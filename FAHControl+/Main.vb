Public Class Main
    Dim trayControl As NotifyIcon
    Dim snoozeThread As Threading.Thread
    Dim WithEvents fc As FAH.Client

    Dim WithEvents fw_c As ProcessWatcher
    Dim WithEvents fw_d As ProcessWatcher

    Dim fw_a As List(Of String)
    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Visible = False
        Me.WindowState = FormWindowState.Minimized
        Me.ShowInTaskbar = False

        Dim connectionMI As New MenuItem("Connected")
        AddHandler connectionMI.Click, AddressOf connectionMI_Click

        Dim snoozeMI As New MenuItem("Snooze")
        AddHandler snoozeMI.Click, AddressOf snoozeMI_Click

        Dim spacerMI As New MenuItem("-")
        spacerMI.Enabled = False

        Dim settingsMI As New MenuItem("Settings")
        AddHandler settingsMI.Click, AddressOf settingsMI_Click

        Dim exitMI As New MenuItem("Exit")
        AddHandler exitMI.Click, AddressOf exitMI_Click

        Dim cm As New ContextMenu
        With cm.MenuItems
            .Add(connectionMI)
            .Add(snoozeMI)
            .Add(spacerMI)
            .Add(settingsMI)
            .Add(exitMI)
        End With

        trayControl = New NotifyIcon With {
            .Icon = My.Resources.fah,
            .Visible = True,
            .ContextMenu = cm
        }

        fw_c = New ProcessWatcher(ProcessWatcher.ModeEnum.Creation)
        fw_d = New ProcessWatcher(ProcessWatcher.ModeEnum.Deletion)

        For Each app As String In My.Settings.fahConfApps
            fw_c.AddWatchedProcess(app)
            fw_d.AddWatchedProcess(app)
        Next

        fw_c.Listen()
        fw_d.Listen()

        fw_a = New List(Of String)

        fc = New FAH.Client
        fc.Connect(False)
    End Sub

    Private Sub snoozeMI_Click(sender As Object, e As EventArgs)
        If snoozeThread IsNot Nothing AndAlso snoozeThread.ThreadState <> Threading.ThreadState.Stopped Then snoozeThread.Abort()

        Dim s As MenuItem = sender
        Dim CurrentSlotInfo As List(Of FAH.Slot) = fc.ListSlots()
        Dim FilteredSlotInfo As List(Of FAH.Slot) = CurrentSlotInfo.Where(Function(y) CurrentSlotInfo.Select(Function(x) x.ID).
                                                                              Intersect(My.Settings.fahSlotWhitelist.Split(",").ToList().
                                                                              Select(Function(x) x)).Contains(y.ID)).ToList()

        Dim IntendedAction As String = String.Empty
        If s.Checked Then IntendedAction = "WAKE" Else IntendedAction = "SNOOZE"
        Dim AtleastOneSlotRunning As Boolean = FilteredSlotInfo.Where(Function(x) x.Status = "RUNNING").Count > 0
        Dim AtleastOneSlotSleeping As Boolean = FilteredSlotInfo.Where(Function(x) x.Status = "PAUSED").Count > 0

        If IntendedAction = "WAKE" And AtleastOneSlotSleeping Then
            snoozeThread = New Threading.Thread(Sub() Wake(FilteredSlotInfo))
            snoozeThread.Start()
        ElseIf IntendedAction = "SNOOZE" And AtleastOneSlotRunning Then
            snoozeThread = New Threading.Thread(Sub() SnoozeCycle(FilteredSlotInfo))
            snoozeThread.Start()
        End If

        If s.Checked Then s.Checked = False Else s.Checked = True
    End Sub

    Private Sub settingsMI_Click(sender As Object, e As EventArgs)
        Settings.ShowDialog()

        If My.Settings.fahUseConfApp Then
            fw_c.ClearWatchedProcesses()
            fw_d.ClearWatchedProcesses()

            For Each app As String In My.Settings.fahConfApps
                fw_c.AddWatchedProcess(app)
                fw_d.AddWatchedProcess(app)
            Next

            fw_c.RestartListener()
            fw_d.RestartListener()
        Else
            fw_c.StopListening()
            fw_d.StopListening()
        End If
    End Sub

    Private Sub exitMI_Click(sender As Object, e As EventArgs)
        Environment.Exit(0)
    End Sub

    Private Sub SnoozeCycle(Optional ByVal Slots As List(Of FAH.Slot) = Nothing)
        Dim SleepValue As Integer = My.Settings.fahSnoozeValue * 60 * 1000

        Snooze(Slots)
        Threading.Thread.Sleep(SleepValue)
        Wake(Slots)
    End Sub

    Private Function Snooze(Optional ByVal Slots As List(Of FAH.Slot) = Nothing) As Boolean
        If Slots Is Nothing Then Slots = New List(Of FAH.Slot) From {New FAH.Slot}

        For Each Slot In Slots
            Dim PauseResponses As List(Of String) = fc.SendReceiveCommand("pause " & Slot.ID, 2, 3000)
            Dim PauseLastResponse As New List(Of FAH.Slot)
            If PauseResponses.Count > 0 Then Else If FAH.Slot.FromString(PauseResponses.Last()).Where(Function(x) x.Status = "RUNNING").Count < 0 Then Return False
        Next

        trayControl.ContextMenu.MenuItems.Item(1).Checked = True
        Return True
    End Function

    Private Function Wake(Optional ByVal Slots As List(Of FAH.Slot) = Nothing) As Boolean
        If Slots Is Nothing Then Slots = New List(Of FAH.Slot) From {New FAH.Slot}

        For Each Slot In Slots
            Dim UnPauseResponses As List(Of String) = fc.SendReceiveCommand("unpause " & Slot.ID, 2, 3000)
            Dim UnPauseLastResponse As New List(Of FAH.Slot)
            If UnPauseResponses.Count > 0 Then Else If FAH.Slot.FromString(UnPauseResponses.Last()).Where(Function(x) x.Status = "PAUSED").Count < 0 Then Return False
        Next

        trayControl.ContextMenu.MenuItems.Item(1).Checked = False
        Return True
    End Function

    Private Sub fc_ConnectionMade() Handles fc.ConnectionMade
        trayControl.ContextMenu.MenuItems.Item(0).Checked = True
    End Sub

    Private Sub fc_ConnectionLost(ByVal PreviouslyConnected As Boolean) Handles fc.ConnectionLost
        trayControl.ContextMenu.MenuItems.Item(0).Checked = False
    End Sub

    Private Sub connectionMI_Click(sender As Object, e As EventArgs)
        If trayControl.ContextMenu.MenuItems.Item(0).Checked Then fc.Disconnect() Else fc.Connect(False)
    End Sub

    Private Sub fw_ProcessEvent(ByVal Mode As ProcessWatcher.ModeEnum, ByVal ProcessName As String) Handles fw_c.ProcessEvent, fw_d.ProcessEvent
        If Mode = ProcessWatcher.ModeEnum.Creation Then fw_a.Add(ProcessName) Else If fw_a.Find(Function(x) x = ProcessName) <> String.Empty Then fw_a.Remove(ProcessName)
        If My.Settings.fahSlotWhitelist.Length > 0 Then
            For Each slot As String In My.Settings.fahSlotWhitelist.Split(",")
                If fw_a.Count > 0 Then fc.Pause(slot) Else fc.Unpause(slot)
            Next
        Else
            If fw_a.Count > 0 Then fc.Pause() Else fc.Unpause()
        End If
    End Sub

    Protected Overrides Sub OnShown(e As EventArgs)
        MyBase.OnShown(e)
        Me.Hide()
    End Sub
End Class
