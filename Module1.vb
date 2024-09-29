Imports MySql.Data.MySqlClient
Module Module1
    Public conn As New MySqlConnection
    Public Sub connect()
        conn.ConnectionString = "server=localhost;user id=root;password=;database=vbbilling"
        conn.Open()
        If conn.State <> ConnectionState.Open Then
            MsgBox("Not Connected")
            'Else
            'MsgBox("Connection Established")
        End If
    End Sub
End Module
