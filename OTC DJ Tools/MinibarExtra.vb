Imports System.Math
Imports System.Drawing.Drawing2D
Imports System.Net
Imports System.IO

Public Class MinibarExtra
    Private m_Face As Bitmap
    Dim clockwidth As Integer = 150
    Dim clockheight As Integer = 150
    Public nowlocal As DateTime = TOTHClock.nowlocal
    Dim alert As String = "Data unavailable..."
    Dim npdata As String = "Data unavailable..."

    Private Sub MinibarClock_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Login.email <> "none" Then
            Label6.Text = "E-mail: " + Login.email.ToLower + "@offthechartradio.co.uk"
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

    Private Sub MinibarClock_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged
        If Visible = True Then
            If Minibar.Visible = "true" And Minibar.useddock = "false" Then
                If (Minibar.Location.Y - Me.Height) < 0 Then
                    Me.PictureBox1.Hide()
                    Me.PictureBox4.Show()
                    Me.SetBounds(Minibar.Location.X - StatusChange.Width - Me.Width + Minibar.Width - 5, Minibar.Location.Y + Minibar.Height, Me.Width, Me.Height)
                Else
                    Me.PictureBox4.Hide()
                    Me.PictureBox1.Show()
                    Me.SetBounds(Minibar.Location.X - StatusChange.Width - Me.Width + Minibar.Width - 5, Minibar.Location.Y - Me.Height, Me.Width, Me.Height)
                End If
            Else
                Me.PictureBox4.Hide()
                Me.PictureBox1.Show()
                Me.SetBounds(Screen.GetWorkingArea(Me).Width - StatusChange.Width - Me.Width - 5, Screen.GetWorkingArea(Me).Height - Me.Height, Me.Width, Me.Height)
            End If
        End If
    End Sub


End Class