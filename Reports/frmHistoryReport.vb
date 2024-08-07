Public Class frmHistoryReport

    Dim lsCond As String = ""
    Private Sub frmHistoryReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            gsQry = " select CONCAT(entity_code,'-', entity_name) as EntityCode ,entity_gid from arms_mst_tentity"
            gsQry &= " where delete_flag='N' "
            gsQry &= " order by entity_name "
            Call gpBindCombo(gsQry, "EntityCode", "entity_gid", cboEntity, gOdbcConn)

            gsQry = " select prod_desc ,prod_flag from arms_mst_tproduct"
            gsQry &= " where delete_flag='N' "
            gsQry &= " order by prod_desc "
            Call gpBindCombo(gsQry, "prod_desc", "prod_flag", cboProduct, gOdbcConn)

            Call ClearAll()

            KeyPreview = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub ClearAll()
        cboFileName.Text = ""
        cboEntity.Text = ""
        txtStatus.Text = ""
        txtChqNo.Text = ""
        txtChqAmt.Text = ""
        txtAccountNo.Text = ""
        txtContractNo.Text = ""
        'txtPayeeName.Text = ""
        txtBoxNo.Text = ""
        txtShelfNo.Text = ""
        cboProduct.Text = ""
        txtMicrCode.Text = ""
        dtpCycleFrom.Checked = False
        dtpCycleTo.Checked = False
        dtpChqForm.Checked = False
        dtpChqTo.Checked = False
        dgvReport.DataSource = Nothing
    End Sub

    Private Sub frmHistoryReport_Resize(sender As Object, e As EventArgs) Handles Me.Resize
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

    Private Sub cboFileName_GotFocus(sender As Object, e As EventArgs)
        gsQry = ""
        gsQry &= " select file_name ,file_gid from arms_trn_tfile"
        gsQry &= " where 1= 1 "
        gsQry &= " and file_type = " & gnFileHistoryUpload & " "

        If dtpCycleFrom.Checked = True Then gsQry &= " and import_date >= '" & Format(dtpCycleFrom.Value, "yyyy-MM-dd") & "' "
        If dtpCycleTo.Checked = True Then gsQry &= " and import_date < '" & Format(DateAdd(DateInterval.Day, 1, dtpCycleTo.Value), "yyyy-MM-dd") & "' "

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
    Private Sub LoadData(Optional RunFlag As Boolean = False)

        Dim i As Integer

        lsCond = ""

        Try
            If dtpCycleFrom.Checked = True Then lsCond &= " and a.chq_date >='" & Format(dtpCycleFrom.Value, "yyyy-MM-dd") & "' "
            If dtpCycleTo.Checked = True Then lsCond &= " and a.chq_date <='" & Format(dtpCycleTo.Value, "yyyy-MM-dd") & "' "

            If dtpChqForm.Checked = True Then lsCond &= " and a.chq_date >='" & Format(dtpChqForm.Value, "yyyy-MM-dd") & "' "
            If dtpChqTo.Checked = True Then lsCond &= " and a.chq_date <='" & Format(dtpChqTo.Value, "yyyy-MM-dd") & "' "

            If Not (cboFileName.SelectedIndex = -1 Or cboFileName.Text = "") Then
                lsCond &= " and b.file_gid ='" & Val(cboFileName.SelectedValue.ToString) & "' "
            End If

            If Not (cboEntity.SelectedIndex = -1 Or cboEntity.Text.Trim = "") Then
                lsCond &= " and a.entity_gid = '" & QuoteFilter(cboEntity.SelectedValue.ToString) & "' "
            End If

            If txtContractNo.Text <> "" Then lsCond &= " and a.contract_no = '" & QuoteFilter(txtContractNo.Text) & "' "
            'If txtPayeeName.Text <> "" Then lsCond &= " and a.payee_name = '" & QuoteFilter(txtPayeeName.Text) & "' "
            If txtChqNo.Text <> "" Then lsCond &= " and a.chq_no = '" & QuoteFilter(txtChqNo.Text) & "' "
            If txtChqAmt.Text <> "" Then lsCond &= " and a.chq_amount = '" & QuoteFilter(txtChqAmt.Text) & "' "
            If txtMicrCode.Text <> "" Then lsCond &= " and a.sort_key = '" & QuoteFilter(txtMicrCode.Text) & "' "
            If txtAccountNo.Text <> "" Then lsCond &= " and a.sort_key = '" & QuoteFilter(txtAccountNo.Text) & "' "
            If cboProduct.Text <> "" Then lsCond &= " and a.chq_prod = '" & QuoteFilter(cboProduct.Text) & "' "
            If txtShelfNo.Text <> "" Then lsCond &= " and a.shelf_no = '" & QuoteFilter(txtShelfNo.Text) & "' "
            If txtBoxNo.Text <> "" Then lsCond &= " and a.box_no = '" & QuoteFilter(txtBoxNo.Text) & "' "
            If txtStatus.Text <> "" Then lsCond &= " and a.chq_status like '%" & QuoteFilter(txtStatus.Text) & "%' "

            gsQry = ""
            gsQry &= " select "
            gsQry &= " c.entity_name as 'Company',"
            gsQry &= " a.contract_no as 'Contract No',"
            gsQry &= " date_format(a.chq_date,'%d-%m-%Y')  as 'Cheque Date',"
            gsQry &= " a.payee_name as 'Customer Name',"
            gsQry &= " a.chq_no as 'Cheque No',"
            gsQry &= " a.chq_amount as 'Cheque Amount',"
            gsQry &= " a.chq_acc_no as 'Account No',"
            gsQry &= " a.sort_key as 'Micr Code',"
            gsQry &= " a.chq_type as 'Cheque Type',"
            gsQry &= " a.cover_no as 'Cover No',"
            gsQry &= " a.Pay_location as 'Location',"
            gsQry &= " a.box_no as 'Box No',"
            gsQry &= " a.cuboard_no as 'Cuboard No',"
            gsQry &= " a.shelf_no as 'Shelf No',"
            gsQry &= " a.chq_status as 'Status',"
            gsQry &= " a.chq_prod as 'Product'"

            gsQry &= " from arms_trn_thistory as a"
            gsQry &= " left join arms_trn_tfile as b on b.file_gid=a.file_gid and b.delete_flag = 'N'"
            gsQry &= " left join arms_mst_tentity as c on c.entity_gid=a.entity_gid and c.delete_flag = 'N'"
            gsQry &= " where true "
            gsQry &= lsCond
            gsQry &= " and a.delete_flag='N' order by history_gid asc"

            Call gpPopGridView(dgvReport, gsQry, gOdbcConn)

            For i = 0 To dgvReport.Columns.Count - 1
                dgvReport.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next i

            dgvReport.AutoResizeColumns()

            lblRecCount.Text = "Record Count: " & dgvReport.RowCount
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, gsProjectName)
        End Try

    End Sub

    Private Sub LoadChqNoQryData(Optional RunFlag As Boolean = False)

        Dim i As Integer

        lsCond = ""

        Try
            If dtpCycleFrom.Checked = True Then lsCond &= " and a.chq_date >='" & Format(dtpCycleFrom.Value, "yyyy-MM-dd") & "' "
            If dtpCycleTo.Checked = True Then lsCond &= " and a.chq_date <='" & Format(dtpCycleTo.Value, "yyyy-MM-dd") & "' "

            If dtpChqForm.Checked = True Then lsCond &= " and a.chq_date >='" & Format(dtpChqForm.Value, "yyyy-MM-dd") & "' "
            If dtpChqTo.Checked = True Then lsCond &= " and a.chq_date <='" & Format(dtpChqTo.Value, "yyyy-MM-dd") & "' "

            If Not (cboFileName.SelectedIndex = -1 Or cboFileName.Text = "") Then
                lsCond &= " and b.file_gid ='" & Val(cboFileName.SelectedValue.ToString) & "' "
            End If

            If Not (cboEntity.SelectedIndex = -1 Or cboEntity.Text.Trim = "") Then
                lsCond &= " and a.entity_gid = '" & QuoteFilter(cboEntity.SelectedValue.ToString) & "' "
            End If

            If txtContractNo.Text <> "" Then lsCond &= " and a.contract_no = '" & QuoteFilter(txtContractNo.Text) & "' "
            'If txtPayeeName.Text <> "" Then lsCond &= " and a.payee_name = '" & QuoteFilter(txtPayeeName.Text) & "' "
            If txtChqNo.Text <> "" Then lsCond &= " and a.chq_no = '" & QuoteFilter(txtChqNo.Text) & "' "
            If txtChqAmt.Text <> "" Then lsCond &= " and a.chq_amount = '" & QuoteFilter(txtChqAmt.Text) & "' "
            If txtMicrCode.Text <> "" Then lsCond &= " and a.sort_key = '" & QuoteFilter(txtMicrCode.Text) & "' "
            If txtAccountNo.Text <> "" Then lsCond &= " and a.sort_key = '" & QuoteFilter(txtAccountNo.Text) & "' "
            If cboProduct.Text <> "" Then lsCond &= " and a.chq_prod = '" & QuoteFilter(cboProduct.Text) & "' "
            If txtShelfNo.Text <> "" Then lsCond &= " and a.shelf_no = '" & QuoteFilter(txtShelfNo.Text) & "' "
            If txtBoxNo.Text <> "" Then lsCond &= " and a.box_no = '" & QuoteFilter(txtBoxNo.Text) & "' "
            If txtStatus.Text <> "" Then lsCond &= " and a.chq_status like '%" & QuoteFilter(txtStatus.Text) & "%' "

            gsQry = ""
            gsQry &= " select "
            gsQry &= " c.entity_name as 'Company',"
            gsQry &= " a.contract_no as 'Contract No',"
            gsQry &= " date_format(a.chq_date,'%d-%m-%Y')  as 'Cheque Date',"
            gsQry &= " a.payee_name as 'Customer Name',"
            gsQry &= " a.chq_no as 'Cheque No',"
            gsQry &= " a.chq_amount as 'Cheque Amount',"
            gsQry &= " a.chq_acc_no as 'Account No',"
            gsQry &= " a.sort_key as 'Micr Code',"
            gsQry &= " a.chq_type as 'Cheque Type',"
            gsQry &= " a.cover_no as 'Cover No',"
            gsQry &= " a.Pay_location as 'Location',"
            gsQry &= " a.box_no as 'Box No',"
            gsQry &= " a.cuboard_no as 'Cuboard No',"
            gsQry &= " a.shelf_no as 'Shelf No',"
            gsQry &= " a.chq_status as 'Status',"
            gsQry &= " a.chq_prod as 'Product'"

            gsQry &= " from arms_trn_thistory as a"
            gsQry &= " left join arms_trn_tfile as b on b.file_gid=a.file_gid and b.delete_flag = 'N'"
            gsQry &= " left join arms_mst_tentity as c on c.entity_gid=a.entity_gid and c.delete_flag = 'N'"
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

            gsQry &= " where true "
            gsQry &= lsCond
            gsQry &= " and a.delete_flag='N' order by history_gid asc"

            Call gpPopGridView(dgvReport, gsQry, gOdbcConn)

            For i = 0 To dgvReport.Columns.Count - 1
                dgvReport.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next i

            dgvReport.AutoResizeColumns()

            lblRecCount.Text = "Record Count: " & dgvReport.RowCount
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, gsProjectName)
        End Try

    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Try
            If dgvReport.RowCount = 0 Then
                MsgBox("No Details to Export!", MsgBoxStyle.Critical, gsProjectName)
                Exit Sub
            End If

            PrintDGViewXML(dgvReport, gsReportPath & "History.xls", "History Report", "", True, True)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnClear_Click(sender As System.Object, e As System.EventArgs) Handles btnClear.Click
        Call ClearAll()
    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        MyBase.Close()
    End Sub
End Class