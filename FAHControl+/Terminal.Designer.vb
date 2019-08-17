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
        Me.outputTXT.Location = New System.Drawing.Point(16, 15)
        Me.outputTXT.Margin = New System.Windows.Forms.Padding(4)
        Me.outputTXT.Multiline = True
        Me.outputTXT.Name = "outputTXT"
        Me.outputTXT.ReadOnly = True
        Me.outputTXT.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.outputTXT.Size = New System.Drawing.Size(1012, 300)
        Me.outputTXT.TabIndex = 0
        '
        'commandLBL
        '
        Me.commandLBL.AutoSize = True
        Me.commandLBL.Location = New System.Drawing.Point(13, 356)
        Me.commandLBL.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.commandLBL.Name = "commandLBL"
        Me.commandLBL.Size = New System.Drawing.Size(71, 17)
        Me.commandLBL.TabIndex = 1
        Me.commandLBL.Text = "Command"
        '
        'commandBTN
        '
        Me.commandBTN.Location = New System.Drawing.Point(409, 349)
        Me.commandBTN.Margin = New System.Windows.Forms.Padding(4)
        Me.commandBTN.Name = "commandBTN"
        Me.commandBTN.Size = New System.Drawing.Size(100, 28)
        Me.commandBTN.TabIndex = 2
        Me.commandBTN.Text = "Send"
        Me.commandBTN.UseVisualStyleBackColor = True
        '
        'commandTXT
        '
        Me.commandTXT.Location = New System.Drawing.Point(93, 353)
        Me.commandTXT.Margin = New System.Windows.Forms.Padding(4)
        Me.commandTXT.Name = "commandTXT"
        Me.commandTXT.Size = New System.Drawing.Size(308, 22)
        Me.commandTXT.TabIndex = 3
        '
        'connectionGBX
        '
        Me.connectionGBX.Controls.Add(Me.connectRBTN)
        Me.connectionGBX.Controls.Add(Me.disconnectRBTN)
        Me.connectionGBX.Location = New System.Drawing.Point(643, 347)
        Me.connectionGBX.Margin = New System.Windows.Forms.Padding(4)
        Me.connectionGBX.Name = "connectionGBX"
        Me.connectionGBX.Padding = New System.Windows.Forms.Padding(4)
        Me.connectionGBX.Size = New System.Drawing.Size(164, 82)
        Me.connectionGBX.TabIndex = 4
        Me.connectionGBX.TabStop = False
        Me.connectionGBX.Text = "Connection Control"
        '
        'connectRBTN
        '
        Me.connectRBTN.AutoSize = True
        Me.connectRBTN.Location = New System.Drawing.Point(8, 26)
        Me.connectRBTN.Margin = New System.Windows.Forms.Padding(4)
        Me.connectRBTN.Name = "connectRBTN"
        Me.connectRBTN.Size = New System.Drawing.Size(81, 21)
        Me.connectRBTN.TabIndex = 5
        Me.connectRBTN.TabStop = True
        Me.connectRBTN.Text = "Connect"
        Me.connectRBTN.UseVisualStyleBackColor = True
        '
        'disconnectRBTN
        '
        Me.disconnectRBTN.AutoSize = True
        Me.disconnectRBTN.Location = New System.Drawing.Point(8, 54)
        Me.disconnectRBTN.Margin = New System.Windows.Forms.Padding(4)
        Me.disconnectRBTN.Name = "disconnectRBTN"
        Me.disconnectRBTN.Size = New System.Drawing.Size(99, 21)
        Me.disconnectRBTN.TabIndex = 6
        Me.disconnectRBTN.TabStop = True
        Me.disconnectRBTN.Text = "Disconnect"
        Me.disconnectRBTN.UseVisualStyleBackColor = True
        '
        'commandCRCBX
        '
        Me.commandCRCBX.AutoSize = True
        Me.commandCRCBX.Location = New System.Drawing.Point(815, 383)
        Me.commandCRCBX.Margin = New System.Windows.Forms.Padding(4)
        Me.commandCRCBX.Name = "commandCRCBX"
        Me.commandCRCBX.Size = New System.Drawing.Size(181, 21)
        Me.commandCRCBX.TabIndex = 6
        Me.commandCRCBX.Text = "Send CR with Command"
        Me.commandCRCBX.UseVisualStyleBackColor = True
        '
        'commandLFCBX
        '
        Me.commandLFCBX.AutoSize = True
        Me.commandLFCBX.Location = New System.Drawing.Point(815, 411)
        Me.commandLFCBX.Margin = New System.Windows.Forms.Padding(4)
        Me.commandLFCBX.Name = "commandLFCBX"
        Me.commandLFCBX.Size = New System.Drawing.Size(178, 21)
        Me.commandLFCBX.TabIndex = 7
        Me.commandLFCBX.Text = "Send LF with Command"
        Me.commandLFCBX.UseVisualStyleBackColor = True
        '
        'crlfCBX
        '
        Me.crlfCBX.AutoSize = True
        Me.crlfCBX.Location = New System.Drawing.Point(815, 326)
        Me.crlfCBX.Margin = New System.Windows.Forms.Padding(4)
        Me.crlfCBX.Name = "crlfCBX"
        Me.crlfCBX.Size = New System.Drawing.Size(169, 21)
        Me.crlfCBX.TabIndex = 8
        Me.crlfCBX.Text = "Implicit CR in every LF"
        Me.crlfCBX.UseVisualStyleBackColor = True
        '
        'clearTerminalBTN
        '
        Me.clearTerminalBTN.Location = New System.Drawing.Point(517, 333)
        Me.clearTerminalBTN.Margin = New System.Windows.Forms.Padding(4)
        Me.clearTerminalBTN.Name = "clearTerminalBTN"
        Me.clearTerminalBTN.Size = New System.Drawing.Size(100, 53)
        Me.clearTerminalBTN.TabIndex = 9
        Me.clearTerminalBTN.Text = "Clear Terminal"
        Me.clearTerminalBTN.UseVisualStyleBackColor = True
        '
        'sendrecvTestBTN
        '
        Me.sendrecvTestBTN.Location = New System.Drawing.Point(517, 393)
        Me.sendrecvTestBTN.Name = "sendrecvTestBTN"
        Me.sendrecvTestBTN.Size = New System.Drawing.Size(100, 62)
        Me.sendrecvTestBTN.TabIndex = 10
        Me.sendrecvTestBTN.Text = "Blocking Send/Recv Test"
        Me.sendrecvTestBTN.UseVisualStyleBackColor = True
        '
        'Terminal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1045, 467)
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
        Me.Margin = New System.Windows.Forms.Padding(4)
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
