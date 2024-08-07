DELIMITER $$

DROP PROCEDURE IF EXISTS `pr_arms_set_generatebatch` $$
CREATE PROCEDURE `pr_arms_set_generatebatch`(
  in pr_entity_gid int,
  in pr_cycle_date date,
  in pr_prod_flag tinyint,
  in pr_loc_code varchar(8),
  in pr_system_ip varchar(16),
  in pr_action_by varchar(16),
  out pr_result int(10),
  out pr_msg text
)
me:BEGIN
  declare err_msg text default '';
  declare err_flag boolean default false;

  declare v_loc_code varchar(8) default '';
  declare v_prod_flag tinyint default 0;
  declare v_tot_count int default 0;
  declare v_tot_amount double(15,2) default 0;
  declare v_batch_gid int default 0;
  declare v_batch_status tinyint default 0;
  declare v_rplob_status tinyint default 2;

  declare done tinyint default 0;

  declare cur_batch cursor for

    select c.loc_code,c.prod_flag,count(*) as tot_count,sum(chq_amount) as tot_amount from arms_trn_tbatchentry as e
    inner join arms_trn_tcheque as c on e.chq_gid = c.chq_gid
    and c.available_flag = 1
    and c.chq_status & v_rplob_status > 0
    and c.delete_flag = 'N'
    where e.entity_gid = pr_entity_gid
    and e.cycle_date = pr_cycle_date
    and c.prod_flag = pr_prod_flag
    and c.loc_code = pr_loc_code
    and e.system_ip = pr_system_ip
    and e.delete_flag = 'N'
    group by c.loc_code,c.prod_flag;

  declare continue handler for not found set done = 1;

  DECLARE EXIT HANDLER FOR SQLEXCEPTION
  BEGIN
	  ROLLBACK;

    set pr_result = 0;
    set pr_msg = 'SQLEXCEPTION';
  END;

  select status_flag into v_batch_status from arms_mst_tstatus where status_desc = 'Batch' and delete_flag = 'N';

  open cur_batch;

  batch_loop:loop
    fetch cur_batch into v_loc_code,v_prod_flag,v_tot_count,v_tot_amount;

    if done = 1 then
      leave batch_loop;
    end if;

    insert into arms_trn_tbatch (entity_gid,cycle_date,loc_code,prod_flag,tot_count,tot_amount,system_ip,
      insert_date,insert_by) values (pr_entity_gid,pr_cycle_date,v_loc_code,v_prod_flag,v_tot_count,v_tot_amount,
      pr_system_ip,sysdate(),pr_action_by);

    select max(batch_gid) into v_batch_gid from arms_trn_tbatch;

    /*where entity_gid = pr_entity_gid
    and cycle_date = pr_cycle_date
    and system_ip = pr_system_ip
    and loc_code = v_loc_code
    and prod_flag = v_prod_flag
    and tot_count = v_tot_count
    and tot_amount = v_tot_amount
    and delete_flag = 'N';
    */

    insert into arms_trn_tbatchcheque (batch_gid,chq_gid)
    select v_batch_gid,c.chq_gid from arms_trn_tbatchentry as e
    inner join arms_trn_tcheque as c on e.chq_gid = c.chq_gid
    and c.available_flag = 1
    and c.loc_code = v_loc_code
    and c.prod_flag = v_prod_flag
    and c.chq_status & v_rplob_status > 0
    and c.delete_flag = 'N'
    where e.entity_gid = pr_entity_gid
    and e.cycle_date = pr_cycle_date
    and e.system_ip = pr_system_ip
    and e.delete_flag = 'N'
    order by batchentry_gid;

    update arms_trn_tbatchentry as e
    inner join arms_trn_tbatchcheque as c on e.chq_gid = c.chq_gid and c.delete_flag = 'N'
    set e.delete_flag = 'Y'
    where e.system_ip = pr_system_ip
    and c.batch_gid = v_batch_gid
    and e.delete_flag = 'N';

    update arms_trn_tcheque as c
    inner join arms_trn_tbatchcheque as b on c.chq_gid = b.chq_gid and b.delete_flag = 'N'
    set
    c.batch_gid = v_batch_gid,
    c.available_flag = 0,
    c.chq_status = c.chq_status | v_batch_status
    where b.batch_gid = v_batch_gid
    and c.available_flag = 1
    and c.chq_status & v_rplob_status > 0
    and c.delete_flag = 'N';

    delete from arms_trn_tbatchentry where system_ip = pr_system_ip and delete_flag = 'Y';
  end loop;

  close cur_batch;

  set pr_result = v_batch_gid;
  set pr_msg = 'Batch generated successfully !';
END $$

DELIMITER ;