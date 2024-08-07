DELIMITER $$

DROP PROCEDURE IF EXISTS `pr_arms_trn_tinward` $$
CREATE PROCEDURE `pr_arms_trn_tinward`(
  in pr_inward_gid int(10),
  in pr_entity_gid int(10),
  in pr_received_date date,
  in pr_received_by varchar(16),
  in pr_courier_gid int(10),
  in pr_chq_count int(11),
  in pr_city_gid int(10),
  in pr_awb_no varchar(32),
  in pr_inward_remark varchar(255), 
  in pr_action_by varchar(30),
  in pr_action varchar(30),
  out pr_result int(10),
  out pr_err_msg text
)
me:BEGIN
  declare err_msg text default '';
  declare err_flag boolean default false;

  DECLARE EXIT HANDLER FOR SQLEXCEPTION
  BEGIN
    ROLLBACK;
    set pr_result = 0;
    set pr_err_msg = 'SQLEXCEPTION';
  END;

  if pr_action = 'INSERT' or pr_action = 'UPDATE' then
    if pr_entity_gid = 0 then
      set err_msg := concat(err_msg,'Blank entity gid,');
      set err_flag := true;
    end if;

    if pr_received_date = null then
      set err_msg := concat(err_msg,'Blank recived date,');
      set err_flag := true;
    end if;

    if pr_received_by = '' then
      set err_msg := concat(err_msg,'Blank entity gid,');
      set err_flag := true;
    end if;

    if pr_courier_gid = 0 then
      set err_msg := concat(err_msg,'Blank entity gid,');
      set err_flag := true;
    end if;

    if pr_city_gid = 0 then
      set err_msg := concat(err_msg,'Blank city gid,');
      set err_flag := true;
    end if;

    if pr_chq_count = 0 then
      set err_msg := concat(err_msg,'Blank chq count,');
      set err_flag := true;
    end if;

    if pr_awb_no = '' then
      set err_msg := concat(err_msg,'Blank entity gid,');
      set err_flag := true;
    end if;

    if pr_action_by = '' then
      set err_msg := concat(err_msg,'Blank entity gid,');
      set err_flag := true;
    end if;
  end if;

  IF pr_action = 'INSERT' THEN
    if err_flag = false then
      START TRANSACTION;

      INSERT INTO arms_trn_tinward(entity_gid,received_date,received_by,courier_gid,awb_no,inward_remark,insert_date,insert_by,city_gid,chq_count)
      VALUES (pr_entity_gid,pr_received_date,pr_received_by,pr_courier_gid,pr_awb_no,pr_inward_remark,sysdate(),pr_action_by,pr_city_gid,pr_chq_count);

      COMMIT;
    else
      set pr_result = 0;
      set pr_err_msg = err_msg;
      leave me;
    end if;
  END IF;

  IF pr_action = 'UPDATE' THEN
    if pr_inward_gid > 0 then
      if exists (select count(*) from arms_trn_tinward
        where entity_gid = pr_entity_gid
        and received_date = pr_received_date
        and courier_gid=pr_courier_gid
        and awb_no = pr_awb_no
        and delete_flag = 'N')then

        set err_msg := concat(err_msg,'Duplicate inward,');
        set err_flag := true;
      end if;
    else
        set err_msg := concat(err_msg,'Please select the record,');
        set err_flag := true;
    end if;

    if err_flag = false then
      START TRANSACTION;

      UPDATE arms_trn_tinward
      SET entity_gid = pr_entity_gid,
      received_date = pr_received_date,
      received_by = pr_received_by,
      courier_gid = pr_courier_gid,
      awb_no = pr_awb_no,
      inward_remark = pr_inward_remark,
      insert_date = sysdate(),
      insert_by = pr_action_by,
      update_date = sysdate(),
      city_gid = pr_city_gid,
      chq_count = pr_chq_count,
      update_by = pr_action_by
      WHERE inward_gid = pr_inward_gid
      and delete_flag = 'N';

      COMMIT;
    else
      set pr_result = 0;
      set pr_err_msg = err_msg;
      leave me;
   end if;
  END IF;

  IF pr_action = 'DELETE' THEN
    START TRANSACTION;

    UPDATE arms_trn_tinward set delete_flag = 'Y'
    WHERE inward_gid = pr_inward_gid
    and delete_flag = 'N';

    COMMIT;
  END IF;

 set pr_result = 1;
END $$

DELIMITER ;