Public Class frmScanAuditQueue
    Private Sub frminwardsummary_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        'If dgvsummary.RowCount > 0 Then Call LoadData()
    End Sub

    Private Sub frminwardsummary_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then SendKeys.Send("{TAB}")
    End Sub
    Private Sub frminwardsummary_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.KeyPreview = True
        MyBase.WindowState = FormWindowState.Maximized
        txtgnsarefno.Focus()
        txtgnsarefno.Text = ""
        btnrefresh.PerformClick()
    End Sub

    Private Sub frminwardsummary_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        With dgvsummary
            pnlMain.Width = Me.Width - 30
            pnlMain.Height = Me.Height - 140
            .Height = pnlMain.Height - 10
            .Width = pnlMain.Width - 10
        End With
    End Sub

    Private Sub btnrefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrefresh.Click
        Dim lssql As String
        Dim lsPacketRef As String
        Dim ds As New DataSet
        Dim lsLockFlag As String
        Dim lsLockBy As String

        Call LoadData()
        If dgvsummary.Rows.Count <= 0 Then
            MsgBox("No records found", MsgBoxStyle.OkOnly, gsProjectName)
            Exit Sub
        End If
        If txtgnsarefno.Text <> "" Then
            lssql = ""
            lssql &= " select cover_no "
            lssql &= " from arms_trn_tpacket "
            lssql &= " where lot_no='" & dgvsummary.Rows(0).Cells("Lot No").Value.ToString & "'"
            lssql &= " and contract_no = '" & dgvsummary.Rows(0).Cells("Contract No").Value.ToString & "'"
            lssql &= " and cover_no <> '" & dgvsummary.Rows(0).Cells("Cover No").Value.ToString & "'"
            lssql &= " and delete_flag='N'"

            lsPacketRef = gfExecuteScalar(lssql, gOdbcConn)

            If lsPacketRef <> "" Then
                If MsgBox("This Agreement Already have a packet:" & lsPacketRef & "..,Do you want to Continue?", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2, gsProjectName) = MsgBoxResult.No Then
                    Exit Sub
                End If
            End If

            lssql = ""
            lssql &= " select gnsa_lock_flag,gnsa_lock_by "
            lssql &= " from arms_trn_tpacket "
            lssql &= " where lot_no='" & dgvsummary.Rows(0).Cells("Lot No").Value.ToString & "'"
            lssql &= " and contract_no = '" & dgvsummary.Rows(0).Cells("Contract No").Value.ToString & "'"
            lssql &= " and cover_no= '" & dgvsummary.Rows(0).Cells("Cover No").Value.ToString & "'"
            lssql &= " and delete_flag='N'"

            gpDataSet(lssql, "Packet", gOdbcConn, ds)

            If ds.Tables("Packet").Rows.Count = 1 Then
                lsLockFlag = ds.Tables("Packet").Rows(0).Item("gnsa_lock_flag").ToString
                lsLockBy = ds.Tables("Packet").Rows(0).Item("gnsa_lock_by").ToString
            End If

            If lsLockFlag = "Y" And lsLockBy <> gsLoginUserCode Then
                MsgBox("This Packet Already Opened by:" & lsLockBy & "", MsgBoxStyle.Information, gsProjectName)
                Exit Sub
            End If

            Dim frmImageEntry As New frmImageBaseEntry(dgvsummary.Rows(0).Cells("packet gid").Value.ToString)
            frmImageEntry.ShowDialog()

            'txtgnsarefno.Text = ""
            dgvsummary.DataSource = Nothing
            lbltotrec.Text = ""
            txtgnsarefno.Focus()
        End If
    End Sub

    Private Sub LoadData()
        Dim ds As New DataSet
        Dim lsSql As String
        Dim lsCond As String = ""

        If rdoShowall.Checked = True Then
            lsSql = ""
            lsSql &= " select packet_gid as 'Packet gid', cover_no as 'Cover No',contract_no as 'Contract No',lot_no as 'Lot No' "
            lsSql &= " from arms_trn_tpacket "
            lsSql &= " where packet_status & " & GCPACKETSCANCOMPLETED & " = " & GCPACKETSCANCOMPLETED & " "
            lsSql &= " and packet_status & " & GCPACKETSCANAUDITED & " = 0 "
            lsSql &= " and delete_flag='N'"

            If dtpfrom.Checked Then
                lsSql &= " and  date_format(rcvd_date,'%Y-%m-%d') >='" & Format(dtpfrom.Value, "yyyy-MM-dd") & "'"
            End If

            If dtpto.Checked Then
                lsSql &= " and  date_format(rcvd_date,'%Y-%m-%d') <='" & Format(dtpto.Value, "yyyy-MM-dd") & "'"
            End If

            If txtgnsarefno.Text.Trim <> "" Then
                lsSql &= " and cover_no='" & txtgnsarefno.Text.Trim & "'"
            End If

            If txtContractNo.Text.Trim <> "" Then
                lsSql &= " and contract_no='" & txtContractNo.Text.Trim & "'"
            End If

            lsSql &= " order by cover_no asc"
        Else
            lsSql = ""
            lsSql &= " select packet_gid as 'Packet gid', cover_no as 'Cover No',contract_no as 'Contract No',lot_no as 'Lot No' "
            lsSql &= " from arms_trn_tpacket "
            lsSql &= " where packet_status & " & GCPACKETSCANCOMPLETED & " = " & GCPACKETSCANCOMPLETED & " "
            lsSql &= " and packet_status & " & GCPACKETSCANAUDITED & " = 0 "
            lsSql &= " and delete_flag='N'"

            If dtpfrom.Checked Then
                lsSql &= " and  date_format(rcvd_date,'%Y-%m-%d') >='" & Format(dtpfrom.Value, "yyyy-MM-dd") & "'"
            End If

            If dtpto.Checked Then
                lsSql &= " and  date_format(rcvd_date,'%Y-%m-%d') <='" & Format(dtpto.Value, "yyyy-MM-dd") & "'"
            End If

            If txtgnsarefno.Text.Trim <> "" Then
                lsSql &= " and cover_no='" & txtgnsarefno.Text.Trim & "'"
            End If

            If txtContractNo.Text.Trim <> "" Then
                lsSql &= " and contract_no='" & txtContractNo.Text.Trim & "'"
            End If

            lsSql &= " order by cover_no asc"
            lsSql &= " limit 0, " & TxtLimitTo.Text & ""
        End If

        With dgvsummary
            .Columns.Clear()
            gpPopGridView(dgvsummary, lsSql, gOdbcConn)
            lbltotrec.Text = "Total Records : " & (.RowCount).ToString
        End With
    End Sub

    Private Sub btnclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclear.Click
        dtpfrom.Value = Now()
        dtpfrom.Checked = False
        dtpto.Value = Now()
        dtpto.Checked = False
        txtgnsarefno.Text = ""
        dgvsummary.DataSource = Nothing
        lbltotrec.Text = ""
    End Sub

    Private Sub btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        If MsgBox("Do you want to Close?", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2, gsProjectName) = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        If dgvsummary.Rows.Count <= 0 Then
            Exit Sub
        End If
        Call PrintDGridXML(dgvsummary, gsReportPath & "\Summary.xls", "Summary")
    End Sub

    Private Sub dgvsummary_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvsummary.CellContentDoubleClick
        Dim lssql, lsPacketRef, lsLockFlag, lsLockBy As String
        Dim ds As New DataSet

        If e.RowIndex < 0 Then
            Exit Sub
        End If
        lssql = ""
        lssql &= " select cover_no "
        lssql &= " from arms_trn_tpacket "
        lssql &= " where lot_no='" & dgvsummary.Rows(e.RowIndex).Cells("Lot No").Value.ToString & "'"
        lssql &= " and contract_no='" & dgvsummary.Rows(e.RowIndex).Cells("Contract No").Value.ToString & "'"
        lssql &= " and cover_no <> '" & dgvsummary.Rows(e.RowIndex).Cells("Cover No").Value.ToString & "'"
        lssql &= " and delete_flag='N'"
        lsPacketRef = gfExecuteScalar(lssql, gOdbcConn)

        lssql = ""
        lssql &= " select gnsa_lock_flag,gnsa_lock_by "
        lssql &= " from arms_trn_tpacket "
        lssql &= " where lot_no='" & dgvsummary.Rows(e.RowIndex).Cells("Lot No").Value.ToString & "'"
        lssql &= " and contract_no='" & dgvsummary.Rows(e.RowIndex).Cells("Contract No").Value.ToString & "'"
        lssql &= " and cover_no= '" & dgvsummary.Rows(e.RowIndex).Cells("Cover No").Value.ToString & "'"
        lssql &= " and delete_flag='N'"

        gpDataSet(lssql, "Packet", gOdbcConn, ds)

        If ds.Tables("Packet").Rows.Count = 1 Then
            lsLockFlag = ds.Tables("Packet").Rows(0).Item("gnsa_lock_flag").ToString
            lsLockBy = ds.Tables("Packet").Rows(0).Item("gnsa_lock_by").ToString
        End If

        If lsLockFlag = "Y" And lsLockBy <> gsLoginUserCode Then
            MsgBox("This Packet Already Opened by:" & lsLockBy & "", MsgBoxStyle.Information, gsProjectName)
            Exit Sub
        End If

        Dim frmImageEntry As New frmImageBaseEntry(dgvsummary.Rows(e.RowIndex).Cells("Packet gid").Value.ToString)
        frmImageEntry.ShowDialog()

        rdoLimitTo.Checked = True
        LoadData()
    End Sub


    Private Sub dgvsummary_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        Dim lssql, lsPacketRef As String

        If dgvsummary.Columns(e.ColumnIndex).Name = "Physical" Then
            If e.RowIndex < 0 Then
                Exit Sub
            End If

            lssql = ""
            lssql &= " select cover_no "
            lssql &= " from arms_trn_tpacket "
            lssql &= " where lot_no='" & dgvsummary.Rows(0).Cells("Lot No").Value.ToString & "'"
            lssql &= " and contract_no = '" & dgvsummary.Rows(0).Cells("Contract No").Value.ToString & "'"
            lssql &= " and cover_no <> '" & dgvsummary.Rows(0).Cells("Cover No").Value.ToString & "'"
            lssql &= " and delete_flag='N'"

            lsPacketRef = gfExecuteScalar(lssql, gOdbcConn)

            If lsPacketRef <> "" Then
                If MsgBox("This Agreement Already have a packet:" & lsPacketRef & "..,Do you want to Continue?", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2, gsProjectName) = MsgBoxResult.No Then
                    Exit Sub
                End If
            End If

         
            'txtgnsarefno.Text = ""
            LoadData()
        Else
            Dim frmImageEntry As New frmImageBaseEntry(dgvsummary.Rows(e.RowIndex).Cells("Packet gid").Value.ToString)
            frmImageEntry.ShowDialog()
        End If

    End Sub

End Class