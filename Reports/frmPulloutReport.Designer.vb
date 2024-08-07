<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPulloutReport
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
        Me.txtPulloutReason = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.dtpChqTo = New System.Windows.Forms.DateTimePicker()
        Me.dtpChqForm = New System.Windows.Forms.DateTimePicker()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtChqId = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtPulloutId = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtChqAmt = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cboEntity = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtChqNo = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpImportTo = New System.Windows.Forms.DateTimePicker()
        Me.dtpImportFrom = New System.Windows.Forms.DateTimePicker()
        Me.txtContractNo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.cboFileName = New System.Windows.Forms.ComboBox()
        Me.lbl1 = New System.Windows.Forms.Label()
        Me.pnlDisplay = New System.Windows.Forms.Panel()
        Me.lblRecCount = New System.Windows.Forms.Label()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.dgvReport = New System.Windows.Forms.DataGridView()
        Me.pnlButtons = New System.Windows.Forms.Panel()
        Me.pnlDisplay.SuspendLayout()
        CType(Me.dgvReport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlButtons.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtPulloutReason
        '
        Me.txtPulloutReason.Location = New System.Drawing.Point(93, 116)
        Me.txtPulloutReason.MaxLength = 255
        Me.txtPulloutReason.Name = "txtPulloutReason"
        Me.txtPulloutReason.Size = New System.Drawing.Size(342, 21)
        Me.txtPulloutReason.TabIndex = 11
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(-14, 119)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(105, 13)
        Me.Label14.TabIndex = 61
        Me.Label14.Text = "Pullout Reason"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(293, 38)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(21, 13)
        Me.Label20.TabIndex = 58
        Me.Label20.Text = "To"
        '
        'dtpChqTo
        '
        Me.dtpChqTo.CustomFormat = "dd-MM-yyyy"
        Me.dtpChqTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpChqTo.Location = New System.Drawing.Point(324, 35)
        Me.dtpChqTo.Name = "dtpChqTo"
        Me.dtpChqTo.ShowCheckBox = True
        Me.dtpChqTo.Size = New System.Drawing.Size(111, 21)
        Me.dtpChqTo.TabIndex = 4
        '
        'dtpChqForm
        '
        Me.dtpChqForm.CustomFormat = "dd-MM-yyyy"
        Me.dtpChqForm.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpChqForm.Location = New System.Drawing.Point(93, 35)
        Me.dtpChqForm.Name = "dtpChqForm"
        Me.dtpChqForm.ShowCheckBox = True
        Me.dtpChqForm.Size = New System.Drawing.Size(111, 21)
        Me.dtpChqForm.TabIndex = 3
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(9, 38)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(78, 13)
        Me.Label19.TabIndex = 55
        Me.Label19.Text = "Chq From"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtChqId
        '
        Me.txtChqId.AcceptsReturn = True
        Me.txtChqId.Location = New System.Drawing.Point(93, 89)
        Me.txtChqId.MaxLength = 10
        Me.txtChqId.Name = "txtChqId"
        Me.txtChqId.Size = New System.Drawing.Size(111, 21)
        Me.txtChqId.TabIndex = 9
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(16, 92)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(71, 13)
        Me.Label16.TabIndex = 52
        Me.Label16.Text = "Chq Id"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtPulloutId
        '
        Me.txtPulloutId.Location = New System.Drawing.Point(324, 89)
        Me.txtPulloutId.MaxLength = 10
        Me.txtPulloutId.Name = "txtPulloutId"
        Me.txtPulloutId.Size = New System.Drawing.Size(111, 21)
        Me.txtPulloutId.TabIndex = 10
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(228, 92)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(86, 13)
        Me.Label17.TabIndex = 50
        Me.Label17.Text = "Pullout Id"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtChqAmt
        '
        Me.txtChqAmt.Location = New System.Drawing.Point(775, 62)
        Me.txtChqAmt.MaxLength = 18
        Me.txtChqAmt.Name = "txtChqAmt"
        Me.txtChqAmt.Size = New System.Drawing.Size(111, 21)
        Me.txtChqAmt.TabIndex = 8
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(676, 68)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(83, 13)
        Me.Label13.TabIndex = 44
        Me.Label13.Text = "Chq Amt"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboStatus
        '
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Location = New System.Drawing.Point(536, 89)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(350, 21)
        Me.cboStatus.TabIndex = 12
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(486, 92)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(44, 13)
        Me.Label9.TabIndex = 30
        Me.Label9.Text = "Status"
        '
        'cboEntity
        '
        Me.cboEntity.FormattingEnabled = True
        Me.cboEntity.Location = New System.Drawing.Point(536, 35)
        Me.cboEntity.Name = "cboEntity"
        Me.cboEntity.Size = New System.Drawing.Size(350, 21)
        Me.cboEntity.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(488, 38)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 13)
        Me.Label6.TabIndex = 24
        Me.Label6.Text = "Entity"
        '
        'txtChqNo
        '
        Me.txtChqNo.Location = New System.Drawing.Point(536, 62)
        Me.txtChqNo.MaxLength = 16
        Me.txtChqNo.Name = "txtChqNo"
        Me.txtChqNo.Size = New System.Drawing.Size(111, 21)
        Me.txtChqNo.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(471, 65)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 13)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "Chq No"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(293, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(21, 13)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "To"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 11)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 13)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Import From"
        '
        'dtpImportTo
        '
        Me.dtpImportTo.CustomFormat = "dd-MM-yyyy"
        Me.dtpImportTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpImportTo.Location = New System.Drawing.Point(324, 8)
        Me.dtpImportTo.Name = "dtpImportTo"
        Me.dtpImportTo.ShowCheckBox = True
        Me.dtpImportTo.Size = New System.Drawing.Size(111, 21)
        Me.dtpImportTo.TabIndex = 1
        '
        'dtpImportFrom
        '
        Me.dtpImportFrom.CustomFormat = "dd-MM-yyyy"
        Me.dtpImportFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpImportFrom.Location = New System.Drawing.Point(93, 8)
        Me.dtpImportFrom.Name = "dtpImportFrom"
        Me.dtpImportFrom.ShowCheckBox = True
        Me.dtpImportFrom.Size = New System.Drawing.Size(111, 21)
        Me.dtpImportFrom.TabIndex = 0
        '
        'txtContractNo
        '
        Me.txtContractNo.Location = New System.Drawing.Point(93, 62)
        Me.txtContractNo.MaxLength = 32
        Me.txtContractNo.Name = "txtContractNo"
        Me.txtContractNo.Size = New System.Drawing.Size(342, 21)
        Me.txtContractNo.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 13)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Contract No"
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(814, 119)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(72, 24)
        Me.btnClose.TabIndex = 15
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(736, 119)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(72, 24)
        Me.btnClear.TabIndex = 14
        Me.btnClear.Text = "C&lear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(658, 119)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(72, 24)
        Me.btnRefresh.TabIndex = 13
        Me.btnRefresh.Text = "&Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'cboFileName
        '
        Me.cboFileName.FormattingEnabled = True
        Me.cboFileName.Location = New System.Drawing.Point(536, 8)
        Me.cboFileName.Name = "cboFileName"
        Me.cboFileName.Size = New System.Drawing.Size(350, 21)
        Me.cboFileName.TabIndex = 2
        '
        'lbl1
        '
        Me.lbl1.AutoSize = True
        Me.lbl1.Location = New System.Drawing.Point(468, 11)
        Me.lbl1.Name = "lbl1"
        Me.lbl1.Size = New System.Drawing.Size(61, 13)
        Me.lbl1.TabIndex = 2
        Me.lbl1.Text = "File Name"
        '
        'pnlDisplay
        '
        Me.pnlDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlDisplay.Controls.Add(Me.lblRecCount)
        Me.pnlDisplay.Controls.Add(Me.btnExport)
        Me.pnlDisplay.Location = New System.Drawing.Point(13, 307)
        Me.pnlDisplay.Name = "pnlDisplay"
        Me.pnlDisplay.Size = New System.Drawing.Size(900, 32)
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
        Me.btnExport.Location = New System.Drawing.Point(823, 3)
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
        Me.dgvReport.Location = New System.Drawing.Point(13, 172)
        Me.dgvReport.Name = "dgvReport"
        Me.dgvReport.ReadOnly = True
        Me.dgvReport.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dgvReport.Size = New System.Drawing.Size(900, 129)
        Me.dgvReport.TabIndex = 1
        '
        'pnlButtons
        '
        Me.pnlButtons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlButtons.Controls.Add(Me.txtPulloutReason)
        Me.pnlButtons.Controls.Add(Me.Label14)
        Me.pnlButtons.Controls.Add(Me.Label20)
        Me.pnlButtons.Controls.Add(Me.dtpChqTo)
        Me.pnlButtons.Controls.Add(Me.dtpChqForm)
        Me.pnlButtons.Controls.Add(Me.Label19)
        Me.pnlButtons.Controls.Add(Me.txtChqId)
        Me.pnlButtons.Controls.Add(Me.Label16)
        Me.pnlButtons.Controls.Add(Me.txtPulloutId)
        Me.pnlButtons.Controls.Add(Me.Label17)
        Me.pnlButtons.Controls.Add(Me.txtChqAmt)
        Me.pnlButtons.Controls.Add(Me.Label13)
        Me.pnlButtons.Controls.Add(Me.cboStatus)
        Me.pnlButtons.Controls.Add(Me.Label9)
        Me.pnlButtons.Controls.Add(Me.cboEntity)
        Me.pnlButtons.Controls.Add(Me.Label6)
        Me.pnlButtons.Controls.Add(Me.txtChqNo)
        Me.pnlButtons.Controls.Add(Me.Label5)
        Me.pnlButtons.Controls.Add(Me.Label3)
        Me.pnlButtons.Controls.Add(Me.Label4)
        Me.pnlButtons.Controls.Add(Me.dtpImportTo)
        Me.pnlButtons.Controls.Add(Me.dtpImportFrom)
        Me.pnlButtons.Controls.Add(Me.txtContractNo)
        Me.pnlButtons.Controls.Add(Me.Label2)
        Me.pnlButtons.Controls.Add(Me.btnClose)
        Me.pnlButtons.Controls.Add(Me.btnClear)
        Me.pnlButtons.Controls.Add(Me.btnRefresh)
        Me.pnlButtons.Controls.Add(Me.cboFileName)
        Me.pnlButtons.Controls.Add(Me.lbl1)
        Me.pnlButtons.Location = New System.Drawing.Point(13, 14)
        Me.pnlButtons.Name = "pnlButtons"
        Me.pnlButtons.Size = New System.Drawing.Size(900, 152)
        Me.pnlButtons.TabIndex = 0
        '
        'frmPulloutReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(924, 353)
        Me.Controls.Add(Me.pnlDisplay)
        Me.Controls.Add(Me.dgvReport)
        Me.Controls.Add(Me.pnlButtons)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmPulloutReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pullout Report"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlDisplay.ResumeLayout(False)
        Me.pnlDisplay.PerformLayout()
        CType(Me.dgvReport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlButtons.ResumeLayout(False)
        Me.pnlButtons.PerformLayout()
    End Sub

    Friend WithEvents txtPulloutReason As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents dtpChqTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpChqForm As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtChqId As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtPulloutId As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtChqAmt As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboEntity As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtChqNo As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpImportTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpImportFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtContractNo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents cboFileName As System.Windows.Forms.ComboBox
    Friend WithEvents lbl1 As System.Windows.Forms.Label
    Friend WithEvents pnlDisplay As System.Windows.Forms.Panel
    Friend WithEvents lblRecCount As System.Windows.Forms.Label
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents dgvReport As System.Windows.Forms.DataGridView
    Friend WithEvents pnlButtons As System.Windows.Forms.Panel
End Class
