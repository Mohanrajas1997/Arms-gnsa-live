Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Data
Imports MySql.Data
Imports MySql.Data.MySqlClient
Public Class frmPacketEntry
    Dim fobjDTChqs As DataTable
    Dim msSql As String

    Private Sub frmPacketEntry_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then SendKeys.Send("{TAB}")
    End Sub

    Private Sub frmPacketEntry_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
    End Sub

    Private Sub frmPacketEntry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'gsQry = ""
        'gsQry &= " select loc_code,loc_name from vms_mst_tlocation"
        'gsQry &= " where true "
        'gsQry &= " and delete_flag='N' "
        'gsQry &= " order by loc_code "

        'Call gpBindCombo(gsQry, "loc_name", "loc_code", cboEntityName, gOdbcConn)

        'gsQry = ""
        'gsQry &= " select * from arms_mst_tbankbranch"
        'gsQry &= " where delete_flag='N' "
        'gsQry &= " order by bank_branch"

        'Call gpBindCombo(gsQry, "bank_branch", "bank_branch", cboBankBranch, gOdbcConn)

        gsQry = ""
        gsQry = " select CONCAT(entity_code,'-', entity_name) as EntityCode ,entity_gid from arms_mst_tentity"
        gsQry &= " where delete_flag='N' "
        gsQry &= " order by entity_name "

        Call gpBindCombo(gsQry, "EntityCode", "entity_gid", cboEntityName, gOdbcConn)
        TxtBankbranch.Enabled = False
        txtBankCode.Enabled = False
        txtBankName.Enabled = False

        Call EnableSave(False)
    End Sub

    Private Sub EnableSave(ByVal Status As Boolean)
        pnlButtons.Visible = Not Status
        pnlSave.Visible = Status

        pnlPktInfo.Enabled = Status
        pnlChqInfo.Enabled = Status
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Call Clear_Control()
        EnableSave(True)
        cboEntityName.Focus()

        'Call lpGenerateURNNo()
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
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
            MsgBox(ex.Message, MsgBoxStyle.Information, gsProjectName)
        End Try
    End Sub

    Private Sub btnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFind.Click
        Dim SearchDialog As frmSearch
        Try
            SearchDialog = New frmSearch(gOdbcConn, _
                             " select a.packet_gid 'Packet Id', a.rcvd_date 'Received Date',a.contract_no as 'Contract No'," & _
                             " a.lot_no as 'Lot No',a.cover_no as 'Cover No'," & _
                             " a.tot_chqs 'No. of Cheques' FROM arms_trn_tpacket as a ", _
                             " a.packet_gid, a.rcvd_date,a.contract_no,a.lot_no,a.cover_no", _
                             " 1 = 1 and a.delete_flag = 'N' ")
            SearchDialog.ShowDialog()

            If Val(txt) <> 0 Then
                Call ListAll("select * from arms_trn_tpacket " _
                    & "where packet_gid = " & txt & " " _
                    & "and delete_flag = 'N' ", gOdbcConn)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, gsProjectName)
        End Try
    End Sub

    Private Sub ListAll(ByVal gsqry As String, ByVal odbcConn As MySqlConnection)
        Dim lobjDataReader As Odbc.OdbcDataReader
        Dim DTChqs As DataTable
        Dim ds As DataSet
        Dim objColumn As DataColumn
        Dim objRow As DataRow
        Dim i As Integer = 0

        Try
            'lobjDataReader = gfExecuteQry(gsqry, gOdbcConn)


            ds = gfDataSet(gsqry, "list_all", gOdbcConn)

            With ds.Tables("list_all")
                If .Rows.Count > 0 Then

                    txtId.Text = .Rows(0).Item("packet_gid")
                    txtLotNo.Text = .Rows(0).Item("lot_no").ToString
                    dtpRcvdDate.Value = .Rows(0).Item("rcvd_date")
                    cboEntityName.SelectedValue = .Rows(0).Item("entity_gid").ToString
                    txtPktNo.Text = .Rows(0).Item("packet_no").ToString.ToString
                    txtContractNo.Text = .Rows(0).Item("contract_no").ToString
                    txtTotChq.Text = .Rows(0).Item("tot_chqs")
                    TxtCoverNo.Text = .Rows(0).Item("cover_no").ToString

                    fobjDTChqs = Nothing

                    dgvChq.Columns.Clear()
                    dgvChq.DataSource = Nothing

                    'Load Chq Details
                    gsqry = ""
                    gsqry &= " select * from arms_trn_tcheque as a "
                    gsqry &= " where a.packet_gid=" & txtId.Text
                    gsqry &= " and a.delete_flag='N'"

                    DTChqs = GetDataTable(gsqry)

                    If DTChqs.Rows.Count > 0 Then
                        fobjDTChqs = New DataTable

                        objColumn = New DataColumn("SNo")
                        objColumn.ColumnName = "SNo"
                        fobjDTChqs.Columns.Add(objColumn)

                        'objColumn = New DataColumn("Product")
                        'objColumn.ColumnName = "Product"
                        'fobjDTChqs.Columns.Add(objColumn)

                        'objColumn = New DataColumn("Pdc Cycle")
                        'objColumn.ColumnName = "Pdc Cycle"
                        'fobjDTChqs.Columns.Add(objColumn)

                        objColumn = New DataColumn("Chq Date")
                        objColumn.ColumnName = "Chq Date"
                        fobjDTChqs.Columns.Add(objColumn)

                        objColumn = New DataColumn("Chq No")
                        objColumn.ColumnName = "Chq No"
                        fobjDTChqs.Columns.Add(objColumn)

                        objColumn = New DataColumn("Chq Amount")
                        objColumn.ColumnName = "Chq Amount"
                        fobjDTChqs.Columns.Add(objColumn)

                        objColumn = New DataColumn("Micr")
                        objColumn.ColumnName = "Micr"
                        fobjDTChqs.Columns.Add(objColumn)

                        objColumn = New DataColumn("Bank Code")
                        objColumn.ColumnName = "Bank Code"
                        fobjDTChqs.Columns.Add(objColumn)

                        objColumn = New DataColumn("Bank Name")
                        objColumn.ColumnName = "Bank Name"
                        fobjDTChqs.Columns.Add(objColumn)

                        objColumn = New DataColumn("Bank Branch")
                        objColumn.ColumnName = "Bank Branch"
                        fobjDTChqs.Columns.Add(objColumn)

                        objColumn = New DataColumn("AT PAR Flag")
                        objColumn.ColumnName = "AT PAR Flag"
                        fobjDTChqs.Columns.Add(objColumn)

                        objColumn = New DataColumn("CTS Flag")
                        objColumn.ColumnName = "CTS Flag"
                        fobjDTChqs.Columns.Add(objColumn)

                        objColumn = New DataColumn("CTS Disc")
                        objColumn.ColumnName = "CTS Disc"
                        fobjDTChqs.Columns.Add(objColumn)

                        objColumn = New DataColumn("CTS Disc Value")
                        objColumn.ColumnName = "CTS Disc Value"
                        fobjDTChqs.Columns.Add(objColumn)

                        objColumn = New DataColumn("Chq Disc")
                        objColumn.ColumnName = "Chq Disc"
                        fobjDTChqs.Columns.Add(objColumn)

                        objColumn = New DataColumn("Chq Disc Value")
                        objColumn.ColumnName = "Chq Disc Value"
                        fobjDTChqs.Columns.Add(objColumn)

                        'objColumn = New DataColumn("Product Loc Code")
                        'objColumn.ColumnName = "Product Loc Code"
                        'fobjDTChqs.Columns.Add(objColumn)

                        'objColumn = New DataColumn("Product Flag")
                        'objColumn.ColumnName = "Product Flag"
                        'fobjDTChqs.Columns.Add(objColumn)

                        For i = 0 To DTChqs.Rows.Count - 1
                            objRow = fobjDTChqs.NewRow

                            objRow.Item("SNo") = fobjDTChqs.Rows.Count + 1

                            'objRow.Item("Product") = DTChqs.Rows(i).Item("prod_desc").ToString
                            'objRow.Item("Product Loc Code") = DTChqs.Rows(i).Item("prodloc_code").ToString
                            'objRow.Item("Product Flag") = DTChqs.Rows(i).Item("prod_flag").ToString

                            'objRow.Item("Pdc Cycle") = DTChqs.Rows(i).Item("pdc_cycle").ToString
                            objRow.Item("Chq Date") = Format(DTChqs.Rows(i).Item("chq_date"), "dd-MMM-yyyy")
                            objRow.Item("Chq No") = DTChqs.Rows(i).Item("chq_no").ToString
                            objRow.Item("Chq Amount") = Format(DTChqs.Rows(i).Item("chq_amount"), "0.00")
                            objRow.Item("Micr") = DTChqs.Rows(i).Item("micr_code").ToString
                            objRow.Item("Bank Code") = DTChqs.Rows(i).Item("bank_code").ToString
                            objRow.Item("Bank Name") = DTChqs.Rows(i).Item("bank_name").ToString
                            objRow.Item("Bank Branch") = DTChqs.Rows(i).Item("bank_branch").ToString
                            objRow.Item("AT PAR Flag") = DTChqs.Rows(i).Item("atpar_flag").ToString
                            objRow.Item("CTS Flag") = DTChqs.Rows(i).Item("cts_flag").ToString
                            objRow.Item("CTS Disc Value") = DTChqs.Rows(i).Item("cts_disc")
                            objRow.Item("Chq Disc Value") = DTChqs.Rows(i).Item("chq_disc")

                            gsqry = ""
                            gsqry &= " select group_concat(disc_desc) from arms_mst_tdisc"
                            gsqry &= " where disc_flag & " & DTChqs.Rows(i).Item("cts_disc") & " = disc_flag"
                            gsqry &= " and disc_type = 'CTS' "
                            gsqry &= " and delete_flag='N'"

                            objRow.Item("CTS Disc") = gfExecuteScalar(gsqry, gOdbcConn)

                            gsqry = ""
                            gsqry &= " select group_concat(disc_desc) from arms_mst_tdisc"
                            gsqry &= " where disc_flag & " & DTChqs.Rows(i).Item("chq_disc") & " = disc_flag"
                            gsqry &= " and disc_type = 'CHQ' "
                            gsqry &= " and delete_flag='N'"

                            objRow.Item("Chq Disc") = gfExecuteScalar(gsqry, gOdbcConn)

                            fobjDTChqs.Rows.Add(objRow)
                        Next i

                        dgvChq.DataSource = fobjDTChqs

                        For i = 0 To dgvChq.Columns.Count - 1
                            dgvChq.Columns(i).ReadOnly = True
                            dgvChq.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
                        Next i
                    End If

                    Call LoadSumm(Val(txtId.Text))
               
                End If
            End With

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, gsProjectName)
        End Try
    End Sub

    

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If MsgBox("Are you sure want to Close?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, gsProjectName) = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim ds As New DataSet
        Dim lnPktId As Long = 0
        Dim lnPktSlNo As Long = 0
        Dim lsPktNo As String = ""
        Dim lnProdFlag As Integer = 0
        Dim lnSubProdFlag As Integer = 0
        Dim lsProdCode As String = ""
        Dim lsProdLocCode As String = ""
        Dim lnPdcCycle As Integer = 0
        Dim lsEntityName As String = ""
        Dim lsContractNo As String = ""
        Dim lnTotChqs As Integer = 0
        Dim lsMonthEndFlag As String = ""
        Dim lsRemark As String = ""
        Dim lsInwardId As String = ""
        Dim lsFilegid As String = ""
        Dim lsChqType As String = ""
        Dim lsLotNo As Integer = 0
        Dim lsCoverNo As String = ""
        Dim lsPayeename As String = ""
        Dim lsLocCode As String = ""
        Dim lsChqAccNo As String = ""


        Dim lnDiscValue As Integer = 0
        Dim lnCtsDiscValue As Integer = 0
        Dim lnSummSelected As Integer = 0
        Dim lnResult As Long = 0
        Dim lnChqId As Long = 0
        Dim lnInwardChqId As Long = 0

        Dim i As Integer = 0

        Try
            If cboEntityName.SelectedIndex = -1 Or cboEntityName.Text.Trim = "" Then
                MsgBox("Please select the Entity Name !", MsgBoxStyle.Information, gsProjectName)
                cboEntityName.Focus()
                Exit Sub
            Else
                lsEntityName = cboEntityName.SelectedValue.ToString
            End If

            If txtContractNo.Text = "" Then
                MsgBox("Pleae input Contract no !", MsgBoxStyle.Information, gsProjectName)
                txtContractNo.Focus()
                Exit Sub
            Else
                lsContractNo = Mid(QuoteFilter(txtContractNo.Text), 1, 128)
            End If

            lnTotChqs = Val(txtTotChq.Text)
            lsLotNo = Val(txtLotNo.Text)

            If TxtCoverNo.Text = "" Then
                MsgBox("Pleae input Cover no !", MsgBoxStyle.Information, gsProjectName)
                TxtCoverNo.Focus()
                Exit Sub
            Else
                lsCoverNo = Mid(QuoteFilter(TxtCoverNo.Text), 1, 128)
            End If

            If lsLotNo = 0 Then
                MsgBox("Please input Lot No !", MsgBoxStyle.Information, gsProjectName)
                txtLotNo.Focus()
                Exit Sub
            End If
            If lnTotChqs = 0 Then
                MsgBox("Please input cheque count !", MsgBoxStyle.Information, gsProjectName)
                txtTotChq.Focus()
                Exit Sub
            End If

            'Cheques generated should match with the no. of cheques 
            If lnTotChqs <> dgvChq.Rows.Count Then
                'MsgBox("Cheques count mismatch !", MsgBoxStyle.Information, gsProjectName)
                If MsgBox("Cheques count mismatch.If you Continue? Click Yes", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, gsProjectName) = MsgBoxResult.Yes Then

                Else
                    txtTotChq.Focus()
                    Exit Sub
                End If
            End If

            If rdoMonthly.Checked = True Then
                lsMonthEndFlag = "M"
            ElseIf rdoQuarterly.Checked = True Then
                lsMonthEndFlag = "Q"
            ElseIf rdoHalfly.Checked = True Then
                lsMonthEndFlag = "H"
            End If

            ' summary grid validation
            For i = 0 To dgvSumm.Rows.Count - 1
                'If dgvSumm.Rows(i).Cells("Received").Value = True Then
                'If dgvSumm.Rows(i).Cells("Pdc Cycle").Value <> lnPdcCycle Then
                '    MsgBox("Summary pdc date is not matched with pdc cycle !", MsgBoxStyle.Critical, gsProjectName)
                '    txtLotNo.Focus()
                '    Exit Sub
                'End If

                If dgvSumm.Rows(i).Cells("Contract No").Value.ToString <> txtContractNo.Text Then
                    MsgBox("Summary loan no is not matched !", MsgBoxStyle.Critical, gsProjectName)
                    txtContractNo.Focus()
                    Exit Sub
                End If

                If dgvSumm.Rows(i).Cells("entity_gid").Value.ToString <> lsEntityName Then
                    MsgBox("Summary location is not matched !", MsgBoxStyle.Critical, gsProjectName)
                    cboEntityName.Focus()
                    Exit Sub
                End If

                lsFilegid = ""
                lsChqType = ""
                lsPayeename = ""
                lsLocCode = ""
                lnProdFlag = 0
                lsChqAccNo = ""

                lsFilegid = dgvSumm.Rows(i).Cells("file_gid").Value.ToString()
                lsChqType = dgvSumm.Rows(i).Cells("Cheque Type").Value.ToString()
                lsPayeename = dgvSumm.Rows(i).Cells("Dealer Name").Value.ToString()
                lsLocCode = dgvSumm.Rows(i).Cells("Loc Code").Value.ToString()
                lnProdFlag = dgvSumm.Rows(i).Cells("prod_flag").Value.ToString()
                lsChqAccNo = dgvSumm.Rows(i).Cells("chq acc no").Value.ToString()
                'lnSummSelected += 1
                'End If
            Next i

            ' chq grid validation
            'For i = 0 To dgvChq.Rows.Count - 1
            '    If dgvChq.Rows(i).Cells("Pdc Cycle").Value <> lnPdcCycle Then
            '        MsgBox("Chq date is not matched with pdc cycle !", MsgBoxStyle.Critical, gsProjectName)
            '        txtLotNo.Focus()
            '        Exit Sub
            '    End If
            'Next i

            'If lnSummSelected = 0 Then
            '    MsgBox("Please select chq summary !", MsgBoxStyle.Information, gsProjectName)
            '    dgvSumm.Focus()
            '    Exit Sub
            'End If

            'lsRemark = Mid(QuoteFilter(txtRemark.Text), 1, 255)

            ' Product
            'lnProdFlag = dgvChq.Rows(0).Cells("Product Flag").Value

            'gsQry = ""
            'gsQry &= " select prod_code from vms_mst_tproduct "
            'gsQry &= " where prod_flag = " & lnProdFlag & " "
            'gsQry &= " and delete_flag = 'N' "

            'lsProdCode = gfExecuteScalar(gsQry, gOdbcConn)

            If txtId.Text = "" Then
                ' Packet no generation
                gsQry = ""
                gsQry &= " select max(packet_slno) from arms_trn_tpacket "
                'gsQry &= " where entity_gid = '" & lsEntityName & "' "
                'gsQry &= " and lot_no = '" & QuoteFilter(txtLotNo.Text) & "' "
                'gsQry &= " and contract_no = '" & QuoteFilter(txtContractNo.Text) & "'"

                gsQry &= " where delete_flag = 'N' "

                lnPktSlNo = Val(gfExecuteScalar(gsQry, gOdbcConn)) + 1

                lsPktNo = txtLotNo.Text & Format(lnPktSlNo, "0000")

                ' Duplicate validation
                gsQry = ""
                gsQry &= " select count(*) from arms_trn_tpacket "
                gsQry &= " where packet_no = '" & lsPktNo & "' "
                gsQry &= " and lot_no = '" & QuoteFilter(txtLotNo.Text) & "' "
                gsQry &= " and contract_no = '" & QuoteFilter(txtContractNo.Text) & "'"
                gsQry &= " and delete_flag = 'N' "

                lnResult = Val(gfExecuteScalar(gsQry, gOdbcConn))

                If lnResult > 0 Then
                    MsgBox("Duplicate packet no : " & lsPktNo & " !", MsgBoxStyle.Critical, gsProjectName)
                    txtLotNo.Focus()
                    Exit Sub
                End If

         

                'Duplicate Validation Cover Number
                gsQry = ""
                gsQry &= " select count(*) from arms_trn_tpacket "
                gsQry &= " where "
                gsQry &= "  entity_gid='" & lsEntityName & "'"
                gsQry &= " and cover_no = '" & QuoteFilter(TxtCoverNo.Text) & "'"
                gsQry &= " and delete_flag = 'N' "

                lnResult = Val(gfExecuteScalar(gsQry, gOdbcConn))

                If lnResult > 0 Then
                    MsgBox("Duplicate Cover no !", MsgBoxStyle.Critical, gsProjectName)
                    TxtCoverNo.Focus()
                    Exit Sub
                End If

                'insert in packet table
                gsQry = ""
                gsQry &= " insert into arms_trn_tpacket (rcvd_date,entity_gid,file_gid,lot_no,contract_no,cover_no,cheque_type,packet_slno,packet_no,"
                gsQry &= " tot_chqs,year_flag,remark,packet_status,entry_date,entry_by) values("
                gsQry &= " '" & Format(dtpRcvdDate.Value, "yyyy-MM-dd") & "',"
                gsQry &= " '" & lsEntityName & "',"
                gsQry &= " '" & lsFilegid & "',"
                gsQry &= " " & lsLotNo & ","
                gsQry &= "'" & lsContractNo & "',"
                gsQry &= "'" & lsCoverNo & "',"
                gsQry &= "'" & lsChqType & "',"
                gsQry &= " " & lnPktSlNo & ","
                gsQry &= " '" & lsPktNo & "',"
                gsQry &= " " & lnTotChqs & ","
                gsQry &= " '" & lsMonthEndFlag & "',"
                gsQry &= " '" & lsRemark & "',"
                gsQry &= "1,"
                gsQry &= " sysdate(),"
                gsQry &= " '" & gsLoginUserCode & "')"

                lnResult = gfInsertQry(gsQry, gOdbcConn)

                gsQry = " select packet_gid from arms_trn_tpacket where packet_no = '" & lsPktNo & "' and contract_no = '" & lsContractNo & "' and lot_no = '" & lsLotNo & "' and entity_gid = '" & lsEntityName & "' and delete_flag = 'N'"

                lnPktId = gfExecuteScalar(gsQry, gOdbcConn)

                ' update summary
                With dgvSumm
                    lsInwardId = "0"

                    For i = 0 To .Rows.Count - 1
                        'If .Rows(i).Cells("Received").Value = True Then
                        gsQry = ""
                        gsQry &= " update arms_trn_taplobinput set "
                        gsQry &= " packet_gid = " & lnPktId & " "
                        gsQry &= " where entity_gid='" & lsEntityName & "'"
                        gsQry &= " and lot_no = '" & QuoteFilter(txtLotNo.Text) & "' "
                        gsQry &= " and contract_no = '" & QuoteFilter(txtContractNo.Text) & "'"
                        gsQry &= " and api_gid = " & .Rows(i).Cells("api_gid").Value & " "
                        gsQry &= " and chq_no='" & .Rows(i).Cells("Chq No").Value & "'"
                        gsQry &= " and chq_gid = 0 "
                        gsQry &= " and delete_flag = 'N' "

                        lnResult = gfInsertQry(gsQry, gOdbcConn)
                        lsInwardId &= "," & .Rows(i).Cells("api_gid").Value.ToString
                        'End If
                    Next i
                End With

                With dgvChq
                    For i = 0 To .Rows.Count - 1
                        'lnSubProdFlag = 0
                        'lsProdLocCode = .Rows(i).Cells("Product Loc Code").Value.ToString

                        'Select Case .Rows(i).Cells("Product").Value
                        '    Case "CTS"
                        '        Select Case .Rows(i).Cells("Product Loc Code").Value
                        '            Case "CTS"
                        '                lnSubProdFlag = gnSubProdAllCTS
                        '            Case Else
                        '                lnSubProdFlag = gnSubProdCTS
                        '        End Select
                        '    Case "CCLR"
                        '        lnSubProdFlag = gnSubProdCCLR
                        '    Case "OTHERS"
                        '        lnSubProdFlag = 0
                        'End Select

                        gsQry = ""
                        gsQry &= " insert into arms_trn_tcheque ("
                        gsQry &= " packet_gid,entity_gid,file_gid,contract_no,payee_name,loc_code,prod_flag,cycle_date,chq_date,chq_no,chq_amount,chq_acc_no,micr_code,"
                        gsQry &= " bank_code,bank_name,bank_branch,atpar_flag,cts_flag,cts_disc,chq_disc,chq_status,packet_no,"
                        gsQry &= " org_chq_date,org_chq_no,org_chq_amount,available_flag) values ("
                        gsQry &= " " & lnPktId & ","
                        gsQry &= " " & lsEntityName & ","
                        gsQry &= " " & lsFilegid & ","
                        gsQry &= " '" & lsContractNo & "',"
                        gsQry &= " '" & lsPayeename & "',"
                        gsQry &= " '" & lsLocCode & "',"
                        gsQry &= " '" & lnProdFlag & "',"
                        gsQry &= " '" & Format(CDate(.Rows(i).Cells("Chq Date").Value), "yyyy-MM-dd") & "',"
                        gsQry &= " '" & Format(CDate(.Rows(i).Cells("Chq Date").Value), "yyyy-MM-dd") & "',"
                        gsQry &= " '" & .Rows(i).Cells("Chq No").Value.ToString & "',"
                        gsQry &= " '" & .Rows(i).Cells("Chq Amount").Value & "',"
                        gsQry &= "'" & lsChqAccNo & "',"
                        gsQry &= " '" & .Rows(i).Cells("Micr").Value.ToString & "',"
                        gsQry &= " '" & .Rows(i).Cells("Bank Code").Value.ToString & "',"
                        gsQry &= " '" & .Rows(i).Cells("Bank Name").Value.ToString & "',"
                        gsQry &= " '" & .Rows(i).Cells("Bank Branch").Value.ToString & "',"
                        gsQry &= " '" & .Rows(i).Cells("AT PAR Flag").Value.ToString & "',"
                        gsQry &= " '" & .Rows(i).Cells("CTS Flag").Value.ToString & "',"
                        gsQry &= " " & .Rows(i).Cells("CTS Disc Value").Value & ","
                        gsQry &= " " & .Rows(i).Cells("Chq Disc Value").Value & ","

                        If .Rows(i).Cells("Chq Disc Value").Value = 0 Then
                            gsQry &= " 0,"
                        Else
                            gsQry &= " " & gnChqDisc.ToString & ","
                        End If

                        gsQry &= " '" & lsCoverNo & "',"
                        gsQry &= " '" & Format(CDate(.Rows(i).Cells("Chq Date").Value), "yyyy-MM-dd") & "',"
                        gsQry &= " '" & .Rows(i).Cells("Chq No").Value.ToString & "',"
                        gsQry &= " '" & .Rows(i).Cells("Chq Amount").Value & "',1)"

                        lnResult = gfInsertQry(gsQry, gOdbcConn)

                        ' Find chq id
                        gsQry = ""
                        gsQry &= " select max(chq_gid) from arms_trn_tcheque "
                        gsQry &= " where packet_gid = " & lnPktId & " "
                        gsQry &= " and chq_date = '" & Format(CDate(.Rows(i).Cells("Chq Date").Value), "yyyy-MM-dd") & "' "
                        gsQry &= " and chq_no='" & .Rows(i).Cells("Chq No").Value.ToString & "'"
                        gsQry &= " and delete_flag = 'N' "

                        lnChqId = Val(gfExecuteScalar(gsQry, gOdbcConn))

                        ' Find Inward Chq Id
                        gsQry = ""
                        gsQry &= " select max(api_gid) from arms_trn_taplobinput "
                        gsQry &= " where api_gid in (" & lsInwardId & ") "
                        gsQry &= " and chq_date = '" & Format(CDate(.Rows(i).Cells("Chq Date").Value), "yyyy-MM-dd") & "' "
                        gsQry &= " and chq_no='" & .Rows(i).Cells("Chq No").Value.ToString & "'"
                        gsQry &= " and chq_gid = 0 "
                        gsQry &= " and delete_flag = 'N' "

                        lnInwardChqId = Val(gfExecuteScalar(gsQry, gOdbcConn))

                        If lnInwardChqId > 0 Then
                            ' update chq id in inward chq table
                            gsQry = ""
                            gsQry &= " update arms_trn_taplobinput set "
                            gsQry &= " packet_gid = " & lnPktId & ","
                            gsQry &= " chq_gid = " & lnChqId & " "
                            gsQry &= " where api_gid = " & lnInwardChqId & " "
                            gsQry &= " and chq_gid = 0 "
                            gsQry &= " and delete_flag = 'N' "

                            lnResult = gfInsertQry(gsQry, gOdbcConn)

                            ' cheque table
                            gsQry = ""
                            gsQry &= " update arms_trn_tcheque set "
                            gsQry &= " chq_status = chq_status | " & gnChqInward & " "
                            gsQry &= " where chq_gid = " & lnChqId & " "
                            gsQry &= " and chq_status & " & gnChqInward & " = 0 "
                            gsQry &= " and delete_flag = 'N' "

                            lnResult = gfInsertQry(gsQry, gOdbcConn)

                            gsQry = ""
                            gsQry &= " update arms_trn_taplobinput as a inner join arms_trn_tcheque as b "
                            gsQry &= " on a.chq_gid=b.chq_gid"
                            gsQry &= " and a.file_gid=b.file_gid"
                            gsQry &= " and a.packet_gid=b.packet_gid"
                            gsQry &= " and a.delete_flag='N'"
                            gsQry &= " and b.delete_flag='N'"
                            gsQry &= "SET b.additional1=a.additional1,"
                            gsQry &= "b.additional2=a.additional2,"
                            gsQry &= "b.additional3=a.additional3,"
                            gsQry &= "b.additional4=a.additional4,"
                            gsQry &= "b.additional5=a.additional5,"
                            gsQry &= "b.chq_type=a.cheque_type,"
                            gsQry &= "b.payee_name=a.payee_name"
                            gsQry &= " where b.chq_gid= " & lnChqId & " "
                            gsQry &= " and a.api_gid = " & lnInwardChqId & " "
                            gsQry &= "and a.packet_gid = " & lnPktId & ""

                            lnResult = gfInsertQry(gsQry, gOdbcConn)

                        End If
                    Next i
                End With
            End If

            MsgBox("Record saved successfully ! " & vbNewLine & vbNewLine & "Packet No: " & lsPktNo, MsgBoxStyle.Information, gsProjectName)

            Call Clear_Control()

            If MsgBox("Do you want to add another Packet?", MsgBoxStyle.YesNo, gsProjectName) = MsgBoxResult.Yes Then
                btnNew.PerformClick()
                txtLotNo.Focus()
            Else
                Call EnableSave(False)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, gsProjectName)
        End Try
    End Sub

    Private Sub Clear_Control()
        Call frmCtrClear(Me)

        txtId.Text = ""

        txtContractNo.Text = ""
        txtTotChq.Text = ""
        TxtCoverNo.Text = ""
        txtLotNo.Text = ""

        rdoMonthly.Checked = True

        Call ChqPanelClear()

        dgvChq.Columns.Clear()
        dgvChq.DataSource = Nothing

        fobjDTChqs = Nothing

        dgvSumm.Columns.Clear()
        dgvSumm.DataSource = Nothing
        dtpRcvdDate.Focus()
    End Sub

    Private Sub ChqPanelClear()
        Dim ldDate As Date

        txtChqsCount.Text = ""
        txtChqNo.Text = ""
        txtChqAmt.Text = ""
        txtMicrCode.Text = ""
        txtBankCode.Text = ""
        txtBankName.Text = ""
        TxtBankbranch.Text = ""
        'cboBankBranch.SelectedIndex = -1

        gnCtsDiscVal = 0

        ldDate = DateAdd(DateInterval.Month, 1, Now)
        dtpChqDate.Value = DateSerial(Year(ldDate), Month(ldDate), Val(txtLotNo.Text))

        rdoChqAsc.Checked = True
        txtChqsCount.Focus()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Call Clear_Control()
        Call EnableSave(False)
    End Sub

    Private Sub cboDealer_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboEntityName.LostFocus
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Dim ldDate As Date

        txtChqsCount.Text = (Val(txtTotChq.Text) - dgvChq.Rows.Count).ToString

        If Val(txtChqsCount.Text) <= 0 Then
            Call ChqPanelClear()
            Exit Sub
        End If

        If dgvChq.Rows.Count = 0 Then
            ldDate = DateAdd(DateInterval.Month, 1, Now)
            dtpChqDate.Value = DateSerial(Year(ldDate), Month(ldDate), Val(txtLotNo.Text))
        Else
            dtpChqDate.Value = DateAdd(DateInterval.Month, 1, dtpChqDate.Value)
            txtChqNo.Text = Format(Val(txtChqNo.Text) + 1, "000000")
        End If

        rdoChqAsc.Checked = True

        txtChqsCount.Focus()
    End Sub

    Private Sub btnGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        Dim ds As New DataSet
        Dim objColumn As DataColumn
        Dim objRow As DataRow
        Dim objDGVButtonCol As DataGridViewButtonColumn

        Dim ldChqDate As Date
        Dim lnChqNo As Integer = 0
        Dim lsBankCode As String = ""
        Dim lsBankName As String = ""
        Dim lsBankBranch As String = ""
        Dim lsChqNo As String = ""
        Dim lsMicrCode As String = ""
        Dim lsAtparFlag As String = ""
        Dim lsCtsFlag As String = ""
        Dim lsCtsDisc As String = ""
        Dim lsTxt As String = ""
        Dim lsProd As String = ""
        Dim lsProdLocCode As String = ""
        Dim lnPdcCycle As Integer = 0
        Dim lnProdFlag As Integer = 0
        Dim lbDupFlag As Boolean = False
        Dim lsChqDisc As String = ""
        Dim lnChqDiscValue As Integer = 0
        Dim lsMonthEndFlag As String = ""
        Dim lbProdFlag As Boolean = False
        Dim lnResult As Long = 0
        Dim lsEntityGid As String = ""
        Dim lsChqType As String = ""

        Dim i As Integer, j As Integer
        Dim c As Integer = 0

        Try
            Call gpTrimAll(Me)

            If Val(txtChqsCount.Text) = 0 Then
                MsgBox("Please enter cheques count !", MsgBoxStyle.Information, gsProjectName)
                txtChqsCount.Focus()
                Exit Sub
            End If

            If txtBankCode.Text = "" Then
                MsgBox("Bank code cannot be empty !", MsgBoxStyle.Critical, gsProjectName)
                txtBankCode.Focus()
                Exit Sub
            End If

            If txtBankName.Text = "" Then
                MsgBox("Bank name cannot be empty !", MsgBoxStyle.Critical, gsProjectName)
                txtBankName.Focus()
                Exit Sub
            End If

            lsEntityGid = cboEntityName.SelectedValue.ToString

            'lnPdcCycle = Val(txtPdcCycleDay.Text)

            'If rdoMonthEndNo.Checked = True Then
            '    lsMonthEndFlag = "N"
            'Else
            '    lsMonthEndFlag = "Y"

            '    If lnPdcCycle <> 30 Then
            '        MsgBox("Please keep month end pdc cycle as 30 !", MsgBoxStyle.Information, gsProjectName)
            '        txtLotNo.Focus()
            '        Exit Sub
            '    End If
            'End If

            'If Val(Format(dtpChqDate.Value, "dd")) <> lnPdcCycle Then
            '    If MsgBox("Chq date is differs from pdc cycle day ! Are you sure to continue ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, gsProjectName) = MsgBoxResult.Yes Then
            '        If lsMonthEndFlag = "N" Then
            '            'lsChqDisc = "Cycle date differ"
            '            'lnChqDiscValue = gnDiscChqCycleDate
            '        End If
            '    Else
            '        dtpChqDate.Focus()
            '        Exit Sub
            '    End If
            'End If

            If txtChqNo.Text = "" Then
                MsgBox("Please enter the Cheque No. !", MsgBoxStyle.Information, gsProjectName)
                txtChqNo.Focus()
                Exit Sub
            End If

            If txtMicrCode.Text = "" Then
                MsgBox("Micr code is blank !", MsgBoxStyle.Critical)
                txtMicrCode.Focus()
                Exit Sub
            Else
                If txtMicrCode.Text.Length <> 9 Then
                    MsgBox("Invalid micr code !", MsgBoxStyle.Critical, gsProjectName)
                    txtMicrCode.Focus()
                    Exit Sub
                End If
            End If

            If Val(txtChqAmt.Text) = 0 Then
                MsgBox("Cheque amount cannot be zero !", MsgBoxStyle.Information, gsProjectName)
                txtChqAmt.Focus()
                Exit Sub
            End If

            If TxtBankbranch.Text = "" Then
                MsgBox("Bank branch cannot be empty !", MsgBoxStyle.Information, gsProjectName)
                TxtBankbranch.Focus()
                Exit Sub
            End If
            If cboChqType.Text = "" Then
                MsgBox("Chq Type cannot be empty !", MsgBoxStyle.Information, gsProjectName)
                cboChqType.Focus()
                Exit Sub
            End If




            ' Product
            lbProdFlag = False

            ' Based on micr dump
            gsQry = ""
            gsQry &= " select * from arms_mst_tmicr "
            gsQry &= " where micr_code = '" & QuoteFilter(txtMicrCode.Text) & "' "
            gsQry &= IIf(txtMicrCode.Text = "", " and 1 = 2 ", "")
            gsQry &= " and delete_flag = 'N' "

            Call gpDataSet(gsQry, "prod", gOdbcConn, ds)

            'With ds.Tables("prod")
            '    If .Rows.Count = 1 Then
            '        Select Case .Rows(0).Item("prod_flag")
            '            Case gnProdCTS
            '                lbProdFlag = True
            '                lsProd = "CTS"
            '                lsProdLocCode = .Rows(0).Item("prodloc_code").ToString
            '            Case gnProdCCLR
            '                lbProdFlag = True
            '                lsProd = "CCLR"
            '                lsProdLocCode = .Rows(0).Item("prodloc_code").ToString
            '        End Select
            '    End If

            '    .Rows.Clear()

            '    If lbProdFlag = False Then
            '        ' Based on CTS
            '        gsQry = ""
            '        gsQry &= " select * from vms_mst_tprodcts "
            '        gsQry &= " where bank_micr_code = '" & Mid(txtMicrCode.Text, 4, 3) & "' "
            '        gsQry &= " and delete_flag = 'N' "

            '        Call gpDataSet(gsQry, "prod", gOdbcConn, ds)

            '        If .Rows.Count = 1 Then
            '            lsProd = "CTS"
            '            lsProdLocCode = .Rows(0).Item("prodloc_code").ToString
            '        ElseIf .Rows.Count > 1 Then
            '            MsgBox("More than one CTS code found !", MsgBoxStyle.Critical, gsProjectName)
            '            txtMicrCode.Focus()
            '            Exit Sub
            '        Else
            '            ' Based on CCLR
            '            gsQry = ""
            '            gsQry &= " select * from vms_mst_tprodcclr "
            '            gsQry &= " where loc_micr_code = '" & Mid(txtMicrCode.Text, 1, 3) & "' "
            '            gsQry &= " and delete_flag = 'N' "

            '            Call gpDataSet(gsQry, "prod", gOdbcConn, ds)

            '            If .Rows.Count = 1 Then
            '                lsProd = "CCLR"
            '                lsProdLocCode = .Rows(0).Item("prodloc_code").ToString
            '            ElseIf .Rows.Count > 1 Then
            '                MsgBox("More than one CCLR code found !", MsgBoxStyle.Critical, gsProjectName)
            '                txtMicrCode.Focus()
            '                Exit Sub
            '            Else
            '                lsProd = "OTHERS"
            '                lsProdLocCode = ""
            '            End If
            '        End If
            '    End If
            'End With

            'Select Case lsProd
            '    Case "CTS"
            '        lnProdFlag = gnProdCTS
            '    Case "CCLR"
            '        lnProdFlag = gnProdCCLR
            '    Case "OTHERS"
            '        lnProdFlag = gnProdOthers
            '    Case Else
            '        MsgBox("System not able to find the product !", MsgBoxStyle.Critical, gsProjectName)
            '        txtMicrCode.Focus()
            '        Exit Sub
            'End Select

            If dgvChq.Columns.Count = 0 Then
                fobjDTChqs = New DataTable

                objColumn = New DataColumn("SNo")
                objColumn.ColumnName = "SNo"
                fobjDTChqs.Columns.Add(objColumn)

                'objColumn = New DataColumn("Product")
                'objColumn.ColumnName = "Product"
                'fobjDTChqs.Columns.Add(objColumn)

                'objColumn = New DataColumn("Pdc Cycle")
                'objColumn.ColumnName = "Pdc Cycle"
                'fobjDTChqs.Columns.Add(objColumn)

                objColumn = New DataColumn("Chq Date")
                objColumn.ColumnName = "Chq Date"
                fobjDTChqs.Columns.Add(objColumn)

                objColumn = New DataColumn("Chq No")
                objColumn.ColumnName = "Chq No"
                fobjDTChqs.Columns.Add(objColumn)

                objColumn = New DataColumn("Chq Amount")
                objColumn.ColumnName = "Chq Amount"
                fobjDTChqs.Columns.Add(objColumn)

                objColumn = New DataColumn("Micr")
                objColumn.ColumnName = "Micr"
                fobjDTChqs.Columns.Add(objColumn)

                objColumn = New DataColumn("Bank Code")
                objColumn.ColumnName = "Bank Code"
                fobjDTChqs.Columns.Add(objColumn)

                objColumn = New DataColumn("Bank Name")
                objColumn.ColumnName = "Bank Name"
                fobjDTChqs.Columns.Add(objColumn)

                objColumn = New DataColumn("Bank Branch")
                objColumn.ColumnName = "Bank Branch"
                fobjDTChqs.Columns.Add(objColumn)

                objColumn = New DataColumn("AT PAR Flag")
                objColumn.ColumnName = "AT PAR Flag"
                fobjDTChqs.Columns.Add(objColumn)

                objColumn = New DataColumn("CTS Flag")
                objColumn.ColumnName = "CTS Flag"
                fobjDTChqs.Columns.Add(objColumn)

                objColumn = New DataColumn("CTS Disc")
                objColumn.ColumnName = "CTS Disc"
                fobjDTChqs.Columns.Add(objColumn)

                objColumn = New DataColumn("CTS Disc Value")
                objColumn.ColumnName = "CTS Disc Value"
                fobjDTChqs.Columns.Add(objColumn)

                objColumn = New DataColumn("Chq Disc")
                objColumn.ColumnName = "Chq Disc"
                fobjDTChqs.Columns.Add(objColumn)

                objColumn = New DataColumn("Chq Disc Value")
                objColumn.ColumnName = "Chq Disc Value"
                fobjDTChqs.Columns.Add(objColumn)

                'objColumn = New DataColumn("Product Loc Code")
                'objColumn.ColumnName = "Product Loc Code"
                'fobjDTChqs.Columns.Add(objColumn)

                'objColumn = New DataColumn("Product Flag")
                'objColumn.ColumnName = "Product Flag"
                'fobjDTChqs.Columns.Add(objColumn)
            End If

            lsBankCode = Mid(QuoteFilter(txtBankCode.Text), 1, 3)
            lsBankName = Mid(QuoteFilter(txtBankName.Text), 1, 128)
            lsBankBranch = Mid(QuoteFilter(TxtBankbranch.Text), 1, 128)

            If rdoAtparYes.Checked = True Then
                lsAtparFlag = "Y"
            Else
                lsAtparFlag = "N"
            End If

            If gnCtsDiscVal = 0 Then
                lsCtsFlag = "Y"
            Else
                lsCtsFlag = "N"
            End If

            gsQry = ""
            gsQry &= " select group_concat(cts_desc) from arms_mst_tcts"
            gsQry &= " where cts_flag & " & gnCtsDiscVal & " > 0 "
            gsQry &= " and delete_flag='N'"

            lsCtsDisc = gfExecuteScalar(gsQry, gOdbcConn)

            ldChqDate = dtpChqDate.Value
            lnChqNo = Val(txtChqNo.Text)

            If MsgBox("Are you sure to generate ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, gsProjectName) = MsgBoxResult.No Then
                Exit Sub
            End If

            For i = 0 To Val(txtChqsCount.Text) - 1
                'lsChqType = dgvSumm.Rows(i).Cells("Cheque Type").Value.ToString()
                lsChqType = cboChqType.Text
                If lsChqType = "PDC" Then
                    If i > 0 Then
                        If rdoMonthly.Checked = True Then
                            dtpChqDate.Value = DateAdd(DateInterval.Month, 1, dtpChqDate.Value)
                        ElseIf rdoQuarterly.Checked = True Then

                            dtpChqDate.Value = DateAdd(DateInterval.Month, 3, dtpChqDate.Value)
                            'dtpChqDate.Value = CDate(Format(dtpChqDate.Value, "01-MMM-yyyy"))
                            ''dtpChqDate.Value = DateAdd(DateInterval.Day, -1, dtpChqDate.Value)
                        ElseIf rdoHalfly.Checked = True Then

                            'dtpChqDate.Value = DateAdd(DateInterval.Month, 6, ldChqDate)
                            dtpChqDate.Value = DateAdd(DateInterval.Month, 6, dtpChqDate.Value)
                        End If
                    End If
                End If


                Select Case True
                    Case rdoChqDesc.Checked
                        txtChqNo.Text = Format(lnChqNo - i, "000000")
                    Case Else
                        txtChqNo.Text = Format(lnChqNo + i, "000000")
                End Select

                lbDupFlag = False

                ' Duplicate check
                For j = 0 To fobjDTChqs.Rows.Count - 1
                    With fobjDTChqs.Rows(j)
                        ' chq level
                        If .Item("Chq Date") = Format(dtpChqDate.Value, "dd-MMM-yyyy") _
                            And .Item("Chq No") = txtChqNo.Text _
                            And .Item("Chq Amount") = Format(Val(txtChqAmt.Text), "0.00") Then
                            lbDupFlag = True

                            MsgBox("Duplicate chq no " & txtChqNo.Text & " !", MsgBoxStyle.Critical, gsProjectName)
                        End If

                        ' product level
                        'If .Item("Product Flag") <> lnProdFlag Then
                        '    MsgBox("System will not accept different products in one packet !")
                        '    lbDupFlag = True
                        'End If
                    End With
                Next j

                If lbDupFlag = False Then
                    objRow = fobjDTChqs.NewRow

                    objRow.Item("SNo") = fobjDTChqs.Rows.Count + 1
                    'objRow.Item("Product") = lsProd
                    'objRow.Item("Product Loc Code") = lsProdLocCode
                    'objRow.Item("Product Flag") = lnProdFlag
                    'objRow.Item("Pdc Cycle") = lnPdcCycle
                    objRow.Item("Chq Date") = Format(dtpChqDate.Value, "dd-MMM-yyyy")
                    objRow.Item("Chq No") = txtChqNo.Text
                    objRow.Item("Chq Amount") = Format(Val(txtChqAmt.Text), "0.00")
                    objRow.Item("Micr") = txtMicrCode.Text
                    objRow.Item("Bank Code") = lsBankCode
                    objRow.Item("Bank Name") = lsBankName
                    objRow.Item("Bank Branch") = lsBankBranch
                    objRow.Item("AT PAR Flag") = lsAtparFlag
                    objRow.Item("CTS Flag") = lsCtsFlag
                    objRow.Item("CTS Disc Value") = gnCtsDiscVal
                    objRow.Item("CTS Disc") = lsCtsDisc
                    objRow.Item("Chq Disc") = lsChqDisc
                    objRow.Item("Chq Disc Value") = lnChqDiscValue

                    fobjDTChqs.Rows.Add(objRow)
                End If
            Next i

            dgvChq.DataSource = fobjDTChqs

            For i = 0 To dgvChq.Columns.Count - 1
                dgvChq.Columns(i).ReadOnly = True
                dgvChq.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next i

            If dgvChq.Columns.Count = fobjDTChqs.Columns.Count Then
                ' CTS
                objDGVButtonCol = New DataGridViewButtonColumn
                objDGVButtonCol.Name = "CTS Audit"
                objDGVButtonCol.Text = "CTS Audit"
                objDGVButtonCol.UseColumnTextForButtonValue = True
                dgvChq.Columns.Add(objDGVButtonCol)

                ' Chq Disc
                objDGVButtonCol = New DataGridViewButtonColumn
                objDGVButtonCol.Name = "Chq Audit"
                objDGVButtonCol.Text = "Chq Audit"
                objDGVButtonCol.UseColumnTextForButtonValue = True
                dgvChq.Columns.Add(objDGVButtonCol)

                ' Remove
                objDGVButtonCol = New DataGridViewButtonColumn
                objDGVButtonCol.Name = "Remove"
                objDGVButtonCol.Text = "Remove"
                objDGVButtonCol.UseColumnTextForButtonValue = True
                dgvChq.Columns.Add(objDGVButtonCol)
            End If

            With dgvChq
                For i = 0 To .Rows.Count - 1
                    msSql = ""
                    msSql &= " select api_gid from arms_trn_taplobinput "
                    msSql &= " where entity_gid = '" & lsEntityGid & "' "
                    msSql &= " and lot_no = '" & QuoteFilter(txtLotNo.Text) & "' "
                    msSql &= " and contract_no = '" & QuoteFilter(txtContractNo.Text) & "'"
                    msSql &= " and chq_no = '" & .Rows(i).DataBoundItem("Chq No").ToString & "' "
                    msSql &= " and chq_date = '" & Format(CDate(.Rows(i).DataBoundItem("Chq Date").ToString), "yyyy-MM-dd") & "' "
                    msSql &= " and chq_amount = '" & .Rows(i).DataBoundItem("Chq Amount").ToString & "' "
                    'msSql &= " and chq_amount = '" & Val(txtChqAmt.Text) & "' "
                    msSql &= " and chq_gid = 0 "
                    msSql &= " and delete_flag = 'N' "

                    lnResult = Val(gfExecuteScalar(msSql, gOdbcConn))

                    If lnResult = 0 Then
                        .Rows(i).DefaultCellStyle.BackColor = Color.Red
                        c += 1
                    End If
                Next i
            End With

            If c > 0 Then
                MsgBox(c.ToString & " record(s) not matched with arms dump !", MsgBoxStyle.Critical, gsProjectName)
            End If

            btnClear.PerformClick()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, gsProjectName)
        End Try
    End Sub

    Private Sub txtNumberofChqs_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTotChq.KeyPress
        If gfIntEntryOnly(e) Then e.Handled = True
    End Sub

    Private Sub txtChqsCount_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtChqsCount.KeyPress
        If gfIntEntryOnly(e) Then e.Handled = True
    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClrGrid.Click
        If Not IsNothing(dgvChq.CurrentRow) Then
            If MsgBox("Are you sure to clear grid ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, gsProjectName) = MsgBoxResult.Yes Then
                fobjDTChqs.Rows.Clear()
            End If
        End If
    End Sub

    Private Sub dgvChqs_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvChq.CellClick
        Dim objfrm As Object
        Dim i As Integer

        Select Case dgvChq.Columns(dgvChq.CurrentCell.ColumnIndex).Name
            Case "Chq Audit"
                gnDiscVal = dgvChq.Rows(dgvChq.CurrentCell.RowIndex).Cells("Chq Disc Value").Value

                objfrm = New frmDiscCheckList
                objfrm.ShowDialog()

                If gnDiscVal > 0 Then
                    gsQry = " select group_concat(disc_desc) from arms_mst_tdisc"
                    gsQry &= " where disc_flag & " & gnDiscVal & " = disc_flag "
                    gsQry &= " and disc_type = 'CHQ' "
                    gsQry &= " and delete_flag='N'"

                    dgvChq.Rows(dgvChq.CurrentCell.RowIndex).Cells("Chq Disc").Value = gfExecuteScalar(gsQry, gOdbcConn)
                Else
                    dgvChq.Rows(dgvChq.CurrentCell.RowIndex).Cells("Chq Disc").Value = ""
                End If

                dgvChq.Rows(dgvChq.CurrentCell.RowIndex).Cells("Chq Disc Value").Value = gnDiscVal
                gnDiscVal = 0
            Case "CTS Audit"
                gnCtsDiscVal = dgvChq.Rows(dgvChq.CurrentCell.RowIndex).Cells("CTS Disc Value").Value

                objfrm = New frmCtsCheckList
                objfrm.ShowDialog()

                If gnCtsDiscVal > 0 Then
                    gsQry = " select group_concat(cts_desc) from arms_mst_tcts"
                    gsQry &= " where cts_flag & " & gnCtsDiscVal & " = cts_flag "
                    gsQry &= " and delete_flag='N'"

                    dgvChq.Rows(dgvChq.CurrentCell.RowIndex).Cells("CTS Disc").Value = gfExecuteScalar(gsQry, gOdbcConn)
                Else
                    dgvChq.Rows(dgvChq.CurrentCell.RowIndex).Cells("CTS Disc").Value = ""
                End If

                dgvChq.Rows(dgvChq.CurrentCell.RowIndex).Cells("CTS Disc Value").Value = gnCtsDiscVal
                gnCtsDiscVal = 0
            Case "Remove"
                If MsgBox("Are you sure to remove ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, gsProjectName) = MsgBoxResult.Yes Then
                    Call dgvChq.Rows.RemoveAt(dgvChq.CurrentCell.RowIndex)

                    If dgvChq.Rows.Count > 0 Then
                        For i = dgvChq.CurrentCell.RowIndex To dgvChq.Rows.Count - 1
                            dgvChq.Rows(i).Cells("SNo").Value = (i + 1).ToString
                        Next i
                    End If
                End If
        End Select
    End Sub

    Private Sub txtMicrCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMicrCode.KeyPress
        If gfIntEntryOnly(e) Then e.Handled = True
    End Sub

    Private Sub frmPacketEntry_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        With pnlPktInfo
            .Left = 6
            .Top = 6
        End With

        With pnlChqInfo
            .Top = pnlPktInfo.Top + pnlPktInfo.Height + 6
            .Left = pnlPktInfo.Left
            .Width = Me.Width - 20
            .Height = Me.Height - (.Top + 48 + pnlSave.Height)
        End With

        With dgvChq
            .Left = 6
            .Width = pnlChqInfo.Width - 14
            .Height = pnlChqInfo.Height - (.Top + 8)
        End With

        With dgvSumm
            .Left = dgvChq.Left
            .Width = dgvChq.Width
        End With

        pnlSave.Top = pnlChqInfo.Top + pnlChqInfo.Height + 6
        pnlSave.Left = (Me.Width - (pnlSave.Width + 20)) \ 2

        pnlButtons.Top = pnlSave.Top
        pnlButtons.Left = (Me.Width - (pnlButtons.Width + 20)) \ 2
    End Sub

    Private Sub txtMicrCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMicrCode.TextChanged

    End Sub
    Private Sub txtMicrCode_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtMicrCode.Validating
        Dim ds As DataSet
        If txtMicrCode.Text <> "" And txtMicrCode.Text <> "XXX" Then
            gsQry = ""
            gsQry &= " select micr_code,bank_code,bank_name,branch_name from arms_mst_tmicr "
            gsQry &= " where micr_code='" & txtMicrCode.Text & "'"
            gsQry &= " and delete_flag='N' "

            ds = gfDataSet(gsQry, "micr_all", gOdbcConn)

            With ds.Tables("micr_all")
                If .Rows.Count > 0 Then
                    txtBankCode.Text = .Rows(0).Item("bank_code").ToString
                    txtBankName.Text = .Rows(0).Item("bank_name").ToString
                    TxtBankbranch.Text = .Rows(0).Item("branch_name").ToString
                End If
            End With
            If txtBankName.Text = "" Then e.Cancel = True
        End If
    End Sub
    Private Sub txtMicrCode_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMicrCode.LostFocus
        If txtMicrCode.Text = "XXX" Then
            txtBankCode.Enabled = True
            txtBankName.Enabled = True
            TxtBankbranch.Enabled = True
        Else
            txtBankCode.Enabled = False
            txtBankName.Enabled = False
            TxtBankbranch.Enabled = False
        End If
    End Sub

    Private Sub txtBankCode_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBankCode.LostFocus
        If txtBankCode.Text = "XXX" Then
            txtBankName.Enabled = True
        Else
            txtBankName.Enabled = False
        End If
    End Sub

    'Private Sub txtBankCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBankCode.TextChanged

    'End Sub

    'Private Sub txtBankCode_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtBankCode.Validating
    '    If txtBankCode.Text <> "" And txtBankCode.Text <> "XXX" Then
    '        gsQry = ""
    '        gsQry &= " select bank_name from arms_mst_tbank "
    '        gsQry &= " where bank_code = '" & txtBankCode.Text & "' "
    '        gsQry &= " and delete_flag = 'N' "

    '        txtBankName.Text = gfExecuteScalar(gsQry, gOdbcConn)

    '        If txtBankName.Text = "" Then e.Cancel = True
    '    End If
    'End Sub

    Private Sub txtContractNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtContractNo.TextChanged
    End Sub

    Private Sub txtContractNo_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtContractNo.Validating
        Dim i As Integer
        Dim lsEntityGid As String = ""
        Dim lobjChkBox As DataGridViewCheckBoxColumn
        Dim lobjBtn As DataGridViewButtonColumn
        Dim lsChqType As String = ""

        If cboEntityName.Text <> "" And cboEntityName.SelectedIndex <> -1 Then lsEntityGid = cboEntityName.SelectedValue.ToString

        If txtId.Text = "" And txtContractNo.Text <> "" And txtLotNo.Text <> "" Then
            'gsQry = ""
            'gsQry &= " select "
            'gsQry &= " i.pdc_cycle as 'Pdc Cycle',"
            'gsQry &= " i.loan_no as 'Loan No',"
            'gsQry &= " i.send_date as 'Send Date',"
            'gsQry &= " i.chq_start_date as 'Chq Start Date',"
            'gsQry &= " i.chq_end_date as 'Chq End Date',"
            'gsQry &= " i.chq_start_no as 'Chq Start No',"
            'gsQry &= " i.chq_end_no as 'Chq End No',"
            'gsQry &= " i.chq_amount as 'Chq Amount',"
            'gsQry &= " i.chq_count as 'Chq Count',"
            'gsQry &= " i.micr_code as 'Micr Code',"
            'gsQry &= " b.bank_code as 'Bank Code',"
            'gsQry &= " i.bank_name as 'Bank Name',"
            'gsQry &= " i.branch_name as 'Branch Name',"
            'gsQry &= " i.loc_code as 'Loc Code',"
            'gsQry &= " i.inward_gid "
            'gsQry &= " from vms_trn_tinward as i "
            'gsQry &= " left join vms_mst_tbank as b on b.bank_name = i.bank_name and b.delete_flag = 'N' "
            'gsQry &= " where i.loan_no = '" & QuoteFilter(txtContractNo.Text) & "' "
            'gsQry &= " and i.loc_code = '" & lsLocCode & "' "
            ''gsQry &= " and i.pdc_cycle = " & Val(txtPdcCycleDay.Text) & " "
            'gsQry &= " and i.packet_gid = 0 "
            'gsQry &= " and i.delete_flag = 'N' "



            gsQry = ""
            gsQry &= " select "
            gsQry &= " count(*) as 'ChqCount'"
            gsQry &= " from arms_trn_taplobinput "
            gsQry &= " where entity_gid = '" & lsEntityGid & "' "
            gsQry &= " and lot_no = '" & QuoteFilter(txtLotNo.Text) & "' "
            gsQry &= " and contract_no = '" & QuoteFilter(txtContractNo.Text) & "'"
            gsQry &= " and chq_gid = 0 "
            gsQry &= " and delete_flag = 'N' "

            txtTotChq.Text = gfExecuteScalar(gsQry, gOdbcConn)
            txtTotChq.Enabled = False

            If txtTotChq.Text = "" Then e.Cancel = True

            gsQry = ""
            gsQry &= " select "
            gsQry &= " i.lot_no as 'Lot No',"
            gsQry &= " i.cheque_type as 'Cheque Type',"
            gsQry &= " i.contract_no as 'Contract No',"
            gsQry &= " i.payee_name as 'Dealer Name',"
            gsQry &= " i.chq_date as 'Chq Date',"
            gsQry &= " i.chq_no as 'Chq No',"
            gsQry &= " i.chq_amount as 'Chq Amount',"
            gsQry &= " i.chq_acc_no as 'Chq Acc No',"
            gsQry &= " i.loc_code as 'Loc Code',"
            gsQry &= " i.micr_code as 'Micr Code',"
            gsQry &= " i.bank_name as 'Bank Name',"
            gsQry &= " i.bank_branch as 'Branch Name',"
            gsQry &= " i.api_gid, "
            gsQry &= " i.entity_gid, "
            gsQry &= " i.file_gid,i.prod_flag "
            gsQry &= " from arms_trn_taplobinput as i "
            gsQry &= " where i.entity_gid = '" & lsEntityGid & "' "
            gsQry &= " and i.lot_no = '" & QuoteFilter(txtLotNo.Text) & "' "
            gsQry &= " and i.contract_no = '" & QuoteFilter(txtContractNo.Text) & "'"
            'gsQry &= " and i.pdc_cycle = " & Val(txtPdcCycleDay.Text) & " "
            gsQry &= " and i.chq_gid = 0 "
            gsQry &= " and i.delete_flag = 'N' "


            dgvSumm.Columns.Clear()
            dgvSumm.DataSource = Nothing

            Call gpPopGridView(dgvSumm, gsQry, gOdbcConn)

            For i = 0 To dgvSumm.Columns.Count - 1
                dgvSumm.Columns(i).ReadOnly = True
                dgvSumm.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable

            Next i

            dgvSumm.Columns("api_gid").Visible = False
            dgvSumm.Columns("entity_gid").Visible = False
            dgvSumm.Columns("file_gid").Visible = False
            dgvSumm.Columns("prod_flag").Visible = False



            If lsChqType = "SPDC" Then
                rdoMonthly.Enabled = False
                rdoQuarterly.Enabled = False
                rdoHalfly.Enabled = False
            End If

            If dgvSumm.Rows.Count > 0 Then
                lsChqType = dgvSumm.Rows(0).Cells("Cheque Type").Value.ToString()
            End If

            '' Select
            'lobjBtn = New DataGridViewButtonColumn
            'lobjBtn.Name = "Select"
            'lobjBtn.Text = "Select"
            'dgvSumm.Columns.Insert(0, lobjBtn)

            '' Received
            'lobjChkBox = New DataGridViewCheckBoxColumn
            'lobjChkBox.Name = "Received"
            'dgvSumm.Columns.Insert(0, lobjChkBox)

            'For i = 0 To dgvSumm.Rows.Count - 1
            '    'dgvSumm.Rows(i).Cells("Select").Value = "Select"
            '    'dgvSumm.Rows(i).Cells("Received").Value = False
            'Next i
        End If
    End Sub

    Private Sub dgvSumm_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSumm.CellClick
        With dgvSumm
            If txtId.Text = "" Then
                Select Case .Columns(.CurrentCell.ColumnIndex).Name
                    Case "Select"
                        If .CurrentRow.Cells("Received").Value = False Then
                            MsgBox("Please mark it as received !", MsgBoxStyle.Information, gsProjectName)
                        Else
                            Call ChqPanelClear()

                            txtChqsCount.Text = .CurrentRow.Cells("Chq Count").Value.ToString

                            If .CurrentRow.Cells("Bank Code").Value.ToString = "" Then
                                txtBankCode.Text = "XXX"
                            Else
                                txtBankCode.Text = .CurrentRow.Cells("Bank Code").Value.ToString
                            End If

                            txtBankName.Text = .CurrentRow.Cells("Bank Name").Value.ToString
                            TxtBankbranch.Text = .CurrentRow.Cells("Branch Name").Value.ToString
                            txtChqNo.Text = .CurrentRow.Cells("Chq Start No").Value.ToString
                            dtpChqDate.Value = .CurrentRow.Cells("Chq Start Date").Value
                            txtChqAmt.Text = .CurrentRow.Cells("Chq Amount").Value.ToString
                            '|txtMicrCode.Text = .CurrentRow.Cells("Micr Code").Value.ToString
                            txtChqsCount.Focus()
                        End If
                End Select
            End If
        End With
    End Sub

    Private Sub LoadSumm(ByVal PacketId As Long)
        Dim i As Integer
        Dim lsLocCode As String = ""
        Dim lobjChkBox As DataGridViewCheckBoxColumn
        Dim lobjBtn As DataGridViewButtonColumn

        'gsQry = ""
        'gsQry &= " select "
        'gsQry &= " i.pdc_cycle as 'Pdc Cycle',"
        'gsQry &= " i.loan_no as 'Loan No',"
        'gsQry &= " i.send_date as 'Send Date',"
        'gsQry &= " i.chq_start_date as 'Chq Start Date',"
        'gsQry &= " i.chq_end_date as 'Chq End Date',"
        'gsQry &= " i.chq_start_no as 'Chq Start No',"
        'gsQry &= " i.chq_end_no as 'Chq End No',"
        'gsQry &= " i.chq_amount as 'Chq Amount',"
        'gsQry &= " i.chq_count as 'Chq Count',"
        'gsQry &= " i.micr_code as 'Micr Code',"
        'gsQry &= " b.bank_code as 'Bank Code',"
        'gsQry &= " i.bank_name as 'Bank Name',"
        'gsQry &= " i.branch_name as 'Branch Name',"
        'gsQry &= " i.loc_code as 'Loc Code',"
        'gsQry &= " i.inward_gid "
        'gsQry &= " from vms_trn_tinward as i "
        'gsQry &= " left join vms_mst_tbank as b on b.bank_name = i.bank_name and b.delete_flag = 'N' "
        'gsQry &= " where i.packet_gid = " & PacketId & " "
        'gsQry &= " and i.delete_flag = 'N' "


        gsQry = ""
        gsQry &= " select "
        gsQry &= " i.lot_no as 'Lot No',"
        gsQry &= " i.cheque_type as 'Cheque Type',"
        gsQry &= " i.contract_no as 'Contract No',"
        gsQry &= " i.payee_name as 'Dealer Name',"
        gsQry &= " i.chq_date as 'Chq Date',"
        gsQry &= " i.chq_no as 'Chq No',"
        gsQry &= " i.chq_amount as 'Chq Amount',"
        gsQry &= " i.chq_acc_no as 'Chq Acc No',"
        gsQry &= " i.loc_code as 'Loc Code',"
        gsQry &= " i.micr_code as 'Micr Code',"
        gsQry &= " i.bank_name as 'Bank Name',"
        gsQry &= " i.bank_branch as 'Branch Name',"
        gsQry &= " i.api_gid, "
        gsQry &= " i.entity_gid, "
        gsQry &= " i.file_gid,i.prod_flag "
        gsQry &= " from arms_trn_taplobinput as i "
        gsQry &= " where i.packet_gid = " & PacketId & " "
        gsQry &= " and i.delete_flag = 'N' "

        dgvSumm.Columns.Clear()
        dgvSumm.DataSource = Nothing

        Call gpPopGridView(dgvSumm, gsQry, gOdbcConn)

        For i = 0 To dgvSumm.Columns.Count - 1
            dgvSumm.Columns(i).ReadOnly = True
            dgvSumm.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
        Next i

        dgvSumm.Columns("api_gid").Visible = False
        dgvSumm.Columns("entity_gid").Visible = False
        dgvSumm.Columns("file_gid").Visible = False
        dgvSumm.Columns("prod_flag").Visible = False
        '' Select
        'lobjBtn = New DataGridViewButtonColumn
        'lobjBtn.Name = "Select"
        'lobjBtn.Text = "Select"
        'dgvSumm.Columns.Insert(0, lobjBtn)

        '' Received
        'lobjChkBox = New DataGridViewCheckBoxColumn
        'lobjChkBox.Name = "Received"
        'dgvSumm.Columns.Insert(0, lobjChkBox)

        'For i = 0 To dgvSumm.Rows.Count - 1
        '    dgvSumm.Rows(i).Cells("Select").Value = "Select"
        '    dgvSumm.Rows(i).Cells("Received").Value = True
        'Next i
    End Sub

    Private Sub dgvSumm_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSumm.CellContentClick

    End Sub

    Private Sub lblCtsDisc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblCtsDisc.Click
        Dim objfrm As New frmCtsCheckList
        objfrm.ShowDialog()
    End Sub

    Private Sub dgvSumm_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvSumm.GotFocus
        If dgvSumm.Rows.Count > 0 Then
            dgvSumm.Rows(dgvSumm.CurrentCell.RowIndex).Cells(0).Selected = True
            dgvSumm.CurrentCell = dgvSumm.Rows(dgvSumm.CurrentCell.RowIndex).Cells(0)
        End If
    End Sub


    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
        Dim lnPktId As Long = 0
        Dim lnResult As Long = 0

        Try
            lnPktId = Val(txtId.Text)

            If lnPktId = 0 Then
                MsgBox("Select the Record", MsgBoxStyle.Information, gsProjectName)
                'Calling Find Button to select record
                Call btnFind_Click(sender, e)
            Else
                If MsgBox("Are you sure to delete this record ?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, gsProjectName) = MsgBoxResult.Yes Then
                    ' check
                    gsQry = ""
                    gsQry &= " select count(*) from arms_trn_tcheque "
                    gsQry &= " where packet_gid = " & lnPktId & " "
                    gsQry &= " and chq_status <> 0 "
                    gsQry &= " and chq_status <> " & gnChqDisc & " "
                    gsQry &= " and chq_status <> " & gnChqInward & " "
                    gsQry &= " and chq_status <> " & gnChqHdfcDump & " "
                    gsQry &= " and chq_status <> " & (gnChqDisc Or gnChqInward) & " "
                    gsQry &= " and chq_status <> " & (gnChqDisc Or gnChqHdfcDump) & " "
                    gsQry &= " and chq_status <> " & (gnChqDisc Or gnChqHdfcDump) & " "
                    gsQry &= " and chq_status <> " & (gnChqHdfcDump Or gnChqInward) & " "
                    gsQry &= " and chq_status <> " & (gnChqDisc Or gnChqHdfcDump Or gnChqInward) & " "
                    gsQry &= " and delete_flag = 'N' "

                    lnResult = Val(gfExecuteScalar(gsQry, gOdbcConn))

                    If lnResult > 0 Then
                        MsgBox("Access denied !", MsgBoxStyle.Critical, gsProjectName)
                        Exit Sub
                    End If

                    ' delete record
                    ' packet table
                    gsQry = ""
                    gsQry &= " update arms_trn_tpacket set "
                    gsQry &= " delete_flag = 'Y',"
                    gsQry &= " delete_date = sysdate(),"
                    gsQry &= " delete_by = '" & gsLoginUserCode & "' "
                    gsQry &= " where packet_gid = " & lnPktId & " "
                    gsQry &= " and delete_flag = 'N' "

                    lnResult = gfInsertQry(gsQry, gOdbcConn)

                    ' inward table
                    gsQry = ""
                    gsQry &= " update arms_trn_taplobinput set "
                    gsQry &= " packet_gid = 0, "
                    gsQry &= " chq_gid = 0 "
                    gsQry &= " where packet_gid = " & lnPktId & " "
                    gsQry &= " and delete_flag = 'N' "

                    lnResult = gfInsertQry(gsQry, gOdbcConn)

                    '' update chq id in inward chq table
                    'gsQry = ""
                    'gsQry &= " update vms_trn_tinwardchq set "
                    'gsQry &= " packet_gid = 0,"
                    'gsQry &= " chq_gid = 0 "
                    'gsQry &= " where packet_gid = " & lnPktId & " "
                    'gsQry &= " and delete_flag = 'N' "

                    'lnResult = gfInsertQry(gsQry, gOdbcConn)

                    '' update chq id in chqhdfc table
                    'gsQry = ""
                    'gsQry &= " update vms_trn_tcheque as c "
                    'gsQry &= " inner join vms_trn_tchqhdfc as h on h.chq_gid = c.chq_gid and h.delete_flag = 'N' "
                    'gsQry &= " set h.chq_gid = 0 "
                    'gsQry &= " where c.packet_gid = " & lnPktId & " "
                    'gsQry &= " and c.delete_flag = 'N' "

                    'lnResult = gfInsertQry(gsQry, gOdbcConn)

                    ' cheque table
                    gsQry = ""
                    gsQry &= " update arms_trn_tcheque set "
                    gsQry &= " delete_flag = 'Y' "
                    gsQry &= " where packet_gid = " & lnPktId & " "
                    'gsQry &= " and (chq_status = 0 "
                    'gsQry &= " or chq_status = " & gnChqDisc & " "
                    'gsQry &= " or chq_status = " & gnChqInward & " "
                    'gsQry &= " or chq_status = " & (gnChqDisc Or gnChqInward) & ") "
                    gsQry &= " and delete_flag = 'N' "

                    lnResult = gfInsertQry(gsQry, gOdbcConn)

                    gsQry = ""
                    gsQry &= " update arms_trn_talmira set "
                    gsQry &= " delete_flag='Y' "
                    gsQry &= " where packet_gid = " & lnPktId & " "
                    gsQry &= " and delete_flag = 'N' "

                    lnResult = gfInsertQry(gsQry, gOdbcConn)

                    MsgBox("Record deleted successfully !", MsgBoxStyle.Information, gsProjectName)

                    Call EnableSave(False)
                    Call Clear_Control()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, gsProjectName)
        End Try
    End Sub
End Class