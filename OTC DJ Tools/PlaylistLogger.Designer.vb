<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PlaylistLogger
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PlaylistLogger))
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Artist = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Title = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Mix = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Duration = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DisplayOnline = New System.Windows.Forms.DataGridViewButtonColumn
        Me.CatNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ISRC = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UsedDB = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Up = New System.Windows.Forms.DataGridViewButtonColumn
        Me.Down = New System.Windows.Forms.DataGridViewButtonColumn
        Me.SubmitNpdata = New System.ComponentModel.BackgroundWorker
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.Button5 = New System.Windows.Forms.Button
        Me.Button6 = New System.Windows.Forms.Button
        Me.Button7 = New System.Windows.Forms.Button
        Me.Button8 = New System.Windows.Forms.Button
        Me.ExportPlaylist = New System.Windows.Forms.SaveFileDialog
        Me.ImportPlaylist = New System.Windows.Forms.OpenFileDialog
        Me.AddMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.FromDatabaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ManuallyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.FromFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OpenAudioFile = New System.Windows.Forms.OpenFileDialog
        Me.UploadPL = New System.ComponentModel.BackgroundWorker
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.ComboBox2 = New System.Windows.Forms.ComboBox
        Me.Button9 = New System.Windows.Forms.Button
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.AddMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Artist, Me.Title, Me.Mix, Me.Duration, Me.DisplayOnline, Me.CatNo, Me.Label, Me.ISRC, Me.UsedDB, Me.Up, Me.Down})
        Me.DataGridView1.Location = New System.Drawing.Point(12, 12)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DataGridView1.Size = New System.Drawing.Size(509, 226)
        Me.DataGridView1.TabIndex = 0
        '
        'Artist
        '
        Me.Artist.HeaderText = "Artist"
        Me.Artist.Name = "Artist"
        Me.Artist.ReadOnly = True
        Me.Artist.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Title
        '
        Me.Title.HeaderText = "Title"
        Me.Title.Name = "Title"
        Me.Title.ReadOnly = True
        Me.Title.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Title.Width = 150
        '
        'Mix
        '
        Me.Mix.HeaderText = "Mix"
        Me.Mix.Name = "Mix"
        Me.Mix.ReadOnly = True
        Me.Mix.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Mix.Width = 110
        '
        'Duration
        '
        Me.Duration.HeaderText = "Duration"
        Me.Duration.Name = "Duration"
        Me.Duration.ReadOnly = True
        Me.Duration.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Duration.Width = 55
        '
        'DisplayOnline
        '
        Me.DisplayOnline.HeaderText = "Display Online"
        Me.DisplayOnline.Name = "DisplayOnline"
        Me.DisplayOnline.ReadOnly = True
        Me.DisplayOnline.Text = "Go"
        Me.DisplayOnline.UseColumnTextForButtonValue = True
        Me.DisplayOnline.Width = 90
        '
        'CatNo
        '
        Me.CatNo.HeaderText = "Cat No."
        Me.CatNo.Name = "CatNo"
        Me.CatNo.ReadOnly = True
        Me.CatNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Label
        '
        Me.Label.HeaderText = "Label"
        Me.Label.Name = "Label"
        Me.Label.ReadOnly = True
        Me.Label.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Label.Width = 80
        '
        'ISRC
        '
        Me.ISRC.HeaderText = "ISRC"
        Me.ISRC.Name = "ISRC"
        Me.ISRC.ReadOnly = True
        Me.ISRC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'UsedDB
        '
        Me.UsedDB.HeaderText = "Used DB"
        Me.UsedDB.Name = "UsedDB"
        Me.UsedDB.ReadOnly = True
        Me.UsedDB.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.UsedDB.Visible = False
        '
        'Up
        '
        Me.Up.HeaderText = "Move Row"
        Me.Up.Name = "Up"
        Me.Up.ReadOnly = True
        Me.Up.Text = "Up"
        Me.Up.UseColumnTextForButtonValue = True
        Me.Up.Width = 70
        '
        'Down
        '
        Me.Down.HeaderText = "Move Row"
        Me.Down.Name = "Down"
        Me.Down.ReadOnly = True
        Me.Down.Text = "Down"
        Me.Down.UseColumnTextForButtonValue = True
        Me.Down.Width = 70
        '
        'SubmitNpdata
        '
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(13, 280)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Add"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(96, 280)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Edit"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(177, 280)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 3
        Me.Button3.Text = "Remove"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(446, 280)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 6
        Me.Button4.Text = "Export"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(365, 280)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(75, 23)
        Me.Button5.TabIndex = 5
        Me.Button5.Text = "Import"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(258, 280)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(75, 23)
        Me.Button6.TabIndex = 4
        Me.Button6.Text = "Reset"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(365, 329)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(75, 23)
        Me.Button7.TabIndex = 8
        Me.Button7.Text = "Generate"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(446, 329)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(75, 23)
        Me.Button8.TabIndex = 9
        Me.Button8.Text = "Upload"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'ExportPlaylist
        '
        Me.ExportPlaylist.DefaultExt = "csv"
        Me.ExportPlaylist.Filter = "CSV Files|*.csv"
        Me.ExportPlaylist.Title = "Export Playlist"
        '
        'ImportPlaylist
        '
        Me.ImportPlaylist.Filter = "CSV Files|*.csv|Playlist Files|*.m3u; *.pls"
        Me.ImportPlaylist.Title = "Import Playlist"
        '
        'AddMenu
        '
        Me.AddMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FromDatabaseToolStripMenuItem, Me.ToolStripSeparator1, Me.ManuallyToolStripMenuItem, Me.FromFileToolStripMenuItem})
        Me.AddMenu.Name = "ContextMenuStrip1"
        Me.AddMenu.Size = New System.Drawing.Size(159, 98)
        '
        'FromDatabaseToolStripMenuItem
        '
        Me.FromDatabaseToolStripMenuItem.Name = "FromDatabaseToolStripMenuItem"
        Me.FromDatabaseToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.FromDatabaseToolStripMenuItem.Text = "From Database"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(155, 6)
        '
        'ManuallyToolStripMenuItem
        '
        Me.ManuallyToolStripMenuItem.Name = "ManuallyToolStripMenuItem"
        Me.ManuallyToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.ManuallyToolStripMenuItem.Text = "Manually"
        '
        'FromFileToolStripMenuItem
        '
        Me.FromFileToolStripMenuItem.Name = "FromFileToolStripMenuItem"
        Me.FromFileToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.FromFileToolStripMenuItem.Text = "From Audio File"
        '
        'OpenAudioFile
        '
        Me.OpenAudioFile.Filter = "MP3 Files|*.mp3|WMA Files|*.wma|AAC Files|*.aac; *.m4p; *.m4a|OGG Files|*.ogg"
        Me.OpenAudioFile.Title = "Add From Audio File"
        '
        'UploadPL
        '
        '
        'Timer1
        '
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(51, 245)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(158, 20)
        Me.DateTimePicker1.TabIndex = 10
        Me.DateTimePicker1.Value = New Date(2008, 1, 1, 0, 0, 0, 0)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 248)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Date:"
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"12am", "1am", "2am", "3am", "4am", "5am", "6am", "7am", "8am", "9am", "10am", "11am", "12pm", "1pm", "2pm", "3pm", "4pm", "5pm", "6pm", "7pm", "8pm", "9pm", "10pm", "11pm"})
        Me.ComboBox1.Location = New System.Drawing.Point(330, 245)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(72, 21)
        Me.ComboBox1.TabIndex = 11
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(291, 248)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "From:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(420, 248)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(23, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "To:"
        '
        'ComboBox2
        '
        Me.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Items.AddRange(New Object() {"12am", "1am", "2am", "3am", "4am", "5am", "6am", "7am", "8am", "9am", "10am", "11am", "12pm", "1pm", "2pm", "3pm", "4pm", "5pm", "6pm", "7pm", "8pm", "9pm", "10pm", "11pm"})
        Me.ComboBox2.Location = New System.Drawing.Point(449, 245)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(72, 21)
        Me.ComboBox2.TabIndex = 12
        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(12, 329)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(159, 23)
        Me.Button9.TabIndex = 7
        Me.Button9.Text = "Manual Now Playing Update"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'PlaylistLogger
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(534, 384)
        Me.ControlBox = False
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.ComboBox2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(990, 5000)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(550, 400)
        Me.Name = "PlaylistLogger"
        Me.ShowInTaskbar = False
        Me.Text = "Playlist Logger"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.AddMenu.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents SubmitNpdata As System.ComponentModel.BackgroundWorker
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents ExportPlaylist As System.Windows.Forms.SaveFileDialog
    Friend WithEvents ImportPlaylist As System.Windows.Forms.OpenFileDialog
    Friend WithEvents AddMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ManuallyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FromFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenAudioFile As System.Windows.Forms.OpenFileDialog
    Friend WithEvents FromDatabaseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents UploadPL As System.ComponentModel.BackgroundWorker
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Artist As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Title As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Mix As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Duration As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DisplayOnline As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents CatNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ISRC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UsedDB As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Up As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Down As System.Windows.Forms.DataGridViewButtonColumn
End Class
