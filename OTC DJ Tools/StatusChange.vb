Public Class StatusChange
    Enum ABEdge
        ABE_LEFT = 0
        ABE_TOP
        ABE_RIGHT
        ABE_BOTTOM
    End Enum
    Private Sub StatusChange_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' If Minibar.Visible = True Then
        'Me.SetBounds(Screen.GetWorkingArea(Me).Width - Me.Width, Screen.GetWorkingArea(Me).Height - Me.Height - Minibar.Height, Me.Width, Me.Height)
        'Else
        'Me.SetBounds(Screen.GetWorkingArea(Me).Width - Me.Width, Screen.GetWorkingArea(Me).Height - Me.Height, Me.Width, Me.Height)
        'End If
        
    End Sub

   
    Private Sub StatusChange_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged
        If Visible = True Then
            'If Minibar.Visible = "true" Then
            '    If Minibar.useddock = "true" Then
            '        MsgBox("minibar visible, with dock")
            '        Me.SetBounds(Screen.GetWorkingArea(Me).Width - Me.Width, Screen.GetWorkingArea(Me).Height - Me.Height, Me.Width, Me.Height)
            '    ElseIf Minibar.useddockonce = "true" Then
            '        MsgBox("minibar visible, without dock, but dock had been used")
            '        Me.SetBounds(Screen.GetWorkingArea(Me).Width - Me.Width, Screen.GetWorkingArea(Me).Height - Me.Height, Me.Width, Me.Height)
            '    Else
            '        MsgBox("minibar visible, without dock")
            '        Me.SetBounds(Screen.GetWorkingArea(Me).Width - Me.Width, Screen.GetWorkingArea(Me).Height - Me.Height - Minibar.Height, Me.Width, Me.Height)
            '    End If
            'Else
            '    If Minibar.useddockonce = "true" Then
            '        MsgBox("minibar invisible, dock had been used")
            '        Me.SetBounds(Screen.GetWorkingArea(Me).Width - Me.Width, Screen.GetWorkingArea(Me).Height - Me.Height + Minibar.Height, Me.Width, Me.Height)
            '    Else
            '        MsgBox("minibar invisible, without dock use")
            '        Me.SetBounds(Screen.GetWorkingArea(Me).Width - Me.Width, Screen.GetWorkingArea(Me).Height - Me.Height, Me.Width, Me.Height)
            '    End If
            'End If
            If Minibar.Visible = "true" And Minibar.useddock = "false" Then
                If (Minibar.Location.Y - Me.Height) < 0 Then
                    Me.PictureBox2.Hide()
                    Me.PictureBox5.Show()
                    Me.SetBounds(Minibar.Location.X - Me.Width + Minibar.Width, Minibar.Location.Y + Minibar.Height, Me.Width, Me.Height)
                Else
                    Me.PictureBox5.Hide()
                    Me.PictureBox2.Show()
                    Me.SetBounds(Minibar.Location.X - Me.Width + Minibar.Width, Minibar.Location.Y - Me.Height, Me.Width, Me.Height)
                End If
            Else
                Me.PictureBox5.Hide()
                Me.PictureBox2.Show()
                Me.SetBounds(Screen.GetWorkingArea(Me).Width - Me.Width, Screen.GetWorkingArea(Me).Height - Me.Height, Me.Width, Me.Height)
            End If
        End If
    End Sub

    Private Sub lblEmailNotifier_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblEmailNotifier.DoubleClick
        'Minibar.Button2_Click(sender, e)
        'If DJMail.Visible = False Then

        'Enclosure.ToolStripButton7_Click(sender, e)
        'Enclosure.ToolStripButton7.Checked = True
        If Login.email = "none" Or Login.imappass = "none" Then
            MsgBox("Your account details are unavailable, please contact management")
        Else
            DJMail.Close()
            DJMail.Show()
            DJMail.ControlBox = True
            Enclosure.ToolStripButton7.Checked = True
            ' End If
            DJMail.webEmailMain.Refresh()
        End If
    End Sub

    
End Class