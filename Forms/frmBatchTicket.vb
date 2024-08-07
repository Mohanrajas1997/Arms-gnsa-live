Imports System.IO
Imports System.IO.FileStream
Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Windows.Forms
Imports iTextSharp
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class frmBatchTicket

    Dim lfobj As New FileIO.FileSystem
    Private streamToPrint As StreamReader
    Friend TextToBePrinted As String
    Dim todaysdate As String = String.Format("{0:dd/MM/yyyy}", DateTime.Now)
    Private doc As Document

    Dim mnPrintMaxLen As Integer = 99
    Dim mnPrintMaxRows As Integer = 60
    Dim mnPageRow As Integer = 0
    Dim mnPageNo As Integer = 0
    Dim mnLineNo As Integer = 0
    Dim mnTotDrAmt As Double = 0
    Dim mnTotCrAmt As Double = 0
    Dim msColHead(6) As String
    Dim mnColAlign(6) As Integer
    Dim mnColWidth(6) As Integer

    Dim cmd As MySqlCommand
    Dim da As MySqlDataAdapter
    Dim dt As DataTable

    Dim cmdCon As MySqlCommand
    Dim daCon As MySqlDataAdapter
    Dim dtCon As DataTable

    Dim cmdAll As MySqlCommand
    Dim daAll As MySqlDataAdapter
    Dim dtAll As DataTable

    Dim cmdHead As MySqlCommand
    Dim daHead As MySqlDataAdapter
    Dim dtHead As DataTable

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Call LoadData()
    End Sub

    Private Sub LoadData()
        Dim i As Integer
        Dim lsSql As String
        Dim lnEntityId As Long
        Dim lsCycleDate As String

        Dim lsCond As String

        Try
            lsCond = ""

            If cboEntity.SelectedIndex = -1 Or cboEntity.Text = "" Then
                MsgBox("Please select the Entity ?", MsgBoxStyle.Information, gsProjectName)
                cboEntity.Focus()
                Exit Sub
            End If

            If txtPickupLoc.Text = "" Then
                MessageBox.Show("Please fill pickup location !", gsProjectName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtPickupLoc.Focus()
                Exit Sub
            End If

            lnEntityId = Val(cboEntity.SelectedValue.ToString)
            lsCycleDate = Format(CDate(dtpCycleDate.Text), "yyyy-MM-dd")

            lsCond &= " and cycle_date =' " & lsCycleDate & " '"
            lsCond &= " and entity_gid = " & lnEntityId & " "

            Call gfInsertQry("set @a := 0", gOdbcConn)

            lsSql = ""
            lsSql &= " SELECT a.batch_gid,@a:=@a+1 as 'SNo',a.batch_gid as 'Batch Id',a.cycle_date as 'Cycle Date',a.loc_code as 'Loc Code',"
            lsSql &= " b.prod_code as 'Prod Code',a.tot_count as 'Total Count',a.tot_amount as 'Total Amount' "
            lsSql &= " from arms_trn_tbatch as a "
            lsSql &= " inner join arms_mst_tproduct as b on b.prod_flag = a.prod_flag and b.delete_flag = 'N' "
            lsSql &= " where 1 = 1 "
            lsSql &= lsCond
            lsSql &= " and a.delete_flag = 'N' "

            dgvBatch.Columns.Clear()

            gpPopGridView(dgvBatch, lsSql, gOdbcConn)

            For i = 0 To dgvBatch.Columns.Count - 1
                dgvBatch.Columns(i).ReadOnly = True
                dgvBatch.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next i


            Dim checkBoxColumn As New DataGridViewCheckBoxColumn()
            checkBoxColumn.HeaderText = ""
            checkBoxColumn.Width = 30
            checkBoxColumn.Name = "checkBoxColumn"
            dgvBatch.Columns.Insert(0, checkBoxColumn)

            ' MessageBox.Show("Selected Values" & message)

            dgvBatch.Columns("batch_gid").Visible = False

            lblRecordCount.Text = "Total Records : " & dgvBatch.RowCount

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearAll()
    End Sub

    Private Sub frmBatchTicket_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            ' dtpCycleDate.MaxDate = Date.Today()

            gsQry = " select CONCAT(entity_code,'-', entity_name) as EntityCode ,entity_gid from arms_mst_tentity"
            gsQry &= " where delete_flag='N' "
            gsQry &= " order by entity_name "

            Call gpBindCombo(gsQry, "EntityCode", "entity_gid", cboEntity, gOdbcConn)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Dim Bselectedbatchid As Integer
        Dim list As New List(Of Integer)
        Dim lsPdfFile As String

        Try
            For Each row As DataGridViewRow In dgvBatch.Rows
                Dim isSelected As Boolean = Convert.ToBoolean(row.Cells("checkBoxColumn").Value)
                If isSelected Then
                    Bselectedbatchid = row.Cells("batch_gid").Value
                    list.Add(Bselectedbatchid)
                End If
            Next

            doc = New Document()

            lsPdfFile = gsAsciiPath & "\BatchTicket.pdf"
            If File.Exists(lsPdfFile) Then File.Delete(lsPdfFile)

            PdfWriter.GetInstance(doc, New FileStream(lsPdfFile, FileMode.Create))
            doc.Open()

            If gOdbcConn.State = ConnectionState.Closed Then gOdbcConn.Open()

            For Each num In list
                gnBatchId = num

                cmd = New MySqlCommand("pr_arms_get_batch", gOdbcConn)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("?pr_batch_gid", gnBatchId)
                cmd.Parameters("?pr_batch_gid").Direction = ParameterDirection.Input

                dt = New DataTable
                da = New MySqlDataAdapter(cmd)
                da.Fill(dt)

                Dim lsTxtFile As String = gsAsciiPath & "\BatchTicket.txt"

                If File.Exists(lsTxtFile) Then File.Delete(lsTxtFile)

                Using sw As New StreamWriter(lsTxtFile)
                    'sw.WriteLine(" ")
                    'sw.WriteLine(" ")
                    sw.WriteLine("" + ToRight(" ", 4) + "" + ToRight("CITICHECK", 11) + "- " + ToRight("Deposit Slip", 17) + "" + ToRight("CHENNAI", 35) + "")
                    sw.WriteLine("" + ToRight("------------------------------------------------------------------------------------------------------", 85) + "")
                    sw.WriteLine("" + ToRight("Dep.No", 11) + "" + ToRight("|", 2) + "" + ToRight("Cust.Code", 14) + "" + ToRight("|", 4) + "" + ToRight("Date", 27) + " " + ToRight("Gross Dep. Amount", 26) + "")
                    sw.WriteLine("" + ToRight(" ", 12) + "|" + ToRight(" ", 15) + "|")
                    sw.WriteLine("" + ToRight(gnBatchId.ToString, 11) + "" + ToRight("|", 2) + "" + ToRight(dt.Rows(0)("Entity Code").ToString, 14) + "" + ToRight("|", 4) + "" + ToRight(dt.Rows(0)("Cycle Date").ToString, 27) + "" + ToLeft(Format(dt.Rows(0)("Totel Amount"), "0.00"), 18) + "")
                    sw.WriteLine("" + ToRight(" ", 12) + "|" + ToRight(" ", 15) + "|")
                    sw.WriteLine("" + ToRight(" ", 12) + "|" + ToRight(" ", 15) + "|" + ToRight("---------------------------------------------------------", 57) + "")
                    sw.WriteLine("" + ToRight(" ", 12) + "|" + ToRight(" ", 15) + "|" + ToRight("PickUp Location", 23) + "" + ToRight("No. of Cheques", 22) + "" + ToRight("Customer Ref", 12) + "")
                    sw.WriteLine("" + ToRight(" ", 12) + "|" + ToRight(" ", 15) + "|" + ToRight(txtPickupLoc.Text, 15) + "  " + ToRight(" ", 8) + "     " + ToRight(dt.Rows(0)("Totel Count").ToString, 14) + "")
                    sw.WriteLine("" + ToRight(" ", 12) + "|" + ToRight(" ", 15) + "|")
                    sw.WriteLine("" + ToRight(" ", 12) + "|" + ToRight(" ", 15) + "|")
                    sw.WriteLine("" + ToRight("------------------ ", 11) + "-" + ToRight("---------------------", 15) + "-" + ToRight("---------------------------------------------------------", 57) + "")
                    sw.WriteLine("" + ToRight("Details", 7) + "" + ToRight(" ", 71) + "" + ToRight("Amount", 7) + "")
                    sw.WriteLine("")
                    sw.WriteLine("" + ToRight("As per Enclosure", 17) + "" + ToRight(dt.Rows(0)("Totel Count").ToString, 4) + "" + ToRight("Cheques", 7) + "" + ToRight("", 38) + "" + ToLeft(Format(dt.Rows(0)("Totel Amount"), "0.00"), 18) + "")
                    'sw.WriteLine("")
                    'sw.WriteLine("")
                    'sw.WriteLine("")
                    sw.WriteLine("" + ToRight("------------------------------------------------------------------------------------------------------", 85) + "")
                    sw.WriteLine("" + ToRight(" ", 58) + "" + ToRight("Total", 8) + "" + ToLeft(Format(dt.Rows(0)("Totel Amount"), "0.00"), 19) + "")
                    sw.WriteLine("" + ToRight(" ", 58) + "" + ToRight("============================", 30) + "")
                    sw.WriteLine("1st Copy  - CITIBANK Copy")
                    sw.WriteLine("2nd Copy  - Co-ord. Copy")
                    sw.WriteLine("3rd Copy  - Centre/Bank Copy")
                    'sw.WriteLine("")
                    sw.WriteLine("" + ToRight(" ", 35) + "" + ToRight("----------------------", 25) + "" + ToRight("--------------------------", 26) + "")
                    sw.WriteLine("" + ToRight(" ", 35) + "" + ToRight("Customer Sign", 25) + "" + ToLeft("Banks Authorised", 25) + "")
                    sw.WriteLine("" + ToRight(" ", 35) + "" + ToRight("(Date/Time)", 28) + "" + ToLeft("Signatory", 22) + "")
                    sw.WriteLine("" + ToRight("------------------------------------------------------------------------------------------------------", 85) + "")
                    'sw.WriteLine("")
                    'sw.WriteLine("")
                    sw.Close()
                End Using

                Call AppendPdf(doc, lsTxtFile, 10)
                Call CoveringLetterPdf(doc)
                Call GetBatchAllCheque(doc, gnBatchId)
            Next

            doc.Close()

            System.Diagnostics.Process.Start(lsPdfFile)
        Catch ex As Exception
            MsgBox("The process failed:" & ex.Message)
        End Try
    End Sub

    Private Sub CoveringLetterPdf(doc As Document)
        If gOdbcConn.State = ConnectionState.Closed Then
            gOdbcConn.Open()
        End If

        cmdCon = New MySqlCommand("pr_arms_get_citicontact", gOdbcConn)
        cmdCon.CommandType = CommandType.StoredProcedure

        dtCon = New DataTable
        daCon = New MySqlDataAdapter(cmdCon)
        daCon.Fill(dtCon)

        Try
            Dim lsTxtFile As String = gsAsciiPath & "\CoveringLetter.txt"

            If File.Exists(lsTxtFile) Then File.Delete(lsTxtFile)

            'FileOpen(1, pathCoveringletter, OpenMode.Output, OpenAccess.Write)
            Using sw As New StreamWriter(lsTxtFile)
                sw.WriteLine("")
                sw.WriteLine("")
                sw.WriteLine("")
                sw.WriteLine("")
                sw.WriteLine(ToRight(" ", 3) + ToRight("Handover Date", 14) + "" + ":" + " " + ToRight(todaysdate, 10) + "" + ToRight(" ", 28) + "" + ToRight("Deposit Date :", 14) + "" + ToRight(dt.Rows(0)("Cycle Date").ToString, 10) + "")
                sw.WriteLine("")
                sw.WriteLine("" + ToRight(" ", 3) + "" + ToRight("CHENNAI", 8) + "" + " - " + "" + ToRight("Summary of Total cheques inside the packet - ", 45) + "" + ToRight(dt.Rows(0)("Entity Code").ToString, 14) + "")
                sw.WriteLine("")
                sw.WriteLine("" + ToRight(" ", 3) + "" + ToRight("Client Code", 11) + "" + ToRight(" ", 16) + "" + ToRight("Total cheques", 13) + "" + ToRight(" ", 13) + "" + ToRight("Total Amount", 13) + "")
                sw.WriteLine("")
                sw.WriteLine("" + ToRight(" ", 3) + "" + ToRight(dt.Rows(0)("Entity Code").ToString, 17) + "" + ToRight(" ", 10) + "" + ToRight(Format(dt.Rows(0)("Totel Count"), "0.00"), 15) + "" + ToRight(" ", 8) + "" + ToRight(dt.Rows(0)("Totel Amount").ToString.PadLeft(14), 15) + "")
                sw.WriteLine("")
                'sw.WriteLine("")
                sw.WriteLine("" + ToRight(" ", 3) + "" + "Note :- If there is difference in total number of cheques as mentioned" + "")
                sw.WriteLine("" + ToRight(" ", 3) + "" + "above and actual cheques received then immediately highlight" + "")
                sw.WriteLine("" + ToRight(" ", 3) + "" + "the same to below mention personnel of Citibank." + "")
                sw.WriteLine("")
                sw.WriteLine("" + ToRight(" ", 3) + "" + ToRight("Name", 4) + "" + ToRight(" ", 24) + "" + ToRight("Contact no", 10) + "" + ToRight(" ", 16) + "" + ToRight("Email ID", 8) + "")
                sw.WriteLine("")
                For i As Integer = 0 To dtCon.Rows.Count() - 1 Step +1
                    sw.WriteLine("" + ToRight(" ", 3) + "" + ToRight(dtCon.Rows(i)("contact_name").ToString, 20) + "" + ToRight(" ", 8) + "" + ToRight(dtCon.Rows(i)("contact_no").ToString, 17) + "" + ToRight(" ", 8) + "" + ToRight(dtCon.Rows(i)("contact_email").ToString, 64) + "")
                    ' sw.WriteLine("")
                Next
                sw.Close()
            End Using

            Call AppendParagraphPdf(doc, lsTxtFile)
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try
    End Sub

    Private Sub CoveringLetterPdf()
        If gOdbcConn.State = ConnectionState.Closed Then
            gOdbcConn.Open()
        End If
        cmdCon = New MySqlCommand("pr_arms_get_citicontact", gOdbcConn)
        cmdCon.CommandType = CommandType.StoredProcedure
        dtCon = New DataTable
        daCon = New MySqlDataAdapter(cmdCon)
        daCon.Fill(dtCon)
        Try
            Dim pathCoveringletter As String = "D:\CoveringLetter.txt"
            If File.Exists(pathCoveringletter) Then
                File.Delete(pathCoveringletter)
            End If
            'FileOpen(1, pathCoveringletter, OpenMode.Output, OpenAccess.Write)
            Using sw As New StreamWriter(pathCoveringletter)
                'sw.WriteLine("")
                'sw.WriteLine("")
                'sw.WriteLine("")
                sw.WriteLine("" + ToRight("Handover Date", 14) + "" + ":" + " " + ToRight(todaysdate, 10) + "" + ToRight(" ", 28) + "" + ToRight("Deposit Date :", 14) + "" + ToRight(dt.Rows(0)("Cycle Date").ToString, 10) + "")
                sw.WriteLine("")
                sw.WriteLine("" + ToRight(" ", 3) + "" + ToRight("CHENNAI", 8) + "" + " - " + "" + ToRight("Summary of Total cheques inside the packet - ", 45) + "" + ToRight(dt.Rows(0)("Entity Code").ToString, 14) + "")
                sw.WriteLine("")
                sw.WriteLine("" + ToRight(" ", 3) + "" + ToRight("Client Code", 11) + "" + ToRight(" ", 16) + "" + ToRight("Total cheques", 13) + "" + ToRight(" ", 13) + "" + ToRight("Total Amount", 13) + "")
                sw.WriteLine("")
                sw.WriteLine("" + ToRight(" ", 3) + "" + ToRight(dt.Rows(0)("Entity Code").ToString, 17) + "" + ToRight(" ", 10) + "" + ToRight(dt.Rows(0)("Totel Count").ToString.PadLeft(13), 15) + "" + ToRight(" ", 8) + "" + ToRight(dt.Rows(0)("Totel Amount").ToString.PadLeft(14), 15) + "")
                sw.WriteLine("")
                'sw.WriteLine("")
                sw.WriteLine("" + ToRight(" ", 3) + "" + "Note :- If there is difference in total number of cheques as mentioned" + "")
                sw.WriteLine("" + ToRight(" ", 3) + "" + "above and actual cheques received then immediately highlight" + "")
                sw.WriteLine("" + ToRight(" ", 3) + "" + "the same to below mention personnel of Citibank." + "")
                sw.WriteLine("")
                sw.WriteLine("" + ToRight(" ", 3) + "" + ToRight("Name", 4) + "" + ToRight(" ", 24) + "" + ToRight("Contact no", 10) + "" + ToRight(" ", 16) + "" + ToRight("Email ID", 8) + "")
                sw.WriteLine("")
                For i As Integer = 0 To dtCon.Rows.Count() - 1 Step +1
                    sw.WriteLine("" + ToRight(" ", 3) + "" + ToRight(dtCon.Rows(i)("contact_name").ToString, 20) + "" + ToRight(" ", 8) + "" + ToRight(dtCon.Rows(i)("contact_no").ToString, 17) + "" + ToRight(" ", 8) + "" + ToRight(dtCon.Rows(i)("contact_email").ToString, 64) + "")
                    ' sw.WriteLine("")
                Next
                sw.Close()
            End Using
            Call AppendPdf(pathCoveringletter, gsResultpdf, 10)
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try

    End Sub

    Private Sub GetBatchAllCheque(doc As Document, BatchId As Long)
        If gOdbcConn.State = ConnectionState.Closed Then
            gOdbcConn.Open()
        End If

        cmdAll = New MySqlCommand("pr_arms_get_batchAllChq", gOdbcConn)
        cmdAll.CommandType = CommandType.StoredProcedure
        cmdAll.Parameters.AddWithValue("?pr_batch_gid", BatchId)
        cmdAll.Parameters("?pr_batch_gid").Direction = ParameterDirection.Input

        dtAll = New DataTable
        daAll = New MySqlDataAdapter(cmdAll)
        daAll.Fill(dtAll)

        If dtAll.Rows.Count > 0 Then
            Dim lsTxtFile As String = gsAsciiPath & "\BatchAllCheque.txt"

            If File.Exists(lsTxtFile) Then File.Delete(lsTxtFile)
            FileOpen(1, lsTxtFile, OpenMode.Output, OpenAccess.Write)

            PrintPageHeader(dtAll)
            mnPageNo = 0

            For row = 0 To dtAll.Rows.Count - 1
                PrintRow(dtAll, row)
                mnLineNo += 1

                If mnLineNo >= 60 And row <> dtAll.Rows.Count - 1 Then
                    PrintPageFooter()
                    FileClose(1)

                    Call AppendPdf(doc, lsTxtFile, 8)

                    If File.Exists(lsTxtFile) Then File.Delete(lsTxtFile)
                    FileOpen(1, lsTxtFile, OpenMode.Output, OpenAccess.Write)

                    PrintPageHeader(dtAll)
                End If
            Next row

            PrintPageFooter()
            FileClose(1)

            Call AppendPdf(doc, lsTxtFile, 8)
        Else
            MsgBox("No records found !")
        End If
    End Sub

    Private Sub GetBatchAllCheque()
        If gOdbcConn.State = ConnectionState.Closed Then
            gOdbcConn.Open()
        End If
        cmdAll = New MySqlCommand("pr_arms_get_batchAllChq", gOdbcConn)
        cmdAll.CommandType = CommandType.StoredProcedure
        cmdAll.Parameters.AddWithValue("?pr_batch_gid", gnBatchId)
        cmdAll.Parameters("?pr_batch_gid").Direction = ParameterDirection.Input
        dtAll = New DataTable
        daAll = New MySqlDataAdapter(cmdAll)
        daAll.Fill(dtAll)
        If dtAll.Rows.Count > 0 Then
            Dim pathAll As String = "D:\BatchAllCheque.txt"
            If File.Exists(pathAll) Then
                File.Delete(pathAll)
            End If

            FileOpen(1, pathAll, OpenMode.Output, OpenAccess.Write)
            PrintPageHeader(dt)
            mnPageNo = 0

            For row = 0 To dtAll.Rows.Count - 1
                PrintRow(dtAll, row)
                mnLineNo += 1
                If mnLineNo >= 84 And row <> dtAll.Rows.Count - 1 Then
                    PrintPageFooter()
                    ' FileClose(1)
                    ' Call AppendPdF(pathAll, gsResultpdf)

                    'Dim objReader As New System.IO.StreamReader(pathAll)
                    'objReader.ReadToEnd()
                    'objReader.Close() 
                    'pathAll.EndsWith(1)

                    'File.Delete(pathAll)
                    'FileOpen(1, pathAll, OpenMode.Output, OpenAccess.Write)
                    PrintPageHeader(dt)
                End If
            Next row

            PrintPageFooter()
            FileClose(1)

            Call AppendPdf(pathAll, gsResultpdf, 10)
        Else
            MsgBox("No records found !")
        End If
    End Sub

    Private Sub PrintPageHeader(dt As DataTable)
        Dim i As Integer
        Dim n As Integer
        Dim lsTxt As String = ""

        n = mnPrintMaxLen \ 4D

        lsTxt = ""
        lsTxt &= AlignTxt("Customer:" & dt.Rows(0)("Entity Code"), n, 1)
        lsTxt &= AlignTxt("Location:" & dt.Rows(0)("Pickup Loca"), n, 4)
        lsTxt &= AlignTxt("Cycle:" & Format(CDate(dt.Rows(0)("Cycle Date").ToString), "dd/MM/yy"), n, 4)
        lsTxt &= AlignTxt("Dep No:" & gnBatchId.ToString, n, 7)

        PrintLine(1, lsTxt)

        PrintLine(1, StrDup(mnPrintMaxLen, "-"))

        lsTxt = ""
        lsTxt &= AlignTxt("SlNo", 6, 1)
        lsTxt &= AlignTxt("Customer Name", 20, 1)
        lsTxt &= AlignTxt("Bank", 18, 1)
        lsTxt &= AlignTxt("Micr Code", 10, 1)
        lsTxt &= AlignTxt("Cheque Date", 11, 1)
        lsTxt &= AlignTxt("Pickup Loc", 12, 4)
        lsTxt &= AlignTxt("Chq No", 10, 1)
        lsTxt &= AlignTxt("Amount", 12, 7)

        PrintLine(1, AlignTxt(lsTxt, mnPrintMaxLen, 1))
        PrintLine(1, StrDup(mnPrintMaxLen, "-"))

        mnLineNo = 4
    End Sub

    Private Sub PrintRow(ByVal dtchq As DataTable, ByVal row As Integer)
        Dim lsSNo As String
        Dim lsTxt As String

        lsSNo = row + 1

        lsTxt = ""
        lsTxt &= AlignTxt(lsSNo, 6, 1)
        lsTxt &= AlignTxt(dtchq.Rows(row)("Customer Name"), 19, 1) & " "
        lsTxt &= AlignTxt(dtchq.Rows(row)("Bank"), 17, 1) & " "
        lsTxt &= AlignTxt(dtchq.Rows(row)("Micr Code"), 10, 1)
        lsTxt &= AlignTxt(dtchq.Rows(row)("chq_date"), 11, 1)
        'lsTxt &= AlignTxt(dtchq.Rows(row)("Pickup Loca"), 12, 4)
        lsTxt &= AlignTxt(txtPickupLoc.Text.Trim(), 12, 4)
        lsTxt &= AlignTxt(dtchq.Rows(row)("Chq No"), 10, 1)
        lsTxt &= AlignTxt(Format(dtchq.Rows(row)("Amount"), "0.00"), 12, 7)

        PrintLine(1, lsTxt)
    End Sub

    Private Sub PrintPageFooter()
        mnPageNo += 1
        PrintLine(1, StrDup(mnPrintMaxLen, "-"))
        PrintLine(1, AlignTxt("Page No : " & mnPageNo, mnPrintMaxLen, 4))
        'PrintLine(1, Chr(13) + Chr(10))
    End Sub

    Private Sub AppendPdf(doc As Document, TextFileName As String, FontSize As Integer)
        If File.Exists(TextFileName) Then
            Dim rdr As New StreamReader(TextFileName)

            Dim lobjBaseFont As BaseFont
            lobjBaseFont = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1250, BaseFont.NOT_EMBEDDED)
            Dim lobjFont As New iTextSharp.text.Font(lobjBaseFont, FontSize, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)

            doc.NewPage()
            doc.Add(New Paragraph(rdr.ReadToEnd(), lobjFont))

            rdr.Close()
        End If
    End Sub

    Private Sub AppendParagraphPdf(doc As Document, TextFileName As String)
        If File.Exists(TextFileName) Then
            Dim rdr As New StreamReader(TextFileName)

            Dim lobjBaseFont As BaseFont
            lobjBaseFont = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1250, BaseFont.NOT_EMBEDDED)
            Dim lobjFont As New iTextSharp.text.Font(lobjBaseFont, 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)

            doc.Add(New Paragraph(rdr.ReadToEnd(), lobjFont))

            rdr.Close()
        End If
    End Sub

    Private Sub AppendPdF(inputputFilePath As String, outputFilePath As String, FontSize As Integer)
        If File.Exists(outputFilePath) Then

            Dim rdr As New StreamReader(inputputFilePath)
            Dim reader As New PdfReader(System.IO.File.ReadAllBytes(outputFilePath))
            'Dim reader = New PdfReader(outputFilePath)
            If True Then
                Using fileStream = New FileStream(outputFilePath, FileMode.Create, FileAccess.Write)
                    Dim document = New Document(reader.GetPageSizeWithRotation(1))
                    Dim writer = PdfWriter.GetInstance(document, fileStream)
                    document.Open()
                    For i = 1 To reader.NumberOfPages
                        document.NewPage()
                        Dim importedPage = writer.GetImportedPage(reader, i)
                        Dim contentByte = writer.DirectContent
                        contentByte.AddTemplate(importedPage, 0, 0)
                    Next

                    Dim bfCourier As BaseFont
                    bfCourier = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1250, BaseFont.NOT_EMBEDDED)
                    Dim fCourier As New iTextSharp.text.Font(bfCourier, FontSize, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
                    document.NewPage()
                    document.Add(New Paragraph(rdr.ReadToEnd(), fCourier))
                    document.Close()
                    writer.Close()
                    'System.Diagnostics.Process.Start(outputFilePath)
                End Using
            End If

            reader.Close()
            rdr.Close()
        Else
            Dim rdr As New StreamReader(inputputFilePath)
            Dim doc As New Document()
            Dim bfCourier As BaseFont
            bfCourier = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1250, BaseFont.NOT_EMBEDDED)
            Dim fCourier As New iTextSharp.text.Font(bfCourier, 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
            PdfWriter.GetInstance(doc, New FileStream(outputFilePath, FileMode.Create))
            doc.Open()
            doc.Add(New Paragraph(rdr.ReadToEnd(), fCourier))
            doc.Close()
            rdr.Close()
            'System.Diagnostics.Process.Start(outputFilePath)
        End If
    End Sub

    Private Sub ClearAll()
        cboEntity.Text = ""
        dgvBatch.DataSource = Nothing
    End Sub

    Private Sub dgvBatch_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvBatch.CellContentClick

    End Sub

    Private Sub btnExport_Click(sender As System.Object, e As System.EventArgs) Handles btnExport.Click
        Dim Bselectedbatchid As Integer
        Dim list As New List(Of Integer)
        Dim query As String
        query = ""
        Try
            For Each row As DataGridViewRow In dgvBatch.Rows
                Dim isSelected As Boolean = Convert.ToBoolean(row.Cells("checkBoxColumn").Value)
                If isSelected Then
                    Bselectedbatchid = row.Cells("batch_gid").Value
                    List.Add(Bselectedbatchid)
                End If
            Next

            query &= " select"
            query &= " a.payee_name as 'Customer Name',"
            query &= " a.bank_name as 'Bank',"
            query &= " a.micr_code as 'Micr Code',"
            query &= " DATE_FORMAT(a.chq_date, '%d/%m/%Y') as chq_date,"
            query &= " DATE_FORMAT(a.cycle_date, '%d/%m/%Y') as 'Cycle Date',"
            query &= " a.loc_code as 'Pickup Loca',"
            query &= " a.chq_no as 'Chq No',"
            query &= " a.chq_amount as 'Amount',"
            query &= " a.loc_code as 'Loc Code',"
            query &= " b.entity_code as 'Entity Code'"
            query &= " from arms_trn_tcheque as a"
            query &= " inner join arms_mst_tentity as b on b.entity_gid = a.entity_gid"
            query &= " inner join arms_mst_tproduct as c on c.prod_flag = a.prod_flag"
            query &= " inner join arms_trn_tbatchcheque as d on d.chq_gid = a.chq_gid and d.delete_flag = 'N'"
            query &= " where a.batch_gid = " & Bselectedbatchid & " "
            query &= " and a.delete_flag = 'N'"
            query &= " order by d.batchchq_gid asc;"

            SqlToExcel(query, "Print Batch Ticket", "Ticket", False, "")
            Return

        Catch ex As Exception
            MsgBox("The process failed:" & ex.Message)
        End Try

    End Sub
End Class