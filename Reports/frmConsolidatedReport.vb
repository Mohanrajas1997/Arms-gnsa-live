Public Class frmconsolidatedReport

    Dim lsCond As String = ""

    Private Sub frmconsolidatedReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            gsQry = " select CONCAT(entity_code,'-', entity_name) as EntityCode ,entity_gid from arms_mst_tentity"
            gsQry &= " where delete_flag='N' "
            gsQry &= " order by entity_name "
            Call gpBindCombo(gsQry, "EntityCode", "entity_gid", cboEntity, gOdbcConn)

            Call ClearAll()

            KeyPreview = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ClearAll()
        cboEntity.Text = ""
        txtLotNo.Text = ""
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
        Dim lsFld As String

        lsCond = ""

        Try
            If cboEntity.Text = "" Then
                MsgBox("Please Select Entity", MsgBoxStyle.Information, gsProjectName)
                cboEntity.Focus()
                Exit Sub
            End If

            If txtLotNo.Text = "" Then
                MsgBox("Please enter lotno", MsgBoxStyle.Information, gsProjectName)
                txtLotNo.Focus()
                Exit Sub
            End If

            If Not (cboEntity.SelectedIndex = -1 Or cboEntity.Text.Trim = "") Then
                lsCond &= " and a.entity_gid = '" & QuoteFilter(cboEntity.SelectedValue.ToString) & "' "
            End If

            If txtLotNo.Text <> "" Then lsCond &= " and h.lot_no = '" & QuoteFilter(txtLotNo.Text) & "' "

            lsFld = ""

            lsFld &= " h.lot_no as 'Lot No',"
            lsFld &= "c.entity_code as 'ClientCode',"
            lsFld &= "'CITIOPS' as 'DealerCode',"
            lsFld &= "a.box_no as 'BoxNo',"
            lsFld &= "'PDC' as 'ChequeType',"
            lsFld &= "h.contract_no as 'ContractNo',"
            lsFld &= "'' as 'InvoiceDate',"
            lsFld &= "a.chq_date as 'DueDate',"
            lsFld &= "a.chq_amount as 'ChequeAmount',"
            lsFld &= "a.chq_no as 'ChequeNo',"
            lsFld &= "'' as 'ToChequeNo',"
            lsFld &= "a.chq_date as 'ChequeDate',"
            lsFld &= "a.chq_amount as 'ChequeAmount',"
            lsFld &= "c.entity_code as 'PayTo',"
            lsFld &= "'W' as 'Status',"
            lsFld &= "a.micr_code as 'SortKey',"
            lsFld &= "d.loc_name as 'Storage',"
            lsFld &= "a.micr_code as 'SortKey',"
            lsFld &= "d.loc_name as 'PayableLocation',"
            lsFld &= "a.chq_acc_no as 'AccountNo',"
            lsFld &= "a.cuboard_no as 'CuboardNo',"
            lsFld &= "a.shelf_no as 'ShelfNo',"
            'lsFld &= "h.packet_no as 'CoverNO',"
            lsFld &= "h.cover_no as 'CoverNO',"
            lsFld &= "a.chq_amount as 'BreakupAmount',"
            lsFld &= "a.payee_name as 'Remark1_CustomerName',"
            lsFld &= "d.loc_name as 'Remark2',"
            lsFld &= "a.chq_acc_no as 'Remark3',"
            lsFld &= "h.contract_no as 'Remark4',"
            lsFld &= "'' as 'Remark5',"
            lsFld &= "a.cts_flag as 'CTS',"
            lsFld &= "'' as 'Remark7',"
            lsFld &= "'' as 'Remark8',"
            lsFld &= "'' as 'Remark9',"
            lsFld &= "'' as 'Remark10',"
            lsFld &= "a.additional1 as 'Addition1',"
            lsFld &= "a.additional2 as 'Addition2',"
            lsFld &= "a.additional3 as 'Addition3',"
            lsFld &= "a.additional4 as 'Addition4',"
            lsFld &= "a.additional5 as 'Addition5',"
            lsFld &= " make_set(a.chq_status," & gsChqStatus & ") as 'Chq Status',"
            'lsFld &= "(select group_concat(disc_desc) from arms_mst_tdisc where disc_flag & a.chq_disc = disc_flag and disc_type='chq' and delete_flag='N') as 'Chq Disc Status', "
            'lsFld &= "(select group_concat(disc_desc) from arms_mst_tdisc where a.chq_disc = disc_flag and disc_type='chq' and delete_flag='N') as 'Chq Disc Status', "
            lsFld &= "make_set(a.chq_disc," & gsChqDiscStatus & ") as 'Chq Disc Status',"
            lsFld &= "a.chq_remark as 'Chq Disc Status',"
            lsFld &= "'Cheque Table record' as 'Record Status',"
            lsFld &= "e.prod_code as 'Product',"
            lsFld &= "a.bank_name as 'Bank Name',"
            lsFld &= "a.batch_gid as 'Batch Id',"
            lsFld &= "g.batchchq_gid as 'Batch Chq Id',"
            lsFld &= "a.chq_gid as 'Cheque Id'"

            gsQry = ""
            gsQry &= " (select " & lsFld
            gsQry &= " from arms_trn_tcheque as a"
            gsQry &= " left join arms_trn_tpacket as h on a.packet_gid=h.packet_gid and h.delete_flag='N'"
            gsQry &= " left join arms_trn_tfile as b on b.file_gid=a.file_gid and b.delete_flag = 'N'"
            gsQry &= " left join arms_mst_tentity as c on c.entity_gid=a.entity_gid and c.delete_flag = 'N'"
            gsQry &= " left join arms_mst_tlocation as d on d.loc_code = a.loc_code and d.delete_flag = 'N' "
            gsQry &= " left join arms_mst_tproduct as e on e.prod_flag = a.prod_flag and e.delete_flag = 'N' "
            gsQry &= " left join arms_trn_tbatchentry as f on f.chq_gid = a.chq_gid and f.delete_flag = 'N' "

            gsQry &= " left join arms_trn_tbatchcheque as g on g.chq_gid = a.chq_gid and g.delete_flag = 'N' "
            gsQry &= " where true "
            gsQry &= lsCond
            gsQry &= " and a.delete_flag='N' and a.rplob_gid = 0 "
            gsQry &= " order by h.lot_no,h.cover_no,a.chq_gid, g.batchchq_gid asc) "

            gsQry &= "union all"

            gsQry &= "( select "
            gsQry &= " h.lot_no as 'Lot No',"
            gsQry &= "c.entity_code as 'ClientCode',"
            gsQry &= "'CITIOPS' as 'DealerCode',"
            gsQry &= "'' as 'BoxNo',"
            gsQry &= "'PDC' as 'ChequeType',"
            gsQry &= "h.contract_no as 'ContractNo',"
            gsQry &= "'' as 'InvoiceDate',"
            gsQry &= "a.chq_date as 'DueDate',"
            gsQry &= "a.chq_amount as 'ChequeAmount',"
            gsQry &= "a.chq_no as 'ChequeNo',"
            gsQry &= "'' as 'ToChequeNo',"
            gsQry &= "a.chq_date as 'ChequeDate',"
            gsQry &= "a.chq_amount as 'ChequeAmount',"
            gsQry &= "c.entity_code as 'PayTo',"
            gsQry &= "'W' as 'Status',"
            gsQry &= "a.micr_code as 'SortKey',"
            gsQry &= "d.loc_name as 'Storage',"
            gsQry &= "a.micr_code as 'SortKey',"
            gsQry &= "d.loc_name as 'PayableLocation',"
            gsQry &= "a.chq_acc_no as 'AccountNo',"
            gsQry &= "'' as 'CuboardNo',"
            gsQry &= "'' as 'ShelfNo',"
            'gsQry &= "h.packet_no as 'CoverNO',"
            gsQry &= "h.cover_no as 'CoverNO',"
            gsQry &= "a.chq_amount as 'BreakupAmount',"
            gsQry &= "a.payee_name as 'Remark1_CustomerName',"
            gsQry &= "d.loc_name as 'Remark2',"
            gsQry &= "a.chq_acc_no as 'Remark3',"
            gsQry &= "h.contract_no as 'Remark4',"
            gsQry &= "'' as 'Remark5',"
            gsQry &= "a.cts_flag as 'CTS',"
            gsQry &= "'' as 'Remark7',"
            gsQry &= "'' as 'Remark8',"
            gsQry &= "'' as 'Remark9',"
            gsQry &= "'' as 'Remark10',"
            gsQry &= "a.additional1 as 'Addition1',"
            gsQry &= "a.additional2 as 'Addition2',"
            gsQry &= "a.additional3 as 'Addition3',"
            gsQry &= "a.additional4 as 'Addition4',"
            gsQry &= "a.additional5 as 'Addition5',"
            gsQry &= " '' as 'Chq Status',"
            'lsFld &= "(select group_concat(disc_desc) from arms_mst_tdisc where disc_flag & a.chq_disc = disc_flag and disc_type='chq' and delete_flag='N') as 'Chq Disc Status', "
            gsQry &= "'' as 'Chq Disc Status', "
            'lsFld &= "make_set(a.chq_disc," & gsChqDiscStatus & ") as 'Chq Disc Status',"
            gsQry &= "'' as 'Chq Disc Status',"
            gsQry &= "'Aplobh Table record' as 'Record Status',"
            gsQry &= "e.prod_code as 'Product',"
            gsQry &= "a.bank_name as 'Bank Name',"
            gsQry &= "'' as 'Batch Id',"
            gsQry &= "g.batchchq_gid as 'Batch Chq Id',"
            gsQry &= "a.chq_gid as 'Cheque Id'"

            gsQry &= " from arms_trn_taplobinput as a"
            gsQry &= " left join arms_trn_tpacket as h on a.packet_gid=h.packet_gid and h.delete_flag='N'"
            gsQry &= " left join arms_trn_tfile as b on b.file_gid=a.file_gid and b.delete_flag = 'N'"
            gsQry &= " left join arms_mst_tentity as c on c.entity_gid=a.entity_gid and c.delete_flag = 'N'"
            gsQry &= " left join arms_mst_tlocation as d on d.loc_code = a.loc_code and d.delete_flag = 'N' "
            gsQry &= " left join arms_mst_tproduct as e on e.prod_flag = a.prod_flag and e.delete_flag = 'N' "
            gsQry &= " left join arms_trn_tbatchentry as f on f.chq_gid = a.chq_gid and f.delete_flag = 'N' "

            gsQry &= " left join arms_trn_tbatchcheque as g on g.chq_gid = a.chq_gid and g.delete_flag = 'N' "
            gsQry &= " where true "
            gsQry &= lsCond
            gsQry &= " and a.delete_flag='N' and a.chq_gid = 0 "
            gsQry &= " order by h.lot_no,h.cover_no,a.chq_gid, g.batchchq_gid asc )"

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

    Private Sub frmConsolidatedReport_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Try
            With dgvReport
                .Top = pnlButtons.Top + pnlButtons.Height + 5
                .Width = Me.Width - 40
                .Height = Me.Height - pnlButtons.Height - pnlDisplay.Height - 60
                pnlDisplay.Width = .Width
                pnlDisplay.Top = pnlButtons.Top + pnlButtons.Height + dgvReport.Height + 10
                btnExport.Left = pnlDisplay.Width - (btnExport.Width + 10)
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

            PrintDGViewXML(dgvReport, gsReportPath & "Consolidated.xls", "Consolidated Report", "", True, True)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class