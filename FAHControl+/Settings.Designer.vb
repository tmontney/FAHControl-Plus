<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Settings
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
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
        Me.slotidsLBL = New System.Windows.Forms.Label()
        Me.slotidsTXT = New System.Windows.Forms.TextBox()
        Me.confappGBX = New System.Windows.Forms.GroupBox()
        Me.confappAddBTN = New System.Windows.Forms.Button()
        Me.confappRemBTN = New System.Windows.Forms.Button()
        Me.confappsCBX = New System.Windows.Forms.CheckBox()
        Me.confappLBX = New System.Windows.Forms.ListBox()
        Me.fahclientGBX.SuspendLayout()
        Me.snoozeGBX.SuspendLayout()
        Me.slotwhitelistGBX.SuspendLayout()
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
        Me.fahclientGBX.Location = New System.Drawing.Point(16, 15)
        Me.fahclientGBX.Margin = New System.Windows.Forms.Padding(4)
        Me.fahclientGBX.Name = "fahclientGBX"
        Me.fahclientGBX.Padding = New System.Windows.Forms.Padding(4)
        Me.fahclientGBX.Size = New System.Drawing.Size(225, 187)
        Me.fahclientGBX.TabIndex = 0
        Me.fahclientGBX.TabStop = False
        Me.fahclientGBX.Text = "FAHClient Connection"
        '
        'fahclientPasswordTXT
        '
        Me.fahclientPasswordTXT.Location = New System.Drawing.Point(76, 102)
        Me.fahclientPasswordTXT.Margin = New System.Windows.Forms.Padding(4)
        Me.fahclientPasswordTXT.Name = "fahclientPasswordTXT"
        Me.fahclientPasswordTXT.Size = New System.Drawing.Size(96, 22)
        Me.fahclientPasswordTXT.TabIndex = 5
        '
        'fahclientPasswordLBL
        '
        Me.fahclientPasswordLBL.AutoSize = True
        Me.fahclientPasswordLBL.Location = New System.Drawing.Point(8, 106)
        Me.fahclientPasswordLBL.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.fahclientPasswordLBL.Name = "fahclientPasswordLBL"
        Me.fahclientPasswordLBL.Size = New System.Drawing.Size(69, 17)
        Me.fahclientPasswordLBL.TabIndex = 4
        Me.fahclientPasswordLBL.Text = "Password"
        '
        'fahclientTestBTN
        '
        Me.fahclientTestBTN.Location = New System.Drawing.Point(57, 151)
        Me.fahclientTestBTN.Margin = New System.Windows.Forms.Padding(4)
        Me.fahclientTestBTN.Name = "fahclientTestBTN"
        Me.fahclientTestBTN.Size = New System.Drawing.Size(100, 28)
        Me.fahclientTestBTN.TabIndex = 1
        Me.fahclientTestBTN.Text = "Test"
        Me.fahclientTestBTN.UseVisualStyleBackColor = True
        '
        'fahclientPortTXT
        '
        Me.fahclientPortTXT.Location = New System.Drawing.Point(76, 70)
        Me.fahclientPortTXT.Margin = New System.Windows.Forms.Padding(4)
        Me.fahclientPortTXT.Name = "fahclientPortTXT"
        Me.fahclientPortTXT.Size = New System.Drawing.Size(96, 22)
        Me.fahclientPortTXT.TabIndex = 3
        '
        'fahclientPortLBL
        '
        Me.fahclientPortLBL.AutoSize = True
        Me.fahclientPortLBL.Location = New System.Drawing.Point(8, 74)
        Me.fahclientPortLBL.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.fahclientPortLBL.Name = "fahclientPortLBL"
        Me.fahclientPortLBL.Size = New System.Drawing.Size(34, 17)
        Me.fahclientPortLBL.TabIndex = 2
        Me.fahclientPortLBL.Text = "Port"
        '
        'fahclientAddressTXT
        '
        Me.fahclientAddressTXT.Location = New System.Drawing.Point(76, 38)
        Me.fahclientAddressTXT.Margin = New System.Windows.Forms.Padding(4)
        Me.fahclientAddressTXT.Name = "fahclientAddressTXT"
        Me.fahclientAddressTXT.ReadOnly = True
        Me.fahclientAddressTXT.Size = New System.Drawing.Size(96, 22)
        Me.fahclientAddressTXT.TabIndex = 1
        Me.fahclientAddressTXT.Text = "localhost"
        '
        'fahclientAddressLBL
        '
        Me.fahclientAddressLBL.AutoSize = True
        Me.fahclientAddressLBL.Location = New System.Drawing.Point(8, 42)
        Me.fahclientAddressLBL.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.fahclientAddressLBL.Name = "fahclientAddressLBL"
        Me.fahclientAddressLBL.Size = New System.Drawing.Size(60, 17)
        Me.fahclientAddressLBL.TabIndex = 0
        Me.fahclientAddressLBL.Text = "Address"
        '
        'saveBTN
        '
        Me.saveBTN.Location = New System.Drawing.Point(36, 672)
        Me.saveBTN.Margin = New System.Windows.Forms.Padding(4)
        Me.saveBTN.Name = "saveBTN"
        Me.saveBTN.Size = New System.Drawing.Size(100, 28)
        Me.saveBTN.TabIndex = 1
        Me.saveBTN.Text = "Save"
        Me.saveBTN.UseVisualStyleBackColor = True
        '
        'cancelBTN
        '
        Me.cancelBTN.Location = New System.Drawing.Point(144, 672)
        Me.cancelBTN.Margin = New System.Windows.Forms.Padding(4)
        Me.cancelBTN.Name = "cancelBTN"
        Me.cancelBTN.Size = New System.Drawing.Size(100, 28)
        Me.cancelBTN.TabIndex = 2
        Me.cancelBTN.Text = "Cancel"
        Me.cancelBTN.UseVisualStyleBackColor = True
        '
        'snoozeGBX
        '
        Me.snoozeGBX.Controls.Add(Me.fahSnoozeTXT)
        Me.snoozeGBX.Controls.Add(Me.snoozeLBL)
        Me.snoozeGBX.Location = New System.Drawing.Point(16, 209)
        Me.snoozeGBX.Name = "snoozeGBX"
        Me.snoozeGBX.Size = New System.Drawing.Size(225, 61)
        Me.snoozeGBX.TabIndex = 3
        Me.snoozeGBX.TabStop = False
        '
        'fahSnoozeTXT
        '
        Me.fahSnoozeTXT.Location = New System.Drawing.Point(128, 15)
        Me.fahSnoozeTXT.Name = "fahSnoozeTXT"
        Me.fahSnoozeTXT.Size = New System.Drawing.Size(61, 22)
        Me.fahSnoozeTXT.TabIndex = 1
        '
        'snoozeLBL
        '
        Me.snoozeLBL.AutoSize = True
        Me.snoozeLBL.Location = New System.Drawing.Point(3, 18)
        Me.snoozeLBL.Name = "snoozeLBL"
        Me.snoozeLBL.Size = New System.Drawing.Size(119, 17)
        Me.snoozeLBL.TabIndex = 0
        Me.snoozeLBL.Text = "Snooze (Minutes)"
        '
        'slotwhitelistGBX
        '
        Me.slotwhitelistGBX.Controls.Add(Me.slotidsLBL)
        Me.slotwhitelistGBX.Controls.Add(Me.slotidsTXT)
        Me.slotwhitelistGBX.Location = New System.Drawing.Point(16, 276)
        Me.slotwhitelistGBX.Name = "slotwhitelistGBX"
        Me.slotwhitelistGBX.Size = New System.Drawing.Size(225, 67)
        Me.slotwhitelistGBX.TabIndex = 4
        Me.slotwhitelistGBX.TabStop = False
        Me.slotwhitelistGBX.Text = "Slot Whitelist"
        '
        'slotidsLBL
        '
        Me.slotidsLBL.AutoSize = True
        Me.slotidsLBL.Location = New System.Drawing.Point(8, 24)
        Me.slotidsLBL.Name = "slotidsLBL"
        Me.slotidsLBL.Size = New System.Drawing.Size(56, 17)
        Me.slotidsLBL.TabIndex = 1
        Me.slotidsLBL.Text = "Slot IDs"
        '
        'slotidsTXT
        '
        Me.slotidsTXT.Location = New System.Drawing.Point(70, 21)
        Me.slotidsTXT.Name = "slotidsTXT"
        Me.slotidsTXT.Size = New System.Drawing.Size(149, 22)
        Me.slotidsTXT.TabIndex = 0
        '
        'confappGBX
        '
        Me.confappGBX.Controls.Add(Me.confappAddBTN)
        Me.confappGBX.Controls.Add(Me.confappRemBTN)
        Me.confappGBX.Controls.Add(Me.confappsCBX)
        Me.confappGBX.Controls.Add(Me.confappLBX)
        Me.confappGBX.Location = New System.Drawing.Point(16, 349)
        Me.confappGBX.Name = "confappGBX"
        Me.confappGBX.Size = New System.Drawing.Size(225, 236)
        Me.confappGBX.TabIndex = 5
        Me.confappGBX.TabStop = False
        Me.confappGBX.Text = "Conflicting Apps"
        '
        'confappAddBTN
        '
        Me.confappAddBTN.Location = New System.Drawing.Point(193, 97)
        Me.confappAddBTN.Name = "confappAddBTN"
        Me.confappAddBTN.Size = New System.Drawing.Size(30, 23)
        Me.confappAddBTN.TabIndex = 3
        Me.confappAddBTN.Text = "+"
        Me.confappAddBTN.UseVisualStyleBackColor = True
        '
        'confappRemBTN
        '
        Me.confappRemBTN.Location = New System.Drawing.Point(193, 126)
        Me.confappRemBTN.Name = "confappRemBTN"
        Me.confappRemBTN.Size = New System.Drawing.Size(28, 23)
        Me.confappRemBTN.TabIndex = 2
        Me.confappRemBTN.Text = "-"
        Me.confappRemBTN.UseVisualStyleBackColor = True
        '
        'confappsCBX
        '
        Me.confappsCBX.AutoSize = True
        Me.confappsCBX.Location = New System.Drawing.Point(57, 35)
        Me.confappsCBX.Name = "confappsCBX"
        Me.confappsCBX.Size = New System.Drawing.Size(82, 21)
        Me.confappsCBX.TabIndex = 1
        Me.confappsCBX.Text = "Enabled"
        Me.confappsCBX.UseVisualStyleBackColor = True
        '
        'confappLBX
        '
        Me.confappLBX.FormattingEnabled = True
        Me.confappLBX.ItemHeight = 16
        Me.confappLBX.Location = New System.Drawing.Point(6, 62)
        Me.confappLBX.Name = "confappLBX"
        Me.confappLBX.Size = New System.Drawing.Size(183, 148)
        Me.confappLBX.TabIndex = 0
        '
        'Settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(270, 723)
        Me.Controls.Add(Me.confappGBX)
        Me.Controls.Add(Me.slotwhitelistGBX)
        Me.Controls.Add(Me.snoozeGBX)
        Me.Controls.Add(Me.cancelBTN)
        Me.Controls.Add(Me.saveBTN)
        Me.Controls.Add(Me.fahclientGBX)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Settings"
        Me.Text = "FAHControl+ Settings"
        Me.fahclientGBX.ResumeLayout(False)
        Me.fahclientGBX.PerformLayout()
        Me.snoozeGBX.ResumeLayout(False)
        Me.snoozeGBX.PerformLayout()
        Me.slotwhitelistGBX.ResumeLayout(False)
        Me.slotwhitelistGBX.PerformLayout()
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
    Friend WithEvents slotidsLBL As Label
    Friend WithEvents slotidsTXT As TextBox
    Friend WithEvents confappGBX As GroupBox
    Friend WithEvents confappAddBTN As Button
    Friend WithEvents confappRemBTN As Button
    Friend WithEvents confappsCBX As CheckBox
    Friend WithEvents confappLBX As ListBox
End Class
