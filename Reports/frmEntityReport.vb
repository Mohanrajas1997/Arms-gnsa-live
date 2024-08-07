Imports System.IO
Imports System.IO.FileStream
Imports MySql.Data.MySqlClient
Imports System.Data

Public Class frmEntityReport

#Region "Local Declaration"

    Dim cmd As MySqlCommand
    Dim da As MySqlDataAdapter
    Dim dt As DataTable
#End Region

    Private Sub btnRefresh_Click(sender As System.Object, e As System.EventArgs) Handles btnRefresh.Click


        cmd = New MySqlCommand("pr_arms_get_entityreport", gOdbcConn)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("?pr_avail_flag", 1)
        cmd.Parameters("?pr_avail_flag").Direction = ParameterDirection.Input
        cmd.ExecuteNonQuery()
        dt = New DataTable
        da = New MySqlDataAdapter(cmd)
        da.Fill(dt)


        dgvReport.DataSource = dt
    End Sub
End Class