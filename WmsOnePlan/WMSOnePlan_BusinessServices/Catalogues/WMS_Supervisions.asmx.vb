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
Public Class WMS_Supervisions
    Inherits System.Web.Services.WebService

    <WebMethod(Description:="Create a supervision")> _
    Public Function CreateSupervisions(ByRef pSuperId As Integer, ByVal pClientOwhen As String, ByVal pAuditAddress As String, ByVal pComents As String, ByVal pIsInitial As Integer, ByRef pAuditedBy As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        Dim strSql As New StringBuilder
        Try

            strSql.Append(String.Format(" INSERT INTO {0}OP_WMS_SUPERVISIONS(", DefaultSchema))
            strSql.Append(" AUDIT_ADDRESS")
            strSql.Append(" , COMMENTS")
            strSql.Append(" , IS_INITIAL")
            strSql.Append(" , AUDITED_BY")
            strSql.Append(" , CREATED_DATETIME")
            strSql.Append(" , CLIENT_OWHEN")
            strSql.Append(" ) VALUES(")
            strSql.Append(String.Format(" '{0}'", pAuditAddress))
            strSql.Append(String.Format(" , '{0}'", pComents))
            strSql.Append(String.Format(" , {0}", pIsInitial))
            strSql.Append(String.Format(" , '{0}'", pAuditedBy))
            strSql.Append(String.Format(" , GetDate()"))
            strSql.Append(String.Format(" , '{0}'", pClientOwhen))
            strSql.Append(")")

            If ExecuteSqlTransaction(sqldb_conexion.ConnectionString, strSql.ToString, pResult) Then

                strSql = New StringBuilder
                strSql.Append(String.Format(" SELECT isnull(MAX(SUPER_ID),0) FROM {0}OP_WMS_SUPERVISIONS", DefaultSchema))

                Dim miscDA As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqldb_conexion)
                Dim miscDS As DataSet = New DataSet()
                Try
                    miscDA.Fill(miscDS, "FillSupervisions")
                Catch ex As Exception
                    pResult = "ERROR," + ex.Message
                    Return False
                End Try
                If miscDS.Tables(0).Rows(0)(0) = 0 Then
                    pResult = "ERROR, No se pudo obtener el id"
                    Return False
                Else
                    pSuperId = Integer.Parse(miscDS.Tables(0).Rows(0)(0).ToString)
                    pResult = "OK"
                    Return True
                End If
            Else
                Return False
            End If
        Catch ex As Exception
            pResult = ex.Message
            Return False
        End Try
    End Function
    
    <WebMethod(Description:="Update a supervision")> _
    Public Function Updatesupervision(ByVal pSuperId As Integer, ByVal pClientOwhen As String, ByVal pAuditAddress As String, ByVal pComents As String, ByVal pIsInitial As Integer, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        Dim strSql As New StringBuilder
        Try

            strSql.Append(String.Format(" UPDATE {0}OP_WMS_SUPERVISIONS SET", DefaultSchema))
            strSql.Append(String.Format(" AUDIT_ADDRESS = '{0}'", pAuditAddress))
            strSql.Append(String.Format(" , COMMENTS = '{0}'", pComents))
            strSql.Append(String.Format(" , IS_INITIAL = {0}", pIsInitial))
            strSql.Append(String.Format(" , CLIENT_OWHEN = '{0}'", pClientOwhen))
            strSql.Append(String.Format(" WHERE SUPER_ID = {0}", pSuperId))

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

    <WebMethod(Description:="Update a supervision")> _
    Public Function UpdateStatusSupervision(ByVal pSuperId As Integer, ByVal pAsignado As Boolean, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        Dim strSql As New StringBuilder
        Try

            strSql.Append(String.Format(" UPDATE {0}OP_WMS_SUPERVISIONS SET", DefaultSchema))
            strSql.Append(String.Format(" STATUS = {0}", IIf(pAsignado, "'Assigned'", "NULL")))
            strSql.Append(String.Format(" WHERE SUPER_ID = {0}", pSuperId))

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

    <WebMethod(Description:="Delete a supervision")> _
    Public Function DeleteSupervisions(ByVal pSuperId As Integer, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        Dim strSql As New StringBuilder
        Try

            strSql.Append(String.Format(" DELETE {0}OP_WMS_SUPERVISIONS", DefaultSchema))
            strSql.Append(String.Format(" WHERE SUPER_ID = {0}", pSuperId))

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

    <WebMethod(Description:="Get a Supervisions")> _
    Public Function GetSupervisions(ByVal pAddConStatus As Boolean, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        Dim strSql As New StringBuilder
        strSql.Append(" SELECT SUPER_ID, AUDIT_ADDRESS, COMMENTS, CLIENT_OWHEN, ")
        strSql.Append(" case IS_INITIAL when 0 then 'NO' else 'SI' END AS IS_INITIAL")
        strSql.Append(String.Format(" FROM {0}OP_WMS_SUPERVISIONS ", DefaultSchema))
        If pAddConStatus Then
            strSql.Append(" where STATUS IS NULL")
        End If

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "GetInsuranceDocs")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR, No encontraron registros."
            Return miscDS
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function

    <WebMethod(Description:="Get a Supervisions")> _
    Public Function FillSupervisions(ByVal pSuperId As Integer, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        Dim strSql As New StringBuilder
        strSql.Append(" SELECT SUPER_ID, AUDIT_ADDRESS, COMMENTS, IS_INITIAL, CLIENT_OWHEN")
        strSql.Append(String.Format(" FROM {0}OP_WMS_SUPERVISIONS ", DefaultSchema))
        strSql.Append(String.Format(" WHERE SUPER_ID = {0}", pSuperId))

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "FillSupervisions")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR, No encontro el registro."
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function

End Class