DELIMITER $$

DROP PROCEDURE IF EXISTS `pr_arms_set_undoAplobInput` $$
CREATE PROCEDURE `pr_arms_set_undoAplobInput`(
  in pr_file_gid int,
  out pr_result tinyint,
  out pr_msg text

 )
me:begin
  declare v_AplobInput_status int;
  declare i int;
  declare j int;

  DECLARE EXIT HANDLER FOR SQLEXCEPTION
  BEGIN
	  ROLLBACK;

    set pr_result = 0;
    set pr_msg = 'SQLEXCEPTION';
  END;

  select status_flag into v_AplobInput_status from arms_mst_tstatus
  where status_desc = 'Aplob Input'
  and delete_flag = 'N';

  if v_AplobInput_status = 0 then
    set pr_result = 0;
    set pr_msg = 'Aplop input status value zero';
    leave me;
  end if;

  select count(*) into i from arms_trn_taplobinput
  where file_gid = pr_file_gid
  and chq_gid > 0
  and delete_flag = 'N';

  START TRANSACTION;

  update arms_trn_taplobinput as a
  inner join arms_trn_tcheque as c on a.chq_gid = c.chq_gid
  and c.delete_flag = 'N'
  set
  c.chq_status = c.chq_status ^ v_AplobInput_status,
  a.chq_gid = 0
  where a.file_gid = pr_file_gid
  and c.chq_status & v_AplobInput_status > 0
  and a.delete_flag = 'N';

  COMMIT;

  select count(*) into j from arms_trn_taplobinput
  where file_gid = pr_file_gid
  and chq_gid > 0
  and delete_flag = 'N';

  set pr_result = 1;
  set pr_msg = concat('Out of ',cast(i as nchar),' record(s) ',cast((i-j) as nchar), ' undo made successfully !');
END $$

DELIMITER ;