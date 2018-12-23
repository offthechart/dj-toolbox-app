
Imports System.Runtime.InteropServices
Public Class Minibar
    Public minibarpos As String

    Dim hhstatus As Integer
    Dim plstatus As Integer
    Dim tcstatus As Integer

    ' Dim timecalcstatus As Integer
    ' Dim prstatus As Integer
    ' Dim cmstatus As Integer
    Dim dmstatus As Integer
    ' Dim wustatus As Integer
    Public useddock As String
    Public useddockonce As String = "false"
    Private mPrevPos As New Point
    Private mPrevPos2 As New Point

#Region " AppBar "
    <StructLayout(LayoutKind.Sequential)> Structure RECT
        Public left As Integer
        Public top As Integer
        Public right As Integer
        Public bottom As Integer
    End Structure
    <StructLayout(LayoutKind.Sequential)> Structure APPBARDATA
        Public cbSize As Integer
        Public hWnd As IntPtr
        Public uCallbackMessage As Integer
        Public uEdge As Integer
        Public rc As RECT
        Public lParam As IntPtr
    End Structure
    Enum ABMsg
        ABM_NEW = 0
        ABM_REMOVE = 1
        ABM_QUERYPOS = 2
        ABM_SETPOS = 3
        ABM_GETSTATE = 4
        ABM_GETTASKBARPOS = 5
        ABM_ACTIVATE = 6
        ABM_GETAUTOHIDEBAR = 7
        ABM_SETAUTOHIDEBAR = 8
        ABM_WINDOWPOSCHANGED = 9
        ABM_SETSTATE = 10
    End Enum
    Enum ABNotify
        ABN_STATECHANGE = 0
        ABN_POSCHANGED
        ABN_FULLSCREENAPP
        ABN_WINDOWARRANGE
    End Enum
    Enum ABEdge
        ABE_LEFT = 0
        ABE_TOP
        ABE_RIGHT
        ABE_BOTTOM
    End Enum
    Private fBarRegistered As Boolean = False
    <DllImport("SHELL32", CallingConvention:=CallingConvention.StdCall)> _
    Public Shared Function SHAppBarMessage(ByVal dwMessage As Integer, ByRef BarrData As APPBARDATA) As Integer
    End Function
    <DllImport("USER32")> _
    Public Shared Function GetSystemmetric(ByVal Index As Integer) As Integer
    End Function
    <DllImport("User32.dll", ExactSpelling:=True, CharSet:=System.Runtime.InteropServices.CharSet.Auto)> _
    Public Shared Function MoveWindow(ByVal hWnd As IntPtr, ByVal x As Integer, ByVal y As Integer, ByVal cX As Integer, ByVal cY As Integer, ByVal repaint As Boolean) As Boolean
    End Function
    <DllImport("User32.dll", CharSet:=CharSet.Auto)> _
    Public Shared Function RegisterWindowMessage(ByVal msg As String) As Integer
    End Function
    Private uCallBack As Integer

    Private Sub RegisterBar()
        Dim abd As New APPBARDATA
        Dim ret As Integer
        abd.cbSize = Marshal.SizeOf(abd)
        abd.hWnd = Me.Handle
        If Not fBarRegistered Then
            uCallBack = RegisterWindowMessage("AppBarMessage")
            abd.uCallbackMessage = uCallBack

            ret = SHAppBarMessage(ABMsg.ABM_NEW, abd)
            fBarRegistered = True

            ABSetPos()
        Else
            ret = SHAppBarMessage(ABMsg.ABM_REMOVE, abd)
            fBarRegistered = False
        End If
    End Sub

    Private Sub ABSetPos()
        Dim abd As New APPBARDATA
        abd.cbSize = Marshal.SizeOf(abd)
        abd.hWnd = Me.Handle
        abd.uEdge = minibarpos

        If abd.uEdge = ABEdge.ABE_LEFT OrElse abd.uEdge = ABEdge.ABE_RIGHT Then
            abd.rc.top = 0
            abd.rc.bottom = SystemInformation.PrimaryMonitorSize.Height
            If abd.uEdge = ABEdge.ABE_LEFT Then
                abd.rc.left = 0
                abd.rc.right = Size.Width
            Else
                abd.rc.right = SystemInformation.PrimaryMonitorSize.Width
                abd.rc.left = abd.rc.right - Size.Width
            End If
        Else
            abd.rc.left = 0
            abd.rc.right = SystemInformation.PrimaryMonitorSize.Width
            If abd.uEdge = ABEdge.ABE_TOP Then
                abd.rc.top = 0
                abd.rc.bottom = 36
            Else
                abd.rc.bottom = SystemInformation.PrimaryMonitorSize.Height
                abd.rc.top = abd.rc.bottom - 36
            End If
        End If

        'Query the system for an approved size and position.
        SHAppBarMessage(ABMsg.ABM_QUERYPOS, abd)

        'Adjust the rectangle, depending on the edge to which the appbar is anchored.
        Select Case abd.uEdge
            Case ABEdge.ABE_LEFT
                abd.rc.right = abd.rc.left + Size.Width
            Case ABEdge.ABE_RIGHT
                abd.rc.left = abd.rc.right - Size.Width
            Case ABEdge.ABE_TOP
                abd.rc.bottom = abd.rc.top + 36
            Case ABEdge.ABE_BOTTOM
                abd.rc.top = abd.rc.bottom - 36
        End Select


        'Pass the final bounding rectangle to the system.
        SHAppBarMessage(ABMsg.ABM_SETPOS, abd)

        'Move and size the appbar so that it conforms to the  bounding rectangle passed to the system.
        MoveWindow(abd.hWnd, abd.rc.left, abd.rc.top, abd.rc.right - abd.rc.left, abd.rc.bottom - abd.rc.top, True)
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
    End Sub

#End Region


    Private Sub Minibar_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mPrevPos = New Point
        mPrevPos2 = New Point
        If My.Settings.DockMinibar = "true" Then
            RegisterBar()
            FormBorderStyle = Windows.Forms.FormBorderStyle.None
            useddock = "true"
            useddockonce = "true"
            Height = Height + 24
            Width = Width + 6
        Else
            FormBorderStyle = Windows.Forms.FormBorderStyle.None
            useddock = "false"
            'Width = Screen.PrimaryScreen.Bounds.Width + 6
            'Height = 55
            'Location = New System.Drawing.Point(0, Screen.GetWorkingArea(Me).Height - 55)
            If My.Settings.MinibarWidth <> 0 Then
                Me.SetBounds(My.Settings.MinibarXPos, My.Settings.MinibarYPos, My.Settings.MinibarWidth, 36)
            Else
                Me.SetBounds(0, Screen.GetWorkingArea(Me).Height - 36, Screen.GetWorkingArea(Me).Width, 36)
            End If

            'Location.X = Screen.PrimaryScreen.WorkingArea.Left
            'Location.Y = Screen.PrimaryScreen.WorkingArea.Bottom + 50
        End If
        If HandoverHelper.Visible = True Then
            hhstatus = 1
        Else
            hhstatus = 0
            HandoverHelper.MdiParent = Enclosure
            HandoverHelper.Show()
        End If
        If PlaylistLogger.Visible = True Then
            plstatus = 1
        Else
            plstatus = 0
            PlaylistLogger.MdiParent = Enclosure
            PlaylistLogger.Show()
        End If
        If TOTHClock.Visible = True Then
            tcstatus = 1
        Else
            tcstatus = 0
            TOTHClock.MdiParent = Enclosure
            TOTHClock.Show()
            If My.Settings.TCHeight <> "0" And My.Settings.TCWidth <> "0" And My.Settings.TCXPos <> "0" And My.Settings.TCYPos <> "0" Then
                TOTHClock.SetDesktopBounds(My.Settings.TCXPos, My.Settings.TCYPos, My.Settings.TCWidth, My.Settings.TCHeight)
            End If
        End If
        If Login.manualnp <> "true" Then
            ManualNowPlayingUpdateToolStripMenuItem.Enabled = False
        End If
        Enclosure.Hide()

    End Sub

   
    Private Sub Minibar_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        My.Settings.MinibarWidth = Me.Width
        My.Settings.MinibarXPos = Me.Location.X
        My.Settings.MinibarYPos = Me.Location.Y
        My.Settings.Save()
    End Sub

    

    Public Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ' PlaylistLogger.MdiParent = Enclosure
        ' PlaylistLogger.ControlBox = False
        PlaylistLogger.MdiParent = Enclosure
        PlaylistLogger.ShowInTaskbar = False
        PlaylistLogger_Manual.MdiParent = Enclosure
        PlaylistLogger_Search.MdiParent = Enclosure
        DJMail.MdiParent = Enclosure
        DJMail.ControlBox = False
        If useddock = "true" Then
            RegisterBar()
        End If
        Enclosure.Show()
        MinibarExtra.Close()
        Me.Close()
        FormBorderStyle = Windows.Forms.FormBorderStyle.FixedToolWindow
        If hhstatus = 0 Then
            HandoverHelper.Close()
        End If
        If plstatus = 0 Then
            My.Settings.PlayLogXPos = PlaylistLogger.Location.X
            My.Settings.PlayLogYPos = PlaylistLogger.Location.Y
            My.Settings.PlayLogWidth = PlaylistLogger.Size.Width
            My.Settings.PlayLogHeight = PlaylistLogger.Size.Height
            My.Settings.Save()
            PlaylistLogger.Hide()
        End If
        If tcstatus = 0 Then
            My.Settings.TCXPos = TOTHClock.Location.X
            My.Settings.TCYPos = TOTHClock.Location.Y
            My.Settings.TCWidth = TOTHClock.Size.Width
            My.Settings.TCHeight = TOTHClock.Size.Height
            My.Settings.Save()
            TOTHClock.Hide()
        End If
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If useddock = "true" Then
            RegisterBar()
        End If
        Enclosure.Show()
        MinibarExtra.Close()
        Me.Close()
        FormBorderStyle = Windows.Forms.FormBorderStyle.FixedToolWindow
        Enclosure.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        HandoverHelper.Button1_Click(sender, e)
    End Sub



    Private Sub TableLayoutPanel1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TableLayoutPanel1.MouseMove
        If useddock = "false" Then
            Dim delta As New Size(e.X - mPrevPos.X, e.Y - mPrevPos.Y)
            If (e.Button = MouseButtons.Left) Then
                Me.Location += delta
                If StatusChange.Visible = True Then
                    StatusChange.Location += delta
                End If
                If MinibarExtra.Visible = True Then
                    MinibarExtra.Location += delta
                End If
                mPrevPos = e.Location - delta
            Else
                mPrevPos = e.Location
            End If
        End If
    End Sub

    Private Sub PictureBox1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseMove
        If useddock = "false" Then
            Dim delta As New Size(e.X - mPrevPos2.X, e.Y - mPrevPos2.Y)
            If (e.Button = MouseButtons.Left) Then
                Me.Location += New Point(delta.Width, 0)
                Me.Width -= delta.Width
                'MsgBox((Me.Width + delta.Width).ToString)
                mPrevPos2 = e.Location - delta
            Else
                mPrevPos2 = e.Location
            End If
        End If
    End Sub

    Private Sub Button4_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button4.MouseDown
        MinibarExtra.Show()
    End Sub

    Private Sub Button4_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button4.MouseUp
        MinibarExtra.Hide()
    End Sub

    Private Sub lblEmailCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblEmailCheck.DoubleClick
        'Button2_Click(sender, e)
        ' If DJMail.Visible = False Then
        ' Enclosure.ToolStripButton7_Click(sender, e)
        'Enclosure.ToolStripButton7.Checked = True
        If Login.email = "none" Or Login.imappass = "none" Then
            MsgBox("Your account details are unavailable, please contact management")
        Else
            DJMail.Close()

            DJMail.Show()
            DJMail.ControlBox = True

            Enclosure.ToolStripButton7.Checked = True
            'End If
            DJMail.webEmailMain.Refresh()
        End If
    End Sub

   
    Private Sub TableLayoutPanel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles TableLayoutPanel1.Paint

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        ContextMenuStrip1.Show(MousePosition.X, MousePosition.Y)
    End Sub

 

    Private Sub AToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AToolStripMenuItem.Click
        PlaylistLogger.OpenAudioFile.ShowDialog()
    End Sub

    Private Sub AddManuallyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddManuallyToolStripMenuItem.Click
        PlaylistLogger_Manual.Show()
        PlaylistLogger_Manual.MdiParent = Nothing
    End Sub

    Private Sub CancelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelToolStripMenuItem.Click
        ContextMenuStrip1.Close()
    End Sub

    Private Sub ManualNowPlayingUpdateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ManualNowPlayingUpdateToolStripMenuItem.Click
        PlaylistLogger.Button9_Click(sender, e)
    End Sub

    Private Sub ViewLoggerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewLoggerToolStripMenuItem.Click
        If Not PlaylistLogger.MdiParent Is Nothing Then
            PlaylistLogger.MdiParent = Nothing
            PlaylistLogger.ShowInTaskbar = True
            PlaylistLogger.Show()
            PlaylistLogger.SetDesktopBounds(My.Settings.PlayLogXPos, My.Settings.PlayLogYPos, My.Settings.PlayLogWidth, My.Settings.PlayLogHeight)
            ViewLoggerToolStripMenuItem.Text = "Hide Logger"
        Else
            My.Settings.PlayLogXPos = PlaylistLogger.Location.X
            My.Settings.PlayLogYPos = PlaylistLogger.Location.Y
            My.Settings.PlayLogWidth = PlaylistLogger.Size.Width
            My.Settings.PlayLogHeight = PlaylistLogger.Size.Height
            My.Settings.Save()
            PlaylistLogger.MdiParent = Enclosure
            PlaylistLogger.ShowInTaskbar = False
            ViewLoggerToolStripMenuItem.Text = "View Logger"
        End If
    End Sub

    Private Sub AddFromDatabaseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddFromDatabaseToolStripMenuItem.Click
        PlaylistLogger_Search.Show()
        PlaylistLogger_Search.MdiParent = Nothing
    End Sub
End Class