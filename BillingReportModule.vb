Imports MySql.Data.MySqlClient
Imports System.Drawing.Printing
Imports System.Drawing
Imports MessagingToolkit.Barcode
Imports Org.BouncyCastle.Utilities

Module BillingReportModule
    Private WithEvents PD As New PrintDocument
    Private PPD As New PrintPreviewDialog
    Private longpaper As Integer

    Private Sub PrintBillReport(billid As Integer)
        Dim billData As New List(Of BillData)()
        Dim totalAmount As Double = 0
        Dim cgst As Double = 0
        Dim sgst As Double = 0
        Dim modeOfPayment As String = String.Empty
        Dim customerName As String = String.Empty
        Dim customerPhone As String = String.Empty
        Dim cashierName As String = String.Empty
        Dim businessName As String = String.Empty
        Dim branch As String = String.Empty
        Dim gstin As String = String.Empty
        Dim city As String = String.Empty
        Dim state As String = String.Empty
        Dim bdate As String = String.Empty
        Dim mob As String = String.Empty
        Dim items As String = String.Empty
        Dim totalqty As String = String.Empty
        Try
            connect()
            'company 
            Dim companyQuery As String = "SELECT * FROM company WHERE comid = 1"
            Using cmd As New MySqlCommand(companyQuery, conn)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        businessName = reader("businessname").ToString()
                        branch = reader("branch").ToString()
                        gstin = reader("gstin").ToString()
                        city = reader("city").ToString()
                        state = reader("state").ToString()
                        mob = reader("mob").ToString()
                    End If
                End Using
            End Using
            'bills

            Dim billQuery As String = "SELECT * FROM bills WHERE bill_id = @billid"
            Using cmd As New MySqlCommand(billQuery, conn)
                cmd.Parameters.AddWithValue("@billid", billid)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        totalAmount = reader("netamount")
                        cgst = reader("cgst")
                        sgst = reader("sgst")
                        modeOfPayment = reader("mode").ToString()
                        bdate = reader("date").ToString()
                        items = reader("total_item").ToString()
                        totalqty = reader("total_qty").ToString()
                    End If
                End Using
            End Using

            Dim billDataQuery As String = "SELECT * FROM bill_data WHERE bill_id = @billid"
            Using cmd As New MySqlCommand(billDataQuery, conn)
                cmd.Parameters.AddWithValue("@billid", billid)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim total As Double = reader("pro_total")
                        Dim qty As Integer = reader("pro_qty")

                        Dim actualPrice As Double = If(qty > 0, total / qty, 0) ' Prevent division by zero

                        billData.Add(New BillData With {
                .HSNCode = reader("hsn_code"),
                .ProductName = reader("pro_name"),
                .Quantity = qty,
                .Rate = actualPrice, 'MRP
                .Amount = total
            })
                    End While
                End Using
            End Using
            'customer
            Dim customerQuery As String = "SELECT c.cust_name, c.cust_ph, u.username AS cashier_name " &
                                         "FROM bills b " &
                                         "JOIN customer c ON c.cust_ph = b.cust_ph " &
                                         "JOIN users u ON u.userid = b.userid " &
                                         "WHERE b.bill_id = @billid"
            Using cmd As New MySqlCommand(customerQuery, conn)
                cmd.Parameters.AddWithValue("@billid", billid)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        customerName = reader("cust_name").ToString()
                        cashierName = reader("cashier_name").ToString()
                    End If
                End Using
            End Using

            changelongpaper(billData.Count)

            GenerateAndPrintBill(billid, billData, totalAmount, cgst, sgst, modeOfPayment, customerName, customerPhone, cashierName, businessName, branch, gstin, city, state, bdate, mob, items, totalqty)

        Catch ex As Exception
            MessageBox.Show("Error during fetching or printing the bill: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        conn.Close()
    End Sub

    Sub changelongpaper(rowcount As Integer)
        longpaper = rowcount * 18 + 550
    End Sub

    Private Sub GenerateAndPrintBill(billid As Integer, billData As List(Of BillData), totalAmount As Double, cgst As Double, sgst As Double, modeOfPayment As String, customerName As String, customerPhone As String, cashierName As String, businessName As String, branch As String, gstin As String, city As String, state As String, bdate As String, mob As String, items As String, totalqty As String)
        Try
            ' Create the PrintDocument
            Dim printDoc As New PrintDocument()

            ' Set custom paper size and margins
            printDoc.DefaultPageSettings.PaperSize = New PaperSize("Custom", 315, longpaper) ' Width set to 315 (3.15 inches)
            printDoc.DefaultPageSettings.Margins = New Margins(10, 10, 10, 10) ' Margins for better space utilization

            ' Define the PrintPage event handler
            AddHandler printDoc.PrintPage, Sub(previewSender As Object, previewEventArgs As PrintPageEventArgs)
                                               printBillPage(previewSender, previewEventArgs, billData, billid, totalAmount, cgst, sgst, modeOfPayment, customerName, customerPhone, cashierName, businessName, branch, gstin, city, state, bdate, mob, items, totalqty)
                                           End Sub

            ' Set up the PrintPreviewDialog
            PPD.Document = printDoc
            PPD.StartPosition = FormStartPosition.CenterScreen
            PPD.WindowState = FormWindowState.Maximized

            ' Add event handler for the print preview dialog to show the print dialog
            AddHandler PPD.Shown, Sub(previewSender As Object, previewEventArgs As EventArgs)
                                      Dim previewControl As PrintPreviewControl = FindPreviewControl(PPD)
                                      If previewControl IsNot Nothing Then
                                          ' Enable zoom functionality
                                          AddHandler PPD.MouseWheel, Sub(sender, e)
                                                                         If e.Delta > 0 Then
                                                                             previewControl.Zoom += 0.1 ' Zoom In
                                                                         ElseIf e.Delta < 0 Then
                                                                             previewControl.Zoom -= 0.1 ' Zoom Out
                                                                         End If
                                                                         If previewControl.Zoom < 0.1 Then previewControl.Zoom = 0.1 ' Prevent too small zoom
                                                                     End Sub
                                      End If

                                      ' Show the print dialog once preview is shown
                                      Dim printDialog As New PrintDialog()
                                      printDialog.Document = printDoc
                                      printDialog.AllowSomePages = True
                                      printDialog.AllowPrintToFile = False
                                      printDialog.PrinterSettings.DefaultPageSettings.PaperSize = printDoc.DefaultPageSettings.PaperSize

                                      ' Open the PrintDialog
                                      If printDialog.ShowDialog() = DialogResult.OK Then
                                          ' If the user clicks OK, print the document
                                          printDoc.Print()
                                      End If
                                  End Sub

            PPD.ShowDialog()

        Catch ex As Exception
            ' Handle any errors during printing
            MessageBox.Show("Error during printing: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Function FindPreviewControl(dialog As PrintPreviewDialog) As PrintPreviewControl
        For Each control As Control In dialog.Controls
            If TypeOf control Is PrintPreviewControl Then
                Return DirectCast(control, PrintPreviewControl)
            End If
        Next
        Return Nothing
    End Function
    Private Sub printBillPage(sender As Object, e As PrintPageEventArgs, billData As List(Of BillData), billid As Integer, totalAmount As Double, cgst As Double, sgst As Double, modeOfPayment As String, customerName As String, customerPhone As String, cashierName As String, businessName As String, branch As String, gstin As String, city As String, state As String, bdate As String, mob As String, items As String, totalqty As String)
        Dim g As Graphics = e.Graphics
        Dim font As New Font("Arial", 8) ' Standard font
        Dim fonth As New Font("Arial", 7) ' Standard font
        Dim boldFonth As New Font("Times New Roman", 18, FontStyle.Bold) ' Bold font
        Dim boldFont As New Font("Arial", 10, FontStyle.Bold) ' Bold font
        Dim boldFont8 As New Font("Arial", 8, FontStyle.Bold) ' Bold font
        Dim x As Integer = 10
        Dim y As Integer = 10
        Dim lineHeight As Integer = 16 'spacing
        Dim columnWidths As Integer() = {50, 120, 30, 50, 60}


        g.DrawString("Printed on: " & DateTime.Now.ToString("dd/MM/yyyy hh:mm tt"), fonth, Brushes.Black, x + 163, y)
        y += lineHeight * 1


        Dim textSize As SizeF = g.MeasureString(businessName, boldFonth)
        Dim xCenter As Integer = (e.PageBounds.Width - textSize.Width) / 2
        g.DrawString(businessName, boldFonth, Brushes.Black, xCenter, y)
        y += lineHeight * 2

        textSize = g.MeasureString(city & ", " & state, fonth)
        xCenter = (e.PageBounds.Width - textSize.Width) / 2
        g.DrawString(city & ", " & state, fonth, Brushes.Black, xCenter, y)
        y += lineHeight

        textSize = g.MeasureString("GSTIN: " & gstin, fonth)
        xCenter = (e.PageBounds.Width - textSize.Width) / 2
        g.DrawString("GSTIN: " & gstin, fonth, Brushes.Black, xCenter, y)
        y += lineHeight

        textSize = g.MeasureString("-------------------- Phone: " & mob & " --------------------", font)
        xCenter = (e.PageBounds.Width - textSize.Width) / 2
        g.DrawString("-------------------- Phone: " & mob & " --------------------", font, Brushes.Black, xCenter, y)
        y += lineHeight * 2

        ' customer
        g.DrawString("Bill No: " & billid.ToString(), boldFont, Brushes.Black, x, y)
        y += lineHeight
        g.DrawString("Customer Name: " & customerName, font, Brushes.Black, x, y)
        y += lineHeight
        g.DrawString("Customer Phone: " & customerPhone, font, Brushes.Black, x, y)
        y += lineHeight
        g.DrawString("Cashier: " & cashierName, font, Brushes.Black, x, y)
        y += lineHeight
        g.DrawString("Bill Date: " & bdate.ToString(), font, Brushes.Black, x, y)
        y += lineHeight
        y += lineHeight * 0.5
        g.DrawString(" - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -", boldFont, Brushes.Black, x, y)
        y += lineHeight

        textSize = g.MeasureString("TAX INVOICE" & gstin, fonth)
        xCenter = (e.PageBounds.Width - textSize.Width) / 2
        g.DrawString("TAX INVOICE", boldFont, Brushes.Black, xCenter + 15, y)
        y += lineHeight

        g.DrawString(" - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -", boldFont, Brushes.Black, x, y)
        y += lineHeight

        ' Products
        g.DrawString("HSN", boldFont8, Brushes.Black, x, y)
        g.DrawString("Particulars", boldFont8, Brushes.Black, x + columnWidths(0), y)
        g.DrawString("Qty", boldFont8, Brushes.Black, x + columnWidths(0) + columnWidths(1), y)
        g.DrawString("Rate ₹", boldFont8, Brushes.Black, x + columnWidths(0) + columnWidths(1) + columnWidths(2), y)
        g.DrawString("Total ₹", boldFont8, Brushes.Black, x + columnWidths(0) + columnWidths(1) + columnWidths(2) + columnWidths(3), y)
        y += lineHeight
        g.DrawString(" - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ", boldFont, Brushes.Black, x, y)
        y += lineHeight

        ' Print Bill
        For Each item In billData
            g.DrawString(item.HSNCode.ToString(), font, Brushes.Black, x, y)

            Dim productName As String = item.ProductName
            Dim productColumnWidth As Integer = columnWidths(1)
            Dim wrappedText As String = WrapText(g, productName, font, productColumnWidth)
            Dim productHeight As Integer = CInt(g.MeasureString(wrappedText, font, productColumnWidth).Height)

            g.DrawString(wrappedText, font, Brushes.Black, x + columnWidths(0), y)

            ' Quantity
            g.DrawString(item.Quantity.ToString(), font, Brushes.Black, x + columnWidths(0) + columnWidths(1), y)

            ' Rate
            g.DrawString(item.Rate.ToString(), font, Brushes.Black, x + columnWidths(0) + columnWidths(1) + columnWidths(2), y)

            ' Total
            g.DrawString(item.Amount.ToString(), font, Brushes.Black, x + columnWidths(0) + columnWidths(1) + columnWidths(2) + columnWidths(3), y)

            y += Math.Max(lineHeight, productHeight)
        Next
        g.DrawString(" - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -", boldFont, Brushes.Black, x, y)
        y += lineHeight
        g.DrawString("      Items:  " & items & "          QTY:   " & totalqty & "            " & Math.Round(totalAmount), boldFont, Brushes.Black, x, y)
        y += lineHeight
        g.DrawString(" - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -", boldFont, Brushes.Black, x, y)
        y += lineHeight


        g.DrawString("CGST: " & cgst.ToString("C2"), font, Brushes.Black, x, y)
        y += lineHeight
        g.DrawString("SGST: " & sgst.ToString("C2"), font, Brushes.Black, x, y)
        y += lineHeight

        textSize = g.MeasureString("Net Amount: " & Math.Round(totalAmount).ToString("C2"), boldFont)
        xCenter = (e.PageBounds.Width - textSize.Width) / 2
        g.DrawString("Net Amount: " & Math.Round(totalAmount).ToString("C2"), boldFont, Brushes.Black, xCenter, y)
        y += lineHeight


        textSize = g.MeasureString("Mode of Payment: ", fonth)
        xCenter = (e.PageBounds.Width - textSize.Width) / 2
        g.DrawString("Mode of Payment: " & modeOfPayment, font, Brushes.Black, xCenter - 20, y)
        y += lineHeight


        Try
            Dim barcode As New MessagingToolkit.Barcode.BarcodeEncoder()
            Dim barcodeImage As Image = barcode.Encode(MessagingToolkit.Barcode.BarcodeFormat.Code128, billid.ToString())

            Dim resizedBarcode As New Bitmap(barcodeImage, New Size(170, 35)) ' Adjust size

            g.DrawImage(resizedBarcode, x + 65, y) ' Adjust position
            y += resizedBarcode.Height + lineHeight
        Catch ex As Exception
            MessageBox.Show("Error generating barcode: " & ex.Message)
        End Try

        textSize = g.MeasureString("Thank you for shopping with us!", fonth)
        xCenter = (e.PageBounds.Width - textSize.Width) / 2
        g.DrawString("Thank you for shopping with us!", boldFont, Brushes.Black, xCenter - 20, y)
        y += lineHeight
    End Sub

    Private Function WrapText(g As Graphics, text As String, font As Font, maxWidth As Integer) As String
        Dim words As String() = text.Split(" "c)
        Dim wrappedText As String = String.Empty
        Dim currentLine As String = String.Empty

        For Each word As String In words
            Dim testLine As String = If(currentLine = String.Empty, word, currentLine & " " & word)
            If g.MeasureString(testLine, font).Width > maxWidth Then
                wrappedText &= If(wrappedText = String.Empty, currentLine, Environment.NewLine & currentLine)
                currentLine = word
            Else
                currentLine = testLine
            End If
        Next

        wrappedText &= If(wrappedText = String.Empty, currentLine, Environment.NewLine & currentLine)
        Return wrappedText
    End Function

    Public Sub TriggerPrint(billid As Integer)
        PrintBillReport(billid)
    End Sub
End Module

Public Class BillData
    Public Property HSNCode As String
    Public Property ProductName As String
    Public Property Quantity As Integer
    Public Property Rate As Double
    Public Property Amount As Double

End Class
