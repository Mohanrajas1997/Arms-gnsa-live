<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGenerateBatch
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
        Me.cboProdcode = New System.Windows.Forms.ComboBox()
        Me.btnCloss = New System.Windows.Forms.Button()
        Me.btnGenerate = New System.Windows.Forms.Button()
        Me.cboLocCode = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboEntity = New System.Windows.Forms.ComboBox()
        Me.lbReceivedBy = New System.Windows.Forms.Label()
        Me.dtpCycleDate = New System.Windows.Forms.DateTimePicker()
        Me.lbReceivedDate = New System.Windows.Forms.Label()
        Me.pnlMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlMain
        '
        Me.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlMain.Controls.Add(Me.cboProdcode)
        Me.pnlMain.Controls.Add(Me.btnCloss)
        Me.pnlMain.Controls.Add(Me.btnGenerate)
        Me.pnlMain.Controls.Add(Me.cboLocCode)
        Me.pnlMain.Controls.Add(Me.Label1)
        Me.pnlMain.Controls.Add(Me.Label2)
        Me.pnlMain.Controls.Add(Me.cboEntity)
        Me.pnlMain.Controls.Add(Me.lbReceivedBy)
        Me.pnlMain.Controls.Add(Me.dtpCycleDate)
        Me.pnlMain.Controls.Add(Me.lbReceivedDate)
        Me.pnlMain.Location = New System.Drawing.Point(12, 12)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(579, 119)
        Me.pnlMain.TabIndex = 1
        '
        'cboProdcode
        '
        Me.cboProdcode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.cboProdcode.FormattingEnabled = True
        Me.cboProdcode.Location = New System.Drawing.Point(96, 44)
        Me.cboProdcode.Name = "cboProdcode"
        Me.cboProdcode.Size = New System.Drawing.Size(186, 21)
        Me.cboProdcode.TabIndex = 2
        '
        'btnCloss
        '
        Me.btnCloss.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnCloss.Location = New System.Drawing.Point(489, 80)
        Me.btnCloss.Name = "btnCloss"
        Me.btnCloss.Size = New System.Drawing.Size(72, 24)
        Me.btnCloss.TabIndex = 5
        Me.btnCloss.TabStop = False
        Me.btnCloss.Text = "Close"
        Me.btnCloss.UseVisualStyleBackColor = True
        '
        'btnGenerate
        '
        Me.btnGenerate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerate.Location = New System.Drawing.Point(411, 80)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(72, 24)
        Me.btnGenerate.TabIndex = 4
        Me.btnGenerate.Text = "Generate"
        Me.btnGenerate.UseVisualStyleBackColor = True
        '
        'cboLocCode
        '
        Me.cboLocCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.cboLocCode.FormattingEnabled = True
        Me.cboLocCode.Location = New System.Drawing.Point(375, 44)
        Me.cboLocCode.Name = "cboLocCode"
        Me.cboLocCode.Size = New System.Drawing.Size(186, 21)
        Me.cboLocCode.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(304, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label1.Size = New System.Drawing.Size(65, 16)
        Me.Label1.TabIndex = 52
        Me.Label1.Text = "Loc Code"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(3, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 13)
        Me.Label2.TabIndex = 50
        Me.Label2.Text = "Prod Code"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboEntity
        '
        Me.cboEntity.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.cboEntity.FormattingEnabled = True
        Me.cboEntity.Location = New System.Drawing.Point(375, 18)
        Me.cboEntity.Name = "cboEntity"
        Me.cboEntity.Size = New System.Drawing.Size(186, 21)
        Me.cboEntity.TabIndex = 1
        '
        'lbReceivedBy
        '
        Me.lbReceivedBy.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lbReceivedBy.Location = New System.Drawing.Point(304, 18)
        Me.lbReceivedBy.Name = "lbReceivedBy"
        Me.lbReceivedBy.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lbReceivedBy.Size = New System.Drawing.Size(65, 16)
        Me.lbReceivedBy.TabIndex = 48
        Me.lbReceivedBy.Text = "Entity"
        '
        'dtpCycleDate
        '
        Me.dtpCycleDate.CustomFormat = "dd-MM-yyyy"
        Me.dtpCycleDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpCycleDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpCycleDate.Location = New System.Drawing.Point(96, 18)
        Me.dtpCycleDate.Name = "dtpCycleDate"
        Me.dtpCycleDate.Size = New System.Drawing.Size(186, 21)
        Me.dtpCycleDate.TabIndex = 0
        '
        'lbReceivedDate
        '
        Me.lbReceivedDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lbReceivedDate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbReceivedDate.Location = New System.Drawing.Point(3, 18)
        Me.lbReceivedDate.Name = "lbReceivedDate"
        Me.lbReceivedDate.Size = New System.Drawing.Size(81, 13)
        Me.lbReceivedDate.TabIndex = 45
        Me.lbReceivedDate.Text = "Cycle Date"
        Me.lbReceivedDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmGenerateBatch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(603, 144)
        Me.Controls.Add(Me.pnlMain)
        Me.Name = "frmGenerateBatch"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Generate Batch"
        Me.pnlMain.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Friend WithEvents cboLocCode As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboEntity As System.Windows.Forms.ComboBox
    Friend WithEvents lbReceivedBy As System.Windows.Forms.Label
    Friend WithEvents dtpCycleDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbReceivedDate As System.Windows.Forms.Label
    Friend WithEvents cboProdcode As System.Windows.Forms.ComboBox
    Friend WithEvents btnCloss As System.Windows.Forms.Button
    Friend WithEvents btnGenerate As System.Windows.Forms.Button
End Class
