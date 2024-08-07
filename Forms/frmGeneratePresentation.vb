Imports System.IO
Imports System.IO.FileStream
Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Security.Cryptography

Public Class frmGeneratePresentation
    Dim lsCond As String = ""
    Dim lnEntityId As Long
    Dim lnres As Integer
    Dim lnResult As Long

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnRefresh.Click
        Dim i As Integer

        lsCond = ""

        Try
            If dtpCycleFrom.Checked = True Then lsCond &= " and a.cycle_date >='" & Format(dtpCycleFrom.Value, "yyyy-MM-dd") & "' "
            If dtpCycleTo.Checked = True Then lsCond &= " and a.cycle_date < '" & Format(DateAdd(DateInterval.Day, 1, dtpCycleTo.Value), "yyyy-MM-dd") & "' "

            If Not (cboEntity.SelectedIndex = -1 Or cboEntity.Text.Trim = "") Then
                lsCond &= " and a.entity_gid = '" & QuoteFilter(cboEntity.SelectedValue.ToString) & "' "
                lnEntityId = QuoteFilter(cboEntity.SelectedValue.ToString)
            Else
                MsgBox("Entity Cannot be empty!", MsgBoxStyle.Critical, gsProjectName)
                Exit Sub
            End If


            If lsCond = "" Then lsCond = " and 1 = 2 "

            gsQry = ""
            gsQry &= " select "
            gsQry &= "  a.chq_gid,b.entity_code as 'Entity Code',a.contract_no as 'Contract No',p.lot_no as 'Lot No',p.cover_no as 'Cover No', a.cycle_date as 'Cycle Date',a.chq_date as 'Chq Date',"
            gsQry &= " a.chq_no as 'Chq No', a.chq_amount as 'Chq Amount',a.payee_name as 'Payee Name'"
            gsQry &= " from arms_trn_tcheque as a"
            gsQry &= " left join arms_mst_tentity as b on b.entity_gid=a.entity_gid and b.delete_flag = 'N'"
            gsQry &= " inner join arms_trn_tpacket as p on a.packet_gid=p.packet_gid and p.delete_flag='N'"
            gsQry &= " where true "
            gsQry &= lsCond
            gsQry &= " and a.available_flag = 1 "
            'gsQry &= " and p.Cheque_type = 'PDC'"
            gsQry &= " and a.chq_type = 'PDC'"
            gsQry &= " and a.delete_flag='N' "

            Call gpPopGridView(dgvReport, gsQry, gOdbcConn)

            For i = 0 To dgvReport.Columns.Count - 1
                dgvReport.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next i

            dgvReport.AutoResizeColumns()
            If dgvReport.Rows.Count > 0 Then
                btnGenerate.Enabled = True
            End If
            lblRecCount.Text = "Record Count: " & dgvReport.RowCount
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, gsProjectName)
        End Try
    End Sub

    Private Sub btnClear_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClear.Click
        Call ClearAll()
    End Sub

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClose.Click
        MyBase.Close()
    End Sub

    Private Sub btnExport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExport.Click
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

    Private Sub frmFeatureRplobReport_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Try
            gsQry = " select CONCAT(entity_code,'-', entity_name) as EntityCode ,entity_gid from arms_mst_tentity"
            gsQry &= " where delete_flag='N' "
            gsQry &= " order by entity_name "
            Call gpBindCombo(gsQry, "EntityCode", "entity_gid", cboEntity, gOdbcConn)
            Call ClearAll()
            btnGenerate.Enabled = False
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
        btnGenerate.Enabled = False
    End Sub

    Private Sub frmFeatureRplobReport_Resize(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Resize
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

    Private Sub btnGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        Dim i As Integer
        Dim n As Integer
        Dim c As Integer
        Dim d As Integer

        Dim fsSql As String
        Dim lbInsertFlag As Boolean = False
        Dim lsDiscRemark As String = ""

        Dim lnFileId As Long = 0
        Dim lsContractNumber As String = ""
        Dim lsCycleDate As String = ""
        Dim lsChqDate As String = ""
        Dim lsChqNo As String = ""
        Dim lsPayeeName As String = ""
        Dim lnChqAmt As Double = 0
        Dim lsEntityCode As String = ""
        Dim cmd As MySqlCommand
        Dim frm As frmQuickView
        Dim lsFileName As String
        Try


            Select Case ""
                Case cboEntity.Text
                    MsgBox("Entity Can Not Be Empty!", MsgBoxStyle.Information, gsProjectName)
                    cboEntity.Focus()
                    Exit Sub
            End Select

         

            Dim regDate As Date = Date.Now()
            Dim strDate As String = regDate.ToString("ddMMMyyyy")

            lsFileName = "Generate Automated" + "_" + strDate

            'File Name Duplicate
            fsSql = ""
            fsSql &= " select file_gid from arms_trn_tfile"
            fsSql &= " where 1=1 "
            fsSql &= " and file_name = '" & lsFileName & "'"
            fsSql &= " and sheet_name='Automated'"
            fsSql &= " and file_type = " & gnFilePullout & " "
            fsSql &= " and entity_gid='" & lnEntityId & "'"
            fsSql &= " and delete_flag ='N'"

            lnFileId = Val(gfExecuteScalar(fsSql, gOdbcConn))

            If lnFileId > 0 Then
                MsgBox("File Already Imported !", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gsProjectName)

                Exit Sub
            End If

            Call ConOpenOdbc(ServerDetails)
            cmd = New MySqlCommand("pr_arms_trn_tfile", gOdbcConn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("?pr_entity_gid", lnEntityId)
            cmd.Parameters("?pr_entity_gid").Direction = ParameterDirection.Input
            cmd.Parameters.AddWithValue("?pr_file_name", lsFileName)
            cmd.Parameters("?pr_file_name").Direction = ParameterDirection.Input
            cmd.Parameters.AddWithValue("?pr_sheet_name", "Automated")
            cmd.Parameters("?pr_sheet_name").Direction = ParameterDirection.Input
            cmd.Parameters.AddWithValue("?pr_file_type", gnFileRplob)
            cmd.Parameters("?pr_file_type").Direction = ParameterDirection.Input
            cmd.Parameters.AddWithValue("?pr_action_by", gsLoginUserCode)
            cmd.Parameters("?pr_action_by").Direction = ParameterDirection.Input
            cmd.Parameters.AddWithValue("?pr_action", "INSERT")
            cmd.Parameters("?pr_action").Direction = ParameterDirection.Input
            'Out put Para
            cmd.Parameters.Add("?pr_result", MySqlDbType.Int32)
            cmd.Parameters("?pr_result").Direction = ParameterDirection.Output
            cmd.Parameters.Add("?pr_err_msg", MySqlDbType.VarChar)
            cmd.Parameters("?pr_err_msg").Direction = ParameterDirection.Output

            cmd.ExecuteNonQuery()
            Call ConCloseOdbc(ServerDetails)

            lnResult = Val(cmd.Parameters("?pr_result").Value.ToString())
            lnFileId = lnResult

            If (lnResult = 0) Then
                MsgBox(cmd.Parameters("?pr_err_msg").Value.ToString())
                Exit Sub
            End If

            With dgvReport
                n = .Columns.Count - 1
                For i = 0 To .Rows.Count - 1

                    Me.Cursor = Cursors.WaitCursor
                    Application.DoEvents()

                    lbInsertFlag = True
                    lsDiscRemark = ""

                    lsContractNumber = QuoteFilter(.Rows(i).Cells("Contract No").Value)
                    lsEntityCode = Mid(QuoteFilter(.Rows(i).Cells("Entity Code").Value), 1, 16)
                    lsPayeeName = QuoteFilter(.Rows(i).Cells("Payee Name").Value)
                    lsCycleDate = QuoteFilter(.Rows(i).Cells("Cycle Date").Value)
                    If IsDate(lsCycleDate) Then
                        lsCycleDate = Format(CDate(lsCycleDate), "yyyy-MM-dd")
                    Else
                        lsCycleDate = ""
                    End If

                    lsChqDate = QuoteFilter(.Rows(i).Cells("Chq Date").Value)
                    If IsDate(lsChqDate) Then
                        lsChqDate = Format(CDate(lsChqDate), "yyyy-MM-dd")
                    Else
                        lsChqDate = ""
                    End If


                    lnChqAmt = Math.Round(Val(QuoteFilter(.Rows(i).Cells("Chq Amount").Value)), 2)
                    lsChqNo = Mid(Format(Val(QuoteFilter(.Rows(i).Cells("Chq No").Value)), "000000"), 1, 16)
                    If Val(lsChqNo) = 0 Then lsChqNo = ""

                    Call ConOpenOdbc(ServerDetails)
                    cmd = New MySqlCommand("pr_arms_trn_trplob", gOdbcConn)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("?pr_entity_gid", lnEntityId)
                    cmd.Parameters("?pr_entity_gid").Direction = ParameterDirection.Input
                    cmd.Parameters.AddWithValue("?pr_file_gid", lnFileId)
                    cmd.Parameters("?pr_file_gid").Direction = ParameterDirection.Input
                    cmd.Parameters.AddWithValue("?pr_contract_no", lsContractNumber)
                    cmd.Parameters("?pr_contract_no").Direction = ParameterDirection.Input
                    cmd.Parameters.AddWithValue("?pr_payee_name", lsPayeeName)
                    cmd.Parameters("?pr_payee_name").Direction = ParameterDirection.Input
                    cmd.Parameters.AddWithValue("?pr_cycle_date", CDate(lsCycleDate))
                    cmd.Parameters("?pr_cycle_date").Direction = ParameterDirection.Input
                    cmd.Parameters.AddWithValue("?pr_chq_date", CDate(lsChqDate))
                    cmd.Parameters("?pr_chq_date").Direction = ParameterDirection.Input
                    cmd.Parameters.AddWithValue("?pr_chq_no", lsChqNo)
                    cmd.Parameters("?pr_chq_no").Direction = ParameterDirection.Input
                    cmd.Parameters.AddWithValue("?pr_chq_amount", lnChqAmt)
                    cmd.Parameters("?pr_chq_amount").Direction = ParameterDirection.Input
                    cmd.Parameters.AddWithValue("?pr_action", "INSERT")
                    cmd.Parameters("?pr_action").Direction = ParameterDirection.Input
                    'Out put Para
                    cmd.Parameters.Add("?pr_result", MySqlDbType.Int32)
                    cmd.Parameters("?pr_result").Direction = ParameterDirection.Output
                    cmd.Parameters.Add("?pr_err_msg", MySqlDbType.VarChar)
                    cmd.Parameters("?pr_err_msg").Direction = ParameterDirection.Output
                    cmd.ExecuteNonQuery()
                    Call ConCloseOdbc(ServerDetails)
                    lnres = Val(cmd.Parameters("?pr_result").Value.ToString())
                    If lnres > 0 Then
                        c += 1
                    Else
                        d += 1
                        lsDiscRemark = "Line " & (i + 1).ToString & ":" & cmd.Parameters("?pr_err_msg").Value.ToString()
                    End If

                    If (lnres = 0) Then
                        Call ConOpenOdbc(ServerDetails)
                        cmd = New MySqlCommand("pr_arms_trn_terrmsg", gOdbcConn)
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.Parameters.AddWithValue("?pr_file_gid", lnFileId)
                        cmd.Parameters("?pr_file_gid").Direction = ParameterDirection.Input
                        cmd.Parameters.AddWithValue("?pr_errmsg_desc", lsDiscRemark)
                        cmd.Parameters("?pr_errmsg_desc").Direction = ParameterDirection.Input
                        cmd.Parameters.AddWithValue("?pr_action", "INSERT")
                        cmd.Parameters("?pr_action").Direction = ParameterDirection.Input
                        'Out put Para
                        cmd.Parameters.Add("?pr_result", MySqlDbType.Int32)
                        cmd.Parameters("?pr_result").Direction = ParameterDirection.Output
                        cmd.Parameters.Add("?pr_err_msg", MySqlDbType.VarChar)
                        cmd.Parameters("?pr_err_msg").Direction = ParameterDirection.Output
                        cmd.ExecuteNonQuery()
                        Call ConCloseOdbc(ServerDetails)
                        lnres = Val(cmd.Parameters("?pr_result").Value.ToString())
                        If (Convert.ToInt32(lnres) = 0) Then
                            MsgBox(cmd.Parameters("?pr_err_msg").Value.ToString())
                        End If
                    End If

                Next i
            End With

            MsgBox("Out of " & i & " record(s) " & c & " record(s) generated successfully ! ", MsgBoxStyle.Information, gsProjectName)

            fsSql = ""
            fsSql &= " select * from arms_trn_trplob "
            fsSql &= " where file_gid =  " & lnFileId & " "
            fsSql &= " and delete_flag = 'N' "

            frm = New frmQuickView(gOdbcConn, fsSql)
            frm.ShowDialog()

            If d > 0 Then
                MsgBox(d & " record(s) failed to import !", MsgBoxStyle.Critical, gsProjectName)
                fsSql = ""
                fsSql &= " select * from arms_trn_terrmsg "
                fsSql &= " where file_gid =  " & lnFileId & " "
                fsSql &= " and delete_flag = 'N' "

                frm = New frmQuickView(gOdbcConn, fsSql)
                frm.ShowDialog()
            End If

            btnGenerate.Enabled = True
            Application.DoEvents()
            btnRefresh.PerformClick()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, gsProjectName)
            btnGenerate.Enabled = True
            Me.Cursor = Cursors.Default
            Application.DoEvents()
        End Try
    End Sub
End Class