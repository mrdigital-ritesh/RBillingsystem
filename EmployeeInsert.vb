Imports System.IO
Imports MySql.Data.MySqlClient

Public Class EmployeeInsert
    Dim qry As String
    Private imageChanged As Boolean = False

    Private Sub Employee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim screenWidth As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim screenHeight As Integer = Screen.PrimaryScreen.Bounds.Height
        Me.Size = New Size(screenWidth, screenHeight)
        Me.WindowState = FormWindowState.Maximized
        AdminDashboard.Close()
        ManagerDashboard.Close()
        EmployeeDashboard.Close()
        PictureBox1.Image = My.Resources.defaultphoto
        showdata()
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage ' Make the image stretch to fit the PictureBox
    End Sub

    Private Sub ButtonBrowse_Click(sender As Object, e As EventArgs) Handles ButtonBrowse.Click
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            PictureBox1.Image = Image.FromFile(openFileDialog.FileName)
            imageChanged = True
        End If
    End Sub

    Public Sub showdata()
        Call connect()
        TextBox1.Enabled = True

        qry = "select userid as EmpID,username as EmpName,pwd as password,phone,email,aadhar as Aadharno,dob,doj from users where usertype = 'Emp'"
        Dim da As New MySqlDataAdapter(qry, conn)
        Dim dt As New DataTable()

        da.Fill(dt)

        DataGridView1.DataSource = dt
        DataGridView1.Refresh()
        conn.Close()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If ValidateFields() Then
            Try
                connect()

                ' Check if the username already exists
                Dim useridExists As String = "SELECT COUNT(*) FROM users WHERE userid = @userid"
                Dim checkCmd As New MySqlCommand(useridExists, conn)
                checkCmd.Parameters.AddWithValue("@userid", TextBox1.Text)

                Dim usernameCount As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())

                If usernameCount > 0 Then
                    ' If the username already exists, show a message
                    MessageBox.Show("The userid is already in use. Please choose a different userid.", "UserID Conflict", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    conn.Close()
                    Return
                End If

                Dim photoBytes() As Byte = Nothing
                If PictureBox1.Image IsNot Nothing Then
                    Using ms As New MemoryStream()
                        PictureBox1.Image.Save(ms, PictureBox1.Image.RawFormat)
                        photoBytes = ms.ToArray()
                    End Using
                End If

                ' Insert the new employee data into the database
                qry = "INSERT INTO users (userid, username, pwd, usertype, phone, email, aadhar, dob, doj, photo) " &
                  "VALUES (@userid, @username, @pwd, @usertype, @phone, @email, @aadhar, @dob, @doj, @photo)"

                Dim cmd As New MySqlCommand(qry, conn)
                cmd.Parameters.AddWithValue("@userid", TextBox1.Text)
                cmd.Parameters.AddWithValue("@username", TextBox2.Text)
                cmd.Parameters.AddWithValue("@pwd", TextBox6.Text)
                cmd.Parameters.AddWithValue("@usertype", "Emp")
                cmd.Parameters.AddWithValue("@phone", TextBox3.Text)
                cmd.Parameters.AddWithValue("@email", TextBox4.Text)
                cmd.Parameters.AddWithValue("@aadhar", TextBox5.Text)
                cmd.Parameters.AddWithValue("@dob", DateTimePicker1.Value.ToString("yyyy-MM-dd"))
                cmd.Parameters.AddWithValue("@doj", DateTimePicker2.Value.ToString("yyyy-MM-dd"))
                cmd.Parameters.AddWithValue("@photo", photoBytes)

                cmd.ExecuteNonQuery()

                conn.Close()
                MessageBox.Show("Employee data successfully inserted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ClearFields()

            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If conn.State = ConnectionState.Open Then conn.Close()
            End Try
        End If
        showdata()
    End Sub


    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            TextBox1.Enabled = False

            Dim selectedRow As DataGridViewRow = DataGridView1.Rows(e.RowIndex)

            If selectedRow.Cells("EmpID").Value IsNot DBNull.Value Then
                TextBox1.Text = selectedRow.Cells("EmpID").Value.ToString() ' Employee ID
            End If

            If selectedRow.Cells("EmpName").Value IsNot DBNull.Value Then
                TextBox2.Text = selectedRow.Cells("EmpName").Value.ToString() ' Employee Name
            End If

            If selectedRow.Cells("phone").Value IsNot DBNull.Value Then
                TextBox3.Text = selectedRow.Cells("phone").Value.ToString() ' Phone
            End If

            If selectedRow.Cells("email").Value IsNot DBNull.Value Then
                TextBox4.Text = selectedRow.Cells("email").Value.ToString() ' Email
            End If

            If selectedRow.Cells("Aadharno").Value IsNot DBNull.Value Then
                TextBox5.Text = selectedRow.Cells("Aadharno").Value.ToString() ' Aadhar
            End If

            If selectedRow.Cells("dob").Value IsNot DBNull.Value Then
                DateTimePicker1.Value = Convert.ToDateTime(selectedRow.Cells("dob").Value) ' DOB
            End If

            If selectedRow.Cells("doj").Value IsNot DBNull.Value Then
                DateTimePicker2.Value = Convert.ToDateTime(selectedRow.Cells("doj").Value) ' DOJ
            End If

            If selectedRow.Cells("password").Value IsNot DBNull.Value Then
                TextBox6.Text = selectedRow.Cells("password").Value.ToString() ' Password
            End If

            imageChanged = False

            ' Check if the EmpID (or any identifier) exists before fetching the image
            Dim empId As String = selectedRow.Cells("EmpID").Value.ToString()
            If Not String.IsNullOrEmpty(empId) Then
                FetchImageAndDisplay(empId)
            End If
        End If
    End Sub


    Private Sub FetchImageAndDisplay(empId As String)
        Try
            Dim qry As String = "SELECT photo FROM users WHERE userid = @empId"
            Dim cmd As New MySqlCommand(qry, conn)
            cmd.Parameters.AddWithValue("@empId", empId)

            conn.Open()

            Dim photo As Object = cmd.ExecuteScalar()

            conn.Close()

            If photo IsNot DBNull.Value Then
                Dim photoBytes As Byte() = CType(photo, Byte())
                Using ms As New MemoryStream(photoBytes)
                    ' Dispose of the previous image if it exists
                    If PictureBox1.Image IsNot Nothing Then
                        PictureBox1.Image.Dispose()
                    End If

                    ' Load the image from the stream and clone it
                    Dim tempImage As Image = Image.FromStream(ms)
                    PictureBox1.Image = CType(tempImage.Clone(), Image) ' Clone the image to avoid stream issues
                    PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage

                    ' Dispose of the temporary image after cloning
                    tempImage.Dispose()
                End Using
            Else
                ' Handle the case where there is no image in the database
                If PictureBox1.Image IsNot Nothing Then
                    PictureBox1.Image.Dispose()
                End If
                PictureBox1.Image = My.Resources.defaultphoto
            End If
        Catch ex As Exception
            MessageBox.Show("Error fetching photo: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub ClearFields()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()

        PictureBox1.Image = My.Resources.defaultphoto
        DateTimePicker1.Value = DateTime.Now
    End Sub

    Private Function ValidateFields() As Boolean
        If TextBox1.Text.Trim() = "" Then
            MsgBox("Please enter Employee ID.")
            TextBox1.Focus()
            Return False
        End If

        If TextBox2.Text.Trim() = "" Then
            MsgBox("Please enter Employee Name.")
            TextBox2.Focus()
            Return False
        End If

        If TextBox3.Text.Trim() = "" Then
            MsgBox("Please enter Employee Phone No.")
            TextBox3.Focus()
            Return False
        End If

        If TextBox4.Text.Trim() = "" Then
            MsgBox("Please enter Employee Email.")
            TextBox4.Focus()
            Return False
        End If

        If TextBox5.Text.Trim() = "" Then
            MsgBox("Please enter Employee Aadhar No.")
            TextBox5.Focus()
            Return False
        End If

        If TextBox6.Text.Trim() = "" Then
            MsgBox("Please enter Password.")
            TextBox6.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            Dim selectedRow As DataGridViewRow = DataGridView1.SelectedRows(0)

            If selectedRow.Cells("EmpID").Value IsNot DBNull.Value AndAlso Not String.IsNullOrEmpty(selectedRow.Cells("EmpID").Value.ToString()) Then
                Dim empId As String = selectedRow.Cells("EmpID").Value.ToString()

                Dim confirmDelete As DialogResult = MessageBox.Show("Are you sure you want to delete this employee?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If confirmDelete = DialogResult.Yes Then
                    Try
                        connect()

                        Dim qry As String = "DELETE FROM users WHERE userid = @empId"
                        Dim cmd As New MySqlCommand(qry, conn)
                        cmd.Parameters.AddWithValue("@empId", empId)

                        cmd.ExecuteNonQuery()

                        conn.Close()
                        MessageBox.Show("Employee deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        ' Refresh the DataGridView
                        showdata()
                    Catch ex As Exception
                        MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        If conn.State = ConnectionState.Open Then conn.Close()
                    End Try
                End If
            Else
                MessageBox.Show("Selected row does not have a valid Employee ID.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("Please select an employee to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox1.Text.Trim() = "" Then
            MessageBox.Show("Please select an employee from the list to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Check if the userid is already in use by someone else 
        If ValidateFields() Then

            Try
                connect()

                Dim photoBytes() As Byte = Nothing
                Dim updatePhoto As Boolean = False

                ' Only prepare the photo if the image has changed
                If imageChanged AndAlso PictureBox1.Image IsNot Nothing AndAlso PictureBox1.Image IsNot My.Resources.defaultphoto Then
                    updatePhoto = True
                    Using clonedImage As Image = CType(PictureBox1.Image.Clone(), Image)
                        Using ms As New MemoryStream()
                            clonedImage.Save(ms, clonedImage.RawFormat)
                            photoBytes = ms.ToArray()
                        End Using
                    End Using
                End If

                Dim qry As String = "UPDATE users SET username = @username, pwd = @pwd, phone = @phone, email = @email, aadhar = @aadhar, dob = @dob, doj = @doj"

                If updatePhoto Then
                    qry &= ", photo = @photo"
                End If
                qry &= " WHERE userid = @userid"

                Dim cmd As New MySqlCommand(qry, conn)
                cmd.Parameters.AddWithValue("@userid", TextBox1.Text)
                cmd.Parameters.AddWithValue("@username", TextBox2.Text)
                cmd.Parameters.AddWithValue("@pwd", TextBox6.Text)
                cmd.Parameters.AddWithValue("@phone", TextBox3.Text)
                cmd.Parameters.AddWithValue("@email", TextBox4.Text)
                cmd.Parameters.AddWithValue("@aadhar", TextBox5.Text)
                cmd.Parameters.AddWithValue("@dob", DateTimePicker1.Value.ToString("yyyy-MM-dd"))
                cmd.Parameters.AddWithValue("@doj", DateTimePicker2.Value.ToString("yyyy-MM-dd"))

                If updatePhoto Then
                    cmd.Parameters.AddWithValue("@photo", photoBytes)
                End If

                cmd.ExecuteNonQuery()

                conn.Close()
                MessageBox.Show("Employee data updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                imageChanged = False


            Catch ex As Exception
                MessageBox.Show("Error updating employee data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If conn.State = ConnectionState.Open Then conn.Close()
            End Try
            ClearFields()
        End If
        showdata()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ClearFields()
        showdata()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox7.Text = "" AndAlso TextBox8.Text = "" Then
            MsgBox("PLEASE ENTER EMPLOYEE ID OR NAME TO FIND")
        Else
            Dim qry As String = "SELECT userid as EmpID, username as EmpName, pwd as password, phone, email, aadhar as Aadharno, dob, doj " &
                                "FROM users WHERE usertype = 'Emp'"

            If TextBox7.Text <> "" Then
                qry &= " AND userid = '" & TextBox7.Text & "'"
            End If

            If TextBox8.Text <> "" Then
                qry &= " AND username ='" & TextBox8.Text & "'"
                TextBox7.Clear()
            End If

            Call connect()
            Dim da As New MySqlDataAdapter(qry, conn)
            Dim dt As New DataTable()

            da.Fill(dt)

            If dt.Rows.Count > 0 Then
                DataGridView1.DataSource = dt
                DataGridView1.Refresh()
            Else
                MsgBox("No records found.")
                DataGridView1.DataSource = Nothing  ' Clear the DataGridView if no records found
            End If

            conn.Close()
        End If
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        If user = "admin" Then
            AdminDashboard.Show()
        ElseIf user = "manager" Then
            ManagerDashboard.Show()
        End If
    End Sub
End Class
