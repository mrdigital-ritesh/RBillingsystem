Public Class loginform
    Private Sub loginform_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.BackgroundImage = My.Resources.bg
        Me.BackgroundImageLayout = ImageLayout.Stretch
    End Sub

    Private Sub closebt_Click(sender As Object, e As EventArgs) Handles closebt.Click
        start.Close()
        Me.Close()

    End Sub

    Private Sub backbt_Click(sender As Object, e As EventArgs) Handles backbt.Click
        Me.Hide()
        start.Show()
    End Sub


End Class