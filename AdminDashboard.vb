Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports MySql.Data.MySqlClient
Imports System.Runtime.InteropServices

Public Class AdminDashboard
    <DllImport("dwmapi.dll")>
    Private Shared Function DwmSetWindowAttribute(
    hwnd As IntPtr,
    attr As Integer,
    ByRef attrValue As Integer,
    attrSize As Integer) As Integer
    End Function

    Protected Overrides ReadOnly Property CreateParams As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or &H2000000 ' WS_EX_COMPOSITED
            Return cp
        End Get
    End Property
    Private Sub AdminDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loginform.Close()
        Me.BackgroundImage = My.Resources.bg
        Me.BackgroundImageLayout = ImageLayout.Stretch
        Dim screenWidth As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim screenHeight As Integer = Screen.PrimaryScreen.Bounds.Height
        Me.Size = New Size(screenWidth, screenHeight)
        Me.TopMost = True
        Me.WindowState = FormWindowState.Maximized

        Me.FormBorderStyle = FormBorderStyle.Sizable

        Dim DWMWA_CAPTION_COLOR As Integer = 35
        Dim color As Integer = &HFF0000 ' Red color (BGR format)
        DwmSetWindowAttribute(Me.Handle, DWMWA_CAPTION_COLOR, color, 4)


        Label1.Text = "Welcome " + username
        Label2.Left = (Me.ClientSize.Width - Label2.Width) / 2
        Label2.Text = "ADMIN PANEL"

    End Sub
End Class