Imports System.Windows.Forms

Public Class frmMain

    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs) Handles NewWindowToolStripMenuItem.Click
        ' Create a new instance of the child form.
        Dim ChildForm As New System.Windows.Forms.Form
        ' Make it a child of this MDI form before showing it.
        ChildForm.MdiParent = Me

        m_ChildFormNumber += 1
        ChildForm.Text = "Window " & m_ChildFormNumber

        ChildForm.Show()
    End Sub

    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs)
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = OpenFileDialog.FileName
            ' TODO: Add code here to open the file.
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        SaveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"

        If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = SaveFileDialog.FileName
            ' TODO: Add code here to save the current contents of the form to a file.
        End If
    End Sub


    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.Close()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        'Use My.Computer.Clipboard.GetText() or My.Computer.Clipboard.GetData to retrieve information from the clipboard.
    End Sub

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CascadeToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileVerticalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileHorizontalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ArrangeIconsToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CloseAllToolStripMenuItem.Click
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private m_ChildFormNumber As Integer

    Private Sub mnuBankMaster_Click(sender As Object, e As EventArgs) Handles mnuBankMaster.Click
        Dim frmObj As New frmBank
        frmObj.ShowDialog()
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ms As New MenuStrip
        Dim lsVersion As String

        Try
            Call Main()

            If gnLoginUserId > 0 Then
                ms = Me.MenuStrip

                For i = 0 To ms.Items.Count - 1
                    Application.DoEvents()
                    Call LoadSubMenuItems(ms.Items(i))
                Next i
            End If

            Me.WindowState = FormWindowState.Maximized

            Me.Visible = True
            lblStatus.Text = ""

            lsVersion = Application.ProductVersion
            Me.Text = Me.Text & " Version " & lsVersion.Split(".")(0) & "." & lsVersion.Split(".")(1)
            Me.lblUser.Text = "User : " & gsLoginUserCode
        Catch ex As Exception
            MessageBox.Show(ex.Message, gsProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadSubMenuItems(ByVal mnu As ToolStripMenuItem)
        Dim i As Integer
        Dim lsSql As String
        Dim lnCount As Integer

        Try
            lsSql = ""
            lsSql &= " select count(*) from soft_mst_trights "
            lsSql &= " where usergroup_gid = '" & gnLoginUserGrpId & "' "
            lsSql &= " and menu_name = '" & mnu.Name & "' "
            lsSql &= " and rights_flag = 1 "
            lsSql &= " and delete_flag = 'N' "

            lnCount = Val(gfExecuteScalar(lsSql, gOdbcConn))

            If lnCount > 0 Then
                If mnu.DropDownItems.Count > 0 Then
                    For i = 0 To mnu.DropDownItems.Count - 1
                        If mnu.DropDownItems.Item(i).Text <> "" Then
                            Application.DoEvents()
                            LoadSubMenuItems(mnu.DropDownItems.Item(i))
                        End If
                    Next i
                End If
            Else
                mnu.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, gsProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub mnuUserCreation_Click(sender As Object, e As EventArgs) Handles mnuUserCreation.Click
        Dim objfrm As New frmUserMaster
        objfrm.ShowDialog()
    End Sub

    Private Sub SetPasswordToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SetPasswordToolStripMenuItem.Click
        Dim objfrm As New frmChngPwd
        objfrm.ShowDialog()
    End Sub

    Private Sub mnuUserGrp_Click(sender As Object, e As EventArgs) Handles mnuUserGrp.Click
        Dim objFrm As New frmNameMaster("soft_mst_tusergroup", "usergroup_gid", "User Group Id", "usergroup_name", "Region Name", "32", "delete_flag", "User Group Name", "User Group Master", "", "", False)
        objFrm.ShowDialog()
    End Sub

    Private Sub mnuUserGrpRights_Click(sender As Object, e As EventArgs) Handles mnuUserGrpRights.Click
        Dim objfrm As New frmRights
        objfrm.ShowDialog()
    End Sub

    Private Sub mnuUserAuth_Click(sender As Object, e As EventArgs) Handles mnuUserAuth.Click
        Dim frm As New frmUserAuth
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub mnuUserAuthRpt_Click(sender As Object, e As EventArgs) Handles mnuUserAuthRpt.Click
        Dim frm As New frmUserAuthReport
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub mnuUserLog_Click(sender As Object, e As EventArgs) Handles mnuUserLog.Click
        Dim frm As New frmUserManagementReport
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub LocationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LocationToolStripMenuItem.Click
        Dim frmObj As New frmLocation
        frmObj.ShowDialog()
    End Sub

    Private Sub EntityToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EntityToolStripMenuItem.Click
        Dim frmObj As New frmEntity
        frmObj.ShowDialog()
    End Sub

    Private Sub CourierToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CourierToolStripMenuItem.Click
        Dim frmObj As New frmCourier
        frmObj.ShowDialog()
    End Sub

    Private Sub PulloutReasonToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PulloutReasonToolStripMenuItem.Click
        Dim frmObj As New frmPulloutreason
        frmObj.ShowDialog()
    End Sub

    Private Sub InwardToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InwardToolStripMenuItem.Click
        Dim frmObj As New frmInward
        frmObj.ShowDialog()
    End Sub

    Private Sub PulloutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PulloutToolStripMenuItem.Click
        Dim frmObj As New frmPullout
        frmObj.ShowDialog()
    End Sub

    Private Sub AplobinputToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AplobinputToolStripMenuItem.Click
        Dim frmObj As New frmAplobinput
        frmObj.ShowDialog()
    End Sub

    Private Sub AplobOutputToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AplobOutputToolStripMenuItem.Click
        Dim frmObj As New frmAploboutput
        frmObj.ShowDialog()
    End Sub

    Private Sub DeleteFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteFileToolStripMenuItem.Click
        Dim frmObj As New frmDeleteFile
        frmObj.ShowDialog()
    End Sub

    Private Sub AplobInputToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AplobInputToolStripMenuItem1.Click
        Dim objfrm As New frmAplobInputReport
        objfrm.MdiParent = Me
        objfrm.Show()
    End Sub

    Private Sub RplobToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RplobToolStripMenuItem.Click
        Dim objfrm As New frmRplobReport
        objfrm.MdiParent = Me
        objfrm.Show()
    End Sub

    Private Sub ChequeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChequeToolStripMenuItem.Click
        Dim objfrm As New frmChequeReport
        objfrm.MdiParent = Me
        objfrm.Show()
    End Sub

    Private Sub PulloutToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PulloutToolStripMenuItem1.Click
        Dim objfrm As New frmPulloutReport
        objfrm.MdiParent = Me
        objfrm.Show()
    End Sub

    Private Sub PostingFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PostingDumpToolStripMenuItem.Click
        Dim frmObj As New frmPostFile
        frmObj.ShowDialog()
    End Sub

    Private Sub UndoFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UndoFileToolStripMenuItem.Click
        Dim frmObj As New frmUndoFile
        frmObj.ShowDialog()
    End Sub

    Private Sub BatchEntryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BatchEntryToolStripMenuItem.Click
        Dim frmObj As New frmBatchEntry
        frmObj.ShowDialog()
    End Sub

    Private Sub GenerateBatchToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GenerateBatchToolStripMenuItem.Click
        Dim frmObj As New frmGenerateBatch
        frmObj.ShowDialog()
    End Sub

    Private Sub BatchTicketToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BatchTicketToolStripMenuItem.Click
        Dim frmObj As New frmBatchTicket
        frmObj.ShowDialog()
    End Sub

    Private Sub ChequeToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ChequeToolStripMenuItem1.Click
        Dim frmObj As New frmChequeDelete
        frmObj.ShowDialog()
    End Sub

    Private Sub AplobInputToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles AplobInputToolStripMenuItem2.Click
        Dim frmObj As New frmAplobInputDelete
        frmObj.ShowDialog()
    End Sub

    Private Sub RplobToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles RplobToolStripMenuItem1.Click
        Dim frmObj As New frmRplobDelete
        frmObj.ShowDialog()
    End Sub

    Private Sub BatchToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BatchToolStripMenuItem.Click
        Dim frmObj As New frmBatchDelete
        frmObj.ShowDialog()
    End Sub

    Private Sub BatchChequeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BatchChequeToolStripMenuItem.Click
        Dim frmObj As New frmBatchChequeDelete
        frmObj.ShowDialog()
    End Sub

    Private Sub BatchToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles BatchToolStripMenuItem1.Click
        Dim frmObj As New frmBatchReport
        frmObj.MdiParent = Me
        frmObj.Show()
    End Sub

    Private Sub mnuExit_Click(sender As Object, e As EventArgs) Handles mnuExit.Click
        If MsgBox("Are you sure to exit ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, gsProjectName) = MsgBoxResult.Yes Then
            End
        End If
    End Sub

    Private Sub RplobToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles RplobToolStripMenuItem2.Click
        Dim frmObj As New frmRplobNew
        frmObj.ShowDialog()
    End Sub

    Private Sub FeatureRplobToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FeatureRplobToolStripMenuItem.Click
        Dim objfrm As New frmFeatureRplobReport
        objfrm.MdiParent = Me
        objfrm.Show()
    End Sub

    Private Sub ChequeUpdateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChequeUpdateToolStripMenuItem.Click
        Dim frmObj As New frmChequeUpdate
        frmObj.ShowDialog()
    End Sub

    Private Sub mnuFileReport_Click(sender As Object, e As EventArgs) Handles mnuFileReport.Click
        Dim objfrm As New frmFileReport
        objfrm.MdiParent = Me
        objfrm.Show()
    End Sub

    Private Sub mnuQryReport_Click(sender As Object, e As EventArgs) Handles mnuQryReport.Click
        Dim objfrm As New frmQryReport
        objfrm.MdiParent = Me
        objfrm.Show()
    End Sub

    Private Sub mnuErrLineReport_Click(sender As Object, e As EventArgs) Handles mnuErrLineReport.Click
        Dim objfrm As New frmErrLineReport
        objfrm.MdiParent = Me
        objfrm.Show()
    End Sub

    Private Sub mnuInwardReport_Click(sender As Object, e As EventArgs) Handles mnuInwardReport.Click
        Dim objfrm As New frmInwardReport
        objfrm.MdiParent = Me
        objfrm.Show()
    End Sub

    Private Sub AlmiraToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AlmiraToolStripMenuItem.Click
        Dim frmObj As New frmAlmira
        frmObj.ShowDialog()
    End Sub

    Private Sub PacketEntryToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PacketEntryToolStripMenuItem.Click
        Dim frmobj As New frmPacketEntry
        frmobj.MdiParent = Me
        frmobj.Show()
        'frmobj.ShowDialog()
    End Sub

    Private Sub MicrToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles MicrToolStripMenuItem.Click
        Dim objfrm As New frmImport(1)
        objfrm.ShowDialog()
    End Sub

    Private Sub BankBranchToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles BankBranchToolStripMenuItem.Click
        Dim objfrm As New frmImport(2)
        objfrm.ShowDialog()
    End Sub

    Private Sub ChequeUploadToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ChequeUploadToolStripMenuItem.Click
        Dim objfrm As New frmChqUpload
        objfrm.ShowDialog()
    End Sub

    Private Sub UndoChequeDiscToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles UndoChequeDiscToolStripMenuItem.Click
        Dim objfrm As New frmUndoChqdesc
        objfrm.ShowDialog()
    End Sub

    Private Sub BankMasterToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles BankMasterToolStripMenuItem.Click
        Dim objfrm As New frmImport(3)
        objfrm.ShowDialog()
    End Sub

    Private Sub MicrToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles MicrToolStripMenuItem1.Click
        Dim objfrm As New frmMicr
        objfrm.ShowDialog()
    End Sub

    Private Sub MicrToolStripMenuItem2_Click(sender As System.Object, e As System.EventArgs) Handles MicrToolStripMenuItem2.Click
        Dim objfrm As New frmMicrReport
        objfrm.MdiParent = Me
        objfrm.Show()
    End Sub

    Private Sub ChequeDeleteToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ChequeDeleteToolStripMenuItem.Click
        Dim objfrm As New frmImport(4)
        objfrm.ShowDialog()
    End Sub

    Private Sub PouchInwardAuthToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PouchInwardAuthToolStripMenuItem.Click
        Dim objfrm As New frmPouchInwardAuth
        objfrm.ShowDialog()
    End Sub

    Private Sub ImageBaseEntryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImageBaseEntryToolStripMenuItem.Click
        Dim objfrm As New frmScanAuditQueue
        objfrm.ShowDialog()
    End Sub

    Private Sub SearchEngineImageBasedToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SearchEngineImageBasedToolStripMenuItem.Click
        Dim objfrm As New frmSearchReport
        objfrm.ShowDialog()
    End Sub

    Private Sub BulkChqUpdateStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BulkChqUpdateStripMenuItem.Click
        Dim objfrm As New frmBulkChqUpdate
        objfrm.MdiParent = Me
        objfrm.Show()
    End Sub

    Private Sub GeneratePresentationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GeneratePresentationToolStripMenuItem.Click
        Dim objfrm As New frmGeneratePresentation
        objfrm.MdiParent = Me
        objfrm.Show()
    End Sub

    Private Sub PacketToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PacketToolStripMenuItem.Click
        Dim frmObj As New frmPacket
        frmObj.ShowDialog()
    End Sub

    Private Sub ChequeNoQryToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ChequeNoQryToolStripMenuItem.Click
        Dim objfrm As New frmChequeNoQry
        objfrm.ShowDialog()
    End Sub

    Private Sub PulloutDispatchToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PulloutDispatchToolStripMenuItem.Click
        Dim objfrm As New frmDispatch
        objfrm.ShowDialog()
    End Sub

    Private Sub PulloutStatusUpdateToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PulloutStatusUpdateToolStripMenuItem.Click
        Dim objfrm As New frmPulloutStatusUpdate
        objfrm.MdiParent = Me
        objfrm.Show()
    End Sub

    Private Sub EntityToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles EntityToolStripMenuItem1.Click
        Dim objfrm As New frmEntityReport
        objfrm.MdiParent = Me
        objfrm.Show()
    End Sub

    Private Sub ToolStripMenuItem7_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem7.Click
        Dim objfrm As New frmPacketReport
        objfrm.MdiParent = Me
        objfrm.Show()
    End Sub

    Private Sub PulloutToolStripMenuItem2_Click(sender As System.Object, e As System.EventArgs) Handles PulloutToolStripMenuItem2.Click
        Dim frmobj As New frmPulloutDelete
        frmobj.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem8_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem8.Click
        Dim objfrm As New frmSearchEngineReport
        objfrm.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem11_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem11.Click
        Dim objfrm As New frmScanReport
        objfrm.MdiParent = Me
        objfrm.Show()
    End Sub

    Private Sub AlmiraToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles AlmiraToolStripMenuItem1.Click
        Dim objfrm As New frmAlmiraImport
        objfrm.ShowDialog()
    End Sub

    Private Sub HistoryToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles HistoryToolStripMenuItem.Click
        Dim frmObj As New frmHistory
        frmObj.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem12_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem12.Click
        Dim objfrm As New frmHistoryReport
        objfrm.MdiParent = Me
        objfrm.Show()
    End Sub

    Private Sub ConsolidatedReportToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ConsolidatedReportToolStripMenuItem.Click
        Dim objfrm As New frmconsolidatedReport
        objfrm.MdiParent = Me
        objfrm.Show()
    End Sub

    Private Sub ToolStripMenuItem13_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem13.Click
        Dim objfrm As New frmScanImageDownloadReport
        objfrm.MdiParent = Me
        objfrm.Show()
    End Sub

    Private Sub ChequePaymodeUpdationToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ChequePaymodeUpdationToolStripMenuItem.Click
        Dim frmObj As New frmChequePaymodeUpdate
        frmObj.ShowDialog()
    End Sub

    Private Sub DummyPacketEntryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DummyPacketEntryToolStripMenuItem.Click
        Dim frmobj As New frmDummyPacketEntry
        frmobj.MdiParent = Me
        frmobj.Show()
    End Sub
End Class
