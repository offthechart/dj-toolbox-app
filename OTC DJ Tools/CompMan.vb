Public Class CompMan
    Dim action As String
    Dim selected As String

    Private Sub Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Add.Click
        TextBox1.Enabled = True
        OK.Enabled = True
        TextBox1.Text = ""
        TextBox1.Select()
        action = "add"
    End Sub

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        OK.Enabled = False
        If action = "add" And TextBox1.Text <> "" Then
            Entrants.Items.Add(TextBox1.Text)
        ElseIf action = "edit" And TextBox1.Text <> "" Then
            Entrants.Items.Insert(selected, TextBox1.Text)
            Entrants.Items.RemoveAt(selected + 1)
        End If
        TextBox1.Text = ""
        TextBox1.Enabled = False
    End Sub

    Private Sub Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Edit.Click
        If Entrants.SelectedIndex <> -1 Then
            TextBox1.Enabled = True
            OK.Enabled = True
            selected = Entrants.SelectedIndex
            action = "edit"
            TextBox1.Text = Entrants.Items.Item(selected)
            TextBox1.Select()
        Else
            TextBox1.Text = ""
            TextBox1.Enabled = False
            OK.Enabled = False
        End If
    End Sub

    Private Sub Entrants_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Entrants.SelectedIndexChanged
        TextBox1.Text = ""
        TextBox1.Enabled = False
        OK.Enabled = False
    End Sub

    Private Sub Remove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Remove.Click
        TextBox1.Text = ""
        TextBox1.Enabled = False
        OK.Enabled = False
        If Entrants.SelectedIndex <> -1 Then
            Entrants.Items.RemoveAt(Entrants.SelectedIndex)
        End If
    End Sub

    Private Sub Winners_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Winners.Click
        TextBox1.Text = ""
        TextBox1.Enabled = False
        OK.Enabled = False
        If Entrants.Items.Count = 1 Then
            'RichTextBox4.Text = Entrants.Items.Item(0)
            'RichTextBox5.Text = "Second Placed Winner !"
            'RichTextBox6.Text = "Third Placed Winner !"
            Label6.Text = Entrants.Items.Item(0)
            Label7.Text = "Second Placed Winner !"
            Label8.Text = "Third Placed Winner !"
        ElseIf Entrants.Items.Count = 2 Then
            Dim myrand As New Random
            Dim firstplace As Integer = myrand.Next(0, 2)
            'RichTextBox4.Text = Entrants.Items.Item(firstplace)
            Label6.Text = Entrants.Items.Item(firstplace)
            If firstplace = 0 Then
                'RichTextBox5.Text = Entrants.Items.Item(1)
                Label7.Text = Entrants.Items.Item(1)
            Else
                'RichTextBox5.Text = Entrants.Items.Item(0)
                Label7.Text = Entrants.Items.Item(0)
            End If
            'RichTextBox6.Text = "Third Placed Winner !"
            Label8.Text = "Third Placed Winner !"
        ElseIf Entrants.Items.Count = 0 Then
            'RichTextBox4.Text = "First Placed Winner !"
            'RichTextBox5.Text = "Second Placed Winner !"
            'RichTextBox6.Text = "Third Placed Winner !"
            Label6.Text = "First Placed Winner !"
            Label7.Text = "Second Placed Winner !"
            Label8.Text = "Third Placed Winner !"
        Else
            Dim myrand As New Random
            Dim firstplace As Integer = myrand.Next(0, Entrants.Items.Count)
            ' RichTextBox4.Text = Entrants.Items.Item(firstplace)
            Label6.Text = Entrants.Items.Item(firstplace)
            Dim secondplace As Integer = firstplace
            While secondplace = firstplace
                secondplace = myrand.Next(0, Entrants.Items.Count)
            End While
            'RichTextBox5.Text = Entrants.Items.Item(secondplace)
            Label7.Text = Entrants.Items.Item(secondplace)
            Dim thirdplace As Integer = secondplace
            While thirdplace = firstplace Or thirdplace = secondplace
                thirdplace = myrand.Next(0, Entrants.Items.Count)
            End While
            ' RichTextBox6.Text = Entrants.Items.Item(thirdplace)
            Label8.Text = Entrants.Items.Item(thirdplace)
        End If

    End Sub

    Private Sub Reset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Reset.Click
        TextBox1.Text = ""
        TextBox1.Enabled = False
        OK.Enabled = False
        If MsgBox("Clear entry list?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Entrants.Items.Clear()
            Label6.Text = "First Placed Winner !"
            Label7.Text = "Second Placed Winner !"
            Label8.Text = "Third Placed Winner !"
            'RichTextBox4.Text = "First Placed Winner !"
            'RichTextBox5.Text = "Second Placed Winner !"
            'RichTextBox6.Text = "Third Placed Winner !"
        End If
    End Sub

    Private Sub CompMan_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Enclosure.ToolStripButton1.Checked = False
        My.Settings.CompManXPos = Me.Location.X
        My.Settings.CompManYPos = Me.Location.Y
        My.Settings.CompManWidth = Me.Size.Width
        My.Settings.CompManHeight = Me.Size.Height
        My.Settings.Save()
    End Sub
    Private Sub CompMan_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyValue = Keys.Enter Then
            OK_Click(sender, e)
        End If
    End Sub

    Private Sub CompMan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If My.Settings.CompManHeight <> "0" And My.Settings.CompManWidth <> "0" And My.Settings.CompManXPos <> "0" And My.Settings.CompManYPos <> "0" Then
            Me.SetDesktopBounds(My.Settings.CompManXPos, My.Settings.CompManYPos, My.Settings.CompManWidth, My.Settings.CompManHeight)
        End If
    End Sub

End Class