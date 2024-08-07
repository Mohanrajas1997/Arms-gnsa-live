Imports System.IO
Imports System.IO.FileStream
Imports MySql.Data.MySqlClient
Imports System.Data

Public Class frmGenerateBatch

#Region "Local Declaration"
    Dim lnResult As Long
    Dim lsIpAddr As String = ""
    Dim lsCycleDate As String = ""
    Dim lnEntityGid As Integer
    Dim lsLocCode As String = ""
    Dim lnProdFlag As Integer
    Dim lsTxt As String
    Dim cmd As MySqlCommand
    Dim da As MySqlDataAdapter
    Dim ds As DataSet
#End Region

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.       
    End Sub

    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        Try
            lnEntityGid = cboEntity.SelectedValue
            lsCycleDate = Format(CDate(dtpCycleDate.Text), "yyyy-MM-dd")
            lnProdFlag = cboProdcode.SelectedValue
            lsLocCode = cboLocCode.SelectedValue
            lsIpAddr = IPAddresses("")

            Call ConOpenOdbc(ServerDetails)
            cmd = New MySqlCommand("pr_arms_set_generatebatch", gOdbcConn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("?pr_entity_gid", lnEntityGid)
            cmd.Parameters("?pr_entity_gid").Direction = ParameterDirection.Input
            cmd.Parameters.AddWithValue("?pr_cycle_date", CDate(lsCycleDate))
            cmd.Parameters("?pr_cycle_date").Direction = ParameterDirection.Input
            cmd.Parameters.AddWithValue("?pr_prod_flag", lnProdFlag)
            cmd.Parameters("?pr_prod_flag").Direction = ParameterDirection.Input
            cmd.Parameters.AddWithValue("?pr_loc_code", lsLocCode)
            cmd.Parameters("?pr_loc_code").Direction = ParameterDirection.Input
            cmd.Parameters.AddWithValue("?pr_system_ip", lsIpAddr)
            cmd.Parameters("?pr_system_ip").Direction = ParameterDirection.Input
            cmd.Parameters.AddWithValue("?pr_action_by", gsLoginUserCode)
            cmd.Parameters("?pr_action_by").Direction = ParameterDirection.Input          
            'Out put Para
            cmd.Parameters.Add("?pr_result", MySqlDbType.Int32)
            cmd.Parameters("?pr_result").Direction = ParameterDirection.Output
            cmd.Parameters.Add("?pr_msg", MySqlDbType.VarChar)
            cmd.Parameters("?pr_msg").Direction = ParameterDirection.Output
            cmd.ExecuteNonQuery()
            Call ConCloseOdbc(ServerDetails)
            Dim res As Long = Val(cmd.Parameters("?pr_result").Value.ToString())
            If (res = 0) Then
                MsgBox("Batch Id : " & res.ToString & Chr(13) & Chr(10) & cmd.Parameters("?pr_msg").Value.ToString(), MsgBoxStyle.Information, gsProjectName)
                dtpCycleDate.Focus()
            Else
                MsgBox(cmd.Parameters("?pr_msg").Value.ToString())
                cboEntity.Text = ""
                cboLocCode.Text = ""
                cboProdcode.Text = ""
                dtpCycleDate.Focus()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnCloss_Click(sender As Object, e As EventArgs) Handles btnCloss.Click
        If MsgBox("Do you want to Close?", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
            MyBase.Close()
        End If
    End Sub

    Private Sub frmGenerateBatch_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            'dtpCycleDate.MaxDate = Date.Today()

            gsQry = " select CONCAT(entity_code,'-', entity_name) as EntityCode ,entity_gid from arms_mst_tentity"
            gsQry &= " where delete_flag='N' "
            gsQry &= " order by entity_name "
            Call gpBindCombo(gsQry, "EntityCode", "entity_gid", cboEntity, gOdbcConn)

            gsQry = " select CONCAT(prod_code,'-', prod_desc) as ProdCode ,prod_flag from arms_mst_tproduct"
            gsQry &= " where delete_flag='N' "
            gsQry &= " order by prod_desc "
            Call gpBindCombo(gsQry, "ProdCode", "prod_flag", cboProdcode, gOdbcConn)

            gsQry = " select loc_name ,loc_code from arms_mst_tlocation"
            gsQry &= " where delete_flag='N' "
            gsQry &= " order by loc_name "
            Call gpBindCombo(gsQry, "loc_name", "loc_code", cboLocCode, gOdbcConn)


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class