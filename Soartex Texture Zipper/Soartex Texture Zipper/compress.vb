Imports System
Imports System.IO
Imports System.IO.Compression
Imports System.Text

Module compress

    Dim subDirsMain As String() = Nothing 'asset folder level

    Public Sub makeResourcePack(dirSource As String, dirTarget As String)
        Dim rpDirName As String
        rpDirName = extractName(dirSource)

        Try

            'create the pack.mcmeta file (temporary)
            createOrDeleteDescriptionFile(dirSource, replaceUnderscore(rpDirName))

            'get last modified version of the directory
            Dim ver As String = getVersion(dirSource)

            Dim rpFileNamePathTemp As String = My.Computer.FileSystem.SpecialDirectories.Temp & "\" & rpDirName & "-" & ver & ".zip"
            Dim rpFileNamePath As String = dirTarget & "\" & rpDirName & "-" & ver & ".zip"

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
                result = MsgBox(str, MsgBoxStyle.YesNoCancel, "File already exists")

                If result = vbYes Then
                    My.Computer.FileSystem.DeleteFile(rpFileNamePath)
                ElseIf result = vbCancel Then
                    Exit Sub
                ElseIf result = vbNo Then
                    form_main.Enabled = False
                    form_selectTarget.ShowDialog()
                    dirTarget = form_selectTarget.tb_folderTarget.Text
                    form_selectTarget.Close()
                    form_main.Enabled = True

                    rpFileNamePath = dirTarget & "\" & rpDirName & "-" & ver & ".zip"
                End If
            End If

            'Zip file WORKAROUND
            'check if WinRAR exist
            Dim winrarExists As Boolean
            Dim winrarPath As String
            winrarPath = "C:\Program Files\WinRAR\WinRAR.exe"

            If My.Computer.FileSystem.FileExists(winrarPath) = True Then : winrarExists = True
            Else : winrarExists = False
            End If

            If winrarExists = True Then
                If Strings.Right(dirSource, 1) <> "\" Then 'append "\" if needed, so that the folder contents is zipped and not the folder itself
                    dirSource += "\"
                End If

                Dim compress_process As System.Diagnostics.Process = New System.Diagnostics.Process()

                rpFileNamePathTemp = Strings.Left(rpFileNamePathTemp, Len(rpFileNamePathTemp) - 4)
                compress_process.StartInfo.FileName = winrarPath
                compress_process.StartInfo.Arguments = ("a -ep1 -r -afzip """ & rpFileNamePathTemp & """ """ & dirSource & """")
                compress_process.Start()
                compress_process.WaitForExit()
                rpFileNamePathTemp += ".zip"
            Else
                MsgBox("WinRAR isn't present." & vbNewLine & "The resource pack will still be created, however, you will have to rezip or extract the file for it to work.", _
                       vbExclamation, "WinRAR not present")
                ZipFile.CreateFromDirectory(dirSource, rpFileNamePathTemp)
            End If

            My.Computer.FileSystem.MoveFile(rpFileNamePathTemp, rpFileNamePath)

            'delete the temporary pack.mcmeta file
            My.Computer.FileSystem.DeleteFile(dirSource & "\pack.mcmeta")

            Beep()
            MsgBox("Done!", MsgBoxStyle.OkOnly)

        Catch ex As System.IO.IOException
            createOrDeleteDescriptionFile(dirSource, replaceUnderscore(rpDirName), True)
            MsgBox("The file is currently used by another process!" & vbNewLine & vbNewLine & "Please close the other process or try again.", MsgBoxStyle.Critical, "File is used by another process")
        End Try
    End Sub

    Private Function extractName(dir As String) As String
        Dim lastSlash As Integer = InStrRev(dir, "\")
        Dim len As Integer = Strings.Len(dir)

        Dim name As String = Right(dir, len - lastSlash)

        Return name
    End Function

    Private Function replaceUnderscore(name As String) As String
        name = Strings.Replace(name, Strings.ChrW(45), " ")
        name = Strings.Replace(name, Strings.ChrW(95), " ")

        Return name
    End Function

    Private Sub createOrDeleteDescriptionFile(dirTarget As String, rpName As String, Optional deleteOnly As Boolean = False) 'creates the pack.mcmeta
        Dim fileNamePath As String = dirTarget & "\pack.mcmeta"

        If My.Computer.FileSystem.FileExists(fileNamePath) = True Then
            My.Computer.FileSystem.DeleteFile(fileNamePath)
        End If

        If deleteOnly = True Then
            Exit Sub
        End If

        Dim fs As FileStream = File.Create(fileNamePath)

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
    End Sub

    Private Function getVersion(dir As String)
        Dim lastWritten As String
        lastWritten = My.Computer.FileSystem.GetDirectoryInfo(dir).LastWriteTime

        Return Left(lastWritten, 10)
    End Function

    Private Sub getSubDirs(dirToCheck As String, ByRef subDirArray() As String)
        Dim i As Integer = 0

        For Each foundDirectory In My.Computer.FileSystem.GetDirectories(dirToCheck, FileIO.SearchOption.SearchTopLevelOnly)
            ReDim subDirArray(i)
            subDirArray(i) = foundDirectory
            i += 1
        Next
    End Sub

    Public Function checkValidFolder(dir As String) As Boolean
        getSubDirs(dir, subDirsMain)

        If CInt(subDirsMain.Length) <> 1 Then 'the directory contains multiple sub directories
            Return False
        Else 'check if it contains only assets
            If checkForAssetsDir(subDirsMain(0)) = True Then
                Return True
            Else
                Return False
            End If
        End If
    End Function

    Private Function checkForAssetsDir(dir As String) As Boolean
        Dim match As Integer = InStrRev(dir, "assets")

        If match = 0 Then
            Return False
        Else
            Return True
        End If
    End Function
End Module
