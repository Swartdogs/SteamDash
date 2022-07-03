<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OptionsForm
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OptionsForm))
      Me.LabelRevised = New System.Windows.Forms.Label()
      Me.PanelRobot = New System.Windows.Forms.Panel()
      Me.TextPort = New System.Windows.Forms.TextBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.TextAddress = New System.Windows.Forms.TextBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.PanelDash = New System.Windows.Forms.Panel()
      Me.TextButtons = New System.Windows.Forms.TextBox()
      Me.TextValues = New System.Windows.Forms.TextBox()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.ButtonCancel = New System.Windows.Forms.Button()
      Me.ButtonSave = New System.Windows.Forms.Button()
      Me.PanelRobot.SuspendLayout
      Me.PanelDash.SuspendLayout
      Me.SuspendLayout
      '
      'LabelRevised
      '
      Me.LabelRevised.Font = New System.Drawing.Font("Verdana", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
      Me.LabelRevised.ForeColor = System.Drawing.Color.Red
      Me.LabelRevised.Location = New System.Drawing.Point(215, 0)
      Me.LabelRevised.Name = "LabelRevised"
      Me.LabelRevised.Size = New System.Drawing.Size(78, 14)
      Me.LabelRevised.TabIndex = 1
      Me.LabelRevised.Text = "Revised"
      Me.LabelRevised.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      Me.LabelRevised.Visible = false
      '
      'PanelRobot
      '
      Me.PanelRobot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.PanelRobot.Controls.Add(Me.TextPort)
      Me.PanelRobot.Controls.Add(Me.Label3)
      Me.PanelRobot.Controls.Add(Me.TextAddress)
      Me.PanelRobot.Controls.Add(Me.Label2)
      Me.PanelRobot.Location = New System.Drawing.Point(10, 20)
      Me.PanelRobot.Name = "PanelRobot"
      Me.PanelRobot.Size = New System.Drawing.Size(275, 82)
      Me.PanelRobot.TabIndex = 0
      '
      'TextPort
      '
      Me.TextPort.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
      Me.TextPort.Location = New System.Drawing.Point(97, 45)
      Me.TextPort.Name = "TextPort"
      Me.TextPort.Size = New System.Drawing.Size(115, 23)
      Me.TextPort.TabIndex = 1
      Me.TextPort.Tag = "1"
      Me.TextPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'Label3
      '
      Me.Label3.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
      Me.Label3.Location = New System.Drawing.Point(10, 50)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(85, 20)
      Me.Label3.TabIndex = 7
      Me.Label3.Text = "Host Port..."
      '
      'TextAddress
      '
      Me.TextAddress.BackColor = System.Drawing.SystemColors.Window
      Me.TextAddress.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
      Me.TextAddress.Location = New System.Drawing.Point(97, 10)
      Me.TextAddress.Name = "TextAddress"
      Me.TextAddress.Size = New System.Drawing.Size(165, 23)
      Me.TextAddress.TabIndex = 0
      Me.TextAddress.Tag = "0"
      Me.TextAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'Label2
      '
      Me.Label2.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
      Me.Label2.Location = New System.Drawing.Point(10, 15)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(85, 20)
      Me.Label2.TabIndex = 5
      Me.Label2.Text = "Host IP......"
      '
      'PanelDash
      '
      Me.PanelDash.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.PanelDash.Controls.Add(Me.TextButtons)
      Me.PanelDash.Controls.Add(Me.TextValues)
      Me.PanelDash.Controls.Add(Me.Label5)
      Me.PanelDash.Controls.Add(Me.Label6)
      Me.PanelDash.Location = New System.Drawing.Point(10, 125)
      Me.PanelDash.Name = "PanelDash"
      Me.PanelDash.Size = New System.Drawing.Size(275, 82)
      Me.PanelDash.TabIndex = 1
      '
      'TextButtons
      '
      Me.TextButtons.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
      Me.TextButtons.Location = New System.Drawing.Point(134, 45)
      Me.TextButtons.Name = "TextButtons"
      Me.TextButtons.Size = New System.Drawing.Size(78, 23)
      Me.TextButtons.TabIndex = 1
      Me.TextButtons.Tag = "3"
      Me.TextButtons.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'TextValues
      '
      Me.TextValues.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
      Me.TextValues.Location = New System.Drawing.Point(134, 10)
      Me.TextValues.Name = "TextValues"
      Me.TextValues.Size = New System.Drawing.Size(78, 23)
      Me.TextValues.TabIndex = 0
      Me.TextValues.Tag = "2"
      Me.TextValues.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'Label5
      '
      Me.Label5.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
      Me.Label5.Location = New System.Drawing.Point(10, 50)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(118, 20)
      Me.Label5.TabIndex = 9
      Me.Label5.Text = "Button Groups..."
      '
      'Label6
      '
      Me.Label6.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
      Me.Label6.Location = New System.Drawing.Point(10, 15)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(118, 20)
      Me.Label6.TabIndex = 8
      Me.Label6.Text = "Data Values......"
      '
      'Label1
      '
      Me.Label1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
      Me.Label1.Location = New System.Drawing.Point(21, 10)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(48, 20)
      Me.Label1.TabIndex = 4
      Me.Label1.Text = "Robot"
      '
      'Label4
      '
      Me.Label4.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
      Me.Label4.Location = New System.Drawing.Point(21, 115)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(78, 20)
      Me.Label4.TabIndex = 5
      Me.Label4.Text = "Dashboard"
      '
      'ButtonCancel
      '
      Me.ButtonCancel.Enabled = false
      Me.ButtonCancel.Location = New System.Drawing.Point(150, 225)
      Me.ButtonCancel.Name = "ButtonCancel"
      Me.ButtonCancel.Size = New System.Drawing.Size(78, 30)
      Me.ButtonCancel.TabIndex = 3
      Me.ButtonCancel.Text = "Cancel"
      Me.ButtonCancel.UseVisualStyleBackColor = true
      '
      'ButtonSave
      '
      Me.ButtonSave.Enabled = false
      Me.ButtonSave.Location = New System.Drawing.Point(70, 225)
      Me.ButtonSave.Name = "ButtonSave"
      Me.ButtonSave.Size = New System.Drawing.Size(78, 30)
      Me.ButtonSave.TabIndex = 2
      Me.ButtonSave.Text = "Save"
      Me.ButtonSave.UseVisualStyleBackColor = true
      '
      'OptionsForm
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(8!, 14!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(225,Byte),Integer), CType(CType(230,Byte),Integer), CType(CType(245,Byte),Integer))
      Me.ClientSize = New System.Drawing.Size(296, 270)
      Me.Controls.Add(Me.ButtonCancel)
      Me.Controls.Add(Me.ButtonSave)
      Me.Controls.Add(Me.Label4)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.PanelDash)
      Me.Controls.Add(Me.PanelRobot)
      Me.Controls.Add(Me.LabelRevised)
      Me.Font = New System.Drawing.Font("Verdana", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
      Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
      Me.MaximizeBox = false
      Me.Name = "OptionsForm"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
      Me.Text = "Dashboard: Options"
      Me.PanelRobot.ResumeLayout(false)
      Me.PanelRobot.PerformLayout
      Me.PanelDash.ResumeLayout(false)
      Me.PanelDash.PerformLayout
      Me.ResumeLayout(false)

End Sub

   Friend WithEvents LabelRevised As Label
   Friend WithEvents PanelRobot As Panel
   Friend WithEvents TextPort As TextBox
   Friend WithEvents Label3 As Label
   Friend WithEvents TextAddress As TextBox
   Friend WithEvents Label2 As Label
   Friend WithEvents PanelDash As Panel
   Friend WithEvents TextButtons As TextBox
   Friend WithEvents TextValues As TextBox
   Friend WithEvents Label5 As Label
   Friend WithEvents Label6 As Label
   Friend WithEvents Label1 As Label
   Friend WithEvents Label4 As Label
   Friend WithEvents ButtonCancel As Button
   Friend WithEvents ButtonSave As Button
End Class
