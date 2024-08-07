DELIMITER $$

DROP PROCEDURE IF EXISTS `pr_arms_trn_taplobinput` $$
CREATE PROCEDURE `pr_arms_trn_taplobinput`(
  in pr_entity_gid int(10),
  in pr_file_gid int(10),
  in pr_contract_no varchar(32),
  in pr_payee_name varchar(128), 
  in pr_cycle_date date,
  in pr_chq_date date,
  in pr_chq_no varchar(16),
  in pr_chq_amount double(15,2),
  in pr_chq_acc_no varchar(128),
  in pr_micr_code varchar(9),    
  in pr_bank_name varchar(128),  
  in pr_bank_branch varchar(128),
  in pr_cts_flag char(1),        
  in pr_chq_remark  varchar(255),
  in pr_packet_no varchar(16),
  in pr_action varchar(30),
  out pr_result int(10),
  out pr_err_msg text
)
me:begin
  declare err_msg text default '';
  declare err_flag boolean default false;

  DECLARE EXIT HANDLER FOR SQLEXCEPTION
  BEGIN
  ROLLBACK;

    set pr_result := 0;
    set pr_err_msg := 'SQLEXCEPTION';
  END;

  if pr_action = 'INSERT' or pr_action = 'UPDATE' then
	  if pr_entity_gid = 0 then
      set err_msg := concat(err_msg,'Blank entity gid,');
      set err_flag := true;
	  end if;

    if pr_file_gid = 0 then
      set err_msg := concat(err_msg,'Blank file gid,');
      set err_flag := true;
	  end if;

    if pr_contract_no = ''then
      set err_msg := concat(err_msg,'Blank contract no,');
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

    if pr_packet_no = '' then
      set err_msg := concat(err_msg,'Blank packet no,');
      set err_flag := true;
	  end if;

    if pr_chq_amount = 0 then
      set err_msg := concat(err_msg,'Cheque amount cannot be zero,');
      set err_flag := true;
    end if;
  end if;


  
  IF pr_action = 'INSERT' THEN
	  if exists(select api_gid from arms_trn_taplobinput where entity_gid = pr_entity_gid
    and file_gid = pr_file_gid and contract_no = pr_contract_no
    and chq_date = pr_chq_date and chq_no = pr_chq_no
    and chq_amount = pr_chq_amount and delete_flag = 'N') then
    set err_msg := concat(err_msg,'Duplicate entity gid,');
    set err_flag := true;
	  end if;

    if err_flag = false then
		  START TRANSACTION;

		  INSERT INTO arms_trn_taplobinput(entity_gid,file_gid,contract_no,payee_name,cycle_date,chq_date,chq_no,chq_amount,chq_acc_no,micr_code,bank_name,bank_branch,cts_flag,chq_remark,packet_no)
		  VALUES (pr_entity_gid,pr_file_gid,pr_contract_no,pr_payee_name,pr_cycle_date,pr_chq_date,pr_chq_no,pr_chq_amount,pr_chq_acc_no,pr_micr_code,pr_bank_name,pr_bank_branch,pr_cts_flag,pr_chq_remark,pr_packet_no);

		  COMMIT;
    else
      set pr_result := 0;
      set pr_err_msg := err_msg;
      leave me;
   end if;
   set pr_result := 1;
 END IF;
end $$

DELIMITER ;