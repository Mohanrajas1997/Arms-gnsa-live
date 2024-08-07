Public Class frmPouchInwardAuth

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclear.Click
        txtcoverno.Text = ""
        cboEntityName.Text = ""
        txtLotNo.Text = ""
        txtContractNo.Text = ""
        txtTotChq.Text = ""
        txtLotNo.Focus()
    End Sub

    Private Sub clear()
        txtcoverno.Text = ""
        txtContractNo.Text = ""
        txtTotChq.Text = ""
        txtcoverno.Focus()
    End Sub

    Private Sub frmPouchInwardAuth_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gsQry = ""
        gsQry = " select CONCAT(entity_code,'-', entity_name) as EntityCode ,entity_gid from arms_mst_tentity"
        gsQry &= " where delete_flag='N' "
        gsQry &= " order by entity_name "

        Call gpBindCombo(gsQry, "EntityCode", "entity_gid", cboEntityName, gOdbcConn)
    End Sub

    Private Sub btnsubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsubmit.Click
        Dim lssql As String
        Dim ds As New DataSet
        Dim lsEntityName As String = ""
        Dim lsCoverNo As String = ""
        Dim lsLotNo As Integer = 0
        Dim lnTotChqs As Integer = 0
        Dim lnPktSlNo As Long = 0
        Dim lsPktNo As String = ""
        Dim lnResult As Long = 0
        Dim lnFileGid As Integer = 0
        Dim lsContractNo As String = ""
        Dim lsMonthEndFlag As String = ""
        Dim lnPacketGid As Integer = 0

        If txtcoverno.Text.Trim = "" Then
            MsgBox("Please enter Cover No", MsgBoxStyle.Critical, gsProjectName)
            txtcoverno.Focus()
            Exit Sub
        Else
            lsCoverNo = Mid(QuoteFilter(txtcoverno.Text), 1, 128)
        End If

        If cboEntityName.SelectedIndex = -1 Or cboEntityName.Text.Trim = "" Then
            MsgBox("Please select the Entity Name !", MsgBoxStyle.Information, gsProjectName)
            cboEntityName.Focus()
            Exit Sub
        Else
            lsEntityName = cboEntityName.SelectedValue.ToString
        End If

        If txtContractNo.Text.Trim = "" Then
            MsgBox("Please enter Contract No", MsgBoxStyle.Critical, gsProjectName)
            txtContractNo.Focus()
            Exit Sub
        Else
            lsContractNo = Mid(QuoteFilter(txtContractNo.Text), 1, 128)
        End If

        lnTotChqs = Val(txtTotChq.Text)
        lsLotNo = Val(txtLotNo.Text)

        If lsLotNo = 0 Then
            MsgBox("Please input Lot No !", MsgBoxStyle.Information, gsProjectName)
            txtLotNo.Focus()
            Exit Sub
        End If
        If lnTotChqs = 0 Then
            MsgBox("Please input cheque count !", MsgBoxStyle.Information, gsProjectName)
            txtTotChq.Focus()
            Exit Sub
        End If

        ' Packet no generation
        gsQry = ""
        gsQry &= " select max(packet_slno) from arms_trn_tpacket "
        gsQry &= " where delete_flag = 'N'; "

        lnPktSlNo = Val(gfExecuteScalar(gsQry, gOdbcConn)) + 1
        lsPktNo = txtLotNo.Text & Format(lnPktSlNo, "0000")

        ' Duplicate validation
        gsQry = ""
        gsQry &= " select count(*) from arms_trn_tpacket "
        gsQry &= " where entity_gid = " & cboEntityName.SelectedValue.ToString() & " "
        gsQry &= " and packet_no = '" & lsPktNo & "'"
        gsQry &= " and lot_no = '" & QuoteFilter(txtLotNo.Text) & "' "
        gsQry &= " and contract_no = '" & QuoteFilter(txtContractNo.Text) & "'"
        gsQry &= " and delete_flag = 'N' "

        lnResult = Val(gfExecuteScalar(gsQry, gOdbcConn))

        If lnResult > 0 Then
            MsgBox("Duplicate packet no : " & lsPktNo & " !", MsgBoxStyle.Critical, gsProjectName)
            txtLotNo.Focus()
            Exit Sub
        End If

        lnResult = 0

        gsQry = ""
        gsQry &= " select count(*) from arms_trn_tpacket "
        gsQry &= " where cover_no = '" & QuoteFilter(txtcoverno.Text) & "'"
        gsQry &= " and entity_gid = '" & cboEntityName.SelectedValue.ToString & "'"
        gsQry &= " and delete_flag = 'N' "

        lnResult = Val(gfExecuteScalar(gsQry, gOdbcConn))

        If lnResult > 0 Then
            MsgBox("Duplicate cover no : " & QuoteFilter(txtcoverno.Text) & " !", MsgBoxStyle.Critical, gsProjectName)
            txtcoverno.Focus()
            Exit Sub
        End If

        If rdoMonthly.Checked = True Then
            lsMonthEndFlag = "M"
        ElseIf rdoQuarterly.Checked = True Then
            lsMonthEndFlag = "Q"
        ElseIf rdoHalfly.Checked = True Then
            lsMonthEndFlag = "H"
        End If

        gsQry = ""
        gsQry &= " select max(file_gid) from arms_trn_taplobinput "
        gsQry &= " where entity_gid = '" & lsEntityName & "' "
        gsQry &= " and lot_no = '" & QuoteFilter(txtLotNo.Text) & "' "
        gsQry &= " and contract_no = '" & QuoteFilter(txtContractNo.Text) & "'"
        gsQry &= " and chq_gid=0"
        gsQry &= " and delete_flag = 'N' "

        lnFileGid = Val(gfExecuteScalar(gsQry, gOdbcConn))

        If lnFileGid = 0 Then
            MsgBox("File Not Found!", MsgBoxStyle.Critical, gsProjectName)
            Exit Sub
        End If

        'insert in packet table
        gsQry = ""
        gsQry &= " insert into arms_trn_tpacket (rcvd_date,entity_gid,file_gid,lot_no,contract_no,cover_no,packet_slno,packet_no,"
        gsQry &= " tot_chqs,year_flag,packet_status,entry_date,entry_by) values("
        gsQry &= " '" & Format(dtpRcvdDate.Value, "yyyy-MM-dd") & "',"
        gsQry &= " '" & lsEntityName & "',"
        gsQry &= " '" & lnFileGid & "',"
        gsQry &= " " & lsLotNo & ","
        gsQry &= "'" & lsContractNo & "',"
        gsQry &= "'" & lsCoverNo & "',"
        gsQry &= " " & lnPktSlNo & ","
        gsQry &= " '" & lsPktNo & "',"
        gsQry &= " " & lnTotChqs & ","
        gsQry &= " '" & lsMonthEndFlag & "',"
        gsQry &= (GCINWARDENTRY Or GCAUTHENTRY) & ","
        gsQry &= " sysdate(),"
        gsQry &= " '" & gsLoginUserCode & "')"

        lnResult = gfInsertQry(gsQry, gOdbcConn)

        lssql = ""
        lssql &= " select packet_gid from arms_trn_tpacket "
        lssql &= " where entity_gid='" & lsEntityName & "'"
        lssql &= " and file_gid=" & lnFileGid & ""
        lssql &= " and lot_no='" & lsLotNo & "' "
        lssql &= " and contract_no='" & lsContractNo & "'"
        lssql &= " and cover_no='" & lsCoverNo & "'"
        lssql &= " and packet_slno='" & lnPktSlNo & "'"
        lssql &= " and packet_no='" & lsPktNo & "'"
        lssql &= " and delete_flag='N'"

        lnPacketGid = gfExecuteScalar(lssql, gOdbcConn)

        gsQry = ""
        gsQry &= " update arms_trn_taplobinput set "
        gsQry &= " packet_gid = " & lnPacketGid & " "
        gsQry &= " where entity_gid='" & lsEntityName & "'"
        gsQry &= " and lot_no = '" & QuoteFilter(txtLotNo.Text) & "' "
        gsQry &= " and contract_no = '" & QuoteFilter(txtContractNo.Text) & "'"
        gsQry &= " and file_gid=" & lnFileGid & ""
        gsQry &= " and chq_gid = 0 "
        gsQry &= " and delete_flag = 'N' "

        lnResult = gfInsertQry(gsQry, gOdbcConn)

        MsgBox("Record updated successfully !", MsgBoxStyle.Information, gsProjectName)
        'btnclear.PerformClick()
        clear()
        txtcoverno.Focus()

    End Sub

    Private Sub txtContractNo_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtContractNo.Validating
        Dim lsEntityGid As String = ""
        If cboEntityName.Text <> "" And cboEntityName.SelectedIndex <> -1 Then lsEntityGid = cboEntityName.SelectedValue.ToString
        If txtContractNo.Text <> "" And txtLotNo.Text <> "" Then
            gsQry = ""
            gsQry &= " select "
            gsQry &= " count(*) as 'ChqCount'"
            gsQry &= " from arms_trn_taplobinput "
            gsQry &= " where entity_gid = '" & lsEntityGid & "' "
            gsQry &= " and lot_no = '" & QuoteFilter(txtLotNo.Text) & "' "
            gsQry &= " and contract_no = '" & QuoteFilter(txtContractNo.Text) & "'"
            gsQry &= " and chq_gid = 0 "
            gsQry &= " and delete_flag = 'N' "

            txtTotChq.Text = gfExecuteScalar(gsQry, gOdbcConn)
            txtTotChq.Enabled = False
        End If
    End Sub

    Private Sub frmPouchInwardAuth_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = 13 Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

End Class