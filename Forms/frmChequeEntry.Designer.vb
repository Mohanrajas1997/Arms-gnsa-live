<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChequeEntry
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
        Me.rdoMonthly = New System.Windows.Forms.RadioButton()
        Me.TxtBankbranch = New System.Windows.Forms.TextBox()
        Me.cboChqType = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lblCtsDisc = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rdoChqDesc = New System.Windows.Forms.RadioButton()
        Me.rdoChqAsc = New System.Windows.Forms.RadioButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.rdoHalfly = New System.Windows.Forms.RadioButton()
        Me.rdoQuarterly = New System.Windows.Forms.RadioButton()
        Me.rdoAtparNo = New System.Windows.Forms.RadioButton()
        Me.pnlSave = New System.Windows.Forms.Panel()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.rdoAtparYes = New System.Windows.Forms.RadioButton()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtBankName = New System.Windows.Forms.TextBox()
        Me.txtBankCode = New System.Windows.Forms.TextBox()
        Me.dtpChqDate = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.dgvSumm = New System.Windows.Forms.DataGridView()
        Me.txtChqAmt = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtMicrCode = New System.Windows.Forms.TextBox()
        Me.txtCoverNo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtLotNo = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtPktNo = New System.Windows.Forms.TextBox()
        Me.pnlPktInfo = New System.Windows.Forms.Panel()
        Me.dtpRcvdDate = New System.Windows.Forms.DateTimePicker()
        Me.txtId = New System.Windows.Forms.TextBox()
        Me.txtTotChq = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboEntityName = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.dgvChq = New System.Windows.Forms.DataGridView()
        Me.pnlChqInfo = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.btnClrGrid = New System.Windows.Forms.Button()
        Me.btnGenerate = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtChqNo = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtChqsCount = New System.Windows.Forms.TextBox()
        Me.txtContractNo = New System.Windows.Forms.TextBox()
        Me.lblCntno = New System.Windows.Forms.Label()
        Me.txtCount = New System.Windows.Forms.TextBox()
        Me.lblCount = New System.Windows.Forms.Label()
        Me.btnComplete = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnlSave.SuspendLayout()
        CType(Me.dgvSumm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPktInfo.SuspendLayout()
        CType(Me.dgvChq, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlChqInfo.SuspendLayout()
        Me.SuspendLayout()
        '
        'rdoMonthly
        '
        Me.rdoMonthly.AutoSize = True
        Me.rdoMonthly.Checked = True
        Me.rdoMonthly.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.rdoMonthly.Location = New System.Drawing.Point(3, 0)
        Me.rdoMonthly.Name = "rdoMonthly"
        Me.rdoMonthly.Size = New System.Drawing.Size(71, 17)
        Me.rdoMonthly.TabIndex = 0
        Me.rdoMonthly.TabStop = True
        Me.rdoMonthly.Text = "Monthly"
        Me.rdoMonthly.UseVisualStyleBackColor = True
        '
        'TxtBankbranch
        '
        Me.TxtBankbranch.Location = New System.Drawing.Point(320, 217)
        Me.TxtBankbranch.MaxLength = 128
        Me.TxtBankbranch.Name = "TxtBankbranch"
        Me.TxtBankbranch.Size = New System.Drawing.Size(314, 21)
        Me.TxtBankbranch.TabIndex = 72
        '
        'cboChqType
        '
        Me.cboChqType.FormattingEnabled = True
        Me.cboChqType.Items.AddRange(New Object() {"PDC", "SPDC"})
        Me.cboChqType.Location = New System.Drawing.Point(102, 243)
        Me.cboChqType.Name = "cboChqType"
        Me.cboChqType.Size = New System.Drawing.Size(117, 21)
        Me.cboChqType.TabIndex = 5
        Me.cboChqType.Text = "PDC"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(34, 246)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(59, 13)
        Me.Label18.TabIndex = 71
        Me.Label18.Text = "Chq Type"
        '
        'lblCtsDisc
        '
        Me.lblCtsDisc.AutoSize = True
        Me.lblCtsDisc.Font = New System.Drawing.Font("Tahoma", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCtsDisc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblCtsDisc.Location = New System.Drawing.Point(580, 264)
        Me.lblCtsDisc.Name = "lblCtsDisc"
        Me.lblCtsDisc.Size = New System.Drawing.Size(54, 13)
        Me.lblCtsDisc.TabIndex = 8
        Me.lblCtsDisc.Text = "CTS Disc"
        Me.lblCtsDisc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(225, 247)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(84, 13)
        Me.Label17.TabIndex = 14
        Me.Label17.Text = "Chq Order"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.rdoChqDesc)
        Me.Panel1.Controls.Add(Me.rdoChqAsc)
        Me.Panel1.Location = New System.Drawing.Point(319, 244)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(117, 20)
        Me.Panel1.TabIndex = 15
        '
        'rdoChqDesc
        '
        Me.rdoChqDesc.AutoSize = True
        Me.rdoChqDesc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.rdoChqDesc.Location = New System.Drawing.Point(59, -2)
        Me.rdoChqDesc.Name = "rdoChqDesc"
        Me.rdoChqDesc.Size = New System.Drawing.Size(52, 17)
        Me.rdoChqDesc.TabIndex = 1
        Me.rdoChqDesc.Text = "Desc"
        Me.rdoChqDesc.UseVisualStyleBackColor = True
        '
        'rdoChqAsc
        '
        Me.rdoChqAsc.AutoSize = True
        Me.rdoChqAsc.Checked = True
        Me.rdoChqAsc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.rdoChqAsc.Location = New System.Drawing.Point(0, -2)
        Me.rdoChqAsc.Name = "rdoChqAsc"
        Me.rdoChqAsc.Size = New System.Drawing.Size(45, 17)
        Me.rdoChqAsc.TabIndex = 0
        Me.rdoChqAsc.TabStop = True
        Me.rdoChqAsc.Text = "Asc"
        Me.rdoChqAsc.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.rdoHalfly)
        Me.Panel2.Controls.Add(Me.rdoQuarterly)
        Me.Panel2.Controls.Add(Me.rdoMonthly)
        Me.Panel2.Location = New System.Drawing.Point(317, 265)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(224, 23)
        Me.Panel2.TabIndex = 16
        '
        'rdoHalfly
        '
        Me.rdoHalfly.AutoSize = True
        Me.rdoHalfly.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.rdoHalfly.Location = New System.Drawing.Point(162, -1)
        Me.rdoHalfly.Name = "rdoHalfly"
        Me.rdoHalfly.Size = New System.Drawing.Size(57, 17)
        Me.rdoHalfly.TabIndex = 2
        Me.rdoHalfly.Text = "Halfly"
        Me.rdoHalfly.UseVisualStyleBackColor = True
        '
        'rdoQuarterly
        '
        Me.rdoQuarterly.AutoSize = True
        Me.rdoQuarterly.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.rdoQuarterly.Location = New System.Drawing.Point(77, -1)
        Me.rdoQuarterly.Name = "rdoQuarterly"
        Me.rdoQuarterly.Size = New System.Drawing.Size(79, 17)
        Me.rdoQuarterly.TabIndex = 1
        Me.rdoQuarterly.Text = "Quarterly"
        Me.rdoQuarterly.UseVisualStyleBackColor = True
        '
        'rdoAtparNo
        '
        Me.rdoAtparNo.AutoSize = True
        Me.rdoAtparNo.Checked = True
        Me.rdoAtparNo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.rdoAtparNo.Location = New System.Drawing.Point(163, 270)
        Me.rdoAtparNo.Name = "rdoAtparNo"
        Me.rdoAtparNo.Size = New System.Drawing.Size(39, 17)
        Me.rdoAtparNo.TabIndex = 7
        Me.rdoAtparNo.TabStop = True
        Me.rdoAtparNo.Text = "No"
        Me.rdoAtparNo.UseVisualStyleBackColor = True
        '
        'pnlSave
        '
        Me.pnlSave.CausesValidation = False
        Me.pnlSave.Controls.Add(Me.btnCancel)
        Me.pnlSave.Controls.Add(Me.btnSave)
        Me.pnlSave.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlSave.Location = New System.Drawing.Point(262, 612)
        Me.pnlSave.Name = "pnlSave"
        Me.pnlSave.Size = New System.Drawing.Size(152, 28)
        Me.pnlSave.TabIndex = 8
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancel.CausesValidation = False
        Me.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnCancel.Location = New System.Drawing.Point(80, 2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(72, 24)
        Me.btnCancel.TabIndex = 21
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.SystemColors.Control
        Me.btnSave.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnSave.Location = New System.Drawing.Point(2, 2)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(72, 24)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "&Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'rdoAtparYes
        '
        Me.rdoAtparYes.AutoSize = True
        Me.rdoAtparYes.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.rdoAtparYes.Location = New System.Drawing.Point(105, 270)
        Me.rdoAtparYes.Name = "rdoAtparYes"
        Me.rdoAtparYes.Size = New System.Drawing.Size(45, 17)
        Me.rdoAtparYes.TabIndex = 6
        Me.rdoAtparYes.Text = "Yes"
        Me.rdoAtparYes.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(36, 272)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(54, 13)
        Me.Label16.TabIndex = 11
        Me.Label16.Text = "AT PAR"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtBankName
        '
        Me.txtBankName.Location = New System.Drawing.Point(365, 191)
        Me.txtBankName.MaxLength = 128
        Me.txtBankName.Name = "txtBankName"
        Me.txtBankName.Size = New System.Drawing.Size(271, 21)
        Me.txtBankName.TabIndex = 5
        '
        'txtBankCode
        '
        Me.txtBankCode.Location = New System.Drawing.Point(320, 191)
        Me.txtBankCode.MaxLength = 3
        Me.txtBankCode.Name = "txtBankCode"
        Me.txtBankCode.Size = New System.Drawing.Size(39, 21)
        Me.txtBankCode.TabIndex = 7
        '
        'dtpChqDate
        '
        Me.dtpChqDate.CustomFormat = "dd-MMM-yyyy"
        Me.dtpChqDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpChqDate.Location = New System.Drawing.Point(319, 163)
        Me.dtpChqDate.Name = "dtpChqDate"
        Me.dtpChqDate.Size = New System.Drawing.Size(116, 21)
        Me.dtpChqDate.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(224, 167)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 13)
        Me.Label1.TabIndex = 69
        Me.Label1.Text = "Chq Date"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(3, 144)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(91, 13)
        Me.Label15.TabIndex = 0
        Me.Label15.Text = "Cheque Details"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Tahoma", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(3, 2)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(121, 13)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "ARMS Summary List"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvSumm
        '
        Me.dgvSumm.AllowUserToAddRows = False
        Me.dgvSumm.AllowUserToDeleteRows = False
        Me.dgvSumm.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvSumm.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvSumm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSumm.Location = New System.Drawing.Point(3, 18)
        Me.dgvSumm.Name = "dgvSumm"
        Me.dgvSumm.RowHeadersVisible = False
        Me.dgvSumm.Size = New System.Drawing.Size(641, 115)
        Me.dgvSumm.TabIndex = 9
        '
        'txtChqAmt
        '
        Me.txtChqAmt.Location = New System.Drawing.Point(102, 189)
        Me.txtChqAmt.MaxLength = 15
        Me.txtChqAmt.Name = "txtChqAmt"
        Me.txtChqAmt.Size = New System.Drawing.Size(116, 21)
        Me.txtChqAmt.TabIndex = 3
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(9, 193)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(87, 13)
        Me.Label10.TabIndex = 30
        Me.Label10.Text = "Chq Amount"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtMicrCode
        '
        Me.txtMicrCode.Location = New System.Drawing.Point(103, 216)
        Me.txtMicrCode.MaxLength = 9
        Me.txtMicrCode.Name = "txtMicrCode"
        Me.txtMicrCode.Size = New System.Drawing.Size(116, 21)
        Me.txtMicrCode.TabIndex = 4
        '
        'txtCoverNo
        '
        Me.txtCoverNo.Enabled = False
        Me.txtCoverNo.Location = New System.Drawing.Point(319, 34)
        Me.txtCoverNo.MaxLength = 64
        Me.txtCoverNo.Name = "txtCoverNo"
        Me.txtCoverNo.Size = New System.Drawing.Size(313, 21)
        Me.txtCoverNo.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(254, 37)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 13)
        Me.Label4.TabIndex = 72
        Me.Label4.Text = "Cover No"
        '
        'txtLotNo
        '
        Me.txtLotNo.Enabled = False
        Me.txtLotNo.Location = New System.Drawing.Point(103, 33)
        Me.txtLotNo.MaxLength = 8
        Me.txtLotNo.Name = "txtLotNo"
        Me.txtLotNo.Size = New System.Drawing.Size(116, 21)
        Me.txtLotNo.TabIndex = 2
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(53, 36)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(42, 13)
        Me.Label9.TabIndex = 71
        Me.Label9.Text = "Lot No"
        '
        'txtPktNo
        '
        Me.txtPktNo.Location = New System.Drawing.Point(3, 34)
        Me.txtPktNo.Name = "txtPktNo"
        Me.txtPktNo.Size = New System.Drawing.Size(14, 21)
        Me.txtPktNo.TabIndex = 69
        Me.txtPktNo.Visible = False
        '
        'pnlPktInfo
        '
        Me.pnlPktInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlPktInfo.Controls.Add(Me.txtCoverNo)
        Me.pnlPktInfo.Controls.Add(Me.Label4)
        Me.pnlPktInfo.Controls.Add(Me.txtLotNo)
        Me.pnlPktInfo.Controls.Add(Me.Label9)
        Me.pnlPktInfo.Controls.Add(Me.txtPktNo)
        Me.pnlPktInfo.Controls.Add(Me.dtpRcvdDate)
        Me.pnlPktInfo.Controls.Add(Me.txtId)
        Me.pnlPktInfo.Controls.Add(Me.txtTotChq)
        Me.pnlPktInfo.Controls.Add(Me.Label3)
        Me.pnlPktInfo.Controls.Add(Me.cboEntityName)
        Me.pnlPktInfo.Controls.Add(Me.Label2)
        Me.pnlPktInfo.Controls.Add(Me.Label12)
        Me.pnlPktInfo.Location = New System.Drawing.Point(12, 8)
        Me.pnlPktInfo.Name = "pnlPktInfo"
        Me.pnlPktInfo.Size = New System.Drawing.Size(649, 88)
        Me.pnlPktInfo.TabIndex = 0
        '
        'dtpRcvdDate
        '
        Me.dtpRcvdDate.CustomFormat = "dd-MMM-yyyy"
        Me.dtpRcvdDate.Enabled = False
        Me.dtpRcvdDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpRcvdDate.Location = New System.Drawing.Point(103, 6)
        Me.dtpRcvdDate.Name = "dtpRcvdDate"
        Me.dtpRcvdDate.Size = New System.Drawing.Size(116, 21)
        Me.dtpRcvdDate.TabIndex = 0
        Me.dtpRcvdDate.Tag = "*"
        '
        'txtId
        '
        Me.txtId.Location = New System.Drawing.Point(11, 7)
        Me.txtId.Name = "txtId"
        Me.txtId.Size = New System.Drawing.Size(14, 21)
        Me.txtId.TabIndex = 65
        Me.txtId.Visible = False
        '
        'txtTotChq
        '
        Me.txtTotChq.Enabled = False
        Me.txtTotChq.Location = New System.Drawing.Point(103, 60)
        Me.txtTotChq.MaxLength = 3
        Me.txtTotChq.Name = "txtTotChq"
        Me.txtTotChq.Size = New System.Drawing.Size(116, 21)
        Me.txtTotChq.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 63)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "No. of Cheques"
        '
        'cboEntityName
        '
        Me.cboEntityName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboEntityName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboEntityName.Enabled = False
        Me.cboEntityName.FormattingEnabled = True
        Me.cboEntityName.Location = New System.Drawing.Point(318, 6)
        Me.cboEntityName.Name = "cboEntityName"
        Me.cboEntityName.Size = New System.Drawing.Size(316, 21)
        Me.cboEntityName.TabIndex = 1
        Me.cboEntityName.Tag = "*"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(237, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Entity"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(8, 10)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(89, 13)
        Me.Label12.TabIndex = 67
        Me.Label12.Text = "Received Date"
        '
        'dgvChq
        '
        Me.dgvChq.AllowUserToAddRows = False
        Me.dgvChq.AllowUserToDeleteRows = False
        Me.dgvChq.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvChq.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvChq.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvChq.Location = New System.Drawing.Point(3, 315)
        Me.dgvChq.Name = "dgvChq"
        Me.dgvChq.RowHeadersVisible = False
        Me.dgvChq.Size = New System.Drawing.Size(641, 148)
        Me.dgvChq.TabIndex = 18
        Me.dgvChq.TabStop = False
        '
        'pnlChqInfo
        '
        Me.pnlChqInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlChqInfo.Controls.Add(Me.TxtBankbranch)
        Me.pnlChqInfo.Controls.Add(Me.cboChqType)
        Me.pnlChqInfo.Controls.Add(Me.Label18)
        Me.pnlChqInfo.Controls.Add(Me.Panel2)
        Me.pnlChqInfo.Controls.Add(Me.lblCtsDisc)
        Me.pnlChqInfo.Controls.Add(Me.Label17)
        Me.pnlChqInfo.Controls.Add(Me.Panel1)
        Me.pnlChqInfo.Controls.Add(Me.rdoAtparNo)
        Me.pnlChqInfo.Controls.Add(Me.rdoAtparYes)
        Me.pnlChqInfo.Controls.Add(Me.Label16)
        Me.pnlChqInfo.Controls.Add(Me.txtBankName)
        Me.pnlChqInfo.Controls.Add(Me.txtBankCode)
        Me.pnlChqInfo.Controls.Add(Me.dtpChqDate)
        Me.pnlChqInfo.Controls.Add(Me.Label1)
        Me.pnlChqInfo.Controls.Add(Me.Label15)
        Me.pnlChqInfo.Controls.Add(Me.Label14)
        Me.pnlChqInfo.Controls.Add(Me.dgvSumm)
        Me.pnlChqInfo.Controls.Add(Me.txtChqAmt)
        Me.pnlChqInfo.Controls.Add(Me.Label10)
        Me.pnlChqInfo.Controls.Add(Me.txtMicrCode)
        Me.pnlChqInfo.Controls.Add(Me.dgvChq)
        Me.pnlChqInfo.Controls.Add(Me.Label11)
        Me.pnlChqInfo.Controls.Add(Me.btnClrGrid)
        Me.pnlChqInfo.Controls.Add(Me.btnGenerate)
        Me.pnlChqInfo.Controls.Add(Me.btnClear)
        Me.pnlChqInfo.Controls.Add(Me.Label8)
        Me.pnlChqInfo.Controls.Add(Me.Label7)
        Me.pnlChqInfo.Controls.Add(Me.txtChqNo)
        Me.pnlChqInfo.Controls.Add(Me.Label5)
        Me.pnlChqInfo.Controls.Add(Me.Label6)
        Me.pnlChqInfo.Controls.Add(Me.txtChqsCount)
        Me.pnlChqInfo.Location = New System.Drawing.Point(12, 133)
        Me.pnlChqInfo.Name = "pnlChqInfo"
        Me.pnlChqInfo.Size = New System.Drawing.Size(649, 471)
        Me.pnlChqInfo.TabIndex = 6
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(235, 219)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(77, 13)
        Me.Label11.TabIndex = 20
        Me.Label11.Text = "Bank Branch"
        '
        'btnClrGrid
        '
        Me.btnClrGrid.Location = New System.Drawing.Point(562, 288)
        Me.btnClrGrid.Name = "btnClrGrid"
        Me.btnClrGrid.Size = New System.Drawing.Size(72, 24)
        Me.btnClrGrid.TabIndex = 19
        Me.btnClrGrid.Text = "Clear Grid"
        Me.btnClrGrid.UseVisualStyleBackColor = True
        '
        'btnGenerate
        '
        Me.btnGenerate.Location = New System.Drawing.Point(406, 288)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(72, 24)
        Me.btnGenerate.TabIndex = 8
        Me.btnGenerate.Text = "Generate"
        Me.btnGenerate.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(484, 288)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(72, 24)
        Me.btnClear.TabIndex = 18
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(240, 195)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(70, 13)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Bank Name"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(35, 219)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(62, 13)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Micr Code"
        '
        'txtChqNo
        '
        Me.txtChqNo.Location = New System.Drawing.Point(502, 164)
        Me.txtChqNo.MaxLength = 8
        Me.txtChqNo.Name = "txtChqNo"
        Me.txtChqNo.Size = New System.Drawing.Size(116, 21)
        Me.txtChqNo.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(452, 168)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Chq No"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(34, 166)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 13)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Chq Count"
        '
        'txtChqsCount
        '
        Me.txtChqsCount.Location = New System.Drawing.Point(103, 162)
        Me.txtChqsCount.MaxLength = 3
        Me.txtChqsCount.Name = "txtChqsCount"
        Me.txtChqsCount.Size = New System.Drawing.Size(116, 21)
        Me.txtChqsCount.TabIndex = 0
        '
        'txtContractNo
        '
        Me.txtContractNo.Location = New System.Drawing.Point(98, 106)
        Me.txtContractNo.MaxLength = 16
        Me.txtContractNo.Name = "txtContractNo"
        Me.txtContractNo.Size = New System.Drawing.Size(316, 21)
        Me.txtContractNo.TabIndex = 1
        '
        'lblCntno
        '
        Me.lblCntno.Location = New System.Drawing.Point(13, 109)
        Me.lblCntno.Name = "lblCntno"
        Me.lblCntno.Size = New System.Drawing.Size(79, 13)
        Me.lblCntno.TabIndex = 70
        Me.lblCntno.Text = "Contract No"
        Me.lblCntno.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCount
        '
        Me.txtCount.Enabled = False
        Me.txtCount.Location = New System.Drawing.Point(476, 106)
        Me.txtCount.MaxLength = 16
        Me.txtCount.Name = "txtCount"
        Me.txtCount.Size = New System.Drawing.Size(75, 21)
        Me.txtCount.TabIndex = 71
        '
        'lblCount
        '
        Me.lblCount.Location = New System.Drawing.Point(420, 106)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(50, 18)
        Me.lblCount.TabIndex = 72
        Me.lblCount.Text = "Count"
        Me.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnComplete
        '
        Me.btnComplete.Location = New System.Drawing.Point(589, 103)
        Me.btnComplete.Name = "btnComplete"
        Me.btnComplete.Size = New System.Drawing.Size(72, 24)
        Me.btnComplete.TabIndex = 73
        Me.btnComplete.Text = "Complete"
        Me.btnComplete.UseVisualStyleBackColor = True
        '
        'frmChequeEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(673, 659)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnComplete)
        Me.Controls.Add(Me.txtCount)
        Me.Controls.Add(Me.lblCount)
        Me.Controls.Add(Me.txtContractNo)
        Me.Controls.Add(Me.lblCntno)
        Me.Controls.Add(Me.pnlPktInfo)
        Me.Controls.Add(Me.pnlChqInfo)
        Me.Controls.Add(Me.pnlSave)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.KeyPreview = True
        Me.Name = "frmChequeEntry"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cheque Entry"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.pnlSave.ResumeLayout(False)
        CType(Me.dgvSumm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPktInfo.ResumeLayout(False)
        Me.pnlPktInfo.PerformLayout()
        CType(Me.dgvChq, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlChqInfo.ResumeLayout(False)
        Me.pnlChqInfo.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rdoMonthly As System.Windows.Forms.RadioButton
    Friend WithEvents TxtBankbranch As System.Windows.Forms.TextBox
    Friend WithEvents cboChqType As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents lblCtsDisc As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents rdoChqDesc As System.Windows.Forms.RadioButton
    Friend WithEvents rdoChqAsc As System.Windows.Forms.RadioButton
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents rdoHalfly As System.Windows.Forms.RadioButton
    Friend WithEvents rdoQuarterly As System.Windows.Forms.RadioButton
    Friend WithEvents rdoAtparNo As System.Windows.Forms.RadioButton
    Friend WithEvents pnlSave As System.Windows.Forms.Panel
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents rdoAtparYes As System.Windows.Forms.RadioButton
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtBankName As System.Windows.Forms.TextBox
    Friend WithEvents txtBankCode As System.Windows.Forms.TextBox
    Friend WithEvents dtpChqDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents dgvSumm As System.Windows.Forms.DataGridView
    Friend WithEvents txtChqAmt As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtMicrCode As System.Windows.Forms.TextBox
    Friend WithEvents txtCoverNo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtLotNo As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtPktNo As System.Windows.Forms.TextBox
    Friend WithEvents pnlPktInfo As System.Windows.Forms.Panel
    Friend WithEvents dtpRcvdDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtId As System.Windows.Forms.TextBox
    Friend WithEvents txtTotChq As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboEntityName As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents dgvChq As System.Windows.Forms.DataGridView
    Friend WithEvents pnlChqInfo As System.Windows.Forms.Panel
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btnClrGrid As System.Windows.Forms.Button
    Friend WithEvents btnGenerate As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtChqNo As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtChqsCount As System.Windows.Forms.TextBox
    Friend WithEvents txtContractNo As System.Windows.Forms.TextBox
    Friend WithEvents lblCntno As System.Windows.Forms.Label
    Friend WithEvents txtCount As System.Windows.Forms.TextBox
    Friend WithEvents lblCount As System.Windows.Forms.Label
    Friend WithEvents btnComplete As System.Windows.Forms.Button
End Class
