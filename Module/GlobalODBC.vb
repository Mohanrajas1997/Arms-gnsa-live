Imports System.IO
Imports System.IO.FileStream
Imports MySql.Data.MySqlClient
Imports System.Data.OleDb
Imports System.Data
Imports System.Security.Cryptography
Imports PdfSharp.Pdf
Imports PdfSharp.Pdf.IO
Imports PdfSharp.Drawing
Imports System.Configuration
Imports System.Data.Odbc



Module GlobalODBC

#Region "Global Declaration"

    Public filepath As String = "D:\"
    Public gsResultpdf As String = ""
    Public gsCoveringpdf As String = ""
    Public gsTicketpdf As String = ""
    Public gsAllchequepdf As String = ""

    'Public ServerDetails As String = "Server=169.38.77.180;DataBase=ambattur_vault;uid=root;pwd=Flexi@123;port=3306;Convert Zero Datetime=True"
    Public ServerDetails As String = "Server=192.168.0.22;DataBase=ambattur_vault;uid=production;pwd=gnsalive;port=3306;Convert Zero Datetime=True"
    Public gsProjectName As String = "ARMS"
    Public gnSearchId As Long

    Public gnMaxPwdSno As Integer = 6
    Public gnMaxPwdAttempt As Integer = 5
    Public gbLoginStatus As Boolean = False

    Public gnLoginUserId As Integer
    Public gsLoginUserName As String = ""
    Public gsLoginUserCode As String = "admin"
    Public gsLoginUserRights As String
    Public gnLoginUserGrpId As Integer
    Public gnBatchId As Integer
    Public gnCtsDiscVal As Integer = 0
    Public gsDatabase As String
    Public gOdbcConn As New MySqlConnection

    Public gOdbcDAdp As New MySqlDataAdapter
    Public gOdbcCmd As New MySqlCommand

    Public gFso As New FileIO.FileSystem
    Public gsAsciiPath As String = "c:\temp"
    Public gsReportPath As String = "c:\execute\"
    Public txt As Long
    Public txt_id As Integer = 0

    Public Const gnFileAplobInput As Integer = 1
    Public Const gnFileAplobOutput As Integer = 2
    Public Const gnFileInwardInput As Integer = 3
    Public Const gnFileRplob As Integer = 4
    Public Const gnFilePullout As Integer = 5
    Public Const gnFileChequeNoQry As Integer = 6
    Public Const gnFilePacketUpload As Integer = 7
    Public Const gnFileChqUpload As Integer = 12
    Public Const gnFileundochqUpload As Integer = 13
    Public Const gnFileBankMstUpload As Integer = 14
    Public Const gnFilePresentationdelete As Integer = 15
    Public Const gnFileAlmiraUpload As Integer = 16
    Public Const gnFileHistoryUpload As Integer = 17
    Public Const gnFileChqUpdateUpload As Integer = 18



    Public Const gnStatusAplobInput As Integer = 1
    Public Const gnStatusRplob As Integer = 2
    Public Const gnStatusPullout As Integer = 4
    Public Const gnStatusBatch As Integer = 8
    Public Const gnStatusDisc As Integer = 16

    Public gsTxt As String
    Public gOdbcConn1 As New OdbcConnection
    Public Const gnSubProdAllCTS As Integer = 1
    Public Const gnSubProdCTS As Integer = 2
    Public Const gnSubProdCCLR As Integer = 4
    Public Const gnSubProdCSPD As Integer = 8
    Public Const gnSubProdCCHK As Integer = 16
    Public Const gnSubProdCANW As Integer = 32
    Public gnChqDisc As Integer = 16
    Public gnChqInward As Integer = 1
    Public Const gnProdCTS As Integer = 1
    Public Const gnProdCCLR As Integer = 2
    Public Const gnProdOthers As Integer = 4
    Public gnChqHdfcDump As Integer = 1

    Public gsQry As String = ""
    Public gsPacketStatus As String = ""
    Public gsChqStatus As String = ""
    Public gsChqDiscStatus As String = ""

    Public gnDiscVal As Long = 0


    'Packet
    Public Const GCINWARDENTRY As Integer = 1
    Public Const GCAUTHENTRY As Integer = 2
    Public Const GCREJECTENTRY As Integer = 4
    Public Const GCPACKETCHEQUEENTRY As Integer = 8
    Public Const GCPACKETCHEQUEREENTRY As Integer = 16
    Public Const GCPACKETVAULTED As Integer = 32
    Public Const GCIPACKETPULLOUT As Integer = 64
    Public Const GCGNSAREFCHANGED As Integer = 128
    Public Const GCAGREEMENTNOCHANGED As Integer = 256
    Public Const GCPACKETRETRIEVAL As Integer = 512
    Public Const GCPACKETSCANCOMPLETED As Integer = 1024
    Public Const GCPACKETRESCAN As Integer = 2048
    Public Const GCPACKETSCANAUDITED As Integer = 4096

    Public GCScanDiscValue As Long = 0

    'Scan
    Public Const GCSCANCOMPLETED As Integer = 1
    Public Const GCSCANVALID As Integer = 2
    Public Const GCSCANINVALID As Integer = 4
    Public Const GCSCANCANCELED As Integer = 8
    Public Const GCSCANRESCAN As Integer = 16
    Public Const GCSCANAUDITED As Integer = 32
    Public Const GCSCANFINONEAUDITED As Integer = 64
    Public Const GCSCANFINONEVALID As Integer = 128
    Public Const GCSCANFINONEINVALID As Integer = 256


    Private KEY_192() As Byte = {42, 16, 93, 156, 78, 4, 218, 32, _
            15, 167, 44, 80, 26, 250, 155, 112, 2, 94, 11, 204, 119, 35, 184, 197}

    Private IV_192() As Byte = {55, 103, 246, 79, 36, 99, 167, 3, _
            42, 5, 62, 83, 184, 7, 209, 13, 145, 23, 200, 58, 173, 10, 121, 222}
#End Region
    'For calling the Main form
    Public Sub Main()
        Dim DbUId As String = ""
        Dim DbPort As String = ""
        Dim DbPwd As String = ""
        Dim DbIP As String = ""
        Dim Db As String = ""

        Dim n As Integer = 0
        Dim lsSql As String

        'Dim sr As StreamReader
        'Dim lsLine As String

        'Try
        '    sr = FileIO.FileSystem.OpenTextFileReader(Application.StartupPath & "\appconfig.ini")

        '    While Not sr.EndOfStream
        '        lsLine = sr.ReadLine()
        '        lsLine = DecryptTripleDES(lsLine)
        '        n += 1

        '        Select Case n
        '            Case 1
        '                DbIP = lsLine
        '            Case 2
        '                DbPort = lsLine
        '            Case 3
        '                DbUId = lsLine
        '            Case 4
        '                DbPwd = lsLine
        '            Case 5
        '                Db = lsLine
        '            Case 6
        '                gsAsciiPath = lsLine
        '        End Select
        '    End While

        '    sr.Close()

        '    If FileIO.FileSystem.DirectoryExists(gsAsciiPath) = False Then
        '        MsgBox("Invalid Ascii Path", MsgBoxStyle.Information, gsProjectName)
        '        frmServerConfiguration.ShowDialog()
        '        Exit Sub
        '    End If

        'ServerDetails = "Driver={MySQL ODBC 5.1 Driver};Server=192.168.0.155;DataBase=ambattur_vault;uid=root;pwd=gnsa;port=3306"
        'ServerDetails = "Server=192.168.0.155;DataBase=ambattur_vault;uid=root;pwd=gnsa;port=3306"
        'ServerDetails = "Server=169.38.77.180;DataBase=ambattur_vault;uid=root;pwd=Flexi@123;port=3306"

        ServerDetails = ConfigurationManager.ConnectionStrings("ConString").ConnectionString

        Call ConOpenOdbc(ServerDetails)
        gbLoginStatus = False

        'get packet status desc
        lsSql = ""
        lsSql &= " select group_concat(status_desc) from arms_mst_tstatus "
        lsSql &= " where status_type = 'Packet' and delete_flag = 'N' "
        lsSql &= " order by status_flag "

        gsPacketStatus = gfExecuteScalar(lsSql, gOdbcConn)
        gsPacketStatus = "'" & gsPacketStatus.Replace(",", "','") & "'"

        ' get chq status desc
        lsSql = ""
        lsSql &= " select group_concat(status_desc) from arms_mst_tstatus "
        lsSql &= " where delete_flag = 'N' and status_type = 'Cheque'"
        lsSql &= " order by status_flag "

        gsChqStatus = gfExecuteScalar(lsSql, gOdbcConn)
        gsChqStatus = "'" & gsChqStatus.Replace(",", "','") & "'"

        ' get chq status desc
        lsSql = ""
        lsSql &= " select group_concat(disc_desc) from arms_mst_tdisc "
        lsSql &= " where disc_type = 'chq' and delete_flag = 'N' "
        lsSql &= " order by disc_flag "

        gsChqDiscStatus = gfExecuteScalar(lsSql, gOdbcConn)
        gsChqDiscStatus = "'" & gsChqDiscStatus.Replace(",", "','") & "'"

        'Call lp_CreateAsciiPath()

        frmLogin.ShowDialog()

        If gbLoginStatus = True Then
            gbLoginStatus = False
        End If
        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.Critical, gsProjectName)
        '    frmServerConfiguration.ShowDialog()
        'End Try
    End Sub
    'Validating for Integer only
    Public Function gfIntEntryOnly(ByVal e As System.Windows.Forms.KeyPressEventArgs) As Boolean
        Select Case Asc(e.KeyChar)
            Case 48 To 57, 8, 46
                gfIntEntryOnly = False
            Case Else
                gfIntEntryOnly = True
        End Select
    End Function
    'AutoFillCombo :Created Date :24-02-2009 :Created By :Ilaya
    Public Sub gpAutoFillCombo(ByVal cboBox As ComboBox)

        Dim lnLenght As Long

        With cboBox

            lnLenght = .Text.Length

            .SelectedIndex = .FindString(.Text)

            .SelectionStart = lnLenght

            .SelectionLength = Math.Abs(.Text.Length - lnLenght)

        End With

    End Sub

    'AutoFillCombo :Created Date :24-02-2009 Created By :Ilaya
    Public Sub gpAutoFindCombo(ByVal cboBox As ComboBox)
        cboBox.SelectedIndex = cboBox.FindString(cboBox.Text)
    End Sub

    Public Sub ConOpenOdbc(ByVal ServerDetails As String)

        If gOdbcConn.State = ConnectionState.Open Then
            gOdbcConn.Close()
        End If

        If gOdbcConn.State = ConnectionState.Closed Then
            gOdbcConn.ConnectionString = ServerDetails
            gOdbcConn.Open()
            gOdbcCmd.Connection = gOdbcConn
        End If
        'empid = Security.clsEmpId
    End Sub

    Public Sub ConCloseOdbc(ByVal ServerDetails As String)
        If gOdbcConn.State = ConnectionState.Open Then
            gOdbcConn.Close()
        End If
    End Sub

    Public Function gfInsertQry(ByVal strsql As String, ByVal odbcConn As MySqlConnection) As Integer
        Dim recAffected As Long

        Call ConOpenOdbc(ServerDetails)
        gOdbcCmd = New MySqlCommand(strsql, odbcConn)
        gOdbcCmd.CommandType = CommandType.Text
        'Try
        recAffected = gOdbcCmd.ExecuteNonQuery()

        Call ConCloseOdbc(ServerDetails)
        Return recAffected
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        '    Exit Function
        'End Try
    End Function

    Public Function gfInsertStoredprocedure(ByVal strsql As String, ByVal odbcConn As MySqlConnection) As Integer
        Dim recAffected As Long
        Call ConOpenOdbc(ServerDetails)
        gOdbcCmd = New MySqlCommand(strsql, odbcConn)
        gOdbcCmd.CommandType = CommandType.StoredProcedure
        'Try
        Call ConCloseOdbc(ServerDetails)
        recAffected = gOdbcCmd.ExecuteNonQuery()
        Return recAffected
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        '    Exit Function
        'End Try
    End Function

    Public Function DecryptTripleDES(ByVal value As String) As String
        Try
            If value <> "" Then
                value = value.Replace(" ", "+")
                Dim cryptoProvider As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider()

                'convert from string to byte array
                Dim buffer As Byte() = Convert.FromBase64String(value)
                Dim ms As MemoryStream = New MemoryStream(buffer)
                Dim cs As CryptoStream = New CryptoStream(ms, cryptoProvider.CreateDecryptor(KEY_192, IV_192), CryptoStreamMode.Read)
                Dim sr As StreamReader = New StreamReader(cs)

                Return sr.ReadToEnd()
            Else
                Return ""
            End If
        Catch ex As Exception
            Return ""
            'Handle Exception - Redirect to Error Page
        End Try
    End Function

    Public Function EncryptTripleDES(ByVal value As String) As String
        Try
            If value <> "" Then
                Dim cryptoProvider As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider()
                Dim ms As MemoryStream = New MemoryStream()
                Dim cs As CryptoStream = New CryptoStream(ms, cryptoProvider.CreateEncryptor(KEY_192, IV_192), CryptoStreamMode.Write)
                Dim sw As StreamWriter = New StreamWriter(cs)

                sw.Write(value)
                sw.Flush()
                cs.FlushFinalBlock()
                ms.Flush()

                'convert back to a string
                Return Convert.ToBase64String(ms.GetBuffer(), 0, ms.Length)
            Else
                Return ""
            End If
        Catch ex As Exception
            'Handle Exception - Redirect to Error Page
            Return ""
        End Try
    End Function

    'its IP address in standard and byte format.
    Public Function IPAddresses(ByVal server As String) As String
        Try
            ' Get server related information.
            Dim heserver As Net.IPHostEntry = Net.Dns.GetHostEntry(server)
            ' Loop on the AddressList
            Dim curAdd As Net.IPAddress
            Dim lsIpAddr As String = ""

            For Each curAdd In heserver.AddressList
                ' Display the server IP address in the standard format. In 
                ' IPv4 the format will be dotted-quad notation, in IPv6 it will be
                ' in in colon-hexadecimal notation.
                lsIpAddr = curAdd.ToString()
            Next curAdd

            Return lsIpAddr
        Catch e As Exception
            MsgBox(e.Message, MsgBoxStyle.Critical, gsProjectName)
            Return ""
        End Try
    End Function 'IPAddresses

    Public Sub frmCtrClear(ByVal frmName As Object)
        Dim ctrl As Control
        For Each ctrl In frmName.Controls
            If ctrl.Tag <> "*" Then
                If TypeOf ctrl Is TextBox Then ctrl.Text = ""
                If TypeOf ctrl Is ComboBox Then
                    ctrl.Text = ""
                End If

                If TypeOf ctrl Is Panel Then frmCtrClear(ctrl)
                If TypeOf ctrl Is GroupBox Then frmCtrClear(ctrl)
            End If
        Next
    End Sub

    ''To Clear control in a form
    Public Sub gpTrimAll(ByVal ctrlBag As Object)
        Dim ctrl As Control

        For Each ctrl In ctrlBag.Controls
            If TypeOf ctrl Is TextBox Then
                ctrl.Text = Trim(ctrl.Text)
            ElseIf ctrl.Controls.Count > 0 Then
                gpTrimAll(ctrl)
            End If
        Next
    End Sub

    'To get Dataset
    Public Sub gpDataSet(ByVal SQL As String, ByVal tblName As String, ByVal odbcConn As MySqlConnection, ByVal ds As DataSet)
        Call ConOpenOdbc(ServerDetails)
        Dim objDataAdapter As New MySqlDataAdapter(SQL, odbcConn)
        Try
            Call ConCloseOdbc(ServerDetails)
            objDataAdapter.Fill(ds, tblName)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, gsProjectName)
        End Try
    End Sub

    'To Execute Query and return as datareader
    Public Function gfExecuteQry(ByVal strsql As String, ByVal odbcConn As MySqlConnection)
        Dim objCommand As New MySqlCommand
        Dim objDataReader As MySqlDataReader
        Call ConOpenOdbc(ServerDetails)
        objCommand = New MySqlCommand(strsql, odbcConn)
        Try
            objDataReader = objCommand.ExecuteReader()

            ' odbcConn.Close()
            'objCommand.Dispose()
            Return objDataReader
        Catch ex As Exception
            MsgBox(ex.Message)
            Return (0)
        End Try
        'Call ConCloseOdbc(ServerDetails)
    End Function

    'To get Dataset
    Public Function gfDataSet(ByVal SQL As String, ByVal tblName As String, ByVal odbcConn As MySqlConnection) As DataSet
        Try
            Call ConOpenOdbc(ServerDetails)
            Dim objDataAdapter As New MySqlDataAdapter(SQL, odbcConn)
            Dim objDataSet As New DataSet
            objDataAdapter.Fill(objDataSet, tblName)
            Call ConCloseOdbc(ServerDetails)
            Return objDataSet
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    'Binding combo
    Public Sub gpBindCombo(ByVal SQL As String, ByVal Dispfld As String, _
                               ByVal Valfld As String, ByRef ComboName As ComboBox, _
                                ByVal odbcConn As MySqlConnection)

        Dim objDataAdapter As New MySqlDataAdapter
        Dim objCommand As New MySqlCommand
        Dim objDataTable As New Data.DataTable
        Try
            Call ConOpenOdbc(ServerDetails)
            objCommand.Connection = odbcConn
            objCommand.CommandType = CommandType.Text
            objCommand.CommandText = SQL
            objDataAdapter.SelectCommand = objCommand
            objDataAdapter.Fill(objDataTable)
            ComboName.DataSource = objDataTable
            ComboName.DisplayMember = Dispfld
            ComboName.ValueMember = Valfld
            ComboName.SelectedIndex = -1
            Call ConCloseOdbc(ServerDetails)
        Catch ex As Exception
            MsgBox(ex.Message)
            objDataTable.Dispose()
            objCommand.Dispose()
            objDataAdapter.Dispose()
        End Try
    End Sub

   Public Function QuoteFilter(ByVal txt As String) As String
        QuoteFilter = Trim(Replace(Replace(Replace(txt, "'", " "), """", """"""), "\", "\\"))
    End Function

    'Excel To DS :Created Date :23-02-2009 :Created By :Ilaya
    Public Function gpExcelDataset(ByVal Qry As String, ByVal Excelpath As String) As DataTable
        Dim fOleDbConString As String = ""
        Dim lobjDataTable As New DataTable
        Dim lobjDataSet As New DataSet
        Dim lobjDataAdapter As New OleDbDataAdapter
        Dim n As Integer

        n = Excelpath.Split(".").Length

        If Excelpath.Split(".")(n - 1).ToLower = "xlsx" Then
            'Dim fOleDbConString As String = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" & Excelpath & ";" + "Extended Properties=Excel 12.0;"
            fOleDbConString = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" & Excelpath & ";" + "Extended Properties='Excel 12.0 Xml;HDR=YES';"
            'fOleDbConString = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" & Excelpath & ";" + "Extended Properties='Excel 12.0;"
        Else
            fOleDbConString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" & Excelpath & ";" + "Extended Properties=Excel 8.0;"
        End If

        lobjDataAdapter = New OleDbDataAdapter(Qry, fOleDbConString)
        lobjDataSet = New DataSet("TBL")
        lobjDataAdapter.Fill(lobjDataSet, "TBL")
        lobjDataTable = lobjDataSet.Tables(0)

        Return lobjDataTable
    End Function

    'To Execute Query and return value as string
    Public Function gfExecuteScalar(ByVal strsql As String, ByVal odbcConn As MySqlConnection) As String
        Dim StrVal As String
        Dim objCommand As MySqlCommand
        Call ConOpenOdbc(ServerDetails)
        objCommand = New MySqlCommand(strsql, odbcConn)

        Try
            If IsDBNull(objCommand.ExecuteScalar()) Or IsNothing(objCommand.ExecuteScalar()) Then
                StrVal = ""
            Else
                StrVal = objCommand.ExecuteScalar()
            End If
            Call ConCloseOdbc(ServerDetails)
            objCommand.Dispose()
            Return StrVal

        Catch ex As Exception
            MsgBox(ex.Message)
            Return 0
        End Try
    End Function

    'To Bind values to Datagrid
    Public Sub gpPopGridView(ByVal GridName As DataGridView, ByVal Qry As String, ByVal odbcConn As MySqlConnection)
        Dim lda As MySqlDataAdapter
        Dim lds As New DataSet
        Dim ldt As DataTable
        Try
            'If odbcConn.State = ConnectionState.Closed Then odbcConn.Open()
            Call ConOpenOdbc(ServerDetails)
            lda = New MySqlDataAdapter(Qry, odbcConn)

            lda.Fill(lds, "tbl")
            ldt = lds.Tables("tbl")
            GridName.DataSource = ldt
            Call ConCloseOdbc(ServerDetails)
            'odbcConn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    'To Bind values to Datagrid
    Public Sub gpPopGridView(ByVal GridName As DataGridView, ByVal Qry As String, ByVal odbcConn As Odbc.OdbcConnection)
        Dim lda As Odbc.OdbcDataAdapter
        Dim lds As New DataSet
        Dim ldt As DataTable

        Try
            If odbcConn.State = ConnectionState.Closed Then odbcConn.Open()

            lda = New Odbc.OdbcDataAdapter(Qry, odbcConn)
            lda.Fill(lds, "tbl")
            ldt = lds.Tables("tbl")
            GridName.DataSource = ldt

            odbcConn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Function AmtInWords(ByRef amt As Double, ByRef Rupees As String, ByRef Paise As String, ByRef Only As String) As String
        Dim m As Long
        Dim n As Short
        Dim b As String = ""
        Dim a As String = ""
        Dim C As String = ""

        m = Int(amt)
        n = Math.Round(((amt - m) * 100), 0)

        If m <> 0 Then
            a = English(m)
            'If n <> 0 Then
            b = " and "
        End If
        'If n <> 0 Then
        If n > 0 Then
            C = Paise & " " & English(n)
        Else
            b = ""
        End If

        AmtInWords = Rupees & " " & a & b & C & " " & Only
    End Function
    Function English(ByVal n As Long) As String
        Const Thousand As Long = 1000
        Const Lakh As Long = Thousand * 100
        Const Crore As Long = Thousand * 10000
        'Const Trillion = Thousand * Crore

        Dim Buf As String : Buf = ""

        If (n = 0) Then English = "zero" : Exit Function

        If (n < 0) Then Buf = "negative " : n = -n

        If (n >= Crore) Then
            Buf = Buf & EnglishDigitGroup(n \ Crore) & " crore"
            n = n Mod Crore
            If (n) Then Buf = Buf & " "
        End If

        If (n >= Lakh) Then
            Buf = Buf & EnglishDigitGroup(n \ Lakh) & " lakh"
            n = n Mod Lakh
            If (n) Then Buf = Buf & " "
        End If

        If (n >= Thousand) Then
            Buf = Buf & EnglishDigitGroup(n \ Thousand) & " thousand"
            n = n Mod Thousand
            If (n) Then Buf = Buf & " "
        End If

        If (n > 0) Then
            Buf = Buf & EnglishDigitGroup(n)
        End If

        English = Buf
    End Function
    ' Support function to be used only by English()
    Function EnglishDigitGroup(ByVal n As Short) As String
        Const Hundred As String = " hundred"
        Const One As String = "one"
        Const Two As String = "two"
        Const Three As String = "three"
        Const Four As String = "four"
        Const Five As String = "five"
        Const Six As String = "six"
        Const Seven As String = "seven"
        Const Eight As String = "eight"
        Const Nine As String = "nine"
        Dim Buf As String : Buf = ""
        Dim Flag As Short : Flag = False

        'Do hundreds
        Select Case (n \ 100)
            Case 0 : Buf = "" : Flag = False
            Case 1 : Buf = One & Hundred : Flag = True
            Case 2 : Buf = Two & Hundred : Flag = True
            Case 3 : Buf = Three & Hundred : Flag = True
            Case 4 : Buf = Four & Hundred : Flag = True
            Case 5 : Buf = Five & Hundred : Flag = True
            Case 6 : Buf = Six & Hundred : Flag = True
            Case 7 : Buf = Seven & Hundred : Flag = True
            Case 8 : Buf = Eight & Hundred : Flag = True
            Case 9 : Buf = Nine & Hundred : Flag = True
        End Select

        If (Flag) Then n = n Mod 100
        If (n) Then
            If (Flag) Then Buf = Buf & " "
        Else
            EnglishDigitGroup = Buf
            Exit Function
        End If

        'Do tens (except teens)
        Select Case (n \ 10)
            Case 0, 1 : Flag = False
            Case 2 : Buf = Buf & "twenty" : Flag = True
            Case 3 : Buf = Buf & "thirty" : Flag = True
            Case 4 : Buf = Buf & "forty" : Flag = True
            Case 5 : Buf = Buf & "fifty" : Flag = True
            Case 6 : Buf = Buf & "sixty" : Flag = True
            Case 7 : Buf = Buf & "seventy" : Flag = True
            Case 8 : Buf = Buf & "eighty" : Flag = True
            Case 9 : Buf = Buf & "ninety" : Flag = True
        End Select

        If (Flag) Then n = n Mod 10
        If (n) Then
            If (Flag) Then Buf = Buf & "-"
        Else
            EnglishDigitGroup = Buf
            Exit Function
        End If

        'Do ones and teens
        Select Case (n)
            Case 0 ' do nothing
            Case 1 : Buf = Buf & One
            Case 2 : Buf = Buf & Two
            Case 3 : Buf = Buf & Three
            Case 4 : Buf = Buf & Four
            Case 5 : Buf = Buf & Five
            Case 6 : Buf = Buf & Six
            Case 7 : Buf = Buf & Seven
            Case 8 : Buf = Buf & Eight
            Case 9 : Buf = Buf & Nine
            Case 10 : Buf = Buf & "ten"
            Case 11 : Buf = Buf & "eleven"
            Case 12 : Buf = Buf & "twelve"
            Case 13 : Buf = Buf & "thirteen"
            Case 14 : Buf = Buf & "fourteen"
            Case 15 : Buf = Buf & "fifteen"
            Case 16 : Buf = Buf & "sixteen"
            Case 17 : Buf = Buf & "seventeen"
            Case 18 : Buf = Buf & "eighteen"
            Case 19 : Buf = Buf & "nineteen"
        End Select

        EnglishDigitGroup = Buf
    End Function

    'textwith
    Function ToRight(text As String, length As Integer)
        If text.Length > length Then
            Return text.Substring(0, length)
        Else
            Return text.PadRight(length)
        End If
    End Function

    Function ToLeft(text As String, length As Integer)
        If text.Length > length Then
            Return text.Substring(0, length)
        Else
            Return text.PadLeft(length)
        End If
    End Function

    'To Get the DataTable
    Public Function GetDataTable(ByVal SqlQry As String) As DataTable
        Dim lobjDataTable As New DataTable
        Dim lobjDataView As New DataView
        Dim lobjDataSet As New DataSet
        Dim lobjDataAdapter As New Odbc.OdbcDataAdapter
        GetDataTable = Nothing
        Try
            gOdbcDAdp = New MySqlDataAdapter(SqlQry, gOdbcConn)
            lobjDataSet = New DataSet("TBL")
            gOdbcDAdp.Fill(lobjDataSet, "TBL")
            lobjDataTable = lobjDataSet.Tables(0)
            lobjDataView = New DataView(lobjDataTable)
            Return lobjDataTable
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Public Function AlignTxt(ByVal txt As String, ByVal Length As Integer, ByVal Alignment As Integer) As String
        Select Case Alignment
            Case 1
                Return LSet(txt, Length)
            Case 4
                Return CSet(txt, Length)
            Case 7
                Return RSet(txt, Length)
        End Select
    End Function

    Private Function CSet(ByVal txt As String, ByVal PaperChrWidth As Integer) As String
        Dim s As String                 ' Temporary String Variable
        Dim l As Integer                ' Length of the String
        If Len(txt) > PaperChrWidth Then
            CSet = Left(txt, PaperChrWidth)
        Else
            l = (PaperChrWidth - Len(txt)) / 2
            s = RSet(txt, l + Len(txt))
            CSet = Space(PaperChrWidth - Len(s))
            CSet = s + CSet
        End If
    End Function

    'To Execute Query and return value as boolean
    Public Function gfExecuteQryBln(ByVal strsql As String, ByVal odbcConn As MySqlConnection) As Boolean
        Dim objDataReader As MySqlDataReader
        Call ConOpenOdbc(ServerDetails)
        gOdbcCmd = New MySqlCommand(strsql, odbcConn)

        Try
            objDataReader = gOdbcCmd.ExecuteReader()
            Call ConCloseOdbc(ServerDetails)
            If objDataReader.HasRows Then
                objDataReader.Close()
                Return True
            Else
                objDataReader.Close()
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function
    Public Function gfAmountEntryOnly(ByVal e As System.Windows.Forms.KeyPressEventArgs, ByVal txt As TextBox) As Boolean
        Select Case Asc(e.KeyChar)
            Case 48 To 57, 8, 46
                If Asc(e.KeyChar) = 46 Then
                    If InStr(txt.Text, ".") = 0 Then
                        gfAmountEntryOnly = False
                    Else
                        gfAmountEntryOnly = True
                    End If
                Else
                    gfAmountEntryOnly = False
                End If
            Case Else
                gfAmountEntryOnly = True
        End Select
    End Function
End Module