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
Public Class WMS_SupervisionsDetail
    Inherits System.Web.Services.WebService

    <WebMethod(Description:="Create a supervision detail")> _
    Public Function CreateSupervisionsDetail(ByRef pSuperId As Integer, ByVal pCode As String, ByVal pDescription As String, ByVal pQty As Decimal, ByRef pCost As Decimal, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        Dim strSql As New StringBuilder
        Try

            strSql.Append(String.Format(" INSERT INTO {0}OP_WMS_SUPERVISIONS_DETAIL(", DefaultSchema))
            strSql.Append(" SUPER_ID")
            strSql.Append(" , CODE")
            strSql.Append(" , DESCRIPTION")
            strSql.Append(" , QTY")
            strSql.Append(" , COST")
            strSql.Append(" ) VALUES(")
            strSql.Append(String.Format(" {0}", pSuperId))
            strSql.Append(String.Format(" , '{0}'", pCode))
            strSql.Append(String.Format(" , '{0}'", pDescription))
            strSql.Append(String.Format(" , '{0}'", pQty))
            strSql.Append(String.Format(" , '{0}'", pCost))
            strSql.Append(" )")

            If ExecuteSqlTransaction(sqldb_conexion.ConnectionString, strSql.ToString, pResult) Then
                Return True
            End If
        Catch ex As Exception
            pResult = ex.Message
            Return False
        End Try
    End Function

    <WebMethod(Description:="Update a supervision detail")> _
    Public Function UpdateSupervisionDetail(ByRef pSuperId As Integer, ByVal pCode As String, ByVal pDescription As String, ByVal pQty As Decimal, ByRef pCost As Decimal, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        Dim strSql As New StringBuilder
        Try

            strSql.Append(String.Format(" UPDATE {0}OP_WMS_SUPERVISIONS_DETAIL SET", DefaultSchema))
            strSql.Append(String.Format(" DESCRIPTION = '{0}'", pDescription))
            strSql.Append(String.Format(" , QTY = '{0}'", pQty))
            strSql.Append(String.Format(" , COST = '{0}'", pCost))
            strSql.Append(String.Format(" WHERE SUPER_ID = {0}", pSuperId))
            strSql.Append(String.Format(" AND CODE = '{0}'", pCode))

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

    <WebMethod(Description:="Delete a supervision detail")> _
    Public Function DeleteSupervisionsDetails(ByVal pSuperId As Integer, ByVal pCode As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        Dim strSql As New StringBuilder
        Try

            strSql.Append(String.Format(" DELETE {0}OP_WMS_SUPERVISIONS_DETAIL", DefaultSchema))
            strSql.Append(String.Format(" WHERE SUPER_ID = {0}", pSuperId))
            strSql.Append(String.Format(" AND CODE = '{0}'", pCode))

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

    <WebMethod(Description:="Delete a supervision detail")> _
    Public Function DeleteAllBySuperIdSupervisionsDetail(ByVal pSuperId As Integer, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        Dim strSql As New StringBuilder
        Try

            strSql.Append(String.Format(" DELETE {0}OP_WMS_SUPERVISIONS_DETAIL", DefaultSchema))
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

    <WebMethod(Description:="Get a Supervisions detail")> _
    Public Function GetSupervisionsDetail(ByVal pSuperId As Integer, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        Dim strSql As New StringBuilder
        strSql.Append(" SELECT CODE, DESCRIPTION, QTY, COST")
        strSql.Append(String.Format(" FROM {0}OP_WMS_SUPERVISIONS_DETAIL ", DefaultSchema))
        strSql.Append(String.Format(" where SUPER_ID = {0}", pSuperId))

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "GetSupervisionsDetail")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR, No encontraron registros."
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If
    End Function

    <WebMethod(Description:="Get a Supervisions detail")> _
    Public Function FillSupervisionsDetail(ByVal pSuperId As Integer, ByVal pCode As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        Dim strSql As New StringBuilder
        strSql.Append(" SELECT CODE, DESCRIPTION, QTY, COST")
        strSql.Append(String.Format(" FROM {0}OP_WMS_SUPERVISIONS_DETAIL ", DefaultSchema))
        strSql.Append(String.Format(" where SUPER_ID = {0}", pSuperId))
        strSql.Append(String.Format(" AND CODE = '{0}'", pCode))

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "FillSupervisionsDetail")
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

    <WebMethod(Description:="Get a Supervisions detail")> _
    Public Function ExistSupervisionsDetail(ByVal pSuperId As Integer, ByVal pCode As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        Dim strSql As New StringBuilder
        strSql.Append(" SELECT COUNT(*)")
        strSql.Append(String.Format(" FROM {0}OP_WMS_SUPERVISIONS_DETAIL ", DefaultSchema))
        strSql.Append(String.Format(" where SUPER_ID = {0}", pSuperId))
        strSql.Append(String.Format(" AND CODE = '{0}'", pCode))

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "ExistSupervisionsDetail")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR, No encontraron registros."
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If
    End Function

End Class