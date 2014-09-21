Public Class form_selectTarget

    Private Sub btn_selectFolderTarget_Click(sender As Object, e As EventArgs) Handles btn_selectFolderTarget.Click
        form_main.FolderBrowserDialog.ShowDialog()
        If form_main.FolderBrowserDialog.SelectedPath <> "" Then
            tb_folderTarget.Text = form_main.FolderBrowserDialog.SelectedPath
        End If
    End Sub

    Private Sub btn_run_Click(sender As Object, e As EventArgs) Handles btn_run.Click
        If tb_folderTarget.Text = "" Then
            Dim str As String
            str = "Select a valid destination folder."
            MsgBox(str, MsgBoxStyle.Exclamation, "Invalid folder")

            Exit Sub
        End If

        Me.Hide()
    End Sub
End Class