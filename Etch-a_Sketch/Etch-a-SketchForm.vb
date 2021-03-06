'Jamison Burton
'RCET0265
'Spring 2022
'Math Contest
'https://github.com/Reimonoe17/Etch-a-Sketch

Imports System.Math
Public Class Form1
    'A global variable for the color
    Dim currentColor As Color
    'Automaticly sets to the pen color to black when program opens
    Private Sub GraphicsExamplesForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        currentColor = Color.Black
    End Sub
    'The primary subroutine for drawing
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
    'Button inputs given subroutines to run, such as sketch and ColorDialog
    Private Sub GraphicsExamplesForm_MouseMove(sender As Object, e As MouseEventArgs) Handles DisplayPictureBox.MouseMove
        Static Dim oldX, oldY As Integer

        Me.Text = $"({e.X},{e.Y}{e.Button.ToString()})"

        Select Case e.Button.ToString
            Case "Left"
                Sketch(oldX, oldY, e.X, e.Y)
            Case "Right"
                ContextMenuStrip1.Show()
            Case "Middle"
                ColorDialog.ShowDialog()
                Me.currentColor = ColorDialog.Color
        End Select

        oldX = e.X
        oldY = e.Y

    End Sub
    'clears the DisplayPictureBow of any sketchs
    Sub Clear()
        DisplayPictureBox.Refresh()
    End Sub
    'subroutine that draws a grid and three trinometric functions in different color. It saves the orignal color
    Private Sub DrawWaveformButton_Click(sender As Object, e As EventArgs) Handles DrawWaveformButton.Click, DrawWaveformToolStripMenuItem.Click
        Dim saveColor = currentColor
        DrawDivisions()
        currentColor = Color.Red
        DrawSinWave()
        currentColor = Color.Blue
        DrawCosWave()
        currentColor = Color.YellowGreen
        DrawTanWave()
        currentColor = saveColor
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

    Sub DrawCosWave()
        Dim g As Graphics = DisplayPictureBox.CreateGraphics
        Dim pen As New Pen(Me.currentColor)
        Dim x, y, ymax, oldY, oldX As Integer
        ymax = 100
        x = 45

        'use system.math
        'degrees must be converted to radians deg * (PI/180)
        '
        For x = 0 To 360 Step 1
            y = CInt(((Floor(ymax * Cos(x * (PI / 180))) * -1) + ymax))
            Sketch(oldX, oldY, x, y)
            oldX = x
            oldY = y
        Next

        Console.WriteLine(ymax * Cos(x * (PI / 180)))

        Console.WriteLine(Floor((ymax * Cos(x * (PI / 180)))))
    End Sub
    Sub DrawTanWave()
        Dim g As Graphics = DisplayPictureBox.CreateGraphics
        Dim pen As New Pen(Me.currentColor)
        Dim x, y, ymax, oldY, oldX As Integer
        ymax = 100
        x = 45

        'use system.math
        'degrees must be converted to radians deg * (PI/180)
        '
        For x = 0 To 360 Step 1
            Try
                y = CInt(((Floor(ymax * Tan(x * (PI / 180))) * -1) + ymax))
                Sketch(oldX, oldY, x, y)
                oldX = x
                oldY = y
            Catch ex As Exception
                Console.WriteLine("Infinite number detected")
                Console.WriteLine(ex.Message)
            End Try

        Next


    End Sub
    Sub DrawDivisions()
        Dim verticalDivisions As Integer = 10
        Dim horizontalDivisions As Integer = 10
        Dim saveColor = currentColor
        currentColor = Color.LightGray

        For v = 0 To 360 Step DisplayPictureBox.Width \ verticalDivisions
            Sketch(v, 0, v, DisplayPictureBox.Height)
        Next

        For h = 0 To 200 Step DisplayPictureBox.Height \ horizontalDivisions
            Sketch(0, h, DisplayPictureBox.Width, h)
        Next

        currentColor = saveColor
    End Sub
    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click, ExitToolStripMenuItem.Click
        Me.Close()
    End Sub
    'About message box
    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        MsgBox("This program is a simulation of an Etch-a-Sketch." & vbNewLine & "Prepared for: Tim Rossiter" & vbNewLine & "Prepared by: Jamison Burton")
    End Sub

End Class
