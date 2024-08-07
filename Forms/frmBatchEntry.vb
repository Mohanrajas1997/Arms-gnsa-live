Imports System.IO
Imports System.IO.FileStream
Imports MySql.Data.MySqlClient
Imports System.Data

Public Class frmBatchEntry

#Region "Local Declaration"
    Dim lnChqId As Integer
    Dim lnResult As Long
    Dim lsIpAddr As String = ""
    Dim lsContractNo As String = ""
    Dim ldChqAmount As Double = 0
    Dim lsChqNo As String = ""
    Dim lsCycleDate As String = ""
    Dim lnEntityGid As Integer
    Dim lnBatchGid As Integer
    Dim cmd As MySqlCommand
    Dim da As MySqlDataAdapter
    Dim ds As DataSet
#End Region

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.       
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        Try
            lnEntityGid = cboEntity.SelectedValue
            lsCycleDate = Format(CDate(dtpCycleDate.Text), "yyyy-MM-dd")
            lsChqNo = Format(Val(txtChqNo.Text), "000000")
            ldChqAmount = Math.Round(Val(txtChqAmt.Text.ToString), 2)
            lsContractNo = txtContractNo.Text
            'txtChqId.Text = dgvContractdtls.Rows(1).Cells("chq_gid").Value.ToString
            lsIpAddr = IPAddresses("")
            Dim i As Integer
            If Not Integer.TryParse(txtChqId.Text, i) Then
                i = 0
            End If
            lnChqId = i

            Call ConOpenOdbc(ServerDetails)
            cmd = New MySqlCommand("pr_arms_trn_tbatchentry", gOdbcConn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("?pr_entity_gid", lnEntityGid)
            cmd.Parameters("?pr_entity_gid").Direction = ParameterDirection.Input
            cmd.Parameters.AddWithValue("?pr_cycle_date", CDate(lsCycleDate))
            cmd.Parameters("?pr_cycle_date").Direction = ParameterDirection.Input
            cmd.Parameters.AddWithValue("?pr_contract_no", lsContractNo)
            cmd.Parameters("?pr_contract_no").Direction = ParameterDirection.Input
            cmd.Parameters.AddWithValue("?pr_chq_no", lsChqNo)
            cmd.Parameters("?pr_chq_no").Direction = ParameterDirection.Input
            cmd.Parameters.AddWithValue("?pr_chq_amount", ldChqAmount)
            cmd.Parameters("?pr_chq_amount").Direction = ParameterDirection.Input
            cmd.Parameters.AddWithValue("?pr_chq_gid", lnChqId)
            cmd.Parameters("?pr_chq_gid").Direction = ParameterDirection.Input
            'cmd.Parameters.AddWithValue("?pr_system_ip", "192.168.1.66")
            cmd.Parameters.AddWithValue("?pr_system_ip", lsIpAddr)
            'lsIpAddr)
            cmd.Parameters("?pr_system_ip").Direction = ParameterDirection.Input
            cmd.Parameters.AddWithValue("?pr_action_by", gsLoginUserCode)
            cmd.Parameters("?pr_action_by").Direction = ParameterDirection.Input
            cmd.Parameters.AddWithValue("?pr_action", "INSERT")
            cmd.Parameters("?pr_action").Direction = ParameterDirection.Input
            'Out put Para
            cmd.Parameters.Add("?pr_result", MySqlDbType.Int32)
            cmd.Parameters("?pr_result").Direction = ParameterDirection.Output

            cmd.Parameters.Add("?pr_msg", MySqlDbType.VarChar)
            cmd.Parameters("?pr_msg").Direction = ParameterDirection.Output

            cmd.ExecuteNonQuery()
            Call ConCloseOdbc(ServerDetails)
            Dim res As Integer = Val(cmd.Parameters("?pr_result").Value.ToString())
            If (res = 0) Then
                MsgBox(cmd.Parameters("?pr_msg").Value.ToString())

                If cmd.Parameters("?pr_msg").Value.ToString().ToLower() = "more than one record found" Then
                    Call BindContractDtls()
                Else
                    txtChqNo.Focus()
                End If
            Else
                MsgBox(cmd.Parameters("?pr_msg").Value.ToString(), MsgBoxStyle.Information, gsProjectName)
                Call BindDgvBatchEntry()
                Call ClearAll()
                txtChqNo.Focus()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub txtChqAmt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtChqAmt.LostFocus
        If Val(txtChqAmt.Text) > 0 Then
            If txtChqNo.Text.Trim = "" Then
                MsgBox("please enter Cheque No", MsgBoxStyle.Information)
                txtChqNo.Focus()
                Exit Sub
            ElseIf Not IsDate(dtpCycleDate.Text) Then
                MsgBox("please enter Valid Cheque Date", MsgBoxStyle.Information)
                Exit Sub
            Else
                Call BindContractDtls()
            End If
        End If
    End Sub

    Private Sub BindContractDtls()
        Dim lsSql As String = ""
        Me.KeyPreview = True

        lnEntityGid = cboEntity.SelectedValue
        lsCycleDate = Format(CDate(dtpCycleDate.Text), "yyyy-MM-dd")
        lsChqNo = Format(Val(txtChqNo.Text), "000000")
        ldChqAmount = Math.Round(Val(txtChqAmt.Text), 2)

        lsSql = ""
        lsSql &= " select chq_gid, contract_no as 'Contract No', payee_name  as 'Customer Name'"
        lsSql &= " FROM arms_trn_tcheque "
        lsSql &= " WHERE entity_gid=" & lnEntityGid
        lsSql &= " and cycle_date='" & lsCycleDate & "'"
        lsSql &= " and chq_no='" & lsChqNo & "'"
        lsSql &= " and chq_amount='" & ldChqAmount & "'"
        lsSql &= " and available_flag = 1 "
        lsSql &= " and chq_status & 2 > 0"
        lsSql &= " and delete_flag='N'"

        dgvContractdtls.Columns.Clear()
        gpPopGridView(dgvContractdtls, lsSql, gOdbcConn)

        If dgvContractdtls.Rows.Count > 0 Then
            With dgvContractdtls
                .Columns("chq_gid").Visible = False
                .Columns("Customer Name").Width = 320
            End With
        End If
    End Sub

    Private Sub btnClr_Click(sender As Object, e As EventArgs) Handles btnClr.Click
        Call ClearAll()
        txtChqNo.Focus()
    End Sub

    Private Sub frmBatchEntry_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmBatchEntry_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            ' dtpCycleDate.MaxDate = Date.Today()

            gsQry = " select CONCAT(entity_code,'-', entity_name) as EntityCode ,entity_gid from arms_mst_tentity"
            gsQry &= " where delete_flag='N' "
            gsQry &= " order by entity_name "
            Call gpBindCombo(gsQry, "EntityCode", "entity_gid", cboEntity, gOdbcConn)

            ' Call BindDgvBatchEntry()
            Me.KeyPreview = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ClearAll()
        txtChqNo.Text = ""
        txtChqAmt.Text = ""
        txtContractNo.Text = ""
        txtChqId.Text = ""

    End Sub

    Private Sub BindDgvBatchEntry()
        Dim i As Integer
        Dim lobjBtn As DataGridViewButtonColumn

        dgvBatchEntry.Columns.Clear()

        cmd = New MySqlCommand("pr_arms_get_batchentry", gOdbcConn)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("?pr_entity_gid", lnEntityGid)
        cmd.Parameters("?pr_entity_gid").Direction = ParameterDirection.Input
        cmd.Parameters.AddWithValue("?pr_cycle_date", lsCycleDate)
        cmd.Parameters("?pr_cycle_date").Direction = ParameterDirection.Input
        'cmd.Parameters.AddWithValue("?pr_system_ip", "192.168.0.64")
        cmd.Parameters.AddWithValue("?pr_system_ip", lsIpAddr)
        cmd.Parameters("?pr_system_ip").Direction = ParameterDirection.Input
        cmd.Parameters.AddWithValue("?pr_entry_by", gsLoginUserCode)
        cmd.Parameters("?pr_entry_by").Direction = ParameterDirection.Input
        ds = New DataSet
        da = New MySqlDataAdapter(cmd)
        da.Fill(ds)
        dgvBatchEntry.DataSource = ds.Tables(0)
        dgvBatchEntrySub.DataSource = ds.Tables(1)

        For i = 0 To dgvBatchEntry.Columns.Count - 1
            dgvBatchEntry.Columns(i).ReadOnly = True
            dgvBatchEntry.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
        Next i


        For i = 0 To dgvBatchEntrySub.Columns.Count - 1
            dgvBatchEntrySub.Columns(i).ReadOnly = True
            dgvBatchEntrySub.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
        Next i

        lobjBtn = New DataGridViewButtonColumn
        lobjBtn.HeaderText = "Remove"
        dgvBatchEntry.Columns.Insert(0, lobjBtn)

        For i = 0 To dgvBatchEntry.RowCount - 1
            dgvBatchEntry.Rows(i).Cells(0).Value = "Remove"
        Next i

        dgvBatchEntry.Columns("Chq Id").Visible = False
        dgvBatchEntry.Columns("Entry Id").Visible = False


    End Sub

    Private Sub dgvBatchEntry_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvBatchEntry.CellContentClick
        With dgvBatchEntry
            If e.ColumnIndex = 0 Then
                'Select Case e.ColumnIndex
                '    Case .Columns.Count - 10
                lnChqId = Val(.Rows(e.RowIndex).Cells.Item("Chq Id").Value.ToString())
                lsIpAddr = IPAddresses("")

                If lnChqId > 0 Then

                    If MsgBox("Are you sure to delete ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, gsProjectName) = MsgBoxResult.Yes Then
                        Call ConOpenOdbc(ServerDetails)
                        cmd = New MySqlCommand("pr_arms_trn_tbatchentry", gOdbcConn)
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.Parameters.AddWithValue("?pr_entity_gid", 0)
                        cmd.Parameters("?pr_entity_gid").Direction = ParameterDirection.Input
                        cmd.Parameters.AddWithValue("?pr_cycle_date", CDate(lsCycleDate))
                        cmd.Parameters("?pr_cycle_date").Direction = ParameterDirection.Input
                        cmd.Parameters.AddWithValue("?pr_contract_no", 0)
                        cmd.Parameters("?pr_contract_no").Direction = ParameterDirection.Input
                        cmd.Parameters.AddWithValue("?pr_chq_no", 0)
                        cmd.Parameters("?pr_chq_no").Direction = ParameterDirection.Input
                        cmd.Parameters.AddWithValue("?pr_chq_amount", 0)
                        cmd.Parameters("?pr_chq_amount").Direction = ParameterDirection.Input
                        cmd.Parameters.AddWithValue("?pr_chq_gid", lnChqId)
                        cmd.Parameters("?pr_chq_gid").Direction = ParameterDirection.Input
                        'cmd.Parameters.AddWithValue("?pr_system_ip", "192.168.0.64")
                        cmd.Parameters.AddWithValue("?pr_system_ip", lsIpAddr)
                        cmd.Parameters("?pr_system_ip").Direction = ParameterDirection.Input
                        cmd.Parameters.AddWithValue("?pr_action_by", gsLoginUserCode)
                        cmd.Parameters("?pr_action_by").Direction = ParameterDirection.Input
                        cmd.Parameters.AddWithValue("?pr_action", "DELETE")
                        cmd.Parameters("?pr_action").Direction = ParameterDirection.Input
                        'Out put Para
                        cmd.Parameters.Add("?pr_result", MySqlDbType.Int32)
                        cmd.Parameters("?pr_result").Direction = ParameterDirection.Output
                        cmd.Parameters.Add("?pr_msg", MySqlDbType.VarChar)
                        cmd.Parameters("?pr_msg").Direction = ParameterDirection.Output
                        cmd.ExecuteNonQuery()
                        Call ConCloseOdbc(ServerDetails)
                        Dim res As String = cmd.Parameters("?pr_result").Value.ToString()



                        If (res = 0) Then
                            MsgBox(cmd.Parameters("?pr_msg").Value.ToString())
                            Call BindDgvBatchEntry()
                            txtChqNo.Focus()
                        Else
                            'MsgBox("Record deleted successfully !", MsgBoxStyle.Information, gsProjectName)
                            MsgBox(cmd.Parameters("?pr_msg").Value.ToString())
                            Call BindDgvBatchEntry()
                            Call ClearAll()
                            txtChqNo.Focus()
                        End If
                    End If
                    'End Select
                End If
            End If
        End With
    End Sub

    Private Sub txtChqNo_GotFocus(sender As Object, e As EventArgs) Handles txtChqNo.GotFocus
        With txtChqNo
            .SelectionStart = 0
            .SelectionLength = .TextLength
        End With
    End Sub

    Private Sub txtChqNo_TextChanged(sender As Object, e As EventArgs) Handles txtChqNo.TextChanged

    End Sub

    Private Sub txtChqAmt_GotFocus(sender As Object, e As EventArgs) Handles txtChqAmt.GotFocus
        With txtChqNo
            .SelectionStart = 0
            .SelectionLength = .TextLength
        End With
    End Sub


    Private Sub dgvContractdtls_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvContractdtls.CellDoubleClick
        If e.RowIndex < 0 Then Exit Sub
        txtChqId.Text = dgvContractdtls.Rows(e.RowIndex).Cells("chq_gid").Value.ToString
        txtContractNo.Text = dgvContractdtls.Rows(e.RowIndex).Cells("Contract No").Value.ToString
    End Sub


End Class