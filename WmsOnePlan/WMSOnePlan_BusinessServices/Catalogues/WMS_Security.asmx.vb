Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Configuration.ConfigurationManager
Imports System.ComponentModel
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic.CompilerServices
Imports WMSOnePlan_BusinessServices.ModuleServices
Imports System
Imports System.IO
Imports System.IO.Path
Imports System.Net
Imports System.Net.NetworkInformation
Imports System.Reflection
Imports System.Security.Cryptography
Imports System.Security.Cryptography.Xml
Imports System.Text
Imports System.Xml
Imports MobilityScm.Modelo.Tipos
Imports MobilityScm.Utilerias
Imports Newtonsoft.Json.Linq


' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
<System.Web.Script.Services.ScriptService()>
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")>
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)>
<ToolboxItem(False)>
Public Class WMS_Security
    Inherits System.Web.Services.WebService

    <WebMethod(Description:="Crear usuarios")>
    Public Function CreateUserLogin(ByVal pLOGIN_ID As String, ByVal pROLE_ID As String, ByVal pLOGIN_NAME As String, ByVal pLOGIN_TYPE As String,
                                    ByVal pLOGIN_STATUS As String, ByVal pLOGIN_PWD As String, ByVal pLICENSE_SERIAL As String,
                                    ByVal pENVIRONMENT As String, ByVal pGUI_LAYOUT As String, ByVal pCONSOLIDATION_TERMINAL As Integer,
                                    ByVal pLINE_ID As String, ByVal pGENERATE_TASKS As String, ByVal pLOADING_GATE As Integer,
                                    ByVal pWHEREHOUSE_iD As String, ByVal pEmail As String, ByVal pAuthorizer As Integer, ByVal pNotifyLetterQuota As Integer,
                                    ByVal pCAN_RELOCATE As Integer, ByVal linePosition As String, ByVal spotColumn As String, ByVal terminalIp As String, ByVal domainId As Integer,
                                    ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean
        'pResult = "No tiene autorización para crear usuarios nuevos, contacte a su administrador"
        'Return False
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String = ""
        Try
            XSQL = "INSERT INTO  " & DefaultSchema & "OP_WMS_LOGINS("
            XSQL = XSQL + "LOGIN_ID,"
            XSQL = XSQL + "ROLE_ID,"
            XSQL = XSQL + "LOGIN_NAME,"
            XSQL = XSQL + "LOGIN_TYPE,"
            XSQL = XSQL + "LOGIN_STATUS,"
            XSQL = XSQL + "LOGIN_PWD,"
            XSQL = XSQL + "LICENSE_SERIAL,"
            XSQL = XSQL + "ENVIRONMENT,"
            XSQL = XSQL + "GUI_LAYOUT,"
            XSQL = XSQL + "CONSOLIDATION_TERMINAL,"
            XSQL = XSQL + "GENERATE_TASKS, LINE_ID"
            XSQL = XSQL + ", [3PL_WAREHOUSE]"
            XSQL = XSQL + ", EMAIL"
            XSQL = XSQL + ", AUTHORIZER"
            XSQL = XSQL + ", NOTIFY_LETTER_QUOTA"
            XSQL = XSQL + ", CAN_RELOCATE"
            XSQL = XSQL + ", LINE_POSITION"
            XSQL = XSQL + ", SPOT_COLUMN"
            XSQL = XSQL + ", TERMINAL_IP"
            XSQL = XSQL + ", DOMAIN_ID"
            XSQL = XSQL + ") VALUES ("
            XSQL = XSQL + "'" + pLOGIN_ID.ToUpper + "',"
            XSQL = XSQL + "'" + pROLE_ID.ToUpper + "',"
            XSQL = XSQL + "'" + pLOGIN_NAME.ToUpper + "',"
            XSQL = XSQL + "'" + pLOGIN_TYPE.ToUpper + "',"
            XSQL = XSQL + "'" + pLOGIN_STATUS.ToUpper + "',"
            XSQL = XSQL + "'" + pLOGIN_PWD + "',"
            XSQL = XSQL + "'" + pLICENSE_SERIAL.ToUpper + "',"
            XSQL = XSQL + "'" + pENVIRONMENT + "',"
            XSQL = XSQL + "'" + pGUI_LAYOUT + "',"
            XSQL = XSQL + pCONSOLIDATION_TERMINAL.ToString & ","
            XSQL = XSQL + pGENERATE_TASKS.ToString & ",'" + pLINE_ID
            XSQL = XSQL + "' , '" + pWHEREHOUSE_iD + "'"
            XSQL = XSQL + " , '" + pEmail + "'"
            XSQL = XSQL + " , " + pAuthorizer.ToString()
            XSQL = XSQL + " , " + pNotifyLetterQuota.ToString()
            XSQL = XSQL + " , " + pCAN_RELOCATE.ToString()
            XSQL = XSQL + " , '" + linePosition + "'"
            XSQL = XSQL + " , '" + spotColumn + "'"
            XSQL = XSQL + " , '" + terminalIp + "'"
            XSQL = XSQL + " , " + domainId.ToString() + " "
            XSQL = XSQL + ")"

            If ExecuteSqlTransaction(sqldb_conexion.ConnectionString, XSQL, pResult) Then

                If pLOADING_GATE <> 0 Then
                    XSQL = XSQL + " UPDATE " + AppSettings("SONDA_DB_OWNER").ToString + ".SONDA_LOADING_GATES SET"
                    XSQL = XSQL + " ASSIGNED_OPERATOR = '" & pLOGIN_ID & "'"
                    XSQL = XSQL + " WHERE GATE_ID = " & pLOADING_GATE
                    If ExecuteSqlTransaction(sqldb_conexion.ConnectionString, XSQL, pResult) Then
                        Return True
                    Else
                        Return False
                    End If
                End If

            Else
                Return False
            End If
        Catch ex As Exception
            pResult = ex.Message
            Return False
        End Try
        Return True
    End Function

    <WebMethod(Description:="Actualiza usuario")>
    Public Function UpdateUserLogin(ByVal pLOGIN_ID As String, ByVal pROLE_ID As String, ByVal pLOGIN_NAME As String, ByVal pLOGIN_TYPE As String,
                                    ByVal pLOGIN_STATUS As String, ByVal pLOGIN_PWD As String, ByVal pLICENSE_SERIAL As String,
                                    ByVal pENVIRONMENT As String, ByVal pGUI_LAYOUT As String, ByVal pCONSOLIDATION_TERMINAL As Integer,
                                    ByVal pGENERATE_TASKS As Integer, ByVal pLINE_ID As String, ByVal pLOADING_GATE As Integer,
                                    ByVal pWHEREHOUSE_iD As String, ByVal pEmail As String, ByVal pAuthorizer As Integer, ByVal pNotifyLetterQuota As Integer,
                                    ByVal pCAN_RELOCATE As Integer, ByVal linePosition As String, ByVal spotColumn As String, ByVal terminalIp As String, ByVal domainId As Integer,
                                    ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String = ""
        Try
            XSQL = "UPDATE  " & DefaultSchema & "OP_WMS_LOGINS SET "
            XSQL = XSQL + "LOGIN_ID = '" + pLOGIN_ID.ToUpper + "',"
            XSQL = XSQL + "ROLE_ID = '" + pROLE_ID.ToUpper + "',"
            XSQL = XSQL + "LOGIN_NAME = '" + pLOGIN_NAME.ToUpper + "',"
            XSQL = XSQL + "LOGIN_TYPE = '" + pLOGIN_TYPE.ToUpper + "',"
            XSQL = XSQL + "LOGIN_STATUS = '" + pLOGIN_STATUS.ToUpper + "',"
            XSQL = XSQL + "LOGIN_PWD = '" + pLOGIN_PWD.ToString() + "',"
            XSQL = XSQL + "LICENSE_SERIAL = '" + pLICENSE_SERIAL.ToUpper.ToString() + "',"
            XSQL = XSQL + "ENVIRONMENT = '" + pENVIRONMENT.ToString() + "', "
            XSQL = XSQL + "GUI_LAYOUT = '" + pGUI_LAYOUT.ToString() + "', "
            XSQL = XSQL + "CONSOLIDATION_TERMINAL = " + pCONSOLIDATION_TERMINAL.ToString + ", "
            XSQL = XSQL + "GENERATE_TASKS = '" + pGENERATE_TASKS.ToString + "',"
            XSQL = XSQL + "LINE_ID = '" + pLINE_ID.ToString.ToString() + "',"
            XSQL = XSQL + "LOADING_GATE = '" + pLOADING_GATE.ToString() + "'"
            XSQL = XSQL + ", [3PL_WAREHOUSE] = '" + pWHEREHOUSE_iD.ToString() + "'"
            XSQL = XSQL + ", EMAIL = '" + pEmail + "'"
            XSQL = XSQL + ", AUTHORIZER = " + pAuthorizer.ToString()
            XSQL = XSQL + ", NOTIFY_LETTER_QUOTA = " + pNotifyLetterQuota.ToString()
            XSQL = XSQL + ", CAN_RELOCATE = " + pCAN_RELOCATE.ToString()
            XSQL = XSQL + ", LINE_POSITION = '" + linePosition + "'"
            XSQL = XSQL + ", SPOT_COLUMN = '" + spotColumn + "'"
            XSQL = XSQL + ", TERMINAL_IP = '" + terminalIp + "'"
            XSQL = XSQL + ", DOMAIN_ID = " + domainId.ToString() + ""
            XSQL = XSQL + "  WHERE "
            XSQL = XSQL + " LOGIN_ID = '" + pLOGIN_ID.ToUpper + "'"


            If ExecuteSqlTransaction(sqldb_conexion.ConnectionString, XSQL, pResult) Then

                If pLOADING_GATE <> 0 Then
                    XSQL = XSQL + " UPDATE " + AppSettings("SONDA_DB_OWNER").ToString + ".SONDA_LOADING_GATES SET "
                    XSQL = XSQL + " ASSIGNED_OPERATOR = '" & pLOGIN_ID & "'"
                    XSQL = XSQL + " WHERE GATE_ID = " & pLOADING_GATE
                    If ExecuteSqlTransaction(sqldb_conexion.ConnectionString, XSQL, pResult) Then
                        Return True
                    Else
                        Return False
                    End If
                End If


            Else
                Return False
            End If


        Catch ex As Exception
            pResult = ex.Message
            Return False
        End Try
        Return True
    End Function

    <WebMethod(Description:="GetDomains")>
    Public Function GetDomains(ByRef result As String, ByVal environmentName As String) As DataTable

        Dim connection = New SqlConnection(AppSettings(environmentName).ToString)
        connection.Open()
        Try
            Dim command As New SqlCommand
            command.CommandText = DefaultSchema + "[OP_WMS_SP_GET_DOMAINS]"
            command.CommandType = CommandType.StoredProcedure
            command.Connection = connection

            Dim adapter As SqlDataAdapter = New SqlDataAdapter(command)
            Dim dataSet As DataSet = New DataSet()

            Try
                adapter.Fill(dataSet, "Domains")
            Catch ex As Exception
                result = "ERROR," + ex.Message
                Return Nothing
            End Try

            If dataSet Is Nothing Or dataSet.Tables.Count <= 0 Then
                result = "No se encontró información."
                Return Nothing
            End If

            result = "OK"
            Return dataSet.Tables(0)

        Catch ex As Exception
            result = ex.Message
            Return Nothing
        Finally
            connection.Close()
            connection.Dispose()
            connection = Nothing
        End Try

    End Function


    <WebMethod(Description:="Actualiza GUI de usuario")>
    Public Function UpdateUserGUI(ByVal pLOGIN_ID As String, ByVal pGUI_LAYOUT As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String = ""
        Try
            XSQL = "UPDATE  " & DefaultSchema & "OP_WMS_LOGINS SET "
            XSQL = XSQL + "GUI_LAYOUT = '" + pGUI_LAYOUT + "' "
            XSQL = XSQL + " WHERE "
            XSQL = XSQL + "LOGIN_ID = '" + pLOGIN_ID.ToUpper + "'"
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

    <WebMethod(Description:="Actualiza Usuario Cliente")>
    Public Function UpdateUserCliente(ByVal pLoginId As String, ByVal pClientCode As String, ByVal pIsExternal As Integer, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        Try
            Dim strSql As New StringBuilder(String.Format(" UPDATE {0}OP_WMS_LOGINS SET", DefaultSchema))
            strSql.Append(String.Format(" IS_EXTERNAL = {0}", pIsExternal))
            strSql.Append(String.Format(" , RELATED_CLIENT = '{0}'", pClientCode))
            strSql.Append(String.Format(" WHERE LOGIN_ID = '{0}'", pLoginId))

            If ExecuteSqlTransaction(sqldb_conexion.ConnectionString, strSql.ToString(), pResult) Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            pResult = ex.Message
            Return False
        End Try
    End Function

    <WebMethod(Description:="Get Cliente User")>
    Public Function GetClientUser(ByVal pLoginId As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataTable

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        Dim strSql As New StringBuilder(" SELECT * ")
        strSql.Append(String.Format(" FROM {0}OP_WMS_LOGINS ", DefaultSchema))
        strSql.Append(String.Format(" LEFT JOIN {0}OP_WMS_VIEW_CLIENTS ON RELATED_CLIENT = CLIENT_CODE COLLATE DATABASE_DEFAULT ", DefaultSchema))
        strSql.Append(String.Format(" WHERE LOGIN_ID = '{0}'", pLoginId))

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(strSql.ToString(), sqldb_conexion)
        Dim miscDS As DataTable = New DataTable("GetClientUser")
        Try
            miscDA.Fill(miscDS)
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Rows.Count <= 0 Then
            pResult = "ERROR,No existe el usuario : " + pLoginId
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If
    End Function

    <WebMethod(Description:="Get Cliente User")>
    Public Function GetClientUserPass(ByVal pLoginId As String, ByVal pPwd As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataTable

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        Dim strSql As New StringBuilder(" SELECT * ")
        strSql.Append(String.Format(" FROM {0}OP_WMS_LOGINS ", DefaultSchema))
        strSql.Append(String.Format(" INNER JOIN {0}OP_WMS_VIEW_CLIENTS ON RELATED_CLIENT = CLIENT_CODE COLLATE DATABASE_DEFAULT", DefaultSchema))
        strSql.Append(String.Format(" WHERE LOGIN_ID = '{0}'", pLoginId))
        strSql.Append(String.Format(" AND LOGIN_PWD = '{0}'", pPwd))

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(strSql.ToString(), sqldb_conexion)
        Dim miscDS As DataTable = New DataTable("GetClientUser")
        Try
            miscDA.Fill(miscDS)
        Catch ex As Exception
            pResult = "ERROR," & ex.Message
            Return Nothing
        End Try
        If miscDS.Rows.Count <= 0 Then
            pResult = "ERROR,No existe el usuario o no tiene un cliente asignado." + pLoginId
            Return Nothing
        ElseIf miscDS.Rows(0)("LOGIN_STATUS") = "BLOQUEADO" Then
            pResult = "El usuario se encuentra bloqueado"
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function

    <WebMethod(Description:="Eliminar usuario")>
    Public Function DeleteUserLogin(ByVal pLOGIN_ID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim XSQL As String = ""
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        XSQL = "DELETE  " & DefaultSchema & "OP_WMS_LOGINS"
        XSQL = XSQL + " WHERE "
        XSQL = XSQL + "LOGIN_ID = '" + pLOGIN_ID + "'"
        Try
            If ExecuteSqlTransaction(sqldb_conexion.ConnectionString, XSQL, pResult) Then
                XSQL = "DELETE  " & DefaultSchema & "OP_WMS_LOGIN_JOIN_LOCATIONS WHERE LOGIN_ID = '" + pLOGIN_ID + "'"

                If ExecuteSqlTransaction(sqldb_conexion.ConnectionString, XSQL, pResult) Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If
        Catch ex As Exception
            pResult = ex.Message
            Return False
        End Try

    End Function
    <WebMethod(Description:="Buscar usuario por multiples columnas")>
    Public Function SearchOperators(ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String = ""
        XSQL = "SELECT * FROM  " & DefaultSchema & "OP_WMS_LOGINS"
        XSQL = XSQL + " WHERE "
        XSQL = XSQL + "UPPER(ROLE_ID) LIKE 'OPERADOR%' AND LOGIN_STATUS = 'ACTIVO'"
        XSQL = XSQL + " ORDER BY "
        XSQL = XSQL + "LOGIN_NAME"
        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "SearchOperators")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR,No existen Operarios"
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function

    <WebMethod(Description:="Buscar usuario por multiples columnas")>
    Public Function SearchPartialUserLogin(ByVal pLOGIN_ID As String, ByVal pROLE_ID As String, ByVal pLOGIN_NAME As String, ByVal pLOGIN_TYPE As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        Dim XSQL As String = ""
        XSQL = "SELECT L.*, [D].[DOMAIN] FROM  " & DefaultSchema & "OP_WMS_LOGINS L  "
        XSQL = XSQL + " LEFT JOIN dbo.OP_WMS_DOMAINS D ON [D].[ID] = [L].[DOMAIN_ID]  WHERE "
        XSQL = XSQL + "UPPER(LOGIN_ID) LIKE '%" + pLOGIN_ID.ToUpper + "%' OR "
        XSQL = XSQL + "UPPER(ROLE_ID) LIKE '%" + pROLE_ID.ToUpper + "%' OR "
        XSQL = XSQL + "UPPER(LOGIN_NAME) LIKE '%" + pLOGIN_NAME.ToUpper + "%' OR "
        XSQL = XSQL + "UPPER(LOGIN_TYPE) LIKE '%" + pLOGIN_TYPE.ToUpper + "%'"
        XSQL = XSQL + " ORDER BY "
        XSQL = XSQL + "LOGIN_ID, "
        XSQL = XSQL + "ROLE_ID, "
        XSQL = XSQL + "LOGIN_NAME, "
        XSQL = XSQL + "LOGIN_TYPE"
        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "SearchPartial_UserLogin")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR,No existe UserLogin : " + pLOGIN_ID
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function
    <WebMethod(Description:="buscar usuarios por codigo")>
    Public Function SearchByKeyUserLogin(ByVal pLOGIN_ID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String = ""
        XSQL = "SELECT L.*,[D].[DOMAIN],CAST( [D].[ID] AS VARCHAR) +' - ' + [D].[DOMAIN] [DOMAIN_DESCRIPTION] FROM  " & DefaultSchema & "OP_WMS_LOGINS L "
        XSQL = XSQL + " LEFT JOIN dbo.OP_WMS_DOMAINS D ON [D].[ID] = [L].[DOMAIN_ID]"
        XSQL = XSQL + " WHERE "
        XSQL = XSQL + "UPPER(LOGIN_ID) = '" + pLOGIN_ID.ToUpper + "'"
        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "SearchByKey_UserLogin")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR,No existe UserLogin : " + pLOGIN_ID
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function

    <WebMethod(Description:="buscar usuarios por autorizados")>
    Public Function SearchByAuthorizerUserLogin(ByVal pAuthorizer As Integer, ByRef pResult As String, ByVal pEnvironmentName As String) As DataTable
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String = ""
        XSQL = "SELECT * FROM  " & DefaultSchema & "OP_WMS_LOGINS"
        XSQL = XSQL + " WHERE "
        XSQL = XSQL + " AUTHORIZER = " + pAuthorizer.ToString()
        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDt As DataTable = New DataTable("SearchByAuthorizerUserLogin")
        Try
            miscDA.Fill(miscDt)
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDt.Rows.Count <= 0 Then
            pResult = "ERROR, No se encontraron registros."
            Return Nothing
        Else
            pResult = "OK"
            Return miscDt
        End If
    End Function

    Private Function IsValidDate(ByVal pDate As Date) As Boolean
        If Year(pDate) >= 2000 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function ExecuteSqlTransaction(ByVal connectionString As String, ByVal SQLStatment As String, ByRef pResult As String) As Boolean
        Using connection As New SqlConnection(connectionString)

            connection.Open()

            Dim command As SqlCommand = connection.CreateCommand()
            Dim transaction As SqlTransaction

            transaction = connection.BeginTransaction("LocalTransaction")
            command.Connection = connection
            command.Transaction = transaction

            Try
                command.CommandText = SQLStatment
                command.ExecuteNonQuery()
                transaction.Commit()
                pResult = "OK"

            Catch ex As Exception
                pResult = ex.Message
                Try
                    transaction.Rollback()
                Catch ex2 As Exception
                    pResult = ex.Message
                    Return False
                End Try
                Return False
            End Try
        End Using

        Return True
    End Function

    <WebMethod(Description:="UserLogin Group by Role")>
    Public Function GroupByKeyUserLogin(ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String = ""
        XSQL = "SELECT DISTINCT(ROLE_ID) FROM  " & DefaultSchema & "OP_WMS_LOGINS"
        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "GroupByKeyUserLogin")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR,No existen grupos por nivel de acceso"
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function

    <WebMethod(Description:="Get distinct access leves from roles table")>
    Public Function AccessLevelGroups(ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String = ""
        XSQL = "SELECT ROLE_ID FROM  " & DefaultSchema & "OP_WMS_ROLES GROUP BY ROLE_ID"
        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "AccessLevelGroups")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR,No existen niveles de acceso"
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function
    <WebMethod(Description:="Get distinct access leves from roles table")>
    Public Function CheckPointGroups(ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String = ""
        XSQL = "SELECT PRIV_GROUP FROM  " & DefaultSchema & "OP_WMS_PRIVILEGES GROUP BY PRIV_GROUP"
        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "PRIV_GROUP")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR,No existen grupos de checkpoint"
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function

    <WebMethod(Description:="CheckPoint")>
    Public Function SearchByKeyCheckPoint(ByVal pPRIV_ID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String = ""
        XSQL = "SELECT * FROM  " & DefaultSchema & "OP_WMS_PRIVILEGES"
        XSQL = XSQL + " WHERE "
        XSQL = XSQL + "UPPER(PRIV_ID) = '" + pPRIV_ID.ToUpper + "'"
        XSQL = XSQL + " ORDER BY "
        XSQL = XSQL + "PRIV_ID"
        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "SearchByKey_CheckPoint")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR,No existe CheckPoint : " + pPRIV_ID
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function

    <WebMethod(Description:="CheckPoint")>
    Public Function SearchPartialCheckPoint(ByVal pPRIV_ID As String, ByVal pPRIV_NAME As String, ByVal pPRIV_GROUP As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String = ""
        XSQL = "SELECT * FROM  " & DefaultSchema & "OP_WMS_PRIVILEGES"
        XSQL = XSQL + " WHERE "
        XSQL = XSQL + "UPPER(PRIV_ID) LIKE '%" + pPRIV_ID.ToUpper + "%' OR "
        XSQL = XSQL + "UPPER(PRIV_NAME) LIKE '%" + pPRIV_NAME.ToUpper + "%' OR "
        XSQL = XSQL + "UPPER(PRIV_GROUP) LIKE '%" + pPRIV_GROUP.ToUpper + "%' "
        XSQL = XSQL + " ORDER BY "
        XSQL = XSQL + "PRIV_ID, "
        XSQL = XSQL + "PRIV_NAME, "
        XSQL = XSQL + "PRIV_GROUP"
        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "SearchPartial_CheckPoint")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR,No existe CheckPoint : " + pPRIV_ID
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function



    <WebMethod(Description:="Eliminar puntos de control de seguridad")>
    Public Function DeleteCheckPoint(ByVal pPRIV_ID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim XSQL As String = ""
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        XSQL = "DELETE  " & DefaultSchema & "OP_WMS_PRIVILEGES"
        XSQL = XSQL + " WHERE "
        XSQL = XSQL + "PRIV_ID = '" + pPRIV_ID + "'"
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


    <WebMethod(Description:="Actualizar puntos de control de seguridad")>
    Public Function UpdateCheckPoint(ByVal pPRIV_ID As String, ByVal pPRIV_NAME As String, ByVal pPRIV_GROUP As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim XSQL As String = ""
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Try
            XSQL = "UPDATE  " & DefaultSchema & "OP_WMS_PRIVILEGES SET "
            XSQL = XSQL + "PRIV_ID = '" + pPRIV_ID + "',"
            XSQL = XSQL + "PRIV_NAME = '" + pPRIV_NAME + "',"
            XSQL = XSQL + "PRIV_GROUP = '" + pPRIV_GROUP + "' "
            XSQL = XSQL + " WHERE "
            XSQL = XSQL + "PRIV_ID = '" + pPRIV_ID + "'"
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

    <WebMethod(Description:="Actualizar puntos de control de seguridad")>
    Public Function UpdateLicense(ByVal pPRIV_LOGIN_ID As String, ByVal pPRIV_LICENSE As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim XSQL As String = ""
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Try
            XSQL = "exec " & DefaultSchema & "OP_WMS_SP_LICENSE_USER @LOGIN_ID = '" & pPRIV_LOGIN_ID & "' " & "@LICENSE = '" & pPRIV_LICENSE & "'"

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



    <WebMethod(Description:="Crear puntos de control de seguridad")>
    Public Function CreateCheckPoint(ByVal pPRIV_ID As String, ByVal pPRIV_NAME As String, ByVal pPRIV_GROUP As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim XSQL As String = ""
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Try
            XSQL = "INSERT INTO  " & DefaultSchema & "OP_WMS_PRIVILEGES("
            XSQL = XSQL + "PRIV_ID,"
            XSQL = XSQL + "PRIV_NAME,"
            XSQL = XSQL + "PRIV_GROUP)"
            XSQL = XSQL + "VALUES ("
            XSQL = XSQL + "'" + pPRIV_ID + "',"
            XSQL = XSQL + "'" + pPRIV_NAME + "',"
            XSQL = XSQL + "'" + pPRIV_GROUP + "')"
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

    <WebMethod(Description:="Buscar nivel de acceso por ID")>
    Public Function SearchByKeyAccessLevel(ByVal pROLE_ID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet

        Dim XSQL As String = ""
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        XSQL = "SELECT * FROM  " & DefaultSchema & "OP_WMS_ROLES"
        XSQL = XSQL + " WHERE "
        XSQL = XSQL + "UPPER(ROLE_ID) = '" + pROLE_ID.ToUpper + "'"
        XSQL = XSQL + " ORDER BY "
        XSQL = XSQL + "ROLE_ID"
        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "SearchByKey_AccessLevel")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR,No existe AccessLevel : " + pROLE_ID
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function



    <WebMethod(Description:="Busqueda Parcial de niveles de acceso")>
    Public Function SearchPartialAccessLevel(ByVal pROLE_ID As String, ByVal pROLE_NAME As String, ByVal pROLE_DESCRIPTION As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet

        Dim XSQL As String = ""
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        XSQL = "SELECT * FROM  " & DefaultSchema & "OP_WMS_ROLES"
        XSQL = XSQL + " WHERE "
        XSQL = XSQL + "UPPER(ROLE_ID) LIKE '%" + pROLE_ID.ToUpper + "%' OR "
        XSQL = XSQL + "UPPER(ROLE_NAME) LIKE '%" + pROLE_NAME.ToUpper + "%' OR "
        XSQL = XSQL + "UPPER(ROLE_DESCRIPTION) LIKE '%" + pROLE_DESCRIPTION.ToUpper + "%' "
        XSQL = XSQL + " ORDER BY "
        XSQL = XSQL + "ROLE_ID, "
        XSQL = XSQL + "ROLE_NAME, "
        XSQL = XSQL + "ROLE_DESCRIPTION"
        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "SearchPartial_AccessLevel")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR,No existe AccessLevel : " + pROLE_ID
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function



    <WebMethod(Description:="Borrar Nivel de Acceso")>
    Public Function DeleteAccessLevel(ByVal pROLE_ID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim XSQL As String = ""
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        XSQL = "DELETE  " & DefaultSchema & "OP_WMS_ROLES"
        XSQL = XSQL + " WHERE "
        XSQL = XSQL + "ROLE_ID = '" + pROLE_ID + "'"
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


    <WebMethod(Description:="Actualizar niveles de acceso")>
    Public Function UpdateAccessLevel(ByVal pROLE_ID As String, ByVal pROLE_NAME As String, ByVal pROLE_DESCRIPTION As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim XSQL As String = ""
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        Try
            XSQL = "UPDATE  " & DefaultSchema & "OP_WMS_ROLES SET "
            XSQL = XSQL + "ROLE_ID = '" + pROLE_ID + "',"
            XSQL = XSQL + "ROLE_NAME = '" + pROLE_NAME + "',"
            XSQL = XSQL + "ROLE_DESCRIPTION = '" + pROLE_DESCRIPTION + "' "
            XSQL = XSQL + " WHERE "
            XSQL = XSQL + "ROLE_ID = '" + pROLE_ID + "'"
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



    <WebMethod(Description:="Crear Niveles de Acceso")>
    Public Function CreateAccessLevel(ByVal pROLE_ID As String, ByVal pROLE_NAME As String, ByVal pROLE_DESCRIPTION As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim XSQL As String = ""
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        Try
            XSQL = "INSERT INTO  " & DefaultSchema & "OP_WMS_ROLES("
            XSQL = XSQL + "ROLE_ID,"
            XSQL = XSQL + "ROLE_NAME,"
            XSQL = XSQL + "ROLE_DESCRIPTION)"
            XSQL = XSQL + "VALUES ("
            XSQL = XSQL + "'" + pROLE_ID + "',"
            XSQL = XSQL + "'" + pROLE_NAME + "',"
            XSQL = XSQL + "'" + pROLE_DESCRIPTION + "')"
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



    <WebMethod(Description:="Buscar Privs por AccessLevel")>
    Public Function GetCheckPointJoinAccessLevel(ByVal pCheckPoint As String, ByVal pAccessLevel As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String = ""
        XSQL = "SELECT * FROM  " & DefaultSchema & "OP_WMS_ROLES_JOIN_PRIVS"
        XSQL = XSQL + " WHERE "
        XSQL = XSQL + "UPPER(ROLE_ID) = '" + pAccessLevel.ToUpper + "' AND "
        XSQL = XSQL + "UPPER(PRIV_ID) = '" + pCheckPoint.ToUpper + "'"
        XSQL = XSQL + " ORDER BY "
        XSQL = XSQL + "ROLE_ID, "
        XSQL = XSQL + "PRIV_ID"
        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "GetCheckPointJoinAccessLevel")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR,No existe AccessLevel : " + pAccessLevel + "/CheckPoint = " + pCheckPoint
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function

    <WebMethod(Description:="Buscar Privs por AccessLevel")>
    Public Function SelectCheckPointsJoinAccessLevel(ByVal pAccessLevel As String, ByVal JoinOrNot As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String = ""

        XSQL = "SELECT PRIV_ID, PRIV_NAME, PRIV_GROUP "
        XSQL = XSQL + "FROM  " & DefaultSchema & "OP_WMS_PRIVILEGES  A "

        XSQL = XSQL + "where a.PRIV_ID " + IIf(JoinOrNot = "YES", "", " not ") + " in (select PRIV_ID from  " & DefaultSchema & "OP_WMS_ROLES_JOIN_PRIVS "
        XSQL = XSQL + "where ROLE_ID = '" + pAccessLevel + "')"


        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "SelectCheckPointsJoinAccessLevel")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR,No existe SelectCheckPointsJoinAccessLevel : " + pAccessLevel
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If


    End Function
    <WebMethod(Description:="Crear puntos de control de seguridad")>
    Public Function JoinCheckPointToAccessLevel(ByVal pCheckPoint As String, ByVal pAccessLevel As String, ByVal pAddOrRemove As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String = ""
        Try
            If pAddOrRemove = "ADD" Then
                XSQL = "INSERT INTO  " & DefaultSchema & "OP_WMS_ROLES_JOIN_CHECKPOINTS("
                XSQL = XSQL + "ROLE_ID,"
                XSQL = XSQL + "CHECK_ID)"
                XSQL = XSQL + "VALUES ("
                XSQL = XSQL + "'" + pAccessLevel.ToUpper + "',"
                XSQL = XSQL + "'" + pCheckPoint.ToUpper + "')"
            Else
                XSQL = "DELETE FROM  " & DefaultSchema & "OP_WMS_ROLES_JOIN_CHECKPOINTS"
                XSQL = XSQL + " WHERE "
                XSQL = XSQL + "ROLE_ID = '" + pAccessLevel.ToUpper + "' AND "
                XSQL = XSQL + "CHECK_ID = '" + pCheckPoint.ToUpper + "'"
            End If
            If ExecuteSqlTransaction(sqldb_conexion.ConnectionString, XSQL, pResult) Then
                Return True
            Else
                If InStr(pResult.ToUpper, "DUPLICATE") >= 1 Then
                    pResult = pCheckPoint + " Already belongs to " + pAccessLevel
                    Return True
                Else
                    Return False
                End If
            End If
        Catch ex As Exception
            If InStr(ex.Message.ToUpper, "DUPLICATE") >= 1 Then
                pResult = pCheckPoint + " Already belongs to " + pAccessLevel
                Return True
            Else
                Return False
            End If
        End Try

    End Function
    <WebMethod(Description:="Autenticar Usuario/Password")>
    Public Function VerifyUserPass(ByVal pUserId As String, ByVal pPass As String, ByRef pResult As String, ByVal pEnvironmentName As String, ByRef expirationDate As DateTime, ByRef showMessage As Boolean, ByRef missingDays As Integer) As DataSet

        'pResult = ValidarLicencia(pUserId, pPass)

        If (Not String.IsNullOrEmpty(pResult)) Then
            Return Nothing
        End If

        'If Not VerifyLicenseFile(pResult, pEnvironmentName, expirationDate, showMessage, missingDays) Then
        '    Return Nothing
        'End If

        Dim sqldbConexion As SqlConnection
        Dim xconnstr As String = ""
        Try
            Dim x As Integer = AppSettings.Count
            Dim y = AppSettings.Get(pEnvironmentName)
            xconnstr = AppSettings(pEnvironmentName).ToString
            sqldbConexion = New SqlConnection(xconnstr)
        Catch ex As SqlException
            LogSQLErrors("VERIFYUSERPASS", "xconn:" + xconnstr, "")

            pResult = ex.InnerException.Message + " " + pEnvironmentName
            Return Nothing
        End Try

        If (pUserId.ToUpper.Trim.Split("@").Length = 2) Then
            Dim errorMessageResult = ""
            Dim credentialsValidationResult = ValidateCredentialsOfUser(pUserId, pPass, pEnvironmentName, errorMessageResult)
            If IsNothing(credentialsValidationResult) Then
                pResult = errorMessageResult
                Return Nothing
            End If
        End If

        Dim cmd As New SqlCommand

        cmd.Parameters.Add("@LOGIN_ID", SqlDbType.VarChar, 25)
        cmd.Parameters("@LOGIN_ID").Direction = ParameterDirection.Input
        cmd.Parameters("@LOGIN_ID").Value = pUserId.ToUpper.Trim.Split("@")(0)

        cmd.Parameters.Add("@LOGIN_PWD", SqlDbType.VarChar, 75)
        cmd.Parameters("@LOGIN_PWD").Direction = ParameterDirection.Input
        cmd.Parameters("@LOGIN_PWD").Value = pPass.Trim

        cmd.CommandText = $"{DefaultSchema}[OP_WMS_SP_GET_LOGIN]"
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Connection = sqldbConexion

        Dim xsql As String = ""
        Dim dataAdapter = New SqlDataAdapter(cmd)

        Dim miscDS As DataSet = New DataSet()
        Try
            dataAdapter.Fill(miscDS, "VerifyUserPass")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR,No existe usuario o password invalido : " + pUserId

            Return Nothing
        Else
            If checkserial() Then
                'ckeck license serial
                xsql = " OPEN SYMMETRIC KEY	SqlSysPropSecury "
                xsql += " DECRYPTION BY CERTIFICATE	SqlSysPropSecuryCert WITH PASSWORD = '$m0b1l17y$^Wm5^2@XIV^C3@1s@';"
                xsql += " SELECT * FROM  " + DefaultSchema + "OP_WMS_LOGINS A WHERE " &
                        " A.LOGIN_ID	=	'" & pUserId.Split("@")(0) & "' AND " &
                        " RTRIM(CONVERT(VARCHAR(MAX), DecryptByKey(LICENSE_SERIAL))) = '" & pUserId.Split("@")(0) & "'+((SELECT TOP 1 BACKOFFICE_LICENSE FROM  " + DefaultSchema + "OP_SETUP_COMPANY WHERE COMPANY_CODE = A.COMPANY_CODE)+A.ROLE_ID) "
                xsql += " CLOSE SYMMETRIC KEY SqlSysPropSecury;"
                Dim SerialDS As DataSet = New DataSet()
                Dim SerialDA As SqlDataAdapter
                Try
                    SerialDA = New SqlDataAdapter(xsql, sqldbConexion)
                    SerialDA.Fill(SerialDS, "VerifyLicense")
                    If SerialDS.Tables(0).Rows.Count <= 0 Then
                        pResult = "ERROR, invalid user certificate, please contact your system administrator"
                        Return Nothing
                    Else
                        pResult = "OK"
                        Return SerialDS
                    End If
                Catch ex As Exception
                    pResult = ex.Message
                    Return Nothing
                End Try
            Else
                pResult = "OK"
                Return miscDS

            End If

        End If


    End Function

    <WebMethod(Description:="Obtiene el valor de un parametro")>
    Public Function GetParameterValue(ByRef pResult As String, ByVal pEnvironmentName As String, groupId As String, parameterId As String) As String

        Dim sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL = ""

        XSQL = "SELECT " & DefaultSchema & "[OP_WMS_FN_GET_PARAMETER_VALUE] ('" & groupId & "','" & parameterId & "')"

        Dim dataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim dataSet = New DataSet()
        Try
            dataAdapter.Fill(dataSet, "Parameters")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If dataSet.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR, GetParameterValue no existe"
            Return Nothing
        Else
            pResult = "OK"
            Return dataSet.Tables(0).Rows(0)(0).ToString()
        End If

    End Function

    Function checkserial() As Boolean
        Try
            If Today >= "01-15-2014" Then
                Return False
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    <WebMethod(Description:="Autenticar Usuario/Password")>
    Public Function VerifyExternalUserPass(ByVal pUserID As String, ByVal pPass As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet

        Dim sqldb_conexion As SqlConnection
        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Catch ex As Exception
            pResult = ex.Message + " " + pEnvironmentName
            Return Nothing
        End Try

        Dim XSQL As String = ""
        Dim miscDA As SqlDataAdapter

        XSQL = "select * from  " + DefaultSchema + "OP_WMS_WP_SYS_ACCOUNTS where account_id = '" + pUserID + "' and pwd = '" + pPass + "'"

        Try
            miscDA = New SqlDataAdapter(XSQL, sqldb_conexion)
        Catch ex As Exception
            pResult = ex.Message
            Return Nothing
        End Try

        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "VerifyExternalUserPass")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR,No existe usuario o password invalido : " + pUserID
            LogSQLErrors("VerifyExternalUserPass_FAILED:" + pResult, pUserID + " : " + pPass, "")
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If


    End Function
    <WebMethod(Description:="Mostrar opciones del menu BASC para este usuario")>
    Public Function BringUserMenuBasc(ByVal pUserID As String, ByVal pEnvironmentName As String) As String
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

        XSQL = "SELECT * FROM  " + DefaultSchema + "[OP_WMS_FUNC_GET_USER_BASC]('" + pUserID + "') ORDER BY ACCESS"

        Try
            miscDA = New SqlDataAdapter(XSQL, sqldb_conexion)
        Catch ex As Exception
            pResult = ex.Message
            Return pResult
        End Try

        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "BringUserMenuBasc")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return pResult
        End Try

        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR,No opciones BASC para el usuario : " + pUserID
            LogSQLErrors(pResult, XSQL, "")
            Return pResult
        Else
            pResult = "OK"
            Return GetJson(miscDS.Tables(0))
        End If


    End Function


    <WebMethod(Description:="Autenticar Usuario/Password.")>
    Public Function VerifyUserPassBasc(ByVal pUserID As String, ByVal pPass As String, ByVal pEnvironmentName As String) As String
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

        XSQL = "SELECT A.*, B.WS_HOST FROM "
        XSQL = XSQL + "  " & DefaultSchema & "OP_WMS_LOGINS A,  " & DefaultSchema & "OP_SETUP_ENVIRONMENTS B WHERE B.PLATFORM = 'BASC'  AND B.ENVIRONMENT_NAME = A.ENVIRONMENT "
        XSQL = XSQL + " AND A.LOGIN_ID = '" + pUserID.ToUpper.Trim + "' AND A.LOGIN_PWD = '" + pPass.Trim + "'"

        Try
            miscDA = New SqlDataAdapter(XSQL, sqldb_conexion)
        Catch ex As Exception
            pResult = ex.Message
            Return pResult
        End Try

        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "VerifyUserPassBasc")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return pResult
        End Try

        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR,No existe usuario o password invalido : " + pUserID + "/" + pEnvironmentName
            LogSQLErrors(pResult, XSQL, "")
            Return pResult
        Else
            pResult = "OK"
            Return GetJson(miscDS.Tables(0))
        End If


    End Function

    <WebMethod(Description:="Obtner el nombre del cliente licenciado")>
    Public Function GetCompanyName(ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String = ""

        XSQL = "SELECT * FROM  " & DefaultSchema & "OP_SETUP_COMPANY "

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "GetCompanyName")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR,No existe SETUP : "
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If


    End Function
    <WebMethod(Description:="Obtener los diferentes ambientes de trabajo ")>
    Public Function GetEnvironments(ByVal pPlatform As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String = ""

        XSQL = "SELECT * FROM  " & DefaultSchema & "OP_SETUP_ENVIRONMENTS WHERE PLATFORM = '" + pPlatform + "'"

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()

        Try
            miscDA.Fill(miscDS, "GetEnvironments")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR,No existen ambientes de trabajo definidos."
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function
    <WebMethod(Description:="Obtener los diferentes ambientes de trabajo ")>
    Public Function GetEnvironmentByKey(ByVal pPlatform As String, ByVal pEnvironmentKey As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet

        Try
            Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
            Dim XSQL As String = ""

            XSQL = "SELECT * FROM " & DefaultSchema & "OP_SETUP_ENVIRONMENTS WHERE ENVIRONMENT_NAME = '" + pEnvironmentKey + "' AND PLATFORM = '" + pPlatform + "'"

            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()

            Try
                miscDA.Fill(miscDS, "GetEnvironmentByKey")
            Catch ex As Exception
                pResult = "ERROR," + ex.Message
                Return Nothing
            End Try
            If miscDS.Tables(0).Rows.Count <= 0 Then
                pResult = "ERROR,No existen ambientes de trabajo definidos."
                Return Nothing
            Else
                pResult = "OK"
                Return miscDS
            End If

        Catch ex As Exception
            pResult = ex.Message
            Return Nothing
        End Try
        Return Nothing
    End Function

    <WebMethod(Description:="Buscar usuario por multiples columnas")>
    Public Function GetCheckPointsTree(ByVal pRoleID As String, ByVal pRoleDesc As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String = ""
        XSQL = "SELECT * FROM  " & DefaultSchema & "OP_WMS_VIEW_CHECKPOINTS_TREE WHERE ROLE_ID='" + pRoleID.ToUpper.Trim + "'"
        If pRoleDesc <> "" Then
            XSQL = XSQL + " AND DESCRIPTION LIKE '%" + pRoleDesc + "%' "
        End If
        XSQL = XSQL + " ORDER BY "
        XSQL = XSQL + " ACCESS ASC"
        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "GetCheckPointsTree")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR,No existen CHECKPOINTS"
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function

    <WebMethod(Description:="Buscar Privs por AccessLevel")>
    Public Function IsUserAllowed(ByVal pCheckPointID As String, ByVal pAccessLevel As String, ByVal JoinOrNot As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String = ""

        XSQL = "SELECT * FROM  " & DefaultSchema & "OP_WMS_ROLES_JOIN_CHECKPOINTS "
        XSQL = XSQL + "WHERE ROLE_ID = '" + pAccessLevel + "'" +
        " AND CHECK_ID = '" + pCheckPointID + "'"

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "IsUserAllowed")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR,No existe OP_WMS_CHECKPOINTS : " + XSQL
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If


    End Function

    <WebMethod(Description:="Obtener permisos por usuario")>
    Public Function ObtenerPermisosPorUsuario(pLogin As String, ByRef pResult As String, pEnvironmentName As String) As DataTable
        Dim sqldbConexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()
        Try
            Dim cmd As New SqlCommand

            cmd.Parameters.Add("@LOGIN", SqlDbType.VarChar, 50)
            cmd.Parameters("@LOGIN").Direction = ParameterDirection.Input
            cmd.Parameters("@LOGIN").Value = pLogin

            cmd.CommandText = $"{DefaultSchema}[OP_WMS_SP_GET_CHECKPOINTS_BY_USER]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion

            Dim miscDa = New SqlDataAdapter(cmd)
            Dim miscDs = New DataSet()

            Try
                miscDa.Fill(miscDs, "Permisos")
            Catch ex As Exception
                pResult = $"ERROR, {ex.Message}"
                Return Nothing
            End Try

            If miscDs Is Nothing Or miscDs.Tables.Count <= 0 Then
                pResult = "No se encontraron Permisos."
                Return Nothing
            End If
            pResult = "OK"
            Return miscDs.Tables(0)
        Catch ex As Exception
            pResult = ex.Message
            Return Nothing
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try
    End Function
    <WebMethod(Description:="OBTIENE EL NIVEL DE ACCESO SOLICITADO")>
    Public Function getSecurityPermits(pParent As String, pCategory As String, pLogin As String, ByRef pResult As String, pEnvironmentName As String) As DataTable
        Dim sqldbConexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()
        Try
            Dim cmd As New SqlCommand

            cmd.Parameters.Add("@PARENT", SqlDbType.VarChar, 50)
            cmd.Parameters("@PARENT").Direction = ParameterDirection.Input
            cmd.Parameters("@PARENT").Value = pParent

            cmd.Parameters.Add("@CATEGORY", SqlDbType.VarChar, 50)
            cmd.Parameters("@CATEGORY").Direction = ParameterDirection.Input
            cmd.Parameters("@CATEGORY").Value = pCategory

            cmd.Parameters.Add("@LOGIN", SqlDbType.VarChar, 50)
            cmd.Parameters("@LOGIN").Direction = ParameterDirection.Input
            cmd.Parameters("@LOGIN").Value = pLogin

            cmd.CommandText = $"{DefaultSchema}[OP_WMS_SP_GET_SECURITY_ACCESS]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion

            Dim miscDa = New SqlDataAdapter(cmd)
            Dim miscDs = New DataSet()

            Try
                miscDa.Fill(miscDs, "Permisos")
            Catch ex As Exception
                pResult = $"ERROR, {ex.Message}"
                Return Nothing
            End Try

            If miscDs.Tables("Permisos").Rows.Count = 0 Then
                pResult = "No se encontro el permiso"
                Return Nothing
            End If
            'If miscDs Is Nothing Or miscDs.Tables.Count <= 0 Then
            'End If
            pResult = "OK"
            Return miscDs.Tables(0)
        Catch ex As Exception
            pResult = ex.Message
            Return Nothing
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try
    End Function
    <WebMethod(Description:="Buscar Privs por AccessLevel")>
    Public Function GetMobileUserMenu(ByVal pRoleID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String = ""

        XSQL = "select * from  " & DefaultSchema & "OP_WMS_CHECKPOINTS "
        XSQL = XSQL + " where CHECK_ID in (SELECT CHECK_ID FROM  " + DefaultSchema + "OP_WMS_ROLES_JOIN_CHECKPOINTS WHERE ROLE_ID = '" + pRoleID + "') AND CATEGORY = 'MOBILE_MENU_ITEM' ORDER BY MPC_4 ASC"
        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()

        Try
            miscDA.Fill(miscDS, "GetMobileUserMenu")
            If miscDS.Tables(0).Rows.Count >= 1 Then
                pResult = "OK"
                Return miscDS
            Else
                pResult = "ERROR, Usuario no tiene privilegios"
                Return Nothing
            End If
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR,No existe OP_WMS_CHECKPOINTS : " + pRoleID
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If
    End Function
    <WebMethod(Description:="Buscar Basc Privs por AccessLevel")>
    Public Function GetBascUserMenu(ByVal pRoleID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String = ""

        XSQL = "SELECT * FROM  " + DefaultSchema + "OP_BASC_VIEW_MENU "
        XSQL = XSQL + " WHERE CHECK_ID in (SELECT CHECK_ID FROM  " + DefaultSchema + "OP_WMS_ROLES_JOIN_CHECKPOINTS WHERE ROLE_ID = '" + pRoleID + "') AND CATEGORY = 'MOBILE_MENU_ITEM' ORDER BY MPC_4 ASC"
        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()

        Try
            miscDA.Fill(miscDS, "GetMobileUserMenu")
            If miscDS.Tables(0).Rows.Count >= 1 Then
                pResult = "OK"
                Return miscDS
            Else
                pResult = "ERROR, Usuario no tiene privilegios"
                Return Nothing
            End If
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR,No existe OP_WMS_CHECKPOINTS : " + pRoleID
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If
    End Function

    <WebMethod(Description:="Actualiza usuario")>
    Public Function UpdateUserPwd(ByVal pLOGIN_ID As String, ByVal pLOGIN_PWD As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String = ""
        Try
            XSQL = "UPDATE  " & DefaultSchema & "OP_WMS_LOGINS SET "
            XSQL = XSQL + "LOGIN_PWD = '" + pLOGIN_PWD + "' "
            XSQL = XSQL + " WHERE "
            XSQL = XSQL + "LOGIN_ID = '" + pLOGIN_ID.ToUpper + "'"
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

    <WebMethod(Description:="Actualiza usuario")>
    Public Function RegisterLogIn(ByVal pLOGIN_ID As String, ByVal pInOrOut As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String = ""
        Try
            XSQL = "UPDATE  " & DefaultSchema & "OP_WMS_LOGINS SET "
            If pInOrOut = "CHECK_IN" Then
                XSQL = XSQL + " IS_LOGGED = 1 "
            Else
                XSQL = XSQL + " IS_LOGGED = 0, LAST_LOGGED = CURRENT_TIMESTAMP "
            End If
            XSQL = XSQL + " WHERE "
            XSQL = XSQL + " LOGIN_ID = '" + pLOGIN_ID.ToUpper + "' "
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

    <WebMethod(Description:="usuario puede o no generar tareas")>
    Public Function UserCanGenerateTasks(ByVal pLOGIN_ID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String = ""
        XSQL = "SELECT ISNULL(GENERATE_TASKS,0) AS GENERATE_TASKS FROM  " & DefaultSchema & "OP_WMS_LOGINS WHERE UPPER(LOGIN_ID) = '" + pLOGIN_ID.ToUpper + "'"
        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "UserCanGenerateTasks")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return False
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR,No existe UserLogin : " + pLOGIN_ID
            Return False
        Else
            If miscDS.Tables(0).Rows(0)("GENERATE_TASKS") = 1 Then
                pResult = "OK"
                Return True
            Else
                pResult = "No tiene privilegios para Crear Tareas o es un BIN adicional"
                Return False
            End If
        End If

    End Function


    <WebMethod(Description:="Autenticar Usuario/Password")>
    Public Function GetLastLoginID_OnThisTerminal(ByVal pTerminalIP As String, ByRef pResult As String, ByVal pEnvironmentName As String) As String

        'Marzo-27-2011 Creacion de funcion para determinar el ultimo usuario logged en una terminal en especifico. busqueda por IP address.

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String = ""

        XSQL = "SELECT LOGIN_ID FROM  " & DefaultSchema & "OP_WMS_TERMINALS "
        XSQL = XSQL + " where TERMINAL_IP = '" + pTerminalIP.Trim + "'"

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "GetLastLoginID_OnThisTerminal")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message + " / " + pEnvironmentName + " / " + XSQL
            Return ""
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR,No existe Terminal: " + pTerminalIP
            Return "ERROR"
        Else
            pResult = "OK"
            Return miscDS.Tables(0).Rows(0)("LOGIN_ID").ToString
        End If
    End Function

    <WebMethod(Description:="Actualiza usuario")>
    Public Function RegisterTerminalLogIn(ByVal pTERMINAL_IP As String, ByVal pLOGIN_ID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean


        Try
            Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
            Dim XSQL As String = ""

            XSQL = "SELECT LOGIN_ID FROM  " & DefaultSchema & "OP_WMS_TERMINALS "
            XSQL = XSQL + "where TERMINAL_IP = '" + pTERMINAL_IP.Trim + "'"

            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()

            Try
                miscDA.Fill(miscDS, "GetLastLoginID_OnThisTerminal")

            Catch ex As Exception
                pResult = "ERROR," + ex.Message + " " + XSQL
                Return False
            End Try
            If miscDS.Tables(0).Rows.Count >= 1 Then
                Try
                    XSQL = "UPDATE  " & DefaultSchema & "OP_WMS_TERMINALS SET "
                    XSQL = XSQL + " LOGIN_ID = '" + pLOGIN_ID.Trim.ToUpper + "', LAST_LOGON = CURRENT_TIMESTAMP "
                    XSQL = XSQL + " WHERE "
                    XSQL = XSQL + " TERMINAL_IP = '" + pTERMINAL_IP.ToUpper + "' "

                    'XSQL = XSQL + "XXXXXX" + pEnvironmentName

                    'If ExecuteSqlTransaction(sqldb_conexion.ConnectionString, XSQL, pResult) Then
                    If ExecuteSqlTransaction(AppSettings(pEnvironmentName).ToString, XSQL, pResult) Then
                        Return True
                    Else
                        pResult = "AFTER: " + pResult + " " + sqldb_conexion.ConnectionString
                        Return False
                    End If
                Catch ex As Exception
                    pResult = ex.Message + " " + XSQL + " " + sqldb_conexion.ConnectionString + " " + pEnvironmentName
                    Return False
                End Try

            Else

                Try
                    XSQL = "INSERT INTO  " & DefaultSchema & "OP_WMS_TERMINALS (TERMINAL_IP, LOGIN_ID, LAST_LOGON) VALUES ("
                    XSQL = XSQL + " '" + pTERMINAL_IP.Trim.ToUpper + "',"
                    XSQL = XSQL + " '" + pLOGIN_ID.Trim.ToUpper + "',CURRENT_TIMESTAMP)"

                    'If ExecuteSqlTransaction(sqldb_conexion.ConnectionString, XSQL, pResult) Then
                    If ExecuteSqlTransaction(AppSettings(pEnvironmentName).ToString, XSQL, pResult) Then

                        Return True
                    Else
                        pResult = pResult + " " + XSQL
                        Return False
                    End If
                Catch ex As Exception
                    pResult = ex.Message + " " + XSQL
                    Return False
                End Try

            End If
        Catch ex As Exception
            pResult = ex.Message
            Return False
        End Try
    End Function

    <WebMethod(Description:="Actualiza usuario")>
    Public Function KillBroadcast(ByVal pBroadCastLOGIN_ID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String = ""
        Try
            XSQL = "UPDATE  " & DefaultSchema & "OP_WMS_LOGINS SET IS_LOGGED = 0"
            XSQL = XSQL + " WHERE "
            XSQL = XSQL + "LOGIN_ID <> '" + pBroadCastLOGIN_ID.ToUpper + "'"
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

    <WebMethod(Description:="Obtiene usuarios notificacion carta cupo")>
    Public Function GetUsersNotifyLetterQuota(ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet

        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim xsql As String = ""

        xsql = "SELECT * FROM  " & DefaultSchema & "OP_WMS_LOGINS "
        xsql = xsql + " where NOTIFY_LETTER_QUOTA = 1"

        Dim miscDa As SqlDataAdapter = New SqlDataAdapter(xsql, sqldbConexion)
        Dim miscDs As DataSet = New DataSet()
        Try
            miscDa.Fill(miscDs, "GetUsersNotifyLetterQuota")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDs.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR, No hay usuarios para notificar"
            Return Nothing
        Else
            pResult = "OK"
            Return miscDs
        End If
    End Function

    <WebMethod(Description:="Valida las credenciales (dominio, usuario y contraseña) del operador")>
    Public Function ValidateCredentialsOfUser(userLoginId As String, userPass As String, environmentName As String, ByRef errorMessage As String) As DataTable
        Dim sqldbConexion = New SqlConnection(AppSettings(environmentName).ToString)
        sqldbConexion.Open()
        Try
            Dim cmd As New SqlCommand

            cmd.Parameters.Add("@LOGIN_ID", SqlDbType.VarChar, 50)
            cmd.Parameters("@LOGIN_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@LOGIN_ID").Value = userLoginId.Split("@")(0)

            cmd.Parameters.Add("@DOMAIN", SqlDbType.VarChar, 50)
            cmd.Parameters("@DOMAIN").Direction = ParameterDirection.Input
            cmd.Parameters("@DOMAIN").Value = userLoginId.Split("@")(1)

            cmd.Parameters.Add("@PASSWORD", SqlDbType.VarChar, 50)
            cmd.Parameters("@PASSWORD").Direction = ParameterDirection.Input
            cmd.Parameters("@PASSWORD").Value = userPass

            cmd.CommandText = $"{DefaultSchema}[OP_WMS_SP_VALIDATE_CREDENTIALS_OF_USER]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion

            Dim dataAdapter = New SqlDataAdapter(cmd)
            Dim dataSet = New DataSet()

            Try
                dataAdapter.Fill(dataSet, "UserCredentials")
            Catch ex As Exception
                errorMessage = ex.Message
                Return Nothing
            End Try

            Return dataSet.Tables(0)
        Catch ex As Exception
            errorMessage = ex.Message
            Return Nothing
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try
    End Function


    Function ValidarLicencia(loginId As String, password As String) As String
        Dim mensaje = String.Empty
        Try
            Dim deviceId = GetMacAddress()

            Dim urlApi = Encrypt.DecryptText(AppSettings("URL_API").ToString)
            Dim parameters = $"(loginId='{loginId}',password='{password}',codeApp='SWIFT_3PL_BACKOFFICE',deviceId='{deviceId}')"
            Dim url = $"{urlApi}{Enums.GetStringValue(ApiOptions.ValidarCredenciales)}{parameters}"

            Dim result = Rest.ExecuteGet(url)
            Dim json = JObject.Parse(result)

            Dim err = CStr(json("error"))

            If (Not String.IsNullOrEmpty(err)) Then
                Dim jsonDeError = JObject.Parse(err)
                mensaje = jsonDeError("error")("message").Value(Of String)()
            End If
        Catch ex As WebException
            Dim stream As Stream = Nothing
            Dim respuesta = String.Empty
            stream = ex.Response.GetResponseStream()


            If stream IsNot Nothing Then

                Dim reader = New StreamReader(stream)
                respuesta = reader.ReadToEnd()
            End If

            If Not String.IsNullOrEmpty(respuesta) Then
                Dim jsonDeError = JObject.Parse(respuesta)
                mensaje = jsonDeError("error")("message").Value(Of String)()
                mensaje = TraducirMensajeDeErrorDelApi(mensaje)
            End If
        Catch ex As Exception
            mensaje = "Error al validar la licencia: " + ex.Message
        End Try
        Return mensaje
    End Function

    Public Function GetMacAddress() As String
        For Each nic As NetworkInterface In NetworkInterface.GetAllNetworkInterfaces()

            If nic.NetworkInterfaceType = NetworkInterfaceType.Ethernet AndAlso nic.OperationalStatus = OperationalStatus.Up Then
                Return nic.GetPhysicalAddress().ToString()
            End If
        Next
        Return String.Empty
    End Function

    Private Function TraducirMensajeDeErrorDelApi(ByVal mensaje As String) As String

        Select Case mensaje
            Case Enums.GetStringValue(MensajeDeErrorDelApi.ContraseñaIncorrecta)
                mensaje = Enums.GetStringValue(MensajeDeErrorDelApiTraducido.ContraseñaIncorrecta)
            Case Enums.GetStringValue(MensajeDeErrorDelApi.EmpresaBloqueada)
                mensaje = Enums.GetStringValue(MensajeDeErrorDelApiTraducido.EmpresaBloqueada)
            Case Enums.GetStringValue(MensajeDeErrorDelApi.LicenciaBloqueada)
                mensaje = Enums.GetStringValue(MensajeDeErrorDelApiTraducido.LicenciaBloqueada)
            Case Enums.GetStringValue(MensajeDeErrorDelApi.LicenciaExpirada)
                mensaje = Enums.GetStringValue(MensajeDeErrorDelApiTraducido.LicenciaExpirada)
            Case Enums.GetStringValue(MensajeDeErrorDelApi.SinAcceso)
                mensaje = Enums.GetStringValue(MensajeDeErrorDelApiTraducido.SinAcceso)
            Case Enums.GetStringValue(MensajeDeErrorDelApi.UsuarioBloqueado)
                mensaje = Enums.GetStringValue(MensajeDeErrorDelApiTraducido.UsuarioBloqueado)
        End Select

        Return mensaje
    End Function

    <WebMethod(Description:="Obtine las accesos para el usuario")>
    Public Function GetCheckpointsByLogin(loginId As String, type As String, environmentName As String, ByRef resultError As String) As DataTable
        Dim sqldbConexion = New SqlConnection(AppSettings(environmentName).ToString)
        sqldbConexion.Open()
        Try
            Dim cmd As New SqlCommand

            cmd.Parameters.Add("@LOGIN_ID", SqlDbType.VarChar, 50)
            cmd.Parameters("@LOGIN_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@LOGIN_ID").Value = loginId

            cmd.Parameters.Add("@TYPE", SqlDbType.VarChar, 50)
            cmd.Parameters("@TYPE").Direction = ParameterDirection.Input
            cmd.Parameters("@TYPE").Value = type

            cmd.CommandText = $"{DefaultSchema}[OP_WMS_SP_GET_CHECKPOINTS_BY_LOGIN]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion

            Dim dataAdapter = New SqlDataAdapter(cmd)
            Dim dataSet = New DataSet()

            Try
                dataAdapter.Fill(dataSet, "UserCredentials")
            Catch ex As Exception
                resultError = ex.Message
                Return Nothing
            End Try

            Return dataSet.Tables(0)
        Catch ex As Exception
            resultError = ex.Message
            Return Nothing
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try
    End Function

End Class