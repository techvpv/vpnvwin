Public Class Form2
    ' -----------------------------------------------XXXXXXXXXXXXXXXXX-----------------------------------------------
  
    ' -----------------------------------------------XXXXXXXXXXXXXXXXX-----------------------------------------------
    Private ConfigPathname As String = Application.StartupPath & "\data\settings.dat"
    Dim tempData As String = "1.0::http://script8.prothemes.biz/update.zip::News"  ' Sample data
    Private Sub FlatCheckbox3_CheckedChanged(ByVal sender As Object) Handles LPageBox.CheckedChanged
        If UpdateBox.Checked = True Then
            LPageTextBox.Enabled = True
        ElseIf UpdateBox.Checked = False Then
            LPageTextBox.Enabled = False
        End If
    End Sub

    Private Sub FlatButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveButton1.Click
        Try
            If StartBox.Checked = True Then
                My.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True).SetValue(Form1.AppName, Application.ExecutablePath)
            ElseIf StartBox.Checked = False Then
                My.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True).DeleteValue(Form1.AppName)
            End If
        Catch ex As Exception

        End Try
        If TCP_PortBox.Text.Trim = "" Then
            'MsgBox("Rport field is empty!", , Form1.AppName)
            MsgBox("Le champ Rport ne peut être vide!", , Form1.AppName)
        ElseIf BindBox.Text.Trim = "" Then
            'MsgBox("Lport field is empty!", , Form1.AppName)
            MsgBox("Le champ Lport ne peut être vide!", , Form1.AppName)
        Else
            Try
                Dim xoption As New _Set
                Dim xoptionRow As _Set.optionsRow
                xoptionRow = xoption.options.NewoptionsRow
                xoptionRow.startup = StartBox.Checked
                xoptionRow.notify = UpdateBox.Checked
                xoptionRow.landing_page = LPageBox.Checked
                xoptionRow.tcprport = TCP_PortBox.Text.Trim
                xoptionRow.udprport = UDP_PortBox.Text.Trim
                xoptionRow.ping = PingBox.Checked
                xoptionRow.lport = BindBox.Text.Trim
                xoptionRow.username = UsernameBox.Text.Trim
                xoptionRow.password = PasswordBox.Text.Trim
                xoptionRow.page = LPageTextBox.Text.Trim
                xoption.options.AddoptionsRow(xoptionRow)
                xoption.WriteXml(ConfigPathname, System.Data.XmlWriteMode.IgnoreSchema)
                Try
                    FileOpen(1, Application.StartupPath & ("\data\acc.tmp"), OpenMode.Output)
                Catch
                End Try
                Try
                    PrintLine(1, UsernameBox.Text)
                    Print(1, PasswordBox.Text)
                Catch

                End Try
                FileClose(1)
                'MsgBox("Cyber VPN Settings Saved Successfully", , Form1.AppName)
                MsgBox("Les paramètres du compte VPN Vision sauvegardées", , Form1.AppName)
                Me.Hide()
            Catch ex As Exception
                'MsgBox("Settings Not Saved - Error", , Form1.AppName)
                MsgBox("Erreur, paramètres non sauvegardées", , Form1.AppName)
            End Try
        End If
    End Sub

    Private Sub FlatButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveButton3.Click
        Try
            If StartBox.Checked = True Then
                My.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True).SetValue(Form1.AppName, Application.ExecutablePath)
            ElseIf StartBox.Checked = False Then
                My.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True).DeleteValue(Form1.AppName)
            End If
        Catch ex As Exception

        End Try
        If UsernameBox.Text.Trim = "" Then
            'MsgBox("Username field is empty!", , Form1.AppName)
            MsgBox("Le champ ""Username"" est vide!", , Form1.AppName)
        ElseIf PasswordBox.Text.Trim = "" Then
            'MsgBox("Password field is empty!", , Form1.AppName)
            MsgBox("Le champ ""Password"" est vide!", , Form1.AppName)
        Else
            Try
                Dim xoption As New _Set
                Dim xoptionRow As _Set.optionsRow
                xoptionRow = xoption.options.NewoptionsRow
                xoptionRow.startup = StartBox.Checked
                xoptionRow.notify = UpdateBox.Checked
                xoptionRow.landing_page = LPageBox.Checked
                xoptionRow.tcprport = TCP_PortBox.Text.Trim
                xoptionRow.lport = BindBox.Text.Trim
                xoptionRow.udprport = UDP_PortBox.Text.Trim
                xoptionRow.ping = PingBox.Checked
                xoptionRow.username = UsernameBox.Text.Trim
                xoptionRow.password = PasswordBox.Text.Trim
                xoptionRow.page = LPageTextBox.Text.Trim
                xoption.options.AddoptionsRow(xoptionRow)
                xoption.WriteXml(ConfigPathname, System.Data.XmlWriteMode.IgnoreSchema)
                Try
                    FileOpen(1, Application.StartupPath & ("\data\acc.tmp"), OpenMode.Output)
                Catch
                End Try
                Try
                    PrintLine(1, UsernameBox.Text)
                    Print(1, PasswordBox.Text)
                Catch

                End Try
                FileClose(1)
                'MsgBox("Cyber VPN Settings Saved Successfully", , Form1.AppName)
                MsgBox("Les paramètres du compte VPN Vision sauvegardées", , Form1.AppName)
                Me.Hide()
            Catch ex As Exception
                'MsgBox("Settings Not Saved - Error", , Form1.AppName)
                MsgBox("Erreur, paramètres non sauvegardées", , Form1.AppName)
            End Try
        End If
    End Sub

    Private Sub FlatLabel6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AccountLinkBox.Click
        Process.Start(Form1.account_link)
    End Sub

    Private Sub FlatButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateButton.Click
        Try
            Dim webClient As New System.Net.WebClient
            tempData = webClient.DownloadString("http://" + Form1.domain + "/updater.php")
            webClient.Dispose()
        Catch ex As Exception

        End Try
        Dim ver_no As String
        Dim file_path As String
        Dim news_data As String
        ver_no = Split(tempData, "::")(0)
        file_path = Split(tempData, "::")(1)
        news_data = Split(tempData, "::")(2)
        Label7.Text = "v" & ver_no
        Label7.Refresh()
        RainoTextBox6.Text = news_data
        RainoTextBox6.Refresh()
        If ver_no.Contains("1.0") Then
            'MsgBox("No update found!", , "Update Checker")
            MsgBox("Pas de mise à jour trouvée!", , "Vérification d'update")
        Else
            'MsgBox("Newer version of application found!", , "Update Checker")
            MsgBox("Télécharger la mise à jour!", , "Vérification d'update")
            'Not avilable - Contact Support
            '  Process.Start(Application.StartupPath & "\Updater.exe")
            '   End
        End If
    End Sub

    Private Sub FlatButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveButton2.Click
        Try
            If StartBox.Checked = True Then
                My.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True).SetValue(Form1.AppName, Application.ExecutablePath)
            ElseIf StartBox.Checked = False Then
                My.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True).DeleteValue(Form1.AppName)
            End If
        Catch ex As Exception

        End Try
        If UsernameBox.Text.Trim = "" Then
            'MsgBox("Username field is empty!", , Form1.AppName)
            MsgBox("Le champ ""Username"" est vide!", , Form1.AppName)
        ElseIf PasswordBox.Text.Trim = "" Then
            'MsgBox("Password field is empty!", , Form1.AppName)
            MsgBox("Le champ ""Password"" est vide!", , Form1.AppName)
        Else
            Try
                Dim xoption As New _Set
                Dim xoptionRow As _Set.optionsRow
                xoptionRow = xoption.options.NewoptionsRow
                xoptionRow.startup = StartBox.Checked
                xoptionRow.notify = UpdateBox.Checked
                xoptionRow.landing_page = LPageBox.Checked
                xoptionRow.tcprport = TCP_PortBox.Text.Trim
                xoptionRow.lport = BindBox.Text.Trim
                xoptionRow.udprport = UDP_PortBox.Text.Trim
                xoptionRow.ping = PingBox.Checked
                xoptionRow.username = UsernameBox.Text.Trim
                xoptionRow.password = PasswordBox.Text.Trim
                xoptionRow.page = LPageTextBox.Text.Trim
                xoption.options.AddoptionsRow(xoptionRow)
                xoption.WriteXml(ConfigPathname, System.Data.XmlWriteMode.IgnoreSchema)
                Try
                    FileOpen(1, Application.StartupPath & ("\data\acc.tmp"), OpenMode.Output)
                Catch
                End Try
                Try
                    PrintLine(1, UsernameBox.Text)
                    Print(1, PasswordBox.Text)
                Catch

                End Try
                FileClose(1)
                'MsgBox("Cyber VPN Settings Saved Successfully", , Form1.AppName)
                MsgBox("Les paramètres du compte VPN Vision sauvegardées", , Form1.AppName)
                Me.Hide()
            Catch ex As Exception
                'MsgBox("Settings Not Saved - Error", , Form1.AppName)
                MsgBox("Erreur, paramètres non sauvegardées", , Form1.AppName)
            End Try
        End If
    End Sub
End Class