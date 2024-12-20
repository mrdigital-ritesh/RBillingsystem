Imports System.Windows.Forms.ListView
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports MySql.Data.MySqlClient

Public Class checkout

    Dim qry As String
    Dim cmd As MySqlCommand
    Dim Reader As MySqlDataReader
    Private Sub closebt_Click(sender As Object, e As EventArgs) Handles closebt.Click
        Me.Close()
    End Sub

    Private Sub checkout_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.TopMost = True
        TextBox2.Focus()


        Label6.Text = "MODE: CASH"
        Label1.Text = "PROCEED TO PAY"
        Label9.Text = "BILL NO:"
        Label9.Text += " " + billid.ToString
        Label1.Left = (Me.ClientSize.Width - Label1.Width) / 2
        Label6.Left = (Me.Panel3.Width - Label6.Width) / 2

        TextBox4.Text = Math.Round(totalAmount)
        TextBox1.Text = Math.Round(totalAmount)

        UpdateAmountInWords()
        TextBox2.Focus()
        ListView2.View = View.Details

        ListView2.Columns.Clear()
        ListView2.Columns.Add("  PRODUCT ID", 100, HorizontalAlignment.Center)
        ListView2.Columns.Add("PRODUCT NAME", 150, HorizontalAlignment.Center)
        ListView2.Columns.Add("BRAND", 120, HorizontalAlignment.Center)
        ListView2.Columns.Add("CATEGORY", 100, HorizontalAlignment.Center)
        ListView2.Columns.Add("PRICE", 100, HorizontalAlignment.Center)
        ListView2.Columns.Add("QTY", 70, HorizontalAlignment.Center)
        ListView2.Columns.Add("DIS %", 80, HorizontalAlignment.Center)
        ListView2.Columns.Add("GST %", 80, HorizontalAlignment.Center)
        ListView2.Columns.Add("TOTAL", 120, HorizontalAlignment.Center)
        ListView2.Columns.Add("PREGST", 120, HorizontalAlignment.Center)
    End Sub
    'To clone billform listview in this form
    Public Sub SetListViewData(listViewItems As ListViewItemCollection)
        ListView2.Items.Clear()

        For Each item As ListViewItem In listViewItems
            ListView2.Items.Add(item.Clone())
        Next
    End Sub
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Label6.Text = "MODE: CASH"
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Label6.Text = "MODE: CARD"
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Label6.Text = "MODE: UPI"
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        Dim amountDue As Integer
        Dim cashPaid As Integer

        If Not Integer.TryParse(TextBox1.Text, amountDue) Then
            TextBox3.Text = "0" ' Reset return amount if invalid
            Exit Sub
        End If

        If Integer.TryParse(TextBox2.Text, cashPaid) Then
            If cashPaid >= amountDue Then
                Dim returnAmt As Integer = cashPaid - amountDue
                TextBox3.Text = returnAmt.ToString()
            Else
                TextBox3.Text = "0" ' Reset return amount if cash is insufficient
            End If
        Else
            TextBox3.Text = "0" ' Reset return amount if invalid
        End If
    End Sub

    Private Sub UpdateAmountInWords()
        Dim totalAmount As Decimal

        If Decimal.TryParse(TextBox1.Text, totalAmount) Then
            label8.Text = ConvertToWords(totalAmount)
            label8.Left = (Me.ClientSize.Width - label8.Width) / 2 ' Center align Label8
        Else
            label8.Text = "Invalid Amount"
        End If
    End Sub

    Private Function ConvertToWords(amount As Decimal) As String
        Dim amountInWords As String = ""
        Dim culture As New System.Globalization.CultureInfo("en-IN")

        Try
            Dim numToWords As String = NumberToWords(CInt(Math.Truncate(amount)))
            Dim rupeePart As String = If(amount > 0, $"{numToWords} Rupees", "Zero Rupees")

            Dim fractionPart As Decimal = amount - Math.Truncate(amount)
            Dim paise As Integer = CInt(fractionPart * 100)

            If paise > 0 Then
                rupeePart &= $" and {NumberToWords(paise)} Paise"
            End If

            Return rupeePart & " Only"
        Catch ex As Exception
            Return "Error Converting Amount to Words"
        End Try
    End Function

    Private Function NumberToWords(number As Integer) As String
        If number = 0 Then Return "Zero"

        Dim words As String = ""
        Dim unitsMap As String() = {"Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"}
        Dim tensMap As String() = {"Zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety"}

        If number < 20 Then
            words = unitsMap(number)
        ElseIf number < 100 Then
            words = tensMap(number \ 10)
            If (number Mod 10) > 0 Then words &= "-" & unitsMap(number Mod 10)
        ElseIf number < 1000 Then
            words = unitsMap(number \ 100) & " Hundred"
            If (number Mod 100) > 0 Then words &= " and " & NumberToWords(number Mod 100)
        ElseIf number < 100000 Then
            words = NumberToWords(number \ 1000) & " Thousand"
            If (number Mod 1000) > 0 Then words &= " and " & NumberToWords(number Mod 1000)
        ElseIf number < 10000000 Then
            words = NumberToWords(number \ 100000) & " Lakh"
            If (number Mod 100000) > 0 Then words &= " and " & NumberToWords(number Mod 100000)
        Else
            words = NumberToWords(number \ 10000000) & " Crore"
            If (number Mod 10000000) > 0 Then words &= " and " & NumberToWords(number Mod 10000000)
        End If

        Return words
    End Function


    '------> from here all data go in database -RB
    Private Async Sub InsertBill()
        Try
            If conn.State = ConnectionState.Closed Then
                connect()
            End If

            qry = "INSERT INTO bills (bill_id, userid, cust_ph, total_item, total_qty, amount, total_dis, cgst, sgst, netamount, date) " &
              "VALUES (@bill_id, @userid, @cust_ph, @total_item, @total_qty, @amount, @total_dis, @cgst, @sgst, @netamount, @date)"
            cmd = New MySqlCommand(qry, conn)

            cmd.Parameters.AddWithValue("@bill_id", billid)
            cmd.Parameters.AddWithValue("@userid", userid)
            cmd.Parameters.AddWithValue("@cust_ph", custnum)
            cmd.Parameters.AddWithValue("@total_item", totalItems)
            cmd.Parameters.AddWithValue("@total_qty", totalQuantity)
            cmd.Parameters.AddWithValue("@amount", Convert.ToDouble(Amount))
            cmd.Parameters.AddWithValue("@total_dis", Convert.ToDouble(totalDiscount))
            cmd.Parameters.AddWithValue("@cgst", Convert.ToDouble(cgst))
            cmd.Parameters.AddWithValue("@sgst", Convert.ToDouble(sgst))
            cmd.Parameters.AddWithValue("@netamount", Convert.ToDouble(totalAmount))
            cmd.Parameters.AddWithValue("@date", DateTime.Now)

            Await cmd.ExecuteNonQueryAsync()

            MessageBox.Show("Bill inserted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As MySqlException
            MessageBox.Show("MySQL Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("General Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub


    Private Sub InsertBillData(billID As Integer, productID As String, quantity As Integer, price As Double, discount As Double, gst As Double, totalAmount As Double, preGstAmount As Double)
        Try
            If conn.State = ConnectionState.Closed Then
                connect()
            End If

            qry = "INSERT INTO billdata (bill_id, pro_id, qty, price, discount, gst, total_amount, pregst_amount) " &
                  "VALUES (@BillID, @ProductID, @Quantity, @Price, @Discount, @GST, @TotalAmount, @PreGSTAmount)"
            cmd = New MySqlCommand(qry, conn)

            cmd.Parameters.AddWithValue("@BillID", billID)
            cmd.Parameters.AddWithValue("@ProductID", productID)
            cmd.Parameters.AddWithValue("@Quantity", quantity)
            cmd.Parameters.AddWithValue("@Price", price)
            cmd.Parameters.AddWithValue("@Discount", discount)
            cmd.Parameters.AddWithValue("@GST", gst)
            cmd.Parameters.AddWithValue("@TotalAmount", totalAmount)
            cmd.Parameters.AddWithValue("@PreGSTAmount", preGstAmount)

            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        InsertBill()
    End Sub
End Class
