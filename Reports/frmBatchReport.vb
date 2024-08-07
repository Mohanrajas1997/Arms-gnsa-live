Public Class frmBatchReport

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
            If dtpCycleFrom.Checked = True Then lsCond &= " and a.cycle_date >='" & Format(dtpCycleFrom.Value, "yyyy-MM-dd") & "' "
            If dtpCycleTo.Checked = True Then lsCond &= " and a.cycle_date < '" & Format(DateAdd(DateInterval.Day, 1, dtpCycleTo.Value), "yyyy-MM-dd") & "' "

            If dtpBatchFrom.Checked = True Then lsCond &= " and a.insert_date >='" & Format(dtpBatchFrom.Value, "yyyy-MM-dd") & "' "
            If dtpBatchTo.Checked = True Then lsCond &= " and a.insert_date < '" & Format(DateAdd(DateInterval.Day, 1, dtpBatchTo.Value), "yyyy-MM-dd") & "' "

            If Not (cboEntity.SelectedIndex = -1 Or cboEntity.Text.Trim = "") Then
                lsCond &= " and a.entity_gid = '" & QuoteFilter(cboEntity.SelectedValue.ToString) & "' "
            End If

            If Not (cboProductCode.SelectedIndex = -1 Or cboProductCode.Text.Trim = "") Then
                lsCond &= " and b.prod_flag = '" & QuoteFilter(cboProductCode.SelectedValue.ToString) & "' "
            End If

            'If txtBatchId.Text <> "" Then lsCond &= " and a.batch_gid = " & Val(txtBatchId.Text) & " "

            If lsCond = "" Then lsCond = " and 1 = 2 "

            gsQry = ""
            gsQry &= " select "
            gsQry &= "  a.insert_date as 'DISPATCH DATE',c.entity_name as 'CLIENT',a.tot_count as 'NO. OF CHQS',a.tot_amount as 'AMOUNT',a.cycle_date as 'CHEQUE DATE'"
            'gsQry &= "  d.loc_name as 'Location', "
            'gsQry &= " b.prod_desc as 'Product',a.cts_flag as 'CTS Flag',a.system_ip as 'System Ip',a.insert_by as 'Insert By',a.update_date as 'Update Date',a.update_by as 'Update By' "

            gsQry &= " from arms_trn_tbatch as a"
            gsQry &= " left join arms_mst_tproduct as b on b.prod_flag=a.prod_flag and b.delete_flag = 'N'"
            gsQry &= " left join arms_mst_tentity as c on c.entity_gid=a.entity_gid and c.delete_flag = 'N'"
            gsQry &= " left join arms_mst_tlocation as d on d.loc_code=a.loc_code and d.delete_flag = 'N'"
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
            PrintDGViewXML(dgvReport, gsReportPath & "Batch.xls", "Batch Report")

            MsgBox(" Exported to Excel !!" & Chr(13) & _
                   " Saved Path : " & gsReportPath & "BatchReport", MsgBoxStyle.Information, gsProjectName)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub frmBatchReport_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            'dtpCycleFrom.MaxDate = Date.Today()
            'dtpCycleFrom.MaxDate = Date.Today()

            gsQry = " select CONCAT(entity_code,'-', entity_name) as EntityCode ,entity_gid from arms_mst_tentity"
            gsQry &= " where delete_flag='N' "
            gsQry &= " order by entity_name "
            Call gpBindCombo(gsQry, "EntityCode", "entity_gid", cboEntity, gOdbcConn)

            gsQry = " select CONCAT(prod_code,'-', prod_desc) as ProdCode ,prod_flag from arms_mst_tproduct"
            gsQry &= " where delete_flag='N' "
            gsQry &= " order by prod_desc "
            Call gpBindCombo(gsQry, "ProdCode", "prod_flag", cboProductCode, gOdbcConn)

            Call ClearAll()

            KeyPreview = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
       
    End Sub

    Private Sub frmBatchReport_Resize(sender As Object, e As EventArgs) Handles Me.Resize
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
        cboEntity.Text = ""
        'txtBatchId.Text = ""
        cboProductCode.Text = ""
        dtpCycleFrom.Checked = False
        dtpCycleTo.Checked = False
        dgvReport.DataSource = Nothing
    End Sub
End Class