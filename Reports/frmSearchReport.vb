Imports System.Net
Imports System.IO
Imports System.Text
Imports Newtonsoft.Json
Imports MySql.Data.MySqlClient
Public Class frmSearchReport
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

        Me.KeyPreview = True

        RdiChqYes.Checked = True


        txtaccno.Clear()

        PnlPdcEntry.Visible = True


    End Sub
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
       
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

        Scangid = gvmChkrEntry.Rows(rowindex).Cells("scan_gid").Value.ToString
        TxtChqNo.Text = gvmChkrEntry.Rows(rowindex).Cells("Cheque No").Value.ToString
        TxtMicrCode.Text = gvmChkrEntry.Rows(rowindex).Cells("Micr Code").Value.ToString

        TxtPaymode.Text = gvmChkrEntry.Rows(rowindex).Cells("Pay_Mode").Value.ToString
        TxtRemarks.Text = gvmChkrEntry.Rows(rowindex).Cells("Reason").Value.ToString
        mstchqdate.Text = gvmChkrEntry.Rows(rowindex).Cells("Chq Date").Value.ToString
        TxtChqNo.Text = gvmChkrEntry.Rows(rowindex).Cells("Cheque No").Value.ToString
        txtchqamt.Text = gvmChkrEntry.Rows(rowindex).Cells("Cheque Amount").Value.ToString
        txtaccno.Text = gvmChkrEntry.Rows(rowindex).Cells("Chq_Accno").Value.ToString
        TxtBankCode.Text = gvmChkrEntry.Rows(rowindex).Cells("Bank Code").Value.ToString
        TxtBankName.Text = gvmChkrEntry.Rows(rowindex).Cells("Bank Name").Value.ToString
        TxtTotalChq.Text = gvmChkrEntry.Rows(rowindex).Cells("tot_chqs").Value.ToString
        TxtEntityName.Text = gvmChkrEntry.Rows(rowindex).Cells("entity_name").Value.ToString
        TxtLotNo.Text = gvmChkrEntry.Rows(rowindex).Cells("lot_no").Value.ToString
        TxtContractNo.Text = gvmChkrEntry.Rows(rowindex).Cells("contract_no").Value.ToString




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

                End If
            Next
        End If

        TxtPaymode.Focus()

    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Function CallCholaApi(ByVal ObjScanImage As ScanEntryModel) As String

        Dim reqString() As Byte
        Dim resByte As Byte()
        Dim responseFromApi As String
        '  Dim endPoint As String = "http://localhost:8556/api/Scan/viewimage"
        Dim endPoint As String = "http://192.168.0.154:106/api/Scan/viewimage"
        ' Dim endPoint As String = "http://192.168.0.22:105/api/Scan/viewimage"
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

        PicFrontSide.Top = pnlHeader.Top + pnlHeader.Height + 8
        PicFrontSide.Left = pnlHeader.Left
        PicFrontSide.Width = Me.Width - pnlEntry.Width - 48
        PicFrontSide.Height = Me.Height - PicFrontSide.Top - pnlChq.Height - 40

        pnlEntry.Left = PicFrontSide.Left + PicFrontSide.Width + 8
        Pnlchqdtls.Left = pnlEntry.Left
        PnlPdcEntry.Left = pnlEntry.Left
        PnlBankdtls.Left = pnlEntry.Left

        pnlChq.Top = PicFrontSide.Top + PicFrontSide.Height + 8
        pnlChq.Width = Me.Width - 20

        gvmChkrEntry.Height = pnlChq.Height - 32

    End Sub

    Private Sub RdiChqYes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdiChqYes.CheckedChanged
        If RdiChqYes.Checked = True Then
            Pnlchqdtls.Enabled = True
            PnlPdcEntry.Enabled = True
        End If
    End Sub

    Private Sub RdiChqNo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdiChqNo.CheckedChanged
        If RdiChqNo.Checked = True Then
            Pnlchqdtls.Enabled = False
            PnlPdcEntry.Enabled = False
        End If
        TxtRemarks.Focus()
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

    Private Sub btnRefresh_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        Dim lsSql As String
        Dim lnPktId As Long = 0
        Dim ds As New DataSet
        Dim lsCond As String
        ' Find Agreement Id
        If TxtCoverNo.Text.Trim = "" Then

            MsgBox("Please Enter the Cover No..!", MsgBoxStyle.Critical, gsProjectName)
            TxtCoverNo.Focus()
            Exit Sub
        End If
        lsCond = ""
        If TxtCoverNo.Text.Trim <> "" Then
            lsCond &= " and b.cover_no = '" & TxtCoverNo.Text.Trim & "' "
        End If
        If TxtLotNo.Text.Trim <> "" Then
            lsCond &= " and b.lot_no = '" & TxtCoverNo.Text.Trim & "' "
        End If
        If TxtContractNo.Text.Trim <> "" Then
            lsCond &= " and b.contract_no = '" & TxtContractNo.Text.Trim & "' "
        End If

        lsSql = ""
        lsSql &= "  select @rownr:=@rownr+1 AS 'Serial No',scan_gid,scan_packet_gid,c.chq_no as 'Cheque No',c.chq_amount as 'Cheque Amount',"
        lsSql &= "  scan_micr_code as 'Micr Code',scan_tran_code as 'Tran Code',scan_base_code as 'Base Code',scan_status,date_format(c.chq_date,'%d/%m/%Y') as 'Chq Date',"
        lsSql &= "  c.chq_type AS 'Pay_Mode',c.chq_acc_no as 'Chq_Accno', "
        lsSql &= "  scan_remark as 'Reason',bank_code as 'Bank Code',bank_name as 'Bank Name',scan_chq_gid,b.tot_chqs,d.entity_name,b.lot_no,b.contract_no"
        lsSql &= " from arms_trn_tscan as a"
        lsSql &= " inner join arms_trn_tpacket as b on a.scan_packet_gid=b.packet_gid and b.delete_flag='N'"
        lsSql &= " and scan_status & " & GCSCANCANCELED & " = 0"
        lsSql &= " and scan_status & " & GCSCANRESCAN & "= 0 "
        lsSql &= " inner join arms_trn_tcheque as c on a.scan_chq_gid=c.chq_gid and b.packet_gid=c.packet_gid and c.delete_flag='N'"
        lsSql &= " inner join arms_mst_tentity as d on c.entity_gid=d.entity_gid and d.delete_flag='N'"
        lsSql &= " cross join (select @rownr:=0) as t "
        lsSql &= " where true"
        lsSql &= lsCond

        gvmChkrEntry.Columns.Clear()
        gpPopGridView(gvmChkrEntry, lsSql, gOdbcConn)

        If gvmChkrEntry.Rows.Count > 0 Then
            With gvmChkrEntry
                .Columns("scan_gid").Visible = False
                .Columns("scan_packet_gid").Visible = False
                .Columns("scan_status").Visible = False
                .Columns("Chq Date").Visible = False
                .Columns("Pay_Mode").Visible = False
                .Columns("Chq_Accno").Visible = False
                .Columns("scan_chq_gid").Visible = False
                .Columns("Bank Code").Visible = False
                .Columns("Bank Name").Visible = False
                .Columns("Reason").Visible = False
                .Columns("tot_chqs").Visible = False
                .Columns("entity_name").Visible = False
                .Columns("lot_no").Visible = False
                .Columns("contract_no").Visible = False
            End With
        End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        TxtCoverNo.Text = ""
        TxtLotNo.Text = ""
        TxtContractNo.Text = ""
        TxtChqNo.Text = ""
        txtchqamt.Text = ""
        mstchqdate.Text = ""
        TxtTotalChq.Text = ""
        TxtEntityName.Text = ""
        TxtBankCode.Text = ""
        TxtBankName.Text = ""
        gvmChkrEntry.Columns.Clear()
        PicFrontSide.Image = Nothing
    End Sub

End Class