DELIMITER $$

DROP PROCEDURE IF EXISTS `pr_arms_trn_tbatchentry` $$
CREATE PROCEDURE `pr_arms_trn_tbatchentry`(
  in pr_entity_gid int,
  in pr_cycle_date date,
  in pr_contract_no varchar(32),
  in pr_chq_no varchar(16),
  in pr_chq_amount double(15,2),
  in pr_chq_gid int,
  in pr_system_ip varchar(16),
  in pr_action varchar(16),
  in pr_action_by varchar(16),
  out pr_result int(10),
  out pr_msg text
)
me:BEGIN
  declare err_msg text default '';
  declare err_flag boolean default false;
  declare v_system_ip varchar(16) default '';
  declare v_result int default 0;
  declare v_chq_gid int default 0;
  declare v_rplob_status tinyint default 0;
  declare v_loc_code varchar(8) default '';

  DECLARE EXIT HANDLER FOR SQLEXCEPTION
  BEGIN
	  ROLLBACK;

    set pr_result = 0;
    set pr_msg = 'SQLEXCEPTION';
  END;

  select status_flag into v_rplob_status from arms_mst_tstatus where status_desc = 'Rplob' and delete_flag = 'N';

  set pr_contract_no := ifnull(pr_contract_no,'');

  if pr_chq_gid = 0 then
	  set pr_chq_gid := null;
  end if;

  if pr_contract_no = '' then
	  set pr_contract_no := null;
  end if;


  if pr_action = "INSERT" then
	  if pr_entity_gid = 0 then
		  set err_msg := concat(err_msg,'Entity Cannot be Zero,');
		  set err_flag := true;
	  end if;

	  if pr_cycle_date = null then
		  set err_msg := concat(err_msg,'Cycle Date Cannot be Blank,');
		  set err_flag := true;
	  end if;

	  if pr_chq_no = '' then
  		set err_msg := concat(err_msg,'Cheque No Cannot be Blank,');
		  set err_flag := true;
	  end if;

	  if pr_chq_amount = 0 then
		  set err_msg := concat(err_msg,'Cheque Amount Cannot be Zero,');
		  set err_flag := true;
	  end if;

    if pr_system_ip = '' then
    set err_msg := concat(err_msg,'System IP Cannot be Blank,');
    set err_flag := true;
    end if;

    if pr_action_by = '' then
    set err_msg := concat(err_msg,'Action by Cannot be Blank,');
    set err_flag := true;
    end if;
  end if;

  select system_ip into v_system_ip from arms_trn_tbatchentry
  where insert_by = pr_action_by
  and delete_flag = 'N' limit 0,1;

  set v_system_ip = ifnull(v_system_ip,'');
  set v_system_ip = if(v_system_ip = '',pr_system_ip,v_system_ip);

  if pr_system_ip <> v_system_ip then
    set err_msg := concat(err_msg,'User Trying To Do Entry From Different System,');
    set err_flag := true;
  end if;


  IF pr_action = "INSERT" THEN
    IF err_flag = false then
      if exists (
	                select chq_gid from arms_trn_tcheque
	                where entity_gid = pr_entity_gid
	                and cycle_date = pr_cycle_date
	                and chq_no = pr_chq_no
	                and chq_amount = pr_chq_amount
	                and chq_gid = ifnull(pr_chq_gid,chq_gid)
	                and contract_no = ifnull(pr_contract_no,contract_no)
	                and available_flag = 1
	                and chq_status & v_rplob_status > 0
                  and delete_flag = 'N'
                ) then

        select count(*) into v_result from arms_trn_tcheque
	      where entity_gid = pr_entity_gid
	      and cycle_date = pr_cycle_date
	      and chq_no = pr_chq_no
	      and chq_amount = pr_chq_amount
	      and chq_gid = ifnull(pr_chq_gid,chq_gid)
	      and contract_no = ifnull(pr_contract_no,contract_no)
	      and available_flag = 1
	      and chq_status & v_rplob_status > 0
        and delete_flag = 'N';

        set v_result := ifnull(v_result,0);
      end if;

      if v_result = 0 then
        set err_msg := concat(err_msg,'No record found,');
        set err_flag := true;
      end if;

      if v_result > 1 then
        set err_msg := concat(err_msg,'More than one record found,');
        set err_flag := true;
      end if;

      if v_result = 1 then
        select chq_gid,loc_code into v_chq_gid,v_loc_code from arms_trn_tcheque
        where entity_gid = pr_entity_gid
        and cycle_date = pr_cycle_date
        and chq_no = pr_chq_no
        and chq_amount = pr_chq_amount
        and chq_gid = ifnull(pr_chq_gid,chq_gid)
        and contract_no = ifnull(pr_contract_no,contract_no)
        and available_flag = 1
		    and chq_status & v_rplob_status > 0
		    and delete_flag = 'N';

        if exists(select batchentry_gid from arms_trn_tbatchentry
		      where chq_gid = v_chq_gid and delete_flag = 'N') then
		      set err_msg := concat(err_msg,'Duplicate Entry,');
		      set err_flag := true;
	      end if;
      end if;

      if err_flag = false then
        START TRANSACTION;

        INSERT INTO arms_trn_tbatchentry(entity_gid,cycle_date,chq_gid,system_ip,insert_date,insert_by)
        VALUES (pr_entity_gid,pr_cycle_date,v_chq_gid,pr_system_ip,sysdate(),pr_action_by);

	      COMMIT;

        set pr_msg = concat('Location : ',v_loc_code,char(13),char(13),char(10), 'Record added successfully !');
      else
        set pr_result = 0;
        set pr_msg = err_msg;
        leave me;
      end if;
    else
        set pr_result = 0;
        set pr_msg = err_msg;
        leave me;
    END IF;
  END IF;

  if pr_action = 'DELETE' then
    if err_flag = false then
		  START TRANSACTION;

      update arms_trn_tbatchentry set
      update_date = sysdate(),
      update_by = pr_action_by,
      delete_flag = 'Y'
      where chq_gid = pr_chq_gid
      and delete_flag = 'N';

		  COMMIT;

      set pr_msg = 'Record deleted successfully !';
    else
      set pr_result = 0;
      set pr_msg = err_msg;
      leave me;
	  end if;
  end if;

  set pr_result = 1;
END $$

DELIMITER ;