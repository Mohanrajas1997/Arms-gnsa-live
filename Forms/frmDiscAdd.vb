Public Class frmDiscAdd
    Dim Packet As String = ""
    Dim PacketChar As String = ""
    Dim mnChklstValid As Long
    Dim mnChklstDisc As Long
    Dim mnChkLstAllStatus As Long = 0
    Dim mnChkLstSelected As Long = 0

    Public Sub New(ByVal PacketMode As String)
        InitializeComponent()
        Packet = PacketMode
        If PacketMode = "PDC" Then
            PacketChar = "P"
        ElseIf PacketMode = "SPDC" Then
            PacketChar = "S"
        End If
    End Sub
    Private Sub frmDiscAdd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim lsSql As String = ""
        Dim lobjChkBoxColumn As DataGridViewCheckBoxColumn
        Dim lnChkLstDisc As Integer
        Dim n As Integer
        Me.KeyPreview = True
        lsSql = ""
        lsSql &= " select disc_gid, disc_flag, disc_desc  as 'Disc List'"
        lsSql &= " FROM arms_mst_tdisc "
        lsSql &= " WHERE disc_type='CHQ'"
        lsSql &= " and delete_flag='N'"

        dgvChklst.Columns.Clear()
        gpPopGridView(dgvChklst, lsSql, gOdbcConn)
        With dgvChklst
            .Columns("disc_gid").Visible = False
            .Columns("disc_flag").Visible = False
            .Columns("Disc List").Width = 320

            For i = 0 To .Columns.Count - 1
                .Columns(i).ReadOnly = True
            Next i

            n = .Columns.Count - 1

            lobjChkBoxColumn = New DataGridViewCheckBoxColumn
            lobjChkBoxColumn.HeaderText = "Select"
            lobjChkBoxColumn.Width = 50
            lobjChkBoxColumn.Name = "Select"
            lobjChkBoxColumn.Selected = False

            .Columns.Add(lobjChkBoxColumn)

            For i = 0 To .Rows.Count - 1
                mnChkLstAllStatus = mnChkLstAllStatus Or .Rows(i).Cells("disc_flag").Value

                If (lnChkLstDisc And .Rows(i).Cells("disc_flag").Value) > 0 Then
                    .Rows(i).Cells(n + 1).Value = True
                Else
                    .Rows(i).Cells(n + 1).Value = False
                End If
            Next i


        End With
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim lnChklstValue As Long = 0
        Dim lnChklstDisc As Long = 0
        Dim i As Integer
        Dim n As Integer

        ' check list value
        With dgvChklst
            n = .Columns.Count - 1

            For i = 0 To .Rows.Count - 1
                lnChklstValue = .Rows(i).Cells("disc_flag").Value

                If .Rows(i).Cells(n).Value = True Then
                    lnChklstDisc = lnChklstDisc Or lnChklstValue
                End If
            Next i
        End With
        GCScanDiscValue = lnChklstDisc
        Me.Close()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub dgvChklst_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvChklst.CellContentClick
        Dim i As Integer
        Dim lnChklstValue As Long
        Dim lnChklstDisc As Long

        With dgvChklst
            If e.RowIndex >= 0 And dgvChklst.ReadOnly = False Then
                Select Case e.ColumnIndex
                    Case .Columns.Count - 1
                        .Rows(e.RowIndex).Cells(.Columns.Count - 1).Value = False


                        .EndEdit()

                        For i = 0 To .Rows.Count - 1
                            lnChklstValue = .Rows(i).Cells("disc_flag").Value
                            mnChkLstAllStatus = mnChkLstAllStatus Or lnChklstValue

                            If .Rows(i).Cells(.Columns.Count - 1).Value = True Then
                                lnChklstDisc = lnChklstDisc Or lnChklstValue
                            End If
                        Next i
                End Select

            End If
        End With
    End Sub

    Private Sub frmDiscAdd_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.Send("{TAB}")
            Case Keys.Escape
                btnClose_Click(sender, e)
        End Select

    End Sub
End Class