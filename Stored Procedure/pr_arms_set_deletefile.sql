DELIMITER $$

DROP PROCEDURE IF EXISTS `pr_arms_set_deletefile` $$
CREATE PROCEDURE `pr_arms_set_deletefile`(
 in pr_entity_gid int(10),
 in pr_file_gid int(10),
 in pr_file_type tinyint(3),
 in pr_action_by varchar(16),
 out pr_result int,
 out pr_msg text
)
me:Begin
  declare recordfound int;
  declare err_msg text default '';
  declare err_flag boolean default false;

  DECLARE EXIT HANDLER FOR SQLEXCEPTION
  BEGIN
    ROLLBACK;

    set pr_result = 0;
    set pr_msg = 'SQLEXCEPTION,';
  END;

 
  if pr_entity_gid = 0 then
    set err_msg := concat(err_msg,'Blank entity,');
    set err_flag := true;
  end if;

  if pr_file_gid = 0 then
    set err_msg := concat(err_msg,'Blank file name,');
    set err_flag := true;
  end if;

  if pr_file_type = 0 then
    set err_msg :=concat(err_msg,'Blank file type,');
    set err_flag :=true;
  end if;


  if pr_file_type = 1 then

     select count(*) into recordfound from arms_trn_taplobinput
     where entity_gid=pr_entity_gid and file_gid = pr_file_gid
     and chq_gid > 0 and delete_flag = 'N';

    if recordfound > 0 then
      set pr_result:= 0;
      set err_msg := concat(err_msg,'Access denied,');
      set err_flag := true;
    else

      UPDATE arms_trn_tfile set delete_flag = 'Y',
      update_date=sysdate(),update_by=pr_action_by
      WHERE file_gid = pr_file_gid and delete_flag='N';

      UPDATE arms_trn_taplobinput set delete_flag = 'Y'
      WHERE file_gid = pr_file_gid and delete_flag='N';

      set pr_result = pr_file_gid;
      set pr_msg = 'File deleted successfully !';
    end if;
  end if;


  if pr_file_type = 2 then

     select count(*) into recordfound from arms_trn_tcheque
     where entity_gid=pr_entity_gid and file_gid = pr_file_gid
     and chq_status > 0 and delete_flag = 'N';

    if recordfound > 0 then
      set pr_result:= 0;
      set err_msg := concat(err_msg,'Access denied,');
      set err_flag := true;
    else

      UPDATE arms_trn_tfile set delete_flag = 'Y',
      update_date=sysdate(),
      update_by=pr_action_by
      WHERE file_gid = pr_file_gid and delete_flag='N';

      UPDATE arms_trn_tcheque set delete_flag = 'Y'
      WHERE file_gid = pr_file_gid and delete_flag='N';

      set pr_result = pr_file_gid;
      set pr_msg = 'File deleted successfully !';
    end if;
  end if;

  if pr_file_type=3 then

     select count(*) into recordfound from arms_trn_tcheque
     where entity_gid=pr_entity_gid and file_gid = pr_file_gid
     and chq_status > 0 and delete_flag = 'N';

    if recordfound > 0 then
      set pr_result:= 0;
      set err_msg := concat(err_msg,'Access denied,');
      set err_flag := true;
    else

      UPDATE arms_trn_tfile set delete_flag = 'Y',
      update_date=sysdate(),update_by=pr_action_by
      WHERE file_gid = pr_file_gid and delete_flag='N';

      UPDATE arms_trn_tcheque set delete_flag = 'Y'
      WHERE file_gid = pr_file_gid and delete_flag='N';

      set pr_result = pr_file_gid;
      set pr_msg = 'File deleted successfully !';
   end if;
  end if;

  if pr_file_type=4 then
     select count(*) into recordfound from arms_trn_trplob
     where entity_gid=pr_entity_gid and file_gid = pr_file_gid
     and chq_gid > 0 and delete_flag = 'N';

    if recordfound > 0 then
      set pr_result:= 0;
      set err_msg := concat(err_msg,'Access denied,');
      set err_flag := true;
    else
      UPDATE arms_trn_tfile set delete_flag = 'Y',
      update_date=sysdate(),update_by=pr_action_by
      WHERE file_gid = pr_file_gid and delete_flag='N';

      UPDATE arms_trn_trplob set delete_flag = 'Y'
      WHERE file_gid = pr_file_gid and chq_gid = 0 and delete_flag='N';

      set pr_result = pr_file_gid;
      set pr_msg = 'File deleted successfully !';
   end if;
  end if;

  if pr_file_type=5 then

      select count(*) into recordfound from arms_trn_tpullout
      where entity_gid=pr_entity_gid and file_gid = pr_file_gid
      and chq_gid > 0 and delete_flag = 'N';

    if recordfound > 0 then
      set pr_result:= 0;
      set err_msg := concat(err_msg,'Access denied,');
      set err_flag := true;
    else

      UPDATE arms_trn_tfile set delete_flag = 'Y',
      update_date=sysdate(),update_by=pr_action_by
      WHERE file_gid = pr_file_gid and delete_flag='N';

      UPDATE arms_trn_tpullout set delete_flag = 'Y'
      WHERE file_gid = pr_file_gid and delete_flag='N';

      set pr_result = pr_file_gid;
      set pr_msg = 'File deleted successfully !';
   end if;
  end if;

  if err_flag = true then
     set pr_result = 0;
     set pr_msg = err_msg;
     leave me;
  end if;


END $$

DELIMITER ;