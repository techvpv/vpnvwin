Imports System.Net
Imports System.IO
Imports System.Text
Imports System.Xml
Public Class Form1
    ' -----------------------------------------------XXXXXXXXXXXXXXXXX-----------------------------------------------
    'By Williams BUI
    ' -----------------------------------------------XXXXXXXXXXXXXXXXX-----------------------------------------------
    ' VPN Service name
    Public Const AppName As String = "VPN Vision"

    ' social media links
    Dim twitter_page As String = "https://twitter.com/vpnvision"
    Dim facebook_page As String = "https://www.facebook.com/VPNVISION"

    ' VPN account creation link
    Public Shared account_link As String = "https://www.vpnvision.com/mon-compte/"

    Dim remote_option As String = 1

    Public Shared domain As String = "fr9.vpnvision.com/Upload"

    Dim sent As Long
    Dim received As Long
    Dim list1 As New ArrayList
    Dim list2 As New ArrayList
    Dim tcp_ca As New ArrayList
    Dim udp_ca As New ArrayList
    Dim ca As String
    Dim servertcp As String
    Dim serverudp As String
    Dim statusread As String
    Dim statusr As String
    Dim statusw As String
    Dim tempData As String
    Dim ldata As String
    Dim IPServer As String
    Dim lport As String
    Dim proto As String
    Dim rport As String
    Dim SelectServer As String
    Public Shared connected_yes As String
    Private ConfigPathname As String = Application.StartupPath & "\data\settings.dat"

    Public Function myConnection()

        IPServer = list1(ServersBox.SelectedIndex)  'TCP
        ca = tcp_ca(ServersBox.SelectedIndex)

        Dim client As New WebClient
        ldata = client.DownloadString("http://" & domain & "/get_data.php?server_code=" & Trim(ServersBox.SelectedIndex) & "&proto=" & "tcp")

        Dim getca As String = Trim(Split(Split(ldata, "<ca>")(1), "</ca>")(0))
        Dim path As String = Application.StartupPath & "\data\" & ca

        If File.Exists(path) Then
            File.Delete(path)
        End If
        Dim fs As FileStream = File.Create(path, 1024)
        Dim info As Byte() = New UTF8Encoding(True).GetBytes(getca)
        fs.Write(info, 0, info.Length)
        fs.Close()

        If Form2.BindBox.Text.Trim = "" Then
            lport = "1194"
        Else
            lport = Form2.BindBox.Text.Trim
        End If

        servertcp = "--client --dev tun --remote " & IPServer & " --proto tcp --port " & "443" & " --lport " & lport & _
" --keepalive 20 60 --auth-user-pass data\acc.tmp --reneg-sec 432000 --resolv-retry infinite --ca data\" & ca & " --comp-lzo --verb 3" & _
" --log data\logfile.tmp --status data\status.dat 1 "

        SelectServer = servertcp

    End Function

    Private Sub Form1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Minimized Then
            Me.Hide()
            NotifyIcon1.Visible = True
            NotifyIcon1.ShowBalloonTip(3000, AppName, "Je suis là!", ToolTipIcon.Info)
        End If
    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If File.Exists(Application.StartupPath & "\bin\openvpn.exe") Then
        Else
            MsgBox("Fichiers de dépendances manquants!", , AppName + "- Error")
            End
        End If
        Try
            If New FileInfo(ConfigPathname).Exists Then
                Dim xoption As New _Set
                Dim xoptionRow As _Set.optionsRow
                xoption.ReadXml(ConfigPathname, System.Data.XmlReadMode.IgnoreSchema)
                If xoption.options.Rows.Count > 0 Then
                    xoptionRow = xoption.options.Rows.Item(0)
                    If Not xoptionRow.IsstartupNull Then
                        Form2.StartBox.Checked = xoptionRow.startup
                    End If
                    If Not xoptionRow.IsnotifyNull Then
                        Form2.UpdateBox.Checked = xoptionRow.notify
                    End If
                    If Not xoptionRow.Islanding_pageNull Then
                        Form2.LPageBox.Checked = xoptionRow.landing_page
                    End If
                    If Not xoptionRow.IspageNull Then
                        Form2.LPageTextBox.Text = xoptionRow.page
                    End If
                    If Not xoptionRow.IsusernameNull Then
                        Form2.UsernameBox.Text = xoptionRow.username
                    End If
                    If Not xoptionRow.IspasswordNull Then
                        Form2.PasswordBox.Text = xoptionRow.password
                    End If
                    If Not xoptionRow.IstcprportNull Then
                        Form2.TCP_PortBox.Text = xoptionRow.tcprport
                    End If
                    If Not xoptionRow.IslportNull Then
                        Form2.BindBox.Text = xoptionRow.lport
                    End If
                    If Not xoptionRow.IsudprportNull Then
                        Form2.UDP_PortBox.Text = xoptionRow.udprport
                    End If
                    If Not xoptionRow.IspingNull Then
                        Form2.PingBox.Checked = xoptionRow.ping
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
        Try
            FileOpen(1, Application.StartupPath & ("\data\acc.tmp"), OpenMode.Output)
        Catch
        End Try

        Try
            PrintLine(1, Form2.UsernameBox.Text)
            Print(1, Form2.PasswordBox.Text)
        Catch

        End Try
        FileClose(1)

        If remote_option = 1 Then
            ServersBox.Items.Clear()
            ServersBox.Text = ""
            list1.Clear()
            tcp_ca.Clear()
            Dim tcp As XmlReader = XmlReader.Create(Application.StartupPath + "/data/tcp.xml")
            Do While tcp.Read()
                If tcp.NodeType = XmlNodeType.Element AndAlso tcp.Name = "name" Then
                    ServersBox.Items.Add(tcp.ReadElementString & " ")
                ElseIf tcp.NodeType = XmlNodeType.Element AndAlso tcp.Name = "ip" Then
                    list1.Add(tcp.ReadElementString)
                ElseIf tcp.NodeType = XmlNodeType.Element AndAlso tcp.Name = "ca" Then
                    tcp_ca.Add(tcp.ReadElementString)
                Else
                    tcp.Read()
                End If
            Loop

        End If
    End Sub
    Private Sub FlatButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConnectButton.Click

        If ConnectButton.Text = "Connecter" Then

            If ServersBox.Text = "" Then
                MsgBox("Merci de sélectionner un serveur VPN!", , AppName)
            Else

                Try
                    Dim Filenum As Integer = FreeFile()
                    FileOpen(Filenum, Application.StartupPath & "\data\logfile.tmp", OpenMode.Output)
                    FileClose()
                Catch ex As Exception

                End Try
                InfoBar.Text = "Connexion en cours..."
                InfoBar.ForeColor = Color.FromArgb(243, 156, 18)
                InfoBar.Refresh()
                ConnectButton.Text = "Connexion"
                ConnectButton.Update()
                ConnectButton.Refresh()
                connected_yes = 0
                NotifyIcon1.ShowBalloonTip(3000, AppName, "Status: Connection en cours...", ToolTipIcon.Info)
                myConnection()
                Shell(Application.StartupPath & "\bin\openvpn " & SelectServer, AppWinStyle.Hide)
                TimerLog.Start()
                Timer1.Start()
            End If
        ElseIf ConnectButton.Text = "Connexion" Then
            If MsgBox("Souhaitez-vous vous déconnecter de " + AppName, MsgBoxStyle.YesNo, AppName) = vbYes Then
                Dim g As String
                g = "taskkill /f /im openvpn.exe"
                Shell("cmd /c" & g, vbHide)
                If Form2.PingBox.Checked = True Then
                    Dim gg As String
                    gg = "taskkill /f /im ping.exe"
                    Shell("cmd /c" & gg, vbHide)
                End If
                TimerLog.Stop()
                Try
                    Dim Filenum As Integer = FreeFile()
                    FileOpen(Filenum, Application.StartupPath & "\data\logfile.tmp", OpenMode.Output)
                    FileClose()
                Catch ex As Exception

                End Try
                Timer1.Stop()
                Timer1.Enabled = False
                connected_yes = 0
                InfoBar.ForeColor = Color.FromArgb(253, 106, 72)
                InfoBar.Text = "Déconnecté"
                InfoBar.Update()
                InfoBar.Refresh()
                ConnectButton.Text = "Connecter"
                ConnectButton.Refresh()
                NotifyIcon1.ShowBalloonTip(3000, AppName, "Status: Déconnecté", ToolTipIcon.Info)
            End If
        ElseIf ConnectButton.Text = "Déconnecter" Then

            Dim g As String
            g = "taskkill /f /im openvpn.exe"
            Shell("cmd /c" & g, vbHide)
            If Form2.PingBox.Checked = True Then
                Dim gg As String
                gg = "taskkill /f /im ping.exe"
                Shell("cmd /c" & gg, vbHide)
            End If
            connected_yes = 0
            InfoBar.ForeColor = Color.FromArgb(253, 106, 72)
            InfoBar.Update()
            InfoBar.Refresh()
            InfoBar.Text = "Déconnecté"
            ConnectButton.Text = "Connecter"
            ConnectButton.Refresh()


            NotifyIcon1.ShowBalloonTip(3000, AppName, "Status: Déconnecté", ToolTipIcon.Info)
            Timer1.Stop()
            Timer1.Enabled = False
            TimerLog.Stop()
            Try
                Dim Filenum As Integer = FreeFile()
                FileOpen(Filenum, Application.StartupPath & "\data\logfile.tmp", OpenMode.Output)
                FileClose()
            Catch ex As Exception

            End Try

        End If
    End Sub

    Private Sub FlatButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SettingsButton.Click
        Form2.ShowDialog()
    End Sub

    Private Sub FlatButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutButton.Click
        Form3.ShowDialog()
    End Sub
    Public Function BytesToMegabytes(ByVal Bytes As Double) As Double

        Dim dblAns As Double
        dblAns = (Bytes / 1024) / 1024
        BytesToMegabytes = Format(dblAns, "###,###,##0.00")

    End Function
    Public Function BytesToMegabyte(ByVal Bytes As Double) As Double

        Dim dblAns As Double
        dblAns = (Bytes / 1024) / 1024
        BytesToMegabyte = Format(dblAns, "###,###,##0.00")

    End Function

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Try
            Dim logFileStream As New FileStream(Application.StartupPath & "\data\status.dat", FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
            Dim logFileReader As New StreamReader(logFileStream)

            statusread = logFileReader.ReadToEnd

            logFileReader.Close()
            logFileStream.Close()
        Catch ex As Exception

        End Try
        Try
            statusr = Split(Split(statusread, "TCP/UDP read bytes,")(1), "TCP/UDP write bytes,")(0)
            statusw = Split(Split(statusread, "TCP/UDP write bytes,")(1), "Auth read bytes,")(0)
        Catch ex As Exception

        End Try
        'It is for Sent Bytes
        Try
            SentBox.Text = BytesToMegabyte(statusw.Trim) & " Mo"
        Catch ex As Exception

        End Try

        'It is for Rec Bytes
        Try
            RecBox.Text = BytesToMegabytes(statusr.Trim) & " Mo"
        Catch ex As Exception

        End Try
    End Sub
    Private Sub ChromeButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogButton.Click
        If LogButton.Text = ">" Then
            Me.Size = New Size(645, 432)
            LogButton.Text = "<"
        ElseIf LogButton.Text = "<" Then
            Me.Size = New Size(338, 432)
            LogButton.Text = ">"
        End If
    End Sub

    Private Sub PictureBox3_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles FacebookBox.MouseEnter
        FacebookBox.Height = 26
        FacebookBox.Width = 26
        ToolTip1.SetToolTip(FacebookBox, "Liker notre page Facebook")
    End Sub

    Private Sub PictureBox3_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles FacebookBox.MouseHover
        FacebookBox.Height = 26
        FacebookBox.Width = 26
        ToolTip1.SetToolTip(FacebookBox, "Liker notre page Facebook")
    End Sub

    Private Sub PictureBox3_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles FacebookBox.MouseLeave
        FacebookBox.Height = 24
        FacebookBox.Width = 24
    End Sub

    Private Sub PictureBox4_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TwitterBox.MouseEnter
        TwitterBox.Height = 26
        TwitterBox.Width = 26
        ToolTip1.SetToolTip(TwitterBox, "Liker notre page Twitter")
    End Sub

    Private Sub PictureBox4_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles TwitterBox.MouseHover
        TwitterBox.Height = 26
        TwitterBox.Width = 26
        ToolTip1.SetToolTip(TwitterBox, "Liker notre page Twitter")
    End Sub
    Private Sub PictureBox4_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TwitterBox.MouseLeave
        TwitterBox.Height = 24
        TwitterBox.Width = 24
    End Sub
    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FacebookBox.Click
        Process.Start(facebook_page)
    End Sub

    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TwitterBox.Click
        Process.Start(twitter_page)
    End Sub

    Private Sub NotifyIcon1_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles NotifyIcon1.DoubleClick
        Try
            If Me.WindowState = FormWindowState.Minimized Then
                Me.Show()
                Me.WindowState = FormWindowState.Normal
            End If
            Me.Activate()
            Me.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub HideToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HideToolStripMenuItem.Click
        Me.Hide()
    End Sub

    Private Sub ShowToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowToolStripMenuItem.Click
        Try
            If Me.WindowState = FormWindowState.Minimized Then
                Me.Show()
                Me.WindowState = FormWindowState.Normal
            End If
            Me.Activate()
            Me.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        If connected_yes = 0 Then
            End
        Else
            Try
                If MsgBox("Souhaitez-vous vous déconnecter de " + AppName, MsgBoxStyle.YesNo, AppName) = vbYes Then
                    Dim g As String
                    g = "taskkill /f /im openvpn.exe"
                    Shell("cmd /c" & g, vbHide)
                    TimerLog.Stop()
                    If Form2.PingBox.Checked = True Then
                        Dim gg As String
                        gg = "taskkill /f /im ping.exe"
                        Shell("cmd /c" & gg, vbHide)
                    End If
                    Try
                        Dim Filenum As Integer = FreeFile()
                        FileOpen(Filenum, Application.StartupPath & "\data\logfile.tmp", OpenMode.Output)
                        FileClose()
                    Catch ex As Exception

                    End Try
                    Timer1.Stop()
                    Timer1.Enabled = False
                    connected_yes = 0
                    InfoBar.ForeColor = Color.FromArgb(253, 106, 72)
                    InfoBar.Text = "Déconnecté"
                    InfoBar.Update()
                    InfoBar.Refresh()
                    ConnectButton.Text = "Connecter"
                    ConnectButton.Refresh()
                    NotifyIcon1.ShowBalloonTip(3000, AppName, "Status: Déconnecté", ToolTipIcon.Info)
                    End
                End If
            Catch ex As Exception

            End Try
        End If

    End Sub

    Private Sub TimerLog_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerLog.Tick
        Try
            Logs.Text = ""
            Dim textline(10000) As String
            Dim TestfileX As String = Application.StartupPath & "\data\logfile.tmp"
            Dim log_ctr As Integer
            Dim tapg As String = 0
            Dim last_log As Integer
            FileOpen(1, TestfileX, OpenMode.Input, OpenAccess.Read, OpenShare.LockRead)
            Do Until EOF(1)
                textline(log_ctr) = LineInput(1)
                log_ctr = log_ctr + 1
                If last_log <> log_ctr Then
                    For n = last_log To log_ctr - 1
                        If tapg = 1 Then
                            textline(n) = "Erreurs TAP"
                        End If
                        If textline(n).Contains("L'adaptateur TAP-Win32 n'est pas installé sur votre ordinateur.") Then
                            Logs.SelectedText = Logs.SelectedText & "L'adaptateur TAP-Win32 n'est pas installé sur votre ordinateur" & vbCrLf
                            Dim g As String
                            g = "taskkill /f /im openvpn.exe"
                            Shell("cmd /c" & g, vbHide)
                            connected_yes = 0
                            NotifyIcon1.ShowBalloonTip(3000, AppName, "Status: Driver TAP introuvable!", ToolTipIcon.Info)
                            InfoBar.ForeColor = Color.FromArgb(253, 106, 72)
                            InfoBar.Text = "Driver TAP introuvable!"
                            If Form2.PingBox.Checked = True Then
                                Dim gg As String
                                gg = "taskkill /f /im ping.exe"
                                Shell("cmd /c" & gg, vbHide)
                            End If
                            InfoBar.Update()
                            InfoBar.Refresh()
                            ConnectButton.Text = "Connecter"
                            ConnectButton.Update()
                            ConnectButton.Refresh()
                            TimerLog.Stop()
                            Timer1.Stop()
                            TimerLog.Enabled = False
                            tapg = 1
                            Dim tap_error As New tap_error
                            tap_error.ShowDialog()

                        ElseIf textline(n).Contains("SYSTEME DE LA TABLE DE ROUTAGE") Then
                            Logs.SelectedText = Logs.SelectedText & "L'adaptateur TAP-Win32 n'est pas installé sur votre ordinateur" & vbCrLf
                            Dim g As String
                            g = "taskkill /f /im openvpn.exe"
                            Shell("cmd /c" & g, vbHide)
                            If Form2.PingBox.Checked = True Then
                                Dim gg As String
                                gg = "taskkill /f /im ping.exe"
                                Shell("cmd /c" & gg, vbHide)
                            End If
                            connected_yes = 0
                            NotifyIcon1.ShowBalloonTip(3000, AppName, "Status : Erreur driver TAP!", ToolTipIcon.Info)
                            InfoBar.ForeColor = Color.FromArgb(253, 106, 72)
                            InfoBar.Text = "Erreur driver TAP!"
                            InfoBar.Update()
                            InfoBar.Refresh()
                            ConnectButton.Text = "Connecter"
                            ConnectButton.Update()
                            ConnectButton.Refresh()
                            TimerLog.Stop()
                            Timer1.Stop()
                            TimerLog.Enabled = False
                            tapg = 1
                            Dim tap_error As New tap_error
                            tap_error.ShowDialog()
                        End If

                        If InStrRev(textline(n), "OpenVPN 2.2.2-ost-20120111") > 0 Then
                            Logs.SelectedText = Logs.SelectedText & "Connexion au réseau VPN Vision" & vbCrLf
                        ElseIf InStrRev(textline(n), "LZO compression initialized") > 0 Then
                            Logs.SelectedText = Logs.SelectedText & "Cpmpression LZO OK" & vbCrLf
                        ElseIf InStrRev(textline(n), "Attempting") > 0 Then
                            Logs.SelectedText = Logs.SelectedText & "Accès au serveur VPN Vision....." & vbCrLf
                        ElseIf InStrRev(textline(n), "VERIFY OK:") > 0 Then
                            Logs.SelectedText = Logs.SelectedText & "Vérification des identifiants de connexion" & vbCrLf
                        ElseIf InStrRev(textline(n), "Peer Connection Initiated with 0.0.0.0:0") > 0 Then
                            Logs.SelectedText = Logs.SelectedText & "Initialisation du serveur VPN Vision...." & vbCrLf
                        ElseIf InStrRev(textline(n), "TAP-WIN32 device") > 0 Then
                            Logs.SelectedText = Logs.SelectedText & "Connexion avec le serveur VPN Vision en cours..." & vbCrLf
                        ElseIf InStrRev(textline(n), "NETSH: C:\WINDOWS\system32\netsh.exe interface ip set address {") > 0 Then
                            Logs.SelectedText = Logs.SelectedText & "Attention!! Vous avez été détecté!!" & vbCrLf & "Effacement de votre Disque dur en cours..." & vbCrLf
                        ElseIf InStrRev(textline(n), "Successful ARP Flush on interface") > 0 Then
                            Logs.SelectedText = Logs.SelectedText & "Veuillez patienter s'il vous plaît........" & vbCrLf
                        ElseIf InStrRev(textline(n), "Initialization Sequence Completed") > 0 Then
                            Logs.SelectedText = "Connexion au serveur VPN Vision réussie" & vbCrLf
                            If connected_yes = 0 Then

                                Timer1.Start()
                                NotifyIcon1.ShowBalloonTip(3000, AppName, "Status : Connexion réussie à VPN Vision", ToolTipIcon.Info)
                                connected_yes = 1
                                Logs.SelectedText = Logs.SelectedText & "" & vbCrLf & "Votre connexion est maintenant sécurisée." & vbCrLf & "" & vbCrLf & "Vous avez accès à la TV française en vous rendant sur les sites internet des chaînes." & vbCrLf & "" & vbCrLf & "Par exemple:" & vbCrLf & "" & vbCrLf & "http://www.mytf1.fr" & vbCrLf & "http://www.france2.fr" & vbCrLf & "http://www.m6replay.fr" & vbCrLf & "" & vbCrLf & "Merci d'utiliser VPN Vision "
                                TimerLog.Stop()
                                If Form2.LPageBox.Checked = True Then
                                    Process.Start(Form2.LPageTextBox.Text.Trim)
                                End If
                                If Form2.PingBox.Checked = True Then
                                    Shell("cmd /c ping google.com -t", AppWinStyle.Hide)
                                End If
                                InfoBar.ForeColor = Color.FromArgb(39, 174, 96)
                                InfoBar.Text = "Connecté"
                                InfoBar.Update()
                                InfoBar.Refresh()
                                ConnectButton.Text = "Déconnecter" 'une fois connecté, c'est le message qui s'affiche
                                ConnectButton.Update()
                                ConnectButton.Refresh()
                            End If
                        ElseIf InStrRev(textline(n), "AUTH: Received AUTH_FAILED control message") > 0 Then
                            Logs.SelectedText = "L'authentification a échoué" & vbCrLf
                            Logs.SelectedText = "Vérifier vos identifiants VPN Vision" & vbCrLf

                            Dim g As String
                            g = "taskkill /f /im openvpn.exe"
                            Shell("cmd /c" & g, vbHide)
                            TimerLog.Stop()
                            Timer1.Stop()
                            connected_yes = 0
                            InfoBar.ForeColor = Color.FromArgb(253, 106, 72)
                            InfoBar.Text = "L'authentification a échoué!"
                            InfoBar.Update()
                            InfoBar.Refresh()
                            ConnectButton.Text = "Connecter"
                            If Form2.PingBox.Checked = True Then
                                Dim gg As String
                                gg = "taskkill /f /im ping.exe"
                                Shell("cmd /c" & gg, vbHide)
                            End If
                            ConnectButton.Update()
                            ConnectButton.Refresh()
                            NotifyIcon1.ShowBalloonTip(3000, AppName, "Status : L'authentification a échoué", ToolTipIcon.Info)

                        ElseIf InStrRev(textline(n), "L'adaptateur TAP-Win32 n'est pas installé sur votre ordinateur") > 0 Then
                            Logs.SelectedText = Logs.SelectedText & "L'adaptateur TAP-Win32 n'est pas installé sur votre ordinateur" & vbCrLf
                            Dim g As String
                            g = "taskkill /f /im openvpn.exe"
                            Shell("cmd /c" & g, vbHide)
                            If Form2.PingBox.Checked = True Then
                                Dim gg As String
                                gg = "taskkill /f /im ping.exe"
                                Shell("cmd /c" & gg, vbHide)
                            End If
                            connected_yes = 0
                            NotifyIcon1.ShowBalloonTip(3000, AppName, "Status: Driver TAP introuvable!", ToolTipIcon.Info)
                            InfoBar.ForeColor = Color.FromArgb(253, 106, 72)
                            InfoBar.Text = "Driver TAP introuvable!"
                            InfoBar.Update()
                            InfoBar.Refresh()
                            ConnectButton.Text = "Connecter"
                            ConnectButton.Update()
                            ConnectButton.Refresh()
                            TimerLog.Stop()
                            Timer1.Stop()
                            TimerLog.Enabled = False
                            tapg = 1
                            Dim tap_error As New tap_error
                            tap_error.ShowDialog()
                        ElseIf InStrRev(textline(n), "Inactivité timeout (--ping-restart), restarting") > 0 Then
                            Dim g As String
                            g = "taskkill /f /im openvpn.exe"
                            Shell("cmd /c" & g, vbHide)
                            If Form2.PingBox.Checked = True Then
                                Dim gg As String
                                gg = "taskkill /f /im ping.exe"
                                Shell("cmd /c" & gg, vbHide)
                            End If
                            Logs.Text = "======Inactivité timeout======" & vbNewLine & "Connexion impossible..." & vbCrLf & "S'il vous plaît, essayer de vous connecter encore une fois" & vbCrLf & vbCrLf & "=======Essayer encore======"
                            TimerLog.Stop()
                            Timer1.Stop()
                            connected_yes = 0
                            ConnectButton.Text = "Connecter"
                            ConnectButton.Update()
                            ConnectButton.Refresh()
                            InfoBar.ForeColor = Color.FromArgb(253, 106, 72)
                            InfoBar.Text = "Timeout!"
                            InfoBar.Update()
                            InfoBar.Refresh()
                            NotifyIcon1.ShowBalloonTip(3000, AppName, "Status : Timeout!", ToolTipIcon.Info)
                        ElseIf InStrRev(textline(n), "Exiting") > 0 Then
                            Dim g As String
                            g = "taskkill /f /im openvpn.exe"
                            Shell("cmd /c" & g, vbHide)
                            If Form2.PingBox.Checked = True Then
                                Dim gg As String
                                gg = "taskkill /f /im ping.exe"
                                Shell("cmd /c" & gg, vbHide)
                            End If
                            Try
                                TimerLog.Stop()
                                Timer1.Stop()
                            Catch ex As Exception

                            End Try

                            ConnectButton.Text = "Connecter"
                            connected_yes = 0
                            InfoBar.ForeColor = Color.FromArgb(253, 106, 72)
                            InfoBar.Text = "Disconnected"
                            ConnectButton.Update()
                            ConnectButton.Refresh()
                            InfoBar.Update()
                            InfoBar.Refresh()
                            NotifyIcon1.ShowBalloonTip(3000, AppName, "Status : Impossible de se connecter au serveur VPN Vision", ToolTipIcon.Info)
                            Logs.Text = "Impossible de se connecter..." & vbCrLf & "S'il vous plaît, essayer encore"
                            TimerLog.Enabled = False
                        End If
                    Next
                    last_log = log_ctr
                End If
            Loop
            FileClose(1)
        Catch ex As Exception

        End Try
        Try
            FileClose(1)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub getMyData_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles getMyData.DoWork
        Try
            Dim webClient As New System.Net.WebClient
            webClient.DownloadFile("http://" + domain + "/tcp.xml", Application.StartupPath & "\data\tcp.xml")
            webClient.Dispose()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub updateChecker_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles updateChecker.RunWorkerCompleted
        Dim ver_no As String
        Dim news_data As String
        ver_no = Split(tempData, "::")(0)
        news_data = Split(tempData, "::")(2)
        Form2.Label7.Text = "v" & ver_no
        Form2.Label7.Refresh()
        Form2.RainoTextBox6.Text = news_data
        Form2.RainoTextBox6.Refresh()
        If ver_no.Contains("1.0") Then

        Else
            MsgBox("Nouvelle version de l'application disponible!")
        End If
    End Sub
    Private Sub ChromeThemeContainer1_Click(sender As Object, e As EventArgs) Handles ChromeThemeContainer1.Click

    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ServerLabel_Click(sender As Object, e As EventArgs) Handles ServerLabel.Click

    End Sub
End Class