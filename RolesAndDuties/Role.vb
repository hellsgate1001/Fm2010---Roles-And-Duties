Public Class Role
    Dim position As New Position
    Dim name As String
    Dim role As New Dictionary(Of String, Dictionary(Of String, Dictionary(Of String, String)))
    Dim Duties As New Dictionary(Of String, Dictionary(Of String, String))

    'Public Sub SetDuties(ByVal NewDuties As Dictionary(Of String, Dictionary(Of String, String)))
    'Duties = NewDuties
    'End Sub

    Public Sub SetDuties(ByVal DutyList As List(Of Duty))
        For Each du As Duty In DutyList
            Duties.Add(du.GetName(), du.GetAttributes())
        Next
    End Sub

    Public Sub SetName(ByVal NewName As String)
        name = NewName
    End Sub

    Public Sub SetRole()
        Dim NewRole As New Dictionary(Of String, Dictionary(Of String, Dictionary(Of String, String)))
        NewRole.Add(name, Duties)
        role = NewRole
    End Sub

    Public Function GetRole() As Dictionary(Of String, Dictionary(Of String, Dictionary(Of String, String)))
        Return role
    End Function

    Public Function GetName() As String
        Return name
    End Function

    Public Function GetDuties() As Dictionary(Of String, Dictionary(Of String, String))
        Return Duties
    End Function
End Class
