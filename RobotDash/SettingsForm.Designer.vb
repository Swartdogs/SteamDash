﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SettingsForm
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
      Me.components = New System.ComponentModel.Container()
      Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SettingsForm))
      Me.Label1 = New System.Windows.Forms.Label()
      Me.GridFuel = New System.Windows.Forms.DataGridView()
      Me.ColIndex = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.colDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.colValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.TimerError = New System.Windows.Forms.Timer(Me.components)
      Me.ButtonSend = New System.Windows.Forms.Button()
      Me.ButtonCancel = New System.Windows.Forms.Button()
      Me.ButtonLog = New System.Windows.Forms.Button()
      CType(Me.GridFuel,System.ComponentModel.ISupportInitialize).BeginInit
      Me.SuspendLayout
      '
      'Label1
      '
      Me.Label1.BackColor = System.Drawing.Color.Aqua
      Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.Label1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
      Me.Label1.ForeColor = System.Drawing.Color.Black
      Me.Label1.Location = New System.Drawing.Point(5, 5)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(312, 20)
      Me.Label1.TabIndex = 6
      Me.Label1.Text = "FUEL HANDLER"
      Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'GridFuel
      '
      Me.GridFuel.AllowUserToAddRows = false
      Me.GridFuel.AllowUserToDeleteRows = false
      Me.GridFuel.AllowUserToResizeColumns = false
      Me.GridFuel.AllowUserToResizeRows = false
      Me.GridFuel.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(215,Byte),Integer), CType(CType(215,Byte),Integer), CType(CType(215,Byte),Integer))
      Me.GridFuel.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
      DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
      DataGridViewCellStyle1.BackColor = System.Drawing.Color.Aqua
      DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
      DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
      DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
      Me.GridFuel.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
      Me.GridFuel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
      Me.GridFuel.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColIndex, Me.colDesc, Me.colValue})
      DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
      DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
      DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
      DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
      DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Window
      DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText
      DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
      Me.GridFuel.DefaultCellStyle = DataGridViewCellStyle4
      Me.GridFuel.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
      Me.GridFuel.EnableHeadersVisualStyles = false
      Me.GridFuel.Location = New System.Drawing.Point(5, 23)
      Me.GridFuel.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
      Me.GridFuel.MultiSelect = false
      Me.GridFuel.Name = "GridFuel"
      DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle5.BackColor = System.Drawing.Color.Aqua
      DataGridViewCellStyle5.Font = New System.Drawing.Font("Verdana", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
      DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
      DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
      Me.GridFuel.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
      Me.GridFuel.RowHeadersVisible = false
      Me.GridFuel.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
      Me.GridFuel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
      Me.GridFuel.Size = New System.Drawing.Size(312, 223)
      Me.GridFuel.TabIndex = 0
      '
      'ColIndex
      '
      Me.ColIndex.HeaderText = "Index"
      Me.ColIndex.Name = "ColIndex"
      Me.ColIndex.ReadOnly = true
      Me.ColIndex.Visible = false
      Me.ColIndex.Width = 10
      '
      'colDesc
      '
      Me.colDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
      DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightCyan
      DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightCyan
      Me.colDesc.DefaultCellStyle = DataGridViewCellStyle2
      Me.colDesc.HeaderText = "Description"
      Me.colDesc.Name = "colDesc"
      Me.colDesc.ReadOnly = true
      Me.colDesc.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
      Me.colDesc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
      Me.colDesc.Width = 200
      '
      'colValue
      '
      Me.colValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
      DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
      Me.colValue.DefaultCellStyle = DataGridViewCellStyle3
      Me.colValue.HeaderText = "Value"
      Me.colValue.Name = "colValue"
      Me.colValue.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
      Me.colValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
      Me.colValue.Width = 110
      '
      'TimerError
      '
      Me.TimerError.Interval = 10
      '
      'ButtonSend
      '
      Me.ButtonSend.Enabled = false
      Me.ButtonSend.Location = New System.Drawing.Point(48, 262)
      Me.ButtonSend.Name = "ButtonSend"
      Me.ButtonSend.Size = New System.Drawing.Size(110, 30)
      Me.ButtonSend.TabIndex = 1
      Me.ButtonSend.Text = "Save and Send"
      Me.ButtonSend.UseVisualStyleBackColor = true
      '
      'ButtonCancel
      '
      Me.ButtonCancel.Enabled = false
      Me.ButtonCancel.Location = New System.Drawing.Point(164, 262)
      Me.ButtonCancel.Name = "ButtonCancel"
      Me.ButtonCancel.Size = New System.Drawing.Size(110, 30)
      Me.ButtonCancel.TabIndex = 2
      Me.ButtonCancel.Text = "Cancel"
      Me.ButtonCancel.UseVisualStyleBackColor = true
      '
      'ButtonLog
      '
      Me.ButtonLog.Location = New System.Drawing.Point(106, 298)
      Me.ButtonLog.Name = "ButtonLog"
      Me.ButtonLog.Size = New System.Drawing.Size(110, 30)
      Me.ButtonLog.TabIndex = 7
      Me.ButtonLog.Text = "Data Log"
      Me.ButtonLog.UseVisualStyleBackColor = true
      '
      'SettingsForm
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(8!, 14!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(225,Byte),Integer), CType(CType(230,Byte),Integer), CType(CType(245,Byte),Integer))
      Me.ClientSize = New System.Drawing.Size(322, 337)
      Me.Controls.Add(Me.ButtonLog)
      Me.Controls.Add(Me.ButtonCancel)
      Me.Controls.Add(Me.ButtonSend)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.GridFuel)
      Me.Font = New System.Drawing.Font("Verdana", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
      Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
      Me.MaximizeBox = false
      Me.Name = "SettingsForm"
      Me.Text = "Dashboard: Robot Settings"
      CType(Me.GridFuel,System.ComponentModel.ISupportInitialize).EndInit
      Me.ResumeLayout(false)

End Sub

   Friend WithEvents Label1 As Label
   Friend WithEvents GridFuel As DataGridView
   Friend WithEvents TimerError As Timer
   Friend WithEvents ButtonSend As Button
   Friend WithEvents ButtonCancel As Button
   Friend WithEvents ColIndex As DataGridViewTextBoxColumn
   Friend WithEvents colDesc As DataGridViewTextBoxColumn
   Friend WithEvents colValue As DataGridViewTextBoxColumn
   Friend WithEvents ButtonLog As Button
End Class
