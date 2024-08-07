<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBatchEntry
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
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.cboEntity = New System.Windows.Forms.ComboBox()
        Me.lbReceivedBy = New System.Windows.Forms.Label()
        Me.dtpCycleDate = New System.Windows.Forms.DateTimePicker()
        Me.lbReceivedDate = New System.Windows.Forms.Label()
        Me.pnlBatchEntry = New System.Windows.Forms.Panel()
        Me.dgvContractdtls = New System.Windows.Forms.DataGridView()
        Me.btnClr = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.txtChqId = New System.Windows.Forms.TextBox()
        Me.txtChqAmt = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtChqNo = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtContractNo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dgvBatchEntry = New System.Windows.Forms.DataGridView()
        Me.dgvBatchEntrySub = New System.Windows.Forms.DataGridView()
        Me.pnlMain.SuspendLayout()
        Me.pnlBatchEntry.SuspendLayout()
        CType(Me.dgvContractdtls, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvBatchEntry, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvBatchEntrySub, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlMain
        '
        Me.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlMain.Controls.Add(Me.cboEntity)
        Me.pnlMain.Controls.Add(Me.lbReceivedBy)
        Me.pnlMain.Controls.Add(Me.dtpCycleDate)
        Me.pnlMain.Controls.Add(Me.lbReceivedDate)
        Me.pnlMain.Location = New System.Drawing.Point(12, 12)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(511, 49)
        Me.pnlMain.TabIndex = 0
        '
        'cboEntity
        '
        Me.cboEntity.FormattingEnabled = True
        Me.cboEntity.Location = New System.Drawing.Point(292, 15)
        Me.cboEntity.Name = "cboEntity"
        Me.cboEntity.Size = New System.Drawing.Size(204, 21)
        Me.cboEntity.TabIndex = 1
        '
        'lbReceivedBy
        '
        Me.lbReceivedBy.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lbReceivedBy.Location = New System.Drawing.Point(221, 15)
        Me.lbReceivedBy.Name = "lbReceivedBy"
        Me.lbReceivedBy.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lbReceivedBy.Size = New System.Drawing.Size(65, 16)
        Me.lbReceivedBy.TabIndex = 48
        Me.lbReceivedBy.Text = "Entity"
        '
        'dtpCycleDate
        '
        Me.dtpCycleDate.CustomFormat = "dd-MM-yyyy"
        Me.dtpCycleDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpCycleDate.Location = New System.Drawing.Point(87, 12)
        Me.dtpCycleDate.Name = "dtpCycleDate"
        Me.dtpCycleDate.Size = New System.Drawing.Size(106, 21)
        Me.dtpCycleDate.TabIndex = 0
        '
        'lbReceivedDate
        '
        Me.lbReceivedDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lbReceivedDate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbReceivedDate.Location = New System.Drawing.Point(0, 15)
        Me.lbReceivedDate.Name = "lbReceivedDate"
        Me.lbReceivedDate.Size = New System.Drawing.Size(81, 13)
        Me.lbReceivedDate.TabIndex = 45
        Me.lbReceivedDate.Text = "Cycle Date"
        Me.lbReceivedDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnlBatchEntry
        '
        Me.pnlBatchEntry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlBatchEntry.Controls.Add(Me.dgvContractdtls)
        Me.pnlBatchEntry.Controls.Add(Me.btnClr)
        Me.pnlBatchEntry.Controls.Add(Me.btnAdd)
        Me.pnlBatchEntry.Controls.Add(Me.txtChqId)
        Me.pnlBatchEntry.Controls.Add(Me.txtChqAmt)
        Me.pnlBatchEntry.Controls.Add(Me.Label13)
        Me.pnlBatchEntry.Controls.Add(Me.txtChqNo)
        Me.pnlBatchEntry.Controls.Add(Me.Label5)
        Me.pnlBatchEntry.Controls.Add(Me.txtContractNo)
        Me.pnlBatchEntry.Controls.Add(Me.Label2)
        Me.pnlBatchEntry.Location = New System.Drawing.Point(12, 67)
        Me.pnlBatchEntry.Name = "pnlBatchEntry"
        Me.pnlBatchEntry.Size = New System.Drawing.Size(511, 188)
        Me.pnlBatchEntry.TabIndex = 1
        '
        'dgvContractdtls
        '
        Me.dgvContractdtls.AllowUserToAddRows = False
        Me.dgvContractdtls.AllowUserToDeleteRows = False
        Me.dgvContractdtls.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvContractdtls.Location = New System.Drawing.Point(8, 33)
        Me.dgvContractdtls.Name = "dgvContractdtls"
        Me.dgvContractdtls.Size = New System.Drawing.Size(488, 118)
        Me.dgvContractdtls.TabIndex = 56
        '
        'btnClr
        '
        Me.btnClr.Location = New System.Drawing.Point(424, 157)
        Me.btnClr.Name = "btnClr"
        Me.btnClr.Size = New System.Drawing.Size(72, 24)
        Me.btnClr.TabIndex = 5
        Me.btnClr.TabStop = False
        Me.btnClr.Text = "Clear"
        Me.btnClr.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(339, 157)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(72, 24)
        Me.btnAdd.TabIndex = 4
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'txtChqId
        '
        Me.txtChqId.AcceptsReturn = True
        Me.txtChqId.Location = New System.Drawing.Point(250, 159)
        Me.txtChqId.MaxLength = 10
        Me.txtChqId.Name = "txtChqId"
        Me.txtChqId.Size = New System.Drawing.Size(73, 21)
        Me.txtChqId.TabIndex = 3
        Me.txtChqId.TabStop = False
        Me.txtChqId.Visible = False
        '
        'txtChqAmt
        '
        Me.txtChqAmt.Location = New System.Drawing.Point(339, 6)
        Me.txtChqAmt.MaxLength = 18
        Me.txtChqAmt.Name = "txtChqAmt"
        Me.txtChqAmt.Size = New System.Drawing.Size(157, 21)
        Me.txtChqAmt.TabIndex = 1
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(268, 10)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(65, 13)
        Me.Label13.TabIndex = 48
        Me.Label13.Text = "Chq Amt"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtChqNo
        '
        Me.txtChqNo.Location = New System.Drawing.Point(87, 6)
        Me.txtChqNo.MaxLength = 16
        Me.txtChqNo.Name = "txtChqNo"
        Me.txtChqNo.Size = New System.Drawing.Size(157, 21)
        Me.txtChqNo.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(12, 10)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 13)
        Me.Label5.TabIndex = 47
        Me.Label5.Text = "Chq No"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtContractNo
        '
        Me.txtContractNo.Location = New System.Drawing.Point(87, 159)
        Me.txtContractNo.MaxLength = 32
        Me.txtContractNo.Name = "txtContractNo"
        Me.txtContractNo.Size = New System.Drawing.Size(157, 21)
        Me.txtContractNo.TabIndex = 2
        Me.txtContractNo.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 163)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 13)
        Me.Label2.TabIndex = 55
        Me.Label2.Text = "Contract No"
        '
        'dgvBatchEntry
        '
        Me.dgvBatchEntry.AllowUserToAddRows = False
        Me.dgvBatchEntry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBatchEntry.Location = New System.Drawing.Point(12, 261)
        Me.dgvBatchEntry.Name = "dgvBatchEntry"
        Me.dgvBatchEntry.Size = New System.Drawing.Size(1080, 240)
        Me.dgvBatchEntry.TabIndex = 2
        '
        'dgvBatchEntrySub
        '
        Me.dgvBatchEntrySub.AllowUserToAddRows = False
        Me.dgvBatchEntrySub.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBatchEntrySub.Location = New System.Drawing.Point(529, 12)
        Me.dgvBatchEntrySub.Name = "dgvBatchEntrySub"
        Me.dgvBatchEntrySub.Size = New System.Drawing.Size(563, 243)
        Me.dgvBatchEntrySub.TabIndex = 3
        '
        'frmBatchEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1104, 506)
        Me.Controls.Add(Me.dgvBatchEntrySub)
        Me.Controls.Add(Me.dgvBatchEntry)
        Me.Controls.Add(Me.pnlBatchEntry)
        Me.Controls.Add(Me.pnlMain)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBatchEntry"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Batch Entry"
        Me.pnlMain.ResumeLayout(False)
        Me.pnlBatchEntry.ResumeLayout(False)
        Me.pnlBatchEntry.PerformLayout()
        CType(Me.dgvContractdtls, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvBatchEntry, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvBatchEntrySub, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Friend WithEvents lbReceivedDate As System.Windows.Forms.Label
    Friend WithEvents dtpCycleDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbReceivedBy As System.Windows.Forms.Label
    Friend WithEvents cboEntity As System.Windows.Forms.ComboBox
    Friend WithEvents pnlBatchEntry As System.Windows.Forms.Panel
    Friend WithEvents txtChqAmt As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtChqNo As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnClr As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents txtChqId As System.Windows.Forms.TextBox
    Friend WithEvents txtContractNo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dgvBatchEntry As System.Windows.Forms.DataGridView
    Friend WithEvents dgvBatchEntrySub As System.Windows.Forms.DataGridView
    Friend WithEvents dgvContractdtls As System.Windows.Forms.DataGridView
End Class
