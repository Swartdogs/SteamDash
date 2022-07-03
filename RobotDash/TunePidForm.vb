Imports System.ComponentModel

Public Class TunePidForm

   Public Enum DataGroup
      All = 0
      RobotValue = 1
      DashValue = 2
      DashButton = 3
   End Enum

   Private c_formName      As String = "TUNE PID"
   Private c_ignoreEvents  As Boolean = False

   Private Sub ButtonRun_KeyDown(sender As Object, e As KeyEventArgs) Handles ButtonRun.KeyDown
      If e.KeyCode = Keys.Space Then DashButton(0, DBIndex.buttonRunPID) = True
   End Sub

   Private Sub ButtonRun_KeyUp(sender As Object, e As KeyEventArgs) Handles ButtonRun.KeyUp
      If e.KeyCode = Keys.Space Then DashButton(0, DBIndex.buttonRunPID) = False
   End Sub

   Private Sub ButtonRun_MouseDown(sender As Object, e As MouseEventArgs) Handles ButtonRun.MouseDown
      DashButton(0, DBIndex.buttonRunPID) = True
   End Sub

   Private Sub ButtonRun_MouseUp(sender As Object, e As MouseEventArgs) Handles ButtonRun.MouseUp
      DashButton(0, DBIndex.buttonRunPID) = False
   End Sub

   Private Sub ButtonSend_Click(sender As Object, e As EventArgs) Handles ButtonSend.Click
      If m_dashValue(DVindex.pidSelect).revised       Then DashValue(DVindex.pidSelect, False) = CDbl(ListPID.SelectedIndex)
      If m_dashValue(DVindex.pidSetpoint).revised     Then DashValue(DVindex.pidSetpoint, False) = ConvertToDouble(TextSetpoint.Text)
      If m_dashValue(DVindex.pidMaxOut).revised       Then DashValue(DVindex.pidMaxOut, False) = ConvertToDouble(TextMaxOut.Text)
      If m_dashValue(DVindex.pidPthreshold).revised   Then DashValue(DVindex.pidPthreshold, False) = ConvertToDouble(TextPThreshold.Text)
      If m_dashValue(DVindex.pidPabove).revised       Then DashValue(DVindex.pidPabove, False) = ConvertToDouble(TextPAbove.Text)
      If m_dashValue(DVindex.pidPbelow).revised       Then DashValue(DVindex.pidPbelow, False) = ConvertToDouble(TextPBelow.Text)
      If m_dashValue(DVindex.pidIthreshold).revised   Then DashValue(DVindex.pidIthreshold, False) = ConvertToDouble(TextIThreshold.Text)
      If m_dashValue(DVindex.pidIabove).revised       Then DashValue(DVindex.pidIabove, False) = ConvertToDouble(TextIAbove.Text)
      If m_dashValue(DVindex.pidIbelow).revised       Then DashValue(DVindex.pidIbelow, False) = ConvertToDouble(TextIBelow.Text)
      If m_dashValue(DVindex.pidDthreshold).revised   Then DashValue(DVindex.pidDthreshold, False) = ConvertToDouble(TextDThreshold.Text)
      If m_dashValue(DVindex.pidDabove).revised       Then DashValue(DVindex.pidDabove, False) = ConvertToDouble(TextDAbove.Text)
      If m_dashValue(DVindex.pidDbelow).revised       Then DashValue(DVindex.pidDbelow, False) = ConvertToDouble(TextDBelow.Text)

      DashValue(-1, True) = 0
   End Sub

   Private Sub ListPID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListPID.SelectedIndexChanged
      If Not c_ignoreEvents
         m_dashValue(DVindex.pidSelect).revised = True
         ListPID.BackColor = m_colorPending
         ButtonSend.Enabled = True
         ButtonRun.Enabled = False
      End If
   End Sub

   Private Sub ShowSettings()
      Dim sendEnabled As Boolean = False

      c_ignoreEvents = True

      ListPID.SelectedIndex = m_dashValue(DVindex.pidSelect).value
      If Not m_dashValue(DVindex.pidSelect).sentToHost
         ListPID.BackColor = m_colorPending
         sendEnabled = True
      End If

      TextSetpoint.Text = FormatValue(m_dashValue(DVindex.pidSetpoint).value, 2)
      If Not m_dashValue(DVindex.pidSetpoint).sentToHost
         TextSetpoint.BackColor = m_colorPending
         sendEnabled = True
      End If

      TextMaxOut.Text = FormatValue(m_dashValue(DVindex.pidMaxOut).value , 2)
      If Not m_dashValue(DVindex.pidMaxOut).sentToHost
         TextMaxOut.BackColor = m_colorPending
         sendEnabled = True
      End If

      TextPThreshold.Text = FormatValue(m_dashValue(DVindex.pidPthreshold).value, 6)
      If Not m_dashValue(DVindex.pidPthreshold).sentToHost
         TextPThreshold.BackColor = m_colorPending
         sendEnabled = True
      End If

      TextPAbove.Text = FormatValue(m_dashValue(DVindex.pidPabove).value, 6)
      If Not m_dashValue(DVindex.pidPabove).sentToHost
         TextPAbove.BackColor = m_colorPending
         sendEnabled = True
      End If

      TextPBelow.Text = FormatValue(m_dashValue(DVindex.pidPbelow).value, 6)
      If Not m_dashValue(DVindex.pidPbelow).sentToHost
         TextPBelow.BackColor = m_colorPending
         sendEnabled = True
      End If

      TextIThreshold.Text = FormatValue(m_dashValue(DVindex.pidIthreshold).value, 6)
      If Not m_dashValue(DVindex.pidIthreshold).sentToHost
         TextIThreshold.BackColor = m_colorPending
         sendEnabled = True
      End If

      TextIAbove.Text = FormatValue(m_dashValue(DVindex.pidIabove).value, 6)
      If Not m_dashValue(DVindex.pidIabove).sentToHost
         TextIAbove.BackColor = m_colorPending
         sendEnabled = True
      End If

      TextIBelow.Text = FormatValue(m_dashValue(DVindex.pidIbelow).value, 6)
      If Not m_dashValue(DVindex.pidIbelow).sentToHost
         TextIbelow.BackColor = m_colorPending
         sendEnabled = True
      End If

      TextDThreshold.Text = FormatValue(m_dashValue(DVindex.pidDthreshold).value, 6)
      If Not m_dashValue(DVindex.pidDthreshold).sentToHost
         TextDThreshold.BackColor = m_colorPending
         sendEnabled = True
      End If

      TextDAbove.Text = FormatValue(m_dashValue(DVindex.pidDabove).value, 6)
      If Not m_dashValue(DVindex.pidDabove).sentToHost
         TextDAbove.BackColor = m_colorPending
         sendEnabled = True
      End If

      TextDBelow.Text = FormatValue(m_dashValue(DVindex.pidDbelow).value, 6)
      If Not m_dashValue(DVindex.pidDbelow).sentToHost
         TextDBelow.BackColor = m_colorPending
         sendEnabled = True
      End If

      c_ignoreEvents = False

      ButtonSend.Enabled = sendEnabled
      ButtonRun.Enabled = False
   End Sub

   Private Sub Text_GotFocus(sender As Object, e As EventArgs) Handles TextSetpoint.GotFocus, TextMaxOut.GotFocus, _
                                                                       TextPThreshold.GotFocus, TextPAbove.GotFocus, TextPBelow.GotFocus, _
                                                                       TextIThreshold.GotFocus, TextIAbove.GotFocus, TextIBelow.GotFocus, _
                                                                       TextDThreshold.GotFocus, TextDAbove.GotFocus, TextDBelow.GotFocus
      Dim box As TextBox = CType(sender, TextBox)
      box.SelectAll()
   End Sub

   Private Sub Text_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextSetpoint.KeyPress, TextMaxOut.KeyPress, _
                                                                               TextPThreshold.KeyPress, TextPAbove.KeyPress, TextPBelow.KeyPress, _
                                                                               TextIThreshold.KeyPress, TextIAbove.KeyPress, TextIBelow.KeyPress, _
                                                                               TextDThreshold.KeyPress, TextDAbove.KeyPress, TextDBelow.KeyPress
      Dim box As TextBox = CType(sender, TextBox)
      e.KeyChar = TextBoxKeyPress(TextBoxType.Float, e.KeyChar)
   End Sub

   Private Sub Text_Validating(sender As Object, e As CancelEventArgs) Handles TextSetpoint.Validating, TextMaxOut.Validating, _
                                                                               TextPThreshold.Validating, TextPAbove.Validating, TextPBelow.Validating, _
                                                                               TextIThreshold.Validating, TextIAbove.Validating, TextIBelow.Validating, _
                                                                               TextDThreshold.Validating, TextDAbove.Validating, TextDBelow.Validating
      Dim box     As TextBox = CType(sender, TextBox)
      Dim count   As Integer = 0
      Dim found   As Integer

      If box.Text.Length = 0 Then box.Text = "0"
      Dim text As String = box.Text

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
         e.Cancel = True

      Else
         Dim index      As Integer
         Dim newValue   As Double = ConvertToDouble(box.Text)
         
         Select box.Tag
            Case 0:  index = DVindex.pidSetpoint
            Case 1:  index = DVindex.pidMaxOut
            Case 2:  index = DVindex.pidPthreshold
            Case 3:  index = DVindex.pidPabove
            Case 4:  index = DVindex.pidPbelow
            Case 5:  index = DVindex.pidIthreshold
            Case 6:  index = DVindex.pidIabove
            Case 7:  index = DVindex.pidIbelow
            Case 8:  index = DVindex.pidDthreshold
            Case 9:  index = DVindex.pidDabove
            Case 10: index = DVindex.pidDbelow
         End Select

         If index < 2 Then box.Text = FormatValue(newValue, 2) Else box.Text = FormatValue(newValue, 6)

         If m_dashValue(index).value <> newValue
            m_dashValue(index).revised = True
            box.BackColor = m_colorPending
            ButtonSend.Enabled = True
            ButtonRun.Enabled = False
         End If
      End If
   End Sub

   Private Sub TunePidForm_Closed(sender As Object, e As EventArgs) Handles Me.Closed
      m_tunePIDForm = Nothing
   End Sub

   Private Sub TunePidForm_Load(sender As Object, e As EventArgs) Handles Me.Load
      Me.Top = m_dashForm.Top + 60
      Me.Left = m_dashForm.Left + 20
      ShowSettings()
   End Sub

   Public Sub UpdateStatus(group As DataGroup)
      Static testReady As Boolean = False

      If group = DataGroup.RobotValue
         ButtonRun.Enabled = testReady And (m_robotMode = 4)

      ElseIf group = DataGroup.DashValue
         testReady = True

         If Not m_dashValue(DVindex.pidSelect).revised And m_dashValue(DVindex.pidSelect).sentToHost Then ListPID.BackColor = Color.White Else testReady = False
         If Not m_dashValue(DVindex.pidSetpoint).revised And  m_dashValue(DVindex.pidSetpoint).sentToHost Then TextSetpoint.BackColor = Color.White Else testReady = False
         If Not m_dashValue(DVindex.pidMaxOut).revised And m_dashValue(DVindex.pidMaxOut).sentToHost Then TextMaxOut.BackColor = Color.White Else testReady = False

         If Not m_dashValue(DVindex.pidPthreshold).revised And m_dashValue(DVindex.pidPthreshold).sentToHost Then TextPThreshold.BackColor = Color.White Else testReady = False
         If Not m_dashValue(DVindex.pidPabove).revised And m_dashValue(DVindex.pidPabove).sentToHost Then TextPAbove.BackColor = Color.White Else testReady = False
         If Not m_dashValue(DVindex.pidPbelow).revised And m_dashValue(DVindex.pidPbelow).sentToHost Then TextPBelow.BackColor = Color.White Else testReady = False

         If Not m_dashValue(DVindex.pidIthreshold).revised And m_dashValue(DVindex.pidIthreshold).sentToHost Then TextIThreshold.BackColor = Color.White Else testReady = False
         If Not m_dashValue(DVindex.pidIabove).revised And m_dashValue(DVindex.pidIabove).sentToHost Then TextIAbove.BackColor = Color.White Else testReady = False
         If Not m_dashValue(DVindex.pidIbelow).revised And m_dashValue(DVindex.pidIbelow).sentToHost Then TextIBelow.BackColor = Color.White Else testReady = False

         If Not m_dashValue(DVindex.pidDthreshold).revised And m_dashValue(DVindex.pidDthreshold).sentToHost Then TextDThreshold.BackColor = Color.White Else testReady = False
         If Not m_dashValue(DVindex.pidDabove).revised And m_dashValue(DVindex.pidDabove).sentToHost Then TextDAbove.BackColor = Color.White Else testReady = False
         If Not m_dashValue(DVindex.pidDbelow).revised And m_dashValue(DVindex.pidDbelow).sentToHost Then TextDBelow.BackColor = Color.White Else testReady = False

         ButtonSend.Enabled = Not testReady
         ButtonRun.Enabled = testReady And (m_robotMode = 4)
      End If
   End Sub

End Class