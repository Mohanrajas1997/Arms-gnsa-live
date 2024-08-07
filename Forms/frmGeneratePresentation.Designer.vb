<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGeneratePresentation
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
        Me.btnExport = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.pnlDisplay = New System.Windows.Forms.Panel()
        Me.lblRecCount = New System.Windows.Forms.Label()
        Me.dgvReport = New System.Windows.Forms.DataGridView()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboEntity = New System.Windows.Forms.ComboBox()
        Me.pnlButtons = New System.Windows.Forms.Panel()
        Me.dtpCycleTo = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpCycleFrom = New System.Windows.Forms.DateTimePicker()
        Me.btnGenerate = New System.Windows.Forms.Button()
        Me.pnlDisplay.SuspendLayout()
        CType(Me.dgvReport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlButtons.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnExport
        '
        Me.btnExport.Location = New System.Drawing.Point(679, 2)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(72, 24)
        Me.btnExport.TabIndex = 1
        Me.btnExport.Text = "E&xport"
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 13)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "Cheque Date"
        '
        'pnlDisplay
        '
        Me.pnlDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlDisplay.Controls.Add(Me.lblRecCount)
        Me.pnlDisplay.Controls.Add(Me.btnExport)
        Me.pnlDisplay.Location = New System.Drawing.Point(12, 340)
        Me.pnlDisplay.Name = "pnlDisplay"
        Me.pnlDisplay.Size = New System.Drawing.Size(756, 32)
        Me.pnlDisplay.TabIndex = 2
        '
        'lblRecCount
        '
        Me.lblRecCount.AutoSize = True
        Me.lblRecCount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblRecCount.Location = New System.Drawing.Point(9, 8)
        Me.lblRecCount.Name = "lblRecCount"
        Me.lblRecCount.Size = New System.Drawing.Size(83, 13)
        Me.lblRecCount.TabIndex = 0
        Me.lblRecCount.Text = "Record Count"
        '
        'dgvReport
        '
        Me.dgvReport.AllowUserToAddRows = False
        Me.dgvReport.AllowUserToDeleteRows = False
        Me.dgvReport.Location = New System.Drawing.Point(14, 94)
        Me.dgvReport.Name = "dgvReport"
        Me.dgvReport.ReadOnly = True
        Me.dgvReport.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dgvReport.Size = New System.Drawing.Size(754, 240)
        Me.dgvReport.TabIndex = 1
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(667, 40)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(72, 24)
        Me.btnClose.TabIndex = 4
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(590, 40)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(72, 24)
        Me.btnClear.TabIndex = 3
        Me.btnClear.Text = "C&lear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(415, 40)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(72, 24)
        Me.btnRefresh.TabIndex = 2
        Me.btnRefresh.Text = "&Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(347, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 13)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "Entity"
        '
        'cboEntity
        '
        Me.cboEntity.FormattingEnabled = True
        Me.cboEntity.Location = New System.Drawing.Point(393, 13)
        Me.cboEntity.Name = "cboEntity"
        Me.cboEntity.Size = New System.Drawing.Size(346, 21)
        Me.cboEntity.TabIndex = 1
        '
        'pnlButtons
        '
        Me.pnlButtons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlButtons.Controls.Add(Me.btnGenerate)
        Me.pnlButtons.Controls.Add(Me.dtpCycleTo)
        Me.pnlButtons.Controls.Add(Me.Label1)
        Me.pnlButtons.Controls.Add(Me.dtpCycleFrom)
        Me.pnlButtons.Controls.Add(Me.btnClose)
        Me.pnlButtons.Controls.Add(Me.btnClear)
        Me.pnlButtons.Controls.Add(Me.btnRefresh)
        Me.pnlButtons.Controls.Add(Me.Label4)
        Me.pnlButtons.Controls.Add(Me.Label6)
        Me.pnlButtons.Controls.Add(Me.cboEntity)
        Me.pnlButtons.Location = New System.Drawing.Point(14, 12)
        Me.pnlButtons.Name = "pnlButtons"
        Me.pnlButtons.Size = New System.Drawing.Size(754, 76)
        Me.pnlButtons.TabIndex = 0
        '
        'dtpCycleTo
        '
        Me.dtpCycleTo.CustomFormat = "dd-MM-yyyy"
        Me.dtpCycleTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpCycleTo.Location = New System.Drawing.Point(228, 13)
        Me.dtpCycleTo.Name = "dtpCycleTo"
        Me.dtpCycleTo.ShowCheckBox = True
        Me.dtpCycleTo.Size = New System.Drawing.Size(115, 21)
        Me.dtpCycleTo.TabIndex = 31
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(208, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(21, 13)
        Me.Label1.TabIndex = 30
        Me.Label1.Text = "To"
        '
        'dtpCycleFrom
        '
        Me.dtpCycleFrom.CustomFormat = "dd-MM-yyyy"
        Me.dtpCycleFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpCycleFrom.Location = New System.Drawing.Point(86, 12)
        Me.dtpCycleFrom.Name = "dtpCycleFrom"
        Me.dtpCycleFrom.ShowCheckBox = True
        Me.dtpCycleFrom.Size = New System.Drawing.Size(115, 21)
        Me.dtpCycleFrom.TabIndex = 29
        '
        'btnGenerate
        '
        Me.btnGenerate.Location = New System.Drawing.Point(491, 40)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(96, 24)
        Me.btnGenerate.TabIndex = 32
        Me.btnGenerate.Text = "&Presentation"
        Me.btnGenerate.UseVisualStyleBackColor = True
        '
        'frmGeneratePresentation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(986, 384)
        Me.Controls.Add(Me.pnlDisplay)
        Me.Controls.Add(Me.dgvReport)
        Me.Controls.Add(Me.pnlButtons)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmGeneratePresentation"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Presentation"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlDisplay.ResumeLayout(False)
        Me.pnlDisplay.PerformLayout()
        CType(Me.dgvReport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlButtons.ResumeLayout(False)
        Me.pnlButtons.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents pnlDisplay As System.Windows.Forms.Panel
    Friend WithEvents lblRecCount As System.Windows.Forms.Label
    Friend WithEvents dgvReport As System.Windows.Forms.DataGridView
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboEntity As System.Windows.Forms.ComboBox
    Friend WithEvents pnlButtons As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpCycleFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpCycleTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnGenerate As System.Windows.Forms.Button
End Class
