Public Class frmFeatureRplobReport

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

            If Not (cboEntity.SelectedIndex = -1 Or cboEntity.Text.Trim = "") Then
                lsCond &= " and a.entity_gid = '" & QuoteFilter(cboEntity.SelectedValue.ToString) & "' "
            End If

            If cboChqType.Text = "SPDC" Then
                lsCond &= " and a.chq_type = 'SPDC' "
            ElseIf cboChqType.Text = "PDC" Then
                lsCond &= " and a.chq_type = 'PDC' "
            End If
            If lsCond = "" Then lsCond = " and 1 = 2 "

            gsQry = ""
            gsQry &= " select "
            gsQry &= " b.entity_code as 'Entity Code',a.contract_no as 'Contract No', a.cycle_date as 'Cycle Date',a.chq_date as 'Chq Date',"
            gsQry &= " a.chq_no as 'Chq No', a.chq_amount as 'Chq Amount',a.payee_name as 'Payee Name'"

            gsQry &= " from arms_trn_tcheque as a"
            gsQry &= " left join arms_mst_tentity as b on b.entity_gid=a.entity_gid and b.delete_flag = 'N'"
            gsQry &= " where true "
            gsQry &= lsCond
            gsQry &= " and a.available_flag = 1 "
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
            PrintDGViewXML(dgvReport, gsReportPath & "FeatureRplob.xls", "FeatureRplob Report")

            MsgBox(" Exported to Excel !!" & Chr(13) & _
                   " Saved Path : " & gsReportPath & "FeatureRplob", MsgBoxStyle.Information, gsProjectName)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub frmFeatureRplobReport_Load(sender As Object, e As EventArgs) Handles Me.Load
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
        dtpCycleFrom.Checked = False
        dtpCycleTo.Checked = False
        dgvReport.DataSource = Nothing
    End Sub

    Private Sub frmFeatureRplobReport_Resize(sender As Object, e As EventArgs) Handles Me.Resize
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
End Class