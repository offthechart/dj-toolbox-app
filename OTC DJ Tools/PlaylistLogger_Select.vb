Public Class PlaylistLogger_Select

    Private Sub PlaylistLogger_Select_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        ' PlaylistLogger.Enabled = True
    End Sub

    Private Sub PlaylistLogger_Select_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Minibar.Visible = False Then
            MdiParent = Enclosure
        End If
        PlaylistLogger.Enabled = False

        If Not PlaylistLogger.myid3tags Is Nothing Then
            Label2.Text = "Artist: " + PlaylistLogger.myid3tags.artist
            Label3.Text = "Title: " + PlaylistLogger.myid3tags.title
        Else
            RadioButton1.Enabled = False
            Label2.Enabled = False
            Label3.Enabled = False
        End If

        ' IN EITHER CASE, USE ID3 DURATION
        If PlaylistLogger.myfiletags.ToString <> "System.String[]" Then
            Label5.Text = "Artist: " + PlaylistLogger.myfiletags
            If PlaylistLogger.myfiletags = "" Then
                RadioButton2.Enabled = False
                Label5.Enabled = False
                Label4.Enabled = False
            End If
        Else
            Label5.Text = "Artist: " + PlaylistLogger.myfiletags(0)
            Label4.Text = "Title: " + PlaylistLogger.myfiletags(1)
            If PlaylistLogger.myfiletags(0) = "" And PlaylistLogger.myfiletags(1) = "" Then
                RadioButton2.Enabled = False
                Label5.Enabled = False
                Label4.Enabled = False
            End If
        End If

        If RadioButton1.Enabled = True Then
            RadioButton1.Checked = True
        ElseIf RadioButton2.Enabled = True Then
            RadioButton2.Checked = True
        Else
            RadioButton3.Checked = True
        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        PlaylistLogger.Enabled = True
        Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If RadioButton3.Checked = True Then
            PlaylistLogger_Manual.Show()
        ElseIf RadioButton2.Checked = True Then
            If PlaylistLogger.myfiletags.ToString <> "System.String[]" Then
                If Not PlaylistLogger.myid3tags Is Nothing Then
                    PlaylistLogger.DataGridView1.Rows(PlaylistLogger.DataGridView1.Rows.Add).SetValues(PlaylistLogger.myfiletags, "", "", Fix(PlaylistLogger.myid3tags.duration).ToString, "", "", "", "", "false")
                Else
                    PlaylistLogger.DataGridView1.Rows(PlaylistLogger.DataGridView1.Rows.Add).SetValues(PlaylistLogger.myfiletags, "", "", "", "", "", "", "", "false")
                End If
            Else
                If Not PlaylistLogger.myid3tags Is Nothing Then
                    PlaylistLogger.DataGridView1.Rows(PlaylistLogger.DataGridView1.Rows.Add).SetValues(PlaylistLogger.myfiletags(0), PlaylistLogger.myfiletags(1), "", Fix(PlaylistLogger.myid3tags.duration).ToString, "", "", "", "", "false")
                Else
                    PlaylistLogger.DataGridView1.Rows(PlaylistLogger.DataGridView1.Rows.Add).SetValues(PlaylistLogger.myfiletags(0), PlaylistLogger.myfiletags(1), "", "", "", "", "", "", "false")
                End If
            End If
            PlaylistLogger.Enabled = True
        ElseIf RadioButton1.Checked = True Then
            If Not PlaylistLogger.myid3tags Is Nothing Then
                If PlaylistLogger.myid3tags.artist.ToString = "" Then
                    PlaylistLogger.DataGridView1.Rows(PlaylistLogger.DataGridView1.Rows.Add).SetValues(" ", PlaylistLogger.myid3tags.title.ToString, "", Fix(PlaylistLogger.myid3tags.duration).ToString, "", "", "", "", "false")
                Else
                    PlaylistLogger.DataGridView1.Rows(PlaylistLogger.DataGridView1.Rows.Add).SetValues(PlaylistLogger.myid3tags.artist.ToString, PlaylistLogger.myid3tags.title.ToString, "", Fix(PlaylistLogger.myid3tags.duration).ToString, "", "", "", "", "false")
                End If
            End If
            PlaylistLogger.Enabled = True
        End If
        Close()
    End Sub

End Class