Public Class product
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call connect()
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
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font


    End Sub


End Class
