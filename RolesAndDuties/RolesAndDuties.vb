Imports System.IO
Imports System.Xml
Imports System.Xml.XPath
Namespace ReadXML
End Namespace


Public Class RolesAndDuties
    Dim RoleFile As String = AppPath() + "PositionRoleDuty.xml"
    Dim numRows As Integer
    Dim doc As New XmlDocument
    Dim root As XmlNode
    Dim Positions As XmlNodeList
    Dim Roles As XmlNodeList
    Dim Duties As XmlNodeList
    
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If File.Exists(RoleFile) Then
            'Dim csvStream As StreamReader = File.OpenText(RoleFile)
            Me.doc.Load(Me.RoleFile)
            Me.root = doc.DocumentElement
            Dim pos As String = "AMC"
            Dim role As String = "Trequartista"
            Dim duty As String = "Attack"

            Dim amc As String
            amc = root.SelectSingleNode("descendant::position[name='" + pos + "']") _
                .SelectSingleNode("descendant::role[name='" + role + "']") _
                .SelectSingleNode("descendant::duty[name='" + duty + "']") _
                .ChildNodes(1).InnerText

            MessageBox.Show("My Test String")
        End If
        MessageBox.Show(AppPath())
    End Sub

    Private Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileOpen.Click
        If dlgOpen.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim lineCounter As Integer = 0
            FileOpen(1, dlgOpen.FileName, OpenMode.Input)
            Do Until EOF(1)
                'Dim itemCounter As Integer = 0
                Dim FullLine As String = LineInput(1).Replace("""", "")
                Dim LineArray = FullLine.Split(";")
                'For lineNum = 0 To (LineArray.Count() - 1)
                'LineArray(lineNum) = LineArray(lineNum).Replace("""", "")
                'Next
            Loop
            'MessageBox.Show(Position("AMC")("Trequartista")("Attack")("top"))
        End If
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
