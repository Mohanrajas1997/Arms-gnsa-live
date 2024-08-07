Public Class frmScanReport
    Dim lsCond As String
    Private Sub frmScanReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        txtChqNo.Text = ""
        txtChqAmt.Text = ""
        txtBankName.Text = ""
        txtContractNo.Text = ""
        txtScanId.Text = ""
        txtMicr.Text = ""
        dtpChqForm.Checked = False
        dtpChqTo.Checked = False
        dgvReport.DataSource = Nothing
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Call ClearAll()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Dim i As Integer
        lsCond = ""

        Try
            If dtpChqForm.Checked = True Then lsCond &= " and a.scan_chq_date >='" & Format(dtpChqForm.Value, "yyyy-MM-dd") & "' "
            If dtpChqTo.Checked = True Then lsCond &= " and a.scan_chq_date <='" & Format(dtpChqTo.Value, "yyyy-MM-dd") & "' "

            If Not (cboEntity.SelectedIndex = -1 Or cboEntity.Text = "") Then
                lsCond &= " and b.entity_gid ='" & Val(cboEntity.SelectedValue.ToString) & "' "
            End If

            If txtContractNo.Text <> "" Then lsCond &= " and b.contract_no = '" & QuoteFilter(txtContractNo.Text) & "' "
            If txtChqNo.Text <> "" Then lsCond &= " and a.scan_chq_no = '" & QuoteFilter(txtChqNo.Text) & "' "
            If txtChqAmt.Text <> "" Then lsCond &= " and a.scan_chq_amount = '" & QuoteFilter(txtChqAmt.Text) & "' "
            If txtBankName.Text <> "" Then lsCond &= " and a.scan_bank_name = '" & QuoteFilter(txtBankName.Text) & "' "
            If txtMicr.Text <> "" Then lsCond &= " and a.scan_micr_code = '" & QuoteFilter(txtMicr.Text) & "' "
            If txtScanId.Text <> "" Then lsCond &= " and a.scan_gid = '" & QuoteFilter(txtScanId.Text) & "' "

            gsQry = ""
            gsQry &= " select "
            gsQry &= " d.entity_name as 'Company',"
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
            gsQry &= lsCond

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

    Private Sub btnExport_Click(sender As Object, e As EventArgs)
        Try
            If dgvReport.RowCount = 0 Then
                MsgBox("No Details to Export!", MsgBoxStyle.Critical, gsProjectName)
                Exit Sub
            End If

            PrintDGViewXML(dgvReport, gsReportPath & "Scan.xls", "Scan Report", "", True, True)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub frmScanReport_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        Try
            With dgvReport
                .Top = pnlMain.Top + pnlMain.Height + 5
                .Width = Me.Width - 40
                .Height = Me.Height - pnlMain.Height - pnlExport.Height - 60
                pnlExport.Width = .Width
                pnlExport.Top = pnlMain.Top + pnlMain.Height + dgvReport.Height + 10
                btnExport.Left = pnlExport.Width - (btnExport.Width + 10)
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class