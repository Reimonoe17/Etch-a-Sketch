'Jamison Burton
'RCET0265
'Spring 2022
'Math Contest
'https://github.com/Reimonoe17/Etch-a-Sketch

Imports System.Math
Public Class Form1
    Dim currentColor As Color
    Private Sub GraphicsExamplesForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        currentColor = Color.Black
    End Sub

    Sub Sketch(startX As Integer, startY As Integer, endX As Integer, endY As Integer)
        Dim g As Graphics = DisplayPictureBox.CreateGraphics
        Dim pen As New Pen(Me.currentColor)
        'Static Dim oldX, oldY As Integer

        g.DrawLine(pen, startX, startY, endX, endY)
        'oldX = currentX
        'oldY = currentY

        g.Dispose()
        pen.Dispose()

    End Sub
    Private Sub GraphicsExamplesForm_MouseMove(sender As Object, e As MouseEventArgs) Handles DisplayPictureBox.MouseMove
        Static Dim oldX, oldY As Integer

        Me.Text = $"({e.X},{e.Y}{e.Button.ToString()})"

        Select Case e.Button.ToString
            Case "Left"
                Sketch(oldX, oldY, e.X, e.Y)
            Case "Right"
            Case "Middle"
                'ColorDialog1.ShowDialog()
                'Me.currentColor = ColorDialog1.Color
                Clear()
        End Select

        oldX = e.X
        oldY = e.Y

    End Sub
    Sub Clear()
        DisplayPictureBox.Refresh()
    End Sub
    Private Sub DrawWaveformButton_Click(sender As Object, e As EventArgs) Handles DrawWaveformButton.Click, DrawWaveformToolStripMenuItem.Click
        DrawSinWave()
    End Sub
    Private Sub ClearToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearToolStripMenuItem.Click, ClearButton.Click
        Clear()
    End Sub
    Private Sub SelectColorButton_Click(sender As Object, e As EventArgs) Handles SelectColorButton.Click, SelectColorToolStripMenuItem.Click
        ColorDialog.ShowDialog()
        Me.currentColor = ColorDialog.Color
    End Sub
    Sub DrawSinWave()
        Dim g As Graphics = DisplayPictureBox.CreateGraphics
        Dim pen As New Pen(Me.currentColor)
        Dim x, y, ymax, oldY, oldX As Integer
        ymax = 100
        x = 45

        'use system.math
        'degrees must be converted to radians deg * (PI/180)
        '
        For x = 0 To 360 Step 1
            y = CInt(((Floor(ymax * Sin(x * (PI / 180))) * -1) + ymax))
            Sketch(oldX, oldY, x, y)
            oldX = x
            oldY = y
        Next

        Console.WriteLine(ymax * Sin(x * (PI / 180)))

        Console.WriteLine(Floor((ymax * Sin(x * (PI / 180)))))


    End Sub

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub
End Class
