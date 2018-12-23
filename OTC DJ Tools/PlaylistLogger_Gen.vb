Public Class PlaylistLogger_Gen
    'Public mydate As String
    'Public mytime As String

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Close()
    End Sub

    Private Sub PlaylistLogger_Gen_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        PlaylistLogger.Enabled = True
    End Sub

    Private Sub PlaylistLogger_Gen_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Minibar.Visible = False Then
            MdiParent = Enclosure
        End If
        PlaylistLogger.Enabled = False
        PlaylistLogger.generatetimes()
        Dim mydate As Date = PlaylistLogger.DateTimePicker1.Value
        ' Dim mydate As DateTime = PlaylistLogger.DateTimePicker1.Value
        TextBox1.Text = "[b]" + mydate.DayOfWeek.ToString + " " + mydate.ToLongDateString + "[/b]" + vbNewLine + "[color=red]" + PlaylistLogger.times + "[/color]" + vbNewLine
        If PlaylistLogger.DataGridView1.Rows.Count > 1 Then
            Dim loggerrows As Integer = PlaylistLogger.DataGridView1.Rows.Count
            Dim currentrow As Integer = 0
            While loggerrows > 1
                TextBox1.Text = TextBox1.Text + vbNewLine + PlaylistLogger.DataGridView1.Rows(currentrow).Cells("Artist").Value + " - " + PlaylistLogger.DataGridView1.Rows(currentrow).Cells("Title").Value
                If PlaylistLogger.DataGridView1.Rows(currentrow).Cells("Mix").Value <> "" Then
                    TextBox1.Text = TextBox1.Text + " (" + PlaylistLogger.DataGridView1.Rows(currentrow).Cells("Mix").Value + ")"
                End If
                loggerrows = loggerrows - 1
                currentrow = currentrow + 1
            End While
        End If
        ' format: artist - title (mix)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Clipboard.SetText(TextBox1.Text)
        MsgBox("Playlist copied to the clipboard. Don't forget to use the upload button to send your playlist to the server.")
    End Sub
End Class