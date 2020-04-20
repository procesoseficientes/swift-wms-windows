Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Configuration.ConfigurationManager
Imports System.ComponentModel
Imports System.Data.SqlClient
Imports WMSOnePlan_BusinessServices.ModuleServices

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class WMS_Clients
    Inherits System.Web.Services.WebService


    <WebMethod(Description:="Create Clients")> _
    Public Function CreateClients(ByVal pCLIENT_CODE As String, ByVal pCLIENT_NAME As String, ByVal pCLIENT_ROUTE As String, ByVal pCLIENT_CLASS As String, ByVal pCLIENT_STATUS As System.Int32, ByVal pCLIENT_ERP_CODE As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String = ""
        Try
            XSQL = "INSERT INTO " & DefaultSchema & "OP_WMS_CLIENTS("
            XSQL = XSQL + "CLIENT_CODE,"
            XSQL = XSQL + "CLIENT_NAME,"
            XSQL = XSQL + "CLIENT_ROUTE,"
            XSQL = XSQL + "CLIENT_CLASS,"
            XSQL = XSQL + "CLIENT_CA,"
            XSQL = XSQL + "CLIENT_STATUS, CLIENT_ERP_CODE)"
            XSQL = XSQL + "VALUES ("
            XSQL = XSQL + "'" + pCLIENT_CODE + "',"
            XSQL = XSQL + "'" + pCLIENT_NAME + "',"
            XSQL = XSQL + "'" + pCLIENT_ROUTE + "',"
            XSQL = XSQL + "'" + pCLIENT_CLASS + "',"
            XSQL = XSQL + "NULL,"
            XSQL = XSQL + pCLIENT_STATUS.ToString + ",'" + pCLIENT_ERP_CODE + "')"

            If ExecuteSqlTransaction(sqldb_conexion.ConnectionString, XSQL, pResult) Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            pResult = ex.Message
            Return False
        End Try

    End Function

    <WebMethod(Description:="Update Clients")> _
    Public Function UpdateClients(ByVal pCLIENT_CODE As String, ByVal pCLIENT_NAME As String, ByVal pCLIENT_ROUTE As String, ByVal pCLIENT_CLASS As String, ByVal pCLIENT_STATUS As System.Int32, ByVal pCLIENT_ERP_CODE As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String = ""
        Try
            XSQL = "UPDATE " & DefaultSchema & "OP_WMS_CLIENTS SET "
            XSQL = XSQL + "CLIENT_CODE = '" + pCLIENT_CODE + "',"
            XSQL = XSQL + "CLIENT_NAME = '" + pCLIENT_NAME + "',"
            XSQL = XSQL + "CLIENT_ROUTE = 'NA',"
            XSQL = XSQL + "CLIENT_CLASS = '" + pCLIENT_CLASS + "',"
            XSQL = XSQL + "CLIENT_STATUS = " + pCLIENT_STATUS.ToString + ", "
            XSQL = XSQL + "CLIENT_ERP_CODE = '" + Mid(pCLIENT_ERP_CODE.ToString, InStr(pCLIENT_ERP_CODE.ToString, "/") + 1, 8) + "'"

            XSQL = XSQL + " WHERE "
            XSQL = XSQL + "CLIENT_CODE = '" + pCLIENT_CODE + "'"
            If ExecuteSqlTransaction(sqldb_conexion.ConnectionString, XSQL, pResult) Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            pResult = ex.Message
            Return False
        End Try

    End Function

    <WebMethod(Description:="Delete Clients")> _
    Public Function DeleteClients(ByVal pCLIENT_CODE As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String = ""
        XSQL = "DELETE " & DefaultSchema & "OP_WMS_CLIENTS"
        XSQL = XSQL + " WHERE "
        XSQL = XSQL + "CLIENT_CODE = '" + pCLIENT_CODE + "'"
        Try
            If ExecuteSqlTransaction(sqldb_conexion.ConnectionString, XSQL, pResult) Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            pResult = ex.Message
            Return False
        End Try

    End Function

    <WebMethod(Description:="Search Clients")> _
    Public Function SearchByKeyClients(ByVal pCLIENT_CODE As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet

        Dim XSQL As String = ""
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        XSQL = "SELECT * FROM  " + DefaultSchema + "[OP_WMS_VIEW_CLIENTS] WHERE "
        XSQL = XSQL + " CLIENT_CODE = '" + pCLIENT_CODE.ToUpper + "' COLLATE DATABASE_DEFAULT"

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "SearchByKey_Clients")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR,No existe Cliente : " + pCLIENT_CODE
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function

    <WebMethod(Description:="Search Clients that haven't been related from ERP to WMS")> _
    Public Function GetClientsPendingToRelate(ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet

        Dim XSQL As String = ""
        Dim sqldb_conexion As SqlConnection

        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try

        XSQL = "SELECT * FROM " & DefaultSchema & "OP_WMS_VIEW_CLIENTS_PENDING_TO_REPLICATE"

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()

        Try
            miscDA.Fill(miscDS, "GetClientsPendingToRelate")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR, No existen Clientes pendientes de relacionar ERP-WMS"
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function

    <WebMethod(Description:="Search Clients that haven't been related from ERP to WMS")> _
    Public Function GetERPClients(ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet

        Dim XSQL As String = ""
        Dim sqldb_conexion As SqlConnection

        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try

        XSQL = "SELECT * FROM " & DefaultSchema & "OP_WMS_VIEW_ERP_CLIENTS ORDER BY CLIENT_NAME ASC"

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()

        Try
            miscDA.Fill(miscDS, "GetERPClients")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR, No existen Clientes en ERP"
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function

    <WebMethod(Description:="Search Clients")> _
    Public Function SearchPartialClients(ByVal pCLIENT_CODE As String, ByVal pCLIENT_NAME As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String = ""

        If pCLIENT_CODE.Length > 0 Or pCLIENT_NAME.Length > 0 Then

            XSQL = "SELECT *, 1 AS [IS_SELECTED] FROM " & DefaultSchema & "[OP_WMS_VIEW_CLIENTS]"
            XSQL = XSQL + " WHERE "
            XSQL = XSQL + " CLIENT_CODE LIKE '" + pCLIENT_CODE.ToUpper + "%' COLLATE DATABASE_DEFAULT OR "
            XSQL = XSQL + " CLIENT_NAME = '" + pCLIENT_NAME.ToUpper + "' COLLATE DATABASE_DEFAULT "
            '20-Ene-2011 J.R. Es innecesario el upper porque los codigos ya son solo numeros ademas es un solo cliente el que se busca por lo que no se necesita order by
            'XSQL = XSQL + " UPPER(CLIENT_CODE) LIKE '" + pCLIENT_CODE.ToUpper + "%' OR "
            'XSQL = XSQL + " UPPER(CLIENT_NAME) = '" + pCLIENT_NAME.ToUpper + "'"
            XSQL = XSQL + " ORDER BY "
            XSQL = XSQL + " CLIENT_CODE, "
            XSQL = XSQL + " CLIENT_NAME"


        Else '04072012 WM modificado para que no de error cuando no se le mandan fijos los datos del cliente y devuelva todos los clientes
            XSQL = "SELECT *, 1 AS [IS_SELECTED] FROM " & DefaultSchema & "[OP_WMS_VIEW_CLIENTS]"
            XSQL = XSQL + " ORDER BY "
            XSQL = XSQL + " CLIENT_CODE, "
            XSQL = XSQL + " CLIENT_NAME"
        End If

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "SearchPartial_Clients")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try

        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR,No existe Clientes : " + pCLIENT_CODE
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function

    <WebMethod(Description:="Search view Clients")> _
    Public Function GetViewClients(ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet

        Dim XSQL As String = ""
        Dim sqldb_conexion As SqlConnection

        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try

        XSQL = "SELECT * FROM " & DefaultSchema & "OP_WMS_VIEW_CLIENTS"

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()

        Try
            miscDA.Fill(miscDS, "GetViewClients")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR, No existen Clientes en ERP"
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function

    <WebMethod(Description:="GetIfExistsMaterialByClient")>
    Public Function GetIfExistsMaterialByClient(ByVal clientCode As String, ByRef result As String, ByVal environmentName As String) As Boolean
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(environmentName).ToString)
        sqldb_conexion.Open()

        Try
            Dim cmd As New SqlCommand
            Dim reader As SqlDataReader
            Dim dt As DataTable = New DataTable("Operacion")

            cmd.Parameters.Add("@CLIENT_CODE", SqlDbType.VarChar,25)
            cmd.Parameters("@CLIENT_CODE").Direction = ParameterDirection.Input
            cmd.Parameters("@CLIENT_CODE").Value = clientCode

            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_VALIDATED_IF_CLIENT_EXISTS]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldb_conexion
            cmd.ExecuteNonQuery()

            dt.Load(reader)

            result = "OK"

            If dt.Rows(0).Item(0) = 0 then
                Return False
            end If

            Return True
        Catch ex As Exception
            result = ex.Message
            Return False
        Finally
            sqldb_conexion.Close()
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try
    End Function
End Class