Imports System.Windows.Forms
Imports System.Net
Imports System.IO

Public Class Enclosure
    Dim alert As String = ""
    Dim lastchecked As Integer
    Dim emailstrdata As String
    Dim startup As String
    Dim viewcount As Integer = 0

    Dim savedlabel1 As String
    Dim savedlabel2 As String

    Public myalert As String = "Data unavailable..."
    Public mynpdata As String = "Data unavailable..."

    Dim errorcount As Integer = 0


    Enum ABEdge
        ABE_LEFT = 0
        ABE_TOP
        ABE_RIGHT
        ABE_BOTTOM
    End Enum
    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        If About.Visible = False Then
            About.Show()
        Else
            About.Close()
        End If
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        If TOTHClock.Visible = True Then
            If TOTHClock.loadstart = "done" Then
                Me.NotifyIcon1.Visible = False
                Close()

            End If
        Else
            Me.NotifyIcon1.Visible = False
            Close()
        End If
    End Sub

    Private Sub ToolStripStatusLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ToolTip_Popup(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PopupEventArgs)

    End Sub


    Private Sub Enclosure_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        startup = "true"
        If My.Settings.EncHeight <> "0" And My.Settings.EncWidth <> "0" And My.Settings.XPos <> "0" And My.Settings.YPos <> "0" Then
            Me.SetDesktopBounds(My.Settings.XPos, My.Settings.YPos, My.Settings.EncWidth, My.Settings.EncHeight)
        End If
        'webEmailCheck.Navigate("http://www.offthechartradio.co.uk/djmail/checker.php?username=" + Login.email + "&password=" + Login.imappass)
        If My.Settings.MailCheck > 0 Then
            timerEmail.Interval = My.Settings.MailCheck * 60000
        Else
            timerEmail.Interval = 60000
        End If
        'If IsNumeric(webEmailCheck.DocumentText) = True Then
        '    lastchecked = webEmailCheck.DocumentText
        '    timerEmail.Start()
        'Else
        '    timerProblem.Start()
        'End If
        BackgroundWorker2.RunWorkerAsync()


    End Sub
    Private Sub Enclosure_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

        HandoverHelper.Close()
        PlaylistLogger.Close()
        TOTHClock.Close()
        TimeCalculator.Close()
        PreRecMon.Close()
        CompMan.Close()
        DJMail.Close()
        WebcamUploader.Close()
        StatusChange.Close()

        My.Settings.XPos = Me.Location.X
        My.Settings.YPos = Me.Location.Y
        My.Settings.EncWidth = Me.Size.Width
        My.Settings.EncHeight = Me.Size.Height
        My.Settings.Save()
        Me.NotifyIcon1.Visible = False

        'If BackgroundWorker2.IsBusy Then
        '    While BackgroundWorker2.IsBusy
        '        Application.DoEvents()
        '    End While
        'End If

        End
    End Sub

    Private Sub ToolStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        HandoverHelper.MdiParent = Me
        If HandoverHelper.Visible = False Then
            HandoverHelper.Show()
        Else
            HandoverHelper.Close()
        End If
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        TimeCalculator.MdiParent = Me
        If TimeCalculator.Visible = False Then
            TimeCalculator.Show()
        Else
            TimeCalculator.Close()
        End If
        'MsgBox("Not yet implemented")
    End Sub

    Private Sub OTCWebsiteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OTCWebsiteToolStripMenuItem.Click
        Try
            System.Diagnostics.Process.Start("http://www.offthechartradio.co.uk")
        Catch
        End Try
    End Sub

    Private Sub ScheduleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ScheduleToolStripMenuItem.Click
        Try
            System.Diagnostics.Process.Start("http://www.offthechartradio.co.uk/schedule")
        Catch
        End Try
    End Sub

    Private Sub ForumsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ForumsToolStripMenuItem.Click
        Try
            System.Diagnostics.Process.Start("http://www.offthechartradio.co.uk/forums")
        Catch
        End Try
    End Sub

    Private Sub ServerStatusToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ServerStatusToolStripMenuItem.Click
        ServerStatus.Show()
    End Sub

    Private Sub OptionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptionsToolStripMenuItem.Click
        Options.Show()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Close()
    End Sub

    Public Sub ToolStripButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton7.Click
        'Memory Problem &
        'DJMail.MdiParent = Me
        DJMail.ControlBox = False
        DJMail.MdiParent = Me
        If DJMail.Visible = False Then
            If Login.email = "none" Or Login.imappass = "none" Then
                MsgBox("Your account details are unavailable, please contact management")
            Else
                DJMail.Show()
                If My.Settings.MailHeight <> "0" And My.Settings.MailWidth <> "0" And My.Settings.MailXPos <> "0" And My.Settings.MailYPos <> "0" Then
                    DJMail.SetDesktopBounds(My.Settings.MailXPos, My.Settings.MailYPos, My.Settings.MailWidth, My.Settings.MailHeight)
                End If
            End If
        Else
            My.Settings.MailXPos = DJMail.Location.X
            My.Settings.MailYPos = DJMail.Location.Y
            My.Settings.MailWidth = DJMail.Size.Width
            My.Settings.MailHeight = DJMail.Size.Height
            My.Settings.Save()
            DJMail.Hide()
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        PreRecMon.MdiParent = Me
        If PreRecMon.Visible = False Then
            PreRecMon.Show()
        Else
            PreRecMon.Close()
        End If
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        CompMan.MdiParent = Me
        If CompMan.Visible = False Then
            CompMan.Show()
        Else
            CompMan.Close()
        End If
    End Sub


    Private Sub MinibarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MinibarToolStripMenuItem.Click
        Minibar.minibarpos = ABEdge.ABE_BOTTOM
        Minibar.Show()
        'webEmailCheck.Refresh()
        'Debug.Print(webEmailCheck.DocumentText + " new messages")
    End Sub

    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        TOTHClock.MdiParent = Me
        If TOTHClock.Visible = False Then
            If My.Settings.TCHeight <> "0" And My.Settings.TCWidth <> "0" And My.Settings.TCXPos <> "0" And My.Settings.TCYPos <> "0" Then
                TOTHClock.Show()
                TOTHClock.SetDesktopBounds(My.Settings.TCXPos, My.Settings.TCYPos, My.Settings.TCWidth, My.Settings.TCHeight)
            Else
                TOTHClock.Show()
            End If
        Else
            If TOTHClock.loadstart = "done" Then
                My.Settings.TCXPos = TOTHClock.Location.X
                My.Settings.TCYPos = TOTHClock.Location.Y
                My.Settings.TCWidth = TOTHClock.Size.Width
                My.Settings.TCHeight = TOTHClock.Size.Height
                My.Settings.Save()
                TOTHClock.Hide()
            End If
        End If
    End Sub

    Private Sub ToolStripButton8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton8.Click
        WebcamUploader.MdiParent = Me
        If WebcamUploader.Visible = False Then
            WebcamUploader.Show()
        Else
            WebcamUploader.Close()
        End If
    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        ToolStripMenuItem1_Click(sender, e)
    End Sub

    Private Sub OTCWebsiteToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OTCWebsiteToolStripMenuItem1.Click
        OTCWebsiteToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub ScheduleToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ScheduleToolStripMenuItem1.Click
        ForumsToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub ForumsToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ForumsToolStripMenuItem1.Click
        ScheduleToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub ServerStatusToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ServerStatusToolStripMenuItem1.Click
        ServerStatusToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub ToolStripButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton6.Click

        PlaylistLogger.MdiParent = Me
        If PlaylistLogger.Visible = False Then
            If My.Settings.PlayLogHeight <> "0" And My.Settings.PlayLogWidth <> "0" And My.Settings.PlayLogXPos <> "0" And My.Settings.PlayLogYPos <> "0" Then
                PlaylistLogger.Show()
                PlaylistLogger.SetDesktopBounds(My.Settings.PlayLogXPos, My.Settings.PlayLogYPos, My.Settings.PlayLogWidth, My.Settings.PlayLogHeight)
            Else
                PlaylistLogger.Show()
            End If
        Else
            My.Settings.PlayLogXPos = PlaylistLogger.Location.X
            My.Settings.PlayLogYPos = PlaylistLogger.Location.Y
            My.Settings.PlayLogWidth = PlaylistLogger.Size.Width
            My.Settings.PlayLogHeight = PlaylistLogger.Size.Height
            My.Settings.Save()
            PlaylistLogger.Hide()
        End If
       
    End Sub

    Private Sub LinksToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinksToolStripMenuItem.Click

    End Sub

    Private Sub PostAlertToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PostAlertToolStripMenuItem.Click
        If BackgroundWorker1.IsBusy Then
            MsgBox("An alert is currently being processed, please wait for it to complete")
        Else
            alert = InputBox("Please enter your alert below (max 100 chars)")
            While alert.Length > 101
                MsgBox("Your alert is too long, please rephrase it")
                alert = InputBox("Please enter your alert below (max 100 chars)", , alert)
            End While
            If alert <> "" Then
                BackgroundWorker1.RunWorkerAsync()
            End If
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        alert = alert.Replace("&", "^")
        alert = alert.Replace("#", "`")
        Dim webReq As HttpWebRequest = WebRequest.Create("http://www.offthechartradio.co.uk/scripts/djtools.php?u=" + Login.text1 + "&p=" + Login.text2 + "&o=alert&a=" + alert)
        Dim webResp As HttpWebResponse = webReq.GetResponse()
        Dim dataStream As Stream = webResp.GetResponseStream
        Dim streamRead As New StreamReader(dataStream)
        Dim strdata As String = streamRead.ReadToEnd()
        If strdata = "ErrorCode1" Then
            MsgBox("Incorrect username or password, please log in again")
        ElseIf strdata = "ErrorCode2" Then
            MsgBox("Your account is disabled, please contact management")
        ElseIf strdata = "ErrorCode3" Then
            MsgBox("Error Code 3 - Please contact management quoting this number")
        ElseIf strdata = "ErrorCode4" Then
            MsgBox("Error Code 4 - Please contact management quoting this number")
        ElseIf strdata = "ErrorCode5" Then
            MsgBox("Database unavailable, update failure")
        ElseIf InStr(strdata, "success") <> "0" Then
            MsgBox("Alert updated successfully")
        Else
            MsgBox("Update failed, please try again. If the system continually fails please contact management")
        End If
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        If Minibar.Visible = True Then
            Minibar.Button2_Click(sender, e)
        Else
            Me.WindowState = FormWindowState.Maximized
            Me.TopMost = True
            Me.TopMost = False
        End If
    End Sub

    Private Sub Enclosure_LocationChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LocationChanged

    End Sub
    Private Sub timerEmail_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timerEmail.Tick
        'If IsNumeric(webEmailCheck.DocumentText) = True Then
        '    lastchecked = webEmailCheck.DocumentText
        '    webEmailCheck.Refresh()
        'Else
        '    timerProblem.Start()
        'End If
        If BackgroundWorker2.IsBusy Then
            If Login.email <> "none" And Login.imappass <> "none" Then
                errorcount = errorcount + 1
                If errorcount = 2 Then
                    'errorcount = 0
                    MsgBox("The mail checker failed to determine if you have any new messages and will check again shortly. This may indicate a temporary server issue. You will only be notified of this particular problem once.")
                End If
            End If
            BackgroundWorker2.CancelAsync()
        Else
            ' errorcount = 0
            BackgroundWorker2.RunWorkerAsync()
        End If
    End Sub

    Private Sub timerProblem_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'timerProblem.Stop()
        'If IsNumeric(webEmailCheck.DocumentText) = True Then
        '    lastchecked = webEmailCheck.DocumentText
        '    timerEmail.Start()
        'Else
        '    timerProblem.Start()
        'End If
    End Sub

    Private Sub webEmailCheck_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs)
        'If IsNumeric(webEmailCheck.DocumentText) = True Then
        '    If webEmailCheck.DocumentText > 1 Then
        '        Minibar.lblEmailCheck.Text = webEmailCheck.DocumentText + " new messages"
        '    Else
        '        If webEmailCheck.DocumentText = 0 Then
        '            Minibar.lblEmailCheck.Text = "No new messages"
        '        Else
        '            Minibar.lblEmailCheck.Text = webEmailCheck.DocumentText + " new message"
        '        End If

        '    End If
        '    If webEmailCheck.DocumentText <> 0 Then
        '        Minibar.lblEmailCheck.ForeColor = Color.Red
        '        Minibar.lblEmailCheck.Font = New Font(Minibar.lblEmailCheck.Font, FontStyle.Bold)
        '    Else
        '        Minibar.lblEmailCheck.ForeColor = Color.Black
        '        Minibar.lblEmailCheck.Font = New Font(Minibar.lblEmailCheck.Font, FontStyle.Regular)
        '    End If

        '    If lastchecked < webEmailCheck.DocumentText Then
        '        NumEmails = webEmailCheck.DocumentText - lastchecked
        '        lastchecked = webEmailCheck.DocumentText
        '        StatusChange.lblEmailNotifier.Text = "New Message Received"
        '        StatusChange.Show()
        '        HandoverHelper.Timer1.Start()
        '    Else
        '        timerProblem.Start()
        '    End If

        'Else
        'timerProblem.Start()
        'End If
    End Sub

    Private Sub BackgroundWorker2_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker2.DoWork
        ' MsgBox("Checking...")
        If Login.email <> "none" And Login.imappass <> "none" Then
            Try
                Dim webReq As HttpWebRequest = WebRequest.Create("http://www.offthechartradio.co.uk/djmail/checker.php?username=" + Login.email + "&password=" + Login.imappass)
                webReq.Timeout = 20000
                Dim webResp As HttpWebResponse = webReq.GetResponse()
                Dim dataStream As Stream = webResp.GetResponseStream
                Dim streamRead As New StreamReader(dataStream)
                emailstrdata = streamRead.ReadToEnd()
                If startup = "true" Then
                    lastchecked = emailstrdata
                    startup = "false"
                End If
                errorcount = 0
            Catch
                errorcount = errorcount + 1
                If errorcount = 2 Then
                    'errorcount = 0
                    MsgBox("The mail checker failed to determine if you have any new messages and will check again shortly. This may indicate a temporary server issue. You will only be notified of this particular problem once.")
                End If
            End Try
        End If
    End Sub

    Private Sub timerEmail2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timerEmail2.Tick
        timerEmail2.Stop()


        If (StatusChange.Visible = True) Then
            viewcount = viewcount + 1
            If savedlabel1 <> StatusChange.Label1.Text Then
                savedlabel1 = StatusChange.Label1.Text
                viewcount = 1
            End If
            If savedlabel2 <> StatusChange.lblEmailNotifier.Text Then
                savedlabel2 = StatusChange.lblEmailNotifier.Text
                viewcount = 1
            End If
            If (viewcount > 2) Then
                StatusChange.Hide()
                StatusChange.lblEmailNotifier.Text = ""
                viewcount = 0
            End If
        End If
        If errorcount > 1 Then
            Minibar.lblEmailCheck.Text = "Mail Inaccessible"
            Minibar.lblEmailCheck.ForeColor = Color.Black
            Minibar.lblEmailCheck.Font = New Font(Minibar.lblEmailCheck.Font, FontStyle.Regular)
        Else


            'Dim numemails As Integer = 0

            'If startup = "false" And IsNumeric(emailstrdata) = True Then
            '    numemails = Integer.Parse(emailstrdata)
            '    If lastchecked < numemails Then
            '        lastchecked = numemails
            '        StatusChange.lblEmailNotifier.Text = "New Message Received"
            '        If HandoverHelper.Visible = True Then
            '            StatusChange.Label1.Text = HandoverHelper.Label1.Text
            '        ElseIf Minibar.Visible = True Then
            '            StatusChange.Label1.Text = Minibar.Label3.Text
            '        End If
            '        If StatusChange.Label1.Text = "DJ On Air" Then
            '            StatusChange.Label1.ForeColor = Color.Red
            '        Else
            '            StatusChange.Label1.ForeColor = Color.Black
            '        End If
            '        StatusChange.Show()
            '    End If
            'End If
            If IsNumeric(emailstrdata) = True Then
                ' numemails = Integer.Parse(emailstrdata)

                'MsgBox(lastchecked.ToString)
                'MsgBox(emailstrdata)
                If (startup = "false") And (emailstrdata > lastchecked) Then
                    'MsgBox("showing message - oldmsg: " + lastchecked.ToString + " - newmsg: " + emailstrdata)
                    lastchecked = emailstrdata
                    StatusChange.lblEmailNotifier.Text = "New Message Received"
                    If HandoverHelper.Visible = True Then
                        StatusChange.Label1.Text = HandoverHelper.Label1.Text
                    ElseIf Minibar.Visible = True Then
                        StatusChange.Label1.Text = Minibar.Label3.Text
                    Else
                        StatusChange.Label1.Text = "HH Off"
                    End If
                    If StatusChange.Label1.Text = "DJ On Air" Then
                        StatusChange.Label1.ForeColor = Color.Red
                    Else
                        StatusChange.Label1.ForeColor = Color.Black
                    End If
                    StatusChange.Show()
                ElseIf (emailstrdata < lastchecked) Then
                    lastchecked = emailstrdata
                End If


                If emailstrdata > 1 Then
                    Minibar.lblEmailCheck.Text = emailstrdata + " new messages"
                Else
                    If emailstrdata = 0 Then
                        Minibar.lblEmailCheck.Text = "No new messages"
                    Else
                        Minibar.lblEmailCheck.Text = emailstrdata + " new message"
                    End If

                End If
                If emailstrdata <> 0 Then
                    Minibar.lblEmailCheck.ForeColor = Color.Red
                    Minibar.lblEmailCheck.Font = New Font(Minibar.lblEmailCheck.Font, FontStyle.Bold)
                Else
                    Minibar.lblEmailCheck.ForeColor = Color.Black
                    Minibar.lblEmailCheck.Font = New Font(Minibar.lblEmailCheck.Font, FontStyle.Regular)
                End If

            End If

        End If
        timerEmail2.Start()
    End Sub

    

    
    Private Sub timerError_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timerError.Tick
        If errorcount = 2 Then

            errorcount = errorcount + 1
        End If
    End Sub

 

    Private Sub ExtraInfoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExtraInfoToolStripMenuItem.Click
        ExtraInfo.Show()
    End Sub

    Private Sub ExtraInfoToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExtraInfoToolStripMenuItem1.Click
        ExtraInfo.Show()
    End Sub

    Private Sub UploadedPlaylistsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UploadedPlaylistsToolStripMenuItem.Click
        Try
            System.Diagnostics.Process.Start("http://www.offthechartradio.co.uk/scripts/viewlogs.php?show=" + StrConv(My.Settings.Username, VbStrConv.ProperCase))
        Catch
        End Try
    End Sub
End Class
