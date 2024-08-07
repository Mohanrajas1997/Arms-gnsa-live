Public Class frmPacketReport

    Dim lsCond As String = ""

    Private Sub frmPacketReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            gsQry = " select CONCAT(entity_code,'-', entity_name) as EntityCode ,entity_gid from arms_mst_tentity"
            gsQry &= " where delete_flag='N' "
            gsQry &= " order by entity_name "
            Call gpBindCombo(gsQry, "EntityCode", "entity_gid", cboEntity, gOdbcConn)

            cboStatus.Items.Add("Inward Entry")
            cboStatus.Items.Add("Auth Entry")
            cboStatus.Items.Add("Reject Entry")
            cboStatus.Items.Add("Packet Cheque Entry")
            cboStatus.Items.Add("Packet Cheque ReEntry")
            cboStatus.Items.Add("Packet Vaulted")
            cboStatus.Items.Add("Packet Pullout")
            cboStatus.Items.Add("Gnsa Ref Changed")
            cboStatus.Items.Add("Agreement No Changed")
            cboStatus.Items.Add("Packet Retrival")
            cboStatus.Items.Add("Packet Scan Completed")
            cboStatus.Items.Add("Packet ReScan")
            cboStatus.Items.Add("Packet Scan Audited")

            Call ClearAll()

            KeyPreview = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ClearAll()
        txtLotNo.Text = ""
        cboEntity.Text = ""
        txtContractNo.Text = ""
        txtPacketNo.Text = ""
        dtpImportFrom.Checked = False
        dtpImportTo.Checked = False
        dgvReport.DataSource = Nothing
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Call ClearAll()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        MyBase.Close()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Dim i As Integer

        lsCond = ""

        Try
            If dtpImportFrom.Checked = True Then lsCond &= " and a.rcvd_date >='" & Format(dtpImportFrom.Value, "yyyy-MM-dd") & "' "
            If dtpImportTo.Checked = True Then lsCond &= " and a.rcvd_date <='" & Format(dtpImportTo.Value, "yyyy-MM-dd") & "' "

            If txtContractNo.Text <> "" Then lsCond &= " and a.contract_no = '" & QuoteFilter(txtContractNo.Text) & "' "
            If txtLotNo.Text <> "" Then lsCond &= " and a.lot_no = '" & QuoteFilter(txtLotNo.Text) & "' "
            If txtPacketNo.Text <> "" Then lsCond &= " and a.packet_no = " & Val(txtPacketNo.Text) & " "

            If Not (cboEntity.SelectedIndex = -1 Or cboEntity.Text.Trim = "") Then
                lsCond &= " and a.entity_gid = '" & QuoteFilter(cboEntity.SelectedValue.ToString) & "' "
            End If

            If Not (cboStatus.SelectedIndex = -1 Or cboEntity.Text.Trim = "") Then
                Select Case cboStatus.Text
                    Case "Inward Entry"
                        lsCond &= " and a.packet_status & 1 > 0 "
                    Case "Auth Entry"
                        lsCond &= " and a.packet_status & 2 > 0 "
                    Case "Reject Entry"
                        lsCond &= " and a.packet_status & 4 > 0 "
                    Case "Packet Cheque Entry"
                        lsCond &= " and a.packet_status & 8 > 0 "
                    Case "Packet Cheque ReEntry"
                        lsCond &= " and a.packet_status & 16 > 0 "
                    Case "Packet Vaulted"
                        lsCond &= " and a.packet_status & 32 > 0 "
                    Case "Packet Pullout"
                        lsCond &= " and a.packet_status & 64 > 0 "
                    Case "Gnsa Ref Changed"
                        lsCond &= " and a.packet_status & 128 > 0 "
                    Case "Agreement No Changed"
                        lsCond &= " and a.packet_status & 256 > 0 "
                    Case "Packet Retrival"
                        lsCond &= " and a.packet_status & 512 > 0 "
                    Case "Packet Scan Completed"
                        lsCond &= " and a.packet_status & 1024 > 0 "
                    Case "Packet ReScan"
                        lsCond &= " and a.packet_status & 2048 > 0 "
                    Case "Packet Scan Audited"
                        lsCond &= " and a.packet_status & 4096 > 0 "

                End Select
            End If

            gsQry = ""
            gsQry &= " select "
            gsQry &= " c.entity_name as 'Company',"
            gsQry &= " a.lot_no as 'Lot No',"
            gsQry &= " date_format(a.rcvd_date,'%d-%m-%Y')  as 'Received Date',"
            gsQry &= " a.contract_no as 'Contract No',"
            gsQry &= " a.cover_no as 'Cover No',"
            gsQry &= " a.almira_gid as 'Almira Gid',"
            gsQry &= " a.Cheque_type as 'Cheque Type',"
            'gsQry &= " make_set(a.packet_status,'1','2','4','8','16','32','64','128','256','512','1024','2048','4096') as 'Packet Status' group by packet_status ,"
            gsQry &= " make_set(a.packet_status," & gsPacketStatus & ") as 'Packet Status',"
            'gsQry &= " case when a.packet_status = '1' then 'Inward Entry' when a.packet_status = '2' then 'Auth Entry' when a.packet_status = '4' then 'Reject Entry' when a.packet_status = '8' then 'Packet Cheque Entry' when a.packet_status = '16' then 'Packet Cheque ReEntry' when a.packet_status = '32' then 'Packet Vaulted' when a.packet_status = '64' then 'Packet Pullout' when a.packet_status = '128' then 'GNSA Ref Changed' when a.packet_status = '256' then 'Agreement No# Changed' when a.packet_status = '512' then 'Packet Retrival' when a.packet_status = '1024' then 'Packet Scan Completed' when a.packet_status = '2048' then 'Packet ReScan' when a.packet_status = '4096' then 'Packet Scan Audited' end as 'Packet Status',"
            gsQry &= " a.packet_no as 'Packet No',"
            gsQry &= "  a.packet_slno as 'Packet Slno',"
            gsQry &= " a.tot_chqs as 'Total Cheques',"
            gsQry &= " case when a.year_flag = 'M' then 'Monthly' when a.year_flag = 'H' then 'Halfly' when a.year_flag = 'Q' then 'Quartly' when a.year_flag = 'Y' then 'Yearly' end as 'Year Flag',"
            gsQry &= " a.remark as 'Remark',"
            gsQry &= " a.packet_gid as 'Packet Gid'"

            gsQry &= " from arms_trn_tpacket as a"
            gsQry &= " left join arms_trn_tfile as b on b.file_gid=a.file_gid and b.delete_flag = 'N'"
            gsQry &= " left join arms_mst_tentity as c on c.entity_gid=a.entity_gid and c.delete_flag = 'N'"
            gsQry &= " where true "
            gsQry &= lsCond
            gsQry &= " and a.delete_flag='N' order by packet_gid asc"

            Call gpPopGridView(dgvReport, gsQry, gOdbcConn)

            For i = 0 To dgvReport.Columns.Count - 1
                dgvReport.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next i

            dgvReport.AutoResizeColumns()

            lblRecCount.Text = "Record Count: " & dgvReport.RowCount
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, gsProjectName)
        End Try
    End Sub

    Private Sub frmPacketReport_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        Try
            With dgvReport
                .Top = pnlMain.Top + pnlMain.Height + 5
                .Width = Me.Width - 40
                .Height = Me.Height - pnlMain.Height - pnlExport.Height - 60
                pnlExport.Width = .Width
                pnlExport.Top = pnlMain.Top + pnlMain.Height + dgvReport.Height + 10
                btnExport.Left = pnlExport.Width - (btnExport.Width + 10)
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Try
            If dgvReport.RowCount = 0 Then
                MsgBox("No Details to Export!", MsgBoxStyle.Critical, gsProjectName)
                Exit Sub
            End If

            PrintDGViewXML(dgvReport, gsReportPath & "Packet.xls", "Packet Report", "", True, True)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class