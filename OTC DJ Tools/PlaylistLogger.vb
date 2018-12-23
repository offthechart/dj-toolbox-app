Imports System.Net
Imports System.IO
Imports System.Environment
Imports Un4seen.Bass.AddOn
Imports Un4seen.Bass
Imports Un4seen.Bass.AddOn.Tags



Public Class PlaylistLogger

    ' use of gracenote SDK? (can also read ID3v2)

    Dim myartist As String = ""
    Dim mytitle As String = ""
    Dim mymix As String = ""
    Dim npdatatype As String = "new"
    Dim npdata As String = ""

    Dim savestring As String
    Dim uploadstring As String
    Dim uploadfile As String

    Public times As String

    Public myid3tags As TAG_INFO
    Public myfiletags

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        'Dim artist As String = DataGridView1.Item(0, Integer.Parse(DataGridView1.CurrentRow.Index.ToString)).ToString
        'Dim title As String = DataGridView1.Item(1, Integer.Parse(DataGridView1.CurrentRow.Index.ToString)).ToString
        ' update online data

        'MsgBox(artist + " - " + title)
        'MsgBox(DataGridView1.CurrentRow.Index)
        If DataGridView1.CurrentCellAddress.X = 4 Then
            
            myartist = DataGridView1.Rows(Integer.Parse(DataGridView1.CurrentRow.Index.ToString).ToString).Cells("Artist").Value
            mytitle = DataGridView1.Rows(Integer.Parse(DataGridView1.CurrentRow.Index.ToString).ToString).Cells("Title").Value
            mymix = DataGridView1.Rows(Integer.Parse(DataGridView1.CurrentRow.Index.ToString).ToString).Cells("Mix").Value
            If myartist <> "" And mytitle <> "" Then
                If Login.npdata <> "man" Then
                    MsgBox("You do not have manual now playing updates enabled. Please see the options menu to turn them on.")
                Else
                    If SubmitNpdata.IsBusy Then
                        MsgBox("Update already in progress, please wait")
                    Else
                        npdatatype = "new"
                        SubmitNpdata.RunWorkerAsync()
                    End If
                End If
            End If
        ElseIf DataGridView1.CurrentCellAddress.X = 9 Then
        'up
        myartist = DataGridView1.Rows(Integer.Parse(DataGridView1.CurrentRow.Index.ToString).ToString).Cells("Artist").Value
        If myartist <> "" Then

            If DataGridView1.CurrentRow.Index > 0 And DataGridView1.CurrentRow.Index < (DataGridView1.Rows.Count - 1) Then

                Dim oldartist As String = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells("Artist").Value
                Dim oldtitle As String = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells("Title").Value
                Dim oldmix As String = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells("Mix").Value
                Dim oldduration As String = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells("Duration").Value
                Dim oldcatno As String = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells("CatNo").Value
                Dim oldlabel As String = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells("Label").Value
                Dim oldisrc As String = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells("ISRC").Value
                DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells("Artist").Value = DataGridView1.Rows(DataGridView1.CurrentRow.Index - 1).Cells("Artist").Value
                DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells("Title").Value = DataGridView1.Rows(DataGridView1.CurrentRow.Index - 1).Cells("Title").Value
                DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells("Mix").Value = DataGridView1.Rows(DataGridView1.CurrentRow.Index - 1).Cells("Mix").Value
                DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells("Duration").Value = DataGridView1.Rows(DataGridView1.CurrentRow.Index - 1).Cells("Duration").Value
                DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells("CatNo").Value = DataGridView1.Rows(DataGridView1.CurrentRow.Index - 1).Cells("CatNo").Value
                DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells("Label").Value = DataGridView1.Rows(DataGridView1.CurrentRow.Index - 1).Cells("Label").Value
                DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells("ISRC").Value = DataGridView1.Rows(DataGridView1.CurrentRow.Index - 1).Cells("ISRC").Value
                DataGridView1.Rows(DataGridView1.CurrentRow.Index - 1).Cells("Artist").Value = oldartist
                DataGridView1.Rows(DataGridView1.CurrentRow.Index - 1).Cells("Title").Value = oldtitle
                DataGridView1.Rows(DataGridView1.CurrentRow.Index - 1).Cells("Mix").Value = oldmix
                DataGridView1.Rows(DataGridView1.CurrentRow.Index - 1).Cells("Duration").Value = oldduration
                DataGridView1.Rows(DataGridView1.CurrentRow.Index - 1).Cells("CatNo").Value = oldcatno
                DataGridView1.Rows(DataGridView1.CurrentRow.Index - 1).Cells("Label").Value = oldlabel
                DataGridView1.Rows(DataGridView1.CurrentRow.Index - 1).Cells("ISRC").Value = oldisrc

            End If
        End If
        ElseIf DataGridView1.CurrentCellAddress.X = 10 Then
        'down
        myartist = DataGridView1.Rows(Integer.Parse(DataGridView1.CurrentRow.Index.ToString).ToString).Cells("Artist").Value
        If myartist <> "" Then
            If DataGridView1.Rows.Count > (DataGridView1.CurrentRow.Index + 2) Then
                Dim oldartist As String = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells("Artist").Value
                Dim oldtitle As String = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells("Title").Value
                Dim oldmix As String = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells("Mix").Value
                Dim oldduration As String = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells("Duration").Value
                Dim oldcatno As String = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells("CatNo").Value
                Dim oldlabel As String = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells("Label").Value
                Dim oldisrc As String = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells("ISRC").Value
                DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells("Artist").Value = DataGridView1.Rows(DataGridView1.CurrentRow.Index + 1).Cells("Artist").Value
                DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells("Title").Value = DataGridView1.Rows(DataGridView1.CurrentRow.Index + 1).Cells("Title").Value
                DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells("Mix").Value = DataGridView1.Rows(DataGridView1.CurrentRow.Index + 1).Cells("Mix").Value
                DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells("Duration").Value = DataGridView1.Rows(DataGridView1.CurrentRow.Index + 1).Cells("Duration").Value
                DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells("CatNo").Value = DataGridView1.Rows(DataGridView1.CurrentRow.Index + 1).Cells("CatNo").Value
                DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells("Label").Value = DataGridView1.Rows(DataGridView1.CurrentRow.Index + 1).Cells("Label").Value
                DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells("ISRC").Value = DataGridView1.Rows(DataGridView1.CurrentRow.Index + 1).Cells("ISRC").Value
                DataGridView1.Rows(DataGridView1.CurrentRow.Index + 1).Cells("Artist").Value = oldartist
                DataGridView1.Rows(DataGridView1.CurrentRow.Index + 1).Cells("Title").Value = oldtitle
                DataGridView1.Rows(DataGridView1.CurrentRow.Index + 1).Cells("Mix").Value = oldmix
                DataGridView1.Rows(DataGridView1.CurrentRow.Index + 1).Cells("Duration").Value = oldduration
                DataGridView1.Rows(DataGridView1.CurrentRow.Index + 1).Cells("CatNo").Value = oldcatno
                DataGridView1.Rows(DataGridView1.CurrentRow.Index + 1).Cells("Label").Value = oldlabel
                DataGridView1.Rows(DataGridView1.CurrentRow.Index + 1).Cells("ISRC").Value = oldisrc

            End If
        End If
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles SubmitNpdata.DoWork
        npdata = npdata.Replace("&", "^")
        npdata = npdata.Replace("#", "`")
        myartist = myartist.Replace("&", "^")
        myartist = myartist.Replace("#", "`")
        mytitle = mytitle.Replace("&", "^")
        mytitle = mytitle.Replace("#", "`")
        mymix = mymix.Replace("&", "^")
        mymix = mymix.Replace("#", "`")
        Dim webReq As HttpWebRequest
        If npdatatype = "old" Then
            webReq = WebRequest.Create("http://www.offthechartradio.co.uk/scripts/djtools.php?u=" + Login.text1 + "&p=" + Login.text2 + "&o=npdata&a=" + npdata)
        Else
            If mymix = "" Then
                webReq = WebRequest.Create("http://www.offthechartradio.co.uk/scripts/djtools.php?u=" + Login.text1 + "&p=" + Login.text2 + "&o=npdata&a=" + myartist + "&t=" + mytitle)
            Else
                webReq = WebRequest.Create("http://www.offthechartradio.co.uk/scripts/djtools.php?u=" + Login.text1 + "&p=" + Login.text2 + "&o=npdata&a=" + myartist + "&t=" + mytitle + " (" + mymix + ")")
            End If
        End If
        Dim webResp As HttpWebResponse = webReq.GetResponse()
        Dim dataStream As Stream = webResp.GetResponseStream
        Dim streamRead As New StreamReader(dataStream)
        Dim strdata As String = streamRead.ReadToEnd()
        If strdata = "ErrorCode1" Then
            MsgBox("Incorrect username or password, please log in again")
        ElseIf strdata = "ErrorCode2" Then
            MsgBox("Your account is disabled, please contact management")
        ElseIf strdata = "ErrorCode3" Then
            MsgBox("Error Code 3 - Please contact management quoting this number")
        ElseIf strdata = "ErrorCode4" Then
            MsgBox("Error Code 4 - Please contact management quoting this number")
        ElseIf strdata = "ErrorCode5" Then
            MsgBox("Database unavailable, update failure")
        ElseIf InStr(strdata, "success") <> "0" Then
            npdata = npdata.Replace("^", "&")
            myartist = myartist.Replace("^", "&")
            mytitle = mytitle.Replace("^", "&")
            mymix = mymix.Replace("^", "&")
            npdata = npdata.Replace("`", "#")
            myartist = myartist.Replace("`", "#")
            mytitle = mytitle.Replace("`", "#")
            mymix = mymix.Replace("`", "#")
            If npdatatype = "old" Then
                MsgBox("Now playing data updated successfully with " + npdata)
            Else
                If mymix = "" Then
                    MsgBox("Now playing data updated successfully with " + mytitle + " by " + myartist)
                Else
                    MsgBox("Now playing data updated successfully with " + mytitle + " (" + mymix + ")" + " by " + myartist)
                End If
            End If
        Else
            MsgBox("Update failed, please try again. If the system continually fails please contact management")
        End If
    End Sub

    Private Sub PlaylistLogger_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Me.DragDrop
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim filePaths As String() = CType(e.Data.GetData(DataFormats.FileDrop), String())
            For Each fileLoc As String In filePaths
                ' Code to read the contents of the text file
                If File.Exists(fileLoc) Then
                    Using tr As TextReader = New StreamReader(fileLoc)
                        MessageBox.Show(tr.ReadToEnd())
                    End Using
                End If

            Next fileLoc
        End If
    End Sub

    Private Sub PlaylistLogger_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Me.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub




    Private Sub PlaylistLogger_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        autorecoversave()
        Bass.BASS_Free()
        PlaylistLogger_Gen.Close()
        PlaylistLogger_Manual.Close()
        PlaylistLogger_Search.Close()
        PlaylistLogger_Select.Close()
        Enclosure.ToolStripButton6.Checked = False
        My.Settings.PlayLogXPos = Me.Location.X
        My.Settings.PlayLogYPos = Me.Location.Y
        My.Settings.PlayLogWidth = Me.Size.Width
        My.Settings.PlayLogHeight = Me.Size.Height
        If (InStr(DateTimePicker1.Value.ToString, ":")) Then
            'My.Settings.PlayLogDate = DateTimePicker1.Value.ToString.Substring(0, 10)
            Dim myarray As Array = DateTimePicker1.Value.ToString.Split(" ")
            My.Settings.PlayLogDate = myarray(0)
        Else
            My.Settings.PlayLogDate = DateTimePicker1.Value.ToString
        End If
        My.Settings.PlayLogTime1 = ComboBox1.SelectedIndex
        My.Settings.PlayLogTime2 = ComboBox2.SelectedIndex
        My.Settings.Save()
    End Sub

    Private Sub PlaylistLogger_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If My.Settings.PlayLogHeight <> "0" And My.Settings.PlayLogWidth <> "0" And My.Settings.PlayLogXPos <> "0" And My.Settings.PlayLogYPos <> "0" Then
            Me.SetDesktopBounds(My.Settings.PlayLogXPos, My.Settings.PlayLogYPos, My.Settings.PlayLogWidth, My.Settings.PlayLogHeight)
        End If
        If (My.Settings.PlayLogDate <> "") And (Not My.Settings.PlayLogDate Is Nothing) Then
            Try
                DateTimePicker1.Value = My.Settings.PlayLogDate
            Catch
            End Try
        End If
        If (My.Settings.PlayLogTime1 <> "") And (Not My.Settings.PlayLogTime1 Is Nothing) Then
            ComboBox1.SelectedIndex = My.Settings.PlayLogTime1
        Else
            ComboBox1.SelectedIndex = 0
        End If
        If (My.Settings.PlayLogTime2 <> "") And (Not My.Settings.PlayLogTime2 Is Nothing) Then
            ComboBox2.SelectedIndex = My.Settings.PlayLogTime2
        Else
            ComboBox2.SelectedIndex = 0
        End If
        Call Bass.BASS_Init(1, 44100, BASSInit.BASS_DEVICE_DEFAULT, Nothing, Nothing)
        If Login.manualnp <> "true" Then
            Button9.Enabled = False
        End If
        autorecoveropen()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        If MsgBox("Are you sure you want to clear the current playlist?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            DataGridView1.Rows.Clear()
        End If
        autorecoversave()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            If DataGridView1.Rows.Count > 1 Then
                DataGridView1.Rows.RemoveAt(DataGridView1.CurrentRow.Index)
            End If
        Catch
            ' no rows selected
        End Try
        autorecoversave()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        ImportPlaylist.ShowDialog()

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        ExportPlaylist.ShowDialog()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'PlaylistLogger_Search.Show()

        AddMenu.Show(MousePosition.X, MousePosition.Y)

    End Sub

    Private Sub ManuallyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ManuallyToolStripMenuItem.Click
        PlaylistLogger_Manual.Show()
    End Sub

    Private Sub FromFileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FromFileToolStripMenuItem.Click
        OpenAudioFile.ShowDialog()
    End Sub

    Private Sub OpenAudioFile_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles OpenAudioFile.FileOk
        ' Filename reading
        Dim filenameparts As Array = OpenAudioFile.FileName.Split("\")
        Dim filename As String = filenameparts(filenameparts.Length - 1)
        filename = filename.Remove(filename.Length - 4, 4)
        If InStr(filename, "~") Then
            Dim chararray() As Char = {"~"}
            Dim infoarray As Array = filename.Split(chararray, 2)
            infoarray(0) = infoarray(0).ToString.Trim("~")
            infoarray(0) = infoarray(0).ToString.Trim(" ")
            infoarray(1) = infoarray(1).ToString.Trim("~")
            infoarray(1) = infoarray(1).ToString.Trim(" ")
            ' MsgBox("Artist: " + infoarray(0) + " - " + "Title: " + infoarray(1))
            myfiletags = infoarray
        ElseIf InStr(filename, "-") Then
            Dim chararray() As Char = {"-"}
            Dim infoarray As Array = filename.Split(chararray, 2)
            infoarray(0) = infoarray(0).ToString.Trim("-")
            infoarray(0) = infoarray(0).ToString.Trim(" ")
            infoarray(1) = infoarray(1).ToString.Trim("-")
            infoarray(1) = infoarray(1).ToString.Trim(" ")
            '   MsgBox("Artist: " + infoarray(0) + " - " + "Title: " + infoarray(1))
            myfiletags = infoarray
        Else
            myfiletags = filename
            ' MsgBox("Artist: " + filename)
        End If

        'Tag Reading
        myid3tags = BassTags.BASS_TAG_GetFromFile(OpenAudioFile.FileName, False, True)


        PlaylistLogger_Select.Show()
    End Sub

    Private Sub SaveFileDialog1_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ExportPlaylist.FileOk
        'Dim streamwriter As New StreamWriter()
        'while more lines available
        '    streamwriter.WriteLine()
        'End While
        generatecsv(False)
        Try
            savestring = Environment.GetFolderPath(SpecialFolder.ApplicationData)
            savestring = savestring + "\Off_The_Chart_Radio\playlistlog"
            Dim dir As System.IO.DirectoryInfo
            dir = New System.IO.DirectoryInfo(savestring)
            If (Not dir.Exists) Then
                dir.Create()
            End If
            savestring = savestring + "\autorecover.csv"
            If (Not File.Exists(savestring)) Then
                Dim sw As StreamWriter = File.CreateText(savestring)
                sw.Close()
            End If
            Dim recovereddata As String = File.ReadAllText(savestring)

            If recovereddata.Length > 0 Then
                Dim sw As StreamWriter = File.CreateText(ExportPlaylist.FileName)
                sw.Write(recovereddata)
                sw.Close()
            End If
        Catch ex As Exception
            MsgBox("Failed to save file. Please check the chosen folder is writeable and try again.")
        End Try
    End Sub

    Private Sub OpenPlaylistFile_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ImportPlaylist.FileOk
        Dim doimport As Boolean = False

        If DataGridView1.Rows.Count > 1 Then
            If MsgBox("This will clear the current playlist, are you sure you want to continue?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                doimport = True
            End If
        Else
            doimport = True
        End If

        If doimport = True Then
            Try
                If ImportPlaylist.FileName.ToLower.EndsWith(".csv") Or ImportPlaylist.FileName.ToLower.EndsWith(".pls") Or ImportPlaylist.FileName.ToLower.EndsWith(".m3u") Then
                    Dim streamread As New StreamReader(ImportPlaylist.OpenFile())
                    Dim strdata As String = streamread.ReadToEnd()
                    streamread.Close()
                    If ImportPlaylist.FileName.ToLower.EndsWith(".csv") Then
                        opencsv(strdata)
                    ElseIf ImportPlaylist.FileName.ToLower.EndsWith(".pls") Then
                        openpls(strdata)
                    ElseIf ImportPlaylist.FileName.ToLower.EndsWith(".m3u") Then
                        openm3u(strdata)
                    End If
                End If
            Catch
                MsgBox("Error processing file, please ensure you have permission to read this file and try again")
            End Try
        End If
        autorecoversave()
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        If DataGridView1.Rows.Count > 1 Then
            If ComboBox1.SelectedIndex <> ComboBox2.SelectedIndex And DateTimePicker1.Value <> "01/01/2008" Then

                Enabled = False
                generatecsv(True)



            Else
                MsgBox("Please select the correct date and times for your show from the dropdowns and try again.")
            End If
        End If
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        PlaylistLogger_Gen.Show()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ' if database entered
        ' PlaylistLogger_Search.Show()
        ' else
        ' PlaylistLogger_Manual.Show()
        Try
            If DataGridView1.Rows(Integer.Parse(DataGridView1.CurrentRow.Index.ToString).ToString).Cells("UsedDB").Value <> "true" Then
                If DataGridView1.Rows(Integer.Parse(DataGridView1.CurrentRow.Index.ToString).ToString).Cells("Artist").Value <> "" Then
                    PlaylistLogger_Manual.plartist = DataGridView1.Rows(Integer.Parse(DataGridView1.CurrentRow.Index.ToString).ToString).Cells("Artist").Value
                    PlaylistLogger_Manual.pltitle = DataGridView1.Rows(Integer.Parse(DataGridView1.CurrentRow.Index.ToString).ToString).Cells("Title").Value
                    PlaylistLogger_Manual.plversion = DataGridView1.Rows(Integer.Parse(DataGridView1.CurrentRow.Index.ToString).ToString).Cells("Mix").Value
                    PlaylistLogger_Manual.plduration = DataGridView1.Rows(Integer.Parse(DataGridView1.CurrentRow.Index.ToString).ToString).Cells("Duration").Value
                    PlaylistLogger_Manual.plcatno = DataGridView1.Rows(Integer.Parse(DataGridView1.CurrentRow.Index.ToString).ToString).Cells("CatNo").Value
                    PlaylistLogger_Manual.pllabel = DataGridView1.Rows(Integer.Parse(DataGridView1.CurrentRow.Index.ToString).ToString).Cells("Label").Value
                    PlaylistLogger_Manual.plisrc = DataGridView1.Rows(Integer.Parse(DataGridView1.CurrentRow.Index.ToString).ToString).Cells("ISRC").Value
                    PlaylistLogger_Manual.Show()
                End If
            Else
                MsgBox("This entry appears to have been made using the PPL database and so cannot be edited manually")
            End If
        Catch
            ' no row was selected
        End Try
    End Sub

    Private Sub autorecoversave()
        Try

            savestring = Environment.GetFolderPath(SpecialFolder.ApplicationData)
            savestring = savestring + "\Off_The_Chart_Radio\playlistlog"
            Dim dir As System.IO.DirectoryInfo
            dir = New System.IO.DirectoryInfo(savestring)
            If (Not dir.Exists) Then
                dir.Create()
            End If
            savestring = savestring + "\autorecover.csv"
            If (Not File.Exists(savestring)) Then
                Dim sw As StreamWriter = File.CreateText(savestring)
                sw.Close()
            End If

            'If DataGridView1.Rows.Count > 1 Then
            ' Save recovery data
            generatecsv(False)

            'End If
        Catch
            MsgBox("Failed to save auto recovery information, in the event of a program crash you may lose this playlist. Please contact management for assistance")
        End Try
    End Sub

    Private Sub autorecoveropen()
        Try

            savestring = Environment.GetFolderPath(SpecialFolder.ApplicationData)
            savestring = savestring + "\Off_The_Chart_Radio\playlistlog"
            Dim dir As System.IO.DirectoryInfo
            dir = New System.IO.DirectoryInfo(savestring)
            If (Not dir.Exists) Then
                dir.Create()
            End If
            savestring = savestring + "\autorecover.csv"
            If (Not File.Exists(savestring)) Then
                Dim sw As StreamWriter = File.CreateText(savestring)
                sw.Close()
            End If
            Dim recovereddata As String = File.ReadAllText(savestring)

            If recovereddata.Length > 0 Then
                opencsv(recovereddata)
            End If
        Catch
            MsgBox("Failed to open your previous playlist file, please contact management for assistance")
        End Try
    End Sub

    Private Sub generatecsv(ByVal upload As Boolean)
        'Enabled = False

        ' generate csv, save locally as backup, then upload to server
        Dim datestring2 As String
        If DateTimePicker1.Value.Day.ToString.Length = 1 Then
            datestring2 = "0" + DateTimePicker1.Value.Day.ToString
        Else
            datestring2 = DateTimePicker1.Value.Day.ToString
        End If
        If DateTimePicker1.Value.Month.ToString.Length = 1 Then
            datestring2 = datestring2 + "/0" + DateTimePicker1.Value.Month.ToString
        Else
            datestring2 = datestring2 + "/" + DateTimePicker1.Value.Month.ToString
        End If
        datestring2 = datestring2 + "/" + DateTimePicker1.Value.Year.ToString
        Dim mycsvstring As String = StrConv(My.Settings.Username, VbStrConv.ProperCase) + "," + ComboBox1.SelectedItem + "-" + ComboBox2.SelectedItem + "," + datestring2 + vbNewLine
        mycsvstring = mycsvstring + "Artist,Title,Mix/Version,Duration,CatNo,Label,ISRC" + vbNewLine

        Dim numrows As Integer = DataGridView1.Rows.Count
        Dim currentrow As Integer = 0
        Dim mystring As String

        While currentrow < (numrows - 1)
            If InStr(DataGridView1.Rows(currentrow).Cells("Artist").Value, """") Then
                mystring = DataGridView1.Rows(currentrow).Cells("Artist").Value
                mycsvstring = mycsvstring + """" + mystring.Replace("""", """""") + """" + ","
            ElseIf InStr(DataGridView1.Rows(currentrow).Cells("Artist").Value, ",") Then
                mycsvstring = mycsvstring + """" + DataGridView1.Rows(currentrow).Cells("Artist").Value + """" + ","
            Else
                mycsvstring = mycsvstring + DataGridView1.Rows(currentrow).Cells("Artist").Value + ","
            End If
            If InStr(DataGridView1.Rows(currentrow).Cells("Title").Value, """") Then
                mystring = DataGridView1.Rows(currentrow).Cells("Title").Value
                mycsvstring = mycsvstring + """" + mystring.Replace("""", """""") + """" + ","
            ElseIf InStr(DataGridView1.Rows(currentrow).Cells("Title").Value, ",") Then
                mycsvstring = mycsvstring + """" + DataGridView1.Rows(currentrow).Cells("Title").Value + """" + ","
            Else
                mycsvstring = mycsvstring + DataGridView1.Rows(currentrow).Cells("Title").Value + ","
            End If
            If InStr(DataGridView1.Rows(currentrow).Cells("Mix").Value, """") Then
                mystring = DataGridView1.Rows(currentrow).Cells("Mix").Value
                mycsvstring = mycsvstring + """" + mystring.Replace("""", """""") + """" + ","
            ElseIf InStr(DataGridView1.Rows(currentrow).Cells("Mix").Value, ",") Then
                mycsvstring = mycsvstring + """" + DataGridView1.Rows(currentrow).Cells("Mix").Value + """" + ","
            Else
                mycsvstring = mycsvstring + DataGridView1.Rows(currentrow).Cells("Mix").Value + ","
            End If
            If InStr(DataGridView1.Rows(currentrow).Cells("Duration").Value, """") Then
                mystring = DataGridView1.Rows(currentrow).Cells("Duration").Value
                mycsvstring = mycsvstring + """" + mystring.Replace("""", """""") + """" + ","
            ElseIf InStr(DataGridView1.Rows(currentrow).Cells("Duration").Value, ",") Then
                mycsvstring = mycsvstring + """" + DataGridView1.Rows(currentrow).Cells("Duration").Value + """" + ","
            Else
                mycsvstring = mycsvstring + DataGridView1.Rows(currentrow).Cells("Duration").Value + ","
            End If
            If InStr(DataGridView1.Rows(currentrow).Cells("CatNo").Value, """") Then
                mystring = DataGridView1.Rows(currentrow).Cells("CatNo").Value
                mycsvstring = mycsvstring + """" + mystring.Replace("""", """""") + """" + ","
            ElseIf InStr(DataGridView1.Rows(currentrow).Cells("CatNo").Value, ",") Then
                mycsvstring = mycsvstring + """" + DataGridView1.Rows(currentrow).Cells("CatNo").Value + """" + ","
            Else
                mycsvstring = mycsvstring + DataGridView1.Rows(currentrow).Cells("CatNo").Value + ","
            End If
            If InStr(DataGridView1.Rows(currentrow).Cells("Label").Value, """") Then
                mystring = DataGridView1.Rows(currentrow).Cells("Label").Value
                mycsvstring = mycsvstring + """" + mystring.Replace("""", """""") + """" + ","
            ElseIf InStr(DataGridView1.Rows(currentrow).Cells("Label").Value, ",") Then
                mycsvstring = mycsvstring + """" + DataGridView1.Rows(currentrow).Cells("Label").Value + """" + ","
            Else
                mycsvstring = mycsvstring + DataGridView1.Rows(currentrow).Cells("Label").Value + ","
            End If
            If InStr(DataGridView1.Rows(currentrow).Cells("ISRC").Value, """") Then
                mystring = DataGridView1.Rows(currentrow).Cells("ISRC").Value
                mycsvstring = mycsvstring + """" + mystring.Replace("""", """""") + """" + ","
            ElseIf InStr(DataGridView1.Rows(currentrow).Cells("ISRC").Value, ",") Then
                mycsvstring = mycsvstring + """" + DataGridView1.Rows(currentrow).Cells("ISRC").Value + """" + vbNewLine
            Else
                mycsvstring = mycsvstring + DataGridView1.Rows(currentrow).Cells("ISRC").Value + vbNewLine
            End If
            currentrow = currentrow + 1
        End While

        'MsgBox(mycsvstring)
        ' if boolean true, save as backup with proper filename then upload
        ' if boolean false, save as auto recover and don't upload
        If upload = True Then
            ' check for durations being present and other fields
            ' required are artist title and duration
            Dim cancontinue As Boolean = True

            Dim goodrowcount As Integer = DataGridView1.Rows.Count - 1
            Dim mycounter As Integer = 0
            While mycounter < goodrowcount
                If DataGridView1.Rows(mycounter).Cells("Artist").Value = "" Or DataGridView1.Rows(mycounter).Cells("Artist").Value = " " Then
                    cancontinue = False
                End If
                If DataGridView1.Rows(mycounter).Cells("Title").Value = "" Then
                    cancontinue = False
                End If
                If DataGridView1.Rows(mycounter).Cells("Duration").Value = "" Or (DataGridView1.Rows(mycounter).Cells("Duration").Value = "0" And DataGridView1.Rows(mycounter).Cells("ISRC").Value = "" And DataGridView1.Rows(mycounter).Cells("UsedDB").Value = "false") Then
                    cancontinue = False
                End If
                mycounter = mycounter + 1
            End While

            If cancontinue = True Then
                If MsgBox("You are about to upload a playlist for " + DateTimePicker1.Value.ToShortDateString + " between " + ComboBox1.SelectedItem + " and " + ComboBox2.SelectedItem + ". Are you sure this correct?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Try

                        uploadstring = Environment.GetFolderPath(SpecialFolder.ApplicationData)
                        uploadstring = uploadstring + "\Off_The_Chart_Radio\playlistlog"
                        Dim dir As System.IO.DirectoryInfo
                        dir = New System.IO.DirectoryInfo(uploadstring)
                        If (Not dir.Exists) Then
                            dir.Create()
                        End If
                        Dim datestring As String = DateTimePicker1.Value.Year.ToString
                        If DateTimePicker1.Value.Month.ToString.Length = 1 Then
                            datestring = datestring + "-0" + DateTimePicker1.Value.Month.ToString
                        Else
                            datestring = datestring + "-" + DateTimePicker1.Value.Month.ToString
                        End If
                        If DateTimePicker1.Value.Day.ToString.Length = 1 Then
                            datestring = datestring + "-0" + DateTimePicker1.Value.Day.ToString
                        Else
                            datestring = datestring + "-" + DateTimePicker1.Value.Day.ToString
                        End If
                        uploadstring = uploadstring + "\" + datestring + "_" + ComboBox1.SelectedItem + "-" + ComboBox2.SelectedItem + "_" + StrConv(My.Settings.Username, VbStrConv.ProperCase) + ".csv"

                        Dim sw As StreamWriter = File.CreateText(uploadstring)
                        sw.Write(mycsvstring)
                        sw.Close()

                        uploadfile = datestring + "_" + ComboBox1.SelectedItem + "-" + ComboBox2.SelectedItem + "_" + StrConv(My.Settings.Username, VbStrConv.ProperCase) + ".csv"
                        UploadPL.RunWorkerAsync()
                        Timer1.Start()
                    Catch
                        MsgBox("Failed to generate playlist. Please contact management for assistance.")
                        Enabled = True
                    End Try
                Else
                    MsgBox("Upload aborted, please modify your show times and upload again.")
                    Enabled = True
                End If
            Else
                MsgBox("You have not filled in all of the required artist/title/duration fields, or a duration is zero. The upload was stopped.")
                Enabled = True
            End If
        Else
            Try
                Dim sw As StreamWriter = File.CreateText(savestring)
                sw.Write(mycsvstring)
                sw.Close()
            Catch
                MsgBox("Failed to save auto recovery information, in the event of a program crash you may lose this playlist. Please contact management for assistance")
            End Try
            'Enabled = True
        End If
    End Sub


    Private Sub PlaylistLogger_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        DataGridView1.Width = Me.Width - 41
        DataGridView1.Height = Me.Height - 174
        ComboBox1.Location = New System.Drawing.Point(Me.Width - 220, Me.Height - 155)
        ComboBox2.Location = New System.Drawing.Point(Me.Width - 101, Me.Height - 155)
        Button4.Location = New System.Drawing.Point(Me.Width - 104, Me.Height - 120)
        Button8.Location = New System.Drawing.Point(Me.Width - 104, Me.Height - 71)
        Button5.Location = New System.Drawing.Point(Me.Width - 185, Me.Height - 120)
        Button7.Location = New System.Drawing.Point(Me.Width - 185, Me.Height - 71)
        Label3.Location = New System.Drawing.Point(Me.Width - 130, Me.Height - 152)
        Label2.Location = New System.Drawing.Point(Me.Width - 259, Me.Height - 152)
        Label1.Location = New System.Drawing.Point(Label1.Location.X, Me.Height - 152)
        DateTimePicker1.Location = New System.Drawing.Point(DateTimePicker1.Location.X, Me.Height - 155)
        Button1.Location = New System.Drawing.Point(Button1.Location.X, Me.Height - 120)
        Button2.Location = New System.Drawing.Point(Button2.Location.X, Me.Height - 120)
        Button3.Location = New System.Drawing.Point(Button3.Location.X, Me.Height - 120)
        Button6.Location = New System.Drawing.Point(Button6.Location.X, Me.Height - 120)
        Button9.Location = New System.Drawing.Point(Button9.Location.X, Me.Height - 71)
    End Sub

    Private Sub PlaylistLogger_ResizeEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ResizeEnd
        DataGridView1.Width = Me.Width - 41
        DataGridView1.Height = Me.Height - 174
        ComboBox1.Location = New System.Drawing.Point(Me.Width - 220, Me.Height - 155)
        ComboBox2.Location = New System.Drawing.Point(Me.Width - 101, Me.Height - 155)
        Button4.Location = New System.Drawing.Point(Me.Width - 104, Me.Height - 120)
        Button8.Location = New System.Drawing.Point(Me.Width - 104, Me.Height - 71)
        Button5.Location = New System.Drawing.Point(Me.Width - 185, Me.Height - 120)
        Button7.Location = New System.Drawing.Point(Me.Width - 185, Me.Height - 71)
        Label3.Location = New System.Drawing.Point(Me.Width - 130, Me.Height - 152)
        Label2.Location = New System.Drawing.Point(Me.Width - 259, Me.Height - 152)
        Label1.Location = New System.Drawing.Point(Label1.Location.X, Me.Height - 152)
        DateTimePicker1.Location = New System.Drawing.Point(DateTimePicker1.Location.X, Me.Height - 155)
        Button1.Location = New System.Drawing.Point(Button1.Location.X, Me.Height - 120)
        Button2.Location = New System.Drawing.Point(Button2.Location.X, Me.Height - 120)
        Button3.Location = New System.Drawing.Point(Button3.Location.X, Me.Height - 120)
        Button6.Location = New System.Drawing.Point(Button6.Location.X, Me.Height - 120)
        Button9.Location = New System.Drawing.Point(Button9.Location.X, Me.Height - 71)
    End Sub

    Private Sub PlaylistLogger_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged
        If Visible = False Then
            PlaylistLogger_Gen.Close()
            PlaylistLogger_Manual.Close()
            PlaylistLogger_Search.Close()
            PlaylistLogger_Select.Close()
        End If
    End Sub

    Private Sub UploadPL_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles UploadPL.DoWork
        '  Enabled = True ' may not work in bgworker
        'Try
        '    Dim userstring As String = StrConv(My.Settings.Username, VbStrConv.ProperCase)
        '    userstring = userstring.Replace(" ", "%20")
        '    Dim uploadloc As String = "ftp://offthechartradio.co.uk/%2f" + userstring + "/%2f" + uploadfile
        '    'MsgBox(uploadstring)
        '    MsgBox(uploadloc)
        '    ' NEED TO GET IT TO CREATE A DIR
        '    My.Computer.Network.UploadFile(uploadstring, uploadloc, "pllogger@offthechartradio.com", "password")
        '    MsgBox("Playlist uploaded successfully. Don't forget to use the Generate button to get your forum style playlist")
        'Catch ex As Exception
        '    MsgBox("Playlist upload failed. Please contact management for assistance." + ex.ToString)
        'End Try

        Try
            Dim userstring As String = StrConv(My.Settings.Username, VbStrConv.ProperCase)
            'userstring = userstring.Replace(" ", "%20")
            Dim clsRequest As System.Net.FtpWebRequest
            Dim uploadloc As String
            Dim myresponse As WebResponse

            uploadloc = "ftp://offthechartradio.co.uk"
            clsRequest = _
            DirectCast(System.Net.WebRequest.Create(uploadloc), System.Net.FtpWebRequest)
            clsRequest.Credentials = New System.Net.NetworkCredential("pllogger@offthechartradio.com", "password")
            clsRequest.Proxy = Nothing
            clsRequest.KeepAlive = True
            clsRequest.Method = System.Net.WebRequestMethods.Ftp.ListDirectory
            clsRequest.UsePassive = True
            myresponse = clsRequest.GetResponse()
            Dim mystream As New StreamReader(myresponse.GetResponseStream())
            Dim mydata As String = mystream.ReadToEnd
            mystream.Close()
            mystream.Dispose()
            'MsgBox(mydata)

            If InStr(mydata, userstring) Then
                'MsgBox("it's there")
            Else
                'MsgBox("making folder")
                uploadloc = "ftp://offthechartradio.co.uk/" + userstring
                clsRequest = _
                DirectCast(System.Net.WebRequest.Create(uploadloc), System.Net.FtpWebRequest)
                clsRequest.Credentials = New System.Net.NetworkCredential("pllogger@offthechartradio.com", "password")
                clsRequest.Proxy = Nothing
                clsRequest.Method = System.Net.WebRequestMethods.Ftp.MakeDirectory
                clsRequest.UsePassive = True
                myresponse = clsRequest.GetResponse()
            End If

            'MsgBox("uploading file")
            uploadloc = "ftp://offthechartradio.co.uk/" + userstring + "/" + uploadfile
            clsRequest = DirectCast(System.Net.WebRequest.Create(uploadloc), System.Net.FtpWebRequest)
            clsRequest.Credentials = New System.Net.NetworkCredential("pllogger@offthechartradio.com", "password")
            clsRequest.Proxy = Nothing
            clsRequest.Method = System.Net.WebRequestMethods.Ftp.UploadFile
            clsRequest.UsePassive = True
            clsRequest.KeepAlive = False
            ' read in file...
            Dim bFile() As Byte = System.IO.File.ReadAllBytes(uploadstring)
            ' upload file...
            Dim clsStream As System.IO.Stream = _
            clsRequest.GetRequestStream()
            clsStream.Write(bFile, 0, bFile.Length)
            clsStream.Close()
            clsStream.Dispose()
            MsgBox("Playlist uploaded successfully. Don't forget to use the Generate button to get your forum style playlist")
        Catch ex As Exception
            MsgBox("Playlist upload failed. Please contact management for assistance." + ex.ToString)
        End Try
    End Sub

    Private Sub FromDatabaseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FromDatabaseToolStripMenuItem.Click
        PlaylistLogger_Search.Show()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If Not UploadPL.IsBusy Then
            Enabled = True
            Timer1.Stop()
        End If
    End Sub


    Public Sub generatetimes()
        If ComboBox1.SelectedIndex.ToString.Length = 1 Then
            times = "0" + ComboBox1.SelectedIndex.ToString + ":00 - "
        Else
            times = ComboBox1.SelectedIndex.ToString + ":00 - "
        End If
        If ComboBox2.SelectedIndex.ToString.Length = 1 Then
            times = times + "0" + ComboBox2.SelectedIndex.ToString + ":00"
        Else
            times = times + ComboBox2.SelectedIndex.ToString + ":00"
        End If
    End Sub

    Public Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        If Login.npdata <> "man" Then
            MsgBox("You do not have manual now playing updates enabled. Please see the options menu to turn them on.")
        Else
            npdata = InputBox("Please enter your update below in the format specified in the forums." + vbNewLine + vbNewLine + "Generally: 'Title (Mix) by Artist'")
            If npdata <> "" Then
                ' update online
                If Not SubmitNpdata.IsBusy Then
                    npdatatype = "old"
                    SubmitNpdata.RunWorkerAsync()
                Else
                    MsgBox("Update already in progress, please wait")
                End If
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        If DataGridView1.Rows.Count > 1 Then
            autorecoversave()
        End If
        ' DataGridView1.ScrollBars = ScrollBars.None
        ' DataGridView1.ScrollBars = ScrollBars.Both
        DataGridView1.AutoResizeRows()
    End Sub

    Private Sub opencsv(ByVal data As String)
        If InStr(data, "Label,ISRC") Then
            DataGridView1.Rows.Clear()
            data = data.Replace(vbNewLine, "|")
            Dim separator As Char() = {"|"}
            Dim dataarray As Array = data.Split(separator, StringSplitOptions.RemoveEmptyEntries)
            Dim mycount As Integer = 2
            If ((dataarray.Length - 2) > 0) Then
                DataGridView1.Rows.Add(dataarray.Length - 2)
            End If
            While mycount < dataarray.Length
                Dim rowarray As String()
                Dim newseparator As Char() = {","}
                Dim splitstring As Char() = {""""}
                dataarray(mycount) = dataarray(mycount).ToString.Replace("""""""", """|")
                dataarray(mycount) = dataarray(mycount).ToString.Replace("""""", "|")
                If dataarray(mycount).ToString.StartsWith("""") Then
                    rowarray = dataarray(mycount).ToString.Split(splitstring, 2, StringSplitOptions.RemoveEmptyEntries)
                    ' rowarray(0) = rowarray(0).Remove(0, 1)
                    rowarray(0) = rowarray(0).Replace("|", """")
                    DataGridView1.Rows(mycount - 2).Cells("Artist").Value = rowarray(0)
                    dataarray(mycount) = rowarray(1).ToString.Remove(0, 1)
                Else
                    rowarray = dataarray(mycount).ToString.Split(newseparator, 2)
                    DataGridView1.Rows(mycount - 2).Cells("Artist").Value = rowarray(0)
                    dataarray(mycount) = rowarray(1)
                End If

                If dataarray(mycount).ToString.StartsWith("""") Then
                    rowarray = dataarray(mycount).ToString.Split(splitstring, 2, StringSplitOptions.RemoveEmptyEntries)
                    ' rowarray(0) = rowarray(0).Remove(0, 1)
                    rowarray(0) = rowarray(0).Replace("|", """")
                    DataGridView1.Rows(mycount - 2).Cells("Title").Value = rowarray(0)
                    dataarray(mycount) = rowarray(1).ToString.Remove(0, 1)
                Else
                    rowarray = dataarray(mycount).ToString.Split(newseparator, 2)
                    DataGridView1.Rows(mycount - 2).Cells("Title").Value = rowarray(0)
                    dataarray(mycount) = rowarray(1)
                End If

                If dataarray(mycount).ToString.StartsWith("""") Then
                    rowarray = dataarray(mycount).ToString.Split(splitstring, 2, StringSplitOptions.RemoveEmptyEntries)
                    ' rowarray(0) = rowarray(0).Remove(0, 1)
                    rowarray(0) = rowarray(0).Replace("|", """")
                    DataGridView1.Rows(mycount - 2).Cells("Mix").Value = rowarray(0)
                    dataarray(mycount) = rowarray(1).ToString.Remove(0, 1)
                Else
                    rowarray = dataarray(mycount).ToString.Split(newseparator, 2)
                    DataGridView1.Rows(mycount - 2).Cells("Mix").Value = rowarray(0)
                    dataarray(mycount) = rowarray(1)
                End If

                If dataarray(mycount).ToString.StartsWith("""") Then
                    rowarray = dataarray(mycount).ToString.Split(splitstring, 2, StringSplitOptions.RemoveEmptyEntries)
                    ' rowarray(0) = rowarray(0).Remove(0, 1)
                    rowarray(0) = rowarray(0).Replace("|", """")
                    DataGridView1.Rows(mycount - 2).Cells("Duration").Value = rowarray(0)
                    dataarray(mycount) = rowarray(1).ToString.Remove(0, 1)
                Else
                    rowarray = dataarray(mycount).ToString.Split(newseparator, 2)
                    DataGridView1.Rows(mycount - 2).Cells("Duration").Value = rowarray(0)
                    dataarray(mycount) = rowarray(1)
                End If

                If dataarray(mycount).ToString.StartsWith("""") Then
                    rowarray = dataarray(mycount).ToString.Split(splitstring, 2, StringSplitOptions.RemoveEmptyEntries)
                    ' rowarray(0) = rowarray(0).Remove(0, 1)
                    rowarray(0) = rowarray(0).Replace("|", """")
                    DataGridView1.Rows(mycount - 2).Cells("CatNo").Value = rowarray(0)
                    dataarray(mycount) = rowarray(1).ToString.Remove(0, 1)
                Else
                    rowarray = dataarray(mycount).ToString.Split(newseparator, 2)
                    DataGridView1.Rows(mycount - 2).Cells("CatNo").Value = rowarray(0)
                    dataarray(mycount) = rowarray(1)
                End If

                If dataarray(mycount).ToString.StartsWith("""") Then
                    rowarray = dataarray(mycount).ToString.Split(splitstring, 2, StringSplitOptions.RemoveEmptyEntries)
                    ' rowarray(0) = rowarray(0).Remove(0, 1)
                    rowarray(0) = rowarray(0).Replace("|", """")
                    DataGridView1.Rows(mycount - 2).Cells("Label").Value = rowarray(0)
                    dataarray(mycount) = rowarray(1).ToString.Remove(0, 1)
                Else
                    rowarray = dataarray(mycount).ToString.Split(newseparator, 2)
                    DataGridView1.Rows(mycount - 2).Cells("Label").Value = rowarray(0)
                    dataarray(mycount) = rowarray(1)
                End If

                If dataarray(mycount).ToString.StartsWith("""") Then
                    rowarray = dataarray(mycount).ToString.Split(splitstring, 2, StringSplitOptions.RemoveEmptyEntries)
                    ' rowarray(0) = rowarray(0).Remove(0, 1)
                    rowarray(0) = rowarray(0).Replace("|", """")
                    DataGridView1.Rows(mycount - 2).Cells("ISRC").Value = rowarray(0)
                Else
                    DataGridView1.Rows(mycount - 2).Cells("ISRC").Value = dataarray(mycount).ToString
                End If

                If DataGridView1.Rows(mycount - 2).Cells("CatNo").Value <> "" Or DataGridView1.Rows(mycount - 2).Cells("Label").Value <> "" Or DataGridView1.Rows(mycount - 2).Cells("ISRC").Value <> "" Then
                    DataGridView1.Rows(mycount - 2).Cells("UsedDB").Value = "true"
                Else
                    DataGridView1.Rows(mycount - 2).Cells("UsedDB").Value = "false"
                End If

                mycount = mycount + 1
            End While
        Else
            MsgBox("This is not a valid DJ Toolbox version 2 csv file")
        End If
    End Sub
    Private Sub openpls(ByVal data As String)
        If InStr(data, "[playlist]") Then
            DataGridView1.Rows.Clear()
            Dim splitter As String() = {"NumberOfEntries="}
            Dim countarray As String() = data.Split(splitter, 2, StringSplitOptions.None)
            countarray = countarray(1).Split(vbNewLine)
            Dim count As Integer = Integer.Parse(countarray(0))
            DataGridView1.Rows.Add(count)
            Dim currentfile As Integer = 1
            While currentfile <= count
                Dim mystring As String = "Title" + currentfile.ToString + "="
                Dim splitter2 As String() = {mystring}
                Dim dataarray As String() = data.Split(splitter2, 2, StringSplitOptions.None)
                dataarray = dataarray(1).Split(vbNewLine)
                If InStr(dataarray(0), "~") Then
                    Dim chararray() As Char = {"~"}
                    Dim infoarray As Array = dataarray(0).Split(chararray, 2)
                    infoarray(0) = infoarray(0).ToString.Trim("~")
                    infoarray(0) = infoarray(0).ToString.Trim(" ")
                    infoarray(1) = infoarray(1).ToString.Trim("~")
                    infoarray(1) = infoarray(1).ToString.Trim(" ")
                    DataGridView1.Rows(currentfile - 1).Cells("Artist").Value = infoarray(0)
                    DataGridView1.Rows(currentfile - 1).Cells("Title").Value = infoarray(1)
                ElseIf InStr(dataarray(0), "-") Then
                    Dim chararray() As Char = {"-"}
                    Dim infoarray As Array = dataarray(0).Split(chararray, 2)
                    infoarray(0) = infoarray(0).ToString.Trim("-")
                    infoarray(0) = infoarray(0).ToString.Trim(" ")
                    infoarray(1) = infoarray(1).ToString.Trim("-")
                    infoarray(1) = infoarray(1).ToString.Trim(" ")
                    DataGridView1.Rows(currentfile - 1).Cells("Artist").Value = infoarray(0)
                    DataGridView1.Rows(currentfile - 1).Cells("Title").Value = infoarray(1)
                Else
                    DataGridView1.Rows(currentfile - 1).Cells("Artist").Value = dataarray(0)
                End If
                mystring = "Length" + currentfile.ToString + "="
                Dim splitter3 As String() = {mystring}
                Dim dataarray2 As String() = data.Split(splitter3, 2, StringSplitOptions.None)
                dataarray2 = dataarray2(1).Split(vbNewLine)
                If Integer.Parse(dataarray2(0).ToString) > 0 Then
                    DataGridView1.Rows(currentfile - 1).Cells("Duration").Value = dataarray2(0)
                End If
                DataGridView1.Rows(currentfile - 1).Cells("UsedDB").Value = "false"
                currentfile = currentfile + 1
            End While
        Else
            MsgBox("This is not a valid pls playlist file")
        End If
    End Sub
    Private Sub openm3u(ByVal data As String)
        If InStr(data, "#EXTM3U") Then
            DataGridView1.Rows.Clear()
            Dim splitter As String() = {"#EXTINF:"}
            Dim moredata As Boolean = True
            Dim testarray As String() = data.Split(splitter, StringSplitOptions.None)
            Dim count As Integer = testarray.Length - 1
            DataGridView1.Rows.Add(count)
            Dim currentrow As Integer = 0
            While moredata = True
                Dim dataarray As String() = data.Split(splitter, 2, StringSplitOptions.RemoveEmptyEntries)
                'MsgBox(dataarray(1))
                dataarray = dataarray(1).Split(",", 2, StringSplitOptions.None)
                'MsgBox(dataarray(0))
                If Integer.Parse(dataarray(0).ToString) > 0 Then
                    DataGridView1.Rows(currentrow).Cells("Duration").Value = dataarray(0)
                End If
                'MsgBox(dataarray(1))
                If InStr(dataarray(1), "#EXTINF:") Then
                    Dim newarray As String() = dataarray(1).Split(splitter, 2, StringSplitOptions.RemoveEmptyEntries)
                    data = "randomchar #EXTINF:" + newarray(1)
                Else
                    moredata = False
                End If
                dataarray = dataarray(1).Split(vbNewLine)
                If InStr(dataarray(0), "~") Then
                    Dim chararray() As Char = {"~"}
                    Dim infoarray As Array = dataarray(0).Split(chararray, 2)
                    infoarray(0) = infoarray(0).ToString.Trim("~")
                    infoarray(0) = infoarray(0).ToString.Trim(" ")
                    infoarray(1) = infoarray(1).ToString.Trim("~")
                    infoarray(1) = infoarray(1).ToString.Trim(" ")
                    DataGridView1.Rows(currentrow).Cells("Artist").Value = infoarray(0)
                    DataGridView1.Rows(currentrow).Cells("Title").Value = infoarray(1)
                ElseIf InStr(dataarray(0), "-") Then
                    Dim chararray() As Char = {"-"}
                    Dim infoarray As Array = dataarray(0).Split(chararray, 2)
                    infoarray(0) = infoarray(0).ToString.Trim("-")
                    infoarray(0) = infoarray(0).ToString.Trim(" ")
                    infoarray(1) = infoarray(1).ToString.Trim("-")
                    infoarray(1) = infoarray(1).ToString.Trim(" ")
                    DataGridView1.Rows(currentrow).Cells("Artist").Value = infoarray(0)
                    DataGridView1.Rows(currentrow).Cells("Title").Value = infoarray(1)
                Else
                    DataGridView1.Rows(currentrow).Cells("Artist").Value = dataarray(0)
                End If
                DataGridView1.Rows(currentrow).Cells("UsedDB").Value = "false"
                count = count - 1
                currentrow = currentrow + 1
                If count = 0 Then
                    moredata = False
                End If
            End While
        Else
            MsgBox("This is not a valid m3u playlist file")
        End If
    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        If DateTimePicker1.Value.ToString <> "01/01/2008" And DateTimePicker1.Value.ToString <> "01/01/2008 00:00:00" Then
            If (InStr(DateTimePicker1.Value.ToString, ":")) Then
                My.Settings.PlayLogDate = DateTimePicker1.Value.ToString.Substring(0, 10)
            Else
                My.Settings.PlayLogDate = DateTimePicker1.Value.ToString
            End If
            My.Settings.Save()
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        My.Settings.PlayLogTime1 = ComboBox1.SelectedIndex
        My.Settings.Save()
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        My.Settings.PlayLogTime2 = ComboBox2.SelectedIndex
        My.Settings.Save()
    End Sub

End Class
