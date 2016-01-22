<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form2))
        Me.ChromeThemeContainer1 = New VPN_Vision.ChromeThemeContainer()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.FlatTabControl1 = New VPN_Vision.FlatTabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.PingBox = New VPN_Vision.FlatCheckbox()
        Me.FlatLabel3 = New VPN_Vision.FlatLabel()
        Me.SaveButton1 = New VPN_Vision.FlatButton()
        Me.UpdateBox = New VPN_Vision.FlatCheckbox()
        Me.LPageTextBox = New VPN_Vision.RainoTextBox()
        Me.LPageBox = New VPN_Vision.FlatCheckbox()
        Me.StartBox = New VPN_Vision.FlatCheckbox()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.FlatLabel14 = New VPN_Vision.FlatLabel()
        Me.ChromeSeparator5 = New VPN_Vision.ChromeSeparator()
        Me.AccountLinkBox = New VPN_Vision.FlatLabel()
        Me.FlatLabel5 = New VPN_Vision.FlatLabel()
        Me.FlatLabel4 = New VPN_Vision.FlatLabel()
        Me.SaveButton3 = New VPN_Vision.FlatButton()
        Me.PasswordBox = New VPN_Vision.RainoTextBox()
        Me.UsernameBox = New VPN_Vision.RainoTextBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.FlatGroupBox2 = New VPN_Vision.FlatGroupBox()
        Me.RainoTextBox6 = New VPN_Vision.RainoTextBox()
        Me.ChromeSeparator1 = New VPN_Vision.ChromeSeparator()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.FlatGroupBox1 = New VPN_Vision.FlatGroupBox()
        Me.UpdateButton = New VPN_Vision.FlatButton()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.SaveButton2 = New VPN_Vision.FlatButton()
        Me.FlatLabel13 = New VPN_Vision.FlatLabel()
        Me.FlatLabel12 = New VPN_Vision.FlatLabel()
        Me.FlatLabel11 = New VPN_Vision.FlatLabel()
        Me.FlatLabel10 = New VPN_Vision.FlatLabel()
        Me.ChromeSeparator4 = New VPN_Vision.ChromeSeparator()
        Me.FlatLabel9 = New VPN_Vision.FlatLabel()
        Me.FlatLabel8 = New VPN_Vision.FlatLabel()
        Me.ChromeSeparator3 = New VPN_Vision.ChromeSeparator()
        Me.FlatLabel7 = New VPN_Vision.FlatLabel()
        Me.ChromeSeparator2 = New VPN_Vision.ChromeSeparator()
        Me.UDP_PortBox = New VPN_Vision.RainoTextBox()
        Me.FlatLabel2 = New VPN_Vision.FlatLabel()
        Me.FlatLabel1 = New VPN_Vision.FlatLabel()
        Me.BindBox = New VPN_Vision.RainoTextBox()
        Me.TCP_PortBox = New VPN_Vision.RainoTextBox()
        Me.ChromeThemeContainer1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlatTabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.FlatGroupBox2.SuspendLayout()
        Me.FlatGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ChromeThemeContainer1
        '
        Me.ChromeThemeContainer1.BackColor = System.Drawing.Color.White
        Me.ChromeThemeContainer1.BorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.ChromeThemeContainer1.Controls.Add(Me.PictureBox1)
        Me.ChromeThemeContainer1.Controls.Add(Me.FlatTabControl1)
        Me.ChromeThemeContainer1.Customization = "AAAA/1paWv9ycnL/"
        Me.ChromeThemeContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ChromeThemeContainer1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ChromeThemeContainer1.Image = Nothing
        Me.ChromeThemeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ChromeThemeContainer1.Movable = True
        Me.ChromeThemeContainer1.Name = "ChromeThemeContainer1"
        Me.ChromeThemeContainer1.NoRounding = False
        Me.ChromeThemeContainer1.Sizable = False
        Me.ChromeThemeContainer1.Size = New System.Drawing.Size(526, 328)
        Me.ChromeThemeContainer1.SmartBounds = True
        Me.ChromeThemeContainer1.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ChromeThemeContainer1.TabIndex = 0
        Me.ChromeThemeContainer1.Text = "    Paramètres"
        Me.ChromeThemeContainer1.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.ChromeThemeContainer1.Transparent = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.VPN_Vision.My.Resources.Resources.icon
        Me.PictureBox1.Location = New System.Drawing.Point(7, 9)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'FlatTabControl1
        '
        Me.FlatTabControl1.Controls.Add(Me.TabPage1)
        Me.FlatTabControl1.Controls.Add(Me.TabPage4)
        Me.FlatTabControl1.Controls.Add(Me.TabPage2)
        Me.FlatTabControl1.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.FlatTabControl1.ItemSize = New System.Drawing.Size(0, 30)
        Me.FlatTabControl1.Location = New System.Drawing.Point(3, 31)
        Me.FlatTabControl1.Name = "FlatTabControl1"
        Me.FlatTabControl1.SelectedIndex = 0
        Me.FlatTabControl1.Size = New System.Drawing.Size(523, 294)
        Me.FlatTabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.White
        Me.TabPage1.Controls.Add(Me.PingBox)
        Me.TabPage1.Controls.Add(Me.FlatLabel3)
        Me.TabPage1.Controls.Add(Me.SaveButton1)
        Me.TabPage1.Controls.Add(Me.UpdateBox)
        Me.TabPage1.Controls.Add(Me.LPageTextBox)
        Me.TabPage1.Controls.Add(Me.LPageBox)
        Me.TabPage1.Controls.Add(Me.StartBox)
        Me.TabPage1.Location = New System.Drawing.Point(4, 34)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(515, 256)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Options"
        '
        'PingBox
        '
        Me.PingBox.Checked = False
        Me.PingBox.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.PingBox.Location = New System.Drawing.Point(45, 33)
        Me.PingBox.Name = "PingBox"
        Me.PingBox.Size = New System.Drawing.Size(401, 20)
        Me.PingBox.TabIndex = 18
        Me.PingBox.Text = "Améliorer votre connection Internet"
        '
        'FlatLabel3
        '
        Me.FlatLabel3.AutoSize = True
        Me.FlatLabel3.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.FlatLabel3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(135, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(135, Byte), Integer))
        Me.FlatLabel3.Location = New System.Drawing.Point(50, 180)
        Me.FlatLabel3.Name = "FlatLabel3"
        Me.FlatLabel3.Size = New System.Drawing.Size(34, 13)
        Me.FlatLabel3.TabIndex = 17
        Me.FlatLabel3.Text = "URL:"
        '
        'SaveButton1
        '
        Me.SaveButton1.ButtonStyle = VPN_Vision.FlatButton.Style.Blue
        Me.SaveButton1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.SaveButton1.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.SaveButton1.Image = Nothing
        Me.SaveButton1.Location = New System.Drawing.Point(401, 217)
        Me.SaveButton1.Name = "SaveButton1"
        Me.SaveButton1.RoundedCorners = False
        Me.SaveButton1.Size = New System.Drawing.Size(65, 26)
        Me.SaveButton1.TabIndex = 10
        Me.SaveButton1.Text = "Sauver"
        '
        'UpdateBox
        '
        Me.UpdateBox.Checked = False
        Me.UpdateBox.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.UpdateBox.Location = New System.Drawing.Point(45, 101)
        Me.UpdateBox.Name = "UpdateBox"
        Me.UpdateBox.Size = New System.Drawing.Size(401, 20)
        Me.UpdateBox.TabIndex = 9
        Me.UpdateBox.Text = "Prévenir de la disponibilité d'une mise à jour"
        '
        'LPageTextBox
        '
        Me.LPageTextBox.BackColor = System.Drawing.Color.Transparent
        Me.LPageTextBox.BackgroundColour = System.Drawing.Color.White
        Me.LPageTextBox.BorderColour = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.LPageTextBox.Enabled = False
        Me.LPageTextBox.Location = New System.Drawing.Point(94, 172)
        Me.LPageTextBox.MaxLength = 32767
        Me.LPageTextBox.Multiline = False
        Me.LPageTextBox.Name = "LPageTextBox"
        Me.LPageTextBox.ReadOnly = False
        Me.LPageTextBox.Size = New System.Drawing.Size(342, 26)
        Me.LPageTextBox.Style = VPN_Vision.RainoTextBox.Styles.Normal
        Me.LPageTextBox.TabIndex = 2
        Me.LPageTextBox.Text = "http://www.vpnvision.com/tester-votre-ip/"
        Me.LPageTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.LPageTextBox.TextColour = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.LPageTextBox.UseSystemPasswordChar = False
        '
        'LPageBox
        '
        Me.LPageBox.Checked = True
        Me.LPageBox.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.LPageBox.Location = New System.Drawing.Point(45, 134)
        Me.LPageBox.Name = "LPageBox"
        Me.LPageBox.Size = New System.Drawing.Size(401, 20)
        Me.LPageBox.TabIndex = 1
        Me.LPageBox.Text = "Ouvrir la page internet VPN Vision"
        '
        'StartBox
        '
        Me.StartBox.Checked = False
        Me.StartBox.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.StartBox.Location = New System.Drawing.Point(45, 68)
        Me.StartBox.Name = "StartBox"
        Me.StartBox.Size = New System.Drawing.Size(401, 20)
        Me.StartBox.TabIndex = 0
        Me.StartBox.Text = "Démarrer VPN Vision avec Windows"
        '
        'TabPage4
        '
        Me.TabPage4.BackColor = System.Drawing.Color.White
        Me.TabPage4.Controls.Add(Me.FlatLabel14)
        Me.TabPage4.Controls.Add(Me.ChromeSeparator5)
        Me.TabPage4.Controls.Add(Me.AccountLinkBox)
        Me.TabPage4.Controls.Add(Me.FlatLabel5)
        Me.TabPage4.Controls.Add(Me.FlatLabel4)
        Me.TabPage4.Controls.Add(Me.SaveButton3)
        Me.TabPage4.Controls.Add(Me.PasswordBox)
        Me.TabPage4.Controls.Add(Me.UsernameBox)
        Me.TabPage4.Location = New System.Drawing.Point(4, 34)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(515, 256)
        Me.TabPage4.TabIndex = 1
        Me.TabPage4.Text = "Identifiants"
        '
        'FlatLabel14
        '
        Me.FlatLabel14.AutoSize = True
        Me.FlatLabel14.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.FlatLabel14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(135, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(135, Byte), Integer))
        Me.FlatLabel14.Location = New System.Drawing.Point(17, 24)
        Me.FlatLabel14.Name = "FlatLabel14"
        Me.FlatLabel14.Size = New System.Drawing.Size(94, 13)
        Me.FlatLabel14.TabIndex = 25
        Me.FlatLabel14.Text = "Vos identifiants"
        '
        'ChromeSeparator5
        '
        Me.ChromeSeparator5.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.ChromeSeparator5.Colors = New VPN_Vision.Bloom(-1) {}
        Me.ChromeSeparator5.Customization = ""
        Me.ChromeSeparator5.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.ChromeSeparator5.Image = Nothing
        Me.ChromeSeparator5.Location = New System.Drawing.Point(115, 31)
        Me.ChromeSeparator5.Name = "ChromeSeparator5"
        Me.ChromeSeparator5.NoRounding = False
        Me.ChromeSeparator5.Size = New System.Drawing.Size(382, 1)
        Me.ChromeSeparator5.TabIndex = 24
        Me.ChromeSeparator5.Text = "ChromeSeparator5"
        Me.ChromeSeparator5.Transparent = False
        '
        'AccountLinkBox
        '
        Me.AccountLinkBox.AutoSize = True
        Me.AccountLinkBox.Cursor = System.Windows.Forms.Cursors.Hand
        Me.AccountLinkBox.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AccountLinkBox.ForeColor = System.Drawing.Color.SteelBlue
        Me.AccountLinkBox.Location = New System.Drawing.Point(213, 173)
        Me.AccountLinkBox.Name = "AccountLinkBox"
        Me.AccountLinkBox.Size = New System.Drawing.Size(265, 13)
        Me.AccountLinkBox.TabIndex = 12
        Me.AccountLinkBox.Text = "Pas de compte? Enregistrez-vous maintenant"
        '
        'FlatLabel5
        '
        Me.FlatLabel5.AutoSize = True
        Me.FlatLabel5.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.FlatLabel5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(135, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(135, Byte), Integer))
        Me.FlatLabel5.Location = New System.Drawing.Point(24, 133)
        Me.FlatLabel5.Name = "FlatLabel5"
        Me.FlatLabel5.Size = New System.Drawing.Size(70, 13)
        Me.FlatLabel5.TabIndex = 11
        Me.FlatLabel5.Text = "Password: "
        '
        'FlatLabel4
        '
        Me.FlatLabel4.AutoSize = True
        Me.FlatLabel4.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.FlatLabel4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(135, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(135, Byte), Integer))
        Me.FlatLabel4.Location = New System.Drawing.Point(24, 81)
        Me.FlatLabel4.Name = "FlatLabel4"
        Me.FlatLabel4.Size = New System.Drawing.Size(74, 13)
        Me.FlatLabel4.TabIndex = 10
        Me.FlatLabel4.Text = "Username: "
        '
        'SaveButton3
        '
        Me.SaveButton3.ButtonStyle = VPN_Vision.FlatButton.Style.Blue
        Me.SaveButton3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.SaveButton3.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.SaveButton3.Image = Nothing
        Me.SaveButton3.Location = New System.Drawing.Point(417, 217)
        Me.SaveButton3.Name = "SaveButton3"
        Me.SaveButton3.RoundedCorners = False
        Me.SaveButton3.Size = New System.Drawing.Size(65, 26)
        Me.SaveButton3.TabIndex = 3
        Me.SaveButton3.Text = "Sauver"
        '
        'PasswordBox
        '
        Me.PasswordBox.BackColor = System.Drawing.Color.Transparent
        Me.PasswordBox.BackgroundColour = System.Drawing.Color.White
        Me.PasswordBox.BorderColour = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.PasswordBox.Location = New System.Drawing.Point(104, 127)
        Me.PasswordBox.MaxLength = 32767
        Me.PasswordBox.Multiline = False
        Me.PasswordBox.Name = "PasswordBox"
        Me.PasswordBox.ReadOnly = False
        Me.PasswordBox.Size = New System.Drawing.Size(375, 26)
        Me.PasswordBox.Style = VPN_Vision.RainoTextBox.Styles.Normal
        Me.PasswordBox.TabIndex = 2
        Me.PasswordBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.PasswordBox.TextColour = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.PasswordBox.UseSystemPasswordChar = True
        '
        'UsernameBox
        '
        Me.UsernameBox.BackColor = System.Drawing.Color.Transparent
        Me.UsernameBox.BackgroundColour = System.Drawing.Color.White
        Me.UsernameBox.BorderColour = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.UsernameBox.Location = New System.Drawing.Point(104, 73)
        Me.UsernameBox.MaxLength = 32767
        Me.UsernameBox.Multiline = False
        Me.UsernameBox.Name = "UsernameBox"
        Me.UsernameBox.ReadOnly = False
        Me.UsernameBox.Size = New System.Drawing.Size(375, 26)
        Me.UsernameBox.Style = VPN_Vision.RainoTextBox.Styles.Normal
        Me.UsernameBox.TabIndex = 1
        Me.UsernameBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.UsernameBox.TextColour = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.UsernameBox.UseSystemPasswordChar = False
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.White
        Me.TabPage2.Controls.Add(Me.FlatGroupBox2)
        Me.TabPage2.Controls.Add(Me.FlatGroupBox1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 34)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(515, 256)
        Me.TabPage2.TabIndex = 2
        Me.TabPage2.Text = "Update"
        '
        'FlatGroupBox2
        '
        Me.FlatGroupBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.FlatGroupBox2.Controls.Add(Me.RainoTextBox6)
        Me.FlatGroupBox2.Controls.Add(Me.ChromeSeparator1)
        Me.FlatGroupBox2.Controls.Add(Me.Label8)
        Me.FlatGroupBox2.Location = New System.Drawing.Point(19, 135)
        Me.FlatGroupBox2.Name = "FlatGroupBox2"
        Me.FlatGroupBox2.Size = New System.Drawing.Size(469, 106)
        Me.FlatGroupBox2.TabIndex = 1
        Me.FlatGroupBox2.Text = "FlatGroupBox2"
        '
        'RainoTextBox6
        '
        Me.RainoTextBox6.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.RainoTextBox6.BackgroundColour = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.RainoTextBox6.BorderColour = System.Drawing.Color.Transparent
        Me.RainoTextBox6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.RainoTextBox6.Location = New System.Drawing.Point(0, 31)
        Me.RainoTextBox6.MaxLength = 32767
        Me.RainoTextBox6.Multiline = True
        Me.RainoTextBox6.Name = "RainoTextBox6"
        Me.RainoTextBox6.ReadOnly = True
        Me.RainoTextBox6.Size = New System.Drawing.Size(469, 75)
        Me.RainoTextBox6.Style = VPN_Vision.RainoTextBox.Styles.Normal
        Me.RainoTextBox6.TabIndex = 12
        Me.RainoTextBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.RainoTextBox6.TextColour = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.RainoTextBox6.UseSystemPasswordChar = False
        '
        'ChromeSeparator1
        '
        Me.ChromeSeparator1.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.ChromeSeparator1.Colors = New VPN_Vision.Bloom(-1) {}
        Me.ChromeSeparator1.Customization = ""
        Me.ChromeSeparator1.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.ChromeSeparator1.Image = Nothing
        Me.ChromeSeparator1.Location = New System.Drawing.Point(2, 31)
        Me.ChromeSeparator1.Name = "ChromeSeparator1"
        Me.ChromeSeparator1.NoRounding = False
        Me.ChromeSeparator1.Size = New System.Drawing.Size(467, 1)
        Me.ChromeSeparator1.TabIndex = 11
        Me.ChromeSeparator1.Text = "ChromeSeparator1"
        Me.ChromeSeparator1.Transparent = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(36, 9)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(92, 16)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = "Les nouveautés"
        '
        'FlatGroupBox1
        '
        Me.FlatGroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.FlatGroupBox1.Controls.Add(Me.UpdateButton)
        Me.FlatGroupBox1.Controls.Add(Me.Label7)
        Me.FlatGroupBox1.Controls.Add(Me.Label6)
        Me.FlatGroupBox1.Controls.Add(Me.Label5)
        Me.FlatGroupBox1.Controls.Add(Me.Label4)
        Me.FlatGroupBox1.Location = New System.Drawing.Point(19, 23)
        Me.FlatGroupBox1.Name = "FlatGroupBox1"
        Me.FlatGroupBox1.Size = New System.Drawing.Size(469, 93)
        Me.FlatGroupBox1.TabIndex = 0
        Me.FlatGroupBox1.Text = "FlatGroupBox1"
        '
        'UpdateButton
        '
        Me.UpdateButton.ButtonStyle = VPN_Vision.FlatButton.Style.Blue
        Me.UpdateButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.UpdateButton.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.UpdateButton.Image = Nothing
        Me.UpdateButton.Location = New System.Drawing.Point(380, 52)
        Me.UpdateButton.Name = "UpdateButton"
        Me.UpdateButton.RoundedCorners = False
        Me.UpdateButton.Size = New System.Drawing.Size(65, 26)
        Me.UpdateButton.TabIndex = 13
        Me.UpdateButton.Text = "Update"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(148, 52)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(33, 16)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "-----"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(145, 21)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(36, 16)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "v1.0"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(36, 52)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(111, 16)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Dernière Version:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(36, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(105, 16)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Votre Version: "
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.White
        Me.TabPage3.Location = New System.Drawing.Point(4, 34)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(515, 256)
        Me.TabPage3.TabIndex = 3
        '
        'SaveButton2
        '
        Me.SaveButton2.ButtonStyle = VPN_Vision.FlatButton.Style.Blue
        Me.SaveButton2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.SaveButton2.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.SaveButton2.Image = Nothing
        Me.SaveButton2.Location = New System.Drawing.Point(0, 0)
        Me.SaveButton2.Name = "SaveButton2"
        Me.SaveButton2.RoundedCorners = False
        Me.SaveButton2.Size = New System.Drawing.Size(65, 26)
        Me.SaveButton2.TabIndex = 0
        '
        'FlatLabel13
        '
        Me.FlatLabel13.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.FlatLabel13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(135, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(135, Byte), Integer))
        Me.FlatLabel13.Location = New System.Drawing.Point(0, 0)
        Me.FlatLabel13.Name = "FlatLabel13"
        Me.FlatLabel13.Size = New System.Drawing.Size(100, 23)
        Me.FlatLabel13.TabIndex = 0
        '
        'FlatLabel12
        '
        Me.FlatLabel12.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.FlatLabel12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(135, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(135, Byte), Integer))
        Me.FlatLabel12.Location = New System.Drawing.Point(0, 0)
        Me.FlatLabel12.Name = "FlatLabel12"
        Me.FlatLabel12.Size = New System.Drawing.Size(100, 23)
        Me.FlatLabel12.TabIndex = 0
        '
        'FlatLabel11
        '
        Me.FlatLabel11.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.FlatLabel11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(135, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(135, Byte), Integer))
        Me.FlatLabel11.Location = New System.Drawing.Point(0, 0)
        Me.FlatLabel11.Name = "FlatLabel11"
        Me.FlatLabel11.Size = New System.Drawing.Size(100, 23)
        Me.FlatLabel11.TabIndex = 0
        '
        'FlatLabel10
        '
        Me.FlatLabel10.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.FlatLabel10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(135, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(135, Byte), Integer))
        Me.FlatLabel10.Location = New System.Drawing.Point(0, 0)
        Me.FlatLabel10.Name = "FlatLabel10"
        Me.FlatLabel10.Size = New System.Drawing.Size(100, 23)
        Me.FlatLabel10.TabIndex = 0
        '
        'ChromeSeparator4
        '
        Me.ChromeSeparator4.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.ChromeSeparator4.Colors = New VPN_Vision.Bloom(-1) {}
        Me.ChromeSeparator4.Customization = ""
        Me.ChromeSeparator4.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.ChromeSeparator4.Image = Nothing
        Me.ChromeSeparator4.Location = New System.Drawing.Point(0, 0)
        Me.ChromeSeparator4.Name = "ChromeSeparator4"
        Me.ChromeSeparator4.NoRounding = False
        Me.ChromeSeparator4.Size = New System.Drawing.Size(0, 0)
        Me.ChromeSeparator4.TabIndex = 0
        Me.ChromeSeparator4.Transparent = False
        '
        'FlatLabel9
        '
        Me.FlatLabel9.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.FlatLabel9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(135, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(135, Byte), Integer))
        Me.FlatLabel9.Location = New System.Drawing.Point(0, 0)
        Me.FlatLabel9.Name = "FlatLabel9"
        Me.FlatLabel9.Size = New System.Drawing.Size(100, 23)
        Me.FlatLabel9.TabIndex = 0
        '
        'FlatLabel8
        '
        Me.FlatLabel8.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.FlatLabel8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(135, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(135, Byte), Integer))
        Me.FlatLabel8.Location = New System.Drawing.Point(0, 0)
        Me.FlatLabel8.Name = "FlatLabel8"
        Me.FlatLabel8.Size = New System.Drawing.Size(100, 23)
        Me.FlatLabel8.TabIndex = 0
        '
        'ChromeSeparator3
        '
        Me.ChromeSeparator3.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.ChromeSeparator3.Colors = New VPN_Vision.Bloom(-1) {}
        Me.ChromeSeparator3.Customization = ""
        Me.ChromeSeparator3.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.ChromeSeparator3.Image = Nothing
        Me.ChromeSeparator3.Location = New System.Drawing.Point(0, 0)
        Me.ChromeSeparator3.Name = "ChromeSeparator3"
        Me.ChromeSeparator3.NoRounding = False
        Me.ChromeSeparator3.Size = New System.Drawing.Size(0, 0)
        Me.ChromeSeparator3.TabIndex = 0
        Me.ChromeSeparator3.Transparent = False
        '
        'FlatLabel7
        '
        Me.FlatLabel7.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.FlatLabel7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(135, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(135, Byte), Integer))
        Me.FlatLabel7.Location = New System.Drawing.Point(0, 0)
        Me.FlatLabel7.Name = "FlatLabel7"
        Me.FlatLabel7.Size = New System.Drawing.Size(100, 23)
        Me.FlatLabel7.TabIndex = 0
        '
        'ChromeSeparator2
        '
        Me.ChromeSeparator2.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.ChromeSeparator2.Colors = New VPN_Vision.Bloom(-1) {}
        Me.ChromeSeparator2.Customization = ""
        Me.ChromeSeparator2.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.ChromeSeparator2.Image = Nothing
        Me.ChromeSeparator2.Location = New System.Drawing.Point(0, 0)
        Me.ChromeSeparator2.Name = "ChromeSeparator2"
        Me.ChromeSeparator2.NoRounding = False
        Me.ChromeSeparator2.Size = New System.Drawing.Size(0, 0)
        Me.ChromeSeparator2.TabIndex = 0
        Me.ChromeSeparator2.Transparent = False
        '
        'UDP_PortBox
        '
        Me.UDP_PortBox.BackColor = System.Drawing.Color.Transparent
        Me.UDP_PortBox.BackgroundColour = System.Drawing.Color.White
        Me.UDP_PortBox.BorderColour = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.UDP_PortBox.Location = New System.Drawing.Point(0, 0)
        Me.UDP_PortBox.MaxLength = 32767
        Me.UDP_PortBox.Multiline = False
        Me.UDP_PortBox.Name = "UDP_PortBox"
        Me.UDP_PortBox.ReadOnly = False
        Me.UDP_PortBox.Size = New System.Drawing.Size(0, 26)
        Me.UDP_PortBox.Style = VPN_Vision.RainoTextBox.Styles.Normal
        Me.UDP_PortBox.TabIndex = 0
        Me.UDP_PortBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.UDP_PortBox.TextColour = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.UDP_PortBox.UseSystemPasswordChar = False
        '
        'FlatLabel2
        '
        Me.FlatLabel2.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.FlatLabel2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(135, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(135, Byte), Integer))
        Me.FlatLabel2.Location = New System.Drawing.Point(0, 0)
        Me.FlatLabel2.Name = "FlatLabel2"
        Me.FlatLabel2.Size = New System.Drawing.Size(100, 23)
        Me.FlatLabel2.TabIndex = 0
        '
        'FlatLabel1
        '
        Me.FlatLabel1.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.FlatLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(135, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(135, Byte), Integer))
        Me.FlatLabel1.Location = New System.Drawing.Point(0, 0)
        Me.FlatLabel1.Name = "FlatLabel1"
        Me.FlatLabel1.Size = New System.Drawing.Size(100, 23)
        Me.FlatLabel1.TabIndex = 0
        '
        'BindBox
        '
        Me.BindBox.BackColor = System.Drawing.Color.Transparent
        Me.BindBox.BackgroundColour = System.Drawing.Color.White
        Me.BindBox.BorderColour = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.BindBox.Location = New System.Drawing.Point(0, 0)
        Me.BindBox.MaxLength = 32767
        Me.BindBox.Multiline = False
        Me.BindBox.Name = "BindBox"
        Me.BindBox.ReadOnly = False
        Me.BindBox.Size = New System.Drawing.Size(0, 26)
        Me.BindBox.Style = VPN_Vision.RainoTextBox.Styles.Normal
        Me.BindBox.TabIndex = 0
        Me.BindBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.BindBox.TextColour = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.BindBox.UseSystemPasswordChar = False
        '
        'TCP_PortBox
        '
        Me.TCP_PortBox.BackColor = System.Drawing.Color.Transparent
        Me.TCP_PortBox.BackgroundColour = System.Drawing.Color.White
        Me.TCP_PortBox.BorderColour = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.TCP_PortBox.Location = New System.Drawing.Point(0, 0)
        Me.TCP_PortBox.MaxLength = 32767
        Me.TCP_PortBox.Multiline = False
        Me.TCP_PortBox.Name = "TCP_PortBox"
        Me.TCP_PortBox.ReadOnly = False
        Me.TCP_PortBox.Size = New System.Drawing.Size(0, 26)
        Me.TCP_PortBox.Style = VPN_Vision.RainoTextBox.Styles.Normal
        Me.TCP_PortBox.TabIndex = 0
        Me.TCP_PortBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.TCP_PortBox.TextColour = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.TCP_PortBox.UseSystemPasswordChar = False
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(526, 328)
        Me.Controls.Add(Me.ChromeThemeContainer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form2"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Paramètres"
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.ChromeThemeContainer1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlatTabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.FlatGroupBox2.ResumeLayout(False)
        Me.FlatGroupBox2.PerformLayout()
        Me.FlatGroupBox1.ResumeLayout(False)
        Me.FlatGroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ChromeThemeContainer1 As VPN_Vision.ChromeThemeContainer
    Friend WithEvents FlatTabControl1 As VPN_Vision.FlatTabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents LPageBox As VPN_Vision.FlatCheckbox
    Friend WithEvents StartBox As VPN_Vision.FlatCheckbox
    Friend WithEvents LPageTextBox As VPN_Vision.RainoTextBox
    Friend WithEvents SaveButton1 As VPN_Vision.FlatButton
    Friend WithEvents UpdateBox As VPN_Vision.FlatCheckbox
    Friend WithEvents SaveButton3 As VPN_Vision.FlatButton
    Friend WithEvents PasswordBox As VPN_Vision.RainoTextBox
    Friend WithEvents UsernameBox As VPN_Vision.RainoTextBox
    Friend WithEvents FlatGroupBox2 As VPN_Vision.FlatGroupBox
    Friend WithEvents FlatGroupBox1 As VPN_Vision.FlatGroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ChromeSeparator1 As VPN_Vision.ChromeSeparator
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents UpdateButton As VPN_Vision.FlatButton
    Friend WithEvents FlatLabel3 As VPN_Vision.FlatLabel
    Friend WithEvents FlatLabel5 As VPN_Vision.FlatLabel
    Friend WithEvents FlatLabel4 As VPN_Vision.FlatLabel
    Friend WithEvents AccountLinkBox As VPN_Vision.FlatLabel
    Friend WithEvents RainoTextBox6 As VPN_Vision.RainoTextBox
    Friend WithEvents PingBox As VPN_Vision.FlatCheckbox
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents FlatLabel2 As VPN_Vision.FlatLabel
    Friend WithEvents FlatLabel1 As VPN_Vision.FlatLabel
    Friend WithEvents BindBox As VPN_Vision.RainoTextBox
    Friend WithEvents TCP_PortBox As VPN_Vision.RainoTextBox
    Friend WithEvents FlatLabel10 As VPN_Vision.FlatLabel
    Friend WithEvents ChromeSeparator4 As VPN_Vision.ChromeSeparator
    Friend WithEvents FlatLabel9 As VPN_Vision.FlatLabel
    Friend WithEvents FlatLabel8 As VPN_Vision.FlatLabel
    Friend WithEvents ChromeSeparator3 As VPN_Vision.ChromeSeparator
    Friend WithEvents FlatLabel7 As VPN_Vision.FlatLabel
    Friend WithEvents ChromeSeparator2 As VPN_Vision.ChromeSeparator
    Friend WithEvents UDP_PortBox As VPN_Vision.RainoTextBox
    Friend WithEvents SaveButton2 As VPN_Vision.FlatButton
    Friend WithEvents FlatLabel13 As VPN_Vision.FlatLabel
    Friend WithEvents FlatLabel12 As VPN_Vision.FlatLabel
    Friend WithEvents FlatLabel11 As VPN_Vision.FlatLabel
    Friend WithEvents FlatLabel14 As VPN_Vision.FlatLabel
    Friend WithEvents ChromeSeparator5 As VPN_Vision.ChromeSeparator
End Class
