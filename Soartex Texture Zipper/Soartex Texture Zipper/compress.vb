Imports System
Imports System.IO
Imports System.IO.Compression
Imports System.Text

Module compress
    Public Sub makeResourcePack(dirSource As String, dirTarget As String)
        Dim rpName As String
        rpName = extractName(dirSource)

        'create the pack.mcmeta file (temporary)
        createDescriptionFile(dirTarget, rpName)

        'get last modified version of the directory
        Dim ver As String = getVersion(dirSource)

        'create the resource pack
        ZipFile.CreateFromDirectory(dirSource, My.Computer.FileSystem.SpecialDirectories.Temp & "\" & rpName & "-" & ver & ".zip")
        My.Computer.FileSystem.MoveFile(My.Computer.FileSystem.SpecialDirectories.Temp & "\" & rpName & "-" & ver & ".zip", dirSource & "\" & rpName & "-" & ver & ".zip")

        'delete the temporary pack.mcmeta file
        My.Computer.FileSystem.DeleteFile(dirSource & "\pack.mcmeta")

        MsgBox("Done!", MsgBoxStyle.OkOnly)
    End Sub

    Private Function extractName(dir As String) As String
        Dim lastSlash As Integer = InStrRev(dir, "\")
        Dim len As Integer = Strings.Len(dir)

        Dim name As String = Right(dir, len - lastSlash)

        Return name
    End Function

    Private Sub createDescriptionFile(dirTarget As String, rpName As String) 'creates the pack.mcmeta
        Dim fs As FileStream = File.Create(dirTarget & "\pack.mcmeta")

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

    Public Function checkValidFolder(dir As String) As Boolean
        Dim i As Integer = 0
        Dim subDirs As String() = Nothing

        For Each foundDirectory In My.Computer.FileSystem.GetDirectories(dir, FileIO.SearchOption.SearchTopLevelOnly)
            ReDim subDirs(i)
            subDirs(i) = foundDirectory
            i += 1
        Next

        If i <> 0 + 1 Then 'the directory contains multiple sub directories
            Return False
        Else 'check if it contains only assets
            If checkForAssetsDir(subDirs(0)) = True Then
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
