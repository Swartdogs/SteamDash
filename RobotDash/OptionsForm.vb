Imports System.ComponentModel

Public Class OptionsForm
   Private c_countChange      As Boolean = False
   Private c_dashOptions      As DashOptions
   Private c_formName         As String = "DASHBOARD OPTIONS"
   Private c_hostChange       As Boolean = False
   Private c_revised          As Boolean = False

   Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
      Dim result As DialogResult = MessageBox.Show(Me, "CAUTION:  Canceling the current edit session will restore the Options to the last saved values.  " _ 
                                    & "Any unsaved changes will be lost.  Do you wish to proceed?", _ 
                                   c_formName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

      If result = DialogResult.Yes
         c_dashOptions = m_dashOptions
         ShowOptions()
         Revised(False)
         c_countChange = False
         c_hostChange = False
      End If
   End Sub

   Private Sub ButtonSave_Click(sender As Object, e As EventArgs) Handles ButtonSave.Click
      If c_dashOptions.dashButtonCount <> m_dashOptions.dashButtonCount Then ReDim m_dashButton(c_dashOptions.dashButtonCount)
      If c_dashOptions.dashCount <> m_dashOptions.dashCount Then ReDim m_dashValue(c_dashOptions.dashCount)

      m_dashOptions = c_dashOptions
      SaveOptions()
      Revised(False)

      If c_hostChange
         StartClient()
      ElseIf c_countChange
         If m_dataForm IsNot Nothing Then m_dataForm.BuildGrids()
         If m_tcpClient IsNot Nothing Then m_tcpClient.NewCounts()
      End If

      c_countChange = False
      c_hostChange = False
   End Sub

   Private Sub OptionsForm_Closed(sender As Object, e As EventArgs) Handles Me.Closed
      m_optionsForm = Nothing
   End Sub

   Private Sub OptionsForm_Load(sender As Object, e As EventArgs) Handles Me.Load
      Me.Top = m_dashForm.Top + 60
      Me.Left = m_dashForm.Left + 20
      c_dashOptions = m_dashOptions
      ShowOptions()
   End Sub

   Private Sub Revised(state As Boolean)
      If c_revised <> state
         c_revised = state
         ButtonSave.Enabled = state
         ButtonCancel.Enabled = state
         LabelRevised.Visible = state
      End If
   End Sub

   Private Sub ShowOptions()
      With c_dashOptions
         TextAddress.Text = .robotHost
         TextPort.Text = .robotPort.ToString
         TextValues.Text = .dashCount.ToString
         TextButtons.Text = .dashButtonCount.ToString
      End With
   End Sub

   Private Sub Text_GotFocus(sender As Object, e As EventArgs) Handles TextAddress.GotFocus, TextPort.GotFocus, TextValues.GotFocus, TextButtons.GotFocus
      Dim box As TextBox = CType(sender, TextBox)
      box.SelectAll
   End Sub

   Private Sub Text_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextAddress.KeyPress, TextPort.KeyPress, TextValues.KeyPress, TextButtons.KeyPress
      Dim box As TextBox = CType(sender, TextBox)

      If box.Tag = 0
         e.KeyChar = TextBoxKeyPress(TextBoxType.Text, e.KeyChar)
      Else
         e.KeyChar = TextBoxKeyPress(TextBoxType.PositiveInteger, e.KeyChar)
      End If

      Revised(True)
   End Sub

   Private Sub TextAddress_Validating(sender As Object, e As CancelEventArgs) Handles TextAddress.Validating
      If c_dashOptions.robotHost <> TextAddress.Text
         c_dashOptions.robotHost = TextAddress.Text
         c_hostChange = True
      End If
   End Sub

   Private Sub TextButtons_Validating(sender As Object, e As CancelEventArgs) Handles TextButtons.Validating
      If TextButtons.Text.Length = 0 Then TextButtons.Text = "0"

      Dim count   As Long = CLng(TextButtons.text)

      If count > 10
         Dim result As DialogResult = MessageBox.Show(Me, "Dashboard Button Groups range = 0 to 10.", c_formName, MessageBoxButtons.OK, MessageBoxIcon.Information)
         TextButtons.Text = c_dashOptions.dashButtonCount.ToString
         e.Cancel = True         
      ElseIf c_dashOptions.dashButtonCount <> count
         c_dashOptions.dashButtonCount = count
         c_countChange = True
      End If
   End Sub

   Private Sub TextPort_Validating(sender As Object, e As CancelEventArgs) Handles TextPort.Validating
      If TextPort.Text.Length = 0 Then TextPort.Text = "0"
      
      Dim port As Long = CLng(TextPort.Text)

      If port > 65535
         Dim result As DialogResult = MessageBox.Show(Me, "Host Port range = 0 to 65535.", c_formName, MessageBoxButtons.OK, MessageBoxIcon.Information)
         TextPort.Text = c_dashOptions.robotPort.ToString
         e.Cancel = True
      ElseIf c_dashOptions.robotPort <> port
         c_dashOptions.robotPort = port
         c_hostChange = True
      End If
   End Sub

   Private Sub TextValues_Validating(sender As Object, e As CancelEventArgs) Handles TextValues.Validating
      If TextValues.Text.Length = 0 Then TextValues.Text = "0"

      Dim count   As Long = CLng(TextValues.text)

      If count > 300
         Dim result As DialogResult = MessageBox.Show(Me, "Dashboard Data Values range = 0 to 300.", c_formName, MessageBoxButtons.OK, MessageBoxIcon.Information)
         TextValues.Text = c_dashOptions.dashCount.ToString
         e.Cancel = True         
      ElseIf c_dashOptions.dashCount <> count
         c_dashOptions.dashCount = count
         c_countChange = True
      End If
   End Sub
End Class