Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports MySql.Data.MySqlClient
Imports System.Runtime.InteropServices
Public Class Billadd


    Dim qry As String
    Dim cmd As MySqlCommand
    Dim Reader As MySqlDataReader
    Dim totalItems As Integer = 0
    Dim totalQuantity As Integer = 0
    Dim preGst As Double = 0.0
    Dim Amount As Double = 0.0
    Dim totalDiscount As Double = 0.0
    Dim totalAmount As Double = 0.0
    Dim cgst As Double = 0.0
    Dim sgst As Double = 0.0


    Private Sub Billadd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim screenWidth As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim screenHeight As Integer = Screen.PrimaryScreen.Bounds.Height
        Me.Size = New Size(screenWidth, screenHeight)


        ' Full screen form
        Me.TopMost = True

        'Me.FormBorderStyle = FormBorderStyle.None
        Me.WindowState = FormWindowState.Maximized
        pid.Focus()
        Label1.Left = (Me.ClientSize.Width - Label1.Width) / 2
        Label1.Text = "BILLING"
        Label2.Text = "PRODUCT ID:"
        Label3.Text = "PRODUCT NAME:"
        Label4.Text = "PRODUCT BRAND:"
        Label5.Text = "PRODUCT CATEGORY:"
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
        Label20.Text = "BILL ID:"
        Label21.Text = ""
        Label27.Text = ""
        Label26.Text = ""
        Label22.Text = "AMOUNT"
        Label25.Text = "CASHIER ID:"
        Label28.Text = "CASHIER NAME:"
        Label23.Text = "DATE:"
        Label24.Text = ""
        Timer1.Enabled = True
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        TextBox6.Enabled = False
        TextBox7.Enabled = False

        autobill()
        Button1.Text = "UPDATE ITEM"
        Button2.Text = "DELETE ITEM"
        Button3.Text = "DRAFT ITEM"
        Button4.Text = "CLEAR"
        Button5.Text = "Generate Bill"

        ListView1.View = View.Details
        ListView1.Columns.Clear()
        ListView1.Columns.Add("PRODUCT ID", 100, HorizontalAlignment.Left)
        ListView1.Columns.Add("PRODUCT NAME", 150, HorizontalAlignment.Left)
        ListView1.Columns.Add("BRAND", 120, HorizontalAlignment.Left)
        ListView1.Columns.Add("CATEGORY", 100, HorizontalAlignment.Left)
        ListView1.Columns.Add("PRICE", 100, HorizontalAlignment.Left)
        ListView1.Columns.Add("QUANTITY", 70, HorizontalAlignment.Left)
        ListView1.Columns.Add("DISCOUNT", 80, HorizontalAlignment.Left)
        ListView1.Columns.Add("GST", 80, HorizontalAlignment.Left)
        ListView1.Columns.Add("TOTAL", 120, HorizontalAlignment.Left)
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
            Else
                Me.Label21.Text = "2001"
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
            Dim qty As Integer = Convert.ToInt32(itm.SubItems(5).Text) ' Quantity
            Dim price As Double = Convert.ToDouble(itm.SubItems(4).Text) ' Price
            Dim discount As Double = Convert.ToDouble(itm.SubItems(6).Text) ' Discount percentage
            Dim gst As Double = Convert.ToDouble(itm.SubItems(7).Text) ' GST percentage

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
        TextBox16.Text = Format(totalAmount)
    End Sub


    Private Sub pid_TextChanged(sender As Object, e As EventArgs) Handles pid.TextChanged
        Call connect()
        qry = "SELECT p.*, c.gst " &
                    "FROM products p " &
                    "INNER JOIN category c ON p.cat_name = c.cat_name " &
                    "WHERE p.pro_id = @ProID"
        cmd = New MySqlCommand(qry, conn)
        cmd.Parameters.AddWithValue("@ProID", pid.Text)

        Dim proID As String = ""
        Dim proName As String = ""
        Dim proBrand As String = ""
        Dim proCategory As String = ""
        Dim proPrice As Double = 0.0
        Dim proDiscount As Double = 0.0
        Dim proGST As Double = 0.0
        Dim enteredQty As Integer = 1

        Reader = cmd.ExecuteReader()
        If Reader.HasRows Then
            While Reader.Read()
                proID = Reader("pro_id").ToString()
                proName = Reader("pro_name").ToString()
                proBrand = Reader("pro_brand").ToString()
                proCategory = Reader("cat_name").ToString()
                proPrice = Convert.ToDouble(Reader("pro_mrp"))
                proDiscount = Convert.ToDouble(Reader("pro_disc"))
                proGST = Convert.ToDouble(Reader("gst"))


                TextBox1.Text = proName
                TextBox2.Text = proBrand
                TextBox3.Text = proCategory
                TextBox4.Text = proPrice

                TextBox6.Text = proDiscount
                TextBox7.Text = proGST

                If Not String.IsNullOrWhiteSpace(TextBox5.Text) Then
                    enteredQty = Convert.ToInt32(TextBox5.Text)
                End If

                Dim discountedPrice As Double = proPrice - (proPrice * proDiscount / 100)
                Dim totalAmount As Double = discountedPrice * enteredQty

                Dim exists As Boolean = False

                For Each itm As ListViewItem In ListView1.Items
                    If itm.SubItems(0).Text = proID Then
                        Dim existingQty As Integer = Convert.ToInt32(itm.SubItems(5).Text)
                        Dim newQty As Integer = existingQty + enteredQty
                        itm.SubItems(5).Text = newQty.ToString()

                        Dim existingTotal As Double = Convert.ToDouble(itm.SubItems(8).Text)
                        itm.SubItems(8).Text = Format(existingTotal + totalAmount, "0.00")

                        exists = True
                        Exit For
                    End If
                Next

                If Not exists Then
                    Dim itm As New ListViewItem(proID)
                    itm.SubItems.Add(proName)
                    itm.SubItems.Add(proBrand)
                    itm.SubItems.Add(proCategory)
                    itm.SubItems.Add(Format(proPrice, "0.00")) ' Original price
                    itm.SubItems.Add(enteredQty.ToString()) ' Quantity
                    itm.SubItems.Add(Format(proDiscount, "0.00")) ' Discount
                    itm.SubItems.Add(Format(proGST, "0.00")) ' GST percentage
                    itm.SubItems.Add(Format(totalAmount, "0.00")) ' Total amount
                    ListView1.Items.Add(itm)
                End If
            End While
            UpdateBill()
        End If
        Reader.Close()
        conn.Close()
        pid.Focus()
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        If ListView1.SelectedItems.Count > 0 Then
            Dim selectedItem As ListViewItem = ListView1.SelectedItems(0)

            TextBox1.Text = selectedItem.SubItems(1).Text ' Product Name
            TextBox2.Text = selectedItem.SubItems(2).Text ' Brand
            TextBox3.Text = selectedItem.SubItems(3).Text ' Category
            TextBox4.Text = selectedItem.SubItems(4).Text ' Price
            TextBox5.Text = selectedItem.SubItems(5).Text ' Quantity
            TextBox6.Text = selectedItem.SubItems(6).Text ' Discount
            TextBox7.Text = selectedItem.SubItems(7).Text ' GST
        End If
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ListView1.SelectedItems.Count > 0 Then
            Dim selectedItem As ListViewItem = ListView1.SelectedItems(0)

            Dim newQty As Integer
            If Integer.TryParse(TextBox5.Text, newQty) AndAlso newQty > 0 Then
                selectedItem.SubItems(5).Text = newQty.ToString()

                Dim price As Double = Convert.ToDouble(selectedItem.SubItems(4).Text)
                Dim discount As Double = Convert.ToDouble(selectedItem.SubItems(6).Text)
                Dim discountedPrice As Double = price - (price * discount / 100)
                Dim totalAmount As Double = discountedPrice * newQty

                Dim gst As Double = Convert.ToDouble(selectedItem.SubItems(7).Text)


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

    Private Sub InsertNewCustomer()
        Try
            If conn.State = ConnectionState.Closed Then
                connect()
            End If

            qry = "INSERT INTO customer (cust_ph, cust_name, cust_email, cust_dob) VALUES (@PhoneNumber, @Name, @Email, @DOB)"
            cmd = New MySqlCommand(qry, conn)

            cmd.Parameters.AddWithValue("@PhoneNumber", TextBox8.Text)
            cmd.Parameters.AddWithValue("@Name", TextBox9.Text)
            cmd.Parameters.AddWithValue("@Email", TextBox10.Text)
            cmd.Parameters.AddWithValue("@DOB", DateTimePicker1.Value.ToString("yyyy-MM-dd"))

            cmd.ExecuteNonQuery()
            MessageBox.Show("New customer added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        InsertNewCustomer()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label24.Text = Now
    End Sub

    Private Sub Label27_Click(sender As Object, e As EventArgs) Handles Label27.Click

    End Sub
End Class