<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDispatch
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txtId = New System.Windows.Forms.TextBox()
        Me.lbAWBNo = New System.Windows.Forms.Label()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.TxtAwbNo = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CboCourierName = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.DtpDispatchDt = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDispatchBy = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboEntity = New System.Windows.Forms.ComboBox()
        Me.txtDispatchAddr = New System.Windows.Forms.TextBox()
        Me.lbentity = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnFind = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.pnlSave = New System.Windows.Forms.Panel()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.pnlButtons = New System.Windows.Forms.Panel()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.PnlPullout = New System.Windows.Forms.Panel()
        Me.BtnInverse = New System.Windows.Forms.Button()
        Me.BtnDeSelect = New System.Windows.Forms.Button()
        Me.BtnSelect = New System.Windows.Forms.Button()
        Me.TxtPulloutId = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpReqTo = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtpReqFrom = New System.Windows.Forms.DateTimePicker()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.CboPulloutEntity = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.dgvReport = New System.Windows.Forms.DataGridView()
        Me.lblRecCount = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.pnlMain.SuspendLayout()
        Me.pnlSave.SuspendLayout()
        Me.pnlButtons.SuspendLayout()
        Me.PnlPullout.SuspendLayout()
        CType(Me.dgvReport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtId
        '
        Me.txtId.Location = New System.Drawing.Point(-8, 1)
        Me.txtId.Name = "txtId"
        Me.txtId.Size = New System.Drawing.Size(27, 21)
        Me.txtId.TabIndex = 64
        Me.txtId.Visible = False
        '
        'lbAWBNo
        '
        Me.lbAWBNo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lbAWBNo.Location = New System.Drawing.Point(284, 61)
        Me.lbAWBNo.Name = "lbAWBNo"
        Me.lbAWBNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lbAWBNo.Size = New System.Drawing.Size(103, 16)
        Me.lbAWBNo.TabIndex = 10
        Me.lbAWBNo.Text = "Dispatch Addr"
        '
        'pnlMain
        '
        Me.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlMain.Controls.Add(Me.TxtAwbNo)
        Me.pnlMain.Controls.Add(Me.Label7)
        Me.pnlMain.Controls.Add(Me.CboCourierName)
        Me.pnlMain.Controls.Add(Me.Label6)
        Me.pnlMain.Controls.Add(Me.DtpDispatchDt)
        Me.pnlMain.Controls.Add(Me.Label4)
        Me.pnlMain.Controls.Add(Me.txtDispatchBy)
        Me.pnlMain.Controls.Add(Me.Label2)
        Me.pnlMain.Controls.Add(Me.txtRemarks)
        Me.pnlMain.Controls.Add(Me.Label1)
        Me.pnlMain.Controls.Add(Me.cboEntity)
        Me.pnlMain.Controls.Add(Me.lbAWBNo)
        Me.pnlMain.Controls.Add(Me.txtDispatchAddr)
        Me.pnlMain.Controls.Add(Me.lbentity)
        Me.pnlMain.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlMain.Location = New System.Drawing.Point(9, 22)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(834, 116)
        Me.pnlMain.TabIndex = 0
        '
        'TxtAwbNo
        '
        Me.TxtAwbNo.Location = New System.Drawing.Point(115, 32)
        Me.TxtAwbNo.Name = "TxtAwbNo"
        Me.TxtAwbNo.Size = New System.Drawing.Size(165, 21)
        Me.TxtAwbNo.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(3, 36)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(103, 13)
        Me.Label7.TabIndex = 44
        Me.Label7.Text = "Awb No"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CboCourierName
        '
        Me.CboCourierName.FormattingEnabled = True
        Me.CboCourierName.Location = New System.Drawing.Point(396, 32)
        Me.CboCourierName.Name = "CboCourierName"
        Me.CboCourierName.Size = New System.Drawing.Size(432, 21)
        Me.CboCourierName.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(285, 35)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(103, 13)
        Me.Label6.TabIndex = 42
        Me.Label6.Text = "Courier Name"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DtpDispatchDt
        '
        Me.DtpDispatchDt.CustomFormat = "dd-MM-yyyy"
        Me.DtpDispatchDt.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpDispatchDt.Location = New System.Drawing.Point(115, 6)
        Me.DtpDispatchDt.Name = "DtpDispatchDt"
        Me.DtpDispatchDt.Size = New System.Drawing.Size(165, 21)
        Me.DtpDispatchDt.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 10)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 13)
        Me.Label4.TabIndex = 39
        Me.Label4.Text = "Dispatch Date"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtDispatchBy
        '
        Me.txtDispatchBy.Location = New System.Drawing.Point(115, 58)
        Me.txtDispatchBy.MaxLength = 124
        Me.txtDispatchBy.Name = "txtDispatchBy"
        Me.txtDispatchBy.Size = New System.Drawing.Size(165, 21)
        Me.txtDispatchBy.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(3, 88)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label2.Size = New System.Drawing.Size(103, 16)
        Me.Label2.TabIndex = 35
        Me.Label2.Text = "Remarks"
        '
        'txtRemarks
        '
        Me.txtRemarks.Location = New System.Drawing.Point(115, 85)
        Me.txtRemarks.MaxLength = 500
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(382, 21)
        Me.txtRemarks.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(3, 60)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label1.Size = New System.Drawing.Size(103, 16)
        Me.Label1.TabIndex = 33
        Me.Label1.Text = "Dispatch By"
        '
        'cboEntity
        '
        Me.cboEntity.FormattingEnabled = True
        Me.cboEntity.Location = New System.Drawing.Point(396, 6)
        Me.cboEntity.Name = "cboEntity"
        Me.cboEntity.Size = New System.Drawing.Size(432, 21)
        Me.cboEntity.TabIndex = 1
        '
        'txtDispatchAddr
        '
        Me.txtDispatchAddr.Location = New System.Drawing.Point(396, 58)
        Me.txtDispatchAddr.MaxLength = 225
        Me.txtDispatchAddr.Name = "txtDispatchAddr"
        Me.txtDispatchAddr.Size = New System.Drawing.Size(432, 21)
        Me.txtDispatchAddr.TabIndex = 5
        '
        'lbentity
        '
        Me.lbentity.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbentity.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbentity.Location = New System.Drawing.Point(305, 10)
        Me.lbentity.Name = "lbentity"
        Me.lbentity.Size = New System.Drawing.Size(83, 13)
        Me.lbentity.TabIndex = 2
        Me.lbentity.Text = "Entity"
        Me.lbentity.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.SystemColors.Control
        Me.btnClose.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnClose.Location = New System.Drawing.Point(266, 1)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(84, 24)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "C&lose"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'btnFind
        '
        Me.btnFind.BackColor = System.Drawing.SystemColors.Control
        Me.btnFind.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnFind.Location = New System.Drawing.Point(91, 1)
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Size = New System.Drawing.Size(84, 24)
        Me.btnFind.TabIndex = 1
        Me.btnFind.Text = "&Find"
        Me.btnFind.UseVisualStyleBackColor = False
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.SystemColors.Control
        Me.btnDelete.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnDelete.Location = New System.Drawing.Point(178, 1)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(84, 24)
        Me.btnDelete.TabIndex = 2
        Me.btnDelete.Text = "&Delete"
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnCancel.Location = New System.Drawing.Point(93, 1)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(84, 24)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'pnlSave
        '
        Me.pnlSave.Controls.Add(Me.btnCancel)
        Me.pnlSave.Controls.Add(Me.btnSave)
        Me.pnlSave.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.pnlSave.Location = New System.Drawing.Point(338, 484)
        Me.pnlSave.Name = "pnlSave"
        Me.pnlSave.Size = New System.Drawing.Size(177, 28)
        Me.pnlSave.TabIndex = 62
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.SystemColors.Control
        Me.btnSave.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnSave.Location = New System.Drawing.Point(2, 1)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(84, 24)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "&Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'pnlButtons
        '
        Me.pnlButtons.Controls.Add(Me.btnClose)
        Me.pnlButtons.Controls.Add(Me.btnFind)
        Me.pnlButtons.Controls.Add(Me.btnDelete)
        Me.pnlButtons.Controls.Add(Me.btnNew)
        Me.pnlButtons.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.pnlButtons.Location = New System.Drawing.Point(233, 484)
        Me.pnlButtons.Name = "pnlButtons"
        Me.pnlButtons.Size = New System.Drawing.Size(352, 28)
        Me.pnlButtons.TabIndex = 2
        '
        'btnNew
        '
        Me.btnNew.BackColor = System.Drawing.SystemColors.Control
        Me.btnNew.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnNew.Location = New System.Drawing.Point(4, 1)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(84, 24)
        Me.btnNew.TabIndex = 0
        Me.btnNew.Text = "&New"
        Me.btnNew.UseVisualStyleBackColor = False
        '
        'PnlPullout
        '
        Me.PnlPullout.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PnlPullout.Controls.Add(Me.BtnInverse)
        Me.PnlPullout.Controls.Add(Me.BtnDeSelect)
        Me.PnlPullout.Controls.Add(Me.BtnSelect)
        Me.PnlPullout.Controls.Add(Me.TxtPulloutId)
        Me.PnlPullout.Controls.Add(Me.Label3)
        Me.PnlPullout.Controls.Add(Me.dtpReqTo)
        Me.PnlPullout.Controls.Add(Me.Label5)
        Me.PnlPullout.Controls.Add(Me.dtpReqFrom)
        Me.PnlPullout.Controls.Add(Me.btnClear)
        Me.PnlPullout.Controls.Add(Me.btnRefresh)
        Me.PnlPullout.Controls.Add(Me.Label8)
        Me.PnlPullout.Controls.Add(Me.Label9)
        Me.PnlPullout.Controls.Add(Me.CboPulloutEntity)
        Me.PnlPullout.Location = New System.Drawing.Point(9, 145)
        Me.PnlPullout.Name = "PnlPullout"
        Me.PnlPullout.Size = New System.Drawing.Size(834, 76)
        Me.PnlPullout.TabIndex = 1
        '
        'BtnInverse
        '
        Me.BtnInverse.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.BtnInverse.Location = New System.Drawing.Point(652, 44)
        Me.BtnInverse.Name = "BtnInverse"
        Me.BtnInverse.Size = New System.Drawing.Size(87, 23)
        Me.BtnInverse.TabIndex = 7
        Me.BtnInverse.Text = "Inverse"
        Me.BtnInverse.UseVisualStyleBackColor = False
        '
        'BtnDeSelect
        '
        Me.BtnDeSelect.BackColor = System.Drawing.Color.LightCoral
        Me.BtnDeSelect.Location = New System.Drawing.Point(561, 44)
        Me.BtnDeSelect.Name = "BtnDeSelect"
        Me.BtnDeSelect.Size = New System.Drawing.Size(87, 23)
        Me.BtnDeSelect.TabIndex = 6
        Me.BtnDeSelect.Text = "De-Select"
        Me.BtnDeSelect.UseVisualStyleBackColor = False
        '
        'BtnSelect
        '
        Me.BtnSelect.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.BtnSelect.Location = New System.Drawing.Point(470, 44)
        Me.BtnSelect.Name = "BtnSelect"
        Me.BtnSelect.Size = New System.Drawing.Size(87, 23)
        Me.BtnSelect.TabIndex = 5
        Me.BtnSelect.Text = "Select"
        Me.BtnSelect.UseVisualStyleBackColor = False
        '
        'TxtPulloutId
        '
        Me.TxtPulloutId.Location = New System.Drawing.Point(115, 43)
        Me.TxtPulloutId.Name = "TxtPulloutId"
        Me.TxtPulloutId.Size = New System.Drawing.Size(133, 21)
        Me.TxtPulloutId.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(45, 47)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 13)
        Me.Label3.TabIndex = 33
        Me.Label3.Text = "Pullout Id"
        '
        'dtpReqTo
        '
        Me.dtpReqTo.CustomFormat = "dd-MM-yyyy"
        Me.dtpReqTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpReqTo.Location = New System.Drawing.Point(277, 13)
        Me.dtpReqTo.Name = "dtpReqTo"
        Me.dtpReqTo.ShowCheckBox = True
        Me.dtpReqTo.Size = New System.Drawing.Size(133, 21)
        Me.dtpReqTo.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(254, 17)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(21, 13)
        Me.Label5.TabIndex = 30
        Me.Label5.Text = "To"
        '
        'dtpReqFrom
        '
        Me.dtpReqFrom.CustomFormat = "dd-MM-yyyy"
        Me.dtpReqFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpReqFrom.Location = New System.Drawing.Point(115, 12)
        Me.dtpReqFrom.Name = "dtpReqFrom"
        Me.dtpReqFrom.ShowCheckBox = True
        Me.dtpReqFrom.Size = New System.Drawing.Size(133, 21)
        Me.dtpReqFrom.TabIndex = 0
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(742, 43)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(84, 24)
        Me.btnClear.TabIndex = 8
        Me.btnClear.Text = "C&lear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(382, 43)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(84, 24)
        Me.btnRefresh.TabIndex = 4
        Me.btnRefresh.Text = "&Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(3, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(103, 13)
        Me.Label8.TabIndex = 25
        Me.Label8.Text = "Pullout Req From"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(416, 17)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(40, 13)
        Me.Label9.TabIndex = 28
        Me.Label9.Text = "Entity"
        '
        'CboPulloutEntity
        '
        Me.CboPulloutEntity.FormattingEnabled = True
        Me.CboPulloutEntity.Location = New System.Drawing.Point(470, 13)
        Me.CboPulloutEntity.Name = "CboPulloutEntity"
        Me.CboPulloutEntity.Size = New System.Drawing.Size(356, 21)
        Me.CboPulloutEntity.TabIndex = 2
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Tahoma", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(10, 224)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(69, 13)
        Me.Label14.TabIndex = 66
        Me.Label14.Text = "Pullout List"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvReport
        '
        Me.dgvReport.AllowUserToAddRows = False
        Me.dgvReport.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        Me.dgvReport.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvReport.BackgroundColor = System.Drawing.SystemColors.Menu
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvReport.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvReport.GridColor = System.Drawing.SystemColors.Desktop
        Me.dgvReport.Location = New System.Drawing.Point(9, 240)
        Me.dgvReport.Name = "dgvReport"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvReport.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvReport.RowHeadersVisible = False
        Me.dgvReport.Size = New System.Drawing.Size(834, 240)
        Me.dgvReport.TabIndex = 67
        '
        'lblRecCount
        '
        Me.lblRecCount.AutoSize = True
        Me.lblRecCount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblRecCount.Location = New System.Drawing.Point(605, 224)
        Me.lblRecCount.Name = "lblRecCount"
        Me.lblRecCount.Size = New System.Drawing.Size(83, 13)
        Me.lblRecCount.TabIndex = 68
        Me.lblRecCount.Text = "Record Count"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(9, 4)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(89, 13)
        Me.Label10.TabIndex = 69
        Me.Label10.Text = "Dispatch Entry"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmDispatch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(853, 515)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.lblRecCount)
        Me.Controls.Add(Me.dgvReport)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.PnlPullout)
        Me.Controls.Add(Me.txtId)
        Me.Controls.Add(Me.pnlMain)
        Me.Controls.Add(Me.pnlButtons)
        Me.Controls.Add(Me.pnlSave)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDispatch"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pullout Dispatch "
        Me.pnlMain.ResumeLayout(False)
        Me.pnlMain.PerformLayout()
        Me.pnlSave.ResumeLayout(False)
        Me.pnlButtons.ResumeLayout(False)
        Me.PnlPullout.ResumeLayout(False)
        Me.PnlPullout.PerformLayout()
        CType(Me.dgvReport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtId As System.Windows.Forms.TextBox
    Friend WithEvents lbAWBNo As System.Windows.Forms.Label
    Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Friend WithEvents cboEntity As System.Windows.Forms.ComboBox
    Friend WithEvents txtDispatchAddr As System.Windows.Forms.TextBox
    Friend WithEvents lbentity As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnFind As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents pnlSave As System.Windows.Forms.Panel
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents pnlButtons As System.Windows.Forms.Panel
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDispatchBy As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DtpDispatchDt As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CboCourierName As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtAwbNo As System.Windows.Forms.TextBox
    Friend WithEvents PnlPullout As System.Windows.Forms.Panel
    Friend WithEvents BtnInverse As System.Windows.Forms.Button
    Friend WithEvents BtnDeSelect As System.Windows.Forms.Button
    Friend WithEvents BtnSelect As System.Windows.Forms.Button
    Friend WithEvents TxtPulloutId As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpReqTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtpReqFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents CboPulloutEntity As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents dgvReport As System.Windows.Forms.DataGridView
    Friend WithEvents lblRecCount As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
End Class
