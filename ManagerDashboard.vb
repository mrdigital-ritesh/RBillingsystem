Imports MySql.Data.MySqlClient

Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Imports System.Runtime.InteropServices
Imports System.Globalization
Imports OxyPlot
Imports OxyPlot.Series
Imports OxyPlot.WindowsForms
Imports System.IO
Imports System.Windows.Forms.VisualStyles
Public Class ManagerDashboard


    Private plotView As PlotView
    Dim qry As String
    Dim cmd As MySqlCommand
    Dim Reader As MySqlDataReader

    Protected Overrides ReadOnly Property CreateParams As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or &H2000000 ' WS_EX_COMPOSITED
            Return cp
        End Get
    End Property
    Private Sub ManagerDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'chart code
        conn.Close()


        'main code
        loginform.Close()
        ManagerInsert.Close()
        EmployeeInsert.Close()
        Billadd.Close()
        product.Close()
        Barcodegenerate.Close()
        fetchcompany()
        dashdetail()
        Me.BackgroundImage = My.Resources.bg
        Me.BackgroundImageLayout = ImageLayout.Stretch
        Dim screenWidth As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim screenHeight As Integer = Screen.PrimaryScreen.Bounds.Height
        Me.Size = New Size(screenWidth, screenHeight)
        Me.WindowState = FormWindowState.Maximized
        Timer1.Enabled = True
        Me.FormBorderStyle = FormBorderStyle.Sizable
        InitializeSalesPieChart()

        Label1.Text = "Welcome " + username
        Label2.Left = (Me.ClientSize.Width - Label2.Width) / 2
        Label2.Text = "MANAGER PANEL"

        Label12.Text = "BUSINESS NAME:"
        Label13.Text = "BRANCH NAME:"
        Label14.Text = "GSTIN:"

    End Sub
    Private Sub InitializeSalesPieChart()
        Dim plotModel As New PlotModel() With {
            .Title = "Sales Distribution by Category"
        }

        ' Create PieSeries for displaying sales data
        Dim pieSeries As New PieSeries() With {
            .StartAngle = 90,
            .AngleSpan = 360
        }

        ' Get sales data from the database
        Dim connectionString As String = "your_connection_string_here" ' Replace with your actual connection string
        Dim query As String = "SELECT p.cat_name, SUM(bd.pro_total) AS total_sales FROM bill_data bd JOIN bills b ON bd.bill_id = b.bill_id JOIN products p ON bd.pro_id = p.pro_id GROUP BY p.cat_name ORDER BY total_sales DESC;"

        ' Open connection and fetch data

        conn.Open()
        Using cmd As New MySqlCommand(query, conn)
            Using reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    Dim category As String = reader("cat_name").ToString()
                    Dim totalSales As Double = Convert.ToDouble(reader("total_sales"))

                    ' Add a slice to the pie chart for each product category
                    pieSeries.Slices.Add(New PieSlice(category, totalSales) With {.IsExploded = False})
                End While
            End Using
        End Using


        ' Add the pie series to the plot model
        plotModel.Series.Add(pieSeries)

        ' Set the PlotModel (chart model) to the PlotView
        PlotView1.Model = plotModel
        conn.Close()

    End Sub

    Public Sub fetchcompany()
        Try
            Call connect()

            qry = "SELECT businessname, branch, gstin FROM company WHERE comid = 1"
            cmd = New MySqlCommand(qry, conn)

            Dim reader As MySqlDataReader = cmd.ExecuteReader()

            If reader.Read() Then
                Label17.Text = reader("businessname").ToString()
                Label16.Text = reader("branch").ToString()
                Label15.Text = reader("gstin").ToString()

            End If

            reader.Close()
            conn.Close()

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub
    Public Sub dashdetail()
        Try
            Call connect()

            qry = "
    SELECT 
        (SELECT SUM(netamount) FROM bills WHERE DATE(date) = CURDATE()) AS today_sales,
        (SELECT COUNT(*) FROM products) AS total_products,
        (SELECT COUNT(*) FROM bills WHERE DATE(date) = CURDATE()) AS total_bills,
        (SELECT SUM(netamount) FROM bills WHERE MONTH(date) = MONTH(CURDATE()) AND YEAR(date) = YEAR(CURDATE())) AS monthly_sales"



            cmd = New MySqlCommand(qry, conn)

            Dim reader As MySqlDataReader = cmd.ExecuteReader()

            If reader.Read() Then
                Label8.Text = If(IsDBNull(reader("today_sales")), "0", reader("today_sales").ToString())
                Label10.Text = If(IsDBNull(reader("total_products")), "0", reader("total_products").ToString())
                Label9.Text = If(IsDBNull(reader("total_bills")), "0", reader("total_bills").ToString())
                Label11.Text = If(IsDBNull(reader("monthly_sales")), "0", reader("monthly_sales").ToString())
            End If
            Label8.Left = (Panel2.ClientSize.Width - Label8.Width) / 2
            Label10.Left = (Panel4.ClientSize.Width - Label10.Width) / 2
            Label9.Left = (Panel5.ClientSize.Width - Label9.Width) / 2
            Label11.Left = (Panel6.ClientSize.Width - Label11.Width) / 2
            reader.Close()
            conn.Close()

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
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


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        EmployeeInsert.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        product.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Barcodegenerate.Show()
    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Dim confirm As DialogResult = MessageBox.Show("Are you sure you want to logout.?", "Confirm LOGOUT", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If confirm = DialogResult.Yes Then
            loginform.Show()
        End If
    End Sub
End Class