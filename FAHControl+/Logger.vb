Public Class Logger
    Public Shared ReadOnly Property Log As List(Of Dictionary(Of String, Object))
    Public Shared ReadOnly Property LogFile As String
    Public Const BASE_LOGFILE_NAME As String = "log-0.json"
    Public Shared ReadOnly Property LogFileLocked As Boolean
    Public Shared ReadOnly Property TrayIconEnabled As Boolean
        Get
            Return TrayIcon IsNot Nothing
        End Get
    End Property

    Public Shared Event LogFileContentsChanged As EventHandler

    Private Const LOGFILE_WRITE_RETRIES = 5
    Private Shared TrayIcon As NotifyIcon

    Public Shared Sub InitializeLog(Optional ByVal TrayIcon As NotifyIcon = Nothing)
        _Log = New List(Of Dictionary(Of String, Object))
        _LogFile = FindLatestLogFile()
        Dim ImportSuccessful As Boolean = False

        Try
            Import()
            ImportSuccessful = True
        Catch notFoundEx As IO.FileNotFoundException
            Logger.Write("Log file could not be found. This could be because the program has never run before.", "Logger", True)
        Catch inUseEx As IO.IOException
            Logger.Write("Log file could not be accessed. Please check that you have access to the file, and that the file is not locked.", "Logger", True)
        Catch ex As Exception
            Logger.Write("An exception occurred while accessing the log file: " & ex.Message, "Logger", True)
        End Try

        If ImportSuccessful = False Then CreateNewLogFile()
        Logger.TrayIcon = TrayIcon
    End Sub

    Private Shared Function FindLatestLogFile() As String
        Dim programDirectoryFiles As New IO.DirectoryInfo(Environment.CurrentDirectory)
        Dim logFiles = programDirectoryFiles.EnumerateFiles("log*.json", IO.SearchOption.TopDirectoryOnly).OrderByDescending(Function(x) x.LastWriteTime)
        If logFiles.Count > 0 Then Return logFiles.First().Name Else Return BASE_LOGFILE_NAME
    End Function

    Private Shared Sub CreateNewLogFile()
        Dim logIteration As Integer = LogFile.Split("-")(1).Substring(0, 1)
        logIteration += 1
        _LogFile = "log-" & (logIteration + 1).ToString() & ".json"
        If Log Is Nothing Then _Log = New List(Of Dictionary(Of String, Object))
        Export()
    End Sub

    Public Shared Sub Write(ByVal Msg As String, Optional ByVal Component As String = "Main",
                            Optional ByVal NoExport As Boolean = False)
        Dim Entry As New Dictionary(Of String, Object) From {
                {"timestamp", Date.Now()},
                {"component", Component},
                {"message", Msg}
            }
        Log.Add(Entry)
        RaiseEvent LogFileContentsChanged(Entry, Nothing)

        If NoExport = False Then Export()
    End Sub

    Private Shared Sub Import()
        _Log = Newtonsoft.Json.JsonConvert.DeserializeObject(Of List(Of Dictionary(Of String, Object)))(IO.File.ReadAllText(LogFile))
        If _Log Is Nothing Then _Log = New List(Of Dictionary(Of String, Object))
    End Sub

    Public Shared Function Export(Optional ByVal RetryCount As Integer = 0) As Boolean
        ' Unsure if recursive function/Thread.Sleep necessary.
        ' Function may cause file to lock and cause simultaneous calls to throw IOException.
        RetryCount += 1
        If RetryCount > LOGFILE_WRITE_RETRIES Then
            ' This should only happen if another program opens the log file for too long.
            ' Increase LOGFILE_WRITE_RETRIES or reduce the time the program keeps the file open.
            Write("Attempted to write " & LOGFILE_WRITE_RETRIES.ToString() & " times to the log file, but it was still locked.", "Logger", True)
            If TrayIconEnabled Then TrayIcon.ShowBalloonTip(5000, "Warning", "Failed to write to the log file. Please investigate.", ToolTipIcon.Warning)
            Return False
        End If

        If LogFileLocked Then
            Threading.Thread.Sleep(100)
            Return Export(RetryCount)
        Else
            _LogFileLocked = True
            Try
                IO.File.WriteAllText(LogFile, Newtonsoft.Json.JsonConvert.SerializeObject(Log))
                _LogFileLocked = False

                Return True
            Catch ex As Exception
                Return Export(RetryCount)
            End Try
        End If
    End Function
End Class
