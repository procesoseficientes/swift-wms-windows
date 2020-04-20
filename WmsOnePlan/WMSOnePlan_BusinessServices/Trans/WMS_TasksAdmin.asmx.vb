Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Configuration.ConfigurationManager
Imports System.ComponentModel
Imports System.Data.SqlClient
Imports WMSOnePlan_BusinessServices.ModuleServices
Imports WMSOnePlan_BusinessServices.WMS_Tasks
Imports WMSOnePlan_BusinessServices.WMS_InfoTrans

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")>
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)>
<ToolboxItem(False)>
Public Class WMS_TasksAdmin
    Inherits System.Web.Services.WebService

    <WebMethod()>
    Public Function UpdateAssignedTaskUser(ByVal serialNumber As Integer, ByVal wavePicking As Integer, ByVal materialId As String, ByVal pTASK_ASSIGNEDTO As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldb_conexion As SqlConnection = Nothing

        Dim XSQL As String = ""
        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
            sqldb_conexion.Open()

            XSQL = "UPDATE " + DefaultSchema + "OP_WMS_TASK_LIST "

            XSQL = XSQL + "SET "
            If pTASK_ASSIGNEDTO = "Nadie" Then
                XSQL = XSQL + "TASK_ASSIGNEDTO = NULL, "
            Else
                XSQL = XSQL + "TASK_ASSIGNEDTO = '" + pTASK_ASSIGNEDTO + "' "
            End If
            If Not serialNumber = 0 Then
                XSQL = XSQL + " WHERE SERIAL_NUMBER=" & serialNumber
            Else
                XSQL = XSQL + " WHERE WAVE_PICKING_ID=" & wavePicking
                XSQL = XSQL + " AND MATERIAL_ID= '" & materialId + "'"
            End If

            If Not serialNumber = 0 Then
                XSQL = XSQL + "; "
                XSQL = XSQL + "UPDATE PH SET "
                XSQL = XSQL + "PH.POLIZA_ASSIGNEDTO = '" + pTASK_ASSIGNEDTO + "' "
                XSQL = XSQL + "FROM " + DefaultSchema + "OP_WMS_POLIZA_HEADER PH "
                XSQL = XSQL + "INNER JOIN " + DefaultSchema + "OP_WMS_TASK_LIST TL ON( "
                XSQL = XSQL + "PH.DOC_ID = TL.DOC_ID_SOURCE "
                XSQL = XSQL + ") "
                XSQL = XSQL + "WHERE TL.SERIAL_NUMBER = " & serialNumber
            End If


            'XSQL = XSQL + "TASK_OWNER = '" + pTASK_OWNER + "'"

            'XSQL = XSQL + " WHERE SERIAL_NUMBER=" & pTASK_SN
            Dim cmd As New SqlCommand

            cmd.CommandText = XSQL
            cmd.Connection = sqldb_conexion
            cmd.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            pResult = ex.Message
            Return False
        Finally
            '09-Mar-11 J.R. cerrar conexiones para mejorar performance
            sqldb_conexion.Close()
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try

    End Function

    <WebMethod()>
    Public Function MarkToAudit(ByVal pERP_DOC As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim XSQL As String = ""
        Try

            XSQL = "UPDATE " + DefaultSchema + "OP_WMS_DEMAND_TO_PICK "
            XSQL = XSQL + " SET "
            XSQL = XSQL + " NEEDS_TO_AUDIT      = 1"
            XSQL = XSQL + " WHERE ERP_DOCUMENT  = '" + pERP_DOC + "'"

            If ExecuteSqlTransaction(AppSettings(pEnvironmentName).ToString, XSQL, pResult) Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            pResult = ex.Message
            Return False
        Finally
            '09-Mar-11 J.R. cerrar conexiones para mejorar performance
        End Try

    End Function

    <WebMethod()>
    Public Function UpdateStatusTaskUser(ByVal wavePicking As Integer, ByVal pNewStatus As Integer, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldb_conexion As SqlConnection = Nothing
        Dim XSQL As String = ""

        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
            sqldb_conexion.Open()

            XSQL = "UPDATE  " + DefaultSchema + "OP_WMS_TASK_LIST "
            XSQL = XSQL + "SET "
            XSQL = XSQL + "IS_PAUSED = " & pNewStatus
            XSQL = XSQL + " WHERE WAVE_PICKING_ID = " & wavePicking
            'XSQL = XSQL + " AND MATERIAL_ID = '" & materialId & "'"

            Dim cmd As New SqlCommand

            cmd.CommandText = XSQL
            cmd.Connection = sqldb_conexion
            cmd.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            pResult = ex.Message
            Return False
        Finally
            '09-Mar-11 J.R. cerrar conexiones para mejorar performance
            sqldb_conexion.Close()
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try

    End Function

    <WebMethod()>
    Public Function UpdateTaskStatusByBin(ByVal pERP_DOCUMENT As String, ByVal pNewBIN_ID As Integer, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim pTrans As SqlTransaction

        sqldb_conexion.Open()

        Dim XSQL As String = ""

        Try

            XSQL = "SELECT BIN_STATUS FROM " + DefaultSchema + "OP_WMS_BINS WHERE BIN_ID = " + pNewBIN_ID.ToString

            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()
            Try
                miscDA.Fill(miscDS, "UpdateTaskStatusByBin")
            Catch ex As Exception
                pResult = "ERROR," + ex.Message
                Return False
            End Try
            If miscDS.Tables(0).Rows.Count <= 0 Then
                pResult = "No existe Bin : " + pNewBIN_ID.ToString
                Return False
            ElseIf Not IsDBNull(miscDS.Tables(0).Rows(0)("BIN_STATUS")) Then
                pResult = "Este Bin no esta vacío, utilice otro."
                Return False
            End If

        Catch ex As Exception

            pResult = "ERROR," + ex.Message
            Return False

        End Try

        pTrans = sqldb_conexion.BeginTransaction(IsolationLevel.RepeatableRead)


        Try

            XSQL = "UPDATE " + DefaultSchema + "OP_WMS_TASK_LIST "
            XSQL = XSQL + "SET "
            XSQL = XSQL + "BIN_TARGET = " & pNewBIN_ID
            XSQL = XSQL + " WHERE ERP_LEGACY_ID='" & pERP_DOCUMENT & "' AND (IS_COMPLETED = 0 OR IS_PAUSED = 1) "

            'FileOpen(1, "c:\OnePlanWMS\OP_WMS_LOG_TEST.txt", OpenMode.Append, OpenAccess.ReadWrite, OpenShare.Default)
            'WriteLine(1, "UpdateTaskStatusByBin - " + XSQL)
            'FileClose(1)

            If ExecuteSqlTransaction(pTrans, XSQL, pResult) Then

                XSQL = "UPDATE OP_WMS_BINS "
                XSQL = XSQL + "SET "
                XSQL = XSQL + "BIN_STATUS = 'RUNNING' "

                '01-Feb-11 J.R. ahora el picker1 cuando asigna el bin a Running le dice que pedido lleva
                XSQL = XSQL + ", CURRENT_ERP_DOCUMENT = '" + pERP_DOCUMENT + "' "

                XSQL = XSQL + " WHERE BIN_ID = " & pNewBIN_ID

                'FileOpen(1, "c:\OnePlanWMS\OP_WMS_LOG_TEST.txt", OpenMode.Append, OpenAccess.ReadWrite, OpenShare.Default)
                'WriteLine(1, "UpdateTaskStatusByBin - " + XSQL)
                'FileClose(1)

                If ExecuteSqlTransaction(pTrans, XSQL, pResult) Then
                    pTrans.Commit()
                    Return True
                Else
                    pTrans.Rollback()
                    Return False
                End If
            Else
                pTrans.Rollback()
                Return False
            End If
        Catch ex As Exception
            pResult = "UTSB" + ex.Message
            pTrans.Rollback()
            Return False
        Finally
            '09-Mar-11 J.R. cerrar conexiones para mejorar performance
            sqldb_conexion.Close()
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try


    End Function


    <WebMethod()>
    Public Function DeleteTask(ByVal pTASK_SN As Long, ByRef pUserID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldb_conexion As SqlConnection = Nothing

        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)

            Dim sqlCmd = New SqlCommand(DefaultSchema & "OP_WMS_DELETE_PICKING", sqldb_conexion)
            sqlCmd.CommandType = CommandType.StoredProcedure
            sqlCmd.Parameters.Add(New SqlParameter("@WAVE_PICKING_ID", SqlDbType.Int)).Value = pTASK_SN
            'sqlCmd.Parameters.Add(New SqlParameter("@MATERIAL_ID", SqlDbType.VarChar, 25)).Value = pCodeSku
            sqlCmd.Parameters.Add(New SqlParameter("@USER_ID", SqlDbType.VarChar, 25)).Value = pUserID

            If sqldb_conexion.State = ConnectionState.Closed Then sqldb_conexion.Open()
            sqlCmd.ExecuteNonQuery()

            Return True


        Catch ex As Exception
            pResult = ex.Message
            Return False
        Finally
            '09-Mar-11 J.R. cerrar conexiones para mejorar performance
            sqldb_conexion.Close()
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try

    End Function

    'FRM 10Ag2010
    'Instead of creating from Desktop, user will just mark as allowed to picking prior system validations.
    <WebMethod()>
    Public Function MarkAllowedToPicking(ByVal pWAREHOUSE_SOURCE As String, ByVal pLINE_ID As String, ByVal pERPDoc As String, ByVal pTaskOwner As String, ByVal pComments As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim pTrans As SqlTransaction
        Dim xserv1 As New WMS_Tasks

        sqldb_conexion.Open()
        pTrans = sqldb_conexion.BeginTransaction(IsolationLevel.Serializable)

        Dim XSQL As String = ""
        Dim xdata1 As DataSet
        Try
            xdata1 = xserv1.GetDemandDetail(pERPDoc, pResult, pTrans)
            Dim xrow As DataRow
            If pResult = "OK" Then
                For Each xrow In xdata1.Tables(0).Rows

                    If Not xserv1.CreatePickingTask(pWAREHOUSE_SOURCE, pLINE_ID, pERPDoc, xrow("ERP_DOC_DATE"), xrow("CLIENT_ID"), "", xrow("QTY"), xrow("MATERIAL_ID"), False, "", pTaskOwner, "TAREA CREADA DESDE LECTURA EN LINEA", False, False, "0", 0, pResult, pTrans) Then
                        pTrans.Rollback()
                        Return False
                    End If

                Next
                pTrans.Rollback()
                If Not xserv1.MarkAsAllowedToPick(pERPDoc, pLINE_ID, pResult, pEnvironmentName) Then
                    Return False
                End If
                pResult = "OK"
                Return True
            Else
                pTrans.Rollback()
                Return False
            End If
        Catch ex As Exception
            pTrans.Rollback()
            pResult = ex.Message
            Return False
        Finally
            '09-Mar-11 J.R. cerrar conexiones para mejorar performance
            sqldb_conexion.Close()
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try

    End Function


    <WebMethod()>
    Public Function CreatePickingFromDemand(ByVal pWAREHOUSE_SOURCE As String, ByVal pLINE_ID As String, ByVal pERPDoc As String, ByVal pTaskOwner As String, ByVal pComments As String, ByVal pTargetBin As Integer, ByVal pNeedsToAudit As Integer, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim pTrans As SqlTransaction
        Dim xserv1 As New WMS_Tasks

        Try
            Dim srvUsers As New WMS_Security
            Dim blnGenerateTasks As Boolean
            blnGenerateTasks = srvUsers.UserCanGenerateTasks(pTaskOwner, pResult, pEnvironmentName)
            If Not blnGenerateTasks Then
                Return False
            End If
        Catch ex As Exception
            pResult = ex.Message
            Return False
        End Try

        sqldb_conexion.Open()
        pTrans = sqldb_conexion.BeginTransaction(IsolationLevel.Serializable)

        Dim XSQL As String = ""
        Dim xdata1 As DataSet
        Try

            xdata1 = xserv1.GetDemandDetail(pERPDoc, pResult, pTrans)
            Dim xrow As DataRow
            If pResult = "OK" Then
                For Each xrow In xdata1.Tables(0).Rows
                    If Not xserv1.CreatePickingTask(pWAREHOUSE_SOURCE, pLINE_ID, pERPDoc, xrow("ERP_DOC_DATE"), xrow("CLIENT_ID"), "", xrow("QTY"), xrow("MATERIAL_ID"), False, "", pTaskOwner, "TAREA CREADA DESDE MONITOR DE DEMANDA", False, False, pTargetBin, pNeedsToAudit, pResult, pTrans) Then
                        pTrans.Rollback()
                        Return False
                    Else
                        If Not xserv1.UpdateDemand(pERPDoc, xrow("MATERIAL_ID"), pTaskOwner, pResult, pTrans) Then
                            pTrans.Rollback()
                            Return False
                        End If
                    End If
                Next
                pResult = "OK"
                pTrans.Commit()
                Return True
            Else
                pTrans.Rollback()
                Return False
            End If
        Catch ex As Exception
            pTrans.Rollback()
            pResult = ex.Message
            Return False
        Finally
            '09-Mar-11 J.R. cerrar conexiones para mejorar performance
            sqldb_conexion.Close()
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try

    End Function

    <WebMethod()>
    Public Function TestCreatePickingFromDemand(ByVal pWAREHOUSE_SOURCE As String, ByVal pLINE_ID As String, ByVal pERPDoc As String, ByVal pTaskOwner As String, ByVal pComments As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim pTrans As SqlTransaction
        Dim xserv1 As New WMS_Tasks

        sqldb_conexion.Open()
        pTrans = sqldb_conexion.BeginTransaction(IsolationLevel.Serializable)

        Dim XSQL As String = ""
        Dim xdata1 As DataSet
        Try
            xdata1 = xserv1.GetDemandDetail(pERPDoc, pResult, pTrans)
            Dim xrow As DataRow
            If pResult = "OK" Then
                For Each xrow In xdata1.Tables(0).Rows
                    If Not xserv1.CreatePickingTask(pWAREHOUSE_SOURCE, pLINE_ID, pERPDoc, xrow("ERP_DOC_DATE"), xrow("CLIENT_ID"), "", xrow("QTY"), xrow("MATERIAL_ID"), False, "", pTaskOwner, "TAREA CREADA DESDE MONITOR DE DEMANDA", False, False, "0", 0, pResult, pTrans) Then
                        pTrans.Rollback()
                        Return False
                    Else
                        If Not xserv1.UpdateDemand(pERPDoc, xrow("MATERIAL_ID"), pTaskOwner, pResult, pTrans) Then
                            pTrans.Rollback()
                            Return False
                        End If
                    End If
                Next
                pResult = "OK"
                pTrans.Rollback()
                Return True
            Else
                pTrans.Rollback()
                Return False
            End If
        Catch ex As Exception
            pTrans.Rollback()
            pResult = ex.Message
            Return False
        Finally
            '09-Mar-11 J.R. cerrar conexiones para mejorar performance
            sqldb_conexion.Close()
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try

    End Function


    <WebMethod()>
    Public Function CreatePickingManual(ByVal pWAREHOUSE_SOURCE As String, ByVal pLINE_ID As String, ByVal pERPDoc As String, ByVal pERPClient As String, ByVal pTaskOwner As String, ByVal pComments As String, ByVal pQty As Double, ByVal pMaterialID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim pTrans As SqlTransaction
        Dim xserv1 As New WMS_Tasks

        sqldb_conexion.Open()
        pTrans = sqldb_conexion.BeginTransaction(IsolationLevel.Serializable)

        Dim XSQL As String = ""
        Try
            If Not xserv1.CreatePickingTask(pWAREHOUSE_SOURCE, pLINE_ID, pERPDoc, Now, pERPClient, "", pQty, pMaterialID, False, "", pTaskOwner, pComments, False, False, "0", 0, pResult, pTrans) Then
                pTrans.Rollback()
                Return False
            Else
                pTrans.Commit()
                Return True
            End If
        Catch ex As Exception
            pTrans.Rollback()
            pResult = ex.Message
            Return False
        Finally
            '09-Mar-11 J.R. cerrar conexiones para mejorar performance
            sqldb_conexion.Close()
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try

    End Function


    '12-Jul-10 J.R. para crear tareas de replenishment a partir de la opcion Monitor de Reabastecimiento del admin.tasks
    <WebMethod()>
    Public Function CreateReplenishment(ByVal pWAREHOUSE_SOURCE As String, ByVal pWAREHOUSE_TARGET As String, ByVal pTaskOwner As String, ByVal pTASK_ASSIGNEDTO As String, ByVal pMATERIAL_CODE As String, ByVal pMATERIAL_BARCODE As String, ByVal pLOCATION_SPOT_SOURCE As String, ByVal pLOCATION_SPOT_TARGET As String, ByVal p_QTY As Double, ByVal pQUANTITY_ASSIGNED As Double, ByVal pBIN_SOURCE As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim pTrans As SqlTransaction
        Dim xserv1 As New WMS_Tasks

        sqldb_conexion.Open()
        pTrans = sqldb_conexion.BeginTransaction(IsolationLevel.Serializable)

        Dim XSQL As String = ""
        Try
            'If Not xserv1.CreateTask(pWAREHOUSE_SOURCE, pWAREHOUSE_TARGET, "TAREA_REABASTECIMIENTO", "REABASTECIMIENTO_MANUAL", pTaskOwner, pTASK_ASSIGNEDTO, 0, pMATERIAL_CODE, pMATERIAL_BARCODE, pLOCATION_SPOT_SOURCE, pLOCATION_SPOT_TARGET, "", Today.Date, p_QTY, pQUANTITY_ASSIGNED, "", pComments, 0, 0, 0, pResult, pTrans) Then
            'If Not xserv1.CreateReplenishmentTask(pWAREHOUSE_SOURCE, pLINE_ID, pERPDoc, xrow("ERP_DOC_DATE"), xrow("CLIENT_ID"), "", xrow("QTY"), xrow("MATERIAL_ID"), False, "", pTaskOwner, "TAREA CREADA DESDE MONITOR DE DEMANDA", False, False, pResult, pTrans) Then
            If Not xserv1.CreateReplenishmentTask(pWAREHOUSE_SOURCE, pWAREHOUSE_TARGET, pTaskOwner, pTASK_ASSIGNEDTO, 0, pMATERIAL_CODE, pMATERIAL_BARCODE, pLOCATION_SPOT_SOURCE, pLOCATION_SPOT_TARGET, Today.Date, p_QTY, pQUANTITY_ASSIGNED, "", 0, 0, 0, pResult, pTrans) Then
                pTrans.Rollback()
                Return False
            Else
                pResult = "OK"
                pTrans.Commit()
                Return True
            End If
        Catch ex As Exception
            pTrans.Rollback()
            pResult = ex.Message
            Return False
        End Try

    End Function
    <WebMethod(Description:="determine if the scanned location is contained on a given wave and sku ")>
    Public Function GetMyPickingTasks(ByVal pLOGIN_ID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection

        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
            Dim SQL As String = ""
            Dim pDebugInfo As String = ""
            sqldb_conexion.Open()


            SQL = " SELECT * FROM  " + DefaultSchema + "OP "

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

    <WebMethod()>
    Public Function GetBestLocationToRelocFromStandBy(ByVal pWAREHOUSE As String, ByVal pBIN As String, ByVal pMATERIAL As String, ByVal pQTY As Double, ByVal pSTANDBY_LOCATION As String, ByVal pEnvironmentName As String, ByRef pResult As String) As String

        'Dim pNum As Integer = 0
        Dim pTrans As SqlTransaction = Nothing
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim strLocation As String
        Dim xrow As DataRow

        Try

            sqldb_conexion.Open()

            pTrans = sqldb_conexion.BeginTransaction(IsolationLevel.Serializable)

            'pNum = 1
            Dim xserv1 As New WMS_Tasks
            Dim xserv2 As New WMS_Locations
            Dim xdata As DataSet

            'Dim pLastTaskNumber As Double = 0
            'Dim pLastTransNumber As Double = 0

            xdata = xserv1.GetLocationsForStoragePicking(pWAREHOUSE, pMATERIAL, pSTANDBY_LOCATION, pResult, pTrans)
            If pResult = "OK" Then
                xrow = xdata.Tables(0).Rows(0)
                strLocation = xdata.Tables(0).Rows(0)("SPOT_ID").ToString
            Else
                xdata = xserv2.GetRelatedProd_ByWarehouse(pWAREHOUSE, pMATERIAL, pResult, pEnvironmentName)
                If pResult = "OK" Then
                    xrow = xdata.Tables(0).Rows(0)
                    strLocation = xdata.Tables(0).Rows(0)("LOCATION_SPOT").ToString
                Else
                    strLocation = ""
                    pResult = "Todas las ubicaciones relacionadas estan vacias o no hay ninguna relacion creada"
                End If
            End If

            pTrans.Commit()
            sqldb_conexion.Close()
            Return strLocation

        Catch ex As Exception
            Try
                Dim pMess As String = ex.Message
                pTrans.Rollback()
                sqldb_conexion.Close()
                pResult = pMess
                Return "Error: " + pMess
            Catch ex1 As Exception
                pResult = ex1.Message
                Return "Error: " + ex1.Message
            End Try
            pResult = ex.Message
            Return "Error: " + ex.Message
        End Try
        pResult = "OK"
        Return "OK"
    End Function

    '13-Ago-10 J.R. para actualizar el Start Date/time de la tarea cada vez que le aparece al usuario en la HH
    <WebMethod()>
    Public Function UpdateTaskStartDate(ByVal pTASK_SN As Long, ByRef pUserID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim pTrans As SqlTransaction

        sqldb_conexion.Open()
        pTrans = sqldb_conexion.BeginTransaction(IsolationLevel.Serializable)

        Dim XSQL As String = ""
        Try
            XSQL = "UPDATE " + DefaultSchema + "OP_WMS_TASK_LIST "
            XSQL = XSQL + "SET "
            XSQL = XSQL + "PICKING_STARTED_DATE=CURRENT_TIMESTAMP"
            XSQL = XSQL + " WHERE SERIAL_NUMBER=" & pTASK_SN

            If ExecuteSqlTransaction(pTrans, XSQL, pResult) Then
                pTrans.Commit()
                Return True
            Else
                pTrans.Rollback()
                Return False
            End If

        Catch ex As Exception
            pResult = ex.Message
            Return False
        Finally
            '09-Mar-11 J.R. cerrar conexiones para mejorar performance
            sqldb_conexion.Close()
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try

    End Function

    <WebMethod()>
    Public Function AddLog(ByVal pLOGIN_ID As String, ByVal pTRANS_TYPE As String, ByVal pBIN_ID As Integer, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim pTrans As SqlTransaction

        sqldb_conexion.Open()
        pTrans = sqldb_conexion.BeginTransaction(IsolationLevel.Serializable)

        Dim XSQL As String = ""

        Try

            XSQL = "INSERT INTO " + DefaultSchema + "OP_WMS_LOGS (LOGIN_ID, TRANS_TYPE, LOG_DATE, BIN_ID) "
            XSQL = XSQL + "VALUES ('" + pLOGIN_ID + "', '" + pTRANS_TYPE + "', GETDATE(), " & pBIN_ID & ")"

            If ExecuteSqlTransaction(pTrans, XSQL, pResult) Then
                pTrans.Commit()
                Return True
            Else
                pTrans.Rollback()
                Return False
            End If

        Catch ex As Exception
            pTrans.Rollback()
            pResult = ex.Message
            Return False
        Finally
            '09-Mar-11 J.R. cerrar conexiones para mejorar performance
            sqldb_conexion.Close()
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try

    End Function

    <WebMethod(Description:="Limpia la DATA para empezar campaña")>
    Public Function CleanUpDataForNewCampaign(ByVal pLogin As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim pTrans As SqlTransaction = Nothing
        sqldb_conexion.Open()

        Try

            Dim cmd As New SqlCommand
            pTrans = sqldb_conexion.BeginTransaction(IsolationLevel.Serializable)
            cmd.CommandText = DefaultSchema + "OP_WMS_SP_START_CAMPAIGN"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldb_conexion
            cmd.Transaction = pTrans
            cmd.ExecuteNonQuery()
            pTrans.Commit()

            sqldb_conexion.Close()
            pResult = "OK"
            Return True

        Catch ex As Exception

            pTrans.Rollback()
            pResult = ex.Message
            Return False

        Finally
            '09-Mar-11 J.R. cerrar conexiones para mejorar performance
            sqldb_conexion.Close()
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try

    End Function

    '24-Feb-11 J.R. para anular pedidos (asignados y por asignar)
    <WebMethod()>
    Public Function MarkDocumentAsVoid(ByVal pERP_DOCUMENT As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim pTrans As SqlTransaction
        Dim intCuantos As Integer

        sqldb_conexion.Open()

        pTrans = sqldb_conexion.BeginTransaction(IsolationLevel.Serializable)

        Dim XSQL As String = ""
        Try

            XSQL = "UPDATE " + DefaultSchema + "OP_WMS_DEMAND_TO_PICK SET ALLOWED_TO_PICK = 6, VOIDED_DATE = GETDATE() WHERE ERP_DOCUMENT = '" & pERP_DOCUMENT & "' AND (ALLOWED_TO_PICK IS NULL OR ALLOWED_TO_PICK = 2)"

            'XSQL = "UPDATE OP_WMS_TASK_LIST "
            'XSQL = XSQL + "SET "
            'XSQL = XSQL + "BIN_TARGET = " & pNewBIN_ID
            'XSQL = XSQL + " WHERE ERP_LEGACY_ID='" & pERP_DOCUMENT & "' AND IS_COMPLETED = 0 AND IS_PAUSED = 0 AND IS_CANCELED = 0 "


            ''FileOpen(1, "c:\OnePlanWMS\OP_WMS_LOG_TEST.txt", OpenMode.Append, OpenAccess.ReadWrite, OpenShare.Default)
            ''WriteLine(1, "UpdateTaskStatusByBin - " + XSQL)
            ''FileClose(1)


            'If ExecuteSqlTransaction(pTrans, XSQL, pResult) Then

            '    XSQL = "UPDATE OP_WMS_BINS "
            '    XSQL = XSQL + "SET "
            '    XSQL = XSQL + "BIN_STATUS = 'RUNNING' "

            '    '01-Feb-11 J.R. ahora el picker1 cuando asigna el bin a Running le dice que pedido lleva
            '    XSQL = XSQL + ", CURRENT_ERP_DOCUMENT = '" + pERP_DOCUMENT + "' "

            '    XSQL = XSQL + " WHERE BIN_ID = " & pNewBIN_ID

            '    'FileOpen(1, "c:\OnePlanWMS\OP_WMS_LOG_TEST.txt", OpenMode.Append, OpenAccess.ReadWrite, OpenShare.Default)
            '    'WriteLine(1, "UpdateTaskStatusByBin - " + XSQL)
            '    'FileClose(1)

            If ExecuteSqlTransaction(pTrans, XSQL, pResult, intCuantos) Then
                pTrans.Commit()
                If intCuantos <> 0 Then
                    Return True
                Else
                    Return False
                End If
            Else
                pTrans.Rollback()
                Return False
            End If
            'Else
            'pTrans.Rollback()
2:          'Return False
            'End If
        Catch ex As Exception
            pResult = ex.Message
            pTrans.Rollback()
            Return False
        Finally
            '09-Mar-11 J.R. cerrar conexiones para mejorar performance
            sqldb_conexion.Close()
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try

    End Function

    '23-Jun-11 J.R. para restaurar pedidos anulados
    <WebMethod()>
    Public Function RestoreDocumentFromVoid(ByVal pERP_DOCUMENT As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim pTrans As SqlTransaction
        Dim intCuantos As Integer

        sqldb_conexion.Open()

        pTrans = sqldb_conexion.BeginTransaction(IsolationLevel.Serializable)

        Dim XSQL As String = ""
        Try

            XSQL = "UPDATE " + DefaultSchema + "OP_WMS_DEMAND_TO_PICK SET ALLOWED_TO_PICK = NULL WHERE ERP_DOCUMENT = '" & pERP_DOCUMENT & "' AND (ALLOWED_TO_PICK = 6)"

            If ExecuteSqlTransaction(pTrans, XSQL, pResult, intCuantos) Then
                pTrans.Commit()
                If intCuantos <> 0 Then
                    Return True
                Else
                    Return False
                End If
            Else
                pTrans.Rollback()
                Return False
            End If

        Catch ex As Exception
            pResult = ex.Message
            pTrans.Rollback()
            Return False
        Finally
            '09-Mar-11 J.R. cerrar conexiones para mejorar performance
            sqldb_conexion.Close()
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try

    End Function

    '29-Mar-11 J.R. balancea pedidos por linea
    <WebMethod()>
    Public Function AssignLineToDemmand(ByVal pSector As String, ByVal pRuta As String, ByVal pIncluyeAsignados As Boolean, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim pTrans As SqlTransaction
        Dim xdata As DataSet
        Dim xdata2 As DataSet
        Dim xrow As DataRow
        Dim xrow2 As DataRow
        Dim xserv As New WMS_InfoTrans
        Dim XSQL As String = ""
        Dim blnErrors As Boolean = False
        Dim blnYaDesasigno As Boolean = False

        sqldb_conexion.Open()

        Try

            'Busca tamaños pedidos
            '13-Abr-11 J.R. se agrego parametro pIncluyeAsignados
            xdata = xserv.GetLineBalancingBySector(pSector, pRuta, pIncluyeAsignados, pResult, pEnvironmentName)
            If pResult = "OK" Then

                'Recorre tamaños pedidos
                For Each xrow In xdata.Tables(0).Rows

                    'busca detalle pedidos segun Size
                    '13-Abr-11 J.R. se agrego parametro pIncluyeAsignados
                    xdata2 = xserv.GetDemandBySizeForBalancing(pSector, pRuta, pIncluyeAsignados, xrow("SIZE").ToString, pResult, pEnvironmentName)
                    If pResult = "OK" Then

                        Dim intTotalPedidosLinea1 As Integer = xrow("LINEA1")
                        Dim intTotalPedidosLinea2 As Integer = xrow("LINEA2")
                        Dim intTotalPedidosLinea3 As Integer = xrow("LINEA3")
                        Dim intNextLine As Integer
                        If intTotalPedidosLinea1 + intTotalPedidosLinea2 + intTotalPedidosLinea3 > 0 Then

                            pTrans = sqldb_conexion.BeginTransaction(IsolationLevel.Serializable)

                            '13-Abr-11 J.R. se agrego parametro pIncluyeAsignados
                            If pIncluyeAsignados And Not blnYaDesasigno Then
                                blnYaDesasigno = True
                                XSQL = "UPDATE " + DefaultSchema + "OP_WMS_DEMAND_TO_PICK SET ASSIGNED_TO_LINE = NULL, ALLOWED_TO_PICK = NULL WHERE CLIENT_REGION = '" + pSector + "' "
                                If pRuta.Trim <> "" Then
                                    XSQL = XSQL + "AND CLIENT_ROUTE like '%" + pRuta.ToUpper + "%' "
                                End If
                                If Not ExecuteSqlTransaction(pTrans, XSQL, pResult) Then
                                    blnErrors = True
                                End If
                            End If

                            Dim strLinea As String = ""

                            'Recorre detalle pedidos
                            intNextLine = 1
                            For Each xrow2 In xdata2.Tables(0).Rows

                                strLinea = ""
                                If intNextLine = 1 Then
                                    If intTotalPedidosLinea1 > 0 Then
                                        strLinea = "LINEA_1"
                                        intTotalPedidosLinea1 -= 1
                                        intNextLine = 2
                                    Else
                                        If intTotalPedidosLinea2 > 0 Then
                                            strLinea = "LINEA_2"
                                            intTotalPedidosLinea2 -= 1
                                            intNextLine = 3
                                        Else
                                            If intTotalPedidosLinea3 > 0 Then
                                                strLinea = "LINEA_3"
                                                intTotalPedidosLinea3 -= 1
                                                intNextLine = 1
                                            End If
                                        End If
                                    End If

                                ElseIf intNextLine = 2 Then
                                    If intTotalPedidosLinea2 > 0 Then
                                        strLinea = "LINEA_2"
                                        intTotalPedidosLinea2 -= 1
                                        intNextLine = 3
                                    Else
                                        If intTotalPedidosLinea3 > 0 Then
                                            strLinea = "LINEA_3"
                                            intTotalPedidosLinea3 -= 1
                                            intNextLine = 1
                                        Else
                                            If intTotalPedidosLinea1 > 0 Then
                                                strLinea = "LINEA_1"
                                                intTotalPedidosLinea1 -= 1
                                                intNextLine = 2
                                            End If
                                        End If
                                    End If

                                ElseIf intNextLine = 3 Then
                                    If intTotalPedidosLinea3 > 0 Then
                                        strLinea = "LINEA_3"
                                        intTotalPedidosLinea3 -= 1
                                        intNextLine = 1
                                    Else
                                        If intTotalPedidosLinea1 > 0 Then
                                            strLinea = "LINEA_1"
                                            intTotalPedidosLinea1 -= 1
                                            intNextLine = 2
                                        Else
                                            If intTotalPedidosLinea2 > 0 Then
                                                strLinea = "LINEA_2"
                                                intTotalPedidosLinea2 -= 1
                                                intNextLine = 3
                                            End If
                                        End If
                                    End If
                                End If

                                If strLinea <> "" Then

                                    XSQL = "UPDATE " + DefaultSchema + "OP_WMS_DEMAND_TO_PICK SET ASSIGNED_TO_LINE = '" & strLinea & "' WHERE ERP_DOCUMENT = '" & xrow2("ERP_DOCUMENT") & "'"
                                    If Not ExecuteSqlTransaction(pTrans, XSQL, pResult) Then
                                        blnErrors = True
                                    End If

                                End If

                            Next  'Recorre detalle pedidos

                            If Not blnErrors Then
                                pTrans.Commit()
                            Else
                                pTrans.Rollback()
                            End If

                        End If  'Si totallinea1 + 2 + 3 > 0

                    End If  'busca detalle pedidos segun Size
                    If pResult = "No se encontraron pedidos para asignar" Then pResult = "OK"

                Next  'Recorre tamaños pedidos

            End If  'Busca tamaños pedidos

            Return True

        Catch ex As Exception
            pResult = "ERROR: " + ex.Message
            Return False

        Finally
            sqldb_conexion.Close()
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try

    End Function

    '07-Abr-11 J.R. quita el bin de la tabla de control
    <WebMethod()>
    Public Function RemovePedidoFromCtrlBin(ByVal pTargetBin As Integer, ByVal pAssignedUser As String, ByVal pLinea As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim pTrans As SqlTransaction
        Dim xserv1 As New WMS_Tasks




        sqldb_conexion.Open()
        pTrans = sqldb_conexion.BeginTransaction(IsolationLevel.Serializable)

        Try

            xserv1.RemoveBINfromControlTable(pTargetBin, pAssignedUser, pLinea, pResult, pTrans)
            If pResult = "OK" Then
                pTrans.Commit()
                Return True
            Else
                pTrans.Rollback()
                Return False
            End If

        Catch ex As Exception
            pTrans.Rollback()
            pResult = ex.Message
            Return False
        Finally
            '09-Mar-11 J.R. cerrar conexiones para mejorar performance
            sqldb_conexion.Close()
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try

    End Function

    '07-Abr-11 J.R. quita el bin de la tabla de control
    <WebMethod()>
    Public Function AddNewBINClosedToCtrlBin(ByVal pERPDoc As String, ByVal pClosedBin As Integer, ByVal pTargetBin As Integer, ByVal pAssignedUser As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim pTrans As SqlTransaction
        Dim xserv1 As New WMS_Tasks

        sqldb_conexion.Open()
        pTrans = sqldb_conexion.BeginTransaction(IsolationLevel.Serializable)

        Try

            xserv1.AddClosedBINtoControlTable(pERPDoc, pClosedBin, pTargetBin, pAssignedUser, pResult, pTrans)
            If pResult = "OK" Then
                pTrans.Commit()
                Return True
            Else
                pTrans.Rollback()
                Return False
            End If

        Catch ex As Exception
            pTrans.Rollback()
            pResult = ex.Message
            Return False
        Finally
            '09-Mar-11 J.R. cerrar conexiones para mejorar performance
            sqldb_conexion.Close()
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try

    End Function

    '27-Jun-11 J.R. cuando se reasigna un pedido a otro bin, agrega el bin a la tabla de control para que aparezca en las MK4000
    <WebMethod()>
    Public Function AddReassignedBINtoControlTableCall(ByVal pERPDoc As String, ByVal pTargetBin As Integer, ByVal pColumna As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim pTrans As SqlTransaction
        Dim xserv1 As New WMS_Tasks

        sqldb_conexion.Open()


        Dim XSQL As String = ""

        XSQL = "SELECT '" & pERPDoc & "'," & pTargetBin & ", LOGIN_ID, (SELECT DATEADD(MILLISECOND,100,MAX(DATETIME_PASSED)) FROM " + DefaultSchema + "OP_WMS_CTRL_BIN_PASSING WHERE ERP_LEGACY_ID = '" & pERPDoc & "') HORA_NUEVA, LOCATION_SPOT FROM OP_WMS_LOGIN_JOIN_LOCATIONS "
        XSQL = XSQL + "WHERE LINE_ID = (SELECT MAX(ASSIGNED_TO_LINE) FROM " + DefaultSchema + "OP_WMS_DEMAND_TO_PICK WHERE ERP_DOCUMENT = '" & pERPDoc & "') "
        XSQL = XSQL + "AND LOCATION_SPOT >= '" & pColumna & "' "
        XSQL = XSQL + "ORDER BY LOCATION_SPOT "

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "AddReassignedBINtoControlTableCall")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return False
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "NO_INFO"
            Return False
        Else
            pTrans = sqldb_conexion.BeginTransaction(IsolationLevel.Serializable)
            Try

                For Each xRow In miscDS.Tables(0).Rows
                    XSQL = "INSERT INTO " + DefaultSchema + "OP_WMS_CTRL_BIN_PASSING (ERP_LEGACY_ID, BIN_TARGET, TASK_ASSIGNEDTO, DATETIME_PASSED, BIN_RELEASED) "
                    XSQL = XSQL + "VALUES ('" + pERPDoc + "', " & pTargetBin & ", '" + xRow("LOGIN_ID").ToString + "', '" & Format(xRow("HORA_NUEVA"), "yyyy/MM/dd hh:mm:ss.fff tt") & "', '" + IIf(xRow("LOCATION_SPOT").ToString = pColumna, "S", "N") + "')"
                    If Not ExecuteSqlTransaction(pTrans, XSQL, pResult) Then
                        pTrans.Rollback()
                        Return False
                    End If

                    'xserv1.AddReassignedBINtoControlTable(pERPDoc, pTargetBin, pColumna, pResult, pTrans)
                Next
                pTrans.Commit()
                pResult = "OK"
                Return True

            Catch ex As Exception
                pResult = ex.Message
                pTrans.Rollback()
                Return False
            Finally
                '09-Mar-11 J.R. cerrar conexiones para mejorar performance
                sqldb_conexion.Close()
                sqldb_conexion.Dispose()
                sqldb_conexion = Nothing
            End Try
        End If


        'pTrans = sqldb_conexion.BeginTransaction(IsolationLevel.Serializable)

        'Try

        '    xserv1.AddReassignedBINtoControlTable(pERPDoc, pTargetBin, pColumna, pResult, pTrans)
        '    If pResult = "OK" Then
        '        pTrans.Commit()
        '        Return True
        '    Else
        '        pTrans.Rollback()
        '        Return False
        '    End If

        'Catch ex As Exception
        '    pTrans.Rollback()
        '    pResult = ex.Message
        '    Return False
        'Finally
        '    '09-Mar-11 J.R. cerrar conexiones para mejorar performance
        '    sqldb_conexion.Close()
        '    sqldb_conexion.Dispose()
        '    sqldb_conexion = Nothing
        'End Try

    End Function
    'crear tarea de validacion de bultos
    <WebMethod()>
    Public Function CreatePackagesCountTask(ByVal pWAREHOUSE_SOURCE As String, ByVal pLINE_ID As String, ByVal pERPDoc As String, ByVal pERPClient As String, ByVal pTaskOwner As String, ByVal pComments As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim pTrans As SqlTransaction
        Dim xserv1 As New WMS_Tasks

        sqldb_conexion.Open()
        pTrans = sqldb_conexion.BeginTransaction(IsolationLevel.Serializable)

        Dim XSQL As String = ""
        Try
            If Not xserv1.CreatePackagesCountTask(pWAREHOUSE_SOURCE, pLINE_ID, pERPDoc, False, "", pResult, pTrans) Then
                pTrans.Rollback()
                Return False
            Else
                pTrans.Commit()
                Return True
            End If
        Catch ex As Exception
            pTrans.Rollback()
            pResult = ex.Message
            Return False
        Finally

            sqldb_conexion.Close()
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try

    End Function
    'WM agregado para crear conteos en wms
    <WebMethod(Description:="Devuelve los conteos")>
    Public Function get_all_counts(ByVal pEnvironmentName As String, ByRef pResult As String) As DataSet
        Dim XSQL As String = "SELECT * "
        XSQL = XSQL & " FROM " & DefaultSchema & "OP_WMS_COUNTING "

        Dim sqldb_conexion As SqlConnection

        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()
            miscDA.Fill(miscDS, "OP_WMS_COUNTING")
            pResult = "OK"
            Return miscDS
        Catch ex As Exception

            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
    End Function

    <WebMethod(Description:="graba un conteo")>
    Public Function set_counting(ByRef pCOUNT_ID As Integer, ByVal pCREATED_BY As String, ByVal pCOUNT_TYPE As String, ByVal pACCURACY As Decimal,
                                    ByVal pFiltro As DataSet, ByVal pEnvironmentName As String, ByRef pResult As String) As Boolean
        Dim sqldb_conexion As SqlConnection
        Dim sqlCmd As SqlCommand
        Dim sqlSELECT As String = String.Empty
        Dim XWHERE As String = String.Empty
        Dim i As Integer = 0

        sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Try

            If pFiltro.Tables("OPCIONES").Rows.Count > 0 Then
                If XWHERE.Contains("WHERE") Then
                    XWHERE = " AND " + pFiltro.Tables("OPCIONES").Rows(i)("OPCION").ToString

                Else
                    XWHERE = " WHERE " + pFiltro.Tables("OPCIONES").Rows(i)("OPCION").ToString
                End If
                For i = 0 To pFiltro.Tables("OPCIONES").Rows.Count - 1
                    If XWHERE.Contains("IN") Then

                        XWHERE = XWHERE + " , '" + pFiltro.Tables("OPCIONES").Rows(i)("VALOR").ToString + "'"
                    Else
                        XWHERE = XWHERE + " IN ( '" + pFiltro.Tables("OPCIONES").Rows(i)("VALOR").ToString + "'"

                    End If
                Next
                XWHERE = XWHERE + " ) "
            End If

            If pFiltro.Tables("FILTROS").Rows.Count > 0 Then
                For i = 0 To pFiltro.Tables("FILTROS").Rows.Count - 1
                    Dim st As String = String.Empty
                    Select Case pFiltro.Tables("FILTROS").Rows(i)("FILTRO").ToString
                        Case "REGIMEN"
                            st = "REGIMEN"
                        Case "CLIENTE"
                            st = "CLIENT_CODE"
                        Case "BODEGA"
                            st = "WAREHOUSE_ID"
                    End Select

                    If XWHERE.Contains("WHERE") Then
                        XWHERE = XWHERE + " AND " + st
                        XWHERE = XWHERE + " = '" + pFiltro.Tables("FILTROS").Rows(i)("VALOR").ToString + "'"

                    Else
                        XWHERE = " WHERE " + st
                        XWHERE = XWHERE + " = '" + pFiltro.Tables("FILTROS").Rows(i)("VALOR").ToString + "'"
                    End If
                Next
            End If

            sqlSELECT = "SELECT DISTINCT CLIENT_CODE,MATERIAL_ID,BARCODE_ID,MATERIAL_NAME,REGIMEN,CODIGO_POLIZA,CURRENT_LOCATION,WAREHOUSE_ID "
            sqlSELECT = sqlSELECT & " FROM " & DefaultSchema & "OP_WMS_VIEW_ACOUNTABLE_LOCATIONS "
            If Not pCOUNT_TYPE = "COMPLETO" Then
                sqlSELECT = sqlSELECT + XWHERE
            End If

            Dim sqlINS As String

            sqlINS = "INSERT INTO " & DefaultSchema & "OP_WMS_TEMP_TOCOUNT(CLIENT_CODE, MATERIAL_ID, BARCODE_ID, MATERIAL_NAME, REGIMEN, CODIGO_POLIZA, CURRENT_LOCATION, WAREHOUSE_ID) "
            sqlINS = sqlINS + sqlSELECT

            ExecuteSqlTransaction(AppSettings(pEnvironmentName).ToString, sqlINS, pResult)

            sqlCmd = New SqlCommand(DefaultSchema & "OP_WMS_SP_COUNTING", sqldb_conexion)
            sqlCmd.CommandType = CommandType.StoredProcedure

            'creamos todos los parametros del sp
            sqlCmd.Parameters.Add(New SqlParameter("@pCOUNT_ID", SqlDbType.Int)).Direction = ParameterDirection.InputOutput
            sqlCmd.Parameters.Add(New SqlParameter("@pCREATED_BY", SqlDbType.VarChar, 25)).Direction = ParameterDirection.Input
            sqlCmd.Parameters.Add(New SqlParameter("@pCOUNT_TYPE", SqlDbType.VarChar, 25))
            sqlCmd.Parameters.Add(New SqlParameter("@pACCURACY", SqlDbType.Float))
            sqlCmd.Parameters.Add(New SqlParameter("@pRESULT", SqlDbType.VarChar, 4000)).Direction = ParameterDirection.Output

            sqlCmd.Parameters("@pCREATED_BY").Value = pCREATED_BY
            sqlCmd.Parameters("@pCOUNT_TYPE").Value = pCOUNT_TYPE
            sqlCmd.Parameters("@pACCURACY").Value = pACCURACY

            If pCOUNT_ID > 0 Then
                sqlCmd.Parameters("@pCOUNT_ID").Value = pCOUNT_ID
            End If

            'ejecutamos el procedure y validamos la respuesta
            If sqldb_conexion.State = ConnectionState.Closed Then sqldb_conexion.Open()
            sqlCmd.ExecuteNonQuery()

            pResult = sqlCmd.Parameters("@pRESULT").Value


            If pResult = "OK" Then
                pCOUNT_ID = sqlCmd.Parameters("@pCOUNT_ID").Value
                Return True
            Else

                Return False
            End If

        Catch ex As Exception
            pResult = ex.Message
            pResult = "ERROR:" + ex.Message
            Return False

        Finally
            If sqldb_conexion.State = ConnectionState.Open Then sqldb_conexion.Close()

        End Try

    End Function

    <WebMethod(Description:="Devuelve los ubicaciones a contar")>
    Public Function get_locations_count(ByVal pFiltro As DataSet, ByVal pEnvironmentName As String, ByRef pResult As String) As DataSet

        Dim XSQL As String = String.Empty
        Dim XWHERE As String = String.Empty
        Dim i As Integer

        Dim sqldb_conexion As SqlConnection

        Try

            If pFiltro.Tables("OPCIONES").Rows.Count > 0 Then
                If XWHERE.Contains("WHERE") Then
                    XWHERE = " AND " + pFiltro.Tables("OPCIONES").Rows(i)("OPCION").ToString

                Else
                    XWHERE = " WHERE " + pFiltro.Tables("OPCIONES").Rows(i)("OPCION").ToString
                End If
                For i = 0 To pFiltro.Tables("OPCIONES").Rows.Count - 1
                    If XWHERE.Contains("IN") Then

                        XWHERE = XWHERE + " , '" + pFiltro.Tables("OPCIONES").Rows(i)("VALOR").ToString + "'"
                    Else
                        XWHERE = XWHERE + " IN ( '" + pFiltro.Tables("OPCIONES").Rows(i)("VALOR").ToString + "'"

                    End If
                Next
                XWHERE = XWHERE + " ) "
            End If

            If pFiltro.Tables("FILTROS").Rows.Count > 0 Then
                For i = 0 To pFiltro.Tables("FILTROS").Rows.Count - 1
                    Dim st As String = String.Empty
                    Select Case pFiltro.Tables("FILTROS").Rows(i)("FILTRO").ToString
                        Case "REGIMEN"
                            st = "REGIMEN"
                        Case "CLIENTE"
                            st = "CLIENT_CODE"
                        Case "BODEGA"
                            st = "WAREHOUSE_ID"
                    End Select

                    If XWHERE.Contains("WHERE") Then
                        XWHERE = XWHERE + " AND " + st
                        XWHERE = XWHERE + " = '" + pFiltro.Tables("FILTROS").Rows(i)("VALOR").ToString + "'"

                    Else
                        XWHERE = " WHERE " + st
                        XWHERE = XWHERE + " = '" + pFiltro.Tables("FILTROS").Rows(i)("VALOR").ToString + "'"
                    End If
                Next
            End If

            XSQL = "SELECT DISTINCT CURRENT_LOCATION "
            XSQL = XSQL & " FROM " & DefaultSchema & "OP_WMS_VIEW_ACOUNTABLE_LOCATIONS "
            XSQL = XSQL + XWHERE

            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()
            miscDA.Fill(miscDS, "OP_WMS_COUNTING")
            pResult = "OK"
            Return miscDS
        Catch ex As Exception

            pResult = XSQL + " ERROR," + ex.Message
            Return Nothing
        End Try
    End Function

    <WebMethod(Description:="Devuelve tareas de conteo")>
    Public Function get_all_count_tasks(ByVal pCOUNT_ID As Integer, ByVal pEnvironmentName As String, ByRef pResult As String) As DataSet
        Dim XSQL As String = "SELECT COUNT_ID, SERIAL_NUMBER, ISNULL(ASSIGNED_TO,'NO ASIGNADO') ASSIGNED_TO, ASSIGNED_BY, COUNT_TYPE, COUNT_REGIMEN, COUNT_CLIENT_OWNER, "
        XSQL = XSQL & "COUNT_CLIENT_NAME, COUNT_DESCRIPTION, CREATED_DATE, ASSIGNED_DATE, COUNTED_DATE, COMPLETED_DATE, CANCELED_DATE, EXPECTED_LOCATION_SPOT, "
        XSQL = XSQL & "SCANNED_LOCATION_SPOT, EXPECTED_LICENSE_ID, SCANNED_LICENSE_ID, EXPECTED_MATERIAL_ID, SCANNED_MATERIAL_ID, SCANNED_BARCODE, MATERIAL_NAME, SNAPSHOT_QTY, "
        XSQL = XSQL & "INPUTED_QTY, CALCULATED_DIFF, COMMENTS, HIT_OR_MISS "
        XSQL = XSQL & " FROM " & DefaultSchema & "OP_WMS_TASK_LIST_COUNTING WHERE COUNT_ID =  " & pCOUNT_ID

        Dim sqldb_conexion As SqlConnection

        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()
            miscDA.Fill(miscDS, "OP_WMS_TASK_LIST_COUNTING")
            pResult = "OK"
            Return miscDS
        Catch ex As Exception

            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
    End Function

    <WebMethod(Description:="asigna tareas de conteo")>
    Public Function assing_counting_task(ByVal pTasks As DataSet, ByVal pEnvironmentName As String, ByRef pResult As String) As Boolean
        Dim sqldb_conexion As SqlConnection

        Dim sqlSELECT As String = String.Empty

        sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        Try
            Dim i As Int16
            For i = 0 To pTasks.Tables(0).Rows.Count - 1
                sqlSELECT = " UPDATE " & DefaultSchema & "OP_WMS_TASK_LIST_COUNTING SET ASSIGNED_TO = '" & pTasks.Tables(0).Rows(i)("ASIGNAR_A") & "', "
                sqlSELECT = sqlSELECT & " ASSIGNED_BY = '" & pTasks.Tables(0).Rows(i)("ASIGNADO_POR") & "', ASSIGNED_DATE =  GETDATE() "
                sqlSELECT = sqlSELECT & " WHERE COUNT_ID = " & pTasks.Tables(0).Rows(i)("COUNT_ID") & " AND SERIAL_NUMBER = " & pTasks.Tables(0).Rows(i)("SERIAL_NUMBER")

                ExecuteSqlTransaction(AppSettings(pEnvironmentName).ToString, sqlSELECT, pResult)

            Next

            If pResult = "OK" Then

                Return True
            Else

                Return False
            End If

        Catch ex As Exception
            pResult = ex.Message
            pResult = "ERROR:" + ex.Message
            Return False

        Finally
            If sqldb_conexion.State = ConnectionState.Open Then sqldb_conexion.Close()

        End Try

    End Function

    <WebMethod(Description:="rpt diferencias conteo")>
    Public Function get_count_dif(ByVal pCOUNT_ID As Integer, ByVal pEnvironmentName As String, ByRef pResult As String) As DataSet
        Dim XSQL As String = "SELECT COUNT_ID CONTEO, COUNT_TYPE TIPO, COUNT_CLIENT_NAME CLIENTE, COUNTED_DATE FECHA_CONTEO,  "
        XSQL = XSQL & "SCANNED_MATERIAL_ID CODIGO_PRODUCTO, SCANNED_BARCODE CODIGO_ALTERNO, MATERIAL_NAME PRODUCTO, SNAPSHOT_QTY SISTEMA, INPUTED_QTY CONTADO, "
        XSQL = XSQL & "CALCULATED_DIFF DIFERENCIA "
        XSQL = XSQL & " FROM " & DefaultSchema & "OP_WMS_TASK_LIST_COUNTING "
        XSQL = XSQL & "WHERE CALCULATED_DIFF <> 0 "

        Dim sqldb_conexion As SqlConnection

        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()
            miscDA.Fill(miscDS, "DIFERENCIAS")
            pResult = "OK"
            Return miscDS
        Catch ex As Exception

            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
    End Function
    <WebMethod(Description:="cancela tareas de conteo")>
    Public Function cancel_counting_task(ByVal pTasks As DataSet, ByVal pEnvironmentName As String, ByRef pResult As String) As Boolean
        Dim sqldb_conexion As SqlConnection

        Dim sqlSELECT As String = String.Empty

        sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        Try
            Dim i As Int16
            For i = 0 To pTasks.Tables(0).Rows.Count - 1
                sqlSELECT = " UPDATE " & DefaultSchema & "OP_WMS_TASK_LIST_COUNTING SET CANCELED_DATE = GETDATE() "
                sqlSELECT = sqlSELECT & " WHERE COUNT_ID = " & pTasks.Tables(0).Rows(i)("COUNT_ID") & " AND SERIAL_NUMBER = " & pTasks.Tables(0).Rows(i)("SERIAL_NUMBER")

                ExecuteSqlTransaction(AppSettings(pEnvironmentName).ToString, sqlSELECT, pResult)

            Next

            If pResult = "OK" Then

                Return True
            Else

                Return False
            End If

        Catch ex As Exception
            pResult = ex.Message
            pResult = "ERROR:" + ex.Message
            Return False

        Finally
            If sqldb_conexion.State = ConnectionState.Open Then sqldb_conexion.Close()

        End Try

    End Function

    <WebMethod()>
    Public Function UpdateStatusTaskUserBySerialNumber(ByVal pTASK_SN As Long, ByVal pNewStatus As Integer, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldb_conexion As SqlConnection = Nothing
        Dim XSQL As String = ""

        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
            sqldb_conexion.Open()

            XSQL = "UPDATE  " + DefaultSchema + "OP_WMS_TASK_LIST "
            XSQL = XSQL + "SET "
            XSQL = XSQL + "IS_PAUSED = " & pNewStatus
            XSQL = XSQL + " WHERE SERIAL_NUMBER = (SELECT TOP 1 SERIAL_NUMBER FROM  " + DefaultSchema + "OP_WMS_TASK_LIST WHERE SERIAL_NUMBER = " & pTASK_SN & ") AND "
            XSQL = XSQL + " MATERIAL_ID = (SELECT TOP 1 MATERIAL_ID FROM  " + DefaultSchema + "OP_WMS_TASK_LIST WHERE SERIAL_NUMBER = " & pTASK_SN & ") "

            Dim cmd As New SqlCommand

            cmd.CommandText = XSQL
            cmd.Connection = sqldb_conexion
            cmd.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            pResult = ex.Message
            Return False
        Finally
            '09-Mar-11 J.R. cerrar conexiones para mejorar performance
            sqldb_conexion.Close()
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try

    End Function


    <WebMethod()>
    Public Function DeleteTaskBySerialNumber(ByVal serialNumber As Integer, ByRef pUserID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldb_conexion As SqlConnection = Nothing

        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)

            Dim sqlCmd = New SqlCommand(DefaultSchema & "OP_WMS_DELETE_PICKING_BY_SERIAL_NUMBER", sqldb_conexion)
            sqlCmd.CommandType = CommandType.StoredProcedure
            sqlCmd.Parameters.Add(New SqlParameter("@SERIAL_NUMBER", SqlDbType.Int)).Value = serialNumber
            sqlCmd.Parameters.Add(New SqlParameter("@USER_ID", SqlDbType.VarChar, 25)).Value = pUserID

            If sqldb_conexion.State = ConnectionState.Closed Then sqldb_conexion.Open()
            sqlCmd.ExecuteNonQuery()

            Return True


        Catch ex As Exception
            pResult = ex.Message
            Return False
        Finally
            '09-Mar-11 J.R. cerrar conexiones para mejorar performance
            sqldb_conexion.Close()
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try

    End Function


    <WebMethod()>
    Public Function UpdateTaskByTaskId(ByVal taskId As Integer, ByRef newStatus As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldb_conexion As SqlConnection = Nothing

        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)

            Dim sqlCmd = New SqlCommand(DefaultSchema & "OP_WMS_UPDATE_TASK_BY_TASK_ID", sqldb_conexion)
            sqlCmd.CommandType = CommandType.StoredProcedure
            sqlCmd.Parameters.Add(New SqlParameter("@TASK_ID", SqlDbType.Int)).Value = taskId
            sqlCmd.Parameters.Add(New SqlParameter("@NEW_STATUS", SqlDbType.VarChar, 25)).Value = newStatus

            If sqldb_conexion.State = ConnectionState.Closed Then sqldb_conexion.Open()
            sqlCmd.ExecuteNonQuery()

            Return True

        Catch ex As Exception
            pResult = ex.Message
            Return False
        Finally
            '09-Mar-11 J.R. cerrar conexiones para mejorar performance
            sqldb_conexion.Close()
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try

    End Function




    <WebMethod()>
    Public Function DeleteCountingTask(ByVal taskId As Integer, ByRef user As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldb_conexion As SqlConnection = Nothing

        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)

            Dim sqlCmd = New SqlCommand(DefaultSchema & "OP_WMS_DELETE_COUNTING_TASK", sqldb_conexion)
            sqlCmd.CommandType = CommandType.StoredProcedure
            sqlCmd.Parameters.Add(New SqlParameter("@TASK_ID", SqlDbType.Int)).Value = taskId
            sqlCmd.Parameters.Add(New SqlParameter("@USER", SqlDbType.VarChar)).Value = user

            If sqldb_conexion.State = ConnectionState.Closed Then sqldb_conexion.Open()
            sqlCmd.ExecuteNonQuery()

            Return True

        Catch ex As Exception
            pResult = ex.Message
            Return False
        Finally
            '09-Mar-11 J.R. cerrar conexiones para mejorar performance
            sqldb_conexion.Close()
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try

    End Function

End Class