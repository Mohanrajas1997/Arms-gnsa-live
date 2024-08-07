<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPulloutDelete
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
        Me.lblPulloutId = New System.Windows.Forms.Label()
        Me.dtpChqDate = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtChqAmount = New System.Windows.Forms.TextBox()
        Me.lbEntity = New System.Windows.Forms.Label()
        Me.txtContractNo = New System.Windows.Forms.TextBox()
        Me.txtChqNo = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.txtPullId = New System.Windows.Forms.TextBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblPacketNo = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.txtPacketNo = New System.Windows.Forms.TextBox()
        Me.cboEntity = New System.Windows.Forms.ComboBox()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.pnlMain.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblPulloutId
        '
        Me.lblPulloutId.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblPulloutId.Location = New System.Drawing.Point(-2, 15)
        Me.lblPulloutId.Name = "lblPulloutId"
        Me.lblPulloutId.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblPulloutId.Size = New System.Drawing.Size(89, 16)
        Me.lblPulloutId.TabIndex = 70
        Me.lblPulloutId.Text = "PullOut Id"
        '
        'dtpChqDate
        '
        Me.dtpChqDate.CustomFormat = "dd-MM-yyyy"
        Me.dtpChqDate.Enabled = False
        Me.dtpChqDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpChqDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpChqDate.Location = New System.Drawing.Point(91, 86)
        Me.dtpChqDate.Name = "dtpChqDate"
        Me.dtpChqDate.Size = New System.Drawing.Size(324, 21)
        Me.dtpChqDate.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(-1, 92)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label3.Size = New System.Drawing.Size(89, 16)
        Me.Label3.TabIndex = 78
        Me.Label3.Text = "Chq Date"
        '
        'txtChqAmount
        '
        Me.txtChqAmount.Enabled = False
        Me.txtChqAmount.Location = New System.Drawing.Point(91, 113)
        Me.txtChqAmount.MaxLength = 16
        Me.txtChqAmount.Name = "txtChqAmount"
        Me.txtChqAmount.Size = New System.Drawing.Size(324, 20)
        Me.txtChqAmount.TabIndex = 4
        '
        'lbEntity
        '
        Me.lbEntity.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lbEntity.Location = New System.Drawing.Point(-2, 9)
        Me.lbEntity.Name = "lbEntity"
        Me.lbEntity.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lbEntity.Size = New System.Drawing.Size(89, 16)
        Me.lbEntity.TabIndex = 48
        Me.lbEntity.Text = "Entity"
        '
        'txtContractNo
        '
        Me.txtContractNo.Enabled = False
        Me.txtContractNo.Location = New System.Drawing.Point(91, 32)
        Me.txtContractNo.MaxLength = 16
        Me.txtContractNo.Name = "txtContractNo"
        Me.txtContractNo.Size = New System.Drawing.Size(324, 20)
        Me.txtContractNo.TabIndex = 1
        '
        'txtChqNo
        '
        Me.txtChqNo.Enabled = False
        Me.txtChqNo.Location = New System.Drawing.Point(91, 141)
        Me.txtChqNo.MaxLength = 16
        Me.txtChqNo.Name = "txtChqNo"
        Me.txtChqNo.Size = New System.Drawing.Size(324, 20)
        Me.txtChqNo.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(-2, 144)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label6.Size = New System.Drawing.Size(89, 16)
        Me.Label6.TabIndex = 74
        Me.Label6.Text = "Chq No"
        '
        'pnlMain
        '
        Me.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlMain.Controls.Add(Me.txtPullId)
        Me.pnlMain.Controls.Add(Me.lblPulloutId)
        Me.pnlMain.Location = New System.Drawing.Point(13, 10)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(426, 46)
        Me.pnlMain.TabIndex = 9
        '
        'txtPullId
        '
        Me.txtPullId.Location = New System.Drawing.Point(90, 12)
        Me.txtPullId.MaxLength = 16
        Me.txtPullId.Name = "txtPullId"
        Me.txtPullId.Size = New System.Drawing.Size(324, 20)
        Me.txtPullId.TabIndex = 0
        '
        'btnClose
        '
        Me.btnClose.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnClose.Location = New System.Drawing.Point(358, 231)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(72, 24)
        Me.btnClose.TabIndex = 13
        Me.btnClose.TabStop = False
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.Location = New System.Drawing.Point(280, 231)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(72, 24)
        Me.btnClear.TabIndex = 12
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnDelete.Location = New System.Drawing.Point(202, 231)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(72, 24)
        Me.btnDelete.TabIndex = 11
        Me.btnDelete.TabStop = False
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(-2, 118)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label5.Size = New System.Drawing.Size(89, 16)
        Me.Label5.TabIndex = 71
        Me.Label5.Text = "Chq Amount"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(-2, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label2.Size = New System.Drawing.Size(89, 16)
        Me.Label2.TabIndex = 63
        Me.Label2.Text = "Contract No"
        '
        'lblPacketNo
        '
        Me.lblPacketNo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblPacketNo.Location = New System.Drawing.Point(-1, 62)
        Me.lblPacketNo.Name = "lblPacketNo"
        Me.lblPacketNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblPacketNo.Size = New System.Drawing.Size(89, 16)
        Me.lblPacketNo.TabIndex = 62
        Me.lblPacketNo.Text = "Packet No"
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.txtPacketNo)
        Me.Panel3.Controls.Add(Me.cboEntity)
        Me.Panel3.Controls.Add(Me.dtpChqDate)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.txtChqAmount)
        Me.Panel3.Controls.Add(Me.lbEntity)
        Me.Panel3.Controls.Add(Me.txtContractNo)
        Me.Panel3.Controls.Add(Me.txtChqNo)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.lblPacketNo)
        Me.Panel3.Location = New System.Drawing.Point(13, 62)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(426, 203)
        Me.Panel3.TabIndex = 10
        '
        'txtPacketNo
        '
        Me.txtPacketNo.Enabled = False
        Me.txtPacketNo.Location = New System.Drawing.Point(91, 58)
        Me.txtPacketNo.MaxLength = 16
        Me.txtPacketNo.Name = "txtPacketNo"
        Me.txtPacketNo.Size = New System.Drawing.Size(324, 20)
        Me.txtPacketNo.TabIndex = 80
        '
        'cboEntity
        '
        Me.cboEntity.Enabled = False
        Me.cboEntity.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.cboEntity.FormattingEnabled = True
        Me.cboEntity.Location = New System.Drawing.Point(91, 5)
        Me.cboEntity.Name = "cboEntity"
        Me.cboEntity.Size = New System.Drawing.Size(324, 21)
        Me.cboEntity.TabIndex = 79
        '
        'btnUpdate
        '
        Me.btnUpdate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdate.Location = New System.Drawing.Point(124, 231)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(72, 24)
        Me.btnUpdate.TabIndex = 14
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'frmPulloutDelete
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(452, 277)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.pnlMain)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.Panel3)
        Me.Name = "frmPulloutDelete"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pullout Delete"
        Me.pnlMain.ResumeLayout(False)
        Me.pnlMain.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblPulloutId As Label
    Friend WithEvents dtpChqDate As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents txtChqAmount As TextBox
    Friend WithEvents lbEntity As Label
    Friend WithEvents txtContractNo As TextBox
    Friend WithEvents txtChqNo As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents pnlMain As Panel
    Friend WithEvents txtPullId As TextBox
    Friend WithEvents btnClose As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lblPacketNo As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents cboEntity As ComboBox
    Friend WithEvents txtPacketNo As TextBox
    Friend WithEvents btnUpdate As Button
End Class
