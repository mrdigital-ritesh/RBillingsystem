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
        ' Set up the form on load

        Me.BackgroundImage = My.Resources.bg
        Me.BackgroundImageLayout = ImageLayout.Stretch
        Dim screenWidth As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim screenHeight As Integer = Screen.PrimaryScreen.Bounds.Height
        Me.Size = New Size(screenWidth, screenHeight)
        Me.WindowState = FormWindowState.Maximized

        ' Display user details
        Label27.Text = username
        Label26.Text = userid
        Label25.Text = "EMPLOYEE ID:"
        Label28.Text = "EMPLOYEE NAME:"
        Label24.Text = ""

        ' Enable timer for displaying time
        Timer1.Enabled = True
        Me.FormBorderStyle = FormBorderStyle.Sizable
    End Sub

    Private Sub GenerateBarcode(productId As String, productName As String, mrp As Decimal, dis As Decimal)
        Try
            ' Validate Product ID
            If String.IsNullOrWhiteSpace(productId) Then
                MessageBox.Show("Product ID is required to generate a barcode.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            If Count >= 15 Then
                MessageBox.Show("Page full. Please start a new page.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return

            End If
            ' Create BarcodeEncoder instance
            Dim barcodeEncoder As New BarcodeEncoder()

            ' Encode the barcode in Code 128 format
            Dim barcodeImage As Image = barcodeEncoder.Encode(BarcodeFormat.Code128, productId)

            ' Fetch the discount (assuming discount percentage is stored in the 'products' table)
            Dim discount As Decimal = dis

            ' Calculate the special price
            Dim specialPrice As Decimal = mrp - (mrp * discount / 100)

            ' Create a panel with a border to display the barcode
            Dim barcodePanel As New Panel With {
            .Width = 250,
            .Height = 145, ' Height to accommodate label, barcode, and "RSMART" text
            .Margin = New Padding(10),
            .BorderStyle = BorderStyle.FixedSingle,
            .BackColor = Color.White ' Optional: Set a background color for better contrast
        }

            ' Label for the product name
            Dim labelName As New Label With {
            .Text = productName,
            .Top = 8,
            .Left = (barcodePanel.Width - 200) / 2, ' Center align horizontally
            .Width = 200,
            .Font = New Font("Arial", 10, FontStyle.Bold),
            .TextAlign = ContentAlignment.MiddleCenter
        }

            ' Label for the MRP with a crossed-out text
            Dim labelMRP As New Label With {
            .Text = "MRP: " & mrp.ToString("C2"),
            .Top = 28,
            .Left = (barcodePanel.Width - 200) / 2, ' Center align horizontally
            .Width = 200,
            .Font = New Font("Arial", 8, FontStyle.Strikeout), ' Strikethrough the MRP
            .TextAlign = ContentAlignment.MiddleCenter
        }

            ' Label for the special price
            Dim labelSpecialPrice As New Label With {
            .Text = "Special Price: " & specialPrice.ToString("C2"),
            .Top = 48, ' Positioning below the MRP label
            .Left = (barcodePanel.Width - 200) / 2, ' Center align horizontally
            .Width = 200,
            .Font = New Font("Arial", 8, FontStyle.Bold), ' Bold to highlight the special price
            .TextAlign = ContentAlignment.MiddleCenter
        }

            ' Label for "RSMART"
            Dim labelRSMART As New Label With {
            .Text = "RSMART",
            .Top = 110, ' Positioning below the barcode
            .Left = (barcodePanel.Width - 150) / 2, ' Center align horizontally
            .Width = 150, ' Adjust width for better appearance
            .Font = New Font("Arial", 12, FontStyle.Bold),
            .ForeColor = Color.Black, ' Choose a color for the label, similar to brand styles like "DMart"
            .TextAlign = ContentAlignment.MiddleCenter
        }

            ' PictureBox for Barcode image
            Dim pictureBox As New PictureBox With {
            .Image = barcodeImage,
            .Width = 200,
            .Height = 55,
            .Top = 50, ' Adjusted to make the barcode more centered vertically
            .Left = (barcodePanel.Width - 200) / 2, ' Center align horizontally
            .SizeMode = PictureBoxSizeMode.StretchImage
        }

            ' Add controls to the panel
            barcodePanel.Controls.Add(labelName)
            barcodePanel.Controls.Add(labelMRP)
            barcodePanel.Controls.Add(labelSpecialPrice) ' Add the special price label
            barcodePanel.Controls.Add(labelRSMART)  ' Add the "RSMART" label
            barcodePanel.Controls.Add(pictureBox)
            count += 1
            ' Add barcode panel to the FlowLayoutPanel
            FlowLayoutPanelPreview.Controls.Add(barcodePanel)

        Catch ex As Exception
            MessageBox.Show("Error generating barcode: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Function to retrieve discount percentage from the database


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Generate barcode for the selected product
        If DataGridViewProducts.SelectedRows.Count > 0 Then
            Dim selectedRow = DataGridViewProducts.SelectedRows(0)
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
        ' Update the date and time display
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
        ' Search for products based on the text input
        SearchProducts()
    End Sub

    Private Sub PrintBarcodes()
        Try
            Dim printDoc As New PrintDocument()
            AddHandler printDoc.PrintPage, AddressOf PrintPage
            printDoc.Print()
        Catch ex As Exception
            MessageBox.Show("Error printing barcodes: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PrintPage(sender As Object, e As PrintPageEventArgs)
        ' Set initial positions for drawing barcodes on the page
        Dim x As Integer = 50 ' Start position from the left side of the page
        Dim y As Integer = 50 ' Start position from the top of the page
        Dim panelWidth As Integer = 250 ' Width of each barcode panel
        Dim panelHeight As Integer = 150 ' Height of each barcode panel
        Dim marginX As Integer = 10 ' Horizontal margin between barcodes
        Dim marginY As Integer = 10 ' Vertical margin between barcodes

        ' Loop through each barcode control in the FlowLayoutPanel
        For Each control As Control In FlowLayoutPanelPreview.Controls
            ' Create a bitmap of the control (barcode panel)
            Dim bitmap As New Bitmap(control.Width, control.Height)
            control.DrawToBitmap(bitmap, New Rectangle(0, 0, control.Width, control.Height))

            ' Draw the barcode image on the page at the specified x, y position
            e.Graphics.DrawImage(bitmap, x, y)

            ' Adjust the x position for the next barcode (with horizontal margin)
            x += panelWidth + marginX

            ' If the next barcode would exceed the page width, move to the next line (vertical margin)
            If x + panelWidth > e.PageBounds.Width Then
                x = 50 ' Reset to start from the left side of the page
                y += panelHeight + marginY ' Move down to the next line
            End If

            ' If there is not enough space to print on the current page, start a new page
            If y + panelHeight > e.PageBounds.Height Then
                e.HasMorePages = True
                Return
            End If
        Next

        ' If all barcodes are printed, no more pages are needed
        e.HasMorePages = False
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Print barcodes
        PrintBarcodes()
    End Sub

    Private Sub FlowLayoutPanelPreview_Paint(sender As Object, e As PaintEventArgs) Handles FlowLayoutPanelPreview.Paint

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        FlowLayoutPanelPreview.Controls.Clear()
        count = 0
    End Sub
End Class
