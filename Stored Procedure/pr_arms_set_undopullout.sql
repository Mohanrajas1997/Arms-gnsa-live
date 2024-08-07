DELIMITER $$

DROP PROCEDURE IF EXISTS `pr_arms_set_undopullout` $$
CREATE PROCEDURE `pr_arms_set_undopullout`(
  in pr_file_gid int,
  out pr_result tinyint,
  out pr_msg text
)
me:begin
  declare v_pullout_status int;
  declare i int;
  declare j int;

  DECLARE EXIT HANDLER FOR SQLEXCEPTION
  BEGIN
	  ROLLBACK;

    set pr_result = 0;
    set pr_msg = 'SQLEXCEPTION';
  END;

  select status_flag into v_pullout_status from arms_mst_tstatus
  where status_desc = 'Pullout'
  and delete_flag = 'N';

  if v_pullout_status = 0 then
    set pr_result = 0;
    set pr_msg = 'Pullout status value zero';
    leave me;
  end if;

  select count(*) into i from arms_trn_tpullout
  where file_gid = pr_file_gid
  and chq_gid > 0
  and delete_flag = 'N';

  START TRANSACTION;

  update arms_trn_tpullout as p
  inner join arms_trn_tcheque as c on p.chq_gid = c.chq_gid
  and c.delete_flag = 'N'
  set
  c.chq_status = c.chq_status ^ v_pullout_status,
  c.available_flag = 1,
  p.chq_gid = 0
  where p.file_gid = pr_file_gid
  and c.chq_status & v_pullout_status > 0
  and c.available_flag = 0
  and p.delete_flag = 'N';

  COMMIT;

  select count(*) into j from arms_trn_tpullout
  where file_gid = pr_file_gid
  and chq_gid > 0
  and delete_flag = 'N';

  set pr_result = 1;
  set pr_msg = concat('Out of ',cast(i as nchar),' record(s) ',cast((i-j) as nchar), ' undo made successfully !');
END $$

DELIMITER ;