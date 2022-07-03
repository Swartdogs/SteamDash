Imports System.ComponentModel
Imports System.Timers

Public Class HostTrafficForm

   Private c_trafficHold      As Boolean = False
   Private c_shutdown         As Boolean = False
   Private c_shutdownTimer    As Timer

   Private Delegate Sub AddMessageCallback(from As Integer, message As String)

   Private Sub Add(from As Integer, message As String)
      If from = -1
         Me.Close()

      ElseIf Not c_trafficHold
         Dim source As String = String.Empty

         Select from
            Case TrafficFrom.Code : source = "----"
            Case TrafficFrom.Host : source = "Host"
            Case TrafficFrom.Client : source = "Client"
         End Select

         GridTraffic.SuspendLayout
            GridTraffic.Rows.Add(Date.Now.ToString("hh:mm:ss"), source, message)
            GridTraffic.FirstDisplayedScrollingRowIndex = GridTraffic.Rows(GridTraffic.RowCount - 1).Index
            If GridTraffic.RowCount > 1000 Then GridTraffic.Rows.Remove(GridTraffic.Rows(0))
         GridTraffic.ResumeLayout
      End If
   End Sub

   Public Sub AddMessage(from As Integer, message As String)
      Me.Invoke(New AddMessageCallback(AddressOf Add), New Object() {from, message})
   End Sub

   Private Sub ButtonClear_Click(sender As Object, e As EventArgs) Handles ButtonClear.Click
      GridTraffic.RowCount = 0
   End Sub

   Private Sub ButtonHold_Click(sender As Object, e As EventArgs) Handles ButtonHold.Click
      c_trafficHold = Not c_trafficHold

      If c_trafficHold
         ButtonHold.BackColor = Color.PaleGreen
      Else
         ButtonHold.BackColor = Color.FromArgb(225, 230, 245)
      End If
   End Sub

   Private Sub HostTrafficForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
      If Not c_shutdown
         Me.Hide()
         m_hostTrafficForm = Nothing

         If c_shutdownTimer Is Nothing
            c_shutdownTimer = New Timer(2000)
            c_shutdownTimer.AutoReset = False
            AddHandler c_shutdownTimer.Elapsed, New ElapsedEventHandler(AddressOf ShutdownTimeout)
         End If

         c_shutdownTimer.Start()
         c_shutdown = True
         e.Cancel = True
      End If
   End Sub

   Private Sub HostTrafficForm_Load(sender As Object, e As EventArgs) Handles Me.Load
      Me.Top = m_dashForm.Top + 60
      Me.Left = m_dashForm.Left + 20
   End Sub

   Private Sub HostTrafficForm_Resize(sender As Object, e As EventArgs) Handles Me.Resize
      If Me.WindowState = FormWindowState.Normal
         GridTraffic.Columns(2).Width = GridTraffic.Width - 140
      End If
   End Sub

   Private Sub ShutdownTimeout()
      AddMessage(-1, String.Empty)
   End Sub
End Class