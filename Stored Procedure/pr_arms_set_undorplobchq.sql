DELIMITER $$

DROP PROCEDURE IF EXISTS `pr_arms_set_undorplobchq` $$
CREATE PROCEDURE `pr_arms_set_undorplobchq`(
  in pr_rplob_gid int,
  out pr_result tinyint,
  out pr_msg text
)
me:begin
  declare v_rplob_status int default 0;
  declare i int;
  declare j int;

  DECLARE EXIT HANDLER FOR SQLEXCEPTION
  BEGIN
	  ROLLBACK;

    set pr_result = 0;
    set pr_msg = 'SQLEXCEPTION';
  END;

  select status_flag into v_rplob_status from arms_mst_tstatus
  where status_desc = 'Rplob'
  and delete_flag = 'N';

  if v_rplob_status = 0 then
    set pr_result = 0;
    set pr_msg = 'Unable to find rplob status value';
    leave me;
  end if;

  select count(*) into i from arms_trn_trplob
  where rplob_gid = pr_rplob_gid
  and chq_gid > 0
  and delete_flag = 'N';

  START TRANSACTION;

  update arms_trn_trplob as r
  inner join arms_trn_tcheque as c on r.chq_gid = c.chq_gid
  and c.delete_flag = 'N'
  set
  c.chq_status = c.chq_status ^ v_rplob_status,
  r.chq_gid = 0
  where r.rplob_gid = pr_rplob_gid
  and c.chq_status & v_rplob_status > 0
  and c.available_flag = 1
  and r.delete_flag = 'N';

  COMMIT;

  select count(*) into j from arms_trn_trplob
  where file_gid = pr_rplob_gid
  and chq_gid > 0
  and delete_flag = 'N';

  set pr_result = 1;
  set pr_msg = concat('Out of ',cast(i as nchar),' record(s) ',cast((i-j) as nchar), ' undo made successfully !');
END $$

DELIMITER ;