﻿Public Class Main
    Dim trayControl As NotifyIcon
    Dim snoozeThread As Threading.Thread
    Dim WithEvents fc As FAHClient.Client

    Dim WithEvents fw_c As ProcessWatcher
    Dim WithEvents fw_d As ProcessWatcher

    Dim fw_a As List(Of String)
    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Visible = False
        Me.WindowState = FormWindowState.Minimized
        Me.ShowInTaskbar = False

        AddHandler AppDomain.CurrentDomain.ProcessExit, AddressOf OnProcessExit

        Dim connectionMI As New MenuItem("Connect")
        AddHandler connectionMI.Click, AddressOf connectionMI_Click

        Dim snoozeMI As New MenuItem("Snooze")
        AddHandler snoozeMI.Click, AddressOf snoozeMI_Click

        Dim spacerMI As New MenuItem("-")
        spacerMI.Enabled = False

        Dim logMI As New MenuItem("Log")
        AddHandler logMI.Click, AddressOf logMI_Click

        Dim settingsMI As New MenuItem("Settings")
        AddHandler settingsMI.Click, AddressOf settingsMI_Click

        Dim aboutMI As New MenuItem("About")
        AddHandler aboutMI.Click, AddressOf aboutMI_Click

        Dim exitMI As New MenuItem("Exit")
        AddHandler exitMI.Click, AddressOf exitMI_Click

        Dim cm As New ContextMenu
        With cm.MenuItems
            .Add(connectionMI)
            .Add(snoozeMI)
            .Add(spacerMI)
            .Add(logMI)
            .Add(settingsMI)
            .Add(aboutMI)
            .Add(exitMI)
        End With

        trayControl = New NotifyIcon With {
            .Icon = My.Resources.fah,
            .Visible = True,
            .ContextMenu = cm
        }

        Logger.InitializeLog(trayControl)
        Logger.Write("Program start")

        fw_c = New ProcessWatcher(ProcessWatcher.ModeEnum.Creation)
        fw_d = New ProcessWatcher(ProcessWatcher.ModeEnum.Deletion)

        For Each app As String In My.Settings.fahConfApps
            fw_c.AddWatchedProcess(app)
            fw_d.AddWatchedProcess(app)
        Next

        If My.Settings.fahUseConfApp Then
            fw_c.Listen()
            fw_d.Listen()
        End If

        fw_a = New List(Of String)

        fc = New FAHClient.Client
        fc.Connect(False, My.Settings.fahClientHost, My.Settings.fahClientPort, My.Settings.fahClientPassword)
    End Sub

    Private Sub snoozeMI_Click(sender As Object, e As EventArgs)
        If snoozeThread IsNot Nothing AndAlso snoozeThread.ThreadState <> Threading.ThreadState.Stopped Then snoozeThread.Abort()

        Dim s As MenuItem = sender
        Dim CurrentSlotInfo As List(Of FAHClient.Slot) = fc.ListSlots()
        Dim FilteredSlotInfo As List(Of FAHClient.Slot) = CurrentSlotInfo.Where(Function(y) CurrentSlotInfo.Select(Function(x) x.ID).
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
        Using settingsDLG As New Settings(fc)
            settingsDLG.ShowDialog()
        End Using

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

    Private Sub aboutMI_Click(sender As Object, e As EventArgs)
        About.ShowDialog()
    End Sub

    Private Sub exitMI_Click(sender As Object, e As EventArgs)
        Environment.Exit(0)
    End Sub

    Private Sub OnProcessExit(sender As Object, e As EventArgs)
        Logger.Write("Program end")

        fw_c.StopListening()
        fw_d.StopListening()

        fc.Disconnect("Program end")
    End Sub

    Private Sub SnoozeCycle(Optional ByVal Slots As List(Of FAHClient.Slot) = Nothing)
        Dim SleepValue As Integer = My.Settings.fahSnoozeValue * 60 * 1000

        Logger.Write("Running cycle", "Snooze")
        Snooze(Slots)
        Threading.Thread.Sleep(SleepValue)
        Wake(Slots)
    End Sub

    Private Function Snooze(Optional ByVal Slots As List(Of FAHClient.Slot) = Nothing) As Boolean
        If Slots Is Nothing Then Slots = New List(Of FAHClient.Slot) From {New FAHClient.Slot}

        For Each Slot In Slots
            Dim PauseResponses As List(Of String) = fc.SendReceiveCommand("pause " & Slot.ID, 2, 3000)
            Logger.Write("Pausing slot " & Slot.ID)
            Dim PauseLastResponse As New List(Of FAHClient.Slot)
            If PauseResponses.Count > 0 Then Else If FAHClient.Slot.FromString(PauseResponses.Last()).Where(Function(x) x.Status = "RUNNING").Count < 0 Then Return False
        Next

        trayControl.ContextMenu.MenuItems.Item(1).Checked = True
        Return True
    End Function

    Private Function Wake(Optional ByVal Slots As List(Of FAHClient.Slot) = Nothing) As Boolean
        If Slots Is Nothing Then Slots = New List(Of FAHClient.Slot) From {New FAHClient.Slot}

        For Each Slot In Slots
            Dim UnPauseResponses As List(Of String) = fc.SendReceiveCommand("unpause " & Slot.ID, 2, 3000)
            Logger.Write("Unpausing slot " & Slot.ID)
            Dim UnPauseLastResponse As New List(Of FAHClient.Slot)
            If UnPauseResponses.Count > 0 Then Else If FAHClient.Slot.FromString(UnPauseResponses.Last()).Where(Function(x) x.Status = "PAUSED").Count < 0 Then Return False
        Next

        trayControl.ContextMenu.MenuItems.Item(1).Checked = False
        Return True
    End Function

    Private Sub fc_ConnectionMade() Handles fc.ConnectionMade
        trayControl.ContextMenu.MenuItems.Item(0).Checked = True
        Logger.Write("Connected successfully to FAHClient.", "FAHClient")
    End Sub

    Private Sub fc_ConnectionLost(ByVal PreviouslyConnected As Boolean, ByVal Reason As String) Handles fc.ConnectionLost
        trayControl.ContextMenu.MenuItems.Item(0).Checked = False
        Logger.Write("Lost connection to FAHClient: " & Reason, "FAHClient")
    End Sub

    Private Sub connectionMI_Click(sender As Object, e As EventArgs)
        Logger.Write("User clicked the connection button")
        If trayControl.ContextMenu.MenuItems.Item(0).Checked Then fc.Disconnect("User disconnected") Else fc.Connect(False, My.Settings.fahClientHost, My.Settings.fahClientPort, My.Settings.fahClientPassword)
    End Sub

    Private Sub fw_ProcessEvent(ByVal Mode As ProcessWatcher.ModeEnum, ByVal ProcessName As String) Handles fw_c.ProcessEvent, fw_d.ProcessEvent
        If Mode = ProcessWatcher.ModeEnum.Creation Then fw_a.Add(ProcessName) Else If fw_a.Find(Function(x) x = ProcessName) <> String.Empty Then fw_a.Remove(ProcessName)
        If My.Settings.fahSlotWhitelist.Split(",").Length > 0 Then
            Logger.Write("Running cycle", "ConfApp")
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

    Private Sub logMI_Click(sender As Object, e As EventArgs)
        Log.ShowDialog()
    End Sub
End Class
