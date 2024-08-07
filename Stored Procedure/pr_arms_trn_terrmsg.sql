DELIMITER $$

DROP PROCEDURE IF EXISTS `pr_arms_trn_terrmsg` $$
CREATE PROCEDURE `pr_arms_trn_terrmsg`(
  in pr_file_gid int(11),
  in pr_errmsg_desc text,
  in pr_action varchar(16),
  out pr_result int(10),
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

  IF pr_action = 'INSERT' THEN
    if err_flag = false then
		  START TRANSACTION;

		  INSERT INTO arms_trn_terrmsg(file_gid,errmsg_desc )
		  VALUES (pr_file_gid,pr_errmsg_desc);

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