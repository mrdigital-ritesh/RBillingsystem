Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports MySql.Data.MySqlClient
Public Class Billadd


    Dim qry As String
    Dim cmd As MySqlCommand
    Dim Reader As MySqlDataReader




    Private Sub Billadd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim screenWidth As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim screenHeight As Integer = Screen.PrimaryScreen.Bounds.Height
        Me.Size = New Size(screenWidth, screenHeight)

        Me.TopMost = False
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
        Label27.Text = ""
        Label26.Text = ""
        Label22.Text = "AMOUNT"
        Label25.Text = "EMPLOYEE ID:"
        Label28.Text = "EMPLOYEE NAME:"
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
        Button5.Text = "CHECKOUT"

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

    Public Sub reloadBill()
        autobill()
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
        TextBox16.Text = Math.Round(totalAmount)

    End Sub

    Private suppressTextChanged As Boolean = False ' Prevent overlap

    Private Sub pid_TextChanged(sender As Object, e As EventArgs) Handles pid.TextChanged
        If suppressTextChanged Then Exit Sub ' Prevent overlapping executions
        suppressTextChanged = True

        Try
            If String.IsNullOrWhiteSpace(pid.Text) Then
                suppressTextChanged = False
                Exit Sub
            End If

            TextBox5.Clear() ' Clear quantity input

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

                ' Fetch product details
                proID = Reader("pro_id").ToString()
                proName = Reader("pro_name").ToString()
                proBrand = Reader("pro_brand").ToString()
                proHSN = Reader("hsn_code").ToString()
                proPrice = Convert.ToDouble(Reader("pro_mrp"))
                proDiscount = Convert.ToDouble(Reader("pro_disc"))
                proGST = Convert.ToDouble(Reader("gst"))
                stock = Convert.ToInt32(Reader("pro_qty"))

                ' Update UI fields
                TextBox1.Text = proName
                TextBox2.Text = proBrand
                TextBox3.Text = proHSN
                TextBox4.Text = Format(proPrice, "0.00")
                TextBox6.Text = Format(proDiscount, "0.00")
                TextBox7.Text = Format(proGST, "0.00")

                If Not String.IsNullOrWhiteSpace(TextBox5.Text) Then
                    enteredQty = Convert.ToInt32(TextBox5.Text)
                End If

                ' Validate stock
                If enteredQty > stock Then
                    MessageBox.Show("Insufficient stock. Available quantity: " & stock.ToString(), "Stock Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Reader.Close()
                    conn.Close()
                    pid.Focus()
                    suppressTextChanged = False
                    Exit Sub
                End If

                ' Check if product is already in the ListView
                Dim exists As Boolean = False
                For Each itm As ListViewItem In ListView1.Items
                    If String.Equals(itm.SubItems(0).Text, proID, StringComparison.OrdinalIgnoreCase) Then
                        ' Product already exists; update quantity and total
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

                        ' Update ListView item
                        itm.SubItems(5).Text = newQty.ToString()
                        Dim totalAmount As Double = (proPrice - (proPrice * proDiscount / 100)) * newQty
                        itm.SubItems(8).Text = Format(totalAmount, "0.00")

                        exists = True
                        Exit For
                    End If
                Next

                ' If the product is not already in the ListView, add it
                If Not exists Then
                    Dim discountedPrice As Double = proPrice - (proPrice * proDiscount / 100)
                    Dim totalAmount As Double = discountedPrice * enteredQty
                    Dim preGstAmount As Double = Math.Round((totalAmount * 100) / (100 + proGST), 2)

                    ' Add new product to the ListView
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
            suppressTextChanged = False ' Allow further executions
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

                    ' Execute the query to fetch the stock quantity
                    Reader = cmd.ExecuteReader()

                    If Reader.HasRows Then
                        While Reader.Read()
                            stock = Convert.ToInt32(Reader("pro_qty"))
                        End While
                    End If
                    Reader.Close()

                    ' Check if the new quantity exceeds available stock
                    If newQty > stock Then
                        MessageBox.Show("Insufficient stock. Available quantity: " & stock.ToString(), "Stock Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        conn.Close()

                        Reader.Close()
                        conn.Close()
                        Exit Sub ' Exit if stock is insufficient
                    End If

                Catch ex As Exception
                    MessageBox.Show("Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                        conn.Close()
                    End If
                End Try

                ' If stock is sufficient, update the quantity and total amount in ListView
                selectedItem.SubItems(5).Text = newQty.ToString()

                ' Calculate new total amount
                Dim price As Double = Convert.ToDouble(selectedItem.SubItems(4).Text)
                Dim discount As Double = Convert.ToDouble(selectedItem.SubItems(6).Text)
                Dim discountedPrice As Double = price - (price * discount / 100)
                Dim totalAmount As Double = discountedPrice * newQty

                ' Update total amount for the item in the ListView
                selectedItem.SubItems(8).Text = Format(totalAmount, "0.00")
                UpdateBill() ' Recalculate the total bill

            Else
                MessageBox.Show("Please enter a valid quantity.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("Please select an item from the list to update.", "No Item Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        ' Clear the quantity input field after update
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
        Label24.Text = Now
    End Sub

    Private Sub Label27_Click(sender As Object, e As EventArgs) Handles Label27.Click

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        pid.Clear()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        TextBox8.Clear()
        TextBox9.Clear()
        TextBox10.Clear()
        TextBox11.Clear()
        TextBox12.Clear()
        TextBox13.Clear()
        TextBox14.Clear()
        TextBox15.Clear()
        TextBox16.Clear()
        TextBox17.Clear()
        DateTimePicker1.Text = Now
        ListView1.Items.Clear()


    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        checkout.SetListViewData(ListView1.Items)
        custnum = TextBox8.Text
        custname = TextBox9.Text
        custmail = TextBox10.Text
        custdob = DateTimePicker1.Value.ToString("yyyy-MM-dd")

        checkout.Show()
    End Sub
End Class