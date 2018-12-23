<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DJMail
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DJMail))
        Me.webEmailMain = New System.Windows.Forms.WebBrowser
        Me.SuspendLayout()
        '
        'webEmailMain
        '
        Me.webEmailMain.AllowWebBrowserDrop = False
        Me.webEmailMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.webEmailMain.IsWebBrowserContextMenuEnabled = False
        Me.webEmailMain.Location = New System.Drawing.Point(0, 0)
        Me.webEmailMain.MinimumSize = New System.Drawing.Size(20, 20)
        Me.webEmailMain.Name = "webEmailMain"
        Me.webEmailMain.ScriptErrorsSuppressed = True
        Me.webEmailMain.Size = New System.Drawing.Size(784, 414)
        Me.webEmailMain.TabIndex = 0
        Me.webEmailMain.WebBrowserShortcutsEnabled = False
        '
        'DJMail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 414)
        Me.Controls.Add(Me.webEmailMain)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DJMail"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Mail Viewer"
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents webEmailMain As System.Windows.Forms.WebBrowser
End Class
