DELIMITER $$

DROP PROCEDURE IF EXISTS `pr_arms_set_deletebatchcheque` $$
CREATE PROCEDURE `pr_arms_set_deletebatchcheque`(
  in pr_chq_gid int,
  in pr_action_by varchar(16)
)
me:BEGIN
  declare v_batch_status int;
  declare v_chq_amount double(15,2);
  declare v_chq_gid int;

  
  select status_flag into v_batch_status from arms_mst_tstatus where status_desc = 'Batch' and delete_flag = 'N';

  select chq_gid,chq_amount into v_chq_gid,v_chq_amount from arms_trn_tcheque
  where chq_gid = pr_chq_gid
  and available_flag = 0
  and chq_status & v_batch_status > 0
  and delete_flag = 'N';

  if v_chq_gid > 0 then
  
    update arms_trn_tcheque as c
    inner join arms_trn_tbatchcheque as b on c.chq_gid = b.chq_gid and b.delete_flag = 'N'
    inner join arms_trn_tbatch as h on b.batch_gid = h.batch_gid and h.delete_flag = 'N'
    set
    c.available_flag = 1,
    c.chq_status = c.chq_status ^ v_batch_status,
    c.batch_gid = 0,
    b.update_date = sysdate(),
    b.update_by = pr_action_by,
    b.delete_flag = 'Y',
    h.tot_count = h.tot_count - 1,
    h.tot_amount = h.tot_amount - v_chq_amount
    where c.chq_gid = pr_chq_gid
    and c.available_flag = 0
    and c.chq_status & v_batch_status > 0
    and c.delete_flag = 'N';
  end if;
END $$

DELIMITER ;