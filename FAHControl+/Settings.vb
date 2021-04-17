Public Class Settings
    Dim WithEvents fClient As FAHClient.Client
    Dim confappLBXTT As ToolTip

    Public Sub New(Optional ByVal fClient As FAHClient.Client = Nothing)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.fClient = If(fClient, New FAHClient.Client())
    End Sub

    Private Sub fahclientTestBTN_Click(sender As Object, e As EventArgs) Handles fahclientTestBTN.Click
        Logger.Write("Testing connection to FAHClient", "Settings")
        Using testClient As New FAHClient.Client
            testClient.Connect(False, fahclientAddressTXT.Text, fahclientPortTXT.Text, fahclientPasswordTXT.Text)
            If testClient.Connected Then
                Logger.Write("Test was successful.", "Settings")
                MsgBox("Test successful!")
            Else
                Logger.Write("Test was not successful", "Settings")
                MsgBox("Test failed! Please ensure FAHClient is listening on port " & fahclientPortTXT.Text & " and that the password is correct (if required).")
            End If
        End Using
    End Sub

    '***Likely doesn't work. Disabling for now.***
    'Private Sub fClient_DataReceived(ByVal Data As String()) Handles fClient.DataReceived
    '    If Data = "4>" Then
    '        MsgBox("Connection successful!")
    '    Else
    '        MsgBox("Connection failed.")
    '    End If

    '    fClient.Disconnect()
    'End Sub

    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fahclientAddressTXT.Text = My.Settings.fahClientHost
        fahclientPortTXT.Text = My.Settings.fahClientPort
        fahclientPasswordTXT.Text = My.Settings.fahClientPassword
        fahSnoozeTXT.Text = My.Settings.fahSnoozeValue
        LoadSlots()
        confappsCBX.Checked = My.Settings.fahUseConfApp

        confappLBX.Items.Clear()
        SpecializedStringCollectionToListboxObjectCollection(My.Settings.fahConfApps, confappLBX)

        confappLBXTT = New ToolTip()
    End Sub

    Private Sub LoadSlots()
        slotsDGV.Rows.Clear()

        If fClient.Connected Then
            Dim SlotWhiteList As List(Of String) = If(My.Settings.fahSlotWhitelist <> String.Empty, My.Settings.fahSlotWhitelist.Split(",").ToList(), New List(Of String))
            fClient.ListSlots().ForEach(Sub(x)
                                            Dim SlotChecked As Boolean = SlotWhiteList.Where(Function(y) y = x.ID).Count > 0
                                            slotsDGV.Rows.Add({x.ID, x.Description, SlotChecked})
                                        End Sub)
        End If
    End Sub

    Private Sub SaveSlots()
        Dim SlotWhiteList As New List(Of String)
        For Each row As DataGridViewRow In slotsDGV.Rows
            If row.Cells(2).Value = True Then SlotWhiteList.Add(row.Cells(0).Value)
        Next
        My.Settings.fahSlotWhitelist = String.Join(",", SlotWhiteList.ToArray())

        My.Settings.Save()
    End Sub

    Private Sub Settings_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F1 Then Terminal.ShowDialog() Else If e.KeyCode = Keys.F2 Then ProcessWatcherTester.ShowDialog()
    End Sub

    Private Function ValidateFields(ByRef Msg As String) As Boolean
        Dim SnoozeValue As Integer = 0
        Dim SnoozeValueResult As Boolean = Integer.TryParse(fahSnoozeTXT.Text, SnoozeValue)

        Dim PortValue As Integer = -1
        Dim PortValueResult As Boolean = Integer.TryParse(fahclientPortTXT.Text, PortValue)

        If PortValueResult AndAlso (PortValue < 0 Or PortValue > 65535) Then
            Msg = "Port value must be a number greater or equal to 0 and less than or equal to 65535."
        ElseIf PortValueResult = False Then
            Msg = "Port value must be a whole number."
        End If

        If SnoozeValueResult AndAlso SnoozeValue < 1 Then
            Msg = "Snooze value must be greater than 0."
        ElseIf SnoozeValueResult = False Then
            Msg = "Snooze value must be a whole number."
        End If

        If Msg <> String.Empty Then Return False Else Return True
    End Function

    Private Sub saveBTN_Click(sender As Object, e As EventArgs) Handles saveBTN.Click
        Dim ErrMsg As String = String.Empty
        If ValidateFields(ErrMsg) Then
            My.Settings.fahClientHost = fahclientAddressTXT.Text
            My.Settings.fahClientPort = fahclientPortTXT.Text
            My.Settings.fahClientPassword = fahclientPasswordTXT.Text
            My.Settings.fahSnoozeValue = fahSnoozeTXT.Text

            My.Settings.fahUseConfApp = confappsCBX.Checked
            My.Settings.fahConfApps = ListboxObjectCollectionToSpecializedStringCollection(confappLBX.Items)

            My.Settings.Save()

            SaveSlots()

            Me.Close()
        Else
            MsgBox(ErrMsg, MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub cancelBTN_Click(sender As Object, e As EventArgs) Handles cancelBTN.Click
        Me.Close()
    End Sub

    Private Sub confappAddBTN_Click(sender As Object, e As EventArgs) Handles confappAddBTN.Click
        Using ofd As New OpenFileDialog With {.Filter = "Executable Files (*.exe) | *.exe"}
            If ofd.ShowDialog() = DialogResult.OK Then If confappLBX.Items.IndexOf(ofd.FileName) = -1 Then confappLBX.Items.Add(ofd.FileName)
        End Using
    End Sub

    Private Sub confappRemBTN_Click(sender As Object, e As EventArgs) Handles confappRemBTN.Click
        If confappLBX.SelectedIndex <> -1 Then confappLBX.Items.RemoveAt(confappLBX.SelectedIndex)
    End Sub

    Private Function ListboxObjectCollectionToSpecializedStringCollection(ByVal LBOC As ListBox.ObjectCollection) As Specialized.StringCollection
        Dim ret As New Specialized.StringCollection

        For Each item In LBOC
            ret.Add(item)
        Next

        Return ret
    End Function

    Private Sub SpecializedStringCollectionToListboxObjectCollection(ByVal SSC As Specialized.StringCollection, ByRef LBX As ListBox)
        For Each item In SSC
            LBX.Items.Add(item)
        Next
    End Sub

    Private Sub confappLBX_SelectedIndexChanged(sender As Object, e As MouseEventArgs) Handles confappLBX.MouseMove
        If confappLBX.IndexFromPoint(e.Location) <> -1 Then confappLBXTT.SetToolTip(confappLBX, confappLBX.Items.Item(confappLBX.IndexFromPoint(e.Location)))
    End Sub
End Class