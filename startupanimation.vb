Imports System.Media

Public Class startupanimation
    Protected Overrides ReadOnly Property CreateParams As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or &H2000000 ' WS_EX_COMPOSITED
            Return cp
        End Get
    End Property

    Private soundPlayer As SoundPlayer

    Private Sub startupanimation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Setform(Me)
        Timer1.Enabled = True
        soundPlayer = New SoundPlayer(My.Resources.musicstart)
        soundPlayer.Load()

        Try
            soundPlayer.Play()
        Catch ex As Exception
            MessageBox.Show($"Error playing sound: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Dim delayTimer As New Timer()
        delayTimer.Interval = 300
        AddHandler delayTimer.Tick, AddressOf DelayAndLoadGif
        delayTimer.Start()
    End Sub

    Private Sub DelayAndLoadGif(sender As Object, e As EventArgs)
        CType(sender, Timer).Stop()

        Try
            PictureBox1.Image = My.Resources.startup1
        Catch ex As Exception
            MessageBox.Show($"Error loading GIF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        start.Show()
    End Sub
End Class
