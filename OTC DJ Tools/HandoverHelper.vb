Imports System.IO
Imports System.Net
Imports System.Net.Sockets

Public Class HandoverHelper
    Dim strdata As String
    Dim ViewCount As Integer
    Dim OffAirCount As Integer = 0
    Dim OldStatus As String
    Dim failcount As Integer = 0
    Dim errorcount As Integer = 0
    '  Dim errorcount2 As Integer = 0


    Private Sub HandoverHelper_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If My.Settings.HHHeight <> "0" And My.Settings.HHWidth <> "0" And My.Settings.HHXPos <> "0" And My.Settings.HHYPos <> "0" Then
            Me.SetDesktopBounds(My.Settings.HHXPos, My.Settings.HHYPos, My.Settings.HHWidth, My.Settings.HHHeight)
        End If

        OldStatus = "Startup"
        'Timer2.Start()
        'RefreshWeb()
        Timer1.Start()
    End Sub
    Private Sub RefreshWeb()
        Timer1.Stop()
        BackgroundWorker1.RunWorkerAsync()
        Timer2.Start()
    End Sub

    Private Sub Print()
        Try
            Dim datastring As String = strdata
            If datastring = "onair" Or datastring = "offair" Then
                errorcount = 0
            End If
            If datastring = "onair" Then
                Me.Label2.Text = "Last Update: " & Now()
                If OldStatus <> "OnAir" Then
                    OffAirCount = OffAirCount + 1
                End If
                If (OldStatus <> "OnAir" And OffAirCount > 2) Or OldStatus = "OnAir" Or OldStatus = "Startup" Then
                    Label1.Text = "DJ On Air"
                    Label1.ForeColor = Color.Red
                    'Me.RichTextBox1.SelectAll()
                    'Me.RichTextBox1.SelectionAlignment = HorizontalAlignment.Center
                    'Me.RichTextBox1.DeselectAll()
                    If Minibar.Visible = True Then
                        'Minibar.RichTextBox1.Text = "DJ On Air"
                        'Minibar.RichTextBox1.ForeColor = Color.Red
                        'Minibar.RichTextBox1.SelectAll()
                        'Minibar.RichTextBox1.SelectionAlignment = HorizontalAlignment.Center
                        'Minibar.RichTextBox1.DeselectAll()
                        Minibar.Label3.Text = "DJ On Air"
                        Minibar.Label3.ForeColor = Color.Red
                    End If
                    If OldStatus <> "OnAir" Then
                        StatusChange.Label1.Text = "DJ On Air"
                        StatusChange.Label1.ForeColor = Color.Red
                        'StatusChange.RichTextBox1.SelectAll()
                        'StatusChange.RichTextBox1.SelectionAlignment = HorizontalAlignment.Center
                        'StatusChange.RichTextBox1.DeselectAll()
                        StatusChange.Show()
                    End If
                    OldStatus = "OnAir"
                    OffAirCount = 0
                End If
            ElseIf datastring = "Could not retrieve data" Then
                ' Me.Label2.Text = "Last Update: " & Now()
                OffAirCount = 0
                If (OldStatus = "Startup") Then
                    errorcount = 4

                    Me.Label2.Text = "Last Update: " & Now()
                    Label1.Text = "Error"
                    Label1.ForeColor = Color.Black
                    'Me.RichTextBox1.SelectAll()
                    'Me.RichTextBox1.SelectionAlignment = HorizontalAlignment.Center
                    'Me.RichTextBox1.DeselectAll()
                    If Minibar.Visible = True Then
                        'Minibar.RichTextBox1.Text = "Error"
                        'Minibar.RichTextBox1.ForeColor = Color.Black
                        'Minibar.RichTextBox1.SelectAll()
                        'Minibar.RichTextBox1.SelectionAlignment = HorizontalAlignment.Center
                        'Minibar.RichTextBox1.DeselectAll()
                        Minibar.Label3.Text = "Error"
                        Minibar.Label3.ForeColor = Color.Black
                    End If
                    If OldStatus <> "Unknown" Then
                        StatusChange.Label1.Text = "Error"
                        StatusChange.Label1.ForeColor = Color.Black
                        'StatusChange.RichTextBox1.SelectAll()
                        'StatusChange.RichTextBox1.SelectionAlignment = HorizontalAlignment.Center
                        'StatusChange.RichTextBox1.DeselectAll()
                        StatusChange.Show()
                    End If
                    OldStatus = "Unknown"
                    MsgBox("The handover helper is struggling to retrieve the current on air status which may indicate a server problem. It will now display an error status until it can reliably determine whether or not you are on air. Please do not attempt to reconnect unless you are sure you are off air.")
                Else
                    errorcount = errorcount + 1
                    If errorcount > 2 Then
                        If errorcount = 3 Then
                            ' errorcount2 = 0
                            MsgBox("The handover helper is struggling to retrieve the current on air status which may indicate a server problem. It will now display an error status until it can reliably determine whether or not you are on air. Please do not attempt to reconnect unless you are sure you are off air.")
                        End If
                        doerror()
                    End If
                   
                End If
                ' Do nothing
            ElseIf datastring = "offair" Then
                Me.Label2.Text = "Last Update: " & Now()
                OffAirCount = 0
                Label1.Text = "DJ Off Air"
                Label1.ForeColor = Color.Black
                'Me.RichTextBox1.SelectAll()
                'Me.RichTextBox1.SelectionAlignment = HorizontalAlignment.Center
                'Me.RichTextBox1.DeselectAll()
                If Minibar.Visible = True Then
                    'Minibar.RichTextBox1.Text = "DJ Off Air"
                    'Minibar.RichTextBox1.ForeColor = Color.Black
                    'Minibar.RichTextBox1.SelectAll()
                    'Minibar.RichTextBox1.SelectionAlignment = HorizontalAlignment.Center
                    'Minibar.RichTextBox1.DeselectAll()
                    Minibar.Label3.Text = "DJ Off Air"
                    Minibar.Label3.ForeColor = Color.Black
                End If
                If OldStatus <> "OffAir" Then
                    StatusChange.Label1.Text = "DJ Off Air"
                    StatusChange.Label1.ForeColor = Color.Black
                    'StatusChange.RichTextBox1.SelectAll()
                    'StatusChange.RichTextBox1.SelectionAlignment = HorizontalAlignment.Center
                    'StatusChange.RichTextBox1.DeselectAll()
                    StatusChange.Show()
                End If
                OldStatus = "OffAir"
            Else
                errorcount = errorcount + 1
                If errorcount > 2 Then
                    ' errorcount2 = 0

                    If errorcount = 3 Then
                        MsgBox("The handover helper is struggling to retrieve the current on air status which may indicate a server problem. It will now display an error status until it can reliably determine whether or not you are on air. Please do not attempt to reconnect unless you are sure you are off air.")
                    End If
                    doerror()
                End If

                'Else
                '    OffAirCount = 0
                '    Label1.Text = "Error"
                '    Label1.ForeColor = Color.Black
                '    'Me.RichTextBox1.SelectAll()
                '    'Me.RichTextBox1.SelectionAlignment = HorizontalAlignment.Center
                '    'Me.RichTextBox1.DeselectAll()
                '    If Minibar.Visible = True Then
                '        'Minibar.RichTextBox1.Text = "Error"
                '        'Minibar.RichTextBox1.ForeColor = Color.Black
                '        'Minibar.RichTextBox1.SelectAll()
                '        'Minibar.RichTextBox1.SelectionAlignment = HorizontalAlignment.Center
                '        'Minibar.RichTextBox1.DeselectAll()
                '        Minibar.Label3.Text = "Error"
                '        Minibar.Label3.ForeColor = Color.Black
                '    End If
                '    If OldStatus <> "Unknown" Then
                '        StatusChange.Label1.Text = "Error"
                '        StatusChange.Label1.ForeColor = Color.Black
                '        'StatusChange.RichTextBox1.SelectAll()
                '        'StatusChange.RichTextBox1.SelectionAlignment = HorizontalAlignment.Center
                '        'StatusChange.RichTextBox1.DeselectAll()
                '        StatusChange.Show()
                '    End If
                '    OldStatus = "Unknown"
            End If

        Catch
        End Try
    End Sub
    'Private Sub WaitReady()
    '    Do Until Me.WebBrowser1.ReadyState = WebBrowserReadyState.Complete
    '        Application.DoEvents()
    '    Loop
    'End Sub

    'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    'End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        RefreshWeb()

        'If (StatusChange.Visible = True) Then
        '    ViewCount = ViewCount + 1
        '    If (ViewCount > 2) Then
        '        StatusChange.Hide()
        '        ViewCount = 0
        '    End If
        'End If

    End Sub
    Private Sub HandoverHelper_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Enclosure.ToolStripButton2.Checked = False
        My.Settings.HHXPos = Me.Location.X
        My.Settings.HHYPos = Me.Location.Y
        My.Settings.HHWidth = Me.Size.Width
        My.Settings.HHHeight = Me.Size.Height
        My.Settings.Save()
        Timer1.Stop()
        Timer2.Stop()
    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim webReq As HttpWebRequest = WebRequest.Create("http://www.offthechartradio.co.uk/scripts/handoverhelper.php")
            webReq.Timeout = 10000
            Dim webResp As HttpWebResponse = webReq.GetResponse()
            Dim dataStream As Stream = webResp.GetResponseStream
            Dim streamRead As New StreamReader(dataStream)
            strdata = streamRead.ReadToEnd()
            ' errorcount = 0
        Catch
            ' MsgBox("The handover helper is struggling to retrieve the current on air status. It will continue to try, but thought it might be worth letting you know that if this message keeps coming up, what it shows is unlikely to be accurate")
            strdata = "failure"
            errorcount = errorcount + 1
            If errorcount = 3 Then
                ' errorcount = 0
                MsgBox("The handover helper is struggling to retrieve the current on air status which may indicate a server problem. It will now display an error status until it can reliably determine whether or not you are on air. Please do not attempt to reconnect unless you are sure you are off air.")
            End If
        End Try
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        If BackgroundWorker1.IsBusy Then
            failcount = failcount + 1
            If failcount > 59 Then
                'BackgroundWorker1.CancelAsync()
                'failcount = 0
                If failcount = 60 Then
                    MsgBox("The handover helper is struggling to retrieve the current on air status which may indicate a server problem. It will now display an error status until it can reliably determine whether or not you are on air. Please do not attempt to reconnect unless you are sure you are off air.")
                End If
                doerror()
                'BackgroundWorker1.RunWorkerAsync()
            End If
            
        Else
            failcount = 0
            If strdata <> "failure" Then
                Print()
                Timer2.Stop()
                Timer1.Start()
            Else
                Timer2.Stop()
                If errorcount > 2 Then
                    doerror()
                    errorcount = errorcount + 1
                End If
                Timer1.Start()
            End If
        End If
    End Sub

    Public Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If BackgroundWorker2.IsBusy Then
            MsgBox("Reconnection already in progress, please wait until it completes")
        Else
            If Label1.Text = "DJ On Air" Then
                If MsgBox("The handover helper is currently reporting that a DJ is on air. Are you sure you want to reconnect?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    reconnect()
                End If
            Else
                reconnect()
            End If
        End If
    End Sub
    Private Sub reconnect()
        If MsgBox("Before continuing, please ensure that: 1. Simplecast is running and encoding to the server, 2. You have a track playing, 3. The Simplecast level meters are registering audio. After these checks, are you ready to reconnect?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            BackgroundWorker2.RunWorkerAsync()
        End If
    End Sub

    Private Sub BackgroundWorker2_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker2.DoWork
        Try
            Dim webReq As HttpWebRequest = WebRequest.Create("http://www.offthechartradio.co.uk/scripts/djtools.php?u=" + Login.text1 + "&p=" + Login.text2 + "&o=reconnect")
            Dim webResp As HttpWebResponse = webReq.GetResponse()
            Dim dataStream As Stream = webResp.GetResponseStream
            Dim streamRead As New StreamReader(dataStream)
            Dim strdata2 As String = streamRead.ReadToEnd()

            If strdata2 = "ErrorCode1" Then
                MsgBox("Incorrect username or password, please log in again")
            ElseIf strdata2 = "ErrorCode2" Then
                MsgBox("Your account is disabled, please contact management")
            ElseIf strdata2 = "ErrorCode3" Then
                MsgBox("Error Code 3 - Please contact management quoting this number")
            ElseIf strdata2 = "ErrorCode4" Then
                MsgBox("Error Code 4 - Please contact management quoting this number")
            ElseIf strdata2 = "ErrorCode5" Then
                MsgBox("Database unavailable, reconnection failure")
            ElseIf InStr(strdata2, "Reconnection initiated") <> "0" Then
                MsgBox("Reconnection initiated, you should be back on air within seconds")
            Else
                MsgBox("Reconnection failure, please try again. If the system continually fails please contact management")
            End If

        Catch
            MsgBox("Could not connect to server, please check your connection. If this error recurs please contact management")
        End Try
    End Sub

    Private Sub HandoverHelper_ResizeEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ResizeEnd
        Dim myheight As Integer = Label1.Height
        myheight = myheight * 0.68
        If myheight > 0.1 Then
            Label1.Font = New Font("Microsoft Sans Serif", myheight, FontStyle.Bold)
        End If
    End Sub

    Private Sub HandoverHelper_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged
        If Visible = True Then
            Dim myheight As Integer = Label1.Height
            myheight = myheight * 0.68
            If myheight > 0.1 Then
                Label1.Font = New Font("Microsoft Sans Serif", myheight, FontStyle.Bold)
            End If
        End If
    End Sub
    Private Sub doerror()
        Me.Label2.Text = "Last Update: " & Now()
        Label1.Text = "Error"
        Label1.ForeColor = Color.Black
        'Me.RichTextBox1.SelectAll()
        'Me.RichTextBox1.SelectionAlignment = HorizontalAlignment.Center
        'Me.RichTextBox1.DeselectAll()
        If Minibar.Visible = True Then
            'Minibar.RichTextBox1.Text = "Error"
            'Minibar.RichTextBox1.ForeColor = Color.Black
            'Minibar.RichTextBox1.SelectAll()
            'Minibar.RichTextBox1.SelectionAlignment = HorizontalAlignment.Center
            'Minibar.RichTextBox1.DeselectAll()
            Minibar.Label3.Text = "Error"
            Minibar.Label3.ForeColor = Color.Black
        End If
        If OldStatus <> "Unknown" Then
            StatusChange.Label1.Text = "Error"
            StatusChange.Label1.ForeColor = Color.Black
            'StatusChange.RichTextBox1.SelectAll()
            'StatusChange.RichTextBox1.SelectionAlignment = HorizontalAlignment.Center
            'StatusChange.RichTextBox1.DeselectAll()
            StatusChange.Show()
        End If
        OldStatus = "Unknown"

    End Sub

  
    Private Sub HandoverHelper_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Dim myheight As Integer = Label1.Height
        myheight = myheight * 0.68
        If myheight > 0.1 Then
            Label1.Font = New Font("Microsoft Sans Serif", myheight, FontStyle.Bold)
        End If
    End Sub
End Class