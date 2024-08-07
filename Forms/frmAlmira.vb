Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Data
Imports MySql.Data
Imports MySql.Data.MySqlClient
Public Class frmAlmira
#Region "Local Declaration"
    Dim msSql As String
    Dim mnResult As Integer
#End Region
    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.       
    End Sub
    Private Sub frmAlmira_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then SendKeys.Send("{TAB}")
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
        txt_id = 0
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
            Case cboLotNo.Text
                MsgBox("City cannot be empty !", MsgBoxStyle.Critical, gsProjectName)
                cboLotNo.Focus()
                Exit Sub
            Case cboContractNo.Text
                MsgBox("Contract No cannot be empty !", MsgBoxStyle.Critical, gsProjectName)
                cboContractNo.Focus()
                Exit Sub
            Case txtBoxNo.Text
                MsgBox("Box No cannot be empty !", MsgBoxStyle.Critical, gsProjectName)
                txtBoxNo.Focus()
                Exit Sub
                'Case Format(CDate(dpReceivedDate.Value), "yyyy-MM-dd") > Format(CDate(Date.Today), "yyyy-MM-dd")
                '    MsgBox("ReceivedDate Invalied !", MsgBoxStyle.Critical, gsProjectName)
                '    dpReceivedDate.Focus()
                '    Exit Sub
            Case txtCuboardNo.Text
                MsgBox("Cuboard No cannot be empty !", MsgBoxStyle.Critical, gsProjectName)
                txtCuboardNo.Focus()
                Exit Sub
            Case txtShelfNo.Text
                MsgBox("Shelf No cannot be empty !", MsgBoxStyle.Critical, gsProjectName)
                txtShelfNo.Focus()
                Exit Sub
            Case CboCoverno.Text
                MsgBox("Cover No cannot be empty !", MsgBoxStyle.Critical, gsProjectName)
                CboCoverno.Focus()
                Exit Sub


        End Select

        If txtId.Text.Trim = "" Then

            Dim entity As String = cboEntity.SelectedValue
            Dim Lotno As String = cboLotNo.SelectedValue
            Dim ContractNo As String = cboContractNo.SelectedValue
            Dim CuboardNo As String = txtCuboardNo.Text
            Dim ShelfNo As String = txtShelfNo.Text
            Dim BoxNo As String = txtBoxNo.Text
            Dim CoverNo As String = CboCoverno.SelectedValue

            Using cmd As New MySqlCommand("pr_arms_trn_talmira", gOdbcConn)
                Call ConOpenOdbc(ServerDetails)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("?pr_almira_gid", 0)
                cmd.Parameters("?pr_almira_gid").Direction = ParameterDirection.Input
                cmd.Parameters.AddWithValue("?pr_entity_gid", entity)
                cmd.Parameters("?pr_entity_gid").Direction = ParameterDirection.Input
                cmd.Parameters.AddWithValue("?pr_lot_no", Lotno)
                cmd.Parameters("?pr_lot_no").Direction = ParameterDirection.Input
                cmd.Parameters.AddWithValue("?pr_packet_gid", ContractNo)
                cmd.Parameters("?pr_packet_gid").Direction = ParameterDirection.Input
                cmd.Parameters.AddWithValue("?pr_cuboard_no", CuboardNo)
                cmd.Parameters("?pr_cuboard_no").Direction = ParameterDirection.Input
                cmd.Parameters.AddWithValue("?pr_shelf_no", ShelfNo)
                cmd.Parameters("?pr_shelf_no").Direction = ParameterDirection.Input
                cmd.Parameters.AddWithValue("?pr_box_no", BoxNo)
                cmd.Parameters("?pr_box_no").Direction = ParameterDirection.Input
                cmd.Parameters.AddWithValue("?pr_cover_no", CoverNo)
                cmd.Parameters("?pr_cover_no").Direction = ParameterDirection.Input
                'gsLoginUserCode is global variables
                cmd.Parameters.AddWithValue("?pr_entry_by", gsLoginUserCode)
                cmd.Parameters("?pr_entry_by").Direction = ParameterDirection.Input
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
                    cboEntity.Focus()
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
            Dim entity As String = cboEntity.SelectedValue
            Dim Lotno As String = cboLotNo.SelectedValue
            Dim ContractNo As String = cboContractNo.SelectedValue
            Dim CuboardNo As String = txtCuboardNo.Text
            Dim ShelfNo As String = txtShelfNo.Text
            Dim BoxNo As String = txtBoxNo.Text
            Dim CoverNo As String = CboCoverno.SelectedValue


            Using cmd As New MySqlCommand("pr_arms_trn_talmira", gOdbcConn)
                Call ConOpenOdbc(ServerDetails)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("?pr_almira_gid", id)
                cmd.Parameters("?pr_almira_gid").Direction = ParameterDirection.Input
                cmd.Parameters.AddWithValue("?pr_entity_gid", entity)
                cmd.Parameters("?pr_entity_gid").Direction = ParameterDirection.Input
                cmd.Parameters.AddWithValue("?pr_lot_no", Lotno)
                cmd.Parameters("?pr_lot_no").Direction = ParameterDirection.Input
                cmd.Parameters.AddWithValue("?pr_packet_gid", ContractNo)
                cmd.Parameters("?pr_packet_gid").Direction = ParameterDirection.Input
                cmd.Parameters.AddWithValue("?pr_cuboard_no", CuboardNo)
                cmd.Parameters("?pr_cuboard_no").Direction = ParameterDirection.Input
                cmd.Parameters.AddWithValue("?pr_shelf_no", ShelfNo)
                cmd.Parameters("?pr_shelf_no").Direction = ParameterDirection.Input
                cmd.Parameters.AddWithValue("?pr_box_no", BoxNo)
                cmd.Parameters("?pr_box_no").Direction = ParameterDirection.Input
                cmd.Parameters.AddWithValue("?pr_cover_no", CoverNo)
                cmd.Parameters("?pr_cover_no").Direction = ParameterDirection.Input

                'gsLoginUserCode is global variables
                cmd.Parameters.AddWithValue("?pr_entry_by", gsLoginUserCode)
                cmd.Parameters("?pr_entry_by").Direction = ParameterDirection.Input
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
                    Using cmd As New MySqlCommand("pr_arms_trn_talmira", gOdbcConn)
                        Call ConOpenOdbc(ServerDetails)
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.Parameters.AddWithValue("?pr_almira_gid", id)
                        cmd.Parameters("?pr_almira_gid").Direction = ParameterDirection.Input
                        cmd.Parameters.AddWithValue("?pr_entity_gid", 0)
                        cmd.Parameters("?pr_entity_gid").Direction = ParameterDirection.Input
                        cmd.Parameters.AddWithValue("?pr_lot_no", 0)
                        cmd.Parameters("?pr_lot_no").Direction = ParameterDirection.Input
                        cmd.Parameters.AddWithValue("?pr_packet_gid", 0)
                        cmd.Parameters("?pr_packet_gid").Direction = ParameterDirection.Input
                        cmd.Parameters.AddWithValue("?pr_cuboard_no", 0)
                        cmd.Parameters("?pr_cuboard_no").Direction = ParameterDirection.Input
                        cmd.Parameters.AddWithValue("?pr_shelf_no", 0)
                        cmd.Parameters("?pr_shelf_no").Direction = ParameterDirection.Input
                        cmd.Parameters.AddWithValue("?pr_box_no", 0)
                        cmd.Parameters("?pr_box_no").Direction = ParameterDirection.Input
                        cmd.Parameters.AddWithValue("?pr_cover_no", 0)
                        cmd.Parameters("?pr_cover_no").Direction = ParameterDirection.Input

                        'gsLoginUserCode is global variables
                        cmd.Parameters.AddWithValue("?pr_entry_by", gsLoginUserCode)
                        cmd.Parameters("?pr_entry_by").Direction = ParameterDirection.Input
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
                            MsgBox(cmd.Parameters("?pr_err_msg").Value.ToString())
                        Else
                            MsgBox("Record updated successfully !", MsgBoxStyle.Information, gsProjectName)
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
                             " SELECT a.almira_gid as 'Almira Id'," & _
                             " b.entity_name as 'Entity Name',a.lot_no as 'Lot No',c.contract_no as 'Contract No',a.cover_no as 'Cover No',a.cuboard_no as 'Cuboard NO'," & _
                             " a.shelf_no as 'Shelf No',a.box_no as 'Box No' FROM arms_trn_talmira a " & _
                             " inner join arms_mst_tentity b on a.entity_gid=b.entity_gid and b.delete_flag='N' and a.delete_flag='N' " & _
                             " inner join arms_trn_tpacket c on b.entity_gid=c.entity_gid and a.packet_gid=c.packet_gid and c.delete_flag='N'", _
                             " a.almira_gid,b.entity_name,a.lot_no,c.contract_no,a.cover_no,a.cuboard_no,a.shelf_no,a.box_no", _
                             " 1 = 1")
            SearchDialog.ShowDialog()

            If Val(txt) <> 0 Then
                txt_id = txt
                Call ListAll("select * from arms_trn_talmira " _
                    & " where almira_gid = " & txt & " " _
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
                    txtId.Text = .Rows(0).Item("almira_gid").ToString
                    cboEntity.SelectedValue = .Rows(0).Item("entity_gid").ToString
                    cboLotNo.SelectedValue = .Rows(0).Item("lot_no").ToString
                    cboContractNo.SelectedValue = .Rows(0).Item("packet_gid").ToString
                    txtCuboardNo.Text = .Rows(0).Item("cuboard_no").ToString
                    txtShelfNo.Text = .Rows(0).Item("shelf_no").ToString
                    txtBoxNo.Text = .Rows(0).Item("box_no").ToString
                    CboCoverno.SelectedValue = .Rows(0).Item("cover_no").ToString
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

    Private Sub frmAlmira_Load(sender As Object, e As EventArgs) Handles Me.Load

        Try
            gsQry = " select entity_gid,CONCAT(entity_code,'-', entity_name) as EntityCode  from arms_mst_tentity"
            gsQry &= " where delete_flag='N' "
            gsQry &= " order by entity_name "

            Call gpBindCombo(gsQry, "EntityCode", "entity_gid", cboEntity, gOdbcConn)

            KeyPreview = True
     

            Call EnableSave(False)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub CboEntity_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboEntity.SelectedIndexChanged
        Try
            cboLotNo.DataSource = Nothing
            cboLotNo.Items.Clear()
            cboLotNo.Text = String.Empty
            Dim Entityvalue As Integer
            'Entityvalue = cboEntity.SelectedIndex

            If cboEntity.SelectedIndex <> -1 Then
                Entityvalue = Val(cboEntity.SelectedValue.ToString)
            End If


            If Entityvalue > 0 Then
                If txt_id = 0 Then
                    gsQry = " select distinct lot_no from arms_trn_tpacket"
                    gsQry &= " where entity_gid=" & cboEntity.SelectedValue & " and almira_gid=" & txt_id & " and delete_flag='N' "
                    'gsQry &= " order by packet_gid asc "

                    Call gpBindCombo(gsQry, "lot_no", "lot_no", cboLotNo, gOdbcConn)
                Else
                    gsQry = " select distinct lot_no from arms_trn_tpacket"
                    gsQry &= " where entity_gid=" & cboEntity.SelectedValue & " and  delete_flag='N' "
                    'gsQry &= " order by packet_gid asc "

                    Call gpBindCombo(gsQry, "lot_no", "lot_no", cboLotNo, gOdbcConn)
                End If
      
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub CboLotNo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboLotNo.SelectedIndexChanged
        Try
            cboContractNo.DataSource = Nothing
            cboContractNo.Items.Clear()
            cboContractNo.Text = String.Empty
            Dim lotvalue As Integer
            lotvalue = cboLotNo.SelectedIndex
            If cboLotNo.SelectedIndex <> -1 Then
                lotvalue = Val(cboLotNo.SelectedValue.ToString)
            End If
            If lotvalue > 0 Then
                If txt_id = 0 Then
                    gsQry = " select packet_gid, contract_no from arms_trn_tpacket"
                    gsQry &= " where entity_gid=" & cboEntity.SelectedValue & " and lot_no=" & cboLotNo.SelectedValue & " and almira_gid=" & txt_id & "  and delete_flag='N' "
                    gsQry &= " order by packet_gid asc "
                    Call gpBindCombo(gsQry, "contract_no", "packet_gid", cboContractNo, gOdbcConn)
                Else
                    gsQry = " select packet_gid, contract_no from arms_trn_tpacket"
                    gsQry &= " where entity_gid=" & cboEntity.SelectedValue & " and lot_no=" & cboLotNo.SelectedValue & "   and delete_flag='N' "
                    gsQry &= " order by packet_gid asc "

                    Call gpBindCombo(gsQry, "contract_no", "packet_gid", cboContractNo, gOdbcConn)
                End If
             
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub CboContractNo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboContractNo.SelectedIndexChanged
        Try
            
            Dim ContractNo As Integer
            ContractNo = cboContractNo.SelectedIndex
            If cboContractNo.SelectedIndex <> -1 Then
                ContractNo = Val(cboContractNo.SelectedValue.ToString)
            End If
            Dim lotvalue As Integer
            lotvalue = cboLotNo.SelectedIndex
            If cboLotNo.SelectedIndex <> -1 Then
                lotvalue = Val(cboLotNo.SelectedValue.ToString)
            End If
            If lotvalue > 0 Then
                If ContractNo > 0 Then
                    If txt_id = 0 Then
                        gsQry = " select distinct cover_no,packet_gid from arms_trn_tpacket"
                        gsQry &= " where entity_gid=" & cboEntity.SelectedValue & " and lot_no=" & cboLotNo.SelectedValue & " and packet_gid='" & cboContractNo.SelectedValue.ToString & "' and packet_status<>0 and almira_gid=" & txt_id & "  and delete_flag='N' "
                        gsQry &= " order by packet_gid asc "

                        Call gpBindCombo(gsQry, "cover_no", "cover_no", CboCoverno, gOdbcConn)
                    Else
                        gsQry = " select distinct cover_no,packet_gid from arms_trn_tpacket"
                        gsQry &= " where entity_gid=" & cboEntity.SelectedValue & " and lot_no=" & cboLotNo.SelectedValue & " and packet_gid='" & cboContractNo.SelectedValue.ToString & "' and packet_status<>0 and  delete_flag='N' "
                        gsQry &= " order by packet_gid asc "

                        Call gpBindCombo(gsQry, "cover_no", "cover_no", CboCoverno, gOdbcConn)
                    End If
            
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    
End Class