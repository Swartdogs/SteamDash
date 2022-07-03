Imports System.ComponentModel

Public Class DashForm

   Public Enum LinkStatus
      None = 0
      Connecting = 1
      NoAddress = 2
      Connected = 3
   End Enum

   Private c_formName      As String = "Dashboard"
   Private c_ignoreEvents  As Boolean = False

   Private Delegate Sub ClientStatusCallback(status As LinkStatus)
   Private Delegate Sub FinishCountCallback(mode As Integer, robotCount As Integer, dashCount As Integer, dashButtonCount As Integer)
   Private Delegate Sub FinishGetCallback(mode As Integer)
   Private Delegate Sub FinishPutCallback(buttonAck As Boolean, valueAck As Boolean)

   Private Sub BuildDataGrid()
      GridRobot.Font = New Font("Verdana", 11)

      With GridRobot
         .RowCount = 11
         .Item(1, 0).Value = "Drive: Mode"
         .Item(1, 1).Value = "          Gyro"
         .Item(1, 2).Value = "          Drive Encoder Left"
         .Item(1, 3).Value = "          Drive Encoder Right"
         .Item(1, 4).Value = "Fuel:   Intake Speed"
         .Item(1, 5).Value = "          Lower Shooter Speed"
         .Item(1, 6).Value = "          Upper Shooter Speed"
         .Item(1, 7).Value = "          Legs Down"
         .Item(1, 8).Value = "Gear:  In Pickup"
         .Item(1, 9).Value = "          Air Vent"
         .Item(1, 10).Value = "Goat:  Motor Amps"
      End With

      ShowData()

      c_ignoreEvents = True
         ListAuto.SelectedIndex = m_dashValue(DVindex.autoSelect).value
         If Not m_dashValue(DVindex.autoSelect).sentToHost
            ListAuto.BackColor = m_colorPending
         End If

         ListDelay.SelectedIndex = m_dashValue(DVindex.autoDelay).value
         If Not m_dashValue(DVindex.autoDelay).sentToHost
            ListDelay.BackColor = m_colorPending
         End If
      c_ignoreEvents = False
   End Sub

   Private Sub ButtonGyro_MouseDown(sender As Object, e As MouseEventArgs) 
      If m_robotValue(RVindex.calibrateGyro) = 0 Then DashButton(0, DBIndex.buttonGyro) = True
   End Sub

   Private Sub ButtonGyro_MouseUp(sender As Object, e As MouseEventArgs) 
      DashButton(0, DBIndex.buttonGyro) = False
   End Sub

   Private Sub ClientStatus(status As LinkStatus)
      If status = LinkStatus.Connected 
         LedRobot.BackColor = Color.PaleGreen
         LabelStatus.BackColor = Color.FromArgb(252, 252, 252)         
      Else
         LedRobot.BackColor = Color.WhiteSmoke
         LabelStatus.BackColor = Color.Yellow
      End If

      Select status
         Case LinkStatus.Connecting
            LabelStatus.Text = "Connecting..."
         Case LinkStatus.NoAddress
            LabelStatus.Text = "No IP Address"
         Case Else
            LabelStatus.Text = ""
      End Select
   End Sub

   Private Sub DashForm_Closed(sender As Object, e As EventArgs) Handles Me.Closed
      m_dashForm = Nothing
   End Sub

   Private Sub DashForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
      SaveDashValues()
      StopClient()
      m_tcpClient = Nothing
   End Sub

   Private Sub DashForm_Load(sender As Object, e As EventArgs) Handles Me.Load
      m_dashForm = Me

      Me.Top = Screen.GetBounds(Me).Top + 5
      Me.Left = Screen.GetBounds(Me).Left + (Screen.GetBounds(Me).Width - Me.Width) / 2

      m_imageDone = Image.FromFile(Application.StartupPath & "\Resources\Done.png")
      m_imagePending = Image.FromFile(Application.StartupPath & "\Resources\Pending.png")

      LoadOptions()
      LoadDashValues()
      StartClient()
      BuildDataGrid()
   End Sub

   Private Sub DashForm_Resize(sender As Object, e As EventArgs) Handles Me.Resize
      Static myWindowState As FormWindowState = FormWindowState.Normal

      If myWindowState <> Me.WindowState
         myWindowState = Me.WindowState
         SetAppWindowState(myWindowState)
      End If
   End Sub

   Private Function DriveMode(mode As Integer) As String
      Select mode
         Case 0:     Return "Drive-Rotate"
         Case 1:     Return "Drive-Strafe"
         Case 2:     Return "Strafe"
         Case 3:     Return "Joystick"
         Case 4:     Return "Auto Rotate"
         Case 5:     Return "Auto Drive"
         Case 6:     Return "Auto Strafe"
         Case 7:     Return "Auto Done"
         Case 8:     Return "Gear Place"
         Case Else:  Return "?"  
      End Select
   End Function

   Private Sub FileExit_Click(sender As Object, e As EventArgs) Handles FileExit.Click
      Me.Close()
   End Sub

   Private Sub FinishCount(mode As Integer, robotCount As Integer, dashCount As Integer, dashButtonCount As Integer)
      m_robotCount = robotCount
      ReDim m_robotValue(m_robotCount)

      If m_robotMode <> mode
         m_robotMode = mode
         LabelStatus.Text = RobotModeCaption(mode)
         'ButtonGyro.Enabled = (m_robotMode = 1 And m_robotCount > 0)
      End If

      If dashCount <> m_dashOptions.dashCount Or dashButtonCount <> m_dashOptions.dashButtonCount
         Dim result As DialogResult = MessageBox.Show(Me, "CAUTION:  The Dashboard and Robot data configurations are inconsistent. " & vbCrLf & vbCrLf & _
                                                      "DASHBOARD: Data Values=" & m_dashOptions.dashCount.ToString & "   Button Groups=" &  _
                                                      m_dashOptions.dashButtonCount & vbCrLf & "           ROBOT: Data Values=" & dashCount.ToString & _
                                                      "   Button Groups=" & dashButtonCount.ToString, c_formName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
      End If

      If m_dataForm IsNot Nothing Then m_dataForm.BuildGrids(True)
   End Sub

   Private Sub FinishGet(mode As Integer)
      If m_robotMode <> mode
         m_robotMode = mode
         LabelStatus.Text = RobotModeCaption(mode)
         'ButtonGyro.Enabled = (m_robotMode = 1 And m_robotCount > 0)
      End If

      ShowData()
      If m_dataForm IsNot Nothing Then m_dataForm.ShowData(DataForm.DataGroup.RobotValue)
      If m_tunePIDForm IsNot Nothing Then m_tunePIDForm.UpdateStatus(TunePidForm.DataGroup.RobotValue)
   End Sub

   Private Sub FinishPut(buttonAck As Boolean, valueAck As Boolean)
      If buttonAck
         If m_dataForm IsNot Nothing Then m_dataForm.ShowData(DataForm.DataGroup.DashButton)
      End If

      If valueAck
         UpdateStatus()
         If m_dataForm IsNot Nothing Then m_dataForm.ShowData(DataForm.DataGroup.DashValue)
         If m_settingsForm IsNot Nothing Then m_settingsForm.UpdateStatus()
         If m_tunePIDForm IsNot Nothing Then m_tunePIDForm.UpdateStatus(TunePidForm.DataGroup.DashValue)
      End If
   End Sub

   Public Function FuelLegState(state As Integer)
      Select state
         Case 0:     Return "None"
         Case 1:     Return "Left"
         Case 2:     Return "Right"
         Case 3:     Return "All"
         Case Else:  Return "?" 
      End Select
   End Function

   Public Sub InvokeClientStatus(status As LinkStatus)
      Me.Invoke(New ClientStatusCallback(AddressOf ClientStatus), New Object () {status})
   End Sub

   Public Sub InvokeFinishCount(mode As Integer, robotCount As Integer, dashCount As Integer, dashButtonCount As Integer)
      Me.Invoke(New FinishCountCallback(AddressOf FinishCount), New Object () {mode, robotCount, dashCount, dashButtonCount})
   End Sub

   Public Sub InvokeFinshGet(mode As Integer)
      Me.Invoke(New FinishGetCallback(AddressOf FinishGet), New Object () {mode})
   End Sub

   Public Sub InvokeFinishPut(buttonAck As Boolean, valueAck As Boolean)
      Me.Invoke(New FinishPutCallback(AddressOf FinishPut), New Object () {buttonAck, valueAck})
   End Sub

   Private Sub ListAuto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListAuto.SelectedIndexChanged
      If Not c_ignoreEvents
         m_dashValue(DVindex.autoSelect).revised = True
         ListAuto.BackColor = m_colorPending
         DashValue(DVindex.autoSelect, True) = CDbl(ListAuto.SelectedIndex)
      End If
   End Sub

   Private Sub ListDelay_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListDelay.SelectedIndexChanged
      If Not c_ignoreEvents
         m_dashValue(DVindex.autoDelay).revised = True
         ListDelay.BackColor = m_colorPending
         DashValue(DVindex.autoDelay, True) =  CDbl(ListDelay.SelectedIndex)
      End If
   End Sub

   Private Sub ShowData()
      Static calibrate  As Boolean = False
      Static hasGear    As Boolean = False
      Static liftAlign  As Boolean = False

      If m_robotCount > 0
         If GetRobotValue(RVindex.calibrateGyro) = 1
            LabelStatus.Text = "Calibrate Gyro"
            calibrate = True
         ElseIf calibrate
            LabelStatus.Text = RobotModeCaption(m_robotMode)
            calibrate = false
         End If

         With GridRobot
            .Item(2, 0).Value = DriveMode(GetRobotValue(RVindex.driveMode))
            .Item(2, 1).Value = GetRobotValue(RVindex.driveGyro).ToString("0.00")
            .Item(2, 2).Value = (GetRobotValue(RVindex.driveEncoderL) / 10).ToString("0.0")
            .Item(2, 3).Value = (GetRobotValue(RVindex.driveEncoderR) / 10).ToString("0.0")
            .Item(2, 4).Value = (GetRobotValue(RVindex.fuelIntake) * 100).ToString("0") & " %"
            .Item(2, 5).Value = Math.Abs(GetRobotValue(RVindex.lowerShooter)).ToString("0")
            .Item(2, 6).Value = Math.Abs(GetRobotValue(RVindex.upperShooter)).ToString("0")
            .Item(2, 7).Value = FuelLegState(GetRobotValue(RVindex.fuelLegs))
            .Item(2, 10).Value = GetRobotValue(RVindex.goatAmps).ToString("0.0")

            If GetRobotValue(RVindex.gearSensor) > 0
               .Item(2, 8).Value = "YES"
               .Item(2, 8).Style.BackColor = Color.SpringGreen

               If Not hasGear
                  hasGear = True
                  My.Computer.Audio.Play(Application.StartupPath & "\Resources\GotGear.wav", AudioPlayMode.Background)
               End If
            Else
               .Item(2, 8).Value = "NO"
               .Item(2, 8).Style.BackColor = Color.White
               hasGear = False
            End If

            If GetRobotValue(RVindex.airVent) > 0
               .Item(2, 9).Value = "OPEN"
               .Item(2, 9).Style.BackColor = Color.Salmon
            Else
               .Item(2, 9).Value = "CLOSED"
               .Item(2, 9).Style.BackColor = Color.White
            End If
         End With

         If GetRobotValue(RVindex.liftAlign) > 0
            If Not liftAlign
               liftAlign = True
               My.Computer.Audio.Play(Application.StartupPath & "\Resources\LiftAlign.wav", AudioPlayMode.Background)
            End If
         Else
            liftAlign = False
         End If
      End If
   End Sub

   Private Sub UpdateStatus()
      If Not m_dashValue(DVindex.autoSelect).revised And m_dashValue(DVindex.autoSelect).sentToHost Then ListAuto.BackColor = Color.White
      If Not m_dashValue(DVindex.autoDelay).revised And m_dashValue(DVindex.autoDelay).sentToHost Then ListDelay.BackColor = Color.White
   End Sub

   Private Sub ViewData_Click(sender As Object, e As EventArgs) Handles ViewData.Click
      If m_dataForm Is Nothing
         m_dataForm = New DataForm
         m_dataForm.Show()
      ElseIf m_dataForm.WindowState = FormWindowState.Minimized
         m_dataForm.WindowState = FormWindowState.Normal
      Else
         m_dataForm.Activate()
      End If
   End Sub

   Private Sub ViewOptions_Click(sender As Object, e As EventArgs) Handles ViewOptions.Click
      If m_optionsForm Is Nothing
         m_optionsForm = New OptionsForm
         m_optionsForm.Show()
      ElseIf m_optionsForm.WindowState = FormWindowState.Minimized
         m_optionsForm.WindowState = FormWindowState.Normal
      Else
         m_optionsForm.Activate()
      End If
   End Sub

   Private Sub ViewSettings_Click(sender As Object, e As EventArgs) Handles ViewSettings.Click
      If m_settingsForm Is Nothing
         m_settingsForm = New SettingsForm
         m_settingsForm.Show()
      ElseIf m_settingsForm.WindowState = FormWindowState.Minimized
         m_settingsForm.WindowState = FormWindowState.Normal
      Else
         m_settingsForm.Activate()
      End If
   End Sub

   Private Sub ViewTraffic_Click(sender As Object, e As EventArgs) Handles ViewTraffic.Click 
      If m_hostTrafficForm Is Nothing
         m_hostTrafficForm = New HostTrafficForm
         m_hostTrafficForm.Show()
      ElseIf m_hostTrafficForm.WindowState = FormWindowState.Minimized
         m_hostTrafficForm.WindowState = FormWindowState.Normal
      Else
         m_hostTrafficForm.Activate()
      End If
   End Sub

   Private Sub ViewTune_Click(sender As Object, e As EventArgs) Handles ViewTune.Click
      If m_tunePIDForm Is Nothing
         m_tunePIDForm = New TunePidForm
         m_tunePIDForm.Show()
      ElseIf m_tunePIDForm.WindowState = FormWindowState.Minimized
         m_tunePIDForm.WindowState = FormWindowState.Normal
      Else
         m_tunePIDForm.Activate()
      End If
   End Sub

End Class
