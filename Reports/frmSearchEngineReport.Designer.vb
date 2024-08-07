<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSearchEngineReport
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
        Me.grpMain = New System.Windows.Forms.GroupBox()
        Me.cboEntity = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblChqno = New System.Windows.Forms.Label()
        Me.lblContract = New System.Windows.Forms.Label()
        Me.txtchqno = New System.Windows.Forms.TextBox()
        Me.txtcontno = New System.Windows.Forms.TextBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.lblAplobinput = New System.Windows.Forms.Label()
        Me.dgvcheque = New System.Windows.Forms.DataGridView()
        Me.dgvPullout = New System.Windows.Forms.DataGridView()
        Me.dgvScan = New System.Windows.Forms.DataGridView()
        Me.dgvAplob = New System.Windows.Forms.DataGridView()
        Me.lblCheque = New System.Windows.Forms.Label()
        Me.lblPullout = New System.Windows.Forms.Label()
        Me.lblScan = New System.Windows.Forms.Label()
        Me.lblAplobCount = New System.Windows.Forms.Label()
        Me.lblChequeCount = New System.Windows.Forms.Label()
        Me.lblPulloutCount = New System.Windows.Forms.Label()
        Me.lblScanCount = New System.Windows.Forms.Label()
        Me.grpMain.SuspendLayout()
        CType(Me.dgvcheque, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvPullout, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvScan, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvAplob, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpMain
        '
        Me.grpMain.Controls.Add(Me.cboEntity)
        Me.grpMain.Controls.Add(Me.Label6)
        Me.grpMain.Controls.Add(Me.lblChqno)
        Me.grpMain.Controls.Add(Me.lblContract)
        Me.grpMain.Controls.Add(Me.txtchqno)
        Me.grpMain.Controls.Add(Me.txtcontno)
        Me.grpMain.Location = New System.Drawing.Point(12, 5)
        Me.grpMain.Name = "grpMain"
        Me.grpMain.Size = New System.Drawing.Size(811, 52)
        Me.grpMain.TabIndex = 13
        Me.grpMain.TabStop = False
        '
        'cboEntity
        '
        Me.cboEntity.FormattingEnabled = True
        Me.cboEntity.Location = New System.Drawing.Point(59, 18)
        Me.cboEntity.Name = "cboEntity"
        Me.cboEntity.Size = New System.Drawing.Size(255, 21)
        Me.cboEntity.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(11, 21)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 13)
        Me.Label6.TabIndex = 26
        Me.Label6.Text = "Entity"
        '
        'lblChqno
        '
        Me.lblChqno.AutoSize = True
        Me.lblChqno.Location = New System.Drawing.Point(574, 21)
        Me.lblChqno.Name = "lblChqno"
        Me.lblChqno.Size = New System.Drawing.Size(66, 13)
        Me.lblChqno.TabIndex = 2
        Me.lblChqno.Text = "Cheque No"
        '
        'lblContract
        '
        Me.lblContract.Location = New System.Drawing.Point(320, 21)
        Me.lblContract.Name = "lblContract"
        Me.lblContract.Size = New System.Drawing.Size(80, 13)
        Me.lblContract.TabIndex = 0
        Me.lblContract.Text = "Contract No"
        Me.lblContract.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtchqno
        '
        Me.txtchqno.Location = New System.Drawing.Point(646, 18)
        Me.txtchqno.Name = "txtchqno"
        Me.txtchqno.Size = New System.Drawing.Size(154, 21)
        Me.txtchqno.TabIndex = 2
        '
        'txtcontno
        '
        Me.txtcontno.Location = New System.Drawing.Point(406, 18)
        Me.txtcontno.Name = "txtcontno"
        Me.txtcontno.Size = New System.Drawing.Size(154, 21)
        Me.txtcontno.TabIndex = 1
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(749, 59)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(74, 23)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(669, 59)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(74, 23)
        Me.btnClear.TabIndex = 2
        Me.btnClear.Text = "C&lear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnExport
        '
        Me.btnExport.Location = New System.Drawing.Point(589, 59)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(74, 23)
        Me.btnExport.TabIndex = 1
        Me.btnExport.Text = "&Export"
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(509, 59)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(74, 23)
        Me.btnSearch.TabIndex = 0
        Me.btnSearch.Text = "&Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'lblAplobinput
        '
        Me.lblAplobinput.AutoSize = True
        Me.lblAplobinput.Font = New System.Drawing.Font("Tahoma", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAplobinput.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblAplobinput.Location = New System.Drawing.Point(18, 69)
        Me.lblAplobinput.Name = "lblAplobinput"
        Me.lblAplobinput.Size = New System.Drawing.Size(115, 13)
        Me.lblAplobinput.TabIndex = 20
        Me.lblAplobinput.Text = "Aplob Input Details"
        '
        'dgvcheque
        '
        Me.dgvcheque.AllowUserToAddRows = False
        Me.dgvcheque.AllowUserToDeleteRows = False
        Me.dgvcheque.BackgroundColor = System.Drawing.Color.White
        Me.dgvcheque.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvcheque.Location = New System.Drawing.Point(12, 193)
        Me.dgvcheque.Name = "dgvcheque"
        Me.dgvcheque.ReadOnly = True
        Me.dgvcheque.Size = New System.Drawing.Size(811, 86)
        Me.dgvcheque.TabIndex = 25
        '
        'dgvPullout
        '
        Me.dgvPullout.AllowUserToAddRows = False
        Me.dgvPullout.AllowUserToDeleteRows = False
        Me.dgvPullout.BackgroundColor = System.Drawing.Color.White
        Me.dgvPullout.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPullout.Location = New System.Drawing.Point(12, 298)
        Me.dgvPullout.Name = "dgvPullout"
        Me.dgvPullout.ReadOnly = True
        Me.dgvPullout.Size = New System.Drawing.Size(811, 86)
        Me.dgvPullout.TabIndex = 26
        '
        'dgvScan
        '
        Me.dgvScan.AllowUserToAddRows = False
        Me.dgvScan.AllowUserToDeleteRows = False
        Me.dgvScan.BackgroundColor = System.Drawing.Color.White
        Me.dgvScan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvScan.Location = New System.Drawing.Point(12, 403)
        Me.dgvScan.Name = "dgvScan"
        Me.dgvScan.ReadOnly = True
        Me.dgvScan.Size = New System.Drawing.Size(811, 86)
        Me.dgvScan.TabIndex = 27
        '
        'dgvAplob
        '
        Me.dgvAplob.AllowUserToAddRows = False
        Me.dgvAplob.AllowUserToDeleteRows = False
        Me.dgvAplob.BackgroundColor = System.Drawing.Color.White
        Me.dgvAplob.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAplob.Location = New System.Drawing.Point(12, 88)
        Me.dgvAplob.Name = "dgvAplob"
        Me.dgvAplob.ReadOnly = True
        Me.dgvAplob.Size = New System.Drawing.Size(811, 86)
        Me.dgvAplob.TabIndex = 24
        '
        'lblCheque
        '
        Me.lblCheque.AutoSize = True
        Me.lblCheque.Font = New System.Drawing.Font("Tahoma", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCheque.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblCheque.Location = New System.Drawing.Point(18, 177)
        Me.lblCheque.Name = "lblCheque"
        Me.lblCheque.Size = New System.Drawing.Size(91, 13)
        Me.lblCheque.TabIndex = 28
        Me.lblCheque.Text = "Cheque Details"
        '
        'lblPullout
        '
        Me.lblPullout.AutoSize = True
        Me.lblPullout.Font = New System.Drawing.Font("Tahoma", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPullout.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblPullout.Location = New System.Drawing.Point(18, 282)
        Me.lblPullout.Name = "lblPullout"
        Me.lblPullout.Size = New System.Drawing.Size(89, 13)
        Me.lblPullout.TabIndex = 29
        Me.lblPullout.Text = "PullOut Details"
        '
        'lblScan
        '
        Me.lblScan.AutoSize = True
        Me.lblScan.Font = New System.Drawing.Font("Tahoma", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblScan.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblScan.Location = New System.Drawing.Point(18, 387)
        Me.lblScan.Name = "lblScan"
        Me.lblScan.Size = New System.Drawing.Size(76, 13)
        Me.lblScan.TabIndex = 30
        Me.lblScan.Text = "Scan Details"
        '
        'lblAplobCount
        '
        Me.lblAplobCount.ForeColor = System.Drawing.Color.DarkRed
        Me.lblAplobCount.Location = New System.Drawing.Point(139, 69)
        Me.lblAplobCount.Name = "lblAplobCount"
        Me.lblAplobCount.Size = New System.Drawing.Size(99, 13)
        Me.lblAplobCount.TabIndex = 31
        Me.lblAplobCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblAplobCount.Visible = False
        '
        'lblChequeCount
        '
        Me.lblChequeCount.ForeColor = System.Drawing.Color.DarkRed
        Me.lblChequeCount.Location = New System.Drawing.Point(139, 177)
        Me.lblChequeCount.Name = "lblChequeCount"
        Me.lblChequeCount.Size = New System.Drawing.Size(99, 13)
        Me.lblChequeCount.TabIndex = 32
        Me.lblChequeCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblChequeCount.Visible = False
        '
        'lblPulloutCount
        '
        Me.lblPulloutCount.ForeColor = System.Drawing.Color.DarkRed
        Me.lblPulloutCount.Location = New System.Drawing.Point(139, 282)
        Me.lblPulloutCount.Name = "lblPulloutCount"
        Me.lblPulloutCount.Size = New System.Drawing.Size(99, 13)
        Me.lblPulloutCount.TabIndex = 33
        Me.lblPulloutCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblPulloutCount.Visible = False
        '
        'lblScanCount
        '
        Me.lblScanCount.ForeColor = System.Drawing.Color.DarkRed
        Me.lblScanCount.Location = New System.Drawing.Point(139, 387)
        Me.lblScanCount.Name = "lblScanCount"
        Me.lblScanCount.Size = New System.Drawing.Size(99, 13)
        Me.lblScanCount.TabIndex = 34
        Me.lblScanCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblScanCount.Visible = False
        '
        'frmSearchEngineReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(914, 516)
        Me.Controls.Add(Me.lblScanCount)
        Me.Controls.Add(Me.lblPulloutCount)
        Me.Controls.Add(Me.lblChequeCount)
        Me.Controls.Add(Me.lblAplobCount)
        Me.Controls.Add(Me.lblScan)
        Me.Controls.Add(Me.lblPullout)
        Me.Controls.Add(Me.lblCheque)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.dgvcheque)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.dgvPullout)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.dgvScan)
        Me.Controls.Add(Me.dgvAplob)
        Me.Controls.Add(Me.lblAplobinput)
        Me.Controls.Add(Me.grpMain)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Name = "frmSearchEngineReport"
        Me.Text = "Search Engine Report"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.grpMain.ResumeLayout(False)
        Me.grpMain.PerformLayout()
        CType(Me.dgvcheque, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvPullout, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvScan, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvAplob, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grpMain As System.Windows.Forms.GroupBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents lblChqno As System.Windows.Forms.Label
    Friend WithEvents lblContract As System.Windows.Forms.Label
    Friend WithEvents txtchqno As System.Windows.Forms.TextBox
    Friend WithEvents txtcontno As System.Windows.Forms.TextBox
    Friend WithEvents lblAplobinput As System.Windows.Forms.Label
    Friend WithEvents dgvcheque As System.Windows.Forms.DataGridView
    Friend WithEvents dgvPullout As System.Windows.Forms.DataGridView
    Friend WithEvents dgvScan As System.Windows.Forms.DataGridView
    Friend WithEvents dgvAplob As System.Windows.Forms.DataGridView
    Friend WithEvents cboEntity As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblCheque As System.Windows.Forms.Label
    Friend WithEvents lblPullout As System.Windows.Forms.Label
    Friend WithEvents lblScan As System.Windows.Forms.Label
    Friend WithEvents lblAplobCount As System.Windows.Forms.Label
    Friend WithEvents lblChequeCount As System.Windows.Forms.Label
    Friend WithEvents lblPulloutCount As System.Windows.Forms.Label
    Friend WithEvents lblScanCount As System.Windows.Forms.Label

End Class
