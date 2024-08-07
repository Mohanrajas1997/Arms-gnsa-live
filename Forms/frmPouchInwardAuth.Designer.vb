<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPouchInwardAuth
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.rdoHalfly = New System.Windows.Forms.RadioButton()
        Me.rdoQuarterly = New System.Windows.Forms.RadioButton()
        Me.rdoMonthly = New System.Windows.Forms.RadioButton()
        Me.txtTotChq = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtContractNo = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtLotNo = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cboEntityName = New System.Windows.Forms.ComboBox()
        Me.dtpRcvdDate = New System.Windows.Forms.DateTimePicker()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnclear = New System.Windows.Forms.Button()
        Me.btnsubmit = New System.Windows.Forms.Button()
        Me.txtcoverno = New System.Windows.Forms.TextBox()
        Me.lblAgreementNo = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Panel2)
        Me.GroupBox1.Controls.Add(Me.txtTotChq)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtContractNo)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.txtLotNo)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.cboEntityName)
        Me.GroupBox1.Controls.Add(Me.dtpRcvdDate)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.btnClose)
        Me.GroupBox1.Controls.Add(Me.btnclear)
        Me.GroupBox1.Controls.Add(Me.btnsubmit)
        Me.GroupBox1.Controls.Add(Me.txtcoverno)
        Me.GroupBox1.Controls.Add(Me.lblAgreementNo)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(510, 159)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.rdoHalfly)
        Me.Panel2.Controls.Add(Me.rdoQuarterly)
        Me.Panel2.Controls.Add(Me.rdoMonthly)
        Me.Panel2.Location = New System.Drawing.Point(274, 100)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(224, 23)
        Me.Panel2.TabIndex = 5
        '
        'rdoHalfly
        '
        Me.rdoHalfly.AutoSize = True
        Me.rdoHalfly.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.rdoHalfly.Location = New System.Drawing.Point(162, 1)
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
        Me.rdoQuarterly.Location = New System.Drawing.Point(77, 1)
        Me.rdoQuarterly.Name = "rdoQuarterly"
        Me.rdoQuarterly.Size = New System.Drawing.Size(79, 17)
        Me.rdoQuarterly.TabIndex = 1
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
        Me.rdoMonthly.TabIndex = 0
        Me.rdoMonthly.TabStop = True
        Me.rdoMonthly.Text = "Monthly"
        Me.rdoMonthly.UseVisualStyleBackColor = True
        '
        'txtTotChq
        '
        Me.txtTotChq.Location = New System.Drawing.Point(129, 101)
        Me.txtTotChq.MaxLength = 3
        Me.txtTotChq.Name = "txtTotChq"
        Me.txtTotChq.Size = New System.Drawing.Size(116, 21)
        Me.txtTotChq.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(34, 105)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 13)
        Me.Label3.TabIndex = 76
        Me.Label3.Text = "No. of Cheques"
        '
        'txtContractNo
        '
        Me.txtContractNo.Location = New System.Drawing.Point(332, 75)
        Me.txtContractNo.MaxLength = 16
        Me.txtContractNo.Name = "txtContractNo"
        Me.txtContractNo.Size = New System.Drawing.Size(166, 21)
        Me.txtContractNo.TabIndex = 3
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(248, 79)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(79, 13)
        Me.Label13.TabIndex = 75
        Me.Label13.Text = "Contract No"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtLotNo
        '
        Me.txtLotNo.Location = New System.Drawing.Point(332, 20)
        Me.txtLotNo.MaxLength = 8
        Me.txtLotNo.Name = "txtLotNo"
        Me.txtLotNo.Size = New System.Drawing.Size(165, 21)
        Me.txtLotNo.TabIndex = 0
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(282, 24)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(42, 13)
        Me.Label9.TabIndex = 73
        Me.Label9.Text = "Lot No"
        '
        'cboEntityName
        '
        Me.cboEntityName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboEntityName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboEntityName.FormattingEnabled = True
        Me.cboEntityName.Location = New System.Drawing.Point(129, 47)
        Me.cboEntityName.Name = "cboEntityName"
        Me.cboEntityName.Size = New System.Drawing.Size(370, 21)
        Me.cboEntityName.TabIndex = 1
        Me.cboEntityName.Tag = "*"
        '
        'dtpRcvdDate
        '
        Me.dtpRcvdDate.CustomFormat = "dd-MMM-yyyy"
        Me.dtpRcvdDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpRcvdDate.Location = New System.Drawing.Point(129, 21)
        Me.dtpRcvdDate.Name = "dtpRcvdDate"
        Me.dtpRcvdDate.Size = New System.Drawing.Size(116, 21)
        Me.dtpRcvdDate.TabIndex = 68
        Me.dtpRcvdDate.Tag = "*"
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(32, 25)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(89, 13)
        Me.Label12.TabIndex = 69
        Me.Label12.Text = "Received Date"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(33, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Entity"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnClose
        '
        Me.btnClose.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(317, 130)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(87, 23)
        Me.btnClose.TabIndex = 7
        Me.btnClose.Text = "C&lose"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnclear
        '
        Me.btnclear.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnclear.Location = New System.Drawing.Point(222, 130)
        Me.btnclear.Name = "btnclear"
        Me.btnclear.Size = New System.Drawing.Size(87, 23)
        Me.btnclear.TabIndex = 6
        Me.btnclear.Text = "&Clear"
        Me.btnclear.UseVisualStyleBackColor = True
        '
        'btnsubmit
        '
        Me.btnsubmit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnsubmit.Location = New System.Drawing.Point(128, 130)
        Me.btnsubmit.Name = "btnsubmit"
        Me.btnsubmit.Size = New System.Drawing.Size(87, 23)
        Me.btnsubmit.TabIndex = 5
        Me.btnsubmit.Text = "&Submit"
        Me.btnsubmit.UseVisualStyleBackColor = True
        '
        'txtcoverno
        '
        Me.txtcoverno.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcoverno.Location = New System.Drawing.Point(127, 73)
        Me.txtcoverno.MaxLength = 16
        Me.txtcoverno.Name = "txtcoverno"
        Me.txtcoverno.Size = New System.Drawing.Size(116, 21)
        Me.txtcoverno.TabIndex = 2
        '
        'lblAgreementNo
        '
        Me.lblAgreementNo.AutoSize = True
        Me.lblAgreementNo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAgreementNo.Location = New System.Drawing.Point(63, 77)
        Me.lblAgreementNo.Name = "lblAgreementNo"
        Me.lblAgreementNo.Size = New System.Drawing.Size(57, 13)
        Me.lblAgreementNo.TabIndex = 1
        Me.lblAgreementNo.Text = "Cover No"
        '
        'frmPouchInwardAuth
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(525, 171)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPouchInwardAuth"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pouch Inward and Auth"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnclear As System.Windows.Forms.Button
    Friend WithEvents btnsubmit As System.Windows.Forms.Button
    Friend WithEvents txtcoverno As System.Windows.Forms.TextBox
    Friend WithEvents lblAgreementNo As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpRcvdDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cboEntityName As System.Windows.Forms.ComboBox
    Friend WithEvents txtLotNo As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtContractNo As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtTotChq As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents rdoHalfly As System.Windows.Forms.RadioButton
    Friend WithEvents rdoQuarterly As System.Windows.Forms.RadioButton
    Friend WithEvents rdoMonthly As System.Windows.Forms.RadioButton
End Class
