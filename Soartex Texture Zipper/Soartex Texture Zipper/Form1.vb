Public Class form_main

    Private Sub btn_selectFolderToCompress_Click(sender As Object, e As EventArgs) Handles btn_selectFolderSource.Click
        FolderBrowserDialog.ShowDialog()
        If FolderBrowserDialog.SelectedPath <> "" Then
            tb_folderSource.Text = FolderBrowserDialog.SelectedPath
        End If
    End Sub

    Private Sub btn_selectFolderTarget_Click(sender As Object, e As EventArgs) Handles btn_selectFolderTarget.Click
        FolderBrowserDialog.ShowDialog()
        If FolderBrowserDialog.SelectedPath <> "" Then
            tb_folderTarget.Text = FolderBrowserDialog.SelectedPath
        End If
    End Sub

    Private Sub btn_run_Click(sender As Object, e As EventArgs) Handles btn_run.Click
        Dim dirSource As String = tb_folderSource.Text
        Dim dirTarget As String
        Dim str As String

        If dirSource = "" Then
            str = "Select a folder to compress to a resource pack file"
            MsgBox(str, MsgBoxStyle.Exclamation, "Select folder to convert")
        Else
            If checkValidFolder(dirSource) = False Then
                str = "Select a valid folder to compress to a resource pack file." & vbNewLine & vbNewLine & "It should contain only an ""assets"" folder."
                MsgBox(str, MsgBoxStyle.Exclamation, "Invalid folder")
            Else
                If tb_folderTarget.Text = "" Then
                    dirTarget = tb_folderSource.Text
                Else
                    dirTarget = tb_folderTarget.Text
                End If

                Me.Enabled = False
                Cursor = Cursors.WaitCursor

                str = btn_run.Text
                btn_run.Text = "COMPRESSING"

                makeResourcePack(dirSource, dirTarget)

                btn_run.Text = str
                Cursor = Cursors.Arrow
                Me.Enabled = True
            End If
        End If
    End Sub
End Class
