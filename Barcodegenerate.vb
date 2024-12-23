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
    Private Sub GenerateBarcode(productId As String, productName As String, mrp As Decimal)
        Try
            ' Validate Product ID
            If String.IsNullOrWhiteSpace(productId) Then
                MessageBox.Show("Product ID is required to generate a barcode.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' Create BarcodeEncoder instance
            Dim barcodeEncoder As New BarcodeEncoder()

            ' Encode the barcode in Code 128 format
            Dim barcodeImage As Image = barcodeEncoder.Encode(BarcodeFormat.Code128, productId)

            ' Create a panel to display the barcode
            Dim barcodePanel As New Panel With {.Width = 250, .Height = 150, .Margin = New Padding(10)}
            Dim labelName As New Label With {.Text = productName, .Top = 10, .Left = 10, .Width = 200}
            Dim labelMRP As New Label With {.Text = "MRP: " & mrp.ToString("C2"), .Top = 30, .Left = 10, .Width = 200}
            Dim pictureBox As New PictureBox With {.Image = barcodeImage, .Width = 200, .Height = 50, .Top = 60, .Left = 10, .SizeMode = PictureBoxSizeMode.StretchImage}

            barcodePanel.Controls.Add(labelName)
            barcodePanel.Controls.Add(labelMRP)
            barcodePanel.Controls.Add(pictureBox)
            FlowLayoutPanelPreview.Controls.Add(barcodePanel)
        Catch ex As Exception
            MessageBox.Show("Error generating barcode: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Generate barcode for the selected product
        If DataGridViewProducts.SelectedRows.Count > 0 Then
            Dim selectedRow = DataGridViewProducts.SelectedRows(0)
            Dim productId = selectedRow.Cells("Product ID").Value.ToString()
            Dim productName = selectedRow.Cells("Product Name").Value.ToString()
            Dim mrp = Convert.ToDecimal(selectedRow.Cells("MRP").Value)

            GenerateBarcode(productId, productName, mrp)
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
            Dim qry As String = "SELECT pro_id AS 'Product ID', pro_name AS 'Product Name', pro_brand AS 'Brand', pro_mrp AS 'MRP' FROM products"
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
            Dim qry As String = "SELECT pro_id AS 'Product ID', pro_name AS 'Product Name', pro_brand AS 'Brand', pro_mrp AS 'MRP' 
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
        ' Print all barcodes on the FlowLayoutPanel
        Dim x As Integer = 50
        Dim y As Integer = 50
        Dim panelWidth As Integer = 250
        Dim panelHeight As Integer = 150

        For Each control As Control In FlowLayoutPanelPreview.Controls
            Dim bitmap As New Bitmap(control.Width, control.Height)
            control.DrawToBitmap(bitmap, New Rectangle(0, 0, control.Width, control.Height))
            e.Graphics.DrawImage(bitmap, x, y)

            x += panelWidth + 10
            If x + panelWidth > e.PageBounds.Width Then
                x = 50
                y += panelHeight + 10
            End If

            If y + panelHeight > e.PageBounds.Height Then
                e.HasMorePages = True
                Return
            End If
        Next

        e.HasMorePages = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Print barcodes
        PrintBarcodes()
    End Sub

    Private Sub FlowLayoutPanelPreview_Paint(sender As Object, e As PaintEventArgs) Handles FlowLayoutPanelPreview.Paint

    End Sub
End Class
