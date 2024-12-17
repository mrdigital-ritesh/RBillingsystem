Imports System.Windows.Forms.VisualStyles.VisualStyleElement
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
        Label9.Text = "INVENTORY CONTROL"

        Button1.Text = "Insert Item"
        Button2.Text = "Update Item"
        Button3.Text = "Delete Item"
        Button4.Text = "Clear"

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

    'Category load in dropdown
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

    'Insert data
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        connect()
        Dim cmd As New MySqlCommand
        qry = "insert into products values('" & pid.Text & "','" & pname.Text & "','" & pbrand.Text &
            "','" & category.Text & "','" & purprice.Text & "','" & mrp.Text & "','" & disc.Text & "','" & qty.Text & "',
            '" & supplier.Text & "', curdate())"
        cmd.CommandText = qry
        'cmd.CommandType = CommandType.Text
        cmd.Connection = conn
        cmd.ExecuteNonQuery()
        conn.Close()
        showdata()
        MsgBox("DATA SUCCESSFULLY INSERTED...")
        clear()


    End Sub


    'Data select
    Private Sub DataGridView1_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        If DataGridView1.SelectedCells.Count > 0 Then
            Button2.Enabled = True
            Button3.Enabled = True
            pid.Text = DataGridView1.CurrentRow.Cells(0).Value.ToString
            pname.Text = DataGridView1.CurrentRow.Cells(1).Value.ToString
            pbrand.Text = DataGridView1.CurrentRow.Cells(2).Value.ToString
            category.Text = DataGridView1.CurrentRow.Cells(3).Value.ToString
            purprice.Text = DataGridView1.CurrentRow.Cells(4).Value.ToString
            mrp.Text = DataGridView1.CurrentRow.Cells(5).Value.ToString
            disc.Text = DataGridView1.CurrentRow.Cells(6).Value.ToString
            qty.Text = DataGridView1.CurrentRow.Cells(7).Value.ToString
            supplier.Text = DataGridView1.CurrentRow.Cells(8).Value.ToString
            stockdate.Text = DataGridView1.CurrentRow.Cells(9).Value.ToString
            'MsgBox(DataGridView1.CurrentRow.Cells(0).Value.ToString)
        Else
            Button2.Enabled = False
            Button3.Enabled = False
        End If

    End Sub

    'Clear field
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        clear()
    End Sub
    Public Sub clear()
        pname.Clear()
        pbrand.Clear()
        mrp.Clear()
        disc.Clear()
        purprice.Clear()
        qty.Clear()
        supplier.Clear()
        category.Text = ""
        autoid()
        stockdate.Text = Today.ToString("yyyy-MM-dd")
        pname.Focus()
    End Sub

    'Delete
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim cmd As New MySqlCommand
        Dim r As Integer
        connect()
        qry = "delete from products where pro_id = '" & pid.Text & "'"
        cmd.CommandText = qry
        cmd.Connection = conn
        r = MsgBox("Do you want to delete Product id: " & pid.Text & "...", MsgBoxStyle.YesNo)
        If r = 6 Then
            cmd.ExecuteNonQuery()
        End If
        conn.Close()
        showdata()
        clear()


    End Sub

    'Update
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim cmd As New MySqlCommand
        Dim r As Integer
        connect()
        qry = "update products set pro_name = '" & pname.Text & "',pro_brand = '" & pbrand.Text & "',cat_name='" & category.Text & "',pro_purprice='" & purprice.Text & "',pro_mrp='" & mrp.Text & "',pro_disc = '" & disc.Text & "',pro_qty ='" & qty.Text & "',supp_id = '" & supplier.Text & "',stockdate = curdate() where pro_id = '" & pid.Text & "'"
        cmd.CommandText = qry
        cmd.Connection = conn
        r = MsgBox("Do you want to Update Product id: " & pid.Text & "...", MsgBoxStyle.YesNo)
        If r = 6 Then
            cmd.ExecuteNonQuery()
        End If
        conn.Close()
        showdata()
        clear()

    End Sub

    
End Class
