Public Class start
    Private Sub start_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.BackgroundImage = My.Resources.bg
        Me.BackgroundImageLayout = ImageLayout.Stretch
        ADMIN.Text = "ADMIN"
        MANAGER.Text = "MANAGER"
        EMPLOYEE.Text = "EMPLOYEE"

    End Sub




    Private Sub closebt_Click(sender As Object, e As EventArgs) Handles closebt.Click
        Me.Close()
    End Sub

    Private Sub PictureAdmin_Click(sender As Object, e As EventArgs) Handles PictureAdmin.Click
        user = "admin"
        loginform.Show()

    End Sub

    Private Sub PictureManager_Click(sender As Object, e As EventArgs) Handles PictureManager.Click
        user = "manager"
        loginform.Show()

    End Sub

    Private Sub PictureEmp_Click(sender As Object, e As EventArgs) Handles PictureEmp.Click
        user = "emp"
        loginform.Show()

    End Sub
End Class