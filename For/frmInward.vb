Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Data
Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class frmInward

#Region "Local Declaration"
    Dim msSql As String
    Dim mnResult As Integer
#End Region

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.       
    End Sub

    Private Sub EnableSave(ByVal Status As Boolean)
        pnlButtons.Visible = Not Status
        pnlSave.Visible = Status
        pnlMain.Enabled = Status
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Call EnableSave(True)
        Call ClearAll()
        cboEntity.Focus()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Try
            If txtId.Text = "" Then
                If MsgBox("Select Record to edit", MsgBoxStyle.YesNo, gsProjectName) = MsgBoxResult.Yes Then
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

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        Select Case ""
            Case cboEntity.Text
                MsgBox("Entity cannot be empty !", MsgBoxStyle.Critical, gsProjectName)
                cboEntity.Focus()
                Exit Sub
            Case dpReceivedDate.Text
                MsgBox("ReceivedDate cannot be empty !", MsgBoxStyle.Critical, gsProjectName)
                dpReceivedDate.Focus()
                Exit Sub
            Case Format(CDate(dpReceivedDate.Value), "yyyy-MM-dd") > Format(CDate(Date.Today), "yyyy-MM-dd")
                MsgBox("ReceivedDate Invalied !", MsgBoxStyle.Critical, gsProjectName)
                dpReceivedDate.Focus()
                Exit Sub
            Case cboReceivedBy.Text
                MsgBox("ReceivedBy cannot be empty !", MsgBoxStyle.Critical, gsProjectName)
                cboReceivedBy.Focus()
                Exit Sub
            Case cboCourier.Text
                MsgBox("Courier cannot be empty !", MsgBoxStyle.Critical, gsProjectName)
                cboCourier.Focus()
                Exit Sub
            Case txtAWBNo.Text
                MsgBox("AWBNo cannot be empty !", MsgBoxStyle.Critical, gsProjectName)
                txtAWBNo.Focus()
                Exit Sub
            
        End Select

        If txtId.Text.Trim = "" Then

            Dim entity As String = cboEntity.SelectedValue
            Dim receiveddate As String = Format(CDate(dpReceivedDate.Value), "yyyy-MM-dd")
            Dim receivedby As String = cboReceivedBy.Text
            Dim courier As String = cboCourier.SelectedValue
            Dim awbno As String = txtAWBNo.Text
            Dim remark As String = txtRemark.Text

            Using cmd As New MySqlCommand("pr_arms_trn_tinward", gOdbcConn)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add("?pr_inward_gid", 0)
                cmd.Parameters("?pr_inward_gid").Direction = ParameterDirection.Input
                cmd.Parameters.Add("?pr_entity_gid", entity)
                cmd.Parameters("?pr_entity_gid").Direction = ParameterDirection.Input
                cmd.Parameters.Add("?pr_received_date", receiveddate)
                cmd.Parameters("?pr_received_date").Direction = ParameterDirection.Input
                cmd.Parameters.Add("?pr_received_by", receivedby)
                cmd.Parameters("?pr_received_by").Direction = ParameterDirection.Input
                cmd.Parameters.Add("?pr_courier_gid", courier)
                cmd.Parameters("?pr_courier_gid").Direction = ParameterDirection.Input
                cmd.Parameters.Add("?pr_awb_no", awbno)
                cmd.Parameters("?pr_awb_no").Direction = ParameterDirection.Input
                cmd.Parameters.Add("?pr_inward_remark", remark)
                cmd.Parameters("?pr_inward_remark").Direction = ParameterDirection.Input
                cmd.Parameters.Add("?pr_action", "INSERT")
                cmd.Parameters("?pr_action").Direction = ParameterDirection.Input
                'gsActionBy is global variables
                cmd.Parameters.Add("?pr_action_by", gsActionBy)
                cmd.Parameters("?pr_action_by").Direction = ParameterDirection.Input
                'Out put Para
                cmd.Parameters.Add("?pr_result", MySqlDbType.Int32)
                cmd.Parameters("?pr_result").Direction = ParameterDirection.Output
                cmd.Parameters.Add("?pr_err_msg", MySqlDbType.VarChar)
                cmd.Parameters("?pr_err_msg").Direction = ParameterDirection.Output
                cmd.ExecuteNonQuery()
                Dim res As String = cmd.Parameters("?pr_result").Value.ToString()
                If (res = 0) Then
                    MsgBox(cmd.Parameters("?pr_err_msg").Value.ToString())
                    cboEntity.Focus()
                Else
                    MsgBox(cmd.Parameters("?pr_result").Value.ToString() + Name + " " + "Recard Update Successfully !")
                    Call ClearAll()
                    EnableSave(False)
                    btnNew.Focus()
                End If
            End Using
        Else
            ' Update rack
            Dim id As Integer = Convert.ToInt32(txt)
            Dim entity As String = cboEntity.SelectedValue
            Dim receiveddate As String = Format(CDate(dpReceivedDate.Value), "yyyy-MM-dd")
            Dim receivedby As String = cboReceivedBy.Text
            Dim courier As String = cboCourier.SelectedValue
            Dim awbno As String = txtAWBNo.Text
            Dim remark As String = txtRemark.Text
            Using cmd As New MySqlCommand("pr_arms_trn_tinward", gOdbcConn)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add("?pr_inward_gid", id)
                cmd.Parameters("?pr_inward_gid").Direction = ParameterDirection.Input
                cmd.Parameters.Add("?pr_entity_gid", entity)
                cmd.Parameters("?pr_entity_gid").Direction = ParameterDirection.Input
                cmd.Parameters.Add("?pr_received_date", receiveddate)
                cmd.Parameters("?pr_received_date").Direction = ParameterDirection.Input
                cmd.Parameters.Add("?pr_received_by", receivedby)
                cmd.Parameters("?pr_received_by").Direction = ParameterDirection.Input
                cmd.Parameters.Add("?pr_courier_gid", courier)
                cmd.Parameters("?pr_courier_gid").Direction = ParameterDirection.Input
                cmd.Parameters.Add("?pr_awb_no", awbno)
                cmd.Parameters("?pr_awb_no").Direction = ParameterDirection.Input
                cmd.Parameters.Add("?pr_inward_remark", remark)
                cmd.Parameters("?pr_inward_remark").Direction = ParameterDirection.Input
                cmd.Parameters.Add("?pr_action", "UPDATE")
                cmd.Parameters("?pr_action").Direction = ParameterDirection.Input
                'gsActionBy is global variables
                cmd.Parameters.Add("?pr_action_by", gsActionBy)
                cmd.Parameters("?pr_action_by").Direction = ParameterDirection.Input
                'Out put Para
                cmd.Parameters.Add("?pr_result", MySqlDbType.Int32)
                cmd.Parameters("?pr_result").Direction = ParameterDirection.Output
                cmd.Parameters.Add("?pr_err_msg", MySqlDbType.VarChar)
                cmd.Parameters("?pr_err_msg").Direction = ParameterDirection.Output
                cmd.ExecuteNonQuery()
                Dim res As String = cmd.Parameters("?pr_result").Value.ToString()
                If (res = 0) Then
                    MsgBox(cmd.Parameters("?pr_err_msg").Value.ToString())
                    cboEntity.Focus()
                Else
                    MsgBox(cmd.Parameters("?pr_result").Value.ToString() + " " + "Recard Update Successfully !")
                    Call ClearAll()
                    EnableSave(False)
                    btnNew.Focus()
                End If
            End Using
        End If

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If txtId.Text = "" Then
                If MsgBox("Select record to delete?", MsgBoxStyle.YesNo, gsProjectName) = MsgBoxResult.Yes Then
                    'Calling Find Button to select record
                    Call btnFind_Click(sender, e)
                End If
            Else
                If MsgBox("Are you sure to delete this record?", MsgBoxStyle.YesNo, gsProjectName) = MsgBoxResult.Yes Then

                    Dim id As Integer = Convert.ToInt32(txt)
                    Using cmd As New MySqlCommand("pr_arms_trn_tinward", gOdbcConn)
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.Parameters.Add("?pr_inward_gid", id)
                        cmd.Parameters("?pr_inward_gid").Direction = ParameterDirection.Input
                        cmd.Parameters.Add("?pr_entity_gid", 0)
                        cmd.Parameters("?pr_entity_gid").Direction = ParameterDirection.Input
                        cmd.Parameters.Add("?pr_received_date", 0)
                        cmd.Parameters("?pr_received_date").Direction = ParameterDirection.Input
                        cmd.Parameters.Add("?pr_received_by", 0)
                        cmd.Parameters("?pr_received_by").Direction = ParameterDirection.Input
                        cmd.Parameters.Add("?pr_courier_gid", 0)
                        cmd.Parameters("?pr_courier_gid").Direction = ParameterDirection.Input
                        cmd.Parameters.Add("?pr_awb_no", 0)
                        cmd.Parameters("?pr_awb_no").Direction = ParameterDirection.Input
                        cmd.Parameters.Add("?pr_inward_remark", 0)
                        cmd.Parameters("?pr_inward_remark").Direction = ParameterDirection.Input
                        cmd.Parameters.Add("?pr_action", "DELETE")
                        cmd.Parameters("?pr_action").Direction = ParameterDirection.Input
                        'gsActionBy is global variables
                        cmd.Parameters.Add("?pr_action_by", gsActionBy)
                        cmd.Parameters("?pr_action_by").Direction = ParameterDirection.Input
                        'Out put Para
                        cmd.Parameters.Add("?pr_result", MySqlDbType.Int32)
                        cmd.Parameters("?pr_result").Direction = ParameterDirection.Output
                        cmd.Parameters.Add("?pr_err_msg", MySqlDbType.VarChar)
                        cmd.Parameters("?pr_err_msg").Direction = ParameterDirection.Output
                        cmd.ExecuteNonQuery()
                        Dim res As String = cmd.Parameters("?pr_result").Value.ToString()
                        If (res = 0) Then
                            MsgBox(cmd.Parameters("?pr_err_msg").Value.ToString())
                        Else
                            MsgBox(cmd.Parameters("?pr_result").Value.ToString() + " " + "Recard Delete Successfully!!!")
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

    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
        Dim SearchDialog As frmSearch

        Try
            SearchDialog = New frmSearch(gOdbcConn, _
                             " SELECT inward_gid as 'Inward Id'," & _
                             " entity_name as 'Entity Name',courier_name as 'Courier Name',received_by as 'Received By',received_date as 'Received Date',awb_no as 'AWB NO',inward_remark as 'Inward Remark' FROM arms_trn_vinward ", _
                             " inward_gid,entity_name,courier_name,received_by,received_date,awb_no,inward_remark", _
                             " 1 = 1 and delete_flag = 'N'")
            SearchDialog.ShowDialog()

            If Val(txt) <> 0 Then
                Call ListAll("select * from arms_trn_vinward " _
                    & " where inward_gid = " & txt & " " _
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
                    txtId.Text = .Rows(0).Item("inward_gid").ToString
                    cboEntity.Text = .Rows(0).Item("entity_name").ToString
                    dpReceivedDate.Text = .Rows(0).Item("received_date").ToString
                    cboReceivedBy.Text = .Rows(0).Item("received_by").ToString
                    cboCourier.Text = .Rows(0).Item("courier_name").ToString
                    txtAWBNo.Text = .Rows(0).Item("awb_no").ToString
                    txtRemark.Text = .Rows(0).Item("inward_remark").ToString

                Else
                    ClearAll()
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Call frmCtrClear(Me)
        Call EnableSave(False)
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        If MsgBox("Are you sure to close ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, gsProjectName) = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub ClearAll()
        Call frmCtrClear(Me)
    End Sub

    Private Sub frmInward_Load(sender As Object, e As EventArgs) Handles Me.Load

        Try
            gsQry = " select entity_gid, entity_name from arms_mst_tentity"
            gsQry &= " where delete_flag='N' "
            gsQry &= " order by entity_name "

            Call gpBindCombo(gsQry, "entity_name", "entity_gid", cboEntity, gOdbcConn)

            gsQry = " select user_gid, user_code from soft_mst_tuser"
            gsQry &= " where delete_flag='N' "
            gsQry &= " order by user_code "

            Call gpBindCombo(gsQry, "user_code", "user_gid", cboReceivedBy, gOdbcConn)

            gsQry = " select courier_gid, courier_name from arms_mst_tcourier"
            gsQry &= " where delete_flag='N' "
            gsQry &= " order by courier_name "

            Call gpBindCombo(gsQry, "courier_name", "courier_gid", cboCourier, gOdbcConn)
            KeyPreview = True
            Call EnableSave(False)
            dpReceivedDate.MaxDate = Date.Today()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class



