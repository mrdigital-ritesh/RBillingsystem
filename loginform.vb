Public Class loginform
    Private Sub loginform_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If user = "admin" Then
            loginlabel.Text = "ADMIN LOGIN"
        ElseIf user = "manager" Then
            loginlabel.Text = "MANAGER LOGIN"
        ElseIf user = "emp" Then
            loginlabel.Text = "EMPLOYEE LOGIN"
        End If


        Me.BackgroundImage = My.Resources.bg
        Me.BackgroundImageLayout = ImageLayout.Stretch
        loginlabel.Left = (Me.ClientSize.Width - loginlabel.Width) / 2
    End Sub

    Private Sub closebt_Click(sender As Object, e As EventArgs) Handles closebt.Click
        start.Close()
        Me.Close()

    End Sub

    Private Sub backbt_Click(sender As Object, e As EventArgs) Handles backbt.Click
        Me.Hide()
        start.Show()
        Me.Close()
    End Sub


End Class