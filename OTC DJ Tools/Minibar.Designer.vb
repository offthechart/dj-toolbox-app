<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Minibar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Minibar))
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Button3 = New System.Windows.Forms.Button
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Button4 = New System.Windows.Forms.Button
        Me.lblEmailCheck = New System.Windows.Forms.Label
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.PictureBox4 = New System.Windows.Forms.PictureBox
        Me.PictureBox5 = New System.Windows.Forms.PictureBox
        Me.Button5 = New System.Windows.Forms.Button
        Me.timerEmail = New System.Windows.Forms.Timer(Me.components)
        Me.timerEmail2 = New System.Windows.Forms.Timer(Me.components)
        Me.timerProblem = New System.Windows.Forms.Timer(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ViewLoggerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.AddFromDatabaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.AToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AddManuallyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.ManualNowPlayingUpdateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.CancelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(855, 4)
        Me.Button2.Name = "Button2"
        Me.TableLayoutPanel1.SetRowSpan(Me.Button2, 2)
        Me.Button2.Size = New System.Drawing.Size(69, 23)
        Me.Button2.TabIndex = 0
        Me.Button2.Text = "Restore"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(930, 4)
        Me.Button1.Name = "Button1"
        Me.TableLayoutPanel1.SetRowSpan(Me.Button1, 2)
        Me.Button1.Size = New System.Drawing.Size(69, 24)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Exit"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(402, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(209, 17)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Syncing with server..."
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(402, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(209, 17)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Syncing with server..."
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(780, 4)
        Me.Button3.Name = "Button3"
        Me.TableLayoutPanel1.SetRowSpan(Me.Button3, 2)
        Me.Button3.Size = New System.Drawing.Size(69, 23)
        Me.Button3.TabIndex = 3
        Me.Button3.Text = "Reconnect"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AllowDrop = True
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 15
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.00062!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.00062!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.99813!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 215.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.00062!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 9.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.PictureBox1, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 7, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 7, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Button3, 11, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Button2, 12, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Button4, 9, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblEmailCheck, 5, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.PictureBox2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.PictureBox3, 14, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Button1, 13, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.PictureBox4, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.PictureBox5, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Button5, 10, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.AddColumns
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 17.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 17.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1012, 36)
        Me.TableLayoutPanel1.TabIndex = 7
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.OTC_DJ_Toolbox.My.Resources.Resources.red_grad_whitecorners_100
        Me.PictureBox1.Location = New System.Drawing.Point(4, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.TableLayoutPanel1.SetRowSpan(Me.PictureBox1, 2)
        Me.PictureBox1.Size = New System.Drawing.Size(104, 28)
        Me.PictureBox1.TabIndex = 7
        Me.PictureBox1.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(127, 1)
        Me.Label3.Name = "Label3"
        Me.TableLayoutPanel1.SetRowSpan(Me.Label3, 2)
        Me.Label3.Size = New System.Drawing.Size(144, 31)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Loading..."
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(630, 4)
        Me.Button4.Name = "Button4"
        Me.TableLayoutPanel1.SetRowSpan(Me.Button4, 2)
        Me.Button4.Size = New System.Drawing.Size(69, 23)
        Me.Button4.TabIndex = 2
        Me.Button4.Text = "View Extra"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'lblEmailCheck
        '
        Me.lblEmailCheck.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblEmailCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblEmailCheck.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmailCheck.Location = New System.Drawing.Point(287, 1)
        Me.lblEmailCheck.Margin = New System.Windows.Forms.Padding(0)
        Me.lblEmailCheck.Name = "lblEmailCheck"
        Me.TableLayoutPanel1.SetRowSpan(Me.lblEmailCheck, 2)
        Me.lblEmailCheck.Size = New System.Drawing.Size(100, 34)
        Me.lblEmailCheck.TabIndex = 9
        Me.lblEmailCheck.Text = "Mail Inaccessible"
        Me.lblEmailCheck.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'PictureBox2
        '
        Me.PictureBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(0, 1)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(0)
        Me.PictureBox2.Name = "PictureBox2"
        Me.TableLayoutPanel1.SetRowSpan(Me.PictureBox2, 2)
        Me.PictureBox2.Size = New System.Drawing.Size(1, 34)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 10
        Me.PictureBox2.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(1011, 1)
        Me.PictureBox3.Margin = New System.Windows.Forms.Padding(0)
        Me.PictureBox3.Name = "PictureBox3"
        Me.TableLayoutPanel1.SetRowSpan(Me.PictureBox3, 2)
        Me.PictureBox3.Size = New System.Drawing.Size(1, 34)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 11
        Me.PictureBox3.TabStop = False
        '
        'PictureBox4
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.PictureBox4, 15)
        Me.PictureBox4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox4.Margin = New System.Windows.Forms.Padding(0)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(1012, 1)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox4.TabIndex = 12
        Me.PictureBox4.TabStop = False
        '
        'PictureBox5
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.PictureBox5, 15)
        Me.PictureBox5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(0, 35)
        Me.PictureBox5.Margin = New System.Windows.Forms.Padding(0)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(1012, 1)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox5.TabIndex = 13
        Me.PictureBox5.TabStop = False
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(705, 4)
        Me.Button5.Name = "Button5"
        Me.TableLayoutPanel1.SetRowSpan(Me.Button5, 2)
        Me.Button5.Size = New System.Drawing.Size(69, 23)
        Me.Button5.TabIndex = 14
        Me.Button5.Text = "Playlist"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewLoggerToolStripMenuItem, Me.ToolStripSeparator4, Me.AddFromDatabaseToolStripMenuItem, Me.ToolStripSeparator2, Me.AToolStripMenuItem, Me.AddManuallyToolStripMenuItem, Me.ToolStripSeparator3, Me.ManualNowPlayingUpdateToolStripMenuItem, Me.ToolStripSeparator1, Me.CancelToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(226, 182)
        '
        'ViewLoggerToolStripMenuItem
        '
        Me.ViewLoggerToolStripMenuItem.Name = "ViewLoggerToolStripMenuItem"
        Me.ViewLoggerToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.ViewLoggerToolStripMenuItem.Text = "View Logger"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(222, 6)
        '
        'AddFromDatabaseToolStripMenuItem
        '
        Me.AddFromDatabaseToolStripMenuItem.Name = "AddFromDatabaseToolStripMenuItem"
        Me.AddFromDatabaseToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.AddFromDatabaseToolStripMenuItem.Text = "Add From Database"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(222, 6)
        '
        'AToolStripMenuItem
        '
        Me.AToolStripMenuItem.Name = "AToolStripMenuItem"
        Me.AToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.AToolStripMenuItem.Text = "Add From Audio File"
        '
        'AddManuallyToolStripMenuItem
        '
        Me.AddManuallyToolStripMenuItem.Name = "AddManuallyToolStripMenuItem"
        Me.AddManuallyToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.AddManuallyToolStripMenuItem.Text = "Add Manually"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(222, 6)
        '
        'ManualNowPlayingUpdateToolStripMenuItem
        '
        Me.ManualNowPlayingUpdateToolStripMenuItem.Name = "ManualNowPlayingUpdateToolStripMenuItem"
        Me.ManualNowPlayingUpdateToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.ManualNowPlayingUpdateToolStripMenuItem.Text = "Manual Now Playing Update"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(222, 6)
        '
        'CancelToolStripMenuItem
        '
        Me.CancelToolStripMenuItem.Name = "CancelToolStripMenuItem"
        Me.CancelToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.CancelToolStripMenuItem.Text = "Cancel"
        '
        'Minibar
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1012, 36)
        Me.ControlBox = False
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Minibar"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Minibar"
        Me.TopMost = True
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents lblEmailCheck As System.Windows.Forms.Label
    Friend WithEvents timerEmail As System.Windows.Forms.Timer
    Friend WithEvents timerEmail2 As System.Windows.Forms.Timer
    Friend WithEvents timerProblem As System.Windows.Forms.Timer
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AddFromDatabaseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddManuallyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CancelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ManualNowPlayingUpdateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewLoggerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
End Class
