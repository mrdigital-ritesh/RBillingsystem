Public Class testprint
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        BillingReportModule.TriggerPrint(2027)
        Setform(Me)

    End Sub
End Class