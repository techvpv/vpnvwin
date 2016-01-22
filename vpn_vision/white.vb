Imports System.Drawing.Drawing2D
Imports System.ComponentModel
Imports System.Drawing.Text

Module Drawing
    '

    '
    Public Function RoundRect(ByVal rect As Rectangle, ByVal slope As Integer) As GraphicsPath
        Dim gp As GraphicsPath = New GraphicsPath()
        Dim arcWidth As Integer = slope * 2
        gp.AddArc(New Rectangle(rect.X, rect.Y, arcWidth, arcWidth), -180, 90)
        gp.AddArc(New Rectangle(rect.Width - arcWidth + rect.X, rect.Y, arcWidth, arcWidth), -90, 90)
        gp.AddArc(New Rectangle(rect.Width - arcWidth + rect.X, rect.Height - arcWidth + rect.Y, arcWidth, arcWidth), 0, 90)
        gp.AddArc(New Rectangle(rect.X, rect.Height - arcWidth + rect.Y, arcWidth, arcWidth), 90, 90)
        gp.CloseAllFigures()
        Return gp
    End Function

End Module

Class FlatButton
    Inherits Control

    Enum Style
        Blue
        Dark
        Light
    End Enum

    Private _style As Style
    Public Property ButtonStyle As Style
        Get
            Return _style
        End Get
        Set(ByVal value As Style)
            _style = value
            Invalidate()
        End Set
    End Property

    Private _image As Image
    Public Property Image As Image
        Get
            Return _image
        End Get
        Set(ByVal value As Image)
            _image = value
            Invalidate()
        End Set
    End Property

    Private _rounded As Boolean
    Public Property RoundedCorners As Boolean
        Get
            Return _rounded
        End Get
        Set(ByVal value As Boolean)
            _rounded = value
            Invalidate()
        End Set
    End Property

    Enum State
        None
        Over
        Down
    End Enum

    Private MouseState As State

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer Or _
                 ControlStyles.UserPaint Or ControlStyles.ResizeRedraw, True)
        MouseState = State.None
        Size = New Size(65, 26)
        Font = New Font("Verdana", 8)
        Cursor = Cursors.Hand
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)

        Dim G As Graphics = e.Graphics

        G.Clear(Parent.BackColor)
        G.SmoothingMode = Drawing2D.SmoothingMode.HighQuality

        Dim slope As Integer = 3

        Dim shadowRect As New Rectangle(0, 0, Width - 1, Height - 1)
        Dim shadowPath As GraphicsPath = RoundRect(shadowRect, slope)
        Dim mainRect As New Rectangle(0, 0, Width - 2, Height - 2)
        Select Case ButtonStyle
            Case Style.Blue
                If _rounded Then
                    G.FillPath(New SolidBrush(Color.FromArgb(216, 150, 42)), shadowPath)
                    G.FillPath(New SolidBrush(Color.FromArgb(216, 150, 42)), RoundRect(mainRect, slope))
                Else
                    G.FillPath(New SolidBrush(Color.FromArgb(216, 150, 42)), shadowPath)
                    G.FillPath(New SolidBrush(Color.FromArgb(216, 150, 42)), RoundRect(mainRect, slope))
                End If
            Case Style.Dark
                If _rounded Then
                    G.FillPath(New SolidBrush(Color.FromArgb(45, 45, 45)), shadowPath)
                    G.FillPath(New SolidBrush(Color.FromArgb(75, 75, 75)), RoundRect(mainRect, slope))
                Else
                    G.FillRectangle(New SolidBrush(Color.FromArgb(45, 45, 45)), shadowRect)
                    G.FillRectangle(New SolidBrush(Color.FromArgb(75, 75, 75)), mainRect)
                End If
            Case Style.Light
                If _rounded Then
                    G.FillPath(New SolidBrush(Color.FromArgb(145, 145, 145)), shadowPath)
                    G.FillPath(New SolidBrush(Color.FromArgb(170, 170, 170)), RoundRect(mainRect, slope))
                Else
                    G.FillRectangle(New SolidBrush(Color.FromArgb(145, 145, 145)), shadowRect)
                    G.FillRectangle(New SolidBrush(Color.FromArgb(170, 170, 170)), mainRect)
                End If
        End Select

        If _image Is Nothing Then
            Dim textX As Integer = ((Me.Width - 1) / 2) - (G.MeasureString(Text, Font).Width / 2)
            Dim textY As Integer = ((Me.Height - 1) / 2) - (G.MeasureString(Text, Font).Height / 2)
            G.DrawString(Text, Font, Brushes.White, textX, textY)
        Else
            Dim textSize As Size = New Size(G.MeasureString(Text, Font).Width, G.MeasureString(Text, Font).Height)
            Dim imageWidth As Integer = Me.Height - 19, imageHeight As Integer = Me.Height - 19
            Dim imageX As Integer = ((Me.Width - 1) / 2) - ((imageWidth + 4 + textSize.Width) / 2)
            Dim imageY As Integer = ((Me.Height - 1) / 2) - (imageHeight / 2)
            G.DrawImage(_image, imageX, imageY, imageWidth, imageHeight)
            G.DrawString(Text, Font, Brushes.White, New Point(imageX + imageWidth + 4, ((Me.Height - 1) / 2) - textSize.Height / 2))
        End If

        If MouseState = State.Over Then
            G.FillPath(New SolidBrush(Color.FromArgb(25, Color.White)), shadowPath)
        ElseIf MouseState = State.Down Then
            G.FillPath(New SolidBrush(Color.FromArgb(40, Color.White)), shadowPath)
        End If

    End Sub

    Protected Overrides Sub OnMouseEnter(ByVal e As System.EventArgs)
        MyBase.OnMouseEnter(e)
        MouseState = State.Over
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseLeave(ByVal e As System.EventArgs)
        MyBase.OnMouseLeave(e)
        MouseState = State.None
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseUp(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseUp(e)
        MouseState = State.Over
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseDown(e)
        MouseState = State.Down
        Invalidate()
    End Sub
End Class

Class FlatTabControl
    Inherits TabControl

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.ResizeRedraw Or _
                 ControlStyles.UserPaint Or ControlStyles.DoubleBuffer, True)
        ItemSize = New Size(0, 30)
        Font = New Font("Verdana", 8)
    End Sub

    Protected Overrides Sub CreateHandle()
        MyBase.CreateHandle()
        Alignment = TabAlignment.Top
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)

        Dim G As Graphics = e.Graphics

        Dim borderPen As New Pen(Color.FromArgb(225, 225, 225))

        G.SmoothingMode = SmoothingMode.HighQuality
        G.Clear(Parent.BackColor)

        Dim fillRect As New Rectangle(2, ItemSize.Height + 2, Width - 6, Height - ItemSize.Height - 3)
        G.FillRectangle(Brushes.White, fillRect)
        G.DrawRectangle(borderPen, fillRect)

        Dim FontColor As New Color

        For i = 0 To TabCount - 1

            Dim mainRect As Rectangle = GetTabRect(i)

            If i = SelectedIndex Then

                G.FillRectangle(New SolidBrush(Color.White), mainRect)
                G.DrawRectangle(borderPen, mainRect)
                G.DrawLine(New Pen(Color.FromArgb(216, 150, 42)), New Point(mainRect.X + 1, mainRect.Y), New Point(mainRect.X + mainRect.Width - 1, mainRect.Y))
                G.DrawLine(Pens.White, New Point(mainRect.X + 1, mainRect.Y + mainRect.Height), New Point(mainRect.X + mainRect.Width - 1, mainRect.Y + mainRect.Height))
                FontColor = Color.FromArgb(216, 150, 42)

            Else

                G.FillRectangle(New SolidBrush(Color.FromArgb(245, 245, 245)), mainRect)
                G.DrawRectangle(borderPen, mainRect)
                FontColor = Color.FromArgb(160, 160, 160)

            End If

            Dim titleX As Integer = (mainRect.Location.X + mainRect.Width / 2) - (G.MeasureString(TabPages(i).Text, Font).Width / 2)
            Dim titleY As Integer = (mainRect.Location.Y + mainRect.Height / 2) - (G.MeasureString(TabPages(i).Text, Font).Height / 2)
            G.DrawString(TabPages(i).Text, Font, New SolidBrush(FontColor), New Point(titleX, titleY))

            Try : TabPages(i).BackColor = Color.White : Catch : End Try

        Next

    End Sub

End Class

Class FlatGroupBox
    Inherits ContainerControl

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer Or _
                 ControlStyles.UserPaint Or ControlStyles.ResizeRedraw, True)
        BackColor = Color.FromArgb(250, 250, 250)
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)

        Dim G As Graphics = e.Graphics

        G.SmoothingMode = SmoothingMode.HighQuality
        G.Clear(Parent.BackColor)

        Dim mainRect As New Rectangle(0, 0, Width - 1, Height - 1)
        G.FillRectangle(New SolidBrush(Color.FromArgb(250, 250, 250)), mainRect)
        G.DrawRectangle(New Pen(Color.FromArgb(225, 225, 225)), mainRect)

    End Sub

End Class

Class FlatLabelHeader
    Inherits Label

    Sub New()
        Font = New Font("Verdana", 10, FontStyle.Bold)
    End Sub

End Class

Class FlatLabel
    Inherits Label

    Sub New()
        Font = New Font("Verdana", 8)
        ForeColor = Color.FromArgb(135, 135, 135)
    End Sub

End Class

Class FlatProgressBar
    Inherits Control

    Private _Maximum As Integer = 100
    Public Property Maximum As Integer
        Get
            Return _Maximum
        End Get
        Set(ByVal v As Integer)
            If v < 1 Then v = 1
            If v < _Value Then _Value = v
            _Maximum = v
            Invalidate()
        End Set
    End Property

    Private _Value As Integer
    Public Property Value As Integer
        Get
            Return _Value
        End Get
        Set(ByVal v As Integer)
            If v > _Maximum Then v = Maximum
            _Value = v
            Invalidate()
        End Set
    End Property

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer Or _
                 ControlStyles.UserPaint Or ControlStyles.ResizeRedraw, True)
        Size = New Size(100, 40)
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)

        Dim G As Graphics = e.Graphics

        G.SmoothingMode = SmoothingMode.HighQuality
        G.Clear(Parent.BackColor)

        Dim mainRect As New Rectangle(0, 0, Width - 1, Height - 1)
        G.FillRectangle(New SolidBrush(Color.FromArgb(240, 240, 240)), mainRect)
        G.DrawLine(New Pen(Color.FromArgb(230, 230, 230)), New Point(mainRect.X, mainRect.Height), New Point(mainRect.Width, mainRect.Height))

        Dim barRect As New Rectangle(0, 0, CInt(((Width / _Maximum) * _Value) - 1), Height - 1)
        G.FillRectangle(New SolidBrush(Color.FromArgb(216, 150, 42)), barRect)
        If _Value > 1 Then G.DrawLine(New Pen(Color.FromArgb(20, 140, 200)), New Point(barRect.X, barRect.Height), New Point(barRect.Width, barRect.Height))

        Dim textX As Integer = 12
        Dim textY As Integer = ((Me.Height - 1) / 2) - (G.MeasureString(Text, Font).Height / 2)
        Dim percent As Single = (_Value / _Maximum) * 100
        Dim txt As String = Text & " " & CStr(percent) & "%"
        G.DrawString(txt, Font, Brushes.White, New Point(textX, textY))

    End Sub

End Class

Class FlatAlertBox
    Inherits Control

    Private exitLocation As Point
    Private overExit As Boolean

    Enum Style
        _Error
        _Success
        _Warning
        _Notice
    End Enum

    Private _alertStyle As Style
    Public Property AlertStyle As Style
        Get
            Return _alertStyle
        End Get
        Set(ByVal value As Style)
            _alertStyle = value
            Invalidate()
        End Set
    End Property

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer Or _
                 ControlStyles.UserPaint Or ControlStyles.ResizeRedraw, True)
        Font = New Font("Verdana", 8)
        Size = New Size(200, 40)
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)

        Dim G As Graphics = e.Graphics

        G.SmoothingMode = SmoothingMode.HighQuality
        G.Clear(Parent.BackColor)

        Dim borderColor, innerColor, textColor As Color
        Select Case _alertStyle
            Case Style._Error
                borderColor = Color.FromArgb(250, 195, 195)
                innerColor = Color.FromArgb(255, 235, 235)
                textColor = Color.FromArgb(220, 90, 90)
            Case Style._Notice
                borderColor = Color.FromArgb(180, 215, 230)
                innerColor = Color.FromArgb(235, 245, 255)
                textColor = Color.FromArgb(80, 145, 180)
            Case Style._Success
                borderColor = Color.FromArgb(180, 220, 130)
                innerColor = Color.FromArgb(235, 245, 225)
                textColor = Color.FromArgb(95, 145, 45)
            Case Style._Warning
                borderColor = Color.FromArgb(220, 215, 140)
                innerColor = Color.FromArgb(250, 250, 220)
                textColor = Color.FromArgb(145, 135, 110)
        End Select

        Dim mainRect As New Rectangle(0, 0, Width - 1, Height - 1)
        G.FillRectangle(New SolidBrush(innerColor), mainRect)
        G.DrawRectangle(New Pen(borderColor), mainRect)

        Dim styleText As String = Nothing
        Select Case _alertStyle
            Case Style._Error
                styleText = "Error!"
            Case Style._Notice
                styleText = "Notice!"
            Case Style._Success
                styleText = "Success!"
            Case Style._Warning
                styleText = "Warning!"
        End Select

        Dim styleFont As New Font(Font.FontFamily, Font.Size, FontStyle.Bold)
        Dim textY As Integer = ((Me.Height - 1) / 2) - (G.MeasureString(Text, Font).Height / 2)
        G.DrawString(styleText, styleFont, New SolidBrush(textColor), New Point(10, textY))
        G.DrawString(Text, Font, New SolidBrush(textColor), New Point(10 + G.MeasureString(styleText, styleFont).Width + 4, textY))

        Dim exitFont As New Font("Marlett", 6)
        Dim exitY As Integer = ((Me.Height - 1) / 2) - (G.MeasureString("r", exitFont).Height / 2) + 1
        exitLocation = New Point(Width - 26, exitY - 3)
        G.DrawString("r", exitFont, New SolidBrush(textColor), New Point(Width - 23, exitY))

    End Sub

    Protected Overrides Sub OnMouseMove(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseMove(e)

        If e.X >= Width - 26 AndAlso e.X <= Width - 12 AndAlso e.Y > exitLocation.Y AndAlso e.Y < exitLocation.Y + 12 Then
            If Cursor <> Cursors.Hand Then Cursor = Cursors.Hand
            overExit = True
        Else
            If Cursor <> Cursors.Arrow Then Cursor = Cursors.Arrow
            overExit = False
        End If

        Invalidate()

    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseDown(e)

        If overExit Then Me.Visible = False

    End Sub

End Class

Class FlatCombo
    Inherits ComboBox

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer Or _
                 ControlStyles.UserPaint Or ControlStyles.ResizeRedraw Or _
                 ControlStyles.SupportsTransparentBackColor, True)
        Font = New Font("Verdana", 8)
    End Sub

    Protected Overrides Sub CreateHandle()
        MyBase.CreateHandle()

        DrawMode = Windows.Forms.DrawMode.OwnerDrawFixed
        DropDownStyle = ComboBoxStyle.DropDownList
        DoubleBuffered = True
        ItemHeight = 20

    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)

        Dim G As Graphics = e.Graphics

        G.SmoothingMode = SmoothingMode.HighQuality
        G.Clear(Parent.BackColor)

        Dim mainRect As New Rectangle(0, 0, Width - 1, Height - 1)
        Dim Rectt As New Rectangle(3, 4, 25, 17)
        G.FillRectangle(Brushes.White, mainRect)
        G.DrawRectangle(New Pen(Color.FromArgb(225, 225, 225)), mainRect)

        Dim triangle As Point() = New Point() {New Point(Width - 14, 16), New Point(Width - 18, 10), New Point(Width - 10, 10)}
        G.FillPolygon(Brushes.DarkGray, triangle)
        G.DrawLine(New Pen(Color.FromArgb(225, 225, 225)), New Point(Width - 27, 0), New Point(Width - 27, Height - 1))

        Try
            If Form1.ServersBox.Text = "" Then

            ElseIf Form1.ServersBox.Text.Contains("Afghanistan") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Afghanistan.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Albania") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Albania.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Algeria") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Algeria.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Andorra") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Andorra.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Antigua and Barbuda") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Antigua-and-Barbuda.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Argentina") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Argentina.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Armenia") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Armenia.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Australia") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Australia.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Austria") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Austria.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Azerbaijan") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Azerbaijan.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Bahamas") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Bahamas.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Bahrain") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Bahrain.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Bangladesh") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Bangladesh.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Barbados") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Barbados.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Belarus") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Belarus.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Belgium") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Belgium.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Belize") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Belize.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Benin") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Benin.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Bhutan") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Bhutan.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Bolivia") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Bolivia.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Bosnia and Herzegovina") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Bosnia-and-Herzegovina.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Botswana") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Botswana.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Brazil") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Brazil.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Brunei") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Brunei.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Bulgaria") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Bulgaria.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Burkina Faso") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Burkina-Faso.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Burundi") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Burundi.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Cambodia") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Cambodia.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Cameroon") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Cameroon.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Canada") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Canada.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Cape Verde") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Cape-Verde.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Central African Republic") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Central-African-Republic.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Chad") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Chad.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Chile") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Chile.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("China") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\China.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Colombia") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Colombia.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Comoros") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Comoros.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Congo Democratic") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Congo-(Democratic).png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Congo Republic") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Congo-(Republic).png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Costa Rica") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Costa-Rica.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Cote d'Ivoire") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Cote-d'Ivoire.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Croatia") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Croatia.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Cuba") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Cuba.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Cyprus") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Cyprus.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Czech Republic") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Czech-Republic.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Denmark") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Denmark.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Djibouti") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Djibouti.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Dominica") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Dominica.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Dominican Republic") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Dominican-Republic.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("East Timor") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\East-Timor.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Ecuador") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Ecuador.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Egypt") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Egypt.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("El Salvador") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\El-Salvador.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Equatorial Guinea") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Equatorial-Guinea.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Eritrea") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Eritrea.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Estonia") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Estonia.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Ethiopia") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Ethiopia.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Fiji") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Fiji.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Finland") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Finland.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("France") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\France.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("France - USA") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\France.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Gabon") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Gabon.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Gambia") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Gambia.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Georgia") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Georgia.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Germany") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Germany.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Ghana") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Ghana.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Grecee") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Grecee.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Grenada") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Grenada.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Guatemala") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Guatemala.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Guinea Bissau") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Guinea-Bissau.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Guinea") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Guinea.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Guyana") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Guyana.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Haiti") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Haiti.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Honduras") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Honduras.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Hungary") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Hungary.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Iceland") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Iceland.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("India") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\India.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Indonesia") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Indonesia.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Iran") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Iran.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Iraq") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Iraq.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Ireland") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Ireland.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Israel") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Israel.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Italy") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Italy.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Jamaica") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Jamaica.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Japan") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Japan.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Jordan") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Jordan.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Kazakhstan") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Kazakhstan.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Kenya") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Kenya.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Kiribati") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Kiribati.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Korea North") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Korea,-North.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Korea South") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Korea,-South.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Kosovo") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Kosovo.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Kuwait") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Kuwait.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Kyrgyzstan") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Kyrgyzstan.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Laos") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Laos.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Latvia") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Latvia.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Lebanon") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Lebanon.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Lesotho") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Lesotho.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Liberia") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Liberia.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Libya") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Libya.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Liechtenstein") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Liechtenstein.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Lithuania") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Lithuania.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Luxembourg") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Luxembourg.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Macedonia") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Macedonia.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Madagascar") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Madagascar.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Malawi") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Malawi.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Malaysia") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Malaysia.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Maldives") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Maldives.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Mali") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Mali.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Malta") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Malta.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Marshall Islands") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Marshall-Islands.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Mauritania") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Mauritania.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Mauritius") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Mauritius.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Mexico") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Mexico.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Micronesia Federated") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Micronesia-(Federated).png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Moldova") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Moldova.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Monaco") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Monaco.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Mongolia") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Mongolia.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Montenegro") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Montenegro.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Morocco") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Morocco.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Mozambique") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Mozambique.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Myanmar") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Myanmar.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Namibia") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Namibia.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Nauru") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Nauru.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Nepal") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Nepal.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Netherlands") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Netherlands.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("New Zealand") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\New-Zealand.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Nicaragua") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Nicaragua.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Niger") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Niger.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Nigeria") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Nigeria.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Norway") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Norway.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Oman") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Oman.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Pakistan") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Pakistan.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Palau") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Palau.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Panama") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Panama.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Papua New Guinea") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Papua-New-Guinea.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Paraguay") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Paraguay.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Peru") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Peru.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Philippines") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Philippines.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Poland") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Poland.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Portugal") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Portugal.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Qatar") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Qatar.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Romania") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Romania.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Russia") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Russia.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Rwanda") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Rwanda.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Saint Kitts and Nevis") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Saint-Kitts-and-Nevis.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Saint Lucia") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Saint-Lucia.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Saint Vincent and the Grenadines") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Saint-Vincent-and-the-Grenadines.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Samoa") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Samoa.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("San Marino") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\San-Marino.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Sao Tome and Principe") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Sao-Tome-and-Principe.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Saudi Arabia") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Saudi-Arabia.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Senegal") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Senegal.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Serbia") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Serbia.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Seychelles") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Seychelles.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Sierra Leone") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Sierra-Leone.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Singapore") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Singapore.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Slovakia") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Slovakia.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Slovenia") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Slovenia.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Solomon Islands") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Solomon-Islands.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Somalia") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Somalia.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("South Africa") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\South-Africa.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("South Sudan") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\South-Sudan.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Spain") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Spain.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Sri Lanka") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Sri-Lanka.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Sudan") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Sudan.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Suriname") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Suriname.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Swaziland") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Swaziland.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Sweden") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Sweden.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Switzerland") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Switzerland.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Syria") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Syria.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Taiwan") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Taiwan.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Tajikistan") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Tajikistan.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Tanzania") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Tanzania.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Thailand") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Thailand.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Togo") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Togo.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Tonga") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Tonga.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Trinidad and Tobago") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Trinidad-and-Tobago.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Tunisia") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Tunisia.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Turkey") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Turkey.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Turkmenistan") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Turkmenistan.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Tuvalu") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Tuvalu.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Uganda") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Uganda.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Ukraine") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Ukraine.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("United Arab Emirates") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\United-Arab-Emirates.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("United Kingdom") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\United-Kingdom.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Angleterre") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\United-Kingdom.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Grande bretagne") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\United-Kingdom.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("United States") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\United-States-of-America.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("USA - France") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\United-States-of-America.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("UK") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\United-Kingdom.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("USA") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\United-States-of-America.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Uruguay") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Uruguay.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Uzbekistan") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Uzbekistan.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Vanuatu") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Vanuatu.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Vatican City") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Vatican-City.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Venezuela") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Venezuela.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Vietnam") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Vietnam.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Yemen") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Yemen.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Zambia") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Zambia.png"), Rectt)

            ElseIf Form1.ServersBox.Text.Contains("Zimbabwe") Then
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Zimbabwe.png"), Rectt)
            Else
                G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\unknown.png"), Rectt)
            End If
        Catch : End Try
        Try
            If Items.Count > 0 Then
                If Not SelectedIndex = -1 Then
                    Dim textX As Integer = 6
                    Dim textY As Integer = ((Me.Height - 1) / 2) - (G.MeasureString(Items(SelectedIndex), Font).Height / 2) + 1
                    G.DrawString("       " & Items(SelectedIndex), Font, Brushes.Gray, New Point(textX, textY))
                Else
                End If
            End If
        Catch : End Try

    End Sub

    Sub replaceItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles Me.DrawItem
        e.DrawBackground()

        Dim G As Graphics = e.Graphics
        G.SmoothingMode = SmoothingMode.HighQuality

        Dim rect As New Rectangle(e.Bounds.X - 1, e.Bounds.Y - 1, e.Bounds.Width + 1, e.Bounds.Height + 1)
        Dim Rectt As New Rectangle(e.Bounds.X + 2, e.Bounds.Y + 1, 25, 17)

        Try
            If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
                G.FillRectangle(New SolidBrush(Color.FromArgb(216, 150, 42)), rect)
                G.DrawString("       " & MyBase.GetItemText(MyBase.Items(e.Index)), Font, Brushes.White, New Rectangle(e.Bounds.X + 6, e.Bounds.Y + 3, e.Bounds.Width, e.Bounds.Height))
                Try
                    If MyBase.Items(e.Index) = "" Then

                    ElseIf MyBase.Items(e.Index).Contains("Afghanistan") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Afghanistan.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Albania") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Albania.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Algeria") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Algeria.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Andorra") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Andorra.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Antigua and Barbuda") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Antigua-and-Barbuda.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Argentina") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Argentina.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Armenia") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Armenia.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Australia") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Australia.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Austria") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Austria.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Azerbaijan") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Azerbaijan.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Bahamas") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Bahamas.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Bahrain") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Bahrain.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Bangladesh") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Bangladesh.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Barbados") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Barbados.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Belarus") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Belarus.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Belgium") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Belgium.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Belize") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Belize.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Benin") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Benin.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Bhutan") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Bhutan.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Bolivia") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Bolivia.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Bosnia and Herzegovina") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Bosnia-and-Herzegovina.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Botswana") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Botswana.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Brazil") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Brazil.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Brunei") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Brunei.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Bulgaria") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Bulgaria.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Burkina Faso") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Burkina-Faso.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Burundi") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Burundi.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Cambodia") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Cambodia.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Cameroon") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Cameroon.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Canada") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Canada.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Cape Verde") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Cape-Verde.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Central African Republic") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Central-African-Republic.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Chad") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Chad.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Chile") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Chile.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("China") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\China.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Colombia") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Colombia.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Comoros") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Comoros.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Congo Democratic") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Congo-(Democratic).png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Congo Republic") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Congo-(Republic).png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Costa Rica") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Costa-Rica.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Cote d'Ivoire") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Cote-d'Ivoire.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Croatia") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Croatia.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Cuba") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Cuba.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Cyprus") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Cyprus.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Czech Republic") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Czech-Republic.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Denmark") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Denmark.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Djibouti") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Djibouti.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Dominica") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Dominica.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Dominican Republic") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Dominican-Republic.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("East Timor") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\East-Timor.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Ecuador") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Ecuador.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Egypt") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Egypt.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("El Salvador") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\El-Salvador.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Equatorial Guinea") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Equatorial-Guinea.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Eritrea") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Eritrea.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Estonia") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Estonia.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Ethiopia") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Ethiopia.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Fiji") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Fiji.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Finland") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Finland.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("France") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\France.png"), Rectt)

                    ElseIf Form1.ServersBox.Text.Contains("France - USA") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\France.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Gabon") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Gabon.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Gambia") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Gambia.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Georgia") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Georgia.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Germany") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Germany.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Ghana") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Ghana.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Grecee") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Grecee.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Grenada") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Grenada.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Guatemala") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Guatemala.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Guinea Bissau") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Guinea-Bissau.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Guinea") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Guinea.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Guyana") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Guyana.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Haiti") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Haiti.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Honduras") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Honduras.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Hungary") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Hungary.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Iceland") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Iceland.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("India") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\India.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Indonesia") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Indonesia.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Iran") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Iran.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Iraq") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Iraq.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Ireland") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Ireland.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Israel") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Israel.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Italy") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Italy.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Jamaica") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Jamaica.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Japan") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Japan.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Jordan") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Jordan.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Kazakhstan") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Kazakhstan.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Kenya") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Kenya.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Kiribati") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Kiribati.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Korea North") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Korea,-North.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Korea South") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Korea,-South.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Kosovo") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Kosovo.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Kuwait") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Kuwait.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Kyrgyzstan") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Kyrgyzstan.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Laos") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Laos.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Latvia") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Latvia.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Lebanon") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Lebanon.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Lesotho") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Lesotho.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Liberia") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Liberia.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Libya") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Libya.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Liechtenstein") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Liechtenstein.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Lithuania") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Lithuania.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Luxembourg") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Luxembourg.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Macedonia") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Macedonia.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Madagascar") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Madagascar.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Malawi") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Malawi.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Malaysia") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Malaysia.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Maldives") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Maldives.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Mali") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Mali.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Malta") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Malta.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Marshall Islands") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Marshall-Islands.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Mauritania") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Mauritania.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Mauritius") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Mauritius.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Mexico") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Mexico.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Micronesia Federated") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Micronesia-(Federated).png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Moldova") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Moldova.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Monaco") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Monaco.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Mongolia") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Mongolia.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Montenegro") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Montenegro.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Morocco") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Morocco.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Mozambique") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Mozambique.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Myanmar") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Myanmar.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Namibia") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Namibia.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Nauru") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Nauru.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Nepal") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Nepal.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Netherlands") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Netherlands.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("New Zealand") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\New-Zealand.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Nicaragua") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Nicaragua.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Niger") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Niger.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Nigeria") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Nigeria.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Norway") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Norway.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Oman") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Oman.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Pakistan") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Pakistan.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Palau") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Palau.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Panama") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Panama.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Papua New Guinea") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Papua-New-Guinea.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Paraguay") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Paraguay.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Peru") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Peru.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Philippines") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Philippines.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Poland") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Poland.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Portugal") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Portugal.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Qatar") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Qatar.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Romania") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Romania.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Russia") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Russia.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Rwanda") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Rwanda.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Saint Kitts and Nevis") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Saint-Kitts-and-Nevis.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Saint Lucia") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Saint-Lucia.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Saint Vincent and the Grenadines") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Saint-Vincent-and-the-Grenadines.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Samoa") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Samoa.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("San Marino") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\San-Marino.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Sao Tome and Principe") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Sao-Tome-and-Principe.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Saudi Arabia") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Saudi-Arabia.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Senegal") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Senegal.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Serbia") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Serbia.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Seychelles") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Seychelles.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Sierra Leone") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Sierra-Leone.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Singapore") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Singapore.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Slovakia") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Slovakia.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Slovenia") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Slovenia.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Solomon Islands") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Solomon-Islands.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Somalia") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Somalia.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("South Africa") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\South-Africa.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("South Sudan") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\South-Sudan.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Spain") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Spain.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Sri Lanka") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Sri-Lanka.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Sudan") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Sudan.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Suriname") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Suriname.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Swaziland") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Swaziland.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Sweden") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Sweden.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Switzerland") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Switzerland.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Syria") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Syria.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Taiwan") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Taiwan.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Tajikistan") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Tajikistan.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Tanzania") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Tanzania.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Thailand") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Thailand.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Togo") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Togo.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Tonga") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Tonga.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Trinidad and Tobago") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Trinidad-and-Tobago.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Tunisia") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Tunisia.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Turkey") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Turkey.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Turkmenistan") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Turkmenistan.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Tuvalu") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Tuvalu.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Uganda") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Uganda.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Ukraine") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Ukraine.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("United Arab Emirates") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\United-Arab-Emirates.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("United Kingdom") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\United-Kingdom.png"), Rectt)

                    ElseIf Form1.ServersBox.Text.Contains("Angleterre") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\United-Kingdom.png"), Rectt)

                    ElseIf Form1.ServersBox.Text.Contains("Grande bretagne") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\United-Kingdom.png"), Rectt)

                    ElseIf Form1.ServersBox.Text.Contains("United States") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\United-States-of-America.png"), Rectt)

                    ElseIf Form1.ServersBox.Text.Contains("USA - France") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\United-States-of-America.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("UK") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\United-Kingdom.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("USA") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\United-States-of-America.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Uruguay") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Uruguay.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Uzbekistan") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Uzbekistan.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Vanuatu") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Vanuatu.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Vatican City") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Vatican-City.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Venezuela") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Venezuela.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Vietnam") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Vietnam.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Yemen") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Yemen.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Zambia") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Zambia.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Zimbabwe") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Zimbabwe.png"), Rectt)
                    Else
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\unknown.png"), Rectt)
                    End If
                Catch ex As Exception

                End Try
            Else
                G.FillRectangle(Brushes.White, rect)
                G.DrawString("       " & MyBase.GetItemText(MyBase.Items(e.Index)), Font, Brushes.DarkGray, New Rectangle(e.Bounds.X + 6, e.Bounds.Y + 3, e.Bounds.Width, e.Bounds.Height))
                Try
                    If MyBase.Items(e.Index) = "" Then

                    ElseIf MyBase.Items(e.Index).Contains("Afghanistan") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Afghanistan.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Albania") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Albania.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Algeria") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Algeria.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Andorra") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Andorra.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Antigua and Barbuda") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Antigua-and-Barbuda.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Argentina") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Argentina.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Armenia") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Armenia.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Australia") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Australia.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Austria") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Austria.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Azerbaijan") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Azerbaijan.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Bahamas") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Bahamas.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Bahrain") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Bahrain.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Bangladesh") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Bangladesh.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Barbados") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Barbados.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Belarus") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Belarus.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Belgium") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Belgium.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Belize") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Belize.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Benin") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Benin.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Bhutan") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Bhutan.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Bolivia") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Bolivia.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Bosnia and Herzegovina") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Bosnia-and-Herzegovina.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Botswana") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Botswana.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Brazil") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Brazil.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Brunei") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Brunei.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Bulgaria") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Bulgaria.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Burkina Faso") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Burkina-Faso.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Burundi") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Burundi.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Cambodia") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Cambodia.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Cameroon") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Cameroon.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Canada") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Canada.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Cape Verde") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Cape-Verde.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Central African Republic") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Central-African-Republic.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Chad") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Chad.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Chile") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Chile.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("China") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\China.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Colombia") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Colombia.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Comoros") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Comoros.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Congo Democratic") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Congo-(Democratic).png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Congo Republic") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Congo-(Republic).png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Costa Rica") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Costa-Rica.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Cote d'Ivoire") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Cote-d'Ivoire.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Croatia") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Croatia.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Cuba") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Cuba.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Cyprus") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Cyprus.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Czech Republic") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Czech-Republic.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Denmark") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Denmark.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Djibouti") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Djibouti.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Dominica") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Dominica.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Dominican Republic") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Dominican-Republic.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("East Timor") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\East-Timor.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Ecuador") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Ecuador.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Egypt") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Egypt.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("El Salvador") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\El-Salvador.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Equatorial Guinea") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Equatorial-Guinea.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Eritrea") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Eritrea.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Estonia") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Estonia.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Ethiopia") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Ethiopia.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Fiji") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Fiji.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Finland") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Finland.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("France") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\France.png"), Rectt)

                    ElseIf Form1.ServersBox.Text.Contains("France - USA") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\France.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Gabon") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Gabon.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Gambia") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Gambia.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Georgia") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Georgia.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Germany") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Germany.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Ghana") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Ghana.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Grecee") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Grecee.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Grenada") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Grenada.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Guatemala") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Guatemala.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Guinea Bissau") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Guinea-Bissau.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Guinea") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Guinea.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Guyana") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Guyana.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Haiti") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Haiti.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Honduras") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Honduras.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Hungary") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Hungary.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Iceland") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Iceland.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("India") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\India.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Indonesia") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Indonesia.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Iran") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Iran.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Iraq") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Iraq.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Ireland") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Ireland.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Israel") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Israel.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Italy") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Italy.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Jamaica") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Jamaica.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Japan") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Japan.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Jordan") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Jordan.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Kazakhstan") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Kazakhstan.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Kenya") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Kenya.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Kiribati") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Kiribati.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Korea North") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Korea,-North.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Korea South") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Korea,-South.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Kosovo") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Kosovo.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Kuwait") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Kuwait.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Kyrgyzstan") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Kyrgyzstan.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Laos") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Laos.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Latvia") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Latvia.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Lebanon") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Lebanon.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Lesotho") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Lesotho.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Liberia") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Liberia.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Libya") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Libya.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Liechtenstein") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Liechtenstein.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Lithuania") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Lithuania.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Luxembourg") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Luxembourg.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Macedonia") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Macedonia.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Madagascar") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Madagascar.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Malawi") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Malawi.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Malaysia") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Malaysia.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Maldives") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Maldives.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Mali") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Mali.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Malta") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Malta.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Marshall Islands") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Marshall-Islands.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Mauritania") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Mauritania.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Mauritius") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Mauritius.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Mexico") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Mexico.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Micronesia Federated") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Micronesia-(Federated).png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Moldova") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Moldova.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Monaco") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Monaco.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Mongolia") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Mongolia.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Montenegro") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Montenegro.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Morocco") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Morocco.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Mozambique") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Mozambique.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Myanmar") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Myanmar.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Namibia") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Namibia.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Nauru") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Nauru.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Nepal") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Nepal.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Netherlands") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Netherlands.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("New Zealand") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\New-Zealand.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Nicaragua") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Nicaragua.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Niger") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Niger.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Nigeria") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Nigeria.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Norway") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Norway.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Oman") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Oman.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Pakistan") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Pakistan.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Palau") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Palau.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Panama") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Panama.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Papua New Guinea") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Papua-New-Guinea.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Paraguay") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Paraguay.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Peru") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Peru.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Philippines") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Philippines.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Poland") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Poland.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Portugal") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Portugal.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Qatar") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Qatar.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Romania") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Romania.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Russia") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Russia.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Rwanda") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Rwanda.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Saint Kitts and Nevis") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Saint-Kitts-and-Nevis.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Saint Lucia") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Saint-Lucia.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Saint Vincent and the Grenadines") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Saint-Vincent-and-the-Grenadines.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Samoa") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Samoa.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("San Marino") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\San-Marino.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Sao Tome and Principe") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Sao-Tome-and-Principe.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Saudi Arabia") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Saudi-Arabia.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Senegal") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Senegal.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Serbia") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Serbia.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Seychelles") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Seychelles.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Sierra Leone") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Sierra-Leone.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Singapore") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Singapore.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Slovakia") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Slovakia.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Slovenia") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Slovenia.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Solomon Islands") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Solomon-Islands.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Somalia") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Somalia.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("South Africa") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\South-Africa.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("South Sudan") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\South-Sudan.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Spain") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Spain.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Sri Lanka") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Sri-Lanka.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Sudan") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Sudan.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Suriname") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Suriname.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Swaziland") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Swaziland.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Sweden") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Sweden.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Switzerland") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Switzerland.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Syria") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Syria.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Taiwan") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Taiwan.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Tajikistan") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Tajikistan.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Tanzania") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Tanzania.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Thailand") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Thailand.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Togo") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Togo.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Tonga") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Tonga.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Trinidad and Tobago") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Trinidad-and-Tobago.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Tunisia") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Tunisia.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Turkey") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Turkey.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Turkmenistan") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Turkmenistan.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Tuvalu") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Tuvalu.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Uganda") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Uganda.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Ukraine") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Ukraine.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("United Arab Emirates") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\United-Arab-Emirates.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("United Kingdom") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\United-Kingdom.png"), Rectt)

                    ElseIf Form1.ServersBox.Text.Contains("Angleterre") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\United-Kingdom.png"), Rectt)

                    ElseIf Form1.ServersBox.Text.Contains("Grande bretagne") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\United-Kingdom.png"), Rectt)

                    ElseIf Form1.ServersBox.Text.Contains("United States") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\United-States-of-America.png"), Rectt)

                    ElseIf Form1.ServersBox.Text.Contains("USA - France") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\United-States-of-America.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("UK") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\United-Kingdom.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("USA") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\United-States-of-America.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Uruguay") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Uruguay.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Uzbekistan") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Uzbekistan.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Vanuatu") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Vanuatu.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Vatican City") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Vatican-City.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Venezuela") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Venezuela.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Vietnam") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Vietnam.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Yemen") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Yemen.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Zambia") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Zambia.png"), Rectt)

                    ElseIf MyBase.Items(e.Index).Contains("Zimbabwe") Then
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\Zimbabwe.png"), Rectt)
                    Else
                        G.DrawImage(Image.FromFile(Application.StartupPath + "\flags\unknown.png"), Rectt)
                    End If
                Catch ex As Exception

                End Try
            End If

        Catch : End Try

    End Sub

    Protected Overrides Sub OnSelectedItemChanged(ByVal e As System.EventArgs)
        MyBase.OnSelectedItemChanged(e)
        Invalidate()
    End Sub

End Class

<DefaultEvent("CheckedChanged")> Class FlatCheckbox
    Inherits Control

    Event CheckedChanged(ByVal sender As Object)

    Private _checked As Boolean
    Public Property Checked() As Boolean
        Get
            Return _checked
        End Get
        Set(ByVal value As Boolean)
            _checked = value
            Invalidate()
        End Set
    End Property

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer Or _
                 ControlStyles.UserPaint Or ControlStyles.ResizeRedraw, True)
        Size = New Size(140, 20)
        Font = New Font("Verdana", 8)
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)

        Dim G As Graphics = e.Graphics

        G.SmoothingMode = SmoothingMode.HighQuality
        G.Clear(Parent.BackColor)

        Dim box As New Rectangle(0, 0, Height, Height - 1)
        G.FillRectangle(Brushes.White, box)
        G.DrawRectangle(New Pen(Color.FromArgb(225, 225, 225)), box)

        Dim markPen As New Pen(Color.FromArgb(150, 155, 160))
        Dim lightMarkPen As New Pen(Color.FromArgb(170, 175, 180))
        If _checked Then G.DrawString("a", New Font("Marlett", 14), Brushes.Gray, New Point(0, 0))

        Dim textY As Integer = (Height / 2) - (G.MeasureString(Text, Font).Height / 2)
        G.DrawString(Text, Font, Brushes.Gray, New Point(24, textY))

    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseDown(e)

        If _checked Then
            _checked = False
        Else
            _checked = True
        End If

        RaiseEvent CheckedChanged(Me)
        Invalidate()

    End Sub

End Class

<DefaultEvent("CheckedChanged")> Class FlatRadioButton
    Inherits Control

    Event CheckedChanged(ByVal sender As Object)

    Private _checked As Boolean
    Public Property Checked() As Boolean
        Get
            Return _checked
        End Get
        Set(ByVal value As Boolean)
            _checked = value
            Invalidate()
        End Set
    End Property

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer Or _
                 ControlStyles.UserPaint Or ControlStyles.ResizeRedraw, True)
        Size = New Size(140, 20)
        Font = New Font("Verdana", 8)
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)

        Dim G As Graphics = e.Graphics

        G.SmoothingMode = SmoothingMode.HighQuality
        G.Clear(Parent.BackColor)

        Dim box As New Rectangle(0, 0, Height - 1, Height - 1)
        G.FillEllipse(Brushes.White, box)
        G.DrawEllipse(New Pen(Color.FromArgb(225, 225, 225)), box)

        If _checked Then
            Dim innerMark As New Rectangle(6, 6, Height - 13, Height - 13)
            G.FillEllipse(New SolidBrush(Color.FromArgb(20, 160, 230)), innerMark)
        End If

        Dim textY As Integer = (Height / 2) - (G.MeasureString(Text, Font).Height / 2)
        G.DrawString(Text, Font, Brushes.Gray, New Point(24, textY))

    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseDown(e)

        For Each C As Control In Parent.Controls
            If C IsNot Me AndAlso TypeOf C Is FlatRadioButton Then
                DirectCast(C, FlatRadioButton).Checked = False
            End If
        Next

        If _checked Then
            _checked = False
        Else
            _checked = True
        End If

        RaiseEvent CheckedChanged(Me)
        Invalidate()

    End Sub

End Class

Class RainoTextBox
    Inherits Control

#Region "Declarations"
    Private State As MouseState = MouseState.None
    Private WithEvents TB As Windows.Forms.TextBox
    Private _BaseColour As Color = Color.White
    Private _TextColour As Color = Color.FromArgb(150, 150, 150)
    Private _BorderColour As Color = Color.FromArgb(180, 180, 180)
    Private _Style As Styles = Styles.Normal
    Private _TextAlign As HorizontalAlignment = HorizontalAlignment.Left
    Private _MaxLength As Integer = 32767
    Private _ReadOnly As Boolean
    Private _UseSystemPasswordChar As Boolean
    Private _Multiline As Boolean
#End Region

#Region "TextBox Properties"

    Enum Styles
        Normal
    End Enum

    <Category("Options")>
    Property TextAlign() As HorizontalAlignment
        Get
            Return _TextAlign
        End Get
        Set(ByVal value As HorizontalAlignment)
            _TextAlign = value
            If TB IsNot Nothing Then
                TB.TextAlign = value
            End If
        End Set
    End Property

    <Category("Options")>
    Property MaxLength() As Integer
        Get
            Return _MaxLength
        End Get
        Set(ByVal value As Integer)
            _MaxLength = value
            If TB IsNot Nothing Then
                TB.MaxLength = value
            End If
        End Set
    End Property

    <Category("Options")>
    Property [ReadOnly]() As Boolean
        Get
            Return _ReadOnly
        End Get
        Set(ByVal value As Boolean)
            _ReadOnly = value
            If TB IsNot Nothing Then
                TB.ReadOnly = value
            End If
        End Set
    End Property

    <Category("Options")>
    Property UseSystemPasswordChar() As Boolean
        Get
            Return _UseSystemPasswordChar
        End Get
        Set(ByVal value As Boolean)
            _UseSystemPasswordChar = value
            If TB IsNot Nothing Then
                TB.UseSystemPasswordChar = value
            End If
        End Set
    End Property

    <Category("Options")>
    Property Multiline() As Boolean
        Get
            Return _Multiline
        End Get
        Set(ByVal value As Boolean)
            _Multiline = value
            If TB IsNot Nothing Then
                TB.Multiline = value

                If value Then
                    TB.Height = Height - 11
                Else
                    Height = TB.Height + 11
                End If

            End If
        End Set
    End Property

    <Category("Options")>
    Overrides Property Text As String
        Get
            Return MyBase.Text
        End Get
        Set(ByVal value As String)
            MyBase.Text = value
            If TB IsNot Nothing Then
                TB.Text = value
            End If
        End Set
    End Property

    <Category("Options")>
    Overrides Property Font As Font
        Get
            Return MyBase.Font
        End Get
        Set(ByVal value As Font)
            MyBase.Font = value
            If TB IsNot Nothing Then
                TB.Font = value
                TB.Location = New Point(3, 5)
                TB.Width = Width - 6

                If Not _Multiline Then
                    Height = TB.Height + 11
                End If
            End If
        End Set
    End Property

    Protected Overrides Sub OnCreateControl()
        MyBase.OnCreateControl()
        If Not Controls.Contains(TB) Then
            Controls.Add(TB)
        End If
    End Sub

    Private Sub OnBaseTextChanged(ByVal s As Object, ByVal e As EventArgs)
        Text = TB.Text
    End Sub

    Private Sub OnBaseKeyDown(ByVal s As Object, ByVal e As KeyEventArgs)
        If e.Control AndAlso e.KeyCode = Keys.A Then
            TB.SelectAll()
            e.SuppressKeyPress = True
        End If
        If e.Control AndAlso e.KeyCode = Keys.C Then
            TB.Copy()
            e.SuppressKeyPress = True
        End If
    End Sub

    Protected Overrides Sub OnResize(ByVal e As EventArgs)
        TB.Location = New Point(5, 5)
        TB.Width = Width - 10

        If _Multiline Then
            TB.Height = Height - 11
        Else
            Height = TB.Height + 11
        End If

        MyBase.OnResize(e)
    End Sub

    Public Property Style As Styles
        Get
            Return _Style
        End Get
        Set(ByVal value As Styles)
            _Style = value
        End Set
    End Property

    Public Sub SelectAll()
        TB.Focus()
        TB.SelectAll()
    End Sub


#End Region

#Region "Colour Properties"

    <Category("Colours")>
    Public Property BackgroundColour As Color
        Get
            Return _BaseColour
        End Get
        Set(ByVal value As Color)
            _BaseColour = value
        End Set
    End Property

    <Category("Colours")>
    Public Property TextColour As Color
        Get
            Return _TextColour
        End Get
        Set(ByVal value As Color)
            _TextColour = value
        End Set
    End Property

    <Category("Colours")>
    Public Property BorderColour As Color
        Get
            Return _BorderColour
        End Get
        Set(ByVal value As Color)
            _BorderColour = value
        End Set
    End Property

#End Region

#Region "Mouse States"

    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        State = MouseState.Down : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        State = MouseState.Over : TB.Focus() : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseLeave(ByVal e As EventArgs)
        MyBase.OnMouseLeave(e)
        State = MouseState.None : Invalidate()
    End Sub

#End Region

#Region "Draw Control"
    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or _
                 ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer Or _
                 ControlStyles.SupportsTransparentBackColor, True)
        DoubleBuffered = True
        BackColor = Color.Transparent
        TB = New Windows.Forms.TextBox
        TB.Height = 190
        TB.Font = New Font("Segoe UI", 8)
        TB.Text = Text
        TB.BackColor = Color.FromArgb(255, 255, 255)
        TB.ForeColor = Color.FromArgb(150, 150, 150)
        TB.MaxLength = _MaxLength
        TB.Multiline = False
        TB.ReadOnly = _ReadOnly
        TB.UseSystemPasswordChar = _UseSystemPasswordChar
        TB.BorderStyle = BorderStyle.None
        TB.Location = New Point(5, 5)
        TB.Width = Width - 35
        AddHandler TB.TextChanged, AddressOf OnBaseTextChanged
        AddHandler TB.KeyDown, AddressOf OnBaseKeyDown
    End Sub


    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim g = e.Graphics
        Dim GP As GraphicsPath
        Dim Base As New Rectangle(0, 0, Width, Height)
        With g
            .TextRenderingHint = TextRenderingHint.ClearTypeGridFit
            .SmoothingMode = SmoothingMode.HighQuality
            .PixelOffsetMode = PixelOffsetMode.HighQuality
            .Clear(BackColor)
            TB.BackColor = Color.FromArgb(255, 255, 255)
            TB.ForeColor = Color.FromArgb(150, 150, 150)
            Select Case _Style
                Case Styles.Normal
                    .FillRectangle(New SolidBrush(Color.FromArgb(255, 255, 255)), New Rectangle(0, 0, Width - 1, Height - 1))
                    .DrawRectangle(New Pen(New SolidBrush(Color.FromArgb(180, 180, 180)), 2), New Rectangle(0, 0, Width, Height))
            End Select
            .InterpolationMode = CType(7, InterpolationMode)
        End With
    End Sub

#End Region
    '

    '
End Class