Namespace FAHClient
    Public Class Client : Implements IDisposable
        Public Event DataReceived(ByVal Data As String())
        Public Event UpdateReceived(ByVal Data As String)
        Public Event ConnectionMade()
        Public Event ConnectionLost(ByVal PreviouslyConnected As Boolean)
        Public Event ExceptionOccurred(ByVal Component As String, ByVal Exception As Exception)

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
                Exit Sub
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
                    Dim JsonStr As String = Output.Substring(StartOpenBracket, (EndCloseBracket - StartOpenBracket) + 1).Replace("False", """False""").Replace("True", """True""")
                    Return Newtonsoft.Json.JsonConvert.DeserializeObject(Of List(Of Dictionary(Of String, Object)))(JsonStr, New Newtonsoft.Json.JsonSerializerSettings With {.NullValueHandling = Newtonsoft.Json.NullValueHandling.Include})
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
            ' Will throw an exception if commands are sent too quickly.
            If Command <> String.Empty AndAlso tClient.Connected Then
                If SendLfOnCmd Then Command += vbLf

                Dim b() As Byte = System.Text.ASCIIEncoding.ASCII.GetBytes(Command)
                Try
                    Dim wr As Net.Sockets.NetworkStream = tClient.GetStream()
                    wr.Write(b, 0, b.Length)
                    wr.Flush()
                Catch ex As Exception
                    RaiseEvent ExceptionOccurred("SendCommand", ex)
                End Try

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
                        If SuppressDataReceivedEvents = 0 Then
                            RaiseEvent DataReceived(Response.Split("---"))
                        Else
                            SuppressDataReceivedEvents -= 1
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

        Public Enum TypeEnum As Integer
            Multiple = -2
            Unknown = -1
            Slot = 0
            Queue = 1
            Heartbeat = 2
        End Enum

        Public Shared Function TypeDetection(ByVal Data As String, Optional ByVal Exclude As TypeEnum = TypeEnum.Unknown) As TypeEnum
            Dim InitialDetection As TypeEnum = TypeEnum.Unknown

            If (Exclude <> TypeEnum.Slot AndAlso (Data.Contains("id") And Data.Contains("status"))) Then
                InitialDetection = TypeEnum.Slot
            ElseIf (Exclude <> TypeEnum.Queue AndAlso (Data.Contains("id") And Data.Contains("state"))) Then
                InitialDetection = TypeEnum.Queue
            ElseIf (Exclude <> TypeEnum.Heartbeat AndAlso (Data.Contains("heartbeat"))) Then
                InitialDetection = TypeEnum.Heartbeat
            End If

            If InitialDetection <> TypeEnum.Unknown Then
                Dim SecondDetection As TypeEnum = TypeDetection(Data, InitialDetection)
                If SecondDetection <> TypeEnum.Unknown And InitialDetection <> SecondDetection Then InitialDetection = TypeEnum.Multiple
            End If

            Return InitialDetection
        End Function

        Public Shared Function TryParse(ByVal Data As Object, ByVal T As TypeEnum, ByRef Result As Boolean) As Object
            Dim ReturnData As Object = Nothing
            Result = False

            If T = TypeEnum.Heartbeat Then
                ReturnData = HeartbeatFromString(Data)
                If ReturnData <> "-1" Then Result = True
            ElseIf T = TypeEnum.Queue Then
                ReturnData = Queue.FromString(Data)
                If ReturnData.Count > 0 Then Result = True
            ElseIf T = TypeEnum.Slot Then
                ReturnData = Slot.FromString(Data)
                If ReturnData.Count > 0 Then Result = True
            End If

            Return ReturnData
        End Function

        Public Shared Function FromString(ByVal Data As String) As List(Of Update)
            Dim Updates As New List(Of Update)

            For Each line As String In Data.Split(vbNewLine).Where(Function(x) x <> String.Empty)
                Dim l() As String = line.Split(" ")
                Dim u As New Update With {
                .ID = l(0),
                .Rate = l(1)
            }
                If l(2).Contains(" ") Then u.Expression = "$(" & l(2) & ")" Else u.Expression = "$" & l(2)

                Updates.Add(u)
            Next

            Return Updates
        End Function

        Public Shared Function HeartbeatFromString(ByVal Data As String) As String
            Try
                Dim sIndex As Integer = Data.IndexOf("heartbeat")
                If sIndex <> -1 Then
                    Dim eIndex As Integer = Data.IndexOf("-")
                    If eIndex <> -1 Then
                        Return Data.Substring(sIndex + 9, eIndex - (sIndex + 9)).Trim()
                    End If
                End If
            Catch ex As Exception
                Return -1
            End Try

            Return -1
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
                Dim SlotObj As Object = Client.FAHOutputStrToObject(Data)
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

        Public Overrides Function ToString() As String
            Return Newtonsoft.Json.JsonConvert.SerializeObject(Me)
        End Function
    End Class

    Public Class Queue
        Public Property ID As String
        Public Property State As String
        Public Property Error_ As String
        Public Property Project As String
        Public Property Run As String
        Public Property Clone As String
        Public Property Gen As String
        Public Property Core As String
        Public Property Unit As String
        Public Property PercentDone As String
        Public Property ETA As String
        Public Property PPD As String
        Public Property CreditEstimate As String
        Public Property WaitingOn As String
        Public Property NextAttempt As String
        Public Property TimeRemaining As String
        Public Property TotalFrames As String
        Public Property FramesDone As String
        Public Property Assigned As String
        Public Property Timeout As String
        Public Property Deadline As String
        Public Property WS As String
        Public Property CS As String
        Public Property Attempts As String
        Public Property Slot As String
        Public Property TPF As String
        Public Property BaseCredit As String

        Public Shared Function FromString(ByVal Data As String) As List(Of Queue)
            Dim Queue As New List(Of Queue)

            Try
                Dim QueueObj As Object = Client.FAHOutputStrToObject(Data)
                For Each item In QueueObj
                    Dim q As New Queue
                    For Each p As Reflection.PropertyInfo In q.GetType().GetProperties()
                        p.SetValue(q, item(p.Name.Replace("_", "").ToLower()).ToString())
                    Next
                    Queue.Add(q)
                Next
            Catch ex As Exception
                Return New List(Of Queue)
            End Try

            Return Queue
        End Function

        Public Function ToString2() As String
            Return "Slot " & Slot & " running PRCG " & Project & "|" & Run & "|" & Clone & "|" & Gen & " is " & PercentDone & " done, with an estimated credit of " & CreditEstimate & "."
        End Function

        Public Overrides Function ToString() As String
            Return Newtonsoft.Json.JsonConvert.SerializeObject(Me)
        End Function
    End Class
End Namespace