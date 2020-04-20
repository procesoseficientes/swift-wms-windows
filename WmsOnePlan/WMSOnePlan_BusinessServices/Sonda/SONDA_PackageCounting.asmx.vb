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
Public Class SONDA_PackageCounting
    Inherits System.Web.Services.WebService

    <WebMethod(Description:="Get my TODAY completed review tasks")> _
    Public Function GetMyCompletedReviewTasks(ByVal pLoginID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings("SONDA").ToString)
        Dim SQL As String = ""
        Dim pDebugInfo As String = ""
        sqldb_conexion.Open()

        Try

            SQL = " SELECT   A.ROUTE_ID, "
            SQL = SQL & "    ( "
            SQL = SQL & "        SELECT COUNT(1) FROM " + AppSettings("SONDA_DB_OWNER").ToString + ".SONDA_DOCS "
            SQL = SQL & "        WHERE COUNTED_ASSIGNED_TO = '" + pLoginID + "' AND "
            SQL = SQL & "        CONVERT(CHAR(10),LAST_UPDATE,120) = CONVERT(CHAR(10),GETDATE(),120) AND "
            SQL = SQL & "        STATUS = 'LOADED' AND "
            SQL = SQL & "        ROUTE_ID = A.ROUTE_ID "
            SQL = SQL & "     "
            SQL = SQL & "    ) AS TASKS_COMPLETED, "
            SQL = SQL & "    ( "
            SQL = SQL & "        SELECT COUNT(1) FROM " + AppSettings("SONDA_DB_OWNER").ToString + ".SONDA_DOCS "
            SQL = SQL & "        WHERE COUNTED_ASSIGNED_TO =  '" + pLoginID + "' AND "
            SQL = SQL & "        CONVERT(CHAR(10),LAST_UPDATE,120) = CONVERT(CHAR(10),GETDATE(),120) AND "
            SQL = SQL & "        STATUS IN('LOADED','TO_VERIFY') AND "
            SQL = SQL & "        ROUTE_ID = A.ROUTE_ID "
            SQL = SQL & "     "
            SQL = SQL & "    ) AS TASKS_TOTAL_TODAY "
            SQL = SQL & "     "
            Sql = Sql & "FROM "
            SQL = SQL & "    " + AppSettings("SONDA_DB_OWNER").ToString + ".SONDA_DOCS A "
            SQL = SQL & "WHERE "
            SQL = SQL & "    A.COUNTED_ASSIGNED_TO = '" + pLoginID + "' AND "
            Sql = Sql & "    CONVERT(CHAR(10),A.LAST_UPDATE,120) = CONVERT(CHAR(10),GETDATE(),120) AND "
            SQL = SQL & "    A.STATUS = 'LOADED' GROUP BY A.ROUTE_ID"


            pDebugInfo = "0"

            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(SQL, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()
            pDebugInfo = "1"
            miscDA.Fill(miscDS, "ROUTES")
            pDebugInfo = "2"
            If miscDS.Tables(0).Rows.Count <= 0 Then
                pResult = "ERROR, No hay tareas para : " + pLoginID
                Return Nothing
            Else
                pDebugInfo = "2.1"
                Dim xsql As String = ""
                xsql = "SELECT BOX_ID + '  [' + CAST(VERIFIED_DATETIME AS nvarchar(25))+']' AS BOX_ID_CAPTION, "
                xsql = xsql + " (SELECT TOP 1 Z.ROUTE_ID FROM " + AppSettings("SONDA_DB_OWNER").ToString + ".SONDA_DOCS Z WHERE Z.DOC_ID = DOC_ID) AS ROUTE_ID "
                xsql = xsql + " FROM " + AppSettings("SONDA_DB_OWNER").ToString + ".SONDA_ORDERS_BY_DOC  "
                xsql = xsql + " WHERE "
                xsql = xsql + " STATUS = 'VERIFIED' AND CONVERT(CHAR(10),VERIFIED_DATETIME,120) = CONVERT(CHAR(10),GETDATE(),120) ORDER BY VERIFIED_DATETIME DESC "
                
                pDebugInfo = "2.2"

                miscDA.SelectCommand = New SqlCommand(XSQL, sqldb_conexion)
                miscDA.Fill(miscDS, "TASKS")

                If miscDS.Tables(0).Rows.Count <= 0 Then
                    pResult = "ERROR, No hay tareas (DET) para : " + pLoginID
                    Return Nothing
                Else
                    Try
                        miscDS.Relations.Add("TASKS_X_ROUTES", miscDS.Tables("ROUTES").Columns("ROUTE_ID"), miscDS.Tables("TASKS").Columns("ROUTE_ID"))
                    Catch ex As Exception

                    End Try

                    pResult = "OK"
                    Return miscDS
                End If

            End If

        Catch ex As Exception
            pResult = "ERROR, " + ex.Message + " pDebugInfo: "
            Return Nothing
        Finally
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try


    End Function

    <WebMethod(Description:="Get my counting tasks")> _
    Public Function GetMyCountingTasks(ByVal pLOGIN_ID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings("SONDA").ToString)
        Dim XSQL As String = ""
        Dim pDebugInfo As String = ""
        sqldb_conexion.Open()

        Try

            XSQL = "        SELECT TOP 75 "
            XSQL = XSQL + "     A.ROUTE, A.ERP_DOC, (A.ERP_DOC + ' - '+ CAST(A.SCANNED as varchar(25)) + '/'+ CAST(A.TOTAL_PACKAGES AS VARCHAR(25))) AS DOC_CAPTION, "
            'XSQL = XSQL + "     (B.ROUTE + ' : '+(CAST(B.SCANNED as varchar(25)) + '/'+ CAST(A.TOTAL_PACKAGES AS VARCHAR(25)))) AS ROUTE_CAPTION, "
            XSQL = XSQL + "     A.ROUTE AS ROUTE_CAPTION, "
            XSQL = XSQL + "     A.SCANNED_PERC, "
            XSQL = XSQL + "     A.SCANNED, "
            XSQL = XSQL + "     A.TOTAL_PACKAGES, A.STATUS"
            XSQL = XSQL + " FROM "
            XSQL = XSQL + "     " + AppSettings("SONDA_DB_OWNER").ToString + ".SONDA_VIEW_TASK_OVERVIEW_BY_DOCS A "
            'XSQL = XSQL + "     dbo.SONDA_VIEW_TASK_OVERVIEW_BY_ROUTES B "
            XSQL = XSQL + " WHERE"
            XSQL = XSQL + "     A.assigned_to = '" + pLOGIN_ID + "'"
            'XSQL = XSQL + "     AND A.SCANNED < A.TOTAL_PACKAGES"
            XSQL = XSQL + "     AND A.STATUS <> 'COMPLETED'"
            'XSQL = XSQL + "     AND B.ROUTE = A.ROUTE"
            XSQL = XSQL + " ORDER BY"
            XSQL = XSQL + "     A.scanned_perc desc"

            pDebugInfo = "0"

            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()
            pDebugInfo = "1"
            miscDA.Fill(miscDS, "DISPATCH")
            pDebugInfo = "2"
            If miscDS.Tables(0).Rows.Count <= 0 Then
                pResult = "ERROR, No hay tareas para : " + pLOGIN_ID
                Return Nothing
            Else
                pDebugInfo = "2.1"

                XSQL = "SELECT ERP_DOC, BOX_ID, PENDING_TO_SCAN, LAST_UPDATED, (BOX_ID + '   [' + CAST(LAST_UPDATED AS nvarchar(25))+']') AS BOX_ID_CAPTION "
                XSQL = XSQL + " FROM " + AppSettings("DB_LINK").ToString + "OP_WMS_PACKAGES_X_DISPATCH  "
                XSQL = XSQL + " WHERE ASSIGNED_TO = '" + pLOGIN_ID + "' AND STATUS <> 'COMPLETED'"

                'XSQL = XSQL + " WHERE ASSIGNED_TO = '" + pLOGIN_ID + "' AND SCANNED < PENDING_TO_SCAN"

                pDebugInfo = "2.2"

                miscDA.SelectCommand = New SqlCommand(XSQL, sqldb_conexion)
                miscDA.Fill(miscDS, "PACKAGES")

                If miscDS.Tables(0).Rows.Count <= 0 Then
                    pResult = "ERROR, No hay tareas (DET) para : " + pLOGIN_ID
                    Return Nothing
                Else
                    Try
                        miscDS.Relations.Add("PACKAGES_X_DISPATCH", miscDS.Tables("DISPATCH").Columns("ERP_DOC"), miscDS.Tables("PACKAGES").Columns("ERP_DOC"))
                    Catch ex As Exception

                    End Try
                    
                    pResult = "OK"
                    Return miscDS
                End If

            End If

        Catch ex As Exception
            pResult = "ERROR, " + ex.Message + " pDebugInfo: "
            Return Nothing
        Finally
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try


    End Function
    <WebMethod(Description:="Get my counting tasks")> _
    Public Function GetMyCompletedCountingTasks(ByVal pLOGIN_ID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings("SONDA").ToString)
        Dim XSQL As String = ""
        Dim pDebugInfo As String = ""
        sqldb_conexion.Open()

        Try

            XSQL = "        SELECT TOP 100 "
            XSQL = XSQL + "     A.ROUTE, A.ERP_DOC, (A.ERP_DOC + ' - '+ CAST(A.SCANNED as varchar(25)) + '/'+ CAST(A.TOTAL_PACKAGES AS VARCHAR(25))) AS DOC_CAPTION, "
            XSQL = XSQL + "     (B.ROUTE + ' : '+(CAST(B.SCANNED as varchar(25)) + '/'+ CAST(A.TOTAL_PACKAGES AS VARCHAR(25)))) AS ROUTE_CAPTION, "
            XSQL = XSQL + "     A.SCANNED_PERC, "
            XSQL = XSQL + "     A.SCANNED, "
            XSQL = XSQL + "     A.TOTAL_PACKAGES, A.STATUS"
            XSQL = XSQL + " FROM "
            XSQL = XSQL + "     " + AppSettings("SONDA_DB_OWNER").ToString + ".SONDA_VIEW_TASK_OVERVIEW_BY_DOCS A, "
            XSQL = XSQL + "     " + AppSettings("SONDA_DB_OWNER").ToString + ".SONDA_VIEW_TASK_OVERVIEW_BY_ROUTES B "
            XSQL = XSQL + " WHERE"
            XSQL = XSQL + "     A.assigned_to = '" + pLOGIN_ID + "'"
            XSQL = XSQL + "     AND A.SCANNED = A.TOTAL_PACKAGES"
            XSQL = XSQL + "     AND B.ROUTE = A.ROUTE"
            XSQL = XSQL + " ORDER BY"
            XSQL = XSQL + "     A.scanned_perc Asc"

            pDebugInfo = "0"

            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()
            pDebugInfo = "1"
            miscDA.Fill(miscDS, "DISPATCH")
            pDebugInfo = "2"
            If miscDS.Tables(0).Rows.Count <= 0 Then
                pResult = "ERROR, No hay tareas para : " + pLOGIN_ID
                Return Nothing
            Else
                pDebugInfo = "2.1"

                XSQL = "SELECT ERP_DOC, BOX_ID, PENDING_TO_SCAN, LAST_UPDATED, (BOX_ID + '   [' + CAST(LAST_UPDATED AS nvarchar(25))+']') AS BOX_ID_CAPTION FROM " + AppSettings("DB_LINK").ToString + "OP_WMS_PACKAGES_X_DISPATCH "
                XSQL = XSQL + " WHERE ASSIGNED_TO = '" + pLOGIN_ID + "' AND STATUS = 'COMPLETED'"

                pDebugInfo = "2.2"

                miscDA.SelectCommand = New SqlCommand(XSQL, sqldb_conexion)
                miscDA.Fill(miscDS, "PACKAGES")

                If miscDS.Tables(0).Rows.Count <= 0 Then
                    pResult = "ERROR, No hay tareas (DET) para : " + pLOGIN_ID
                    Return Nothing
                Else

                    miscDS.Relations.Add("PACKAGES_X_DISPATCH", miscDS.Tables("DISPATCH").Columns("ERP_DOC"), miscDS.Tables("PACKAGES").Columns("ERP_DOC"))

                    pResult = "OK"
                    Return miscDS
                End If

            End If

        Catch ex As Exception
            pResult = "ERROR, " + ex.Message + " pDebugInfo: "
            Return Nothing
        Finally
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try



    End Function
    <WebMethod(Description:="Actualiza la tarea de conteo")> _
    Public Function UpdateCountingTask(ByVal pBOX_ID As String, ByVal pLogin As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings("SONDA").ToString)
        sqldb_conexion.Open()

        Try

            Dim cmd As New SqlCommand

            cmd.Parameters.Add("@pBOXID", SqlDbType.VarChar, 50)
            cmd.Parameters("@pBOXID").Direction = ParameterDirection.Input
            cmd.Parameters("@pBOXID").Value = pBOX_ID

            cmd.Parameters.Add("@pLOGIN_ID", SqlDbType.VarChar, 25)
            cmd.Parameters("@pLOGIN_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@pLOGIN_ID").Value = pLogin

            cmd.Parameters.Add("@pRESULT", SqlDbType.VarChar, 250)
            cmd.Parameters("@pRESULT").Direction = ParameterDirection.Output
            cmd.Parameters("@pRESULT").Value = ""

            cmd.CommandText = "SONDA_SP_UPDATE_COUNTING_TASK"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldb_conexion

            cmd.ExecuteNonQuery()

            sqldb_conexion.Close()
            pResult = cmd.Parameters("@pRESULT").Value.ToString
            Return IIf(pResult = "OK", True, False)

        Catch ex As Exception
            pResult = ex.Message
            Return False
        Finally
            sqldb_conexion.Close()
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try

    End Function
    <WebMethod(Description:="Get my counting tasks")> _
    Public Function GetAllCountingTasks(ByVal pSinceDate As Date, ByVal pToDate As Date, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings("SONDA").ToString)
        Dim XSQL As String = ""
        Dim pFormatedDate_Since As String
        Dim pFormatedDate_To As String

        pFormatedDate_Since = Format(pSinceDate, "yyyy-MM-dd") + " 0:00:00"
        pFormatedDate_To = Format(pToDate, "yyyy-MM-dd") + " 23:59:00"

        Dim pDebugInfo As String = ""
        sqldb_conexion.Open()



        Try

            XSQL = "        SELECT * "
            XSQL = XSQL + " FROM "
            XSQL = XSQL + "     dbo.SONDA_VIEW_ALLCOUTING"
            XSQL = XSQL + " WHERE"
            XSQL = XSQL + " CREADA_EL BETWEEN CONVERT(CHAR(25),'" + pFormatedDate_Since + "',21) AND CONVERT(CHAR(25),'" + pFormatedDate_To + "',21) "

            XSQL = XSQL + " ORDER BY"
            XSQL = XSQL + "     RUTA, PEDIDO"

            pDebugInfo = "0"

            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()
            pDebugInfo = "1"
            miscDA.Fill(miscDS, "DISPATCH")
            pDebugInfo = "2"
            If miscDS.Tables(0).Rows.Count <= 0 Then
                pResult = "ERROR, No hay tareas en ese rango de fechas "
                Return Nothing
            Else
                pResult = "OK"
                Return miscDS
            End If

        Catch ex As Exception
            pResult = "ERROR, " + ex.Message + " pDebugInfo: "
            Return Nothing
        Finally
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try



    End Function
    Public Function GetDOC_ID(ByVal pBOX_ID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Integer
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings("SONDA").ToString)
        Dim XSQL As String = ""
        sqldb_conexion.Open()

        Try

            XSQL = "        SELECT DOC_ID "
            XSQL = XSQL + " FROM "
            XSQL = XSQL + "     dbo.SONDA_ORDERS_BY_DOC"
            XSQL = XSQL + " WHERE BOX_ID = '" + pBOX_ID + "'"


            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()
            miscDA.Fill(miscDS, "DISPATCH")
            If miscDS.Tables(0).Rows.Count <= 0 Then
                pResult = "ERROR, No Documento no existe "
                Return 0
            Else
                pResult = "OK"
                Return miscDS.Tables(0).Rows(0)("DOC_ID")
            End If

        Catch ex As Exception
            pResult = "ERROR, " + ex.Message + " pDebugInfo: "
            Return Nothing
        Finally
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try



    End Function

    <WebMethod(Description:="Get counting overview by operator")> _
    Public Function GetTasksOverview_ByOperator(ByVal pSinceDate As Date, ByVal pToDate As Date, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings("SONDA").ToString)
        Dim XSQL As String = ""
        Dim pFormatedDate_Since As String
        Dim pFormatedDate_To As String
        Dim pFormat As String = "MM/dd/yyyy"

        pFormatedDate_Since = Format(pSinceDate, pFormat)
        pFormatedDate_To = Format(pToDate, pFormat)

        Dim pDebugInfo As String = ""
        sqldb_conexion.Open()

        Try

            XSQL = "        SELECT * "
            XSQL = XSQL + " FROM "
            XSQL = XSQL + "     SONDA_VIEW_TASK_OVERVIEW_BY_OPERATORS"
            XSQL = XSQL + " WHERE"
            XSQL = XSQL + " CREATED_DATE BETWEEN CONVERT(CHAR(25),'" + pFormatedDate_Since + "',21) AND CONVERT(CHAR(25),'" + pFormatedDate_To + "',21) "

            XSQL = XSQL + " ORDER BY"
            XSQL = XSQL + "     CREATED_DATE, ASSIGNED_TO"

            pDebugInfo = "0"

            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()
            pDebugInfo = "1"
            miscDA.Fill(miscDS, "SONDA_VIEW_TASK_OVERVIEW_BY_OPERATORS")



            pDebugInfo = "2"
            If miscDS.Tables(0).Rows.Count <= 0 Then
                pResult = "ERROR, No hay tareas en ese rango de fechas " + pFormatedDate_Since + " " + pFormatedDate_To
                Return Nothing
            Else
                pResult = "OK"
                Return miscDS
            End If

        Catch ex As Exception
            pResult = "ERROR, " + ex.Message + " pDebugInfo: "
            Return Nothing
        Finally
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try

    End Function
    <WebMethod(Description:="Get counting overview by operator")> _
    Public Function GetTasksOverview_ByRoute(ByVal pSinceDate As Date, ByVal pToDate As Date, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings("SONDA").ToString)
        Dim XSQL As String = ""
        Dim pFormatedDate_Since As String
        Dim pFormatedDate_To As String
        Dim pFormat As String = "MM/dd/yyyy"

        pFormatedDate_Since = Format(pSinceDate, pFormat)
        pFormatedDate_To = Format(pToDate, pFormat)


        Dim pDebugInfo As String = ""
        sqldb_conexion.Open()



        Try

            XSQL = "        SELECT * "
            XSQL = XSQL + " FROM "
            XSQL = XSQL + "     SONDA_VIEW_TASK_OVERVIEW_BY_ROUTE"
            XSQL = XSQL + " WHERE"
            XSQL = XSQL + " CREATED_DATE BETWEEN CONVERT(CHAR(25),'" + pFormatedDate_Since + "',21) AND CONVERT(CHAR(25),'" + pFormatedDate_To + "',21) "

            XSQL = XSQL + " ORDER BY"
            XSQL = XSQL + "     CREATED_DATE, ROUTE"

            pDebugInfo = "0"

            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()
            pDebugInfo = "1"
            miscDA.Fill(miscDS, "SONDA_VIEW_TASK_OVERVIEW_BY_ROUTE")



            pDebugInfo = "2"
            If miscDS.Tables(0).Rows.Count <= 0 Then
                pResult = "ERROR, No hay tareas en ese rango de fechas "
                Return Nothing
            Else
                pResult = "OK"
                Return miscDS
            End If

        Catch ex As Exception
            pResult = "ERROR, " + ex.Message + " pDebugInfo: "
            Return Nothing
        Finally
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try
    End Function
    <WebMethod(Description:="Get counting overview by operator")> _
    Public Function GetCompletedAverage(ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings("SONDA").ToString)
        Dim XSQL As String = ""

        Dim pDebugInfo As String = ""
        sqldb_conexion.Open()

        Try

            XSQL = "SELECT AVG(SCANNED_PERC) AS AVG_SCANNED_PERC FROM [SONDA_VIEW_TASK_OVERVIEW_BY_DOCS]"

            pDebugInfo = "0"

            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()
            pDebugInfo = "1"
            miscDA.Fill(miscDS, "GetCompletedAverage")

            pDebugInfo = "2"
            If miscDS.Tables(0).Rows.Count <= 0 Then
                pResult = "ERROR, No hay datos para determinar el promedio. GetCompletedAverage "
                Return Nothing
            Else
                pResult = "OK"
                Return miscDS
            End If

        Catch ex As Exception
            pResult = "ERROR, " + ex.Message + " pDebugInfo: "
            Return Nothing
        Finally
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try
    End Function
    <WebMethod(Description:="Get my counting tasks")> _
    Public Function GetAllRoutesCompleted(ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings("SONDA").ToString)
        Dim XSQL As String = ""

        Dim pDebugInfo As String = ""
        sqldb_conexion.Open()

        Try

            XSQL = "        SELECT * "
            XSQL = XSQL + " FROM "
            XSQL = XSQL + "     dbo.SONDA_VIEW_COMPLETED_ROUTES"
            XSQL = XSQL + " ORDER BY"
            XSQL = XSQL + "     ROUTE"

            pDebugInfo = "0"

            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()
            pDebugInfo = "1"
            miscDA.Fill(miscDS, "GetAllRoutesCompleted")
            pDebugInfo = "2"
            If miscDS.Tables(0).Rows.Count <= 0 Then
                pResult = "ERROR, No hay rutas completadas "
                Return Nothing
            Else
                pResult = "OK"
                Return miscDS
            End If

        Catch ex As Exception
            pResult = "ERROR, " + ex.Message
            Return Nothing
        Finally
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try



    End Function
    <WebMethod(Description:="Get counting overview by operator")> _
    Public Function GetCompletedOrdersByRoute(ByVal pRouteID As String, ByVal pLoginID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet


        If AppSettings("DB_LINK") Is Nothing Then
            pResult = "ERROR, variable DB_LINK no existe, en archivo de configuracion."
            Return Nothing
        End If

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String = ""



        Dim pDebugInfo As String = ""
        sqldb_conexion.Open()

        Try

            XSQL = "        SELECT ROUTE, ERP_DOC, CLIENT_NAME, TOTAL_PACKAGES, FV, 'EMPTY' AS TRANSPORT_UNIT, '' AS TRANSPORT_CAPTION, 0 AS COMPANY_ID "
            XSQL = XSQL + " FROM "
            XSQL = XSQL + "     " + AppSettings("SONDA_DB_OWNER").ToString + ".SONDA_VIEW_COMPLETED_ROUTE_ORDERS"
            XSQL = XSQL + " WHERE"
            XSQL = XSQL + " ROUTE = '" + pRouteID + "' AND "
            XSQL = XSQL + " ERP_DOC NOT IN (SELECT ERP_DOC FROM " + AppSettings("SONDA_DB_OWNER").ToString + ".SONDA_ROUTE_IN_DESIGN WHERE LOGIN_ID = '" + pLoginID + "' AND ROUTE = '" + pRouteID + "')"

            pDebugInfo = "0"

            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()
            pDebugInfo = "1"
            miscDA.Fill(miscDS, "GetCompletedOrdersByRoute")

            pDebugInfo = "2"
            If miscDS.Tables(0).Rows.Count <= 0 Then
                pResult = "ERROR, No hay pedidos para esta ruta " + pRouteID
                Return Nothing
            Else
                pResult = "OK"
                Return miscDS
            End If

        Catch ex As Exception
            pResult = "ERROR, " + ex.Message + " pDebugInfo: "
            Return Nothing
        Finally
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try
    End Function
    <WebMethod(Description:="Get my first verifying counting tasks")> _
   Public Function GetMyFirstVerifyingTask(ByVal pLOGIN_ID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings("SONDA").ToString)
        Dim XSQL As String = ""
        Dim pDebugInfo As String = ""
        sqldb_conexion.Open()

        Try

            XSQL = "        SELECT TOP 1"
            XSQL = XSQL + "   *  "
            XSQL = XSQL + " FROM "
            XSQL = XSQL + "     " + AppSettings("SONDA_DB_OWNER").ToString + ".SONDA_DOCS "
            XSQL = XSQL + " WHERE"
            XSQL = XSQL + "     COUNTED_ASSIGNED_TO = '" + pLOGIN_ID + "'"
            XSQL = XSQL + "     AND STATUS IN('TO_VERIFY','LOADING')"
            XSQL = XSQL + " ORDER BY"
            XSQL = XSQL + "     CREATED"

            pDebugInfo = "0"

            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()
            pDebugInfo = "1"
            miscDA.Fill(miscDS, "DISPATCH")
            pDebugInfo = "2"
            If miscDS.Tables(0).Rows.Count <= 0 Then
                pResult = "ERROR, No hay tareas de veficacion para : " + pLOGIN_ID
                Return Nothing
            Else
                pResult = "OK"
                Return miscDS
            End If

        Catch ex As Exception
            pResult = "ERROR, " + ex.Message
            Return Nothing
        Finally
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try


    End Function
    <WebMethod(Description:="Get my first verifying counting tasks")> _
   Public Function GetCountMyVerifyingTasks(ByVal pLOGIN_ID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings("SONDA").ToString)
        Dim XSQL As String = ""
        Dim pDebugInfo As String = ""
        sqldb_conexion.Open()

        Try

            XSQL = "        SELECT COUNT(1) AS TOTAL_PENDING_TASK"
            XSQL = XSQL + " FROM "
            XSQL = XSQL + "     " + AppSettings("SONDA_DB_OWNER").ToString + ".SONDA_DOCS "
            XSQL = XSQL + " WHERE"
            XSQL = XSQL + "     COUNTED_ASSIGNED_TO = '" + pLOGIN_ID + "'"
            XSQL = XSQL + "     AND STATUS IN ('TO_VERIFY','LOADING')"

            pDebugInfo = "0"

            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()
            pDebugInfo = "1"
            miscDA.Fill(miscDS, "DISPATCH")
            pDebugInfo = "2"
            If miscDS.Tables(0).Rows.Count <= 0 Then
                pResult = "ERROR, No hay tareas de veficacion para : " + pLOGIN_ID
                Return Nothing
            Else
                pResult = "OK"
                Return miscDS
            End If

        Catch ex As Exception
            pResult = "ERROR, " + ex.Message + " debug info: " + pDebugInfo
            Return Nothing
        Finally
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try


    End Function
    <WebMethod(Description:="Get my validating task header")> _
    Public Function GetValidatingTask_Header(ByVal pSONDA_DOC As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings("SONDA").ToString)
        Dim XSQL As String = ""
        Dim pDebugInfo As String = ""
        sqldb_conexion.Open()

        Try

            XSQL = "        SELECT TOP 1 C.ROUTE_ID, A.ERP_DOC, ISNULL(B.CLIENT_NAME,'N/A')AS CLIENT_NAME "
            XSQL = XSQL + " FROM " + AppSettings("SONDA_DB_OWNER").ToString + ".SONDA_DOCS C,"
            XSQL = XSQL + "     " + AppSettings("SONDA_DB_OWNER").ToString + ".SONDA_ORDERS_BY_DOC A LEFT OUTER JOIN "
            XSQL = XSQL + "     " + AppSettings("DB_LINK").ToString + "OP_WMS_DEMAND_TO_PICK B ON B.ERP_DOCUMENT = A.ERP_DOC "
            XSQL = XSQL + " WHERE"
            XSQL = XSQL + "     A.DOC_ID = " + pSONDA_DOC.ToString + " AND C.DOC_ID = A.DOC_ID"

            pDebugInfo = "0"

            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()
            pDebugInfo = "1"
            miscDA.Fill(miscDS, "GetValidatingTask_Header")
            pDebugInfo = "2"
            If miscDS.Tables(0).Rows.Count <= 0 Then
                pResult = "ERROR, No hay informacion para : " + pSONDA_DOC
                Return Nothing
            Else
                pResult = "OK"
                Return miscDS
            End If

        Catch ex As Exception
            pResult = "ERROR, " + ex.Message
            Return Nothing
        Finally
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try


    End Function
    <WebMethod(Description:="Get my validating task header")> _
    Public Function GetValidatingTask_Detail(ByVal pAssignedTo As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings("SONDA").ToString)
        Dim XSQL As String = ""
        Dim pDebugInfo As String = ""
        sqldb_conexion.Open()

        Try

            XSQL = " SELECT B.*, (SELECT TOP 1 CLIENT_NAME FROM " + AppSettings("DB_LINK").ToString + "OP_WMS_DEMAND_TO_PICK WHERE ERP_DOCUMENT = B.ERP_DOC) AS CLIENT_NAME "
            XSQL = XSQL + "     FROM " + AppSettings("SONDA_DB_OWNER").ToString + ".SONDA_ORDERS_BY_DOC B "
            XSQL = XSQL + " WHERE B.DOC_ID IN (SELECT A.DOC_ID FROM " + AppSettings("SONDA_DB_OWNER").ToString + ".SONDA_DOCS A WHERE "
            XSQL = XSQL + "     A.COUNTED_ASSIGNED_TO = '" + pAssignedTo.ToUpper.Trim + _
            "' AND STATUS IN ('TO_VERIFY','LOADING')) ORDER BY VERIFIED_DATETIME DESC, B.ERP_DOC"


            pDebugInfo = "0"

            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()
            pDebugInfo = "1"
            miscDA.Fill(miscDS, "GetValidatingTask_Detail")
            pDebugInfo = "2"
            If miscDS.Tables(0).Rows.Count <= 0 Then
                pResult = "ERROR, No hay detalle para : " + pAssignedTo
                Return Nothing
            Else
                pResult = "OK"
                Return miscDS
            End If

        Catch ex As Exception
            pResult = "ERROR, " + ex.Message
            Return Nothing
        Finally
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try


    End Function
    <WebMethod(Description:="Actualiza la tarea de verificacion")> _
    Public Function UpdateVerifyTask(ByVal pBOX_ID As String, ByVal pSTATUS As String, ByVal pLogin As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings("SONDA").ToString)
        sqldb_conexion.Open()

        Try

            Dim cmd As New SqlCommand
            Dim pDOC_ID As Integer = GetDOC_ID(pBOX_ID, pResult, pEnvironmentName)

            cmd.Parameters.Add("@pDOC_ID", SqlDbType.Int)
            cmd.Parameters("@pDOC_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@pDOC_ID").Value = pDOC_ID

            cmd.Parameters.Add("@pERP_DOC", SqlDbType.VarChar, 50)
            cmd.Parameters("@pERP_DOC").Direction = ParameterDirection.Input
            cmd.Parameters("@pERP_DOC").Value = Mid(pBOX_ID, 1, InStr(pBOX_ID, "-") - 1)

            cmd.Parameters.Add("@pBOX_ID", SqlDbType.VarChar, 50)
            cmd.Parameters("@pBOX_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@pBOX_ID").Value = pBOX_ID

            cmd.Parameters.Add("@pSTATUS", SqlDbType.VarChar, 50)
            cmd.Parameters("@pSTATUS").Direction = ParameterDirection.Input
            cmd.Parameters("@pSTATUS").Value = pSTATUS

            cmd.Parameters.Add("@pLOGIN_ID", SqlDbType.VarChar, 25)
            cmd.Parameters("@pLOGIN_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@pLOGIN_ID").Value = pLogin

            cmd.Parameters.Add("@pRESULT", SqlDbType.VarChar, 250)
            cmd.Parameters("@pRESULT").Direction = ParameterDirection.Output
            cmd.Parameters("@pRESULT").Value = ""

            cmd.CommandText = "" + AppSettings("SONDA_DB_OWNER").ToString + ".SONDA_SP_UPDATE_ORDER_BY_DOC"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldb_conexion

            cmd.ExecuteNonQuery()

            sqldb_conexion.Close()
            pResult = cmd.Parameters("@pRESULT").Value.ToString
            Return IIf(pResult = "OK", True, False)

        Catch ex As Exception
            pResult = ex.Message
            Return False
        Finally
            sqldb_conexion.Close()
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try

    End Function

    <WebMethod(Description:="Actualiza la tarea de conteo")> _
    Public Function MarkAsPrize(ByVal pBOX_ID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings("SONDA").ToString)
        sqldb_conexion.Open()

        Try

            Dim cmd As New SqlCommand

            cmd.Parameters.Add("@pBOXID", SqlDbType.VarChar, 50)
            cmd.Parameters("@pBOXID").Direction = ParameterDirection.Input
            cmd.Parameters("@pBOXID").Value = pBOX_ID

            cmd.Parameters.Add("@pRESULT", SqlDbType.VarChar, 250)
            cmd.Parameters("@pRESULT").Direction = ParameterDirection.Output
            cmd.Parameters("@pRESULT").Value = ""

            cmd.CommandText = "SONDA_SP_MARK_AS_PRIZE"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldb_conexion

            cmd.ExecuteNonQuery()

            sqldb_conexion.Close()
            pResult = cmd.Parameters("@pRESULT").Value.ToString
            Return IIf(pResult = "OK", True, False)

        Catch ex As Exception
            pResult = ex.Message
            Return False
        Finally
            sqldb_conexion.Close()
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try

    End Function


    


End Class