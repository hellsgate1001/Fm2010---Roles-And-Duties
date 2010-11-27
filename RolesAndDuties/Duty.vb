Public Class Duty
    Dim Role As New Role
    Dim name As String
    Dim TopString As String
    Dim InterString As String
    Dim Top(9) As Array
    Dim Inter(9) As Array
    Dim Attributes As Dictionary(Of String, String)
    Dim FullDuty As Dictionary(Of String, Dictionary(Of String, String))

    Private Function _SetAttributes(ByRef AttStr As String) As Array
        Return AttStr.Split("-")
    End Function

    Public Sub SetTop(ByRef AttStr As String)
        Top = _SetAttributes(AttStr)
        TopString = AttStr
    End Sub

    Public Sub SetInter(ByRef AttStr As String)
        Inter = _SetAttributes(AttStr)
        InterString = AttStr
    End Sub

    Public Sub SetDuty()
        Dim NewDuty As New Dictionary(Of String, Dictionary(Of String, String))
        NewDuty.Add(name, Attributes)
        FullDuty = NewDuty
    End Sub

    Public Sub setAttributes(ByVal NewAtts As Dictionary(Of String, String))
        Attributes = NewAtts
    End Sub

    Public Sub SetName(ByVal NewName As String)
        name = NewName
    End Sub

    Public Function GetName() As String
        Return name
    End Function

    Public Function GetAttributes() As Dictionary(Of String, String)
        Return Attributes
    End Function

    Public Function GetDuties() As Dictionary(Of String, Dictionary(Of String, String))
        Return FullDuty
    End Function
End Class
