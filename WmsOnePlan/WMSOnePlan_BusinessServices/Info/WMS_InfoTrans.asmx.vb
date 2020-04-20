Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Configuration.ConfigurationManager
Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Security.Cryptography.X509Certificates
Imports WMSOnePlan_BusinessServices.ModuleServices
Imports System.Web.Script.Services

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")>
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)>
<ToolboxItem(False)>
Public Class WMS_InfoTrans
    Inherits System.Web.Services.WebService
    Dim xsql As String
    <WebMethod(Description:="Get Occupancy Level")>
    Public Function GetOccupancyLevel(ByVal pDate As String, ByVal pDateTo As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet

        Dim sqldb_conexion As SqlConnection
        sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim SQL As String = ""
        Dim pDebugInfo As String = ""
        sqldb_conexion.Open()

        Try
            SQL = "SELECT * FROM  " + DefaultSchema + "OP_WMS_FUNC_GET_OCCUPANCY_LEVEL('" + pDate + "','" + pDateTo + "')"


            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(SQL, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()

            miscDA.Fill(miscDS, "GetOccupancyLevel")

            If miscDS.Tables(0).Rows.Count <= 0 Then
                pResult = "ERROR, No hay informacion para la medicion de ocupacion."
                Return Nothing
            Else
                pResult = "OK"
                Return miscDS
            End If

        Catch ex As Exception
            pResult = "ERROR, (GetOccupancyLevel) " + ex.Message
            Return Nothing
        Finally
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try

    End Function
    <WebMethod(Description:="get occupancy level")>
    Public Function CheckIfPolizaHasReview(ByVal pPoliza As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldb_conexion As SqlConnection
        sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim SQL As String = ""
        Dim pDebugInfo As String = ""
        sqldb_conexion.Open()

        Try
            SQL = " SELECT * FROM [OP_WMS_FUNC_GET_AUDIT_BY_POLIZA]('" + pPoliza + "'); "

            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(SQL, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()

            pDebugInfo = "1"
            miscDA.Fill(miscDS, "CheckIfPolizaHasReview")
            pDebugInfo = "2"
            If miscDS.Tables(0).Rows.Count <= 0 Then
                'pResult = "ERROR, No hay informacion para la auditoria"
                'Return False
                pResult = "OK"
                Return False

            Else
                pResult = "OK"
                Return True
            End If

        Catch ex As Exception
            pResult = "ERROR, (CheckIfPolizaHasReview)" + ex.Message + " pDebugInfo: "
            Return Nothing
        Finally
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try

    End Function


    <WebMethod(Description:="determine if the scanned location is contained on a given wave and sku ")>
    Public Function GetPickingVsAudit(ByVal pSinceDate As Date, ByVal pToDate As Date, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection
        sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim SQL As String = ""
        Dim pDebugInfo As String = ""
        sqldb_conexion.Open()

        Try
            Dim pFormatedDate_Since As String
            Dim pFormatedDate_To As String

            pFormatedDate_Since = Format(pSinceDate, "yyyy-MM-dd") + " 01:00AM"
            pFormatedDate_To = Format(pToDate, "yyyy-MM-dd") + " 23:59PM"

            SQL = " SELECT * FROM  " + DefaultSchema + "OP_WMS_VIEW_PICKING_VS_AUDIT "
            SQL = SQL + "WHERE PICKING_FINISHED_DATE >= '" + pFormatedDate_Since + "' AND "
            SQL = SQL + "PICKING_FINISHED_DATE <= '" + pFormatedDate_To + "' "

            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(SQL, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()

            pDebugInfo = "1"
            miscDA.Fill(miscDS, "GetPickingVsAudit")
            pDebugInfo = "2"
            If miscDS.Tables(0).Rows.Count <= 0 Then
                pResult = "ERROR, No hay informacion para comparar picking vs auditoria"
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
    <WebMethod(Description:="determine if the scanned location is contained on a given wave and sku ")>
    Public Function GetWavePickingDetail(pWAVE_ID As Integer, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection
        sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim SQL As String = ""
        Dim pDebugInfo As String = ""
        sqldb_conexion.Open()

        Try

            SQL = "SELECT * FROM OP_WMS_VIEW_DETAIL_WAVEPICKING WHERE WAVE_PICKING_ID = " & pWAVE_ID

            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(SQL, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()

            pDebugInfo = "1"
            miscDA.Fill(miscDS, "GetWavePickingDetail")
            pDebugInfo = "2"
            If miscDS.Tables(0).Rows.Count <= 0 Then
                pResult = "ERROR, No hay informacion para esta ola " & pWAVE_ID
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


    <WebMethod(Description:="Get my first task from a given wave and sku ")>
    Public Function GetAuditLog(ByVal pDate As String, ByVal pDateTo As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim pLocalResult As String = ""
        Dim sqldb_conexion As SqlConnection
        sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim pDebugInfo As String = ""
        sqldb_conexion.Open()

        Try
            pDebugInfo = "0"
            xsql = "SELECT * FROM  " + DefaultSchema + "OP_WMS_FUNC_GET_AUDIT_RECEPTION('" + pDate + " 00:00','" + pDateTo + " 23:59')"
            pDebugInfo = "1"
            Dim miscDA_Parent As SqlDataAdapter = New SqlDataAdapter(xsql, sqldb_conexion)
            Dim miscDS_Parent As DataSet = New DataSet()
            pDebugInfo = "2"
            miscDA_Parent.Fill(miscDS_Parent, "CONTROL")
            pDebugInfo = "3"
            If miscDS_Parent.Tables(0).Rows.Count <= 0 Then
                pResult = "ERROR, No hay conteos para esta fecha: " + pDate + " / " + pDateTo
                Return Nothing
            Else
                pDebugInfo = "4"
                Dim xsql As String = ""

                xsql = "SELECT * FROM  " + DefaultSchema + "OP_WMS_FUNC_GET_AUDIT_RECEPTION_SERIAL('" + pDate + " 00:00','" + pDateTo + " 23:59')"

                pDebugInfo = "5"
                Dim miscDA_Child As SqlDataAdapter = New SqlDataAdapter(xsql, sqldb_conexion)
                'Dim miscDS_Child As DataSet = New DataSet()
                pDebugInfo = "6"
                miscDA_Child.SelectCommand = New SqlCommand(xsql, sqldb_conexion)
                miscDA_Child.Fill(miscDS_Parent, "SERIAL")
                pDebugInfo = "7"

                Try
                    If miscDS_Parent.Tables(1).Rows.Count >= 1 Then
                        Dim parentColumns As DataColumn() = New DataColumn() {miscDS_Parent.Tables("CONTROL").Columns("AUDIT_ID"), miscDS_Parent.Tables("CONTROL").Columns("MATERIAL_ID")}
                        Dim ChildColumns As DataColumn() = New DataColumn() {miscDS_Parent.Tables("SERIAL").Columns("AUDIT_ID"), miscDS_Parent.Tables("SERIAL").Columns("MATERIAL_ID")}
                        pDebugInfo = "8"
                        Try
                            pDebugInfo = "9"
                            miscDS_Parent.Relations.Add("SERIES_X_SKU", parentColumns, ChildColumns, False)
                        Catch ex As Exception
                            'LogSQLErrors("SERIES:" + ex.Message, xsql, pLocalResult)
                            pDebugInfo = "10"
                            pResult = ex.Message
                            Return Nothing
                        End Try
                        pDebugInfo = "11"
                        pResult = "OK"
                        Return miscDS_Parent
                    Else
                        pDebugInfo = "12"
                        pResult = "OK"
                        Return miscDS_Parent
                    End If
                Catch ex As Exception
                    pDebugInfo = "14"
                    pResult = "OK"
                    Return miscDS_Parent
                End Try

            End If

        Catch ex As Exception
            'LogSQLErrors(pResult, xsql, pLocalResult)
            pResult = "ERROR, " + ex.Message + " pDebugInfo: " + pDebugInfo
            Return Nothing
        Finally
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try
        Return Nothing
    End Function

    <WebMethod(Description:="Get my first task from a given wave and sku ")>
    Public Function GetAuditLogDispatch(ByVal pDate As String, ByVal pDateTo As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim pLocalResult As String = ""
        Dim sqldb_conexion As SqlConnection = Nothing
        Dim pDebugInfo As String = ""

        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
            sqldb_conexion.Open()

            xsql = "SELECT * FROM  " + DefaultSchema + "OP_WMS_FUNC_GET_AUDIT_DISPATCH('" + pDate + " 00:00','" + pDateTo + " 23:59')"

            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(xsql, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()

            miscDA.Fill(miscDS, "CONTROL")

            If miscDS.Tables(0).Rows.Count <= 0 Then
                pResult = "ERROR, No hay auditorias de despacho para esta fecha: " + pDate + " / " + pDateTo
                Return Nothing
            Else
                pDebugInfo = "2.1"
                Dim xsql As String = ""

                xsql = "SELECT * FROM  " + DefaultSchema + "OP_WMS_FUNC_GET_AUDIT_DISPATCH_SERIAL('" + pDate + " 00:00','" + pDateTo + " 23:59')"

                miscDA.SelectCommand = New SqlCommand(xsql, sqldb_conexion)
                miscDA.Fill(miscDS, "SERIAL")

                If miscDS.Tables(1).Rows.Count >= 1 Then
                    Dim parentColumns As DataColumn() = New DataColumn() {miscDS.Tables("CONTROL").Columns("AUDIT_ID"), miscDS.Tables("CONTROL").Columns("MATERIAL_ID")}
                    Dim ChildColumns As DataColumn() = New DataColumn() {miscDS.Tables("SERIAL").Columns("AUDIT_ID"), miscDS.Tables("SERIAL").Columns("MATERIAL_ID")}

                    Try
                        miscDS.Relations.Add("SERIES_X_SKU", parentColumns, ChildColumns, False)
                        pResult = "OK"
                        Return miscDS
                    Catch ex As Exception
                        'LogSQLErrors("SERIES:" + ex.Message, xsql, pLocalResult)
                        pResult = ex.Message
                        Return Nothing
                    End Try
                Else
                    pResult = "OK"
                    Return miscDS
                End If

            End If

        Catch ex As Exception
            LogSQLErrors(pResult, xsql, pLocalResult)
            pResult = "ERROR, " + ex.Message + " pDebugInfo: "
            Return Nothing
        Finally
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try
        Return Nothing
    End Function

    <WebMethod(Description:="Get images audit ")>
    Public Function GetImgAudi(ByVal pCodePoliza As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldbConexion As SqlConnection
        sqldbConexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)


        sqldbConexion.Open()

        Try
            Dim strSql As New StringBuilder
            strSql.Append(" SELECT *")
            strSql.Append(String.Format(" FROM {0}OP_WMS_IMAGENES_POLIZA ", DefaultSchema))
            strSql.Append(String.Format(" where CODIGO_POLIZA = '{0}'", pCodePoliza))

            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(strSql.ToString(), sqldbConexion)
            Dim miscDS As DataSet = New DataSet()


            miscDA.Fill(miscDS, "GetImgAudi")

            If miscDS.Tables(0).Rows.Count <= 0 Then
                pResult = "ERROR, No hay fotografias para la poliza: " & pCodePoliza
                Return Nothing
            Else
                pResult = "OK"
                Return miscDS
            End If

        Catch ex As Exception
            pResult = "ERROR, " + ex.Message + " pDebugInfo: "
            Return Nothing
        Finally
            sqldbConexion.Dispose()

        End Try
    End Function


    <WebMethod(Description:="Get my first task from a given wave and sku ")>
    Public Function GetAuditLabel(ByVal pItemName As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection
        sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim SQL As String = ""
        Dim pFrom As String = ""
        Dim pDebugInfo As String = ""
        sqldb_conexion.Open()

        Try
            SQL = " SELECT PARAM_CAPTION FROM  " + DefaultSchema + "OP_WMS_FUNC_GET_CONFIGU_INFO('SISTEMA','AUDIT_SUMMARY_COUNT','" + pItemName + "')"

            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(SQL, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()

            pDebugInfo = "1"
            miscDA.Fill(miscDS, "GetAuditLabel")
            pDebugInfo = "2"
            If miscDS.Tables(0).Rows.Count <= 0 Then
                pResult = "ERROR, No hay informacion para: " & pItemName
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

    <WebMethod(Description:="Get my first task from a given wave and sku ")>
    Public Function GetAuditSummary(ByVal pCODIGO_POLIZA As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection
        sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim SQL As String = ""
        Dim pFrom As String = ""
        Dim pDebugInfo As String = ""
        sqldb_conexion.Open()

        Try
            SQL = " SELECT * FROM  " + DefaultSchema + "OP_WMS_AUDIT_RECEPTION_SUMMARY WHERE CODIGO_POLIZA = '" + pCODIGO_POLIZA + "'"

            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(SQL, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()

            pDebugInfo = "1"
            miscDA.Fill(miscDS, "GetAuditSummary")
            pDebugInfo = "2"
            If miscDS.Tables(0).Rows.Count <= 0 Then
                pResult = "ERROR, No hay informacion de resumen de ingreso para poliza : " & pCODIGO_POLIZA
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


    <WebMethod(Description:="Get my first task from a given wave and sku ")>
    Public Function GetAuditView(ByVal pAuditID As Integer, ByVal pOPTION As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection
        sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim SQL As String = ""
        Dim pFrom As String = ""
        Dim pDebugInfo As String = ""
        sqldb_conexion.Open()

        Try
            Select Case pOPTION
                Case "MMI_AUDIT_REC_FISCAL"
                    pFrom = "" + DefaultSchema + "OP_WMS_VIEW_AUDIT_RECEPTION"
                    SQL = " SELECT * FROM " + pFrom + " WHERE AUDIT_ID = " & pAuditID
                Case "MMI_AUDIT_DISPATCH_FISCAL"
                    pFrom = "" + DefaultSchema + "OP_WMS_VIEW_AUDIT_DISPATCH"
                    SQL = " SELECT * FROM " + pFrom + " WHERE AUDIT_ID = " & pAuditID
                Case "MMI_AUDIT_DISPATCH_FISCAL_DETAIL"
                    SQL = " SELECT * FROM  " + DefaultSchema + "OP_WMS_VIEW_AUDIT_DISPATCH WHERE AUDIT_ID IN ( SELECT AUDIT_ID FROM  " + DefaultSchema + "OP_WMS3PL_AUDITS_X_PASS WHERE PASS_ID = " & pAuditID & ") ORDER BY AUDIT_ID"
                Case "MMI_AUDIT_DISPATCH_FISCAL_DETAIL_CERTIFICATE"
                    SQL = " SELECT * FROM  " + DefaultSchema + "OP_WMS_VIEW_AUDIT_DISPATCH_CERTIFICATES WHERE AUDIT_ID IN ( SELECT AUDIT_ID FROM  " + DefaultSchema + "OP_WMS3PL_AUDITS_X_PASS WHERE PASS_ID = " & pAuditID & ") ORDER BY AUDIT_ID"

            End Select


            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(SQL, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()

            pDebugInfo = "1"
            miscDA.Fill(miscDS, "GetAuditReception")
            pDebugInfo = "2"
            If miscDS.Tables(0).Rows.Count <= 0 Then
                pResult = "ERROR, No hay informacion para auditoria : " & pAuditID
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

    <WebMethod(Description:="Get my first task from a given wave and sku ")>
    Public Function GetMyFirstTask(ByVal pLoginID As String, ByVal pWaveID As Integer, ByVal pCODIGO_POLIZA_SOURCE As String, ByVal pSKU As String, ByVal LocationSpotTarget As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection
        sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim SQL As String = ""
        Dim pDebugInfo As String = ""
        Dim pRegimen As String = pResult
        sqldb_conexion.Open()

        Try
            If pRegimen = "FISCAL" Then
                SQL = " SELECT * FROM  " + DefaultSchema + "OP_WMS_FUNC_GET_MY_FIRST_PICKING('" + pLoginID + "'," & pWaveID & ",'" + pCODIGO_POLIZA_SOURCE + "','" & pSKU.ToUpper & "')"
                'LogSQLErrors("GetMyFirstTask", SQL, "")
            Else
                SQL = " SELECT * FROM  " + DefaultSchema + "OP_WMS_FUNC_GET_MY_FIRST_PICKING_ALMGEN('" + pLoginID + "'," & pWaveID & ",'" & pSKU.ToUpper & "', '" + LocationSpotTarget + "' )"
            End If


            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(SQL, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()

            pDebugInfo = "1"
            miscDA.Fill(miscDS, "GetMyFirstTask")
            pDebugInfo = "2"
            If miscDS.Tables(0).Rows.Count <= 0 Then
                'pResult = "ERROR, No hay tareas para : " + pLoginID + " POLIZA: " + pCODIGO_POLIZA_SOURCE + " SKU: " + pSKU + "OLA : " & pWaveID & " REGIMEN: " & pRegimen
                pResult = SQL
                Return Nothing
            Else
                pResult = "OK"
                Return miscDS
            End If

        Catch ex As Exception
            pResult = "ERROR, " + ex.Message + " pDebugInfo: " & pLoginID & " " & pWaveID & " " & pSKU
            Return Nothing
        Finally
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try


    End Function

    <WebMethod(Description:="determine if the scanned location is contained on a given wave and sku ")>
    Public Function IsContainedOnWave(ByVal pLoginID As String, ByVal pLocationID As String, ByVal pWaveID As Integer, ByVal pSKU As String, ByVal pLicenseID As Integer, ByVal pCODIGO_POLIZA_SOURCE As String, ByVal pSERVICE As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection
        sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim SQL As String = ""
        Dim pDebugInfo As String = ""
        sqldb_conexion.Open()

        Try
            SQL = " select top 1 task_subtype from  " + DefaultSchema + "op_wms_task_list where WAVE_PICKING_ID = " & pWaveID
            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(SQL, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()
            pDebugInfo = "1"
            miscDA.Fill(miscDS, "IsLocationContainedOnWave")
            pDebugInfo = "2"
            If miscDS.Tables(0).Rows.Count <= 0 Then
                pResult = "ERROR, Ola " & pWaveID & " no existe"

            Else
                Dim taskType = miscDS.Tables(0).Rows(0)("TASK_SUBTYPE")
                Select Case taskType
                    Case "DESPACHO_GENERAL", "DESPACHO_CONSOLIDADO", "DESPACHO_WT"
                        SQL = " SELECT * FROM  " + DefaultSchema + "OP_WMS_FUNC_GET_MY_PICKING_LIST_DETAIL_ALMAGEN_IN_PROGRESS('" + pLoginID + "')  WHERE WAVE_PICKING_ID = " & pWaveID

                    Case "TRASLADO_GENERAL"
                        SQL = " SELECT * FROM  " + DefaultSchema + "OP_WMS_FUNC_GET_MY_PICKING_LIST_DETAIL('" + pLoginID + "')  WHERE WAVE_PICKING_ID = " & pWaveID
                    Case "DESPACHO_FISCAL"
                        SQL = " SELECT * FROM  " + DefaultSchema + "OP_WMS_FUNC_GET_MY_PICKING_LIST_DETAIL('" + pLoginID + "')  WHERE WAVE_PICKING_ID = " & pWaveID
                    Case Else
                        SQL = " SELECT * FROM  " + DefaultSchema + "OP_WMS_FUNC_GET_MY_REALLOC_TASK_LIST_DETAIL('" + pLoginID + "')  WHERE WAVE_PICKING_ID = " & pWaveID
                End Select

                Select Case pSERVICE
                    Case "UBICACION"
                        SQL = SQL + " AND LOCATION_SPOT_SOURCE = '" + pLocationID + "'" ' + "' AND CODIGO_POLIZA_SOURCE = '" & pCODIGO_POLIZA_SOURCE & "'"
                        If (taskType.Equals("DESPACHO_GENERAL")) Then
                            SQL = SQL + " AND [MATERIAL_ID] = '" + pSKU + "'"
                        End If

                    Case "LICENCIA"
                        SQL = SQL + " AND LOCATION_SPOT_SOURCE = '" + pLocationID + "' AND LICENSE_ID_SOURCE = " & pLicenseID '& " AND CODIGO_POLIZA_SOURCE = '" & pCODIGO_POLIZA_SOURCE & "'"
                        If (taskType.Equals("DESPACHO_GENERAL")) Then
                            SQL = SQL + " AND [MATERIAL_ID] = '" + pSKU + "'"
                        End If
                    Case "SKU"
                        SQL = SQL + " AND LOCATION_SPOT_SOURCE = '" + pLocationID + "' AND LICENSE_ID_SOURCE = " & pLicenseID & " AND (BARCODE_ID = '" & pSKU.Replace(" ", "") & "' OR BARCODE_ID = (SELECT TOP 1 Z.BARCODE_ID FROM  " + DefaultSchema + "OP_WMS_MATERIALS Z WHERE Z.ALTERNATE_BARCODE = '" & pSKU.Replace(" ", "") & "'))"
                        'SQL = SQL + " AND LOCATION_SPOT_SOURCE = '" + pLocationID + "' AND LICENSE_ID_SOURCE = " & pLicenseID & " AND (BARCODE_ID = '" & pSKU.Replace(" ", "") & "' OR BARCODE_ID = (SELECT Z.BARCODE_ID FROM  " + DefaultSchema + "OP_WMS_MATERIALS Z WHERE Z.ALTERNATE_BARCODE = '" & pSKU.Replace(" ", "") & "')) AND CODIGO_POLIZA_SOURCE = '" & pCODIGO_POLIZA_SOURCE & "'"
                End Select
                'LogSQLErrors("IsContaidedOnWave", SQL, "")

                miscDA = New SqlDataAdapter(SQL, sqldb_conexion)
                miscDS = New DataSet()

                pDebugInfo = "1"
                miscDA.Fill(miscDS, "IsLocationContainedOnWave")
                pDebugInfo = "2"
                If miscDS.Tables(0).Rows.Count <= 0 Then
                    'LogSQLErrors("IS_CONTAINDED_ON_WAVE?", SQL, "")
                    pResult = "ERROR, " & pSERVICE & " Invalida para esta ola de picking"
                    Return Nothing
                Else
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


    <WebMethod(Description:="Get my TODAY completed review tasks")>
    Public Function GetMyTasks(ByVal pLoginID As String, ByVal pRegimen As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection
        sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim SQL As String = ""
        Dim pDebugInfo As String = ""
        sqldb_conexion.Open()
        Dim typeTask As String = "TAREA_PICKING "

        Try
            Select Case pRegimen
                Case "REUBICACION_POR_REABASTECIMIENTO"   'Reubicacion por Reabastecimiento
                    SQL = " SELECT * FROM  " + DefaultSchema + "OP_WMS_FUNC_GET_MY_REALLOC_TASK_HEADER('" + pLoginID + "') ORDER BY [PRIORITY] DESC, [ASSIGNED_DATE] DESC"
                    typeTask = "TAREA_REUBICACION"
                Case "DI"   'TRASLADOS A GENERAL
                    SQL = " SELECT * FROM  " + DefaultSchema + "OP_WMS_FUNC_GET_MY_PICKING_DI_LIST_HEADER('" + pLoginID + "') ORDER BY [ASSIGNED_DATE]"
                Case "DESPACHO_ALMGEN"
                    SQL = " SELECT * FROM  " + DefaultSchema + "OP_WMS_FUNC_GET_MY_PICKING_ALMGEN_HEADER('" + pLoginID + "') ORDER BY [PRIORITY] DESC, [ASSIGNED_DATE] DESC"
                Case Else   'FISCAL
                    SQL = " SELECT * FROM  " + DefaultSchema + "OP_WMS_FUNC_GET_MY_PICKING_LIST_HEADER('" + pLoginID + "') ORDER BY [PRIORITY] DESC, [ASSIGNED_DATE] DESC"
            End Select

            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(SQL, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()

            pDebugInfo = "1"
            miscDA.Fill(miscDS, "MY_WAVES")
            pDebugInfo = "2"
            If miscDS.Tables(0).Rows.Count <= 0 Then
                pResult = "ERROR, No hay tareas para : " + pLoginID
                Return Nothing
            Else
                pDebugInfo = "2.1"
                Dim xsql As String = ""

                xsql = " EXEC  " + DefaultSchema + "[OP_WMS_SP_GET_MY_PICKING_LIST_DETAIL] @LOGIN_ID = '" + pLoginID + "' " + ", @TASK_TYPE ='" + typeTask + "'"

                pDebugInfo = "2.2"
                'LogSQLErrors("GETMYTASKS", xsql, "")
                miscDA.SelectCommand = New SqlCommand(xsql, sqldb_conexion)
                miscDA.Fill(miscDS, "SKUS")

                If miscDS.Tables(1).Rows.Count <= 0 Then
                    pResult = "ERROR(1), No hay tareas (DET) para : " + pLoginID
                    'LogSQLErrors(pResult, xsql, "")
                    Return Nothing
                Else
                    Try

                        xsql = " EXEC " + DefaultSchema + "[OP_WMS_SP_GET_MY_PICKING_LIST_DETAIL_BY_LICENCE] @LOGIN_ID = '" + pLoginID + "' " + ", @TASK_TYPE ='" + typeTask + "'"

                        'LogSQLErrors("GETMYTASK", xsql, "")
                        miscDA.SelectCommand = New SqlCommand(xsql, sqldb_conexion)
                        miscDA.Fill(miscDS, "INV_X_SKU")

                        If miscDS.Tables(2).Rows.Count <= 0 Then
                            pResult = "ERROR(2), No hay tareas (DET) para : " + pLoginID
                            Return Nothing
                        Else
                            Try
                                Dim parentColumns As DataColumn() = Nothing
                                Dim ChildColumns As DataColumn() = Nothing
                                If pRegimen = "DESPACHO_ALMGEN" Then
                                    parentColumns = New DataColumn() _
                                        {miscDS.Tables("SKUS").Columns("WAVE_PICKING_ID"), miscDS.Tables("SKUS").Columns("BARCODE_ID")}
                                    ChildColumns = New DataColumn() _
                                        {miscDS.Tables("INV_X_SKU").Columns("WAVE_PICKING_ID"), miscDS.Tables("INV_X_SKU").Columns("BARCODE_ID")}
                                    Try
                                        'LogSQLErrors("miscDS.Tables(INV_X_SKU).Rows(2): ", CStr(miscDS.Tables("INV_X_SKU").Rows(2)("BARCODE_ID")) + " " + CStr(miscDS.Tables("INV_X_SKU").Rows(2)("QUANTITY_PENDING")), "")
                                    Catch ex As Exception

                                    End Try
                                Else
                                    parentColumns = New DataColumn() {miscDS.Tables("SKUS").Columns("WAVE_PICKING_ID"), miscDS.Tables("SKUS").Columns("CODIGO_POLIZA_SOURCE"), miscDS.Tables("SKUS").Columns("BARCODE_ID")}
                                    ChildColumns = New DataColumn() {miscDS.Tables("INV_X_SKU").Columns("WAVE_PICKING_ID"), miscDS.Tables("INV_X_SKU").Columns("CODIGO_POLIZA_SOURCE"), miscDS.Tables("INV_X_SKU").Columns("BARCODE_ID")}
                                End If

                                miscDS.Relations.Add("LOCATIONS_X_SKUS", parentColumns, ChildColumns, False)

                                Try
                                    miscDS.Relations.Add("SKUS_X_WAVE", miscDS.Tables("MY_WAVES").Columns("WAVE_PICKING_ID"), miscDS.Tables("SKUS").Columns("WAVE_PICKING_ID"), False)

                                Catch ex As Exception
                                    pResult = "ERROR:GetMyTasks(1), " + ex.Message
                                    Return Nothing
                                End Try
                            Catch ex As Exception
                                pResult = "ERROR:GetMyTasks(2), " + ex.Message
                                Return Nothing
                            End Try

                            pResult = "OK"
                            Return miscDS
                        End If


                    Catch ex As Exception
                        pResult = ex.Message
                        Return Nothing
                    End Try
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


    <WebMethod(Description:="Get GetMyLastLicense")>
    Public Function GetClient_CommercialAggrements(ByVal pCLIENT_CODE As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection
        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Catch ex As Exception
            pResult = "ERROR:" + ex.Message
            Return Nothing
        End Try

        Dim XSQL As String = ""
        XSQL = "SELECT * FROM "
        XSQL = XSQL + "  " + DefaultSchema + "[OP_WMS_VIEW_CUSTOMER_TERMS_OF_TRADE] "
        XSQL = XSQL + " WHERE CLIENT_CODE = '" + pCLIENT_CODE + "'"

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "GetComercialAggrements")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR, Cliente " & pCLIENT_CODE & " no tiene ningun acuerdo comercial vigente"
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function

    <WebMethod(Description:="Get GetMyLastLicense")>
    Public Function GetServerDateTime() As String
        Try
            Return Now.ToString
        Catch ex As Exception
            Return "ERROR," + ex.Message
        End Try
    End Function

    <WebMethod(Description:="Get GetMyLastLicense")>
    Public Function GetMyLastLicense(ByVal pCODIGO_POLIZA As String, ByVal pLOGIN_ID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection
        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Catch ex As Exception
            pResult = "ERROR:" + ex.Message
            Return Nothing
        End Try

        Dim XSQL As String = ""
        XSQL = "SELECT TOP 1 *, "
        XSQL = XSQL + " (SELECT COUNT(MATERIAL_ID) AS TOTAL_COUNT FROM " + DefaultSchema + "[OP_WMS_INV_X_LICENSE] WHERE [LICENSE_ID] = A.[LICENSE_ID]) AS TOTAL_SKUS "
        XSQL = XSQL + " FROM  " + DefaultSchema + "OP_WMS_LICENSES A "
        XSQL = XSQL + " WHERE A.CODIGO_POLIZA = '" + pCODIGO_POLIZA + "'"
        XSQL = XSQL + " AND A.LAST_UPDATED_BY = '" + pLOGIN_ID + "' AND A.CURRENT_LOCATION = (SELECT DEFAULT_RECEPTION_LOCATION FROM  " + DefaultSchema + "OP_WMS_WAREHOUSES WHERE WAREHOUSE_ID IN "
        XSQL = XSQL + " 		(SELECT DEFAULT_WAREHOUSE_ID FROM  " + DefaultSchema + "OP_WMS_LOGINS WHERE LOGIN_ID = '" + pLOGIN_ID + "'))"
        XSQL = XSQL + " ORDER BY A.LICENSE_ID"

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "GetMyLastLicense")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "Sin Licencia Registrada"
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function
    <WebMethod(Description:="Get Inventory by License")>
    Public Function GET_LICENSE_DETAIL(ByVal pLICENSE_ID As Integer, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection
        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Catch ex As Exception

            pResult = "ERROR:" + ex.Message
            Return Nothing
        End Try

        Dim cmd As New SqlCommand

        cmd.Parameters.Add("@LICENSE_ID", SqlDbType.VarChar)
        cmd.Parameters("@LICENSE_ID").Direction = ParameterDirection.Input
        cmd.Parameters("@LICENSE_ID").Value = pLICENSE_ID


        cmd.CommandText = DefaultSchema & "OP_WMS_SP_GET_LICENSE_DETAIL"
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Connection = sqldb_conexion


        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(cmd)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "GET_LICENSE_DETAIL")
            sqldb_conexion.Close()
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR, Licencia " & pLICENSE_ID & " & no tiene inventario"
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function

    <WebMethod(Description:="Get Inventory by Warehouse")>
    Public Function Get_OP_WMS_POLIZA_HEADER(ByVal pCodigoPoliza As String, ByVal pNumeroOrden As String, ByVal pRegimen As String, ByVal pTipo As String,
                                             ByVal pOperador As String, validarOperador As Boolean, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection
        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Catch ex As Exception
            pResult = "ERROR:" + ex.Message
            Return Nothing
        End Try
        Dim XSQL As String = ""
        XSQL = " SELECT a.*, (select TOP 1 b.client_name  from  " + DefaultSchema + "OP_WMS_VIEW_CLIENTS b where b.CLIENT_CODE = a.CLIENT_CODE COLLATE DATABASE_DEFAULT) + CHAR(13) + CHAR(10) + CASE WHEN [RDH].[NAME_SUPPLIER] IS NULL THEN '' ELSE 'Proveedor: ' + [RDH].[NAME_SUPPLIER] END as CLIENT_NAME, "
        XSQL = XSQL + " ISNULL((SELECT TOP 1 ISNULL(CONTENEDOR,'N/A') FROM  " + DefaultSchema + "OP_WMS_AUDIT_RECEPTION_CONTROL WHERE (CODIGO_POLIZA = '" + pCodigoPoliza + "' OR NUMERO_ORDEN = '" + pCodigoPoliza + "') AND STATUS = 'CREATED'),'N/A') AS CONTENEDOR_EN_CONTEO "
        XSQL = XSQL + " FROM  " + DefaultSchema + "OP_WMS_POLIZA_HEADER a "
        XSQL = XSQL + " LEFT JOIN " + DefaultSchema + "[OP_WMS_TASK_LIST] [TL] ON ( [a].[DOC_ID] = [TL].[DOC_ID_SOURCE]) "
        XSQL = XSQL + " LEFT JOIN " + DefaultSchema + "[OP_WMS_ERP_RECEPTION_DOCUMENT_HEADER] [RDH] ON( [RDH].[TASK_ID] = [TL].[SERIAL_NUMBER]) "
        XSQL = XSQL + " WHERE "
        XSQL = XSQL + " (a.CODIGO_POLIZA = '" + pCodigoPoliza + "'" + If((Not pNumeroOrden Is Nothing) AndAlso pNumeroOrden.Length > 0, "AND NUMERO_ORDEN = '" + pNumeroOrden + "'", "") + ")"
        XSQL = XSQL + " and a.TIPO = '" + pTipo + "'"
        If Not pRegimen = "" Then
            XSQL = XSQL + " and a.WAREHOUSE_REGIMEN = '" + pRegimen + "' "
            If validarOperador Then
                XSQL = XSQL + " AND a.POLIZA_ASSIGNEDTO = '" + pOperador + "' "
            End If
        End If

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "Get_OP_WMS_POLIZA_HEADER")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR, Poliza no existe o no esta asignado al operador"
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function

    <WebMethod(Description:="Get Inventory by Warehouse")>
    Public Function Get_OP_WMS_IMAGENES_POLIZA(ByVal pCODIGO_BARRAS_ID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection
        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Catch ex As Exception
            pResult = "ERROR:" + ex.Message
            Return Nothing
        End Try

        Dim XSQL As String = ""
        XSQL = XSQL + " select * from  " + DefaultSchema + "OP_WMS_IMAGENES_POLIZA "
        XSQL = XSQL + " WHERE "
        XSQL = XSQL + " CODIGO_POLIZA = '" + pCODIGO_BARRAS_ID + "'"

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "Get_OP_WMS_IMAGENES_POLIZA")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR, Poliza no existe"
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function

    <WebMethod(Description:="Get Inventory by Warehouse")>
    Public Function GetTransBasicView(ByVal UserLogged As String, ByVal plstUsers As String, ByVal plstTransTypes As String, ByVal pSinceDate As Date, ByVal pToDate As Date, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim pFormatedDate_Since As String
        Dim pFormatedDate_To As String
        Dim cmd As New SqlCommand

        pFormatedDate_Since = Format(pSinceDate, "yyyy-MM-dd")
        pFormatedDate_To = Format(pToDate, "yyyy-MM-dd 23:59")

        cmd.Parameters.Add(New SqlParameter("@START_DATE", SqlDbType.DateTime))
        cmd.Parameters("@START_DATE").Value = pFormatedDate_Since
        cmd.Parameters.Add(New SqlParameter("@END_DATE", SqlDbType.DateTime))
        cmd.Parameters("@END_DATE").Value = pFormatedDate_To
        cmd.Parameters.Add(New SqlParameter("@LOGIN", SqlDbType.VarChar))
        cmd.Parameters("@LOGIN").Value = plstUsers
        cmd.Parameters.Add(New SqlParameter("@TRANS_TYPE", SqlDbType.VarChar))
        cmd.Parameters("@TRANS_TYPE").Value = plstTransTypes
        cmd.Parameters.Add(New SqlParameter("@USER_LOGGED", SqlDbType.VarChar)).Value = UserLogged

        cmd.CommandText = DefaultSchema + "[OP_WMS_SP_GET_TRANS_BASIC_VIEW]"
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Connection = sqldb_conexion

        Dim miscDa = New SqlDataAdapter(cmd)
        sqldb_conexion.Close()
        pResult = "OK"

        If pResult = "OK" Then

            Dim miscDS = New DataSet()
            Try
                miscDa.Fill(miscDS, "GetTransBasicView")
            Catch ex As Exception
                pResult = "ERROR (1)," + ex.Message
                'LogSQLErrors("INFOTRANS ERROR", XSQL, pResult)

                Return Nothing
            End Try
            If miscDS.Tables(0).Rows.Count <= 0 Then
                pResult = "ERROR, No se encontraron transacciones para ese rango de filtro"
                Return Nothing
            Else
                pResult = "OK"
                Return miscDS
            End If
        Else
            Return Nothing
        End If
        Return Nothing
    End Function
    <WebMethod(Description:="Get Inventory by client code in a date range")>
    Public Function GetTransBasicView_ByClient(ByVal pClientID As String, ByVal pSinceDate As Date, ByVal pToDate As Date, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim pFormatedDate_Since As String
        Dim pFormatedDate_To As String

        pFormatedDate_Since = Format(pSinceDate, "yyyy-MM-dd")
        pFormatedDate_To = Format(pToDate, "yyyy-MM-dd 23:59")

        Dim XSQL As String = ""
        XSQL = "SELECT * FROM  " + DefaultSchema + "OP_WMS_VIEW_TRANS_BASIC A WHERE "
        XSQL = XSQL + " A.TRANS_DATE >= '" + pFormatedDate_Since + "' AND A.TRANS_DATE <= '" + pFormatedDate_To + "' AND "
        XSQL = XSQL + " A.CLIENT_OWNER = '" + pClientID + "' ORDER BY TRANS_DATE DESC"

        pResult = "OK"
        'Return Nothing

        'LogSQLErrors("INFOTRANS", XSQL, pResult)

        If pResult = "OK" Then

            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()
            Try
                miscDA.Fill(miscDS, "GetTransBasicView_ByClient")
            Catch ex As Exception
                pResult = "ERROR,GetTransBasicView_ByClient:" + ex.Message
                'LogSQLErrors("INFOTRANS ERROR", XSQL, pResult)

                Return Nothing
            End Try
            If miscDS.Tables(0).Rows.Count <= 0 Then
                pResult = "ERROR, No se encontraron transacciones para ese rango de filtro"
                LogSQLErrors("GetTransBasicView_ByClient_NO_ROWS_FOUND", XSQL, "")
                Return Nothing
            Else
                pResult = "OK"
                Return miscDS
            End If
        Else
            Return Nothing
        End If
        Return Nothing
    End Function

    <WebMethod(Description:="Get Tasks")>
    Public Function GetTasksBasicView(ByVal plstUsers As String, ByVal plstTasksTypes As String, ByVal pSinceDate As Date, ByVal pToDate As Date, login As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldbConexion As SqlConnection
        Dim ds As New DataSet
        Dim cmd As New SqlCommand
        sqldbConexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim pFormatedDate_Since As String
        Dim pFormatedDate_To As String

        pFormatedDate_Since = Format(pSinceDate, "yyyy-MM-dd") + " 01:00AM"
        pFormatedDate_To = Format(pToDate, "yyyy-MM-dd") + " 23:59PM"



        cmd.Parameters.Add(New SqlParameter("@START_DATETIME", SqlDbType.DateTime))
        cmd.Parameters("@START_DATETIME").Value = pFormatedDate_Since
        cmd.Parameters.Add(New SqlParameter("@END_DATETIME", SqlDbType.DateTime))
        cmd.Parameters("@END_DATETIME").Value = pFormatedDate_To
        cmd.Parameters.Add(New SqlParameter("@USERS", SqlDbType.VarChar))
        cmd.Parameters("@USERS").Value = plstUsers
        cmd.Parameters.Add(New SqlParameter("@TYPES", SqlDbType.VarChar))
        cmd.Parameters("@TYPES").Value = plstTasksTypes
        cmd.Parameters.Add(New SqlParameter("@LOGIN", SqlDbType.VarChar))
        cmd.Parameters("@LOGIN").Value = login

        cmd.CommandText = DefaultSchema + "[OP_WMS_GET_TASK_BASIC_VIEW]"
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Connection = sqldbConexion

        Dim miscDa = New SqlDataAdapter(cmd)
        sqldbConexion.Close()

        Try
            miscDa.Fill(ds, "GetTasksBasicView")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try

        If ds.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR, No se encontraron tareas para ese rango de filtro"
            Return Nothing
        Else
            pResult = "OK"
            Return ds
        End If

    End Function



    <WebMethod(Description:="Get Tasks")>
    Public Function GetRepPolizaEgreso(ByVal pCodigoPoliza As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet

        Dim connection As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Try
            Dim dt As New DataSet

            Dim command As New SqlCommand

            command.Parameters.Add("@POLICY_CODE", SqlDbType.VarChar).Value = pCodigoPoliza
            command.CommandText = $"{DefaultSchema}[OP_WMS_SP_GET_DISPATCH_GENERAL_FOR_REPORT]"
            command.CommandType = CommandType.StoredProcedure
            command.Connection = connection

            Dim adapter = New SqlDataAdapter(command)
            adapter.Fill(dt, "ObtenerLayoutDeLaVistaDeQueryList")

            If dt.Tables(0).Rows.Count <= 0 Then
                pResult = "ERROR, No se encontraron registros"
                Return Nothing
            Else
                pResult = "OK"
                Return dt
            End If
            
        Catch ex As Exception
            pResult = ex.Message
            Return Nothing
        Finally
            connection.Close()
            connection.Dispose()
        End Try



    End Function


    <WebMethod(Description:="Get Tasks")>
    Public Function GetRepPolizaFiscal(ByVal pCodigoPoliza As String, ByVal pRegimen As String, ByVal pTipo As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        Dim xql As String = ""

        xql = " SELECT [PH].[DOC_ID] "
        xql = xql + " ,[PH].[NUMERO_ORDEN] "
        xql = xql + " ,[PH].[REGIMEN] "
        xql = xql + " ,[PD].[MISC_TAXES] IMPUESTOS_VARIOS "
        xql = xql + " ,[PD].[CUSTOMS_AMOUNT] CIF "
        xql = xql + " ,[PD].[CODIGO_POLIZA_ORIGEN] "
        xql = xql + " ,[PD].[QTY] "
        xql = xql + " ,[C].[CLIENT_NAME] "
        xql = xql + " ,[PD].[SKU_DESCRIPTION] "

        If pTipo = "EGRESO" Then
            xql = xql + " ,[PHI].[DOC_ID] DOC_ID_INGRESO "
            xql = xql + " ,[PHI].[NUMERO_ORDEN] NUMERO_ORDEN_INGRESO "
        End If

        xql = xql + " ,([PD].[MISC_TAXES] + [PD].[CUSTOMS_AMOUNT]) TOTAL "
        xql = xql + " FROM " + DefaultSchema + "[OP_WMS_POLIZA_HEADER] [PH] "
        xql = xql + " INNER JOIN " + DefaultSchema + "[OP_WMS_POLIZA_DETAIL] [PD] "
        xql = xql + " ON [PH].[DOC_ID] = [PD].[DOC_ID] "

        If pTipo = "EGRESO" Then
            xql = xql + " INNER JOIN " + DefaultSchema + "[OP_WMS_POLIZA_HEADER] [PHI] "
            xql = xql + " ON [PD].[CODIGO_POLIZA_ORIGEN] = [PHI].[CODIGO_POLIZA] "
        End If

        xql = xql + " LEFT JOIN " + DefaultSchema + "[OP_WMS_VIEW_CLIENTS] [C] "
        xql = xql + " ON [PH].[CLIENT_CODE] = [C].[CLIENT_CODE] "
        xql = xql + " WHERE ([PH].[CODIGO_POLIZA] = '" + pCodigoPoliza + "'"

        If IsNumeric(pCodigoPoliza) Then
            xql = xql + " OR [PH].[DOC_ID] = " + pCodigoPoliza + ""
        End If

        xql = xql + " OR [PH].[NUMERO_ORDEN] = '" + pCodigoPoliza + "')"

        xql = xql + " AND [PH].[WAREHOUSE_REGIMEN] = '" + pRegimen + "'"
        xql = xql + " AND [PH].[TIPO] = '" + pTipo + "'"



        Dim miscDa As SqlDataAdapter = New SqlDataAdapter(xql, sqldbConexion)
        Dim miscDs As DataSet = New DataSet()
        Try
            miscDa.Fill(miscDs, "repPolEgreso")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDs.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR, No se encontraron registros"
            Return Nothing
        Else
            pResult = "OK"
            Return miscDs
        End If

    End Function



    <WebMethod(Description:="Get Tasks by specific dates")>
    Public Function GetTasksBasicView_Calendar(ByVal plstUsers As String, ByVal plstTasksTypes As String, ByVal pDates As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        Dim XSQL As String = ""
        '22-Jun-11 J.R.
        'XSQL = "SELECT *, (((QUANTITY_ASSIGNED-QUANTITY_PENDING)/QUANTITY_ASSIGNED)*100) AS NIVEL_AVANCE FROM OP_WMS_TASK_LIST"
        XSQL = "SELECT *, (((QUANTITY_ASSIGNED-QUANTITY_PENDING)/QUANTITY_ASSIGNED)*100) AS NIVEL_AVANCE, (SELECT MAX(CLIENT_REGION) FROM  " + DefaultSchema + "OP_WMS_DEMAND_TO_PICK WHERE ERP_DOCUMENT = ERP_LEGACY_ID) SECTOR FROM  " + DefaultSchema + "OP_WMS_TASK_LIST"
        XSQL = XSQL + " WHERE "
        XSQL = XSQL + " CONVERT(CHAR(25),ASSIGNED_DATE,23) IN (" + pDates + ") AND "
        If plstUsers <> "NONE" Then
            XSQL = XSQL + " TASK_ASSIGNEDTO IN (" + plstUsers.ToUpper.Trim + ") AND "
        End If
        If plstTasksTypes <> "NONE" Then
            XSQL = XSQL + " TASK_TYPE IN (" + plstTasksTypes.ToUpper.Trim + ") AND "
        End If
        '22-Jun-11 J.R.
        'XSQL = XSQL + " IS_CANCELED=0 ORDER BY ASSIGNED_DATE, TASK_TYPE, TASK_ASSIGNEDTO"
        XSQL = XSQL + " IS_CANCELED=0 ORDER BY SERIAL_NUMBER"

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "GetTasksBasicView_Calendar")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR, No se encontraron tareas para ese rango de filtro"
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function

    <WebMethod(Description:="Get Pending Demand from SAP")>
    Public Function GetDemandBasicView(ByVal plstUsers As String, ByVal plstTasksTypes As String, ByVal pDateFilterType As String, ByVal pSinceDate As Date, ByVal pToDate As Date, ByVal pDates As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim pFormatedDate_Since As String
        Dim pFormatedDate_To As String

        pFormatedDate_Since = Format(pSinceDate, "yyyy-MM-dd")
        pFormatedDate_To = Format(pToDate, "yyyy-MM-dd")

        Dim XSQL As String = ""
        XSQL = "SELECT * FROM OP_WMS_VIEW_GROUPBY_PENDING_DEMAND"
        XSQL = XSQL + " WHERE ALLOWED_TO_PICK IS NULL AND "

        If pDateFilterType = "BY_CALENDAR" Then
            XSQL = XSQL + " CONVERT(CHAR(10),ERP_DOC_DATE,23) IN (" + pDates + ") "
        Else
            XSQL = XSQL + " CONVERT(CHAR(25),ERP_DOC_DATE,21) BETWEEN CONVERT(CHAR(25),'" + pFormatedDate_Since + " 00:00:00',21) AND "
            XSQL = XSQL + " CONVERT(CHAR(25),'" + pFormatedDate_To + " 24:00:00',21) "
        End If

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "MasterDemand")

            XSQL = "SELECT A.ERP_DOCUMENT as Documento, "
            XSQL = XSQL + "  A.MATERIAL_ID as Codigo, "
            XSQL = XSQL + "  A.MATERIAL_NAME as Description,  "
            XSQL = XSQL + "  A.QTY as Cantidad, "
            XSQL = XSQL + "  ISNULL(B.DISP_LINEA_1,0) AS InvLinea_1, ISNULL(B.DISP_LINEA_2,0) AS InvLinea_2,  ISNULL(B.DISP_LINEA_3,0) AS InvLinea_3  "

            XSQL = XSQL + "  FROM OP_WMS_VIEW_PENDING_DEMAND A LEFT OUTER JOIN "
            XSQL = XSQL + "  OP_WMS_VIEW_SALABLE_BY_LINE B "
            XSQL = XSQL + "  ON B.MATERIAL_ID = A.MATERIAL_ID "
            XSQL = XSQL + "  AND B.WAREHOUSE_ID IN(SELECT WAREHOUSE_ID FROM OP_WMS_WAREHOUSES WHERE ALLOW_PICKING = 1) "
            '14-Abr-11 J.R. cambia la forma de traer lo pendiente debido al proceso de balanceo pedidos por linea
            'XSQL = XSQL + "  WHERE A.ASSIGNED_TO_LINE IS NULL AND "
            XSQL = XSQL + "  WHERE A.ALLOWED_TO_PICK IS NULL AND "

            '29Jun10 J.R. se agrego poque ya no se usan dos funciones sino solo esta (getDemandBasicView) para traer la data por DateRange o bien por Calendar
            If pDateFilterType = "BY_CALENDAR" Then
                XSQL = XSQL + " CONVERT(CHAR(10),ERP_DOC_DATE,23) IN (" + pDates + ") "
            Else
                'XSQL = XSQL + " CONVERT(CHAR(25),ERP_DOC_DATE,21) BETWEEN CONVERT(CHAR(25),'" + pFormatedDate_Since + "',21) AND "
                'XSQL = XSQL + " CONVERT(CHAR(25),'" + pFormatedDate_To + "',21)"
                XSQL = XSQL + " CONVERT(CHAR(25),ERP_DOC_DATE,21) BETWEEN CONVERT(CHAR(25),'" + pFormatedDate_Since + " 00:00:00',21) AND "
                XSQL = XSQL + " CONVERT(CHAR(25),'" + pFormatedDate_To + " 24:00:00',21)"
            End If

            miscDA = New SqlDataAdapter(XSQL, sqldb_conexion)
            miscDA.Fill(miscDS, "DetailDemand")

            Dim keyColumn As DataColumn = miscDS.Tables("MasterDemand").Columns("ERP_DOCUMENT")
            Dim foreignKeyColumn As DataColumn = miscDS.Tables("DetailDemand").Columns("Documento")

            miscDS.Relations.Add("D", keyColumn, foreignKeyColumn)

            'FileOpen(1, "c:\OnePlanWMS\OP_WMS_LOG.txt", OpenMode.Append, OpenAccess.ReadWrite, OpenShare.Default)
            'WriteLine(1, Now.ToString + " - " + XSQL)
            'FileClose(1)

        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR, No se encontraron pedidos pendientes para ese rango de filtro." & XSQL
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function

    <WebMethod(Description:="Get Tasks by specific dates")>
    Public Function GetDemandBasicView_Calendar(ByVal plstUsers As String, ByVal plstTasksTypes As String, ByVal pDates As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)


        Dim XSQL As String = ""
        XSQL = "SELECT * FROM OP_WMS_VIEW_PENDING_DEMAND"
        XSQL = XSQL + " WHERE "
        '29Jun10 J.R. el campo no se llamaba ASSIGNED_DATE sino ERP_DOC_DATE
        'XSQL = XSQL + " CONVERT(CHAR(25),ASSIGNED_DATE,23) IN (" + pDates + ") "
        XSQL = XSQL + " CONVERT(CHAR(25),ERP_DOC_DATE,23) IN (" + pDates + ") "

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "GetTasksBasicView_Calendar")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR, No se encontraron pedidos pendientes para ese rango de filtro"
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function

    <WebMethod(Description:="Get Assigned Demand from SAP to WMS")>
    Public Function GetDemandAssignedView(ByVal pSinceDate As Date, ByVal pToDate As Date, ByVal pDateFilterType As String, ByVal pDates As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        '29Jun10 J.R. se agregaron los parametos, pDateFilterType, pDates para unificar filtros por Calendar y por DateRange    
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim pFormatedDate_Since As String
        Dim pFormatedDate_To As String


        pFormatedDate_Since = Format(pSinceDate, "yyyy-MM-dd")
        pFormatedDate_To = Format(pToDate, "yyyy-MM-dd")


        Dim XSQL As String = ""
        '19-Ago-10 J.R. traia un registro por cada producto pero no esta mostrando el producto, entonces se miraban muchas lineas repeditas
        'XSQL = "SELECT * FROM OP_WMS_VIEW_ASSIGNED_DEMAND"
        XSQL = "SELECT * FROM OP_WMS_VIEW_GROUPBY_ASSIGNED_DEMAND"
        XSQL = XSQL + " WHERE "

        '29Jun10 J.R. se agrego poque ya no se usan dos funciones sino solo esta (getDemandBasicView) para traer la data por DateRange o bien por Calendar
        If pDateFilterType = "BY_CALENDAR" Then
            '28-Feb-11 J.R. Para que filtre por fecha de asignacion y no por fecha de documento
            'XSQL = XSQL + " CONVERT(CHAR(10),ERP_DOC_DATE,23) IN (" + pDates + ") "
            XSQL = XSQL + " CONVERT(CHAR(10),ASSIGNED_DATE,23) IN (" + pDates + ") "
        Else
            '28-Feb-11 J.R. Para que filtre por fecha de asignacion y no por fecha de documento
            'XSQL = XSQL + " CONVERT(CHAR(25),ERP_DOC_DATE,21) BETWEEN CONVERT(CHAR(25),'" + pFormatedDate_Since + " 00:00:00',21) AND "
            XSQL = XSQL + " CONVERT(CHAR(25),ASSIGNED_DATE,21) BETWEEN CONVERT(CHAR(25),'" + pFormatedDate_Since + " 00:00:00',21) AND "
            XSQL = XSQL + " CONVERT(CHAR(25),'" + pFormatedDate_To + " 24:00:00',21) "
            'XSQL = XSQL + " CONVERT(CHAR(25),ERP_DOC_DATE,21) BETWEEN CONVERT(CHAR(25),'" + pFormatedDate_Since + "',21) AND "
            'XSQL = XSQL + " CONVERT(CHAR(25),'" + pFormatedDate_To + "',21) "
        End If

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "GetDemandBasicView")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR, No se encontraron pedidos pendientes para ese rango de filtro"
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function

    <WebMethod(Description:="Get Tasks by specific dates")>
    Public Function GetDemandAssignedView_Calendar(ByVal pDates As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)


        Dim XSQL As String = ""
        XSQL = "SELECT * FROM OP_WMS_VIEW_ASSIGNED_DEMAND"
        XSQL = XSQL + " WHERE "
        '29Jun10 J.R. el campo no se llamaba ASSIGNED_DATE sino ERP_DOC_DATE
        'XSQL = XSQL + " CONVERT(CHAR(25),ASSIGNED_DATE,23) IN (" + pDates + ") "
        XSQL = XSQL + " CONVERT(CHAR(25),ERP_DOC_DATE,23) IN (" + pDates + ") "

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "GetTasksBasicView_Calendar")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR, No se encontraron pedidos pendientes para ese rango de filtro"
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function

    '24-Feb-11 J.R. para anular pedidos (asignados y por asignar)
    <WebMethod(Description:="Get Demand Voided in WMS")>
    Public Function GetDemandVoidedView(ByVal pSinceDate As Date, ByVal pToDate As Date, ByVal pDateFilterType As String, ByVal pDates As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim pFormatedDate_Since As String
        Dim pFormatedDate_To As String

        pFormatedDate_Since = Format(pSinceDate, "yyyy-MM-dd")
        pFormatedDate_To = Format(pToDate, "yyyy-MM-dd")

        Dim XSQL As String = ""
        XSQL = "SELECT * FROM OP_WMS_VIEW_GROUPBY_VOIDED_DEMAND"
        XSQL = XSQL + " WHERE "

        '29Jun10 J.R. se agrego poque ya no se usan dos funciones sino solo esta (getDemandBasicView) para traer la data por DateRange o bien por Calendar
        If pDateFilterType = "BY_CALENDAR" Then
            XSQL = XSQL + " CONVERT(CHAR(10),VOIDED_DATE,23) IN (" + pDates + ") "
        Else
            XSQL = XSQL + " CONVERT(CHAR(25),VOIDED_DATE,21) BETWEEN CONVERT(CHAR(25),'" + pFormatedDate_Since + " 00:00:00',21) AND "
            XSQL = XSQL + " CONVERT(CHAR(25),'" + pFormatedDate_To + " 24:00:00',21) "
            'XSQL = XSQL + " CONVERT(CHAR(25),ERP_DOC_DATE,21) BETWEEN CONVERT(CHAR(25),'" + pFormatedDate_Since + "',21) AND "
            'XSQL = XSQL + " CONVERT(CHAR(25),'" + pFormatedDate_To + "',21) "
        End If

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "GetDemandVoidedView")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR, No se encontraron pedidos anulados en esas fechas"
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function

    '25-Abr-11 J.R. mostrar pedidos pendientes de picking
    <WebMethod(Description:="Get Pending Picking Demand in WMS")>
    Public Function GetDemandPendingPickingView(ByVal pSinceDate As Date, ByVal pToDate As Date, ByVal pDateFilterType As String, ByVal pDates As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim pFormatedDate_Since As String
        Dim pFormatedDate_To As String

        pFormatedDate_Since = Format(pSinceDate, "yyyy-MM-dd")
        pFormatedDate_To = Format(pToDate, "yyyy-MM-dd")

        Dim XSQL As String = ""
        XSQL = "SELECT * FROM OP_WMS_VIEW_GROUPBY_PENDING_PICKING ORDER BY CLIENT_REGION, ASSIGNED_TO_LINE"
        'XSQL = XSQL + " WHERE "

        ''29Jun10 J.R. se agrego poque ya no se usan dos funciones sino solo esta (getDemandBasicView) para traer la data por DateRange o bien por Calendar
        'If pDateFilterType = "BY_CALENDAR" Then
        '    XSQL = XSQL + " CONVERT(CHAR(10),VOIDED_DATE,23) IN (" + pDates + ") "
        'Else
        '    XSQL = XSQL + " CONVERT(CHAR(25),VOIDED_DATE,21) BETWEEN CONVERT(CHAR(25),'" + pFormatedDate_Since + " 00:00:00',21) AND "
        '    XSQL = XSQL + " CONVERT(CHAR(25),'" + pFormatedDate_To + " 24:00:00',21) "
        '    'XSQL = XSQL + " CONVERT(CHAR(25),ERP_DOC_DATE,21) BETWEEN CONVERT(CHAR(25),'" + pFormatedDate_Since + "',21) AND "
        '    'XSQL = XSQL + " CONVERT(CHAR(25),'" + pFormatedDate_To + "',21) "
        'End If

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "MasterDemandPendingPicking")

            XSQL = "SELECT SECTORLINEA, CLIENT_REGION Sector, ASSIGNED_TO_LINE Linea, ERP_DOCUMENT Documento, CLIENT_ID CodigoCliente, CLIENT_NAME NombreCliente, QTY Unidades FROM OP_WMS_VIEW_PENDING_PICKING ORDER BY CLIENT_REGION, ASSIGNED_TO_LINE, ERP_DOCUMENT"

            miscDA = New SqlDataAdapter(XSQL, sqldb_conexion)
            miscDA.Fill(miscDS, "DetailDemandPendingPicking")

            'Dim keyColumns(2) As DataColumn
            'keyColumns(0) = miscDS.Tables("MasterDemandPendingPicking").Columns("CLIENT_REGION")
            'keyColumns(1) = miscDS.Tables("MasterDemandPendingPicking").Columns("ASSIGNED_TO_LINE")
            'Dim foreignKeyColumns(2) As DataColumn
            'foreignKeyColumns(0) = miscDS.Tables("DetailDemandPendingPicking").Columns("CLIENT_REGION")
            'foreignKeyColumns(1) = miscDS.Tables("DetailDemandPendingPicking").Columns("ASSIGNED_TO_LINE")

            'Dim relColumnas As DataRelation = New DataRelation("D", keyColumns, foreignKeyColumns)

            'miscDS.Relations.Add(relColumnas)
            ''miscDS.Relations.Add("D", keyColumns, foreignKeyColumns)

            Dim keyColumn As DataColumn = miscDS.Tables("MasterDemandPendingPicking").Columns("SECTORLINEA")
            'Dim keyColumn2 As DataColumn = miscDS.Tables("MasterDemandPendingPicking").Columns("ASSIGNED_TO_LINE")
            Dim foreignKeyColumn As DataColumn = miscDS.Tables("DetailDemandPendingPicking").Columns("SECTORLINEA")
            'Dim foreignKeyColumn2 As DataColumn = miscDS.Tables("DetailDemandPendingPicking").Columns("ASSIGNED_TO_LINE")

            miscDS.Relations.Add("D", keyColumn, foreignKeyColumn, False)
            'miscDS.Relations.Add("D2", keyColumn2, foreignKeyColumn2, False)

        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR, No se encontraron pedidos pendientes de pickear"
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function

    <WebMethod(Description:="Get pending Tasks to specific user")>
    Public Function GetPendingTasks(ByVal pTaskType As String, ByVal pLoginID As String, ByVal pBIN As Integer, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)


        Dim XSQL As String = ""
        XSQL = "SELECT * FROM OP_WMS_TASK_LIST "
        XSQL = XSQL + " WHERE TASK_TYPE = '" + pTaskType + "' AND "
        XSQL = XSQL + " TASK_ASSIGNEDTO = '" + pLoginID.ToUpper + "' AND "
        If pBIN <> 0 Then
            XSQL = XSQL + " BIN_TARGET = " & pBIN & " AND "
        End If
        '21-Feb-11 J.R. traia tareas de pedidos que habian quedado pendientes (incompletos)
        If pTaskType = "TAREA_PICKING" Then
            XSQL = XSQL + " ERP_LEGACY_ID = (select isnull(CURRENT_ERP_DOCUMENT,'') CURRENT_ERP_DOCUMENT from OP_WMS_BINS where BIN_ID = " & pBIN & ") AND "
        End If
        XSQL = XSQL + " IS_CANCELED = 0 AND "
        XSQL = XSQL + " IS_COMPLETED = 0 AND "
        XSQL = XSQL + " IS_PAUSED = 0 "
        '29-Jun-11 J.R. cambios codigo de ubicaciones
        'XSQL = XSQL + " ORDER BY ERP_LEGACY_ID, Substring(Location_Spot_Source,1,3) ASC, Substring(Location_Spot_Source,4,3) ASC, Substring(Location_Spot_Source,10,5) ASC, Substring(Location_Spot_Source,7,3) ASC "
        XSQL = XSQL + " ORDER BY ERP_LEGACY_ID, Substring(Location_Spot_Source,1,2) ASC, Substring(Location_Spot_Source,3,3) ASC, Substring(Location_Spot_Source,8,3) ASC, Substring(Location_Spot_Source,6,2) ASC "

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "GetPendingTasks")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "NO_MORE_TASKS"
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function
    <WebMethod(Description:="Get pending Tasks to specific user")>
    Public Function GetPendingTasksByDoc(ByVal pERP_DOCUMENT As String, ByVal pLoginID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)


        Dim XSQL As String = ""
        XSQL = "SELECT * FROM OP_WMS_TASK_LIST "
        XSQL = XSQL + " WHERE ERP_LEGACY_ID = '" + pERP_DOCUMENT + "' AND "
        XSQL = XSQL + " TASK_ASSIGNEDTO = '" + pLoginID.ToUpper + "' AND "
        XSQL = XSQL + " IS_CANCELED  = 0 AND "
        XSQL = XSQL + " IS_COMPLETED = 0 AND "
        XSQL = XSQL + " IS_PAUSED    = 0 "
        '29-Jun-11 J.R. cambios codigo de ubicaciones
        'XSQL = XSQL + " ORDER BY ERP_LEGACY_ID, Substring(Location_Spot_Source,1,3) ASC, Substring(Location_Spot_Source,4,3) ASC, Substring(Location_Spot_Source,10,5) ASC, Substring(Location_Spot_Source,7,3) ASC "
        XSQL = XSQL + " ORDER BY ERP_LEGACY_ID, Substring(Location_Spot_Source,1,2) ASC, Substring(Location_Spot_Source,3,3) ASC, Substring(Location_Spot_Source,8,3) ASC, Substring(Location_Spot_Source,6,2) ASC "

        'FileOpen(1, "c:\OnePlanWMS\OP_WMS_LOG_TEST.txt", OpenMode.Append, OpenAccess.ReadWrite, OpenShare.Default)
        'WriteLine(1, "GetPendingTasksByDoc - " + XSQL)
        'FileClose(1)

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "GetPendingTasks")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "NO_MORE_TASKS"
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function
    <WebMethod(Description:="Get pending Tasks to specific user")>
    Public Function GetPendingTasksByDocAndSKU(ByVal pERP_DOCUMENT As String, ByVal pSKU As String, ByVal pLoginID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)


        Dim XSQL As String = ""
        XSQL = "SELECT * FROM OP_WMS_TASK_LIST "
        XSQL = XSQL + " WHERE ERP_LEGACY_ID = '" + pERP_DOCUMENT + "' AND "
        XSQL = XSQL + " MATERIAL_CODE = '" + pSKU.ToUpper + "' AND "
        XSQL = XSQL + " TASK_ASSIGNEDTO = '" + pLoginID.ToUpper + "' AND "
        XSQL = XSQL + " IS_CANCELED  = 0 AND "
        XSQL = XSQL + " IS_COMPLETED = 0 AND "
        XSQL = XSQL + " IS_PAUSED    = 0 "
        '29-Jun-11 J.R. cambios codigo de ubicaciones
        'XSQL = XSQL + " ORDER BY ERP_LEGACY_ID, Substring(Location_Spot_Source,1,3) ASC, Substring(Location_Spot_Source,4,3) ASC, Substring(Location_Spot_Source,10,5) ASC, Substring(Location_Spot_Source,7,3) ASC "
        XSQL = XSQL + " ORDER BY ERP_LEGACY_ID, Substring(Location_Spot_Source,1,2) ASC, Substring(Location_Spot_Source,3,3) ASC, Substring(Location_Spot_Source,8,3) ASC, Substring(Location_Spot_Source,6,2) ASC "

        'FileOpen(1, "c:\OnePlanWMS\OP_WMS_LOG_TEST.txt", OpenMode.Append, OpenAccess.ReadWrite, OpenShare.Default)
        'WriteLine(1, "GetPendingTasksByDoc - " + XSQL)
        'FileClose(1)

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "GetPendingTasks")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "NO_MORE_TASKS"
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function

    '20-Ene-11 J.R. se agrego parametro pSector y pRuta para filtrar el query por sector/ruta
    <WebMethod(Description:="Get next PO to be processed")>
    Public Function GetNextERP_DOC(ByVal pLinea As String, ByVal pSector As String, ByVal pRuta As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        'Public Function GetNextERP_DOC(ByVal pLinea As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String = ""

        '17-Nov-10 J.R. se pidio que la ventana de Binpicking muestre el numero de unidades del pedido para poder incluir los bins vacios y no tener que estar halandolos cada usuario
        '10-Nov-10 J.R. se pidio que la ventana de Binpicking muestre la region y sepa cuando hay cambio de region para avisar
        ''XSQL = "SELECT TOP 1 ERP_DOCUMENT FROM  "
        'XSQL = "SELECT TOP 1 ERP_DOCUMENT, CLIENT_REGION FROM  "
        'XSQL = XSQL + " OP_WMS_VIEW_ASSIGNED_DEMAND "
        'XSQL = XSQL + " ORDER BY ASSIGNED_DATE, ERP_DOCUMENT "
        ''XSQL = XSQL + " ORDER BY ERP_DOCUMENT DESC"
        XSQL = "SELECT TOP 1 ERP_DOCUMENT, CLIENT_REGION, CLIENT_ROUTE, SUM(ISNULL(QTY,0)) AS UNIDADES, NEEDS_TO_AUDIT FROM OP_WMS_VIEW_ASSIGNED_DEMAND "
        XSQL = XSQL + " WHERE ASSIGNED_TO_LINE = '" + pLinea + "' "

        '20-Ene-11 J.R. se agrego filtro por sector y ruta
        If pSector.Trim <> "" Then
            XSQL = XSQL + " AND CLIENT_REGION = '" + pSector + "' "
        End If
        If pRuta.Trim <> "" Then
            XSQL = XSQL + " AND CLIENT_ROUTE like '%" + pRuta.ToUpper + "%' "
        End If

        XSQL = XSQL + " GROUP BY ERP_DOCUMENT, CLIENT_REGION, CLIENT_ROUTE, ASSIGNED_DATE, NEEDS_TO_AUDIT "
        XSQL = XSQL + " ORDER BY ASSIGNED_DATE, ERP_DOCUMENT "

        Try
            'FileOpen(1, "c:\logs\OP_WMS_LOG_TEST.txt", OpenMode.Append, OpenAccess.ReadWrite, OpenShare.Default)
            'WriteLine(1, "GetNextERP_DOC - " + XSQL)
            'FileClose(1)

        Catch ex As Exception
            'pResult = "ERROR," + ex.Message
            'Return Nothing
        End Try

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "GetNextERP_DOC")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "NO_MORE_ERP_DOCS"
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function

    <WebMethod(Description:="Get ERP_DOCUMENT related with the BIN")>
    Public Function GetERP_DOC_By_BIN(ByVal pBIN As Integer, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String = ""

        XSQL = "SELECT CURRENT_ERP_DOCUMENT as ERP_LEGACY_ID FROM OP_WMS_BINS WHERE BIN_ID = " & pBIN

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "GetERP_DOC_By_BIN")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            'FileOpen(1, "c:\OnePlanWMS\OP_WMS_LOG_TEST.txt", OpenMode.Append, OpenAccess.ReadWrite, OpenShare.Default)
            'WriteLine(1, "GetERP_DOC_By_BIN - " + pResult)
            'FileClose(1)
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "NO_DOC_RELATED"
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If


        ''28-Ene-11 J.R. ahora primero verifica por INV_X_BIN
        'XSQL = "SELECT TOP 1 LAST_ERP_DOC as ERP_LEGACY_ID FROM OP_WMS_INV_X_BIN WHERE BIN_ID = " & pBIN

        'Dim miscDABIN As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        'Dim miscDSBIN As DataSet = New DataSet()
        'Try
        '    miscDABIN.Fill(miscDSBIN, "GetERP_DOC_By_BIN")

        '    If miscDSBIN.Tables(0).Rows.Count <= 0 Then

        '        '26-Oct-10 J.R. se puso el Order By porque estaba agarrando documentos viejitos que habian quedado con cantidades pendientes
        '        '16-Sep-10 J.R. no tenia filtro por Quantity Pending entonces devolvia documentos que ya estaban cerrados
        '        XSQL = "SELECT TOP 1 ERP_LEGACY_ID "
        '        XSQL = XSQL + " FROM OP_WMS_TASK_LIST "
        '        '07-Nov-10 J.R. cuando habian tareas incompletas, al hacer picking para otro pedido con el mismo bin, traia otro que habia quedado pendiente
        '        'XSQL = XSQL + " WHERE BIN_TARGET = " & pBIN & " AND QUANTITY_PENDING <> 0 order by ERP_LEGACY_ID desc "
        '        '28-Ene-11 J.R. Se volvio a cambiar el orden hacia LegacyID porque estaba halando pedidos viejitos con tareas pedientes (error = BIN RELACIONADO)
        '        '21-Ene-11 J.R. Se cambio el order a Serial_Number porque ese campo esta indexado, performance.
        '        XSQL = XSQL + " WHERE BIN_TARGET = " & pBIN & " AND IS_COMPLETED = 0 order by ERP_LEGACY_ID desc "
        '        'XSQL = XSQL + " WHERE BIN_TARGET = " & pBIN & " AND IS_COMPLETED = 0 order by SERIAL_NUMBER desc "

        '        'FileOpen(1, "c:\OnePlanWMS\OP_WMS_LOG_TEST.txt", OpenMode.Append, OpenAccess.ReadWrite, OpenShare.Default)
        '        'WriteLine(1, "GetERP_DOC_By_BIN - " + XSQL)
        '        'FileClose(1)

        '        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        '        Dim miscDS As DataSet = New DataSet()
        '        Try
        '            miscDA.Fill(miscDS, "GetERP_DOC_By_BIN")
        '        Catch ex As Exception
        '            pResult = "ERROR," + ex.Message
        '            'FileOpen(1, "c:\OnePlanWMS\OP_WMS_LOG_TEST.txt", OpenMode.Append, OpenAccess.ReadWrite, OpenShare.Default)
        '            'WriteLine(1, "GetERP_DOC_By_BIN - " + pResult)
        '            'FileClose(1)
        '            Return Nothing
        '        End Try
        '        If miscDS.Tables(0).Rows.Count <= 0 Then
        '            pResult = "NO_DOC_RELATED"
        '            Return Nothing
        '        Else
        '            pResult = "OK"
        '            Return miscDS
        '        End If

        '    Else
        '        pResult = "OK"
        '        Return miscDSBIN
        '    End If


        'Catch ex As Exception
        '    pResult = "ERROR," + ex.Message
        '    'FileOpen(1, "c:\OnePlanWMS\OP_WMS_LOG_TEST.txt", OpenMode.Append, OpenAccess.ReadWrite, OpenShare.Default)
        '    'WriteLine(1, "GetERP_DOC_By_BIN - " + pResult)
        '    'FileClose(1)
        '    Return Nothing
        'End Try

    End Function

    '23-Jul-10 J.R.
    <WebMethod(Description:="Get pending Replenishment Tasks to specific user")>
    Public Function GetPendingReplenishmentTasks(ByVal pTaskType As String, ByVal pLoginID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)


        Dim XSQL As String = ""
        XSQL = "SELECT * FROM OP_WMS_TASK_LIST "
        XSQL = XSQL + " WHERE TASK_TYPE = '" + pTaskType + "' AND "
        XSQL = XSQL + " TASK_ASSIGNEDTO = '" + pLoginID.ToUpper + "' AND "
        XSQL = XSQL + " IS_CANCELED = 0 AND "
        XSQL = XSQL + " IS_COMPLETED = 0 AND "
        XSQL = XSQL + " IS_PAUSED = 0 "
        'XSQL = XSQL + " ORDER BY ERP_LEGACY_ID, Substring(Location_Spot_Source,1,3) ASC, Substring(Location_Spot_Source,4,3) ASC, Substring(Location_Spot_Source,10,5) ASC, Substring(Location_Spot_Source,7,3) ASC "

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "GetPendingReplenishmentTasks")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "NO_MORE_TASKS"
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function

    '26-Jul-10 busca tareas pendientes de reubicacion por usuario
    <WebMethod(Description:="Get pending Relocation Tasks to specific user")>
    Public Function GetPendingRelocationTasks(ByVal pTaskType As String, ByVal pLoginID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)


        Dim XSQL As String = ""
        XSQL = "SELECT * FROM OP_WMS_TASK_LIST "
        XSQL = XSQL + " WHERE TASK_TYPE = '" + pTaskType + "' AND "
        XSQL = XSQL + " TASK_ASSIGNEDTO = '" + pLoginID.ToUpper + "' AND "
        XSQL = XSQL + " IS_CANCELED = 0 AND "
        XSQL = XSQL + " IS_COMPLETED = 0 AND "
        XSQL = XSQL + " IS_PAUSED = 0 "
        XSQL = XSQL + " ORDER BY LOCATION_SPOT_TARGET, MATERIAL_CODE "

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "GetPendingRelocationTasks")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "NO_MORE_TASKS"
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function

    <WebMethod(Description:="Get Last 10 trans for a specific location")>
    Public Function GetLastTrans_ByLocation(ByVal pWarehouseParent As String, ByVal pLocation As String, ByVal pTopRows As Integer, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)


        Dim XSQL As String = ""
        XSQL = "SELECT TOP " & pTopRows & " * FROM OP_WMS_TRANS"
        XSQL = XSQL + " WHERE SOURCE_WAREHOUSE = '" + pWarehouseParent + "' AND SOURCE_LOCATION = '" + pLocation + "'"
        XSQL = XSQL + " ORDER BY TRANS_DATE, TRANS_TYPE, LOGIN_ID"

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()

        Try
            miscDA.Fill(miscDS, "GetLastTrans_ByLocation")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR, No se encontraron transacciones para esa ubicacion"
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function

    <WebMethod(Description:="Get Current Doc on Dispatch")>
    Public Function GetCurrentDocOnDispatchInfo(ByVal pLine As String, ByVal pLogin As String, ByVal pEnvironmentName As String, ByRef pResult As String) As DataSet
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)


        Dim XSQL As String = ""
        '07-Sep-10 J.R. dbo.OP_WMS_FUNC_CONSOL_TERMINAL_BYUSR('" & pLOGIN & "') para que trajera los datos en base a la terminal de consolidacion asignada
        XSQL = "SELECT * FROM OP_WMS_VIEW_DOC_ON_DISPATCH where LINE_ID = '" + pLine + "' AND CONSOLIDATION_TERMINAL = dbo.OP_WMS_FUNC_CONSOL_TERMINAL_BYUSR('" & pLogin & "') ORDER BY QTY_PENDING DESC"

        'FileOpen(1, "c:\OnePlanWMS\OP_WMS_LOG_TEST.txt", OpenMode.Append, OpenAccess.ReadWrite, OpenShare.Default)
        'WriteLine(1, "GetCurrentDocOnDispatchInfo - " + XSQL)
        'FileClose(1)

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()

        Try
            miscDA.Fill(miscDS, "GetCurrentDocOnDispatchInfo")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            'FileOpen(1, "c:\OnePlanWMS\OP_WMS_LOG_TEST.txt", OpenMode.Append, OpenAccess.ReadWrite, OpenShare.Default)
            'WriteLine(1, "GetCurrentDocOnDispatchInfo - catch - " + pResult)
            'FileClose(1)
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR, No hay pedido en consolidacion para linea " + pLine
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function

    <WebMethod(Description:="Get Current Doc on Dispatch")>
    Public Function GetPerc_DocOnDispatch(ByVal pLine As String, ByVal pLogin As String, ByVal pEnvironmentName As String, ByRef pResult As String) As Double
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        Dim XSQL As String = ""
        '29Jun10 J.R. mal calculado el %
        'XSQL = "SELECT (SUM(QTY_CONS) / SUM(QTY_PENDING)*100) AS PERC_CUADRE "
        XSQL = "SELECT (SUM(QTY_CONS) / SUM(ERP_QTY)*100) AS PERC_CUADRE "
        '07-Sep-10 J.R. dbo.OP_WMS_FUNC_CONSOL_TERMINAL_BYUSR('" & pLOGIN & "') para que trajera los datos en base a la terminal de consolidacion asignada
        XSQL = XSQL + "FROM OP_WMS_VIEW_DOC_ON_DISPATCH WHERE LINE_ID = '" + pLine + "' AND CONSOLIDATION_TERMINAL = dbo.OP_WMS_FUNC_CONSOL_TERMINAL_BYUSR('" & pLogin & "')"

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()

        Try
            miscDA.Fill(miscDS, "GetPerc_DocOnDispatch")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR, No hay pedido en consolidacion para linea " + pLine
            Return 0
        Else
            pResult = "OK"
            Return miscDS.Tables(0).Rows(0)("PERC_CUADRE")
        End If

    End Function


    <WebMethod(Description:="Get Current Doc on Dispatch")>
    Public Function AllowMaterialScann_DocOnDispatch(ByVal pLine As String, ByVal pMaterialID As String, ByVal pScannedQty As Double, ByVal pLogin As String, ByVal pEnvironmentName As String, ByRef pResult As String) As Double
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        Dim XSQL As String = ""
        XSQL = "SELECT  QTY_PENDING "
        XSQL = XSQL + " FROM OP_WMS_VIEW_DOC_ON_DISPATCH "
        XSQL = XSQL + " WHERE LINE_ID = '" + pLine + "' AND"
        XSQL = XSQL + " MATERIAL_ID = '" + pMaterialID + "'"
        '07-Sep-10 J.R. dbo.OP_WMS_FUNC_CONSOL_TERMINAL_BYUSR('" & pLOGIN & "') para que trajera los datos en base a la terminal de consolidacion asignada
        XSQL = XSQL + " AND CONSOLIDATION_TERMINAL = dbo.OP_WMS_FUNC_CONSOL_TERMINAL_BYUSR('" & pLogin & "')"

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()

        Try
            miscDA.Fill(miscDS, "AllowMaterialScann_DocOnDispatch")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR, Material " + pMaterialID + " no existe en el pedido "
            Return -1
        Else
            If miscDS.Tables(0).Rows(0)("QTY_PENDING") >= pScannedQty Then
                pResult = "OK"
                Return 0
            Else
                pResult = "ERROR, Cantidad ingresada Excede la cantidad solicitada"
                Return -1
            End If
        End If
    End Function

    <WebMethod(Description:="Get Current Doc on Dispatch")>
    Public Function GetTransDet_DocOnDispatch(ByVal pLine As String, ByVal pLogin As String, ByVal pEnvironmentName As String, ByRef pResult As String) As DataTable

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldb_conexion.Open()

        Try
            Dim cmd As New SqlCommand
            Dim reader As SqlDataReader
            Dim dt As DataTable = New DataTable("TransDoc")

            cmd.CommandText = "OP_WMS_SP_GET_TRANS_DOC_INDISPATCH"
            cmd.Parameters.Add("@pLineID", SqlDbType.VarChar, 15).Value = pLine
            '07-Sep-10 J.Rpara que trajera los datos en base a la terminal de consolidacion asignada
            cmd.Parameters.Add("@pLoginID", SqlDbType.VarChar, 25).Value = pLogin

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldb_conexion
            reader = cmd.ExecuteReader()

            dt.Load(reader)

            sqldb_conexion.Close()
            pResult = "OK"
            Return dt

        Catch ex As Exception
            pResult = ex.Message
            Return Nothing
        Finally
            '09-Mar-11 J.R. cerrar conexiones para mejorar performance
            sqldb_conexion.Close()
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try
    End Function

    '09-Jul-10 J.R. traer replenishment    
    <WebMethod(Description:="Get Products ready for Replenishment")>
    Public Function GetReplenishmentProdsBasicView(ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        Dim XSQL As String = ""
        XSQL = "SELECT * FROM OP_WMS_VIEW_PENDING_REPLENISHMENT ORDER BY PERCENTAGE_TO_LIMIT "
        'XSQL = XSQL + " WHERE "

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "GetReplenishmentProdsBasicView")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR, No se encontraron prductoso para ese rango de filtro"
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function

    '22-Jul-10 J.R. devuelve un DS con los productos a Reabastecer por usuario
    <WebMethod(Description:="Get Products ready for Replenishment by User Assigned to a location")>
    Public Function GetReplenishmentByUser(ByVal pUser As String, ByVal pWarehouse As String, ByVal pTaskType As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        Dim XSQL As String = ""
        XSQL = "Select MATERIAL_ID SKU, MATERIAL_DESCRIPTION DESCRIPCION, A.LOCATION_SPOT UBICACION, QUANTITY_SALABLE ACTUAL, VALID_REPLENISH REABASTECER, isnull(VALID_REPLENISH,1) / isnull(A.MAX_X_BIN, isnull(VALID_REPLENISH,1)) BINS "
        XSQL = XSQL + "FROM OP_WMS_VIEW_PENDING_REPLENISHMENT A inner join OP_WMS_LOGIN_JOIN_LOCATIONS B "
        XSQL = XSQL + "ON A.WAREHOUSE_PARENT = B.WAREHOUSE_PARENT AND A.LINE_ID = B.LINE_ID AND SUBSTRING(A.LOCATION_SPOT,1,6) = SUBSTRING(B.LOCATION_SPOT,1,6) "
        XSQL = XSQL + "WHERE A.WAREHOUSE_PARENT = '" + pWarehouse + "' AND B.TASK_TYPE = '" + pTaskType + "' AND B.LOGIN_ID = '" + pUser + "' AND VALID_REPLENISH > 0 "
        XSQL = XSQL + "ORDER BY PERCENTAGE_TO_LIMIT, VALID_REPLENISH"

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "GetReplenishmentByUser")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR, No se encontraron productos para ese rango de filtro"
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function

    <WebMethod(Description:="Get Transactional Info of a BIN")>
    Public Function GetTransactionalBINInfo(ByVal pBinID As String, ByVal pEnvironmentName As String, ByRef pResult As String) As DataSet
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)


        Dim XSQL As String = ""
        XSQL = "SELECT * FROM OP_WMS_FUNC_GETBIN_CURRENTINFO('" + pBinID + "')"

        'FileOpen(1, "c:\OnePlanWMS\OP_WMS_LOG_TEST.txt", OpenMode.Append, OpenAccess.ReadWrite, OpenShare.Default)
        'WriteLine(1, "GetCurrentDocOnDispatchInfo - " + XSQL)
        'FileClose(1)

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()

        Try
            miscDA.Fill(miscDS, "GetBINInfo")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            'FileOpen(1, "c:\OnePlanWMS\OP_WMS_LOG_TEST.txt", OpenMode.Append, OpenAccess.ReadWrite, OpenShare.Default)
            'WriteLine(1, "GetCurrentDocOnDispatchInfo - catch - " + pResult)
            'FileClose(1)
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR, No hay informacion para el Bin: " + pBinID
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function

    <WebMethod(Description:="Get Transactional Info of a Document")>
    Public Function GetTransactionalDOCInfo(ByVal pDocNumber As String, ByVal pEnvironmentName As String, ByRef pResult As String) As DataSet
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)


        Dim XSQL As String = ""
        XSQL = "SELECT * FROM OP_WMS_FUNC_GETDOC_CURRENTINFO('" + pDocNumber + "')"

        'FileOpen(1, "c:\OnePlanWMS\OP_WMS_LOG_TEST.txt", OpenMode.Append, OpenAccess.ReadWrite, OpenShare.Default)
        'WriteLine(1, "GetCurrentDocOnDispatchInfo - " + XSQL)
        'FileClose(1)

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()

        Try
            miscDA.Fill(miscDS, "GetTransactionalDOCInfo")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            'FileOpen(1, "c:\OnePlanWMS\OP_WMS_LOG_TEST.txt", OpenMode.Append, OpenAccess.ReadWrite, OpenShare.Default)
            'WriteLine(1, "GetCurrentDocOnDispatchInfo - catch - " + pResult)
            'FileClose(1)
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR, No hay informacion para el Pedido: " + pDocNumber
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function

    <WebMethod(Description:="Get qty pending pedidos")>
    Public Function GetPending_Docs(ByVal pLinea As String, ByVal pSector As String, ByVal pRuta As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String = ""

        XSQL = "SELECT COUNT(distinct ERP_DOCUMENT) PENDIENTES FROM OP_WMS_DEMAND_TO_PICK "
        XSQL = XSQL + "WHERE ALLOWED_TO_PICK = 2 AND ASSIGNED_TO_LINE = '" + pLinea + "' "


        If pSector.Trim <> "" Then
            XSQL = XSQL + " AND CLIENT_REGION = '" + pSector + "' "
        End If
        If pRuta.Trim <> "" Then
            XSQL = XSQL + " AND CLIENT_ROUTE like '%" + pRuta.ToUpper + "%' "
        End If

        'FileOpen(1, "c:\OnePlanWMS\OP_WMS_LOG_TEST.txt", OpenMode.Append, OpenAccess.ReadWrite, OpenShare.Default)
        'WriteLine(1, "GetNextERP_DOC - " + XSQL)
        'FileClose(1)

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "GetPending_Docs")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "NO_MORE_ERP_DOCS"
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function

    '11-Mar-11 J.R. Reporte de pedidos recibidos vs consolidados
    <WebMethod(Description:="Get Received vs Consolidated Docs Report ")>
    Public Function GetDocsReportBasicView(ByVal pSinceDate As Date, ByVal pToDate As Date, ByVal pDateFilterType As String, ByVal pDates As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim pFormatedDate_Since As String
        Dim pFormatedDate_To As String


        pFormatedDate_Since = Format(pSinceDate, "yyyy-MM-dd")
        pFormatedDate_To = Format(pToDate, "yyyy-MM-dd")

        Dim XSQL As String = ""
        XSQL = "SELECT * FROM OP_WMS_VIEW_DOCS_RECVD_VS_CONSOL"
        XSQL = XSQL + " WHERE "

        If pDateFilterType = "BY_CALENDAR" Then
            'XSQL = XSQL + " CONVERT(CHAR(10),ASSIGNED_DATE,23) IN (" + pDates + ") "
            XSQL = XSQL + " ERP_DOC_DATE IN (" + pDates + ") "
        Else
            'XSQL = XSQL + " CONVERT(CHAR(25),ASSIGNED_DATE,21) BETWEEN CONVERT(CHAR(25),'" + pFormatedDate_Since + " 00:00:00',21) AND "
            'XSQL = XSQL + " ERP_DOC_DATE BETWEEN CONVERT(CHAR(25),'" + pFormatedDate_Since + " 00:00:00',21) AND "
            XSQL = XSQL + " ERP_DOC_DATE BETWEEN '" + pFormatedDate_Since + "' AND "
            XSQL = XSQL + " '" + pFormatedDate_To + "' "
        End If

        XSQL = XSQL + " ORDER BY CLIENT_REGION, ERP_DOC_DATE "

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "GetDocsReportBasicView")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR, No se encontraron pedidos para ese rango de fechas"
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function

    '22-Mar-11 J.R. dataset con los datos de la distribucion o balanceo de pedidos por tamano y linea
    <WebMethod(Description:="Get Balanceo de Pedidos ")>
    Public Function GetLineBalancingBySector(ByVal pSector As String, ByVal pRuta As String, ByVal pIncluyeAsignados As Boolean, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        Dim XSQL As New StringBuilder
        XSQL.Append("SELECT SIZE, SIZE_DESCRIPTION, INITIAL_RANGE, FINAL_RANGE, TOTAL_PEDIDOS, ")
        XSQL.Append("ROUND(TOTAL_PEDIDOS * LINE_1_PERCENT / 100,0) LINEA1, ")
        XSQL.Append("CASE WHEN LINE_3_PERCENT > 0 THEN ROUND(TOTAL_PEDIDOS * LINE_2_PERCENT / 100,0) ELSE TOTAL_PEDIDOS - ROUND(TOTAL_PEDIDOS * LINE_1_PERCENT / 100,0) END LINEA2, ")
        XSQL.Append("CASE WHEN LINE_3_PERCENT > 0 THEN TOTAL_PEDIDOS - ROUND(TOTAL_PEDIDOS * LINE_1_PERCENT / 100,0) - ROUND(TOTAL_PEDIDOS * LINE_2_PERCENT / 100,0) ELSE 0 END LINEA3 ")
        XSQL.Append("FROM (select *, (SELECT COUNT(1) FROM (select ERP_DOCUMENT, SUM(ISNULL(QTY,0)) QTY, dbo.OP_WMS_FUNC_TAMANO_PEDIDO(SUM(ISNULL(QTY,0))) TAMANO from OP_WMS_DEMAND_TO_PICK where (ALLOWED_TO_PICK is null " + IIf(pIncluyeAsignados, " OR ALLOWED_TO_PICK = 2)", ")") + " and CLIENT_REGION = '" & pSector.ToUpper & "' ")

        '20-Ene-11 J.R. se agrego filtro por sector y ruta
        If pRuta.Trim <> "" Then
            XSQL.Append("AND CLIENT_ROUTE like '%" + pRuta.ToUpper + "%' ")
        End If

        XSQL.Append("group by ERP_DOCUMENT) A WHERE TAMANO = OP_WMS_LINES_BALANCING.SIZE) AS TOTAL_PEDIDOS from OP_WMS_LINES_BALANCING) B ")

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL.ToString, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "GetLineBalancingBySector")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "No se encontraron pedidos para asignar o no se han creado los pordentajes de balanceo"
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function

    '22-Mar-11 J.R. dataset con los datos de la distribucion o balanceo de pedidos por tamano y linea
    <WebMethod(Description:="Get Balanceo de Pedidos Por Tamano")>
    Public Function GetDemandBySizeForBalancing(ByVal pSector As String, ByVal pRuta As String, ByVal pIncluyeAsignados As Boolean, ByVal pTamano As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        Try

            Dim XSQL As New StringBuilder
            XSQL.Append("select * FROM (select ERP_DOCUMENT, SUM(ISNULL(QTY,0)) QTY, dbo.OP_WMS_FUNC_TAMANO_PEDIDO(SUM(ISNULL(QTY,0))) TAMANO from OP_WMS_DEMAND_TO_PICK where (ALLOWED_TO_PICK is null " + IIf(pIncluyeAsignados, " OR ALLOWED_TO_PICK = 2)", ")") + " and CLIENT_REGION = '" & pSector.ToUpper & "' ")

            '20-Ene-11 J.R. se agrego filtro por sector y ruta
            If pRuta.Trim <> "" Then
                XSQL.Append("AND CLIENT_ROUTE like '%" + pRuta.ToUpper + "%' ")
            End If

            XSQL.Append("group by ERP_DOCUMENT) A WHERE TAMANO = '" & pTamano & "' ORDER BY QTY DESC, ERP_DOCUMENT")

            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL.ToString, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()
            Try
                miscDA.Fill(miscDS, "GetDemandBySizeForBalancing")
            Catch ex As Exception
                pResult = "ERROR," + ex.Message
                Return Nothing
            End Try
            If miscDS.Tables(0).Rows.Count <= 0 Then
                pResult = "No se encontraron pedidos para asignar"
                Return Nothing
            Else
                pResult = "OK"
                Return miscDS
            End If

        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try

    End Function

    <WebMethod(Description:="Get Current Doc on Dispatch")>
    Public Function GetClientRouteInfoByDoc(ByVal pDoc As String, ByVal pEnvironmentName As String, ByRef pResult As String) As DataSet
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        Dim XSQL As String = ""
        XSQL = "SELECT CLIENT_ROUTE, CLIENT_REGION FROM OP_WMS_DEMAND_TO_PICK WHERE ERP_DOCUMENT = '" + pDoc.ToUpper + "'"

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()

        Try
            miscDA.Fill(miscDS, "GetClientRouteInfoByDoc")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR, Documento " + pDoc + " no existe "
            Return Nothing
        Else
            Return miscDS
        End If
    End Function
    <WebMethod(Description:="Get Current Doc on Dispatch")>
    Public Function GetNextPendingBIN(ByVal pLogin As String, ByVal pEnvironmentName As String, ByRef pResult As String) As DataTable

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldb_conexion.Open()

        Try
            Dim cmd As New SqlCommand
            Dim reader As SqlDataReader
            Dim dt As DataTable = New DataTable("GetNextPendingBIN")

            cmd.CommandText = "OP_WMS_SP_GET_NEXT_PENDING_BIN"
            cmd.Parameters.Add("@pLoginID", SqlDbType.VarChar, 25).Value = pLogin

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldb_conexion
            reader = cmd.ExecuteReader()

            dt.Load(reader)

            sqldb_conexion.Close()
            pResult = "OK"
            Return dt

        Catch ex As Exception
            pResult = ex.Message
            Return Nothing
        Finally
            '09-Mar-11 J.R. cerrar conexiones para mejorar performance
            sqldb_conexion.Close()
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try
    End Function

    <WebMethod(Description:="Get pending Tasks to specific user")>
    Public Function GetPendingTasksByDoc_Kiosk(ByVal pERP_DOCUMENT As String, ByVal pLoginID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)


        Dim XSQL As String = ""
        XSQL = "SELECT * FROM OP_WMS_TASK_LIST "
        XSQL = XSQL + " WHERE ERP_LEGACY_ID = '" + pERP_DOCUMENT + "' AND "
        XSQL = XSQL + " TASK_ASSIGNEDTO = '" + pLoginID.ToUpper + "' AND "
        XSQL = XSQL + " IS_CANCELED  = 0 AND "
        XSQL = XSQL + " IS_PAUSED    = 0 AND"
        XSQL = XSQL + " IS_COMPLETED2 = 0  "
        '29-Jun-11 J.R. cambios codigo de ubicaciones
        'XSQL = XSQL + " ORDER BY ERP_LEGACY_ID, Substring(Location_Spot_Source,1,3) ASC, Substring(Location_Spot_Source,4,3) ASC, Substring(Location_Spot_Source,10,5) ASC, Substring(Location_Spot_Source,7,3) ASC "
        XSQL = XSQL + " ORDER BY ERP_LEGACY_ID, Substring(Location_Spot_Source,1,2) ASC, Substring(Location_Spot_Source,3,3) ASC, Substring(Location_Spot_Source,8,3) ASC, Substring(Location_Spot_Source,6,2) ASC "

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "GetPendingTasksByDoc_Kiosk")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "NO_MORE_TASKS"
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function

    '25-May-11 J.R. para obtener informacion de un documento
    <WebMethod(Description:="Get info of Document")>
    Public Function GetDocumentInfo(ByVal pDoc As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String = ""

        XSQL = "SELECT CLIENT_NAME, SUM(ISNULL(QTY,0)) UNIDADES, MAX(CLIENT_REGION) SECTOR, MAX(CLIENT_ROUTE) RUTA, (SELECT MAX(ISNULL(QTY_BOXES,0)) FROM OP_WMS_DOCUMENT_HEADER WHERE ERP_LEGACY_ID = '" + pDoc + "') QTY_BOXES FROM OP_WMS_DEMAND_TO_PICK WHERE ERP_DOCUMENT = '" + pDoc + "' GROUP BY CLIENT_NAME "

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "GetDocumentInfo")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "NO_INFO"
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function

    '17-Jun-11 J.R. 
    <WebMethod(Description:="Daily Consolidtion")>
    Public Function GetConsolidationByDay(ByVal pDate As Date, ByVal pLoginID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        'Dim pDateString As Date = Format(pDate, "yyyy-MM-dd HH:mm:00")
        Dim pDateString As String = Format(pDate, "yyyy-MM-dd")

        Dim XSQL As String = ""
        XSQL = "SELECT * FROM OP_WMS_VIEW_DAILY_CONSOLIDATION "
        XSQL = XSQL + " WHERE LOGIN_ID = '" + pLoginID + "' AND "
        XSQL = XSQL + " CONVERT(CHAR(10),FIN,21) = '" + pDateString + "' "
        'XSQL = XSQL + " CONVERT(CHAR(10),FIN,21) = CONVERT(CHAR(25),'" + pDateString + " 00:00:00',21) "
        XSQL = XSQL + " ORDER BY FIN "

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "GetConsolidationByDay")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "NO_INFO"
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function

    '24-Jun-11 J.R. para llenar el combo de rutas en balanceo de pedidos
    <WebMethod(Description:="Get RUTAS POR SECTOR")>
    Public Function GetRutasPorSector(ByVal pSector As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String = ""

        XSQL = "SELECT DISTINCT(ISNULL(CLIENT_ROUTE,'')) AS RUTA FROM OP_WMS_DEMAND_TO_PICK WHERE CLIENT_REGION = '" + pSector + "' ORDER BY 1 "

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "GetRutasPorSector")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "NO_INFO"
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function

    '27-Jun-11 J.R. 
    <WebMethod(Description:="Get Locations by document in line")>
    Public Function GetLocationsByDocument(ByVal pDoc As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        Dim XSQL As String = ""

        XSQL = "SELECT LOCATION_SPOT, LINE_ID FROM OP_WMS_LOGIN_JOIN_LOCATIONS "
        XSQL = XSQL + "WHERE LINE_ID = (SELECT MAX(ASSIGNED_TO_LINE) FROM OP_WMS_DEMAND_TO_PICK WHERE ERP_DOCUMENT = '" + pDoc + "') "
        XSQL = XSQL + "ORDER BY LOCATION_SPOT"

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "GetLocationsByDocument")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "NO_INFO"
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function

    '21/06/2013 WM
    <WebMethod(Description:="Get all finished dispatch control ")>
    Public Function GetFinishedDispatchAudit(ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection
        sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim SQL As String = ""

        sqldb_conexion.Open()

        Try
            SQL = " SELECT * FROM " + DefaultSchema + "OP_WMS_AUDIT_DISPATCH_CONTROL WHERE STATUS = 'FINISHED' AND PASS_DATE IS NULL AND PASS = 0"

            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(SQL, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()


            miscDA.Fill(miscDS, "GetFinishedDispatchAudit")

            If miscDS.Tables(0).Rows.Count <= 0 Then
                pResult = "ERROR, No hay auditorias terminadas pendientes de pase de salida"
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

    <WebMethod(Description:="Get all pass by poliza available ")>
    Public Function GetPassByPolizaAvailable(ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldbConexion As SqlConnection
        sqldbConexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        'Dim SQL As String = ""

        sqldbConexion.Open()

        Try
            Dim strSql As New StringBuilder
            strSql.Append(" SELECT P.CODIGO_POLIZA , P.NUMERO_ORDEN	")
            strSql.Append(String.Format(" FROM {0}OP_WMS_POLIZA_HEADER P", DefaultSchema))
            strSql.Append(String.Format(" INNER JOIN {0}OP_WMS_TRANS T ON T.CODIGO_POLIZA = P.CODIGO_POLIZA", DefaultSchema))
            strSql.Append(" WHERE NOT EXISTS(SELECT 1")
            strSql.Append(" FROM  " + DefaultSchema + "OP_WMS3PL_POLIZA_X_PASS PS")
            strSql.Append(" WHERE P.CODIGO_POLIZA = PS.CODE_POLIZA)")
            strSql.Append(" AND P.TIPO = 'EGRESO'")
            strSql.Append(" GROUP BY P.CODIGO_POLIZA , P.NUMERO_ORDEN")

            'SQL = " SELECT P.CODIGO_POLIZA , P.NUMERO_ORDEN	 FROM " + DefaultSchema + "OP_WMS_POLIZA_HEADER WHERE STATUS = 'FINISHED' AND PASS_DATE IS NULL AND PASS = 0"

            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(strSql.ToString(), sqldbConexion)
            Dim miscDS As DataSet = New DataSet()


            miscDA.Fill(miscDS, "GetPassByPoliza")

            If miscDS.Tables(0).Rows.Count <= 0 Then
                pResult = "ERROR, No hay polizas pendientes de pase de salida"
                Return Nothing
            Else
                pResult = "OK"
                Return miscDS
            End If

        Catch ex As Exception
            pResult = "ERROR, " + ex.Message + " pDebugInfo: "
            Return Nothing
        Finally
            sqldbConexion.Dispose()
        End Try
    End Function

    <WebMethod(Description:="Get all pass by poliza assigned ")>
    Public Function GetPassByPolizaAssigned(ByVal pPassId As Integer, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldbConexion As SqlConnection
        sqldbConexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        'Dim SQL As String = ""

        sqldbConexion.Open()

        Try
            Dim strSql As New StringBuilder
            strSql.Append(" SELECT *")
            strSql.Append(String.Format(" FROM {0}OP_WMS_VIEW_PASS_BY_POLIZA ", DefaultSchema))
            strSql.Append(String.Format(" WHERE PASS_ID = '{0}'", pPassId))

            'SQL = " SELECT P.CODIGO_POLIZA , P.NUMERO_ORDEN	 FROM " + DefaultSchema + "OP_WMS_POLIZA_HEADER WHERE STATUS = 'FINISHED' AND PASS_DATE IS NULL AND PASS = 0"

            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(strSql.ToString(), sqldbConexion)
            Dim miscDS As DataSet = New DataSet()


            miscDA.Fill(miscDS, "GetPassByPolizaAssigned")

            If miscDS.Tables(0).Rows.Count <= 0 Then
                pResult = "ERROR, No hay polizas para el pase de salida"
                Return Nothing
            Else
                pResult = "OK"
                Return miscDS
            End If

        Catch ex As Exception
            pResult = "ERROR, " + ex.Message + " pDebugInfo: "
            Return Nothing
        Finally
            sqldbConexion.Dispose()
        End Try
    End Function

    <WebMethod(Description:="Get Lotacion")>
    Public Function GET_LOCATION(ByVal pLocation As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection
        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Catch ex As Exception
            pResult = "ERROR:" + ex.Message
            Return Nothing
        End Try

        Dim XSQL As String = ""
        XSQL = "SELECT * "
        XSQL = XSQL + " , ISNULL((SELECT SUM(USED_MT2) FROM  " + DefaultSchema + "OP_WMS_LICENSES L "
        XSQL = XSQL + " WHERE S.LOCATION_SPOT = L.CURRENT_LOCATION AND 0 < ( SELECT COUNT(*)"
        XSQL = XSQL + " FROM  " + DefaultSchema + "OP_WMS_INV_X_LICENSE IL WHERE L.LICENSE_ID = IL.LICENSE_ID AND IL.QTY > 0)),0) AS MT2_USED"
        XSQL = XSQL + " FROM  " + DefaultSchema + "OP_WMS_SHELF_SPOTS S"
        XSQL = XSQL + " WHERE "
        XSQL = XSQL + " LOCATION_SPOT = '" & pLocation & "'"

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "GET_LICENSE_DETAIL")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR,  La ubicacion " & pLocation & " no existe"
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function

    <WebMethod(Description:="Get Poliza_Assignedto")>
    Public Function GET_POLIZA_ASSIGNEDTO(ByVal pOperador As String, ByVal pPolizaOpcion As String, ByVal pRegimen As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldbConexion As SqlConnection
        Try
            sqldbConexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Catch ex As Exception
            pResult = "ERROR:" + ex.Message
            Return Nothing
        End Try

        Dim cmd As New SqlCommand

        cmd.Parameters.Add("@Operador", SqlDbType.VarChar)
        cmd.Parameters("@Operador").Direction = ParameterDirection.Input
        cmd.Parameters("@Operador").Value = pOperador

        cmd.Parameters.Add("@PolizaOpcion", SqlDbType.VarChar)
        cmd.Parameters("@PolizaOpcion").Direction = ParameterDirection.Input
        cmd.Parameters("@PolizaOpcion").Value = pPolizaOpcion

        cmd.Parameters.Add("@REGIMEN", SqlDbType.VarChar)
        cmd.Parameters("@REGIMEN").Direction = ParameterDirection.Input
        cmd.Parameters("@REGIMEN").Value = pRegimen

        cmd.Parameters.Add("@pRESULT", SqlDbType.VarChar, 250)
        cmd.Parameters("@pRESULT").Direction = ParameterDirection.Output
        cmd.Parameters("@pRESULT").Value = ""
        cmd.CommandText = DefaultSchema + "[OP_WMS_SP_GET_POLIZA_ASSIGNED]"
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Connection = sqldbConexion

        Dim miscDa As SqlDataAdapter = New SqlDataAdapter(cmd)
        Dim miscDs As DataSet = New DataSet()

        Try
            miscDa.Fill(miscDs, "GET_POLIZA_ASSIGNEDTO")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try

        sqldbConexion.Close()
        pResult = cmd.Parameters("@pRESULT").Value.ToString

        Return miscDs

    End Function

    <WebMethod(Description:="Get Poliza_Assignedto")>
    Public Function GET_TYPE_CHARGE_MOVIL(ByVal pLicenseId As Integer, ByVal pTypeTrans As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection
        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Catch ex As Exception
            pResult = "ERROR:" + ex.Message
            Return Nothing
        End Try
        Try
            Dim cmd As New SqlCommand
            cmd.Parameters.Add("@LICENSE_ID", SqlDbType.Int)
            cmd.Parameters("@LICENSE_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@LICENSE_ID").Value = pLicenseId

            cmd.Parameters.Add("@TYPE_TRANS", SqlDbType.VarChar)
            cmd.Parameters("@TYPE_TRANS").Direction = ParameterDirection.Input
            cmd.Parameters("@TYPE_TRANS").Value = pTypeTrans


            cmd.CommandText = DefaultSchema + "[OP_WMS_GET_TYPE_CHARGE_BY_MOBILE]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldb_conexion

            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim miscDS As DataSet = New DataSet()
            miscDA.Fill(miscDS, "GET_TYPE_CHARGE_MOVIL")

            If miscDS.Tables(0).Rows.Count <= 0 Then
                pResult = "ERROR,  No hay tipos de cobro para movil"
                Return Nothing
            Else
                pResult = "OK"
                Return miscDS
            End If
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try

    End Function


    <WebMethod(Description:="Get Poliza_Assignedto")>
    Public Function SearchSkuAuditoriaDesp(ByVal pBarcode As String, ByVal pPoliza As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection
        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Catch ex As Exception
            pResult = "ERROR:" + ex.Message
            Return Nothing
        End Try

        Dim XSQL As String = ""
        XSQL = "select COUNT(*)"
        XSQL = XSQL + " from  " + DefaultSchema + "OP_WMS_TASK_LIST"
        XSQL = XSQL + " where CODIGO_POLIZA_TARGET = '" + pPoliza + "'"
        XSQL = XSQL + " AND BARCODE_ID = '" + pBarcode + "'"


        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "SearchSkuAuditoriaDesp")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try

        If miscDS.Tables(0).Rows(0)(0) = 0 Then
            pResult = "ERROR, Sku invalido para esta auditoria"
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function

    <WebMethod(Description:="Get Tasks Ingreso General")>
    Public Function GetTaskIngGeneral(ByVal pCodigoPoliza As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        Dim strSql As New StringBuilder
        strSql.Append(" SELECT *")
        strSql.Append(String.Format(" FROM {0}OP_WMS_VIEW_TRANS_BASIC_ING_GENERAL", DefaultSchema))
        strSql.Append(String.Format(" WHERE CODIGO_POLIZA = '{0}'", pCodigoPoliza))

        Dim miscDa As SqlDataAdapter = New SqlDataAdapter(strSql.ToString(), sqldbConexion)
        Dim miscDs As DataSet = New DataSet()
        Try
            miscDa.Fill(miscDs, "repTransIngGeneral")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDs.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR, No se encontraron registros"
            Return Nothing
        Else
            pResult = "OK"
            Return miscDs
        End If

    End Function
#Region "Inventario Externo"


    <WebMethod(Description:="UpDatePoliza")>
    Public Function UpdatePoliza(
            ByVal pPOLIZA_SEGURO As String,
            ByVal pUSER As String,
            ByVal pRPOLIZA As String,
            ByVal pResult As String,
            ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection
        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Catch ex As Exception
            pResult = "ERROR:" + ex.Message
            Return Nothing
        End Try
        Dim XSQL As String = "exec   " + DefaultSchema + "[OP_WMS_SP_INSERTAR_LICENCIA] "
        XSQL = XSQL + " ,@POLIZA_SEGURO  ='" + pPOLIZA_SEGURO + "'"
        XSQL = XSQL + " ,@USER           ='" + pUSER + "'"
        XSQL = XSQL + " ,@RPOLIZA        ='" + pRPOLIZA + "'"
        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "UpDatePoliza")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try

        If pResult = "OK" Then
            Return miscDS
        End If
    End Function

    <WebMethod(Description:="AddMaterial")>
    Public Function AddMaterial(
        ByVal pCODE_SKU As String,
        ByVal pSKU_DESCRIPTION As String,
        ByVal pCUSTOMER As String,
        ByVal pUSER As String,
        ByVal pResult As String,
        ByVal pEnvironmentName As String
                    ) As DataSet
        Dim sqldb_conexion As SqlConnection
        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Catch ex As Exception
            pResult = "ERROR:" + ex.Message
            Return Nothing
        End Try
        Dim XSQL As String = "exec   " + DefaultSchema + "[OP_WMS_SP_ADD_MATERIAL] "
        XSQL = XSQL + " @CODE_SKU         ='" + pCODE_SKU + "'"
        XSQL = XSQL + " ,@SKU_DESCRIPTION  ='" + pSKU_DESCRIPTION + "'"
        XSQL = XSQL + " ,@CUSTOMER         ='" + pCUSTOMER + "'"
        XSQL = XSQL + " ,@USER      	   ='" + pUSER + "'"
        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "OP_WMS_SP_INSERTAR_LICENCIA")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try

        If pResult = "OK" Then
            Return miscDS
        End If
    End Function

    <WebMethod(Description:="AddPolizaHeader")>
    Public Function AddPolizaHeader(
        ByVal pNumeroPoliza As Integer,
        ByVal pCUSTOMER As String,
        ByVal pCUSTOMER_NAME As String,
        ByVal pUSER As String,
        ByVal pTIPO As String,
        ByVal pPOLASEGURADORA As String,
        ByVal pACUERDO_COMERCIAL As String,
        ByVal pIDENTITY As String,
        ByVal pResult As String,
        ByVal pEnvironmentName As String) As String

        Dim sqldb_conexion As SqlConnection
        Dim sqlCmd As SqlCommand
        Dim strReturn As String

        Dim st As String
        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Catch ex As Exception
            pResult = "ERROR:" + ex.Message
            Return Nothing
        End Try


        Try
            ' Enviamos datos de licencia
            Dim cmd As New SqlCommand(DefaultSchema + "[OP_WMS_SP_INSERT_OP_WMS_POLIZA_HEADER]", sqldb_conexion)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@NumeroPoliza", SqlDbType.Int).Value = pNumeroPoliza
            cmd.Parameters.Add("@CUSTOMER", SqlDbType.VarChar).Value = pCUSTOMER
            cmd.Parameters.Add("@CUSTOMER_NAME", SqlDbType.VarChar).Value = pCUSTOMER_NAME
            cmd.Parameters.Add("@USER", SqlDbType.VarChar).Value = pUSER
            cmd.Parameters.Add("@TIPO", SqlDbType.VarChar).Value = pTIPO
            cmd.Parameters.Add("@POLASEGURADORA", SqlDbType.VarChar).Value = pPOLASEGURADORA
            cmd.Parameters.Add("@ACUERDO_COMERCIAL", SqlDbType.VarChar).Value = pACUERDO_COMERCIAL
            cmd.Parameters.Add("@IDENTITY", SqlDbType.Int).Value = ParameterDirection.Output
            sqldb_conexion.Open()
            st = cmd.ExecuteScalar()

            strReturn = st
            sqldb_conexion.Close()

            If strReturn = "0" Then
                pResult = "ERROR:" + strReturn
            Else
                If strReturn > 1 Then
                    pResult = "inserted"
                    pResult = st
                End If
                'If strReturn = "2" Then
                '    pResult = "updated"
                'End If
                '' Return True
            End If
            Return strReturn
        Catch ex As Exception
            pResult = ex.Message
            pResult = "ERROR:" + ex.Message
            Return "0"
        Finally
            If sqldb_conexion.State = ConnectionState.Open Then sqldb_conexion.Close()
        End Try
    End Function

    <WebMethod(Description:="AddLicense")>
    Public Function AddLicense(
            ByVal pCUSTOMER As String,
            ByVal pWAREHOUSE As String,
            ByVal pLOCATION As String,
            ByVal pUSER As String,
            ByVal pFECHA As Date,
            ByVal pIDENTITY As String,
            ByVal pResult As String,
            ByVal pEnvironmentName As String
                                            ) As String
        Dim sqldb_conexion As SqlConnection
        Dim sqlCmd As SqlCommand
        Dim strReturn As String

        Dim st As String
        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Catch ex As Exception
            pResult = "ERROR:" + ex.Message
            Return Nothing
        End Try


        Try
            ' Enviamos datos de licencia
            Dim cmd As New SqlCommand(DefaultSchema + "[OP_WMS_SP_INSERTAR_LICENCIA]", sqldb_conexion)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@CUSTOMER", SqlDbType.VarChar).Value = pCUSTOMER
            cmd.Parameters.Add("@WAREHOUSE", SqlDbType.VarChar).Value = pWAREHOUSE
            cmd.Parameters.Add("@LOCATION", SqlDbType.VarChar).Value = pLOCATION
            cmd.Parameters.Add("@USER", SqlDbType.VarChar).Value = pUSER
            cmd.Parameters.Add("@IDENTITY", SqlDbType.Int).Value = ParameterDirection.Output
            cmd.Parameters.Add("@FECHA", SqlDbType.DateTime2).Value = pFECHA
            sqldb_conexion.Open()
            st = cmd.ExecuteScalar()

            strReturn = st

            sqldb_conexion.Close()
            'aca en strReturn ya tengo el v

            If strReturn = "0" Then
                pResult = "ERROR:" + strReturn
                'Return False
            Else
                If strReturn > 1 Then
                    pResult = "inserted"
                    pResult = st
                End If
                'If strReturn = "2" Then
                '    pResult = "updated"
                'End If
                '' Return True
            End If
            Return strReturn
        Catch ex As Exception
            pResult = ex.Message
            pResult = "ERROR:" + ex.Message
            ' Return False
            Return "0"
        Finally
            If sqldb_conexion.State = ConnectionState.Open Then sqldb_conexion.Close()

        End Try
    End Function


    <WebMethod(Description:="AddPolizaDetail")>
    Public Function AddPolizaDetail(
            ByVal pHEADER As String,
            ByVal pLINE As String,
            ByVal pCUSTOMER As String,
            ByVal pCUSTOMER_NAME As String,
            ByVal pUSER As String,
            ByVal pSKU_DESCRIPTION As String,
            ByVal pUNIT_MEASURE As String,
            ByVal pQTY As String,
            ByVal pTOTAL As String,
            ByVal pUNIT_PRICE As String,
            ByVal pFECHA As Date,
            ByVal pResult As String,
            ByVal pEnvironmentName As String
                                    ) As String
        Dim sqldb_conexion As SqlConnection
        Dim sqlCmd As SqlCommand
        Dim strReturn As String
        Dim st As String
        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Catch ex As Exception
            pResult = "ERROR:" + ex.Message
            Return Nothing
        End Try

        Try
            ' Enviamos datos de licencia
            Dim cmd As New SqlCommand(DefaultSchema + "[OP_WMS_SP_INSERT_OP_WMS_POLIZA_DETAIL]", sqldb_conexion)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@HEADER", SqlDbType.Int).Value = pHEADER
            cmd.Parameters.Add("@LINE", SqlDbType.Int).Value = pLINE
            cmd.Parameters.Add("@CUSTOMER", SqlDbType.VarChar).Value = pCUSTOMER
            cmd.Parameters.Add("@CUSTOMER_NAME", SqlDbType.VarChar).Value = pCUSTOMER_NAME
            cmd.Parameters.Add("@USER", SqlDbType.VarChar).Value = pUSER
            cmd.Parameters.Add("@SKU_DESCRIPTION", SqlDbType.VarChar).Value = pSKU_DESCRIPTION
            cmd.Parameters.Add("@UNIT_MEASURE", SqlDbType.VarChar).Value = pUNIT_MEASURE
            cmd.Parameters.Add("@QTY", SqlDbType.Int).Value = pQTY
            cmd.Parameters.Add("@TOTAL", SqlDbType.Float).Value = pTOTAL
            cmd.Parameters.Add("@UNIT_PRICE", SqlDbType.Float).Value = pUNIT_PRICE
            cmd.Parameters.Add("@FECHA", SqlDbType.DateTime2).Value = pFECHA
            sqldb_conexion.Open()
            cmd.ExecuteNonQuery()
            sqldb_conexion.Close()
            sqldb_conexion.Open()
            st = cmd.ExecuteScalar()

            strReturn = st
            sqldb_conexion.Close()

            If strReturn = "0" Then
                pResult = "ERROR:" + strReturn
            Else
                If strReturn > 1 Then
                    pResult = "inserted"
                    pResult = st
                End If
                'If strReturn = "2" Then
                '    pResult = "updated"
                'End If
                '' Return True
            End If
            Return strReturn
        Catch ex As Exception
            pResult = ex.Message
            pResult = "ERROR:" + ex.Message
            Return "0"
        Finally
            If sqldb_conexion.State = ConnectionState.Open Then sqldb_conexion.Close()
        End Try

    End Function

    <WebMethod(Description:="AddInventory")>
    Public Function AddInventory(
                ByVal pcodeSku As String,
                ByVal pskudes As String,
                ByVal pumesure As String,
                ByVal pqty As Integer,
                ByVal ptotal As Decimal,
                ByVal puprice As Decimal,
                ByVal pcustomer As String,
                ByVal pcustomername As String,
                ByVal puser As String,
                ByVal pwh As String,
                ByVal psigno As String,
                ByVal plocation As String,
                ByVal pheader As String,
                ByVal pfecha As Date,
                ByVal pacuerdo As String,
                ByVal pRESULTADO As String,
                ByVal pResult As String,
                ByVal pEnvironmentName As String) As String

        Dim sqldb_conexion As SqlConnection
        Dim sqlCmd As SqlCommand
        Dim strReturn As String
        Dim st As String
        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Catch ex As Exception
            pResult = "ERROR:" + ex.Message
            Return Nothing
        End Try

        Try
            ' Enviamos datos de licencia
            Dim cmd As New SqlCommand(DefaultSchema + "[OP_WMS_SP_UPDATE_OR_INSERT_OP_WMS_INV_X_LICENSE]", sqldb_conexion)
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.Add("@CODE_SKU", SqlDbType.VarChar).Value = pcodeSku
            cmd.Parameters.Add("@SKU_DESCRIPTION", SqlDbType.VarChar).Value = pskudes
            cmd.Parameters.Add("@UNIT_MEASURE", SqlDbType.VarChar).Value = pumesure
            cmd.Parameters.Add("@QTY", SqlDbType.Int).Value = pqty
            cmd.Parameters.Add("@TOTAL", SqlDbType.Float).Value = ptotal
            cmd.Parameters.Add("@UNIT_PRICE", SqlDbType.Float).Value = puprice
            cmd.Parameters.Add("@CUSTOMER", SqlDbType.VarChar).Value = pcustomer
            cmd.Parameters.Add("@CUSTOMER_NAME", SqlDbType.VarChar).Value = pcustomername
            cmd.Parameters.Add("@USER", SqlDbType.VarChar).Value = puser
            cmd.Parameters.Add("@WAREHOUSE", SqlDbType.VarChar).Value = pwh
            cmd.Parameters.Add("@SIGNO", SqlDbType.VarChar).Value = psigno
            cmd.Parameters.Add("@LOCATION", SqlDbType.VarChar).Value = plocation
            cmd.Parameters.Add("@HEADER", SqlDbType.VarChar).Value = pheader
            cmd.Parameters.Add("@FECHA", SqlDbType.DateTime2).Value = pfecha
            cmd.Parameters.Add("@ACUERDO_COMERCIAL", SqlDbType.VarChar).Value = pacuerdo
            cmd.Parameters.Add("@RESULTADO", SqlDbType.VarChar).Value = ParameterDirection.Output
            sqldb_conexion.Open()
            st = cmd.ExecuteScalar().ToString() 'cmd.ExecuteNonQuery()
            sqldb_conexion.Close()
            'sqldb_conexion.Open()


            strReturn = st.ToString()
            sqldb_conexion.Close()

            If strReturn.Contains("EXITO") Then
                Return st
            End If

            ' Return "Exito"
        Catch ex As Exception
            Return st + ex.Message
            'pResult = strReturn
            'Finally
            '    If sqldb_conexion.State = ConnectionState.Open Then sqldb_conexion.Close()
        End Try
        Return st
    End Function

    <WebMethod(Description:="AddGeneralData")>
    Public Function AddGeneralData(ByVal pcustomer As String, ByVal pcustomername As String, ByVal puser As String, ByVal pwh As String, ByVal plocation As String, ByVal pseguro As String,
                ByVal pacuerdo As String, ByVal pfecha As Date, ByVal pResult As String, ByVal pEnvironmentName As String) As String

        Dim sqldb_conexion As SqlConnection
        Dim sqlCmd As SqlCommand
        Dim strReturn As String
        Dim st As String
        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Catch ex As Exception
            pResult = "ERROR:" + ex.Message
            Return Nothing
        End Try

        Try
            ' Enviamos parametros para sp general
            Dim cmd As New SqlCommand(DefaultSchema + "[OP_WMS_SP_ADD_EXTERNAL_TRANSACCION]", sqldb_conexion)
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.Add("@CLIENTE", SqlDbType.VarChar).Value = pcustomer
            cmd.Parameters.Add("@CLIENTE_NOMBRE", SqlDbType.VarChar).Value = pcustomername
            cmd.Parameters.Add("@USUARIO", SqlDbType.VarChar).Value = puser
            cmd.Parameters.Add("@BODEGA", SqlDbType.VarChar).Value = pwh
            cmd.Parameters.Add("@UBICACION", SqlDbType.VarChar).Value = plocation
            cmd.Parameters.Add("@POLIZA_SEGURO", SqlDbType.VarChar).Value = pseguro
            cmd.Parameters.Add("@ACUERDO_COMERCIAL", SqlDbType.VarChar).Value = pacuerdo
            cmd.Parameters.Add("@FECHA_OPERACION", SqlDbType.DateTime2).Value = pfecha
            cmd.Parameters.Add("@RESULTADO", SqlDbType.VarChar).Value = ParameterDirection.Output
            sqldb_conexion.Open()
            st = cmd.ExecuteScalar().ToString() 'cmd.ExecuteNonQuery()
            sqldb_conexion.Close()
            'sqldb_conexion.Open()


            strReturn = st.ToString()
            sqldb_conexion.Close()

            If strReturn.Contains("EXITO") Then
                Return st
            End If
        Catch ex As Exception
            Return st + ex.Message
        End Try
        Return st
    End Function




    <WebMethod(Description:="ResultProcessDispatchExternal")>
    Public Function ResultProcessDispatchExternal(ByVal pEnvironmentName As String, ByVal FechaDocumento As DateTime) As String

        Dim sqldb_conexion As SqlConnection
        Dim sqlCmd As SqlCommand
        Dim strReturn As String
        Dim st As String
        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Catch ex As Exception
            st = "ERROR:" + ex.Message
            Return Nothing
        End Try

        Try
            Dim cmd As New SqlCommand(DefaultSchema + "[OP_WMS_SP_PROCESS_DISPATCH_INVENTORY_EXTERNAL]", sqldb_conexion)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@DOCUMENT_DATE", SqlDbType.Date).Value = FechaDocumento.Date


            sqldb_conexion.Open()
            st = cmd.ExecuteScalar().ToString() 'cmd.ExecuteNonQuery()
            sqldb_conexion.Close()
            'sqldb_conexion.Open()


            strReturn = st.ToString()
            sqldb_conexion.Close()

            If strReturn.Contains("EXITO") Then
                Return st
            End If
        Catch ex As Exception
            Return "ERROR: " + ex.Message
        End Try
        Return st
    End Function

    <WebMethod(Description:="AddAllDataToServer")>
    Public Function ReceiveInventoryFromFile(ByVal pDATA As DataSet, ByVal pEnvironmentName As String) As String
        Dim sqldb_conexion As SqlConnection
        Dim cmd As New SqlCommand

        Dim st As String
        Dim miscDs As DataTable = New DataTable("AddAllDataToServer")

        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Catch ex As Exception
            Return "ERROR:" + ex.Message

        End Try

        Try

            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_ADD_INVENTORY_EXTERNAL]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldb_conexion

            Dim miscDa = New SqlDataAdapter(cmd)
            miscDa.Fill(miscDs)
            sqldb_conexion.Close()
            If miscDs.Rows(0)(0) > 0 Then
                Return miscDs.Rows(0)(0)
            End If
        Catch ex As Exception
            Return st + ex.Message
        End Try
        Return st
    End Function

    <WebMethod(Description:="AddAllDataToServer")>
    Public Function ReceiveInventoryFromFileExcel(ByVal pDATA As DataTable, ByVal pLOGIN As String, ByVal pCLIENT As String, ByVal pEnvironmentName As String) As String
        Dim sqldb_conexion As SqlConnection
        ' Dim cmd As new SqlCommand

        Dim st As String = ""
        Dim miscDs As DataTable = New DataTable("AddAllDataToServer")
        Dim cmd As New SqlCommand

        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Catch ex As Exception
            Return "ERROR:" + ex.Message

        End Try

        Try
            sqldb_conexion.Open()

            cmd = New SqlCommand(DefaultSchema + "[OP_WMS_CLEAN_DISPATCH_FROM_EXTERNAL]", sqldb_conexion)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.ExecuteNonQuery()

            For Each xrow In pDATA.Rows

                cmd = New SqlCommand(DefaultSchema + "[OP_WMS_DISPATCH_REVIEW_FROM_EXTERNAL]", sqldb_conexion)
                cmd.CommandType = CommandType.StoredProcedure

                cmd.Parameters.Add("@CLIENTE", SqlDbType.VarChar).Value = pCLIENT
                cmd.Parameters.Add("@SKU", SqlDbType.VarChar).Value = xrow("CODIGO")
                cmd.Parameters.Add("@SKU_NAME", SqlDbType.VarChar).Value = xrow("DESCRIPCION")
                cmd.Parameters.Add("@QTY_REQUESTED", SqlDbType.Float).Value = xrow("CANTIDAD")
                cmd.Parameters.Add("@LOGIN", SqlDbType.VarChar).Value = pLOGIN
                cmd.ExecuteNonQuery()

            Next

            sqldb_conexion.Close()


        Catch ex As Exception
            Return st + ex.Message
        End Try
        Return st
    End Function

    <WebMethod(Description:="AddDataToReviewAddExternal")>
    Public Function AddDataToReviewAddExternal(ByVal pDATA As DataTable, ByVal pLOGIN As String, ByVal pCLIENT As String, ByVal pEnvironmentName As String) As String
        Dim sqldb_conexion As SqlConnection
        ' Dim cmd As new SqlCommand

        Dim st As String = ""
        Dim miscDs As DataTable = New DataTable("AddDataToReviewAddExternal")
        Dim cmd As New SqlCommand

        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Catch ex As Exception
            Return "ERROR:" + ex.Message

        End Try

        Try
            sqldb_conexion.Open()

            For Each xrow In pDATA.Rows

                cmd = New SqlCommand(DefaultSchema + "[OP_WMS_ADD_REVIEW_FROM_EXTERNAL]", sqldb_conexion)
                cmd.CommandType = CommandType.StoredProcedure

                cmd.Parameters.Add("@CLIENTE", SqlDbType.VarChar).Value = pCLIENT
                cmd.Parameters.Add("@CODIGO", SqlDbType.VarChar).Value = xrow("CODIGO")
                cmd.Parameters.Add("@DESCRIPCION", SqlDbType.VarChar).Value = xrow("DESCRIPCION")
                cmd.Parameters.Add("@UNIDAD_MEDIDA", SqlDbType.VarChar).Value = xrow("UNIDAD DE MEDIDA")
                cmd.Parameters.Add("@QTY", SqlDbType.Float).Value = xrow("CANTIDAD")
                cmd.Parameters.Add("@PRECIO_UNITARIO", SqlDbType.Float).Value = xrow("PRECIO UNITARIO")
                cmd.Parameters.Add("@TOTAL", SqlDbType.Float).Value = xrow("COSTO TOTAL")
                cmd.ExecuteNonQuery()

            Next

            sqldb_conexion.Close()


        Catch ex As Exception
            Return st + ex.Message
        End Try
        Return st
    End Function


    <WebMethod(Description:="GetReviewDispatchForExternal")>
    Public Function GetReviewDispatchForExternal(ByVal pEnvironmentName As String) As DataTable
        Dim RESULT As String = ""
        Dim sqldb_conexion As SqlConnection
        Dim cmd As New SqlCommand

        Dim miscDs As DataTable = New DataTable("GetReviewDispatchForExternal")

        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Catch ex As Exception
            RESULT = "Error" + ex.Message
            Return Nothing
        End Try

        Try

            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_GET_DISPATCH_FROM_EXTERNAL]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldb_conexion

            Dim miscDa = New SqlDataAdapter(cmd)
            miscDa.Fill(miscDs)
            sqldb_conexion.Close()
            If miscDs.Rows.Count > 0 Then
                Return miscDs
            End If
        Catch ex As Exception
            RESULT = ex.Message
            Return Nothing
        End Try
        Return Nothing
    End Function

    <WebMethod(Description:="GetReviewDispatchForExternalUpdate")>
    Public Function GetReviewDispatchForExternalUpdate(ByVal pEnvironmentName As String) As DataTable
        Dim RESULT As String = ""
        Dim sqldb_conexion As SqlConnection
        Dim cmd As New SqlCommand

        Dim miscDs As DataTable = New DataTable("GetReviewDispatchForExternalUpdate")

        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Catch ex As Exception
            RESULT = "Error" + ex.Message
            Return Nothing
        End Try

        Try

            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_GET_DISPATCH_FROM_EXTERNAL_UPDATE]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldb_conexion

            Dim miscDa = New SqlDataAdapter(cmd)
            miscDa.Fill(miscDs)
            sqldb_conexion.Close()
            If miscDs.Rows.Count > 0 Then
                Return miscDs
            End If
        Catch ex As Exception
            RESULT = ex.Message
            Return Nothing
        End Try
        Return Nothing
    End Function

    <WebMethod(Description:="GetWarehouseForExt")>
    Public Function GetWarehouseForExt(ByVal pEnvironmentName As String) As DataTable
        Dim RESULT As String = ""
        Dim sqldb_conexion As SqlConnection
        Dim cmd As New SqlCommand

        Dim miscDs As DataTable = New DataTable("GetWarehouseForExt")

        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Catch ex As Exception
            RESULT = "Error" + ex.Message
            Return Nothing
        End Try

        Try

            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_GET_Warehouse_For_Ext]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldb_conexion

            Dim miscDa = New SqlDataAdapter(cmd)
            miscDa.Fill(miscDs)
            sqldb_conexion.Close()
            If miscDs.Rows.Count > 0 Then
                Return miscDs
            End If
        Catch ex As Exception
            RESULT = ex.Message
            Return Nothing
        End Try
        Return Nothing
    End Function


    <WebMethod(Description:="GetAvilableInsurance")>
    Public Function GetInsuranceAvilable(ByVal pPoliza As String, ByVal pUser As String, ByVal pRpoliza As Integer, ByVal pResult As String, ByVal pEnvironmentName As String) As String
        Dim sqldb_conexion As SqlConnection
        Dim sqlCmd As SqlCommand
        Dim strReturn As String
        Dim st As String
        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Catch ex As Exception
            pResult = "ERROR:" + ex.Message
            Return Nothing
        End Try

        Try
            ' Enviamos datos de licencia
            Dim cmd As New SqlCommand(DefaultSchema + "[OP_WMS_SP_UPDATE_INSURANCE_COMPANIES]", sqldb_conexion)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@POLIZA_SEGURO", SqlDbType.VarChar).Value = pPoliza
            cmd.Parameters.Add("@USER", SqlDbType.VarChar).Value = pUser
            cmd.Parameters.Add("@RPOLIZA", SqlDbType.Int).Value = ParameterDirection.Output
            sqldb_conexion.Open()
            st = cmd.ExecuteScalar().ToString()
            sqldb_conexion.Close()
            strReturn = st
            sqldb_conexion.Close()
            pResult = st
            If strReturn = "0" Then
                pResult = "ERROR:" + strReturn
            Else
                If strReturn Then
                    pResult = "inserted"
                    pResult = st
                End If
                'If strReturn = "2" Then
                '    pResult = "updated"
                'End If
                '' Return True
            End If
            Return strReturn
        Catch ex As Exception
            pResult = ex.Message
            pResult = "ERROR:" + ex.Message
            Return st
        Finally
            If sqldb_conexion.State = ConnectionState.Open Then sqldb_conexion.Close()
        End Try

    End Function


    <WebMethod(Description:="RebajaInventarioDeLicencias")>
    Public Function updateInventory(ByVal pcode As String, ByVal pqty As Integer, ByVal pcustomer As String, ByVal presultado As String, ByVal pResult As String, ByVal pEnvironmentName As String) As String
        Dim sqldb_conexion As SqlConnection
        Dim sqlCmd As SqlCommand
        Dim strReturn As String
        Dim st As String
        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Catch ex As Exception
            pResult = "ERROR:" + ex.Message
            Return Nothing
        End Try

        Try
            Dim cmd As New SqlCommand(DefaultSchema + "[OP_WMS_SP_UPDATE_INV_X_LICENSE]", sqldb_conexion)
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.Add("@CODE_SKU", SqlDbType.VarChar).Value = pcode
            cmd.Parameters.Add("@QTY", SqlDbType.Int).Value = pqty
            cmd.Parameters.Add("@CUSTOMER", SqlDbType.VarChar).Value = pcustomer
            cmd.Parameters.Add("@RESULTADO", SqlDbType.VarChar).Value = ParameterDirection.Output
            sqldb_conexion.Open()
            st = cmd.ExecuteScalar().ToString() 'cmd.ExecuteNonQuery()
            sqldb_conexion.Close()

            strReturn = st.ToString()
            sqldb_conexion.Close()

            If strReturn.Contains("EXITO") Then
                Return st
            End If

        Catch ex As Exception
            Return st + ex.Message
        End Try
        Return st
    End Function
#End Region

#Region "Carta Cupo"
    <WebMethod(Description:="Update QuotaLatter")>
    Public Function UpdateQuotaLatter(ByVal pCarta As String, ByVal pRegimen As String, ByVal pMedida As String,
                                      ByVal pFirma As String, ByVal pClave As String, positionPerson As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection
        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Catch ex As Exception
            pResult = "ERROR:" + ex.Message
            Return Nothing
        End Try
        Dim XSQL As String = "" '"exec   [alsersa].[OP_WMS_SP_ADD_SIGNATURE_QUOTA_LETTER] @GPoliza='" + pRegimen + "', @GMedida='" + pMedida + "', @GFirma='" + pFirma + "', @GCarta='" + pCarta + "'"
        XSQL = " UPDATE " + DefaultSchema + " OP_WMS_QUOTA_LETTER "
        XSQL = XSQL + " SET REGIMEN =' " + pRegimen + " ' "
        XSQL = XSQL + " ,UNIDAD_MEDIDA=' " + pMedida + " ' "
        XSQL = XSQL + " ,FIRMA=' " + pFirma + " ' "
        XSQL = XSQL + " ,CLAVE_ADUANA_ALSERSA=' " + pClave + " ' "
        XSQL = XSQL + " ,POSITION_PERSON=' " + positionPerson + " ' "
        XSQL = XSQL + " WHERE DOC_ID=' " + pCarta + " ' "
        XSQL = XSQL + " AND STATUS='SOLICITADA' "
        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "UpdateQuotaLatter")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try

        If pResult = "OK" Then
            'miscDS.Tables(0).Rows.Count = 0 Then
            ' pResult = "ERROR, No se encontraron solicitudes"
            'Return Nothing
            ' Else          '    pResult = "OK"
            Return miscDS
        End If
    End Function

    <WebMethod(Description:="Get QuotaLatter")>
    Public Function GetQuotaLatter(ByVal pStatus As String, ByVal pStatus2 As String, ByVal pStatus3 As String, ByVal pFechaInicio As Date,
                                   ByVal pFechaFinal As Date, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection
        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Catch ex As Exception
            pResult = "ERROR:" + ex.Message
            Return Nothing
        End Try

        Dim XSQL As String = ""
        XSQL = "select QL.*, ISNULL((SELECT TOP 1 L.EMAIL FROM  " + DefaultSchema + "OP_WMS_LOGINS L WHERE L.RELATED_CLIENT = QL.RELATED_CLIENT_CODE), '') AS EMAIL"
        XSQL = XSQL + " from  " + DefaultSchema + "OP_WMS_QUOTA_LETTER QL"
        XSQL = XSQL + " INNER JOIN  " + DefaultSchema + "OP_WMS_VIEW_CLIENTS ON RELATED_CLIENT_CODE = CLIENT_CODE"
        XSQL = XSQL + " where STATUS  in ('" + pStatus + "', '" + pStatus2 + "', '" + pStatus3 + "')"
        XSQL = XSQL + " AND convert(date,LAST_UPDATED) BETWEEN convert(date,'" + pFechaInicio.Date.ToString("yyyy-MM-dd") + "') AND convert(date,'" + pFechaFinal.Date.ToString("yyyy-MM-dd") + "')"
        XSQL = XSQL + " ORDER BY [STATUS] DESC"

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "GetQuotaLatter")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try

        If miscDS.Tables(0).Rows.Count = 0 Then
            pResult = "ERROR, No se encontraron solicitudes"
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function

    <WebMethod(Description:="Get QuotaLatter por Garita")>
    Public Function GetQuotaLatterGarita(ByVal pDocId As Integer, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldbConexion As SqlConnection
        Try
            sqldbConexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Catch ex As Exception
            pResult = "ERROR:" + ex.Message
            Return Nothing
        End Try

        Dim XSQL As String = ""
        XSQL = "select *"
        XSQL = XSQL + " from  " + DefaultSchema + "OP_WMS_QUOTA_LETTER"
        XSQL = XSQL + " INNER JOIN  " + DefaultSchema + "OP_WMS_VIEW_CLIENTS ON RELATED_CLIENT_CODE = CLIENT_CODE"
        XSQL = XSQL + " where DOC_ID = " + pDocId.ToString()

        Dim miscDa As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldbConexion)
        Dim miscDs As DataSet = New DataSet()
        Try
            miscDa.Fill(miscDs, "GetQuotaLatterGarita")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try

        If miscDs.Tables(0).Rows.Count = 0 Then
            pResult = "ERROR, No se encontro la carta de cupo"
            Return Nothing
        Else
            If miscDs.Tables(0).Rows(0)("STATUS") = "SOLICITADA" Then
                pResult = "ERROR, No sé a autorizado la carta cupo"
                Return Nothing
            ElseIf miscDs.Tables(0).Rows(0)("STATUS") = "EN_SITIO" Then
                pResult = "ERROR, Ya fue usada la carta cupo"
                Return Nothing
            Else
                pResult = "OK"
                Return miscDs
            End If
        End If
    End Function

    <WebMethod(Description:="Get Doc, Poliza and Num Order por Garita")>
    Public Function GetDocPolizaEnc(ByVal pDocId As Integer, ByVal pCodigoPoliza As String, ByVal pNumeroOrden As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldbConexion As SqlConnection
        Try
            sqldbConexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Catch ex As Exception
            pResult = "ERROR:" + ex.Message
            Return Nothing
        End Try

        Dim strSql As New StringBuilder(" SELECT TOP 1 *")
        strSql.Append(String.Format(" FROM {0}OP_WMS_POLIZA_HEADER", DefaultSchema))
        strSql.Append(" WHERE TIPO = 'INGRESO'")
        strSql.Append(" AND WAREHOUSE_REGIMEN = 'FISCAL'")
        If Not pDocId = 0 Then
            strSql.Append(String.Format(" AND DOC_ID = {0}", pDocId))
        ElseIf Not pCodigoPoliza = "" Then
            strSql.Append(String.Format(" AND CODIGO_POLIZA = '{0}'", pCodigoPoliza))
        ElseIf Not pNumeroOrden = "" Then
            strSql.Append(String.Format(" AND NUMERO_ORDEN = '{0}'", pNumeroOrden))
        End If

        Dim miscDa As SqlDataAdapter = New SqlDataAdapter(strSql.ToString(), sqldbConexion)
        Dim miscDs As DataSet = New DataSet()
        Try
            miscDa.Fill(miscDs, "GetDocPolizaEnc")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try

        If miscDs.Tables(0).Rows.Count = 0 Then
            pResult = "ERROR, No se encontro el documento"
            Return Nothing
        End If

        pResult = "OK"
        Return miscDs
    End Function

    <WebMethod(Description:="Get QuotaLatter por Garita")>
    Public Function GetLineasAvailable(ByVal pDocId As Integer, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldbConexion As SqlConnection
        Try
            sqldbConexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Catch ex As Exception
            pResult = "ERROR:" + ex.Message
            Return Nothing
        End Try

        Dim cmd As New SqlCommand

        cmd.Parameters.Add(New SqlParameter("@DOC_ID", SqlDbType.Int))
        cmd.Parameters("@DOC_ID").Value = pDocId
        cmd.CommandText = DefaultSchema + "[OP_WMS_GET_AVAILABLE_LINES]"
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Connection = sqldbConexion

        Dim miscDa = New SqlDataAdapter(cmd)
        Dim miscDs As DataSet = New DataSet()
        Try
            miscDa.Fill(miscDs, "GetLineasAvailable")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try

        If miscDs.Tables(0).Rows.Count = 0 Then
            pResult = "ERROR, No se encontraron registros"
            Return Nothing
        End If

        pResult = "OK"
        Return miscDs
    End Function

#End Region
#Region "Acuse Recibo"

    <WebMethod(Description:="Get AcuseRecibo")>
    Public Function GetAcuseRecibo(ByVal pFechaInicio As Date, ByVal pFechaFinal As Date,
                                   ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection
        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Catch ex As Exception
            pResult = "ERROR:" + ex.Message
            Return Nothing
        End Try

        Dim XSQL As String = ""
        XSQL = "select AC.*,  SS.*, SS.[STATUS] AS EstatusSat "
        XSQL = XSQL + " from  " + DefaultSchema + "OP_WMS_ACUSE_RECIBO AC"
        XSQL = XSQL + " LEFT JOIN  " + DefaultSchema + "OP_WMS_SAT_SERVICES SS ON DOC_ID = ACUSE_DOC_ID		"
        XSQL = XSQL + " where convert(date,AC.LAST_UPDATED) BETWEEN convert(date,'" + pFechaInicio.Date.ToString("yyyy-MM-dd") + "') AND convert(date,'" + pFechaFinal.Date.ToString("yyyy-MM-dd") + "')"
        XSQL = XSQL + " ORDER BY AC.[STATUS] DESC"

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "GetAcuseRecibo")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try

        If miscDS.Tables(0).Rows.Count = 0 Then
            pResult = "ERROR, No se encontraron acuses de recibo"
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function

#End Region

    ''' <summary>
    ''' Método para obtener las tareas de recepción pendientes.
    ''' </summary>
    ''' <param name="SerialNumber"></param>
    ''' <param name="AssignedTo"></param>
    ''' <param name="pEnvironmentName"></param>
    ''' <param name="pResult"></param>
    ''' <returns></returns>
    <WebMethod(Description:="Obtener tares de recepcion asignadas a un usuario")>
    Public Function ObtenerTareasRecepcionAsignadasUsuario(ByVal Regimen As String, ByVal SerialNumber As String, ByVal AssignedTo As String, ByVal pEnvironmentName As String, ByRef pResult As String) As DataTable
        Dim sqldbConexion As SqlConnection
        Dim miscDs As DataTable = New DataTable("TareasRecepcion")
        Dim cmd As New SqlCommand
        Try
            sqldbConexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)

            If Not SerialNumber Is Nothing OrElse Not SerialNumber = String.Empty Then
                cmd.Parameters.Add("@SERIAL_NUMBER", SqlDbType.BigInt)
                cmd.Parameters("@SERIAL_NUMBER").Direction = ParameterDirection.Input
                cmd.Parameters("@SERIAL_NUMBER").Value = SerialNumber
            End If
            If Not AssignedTo Is Nothing OrElse Not SerialNumber = String.Empty Then
                cmd.Parameters.Add("@TASK_ASSIGNEDTO", SqlDbType.VarChar)
                cmd.Parameters("@TASK_ASSIGNEDTO").Direction = ParameterDirection.Input
                cmd.Parameters("@TASK_ASSIGNEDTO").Value = AssignedTo
            End If

            cmd.Parameters.Add("@REGIMEN", SqlDbType.VarChar)
            cmd.Parameters("@REGIMEN").Direction = ParameterDirection.Input
            cmd.Parameters("@REGIMEN").Value = Regimen

            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_GET_RECEPTION_TASK]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion

            Dim miscDa As SqlDataAdapter = New SqlDataAdapter(cmd)
            miscDa.Fill(miscDs)
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        sqldbConexion.Close()
        Return miscDs
    End Function

    <WebMethod(Description:="Distribuir Tareas a Todos los Operadores")>
    Public Function DistribuirTareasATodosLosOperadores(login As String, ByVal pEnvironmentName As String) As DataTable
        Dim sqldbConexion As SqlConnection
        Dim miscDs As DataTable = New DataTable("TareasRecepcion")
        Dim cmd As New SqlCommand
        sqldbConexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        cmd.Parameters.Add(New SqlParameter("@LOGIN", SqlDbType.VarChar)).Value = login
        cmd.CommandText = DefaultSchema + "[OP_WMS_SP_RE_ASIGN_TASKS_TO_EVERYONE]"
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Connection = sqldbConexion

        Dim miscDa = New SqlDataAdapter(cmd)
        miscDa.Fill(miscDs)
        sqldbConexion.Close()
        Return miscDs
    End Function

    <WebMethod(Description:="Distribuir Tareas a Todos los Operadores Sin Tareas")>
    Public Function DistribuirTareasATodosLosOperadoresSinTareas(login As String, ByRef result As String, pEnvironmentName As String) As DataTable
        Try
            Dim sqldbConexion As SqlConnection
            Dim miscDs As DataTable = New DataTable("TareasRecepcion")
            Dim cmd As New SqlCommand
            sqldbConexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)

            cmd.Parameters.Add(New SqlParameter("@LOGIN", SqlDbType.VarChar)).Value = login
            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_RE_ASIGN_TASKS_TO_EVERYONE_WITHOUT_TASKS]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion

            Dim miscDa = New SqlDataAdapter(cmd)
            miscDa.Fill(miscDs)
            sqldbConexion.Close()
            Return miscDs
        Catch ex As Exception
            result = ex.Message
            Return Nothing
        End Try
    End Function

    <WebMethod(Description:="Validar si la licencia tiene inventario.")>
    Public Function LicenceHasInventory(ByVal IdLicence As Integer, ByVal pEnvironmentName As String) As Boolean
        Dim sqldbConexion As SqlConnection
        Dim miscDs As DataTable = New DataTable("LicenceHasInventory")
        Dim cmd As New SqlCommand
        sqldbConexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        cmd.Parameters.Add(New SqlParameter("@LICENCE_ID", SqlDbType.Int))
        cmd.Parameters("@LICENCE_ID").Value = IdLicence
        cmd.CommandText = DefaultSchema + "[OP_WMS_SP_LICENCE_HAS_INVENTORY]"
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Connection = sqldbConexion

        Dim miscDa = New SqlDataAdapter(cmd)
        miscDa.Fill(miscDs)
        If miscDs.Rows.Count > 0 Then
            Return IIf(miscDs.Rows(0)(0).ToString() = "0", False, True)
        End If
        sqldbConexion.Close()
        Return True
    End Function

    <WebMethod(Description:="Autoriza el envio de una recepcion a ERP.")>
    Public Function AuthorizeErpReceptionDocument(ByVal ErpReceptionDocumentId As Integer, ByVal LastUpdateBy As String, ByVal pEnvironmentName As String, ByRef pResult As String) As Boolean
        Try
            Dim sqldbConexion As SqlConnection
            Dim miscDs As DataTable = New DataTable("Autorizacion Recepcion")
            Dim cmd As New SqlCommand
            sqldbConexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)

            cmd.Parameters.Add(New SqlParameter("@ERP_RECEPTION_DOCUMENT_HEADER_ID", SqlDbType.Int))
            cmd.Parameters("@ERP_RECEPTION_DOCUMENT_HEADER_ID").Value = ErpReceptionDocumentId

            cmd.Parameters.Add(New SqlParameter("@LAST_UPDATE_BY", SqlDbType.VarChar))
            cmd.Parameters("@LAST_UPDATE_BY").Value = LastUpdateBy

            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_AUTHORIZE_ERP_RECEPTION_DOCUMENT]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion

            Dim miscDa = New SqlDataAdapter(cmd)
            miscDa.Fill(miscDs)
            If miscDs.Rows.Count > 0 Then
                pResult = miscDs.Rows(0)(1).ToString()
                Return IIf(miscDs.Rows(0)(1).ToString() = "Proceso Exitoso", True, False)
            End If
            sqldbConexion.Close()
            Return True
        Catch ex As Exception
            pResult = ex.Message
            Return False
        End Try
    End Function


    <WebMethod(Description:="Obtiene la etiqueta de recepción")>
    Public Function GetReceptionTag(taskId As Integer, login As String, pEnvironmentName As String, ByRef pResult As String) As DataTable
        Dim sqldbConexion As SqlConnection
        sqldbConexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Try
            Dim miscDs = New DataTable("EtiquetaRecepcion")
            Dim cmd As New SqlCommand

            cmd.Parameters.Add(New SqlParameter("@TASK_ID", SqlDbType.Int))
            cmd.Parameters("@TASK_ID").Value = taskId

            cmd.Parameters.Add(New SqlParameter("@LOGIN", SqlDbType.VarChar, 25))
            cmd.Parameters("@LOGIN").Value = login

            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_GET_RECEPTION_TAG]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion

            Dim miscDa = New SqlDataAdapter(cmd)
            miscDa.Fill(miscDs)

            Return miscDs
        Catch ex As Exception
            pResult = ex.Message
            Return Nothing
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try
    End Function
    <WebMethod(Description:="Obtiene la etiqueta de picking")>
    Public Function GetPickingTag(wavePickingId As Integer, login As String, pEnvironmentName As String, ByRef pResult As String) As DataTable
        Dim sqldbConexion As SqlConnection
        sqldbConexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Try
            Dim miscDs = New DataTable("EtiquetaPicking")
            Dim cmd As New SqlCommand

            cmd.Parameters.Add(New SqlParameter("@WAVE_PICKING_ID", SqlDbType.Int))
            cmd.Parameters("@WAVE_PICKING_ID").Value = wavePickingId

            cmd.Parameters.Add(New SqlParameter("@LOGIN", SqlDbType.VarChar, 25))
            cmd.Parameters("@LOGIN").Value = login

            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_GET_PICKING_TAG]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion

            Dim miscDa = New SqlDataAdapter(cmd)
            miscDa.Fill(miscDs)

            Return miscDs
        Catch ex As Exception
            pResult = ex.Message
            Return Nothing
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try
    End Function

    <WebMethod(Description:="Obtiene la etiqueta de picking")>
    Public Function GetLabel(labelId As Integer, pEnvironmentName As String, ByRef pResult As String) As DataTable
        Dim sqldbConexion As SqlConnection
        sqldbConexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Try
            Dim miscDs = New DataTable("EtiquetaPicking")
            Dim cmd As New SqlCommand

            cmd.Parameters.Add(New SqlParameter("@LABEL_ID", SqlDbType.Int))
            cmd.Parameters("@LABEL_ID").Value = labelId


            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_GET_LABEL]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion

            Dim miscDa = New SqlDataAdapter(cmd)
            miscDa.Fill(miscDs)

            Return miscDs
        Catch ex As Exception
            pResult = ex.Message
            Return Nothing
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try
    End Function

    <WebMethod(Description:="Autoriza el envio de un picking a ERP.")>
    Public Function AuthorizeErpPickingDocument(ByVal ErpPickingDocumentId As Integer, ByVal LastUpdateBy As String, ByVal pEnvironmentName As String, ByRef pResult As String) As Boolean
        Try
            Dim sqldbConexion As SqlConnection
            Dim miscDs As DataTable = New DataTable("Autorizacion Picking")
            Dim cmd As New SqlCommand
            sqldbConexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)

            cmd.Parameters.Add(New SqlParameter("@PICKING_DEMAND_HEADER_ID", SqlDbType.Int))
            cmd.Parameters("@PICKING_DEMAND_HEADER_ID").Value = ErpPickingDocumentId

            cmd.Parameters.Add(New SqlParameter("@LAST_UPDATE_BY", SqlDbType.VarChar))
            cmd.Parameters("@LAST_UPDATE_BY").Value = LastUpdateBy

            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_AUTHORIZE_ERP_PICKING_DOCUMENT]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion

            Dim miscDa = New SqlDataAdapter(cmd)
            miscDa.Fill(miscDs)
            If miscDs.Rows.Count > 0 Then
                pResult = miscDs.Rows(0)(1).ToString()
                Return IIf(miscDs.Rows(0)(1).ToString() = "Proceso Exitoso", True, False)
            End If
            sqldbConexion.Close()
            Return True
        Catch ex As Exception
            pResult = ex.Message
            Return False
        End Try
    End Function

#Region "Picking y Recepcion"

    <WebMethod(Description:="Obtiene el detalle del Picking")>
    Public Function GetTaskDetailForPicking(wavePickingId As Integer, login As String, pEnvironmentName As String, ByRef pResult As String) As DataTable
        Try
            Dim sqldbConexion As SqlConnection
            Dim miscDs As DataTable = New DataTable("GetTaskDetailForPicking")
            Dim cmd As New SqlCommand
            sqldbConexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)

            cmd.Parameters.Add(New SqlParameter("@WAVE_PICKING_ID ", SqlDbType.Int))
            cmd.Parameters("@WAVE_PICKING_ID ").Value = wavePickingId
            cmd.Parameters.Add(New SqlParameter("@LOGIN ", SqlDbType.VarChar)).Value = login

            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_GET_TASK_DETAIL_FOR_PICKING]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion

            Dim miscDa = New SqlDataAdapter(cmd)
            miscDa.Fill(miscDs)
            sqldbConexion.Close()
            Return miscDs
        Catch ex As Exception
            pResult = ex.Message
            Return Nothing
        End Try
    End Function

    <WebMethod(Description:="Obtiene el detalle de la recepcion")>
    Public Function GetTaskDetailForReception(serialNUmber As Integer, pEnvironmentName As String, ByRef pResult As String) As DataTable
        Try
            Dim sqldbConexion As SqlConnection
            Dim miscDs As DataTable = New DataTable("GetTaskDetailForReception")
            Dim cmd As New SqlCommand
            sqldbConexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)

            cmd.Parameters.Add(New SqlParameter("@SERIAL_NUMBER", SqlDbType.Int))
            cmd.Parameters("@SERIAL_NUMBER").Value = serialNUmber

            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_GET_TASK_DETAIL_FOR_RECEPTION]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion

            Dim miscDa = New SqlDataAdapter(cmd)
            miscDa.Fill(miscDs)
            sqldbConexion.Close()
            Return miscDs
        Catch ex As Exception
            pResult = ex.Message
            Return Nothing
        End Try
    End Function

#End Region


    <WebMethod(Description:="Obtiene el detalle del Picking")>
    Public Function GetTaskDetailForRealloc(wavePickingId As Integer, login As String, pEnvironmentName As String, ByRef pResult As String) As DataTable
        Try
            Dim sqldbConexion As SqlConnection
            Dim miscDs As DataTable = New DataTable("GetTaskDetailForPicking")
            Dim cmd As New SqlCommand
            sqldbConexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)

            cmd.Parameters.Add(New SqlParameter("@WAVE_PICKING_ID ", SqlDbType.Int))
            cmd.Parameters("@WAVE_PICKING_ID ").Value = wavePickingId
            cmd.Parameters.Add(New SqlParameter("@LOGIN ", SqlDbType.VarChar)).Value = login

            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_GET_TASK_DETAIL_FOR_REALLOC]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion

            Dim miscDa = New SqlDataAdapter(cmd)
            miscDa.Fill(miscDs)
            sqldbConexion.Close()
            Return miscDs
        Catch ex As Exception
            pResult = ex.Message
            Return Nothing
        End Try
    End Function

    <WebMethod(Description:="Obtiene el detalle de un coteo")>
    Public Function GetTaskDetailForCount(taskId As Integer, login As String, pEnvironmentName As String, ByRef pResult As String) As DataTable
        Try
            Dim sqldbConexion As SqlConnection
            Dim miscDs As DataTable = New DataTable("GetTaskDetailForCount")
            Dim cmd As New SqlCommand
            sqldbConexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)

            cmd.Parameters.Add(New SqlParameter("@TASK_ID", SqlDbType.Int))
            cmd.Parameters("@TASK_ID").Value = taskId
            cmd.Parameters.Add(New SqlParameter("@LOGIN", SqlDbType.VarChar)).Value = login

            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_GET_TASK_DETAIL_FOR_COUNT]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion

            Dim miscDa = New SqlDataAdapter(cmd)
            miscDa.Fill(miscDs)
            sqldbConexion.Close()
            Return miscDs
        Catch ex As Exception
            pResult = ex.Message
            Return Nothing
        End Try
    End Function


    <WebMethod(Description:="Modifica el operador de un conteo")>
    Public Function UpdateAssignedOperatorToCountDetail(ByVal physicalCountDetailId As Integer, ByVal assignedTo As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean
        Dim sqldbConexion As SqlConnection
        Dim miscDs = New DataTable("Result")
        Dim cmd As New SqlCommand
        sqldbConexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        cmd.Parameters.Add(New SqlParameter("@PHYSICAL_COUNT_DETAIL_ID", SqlDbType.Int))
        cmd.Parameters("@PHYSICAL_COUNT_DETAIL_ID").Value = physicalCountDetailId

        cmd.Parameters.Add(New SqlParameter("@ASSIGNED_TO", SqlDbType.VarChar))
        cmd.Parameters("@ASSIGNED_TO").Value = assignedTo


        cmd.CommandText = DefaultSchema + "[OP_WMS_SP_UPDATE_ASSIGNED_OPERATOR_TO_COUNT_DETAIL]"
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Connection = sqldbConexion

        Dim miscDa = New SqlDataAdapter(cmd)
        miscDa.Fill(miscDs)

        If miscDs.Rows.Count > 0 Then
            pResult = miscDs.Rows(0)(0).ToString()
            Return IIf(miscDs.Rows(0)(0).ToString() = "OK", True, False)
        End If
        sqldbConexion.Close()
        Return True

    End Function

    <WebMethod(Description:="Obtiene los operadores relacionados al login por en cd y bodegas")>
    Public Function GetOperatorAssignedToDistributionCenterByUser(login As String, pEnvironmentName As String, ByRef pResult As String) As DataTable
        Try
            Dim sqldbConexion As SqlConnection
            Dim miscDs As New DataTable("GetOperatorAssignedToDistributionCenterByUser")
            Dim cmd As New SqlCommand
            sqldbConexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)

            cmd.Parameters.Add(New SqlParameter("@LOGIN", SqlDbType.VarChar)).Value = login

            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_GET_OPERATORS_ASSIGNED_TO_DISTRIBUTION_CENTER_BY_USER]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion

            Dim miscDa = New SqlDataAdapter(cmd)
            miscDa.Fill(miscDs)
            sqldbConexion.Close()
            pResult = "OK"
            Return miscDs
        Catch ex As Exception
            pResult = ex.Message
            Return Nothing
        End Try
    End Function

    <WebMethod(Description:="Obtiene los operadores para grafica de administrador de tareas")>
    Public Function GetOperatorsGraphicsTask(plstUsers As String, plstTasksTypes As String, pSinceDate As Date, pToDate As Date, login As String, ByRef pResult As String, pEnvironmentName As String) As DataTable
        Try
            Dim sqldbConexion As SqlConnection
            Dim miscDs As New DataTable("GetOperatorsGraphicsTask")
            Dim cmd As New SqlCommand
            sqldbConexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)

            pSinceDate = pSinceDate + (New TimeSpan(0, 0, 0))
            pToDate = pToDate + (New TimeSpan(23, 59, 0))

            cmd.Parameters.Add(New SqlParameter("@START_DATETIME", SqlDbType.DateTime))
            cmd.Parameters("@START_DATETIME").Value = pSinceDate
            cmd.Parameters.Add(New SqlParameter("@END_DATETIME", SqlDbType.DateTime))
            cmd.Parameters("@END_DATETIME").Value = pToDate
            cmd.Parameters.Add(New SqlParameter("@USERS", SqlDbType.VarChar))
            cmd.Parameters("@USERS").Value = plstUsers
            cmd.Parameters.Add(New SqlParameter("@TYPES", SqlDbType.VarChar))
            cmd.Parameters("@TYPES").Value = plstTasksTypes
            cmd.Parameters.Add(New SqlParameter("@LOGIN", SqlDbType.VarChar))
            cmd.Parameters("@LOGIN").Value = login

            cmd.CommandText = DefaultSchema + "[OP_WMS_GET_GET_OPERATORS_GRAPHICS_TASK]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion

            Dim miscDa = New SqlDataAdapter(cmd)
            miscDa.Fill(miscDs)
            sqldbConexion.Close()
            Return miscDs
        Catch ex As Exception
            pResult = ex.Message
            Return Nothing
        End Try
    End Function

    <WebMethod(Description:="Obtiene los operadores para grafica de administrador de tareas")>
    Public Function GetTaskPending(wavePickingId As Integer, login As String, ByRef pResult As String, pEnvironmentName As String) As DataTable
        Try

            Dim sqldbConexion As SqlConnection
            Dim miscDs As New DataTable("GetTaskPending")
            Dim cmd As New SqlCommand
            sqldbConexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)

            cmd.Parameters.Add(New SqlParameter("@WAVE_PICKING_ID", SqlDbType.Int)).Value = wavePickingId
            cmd.Parameters.Add(New SqlParameter("@LOGIN", SqlDbType.VarChar)).Value = login

            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_GET_TASK_PENDING]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion

            Dim miscDa = New SqlDataAdapter(cmd)
            miscDa.Fill(miscDs)
            sqldbConexion.Close()
            Return miscDs
        Catch ex As Exception
            pResult = ex.Message
            Return Nothing
        End Try
    End Function

    <WebMethod(Description:="Obtiene la ubicacion")>
    Public Function GetLocation(location As String, ByRef pResult As String, pEnvironmentName As String) As DataTable
        Try

            Dim sqldbConexion As SqlConnection
            Dim miscDs As New DataTable("GetLocation")
            Dim cmd As New SqlCommand
            sqldbConexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)

            cmd.Parameters.Add(New SqlParameter("@LOCATION", SqlDbType.VarChar)).Value = location

            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_GET_LOCATION]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion

            Dim miscDa = New SqlDataAdapter(cmd)
            miscDa.Fill(miscDs)
            sqldbConexion.Close()
            Return miscDs
        Catch ex As Exception
            pResult = ex.Message
            Return Nothing
        End Try
    End Function

    <WebMethod(Description:="Obtiene el material")>
    Public Function GetMaterial(codeMaterial As String, ByRef pResult As String, pEnvironmentName As String) As DataTable
        Try

            Dim sqldbConexion As SqlConnection
            Dim miscDs As New DataTable("GetMaterial")
            Dim cmd As New SqlCommand
            sqldbConexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)

            cmd.Parameters.Add(New SqlParameter("@CODE_MATERIAL", SqlDbType.VarChar)).Value = codeMaterial

            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_GET_MATERIAL]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion

            Dim miscDa = New SqlDataAdapter(cmd)
            miscDa.Fill(miscDs)
            sqldbConexion.Close()
            Return miscDs
        Catch ex As Exception
            pResult = ex.Message
            Return Nothing
        End Try
    End Function

    <WebMethod(Description:="Obtiene los operadores relacionados al login por en cd y bodegas que pueden reubicar")>
    Public Function GetCanReallocOperatorAssignedToDistributionCenterByUser(login As String, pEnvironmentName As String, ByRef pResult As String) As DataTable
        Try
            Dim sqldbConexion As SqlConnection
            Dim miscDs As New DataTable("GetCanReallocOperatorAssignedToDistributionCenterByUser")
            Dim cmd As New SqlCommand
            sqldbConexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)

            cmd.Parameters.Add(New SqlParameter("@LOGIN", SqlDbType.VarChar)).Value = login

            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_GET_CAN_REALLOCATE_OPERATORS_ASSIGNED_TO_DISTRIBUTION_CENTER_BY_USER]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion

            Dim miscDa = New SqlDataAdapter(cmd)
            miscDa.Fill(miscDs)
            sqldbConexion.Close()
            pResult = "OK"
            Return miscDs
        Catch ex As Exception
            pResult = ex.Message
            Return Nothing
        End Try
    End Function

    <WebMethod(Description:="Valida si puede trabajar la tarea.")>
    Public Function ValidateTaskStatus(login As String, serialNumber As Integer, taskId As Integer, wavePickingId As Integer, materialId As String, taskType As String, pEnvironmentName As String, ByRef pResult As String) As DataTable
        Try
            Dim sqldbConexion As SqlConnection
            Dim miscDs As New DataTable("ValidateTaskStatus")
            Dim cmd As New SqlCommand
            sqldbConexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)

            cmd.Parameters.Add(New SqlParameter("@LOGIN", SqlDbType.VarChar)).Value = login
            cmd.Parameters.Add(New SqlParameter("@SERIAL_NUMBER", SqlDbType.Int)).Value = serialNumber
            cmd.Parameters.Add(New SqlParameter("@TASK_ID", SqlDbType.Int)).Value = taskId
            cmd.Parameters.Add(New SqlParameter("@WAVE_PICKING_ID", SqlDbType.Int)).Value = wavePickingId
            cmd.Parameters.Add(New SqlParameter("@MATERIAL_ID", SqlDbType.VarChar)).Value = materialId
            cmd.Parameters.Add(New SqlParameter("@TASK_TYPE", SqlDbType.VarChar)).Value = taskType

            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_VALIDATE_TASK_STATUS]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion

            Dim miscDa = New SqlDataAdapter(cmd)
            miscDa.Fill(miscDs)
            sqldbConexion.Close()
            pResult = "OK"
            Return miscDs
        Catch ex As Exception
            pResult = ex.Message
            Return Nothing
        End Try
    End Function

    <WebMethod(Description:="Valida el estado de los materiales de la licencia")>
    Public Function ValidateStatusInMaterialsLicense(license As Integer, pEnvironmentName As String, ByRef pResult As String) As DataTable
        Try
            Dim sqldbConexion As SqlConnection
            Dim miscDs As New DataTable("ValidateStatusInMaterialsLicense")
            Dim cmd As New SqlCommand
            sqldbConexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)

            cmd.Parameters.Add(New SqlParameter("@LICENSE", SqlDbType.VarChar)).Value = license

            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_VALIDATE_STATUS_IN_MATERIALS_LICENSE]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion

            Dim miscDa = New SqlDataAdapter(cmd)
            miscDa.Fill(miscDs)
            sqldbConexion.Close()
            pResult = "OK"
            Return miscDs
        Catch ex As Exception
            pResult = ex.Message
            Return Nothing
        End Try
    End Function

    <WebMethod(Description:="Obtiene el proveedor por documento")>
    Public Function GetSupplierByDocument(taskId As Integer, pEnvironmentName As String, ByRef pResult As String) As DataTable
        Dim sqldbConexion As SqlConnection
        sqldbConexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Try

            Dim miscDs As New DataTable("GetSupplierByDocument")
            Dim cmd As New SqlCommand


            cmd.Parameters.Add(New SqlParameter("@TASK_ID", SqlDbType.Int)).Value = taskId
            cmd.CommandText = $"{DefaultSchema}[OP_WMS_GET_SUPPLIER_BY_DOCUMENT]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion

            Dim miscDa = New SqlDataAdapter(cmd)
            miscDa.Fill(miscDs)
            pResult = "OK"
            Return miscDs
        Catch ex As Exception
            pResult = ex.Message
            Return Nothing
        Finally
            sqldbConexion.Close()
        End Try
    End Function

    <WebMethod(Description:="Obtiene el detalle de la tarea de recepcion por devolucion de factura")>
    Public Function ObtenerDetalleDeRecepcionPorDevolucionPorTarea(taskId As Integer, pEnvironmentName As String, ByRef pResult As String) As DataSet
        Dim sqldbConexion As SqlConnection
        sqldbConexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Try

            Dim miscDs As New DataSet
            Dim cmd As New SqlCommand

            cmd.Parameters.Add(New SqlParameter("@TASK_ID", SqlDbType.Int)).Value = taskId
            cmd.CommandText = $"{DefaultSchema}[OP_WMS_SP_GET_RECEPTION_RETURN_BY_TASK]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion

            Dim miscDa = New SqlDataAdapter(cmd)
            miscDa.Fill(miscDs)
            pResult = "OK"
            Return miscDs
        Catch ex As Exception
            pResult = ex.Message
            Return Nothing
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try
    End Function


    <WebMethod(Description:="Obtiene el detalle de la tarea de recepcion por devolucion de factura")>
    Public Function ObtenerTipoDeRecepcion(taskId As Integer, pEnvironmentName As String, ByRef pResult As String) As String
        Dim sqldbConexion As SqlConnection
        sqldbConexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Try
            Dim miscDs As New DataTable("ObtenerTipoDeRecepcion")
            Dim cmd As New SqlCommand

            cmd.Parameters.Add("@TASK_ID", SqlDbType.VarChar)
            cmd.Parameters("@TASK_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@TASK_ID").Value = taskId

            cmd.Parameters.Add("@TYPE", SqlDbType.VarChar, 50)
            cmd.Parameters("@TYPE").Direction = ParameterDirection.Output
            cmd.Parameters("@TYPE").Value = pResult

            cmd.CommandText = $"{DefaultSchema}[OP_WMS_SP_GET_RECEPTION_TYPE]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion

            Dim miscDa = New SqlDataAdapter(cmd)
            miscDa.Fill(miscDs)

            pResult = miscDs.Rows(0)(0).ToString()
            Return pResult
        Catch ex As Exception
            pResult = ex.Message
            Return pResult
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try
    End Function


    <WebMethod(Description:="Obtiene el detalle de la tarea de recepcion por devolucion de factura")>
    Public Function ObtenerParametros(grupoParametro As String, idParametro As String, pEnvironmentName As String) As DataSet
        Dim sqldbConexion As SqlConnection
        sqldbConexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Try
            Dim miscDs As New DataSet("ObtenerParametros")
            Dim cmd As New SqlCommand

            cmd.Parameters.Add("@GROUP_ID", SqlDbType.VarChar)
            cmd.Parameters("@GROUP_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@GROUP_ID").Value = grupoParametro

            cmd.Parameters.Add("@PARAMETER_ID", SqlDbType.VarChar, 50)
            cmd.Parameters("@PARAMETER_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@PARAMETER_ID").Value = idParametro

            cmd.CommandText = $"{DefaultSchema}[OP_WMS_SP_GET_PARAMETER]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion

            Dim miscDa = New SqlDataAdapter(cmd)
            miscDa.Fill(miscDs)

            Return miscDs
        Catch ex As Exception
            Return Nothing
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try
    End Function

    <WebMethod(Description:="Valida una etiqueta")>
    Public Function ValidarEtiqueta(labelId As Integer, pEnvironmentName As String, ByRef pResult As String) As DataTable
        Dim sqldbConexion As SqlConnection
        sqldbConexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Try
            Dim miscDs As New DataTable("ValidaUnaEtiqueta")
            Dim cmd As New SqlCommand

            cmd.Parameters.Add("@LABEL_ID", SqlDbType.VarChar).Value = labelId

            cmd.CommandText = $"{DefaultSchema}[OP_WMS_SP_VALIDATE_LABEL]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion

            Dim miscDa = New SqlDataAdapter(cmd)
            miscDa.Fill(miscDs)
            If miscDs.Rows.Count > 0 Then
                pResult = "OK"
            Else
                pResult = "No existe etiqueta"
            End If

            Return miscDs
        Catch ex As Exception
            pResult = ex.Message
            Return Nothing
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try
    End Function

    <WebMethod(Description:="Obtener Informacion de Picking No Inmediato")>
    Public Function ObtenerInformacionPickingNoInmediato(olaPicking As Integer, pEnvironmentName As String, ByRef pResult As String) As DataTable
        Dim connection As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Try
            Dim dataTable As New DataTable("ObtenerInformacionPickingNoInmediato")
            Dim command As New SqlCommand

            command.Parameters.Add("@WAVE_PICKING_ID", SqlDbType.VarChar).Value = olaPicking

            command.CommandText = $"{DefaultSchema}[OP_WMS_GET_INFO_OF_NO_INMEDIATE_PICKING]"
            command.CommandType = CommandType.StoredProcedure
            command.Connection = connection

            Dim adapter = New SqlDataAdapter(command)
            adapter.Fill(dataTable)
            Return dataTable
        Catch ex As Exception
            pResult = ex.Message
            Return Nothing
        Finally
            connection.Close()
            connection.Dispose()
        End Try
    End Function

    <WebMethod(Description:="Obtiene el valor para mostrar al imprimir la licencia(proyecto o código de cliente) según licencia")>
    Public Function ObtenerValorProyectoEnBaseALicencia(licenseId As Integer, environmentName As String) As String
        Dim connection As SqlConnection = New SqlConnection(AppSettings(environmentName).ToString)
        Try
            Dim dataTable As New DataTable("ObtenerValorProyectoEnBaseALicencia")
            Dim command As New SqlCommand

            command.Parameters.Add("@LICENSE_ID", SqlDbType.Int).Value = licenseId

            command.CommandText = $"{DefaultSchema}[OP_WMS_SP_GET_PROJECT_VALUE_BASED_ON_LICENSE] "
            command.CommandType = CommandType.StoredProcedure
            command.Connection = connection

            Dim adapter = New SqlDataAdapter(command)
            adapter.Fill(dataTable)

            Return dataTable.Rows(0)("PROJECT").ToString
        Catch ex As Exception
            Return Nothing
        Finally
            connection.Close()
            connection.Dispose()
        End Try
    End Function

    <WebMethod(Description:="...")>
    Public Function GetTaskByLocation(ByVal loginId As String, ByVal regimen As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim connection As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim typeTask As String = "TAREA_PICKING "

        Try
            Dim dataSet As New DataSet
            Dim command As New SqlCommand

            Select Case regimen
                Case "REUBICACION_POR_REABASTECIMIENTO"
                    typeTask = "TAREA_REUBICACION"
            End Select

            command.Parameters.Add("@LOGIN_ID", SqlDbType.VarChar, 25).Value = loginId
            command.Parameters.Add("@TASK_TYPE", SqlDbType.VarChar, 25).Value = typeTask

            command.CommandText = $"{DefaultSchema}[OP_WMS_SP_GET_LOCATION_TASK_BY_LOGIN]"
            command.CommandType = CommandType.StoredProcedure
            command.Connection = connection

            Dim adapter = New SqlDataAdapter(command)
            adapter.Fill(dataSet, "LOCATION")


            If dataSet.Tables("LOCATION").Rows.Count <= 0 Then
                pResult = "ERROR, No hay tareas para : " + loginId
                Return Nothing
            End If

            command.CommandText = $"{DefaultSchema}[OP_WMS_SP_GET_MATERIAL_TASK_BY_LOGIN]"
            command.CommandType = CommandType.StoredProcedure
            command.Connection = connection

            adapter.Fill(dataSet, "MATERIAL")


            If dataSet.Tables("MATERIAL").Rows.Count <= 0 Then
                pResult = "ERROR(1), No hay tareas (DET) para : " + loginId
                Return Nothing
            End If

            command.CommandText = $"{DefaultSchema}[OP_WMS_SP_GET_TASK_BY_LOGIN]"
            command.CommandType = CommandType.StoredProcedure
            command.Connection = connection
            adapter.Fill(dataSet, "TASK")

            If dataSet.Tables("TASK").Rows.Count <= 0 Then
                pResult = "ERROR(2), No hay tareas (DET) para : " + loginId
                Return Nothing
            End If

            Dim parentColumns As DataColumn() = Nothing
            Dim ChildColumns As DataColumn() = Nothing

            dataSet.Relations.Add("LOCATION_X_MATERIAL", dataSet.Tables("LOCATION").Columns("LOCATION_SPOT_SOURCE"), dataSet.Tables("MATERIAL").Columns("LOCATION_SPOT_SOURCE"), False)

            parentColumns = New DataColumn() {dataSet.Tables("MATERIAL").Columns("LOCATION_SPOT_SOURCE"), dataSet.Tables("MATERIAL").Columns("MATERIAL_ID")}
            ChildColumns = New DataColumn() {dataSet.Tables("TASK").Columns("LOCATION_SPOT_SOURCE"), dataSet.Tables("TASK").Columns("MATERIAL_ID")}

            dataSet.Relations.Add("MATERIAL_X_TASK", parentColumns, ChildColumns, False)

            pResult = "OK"
            Return dataSet
        Catch ex As Exception
            pResult = ex.Message
            Return Nothing
        Finally
            connection.Close()
            connection.Dispose()
        End Try


    End Function


    <WebMethod(Description:="Obtener Listado Consultas Dinamicas")>
    Public Function ObtenerListadoConsultasDinamicas(login As String, environmentName As String) As DataTable

        Dim connection As SqlConnection = New SqlConnection(AppSettings(environmentName).ToString)
        Try
            Dim dataTable As New DataTable("ObtenerListadoConsultasDinamicas")
            Dim command As New SqlCommand

            command.Parameters.Add("@LOGIN", SqlDbType.VarChar).Value = login

            command.CommandText = $"{DefaultSchema}[OP_WMS_SP_GET_QUERY_LIST]"
            command.CommandType = CommandType.StoredProcedure
            command.Connection = connection

            Dim adapter = New SqlDataAdapter(command)
            adapter.Fill(dataTable)

            Return dataTable
        Catch ex As Exception
            Return Nothing
        Finally
            connection.Close()
            connection.Dispose()
        End Try
    End Function


    <WebMethod(Description:="Obtener Consulta Seleccionada")>
    Public Function ObtenerConsultaSeleccionada(ByVal idConsulta As Integer, ByVal sufijo As String, login As String, environmentName As String, startDate As date, endDate As Date) As DataTable
        Dim connection As SqlConnection = New SqlConnection(AppSettings(environmentName).ToString)
        Try
            Dim dataTable As New DataTable("ResultadoConsulta")
            Dim command As New SqlCommand

            command.Parameters.Add("@QUERY_LIST_ID", SqlDbType.Int).Value = idConsulta
            command.Parameters.Add("@WHERE", SqlDbType.VarChar).Value = sufijo
            command.Parameters.Add("@LOGIN", SqlDbType.VarChar).Value = login
            command.Parameters.Add("@START_DATE", SqlDbType.date).Value = startDate
            command.Parameters.Add("@END_DATE", SqlDbType.Date).Value = endDate

            command.CommandText = $"{DefaultSchema}[OP_WMS_SP_EXECUTE_QUERY_FROM_QUERY_LIST]"
            command.CommandType = CommandType.StoredProcedure
            command.Connection = connection

            Dim adapter = New SqlDataAdapter(command)
            adapter.Fill(dataTable)

            Return dataTable
        Catch ex As Exception
            Return Nothing
        Finally
            connection.Close()
            connection.Dispose()
        End Try
    End Function

    <WebMethod(Description:="Inserta o actualiza el grid layout del grid query list")>
    Public Function GuardarElLayoutDeLaVistaDeQueryList(ByVal idQueryList As Integer, ByVal loginId As String, layoutxml As String, environmentName As String) As DataTable
        Dim connection As SqlConnection = New SqlConnection(AppSettings(environmentName).ToString)
        Try
            Dim dataTable As New DataTable("GuardarElLayoutDeLaVistaDeQueryList")
            Dim command As New SqlCommand

            command.Parameters.Add("@QUERY_LIST_ID", SqlDbType.Int).Value = idQueryList
            command.Parameters.Add("@LOGIN_ID", SqlDbType.VarChar).Value = loginId
            command.Parameters.Add("@LAYOUT_XML", SqlDbType.Xml).Value = layoutxml

            command.CommandText = $"{DefaultSchema}[OP_WMS_INSERT_OR_UPDATE_QUERY_LIST_BY_GRIDS_LAYOUT]"
            command.CommandType = CommandType.StoredProcedure
            command.Connection = connection

            Dim adapter = New SqlDataAdapter(command)
            adapter.Fill(dataTable)

            Return dataTable
        Catch ex As Exception
            Return Nothing
        Finally
            connection.Close()
            connection.Dispose()
        End Try
    End Function

    <WebMethod(Description:="obtener el grid layout del grid query list")>
    Public Function ObtenerLayoutDeLaVistaDeQueryList(ByVal idQueryList As Integer, ByVal loginId As String, environmentName As String) As DataTable
        Dim connection As SqlConnection = New SqlConnection(AppSettings(environmentName).ToString)
        Try
            Dim dataTable As New DataTable("ObtenerLayoutDeLaVistaDeQueryList")
            Dim command As New SqlCommand

            command.Parameters.Add("@QUERY_LIST_ID", SqlDbType.Int).Value = idQueryList
            command.Parameters.Add("@LOGIN_ID", SqlDbType.VarChar).Value = loginId
            command.CommandText = $"{DefaultSchema}[OP_WMS_GET_GRIDS_LAYOUT_BY_QUERY_LIST]"
            command.CommandType = CommandType.StoredProcedure
            command.Connection = connection

            Dim adapter = New SqlDataAdapter(command)
            adapter.Fill(dataTable)

            Return dataTable
        Catch ex As Exception
            Return Nothing
        Finally
            connection.Close()
            connection.Dispose()
        End Try
    End Function

End Class