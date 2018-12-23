Imports System.Environment
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports System.Data
Imports System.Drawing.Imaging



Public Class WebcamUploader
    Dim filename As String

    Private Sub WebcamUploader_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If My.Settings.WebcamHeight <> "0" And My.Settings.WebcamWidth <> "0" And My.Settings.WebcamXPos <> "0" And My.Settings.WebcamYPos <> "0" Then
            Me.SetDesktopBounds(My.Settings.WebcamXPos, My.Settings.WebcamYPos, My.Settings.WebcamWidth, My.Settings.WebcamHeight)
        End If
        LoadDeviceList()
        ComboBox1.SelectedIndex = 0
        lstDevices.SelectedIndex = 0
    End Sub
    ' Create constant using attend in function of DLL file.

    Const WM_CAP As Short = &H400S
    Const WM_CAP_DRIVER_CONNECT As Integer = WM_CAP + 10
    Const WM_CAP_DRIVER_DISCONNECT As Integer = WM_CAP + 11
    Const WM_CAP_EDIT_COPY As Integer = WM_CAP + 30
    Const WM_CAP_SET_PREVIEW As Integer = WM_CAP + 50
    Const WM_CAP_SET_PREVIEWRATE As Integer = WM_CAP + 52
    Const WM_CAP_SET_SCALE As Integer = WM_CAP + 53
    Const WS_CHILD As Integer = &H40000000
    Const WS_VISIBLE As Integer = &H10000000
    Const SWP_NOMOVE As Short = &H2S
    Const SWP_NOSIZE As Short = 1
    Const SWP_NOZORDER As Short = &H4S
    Const HWND_BOTTOM As Short = 1

    Dim iDevice As Integer = 0  ' Normal device ID 
    Dim hHwnd As Integer  ' Handle value to preview window

    ' Declare function from AVI capture DLL.

    Declare Function SendMessage Lib "user32" Alias "SendMessageA" _
        (ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer, _
         ByVal lParam As Object) As Integer

    Declare Function SetWindowPos Lib "user32" Alias "SetWindowPos" (ByVal hwnd As Integer, _
        ByVal hWndInsertAfter As Integer, ByVal x As Integer, ByVal y As Integer, _
        ByVal cx As Integer, ByVal cy As Integer, ByVal wFlags As Integer) As Integer

    Declare Function DestroyWindow Lib "user32" (ByVal hndw As Integer) As Boolean

    Declare Function capCreateCaptureWindowA Lib "avicap32.dll" _
        (ByVal lpszWindowName As String, ByVal dwStyle As Integer, _
        ByVal x As Integer, ByVal y As Integer, ByVal nWidth As Integer, _
        ByVal nHeight As Short, ByVal hWndParent As Integer, _
        ByVal nID As Integer) As Integer

    Declare Function capGetDriverDescriptionA Lib "avicap32.dll" (ByVal wDriver As Short, _
        ByVal lpszName As String, ByVal cbName As Integer, ByVal lpszVer As String, _
        ByVal cbVer As Integer) As Boolean

    ' Connect to the device.

    Private Sub LoadDeviceList()
        Dim strName As String = Space(100)
        Dim strVer As String = Space(100)
        Dim bReturn As Boolean
        Dim x As Integer = 0

        ' Load name of all avialable devices into the lstDevices .

        Do
            '   Get Driver name and version
            bReturn = capGetDriverDescriptionA(x, strName, 100, strVer, 100)
            ' If there was a device add device name to the list 
            If bReturn Then lstDevices.Items.Add(strName.Trim)
            x += 1
        Loop Until bReturn = False
    End Sub

    ' To display the output from a video capture device, you need to create a capture window.

    Private Sub OpenPreviewWindow()
        Dim iHeight As Integer = picCapture.Height
        Dim iWidth As Integer = picCapture.Width

        ' Open Preview window in picturebox .
        ' Create a child window with capCreateCaptureWindowA so you can display it in a picturebox.

        hHwnd = capCreateCaptureWindowA(iDevice, WS_VISIBLE Or WS_CHILD, 0, 0, 640, _
            480, picCapture.Handle.ToInt32, 0)

        ' Connect to device
        If SendMessage(hHwnd, WM_CAP_DRIVER_CONNECT, iDevice, 0) Then
            ' Set the preview scale
            SendMessage(hHwnd, WM_CAP_SET_SCALE, True, 0)

            ' Set the preview rate in milliseconds
            SendMessage(hHwnd, WM_CAP_SET_PREVIEWRATE, 66, 0)

            ' Start previewing the image from the camera 
            SendMessage(hHwnd, WM_CAP_SET_PREVIEW, True, 0)

            ' Resize window to fit in picturebox 
            SetWindowPos(hHwnd, HWND_BOTTOM, 0, 0, picCapture.Width, picCapture.Height, _
                                   SWP_NOMOVE Or SWP_NOZORDER)


        Else
            ' Error connecting to device close window 
            DestroyWindow(hHwnd)
            MsgBox("Could not connect to device")
            btnStart.Text = "Start Preview"
            lstDevices.Enabled = True
            Button1.Enabled = False
            ClosePreviewWindow()
        End If
    End Sub


    ' Finally, to close the preview window, disconnect from the device 
    ' and destroy the preview window. 

    Private Sub ClosePreviewWindow()
        ' Disconnect from device
        SendMessage(hHwnd, WM_CAP_DRIVER_DISCONNECT, iDevice, 0)

        ' close window 
        DestroyWindow(hHwnd)
    End Sub

    Private Sub save()
        Dim data As IDataObject
        Dim bmap As New Bitmap( _
                CInt(320), _
                CInt(240))
        Dim bmaptoresize As Bitmap
        Dim savestring As String
        Dim camtext As String = "OTC Webcam "
        Dim username As String = StrConv(My.Settings.Username, VbStrConv.ProperCase)
        ' Copy image to clipboard 
        SendMessage(hHwnd, WM_CAP_EDIT_COPY, 0, 0)

        ' Get image from clipboard and convert it to a bitmap 
        data = Clipboard.GetDataObject()
        If data.GetDataPresent(GetType(System.Drawing.Bitmap)) Then
            bmaptoresize = CType(data.GetData(GetType(System.Drawing.Bitmap)), Image)

            ' START OF RESIZE TEST
            ' Get the source bitmap.
            Dim bm_source As New Bitmap(bmaptoresize)

            ' Make a bitmap for the result.
            Dim bm_dest As New Bitmap( _
                CInt(320), _
                CInt(240))

            ' Make a Graphics object for the result Bitmap.
            Dim gr_dest As Graphics = Graphics.FromImage(bm_dest)

            ' Copy the source image into the destination bitmap.
            gr_dest.DrawImage(bm_source, 0, 0, _
                bm_dest.Width + 1, _
                bm_dest.Height + 1)

            ' Display the result.
            bmap = bm_dest
            ' END OF RESIZE TEST

            picCapture.Image = bmaptoresize
            savestring = Environment.GetFolderPath(SpecialFolder.ApplicationData)
            savestring = savestring + "\Off_The_Chart_Radio\upload"
            Dim dir As System.IO.DirectoryInfo
            dir = New System.IO.DirectoryInfo(savestring)
            If (Not dir.Exists) Then
                dir.Create()
            End If
            ClosePreviewWindow()
            If (RadioButton1.Checked = True) Then
                camtext = camtext + "1 :: " + username
                Label2.Text = camtext

                Dim FontColor As Color = Color.White
                Dim BackColor As Color = Color.Black
                Dim FontName As String = "Trebuchet MS"
                Dim FontSize As Integer = 8
                Dim Height As Integer = 21
                Dim Width As Integer = Label2.Width + 6
                Dim objBitmap As New Bitmap(Width, Height)
                Dim objGraphics As Graphics = Graphics.FromImage(objBitmap)
                Dim objFont As New Font(FontName, FontSize)
                'Following PointF object defines where the text will be displayed in the
                'specified area of the image
                Dim objPoint As New PointF(5.0F, 5.0F)
                Dim objBrushForeColor As New SolidBrush(FontColor)
                Dim objBrushBackColor As New SolidBrush(BackColor)
                objGraphics.FillRectangle(objBrushBackColor, 0, 0, Width, Height)
                objGraphics.DrawString(Label2.Text, objFont, objBrushForeColor, objPoint)
                Label2.Image = objBitmap

                Dim camtextbmap As New Bitmap(Label2.Image)
                Label2.Image = camtextbmap
                savestring = savestring + "\webcam1.jpg"
                Dim gr As Graphics = Graphics.FromImage(bmap)
                gr.DrawImage(Label2.Image, _
        (320 - Label2.Width - 5) \ 2, _
        -5)
                bmap.Save(savestring, Imaging.ImageFormat.Jpeg)
                Timer1.Stop()
                filename = savestring
                upload()
            Else
                camtext = camtext + "2 :: " + username
                Label2.Text = camtext

                Dim FontColor As Color = Color.White
                Dim BackColor As Color = Color.Black
                Dim FontName As String = "Trebuchet MS"
                Dim FontSize As Integer = 8
                Dim Height As Integer = 21
                Dim Width As Integer = Label2.Width + 6
                Dim objBitmap As New Bitmap(Width, Height)
                Dim objGraphics As Graphics = Graphics.FromImage(objBitmap)
                Dim objFont As New Font(FontName, FontSize)
                'Following PointF object defines where the text will be displayed in the
                'specified area of the image
                Dim objPoint As New PointF(5.0F, 5.0F)
                Dim objBrushForeColor As New SolidBrush(FontColor)
                Dim objBrushBackColor As New SolidBrush(BackColor)
                objGraphics.FillRectangle(objBrushBackColor, 0, 0, Width, Height)
                objGraphics.DrawString(Label2.Text, objFont, objBrushForeColor, objPoint)
                Label2.Image = objBitmap

                Dim camtextbmap As New Bitmap(Label2.Image)
                Label2.Image = camtextbmap
                savestring = savestring + "\webcam2.jpg"
                Dim gr As Graphics = Graphics.FromImage(bmap)
                gr.DrawImage(Label2.Image, _
        (320 - Label2.Width - 5) \ 2, _
        -5)
                bmap.Save(savestring, Imaging.ImageFormat.Jpeg)
                Timer1.Stop()
                filename = savestring
                upload()
            End If
            OpenPreviewWindow()


        End If
    End Sub



    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        If btnStart.Text = "Start Preview" Then
            btnStart.Text = "Stop Preview"
            lstDevices.Enabled = False
            Button1.Enabled = True
            OpenPreviewWindow()
        ElseIf btnStart.Text = "Stop Preview" Then
            ClosePreviewWindow()
            picCapture.Image = picCapture.InitialImage
            btnStart.Text = "Start Preview"
            lstDevices.Enabled = True
            Button1.Enabled = False
        End If


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Button1.Text = "Start Upload" Then
            If Login.webcam = 0 Then
                MsgBox("You are currently not set to use a webcam on the OTC site. Although uploads will work, no link will be displayed in your on air info until you enable the checkbox in the toolbox options window.")
            End If
            Button1.Text = "Stop Upload"
            btnStart.Enabled = False
            RadioButton1.Enabled = False
            RadioButton2.Enabled = False
            ComboBox1.Enabled = False
            Timer1.Enabled = True
            Timer1.Start()
        ElseIf Button1.Text = "Stop Upload" Then
            Timer2.Stop()
            Timer1.Stop()
            If BackgroundWorker1.IsBusy Then
                BackgroundWorker1.CancelAsync()
            End If
            Button1.Text = "Start Upload"
            btnStart.Enabled = True
            RadioButton1.Enabled = True
            RadioButton2.Enabled = True
            ComboBox1.Enabled = True
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Select Case ComboBox1.SelectedIndex
            Case 0
                Timer1.Interval = 5000
            Case 1
                Timer1.Interval = 10000
            Case 2
                Timer1.Interval = 15000
            Case 3
                Timer1.Interval = 20000
            Case 4
                Timer1.Interval = 25000
            Case 5
                Timer1.Interval = 30000
        End Select
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        save()
    End Sub
    Private Sub WebcamUploader_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Enclosure.ToolStripButton8.Checked = False
        My.Settings.WebcamXPos = Me.Location.X
        My.Settings.WebcamYPos = Me.Location.Y
        My.Settings.WebcamWidth = Me.Size.Width
        My.Settings.WebcamHeight = Me.Size.Height
        My.Settings.Save()
        ClosePreviewWindow()
    End Sub
    Private Sub upload()
        If Not BackgroundWorker1.IsBusy And Button1.Text = "Stop Upload" Then
            BackgroundWorker1.RunWorkerAsync()
        End If
        'If RadioButton1.Checked = True Then
        '    My.Computer.Network.UploadFile(filename, "ftp://offthechartradio.co.uk/webcam1.jpg", "username", "password")
        'Else
        '    My.Computer.Network.UploadFile(filename, "ftp://offthechartradio.co.uk/webcam2.jpg", "username", "password")
        'End If
        Timer2.Start()
    End Sub


    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            If RadioButton1.Checked = True Then
                My.Computer.Network.UploadFile(filename, "ftp://offthechartradio.co.uk/webcam1.jpg", "username", "password")
            Else
                My.Computer.Network.UploadFile(filename, "ftp://offthechartradio.co.uk/webcam2.jpg", "username", "password")
            End If
        Catch
        End Try
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Timer2.Stop()
        If BackgroundWorker1.IsBusy Then
            Timer2.Start()
        Else
            Timer1.Start()
        End If
    End Sub
End Class
