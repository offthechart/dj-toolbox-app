Public Class TimeCalculator
    Dim pointstatus As Integer = 0

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub ButtonDot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDot.Click
        If pointstatus = 0 Then
            pointstatus = 1
        Else
            pointstatus = 0
        End If
    End Sub

    Private Sub TimeCalculator_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If My.Settings.TimeCalcHeight <> "0" And My.Settings.TimeCalcWidth <> "0" And My.Settings.TimeCalcXPos <> "0" And My.Settings.TimeCalcYPos <> "0" Then
            Me.SetDesktopBounds(My.Settings.TimeCalcXPos, My.Settings.TimeCalcYPos, My.Settings.TimeCalcWidth, My.Settings.TimeCalcHeight)
        End If
    End Sub
    Private Sub TimeCalculator_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Enclosure.ToolStripButton4.Checked = False
        My.Settings.TimeCalcXPos = Me.Location.X
        My.Settings.TimeCalcYPos = Me.Location.Y
        My.Settings.TimeCalcWidth = Me.Size.Width
        My.Settings.TimeCalcHeight = Me.Size.Height
        My.Settings.Save()
    End Sub

    Private Sub Button0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button0.Click
        If pointstatus = 0 Then
            MinutesField.Text = MinutesField.Text.Substring(1, 1) + "0"
        Else
            SecondsField.Text = SecondsField.Text.Substring(1, 1) + "0"
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If pointstatus = 0 Then
            MinutesField.Text = MinutesField.Text.Substring(1, 1) + "1"
        Else
            SecondsField.Text = SecondsField.Text.Substring(1, 1) + "1"
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If pointstatus = 0 Then
            MinutesField.Text = MinutesField.Text.Substring(1, 1) + "2"
        Else
            SecondsField.Text = SecondsField.Text.Substring(1, 1) + "2"
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If pointstatus = 0 Then
            MinutesField.Text = MinutesField.Text.Substring(1, 1) + "3"
        Else
            SecondsField.Text = SecondsField.Text.Substring(1, 1) + "3"
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If pointstatus = 0 Then
            MinutesField.Text = MinutesField.Text.Substring(1, 1) + "4"
        Else
            SecondsField.Text = SecondsField.Text.Substring(1, 1) + "4"
        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If pointstatus = 0 Then
            MinutesField.Text = MinutesField.Text.Substring(1, 1) + "5"
        Else
            SecondsField.Text = SecondsField.Text.Substring(1, 1) + "5"
        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        If pointstatus = 0 Then
            MinutesField.Text = MinutesField.Text.Substring(1, 1) + "6"
        Else
            SecondsField.Text = SecondsField.Text.Substring(1, 1) + "6"
        End If
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        If pointstatus = 0 Then
            MinutesField.Text = MinutesField.Text.Substring(1, 1) + "7"
        Else
            SecondsField.Text = SecondsField.Text.Substring(1, 1) + "7"
        End If
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        If pointstatus = 0 Then
            MinutesField.Text = MinutesField.Text.Substring(1, 1) + "8"
        Else
            SecondsField.Text = SecondsField.Text.Substring(1, 1) + "8"
        End If
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        If pointstatus = 0 Then
            MinutesField.Text = MinutesField.Text.Substring(1, 1) + "9"
        Else
            SecondsField.Text = SecondsField.Text.Substring(1, 1) + "9"
        End If
    End Sub
    
    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        MinutesField.Text = "00"
        SecondsField.Text = "00"
        pointstatus = 0
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Times.Items.Add(MinutesField.Text + ":" + SecondsField.Text)
        MinutesField.Text = "00"
        SecondsField.Text = "00"
        pointstatus = 0
        updatetotal()
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        If Times.SelectedIndex >= 0 Then
            Times.Items.RemoveAt(Times.SelectedIndex)
            updatetotal()
        End If
    End Sub
    Private Sub updatetotal()
        Dim minutes As Integer
        Dim seconds As Integer
        Dim totalsecs As Integer = 0
        Dim totalmins As Integer = 0
        Dim totalhours As Integer = 0
        Dim totaltext As String

        For Each item As String In Times.Items
            minutes = Integer.Parse(item.Substring(0, 2))
            seconds = Integer.Parse(item.Substring(3, 2))

            totalsecs = seconds + (minutes * 60) + totalsecs
        Next
        If totalsecs > 59 Then
            totalmins = Fix(totalsecs / 60)
            totalsecs = totalsecs Mod 60
        End If
        If totalmins > 59 Then
            totalhours = Fix(totalmins / 60)
            totalmins = totalmins Mod 60
        End If
        If totalsecs.ToString.Length < 2 Then
            totaltext = "0" + totalsecs.ToString
        Else
            totaltext = totalsecs.ToString
        End If
        If totalmins.ToString.Length < 2 Then
            totaltext = "0" + totalmins.ToString + ":" + totaltext
        Else
            totaltext = totalmins.ToString + ":" + totaltext
        End If
        If totalhours.ToString.Length < 2 Then
            totaltext = "0" + totalhours.ToString + ":" + totaltext
        Else
            totaltext = totalhours.ToString + ":" + totaltext
        End If
        Total.Text = totaltext
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        Times.Items.Clear()
        updatetotal()
    End Sub

    Private Sub MinutesField_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MinutesField.Click
        pointstatus = 0
        Button10.Select()
    End Sub
    Private Sub SecondsField_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SecondsField.Click
        pointstatus = 1
        Button10.Select()
    End Sub
End Class