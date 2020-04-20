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
Public Class WMS_Insurance_Companies
    Inherits System.Web.Services.WebService

    <BrowsableAttribute(True)> _
    Public EnvironmentName As String

    <WebMethod(Description:="Create a Insurance Companies")> _
    Public Function CreateInsuranceCompany(ByVal pCompanyId As String, ByVal pCompanyName As String, ByVal pCreateBy As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        Dim strSql As New StringBuilder
        Try

            strSql.Append(String.Format(" INSERT INTO {0}OP_WMS_INSURANCE_COMPANIES(", DefaultSchema))
            strSql.Append(" COMPANY_ID")
            strSql.Append(" , COMPANY_NAME")
            strSql.Append(" , CREATED_DATE")
            strSql.Append(" , CREATED_BY")
            strSql.Append(" ) VALUES(")
            strSql.Append(String.Format(" '{0}'", pCompanyId))
            strSql.Append(String.Format(" , '{0}'", pCompanyName))
            strSql.Append(String.Format(" , GetDate()"))
            strSql.Append(String.Format(" , '{0}'", pCreateBy))
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

    <WebMethod(Description:="Update a Insurance Companies")> _
    Public Function UpdateInsuranceCompany(ByVal pCompanyId As String, ByVal pCompanyName As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        Dim strSql As New StringBuilder
        Try

            strSql.Append(String.Format(" UPDATE {0}OP_WMS_INSURANCE_COMPANIES SET", DefaultSchema))
            strSql.Append(String.Format(" COMPANY_NAME = '{0}'", pCompanyName))
            strSql.Append(String.Format(" WHERE COMPANY_ID = '{0}'", pCompanyId))


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

    <WebMethod(Description:="Delete a Insurance Companies")> _
    Public Function DeleteInsuranceCompany(ByVal pCompanyId As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        Dim strSql As New StringBuilder
        Try

            strSql.Append(String.Format(" DELETE {0}OP_WMS_INSURANCE_COMPANIES", DefaultSchema))
            strSql.Append(String.Format(" WHERE COMPANY_ID = '{0}'", pCompanyId))

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

    <WebMethod(Description:="Get a Insurance Company")> _
    Public Function GetInsuranceCompany(ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet

        Dim XSQL As String = ""
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim xbarcode As String = ""

        XSQL = String.Format("SELECT COMPANY_ID, COMPANY_NAME FROM {0}OP_WMS_INSURANCE_COMPANIES", DefaultSchema)


        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "SearchByBarCode")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR, No existen encontraron registros."
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function

    <WebMethod(Description:="Fill a Insurance Company")> _
    Public Function FillInsuranceCompany(ByVal pCompanyId As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet

        Dim XSQL As String = ""
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim xbarcode As String = ""

        XSQL = String.Format("SELECT COMPANY_ID, COMPANY_NAME, CREATED_DATE, CREATED_BY FROM {0}OP_WMS_INSURANCE_COMPANIES WHERE COMPANY_ID = '{1}'", DefaultSchema, pCompanyId)


        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "FillInsuranceCompany")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR, No se encontro el registro."
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function

    <WebMethod(Description:="Mira si ya existe el insurance companie")> _
    Public Function Exist_Insurance_Companie(ByVal pCompanyId As String, ByVal pEnvironmentName As String, ByRef pResult As String) As DataSet

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)


        Dim strSql As New StringBuilder
        strSql.Append(" SELECT")
        strSql.Append(" COUNT(*)")
        strSql.Append(String.Format(" FROM {0}OP_WMS_INSURANCE_COMPANIES", DefaultSchema))
        strSql.Append(String.Format(" WHERE COMPANY_ID = '{0}'", pCompanyId))

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "ExistInsuranceCompanie")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR, No se encontro el registro."
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If
    End Function

End Class