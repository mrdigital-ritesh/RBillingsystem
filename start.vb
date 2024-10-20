Public Class start
    Private Sub start_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.BackgroundImage = My.Resources.bg
        Me.BackgroundImageLayout = ImageLayout.Stretch
        ADMIN.Text = "ADMIN"
        MANAGER.Text = "MANAGER"
        EMPLOYEE.Text = "EMPLOYEE"

    End Sub


    Private Sub PictureBox2_Click_1(sender As Object, e As EventArgs) Handles PictureBox2.Click
        loginform.Show()

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        loginform.Show()

    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        loginform.Show()

    End Sub

    Private Sub closebt_Click(sender As Object, e As EventArgs) Handles closebt.Click
        Me.Close()
    End Sub
End Class