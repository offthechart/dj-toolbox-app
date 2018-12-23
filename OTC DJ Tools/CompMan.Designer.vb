<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CompMan
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CompMan))
        Me.Entrants = New System.Windows.Forms.ListBox
        Me.Add = New System.Windows.Forms.Button
        Me.Edit = New System.Windows.Forms.Button
        Me.Remove = New System.Windows.Forms.Button
        Me.Reset = New System.Windows.Forms.Button
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.OK = New System.Windows.Forms.Button
        Me.Winners = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Entrants
        '
        Me.Entrants.FormattingEnabled = True
        Me.Entrants.Location = New System.Drawing.Point(13, 26)
        Me.Entrants.Name = "Entrants"
        Me.Entrants.Size = New System.Drawing.Size(309, 147)
        Me.Entrants.TabIndex = 7
        '
        'Add
        '
        Me.Add.Location = New System.Drawing.Point(13, 180)
        Me.Add.Name = "Add"
        Me.Add.Size = New System.Drawing.Size(60, 23)
        Me.Add.TabIndex = 0
        Me.Add.Text = "Add"
        Me.Add.UseVisualStyleBackColor = True
        '
        'Edit
        '
        Me.Edit.Location = New System.Drawing.Point(79, 180)
        Me.Edit.Name = "Edit"
        Me.Edit.Size = New System.Drawing.Size(60, 23)
        Me.Edit.TabIndex = 1
        Me.Edit.Text = "Edit"
        Me.Edit.UseVisualStyleBackColor = True
        '
        'Remove
        '
        Me.Remove.Location = New System.Drawing.Point(145, 180)
        Me.Remove.Name = "Remove"
        Me.Remove.Size = New System.Drawing.Size(60, 23)
        Me.Remove.TabIndex = 2
        Me.Remove.Text = "Remove"
        Me.Remove.UseVisualStyleBackColor = True
        '
        'Reset
        '
        Me.Reset.Location = New System.Drawing.Point(261, 180)
        Me.Reset.Name = "Reset"
        Me.Reset.Size = New System.Drawing.Size(60, 23)
        Me.Reset.TabIndex = 3
        Me.Reset.Text = "Reset"
        Me.Reset.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Enabled = False
        Me.TextBox1.Location = New System.Drawing.Point(56, 210)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(199, 20)
        Me.TextBox1.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 213)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Name:"
        '
        'OK
        '
        Me.OK.Enabled = False
        Me.OK.Location = New System.Drawing.Point(261, 207)
        Me.OK.Name = "OK"
        Me.OK.Size = New System.Drawing.Size(61, 23)
        Me.OK.TabIndex = 5
        Me.OK.Text = "OK"
        Me.OK.UseVisualStyleBackColor = True
        '
        'Winners
        '
        Me.Winners.Location = New System.Drawing.Point(13, 253)
        Me.Winners.Name = "Winners"
        Me.Winners.Size = New System.Drawing.Size(310, 23)
        Me.Winners.TabIndex = 6
        Me.Winners.Text = "Pick Winners"
        Me.Winners.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Entrants:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Trebuchet MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 291)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(27, 18)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "1st"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Trebuchet MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 323)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 18)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "2nd"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Trebuchet MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 355)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(30, 18)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "3rd"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Trebuchet MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(53, 291)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(131, 18)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "First Placed Winner !"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Trebuchet MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(53, 323)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(145, 18)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "Second Placed Winner !"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Trebuchet MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(53, 355)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(135, 18)
        Me.Label8.TabIndex = 21
        Me.Label8.Text = "Third Placed Winner !"
        '
        'CompMan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(336, 391)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Winners)
        Me.Controls.Add(Me.OK)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Reset)
        Me.Controls.Add(Me.Remove)
        Me.Controls.Add(Me.Edit)
        Me.Controls.Add(Me.Add)
        Me.Controls.Add(Me.Entrants)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(352, 427)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(352, 427)
        Me.Name = "CompMan"
        Me.Text = "Competition Manager"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Entrants As System.Windows.Forms.ListBox
    Friend WithEvents Add As System.Windows.Forms.Button
    Friend WithEvents Edit As System.Windows.Forms.Button
    Friend WithEvents Remove As System.Windows.Forms.Button
    Friend WithEvents Reset As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents OK As System.Windows.Forms.Button
    Friend WithEvents Winners As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
End Class
