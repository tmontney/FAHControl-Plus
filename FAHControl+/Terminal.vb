Public Class Terminal
    Dim WithEvents tClient As FAHClient.Client
    Private Sub connectRBTN_CheckedChanged(sender As Object, e As EventArgs) Handles connectRBTN.CheckedChanged
        If connectRBTN.Checked Then
            outputTXT.AppendText("Attempting to connect to " & My.Settings.fahClientHost & " on TCP port " & My.Settings.fahClientPort.ToString() & "..." & vbNewLine)
            tClient = New FAHClient.Client

            commandLFCBX.Checked = tClient.SendLfOnCmd

            tClient.Connect(My.Settings.fahClientHost, My.Settings.fahClientPort)
        End If
    End Sub

    Private Sub disconnectRBTN_CheckedChanged(sender As Object, e As EventArgs) Handles disconnectRBTN.CheckedChanged
        If disconnectRBTN.Checked Then
            If tClient IsNot Nothing AndAlso tClient.Connected Then tClient.Disconnect()
            outputTXT.Clear()
        End If
    End Sub

    Private Delegate Sub _outputTXT_AppendText(ByVal Text As String)
    Private Sub outputTXT_AppendText(ByVal Text As String)
        If outputTXT.InvokeRequired Then
            outputTXT.Invoke(New _outputTXT_AppendText(AddressOf outputTXT_AppendText), Text)
        Else
            outputTXT.AppendText(Text)
        End If
    End Sub

    Private Sub tClient_DataReceived(ByVal Data As String()) Handles tClient.DataReceived
        For Each item As String In Data
            If crlfCBX.Checked Then item = item.Replace(vbLf, vbCrLf)
            outputTXT_AppendText(item)
        Next

    End Sub

    Private Sub tClient_ConnectionMade() Handles tClient.ConnectionMade

    End Sub

    Private Sub tClient_ConnectionLost(ByVal PreviouslyConnected As Boolean) Handles tClient.ConnectionLost
        RemoveHandler connectRBTN.CheckedChanged, AddressOf connectRBTN_CheckedChanged
        connectRBTN.Checked = False
        AddHandler connectRBTN.CheckedChanged, AddressOf connectRBTN_CheckedChanged
        If PreviouslyConnected = False Then MsgBox("Connection failed!")
    End Sub

    Private Sub commandBTN_Click(sender As Object, e As EventArgs) Handles commandBTN.Click
        Dim cmd As String = commandTXT.Text

        If commandCRCBX.Checked Then cmd += vbCr
        If commandLFCBX.Checked Then cmd += vbLf

        outputTXT.AppendText(commandTXT.Text & vbNewLine)
        tClient.SendCommand(cmd)
    End Sub

    Private Sub Terminal_Closing(sender As Object, e As EventArgs) Handles MyBase.Closing
        If tClient IsNot Nothing AndAlso tClient.Connected Then tClient.Disconnect()
    End Sub

    Private Sub clearTerminalBTN_Click(sender As Object, e As EventArgs) Handles clearTerminalBTN.Click
        outputTXT.Clear()
    End Sub

    Private Sub sendrecvTestBTN_Click(sender As Object, e As EventArgs) Handles sendrecvTestBTN.Click
        tClient.ClearUpdates()

        Dim testUpdate As New FAHClient.Update With {
            .ID = 0,
            .Rate = 0,
            .Expression = "$(slot-info)"
        }

        tClient.AddUpdate(testUpdate)
        Dim PauseResponses As List(Of String) = tClient.SendReceiveCommand("pause", 2, True)

        For Each Response As String In PauseResponses
            MsgBox(Response)
        Next

        Dim UnpauseResponses As List(Of String) = tClient.SendReceiveCommand("unpause", 2, True)

        For Each Response As String In PauseResponses
            MsgBox(Response)
        Next

        tClient.ClearUpdates()
    End Sub
End Class