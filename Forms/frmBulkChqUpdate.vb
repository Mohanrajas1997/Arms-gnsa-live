Imports System.IO
Imports System.IO.FileStream
Imports MySql.Data.MySqlClient
Imports System.Data
Public Class frmBulkChqUpdate
    Dim cmd As MySqlCommand
    Dim da As MySqlDataAdapter
    Dim dt As DataTable
    Private Sub frminwardsummary_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        'If dgvsummary.RowCount > 0 Then Call LoadData()
    End Sub

    Private Sub frminwardsummary_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then SendKeys.Send("{TAB}")
    End Sub
    Private Sub frminwardsummary_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.KeyPreview = True
        MyBase.WindowState = FormWindowState.Maximized

        gsQry = " select CONCAT(entity_code,'-', entity_name) as EntityCode ,entity_gid from arms_mst_tentity"
        gsQry &= " where delete_flag='N' "
        gsQry &= " order by entity_name "
        Call gpBindCombo(gsQry, "EntityCode", "entity_gid", cboEntity, gOdbcConn)
        Call ClearAll()
    End Sub

    Private Sub frminwardsummary_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        With dgvsummary
            pnlMain.Width = Me.Width - 30
            pnlMain.Height = Me.Height - 140
            .Height = pnlMain.Height - 10
            .Width = pnlMain.Width - 10
        End With
    End Sub

    Private Sub btnrefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrefresh.Click
        Dim ds As New DataSet

        Call LoadData()

        If dgvsummary.Rows.Count <= 0 Then
            MsgBox("No records found", MsgBoxStyle.OkOnly, gsProjectName)
            Exit Sub
        End If
    End Sub

    Private Sub LoadData()
        Dim ds As New DataSet
        Dim lsSql As String
        Dim lsCond As String = ""
        Dim lobjChkBoxColumn As DataGridViewCheckBoxColumn
        Dim n As Integer

        If dtpfrom.Checked = True Then lsCond &= " and a.cycle_date >='" & Format(dtpfrom.Value, "yyyy-MM-dd") & "' "
        If dtpto.Checked = True Then lsCond &= " and a.cycle_date < '" & Format(DateAdd(DateInterval.Day, 1, dtpto.Value), "yyyy-MM-dd") & "' "

        If Not (cboEntity.SelectedIndex = -1 Or cboEntity.Text.Trim = "") Then
            lsCond &= " and a.entity_gid = '" & QuoteFilter(cboEntity.SelectedValue.ToString) & "' "
        Else
            MsgBox("Entity Cannot be empty!", MsgBoxStyle.Critical, gsProjectName)
            Exit Sub
        End If
        If lsCond = "" Then lsCond = " and 1 = 2 "

        lsSql = ""
        lsSql &= " select "
        lsSql &= " a.chq_gid,b.entity_code as 'Entity Code',a.contract_no as 'Contract No',p.lot_no as 'Lot No',p.cover_no as 'Cover No', a.cycle_date as 'Cycle Date',a.chq_date as 'Chq Date',"
        lsSql &= " a.chq_no as 'Chq No', a.chq_amount as 'Chq Amount',a.payee_name as 'Payee Name',fn_get_disc_desc(a.chq_disc,'CHQ') as 'Chq Desc'"
        lsSql &= " from arms_trn_tcheque as a"
        lsSql &= " left join arms_mst_tentity as b on b.entity_gid=a.entity_gid and b.delete_flag = 'N'"
        lsSql &= " inner join arms_trn_tpacket as p on a.packet_gid=p.packet_gid and p.delete_flag='N'"
        lsSql &= " where true "
        lsSql &= lsCond
        lsSql &= " and a.chq_disc >0 "
        lsSql &= " and a.chq_type = 'PDC' "
        lsSql &= " and a.delete_flag='N' "

        dgvsummary.Columns.Clear()
        gpPopGridView(dgvsummary, lsSql, gOdbcConn)

        With dgvsummary

            .Columns("chq_gid").Visible = False
            For i = 0 To .Columns.Count - 1
                .Columns(i).ReadOnly = True
            Next i
            n = .Columns.Count - 1

            lobjChkBoxColumn = New DataGridViewCheckBoxColumn
            lobjChkBoxColumn.HeaderText = "Select"
            lobjChkBoxColumn.Width = 50
            lobjChkBoxColumn.Name = "Select"
            lobjChkBoxColumn.Selected = False

            .Columns.Add(lobjChkBoxColumn)

            lbltotrec.Text = "Total Records : " & (.RowCount).ToString
        End With
    End Sub

    Private Sub btnclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclear.Click

        Call ClearAll()
    End Sub
    Private Sub ClearAll()
        cboEntity.Text = ""
        dtpfrom.Value = Now()
        dtpfrom.Checked = False
        dtpto.Value = Now()
        dtpto.Checked = False
        dgvsummary.DataSource = Nothing
        lbltotrec.Text = ""
    End Sub

    Private Sub btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        If MsgBox("Do you want to Close?", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2, gsProjectName) = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        If dgvsummary.Rows.Count <= 0 Then
            Exit Sub
        End If
        Call PrintDGridXML(dgvsummary, gsReportPath & "\DiscRpt.xls", "Summary")
    End Sub

    Private Sub btn_Update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Update.Click
        Dim lnChklstValue As Long = 0
        Dim lnChqId As Long = 0
        Dim i As Integer
        Dim n As Integer

        Dim lsContractNo As String = ""
        Dim ldChqAmount As Double = 0
        Dim lsChqNo As String = ""
        Dim lsCycleDate As String = ""
        Dim lnEntityGid As Integer
        Dim lsChqDate As String = ""

        ' check list value
        With dgvsummary
            n = .Columns.Count - 1

            For i = 0 To .Rows.Count - 1
                lnChklstValue = .Rows(i).Cells("chq_gid").Value

                If .Rows(i).Cells(n).Value = True Then
                    lnChqId = 0
                    lnChqId = lnChklstValue

                    lsContractNo = .Rows(i).Cells("Contract No").Value
                    lsCycleDate = Format(CDate(.Rows(i).Cells("Cycle Date").Value), "yyyy-MM-dd")
                    lsChqDate = Format(CDate(.Rows(i).Cells("Chq Date").Value), "yyyy-MM-dd")
                    ldChqAmount = .Rows(i).Cells("Chq Amount").Value

                    lsChqNo = Mid(Format(Val(QuoteFilter(.Rows(i).Cells("Chq No").Value).ToString), "000000"), 1, 16)
                    If Val(lsChqNo) = 0 Then lsChqNo = ""

                    Call ConOpenOdbc(ServerDetails)
                    cmd = New MySqlCommand("pr_arms_set_updatechq", gOdbcConn)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("?pr_chq_gid", lnChqId)
                    cmd.Parameters("?pr_chq_gid").Direction = ParameterDirection.Input
                    cmd.Parameters.AddWithValue("?pr_contract_no", lsContractNo)
                    cmd.Parameters("?pr_contract_no").Direction = ParameterDirection.Input
                    cmd.Parameters.AddWithValue("?pr_cycle_date", CDate(lsCycleDate))
                    cmd.Parameters("?pr_cycle_date").Direction = ParameterDirection.Input
                    cmd.Parameters.AddWithValue("?pr_chq_date", CDate(lsChqDate))
                    cmd.Parameters("?pr_chq_date").Direction = ParameterDirection.Input
                    cmd.Parameters.AddWithValue("?pr_chq_no", lsChqNo)
                    cmd.Parameters("?pr_chq_no").Direction = ParameterDirection.Input
                    cmd.Parameters.AddWithValue("?pr_chq_amount", ldChqAmount)
                    cmd.Parameters("?pr_chq_amount").Direction = ParameterDirection.Input
                    cmd.Parameters.AddWithValue("?pr_action_by", gsLoginUserCode)
                    cmd.Parameters("?pr_action_by").Direction = ParameterDirection.Input
                    cmd.Parameters.AddWithValue("?pr_chq_disc", 0)
                    cmd.Parameters("?pr_chq_disc").Direction = ParameterDirection.Input
                    'out put Para
                    cmd.Parameters.Add("?pr_result", MySqlDbType.Int32)
                    cmd.Parameters("?pr_result").Direction = ParameterDirection.Output
                    cmd.Parameters.Add("?pr_msg", MySqlDbType.VarChar)
                    cmd.Parameters("?pr_msg").Direction = ParameterDirection.Output
                    cmd.ExecuteNonQuery()
                    Call ConCloseOdbc(ServerDetails)
                    Dim res As Integer = Val(cmd.Parameters("?pr_result").Value.ToString())
                    If (res = 0) Then
                        MsgBox(cmd.Parameters("?pr_msg").Value.ToString())

                    Else
                        lnChqId = 0
                    End If
                End If
            Next i
        End With

        MsgBox(cmd.Parameters("?pr_msg").Value.ToString())
        btnrefresh.PerformClick()
    End Sub
End Class