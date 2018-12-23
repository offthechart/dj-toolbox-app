
Imports System.Net
Imports System.IO
Imports System.Environment

Public Class Login
    Public Shared text1 As String
    Public Shared text2 As String

    Public Shared webcam As String
    Public Shared npdata As String
    Public Shared email As String
    Public Shared imappass As String
    Public Shared manualnp As String

    Dim strdata As String

    Dim sentrequest As Boolean
    Dim backgroundaction As String


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If My.Settings.firstrun = "true" Then
            My.Settings.Upgrade()
            My.Settings.firstrun = "false"
            My.Settings.Save()
        End If
        Me.TextBox1.Text = My.Settings.Username
        Me.TextBox2.Text = My.Settings.Password
        Un4seen.Bass.BassNet.Registration("username", "password")
    End Sub

    Private Sub DoLogin()
        'Dim loggedin = False
        If (Me.TextBox1.Text = "") Then
            MsgBox("You have not entered a username")
        ElseIf (Me.TextBox2.Text = "") Then
            MsgBox("You have not entered a password")
        Else
            ShowStatusBar()
            ' Attempt login
            text1 = Me.TextBox1.Text
            text2 = Me.TextBox2.Text
            'Me.WebBrowser1.Url = (New Uri("http://www.offthechartradio.co.uk/scripts/djtools.php?u=" + text1 + "&p=" + text2 + "&o=read"))
            backgroundaction = "authenticate"
            BackgroundWorker1.RunWorkerAsync()
            Timer1.Enabled = True
            Timer1.Start()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        DoLogin()
    End Sub
    Private Sub Login_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyValue = Keys.Enter Then
            DoLogin()
        End If
    End Sub


    Private Sub complete()
        Dim datastring = strdata
        If datastring = "ErrorCode1" Then
            MsgBox("Incorrect username or password")
            HideStatusBar()
        ElseIf datastring = "ErrorCode2" Then
            MsgBox("Your account is disabled, please contact management")
            HideStatusBar()
        ElseIf datastring = "ErrorCode3" Then
            MsgBox("Error Code 3 - Please contact management quoting this number")
            HideStatusBar()
        ElseIf datastring = "ErrorCode4" Then
            MsgBox("Error Code 4 - Please contact management quoting this number")
            HideStatusBar()
        ElseIf datastring = "ErrorCode5" Then
            MsgBox("Database unavailable, toolbox cannot load")
            HideStatusBar()
        ElseIf InStr(datastring, ",") <> "0" Then
            ' If login successful {
            My.Settings.Username = text1
            My.Settings.Password = text2
            My.Settings.Save()
            'Me.ProgressBar1.Step = 10
            ' Update progress bar / label
            ' Download settings
            'Me.ProgressBar1.PerformStep()
            Dim resultArray As String() = datastring.Split(",")
            email = resultArray(0)
            imappass = resultArray(1)
            webcam = resultArray(2)
            npdata = resultArray(3)
            manualnp = resultArray(4)
            'Me.ProgressBar1.PerformStep()
            Me.Label4.Text = "Checking for imaging updates"
            backgroundaction = "imagingcheck"
            BackgroundWorker1.RunWorkerAsync()
            Timer1.Enabled = True
            Timer1.Start()

            '   If MsgBox("New imaging is available, do you want to download?", vbYesNo) = MsgBoxResult.Yes Then
            ' Do download
            ' Go through folders
            'Me.ProgressBar1.Step = 50  ' 50 / number of folders
            ' Dim foldername = "promos"
            '  Me.Label4.Text = "Downloading from " + foldername
            '   Me.ProgressBar1.PerformStep()
            'Else
            'Me.ProgressBar1.Step = 80
            'Me.ProgressBar1.PerformStep()
            'End If
            ' Update progress bar / label

            ' Launch Enclosure / close login
            ' }
        Else

            MsgBox("Unknown error, toolbox cannot load")
            HideStatusBar()

        End If
    End Sub
    Private Sub ShowStatusBar()
        Me.TextBox1.Enabled = False
        Me.TextBox2.Enabled = False
        Me.Button1.Hide()
        Me.Label1.Hide()
        Me.Label2.Hide()
        Me.Label3.Hide()
        Me.TextBox1.Hide()
        Me.TextBox2.Hide()
        Me.ProgressBar1.Show()
        Me.Label4.Show()
        Dim nowplus As Date = Now.AddSeconds(1)
        While Now < nowplus
            Application.DoEvents()
        End While
    End Sub
    Private Sub HideStatusBar()
        Me.TextBox1.Enabled = True
        Me.TextBox2.Enabled = True
        Me.Button1.Show()
        Me.Label1.Show()
        Me.Label2.Show()
        Me.Label3.Show()
        Me.TextBox1.Show()
        Me.TextBox2.Show()
        Me.ProgressBar1.Hide()
        Me.Label4.Hide()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        End
    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        If backgroundaction = "authenticate" Then
            Try
                Dim webReq As HttpWebRequest = WebRequest.Create("http://www.offthechartradio.co.uk/scripts/djtools.php?u=" + text1 + "&p=" + text2 + "&o=read")
                Dim webResp As HttpWebResponse = webReq.GetResponse()
                Dim dataStream As Stream = webResp.GetResponseStream
                Dim streamRead As New StreamReader(dataStream)
                strdata = streamRead.ReadToEnd()
            Catch
                MsgBox("Could not connect to server, please check your internet connection")
                strdata = "failure"
            End Try
        ElseIf backgroundaction = "imagingcheck" Then
            Try
                Dim webReq As HttpWebRequest = WebRequest.Create("http://www.offthechartradio.co.uk/scripts/toolboxaudio.php")
                Dim webResp As HttpWebResponse = webReq.GetResponse()
                Dim dataStream As Stream = webResp.GetResponseStream
                Dim streamRead As New StreamReader(dataStream)
                strdata = streamRead.ReadToEnd()
            Catch
                strdata = "failure"
            End Try
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If backgroundaction = "authenticate" Then

            If BackgroundWorker1.IsBusy Then

            Else
                Timer1.Stop()
                Timer1.Enabled = False
                If strdata = "failure" Then
                    HideStatusBar()
                Else
                    complete()
                End If
            End If

        ElseIf backgroundaction = "imagingcheck" Then
            If BackgroundWorker1.IsBusy Then

            Else
                Timer1.Stop()
                Timer1.Enabled = False
                If strdata = "failure" Then
                    MsgBox("Imaging update failed, please try again later")
                Else
                    imagingdownload()
                End If
            End If
        End If



    End Sub
    Private Sub imagingdownload()
        Dim statusstring As String = "success"
        Dim savestring As String
        savestring = Environment.GetFolderPath(SpecialFolder.ApplicationData)
        savestring = savestring + "\Off_The_Chart_Radio\imaging"
        Dim dir As System.IO.DirectoryInfo
        dir = New System.IO.DirectoryInfo(savestring)
        If (Not dir.Exists) Then
            dir.Create()
        End If
        savestring = savestring + "\info.txt"
        If (Not File.Exists(savestring)) Then
            Dim sw As StreamWriter = File.CreateText(savestring)
            sw.Close()
        End If
        Dim oldstrdata As String = File.ReadAllText(savestring)

        If strdata <> oldstrdata Then

            If MsgBox("Your imaging directory is out of date, would you like to fix this now?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                Dim localsaveloc As String = My.Settings.ImagingLoc
                If (localsaveloc <> "") And (Not localsaveloc Is Nothing) Then
                    Dim localsavedir As System.IO.DirectoryInfo
                    localsavedir = New System.IO.DirectoryInfo(localsaveloc)
                    If Not localsavedir.Exists Then
                        localsaveloc = ""
                    End If
                End If
                While (localsaveloc = "") Or (localsaveloc Is Nothing)
                    Me.Label4.Text = "Waiting for user input"
                    FolderBrowserDialog1.ShowDialog()
                    localsaveloc = FolderBrowserDialog1.SelectedPath
                    Try
                        Dim sw As StreamWriter = File.CreateText(localsaveloc & "\toolboxtest45633.txt")
                        sw.Close()
                        File.Delete(localsaveloc & "\toolboxtest45633.txt")
                    Catch
                        MsgBox("This path is not writeable, please try another")
                        localsaveloc = ""
                    End Try
                End While
                My.Settings.ImagingLoc = localsaveloc
                If (My.Settings.ImagingArchive <> "false" And My.Settings.ImagingArchive <> "true") Or (My.Settings.ImagingArchive Is Nothing) Then
                    If MsgBox("Would you like to keep an archive of all deleted imaging?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        My.Settings.ImagingArchive = "true"
                    Else
                        My.Settings.ImagingArchive = "false"
                    End If
                End If
                My.Settings.Save()
                Me.Label4.Text = "Downloading latest imaging"
                Dim files As String() = strdata.Split("^")
                Dim currentfileint As Integer = 0
                While currentfileint < files.Length - 1 And statusstring = "success"
                    Dim currentfilestring As String = files(currentfileint)

                    Dim currentfilearr As String() = currentfilestring.Split(",")
                    Dim currentfile As String = currentfilearr(0)
                    Dim currentmodified As String = currentfilearr(1)
                    If ((oldstrdata.Contains(currentfile)) And (oldstrdata.Contains(currentmodified))) Then
                        ' File is already in the library
                        'MsgBox("ignore " & currentfile & " " & currentmodified)
                    Else
                        ' Download currentfile
                        'MsgBox("download " & currentfile)
                        Dim partloc As String = currentfile.Replace("http://www.offthechartradio.co.uk/files/djs/audio", "")
                        partloc = partloc.Replace("/", "\")
                        Try
                            If (File.Exists(localsaveloc & partloc) And My.Settings.ImagingArchive = "true") Then
                                Dim archivedir As System.IO.DirectoryInfo
                                archivedir = New System.IO.DirectoryInfo(localsaveloc & "\archive")
                                If Not archivedir.Exists Then
                                    archivedir.Create()
                                End If
                                Dim myint As Integer = 1
                                Dim temploc As String = partloc
                                While File.Exists(localsaveloc & "\archive" & temploc)
                                    temploc = partloc.Replace(".mp3", " (" & myint & ").mp3")
                                    myint = myint + 1
                                End While
                                Dim mydir As System.IO.DirectoryInfo
                                Dim mypart As String() = temploc.Split("\")
                                mydir = New System.IO.DirectoryInfo(localsaveloc & "\archive\" & mypart(1))
                                If Not mydir.Exists Then
                                    mydir.Create()
                                End If
                                File.Copy(localsaveloc & partloc, localsaveloc & "\archive" & temploc, True)
                            End If

                            'Me.Label4.Text = "Downloading " & partloc
                            'Application.DoEvents()
                            My.Computer.Network.DownloadFile(currentfile, localsaveloc & partloc, "", "", True, 10000, True, FileIO.UICancelOption.ThrowException)

                        Catch ex As Exception
                            statusstring = "failure"
                            MsgBox("Imaging update failed or cancelled, please try again later")
                            'MsgBox(ex.ToString)
                        End Try
                    End If

                    currentfileint = currentfileint + 1
                End While
                Me.Label4.Text = "Clearing out old imaging"
                files = oldstrdata.Split("^")
                currentfileint = 0
                While currentfileint < files.Length - 1 And statusstring = "success"
                    Dim currentfilestring As String = files(currentfileint)
                    Dim currentfilearr As String() = currentfilestring.Split(",")
                    Dim currentfile As String = currentfilearr(0)
                    If strdata.Contains(currentfile) Then
                        ' File ok, ignore
                    Else
                        Dim partloc As String = currentfile.Replace("http://www.offthechartradio.co.uk/files/djs/audio", "")
                        partloc = partloc.Replace("/", "\")
                        Try
                            If (File.Exists(localsaveloc & partloc) And My.Settings.ImagingArchive = "true") Then
                                Dim archivedir As System.IO.DirectoryInfo
                                archivedir = New System.IO.DirectoryInfo(localsaveloc & "\archive")
                                If Not archivedir.Exists Then
                                    archivedir.Create()
                                End If
                                Dim myint As Integer = 1
                                Dim temploc As String = partloc
                                While File.Exists(localsaveloc & "\archive" & temploc)
                                    temploc = partloc.Replace(".mp3", " (" & myint & ").mp3")
                                    myint = myint + 1
                                End While
                                Dim mydir As System.IO.DirectoryInfo
                                Dim mypart As String() = temploc.Split("\")
                                mydir = New System.IO.DirectoryInfo(localsaveloc & "\archive\" & mypart(1))
                                If Not mydir.Exists Then
                                    mydir.Create()
                                End If
                                File.Copy(localsaveloc & partloc, localsaveloc & "\archive" & temploc, True)
                                File.Delete(localsaveloc & partloc)
                            ElseIf File.Exists(localsaveloc & partloc) Then
                                File.Delete(localsaveloc & partloc)
                            End If
                        Catch ex As Exception
                            statusstring = "failure"
                            MsgBox("Local file error, please check your imaging directory exists and is writeable")
                        End Try
                        ' File to be archived
                    End If
                    currentfileint = currentfileint + 1
                End While
                Me.Label4.Text = "Loading user interface"
                If statusstring = "success" Then
                    File.WriteAllText(savestring, strdata)
                    MsgBox("Imaging updated successfully")
                End If
                Enclosure.Show()
                Me.Close()
            End If

        End If
        Me.Label4.Text = "Loading user interface"
        Enclosure.Show()
        Me.Close()
    End Sub
End Class
