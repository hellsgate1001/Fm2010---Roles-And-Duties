Public Class Position
    Dim Name As String
    Dim Roles As New Dictionary(Of String, Dictionary(Of String, Dictionary(Of String, String)))
    Dim position As New Dictionary(Of String, Dictionary(Of String, Dictionary(Of String, Dictionary(Of String, String))))

    Public Sub SetName(ByVal NewName As String)
        Name = NewName
    End Sub

    Public Sub SetRoles(ByVal RoleList As List(Of Role))
        For Each ro As Role In RoleList
            Roles.Add(ro.GetName(), ro.GetDuties())
        Next
    End Sub

    Public Function GetName() As String
        Return Name
    End Function

    Public Function GetRoles() As Dictionary(Of String, Dictionary(Of String, Dictionary(Of String, String)))
        Return Roles
    End Function
End Class
