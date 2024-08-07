<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPullout
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
        Me.cboSheetName = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pnlButton = New System.Windows.Forms.Panel()
        Me.btnImport = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.txtFileName = New System.Windows.Forms.TextBox()
        Me.lblFileName = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.cboEntity = New System.Windows.Forms.ComboBox()
        Me.dpDate = New System.Windows.Forms.DateTimePicker()
        Me.lbReceivedBy = New System.Windows.Forms.Label()
        Me.lbReceivedDate = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.pnlButton.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.cboEntity)
        Me.Panel1.Controls.Add(Me.dpDate)
        Me.Panel1.Controls.Add(Me.lbReceivedBy)
        Me.Panel1.Controls.Add(Me.lbReceivedDate)
        Me.Panel1.Controls.Add(Me.cboSheetName)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.pnlButton)
        Me.Panel1.Controls.Add(Me.btnBrowse)
        Me.Panel1.Controls.Add(Me.txtFileName)
        Me.Panel1.Controls.Add(Me.lblFileName)
        Me.Panel1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(453, 164)
        Me.Panel1.TabIndex = 1
        '
        'cboSheetName
        '
        Me.cboSheetName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSheetName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboSheetName.ItemHeight = 13
        Me.cboSheetName.Location = New System.Drawing.Point(82, 96)
        Me.cboSheetName.Name = "cboSheetName"
        Me.cboSheetName.Size = New System.Drawing.Size(331, 21)
        Me.cboSheetName.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(4, 100)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 13)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Sheet Name"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnlButton
        '
        Me.pnlButton.Controls.Add(Me.btnImport)
        Me.pnlButton.Controls.Add(Me.btnClose)
        Me.pnlButton.Location = New System.Drawing.Point(261, 122)
        Me.pnlButton.Name = "pnlButton"
        Me.pnlButton.Size = New System.Drawing.Size(152, 28)
        Me.pnlButton.TabIndex = 3
        '
        'btnImport
        '
        Me.btnImport.Location = New System.Drawing.Point(1, 3)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(72, 24)
        Me.btnImport.TabIndex = 0
        Me.btnImport.Text = "&Import"
        Me.btnImport.UseVisualStyleBackColor = True
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
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(421, 67)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(25, 21)
        Me.btnBrowse.TabIndex = 1
        Me.btnBrowse.Text = "...."
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'txtFileName
        '
        Me.txtFileName.Location = New System.Drawing.Point(82, 67)
        Me.txtFileName.Name = "txtFileName"
        Me.txtFileName.ReadOnly = True
        Me.txtFileName.Size = New System.Drawing.Size(331, 21)
        Me.txtFileName.TabIndex = 0
        '
        'lblFileName
        '
        Me.lblFileName.Location = New System.Drawing.Point(18, 71)
        Me.lblFileName.Name = "lblFileName"
        Me.lblFileName.Size = New System.Drawing.Size(61, 13)
        Me.lblFileName.TabIndex = 2
        Me.lblFileName.Text = "File Name"
        Me.lblFileName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'cboEntity
        '
        Me.cboEntity.FormattingEnabled = True
        Me.cboEntity.Location = New System.Drawing.Point(85, 39)
        Me.cboEntity.Name = "cboEntity"
        Me.cboEntity.Size = New System.Drawing.Size(328, 21)
        Me.cboEntity.TabIndex = 47
        '
        'dpDate
        '
        Me.dpDate.CustomFormat = "dd-MM-yyyy"
        Me.dpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpDate.Location = New System.Drawing.Point(85, 12)
        Me.dpDate.Name = "dpDate"
        Me.dpDate.Size = New System.Drawing.Size(328, 21)
        Me.dpDate.TabIndex = 46
        '
        'lbReceivedBy
        '
        Me.lbReceivedBy.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lbReceivedBy.Location = New System.Drawing.Point(-6, 42)
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
        Me.lbReceivedDate.Text = "Date"
        Me.lbReceivedDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmPullout
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(479, 189)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmPullout"
        Me.Text = "Pullout Master"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlButton.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cboSheetName As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents pnlButton As System.Windows.Forms.Panel
    Friend WithEvents btnImport As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents txtFileName As System.Windows.Forms.TextBox
    Friend WithEvents lblFileName As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents cboEntity As System.Windows.Forms.ComboBox
    Friend WithEvents dpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbReceivedBy As System.Windows.Forms.Label
    Friend WithEvents lbReceivedDate As System.Windows.Forms.Label
End Class
