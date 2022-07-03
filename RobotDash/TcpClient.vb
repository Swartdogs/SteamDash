Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Timers

Public Class TcpClient
   Private Enum ReceiveState
      None = 0
      Ignore = 1
      Login = 2
      GetCategory = 3
      GetColors = 4
      GetRank = 5
      GetTeam = 6
   End Enum

   Private c_connected        As Boolean = False
   Private c_getTimer         As Timer
   Private c_hostAddress      As IPAddress
   Private c_newCounts        As Boolean
   Private c_openTimer        As Timer
   Private c_receiveState     As ReceiveState = ReceiveState.None
   Private c_retryTimer       As Timer

   Private WithEvents c_clientSocket   As ClientSocket

   Private Sub Connect(connected as Boolean) Handles c_clientSocket.Connect
      If m_dashForm IsNot Nothing
         If connected
            m_dashForm.InvokeClientStatus(DashForm.LinkStatus.Connected)
         Else
            m_dashForm.InvokeClientStatus(DashForm.LinkStatus.None)
         End If
      End If

      c_connected = connected

      If connected
         ShowTraffic(TrafficFrom.Code, "Connected")
         m_robotMode = -1
         c_getTimer.Start()
      Else
         c_retryTimer.Start()
      End If
   End Sub

   Private Sub Disconnect(message As String) Handles c_clientSocket.Disconnect
      c_connected = False
      m_robotMode = -1
      If m_dashForm IsNot Nothing Then m_dashForm.InvokeClientStatus(DashForm.LinkStatus.None)

      c_clientSocket.Close()
      c_getTimer.Stop()
      c_retryTimer.Start()

      ShowTraffic(TrafficFrom.Code, message)
   End Sub

   Public Sub GetHostAddress()
      If m_dashForm IsNot Nothing Then m_dashForm.InvokeClientStatus(DashForm.LinkStatus.Connecting)
      Dns.BeginGetHostAddresses(m_dashOptions.robotHost, AddressOf GetHostAddressCallback, Nothing)
   End Sub

   Public Sub GetHostAddressCallback(ar As IAsyncResult)
      Try
         Dim hostIP() as IPAddress = Dns.EndGetHostAddresses(ar)

         For index As Integer = 0 To hostIP.Count - 1
            If (Not hostIP(index).IsIPv6LinkLocal) And (Not hostIP(index).IsIPv6Multicast) And (Not hostIP(index).IsIPv6SiteLocal)
               c_clientSocket.Open(hostIP(index), m_dashOptions.robotPort)
               Exit For
            End If
         Next

      Catch e As Exception
         If m_dashForm IsNot Nothing Then m_dashForm.InvokeClientStatus(DashForm.LinkStatus.NoAddress)
         c_retryTimer.Start()
      End Try
   End Sub

   Private Sub GetTimeout()
      c_getTimer.Stop()

      If c_connected
         If m_robotMode < 0
            m_robotMode = 0
            c_newCounts = False
            SendMessage("COUNT:")

         ElseIf c_newCounts
            c_newCounts = False
            SendMessage("COUNT:")

         Else
            SendMessage("GET:" & DateAndTime.Now.ToString("MM/dd/yy hh:mm") & "|0," & (m_robotCount - 1).ToString)
         End If
      End If
   End Sub

   Public Function IsConnected() As Boolean
      Return c_connected
   End Function

   Public Sub NewCounts()
      c_newCounts = True
   End Sub

   Private Sub NewMessage(ByVal message As String) Handles c_clientSocket.NewMessage
      Dim command             As String = String.Empty
      Dim colon               As Integer
      Dim errorMessage        As String = String.Empty
      Dim parse()             As String
      Dim validCommand        As Boolean = False

      ShowTraffic(TrafficFrom.Host, message)

      colon = message.IndexOf(":")

      If colon < 0
         ShowTraffic(TrafficFrom.Code, "No command in message")

      Else
         command = message.Substring(0, colon)
         message = message.Substring(colon + 1).Trim

         Select command
            Case "COUNT"
               parse = message.Split(",")

               If parse.Count = 4
                  m_dashForm.InvokeFinishCount(ConvertToInt(parse(0)), ConvertToInt(parse(1)), ConvertToInt(parse(2)), ConvertToInt(parse(3)))
                  SendDashboardData()
               Else
                  ShowTraffic(TrafficFrom.Code, "Invalid COUNT response") 
               End If

            Case "GET"
               parse = message.Split(",")

               If parse.Count = m_robotCount + 2
                  For i As Integer = 0 To m_robotCount - 1
                     m_robotValue(i) = ConvertToDouble(parse(i + 2))
                  Next

                  m_dashForm.InvokeFinshGet(ConvertToInt(parse(0)))
               Else
                  ShowTraffic(TrafficFrom.Code, "Invalid GET response")
               End If

            Case "PUT"
               Dim ack()      as String
               Dim buttonAck  As Boolean = False
               Dim index      As Integer = 0
               Dim valueAck   As Boolean = False

               parse = message.Split("|")

               For i As Integer = 0 To parse.Count - 1
                  ack = parse(i).Split(",")

                  If ack.Count = 2
                     index = ConvertToInt(ack(1))

                     Select ack(0)
                        Case "B"
                           If index < m_dashOptions.dashButtonCount
                              m_dashButton(index).sentToHost = True
                              buttonAck = True
                           End If

                        Case "V"
                           If index < m_dashOptions.dashCount
                              m_dashValue(index).sentToHost = True
                              valueAck = True
                           End If
                     End Select
                  End If
               Next

               m_dashForm.InvokeFinishPut(buttonAck, valueAck)
         End Select

         c_getTimer.Start()
      End If
   End Sub

   Private Sub NewTraffic(message As String) Handles c_clientSocket.NewTraffic
      ShowTraffic(TrafficFrom.Code, message)
   End Sub

   Private Sub OpenPort()
      If c_openTimer IsNot Nothing Then c_openTimer.Stop()

      If c_getTimer Is Nothing
         c_getTimer = New Timer(200)
         c_getTimer.AutoReset = False
         AddHandler c_getTimer.Elapsed, New ElapsedEventHandler(AddressOf GetTimeout)
      End If

      If c_retryTimer Is Nothing
         c_retryTimer = New Timer(5000)
         c_retryTimer.AutoReset = False
         AddHandler c_retryTimer.Elapsed, New ElapsedEventHandler(AddressOf RetryConnect)
      End If

      GetHostAddress()
   End Sub

   Private Sub RetryConnect(sender As Object, e As ElapsedEventArgs)
      c_retryTimer.Stop()
      GetHostAddress()
   End Sub

   Private Sub SendDashboardData()
      Dim i          As Integer
      Dim dash       As String = String.Empty

      For i = 0 To m_dashOptions.dashButtonCount - 1
         dash &= "B," & i.ToString & "," & m_dashButton(i).value.ToString & "|"
      Next

      For i = 0 To m_dashOptions.dashCount - 1
         dash &= "V," & i.ToString & "," & FormatValue(m_dashValue(i).value, 6) & "|"
      Next

      If dash.Length > 0 Then SendMessage("PUT:" & dash)
   End Sub

   Public Sub SendMessage(message As String)
      If c_connected
         ShowTraffic(TrafficFrom.Client, message)
         c_clientSocket.Send(message)
      End If
   End Sub

   Private Sub ShowTraffic(from As TrafficFrom, message As String)
      If m_hostTrafficForm IsNot Nothing
         m_hostTrafficForm.AddMessage(from, message)
      End If
   End Sub

   Public Sub Shutdown()
      If c_getTimer IsNot Nothing Then c_getTimer.Stop()
      If c_retryTimer IsNot Nothing Then c_retryTimer.Stop()

      c_connected = False
      c_clientSocket.Close()
      m_dashForm.LedRobot.BackColor = Color.LightPink
   End Sub

   Public Sub Start()
      If c_clientSocket Is Nothing Then
         c_clientSocket = New ClientSocket
         OpenPort()         
      Else
         c_connected = False
         c_clientSocket.Close()

         If c_openTimer Is Nothing
            c_openTimer = New Timer(2000)
            c_openTimer.AutoReset = False
            AddHandler c_openTimer.Elapsed, New ElapsedEventHandler(AddressOf OpenPort)
         End If

         c_openTimer.Start()
      End If
   End Sub

End Class

' *******************************************************************************************************************

Public Class ClientSocket
   Private Structure ReceiveBuffer
      Dim bufferSize          As Integer
      Dim buffer()            As Byte
      Dim message             As String
   End Structure

   Private c_hostIP           As IPAddress
   Private c_hostPort         As Int32
   Private c_openTimer        As Timer
   Private c_receive          As ReceiveBuffer
   Private c_socket           As Socket
   Private c_socketOpen       As Boolean = False

   Public Event Connect(connected As Boolean)
   Public Event Disconnect(message As String)
   Public Event NewMessage(message As String)
   Public Event NewTraffic(message As String)

   Private Sub ConnectCallback(result As IAsyncResult)
      On Error GoTo ConnectError

      c_openTimer.Stop()

      If c_socket Is Nothing
         RaiseEvent NewTraffic("Connection Timeout")
         RaiseEvent Connect(False)
      Else
         c_socket.EndConnect(result)
         c_socket.BeginReceive(c_receive.buffer, 0, c_receive.bufferSize, 0, New AsyncCallback(AddressOf ReceiveCallback), c_receive)
         RaiseEvent Connect(c_socket.Connected)
      End If

      Exit Sub

   ConnectError:
      If c_socket Is Nothing Then RaiseEvent Connect(False) Else RaiseEvent Connect(c_socket.Connected)
      RaiseEvent NewTraffic("Connect Error: " & Err.Description)
   End Sub

   Public Sub Close()
      If c_openTimer IsNot Nothing Then c_openTimer.Stop()

      If c_socket IsNot Nothing
         c_socketOpen = False       ' Set to False prior to Shutdown to avoid ObjectDisposedException

         If c_socket.Connected
            c_socket.Shutdown(SocketShutdown.Both)
            c_socket.Close()
         End If

         c_socket = Nothing
      End If
   End Sub

   Public Sub Open(hostIP As IPAddress, hostPort As Int32, optional bufferSize As Integer = 512)
      If c_openTimer Is Nothing
         c_openTimer = New Timer(7000)
         c_openTimer.AutoReset = False
         AddHandler c_openTimer.Elapsed, New ElapsedEventHandler(AddressOf OpenTimeout)
      End If

      Try
         c_hostIP = hostIP
         c_hostPort = hostPort
         c_receive.bufferSize = bufferSize
         ReDim c_receive.buffer(c_receive.bufferSize)

         c_socket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)

         Dim hostEndPoint As New IPEndPoint(c_hostIP, c_hostPort)
         c_socket.BeginConnect(hostEndPoint, New AsyncCallback(AddressOf ConnectCallback), c_socket)
         c_openTimer.Start()
         c_socketOpen = True

      Catch ex As Exception
         RaiseEvent NewTraffic("Open Error: " & ex.Message.ToString)
      End Try
   End Sub

   Private Sub OpenTimeout()
      c_openTimer.Stop()
      c_socket.Close()
      c_socket = Nothing
   End Sub

   Private Sub ReceiveCallback(result As IAsyncResult)
      Dim message As String = String.Empty
      Dim eol     As Integer

      If Not c_socketOpen Then Exit Sub

      On Error GoTo ReceiveError

      Dim bytesRead  As Integer =  0
      bytesRead = c_socket.EndReceive(result)

      If bytesRead > 0 Then
         c_receive.message &= Encoding.ASCII.GetString(c_receive.buffer, 0, bytesRead)

         Do
            eol = InStr(c_receive.message, vbCrLf)                      ' Look for End-of-Line characters   

            If eol Then         
               message = Left(c_receive.message, eol - 1)               ' Get new message from message string
               c_receive.message = Mid(c_receive.message, eol + 2)      ' Delete new message from message string

               RaiseEvent NewMessage(message)
            Else
               Exit Do
            End If
         Loop

         If c_socketOpen
            c_socket.BeginReceive(c_receive.buffer, 0, c_receive.bufferSize, 0, New AsyncCallback(AddressOf ReceiveCallback), c_receive)
         End if
      Else
         RaiseEvent Disconnect("Disconnected: No Message Received")
      End If

      Exit Sub

   ReceiveError:
      message = Err.Description
      eol = InStr(message, vbCrLf)       
      if eol Then message = Left(message, eol - 1)

      RaiseEvent NewTraffic("Receive Error: " & message)
      RaiseEvent Disconnect("Disconnected: Receive Error")
   End Sub

   Public Sub Send(message As String)
      If Not c_socketOpen Then Exit Sub

      Dim byteBuffer As Byte() = Encoding.ASCII.GetBytes(message & vbCrLf)

      Try
         c_socket.BeginSend(byteBuffer, 0, byteBuffer.Length, 0, New AsyncCallback(AddressOf SendCallback), c_socket)

      Catch e As SocketException
         RaiseEvent NewTraffic("Send Error: " & e.Message.ToString)
      End Try
   End Sub

   Private Sub SendCallback(result As IAsyncResult)
      'Debug.Print("SendCallback")
   End Sub
End Class
