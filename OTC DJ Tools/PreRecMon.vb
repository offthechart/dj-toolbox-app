Imports System.Drawing.Drawing2D
Imports System.Math


Public Class PreRecMon
    Private m_Face As Bitmap
    Dim clockwidth As Integer = 150
    Dim clockheight As Integer = 150
    Dim mydate As DateTime
    Dim tempdate As DateTime
    Dim duration As Integer
    Dim stopWatch As New Stopwatch()

    Private Sub PreRecMon_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Enclosure.ToolStripButton3.Checked = False
        My.Settings.PreRecXPos = Me.Location.X
        My.Settings.PreRecYPos = Me.Location.Y
        My.Settings.PreRecWidth = Me.Size.Width
        My.Settings.PreRecHeight = Me.Size.Height
        My.Settings.Save()
    End Sub

    Private Sub PreRecMon_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If My.Settings.PreRecHeight <> "0" And My.Settings.PreRecWidth <> "0" And My.Settings.PreRecXPos <> "0" And My.Settings.PreRecYPos <> "0" Then
            Me.SetDesktopBounds(My.Settings.PreRecXPos, My.Settings.PreRecYPos, My.Settings.PreRecWidth, My.Settings.PreRecHeight)
        End If
        DrawFace()
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
        ' Me.PictureBox1.Image = m_Face

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
    Private Sub PreRecMon_Paint(ByVal sender As Object, ByVal e As  _
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
        Dim time_span As TimeSpan = mydate.TimeOfDay()
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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Button1.Text = "Start" Then
            FromDate.Enabled = False
            NumericUpDown1.Enabled = False
            NumericUpDown2.Enabled = False
            Button1.Text = "Stand By..."
            mydate = FromDate.Value
            mydate = mydate.AddSeconds(-10)
            tempdate = mydate
            duration = (((NumericUpDown1.Value * 60) + NumericUpDown2.Value) * 60) + 10
            ' finaldate = mydate.AddSeconds(duration)
            stopWatch.Reset()
            stopWatch.Start()
            CheckTime.Enabled = True
            CheckTime.Start()
        Else
            CheckTime.Stop()
            CheckTime.Enabled = False
            stopWatch.Stop()
            FromDate.Enabled = True
            NumericUpDown1.Enabled = True
            NumericUpDown2.Enabled = True
            Button1.Text = "Start"
        End If
    End Sub

    Private Sub CheckTime_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckTime.Tick
        Dim ts As TimeSpan = stopWatch.Elapsed
        Dim datetimeremain As DateTime
        Dim datetimetaken As DateTime
        If ts.TotalSeconds > 10 Then
            Dim secondsremain As Integer = duration - Fix(ts.TotalSeconds)
            Dim secondstaken As Integer = Fix(ts.TotalSeconds) - 10
            datetimetaken = datetimetaken.AddSeconds(secondstaken)
            datetimeremain = datetimeremain.AddSeconds(secondsremain)
        End If
        Dim saveddate As DateTime
        saveddate = tempdate
        tempdate = tempdate.AddHours(ts.Hours)
        tempdate = tempdate.AddMinutes(ts.Minutes)
        tempdate = tempdate.AddSeconds(ts.Seconds)
        tempdate = tempdate.AddMilliseconds(ts.Milliseconds)
        mydate = tempdate
        tempdate = saveddate

        Dim string1 As String = mydate.Hour.ToString
        Dim string2 As String = mydate.Minute.ToString
        Dim string3 As String = mydate.Second.ToString
        If string1.Length = 1 Then
            string1 = "0" + string1
        End If
        If string2.Length = 1 Then
            string2 = "0" + string2
        End If
        If string3.Length = 1 Then
            string3 = "0" + string3
        End If
        Label4.Text = string1 + ":" + string2 + ":" + string3

        string1 = datetimetaken.Hour.ToString
        string2 = datetimetaken.Minute.ToString
        string3 = datetimetaken.Second.ToString
        If string1.Length = 1 Then
            string1 = "0" + string1
        End If
        If string2.Length = 1 Then
            string2 = "0" + string2
        End If
        If string3.Length = 1 Then
            string3 = "0" + string3
        End If
        Label9.Text = string1 + ":" + string2 + ":" + string3

        string1 = datetimeremain.Hour.ToString
        string2 = datetimeremain.Minute.ToString
        string3 = datetimeremain.Second.ToString
        If string1.Length = 1 Then
            string1 = "0" + string1
        End If
        If string2.Length = 1 Then
            string2 = "0" + string2
        End If
        If string3.Length = 1 Then
            string3 = "0" + string3
        End If
        Label10.Text = string1 + ":" + string2 + ":" + string3

        ' Paulo's section for textual representation

        Dim part1 As String = ""
        Dim part2 As String = ""
        Dim part3 As String = ""

        Select Case mydate.Minute
            Case 0
                part1 = ""
                If mydate.Hour <> 12 And mydate.Hour <> 0 Then
                    part3 = " o clock"
                End If
            Case 15
                part1 = "Quarter past "
            Case 30
                part1 = "Half past "
            Case 45
                part1 = "Quarter to "
            Case Is < 30
                If mydate.Minute = 1 Then
                    part1 = mydate.Minute.ToString + " minute past "
                Else
                    part1 = mydate.Minute.ToString + " minutes past "
                End If
            Case Is > 30
                If (60 - mydate.Minute) = 1 Then
                    part1 = (60 - mydate.Minute).ToString + " minute to "
                Else
                    part1 = (60 - mydate.Minute).ToString + " minutes to "
                End If
        End Select

        Select Case mydate.Minute
            Case Is < 31
                If mydate.Minute = 0 And mydate.Hour = 0 Then
                    part2 = "Midnight"
                ElseIf mydate.Minute = 0 And mydate.Hour = 12 Then
                    part2 = "Midday"
                ElseIf mydate.Hour = 0 Then
                    part2 = "12"
                ElseIf mydate.Hour < 13 Then
                    part2 = mydate.Hour.ToString
                Else
                    part2 = (mydate.Hour - 12).ToString
                End If
            Case Is > 30
                If mydate.Hour < 12 Then
                    part2 = (mydate.Hour + 1).ToString
                ElseIf mydate.Hour = 23 Then
                    part2 = "12"
                Else
                    part2 = (mydate.Hour - 11).ToString
                End If
        End Select

        Label12.Text = part1 + part2 + part3

        ' End Paulo's section

        If ts.TotalSeconds > 10 Then
            Dim nextmins As String
            Dim nextsecs As String

            nextmins = 60 - mydate.Minute - 1
            nextsecs = 60 - mydate.Second
            If nextsecs = "60" Then
                nextsecs = "00"
                nextmins = nextmins + 1
            End If
            Select Case nextmins
                Case 4
                    Label11.ForeColor = Color.FromArgb(CType(100, Byte), CType(0, Byte), CType(0, Byte))
                Case 3
                    Label11.ForeColor = Color.FromArgb(CType(130, Byte), CType(0, Byte), CType(0, Byte))
                Case 2
                    Label11.ForeColor = Color.FromArgb(CType(160, Byte), CType(0, Byte), CType(0, Byte))
                Case 1
                    Label11.ForeColor = Color.FromArgb(CType(200, Byte), CType(0, Byte), CType(0, Byte))
                Case 0
                    Label11.ForeColor = Color.FromArgb(CType(255, Byte), CType(0, Byte), CType(0, Byte))
                Case Else
                    Label11.ForeColor = Color.Black
            End Select
            If nextmins.Length = 1 Then
                nextmins = "0" & nextmins
            End If
            If nextsecs.Length = 1 Then
                nextsecs = "0" & nextsecs
            End If
            Me.Label11.Text = "00:" & nextmins & ":" & nextsecs
        Else
            Me.Label11.Text = "00:00:00"
            Label11.ForeColor = Color.Black
        End If
        Me.Invalidate()
        If ts.TotalSeconds > 10 Then
            Button1.Text = "Stop"
        End If
        If ts.TotalSeconds > duration Then
            Button1_Click(sender, e)
        End If
    End Sub
End Class