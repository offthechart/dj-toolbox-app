Imports System.Net
Imports System.IO
Imports System.Environment

Public Class Options

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Browse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Browse.Click
        FolderBrowserDialog1.ShowDialog()
        If FolderBrowserDialog1.SelectedPath <> "" Then
            TextBox1.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub FolderBrowserDialog1_HelpRequest(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FolderBrowserDialog1.HelpRequest

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        My.Settings.ImagingLoc = TextBox1.Text
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            My.Settings.ImagingArchive = "true"
        Else
            My.Settings.ImagingArchive = "false"
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        My.Settings.Reload()
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        My.Settings.Save()
        If CheckBox3.Checked = True Then
            Login.webcam = "1"
        ElseIf CheckBox3.Checked = False Then
            Login.webcam = "0"
        End If
        If CheckBox2.Checked = True Then
            Login.npdata = "man"
        ElseIf CheckBox2.Checked = False Then
            Login.npdata = "none"
        End If
        Button1.Text = "Please Wait"
        Button1.Enabled = False
        Button2.Enabled = False
        ProgressBar1.Visible = True
        If My.Settings.MailCheck > 0 Then
            Enclosure.timerEmail.Interval = My.Settings.MailCheck * 60000
        Else
            Enclosure.timerEmail.Interval = 60000
        End If
        BackgroundWorker1.RunWorkerAsync()
        Timer1.Enabled = True
        Timer1.Start()
    End Sub

    Private Sub Options_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Text = My.Settings.ImagingLoc
        If My.Settings.ImagingArchive = "true" Then
            CheckBox1.Checked = True
        ElseIf My.Settings.ImagingArchive = "false" Then
            CheckBox1.Checked = False
        End If
        If My.Settings.DockMinibar = "true" Then
            CheckBox4.Checked = True
        Else
            CheckBox4.Checked = False
        End If
        ComboBox1.SelectedIndex = My.Settings.MailCheck - 1
        If Login.webcam = "1" Then
            CheckBox3.Checked = True
        Else
            CheckBox3.Checked = False
        End If
        If Login.npdata = "man" Then
            CheckBox2.Checked = True
        ElseIf Login.npdata = "none" Then
            CheckBox2.Checked = False
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Select Case ComboBox1.SelectedIndex
            Case 0
                My.Settings.MailCheck = 1
            Case 1
                My.Settings.MailCheck = 2
            Case 2
                My.Settings.MailCheck = 3
            Case 3
                My.Settings.MailCheck = 4
            Case 4
                My.Settings.MailCheck = 5
        End Select

    End Sub

    Private Sub CheckBox3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox3.CheckedChanged

    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim webReq As HttpWebRequest = WebRequest.Create("http://www.offthechartradio.co.uk/scripts/djtools.php?u=" + Login.text1 + "&p=" + Login.text2 + "&o=write&d=" + Login.webcam + ";" + Login.npdata)
        Dim webResp As HttpWebResponse = webReq.GetResponse()
        Dim dataStream As Stream = webResp.GetResponseStream
        Dim streamRead As New StreamReader(dataStream)
        Dim strdata As String = streamRead.ReadToEnd()
        If strdata = "success" Then
            MsgBox("Settings updated successfully")
        Else
            MsgBox("Some settings could not be saved")
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If BackgroundWorker1.IsBusy Then
        Else
            Me.Close()
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If MsgBox("Warning: This option should be used with caution. Ensure you understand EXACTLY what it does before continuing. If you are at all unsure please contact management. Do you wish to continue?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Try
                Dim savestring As String
                savestring = Environment.GetFolderPath(SpecialFolder.ApplicationData)
                savestring = savestring + "\Off_The_Chart_Radio\imaging"
                Dim dir As System.IO.DirectoryInfo
                dir = New System.IO.DirectoryInfo(savestring)
                If (Not dir.Exists) Then
                    dir.Create()
                End If
                savestring = savestring + "\info.txt"
                If File.Exists(savestring) Then
                    File.Delete(savestring)
                End If
                MsgBox("Your imaging history has been cleared. Please ensure the storage location is correct and restart the program to download up to date imaging")
            Catch
                MsgBox("An error occurred during the procedure, please try again or contact management for assistance")
            End Try
        End If
    End Sub

    Private Sub CheckBox4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox4.CheckedChanged
        If CheckBox4.Checked = True Then
            My.Settings.DockMinibar = "true"
        Else
            My.Settings.DockMinibar = "false"
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        My.Settings.MinibarWidth = 0
        My.Settings.MinibarYPos = 0
        My.Settings.MinibarXPos = 0
        MsgBox("Minibar settings will be cleared once options are applied")
    End Sub
End Class