<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Settings
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.fahclientGBX = New System.Windows.Forms.GroupBox()
        Me.fahclientPasswordTXT = New System.Windows.Forms.TextBox()
        Me.fahclientPasswordLBL = New System.Windows.Forms.Label()
        Me.fahclientTestBTN = New System.Windows.Forms.Button()
        Me.fahclientPortTXT = New System.Windows.Forms.TextBox()
        Me.fahclientPortLBL = New System.Windows.Forms.Label()
        Me.fahclientAddressTXT = New System.Windows.Forms.TextBox()
        Me.fahclientAddressLBL = New System.Windows.Forms.Label()
        Me.saveBTN = New System.Windows.Forms.Button()
        Me.cancelBTN = New System.Windows.Forms.Button()
        Me.snoozeGBX = New System.Windows.Forms.GroupBox()
        Me.fahSnoozeTXT = New System.Windows.Forms.TextBox()
        Me.snoozeLBL = New System.Windows.Forms.Label()
        Me.slotwhitelistGBX = New System.Windows.Forms.GroupBox()
        Me.slotsDGV = New System.Windows.Forms.DataGridView()
        Me.confappGBX = New System.Windows.Forms.GroupBox()
        Me.confappAddBTN = New System.Windows.Forms.Button()
        Me.confappRemBTN = New System.Windows.Forms.Button()
        Me.confappsCBX = New System.Windows.Forms.CheckBox()
        Me.confappLBX = New System.Windows.Forms.ListBox()
        Me.SlotID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SlotName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Whitelisted = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.fahclientGBX.SuspendLayout()
        Me.snoozeGBX.SuspendLayout()
        Me.slotwhitelistGBX.SuspendLayout()
        CType(Me.slotsDGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.confappGBX.SuspendLayout()
        Me.SuspendLayout()
        '
        'fahclientGBX
        '
        Me.fahclientGBX.Controls.Add(Me.fahclientPasswordTXT)
        Me.fahclientGBX.Controls.Add(Me.fahclientPasswordLBL)
        Me.fahclientGBX.Controls.Add(Me.fahclientTestBTN)
        Me.fahclientGBX.Controls.Add(Me.fahclientPortTXT)
        Me.fahclientGBX.Controls.Add(Me.fahclientPortLBL)
        Me.fahclientGBX.Controls.Add(Me.fahclientAddressTXT)
        Me.fahclientGBX.Controls.Add(Me.fahclientAddressLBL)
        Me.fahclientGBX.Location = New System.Drawing.Point(12, 12)
        Me.fahclientGBX.Name = "fahclientGBX"
        Me.fahclientGBX.Size = New System.Drawing.Size(169, 152)
        Me.fahclientGBX.TabIndex = 0
        Me.fahclientGBX.TabStop = False
        Me.fahclientGBX.Text = "FAHClient Connection"
        '
        'fahclientPasswordTXT
        '
        Me.fahclientPasswordTXT.Enabled = False
        Me.fahclientPasswordTXT.Location = New System.Drawing.Point(57, 83)
        Me.fahclientPasswordTXT.Name = "fahclientPasswordTXT"
        Me.fahclientPasswordTXT.Size = New System.Drawing.Size(73, 20)
        Me.fahclientPasswordTXT.TabIndex = 5
        '
        'fahclientPasswordLBL
        '
        Me.fahclientPasswordLBL.AutoSize = True
        Me.fahclientPasswordLBL.Location = New System.Drawing.Point(6, 86)
        Me.fahclientPasswordLBL.Name = "fahclientPasswordLBL"
        Me.fahclientPasswordLBL.Size = New System.Drawing.Size(53, 13)
        Me.fahclientPasswordLBL.TabIndex = 4
        Me.fahclientPasswordLBL.Text = "Password"
        '
        'fahclientTestBTN
        '
        Me.fahclientTestBTN.Location = New System.Drawing.Point(43, 123)
        Me.fahclientTestBTN.Name = "fahclientTestBTN"
        Me.fahclientTestBTN.Size = New System.Drawing.Size(75, 23)
        Me.fahclientTestBTN.TabIndex = 1
        Me.fahclientTestBTN.Text = "Test"
        Me.fahclientTestBTN.UseVisualStyleBackColor = True
        '
        'fahclientPortTXT
        '
        Me.fahclientPortTXT.Location = New System.Drawing.Point(57, 57)
        Me.fahclientPortTXT.Name = "fahclientPortTXT"
        Me.fahclientPortTXT.Size = New System.Drawing.Size(73, 20)
        Me.fahclientPortTXT.TabIndex = 3
        '
        'fahclientPortLBL
        '
        Me.fahclientPortLBL.AutoSize = True
        Me.fahclientPortLBL.Location = New System.Drawing.Point(6, 60)
        Me.fahclientPortLBL.Name = "fahclientPortLBL"
        Me.fahclientPortLBL.Size = New System.Drawing.Size(26, 13)
        Me.fahclientPortLBL.TabIndex = 2
        Me.fahclientPortLBL.Text = "Port"
        '
        'fahclientAddressTXT
        '
        Me.fahclientAddressTXT.Location = New System.Drawing.Point(57, 31)
        Me.fahclientAddressTXT.Name = "fahclientAddressTXT"
        Me.fahclientAddressTXT.Size = New System.Drawing.Size(73, 20)
        Me.fahclientAddressTXT.TabIndex = 1
        Me.fahclientAddressTXT.Text = "localhost"
        '
        'fahclientAddressLBL
        '
        Me.fahclientAddressLBL.AutoSize = True
        Me.fahclientAddressLBL.Location = New System.Drawing.Point(6, 34)
        Me.fahclientAddressLBL.Name = "fahclientAddressLBL"
        Me.fahclientAddressLBL.Size = New System.Drawing.Size(45, 13)
        Me.fahclientAddressLBL.TabIndex = 0
        Me.fahclientAddressLBL.Text = "Address"
        '
        'saveBTN
        '
        Me.saveBTN.Location = New System.Drawing.Point(105, 432)
        Me.saveBTN.Name = "saveBTN"
        Me.saveBTN.Size = New System.Drawing.Size(75, 23)
        Me.saveBTN.TabIndex = 1
        Me.saveBTN.Text = "Save"
        Me.saveBTN.UseVisualStyleBackColor = True
        '
        'cancelBTN
        '
        Me.cancelBTN.Location = New System.Drawing.Point(186, 432)
        Me.cancelBTN.Name = "cancelBTN"
        Me.cancelBTN.Size = New System.Drawing.Size(75, 23)
        Me.cancelBTN.TabIndex = 2
        Me.cancelBTN.Text = "Cancel"
        Me.cancelBTN.UseVisualStyleBackColor = True
        '
        'snoozeGBX
        '
        Me.snoozeGBX.Controls.Add(Me.fahSnoozeTXT)
        Me.snoozeGBX.Controls.Add(Me.snoozeLBL)
        Me.snoozeGBX.Location = New System.Drawing.Point(11, 169)
        Me.snoozeGBX.Margin = New System.Windows.Forms.Padding(2)
        Me.snoozeGBX.Name = "snoozeGBX"
        Me.snoozeGBX.Padding = New System.Windows.Forms.Padding(2)
        Me.snoozeGBX.Size = New System.Drawing.Size(169, 50)
        Me.snoozeGBX.TabIndex = 3
        Me.snoozeGBX.TabStop = False
        Me.snoozeGBX.Text = "Snooze Button"
        '
        'fahSnoozeTXT
        '
        Me.fahSnoozeTXT.Location = New System.Drawing.Point(97, 16)
        Me.fahSnoozeTXT.Margin = New System.Windows.Forms.Padding(2)
        Me.fahSnoozeTXT.Name = "fahSnoozeTXT"
        Me.fahSnoozeTXT.Size = New System.Drawing.Size(47, 20)
        Me.fahSnoozeTXT.TabIndex = 1
        '
        'snoozeLBL
        '
        Me.snoozeLBL.AutoSize = True
        Me.snoozeLBL.Location = New System.Drawing.Point(4, 19)
        Me.snoozeLBL.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.snoozeLBL.Name = "snoozeLBL"
        Me.snoozeLBL.Size = New System.Drawing.Size(89, 13)
        Me.snoozeLBL.TabIndex = 0
        Me.snoozeLBL.Text = "Snooze (Minutes)"
        '
        'slotwhitelistGBX
        '
        Me.slotwhitelistGBX.Controls.Add(Me.slotsDGV)
        Me.slotwhitelistGBX.Location = New System.Drawing.Point(21, 223)
        Me.slotwhitelistGBX.Margin = New System.Windows.Forms.Padding(2)
        Me.slotwhitelistGBX.Name = "slotwhitelistGBX"
        Me.slotwhitelistGBX.Padding = New System.Windows.Forms.Padding(2)
        Me.slotwhitelistGBX.Size = New System.Drawing.Size(353, 204)
        Me.slotwhitelistGBX.TabIndex = 4
        Me.slotwhitelistGBX.TabStop = False
        Me.slotwhitelistGBX.Text = "Controlled Slots"
        '
        'slotsDGV
        '
        Me.slotsDGV.AllowUserToAddRows = False
        Me.slotsDGV.AllowUserToDeleteRows = False
        Me.slotsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.slotsDGV.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SlotID, Me.SlotName, Me.Whitelisted})
        Me.slotsDGV.Location = New System.Drawing.Point(5, 30)
        Me.slotsDGV.Name = "slotsDGV"
        Me.slotsDGV.Size = New System.Drawing.Size(343, 160)
        Me.slotsDGV.TabIndex = 2
        '
        'confappGBX
        '
        Me.confappGBX.Controls.Add(Me.confappAddBTN)
        Me.confappGBX.Controls.Add(Me.confappRemBTN)
        Me.confappGBX.Controls.Add(Me.confappsCBX)
        Me.confappGBX.Controls.Add(Me.confappLBX)
        Me.confappGBX.Location = New System.Drawing.Point(186, 12)
        Me.confappGBX.Margin = New System.Windows.Forms.Padding(2)
        Me.confappGBX.Name = "confappGBX"
        Me.confappGBX.Padding = New System.Windows.Forms.Padding(2)
        Me.confappGBX.Size = New System.Drawing.Size(169, 192)
        Me.confappGBX.TabIndex = 5
        Me.confappGBX.TabStop = False
        Me.confappGBX.Text = "Conflicting Apps"
        '
        'confappAddBTN
        '
        Me.confappAddBTN.Location = New System.Drawing.Point(145, 79)
        Me.confappAddBTN.Margin = New System.Windows.Forms.Padding(2)
        Me.confappAddBTN.Name = "confappAddBTN"
        Me.confappAddBTN.Size = New System.Drawing.Size(22, 19)
        Me.confappAddBTN.TabIndex = 3
        Me.confappAddBTN.Text = "+"
        Me.confappAddBTN.UseVisualStyleBackColor = True
        '
        'confappRemBTN
        '
        Me.confappRemBTN.Location = New System.Drawing.Point(145, 102)
        Me.confappRemBTN.Margin = New System.Windows.Forms.Padding(2)
        Me.confappRemBTN.Name = "confappRemBTN"
        Me.confappRemBTN.Size = New System.Drawing.Size(21, 19)
        Me.confappRemBTN.TabIndex = 2
        Me.confappRemBTN.Text = "-"
        Me.confappRemBTN.UseVisualStyleBackColor = True
        '
        'confappsCBX
        '
        Me.confappsCBX.AutoSize = True
        Me.confappsCBX.Location = New System.Drawing.Point(43, 28)
        Me.confappsCBX.Margin = New System.Windows.Forms.Padding(2)
        Me.confappsCBX.Name = "confappsCBX"
        Me.confappsCBX.Size = New System.Drawing.Size(65, 17)
        Me.confappsCBX.TabIndex = 1
        Me.confappsCBX.Text = "Enabled"
        Me.confappsCBX.UseVisualStyleBackColor = True
        '
        'confappLBX
        '
        Me.confappLBX.FormattingEnabled = True
        Me.confappLBX.Location = New System.Drawing.Point(4, 50)
        Me.confappLBX.Margin = New System.Windows.Forms.Padding(2)
        Me.confappLBX.Name = "confappLBX"
        Me.confappLBX.Size = New System.Drawing.Size(138, 121)
        Me.confappLBX.TabIndex = 0
        '
        'SlotID
        '
        Me.SlotID.HeaderText = "Slot ID"
        Me.SlotID.Name = "SlotID"
        Me.SlotID.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.SlotID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'SlotName
        '
        Me.SlotName.HeaderText = "Name"
        Me.SlotName.Name = "SlotName"
        Me.SlotName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.SlotName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Whitelisted
        '
        Me.Whitelisted.HeaderText = "Enabled"
        Me.Whitelisted.Name = "Whitelisted"
        Me.Whitelisted.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Whitelisted.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'Settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(385, 477)
        Me.Controls.Add(Me.confappGBX)
        Me.Controls.Add(Me.slotwhitelistGBX)
        Me.Controls.Add(Me.snoozeGBX)
        Me.Controls.Add(Me.cancelBTN)
        Me.Controls.Add(Me.saveBTN)
        Me.Controls.Add(Me.fahclientGBX)
        Me.KeyPreview = True
        Me.Name = "Settings"
        Me.Text = "Settings"
        Me.fahclientGBX.ResumeLayout(False)
        Me.fahclientGBX.PerformLayout()
        Me.snoozeGBX.ResumeLayout(False)
        Me.snoozeGBX.PerformLayout()
        Me.slotwhitelistGBX.ResumeLayout(False)
        CType(Me.slotsDGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.confappGBX.ResumeLayout(False)
        Me.confappGBX.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents fahclientGBX As GroupBox
    Friend WithEvents fahclientTestBTN As Button
    Friend WithEvents fahclientPortTXT As TextBox
    Friend WithEvents fahclientPortLBL As Label
    Friend WithEvents fahclientAddressTXT As TextBox
    Friend WithEvents fahclientAddressLBL As Label
    Friend WithEvents saveBTN As Button
    Friend WithEvents cancelBTN As Button
    Friend WithEvents fahclientPasswordTXT As TextBox
    Friend WithEvents fahclientPasswordLBL As Label
    Friend WithEvents snoozeGBX As GroupBox
    Friend WithEvents fahSnoozeTXT As TextBox
    Friend WithEvents snoozeLBL As Label
    Friend WithEvents slotwhitelistGBX As GroupBox
    Friend WithEvents confappGBX As GroupBox
    Friend WithEvents confappAddBTN As Button
    Friend WithEvents confappRemBTN As Button
    Friend WithEvents confappsCBX As CheckBox
    Friend WithEvents confappLBX As ListBox
    Friend WithEvents slotsDGV As DataGridView
    Friend WithEvents SlotID As DataGridViewTextBoxColumn
    Friend WithEvents SlotName As DataGridViewTextBoxColumn
    Friend WithEvents Whitelisted As DataGridViewCheckBoxColumn
End Class
