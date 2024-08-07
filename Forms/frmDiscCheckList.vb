Public Class frmDiscCheckList
    Dim mbReadOnly As Boolean

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If MsgBox("Do you want to close?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, gsProjectName) = MsgBoxResult.Yes Then
            MyBase.Close()
        End If
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Call fp_DiscValue()

        If gnDiscVal = 0 Then
            If MsgBox("No discs selected.  Do you want to close?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, gsProjectName) = MsgBoxResult.Yes Then
                MyBase.Close()
            End If
        Else
            MyBase.Close()
        End If
    End Sub

    Private Sub fp_DiscValue()
        Dim i As Integer

        gnDiscVal = 0
        For i = 0 To DGrid.RowCount - 1
            If Not IsDBNull(DGrid.Item(2, i).Value) Then
                If DGrid.Item(2, i).Value = True Then
                    gnDiscVal += DGrid.Item(1, i).Value
                End If
            End If
        Next
    End Sub

    Private Sub frmDiscCheckList_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then SendKeys.Send("{TAB}")
    End Sub

    Private Sub frmDiscCheckList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        KeyPreview = True
        AcceptButton = btnOK
        fp_BindGrid()

        If mbReadOnly = True Then btnOK.Enabled = False
    End Sub

    Sub fp_BindGrid()
        Dim lobjDT As DataTable
        Dim objDataColumn As DataColumn

        Dim i As Integer
        Try
            gsQry = ""
            gsQry &= " SELECT disc_desc 'Disc', disc_flag "
            gsQry &= " FROM arms_mst_tdisc "
            gsQry &= " where disc_type = 'CHQ' and delete_flag = 'N' "
            gsQry &= " order by disc_flag asc "

            lobjDT = GetDataTable(gsQry)
            If lobjDT.Rows.Count > 0 Then
                objDataColumn = New DataColumn
                objDataColumn.DataType = System.Type.GetType("System.Boolean")
                objDataColumn.ColumnName = "Select"

                lobjDT.Columns.Add(objDataColumn)
                DGrid.DataSource = lobjDT

                DGrid.Columns(0).ReadOnly = True
                DGrid.Columns(1).Visible = False

                DGrid.Columns(0).Width = 300
                DGrid.Columns(2).Width = 50
            End If

            If gnDiscVal <> 0 Then
                For i = 0 To DGrid.RowCount - 1
                    If (DGrid.Item(1, i).Value And gnDiscVal) > 0 Then
                        DGrid.Item(2, i).Value = True
                    Else
                        DGrid.Item(2, i).Value = False
                    End If
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, gsProjectName)
        End Try
    End Sub

    Private Sub chkClearAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkClearAll.CheckedChanged
        Dim i As Integer
        If chkClearAll.Checked = True Then
            For i = 0 To DGrid.RowCount - 1
                DGrid.Item(2, i).Value = False
            Next
        End If
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Public Sub New(ByVal ReadOnlyFlag As Boolean)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        mbReadOnly = ReadOnlyFlag
    End Sub
End Class