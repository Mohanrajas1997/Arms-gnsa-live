Imports System.IO
Imports System.IO.FileStream
Imports MySql.Data.MySqlClient
Imports System.Data

Public Class frmAplobInputDelete

#Region "Local Declaration"
    Dim lnApiId As Integer
    Dim lnResult As Long
    Dim lsIpAddr As String = ""
    Dim lsContractNo As String = ""
    Dim ldChqAmount As Double = 0
    Dim lsChqNo As String = ""
    Dim lsMicrCode As String = ""
    Dim lsAccNo As String = ""
    Dim lsCycleDate As String = ""
    Dim lnEntityGid As Integer
    Dim lsChqDate As String = ""
    Dim cmd As MySqlCommand
    Dim da As MySqlDataAdapter
    Dim dt As DataTable
#End Region

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.       
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            If txtApiId.Text.Trim = "" Then
                MsgBox("API Id cannot be empty !", MsgBoxStyle.Critical, gsProjectName)
                txtApiId.Focus()
            Else
                Dim i As Integer = 0
                If Not Integer.TryParse(txtApiId.Text, i) Then
                    i = 0
                End If
                lnApiId = i
                lsContractNo = txtContractNo.Text
                lsCycleDate = Format(CDate(dtpCycleDate.Text), "yyyy-MM-dd")
                lsChqDate = Format(CDate(dtpChqDate.Text), "yyyy-MM-dd")
                ldChqAmount = Math.Round(Val(txtChqAmount.Text), 2)
                lsChqNo = Mid(Format(Val(QuoteFilter(txtChqNo.Text).ToString), "000000"), 1, 16)
                If Val(lsChqNo) = 0 Then lsChqNo = ""
                lsMicrCode = Mid(Format(Val(QuoteFilter(txtMicrcode.Text).ToString), "000000000"), 1, 16)
                lsAccNo = txtAccNo.Text

                Call ConOpenOdbc(ServerDetails)
                cmd = New MySqlCommand("pr_arms_set_updateaplobinput", gOdbcConn)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("?pr_api_gid", lnApiId)
                cmd.Parameters("?pr_api_gid").Direction = ParameterDirection.Input
                cmd.Parameters.AddWithValue("?pr_contract_no", lsContractNo)
                cmd.Parameters("?pr_contract_no").Direction = ParameterDirection.Input
                cmd.Parameters.AddWithValue("?pr_cycle_date", CDate(lsCycleDate))
                cmd.Parameters("?pr_cycle_date").Direction = ParameterDirection.Input
                cmd.Parameters.AddWithValue("?pr_chq_date", CDate(lsChqDate))
                cmd.Parameters("?pr_chq_date").Direction = ParameterDirection.Input
                cmd.Parameters.AddWithValue("?pr_chq_no", lsChqNo)
                cmd.Parameters("?pr_chq_no").Direction = ParameterDirection.Input
                cmd.Parameters.AddWithValue("?pr_micrcode", lsMicrCode)
                cmd.Parameters("?pr_micrcode").Direction = ParameterDirection.Input
                cmd.Parameters.AddWithValue("?pr_acc_no", lsAccNo)
                cmd.Parameters("?pr_acc_no").Direction = ParameterDirection.Input
                cmd.Parameters.AddWithValue("?pr_chq_amount", ldChqAmount)
                cmd.Parameters("?pr_chq_amount").Direction = ParameterDirection.Input
                cmd.Parameters.AddWithValue("?pr_action_by", gsLoginUserCode)
                cmd.Parameters("?pr_action_by").Direction = ParameterDirection.Input
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
                    Call ControleEnable()
                Else
                    MsgBox("Record updated successfully !", MsgBoxStyle.Information, gsProjectName)
                    Call Clear()
                    lnApiId = 0
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If txtApiId.Text.Trim = "" Then
                MsgBox("API Id cannot be empty !", MsgBoxStyle.Critical, gsProjectName)
                txtApiId.Focus()
            Else

                Dim i As Integer = 0
                If Not Integer.TryParse(txtApiId.Text, i) Then
                    i = 0
                End If
                lnApiId = i

                If MsgBox("Are you sure to delete ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
                    Call ConOpenOdbc(ServerDetails)
                    cmd = New MySqlCommand("pr_arms_set_deleteaplobinput", gOdbcConn)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("?pr_api_gid", lnApiId)
                    cmd.Parameters("?pr_api_gid").Direction = ParameterDirection.Input
                    cmd.Parameters.AddWithValue("?pr_action_by", gsLoginUserCode)
                    cmd.Parameters("?pr_action_by").Direction = ParameterDirection.Input
                    ' cmd.ExecuteScalar()
                    Dim res As Integer = cmd.ExecuteNonQuery()
                    Call ConCloseOdbc(ServerDetails)
                    If (res = 0) Then
                        MsgBox("Access denied !", MsgBoxStyle.Critical, gsProjectName)
                        Call ControleEnable()
                    Else
                        MsgBox("Record deleted successfully !", MsgBoxStyle.Information, gsProjectName)
                        Call Clear()
                        lnApiId = 0
                        txtApiId.Focus()
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
        If MsgBox("Are you sure to close ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
            MyBase.Close()
        End If
    End Sub

    Private Sub txtApiId_KeyDown(sender As Object, e As KeyEventArgs) Handles txtApiId.KeyDown
        If e.KeyCode = Keys.Enter Then

            Dim i As Integer = 0
            If Not Integer.TryParse(txtApiId.Text, i) Then
                i = 0
            End If
            lnApiId = i

            cmd = New MySqlCommand("pr_arms_get_aplobinput", gOdbcConn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("?pr_api_gid", lnApiId)
            cmd.Parameters("?pr_api_gid").Direction = ParameterDirection.Input
            dt = New DataTable
            da = New MySqlDataAdapter(cmd)
            da.Fill(dt)

            If (dt.Rows.Count <> 0) Then

                lnEntityGid = dt.Rows(0)("entity_gid")
                lsContractNo = dt.Rows(0)("contract_no")
                lsCycleDate = dt.Rows(0)("cycle_date")
                lsChqDate = dt.Rows(0)("chq_date")
                ldChqAmount = dt.Rows(0)("chq_amount")
                lsChqNo = dt.Rows(0)("chq_no")
                lsMicrCode = dt.Rows(0)("micr_code")
                lsAccNo = dt.Rows(0)("chq_acc_no")

                gsQry = " select CONCAT(entity_code,'-', entity_name) as EntityCode ,entity_gid from arms_mst_tentity"
                gsQry &= " where delete_flag='N' "
                gsQry &= " order by EntityCode "

                Call gpBindCombo(gsQry, "EntityCode", "entity_gid", cboEntity, gOdbcConn)

                Call PresetSelectedValue(cboEntity, lnEntityGid)

                txtContractNo.Text = lsContractNo
                dtpCycleDate.Text = lsCycleDate
                dtpChqDate.Text = lsChqDate
                txtChqAmount.Text = ldChqAmount
                txtChqNo.Text = lsChqNo
                txtMicrcode.Text = lsMicrCode
                txtAccNo.Text = lsAccNo

                Call ControleEnable()

            Else
                MsgBox("Sorry Aplob Input Id Not Matched !", MsgBoxStyle.Critical, gsProjectName)
                Clear()
            End If

        End If
    End Sub

    Private Sub Clear()

        txtApiId.Enabled = True
        txtApiId.Text = ""

        cboEntity.Enabled = False
        txtContractNo.Enabled = False
        txtChqNo.Enabled = False
        dtpChqDate.Enabled = False
        txtChqAmount.Enabled = False
        dtpCycleDate.Enabled = False
        txtMicrcode.Enabled = False
        txtAccNo.Enabled = False

        cboEntity.Text = ""
        txtContractNo.Text = ""
        txtChqNo.Text = ""
        dtpChqDate.Text = ""
        txtChqAmount.Text = ""
        dtpCycleDate.Text = ""
        txtMicrcode.Text = ""
        txtAccNo.Text = ""

        txtApiId.Focus()

    End Sub

    Private Sub ControleEnable()

        txtApiId.Enabled = False

        cboEntity.Enabled = False
        txtContractNo.Enabled = True
        txtChqNo.Enabled = True
        dtpChqDate.Enabled = True
        dtpCycleDate.Enabled = True
        txtChqAmount.Enabled = True
        txtMicrcode.Enabled = True
        txtAccNo.Enabled = True

        cboEntity.Focus()

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

    Private Sub frmAplobInputDelete_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Call Clear()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class