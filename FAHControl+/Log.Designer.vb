<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Log
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
        Me.logDGV = New System.Windows.Forms.DataGridView()
        Me.timestamp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.component = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.message = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.logDGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'logDGV
        '
        Me.logDGV.AllowUserToAddRows = False
        Me.logDGV.AllowUserToDeleteRows = False
        Me.logDGV.AllowUserToOrderColumns = True
        Me.logDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.logDGV.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.timestamp, Me.component, Me.message})
        Me.logDGV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.logDGV.Location = New System.Drawing.Point(0, 0)
        Me.logDGV.Name = "logDGV"
        Me.logDGV.ReadOnly = True
        Me.logDGV.RowTemplate.Height = 24
        Me.logDGV.Size = New System.Drawing.Size(800, 450)
        Me.logDGV.TabIndex = 0
        '
        'timestamp
        '
        Me.timestamp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.timestamp.HeaderText = "Timestamp"
        Me.timestamp.Name = "timestamp"
        Me.timestamp.ReadOnly = True
        Me.timestamp.Width = 106
        '
        'component
        '
        Me.component.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.component.HeaderText = "Component"
        Me.component.Name = "component"
        Me.component.ReadOnly = True
        Me.component.Width = 109
        '
        'message
        '
        Me.message.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.message.HeaderText = "Message"
        Me.message.Name = "message"
        Me.message.ReadOnly = True
        Me.message.Width = 94
        '
        'Log
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.logDGV)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "Log"
        Me.Text = "Log Viewer"
        CType(Me.logDGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents timestamp As DataGridViewTextBoxColumn
    Friend WithEvents component As DataGridViewTextBoxColumn
    Friend WithEvents message As DataGridViewTextBoxColumn
    Private WithEvents logDGV As DataGridView
End Class
