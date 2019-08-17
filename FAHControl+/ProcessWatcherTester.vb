Public Class ProcessWatcherTester
    Dim WithEvents creationWatcher As ProcessWatcher
    Dim WithEvents deletionWatcher As ProcessWatcher
    Private Sub ProcessWatcherTester_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        creationWatcher = New ProcessWatcher(ProcessWatcher.ModeEnum.Creation)
        creationWatcher.Listen()

        deletionWatcher = New ProcessWatcher(ProcessWatcher.ModeEnum.Deletion)
        deletionWatcher.Listen()
    End Sub

    Private Sub ProcessWatcherTester_Closing(sender As Object, e As EventArgs) Handles MyBase.Closing
        creationWatcher.StopListening()
        deletionWatcher.StopListening()
    End Sub

    Private Sub notepadCBX_CheckedChanged(sender As Object, e As EventArgs) Handles notepadCBX.CheckedChanged
        If notepadCBX.Checked Then creationWatcher.AddWatchedProcess("C:\WINDOWS\system32\notepad.exe") Else creationWatcher.RemoveWatchedProcess("C:\WINDOWS\system32\notepad.exe")
        creationWatcher.RestartListener()

        If notepadCBX.Checked Then deletionWatcher.AddWatchedProcess("C:\WINDOWS\system32\notepad.exe") Else deletionWatcher.RemoveWatchedProcess("C:\WINDOWS\system32\notepad.exe")
        deletionWatcher.RestartListener()
    End Sub

    Private Sub paintCBX_CheckedChanged(sender As Object, e As EventArgs) Handles paintCBX.CheckedChanged
        If paintCBX.Checked Then creationWatcher.AddWatchedProcess("C:\WINDOWS\system32\mspaint.exe") Else creationWatcher.RemoveWatchedProcess("C:\WINDOWS\system32\mspaint.exe")
        creationWatcher.RestartListener()

        If paintCBX.Checked Then deletionWatcher.AddWatchedProcess("C:\WINDOWS\system32\mspaint.exe") Else deletionWatcher.RemoveWatchedProcess("C:\WINDOWS\system32\mspaint.exe")
        deletionWatcher.RestartListener()
    End Sub

    Private Sub watcher_ProcessCreated(ByVal Mode As ProcessWatcher.ModeEnum, ByVal ProcessName As String) Handles creationWatcher.ProcessEvent, deletionWatcher.ProcessEvent
        Dim ModeStr As String = String.Empty
        If Mode = ProcessWatcher.ModeEnum.Creation Then ModeStr = "created" Else ModeStr = "deleted"

        MsgBox("Process " & ProcessName & " " & ModeStr & ".", MsgBoxStyle.Information)
    End Sub
End Class