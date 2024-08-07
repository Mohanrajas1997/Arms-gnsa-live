DELIMITER $$

DROP PROCEDURE IF EXISTS `pr_arms_set_postpullout` $$
CREATE PROCEDURE `pr_arms_set_postpullout`(
  in pr_file_gid int,
  out pr_result tinyint,
  out pr_msg text

 )
me:begin

  DECLARE done INT DEFAULT 0;
  declare v_entity_gid int;
  declare v_contract_no varchar(30);
  declare v_chq_date date ;
  declare v_chq_no varchar(30);
  declare v_chq_amount double(15,2);
  declare v_chq_gid int;
  declare v_pullout_gid int;
  declare v_pullout_status int;
  declare v_rplob_status int;
  declare v_before_count int;
  declare v_after_count int;

  Declare file_cur cursor for
  select pullout_gid,entity_gid,contract_no,chq_date,chq_no,chq_amount from arms_trn_tpullout
  where file_gid = pr_file_gid
  and chq_gid =0
  and delete_flag='N';

  declare continue handler for not found set done = 1;

  DECLARE EXIT HANDLER FOR SQLEXCEPTION
  BEGIN
	  ROLLBACK;

    set pr_result = 0;
    set pr_msg = 'SQLEXCEPTION';
  END;

  select status_flag into v_pullout_status from arms_mst_tstatus where status_desc = 'Pullout' and delete_flag = 'N';
  select status_flag into v_rplob_status from arms_mst_tstatus where status_desc = 'Rplob' and delete_flag = 'N';

  if v_pullout_status = 0 then
    set pr_result = 0;
    set pr_msg = 'Pullout status value zero';
    leave me;
  end if;

  if v_rplob_status = 0 then
    set pr_result = 0;
    set pr_msg = 'Rplob status value zero';
    leave me;
  end if;

  select count(*) into v_before_count from arms_trn_tpullout
  where file_gid = pr_file_gid
  and chq_gid =0
  and delete_flag='N';

    open file_cur;

    read_loop: LOOP

      fetch file_cur into v_pullout_gid,v_entity_gid,v_contract_no,v_chq_date,v_chq_no,v_chq_amount;

      IF done = 1 then
          LEAVE read_loop;
      END IF;

      if exists (
          select chq_gid from arms_trn_tcheque
          where entity_gid = v_entity_gid
          and contract_no = v_contract_no
          and chq_date = v_chq_date
          and chq_no = v_chq_no
          and chq_amount = v_chq_amount
          and available_flag = 1
          and chq_status & v_rplob_status = 0
          and delete_flag='N') then
        begin
          set v_chq_gid := 0;

          select chq_gid into v_chq_gid from arms_trn_tcheque
          where entity_gid = v_entity_gid
          and contract_no = v_contract_no
          and chq_date = v_chq_date
          and chq_no = v_chq_no
          and chq_amount = v_chq_amount
          and available_flag = 1
          and chq_status & v_rplob_status = 0
          and delete_flag='N' limit 0,1;

          set v_chq_gid := ifnull(v_chq_gid,0);

          update arms_trn_tpullout set chq_gid = v_chq_gid
          where pullout_gid = v_pullout_gid and chq_gid = 0 and delete_flag='N';

          update arms_trn_tcheque set
          available_flag = 0,
          chq_status = chq_status | v_pullout_status
          where chq_gid = v_chq_gid
          and available_flag = 1
          and chq_status & v_rplob_status = 0
          and delete_flag='N';
        end;
      end if;
    END LOOP read_loop;

    close file_cur;

    SET done=0;

  select count(*) into v_after_count from arms_trn_tpullout
  where file_gid = pr_file_gid
  and chq_gid =0
  and delete_flag='N';

  set pr_result = 1;
  set pr_msg = concat('Out of ',cast(v_before_count as nchar),' record(s) ',
                      cast(v_before_count - v_after_count as nchar),' posted successfully !');

END $$

DELIMITER ;