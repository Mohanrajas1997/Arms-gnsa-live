Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Data
Imports MySql.Data
Imports MySql.Data.MySqlClient
Public Class frmDispatch

#Region "Local Declaration"
    Dim msSql As String
    Dim mnResult As Integer
    Dim cmd As MySqlCommand
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
        PnlPullout.Enabled = Status
    End Sub

    Private Sub btnNew_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnNew.Click
        Call EnableSave(True)
        Call ClearAll()
        cboEntity.Focus()
        txt_id = 0
    End Sub

    Private Sub btnEdit_Click(ByVal sender As Object, ByVal e As EventArgs)
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

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click

        Dim lnDispatchEntityId As Long = 0
        Dim lnEntityId As Long = 0
        Dim n As Integer
        Dim lnChklstValue As Long = 0
        Dim lnPullOutId As Long = 0
        Dim lnEntitygid As Long = 0
        Dim lsAvailableFlag As String
        Dim res As Integer = 0
        Dim DispatchId As Integer = 0

        Select Case ""

            Case cboEntity.Text
                MsgBox("Entity cannot be empty !", MsgBoxStyle.Critical, gsProjectName)
                cboEntity.Focus()
                Exit Sub
            Case CboCourierName.Text
                MsgBox("Courier Name cannot be empty !", MsgBoxStyle.Critical, gsProjectName)
                CboCourierName.Focus()
                Exit Sub
            Case txtDispatchAddr.Text
                MsgBox("Dispatch Addr cannot be empty !", MsgBoxStyle.Critical, gsProjectName)
                txtDispatchAddr.Focus()
                Exit Sub
            Case txtDispatchBy.Text
                MsgBox("Dispatch By cannot be empty !", MsgBoxStyle.Critical, gsProjectName)
                txtDispatchBy.Focus()
                Exit Sub
            Case TxtAwbNo.Text
                MsgBox("AWB No cannot be empty !", MsgBoxStyle.Critical, gsProjectName)
                TxtAwbNo.Focus()
                Exit Sub

        End Select

        lnEntityId = QuoteFilter(CboPulloutEntity.SelectedValue.ToString)
        lnDispatchEntityId = QuoteFilter(cboEntity.SelectedValue.ToString)

        If lnEntityId <> lnDispatchEntityId Then
            MsgBox("Entity Name Not Matched!", MsgBoxStyle.Critical, gsProjectName)
            Exit Sub
        End If

        If txtId.Text.Trim = "" Then
            Dim DispatchDate As String = Format(CDate(DtpDispatchDt.Text), "yyyy-MM-dd")
            Dim entity As String = cboEntity.SelectedValue
            Dim DispatchType_st As String = "P"
            Dim CourierGid As String = CboCourierName.SelectedValue
            Dim AwbNo As String = TxtAwbNo.Text
            Dim DispatchAddr As String = txtDispatchAddr.Text
            Dim DispatchBy As String = txtDispatchBy.Text
            Dim Remarks As String = txtRemarks.Text



            Call ConOpenOdbc(ServerDetails)
            cmd = New MySqlCommand("pr_arms_trn_tdispatch", gOdbcConn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("?pr_dispatch_gid", 0)
            cmd.Parameters("?pr_dispatch_gid").Direction = ParameterDirection.Input
            cmd.Parameters.AddWithValue("?pr_entity_gid", entity)
            cmd.Parameters("?pr_entity_gid").Direction = ParameterDirection.Input
            cmd.Parameters.AddWithValue("?pr_dispatch_date", DispatchDate)
            cmd.Parameters("?pr_dispatch_date").Direction = ParameterDirection.Input
            cmd.Parameters.AddWithValue("?pr_dispatch_type", DispatchType_st)
            cmd.Parameters("?pr_dispatch_type").Direction = ParameterDirection.Input
            cmd.Parameters.AddWithValue("?pr_courier_gid", CourierGid)
            cmd.Parameters("?pr_courier_gid").Direction = ParameterDirection.Input
            cmd.Parameters.AddWithValue("?pr_awb_no", AwbNo)
            cmd.Parameters("?pr_awb_no").Direction = ParameterDirection.Input
            cmd.Parameters.AddWithValue("?pr_dispatch_addr", DispatchAddr)
            cmd.Parameters("?pr_dispatch_addr").Direction = ParameterDirection.Input
            cmd.Parameters.AddWithValue("?pr_dispatch_by", DispatchBy)
            cmd.Parameters("?pr_dispatch_by").Direction = ParameterDirection.Input
            cmd.Parameters.AddWithValue("?pr_dispatch_remark", Remarks)
            cmd.Parameters("?pr_dispatch_remark").Direction = ParameterDirection.Input
            'gsLoginUserCode is global variables
            cmd.Parameters.AddWithValue("?pr_action_by", gsLoginUserCode)
            cmd.Parameters("?pr_action_by").Direction = ParameterDirection.Input
            cmd.Parameters.AddWithValue("?pr_action", "INSERT")
            cmd.Parameters("?pr_action").Direction = ParameterDirection.Input
            'Out put Para
            cmd.Parameters.Add("?pr_result", MySqlDbType.Int32)
            cmd.Parameters("?pr_result").Direction = ParameterDirection.Output
            cmd.Parameters.Add("?pr_err_msg", MySqlDbType.VarChar)
            cmd.Parameters("?pr_err_msg").Direction = ParameterDirection.Output
            cmd.ExecuteNonQuery()
            Call ConCloseOdbc(ServerDetails)
            res = Val(cmd.Parameters("?pr_result").Value.ToString())
            DispatchId = Val(cmd.Parameters("?pr_result").Value.ToString())

            If (res = 0) Then
                MsgBox(cmd.Parameters("?pr_err_msg").Value.ToString())
                cboEntity.Focus()
            Else

                With dgvReport
                    n = .Columns.Count - 1
                    For i = 0 To .Rows.Count - 1

                        lnChklstValue = .Rows(i).Cells("pullout_gid").Value
                        lnEntityId = .Rows(i).Cells("entity_gid").Value
                        lnPullOutId = 0
                        lnPullOutId = lnChklstValue

                        If .Rows(i).Cells(n).Value = True Then
                            lsAvailableFlag = "Y"
                        Else
                            lsAvailableFlag = "N"
                        End If

                        Call ConOpenOdbc(ServerDetails)
                        cmd = New MySqlCommand("pr_arms_set_tpullout", gOdbcConn)
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.Parameters.AddWithValue("?pr_pullout_gid", lnPullOutId)
                        cmd.Parameters("?pr_pullout_gid").Direction = ParameterDirection.Input
                        cmd.Parameters.AddWithValue("?pr_entity_gid", lnEntityId)
                        cmd.Parameters("?pr_entity_gid").Direction = ParameterDirection.Input
                        cmd.Parameters.AddWithValue("?pr_dispatch_gid", DispatchId)
                        cmd.Parameters("?pr_dispatch_gid").Direction = ParameterDirection.Input
                        cmd.Parameters.AddWithValue("?pr_available_flag", lsAvailableFlag)
                        cmd.Parameters("?pr_available_flag").Direction = ParameterDirection.Input
                        cmd.Parameters.AddWithValue("?pr_form_name", "DISPATCH")
                        cmd.Parameters("?pr_form_name").Direction = ParameterDirection.Input
                        cmd.Parameters.AddWithValue("?pr_action_by", gsLoginUserCode)
                        cmd.Parameters("?pr_action_by").Direction = ParameterDirection.Input
                        cmd.Parameters.AddWithValue("?pr_action", "UPDATE")
                        cmd.Parameters("?pr_action").Direction = ParameterDirection.Input
                        'out put Para
                        cmd.Parameters.Add("?pr_result", MySqlDbType.Int32)
                        cmd.Parameters("?pr_result").Direction = ParameterDirection.Output
                        cmd.Parameters.Add("?pr_err_msg", MySqlDbType.VarChar)
                        cmd.Parameters("?pr_err_msg").Direction = ParameterDirection.Output
                        cmd.ExecuteNonQuery()
                        Call ConCloseOdbc(ServerDetails)
                        res = Val(cmd.Parameters("?pr_result").Value.ToString())
                        If (res = 0) Then
                            MsgBox(cmd.Parameters("?pr_err_msg").Value.ToString())

                        Else
                            lnPullOutId = 0
                            lnEntityId = 0
                        End If

                    Next i
                End With

                MsgBox("Record updated successfully !", MsgBoxStyle.Information, gsProjectName)
                Call ClearAll()
                EnableSave(False)
                btnNew.Focus()
            End If

        Else
            ' Update rack
            Dim id As Integer = Convert.ToInt32(txt)
            Dim DispatchDate As String = Format(CDate(DtpDispatchDt.Text), "yyyy-MM-dd")
            Dim entity As String = cboEntity.SelectedValue
            Dim DispatchType_st As String = "P"
            Dim CourierGid As String = CboCourierName.SelectedValue
            Dim AwbNo As String = TxtAwbNo.Text
            Dim DispatchAddr As String = txtDispatchAddr.Text
            Dim DispatchBy As String = txtDispatchBy.Text
            Dim Remarks As String = txtRemarks.Text


            Using cmd As New MySqlCommand("pr_arms_trn_tdispatch", gOdbcConn)
                Call ConOpenOdbc(ServerDetails)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("?pr_dispatch_gid", id)
                cmd.Parameters("?pr_dispatch_gid").Direction = ParameterDirection.Input
                cmd.Parameters.AddWithValue("?pr_entity_gid", entity)
                cmd.Parameters("?pr_entity_gid").Direction = ParameterDirection.Input
                cmd.Parameters.AddWithValue("?pr_dispatch_date", DispatchDate)
                cmd.Parameters("?pr_dispatch_date").Direction = ParameterDirection.Input
                cmd.Parameters.AddWithValue("?pr_dispatch_type", DispatchType_st)
                cmd.Parameters("?pr_dispatch_type").Direction = ParameterDirection.Input
                cmd.Parameters.AddWithValue("?pr_courier_gid", CourierGid)
                cmd.Parameters("?pr_courier_gid").Direction = ParameterDirection.Input
                cmd.Parameters.AddWithValue("?pr_awb_no", AwbNo)
                cmd.Parameters("?pr_awb_no").Direction = ParameterDirection.Input
                cmd.Parameters.AddWithValue("?pr_dispatch_addr", DispatchAddr)
                cmd.Parameters("?pr_dispatch_addr").Direction = ParameterDirection.Input
                cmd.Parameters.AddWithValue("?pr_dispatch_by", DispatchBy)
                cmd.Parameters("?pr_dispatch_by").Direction = ParameterDirection.Input
                cmd.Parameters.AddWithValue("?pr_dispatch_remark", Remarks)
                cmd.Parameters("?pr_dispatch_remark").Direction = ParameterDirection.Input

                'gsLoginUserCode is global variables
                cmd.Parameters.AddWithValue("?pr_action_by", gsLoginUserCode)
                cmd.Parameters("?pr_action_by").Direction = ParameterDirection.Input
                cmd.Parameters.AddWithValue("?pr_action", "UPDATE")
                cmd.Parameters("?pr_action").Direction = ParameterDirection.Input
                'Out put Para
                cmd.Parameters.Add("?pr_result", MySqlDbType.Int32)
                cmd.Parameters("?pr_result").Direction = ParameterDirection.Output
                cmd.Parameters.Add("?pr_err_msg", MySqlDbType.VarChar)
                cmd.Parameters("?pr_err_msg").Direction = ParameterDirection.Output
                cmd.ExecuteNonQuery()
                Call ConCloseOdbc(ServerDetails)
                res = Val(cmd.Parameters("?pr_result").Value.ToString())
                If (res = 0) Then
                    MsgBox(cmd.Parameters("?pr_err_msg").Value.ToString())
                    cboEntity.Focus()
                Else
                    MsgBox("Record updated successfully !", MsgBoxStyle.Information, gsProjectName)
                    Call ClearAll()
                    EnableSave(False)
                    btnNew.Focus()
                End If
            End Using
        End If

    End Sub

    Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDelete.Click
        Dim lnDispatchEntityId As Long = 0
        Dim lnEntityId As Long = 0
        Dim n As Integer
        Dim lnChklstValue As Long = 0
        Dim lnPullOutId As Long = 0
        Dim lnEntitygid As Long = 0
        Dim lsAvailableFlag As String
        Dim res As Integer
        Try
            If txtId.Text = "" Then
                If MsgBox("Select record to delete?", MsgBoxStyle.YesNo, gsProjectName) = MsgBoxResult.Yes Then
                    'Calling Find Button to select record
                    Call btnFind_Click(sender, e)
                End If
            Else
                If MsgBox("Are you sure to delete this record?", MsgBoxStyle.YesNo, gsProjectName) = MsgBoxResult.Yes Then

                    Dim id As Integer = Convert.ToInt32(txt)

                    Call ConOpenOdbc(ServerDetails)
                    cmd = New MySqlCommand("pr_arms_trn_tdispatch", gOdbcConn)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("?pr_dispatch_gid", id)
                    cmd.Parameters("?pr_dispatch_gid").Direction = ParameterDirection.Input
                    cmd.Parameters.AddWithValue("?pr_entity_gid", 0)
                    cmd.Parameters("?pr_entity_gid").Direction = ParameterDirection.Input
                    cmd.Parameters.AddWithValue("?pr_dispatch_date", 0)
                    cmd.Parameters("?pr_dispatch_date").Direction = ParameterDirection.Input
                    cmd.Parameters.AddWithValue("?pr_dispatch_type", 0)
                    cmd.Parameters("?pr_dispatch_type").Direction = ParameterDirection.Input
                    cmd.Parameters.AddWithValue("?pr_courier_gid", 0)
                    cmd.Parameters("?pr_courier_gid").Direction = ParameterDirection.Input
                    cmd.Parameters.AddWithValue("?pr_awb_no", 0)
                    cmd.Parameters("?pr_awb_no").Direction = ParameterDirection.Input
                    cmd.Parameters.AddWithValue("?pr_dispatch_addr", 0)
                    cmd.Parameters("?pr_dispatch_addr").Direction = ParameterDirection.Input
                    cmd.Parameters.AddWithValue("?pr_dispatch_by", 0)
                    cmd.Parameters("?pr_dispatch_by").Direction = ParameterDirection.Input
                    cmd.Parameters.AddWithValue("?pr_dispatch_remark", 0)
                    cmd.Parameters("?pr_dispatch_remark").Direction = ParameterDirection.Input


                    'gsLoginUserCode is global variables
                    cmd.Parameters.AddWithValue("?pr_action_by", gsLoginUserCode)
                    cmd.Parameters("?pr_action_by").Direction = ParameterDirection.Input
                    cmd.Parameters.AddWithValue("?pr_action", "DELETE")
                    cmd.Parameters("?pr_action").Direction = ParameterDirection.Input
                    'Out put Para
                    cmd.Parameters.Add("?pr_result", MySqlDbType.Int32)
                    cmd.Parameters("?pr_result").Direction = ParameterDirection.Output
                    cmd.Parameters.Add("?pr_err_msg", MySqlDbType.VarChar)
                    cmd.Parameters("?pr_err_msg").Direction = ParameterDirection.Output
                    cmd.ExecuteNonQuery()
                    Call ConCloseOdbc(ServerDetails)
                    res = Val(cmd.Parameters("?pr_result").Value.ToString())

                    If (res = 0) Then
                        MsgBox(cmd.Parameters("?pr_err_msg").Value.ToString())
                    Else

                        With dgvReport
                            n = .Columns.Count - 1
                            For i = 0 To .Rows.Count - 1

                                lnChklstValue = .Rows(i).Cells("pullout_gid").Value
                                lnEntityId = .Rows(i).Cells("entity_gid").Value
                                lnPullOutId = 0
                                lnPullOutId = lnChklstValue

                                lsAvailableFlag = "Y"

                                Call ConOpenOdbc(ServerDetails)
                                cmd = New MySqlCommand("pr_arms_set_tpullout", gOdbcConn)
                                cmd.CommandType = CommandType.StoredProcedure
                                cmd.Parameters.AddWithValue("?pr_pullout_gid", lnPullOutId)
                                cmd.Parameters("?pr_pullout_gid").Direction = ParameterDirection.Input
                                cmd.Parameters.AddWithValue("?pr_entity_gid", lnEntityId)
                                cmd.Parameters("?pr_entity_gid").Direction = ParameterDirection.Input
                                cmd.Parameters.AddWithValue("?pr_dispatch_gid", id)
                                cmd.Parameters("?pr_dispatch_gid").Direction = ParameterDirection.Input
                                cmd.Parameters.AddWithValue("?pr_available_flag", lsAvailableFlag)
                                cmd.Parameters("?pr_available_flag").Direction = ParameterDirection.Input
                                cmd.Parameters.AddWithValue("?pr_form_name", "DISPATCH")
                                cmd.Parameters("?pr_form_name").Direction = ParameterDirection.Input
                                cmd.Parameters.AddWithValue("?pr_action_by", gsLoginUserCode)
                                cmd.Parameters("?pr_action_by").Direction = ParameterDirection.Input
                                cmd.Parameters.AddWithValue("?pr_action", "DELETE")
                                cmd.Parameters("?pr_action").Direction = ParameterDirection.Input
                                'out put Para
                                cmd.Parameters.Add("?pr_result", MySqlDbType.Int32)
                                cmd.Parameters("?pr_result").Direction = ParameterDirection.Output
                                cmd.Parameters.Add("?pr_err_msg", MySqlDbType.VarChar)
                                cmd.Parameters("?pr_err_msg").Direction = ParameterDirection.Output
                                cmd.ExecuteNonQuery()
                                Call ConCloseOdbc(ServerDetails)
                                res = Val(cmd.Parameters("?pr_result").Value.ToString())
                                If (res = 0) Then
                                    MsgBox(cmd.Parameters("?pr_err_msg").Value.ToString())

                                Else
                                    lnPullOutId = 0
                                    lnEntityId = 0
                                End If

                            Next i
                        End With

                        MsgBox("Record updated successfully !", MsgBoxStyle.Information, gsProjectName)
                        Call ClearAll()
                        EnableSave(False)
                        btnNew.Focus()
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnFind_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnFind.Click
        Dim SearchDialog As frmSearch

        Try
            SearchDialog = New frmSearch(gOdbcConn, _
                             " SELECT a.dispatch_gid as 'Dispatch Id'," & _
                             " b.entity_name as 'Entity Name',date_format(a.dispatch_date,'%d-%m-%Y') as 'Dispatch Date',case when a.dispatch_type='P' then 'Pullout' end as 'Dispatch Type',c.courier_name as 'Courier Name'," & _
                             " a.awb_no as 'Awb No',a.dispatch_addr as 'Dispatch Addr',a.dispatch_by as 'Dispatch By' FROM arms_trn_tdispatch a " & _
                             " inner join arms_mst_tentity b on a.entity_gid=b.entity_gid and b.delete_flag='N' and a.delete_flag='N' " & _
                             " inner join arms_mst_tcourier c on a.courier_gid=c.courier_gid and c.delete_flag='N'", _
                             " a.dispatch_gid,b.entity_name,a.awb_no,a.dispatch_addr,a.dispatch_by", _
                             " 1 = 1")
            SearchDialog.ShowDialog()

            If Val(txt) <> 0 Then
                txt_id = txt
                Call ListAll("select dispatch_gid,entity_gid,date_format(dispatch_date,'%d-%m-%Y') as dispatch_date,courier_gid,awb_no,dispatch_addr,dispatch_by,dispatch_remark from arms_trn_tdispatch " _
                    & " where dispatch_gid = " & txt & " " _
                    & " and delete_flag = 'N'", gOdbcConn)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ListAll(ByVal SqlStr As String, ByVal odbcConn As MySqlConnection)
        Dim ds As New DataSet
        Dim i As Integer
        Dim n As Integer
        Dim lobjChkBoxColumn As DataGridViewCheckBoxColumn
      

        Try
            ds = gfDataSet(SqlStr, "list_all", gOdbcConn)

            With ds.Tables("list_all")
                If .Rows.Count > 0 Then
                    txtId.Text = .Rows(0).Item("dispatch_gid").ToString
                    cboEntity.SelectedValue = .Rows(0).Item("entity_gid").ToString
                    CboPulloutEntity.SelectedValue = .Rows(0).Item("entity_gid").ToString
                    DtpDispatchDt.Text = .Rows(0).Item("dispatch_date").ToString
                    CboCourierName.SelectedValue = .Rows(0).Item("courier_gid").ToString
                    TxtAwbNo.Text = .Rows(0).Item("awb_no").ToString
                    txtDispatchAddr.Text = .Rows(0).Item("dispatch_addr").ToString
                    txtDispatchBy.Text = .Rows(0).Item("dispatch_by").ToString
                    txtRemarks.Text = .Rows(0).Item("dispatch_remark").ToString
                Else
                    ClearAll()
                End If
            End With

            gsQry = ""
            gsQry &= " select "
            gsQry &= " a.entity_gid,b.entity_code as 'Entity Code',b.entity_name as 'Entity Name', a.contract_no as 'Contract No',date_format(a.chq_date,'%d-%m-%Y') as 'Chq Date',"
            gsQry &= " a.chq_no as 'Cheque No', a.chq_amount as 'Cheque Amount',a.pullout_reason as 'Pullout Reason',"
            gsQry &= " a.packet_no as 'Packet No', a.chq_gid as 'Chq Gid',a.pullout_gid,a.available_flag"
            gsQry &= " from arms_trn_tpullout as a "
            gsQry &= " inner join arms_mst_tentity as b on b.entity_gid=a.entity_gid and b.delete_flag = 'N'"
            gsQry &= " inner join arms_trn_tfile as c on a.entity_gid=c.entity_gid and a.file_gid=c.file_gid and c.delete_flag='N'"
            gsQry &= " where true "
            gsQry &= " and a.chq_gid>0 "
            gsQry &= " and a.dispatch_gid= " & txt & ""
            gsQry &= " and a.available_flag='Y'"
            gsQry &= " and a.delete_flag='N' "

            dgvReport.Columns.Clear()

            Call gpPopGridView(dgvReport, gsQry, gOdbcConn)


            With dgvReport

                .Columns("entity_gid").Visible = False
                .Columns("available_flag").Visible = False
                .Columns("Chq Gid").Visible = False

                For i = 0 To .Columns.Count - 1
                    .Columns(i).ReadOnly = True
                Next i

            End With

            For i = 0 To dgvReport.Columns.Count - 1
                dgvReport.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next i

            dgvReport.AutoResizeColumns()
            If dgvReport.Rows.Count > 0 Then
                BtnSelect.Enabled = True
                BtnDeSelect.Enabled = True
                BtnInverse.Enabled = True
            End If
            lblRecCount.Text = "Record Count: " & dgvReport.RowCount


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Call frmCtrClear(Me)
        Call EnableSave(False)
    End Sub

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClose.Click
        If MsgBox("Are you sure to close ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, gsProjectName) = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub ClearAll()
        Call frmCtrClear(Me)
        cboEntity.Text = ""
        dtpReqFrom.Checked = False
        dtpReqTo.Checked = False
        dgvReport.DataSource = Nothing
        BtnSelect.Enabled = False
        BtnDeSelect.Enabled = False
        BtnInverse.Enabled = False

    End Sub

    Private Sub frmDispatch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            gsQry = " select entity_gid,CONCAT(entity_code,'-', entity_name) as EntityCode  from arms_mst_tentity"
            gsQry &= " where delete_flag='N' "
            gsQry &= " order by entity_name "

            Call gpBindCombo(gsQry, "EntityCode", "entity_gid", cboEntity, gOdbcConn)
            Call gpBindCombo(gsQry, "EntityCode", "entity_gid", CboPulloutEntity, gOdbcConn)

            gsQry = " select courier_gid,courier_name   from arms_mst_tcourier"
            gsQry &= " where delete_flag='N' "
            gsQry &= " order by courier_name "

            Call gpBindCombo(gsQry, "courier_name", "courier_gid", CboCourierName, gOdbcConn)



            KeyPreview = True


            Call EnableSave(False)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub frmDispatch_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then SendKeys.Send("{TAB}")
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        Dim i As Integer
        Dim n As Integer
        Dim lobjChkBoxColumn As DataGridViewCheckBoxColumn
        Dim lsCond As String
        Dim lnEntityId As Long
        Dim lnDispatchEntityId As Long
        lsCond = ""

        Try
            If dtpReqFrom.Checked = True Then lsCond &= " and c.import_date >='" & Format(dtpReqFrom.Value, "yyyy-MM-dd") & "' "
            If dtpReqTo.Checked = True Then lsCond &= " and c.import_date < '" & Format(DateAdd(DateInterval.Day, 1, dtpReqTo.Value), "yyyy-MM-dd") & "' "

            If Not (CboPulloutEntity.SelectedIndex = -1 Or CboPulloutEntity.Text.Trim = "") Then
                lsCond &= " and a.entity_gid = '" & QuoteFilter(CboPulloutEntity.SelectedValue.ToString) & "' "
                lnEntityId = QuoteFilter(CboPulloutEntity.SelectedValue.ToString)
            Else
                MsgBox("Entity Cannot be empty!", MsgBoxStyle.Critical, gsProjectName)
                Exit Sub
            End If
            lnDispatchEntityId = QuoteFilter(cboEntity.SelectedValue.ToString)

            If lnEntityId <> lnDispatchEntityId Then
                MsgBox("Entity Not Matched!", MsgBoxStyle.Critical, gsProjectName)
                Exit Sub
            End If

            If TxtPulloutId.Text <> "" Then lsCond &= "and a.pullout_gid=" & Val(TxtPulloutId.Text) & ""


            If lsCond = "" Then lsCond = " and 1 = 2 "

            gsQry = ""
            gsQry &= " select "
            gsQry &= " a.entity_gid,b.entity_code as 'Entity Code',b.entity_name as 'Entity Name', a.contract_no as 'Contract No',date_format(a.chq_date,'%d-%m-%Y') as 'Chq Date',"
            gsQry &= " a.chq_no as 'Cheque No', a.chq_amount as 'Cheque Amount',a.pullout_reason as 'Pullout Reason',"
            gsQry &= " a.packet_no as 'Packet No', a.chq_gid as 'Chq Gid',a.pullout_gid,a.available_flag"
            gsQry &= " from arms_trn_tpullout as a "
            gsQry &= " inner join arms_mst_tentity as b on b.entity_gid=a.entity_gid and b.delete_flag = 'N'"
            gsQry &= " inner join arms_trn_tfile as c on a.entity_gid=c.entity_gid and a.file_gid=c.file_gid and c.delete_flag='N'"
            gsQry &= " where true "
            gsQry &= lsCond
            gsQry &= " and a.chq_gid>0 "
            gsQry &= " and a.dispatch_gid = 0"
            gsQry &= " and a.available_flag='Y'"
            gsQry &= " and a.delete_flag='N' "

            dgvReport.Columns.Clear()

            Call gpPopGridView(dgvReport, gsQry, gOdbcConn)


            With dgvReport

                .Columns("entity_gid").Visible = False
                .Columns("available_flag").Visible = False
                .Columns("Chq Gid").Visible = False

                For i = 0 To .Columns.Count - 1
                    .Columns(i).ReadOnly = True
                Next i
                n = .Columns.Count - 1

                lobjChkBoxColumn = New DataGridViewCheckBoxColumn
                lobjChkBoxColumn.HeaderText = "Available"
                lobjChkBoxColumn.Width = 50
                lobjChkBoxColumn.Name = "Available"
                lobjChkBoxColumn.Selected = False

                .Columns.Add(lobjChkBoxColumn)

                For i = 0 To .Rows.Count - 1

                    If (.Rows(i).Cells("available_flag").Value) = "Y" Then
                        .Rows(i).Cells(n + 1).Value = True
                    Else
                        .Rows(i).Cells(n + 1).Value = False
                    End If
                Next i

            End With

            For i = 0 To dgvReport.Columns.Count - 1
                dgvReport.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next i

            dgvReport.AutoResizeColumns()
            If dgvReport.Rows.Count > 0 Then
                BtnSelect.Enabled = True
                BtnDeSelect.Enabled = True
                BtnInverse.Enabled = True
            End If
            lblRecCount.Text = "Record Count: " & dgvReport.RowCount
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, gsProjectName)
        End Try
    End Sub

    Private Sub BtnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSelect.Click
        Dim n As Integer
        With dgvReport
            n = .Columns.Count - 1
            For i = 0 To .Rows.Count - 1
                If .Rows(i).Cells(n).Value = False Then
                    .Rows(i).Cells(n).Value = True
                End If
            Next i
        End With
    End Sub

    Private Sub BtnDeSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDeSelect.Click
        Dim n As Integer
        With dgvReport
            n = .Columns.Count - 1
            For i = 0 To .Rows.Count - 1
                If .Rows(i).Cells(n).Value = True Then
                    .Rows(i).Cells(n).Value = False
                End If
            Next i
        End With
    End Sub

    Private Sub BtnInverse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnInverse.Click
        Dim n As Integer
        With dgvReport
            n = .Columns.Count - 1
            For i = 0 To .Rows.Count - 1
                If .Rows(i).Cells(n).Value = True Then
                    .Rows(i).Cells(n).Value = False
                Else
                    .Rows(i).Cells(n).Value = True
                End If
            Next i
        End With
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Call ClearAll()
    End Sub
End Class