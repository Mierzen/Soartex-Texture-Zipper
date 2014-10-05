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

        'check for invalid user input
        If dirSource = "" Then
            str = "Select a folder to compress to a resource pack file."
            MsgBox(str, MsgBoxStyle.Exclamation Or MsgBoxStyle.MsgBoxSetForeground, "Select folder to convert")

            Exit Sub
        End If

        Dim validFolders As String = checkSource(dirSource)
        If validFolders = False Then
            str = "Select a valid folder to compress to a resource pack file." & vbNewLine & vbNewLine & "It should contain only an ""assets"" folder or subdirectories which contain ""assets"" folders."
            MsgBox(str, MsgBoxStyle.Exclamation Or MsgBoxStyle.MsgBoxSetForeground, "Invalid folder")

            Exit Sub
        End If

        'folder is valid. Go ahead
        If tb_folderTarget.Text = "" Then
            Dim result As MsgBoxResult
            result = MsgBox("Output to same folder as source?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo Or MsgBoxStyle.MsgBoxSetForeground Or MsgBoxStyle.ApplicationModal, "No output selected")
            If result = MsgBoxResult.Yes Then
                tb_folderTarget.Text = tb_folderSource.Text
            Else
                Exit Sub
            End If
        End If

        dirTarget = tb_folderTarget.Text

        Me.Enabled = False
        Cursor = Cursors.WaitCursor
        ToolStripStatusLabel_appVersion.Width -= ToolStripProgressBar_zipProgress.Width
        ToolStripProgressBar_zipProgress.Visible = True

        str = btn_run.Text
        btn_run.Text = "COMPRESSING"

        makeResourcePack(dirTarget)

        btn_run.Text = str
        Cursor = Cursors.Arrow
        ToolStripProgressBar_zipProgress.Visible = False
        ToolStripStatusLabel_appVersion.Width += ToolStripProgressBar_zipProgress.Width
        Me.Enabled = True
    End Sub

    Private Sub form_main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ToolStripStatusLabel_appVersion.Width += ToolStripProgressBar_zipProgress.Width

        Dim version As String
        version = "Version: " & My.Application.Info.Version.ToString

#If DEBUG Then
        version += "-dev"
#End If
        ToolStripStatusLabel_appVersion.Text = version
    End Sub
End Class
