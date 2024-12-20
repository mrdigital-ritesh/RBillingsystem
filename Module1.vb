Imports MySql.Data.MySqlClient
Module Module1
    Public user As String = ""
    Public userid As String = ""
    Public username As String = ""
    Public totalItems As Integer
    Public totalQuantity As Integer
    Public billid As Integer
    Public Amount As Double = 0.0
    Public totalDiscount As Double = 0.0
    Public cgst As Double = 0.0
    Public sgst As Double = 0.0
    Public totalAmount As Double = 0.0
    Public preGst As Double = 0.0

    Public custnum As String
    Public custname As String
    Public custmail As String
    Public custdob As String

    Public conn As New MySqlConnection
    Public Sub connect()
        conn.ConnectionString = "server=localhost;user id=root;password=Ritesh@123;database=vbbilling"
        conn.Open()
        If conn.State <> ConnectionState.Open Then
            MsgBox("Not Connected")
            'Else
            'MsgBox("Connection Established")
        End If
    End Sub
End Module
