Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Data
Imports MySql.Data
Imports MySql.Data.MySqlClient
Public Class frmMicr

#Region "Local Declaration"
    Dim msSql As String
    Dim mnResult As Integer
#End Region

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.       
    End Sub

    Private Sub frmMicr_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then SendKeys.Send("{TAB}")
    End Sub
    Private Sub EnableSave(ByVal Status As Boolean)
        pnlButtons.Visible = Not Status
        pnlSave.Visible = Status
        pnlMain.Enabled = Status
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Select Case ""
            Case txtName.Text
                MsgBox("Bank name cannot be empty !", MsgBoxStyle.Critical, gsProjectName)
                txtName.Focus()
                Exit Sub
            Case txtcode.Text
                MsgBox("Bank Code cannot be empty !", MsgBoxStyle.Critical, gsProjectName)
                txtcode.Focus()
                Exit Sub
            Case txtmicrcode.Text
                MsgBox("Micr Code cannot be empty !", MsgBoxStyle.Critical, gsProjectName)
                txtmicrcode.Focus()
                Exit Sub
            Case TxtBranchName.Text
                MsgBox("Branch Name cannot be empty !", MsgBoxStyle.Critical, gsProjectName)
                TxtBranchName.Focus()
                Exit Sub
        End Select

        If txtId.Text.Trim = "" Then

            Dim Bankname As String = txtName.Text
            Dim Bankcode As String = txtcode.Text
            Dim micrcode As String = txtmicrcode.Text
            Dim Bnk_micr_code As String = Mid(micrcode, 4, 3)
            Dim BranchName As String = TxtBranchName.Text
            Using cmd As New MySqlCommand("pr_arms_mst_tmicr", gOdbcConn)
                Call ConOpenOdbc(ServerDetails)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("?pr_micr_gid", 0)
                cmd.Parameters("?pr_micr_gid").Direction = ParameterDirection.Input
                cmd.Parameters.AddWithValue("?pr_micr_code", micrcode)
                cmd.Parameters("?pr_micr_code").Direction = ParameterDirection.Input
                cmd.Parameters.AddWithValue("?pr_micr_bank_code", Bnk_micr_code)
                cmd.Parameters("?pr_micr_bank_code").Direction = ParameterDirection.Input
                cmd.Parameters.AddWithValue("?pr_bank_code", Bankcode)
                cmd.Parameters("?pr_bank_code").Direction = ParameterDirection.Input

                cmd.Parameters.AddWithValue("?pr_bank_name", Bankname)
                cmd.Parameters("?pr_bank_name").Direction = ParameterDirection.Input
                cmd.Parameters.AddWithValue("?pr_branch_name", BranchName)
                cmd.Parameters("?pr_branch_name").Direction = ParameterDirection.Input

                cmd.Parameters.AddWithValue("?pr_action", "INSERT")
                cmd.Parameters("?pr_action").Direction = ParameterDirection.Input
                'Out put Para
                cmd.Parameters.Add("?pr_result", MySqlDbType.Int32)
                cmd.Parameters("?pr_result").Direction = ParameterDirection.Output
                cmd.Parameters.Add("?pr_err_msg", MySqlDbType.VarChar)
                cmd.Parameters("?pr_err_msg").Direction = ParameterDirection.Output
                cmd.ExecuteNonQuery()
                Call ConCloseOdbc(ServerDetails)
                Dim res As String = cmd.Parameters("?pr_result").Value.ToString()
                If (res = 0) Then
                    MsgBox(cmd.Parameters("?pr_err_msg").Value.ToString())
                    txtcode.Focus()
                Else
                    MsgBox("Record updated successfully !", MsgBoxStyle.Information, gsProjectName)
                    Call ClearAll()
                    EnableSave(False)
                    btnNew.Focus()
                End If
            End Using
        Else
            ' Update rack
            Dim id As Integer = Convert.ToInt32(txt)
            Dim Bankname As String = txtName.Text
            Dim Bankcode As String = txtcode.Text
            Dim micrcode As String = txtmicrcode.Text
            Dim Bnk_micr_code As String = Mid(micrcode, 4, 3)
            Dim BranchName As String = TxtBranchName.Text
            Using cmd As New MySqlCommand("pr_arms_mst_tmicr", gOdbcConn)
                Call ConOpenOdbc(ServerDetails)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("?pr_micr_gid", id)
                cmd.Parameters("?pr_micr_gid").Direction = ParameterDirection.Input
                cmd.Parameters.AddWithValue("?pr_micr_code", micrcode)
                cmd.Parameters("?pr_micr_code").Direction = ParameterDirection.Input
                cmd.Parameters.AddWithValue("?pr_micr_bank_code", Bnk_micr_code)
                cmd.Parameters("?pr_micr_bank_code").Direction = ParameterDirection.Input
                cmd.Parameters.AddWithValue("?pr_bank_code", Bankcode)
                cmd.Parameters("?pr_bank_code").Direction = ParameterDirection.Input
                cmd.Parameters.AddWithValue("?pr_bank_name", Bankname)
                cmd.Parameters("?pr_bank_name").Direction = ParameterDirection.Input
                cmd.Parameters.AddWithValue("?pr_branch_name", BranchName)
                cmd.Parameters("?pr_branch_name").Direction = ParameterDirection.Input

                cmd.Parameters.AddWithValue("?pr_action", "UPDATE")
                cmd.Parameters("?pr_action").Direction = ParameterDirection.Input
                'Out put Para
                cmd.Parameters.Add("?pr_result", MySqlDbType.Int32)
                cmd.Parameters("?pr_result").Direction = ParameterDirection.Output
                cmd.Parameters.Add("?pr_err_msg", MySqlDbType.VarChar)
                cmd.Parameters("?pr_err_msg").Direction = ParameterDirection.Output
                cmd.ExecuteNonQuery()
                Call ConCloseOdbc(ServerDetails)
                Dim res As String = cmd.Parameters("?pr_result").Value.ToString()
                If (res = 0) Then
                    MsgBox(cmd.Parameters("?pr_err_msg").Value.ToString())
                    txtcode.Focus()
                Else
                    MsgBox("Record updated successfully !", MsgBoxStyle.Information, gsProjectName)
                    Call ClearAll()
                    EnableSave(False)
                    btnNew.Focus()
                End If
            End Using
        End If

    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Call EnableSave(True)
        Call ClearAll()
        txtcode.Focus()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Call frmCtrClear(Me)
        Call EnableSave(False)
    End Sub

    Private Sub frmBank_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            KeyPreview = True
            Call EnableSave(False)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ClearAll()
        Call frmCtrClear(Me)
    End Sub

    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
        Dim SearchDialog As frmSearch

        Try
            SearchDialog = New frmSearch(gOdbcConn, _
                             " SELECT micr_gid as 'Micr Id'," & _
                             " micr_code as 'Micr Code',micr_bank_code as 'Bank Micr Code',bank_code as 'Bank Code',bank_name as 'Bank Name',branch_name as 'Branch Name' FROM arms_mst_tmicr ", _
                             " micr_gid,micr_code,micr_bank_code,bank_code,bank_name", _
                             " 1 = 1 and delete_flag = 'N'")

            SearchDialog.ShowDialog()

            If Val(txt) <> 0 Then
                Call ListAll("select * from arms_mst_tmicr " _
                    & " where micr_gid = " & txt & " " _
                    & " and delete_flag = 'N'", gOdbcConn)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ListAll(ByVal SqlStr As String, ByVal odbcConn As MySqlConnection)
        Dim ds As New DataSet

        Try
            ds = gfDataSet(SqlStr, "list_all", gOdbcConn)

            With ds.Tables("list_all")
                If .Rows.Count > 0 Then
                    txtId.Text = .Rows(0).Item("micr_gid").ToString
                    txtmicrcode.Text = .Rows(0).Item("micr_code").ToString
                    txtcode.Text = .Rows(0).Item("bank_code").ToString
                    txtName.Text = .Rows(0).Item("bank_name").ToString
                    TxtBranchName.Text = .Rows(0).Item("branch_name").ToString

                Else
                    ClearAll()
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If txtId.Text = "" Then
                If MsgBox("Are you sure to delete ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, gsProjectName) = MsgBoxResult.Yes Then
                    'Calling Find Button to select record
                    Call btnFind_Click(sender, e)
                End If
            Else
                If MsgBox("Are you sure to delete this record ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, gsProjectName) = MsgBoxResult.Yes Then

                    Dim id As Integer = Convert.ToInt32(txt)
                    Using cmd As New MySqlCommand("pr_arms_mst_tmicr", gOdbcConn)
                        Call ConOpenOdbc(ServerDetails)
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.Parameters.AddWithValue("?pr_micr_gid", id)
                        cmd.Parameters("?pr_micr_gid").Direction = ParameterDirection.Input
                        cmd.Parameters.AddWithValue("?pr_micr_code", 0)
                        cmd.Parameters("?pr_micr_code").Direction = ParameterDirection.Input
                        cmd.Parameters.AddWithValue("?pr_micr_bank_code", 0)
                        cmd.Parameters("?pr_micr_bank_code").Direction = ParameterDirection.Input
                        cmd.Parameters.AddWithValue("?pr_bank_code", 0)
                        cmd.Parameters("?pr_bank_code").Direction = ParameterDirection.Input
                        cmd.Parameters.AddWithValue("?pr_bank_name", 0)
                        cmd.Parameters("?pr_bank_name").Direction = ParameterDirection.Input
                        cmd.Parameters.AddWithValue("?pr_branch_name", 0)
                        cmd.Parameters("?pr_branch_name").Direction = ParameterDirection.Input
                        cmd.Parameters.AddWithValue("?pr_action", "DELETE")
                        cmd.Parameters("?pr_action").Direction = ParameterDirection.Input
                        'Out put Para
                        cmd.Parameters.Add("?pr_result", MySqlDbType.Int32)
                        cmd.Parameters("?pr_result").Direction = ParameterDirection.Output
                        cmd.Parameters.Add("?pr_err_msg", MySqlDbType.VarChar)
                        cmd.Parameters("?pr_err_msg").Direction = ParameterDirection.Output
                        cmd.ExecuteNonQuery()
                        Call ConCloseOdbc(ServerDetails)
                        Dim res As String = cmd.Parameters("?pr_result").Value.ToString()
                        If (res = 0) Then
                            MsgBox(cmd.Parameters("?pr_err_msg").Value.ToString(), MsgBoxStyle.Critical, gsProjectName)
                        Else
                            MsgBox("Record deleted successfully !", MsgBoxStyle.Information, gsProjectName)
                            Call ClearAll()
                            EnableSave(False)
                            btnNew.Focus()
                        End If
                    End Using

                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Try
            If txtId.Text = "" Then
                If MsgBox("Do you want to edit the record ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, gsProjectName) = MsgBoxResult.Yes Then
                    'Calling Find Button to select record
                    Call btnFind_Click(sender, e)
                    EnableSave(False)
                End If
            Else
                EnableSave(True)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        If MsgBox("Are you sure to close ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, gsProjectName) = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub
End Class