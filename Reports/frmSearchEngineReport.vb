Public Class frmSearchEngineReport

    Dim lsCond As String = ""
    Dim lsCond_scan As String = ""
    Dim lsFld As String = ""

    Private Sub frmSearchEngineReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            gsQry = " select CONCAT(entity_code,'-', entity_name) as EntityCode ,entity_gid from arms_mst_tentity"
            gsQry &= " where delete_flag='N' "
            gsQry &= " order by entity_name "
            Call gpBindCombo(gsQry, "EntityCode", "entity_gid", cboEntity, gOdbcConn)

            Call ClearAll()

            KeyPreview = True

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub ClearAll()
        cboEntity.Text = ""
        txtcontno.Text = ""
        txtchqno.Text = ""
        lblAplobCount.Text = ""
        lblChequeCount.Text = ""
        lblPulloutCount.Text = ""
        lblScanCount.Text = ""
        dgvAplob.DataSource = Nothing
        dgvcheque.DataSource = Nothing
        dgvPullout.DataSource = Nothing
        dgvScan.DataSource = Nothing
        cboEntity.Focus()

    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Call ClearAll()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Try
            Dim dgvRow As DataGridViewRow = Nothing

            lsCond = ""
            lsCond_scan = ""

            If (cboEntity.SelectedIndex = -1 Or cboEntity.Text.Trim = "") Then
                MessageBox.Show("Please Select Entity !", gsProjectName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            Else
                lsCond &= " and a.entity_gid = '" & QuoteFilter(cboEntity.SelectedValue.ToString) & "' "
                lsCond_scan &= " and b.entity_gid = '" & QuoteFilter(cboEntity.SelectedValue.ToString) & "' "
            End If

            If (txtcontno.Text = "" And txtchqno.Text = "") Then
                MessageBox.Show("Please enter contract no (or) cheque no !", gsProjectName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If Not (txtcontno.Text = "") Then
                lsCond &= " and a.contract_no = '" & QuoteFilter(txtcontno.Text.ToString) & "' "
                lsCond_scan &= " and b.contract_no = '" & QuoteFilter(txtcontno.Text.ToString) & "' "
            End If

            If Not (txtchqno.Text = "") Then
                lsCond &= " and a.chq_no = '" & QuoteFilter(txtchqno.Text.ToString) & "' "
                lsCond_scan &= " and a.scan_chq_no = '" & QuoteFilter(txtchqno.Text.ToString) & "' "
            End If

            'Aplob Input Detail Data Binding
            Call LoadAplobData()

            'Cheque Detail Data Binding
            Call LoadChequeData()

            'Pullout Detail Data Binding
            Call LoadPulloutData()

            'Scan Detail Data Binding
            Call LoadScanData()

            With dgvAplob

                For i = 0 To .Rows.Count - 1
                    dgvRow = .Rows(i)

                    If Val(.RowCount) >= 0 Then
                        lblAplobCount.Visible = True
                        lblAplobCount.ForeColor = Color.DarkRed
                    End If
                Next i

                lblAplobCount.Text = "Total : " & .RowCount
            End With

            With dgvcheque

                For i = 0 To .Rows.Count - 1
                    dgvRow = .Rows(i)

                    If Val(.RowCount) >= 0 Then
                        lblChequeCount.Visible = True
                        lblChequeCount.ForeColor = Color.DarkRed
                    End If
                Next i

                lblChequeCount.Text = "Total : " & .RowCount
            End With

            With dgvPullout

                For i = 0 To .Rows.Count - 1
                    dgvRow = .Rows(i)

                    If Val(.RowCount) >= 0 Then
                        lblPulloutCount.Visible = True
                        lblPulloutCount.ForeColor = Color.DarkRed
                    End If
                Next i

                lblPulloutCount.Text = "Total : " & .RowCount
            End With

            With dgvScan

                For i = 0 To .Rows.Count - 1
                    dgvRow = .Rows(i)

                    If Val(.RowCount) >= 0 Then
                        lblScanCount.Visible = True
                        lblScanCount.ForeColor = Color.DarkRed
                    End If
                Next i

                lblScanCount.Text = "Total : " & .RowCount
            End With

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, gsProjectName)
        End Try
    End Sub

    Private Sub LoadAplobData(Optional ByVal RunFlag As Boolean = False)
        Try
            gsQry = ""
            gsQry &= " select "
            gsQry &= " a.Lot_no as 'Lot No',a.contract_no as 'Contract No',a.payee_name as 'Payee Name',a.cycle_date as 'Cycle Date',a.chq_date as 'Cheque Date',a.chq_no as 'Cheque No', "
            gsQry &= " a.chq_amount as 'Cheque Amount',a.chq_acc_no as 'A/C No',a.bank_name as 'Bank Name', a.api_gid as 'API Gid',a.chq_gid as 'Cheque Gid',"
            gsQry &= " b.file_name as 'File Name', c.entity_name as 'Entity Name',"
            gsQry &= " b.import_date as 'Import Date',a.micr_code as 'Micr Code',a.bank_code as 'Bank Code',a.bank_name as 'Bank Name',a.bank_branch as 'Branch Name',a.cts_flag as 'CTS Flag',a.chq_remark as 'Remark',a.packet_no as 'Packet No'"

            gsQry &= " from arms_trn_taplobinput as a"
            gsQry &= " left join arms_trn_tfile as b on a.file_gid=b.file_gid and b.delete_flag = 'N'"
            gsQry &= " left join arms_mst_tentity as c on c.entity_gid=a.entity_gid and c.delete_flag = 'N'"
            gsQry &= " where true "
            gsQry &= lsCond
            gsQry &= " and a.delete_flag='N' "

            Call gpPopGridView(dgvAplob, gsQry, gOdbcConn)

            dgvAplob.AutoResizeColumns()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, gsProjectName)
        End Try
    End Sub

    Private Sub LoadChequeData(Optional ByVal RunFlag As Boolean = False)
        Try
            lsFld = ""
            lsFld &= " h.lot_no as 'Lot No',"
            lsFld &= "c.entity_code as 'ClientCode',"
            lsFld &= "'CITIOPS' as 'DealerCode',"
            lsFld &= "a.box_no as 'BoxNo',"
            lsFld &= "'PDC' as 'ChequeType',"
            lsFld &= "h.contract_no as 'ContractNo',"
            lsFld &= "'' as 'InvoiceDate',"
            lsFld &= "a.chq_date as 'DueDate',"
            lsFld &= "a.chq_amount as 'ChequeAmount',"
            lsFld &= "a.chq_no as 'ChequeNo',"
            lsFld &= "'' as 'ToChequeNo',"
            lsFld &= "a.chq_date as 'ChequeDate',"
            lsFld &= "a.chq_amount as 'ChequeAmount',"
            lsFld &= "c.entity_code as 'PayTo',"
            lsFld &= "'W' as 'Status',"
            lsFld &= "a.micr_code as 'SortKey',"
            lsFld &= "d.loc_name as 'Storage',"
            lsFld &= "a.micr_code as 'SortKey',"
            lsFld &= "d.loc_name as 'PayableLocation',"
            lsFld &= "a.chq_acc_no as 'AccountNo',"
            lsFld &= "a.cuboard_no as 'CuboardNo',"
            lsFld &= "a.shelf_no as 'ShelfNo',"
            lsFld &= "h.cover_no as 'CoverNO',"
            lsFld &= "a.chq_amount as 'BreakupAmount',"
            lsFld &= "a.payee_name as 'Remark1_CustomerName',"
            lsFld &= "d.loc_name as 'Remark2',"
            lsFld &= "a.chq_acc_no as 'Remark3',"
            lsFld &= "h.contract_no as 'Remark4',"
            lsFld &= "'' as 'Remark5',"
            lsFld &= "a.cts_flag as 'CTS',"
            lsFld &= "'' as 'Remark7',"
            lsFld &= "'' as 'Remark8',"
            lsFld &= "'' as 'Remark9',"
            lsFld &= "'' as 'Remark10',"
            lsFld &= "a.additional1 as 'Addition1',"
            lsFld &= "a.additional2 as 'Addition2',"
            lsFld &= "a.additional3 as 'Addition3',"
            lsFld &= "a.additional4 as 'Addition4',"
            lsFld &= "a.additional5 as 'Addition5',"
            lsFld &= " make_set(a.chq_status," & gsChqStatus & ") as 'Chq Status',"
            lsFld &= "(select group_concat(disc_desc) from arms_mst_tdisc where disc_flag & a.chq_disc = disc_flag and disc_type='chq' and delete_flag='N') as 'Chq Disc Status', "
            lsFld &= "a.chq_remark as 'Chq Disc Status',"
            lsFld &= "e.prod_code as 'Product',"
            lsFld &= "a.bank_name as 'Bank Name',"
            lsFld &= "a.batch_gid as 'Batch Id',"
            lsFld &= "g.batchchq_gid as 'Batch Chq Id',"
            lsFld &= "a.chq_gid as 'Cheque Id'"

            gsQry = ""
            gsQry &= " select " & lsFld
            gsQry &= " from arms_trn_tcheque as a"
            gsQry &= " left join arms_trn_tpacket as h on a.packet_gid=h.packet_gid and h.delete_flag='N'"
            gsQry &= " left join arms_trn_tfile as b on b.file_gid=a.file_gid and b.delete_flag = 'N'"
            gsQry &= " left join arms_mst_tentity as c on c.entity_gid=a.entity_gid and c.delete_flag = 'N'"
            gsQry &= " left join arms_mst_tlocation as d on d.loc_code = a.loc_code and d.delete_flag = 'N' "
            gsQry &= " left join arms_mst_tproduct as e on e.prod_flag = a.prod_flag and e.delete_flag = 'N' "
            gsQry &= " left join arms_trn_tbatchentry as f on f.chq_gid = a.chq_gid and f.delete_flag = 'N' "
            gsQry &= " left join arms_trn_tbatchcheque as g on g.chq_gid = a.chq_gid and g.delete_flag = 'N' "
            gsQry &= " where true "
            gsQry &= lsCond
            gsQry &= " and a.delete_flag='N' "
            gsQry &= " order by h.lot_no,h.cover_no,a.chq_gid, g.batchchq_gid asc "

            Call gpPopGridView(dgvcheque, gsQry, gOdbcConn)

            dgvcheque.AutoResizeColumns()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, gsProjectName)
        End Try
    End Sub

    Private Sub LoadPulloutData(Optional ByVal RunFlag As Boolean = False)
        Try
            gsQry = ""
            gsQry &= " select "
            gsQry &= " a.chq_date as 'Cheque Date', a.chq_no as 'Cheque No',a.contract_no as 'Contract No',"
            gsQry &= "a.chq_amount as 'Cheque Amount',a.pullout_reason as 'Pullout Reason',c.entity_name as 'Entity Name',"
            gsQry &= " d.packet_no as 'Packet No',d.shelf_no as 'Shelf No',d.cuboard_no as 'Cuboard No',d.box_no as 'Box No',"
            gsQry &= " a.insert_date as 'Inserted Date',a.insert_by as 'Inserted By',a.update_date as 'Update Date',a.update_by as 'Update By',"
            gsQry &= " b.file_name as 'File Name', b.import_date as 'Import Date',b.import_by as 'Import By',"
            gsQry &= " a.chq_gid as 'Cheque Id',a.pullout_gid as 'Pullout Id',a.entity_gid as 'Entity Id',a.file_gid as 'File Id',a.dispatch_gid as 'Dispatch Id', "
            gsQry &= " date_format(e.dispatch_date,'%d-%m-%Y') as 'Dispatch Date',e.awb_no as 'Awb No',e.dispatch_addr as 'Dispatch Addr',e.dispatch_by as 'Dispatch By',"
            gsQry &= " case when a.available_flag='P' then 'Pending' when a.available_flag='Y' then 'Yes' when a.available_flag='N' then 'No' end as 'Available', "
            gsQry &= " a.status_by as 'Updated By',a.status_date as 'Updated Date'"
            gsQry &= " from arms_trn_tpullout as a"
            gsQry &= " left join arms_trn_tfile as b on a.file_gid=b.file_gid and b.delete_flag = 'N'"
            gsQry &= " left join arms_mst_tentity as c on c.entity_gid=a.entity_gid and c.delete_flag = 'N'"
            gsQry &= " left join arms_trn_tcheque as d on d.chq_gid = a.chq_gid and d.delete_flag = 'N' "
            gsQry &= " left join arms_trn_tdispatch as e on a.entity_gid=e.entity_gid and a.dispatch_gid=e.dispatch_gid and e.delete_flag='N'"
            gsQry &= " where true "
            gsQry &= lsCond
            gsQry &= " and a.delete_flag='N' "

            Call gpPopGridView(dgvPullout, gsQry, gOdbcConn)

            dgvPullout.AutoResizeColumns()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, gsProjectName)
        End Try
    End Sub

    Private Sub LoadScanData(Optional ByVal RunFlag As Boolean = False)
        Try

            gsQry = ""
            gsQry &= " select "
            gsQry &= " a.scan_gid as 'Scan gid',"
            gsQry &= " a.scan_packet_gid as 'Scan Packet gid',"
            gsQry &= " a.scan_chq_no as 'Cheque No',"
            gsQry &= " a.scan_micr_code as 'Micr Code',"
            gsQry &= " a.scan_tran_code as 'Tran Code',"
            gsQry &= " a.scan_base_code as 'Base Code',"
            gsQry &= " a.scan_chq_date as 'Cheque Date',"
            gsQry &= " a.scan_chq_amount as 'Cheque Amt',"
            gsQry &= " a.scan_bank_code as 'Bank Code',"
            gsQry &= " a.scan_bank_name as 'Bank Name',"
            gsQry &= " a.scan_chq_gid as 'Scan Cheque gid',"
            gsQry &= " a.scan_chq_type as 'Scan Cheque type',"
            gsQry &= " a.scan_status as 'Scan Status'"
            gsQry &= " from  arms_trn_tscan   as a"
            gsQry &= " left join arms_trn_tpacket as b on a.scan_packet_gid = b.packet_gid and b.delete_flag = 'N'"
            gsQry &= " left join arms_trn_tfile as c on b.file_gid=c.file_gid and c.delete_flag = 'N'"
            gsQry &= " left join arms_mst_tentity as d on d.entity_gid=b.entity_gid and d.delete_flag = 'N'"
            gsQry &= " where true "
            gsQry &= lsCond_scan
            'gsQry &= " and a.delete_flag='N' "


            Call gpPopGridView(dgvScan, gsQry, gOdbcConn)

            dgvScan.AutoResizeColumns()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, gsProjectName)
        End Try
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Try
            PrintDGViewXML(dgvAplob, gsReportPath & "Aplopb.xls", "Aplopb", True, True)
            PrintDGViewXML(dgvcheque, gsReportPath & "Cheque.xls", "Cheque", False, True)
            PrintDGViewXML(dgvPullout, gsReportPath & "Pullout.xls", "Pullout", False, True)
            PrintDGViewXML(dgvScan, gsReportPath & "Scan.xls", "Scan", False, True)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub frmSearchEngineReport_SizeChanged(sender As System.Object, e As System.EventArgs) Handles MyBase.SizeChanged
        Dim grid_height As Integer = 0
        Dim grid_width As Integer = 0
        Dim control_space As Integer = 8

        grid_width = Me.Width - control_space * 5

        grid_height = (Me.Height - (grpMain.Top + grpMain.Height + lblAplobinput.Height * 4 + control_space * 12)) / 4

        dgvAplob.Width = grid_width
        dgvAplob.Height = grid_height

        lblCheque.Top = dgvAplob.Top + dgvAplob.Height + control_space
        lblChequeCount.Top = lblCheque.Top

        dgvcheque.Top = lblCheque.Top + lblCheque.Height + control_space
        dgvcheque.Width = grid_width
        dgvcheque.Height = grid_height

        lblPullout.Top = dgvcheque.Top + dgvcheque.Height + control_space
        lblPulloutCount.Top = lblPullout.Top

        dgvPullout.Top = lblPullout.Top + lblPullout.Height + control_space
        dgvPullout.Width = grid_width
        dgvPullout.Height = grid_height

        lblScan.Top = dgvPullout.Top + dgvPullout.Height + control_space
        lblScanCount.Top = lblScan.Top

        dgvScan.Top = lblScan.Top + lblScan.Height + control_space
        dgvScan.Width = grid_width
        dgvScan.Height = grid_height
    End Sub
End Class