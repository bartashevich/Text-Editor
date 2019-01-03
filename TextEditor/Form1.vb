Imports System.IO

Public Class Form1
    Dim CurrentFileName As String = ""

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Untitled - TextEditor"
    End Sub

    Private Sub ToolStripButtonOpen_Click(sender As Object, e As EventArgs) Handles ToolStripButtonOpen.Click
        Dim oReader As StreamReader

        OpenFileDialog1.CheckFileExists = True
        OpenFileDialog1.CheckPathExists = True
        OpenFileDialog1.DefaultExt = "txt"
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
        OpenFileDialog1.Multiselect = False

        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            CurrentFileName = OpenFileDialog1.FileName
            Me.Text = CurrentFileName + " - TextEditor"
            oReader = New StreamReader(OpenFileDialog1.FileName, True)
            RichTextBox.Text = oReader.ReadToEnd
            oReader.Close()
        End If
    End Sub

    Private Sub ToolStripButtonSave_Click(sender As Object, e As EventArgs) Handles ToolStripButtonSave.Click
        If CurrentFileName Is "" Then
            SaveFileDialog1.Filter = "TXT Files (*.txt*)|*.txt"
            If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                CurrentFileName = SaveFileDialog1.FileName
                Me.Text = CurrentFileName + " - TextEditor"
            End If
        End If

        Dim oWriter As StreamWriter
        oWriter = New StreamWriter(CurrentFileName, False)
        oWriter.Write(RichTextBox.Text)
        oWriter.Close()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox.TextChanged

    End Sub
End Class
