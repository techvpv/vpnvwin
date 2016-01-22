Imports System.Net
Imports System.IO
Imports System.Text
Imports System.Xml
Public Class Form1

    ' Enter your VPN Service name
    Public Const AppName As String = "VPN Vision"

    ' Enter your social media links
    Dim twitter_page As String = "https://twitter.com/vpnvision"
    Dim facebook_page As String = "https://www.facebook.com/VPNVISION"
    'Dim google_page As String = "https://plus.google.com/"

    'Enter your VPN account creation link
    Public Shared account_link As String = "https://www.vpnvision.com/mon-compte/"

    'Remotely server list 

    ' 0 refers remotetly server list option is disbaled 
    ' 1 refers remotetly server list option is enabled 
    Dim remote_option As String = 1

    'Enter your server path (Server side located files) (Note enter without http://)
    'Public Shared domain As String = "fr9.vpnvision.com/Upload"
    Public Shared domain As String = "w.bui.free.fr/Upload"

    'Don't modify until you may know what you are doing
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

    ' OpenVPN Configuration File

    Public Function myConnection()
        'TCPButton.Checked = True
        IPServer = list1(ServersBox.SelectedIndex)  'TCP
        ca = tcp_ca(ServersBox.SelectedIndex)

        'If TCPButton.Checked = True Then
        '    IPServer = list1(ServersBox.SelectedIndex)  'TCP
        '    ca = tcp_ca(ServersBox.SelectedIndex)
        'Else
        '    IPServer = list2(ServersBox.SelectedIndex)  'UDP
        '    ca = udp_ca(ServersBox.SelectedIndex)
        'End If


        ' -----------------------------------------------XXXXXXXXXXXXXXXXX-----------------------------------------------
        'Force proto without option remote
        'If remote_option = 1 Then
        'proto = "tcp"
        ' -----------------------------------------------XXXXXXXXXXXXXXXXX-----------------------------------------------

        'If TCPButton.Checked = True Then
        '    proto = "tcp"
        'Else
        '    proto = "udp"
        'End If
        ' -----------------------------------------------XXXXXXXXXXXXXXXXX-----------------------------------------------
        'Tout ce qui est commenté vient de moi
        'Try
        Dim client As New WebClient
        'ldata = client.DownloadString("http://" & domain & "/get_data.php?server_code=" & Trim(ServersBox.SelectedIndex) & "&proto=" & proto)
        ldata = client.DownloadString("http://" & domain & "/get_data.php?server_code=" & Trim(ServersBox.SelectedIndex) & "&proto=" & "tcp")
        'Catch ex As Exception

        'End Try
        ' -----------------------------------------------XXXXXXXXXXXXXXXXX-----------------------------------------------
        Dim getca As String = Trim(Split(Split(ldata, "<ca>")(1), "</ca>")(0))
        Dim path As String = Application.StartupPath & "\data\" & ca

        If File.Exists(path) Then
            File.Delete(path)
        End If
        Dim fs As FileStream = File.Create(path, 1024)
        Dim info As Byte() = New UTF8Encoding(True).GetBytes(getca)
        fs.Write(info, 0, info.Length)
        fs.Close()
        'End If

        ' -----------------------------------------------XXXXXXXXXXXXXXXXX-----------------------------------------------
        'If TCPButton.Checked = True Then
        '    rport = "443"
        'End If

        'End If
        ' -----------------------------------------------XXXXXXXXXXXXXXXXX-----------------------------------------------

        'If TCPButton.Checked = True Then
        '    If Form2.TCP_PortBox.Text.Trim = "" Then
        '        rport = "443"
        '    Else
        '        rport = Form2.TCP_PortBox.Text.Trim
        '    End If
        'Else
        '    If Form2.UDP_PortBox.Text.Trim = "" Then
        '        rport = "1194"
        '    Else
        '        rport = Form2.UDP_PortBox.Text.Trim
        '    End If
        'End If

        If Form2.BindBox.Text.Trim = "" Then
            lport = "1194"
        Else
            lport = Form2.BindBox.Text.Trim
        End If

        ' TCP Config File

        servertcp = "--client --dev tun --remote " & IPServer & " --proto tcp --port " & "443" & " --lport " & lport & _
" --keepalive 20 60 --auth-user-pass data\acc.tmp --reneg-sec 432000 --resolv-retry infinite --ca data\" & ca & " --comp-lzo --verb 3" & _
" --log data\logfile.tmp --status data\status.dat 1 "


        ' UDP Config File

        '        serverudp = "--client --dev tun --remote " & IPServer & " --proto udp --port " & rport & " --lport " & lport & _
        '"  --resolv-retry infinite --mssfix 1450 --tun-mtu 1500 --tun-mtu-extra 32 --persist-key --persist-tun --auth-user-pass data\acc.tmp --ca data\" & ca & " --comp-lzo --verb 3" & _
        '" --log data\logfile.tmp --status data\status.dat 1 "

        ' -----------------------------------------------XXXXXXXXXXXXXXXXX-----------------------------------------------

        ' -----------------------------------------------XXXXXXXXXXXXXXXXX-----------------------------------------------


        'Load Config File
        SelectServer = servertcp
        'If TCPButton.Checked = True Then
        '    SelectServer = servertcp
        'Else
        '    SelectServer = serverudp
        'End If

    End Function

    Private Sub Form1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Minimized Then
            Me.Hide()
            NotifyIcon1.Visible = True
            'NotifyIcon1.ShowBalloonTip(3000, AppName, "I am Here!", ToolTipIcon.Info)
            NotifyIcon1.ShowBalloonTip(3000, AppName, "Je suis là!", ToolTipIcon.Info)
        End If
    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If File.Exists(Application.StartupPath & "\bin\openvpn.exe") Then
            'Okay
        Else
            'MsgBox("Dependency files are missing!", , AppName + "- Error")
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
            ' -----------------------------------------------XXXXXXXXXXXXXXXXX-----------------------------------------------
            'Autoload remote server list (desactivate Buttonradio)
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
            ' -----------------------------------------------XXXXXXXXXXXXXXXXX-----------------------------------------------

            ' -----------------------------------------------XXXXXXXXXXXXXXXXX-----------------------------------------------
            'Comment or Autoload remote server list doesn't work
            'Dim path1 As String = Application.StartupPath & "\data\tcp.xml"
            'Dim path2 As String = Application.StartupPath & "\data\udp.xml"
            'If File.Exists(path1) Then
            '    File.Delete(path1)
            'End If
            'If File.Exists(path2) Then
            '    File.Delete(path2)
            'End If
            ' -----------------------------------------------XXXXXXXXXXXXXXXXX-----------------------------------------------
            Try
                getMyData.RunWorkerAsync()
            Catch ex As Exception

            End Try
        Else
            If Form2.UpdateBox.Checked = True Then
                Try
                    updateChecker.RunWorkerAsync()
                Catch ex As Exception

                End Try
            End If

        End If
    End Sub
    Private Sub FlatButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConnectButton.Click

        'If TCPButton.Checked = True Or UDPButton.Checked = True Then

        'If ConnectButton.Text = "Connect" Then
        If ConnectButton.Text = "Connecter" Then

            If ServersBox.Text = "" Then
                'MsgBox("Please select your server!", , AppName)
                MsgBox("Merci de sélectionner un serveur VPN!", , AppName)
            Else

                Try
                    Dim Filenum As Integer = FreeFile()
                    FileOpen(Filenum, Application.StartupPath & "\data\logfile.tmp", OpenMode.Output)
                    FileClose()
                Catch ex As Exception

                End Try
                'InfoBar.Text = "Connecting..."
                InfoBar.Text = "Connexion en cours..."
                InfoBar.ForeColor = Color.FromArgb(243, 156, 18)
                InfoBar.Refresh()
                'ConnectButton.Text = "Connecting"
                ConnectButton.Text = "Connexion"
                ConnectButton.Update()
                ConnectButton.Refresh()
                connected_yes = 0
                'NotifyIcon1.ShowBalloonTip(3000, AppName, "Status: Connecting...", ToolTipIcon.Info)
                NotifyIcon1.ShowBalloonTip(3000, AppName, "Status: Connection en cours...", ToolTipIcon.Info)
                myConnection()
                Shell(Application.StartupPath & "\bin\openvpn " & SelectServer, AppWinStyle.Hide)
                TimerLog.Start()
                Timer1.Start()
            End If
            'ElseIf ConnectButton.Text = "Connecting" Then
        ElseIf ConnectButton.Text = "Connexion" Then
            'If MsgBox("Do You want to Disconnect" + AppName, MsgBoxStyle.YesNo, AppName) = vbYes Then
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
                'InfoBar.Text = "Disconnected"
                InfoBar.Text = "Déconnecté"
                InfoBar.Update()
                InfoBar.Refresh()
                'ConnectButton.Text = "Connect"
                ConnectButton.Text = "Connecter"
                ConnectButton.Refresh()
                'NotifyIcon1.ShowBalloonTip(3000, AppName, "Status: Disconnected", ToolTipIcon.Info)
                NotifyIcon1.ShowBalloonTip(3000, AppName, "Status: Déconnecté", ToolTipIcon.Info)
            End If
            'ElseIf ConnectButton.Text = "Disconnect" Then
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
            'InfoBar.Text = "Disconnected"
            InfoBar.Text = "Déconnecté"
            'ConnectButton.Text = "Connect"
            ConnectButton.Text = "Connecter"
            ConnectButton.Refresh()

            'NotifyIcon1.ShowBalloonTip(3000, AppName, "Status: Disconnected", ToolTipIcon.Info)
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
        'Else
        ''MsgBox("Please select your Protocol!", , AppName)
        'MsgBox("Merci de sélectionner le protocole!", , AppName)
        'End If
    End Sub

    Private Sub FlatButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SettingsButton.Click
        Form2.ShowDialog()
    End Sub

    Private Sub FlatButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutButton.Click
        Form3.ShowDialog()
    End Sub
    Public Function BytesToMegabytes(ByVal Bytes As Double) As Double
        'This function gives an estimate to two decimal
        'places.  For a more precise answer, format to
        'more decimal places or just return dblAns

        Dim dblAns As Double
        dblAns = (Bytes / 1024) / 1024
        BytesToMegabytes = Format(dblAns, "###,###,##0.00")

    End Function
    Public Function BytesToMegabyte(ByVal Bytes As Double) As Double
        'This function gives an estimate to two decimal
        'places.  For a more precise answer, format to
        'more decimal places or just return dblAns

        Dim dblAns As Double
        dblAns = (Bytes / 1024) / 1024
        BytesToMegabyte = Format(dblAns, "###,###,##0.00")

    End Function

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Try
            Dim logFileStream As New FileStream(Application.StartupPath & "\data\status.dat", FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
            Dim logFileReader As New StreamReader(logFileStream)

            ' Your code here
            statusread = logFileReader.ReadToEnd
            ' Clean up
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
            'SentBox.Text = BytesToMegabyte(statusw.Trim) & " Mb"
            SentBox.Text = BytesToMegabyte(statusw.Trim) & " Mo"
        Catch ex As Exception

        End Try

        'It is for Rec Bytes
        Try
            'RecBox.Text = BytesToMegabytes(statusr.Trim) & " Mb"
            RecBox.Text = BytesToMegabytes(statusr.Trim) & " Mo"
        Catch ex As Exception

        End Try
    End Sub
    'Private Sub FlatRadioButton1_CheckedChanged(ByVal sender As System.Object) Handles TCPButton.CheckedChanged
    '    Try
    '        ServersBox.Items.Clear()
    '        ServersBox.Text = ""
    '        list1.Clear()
    '        tcp_ca.Clear()
    '        Dim tcp As XmlReader = XmlReader.Create(Application.StartupPath + "/data/tcp.xml")
    '        Do While tcp.Read()
    '            If tcp.NodeType = XmlNodeType.Element AndAlso tcp.Name = "name" Then
    '                ServersBox.Items.Add(tcp.ReadElementString & " ")
    '            ElseIf tcp.NodeType = XmlNodeType.Element AndAlso tcp.Name = "ip" Then
    '                list1.Add(tcp.ReadElementString)
    '            ElseIf tcp.NodeType = XmlNodeType.Element AndAlso tcp.Name = "ca" Then
    '                tcp_ca.Add(tcp.ReadElementString)
    '            Else
    '                tcp.Read()
    '            End If
    '        Loop
    '        tcp.Close()
    '    Catch ex As Exception
    '        MsgBox("Unable to load the data", , AppName)
    '    End Try
    'End Sub
    'Private Sub FlatRadioButton2_CheckedChanged(ByVal sender As System.Object) Handles UDPButton.CheckedChanged
    '    Try
    '        ServersBox.Items.Clear()
    '        ServersBox.Text = ""
    '        list2.Clear()
    '        udp_ca.Clear()
    '        Dim udp As XmlReader = XmlReader.Create(Application.StartupPath + "/data/udp.xml")
    '        Do While udp.Read()
    '            If udp.NodeType = XmlNodeType.Element AndAlso udp.Name = "name" Then
    '                ServersBox.Items.Add(udp.ReadElementString & " ")
    '            ElseIf udp.NodeType = XmlNodeType.Element AndAlso udp.Name = "ip" Then
    '                list2.Add(udp.ReadElementString)
    '            ElseIf udp.NodeType = XmlNodeType.Element AndAlso udp.Name = "ca" Then
    '                udp_ca.Add(udp.ReadElementString)
    '            Else
    '                udp.Read()
    '            End If
    '        Loop
    '        udp.Close()
    '    Catch ex As Exception
    '        MsgBox("Unable to load the data", , AppName)
    '    End Try
    'End Sub

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
        'ToolTip1.SetToolTip(FacebookBox, "Like our Facebook page")
        ToolTip1.SetToolTip(FacebookBox, "Liker notre page Facebook")
    End Sub

    Private Sub PictureBox3_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles FacebookBox.MouseHover
        FacebookBox.Height = 26
        FacebookBox.Width = 26
        'ToolTip1.SetToolTip(FacebookBox, "Like our Facebook page")
        ToolTip1.SetToolTip(FacebookBox, "Liker notre page Facebook")
    End Sub

    Private Sub PictureBox3_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles FacebookBox.MouseLeave
        FacebookBox.Height = 24
        FacebookBox.Width = 24
    End Sub

    Private Sub PictureBox4_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TwitterBox.MouseEnter
        TwitterBox.Height = 26
        TwitterBox.Width = 26
        'ToolTip1.SetToolTip(TwitterBox, "Like our Twitter page")
        ToolTip1.SetToolTip(TwitterBox, "Liker notre page Twitter")
    End Sub

    Private Sub PictureBox4_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles TwitterBox.MouseHover
        TwitterBox.Height = 26
        TwitterBox.Width = 26
        'ToolTip1.SetToolTip(TwitterBox, "Like our Twitter page")
        ToolTip1.SetToolTip(TwitterBox, "Liker notre page Twitter")
    End Sub
    Private Sub PictureBox4_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TwitterBox.MouseLeave
        TwitterBox.Height = 24
        TwitterBox.Width = 24
    End Sub

    'Private Sub PictureBox5_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs)
    '    GplusBox.Height = 26
    '    GplusBox.Width = 26
    '    ToolTip1.SetToolTip(GplusBox, "Like our GPlus page")
    'End Sub

    'Private Sub PictureBox5_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs)
    '    GplusBox.Height = 26
    '    GplusBox.Width = 26
    '    ToolTip1.SetToolTip(GplusBox, "Like our GPlus page")
    'End Sub
    'Private Sub PictureBox5_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs)
    '    GplusBox.Height = 24
    '    GplusBox.Width = 24
    'End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FacebookBox.Click
        Process.Start(facebook_page)
    End Sub

    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TwitterBox.Click
        Process.Start(twitter_page)
    End Sub

    'Private Sub PictureBox5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GplusBox.Click
    '    Process.Start(google_page)
    'End Sub
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
                'If MsgBox("Do You want to Disconnect" + AppName, MsgBoxStyle.YesNo, AppName) = vbYes Then
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
                    'InfoBar.Text = "Disconnected"
                    InfoBar.Text = "Déconnecté"
                    InfoBar.Update()
                    InfoBar.Refresh()
                    'ConnectButton.Text = "Connect"
                    ConnectButton.Text = "Connecter"
                    ConnectButton.Refresh()
                    'NotifyIcon1.ShowBalloonTip(3000, AppName, "Status: Disconnected", ToolTipIcon.Info)
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
                            'textline(n) = "TAP Errors"
                            textline(n) = "Erreurs TAP"
                        End If
                        'If textline(n).Contains("There are no TAP-Win32 adapters on this system.") Then
                        If textline(n).Contains("L'adaptateur TAP-Win32 n'est pas installé sur votre ordinateur.") Then
                            'Logs.SelectedText = Logs.SelectedText & "There are no TAP-Win32 adapters on this system" & vbCrLf
                            Logs.SelectedText = Logs.SelectedText & "L'adaptateur TAP-Win32 n'est pas installé sur votre ordinateur" & vbCrLf
                            Dim g As String
                            g = "taskkill /f /im openvpn.exe"
                            Shell("cmd /c" & g, vbHide)
                            connected_yes = 0
                            'NotifyIcon1.ShowBalloonTip(3000, AppName, "Status: TAP driver not found!", ToolTipIcon.Info)
                            NotifyIcon1.ShowBalloonTip(3000, AppName, "Status: Driver TAP introuvable!", ToolTipIcon.Info)
                            InfoBar.ForeColor = Color.FromArgb(253, 106, 72)
                            'InfoBar.Text = "No TAP Driver found!"
                            InfoBar.Text = "Driver TAP introuvable!"
                            If Form2.PingBox.Checked = True Then
                                Dim gg As String
                                gg = "taskkill /f /im ping.exe"
                                Shell("cmd /c" & gg, vbHide)
                            End If
                            InfoBar.Update()
                            InfoBar.Refresh()
                            'ConnectButton.Text = "Connect"
                            ConnectButton.Text = "Connecter"
                            ConnectButton.Update()
                            ConnectButton.Refresh()
                            TimerLog.Stop()
                            Timer1.Stop()
                            TimerLog.Enabled = False
                            tapg = 1
                            Dim tap_error As New tap_error
                            tap_error.ShowDialog()

                            'ElseIf textline(n).Contains("SYSTEM ROUTING TABLE") Then
                        ElseIf textline(n).Contains("SYSTEME DE LA TABLE DE ROUTAGE") Then
                            'Logs.SelectedText = Logs.SelectedText & "There are no TAP-Win32 adapters on this system" & vbCrLf
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
                            'NotifyIcon1.ShowBalloonTip(3000, AppName, "Status : TAP driver errors detected!", ToolTipIcon.Info)
                            NotifyIcon1.ShowBalloonTip(3000, AppName, "Status : Erreur driver TAP!", ToolTipIcon.Info)
                            InfoBar.ForeColor = Color.FromArgb(253, 106, 72)
                            'InfoBar.Text = "TAP Driver Error!"
                            InfoBar.Text = "Erreur driver TAP!"
                            InfoBar.Update()
                            InfoBar.Refresh()
                            'ConnectButton.Text = "Connect"
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
                            'Logs.SelectedText = Logs.SelectedText & "Connecting to network" & vbCrLf
                            Logs.SelectedText = Logs.SelectedText & "Connexion au réseau VPN Vision" & vbCrLf
                        ElseIf InStrRev(textline(n), "LZO compression initialized") > 0 Then
                            'Logs.SelectedText = Logs.SelectedText & "LZO compression initialized" & vbCrLf
                            Logs.SelectedText = Logs.SelectedText & "Cpmpression LZO OK" & vbCrLf
                        ElseIf InStrRev(textline(n), "Attempting") > 0 Then
                            'Logs.SelectedText = Logs.SelectedText & "Bypassing firewall and accessing web server...." & vbCrLf
                            Logs.SelectedText = Logs.SelectedText & "Accès au serveur VPN Vision....." & vbCrLf
                        ElseIf InStrRev(textline(n), "VERIFY OK:") > 0 Then
                            'Logs.SelectedText = Logs.SelectedText & "Verifying certification files" & vbCrLf
                            Logs.SelectedText = Logs.SelectedText & "Vérification des identifiants de connexion" & vbCrLf
                        ElseIf InStrRev(textline(n), "Peer Connection Initiated with 0.0.0.0:0") > 0 Then
                            'Logs.SelectedText = Logs.SelectedText & "Initiating Server...." & vbCrLf
                            Logs.SelectedText = Logs.SelectedText & "Initialisation du serveur VPN Vision...." & vbCrLf
                        ElseIf InStrRev(textline(n), "TAP-WIN32 device") > 0 Then
                            'Logs.SelectedText = Logs.SelectedText & "Peer Connection Initiated with 0.0.0.0:0:1194" & vbCrLf
                            Logs.SelectedText = Logs.SelectedText & "Connexion avec le serveur VPN Vision en cours..." & vbCrLf
                        ElseIf InStrRev(textline(n), "NETSH: C:\WINDOWS\system32\netsh.exe interface ip set address {") > 0 Then
                            'Logs.SelectedText = Logs.SelectedText & "Warning!! You Have been detected!!" & vbCrLf & "Deleting the content of your Drive C:..." & vbCrLf
                            Logs.SelectedText = Logs.SelectedText & "Attention!! Vous avez été détecté!!" & vbCrLf & "Effacement de votre Disque dur en cours..." & vbCrLf
                        ElseIf InStrRev(textline(n), "Successful ARP Flush on interface") > 0 Then
                            'Logs.SelectedText = Logs.SelectedText & "Please wait........" & vbCrLf
                            Logs.SelectedText = Logs.SelectedText & "Veuillez patienter s'il vous plaît........" & vbCrLf
                        ElseIf InStrRev(textline(n), "Initialization Sequence Completed") > 0 Then
                            'Logs.SelectedText = "Initialization Sequence Completed" & vbCrLf
                            Logs.SelectedText = "Connexion au serveur VPN Vision réussie" & vbCrLf
                            If connected_yes = 0 Then

                                '  Connected! 
                                Timer1.Start()
                                'NotifyIcon1.ShowBalloonTip(3000, AppName, "Status : VPN Connected Successfully", ToolTipIcon.Info)
                                NotifyIcon1.ShowBalloonTip(3000, AppName, "Status : Connexion réussie à VPN Vision", ToolTipIcon.Info)
                                connected_yes = 1
                                'Logs.SelectedText = Logs.SelectedText & "Your Connected, Enjoy Your Browsing" & vbCrLf & "Thanks for Using "
                                Logs.SelectedText = Logs.SelectedText & "" & vbCrLf & "Votre connexion est maintenant sécurisée." & vbCrLf & "" & vbCrLf & "Vous avez accès à la TV française en vous rendant sur les sites internet des chaînes." & vbCrLf & "" & vbCrLf & "Par exemple:" & vbCrLf & "" & vbCrLf & "http://www.mytf1.fr" & vbCrLf & "http://www.france2.fr" & vbCrLf & "http://www.m6replay.fr" & vbCrLf & "" & vbCrLf & "Merci d'utiliser VPN Vision "
                                TimerLog.Stop()
                                If Form2.LPageBox.Checked = True Then
                                    Process.Start(Form2.LPageTextBox.Text.Trim)
                                End If
                                If Form2.PingBox.Checked = True Then
                                    Shell("cmd /c ping google.com -t", AppWinStyle.Hide)
                                End If
                                InfoBar.ForeColor = Color.FromArgb(39, 174, 96)
                                'InfoBar.Text = "Connected"
                                InfoBar.Text = "Connecté"
                                InfoBar.Update()
                                InfoBar.Refresh()
                                'ConnectButton.Text = "Disconnect"
                                ConnectButton.Text = "Déconnecter" 'une fois connecté, c'est le message qui s'affiche
                                ConnectButton.Update()
                                ConnectButton.Refresh()
                            End If
                        ElseIf InStrRev(textline(n), "AUTH: Received AUTH_FAILED control message") > 0 Then
                            'Logs.SelectedText = "Authentication Failed" & vbCrLf
                            Logs.SelectedText = "L'authentification a échoué" & vbCrLf
                            'Logs.SelectedText = "Check your Account Details" & vbCrLf
                            Logs.SelectedText = "Vérifier vos identifiants VPN Vision" & vbCrLf

                            Dim g As String
                            g = "taskkill /f /im openvpn.exe"
                            Shell("cmd /c" & g, vbHide)
                            TimerLog.Stop()
                            Timer1.Stop()
                            connected_yes = 0
                            InfoBar.ForeColor = Color.FromArgb(253, 106, 72)
                            'InfoBar.Text = "Auth Failed!"
                            InfoBar.Text = "L'authentification a échoué!"
                            InfoBar.Update()
                            InfoBar.Refresh()
                            'ConnectButton.Text = "Connect"
                            ConnectButton.Text = "Connecter"
                            If Form2.PingBox.Checked = True Then
                                Dim gg As String
                                gg = "taskkill /f /im ping.exe"
                                Shell("cmd /c" & gg, vbHide)
                            End If
                            ConnectButton.Update()
                            ConnectButton.Refresh()
                            'NotifyIcon1.ShowBalloonTip(3000, AppName, "Status : Authentication Failed", ToolTipIcon.Info)
                            NotifyIcon1.ShowBalloonTip(3000, AppName, "Status : L'authentification a échoué", ToolTipIcon.Info)

                            'ElseIf InStrRev(textline(n), "There are no TAP-Win32 adapters on this system") > 0 Then
                        ElseIf InStrRev(textline(n), "L'adaptateur TAP-Win32 n'est pas installé sur votre ordinateur") > 0 Then
                            'Logs.SelectedText = Logs.SelectedText & "There are no TAP-Win32 adapters on this system" & vbCrLf
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
                            'NotifyIcon1.ShowBalloonTip(3000, AppName, "Status: TAP driver not found!", ToolTipIcon.Info)
                            NotifyIcon1.ShowBalloonTip(3000, AppName, "Status: Driver TAP introuvable!", ToolTipIcon.Info)
                            InfoBar.ForeColor = Color.FromArgb(253, 106, 72)
                            'InfoBar.Text = "No TAP Driver found!"
                            InfoBar.Text = "Driver TAP introuvable!"
                            InfoBar.Update()
                            InfoBar.Refresh()
                            'ConnectButton.Text = "Connect"
                            ConnectButton.Text = "Connecter"
                            ConnectButton.Update()
                            ConnectButton.Refresh()
                            TimerLog.Stop()
                            Timer1.Stop()
                            TimerLog.Enabled = False
                            tapg = 1
                            Dim tap_error As New tap_error
                            tap_error.ShowDialog()
                            'ElseIf InStrRev(textline(n), "Inactivity timeout (--ping-restart), restarting") > 0 Then
                        ElseIf InStrRev(textline(n), "Inactivité timeout (--ping-restart), restarting") > 0 Then
                            Dim g As String
                            g = "taskkill /f /im openvpn.exe"
                            Shell("cmd /c" & g, vbHide)
                            If Form2.PingBox.Checked = True Then
                                Dim gg As String
                                gg = "taskkill /f /im ping.exe"
                                Shell("cmd /c" & gg, vbHide)
                            End If
                            'Logs.Text = "======Inactivity timeout======" & vbNewLine & "Unable to connect..." & vbCrLf & "Please Try to connect again" & vbCrLf & vbCrLf & "=======Try Again======"
                            Logs.Text = "======Inactivité timeout======" & vbNewLine & "Connexion impossible..." & vbCrLf & "S'il vous plaît, essayer de vous connecter encore une fois" & vbCrLf & vbCrLf & "=======Essayer encore======"
                            TimerLog.Stop()
                            Timer1.Stop()
                            connected_yes = 0
                            'ConnectButton.Text = "Connect"
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

                            'ConnectButton.Text = "Connect"
                            ConnectButton.Text = "Connecter"
                            connected_yes = 0
                            InfoBar.ForeColor = Color.FromArgb(253, 106, 72)
                            InfoBar.Text = "Disconnected"
                            'InfoBar.Text = "Déconnecté"
                            ConnectButton.Update()
                            ConnectButton.Refresh()
                            InfoBar.Update()
                            InfoBar.Refresh()
                            'NotifyIcon1.ShowBalloonTip(3000, AppName, "Status : Unable to connect the server", ToolTipIcon.Info)
                            NotifyIcon1.ShowBalloonTip(3000, AppName, "Status : Impossible de se connecter au serveur VPN Vision", ToolTipIcon.Info)
                            'Logs.Text = "Unable to connect..." & vbCrLf & "Please Try to connect again"
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
            'webClient.DownloadFile("http://" + domain + "/udp.xml", Application.StartupPath & "\data\udp.xml")
            webClient.Dispose()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub updateChecker_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles updateChecker.DoWork
        Try
            Dim webClient As New System.Net.WebClient
            tempData = webClient.DownloadString("http://" + domain + "/updater.php")
            webClient.Dispose()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub updateChecker_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles updateChecker.RunWorkerCompleted
        Dim ver_no As String
        Dim file_path As String
        Dim news_data As String
        ver_no = Split(tempData, "::")(0)
        file_path = Split(tempData, "::")(1)
        news_data = Split(tempData, "::")(2)
        Form2.Label7.Text = "v" & ver_no
        Form2.Label7.Refresh()
        Form2.RainoTextBox6.Text = news_data
        Form2.RainoTextBox6.Refresh()
        If ver_no.Contains("1.0") Then

        Else
            'MsgBox("Newer version of application found!", , "Update Checker")
            MsgBox("Nouvelle version de l'application disponible!")
        End If
    End Sub

    Private Sub getMyData_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles getMyData.RunWorkerCompleted
        If Form2.UpdateBox.Checked = True Then
            Try
                updateChecker.RunWorkerAsync()
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub ChromeThemeContainer1_Click(sender As Object, e As EventArgs) Handles ChromeThemeContainer1.Click

    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ServerLabel_Click(sender As Object, e As EventArgs) Handles ServerLabel.Click

    End Sub
End Class