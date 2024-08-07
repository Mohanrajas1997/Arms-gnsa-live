<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmScanReport
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
        Me.txtMicr = New System.Windows.Forms.TextBox()
        Me.lblmicr = New System.Windows.Forms.Label()
        Me.txtScanId = New System.Windows.Forms.TextBox()
        Me.lblscanid = New System.Windows.Forms.Label()
        Me.txtBankName = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.dtpChqTo = New System.Windows.Forms.DateTimePicker()
        Me.dtpChqForm = New System.Windows.Forms.DateTimePicker()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtChqAmt = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cboEntity = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtChqNo = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtContractNo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.dgvReport = New System.Windows.Forms.DataGridView()
        Me.pnlExport = New System.Windows.Forms.Panel()
        Me.lblRecCount = New System.Windows.Forms.TextBox()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.pnlMain.SuspendLayout()
        CType(Me.dgvReport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlExport.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlMain
        '
        Me.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlMain.Controls.Add(Me.txtMicr)
        Me.pnlMain.Controls.Add(Me.lblmicr)
        Me.pnlMain.Controls.Add(Me.txtScanId)
        Me.pnlMain.Controls.Add(Me.lblscanid)
        Me.pnlMain.Controls.Add(Me.txtBankName)
        Me.pnlMain.Controls.Add(Me.Label7)
        Me.pnlMain.Controls.Add(Me.Label20)
        Me.pnlMain.Controls.Add(Me.dtpChqTo)
        Me.pnlMain.Controls.Add(Me.dtpChqForm)
        Me.pnlMain.Controls.Add(Me.Label19)
        Me.pnlMain.Controls.Add(Me.txtChqAmt)
        Me.pnlMain.Controls.Add(Me.Label13)
        Me.pnlMain.Controls.Add(Me.cboEntity)
        Me.pnlMain.Controls.Add(Me.Label6)
        Me.pnlMain.Controls.Add(Me.txtChqNo)
        Me.pnlMain.Controls.Add(Me.Label5)
        Me.pnlMain.Controls.Add(Me.txtContractNo)
        Me.pnlMain.Controls.Add(Me.Label2)
        Me.pnlMain.Controls.Add(Me.btnClose)
        Me.pnlMain.Controls.Add(Me.btnClear)
        Me.pnlMain.Controls.Add(Me.btnRefresh)
        Me.pnlMain.Location = New System.Drawing.Point(12, 12)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(906, 110)
        Me.pnlMain.TabIndex = 1
        '
        'txtMicr
        '
        Me.txtMicr.Location = New System.Drawing.Point(93, 69)
        Me.txtMicr.MaxLength = 32
        Me.txtMicr.Name = "txtMicr"
        Me.txtMicr.Size = New System.Drawing.Size(115, 21)
        Me.txtMicr.TabIndex = 77
        '
        'lblmicr
        '
        Me.lblmicr.AutoSize = True
        Me.lblmicr.Location = New System.Drawing.Point(25, 72)
        Me.lblmicr.Name = "lblmicr"
        Me.lblmicr.Size = New System.Drawing.Size(62, 13)
        Me.lblmicr.TabIndex = 78
        Me.lblmicr.Text = "Micr Code"
        Me.lblmicr.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtScanId
        '
        Me.txtScanId.AcceptsReturn = True
        Me.txtScanId.Location = New System.Drawing.Point(308, 69)
        Me.txtScanId.MaxLength = 10
        Me.txtScanId.Name = "txtScanId"
        Me.txtScanId.Size = New System.Drawing.Size(115, 21)
        Me.txtScanId.TabIndex = 21
        '
        'lblscanid
        '
        Me.lblscanid.Location = New System.Drawing.Point(231, 72)
        Me.lblscanid.Name = "lblscanid"
        Me.lblscanid.Size = New System.Drawing.Size(71, 13)
        Me.lblscanid.TabIndex = 76
        Me.lblscanid.Text = "Scan Id"
        Me.lblscanid.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtBankName
        '
        Me.txtBankName.Location = New System.Drawing.Point(774, 41)
        Me.txtBankName.MaxLength = 128
        Me.txtBankName.Name = "txtBankName"
        Me.txtBankName.Size = New System.Drawing.Size(115, 21)
        Me.txtBankName.TabIndex = 13
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(691, 44)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(77, 13)
        Me.Label7.TabIndex = 62
        Me.Label7.Text = "Bank Name"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(281, 11)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(21, 13)
        Me.Label20.TabIndex = 58
        Me.Label20.Text = "To"
        '
        'dtpChqTo
        '
        Me.dtpChqTo.CustomFormat = "dd-MM-yyyy"
        Me.dtpChqTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpChqTo.Location = New System.Drawing.Point(308, 8)
        Me.dtpChqTo.Name = "dtpChqTo"
        Me.dtpChqTo.ShowCheckBox = True
        Me.dtpChqTo.Size = New System.Drawing.Size(115, 21)
        Me.dtpChqTo.TabIndex = 7
        '
        'dtpChqForm
        '
        Me.dtpChqForm.CustomFormat = "dd-MM-yyyy"
        Me.dtpChqForm.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpChqForm.Location = New System.Drawing.Point(93, 8)
        Me.dtpChqForm.Name = "dtpChqForm"
        Me.dtpChqForm.ShowCheckBox = True
        Me.dtpChqForm.Size = New System.Drawing.Size(115, 21)
        Me.dtpChqForm.TabIndex = 6
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(9, 11)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(78, 13)
        Me.Label19.TabIndex = 55
        Me.Label19.Text = "Chq From"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtChqAmt
        '
        Me.txtChqAmt.Location = New System.Drawing.Point(535, 41)
        Me.txtChqAmt.MaxLength = 18
        Me.txtChqAmt.Name = "txtChqAmt"
        Me.txtChqAmt.Size = New System.Drawing.Size(115, 21)
        Me.txtChqAmt.TabIndex = 9
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(450, 44)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(77, 13)
        Me.Label13.TabIndex = 44
        Me.Label13.Text = "Chq Amt"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboEntity
        '
        Me.cboEntity.FormattingEnabled = True
        Me.cboEntity.Location = New System.Drawing.Point(535, 7)
        Me.cboEntity.Name = "cboEntity"
        Me.cboEntity.Size = New System.Drawing.Size(354, 21)
        Me.cboEntity.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(487, 11)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 13)
        Me.Label6.TabIndex = 24
        Me.Label6.Text = "Entity"
        '
        'txtChqNo
        '
        Me.txtChqNo.Location = New System.Drawing.Point(309, 39)
        Me.txtChqNo.MaxLength = 16
        Me.txtChqNo.Name = "txtChqNo"
        Me.txtChqNo.Size = New System.Drawing.Size(115, 21)
        Me.txtChqNo.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(225, 42)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 13)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "Chq No"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtContractNo
        '
        Me.txtContractNo.Location = New System.Drawing.Point(93, 39)
        Me.txtContractNo.MaxLength = 32
        Me.txtContractNo.Name = "txtContractNo"
        Me.txtContractNo.Size = New System.Drawing.Size(115, 21)
        Me.txtContractNo.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 13)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Contract No"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(817, 72)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(72, 24)
        Me.btnClose.TabIndex = 26
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(739, 72)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(72, 24)
        Me.btnClear.TabIndex = 25
        Me.btnClear.Text = "C&lear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(661, 72)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(72, 24)
        Me.btnRefresh.TabIndex = 24
        Me.btnRefresh.Text = "&Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'dgvReport
        '
        Me.dgvReport.AllowUserToAddRows = False
        Me.dgvReport.AllowUserToDeleteRows = False
        Me.dgvReport.Location = New System.Drawing.Point(10, 270)
        Me.dgvReport.Name = "dgvReport"
        Me.dgvReport.ReadOnly = True
        Me.dgvReport.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dgvReport.Size = New System.Drawing.Size(906, 97)
        Me.dgvReport.TabIndex = 3
        '
        'pnlExport
        '
        Me.pnlExport.Controls.Add(Me.lblRecCount)
        Me.pnlExport.Controls.Add(Me.btnExport)
        Me.pnlExport.Location = New System.Drawing.Point(12, 373)
        Me.pnlExport.Name = "pnlExport"
        Me.pnlExport.Size = New System.Drawing.Size(890, 33)
        Me.pnlExport.TabIndex = 5
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
        'frmScanReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(972, 414)
        Me.Controls.Add(Me.pnlExport)
        Me.Controls.Add(Me.dgvReport)
        Me.Controls.Add(Me.pnlMain)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Name = "frmScanReport"
        Me.Text = "Scan Report"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlMain.ResumeLayout(False)
        Me.pnlMain.PerformLayout()
        CType(Me.dgvReport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlExport.ResumeLayout(False)
        Me.pnlExport.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlMain As Panel
    Friend WithEvents txtScanId As TextBox
    Friend WithEvents lblscanid As Label
    Friend WithEvents txtBankName As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents dtpChqTo As DateTimePicker
    Friend WithEvents dtpChqForm As DateTimePicker
    Friend WithEvents Label19 As Label
    Friend WithEvents txtChqAmt As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents cboEntity As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtChqNo As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtContractNo As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnClose As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents btnRefresh As Button
    Friend WithEvents dgvReport As DataGridView
    Friend WithEvents txtMicr As TextBox
    Friend WithEvents lblmicr As Label
    Friend WithEvents pnlExport As Panel
    Friend WithEvents lblRecCount As TextBox
    Friend WithEvents btnExport As Button
End Class
