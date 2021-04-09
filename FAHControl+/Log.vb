Public Class Log
    Private Sub Log_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler Logger.LogFileContentsChanged, AddressOf Log_LogFileContentsChanged

        ReloadLogs()
    End Sub

    Private Sub ReloadLogs()
        logDGV.Rows.Clear()

        For Each Entry As Dictionary(Of String, Object) In Logger.Log
            logDGV.Rows.Add({Entry("timestamp"), Entry("component"), Entry("message")})
        Next
    End Sub

    Private Sub Log_LogFileContentsChanged(ByVal sender As Object, ByVal e As EventArgs)
        ReloadLogs()
    End Sub
End Class