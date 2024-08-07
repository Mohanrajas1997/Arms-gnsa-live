﻿Imports System.IO
Imports System.IO.FileStream
Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Security.Cryptography

Public Class frmRplobNew

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
                    Call ImportRplobFile()
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

    Sub ImportRplobFile()
        Dim i As Integer
        Dim c As Integer
        Dim d As Integer
        Dim lbInsertFlag As Boolean = False
        Dim lsDiscRemark As String = ""
        Dim lsFldFormat As String = ""
        Dim lsFldName(8) As String
        Dim lsTxt As String
        Dim lsContractNumber As String = ""
        Dim lsCycleDate As String = ""
        Dim lsChqDate As String = ""
        Dim lsChqNo As String = ""
        Dim lsPayeeName As String = ""
        Dim lnChqAmt As Double = 0
        Dim lsFileName As String = ""
        Dim lsEntityCode As String = ""
        Dim lnFileId As Long = 0
        Dim lnEntityId As Long = 0
        Dim lsSheetName As String = ""
        Dim frm As frmQuickView
        Dim cmd As MySqlCommand

        Select Case ""
            Case cboEntity.Text
                MsgBox("Entity Can Not Be Empty!", MsgBoxStyle.Information, gsProjectName)
                cboEntity.Focus()
                Exit Sub
        End Select

        lsFldName(1) = "Sno"
        lsFldName(2) = "Client Code"
        lsFldName(3) = "Contract No"
        lsFldName(4) = "Cycle Date"
        lsFldName(5) = "Chq Date"
        lsFldName(6) = "Chq No"
        lsFldName(7) = "Chq Amount"
        lsFldName(8) = "Payee Name"

        lsFileName = QuoteFilter(fsFileName)
        Try
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
                    lsChqDate = Mid(QuoteFilter(.Rows(i).Item("Chq Date").ToString), 1, 16).ToUpper
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
            cmd.Parameters.AddWithValue("?pr_file_type", gnFileRplob)
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

            With fExcelDatatable
                i = 0

                While i <= .Rows.Count - 1
                    With .Rows(i)
                        Me.Cursor = Cursors.WaitCursor
                        Application.DoEvents()

                        lbInsertFlag = True
                        lsDiscRemark = ""

                        lsContractNumber = QuoteFilter(.Item("Contract No").ToString)
                        lsEntityCode = Mid(QuoteFilter(.Item("Client Code").ToString), 1, 16)
                        lsPayeeName = QuoteFilter(.Item("Payee Name").ToString)
                        lsCycleDate = QuoteFilter(.Item("Cycle Date").ToString)
                        If IsDate(lsCycleDate) Then
                            lsCycleDate = Format(CDate(lsCycleDate), "yyyy-MM-dd")
                        Else
                            lsCycleDate = ""
                        End If

                        lsChqDate = QuoteFilter(.Item("Chq Date").ToString)
                        If IsDate(lsChqDate) Then
                            lsChqDate = Format(CDate(lsChqDate), "yyyy-MM-dd")
                        Else
                            lsChqDate = ""
                        End If

                        lnChqAmt = Math.Round(Val(QuoteFilter(.Item("Chq Amount").ToString)), 2)
                        lsChqNo = Mid(Format(Val(QuoteFilter(.Item("Chq No").ToString)), "000000"), 1, 16)
                        If Val(lsChqNo) = 0 Then lsChqNo = ""

                        Call ConOpenOdbc(ServerDetails)
                        cmd = New MySqlCommand("pr_arms_trn_trplob", gOdbcConn)
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.Parameters.AddWithValue("?pr_entity_gid", lnEntityId)
                        cmd.Parameters("?pr_entity_gid").Direction = ParameterDirection.Input
                        cmd.Parameters.AddWithValue("?pr_file_gid", lnFileId)
                        cmd.Parameters("?pr_file_gid").Direction = ParameterDirection.Input
                        cmd.Parameters.AddWithValue("?pr_contract_no", lsContractNumber)
                        cmd.Parameters("?pr_contract_no").Direction = ParameterDirection.Input
                        cmd.Parameters.AddWithValue("?pr_payee_name", lsPayeeName)
                        cmd.Parameters("?pr_payee_name").Direction = ParameterDirection.Input
                        cmd.Parameters.AddWithValue("?pr_cycle_date", CDate(lsCycleDate))
                        cmd.Parameters("?pr_cycle_date").Direction = ParameterDirection.Input
                        cmd.Parameters.AddWithValue("?pr_chq_date", CDate(lsChqDate))
                        cmd.Parameters("?pr_chq_date").Direction = ParameterDirection.Input
                        cmd.Parameters.AddWithValue("?pr_chq_no", lsChqNo)
                        cmd.Parameters("?pr_chq_no").Direction = ParameterDirection.Input
                        cmd.Parameters.AddWithValue("?pr_chq_amount", lnChqAmt)
                        cmd.Parameters("?pr_chq_amount").Direction = ParameterDirection.Input
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
            fsSql &= " select * from arms_trn_trplob "
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

    Private Sub frmRplobNew_Load(sender As Object, e As EventArgs) Handles Me.Load
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