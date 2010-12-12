Imports System.IO
Imports System.Xml
Imports System.Xml.XPath
Imports System.Xml.Linq


Public Class RolesAndDuties
    Dim RoleFile As String = AppPath() + "PositionRoleDuty.xml"
    Dim IniFile As String = AppPath() + "duties.ini"
    Dim PlayerFile As String
    Dim PlayerDetails() As String
    Dim numRows As Integer
    Dim doc As New XmlDocument
    Dim root As XmlNode
    Dim Positions As XmlNodeList
    Dim Roles As XmlNodeList
    Dim Duties As XmlNodeList
    Dim PositionRatings(15) As Integer
    Dim AttributeRatings(60) As Integer

    Dim lblNames As List(Of Label)
    Dim lblPositions As List(Of Label)
    Dim incrementY As Integer = 23
    Dim incrementX As Integer = 240
    Dim LabelTop As Integer = 27
    Dim lTop As Integer = 0
    Dim lLeft As Integer = 100
    Dim Players(1000) As Array
    Dim AllPositions As Dictionary(Of String, Integer)
    Dim ColumnHeadings(100) As String
    Dim PositionLabel As Label() = New Label(15) {}
    Dim PositionLabelCount As Integer = 0
    Dim RoleLabel As Label() = New Label(50) {}
    Dim RoleLabelCount As Integer = 0
    Dim DutyLabel As Label() = New Label(100) {}
    Dim DutyLabelCount As Integer = 0
    Dim ScoreLabel As Label() = New Label(800) {}
    Dim ScoreLabelCount As Integer = 0
    Dim ScoreHeadings(2) As String
    Dim TabPage As Integer = 0

    Dim RoleLabelTop As Integer
    Dim RoleIncY As Integer = 92
    Dim DutyLabelTop As Integer
    Dim DutyLabelLeft As Integer = 125

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If File.Exists(RoleFile) Then
            'Dim csvStream As StreamReader = File.OpenText(RoleFile)
            Me.doc.Load(Me.RoleFile)
            Me.root = doc.DocumentElement
            Dim pos As String = "AMC"
            Dim role As String = "Trequartista"
            Dim duty As String = "Attack"

            Dim amc As String
            amc = Me.root.SelectSingleNode("descendant::position[name='" + pos + "']") _
                .SelectSingleNode("descendant::role[name='" + role + "']") _
                .SelectSingleNode("descendant::duty[name='" + duty + "']") _
                .ChildNodes(1).InnerText

        End If

        If Not File.Exists(Me.IniFile) Then
            File.Create(Me.IniFile)
        Else
            Me.GetIniVars()
            Me.ReadPlayerFile()
        End If

        Me.ScoreHeadings(0) = "Ess"
        Me.ScoreHeadings(1) = "Imp"
        Me.ScoreHeadings(2) = "Tot"
    End Sub

    Private Sub AddRoleLabels(ByVal PosName As String)
        Dim PosDoc As XmlElement = Me.root.SelectSingleNode("descendant::position[name='" + PosName + "']")
        Dim role As XmlNode

        Me.Roles = PosDoc.GetElementsByTagName("role")
        For Each role In Me.Roles
            Dim DutyLabelLeft As Integer = 0
            Me.RoleLabel(Me.RoleLabelCount) = New Label
            Me.RoleLabel(Me.RoleLabelCount).Text = role.SelectSingleNode("name").InnerText
            Me.RoleLabel(Me.RoleLabelCount).Location = New System.Drawing.Point(0, Me.RoleLabelTop)
            Me.RoleLabel(Me.RoleLabelCount).AutoSize = True

            Me.tabDetails.TabPages(Me.TabPage).AutoScroll = True
            Me.tabDetails.TabPages(Me.TabPage).Controls.Add(Me.RoleLabel(Me.RoleLabelCount))
            Me.RoleLabelTop += Me.RoleIncY
            Me.Duties = role.SelectNodes("duty")

            Dim duty As XmlNode
            If Me.DutyLabelCount > 0 Then
                For i = 0 To Me.DutyLabelCount
                    Me.DutyLabel(i) = Nothing
                Next
                Me.DutyLabelCount = 0
            End If
            For Each duty In Me.Duties
                Me.DutyLabel(Me.DutyLabelCount) = New Label
                Me.DutyLabel(Me.DutyLabelCount).Text = duty.SelectSingleNode("name").InnerText
                Me.DutyLabel(Me.DutyLabelCount).TextAlign = ContentAlignment.TopCenter
                Me.DutyLabel(Me.DutyLabelCount).Location = New System.Drawing.Point(Me.DutyLabelLeft, Me.DutyLabelTop)
                Me.DutyLabel(Me.DutyLabelCount).Size = New System.Drawing.Size(240, 23)

                Me.tabDetails.TabPages(Me.TabPage).Controls.Add(Me.DutyLabel(Me.DutyLabelCount))

                ' the score labels and actual scores
                'Get the actual scores
                Dim Essential() As String = duty.SelectSingleNode("top").InnerText.Split("-")
                Dim EssTot As Integer = 0
                For Each ess In Essential
                    EssTot += Int(Me.PlayerDetails(Array.IndexOf(Me.ColumnHeadings, ess)))
                Next
                Dim Important() As String = duty.SelectSingleNode("inter").InnerText.Split("-")
                Dim ImpTot As Integer = 0
                For Each imp In Important
                    ImpTot += Int(Me.PlayerDetails(Array.IndexOf(Me.ColumnHeadings, imp)))
                Next
                Dim Scores(2) As Integer
                Dim ScoresMax(2) As Integer
                Scores(0) = EssTot
                Scores(1) = ImpTot
                Scores(2) = EssTot + ImpTot
                ScoresMax(0) = Essential.Count
                ScoresMax(1) = Important.Count
                ScoresMax(2) = Essential.Count + Important.Count

                For i = 0 To 2
                    Me.ScoreLabel(ScoreLabelCount) = New Label
                    Me.ScoreLabel(Me.ScoreLabelCount).Text = Me.ScoreHeadings(i)
                    Me.ScoreLabel(Me.ScoreLabelCount).TextAlign = ContentAlignment.TopCenter
                    Me.ScoreLabel(Me.ScoreLabelCount).Location = New System.Drawing.Point(Me.DutyLabelLeft + (i * 80), Me.DutyLabelTop + 23)
                    Me.ScoreLabel(Me.ScoreLabelCount).Size = New System.Drawing.Size(80, 23)
                    Me.tabDetails.TabPages(Me.TabPage).Controls.Add(Me.ScoreLabel(Me.ScoreLabelCount))
                    Me.ScoreLabelCount += 1

                    Dim Num As Double = 5.4
                    Dim Format As String = Num.ToString("#,##0.00;($#,##0.00);Zero")
                    Dim PositionScore As Integer = Me.PlayerDetails(Int(Me.tabDetails.TabPages(Me.TabPage).Tag.ToString))
                    Dim PositionRatio As Decimal = PositionScore / 20
                    Dim PosTot As Decimal = (Scores(i) / (ScoresMax(i) * 20)) * 100
                    Dim FullTotal As String = (PosTot * PositionRatio).ToString("#,##0.00;($#,##0.00);Zero")

                    Me.ScoreLabel(Me.ScoreLabelCount) = New Label
                    Me.ScoreLabel(Me.ScoreLabelCount).Text = Str(Scores(i)) _
                        + "/ " + Str(20 * ScoresMax(i)) _
                        + ControlChars.CrLf _
                        + ((Scores(i) / (ScoresMax(i) * 20)) * 100).ToString("#,##0.00;($#,##0.00);Zero") _
                        + "%" _
                        + ControlChars.CrLf _
                        + FullTotal _
                        + "%"
                    Me.ScoreLabel(Me.ScoreLabelCount).TextAlign = ContentAlignment.TopCenter
                    Me.ScoreLabel(Me.ScoreLabelCount).Location = New System.Drawing.Point(Me.DutyLabelLeft + (i * 80), Me.DutyLabelTop + 46)
                    Me.ScoreLabel(Me.ScoreLabelCount).Size = New System.Drawing.Size(80, 46)
                    Me.tabDetails.TabPages(Me.TabPage).Controls.Add(Me.ScoreLabel(Me.ScoreLabelCount))
                    Me.ScoreLabelCount += 1
                Next

                Me.DutyLabelLeft += Me.incrementX
                Me.DutyLabelCount += 1
            Next

            ' add the sub headings for duties
            Me.DutyLabelTop += 92
            Me.DutyLabelLeft = 125
            Me.RoleLabelCount += 1
        Next

    End Sub

    Private Sub ReadPlayerFile()
        Dim lineCounter As Integer = 0
        Dim IsFirst As Boolean = True

        FileOpen(1, Me.PlayerFile, OpenMode.Input)
        Do Until EOF(1)
            Dim PlayerDict = New Dictionary(Of String, String)
            Dim FullLine As String = LineInput(1).Replace("""", "")
            Dim LineArray = FullLine.Split(";")

            If IsFirst = True Then
                IsFirst = False
                Me.ColumnHeadings = LineArray
            Else
                Me.lstPlayers.Items.Add(LineArray(0))
                PlayerDict.Add("name", LineArray(0))
                PlayerDict.Add("positions", LineArray(3))

                Me.Players(lineCounter) = LineArray
                'Me.Players(lineCounter) = PlayerDict
                lineCounter = lineCounter + 1
            End If
        Loop
    End Sub

    Private Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileOpen.Click
        If dlgOpen.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim lineCounter As Integer = 0
            Dim IsFirst As Boolean = True

            Me.PlayerFile = dlgOpen.FileName
            Me.SetIniVars()
            Me.ReadPlayerFile()
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

    Private Sub lstPlayers_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstPlayers.SelectedIndexChanged
        ' Clear all previous player info
        If Me.tabDetails.TabPages.Count > 0 Then
            For i = Me.tabDetails.TabPages.Count - 1 To 0 Step -1
                Me.tabDetails.TabPages.RemoveAt(i)
            Next
            Me.TabPage = 0
        End If
        If Me.RoleLabelCount > 0 Then
            'label are set
            For i = 0 To Me.RoleLabelCount
                Me.RoleLabel(i) = Nothing
            Next
            For i = 0 To Me.DutyLabelCount
                Me.DutyLabel(i) = Nothing
            Next
            Me.RoleLabelCount = 0
            Me.DutyLabelCount = 0
            Me.RoleLabelTop = 46
            Me.lTop = 0
        End If
        Me.PlayerDetails = Me.Players(Me.lstPlayers.SelectedIndex)

        ' Display the player data in the panel
        ' First, set variables to hole array positions for various attribute sets
        Const PositionRatingStart As Integer = 20
        Const PositionRatingEnd As Integer = 34
        Const AttributeRatingStart As Integer = 35
        Const AttributeRatingEnd As Integer = 94

        Dim j As Integer = 0
        For i = PositionRatingStart To PositionRatingEnd
            Me.PositionRatings(j) = PlayerDetails(i)
            j = j + 1
        Next

        j = 0
        For i = AttributeRatingStart To AttributeRatingEnd
            Me.AttributeRatings(j) = PlayerDetails(i)
            j = j + 1
        Next

        For i = 0 To PositionRatings.Length - 1
            If PositionRatings(i) >= 15 Then
                Me.tabDetails.TabPages.Add(Me.ColumnHeadings(i + PositionRatingStart) + "(" + Str(PositionRatings(i)) + ")")
                Me.tabDetails.TabPages(Me.TabPage).Tag = Str(i + PositionRatingStart)
                ' Get the Roles and Duties for this Position
                Me.RoleLabelTop = 0
                Me.DutyLabelTop = 0
                Me.AddRoleLabels(Me.ColumnHeadings(i + PositionRatingStart))
                Me.TabPage += 1
            End If
        Next
    End Sub

    Private Sub SetIniVars()
        Dim sw As StreamWriter = New StreamWriter(Me.IniFile)
        sw.WriteLine(Me.PlayerFile)
        sw.Close()
    End Sub

    Private Sub GetIniVars()
        Dim sr As StreamReader = New StreamReader(Me.IniFile)
        Dim line As String
        Do
            line = sr.ReadLine()
            If Not line = Nothing Then
                Me.PlayerFile = line
            End If
        Loop Until line Is Nothing
        sr.Close()
    End Sub
End Class
