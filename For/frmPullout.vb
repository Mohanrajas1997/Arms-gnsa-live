Imports System.IO
Imports System.IO.FileStream
Imports MySql.Data.MySqlClient
'Imports System.Data.Odbc
'Imports System.Data.OleDb
Imports System.Data
Imports System.Security.Cryptography

Public Class frmPullout

#Region "Local Declaration"
    Dim lnImportFlag As Integer
    Dim fsSql As String
    Dim lnResult As Long
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

    Private Sub btnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click
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

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        If MsgBox("Do you want to Close?", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
            MyBase.Close()
        End If
    End Sub

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

    Private Sub frmPullout_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            gsQry = " select entity_gid, entity_name from arms_mst_tentity"
            gsQry &= " where delete_flag='N' "
            gsQry &= " order by entity_name "
            Call gpBindCombo(gsQry, "entity_name", "entity_gid", cboEntity, gOdbcConn)
            KeyPreview = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ClearAll()
        Call frmCtrClear(Me)
    End Sub

    Sub ImportPaymentFile()
        Dim i As Integer
        Dim res As Integer
        Dim lsFldName(6) As String
        Dim lsFldFormat As String = ""
        Dim c As Integer = 0
        Dim d As Integer = 0
        Dim lsFileName As String = ""
        Dim lsSheetName As String = ""
        Dim lnFileId As Long
        Dim lnEntityId As Long = 0
        Dim lsEntityCode As String = ""
        Dim lnPulloutId As Long = 0
        Dim ldChqDate As Date
        Dim lsChqDate As String = ""
        Dim lsContactNo As String = ""
        Dim lsChqNo As String = ""
        Dim lnChqAmt As Double = 0
        Dim lsRemark As String = ""
        Dim lsDiscRemark As String = ""
        Dim lbInsertFlag As Boolean = False
        Dim lnResult As Long
        Dim frm As frmQuickView

        Const lnFileType As Integer = 5

        lsFldName(1) = "SNO"
        lsFldName(2) = "ENTITY CODE"
        lsFldName(3) = "CONTRACT NO"
        lsFldName(4) = "CHEQUE DATE"
        lsFldName(5) = "CHEQUE NO"
        lsFldName(6) = "CHEQUE AMOUNT"
        lsFldName(7) = "PULLOUT REASON"

        lsFileName = QuoteFilter(fsFileName)

        Try
            '---------------------------------
            Try
                fExcelDatatable = gpExcelDataset("select * from [" & cboSheetName.Text & "$]", fsFilePath)
            Catch ex As Exception
                MsgBox(ex.Message)
                Exit Sub
            End Try

            For i = 1 To 6
                lsFldFormat &= lsFldName(i) & "|"
            Next

            For i = 1 To 6
                If lsFldName(i).Trim <> fExcelDatatable.Columns(i - 1).ColumnName.ToUpper.Trim Then
                    MsgBox("Excel Column Setting is wrong (" & i & ")" & vbCrLf & vbCrLf _
                    & lsFldName(i).ToUpper.Trim & " : " & fExcelDatatable.Columns(i - 1).ColumnName.ToUpper.Trim & ":" & vbCrLf & vbCrLf _
                    & "Correct format is " & vbCrLf & vbCrLf & lsFldFormat, vbOKOnly + vbExclamation, gsProjectName)
                    Exit Sub
                End If
            Next

            'File Name Duplicate
            fsSql = ""
            fsSql &= " select entity_gid from arms_trn_tfile"
            fsSql &= " where 1=1 "
            fsSql &= " and file_name = '" & lsFileName & "'"
            fsSql &= " and sheet_name='" & cboSheetName.Text & "'"
            fsSql &= " and file_type = " & lnFileType & " "
            fsSql &= " and delete_flag ='N'"

            lnEntityId = Val(gfExecuteScalar(fsSql, gOdbcConn))

            If Not lnEntityId = 0 Then
                MsgBox("File Already Imported !", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gsProjectName)
                txtFileName.Focus()
                Exit Sub
            Else

                Select Case ""
                    Case dpDate.Text
                        MsgBox("Bank name cannot be empty !", MsgBoxStyle.Critical, gsProjectName)
                        dpDate.Focus()
                        Exit Sub
                    Case cboEntity.Text
                        MsgBox("Bank Code cannot be empty !", MsgBoxStyle.Critical, gsProjectName)
                        cboEntity.Focus()
                        Exit Sub
                    Case txtFileName.Text
                        MsgBox("Bank Code cannot be empty !", MsgBoxStyle.Critical, gsProjectName)
                        txtFileName.Focus()
                        Exit Sub
                    Case cboSheetName.Text
                        MsgBox("Bank Code cannot be empty !", MsgBoxStyle.Critical, gsProjectName)
                        cboSheetName.Focus()
                        Exit Sub
                End Select
                If cboEntity.Text.Trim = "" Then
                    lsChqDate = Format(CDate(dpDate.Text), "yyyy-MM-dd")
                    lnEntityId = cboEntity.SelectedValue
                    lsFileName = txtFileName.Text
                    lsSheetName = cboSheetName.Text
                    Using cmd As New MySqlCommand("pr_arms_trn_tfile", gOdbcConn)
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.Parameters.Add("?pr_entity_gid", lnEntityId)
                        cmd.Parameters("?pr_entity_gid").Direction = ParameterDirection.Input
                        cmd.Parameters.Add("?pr_file_name", lsFileName)
                        cmd.Parameters("?pr_file_name").Direction = ParameterDirection.Input
                        cmd.Parameters.Add("?pr_sheet_name", lsSheetName)
                        cmd.Parameters("?pr_sheet_name").Direction = ParameterDirection.Input
                        cmd.Parameters.Add("?pr_file_type", gnFilePullout)
                        cmd.Parameters("?pr_file_type").Direction = ParameterDirection.Input
                        cmd.Parameters.Add("?pr_action", "INSERT")
                        cmd.Parameters("?pr_action").Direction = ParameterDirection.Input
                        'Out put Para
                        cmd.Parameters.Add("?pr_result", MySqlDbType.Int32)
                        cmd.Parameters("?pr_result").Direction = ParameterDirection.Output
                        cmd.Parameters.Add("?pr_err_msg", MySqlDbType.VarChar)
                        cmd.Parameters("?pr_err_msg").Direction = ParameterDirection.Output
                        cmd.ExecuteNonQuery()
                        res = cmd.Parameters("?pr_result").Value.ToString()
                        If (res = 0) Then
                            MsgBox(cmd.Parameters("?pr_err_msg").Value.ToString())
                            cboEntity.Focus()
                        Else
                            MsgBox(cmd.Parameters("?pr_result").Value.ToString() + Name + " " + "Recard Update Successfully !")
                            Call ClearAll()
                            cboEntity.Focus()
                        End If
                    End Using
                End If

            End If

            btnImport.Enabled = False

            With fExcelDatatable
                i = 0

                While i <= .Rows.Count - 1
                    With .Rows(i)
                        Me.Cursor = Cursors.WaitCursor
                        Application.DoEvents()

                        lbInsertFlag = True
                        lsDiscRemark = ""

                        lsEntityCode = Mid(QuoteFilter(.Item("ENTITY CODE").ToString), 1, 16)
                        lsChqDate = QuoteFilter(.Item("CHEQUE DATE").ToString)
                        lsContactNo = QuoteFilter(.Item("CONTRACT NO").ToString)
                        lsChqNo = Mid(Format(Val(QuoteFilter(.Item("CHEQUE NO").ToString)), "000000"), 1, 16)
                        If Val(lsChqNo) = 0 Then lsChqNo = ""
                        lnChqAmt = Math.Round(Val(QuoteFilter(.Item("CHEQUE AMOUNT").ToString)), 2)
                        lsRemark = Mid(QuoteFilter(.Item("PULLOUT REASON").ToString), 1, 255)

                        ' Find Dealer Code
                        fsSql = ""
                        fsSql &= " select pullout_gid from arms_trn_tpullout "
                        fsSql &= " where entity_gid = " & glEntityId & " "
                        fsSql &= " and file_gid = " & res & " "
                        fsSql &= " and contract_no = " & lsContactNo & " "
                        fsSql &= " and chq_date = " & lsChqDate & " "
                        fsSql &= " and chq_no = " & lsChqNo & " "
                        fsSql &= " and delete_flag = 'N' "

                        lnPulloutId = Val(gfExecuteScalar(fsSql, gOdbcConn))

                        If lnPulloutId = 0 Then
                            lbInsertFlag = False
                            lsDiscRemark &= "Invalid Entity code,"
                        End If

                        If IsDate(lsChqDate) = False Then
                            lbInsertFlag = False
                            lsDiscRemark &= "Invalid chq date,"
                        Else
                            ' Chk previous days
                            ldChqDate = CDate(lsChqDate)
                            lsChqDate = Format(ldChqDate, "yyyy-MM-dd")

                            lnResult = DateDiff(DateInterval.Day, Now, ldChqDate)

                            If lnResult > gnChqFutureDays Then
                                lbInsertFlag = False
                                lsDiscRemark &= "Chq date is greater then " & gnChqFutureDays & " future days,"
                            ElseIf lnResult < gnChqPrevDays * -1 Then
                                lbInsertFlag = False
                                lsDiscRemark &= "Chq date is less then " & gnChqFutureDays & " previous days,"
                            End If
                        End If

                        If lnChqAmt <= 0 Then
                            lbInsertFlag = False
                            lsDiscRemark &= "Invalid chq amount,"
                        End If

                        If gsClientRemarkFlag = "Y" Then
                            If lsRemark = "" Then
                                lbInsertFlag = False
                                lsDiscRemark &= "Remark cannot be empty,"
                            End If
                        End If

                        If Not (lsChqDate = "" And lnChqAmt = 0 And lnPulloutId = 0 And lsChqNo = "") Then
                            If lbInsertFlag = True Then

                                Using cmd As New MySqlCommand("pr_arms_trn_tpullout", gOdbcConn)
                                    cmd.CommandType = CommandType.StoredProcedure
                                    cmd.Parameters.Add("?pr_entity_gid", lnEntityId)
                                    cmd.Parameters("?pr_entity_gid").Direction = ParameterDirection.Input
                                    cmd.Parameters.Add("?pr_file_gid", res)
                                    cmd.Parameters("?pr_file_gid").Direction = ParameterDirection.Input
                                    cmd.Parameters.Add("?pr_contract_no", lsContactNo)
                                    cmd.Parameters("?pr_contract_no").Direction = ParameterDirection.Input
                                    cmd.Parameters.Add("?pr_chq_date", lsChqDate)
                                    cmd.Parameters("?pr_chq_date").Direction = ParameterDirection.Input
                                    cmd.Parameters.Add("?pr_chq_no", lsChqNo)
                                    cmd.Parameters("?pr_chq_no").Direction = ParameterDirection.Input
                                    cmd.Parameters.Add("?pr_chq_amount", lnChqAmt)
                                    cmd.Parameters("?pr_chq_amount").Direction = ParameterDirection.Input
                                    cmd.Parameters.Add("?pr_pullout_reason", lsRemark)
                                    cmd.Parameters("?pr_pullout_reason").Direction = ParameterDirection.Input
                                    cmd.Parameters.Add("?pr_action", "INSERT")
                                    cmd.Parameters("?pr_action").Direction = ParameterDirection.Input
                                    'Out put Para
                                    cmd.Parameters.Add("?pr_result", MySqlDbType.Int32)
                                    cmd.Parameters("?pr_result").Direction = ParameterDirection.Output
                                    cmd.Parameters.Add("?pr_err_msg", MySqlDbType.VarChar)
                                    cmd.Parameters("?pr_err_msg").Direction = ParameterDirection.Output
                                    cmd.ExecuteNonQuery()
                                    res = cmd.Parameters("?pr_result").Value.ToString()
                                    If (res = 0) Then
                                        MsgBox(cmd.Parameters("?pr_err_msg").Value.ToString())
                                        cboEntity.Focus()
                                    Else
                                        MsgBox(cmd.Parameters("?pr_result").Value.ToString() + Name + " " + "Recard Update Successfully !")
                                        Call ClearAll()
                                        cboEntity.Focus()
                                    End If
                                End Using

                                c += 1

                                'frmMain.lblStatus.Text = "Imported Records Count : " & c
                                Application.DoEvents()
                            Else
                                fsSql = ""
                                fsSql &= " insert into cpm_trn_terrpayment (file_gid,deal_code,chq_date,chq_no,amount,remark,disc_remark) values ("
                                fsSql &= " " & lnFileId & ","
                                fsSql &= " '" & lsDealCode & "',"
                                fsSql &= IIf(IsDate(lsChqDate), " '" & lsChqDate & "',", "null,")
                                fsSql &= " '" & lsChqNo & "',"
                                fsSql &= " " & lnChqAmt & ","
                                fsSql &= " '" & lsRemark & "',"
                                fsSql &= " '" & Mid(lsDiscRemark, 1, 255) & "')"

                                lnResult = gfInsertQry(fsSql, gOdbcConn)

                                d += 1

                                'frmMain.lblStatus.Text = "Error Records Count : " & d
                                Application.DoEvents()
                            End If
                        End If
                    End With

                    i += 1
                End While
            End With

            MsgBox("Out of " & i & " record(s) " & c & " record(s) imported successfully ! ", MsgBoxStyle.Information, gsProjectName)

            If d > 0 Then
                MsgBox(d & " record(s) failed to import !", MsgBoxStyle.Critical, gsProjectName)

                fsSql = ""
                fsSql &= " select * from cpm_trn_terrpayment "
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


End Class