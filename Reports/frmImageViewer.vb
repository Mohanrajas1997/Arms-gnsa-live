Public Class frmImageViewer

    Dim lnbmb As Image

    Public Sub New(ByVal bmb)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        lnbmb = bmb
        PicFrontSide.Image = lnbmb


    End Sub

    Private Sub frmImageViewer_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class