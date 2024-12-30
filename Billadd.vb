Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar
Imports MySql.Data.MySqlClient
Public Class Billadd


    Dim qry As String
    Dim cmd As MySqlCommand
    Dim Reader As MySqlDataReader
    Dim draftID As Integer
    Private Sub Billadd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim screenWidth As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim screenHeight As Integer = Screen.PrimaryScreen.Bounds.Height
        Me.Size = New Size(screenWidth, screenHeight)
        Setform(Me)

        LoadDraftBills()
        Me.KeyPreview = True
        Me.TopMost = False
        AdminDashboard.Close()
        ManagerDashboard.Close()
        EmployeeDashboard.Close()
        'Me.FormBorderStyle = FormBorderStyle.None
        Me.WindowState = FormWindowState.Maximized
        pid.Focus()
        Label1.Left = (Me.ClientSize.Width - Label1.Width) / 2
        Label1.Text = "BILLING"
        Label2.Text = "PRODUCT ID:"
        Label3.Text = "PRODUCT NAME:"
        Label4.Text = "PRODUCT BRAND:"
        Label5.Text = "HSN CODE:"
        Label6.Text = "PRODUCT PRICE:"
        Label7.Text = "PRODUCT QUANTITY:"
        Label8.Text = "PRODUCT DISCOUNT % :"
        Label9.Text = "PRODUCT GST % :"

        Label10.Text = "CUSTOMER NUMBER:"
        Label11.Text = "CUSTOMER NAME:"
        Label12.Text = "CUSTOMER EMAIL:"
        Label13.Text = "CUSTOMER DOB:"

        Label14.Text = "TOTAL ITEM:"
        Label15.Text = "TOTAL QUANTITY:"
        Label16.Text = "TOTAL DISCOUNT:"
        Label17.Text = "CGST:"
        Label18.Text = "SGST:"
        Label19.Text = "NET AMOUNT"
        Label20.Text = "BILL NO:"
        Label21.Text = ""
        Label22.Text = "AMOUNT"


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
        Label24.Text = ""
        Label25.AutoSize = True
        Label26.AutoSize = True
        Label27.AutoSize = True
        Label28.AutoSize = True

        Label26.Left = Label25.Right + 8
        Label27.Left = Label28.Right + 8

        Timer1.Enabled = True
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        TextBox6.Enabled = False
        TextBox7.Enabled = False


        autobill()
        Button1.Text = "UPDATE ITEM (F1)"
        Button2.Text = "DELETE ITEM (F2)"
        Button4.Text = "CLEAR (ESC)"
        Button5.Text = "CHECKOUT (F5)"

        ListView1.OwnerDraw = True
        ListView1.View = View.Details

        ListView1.Columns.Clear()
        ListView1.Columns.Add("  PRODUCT ID", 100, HorizontalAlignment.Center)
        ListView1.Columns.Add("PRODUCT NAME", 150, HorizontalAlignment.Center)
        ListView1.Columns.Add("BRAND", 120, HorizontalAlignment.Center)
        ListView1.Columns.Add("HSN CODE", 100, HorizontalAlignment.Center)
        ListView1.Columns.Add("PRICE", 100, HorizontalAlignment.Center)
        ListView1.Columns.Add("QTY", 70, HorizontalAlignment.Center)
        ListView1.Columns.Add("DIS %", 80, HorizontalAlignment.Center)
        ListView1.Columns.Add("GST %", 80, HorizontalAlignment.Center)
        ListView1.Columns.Add("TOTAL", 120, HorizontalAlignment.Center)
        ListView1.Columns.Add("PREGST", 120, HorizontalAlignment.Center)

    End Sub
    Private Sub ListView1_DrawColumnHeader(sender As Object, e As DrawListViewColumnHeaderEventArgs) Handles ListView1.DrawColumnHeader
        Using headerFont As New Font(e.Font, FontStyle.Bold)
            e.Graphics.FillRectangle(Brushes.LightBlue, e.Bounds)
            TextRenderer.DrawText(e.Graphics, e.Header.Text, headerFont, e.Bounds, Color.Black, TextFormatFlags.VerticalCenter Or TextFormatFlags.HorizontalCenter)
        End Using
    End Sub

    Private Sub ListView1_DrawItem(sender As Object, e As DrawListViewItemEventArgs) Handles ListView1.DrawItem
        e.DrawDefault = True
    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                Button1.PerformClick()
            Case Keys.F2
                Button2.PerformClick()
            Case Keys.F5
                Button5.PerformClick()
            Case Keys.F10
                Button6.PerformClick()
            Case Keys.Escape
                Button4.PerformClick()
            Case Else
        End Select
    End Sub

    Public Sub reloadBill()
        autobill()
        LoadDraftBills()
        TextBox1.Text = String.Empty
        TextBox2.Text = String.Empty
        TextBox3.Text = String.Empty
        TextBox4.Text = String.Empty
        TextBox5.Text = String.Empty
        TextBox6.Text = String.Empty
        TextBox7.Text = String.Empty
        TextBox8.Text = String.Empty
        TextBox9.Text = String.Empty
        TextBox10.Text = String.Empty
        TextBox11.Text = String.Empty
        TextBox12.Text = String.Empty
        TextBox13.Text = String.Empty
        TextBox14.Text = String.Empty
        TextBox15.Text = String.Empty
        TextBox16.Text = String.Empty
        TextBox17.Text = String.Empty
        DateTimePicker1.Text = Now()
        ListView1.Items.Clear()

    End Sub

    Public Sub autobill()
        Try
            If conn.State = ConnectionState.Closed Then
                Call connect()
            End If

            Dim qry As String = "SELECT MAX(bill_id) FROM bills"
            cmd = New MySqlCommand(qry, conn)

            Reader = cmd.ExecuteReader()

            If Reader.Read() AndAlso Not IsDBNull(Reader(0)) Then
                Dim bill_id As Double = Convert.ToDouble(Reader(0))
                Me.Label21.Text = (bill_id + 1).ToString()
                billid = Label21.Text
            Else
                Me.Label21.Text = "2001"
                billid = Label21.Text

            End If

            Reader.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub


    Private Sub UpdateBill()
        totalItems = ListView1.Items.Count
        totalQuantity = 0
        totalDiscount = 0.0
        totalAmount = 0.0
        Amount = 0.0
        cgst = 0.0
        sgst = 0.0

        For Each itm As ListViewItem In ListView1.Items
            Dim qty As Integer = Convert.ToInt32(itm.SubItems(5).Text)
            Dim price As Double = Convert.ToDouble(itm.SubItems(4).Text)
            Dim discount As Double = Convert.ToDouble(itm.SubItems(6).Text)
            Dim gst As Double = Convert.ToDouble(itm.SubItems(7).Text)

            Dim discountedPrice As Double = price - (price * discount / 100)
            Dim itemTotal As Double = discountedPrice * qty

            Dim amountqty = price * qty
            Amount += amountqty

            totalQuantity += qty
            totalDiscount += (price * discount / 100) * qty
            totalAmount += itemTotal

            preGst = Math.Round((itemTotal * 100) / (100 + gst), 2)
            Dim gstAmount As Double = Math.Round(itemTotal - preGst, 2)
            cgst += gstAmount / 2
            sgst += gstAmount / 2

        Next

        TextBox11.Text = totalItems.ToString()
        TextBox12.Text = totalQuantity.ToString()
        TextBox17.Text = Format(Amount, "0.00")
        TextBox13.Text = Format(totalDiscount, "0.00")
        TextBox14.Text = Format(cgst, "0.00")
        TextBox15.Text = Format(sgst, "0.00")
        TextBox16.Text = Math.Round(totalAmount)

    End Sub

    Private suppressTextChanged As Boolean = False ' Prevent overlap

    Private Sub pid_TextChanged(sender As Object, e As EventArgs) Handles pid.TextChanged
        If suppressTextChanged Then Exit Sub
        suppressTextChanged = True

        Try
            If String.IsNullOrWhiteSpace(pid.Text) Then
                suppressTextChanged = False
                Exit Sub
            End If

            TextBox5.Clear()

            If conn.State = ConnectionState.Closed Then
                connect()
            End If

            qry = "SELECT p.*, c.gst " &
              "FROM products p " &
              "INNER JOIN category c ON p.hsn_code = c.hsn_code " &
              "WHERE p.pro_id = @ProID"

            cmd = New MySqlCommand(qry, conn)
            cmd.Parameters.AddWithValue("@ProID", pid.Text)

            Dim proID As String = ""
            Dim proName As String = ""
            Dim proBrand As String = ""
            Dim proHSN As String = ""
            Dim proPrice As Double = 0.0
            Dim proDiscount As Double = 0.0
            Dim proGST As Double = 0.0
            Dim stock As Integer = 0
            Dim enteredQty As Integer = 1

            Reader = cmd.ExecuteReader()
            If Reader.HasRows Then
                Reader.Read()

                proID = Reader("pro_id").ToString()
                proName = Reader("pro_name").ToString()
                proBrand = Reader("pro_brand").ToString()
                proHSN = Reader("hsn_code").ToString()
                proPrice = Convert.ToDouble(Reader("pro_mrp"))
                proDiscount = Convert.ToDouble(Reader("pro_disc"))
                proGST = Convert.ToDouble(Reader("gst"))
                stock = Convert.ToInt32(Reader("pro_qty"))


                TextBox1.Text = proName
                TextBox2.Text = proBrand
                TextBox3.Text = proHSN
                TextBox4.Text = Format(proPrice, "0.00")
                TextBox6.Text = Format(proDiscount, "0.00")
                TextBox7.Text = Format(proGST, "0.00")

                If Not String.IsNullOrWhiteSpace(TextBox5.Text) Then
                    enteredQty = Convert.ToInt32(TextBox5.Text)
                End If

                ' stock check
                If enteredQty > stock Then
                    MessageBox.Show("Insufficient stock. Available quantity: " & stock.ToString(), "Stock Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Reader.Close()
                    conn.Close()
                    pid.Clear()
                    pid.Focus()
                    suppressTextChanged = False
                    Exit Sub
                End If

                Dim exists As Boolean = False
                For Each itm As ListViewItem In ListView1.Items
                    If String.Equals(itm.SubItems(0).Text, proID, StringComparison.OrdinalIgnoreCase) Then
                        Dim existingQty As Integer = Convert.ToInt32(itm.SubItems(5).Text)
                        Dim newQty As Integer = existingQty + enteredQty

                        If newQty > stock Then
                            MessageBox.Show("Insufficient stock. Available quantity: " & stock.ToString(), "Stock Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Reader.Close()
                            conn.Close()
                            pid.Focus()
                            suppressTextChanged = False
                            Exit Sub
                        End If

                        itm.SubItems(5).Text = newQty.ToString()
                        Dim totalAmount As Double = (proPrice - (proPrice * proDiscount / 100)) * newQty
                        itm.SubItems(8).Text = Format(totalAmount, "0.00")

                        exists = True
                        Exit For
                    End If
                Next

                If Not exists Then
                    Dim discountedPrice As Double = proPrice - (proPrice * proDiscount / 100)
                    Dim totalAmount As Double = discountedPrice * enteredQty
                    Dim preGstAmount As Double = Math.Round((totalAmount * 100) / (100 + proGST), 2)

                    Dim itm As New ListViewItem(proID)
                    itm.SubItems.Add(proName)
                    itm.SubItems.Add(proBrand)
                    itm.SubItems.Add(proHSN)
                    itm.SubItems.Add(Format(proPrice, "0.00"))
                    itm.SubItems.Add(enteredQty.ToString())
                    itm.SubItems.Add(Format(proDiscount, "0.00"))
                    itm.SubItems.Add(Format(proGST, "0.00"))
                    itm.SubItems.Add(Format(totalAmount, "0.00"))
                    itm.SubItems.Add(Format(preGstAmount, "0.00"))
                    ListView1.Items.Add(itm)
                End If
                pid.Clear()
                UpdateBill()
            Else
                'MessageBox.Show("Product not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If Reader IsNot Nothing AndAlso Not Reader.IsClosed Then
                Reader.Close()
            End If
            If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            suppressTextChanged = False
            pid.Focus()
        End Try
    End Sub




    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        If ListView1.SelectedItems.Count > 0 Then
            Dim selectedItem As ListViewItem = ListView1.SelectedItems(0)

            TextBox1.Text = selectedItem.SubItems(1).Text ' Product Name
            TextBox2.Text = selectedItem.SubItems(2).Text ' Brand
            TextBox3.Text = selectedItem.SubItems(3).Text ' Hsn
            TextBox4.Text = selectedItem.SubItems(4).Text ' Price
            TextBox5.Text = selectedItem.SubItems(5).Text ' Quantity
            TextBox6.Text = selectedItem.SubItems(6).Text ' Discount
            TextBox7.Text = selectedItem.SubItems(7).Text ' GST
        End If
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ListView1.SelectedItems.Count > 0 Then
            Dim selectedItem As ListViewItem = ListView1.SelectedItems(0)

            Dim productID As String = selectedItem.SubItems(0).Text
            Dim newQty As Integer

            If Integer.TryParse(TextBox5.Text, newQty) AndAlso newQty > 0 Then
                Dim stock As Integer = 0
                Try
                    If conn.State = ConnectionState.Closed Then
                        connect()
                    End If

                    Dim qry As String = "SELECT pro_qty FROM products WHERE pro_id = @ProID"
                    cmd = New MySqlCommand(qry, conn)
                    cmd.Parameters.AddWithValue("@ProID", productID)

                    Reader = cmd.ExecuteReader()

                    If Reader.HasRows Then
                        While Reader.Read()
                            stock = Convert.ToInt32(Reader("pro_qty"))
                        End While
                    End If
                    Reader.Close()

                    If newQty > stock Then
                        MessageBox.Show("Insufficient stock. Available quantity: " & stock.ToString(), "Stock Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        conn.Close()

                        Reader.Close()
                        conn.Close()
                        Exit Sub
                    End If

                Catch ex As Exception
                    MessageBox.Show("Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                        conn.Close()
                    End If
                End Try

                selectedItem.SubItems(5).Text = newQty.ToString()


                Dim price As Double = Convert.ToDouble(selectedItem.SubItems(4).Text)
                Dim discount As Double = Convert.ToDouble(selectedItem.SubItems(6).Text)
                Dim discountedPrice As Double = price - (price * discount / 100)
                Dim totalAmount As Double = discountedPrice * newQty

                selectedItem.SubItems(8).Text = Format(totalAmount, "0.00")
                UpdateBill()

            Else
                MessageBox.Show("Please enter a valid quantity.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("Please select an item from the list to update.", "No Item Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        TextBox5.Clear()
    End Sub




    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If ListView1.SelectedItems.Count > 0 Then
            Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete the selected item?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

            If result = DialogResult.Yes Then
                ListView1.Items.Remove(ListView1.SelectedItems(0))

                TextBox1.Text = String.Empty
                TextBox2.Text = String.Empty
                TextBox3.Text = String.Empty
                TextBox4.Text = String.Empty
                TextBox5.Text = String.Empty
                TextBox6.Text = String.Empty
                TextBox7.Text = String.Empty

                MessageBox.Show("Item deleted successfully...", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                UpdateBill()
            End If
        Else
            MessageBox.Show("Please select an item to delete.", "No Item Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles TextBox8.TextChanged
        If Not String.IsNullOrWhiteSpace(TextBox8.Text) Then
            Try
                If conn.State = ConnectionState.Closed Then
                    connect()
                End If

                qry = "SELECT * FROM customer WHERE cust_ph = @PhoneNumber"
                cmd = New MySqlCommand(qry, conn)
                cmd.Parameters.AddWithValue("@PhoneNumber", TextBox8.Text)

                Reader = cmd.ExecuteReader()

                If Reader.HasRows Then
                    While Reader.Read()
                        TextBox9.Text = Reader("cust_name").ToString()
                        TextBox10.Text = Reader("cust_email").ToString()
                        DateTimePicker1.Value = Convert.ToDateTime(Reader("cust_dob"))
                    End While
                Else
                    TextBox9.Clear()
                    TextBox10.Clear()
                    DateTimePicker1.Value = DateTime.Now
                End If
                Reader.Close()
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Try
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label24.Text = DateTime.Now.ToString("dddd")
        Label24.Text += "   " & DateTime.Now.ToString("dd MMMM yyyy") & "   " & TimeOfDay()
    End Sub

    Private Sub Label27_Click(sender As Object, e As EventArgs) Handles Label27.Click

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        pid.Clear
        TextBox1.Clear
        TextBox2.Clear
        TextBox3.Clear
        TextBox4.Clear
        TextBox5.Clear
        TextBox6.Clear
        TextBox7.Clear
        TextBox8.Clear
        TextBox9.Clear
        TextBox10.Clear
        TextBox11.Clear
        TextBox12.Clear
        TextBox13.Clear
        TextBox14.Clear
        TextBox15.Clear
        TextBox16.Clear
        TextBox17.Clear()
        totalAmount = 0
        DateTimePicker1.Text = Now
        ListView1.Items.Clear


    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        checkout.SetListViewData(ListView1.Items)
        custnum = TextBox8.Text
        custname = TextBox9.Text
        custmail = TextBox10.Text
        custdob = DateTimePicker1.Value.ToString("yyyy-MM-dd")

        checkout.Show()
    End Sub

    'draft billing
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If Not String.IsNullOrWhiteSpace(TextBox8.Text) AndAlso Not String.IsNullOrWhiteSpace(TextBox9.Text) Then
            Try
                If conn.State = ConnectionState.Closed Then
                    connect()
                End If

                For Each itm As ListViewItem In ListView1.Items
                    Dim qry As String = "INSERT INTO draft_bills (customer_phone, customer_name, product_id, product_name, product_price, quantity, discount, gst, total_amount, brand, hsn, pregst, date_created) " &
                                    "VALUES (@Phone, @Name, @ProID, @ProName, @ProPrice, @Qty, @Discount, @GST, @TotalAmount, @Brand, @HSN, @PreGST, NOW())"
                    cmd = New MySqlCommand(qry, conn)
                    cmd.Parameters.AddWithValue("@Phone", TextBox8.Text) ' Customer phone number
                    cmd.Parameters.AddWithValue("@Name", TextBox9.Text) ' Customer name
                    cmd.Parameters.AddWithValue("@ProID", itm.SubItems(0).Text)
                    cmd.Parameters.AddWithValue("@ProName", itm.SubItems(1).Text)
                    cmd.Parameters.AddWithValue("@ProPrice", Convert.ToDouble(itm.SubItems(4).Text))
                    cmd.Parameters.AddWithValue("@Qty", Convert.ToInt32(itm.SubItems(5).Text))
                    cmd.Parameters.AddWithValue("@Discount", Convert.ToDouble(itm.SubItems(6).Text))
                    cmd.Parameters.AddWithValue("@GST", Convert.ToDouble(itm.SubItems(7).Text))
                    cmd.Parameters.AddWithValue("@TotalAmount", Convert.ToDouble(itm.SubItems(8).Text))
                    cmd.Parameters.AddWithValue("@Brand", itm.SubItems(2).Text) ' Brand
                    cmd.Parameters.AddWithValue("@HSN", itm.SubItems(3).Text) ' HSN
                    cmd.Parameters.AddWithValue("@PreGST", Convert.ToDouble(itm.SubItems(9).Text)) 'PreGST

                    cmd.ExecuteNonQuery()
                Next

                MessageBox.Show("Draft bill saved successfully.", "Draft Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Try
            reloadBill()

        Else
            MessageBox.Show("Please enter both customer phone number and name.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub


    Private Sub LoadDraftBills()
        Try
            If conn.State = ConnectionState.Closed Then
                connect()
            End If

            Dim qry As String = "SELECT DISTINCT customer_phone, customer_name FROM draft_bills WHERE status = 'draft'"
            cmd = New MySqlCommand(qry, conn)
            Reader = cmd.ExecuteReader()

            ComboBox1.Items.Clear()

            While Reader.Read()
                Dim customerPhone As String = Reader("customer_phone").ToString()
                Dim customerName As String = Reader("customer_name").ToString()
                ComboBox1.Items.Add(customerName & " (" & customerPhone & ")")
            End While

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If Reader IsNot Nothing AndAlso Not Reader.IsClosed Then
                Reader.Close()
            End If
            If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Try
            If conn.State = ConnectionState.Closed Then
                connect()
            End If
            TextBox1.Text = String.Empty
            TextBox2.Text = String.Empty
            TextBox3.Text = String.Empty
            TextBox4.Text = String.Empty
            TextBox5.Text = String.Empty
            TextBox6.Text = String.Empty
            TextBox7.Text = String.Empty
            TextBox8.Text = String.Empty
            TextBox9.Text = String.Empty
            TextBox10.Text = String.Empty
            TextBox11.Text = String.Empty
            TextBox12.Text = String.Empty
            TextBox13.Text = String.Empty
            TextBox14.Text = String.Empty
            TextBox15.Text = String.Empty
            TextBox16.Text = String.Empty
            TextBox17.Text = String.Empty
            DateTimePicker1.Text = Now()
            Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
            Dim nameParts As String() = selectedItem.Split("(")
            Dim customerName As String = nameParts(0).Trim()
            Dim customerPhone As String = nameParts(1).Replace(")", "").Trim()

            Dim qry As String = "SELECT * FROM draft_bills WHERE customer_phone = @Phone AND customer_name = @Name AND status = 'draft'"
            Dim qryDelete As String = "DELETE FROM draft_bills WHERE customer_phone = @Phone AND customer_name = @Name AND status = 'draft'"
            Using cmd As New MySqlCommand(qry, conn)
                cmd.Parameters.AddWithValue("@Phone", customerPhone)
                cmd.Parameters.AddWithValue("@Name", customerName)

                Using Reader As MySqlDataReader = cmd.ExecuteReader()
                    ListView1.Items.Clear()
                    Dim totalAmount As Double = 0

                    While Reader.Read()

                        Dim itm As New ListViewItem(Reader("product_id").ToString())
                        itm.SubItems.Add(Reader("product_name").ToString())
                        itm.SubItems.Add(Reader("brand").ToString()) ' Brand
                        itm.SubItems.Add(Reader("hsn").ToString()) ' HSN
                        itm.SubItems.Add(Convert.ToDouble(Reader("product_price").ToString()))
                        itm.SubItems.Add(Reader("quantity").ToString())
                        itm.SubItems.Add(Convert.ToDouble(Reader("discount").ToString()))
                        itm.SubItems.Add(Convert.ToDouble(Reader("gst").ToString()))
                        itm.SubItems.Add(Convert.ToDouble(Reader("total_amount").ToString()))
                        itm.SubItems.Add(Convert.ToDouble(Reader("pregst").ToString())) ' Pre-GST
                        ListView1.Items.Add(itm)

                        totalAmount += Convert.ToDouble(Reader("total_amount"))
                    End While
                End Using
            End Using


            TextBox8.Text = customerPhone
            If conn.State = ConnectionState.Closed Then
                connect()
            End If
            Using cmdDelete As New MySqlCommand(qryDelete, conn)
                cmdDelete.Parameters.AddWithValue("@Phone", customerPhone)
                cmdDelete.Parameters.AddWithValue("@Name", customerName)
                cmdDelete.ExecuteNonQuery()
            End Using
            ComboBox1.SelectedText = ""
            ComboBox1.Text = ""


            MessageBox.Show("Draft bill loaded successfully.", "Draft Loaded", MessageBoxButtons.OK, MessageBoxIcon.Information)



        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        UpdateBill()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        If user = "admin" Then
            AdminDashboard.Show()
        ElseIf user = "manager" Then
            ManagerDashboard.Show()
        ElseIf user = "emp" Then
            EmployeeDashboard.Show()
        End If
    End Sub


End Class