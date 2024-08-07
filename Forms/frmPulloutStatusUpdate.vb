Imports System.IO
Imports System.IO.FileStream
Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Security.Cryptography
Public Class frmPulloutStatusUpdate
    Dim lsCond As String = ""
    Dim lnEntityId As Long
    Dim lnres As Integer
    Dim lnResult As Long
    Dim cmd As MySqlCommand
    Dim da As MySqlDataAdapter
    Dim dt As DataTable

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnRefresh.Click
        Dim i As Integer
        Dim n As Integer
        Dim lobjChkBoxColumn As DataGridViewCheckBoxColumn

        lsCond = ""

        Try
            If dtpReqFrom.Checked = True Then lsCond &= " and c.import_date >='" & Format(dtpReqFrom.Value, "yyyy-MM-dd") & "' "
            If dtpReqTo.Checked = True Then lsCond &= " and c.import_date < '" & Format(DateAdd(DateInterval.Day, 1, dtpReqTo.Value), "yyyy-MM-dd") & "' "

            If Not (cboEntity.SelectedIndex = -1 Or cboEntity.Text.Trim = "") Then
                lsCond &= " and a.entity_gid = '" & QuoteFilter(cboEntity.SelectedValue.ToString) & "' "
                lnEntityId = QuoteFilter(cboEntity.SelectedValue.ToString)
            Else
                MsgBox("Entity Cannot be empty!", MsgBoxStyle.Critical, gsProjectName)
                Exit Sub
            End If

            If TxtPulloutId.Text <> "" Then lsCond &= "and a.pullout_gid=" & Val(TxtPulloutId.Text) & ""


            If lsCond = "" Then lsCond = " and 1 = 2 "

            gsQry = ""
            gsQry &= " select "
            gsQry &= " a.entity_gid,b.entity_code as 'Entity Code',b.entity_name as 'Entity Name', a.contract_no as 'Contract No',date_format(a.chq_date,'%d-%m-%Y') as 'Chq Date',"
            gsQry &= " a.chq_no as 'Cheque No', a.chq_amount as 'Cheque Amount',a.pullout_reason as 'Pullout Reason',"
            gsQry &= " a.packet_no as 'Packet No', a.chq_gid as 'Chq Gid',a.pullout_gid,a.available_flag"
            gsQry &= " from arms_trn_tpullout as a "
            gsQry &= " inner join arms_mst_tentity as b on b.entity_gid=a.entity_gid and b.delete_flag = 'N'"
            gsQry &= " inner join arms_trn_tfile as c on a.entity_gid=c.entity_gid and a.file_gid=c.file_gid and c.delete_flag='N'"
            gsQry &= " where true "
            gsQry &= lsCond
            gsQry &= " and a.chq_gid>0 "
            gsQry &= " and a.dispatch_gid = 0"
            gsQry &= " and a.delete_flag='N' "

            dgvReport.Columns.Clear()

            Call gpPopGridView(dgvReport, gsQry, gOdbcConn)


            With dgvReport

                .Columns("entity_gid").Visible = False
                .Columns("available_flag").Visible = False

                For i = 0 To .Columns.Count - 1
                    .Columns(i).ReadOnly = True
                Next i
                n = .Columns.Count - 1

                lobjChkBoxColumn = New DataGridViewCheckBoxColumn
                lobjChkBoxColumn.HeaderText = "Available"
                lobjChkBoxColumn.Width = 50
                lobjChkBoxColumn.Name = "Available"
                lobjChkBoxColumn.Selected = False

                .Columns.Add(lobjChkBoxColumn)

                For i = 0 To .Rows.Count - 1

                    If (.Rows(i).Cells("available_flag").Value) = "Y" Then
                        .Rows(i).Cells(n + 1).Value = True
                    Else
                        .Rows(i).Cells(n + 1).Value = False
                    End If
                Next i

            End With

            For i = 0 To dgvReport.Columns.Count - 1
                dgvReport.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next i

            dgvReport.AutoResizeColumns()
            If dgvReport.Rows.Count > 0 Then
                BtnSelect.Enabled = True
                BtnDeSelect.Enabled = True
                BtnInverse.Enabled = True
                BtnUpdate.Enabled = True
            End If
            lblRecCount.Text = "Record Count: " & dgvReport.RowCount
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, gsProjectName)
        End Try
    End Sub

    Private Sub btnClear_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClear.Click
        Call ClearAll()
    End Sub

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClose.Click
        MyBase.Close()
    End Sub

    Private Sub btnExport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExport.Click
        Try
            If dgvReport.RowCount = 0 Then
                MsgBox("No Details to Export!", MsgBoxStyle.Critical, gsProjectName)
                Exit Sub
            End If
            PrintDGViewXML(dgvReport, gsReportPath & "PulloutStatusUpdate.xls", "PulloutStatusUpdate Report")

            MsgBox(" Exported to Excel !!" & Chr(13) & _
                   " Saved Path : " & gsReportPath & "FeatureRplob", MsgBoxStyle.Information, gsProjectName)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub frmFeatureRplobReport_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Try
            gsQry = " select CONCAT(entity_code,'-', entity_name) as EntityCode ,entity_gid from arms_mst_tentity"
            gsQry &= " where delete_flag='N' "
            gsQry &= " order by entity_name "
            Call gpBindCombo(gsQry, "EntityCode", "entity_gid", cboEntity, gOdbcConn)
            Call ClearAll()
            BtnSelect.Enabled = False
            BtnDeSelect.Enabled = False
            BtnInverse.Enabled = False
            BtnUpdate.Enabled = False

            KeyPreview = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ClearAll()
        cboEntity.Text = ""
        dtpReqFrom.Checked = False
        dtpReqTo.Checked = False
        dgvReport.DataSource = Nothing
        BtnSelect.Enabled = False
        BtnDeSelect.Enabled = False
        BtnInverse.Enabled = False
        BtnUpdate.Enabled = False
      
    End Sub

    Private Sub frmFeatureRplobReport_Resize(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Resize
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

    

    Private Sub BtnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSelect.Click
        Dim n As Integer
        With dgvReport
            n = .Columns.Count - 1
            For i = 0 To .Rows.Count - 1
                If .Rows(i).Cells(n).Value = False Then
                    .Rows(i).Cells(n).Value = True
                End If
            Next i
        End With

    End Sub

    Private Sub BtnDeSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDeSelect.Click
        Dim n As Integer
        With dgvReport
            n = .Columns.Count - 1
            For i = 0 To .Rows.Count - 1
                If .Rows(i).Cells(n).Value = True Then
                    .Rows(i).Cells(n).Value = False
                End If
            Next i
        End With
    End Sub

    Private Sub BtnInverse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnInverse.Click
        Dim n As Integer
        With dgvReport
            n = .Columns.Count - 1
            For i = 0 To .Rows.Count - 1
                If .Rows(i).Cells(n).Value = True Then
                    .Rows(i).Cells(n).Value = False
                Else
                    .Rows(i).Cells(n).Value = True
                End If
            Next i
        End With
    End Sub

    Private Sub BtnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUpdate.Click
        Dim n As Integer
        Dim lnChklstValue As Long = 0
        Dim lnPullOutId As Long = 0
        Dim lnEntitygid As Long = 0
        Dim lsAvailableFlag As String

        With dgvReport
            n = .Columns.Count - 1
            For i = 0 To .Rows.Count - 1

                lnChklstValue = .Rows(i).Cells("pullout_gid").Value
                lnEntityId = .Rows(i).Cells("entity_gid").Value
                lnPullOutId = 0
                lnPullOutId = lnChklstValue

                If .Rows(i).Cells(n).Value = True Then
                    lsAvailableFlag = "Y"
                Else
                    lsAvailableFlag = "N"
                End If

                Call ConOpenOdbc(ServerDetails)
                cmd = New MySqlCommand("pr_arms_set_tpullout", gOdbcConn)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("?pr_pullout_gid", lnPullOutId)
                cmd.Parameters("?pr_pullout_gid").Direction = ParameterDirection.Input
                cmd.Parameters.AddWithValue("?pr_entity_gid", lnEntityId)
                cmd.Parameters("?pr_entity_gid").Direction = ParameterDirection.Input
                cmd.Parameters.AddWithValue("?pr_dispatch_gid", 0)
                cmd.Parameters("?pr_dispatch_gid").Direction = ParameterDirection.Input
                cmd.Parameters.AddWithValue("?pr_available_flag", lsAvailableFlag)
                cmd.Parameters("?pr_available_flag").Direction = ParameterDirection.Input
                cmd.Parameters.AddWithValue("?pr_form_name", "PULLOUT")
                cmd.Parameters("?pr_form_name").Direction = ParameterDirection.Input
                cmd.Parameters.AddWithValue("?pr_action_by", gsLoginUserCode)
                cmd.Parameters("?pr_action_by").Direction = ParameterDirection.Input
                cmd.Parameters.AddWithValue("?pr_action", "UPDATE")
                cmd.Parameters("?pr_action").Direction = ParameterDirection.Input
                'out put Para
                cmd.Parameters.Add("?pr_result", MySqlDbType.Int32)
                cmd.Parameters("?pr_result").Direction = ParameterDirection.Output
                cmd.Parameters.Add("?pr_err_msg", MySqlDbType.VarChar)
                cmd.Parameters("?pr_err_msg").Direction = ParameterDirection.Output
                cmd.ExecuteNonQuery()
                Call ConCloseOdbc(ServerDetails)
                Dim res As Integer = Val(cmd.Parameters("?pr_result").Value.ToString())
                If (res = 0) Then
                    MsgBox(cmd.Parameters("?pr_err_msg").Value.ToString())

                Else
                    lnPullOutId = 0
                    lnEntityId = 0
                End If

            Next i
        End With
        MsgBox(cmd.Parameters("?pr_err_msg").Value.ToString())
        btnRefresh.PerformClick()
    End Sub
End Class