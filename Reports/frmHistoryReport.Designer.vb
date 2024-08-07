<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHistoryReport
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
        Me.pnlDisplay = New System.Windows.Forms.Panel()
        Me.lblRecCount = New System.Windows.Forms.Label()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.dgvReport = New System.Windows.Forms.DataGridView()
        Me.pnlButtons = New System.Windows.Forms.Panel()
        Me.chkChqAmt = New System.Windows.Forms.CheckBox()
        Me.chkContractNo = New System.Windows.Forms.CheckBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.ChkChqNoQry = New System.Windows.Forms.CheckBox()
        Me.txtMicrCode = New System.Windows.Forms.TextBox()
        Me.lblMicrcode = New System.Windows.Forms.Label()
        Me.cboProduct = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.txtShelfNo = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtAccountNo = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.dtpChqTo = New System.Windows.Forms.DateTimePicker()
        Me.dtpChqForm = New System.Windows.Forms.DateTimePicker()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtBoxNo = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtChqAmt = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.dtpCycleTo = New System.Windows.Forms.DateTimePicker()
        Me.dtpCycleFrom = New System.Windows.Forms.DateTimePicker()
        Me.cboEntity = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtChqNo = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtContractNo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.cboFileName = New System.Windows.Forms.ComboBox()
        Me.lbl1 = New System.Windows.Forms.Label()
        Me.pnlDisplay.SuspendLayout()
        CType(Me.dgvReport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlButtons.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlDisplay
        '
        Me.pnlDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlDisplay.Controls.Add(Me.lblRecCount)
        Me.pnlDisplay.Controls.Add(Me.btnExport)
        Me.pnlDisplay.Location = New System.Drawing.Point(12, 360)
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
        Me.dgvReport.Location = New System.Drawing.Point(12, 257)
        Me.dgvReport.Name = "dgvReport"
        Me.dgvReport.ReadOnly = True
        Me.dgvReport.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dgvReport.Size = New System.Drawing.Size(906, 97)
        Me.dgvReport.TabIndex = 3
        '
        'pnlButtons
        '
        Me.pnlButtons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlButtons.Controls.Add(Me.chkChqAmt)
        Me.pnlButtons.Controls.Add(Me.chkContractNo)
        Me.pnlButtons.Controls.Add(Me.Label25)
        Me.pnlButtons.Controls.Add(Me.ChkChqNoQry)
        Me.pnlButtons.Controls.Add(Me.txtMicrCode)
        Me.pnlButtons.Controls.Add(Me.lblMicrcode)
        Me.pnlButtons.Controls.Add(Me.cboProduct)
        Me.pnlButtons.Controls.Add(Me.Label18)
        Me.pnlButtons.Controls.Add(Me.txtStatus)
        Me.pnlButtons.Controls.Add(Me.lblStatus)
        Me.pnlButtons.Controls.Add(Me.txtShelfNo)
        Me.pnlButtons.Controls.Add(Me.Label12)
        Me.pnlButtons.Controls.Add(Me.txtAccountNo)
        Me.pnlButtons.Controls.Add(Me.Label14)
        Me.pnlButtons.Controls.Add(Me.Label20)
        Me.pnlButtons.Controls.Add(Me.dtpChqTo)
        Me.pnlButtons.Controls.Add(Me.dtpChqForm)
        Me.pnlButtons.Controls.Add(Me.Label19)
        Me.pnlButtons.Controls.Add(Me.txtBoxNo)
        Me.pnlButtons.Controls.Add(Me.Label17)
        Me.pnlButtons.Controls.Add(Me.txtChqAmt)
        Me.pnlButtons.Controls.Add(Me.Label13)
        Me.pnlButtons.Controls.Add(Me.Label10)
        Me.pnlButtons.Controls.Add(Me.Label11)
        Me.pnlButtons.Controls.Add(Me.dtpCycleTo)
        Me.pnlButtons.Controls.Add(Me.dtpCycleFrom)
        Me.pnlButtons.Controls.Add(Me.cboEntity)
        Me.pnlButtons.Controls.Add(Me.Label6)
        Me.pnlButtons.Controls.Add(Me.txtChqNo)
        Me.pnlButtons.Controls.Add(Me.Label5)
        Me.pnlButtons.Controls.Add(Me.txtContractNo)
        Me.pnlButtons.Controls.Add(Me.Label2)
        Me.pnlButtons.Controls.Add(Me.btnClose)
        Me.pnlButtons.Controls.Add(Me.btnClear)
        Me.pnlButtons.Controls.Add(Me.btnRefresh)
        Me.pnlButtons.Controls.Add(Me.cboFileName)
        Me.pnlButtons.Controls.Add(Me.lbl1)
        Me.pnlButtons.Location = New System.Drawing.Point(12, 12)
        Me.pnlButtons.Name = "pnlButtons"
        Me.pnlButtons.Size = New System.Drawing.Size(906, 163)
        Me.pnlButtons.TabIndex = 5
        '
        'chkChqAmt
        '
        Me.chkChqAmt.AutoSize = True
        Me.chkChqAmt.Location = New System.Drawing.Point(476, 124)
        Me.chkChqAmt.Name = "chkChqAmt"
        Me.chkChqAmt.Size = New System.Drawing.Size(74, 17)
        Me.chkChqAmt.TabIndex = 84
        Me.chkChqAmt.Text = "Chq Amt"
        Me.chkChqAmt.UseVisualStyleBackColor = True
        '
        'chkContractNo
        '
        Me.chkContractNo.AutoSize = True
        Me.chkContractNo.Location = New System.Drawing.Point(378, 124)
        Me.chkContractNo.Name = "chkContractNo"
        Me.chkContractNo.Size = New System.Drawing.Size(92, 17)
        Me.chkContractNo.TabIndex = 83
        Me.chkContractNo.Text = "Contract No"
        Me.chkContractNo.UseVisualStyleBackColor = True
        '
        'Label25
        '
        Me.Label25.Location = New System.Drawing.Point(238, 124)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(64, 13)
        Me.Label25.TabIndex = 85
        Me.Label25.Text = "Query"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ChkChqNoQry
        '
        Me.ChkChqNoQry.AutoSize = True
        Me.ChkChqNoQry.Location = New System.Drawing.Point(308, 124)
        Me.ChkChqNoQry.Name = "ChkChqNoQry"
        Me.ChkChqNoQry.Size = New System.Drawing.Size(64, 17)
        Me.ChkChqNoQry.TabIndex = 82
        Me.ChkChqNoQry.Text = "Chq No"
        Me.ChkChqNoQry.UseVisualStyleBackColor = True
        '
        'txtMicrCode
        '
        Me.txtMicrCode.Location = New System.Drawing.Point(774, 65)
        Me.txtMicrCode.MaxLength = 128
        Me.txtMicrCode.Name = "txtMicrCode"
        Me.txtMicrCode.Size = New System.Drawing.Size(115, 21)
        Me.txtMicrCode.TabIndex = 73
        '
        'lblMicrcode
        '
        Me.lblMicrcode.Location = New System.Drawing.Point(691, 68)
        Me.lblMicrcode.Name = "lblMicrcode"
        Me.lblMicrcode.Size = New System.Drawing.Size(77, 13)
        Me.lblMicrcode.TabIndex = 74
        Me.lblMicrcode.Text = "Micr Code"
        Me.lblMicrcode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboProduct
        '
        Me.cboProduct.FormattingEnabled = True
        Me.cboProduct.Location = New System.Drawing.Point(310, 93)
        Me.cboProduct.Name = "cboProduct"
        Me.cboProduct.Size = New System.Drawing.Size(115, 21)
        Me.cboProduct.TabIndex = 18
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(231, 95)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(71, 12)
        Me.Label18.TabIndex = 72
        Me.Label18.Text = "Product"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtStatus
        '
        Me.txtStatus.Location = New System.Drawing.Point(93, 121)
        Me.txtStatus.MaxLength = 128
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.Size = New System.Drawing.Size(116, 21)
        Me.txtStatus.TabIndex = 17
        '
        'lblStatus
        '
        Me.lblStatus.Location = New System.Drawing.Point(7, 124)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(80, 13)
        Me.lblStatus.TabIndex = 66
        Me.lblStatus.Text = "Status"
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtShelfNo
        '
        Me.txtShelfNo.Location = New System.Drawing.Point(774, 93)
        Me.txtShelfNo.MaxLength = 16
        Me.txtShelfNo.Name = "txtShelfNo"
        Me.txtShelfNo.Size = New System.Drawing.Size(115, 21)
        Me.txtShelfNo.TabIndex = 16
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(709, 96)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(58, 13)
        Me.Label12.TabIndex = 65
        Me.Label12.Text = "Shelf No"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtAccountNo
        '
        Me.txtAccountNo.Location = New System.Drawing.Point(94, 93)
        Me.txtAccountNo.MaxLength = 128
        Me.txtAccountNo.Name = "txtAccountNo"
        Me.txtAccountNo.Size = New System.Drawing.Size(115, 21)
        Me.txtAccountNo.TabIndex = 12
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(10, 96)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(77, 13)
        Me.Label14.TabIndex = 61
        Me.Label14.Text = "Account No"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(281, 38)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(21, 13)
        Me.Label20.TabIndex = 58
        Me.Label20.Text = "To"
        '
        'dtpChqTo
        '
        Me.dtpChqTo.CustomFormat = "dd-MM-yyyy"
        Me.dtpChqTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpChqTo.Location = New System.Drawing.Point(308, 35)
        Me.dtpChqTo.Name = "dtpChqTo"
        Me.dtpChqTo.ShowCheckBox = True
        Me.dtpChqTo.Size = New System.Drawing.Size(115, 21)
        Me.dtpChqTo.TabIndex = 7
        '
        'dtpChqForm
        '
        Me.dtpChqForm.CustomFormat = "dd-MM-yyyy"
        Me.dtpChqForm.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpChqForm.Location = New System.Drawing.Point(93, 35)
        Me.dtpChqForm.Name = "dtpChqForm"
        Me.dtpChqForm.ShowCheckBox = True
        Me.dtpChqForm.Size = New System.Drawing.Size(115, 21)
        Me.dtpChqForm.TabIndex = 6
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
        'txtBoxNo
        '
        Me.txtBoxNo.Location = New System.Drawing.Point(535, 93)
        Me.txtBoxNo.MaxLength = 16
        Me.txtBoxNo.Name = "txtBoxNo"
        Me.txtBoxNo.Size = New System.Drawing.Size(115, 21)
        Me.txtBoxNo.TabIndex = 15
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(468, 96)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(61, 13)
        Me.Label17.TabIndex = 50
        Me.Label17.Text = "Box No"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtChqAmt
        '
        Me.txtChqAmt.Location = New System.Drawing.Point(535, 65)
        Me.txtChqAmt.MaxLength = 18
        Me.txtChqAmt.Name = "txtChqAmt"
        Me.txtChqAmt.Size = New System.Drawing.Size(115, 21)
        Me.txtChqAmt.TabIndex = 9
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(451, 68)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(77, 13)
        Me.Label13.TabIndex = 44
        Me.Label13.Text = "Chq Amt"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(281, 11)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(21, 13)
        Me.Label10.TabIndex = 35
        Me.Label10.Text = "To"
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(9, 11)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(78, 13)
        Me.Label11.TabIndex = 34
        Me.Label11.Text = "Cycle From"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpCycleTo
        '
        Me.dtpCycleTo.CustomFormat = "dd-MM-yyyy"
        Me.dtpCycleTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpCycleTo.Location = New System.Drawing.Point(308, 8)
        Me.dtpCycleTo.Name = "dtpCycleTo"
        Me.dtpCycleTo.ShowCheckBox = True
        Me.dtpCycleTo.Size = New System.Drawing.Size(115, 21)
        Me.dtpCycleTo.TabIndex = 4
        '
        'dtpCycleFrom
        '
        Me.dtpCycleFrom.CustomFormat = "dd-MM-yyyy"
        Me.dtpCycleFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpCycleFrom.Location = New System.Drawing.Point(93, 8)
        Me.dtpCycleFrom.Name = "dtpCycleFrom"
        Me.dtpCycleFrom.ShowCheckBox = True
        Me.dtpCycleFrom.Size = New System.Drawing.Size(115, 21)
        Me.dtpCycleFrom.TabIndex = 3
        '
        'cboEntity
        '
        Me.cboEntity.FormattingEnabled = True
        Me.cboEntity.Location = New System.Drawing.Point(535, 35)
        Me.cboEntity.Name = "cboEntity"
        Me.cboEntity.Size = New System.Drawing.Size(354, 21)
        Me.cboEntity.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(487, 41)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 13)
        Me.Label6.TabIndex = 24
        Me.Label6.Text = "Entity"
        '
        'txtChqNo
        '
        Me.txtChqNo.Location = New System.Drawing.Point(309, 65)
        Me.txtChqNo.MaxLength = 16
        Me.txtChqNo.Name = "txtChqNo"
        Me.txtChqNo.Size = New System.Drawing.Size(115, 21)
        Me.txtChqNo.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(225, 68)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 13)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "Chq No"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtContractNo
        '
        Me.txtContractNo.Location = New System.Drawing.Point(93, 65)
        Me.txtContractNo.MaxLength = 32
        Me.txtContractNo.Name = "txtContractNo"
        Me.txtContractNo.Size = New System.Drawing.Size(115, 21)
        Me.txtContractNo.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 13)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Contract No"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(817, 121)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(72, 24)
        Me.btnClose.TabIndex = 26
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(739, 121)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(72, 24)
        Me.btnClear.TabIndex = 25
        Me.btnClear.Text = "C&lear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(661, 121)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(72, 24)
        Me.btnRefresh.TabIndex = 24
        Me.btnRefresh.Text = "&Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'cboFileName
        '
        Me.cboFileName.FormattingEnabled = True
        Me.cboFileName.Location = New System.Drawing.Point(535, 8)
        Me.cboFileName.Name = "cboFileName"
        Me.cboFileName.Size = New System.Drawing.Size(354, 21)
        Me.cboFileName.TabIndex = 2
        '
        'lbl1
        '
        Me.lbl1.AutoSize = True
        Me.lbl1.Location = New System.Drawing.Point(467, 11)
        Me.lbl1.Name = "lbl1"
        Me.lbl1.Size = New System.Drawing.Size(61, 13)
        Me.lbl1.TabIndex = 2
        Me.lbl1.Text = "File Name"
        '
        'frmHistoryReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(972, 414)
        Me.Controls.Add(Me.pnlButtons)
        Me.Controls.Add(Me.pnlDisplay)
        Me.Controls.Add(Me.dgvReport)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Name = "frmHistoryReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "History Report"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlDisplay.ResumeLayout(False)
        Me.pnlDisplay.PerformLayout()
        CType(Me.dgvReport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlButtons.ResumeLayout(False)
        Me.pnlButtons.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlDisplay As Panel
    Friend WithEvents lblRecCount As Label
    Friend WithEvents btnExport As Button
    Friend WithEvents dgvReport As DataGridView
    Friend WithEvents pnlButtons As System.Windows.Forms.Panel
    Friend WithEvents chkChqAmt As System.Windows.Forms.CheckBox
    Friend WithEvents chkContractNo As System.Windows.Forms.CheckBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents ChkChqNoQry As System.Windows.Forms.CheckBox
    Friend WithEvents txtMicrCode As System.Windows.Forms.TextBox
    Friend WithEvents lblMicrcode As System.Windows.Forms.Label
    Friend WithEvents cboProduct As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtStatus As System.Windows.Forms.TextBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents txtShelfNo As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtAccountNo As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents dtpChqTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpChqForm As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtBoxNo As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtChqAmt As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents dtpCycleTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpCycleFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboEntity As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtChqNo As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtContractNo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents cboFileName As System.Windows.Forms.ComboBox
    Friend WithEvents lbl1 As System.Windows.Forms.Label
End Class
