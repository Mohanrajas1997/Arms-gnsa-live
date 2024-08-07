Public Class frmChequeReport

    Dim lsCond As String = ""

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub LoadData(Optional RunFlag As Boolean = False)
        Dim i As Integer
        Dim lsFld As String

        lsCond = ""

        Try
            If dtpImportFrom.Checked = True Then lsCond &= " and b.import_date >='" & Format(dtpImportFrom.Value, "yyyy-MM-dd") & "' "
            If dtpImportTo.Checked = True Then lsCond &= " and b.import_date < '" & Format(DateAdd(DateInterval.Day, 1, dtpImportTo.Value), "yyyy-MM-dd") & "' "

            If dtpCycleFrom.Checked = True Then lsCond &= " and a.cycle_date >='" & Format(dtpCycleFrom.Value, "yyyy-MM-dd") & "' "
            If dtpCycleTo.Checked = True Then lsCond &= " and a.cycle_date < '" & Format(DateAdd(DateInterval.Day, 1, dtpCycleTo.Value), "yyyy-MM-dd") & "' "

            If dtpChqForm.Checked = True Then lsCond &= " and a.chq_date >='" & Format(dtpChqForm.Value, "yyyy-MM-dd") & "' "
            If dtpChqTo.Checked = True Then lsCond &= " and a.chq_date < '" & Format(DateAdd(DateInterval.Day, 1, dtpChqTo.Value), "yyyy-MM-dd") & "' "

            If Not (cboFileName.SelectedIndex = -1 Or cboFileName.Text = "") Then
                lsCond &= " and b.file_gid ='" & Val(cboFileName.SelectedValue.ToString) & "' "
            End If

            If Not (cboEntity.SelectedIndex = -1 Or cboEntity.Text.Trim = "") Then
                lsCond &= " and a.entity_gid = '" & QuoteFilter(cboEntity.SelectedValue.ToString) & "' "
            End If

            If Not (cboLocation.SelectedIndex = -1 Or cboLocation.Text.Trim = "") Then
                lsCond &= " and a.loc_code = '" & QuoteFilter(cboLocation.SelectedValue.ToString) & "' "
            End If

            If Not (cboProduct.SelectedIndex = -1 Or cboProduct.Text.Trim = "") Then
                lsCond &= " and a.prod_flag = '" & QuoteFilter(cboProduct.SelectedValue.ToString) & "' "
            End If

            If txtContractNo.Text <> "" Then lsCond &= " and a.contract_no = '" & QuoteFilter(txtContractNo.Text) & "' "
            If txtPayeeName.Text <> "" Then lsCond &= " and a.payee_name = " & Val(txtPayeeName.Text) & " "
            If txtChqNo.Text <> "" Then lsCond &= " and a.chq_no like'" & QuoteFilter(txtChqNo.Text) & "%' "
            If txtChqAmt.Text <> "" Then lsCond &= " and a.chq_amount = " & Val(txtChqAmt.Text) & " "
            If txtBankName.Text <> "" Then lsCond &= " and a.bank_name = " & Val(txtBankName.Text) & " "
            If txtBranch.Text <> "" Then lsCond &= " and a.bank_branch = " & Val(txtBranch.Text) & " "
            If txtShelfNo.Text <> "" Then lsCond &= " and a.shelf_no = " & Val(txtShelfNo.Text) & " "
            If txtChqId.Text <> "" Then lsCond &= " and a.chq_gid = " & Val(txtChqId.Text) & " "
            If txtBoxNo.Text <> "" Then lsCond &= " and a.box_no = " & Val(txtBoxNo.Text) & " "
            If txtAccountNo.Text <> "" Then lsCond &= " and a.chq_acc_no = " & Val(txtAccountNo.Text) & " "
            If txtPacketNo.Text <> "" Then lsCond &= " and a.packet_no = " & Val(txtPacketNo.Text) & " "
            If txtBatchId.Text <> "" Then lsCond &= "and a.batch_gid=" & Val(txtBatchId.Text) & ""
            If txtRemark.Text <> "" Then lsCond &= "and a.chq_remark" & Val(txtRemark.Text) & ""

            Select Case cboStatus.Text
                Case "Available"
                    lsCond &= " and a.available_flag = 1 "
                Case "Not Available"
                    lsCond &= " and a.available_flag = 0 "
                Case "Pullout"
                    lsCond &= " and a.chq_status & " & gnStatusPullout & " > 0 "
                    lsCond &= " and a.available_flag = 0 "
                Case "Presentation"
                    lsCond &= " and a.chq_status & " & gnStatusRplob & " > 0 "
                    lsCond &= " and a.available_flag = 0 "
                Case "Aplob Input"
                    lsCond &= " and a.chq_status & " & gnStatusAplobInput & " > 0 "
                    lsCond &= " and a.available_flag = 0 "
                Case "Presentation Batch"
                    lsCond &= " and a.chq_status & " & gnStatusBatch & " > 0 "
                    lsCond &= " and a.available_flag = 0 "
                Case "Batch Entry"
                    lsCond &= " and a.chq_status & " & gnStatusRplob & " > 0 "
                    lsCond &= " and f.chq_gid > 0 "
                Case "Batch Entry Not Done"
                    lsCond &= " and a.chq_status & " & gnStatusRplob & " > 0 "
                    lsCond &= " and f.chq_gid is null "
                    lsCond &= " and a.available_flag = 1 "
            End Select

            If lsCond = "" Then lsCond = " and 1 = 2 "

            lsFld = ""
            If cboFormat.Text = "Daimler" Then
                If txtBatchId.Text = "" Then
                    MessageBox.Show("Please input batch id !", gsProjectName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                gsQry = ""
                gsQry &= " select "
                gsQry &= " cast(a.batch_gid as nchar) as 'DEP. NO',"
                gsQry &= " b.entity_code as 'Client Code',"
                gsQry &= " a.loc_code as 'Pickup Point',"
                gsQry &= " '' as 'Reference No (Optional)',"
                gsQry &= " date_format(a.cycle_date,'%d-%m-%Y') as 'Deposit Date',"
                gsQry &= " cast(a.tot_amount as nchar) as 'Deposit Amount',"
                gsQry &= " cast(a.tot_count as nchar) as 'Count of Chqs',"
                gsQry &= " '' as 'Chq no',"
                gsQry &= " '' as 'Chq Date',"
                gsQry &= " '' as 'Dealer Code',"
                gsQry &= " '' as 'Dwe Bank code (data base to be available)',"
                gsQry &= " '' as 'Dwe Bank loc code (data base to be available)',"
                gsQry &= " '' as 'Chq Amount',"
                gsQry &= " '' as 'Invoice No (optional)',"
                gsQry &= " '' as 'Misc 1 (optional)',"
                gsQry &= " '' as 'Misc 2 (optional)' "
                gsQry &= " from arms_trn_tbatch as a "
                gsQry &= " inner join arms_mst_tentity as b on a.entity_gid = b.entity_gid and b.delete_flag = 'N' "
                gsQry &= " where a.batch_gid = " & Val(txtBatchId.Text) & " "
                gsQry &= " and a.delete_flag = 'N' "
                gsQry &= " union all "
                gsQry &= " select a.* from ("
                gsQry &= " select "
                gsQry &= " '' as 'DEP. NO',"
                gsQry &= " '' as 'Client Code',"
                gsQry &= " '' as 'Pickup Point',"
                gsQry &= " '' as 'Reference No (Optional)',"
                gsQry &= " '' as 'Deposit Date',"
                gsQry &= " '' as 'Deposit Amount',"
                gsQry &= " '' as 'Count of Chqs',"
                gsQry &= " a.chq_no as 'Chq no',"
                gsQry &= " date_format(a.chq_date,'%d-%m-%Y') as 'Chq Date',"
                gsQry &= " a.payee_name as 'Dealer Code',"
                gsQry &= " mid(a.micr_code,4,3) as 'Dwe Bank code (data base to be available)',"
                gsQry &= " mid(a.micr_code,1,3) as 'Dwe Bank loc code (data base to be available)',"
                gsQry &= " cast(a.chq_amount as nchar) as 'Chq Amount',"
                gsQry &= " a.contract_no as 'Invoice No (optional)',"
                gsQry &= " '' as 'Misc 1 (optional)',"
                gsQry &= " '' as 'Misc 2 (optional)' "
                gsQry &= " from arms_trn_tcheque as a"
                gsQry &= " left join arms_trn_tfile as b on b.file_gid=a.file_gid and b.delete_flag = 'N'"
                gsQry &= " left join arms_mst_tentity as c on c.entity_gid=a.entity_gid and c.delete_flag = 'N'"
                gsQry &= " left join arms_mst_tlocation as d on d.loc_code = a.loc_code and d.delete_flag = 'N' "
                gsQry &= " left join arms_mst_tproduct as e on e.prod_flag = a.prod_flag and e.delete_flag = 'N' "
                gsQry &= " left join arms_trn_tbatchentry as f on f.chq_gid = a.chq_gid and f.delete_flag = 'N' "
                gsQry &= " left join arms_trn_tbatchcheque as g on g.chq_gid = a.chq_gid and g.delete_flag = 'N' "
                gsQry &= " where true "
                gsQry &= lsCond
                gsQry &= " and a.delete_flag='N' "
                gsQry &= " order by g.batchchq_gid asc) as a "
            Else
                If cboFormat.Text = "Final" Then
                    lsFld &= " h.lot_no as 'Lot No',"
                    lsFld &= "c.entity_code as 'ClientCode',"
                    lsFld &= "'CITIOPS' as 'DealerCode',"
                    lsFld &= "a.box_no as 'BoxNo',"
                    lsFld &= "'SPDC' as 'ChequeType',"
                    lsFld &= "a.contract_no as 'ContractNo',"
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
                    'lsFld &= "h.packet_no as 'CoverNO',"
                    lsFld &= "h.cover_no as 'CoverNO',"
                    lsFld &= "a.chq_amount as 'BreakupAmount',"
                    lsFld &= "a.payee_name as 'Remark1_CustomerName',"
                    lsFld &= "d.loc_name as 'Remark2',"
                    lsFld &= "a.chq_acc_no as 'Remark3',"
                    lsFld &= "a.contract_no as 'Remark4',"
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
                    'lsFld &= "(select group_concat(disc_desc) from arms_mst_tdisc where a.chq_disc = disc_flag and disc_type='chq' and delete_flag='N') as 'Chq Disc Status', "
                    lsFld &= "make_set(a.chq_disc," & gsChqDiscStatus & ") as 'Chq Disc Status',"
                    lsFld &= "a.chq_remark as 'Chq Disc Status',"
                    lsFld &= "e.prod_code as 'Product',"
                    lsFld &= "a.bank_name as 'Bank Name',"
                    lsFld &= "a.batch_gid as 'Batch Id',"
                    lsFld &= "g.batchchq_gid as 'Batch Chq Id',"
                    lsFld &= "a.chq_gid as 'Cheque Id'"
                Else
                    lsFld &= "h.packet_no as 'Packet Ref No',c.entity_name as 'Entity Name',a.box_no as 'Box No',a.contract_no as 'Contract No',a.chq_amount as 'Cheque Amount',a.chq_acc_no as 'A/C No',"
                    lsFld &= "a.chq_no as 'Cheque No',a.cycle_date as 'Cycle Date',a.chq_date as 'Cheque Date',a.payee_name as 'Payee Name',"
                    lsFld &= "a.bank_name as 'Bank Name',a.bank_branch as 'Bank Branch',a.chq_gid as 'Cheque Id',"
                    lsFld &= "a.cuboard_no as 'Cuboard No',a.shelf_no as 'Shelf No',a.packet_no as 'Packet No',a.batch_gid as 'Batch Id',"
                    lsFld &= "a.micr_code as 'Micr Code',a.available_flag as 'Avail Flag',"
                    lsFld &= "a.chq_status as 'Chq Status Value',make_set(a.chq_status," & gsChqStatus & ") as 'Chq Status',"
                    lsFld &= "a.chq_disc as 'Chq Disc',(select group_concat(disc_desc) from arms_mst_tdisc where disc_flag & a.chq_disc = disc_flag and disc_type='chq' and delete_flag='N') as 'Chq Disc Status',"
                    lsFld &= "a.cts_flag as 'CTS Flag',a.chq_remark as 'Chq Remark',"
                    lsFld &= "f.batchentry_gid as 'Batch Entry Id',f.system_ip as 'System Ip',f.insert_by as 'Batch Entry By',"
                    lsFld &= "b.file_name as 'File Name',"
                    lsFld &= "b.import_date as 'Import Date',a.loc_code as 'Location Code',a.prod_flag as 'Prod Flag',a.aplobinput_gid as 'API ID',a.rplob_gid as 'Presentation ID',a.batch_gid as 'Batch ID',a.update_date as 'Update Date',a.update_by as 'Update By'"
                End If

                gsQry = ""
                gsQry &= " select " & lsFld
                gsQry &= " from arms_trn_tcheque as a"
                gsQry &= " left join arms_trn_tpacket as h on a.packet_gid=h.packet_gid and h.delete_flag='N'"
                gsQry &= " left join arms_trn_tfile as b on b.file_gid=a.file_gid and b.delete_flag = 'N'"
                gsQry &= " left join arms_mst_tentity as c on c.entity_gid=a.entity_gid and c.delete_flag = 'N'"
                gsQry &= " left join arms_mst_tlocation as d on d.loc_code = a.loc_code and d.delete_flag = 'N' "
                gsQry &= " left join arms_mst_tproduct as e on e.prod_flag = a.prod_flag and e.delete_flag = 'N' "
                gsQry &= " left join arms_trn_tbatchentry as f on f.chq_gid = a.chq_gid and f.delete_flag = 'N' "

                If cboFormat.Text = "Final" Then
                    gsQry &= " left join arms_trn_tbatchcheque as g on g.chq_gid = a.chq_gid and g.delete_flag = 'N' "
                End If

                gsQry &= " where true "
                gsQry &= lsCond
                gsQry &= " and a.delete_flag='N' "

                If cboFormat.Text = "Final" Then
                    gsQry &= " order by h.lot_no,h.cover_no,a.chq_gid, g.batchchq_gid asc "


                End If
            End If

            frmMain.lblStatus.Text = "Start time : " & Now().ToString

            If RunFlag = True Then
                Call PrintDataTable(gsQry, gsReportPath & "Report.xls", True)
            Else
                Call gpPopGridView(dgvReport, gsQry, gOdbcConn)

                For i = 0 To dgvReport.Columns.Count - 1
                    dgvReport.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
                Next i

                dgvReport.AutoResizeColumns()

                lblRecCount.Text = "Record Count: " & dgvReport.RowCount
            End If

            frmMain.lblStatus.Text &= " - End time : " & Now().ToString
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, gsProjectName)
        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Call ClearAll()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        MyBase.Close()
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Try
            If dgvReport.RowCount = 0 Then
                MsgBox("No Details to Export!", MsgBoxStyle.Critical, gsProjectName)
                Exit Sub
            End If

            PrintDGViewXML(dgvReport, gsReportPath & "Cheque.xls", "Cheque Report", "", True, True)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub frmChequeReport_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            gsQry = " select CONCAT(entity_code,'-', entity_name) as EntityCode ,entity_gid from arms_mst_tentity"
            gsQry &= " where delete_flag='N' "
            gsQry &= " order by entity_name "
            Call gpBindCombo(gsQry, "EntityCode", "entity_gid", cboEntity, gOdbcConn)

            cboStatus.Items.Add("Available")
            cboStatus.Items.Add("Not Available")
            cboStatus.Items.Add("Pullout")
            cboStatus.Items.Add("Presentation")
            cboStatus.Items.Add("Aplob Input")
            cboStatus.Items.Add("Batch Entry")
            cboStatus.Items.Add("Batch Entry Not Done")
            cboStatus.Items.Add("Presentation Batch")

            gsQry = " select prod_desc ,prod_flag from arms_mst_tproduct"
            gsQry &= " where delete_flag='N' "
            gsQry &= " order by prod_desc "
            Call gpBindCombo(gsQry, "prod_desc", "prod_flag", cboProduct, gOdbcConn)

            gsQry = " select loc_name ,loc_code from arms_mst_tlocation"
            gsQry &= " where delete_flag='N' "
            gsQry &= " order by loc_name "
            Call gpBindCombo(gsQry, "loc_name", "loc_code", cboLocation, gOdbcConn)

            Call ClearAll()

            KeyPreview = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ClearAll()
        cboFileName.Text = ""
        cboEntity.Text = ""
        cboStatus.Text = ""
        txtChqNo.Text = ""
        txtChqAmt.Text = ""
        txtAccountNo.Text = ""
        txtBankName.Text = ""
        txtContractNo.Text = ""
        txtPayeeName.Text = ""
        txtPacketNo.Text = ""
        txtChqId.Text = ""
        txtBoxNo.Text = ""
        txtShelfNo.Text = ""
        txtBranch.Text = ""
        cboProduct.Text = ""
        cboLocation.Text = ""
        txtRemark.Text = ""
        txtBatchId.Text = ""
        dtpCycleFrom.Checked = False
        dtpCycleTo.Checked = False
        dtpImportFrom.Checked = False
        dtpImportTo.Checked = False
        dtpChqForm.Checked = False
        dtpChqTo.Checked = False
        dgvReport.DataSource = Nothing
    End Sub

    Private Sub frmChequeReport_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Try
            With dgvReport
                .Top = pnlButtons.Top + pnlButtons.Height + 5
                .Width = Me.Width - 40
                .Height = Me.Height - pnlButtons.Height - pnlDisplay.Height - 60
                pnlDisplay.Width = .Width
                pnlDisplay.Top = pnlButtons.Top + pnlButtons.Height + dgvReport.Height + 10
                btnExport.Left = pnlDisplay.Width - (btnExport.Width + 10)
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cboFileName_GotFocus(sender As Object, e As EventArgs) Handles cboFileName.GotFocus
        gsQry = ""
        gsQry &= " select file_name ,file_gid from arms_trn_tfile"
        gsQry &= " where 1= 1 "
        gsQry &= " and file_type = " & gnFileAplobInput & " "

        If dtpImportFrom.Checked = True Then gsQry &= " and import_date >= '" & Format(dtpImportFrom.Value, "yyyy-MM-dd") & "' "
        If dtpImportTo.Checked = True Then gsQry &= " and import_date < '" & Format(DateAdd(DateInterval.Day, 1, dtpImportTo.Value), "yyyy-MM-dd") & "' "

        gsQry &= " and delete_flag='N' "
        gsQry &= " order by file_gid desc "

        Call gpBindCombo(gsQry, "file_name", "file_gid", cboFileName, gOdbcConn)
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        If ChkChqNoQry.Checked = False And chkContractNo.Checked = False And chkChqAmt.Checked = False Then
            Call LoadData()
        Else
            Call LoadChqNoQryData()
        End If
    End Sub

    Private Sub btnRun_Click(sender As Object, e As EventArgs) Handles btnRun.Click
        If ChkChqNoQry.Checked = False And chkContractNo.Checked = False And chkChqAmt.Checked = False Then
            Call LoadData()
        Else
            Call LoadChqNoQryData()
        End If
    End Sub

    Private Sub LoadChqNoQryData(Optional ByVal RunFlag As Boolean = False)
        Dim i As Integer
        Dim lsFld As String

        lsCond = ""

        Try
            If dtpImportFrom.Checked = True Then lsCond &= " and b.import_date >='" & Format(dtpImportFrom.Value, "yyyy-MM-dd") & "' "
            If dtpImportTo.Checked = True Then lsCond &= " and b.import_date < '" & Format(DateAdd(DateInterval.Day, 1, dtpImportTo.Value), "yyyy-MM-dd") & "' "

            If dtpCycleFrom.Checked = True Then lsCond &= " and a.cycle_date >='" & Format(dtpCycleFrom.Value, "yyyy-MM-dd") & "' "
            If dtpCycleTo.Checked = True Then lsCond &= " and a.cycle_date < '" & Format(DateAdd(DateInterval.Day, 1, dtpCycleTo.Value), "yyyy-MM-dd") & "' "

            If dtpChqForm.Checked = True Then lsCond &= " and a.chq_date >='" & Format(dtpChqForm.Value, "yyyy-MM-dd") & "' "
            If dtpChqTo.Checked = True Then lsCond &= " and a.chq_date < '" & Format(DateAdd(DateInterval.Day, 1, dtpChqTo.Value), "yyyy-MM-dd") & "' "

            If Not (cboFileName.SelectedIndex = -1 Or cboFileName.Text = "") Then
                lsCond &= " and b.file_gid ='" & Val(cboFileName.SelectedValue.ToString) & "' "
            End If

            If Not (cboEntity.SelectedIndex = -1 Or cboEntity.Text.Trim = "") Then
                lsCond &= " and a.entity_gid = '" & QuoteFilter(cboEntity.SelectedValue.ToString) & "' "
            End If

            If Not (cboLocation.SelectedIndex = -1 Or cboLocation.Text.Trim = "") Then
                lsCond &= " and a.loc_code = '" & QuoteFilter(cboLocation.SelectedValue.ToString) & "' "
            End If

            If Not (cboProduct.SelectedIndex = -1 Or cboProduct.Text.Trim = "") Then
                lsCond &= " and a.prod_flag = '" & QuoteFilter(cboProduct.SelectedValue.ToString) & "' "
            End If

            If txtContractNo.Text <> "" Then lsCond &= " and a.contract_no = '" & QuoteFilter(txtContractNo.Text) & "' "
            If txtPayeeName.Text <> "" Then lsCond &= " and a.payee_name = " & Val(txtPayeeName.Text) & " "
            If txtChqNo.Text <> "" Then lsCond &= " and a.chq_no like'" & QuoteFilter(txtChqNo.Text) & "%' "
            If txtChqAmt.Text <> "" Then lsCond &= " and a.chq_amount = " & Val(txtChqAmt.Text) & " "
            If txtBankName.Text <> "" Then lsCond &= " and a.bank_name = " & Val(txtBankName.Text) & " "
            If txtBranch.Text <> "" Then lsCond &= " and a.bank_branch = " & Val(txtBranch.Text) & " "
            If txtShelfNo.Text <> "" Then lsCond &= " and a.shelf_no = " & Val(txtShelfNo.Text) & " "
            If txtChqId.Text <> "" Then lsCond &= " and a.chq_gid = " & Val(txtChqId.Text) & " "
            If txtBoxNo.Text <> "" Then lsCond &= " and a.box_no = " & Val(txtBoxNo.Text) & " "
            If txtAccountNo.Text <> "" Then lsCond &= " and a.chq_acc_no = " & Val(txtAccountNo.Text) & " "
            If txtPacketNo.Text <> "" Then lsCond &= " and a.packet_no = " & Val(txtPacketNo.Text) & " "
            If txtBatchId.Text <> "" Then lsCond &= "and a.batch_gid=" & Val(txtBatchId.Text) & ""
            If txtRemark.Text <> "" Then lsCond &= "and a.chq_remark" & Val(txtRemark.Text) & ""

            Select Case cboStatus.Text
                Case "Available"
                    lsCond &= " and a.available_flag = 1 "
                Case "Not Available"
                    lsCond &= " and a.available_flag = 0 "
                Case "Pullout"
                    lsCond &= " and a.chq_status & " & gnStatusPullout & " > 0 "
                    lsCond &= " and a.available_flag = 0 "
                Case "Presentation"
                    lsCond &= " and a.chq_status & " & gnStatusRplob & " > 0 "
                    lsCond &= " and a.available_flag = 0 "
                Case "Aplob Input"
                    lsCond &= " and a.chq_status & " & gnStatusAplobInput & " > 0 "
                    lsCond &= " and a.available_flag = 0 "
                Case "Presentation Batch"
                    lsCond &= " and a.chq_status & " & gnStatusBatch & " > 0 "
                    lsCond &= " and a.available_flag = 0 "
                Case "Batch Entry"
                    lsCond &= " and a.chq_status & " & gnStatusRplob & " > 0 "
                    lsCond &= " and f.chq_gid > 0 "
                Case "Batch Entry Not Done"
                    lsCond &= " and a.chq_status & " & gnStatusRplob & " > 0 "
                    lsCond &= " and f.chq_gid is null "
                    lsCond &= " and a.available_flag = 1 "
            End Select

            If lsCond = "" Then lsCond = ""

            lsFld = ""
            If cboFormat.Text = "Daimler" Then
                If txtBatchId.Text = "" Then
                    MessageBox.Show("Please input batch id !", gsProjectName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                gsQry = ""
                gsQry &= " select "
                gsQry &= " cast(a.batch_gid as nchar) as 'DEP. NO',"
                gsQry &= " b.entity_code as 'Client Code',"
                gsQry &= " a.loc_code as 'Pickup Point',"
                gsQry &= " '' as 'Reference No (Optional)',"
                gsQry &= " date_format(a.cycle_date,'%d-%m-%Y') as 'Deposit Date',"
                gsQry &= " cast(a.tot_amount as nchar) as 'Deposit Amount',"
                gsQry &= " cast(a.tot_count as nchar) as 'Count of Chqs',"
                gsQry &= " '' as 'Chq no',"
                gsQry &= " '' as 'Chq Date',"
                gsQry &= " '' as 'Dealer Code',"
                gsQry &= " '' as 'Dwe Bank code (data base to be available)',"
                gsQry &= " '' as 'Dwe Bank loc code (data base to be available)',"
                gsQry &= " '' as 'Chq Amount',"
                gsQry &= " '' as 'Invoice No (optional)',"
                gsQry &= " '' as 'Misc 1 (optional)',"
                gsQry &= " '' as 'Misc 2 (optional)' "
                gsQry &= " from arms_trn_tbatch as a "
                gsQry &= " inner join arms_mst_tentity as b on a.entity_gid = b.entity_gid and b.delete_flag = 'N' "
                gsQry &= " where a.batch_gid = " & Val(txtBatchId.Text) & " "
                gsQry &= " and a.delete_flag = 'N' "
                gsQry &= " union all "
                gsQry &= " select a.* from ("
                gsQry &= " select "
                gsQry &= " '' as 'DEP. NO',"
                gsQry &= " '' as 'Client Code',"
                gsQry &= " '' as 'Pickup Point',"
                gsQry &= " '' as 'Reference No (Optional)',"
                gsQry &= " '' as 'Deposit Date',"
                gsQry &= " '' as 'Deposit Amount',"
                gsQry &= " '' as 'Count of Chqs',"
                gsQry &= " a.chq_no as 'Chq no',"
                gsQry &= " date_format(a.chq_date,'%d-%m-%Y') as 'Chq Date',"
                gsQry &= " a.payee_name as 'Dealer Code',"
                gsQry &= " mid(a.micr_code,4,3) as 'Dwe Bank code (data base to be available)',"
                gsQry &= " mid(a.micr_code,1,3) as 'Dwe Bank loc code (data base to be available)',"
                gsQry &= " cast(a.chq_amount as nchar) as 'Chq Amount',"
                gsQry &= " a.contract_no as 'Invoice No (optional)',"
                gsQry &= " '' as 'Misc 1 (optional)',"
                gsQry &= " '' as 'Misc 2 (optional)' "
                gsQry &= " from arms_trn_tcheque as a"
                gsQry &= " left join arms_trn_tfile as b on b.file_gid=a.file_gid and b.delete_flag = 'N'"
                gsQry &= " left join arms_mst_tentity as c on c.entity_gid=a.entity_gid and c.delete_flag = 'N'"
                gsQry &= " left join arms_mst_tlocation as d on d.loc_code = a.loc_code and d.delete_flag = 'N' "
                gsQry &= " left join arms_mst_tproduct as e on e.prod_flag = a.prod_flag and e.delete_flag = 'N' "
                gsQry &= " left join arms_trn_tbatchentry as f on f.chq_gid = a.chq_gid and f.delete_flag = 'N' "
                gsQry &= " left join arms_trn_tbatchcheque as g on g.chq_gid = a.chq_gid and g.delete_flag = 'N' "

                gsQry &= " inner join arms_trn_tchequeno_qry as i on i.entity_gid=a.entity_gid "

                If ChkChqNoQry.Checked Then
                    gsQry &= " and i.chq_no=a.chq_no and i.chq_no <> '' "
                End If

                If chkContractNo.Checked Then
                    gsQry &= " and i.contract_no=a.contract_no and i.contract_no <> '' "
                End If

                If chkChqAmt.Checked Then
                    gsQry &= " and i.chq_amount=a.chq_amount and i.chq_amount > 0 "
                End If

                gsQry &= " and i.insert_by='" & gsLoginUserCode & "' and i.delete_flag='N' "

                'gsQry &= " inner join arms_trn_tchequeno_qry as h on h.chq_no=a.chq_no and h.entity_gid=a.entity_gid"
                'gsQry &= " and a.contract_no= h.contract_no and a.chq_amount=h.chq_amount and h.insert_by='" & gsLoginUserCode & "' and h.delete_flag='N'"

                gsQry &= " left join arms_trn_tpullout as i on a.chq_gid=i.chq_gid and i.delete_flag='N'"
                gsQry &= " where true "
                gsQry &= lsCond
                gsQry &= " and a.delete_flag='N' "
                gsQry &= " order by g.batchchq_gid asc) as a "
            Else
                If cboFormat.Text = "Final" Then
                    lsFld &= " h.lot_no as 'Lot No',"
                    lsFld &= "c.entity_code as 'ClientCode',"
                    lsFld &= "'CITIOPS' as 'DealerCode',"
                    lsFld &= "a.box_no as 'BoxNo',"
                    lsFld &= "'PDC' as 'ChequeType',"
                    lsFld &= "a.contract_no as 'ContractNo',"
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
                    lsFld &= "a.contract_no as 'Remark4',"
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
                    'lsFld &= "(select group_concat(disc_desc) from arms_mst_tdisc where a.chq_disc = disc_flag and disc_type='chq' and delete_flag='N') as 'Chq Disc Status', "
                    lsFld &= "make_set(a.chq_disc," & gsChqDiscStatus & ") as 'Chq Disc Status',"
                    lsFld &= "a.chq_remark as 'Chq Disc Status',"
                    lsFld &= "e.prod_code as 'Product',"
                    lsFld &= "a.bank_name as 'Bank Name',"
                    lsFld &= "a.batch_gid as 'Batch Id',"
                    lsFld &= "g.batchchq_gid as 'Batch Chq Id',"
                    lsFld &= "a.chq_gid as 'Cheque Id'"
                Else
                    lsFld &= "h.packet_no as 'Packet Ref No',c.entity_name as 'Entity Name',a.box_no as 'Box No',a.contract_no as 'Contract No',a.chq_amount as 'Cheque Amount',a.chq_acc_no as 'A/C No',"
                    lsFld &= "a.chq_no as 'Cheque No',a.cycle_date as 'Cycle Date',a.chq_date as 'Cheque Date',a.payee_name as 'Payee Name',"
                    lsFld &= "a.bank_name as 'Bank Name',a.bank_branch as 'Bank Branch',a.chq_gid as 'Cheque Id',"
                    lsFld &= "a.cuboard_no as 'Cuboard No',a.shelf_no as 'Shelf No',a.packet_no as 'Packet No',a.batch_gid as 'Batch Id',"
                    lsFld &= "a.micr_code as 'Micr Code',a.available_flag as 'Avail Flag',"
                    lsFld &= "a.chq_status as 'Chq Status Value',make_set(a.chq_status," & gsChqStatus & ") as 'Chq Status',"
                    lsFld &= "j.pullout_reason as 'Pullout Reason',"
                    lsFld &= "a.chq_disc as 'Chq Disc',(select group_concat(disc_desc) from arms_mst_tdisc where disc_flag & a.chq_disc = disc_flag and disc_type='chq' and delete_flag='N') as 'Chq Disc Status',"
                    lsFld &= "a.cts_flag as 'CTS Flag',a.chq_remark as 'Chq Remark',"
                    lsFld &= "f.batchentry_gid as 'Batch Entry Id',f.system_ip as 'System Ip',f.insert_by as 'Batch Entry By',"
                    lsFld &= " date_format(k.dispatch_date,'%d-%m-%Y') as 'Dispatch Date',k.awb_no as 'Awb No',k.dispatch_addr as 'Dispatch Addr',k.dispatch_by as 'Dispatch By',"
                    lsFld &= "b.file_name as 'File Name',"
                    lsFld &= "b.import_date as 'Import Date',a.loc_code as 'Location Code',a.prod_flag as 'Prod Flag',a.aplobinput_gid as 'API ID',a.rplob_gid as 'Presentation ID',a.batch_gid as 'Batch ID',j.dispatch_gid as 'Dispatch Id',a.update_date as 'Update Date',a.update_by as 'Update By'"
                End If

                gsQry = ""
                gsQry &= " select " & lsFld
                gsQry &= " from arms_trn_tcheque as a"
                gsQry &= " left join arms_trn_tpacket as h on a.packet_gid=h.packet_gid and h.delete_flag='N'"
                gsQry &= " left join arms_trn_tfile as b on b.file_gid=a.file_gid and b.delete_flag = 'N'"
                gsQry &= " left join arms_mst_tentity as c on c.entity_gid=a.entity_gid and c.delete_flag = 'N'"
                gsQry &= " left join arms_mst_tlocation as d on d.loc_code = a.loc_code and d.delete_flag = 'N' "
                gsQry &= " left join arms_mst_tproduct as e on e.prod_flag = a.prod_flag and e.delete_flag = 'N' "
                gsQry &= " left join arms_trn_tbatchentry as f on f.chq_gid = a.chq_gid and f.delete_flag = 'N' "
                gsQry &= " inner join arms_trn_tchequeno_qry as i on i.entity_gid=a.entity_gid "

                If ChkChqNoQry.Checked Then
                    gsQry &= " and i.chq_no=a.chq_no and i.chq_no <> '' "
                End If

                If chkContractNo.Checked Then
                    gsQry &= " and i.contract_no=a.contract_no and i.contract_no <> '' "
                End If

                If chkChqAmt.Checked Then
                    gsQry &= " and i.chq_amount=a.chq_amount and i.chq_amount > 0 "
                End If

                gsQry &= " and i.insert_by='" & gsLoginUserCode & "' and i.delete_flag='N' "

                gsQry &= " left join arms_trn_tpullout as j on a.chq_gid=j.chq_gid and j.delete_flag='N'"
                gsQry &= " left join arms_trn_tdispatch as k on j.entity_gid=k.entity_gid and j.dispatch_gid=k.dispatch_gid and k.delete_flag='N'"

                If cboFormat.Text = "Final" Then
                    gsQry &= " left join arms_trn_tbatchcheque as g on g.chq_gid = a.chq_gid and g.delete_flag = 'N' "
                End If

                gsQry &= " where true "
                gsQry &= lsCond
                gsQry &= " and a.delete_flag='N' "

                If cboFormat.Text = "Final" Then
                    gsQry &= " order by h.lot_no,h.cover_no,a.chq_gid, g.batchchq_gid asc "
                End If
            End If

            frmMain.lblStatus.Text = "Start time : " & Now().ToString

            If RunFlag = True Then
                Call PrintDataTable(gsQry, gsReportPath & "Report.xls", True)
            Else
                Call gpPopGridView(dgvReport, gsQry, gOdbcConn)

                For i = 0 To dgvReport.Columns.Count - 1
                    dgvReport.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
                Next i

                dgvReport.AutoResizeColumns()

                lblRecCount.Text = "Record Count: " & dgvReport.RowCount
            End If

            frmMain.lblStatus.Text &= " - End time : " & Now().ToString
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, gsProjectName)
        End Try
    End Sub
End Class