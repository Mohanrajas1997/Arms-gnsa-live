<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUndoFile
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dtpImportTo = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboFileName = New System.Windows.Forms.ComboBox()
        Me.cboFileType = New System.Windows.Forms.ComboBox()
        Me.cboEntity = New System.Windows.Forms.ComboBox()
        Me.dtpDateFrom = New System.Windows.Forms.DateTimePicker()
        Me.lbReceivedBy = New System.Windows.Forms.Label()
        Me.lbReceivedDate = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pnlButton = New System.Windows.Forms.Panel()
        Me.btnPost = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.lblFileName = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Panel1.SuspendLayout()
        Me.pnlButton.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.dtpImportTo)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.cboFileName)
        Me.Panel1.Controls.Add(Me.cboFileType)
        Me.Panel1.Controls.Add(Me.cboEntity)
        Me.Panel1.Controls.Add(Me.dtpDateFrom)
        Me.Panel1.Controls.Add(Me.lbReceivedBy)
        Me.Panel1.Controls.Add(Me.lbReceivedDate)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.pnlButton)
        Me.Panel1.Controls.Add(Me.lblFileName)
        Me.Panel1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(12, 9)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(435, 164)
        Me.Panel1.TabIndex = 0
        '
        'dtpImportTo
        '
        Me.dtpImportTo.CustomFormat = "dd-MM-yyyy"
        Me.dtpImportTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpImportTo.Location = New System.Drawing.Point(297, 12)
        Me.dtpImportTo.Name = "dtpImportTo"
        Me.dtpImportTo.Size = New System.Drawing.Size(122, 21)
        Me.dtpImportTo.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(224, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 50
        Me.Label1.Text = "Import To"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboFileName
        '
        Me.cboFileName.FormattingEnabled = True
        Me.cboFileName.Location = New System.Drawing.Point(85, 98)
        Me.cboFileName.Name = "cboFileName"
        Me.cboFileName.Size = New System.Drawing.Size(334, 21)
        Me.cboFileName.TabIndex = 4
        '
        'cboFileType
        '
        Me.cboFileType.FormattingEnabled = True
        Me.cboFileType.Location = New System.Drawing.Point(85, 69)
        Me.cboFileType.Name = "cboFileType"
        Me.cboFileType.Size = New System.Drawing.Size(334, 21)
        Me.cboFileType.TabIndex = 3
        '
        'cboEntity
        '
        Me.cboEntity.FormattingEnabled = True
        Me.cboEntity.Location = New System.Drawing.Point(85, 39)
        Me.cboEntity.Name = "cboEntity"
        Me.cboEntity.Size = New System.Drawing.Size(334, 21)
        Me.cboEntity.TabIndex = 2
        '
        'dtpDateFrom
        '
        Me.dtpDateFrom.CustomFormat = "dd-MM-yyyy"
        Me.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDateFrom.Location = New System.Drawing.Point(85, 12)
        Me.dtpDateFrom.Name = "dtpDateFrom"
        Me.dtpDateFrom.Size = New System.Drawing.Size(122, 21)
        Me.dtpDateFrom.TabIndex = 0
        '
        'lbReceivedBy
        '
        Me.lbReceivedBy.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lbReceivedBy.Location = New System.Drawing.Point(-8, 44)
        Me.lbReceivedBy.Name = "lbReceivedBy"
        Me.lbReceivedBy.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lbReceivedBy.Size = New System.Drawing.Size(87, 16)
        Me.lbReceivedBy.TabIndex = 45
        Me.lbReceivedBy.Text = "Entity"
        '
        'lbReceivedDate
        '
        Me.lbReceivedDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lbReceivedDate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbReceivedDate.Location = New System.Drawing.Point(-3, 15)
        Me.lbReceivedDate.Name = "lbReceivedDate"
        Me.lbReceivedDate.Size = New System.Drawing.Size(84, 13)
        Me.lbReceivedDate.TabIndex = 44
        Me.lbReceivedDate.Text = "Import From"
        Me.lbReceivedDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(4, 100)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 13)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "File Name"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnlButton
        '
        Me.pnlButton.Controls.Add(Me.btnPost)
        Me.pnlButton.Controls.Add(Me.btnClose)
        Me.pnlButton.Location = New System.Drawing.Point(267, 125)
        Me.pnlButton.Name = "pnlButton"
        Me.pnlButton.Size = New System.Drawing.Size(152, 28)
        Me.pnlButton.TabIndex = 5
        '
        'btnPost
        '
        Me.btnPost.Location = New System.Drawing.Point(1, 3)
        Me.btnPost.Name = "btnPost"
        Me.btnPost.Size = New System.Drawing.Size(72, 24)
        Me.btnPost.TabIndex = 0
        Me.btnPost.Text = "&Undo"
        Me.btnPost.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(79, 3)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(72, 24)
        Me.btnClose.TabIndex = 1
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'lblFileName
        '
        Me.lblFileName.Location = New System.Drawing.Point(18, 71)
        Me.lblFileName.Name = "lblFileName"
        Me.lblFileName.Size = New System.Drawing.Size(61, 13)
        Me.lblFileName.TabIndex = 2
        Me.lblFileName.Text = "File Type"
        Me.lblFileName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'frmUndoFile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(459, 185)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmUndoFile"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Undo File"
        Me.Panel1.ResumeLayout(False)
        Me.pnlButton.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dtpImportTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboFileName As System.Windows.Forms.ComboBox
    Friend WithEvents cboFileType As System.Windows.Forms.ComboBox
    Friend WithEvents cboEntity As System.Windows.Forms.ComboBox
    Friend WithEvents dtpDateFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbReceivedBy As System.Windows.Forms.Label
    Friend WithEvents lbReceivedDate As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents pnlButton As System.Windows.Forms.Panel
    Friend WithEvents btnPost As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents lblFileName As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
End Class
