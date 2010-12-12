<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RolesAndDuties
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.mnuFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFileOpen = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFileExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.dlgOpen = New System.Windows.Forms.OpenFileDialog()
        Me.lstPlayers = New System.Windows.Forms.ListBox()
        Me.lblPosition = New System.Windows.Forms.Label()
        Me.tabDetails = New System.Windows.Forms.TabControl()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFile, Me.mnuHelp})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(995, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'mnuFile
        '
        Me.mnuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFileOpen, Me.ToolStripMenuItem2, Me.mnuFileExit})
        Me.mnuFile.Name = "mnuFile"
        Me.mnuFile.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.mnuFile.Size = New System.Drawing.Size(35, 20)
        Me.mnuFile.Text = "&File"
        '
        'mnuFileOpen
        '
        Me.mnuFileOpen.Name = "mnuFileOpen"
        Me.mnuFileOpen.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.mnuFileOpen.Size = New System.Drawing.Size(147, 22)
        Me.mnuFileOpen.Text = "&Open"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(147, 22)
        Me.ToolStripMenuItem2.Text = "-"
        '
        'mnuFileExit
        '
        Me.mnuFileExit.Name = "mnuFileExit"
        Me.mnuFileExit.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
        Me.mnuFileExit.Size = New System.Drawing.Size(147, 22)
        Me.mnuFileExit.Text = "E&xit"
        '
        'mnuHelp
        '
        Me.mnuHelp.Name = "mnuHelp"
        Me.mnuHelp.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.H), System.Windows.Forms.Keys)
        Me.mnuHelp.Size = New System.Drawing.Size(40, 20)
        Me.mnuHelp.Text = "&Help"
        '
        'dlgOpen
        '
        Me.dlgOpen.FileName = "OpenFileDialog1"
        Me.dlgOpen.Filter = "CSV (*.csv)|*.csv"
        '
        'lstPlayers
        '
        Me.lstPlayers.FormattingEnabled = True
        Me.lstPlayers.Location = New System.Drawing.Point(12, 27)
        Me.lstPlayers.Name = "lstPlayers"
        Me.lstPlayers.Size = New System.Drawing.Size(206, 420)
        Me.lstPlayers.TabIndex = 1
        '
        'lblPosition
        '
        Me.lblPosition.AutoSize = True
        Me.lblPosition.Location = New System.Drawing.Point(224, 27)
        Me.lblPosition.Name = "lblPosition"
        Me.lblPosition.Size = New System.Drawing.Size(44, 13)
        Me.lblPosition.TabIndex = 2
        Me.lblPosition.Text = "Position"
        '
        'tabDetails
        '
        Me.tabDetails.Location = New System.Drawing.Point(227, 43)
        Me.tabDetails.Name = "tabDetails"
        Me.tabDetails.SelectedIndex = 0
        Me.tabDetails.Size = New System.Drawing.Size(770, 404)
        Me.tabDetails.TabIndex = 0
        '
        'RolesAndDuties
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(995, 452)
        Me.Controls.Add(Me.tabDetails)
        Me.Controls.Add(Me.lblPosition)
        Me.Controls.Add(Me.lstPlayers)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "RolesAndDuties"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FM2010 - Player Roles And Duties"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents mnuFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuFileOpen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuFileExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuHelp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dlgOpen As System.Windows.Forms.OpenFileDialog
    Friend WithEvents lstPlayers As System.Windows.Forms.ListBox
    Friend WithEvents lblPosition As System.Windows.Forms.Label
    Friend WithEvents tabDetails As System.Windows.Forms.TabControl

End Class
