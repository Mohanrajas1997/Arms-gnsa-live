<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImageBaseEntry
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
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.TxtTotalChq = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.TxtLotNo = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.TxtPacketId = New System.Windows.Forms.TextBox()
        Me.TxtEntityName = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtContractNo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtCoverNo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtbPacketRecv = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PicFrontSide = New System.Windows.Forms.PictureBox()
        Me.PicBackSide = New System.Windows.Forms.PictureBox()
        Me.pnlEntry = New System.Windows.Forms.Panel()
        Me.RdiChqNo = New System.Windows.Forms.RadioButton()
        Me.RdiChqYes = New System.Windows.Forms.RadioButton()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.CboPcktMode = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TxtDiscValue = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.RdoYetConfirm = New System.Windows.Forms.RadioButton()
        Me.RdiYes = New System.Windows.Forms.RadioButton()
        Me.RdiNo = New System.Windows.Forms.RadioButton()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.TxtRemarks = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.mstchqdate = New System.Windows.Forms.MaskedTextBox()
        Me.TxtBankName = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TxtBankCode = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TxtMicrCode = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TxtChqNo = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtCtsChqAmt = New System.Windows.Forms.TextBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.txtaccno = New System.Windows.Forms.TextBox()
        Me.txtchqamt = New System.Windows.Forms.TextBox()
        Me.lblaccno = New System.Windows.Forms.Label()
        Me.lblchqamt = New System.Windows.Forms.Label()
        Me.lblchqdate = New System.Windows.Forms.Label()
        Me.Pnlchqdtls = New System.Windows.Forms.Panel()
        Me.PnlPdcEntry = New System.Windows.Forms.Panel()
        Me.PnlBankdtls = New System.Windows.Forms.Panel()
        Me.TabChqDetails = New System.Windows.Forms.TabControl()
        Me.TabChqDtls = New System.Windows.Forms.TabPage()
        Me.gvmChkrEntry = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rdoPending = New System.Windows.Forms.RadioButton()
        Me.rdoCompleted = New System.Windows.Forms.RadioButton()
        Me.TabInward = New System.Windows.Forms.TabPage()
        Me.gvmInwardDetails = New System.Windows.Forms.DataGridView()
        Me.api_gid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lot_no = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.contract_no = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.payee_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chq_date = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cycle_date = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chq_no = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chq_amount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chq_acc_no = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlcustinfo = New System.Windows.Forms.Panel()
        Me.txtCustname = New System.Windows.Forms.TextBox()
        Me.cboProdcode = New System.Windows.Forms.ComboBox()
        Me.lblProduct = New System.Windows.Forms.Label()
        Me.lblCustName = New System.Windows.Forms.Label()
        Me.cmbLoc = New System.Windows.Forms.ComboBox()
        Me.lblLoc = New System.Windows.Forms.Label()
        Me.pnlHeader.SuspendLayout()
        CType(Me.PicFrontSide, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicBackSide, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlEntry.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Pnlchqdtls.SuspendLayout()
        Me.PnlPdcEntry.SuspendLayout()
        Me.PnlBankdtls.SuspendLayout()
        Me.TabChqDetails.SuspendLayout()
        Me.TabChqDtls.SuspendLayout()
        CType(Me.gvmChkrEntry, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabInward.SuspendLayout()
        CType(Me.gvmInwardDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlcustinfo.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlHeader.Controls.Add(Me.TxtTotalChq)
        Me.pnlHeader.Controls.Add(Me.Label19)
        Me.pnlHeader.Controls.Add(Me.TxtLotNo)
        Me.pnlHeader.Controls.Add(Me.Label18)
        Me.pnlHeader.Controls.Add(Me.TxtPacketId)
        Me.pnlHeader.Controls.Add(Me.TxtEntityName)
        Me.pnlHeader.Controls.Add(Me.Label6)
        Me.pnlHeader.Controls.Add(Me.TxtContractNo)
        Me.pnlHeader.Controls.Add(Me.Label4)
        Me.pnlHeader.Controls.Add(Me.TxtCoverNo)
        Me.pnlHeader.Controls.Add(Me.Label3)
        Me.pnlHeader.Controls.Add(Me.dtbPacketRecv)
        Me.pnlHeader.Controls.Add(Me.Label2)
        Me.pnlHeader.Enabled = False
        Me.pnlHeader.Location = New System.Drawing.Point(12, 16)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1130, 39)
        Me.pnlHeader.TabIndex = 0
        '
        'TxtTotalChq
        '
        Me.TxtTotalChq.Location = New System.Drawing.Point(779, 8)
        Me.TxtTotalChq.Name = "TxtTotalChq"
        Me.TxtTotalChq.ReadOnly = True
        Me.TxtTotalChq.Size = New System.Drawing.Size(56, 21)
        Me.TxtTotalChq.TabIndex = 4
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(719, 12)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(60, 13)
        Me.Label19.TabIndex = 14
        Me.Label19.Text = "Total Chq"
        '
        'TxtLotNo
        '
        Me.TxtLotNo.Location = New System.Drawing.Point(638, 8)
        Me.TxtLotNo.Name = "TxtLotNo"
        Me.TxtLotNo.ReadOnly = True
        Me.TxtLotNo.Size = New System.Drawing.Size(77, 21)
        Me.TxtLotNo.TabIndex = 3
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(592, 12)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(42, 13)
        Me.Label18.TabIndex = 12
        Me.Label18.Text = "Lot No"
        '
        'TxtPacketId
        '
        Me.TxtPacketId.Location = New System.Drawing.Point(3, 28)
        Me.TxtPacketId.Name = "TxtPacketId"
        Me.TxtPacketId.Size = New System.Drawing.Size(21, 21)
        Me.TxtPacketId.TabIndex = 10
        Me.TxtPacketId.Visible = False
        '
        'TxtEntityName
        '
        Me.TxtEntityName.Location = New System.Drawing.Point(919, 8)
        Me.TxtEntityName.Name = "TxtEntityName"
        Me.TxtEntityName.ReadOnly = True
        Me.TxtEntityName.Size = New System.Drawing.Size(206, 21)
        Me.TxtEntityName.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(841, 12)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(75, 13)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Entity Name"
        '
        'TxtContractNo
        '
        Me.TxtContractNo.Location = New System.Drawing.Point(457, 8)
        Me.TxtContractNo.Name = "TxtContractNo"
        Me.TxtContractNo.ReadOnly = True
        Me.TxtContractNo.Size = New System.Drawing.Size(130, 21)
        Me.TxtContractNo.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(380, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Contract No"
        '
        'TxtCoverNo
        '
        Me.TxtCoverNo.Location = New System.Drawing.Point(243, 8)
        Me.TxtCoverNo.Name = "TxtCoverNo"
        Me.TxtCoverNo.ReadOnly = True
        Me.TxtCoverNo.Size = New System.Drawing.Size(130, 21)
        Me.TxtCoverNo.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(181, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Cover No"
        '
        'dtbPacketRecv
        '
        Me.dtbPacketRecv.CustomFormat = "dd-MM-yyyy"
        Me.dtbPacketRecv.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtbPacketRecv.Location = New System.Drawing.Point(75, 8)
        Me.dtbPacketRecv.Name = "dtbPacketRecv"
        Me.dtbPacketRecv.Size = New System.Drawing.Size(103, 21)
        Me.dtbPacketRecv.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(4, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Rcvd Date"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Packet Details"
        '
        'PicFrontSide
        '
        Me.PicFrontSide.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PicFrontSide.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PicFrontSide.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PicFrontSide.ErrorImage = Nothing
        Me.PicFrontSide.Location = New System.Drawing.Point(213, 86)
        Me.PicFrontSide.Name = "PicFrontSide"
        Me.PicFrontSide.Size = New System.Drawing.Size(123, 212)
        Me.PicFrontSide.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicFrontSide.TabIndex = 22
        Me.PicFrontSide.TabStop = False
        '
        'PicBackSide
        '
        Me.PicBackSide.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PicBackSide.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PicBackSide.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PicBackSide.ErrorImage = Nothing
        Me.PicBackSide.Location = New System.Drawing.Point(47, 86)
        Me.PicBackSide.Name = "PicBackSide"
        Me.PicBackSide.Size = New System.Drawing.Size(133, 223)
        Me.PicBackSide.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicBackSide.TabIndex = 23
        Me.PicBackSide.TabStop = False
        Me.PicBackSide.Visible = False
        '
        'pnlEntry
        '
        Me.pnlEntry.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlEntry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlEntry.Controls.Add(Me.RdiChqNo)
        Me.pnlEntry.Controls.Add(Me.RdiChqYes)
        Me.pnlEntry.Controls.Add(Me.Label14)
        Me.pnlEntry.Controls.Add(Me.CboPcktMode)
        Me.pnlEntry.Controls.Add(Me.Label7)
        Me.pnlEntry.Location = New System.Drawing.Point(887, 61)
        Me.pnlEntry.Name = "pnlEntry"
        Me.pnlEntry.Size = New System.Drawing.Size(253, 56)
        Me.pnlEntry.TabIndex = 1
        '
        'RdiChqNo
        '
        Me.RdiChqNo.AutoSize = True
        Me.RdiChqNo.Location = New System.Drawing.Point(166, 7)
        Me.RdiChqNo.Name = "RdiChqNo"
        Me.RdiChqNo.Size = New System.Drawing.Size(39, 17)
        Me.RdiChqNo.TabIndex = 1
        Me.RdiChqNo.TabStop = True
        Me.RdiChqNo.Text = "No"
        Me.RdiChqNo.UseVisualStyleBackColor = True
        '
        'RdiChqYes
        '
        Me.RdiChqYes.AutoSize = True
        Me.RdiChqYes.Checked = True
        Me.RdiChqYes.Location = New System.Drawing.Point(116, 7)
        Me.RdiChqYes.Name = "RdiChqYes"
        Me.RdiChqYes.Size = New System.Drawing.Size(45, 17)
        Me.RdiChqYes.TabIndex = 0
        Me.RdiChqYes.TabStop = True
        Me.RdiChqYes.Text = "Yes"
        Me.RdiChqYes.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(4, 9)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(88, 13)
        Me.Label14.TabIndex = 45
        Me.Label14.Text = "Cheque Visible"
        '
        'CboPcktMode
        '
        Me.CboPcktMode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CboPcktMode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CboPcktMode.FormattingEnabled = True
        Me.CboPcktMode.Items.AddRange(New Object() {"PDC", "SPDC", "Others"})
        Me.CboPcktMode.Location = New System.Drawing.Point(116, 29)
        Me.CboPcktMode.Name = "CboPcktMode"
        Me.CboPcktMode.Size = New System.Drawing.Size(131, 21)
        Me.CboPcktMode.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(4, 33)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(62, 13)
        Me.Label7.TabIndex = 28
        Me.Label7.Text = "Pay Mode"
        '
        'TxtDiscValue
        '
        Me.TxtDiscValue.Location = New System.Drawing.Point(43, 213)
        Me.TxtDiscValue.Name = "TxtDiscValue"
        Me.TxtDiscValue.Size = New System.Drawing.Size(24, 21)
        Me.TxtDiscValue.TabIndex = 6
        Me.TxtDiscValue.Visible = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.RdoYetConfirm)
        Me.Panel2.Controls.Add(Me.RdiYes)
        Me.Panel2.Controls.Add(Me.RdiNo)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.btnAdd)
        Me.Panel2.Location = New System.Drawing.Point(2, 111)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(247, 49)
        Me.Panel2.TabIndex = 3
        '
        'RdoYetConfirm
        '
        Me.RdoYetConfirm.AutoSize = True
        Me.RdoYetConfirm.Checked = True
        Me.RdoYetConfirm.ForeColor = System.Drawing.Color.Blue
        Me.RdoYetConfirm.Location = New System.Drawing.Point(95, 26)
        Me.RdoYetConfirm.Name = "RdoYetConfirm"
        Me.RdoYetConfirm.Size = New System.Drawing.Size(106, 17)
        Me.RdoYetConfirm.TabIndex = 2
        Me.RdoYetConfirm.TabStop = True
        Me.RdoYetConfirm.Text = "Yet to Confirm"
        Me.RdoYetConfirm.UseVisualStyleBackColor = True
        '
        'RdiYes
        '
        Me.RdiYes.AutoSize = True
        Me.RdiYes.ForeColor = System.Drawing.Color.Red
        Me.RdiYes.Location = New System.Drawing.Point(5, 26)
        Me.RdiYes.Name = "RdiYes"
        Me.RdiYes.Size = New System.Drawing.Size(45, 17)
        Me.RdiYes.TabIndex = 0
        Me.RdiYes.Text = "&Yes"
        Me.RdiYes.UseVisualStyleBackColor = True
        '
        'RdiNo
        '
        Me.RdiNo.AutoSize = True
        Me.RdiNo.ForeColor = System.Drawing.Color.ForestGreen
        Me.RdiNo.Location = New System.Drawing.Point(52, 26)
        Me.RdiNo.Name = "RdiNo"
        Me.RdiNo.Size = New System.Drawing.Size(39, 17)
        Me.RdiNo.TabIndex = 1
        Me.RdiNo.Text = "&No"
        Me.RdiNo.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.SystemColors.Control
        Me.Label12.Cursor = System.Windows.Forms.Cursors.SizeNESW
        Me.Label12.Location = New System.Drawing.Point(2, 5)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(30, 13)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Disc"
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(205, 23)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(37, 23)
        Me.btnAdd.TabIndex = 1
        Me.btnAdd.Text = "&Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'TxtRemarks
        '
        Me.TxtRemarks.BackColor = System.Drawing.SystemColors.Window
        Me.TxtRemarks.Location = New System.Drawing.Point(4, 181)
        Me.TxtRemarks.Name = "TxtRemarks"
        Me.TxtRemarks.Size = New System.Drawing.Size(243, 21)
        Me.TxtRemarks.TabIndex = 4
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(4, 164)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(58, 13)
        Me.Label13.TabIndex = 3
        Me.Label13.Text = "Remarks"
        '
        'mstchqdate
        '
        Me.mstchqdate.Location = New System.Drawing.Point(115, 5)
        Me.mstchqdate.Mask = "00/00/0000"
        Me.mstchqdate.Name = "mstchqdate"
        Me.mstchqdate.Size = New System.Drawing.Size(131, 21)
        Me.mstchqdate.TabIndex = 0
        Me.mstchqdate.ValidatingType = GetType(Date)
        '
        'TxtBankName
        '
        Me.TxtBankName.Location = New System.Drawing.Point(3, 46)
        Me.TxtBankName.Name = "TxtBankName"
        Me.TxtBankName.Size = New System.Drawing.Size(241, 21)
        Me.TxtBankName.TabIndex = 1
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.SystemColors.Control
        Me.Label11.Cursor = System.Windows.Forms.Cursors.SizeNESW
        Me.Label11.Location = New System.Drawing.Point(4, 30)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(70, 13)
        Me.Label11.TabIndex = 36
        Me.Label11.Text = "Bank Name"
        '
        'TxtBankCode
        '
        Me.TxtBankCode.Location = New System.Drawing.Point(116, 2)
        Me.TxtBankCode.Name = "TxtBankCode"
        Me.TxtBankCode.Size = New System.Drawing.Size(131, 21)
        Me.TxtBankCode.TabIndex = 0
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.SystemColors.Control
        Me.Label9.Cursor = System.Windows.Forms.Cursors.SizeNESW
        Me.Label9.Location = New System.Drawing.Point(4, 6)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(66, 13)
        Me.Label9.TabIndex = 34
        Me.Label9.Text = "Bank Code"
        '
        'TxtMicrCode
        '
        Me.TxtMicrCode.Location = New System.Drawing.Point(116, 34)
        Me.TxtMicrCode.Name = "TxtMicrCode"
        Me.TxtMicrCode.Size = New System.Drawing.Size(131, 21)
        Me.TxtMicrCode.TabIndex = 1
        Me.TxtMicrCode.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.Cursor = System.Windows.Forms.Cursors.SizeNESW
        Me.Label8.Location = New System.Drawing.Point(4, 38)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(62, 13)
        Me.Label8.TabIndex = 32
        Me.Label8.Text = "Micr Code"
        '
        'TxtChqNo
        '
        Me.TxtChqNo.Location = New System.Drawing.Point(116, 5)
        Me.TxtChqNo.Name = "TxtChqNo"
        Me.TxtChqNo.Size = New System.Drawing.Size(131, 21)
        Me.TxtChqNo.TabIndex = 0
        Me.TxtChqNo.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.SizeNESW
        Me.Label5.Location = New System.Drawing.Point(4, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 13)
        Me.Label5.TabIndex = 30
        Me.Label5.Text = "Cheque No"
        '
        'txtCtsChqAmt
        '
        Me.txtCtsChqAmt.Location = New System.Drawing.Point(4, 213)
        Me.txtCtsChqAmt.Name = "txtCtsChqAmt"
        Me.txtCtsChqAmt.Size = New System.Drawing.Size(28, 21)
        Me.txtCtsChqAmt.TabIndex = 5
        Me.txtCtsChqAmt.Visible = False
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(167, 208)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(81, 28)
        Me.btnCancel.TabIndex = 8
        Me.btnCancel.Text = "&Close"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(80, 208)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(81, 28)
        Me.btnSave.TabIndex = 7
        Me.btnSave.Text = "&Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'txtaccno
        '
        Me.txtaccno.BackColor = System.Drawing.SystemColors.Window
        Me.txtaccno.Location = New System.Drawing.Point(3, 88)
        Me.txtaccno.Name = "txtaccno"
        Me.txtaccno.Size = New System.Drawing.Size(241, 21)
        Me.txtaccno.TabIndex = 2
        '
        'txtchqamt
        '
        Me.txtchqamt.Location = New System.Drawing.Point(115, 32)
        Me.txtchqamt.Name = "txtchqamt"
        Me.txtchqamt.Size = New System.Drawing.Size(131, 21)
        Me.txtchqamt.TabIndex = 1
        '
        'lblaccno
        '
        Me.lblaccno.AutoSize = True
        Me.lblaccno.Location = New System.Drawing.Point(4, 72)
        Me.lblaccno.Name = "lblaccno"
        Me.lblaccno.Size = New System.Drawing.Size(91, 13)
        Me.lblaccno.TabIndex = 2
        Me.lblaccno.Text = "Drawee A/C No"
        '
        'lblchqamt
        '
        Me.lblchqamt.AutoSize = True
        Me.lblchqamt.Location = New System.Drawing.Point(4, 36)
        Me.lblchqamt.Name = "lblchqamt"
        Me.lblchqamt.Size = New System.Drawing.Size(97, 13)
        Me.lblchqamt.TabIndex = 23
        Me.lblchqamt.Text = "Cheque Amount"
        '
        'lblchqdate
        '
        Me.lblchqdate.AutoSize = True
        Me.lblchqdate.BackColor = System.Drawing.SystemColors.Control
        Me.lblchqdate.Cursor = System.Windows.Forms.Cursors.SizeNESW
        Me.lblchqdate.Location = New System.Drawing.Point(4, 9)
        Me.lblchqdate.Name = "lblchqdate"
        Me.lblchqdate.Size = New System.Drawing.Size(79, 13)
        Me.lblchqdate.TabIndex = 21
        Me.lblchqdate.Text = "Cheque Date"
        '
        'Pnlchqdtls
        '
        Me.Pnlchqdtls.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pnlchqdtls.Controls.Add(Me.Label5)
        Me.Pnlchqdtls.Controls.Add(Me.TxtChqNo)
        Me.Pnlchqdtls.Controls.Add(Me.Label8)
        Me.Pnlchqdtls.Controls.Add(Me.TxtMicrCode)
        Me.Pnlchqdtls.Location = New System.Drawing.Point(887, 118)
        Me.Pnlchqdtls.Name = "Pnlchqdtls"
        Me.Pnlchqdtls.Size = New System.Drawing.Size(253, 58)
        Me.Pnlchqdtls.TabIndex = 2
        '
        'PnlPdcEntry
        '
        Me.PnlPdcEntry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PnlPdcEntry.Controls.Add(Me.mstchqdate)
        Me.PnlPdcEntry.Controls.Add(Me.txtchqamt)
        Me.PnlPdcEntry.Controls.Add(Me.lblchqamt)
        Me.PnlPdcEntry.Controls.Add(Me.lblchqdate)
        Me.PnlPdcEntry.Location = New System.Drawing.Point(886, 181)
        Me.PnlPdcEntry.Name = "PnlPdcEntry"
        Me.PnlPdcEntry.Size = New System.Drawing.Size(253, 59)
        Me.PnlPdcEntry.TabIndex = 3
        '
        'PnlBankdtls
        '
        Me.PnlBankdtls.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PnlBankdtls.Controls.Add(Me.btnCancel)
        Me.PnlBankdtls.Controls.Add(Me.btnSave)
        Me.PnlBankdtls.Controls.Add(Me.Panel2)
        Me.PnlBankdtls.Controls.Add(Me.txtCtsChqAmt)
        Me.PnlBankdtls.Controls.Add(Me.txtaccno)
        Me.PnlBankdtls.Controls.Add(Me.TxtDiscValue)
        Me.PnlBankdtls.Controls.Add(Me.Label9)
        Me.PnlBankdtls.Controls.Add(Me.Label13)
        Me.PnlBankdtls.Controls.Add(Me.TxtBankCode)
        Me.PnlBankdtls.Controls.Add(Me.TxtRemarks)
        Me.PnlBankdtls.Controls.Add(Me.lblaccno)
        Me.PnlBankdtls.Controls.Add(Me.Label11)
        Me.PnlBankdtls.Controls.Add(Me.TxtBankName)
        Me.PnlBankdtls.Location = New System.Drawing.Point(887, 241)
        Me.PnlBankdtls.Name = "PnlBankdtls"
        Me.PnlBankdtls.Size = New System.Drawing.Size(253, 239)
        Me.PnlBankdtls.TabIndex = 4
        '
        'TabChqDetails
        '
        Me.TabChqDetails.Controls.Add(Me.TabChqDtls)
        Me.TabChqDetails.Controls.Add(Me.TabInward)
        Me.TabChqDetails.Location = New System.Drawing.Point(2, 593)
        Me.TabChqDetails.Name = "TabChqDetails"
        Me.TabChqDetails.SelectedIndex = 0
        Me.TabChqDetails.Size = New System.Drawing.Size(1151, 153)
        Me.TabChqDetails.TabIndex = 26
        '
        'TabChqDtls
        '
        Me.TabChqDtls.Controls.Add(Me.gvmChkrEntry)
        Me.TabChqDtls.Controls.Add(Me.rdoPending)
        Me.TabChqDtls.Controls.Add(Me.rdoCompleted)
        Me.TabChqDtls.Location = New System.Drawing.Point(4, 22)
        Me.TabChqDtls.Name = "TabChqDtls"
        Me.TabChqDtls.Padding = New System.Windows.Forms.Padding(3)
        Me.TabChqDtls.Size = New System.Drawing.Size(1143, 127)
        Me.TabChqDtls.TabIndex = 0
        Me.TabChqDtls.Text = "Cheque Details"
        Me.TabChqDtls.UseVisualStyleBackColor = True
        '
        'gvmChkrEntry
        '
        Me.gvmChkrEntry.AllowUserToAddRows = False
        Me.gvmChkrEntry.AllowUserToDeleteRows = False
        Me.gvmChkrEntry.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gvmChkrEntry.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.gvmChkrEntry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvmChkrEntry.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6})
        Me.gvmChkrEntry.Location = New System.Drawing.Point(3, 21)
        Me.gvmChkrEntry.MultiSelect = False
        Me.gvmChkrEntry.Name = "gvmChkrEntry"
        Me.gvmChkrEntry.ReadOnly = True
        Me.gvmChkrEntry.Size = New System.Drawing.Size(1137, 182)
        Me.gvmChkrEntry.TabIndex = 100
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "ChqId"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Serial No"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Cheque No"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Micr Code"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Tran Code"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "Base Code"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'rdoPending
        '
        Me.rdoPending.AutoSize = True
        Me.rdoPending.Checked = True
        Me.rdoPending.ForeColor = System.Drawing.Color.Red
        Me.rdoPending.Location = New System.Drawing.Point(127, 1)
        Me.rdoPending.Name = "rdoPending"
        Me.rdoPending.Size = New System.Drawing.Size(70, 17)
        Me.rdoPending.TabIndex = 1
        Me.rdoPending.TabStop = True
        Me.rdoPending.Text = "Pending"
        Me.rdoPending.UseVisualStyleBackColor = True
        '
        'rdoCompleted
        '
        Me.rdoCompleted.AutoSize = True
        Me.rdoCompleted.ForeColor = System.Drawing.Color.DarkGreen
        Me.rdoCompleted.Location = New System.Drawing.Point(16, 1)
        Me.rdoCompleted.Name = "rdoCompleted"
        Me.rdoCompleted.Size = New System.Drawing.Size(86, 17)
        Me.rdoCompleted.TabIndex = 0
        Me.rdoCompleted.Text = "Completed"
        Me.rdoCompleted.UseVisualStyleBackColor = True
        '
        'TabInward
        '
        Me.TabInward.Controls.Add(Me.gvmInwardDetails)
        Me.TabInward.Location = New System.Drawing.Point(4, 22)
        Me.TabInward.Name = "TabInward"
        Me.TabInward.Padding = New System.Windows.Forms.Padding(3)
        Me.TabInward.Size = New System.Drawing.Size(1143, 127)
        Me.TabInward.TabIndex = 1
        Me.TabInward.Text = "Inward Details"
        Me.TabInward.UseVisualStyleBackColor = True
        '
        'gvmInwardDetails
        '
        Me.gvmInwardDetails.AllowUserToAddRows = False
        Me.gvmInwardDetails.AllowUserToDeleteRows = False
        Me.gvmInwardDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gvmInwardDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.gvmInwardDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvmInwardDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.api_gid, Me.lot_no, Me.contract_no, Me.payee_name, Me.chq_date, Me.cycle_date, Me.chq_no, Me.chq_amount, Me.chq_acc_no})
        Me.gvmInwardDetails.Location = New System.Drawing.Point(3, 2)
        Me.gvmInwardDetails.MultiSelect = False
        Me.gvmInwardDetails.Name = "gvmInwardDetails"
        Me.gvmInwardDetails.ReadOnly = True
        Me.gvmInwardDetails.Size = New System.Drawing.Size(1137, 199)
        Me.gvmInwardDetails.TabIndex = 0
        '
        'api_gid
        '
        Me.api_gid.HeaderText = "Api Gid"
        Me.api_gid.Name = "api_gid"
        Me.api_gid.ReadOnly = True
        Me.api_gid.Visible = False
        '
        'lot_no
        '
        Me.lot_no.HeaderText = "Lot No"
        Me.lot_no.Name = "lot_no"
        Me.lot_no.ReadOnly = True
        '
        'contract_no
        '
        Me.contract_no.HeaderText = "Contract No"
        Me.contract_no.Name = "contract_no"
        Me.contract_no.ReadOnly = True
        '
        'payee_name
        '
        Me.payee_name.HeaderText = "Payee Name"
        Me.payee_name.Name = "payee_name"
        Me.payee_name.ReadOnly = True
        '
        'chq_date
        '
        Me.chq_date.HeaderText = "Chq Date"
        Me.chq_date.Name = "chq_date"
        Me.chq_date.ReadOnly = True
        '
        'cycle_date
        '
        Me.cycle_date.HeaderText = "Cycle Date"
        Me.cycle_date.Name = "cycle_date"
        Me.cycle_date.ReadOnly = True
        '
        'chq_no
        '
        Me.chq_no.HeaderText = "chq No"
        Me.chq_no.Name = "chq_no"
        Me.chq_no.ReadOnly = True
        '
        'chq_amount
        '
        Me.chq_amount.HeaderText = "Chq Amount"
        Me.chq_amount.Name = "chq_amount"
        Me.chq_amount.ReadOnly = True
        '
        'chq_acc_no
        '
        Me.chq_acc_no.HeaderText = "Chq Acc No"
        Me.chq_acc_no.Name = "chq_acc_no"
        Me.chq_acc_no.ReadOnly = True
        '
        'pnlcustinfo
        '
        Me.pnlcustinfo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlcustinfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlcustinfo.Controls.Add(Me.txtCustname)
        Me.pnlcustinfo.Controls.Add(Me.cboProdcode)
        Me.pnlcustinfo.Controls.Add(Me.lblProduct)
        Me.pnlcustinfo.Controls.Add(Me.lblCustName)
        Me.pnlcustinfo.Controls.Add(Me.cmbLoc)
        Me.pnlcustinfo.Controls.Add(Me.lblLoc)
        Me.pnlcustinfo.Location = New System.Drawing.Point(887, 482)
        Me.pnlcustinfo.Name = "pnlcustinfo"
        Me.pnlcustinfo.Size = New System.Drawing.Size(253, 111)
        Me.pnlcustinfo.TabIndex = 5
        '
        'txtCustname
        '
        Me.txtCustname.BackColor = System.Drawing.SystemColors.Window
        Me.txtCustname.Enabled = False
        Me.txtCustname.Location = New System.Drawing.Point(4, 28)
        Me.txtCustname.Name = "txtCustname"
        Me.txtCustname.Size = New System.Drawing.Size(243, 21)
        Me.txtCustname.TabIndex = 0
        '
        'cboProdcode
        '
        Me.cboProdcode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboProdcode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboProdcode.Enabled = False
        Me.cboProdcode.FormattingEnabled = True
        Me.cboProdcode.Items.AddRange(New Object() {"PDC", "SPDC", "Others"})
        Me.cboProdcode.Location = New System.Drawing.Point(116, 83)
        Me.cboProdcode.Name = "cboProdcode"
        Me.cboProdcode.Size = New System.Drawing.Size(131, 21)
        Me.cboProdcode.TabIndex = 2
        '
        'lblProduct
        '
        Me.lblProduct.AutoSize = True
        Me.lblProduct.Location = New System.Drawing.Point(4, 87)
        Me.lblProduct.Name = "lblProduct"
        Me.lblProduct.Size = New System.Drawing.Size(51, 13)
        Me.lblProduct.TabIndex = 47
        Me.lblProduct.Text = "Product"
        '
        'lblCustName
        '
        Me.lblCustName.AutoSize = True
        Me.lblCustName.Location = New System.Drawing.Point(4, 9)
        Me.lblCustName.Name = "lblCustName"
        Me.lblCustName.Size = New System.Drawing.Size(97, 13)
        Me.lblCustName.TabIndex = 45
        Me.lblCustName.Text = "Customer Name"
        '
        'cmbLoc
        '
        Me.cmbLoc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbLoc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbLoc.Enabled = False
        Me.cmbLoc.FormattingEnabled = True
        Me.cmbLoc.Items.AddRange(New Object() {"PDC", "SPDC", "Others"})
        Me.cmbLoc.Location = New System.Drawing.Point(116, 55)
        Me.cmbLoc.Name = "cmbLoc"
        Me.cmbLoc.Size = New System.Drawing.Size(131, 21)
        Me.cmbLoc.TabIndex = 1
        '
        'lblLoc
        '
        Me.lblLoc.AutoSize = True
        Me.lblLoc.Location = New System.Drawing.Point(4, 59)
        Me.lblLoc.Name = "lblLoc"
        Me.lblLoc.Size = New System.Drawing.Size(55, 13)
        Me.lblLoc.TabIndex = 28
        Me.lblLoc.Text = "Location"
        '
        'frmImageBaseEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1154, 749)
        Me.Controls.Add(Me.pnlcustinfo)
        Me.Controls.Add(Me.TabChqDetails)
        Me.Controls.Add(Me.pnlEntry)
        Me.Controls.Add(Me.PicFrontSide)
        Me.Controls.Add(Me.PicBackSide)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.pnlHeader)
        Me.Controls.Add(Me.PnlPdcEntry)
        Me.Controls.Add(Me.PnlBankdtls)
        Me.Controls.Add(Me.Pnlchqdtls)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmImageBaseEntry"
        Me.Text = "Image Base Entry"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        CType(Me.PicFrontSide, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicBackSide, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlEntry.ResumeLayout(False)
        Me.pnlEntry.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Pnlchqdtls.ResumeLayout(False)
        Me.Pnlchqdtls.PerformLayout()
        Me.PnlPdcEntry.ResumeLayout(False)
        Me.PnlPdcEntry.PerformLayout()
        Me.PnlBankdtls.ResumeLayout(False)
        Me.PnlBankdtls.PerformLayout()
        Me.TabChqDetails.ResumeLayout(False)
        Me.TabChqDtls.ResumeLayout(False)
        Me.TabChqDtls.PerformLayout()
        CType(Me.gvmChkrEntry, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabInward.ResumeLayout(False)
        CType(Me.gvmInwardDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlcustinfo.ResumeLayout(False)
        Me.pnlcustinfo.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtbPacketRecv As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtCoverNo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtContractNo As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtEntityName As System.Windows.Forms.TextBox
    Private WithEvents PicFrontSide As System.Windows.Forms.PictureBox
    Private WithEvents PicBackSide As System.Windows.Forms.PictureBox
    Private WithEvents pnlEntry As System.Windows.Forms.Panel
    Private WithEvents txtCtsChqAmt As System.Windows.Forms.TextBox
    Private WithEvents btnCancel As System.Windows.Forms.Button
    Private WithEvents btnSave As System.Windows.Forms.Button
    Private WithEvents txtaccno As System.Windows.Forms.TextBox
    Private WithEvents txtchqamt As System.Windows.Forms.TextBox
    Private WithEvents lblaccno As System.Windows.Forms.Label
    Private WithEvents lblchqamt As System.Windows.Forms.Label
    Private WithEvents lblchqdate As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents CboPcktMode As System.Windows.Forms.ComboBox
    Friend WithEvents TxtPacketId As System.Windows.Forms.TextBox
    Private WithEvents TxtChqNo As System.Windows.Forms.TextBox
    Private WithEvents Label5 As System.Windows.Forms.Label
    Private WithEvents TxtMicrCode As System.Windows.Forms.TextBox
    Private WithEvents Label8 As System.Windows.Forms.Label
    Private WithEvents TxtBankCode As System.Windows.Forms.TextBox
    Private WithEvents Label9 As System.Windows.Forms.Label
    Private WithEvents Label11 As System.Windows.Forms.Label
    Private WithEvents TxtBankName As System.Windows.Forms.TextBox
    Private WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents RdiYes As System.Windows.Forms.RadioButton
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents TxtDiscValue As System.Windows.Forms.TextBox
    Friend WithEvents mstchqdate As System.Windows.Forms.MaskedTextBox
    Private WithEvents Label13 As System.Windows.Forms.Label
    Private WithEvents TxtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents RdiChqNo As System.Windows.Forms.RadioButton
    Private WithEvents RdiNo As System.Windows.Forms.RadioButton
    Private WithEvents RdiChqYes As System.Windows.Forms.RadioButton
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents RdoYetConfirm As System.Windows.Forms.RadioButton
    Friend WithEvents Pnlchqdtls As System.Windows.Forms.Panel
    Friend WithEvents PnlPdcEntry As System.Windows.Forms.Panel
    Friend WithEvents PnlBankdtls As System.Windows.Forms.Panel
    Friend WithEvents TxtLotNo As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents TxtTotalChq As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents TabChqDetails As System.Windows.Forms.TabControl
    Friend WithEvents TabChqDtls As System.Windows.Forms.TabPage
    Friend WithEvents TabInward As System.Windows.Forms.TabPage
    Friend WithEvents gvmInwardDetails As System.Windows.Forms.DataGridView
    Friend WithEvents api_gid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lot_no As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents contract_no As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents payee_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chq_date As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cycle_date As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chq_no As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chq_amount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chq_acc_no As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents gvmChkrEntry As System.Windows.Forms.DataGridView
    Private WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rdoPending As System.Windows.Forms.RadioButton
    Friend WithEvents rdoCompleted As System.Windows.Forms.RadioButton
    Private WithEvents pnlcustinfo As System.Windows.Forms.Panel
    Private WithEvents txtCustname As System.Windows.Forms.TextBox
    Friend WithEvents cboProdcode As System.Windows.Forms.ComboBox
    Friend WithEvents lblProduct As System.Windows.Forms.Label
    Friend WithEvents lblCustName As System.Windows.Forms.Label
    Friend WithEvents cmbLoc As System.Windows.Forms.ComboBox
    Friend WithEvents lblLoc As System.Windows.Forms.Label
End Class
