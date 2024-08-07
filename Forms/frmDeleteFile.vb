Imports System.IO
Imports System.IO.FileStream
Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Security.Cryptography

Public Class frmDeleteFile

#Region "Local Declaration"
    Dim lnres As Integer
    Dim lnImportFlag As Integer
    Dim lnResult As Long
    Dim fnEntitygid As Integer
    Dim fsFileName As String = ""
    Dim fsImportDate As String = ""
    Dim fnFileType As Integer
    Dim fnFilegid As Integer
#End Region

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If MessageBox.Show("Are you sure to delete ?", gsProjectName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If

        fsImportDate = Format(CDate(dtpDate.Text), "yyyy-MM-dd")
        fnFileType = cboFileType.SelectedValue
        fnEntitygid = cboEntity.SelectedValue
        fnFilegid = cboFileName.SelectedValue

        Using cmd As New MySqlCommand("pr_arms_set_deletefile", gOdbcConn)
            Call ConOpenOdbc(ServerDetails)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("?pr_entity_gid", fnEntitygid)
            cmd.Parameters.AddWithValue("?pr_file_gid", fnFilegid)
            cmd.Parameters.AddWithValue("?pr_file_type", fnFileType)
            cmd.Parameters.AddWithValue("?pr_action_by", gsLoginUserCode)

            'Out put Para
            cmd.Parameters.Add("?pr_result", MySqlDbType.Int32)
            cmd.Parameters("?pr_result").Direction = ParameterDirection.Output
            cmd.Parameters.Add("?pr_msg", MySqlDbType.VarChar)
            cmd.Parameters("?pr_msg").Direction = ParameterDirection.Output
            cmd.ExecuteNonQuery()
            Call ConCloseOdbc(ServerDetails)
            lnres = Val(cmd.Parameters("?pr_result").Value.ToString())
            If (lnres = 0) Then
                MsgBox(cmd.Parameters("?pr_msg").Value.ToString())
                dtpDate.Focus()
            Else
                MsgBox("Record deleted successfully !", MsgBoxStyle.Information, gsProjectName)
                Call ClearAll()
                btnDelete.Focus()
            End If
        End Using

    End Sub

    Private Sub frmDeleteFile_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try

            dtpDate.MaxDate = Date.Today()

            gsQry = " select CONCAT(entity_code,'-', entity_name) as EntityCode ,entity_gid from arms_mst_tentity"
            gsQry &= " where delete_flag='N' "
            gsQry &= " order by entity_name "

            Call gpBindCombo(gsQry, "EntityCode", "entity_gid", cboEntity, gOdbcConn)

            gsQry = " select file_desc ,file_type from arms_mst_tfile"
            gsQry &= " where delete_flag='N' "
            gsQry &= " order by file_desc "

            Call gpBindCombo(gsQry, "file_desc", "file_type", cboFileType, gOdbcConn)

            KeyPreview = True
            dtpDate.Focus()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cboFileName_GotFocus(sender As Object, e As EventArgs) Handles cboFileName.GotFocus
      
        fsImportDate = Format(CDate(dtpDate.Text), "yyyy-MM-dd")
        fnFileType = cboFileType.SelectedValue
        fnEntitygid = cboEntity.SelectedValue
        gsQry = ""
        gsQry &= " select file_gid,file_name from arms_trn_tfile "
        gsQry &= " where entity_gid = " & fnEntitygid & " "
        gsQry &= " and file_type = '" & fnFileType & "'"
        gsQry &= " and DATE_FORMAT(import_date,'%Y-%m-%d')  = '" & fsImportDate & "'"
        gsQry &= " and delete_flag='N' "
        gsQry &= " order by file_name desc "
        Call gpBindCombo(gsQry, "file_name", "file_gid", cboFileName, gOdbcConn)

    End Sub

    Private Sub ClearAll()
        Call frmCtrClear(Me)
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        If MsgBox("Are you sure to close ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, gsProjectName) = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub
End Class