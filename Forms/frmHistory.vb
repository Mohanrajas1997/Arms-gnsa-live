Imports System.IO
Imports MySql.Data.MySqlClient

Public Class frmHistory
    Dim msSql As String

#Region "Local Declaration"
    Dim lnres As Integer
    Dim fsSql As String
    Dim lnResult As Long

    Dim fsFilePath As String = ""
    Dim fsFileName As String
    Dim fExcelDatatable As New DataTable
    Dim lobjRow As DataRow
#End Region

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        'User Selected Browse file 
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
    End Sub

    Private Sub frmHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        If MsgBox("Do you want to Close?", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
            MyBase.Close()
        End If
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
            If cboEntity.Text = "" Then
                MsgBox("Please Select Entity", MsgBoxStyle.Information, gsProjectName)
                cboEntity.Focus()
                Exit Sub
            End If

            If txtFileName.Text = "" Then
                MsgBox("Select File Name", MsgBoxStyle.Information, gsProjectName)
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

                    ImportHistoryFile()

                Else
                    MsgBox("Select Sheet Name", MsgBoxStyle.Information, gsProjectName)
                    cboSheetName.Focus()
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

    Sub ImportHistoryFile()
        Dim i As Integer
        Dim c As Integer
        Dim d As Integer
        Dim lbInsertFlag As Boolean = False
        Dim lsDiscRemark As String = ""
        Dim lsFldFormat As String = ""
        Dim lsFldName(17) As String
        Dim lsTxt As String

        Dim lsEntityCode As String = ""
        Dim lsBoxNo As String = ""
        Dim lsChequeType As String = ""
        Dim lsContractNo As String = ""
        Dim lsChequeNo As String = ""
        Dim lsChequeAmt As Double = 0
        Dim lsChequeDate As String = ""
        Dim lsSortKey As String = ""
        Dim lsPayableLoc As String = ""
        Dim lsAccNo As String = ""
        Dim lsCuboardNo As String = ""
        Dim lsShelfNo As String = ""
        Dim lsCoverNo As String = ""
        Dim lsCustomerName As String = ""
        Dim lsChequeSts As String = ""
        Dim lsCts As String = ""
        Dim lsProduct As String = ""
        Dim lsFileName As String = ""
        Dim lnFileId As Long = 0
        Dim lnEntityId As Integer = 0
        Dim lsentity_gid As Integer = 0
        Dim lsSheetName As String = ""


        Dim frm As frmQuickView
        Dim cmd As MySqlCommand


        lsFldName(1) = "Entity Code"
        lsFldName(2) = "Box No"
        lsFldName(3) = "Cheque Type"
        lsFldName(4) = "Contract No"
        lsFldName(5) = "Cheque No"
        lsFldName(6) = "Cheque Amount"
        lsFldName(7) = "Cheque Date"
        lsFldName(8) = "Sort Key"
        lsFldName(9) = "Payable Location"
        lsFldName(10) = "Account No"
        lsFldName(11) = "Cuboard No"
        lsFldName(12) = "Shelf No"
        lsFldName(13) = "Cover No"
        lsFldName(14) = "Customer Name"
        lsFldName(15) = "Cheque Status"
        lsFldName(16) = "CTS"
        lsFldName(17) = "Product"

        lsFileName = QuoteFilter(fsFileName)

        Try
            fExcelDatatable = gpExcelDataset("select * from [" & cboSheetName.Text & "$]", fsFilePath)
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try

        For i = 1 To 16
            lsFldFormat &= lsFldName(i) & "|"
        Next
        For i = 1 To 16
            If lsFldName(i).Trim.ToUpper <> fExcelDatatable.Columns(i - 1).ColumnName.ToUpper.Trim Then
                MsgBox("Excel Column Setting is wrong (" & i & ")" & vbCrLf & vbCrLf _
                & lsFldName(i).ToUpper.Trim & " : " & fExcelDatatable.Columns(i - 1).ColumnName.ToUpper.Trim & ":" & vbCrLf & vbCrLf _
                & "Correct format is " & vbCrLf & vbCrLf & lsFldFormat, vbOKOnly + vbExclamation, gsProjectName)
                Exit Sub
            End If
        Next


        'File Name Duplicate
        fsSql = ""
        fsSql &= " select file_gid from arms_trn_tfile"
        fsSql &= " where 1=1 "
        fsSql &= " and file_name = '" & lsFileName & "'"
        fsSql &= " and sheet_name='" & cboSheetName.Text & "'"
        fsSql &= " and file_type = " & gnFileHistoryUpload & " "
        fsSql &= " and entity_gid = " & cboEntity.SelectedValue & " "
        fsSql &= " and delete_flag ='N'"

        lnFileId = Val(gfExecuteScalar(fsSql, gOdbcConn))
        If lnFileId > 0 Then
            MsgBox("File Already Imported !", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gsProjectName)
            txtFileName.Focus()
            Exit Sub
        End If

        btnImport.Enabled = False

        lnEntityId = lsentity_gid 'cboEntity.SelectedValue
        lsSheetName = cboSheetName.Text
        Call ConOpenOdbc(ServerDetails)
        cmd = New MySqlCommand("pr_arms_trn_tfile", gOdbcConn)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("?pr_entity_gid", cboEntity.SelectedValue)
        cmd.Parameters.AddWithValue("?pr_file_name", lsFileName)
        cmd.Parameters.AddWithValue("?pr_sheet_name", lsSheetName)
        cmd.Parameters.AddWithValue("?pr_file_type", gnFileHistoryUpload)
        cmd.Parameters.AddWithValue("?pr_action_by", gsLoginUserCode)
        cmd.Parameters.AddWithValue("?pr_action", "INSERT")

        ''Out put Para
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
            btnImport.Enabled = True
            Me.Cursor = Cursors.Default
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

                    lsEntityCode = Mid(QuoteFilter(.Item("Entity Code").ToString), 1, 16)
                    lsBoxNo = Mid(QuoteFilter(.Item("Box No").ToString), 1, 32)
                    lsChequeType = Mid(QuoteFilter(.Item("Cheque Type").ToString), 1, 8)
                    lsContractNo = Mid(QuoteFilter(.Item("Contract No").ToString), 1, 32)
                    lsChequeNo = Mid(QuoteFilter(.Item("Cheque No").ToString), 1, 32)
                    lsChequeAmt = Math.Round(Val(QuoteFilter(.Item("Cheque Amount").ToString)), 2)

                    lsChequeDate = QuoteFilter(.Item("Cheque Date").ToString)
                    If IsDate(lsChequeDate) Then
                        lsChequeDate = Format(CDate(lsChequeDate), "yyyy-MM-dd")
                    Else
                        lsChequeDate = ""
                    End If

                    lsSortKey = Mid(QuoteFilter(.Item("Sort Key").ToString), 1, 32)
                    lsPayableLoc = Mid(QuoteFilter(.Item("Payable Location").ToString), 1, 32)
                    lsAccNo = Mid(QuoteFilter(.Item("Account No").ToString), 1, 32)
                    lsCuboardNo = Mid(QuoteFilter(.Item("Cuboard No").ToString), 1, 32)
                    lsShelfNo = Mid(QuoteFilter(.Item("Shelf No").ToString), 1, 32)
                    lsCoverNo = Mid(QuoteFilter(.Item("Cover No").ToString), 1, 32)
                    lsCustomerName = Mid(QuoteFilter(.Item("Customer Name").ToString), 1, 128)
                    lsChequeSts = Mid(QuoteFilter(.Item("Cheque Status").ToString), 1, 32)
                    lsCts = Mid(QuoteFilter(.Item("CTS").ToString), 1, 1)
                    lsProduct = Mid(QuoteFilter(.Item("Product").ToString), 1, 32)


                    Call ConOpenOdbc(ServerDetails)
                    cmd = New MySqlCommand("pr_arms_trn_thistory", gOdbcConn)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("?pr_entity_gid", cboEntity.SelectedValue)
                    cmd.Parameters.AddWithValue("?pr_file_gid", lnFileId)
                    cmd.Parameters.AddWithValue("?pr_box_no", lsBoxNo)
                    cmd.Parameters.AddWithValue("?pr_cheque_type", lsChequeType)
                    cmd.Parameters.AddWithValue("?pr_contract_no", lsContractNo)
                    cmd.Parameters.AddWithValue("?pr_cheque_no", lsChequeNo)
                    cmd.Parameters.AddWithValue("?pr_cheque_amt", lsChequeAmt)
                    cmd.Parameters.AddWithValue("?pr_cheque_date", CDate(lsChequeDate))
                    cmd.Parameters.AddWithValue("?pr_sort_key", lsSortKey)
                    cmd.Parameters.AddWithValue("?pr_payable_loc", lsPayableLoc)
                    cmd.Parameters.AddWithValue("?pr_acc_no", lsAccNo)
                    cmd.Parameters.AddWithValue("?pr_cuboard_no", lsCuboardNo)
                    cmd.Parameters.AddWithValue("?pr_shelf_no", lsShelfNo)
                    cmd.Parameters.AddWithValue("?pr_cover_no", lsCoverNo)
                    cmd.Parameters.AddWithValue("?pr_customer_name", lsCustomerName)
                    cmd.Parameters.AddWithValue("?pr_cheque_sts", lsChequeSts)
                    cmd.Parameters.AddWithValue("?pr_cts", lsCts)
                    cmd.Parameters.AddWithValue("?pr_product", lsProduct)
                    cmd.Parameters.AddWithValue("?pr_action", "INSERT")
                    cmd.Parameters.AddWithValue("?pr_entry_by", gsLoginUserCode)

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
                        lnres = Val(cmd.Parameters("?pr_result").Value.ToString())
                        If (Convert.ToInt32(lnres) = 0) Then
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
        fsSql &= " select * from arms_trn_thistory "
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

    End Sub

End Class