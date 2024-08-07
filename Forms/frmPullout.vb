Imports System.IO
Imports System.IO.FileStream
Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Security.Cryptography

Public Class frmPullout

#Region "Local Declaration"
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
                    Call ImportPulloutFile()
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
            gsQry = " select CONCAT(entity_code,'-', entity_name) as EntityCode ,entity_gid from arms_mst_tentity"
            gsQry &= " where delete_flag='N' "
            gsQry &= " order by entity_name "
            Call gpBindCombo(gsQry, "EntityCode", "entity_gid", cboEntity, gOdbcConn)
            KeyPreview = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ClearAll()
        Call frmCtrClear(Me)
    End Sub

    Sub ImportPulloutFile()
        Dim i As Integer
        Dim res As Integer
        Dim lsFldName(8) As String
        Dim lsFldFormat As String = ""
        Dim c As Integer = 0
        Dim d As Integer = 0
        Dim lsFileName As String = ""
        Dim lsSheetName As String = ""
        Dim lnFileId As Long
        Dim lnEntityId As Long = 0
        Dim lsEntityCode As String = ""
        Dim lnPulloutId As Long = 0
        Dim lsChqDate As String = ""
        Dim lsContactNo As String = ""
        Dim lsChqNo As String = ""
        Dim lnChqAmt As Double = 0
        Dim lsRemark As String = ""
        Dim lsDiscRemark As String = ""
        Dim lsPacketNo As String = ""
        Dim lsTxt As String
        Dim lbInsertFlag As Boolean = False
        Dim lnResult As Integer
        Dim frm As frmQuickView

        Select Case ""
            Case cboEntity.Text
                MsgBox("Entity Code cannot be empty !", MsgBoxStyle.Critical, gsProjectName)
                cboEntity.Focus()
                Exit Sub
        End Select

        lsFldName(1) = "SNO"
        lsFldName(2) = "ENTITY CODE"
        lsFldName(3) = "CONTRACT NO"
        lsFldName(4) = "CHEQUE DATE"
        lsFldName(5) = "CHEQUE NO"
        lsFldName(6) = "CHEQUE AMOUNT"
        lsFldName(7) = "PULLOUT REASON"
        lsFldName(8) = "PACKET NO"

        lsFileName = QuoteFilter(fsFileName)

        Try
            '---------------------------------
            Try
                fExcelDatatable = gpExcelDataset("select * from [" & cboSheetName.Text & "$]", fsFilePath)
            Catch ex As Exception
                MsgBox(ex.Message)
                Exit Sub
            End Try

            For i = 1 To 8
                lsFldFormat &= lsFldName(i) & "|"
            Next
            For i = 1 To 8
                If lsFldName(i).Trim <> fExcelDatatable.Columns(i - 1).ColumnName.ToUpper.Trim Then
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
                    lsEntityCode = Mid(QuoteFilter(.Rows(i).Item("ENTITY CODE").ToString), 1, 16).ToUpper()

                    If lsEntityCode <> lsTxt Then
                        MsgBox("Entity code mismatch in line no : " & (i + 1).ToString, MsgBoxStyle.Critical, gsProjectName)
                        Exit Sub
                    End If
                Next i
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

            Using cmd As New MySqlCommand("pr_arms_trn_tfile", gOdbcConn)
                Call ConOpenOdbc(ServerDetails)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("?pr_entity_gid", lnEntityId)
                cmd.Parameters("?pr_entity_gid").Direction = ParameterDirection.Input
                cmd.Parameters.AddWithValue("?pr_file_name", lsFileName)
                cmd.Parameters("?pr_file_name").Direction = ParameterDirection.Input
                cmd.Parameters.AddWithValue("?pr_sheet_name", lsSheetName)
                cmd.Parameters("?pr_sheet_name").Direction = ParameterDirection.Input
                cmd.Parameters.AddWithValue("?pr_file_type", gnFilePullout)
                cmd.Parameters("?pr_file_type").Direction = ParameterDirection.Input
                cmd.Parameters.AddWithValue("?pr_action_by", gsLoginUserCode)
                cmd.Parameters("?pr_action_by").Direction = ParameterDirection.Input
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
                lnFileId = lnResult

                If (lnResult = 0) Then
                    MsgBox(cmd.Parameters("?pr_err_msg").Value.ToString())
                    Exit Sub
                End If
            End Using

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
                        If IsDate(lsChqDate) Then
                            lsChqDate = Format(CDate(lsChqDate), "yyyy-MM-dd")
                        Else
                            lsChqDate = ""
                        End If

                        lsContactNo = QuoteFilter(.Item("CONTRACT NO").ToString)
                        lsChqNo = Mid(Format(Val(QuoteFilter(.Item("CHEQUE NO").ToString)), "000000"), 1, 16)
                        If Val(lsChqNo) = 0 Then lsChqNo = ""
                        lnChqAmt = Math.Round(Val(QuoteFilter(.Item("CHEQUE AMOUNT").ToString)), 2)
                        lsRemark = Mid(QuoteFilter(.Item("PULLOUT REASON").ToString), 1, 255)
                        lsPacketNo = Mid(QuoteFilter(.Item("PACKET NO").ToString), 1, 64)

                        Using cmd As New MySqlCommand("pr_arms_trn_tpullout", gOdbcConn)
                            Call ConOpenOdbc(ServerDetails)
                            cmd.CommandType = CommandType.StoredProcedure
                            cmd.Parameters.AddWithValue("?pr_pullout_gid", 0)
                            cmd.Parameters("?pr_pullout_gid").Direction = ParameterDirection.Input
                            cmd.Parameters.AddWithValue("?pr_entity_gid", lnEntityId)
                            cmd.Parameters("?pr_entity_gid").Direction = ParameterDirection.Input
                            cmd.Parameters.AddWithValue("?pr_file_gid", lnFileId)
                            cmd.Parameters("?pr_file_gid").Direction = ParameterDirection.Input
                            cmd.Parameters.AddWithValue("?pr_contract_no", lsContactNo)
                            cmd.Parameters("?pr_contract_no").Direction = ParameterDirection.Input
                            cmd.Parameters.AddWithValue("?pr_chq_date", lsChqDate)
                            cmd.Parameters("?pr_chq_date").Direction = ParameterDirection.Input
                            cmd.Parameters.AddWithValue("?pr_chq_no", lsChqNo)
                            cmd.Parameters("?pr_chq_no").Direction = ParameterDirection.Input
                            cmd.Parameters.AddWithValue("?pr_chq_amount", lnChqAmt)
                            cmd.Parameters("?pr_chq_amount").Direction = ParameterDirection.Input
                            cmd.Parameters.AddWithValue("?pr_pullout_reason", lsRemark)
                            cmd.Parameters("?pr_pullout_reason").Direction = ParameterDirection.Input
                            cmd.Parameters.AddWithValue("?pr_packet_no", lsPacketNo)
                            cmd.Parameters("?pr_packet_no").Direction = ParameterDirection.Input
                            cmd.Parameters.AddWithValue("?pr_action_by", gsLoginUserCode)
                            cmd.Parameters("?pr_action_by").Direction = ParameterDirection.Input
                            cmd.Parameters.AddWithValue("?pr_action", "INSERT")
                            cmd.Parameters("?pr_action").Direction = ParameterDirection.Input
                            'Out put Para
                            cmd.Parameters.Add("?pr_result", MySqlDbType.Int32)
                            cmd.Parameters("?pr_result").Direction = ParameterDirection.Output
                            cmd.Parameters.Add("?pr_err_msg", MySqlDbType.VarChar)
                            cmd.Parameters("?pr_err_msg").Direction = ParameterDirection.Output
                            cmd.ExecuteNonQuery()
                            Call ConCloseOdbc(ServerDetails)
                            res = Val(cmd.Parameters("?pr_result").Value.ToString())

                            If res > 0 Then
                                c += 1
                            Else
                                d += 1
                                lsDiscRemark = "Line " & (i + 1).ToString & ":" & cmd.Parameters("?pr_err_msg").Value.ToString()
                            End If
                        End Using

                        If (res = 0) Then
                            Using cmd As New MySqlCommand("pr_arms_trn_terrmsg", gOdbcConn)
                                Call ConOpenOdbc(ServerDetails)
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
                                res = Val(cmd.Parameters("?pr_result").Value.ToString())
                                If (res = 0) Then
                                    MsgBox(cmd.Parameters("?pr_err_msg").Value.ToString())
                                    ClearAll()
                                End If
                            End Using
                        End If

                        Application.DoEvents()
                    End With
                    i += 1
                End While
            End With

            MsgBox("Out of " & i & " record(s) " & c & " record(s) imported successfully ! ", MsgBoxStyle.Information, gsProjectName)
            fsSql = ""
            fsSql &= " select * from arms_trn_tpullout "
            fsSql &= " where file_gid = " & lnFileId & " "
            fsSql &= " and delete_flag = 'N' "

            frm = New frmQuickView(gOdbcConn, fsSql)
            frm.ShowDialog()

            ClearAll()
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


End Class