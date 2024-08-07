Imports System.IO
Imports System.IO.FileStream
Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Security.Cryptography

Public Class frmPostFile

#Region "Local Declaration"
    Dim lnres As Integer
    Dim lnImportFlag As Integer
    Dim lnResult As Long
    Dim fnEntitygid As Integer
    Dim fsFileName As String = ""
    Dim fsImportDateFrom As String = ""
    Dim fsImportDateTo As String = ""
    Dim fnFileType As String = ""
    Dim fnFilegid As Integer
    Dim cmd As MySqlCommand
#End Region

    Private Sub btnPost_Click(sender As Object, e As EventArgs) Handles btnPost.Click
        If MessageBox.Show("Are you sure to post ?", gsProjectName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
            dtpDateFrom.Focus()
            Exit Sub
        End If

        btnPost.Enabled = False
        Me.Cursor = Cursors.WaitCursor

        Try
            fnFilegid = cboFileName.SelectedValue
            fnFileType = cboFileType.Text
            If fnFileType = "" Then
                MsgBox("Please select file type !", MsgBoxStyle.Information, gsProjectName)
            Else
                Select Case fnFileType
                    Case "Aplob Input"
                        Call ConOpenOdbc(ServerDetails)
                        cmd = New MySqlCommand("pr_arms_set_postAplobInput", gOdbcConn)
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.Parameters.AddWithValue("?pr_file_gid", fnFilegid)
                        cmd.Parameters("?pr_file_gid").Direction = ParameterDirection.Input
                        'Out put Para
                        cmd.Parameters.Add("?pr_result", MySqlDbType.Int32)
                        cmd.Parameters("?pr_result").Direction = ParameterDirection.Output
                        cmd.Parameters.Add("?pr_msg", MySqlDbType.VarChar)
                        cmd.Parameters("?pr_msg").Direction = ParameterDirection.Output

                        cmd.CommandTimeout = 0
                        cmd.ExecuteNonQuery()
                        Call ConCloseOdbc(ServerDetails)
                        lnres = Val(cmd.Parameters("?pr_result").Value.ToString())
                        If (lnres = 0) Then
                            MsgBox(cmd.Parameters("?pr_msg").Value.ToString())
                            dtpDateFrom.Focus()
                        Else
                            MsgBox(cmd.Parameters("?pr_msg").Value.ToString())
                            'MsgBox("Record updated successfully !", MsgBoxStyle.Information, gsProjectName)
                            Call ClearAll()
                            btnPost.Focus()
                        End If
                    Case "Pullout"
                        Call ConOpenOdbc(ServerDetails)
                        cmd = New MySqlCommand("pr_arms_set_postpullout", gOdbcConn)
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.Parameters.AddWithValue("?pr_file_gid", fnFilegid)
                        cmd.Parameters("?pr_file_gid").Direction = ParameterDirection.Input
                        'Out put Para
                        cmd.Parameters.Add("?pr_result", MySqlDbType.Int32)
                        cmd.Parameters("?pr_result").Direction = ParameterDirection.Output
                        cmd.Parameters.Add("?pr_msg", MySqlDbType.VarChar)
                        cmd.Parameters("?pr_msg").Direction = ParameterDirection.Output

                        cmd.CommandTimeout = 0
                        cmd.ExecuteNonQuery()
                        Call ConCloseOdbc(ServerDetails)
                        lnres = Val(cmd.Parameters("?pr_result").Value.ToString())
                        If (lnres = 0) Then
                            MsgBox(cmd.Parameters("?pr_msg").Value.ToString())
                            dtpDateFrom.Focus()
                        Else
                            'MsgBox("Record updated successfully !", MsgBoxStyle.Information, gsProjectName)
                            MsgBox(cmd.Parameters("?pr_msg").Value.ToString())
                            Call ClearAll()
                            btnPost.Focus()
                        End If
                    Case "Presentation"
                        Call ConOpenOdbc(ServerDetails)
                        cmd = New MySqlCommand("pr_arms_set_postRplob", gOdbcConn)
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.Parameters.AddWithValue("?pr_file_gid", fnFilegid)
                        cmd.Parameters("?pr_file_gid").Direction = ParameterDirection.Input
                        'Out put Para
                        cmd.Parameters.Add("?pr_result", MySqlDbType.Int32)
                        cmd.Parameters("?pr_result").Direction = ParameterDirection.Output
                        cmd.Parameters.Add("?pr_msg", MySqlDbType.VarChar)
                        cmd.Parameters("?pr_msg").Direction = ParameterDirection.Output

                        cmd.CommandTimeout = 0
                        cmd.ExecuteNonQuery()
                        Call ConCloseOdbc(ServerDetails)
                        lnres = Val(cmd.Parameters("?pr_result").Value.ToString())
                        If (lnres = 0) Then
                            MsgBox(cmd.Parameters("?pr_msg").Value.ToString())
                            dtpDateFrom.Focus()
                        Else
                            ' MsgBox("Record updated successfully !", MsgBoxStyle.Information, gsProjectName)
                            MsgBox(cmd.Parameters("?pr_msg").Value.ToString())
                            Call ClearAll()
                            btnPost.Focus()
                        End If
                End Select
            End If

            btnPost.Enabled = True
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Call frmCtrClear(Me)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        If MsgBox("Are you sure to close ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, gsProjectName) = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub frmPostFile_Load(sender As Object, e As EventArgs) Handles Me.Load

        Try
            dtpDateFrom.MaxDate = Date.Today()
            dtpImportTo.MaxDate = Date.Today()
            gsQry = " select CONCAT(entity_code,'-', entity_name) as EntityCode ,entity_gid from arms_mst_tentity"
            gsQry &= " where delete_flag='N' "
            gsQry &= " order by entity_name "
            Call gpBindCombo(gsQry, "EntityCode", "entity_gid", cboEntity, gOdbcConn)

            cboFileType.Items.Add("Aplob Input")
            cboFileType.Items.Add("Presentation")
            cboFileType.Items.Add("Pullout")
            KeyPreview = True

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub ClearAll()
        Call frmCtrClear(Me)
    End Sub

    Private Sub cboFileName_GotFocus(sender As Object, e As EventArgs) Handles cboFileName.GotFocus

        Try
            fsImportDateFrom = Format(CDate(dtpDateFrom.Text), "yyyy-MM-dd")
            fsImportDateTo = Format(CDate(dtpImportTo.Text), "yyyy-MM-dd")
            fnFileType = cboFileType.Text
            fnEntitygid = cboEntity.SelectedValue

            gsQry = ""
            gsQry &= " select file_gid,concat(file_name,' ',ifnull(sheet_name,'')) as file_name from arms_trn_tfile "
            gsQry &= " where entity_gid = " & fnEntitygid & " "
            gsQry &= " and file_type = (select file_type from arms_mst_tfile where file_desc= '" & fnFileType & "')"
            gsQry &= " and DATE_FORMAT(import_date,'%Y-%m-%d')  between '" & fsImportDateFrom & "' and '" & fsImportDateTo & "'"
            gsQry &= " and delete_flag='N' "
            gsQry &= " order by file_name desc "
            Call gpBindCombo(gsQry, "file_name", "file_gid", cboFileName, gOdbcConn)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

End Class