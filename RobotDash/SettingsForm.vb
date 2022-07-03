Public Class SettingsForm

   Private Structure CellError
      Public grid          As DataGridView
      Public columnIndex   As Integer
      Public rowIndex      As Integer
   End Structure

   Private c_cellError        As CellError
   Private c_formName         As String = "ROBOT SETTINGS"

   Private Sub BuildGrids()
      With GridFuel
         .RowCount = 9
         .Item(1, 0).Value = "Minimum Fuel Intake PWM"
         .Item(1, 1).Value = "Maximum Fuel Intake PWM"
         .Item(1, 2).Value = "Maximum Drive Speed"
         .Item(1, 3).Value = "Low Shooter Speed"
         .Item(1, 4).Value = "High Shooter Speed"
         .Item(1, 5).Value = "Gear In PWM"
         .Item(1, 6).Value = "Gear Out PWM"
         .Item(1, 7).Value = "Goat Direction"
         .Item(1, 8).Value = "Churner Speed"
      End With

      ShowSettings()
   End Sub

   Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
      ShowSettings()
      ButtonSend.Enabled = False
      ButtonCancel.Enabled = False
   End Sub

   Private Sub ButtonLog_Click(sender As Object, e As EventArgs) Handles ButtonLog.Click
      Static logEnabled As Boolean = False

      logEnabled = Not logEnabled

      If logEnabled Then ButtonLog.BackColor = Color.PaleGreen Else ButtonLog.BackColor = Color.FromArgb(225, 230, 245)

      DashButton(0, DBIndex.buttonLogData) = logEnabled
   End Sub

   Private Sub ButtonSend_Click(sender As Object, e As EventArgs) Handles ButtonSend.Click
      If m_dashValue(DVindex.setMinFuelIntake).revised Then DashValue(DVindex.setMinFuelIntake, False) = GridFuel.Item(2, 0).Value
      If m_dashValue(DVindex.setMaxFuelIntake).revised Then DashValue(DVindex.setMaxFuelIntake, False) = GridFuel.Item(2, 1).Value
      If m_dashValue(DVindex.setMaxDriveSpeed).revised Then DashValue(DVindex.setMaxDriveSpeed, False) = GridFuel.Item(2, 2).Value
      If m_dashValue(DVindex.setLowShooterSpeed).revised Then DashValue(DVindex.setLowShooterSpeed, False) = GridFuel.Item(2, 3).Value
      If m_dashValue(DVindex.setHighShooterSpeed).revised Then DashValue(DVindex.setHighShooterSpeed, False) = GridFuel.Item(2, 4).Value
      If m_dashValue(DVindex.setGearInSpeed).revised Then DashValue(DVindex.setGearInSpeed, False) = GridFuel.Item(2, 5).Value
      If m_dashValue(DVindex.setGearOutSpeed).revised Then DashValue(DVindex.setGearOutSpeed, False) = GridFuel.Item(2, 6).Value
      If m_dashValue(DVindex.setGoatDirection).revised Then DashValue(DVindex.setGoatDirection, False) = GridFuel.Item(2, 7).Value
      If m_dashValue(DVindex.setChurnerSpeed).revised Then DashValue(DVindex.setChurnerSpeed, False) = GridFuel.Item(2, 8).Value

      DashValue(-1, True) = 0
   End Sub

   Private Sub Grid_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles GridFuel.CellEndEdit
      Dim grid    As DataGridView = CType(sender, DataGridView)

      Dim count   As Integer = 0
      Dim found   As Integer
      Dim text    As String

      If grid.Item(e.ColumnIndex, e.RowIndex).Value Is Nothing
         text = "0"
      Else
         text = grid.Item(e.ColumnIndex, e.RowIndex).Value.ToString
      End If

      Do
         found = text.IndexOf(".")

         If found >= 0
            count += 1
            text = Mid(text, found + 2)
         Else
            Exit Do
         End If
      Loop

      If count > 1
         Dim result As DialogResult = MessageBox.Show(Me, "Multiple decimal points are not permitted", c_formName, _
                                                      MessageBoxButtons.OK, MessageBoxIcon.Information)

         With c_cellError
            .grid = grid
            .columnIndex = e.ColumnIndex
            .rowIndex = e.RowIndex
         End With
         TimerError.Start()

      Else
         Dim index      As Integer = grid.Item(0, e.RowIndex).Value
         Dim newValue   As Double = ConvertToDouble(grid.Item(e.ColumnIndex, e.RowIndex).Value)
         
         If m_dashValue(index).value <> newValue
            m_dashValue(index).revised = True
            grid.Item(e.ColumnIndex, e.RowIndex).Value = newValue
            grid.Item(e.ColumnIndex, e.RowIndex).Style.BackColor = m_colorPending   

            ButtonSend.Enabled = True
            ButtonCancel.Enabled = True
         End If
      End If
   End Sub

   Private Sub Grid_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles GridFuel.EditingControlShowing
      Dim grid    As DataGridView = CType(sender, DataGridView)

      If grid.CurrentCell.ColumnIndex = 1
         RemoveHandler e.Control.KeyPress, AddressOf GridTextBox_Keypress
         AddHandler e.Control.KeyPress, AddressOf GridTextBox_Keypress   
      End If
   End Sub

   Private Sub Grid_LostFocus(sender As Object, e As EventArgs) Handles GridFuel.LostFocus
      Dim grid    As DataGridView = CType(sender, DataGridView)
      grid.ClearSelection()
   End Sub

   Private Sub GridTextBox_Keypress(sender As Object, e As KeyPressEventArgs)
      e.KeyChar = TextBoxKeyPress(TextBoxType.Float, e.KeyChar)
   End Sub

   Private Sub SettingsForm_Closed(sender As Object, e As EventArgs) Handles Me.Closed
      m_settingsForm = Nothing
   End Sub

   Private Sub SettingsForm_Load(sender As Object, e As EventArgs) Handles Me.Load
      Me.Top = m_dashForm.Top + 60
      Me.Left = m_dashForm.Left + 20
      BuildGrids()
   End Sub

   Public Sub ShowSettings()
      Dim i    As Integer

      GridFuel.SuspendLayout()
         For i = 15 To 23
            GridFuel.Item(0, i - 15).Value = i
            GridFuel.Item(2, i - 15).Value = m_dashValue(i).value

            If m_dashValue(i).sentToHost
               GridFuel.Item(2, i - 15).Style.BackColor = Color.White
            Else
               GridFuel.Item(2, i - 15).Style.BackColor = m_colorPending
            End If
         Next
      GridFuel.ResumeLayout()
   End Sub

   Private Sub TimerError_Tick(sender As Object, e As EventArgs) Handles TimerError.Tick
      TimerError.Stop()
      With c_cellError
         .grid.CurrentCell = .grid.Item(.columnIndex, .rowIndex)
      End With
   End Sub

   Public Sub UpdateStatus()
      Dim i    As Integer

      GridFuel.SuspendLayout()
         For i = 15 To 23
            If Not m_dashValue(i).revised And m_dashValue(i).sentToHost
               GridFuel.Item(2, i - 15).Style.BackColor = Color.White
            Else
               GridFuel.Item(2, i - 15).Style.BackColor = m_colorPending
            End If
         Next
      GridFuel.ResumeLayout()
   End Sub

End Class