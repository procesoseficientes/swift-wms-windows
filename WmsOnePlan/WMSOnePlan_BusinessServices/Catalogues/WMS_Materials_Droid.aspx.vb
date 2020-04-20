Imports System.IO
Imports System.Data.SqlClient
Imports System.Configuration.ConfigurationManager
Imports System.Data.OleDb
Imports System.Web.Script.Serialization
Imports System.Data
Imports System.Runtime.Serialization

Public Class WMS_Materials_Droid
    Inherits System.Web.UI.Page
    Public pResponse As String = ""
    Public pUri As String = ""
    Public pDfltEnv As String = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim pScanned As String = Request.QueryString("pSKU")
        Dim pACTION As String = Request.QueryString("pACTION")

        Dim pResult As String = ""
        Dim pSQL As String = ""
        Dim dt As DataSet
        Dim cmd As New SqlCommand
        cmd.CommandType = CommandType.Text

        Try
            Dim xserv As New WMS_Materials
            pDfltEnv = Request.QueryString("pENV")

            Select Case pACTION
                Case "GET"
                    dt = xserv.SearchByBarCodeMultipleClients(pScanned, pResult, pDfltEnv)
                    If pResult = "OK" Then
                        pResponse = GetJson(dt.Tables(0))
                    Else
                        pResponse = pResult
                    End If
                Case "POST"
                    If xserv.UpdateVolumeFactor(pScanned, 0, 0, 0, 0, pResult, pDfltEnv) Then

                    End If
            End Select

        Catch ex As Exception
            pResponse = "ERROR," + ex.Message
        End Try
    End Sub
    Public Function GetJson(ByVal dt As DataTable) As String

        Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
        Dim rows As New List(Of Dictionary(Of String, Object))
        Dim row As Dictionary(Of String, Object)

        For Each dr As DataRow In dt.Rows
            row = New Dictionary(Of String, Object)
            For Each col As DataColumn In dt.Columns
                row.Add(col.ColumnName, dr(col))
            Next
            rows.Add(row)
        Next

        Return serializer.Serialize(rows)
    End Function
End Class