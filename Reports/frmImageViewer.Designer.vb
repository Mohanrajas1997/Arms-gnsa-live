<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmImageViewer
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.PicFrontSide = New System.Windows.Forms.PictureBox()
        CType(Me.PicFrontSide, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PicFrontSide
        '
        Me.PicFrontSide.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PicFrontSide.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PicFrontSide.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PicFrontSide.ErrorImage = Nothing
        Me.PicFrontSide.Location = New System.Drawing.Point(12, 12)
        Me.PicFrontSide.Name = "PicFrontSide"
        Me.PicFrontSide.Size = New System.Drawing.Size(896, 314)
        Me.PicFrontSide.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicFrontSide.TabIndex = 26
        Me.PicFrontSide.TabStop = False
        '
        'frmImageViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(920, 338)
        Me.Controls.Add(Me.PicFrontSide)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmImageViewer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Image Viewer"
        CType(Me.PicFrontSide, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents PicFrontSide As PictureBox
End Class
