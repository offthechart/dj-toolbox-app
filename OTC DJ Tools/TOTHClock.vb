
Imports System.Math
Imports System.Drawing.Drawing2D
Imports System
Imports System.Diagnostics
Imports System.Threading
Imports System.Text
Imports System.IO
Imports System.Net
Imports System.Net.Sockets

Public Class TOTHClock

    Private m_Face As Bitmap
    Dim Now As DateTime
    Public nowlocal As DateTime
    Dim TimeServers(14) As String
    Dim TimeIdx As Integer
    Dim webarray() As String
    Dim webarray2() As String
    Dim webtext As String
    Dim clockwidth As Integer = 150
    Dim clockheight As Integer = 150
    Dim stagedone As String
    Public stopWatch As New Stopwatch()
    Public loadstart As String = "waiting"
    Dim strdata As String
    Dim ex As New Exception
    Dim strdatacheckcount As Integer = 0
    Dim standardex As String = ex.ToString
    Dim american As Boolean = False


    Public Function getMonth(ByVal int As Integer)
        Select Case int
            Case 1
                Return "Jan"
            Case 2
                Return "Feb"
            Case 3
                Return "Mar"
            Case 4
                Return "Apr"
            Case 5
                Return "May"
            Case 6
                Return "Jun"
            Case 7
                Return "Jul"
            Case 8
                Return "Aug"
            Case 9
                Return "Sep"
            Case 10
                Return "Oct"
            Case 11
                Return "Nov"
            Case 12
                Return "Dec"
            Case Else
                Return "Error"
        End Select
    End Function

    Private Sub TOTHClock_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If My.Settings.TCHeight <> "0" And My.Settings.TCWidth <> "0" And My.Settings.TCXPos <> "0" And My.Settings.TCYPos <> "0" Then
            Me.SetDesktopBounds(My.Settings.TCXPos, My.Settings.TCYPos, My.Settings.TCWidth, My.Settings.TCHeight)
        End If
        'TimeServers(0) = "europe.pool.ntp.org"
        
        TimeServers(0) = "132.163.4.101"
        'TimeServers(0) = "131.107.1.10"
        TimeServers(1) = "132.163.4.103"
        TimeServers(2) = "132.163.4.102"
        TimeServers(3) = "128.138.140.44"
        TimeServers(4) = "192.43.244.18"
        ' TimeServers(5) = "131.107.1.10"
        TimeServers(5) = "69.25.96.13"
        'TimeServers(7) = "216.200.93.8"
        'TimeServers(8) = "216.200.93.9"
        'TimeServers(9) = "207.126.98.204"
        TimeServers(6) = "207.200.81.113"
        TimeServers(7) = "64.236.96.53"
        TimeServers(8) = "68.216.79.113"
        TimeServers(9) = "129.6.15.28"
        TimeServers(10) = "129.6.15.29"

        ' Sync(0)

        ' Draw the face without the hands.
        DrawFace()
        'loadstart = "done"
    End Sub

    Private Sub tothclock_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

        Enclosure.ToolStripButton5.Checked = False
        My.Settings.TCXPos = Me.Location.X
        My.Settings.TCYPos = Me.Location.Y
        My.Settings.TCWidth = Me.Size.Width
        My.Settings.TCHeight = Me.Size.Height
        My.Settings.Save()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Button1.Text = "Please Wait..."
        Button1.Enabled = False
        Dim RandomClass As New Random()
        Dim RandomNumber As Integer
        RandomNumber = RandomClass.Next(3, 6)
        Sync(RandomNumber)
    End Sub

    Private Sub CheckTime_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckTime.Tick
        Dim ts As TimeSpan = stopWatch.Elapsed
        Dim nextmins As String
        Dim nextsecs As String
        nowlocal = Now
        nowlocal = nowlocal.AddHours(ts.Hours)
        nowlocal = nowlocal.AddMinutes(ts.Minutes)
        nowlocal = nowlocal.AddSeconds(ts.Seconds)
        nowlocal = nowlocal.AddMilliseconds(ts.Milliseconds)
        Label1.Text = nowlocal.DayOfWeek.ToString + ", " + nowlocal.Day.ToString + " " + getMonth(nowlocal.Month) + " " + nowlocal.Year.ToString + " - " + nowlocal.TimeOfDay.ToString.Substring(0, 8)
        nextmins = 60 - nowlocal.Minute - 1
        nextsecs = 60 - nowlocal.Second
        If nextsecs = "60" Then
            nextsecs = "00"
            nextmins = nextmins + 1
        End If
        Select Case nextmins
            Case 4
                Label2.ForeColor = Color.FromArgb(CType(100, Byte), CType(0, Byte), CType(0, Byte))
            Case 3
                Label2.ForeColor = Color.FromArgb(CType(130, Byte), CType(0, Byte), CType(0, Byte))
            Case 2
                Label2.ForeColor = Color.FromArgb(CType(160, Byte), CType(0, Byte), CType(0, Byte))
            Case 1
                Label2.ForeColor = Color.FromArgb(CType(200, Byte), CType(0, Byte), CType(0, Byte))
            Case 0
                Label2.ForeColor = Color.FromArgb(CType(255, Byte), CType(0, Byte), CType(0, Byte))
            Case Else
                Label2.ForeColor = Color.Black
        End Select
        If Minibar.Visible = True Then
            Select Case nextmins
                Case 4
                    Minibar.Label2.ForeColor = Color.FromArgb(CType(100, Byte), CType(0, Byte), CType(0, Byte))
                Case 3
                    Minibar.Label2.ForeColor = Color.FromArgb(CType(130, Byte), CType(0, Byte), CType(0, Byte))
                Case 2
                    Minibar.Label2.ForeColor = Color.FromArgb(CType(160, Byte), CType(0, Byte), CType(0, Byte))
                Case 1
                    Minibar.Label2.ForeColor = Color.FromArgb(CType(200, Byte), CType(0, Byte), CType(0, Byte))
                Case 0
                    Minibar.Label2.ForeColor = Color.FromArgb(CType(255, Byte), CType(0, Byte), CType(0, Byte))
                Case Else
                    Minibar.Label2.ForeColor = Color.Black
            End Select
        End If
        If nextmins.Length = 1 Then
            nextmins = "0" & nextmins
        End If
        If nextsecs.Length = 1 Then
            nextsecs = "0" & nextsecs
        End If
        Me.Label2.Text = "Until TOTH: 00:" & nextmins & ":" & nextsecs

        ' Paulo's section for textual representation

        Dim part1 As String = ""
        Dim part2 As String = ""
        Dim part3 As String = ""

        Select Case nowlocal.Minute
            Case 0
                part1 = ""
                If nowlocal.Hour <> 12 And nowlocal.Hour <> 0 Then
                    part3 = " o clock"
                End If
            Case 15
                part1 = "Quarter past "
            Case 30
                part1 = "Half past "
            Case 45
                part1 = "Quarter to "
            Case Is < 30
                If nowlocal.Minute = 1 Then
                    part1 = nowlocal.Minute.ToString + " minute past "
                Else
                    part1 = nowlocal.Minute.ToString + " minutes past "
                End If
            Case Is > 30
                If (60 - nowlocal.Minute) = 1 Then
                    part1 = (60 - nowlocal.Minute).ToString + " minute to "
                Else
                    part1 = (60 - nowlocal.Minute).ToString + " minutes to "
                End If
        End Select

        Select Case nowlocal.Minute
            Case Is < 31
                If nowlocal.Minute = 0 And nowlocal.Hour = 0 Then
                    part2 = "Midnight"
                ElseIf nowlocal.Minute = 0 And nowlocal.Hour = 12 Then
                    part2 = "Midday"
                ElseIf nowlocal.Hour = 0 Then
                    part2 = "12"
                ElseIf nowlocal.Hour < 13 Then
                    part2 = nowlocal.Hour.ToString
                Else
                    part2 = (nowlocal.Hour - 12).ToString
                End If
            Case Is > 30
                If nowlocal.Hour < 12 Then
                    part2 = (nowlocal.Hour + 1).ToString
                ElseIf nowlocal.Hour = 23 Then
                    part2 = "12"
                Else
                    part2 = (nowlocal.Hour - 11).ToString
                End If
        End Select

        Label3.Text = "Textual: " + part1 + part2 + part3

        ' End Paulo's section
        
        If Minibar.Visible = True Then
            Minibar.Label1.Text = Label1.Text
            Minibar.Label2.Text = Label2.Text
        End If
        If MinibarExtra.Visible = True Then
            MinibarExtra.Label3.Text = Label3.Text
            MinibarExtra.nowlocal = nowlocal
            MinibarExtra.Invalidate()
        End If
        Me.Invalidate()


        
    End Sub
    Private Sub Sync(ByVal index As Integer)
        TimeIdx = index
        'WebBrowser1 = New WebBrowser
        'WebBrowser1.Navigate(New Uri("http://" & TimeServers(TimeIdx) & ":13"))
        If TimeIdx > 10 Then
            MsgBox("Could not sync with server, using local PC time, please check your connection")
            CheckTime.Stop()
            Now = DateTime.UtcNow
            If IsInBST(Now) = True Then
                Now = Now.AddHours(1)
            End If
            stopWatch.Reset()
            stopWatch.Start()
            CheckTime.Start()
            BackgroundWorker1.CancelAsync()
            Button1.Text = "Sync With Server"
            Button1.Enabled = True
        Else
            BackgroundWorker1.RunWorkerAsync()
            IsStrdataReady.Start()

            'Try

            '    'Dim webReq As HttpWebRequest = WebRequest.Create("http://" & TimeServers(TimeIdx) & ":13")
            '    'Dim webResp As HttpWebResponse = webReq.GetResponse()
            '    'Dim dataStream As Stream = webResp.GetResponseStream
            '    'Dim streamRead As New StreamReader(dataStream)
            '    'Dim strData As String = streamRead.ReadToEnd()

            '    'Dim webReq As WebRequest = WebRequest.Create("http://" & TimeServers(TimeIdx) & ":13")
            '    'Dim tcpreq As New TcpClient
            '    'tcpreq.Connect(TimeServers(TimeIdx), 13)
            '    'Dim datastream As Stream = tcpreq.GetStream
            '    'Dim streamRead As New StreamReader(datastream)
            '    'Dim strData As String = streamRead.ReadToEnd()
            '    BackgroundWorker1.RunWorkerAsync()



            '    If InStr(strData, "UTC(NIST)") = False Then
            '        If TimeIdx > 9 Then
            '            MsgBox("Could not sync with server, using local PC time, please check your connection")
            '            CheckTime.Stop()
            '            Now = DateTime.UtcNow
            '            If IsInBST(Now) = True Then
            '                Now = Now.AddHours(1)
            '            End If
            '            CheckTime.Start()
            '            Button1.Text = "Sync With Server"
            '            Button1.Enabled = True
            '        Else
            '            Sync(TimeIdx + 1)
            '        End If
            '    Else
            '        webtext = strData
            '        webarray = Split(webtext, " ")
            '        webtext = webarray(1) & " " & webarray(2)
            '        webarray = Split(webtext, "-")
            '        webarray2 = Split(webarray(2), " ")
            '        webtext = webarray2(0) & "/" & webarray(1) & "/" & webarray(0) & " " & webarray2(1)
            '        CheckTime.Stop()
            '        Now = webtext
            '        ' Now = "20/01/2008 00:50:00"
            '        If IsInBST(Now) = True Then
            '            Now = Now.AddHours(1)
            '        End If

            '        CheckTime.Start()

            '        ' AddToTime.Start()
            '        stopWatch.Reset()
            '        stopWatch.Start()

            '        CheckTime.Enabled = True
            '        CheckTime.Start()
            '        Button1.Text = "Sync With Server"
            '        Button1.Enabled = True
            '    End If

            'Catch ex As Exception
            '    If InStr(ex.ToString, "did not properly respond after a period of time") Then
            '        Sync(TimeIdx + 1)
            '    Else
            '        MsgBox("Unable to connect to server, please check your internet connection")
            '        Button1.Text = "Sync With Server"
            '        Button1.Enabled = True
            '    End If
            'End Try
        End If
    End Sub
    Private Sub syncfollow()
        If ex.ToString <> standardex Then
            If InStr(ex.ToString, "did not properly respond after a period of time") Then
                Sync(TimeIdx + 1)
            Else
                MsgBox("Unable to connect to server, please check your internet connection")
                BackgroundWorker1.CancelAsync()
                Button1.Text = "Sync With Server"
                Button1.Enabled = True
            End If
        Else
            If InStr(strdata, "UTC(NIST)") = False Then
                If TimeIdx > 9 Then
                    MsgBox("Could not sync with server, using local PC time, please check your connection")
                    CheckTime.Stop()
                    Now = DateTime.UtcNow
                    If IsInBST(Now) = True Then
                        Now = Now.AddHours(1)
                    End If
                    CheckTime.Start()
                    BackgroundWorker1.CancelAsync()
                    Button1.Text = "Sync With Server"
                    Button1.Enabled = True
                Else
                    Sync(TimeIdx + 1)
                End If
            Else
                webtext = strdata
                webarray = Split(webtext, " ")
                webtext = webarray(1) & " " & webarray(2)
                webarray = Split(webtext, "-")
                webarray2 = Split(webarray(2), " ")
                'If StrConv(My.Settings.Username, VbStrConv.ProperCase) = "Bob Eberth" Then
                ' American Date Fix
                'webtext = webarray(1) & "/" & webarray2(0) & "/" & webarray(0) & " " & webarray2(1)
                'Else
                webtext = webarray2(0) & "/" & webarray(1) & "/" & webarray(0) & " " & webarray2(1)
                ' End If
                CheckTime.Stop()

                If StrConv(My.Settings.Username, VbStrConv.ProperCase) = "Bob Eberth" Then
                    webtext = webarray(1) & "/" & webarray2(0) & "/" & webarray(0) & " " & webarray2(1)
                    Now = webtext
                    american = True
                Else
                    Now = webtext
                    american = False
                End If


                ' Now = "20/01/2008 00:50:00"
                If IsInBST(Now) = True Then
                    Now = Now.AddHours(1)
                End If

                CheckTime.Start()

                ' AddToTime.Start()
                stopWatch.Reset()
                stopWatch.Start()

                CheckTime.Enabled = True
                CheckTime.Start()
                BackgroundWorker1.CancelAsync()
                Button1.Text = "Sync With Server"
                Button1.Enabled = True
            End If
            End If
        
    End Sub
    'Private Sub WebBrowser1_DocumentCompleted(ByVal sender As System.Object, ByVal e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted

    '    If InStr(WebBrowser1.DocumentText, "UTC(NIST)") = False Then
    '        If TimeIdx = 14 Then
    '            MsgBox("Could not sync with server, using local PC time, please check your connection")
    '            CheckTime.Stop()
    '            Now = DateTime.UtcNow
    '            If IsInBST(Now) = True Then
    '                Now = Now.AddHours(1)
    '            End If
    '            CheckTime.Start()
    '            Button1.Text = "Sync With Server"
    '            Button1.Enabled = True
    '        Else
    '            Sync(TimeIdx + 1)
    '        End If
    '    Else
    '        webtext = WebBrowser1.DocumentText
    '        webarray = Split(webtext, " ")
    '        webtext = webarray(1) & " " & webarray(2)
    '        webarray = Split(webtext, "-")
    '        webarray2 = Split(webarray(2), " ")
    '        webtext = webarray2(0) & "/" & webarray(1) & "/" & webarray(0) & " " & webarray2(1)
    '        CheckTime.Stop()
    '        Now = webtext
    '        ' Now = "20/01/2008 00:50:00"
    '        If IsInBST(Now) = True Then
    '            Now = Now.AddHours(1)
    '        End If

    '        CheckTime.Start()

    '        ' AddToTime.Start()
    '        stopWatch.Reset()
    '        stopWatch.Start()

    '        CheckTime.Enabled = True
    '        CheckTime.Start()
    '        Button1.Text = "Sync With Server"
    '        Button1.Enabled = True

    '    End If

    'End Sub
    
 
    Private Sub AddToTime_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToTime.Tick
        Now = Now.AddSeconds(1)
    End Sub

    ' Draw the clock's face without hands.
    Private Sub DrawFace()
        ' Make a Bitmap to hold the clock face.
        m_Face = New Bitmap(clockwidth, _
            clockheight)
        Dim gr As Graphics = Graphics.FromImage(m_Face)

        ' Use a purple background. This will later be
        ' transparent.
        'gr.Clear(Color.Purple)

        ' Fill the clock face with CornflowerBlue.
        Dim inner_rect As New Rectangle(0, 0, _
            clockwidth - 1, _
            clockheight - 1)
        gr.FillEllipse(Brushes.CornflowerBlue, inner_rect)

        ' Draw the clock face.
        gr.DrawEllipse(Pens.Blue, inner_rect)

        ' Draw the tic marks and numerals.
        Dim cx As Integer = (clockwidth - 1) \ 2
        Dim cy As Integer = (clockheight - 1) \ 2
        Dim dtheta As Double = PI / 30
        Dim theta As Double = -10 * dtheta
        Dim x1, y1, x2, y2 As Double
        Dim txt As String
        For i As Integer = 0 To 59
            ' Draw the tic marks.
            x1 = cx + cx * Cos(theta)
            y1 = cy + cy * Sin(theta)
            If i Mod 5 = 0 Then
                ' Label the digit.
                txt = (i \ 5 + 1).ToString()

                ' Find the point lined up along the tic mark.
                x2 = cx + (cx - 1) * Cos(theta) * 0.8
                y2 = cy + (cy - 1) * Sin(theta) * 0.8

                ' Create a rotated font.
                DrawRotatedText(gr, txt, _
                    CSng(360 * (i + 5) / 60), _
                    x2, y2)

                x2 = cx + cx * Cos(theta) * 0.9
                y2 = cy + cy * Sin(theta) * 0.9
            Else
                x2 = cx + cx * Cos(theta) * 0.95
                y2 = cy + cy * Sin(theta) * 0.95
            End If
            gr.DrawLine(Pens.Blue, CSng(x1), CSng(y1), _
                CSng(x2), CSng(y2))
            theta += dtheta
        Next i

        ' Display the clock face on the form's background.
        'Me.PictureBox1.Image = m_Face

        ' Set TransparencyKey so the purple background is
        ' transparent.
        ' Me.TransparencyKey = Color.Purple
    End Sub
    ' Draw text centered at (cx, cy) and 
    ' rotated by angle degrees.
    Private Sub DrawRotatedText(ByVal gr As Graphics, ByVal txt _
        As String, ByVal angle As Single, ByVal cx As Double, _
        ByVal cy As Double)
        ' Make a StringFormat that centers text.
        Dim string_format As New StringFormat
        string_format.Alignment = StringAlignment.Center
        string_format.LineAlignment = StringAlignment.Center

        ' Make a GraphicsPath that draws the text.
        Dim graphics_path As New GraphicsPath( _
            Drawing.Drawing2D.FillMode.Winding)
        Dim ix As Integer = CInt(cx)
        Dim iy As Integer = CInt(cy)
        graphics_path.AddString(txt, _
            Me.Font.FontFamily, _
            Me.Font.Style, Me.Font.Size, _
            New Point(ix, iy), _
            string_format)

        ' Make a rotation matrix representing 
        ' rotation around the point (ix, iy).
        Dim rotation_matrix As New Matrix
        rotation_matrix.RotateAt(angle, New PointF(ix, iy))

        ' Transform the GraphicsPath.
        graphics_path.Transform(rotation_matrix)

        ' Draw the text.
        gr.FillPath(Brushes.Black, graphics_path)
        gr.DrawPath(Pens.Black, graphics_path)


    End Sub
    ' Draw the clock's face with hands.
    Private Sub TOTHClock_Paint(ByVal sender As Object, ByVal e As  _
        System.Windows.Forms.PaintEventArgs) Handles _
        MyBase.Paint
        Const HOUR_R As Double = 0.35
        Const MIN_R As Double = 0.65
        Const SEC_R As Double = 0.75

        If m_Face Is Nothing Then Exit Sub

        ' Copy the face onto the bitmap.
        e.Graphics.DrawImage(m_Face, 10, 10)

        ' Draw the hands.
        Dim cx As Double = clockwidth / 2 + 10
        Dim cy As Double = clockheight / 2 + 10
        Dim x1, y1, theta As Double

        ' Draw the hour hand.
        Dim time_span As TimeSpan = nowlocal.TimeOfDay()
        theta = time_span.TotalHours() / 12 * 2 * PI - PI / 2
        x1 = cx + cx * Cos(theta) * HOUR_R
        y1 = cy + cy * Sin(theta) * HOUR_R
        e.Graphics.DrawLine(Pens.Yellow, _
            CSng(cx), CSng(cy), CSng(x1), CSng(y1))

        ' Draw the minute hand.
        theta = time_span.TotalMinutes() / 60 * 2 * PI - PI / 2
        x1 = cx + cx * Cos(theta) * MIN_R
        y1 = cy + cy * Sin(theta) * MIN_R
        e.Graphics.DrawLine(Pens.Orange, _
            CSng(cx), CSng(cy), CSng(x1), CSng(y1))

        ' Draw the second hand.
        theta = time_span.TotalSeconds() / 60 * 2 * PI - PI / 2
        x1 = cx + cx * Cos(theta) * SEC_R
        y1 = cy + cy * Sin(theta) * SEC_R
        e.Graphics.DrawLine(Pens.LightBlue, _
            CSng(cx), CSng(cy), CSng(x1), CSng(y1))

        ' Draw a circle in the middle.
        e.Graphics.FillEllipse(Brushes.Black, _
            CSng(cx - 3), CSng(cy - 3), 5, 5)



    End Sub
    Private Function IsInBST(ByRef dteTime As Date) As Boolean
        Dim weekday_ As Object = "1"
        'LastSundayInMarch
        Dim LastDayInMarch As Date
        If american = True Or StrConv(My.Settings.Username, VbStrConv.ProperCase) = "Bob Eberth" Then
            american = True
            LastDayInMarch = "03/31/" & dteTime.Year
        Else
            american = False
            LastDayInMarch = "31/03/" & dteTime.Year
        End If
        'UPGRADE_WARNING: Couldn't resolve default property of object weekday_. Click for more: 'ms-help://MS.VSExpressCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Do Until weekday_ = "0"
            'UPGRADE_WARNING: Couldn't resolve default property of object weekday_. Click for more: 'ms-help://MS.VSExpressCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            weekday_ = LastDayInMarch.DayOfWeek
            'UPGRADE_WARNING: Couldn't resolve default property of object weekday_. Click for more: 'ms-help://MS.VSExpressCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If weekday_ = "0" Then Exit Do
            LastDayInMarch = System.DateTime.FromOADate(LastDayInMarch.ToOADate - 1)
            System.Windows.Forms.Application.DoEvents()

        Loop

        'UPGRADE_WARNING: Couldn't resolve default property of object weekday_. Click for more: 'ms-help://MS.VSExpressCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        weekday_ = ""

        'LastSundayInOctober
        Dim LastDayInOctober As Date
        If american = True Or StrConv(My.Settings.Username, VbStrConv.ProperCase) = "Bob Eberth" Then
            american = True
            LastDayInOctober = "10/31/" & dteTime.Year
        Else
            LastDayInOctober = "31/10/" & dteTime.Year
        End If
        'UPGRADE_WARNING: Couldn't resolve default property of object weekday_. Click for more: 'ms-help://MS.VSExpressCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Do Until weekday_ = "0"
            'UPGRADE_WARNING: Couldn't resolve default property of object weekday_. Click for more: 'ms-help://MS.VSExpressCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            weekday_ = LastDayInOctober.DayOfWeek
            'UPGRADE_WARNING: Couldn't resolve default property of object weekday_. Click for more: 'ms-help://MS.VSExpressCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If weekday_ = "0" Then Exit Do
            LastDayInOctober = System.DateTime.FromOADate(LastDayInOctober.ToOADate - 1)
            System.Windows.Forms.Application.DoEvents()

        Loop



        If (dteTime >= (System.DateTime.FromOADate(LastDayInMarch.ToOADate + 1 / 24))) And (dteTime <= (System.DateTime.FromOADate(LastDayInOctober.ToOADate + (1 / 24) - 1 / 24 / 60 / 60))) Then
            IsInBST = True
        Else
            IsInBST = False
        End If
    End Function

   
    
    Private Sub TOTHClock_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged
        If Visible = True And loadstart <> "done" Then
            Application.DoEvents()
            Sync(0)
            loadstart = "done"
        End If
        If Visible = True Then
            Dim maxwidth As Integer = TableLayoutPanel1.Width - 175 - 15
            Dim maxheight As Integer = TableLayoutPanel1.Height - 20

            If maxwidth < 0.1 Then
                maxwidth = 20
            End If
            If maxheight < 0.1 Then
                maxheight = 20
            End If

            If maxwidth > maxheight Then
                clockwidth = maxheight
                clockheight = maxheight
            Else
                clockwidth = maxwidth
                clockheight = maxwidth
            End If

            DrawFace()
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        strdata = ""
        ex = New Exception
        Try
            Dim tcpreq As New TcpClient
            tcpreq.Connect(TimeServers(TimeIdx), 13)
            Dim datastream As Stream = tcpreq.GetStream
            Dim streamRead As New StreamReader(datastream)
            strdata = streamRead.ReadToEnd()

            'Dim webReq As HttpWebRequest = WebRequest.Create("http://" + TimeServers(TimeIdx) + ":13")
            'webReq.Timeout = 8000
            'Dim webResp As HttpWebResponse = webReq.GetResponse()
            'Dim dataStream As Stream = webResp.GetResponseStream
            'Dim streamRead As New StreamReader(dataStream)
            'strdata = streamRead.ReadToEnd()

            'MsgBox("str" + strdata)
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub IsStrdataReady_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IsStrdataReady.Tick
        strdatacheckcount = strdatacheckcount + 1
        If ex.ToString <> standardex Or strdata <> "" Then
            IsStrdataReady.Stop()
            strdatacheckcount = 0
            If strdata <> "" Then
                ex = New Exception
            End If
            syncfollow()
        ElseIf strdatacheckcount > 3 Then
            BackgroundWorker1.CancelAsync()
            If Not BackgroundWorker1.IsBusy Then
                IsStrdataReady.Stop()
                strdatacheckcount = 0
                Sync(TimeIdx + 1)
            End If
        End If
    End Sub

    Private Sub TOTHClock_ResizeEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ResizeEnd
        Dim maxwidth As Integer = TableLayoutPanel1.Width - 175 - 30
        Dim maxheight As Integer = TableLayoutPanel1.Height - 20

        If maxwidth < 0.1 Then
            maxwidth = 20
        End If
        If maxheight < 0.1 Then
            maxheight = 20
        End If

        If maxwidth > maxheight Then
            clockwidth = maxheight
            clockheight = maxheight
        Else
            clockwidth = maxwidth
            clockheight = maxwidth
        End If

        DrawFace()
    End Sub

    Private Sub TOTHClock_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Dim maxwidth As Integer = TableLayoutPanel1.Width - 175 - 30
        Dim maxheight As Integer = TableLayoutPanel1.Height - 20

        If maxwidth < 0.1 Then
            maxwidth = 20
        End If
        If maxheight < 0.1 Then
            maxheight = 20
        End If

        If maxwidth > maxheight Then
            clockwidth = maxheight
            clockheight = maxheight
        Else
            clockwidth = maxwidth
            clockheight = maxwidth
        End If

        DrawFace()
    End Sub
End Class