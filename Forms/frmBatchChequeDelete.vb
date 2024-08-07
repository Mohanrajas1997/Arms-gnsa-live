Imports System.IO
Imports System.IO.FileStream
Imports MySql.Data.MySqlClient
Imports System.Data

Public Class frmBatchChequeDelete

#Region "Local Declaration"
    Dim lnChqId As Integer
    Dim lnBatchGid As Integer
    Dim lnResult As Long
    Dim lsContractNo As String = ""
    Dim lsChqDate As String = ""
    Dim ldChqAmount As Double = 0
    Dim lsChqNo As String = ""
    Dim lsCycleDate As String = ""
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
            If txtChqId.Text.Trim = "" Then
                MsgBox("Batch Id cannot be empty !", MsgBoxStyle.Critical, gsProjectName)
                txtChqId.Focus()
            Else

                Dim i As Integer = 0
                If Not Integer.TryParse(txtChqId.Text, i) Then
                    i = 0
                End If
                lnChqId = i

                If MsgBox("Do You Want Delete ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then

                    Call ConOpenOdbc(ServerDetails)
                    cmd = New MySqlCommand("pr_arms_set_deletebatchcheque", gOdbcConn)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("?pr_chq_gid", lnChqId)
                    cmd.Parameters("?pr_chq_gid").Direction = ParameterDirection.Input
                    cmd.Parameters.AddWithValue("?pr_action_by", gsLoginUserCode)
                    cmd.Parameters("?pr_action_by").Direction = ParameterDirection.Input
                    ' cmd.ExecuteScalar()
                    Dim res As Integer = cmd.ExecuteNonQuery()
                    Call ConCloseOdbc(ServerDetails)
                    If (res = 0) Then
                        MsgBox("Record deletion failed !")
                        Call ControleEnable()
                    Else
                        MsgBox("Record deleted Successfully !")
                        Call Clear()
                        txtChqId.Focus()
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

    Private Sub txtChqId_KeyDown(sender As Object, e As KeyEventArgs) Handles txtChqId.KeyDown
        If e.KeyCode = Keys.Enter Then

            Dim i As Integer = 0
            If Not Integer.TryParse(txtChqId.Text, i) Then
                i = 0
            End If
            lnChqId = i

            cmd = New MySqlCommand("pr_arms_get_batchcheque", gOdbcConn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("?pr_chq_gid", lnChqId)
            cmd.Parameters("?pr_chq_gid").Direction = ParameterDirection.Input
            dt = New DataTable
            da = New MySqlDataAdapter(cmd)
            da.Fill(dt)

            If (dt.Rows.Count <> 0) Then

                lnBatchGid = dt.Rows(0)("batch_gid")
                lsContractNo = dt.Rows(0)("contract_no")
                lsCycleDate = dt.Rows(0)("cycle_date")
                lsChqDate = dt.Rows(0)("chq_date")
                lsChqNo = dt.Rows(0)("chq_no")
                ldChqAmount = dt.Rows(0)("chq_amount")

                txtBatchId.Text = lnBatchGid
                txtContractNo.Text = lsContractNo
                dtpCycleDate.Text = lsCycleDate
                dtpChqDate.Text = lsChqDate
                txtChqNo.Text = lsChqNo
                txtChqAmount.Text = ldChqAmount
                Call ControleEnable()

            Else
                MsgBox("Sorry Chq Id Not Matched!")
                Clear()
            End If

        End If
    End Sub

    Private Sub Clear()

        txtChqId.Enabled = True
        txtChqId.Text = ""

        txtBatchId.Enabled = False
        txtContractNo.Enabled = False
        dtpCycleDate.Enabled = False
        dtpChqDate.Enabled = False
        txtChqAmount.Enabled = False
        txtChqNo.Enabled = False


        txtBatchId.Text = ""
        txtContractNo.Text = ""
        dtpCycleDate.Text = ""
        dtpChqDate.Text = ""
        txtChqAmount.Text = ""
        txtChqNo.Text = ""


        txtChqId.Focus()

    End Sub

    Private Sub ControleEnable()

        txtBatchId.Enabled = False

        txtBatchId.Enabled = False
        txtContractNo.Enabled = False
        dtpCycleDate.Enabled = False
        dtpChqDate.Enabled = False
        txtChqAmount.Enabled = False
        txtChqNo.Enabled = False

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

    Private Sub frmBatchChequeDelete_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Call Clear()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class