DELIMITER $$

DROP PROCEDURE IF EXISTS `pr_arms_trn_tpullout` $$
CREATE PROCEDURE `pr_arms_trn_tpullout`(
  in pr_pullout_gid int(11),
  in pr_entity_gid int(11),
  in pr_file_gid int(10),
  in pr_contract_no varchar(32),
  in pr_chq_date date,
  in pr_chq_no varchar(16),
  in pr_chq_amount double(15,2),
  in pr_pullout_reason varchar(255),
  in pr_action_by  varchar(30),
  in pr_action varchar(30),
  out pr_result int,
  out pr_err_msg text
)
me:BEGIN

  declare err_msg text default '';
  declare err_flag boolean default false;

  DECLARE EXIT HANDLER FOR SQLEXCEPTION
  BEGIN
    ROLLBACK;

    set pr_result = 0;
    set pr_err_msg = 'SQLEXCEPTION';
  END;

  if pr_action = 'INSERT' or pr_action = 'UPDATE' then
	  if pr_entity_gid = 0 then
		  set err_msg := concat(err_msg,'blank entity gid,');
		  set err_flag := true;
	  end if;

    if pr_file_gid = 0 then
		  set err_msg := concat(err_msg,'blank file gid,');
		  set err_flag := true;
    end if;

    if pr_contract_no = '' then
		  set err_msg := concat(err_msg,'blank contract no,');
		  set err_flag := true;
    end if;

    if pr_chq_date = null then
		  set err_msg := concat(err_msg,'blank chq date,');
		  set err_flag := true;
    end if;

    if pr_chq_no = '' then
		  set err_msg := concat(err_msg,'blank chq no,');
		  set err_flag := true;
    end if;

    if pr_chq_amount  = 0 then
		  set err_msg := concat(err_msg,'blank chq amount,');
		  set err_flag := true;
    end if;

    if pr_pullout_reason  = '' then
		  set err_msg := concat(err_msg,'blank pullout reason,');
		  set err_flag := true;
    end if;
  end if;

  IF pr_action = 'INSERT' THEN
	  if exists(select pullout_gid from arms_trn_tpullout where entity_gid = pr_entity_gid  and contract_no =pr_contract_no
    and chq_date = pr_chq_date and chq_no = pr_chq_no and chq_amount = pr_chq_amount and delete_flag = 'N') then
		  set err_msg := concat(err_msg,'Duplicate pullout id,');
		  set err_flag := true;
    end if;

    if err_flag = false then
		  START TRANSACTION;

		  INSERT INTO arms_trn_tpullout(entity_gid,file_gid,contract_no,chq_date,chq_no,chq_amount,pullout_reason,insert_date,insert_by)
		  VALUES(pr_entity_gid,pr_file_gid,pr_contract_no,pr_chq_date,pr_chq_no,pr_chq_amount,pr_pullout_reason,sysdate(),pr_action_by);

		  COMMIT;
    else
      set pr_result := 0;
      set pr_err_msg := err_msg;
      leave me;
    end if;

  END IF;

  IF pr_action = 'DELETE' THEN
    START TRANSACTION;

    UPDATE arms_trn_tpullout set delete_flag = 'Y'
    WHERE pullout_gid = pr_pullout_gid
    and delete_flag = 'N';

    COMMIT;
  END IF;

  set pr_result := 1;
END $$

DELIMITER ;