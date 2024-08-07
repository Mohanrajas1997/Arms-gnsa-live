Public Class frmAplobInputReport
    Dim lsCond As String = ""
    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Dim i As Integer

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

            If txtContractNo.Text <> "" Then lsCond &= " and a.contract_no = '" & QuoteFilter(txtContractNo.Text) & "' "
            If txtPayeeName.Text <> "" Then lsCond &= " and a.payee_name = " & Val(txtPayeeName.Text) & " "
            If txtChqNo.Text <> "" Then lsCond &= " and a.chq_no like'" & QuoteFilter(txtChqNo.Text) & "%' "
            If txtChqAmt.Text <> "" Then lsCond &= " and a.chq_amount = " & Val(txtChqAmt.Text) & " "
            If txtAccountNo.Text <> "" Then lsCond &= " and a.chq_acc_no = " & Val(txtAccountNo.Text) & " "
            If txtBankName.Text <> "" Then lsCond &= " and a.bank_name = " & Val(txtBankName.Text) & " "
            If txtAPIId.Text <> "" Then lsCond &= " and a.api_gid = " & Val(txtAPIId.Text) & " "
            If txtChqId.Text <> "" Then lsCond &= " and a.chq_gid = " & Val(txtChqId.Text) & " "

            Select Case cboStatus.Text
                Case "Posted"
                    lsCond &= " and a.chq_gid > 0 "
                Case "Not Posted"
                    lsCond &= " and a.chq_gid = 0 "
            End Select

            If lsCond = "" Then lsCond = " and 1 = 2 "

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
            PrintDGViewXML(dgvReport, gsReportPath & "AplobInput.xls", "AplobInput Report")

            MsgBox(" Exported to Excel !!" & Chr(13) & _
                   " Saved Path : " & gsReportPath & "AplobInputReport", MsgBoxStyle.Information, gsProjectName)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub frmAplobInputReport_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try

            'dtpImportFrom.MaxDate = Date.Today()
            'dtpImportTo.MaxDate = Date.Today()

            'dtpChqForm.MaxDate = Date.Today()
            'dtpChqTo.MaxDate = Date.Today()

            'dtpCycleFrom.MaxDate = Date.Today()
            'dtpCycleTo.MaxDate = Date.Today()

            gsQry = " select CONCAT(entity_code,'-', entity_name) as EntityCode ,entity_gid from arms_mst_tentity"
            gsQry &= " where delete_flag='N' "
            gsQry &= " order by entity_name "
            Call gpBindCombo(gsQry, "EntityCode", "entity_gid", cboEntity, gOdbcConn)

            'gsQry = " select status_desc ,status_gid from arms_mst_tstatus"
            'gsQry &= " where delete_flag='N' "
            'gsQry &= " order by status_desc "
            'Call gpBindCombo(gsQry, "status_desc", "status_gid", cboStatus, gOdbcConn)

            cboStatus.Items.Add("Posted")
            cboStatus.Items.Add("Not Posted")

            Call ClearAll()

            KeyPreview = True

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub frmAplobInputReport_Resize(sender As Object, e As EventArgs) Handles Me.Resize
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

    Private Sub ClearAll()
        cboFileName.Text = ""
        cboEntity.Text = ""
        cboStatus.Text = ""
        txtChqNo.Text = ""
        txtChqAmt.Text = ""
        txtAccountNo.Text = ""
        txtBankName.Text = ""
        txtAPIId.Text = ""
        txtChqId.Text = ""
        dtpCycleFrom.Checked = False
        dtpCycleTo.Checked = False
        dtpImportFrom.Checked = False
        dtpImportTo.Checked = False
        dtpChqForm.Checked = False
        dtpChqTo.Checked = False
        dgvReport.DataSource = Nothing
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

    Private Sub cboFileName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFileName.SelectedIndexChanged

    End Sub

    Private Sub dtpImportTo_ValueChanged(sender As Object, e As EventArgs) Handles dtpImportTo.ValueChanged

    End Sub
End Class