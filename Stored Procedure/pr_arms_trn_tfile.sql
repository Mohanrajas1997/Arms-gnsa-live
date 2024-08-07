DELIMITER $$

DROP PROCEDURE IF EXISTS `pr_arms_trn_tfile` $$
CREATE PROCEDURE `pr_arms_trn_tfile`(

  in pr_entity_gid int(11),
  in pr_file_name varchar(50),
  in pr_sheet_name varchar(50),
  in pr_file_type tinyint(3),
  in pr_action_by varchar(10),
  in pr_action varchar(16),
  out pr_err_msg text,
  out pr_result int(10)
)
me:BEGIN

  declare err_msg text default '';
  declare err_flag boolean default false;

  DECLARE EXIT HANDLER FOR SQLEXCEPTION
  BEGIN
    ROLLBACK;
    set pr_err_msg = 'SQLEXCEPTION';
    set pr_result = 0;
  END;

  if pr_action = 'INSERT' or pr_action = 'UPDATE' then
	  if pr_entity_gid = 0 then
		  set err_msg := concat(err_msg,'Blank entity gid,');
		  set err_flag := true;
	  end if;

    if pr_file_Name = '' then
		  set err_msg := concat(err_msg,'Blank file Name,');
		  set err_flag := true;
	  end if;
  end if;

  set pr_result = 0;

  IF pr_action = 'INSERT' THEN
	  if exists(select file_gid from arms_trn_tfile where entity_gid = pr_entity_gid
              and file_name = pr_file_name
              and sheet_name = pr_sheet_name
              and file_type = pr_file_type
              and delete_flag = 'N') then
		  set err_msg  := concat(err_msg,'Duplicate  file gid');
		  set err_flag := true;
	  end if;

    if err_flag = false then
		  START TRANSACTION;

		  INSERT INTO arms_trn_tfile(entity_gid,file_name,sheet_name,file_type,import_date,import_by)
		  VALUES(pr_entity_gid,pr_file_name,pr_sheet_name,pr_file_type,sysdate(),pr_action_by);

      COMMIT;

      set pr_result = last_insert_id();
    else
      set pr_result = 0;
	  end if;
  END IF;

  set pr_err_msg = err_msg;

  IF pr_action = 'DELETE' THEN
    START TRANSACTION;

    UPDATE arms_trn_tfile set delete_flag ='Y'
    WHERE entity_gid = pr_entity_gid
    and delete_flag ='N';

    COMMIT;
  END IF;
END $$

DELIMITER ;