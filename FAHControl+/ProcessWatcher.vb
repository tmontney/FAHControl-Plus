Public Class ProcessWatcher
    Public ReadOnly Property IsListening As Boolean
    Public ReadOnly Property ProcessList As List(Of String)
    Public ReadOnly Property Mode As ModeEnum

    Public Event ProcessEvent(ByVal Mode As ModeEnum, ByVal ProcessName As String)

    Public Enum ModeEnum As Integer
        Creation = 0
        Deletion = 1
    End Enum

    Dim watcher As Management.ManagementEventWatcher
    Dim watcherThread As Threading.Thread

    Dim cancellationRequested As Boolean

    Public Sub New(ByVal Mode As ModeEnum)
        Me.Mode = Mode
        _ProcessList = New List(Of String)
    End Sub

    Public Sub Listen()
        cancellationRequested = False
        If IsListening = False Then
            If watcher IsNot Nothing AndAlso watcherThread.ThreadState <> Threading.ThreadState.Stopped Then watcherThread.Abort()

            Dim QueryStr As String = BuildQueryString()
            If QueryStr <> String.Empty Then
                watcher = New Management.ManagementEventWatcher() With {.Query = New Management.WqlEventQuery(GetInstanceClassName(),
            New TimeSpan(0, 0, 1),
            QueryStr)}
                watcher.Options.Timeout = New TimeSpan(0, 0, 3)

                watcherThread = New Threading.Thread(AddressOf tListener)
                watcherThread.Start()
            End If
        End If
    End Sub

    Public Sub StopListening()
        _IsListening = False
        cancellationRequested = True
    End Sub

    Public Sub RestartListener()
        StopListening()
        Listen()
    End Sub

    Public Function ListenOnce() As Management.ManagementBaseObject
        Try
            Return watcher.WaitForNextEvent()
        Catch timeout As Management.ManagementException
            Return Nothing
        End Try
    End Function

    Public Sub AddWatchedProcess(ByVal LiteralPath As String)
        ProcessList.Add(LiteralPath)
    End Sub

    Public Sub RemoveWatchedProcess(ByVal LiteralPath As String)
        If ProcessList.Find(Function(x) x = LiteralPath) <> String.Empty Then ProcessList.Remove(LiteralPath)
    End Sub

    Public Sub ClearWatchedProcesses()
        ProcessList.Clear()
    End Sub

    Private Sub tListener()
        _IsListening = True

        While cancellationRequested = False
            Dim e As Management.ManagementBaseObject = ListenOnce()
            If e IsNot Nothing Then
                Dim expath As String = e("TargetInstance")("ExecutablePath")
                'If expath IsNot Nothing Then
                Dim name As String = e("TargetInstance")("Name")
                '    If ProcessList.Find(Function(x) x = expath) <> String.Empty Then RaiseEvent ProcessEvent(Mode, name)
                RaiseEvent ProcessEvent(Mode, name)
                'End If
            End If
        End While

        watcher.Stop()
        cancellationRequested = False
    End Sub

    Private Function BuildQueryString() As String
        Dim BaseString As String = String.Empty

        If ProcessList.Count > 0 Then
            BaseString = "(TargetInstance Isa " & Chr(34) & "Win32_Process" & Chr(34) & " "

            For Each Prog As String In ProcessList
                BaseString += "AND TargetInstance.ExecutablePath=" & Chr(34) & Prog.Replace("\", "\\") & Chr(34) & " "
            Next
            BaseString = BaseString.Trim()
            BaseString += ")"
        End If

        Return BaseString
    End Function

    Private Function GetInstanceClassName() As String
        If Mode = ModeEnum.Creation Then Return "__InstanceCreationEvent" Else Return "__InstanceDeletionEvent"
    End Function
End Class
