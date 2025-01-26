Imports MySql.Data.MySqlClient
Imports System.Drawing
Imports MessagingToolkit.Barcode
Imports System.Drawing.Printing


Public Class Barcodegenerate
    Protected Overrides ReadOnly Property CreateParams As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or &H2000000 ' WS_EX_COMPOSITED
            Return cp
        End Get
    End Property
    Dim count As Integer = 0
    Private Sub Barcodegenerate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Setform(Me)

        SearchProducts()
        Me.KeyPreview = True
        AdminDashboard.Close()
        ManagerDashboard.Close()
        EmployeeDashboard.Close()
        Me.BackgroundImage = My.Resources.bg
        Me.BackgroundImageLayout = ImageLayout.Stretch
        Dim screenWidth As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim screenHeight As Integer = Screen.PrimaryScreen.Bounds.Height
        Me.Size = New Size(screenWidth, screenHeight)
        Me.WindowState = FormWindowState.Maximized

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
        Me.FormBorderStyle = FormBorderStyle.Sizable
    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                Button3.PerformClick()
            Case Keys.F1
                Button1.PerformClick()
            Case Keys.F5
                Button2.PerformClick()
            Case Else
        End Select
    End Sub

    Private Sub GenerateBarcode(productId As String, productName As String, mrp As Decimal, dis As Decimal)
        Try
            If String.IsNullOrWhiteSpace(productId) Then
                MessageBox.Show("Product ID is required to generate a barcode.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            If Count >= 15 Then
                MessageBox.Show("Page full. Please start a new page.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return

            End If
            Dim barcodeEncoder As New BarcodeEncoder()

            Dim barcodeImage As Image = barcodeEncoder.Encode(BarcodeFormat.Code128, productId)

            Dim discount As Decimal = dis

            Dim specialPrice As Decimal = mrp - (mrp * discount / 100)

            Dim barcodePanel As New Panel With {
            .Width = 250,
            .Height = 146,
            .Margin = New Padding(7),
            .BorderStyle = BorderStyle.FixedSingle,
            .BackColor = Color.White
        }

            Dim labelName As New Label With {
            .Text = productName,
            .Top = 7,
            .Left = (barcodePanel.Width - 200) / 2,
            .Width = 200,
            .Font = New Font("Arial", 10, FontStyle.Bold),
            .TextAlign = ContentAlignment.MiddleCenter
        }

            Dim labelMRP As New Label With {
            .Text = "MRP: " & mrp.ToString("C2"),
            .Top = 25,
            .Left = (barcodePanel.Width - 200) / 2,
            .Width = 200,
            .Font = New Font("Arial", 8, FontStyle.Strikeout),
            .TextAlign = ContentAlignment.MiddleCenter
        }

            Dim labelSpecialPrice As New Label With {
            .Text = "Special Price: " & specialPrice.ToString("C2"),
            .Top = 40,
            .Left = (barcodePanel.Width - 200) / 2,
            .Width = 200,
            .Font = New Font("Arial", 8, FontStyle.Bold),
            .TextAlign = ContentAlignment.MiddleCenter
        }

            Dim labelRSMART As New Label With {
            .Text = "RSMART",
            .Top = 113,
            .Left = (barcodePanel.Width - 150) / 2,
            .Width = 150,
            .Font = New Font("Arial", 12, FontStyle.Bold),
            .ForeColor = Color.Black,
            .TextAlign = ContentAlignment.MiddleCenter
        }

            Dim pictureBox As New PictureBox With {
            .Image = barcodeImage,
            .Width = 205,
            .Height = 57,
            .Top = 57,
            .Left = (barcodePanel.Width - 200) / 2,
            .SizeMode = PictureBoxSizeMode.StretchImage
        }

            barcodePanel.Controls.Add(labelName)
            barcodePanel.Controls.Add(labelMRP)
            barcodePanel.Controls.Add(labelSpecialPrice)
            barcodePanel.Controls.Add(labelRSMART)
            barcodePanel.Controls.Add(pictureBox)
            count += 1
            FlowLayoutPanelPreview.Controls.Add(barcodePanel)

        Catch ex As Exception
            MessageBox.Show("Error generating barcode: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If DataGridViewProducts.SelectedRows.Count > 0 Then

            Dim selectedRow = DataGridViewProducts.SelectedRows(0)
            If selectedRow.Cells("Product ID").Value Is Nothing OrElse String.IsNullOrWhiteSpace(selectedRow.Cells("Product ID").Value.ToString()) Then
                MessageBox.Show("Product ID is missing or invalid.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            If selectedRow.Cells("Product Name").Value Is Nothing OrElse String.IsNullOrWhiteSpace(selectedRow.Cells("Product Name").Value.ToString()) Then
                MessageBox.Show("Product Name is missing or invalid.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            If selectedRow.Cells("MRP").Value Is Nothing OrElse Not IsNumeric(selectedRow.Cells("MRP").Value) Then
                MessageBox.Show("MRP is missing or invalid.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            If selectedRow.Cells("Dis").Value Is Nothing OrElse Not IsNumeric(selectedRow.Cells("Dis").Value) Then
                MessageBox.Show("Discount is missing or invalid.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If


            Dim productId = selectedRow.Cells("Product ID").Value.ToString()
            Dim productName = selectedRow.Cells("Product Name").Value.ToString()
            Dim mrp = Convert.ToDecimal(selectedRow.Cells("MRP").Value)
            Dim disc = Convert.ToDecimal(selectedRow.Cells("Dis").Value)

            GenerateBarcode(productId, productName, mrp, disc)
        Else
            MessageBox.Show("Please select a product to generate the barcode.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label24.Text = DateTime.Now.ToString("dddd")
        Label24.Text += "   " & DateTime.Now.ToString("dd MMMM yyyy") & "   " & TimeOfDay.ToString("HH:mm:ss")
    End Sub

    Private Sub LoadProducts()
        Try
            Call connect()
            Dim qry As String = "SELECT pro_id AS 'Product ID', pro_name AS 'Product Name', pro_brand AS 'Brand',pro_disc As 'Dis', pro_mrp AS 'MRP' FROM products"
            Dim da As New MySqlDataAdapter(qry, conn)
            Dim dt As New DataTable()
            da.Fill(dt)
            DataGridViewProducts.DataSource = dt
            conn.Close()
        Catch ex As Exception
            MessageBox.Show("Error loading products: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SearchProducts()
        Try
            Dim searchText As String = TextBox1.Text.Trim()
            Call connect()
            Dim qry As String = "SELECT pro_id AS 'Product ID', pro_name AS 'Product Name', pro_brand AS 'Brand',pro_disc As 'Dis', pro_mrp AS 'MRP' 
                                 FROM products 
                                 WHERE pro_name LIKE '%" & searchText & "%' 
                                    OR pro_brand LIKE '%" & searchText & "%' 
                                    OR pro_id LIKE '%" & searchText & "%'"
            Dim da As New MySqlDataAdapter(qry, conn)
            Dim dt As New DataTable()
            da.Fill(dt)
            DataGridViewProducts.DataSource = dt
            conn.Close()
        Catch ex As Exception
            MessageBox.Show("Error searching products: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ButtonSearch_Click(sender As Object, e As EventArgs) Handles ButtonSearch.Click
        SearchProducts()
    End Sub

    Private Sub PrintBarcodes()
        Try
            Dim printDoc As New PrintDocument()
            AddHandler printDoc.PrintPage, AddressOf PrintPage

            Dim previewDialog As New PrintPreviewDialog With {
            .Document = printDoc,
            .Width = 800,
            .Height = 600
        }
            If previewDialog.ShowDialog() = DialogResult.OK Then
                printDoc.Print()
            End If
        Catch ex As Exception
            MessageBox.Show("Error printing barcodes: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub PrintPage(sender As Object, e As PrintPageEventArgs)
        Dim x As Integer = 50
        Dim y As Integer = 50
        Dim panelWidth As Integer = 250
        Dim panelHeight As Integer = 150
        Dim marginX As Integer = 10
        Dim marginY As Integer = 10

        For Each control As Control In FlowLayoutPanelPreview.Controls
            Dim bitmap As New Bitmap(control.Width, control.Height)
            control.DrawToBitmap(bitmap, New Rectangle(0, 0, control.Width, control.Height))

            e.Graphics.DrawImage(bitmap, x, y)

            x += panelWidth + marginX

            If x + panelWidth > e.PageBounds.Width Then
                x = 50
                y += panelHeight + marginY
            End If
            If y + panelHeight > e.PageBounds.Height Then
                e.HasMorePages = True
                Return
            End If
        Next

        e.HasMorePages = False
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        PrintBarcodes()
    End Sub

    Private Sub FlowLayoutPanelPreview_Paint(sender As Object, e As PaintEventArgs) Handles FlowLayoutPanelPreview.Paint

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        FlowLayoutPanelPreview.Controls.Clear()
        count = 0
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
