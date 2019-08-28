Public Class Log
    Private Sub Log_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Log As List(Of Dictionary(Of String, Object)) = Read()

        For Each Entry As Dictionary(Of String, Object) In Log
            logDGV.Rows.Add({Entry("timestamp"), Entry("component"), Entry("message")})
        Next
    End Sub

    Public Shared Function Read() As List(Of Dictionary(Of String, Object))
        Dim Log As List(Of Dictionary(Of String, Object))
        If IO.File.Exists("log.json") Then Log = Newtonsoft.Json.JsonConvert.DeserializeObject(Of List(Of Dictionary(Of String, Object)))(IO.File.ReadAllText("log.json"))
        If Log Is Nothing Then Return New List(Of Dictionary(Of String, Object)) Else Return Log
    End Function

    Public Shared Sub Write(ByVal Msg As String, Optional ByVal Component As String = "Main")
        Dim Log As List(Of Dictionary(Of String, Object)) = Read()
        Dim Entry As New Dictionary(Of String, Object) From {
                {"timestamp", Date.Now()},
                {"component", Component},
                {"message", Msg}
            }
        Log.Add(Entry)

        Dim wl As New Threading.Thread(Sub() WriteLog(Log))
        wl.Start()
    End Sub

    Private Shared Sub WriteLog(ByVal Log As List(Of Dictionary(Of String, Object)))
        For i As Integer = 0 To 2
            Try
                IO.File.WriteAllText("log.json", Newtonsoft.Json.JsonConvert.SerializeObject(Log))
            Catch ex As Exception
                Threading.Thread.Sleep(500)
            End Try
        Next
    End Sub
End Class