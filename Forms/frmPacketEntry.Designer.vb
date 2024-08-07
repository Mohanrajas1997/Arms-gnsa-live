<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPacketEntry
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.pnlPktInfo = New System.Windows.Forms.Panel()
        Me.TxtCoverNo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtLotNo = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtPktNo = New System.Windows.Forms.TextBox()
        Me.txtContractNo = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.dtpRcvdDate = New System.Windows.Forms.DateTimePicker()
        Me.txtId = New System.Windows.Forms.TextBox()
        Me.txtTotChq = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboEntityName = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.pnlChqInfo = New System.Windows.Forms.Panel()
        Me.TxtBankbranch = New System.Windows.Forms.TextBox()
        Me.cboChqType = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.rdoHalfly = New System.Windows.Forms.RadioButton()
        Me.rdoQuarterly = New System.Windows.Forms.RadioButton()
        Me.rdoMonthly = New System.Windows.Forms.RadioButton()
        Me.lblCtsDisc = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rdoChqDesc = New System.Windows.Forms.RadioButton()
        Me.rdoChqAsc = New System.Windows.Forms.RadioButton()
        Me.rdoAtparNo = New System.Windows.Forms.RadioButton()
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
        Me.dgvChq = New System.Windows.Forms.DataGridView()
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
        Me.pnlSave = New System.Windows.Forms.Panel()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.pnlButtons = New System.Windows.Forms.Panel()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnFind = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.pnlPktInfo.SuspendLayout()
        Me.pnlChqInfo.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvSumm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvChq, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSave.SuspendLayout()
        Me.pnlButtons.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlPktInfo
        '
        Me.pnlPktInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlPktInfo.Controls.Add(Me.TxtCoverNo)
        Me.pnlPktInfo.Controls.Add(Me.Label4)
        Me.pnlPktInfo.Controls.Add(Me.txtLotNo)
        Me.pnlPktInfo.Controls.Add(Me.Label9)
        Me.pnlPktInfo.Controls.Add(Me.txtPktNo)
        Me.pnlPktInfo.Controls.Add(Me.txtContractNo)
        Me.pnlPktInfo.Controls.Add(Me.Label13)
        Me.pnlPktInfo.Controls.Add(Me.dtpRcvdDate)
        Me.pnlPktInfo.Controls.Add(Me.txtId)
        Me.pnlPktInfo.Controls.Add(Me.txtTotChq)
        Me.pnlPktInfo.Controls.Add(Me.Label3)
        Me.pnlPktInfo.Controls.Add(Me.cboEntityName)
        Me.pnlPktInfo.Controls.Add(Me.Label2)
        Me.pnlPktInfo.Controls.Add(Me.Label12)
        Me.pnlPktInfo.Location = New System.Drawing.Point(14, 12)
        Me.pnlPktInfo.Name = "pnlPktInfo"
        Me.pnlPktInfo.Size = New System.Drawing.Size(649, 88)
        Me.pnlPktInfo.TabIndex = 0
        '
        'TxtCoverNo
        '
        Me.TxtCoverNo.Location = New System.Drawing.Point(319, 61)
        Me.TxtCoverNo.MaxLength = 64
        Me.TxtCoverNo.Name = "TxtCoverNo"
        Me.TxtCoverNo.Size = New System.Drawing.Size(313, 21)
        Me.TxtCoverNo.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(254, 64)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 13)
        Me.Label4.TabIndex = 72
        Me.Label4.Text = "Cover No"
        '
        'txtLotNo
        '
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
        'txtContractNo
        '
        Me.txtContractNo.Location = New System.Drawing.Point(318, 33)
        Me.txtContractNo.MaxLength = 32
        Me.txtContractNo.Name = "txtContractNo"
        Me.txtContractNo.Size = New System.Drawing.Size(316, 21)
        Me.txtContractNo.TabIndex = 3
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(233, 36)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(79, 13)
        Me.Label13.TabIndex = 68
        Me.Label13.Text = "Contract No"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpRcvdDate
        '
        Me.dtpRcvdDate.CustomFormat = "dd-MMM-yyyy"
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
        Me.pnlChqInfo.Location = New System.Drawing.Point(14, 105)
        Me.pnlChqInfo.Name = "pnlChqInfo"
        Me.pnlChqInfo.Size = New System.Drawing.Size(649, 471)
        Me.pnlChqInfo.TabIndex = 1
        '
        'TxtBankbranch
        '
        Me.TxtBankbranch.Location = New System.Drawing.Point(320, 219)
        Me.TxtBankbranch.MaxLength = 128
        Me.TxtBankbranch.Name = "TxtBankbranch"
        Me.TxtBankbranch.Size = New System.Drawing.Size(314, 21)
        Me.TxtBankbranch.TabIndex = 72
        '
        'cboChqType
        '
        Me.cboChqType.FormattingEnabled = True
        Me.cboChqType.Items.AddRange(New Object() {"PDC", "SPDC"})
        Me.cboChqType.Location = New System.Drawing.Point(102, 245)
        Me.cboChqType.Name = "cboChqType"
        Me.cboChqType.Size = New System.Drawing.Size(117, 21)
        Me.cboChqType.TabIndex = 11
        Me.cboChqType.Text = "PDC"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(34, 248)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(59, 13)
        Me.Label18.TabIndex = 71
        Me.Label18.Text = "Chq Type"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.rdoHalfly)
        Me.Panel2.Controls.Add(Me.rdoQuarterly)
        Me.Panel2.Controls.Add(Me.rdoMonthly)
        Me.Panel2.Location = New System.Drawing.Point(317, 267)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(224, 23)
        Me.Panel2.TabIndex = 16
        '
        'rdoHalfly
        '
        Me.rdoHalfly.AutoSize = True
        Me.rdoHalfly.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.rdoHalfly.Location = New System.Drawing.Point(162, 1)
        Me.rdoHalfly.Name = "rdoHalfly"
        Me.rdoHalfly.Size = New System.Drawing.Size(57, 17)
        Me.rdoHalfly.TabIndex = 16
        Me.rdoHalfly.Text = "Halfly"
        Me.rdoHalfly.UseVisualStyleBackColor = True
        '
        'rdoQuarterly
        '
        Me.rdoQuarterly.AutoSize = True
        Me.rdoQuarterly.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.rdoQuarterly.Location = New System.Drawing.Point(77, 1)
        Me.rdoQuarterly.Name = "rdoQuarterly"
        Me.rdoQuarterly.Size = New System.Drawing.Size(79, 17)
        Me.rdoQuarterly.TabIndex = 16
        Me.rdoQuarterly.Text = "Quarterly"
        Me.rdoQuarterly.UseVisualStyleBackColor = True
        '
        'rdoMonthly
        '
        Me.rdoMonthly.AutoSize = True
        Me.rdoMonthly.Checked = True
        Me.rdoMonthly.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.rdoMonthly.Location = New System.Drawing.Point(3, 2)
        Me.rdoMonthly.Name = "rdoMonthly"
        Me.rdoMonthly.Size = New System.Drawing.Size(71, 17)
        Me.rdoMonthly.TabIndex = 16
        Me.rdoMonthly.TabStop = True
        Me.rdoMonthly.Text = "Monthly"
        Me.rdoMonthly.UseVisualStyleBackColor = True
        '
        'lblCtsDisc
        '
        Me.lblCtsDisc.AutoSize = True
        Me.lblCtsDisc.Font = New System.Drawing.Font("Tahoma", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCtsDisc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblCtsDisc.Location = New System.Drawing.Point(580, 266)
        Me.lblCtsDisc.Name = "lblCtsDisc"
        Me.lblCtsDisc.Size = New System.Drawing.Size(54, 13)
        Me.lblCtsDisc.TabIndex = 16
        Me.lblCtsDisc.Text = "CTS Disc"
        Me.lblCtsDisc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(225, 249)
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
        Me.Panel1.Location = New System.Drawing.Point(319, 246)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(117, 20)
        Me.Panel1.TabIndex = 15
        '
        'rdoChqDesc
        '
        Me.rdoChqDesc.AutoSize = True
        Me.rdoChqDesc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.rdoChqDesc.Location = New System.Drawing.Point(59, 0)
        Me.rdoChqDesc.Name = "rdoChqDesc"
        Me.rdoChqDesc.Size = New System.Drawing.Size(52, 17)
        Me.rdoChqDesc.TabIndex = 19
        Me.rdoChqDesc.Text = "Desc"
        Me.rdoChqDesc.UseVisualStyleBackColor = True
        '
        'rdoChqAsc
        '
        Me.rdoChqAsc.AutoSize = True
        Me.rdoChqAsc.Checked = True
        Me.rdoChqAsc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.rdoChqAsc.Location = New System.Drawing.Point(0, 0)
        Me.rdoChqAsc.Name = "rdoChqAsc"
        Me.rdoChqAsc.Size = New System.Drawing.Size(45, 17)
        Me.rdoChqAsc.TabIndex = 15
        Me.rdoChqAsc.TabStop = True
        Me.rdoChqAsc.Text = "Asc"
        Me.rdoChqAsc.UseVisualStyleBackColor = True
        '
        'rdoAtparNo
        '
        Me.rdoAtparNo.AutoSize = True
        Me.rdoAtparNo.Checked = True
        Me.rdoAtparNo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.rdoAtparNo.Location = New System.Drawing.Point(163, 272)
        Me.rdoAtparNo.Name = "rdoAtparNo"
        Me.rdoAtparNo.Size = New System.Drawing.Size(39, 17)
        Me.rdoAtparNo.TabIndex = 14
        Me.rdoAtparNo.TabStop = True
        Me.rdoAtparNo.Text = "No"
        Me.rdoAtparNo.UseVisualStyleBackColor = True
        '
        'rdoAtparYes
        '
        Me.rdoAtparYes.AutoSize = True
        Me.rdoAtparYes.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.rdoAtparYes.Location = New System.Drawing.Point(105, 272)
        Me.rdoAtparYes.Name = "rdoAtparYes"
        Me.rdoAtparYes.Size = New System.Drawing.Size(45, 17)
        Me.rdoAtparYes.TabIndex = 14
        Me.rdoAtparYes.Text = "Yes"
        Me.rdoAtparYes.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(36, 274)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(54, 13)
        Me.Label16.TabIndex = 11
        Me.Label16.Text = "AT PAR"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtBankName
        '
        Me.txtBankName.Location = New System.Drawing.Point(365, 193)
        Me.txtBankName.MaxLength = 128
        Me.txtBankName.Name = "txtBankName"
        Me.txtBankName.Size = New System.Drawing.Size(271, 21)
        Me.txtBankName.TabIndex = 5
        '
        'txtBankCode
        '
        Me.txtBankCode.Location = New System.Drawing.Point(320, 193)
        Me.txtBankCode.MaxLength = 3
        Me.txtBankCode.Name = "txtBankCode"
        Me.txtBankCode.Size = New System.Drawing.Size(39, 21)
        Me.txtBankCode.TabIndex = 7
        '
        'dtpChqDate
        '
        Me.dtpChqDate.CustomFormat = "dd-MMM-yyyy"
        Me.dtpChqDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpChqDate.Location = New System.Drawing.Point(319, 165)
        Me.dtpChqDate.Name = "dtpChqDate"
        Me.dtpChqDate.Size = New System.Drawing.Size(116, 21)
        Me.dtpChqDate.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(224, 169)
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
        Me.Label15.Location = New System.Drawing.Point(3, 146)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(91, 13)
        Me.Label15.TabIndex = 2
        Me.Label15.Text = "Cheque Details"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Tahoma", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(3, 4)
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
        Me.dgvSumm.Location = New System.Drawing.Point(3, 20)
        Me.dgvSumm.Name = "dgvSumm"
        Me.dgvSumm.RowHeadersVisible = False
        Me.dgvSumm.Size = New System.Drawing.Size(641, 115)
        Me.dgvSumm.TabIndex = 1
        '
        'txtChqAmt
        '
        Me.txtChqAmt.Location = New System.Drawing.Point(102, 191)
        Me.txtChqAmt.MaxLength = 15
        Me.txtChqAmt.Name = "txtChqAmt"
        Me.txtChqAmt.Size = New System.Drawing.Size(116, 21)
        Me.txtChqAmt.TabIndex = 9
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(9, 195)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(87, 13)
        Me.Label10.TabIndex = 30
        Me.Label10.Text = "Chq Amount"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtMicrCode
        '
        Me.txtMicrCode.Location = New System.Drawing.Point(103, 218)
        Me.txtMicrCode.MaxLength = 9
        Me.txtMicrCode.Name = "txtMicrCode"
        Me.txtMicrCode.Size = New System.Drawing.Size(116, 21)
        Me.txtMicrCode.TabIndex = 10
        '
        'dgvChq
        '
        Me.dgvChq.AllowUserToAddRows = False
        Me.dgvChq.AllowUserToDeleteRows = False
        Me.dgvChq.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvChq.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvChq.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvChq.Location = New System.Drawing.Point(3, 317)
        Me.dgvChq.Name = "dgvChq"
        Me.dgvChq.RowHeadersVisible = False
        Me.dgvChq.Size = New System.Drawing.Size(641, 148)
        Me.dgvChq.TabIndex = 18
        Me.dgvChq.TabStop = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(235, 221)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(77, 13)
        Me.Label11.TabIndex = 20
        Me.Label11.Text = "Bank Branch"
        '
        'btnClrGrid
        '
        Me.btnClrGrid.Location = New System.Drawing.Point(562, 290)
        Me.btnClrGrid.Name = "btnClrGrid"
        Me.btnClrGrid.Size = New System.Drawing.Size(72, 24)
        Me.btnClrGrid.TabIndex = 19
        Me.btnClrGrid.Text = "Clear Grid"
        Me.btnClrGrid.UseVisualStyleBackColor = True
        '
        'btnGenerate
        '
        Me.btnGenerate.Location = New System.Drawing.Point(406, 290)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(72, 24)
        Me.btnGenerate.TabIndex = 17
        Me.btnGenerate.Text = "Generate"
        Me.btnGenerate.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(484, 290)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(72, 24)
        Me.btnClear.TabIndex = 18
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(240, 197)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(70, 13)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Bank Name"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(35, 221)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(62, 13)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Micr Code"
        '
        'txtChqNo
        '
        Me.txtChqNo.Location = New System.Drawing.Point(502, 166)
        Me.txtChqNo.MaxLength = 8
        Me.txtChqNo.Name = "txtChqNo"
        Me.txtChqNo.Size = New System.Drawing.Size(116, 21)
        Me.txtChqNo.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(452, 170)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Chq No"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(34, 168)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 13)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Chq Count"
        '
        'txtChqsCount
        '
        Me.txtChqsCount.Location = New System.Drawing.Point(103, 164)
        Me.txtChqsCount.MaxLength = 3
        Me.txtChqsCount.Name = "txtChqsCount"
        Me.txtChqsCount.Size = New System.Drawing.Size(116, 21)
        Me.txtChqsCount.TabIndex = 6
        '
        'pnlSave
        '
        Me.pnlSave.CausesValidation = False
        Me.pnlSave.Controls.Add(Me.btnCancel)
        Me.pnlSave.Controls.Add(Me.btnSave)
        Me.pnlSave.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlSave.Location = New System.Drawing.Point(264, 582)
        Me.pnlSave.Name = "pnlSave"
        Me.pnlSave.Size = New System.Drawing.Size(152, 28)
        Me.pnlSave.TabIndex = 4
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancel.CausesValidation = False
        Me.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnCancel.Location = New System.Drawing.Point(80, 1)
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
        Me.btnSave.Location = New System.Drawing.Point(2, 1)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(72, 24)
        Me.btnSave.TabIndex = 20
        Me.btnSave.Text = "&Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'pnlButtons
        '
        Me.pnlButtons.Controls.Add(Me.btnClose)
        Me.pnlButtons.Controls.Add(Me.btnFind)
        Me.pnlButtons.Controls.Add(Me.btnDelete)
        Me.pnlButtons.Controls.Add(Me.btnEdit)
        Me.pnlButtons.Controls.Add(Me.btnNew)
        Me.pnlButtons.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlButtons.Location = New System.Drawing.Point(143, 583)
        Me.pnlButtons.Name = "pnlButtons"
        Me.pnlButtons.Size = New System.Drawing.Size(386, 28)
        Me.pnlButtons.TabIndex = 3
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.SystemColors.Control
        Me.btnClose.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnClose.Location = New System.Drawing.Point(313, 1)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(72, 24)
        Me.btnClose.TabIndex = 4
        Me.btnClose.Text = "C&lose"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnFind
        '
        Me.btnFind.BackColor = System.Drawing.SystemColors.Control
        Me.btnFind.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnFind.Location = New System.Drawing.Point(157, 1)
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Size = New System.Drawing.Size(72, 24)
        Me.btnFind.TabIndex = 2
        Me.btnFind.Text = "&Find"
        Me.btnFind.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.SystemColors.Control
        Me.btnDelete.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnDelete.Location = New System.Drawing.Point(235, 1)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(72, 24)
        Me.btnDelete.TabIndex = 3
        Me.btnDelete.Text = "&Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.BackColor = System.Drawing.SystemColors.Control
        Me.btnEdit.Enabled = False
        Me.btnEdit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnEdit.Location = New System.Drawing.Point(79, 1)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(72, 24)
        Me.btnEdit.TabIndex = 1
        Me.btnEdit.Text = "&Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnNew
        '
        Me.btnNew.BackColor = System.Drawing.SystemColors.Control
        Me.btnNew.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnNew.Location = New System.Drawing.Point(1, 1)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(72, 24)
        Me.btnNew.TabIndex = 0
        Me.btnNew.Text = "&New"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'frmPacketEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(673, 615)
        Me.Controls.Add(Me.pnlSave)
        Me.Controls.Add(Me.pnlButtons)
        Me.Controls.Add(Me.pnlChqInfo)
        Me.Controls.Add(Me.pnlPktInfo)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "frmPacketEntry"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Stock Entry"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlPktInfo.ResumeLayout(False)
        Me.pnlPktInfo.PerformLayout()
        Me.pnlChqInfo.ResumeLayout(False)
        Me.pnlChqInfo.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvSumm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvChq, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSave.ResumeLayout(False)
        Me.pnlButtons.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlPktInfo As System.Windows.Forms.Panel
    Friend WithEvents cboEntityName As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtTotChq As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents pnlChqInfo As System.Windows.Forms.Panel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtChqsCount As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtChqNo As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnClrGrid As System.Windows.Forms.Button
    Friend WithEvents btnGenerate As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents dgvChq As System.Windows.Forms.DataGridView
    Friend WithEvents pnlSave As System.Windows.Forms.Panel
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents pnlButtons As System.Windows.Forms.Panel
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnFind As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents txtId As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents dtpRcvdDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtContractNo As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtMicrCode As System.Windows.Forms.TextBox
    Friend WithEvents txtPktNo As System.Windows.Forms.TextBox
    Friend WithEvents txtLotNo As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtChqAmt As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents dgvSumm As System.Windows.Forms.DataGridView
    Friend WithEvents txtBankName As System.Windows.Forms.TextBox
    Friend WithEvents txtBankCode As System.Windows.Forms.TextBox
    Friend WithEvents dtpChqDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents rdoAtparNo As System.Windows.Forms.RadioButton
    Friend WithEvents rdoAtparYes As System.Windows.Forms.RadioButton
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents rdoChqDesc As System.Windows.Forms.RadioButton
    Friend WithEvents rdoChqAsc As System.Windows.Forms.RadioButton
    Friend WithEvents lblCtsDisc As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents rdoHalfly As System.Windows.Forms.RadioButton
    Friend WithEvents rdoQuarterly As System.Windows.Forms.RadioButton
    Friend WithEvents rdoMonthly As System.Windows.Forms.RadioButton
    Friend WithEvents TxtCoverNo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cboChqType As System.Windows.Forms.ComboBox
    Friend WithEvents TxtBankbranch As System.Windows.Forms.TextBox
End Class
