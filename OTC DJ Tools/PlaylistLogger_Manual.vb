Public Class PlaylistLogger_Manual
    Public plartist As String
    Public pltitle As String
    Public plversion As String
    Public plduration As String
    Public plcatno As String
    Public pllabel As String
    Public plisrc As String

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Close()
    End Sub

    Private Sub PlaylistLogger_Manual_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        PlaylistLogger.Enabled = True
    End Sub

    Private Sub PlaylistLogger_Manual_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If My.Settings.PlayLogShowMore = False Then
            Me.Height = 203
            Button1.SetBounds(Button1.Location.X, 132, Button1.Width, Button1.Height)
            Button2.SetBounds(Button2.Location.X, 132, Button2.Width, Button2.Height)
            Button3.SetBounds(Button3.Location.X, 132, Button3.Width, Button3.Height)
            Label7.Visible = False
            Label8.Visible = False
            Label9.Visible = False
            TextBox6.Visible = False
            TextBox7.Visible = False
            TextBox8.Visible = False
            Button3.Text = "Show More"
        Else
            Me.Height = 290
            Button1.SetBounds(Button1.Location.X, 219, Button1.Width, Button1.Height)
            Button2.SetBounds(Button2.Location.X, 219, Button2.Width, Button2.Height)
            Button3.SetBounds(Button3.Location.X, 219, Button3.Width, Button3.Height)
            Label7.Visible = True
            Label8.Visible = True
            Label9.Visible = True
            TextBox6.Visible = True
            TextBox7.Visible = True
            TextBox8.Visible = True
            Button3.Text = "Show Less"
        End If
        If Minibar.Visible = False Then
            MdiParent = Enclosure
        End If
        PlaylistLogger.Enabled = False

        TextBox1.Text = plartist
        TextBox2.Text = pltitle
        TextBox3.Text = plversion
        If plduration <> "" Then
            TextBox4.Text = Fix(Integer.Parse(plduration) / 60)
            TextBox5.Text = Integer.Parse(plduration) Mod 60
        End If
        TextBox6.Text = plcatno
        TextBox7.Text = pllabel
        TextBox8.Text = plisrc

        TextBox1.Select()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If TextBox1.Text = "" Then
            MsgBox("You must enter at least an artist to continue.")
        Else
            If (TextBox4.Text <> "" And Not IsNumeric(TextBox4.Text)) Or (TextBox5.Text <> "" And Not IsNumeric(TextBox5.Text)) Then
                MsgBox("Your duration is not numeric, please correct it before continuing.")
            Else
                If plartist = "" And pltitle = "" And plduration = "" And plversion = "" Then
                    If TextBox4.Text <> "" And TextBox5.Text <> "" Then
                        plduration = (Integer.Parse(TextBox4.Text) * 60) + Integer.Parse(TextBox5.Text)
                    ElseIf TextBox4.Text <> "" Then
                        plduration = Integer.Parse(TextBox4.Text) * 60
                    ElseIf TextBox5.Text <> "" Then
                        plduration = Integer.Parse(TextBox5.Text)
                    End If
                    PlaylistLogger.DataGridView1.Rows(PlaylistLogger.DataGridView1.Rows.Add).SetValues(TextBox1.Text, TextBox2.Text, TextBox3.Text, plduration, "", TextBox6.Text, TextBox7.Text, TextBox8.Text, "false")
                    Close()
                Else
                    ' edit rather than add
                    If TextBox4.Text <> "" And TextBox5.Text <> "" Then
                        plduration = (Integer.Parse(TextBox4.Text) * 60) + Integer.Parse(TextBox5.Text)
                    ElseIf TextBox4.Text = "" And TextBox5.Text = "" Then
                        plduration = ""
                    ElseIf TextBox4.Text <> "" Then
                        plduration = Integer.Parse(TextBox4.Text) * 60
                    ElseIf TextBox5.Text <> "" Then
                        plduration = Integer.Parse(TextBox5.Text)
                    ElseIf TextBox4.Text = "" Then
                        plduration = ""
                    ElseIf TextBox5.Text = "" Then
                        plduration = ""
                    End If
                    PlaylistLogger.DataGridView1.Rows(PlaylistLogger.DataGridView1.CurrentRow.Index.ToString).SetValues(TextBox1.Text, TextBox2.Text, TextBox3.Text, plduration, "", TextBox6.Text, TextBox7.Text, TextBox8.Text, "false")
                    Close()
                End If
            End If
        End If
    End Sub
    Private Sub Logger_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyValue = Keys.Enter Then
            Button2_Click(sender, e)
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If Me.Height = 203 Then
            MsgBox("You are entering an advanced editor. The information here is CRITICAL to our licensing submissions and should only be entered by yourself if you have permission and instruction to do so from management.")
            Me.Height = 290
            Button1.SetBounds(Button1.Location.X, 219, Button1.Width, Button1.Height)
            Button2.SetBounds(Button2.Location.X, 219, Button2.Width, Button2.Height)
            Button3.SetBounds(Button3.Location.X, 219, Button3.Width, Button3.Height)
            Label7.Visible = True
            Label8.Visible = True
            Label9.Visible = True
            TextBox6.Visible = True
            TextBox7.Visible = True
            TextBox8.Visible = True
            Button3.Text = "Show Less"
            My.Settings.PlayLogShowMore = "true"
            My.Settings.Save()
        Else
            Me.Height = 203
            Button1.SetBounds(Button1.Location.X, 132, Button1.Width, Button1.Height)
            Button2.SetBounds(Button2.Location.X, 132, Button2.Width, Button2.Height)
            Button3.SetBounds(Button3.Location.X, 132, Button3.Width, Button3.Height)
            Label7.Visible = False
            Label8.Visible = False
            Label9.Visible = False
            TextBox6.Visible = False
            TextBox7.Visible = False
            TextBox8.Visible = False
            Button3.Text = "Show More"
            My.Settings.PlayLogShowMore = "false"
            My.Settings.Save()
        End If
    End Sub
End Class