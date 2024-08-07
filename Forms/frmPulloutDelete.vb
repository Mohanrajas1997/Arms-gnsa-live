Imports MySql.Data.MySqlClient

Public Class frmPulloutDelete
#Region "Local Declaration"
    Dim lnchqgid As Integer = 0
    Dim lnPulloutId As Integer
    Dim lnResult As Integer
    Dim lnContractNo As String = ""
    Dim lsPacketNo As String = ""
    Dim ldChqAmount As Double = 0
    Dim lnChqNo As Integer
    Dim lsChqDate As String = ""
    Dim lnEntityGid As Integer
    Dim cmd As MySqlCommand
    Dim da As MySqlDataAdapter
    Dim dt As DataTable
#End Region

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            Dim lsSql As String
            Dim dt1 As DataTable
            Dim vstatus As Integer

            If txtPullId.Text.Trim = "" Then
                MsgBox("Pullout Id cannot be empty !", MsgBoxStyle.Critical, gsProjectName)
                txtPullId.Focus()
            Else

                Dim i As Integer = 0
                If Not Integer.TryParse(txtPullId.Text, i) Then
                    i = 0
                End If
                lnPulloutId = i

                If MsgBox("Do You Want Delete ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
                    Call ConOpenOdbc(ServerDetails)

                    gsQry = ""
                    gsQry &= "select chq_gid from arms_trn_tpullout  where"
                    gsQry &= " pullout_gid = '" & QuoteFilter(txtPullId.Text.ToString) & "'"
                    gsQry &= "and delete_flag='N'"

                    dt1 = GetDataTable(gsQry)

                    If (dt1.Rows.Count <> 0) Then

                        lnchqgid = dt1.Rows(0)("chq_gid")

                    End If


                    If (lnchqgid > 0) Then
                        lsSql = ""
                        lsSql &= "select status_flag from arms_mst_tstatus where status_desc = 'Pullout' and status_type = 'Cheque' and delete_flag = 'N';"
                        vstatus = Val(gfExecuteScalar(lsSql, gOdbcConn))

                        lsSql = ""
                        lsSql &= " update arms_trn_tpullout as p inner join arms_trn_tcheque as c on p.chq_gid = c.chq_gid and c.delete_flag = 'N' set "
                        lsSql &= " c.chq_status = c.chq_status ^ '" & vstatus & "', "
                        lsSql &= " c.available_flag = 1, p.chq_gid = 0 "
                        lsSql &= " where c.chq_gid = '" & lnchqgid & "'"
                        lsSql &= " and c.chq_status & '" & vstatus & "' > 0 "
                        lsSql &= " and c.available_flag = 0 "
                        lsSql &= " and p.delete_flag = 'N' "
                        lnResult = gfInsertQry(lsSql, gOdbcConn)


                        lsSql = ""
                        lsSql &= " update arms_trn_tpullout set "
                        lsSql &= " update_date = sysdate(), "
                        lsSql &= " update_by = '" & gsLoginUserCode & "', "
                        lsSql &= " delete_flag = 'Y' "
                        lsSql &= "where pullout_gid = '" & txtPullId.Text & "' "
                        lsSql &= " and delete_flag = 'N' "

                        lnResult = gfInsertQry(lsSql, gOdbcConn)

                        Call ConCloseOdbc(ServerDetails)

                        If (lnResult = 0) Then
                            MsgBox("Record deletion failed !", MsgBoxStyle.Information, gsProjectName)
                            Call ControleEnable()
                        Else
                            MsgBox("Record deleted successfully !", MsgBoxStyle.Information, gsProjectName)
                            Call Clear()
                            lnPulloutId = 0
                            txtPullId.Focus()
                        End If
                    Else
                        MsgBox("Access Denied !", MsgBoxStyle.Information, gsProjectName)
                        Call ControleEnable()
                        Return
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ControleEnable()

        txtPullId.Enabled = False

        cboEntity.Enabled = False
        txtContractNo.Enabled = True
        txtChqNo.Enabled = True
        dtpChqDate.Enabled = True
        txtChqAmount.Enabled = True
        txtPacketNo.Enabled = True

        cboEntity.Focus()

    End Sub

    Private Sub Clear()

        txtPullId.Enabled = True
        txtPullId.Text = ""

        cboEntity.Enabled = False
        txtContractNo.Enabled = False
        txtChqNo.Enabled = False
        dtpChqDate.Enabled = False
        txtChqAmount.Enabled = False
        txtPacketNo.Enabled = False

        cboEntity.Text = ""
        txtContractNo.Text = ""
        txtPacketNo.Text = ""
        dtpChqDate.Text = ""
        txtChqAmount.Text = ""
        txtChqNo.Text = ""

        txtPullId.Focus()

    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Call Clear()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub txtPullId_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPullId.KeyDown
        If e.KeyCode = Keys.Enter Then

            Dim i As Integer = 0
            If Not Integer.TryParse(txtPullId.Text, i) Then
                i = 0
            End If

            lnPulloutId = i

            gsQry = ""
            gsQry &= "select a.entity_gid,b.entity_code as 'Entity Code',DATE_FORMAT(a.chq_date, '%d/%m/%Y') as 'Cheque Date',ifnull(a.contract_no,'') as 'Contract No',ifnull(a.packet_no,'') as 'Packet No',ifnull(a.chq_amount,'') as 'Cheque Amount',ifnull(a.chq_no,'') as 'Cheque No' from arms_trn_tpullout as a inner join arms_mst_tentity as b on b.entity_gid = a.entity_gid where"
            gsQry &= " a.pullout_gid = '" & QuoteFilter(txtPullId.Text.ToString) & "'"
            gsQry &= "and a.delete_flag='N'"

            dt = GetDataTable(gsQry)

            If (dt.Rows.Count <> 0) Then

                lnEntityGid = dt.Rows(0)("entity_gid")
                lnContractNo = dt.Rows(0)("Contract No")
                lsPacketNo = dt.Rows(0)("Packet No")
                lsChqDate = dt.Rows(0)("Cheque Date")
                ldChqAmount = dt.Rows(0)("Cheque Amount")
                lnChqNo = dt.Rows(0)("Cheque No")

                gsQry = " select CONCAT(entity_code,'-', entity_name) as EntityCode ,entity_gid from arms_mst_tentity"
                gsQry &= " where delete_flag='N' "
                gsQry &= " order by EntityCode "

                Call gpBindCombo(gsQry, "EntityCode", "entity_gid", cboEntity, gOdbcConn)
                Call PresetSelectedValue(cboEntity, lnEntityGid)

                txtContractNo.Text = lnContractNo
                txtPacketNo.Text = lsPacketNo
                dtpChqDate.Text = lsChqDate
                txtChqAmount.Text = ldChqAmount
                txtChqNo.Text = lnChqNo

                Call ControleEnable()

            Else
                MsgBox("Sorry Pullout Id Not Matched!")
                Clear()
            End If
        End If

    End Sub

    Public Sub PresetSelectedValue(ByRef ComboBox As ComboBox, ByVal value As Object)
        Dim item_ndx As Integer

        If ComboBox Is Nothing Then
            '   throw exception?
            Exit Sub
        End If
        With ComboBox
            .Tag = "PresetSelectedValue"
            For item_ndx = 0 To .Items.Count - 1
                .SelectedIndex = item_ndx
                If .SelectedValue = value Then
                    Exit For
                End If
            Next
            If item_ndx >= .Items.Count Then
                .SelectedIndex = -1
            End If
            .Tag = ""
        End With
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            Dim lsSql As String
            Dim dt2 As DataTable
            Dim lsChequeDate As String


            If txtPullId.Text.Trim = "" Then
                MsgBox("Pullout Id cannot be empty !", MsgBoxStyle.Critical, gsProjectName)
                txtPullId.Focus()
            Else

                Dim i As Integer = 0
                If Not Integer.TryParse(txtPullId.Text, i) Then
                    i = 0
                End If
                lnPulloutId = i

                Call ConOpenOdbc(ServerDetails)

                gsQry = ""
                gsQry &= "select chq_gid from arms_trn_tpullout  where"
                gsQry &= " pullout_gid = '" & QuoteFilter(txtPullId.Text.ToString) & "'"
                gsQry &= "and delete_flag='N'"

                dt2 = GetDataTable(gsQry)

                If (dt2.Rows.Count <> 0) Then

                    lnchqgid = dt2.Rows(0)("chq_gid")

                End If

                If (lnchqgid > 0) Then

                    lsChequeDate = Format(CDate(dtpChqDate.Text), "yyyy-MM-dd")

                    lsSql = ""
                    lsSql &= " update arms_trn_tpullout set "
                    lsSql &= " contract_no = '" & txtContractNo.Text & "', "
                    lsSql &= " packet_no = '" & txtPacketNo.Text & "', "
                    lsSql &= " chq_date = '" & lsChequeDate & "', "
                    lsSql &= " chq_amount = '" & txtChqAmount.Text & "', "
                    lsSql &= " chq_no = '" & txtChqNo.Text & "', "
                    lsSql &= " update_date = sysdate(), "
                    lsSql &= " update_by = '" & gsLoginUserCode & "'"
                    lsSql &= "where pullout_gid = '" & txtPullId.Text & "' "
                    lsSql &= " and delete_flag = 'N' "

                    lnResult = gfInsertQry(lsSql, gOdbcConn)

                    Call ConCloseOdbc(ServerDetails)

                    If (lnResult = 0) Then
                        MsgBox("Record updated failed !", MsgBoxStyle.Information, gsProjectName)
                        Call ControleEnable()
                    Else
                        MsgBox("Record updated successfully !", MsgBoxStyle.Information, gsProjectName)
                        Call Clear()
                        lnPulloutId = 0
                        txtPullId.Focus()
                    End If
                Else
                    MsgBox("Access Denied !", MsgBoxStyle.Information, gsProjectName)
                    Call ControleEnable()
                    Return
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class