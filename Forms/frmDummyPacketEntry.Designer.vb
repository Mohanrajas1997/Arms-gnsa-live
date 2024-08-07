<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDummyPacketEntry
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
        Me.pnlPktInfo = New System.Windows.Forms.Panel()
        Me.TxtCoverNo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtLotNo = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtPktNo = New System.Windows.Forms.TextBox()
        Me.dtpRcvdDate = New System.Windows.Forms.DateTimePicker()
        Me.txtId = New System.Windows.Forms.TextBox()
        Me.txtTotChq = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboEntityName = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.pnlSave = New System.Windows.Forms.Panel()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.pnlPktInfo.SuspendLayout()
        Me.pnlSave.SuspendLayout()
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
        Me.pnlPktInfo.Controls.Add(Me.dtpRcvdDate)
        Me.pnlPktInfo.Controls.Add(Me.txtId)
        Me.pnlPktInfo.Controls.Add(Me.txtTotChq)
        Me.pnlPktInfo.Controls.Add(Me.Label3)
        Me.pnlPktInfo.Controls.Add(Me.cboEntityName)
        Me.pnlPktInfo.Controls.Add(Me.Label2)
        Me.pnlPktInfo.Controls.Add(Me.Label12)
        Me.pnlPktInfo.Location = New System.Drawing.Point(12, 12)
        Me.pnlPktInfo.Name = "pnlPktInfo"
        Me.pnlPktInfo.Size = New System.Drawing.Size(649, 88)
        Me.pnlPktInfo.TabIndex = 1
        '
        'TxtCoverNo
        '
        Me.TxtCoverNo.Location = New System.Drawing.Point(319, 34)
        Me.TxtCoverNo.MaxLength = 64
        Me.TxtCoverNo.Name = "TxtCoverNo"
        Me.TxtCoverNo.Size = New System.Drawing.Size(313, 21)
        Me.TxtCoverNo.TabIndex = 3
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
        Me.txtId.Location = New System.Drawing.Point(23, 34)
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
        'pnlSave
        '
        Me.pnlSave.CausesValidation = False
        Me.pnlSave.Controls.Add(Me.btnCancel)
        Me.pnlSave.Controls.Add(Me.btnSave)
        Me.pnlSave.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlSave.Location = New System.Drawing.Point(270, 106)
        Me.pnlSave.Name = "pnlSave"
        Me.pnlSave.Size = New System.Drawing.Size(152, 28)
        Me.pnlSave.TabIndex = 5
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancel.CausesValidation = False
        Me.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnCancel.Location = New System.Drawing.Point(77, 1)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(72, 24)
        Me.btnCancel.TabIndex = 1
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
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "&Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'frmDummyPacketEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(673, 140)
        Me.Controls.Add(Me.pnlSave)
        Me.Controls.Add(Me.pnlPktInfo)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.KeyPreview = True
        Me.Name = "frmDummyPacketEntry"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Packet Entry"
        Me.pnlPktInfo.ResumeLayout(False)
        Me.pnlPktInfo.PerformLayout()
        Me.pnlSave.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlPktInfo As System.Windows.Forms.Panel
    Friend WithEvents TxtCoverNo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtLotNo As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtPktNo As System.Windows.Forms.TextBox
    Friend WithEvents dtpRcvdDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtId As System.Windows.Forms.TextBox
    Friend WithEvents txtTotChq As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboEntityName As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents pnlSave As System.Windows.Forms.Panel
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
End Class
