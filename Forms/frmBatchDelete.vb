Imports System.IO
Imports System.IO.FileStream
Imports MySql.Data.MySqlClient
Imports System.Data

Public Class frmBatchDelete

#Region "Local Declaration"
    Dim lnBatchId As Integer
    Dim lnResult As Long
    Dim lnProdFlag As Integer
    Dim lslocCode As String = ""
    Dim ldTotAmount As Double = 0
    Dim lnTotCount As Integer
    Dim lsCycleDate As String = ""
    Dim lnEntityGid As Integer
    Dim cmd As MySqlCommand
    Dim da As MySqlDataAdapter
    Dim dt As DataTable
#End Region

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.       
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If txtBatchId.Text.Trim = "" Then
                MsgBox("Batch Id cannot be empty !", MsgBoxStyle.Critical, gsProjectName)
                txtBatchId.Focus()
            Else

                Dim i As Integer = 0
                If Not Integer.TryParse(txtBatchId.Text, i) Then
                    i = 0
                End If
                lnBatchId = i

                If MsgBox("Do You Want Delete ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
                    Call ConOpenOdbc(ServerDetails)
                    cmd = New MySqlCommand("pr_arms_set_deletebatch", gOdbcConn)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("?pr_batch_gid", lnBatchId)
                    cmd.Parameters("?pr_batch_gid").Direction = ParameterDirection.Input
                    cmd.Parameters.AddWithValue("?pr_action_by", gsLoginUserCode)
                    cmd.Parameters("?pr_action_by").Direction = ParameterDirection.Input
                    ' cmd.ExecuteScalar()
                    Dim res As Integer = cmd.ExecuteNonQuery()
                    Call ConCloseOdbc(ServerDetails)
                    If (res = 0) Then
                        MsgBox("Record deletion failed !", MsgBoxStyle.Information, gsProjectName)
                        Call ControleEnable()
                    Else
                        MsgBox("Record deleted successfully !", MsgBoxStyle.Information, gsProjectName)
                        Call Clear()
                        txtBatchId.Focus()
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Call Clear()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        If MsgBox("Do you want to Close?", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
            MyBase.Close()
        End If
    End Sub

    Private Sub txtBatchId_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBatchId.KeyDown
        If e.KeyCode = Keys.Enter Then

            Dim i As Integer = 0
            If Not Integer.TryParse(txtBatchId.Text, i) Then
                i = 0
            End If
            lnBatchId = i

            cmd = New MySqlCommand("pr_arms_get_batch", gOdbcConn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("?pr_batch_gid", lnBatchId)
            cmd.Parameters("?pr_batch_gid").Direction = ParameterDirection.Input
            dt = New DataTable
            da = New MySqlDataAdapter(cmd)
            da.Fill(dt)

            If (dt.Rows.Count <> 0) Then

                lnEntityGid = dt.Rows(0)("entity_gid")
                lnProdFlag = dt.Rows(0)("prod_flag")
                lsCycleDate = dt.Rows(0)("Cycle Date")
                lslocCode = dt.Rows(0)("Loc Code")
                ldTotAmount = dt.Rows(0)("Totel Amount")
                lnTotCount = dt.Rows(0)("Totel Count")

                gsQry = " select CONCAT(entity_code,'-', entity_name) as EntityCode ,entity_gid from arms_mst_tentity"
                gsQry &= " where delete_flag='N' "
                gsQry &= " order by EntityCode "

                Call gpBindCombo(gsQry, "EntityCode", "entity_gid", cboEntity, gOdbcConn)
                Call PresetSelectedValue(cboEntity, lnEntityGid)

                gsQry = " select CONCAT(prod_code,'-', prod_desc) as ProdCode ,prod_flag from arms_mst_tproduct"
                gsQry &= " where delete_flag='N' "
                gsQry &= " order by prod_desc "
                Call gpBindCombo(gsQry, "ProdCode", "prod_flag", cboProdCode, gOdbcConn)
                Call PresetSelectedValue(cboProdCode, lnProdFlag)

                gsQry = " select loc_name ,loc_code from arms_mst_tlocation"
                gsQry &= " where delete_flag='N' "
                gsQry &= " order by loc_name "
                Call gpBindCombo(gsQry, "loc_name", "loc_code", cboLocCode, gOdbcConn)
                Call PresetSelectedValue(cboLocCode, lslocCode)

                dtpCycleDate.Text = lsCycleDate
                txtTotAmount.Text = ldTotAmount
                txtTotCount.Text = lnTotCount

                Call ControleEnable()

            Else
                MsgBox("Sorry Batch Id Not Matched!")
                Clear()
            End If

        End If
    End Sub

    Private Sub Clear()

        txtBatchId.Enabled = True
        txtBatchId.Text = ""

        cboEntity.Enabled = False
        cboLocCode.Enabled = False
        cboProdCode.Enabled = False
        txtTotCount.Enabled = False
        txtTotAmount.Enabled = False
        dtpCycleDate.Enabled = False

        cboEntity.Text = ""
        cboLocCode.Text = ""
        cboProdCode.Text = ""
        txtTotCount.Text = ""
        txtTotAmount.Text = ""
        dtpCycleDate.Text = ""


        txtBatchId.Focus()

    End Sub

    Private Sub ControleEnable()

        txtBatchId.Enabled = False

        cboEntity.Enabled = False
        cboLocCode.Enabled = False
        cboProdCode.Enabled = False
        txtTotCount.Enabled = False
        dtpCycleDate.Enabled = False
        txtTotAmount.Enabled = False

        btnDelete.Focus()

    End Sub

    Public Sub PresetSelectedValue(ByRef ComboBox As ComboBox, ByVal value As Object)
        Dim item_ndx As Integer

        If ComboBox Is Nothing Then
            '   throw exception?
            Exit Sub
        End If
        With ComboBox
            .Tag = "PresetSelectedValue"
            For item_ndx = 0 To .Items.Count - 1
                .SelectedIndex = item_ndx
                If .SelectedValue = value Then
                    Exit For
                End If
            Next
            If item_ndx >= .Items.Count Then
                .SelectedIndex = -1
            End If
            .Tag = ""
        End With
    End Sub

    Private Sub frmBatchDelete_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Call Clear()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class