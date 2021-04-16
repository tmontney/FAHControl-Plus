<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Terminal
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
        Me.outputTXT = New System.Windows.Forms.TextBox()
        Me.commandLBL = New System.Windows.Forms.Label()
        Me.commandBTN = New System.Windows.Forms.Button()
        Me.commandTXT = New System.Windows.Forms.TextBox()
        Me.connectionGBX = New System.Windows.Forms.GroupBox()
        Me.connectRBTN = New System.Windows.Forms.RadioButton()
        Me.disconnectRBTN = New System.Windows.Forms.RadioButton()
        Me.commandCRCBX = New System.Windows.Forms.CheckBox()
        Me.commandLFCBX = New System.Windows.Forms.CheckBox()
        Me.crlfCBX = New System.Windows.Forms.CheckBox()
        Me.clearTerminalBTN = New System.Windows.Forms.Button()
        Me.sendrecvTestBTN = New System.Windows.Forms.Button()
        Me.connectionGBX.SuspendLayout()
        Me.SuspendLayout()
        '
        'outputTXT
        '
        Me.outputTXT.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.outputTXT.BackColor = System.Drawing.Color.Black
        Me.outputTXT.ForeColor = System.Drawing.Color.Lime
        Me.outputTXT.Location = New System.Drawing.Point(12, 12)
        Me.outputTXT.Multiline = True
        Me.outputTXT.Name = "outputTXT"
        Me.outputTXT.ReadOnly = True
        Me.outputTXT.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.outputTXT.Size = New System.Drawing.Size(760, 244)
        Me.outputTXT.TabIndex = 0
        '
        'commandLBL
        '
        Me.commandLBL.AutoSize = True
        Me.commandLBL.Location = New System.Drawing.Point(10, 289)
        Me.commandLBL.Name = "commandLBL"
        Me.commandLBL.Size = New System.Drawing.Size(54, 13)
        Me.commandLBL.TabIndex = 1
        Me.commandLBL.Text = "Command"
        '
        'commandBTN
        '
        Me.commandBTN.Location = New System.Drawing.Point(307, 284)
        Me.commandBTN.Name = "commandBTN"
        Me.commandBTN.Size = New System.Drawing.Size(75, 23)
        Me.commandBTN.TabIndex = 2
        Me.commandBTN.Text = "Send"
        Me.commandBTN.UseVisualStyleBackColor = True
        '
        'commandTXT
        '
        Me.commandTXT.Location = New System.Drawing.Point(70, 287)
        Me.commandTXT.Name = "commandTXT"
        Me.commandTXT.Size = New System.Drawing.Size(232, 20)
        Me.commandTXT.TabIndex = 3
        '
        'connectionGBX
        '
        Me.connectionGBX.Controls.Add(Me.connectRBTN)
        Me.connectionGBX.Controls.Add(Me.disconnectRBTN)
        Me.connectionGBX.Location = New System.Drawing.Point(482, 282)
        Me.connectionGBX.Name = "connectionGBX"
        Me.connectionGBX.Size = New System.Drawing.Size(123, 67)
        Me.connectionGBX.TabIndex = 4
        Me.connectionGBX.TabStop = False
        Me.connectionGBX.Text = "Connection Control"
        '
        'connectRBTN
        '
        Me.connectRBTN.AutoSize = True
        Me.connectRBTN.Location = New System.Drawing.Point(6, 21)
        Me.connectRBTN.Name = "connectRBTN"
        Me.connectRBTN.Size = New System.Drawing.Size(65, 17)
        Me.connectRBTN.TabIndex = 5
        Me.connectRBTN.TabStop = True
        Me.connectRBTN.Text = "Connect"
        Me.connectRBTN.UseVisualStyleBackColor = True
        '
        'disconnectRBTN
        '
        Me.disconnectRBTN.AutoSize = True
        Me.disconnectRBTN.Location = New System.Drawing.Point(6, 44)
        Me.disconnectRBTN.Name = "disconnectRBTN"
        Me.disconnectRBTN.Size = New System.Drawing.Size(79, 17)
        Me.disconnectRBTN.TabIndex = 6
        Me.disconnectRBTN.TabStop = True
        Me.disconnectRBTN.Text = "Disconnect"
        Me.disconnectRBTN.UseVisualStyleBackColor = True
        '
        'commandCRCBX
        '
        Me.commandCRCBX.AutoSize = True
        Me.commandCRCBX.Location = New System.Drawing.Point(611, 311)
        Me.commandCRCBX.Name = "commandCRCBX"
        Me.commandCRCBX.Size = New System.Drawing.Size(141, 17)
        Me.commandCRCBX.TabIndex = 6
        Me.commandCRCBX.Text = "Send CR with Command"
        Me.commandCRCBX.UseVisualStyleBackColor = True
        '
        'commandLFCBX
        '
        Me.commandLFCBX.AutoSize = True
        Me.commandLFCBX.Location = New System.Drawing.Point(611, 334)
        Me.commandLFCBX.Name = "commandLFCBX"
        Me.commandLFCBX.Size = New System.Drawing.Size(138, 17)
        Me.commandLFCBX.TabIndex = 7
        Me.commandLFCBX.Text = "Send LF with Command"
        Me.commandLFCBX.UseVisualStyleBackColor = True
        '
        'crlfCBX
        '
        Me.crlfCBX.AutoSize = True
        Me.crlfCBX.Location = New System.Drawing.Point(611, 265)
        Me.crlfCBX.Name = "crlfCBX"
        Me.crlfCBX.Size = New System.Drawing.Size(131, 17)
        Me.crlfCBX.TabIndex = 8
        Me.crlfCBX.Text = "Implicit CR in every LF"
        Me.crlfCBX.UseVisualStyleBackColor = True
        '
        'clearTerminalBTN
        '
        Me.clearTerminalBTN.Location = New System.Drawing.Point(388, 271)
        Me.clearTerminalBTN.Name = "clearTerminalBTN"
        Me.clearTerminalBTN.Size = New System.Drawing.Size(75, 43)
        Me.clearTerminalBTN.TabIndex = 9
        Me.clearTerminalBTN.Text = "Clear Terminal"
        Me.clearTerminalBTN.UseVisualStyleBackColor = True
        '
        'sendrecvTestBTN
        '
        Me.sendrecvTestBTN.Location = New System.Drawing.Point(388, 319)
        Me.sendrecvTestBTN.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.sendrecvTestBTN.Name = "sendrecvTestBTN"
        Me.sendrecvTestBTN.Size = New System.Drawing.Size(75, 50)
        Me.sendrecvTestBTN.TabIndex = 10
        Me.sendrecvTestBTN.Text = "Blocking Send/Recv Test"
        Me.sendrecvTestBTN.UseVisualStyleBackColor = True
        '
        'Terminal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 379)
        Me.Controls.Add(Me.sendrecvTestBTN)
        Me.Controls.Add(Me.clearTerminalBTN)
        Me.Controls.Add(Me.crlfCBX)
        Me.Controls.Add(Me.commandLFCBX)
        Me.Controls.Add(Me.commandCRCBX)
        Me.Controls.Add(Me.connectionGBX)
        Me.Controls.Add(Me.commandTXT)
        Me.Controls.Add(Me.commandBTN)
        Me.Controls.Add(Me.commandLBL)
        Me.Controls.Add(Me.outputTXT)
        Me.Name = "Terminal"
        Me.Text = "Terminal"
        Me.connectionGBX.ResumeLayout(False)
        Me.connectionGBX.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents outputTXT As TextBox
    Friend WithEvents commandLBL As Label
    Friend WithEvents commandBTN As Button
    Friend WithEvents commandTXT As TextBox
    Friend WithEvents connectionGBX As GroupBox
    Friend WithEvents connectRBTN As RadioButton
    Friend WithEvents disconnectRBTN As RadioButton
    Friend WithEvents commandCRCBX As CheckBox
    Friend WithEvents commandLFCBX As CheckBox
    Friend WithEvents crlfCBX As CheckBox
    Friend WithEvents clearTerminalBTN As Button
    Friend WithEvents sendrecvTestBTN As Button
End Class
