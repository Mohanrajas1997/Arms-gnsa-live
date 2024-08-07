<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmScanImageDownloadReport
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
        Me.pnlDisplay = New System.Windows.Forms.Panel()
        Me.lblRecCount = New System.Windows.Forms.Label()
        Me.btnDownload = New System.Windows.Forms.Button()
        Me.dgvReport = New System.Windows.Forms.DataGridView()
        Me.pnlButtons = New System.Windows.Forms.Panel()
        Me.chkChqAmt = New System.Windows.Forms.CheckBox()
        Me.chkContractNo = New System.Windows.Forms.CheckBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.ChkChqNoQry = New System.Windows.Forms.CheckBox()
        Me.cboFormat = New System.Windows.Forms.ComboBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.cboLocation = New System.Windows.Forms.ComboBox()
        Me.cboProduct = New System.Windows.Forms.ComboBox()
        Me.txtChqId = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtBatchId = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtRemark = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtBranch = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtShelfNo = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtBankName = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtAccountNo = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.dtpChqTo = New System.Windows.Forms.DateTimePicker()
        Me.dtpChqForm = New System.Windows.Forms.DateTimePicker()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtPacketNo = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtBoxNo = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtChqAmt = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.dtpCycleTo = New System.Windows.Forms.DateTimePicker()
        Me.dtpCycleFrom = New System.Windows.Forms.DateTimePicker()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtPayeeName = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
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
        Me.chkdisc = New System.Windows.Forms.CheckBox()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.BtnDeSelect = New System.Windows.Forms.Button()
        Me.BtnSelect = New System.Windows.Forms.Button()
        Me.pnlDisplay.SuspendLayout()
        CType(Me.dgvReport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlButtons.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlDisplay
        '
        Me.pnlDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlDisplay.Controls.Add(Me.lblRecCount)
        Me.pnlDisplay.Controls.Add(Me.btnDownload)
        Me.pnlDisplay.Location = New System.Drawing.Point(13, 416)
        Me.pnlDisplay.Name = "pnlDisplay"
        Me.pnlDisplay.Size = New System.Drawing.Size(906, 32)
        Me.pnlDisplay.TabIndex = 5
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
        'btnDownload
        '
        Me.btnDownload.Location = New System.Drawing.Point(829, 3)
        Me.btnDownload.Name = "btnDownload"
        Me.btnDownload.Size = New System.Drawing.Size(72, 24)
        Me.btnDownload.TabIndex = 1
        Me.btnDownload.Text = "Download"
        Me.btnDownload.UseVisualStyleBackColor = True
        '
        'dgvReport
        '
        Me.dgvReport.AllowUserToAddRows = False
        Me.dgvReport.AllowUserToDeleteRows = False
        Me.dgvReport.Location = New System.Drawing.Point(13, 313)
        Me.dgvReport.Name = "dgvReport"
        Me.dgvReport.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dgvReport.Size = New System.Drawing.Size(906, 97)
        Me.dgvReport.TabIndex = 4
        '
        'pnlButtons
        '
        Me.pnlButtons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlButtons.Controls.Add(Me.BtnDeSelect)
        Me.pnlButtons.Controls.Add(Me.BtnSelect)
        Me.pnlButtons.Controls.Add(Me.btnExport)
        Me.pnlButtons.Controls.Add(Me.chkdisc)
        Me.pnlButtons.Controls.Add(Me.chkChqAmt)
        Me.pnlButtons.Controls.Add(Me.chkContractNo)
        Me.pnlButtons.Controls.Add(Me.Label25)
        Me.pnlButtons.Controls.Add(Me.ChkChqNoQry)
        Me.pnlButtons.Controls.Add(Me.cboFormat)
        Me.pnlButtons.Controls.Add(Me.Label24)
        Me.pnlButtons.Controls.Add(Me.cboLocation)
        Me.pnlButtons.Controls.Add(Me.cboProduct)
        Me.pnlButtons.Controls.Add(Me.txtChqId)
        Me.pnlButtons.Controls.Add(Me.Label22)
        Me.pnlButtons.Controls.Add(Me.txtBatchId)
        Me.pnlButtons.Controls.Add(Me.Label23)
        Me.pnlButtons.Controls.Add(Me.Label18)
        Me.pnlButtons.Controls.Add(Me.Label21)
        Me.pnlButtons.Controls.Add(Me.txtRemark)
        Me.pnlButtons.Controls.Add(Me.Label15)
        Me.pnlButtons.Controls.Add(Me.txtBranch)
        Me.pnlButtons.Controls.Add(Me.Label1)
        Me.pnlButtons.Controls.Add(Me.txtShelfNo)
        Me.pnlButtons.Controls.Add(Me.Label12)
        Me.pnlButtons.Controls.Add(Me.txtBankName)
        Me.pnlButtons.Controls.Add(Me.Label7)
        Me.pnlButtons.Controls.Add(Me.txtAccountNo)
        Me.pnlButtons.Controls.Add(Me.Label14)
        Me.pnlButtons.Controls.Add(Me.Label20)
        Me.pnlButtons.Controls.Add(Me.dtpChqTo)
        Me.pnlButtons.Controls.Add(Me.dtpChqForm)
        Me.pnlButtons.Controls.Add(Me.Label19)
        Me.pnlButtons.Controls.Add(Me.txtPacketNo)
        Me.pnlButtons.Controls.Add(Me.Label16)
        Me.pnlButtons.Controls.Add(Me.txtBoxNo)
        Me.pnlButtons.Controls.Add(Me.Label17)
        Me.pnlButtons.Controls.Add(Me.txtChqAmt)
        Me.pnlButtons.Controls.Add(Me.Label13)
        Me.pnlButtons.Controls.Add(Me.Label10)
        Me.pnlButtons.Controls.Add(Me.Label11)
        Me.pnlButtons.Controls.Add(Me.dtpCycleTo)
        Me.pnlButtons.Controls.Add(Me.dtpCycleFrom)
        Me.pnlButtons.Controls.Add(Me.cboStatus)
        Me.pnlButtons.Controls.Add(Me.Label9)
        Me.pnlButtons.Controls.Add(Me.txtPayeeName)
        Me.pnlButtons.Controls.Add(Me.Label8)
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
        Me.pnlButtons.Location = New System.Drawing.Point(13, 12)
        Me.pnlButtons.Name = "pnlButtons"
        Me.pnlButtons.Size = New System.Drawing.Size(906, 272)
        Me.pnlButtons.TabIndex = 3
        '
        'chkChqAmt
        '
        Me.chkChqAmt.AutoSize = True
        Me.chkChqAmt.Location = New System.Drawing.Point(476, 214)
        Me.chkChqAmt.Name = "chkChqAmt"
        Me.chkChqAmt.Size = New System.Drawing.Size(74, 17)
        Me.chkChqAmt.TabIndex = 84
        Me.chkChqAmt.Text = "Chq Amt"
        Me.chkChqAmt.UseVisualStyleBackColor = True
        '
        'chkContractNo
        '
        Me.chkContractNo.AutoSize = True
        Me.chkContractNo.Location = New System.Drawing.Point(378, 214)
        Me.chkContractNo.Name = "chkContractNo"
        Me.chkContractNo.Size = New System.Drawing.Size(92, 17)
        Me.chkContractNo.TabIndex = 85
        Me.chkContractNo.Text = "Contract No"
        Me.chkContractNo.UseVisualStyleBackColor = True
        '
        'Label25
        '
        Me.Label25.Location = New System.Drawing.Point(238, 214)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(64, 13)
        Me.Label25.TabIndex = 87
        Me.Label25.Text = "Query"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ChkChqNoQry
        '
        Me.ChkChqNoQry.AutoSize = True
        Me.ChkChqNoQry.Location = New System.Drawing.Point(308, 214)
        Me.ChkChqNoQry.Name = "ChkChqNoQry"
        Me.ChkChqNoQry.Size = New System.Drawing.Size(64, 17)
        Me.ChkChqNoQry.TabIndex = 86
        Me.ChkChqNoQry.Text = "Chq No"
        Me.ChkChqNoQry.UseVisualStyleBackColor = True
        '
        'cboFormat
        '
        Me.cboFormat.FormattingEnabled = True
        Me.cboFormat.Items.AddRange(New Object() {"Default", "Final", "Daimler"})
        Me.cboFormat.Location = New System.Drawing.Point(93, 211)
        Me.cboFormat.Name = "cboFormat"
        Me.cboFormat.Size = New System.Drawing.Size(115, 21)
        Me.cboFormat.TabIndex = 82
        Me.cboFormat.Text = "Default"
        '
        'Label24
        '
        Me.Label24.Location = New System.Drawing.Point(16, 214)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(71, 13)
        Me.Label24.TabIndex = 83
        Me.Label24.Text = "Format"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboLocation
        '
        Me.cboLocation.FormattingEnabled = True
        Me.cboLocation.Location = New System.Drawing.Point(308, 151)
        Me.cboLocation.Name = "cboLocation"
        Me.cboLocation.Size = New System.Drawing.Size(115, 21)
        Me.cboLocation.TabIndex = 19
        '
        'cboProduct
        '
        Me.cboProduct.FormattingEnabled = True
        Me.cboProduct.Location = New System.Drawing.Point(93, 151)
        Me.cboProduct.Name = "cboProduct"
        Me.cboProduct.Size = New System.Drawing.Size(115, 21)
        Me.cboProduct.TabIndex = 18
        '
        'txtChqId
        '
        Me.txtChqId.AcceptsReturn = True
        Me.txtChqId.Location = New System.Drawing.Point(93, 181)
        Me.txtChqId.MaxLength = 10
        Me.txtChqId.Name = "txtChqId"
        Me.txtChqId.Size = New System.Drawing.Size(115, 21)
        Me.txtChqId.TabIndex = 21
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(16, 184)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(71, 13)
        Me.Label22.TabIndex = 76
        Me.Label22.Text = "Chq Id"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtBatchId
        '
        Me.txtBatchId.Location = New System.Drawing.Point(308, 180)
        Me.txtBatchId.MaxLength = 11
        Me.txtBatchId.Name = "txtBatchId"
        Me.txtBatchId.Size = New System.Drawing.Size(115, 21)
        Me.txtBatchId.TabIndex = 22
        '
        'Label23
        '
        Me.Label23.Location = New System.Drawing.Point(238, 185)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(64, 13)
        Me.Label23.TabIndex = 75
        Me.Label23.Text = "Batch Id"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(16, 154)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(71, 13)
        Me.Label18.TabIndex = 72
        Me.Label18.Text = "Product"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(244, 154)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(58, 13)
        Me.Label21.TabIndex = 71
        Me.Label21.Text = "Location"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtRemark
        '
        Me.txtRemark.Location = New System.Drawing.Point(535, 151)
        Me.txtRemark.MaxLength = 255
        Me.txtRemark.Name = "txtRemark"
        Me.txtRemark.Size = New System.Drawing.Size(354, 21)
        Me.txtRemark.TabIndex = 20
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(450, 154)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(77, 13)
        Me.Label15.TabIndex = 67
        Me.Label15.Text = "Chq Remark"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtBranch
        '
        Me.txtBranch.Location = New System.Drawing.Point(774, 120)
        Me.txtBranch.MaxLength = 128
        Me.txtBranch.Name = "txtBranch"
        Me.txtBranch.Size = New System.Drawing.Size(115, 21)
        Me.txtBranch.TabIndex = 17
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(688, 126)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 13)
        Me.Label1.TabIndex = 66
        Me.Label1.Text = "Bank Branch"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtShelfNo
        '
        Me.txtShelfNo.Location = New System.Drawing.Point(535, 120)
        Me.txtShelfNo.MaxLength = 16
        Me.txtShelfNo.Name = "txtShelfNo"
        Me.txtShelfNo.Size = New System.Drawing.Size(115, 21)
        Me.txtShelfNo.TabIndex = 16
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(470, 123)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(58, 13)
        Me.Label12.TabIndex = 65
        Me.Label12.Text = "Shelf No"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtBankName
        '
        Me.txtBankName.Location = New System.Drawing.Point(774, 91)
        Me.txtBankName.MaxLength = 128
        Me.txtBankName.Name = "txtBankName"
        Me.txtBankName.Size = New System.Drawing.Size(115, 21)
        Me.txtBankName.TabIndex = 13
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(691, 94)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(77, 13)
        Me.Label7.TabIndex = 62
        Me.Label7.Text = "Bank Name"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtAccountNo
        '
        Me.txtAccountNo.Location = New System.Drawing.Point(535, 91)
        Me.txtAccountNo.MaxLength = 128
        Me.txtAccountNo.Name = "txtAccountNo"
        Me.txtAccountNo.Size = New System.Drawing.Size(115, 21)
        Me.txtAccountNo.TabIndex = 12
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(451, 94)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(77, 13)
        Me.Label14.TabIndex = 61
        Me.Label14.Text = "Account No"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(281, 65)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(21, 13)
        Me.Label20.TabIndex = 58
        Me.Label20.Text = "To"
        '
        'dtpChqTo
        '
        Me.dtpChqTo.CustomFormat = "dd-MM-yyyy"
        Me.dtpChqTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpChqTo.Location = New System.Drawing.Point(308, 62)
        Me.dtpChqTo.Name = "dtpChqTo"
        Me.dtpChqTo.ShowCheckBox = True
        Me.dtpChqTo.Size = New System.Drawing.Size(115, 21)
        Me.dtpChqTo.TabIndex = 7
        '
        'dtpChqForm
        '
        Me.dtpChqForm.CustomFormat = "dd-MM-yyyy"
        Me.dtpChqForm.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpChqForm.Location = New System.Drawing.Point(93, 62)
        Me.dtpChqForm.Name = "dtpChqForm"
        Me.dtpChqForm.ShowCheckBox = True
        Me.dtpChqForm.Size = New System.Drawing.Size(115, 21)
        Me.dtpChqForm.TabIndex = 6
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(9, 65)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(78, 13)
        Me.Label19.TabIndex = 55
        Me.Label19.Text = "Chq From"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtPacketNo
        '
        Me.txtPacketNo.AcceptsReturn = True
        Me.txtPacketNo.Location = New System.Drawing.Point(93, 120)
        Me.txtPacketNo.MaxLength = 64
        Me.txtPacketNo.Name = "txtPacketNo"
        Me.txtPacketNo.Size = New System.Drawing.Size(115, 21)
        Me.txtPacketNo.TabIndex = 14
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(16, 123)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(71, 13)
        Me.Label16.TabIndex = 52
        Me.Label16.Text = "Packet No"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtBoxNo
        '
        Me.txtBoxNo.Location = New System.Drawing.Point(308, 119)
        Me.txtBoxNo.MaxLength = 16
        Me.txtBoxNo.Name = "txtBoxNo"
        Me.txtBoxNo.Size = New System.Drawing.Size(115, 21)
        Me.txtBoxNo.TabIndex = 15
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(241, 124)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(61, 13)
        Me.Label17.TabIndex = 50
        Me.Label17.Text = "Box No"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtChqAmt
        '
        Me.txtChqAmt.Location = New System.Drawing.Point(774, 62)
        Me.txtChqAmt.MaxLength = 18
        Me.txtChqAmt.Name = "txtChqAmt"
        Me.txtChqAmt.Size = New System.Drawing.Size(115, 21)
        Me.txtChqAmt.TabIndex = 9
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(691, 68)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(77, 13)
        Me.Label13.TabIndex = 44
        Me.Label13.Text = "Chq Amt"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(281, 38)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(21, 13)
        Me.Label10.TabIndex = 35
        Me.Label10.Text = "To"
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(9, 38)
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
        Me.dtpCycleTo.Location = New System.Drawing.Point(308, 35)
        Me.dtpCycleTo.Name = "dtpCycleTo"
        Me.dtpCycleTo.ShowCheckBox = True
        Me.dtpCycleTo.Size = New System.Drawing.Size(115, 21)
        Me.dtpCycleTo.TabIndex = 4
        '
        'dtpCycleFrom
        '
        Me.dtpCycleFrom.CustomFormat = "dd-MM-yyyy"
        Me.dtpCycleFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpCycleFrom.Location = New System.Drawing.Point(93, 35)
        Me.dtpCycleFrom.Name = "dtpCycleFrom"
        Me.dtpCycleFrom.ShowCheckBox = True
        Me.dtpCycleFrom.Size = New System.Drawing.Size(115, 21)
        Me.dtpCycleFrom.TabIndex = 3
        '
        'cboStatus
        '
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Location = New System.Drawing.Point(535, 181)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(354, 21)
        Me.cboStatus.TabIndex = 23
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(483, 184)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(44, 13)
        Me.Label9.TabIndex = 30
        Me.Label9.Text = "Status"
        '
        'txtPayeeName
        '
        Me.txtPayeeName.Location = New System.Drawing.Point(308, 91)
        Me.txtPayeeName.MaxLength = 128
        Me.txtPayeeName.Name = "txtPayeeName"
        Me.txtPayeeName.Size = New System.Drawing.Size(115, 21)
        Me.txtPayeeName.TabIndex = 11
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(219, 94)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(83, 13)
        Me.Label8.TabIndex = 28
        Me.Label8.Text = "Payee Name"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.txtChqNo.Location = New System.Drawing.Point(535, 62)
        Me.txtChqNo.MaxLength = 16
        Me.txtChqNo.Name = "txtChqNo"
        Me.txtChqNo.Size = New System.Drawing.Size(115, 21)
        Me.txtChqNo.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(451, 65)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 13)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "Chq No"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(281, 11)
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
        Me.dtpImportTo.Location = New System.Drawing.Point(308, 8)
        Me.dtpImportTo.Name = "dtpImportTo"
        Me.dtpImportTo.ShowCheckBox = True
        Me.dtpImportTo.Size = New System.Drawing.Size(115, 21)
        Me.dtpImportTo.TabIndex = 1
        '
        'dtpImportFrom
        '
        Me.dtpImportFrom.CustomFormat = "dd-MM-yyyy"
        Me.dtpImportFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpImportFrom.Location = New System.Drawing.Point(93, 8)
        Me.dtpImportFrom.Name = "dtpImportFrom"
        Me.dtpImportFrom.ShowCheckBox = True
        Me.dtpImportFrom.Size = New System.Drawing.Size(115, 21)
        Me.dtpImportFrom.TabIndex = 0
        '
        'txtContractNo
        '
        Me.txtContractNo.Location = New System.Drawing.Point(93, 91)
        Me.txtContractNo.MaxLength = 32
        Me.txtContractNo.Name = "txtContractNo"
        Me.txtContractNo.Size = New System.Drawing.Size(115, 21)
        Me.txtContractNo.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 94)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 13)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Contract No"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(817, 208)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(72, 24)
        Me.btnClose.TabIndex = 26
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(739, 208)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(72, 24)
        Me.btnClear.TabIndex = 25
        Me.btnClear.Text = "C&lear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(661, 208)
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
        'chkdisc
        '
        Me.chkdisc.AutoSize = True
        Me.chkdisc.Location = New System.Drawing.Point(556, 214)
        Me.chkdisc.Name = "chkdisc"
        Me.chkdisc.Size = New System.Drawing.Size(73, 17)
        Me.chkdisc.TabIndex = 88
        Me.chkdisc.Text = "Chq Disc"
        Me.chkdisc.UseVisualStyleBackColor = True
        '
        'btnExport
        '
        Me.btnExport.BackColor = System.Drawing.Color.LightGreen
        Me.btnExport.Location = New System.Drawing.Point(817, 238)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(72, 24)
        Me.btnExport.TabIndex = 2
        Me.btnExport.Text = "E&xport"
        Me.btnExport.UseVisualStyleBackColor = False
        '
        'BtnDeSelect
        '
        Me.BtnDeSelect.BackColor = System.Drawing.Color.LightCoral
        Me.BtnDeSelect.Location = New System.Drawing.Point(739, 239)
        Me.BtnDeSelect.Name = "BtnDeSelect"
        Me.BtnDeSelect.Size = New System.Drawing.Size(72, 24)
        Me.BtnDeSelect.TabIndex = 90
        Me.BtnDeSelect.Text = "De-Select"
        Me.BtnDeSelect.UseVisualStyleBackColor = False
        '
        'BtnSelect
        '
        Me.BtnSelect.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.BtnSelect.Location = New System.Drawing.Point(661, 239)
        Me.BtnSelect.Name = "BtnSelect"
        Me.BtnSelect.Size = New System.Drawing.Size(72, 24)
        Me.BtnSelect.TabIndex = 89
        Me.BtnSelect.Text = "Select"
        Me.BtnSelect.UseVisualStyleBackColor = False
        '
        'frmScanImageDownloadReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(926, 464)
        Me.Controls.Add(Me.pnlDisplay)
        Me.Controls.Add(Me.dgvReport)
        Me.Controls.Add(Me.pnlButtons)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Name = "frmScanImageDownloadReport"
        Me.Text = "ScanImage Download"
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
    Friend WithEvents btnDownload As Button
    Friend WithEvents dgvReport As DataGridView
    Friend WithEvents pnlButtons As Panel
    Friend WithEvents cboLocation As ComboBox
    Friend WithEvents cboProduct As ComboBox
    Friend WithEvents txtChqId As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents txtBatchId As TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents txtRemark As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents txtBranch As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtShelfNo As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtBankName As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtAccountNo As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents dtpChqTo As DateTimePicker
    Friend WithEvents dtpChqForm As DateTimePicker
    Friend WithEvents Label19 As Label
    Friend WithEvents txtPacketNo As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents txtBoxNo As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents txtChqAmt As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents dtpCycleTo As DateTimePicker
    Friend WithEvents dtpCycleFrom As DateTimePicker
    Friend WithEvents cboStatus As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtPayeeName As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents cboEntity As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtChqNo As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents dtpImportTo As DateTimePicker
    Friend WithEvents dtpImportFrom As DateTimePicker
    Friend WithEvents txtContractNo As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnClose As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents btnRefresh As Button
    Friend WithEvents cboFileName As ComboBox
    Friend WithEvents lbl1 As Label
    Friend WithEvents chkChqAmt As CheckBox
    Friend WithEvents chkContractNo As CheckBox
    Friend WithEvents Label25 As Label
    Friend WithEvents ChkChqNoQry As CheckBox
    Friend WithEvents cboFormat As ComboBox
    Friend WithEvents Label24 As Label
    Friend WithEvents chkdisc As System.Windows.Forms.CheckBox
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents BtnDeSelect As System.Windows.Forms.Button
    Friend WithEvents BtnSelect As System.Windows.Forms.Button
End Class
