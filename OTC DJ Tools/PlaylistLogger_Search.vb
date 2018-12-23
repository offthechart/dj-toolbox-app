Public Class PlaylistLogger_Search

    Private Sub PlaylistLogger_Search_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        PlaylistLogger.Enabled = True
        My.Settings.PPLXPos = Me.Location.X
        My.Settings.PPLYPos = Me.Location.Y
        My.Settings.PPLWidth = Me.Size.Width
        My.Settings.PPLHeight = Me.Size.Height
        My.Settings.Save()
    End Sub

    Private Sub PlaylistLogger_Search_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Minibar.Visible = False Then
            MdiParent = Enclosure
        End If
        If My.Settings.PPLHeight <> "0" And My.Settings.PPLWidth <> "0" And My.Settings.PPLXPos <> "0" And My.Settings.PPLYPos <> "0" Then
            Me.SetDesktopBounds(My.Settings.PPLXPos, My.Settings.PPLYPos, My.Settings.PPLWidth, My.Settings.PPLHeight)
        End If
        PlaylistLogger.Enabled = False
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Close()
    End Sub

    Private Sub WebBrowser1_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        If WebBrowser1.DocumentText.Contains("No Main Artists and/or Recording title matches") Then
            ComboBox1.Items.Clear()
        ElseIf WebBrowser1.DocumentText.Contains("Too many results were found") Then
            ComboBox1.Items.Clear()
        ElseIf (WebBrowser1.Url.ToString.Contains("rssearch.jsp")) Then
            ComboBox1.Items.Clear()
            WebBrowser1.Stop()
            Dim mystring As String = WebBrowser1.DocumentText
            Dim myarray As String() = mystring.Split(New String() {"<tr align=""left"">"}, StringSplitOptions.RemoveEmptyEntries)
            mystring = myarray(0) + "<tr align=""left""><td rowspan=""2"" class=""duration""><b>Index</b></td>" + myarray(1)
            myarray = mystring.Split(New String() {"<td class=""artistName"">"}, StringSplitOptions.RemoveEmptyEntries)
            Dim mytext1 As String = "<td class=""duration"">"
            Dim mytext2 As String = "</td>"
            Dim mynum As Integer = 0
            mystring = myarray(0)
            While (mynum < (myarray.Length - 1))
                mynum = mynum + 1
                mystring = mystring + mytext1 + "OTC" + mynum.ToString + mytext2 + "<td class=""artistName"">" + myarray(mynum)
            End While
            mystring = mystring.Replace("../", "http://repdb.ppluk.com:8090/AudioRepertoireSearch/")
            mystring = mystring.Replace("rssearch.jsp", "http://repdb.ppluk.com:8090/AudioRepertoireSearch/web/rssearch.jsp")
            mystring = mystring.Replace("ascat", "dontshow")
            mystring = mystring.Replace("<b><a href=""serviceCategoryDescription.html"" style=""color : #0000CC"">Licensed Uses</a></b>", "")
            mystring = mystring.Replace("<script src=""http://repdb.ppluk.com:8090/AudioRepertoireSearch/js/tooltip.js"" type=""text/javascript""></script>", "")
            mystring = mystring.Replace("<script src=""http://repdb.ppluk.com:8090/AudioRepertoireSearch/js/sort.js"" type=""text/javascript""></script>", "")
            mystring = mystring.Replace("&#039;", "'")
            mystring = mystring.Replace("&amp;", "&")
            WebBrowser1.DocumentText = mystring
            mynum = myarray.Length - 1
            Dim actualnum As Integer = 1
            While mynum > 0
                ComboBox1.Items.Add(actualnum.ToString)
                actualnum = actualnum + 1
                mynum = mynum - 1
            End While
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If ComboBox1.SelectedIndex < 0 Then
            MsgBox("Please select an item index from the dropdown box")
        Else
            selectitem()
            Close()
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If ComboBox1.SelectedIndex < 0 Then
            MsgBox("Please select an item index from the dropdown box")
        Else
            selectitem()
            ComboBox1.Items.Clear()
            WebBrowser1.Url = New System.Uri("http://repdb.ppluk.com:8090/AudioRepertoireSearch/web/home.jsp?value=var1")
        End If
    End Sub
    Private Sub selectitem()
        
        Dim mytext As String = WebBrowser1.DocumentText
        Dim myarray As String() = mytext.Split(New String() {"OTC" + (ComboBox1.SelectedIndex + 1).ToString}, StringSplitOptions.RemoveEmptyEntries)
        mytext = myarray(1)
        myarray = mytext.Split(New String() {"OTC" + (ComboBox1.SelectedIndex + 2).ToString}, StringSplitOptions.RemoveEmptyEntries)
        mytext = myarray(0)

        Dim temparray As String() = mytext.Split(New String() {"<td class=""artistName"">"}, StringSplitOptions.RemoveEmptyEntries)
        Dim myartist As String = temparray(1)
        temparray = myartist.Split(New String() {"</td>"}, StringSplitOptions.RemoveEmptyEntries)
        myartist = temparray(0)

        temparray = mytext.Split(New String() {"<td class=""rTitle"">"}, StringSplitOptions.RemoveEmptyEntries)
        Dim mytitle As String = temparray(1)
        temparray = mytitle.Split(New String() {"</td>"}, StringSplitOptions.RemoveEmptyEntries)
        mytitle = temparray(0)

        temparray = mytext.Split(New String() {"<td class=""isrc"">"}, StringSplitOptions.RemoveEmptyEntries)
        Dim myisrc As String = temparray(1)
        temparray = myisrc.Split(New String() {"</td>"}, StringSplitOptions.RemoveEmptyEntries)
        myisrc = temparray(0)

        temparray = mytext.Split(New String() {"<td class=""rights"">"}, StringSplitOptions.RemoveEmptyEntries)
        Dim myrights As String = temparray(1)
        temparray = myrights.Split(New String() {"</td>"}, StringSplitOptions.RemoveEmptyEntries)
        myrights = temparray(0)

        temparray = mytext.Split(New String() {"<td class=""duration"">"}, StringSplitOptions.RemoveEmptyEntries)
        Dim myduration As String = temparray(1)
        temparray = myduration.Split(New String() {"</td>"}, StringSplitOptions.RemoveEmptyEntries)
        myduration = temparray(0)
        myduration = myduration.Trim()

        myduration = myduration.Replace("sec", "")
        temparray = myduration.Split(":")
        Dim mymins As String = temparray(0)
        Dim mysecs As String = temparray(1)

        myduration = (Integer.Parse(mysecs) + (Integer.Parse(mymins) * 60))

        myartist = StrConv(myartist, VbStrConv.ProperCase)

        PlaylistLogger.DataGridView1.Rows(PlaylistLogger.DataGridView1.Rows.Add).SetValues(myartist, mytitle, "", myduration, "", "", myrights, myisrc, "true")

    End Sub

    Private Sub PlaylistLogger_Search_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        WebBrowser1.Width = Me.Width - 40
        WebBrowser1.Height = Me.Height - 89
        Button1.Location = New System.Drawing.Point(Me.Width - 103, Me.Height - 71)
        Button2.Location = New System.Drawing.Point(Me.Width - 253, Me.Height - 71)
        Button3.Location = New System.Drawing.Point(Me.Width - 411, Me.Height - 71)
        ComboBox1.Location = New System.Drawing.Point(Me.Width - 497, Me.Height - 69)
        Label1.Location = New System.Drawing.Point(Me.Width - 539, Me.Height - 66)
    End Sub

    Private Sub PlaylistLogger_Search_ResizeEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ResizeEnd
        WebBrowser1.Width = Me.Width - 40
        WebBrowser1.Height = Me.Height - 89
        Button1.Location = New System.Drawing.Point(Me.Width - 103, Me.Height - 71)
        Button2.Location = New System.Drawing.Point(Me.Width - 253, Me.Height - 71)
        Button3.Location = New System.Drawing.Point(Me.Width - 411, Me.Height - 71)
        ComboBox1.Location = New System.Drawing.Point(Me.Width - 497, Me.Height - 69)
        Label1.Location = New System.Drawing.Point(Me.Width - 539, Me.Height - 66)
    End Sub
End Class
