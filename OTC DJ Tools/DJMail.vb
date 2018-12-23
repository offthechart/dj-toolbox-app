Public Class DJMail
    Private Sub DJMail_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Enclosure.ToolStripButton7.Checked = False
        My.Settings.MailXPos = Me.Location.X
        My.Settings.MailYPos = Me.Location.Y
        My.Settings.MailWidth = Me.Size.Width
        My.Settings.MailHeight = Me.Size.Height
        My.Settings.Save()
    End Sub

    Private Sub DJMail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If My.Settings.MailHeight <> "0" And My.Settings.MailWidth <> "0" And My.Settings.MailXPos <> "0" And My.Settings.MailYPos <> "0" Then
            Me.SetDesktopBounds(My.Settings.MailXPos, My.Settings.MailYPos, My.Settings.MailWidth, My.Settings.MailHeight)
        End If
        webEmailMain.Navigate("http://www.offthechartradio.co.uk/djmail/htdocs/login.php?username=" + Login.email + "&password=" + Login.imappass)
        'webEmailMain.Navigate("http://www.offthechartradio.co.uk")
    End Sub

    Private Sub DJMail_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged
        If Me.Visible = True Then
            webEmailMain.Refresh()
            If My.Settings.MailHeight <> "0" And My.Settings.MailWidth <> "0" And My.Settings.MailXPos <> "0" And My.Settings.MailYPos <> "0" Then
                Me.SetDesktopBounds(My.Settings.MailXPos, My.Settings.MailYPos, My.Settings.MailWidth, My.Settings.MailHeight)
            End If
        End If
    End Sub
End Class