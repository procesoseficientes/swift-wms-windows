Imports System.IO
Public Class postimage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not elementsImagerFile.PostedFile Is Nothing Then
            Dim myFile As HttpPostedFile = elementsImagerFile.PostedFile

            ' Get size of uploaded file
            Dim nFileLen As Integer = myFile.ContentLength
            If (nFileLen > 0) Then
                Dim myData(nFileLen) As Byte
                myFile.InputStream.Read(myData, 0, nFileLen)
                Dim strFilename As String = Path.GetFileName(myFile.FileName)

                WriteToFile(Server.MapPath(strFilename), myData)
                Response.Write("File Received")


            End If

        End If


    End Sub
    Sub WriteToFile(strPath As String, Buffer As Byte())
        Try
            Dim newFile As FileStream = New FileStream(strPath, FileMode.Create)
            newFile.Write(Buffer, 0, Buffer.Length)
            newFile.Close()

        Catch ex As Exception

        End Try
    End Sub

End Class