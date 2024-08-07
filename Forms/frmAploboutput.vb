Imports System.IO
Imports System.IO.FileStream
Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Security.Cryptography
Imports Microsoft.Office.Interop

Public Class frmAploboutput

#Region "Local Declaration"
    Dim lnres As Integer
    Dim fsSql As String
    Dim lnResult As Long
    Dim fsFilePath As String = ""
    Dim fsFileName As String
    Dim fExcelDatatable As New DataTable
    Dim lobjRow As DataRow
#End Region

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
    End Sub

    Private Sub LoadSheet()
        Dim objXls As New Excel.Application
        Dim objBook As Excel.Workbook

        If Trim(txtFileName.Text) <> "" Then
            If File.Exists(txtFileName.Text) Then
                objBook = objXls.Workbooks.Open(txtFileName.Text)
                cboSheetName.Items.Clear()
                For i As Integer = 1 To objXls.ActiveWorkbook.Worksheets.Count
                    cboSheetName.Items.Add(objXls.ActiveWorkbook.Worksheets(i).Name)
                Next i
                objXls.Workbooks.Close()

            End If
        End If

        objXls.Workbooks.Close()

        GC.Collect()
        GC.WaitForPendingFinalizers()

        objXls.Quit()

        System.Runtime.InteropServices.Marshal.FinalReleaseComObject(objXls)
        objXls = Nothing

        Call KillAllExcel()
    End Sub

    Public Sub FormatSheet(ByVal ExcelFileName As String, ByVal SheetName As String)
        Dim objApplication As New Excel.Application
        Dim objBooks As Excel.Workbooks
        Dim objWorkBook As Excel.Workbook
        Dim objWorkSheet As Excel.Worksheet
        Dim objRange As Excel.Range
        Dim a() As Short = {1, 2}
        Dim b() As Short = {1, 1}
        Dim i As Integer

        Try
            If File.Exists(ExcelFileName) = False Then Exit Sub

            objBooks = objApplication.Workbooks
            objWorkBook = objBooks.Open(ExcelFileName, False, False)
            objWorkSheet = objWorkBook.Sheets(SheetName)

            objApplication.Visible = True

            For i = 1 To 256
                If objWorkSheet.Cells(1, i).Value <> "" Then
                    objRange = objWorkSheet.Columns(i)

                    If IsDate(objWorkSheet.Cells(2, i).Value) Then
                        objRange.TextToColumns(objRange, Excel.XlTextParsingType.xlDelimited, Excel.XlTextQualifier.xlTextQualifierDoubleQuote, , , , , , , , b, , )
                    Else
                        objRange.TextToColumns(objRange, Excel.XlTextParsingType.xlDelimited, Excel.XlTextQualifier.xlTextQualifierDoubleQuote, , , , , , , , a, , )
                    End If
                Else
                    Exit For
                End If
            Next i

            objWorkBook.Save()
            objWorkBook.Close()
            objBooks.Close()

            objApplication.Quit()

            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(objApplication)

            GC.Collect()
            GC.WaitForPendingFinalizers()

            Call KillAllExcel()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error...")
        End Try
    End Sub

    Private Sub btnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click
        Try
            If txtFileName.Text = "" Then
                MsgBox("Select File Name!", MsgBoxStyle.Information, gsProjectName)
                txtFileName.Focus()
                Exit Sub
            End If
            Panel1.Enabled = False
            Me.Cursor = Cursors.WaitCursor
            Application.DoEvents()

            fsFilePath = txtFileName.Text.Trim
            fsFileName = fsFilePath.Substring(fsFilePath.LastIndexOf("\") + 1)
            If txtFileName.Text <> "" Then
                If cboSheetName.Text <> "" Then
                    Call FormatSheet(txtFileName.Text, cboSheetName.Text)
                    Call ImportAplobOutFile()
                Else
                    MsgBox("Select Sheet Name!", MsgBoxStyle.Information, gsProjectName)
                    Exit Sub
                End If
            Else
                MsgBox("Select File to Import!", MsgBoxStyle.Information, gsProjectName)
                Exit Sub
            End If
            Panel1.Enabled = True
            Me.Cursor = Cursors.Default

        Catch ex As Exception
            MsgBox(ex.Message)
            btnImport.Enabled = True
            Me.Cursor = Cursors.Default
            Application.DoEvents()
        End Try
    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        With OpenFileDialog1
            .Filter = "Excel Files|*.xls;*.xlsx|Text Files|*.*|DBF Files|*.dbf|Text Files|*.txt|Word Files|*.doc"
            .Title = "Select Files to Import"
            .RestoreDirectory = True
            .ShowDialog()
            If .FileName <> "" And .FileName <> "OpenFileDialog1" Then
                txtFileName.Text = .FileName
            End If
            .FileName = ""
        End With

        If (InStr(1, LCase(Trim(txtFileName.Text)), ".xls")) > 0 Then
            cboSheetName.Enabled = True

            Call LoadSheet()

            cboSheetName.Focus()
        Else
            cboSheetName.Enabled = False
        End If
        Exit Sub
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        If MsgBox("Do you want to Close?", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
            MyBase.Close()
        End If
    End Sub

    Sub ImportAplobOutFile()
        Dim i As Integer
        Dim c As Integer
        Dim d As Integer
        Dim lbInsertFlag As Boolean = False
        Dim lsDiscRemark As String = ""
        Dim lsFldFormat As String = ""
        Dim lsFldName(39) As String
        Dim lsTxt As String
        Dim lsContractNumber As String = ""
        Dim lsPayeeName As String = ""
        Dim lsLocCode As String = ""
        Dim lsProdCode As String = ""
        Dim lsCycleDate As String = ""
        Dim lsChqDate As String = ""
        Dim lsChqNo As String = ""
        Dim lnChqAmt As Double = 0
        Dim lsChqAccNo As String = 0
        Dim lsMICRCode As String = ""
        Dim lsBankName As String = ""
        Dim lsBranch As String = ""
        Dim lsCuboardNo As String = ""
        Dim lsShelfNo As String = ""
        Dim lsBoxNo As String = ""
        Dim lsPacketNo As String = ""
        Dim lsLotNo As String = ""
        Dim lsRemark As String = ""
        Dim lsCtsFlag As String = ""
        Dim lsFileName As String = ""
        Dim lsEntityCode As String = ""
        Dim lnFileId As Long = 0
        Dim lnEntityId As Long = 0
        Dim lsSheetName As String = ""
        Dim lsLocName As String = ""
        Dim frm As frmQuickView
        Dim cmd As MySqlCommand

        Select Case ""
            Case cboEntity.Text
                MsgBox("Entity Can Not Be Empty!", MsgBoxStyle.Information, gsProjectName)
                cboEntity.Focus()
                Exit Sub
        End Select

        lsFldName(1) = "ClientCode"
        lsFldName(2) = "DealerCode"
        lsFldName(3) = "BoxNo"
        lsFldName(4) = "ChequeType"
        lsFldName(5) = "ContractNo"
        lsFldName(6) = "InvoiceDate"
        lsFldName(7) = "DueDate"
        lsFldName(8) = "ChequeAmount"
        lsFldName(9) = "ChequeNo"
        lsFldName(10) = "ToChequeNo"
        lsFldName(11) = "ChequeDate"
        lsFldName(12) = "ChequeAmount1"
        lsFldName(13) = "PayTo"
        lsFldName(14) = "Status"
        lsFldName(15) = "SortKey"
        lsFldName(16) = "Storage"
        lsFldName(17) = "SortKey1"
        lsFldName(18) = "PayableLocation"
        lsFldName(19) = "AccountNo"
        lsFldName(20) = "CuboardNo"
        lsFldName(21) = "ShelfNo"
        lsFldName(22) = "CoverNO"
        lsFldName(23) = "BreakupAmount"
        lsFldName(24) = "Remark1_CustomerName"
        lsFldName(25) = "Remark2"
        lsFldName(26) = "Remark3"
        lsFldName(27) = "Remark4"
        lsFldName(28) = "Remark5"
        lsFldName(29) = "CTS"
        lsFldName(30) = "Remark7"
        lsFldName(31) = "Remark8"
        lsFldName(32) = "Remark9"
        lsFldName(33) = "Remark10"
        lsFldName(34) = "Addition1"
        lsFldName(35) = "Addition2"
        lsFldName(36) = "Addition3"
        lsFldName(37) = "Addition4"
        lsFldName(38) = "Addition5"
        lsFldName(39) = "Product"

        lsFileName = QuoteFilter(fsFileName)

        Try
            Try
                fExcelDatatable = gpExcelDataset("select * from [" & cboSheetName.Text & "$]", fsFilePath)
            Catch ex As Exception
                MsgBox(ex.Message)
                Exit Sub
            End Try

            For i = 1 To 39
                lsFldFormat &= lsFldName(i) & "|"
            Next
            For i = 1 To 39
                If lsFldName(i).Trim.ToUpper <> fExcelDatatable.Columns(i - 1).ColumnName.ToUpper.Trim Then
                    MsgBox("Excel Column Setting is wrong (" & i & ")" & vbCrLf & vbCrLf _
                    & lsFldName(i).ToUpper.Trim & " : " & fExcelDatatable.Columns(i - 1).ColumnName.ToUpper.Trim & ":" & vbCrLf & vbCrLf _
                    & "Correct format is " & vbCrLf & vbCrLf & lsFldFormat, vbOKOnly + vbExclamation, gsProjectName)
                    Exit Sub
                End If
            Next

            With fExcelDatatable
                lsTxt = cboEntity.Text
                lsTxt = lsTxt.Split("-")(0).ToUpper

                For i = 0 To .Rows.Count - 1
                    lsEntityCode = Mid(QuoteFilter(.Rows(i).Item("ClientCode").ToString), 1, 16).ToUpper
                    If lsEntityCode <> lsTxt Then
                        MsgBox("Entity code mismatch line no:" & (i + 1).ToString, MsgBoxStyle.Critical, gsProjectName)
                        Exit Sub
                    End If
                    lsChqDate = Mid(QuoteFilter(.Rows(i).Item("ChequeDate").ToString), 1, 16).ToUpper
                    If lsChqDate = "" Then
                        MsgBox("Cheque date can not be empty. line no:" & (i + 1).ToString, MsgBoxStyle.Critical, gsProjectName)
                        Exit Sub
                    End If
                    lsCycleDate = Mid(QuoteFilter(.Rows(i).Item("DueDate").ToString), 1, 16).ToUpper
                    If lsCycleDate = "" Then
                        MsgBox("Cycle date can not be empty. line no:" & (i + 1).ToString, MsgBoxStyle.Critical, gsProjectName)
                        Exit Sub
                    End If
                Next
            End With

            'File Name Duplicate
            fsSql = ""
            fsSql &= " select file_gid from arms_trn_tfile"
            fsSql &= " where 1=1 "
            fsSql &= " and file_name = '" & lsFileName & "'"
            fsSql &= " and sheet_name='" & cboSheetName.Text & "'"
            fsSql &= " and file_type = " & gnFilePullout & " "
            fsSql &= " and delete_flag ='N'"

            lnFileId = Val(gfExecuteScalar(fsSql, gOdbcConn))
            If lnFileId > 0 Then
                MsgBox("File Already Imported !", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gsProjectName)
                txtFileName.Focus()
                Exit Sub
            End If

            btnImport.Enabled = False

            lnEntityId = cboEntity.SelectedValue
            lsSheetName = cboSheetName.Text
            Call ConOpenOdbc(ServerDetails)
            cmd = New MySqlCommand("pr_arms_trn_tfile", gOdbcConn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("?pr_entity_gid", lnEntityId)
            cmd.Parameters("?pr_entity_gid").Direction = ParameterDirection.Input
            cmd.Parameters.AddWithValue("?pr_file_name", lsFileName)
            cmd.Parameters("?pr_file_name").Direction = ParameterDirection.Input
            cmd.Parameters.AddWithValue("?pr_sheet_name", lsSheetName)
            cmd.Parameters("?pr_sheet_name").Direction = ParameterDirection.Input
            cmd.Parameters.AddWithValue("?pr_file_type", gnFileAplobOutput)
            cmd.Parameters("?pr_file_type").Direction = ParameterDirection.Input
            cmd.Parameters.AddWithValue("?pr_action_by", gsLoginUserCode)
            cmd.Parameters("?pr_action_by").Direction = ParameterDirection.Input
            cmd.Parameters.AddWithValue("?pr_action", "INSERT")
            cmd.Parameters("?pr_action").Direction = ParameterDirection.Input
            'Out put Para
            cmd.Parameters.Add("?pr_err_msg", MySqlDbType.VarChar)
            cmd.Parameters("?pr_err_msg").Direction = ParameterDirection.Output

            cmd.Parameters.Add("?pr_result", MySqlDbType.Int32)
            cmd.Parameters("?pr_result").Direction = ParameterDirection.Output

            cmd.ExecuteNonQuery()
            Call ConCloseOdbc(ServerDetails)
            lnResult = Val(cmd.Parameters("?pr_result").Value.ToString())
            lnFileId = lnResult

            If (lnResult = 0) Then
                MsgBox(cmd.Parameters("?pr_err_msg").Value.ToString())
                Exit Sub
            End If

            With fExcelDatatable

                i = 0

                While i <= .Rows.Count - 1
                    With .Rows(i)

                        Me.Cursor = Cursors.WaitCursor
                        Application.DoEvents()

                        lbInsertFlag = True
                        lsDiscRemark = ""

                        lsContractNumber = QuoteFilter(.Item("ContractNo").ToString)
                        lsPayeeName = QuoteFilter(.Item("Remark1_CustomerName").ToString)
                        lsLocName = QuoteFilter(.Item("PayableLocation").ToString)
                        'lsLocCode = lsLocCode.Substring(0, 3)
                        lsProdCode = QuoteFilter(.Item("Product").ToString)
                        lsEntityCode = Mid(QuoteFilter(.Item("ClientCode").ToString), 1, 16)
                        lsCycleDate = Format(CDate(QuoteFilter(.Item("DueDate").ToString)), "yyyy-MM-dd")
                        'lsChqDate = Format(CDate(QuoteFilter(.Item("ChequeDate").ToString)), "yyyy-MM-dd")
                        lsCycleDate = QuoteFilter(.Item("DueDate").ToString)
                        If IsDate(lsCycleDate) Then
                            lsCycleDate = Format(CDate(lsCycleDate), "yyyy-MM-dd")
                        Else
                            lsCycleDate = ""
                        End If
                        lsChqDate = Format(CDate(QuoteFilter(.Item("ChequeDate").ToString)), "yyyy-MM-dd")

                        lsChqDate = QuoteFilter(.Item("ChequeDate").ToString)
                        If IsDate(lsChqDate) Then
                            lsChqDate = Format(CDate(lsChqDate), "yyyy-MM-dd")
                        Else
                            lsChqDate = ""
                        End If

                        lnChqAmt = Math.Round(Val(QuoteFilter(.Item("ChequeAmount").ToString)), 2)
                        lsChqNo = Mid(Format(Val(QuoteFilter(.Item("ChequeNo").ToString)), "000000"), 1, 16)
                        If Val(lsChqNo) = 0 Then lsChqNo = ""
                        lsMICRCode = Mid(Format(Val(QuoteFilter(.Item("SortKey").ToString)), "000000000"), 1, 16)
                        If Val(lsMICRCode) = 0 Then lsMICRCode = ""
                        'Bankname not give
                        'lsBankName = QuoteFilter(.Item("").ToString)
                        lsBranch = QuoteFilter(.Item("Remark4").ToString)
                        'remark not give
                        lsCtsFlag = Mid(QuoteFilter(.Item("CTS").ToString), 1, 255)
                        lsChqAccNo = Mid(QuoteFilter(.Item("AccountNo").ToString), 1, 255)
                        lsBankName = Mid(QuoteFilter(.Item("Remark5").ToString), 1, 255)
                        lsRemark = Mid(QuoteFilter(.Item("Remark7").ToString), 1, 255)
                        'lsLotNo = Mid(QuoteFilter(.Item("Remark8").ToString), 1, 255)
                        lsPacketNo = Mid(QuoteFilter(.Item("CoverNO").ToString), 1, 255)
                        lsCuboardNo = QuoteFilter(.Item("CuboardNo").ToString)
                        lsShelfNo = QuoteFilter(.Item("ShelfNo").ToString)
                        lsBoxNo = QuoteFilter(.Item("BoxNo").ToString)

                        Call ConOpenOdbc(ServerDetails)
                        cmd = New MySqlCommand("pr_arms_trn_tcheque_new", gOdbcConn)
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.Parameters.AddWithValue("?pr_entity_gid", lnEntityId)
                        cmd.Parameters.AddWithValue("?pr_file_gid", lnFileId)
                        cmd.Parameters.AddWithValue("?pr_contract_no", lsContractNumber)
                        cmd.Parameters.AddWithValue("?pr_payee_name", lsPayeeName)
                        cmd.Parameters.AddWithValue("?pr_loc_name", lsLocName)
                        cmd.Parameters.AddWithValue("?pr_prod_code", lsProdCode)
                        cmd.Parameters.AddWithValue("?pr_cycle_date", CDate(lsCycleDate))
                        cmd.Parameters.AddWithValue("?pr_chq_date", CDate(lsChqDate))
                        cmd.Parameters.AddWithValue("?pr_chq_no", lsChqNo)
                        cmd.Parameters.AddWithValue("?pr_chq_amount", lnChqAmt)
                        cmd.Parameters.AddWithValue("?pr_chq_acc_no", lsChqAccNo)
                        cmd.Parameters.AddWithValue("?pr_micr_code", lsMICRCode)
                        cmd.Parameters.AddWithValue("?pr_bank_name", lsBankName)
                        cmd.Parameters.AddWithValue("?pr_bank_branch", lsBranch)
                        cmd.Parameters.AddWithValue("?pr_cts_flag", lsCtsFlag)
                        cmd.Parameters.AddWithValue("?pr_chq_remark", lsRemark)
                        cmd.Parameters.AddWithValue("?pr_packet_no", lsPacketNo)
                        cmd.Parameters.AddWithValue("?pr_cuboard_no", lsCuboardNo)
                        cmd.Parameters.AddWithValue("?pr_shelf_no", lsShelfNo)
                        cmd.Parameters.AddWithValue("?pr_box_no", lsBoxNo)
                        cmd.Parameters.AddWithValue("?pr_action", "INSERT")

                        'Out put Para
                        cmd.Parameters.Add("?pr_result", MySqlDbType.Int32)
                        cmd.Parameters("?pr_result").Direction = ParameterDirection.Output
                        cmd.Parameters.Add("?pr_err_msg", MySqlDbType.VarChar)
                        cmd.Parameters("?pr_err_msg").Direction = ParameterDirection.Output

                        cmd.ExecuteNonQuery()
                        Call ConCloseOdbc(ServerDetails)
                        lnres = Val(cmd.Parameters("?pr_result").Value.ToString())

                        If lnres > 0 Then
                            c += 1
                        Else
                            d += 1
                            lsDiscRemark = "Line " & (i + 1).ToString & ":" & cmd.Parameters("?pr_err_msg").Value.ToString()
                        End If

                        If (lnres = 0) Then
                            Call ConOpenOdbc(ServerDetails)
                            cmd = New MySqlCommand("pr_arms_trn_terrmsg", gOdbcConn)
                            cmd.CommandType = CommandType.StoredProcedure
                            cmd.Parameters.AddWithValue("?pr_file_gid", lnFileId)
                            cmd.Parameters("?pr_file_gid").Direction = ParameterDirection.Input
                            cmd.Parameters.AddWithValue("?pr_errmsg_desc", lsDiscRemark)
                            cmd.Parameters("?pr_errmsg_desc").Direction = ParameterDirection.Input
                            cmd.Parameters.AddWithValue("?pr_action", "INSERT")
                            cmd.Parameters("?pr_action").Direction = ParameterDirection.Input
                            'Out put Para
                            cmd.Parameters.Add("?pr_result", MySqlDbType.Int32)
                            cmd.Parameters("?pr_result").Direction = ParameterDirection.Output
                            cmd.Parameters.Add("?pr_err_msg", MySqlDbType.VarChar)
                            cmd.Parameters("?pr_err_msg").Direction = ParameterDirection.Output
                            cmd.ExecuteNonQuery()
                            Call ConCloseOdbc(ServerDetails)
                            lnResult = Val(cmd.Parameters("?pr_result").Value.ToString())
                            If (Convert.ToInt32(lnResult) = 0) Then
                                MsgBox(cmd.Parameters("?pr_err_msg").Value.ToString())
                            End If
                        End If
                        Application.DoEvents()
                    End With
                    i += 1
                End While
            End With

            MsgBox("Out of " & i & " record(s) " & c & " record(s) imported successfully ! ", MsgBoxStyle.Information, gsProjectName)
            fsSql = ""
            fsSql &= " select * from arms_trn_tcheque "
            fsSql &= " where file_gid = " & lnFileId & " "
            fsSql &= " and delete_flag = 'N' "

            frm = New frmQuickView(gOdbcConn, fsSql)
            frm.ShowDialog()

            If d > 0 Then
                MsgBox(d & " record(s) failed to import !", MsgBoxStyle.Critical, gsProjectName)

                fsSql = ""
                fsSql &= " select * from arms_trn_terrmsg "
                fsSql &= " where file_gid = " & lnFileId & " "
                fsSql &= " and delete_flag = 'N' "

                frm = New frmQuickView(gOdbcConn, fsSql)
                frm.ShowDialog()
            End If

            btnImport.Enabled = True
            Application.DoEvents()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, gsProjectName)
            btnImport.Enabled = True
            Me.Cursor = Cursors.Default
            Application.DoEvents()
        End Try
    End Sub

    Private Sub frmAploboutput_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            gsQry = " select CONCAT(entity_code,'-', entity_name) as EntityCode ,entity_gid from arms_mst_tentity"
            gsQry &= " where delete_flag='N' "
            gsQry &= " order by entity_name "
            Call gpBindCombo(gsQry, "EntityCode", "entity_gid", cboEntity, gOdbcConn)
            KeyPreview = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class