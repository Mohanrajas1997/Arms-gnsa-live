<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPulloutStatusUpdate
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
        Me.btnExport = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.pnlDisplay = New System.Windows.Forms.Panel()
        Me.lblRecCount = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboEntity = New System.Windows.Forms.ComboBox()
        Me.pnlButtons = New System.Windows.Forms.Panel()
        Me.BtnUpdate = New System.Windows.Forms.Button()
        Me.BtnInverse = New System.Windows.Forms.Button()
        Me.BtnDeSelect = New System.Windows.Forms.Button()
        Me.BtnSelect = New System.Windows.Forms.Button()
        Me.TxtPulloutId = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpReqTo = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpReqFrom = New System.Windows.Forms.DateTimePicker()
        Me.dgvReport = New System.Windows.Forms.DataGridView()
        Me.pnlDisplay.SuspendLayout()
        Me.pnlButtons.SuspendLayout()
        CType(Me.dgvReport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnExport
        '
        Me.btnExport.Location = New System.Drawing.Point(711, 2)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(72, 24)
        Me.btnExport.TabIndex = 0
        Me.btnExport.Text = "E&xport"
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(103, 13)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "Pullout Req From"
        '
        'pnlDisplay
        '
        Me.pnlDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlDisplay.Controls.Add(Me.lblRecCount)
        Me.pnlDisplay.Controls.Add(Me.btnExport)
        Me.pnlDisplay.Location = New System.Drawing.Point(12, 340)
        Me.pnlDisplay.Name = "pnlDisplay"
        Me.pnlDisplay.Size = New System.Drawing.Size(794, 32)
        Me.pnlDisplay.TabIndex = 2
        '
        'lblRecCount
        '
        Me.lblRecCount.AutoSize = True
        Me.lblRecCount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblRecCount.Location = New System.Drawing.Point(9, 8)
        Me.lblRecCount.Name = "lblRecCount"
        Me.lblRecCount.Size = New System.Drawing.Size(83, 13)
        Me.lblRecCount.TabIndex = 0
        Me.lblRecCount.Text = "Record Count"
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(712, 43)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(72, 24)
        Me.btnClose.TabIndex = 10
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(638, 43)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(72, 24)
        Me.btnClear.TabIndex = 9
        Me.btnClear.Text = "C&lear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(254, 43)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(72, 24)
        Me.btnRefresh.TabIndex = 4
        Me.btnRefresh.Text = "&Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(372, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 13)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "Entity"
        '
        'cboEntity
        '
        Me.cboEntity.FormattingEnabled = True
        Me.cboEntity.Location = New System.Drawing.Point(418, 13)
        Me.cboEntity.Name = "cboEntity"
        Me.cboEntity.Size = New System.Drawing.Size(366, 21)
        Me.cboEntity.TabIndex = 2
        '
        'pnlButtons
        '
        Me.pnlButtons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlButtons.Controls.Add(Me.BtnUpdate)
        Me.pnlButtons.Controls.Add(Me.BtnInverse)
        Me.pnlButtons.Controls.Add(Me.BtnDeSelect)
        Me.pnlButtons.Controls.Add(Me.BtnSelect)
        Me.pnlButtons.Controls.Add(Me.TxtPulloutId)
        Me.pnlButtons.Controls.Add(Me.Label2)
        Me.pnlButtons.Controls.Add(Me.dtpReqTo)
        Me.pnlButtons.Controls.Add(Me.Label1)
        Me.pnlButtons.Controls.Add(Me.dtpReqFrom)
        Me.pnlButtons.Controls.Add(Me.btnClose)
        Me.pnlButtons.Controls.Add(Me.btnClear)
        Me.pnlButtons.Controls.Add(Me.btnRefresh)
        Me.pnlButtons.Controls.Add(Me.Label4)
        Me.pnlButtons.Controls.Add(Me.Label6)
        Me.pnlButtons.Controls.Add(Me.cboEntity)
        Me.pnlButtons.Location = New System.Drawing.Point(14, 12)
        Me.pnlButtons.Name = "pnlButtons"
        Me.pnlButtons.Size = New System.Drawing.Size(792, 76)
        Me.pnlButtons.TabIndex = 0
        '
        'BtnUpdate
        '
        Me.BtnUpdate.BackColor = System.Drawing.Color.Gold
        Me.BtnUpdate.Location = New System.Drawing.Point(561, 44)
        Me.BtnUpdate.Name = "BtnUpdate"
        Me.BtnUpdate.Size = New System.Drawing.Size(75, 23)
        Me.BtnUpdate.TabIndex = 8
        Me.BtnUpdate.Text = "Update"
        Me.BtnUpdate.UseVisualStyleBackColor = False
        '
        'BtnInverse
        '
        Me.BtnInverse.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.BtnInverse.Location = New System.Drawing.Point(485, 44)
        Me.BtnInverse.Name = "BtnInverse"
        Me.BtnInverse.Size = New System.Drawing.Size(75, 23)
        Me.BtnInverse.TabIndex = 7
        Me.BtnInverse.Text = "Inverse"
        Me.BtnInverse.UseVisualStyleBackColor = False
        '
        'BtnDeSelect
        '
        Me.BtnDeSelect.BackColor = System.Drawing.Color.LightCoral
        Me.BtnDeSelect.Location = New System.Drawing.Point(407, 44)
        Me.BtnDeSelect.Name = "BtnDeSelect"
        Me.BtnDeSelect.Size = New System.Drawing.Size(75, 23)
        Me.BtnDeSelect.TabIndex = 6
        Me.BtnDeSelect.Text = "De-Select"
        Me.BtnDeSelect.UseVisualStyleBackColor = False
        '
        'BtnSelect
        '
        Me.BtnSelect.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.BtnSelect.Location = New System.Drawing.Point(329, 44)
        Me.BtnSelect.Name = "BtnSelect"
        Me.BtnSelect.Size = New System.Drawing.Size(75, 23)
        Me.BtnSelect.TabIndex = 5
        Me.BtnSelect.Text = "Select"
        Me.BtnSelect.UseVisualStyleBackColor = False
        '
        'TxtPulloutId
        '
        Me.TxtPulloutId.Location = New System.Drawing.Point(111, 43)
        Me.TxtPulloutId.Name = "TxtPulloutId"
        Me.TxtPulloutId.Size = New System.Drawing.Size(115, 21)
        Me.TxtPulloutId.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(45, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "Pullout Id"
        '
        'dtpReqTo
        '
        Me.dtpReqTo.CustomFormat = "dd-MM-yyyy"
        Me.dtpReqTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpReqTo.Location = New System.Drawing.Point(253, 13)
        Me.dtpReqTo.Name = "dtpReqTo"
        Me.dtpReqTo.ShowCheckBox = True
        Me.dtpReqTo.Size = New System.Drawing.Size(115, 21)
        Me.dtpReqTo.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(233, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(21, 13)
        Me.Label1.TabIndex = 30
        Me.Label1.Text = "To"
        '
        'dtpReqFrom
        '
        Me.dtpReqFrom.CustomFormat = "dd-MM-yyyy"
        Me.dtpReqFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpReqFrom.Location = New System.Drawing.Point(111, 12)
        Me.dtpReqFrom.Name = "dtpReqFrom"
        Me.dtpReqFrom.ShowCheckBox = True
        Me.dtpReqFrom.Size = New System.Drawing.Size(115, 21)
        Me.dtpReqFrom.TabIndex = 0
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
        Me.dgvReport.Location = New System.Drawing.Point(12, 94)
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
        Me.dgvReport.Size = New System.Drawing.Size(794, 240)
        Me.dgvReport.TabIndex = 2
        '
        'frmPulloutStatusUpdate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(986, 384)
        Me.Controls.Add(Me.dgvReport)
        Me.Controls.Add(Me.pnlDisplay)
        Me.Controls.Add(Me.pnlButtons)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmPulloutStatusUpdate"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pullout Status Update"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlDisplay.ResumeLayout(False)
        Me.pnlDisplay.PerformLayout()
        Me.pnlButtons.ResumeLayout(False)
        Me.pnlButtons.PerformLayout()
        CType(Me.dgvReport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents pnlDisplay As System.Windows.Forms.Panel
    Friend WithEvents lblRecCount As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboEntity As System.Windows.Forms.ComboBox
    Friend WithEvents pnlButtons As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpReqFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpReqTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtPulloutId As System.Windows.Forms.TextBox
    Friend WithEvents BtnSelect As System.Windows.Forms.Button
    Friend WithEvents BtnDeSelect As System.Windows.Forms.Button
    Friend WithEvents BtnInverse As System.Windows.Forms.Button
    Friend WithEvents BtnUpdate As System.Windows.Forms.Button
    Friend WithEvents dgvReport As System.Windows.Forms.DataGridView
End Class
