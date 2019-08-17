<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProcessWatcherTester
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
        Me.notepadCBX = New System.Windows.Forms.CheckBox()
        Me.paintCBX = New System.Windows.Forms.CheckBox()
        Me.procwatcherLBL = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'notepadCBX
        '
        Me.notepadCBX.AutoSize = True
        Me.notepadCBX.Location = New System.Drawing.Point(230, 73)
        Me.notepadCBX.Name = "notepadCBX"
        Me.notepadCBX.Size = New System.Drawing.Size(84, 21)
        Me.notepadCBX.TabIndex = 0
        Me.notepadCBX.Text = "Notepad"
        Me.notepadCBX.UseVisualStyleBackColor = True
        '
        'paintCBX
        '
        Me.paintCBX.AutoSize = True
        Me.paintCBX.Location = New System.Drawing.Point(330, 73)
        Me.paintCBX.Name = "paintCBX"
        Me.paintCBX.Size = New System.Drawing.Size(62, 21)
        Me.paintCBX.TabIndex = 1
        Me.paintCBX.Text = "Paint"
        Me.paintCBX.UseVisualStyleBackColor = True
        '
        'procwatcherLBL
        '
        Me.procwatcherLBL.AutoSize = True
        Me.procwatcherLBL.Location = New System.Drawing.Point(12, 9)
        Me.procwatcherLBL.Name = "procwatcherLBL"
        Me.procwatcherLBL.Size = New System.Drawing.Size(623, 34)
        Me.procwatcherLBL.TabIndex = 2
        Me.procwatcherLBL.Text = "This dialog tests process watcher. While the following boxes are checked (and thi" &
    "s window open), " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "you'll receive a notification whenver the programs start."
        '
        'ProcessWatcherTester
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(668, 136)
        Me.Controls.Add(Me.procwatcherLBL)
        Me.Controls.Add(Me.paintCBX)
        Me.Controls.Add(Me.notepadCBX)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "ProcessWatcherTester"
        Me.Text = "ProcessWatcherTester"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents notepadCBX As CheckBox
    Friend WithEvents paintCBX As CheckBox
    Friend WithEvents procwatcherLBL As Label
End Class
