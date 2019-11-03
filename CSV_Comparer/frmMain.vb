Imports System.IO
Imports System.Text
Imports System.Threading
Imports F23.StringSimilarity

Public Class frmMain

    '    MetroFramework - Windows Modern UI for .NET WinForms Applications

    'Copyright (c) 2013 Jens Thiel, http//thielj.github.com/MetroFramework

    'Permission Is hereby granted, free of charge, to any person obtaining a copy of 
    'this software And associated documentation files (the "Software"), To deal In the 
    'Software without restriction, including without limitation the rights To use, copy, 
    'modify, merge, publish, distribute, sublicense, And/Or sell copies of the Software, 
    'And to permit persons to whom the Software Is furnished to do so, subject to the 
    'following conditions:

    'The above copyright notice And this permission notice shall be included In 
    'all copies Or substantial portions Of the Software.

    'THE SOFTWARE Is PROVIDED "AS IS", WITHOUT WARRANTY Of ANY KIND, EXPRESS Or IMPLIED, 
    'INCLUDING BUT Not LIMITED To THE WARRANTIES Of MERCHANTABILITY, FITNESS For A 
    'PARTICULAR PURPOSE And NONINFRINGEMENT. In NO Event SHALL THE AUTHORS Or COPYRIGHT 
    'HOLDERS BE LIABLE For ANY CLAIM, DAMAGES Or OTHER LIABILITY, WHETHER In AN ACTION Of 
    'CONTRACT, TORT Or OTHERWISE, ARISING FROM, OUT OF Or IN CONNECTION WITH THE SOFTWARE 
    'Or THE USE Or OTHER DEALINGS IN THE SOFTWARE.

    Dim m_CSV1()() As String
    Dim m_CSV2()() As String
    Dim m_Column1, m_Column2, m_Progress As Integer
    Dim m_Separator As Char

    Dim m_inThread As Boolean
    Dim m_thread As New Thread(AddressOf Compare)

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        cboCSV1.SelectedIndex = 0
        cboCSV2.SelectedIndex = 0

        If tbValue.Value = 10 Then
            MetroToolTip1.SetToolTip(tbValue, "max. distance: infinity")
        Else
            MetroToolTip1.SetToolTip(tbValue, "max. distance: " & tbValue.Value)
        End If


    End Sub

    Private Sub tbValue_MouseUp(sender As Object, e As MouseEventArgs) Handles tbValue.MouseUp

        If tbValue.Value = 10 Then
            MetroToolTip1.SetToolTip(tbValue, "max. distance: infinity")
            MetroToolTip1.Show("max. distance:  infinity", tbValue)
        Else
            MetroToolTip1.SetToolTip(tbValue, "max. distance: " & tbValue.Value)
            MetroToolTip1.Show("max. distance:  " & tbValue.Value, tbValue)
        End If


    End Sub


    Public Function ReadCSV(ByVal file As String) As String()()

        Dim comma, semicolon, colon As Integer


        If IO.File.Exists(file) Then

            Dim lines As String() = IO.File.ReadAllLines(file)

            'Solution for the Encoding-Problem
            For Each l In lines
                If l.Contains("�") Then
                    lines = IO.File.ReadAllLines(file, Encoding.Default)
                    Exit For
                End If
            Next


            Dim parts As String()() = New String(lines.Length - 1)() {}


            ' Get separator and check if each row in the csv have the same amount of separator. 
            Dim max, tmp As Integer

            For i As Integer = 0 To lines.Length - 1
                If i = 0 Then
                    comma = lines(i).Split(","c).Count
                    semicolon = lines(i).Split(";"c).Count
                    colon = lines(i).Split(":"c).Count

                    If (comma > semicolon) And (comma > colon) Then
                        m_Separator = ","
                    ElseIf (semicolon > comma) And (semicolon > colon) Then
                        m_Separator = ";"
                    Else
                        m_Separator = ":"
                    End If

                    max = lines(i).Split(m_Separator).Count
                End If

                tmp = lines(i).Split(m_Separator).Count

                If tmp > max Then
                    max = tmp
                End If

            Next

            For i = 0 To lines.Length - 1

                'Add separator in row [i] if the amount is lower than the max amount of separator in a specific row in the csv
                Dim c As Integer = lines(i).Split(m_Separator).Count
                For j = c To max - 1
                    lines(i) = lines(i) & m_Separator
                Next

                'Split in two dimension array
                parts(i) = lines(i).Split(m_Separator)
            Next

            Return parts
        Else
            Throw New FileNotFoundException()
        End If
    End Function



    Private Sub btnCSV1_Click(sender As Object, e As EventArgs) Handles btnCSV1.Click

        ChooseCSV(m_CSV1, cboCSV1)

    End Sub


    Private Sub btnCSV2_Click(sender As Object, e As EventArgs) Handles btnCSV2.Click

        ChooseCSV(m_CSV2, cboCSV2)

    End Sub

    Private Sub ChooseCSV(ByRef in_StringArray()() As String, in_Combobox As MetroFramework.Controls.MetroComboBox)
        Try
            Using ofd1 As New OpenFileDialog

                With ofd1

                    .Filter = "csv files (*.csv)|*.csv"
                    .Title = "Open csv file"
                    .Multiselect = False

                    If .ShowDialog() = DialogResult.OK Then

                        in_StringArray = ReadCSV(.FileName)
                        FillComboboxWithColumnFromCSV(in_Combobox, in_StringArray(0).Length)

                    End If

                End With
            End Using

        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, vbCrLf & "The csv you choose is not valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub FillComboboxWithColumnFromCSV(ByVal in_Combobox As MetroFramework.Controls.MetroComboBox, ByVal in_Anzahl As Integer)
        in_Combobox.Items.Clear()
        in_Combobox.Items.Add("Choose a column to compare")
        in_Combobox.SelectedIndex = 0

        For i = 1 To in_Anzahl
            in_Combobox.Items.Add(i.ToString & ". column")
        Next
    End Sub


    Private Sub btnCompare_Click(sender As Object, e As EventArgs) Handles btnCompare.Click

        If m_inThread Then
            m_inThread = False
            m_thread.Abort()
            btnCompare.Text = "Compare and Merge"
            mpWaiting.Visible = False
            Me.Cursor = Cursors.Default

        Else

            If m_CSV1 Is Nothing Or m_CSV2 Is Nothing Then
                MetroFramework.MetroMessageBox.Show(Me, vbCrLf & "Please choose a CSV1 and CSV2.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ElseIf cboCSV1.SelectedIndex < 1 Or cboCSV2.SelectedIndex < 1 Then

                MetroFramework.MetroMessageBox.Show(Me, vbCrLf & "Please choose a column for CSV1 and CSV2 to compare and merge.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else


                m_Column1 = cboCSV1.SelectedIndex
                m_Column2 = cboCSV2.SelectedIndex

                mpWaiting.Visible = True
                btnCompare.Text = "Cancel"
                m_inThread = True


                m_thread = New Thread(AddressOf Compare)

                m_thread.SetApartmentState(ApartmentState.STA)
                m_thread.Start()

            End If
        End If


    End Sub

    Private Sub Compare()

        'The MIT License (MIT)

        'Copyright(c) 2015 feature[23]

        'Permission Is hereby granted, free Of charge, to any person obtaining a copy
        'of this software And associated documentation files (the "Software"), to deal
        'in the Software without restriction, including without limitation the rights
        'to use, copy, modify, merge, publish, distribute, sublicense, And/Or sell
        'copies of the Software, And to permit persons to whom the Software Is
        'furnished to do so, subject to the following conditions

        'The above copyright notice And this permission notice shall be included in all
        'copies Or substantial portions of the Software.

        'THE SOFTWARE Is PROVIDED "AS IS", WITHOUT WARRANTY Of ANY KIND, EXPRESS Or
        'IMPLIED, INCLUDING BUT Not LIMITED To THE WARRANTIES Of MERCHANTABILITY,
        'FITNESS FOR A PARTICULAR PURPOSE And NONINFRINGEMENT. IN NO EVENT SHALL THE
        'AUTHORS Or COPYRIGHT HOLDERS BE LIABLE For ANY CLAIM, DAMAGES Or OTHER
        'LIABILITY, WHETHER In AN ACTION Of CONTRACT, TORT Or OTHERWISE, ARISING FROM,
        'OUT OF Or IN CONNECTION WITH THE SOFTWARE Or THE USE Or OTHER DEALINGS IN THE
        'SOFTWARE.

        'Portions of this code are licensed And copyright as follows

        'Copyright 2015 Thibault Debatty.

        'Permission Is hereby granted, free Of charge, to any person obtaining
        'a copy of this software And associated documentation files (the
        '"Software"), to deal in the Software without restriction, including
        'without limitation the rights To use, copy, modify, merge, publish,
        'distribute, sublicense, And/Or sell copies Of the Software, And to
        'permit persons To whom the Software Is furnished To Do so, subject to
        'the following conditions

        'The above copyright notice And this permission notice shall be
        'included in all copies Or substantial portions of the Software.

        'THE SOFTWARE Is PROVIDED "AS IS", WITHOUT WARRANTY Of ANY KIND,
        'EXPRESS Or IMPLIED, INCLUDING BUT Not LIMITED TO THE WARRANTIES OF
        'MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE And
        'NONINFRINGEMENT.IN NO EVENT SHALL THE AUTHORS Or COPYRIGHT HOLDERS BE
        'LIABLE FOR ANY CLAIM, DAMAGES Or OTHER LIABILITY, WHETHER IN AN ACTION
        'OF CONTRACT, TORT Or OTHERWISE, ARISING FROM, OUT OF Or IN CONNECTION
        'With THE SOFTWARE Or THE USE Or OTHER DEALINGS In THE SOFTWARE.

        Dim cp As New QGram(1)
        Dim result()() As Integer = New Integer(m_CSV1.Length - 1)() {}


        Dim bestDistance, currentDistance, bestRow, distance As Integer
        Dim s1, s2 As String


        If tbValue.Value = 20 Then
            distance = 99999
        Else
            distance = tbValue.Value
        End If



        For i = 1 To m_CSV1.Length


            m_Progress = 100 / m_CSV1.Length * i
            MetroProgressBar1.BeginInvoke(Sub()
                                              MetroProgressBar1.Value = m_Progress
                                              Me.Cursor = Cursors.WaitCursor
                                          End Sub)

            bestDistance = -1
            bestRow = -1

            For j = 1 To m_CSV2.Length

                s1 = m_CSV1(i - 1)(m_Column1 - 1)
                s2 = m_CSV2(j - 1)(m_Column2 - 1)

                currentDistance = cp.Distance(s1, s2)

                '  Console.WriteLine(s1 & " >> " & s2 & " >> " & currentDistance.ToString)

                If currentDistance <= distance Then

                    If bestDistance = -1 Then
                        bestDistance = currentDistance
                        bestRow = j - 1
                    End If

                    If j = 1 Then
                        bestDistance = currentDistance
                        bestRow = j - 1
                    ElseIf currentDistance < bestDistance Then
                        bestDistance = currentDistance
                        bestRow = j - 1
                    End If
                End If

            Next
            result(i - 1) = {bestRow, bestDistance}

        Next

        Dim merge(m_CSV1.Length - 1)() As String

        For i = 0 To m_CSV1.Length - 1
            If result(i)(0) = -1 Then
                merge(i) = m_CSV1(i)
            Else
                merge(i) = MergeArray(m_CSV1(i), m_CSV2(result(i)(0)))
            End If

        Next

        If mpWaiting.InvokeRequired Then
            mpWaiting.Invoke(Sub()
                                 mpWaiting.Visible = False
                             End Sub)
        Else
            mpWaiting.Visible = False
        End If


        If btnCompare.InvokeRequired Then
            btnCompare.Invoke(Sub()
                                  btnCompare.Text = "Compare and Merge"
                                  Me.Cursor = Cursors.Default
                              End Sub)
        Else
            btnCompare.Text = "Compare and Merge"
        End If
        m_inThread = False


        Using sfd As New SaveFileDialog
            With sfd
                .Filter = "csv files ';;;' (*.csv)|*.csv|csv files ',,,' (*.csv)|*.csv|csv files ':::' (*.csv)|*.csv"
                .Title = "Save csv file"

                If m_Separator = ";" Then
                    .FilterIndex = 1
                ElseIf m_Separator = "," Then
                    .FilterIndex = 2
                Else
                    .FilterIndex = 3
                End If

                If .ShowDialog() = DialogResult.OK Then

                    If .FilterIndex = 1 Then
                        SaveCSV(.FileName, merge, ";")
                    ElseIf .FilterIndex = 2 Then
                        SaveCSV(.FileName, merge, ",")
                    ElseIf .FilterIndex = 3 Then
                        SaveCSV(.FileName, merge, ":")
                    End If


                    BeginInvoke(Sub()
                                    MetroFramework.MetroMessageBox.Show(Me, vbCrLf & "Finished! Your file: " & .FileName, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                End Sub)

                End If
            End With
        End Using

    End Sub


    Private Function MergeArray(ByVal in_S1() As String, ByVal in_S2() As String) As String()

        Dim list = New List(Of String)()

        For i As Integer = 0 To in_S1.Length - 1
            list.Add(in_S1(i))
        Next

        For i As Integer = 0 To in_S2.Length - 1
            list.Add(in_S2(i))
        Next

        Dim array3 As String() = list.ToArray()
        Return array3

    End Function



    Private Sub SaveCSV(ByVal in_Path As String, ByVal in_String()() As String, ByVal in_Separator As Char)
        Dim file As New FileStream(in_Path, FileMode.Create, FileAccess.ReadWrite)
        Dim stream As StreamWriter = New StreamWriter(file, Encoding.Default)
        Try


            For i = 0 To in_String.Length - 1
                For j = 0 To in_String(i).Length - 1
                    stream.Write(in_String(i)(j))

                    If j < (in_String(i).Length - 1) Then
                        stream.Write(in_Separator)
                    End If

                Next
                stream.Write(vbLf)
            Next

        Catch ex As Exception

        Finally
            Stream.Close()
        End Try


    End Sub
End Class
