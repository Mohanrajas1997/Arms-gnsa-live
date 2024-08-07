Public Class frmChequeEntry

    Inherits System.Windows.Forms.Form

    Dim msSql As String
    Dim fobjDTChqs As DataTable
    Dim lnChqcount As Long = 0

#Region "Local Declaration"

    Dim lnRcvddate As Date
    Dim lnEntityName As String
    Dim lnEntityGid As Long
    Dim lnLotNo As String
    Dim lnCoverNo As String
    Dim lsTotChqs As Long

#End Region

    Public Sub New(ByVal lsRcvddate, lsEntityName, lsEntityGid, lsLotNo, lsCoverNo, lnTotChqs)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        lnRcvddate = lsRcvddate
        lnEntityName = lsEntityName
        lnEntityGid = lsEntityGid
        lnLotNo = lsLotNo
        lnCoverNo = lsCoverNo
        lsTotChqs = lnTotChqs

    End Sub

    Private Sub frmChequeEntry_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then SendKeys.Send("{TAB}")
    End Sub

    Private Sub frmChequeEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        dtpRcvdDate.Value = lnRcvddate
        cboEntityName.Text = lnEntityName
        txtLotNo.Text = lnLotNo
        txtCoverNo.Text = lnCoverNo
        txtTotChq.Text = lsTotChqs
        txtId.Text = lnEntityGid

    End Sub

    Private Sub txtCntno_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtContractNo.Validating
        Dim i As Integer
        Dim lsEntityGid As String = ""
        Dim lsChqType As String = ""
        Dim lnPktId As Long = 0

        If cboEntityName.Text <> "" And cboEntityName.SelectedIndex <> -1 Then lsEntityGid = txtId.Text

        If txtContractNo.Text <> "" And txtLotNo.Text <> "" Then

            lsEntityGid = txtId.Text

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

            gsQry = " select packet_gid from arms_trn_tpacket where cover_no = '" & txtCoverNo.Text.ToString & "' and lot_no = '" & lnLotNo & "' and entity_gid = '" & lnEntityGid & "' and delete_flag = 'N'"

            lnPktId = gfExecuteScalar(gsQry, gOdbcConn)

            ' Find chq count
            gsQry = ""
            gsQry &= " select count(*) from arms_trn_tcheque "
            gsQry &= " where packet_gid = " & lnPktId & " "
            gsQry &= " and delete_flag = 'N' "

            lnChqcount = Val(gfExecuteScalar(gsQry, gOdbcConn))

            txtCount.Text = lnChqcount

        End If
    End Sub

    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
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

                objColumn = New DataColumn("Contract No")
                objColumn.ColumnName = "Contract No"
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
                    objRow.Item("Contract No") = txtContractNo.Text
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
                    msSql &= " where entity_gid = '" & lnEntityGid & "' "
                    msSql &= " and lot_no = '" & QuoteFilter(txtLotNo.Text) & "' "
                    'msSql &= " and contract_no = '" & QuoteFilter(txtContractNo.Text) & "'"
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
            clear()
            txtContractNo.Focus()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, gsProjectName)
        End Try
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

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
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

    Private Sub btnClrGrid_Click(sender As Object, e As EventArgs) Handles btnClrGrid.Click
        If Not IsNothing(dgvChq.CurrentRow) Then
            If MsgBox("Are you sure to clear grid ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, gsProjectName) = MsgBoxResult.Yes Then
                fobjDTChqs.Rows.Clear()
            End If
        End If
    End Sub

    Private Sub Clear_Control()
        'Call frmCtrClear(Me)

        'txtId.Text = ""

        'txtContractNo.Text = ""
        'txtTotChq.Text = ""
        'TxtCoverNo.Text = ""
        'txtLotNo.Text = ""

        rdoMonthly.Checked = True

        Call ChqPanelClear()

        dgvChq.Columns.Clear()
        dgvChq.DataSource = Nothing

        fobjDTChqs = Nothing

        dgvSumm.Columns.Clear()
        dgvSumm.DataSource = Nothing
        dtpRcvdDate.Focus()
    End Sub

    Private Sub clear()
        txtContractNo.Text = ""
        txtChqsCount.Text = ""
        txtChqNo.Text = ""
        txtChqAmt.Text = ""
        txtBankCode.Text = ""
        txtBankName.Text = ""
        txtMicrCode.Text = ""
        TxtBankbranch.Text = ""
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
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
        Dim tot_chq As Long = 0

        Dim lnDiscValue As Integer = 0
        Dim lnCtsDiscValue As Integer = 0
        Dim lnSummSelected As Integer = 0
        Dim lnResult As Long = 0
        Dim lnChqId As Long = 0
        Dim lnInwardChqId As Long = 0

        Dim i As Integer = 0

        Try
            If rdoMonthly.Checked = True Then
                lsMonthEndFlag = "M"
            ElseIf rdoQuarterly.Checked = True Then
                lsMonthEndFlag = "Q"
            ElseIf rdoHalfly.Checked = True Then
                lsMonthEndFlag = "H"
            End If

            ' summary grid validation
            For i = 0 To dgvSumm.Rows.Count - 1

                'If dgvSumm.Rows(i).Cells("Contract No").Value.ToString <> txtContractNo.Text Then
                '    MsgBox("Summary loan no is not matched !", MsgBoxStyle.Critical, gsProjectName)
                '    txtContractNo.Focus()
                '    Exit Sub
                'End If

                If dgvSumm.Rows(i).Cells("entity_gid").Value.ToString <> lnEntityGid Then
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
                'lsContractNo = dgvSumm.Rows(i).Cells("Contract No").Value.ToString()
                'lnSummSelected += 1
                'End If
            Next i

            If txtId.Text <> "" Then

                gsQry = " select packet_gid from arms_trn_tpacket where cover_no = '" & txtCoverNo.Text.ToString & "' and lot_no = '" & lnLotNo & "' and entity_gid = '" & lnEntityGid & "' and delete_flag = 'N'"

                lnPktId = gfExecuteScalar(gsQry, gOdbcConn)

                ' update summary
                With dgvSumm
                    lsInwardId = "0"

                    For i = 0 To .Rows.Count - 1
                        'If .Rows(i).Cells("Received").Value = True Then
                        gsQry = ""
                        gsQry &= " update arms_trn_taplobinput set "
                        gsQry &= " packet_gid = " & lnPktId & " "
                        gsQry &= " where entity_gid='" & lnEntityGid & "'"
                        gsQry &= " and lot_no = '" & QuoteFilter(txtLotNo.Text) & "' "
                        gsQry &= " and contract_no = '" & .Rows(i).Cells("Contract No").Value & "'"
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

                        gsQry = ""
                        gsQry &= " insert into arms_trn_tcheque ("
                        gsQry &= " packet_gid,entity_gid,file_gid,contract_no,payee_name,loc_code,prod_flag,cycle_date,chq_date,chq_no,chq_amount,chq_acc_no,micr_code,"
                        gsQry &= " bank_code,bank_name,bank_branch,atpar_flag,cts_flag,cts_disc,chq_disc,chq_status,packet_no,"
                        gsQry &= " org_chq_date,org_chq_no,org_chq_amount,available_flag) values ("
                        gsQry &= " " & lnPktId & ","
                        gsQry &= " " & lnEntityGid & ","
                        gsQry &= " " & lsFilegid & ","
                        gsQry &= " '" & .Rows(i).Cells("Contract No").Value.ToString & "',"
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

                        gsQry &= " '" & .Rows(i).Cells("Contract No").Value.ToString & "',"
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

                        ' Find chq count
                        gsQry = ""
                        gsQry &= " select count(*) from arms_trn_tcheque "
                        gsQry &= " where packet_gid = " & lnPktId & " "
                        gsQry &= " and delete_flag = 'N' "

                        lnChqcount = Val(gfExecuteScalar(gsQry, gOdbcConn))

                        txtCount.Text = lnChqcount

                        ' Find Inward Chq Id
                        gsQry = ""
                        gsQry &= " select max(api_gid) from arms_trn_taplobinput "
                        gsQry &= " where api_gid in (" & lsInwardId & ") "
                        gsQry &= " and chq_date = '" & Format(CDate(.Rows(i).Cells("Chq Date").Value), "yyyy-MM-dd") & "' "
                        gsQry &= " and chq_no='" & .Rows(i).Cells("Chq No").Value.ToString & "'"

                        gsQry &= " and chq_gid = 0 "
                        gsQry &= " and delete_flag = 'N' "

                        lnInwardChqId = Val(gfExecuteScalar(gsQry, gOdbcConn))

                        'If lnInwardChqId > 0 Then
                        ' update chq id in inward chq table
                        gsQry = ""
                        gsQry &= " update arms_trn_taplobinput set "
                        gsQry &= " packet_gid = " & lnPktId & ","
                        gsQry &= " chq_gid = " & lnChqId & " "
                        gsQry &= " where entity_gid='" & lnEntityGid & "'"
                        gsQry &= " and lot_no = '" & QuoteFilter(txtLotNo.Text) & "' "
                        gsQry &= " and contract_no = '" & .Rows(i).Cells("Contract No").Value & "'"
                        gsQry &= " and chq_no='" & .Rows(i).Cells("Chq No").Value & "'"
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

                        'End If
                    Next i
                End With
            End If

            gsQry = ""
            gsQry = " select tot_chqs from arms_trn_tpacket where packet_gid = '" & lnPktId & "' and delete_flag = 'N'"

            tot_chq = gfExecuteScalar(gsQry, gOdbcConn)

            'If tot_chq = txtCount.Text Then
            '    MsgBox("Record saved successfully ! " & vbNewLine & vbNewLine & "Cover No: " & txtCoverNo.Text.ToString, MsgBoxStyle.Information, gsProjectName)
            '    Me.Close()
            'End If

            Call Clear_Control()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, gsProjectName)
        End Try
    End Sub

    Private Sub txtMicrCode_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtMicrCode.Validating
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

    Private Sub dgvChq_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvChq.CellClick
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

    Private Sub btnComplete_Click(sender As Object, e As EventArgs) Handles btnComplete.Click
        Dim lnResult As Long = 0
        Dim lnPktId As Long = 0
        gsQry = " select packet_gid from arms_trn_tpacket where cover_no = '" & txtCoverNo.Text.ToString & "' and lot_no = '" & lnLotNo & "' and entity_gid = '" & lnEntityGid & "' and delete_flag = 'N'"

        lnPktId = gfExecuteScalar(gsQry, gOdbcConn)

        ' Find chq count
        gsQry = ""
        gsQry &= " select count(*) from arms_trn_tcheque "
        gsQry &= " where packet_gid = " & lnPktId & " "
        gsQry &= " and delete_flag = 'N' "

        lnChqcount = Val(gfExecuteScalar(gsQry, gOdbcConn))

        If txtTotChq.Text <> lnChqcount Then
            If MsgBox("Are you sure to Complete ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, gsProjectName) = MsgBoxResult.Yes Then
                gsQry = ""
                gsQry &= " update arms_trn_tpacket set "
                gsQry &= " tot_chqs = " & lnChqcount & " "
                gsQry &= " where packet_gid='" & lnPktId & "'"
                gsQry &= " and delete_flag = 'N' "

                lnResult = gfInsertQry(gsQry, gOdbcConn)
                MsgBox("Record saved successfully ! " & vbNewLine & vbNewLine & "Cover No: " & txtCoverNo.Text.ToString, MsgBoxStyle.Information, gsProjectName)
                Me.Close()
            End If

        End If
        If txtTotChq.Text = lnChqcount Then
            MsgBox("Record saved successfully ! " & vbNewLine & vbNewLine & "Cover No: " & txtCoverNo.Text.ToString, MsgBoxStyle.Information, gsProjectName)
            Me.Close()
        End If
    End Sub

End Class