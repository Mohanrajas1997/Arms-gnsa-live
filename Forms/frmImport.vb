Imports System.Data.Odbc
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports MySql.Data.MySqlClient

Public Class frmImport
    Inherits System.Windows.Forms.Form
#Region "Local Declaration"
    Dim lnImportFlag As Integer
    Dim fsSql As String
    Dim lnResult As Long

    Dim cmd As MySqlCommand
    Dim da As MySqlDataAdapter
    Dim dt As DataTable

    Dim fsFilePath As String = ""
    Dim fsFileName As String
    Dim fExcelDatatable As New DataTable
    Dim lobjRow As DataRow
#End Region
    Public Sub New(ByVal importFlag)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        lnImportFlag = importFlag
    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
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

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If MsgBox("Do you want to Close?", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
            MyBase.Close()
        End If
    End Sub

    Private Sub frmImportP2P_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Select Case lnImportFlag
            Case 1
                Me.Text = "Import Micr File"
            Case 2
                Me.Text = "Import Bank Branch File "
            Case 3
                Me.Text = "Import Bank Master File"
            Case 4
                Me.Text = "Import Bulk Presentation delete File"

        End Select
    End Sub

    Private Sub btnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImport.Click
        Try
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

                    Select Case lnImportFlag
                        Case 1
                            Call ImportMicrFile()
                        Case 2
                            Call ImportBankBranch()
                        Case 3
                            Call ImportBankMaster()
                        Case 4
                            Call ImportPresentationdelete()

                    End Select
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

    Private Function CheckExeclformat(ByVal lsExel As String) As Boolean
        Dim lsExeclcolums() As String = lsExel.Split("|")

        If fExcelDatatable.Columns.Count < UBound(lsExeclcolums) Then
            Return False
        Else
            For i As Integer = 0 To UBound(lsExeclcolums) - 1
                If Not lsExeclcolums(i) = fExcelDatatable.Columns(i).ColumnName Then
                    Return False
                End If
            Next
        End If

        Return True
    End Function

    Sub ImportMicrFile()
        Dim i As Integer
        Dim lsFldName(7) As String
        Dim lsFldFormat As String = ""
        Dim c As Integer = 0
        Dim d As Integer = 0

        Dim lsFileName As String = ""
        Dim lnFileId As Long

        Dim lnMicrId As Long = 0
        Dim lsMicrCode As String = ""
        Dim lsMicrBankCode As String = ""
        Dim lsBankCode As String = ""
        Dim lsBankName As String = ""
        Dim lsBankBranch As String = ""
        Dim lsBankAddr As String = ""
        Dim lnProdFlag As Integer = 0
        Dim lnSubProdFlag As Integer = 0
        Dim lsLocCode As String = ""
        Dim lsProd As String = ""
        Dim lsSubProd As String = ""
        Dim lsLocName As String = ""
        Dim lbInsertFlag As Boolean = False
        Dim lnResult As Long
        Dim lsErrFileName As String = ""
        Dim lsDiscRemark As String = ""

        Const lnFileType As Integer = 7

        lsFldName(1) = "SNO"
        lsFldName(2) = "MICR CODE"
        lsFldName(3) = "BANK CODE"
        lsFldName(4) = "BANK NAME"
        lsFldName(5) = "BANK BRANCH"
        lsFldName(6) = "BANK ADDRESS"
        lsFldName(7) = "LOCATION"

        lsFileName = QuoteFilter(fsFileName)

        Try
            '---------------------------------
            Try
                fExcelDatatable = gpExcelDataset("select * from [" & cboSheetName.Text & "$]", fsFilePath)
            Catch ex As Exception
                MsgBox(ex.Message)
                Exit Sub
            End Try

            For i = 1 To 7
                lsFldFormat &= lsFldName(i) & "|"
            Next

            For i = 1 To 7
                If lsFldName(i).Trim <> fExcelDatatable.Columns(i - 1).ColumnName.ToUpper.Trim Then
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
            fsSql &= " and file_type = " & lnFileType & " "
            fsSql &= " and delete_flag ='N'"

            lnFileId = Val(gfExecuteScalar(fsSql, gOdbcConn))

            If lnFileId > 0 Then
                MsgBox("File already imported !", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gsProjectName)
                txtFileName.Focus()
                Exit Sub
            Else
                fsSql = ""
                fsSql &= " insert into arms_trn_tfile"
                fsSql &= " (import_date, file_name, sheet_name,"
                fsSql &= " file_type,import_by)"
                fsSql &= " values ("
                fsSql &= " sysdate(),"
                fsSql &= " '" & lsFileName & "','" & cboSheetName.Text.Trim & "',"
                fsSql &= " " & lnFileType & ",'" & gsLoginUserCode & "')"

                lnResult = gfInsertQry(fsSql, gOdbcConn)

                fsSql = " select max(file_gid) from arms_trn_tfile "
                lnFileId = gfExecuteScalar(fsSql, gOdbcConn)
            End If

            lsErrFileName = gsReportPath & "err.txt"
            If File.Exists(lsErrFileName) = True Then File.Delete(lsErrFileName)

            Call FileOpen(1, lsErrFileName, OpenMode.Output)
            Call PrintLine(1, "SNo;Error Desc")

            btnImport.Enabled = False

            With fExcelDatatable
                i = 0

                While i <= .Rows.Count - 1
                    With .Rows(i)
                        Me.Cursor = Cursors.WaitCursor
                        Application.DoEvents()

                        lbInsertFlag = True
                        lsDiscRemark = ""

                        lsMicrCode = Mid(QuoteFilter(.Item("MICR CODE").ToString), 1, 9)
                        lsMicrBankCode = Mid(lsMicrCode, 4, 3)
                        lsBankCode = Mid(QuoteFilter(.Item("BANK CODE").ToString), 1, 3)
                        lsBankName = Mid(QuoteFilter(.Item("BANK NAME").ToString), 1, 128)
                        lsBankBranch = Mid(QuoteFilter(.Item("BANK BRANCH").ToString), 1, 128)
                        lsBankAddr = Mid(QuoteFilter(.Item("BANK ADDRESS").ToString), 1, 128)
                        lsLocName = Mid(QuoteFilter(.Item("LOCATION").ToString), 1, 64).ToUpper

                        If lsMicrCode = "" Then
                            lbInsertFlag = False
                            lsDiscRemark &= "Micr code is empty,"
                        ElseIf IsNumeric(lsMicrCode) = False Or lsMicrCode.Length <> 9 Then
                            lbInsertFlag = False
                            lsDiscRemark &= "Invalid micr,"
                        End If

                        ' Location
                        fsSql = ""
                        fsSql &= " select loc_code from arms_mst_tlocation "
                        fsSql &= " where loc_name = '" & lsLocName & "' "
                        fsSql &= " and delete_flag = 'N' "

                        lsLocCode = gfExecuteScalar(fsSql, gOdbcConn)

                        If lsLocCode = "" Then
                            lbInsertFlag = False
                            lsDiscRemark &= "Invalid location,"
                        End If

                        ' Find micr_gid
                        fsSql = ""
                        fsSql &= " select micr_gid from arms_mst_tmicr "
                        fsSql &= " where micr_code = '" & lsMicrCode & "' "
                        fsSql &= " and delete_flag = 'N' "

                        lnMicrId = Val(gfExecuteScalar(fsSql, gOdbcConn))

                        If lbInsertFlag = True Then
                            If lnMicrId = 0 Then
                                fsSql = ""
                                fsSql &= " insert into arms_mst_tmicr (micr_code,micr_bank_code,bank_code,bank_name,branch_name,loc_code) values ("
                                fsSql &= " '" & lsMicrCode & "',"
                                fsSql &= " '" & lsMicrBankCode & "',"
                                fsSql &= " '" & lsBankCode & "',"
                                fsSql &= " '" & lsBankName & "',"
                                fsSql &= " '" & lsBankBranch & "',"
                                fsSql &= " '" & lsLocCode & "')"
                            Else
                                fsSql = ""
                                fsSql &= " update arms_mst_tmicr set "
                                fsSql &= " micr_bank_code = '" & lsMicrBankCode & "',"
                                fsSql &= " bank_code = '" & lsBankCode & "',"
                                fsSql &= " bank_name = '" & lsBankName & "',"
                                fsSql &= " branch_name = '" & lsBankBranch & "',"
                                fsSql &= " loc_code = '" & lsLocCode & "' "
                                fsSql &= " where micr_gid = " & lnMicrId & " "
                                fsSql &= " and delete_flag = 'N' "
                            End If

                            lnResult = gfInsertQry(fsSql, gOdbcConn)

                            c += 1

                            frmMain.lblStatus.Text = "Imported Records Count : " & c
                            Application.DoEvents()
                        Else
                            Call PrintLine(1, c.ToString & ";" & lsDiscRemark)
                            d += 1
                            frmMain.lblStatus.Text = "Error Records Count : " & d
                            Application.DoEvents()
                        End If
                    End With

                    i += 1
                End While
            End With

            Call FileClose(1)

            MsgBox("Out of " & i & " record(s) " & c & " record(s) imported successfully ! ", MsgBoxStyle.Information, gsProjectName)

            If d > 0 Then
                MsgBox(d & " record(s) failed to import !", MsgBoxStyle.Critical, gsProjectName)
                Call gpOpenFile(lsErrFileName)
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

    Sub ImportBankBranch()
        Dim i As Integer
        Dim lsFldName(2) As String
        Dim lsFldFormat As String = ""
        Dim c As Integer = 0
        Dim d As Integer = 0

        Dim lsFileName As String = ""
        Dim lnFileId As Long

        Dim lsBankBranch As String = ""
        Dim lbInsertFlag As Boolean = False
        Dim lnResult As Long
        Dim lsErrFileName As String = ""
        Dim lsDiscRemark As String = ""

        Const lnFileType As Integer = 7

        lsFldName(1) = "SNO"
        lsFldName(2) = "BANK BRANCH"

        lsFileName = QuoteFilter(fsFileName)

        Try
            '---------------------------------
            Try
                fExcelDatatable = gpExcelDataset("select * from [" & cboSheetName.Text & "$]", fsFilePath)
            Catch ex As Exception
                MsgBox(ex.Message)
                Exit Sub
            End Try

            For i = 1 To 2
                lsFldFormat &= lsFldName(i) & "|"
            Next

            For i = 1 To 2
                If lsFldName(i).Trim <> fExcelDatatable.Columns(i - 1).ColumnName.ToUpper.Trim Then
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
            fsSql &= " and file_type = " & lnFileType & " "
            fsSql &= " and delete_flag ='N'"

            lnFileId = Val(gfExecuteScalar(fsSql, gOdbcConn))

            If lnFileId > 0 Then
                MsgBox("File already imported !", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gsProjectName)
                txtFileName.Focus()
                Exit Sub
            Else
                fsSql = ""
                fsSql &= " insert into arms_trn_tfile"
                fsSql &= " (import_date, file_name, sheet_name,"
                fsSql &= " file_type,import_by)"
                fsSql &= " values ("
                fsSql &= " sysdate(),"
                fsSql &= " '" & lsFileName & "','" & cboSheetName.Text.Trim & "',"
                fsSql &= " " & lnFileType & ",'" & gsLoginUserCode & "')"

                lnResult = gfInsertQry(fsSql, gOdbcConn)

                fsSql = " select max(file_gid) from arms_trn_tfile "
                lnFileId = gfExecuteScalar(fsSql, gOdbcConn)
            End If

            lsErrFileName = gsReportPath & "err.txt"
            If File.Exists(lsErrFileName) = True Then File.Delete(lsErrFileName)

            Call FileOpen(1, lsErrFileName, OpenMode.Output)
            Call PrintLine(1, "SNo;Error Desc")

            btnImport.Enabled = False

            With fExcelDatatable
                i = 0

                While i <= .Rows.Count - 1
                    With .Rows(i)
                        Me.Cursor = Cursors.WaitCursor
                        Application.DoEvents()

                        lbInsertFlag = True
                        lsDiscRemark = ""

                        lsBankBranch = Mid(QuoteFilter(.Item("BANK BRANCH").ToString), 1, 64)

                        If lsBankBranch = "" Then
                            lbInsertFlag = False
                            lsDiscRemark &= "Invalid bank branch,"
                        End If

                        ' Find duplicate
                        fsSql = ""
                        fsSql &= " select bankbranch_gid from arms_mst_tbankbranch "
                        fsSql &= " where bank_branch = '" & lsBankBranch & "' "
                        fsSql &= " and delete_flag = 'N' "

                        lnResult = Val(gfExecuteScalar(fsSql, gOdbcConn))

                        If lnResult = 1 Then
                            lbInsertFlag = False
                            lsDiscRemark &= "Duplicate record,"
                        End If

                        If lbInsertFlag = True Then
                            fsSql = "insert into arms_mst_tbankbranch (bank_branch) values ('" & lsBankBranch & "')"

                            lnResult = gfInsertQry(fsSql, gOdbcConn)

                            c += 1

                            frmMain.lblStatus.Text = "Imported Records Count : " & c
                            Application.DoEvents()
                        Else
                            Call PrintLine(1, (i + 1).ToString & ";" & lsDiscRemark)
                            d += 1

                            frmMain.lblStatus.Text = "Error Records Count : " & d
                            Application.DoEvents()
                        End If
                    End With

                    i += 1
                End While
            End With

            Call FileClose(1)

            MsgBox("Out of " & i & " record(s) " & c & " record(s) imported successfully ! ", MsgBoxStyle.Information, gsProjectName)

            If d > 0 Then
                MsgBox(d & " record(s) failed to import !", MsgBoxStyle.Critical, gsProjectName)
                Call gpOpenFile(lsErrFileName)
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

    Sub ImportBankMaster()
        Dim i As Integer
        Dim lsFldName(4) As String
        Dim lsFldFormat As String = ""
        Dim c As Integer = 0
        Dim d As Integer = 0

        Dim lsFileName As String = ""
        Dim lnFileId As Long

        Dim lnMicrId As Long = 0
        Dim lsMicrBankCode As String = ""
        Dim lsBankName As String = ""
        Dim lsBankCode As String = ""
        Dim lsBankAddr As String = ""
        Dim lnProdFlag As Integer = 0
        Dim lnSubProdFlag As Integer = 0
        Dim lsLocCode As String = ""
        Dim lsProd As String = ""
        Dim lsSubProd As String = ""
        Dim lsLocName As String = ""
        Dim lbInsertFlag As Boolean = False
        Dim lnResult As Long
        Dim lsErrFileName As String = ""
        Dim lsDiscRemark As String = ""



        lsFldName(1) = "SNO"
        lsFldName(2) = "BANK NAME"
        lsFldName(3) = "BANK CODE"
        lsFldName(4) = "BANK MICR CODE"


        lsFileName = QuoteFilter(fsFileName)

        Try
            '---------------------------------
            Try
                fExcelDatatable = gpExcelDataset("select * from [" & cboSheetName.Text & "$]", fsFilePath)
            Catch ex As Exception
                MsgBox(ex.Message)
                Exit Sub
            End Try

            For i = 1 To 4
                lsFldFormat &= lsFldName(i) & "|"
            Next

            For i = 1 To 4
                If lsFldName(i).Trim <> fExcelDatatable.Columns(i - 1).ColumnName.ToUpper.Trim Then
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
            fsSql &= " and file_type = " & gnFileBankMstUpload & " "
            fsSql &= " and delete_flag ='N'"

            lnFileId = Val(gfExecuteScalar(fsSql, gOdbcConn))

            If lnFileId > 0 Then
                MsgBox("File already imported !", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gsProjectName)
                txtFileName.Focus()
                Exit Sub
            Else
                fsSql = ""
                fsSql &= " insert into arms_trn_tfile"
                fsSql &= " (import_date, file_name, sheet_name,"
                fsSql &= " file_type,import_by)"
                fsSql &= " values ("
                fsSql &= " sysdate(),"
                fsSql &= " '" & lsFileName & "','" & cboSheetName.Text.Trim & "',"
                fsSql &= " " & gnFileBankMstUpload & ",'" & gsLoginUserCode & "')"

                lnResult = gfInsertQry(fsSql, gOdbcConn)

                fsSql = " select max(file_gid) from arms_trn_tfile "
                lnFileId = gfExecuteScalar(fsSql, gOdbcConn)
            End If

            lsErrFileName = gsReportPath & "err.txt"
            If File.Exists(lsErrFileName) = True Then File.Delete(lsErrFileName)

            Call FileOpen(1, lsErrFileName, OpenMode.Output)
            Call PrintLine(1, "SNo;Error Desc")

            btnImport.Enabled = False

            With fExcelDatatable
                i = 0

                While i <= .Rows.Count - 1
                    With .Rows(i)
                        Me.Cursor = Cursors.WaitCursor
                        Application.DoEvents()

                        lbInsertFlag = True
                        lsDiscRemark = ""

                        lsMicrBankCode = Mid(QuoteFilter(.Item("BANK MICR CODE").ToString), 1, 3)
                        lsBankName = Mid(QuoteFilter(.Item("BANK NAME").ToString), 1, 128)
                        lsBankCode = Mid(QuoteFilter(.Item("BANK CODE").ToString), 1, 3)


                        If lsMicrBankCode = "" Then
                            lbInsertFlag = False
                            lsDiscRemark &= "Micr code is empty,"
                        End If


                        ' Find micr_gid
                        fsSql = ""
                        fsSql &= " select bank_gid from arms_mst_tbank "
                        fsSql &= " where bank_code = '" & lsBankCode & "' "
                        fsSql &= " and delete_flag = 'N' "

                        lnMicrId = Val(gfExecuteScalar(fsSql, gOdbcConn))

                        If lbInsertFlag = True Then
                            If lnMicrId = 0 Then
                                fsSql = ""
                                fsSql &= " insert into arms_mst_tbank (bank_code,bank_micr_code,bank_name) values ("
                                fsSql &= " '" & lsBankCode & "',"
                                fsSql &= " '" & lsMicrBankCode & "',"
                                fsSql &= " '" & lsBankName & "')"
                            Else
                                fsSql = ""
                                fsSql &= " update arms_mst_tbank set "
                                fsSql &= " bank_code = '" & lsBankCode & "',"
                                fsSql &= " bank_micr_code = '" & lsMicrBankCode & "',"
                                fsSql &= " bank_name = '" & lsBankName & "'"
                                fsSql &= " where bank_gid = " & lnMicrId & " "
                                fsSql &= " and delete_flag = 'N' "
                            End If

                            lnResult = gfInsertQry(fsSql, gOdbcConn)

                            c += 1

                            frmMain.lblStatus.Text = "Imported Records Count : " & c
                            Application.DoEvents()
                        Else
                            Call PrintLine(1, c.ToString & ";" & lsDiscRemark)
                            d += 1
                            frmMain.lblStatus.Text = "Error Records Count : " & d
                            Application.DoEvents()
                        End If
                    End With

                    i += 1
                End While
            End With

            Call FileClose(1)

            MsgBox("Out of " & i & " record(s) " & c & " record(s) imported successfully ! ", MsgBoxStyle.Information, gsProjectName)

            If d > 0 Then
                MsgBox(d & " record(s) failed to import !", MsgBoxStyle.Critical, gsProjectName)
                Call gpOpenFile(lsErrFileName)
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

    Sub ImportPresentationdelete()
        Dim i As Integer
        Dim lsFldName(4) As String
        Dim lsFldFormat As String = ""
        Dim c As Integer = 0
        Dim d As Integer = 0

        Dim lsFileName As String = ""
        Dim lnFileId As Long

        Dim lnRplob_gid As Long = 0
        Dim lsChqgid As String = ""
        Dim lsChqNo As String = ""
        Dim lsChqDate As String = ""

        Dim lsBankAddr As String = ""
        Dim lnProdFlag As Integer = 0
        Dim lnSubProdFlag As Integer = 0
        Dim lsLocCode As String = ""
        Dim lsProd As String = ""
        Dim lsSubProd As String = ""
        Dim lsLocName As String = ""
        Dim lbInsertFlag As Boolean = False
        Dim lnResult As Long
        Dim lsErrFileName As String = ""
        Dim lsDiscRemark As String = ""



        lsFldName(1) = "SNO"
        lsFldName(2) = "CHQ GID"
        lsFldName(3) = "CHQ NO"
        lsFldName(4) = "CHQ DATE"


        lsFileName = QuoteFilter(fsFileName)

        Try
            '---------------------------------
            Try
                fExcelDatatable = gpExcelDataset("select * from [" & cboSheetName.Text & "$]", fsFilePath)
            Catch ex As Exception
                MsgBox(ex.Message)
                Exit Sub
            End Try

            For i = 1 To 4
                lsFldFormat &= lsFldName(i) & "|"
            Next

            For i = 1 To 4
                If lsFldName(i).Trim <> fExcelDatatable.Columns(i - 1).ColumnName.ToUpper.Trim Then
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
            fsSql &= " and file_type = " & gnFilePresentationdelete & " "
            fsSql &= " and delete_flag ='N'"

            lnFileId = Val(gfExecuteScalar(fsSql, gOdbcConn))

            If lnFileId > 0 Then
                MsgBox("File already imported !", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gsProjectName)
                txtFileName.Focus()
                Exit Sub
            Else
                fsSql = ""
                fsSql &= " insert into arms_trn_tfile"
                fsSql &= " (import_date, file_name, sheet_name,"
                fsSql &= " file_type,import_by)"
                fsSql &= " values ("
                fsSql &= " sysdate(),"
                fsSql &= " '" & lsFileName & "','" & cboSheetName.Text.Trim & "',"
                fsSql &= " " & gnFilePresentationdelete & ",'" & gsLoginUserCode & "')"

                lnResult = gfInsertQry(fsSql, gOdbcConn)

                fsSql = " select max(file_gid) from arms_trn_tfile "
                lnFileId = gfExecuteScalar(fsSql, gOdbcConn)
            End If

            lsErrFileName = gsReportPath & "err.txt"
            If File.Exists(lsErrFileName) = True Then File.Delete(lsErrFileName)

            Call FileOpen(1, lsErrFileName, OpenMode.Output)
            Call PrintLine(1, "SNo;Error Desc")

            btnImport.Enabled = False

            With fExcelDatatable
                i = 0

                While i <= .Rows.Count - 1
                    With .Rows(i)
                        Me.Cursor = Cursors.WaitCursor
                        Application.DoEvents()

                        lbInsertFlag = True
                        lsDiscRemark = ""

                        lsChqgid = Mid(QuoteFilter(.Item("CHQ GID").ToString), 1, 10)
                        lsChqNo = Mid(QuoteFilter(.Item("CHQ NO").ToString), 1, 6)
                        lsChqDate = QuoteFilter(.Item("CHQ DATE").ToString)


                        If lsChqgid = "" Then
                            lbInsertFlag = False
                            lsDiscRemark &= "Chq Id is empty,"
                        End If

                        If lsChqNo = "" Then
                            lbInsertFlag = False
                            lsDiscRemark &= "Chq No is empty,"
                        End If


                        ' Find rplob_gid
                        fsSql = ""
                        fsSql &= "  select rplob_gid from arms_trn_trplob "
                        fsSql &= " where chq_gid = '" & lsChqgid & "'"
                        fsSql &= " and chq_gid > 0 "
                        fsSql &= " and delete_flag = 'N'"

                        lnRplob_gid = Val(gfExecuteScalar(fsSql, gOdbcConn))

                        If lnRplob_gid = 0 Then
                            lbInsertFlag = False
                            lsDiscRemark &= "Chq Id is not Valid,"
                        End If

                        If lbInsertFlag = True Then
                            If lnRplob_gid > 0 Then
                                'Cmd by Mohan on 08-12-2022
                                'fsSql = ""
                                'fsSql &= " update arms_trn_trplob set "
                                'fsSql &= " update_date = sysdate(),"
                                'fsSql &= " update_by = '" & gsLoginUserCode & "',"
                                'fsSql &= " delete_flag = 'Y'"
                                'fsSql &= " where rplob_gid = '" & lnRplob_gid & "' "
                                'fsSql &= " and chq_gid=0"
                                'fsSql &= " and delete_flag = 'N' "

                                Dim j As Integer = 0
                                Call ConOpenOdbc(ServerDetails)
                                cmd = New MySqlCommand("pr_arms_set_undorplobchq", gOdbcConn)
                                cmd.CommandType = CommandType.StoredProcedure
                                cmd.Parameters.AddWithValue("?pr_rplob_gid", lnRplob_gid)
                                'out put Para
                                cmd.Parameters.Add("?pr_result", MySqlDbType.Int32)
                                cmd.Parameters("?pr_result").Direction = ParameterDirection.Output
                                cmd.Parameters.Add("?pr_msg", MySqlDbType.VarChar)
                                cmd.Parameters("?pr_msg").Direction = ParameterDirection.Output
                                cmd.ExecuteNonQuery()
                                Call ConCloseOdbc(ServerDetails)
                                Dim res As Integer = Val(cmd.Parameters("?pr_result").Value.ToString())
                                If (res = 0) Then
                                    MsgBox(cmd.Parameters("?pr_msg").Value.ToString())
                                    'Else
                                    '    MsgBox("Record undo successfully !", MsgBoxStyle.Information, gsProjectName)
                                End If

                            End If

                            lnResult = gfInsertQry(fsSql, gOdbcConn)

                            c += 1

                            frmMain.lblStatus.Text = "Imported Records Count : " & c
                            Application.DoEvents()
                        Else
                            Call PrintLine(1, c.ToString & ";" & lsDiscRemark)
                            d += 1
                            frmMain.lblStatus.Text = "Error Records Count : " & d
                            Application.DoEvents()
                        End If
                    End With

                    i += 1
                End While
            End With

            Call FileClose(1)

            MsgBox("Out of " & i & " record(s) " & c & " record(s) undo successfully ! ", MsgBoxStyle.Information, gsProjectName)

            If d > 0 Then
                MsgBox(d & " record(s) failed to import !", MsgBoxStyle.Critical, gsProjectName)
                Call gpOpenFile(lsErrFileName)
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
End Class