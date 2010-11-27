Imports System.IO

Public Class RolesAndDuties
    Dim strarray(1, 1) As String
    Dim RoleFile As String = AppPath() + "PositionRoleDuty.csv"
    Dim NameLabelLeft As Integer = 20
    Dim FullInfo As New Dictionary(Of String, Array)
    Dim numRows As Integer


    'Dim interAtts As New Dictionary(Of String, String)
    'Dim TopAtts As New Dictionary(Of String, String)
    Dim DutyAttributes As New Dictionary(Of String, String)
    'Dim Duty As New Dictionary(Of String, Dictionary(Of String, String))
    'Dim Role As New Dictionary(Of String, Dictionary(Of String, Dictionary(Of String, String)))
    Dim Position As New Dictionary(Of String, Dictionary(Of String, Dictionary(Of String, Dictionary(Of String, String))))

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If File.Exists(RoleFile) Then
            Dim csvStream As StreamReader = File.OpenText(RoleFile)
            Dim Lines As Array
            Dim Line As Array
            Dim Line2 As Array
            Dim x As Integer
            Dim tst As String
            Dim tst2 As String
            Dim NewDuty As New Duty
            Dim NewRole As New Role
            Dim DutiesList As New List(Of Duty)
            Dim RolesList As New List(Of Role)

            'Load the content of the roles and duties file into an array
            Lines = csvStream.ReadToEnd().Split(";")
            numRows = UBound(Lines)
            For x = 0 To numRows
                tst = Lines(x)
                Line = tst.Split(",")
                If Line.Length = 5 Then
                    DutyAttributes.Remove("top")
                    DutyAttributes.Remove("inter")
                    DutyAttributes.Add("top", Trim(Line(3)))
                    DutyAttributes.Add("inter", Trim(Line(4)))
                    NewDuty = New Duty
                    If x = 0 Then
                        NewRole = New Role
                    End If
                    NewDuty.SetName(Line(2))
                    NewDuty.setAttributes(DutyAttributes)
                    NewDuty.SetDuty()
                    DutiesList.Add(NewDuty)
                    If x < (numRows - 1) Then
                        tst2 = Lines(x + 1)
                        Line2 = tst2.Split(",")
                        If Trim(Line(1)) <> Trim(Line2(1)) Then
                            NewRole.SetName(Line(1))
                            NewRole.SetDuties(DutiesList)
                            NewRole.SetRole()
                            RolesList.Add(NewRole)
                            If Trim(Line(0)) = Trim(Line2(0)) Then
                                NewRole = New Role
                                DutiesList = New List(Of Duty)
                            End If
                        End If
                        If Trim(Line(0)) <> Trim(Line2(0)) Then
                            Dim NewPos As New Position
                            NewPos.SetName(Line(0))
                            NewPos.SetRoles(RolesList)
                            If Position.Count = 13 Then
                                NewRole = New Role
                            End If
                            Position.Add(NewPos.GetName(), NewPos.GetRoles())
                            NewRole = New Role
                            DutiesList = New List(Of Duty)
                            RolesList = New List(Of Role)
                        End If
                    Else
                        'Role.Add(Trim(Line(1)), Duty)
                        'Position.Add(Trim(Line(0)), Role)
                    End If
                End If
            Next
            MessageBox.Show(Position("AMC")("Trequartista")("Attack")("top") + ControlChars.CrLf + Position("DC")("Central Defender")("Stopper")("top"))
        End If
        MessageBox.Show(AppPath())
    End Sub

    Private Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileOpen.Click
        If dlgOpen.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim lineCounter As Integer = 0
            FileOpen(1, dlgOpen.FileName, OpenMode.Input)
            Do Until EOF(1)
                Dim LineArray = LineInput(1).Split(";")
                Position(LineArray(0))(LineArray(1))(LineArray(2))("top") = LineArray(3)
                Position(LineArray(0))(LineArray(1))(LineArray(2))("inter") = LineArray(4)
                lineCounter += 1
            Loop
            MessageBox.Show(Position("AMC")("Trequartista")("Attack")("top"))
        End If
    End Sub

    Private Sub OutputPlayerLine(ByVal line As String)
        Dim LineArray = line.Split(";")

        'Dim NewDuty As New Duty
        'NewDuty.SetTop(LineArray(3))
        'NewDuty.SetInter(LineArray(4))
    End Sub

    Private Sub mnuFileExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileExit.Click
        Me.Close()
    End Sub

    Private Structure TopAtts
        Public Atts() As String
    End Structure

    Private Structure InterAtts
        Public Atts() As String
    End Structure

    Private Function AppPath() As String
        Dim a As String
        a = Reflection.Assembly.GetExecutingAssembly.Location
        a = Mid(a, 1, InStrRev(a, "\"))
        Return (a)
    End Function
End Class
