DELIMITER $$

DROP PROCEDURE IF EXISTS `pr_arms_trn_tcheque` $$
CREATE PROCEDURE `pr_arms_trn_tcheque`(
  in pr_entity_gid int(10),
  in pr_file_gid int(10),
  in pr_contract_no varchar(32),
  in pr_payee_name varchar(128), 
  in pr_loc_name varchar(64),
  in pr_prod_code varchar(8),
  in pr_cycle_date date,
  in pr_chq_date date,
  in pr_chq_amount double(15,2),
  in pr_chq_no varchar(16),
  in pr_chq_acc_no varchar(128), 
  in pr_micr_code varchar(16),    
  in pr_bank_name varchar(128),  
  in pr_bank_branch varchar(128),
  in pr_cts_flag char(1),        
  in pr_chq_remark varchar(255), 
  in pr_packet_no varchar(50),
  in pr_cuboard_no varchar(32),
  in pr_shelf_no varchar(32),
  in pr_box_no varchar(32),
  in pr_action varchar(30),
  out pr_result int(10),
  out pr_err_msg text
)
me:BEGIN
  declare err_msg text default '';
  declare err_flag boolean default false;
  declare dr_prod_flag int default 0;
  declare dr_loc_code varchar(3) default '';

  DECLARE EXIT HANDLER FOR SQLEXCEPTION
  BEGIN
  ROLLBACK;

    set pr_result = 0;
    set pr_err_msg = 'SQLEXCEPTION';
  END;

  select loc_code into dr_loc_code from arms_mst_tlocation where loc_name = pr_loc_name and delete_flag = 'N';
  select prod_flag into dr_prod_flag from arms_mst_tproduct where prod_code = pr_prod_code and delete_flag = 'N';

  set dr_loc_code = ifnull(dr_loc_code,'');
  set dr_prod_flag = ifnull(dr_prod_flag,0);

  
 if pr_action = 'INSERT' or pr_action = 'UPDATE' then
	  if pr_entity_gid = 0 then
    set err_msg := concat(err_msg,'Blank entity gid,');
    set err_flag := true;
	  end if;

    if pr_file_gid = 0 then
    set err_msg := concat(err_msg,'Blank file gid,');
    set err_flag := true;
	  end if;

   if pr_contract_no = '' then
   set err_msg := concat(err_msg,'Blank contract no,');
   set err_flag := true;
   end if;

   if pr_loc_name = '' then
     set err_msg := concat(err_msg,'Blank local name,');
     set err_flag := true;
   end if;

   if dr_loc_code = '' then
     set err_msg := concat(err_msg,'Location name to be maintained,');
     set err_flag := true;
   end if;

   if  pr_prod_code = '' then
     set err_msg := concat(err_msg,'Blank prod code,');
     set err_flag := true;
   end if;

   if  dr_prod_flag = 0 then
     set err_msg := concat(err_msg,'Product code to be maintained,');
     set err_flag := true;
   end if;

   if pr_cycle_date = null then
     set err_msg := concat(err_msg,'Blank cycle date,');
     set err_flag := true;
   end if;

   if pr_chq_date = null then
   set err_msg := concat(err_msg,'Blank chq date,');
   set err_flag := true;
   end if;

   if pr_chq_no = '' then
   set err_msg := concat(err_msg,'Blank chq no,');
   set err_flag := true;
   end if;

   if pr_chq_amount = 0 then
   set err_msg := concat(err_msg,'Blank chq amount,');
   set err_flag := true;
   end if;
 end if;

  
  IF pr_action = 'INSERT' THEN

	  if exists(select chq_gid from arms_trn_tcheque where entity_gid = pr_entity_gid and  contract_no = pr_contract_no
    and chq_date = pr_chq_date and chq_no = pr_chq_no and chq_amount = pr_chq_amount and delete_flag = 'N') then
    set err_msg := concat(err_msg,'Duplicate entity gid,');
    set err_flag := true;
    end if;

    if err_flag = false then
     START TRANSACTION;

		  INSERT INTO arms_trn_tcheque(entity_gid,file_gid,contract_no,payee_name,loc_code, prod_flag,cycle_date,chq_date,
      chq_amount,chq_no,chq_acc_no,micr_code,bank_name,bank_branch,cts_flag,chq_remark,available_flag,
      packet_no,cuboard_no,shelf_no,box_no,org_chq_date,org_chq_no,org_chq_amount)
		  VALUES (pr_entity_gid,pr_file_gid,pr_contract_no,pr_payee_name,dr_loc_code,dr_prod_flag,pr_cycle_date,pr_chq_date,
      pr_chq_amount,pr_chq_no,pr_chq_acc_no,pr_micr_code,pr_bank_name,pr_bank_branch,pr_cts_flag,pr_chq_remark,1,
      pr_packet_no,pr_cuboard_no,pr_shelf_no,pr_box_no,pr_chq_date,pr_chq_no,pr_chq_amount);

		  COMMIT;
    else
      set pr_result = 0;
      set pr_err_msg = err_msg;
      leave me;
	  end if;
  END IF;
      set pr_result = 1;
END $$

DELIMITER ;