Public Class frmDummyPacketEntry

    Private Sub frmDummyPacketEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gsQry = ""
        gsQry = " select CONCAT(entity_code,'-', entity_name) as EntityCode ,entity_gid from arms_mst_tentity"
        gsQry &= " where delete_flag='N' "
        gsQry &= " order by entity_name "

        Call gpBindCombo(gsQry, "EntityCode", "entity_gid", cboEntityName, gOdbcConn)
    End Sub

    Private Sub frmDummyPacketEntry_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then SendKeys.Send("{TAB}")
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim lnPktId As Long = 0
        Dim lnPktSlNo As Long = 0
        Dim lsPktNo As String = ""
        Dim lsEntityName As String = ""
        Dim lsEntityGid As Long
        Dim lsContractNo As String = ""
        Dim lsLotNo As Long = 0
        Dim lsCoverNo As String = ""
        Dim lsRcvddate As Date
        Dim lnTotChqs As Long = 0
        Dim lnResult As Long = 0


        Try
            lsRcvddate = Format(dtpRcvdDate.Value, "yyyy-MM-dd")

            If cboEntityName.SelectedIndex = -1 Or cboEntityName.Text.Trim = "" Then
                MsgBox("Please select the Entity Name !", MsgBoxStyle.Information, gsProjectName)
                cboEntityName.Focus()
                Exit Sub
            Else
                lsEntityName = cboEntityName.Text.ToString
                lsEntityGid = cboEntityName.SelectedValue.ToString
            End If

            lnTotChqs = Val(txtTotChq.Text)
            lsLotNo = Val(txtLotNo.Text)

            If lsLotNo = 0 Then
                MsgBox("Please input Lot No !", MsgBoxStyle.Information, gsProjectName)
                txtLotNo.Focus()
                Exit Sub
            End If

            If TxtCoverNo.Text = "" Then
                MsgBox("Please input Cover no !", MsgBoxStyle.Information, gsProjectName)
                TxtCoverNo.Focus()
                Exit Sub
            Else
                lsCoverNo = Mid(QuoteFilter(TxtCoverNo.Text), 1, 128)
            End If

            If lnTotChqs = 0 Then
                MsgBox("Please input cheque count !", MsgBoxStyle.Information, gsProjectName)
                txtTotChq.Focus()
                Exit Sub
            End If

            ' Packet no generation
            gsQry = ""
            gsQry &= " select max(packet_slno) from arms_trn_tpacket "
            gsQry &= " where delete_flag = 'N' "

            lnPktSlNo = Val(gfExecuteScalar(gsQry, gOdbcConn)) + 1

            lsPktNo = txtLotNo.Text & Format(lnPktSlNo, "0000")

            ' Duplicate validation
            gsQry = ""
            gsQry &= " select count(*) from arms_trn_tpacket "
            gsQry &= " where packet_no = '" & lsPktNo & "' "
            gsQry &= " and lot_no = '" & QuoteFilter(txtLotNo.Text) & "' "
            'gsQry &= " and contract_no = '" & QuoteFilter(txtContractNo.Text) & "'"
            gsQry &= " and delete_flag = 'N' "

            lnResult = Val(gfExecuteScalar(gsQry, gOdbcConn))

            If lnResult > 0 Then
                MsgBox("Duplicate packet no : " & lsPktNo & " !", MsgBoxStyle.Critical, gsProjectName)
                txtLotNo.Focus()
                Exit Sub
            End If


            'Duplicate Validation Cover Number
            gsQry = ""
            gsQry &= " select count(*) from arms_trn_tpacket "
            gsQry &= " where "
            gsQry &= " entity_gid='" & lsEntityGid & "'"
            gsQry &= " and cover_no = '" & QuoteFilter(TxtCoverNo.Text) & "'"
            gsQry &= " and delete_flag = 'N' "

            lnResult = Val(gfExecuteScalar(gsQry, gOdbcConn))

            If lnResult > 0 Then
                MsgBox("Duplicate Cover no !", MsgBoxStyle.Critical, gsProjectName)
                TxtCoverNo.Focus()
                Exit Sub
            End If

            'insert in packet table
            gsQry = ""
            gsQry &= " insert into arms_trn_tpacket (rcvd_date,entity_gid,file_gid,lot_no,contract_no,cover_no,cheque_type,packet_slno,packet_no,"
            gsQry &= " tot_chqs,year_flag,remark,packet_status,entry_date,entry_by) values("
            gsQry &= " '" & Format(dtpRcvdDate.Value, "yyyy-MM-dd") & "',"
            gsQry &= " '" & lsEntityGid & "',"
            gsQry &= " '" & "999" & "',"
            gsQry &= " " & lsLotNo & ","
            gsQry &= " '" & "12345" & "',"
            gsQry &= "'" & lsCoverNo & "',"
            gsQry &= "'" & "" & "',"
            gsQry &= " " & lnPktSlNo & ","
            gsQry &= " '" & lsPktNo & "',"
            gsQry &= " " & lnTotChqs & ","
            gsQry &= " '" & "M" & "',"
            gsQry &= " '" & "" & "',"
            gsQry &= "1,"
            gsQry &= " sysdate(),"
            gsQry &= " '" & gsLoginUserCode & "')"

            lnResult = gfInsertQry(gsQry, gOdbcConn)

            gsQry = " select packet_gid from arms_trn_tpacket where packet_no = '" & lsPktNo & "' and contract_no = '" & "12345" & "' and lot_no = '" & lsLotNo & "' and entity_gid = '" & lsEntityGid & "' and delete_flag = 'N'"

            lnPktId = gfExecuteScalar(gsQry, gOdbcConn)

            Dim frmobj As New frmChequeEntry(lsRcvddate, lsEntityName, lsEntityGid, lsLotNo, lsCoverNo, lnTotChqs)
            frmobj.ShowDialog()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, gsProjectName)
        End Try

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

End Class