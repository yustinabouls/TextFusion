Option Strict On
Imports System.IO
Public Class frmtexteditorselectafiletoopen
    Dim ind As Byte = 0
    Public Property Url As String

    Private Sub frmtexteditorselectafiletoopen_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        Dim newForm As New frmtexteditorselectafiletoopen
        newForm.ShowDialog()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        SaveFileDialog1.Title = "Save Text Files"
        SaveFileDialog1.CheckFileExists = True
        SaveFileDialog1.CheckPathExists = True
        SaveFileDialog1.DefaultExt = "txt"
        SaveFileDialog1.Filter = "Text Files (*.txt)|*.txt|All Files (*.*|*.*"
        SaveFileDialog1.FilterIndex = 1
        SaveFileDialog1.RestoreDirectory = True

        Try
            RichTextBox1.SaveFile(SaveFileDialog1.FileName, RichTextBoxStreamType.PlainText)
        Catch ex As Exception
            Call SaveAsToolStripMenuItem_Click(Me, e)

        End Try
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(frmtexteditorselectafiletoopen As frmtexteditorselectafiletoopen, e As EventArgs)
        Throw New NotImplementedException()
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        SaveFileDialog1.Title = "Save Text Files"
        SaveFileDialog1.CheckFileExists = False
        SaveFileDialog1.CheckPathExists = False
        SaveFileDialog1.DefaultExt = "txt"
        SaveFileDialog1.Filter = "Text Files (*.txt)|*.txt|All Files (*.*|*.*"
        SaveFileDialog1.FilterIndex = 1
        SaveFileDialog1.RestoreDirectory = True

        If (SaveFileDialog1.ShowDialog() = DialogResult.OK) Then
            RichTextBox1.SaveFile(SaveFileDialog1.FileName, RichTextBoxStreamType.PlainText)
        End If

    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        Dim mystream As Stream = Nothing
        OpenFileDialog1.Filter = "Text Files (*.txt)|*.txt|All Files (*.*|*.*"
        OpenFileDialog1.FilterIndex = 1
        OpenFileDialog1.RestoreDirectory = True
        If (OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK) And (OpenFileDialog1.FileName.Length > 0) Then
            Try
                mystream = OpenFileDialog1.OpenFile
                If (mystream IsNot Nothing) Then
                    RichTextBox1.LoadFile(OpenFileDialog1.FileName, RichTextBoxStreamType.PlainText)
                    Url = OpenFileDialog1.FileName
                End If
            Catch ex As Exception
                MessageBox.Show("Cannot read file from disk. Original error." & ex.Message)
            Finally
                If (mystream IsNot Nothing) Then
                    ind = 1
                    mystream.Close()
                End If

            End Try

        End If
    End Sub

    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        If RichTextBox1.SelectionLength > 0 Then
            RichTextBox1.Copy()

        End If
    End Sub

    Private Sub CutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CutToolStripMenuItem.Click
        If RichTextBox1.SelectionLength > 0 Then
            RichTextBox1.Cut()

        End If
    End Sub

    Private Sub PasteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasteToolStripMenuItem.Click
        RichTextBox1.Paste()
    End Sub
End Class
