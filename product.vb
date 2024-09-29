Imports MySql.Data.MySqlClient
Public Class product
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Call connect()
        Dim screenWidth As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim screenHeight As Integer = Screen.PrimaryScreen.Bounds.Height
        Me.Size = New Size(screenWidth, screenHeight)
        'Me.FormBorderStyle = FormBorderStyle.None
        Me.WindowState = FormWindowState.Maximized

        Label1.Text = "Product Id:"
        Label2.Text = "Product Name:"
        Label3.Text = "Product Brand:"
        Label6.Text = "Category Id:"
        Label5.Text = "Purchase Price:"
        Label4.Text = "MRP:"
        Label7.Text = "Quantity:"
        Label8.Text = "Supplier Id:"
        TextBox1.Enabled = False
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Call showdata()

    End Sub

    Public Sub showdata()
        Call connect()
        Dim str As String
        str = "select * from products"
        Dim da As New MySqlDataAdapter(str, conn)
        Dim dt As New DataTable("product_info")
        da.Fill(dt)

        DataGridView1.DataSource = dt
        DataGridView1.Refresh()
        conn.Close()
    End Sub


End Class
