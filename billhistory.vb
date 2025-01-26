Imports MySql.Data.MySqlClient

Public Class billhistory
    Private Sub billhistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim screenWidth As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim screenHeight As Integer = Screen.PrimaryScreen.Bounds.Height
        Me.Size = New Size(screenWidth, screenHeight)
        Me.WindowState = FormWindowState.Maximized
        Setform(Me)
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

        AdminDashboard.Close()
        ManagerDashboard.Close()
        EmployeeDashboard.Close()
        autoload()
        AddPrintButtonToDataGridView()
        ComboBox1.Items.Add("ALL")
        ComboBox1.Items.Add("CASH")
        ComboBox1.Items.Add("CARD")
        ComboBox1.Items.Add("UPI")
        ComboBox1.SelectedIndex = 0
        DateTimePicker1.Value = DateTime.Now.AddMonths(-1)
        DateTimePicker2.Value = DateTime.Now

        DataGridView1.AutoGenerateColumns = True
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label24.Text = DateTime.Now.ToString("dddd")
        Label24.Text += "   " & DateTime.Now.ToString("dd MMMM yyyy") & "   " & TimeOfDay.ToString("HH:mm:ss")
    End Sub
    Sub autoload()
        conn.Close()

        Dim fromDate As String = DateTime.Now.AddHours(-24).ToString("yyyy-MM-dd HH:mm:ss")
        Dim toDate As String = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")

        Dim paymentMode As String = If(ComboBox1.SelectedItem IsNot Nothing, ComboBox1.SelectedItem.ToString(), "ALL")

        Try
            connect()
            Dim query As String = "SELECT b.bill_id, b.userid, u.username AS cashier_name, c.cust_name AS CustomerName, b.cust_ph AS Custom_Phno, " &
                  "b.total_item, b.total_qty, FORMAT(b.amount, 2) AS amount, FORMAT(b.total_dis, 2) AS total_dis, FORMAT(b.cgst, 2) AS cgst, " &
                  "FORMAT(b.sgst, 2) AS sgst, FORMAT(b.netamount, 2) AS netamount, b.date, b.mode " &
                  "FROM bills b " &
                  "LEFT JOIN users u ON b.userid = u.userid " &
                  "LEFT JOIN customer c ON b.cust_ph = c.cust_ph " &
                  "WHERE b.date BETWEEN @FromDate AND @ToDate " &
                  "ORDER BY b.date DESC"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@FromDate", fromDate)
                cmd.Parameters.AddWithValue("@ToDate", toDate)

                If paymentMode <> "ALL" Then
                    cmd.Parameters.AddWithValue("@PaymentMode", paymentMode)
                End If

                Dim adapter As New MySqlDataAdapter(cmd)
                Dim dt As New DataTable()
                adapter.Fill(dt)

                For Each row As DataRow In dt.Rows
                    For Each column As DataColumn In dt.Columns
                        If row(column) Is DBNull.Value Then
                            If column.DataType Is GetType(String) Then
                                row(column) = String.Empty
                            ElseIf column.DataType Is GetType(Decimal) Or column.DataType Is GetType(Double) Then
                                row(column) = 0
                            End If
                        End If
                    Next
                Next

                DataGridView1.DataSource = dt
            End Using
            conn.Close()
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim fromDate As String = DateTimePicker1.Value.ToString("yyyy-MM-dd")
        Dim toDate As String = DateTimePicker2.Value.ToString("yyyy-MM-dd")
        Dim paymentMode As String = ComboBox1.SelectedItem.ToString()

        Try
            connect()
            Dim query As String = "SELECT b.bill_id, b.userid, u.username AS cashier_name, c.cust_name AS CustomerName, b.cust_ph AS Custom_Phno, " &
                  "b.total_item, b.total_qty, FORMAT(b.amount, 2) AS amount, FORMAT(b.total_dis, 2) AS total_dis, FORMAT(b.cgst, 2) AS cgst, " &
                  "FORMAT(b.sgst, 2) AS sgst, FORMAT(b.netamount, 2) AS netamount, b.date, b.mode " &
                  "FROM bills b " &
                  "LEFT JOIN users u ON b.userid = u.userid " &
                  "LEFT JOIN customer c ON b.cust_ph = c.cust_ph " &
                  "WHERE b.date BETWEEN @FromDate AND @ToDate"

            If paymentMode <> "ALL" Then
                query &= " AND b.mode = @PaymentMode"
            End If

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@FromDate", fromDate)
                cmd.Parameters.AddWithValue("@ToDate", toDate)

                If paymentMode <> "ALL" Then
                    cmd.Parameters.AddWithValue("@PaymentMode", paymentMode)
                End If

                Dim adapter As New MySqlDataAdapter(cmd)
                Dim dt As New DataTable()
                adapter.Fill(dt)

                For Each row As DataRow In dt.Rows
                    For Each column As DataColumn In dt.Columns
                        If row(column) Is DBNull.Value Then
                            If column.DataType Is GetType(String) Then
                                row(column) = String.Empty
                            ElseIf column.DataType Is GetType(Decimal) Or column.DataType Is GetType(Double) Then
                                row(column) = 0
                            End If
                        End If
                    Next
                Next

                DataGridView1.DataSource = dt
            End Using
            conn.Close()
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtMobileNumber_TextChanged(sender As Object, e As EventArgs) Handles txtMobileNumber.TextChanged
        If Not String.IsNullOrEmpty(txtMobileNumber.Text) Then
            txtCustomerName.Clear()
        End If
    End Sub

    Private Sub txtCustomerName_TextChanged(sender As Object, e As EventArgs) Handles txtCustomerName.TextChanged
        If Not String.IsNullOrEmpty(txtCustomerName.Text) Then
            txtMobileNumber.Clear()
        End If
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim mobileNumber As String = txtMobileNumber.Text.Trim()
        Dim customerName As String = txtCustomerName.Text.Trim()

        If String.IsNullOrEmpty(mobileNumber) AndAlso String.IsNullOrEmpty(customerName) Then
            MessageBox.Show("Please enter either a mobile number or a customer name.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            connect()
            Dim query As String = "SELECT b.bill_id, b.userid, u.username AS cashier_name, c.cust_name AS CustomerName, b.cust_ph AS Custom_Phno, " &
                                  "b.total_item, b.total_qty, FORMAT(b.amount, 2) AS amount, FORMAT(b.total_dis, 2) AS total_dis, " &
                                  "FORMAT(b.cgst, 2) AS cgst, FORMAT(b.sgst, 2) AS sgst, FORMAT(b.netamount, 2) AS netamount, b.date, b.mode " &
                                  "FROM bills b " &
                                  "LEFT JOIN users u ON b.userid = u.userid " &
                                  "LEFT JOIN customer c ON b.cust_ph = c.cust_ph " &
                                  "WHERE "

            If Not String.IsNullOrEmpty(mobileNumber) Then
                query &= "b.cust_ph = @MobileNumber"
            Else
                query &= "c.cust_name LIKE @CustomerName"
            End If

            Using cmd As New MySqlCommand(query, conn)
                If Not String.IsNullOrEmpty(mobileNumber) Then
                    cmd.Parameters.AddWithValue("@MobileNumber", mobileNumber)
                Else
                    cmd.Parameters.AddWithValue("@CustomerName", "%" & customerName & "%")
                End If

                Dim adapter As New MySqlDataAdapter(cmd)
                Dim dt As New DataTable()
                adapter.Fill(dt)

                DataGridView1.DataSource = dt
            End Using
            conn.Close()

        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        autoload()

        ComboBox1.SelectedIndex = 0

        DateTimePicker1.Value = DateTime.Now.AddMonths(-1)
        DateTimePicker2.Value = DateTime.Now
    End Sub

    Private Sub AddPrintButtonToDataGridView()
        If Not DataGridView1.Columns.Contains("PrintButtonColumn") Then
            Dim printButtonColumn As New DataGridViewButtonColumn()
            printButtonColumn.Name = "PrintButtonColumn"
            printButtonColumn.HeaderText = "PRINT BILL"
            printButtonColumn.Text = "Print"
            printButtonColumn.UseColumnTextForButtonValue = True
            printButtonColumn.DefaultCellStyle.BackColor = Color.White
            printButtonColumn.FlatStyle = FlatStyle.Flat
            printButtonColumn.DefaultCellStyle.ForeColor = Color.Red
            printButtonColumn.DefaultCellStyle.Font = New Font("Arial", 9.0F, FontStyle.Bold)
            'printButtonColumn.DefaultCellStyle.Padding = New Padding(5,1,5,1)   

            DataGridView1.Columns.Add(printButtonColumn)
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.ColumnIndex = DataGridView1.Columns("PrintButtonColumn").Index AndAlso e.RowIndex >= 0 Then
            Dim billId As String = DataGridView1.Rows(e.RowIndex).Cells("bill_id").Value.ToString()
            BillingReportModule.TriggerPrint(billId)

        End If
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