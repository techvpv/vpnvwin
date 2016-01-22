Public Class tap_error
    ' -----------------------------------------------XXXXXXXXXXXXXXXXX-----------------------------------------------
   
    ' -----------------------------------------------XXXXXXXXXXXXXXXXX-----------------------------------------------
    Private Sub FlatButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlatButton3.Click
        Me.Hide()
    End Sub

    Private Sub FlatButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlatButton2.Click
        Shell(Application.StartupPath & "\tap-fixer.exe", AppWinStyle.NormalFocus)
    End Sub

    Private Sub FlatButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlatButton1.Click
        If Environment.Is64BitOperatingSystem = vbTrue Then
            Shell(Application.StartupPath & "\bin\fixmytap64.bat", AppWinStyle.NormalFocus)
        Else
            Shell(Application.StartupPath & "\bin\fixmytap.bat", AppWinStyle.NormalFocus)
        End If
        Me.Close()
    End Sub
End Class