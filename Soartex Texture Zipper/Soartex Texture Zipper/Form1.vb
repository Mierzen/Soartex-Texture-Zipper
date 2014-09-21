Public Class Form1

    Private Sub btn_selectFolderToCompress_Click(sender As Object, e As EventArgs) Handles btn_selectFolderSource.Click
        FolderBrowserDialog_toZip.ShowDialog()
        If FolderBrowserDialog_toZip.SelectedPath <> "" Then
            tb_folderSource.Text = FolderBrowserDialog_toZip.SelectedPath
        End If
    End Sub

    Private Sub btn_selectFolderTarget_Click(sender As Object, e As EventArgs) Handles btn_selectFolderTarget.Click
        FolderBrowserDialog_toZip.ShowDialog()
        If FolderBrowserDialog_toZip.SelectedPath <> "" Then
            tb_folderTarget.Text = FolderBrowserDialog_toZip.SelectedPath
        End If
    End Sub

    Private Sub btn_run_Click(sender As Object, e As EventArgs) Handles btn_run.Click
        Dim dirSource As String = tb_folderSource.Text
        Dim dirTarget As String

        If dirSource = "" Then
            MsgBox("Select a folder to compress to a resource pack file", MsgBoxStyle.Exclamation, "Select folder to convert")
        Else

            If tb_folderTarget.Text = "" Then
                dirTarget = tb_folderSource.Text
            Else
                dirTarget = tb_folderTarget.Text
            End If

            makeResourcePack(dirSource, dirTarget)
        End If
    End Sub
End Class
