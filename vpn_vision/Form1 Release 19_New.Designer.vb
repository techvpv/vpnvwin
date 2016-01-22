<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

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

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ShowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HideToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TimerLog = New System.Windows.Forms.Timer(Me.components)
        Me.getMyData = New System.ComponentModel.BackgroundWorker()
        Me.updateChecker = New System.ComponentModel.BackgroundWorker()
        Me.ChromeThemeContainer1 = New VPN_Vision.ChromeThemeContainer()
        Me.LogButton = New VPN_Vision.ChromeButton()
        Me.Logs = New System.Windows.Forms.RichTextBox()
        Me.TwitterBox = New System.Windows.Forms.PictureBox()
        Me.FacebookBox = New System.Windows.Forms.PictureBox()
        Me.CopyrightBox = New System.Windows.Forms.Label()
        Me.ChromeSeparator1 = New VPN_Vision.ChromeSeparator()
        Me.ServerLabel = New System.Windows.Forms.Label()
        Me.ServersBox = New VPN_Vision.FlatCombo()
        Me.FlatGroupBox1 = New VPN_Vision.FlatGroupBox()
        Me.RecBox = New System.Windows.Forms.Label()
        Me.SentBox = New System.Windows.Forms.Label()
        Me.AboutButton = New VPN_Vision.FlatButton()
        Me.RecLabel = New System.Windows.Forms.Label()
        Me.SentLabel = New System.Windows.Forms.Label()
        Me.InfoLabel = New System.Windows.Forms.Label()
        Me.InfoBar = New System.Windows.Forms.Label()
        Me.SettingsButton = New VPN_Vision.FlatButton()
        Me.ConnectButton = New VPN_Vision.FlatButton()
        Me.IconBox = New System.Windows.Forms.PictureBox()
        Me.LogoBox = New System.Windows.Forms.PictureBox()
        Me.ChromeSeparator2 = New VPN_Vision.ChromeSeparator()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.ChromeThemeContainer1.SuspendLayout()
        CType(Me.TwitterBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FacebookBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlatGroupBox1.SuspendLayout()
        CType(Me.IconBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LogoBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "VPN Vision"
        Me.NotifyIcon1.Visible = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ShowToolStripMenuItem, Me.HideToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(104, 70)
        '
        'ShowToolStripMenuItem
        '
        Me.ShowToolStripMenuItem.Name = "ShowToolStripMenuItem"
        Me.ShowToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.ShowToolStripMenuItem.Text = "Show"
        '
        'HideToolStripMenuItem
        '
        Me.HideToolStripMenuItem.Name = "HideToolStripMenuItem"
        Me.HideToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.HideToolStripMenuItem.Text = "Hide"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'Timer1
        '
        '
        'TimerLog
        '
        '
        'getMyData
        '
        '
        'updateChecker
        '
        '
        'ChromeThemeContainer1
        '
        Me.ChromeThemeContainer1.BackColor = System.Drawing.Color.White
        Me.ChromeThemeContainer1.BorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.ChromeThemeContainer1.Controls.Add(Me.LogButton)
        Me.ChromeThemeContainer1.Controls.Add(Me.Logs)
        Me.ChromeThemeContainer1.Controls.Add(Me.TwitterBox)
        Me.ChromeThemeContainer1.Controls.Add(Me.FacebookBox)
        Me.ChromeThemeContainer1.Controls.Add(Me.CopyrightBox)
        Me.ChromeThemeContainer1.Controls.Add(Me.ChromeSeparator1)
        Me.ChromeThemeContainer1.Controls.Add(Me.ServerLabel)
        Me.ChromeThemeContainer1.Controls.Add(Me.ServersBox)
        Me.ChromeThemeContainer1.Controls.Add(Me.FlatGroupBox1)
        Me.ChromeThemeContainer1.Controls.Add(Me.IconBox)
        Me.ChromeThemeContainer1.Controls.Add(Me.LogoBox)
        Me.ChromeThemeContainer1.Controls.Add(Me.ChromeSeparator2)
        Me.ChromeThemeContainer1.Customization = "AAAA/1paWv9ycnL/"
        Me.ChromeThemeContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ChromeThemeContainer1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ChromeThemeContainer1.Image = Nothing
        Me.ChromeThemeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ChromeThemeContainer1.Movable = True
        Me.ChromeThemeContainer1.Name = "ChromeThemeContainer1"
        Me.ChromeThemeContainer1.NoRounding = False
        Me.ChromeThemeContainer1.Sizable = False
        Me.ChromeThemeContainer1.Size = New System.Drawing.Size(338, 432)
        Me.ChromeThemeContainer1.SmartBounds = True
        Me.ChromeThemeContainer1.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ChromeThemeContainer1.TabIndex = 0
        Me.ChromeThemeContainer1.Text = "    VPN Vision"
        Me.ChromeThemeContainer1.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.ChromeThemeContainer1.Transparent = False
        '
        'LogButton
        '
        Me.LogButton.Customization = "7e3t//Ly8v/r6+v/5ubm/+vr6//f39//p6en/zw8PP8UFBT/gICA/w=="
        Me.LogButton.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.LogButton.Image = Nothing
        Me.LogButton.Location = New System.Drawing.Point(314, 167)
        Me.LogButton.Name = "LogButton"
        Me.LogButton.NoRounding = False
        Me.LogButton.Size = New System.Drawing.Size(21, 23)
        Me.LogButton.TabIndex = 28
        Me.LogButton.Text = ">"
        Me.LogButton.Transparent = False
        '
        'Logs
        '
        Me.Logs.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Logs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Logs.Location = New System.Drawing.Point(338, 31)
        Me.Logs.Name = "Logs"
        Me.Logs.Size = New System.Drawing.Size(307, 398)
        Me.Logs.TabIndex = 27
        Me.Logs.Text = ""
        '
        'TwitterBox
        '
        Me.TwitterBox.Image = Global.VPN_Vision.My.Resources.Resources.Twitter_32
        Me.TwitterBox.Location = New System.Drawing.Point(295, 401)
        Me.TwitterBox.Name = "TwitterBox"
        Me.TwitterBox.Size = New System.Drawing.Size(24, 24)
        Me.TwitterBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.TwitterBox.TabIndex = 25
        Me.TwitterBox.TabStop = False
        '
        'FacebookBox
        '
        Me.FacebookBox.Image = Global.VPN_Vision.My.Resources.Resources.Facebook_32
        Me.FacebookBox.Location = New System.Drawing.Point(265, 401)
        Me.FacebookBox.Name = "FacebookBox"
        Me.FacebookBox.Size = New System.Drawing.Size(24, 24)
        Me.FacebookBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.FacebookBox.TabIndex = 24
        Me.FacebookBox.TabStop = False
        '
        'CopyrightBox
        '
        Me.CopyrightBox.AutoSize = True
        Me.CopyrightBox.BackColor = System.Drawing.Color.Transparent
        Me.CopyrightBox.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CopyrightBox.ForeColor = System.Drawing.Color.Gray
        Me.CopyrightBox.Location = New System.Drawing.Point(32, 407)
        Me.CopyrightBox.Name = "CopyrightBox"
        Me.CopyrightBox.Size = New System.Drawing.Size(181, 15)
        Me.CopyrightBox.TabIndex = 23
        Me.CopyrightBox.Text = "Pelgo Systems SAS - VPN Vision"
        '
        'ChromeSeparator1
        '
        Me.ChromeSeparator1.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.ChromeSeparator1.Colors = New VPN_Vision.Bloom(-1) {}
        Me.ChromeSeparator1.Customization = ""
        Me.ChromeSeparator1.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.ChromeSeparator1.Image = Nothing
        Me.ChromeSeparator1.Location = New System.Drawing.Point(80, 149)
        Me.ChromeSeparator1.Name = "ChromeSeparator1"
        Me.ChromeSeparator1.NoRounding = False
        Me.ChromeSeparator1.Size = New System.Drawing.Size(245, 1)
        Me.ChromeSeparator1.TabIndex = 7
        Me.ChromeSeparator1.Text = "ChromeSeparator1"
        Me.ChromeSeparator1.Transparent = False
        '
        'ServerLabel
        '
        Me.ServerLabel.AutoSize = True
        Me.ServerLabel.BackColor = System.Drawing.Color.Transparent
        Me.ServerLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ServerLabel.Location = New System.Drawing.Point(9, 140)
        Me.ServerLabel.Name = "ServerLabel"
        Me.ServerLabel.Size = New System.Drawing.Size(74, 16)
        Me.ServerLabel.TabIndex = 6
        Me.ServerLabel.Text = "Serveurs:"
        '
        'ServersBox
        '
        Me.ServersBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ServersBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ServersBox.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.ServersBox.FormattingEnabled = True
        Me.ServersBox.ItemHeight = 20
        Me.ServersBox.Location = New System.Drawing.Point(13, 165)
        Me.ServersBox.Name = "ServersBox"
        Me.ServersBox.Size = New System.Drawing.Size(297, 26)
        Me.ServersBox.TabIndex = 4
        '
        'FlatGroupBox1
        '
        Me.FlatGroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.FlatGroupBox1.Controls.Add(Me.RecBox)
        Me.FlatGroupBox1.Controls.Add(Me.SentBox)
        Me.FlatGroupBox1.Controls.Add(Me.AboutButton)
        Me.FlatGroupBox1.Controls.Add(Me.RecLabel)
        Me.FlatGroupBox1.Controls.Add(Me.SentLabel)
        Me.FlatGroupBox1.Controls.Add(Me.InfoLabel)
        Me.FlatGroupBox1.Controls.Add(Me.InfoBar)
        Me.FlatGroupBox1.Controls.Add(Me.SettingsButton)
        Me.FlatGroupBox1.Controls.Add(Me.ConnectButton)
        Me.FlatGroupBox1.Location = New System.Drawing.Point(0, 266)
        Me.FlatGroupBox1.Name = "FlatGroupBox1"
        Me.FlatGroupBox1.Size = New System.Drawing.Size(338, 129)
        Me.FlatGroupBox1.TabIndex = 3
        Me.FlatGroupBox1.Text = "FlatGroupBox1"
        '
        'RecBox
        '
        Me.RecBox.AutoSize = True
        Me.RecBox.BackColor = System.Drawing.Color.Transparent
        Me.RecBox.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RecBox.Location = New System.Drawing.Point(93, 62)
        Me.RecBox.Name = "RecBox"
        Me.RecBox.Size = New System.Drawing.Size(48, 14)
        Me.RecBox.TabIndex = 25
        Me.RecBox.Text = "0.00 Mo"
        '
        'SentBox
        '
        Me.SentBox.AutoSize = True
        Me.SentBox.BackColor = System.Drawing.Color.Transparent
        Me.SentBox.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SentBox.Location = New System.Drawing.Point(93, 39)
        Me.SentBox.Name = "SentBox"
        Me.SentBox.Size = New System.Drawing.Size(48, 14)
        Me.SentBox.TabIndex = 24
        Me.SentBox.Text = "0.00 Mo"
        '
        'AboutButton
        '
        Me.AboutButton.ButtonStyle = VPN_Vision.FlatButton.Style.Blue
        Me.AboutButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.AboutButton.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.AboutButton.Image = Nothing
        Me.AboutButton.Location = New System.Drawing.Point(238, 93)
        Me.AboutButton.Name = "AboutButton"
        Me.AboutButton.RoundedCorners = False
        Me.AboutButton.Size = New System.Drawing.Size(81, 26)
        Me.AboutButton.TabIndex = 11
        Me.AboutButton.Text = "A Propos"
        '
        'RecLabel
        '
        Me.RecLabel.AutoSize = True
        Me.RecLabel.BackColor = System.Drawing.Color.Transparent
        Me.RecLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RecLabel.Location = New System.Drawing.Point(27, 62)
        Me.RecLabel.Name = "RecLabel"
        Me.RecLabel.Size = New System.Drawing.Size(47, 14)
        Me.RecLabel.TabIndex = 10
        Me.RecLabel.Text = "Reçus: "
        '
        'SentLabel
        '
        Me.SentLabel.AutoSize = True
        Me.SentLabel.BackColor = System.Drawing.Color.Transparent
        Me.SentLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SentLabel.Location = New System.Drawing.Point(27, 39)
        Me.SentLabel.Name = "SentLabel"
        Me.SentLabel.Size = New System.Drawing.Size(59, 14)
        Me.SentLabel.TabIndex = 9
        Me.SentLabel.Text = "Envoyés: "
        '
        'InfoLabel
        '
        Me.InfoLabel.AutoSize = True
        Me.InfoLabel.BackColor = System.Drawing.Color.Transparent
        Me.InfoLabel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InfoLabel.Location = New System.Drawing.Point(27, 15)
        Me.InfoLabel.Name = "InfoLabel"
        Me.InfoLabel.Size = New System.Drawing.Size(48, 14)
        Me.InfoLabel.TabIndex = 8
        Me.InfoLabel.Text = "Status: "
        '
        'InfoBar
        '
        Me.InfoBar.AutoSize = True
        Me.InfoBar.BackColor = System.Drawing.Color.Transparent
        Me.InfoBar.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InfoBar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(72, Byte), Integer))
        Me.InfoBar.Location = New System.Drawing.Point(93, 15)
        Me.InfoBar.Name = "InfoBar"
        Me.InfoBar.Size = New System.Drawing.Size(78, 15)
        Me.InfoBar.TabIndex = 7
        Me.InfoBar.Text = "Déconnecté!"
        '
        'SettingsButton
        '
        Me.SettingsButton.ButtonStyle = VPN_Vision.FlatButton.Style.Blue
        Me.SettingsButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.SettingsButton.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.SettingsButton.Image = Nothing
        Me.SettingsButton.Location = New System.Drawing.Point(136, 93)
        Me.SettingsButton.Name = "SettingsButton"
        Me.SettingsButton.RoundedCorners = False
        Me.SettingsButton.Size = New System.Drawing.Size(81, 26)
        Me.SettingsButton.TabIndex = 6
        Me.SettingsButton.Text = "Paramètres"
        '
        'ConnectButton
        '
        Me.ConnectButton.ButtonStyle = VPN_Vision.FlatButton.Style.Blue
        Me.ConnectButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ConnectButton.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.ConnectButton.Image = Nothing
        Me.ConnectButton.Location = New System.Drawing.Point(30, 93)
        Me.ConnectButton.Name = "ConnectButton"
        Me.ConnectButton.RoundedCorners = False
        Me.ConnectButton.Size = New System.Drawing.Size(81, 26)
        Me.ConnectButton.TabIndex = 5
        Me.ConnectButton.Text = "Connecter"
        '
        'IconBox
        '
        Me.IconBox.Image = Global.VPN_Vision.My.Resources.Resources.icon
        Me.IconBox.Location = New System.Drawing.Point(5, 9)
        Me.IconBox.Name = "IconBox"
        Me.IconBox.Size = New System.Drawing.Size(18, 18)
        Me.IconBox.TabIndex = 2
        Me.IconBox.TabStop = False
        '
        'LogoBox
        '
        Me.LogoBox.Image = Global.VPN_Vision.My.Resources.Resources.cyber_back
        Me.LogoBox.Location = New System.Drawing.Point(0, 31)
        Me.LogoBox.Name = "LogoBox"
        Me.LogoBox.Size = New System.Drawing.Size(338, 90)
        Me.LogoBox.TabIndex = 1
        Me.LogoBox.TabStop = False
        '
        'ChromeSeparator2
        '
        Me.ChromeSeparator2.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.ChromeSeparator2.Colors = New VPN_Vision.Bloom(-1) {}
        Me.ChromeSeparator2.Customization = ""
        Me.ChromeSeparator2.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.ChromeSeparator2.Image = Nothing
        Me.ChromeSeparator2.Location = New System.Drawing.Point(13, 203)
        Me.ChromeSeparator2.Name = "ChromeSeparator2"
        Me.ChromeSeparator2.NoRounding = False
        Me.ChromeSeparator2.Size = New System.Drawing.Size(317, 1)
        Me.ChromeSeparator2.TabIndex = 9
        Me.ChromeSeparator2.Text = "ChromeSeparator2"
        Me.ChromeSeparator2.Transparent = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(338, 432)
        Me.Controls.Add(Me.ChromeThemeContainer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "VPN Vision"
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ChromeThemeContainer1.ResumeLayout(False)
        Me.ChromeThemeContainer1.PerformLayout()
        CType(Me.TwitterBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FacebookBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlatGroupBox1.ResumeLayout(False)
        Me.FlatGroupBox1.PerformLayout()
        CType(Me.IconBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LogoBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ChromeThemeContainer1 As VPN_Vision.ChromeThemeContainer
    Friend WithEvents LogoBox As System.Windows.Forms.PictureBox
    Friend WithEvents IconBox As System.Windows.Forms.PictureBox
    Friend WithEvents FlatGroupBox1 As VPN_Vision.FlatGroupBox
    Friend WithEvents ServersBox As VPN_Vision.FlatCombo
    Friend WithEvents ConnectButton As VPN_Vision.FlatButton
    Friend WithEvents ServerLabel As System.Windows.Forms.Label
    Friend WithEvents ChromeSeparator1 As VPN_Vision.ChromeSeparator
    Friend WithEvents ChromeSeparator2 As VPN_Vision.ChromeSeparator
    Friend WithEvents CopyrightBox As System.Windows.Forms.Label
    Friend WithEvents InfoLabel As System.Windows.Forms.Label
    Friend WithEvents InfoBar As System.Windows.Forms.Label
    Friend WithEvents SettingsButton As VPN_Vision.FlatButton
    Friend WithEvents RecBox As System.Windows.Forms.Label
    Friend WithEvents SentBox As System.Windows.Forms.Label
    Friend WithEvents AboutButton As VPN_Vision.FlatButton
    Friend WithEvents RecLabel As System.Windows.Forms.Label
    Friend WithEvents SentLabel As System.Windows.Forms.Label
    Friend WithEvents FacebookBox As System.Windows.Forms.PictureBox
    Friend WithEvents TwitterBox As System.Windows.Forms.PictureBox
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ShowToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HideToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Logs As System.Windows.Forms.RichTextBox
    Friend WithEvents LogButton As VPN_Vision.ChromeButton
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents TimerLog As System.Windows.Forms.Timer
    Friend WithEvents getMyData As System.ComponentModel.BackgroundWorker
    Friend WithEvents updateChecker As System.ComponentModel.BackgroundWorker
End Class
