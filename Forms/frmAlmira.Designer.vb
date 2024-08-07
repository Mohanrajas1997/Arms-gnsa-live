<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAlmira
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
        Me.txtId = New System.Windows.Forms.TextBox()
        Me.txtUserStatus = New System.Windows.Forms.TextBox()
        Me.lbAWBNo = New System.Windows.Forms.Label()
        Me.lbCourier = New System.Windows.Forms.Label()
        Me.lbReceivedBy = New System.Windows.Forms.Label()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.CboCoverno = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtShelfNo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtBoxNo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboContractNo = New System.Windows.Forms.ComboBox()
        Me.cboLotNo = New System.Windows.Forms.ComboBox()
        Me.cboEntity = New System.Windows.Forms.ComboBox()
        Me.txtCuboardNo = New System.Windows.Forms.TextBox()
        Me.lbentity = New System.Windows.Forms.Label()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnFind = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.pnlSave = New System.Windows.Forms.Panel()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.pnlButtons = New System.Windows.Forms.Panel()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.pnlMain.SuspendLayout()
        Me.pnlSave.SuspendLayout()
        Me.pnlButtons.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtId
        '
        Me.txtId.Location = New System.Drawing.Point(-7, 1)
        Me.txtId.Name = "txtId"
        Me.txtId.Size = New System.Drawing.Size(24, 20)
        Me.txtId.TabIndex = 64
        Me.txtId.Visible = False
        '
        'txtUserStatus
        '
        Me.txtUserStatus.Location = New System.Drawing.Point(6, 3)
        Me.txtUserStatus.Name = "txtUserStatus"
        Me.txtUserStatus.Size = New System.Drawing.Size(22, 21)
        Me.txtUserStatus.TabIndex = 31
        Me.txtUserStatus.Visible = False
        '
        'lbAWBNo
        '
        Me.lbAWBNo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lbAWBNo.Location = New System.Drawing.Point(1, 122)
        Me.lbAWBNo.Name = "lbAWBNo"
        Me.lbAWBNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lbAWBNo.Size = New System.Drawing.Size(74, 16)
        Me.lbAWBNo.TabIndex = 10
        Me.lbAWBNo.Text = "Cuboard No"
        '
        'lbCourier
        '
        Me.lbCourier.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lbCourier.Location = New System.Drawing.Point(2, 68)
        Me.lbCourier.Name = "lbCourier"
        Me.lbCourier.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lbCourier.Size = New System.Drawing.Size(75, 16)
        Me.lbCourier.TabIndex = 8
        Me.lbCourier.Text = "Contract No"
        '
        'lbReceivedBy
        '
        Me.lbReceivedBy.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lbReceivedBy.Location = New System.Drawing.Point(-10, 41)
        Me.lbReceivedBy.Name = "lbReceivedBy"
        Me.lbReceivedBy.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lbReceivedBy.Size = New System.Drawing.Size(87, 16)
        Me.lbReceivedBy.TabIndex = 6
        Me.lbReceivedBy.Text = "Lot No"
        '
        'pnlMain
        '
        Me.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlMain.Controls.Add(Me.CboCoverno)
        Me.pnlMain.Controls.Add(Me.Label3)
        Me.pnlMain.Controls.Add(Me.txtShelfNo)
        Me.pnlMain.Controls.Add(Me.Label2)
        Me.pnlMain.Controls.Add(Me.txtBoxNo)
        Me.pnlMain.Controls.Add(Me.Label1)
        Me.pnlMain.Controls.Add(Me.cboContractNo)
        Me.pnlMain.Controls.Add(Me.cboLotNo)
        Me.pnlMain.Controls.Add(Me.txtUserStatus)
        Me.pnlMain.Controls.Add(Me.cboEntity)
        Me.pnlMain.Controls.Add(Me.lbAWBNo)
        Me.pnlMain.Controls.Add(Me.lbCourier)
        Me.pnlMain.Controls.Add(Me.lbReceivedBy)
        Me.pnlMain.Controls.Add(Me.txtCuboardNo)
        Me.pnlMain.Controls.Add(Me.lbentity)
        Me.pnlMain.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlMain.Location = New System.Drawing.Point(12, 12)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(424, 210)
        Me.pnlMain.TabIndex = 0
        '
        'CboCoverno
        '
        Me.CboCoverno.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CboCoverno.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CboCoverno.FormattingEnabled = True
        Me.CboCoverno.Location = New System.Drawing.Point(82, 92)
        Me.CboCoverno.Name = "CboCoverno"
        Me.CboCoverno.Size = New System.Drawing.Size(328, 21)
        Me.CboCoverno.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(3, 95)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label3.Size = New System.Drawing.Size(75, 16)
        Me.Label3.TabIndex = 38
        Me.Label3.Text = "Cover No"
        '
        'txtShelfNo
        '
        Me.txtShelfNo.Location = New System.Drawing.Point(82, 147)
        Me.txtShelfNo.MaxLength = 32
        Me.txtShelfNo.Name = "txtShelfNo"
        Me.txtShelfNo.Size = New System.Drawing.Size(328, 21)
        Me.txtShelfNo.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(6, 176)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label2.Size = New System.Drawing.Size(71, 16)
        Me.Label2.TabIndex = 35
        Me.Label2.Text = "Box No"
        '
        'txtBoxNo
        '
        Me.txtBoxNo.Location = New System.Drawing.Point(81, 173)
        Me.txtBoxNo.MaxLength = 32
        Me.txtBoxNo.Name = "txtBoxNo"
        Me.txtBoxNo.Size = New System.Drawing.Size(328, 21)
        Me.txtBoxNo.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(2, 149)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label1.Size = New System.Drawing.Size(75, 16)
        Me.Label1.TabIndex = 33
        Me.Label1.Text = "Shelf No"
        '
        'cboContractNo
        '
        Me.cboContractNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboContractNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboContractNo.FormattingEnabled = True
        Me.cboContractNo.Location = New System.Drawing.Point(81, 65)
        Me.cboContractNo.Name = "cboContractNo"
        Me.cboContractNo.Size = New System.Drawing.Size(328, 21)
        Me.cboContractNo.TabIndex = 2
        '
        'cboLotNo
        '
        Me.cboLotNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboLotNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboLotNo.FormattingEnabled = True
        Me.cboLotNo.Location = New System.Drawing.Point(81, 38)
        Me.cboLotNo.Name = "cboLotNo"
        Me.cboLotNo.Size = New System.Drawing.Size(328, 21)
        Me.cboLotNo.TabIndex = 1
        '
        'cboEntity
        '
        Me.cboEntity.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboEntity.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboEntity.FormattingEnabled = True
        Me.cboEntity.Location = New System.Drawing.Point(81, 11)
        Me.cboEntity.Name = "cboEntity"
        Me.cboEntity.Size = New System.Drawing.Size(328, 21)
        Me.cboEntity.TabIndex = 0
        '
        'txtCuboardNo
        '
        Me.txtCuboardNo.Location = New System.Drawing.Point(81, 119)
        Me.txtCuboardNo.MaxLength = 32
        Me.txtCuboardNo.Name = "txtCuboardNo"
        Me.txtCuboardNo.Size = New System.Drawing.Size(328, 21)
        Me.txtCuboardNo.TabIndex = 4
        '
        'lbentity
        '
        Me.lbentity.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbentity.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbentity.Location = New System.Drawing.Point(3, 14)
        Me.lbentity.Name = "lbentity"
        Me.lbentity.Size = New System.Drawing.Size(71, 13)
        Me.lbentity.TabIndex = 2
        Me.lbentity.Text = "Entity"
        Me.lbentity.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnEdit
        '
        Me.btnEdit.BackColor = System.Drawing.SystemColors.Control
        Me.btnEdit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnEdit.Location = New System.Drawing.Point(79, 1)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(72, 24)
        Me.btnEdit.TabIndex = 1
        Me.btnEdit.Text = "&Edit"
        Me.btnEdit.UseVisualStyleBackColor = False
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
        Me.btnClose.UseVisualStyleBackColor = False
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
        Me.btnFind.UseVisualStyleBackColor = False
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
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnCancel.Location = New System.Drawing.Point(80, 1)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(72, 24)
        Me.btnCancel.TabIndex = 8
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'pnlSave
        '
        Me.pnlSave.Controls.Add(Me.btnCancel)
        Me.pnlSave.Controls.Add(Me.btnSave)
        Me.pnlSave.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.pnlSave.Location = New System.Drawing.Point(143, 230)
        Me.pnlSave.Name = "pnlSave"
        Me.pnlSave.Size = New System.Drawing.Size(152, 28)
        Me.pnlSave.TabIndex = 62
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.SystemColors.Control
        Me.btnSave.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnSave.Location = New System.Drawing.Point(2, 1)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(72, 24)
        Me.btnSave.TabIndex = 7
        Me.btnSave.Text = "&Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'pnlButtons
        '
        Me.pnlButtons.Controls.Add(Me.btnClose)
        Me.pnlButtons.Controls.Add(Me.btnFind)
        Me.pnlButtons.Controls.Add(Me.btnDelete)
        Me.pnlButtons.Controls.Add(Me.btnEdit)
        Me.pnlButtons.Controls.Add(Me.btnNew)
        Me.pnlButtons.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.pnlButtons.Location = New System.Drawing.Point(27, 230)
        Me.pnlButtons.Name = "pnlButtons"
        Me.pnlButtons.Size = New System.Drawing.Size(392, 28)
        Me.pnlButtons.TabIndex = 63
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
        Me.btnNew.UseVisualStyleBackColor = False
        '
        'frmAlmira
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(448, 261)
        Me.Controls.Add(Me.txtId)
        Me.Controls.Add(Me.pnlMain)
        Me.Controls.Add(Me.pnlSave)
        Me.Controls.Add(Me.pnlButtons)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAlmira"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Almira "
        Me.pnlMain.ResumeLayout(False)
        Me.pnlMain.PerformLayout()
        Me.pnlSave.ResumeLayout(False)
        Me.pnlButtons.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtId As System.Windows.Forms.TextBox
    Friend WithEvents txtUserStatus As System.Windows.Forms.TextBox
    Friend WithEvents lbAWBNo As System.Windows.Forms.Label
    Friend WithEvents lbCourier As System.Windows.Forms.Label
    Friend WithEvents lbReceivedBy As System.Windows.Forms.Label
    Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Friend WithEvents cboContractNo As System.Windows.Forms.ComboBox
    Friend WithEvents cboLotNo As System.Windows.Forms.ComboBox
    Friend WithEvents cboEntity As System.Windows.Forms.ComboBox
    Friend WithEvents txtCuboardNo As System.Windows.Forms.TextBox
    Friend WithEvents lbentity As System.Windows.Forms.Label
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnFind As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents pnlSave As System.Windows.Forms.Panel
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents pnlButtons As System.Windows.Forms.Panel
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtBoxNo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtShelfNo As System.Windows.Forms.TextBox
    Friend WithEvents CboCoverno As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
