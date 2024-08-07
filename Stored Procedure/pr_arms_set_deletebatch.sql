DELIMITER $$

DROP PROCEDURE IF EXISTS `pr_arms_set_deletebatch` $$
CREATE PROCEDURE `pr_arms_set_deletebatch`(
  in pr_batch_gid int,
  in pr_action_by varchar(16)
)
me:BEGIN
  declare v_batch_status int;

  
  select status_flag into v_batch_status from arms_mst_tstatus where status_desc = 'Batch' and delete_flag = 'N';

  
  update arms_trn_tbatch set
  update_date = sysdate(),
  update_by = pr_action_by,
  delete_flag = 'Y'
  where batch_gid = pr_batch_gid
  and delete_flag = 'N';

  
  update arms_trn_tcheque as c
  inner join arms_trn_tbatchcheque as b on c.chq_gid = b.chq_gid and b.delete_flag = 'N'
  set
  c.available_flag = 1,
  c.chq_status = c.chq_status ^ v_batch_status,
  c.batch_gid = 0,
  b.delete_flag = 'Y'
  where b.batch_gid = pr_batch_gid
  and c.available_flag = 0
  and c.chq_status & v_batch_status > 0
  and c.delete_flag = 'N';
END $$

DELIMITER ;