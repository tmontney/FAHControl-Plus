Namespace FAH
    Public Class Client : Implements IDisposable
        Public Event DataReceived(ByVal Data As String)
        Public Event UpdateReceived(ByVal Data As String)
        Public Event ConnectionMade()
        Public Event ConnectionLost(ByVal PreviouslyConnected As Boolean)

        Public Property SendLfOnCmd As Boolean
        Public Property WaitMSecondsBeforeClassifyUpdateMessage As Integer

        Public ReadOnly Property Host As String
        Public ReadOnly Property Port As Integer
        Public ReadOnly Property Connected As Boolean
        Public ReadOnly Property LastCommandSend As Date
        Public ReadOnly Property AlwaysListen As Boolean

        Private tClient As Net.Sockets.TcpClient
        Private SuppressDataReceivedEvents As Integer
        Private tListener As Threading.Thread
        Private Connecting As Boolean
        Private Property Updates As List(Of Update)

        Public Sub New()
            SendLfOnCmd = True
            LastCommandSend = Date.Parse("1/1/1970")
            WaitMSecondsBeforeClassifyUpdateMessage = 1250
            Updates = New List(Of Update)
        End Sub

        Public Sub Connect(ByVal AlwaysListen As Boolean, Optional ByVal host As String = "localhost",
                Optional ByVal port As Integer = 36330)
            _Host = host
            _Port = port
            _AlwaysListen = AlwaysListen

            Connecting = True

            Try
                tClient = New Net.Sockets.TcpClient(host, port)
            Catch ex As Exception
                SetConnectionLost()
            End Try

            _Connected = tClient.Connected
            If _Connected Then SetConnectionMade()

            tListener = New Threading.Thread(AddressOf Listen)
            tListener.Start()

            Connecting = False
        End Sub

        Public Shared Function FAHOutputStrToObject(ByVal Output As String) As Object
            Dim StartOpenBracket As Integer = Output.IndexOf("[")
            If StartOpenBracket <> -1 Then
                Dim EndCloseBracket As Integer = Output.LastIndexOf("]")
                If EndCloseBracket <> -1 Then
                    Dim JsonStr As String = Output.Substring(StartOpenBracket, (EndCloseBracket - StartOpenBracket) + 1).Replace("False", Chr(34) & "False" & Chr(34)).Replace("True", Chr(34) & "True" & Chr(34))
                    Return Newtonsoft.Json.JsonConvert.DeserializeObject(JsonStr, New Newtonsoft.Json.JsonSerializerSettings With {.NullValueHandling = Newtonsoft.Json.NullValueHandling.Include})
                End If
            End If

            Return Nothing
        End Function

        Private Sub SendEmpty(Optional ByVal Amount As Integer = 4)
            SuppressDataReceivedEvents += 1

            For i As Integer = 0 To Amount - 1
                SendCommand(String.Empty)
            Next
        End Sub

        Public Sub Disconnect()
            SendCommand("quit")
            If tListener IsNot Nothing Then tListener.Abort()
            If tClient IsNot Nothing Then tClient.Close()
            SetConnectionLost()
        End Sub

        Public Sub SendCommand(ByVal Command As String)
            If tClient.Connected Then
                If SendLfOnCmd Then Command += vbLf

                Dim b() As Byte = System.Text.ASCIIEncoding.ASCII.GetBytes(Command)
                Dim wr As Net.Sockets.NetworkStream = tClient.GetStream()
                wr.Write(b, 0, b.Length)
                wr.Flush()

                _LastCommandSend = Date.Now()
            End If
        End Sub

        Public Function SendReceiveCommand(ByVal Command As String, ByVal WaitForMessages As Integer, ByVal MaxMSWaitBetweenMessages As Integer, Optional ByVal IncludeDateStamp As Boolean = False) As List(Of String)
            Dim Responses As New List(Of String)

            If AlwaysListen = False Then
                SendCommand(Command)

                For i As Integer = 0 To WaitForMessages - 1
                    Dim Response As String = ReceiveResponse(, MaxMSWaitBetweenMessages)
                    If Response = "-1" Or Response = String.Empty Then Exit For
                    If IncludeDateStamp Then Response = Date.Now.ToString("MM/dd/yyyy HH:MM:ss.fff") + vbNewLine + Response
                    Responses.Add(Response)
                Next
            End If

            Return Responses
        End Function

        Private Function ReceiveResponse(Optional ByVal BufferSize As Integer = 8192, Optional ByVal ReadTimeout As Integer = -1) As String
            Dim b(BufferSize) As Byte
            Dim r As Integer = 0

            Dim ns As Net.Sockets.NetworkStream = tClient.GetStream()
            If ReadTimeout > -1 Then ns.ReadTimeout = ReadTimeout Else ns.ReadTimeout = -1

            Try
                r = ns.Read(b, 0, b.Length)
                ns.Flush()
            Catch timeout As System.IO.IOException
                Return "-1"
            End Try

            If r = 0 Then Return String.Empty Else Return Text.ASCIIEncoding.ASCII.GetString(b).Trim()
        End Function

        Private Sub Listen()
            Dim Response As String = String.Empty

            While Connecting Or Connected
                Try
                    Response = ReceiveResponse()
                Catch ex As Exception
                    Exit While
                End Try

                If Response = String.Empty Then
                    Exit While
                Else
                    If Connecting = False Then
                        If Updates.Count > 0 AndAlso Date.Now.AddMilliseconds(WaitMSecondsBeforeClassifyUpdateMessage) > LastCommandSend Then
                            RaiseEvent UpdateReceived(Response)
                        Else
                            If SuppressDataReceivedEvents = 0 Then RaiseEvent DataReceived(Response) Else SuppressDataReceivedEvents -= 1
                        End If
                    End If
                End If

                If AlwaysListen = False Then Exit While
            End While

            If AlwaysListen Then Disconnect()
        End Sub

        Private Sub SetConnectionMade()
            _Connected = True
            RaiseEvent ConnectionMade()
        End Sub

        Private Sub SetConnectionLost()
            RaiseEvent ConnectionLost(_Connected)
            _Connected = False
        End Sub

        Public Sub Pause(Optional ByVal SlotID As String = "")
            SendCommand("pause " & SlotID)
        End Sub

        Public Sub Unpause(Optional ByVal SlotID As String = "")
            SendCommand("unpause " & SlotID)
        End Sub

        Public Function ListUpdates(Optional ByVal FromServer As Boolean = False) As List(Of Update)
            If FromServer Then Return Updates Else Return Update.FromString(SendReceiveCommand("updates list", 1, 3000).First())
        End Function

        Public Sub ClearUpdates()
            SendCommand("updates clear")
            Updates.Clear()
        End Sub

        Public Sub AddUpdate(ByVal Update As Update)
            SendCommand("updates add " & Update.ToString())
            Updates.Add(Update)
        End Sub

        Public Function ListSlots() As List(Of Slot)
            Dim Response As List(Of String) = SendReceiveCommand("slot-info", 1, 3000)
            If Response.Count > 0 Then Return Slot.FromString(Response.First()) Else Return New List(Of Slot)
        End Function

        Public Sub Dispose() Implements IDisposable.Dispose
            Disconnect()
        End Sub
    End Class

    Public Class Update
        Public Property ID As Integer
        Public Property Rate As Integer
        Public Property Expression As String

        Public Shared Function FromString(ByVal Data As String) As List(Of Update)
            Dim Updates As New List(Of Update)

            For Each line As String In Data.Split(vbNewLine).Where(Function(x) x <> String.Empty)
                Dim l() As String = line.Split(" ")

                Updates.Add(New Update With {
                    .ID = l(0),
                    .Rate = l(1),
                    .Expression = l(2)
                })
            Next

            Return Updates
        End Function

        Public Overrides Function ToString() As String
            Return ID.ToString() & " " & Rate.ToString() & " " & Expression
        End Function
    End Class

    Public Class Slot
        Public Property ID As String
        Public Property Status As String
        Public Property Description As String
        Public Property Options As Dictionary(Of String, String)
        Public Property Reason As String
        Public Property Idle As Boolean

        Public Sub New()
            Options = New Dictionary(Of String, String)
        End Sub

        Public Shared Function FromString(ByVal Data As String) As List(Of Slot)
            Try
                Dim SlotObj As Object = FAH.Client.FAHOutputStrToObject(Data)
                Dim Slots As New List(Of Slot)
                For Each item As Object In SlotObj
                    Dim s As New Slot With {
                        .Description = item("description"),
                        .ID = item("id"),
                        .Idle = item("idle"),
                        .Reason = item("reason"),
                        .Status = item("status")
                    }

                    If item("options") IsNot Nothing Then
                        For Each optItem As Object In item("options")
                            s.Options.Add(optItem.Name, optItem.Value)
                        Next
                    End If

                    Slots.Add(s)
                Next

                Return Slots
            Catch ex As Exception
                Return New List(Of Slot)
            End Try
        End Function

        Public Shared Function FromListIDsOnly(ByVal Data As List(Of String)) As List(Of Slot)
            Dim Slots As New List(Of Slot)

            For Each item In Data
                Slots.Add(New Slot With {.ID = item})
            Next

            Return Slots
        End Function
    End Class
End Namespace

