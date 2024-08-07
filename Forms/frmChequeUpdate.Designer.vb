<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChequeUpdate
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
        Me.txtChqAmount = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtpChqDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpCycleDate = New System.Windows.Forms.DateTimePicker()
        Me.txtChqNo = New System.Windows.Forms.TextBox()
        Me.txtContractNo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.cboEntity = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtChqId = New System.Windows.Forms.TextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.lbReceivedBy = New System.Windows.Forms.Label()
        Me.DGrid = New System.Windows.Forms.DataGridView()
        Me.Panel3.SuspendLayout()
        Me.pnlMain.SuspendLayout()
        CType(Me.DGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtChqAmount
        '
        Me.txtChqAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtChqAmount.Location = New System.Drawing.Point(106, 117)
        Me.txtChqAmount.MaxLength = 16
        Me.txtChqAmount.Name = "txtChqAmount"
        Me.txtChqAmount.Size = New System.Drawing.Size(377, 21)
        Me.txtChqAmount.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(-10, 120)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label6.Size = New System.Drawing.Size(104, 16)
        Me.Label6.TabIndex = 74
        Me.Label6.Text = "Chq Amount"
        '
        'btnUpdate
        '
        Me.btnUpdate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdate.Location = New System.Drawing.Point(683, 226)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(72, 24)
        Me.btnUpdate.TabIndex = 3
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(-10, 96)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label5.Size = New System.Drawing.Size(104, 16)
        Me.Label5.TabIndex = 71
        Me.Label5.Text = "Chq Date"
        '
        'dtpChqDate
        '
        Me.dtpChqDate.CustomFormat = "dd-MM-yyyy"
        Me.dtpChqDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpChqDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpChqDate.Location = New System.Drawing.Point(106, 90)
        Me.dtpChqDate.Name = "dtpChqDate"
        Me.dtpChqDate.Size = New System.Drawing.Size(377, 21)
        Me.dtpChqDate.TabIndex = 3
        '
        'dtpCycleDate
        '
        Me.dtpCycleDate.CustomFormat = "dd-MM-yyyy"
        Me.dtpCycleDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpCycleDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpCycleDate.Location = New System.Drawing.Point(106, 63)
        Me.dtpCycleDate.Name = "dtpCycleDate"
        Me.dtpCycleDate.Size = New System.Drawing.Size(377, 21)
        Me.dtpCycleDate.TabIndex = 2
        '
        'txtChqNo
        '
        Me.txtChqNo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtChqNo.Location = New System.Drawing.Point(106, 144)
        Me.txtChqNo.MaxLength = 16
        Me.txtChqNo.Name = "txtChqNo"
        Me.txtChqNo.Size = New System.Drawing.Size(377, 21)
        Me.txtChqNo.TabIndex = 5
        '
        'txtContractNo
        '
        Me.txtContractNo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContractNo.Location = New System.Drawing.Point(106, 40)
        Me.txtContractNo.MaxLength = 16
        Me.txtContractNo.Name = "txtContractNo"
        Me.txtContractNo.Size = New System.Drawing.Size(377, 21)
        Me.txtContractNo.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(-10, 147)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label4.Size = New System.Drawing.Size(104, 16)
        Me.Label4.TabIndex = 64
        Me.Label4.Text = "Chq No"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(-10, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label2.Size = New System.Drawing.Size(104, 16)
        Me.Label2.TabIndex = 63
        Me.Label2.Text = "Cycle Date"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(-10, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label1.Size = New System.Drawing.Size(104, 16)
        Me.Label1.TabIndex = 62
        Me.Label1.Text = "Contract No"
        '
        'btnClose
        '
        Me.btnClose.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnClose.Location = New System.Drawing.Point(839, 226)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(72, 24)
        Me.btnClose.TabIndex = 5
        Me.btnClose.TabStop = False
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.Location = New System.Drawing.Point(761, 226)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(72, 24)
        Me.btnClear.TabIndex = 4
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'cboEntity
        '
        Me.cboEntity.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.cboEntity.FormattingEnabled = True
        Me.cboEntity.Location = New System.Drawing.Point(106, 13)
        Me.cboEntity.Name = "cboEntity"
        Me.cboEntity.Size = New System.Drawing.Size(377, 21)
        Me.cboEntity.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(-10, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label3.Size = New System.Drawing.Size(104, 16)
        Me.Label3.TabIndex = 48
        Me.Label3.Text = "Entity"
        '
        'txtChqId
        '
        Me.txtChqId.Location = New System.Drawing.Point(106, 13)
        Me.txtChqId.MaxLength = 16
        Me.txtChqId.Name = "txtChqId"
        Me.txtChqId.Size = New System.Drawing.Size(377, 21)
        Me.txtChqId.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.txtChqAmount)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.dtpChqDate)
        Me.Panel3.Controls.Add(Me.dtpCycleDate)
        Me.Panel3.Controls.Add(Me.txtChqNo)
        Me.Panel3.Controls.Add(Me.txtContractNo)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.cboEntity)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Location = New System.Drawing.Point(12, 69)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(497, 181)
        Me.Panel3.TabIndex = 1
        '
        'pnlMain
        '
        Me.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlMain.Controls.Add(Me.txtChqId)
        Me.pnlMain.Controls.Add(Me.lbReceivedBy)
        Me.pnlMain.Location = New System.Drawing.Point(12, 12)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(497, 51)
        Me.pnlMain.TabIndex = 0
        '
        'lbReceivedBy
        '
        Me.lbReceivedBy.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lbReceivedBy.Location = New System.Drawing.Point(-10, 16)
        Me.lbReceivedBy.Name = "lbReceivedBy"
        Me.lbReceivedBy.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lbReceivedBy.Size = New System.Drawing.Size(104, 16)
        Me.lbReceivedBy.TabIndex = 48
        Me.lbReceivedBy.Text = "Chq Id"
        '
        'DGrid
        '
        Me.DGrid.AllowUserToAddRows = False
        Me.DGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGrid.Location = New System.Drawing.Point(516, 12)
        Me.DGrid.Name = "DGrid"
        Me.DGrid.Size = New System.Drawing.Size(395, 208)
        Me.DGrid.TabIndex = 2
        '
        'frmChequeUpdate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(924, 261)
        Me.Controls.Add(Me.DGrid)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.pnlMain)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnClear)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmChequeUpdate"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cheque Update"
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.pnlMain.ResumeLayout(False)
        Me.pnlMain.PerformLayout()
        CType(Me.DGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtChqAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtpChqDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpCycleDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtChqNo As System.Windows.Forms.TextBox
    Friend WithEvents txtContractNo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents cboEntity As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtChqId As System.Windows.Forms.TextBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Friend WithEvents lbReceivedBy As System.Windows.Forms.Label
    Friend WithEvents DGrid As System.Windows.Forms.DataGridView
End Class
