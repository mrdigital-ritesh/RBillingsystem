Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports MySql.Data.MySqlClient
Imports System.Runtime.InteropServices
Imports System.Globalization
Imports Syncfusion.Windows.Forms.Chart

Public Class AdminDashboard


    Protected Overrides ReadOnly Property CreateParams As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or &H2000000 ' WS_EX_COMPOSITED
            Return cp
        End Get
    End Property
    Private Sub AdminDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'chart code

        Dim series As New ChartSeries("Sales", ChartSeriesType.Pie)

        ' Add data points (Name, Value)
        series.Points.Add("2020", 50)
        series.Points.Add("2021", 70)
        series.Points.Add("2022", 90)
        series.Points.Add("2023", 110)

        ChartControl1.Series.Add(series)

        ChartControl1.Refresh()

        'main code
        loginform.Close()
        ManagerInsert.Close()
        EmployeeInsert.Close()
        Billadd.Close()
        product.Close()
        Me.BackgroundImage = My.Resources.bg
        Me.BackgroundImageLayout = ImageLayout.Stretch
        Dim screenWidth As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim screenHeight As Integer = Screen.PrimaryScreen.Bounds.Height
        Me.Size = New Size(screenWidth, screenHeight)
        Me.WindowState = FormWindowState.Maximized
        Timer1.Enabled = True
        Me.FormBorderStyle = FormBorderStyle.Sizable

        Label1.Text = "Welcome " + username
        Label2.Left = (Me.ClientSize.Width - Label2.Width) / 2
        Label2.Text = "ADMIN PANEL"

    End Sub

    Public Sub dashdetail()

    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label7.Text = DateTime.Now.ToString("dddd")
        Label7.Text += "   " & DateTime.Now.ToString("dd MMMM yyyy") & "   " & TimeOfDay()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Billadd.Show()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ManagerInsert.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        EmployeeInsert.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        product.Show()
    End Sub


End Class