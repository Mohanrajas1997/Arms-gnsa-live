Imports System.Net
Imports System.IO
Imports System.Text
Imports Newtonsoft.Json
Imports MySql.Data.MySqlClient

Public Class frmImageBaseEntry
    Dim count As Integer = 0
    Dim prvvalue As String = ""
    Dim Scangid As New Integer
    Dim lsPacketGid As Integer = 0
    Dim lsagreementno As String = ""
    Dim lsCoverNo As String = ""
    Dim lsLotNo As String = ""
    Dim lsContractNo As String = ""
    Dim lnCyclegid As Integer = 0
    Private Sub frmImageBaseEntry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        gsQry = " select prod_code as ProdCode ,prod_flag from arms_mst_tproduct"
        gsQry &= " where delete_flag='N' "
        gsQry &= " order by prod_desc "
        Call gpBindCombo(gsQry, "ProdCode", "prod_flag", cboProdcode, gOdbcConn)

        gsQry = " select loc_name ,loc_code from arms_mst_tlocation"
        gsQry &= " where delete_flag='N' "
        gsQry &= " order by loc_name "
        Call gpBindCombo(gsQry, "loc_name", "loc_code", cmbLoc, gOdbcConn)

        Me.KeyPreview = True
        RdoYetConfirm.Checked = True
        RdiChqYes.Checked = True

        mstchqdate.Enabled = False
        txtchqamt.Enabled = False
        TxtBankCode.Enabled = False
        TxtBankName.Enabled = False
        txtaccno.Enabled = False
        txtaccno.Clear()

        PnlPdcEntry.Visible = True

        If RdiNo.Checked = True Then
            btnAdd.Enabled = False
        ElseIf RdoYetConfirm.Checked = True Then
            btnAdd.Enabled = False
        Else
            btnAdd.Enabled = True
        End If

    End Sub
    'Public Sub New(ByVal CoverNo As String, ByVal LotNo As String, ByVal ContractNo As String)

    '    ' This call is required by the designer.
    '    InitializeComponent()
    '    TxtCoverNo.Text = CoverNo
    '    TxtContractNo.Text = ContractNo
    '    TxtLotNo.Text = LotNo

    '    lsCoverNo = CoverNo
    '    lsLotNo = LotNo
    '    lsContractNo = ContractNo
    '    ' Add any initialization after the InitializeComponent() call.
    '    LoadData()
    '    LoadGridData(lsPacketGid)
    'End Sub

    Public Sub New(packet_gid As String)

        ' This call is required by the designer.
        InitializeComponent()
        TxtPacketId.Text = packet_gid
        ' Add any initialization after the InitializeComponent() call.
        LoadData(packet_gid)
        LoadGridData(lsPacketGid)
    End Sub

    Private Sub LoadData(packet_gid As Long)
        Dim lsSql As String
        Dim ds As New DataSet


        lsSql = ""
        lsSql &= " select packet_gid,cover_no,Date_format(rcvd_date,'%d-%m-%Y') as packetrecvdate,contract_no,lot_no,b.entity_name,tot_chqs "
        lsSql &= " from arms_trn_tpacket as a "
        lsSql &= " inner join arms_mst_tentity as b on a.entity_gid=b.entity_gid and b.delete_flag='N'"
        lsSql &= " where packet_gid='" & packet_gid & "'"
        lsSql &= " and a.delete_flag='N'"

        gpDataSet(lsSql, "Packet", gOdbcConn, ds)

        If ds.Tables("Packet").Rows.Count = 1 Then
            TxtCoverNo.Text = ds.Tables("Packet").Rows(0).Item("cover_no").ToString
            TxtContractNo.Text = ds.Tables("Packet").Rows(0).Item("contract_no").ToString
            TxtLotNo.Text = ds.Tables("Packet").Rows(0).Item("lot_no").ToString
            lsCoverNo = ds.Tables("Packet").Rows(0).Item("cover_no").ToString
            lsContractNo = ds.Tables("Packet").Rows(0).Item("contract_no").ToString
            lsLotNo = ds.Tables("Packet").Rows(0).Item("lot_no").ToString

            TxtEntityName.Text = ds.Tables("Packet").Rows(0).Item("entity_name").ToString
            'dtbPacketRecv.Text = ds.Tables("Packet").Rows(0).Item("packetrecvdate").ToString
            TxtPacketId.Text = ds.Tables("Packet").Rows(0).Item("packet_gid").ToString
            lsPacketGid = ds.Tables("Packet").Rows(0).Item("packet_gid").ToString
            TxtTotalChq.Text = ds.Tables("Packet").Rows(0).Item("tot_chqs").ToString
        End If

        lsSql = ""
        lsSql &= " Update arms_trn_tpacket set"
        lsSql &= " gnsa_lock_flag='Y' ,"
        lsSql &= " gnsa_lock_date=now(),"
        lsSql &= " gnsa_lock_by='" & gsLoginUserCode & "'"
        lsSql &= " where packet_gid=" & lsPacketGid
        lsSql &= " and delete_flag= 'N'"
        gfExecuteQry(lsSql, gOdbcConn)
        ' Call ConCloseOdbc(ServerDetails)
    End Sub

    Private Sub LoadData1()
        Dim lsSql As String
        Dim ds As New DataSet


        lsSql = ""
        lsSql &= " select packet_gid,cover_no,Date_format(rcvd_date,'%d-%m-%Y') as packetrecvdate,contract_no,lot_no,b.entity_name,tot_chqs "
        lsSql &= " from arms_trn_tpacket as a "
        lsSql &= " inner join arms_mst_tentity as b on a.entity_gid=b.entity_gid and b.delete_flag='N'"
        lsSql &= " where contract_no='" & TxtContractNo.Text.Trim & "'"
        lsSql &= " and cover_no= '" & TxtCoverNo.Text.Trim & "'"
        lsSql &= " and lot_no='" & TxtLotNo.Text.Trim & "'"
        lsSql &= " and a.delete_flag='N'"

        gpDataSet(lsSql, "Packet", gOdbcConn, ds)

        If ds.Tables("Packet").Rows.Count = 1 Then
            TxtEntityName.Text = ds.Tables("Packet").Rows(0).Item("entity_name").ToString
            dtbPacketRecv.Text = ds.Tables("Packet").Rows(0).Item("packetrecvdate").ToString
            TxtPacketId.Text = ds.Tables("Packet").Rows(0).Item("packet_gid").ToString
            lsPacketGid = ds.Tables("Packet").Rows(0).Item("packet_gid").ToString
            TxtTotalChq.Text = ds.Tables("Packet").Rows(0).Item("tot_chqs").ToString
        End If

        lsSql = ""
        lsSql &= " Update arms_trn_tpacket set"
        lsSql &= " gnsa_lock_flag='Y' ,"
        lsSql &= " gnsa_lock_date=now(),"
        lsSql &= " gnsa_lock_by='" & gsLoginUserCode & "'"
        lsSql &= " where packet_gid=" & lsPacketGid
        lsSql &= " and delete_flag= 'N'"
        gfExecuteQry(lsSql, gOdbcConn)
        ' Call ConCloseOdbc(ServerDetails)
    End Sub

    Private Sub EnableCustinfo()
        txtCustname.Focus()
        txtCustname.Enabled = True
        cmbLoc.Enabled = True
        cboProdcode.Enabled = True
    End Sub

    Private Sub LoadGridData(ByVal lsPacketGid As Integer)
        Dim lsSql As String
        Dim lsScanStatusCode As String
        Dim lnPacketAuditCount As Long

        If rdoPending.Checked = True Then
            lsScanStatusCode = "P"
        Else
            lsScanStatusCode = "C"
        End If
        TabChqDtls.Focus()

        If lsPacketGid > 0 Then

            lsSql = ""
            lsSql &= " select @rownr :=@rownr+1 as 'Serial No',api_gid,a.lot_no as 'Lot No',a.contract_no as 'Contract No',cover_no as 'Cover No',"
            lsSql &= " payee_name as 'Payee Name',cycle_date as 'Cycle Date',chq_date as 'Chq Date',chq_no as 'Chq No',chq_amount as 'Chq Amount',"
            lsSql &= " chq_acc_no as 'Chq Acc No',micr_code as 'Micr Code'"
            lsSql &= " from arms_trn_taplobinput as a inner join arms_trn_tpacket as b on a.packet_gid=b.packet_gid and b.delete_flag='N'"
            lsSql &= " cross join (select @rownr:=0) as t "
            lsSql &= " where b.packet_gid='" & lsPacketGid & "'"
            lsSql &= " and chq_gid=0 and a.delete_flag = 'N'"
            gvmInwardDetails.Columns.Clear()
            gpPopGridView(gvmInwardDetails, lsSql, gOdbcConn)

            If gvmInwardDetails.Rows.Count > 0 Then
                With gvmInwardDetails
                    .Columns("api_gid").Visible = False
                End With
            End If

            If rdoPending.Checked = True Then
                lsSql = ""
                lsSql &= " select @rownr:=@rownr+1 AS 'Serial No',scan_gid,scan_packet_gid,scan_chq_no as 'Cheque No',scan_chq_amount as 'Cheque Amount',"
                lsSql &= " scan_micr_code as 'Micr Code',scan_tran_code as 'Tran Code',scan_base_code as 'Base Code',scan_status"
                lsSql &= " from arms_trn_tscan as a inner join arms_trn_tpacket as b on a.scan_packet_gid=b.packet_gid "
                lsSql &= " and packet_status & " & GCPACKETSCANCOMPLETED & " = " & GCPACKETSCANCOMPLETED & " and packet_status & " & GCPACKETSCANAUDITED & " = 0  "
                lsSql &= " and scan_status & " & GCSCANAUDITED & " = 0"
                lsSql &= " and scan_status & " & GCSCANCANCELED & " = 0"
                lsSql &= " cross join (select @rownr:=0) as t "
                lsSql &= " where scan_packet_gid='" & lsPacketGid & "'"
                gvmChkrEntry.Columns.Clear()
                gpPopGridView(gvmChkrEntry, lsSql, gOdbcConn)

                If gvmChkrEntry.Rows.Count > 0 Then
                    With gvmChkrEntry
                        .Columns("scan_gid").Visible = False
                        .Columns("scan_packet_gid").Visible = False
                        .Columns("scan_status").Visible = False
                    End With
                End If
                CboPcktMode.Focus()

            ElseIf rdoCompleted.Checked = True Then

                lsSql = ""
                lsSql &= " select @rownr:=@rownr+1 AS 'Serial No',scan_gid,scan_packet_gid,scan_chq_no as 'Cheque No',scan_chq_amount as 'Cheque Amount',"
                lsSql &= " scan_micr_code as 'Micr Code',scan_tran_code as 'Tran Code',scan_base_code as 'Base Code',scan_status"
                lsSql &= " from arms_trn_tscan cross join (select @rownr:=0) as t "
                lsSql &= " where scan_status & " & GCSCANAUDITED & " = " & GCSCANAUDITED & " and scan_packet_gid='" & lsPacketGid & "'"
                lsSql &= " and scan_status & " & GCSCANCANCELED & " = 0"
                gvmChkrEntry.Columns.Clear()
                gpPopGridView(gvmChkrEntry, lsSql, gOdbcConn)
                With gvmChkrEntry
                    .Columns("scan_gid").Visible = False
                    .Columns("scan_packet_gid").Visible = False
                    .Columns("scan_status").Visible = False
                End With
            End If

            lsSql = ""
            lsSql &= " select count(*) from arms_trn_tscan "
            lsSql &= " where scan_packet_gid=" & lsPacketGid & " and scan_status & " & GCSCANAUDITED & " =0  "
            lsSql &= " and scan_status & " & GCSCANCANCELED & " = 0"

            lnPacketAuditCount = Val(gfExecuteScalar(lsSql, gOdbcConn))

            If lnPacketAuditCount = 0 Then
                MsgBox("Scan Audit Entry Completed Moved to Next Queue", MsgBoxStyle.Information, gsProjectName)
                Close()
            End If
        End If
    End Sub

    Private Sub gvmChkrEntry_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gvmChkrEntry.SelectionChanged

        Dim rowindex As New Integer

        Dim ScanImageGid As New Integer
        Dim ScanImageSide As String
        Dim lsSql As String
        Dim ds As New DataSet
        Dim ObjScanImage As New ScanEntryModel
        Dim lsMicrCode As String = ""

        rowindex = gvmChkrEntry.CurrentCell.RowIndex

        Scangid = Val(gvmChkrEntry.Rows(rowindex).Cells("scan_gid").Value.ToString())
        TxtChqNo.Text = gvmChkrEntry.Rows(rowindex).Cells("Cheque No").Value.ToString
        TxtMicrCode.Text = gvmChkrEntry.Rows(rowindex).Cells("Micr Code").Value.ToString

        If TxtMicrCode.Text <> "" Then
            If TxtMicrCode.Text.Length > 6 Then
                lsMicrCode = TxtMicrCode.Text.Substring(3, 3)
            Else
                TxtMicrCode.Text = ""
            End If
        End If

        lsSql = ""
        lsSql &= " select scanimage_gid,scanimage_side from arms_trn_tscanimage "
        lsSql &= " where scanimage_scan_gid='" & Scangid & "'"
        lsSql &= " and scanimage_type='G' and scanimage_side ='F'"
        gpDataSet(lsSql, "ScanImage", gOdbcConn, ds)

        If ds.Tables("ScanImage").Rows.Count > 0 Then
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                ScanImageGid = ds.Tables("ScanImage").Rows(i).Item("scanimage_gid").ToString()
                ScanImageSide = ds.Tables("ScanImage").Rows(i).Item("scanimage_side").ToString()
                ObjScanImage.scanimage_gid = ScanImageGid
                If ScanImageSide = "F" Then

                    ObjScanImage.scanImage_dtls = CallCholaApi(ObjScanImage)

                    If ObjScanImage.scanImage_dtls <> "" Then
                        Dim bytes() As Byte = Convert.FromBase64String(ObjScanImage.scanImage_dtls)
                        Dim MS As New System.IO.MemoryStream(bytes)
                        Dim bmp As Image = Image.FromStream(MS)
                        PicFrontSide.Image = bmp
                    Else
                        PicFrontSide.Image = Nothing
                    End If
                    PicBackSide.Image = Nothing
                    'ElseIf ScanImageSide = "R" Then
                    '    ObjScanImage.scanImage_dtls = CallCholaApi(ObjScanImage)

                    '    If ObjScanImage.scanImage_dtls <> "" Then
                    '        Dim bytes() As Byte = Convert.FromBase64String(ObjScanImage.scanImage_dtls)
                    '        Dim MS As New System.IO.MemoryStream(bytes)
                    '        Dim bmp As Image = Image.FromStream(MS)
                    '        PicBackSide.Image = bmp
                    '    Else
                    '        PicBackSide.Image = Nothing
                    '    End If

                End If

            Next
        End If

        lsSql = ""
        lsSql &= " select bank_code,bank_name from arms_mst_tmicr "
        lsSql &= " where micr_code='" & TxtMicrCode.Text.Trim & "'"
        gpDataSet(lsSql, "BankMaster", gOdbcConn, ds)

        If ds.Tables("BankMaster").Rows.Count > 0 Then
            TxtBankCode.Text = ds.Tables("BankMaster").Rows(0).Item("bank_code").ToString
            TxtBankName.Text = ds.Tables("BankMaster").Rows(0).Item("bank_name").ToString
            TxtBankName.Enabled = False
        Else
            TxtBankCode.Text = ""
            TxtBankName.Text = ""
        End If
        CboPcktMode.Focus()

    End Sub

    Private Sub CboPcktMode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboPcktMode.SelectedIndexChanged
        If CboPcktMode.Text = "SPDC" Then
            mstchqdate.Enabled = True
            txtchqamt.Enabled = True
            TxtBankCode.Enabled = True
            txtaccno.Enabled = True
            'TxtBankCode.Focus()
            txtaccno.ReadOnly = False
            PnlPdcEntry.Visible = True
        ElseIf CboPcktMode.Text = "PDC" Then
            mstchqdate.Enabled = True
            txtchqamt.Enabled = True
            TxtBankCode.Enabled = True
            txtaccno.Enabled = True
            PnlPdcEntry.Visible = True
            'mstchqdate.Focus()
        ElseIf CboPcktMode.Text = "Others" Then
            mstchqdate.Enabled = False
            txtchqamt.Enabled = False
            TxtBankCode.Enabled = False
            TxtBankName.Enabled = False
            txtaccno.Enabled = False
            PnlPdcEntry.Visible = True
            PnlPdcEntry.Visible = True
            'TxtRemarks.Focus()
        ElseIf CboPcktMode.Text = "Mandate" Then
            mstchqdate.Enabled = False
            txtchqamt.Enabled = False
            TxtBankCode.Enabled = False
            TxtBankName.Enabled = False
            txtaccno.Enabled = False
            PnlPdcEntry.Visible = False
            Pnlchqdtls.Visible = False
            TxtChqNo.Text = ""
            txtchqamt.Text = ""
            'mtxtstartdate.Focus()
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Dim lsSql As String
        If MsgBox("Are you sure you want to close?", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2, gsProjectName) = MsgBoxResult.No Then
            Exit Sub
        End If

        lsSql = ""
        lsSql &= " Update arms_trn_tpacket set"
        lsSql &= " gnsa_lock_flag='N' ,"
        lsSql &= " gnsa_lock_date=now(),"
        lsSql &= " gnsa_lock_by='" & gsLoginUserCode & "'"
        lsSql &= " where packet_gid=" & lsPacketGid
        gfExecuteQry(lsSql, gOdbcConn)

        Me.Close()
    End Sub

    Private Sub txtchqamt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtchqamt.KeyPress
        If e.KeyChar = "13" Then
            SendKeys.Send("{tab}")
            Exit Sub
        End If
        If CboPcktMode.Text = "PDC" Then
            If Not IsDate(mstchqdate.Text) Then
                e.Handled = True
                MsgBox("Please Enter Cheque Date", MsgBoxStyle.Critical, gsProjectName)
                ' MessageBox.Show("Please Enter Cheque Date", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtchqamt.Text = ""
                mstchqdate.Focus()
                Exit Sub
            End If
        End If

        e.Handled = gfAmountEntryOnly(e, txtchqamt)

    End Sub

    Private Sub txtchqamt_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If txtchqamt.Text.ToString() <> "" Then
            Dim currentvalue As String = ""
            If Convert.ToDouble(txtchqamt.Text) > 0 Then
                count += 1
                If count = 1 Then
                    prvvalue = txtchqamt.Text
                    txtchqamt.Clear()
                    txtchqamt.Focus()
                ElseIf count = 2 Then
                    currentvalue = txtchqamt.Text
                    If prvvalue.Equals(currentvalue) Then
                        count = 0
                        prvvalue = ""
                        currentvalue = ""
                    Else
                        count = 0
                        txtchqamt.Clear()
                        txtchqamt.Focus()
                        MsgBox("Amount mismatch ! Reenter the amount", MsgBoxStyle.Critical, gsProjectName)

                    End If
                Else
                    count = 0
                    txtchqamt.Clear()
                    txtchqamt.Focus()
                    MsgBox("Reenter The Amount", MsgBoxStyle.MsgBoxHelp, gsProjectName)
                End If
            Else

                If CboPcktMode.Text = "PDC" Then
                    MsgBox("Amount Cannot Be Empty", MsgBoxStyle.Critical, gsProjectName)
                    txtchqamt.Focus()
                End If
            End If
        Else
            If CboPcktMode.Text = "PDC" Then
                MsgBox("Invalid cheque amount !", MsgBoxStyle.Exclamation, gsProjectName)
                Exit Sub
            End If

        End If
    End Sub

    Private Sub TxtBankCode_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBankCode.Leave
        Dim lsSql As String = ""
        Dim ds As New DataSet
        If TxtBankCode.Text <> "" Then
            If TxtBankCode.Text.ToUpper = "XXX" Then
                TxtBankName.Enabled = True
                TxtBankName.Focus()
            ElseIf TxtBankCode.Text <> "" Then
                lsSql = ""
                lsSql &= " select bank_code,bank_name from arms_mst_tmicr"
                lsSql &= " where bank_code='" & TxtBankCode.Text & "'"
                gpDataSet(lsSql, "BankMaster", gOdbcConn, ds)

                If ds.Tables("BankMaster").Rows.Count > 0 Then
                    TxtBankCode.Text = ds.Tables("BankMaster").Rows(0).Item("bank_code").ToString
                    TxtBankName.Text = ds.Tables("BankMaster").Rows(0).Item("bank_name").ToString
                    TxtBankName.Enabled = False
                Else
                    MsgBox("Bank Code not there in Bank Master!", MsgBoxStyle.Critical, gsProjectName)
                    TxtBankCode.Focus()
                    Exit Sub
                End If
            End If
            'Else
            '    MsgBox("Bank Code Cannot Be Empty", MsgBoxStyle.Critical, gProjectName)
            '    txtchqamt.Focus()
            '    Exit Sub
        End If
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If CboPcktMode.Text <> "" Then
            Dim frmDiscEntry As New frmDiscAdd(CboPcktMode.Text)
            frmDiscEntry.ShowDialog()
            TxtDiscValue.Text = GCScanDiscValue
            btnSave.Focus()
        Else
            MsgBox("Packet Mode Cannot Be Empty", MsgBoxStyle.Critical, gsProjectName)
        End If

    End Sub

    Private Sub RdiNo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdiNo.CheckedChanged
        If RdiNo.Checked = True Then
            btnAdd.Enabled = False
            TxtDiscValue.Text = "0"
        End If
    End Sub

    Private Sub RdiYes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdiYes.CheckedChanged
        If RdiYes.Checked = True Then
            btnAdd.Enabled = True
        End If
    End Sub

    Private Function CallCholaApi(ByVal ObjScanImage As ScanEntryModel) As String

        Dim reqString() As Byte
        Dim resByte As Byte()
        Dim responseFromApi As String
        'Dim endPoint As String = "http://localhost:8556/api/Scan/viewimage"
        'Dim endPoint As String = "http://192.168.0.154:106/api/Scan/viewimage" 'UAT Api
        Dim endPoint As String = "http://192.168.0.22:8601/api/Scan/viewimage" 'Current Live Api
        ' Dim endPoint As String = "http://192.168.0.11:105/api/Scan/viewimage" 'Existing Live Api
        Dim client As WebClient = New WebClient()
        client.Headers("Content-type") = "application/json"
        client.Encoding = System.Text.Encoding.UTF8
        Dim jsonReq = JsonConvert.SerializeObject(ObjScanImage, Formatting.Indented)
        reqString = System.Text.Encoding.Default.GetBytes(jsonReq)

        resByte = client.UploadData(endPoint, "post", reqString)
        responseFromApi = System.Text.Encoding.Default.GetString(resByte)
        Dim tempPost = New With {Key .scanImage_dtls = ""}
        Dim post = JsonConvert.DeserializeAnonymousType(responseFromApi, tempPost)
        Dim scandetails As String = post.scanImage_dtls
        Return scandetails

    End Function

    Private Sub frmImageBaseEntry_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        'pnlHeader.Width = Me.Width - pnlHeader.Left * 2 - 8

        pnlEntry.Width = 264
        Pnlchqdtls.Width = 264
        PnlPdcEntry.Width = 264
        PnlBankdtls.Width = 264
        pnlcustinfo.Width = 264

        PicFrontSide.Top = pnlHeader.Top + pnlHeader.Height + 8
        PicFrontSide.Left = pnlHeader.Left
        PicFrontSide.Width = Me.Width - pnlEntry.Width - 48
        PicFrontSide.Height = Me.Height - PicFrontSide.Top - TabChqDetails.Height - 40

        pnlEntry.Left = PicFrontSide.Left + PicFrontSide.Width + 8
        Pnlchqdtls.Left = pnlEntry.Left
        PnlPdcEntry.Left = pnlEntry.Left
        PnlBankdtls.Left = pnlEntry.Left
        pnlcustinfo.Left = pnlEntry.Left

        TabChqDetails.Top = PicFrontSide.Top + PicFrontSide.Height + 8
        TabChqDetails.Width = Me.Width - 20

        gvmChkrEntry.Height = TabChqDetails.Height - 32

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim drpacket As MySqlDataReader
        Dim drpdc As MySqlDataReader
        Dim drambo_micr As MySqlDataReader
        Dim drambo As MySqlDataReader


        Dim lnPacketGid As Long
        Dim lnEntityGid As Long
        Dim lnFileGid As Long


        Dim lnApiGid As Long = 0
        Dim lsPayeeName As String = ""
        Dim lsLocCode As String = ""
        Dim lnProdFlag As Integer
        Dim lsChqAccNo As String = ""
        Dim lsChqType As String = ""
        Dim lsBankBranch As String = ""

        Dim lsScanStatus As Long = 0
        Dim lsSql As String = ""
        Dim lsChqDate As String = ""
        Dim lsChqAmount As Long = 0
        Dim lsPacketMode As String = ""
        Dim lsScanVisibility As String = ""
        Dim lsScanDiscFlag As String = ""
        Dim lnAuditCount As Long = 0
        Dim lnReScanCount As Long = 0
        Dim lsEntryMode As String = ""

        Dim lschqdisc As String = ""
        Dim lsiscts As Char = ""

        Dim lcPacketDisc As String = ""

        Dim lspap As String = ""
        Dim lsMicrCode As String = ""

        Dim lsChqMode As String = ""
        Dim lcChqDisc As String = ""

        Dim lsismicr As String = ""

        Dim lnTenorCycle As Long = 0

        Dim lsStartDate As String = ""
        Dim lsEndDate As String = ""

        Dim lnResult As Long = 0
        Dim lnChqId As Long = 0

        Dim n As Integer

        If MsgBox("Are you sure you want to Submit?", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2, gsProjectName) = MsgBoxResult.No Then
            Exit Sub
        End If

        If txtchqamt.Text <> "" Then
            lsChqAmount = txtchqamt.Text
        End If

        If RdiChqYes.Checked = True Then

            If CboPcktMode.Text = "" Then
                MsgBox("Please Select Packet Mode..!", MsgBoxStyle.Critical, gsProjectName)
                CboPcktMode.Focus()
                Exit Sub
            End If

            If RdoYetConfirm.Checked = True Then
                MsgBox("Please Confirm Disc Mode..!", MsgBoxStyle.Critical, gsProjectName)
                RdoYetConfirm.Focus()
                Exit Sub
            End If

            If CboPcktMode.Text.ToUpper = "PDC" Then

                If TxtChqNo.Text = "" Then
                    MsgBox("Please Enter the Cheque No..!", MsgBoxStyle.Critical, gsProjectName)
                    TxtChqNo.Focus()
                    Exit Sub
                End If
                If TxtMicrCode.Text = "" Then
                    MsgBox("Please Enter the Micr Code..!", MsgBoxStyle.Critical, gsProjectName)
                    TxtChqNo.Focus()
                    Exit Sub
                End If
                If Not IsDate(mstchqdate.Text) Then
                    MsgBox("Please Enter the Cheque Date..!", MsgBoxStyle.Critical, gsProjectName)
                    mstchqdate.Focus()
                    Exit Sub
                End If
                If Convert.ToDouble(txtchqamt.Text) = 0 Then
                    MsgBox("Cheque Amount Cannot be empty..!", MsgBoxStyle.Critical, gsProjectName)
                    txtchqamt.Focus()
                    Exit Sub
                End If
                If TxtBankCode.Text = "" Then
                    MsgBox("Bank Code Cannot be empty..!", MsgBoxStyle.Critical, gsProjectName)
                    TxtBankCode.Focus()
                    Exit Sub
                End If
                If TxtBankName.Text = "" Then
                    MsgBox("Bank Name Cannot be empty..!", MsgBoxStyle.Critical, gsProjectName)
                    TxtBankName.Focus()
                    Exit Sub
                End If
            ElseIf CboPcktMode.Text.ToUpper = "SPDC" Then
                If TxtChqNo.Text = "" Then
                    MsgBox("Please Enter the Cheque No..!", MsgBoxStyle.Critical, gsProjectName)
                    TxtChqNo.Focus()
                    Exit Sub
                End If
                If TxtMicrCode.Text = "" Then
                    MsgBox("Please Enter the Micr Code..!", MsgBoxStyle.Critical, gsProjectName)
                    TxtChqNo.Focus()
                    Exit Sub
                End If
                If TxtBankCode.Text = "" Then
                    MsgBox("Bank Code Cannot be empty..!", MsgBoxStyle.Critical, gsProjectName)
                    TxtBankCode.Focus()
                    Exit Sub
                End If
                If TxtBankName.Text = "" Then
                    MsgBox("Bank Name Cannot be empty..!", MsgBoxStyle.Critical, gsProjectName)
                    TxtBankName.Focus()
                    Exit Sub
                End If

                If txtchqamt.Text = "" Then
                    lsChqAmount = 0
                End If
            End If

            lsScanStatus = GCSCANVALID
        End If

        If RdiYes.Checked = True Then
            If TxtDiscValue.Text = "" Or TxtDiscValue.Text = "0" Then
                MsgBox("Please Select Disc List..!", MsgBoxStyle.Critical, gsProjectName)
                btnAdd.Focus()
                Exit Sub
            End If

            If txtchqamt.Text = "" Then
                lsChqAmount = 0
            End If

            lsScanStatus = GCSCANINVALID
        End If

        If CboPcktMode.Text.ToUpper = "PDC" Then
            lsPacketMode = "P"
        ElseIf CboPcktMode.Text = "SPDC" Then
            lsPacketMode = "S"
        ElseIf CboPcktMode.Text.ToUpper = "OTHERS" Then
            lsPacketMode = "O"
        ElseIf CboPcktMode.Text.ToUpper = "MANDATE" Then
            lsPacketMode = "M"
        End If

        If RdiChqNo.Checked = True Then
            lsScanVisibility = "N"
        ElseIf RdiChqYes.Checked = True Then
            lsScanVisibility = "Y"
        End If

        If RdiNo.Checked = True Then
            lsScanDiscFlag = "N"
        ElseIf RdiYes.Checked = True Then
            lsScanDiscFlag = "Y"
        End If

        If Not IsDate(mstchqdate.Text) Then
            lsChqDate = "null"
        Else
            lsChqDate = Format(CDate(mstchqdate.Text.Trim), "yyyy-MM-dd")
        End If

        lsSql = " select packet_gid,entity_gid,file_gid from arms_trn_tpacket"
        lsSql &= " where packet_gid='" & TxtPacketId.Text.Trim & "'"
        lsSql &= " and delete_flag='N'"

        drpacket = gfExecuteQry(lsSql, gOdbcConn)

        If drpacket.HasRows Then
            While drpacket.Read
                lnPacketGid = Val(drpacket.Item("packet_gid").ToString)
                lnEntityGid = Val(drpacket.Item("entity_gid").ToString)
                lnFileGid = Val(drpacket.Item("file_gid").ToString)
            End While
        Else
            MsgBox("Invalid Packet", MsgBoxStyle.OkOnly + MsgBoxStyle.Information + MsgBoxStyle.DefaultButton2, gsProjectName)
            Exit Sub
        End If

        If RdiChqYes.Checked = True Then
            lsSql = ""
            lsSql &= " select micr_code "
            lsSql &= " from arms_trn_taplobinput"
            lsSql &= " where entity_gid=" & lnEntityGid & ""
            lsSql &= " and file_gid=" & lnFileGid & ""
            lsSql &= " and lot_no='" & TxtLotNo.Text.Trim & "'"
            lsSql &= " and contract_no='" & TxtContractNo.Text.Trim & "'"
            lsSql &= " and chq_date='" & lsChqDate & "'"
            lsSql &= " and chq_no='" & TxtChqNo.Text.Trim & "'"
            lsSql &= " and packet_gid=" & lnPacketGid & ""
            lsSql &= " and chq_gid = 0 "
            lsSql &= " and delete_flag = 'N' "

            drambo_micr = gfExecuteQry(lsSql, gOdbcConn)
            If drambo_micr.HasRows Then
                While drambo_micr.Read
                    lsMicrCode = drambo_micr.Item("micr_code").ToString
                End While

            End If

            If lsMicrCode = "000000000" Then
                lsSql = ""
                lsSql &= " select api_gid,payee_name,prod_flag,cheque_type,loc_code,bank_branch,chq_acc_no,micr_code "
                lsSql &= " from arms_trn_taplobinput"
                lsSql &= " where entity_gid=" & lnEntityGid & ""
                lsSql &= " and file_gid=" & lnFileGid & ""
                lsSql &= " and lot_no='" & TxtLotNo.Text.Trim & "'"
                lsSql &= " and contract_no='" & TxtContractNo.Text.Trim & "'"
                lsSql &= " and chq_amount='" & txtchqamt.Text.Trim & "'"
                lsSql &= " and chq_date='" & lsChqDate & "'"
                lsSql &= " and chq_no='" & TxtChqNo.Text.Trim & "'"
                lsSql &= " and packet_gid=" & lnPacketGid & ""
                lsSql &= " and chq_gid = 0 "
                lsSql &= " and delete_flag = 'N' "

                drambo = gfExecuteQry(lsSql, gOdbcConn)

                If drambo.HasRows Then
                    While drambo.Read
                        lnApiGid = Val(drambo.Item("api_gid").ToString)
                        lsPayeeName = drambo.Item("payee_name").ToString
                        lnProdFlag = Val(drambo.Item("prod_flag").ToString)
                        lsChqType = drambo.Item("cheque_type").ToString
                        lsLocCode = drambo.Item("loc_code").ToString
                        lsBankBranch = drambo.Item("bank_branch").ToString
                        lsChqAccNo = drambo.Item("chq_acc_no").ToString
                        lsMicrCode = drambo.Item("micr_code").ToString
                    End While

                End If
            Else
                lsSql = ""
                lsSql &= " select api_gid,payee_name,prod_flag,cheque_type,loc_code,bank_branch,chq_acc_no,micr_code "
                lsSql &= " from arms_trn_taplobinput"
                lsSql &= " where entity_gid=" & lnEntityGid & ""
                lsSql &= " and file_gid=" & lnFileGid & ""
                lsSql &= " and lot_no='" & TxtLotNo.Text.Trim & "'"
                lsSql &= " and contract_no='" & TxtContractNo.Text.Trim & "'"
                lsSql &= " and chq_amount='" & txtchqamt.Text.Trim & "'"
                lsSql &= " and chq_date='" & lsChqDate & "'"
                lsSql &= " and chq_no='" & TxtChqNo.Text.Trim & "'"
                lsSql &= " and micr_code='" & TxtMicrCode.Text.Trim & "'"
                lsSql &= " and packet_gid=" & lnPacketGid & ""
                lsSql &= " and chq_gid = 0 "
                lsSql &= " and delete_flag = 'N' "

                drambo = gfExecuteQry(lsSql, gOdbcConn)

                If drambo.HasRows Then
                    While drambo.Read
                        lnApiGid = Val(drambo.Item("api_gid").ToString)
                        lsPayeeName = drambo.Item("payee_name").ToString
                        lnProdFlag = Val(drambo.Item("prod_flag").ToString)
                        lsChqType = drambo.Item("cheque_type").ToString
                        lsLocCode = drambo.Item("loc_code").ToString
                        lsBankBranch = drambo.Item("bank_branch").ToString
                        lsChqAccNo = drambo.Item("chq_acc_no").ToString
                        lsMicrCode = drambo.Item("micr_code").ToString
                    End While

                End If
            End If
        End If

        If lnApiGid = 0 Then
            If MsgBox("Inward Entry Mismatch,Are you sure you want to Continue?", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2, gsProjectName) = MsgBoxResult.No Then
                Exit Sub
            End If
            If MsgBoxResult.Yes Then

                EnableCustinfo()
                If txtCustname.Text = "" Then
                    MsgBox("Please enter customer name..!", MsgBoxStyle.Critical, gsProjectName)
                    txtCustname.Focus()
                    Return
                End If

                If cmbLoc.Text = "" Then
                    MsgBox("Please select Location..!", MsgBoxStyle.Critical, gsProjectName)
                    cmbLoc.Focus()
                    Return
                End If

                If cboProdcode.Text = "" Then
                    MsgBox("Please select Product..!", MsgBoxStyle.Critical, gsProjectName)
                    cboProdcode.Focus()
                    Return
                End If

                lsPayeeName = txtCustname.Text.ToString()
                lsLocCode = cmbLoc.SelectedValue.ToString()
                lnProdFlag = cboProdcode.SelectedValue.ToString()

                If RdiChqYes.Checked = True Then
                    lsSql = ""
                    lsSql &= " select api_gid,payee_name,prod_flag,cheque_type,loc_code,bank_branch,chq_acc_no "
                    lsSql &= " from arms_trn_taplobinput"
                    lsSql &= " where entity_gid=" & lnEntityGid & ""
                    lsSql &= " and file_gid=" & lnFileGid & ""
                    lsSql &= " and lot_no='" & TxtLotNo.Text.Trim & "'"
                    lsSql &= " and contract_no='" & TxtContractNo.Text.Trim & "'"
                    lsSql &= " and chq_amount='" & txtchqamt.Text.Trim & "'"
                    lsSql &= " and chq_date='" & lsChqDate & "'"
                    lsSql &= " and chq_no='" & TxtChqNo.Text.Trim & "'"
                    'lsSql &= " and micr_code='" & TxtMicrCode.Text.Trim & "'"
                    lsSql &= " and packet_gid=" & lnPacketGid & ""
                    lsSql &= " and chq_gid = 0 "
                    lsSql &= " and delete_flag = 'N' "

                    drambo = gfExecuteQry(lsSql, gOdbcConn)

                    If drambo.HasRows Then
                        While drambo.Read
                            lnApiGid = Val(drambo.Item("api_gid").ToString)
                            lsPayeeName = drambo.Item("payee_name").ToString
                            lnProdFlag = Val(drambo.Item("prod_flag").ToString)
                            lsChqType = drambo.Item("cheque_type").ToString
                            lsLocCode = drambo.Item("loc_code").ToString
                            lsBankBranch = drambo.Item("bank_branch").ToString
                            lsChqAccNo = drambo.Item("chq_acc_no").ToString
                        End While
                    End If
                End If
            End If

        End If


        If RdiChqNo.Checked = True Then
            If txtchqamt.Text = "" Then
                lsChqAmount = 0
            End If
            lsScanStatus = GCSCANRESCAN
        End If

        lsSql = ""
        lsSql &= " update arms_trn_tscan set"
        'lsSql &= " scan_chq_no='" & TxtChqNo.Text.Trim & "',"
        'lsSql &= " scan_micr_code='" & TxtMicrCode.Text & "',"
        lsSql &= " scan_chq_date='" & lsChqDate & "',"
        lsSql &= " scan_chq_amount='" & lsChqAmount & "',"
        lsSql &= " scan_chq_accno='" & txtaccno.Text.Trim & "',"
        lsSql &= " scan_bank_code='" & TxtBankCode.Text & "',"
        lsSql &= " scan_bank_name='" & TxtBankName.Text & "',"
        lsSql &= " scan_chq_type='" & lsPacketMode & "',"
        lsSql &= " scan_visibility='" & lsScanVisibility & "',"
        lsSql &= " disc_flag='" & lsScanDiscFlag & "',"
        lsSql &= " scan_disc_value='" & TxtDiscValue.Text & "',"
        lsSql &= " scan_status= scan_status | " & GCSCANAUDITED & " |" & lsScanStatus & ","
        lsSql &= " scan_remark='" & TxtRemarks.Text & "'"
        lsSql &= " where scan_gid=" & Scangid
        lsSql &= " and scan_packet_gid=" & lnPacketGid

        gfExecuteQry(lsSql, gOdbcConn)
        lsSql = ""
        lsSql &= " select count(*) from arms_trn_tscan "
        lsSql &= " where scan_packet_gid=" & lnPacketGid & " and scan_status & " & GCSCANAUDITED & " =0 "
        lsSql &= " and scan_status & " & GCSCANCANCELED & " =0 "

        lnAuditCount = Val(gfExecuteScalar(lsSql, gOdbcConn))

        If lnAuditCount = 0 Then
            lsSql = ""
            lsSql &= " select count(*) from arms_trn_tscan "
            lsSql &= " where scan_packet_gid=" & lnPacketGid & " and scan_status & " & GCSCANRESCAN & " >0  "
            lnReScanCount = Val(gfExecuteScalar(lsSql, gOdbcConn))
        End If

        If lnAuditCount = 0 And lnReScanCount > 0 Then
            lsSql = ""
            lsSql &= " Update arms_trn_tpacket set"
            lsSql &= " packet_status=(packet_status | " & GCPACKETRESCAN & ") ^ " & GCPACKETSCANCOMPLETED & ","
            lsSql &= " gnsa_lock_flag='N' ,"
            lsSql &= " gnsa_lock_date=now(),"
            lsSql &= " gnsa_lock_by='" & gsLoginUserCode & "'"
            lsSql &= " where packet_gid=" & lnPacketGid
            gfExecuteQry(lsSql, gOdbcConn)

        End If

        If lnReScanCount = 0 Then
            If RdiChqYes.Checked = True Then
                gsQry = ""
                gsQry &= " insert into arms_trn_tcheque ("
                gsQry &= " packet_gid,entity_gid,file_gid,contract_no,payee_name,loc_code,prod_flag,cycle_date,chq_date,chq_no,chq_amount,chq_acc_no,micr_code,"
                gsQry &= " bank_code,bank_name,bank_branch,chq_type,atpar_flag,cts_flag,cts_disc,chq_disc,chq_status,packet_no,"
                gsQry &= " org_chq_date,org_chq_no,org_chq_amount,available_flag) values ("
                gsQry &= " " & lnPacketGid & ","
                gsQry &= " " & lnEntityGid & ","
                gsQry &= " " & lnFileGid & ","
                gsQry &= " '" & lsContractNo & "',"
                gsQry &= " '" & lsPayeeName & "',"
                gsQry &= " '" & lsLocCode & "',"
                gsQry &= " '" & lnProdFlag & "',"
                gsQry &= " '" & lsChqDate & "',"
                gsQry &= " '" & lsChqDate & "',"
                gsQry &= " '" & TxtChqNo.Text.Trim & "',"
                gsQry &= " '" & txtchqamt.Text.Trim & "',"
                gsQry &= "'" & lsChqAccNo & "',"
                gsQry &= " '" & TxtMicrCode.Text.Trim & "',"
                gsQry &= " '" & TxtBankCode.Text.Trim & "',"
                gsQry &= " '" & TxtBankName.Text.Trim & "',"
                gsQry &= " '" & lsBankBranch & "',"
                gsQry &= " '" & CboPcktMode.Text & "',"
                gsQry &= " 'Y',"
                gsQry &= " 'Y',"
                gsQry &= " 0,"
                gsQry &= " " & Val(TxtDiscValue.Text.Trim) & ","

                If Val(TxtDiscValue.Text.Trim) = 0 Then
                    gsQry &= " 0,"
                Else
                    gsQry &= " " & gnChqDisc.ToString & ","
                End If

                gsQry &= " '" & lsCoverNo & "',"
                gsQry &= " '" & lsChqDate & "',"
                gsQry &= " '" & TxtChqNo.Text.Trim & "',"
                gsQry &= " '" & txtchqamt.Text.Trim & "',1)"

                lnResult = gfInsertQry(gsQry, gOdbcConn)

                ' Find chq id
                gsQry = ""
                gsQry &= " select max(chq_gid) from arms_trn_tcheque "
                gsQry &= " where packet_gid = " & lnPacketGid & " "
                gsQry &= " and chq_date = '" & lsChqDate & "' "
                gsQry &= " and chq_no='" & TxtChqNo.Text.Trim & "'"
                gsQry &= " and delete_flag = 'N' "

                lnChqId = Val(gfExecuteScalar(gsQry, gOdbcConn))

                If lnApiGid > 0 Then
                    gsQry = ""
                    gsQry &= " update arms_trn_taplobinput set "
                    gsQry &= " packet_gid = " & lnPacketGid & ","
                    gsQry &= " chq_gid = " & lnChqId & " "
                    gsQry &= " where api_gid = " & lnApiGid & " "
                    gsQry &= " and chq_gid = 0 "
                    gsQry &= " and delete_flag = 'N' "

                    lnResult = gfInsertQry(gsQry, gOdbcConn)

                    gsQry = ""
                    gsQry &= " update arms_trn_tcheque set "
                    gsQry &= " aplobinput_gid = " & lnApiGid.ToString() + ","
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
                    gsQry &= " and a.api_gid = " & lnApiGid & " "
                    gsQry &= "and a.packet_gid = " & lnPacketGid & ""

                    lnResult = gfInsertQry(gsQry, gOdbcConn)
                End If

                lsSql = ""
                lsSql &= " Update arms_trn_tscan set "
                lsSql &= " scan_chq_type='" & lsPacketMode & "',"
                lsSql &= " scan_chq_gid=" & lnChqId & ""
                lsSql &= " where scan_chq_no='" & TxtChqNo.Text.Trim & "'"
                lsSql &= " and scan_packet_gid=" & lnPacketGid & ""
                lsSql &= " and scan_gid=" & Scangid

                gfInsertQry(lsSql, gOdbcConn)
            End If
        End If

        If RdiChqYes.Checked = True Then
            If lnAuditCount = 0 And lnReScanCount = 0 Then
                lsSql = ""
                lsSql &= " Update arms_trn_tpacket set"
                lsSql &= " packet_status=packet_status | " & GCPACKETSCANAUDITED & " , "
                lsSql &= " gnsa_lock_flag='N',"
                lsSql &= " gnsa_lock_date=now(),"
                lsSql &= " gnsa_lock_by='" & gsLoginUserCode & "'"
                lsSql &= " where packet_gid=" & lnPacketGid
                gfExecuteQry(lsSql, gOdbcConn)

            End If
        End If


        TxtChqNo.Text = ""
        mstchqdate.Text = ""
        txtchqamt.Text = ""
        TxtBankCode.Text = ""
        TxtBankName.Text = ""
        'txtaccno.Text = ""
        TxtRemarks.Text = ""
        TxtDiscValue.Text = 0
        RdoYetConfirm.Checked = True
        LoadGridData(lsPacketGid)
    End Sub

    Private Sub RdiChqYes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdiChqYes.CheckedChanged
        If RdiChqYes.Checked = True Then
            Pnlchqdtls.Enabled = True
            PnlPdcEntry.Enabled = True
            Panel2.Enabled = True
        End If
    End Sub

    Private Sub RdiChqNo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdiChqNo.CheckedChanged
        If RdiChqNo.Checked = True Then
            Pnlchqdtls.Enabled = False
            PnlPdcEntry.Enabled = False
            Panel2.Enabled = False
        End If
        TxtRemarks.Focus()
    End Sub

    Private Sub rdoPending_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoPending.CheckedChanged
        LoadGridData(lsPacketGid)
    End Sub

    Private Sub rdoCompleted_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoCompleted.CheckedChanged
        LoadGridData(lsPacketGid)
    End Sub

    Private Sub TxtTenorCount_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = gfIntEntryOnly(e)
    End Sub

    Private Sub TxtChqNo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtChqNo.KeyPress
        e.Handled = gfIntEntryOnly(e)
    End Sub

    Private Sub TxtMicrCode_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMicrCode.KeyPress
        e.Handled = gfIntEntryOnly(e)
    End Sub

    Private Sub frmImageBaseEntry_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then SendKeys.Send("{TAB}")
    End Sub
End Class