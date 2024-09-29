Imports MySql.Data.MySqlClient
Public Class product
    Dim qry As String

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
        Label6.Text = "MRP:"
        Label5.Text = "Purchase Price:"
        Label4.Text = "Category:"
        Label8.Text = "Quantity:"
        Label7.Text = "Discount:"
        Label10.Text = "Supplier Name:"
        Label11.Text = "Stock Date:"
        Label9.Text = "R-MART (PRODUCT)"

        Button1.Text = "Add Item"
        Button2.Text = "Update Item"
        Button3.Text = "Delete Item"
        Button2.Enabled = False
        Button3.Enabled = False


        pid.Enabled = False
        stockdate.Enabled = False
        stockdate.Text = Today.ToString("yyyy-MM-dd")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Call showdata()
        Call autoid()
        Call loadcat()
        pname.Focus()

    End Sub

    Public Sub showdata()
        Call connect()
        qry = "select * from products"
        Dim da As New MySqlDataAdapter(qry, conn)
        Dim dt As New DataTable()

        da.Fill(dt)

        DataGridView1.DataSource = dt
        DataGridView1.Refresh()
        conn.Close()
    End Sub

    Public Sub autoid()
        Call connect()
        qry = "select max(pro_id) from products"
        Dim da As New MySqlDataAdapter(qry, conn)
        Dim dt As New DataTable()

        da.Fill(dt)
        Dim pro_id As Double
        If dt.Rows.Count > 0 AndAlso Not IsDBNull(dt.Rows(0).Item(0)) Then
            pro_id = dt.Rows(0).Item(0)
            Me.pid.Text = pro_id + 1
        Else
            Me.pid.Text = 202400001
        End If
        conn.Close()
    End Sub

    Public Sub loadcat()
        Call connect()
        qry = "SELECT cat_name FROM category"
        Dim da As New MySqlDataAdapter(qry, conn)
        Dim dt As New DataTable()

        da.Fill(dt)
        category.Items.Clear()
        For Each row As DataRow In dt.Rows
            category.Items.Add(row("cat_name").ToString())

        Next
        conn.Close()
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Call connect()
        Dim cmd As New MySqlCommand
        qry = "insert into products values('" & pid.Text & "','" & pname.Text & "','" & pbrand.Text &
            "','" & category.Text & "','" & purprice.Text & "','" & mrp.Text & "','" & disc.Text & "','" & qty.Text & "',
            '" & supplier.Text & "', curdate())"
        cmd.CommandText = qry
        'cmd.CommandType = CommandType.Text
        cmd.Connection = conn
        cmd.ExecuteNonQuery()
        conn.Close()
        Call showdata()
        MsgBox("DATA SUCCESSFULLY INSERTED...")
        pname.Clear()
        pbrand.Clear()
        mrp.Clear()
        disc.Clear()
        purprice.Clear()
        qty.Clear()
        supplier.Clear()
        category.Text = ""
        Call autoid()


    End Sub



    Private Sub DataGridView1_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        If DataGridView1.SelectedCells.Count > 0 Then
            Button2.Enabled = True
            Button3.Enabled = True
            MsgBox(DataGridView1.CurrentRow.Cells(0).Value.ToString)
        Else
            Button2.Enabled = False
            Button3.Enabled = False
        End If

    End Sub
End Class
