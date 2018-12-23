Public Class ServerStatus

    Private Sub ServerStatus_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.WebBrowser1.Url = (New Uri("http://www.offthechartradio.co.uk/scripts/listen.php?option=status"))
    End Sub
    Private Sub ServerStatus_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

    End Sub
End Class