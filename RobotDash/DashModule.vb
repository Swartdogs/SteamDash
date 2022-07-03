Module DashModule

   Public Structure DashboardButton
      Dim value            As Long
      Dim sentToHost       As Boolean
   End Structure

   <Serializable> Public Structure DashboardValue
      Dim value            As Double
      Dim revised          As Boolean
      Dim sentToHost       As Boolean
   End Structure

   <Serializable> Public Structure DashOptions
      Dim robotHost        As String
      Dim robotPort        As Int32
      Dim dashCount        As Integer
      Dim dashButtonCount  As Integer
   End Structure

   Public Enum DBIndex
      buttonGyro = 0
      buttonRunPID = 1
      buttonLogData = 2
   End Enum

   Public Enum DVindex
      autoSelect = 0
      autoDelay = 1
      autoStart = 2

      pidSelect = 3
      pidSetpoint = 4
      pidMaxOut = 5
      pidPthreshold = 6
      pidPabove = 7
      pidPbelow = 8
      pidIthreshold = 9
      pidIabove = 10
      pidIbelow = 11
      pidDthreshold = 12
      pidDabove = 13
      pidDbelow = 14

      setMinFuelIntake = 15
      setMaxFuelIntake = 16
      setMaxDriveSpeed = 17
      setLowShooterSpeed = 18
      setHighShooterSpeed = 19
      setGearInSpeed = 20
      setGearOutSpeed = 21
      setGoatDirection = 22
      setChurnerSpeed = 23
   End Enum

   Public Enum RVindex
      calibrateGyro = 0
      driveGyro = 1
      driveEncoderL = 2
      driveEncoderR = 3
      driveMode = 4
      fuelIntake = 5
      fuelLegs = 6
      lowerShooter = 7
      upperShooter = 8
      gearSensor = 9
      liftAlign = 10
      goatAmps = 11
      airVent = 12
   End Enum

   Public Enum TextBoxType
      None = 0
      AnyInteger = 1
      PositiveInteger = 2
      Float = 3
      Text = 4
      Time = 5
   End Enum

   Public Enum TrafficFrom
      Code = 0
      Host = 1
      Client = 2
   End Enum

   Public m_colorPending         As Color = Color.Pink
   Public m_dashFile             As String = Application.StartupPath & "\RobotDash.set"
   Public m_dashValue()          As DashboardValue
   Public m_dashButton()         As DashboardButton
   Public m_dashOptions          As DashOptions
   Public m_imageDone            As Image
   Public m_imagePending         As Image
   Public m_optionsFile          As String = Application.StartupPath & "\RobotDash.cfg"
   Public m_robotValue()         As Double
   Public m_robotCount           As Integer
   Public m_robotMode            As Integer = -1

   Public m_dashForm             As DashForm
   Public m_dataForm             As DataForm
   Public m_hostTrafficForm      As HostTrafficForm
   Public m_optionsForm          As OptionsForm
   Public m_settingsForm         As SettingsForm
   Public m_tunePIDForm          As TunePidForm
   Public m_tcpClient            As TcpClient

   Public Function ConvertToDouble(value As String) As Double
      If IsNumeric(value) Then Return CDbl(value)
      Return 0
   End Function

   Public Function ConvertToInt(value As String) As Integer
      If IsNumeric(value) Then Return CInt(value)
      Return 0
   End Function

   Public Function ConvertToLong(value As String) As Long
      If IsNumeric(value) Then Return CLng(value)
      Return 0
   End Function

   Public Function FormatValue(value As Double, precision As Integer) As String
      Static trim()     As Char = {"0"}
      Dim myValue       As String = FormatNumber(value, precision, TriState.True, TriState.False, TriState.False)
      Dim decimalIndex  As Integer = myValue.IndexOf(".")

      If decimalIndex >= 0
         myValue = myValue.TrimEnd(trim)
         If decimalIndex = myValue.Length - 1 Then myValue = Mid(myValue, 1, myValue.Length - 1)
      End If

      If myValue.Length = 0 Then myValue = "0"

      Return myValue
   End Function

   Public Property DashButton(group As Integer, index As Integer) As Boolean
      Get
         If group < m_dashOptions.dashButtonCount And index < 16
            Dim bitValue As Long = 2 ^ index
            Return ((m_dashButton(group).value And bitValue) > 0)
         Else
            Return False
         End If
      End Get

      Set(value As Boolean)
         If group < m_dashOptions.dashButtonCount And index < 16
            Dim bitValue As Long = 2 ^ index

            If value
               m_dashButton(group).value = m_dashButton(group).value Or bitValue
            ElseIf (m_dashButton(group).value And bitValue) > 0
               m_dashButton(group).value = m_dashButton(group).value Xor bitValue
            End If

            m_dashButton(group).sentToHost = False

            If m_tcpClient IsNot Nothing Then m_tcpClient.SendMessage("PUT:B," & group.ToString & "," & m_dashButton(group).value.ToString & "|")
            If m_dataForm IsNot Nothing Then m_dataForm.ShowData(DataForm.DataGroup.DashButton)
         End If
      End Set
   End Property

   Public Property DashValue(index As Integer, sendToHost As Boolean) As Double
      Get
         If index > 0 And  index < m_dashOptions.dashCount
            Return m_dashValue(index).value
         Else
            Return -1
         End If
      End Get

      Set(value As Double)
         Static mesg    As String = String.Empty
         Static trim()  As Char = {"0", "."}

         If index >= 0 And index < m_dashOptions.dashCount
            m_dashValue(index).value = value
            m_dashValue(index).revised = False
            m_dashValue(index).sentToHost = False

            If Len(mesg) = 0 Then mesg = "PUT:"
            mesg &= "V," & index.ToString & "," & FormatValue(value, 6) & "|"
         End If

         If sendToHost And Len(mesg) > 0
            If m_tcpClient IsNot Nothing Then m_tcpClient.SendMessage(mesg)
            SaveDashValues()
            mesg = String.Empty

            If m_dataForm IsNot Nothing Then m_dataForm.ShowData(DataForm.DataGroup.DashValue)
         End If
      End Set
   End Property

   Public Function GetRobotValue(index As Integer) As Double
      If index >= 0 And index < m_robotCount
         Return m_robotValue(index)
      Else
         Return 0
      End If
   End Function

   Public Sub LoadDashValues()
      Dim fileFound        As Boolean = My.Computer.FileSystem.FileExists(m_dashFile)

      If fileFound
         Dim binaryFormatter  As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter
         Dim fileStream       As New IO.FileStream(m_dashFile, IO.FileMode.OpenOrCreate)
         Dim count            As Integer

         count = binaryFormatter.Deserialize(fileStream)

         For i As Integer = 0 To count - 1
            If i < m_dashOptions.dashCount
               m_dashValue(i) = binaryFormatter.Deserialize(fileStream)
               m_dashValue(i).revised = False
               m_dashValue(i).sentToHost = False
            Else
               Exit For
            End If
         Next

         fileStream.Close()
      End If
   End Sub

   Public Sub LoadOptions()
      Dim fileFound        As Boolean = My.Computer.FileSystem.FileExists(m_optionsFile)
      Dim binaryFormatter  As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter
      Dim fileStream       As New IO.FileStream(m_optionsFile, IO.FileMode.OpenOrCreate)

      If Not fileFound
         With m_dashOptions
            .robotHost = "roborio-525-frc.local"
            .robotPort = 5801
            .dashCount = 0
            .dashButtonCount = 0
         End With

         binaryFormatter.Serialize(fileStream, m_dashOptions)
         fileStream.Position = 0
      End If

      m_dashOptions = binaryFormatter.Deserialize(fileStream)

      fileStream.Close()

      ReDim m_dashValue(m_dashOptions.dashCount)
      ReDim m_dashButton(m_dashOptions.dashButtonCount)
   End Sub

   Public Function RobotModeCaption(mode As Integer) As String
      Dim caption As String = String.Empty

      Select mode
         Case 0:     caption = "BOOT-UP"
         Case 1:     caption = "DISABLED"
         Case 2:     caption = "AUTONOMOUS"
         Case 3:     caption = "TELEOPERATED"
         Case 4:     caption = "TEST"
      End Select

      Return caption
   End Function

   Public Sub SaveDashValues()
      Dim binaryFormatter  As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter
      Dim fileStream       As New IO.FileStream(m_dashFile, IO.FileMode.OpenOrCreate)

      binaryFormatter.Serialize(fileStream, m_dashOptions.dashCount)

      For i As Integer = 0 To m_dashOptions.dashCount - 1
         binaryFormatter.Serialize(fileStream, m_dashValue(i))
      Next

      fileStream.Close()
   End Sub

   Public Sub SaveOptions()
      Dim binaryFormatter  As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter
      Dim fileStream       As New IO.FileStream(m_optionsFile, IO.FileMode.OpenOrCreate)

      binaryFormatter.Serialize(fileStream, m_dashOptions)
      fileStream.Close()
   End Sub

   Public Sub SetAppWindowState(state As FormWindowState)
      If state = FormWindowState.Minimized
         If m_dataForm IsNot Nothing
            m_dataForm.WindowState = state
            m_dataForm.Visible = False
         End If

         If m_optionsForm IsNot Nothing
            m_optionsForm.WindowState = state
            m_optionsForm.Visible = False
         End If

         If m_hostTrafficForm IsNot Nothing
            m_hostTrafficForm.WindowState = state
            m_hostTrafficForm.Visible = False
         End If

         If m_settingsForm IsNot Nothing
            m_settingsForm.WindowState = state
            m_settingsForm.Visible = False
         End If

         If m_tunePIDForm IsNot Nothing
            m_tunePIDForm.WindowState = state
            m_tunePIDForm.Visible = False
         End If

      Else
         If m_dataForm IsNot Nothing
            m_dataForm.Visible = True
            m_dataForm.WindowState = state
         End If

         If m_optionsForm IsNot Nothing
            m_optionsForm.Visible = True
            m_optionsForm.WindowState = state
         End If

         If m_hostTrafficForm IsNot Nothing
            m_hostTrafficForm.Visible = True
            m_hostTrafficForm.WindowState = state
         End If

         If m_settingsForm IsNot Nothing
            m_settingsForm.Visible = True
            m_settingsForm.WindowState = state
         End If

         If m_tunePIDForm IsNot Nothing
            m_tunePIDForm.Visible = True
            m_tunePIDForm.WindowState = state
         End If
      End If
   End Sub

   Public Sub StartClient()
      If m_tcpClient Is Nothing Then m_tcpClient = New TcpClient
      m_tcpClient.Start()
   End Sub

   Public Sub StopClient()
      If m_tcpClient IsNot Nothing Then m_tcpClient.Shutdown()
   End Sub

   Public Function TextBoxKeyPress(ByVal boxType As TextBoxType, ByVal newChar As Char) As Char
      ' TextBoxType:  0=None; 1=AnyInteger; 2=PositiveInteger; 3=Float; 4=Text; 5=Time

      Dim myChar As Char = ""

      Select Case Asc(myChar)
         Case 8, 48 To 57        ' Backspace, 0 to 9
            myChar = newChar
         Case 45                 ' - (minus)
            Select Case boxType
               Case TextBoxType.AnyInteger, TextBoxType.Float, TextBoxType.Text
                  myChar = newChar
            End Select
         Case 46                 ' . (period)
            Select Case boxType
               Case TextBoxType.Float, TextBoxType.Text
                  myChar = newChar
            End Select
         Case 58                 ' : (colon)
            Select Case boxType
                Case TextBoxType.Text, TextBoxType.Time
                  myChar = newChar
            End Select
         Case 124                ' | (pipe)
         Case Else
            myChar = newChar
      End Select

      Return myChar
   End Function

End Module
