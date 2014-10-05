Imports System
Imports System.IO
Imports System.IO.Compression
Imports System.Text

Module compress

    Dim subDirs As String() = Nothing
    Dim subDirsValid As String() = Nothing
    Dim subDirsTemp As String() = Nothing

    Public Sub makeResourcePack(dirTarget As String)
        Try
            'check if WinRAR exist
            Dim winrarExists As Boolean
            Dim winrarPath As String
            winrarPath = "C:\Program Files\WinRAR\WinRAR.exe"

            If My.Computer.FileSystem.FileExists(winrarPath) = True Then
                winrarExists = True
            Else
                winrarExists = False
            End If

            Dim progressIncrement As Integer = Math.Round((form_main.ToolStripProgressBar_zipProgress.Maximum - form_main.ToolStripProgressBar_zipProgress.Value) * 1 / subDirsValid.Length, 0)

            For Each folder In subDirsValid

                trailingSlash("remove", folder)
                Dim rpDirNameUnderscore As String, rpDirNameSpaces As String
                rpDirNameUnderscore = extractName(folder)
                rpDirNameSpaces = replaceUnderscore(rpDirNameUnderscore)

                Try
                    folder = Left(folder, Len(folder) - 7)

                    trailingSlash("+", folder)
                    trailingSlash("+", dirTarget)

                    'delete the temporary pack.mcmeta and pack.png that might be left over from previous incomplete runs
                    createOrDeletePackFiles(folder, rpDirNameSpaces, True)

                    'get last modified version of the directory
                    Dim ver As String = getVersion(folder)

                    'create the pack.mcmeta and pack.png (temporary)
                    createOrDeletePackFiles(folder, rpDirNameSpaces)

                    Dim rpFileNamePathTemp As String = My.Computer.FileSystem.SpecialDirectories.Temp & "\" & rpDirNameUnderscore & "-" & ver & ".zip"
                    Dim rpFileNamePath As String = dirTarget & rpDirNameUnderscore & "-" & ver & ".zip"

                    'create the resource pack
                    'check if the zip already exists in the temp folder. If so, delete it
                    If My.Computer.FileSystem.FileExists(rpFileNamePathTemp) = True Then
                        My.Computer.FileSystem.DeleteFile(rpFileNamePathTemp)
                    End If

                    'check if the zip already exists in the target folder. If so, ask what to do
                    If My.Computer.FileSystem.FileExists(rpFileNamePath) = True Then
                        Dim str As String = "Resourcepack already exists in the target directory." & vbNewLine & vbNewLine & "Click ""Yes"" to replace the file." _
                                            & vbNewLine & "Click ""No"" to select a new target directory."
                        Dim result As MsgBoxResult
                        result = MsgBox(str, MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNoCancel Or MsgBoxStyle.MsgBoxSetForeground Or MsgBoxStyle.ApplicationModal, "File already exists")

                        If result = MsgBoxResult.Yes Then
                            My.Computer.FileSystem.DeleteFile(rpFileNamePath)
                        ElseIf result = vbCancel Then
                            Exit Sub
                        ElseIf result = MsgBoxResult.No Then
LineErr:
                            form_main.Enabled = False
                            form_selectTarget.ShowDialog()
                            If (form_selectTarget.tb_folderTarget.Text = dirTarget) Or (form_selectTarget.tb_folderTarget.Text = Left(dirTarget, Len(dirTarget) - 1)) Then
                                result = MsgBox("Please select a different folder, one where the file does not already exist.", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkCancel Or MsgBoxStyle.MsgBoxSetForeground Or MsgBoxStyle.ApplicationModal, _
                                       "Select a different folder")
                                If result = MsgBoxResult.Cancel Then
                                    Exit Sub
                                End If

                                form_selectTarget.tb_folderTarget.Text = ""

                                GoTo LineErr
                            Else
                                dirTarget = form_selectTarget.tb_folderTarget.Text
                            End If
                            form_selectTarget.Close()
                            form_main.Enabled = True

                            rpFileNamePath = dirTarget & rpDirNameUnderscore & "-" & ver & ".zip"
                        End If
                    End If

                    'Zip file WORKAROUND
                    If winrarExists = True Then
                        Dim compress_process As System.Diagnostics.Process = New System.Diagnostics.Process()

                        compress_process.StartInfo.FileName = winrarPath
                        compress_process.StartInfo.Arguments = ("a -ibck -ep1 -r -afzip """ & rpFileNamePathTemp & """ """ & folder & """")
                        compress_process.Start()
                        compress_process.WaitForExit()
                    Else
                        MsgBox("WinRAR isn't present." & vbNewLine & "The resource pack will still be created, however, you will have to rezip or extract the file for it to work.", _
                               MsgBoxStyle.Exclamation Or MsgBoxStyle.MsgBoxSetForeground Or MsgBoxStyle.ApplicationModal, "WinRAR not present")
                        ZipFile.CreateFromDirectory(folder, rpFileNamePathTemp)
                    End If

                    My.Computer.FileSystem.MoveFile(rpFileNamePathTemp, rpFileNamePath)

                    'delete the temporary pack.mcmeta and pack.png
                    createOrDeletePackFiles(folder, rpDirNameSpaces, True)

                    form_main.ToolStripProgressBar_zipProgress.Increment(progressIncrement)

                Catch ex As System.IO.IOException
                    createOrDeletePackFiles(folder, rpDirNameSpaces, True)
                    MsgBox("The file is currently used by another process!" & vbNewLine & vbNewLine & "Please close the other process or try again.", MsgBoxStyle.Critical Or MsgBoxStyle.MsgBoxSetForeground, "File is used by another process")
                End Try

            Next

            Beep()
            Dim openTargetDir As MsgBoxResult
            openTargetDir = MsgBox("Done!" & vbNewLine & vbNewLine & "Open Explorer to view the resource pack?", _
                                   MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.MsgBoxSetForeground)
            If openTargetDir = MsgBoxResult.Yes Then
                Diagnostics.Process.Start("Explorer.exe", subDirsValid(0))
            End If

        Catch ex As System.IO.DirectoryNotFoundException
            invalidFolder()

        Catch ex As System.ArgumentException
            invalidFolder()
        End Try
    End Sub

    Private Sub trailingSlash(mode As String, ByRef dir As String)
        If mode = "add" Or mode = "append" Or mode = "+" Then

            If Strings.Right(dir, 1) <> "\" Then 'append "\" if needed
                dir += "\"
            End If

        ElseIf mode = "remove" Or mode = "delete" Or mode = "-" Then

            If Strings.Right(dir, 1) = "\" Then 'remove "\" if needed
                dir = Left(dir, Len(dir) - 1)
            End If

        End If
    End Sub

    Private Function extractName(dir As String) As String
        dir = Strings.Left(dir, Len(dir) - 7)

        Dim lastSlash As Integer = InStrRev(dir, "\")

        Dim name As String = Right(dir, Len(dir) - lastSlash)

        Return name
    End Function

    Private Function replaceUnderscore(name As String) As String
        name = Strings.Replace(name, Strings.ChrW(45), " ")
        name = Strings.Replace(name, Strings.ChrW(95), " ")

        Return name
    End Function

    Private Sub createOrDeletePackFiles(dirTarget As String, rpName As String, Optional deleteOnly As Boolean = False) 'creates the pack.mcmeta
        Dim pathMeta As String = dirTarget & "pack.mcmeta"

        If My.Computer.FileSystem.FileExists(pathMeta) = True Then
            My.Computer.FileSystem.DeleteFile(pathMeta)
        End If
        If My.Computer.FileSystem.FileExists(dirTarget & "pack.png") = True Then
            My.Computer.FileSystem.DeleteFile(dirTarget & "pack.png")
        End If

        If deleteOnly = True Then
            Exit Sub
        End If

        'Create pack.mcmeta
        Dim fs As FileStream = File.Create(pathMeta)

        Dim str As String
        Dim tab As String = "   "
        str = "{" & vbNewLine & _
            tab & """pack"":{" & vbNewLine & _
            tab & tab & """pack_format"":1," & vbNewLine & _
            tab & tab & """description"":""" & rpName & """" & vbNewLine & _
            tab & "}" & vbNewLine & _
              "}"

        Dim info As Byte() = New UTF8Encoding(True).GetBytes(str)
        fs.Write(info, 0, info.Length)
        fs.Close()

        'Create pack.png
        My.Resources.pack.Save(dirTarget & "pack.png")
    End Sub

    Private Function getVersion(dir As String)
        Dim folder As New DirectoryInfo(dir)
        Dim newestFile As FileInfo = Nothing
        Dim lastWritten As String

        For Each finfo In folder.EnumerateFiles("*.*", SearchOption.AllDirectories)
            If finfo.Extension = ".png" Or finfo.Extension = ".ogg" Then
                If newestFile Is Nothing OrElse finfo.LastWriteTime >= newestFile.LastWriteTime Then
                    newestFile = finfo
                End If
            End If
        Next

        If IsNothing(newestFile) Then
            Return ""
        End If

        lastWritten = newestFile.LastWriteTime

        Return Left(lastWritten, 10)
    End Function

    Private Function getSubDirs(dirToCheck As String, ByRef subDirArray() As String) As Boolean
        Dim i As Integer = 0

        For Each foundDirectory In My.Computer.FileSystem.GetDirectories(dirToCheck, FileIO.SearchOption.SearchTopLevelOnly)
            ReDim Preserve subDirArray(i)
            subDirArray(i) = foundDirectory
            i += 1
        Next

        If i = 0 Then
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub addToArray(str As String, ByRef arr() As String)
        If IsNothing(arr) = True Then
            ReDim Preserve arr(0)
            arr(0) = str
            Exit Sub
        End If

        ReDim Preserve arr(arr.Length)
        arr(arr.Length - 1) = str
    End Sub

    Private Sub getValidSubDirs(ByVal subDirArrayToCheck() As String, ByRef subDirToSaveTo() As String)
        'the dir can either already just have an "assets" folder, or it can have multiple folders, each with its own "assets" folder
        For Each folder In subDirArrayToCheck
            If checkForAssetsDir(folder) = True Then 'contains only assets

                addToArray(folder, subDirsValid)

            Else 'the directory contains multiple sub directories

                Dim hasSubs As Boolean = getSubDirs(folder, subDirsTemp)

                If hasSubs = True Then
                    getValidSubDirs(subDirsTemp, subDirsValid)
                    subDirsTemp = Nothing
                End If

            End If

        Next


    End Sub

    Public Function checkSource(dir As String) As String
        Try
            Dim hasSubs As Boolean = getSubDirs(dir, subDirs)

            If hasSubs = False Then
                Return False
            End If

            getValidSubDirs(subDirs, subDirsValid)
            Array.Sort(Of String)(subDirsValid)

            Return subDirsValid.Length

        Catch ex As System.IO.DirectoryNotFoundException
            invalidFolder()
            Return False

        Catch ex As System.ArgumentException
            invalidFolder()
            Return False
        End Try
    End Function

    Private Function checkForAssetsDir(dir As String) As Boolean
        Dim match As Integer = InStrRev(dir, "assets")

        If match = 0 Then
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub invalidFolder()
        MsgBox("Please enter a valid folder path.", MsgBoxStyle.Critical Or MsgBoxStyle.MsgBoxSetForeground, "Invalid path")
    End Sub
End Module
