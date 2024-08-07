DELIMITER $$

DROP PROCEDURE IF EXISTS `pr_arms_get_batchAllChq` $$
CREATE PROCEDURE `pr_arms_get_batchAllChq`(
  in pr_batch_gid int
)
begin
  select
    a.payee_name as 'Customer Name',
    a.bank_name as 'Bank',
    a.micr_code as 'Micr Code',
    DATE_FORMAT(a.chq_date, '%d/%m/%Y') as chq_date,
    DATE_FORMAT(a.cycle_date, '%d/%m/%Y') as 'Cycle Date',
    a.loc_code as 'Pickup Loca',
    a.chq_no as 'Chq No',
    a.chq_amount as 'Amount',
    a.loc_code as 'Loc Code',
    b.entity_code as 'Entity Code'
  from arms_trn_tcheque as a
  inner join arms_mst_tentity as b on b.entity_gid = a.entity_gid
  inner join arms_mst_tproduct as c on c.prod_flag = a.prod_flag
  inner join arms_trn_tbatchcheque as d on d.chq_gid = a.chq_gid and d.delete_flag = 'N'
  where a.batch_gid = pr_batch_gid
  and a.delete_flag = 'N'
  order by d.batchchq_gid asc;

end $$

DELIMITER ;