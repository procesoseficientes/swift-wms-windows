Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Configuration.ConfigurationManager
Imports System.ComponentModel
Imports System.Data.SqlClient
Imports WMSOnePlan_BusinessServices.ModuleServices
Imports System.Web.Script.Serialization
Imports Newtonsoft.Json
Imports System.IO
' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
<System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class BASC_Forms
    Inherits System.Web.Services.WebService

    <WebMethod(Description:="GetQuestionInfo")> _
    Public Function GetQuestionInfo(ByVal pFormID As String, ByVal pQuestionGrp As String, ByVal pQuestionName As String, ByVal pEnvironmentName As String) As String
        Dim pResult As String = ""
        Dim sqldb_conexion As SqlConnection

        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Catch ex As Exception
            pResult = ex.Message + " " + pEnvironmentName
            Return pResult
        End Try

        Dim XSQL As String = ""
        Dim miscDA As SqlDataAdapter

        If pQuestionName <> "*" Then
            XSQL = "SELECT * FROM  " + DefaultSchema + "[OP_BASC_FUNC_GET_QUESTION]('" + pFormID + "','" + pQuestionGrp + "','" + pQuestionName + "')"
        Else
            XSQL = "SELECT * FROM  " + DefaultSchema + "[OP_BASC_FUNC_GET_QUESTIONS_ON_GROUP]('" + pFormID + "','" + pQuestionGrp + "')"
        End If

        Try
            miscDA = New SqlDataAdapter(XSQL, sqldb_conexion)
        Catch ex As Exception
            pResult = "GetQuestionInfo: " + ex.Message
            Return pResult
        End Try

        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "GetQuestionInfo")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return pResult
        End Try

        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR,No existe pregunta: " + pFormID + "/" + pQuestionGrp + "/" + pQuestionName
            LogSQLErrors(pResult, XSQL, "")
            Return pResult
        Else
            pResult = "OK"
            Return GetJson(miscDS.Tables(0))
        End If

    End Function
    <WebMethod(Description:="GetAllQuestions")> _
    Public Function GetAllQuestions(ByVal pEnvironmentName As String) As String
        Dim pResult As String = ""
        Dim sqldb_conexion As SqlConnection

        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Catch ex As Exception
            pResult = ex.Message + " " + pEnvironmentName
            Return pResult
        End Try

        Dim XSQL As String = ""
        Dim miscDA As SqlDataAdapter

        XSQL = "SELECT * FROM  " + DefaultSchema + "OP_BASC_FORMS WHERE QUESTION_GROUP <> 'ROOT' ORDER BY FORM_CODE, QUESTION_GROUP, QUESTION_ID"

        Try
            miscDA = New SqlDataAdapter(XSQL, sqldb_conexion)
        Catch ex As Exception
            pResult = "GetAllQuestions: " + ex.Message
            Return pResult
        End Try

        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "GetAllQuestions")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return pResult
        End Try

        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR,No existe preguntas"
            LogSQLErrors(pResult, XSQL, "")
            Return pResult
        Else
            pResult = "OK"
            Return GetJson(miscDS.Tables(0))
        End If

    End Function
    <WebMethod(Description:="GetQuestionInfo")> _
    Public Function GetFormDefinition(ByVal pFormID As String) As String
        Try
            Dim pResult As String = ""
            Dim pJsonFile As StreamReader = New StreamReader("C:\inetpub\wwwroot\Cealsa\Basc\form-" + pFormID + ".json")
            Dim pJsonStr As String = pJsonFile.ReadToEnd()
            pJsonFile.Close()
            Return pJsonStr
        Catch ex As Exception
            Return "GetFormDefinition: ERROR," + ex.Message
        End Try

    End Function

End Class