Imports System.IO
Imports System.IO.FileStream
Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Security.Cryptography
Imports Microsoft.Office.Interop

Public Class frmAplobinput

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
                MsgBox("Please select the file !", MsgBoxStyle.Information, gsProjectName)
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
                    Call ImportAplobInputFile()
                Else
                    MsgBox("Please select the sheet name !", MsgBoxStyle.Information, gsProjectName)
                    Exit Sub
                End If
            Else
                MsgBox("Please select the file !", MsgBoxStyle.Information, gsProjectName)
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

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        If MsgBox("Do you want to Close?", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
            MyBase.Close()
        End If
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

    Sub ImportAplobInputFile()
        Dim i As Integer
        Dim c As Integer
        Dim d As Integer
        Dim lbInsertFlag As Boolean = False
        Dim lsDiscRemark As String = ""
        Dim lsFldFormat As String = ""
        Dim lsFldName(27) As String
        Dim lsTxt As String
        Dim lsContractNumber As String = ""
        Dim lsPayeeName As String = ""
        Dim lsCycleDate As String = ""
        Dim lsChqDate As String = ""
        Dim lsChqNo As String = ""
        Dim lnChqAmt As Double = 0
        Dim lsChqAccNo As String = 0
        Dim lsMICRCode As String = ""
        Dim lsBankName As String = ""
        Dim lsBranch As String = ""
        Dim lsPacketNo As String = ""
        Dim lsRemark As String = ""
        Dim lsCtsFlag As String = ""
        Dim lsFileName As String = ""
        Dim lsEntityCode As String = ""
        Dim lnFileId As Long = 0
        Dim lnEntityId As Integer = 0
        Dim lsSheetName As String = ""
        Dim lsLocName As String = ""
        Dim lsProdCode As String = ""

        Dim lslotno As String = ""
        Dim lsChequetype As String = ""
        Dim lsClientvalue1 As String = ""
        Dim lsClientValue2 As String = ""
        Dim lsClientValue3 As String = ""
        Dim lsClientValue4 As String = ""
        Dim lsClientValue5 As String = ""
        Dim lsPayableLoc As String = ""


        Dim frm As frmQuickView
        Dim cmd As MySqlCommand

        Select Case ""
            Case cboEntity.Text
                MsgBox("Entity Can Not Be Empty!", MsgBoxStyle.Information, gsProjectName)
                cboEntity.Focus()
                Exit Sub
        End Select

        lsFldName(1) = "Client Code"
        lsFldName(2) = "Sr No"
        lsFldName(3) = "Packet No"
        lsFldName(4) = "Drawer Name"
        lsFldName(5) = "REMARKS"
        lsFldName(6) = "TYPE"
        lsFldName(7) = "Cheque No"
        lsFldName(8) = "Cheque Date"
        lsFldName(9) = "Cycle Date"
        lsFldName(10) = "Contract Amount"
        lsFldName(11) = "Cheque Amt"
        lsFldName(12) = "MICR Code"
        lsFldName(13) = "Bank Name"
        lsFldName(14) = "Branch"
        lsFldName(15) = "Payable Location"
        lsFldName(16) = "Pick up Location"
        lsFldName(17) = "Account Number"
        lsFldName(18) = "Payable Location1"
        lsFldName(19) = "Contract Number"
        lsFldName(20) = "Lot No"
        lsFldName(21) = "Cheque Type"
        lsFldName(22) = "Product"
        lsFldName(23) = "Additional1"
        lsFldName(24) = "Additional2"
        lsFldName(25) = "Additional3"
        lsFldName(26) = "Additional4"
        lsFldName(27) = "Additional5"


        lsFileName = QuoteFilter(fsFileName)
        Try
            Try
                fExcelDatatable = gpExcelDataset("select * from [" & cboSheetName.Text & "$]", fsFilePath)
            Catch ex As Exception
                MsgBox(ex.Message)
                Exit Sub
            End Try

            For i = 1 To 27
                lsFldFormat &= lsFldName(i) & "|"
            Next
            For i = 1 To 27
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
                    lsEntityCode = Mid(QuoteFilter(.Rows(i).Item("Client Code").ToString), 1, 16).ToUpper
                    If lsEntityCode <> lsTxt Then
                        MsgBox("Entity code mismatch line no:" & (i + 1).ToString, MsgBoxStyle.Critical, gsProjectName)
                        Exit Sub
                    End If
                    lsChqDate = Mid(QuoteFilter(.Rows(i).Item("Cheque Date").ToString), 1, 16).ToUpper
                    If lsChqDate = "" Then
                        MsgBox("Cheque date can not be empty. line no:" & (i + 1).ToString, MsgBoxStyle.Critical, gsProjectName)
                        Exit Sub
                    End If
                    lsCycleDate = Mid(QuoteFilter(.Rows(i).Item("Cycle Date").ToString), 1, 16).ToUpper
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
            fsSql &= " and file_type = " & gnFileAplobInput & " "
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
            cmd.Parameters.AddWithValue("?pr_file_name", lsFileName)
            cmd.Parameters.AddWithValue("?pr_sheet_name", lsSheetName)
            cmd.Parameters.AddWithValue("?pr_file_type", gnFileAplobInput)
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

                        lsContractNumber = QuoteFilter(.Item("Contract Number").ToString)
                        lsPayeeName = QuoteFilter(.Item("Drawer Name").ToString)
                        lsEntityCode = Mid(QuoteFilter(.Item("Client Code").ToString), 1, 16)

                        lsCycleDate = QuoteFilter(.Item("Cycle Date").ToString)

                        If IsDate(lsCycleDate) Then
                            lsCycleDate = Format(CDate(lsCycleDate), "yyyy-MM-dd")
                        Else
                            lsCycleDate = ""
                        End If

                        lsChqDate = QuoteFilter(.Item("Cheque Date").ToString)

                        If IsDate(lsChqDate) Then
                            lsChqDate = Format(CDate(lsChqDate), "yyyy-MM-dd")
                        Else
                            lsChqDate = ""
                        End If

                        lnChqAmt = Math.Round(Val(QuoteFilter(.Item("Cheque Amt").ToString)), 2)
                        lsChqNo = Format(Val(QuoteFilter(.Item("Cheque No").ToString)), "000000")
                        If Val(lsChqNo) = 0 Then lsChqNo = ""
                        lsMICRCode = Mid(Format(Val(QuoteFilter(.Item("MICR Code").ToString)), "000000000"), 1, 16)
                        If Val(lsMICRCode) = 0 Then lsMICRCode = "000000000"
                        lsBankName = QuoteFilter(.Item("Bank Name").ToString)
                        lsBranch = QuoteFilter(.Item("Branch").ToString)
                        lsRemark = Mid(QuoteFilter(.Item("REMARKS").ToString), 1, 255)
                        lsCtsFlag = Mid(QuoteFilter(.Item("TYPE").ToString), 1, 255)
                        lsChqAccNo = Mid(QuoteFilter(.Item("Account Number").ToString), 1, 255)
                        lsPacketNo = Mid(QuoteFilter(.Item("Packet No").ToString), 1, 255)
                        lslotno = Mid(QuoteFilter(.Item("Lot No").ToString), 1, 32)
                        lsChequetype = Mid(QuoteFilter(.Item("Cheque Type").ToString), 1, 8)
                        lsLocName = Mid(QuoteFilter(.Item("Pick up Location").ToString), 1, 255)
                        lsProdCode = Mid(QuoteFilter(.Item("Product").ToString), 1, 8)
                        lsClientvalue1 = Mid(QuoteFilter(.Item("Additional1").ToString), 1, 255)
                        lsClientValue2 = Mid(QuoteFilter(.Item("Additional2").ToString), 1, 255)
                        lsClientValue3 = Mid(QuoteFilter(.Item("Additional3").ToString), 1, 255)
                        lsClientValue4 = Mid(QuoteFilter(.Item("Additional4").ToString), 1, 255)
                        lsClientValue5 = Mid(QuoteFilter(.Item("Additional5").ToString), 1, 255)
                        lsPayableLoc = Mid(QuoteFilter(.Item("Payable Location").ToString), 1, 255)

                        If lsCtsFlag <> "cts" Then
                            'lsCtsFlag = Convert.ToChar("N")
                            lsCtsFlag = "N"
                        Else
                            'lsCtsFlag = Convert.ToChar("Y")
                            lsCtsFlag = "Y"
                        End If

                        Call ConOpenOdbc(ServerDetails)
                        cmd = New MySqlCommand("pr_arms_trn_taplobinput", gOdbcConn)
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.Parameters.AddWithValue("?pr_entity_gid", lnEntityId)
                        cmd.Parameters.AddWithValue("?pr_file_gid", lnFileId)
                        cmd.Parameters.AddWithValue("?pr_lot_no", lslotno)
                        cmd.Parameters.AddWithValue("?pr_cheque_type", lsChequetype)
                        cmd.Parameters.AddWithValue("?pr_contract_no", lsContractNumber)
                        cmd.Parameters.AddWithValue("?pr_payee_name", lsPayeeName)
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
                        cmd.Parameters.AddWithValue("?pr_locName", lsLocName)
                        cmd.Parameters.AddWithValue("?pr_prod_code", lsProdCode)
                        cmd.Parameters.AddWithValue("?pr_additional1", lsClientvalue1)
                        cmd.Parameters.AddWithValue("?pr_additional2", lsClientValue2)
                        cmd.Parameters.AddWithValue("?pr_additional3", lsClientValue3)
                        cmd.Parameters.AddWithValue("?pr_additional4", lsClientValue4)
                        cmd.Parameters.AddWithValue("?pr_additional5", lsClientValue5)
                        cmd.Parameters.AddWithValue("?pr_payableloc", lsPayableLoc)
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
            fsSql &= " select * from arms_trn_taplobinput "
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

    Private Sub frmAplobinput_Load(sender As Object, e As EventArgs) Handles Me.Load
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