Imports System.IO
Imports MySql.Data.MySqlClient

Public Class Organization

    Dim qry As String
    Dim cmd As MySqlCommand
    Dim Reader As MySqlDataReader
    Private logoChanged As Boolean = False


    Protected Overrides ReadOnly Property CreateParams As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or &H2000000 ' WS_EX_COMPOSITED
            Return cp
        End Get
    End Property

    Private Sub Organization_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.BackgroundImage = My.Resources.bg
        Me.BackgroundImageLayout = ImageLayout.Stretch
        Setform(Me)

        Me.TopMost = True
        PictureBox1.Image = My.Resources.comapanydefault
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        ShowData()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            PictureBox1.Image = Image.FromFile(openFileDialog.FileName)
            logoChanged = True
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If ValidateFields() Then
            Try
                connect()

                Dim checkQry As String = "SELECT COUNT(*) FROM company WHERE comid = 1"
                Dim checkCmd As New MySqlCommand(checkQry, conn)

                Dim exists As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())

                If exists > 0 Then
                    qry = "UPDATE company SET businessname = @businessname, branch = @branch, gstin = @gstin, " &
                      "country = @country, state = @state, city = @city, accno = @accno, bankname = @bankname, " &
                      "ifsc = @ifsc, mail = @mail, mob = @mob, landline = @landline"

                    If logoChanged AndAlso PictureBox1.Image IsNot Nothing Then
                        qry &= ", logo = @logo"
                    End If

                    qry &= " WHERE comid = 1"
                Else
                    qry = "INSERT INTO company (businessname, branch, gstin, country, state, city, accno, " &
                      "bankname, ifsc, mail, mob, landline, logo) VALUES (@businessname, @branch, @gstin, " &
                      "@country, @state, @city, @accno, @bankname, @ifsc, @mail, @mob, @landline, @logo)"
                End If

                cmd = New MySqlCommand(qry, conn)
                cmd.Parameters.AddWithValue("@businessname", Textboxname.Text)
                cmd.Parameters.AddWithValue("@branch", TextBoxbranch.Text)
                cmd.Parameters.AddWithValue("@gstin", TextBoxgst.Text)
                cmd.Parameters.AddWithValue("@country", TextBoxcountry.Text)
                cmd.Parameters.AddWithValue("@state", TextBoxstate.Text)
                cmd.Parameters.AddWithValue("@city", TextBoxcity.Text)
                cmd.Parameters.AddWithValue("@accno", TextBoxacc.Text)
                cmd.Parameters.AddWithValue("@bankname", TextBoxbank.Text)
                cmd.Parameters.AddWithValue("@ifsc", TextBoxifsc.Text)
                cmd.Parameters.AddWithValue("@mail", TextBoxmail.Text)
                cmd.Parameters.AddWithValue("@mob", TextBoxmobile.Text)
                cmd.Parameters.AddWithValue("@landline", TextBoxland.Text)

                If logoChanged AndAlso PictureBox1.Image IsNot Nothing Then
                    Dim logoBytes() As Byte = Nothing
                    Using ms As New MemoryStream()
                        PictureBox1.Image.Save(ms, PictureBox1.Image.RawFormat)
                        logoBytes = ms.ToArray()
                    End Using
                    cmd.Parameters.AddWithValue("@logo", logoBytes)
                Else
                    If Not logoChanged Then
                        cmd.Parameters.AddWithValue("@logo", DBNull.Value)
                    End If
                End If

                cmd.ExecuteNonQuery()
                conn.Close()

                MessageBox.Show("Organization details saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ShowData()

            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If conn.State = ConnectionState.Open Then conn.Close()
            End Try
            ShowData()

        End If
    End Sub


    Private Sub ShowData()
        Try
            Call connect()

            qry = "SELECT businessname, branch, gstin, country, state, city, accno, bankname, ifsc, mail, mob, landline, logo FROM company WHERE comid = 1"
            cmd = New MySqlCommand(qry, conn)

            Dim reader As MySqlDataReader = cmd.ExecuteReader()

            If reader.Read() Then
                Textboxname.Text = reader("businessname").ToString()
                TextBoxbranch.Text = reader("branch").ToString()
                TextBoxgst.Text = reader("gstin").ToString()
                TextBoxcountry.Text = reader("country").ToString()
                TextBoxstate.Text = reader("state").ToString()
                TextBoxcity.Text = reader("city").ToString()
                TextBoxacc.Text = reader("accno").ToString()
                TextBoxbank.Text = reader("bankname").ToString()
                TextBoxifsc.Text = reader("ifsc").ToString()
                TextBoxmail.Text = reader("mail").ToString()
                TextBoxmobile.Text = reader("mob").ToString()
                TextBoxland.Text = reader("landline").ToString()

                If reader("logo") IsNot DBNull.Value Then
                    Try
                        Dim logoBytes As Byte() = CType(reader("logo"), Byte())
                        If logoBytes.Length > 0 Then
                            Using ms As New MemoryStream(logoBytes)
                                Dim logoImage As Image = Image.FromStream(ms)
                                PictureBox1.Image = logoImage
                                PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
                            End Using
                        Else
                            PictureBox1.Image = My.Resources.comapanydefault
                        End If
                    Catch ex As Exception
                        MessageBox.Show("Error loading logo: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        PictureBox1.Image = My.Resources.comapanydefault
                    End Try
                Else
                    PictureBox1.Image = My.Resources.comapanydefault
                End If
            End If

            reader.Close()

            conn.Close()

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    Private Function ValidateFields() As Boolean
        If Textboxname.Text.Trim() = "" Then
            MessageBox.Show("Please enter organization name.")
            Textboxname.Focus()
            Return False
        End If

        If TextBoxbranch.Text.Trim() = "" Then
            MessageBox.Show("Please enter branch.")
            TextBoxbranch.Focus()
            Return False
        End If

        If TextBoxgst.Text.Trim() = "" Then
            MessageBox.Show("Please enter GSTIN.")
            TextBoxgst.Focus()
            Return False
        End If

        If TextBoxcountry.Text.Trim() = "" Then
            MessageBox.Show("Please enter country.")
            TextBoxcountry.Focus()
            Return False
        End If

        If TextBoxstate.Text.Trim() = "" Then
            MessageBox.Show("Please enter state.")
            TextBoxstate.Focus()
            Return False
        End If

        If TextBoxcity.Text.Trim() = "" Then
            MessageBox.Show("Please enter city.")
            TextBoxcity.Focus()
            Return False
        End If

        If TextBoxacc.Text.Trim() = "" Then
            MessageBox.Show("Please enter account number.")
            TextBoxacc.Focus()
            Return False
        End If

        If TextBoxbank.Text.Trim() = "" Then
            MessageBox.Show("Please enter bank name.")
            TextBoxbank.Focus()
            Return False
        End If

        If TextBoxifsc.Text.Trim() = "" Then
            MessageBox.Show("Please enter IFSC code.")
            TextBoxifsc.Focus()
            Return False
        End If

        If TextBoxmail.Text.Trim() = "" Then
            MessageBox.Show("Please enter email.")
            TextBoxmail.Focus()
            Return False
        End If

        If TextBoxmobile.Text.Trim() = "" Then
            MessageBox.Show("Please enter mobile number.")
            TextBoxmobile.Focus()
            Return False
        End If

        If TextBoxland.Text.Trim() = "" Then
            MessageBox.Show("Please enter landline number.")
            TextBoxland.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub closebt_Click_1(sender As Object, e As EventArgs) Handles closebt.Click
        Me.Close()
    End Sub


End Class
