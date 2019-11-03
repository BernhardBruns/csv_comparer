<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits MetroFramework.Forms.MetroForm

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.tbValue = New MetroFramework.Controls.MetroTrackBar()
        Me.btnCompare = New MetroFramework.Controls.MetroButton()
        Me.btnCSV1 = New MetroFramework.Controls.MetroButton()
        Me.btnCSV2 = New MetroFramework.Controls.MetroButton()
        Me.MetroToolTip1 = New MetroFramework.Components.MetroToolTip()
        Me.cboCSV1 = New MetroFramework.Controls.MetroComboBox()
        Me.cboCSV2 = New MetroFramework.Controls.MetroComboBox()
        Me.mpWaiting = New MetroFramework.Controls.MetroPanel()
        Me.MetroLabel1 = New MetroFramework.Controls.MetroLabel()
        Me.MetroProgressBar1 = New MetroFramework.Controls.MetroProgressBar()
        Me.mpWaiting.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbValue
        '
        Me.tbValue.BackColor = System.Drawing.Color.Transparent
        Me.tbValue.Location = New System.Drawing.Point(23, 176)
        Me.tbValue.Maximum = 10
        Me.tbValue.Name = "tbValue"
        Me.tbValue.Size = New System.Drawing.Size(393, 23)
        Me.tbValue.TabIndex = 3
        Me.tbValue.Text = "MetroTrackBar1"
        Me.MetroToolTip1.SetToolTip(Me.tbValue, "similarity")
        Me.tbValue.Value = 5
        '
        'btnCompare
        '
        Me.btnCompare.FontSize = MetroFramework.MetroButtonSize.Medium
        Me.btnCompare.Location = New System.Drawing.Point(23, 219)
        Me.btnCompare.Name = "btnCompare"
        Me.btnCompare.Size = New System.Drawing.Size(393, 38)
        Me.btnCompare.TabIndex = 4
        Me.btnCompare.Text = "Compare and Merge"
        Me.btnCompare.UseSelectable = True
        '
        'btnCSV1
        '
        Me.btnCSV1.FontSize = MetroFramework.MetroButtonSize.Medium
        Me.btnCSV1.Location = New System.Drawing.Point(23, 77)
        Me.btnCSV1.Name = "btnCSV1"
        Me.btnCSV1.Size = New System.Drawing.Size(157, 30)
        Me.btnCSV1.TabIndex = 5
        Me.btnCSV1.Text = "CSV 1"
        Me.btnCSV1.UseSelectable = True
        '
        'btnCSV2
        '
        Me.btnCSV2.FontSize = MetroFramework.MetroButtonSize.Medium
        Me.btnCSV2.Location = New System.Drawing.Point(23, 122)
        Me.btnCSV2.Name = "btnCSV2"
        Me.btnCSV2.Size = New System.Drawing.Size(157, 30)
        Me.btnCSV2.TabIndex = 6
        Me.btnCSV2.Text = "CSV 2"
        Me.btnCSV2.UseSelectable = True
        '
        'MetroToolTip1
        '
        Me.MetroToolTip1.Style = MetroFramework.MetroColorStyle.Blue
        Me.MetroToolTip1.StyleManager = Nothing
        Me.MetroToolTip1.Theme = MetroFramework.MetroThemeStyle.Light
        '
        'cboCSV1
        '
        Me.cboCSV1.FormattingEnabled = True
        Me.cboCSV1.ItemHeight = 24
        Me.cboCSV1.Items.AddRange(New Object() {"Choose a CSV 1"})
        Me.cboCSV1.Location = New System.Drawing.Point(186, 77)
        Me.cboCSV1.Name = "cboCSV1"
        Me.cboCSV1.Size = New System.Drawing.Size(230, 30)
        Me.cboCSV1.TabIndex = 7
        Me.cboCSV1.UseSelectable = True
        '
        'cboCSV2
        '
        Me.cboCSV2.FormattingEnabled = True
        Me.cboCSV2.ItemHeight = 24
        Me.cboCSV2.Items.AddRange(New Object() {"Choose a CSV 2"})
        Me.cboCSV2.Location = New System.Drawing.Point(186, 122)
        Me.cboCSV2.Name = "cboCSV2"
        Me.cboCSV2.Size = New System.Drawing.Size(230, 30)
        Me.cboCSV2.TabIndex = 8
        Me.cboCSV2.UseSelectable = True
        '
        'mpWaiting
        '
        Me.mpWaiting.Controls.Add(Me.MetroLabel1)
        Me.mpWaiting.Controls.Add(Me.MetroProgressBar1)
        Me.mpWaiting.HorizontalScrollbarBarColor = True
        Me.mpWaiting.HorizontalScrollbarHighlightOnWheel = False
        Me.mpWaiting.HorizontalScrollbarSize = 10
        Me.mpWaiting.Location = New System.Drawing.Point(12, 63)
        Me.mpWaiting.Name = "mpWaiting"
        Me.mpWaiting.Size = New System.Drawing.Size(409, 150)
        Me.mpWaiting.TabIndex = 9
        Me.mpWaiting.VerticalScrollbarBarColor = True
        Me.mpWaiting.VerticalScrollbarHighlightOnWheel = False
        Me.mpWaiting.VerticalScrollbarSize = 10
        Me.mpWaiting.Visible = False
        '
        'MetroLabel1
        '
        Me.MetroLabel1.AutoSize = True
        Me.MetroLabel1.Location = New System.Drawing.Point(119, 36)
        Me.MetroLabel1.Name = "MetroLabel1"
        Me.MetroLabel1.Size = New System.Drawing.Size(165, 20)
        Me.MetroLabel1.TabIndex = 3
        Me.MetroLabel1.Text = "I´m working, please wait..."
        '
        'MetroProgressBar1
        '
        Me.MetroProgressBar1.Location = New System.Drawing.Point(11, 64)
        Me.MetroProgressBar1.Name = "MetroProgressBar1"
        Me.MetroProgressBar1.Size = New System.Drawing.Size(393, 38)
        Me.MetroProgressBar1.TabIndex = 2
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(444, 289)
        Me.Controls.Add(Me.mpWaiting)
        Me.Controls.Add(Me.cboCSV2)
        Me.Controls.Add(Me.cboCSV1)
        Me.Controls.Add(Me.btnCSV2)
        Me.Controls.Add(Me.btnCSV1)
        Me.Controls.Add(Me.btnCompare)
        Me.Controls.Add(Me.tbValue)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMain"
        Me.Resizable = False
        Me.Text = "CSV String Comparer"
        Me.mpWaiting.ResumeLayout(False)
        Me.mpWaiting.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tbValue As MetroFramework.Controls.MetroTrackBar
    Friend WithEvents btnCompare As MetroFramework.Controls.MetroButton
    Friend WithEvents btnCSV1 As MetroFramework.Controls.MetroButton
    Friend WithEvents btnCSV2 As MetroFramework.Controls.MetroButton
    Friend WithEvents MetroToolTip1 As MetroFramework.Components.MetroToolTip
    Friend WithEvents cboCSV1 As MetroFramework.Controls.MetroComboBox
    Friend WithEvents cboCSV2 As MetroFramework.Controls.MetroComboBox
    Friend WithEvents mpWaiting As MetroFramework.Controls.MetroPanel
    Friend WithEvents MetroProgressBar1 As MetroFramework.Controls.MetroProgressBar
    Friend WithEvents MetroLabel1 As MetroFramework.Controls.MetroLabel
End Class
