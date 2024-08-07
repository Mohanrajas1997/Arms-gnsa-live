<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSearchReport
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TxtLotNo = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.TxtPacketId = New System.Windows.Forms.TextBox()
        Me.TxtContractNo = New System.Windows.Forms.TextBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtCoverNo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtbPacketRecv = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtTotalChq = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.TxtEntityName = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PicFrontSide = New System.Windows.Forms.PictureBox()
        Me.PicBackSide = New System.Windows.Forms.PictureBox()
        Me.pnlEntry = New System.Windows.Forms.Panel()
        Me.TxtPaymode = New System.Windows.Forms.TextBox()
        Me.RdiChqNo = New System.Windows.Forms.RadioButton()
        Me.RdiChqYes = New System.Windows.Forms.RadioButton()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
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
        Me.txtaccno = New System.Windows.Forms.TextBox()
        Me.txtchqamt = New System.Windows.Forms.TextBox()
        Me.lblaccno = New System.Windows.Forms.Label()
        Me.lblchqamt = New System.Windows.Forms.Label()
        Me.lblchqdate = New System.Windows.Forms.Label()
        Me.pnlChq = New System.Windows.Forms.Panel()
        Me.gvmChkrEntry = New System.Windows.Forms.DataGridView()
        Me.Chq_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Serial_no = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cheque_No = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Micr_Code = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tran_code = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Base_Code = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.label10 = New System.Windows.Forms.Label()
        Me.Pnlchqdtls = New System.Windows.Forms.Panel()
        Me.PnlPdcEntry = New System.Windows.Forms.Panel()
        Me.PnlBankdtls = New System.Windows.Forms.Panel()
        Me.pnlHeader.SuspendLayout()
        CType(Me.PicFrontSide, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicBackSide, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlEntry.SuspendLayout()
        Me.pnlChq.SuspendLayout()
        CType(Me.gvmChkrEntry, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pnlchqdtls.SuspendLayout()
        Me.PnlPdcEntry.SuspendLayout()
        Me.PnlBankdtls.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlHeader.Controls.Add(Me.Button1)
        Me.pnlHeader.Controls.Add(Me.TxtLotNo)
        Me.pnlHeader.Controls.Add(Me.Label18)
        Me.pnlHeader.Controls.Add(Me.btnCancel)
        Me.pnlHeader.Controls.Add(Me.TxtPacketId)
        Me.pnlHeader.Controls.Add(Me.TxtContractNo)
        Me.pnlHeader.Controls.Add(Me.btnSave)
        Me.pnlHeader.Controls.Add(Me.Label4)
        Me.pnlHeader.Controls.Add(Me.TxtCoverNo)
        Me.pnlHeader.Controls.Add(Me.Label3)
        Me.pnlHeader.Controls.Add(Me.dtbPacketRecv)
        Me.pnlHeader.Controls.Add(Me.Label2)
        Me.pnlHeader.Location = New System.Drawing.Point(12, 16)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1037, 39)
        Me.pnlHeader.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(858, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(81, 28)
        Me.Button1.TabIndex = 13
        Me.Button1.Text = "Clear"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TxtLotNo
        '
        Me.TxtLotNo.Location = New System.Drawing.Point(638, 8)
        Me.TxtLotNo.Name = "TxtLotNo"
        Me.TxtLotNo.Size = New System.Drawing.Size(130, 21)
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
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(940, 3)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(81, 28)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "&Close"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'TxtPacketId
        '
        Me.TxtPacketId.Location = New System.Drawing.Point(3, 28)
        Me.TxtPacketId.Name = "TxtPacketId"
        Me.TxtPacketId.Size = New System.Drawing.Size(21, 21)
        Me.TxtPacketId.TabIndex = 10
        Me.TxtPacketId.Visible = False
        '
        'TxtContractNo
        '
        Me.TxtContractNo.Location = New System.Drawing.Point(457, 8)
        Me.TxtContractNo.Name = "TxtContractNo"
        Me.TxtContractNo.Size = New System.Drawing.Size(130, 21)
        Me.TxtContractNo.TabIndex = 2
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(776, 4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(81, 28)
        Me.btnSave.TabIndex = 5
        Me.btnSave.Text = "Refresh"
        Me.btnSave.UseVisualStyleBackColor = True
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
        'TxtTotalChq
        '
        Me.TxtTotalChq.Location = New System.Drawing.Point(115, 4)
        Me.TxtTotalChq.Name = "TxtTotalChq"
        Me.TxtTotalChq.Size = New System.Drawing.Size(131, 21)
        Me.TxtTotalChq.TabIndex = 4
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(4, 8)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(60, 13)
        Me.Label19.TabIndex = 14
        Me.Label19.Text = "Total Chq"
        '
        'TxtEntityName
        '
        Me.TxtEntityName.Location = New System.Drawing.Point(3, 46)
        Me.TxtEntityName.Name = "TxtEntityName"
        Me.TxtEntityName.Size = New System.Drawing.Size(241, 21)
        Me.TxtEntityName.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(4, 31)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(75, 13)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Entity Name"
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
        Me.pnlEntry.Controls.Add(Me.TxtPaymode)
        Me.pnlEntry.Controls.Add(Me.RdiChqNo)
        Me.pnlEntry.Controls.Add(Me.RdiChqYes)
        Me.pnlEntry.Controls.Add(Me.Label14)
        Me.pnlEntry.Controls.Add(Me.Label7)
        Me.pnlEntry.Location = New System.Drawing.Point(887, 61)
        Me.pnlEntry.Name = "pnlEntry"
        Me.pnlEntry.Size = New System.Drawing.Size(253, 56)
        Me.pnlEntry.TabIndex = 1
        '
        'TxtPaymode
        '
        Me.TxtPaymode.Location = New System.Drawing.Point(116, 29)
        Me.TxtPaymode.Name = "TxtPaymode"
        Me.TxtPaymode.Size = New System.Drawing.Size(131, 21)
        Me.TxtPaymode.TabIndex = 46
        Me.TxtPaymode.TabStop = False
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
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(4, 33)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(62, 13)
        Me.Label7.TabIndex = 28
        Me.Label7.Text = "Pay Mode"
        '
        'TxtRemarks
        '
        Me.TxtRemarks.BackColor = System.Drawing.SystemColors.Window
        Me.TxtRemarks.Location = New System.Drawing.Point(4, 201)
        Me.TxtRemarks.Name = "TxtRemarks"
        Me.TxtRemarks.Size = New System.Drawing.Size(243, 21)
        Me.TxtRemarks.TabIndex = 4
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(4, 184)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(58, 13)
        Me.Label13.TabIndex = 44
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
        Me.TxtBankName.Location = New System.Drawing.Point(3, 118)
        Me.TxtBankName.Name = "TxtBankName"
        Me.TxtBankName.Size = New System.Drawing.Size(241, 21)
        Me.TxtBankName.TabIndex = 1
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.SystemColors.Control
        Me.Label11.Cursor = System.Windows.Forms.Cursors.SizeNESW
        Me.Label11.Location = New System.Drawing.Point(4, 102)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(70, 13)
        Me.Label11.TabIndex = 36
        Me.Label11.Text = "Bank Name"
        '
        'TxtBankCode
        '
        Me.TxtBankCode.Location = New System.Drawing.Point(116, 74)
        Me.TxtBankCode.Name = "TxtBankCode"
        Me.TxtBankCode.Size = New System.Drawing.Size(131, 21)
        Me.TxtBankCode.TabIndex = 0
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.SystemColors.Control
        Me.Label9.Cursor = System.Windows.Forms.Cursors.SizeNESW
        Me.Label9.Location = New System.Drawing.Point(4, 78)
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
        'txtaccno
        '
        Me.txtaccno.BackColor = System.Drawing.SystemColors.Window
        Me.txtaccno.Location = New System.Drawing.Point(3, 160)
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
        Me.lblaccno.Location = New System.Drawing.Point(4, 144)
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
        'pnlChq
        '
        Me.pnlChq.Controls.Add(Me.gvmChkrEntry)
        Me.pnlChq.Controls.Add(Me.label10)
        Me.pnlChq.Location = New System.Drawing.Point(3, 523)
        Me.pnlChq.Name = "pnlChq"
        Me.pnlChq.Size = New System.Drawing.Size(1146, 227)
        Me.pnlChq.TabIndex = 25
        '
        'gvmChkrEntry
        '
        Me.gvmChkrEntry.AllowUserToAddRows = False
        Me.gvmChkrEntry.AllowUserToDeleteRows = False
        Me.gvmChkrEntry.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gvmChkrEntry.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.gvmChkrEntry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvmChkrEntry.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Chq_id, Me.Serial_no, Me.Cheque_No, Me.Micr_Code, Me.Tran_code, Me.Base_Code})
        Me.gvmChkrEntry.Location = New System.Drawing.Point(0, 18)
        Me.gvmChkrEntry.Name = "gvmChkrEntry"
        Me.gvmChkrEntry.ReadOnly = True
        Me.gvmChkrEntry.Size = New System.Drawing.Size(1137, 206)
        Me.gvmChkrEntry.TabIndex = 99
        '
        'Chq_id
        '
        Me.Chq_id.HeaderText = "ChqId"
        Me.Chq_id.Name = "Chq_id"
        Me.Chq_id.ReadOnly = True
        Me.Chq_id.Visible = False
        '
        'Serial_no
        '
        Me.Serial_no.HeaderText = "Serial No"
        Me.Serial_no.Name = "Serial_no"
        Me.Serial_no.ReadOnly = True
        '
        'Cheque_No
        '
        Me.Cheque_No.HeaderText = "Cheque No"
        Me.Cheque_No.Name = "Cheque_No"
        Me.Cheque_No.ReadOnly = True
        '
        'Micr_Code
        '
        Me.Micr_Code.HeaderText = "Micr Code"
        Me.Micr_Code.Name = "Micr_Code"
        Me.Micr_Code.ReadOnly = True
        '
        'Tran_code
        '
        Me.Tran_code.HeaderText = "Tran Code"
        Me.Tran_code.Name = "Tran_code"
        Me.Tran_code.ReadOnly = True
        '
        'Base_Code
        '
        Me.Base_Code.HeaderText = "Base Code"
        Me.Base_Code.Name = "Base_Code"
        Me.Base_Code.ReadOnly = True
        '
        'label10
        '
        Me.label10.AutoSize = True
        Me.label10.Font = New System.Drawing.Font("Tahoma", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label10.Location = New System.Drawing.Point(3, -1)
        Me.label10.Name = "label10"
        Me.label10.Size = New System.Drawing.Size(91, 13)
        Me.label10.TabIndex = 3
        Me.label10.Text = "Cheque Details"
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
        Me.PnlBankdtls.Controls.Add(Me.TxtTotalChq)
        Me.PnlBankdtls.Controls.Add(Me.Label19)
        Me.PnlBankdtls.Controls.Add(Me.TxtEntityName)
        Me.PnlBankdtls.Controls.Add(Me.Label6)
        Me.PnlBankdtls.Controls.Add(Me.txtaccno)
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
        'frmSearchReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1154, 749)
        Me.Controls.Add(Me.pnlChq)
        Me.Controls.Add(Me.pnlEntry)
        Me.Controls.Add(Me.PicFrontSide)
        Me.Controls.Add(Me.PicBackSide)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.pnlHeader)
        Me.Controls.Add(Me.PnlPdcEntry)
        Me.Controls.Add(Me.PnlBankdtls)
        Me.Controls.Add(Me.Pnlchqdtls)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmSearchReport"
        Me.Text = "Search Report(Image Based)"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        CType(Me.PicFrontSide, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicBackSide, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlEntry.ResumeLayout(False)
        Me.pnlEntry.PerformLayout()
        Me.pnlChq.ResumeLayout(False)
        Me.pnlChq.PerformLayout()
        CType(Me.gvmChkrEntry, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pnlchqdtls.ResumeLayout(False)
        Me.Pnlchqdtls.PerformLayout()
        Me.PnlPdcEntry.ResumeLayout(False)
        Me.PnlPdcEntry.PerformLayout()
        Me.PnlBankdtls.ResumeLayout(False)
        Me.PnlBankdtls.PerformLayout()
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
    Private WithEvents btnCancel As System.Windows.Forms.Button
    Private WithEvents btnSave As System.Windows.Forms.Button
    Private WithEvents txtaccno As System.Windows.Forms.TextBox
    Private WithEvents txtchqamt As System.Windows.Forms.TextBox
    Private WithEvents lblaccno As System.Windows.Forms.Label
    Private WithEvents lblchqamt As System.Windows.Forms.Label
    Private WithEvents lblchqdate As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Private WithEvents pnlChq As System.Windows.Forms.Panel
    Private WithEvents gvmChkrEntry As System.Windows.Forms.DataGridView
    Private WithEvents Chq_id As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents Serial_no As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents Cheque_No As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents Micr_Code As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents Tran_code As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents Base_Code As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents label10 As System.Windows.Forms.Label
    Friend WithEvents TxtPacketId As System.Windows.Forms.TextBox
    Private WithEvents TxtChqNo As System.Windows.Forms.TextBox
    Private WithEvents Label5 As System.Windows.Forms.Label
    Private WithEvents TxtMicrCode As System.Windows.Forms.TextBox
    Private WithEvents Label8 As System.Windows.Forms.Label
    Private WithEvents TxtBankCode As System.Windows.Forms.TextBox
    Private WithEvents Label9 As System.Windows.Forms.Label
    Private WithEvents Label11 As System.Windows.Forms.Label
    Private WithEvents TxtBankName As System.Windows.Forms.TextBox
    Friend WithEvents mstchqdate As System.Windows.Forms.MaskedTextBox
    Private WithEvents Label13 As System.Windows.Forms.Label
    Private WithEvents TxtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents RdiChqNo As System.Windows.Forms.RadioButton
    Private WithEvents RdiChqYes As System.Windows.Forms.RadioButton
    Friend WithEvents Pnlchqdtls As System.Windows.Forms.Panel
    Friend WithEvents PnlPdcEntry As System.Windows.Forms.Panel
    Friend WithEvents PnlBankdtls As System.Windows.Forms.Panel
    Friend WithEvents TxtLotNo As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents TxtTotalChq As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Private WithEvents Button1 As System.Windows.Forms.Button
    Private WithEvents TxtPaymode As System.Windows.Forms.TextBox
End Class
