<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBatchReport
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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpCycleTo = New System.Windows.Forms.DateTimePicker()
        Me.dtpCycleFrom = New System.Windows.Forms.DateTimePicker()
        Me.cboProductCode = New System.Windows.Forms.ComboBox()
        Me.lbl1 = New System.Windows.Forms.Label()
        Me.cboEntity = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.dgvReport = New System.Windows.Forms.DataGridView()
        Me.pnlButtons = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpBatchFrom = New System.Windows.Forms.DateTimePicker()
        Me.dtpBatchTo = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pnlDisplay = New System.Windows.Forms.Panel()
        Me.lblRecCount = New System.Windows.Forms.Label()
        Me.btnExport = New System.Windows.Forms.Button()
        CType(Me.dgvReport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlButtons.SuspendLayout()
        Me.pnlDisplay.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(241, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "Cycle To"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 13)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "Cycle From"
        '
        'dtpCycleTo
        '
        Me.dtpCycleTo.CustomFormat = "dd-MM-yyyy"
        Me.dtpCycleTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpCycleTo.Location = New System.Drawing.Point(301, 13)
        Me.dtpCycleTo.Name = "dtpCycleTo"
        Me.dtpCycleTo.ShowCheckBox = True
        Me.dtpCycleTo.Size = New System.Drawing.Size(111, 21)
        Me.dtpCycleTo.TabIndex = 1
        '
        'dtpCycleFrom
        '
        Me.dtpCycleFrom.CustomFormat = "dd-MM-yyyy"
        Me.dtpCycleFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpCycleFrom.Location = New System.Drawing.Point(86, 13)
        Me.dtpCycleFrom.Name = "dtpCycleFrom"
        Me.dtpCycleFrom.ShowCheckBox = True
        Me.dtpCycleFrom.Size = New System.Drawing.Size(111, 21)
        Me.dtpCycleFrom.TabIndex = 0
        '
        'cboProductCode
        '
        Me.cboProductCode.FormattingEnabled = True
        Me.cboProductCode.Location = New System.Drawing.Point(497, 40)
        Me.cboProductCode.Name = "cboProductCode"
        Me.cboProductCode.Size = New System.Drawing.Size(315, 21)
        Me.cboProductCode.TabIndex = 5
        '
        'lbl1
        '
        Me.lbl1.AutoSize = True
        Me.lbl1.Location = New System.Drawing.Point(440, 43)
        Me.lbl1.Name = "lbl1"
        Me.lbl1.Size = New System.Drawing.Size(51, 13)
        Me.lbl1.TabIndex = 24
        Me.lbl1.Text = "Product"
        '
        'cboEntity
        '
        Me.cboEntity.FormattingEnabled = True
        Me.cboEntity.Location = New System.Drawing.Point(497, 13)
        Me.cboEntity.Name = "cboEntity"
        Me.cboEntity.Size = New System.Drawing.Size(315, 21)
        Me.cboEntity.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(451, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 13)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "Entity"
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(740, 67)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(72, 24)
        Me.btnClose.TabIndex = 8
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(662, 67)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(72, 24)
        Me.btnClear.TabIndex = 7
        Me.btnClear.Text = "C&lear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(584, 67)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(72, 24)
        Me.btnRefresh.TabIndex = 6
        Me.btnRefresh.Text = "&Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'dgvReport
        '
        Me.dgvReport.AllowUserToAddRows = False
        Me.dgvReport.AllowUserToDeleteRows = False
        Me.dgvReport.Location = New System.Drawing.Point(12, 120)
        Me.dgvReport.Name = "dgvReport"
        Me.dgvReport.ReadOnly = True
        Me.dgvReport.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dgvReport.Size = New System.Drawing.Size(823, 97)
        Me.dgvReport.TabIndex = 1
        '
        'pnlButtons
        '
        Me.pnlButtons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlButtons.Controls.Add(Me.Label1)
        Me.pnlButtons.Controls.Add(Me.dtpBatchFrom)
        Me.pnlButtons.Controls.Add(Me.dtpBatchTo)
        Me.pnlButtons.Controls.Add(Me.Label2)
        Me.pnlButtons.Controls.Add(Me.cboProductCode)
        Me.pnlButtons.Controls.Add(Me.lbl1)
        Me.pnlButtons.Controls.Add(Me.Label3)
        Me.pnlButtons.Controls.Add(Me.btnClose)
        Me.pnlButtons.Controls.Add(Me.dtpCycleFrom)
        Me.pnlButtons.Controls.Add(Me.btnClear)
        Me.pnlButtons.Controls.Add(Me.dtpCycleTo)
        Me.pnlButtons.Controls.Add(Me.btnRefresh)
        Me.pnlButtons.Controls.Add(Me.Label4)
        Me.pnlButtons.Controls.Add(Me.Label6)
        Me.pnlButtons.Controls.Add(Me.cboEntity)
        Me.pnlButtons.Location = New System.Drawing.Point(12, 12)
        Me.pnlButtons.Name = "pnlButtons"
        Me.pnlButtons.Size = New System.Drawing.Size(823, 102)
        Me.pnlButtons.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(239, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "Batch To"
        '
        'dtpBatchFrom
        '
        Me.dtpBatchFrom.CustomFormat = "dd-MM-yyyy"
        Me.dtpBatchFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpBatchFrom.Location = New System.Drawing.Point(86, 37)
        Me.dtpBatchFrom.Name = "dtpBatchFrom"
        Me.dtpBatchFrom.ShowCheckBox = True
        Me.dtpBatchFrom.Size = New System.Drawing.Size(111, 21)
        Me.dtpBatchFrom.TabIndex = 3
        '
        'dtpBatchTo
        '
        Me.dtpBatchTo.CustomFormat = "dd-MM-yyyy"
        Me.dtpBatchTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpBatchTo.Location = New System.Drawing.Point(301, 37)
        Me.dtpBatchTo.Name = "dtpBatchTo"
        Me.dtpBatchTo.ShowCheckBox = True
        Me.dtpBatchTo.Size = New System.Drawing.Size(111, 21)
        Me.dtpBatchTo.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 13)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "Batch From"
        '
        'pnlDisplay
        '
        Me.pnlDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlDisplay.Controls.Add(Me.lblRecCount)
        Me.pnlDisplay.Controls.Add(Me.btnExport)
        Me.pnlDisplay.Location = New System.Drawing.Point(12, 223)
        Me.pnlDisplay.Name = "pnlDisplay"
        Me.pnlDisplay.Size = New System.Drawing.Size(823, 32)
        Me.pnlDisplay.TabIndex = 2
        '
        'lblRecCount
        '
        Me.lblRecCount.AutoSize = True
        Me.lblRecCount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblRecCount.Location = New System.Drawing.Point(8, 8)
        Me.lblRecCount.Name = "lblRecCount"
        Me.lblRecCount.Size = New System.Drawing.Size(83, 13)
        Me.lblRecCount.TabIndex = 0
        Me.lblRecCount.Text = "Record Count"
        '
        'btnExport
        '
        Me.btnExport.Location = New System.Drawing.Point(746, 3)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(72, 24)
        Me.btnExport.TabIndex = 1
        Me.btnExport.Text = "E&xport"
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'frmBatchReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(848, 268)
        Me.Controls.Add(Me.pnlDisplay)
        Me.Controls.Add(Me.pnlButtons)
        Me.Controls.Add(Me.dgvReport)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmBatchReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Trax Dispatch Report"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgvReport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlButtons.ResumeLayout(False)
        Me.pnlButtons.PerformLayout()
        Me.pnlDisplay.ResumeLayout(False)
        Me.pnlDisplay.PerformLayout()
    End Sub

    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpCycleTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpCycleFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboProductCode As System.Windows.Forms.ComboBox
    Friend WithEvents lbl1 As System.Windows.Forms.Label
    Friend WithEvents cboEntity As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents dgvReport As System.Windows.Forms.DataGridView
    Friend WithEvents pnlButtons As System.Windows.Forms.Panel
    Friend WithEvents pnlDisplay As System.Windows.Forms.Panel
    Friend WithEvents lblRecCount As System.Windows.Forms.Label
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpBatchFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpBatchTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
