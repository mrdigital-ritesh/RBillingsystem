Imports MySql.Data.MySqlClient
Imports System.Diagnostics.Eventing
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class loginform

    Dim qry As String
    Dim cmd As MySqlCommand
    Dim Reader As MySqlDataReader

    Protected Overrides ReadOnly Property CreateParams As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or &H2000000 ' WS_EX_COMPOSITED
            Return cp
        End Get
    End Property

    Private Sub loginform_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        start.Close()
        Setform(Me)
        AdminDashboard.Close()
        ManagerDashboard.Close()
        EmployeeDashboard.Close()
        TextBox1.Focus()

        Label3.Text = "OR"
        If user = "admin" Then
            loginlabel.Text = "ADMIN LOGIN"
        ElseIf user = "manager" Then
            loginlabel.Text = "MANAGER LOGIN"
        ElseIf user = "emp" Then
            loginlabel.Text = "EMPLOYEE LOGIN"
        End If

        Panel2.Visible = False
        Me.BackgroundImage = My.Resources.bg
        Me.BackgroundImageLayout = ImageLayout.Stretch
        loginlabel.Left = (Me.ClientSize.Width - loginlabel.Width) / 2

        Label3.Left = (Panel1.ClientSize.Width - Label3.Width) / 2
        Label4.Left = (Panel2.ClientSize.Width - Label4.Width) / 2

    End Sub

    Private Sub closebt_Click(sender As Object, e As EventArgs) Handles closebt.Click
        Close()
        Me.Close()

    End Sub

    Private Sub backbt_Click(sender As Object, e As EventArgs) Handles backbt.Click
        Hide()
        start.Show()
        Close()
    End Sub

    Private Sub Loginbtn_Click(sender As Object, e As EventArgs) Handles Loginbtn.Click
        If String.IsNullOrWhiteSpace(TextBox1.Text) OrElse String.IsNullOrWhiteSpace(TextBox2.Text) Then
            MessageBox.Show("Please enter both User ID and Password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Try
            connect()
            qry = "SELECT * FROM users WHERE userid = @userid AND pwd = @password AND usertype = @usertype"
            cmd = New MySqlCommand(qry, conn)

            cmd.Parameters.AddWithValue("@userid", TextBox1.Text)
            cmd.Parameters.AddWithValue("@password", TextBox2.Text)
            cmd.Parameters.AddWithValue("@usertype", user)
            Reader = cmd.ExecuteReader
            If Reader.HasRows Then
                If Reader.Read Then
                    MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Hide()
                    userid = Reader("userid").ToString
                    username = Reader("username").ToString

                    If user = "admin" Then
                        AdminDashboard.Show()
                    ElseIf user = "manager" Then
                        ManagerDashboard.Show()
                    ElseIf user = "emp" Then
                        EmployeeDashboard.Show()
                    End If

                End If
            Else
                TextBox1.Clear()
                TextBox2.Clear()
                MessageBox.Show("Invalid User ID or Password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Reader.Close()
            conn.Close()


        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            conn.Close()
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Panel2.Visible = True
        Panel1.Visible = False
        TextBox3.Focus()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Panel2.Visible = False
        Panel1.Visible = True
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        If Len(TextBox3.Text) = 10 Then
            Try
                connect()
                qry = "SELECT * FROM users WHERE rfid = @rfid AND usertype = @usertype"
                cmd = New MySqlCommand(qry, conn)

                cmd.Parameters.AddWithValue("@rfid", TextBox3.Text)
                cmd.Parameters.AddWithValue("@usertype", user)

                Reader = cmd.ExecuteReader
                If Reader.HasRows Then
                    If Reader.Read Then
                        MsgBox("Login successful!")

                        MessageBox.Show(Me, "Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        userid = Reader("userid").ToString
                        username = Reader("username").ToString
                        Hide()

                        If user = "admin" Then
                            AdminDashboard.Show()
                        ElseIf user = "manager" Then
                            ManagerDashboard.Show()
                        ElseIf user = "emp" Then
                            EmployeeDashboard.Show()
                        End If

                    End If
                Else
                    TextBox3.Clear()

                    MsgBox("Invalid RFID Card...")
                    MessageBox.Show(Me, "Invalid RFID Card...", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                Reader.Close()
                conn.Close()


            Catch ex As Exception
                MsgBox("ERROR")
                MessageBox.Show("Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                conn.Close()
            End Try

        End If
    End Sub
End Class