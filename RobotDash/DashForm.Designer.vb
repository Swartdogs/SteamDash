<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DashForm
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
      Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DashForm))
      Me.DashMenu = New System.Windows.Forms.MenuStrip()
      Me.MenuFile = New System.Windows.Forms.ToolStripMenuItem()
      Me.FileExit = New System.Windows.Forms.ToolStripMenuItem()
      Me.MenuView = New System.Windows.Forms.ToolStripMenuItem()
      Me.ViewSettings = New System.Windows.Forms.ToolStripMenuItem()
      Me.ViewTune = New System.Windows.Forms.ToolStripMenuItem()
      Me.ViewSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.ViewData = New System.Windows.Forms.ToolStripMenuItem()
      Me.ViewTraffic = New System.Windows.Forms.ToolStripMenuItem()
      Me.ViewOptions = New System.Windows.Forms.ToolStripMenuItem()
      Me.LedRobot = New System.Windows.Forms.Label()
      Me.LabelStatus = New System.Windows.Forms.Label()
      Me.GridRobot = New System.Windows.Forms.DataGridView()
      Me.ColIndex = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.colDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.colValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.PanelAuto = New System.Windows.Forms.Panel()
      Me.ListDelay = New System.Windows.Forms.ComboBox()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.ListAuto = New System.Windows.Forms.ComboBox()
      Me.DashMenu.SuspendLayout
      CType(Me.GridRobot,System.ComponentModel.ISupportInitialize).BeginInit
      Me.PanelAuto.SuspendLayout
      Me.SuspendLayout
      '
      'DashMenu
      '
      Me.DashMenu.Font = New System.Drawing.Font("Verdana", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
      Me.DashMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuFile, Me.MenuView})
      Me.DashMenu.Location = New System.Drawing.Point(0, 0)
      Me.DashMenu.Name = "DashMenu"
      Me.DashMenu.Size = New System.Drawing.Size(383, 24)
      Me.DashMenu.TabIndex = 0
      Me.DashMenu.Text = "MenuStrip1"
      '
      'MenuFile
      '
      Me.MenuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileExit})
      Me.MenuFile.Name = "MenuFile"
      Me.MenuFile.Size = New System.Drawing.Size(40, 20)
      Me.MenuFile.Text = "File"
      '
      'FileExit
      '
      Me.FileExit.Name = "FileExit"
      Me.FileExit.Size = New System.Drawing.Size(97, 22)
      Me.FileExit.Text = "Exit"
      '
      'MenuView
      '
      Me.MenuView.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewSettings, Me.ViewTune, Me.ViewSeparator1, Me.ViewData, Me.ViewTraffic, Me.ViewOptions})
      Me.MenuView.Name = "MenuView"
      Me.MenuView.Size = New System.Drawing.Size(49, 20)
      Me.MenuView.Text = "View"
      '
      'ViewSettings
      '
      Me.ViewSettings.Name = "ViewSettings"
      Me.ViewSettings.Size = New System.Drawing.Size(167, 22)
      Me.ViewSettings.Text = "Robot Settings"
      '
      'ViewTune
      '
      Me.ViewTune.Name = "ViewTune"
      Me.ViewTune.Size = New System.Drawing.Size(167, 22)
      Me.ViewTune.Text = "Tune PID"
      '
      'ViewSeparator1
      '
      Me.ViewSeparator1.Name = "ViewSeparator1"
      Me.ViewSeparator1.Size = New System.Drawing.Size(164, 6)
      '
      'ViewData
      '
      Me.ViewData.Name = "ViewData"
      Me.ViewData.Size = New System.Drawing.Size(167, 22)
      Me.ViewData.Text = "Data Tables"
      '
      'ViewTraffic
      '
      Me.ViewTraffic.Name = "ViewTraffic"
      Me.ViewTraffic.Size = New System.Drawing.Size(167, 22)
      Me.ViewTraffic.Text = "Host Traffic"
      '
      'ViewOptions
      '
      Me.ViewOptions.Name = "ViewOptions"
      Me.ViewOptions.Size = New System.Drawing.Size(167, 22)
      Me.ViewOptions.Text = "Options"
      '
      'LedRobot
      '
      Me.LedRobot.BackColor = System.Drawing.Color.WhiteSmoke
      Me.LedRobot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.LedRobot.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
      Me.LedRobot.Location = New System.Drawing.Point(319, 0)
      Me.LedRobot.Name = "LedRobot"
      Me.LedRobot.Size = New System.Drawing.Size(58, 24)
      Me.LedRobot.TabIndex = 24
      Me.LedRobot.Text = "Robot"
      Me.LedRobot.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'LabelStatus
      '
      Me.LabelStatus.BackColor = System.Drawing.Color.FromArgb(CType(CType(252,Byte),Integer), CType(CType(252,Byte),Integer), CType(CType(252,Byte),Integer))
      Me.LabelStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.LabelStatus.ForeColor = System.Drawing.Color.Red
      Me.LabelStatus.Location = New System.Drawing.Point(193, 0)
      Me.LabelStatus.Name = "LabelStatus"
      Me.LabelStatus.Size = New System.Drawing.Size(121, 24)
      Me.LabelStatus.TabIndex = 25
      Me.LabelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'GridRobot
      '
      Me.GridRobot.AllowUserToAddRows = false
      Me.GridRobot.AllowUserToDeleteRows = false
      Me.GridRobot.AllowUserToResizeColumns = false
      Me.GridRobot.AllowUserToResizeRows = false
      Me.GridRobot.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(215,Byte),Integer), CType(CType(215,Byte),Integer), CType(CType(215,Byte),Integer))
      Me.GridRobot.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
      DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
      DataGridViewCellStyle1.BackColor = System.Drawing.Color.Aqua
      DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
      DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
      DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
      Me.GridRobot.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
      Me.GridRobot.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
      Me.GridRobot.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColIndex, Me.colDesc, Me.colValue})
      DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
      DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
      DataGridViewCellStyle5.Font = New System.Drawing.Font("Verdana", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
      DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
      DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Window
      DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText
      DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
      Me.GridRobot.DefaultCellStyle = DataGridViewCellStyle5
      Me.GridRobot.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
      Me.GridRobot.EnableHeadersVisualStyles = false
      Me.GridRobot.Location = New System.Drawing.Point(5, 123)
      Me.GridRobot.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
      Me.GridRobot.MultiSelect = false
      Me.GridRobot.Name = "GridRobot"
      Me.GridRobot.ReadOnly = true
      DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle6.BackColor = System.Drawing.Color.Aqua
      DataGridViewCellStyle6.Font = New System.Drawing.Font("Verdana", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
      DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
      DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
      Me.GridRobot.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
      Me.GridRobot.RowHeadersVisible = false
      Me.GridRobot.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
      Me.GridRobot.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
      Me.GridRobot.Size = New System.Drawing.Size(372, 267)
      Me.GridRobot.TabIndex = 1
      '
      'ColIndex
      '
      DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
      Me.ColIndex.DefaultCellStyle = DataGridViewCellStyle2
      Me.ColIndex.HeaderText = "Index"
      Me.ColIndex.Name = "ColIndex"
      Me.ColIndex.ReadOnly = true
      Me.ColIndex.Visible = false
      Me.ColIndex.Width = 10
      '
      'colDesc
      '
      Me.colDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
      DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle3.BackColor = System.Drawing.Color.LightCyan
      DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightCyan
      Me.colDesc.DefaultCellStyle = DataGridViewCellStyle3
      Me.colDesc.HeaderText = "Description"
      Me.colDesc.Name = "colDesc"
      Me.colDesc.ReadOnly = true
      Me.colDesc.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
      Me.colDesc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
      Me.colDesc.Width = 250
      '
      'colValue
      '
      Me.colValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
      DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
      Me.colValue.DefaultCellStyle = DataGridViewCellStyle4
      Me.colValue.HeaderText = "Value"
      Me.colValue.Name = "colValue"
      Me.colValue.ReadOnly = true
      Me.colValue.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
      Me.colValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
      Me.colValue.Width = 120
      '
      'Label1
      '
      Me.Label1.BackColor = System.Drawing.Color.Aqua
      Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.Label1.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
      Me.Label1.ForeColor = System.Drawing.Color.Black
      Me.Label1.Location = New System.Drawing.Point(5, 103)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(372, 22)
      Me.Label1.TabIndex = 30
      Me.Label1.Text = "ROBOT DATA"
      Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'Label2
      '
      Me.Label2.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
      Me.Label2.Location = New System.Drawing.Point(12, 28)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(90, 20)
      Me.Label2.TabIndex = 33
      Me.Label2.Text = "Autonomous"
      Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'PanelAuto
      '
      Me.PanelAuto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.PanelAuto.Controls.Add(Me.ListDelay)
      Me.PanelAuto.Controls.Add(Me.Label4)
      Me.PanelAuto.Controls.Add(Me.Label3)
      Me.PanelAuto.Controls.Add(Me.ListAuto)
      Me.PanelAuto.Location = New System.Drawing.Point(5, 38)
      Me.PanelAuto.Name = "PanelAuto"
      Me.PanelAuto.Size = New System.Drawing.Size(372, 60)
      Me.PanelAuto.TabIndex = 0
      '
      'ListDelay
      '
      Me.ListDelay.BackColor = System.Drawing.SystemColors.Window
      Me.ListDelay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.ListDelay.FlatStyle = System.Windows.Forms.FlatStyle.Flat
      Me.ListDelay.Font = New System.Drawing.Font("Verdana", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
      Me.ListDelay.FormattingEnabled = true
      Me.ListDelay.ImeMode = System.Windows.Forms.ImeMode.Hangul
      Me.ListDelay.Items.AddRange(New Object() {"None", "0.25", "0.50", "0.75", "1.00", "1.25", "1.50", "1.75", "2.00", "2.25", "2.50", "2.75", "3.00", "3.25", "3.50", "3.75", "4.00", ""})
      Me.ListDelay.Location = New System.Drawing.Point(287, 25)
      Me.ListDelay.Name = "ListDelay"
      Me.ListDelay.Size = New System.Drawing.Size(74, 26)
      Me.ListDelay.TabIndex = 1
      '
      'Label4
      '
      Me.Label4.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
      Me.Label4.Location = New System.Drawing.Point(301, 3)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(48, 20)
      Me.Label4.TabIndex = 35
      Me.Label4.Text = "Delay"
      Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'Label3
      '
      Me.Label3.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
      Me.Label3.Location = New System.Drawing.Point(102, 3)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(90, 20)
      Me.Label3.TabIndex = 34
      Me.Label3.Text = "Selection"
      Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'ListAuto
      '
      Me.ListAuto.BackColor = System.Drawing.SystemColors.Window
      Me.ListAuto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.ListAuto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
      Me.ListAuto.Font = New System.Drawing.Font("Verdana", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
      Me.ListAuto.FormattingEnabled = true
      Me.ListAuto.ImeMode = System.Windows.Forms.ImeMode.Hangul
      Me.ListAuto.Items.AddRange(New Object() {"None", "Hang Gear: Left", "Hang Gear: Center", "Hang Gear: Right", "Drive Only: Left", "Drive Only: Center", "Drive Only: Right", "Shoot and Drive: Red", "Shoot and Drive: Blue"})
      Me.ListAuto.Location = New System.Drawing.Point(9, 25)
      Me.ListAuto.Name = "ListAuto"
      Me.ListAuto.Size = New System.Drawing.Size(272, 26)
      Me.ListAuto.TabIndex = 0
      '
      'DashForm
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(8!, 14!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(225,Byte),Integer), CType(CType(230,Byte),Integer), CType(CType(245,Byte),Integer))
      Me.ClientSize = New System.Drawing.Size(383, 397)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.PanelAuto)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.GridRobot)
      Me.Controls.Add(Me.LabelStatus)
      Me.Controls.Add(Me.LedRobot)
      Me.Controls.Add(Me.DashMenu)
      Me.Font = New System.Drawing.Font("Verdana", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
      Me.MainMenuStrip = Me.DashMenu
      Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
      Me.MaximizeBox = false
      Me.Name = "DashForm"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Dashboard: 525"
      Me.DashMenu.ResumeLayout(false)
      Me.DashMenu.PerformLayout
      CType(Me.GridRobot,System.ComponentModel.ISupportInitialize).EndInit
      Me.PanelAuto.ResumeLayout(false)
      Me.ResumeLayout(false)
      Me.PerformLayout

End Sub

   Friend WithEvents DashMenu As MenuStrip
   Friend WithEvents MenuFile As ToolStripMenuItem
   Friend WithEvents FileExit As ToolStripMenuItem
   Friend WithEvents MenuView As ToolStripMenuItem
   Friend WithEvents ViewSettings As ToolStripMenuItem
   Friend WithEvents ViewTune As ToolStripMenuItem
   Friend WithEvents ViewSeparator1 As ToolStripSeparator
   Friend WithEvents ViewData As ToolStripMenuItem
   Friend WithEvents ViewOptions As ToolStripMenuItem
   Friend WithEvents LedRobot As Label
   Friend WithEvents LabelStatus As Label
   Friend WithEvents ViewTraffic As ToolStripMenuItem
   Friend WithEvents GridRobot As DataGridView
   Friend WithEvents Label1 As Label
   Friend WithEvents ColIndex As DataGridViewTextBoxColumn
   Friend WithEvents colDesc As DataGridViewTextBoxColumn
   Friend WithEvents colValue As DataGridViewTextBoxColumn
   Friend WithEvents Label2 As Label
   Friend WithEvents PanelAuto As Panel
   Friend WithEvents ListDelay As ComboBox
   Friend WithEvents Label4 As Label
   Friend WithEvents Label3 As Label
   Friend WithEvents ListAuto As ComboBox
End Class
