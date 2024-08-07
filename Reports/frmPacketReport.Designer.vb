<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPacketReport
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
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtPacketNo = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtContractNo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboEntity = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpImportTo = New System.Windows.Forms.DateTimePicker()
        Me.dtpImportFrom = New System.Windows.Forms.DateTimePicker()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.dgvReport = New System.Windows.Forms.DataGridView()
        Me.pnlExport = New System.Windows.Forms.Panel()
        Me.lblRecCount = New System.Windows.Forms.TextBox()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.txtLotNo = New System.Windows.Forms.TextBox()
        Me.lblLotNo = New System.Windows.Forms.Label()
        Me.pnlMain.SuspendLayout()
        CType(Me.dgvReport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlExport.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlMain
        '
        Me.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlMain.Controls.Add(Me.txtLotNo)
        Me.pnlMain.Controls.Add(Me.lblLotNo)
        Me.pnlMain.Controls.Add(Me.cboStatus)
        Me.pnlMain.Controls.Add(Me.Label9)
        Me.pnlMain.Controls.Add(Me.txtPacketNo)
        Me.pnlMain.Controls.Add(Me.Label16)
        Me.pnlMain.Controls.Add(Me.txtContractNo)
        Me.pnlMain.Controls.Add(Me.Label2)
        Me.pnlMain.Controls.Add(Me.cboEntity)
        Me.pnlMain.Controls.Add(Me.Label6)
        Me.pnlMain.Controls.Add(Me.Label3)
        Me.pnlMain.Controls.Add(Me.Label4)
        Me.pnlMain.Controls.Add(Me.dtpImportTo)
        Me.pnlMain.Controls.Add(Me.dtpImportFrom)
        Me.pnlMain.Controls.Add(Me.btnClose)
        Me.pnlMain.Controls.Add(Me.btnClear)
        Me.pnlMain.Controls.Add(Me.btnRefresh)
        Me.pnlMain.Location = New System.Drawing.Point(7, 8)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(903, 103)
        Me.pnlMain.TabIndex = 1
        '
        'cboStatus
        '
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Location = New System.Drawing.Point(535, 38)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(199, 21)
        Me.cboStatus.TabIndex = 57
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(483, 41)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(44, 13)
        Me.Label9.TabIndex = 58
        Me.Label9.Text = "Status"
        '
        'txtPacketNo
        '
        Me.txtPacketNo.AcceptsReturn = True
        Me.txtPacketNo.Location = New System.Drawing.Point(308, 38)
        Me.txtPacketNo.MaxLength = 64
        Me.txtPacketNo.Name = "txtPacketNo"
        Me.txtPacketNo.Size = New System.Drawing.Size(115, 21)
        Me.txtPacketNo.TabIndex = 54
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(231, 41)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(71, 13)
        Me.Label16.TabIndex = 56
        Me.Label16.Text = "Packet No"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtContractNo
        '
        Me.txtContractNo.Location = New System.Drawing.Point(93, 38)
        Me.txtContractNo.MaxLength = 32
        Me.txtContractNo.Name = "txtContractNo"
        Me.txtContractNo.Size = New System.Drawing.Size(115, 21)
        Me.txtContractNo.TabIndex = 53
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 13)
        Me.Label2.TabIndex = 55
        Me.Label2.Text = "Contract No"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboEntity
        '
        Me.cboEntity.FormattingEnabled = True
        Me.cboEntity.Location = New System.Drawing.Point(535, 8)
        Me.cboEntity.Name = "cboEntity"
        Me.cboEntity.Size = New System.Drawing.Size(354, 21)
        Me.cboEntity.TabIndex = 27
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(487, 11)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 13)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "Entity"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(281, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(21, 13)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "To"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 11)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 13)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "Import From"
        '
        'dtpImportTo
        '
        Me.dtpImportTo.CustomFormat = "dd-MM-yyyy"
        Me.dtpImportTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpImportTo.Location = New System.Drawing.Point(308, 8)
        Me.dtpImportTo.Name = "dtpImportTo"
        Me.dtpImportTo.ShowCheckBox = True
        Me.dtpImportTo.Size = New System.Drawing.Size(115, 21)
        Me.dtpImportTo.TabIndex = 22
        '
        'dtpImportFrom
        '
        Me.dtpImportFrom.CustomFormat = "dd-MM-yyyy"
        Me.dtpImportFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpImportFrom.Location = New System.Drawing.Point(93, 8)
        Me.dtpImportFrom.Name = "dtpImportFrom"
        Me.dtpImportFrom.ShowCheckBox = True
        Me.dtpImportFrom.Size = New System.Drawing.Size(115, 21)
        Me.dtpImportFrom.TabIndex = 21
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(818, 68)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(72, 24)
        Me.btnClose.TabIndex = 5
        Me.btnClose.Text = "&Close"
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(740, 68)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(72, 24)
        Me.btnClear.TabIndex = 4
        Me.btnClear.Text = "C&lear"
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(662, 68)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(72, 24)
        Me.btnRefresh.TabIndex = 3
        Me.btnRefresh.Text = "&Refresh"
        '
        'dgvReport
        '
        Me.dgvReport.AllowUserToAddRows = False
        Me.dgvReport.AllowUserToDeleteRows = False
        Me.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvReport.Location = New System.Drawing.Point(7, 250)
        Me.dgvReport.Name = "dgvReport"
        Me.dgvReport.ReadOnly = True
        Me.dgvReport.Size = New System.Drawing.Size(903, 57)
        Me.dgvReport.TabIndex = 3
        '
        'pnlExport
        '
        Me.pnlExport.Controls.Add(Me.lblRecCount)
        Me.pnlExport.Controls.Add(Me.btnExport)
        Me.pnlExport.Location = New System.Drawing.Point(7, 313)
        Me.pnlExport.Name = "pnlExport"
        Me.pnlExport.Size = New System.Drawing.Size(890, 33)
        Me.pnlExport.TabIndex = 4
        '
        'lblRecCount
        '
        Me.lblRecCount.BackColor = System.Drawing.SystemColors.Control
        Me.lblRecCount.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblRecCount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblRecCount.Location = New System.Drawing.Point(6, 8)
        Me.lblRecCount.MaxLength = 100
        Me.lblRecCount.Name = "lblRecCount"
        Me.lblRecCount.ReadOnly = True
        Me.lblRecCount.Size = New System.Drawing.Size(433, 14)
        Me.lblRecCount.TabIndex = 0
        Me.lblRecCount.TabStop = False
        Me.lblRecCount.Text = "Record Count : "
        '
        'btnExport
        '
        Me.btnExport.Location = New System.Drawing.Point(814, 5)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(72, 24)
        Me.btnExport.TabIndex = 1
        Me.btnExport.Text = "&Export"
        '
        'txtLotNo
        '
        Me.txtLotNo.AcceptsReturn = True
        Me.txtLotNo.Location = New System.Drawing.Point(797, 38)
        Me.txtLotNo.MaxLength = 64
        Me.txtLotNo.Name = "txtLotNo"
        Me.txtLotNo.Size = New System.Drawing.Size(92, 21)
        Me.txtLotNo.TabIndex = 59
        '
        'lblLotNo
        '
        Me.lblLotNo.Location = New System.Drawing.Point(740, 41)
        Me.lblLotNo.Name = "lblLotNo"
        Me.lblLotNo.Size = New System.Drawing.Size(51, 13)
        Me.lblLotNo.TabIndex = 60
        Me.lblLotNo.Text = "Lot No"
        Me.lblLotNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmPacketReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(922, 354)
        Me.Controls.Add(Me.dgvReport)
        Me.Controls.Add(Me.pnlExport)
        Me.Controls.Add(Me.pnlMain)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Name = "frmPacketReport"
        Me.Text = "Packet Report"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlMain.ResumeLayout(False)
        Me.pnlMain.PerformLayout()
        CType(Me.dgvReport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlExport.ResumeLayout(False)
        Me.pnlExport.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlMain As Panel
    Friend WithEvents btnClose As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents btnRefresh As Button
    Friend WithEvents dgvReport As DataGridView
    Friend WithEvents pnlExport As Panel
    Friend WithEvents lblRecCount As TextBox
    Friend WithEvents btnExport As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents dtpImportTo As DateTimePicker
    Friend WithEvents dtpImportFrom As DateTimePicker
    Friend WithEvents cboEntity As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtPacketNo As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents txtContractNo As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cboStatus As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtLotNo As TextBox
    Friend WithEvents lblLotNo As Label
End Class
