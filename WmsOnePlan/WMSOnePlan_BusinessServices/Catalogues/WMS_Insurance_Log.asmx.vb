Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Configuration.ConfigurationManager
Imports System.ComponentModel
Imports System.Data.SqlClient
Imports WMSOnePlan_BusinessServices.ModuleServices
Imports System.Web.Script.Services

' Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class WMS_Insurance_Log
    Inherits System.Web.Services.WebService

    <WebMethod(Description:="Create a Insurance log")> _
    Public Function CreateInsuranceLog(ByVal pDocId As Integer, ByVal pLastUpdatedBy As String, ByVal pLastAmount As Decimal, ByVal pLastCoverage As String, ByVal pCurrentAmount As Decimal, ByVal pCurrentCoverage As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        Dim strSql As New StringBuilder
        Try

            strSql.Append(String.Format(" INSERT INTO {0}OP_WMS_INSURANCE_LOG(", DefaultSchema))
            strSql.Append(" DOC_ID")
            strSql.Append(" , LAST_UPDATED_BY")
            strSql.Append(" , LAST_UPDATED")
            strSql.Append(" , LAST_AMOUNT")
            strSql.Append(" , LAST_COVERAGE")
            strSql.Append(" , CURRENT_AMOUNT")
            strSql.Append(" , CURRENT_CIVERAGE")
            strSql.Append(" ) VALUES(")
            strSql.Append(String.Format(" {0}", pDocId))
            strSql.Append(String.Format(" , '{0}'", pLastUpdatedBy))
            strSql.Append(" , GetDate()")
            strSql.Append(String.Format(" , '{0}'", pLastAmount))
            strSql.Append(String.Format(" , '{0}'", pLastCoverage))
            strSql.Append(String.Format(" , '{0}'", pCurrentAmount))
            strSql.Append(String.Format(" , '{0}'", pCurrentCoverage))
            strSql.Append(")")

            If ExecuteSqlTransaction(sqldb_conexion.ConnectionString, strSql.ToString, pResult) Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            pResult = ex.Message
            Return False
        End Try
    End Function

End Class