<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmconsolidatedReport
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
        Me.pnlButtons = New System.Windows.Forms.Panel()
        Me.txtLotNo = New System.Windows.Forms.TextBox()
        Me.lblLotno = New System.Windows.Forms.Label()
        Me.cboEntity = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.pnlDisplay = New System.Windows.Forms.Panel()
        Me.lblRecCount = New System.Windows.Forms.Label()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.dgvReport = New System.Windows.Forms.DataGridView()
        Me.pnlButtons.SuspendLayout()
        Me.pnlDisplay.SuspendLayout()
        CType(Me.dgvReport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlButtons
        '
        Me.pnlButtons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlButtons.Controls.Add(Me.txtLotNo)
        Me.pnlButtons.Controls.Add(Me.lblLotno)
        Me.pnlButtons.Controls.Add(Me.cboEntity)
        Me.pnlButtons.Controls.Add(Me.Label6)
        Me.pnlButtons.Controls.Add(Me.btnClose)
        Me.pnlButtons.Controls.Add(Me.btnClear)
        Me.pnlButtons.Controls.Add(Me.btnRefresh)
        Me.pnlButtons.Location = New System.Drawing.Point(12, 12)
        Me.pnlButtons.Name = "pnlButtons"
        Me.pnlButtons.Size = New System.Drawing.Size(752, 76)
        Me.pnlButtons.TabIndex = 1
        '
        'txtLotNo
        '
        Me.txtLotNo.Location = New System.Drawing.Point(513, 12)
        Me.txtLotNo.MaxLength = 255
        Me.txtLotNo.Name = "txtLotNo"
        Me.txtLotNo.Size = New System.Drawing.Size(228, 21)
        Me.txtLotNo.TabIndex = 20
        '
        'lblLotno
        '
        Me.lblLotno.Location = New System.Drawing.Point(428, 15)
        Me.lblLotno.Name = "lblLotno"
        Me.lblLotno.Size = New System.Drawing.Size(77, 13)
        Me.lblLotno.TabIndex = 67
        Me.lblLotno.Text = "Lot No"
        Me.lblLotno.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboEntity
        '
        Me.cboEntity.FormattingEnabled = True
        Me.cboEntity.Location = New System.Drawing.Point(59, 12)
        Me.cboEntity.Name = "cboEntity"
        Me.cboEntity.Size = New System.Drawing.Size(354, 21)
        Me.cboEntity.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(11, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 13)
        Me.Label6.TabIndex = 24
        Me.Label6.Text = "Entity"
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(669, 39)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(72, 24)
        Me.btnClose.TabIndex = 26
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(591, 39)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(72, 24)
        Me.btnClear.TabIndex = 25
        Me.btnClear.Text = "C&lear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(513, 39)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(72, 24)
        Me.btnRefresh.TabIndex = 24
        Me.btnRefresh.Text = "&Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'pnlDisplay
        '
        Me.pnlDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlDisplay.Controls.Add(Me.lblRecCount)
        Me.pnlDisplay.Controls.Add(Me.btnExport)
        Me.pnlDisplay.Location = New System.Drawing.Point(12, 213)
        Me.pnlDisplay.Name = "pnlDisplay"
        Me.pnlDisplay.Size = New System.Drawing.Size(906, 32)
        Me.pnlDisplay.TabIndex = 4
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
        Me.btnExport.Location = New System.Drawing.Point(829, 3)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(72, 24)
        Me.btnExport.TabIndex = 1
        Me.btnExport.Text = "E&xport"
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'dgvReport
        '
        Me.dgvReport.AllowUserToAddRows = False
        Me.dgvReport.AllowUserToDeleteRows = False
        Me.dgvReport.Location = New System.Drawing.Point(12, 110)
        Me.dgvReport.Name = "dgvReport"
        Me.dgvReport.ReadOnly = True
        Me.dgvReport.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dgvReport.Size = New System.Drawing.Size(906, 97)
        Me.dgvReport.TabIndex = 3
        '
        'frmconsolidatedReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(972, 414)
        Me.Controls.Add(Me.pnlDisplay)
        Me.Controls.Add(Me.dgvReport)
        Me.Controls.Add(Me.pnlButtons)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Name = "frmconsolidatedReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consolidated Report"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlButtons.ResumeLayout(False)
        Me.pnlButtons.PerformLayout()
        Me.pnlDisplay.ResumeLayout(False)
        Me.pnlDisplay.PerformLayout()
        CType(Me.dgvReport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlButtons As Panel
    Friend WithEvents txtLotNo As TextBox
    Friend WithEvents lblLotno As Label
    Friend WithEvents cboEntity As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents btnClose As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents btnRefresh As Button
    Friend WithEvents pnlDisplay As Panel
    Friend WithEvents lblRecCount As Label
    Friend WithEvents btnExport As Button
    Friend WithEvents dgvReport As DataGridView
End Class
