﻿Public Class DataForm

   Public Enum DataGroup
      All = 0
      RobotValue = 1
      DashValue = 2
      DashButton = 3
   End Enum

   Public Sub BuildGrids(Optional robotOnly As Boolean = False)
      Dim row     As Integer

      GridRobotValue.RowCount = m_robotCount
      For row = 0 To m_robotCount - 1
         GridRobotValue.Item(0, row).Value = row + 1
      Next

      If robotOnly
         ShowData(DataGroup.RobotValue)
      Else
         GridDashValue.RowCount = m_dashOptions.dashCount
         For row = 0 To m_dashOptions.dashCount - 1
            GridDashValue.Item(0, row).Value = row + 1
         Next

         GridDashButton.RowCount = m_dashOptions.dashButtonCount
         For row = 0 To m_dashOptions.dashButtonCount - 1
            GridDashButton.Item(0, row).Value = row + 1
         Next

         ShowData(DataGroup.All)
      End If
   End Sub

   Private Function ButtonGroup(index As Integer) As String
      Dim bitValue   As Long = 1
      Dim status     As String = String.Empty

      If index < m_dashOptions.dashButtonCount
         For i = 0 To 15
            If (m_dashButton(index).value And bitValue) > 0 Then status &= "1" Else status &= "0"
            If (i + 1) Mod 4 = 0 Then status &= " "
            bitValue *= 2
         Next
      End If

      Return status
   End Function

   Private Sub DataForm_Closed(sender As Object, e As EventArgs) Handles Me.Closed
      m_dataForm = Nothing
   End Sub

   Private Sub DataForm_Load(sender As Object, e As EventArgs) Handles Me.Load
      Me.Top = m_dashForm.Top + 60
      Me.Left = m_dashForm.Left + 20

      BuildGrids()
   End Sub

   Public Sub ShowData(group As DataGroup)
      Dim i    As Integer

      If group = DataGroup.All Or group = DataGroup.RobotValue
         GridRobotValue.SuspendLayout()
            For i = 0 To m_robotCount - 1
               GridRobotValue.Item(1, i).Value = m_robotValue(i)
            Next
         GridRobotValue.ResumeLayout()
      End If

      If group = DataGroup.All Or group = DataGroup.DashValue
         GridDashValue.SuspendLayout()
            For i = 0 To m_dashOptions.dashCount - 1
               If m_dashValue(i).sentToHost
                  GridDashValue.Item(1, i).Value = m_imageDone
               Else
                  GridDashValue.Item(1, i).Value = m_imagePending
               End If

               GridDashValue.Item(2, i).Value = m_dashValue(i).value
            Next
         GridDashValue.ResumeLayout()
      End If

      If group = DataGroup.All Or group = DataGroup.DashButton
         GridDashButton.SuspendLayout()
            For i = 0 To m_dashOptions.dashButtonCount - 1
               If m_dashButton(i).sentToHost
                  GridDashButton.Item(1, i).Value = m_imageDone
               Else
                  GridDashButton.Item(1, i).Value = m_imagePending          
               End If

               GridDashButton.Item(2, i).Value = ButtonGroup(i)
            Next
         GridDashButton.ResumeLayout()      
      End If
   End Sub

End Class