Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports MySql.Data.MySqlClient
Public Class product
    Dim qry As String
    Protected Overrides ReadOnly Property CreateParams As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or &H2000000 ' WS_EX_COMPOSITED
            Return cp
        End Get
    End Property
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Call connect()
        Me.KeyPreview = True
        Setform(Me)

        Dim screenWidth As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim screenHeight As Integer = Screen.PrimaryScreen.Bounds.Height
        Me.Size = New Size(screenWidth, screenHeight)
        'Me.FormBorderStyle = FormBorderStyle.None
        Me.WindowState = FormWindowState.Maximized
        AdminDashboard.Close()
        ManagerDashboard.Close()
        EmployeeDashboard.Close()
        Label1.Text = "Product Id:"
        Label2.Text = "Product Name:"
        Label3.Text = "Product Brand:"
        Label6.Text = "MRP:"
        Label5.Text = "Purchase Price:"
        Label4.Text = "Category:"
        Label8.Text = "Quantity:"
        Label7.Text = "Discount:"
        Label10.Text = "HSN Code:"
        Label11.Text = "Stock Date:"
        'Label9.Text = "INVENTORY MANAGEMENT"

        Button1.Text = "Insert Item"
        Button2.Text = "Update Item"
        Button3.Text = "Delete Item"
        Button4.Text = "Clear"

        Button2.Enabled = False
        Button3.Enabled = False


        If user = "admin" Then
            Label27.Text = username
            Label26.Text = userid
            Label25.Text = "ADMIN ID:"
            Label28.Text = "ADMIN NAME:"

        ElseIf user = "manager" Then
            Label27.Text = username
            Label26.Text = userid
            Label25.Text = "MANAGER ID:"
            Label28.Text = "MANAGER NAME:"
        ElseIf user = "emp" Then
            Label27.Text = username
            Label26.Text = userid
            Label25.Text = "EMPLOYEE ID:"
            Label28.Text = "EMPLOYEE NAME:"

        End If
        Label25.AutoSize = True
        Label26.AutoSize = True
        Label27.AutoSize = True
        Label28.AutoSize = True

        Label26.Left = Label25.Right + 8
        Label27.Left = Label28.Right + 8
        Label24.Text = ""

        Timer1.Enabled = True


        pid.Enabled = False
        stockdate.Enabled = False
        stockdate.Text = Today.ToString("yyyy-MM-dd")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Call showdata()
        Call autoid()
        Call loadcat()
        pname.Focus()

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label24.Text = DateTime.Now.ToString("dddd")
        Label24.Text += "   " & DateTime.Now.ToString("dd MMMM yyyy") & "   " & TimeOfDay.ToString("HH:mm:ss")
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
        qry = "SELECT cat_name, hsn_code FROM category"
        Dim da As New MySqlDataAdapter(qry, conn)
        Dim dt As New DataTable()

        da.Fill(dt)
        category.Items.Clear()
        category.Tag = New Dictionary(Of String, List(Of String))
        Dim hsnDict As Dictionary(Of String, List(Of String)) = CType(category.Tag, Dictionary(Of String, List(Of String)))

        For Each row As DataRow In dt.Rows
            Dim catName As String = row("cat_name").ToString()
            Dim hsnCode As String = row("hsn_code").ToString()

            If Not hsnDict.ContainsKey(catName) Then
                hsnDict(catName) = New List(Of String)()
            End If

            hsnDict(catName).Add(hsnCode)
            If Not category.Items.Contains(catName) Then
                category.Items.Add(catName)
            End If
        Next
        conn.Close()
    End Sub

    Private Sub category_SelectedIndexChanged(sender As Object, e As EventArgs) Handles category.SelectedIndexChanged
        If category.SelectedItem IsNot Nothing Then
            Dim selectedCategory As String = category.SelectedItem.ToString()
            Dim hsnDict As Dictionary(Of String, List(Of String)) = CType(category.Tag, Dictionary(Of String, List(Of String)))

            ComboBox1.Items.Clear()

            If hsnDict.ContainsKey(selectedCategory) Then
                For Each hsnCode As String In hsnDict(selectedCategory)
                    ComboBox1.Items.Add(hsnCode)
                Next
            End If
        End If
    End Sub

    'Insert data
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ValidateFields() Then
            Try


                connect()
                Dim cmd As New MySqlCommand
                qry = "insert into products values('" & pid.Text & "','" & pname.Text & "','" & pbrand.Text &
                  "','" & category.Text & "','" & purprice.Text & "','" & mrp.Text & "','" & disc.Text & "','" & qty.Text & "',
              '" & ComboBox1.Text & "', curdate())"
                cmd.CommandText = qry
                cmd.Connection = conn
                cmd.ExecuteNonQuery()
                conn.Close()
                showdata()
                MsgBox("DATA SUCCESSFULLY INSERTED...")
                clear()
            Catch ex As Exception
                MsgBox("PRODUCT ID IS ALREADY IN INVENTORY...", MsgBoxStyle.Critical
                       )
            End Try
        End If
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
            ComboBox1.Text = DataGridView1.CurrentRow.Cells(8).Value.ToString
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
        ComboBox1.Text = ""
        category.Text = ""
        autoid()
        stockdate.Text = Today.ToString("yyyy-MM-dd")
        pname.Focus()
    End Sub

    'Delete
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If Not String.IsNullOrEmpty(pid.Text) Then
            Dim cmd As New MySqlCommand
            Dim r As Integer
            Try
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
            Catch ex As Exception
                MsgBox("Deletion Operation not proceed..")
            End Try
        Else
            MsgBox("Please select a product to delete.")
        End If
    End Sub

    'Update
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If ValidateFields() Then
            Dim cmd As New MySqlCommand
            Dim r As Integer
            Try


                connect()
                qry = "update products set pro_name = '" & pname.Text & "', pro_brand = '" & pbrand.Text & "', cat_name='" & category.Text & "', " &
                  "pro_purprice='" & purprice.Text & "', pro_mrp='" & mrp.Text & "', pro_disc = '" & disc.Text & "', pro_qty ='" & qty.Text & "', " &
                  "hsn_code = '" & ComboBox1.Text & "', stockdate = curdate() where pro_id = '" & pid.Text & "'"
                cmd.CommandText = qry
                cmd.Connection = conn
                r = MsgBox("Do you want to Update Product id: " & pid.Text & "...", MsgBoxStyle.YesNo)
                If r = 6 Then
                    cmd.ExecuteNonQuery()
                End If
                conn.Close()
                showdata()
                clear()
            Catch ex As Exception
                MsgBox("Update Operation not proceed..")

            End Try
        End If
    End Sub
    Private Function ValidateFields() As Boolean
        If pname.Text.Trim() = "" Then
            MsgBox("Please enter Product Name.")
            pname.Focus()
            Return False
        End If

        If pbrand.Text.Trim() = "" Then
            MsgBox("Please enter Product Brand.")
            pbrand.Focus()
            Return False
        End If

        If category.Text.Trim() = "" Then
            MsgBox("Please select a Category.")
            category.Focus()
            Return False
        End If

        If Not IsNumeric(purprice.Text) OrElse Convert.ToDecimal(purprice.Text) <= 0 Then
            MsgBox("Please enter a valid Purchase Price.")
            purprice.Focus()
            Return False
        End If

        If Not IsNumeric(mrp.Text) OrElse Convert.ToDecimal(mrp.Text) <= 0 Then
            MsgBox("Please enter a valid MRP.")
            mrp.Focus()
            Return False
        End If

        If Not IsNumeric(disc.Text) OrElse Convert.ToDecimal(disc.Text) < 0 Then
            MsgBox("Please enter a valid Discount.")
            disc.Focus()
            Return False
        End If

        If Not IsNumeric(qty.Text) OrElse Convert.ToInt32(qty.Text) <= 0 Then
            MsgBox("Please enter a valid Quantity.")
            qty.Focus()
            Return False
        End If

        If ComboBox1.Text.Trim() = "" Then
            MsgBox("Please select a valid HSN Code.")
            ComboBox1.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        If user = "admin" Then
            AdminDashboard.Show()
        ElseIf user = "manager" Then
            ManagerDashboard.Show()
        End If
    End Sub
End Class
