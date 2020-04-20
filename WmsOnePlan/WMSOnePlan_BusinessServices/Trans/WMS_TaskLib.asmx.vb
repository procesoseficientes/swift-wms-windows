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
Public Class WMS_Tasks
    Inherits System.Web.Services.WebService

    'TRANSACTION
    Public Function GetDemandDetail(ByVal pERPDoc As String, ByRef pResult As String, ByRef pTrans As SqlTransaction) As DataSet

        Dim XSQL As String = ""
        XSQL = "SELECT * FROM OP_WMS_VIEW_PENDING_DEMAND WHERE ERP_DOCUMENT = '" + pERPDoc + "'"

        Dim miscDA As New SqlCommand
        Dim miscADP As New SqlDataAdapter
        Dim miscDS As New DataSet

        miscDA.Transaction = pTrans
        miscDA.Connection = pTrans.Connection
        miscDA.CommandText = XSQL
        miscDA.CommandType = CommandType.Text

        Try
            miscADP.SelectCommand = miscDA
            miscADP.Fill(miscDS)
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR, No se encontro detalle para ese pedido " + pERPDoc
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If
    End Function


    'TRANSACTION
    Public Function GetUserForTask(ByVal pWarehouse As String, ByVal pLineID As String, ByVal pMaterial As String, ByRef pResult As String, ByRef pTrans As SqlTransaction) As DataSet

        Dim XSQL As String = ""

        '21-Jul-10 J.R. se agrego tipo tarea para saber si son usuarios de Picking o de Replenishmet
        'XSQL = "SELECT * FROM OP_WMS_FUNC_GET_USER_TO_PICK('" + pWarehouse.Trim + "','" + pLineID.ToUpper + "','" + pMaterial.Trim + "')"
        XSQL = "SELECT * FROM OP_WMS_FUNC_GET_USER_TO_PICK('" + pWarehouse.Trim + "','" + pLineID.ToUpper + "','" + pMaterial.Trim + "','PICKING')"

        'FileOpen(1, "c:\OnePlanWMS\OP_WMS_LOG_TEST.txt", OpenMode.Append, OpenAccess.ReadWrite, OpenShare.Default)
        'WriteLine(1, "GetUserForTask - " + XSQL)
        'FileClose(1)


        Dim miscDA As New SqlCommand
        Dim miscADP As New SqlDataAdapter
        Dim miscDS As New DataSet

        miscDA.Transaction = pTrans
        miscDA.Connection = pTrans.Connection
        miscDA.CommandText = XSQL
        miscDA.CommandType = CommandType.Text

        Try
            miscADP.SelectCommand = miscDA
            miscADP.Fill(miscDS)
        Catch ex As Exception
            pResult = "ERROR," + ex.Message + " - " + XSQL
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then

            pResult = "ERROR, No se encontro usuario para asignar tarea. Producto:" & pMaterial & " - " & GetProdInfo("DESC", pMaterial, pTrans)
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If
    End Function

    'TRANSACTION
    Public Function UpdateDemand(ByVal pERPDoc As String, ByVal pMaterial As String, ByVal pAssignedBy As String, ByRef pResult As String, ByRef pTrans As SqlTransaction) As Boolean
        Dim XSQL As String
        Try
            XSQL = "UPDATE OP_WMS_DEMAND_TO_PICK "
            XSQL = XSQL + " SET "
            '11-Nov-10 J.R. ya no lo definira el picker sino la persona que asigno en el monitor de tareas
            'XSQL = XSQL + " IS_ASSIGNED = 1, ASSIGNED_BY = '" + pAssignedBy + "', ASSIGNED_DATE = CURRENT_TIMESTAMP, ALLOWED_TO_PICK = 3"
            XSQL = XSQL + " IS_ASSIGNED = 1, ASSIGNED_BY = '" + pAssignedBy + "', ALLOWED_TO_PICK = 3"
            XSQL = XSQL + " WHERE ERP_DOCUMENT = '" + pERPDoc + "' AND  MATERIAL_ID = '" + pMaterial + "' "

            If ExecuteSqlTransaction(pTrans, XSQL, pResult) Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return False
        End Try

    End Function

    'NOT TRANSACTION
    Public Function MarkAsAllowedToPick(ByVal pERPDoc As String, ByVal pLINE_ID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean
        Dim XSQL As String
        Try

            XSQL = "UPDATE OP_WMS_DEMAND_TO_PICK "
            XSQL = XSQL + " SET "
            XSQL = XSQL + " ALLOWED_TO_PICK = 2, ASSIGNED_DATE = GETDATE(), ASSIGNED_TO_LINE = '" + pLINE_ID + "' "
            XSQL = XSQL + " WHERE ERP_DOCUMENT = '" + pERPDoc + "'"

            If ExecuteSqlTransaction(AppSettings(pEnvironmentName).ToString, XSQL, pResult) Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return False
        End Try

    End Function

    'TRANSACTION
    Public Function CreatePickingTask(ByVal pWAREHOUSE_SOURCE As String, ByVal pLINE_ID As String, ByVal pERPDoc As String, ByVal pERPDate As Date, ByVal pClientID As String, ByVal pTargetLocation As String, ByVal pTaskQty As Double, ByVal pMaterialCode As String, ByVal pIsDescretional As Boolean, ByVal pDiscretionalUser As String, ByVal pTaskOwner As String, ByVal pComments As String, ByVal pShouldCommit As Boolean, ByVal pShouldBeginTrans As Boolean, ByVal pTargetBin As String, ByVal pNEEDS_TO_AUDIT As Integer, ByRef pResult As String, ByRef pTrans As SqlTransaction) As Boolean

        Dim pAssignedUser As String = ""
        Dim pSourceLocation As String = ""

        Dim xserv1 As New WMS_Tasks
        Dim pPendienteAsignar As Double = 0
        Dim pInvDisponible As Double
        Dim ptmpQty As Double
        Dim pBin As String

        Dim xdata As DataSet
        Dim XSQL As String = ""
        Dim xdata1 As DataSet
        Try

            xdata = xserv1.GetLocationsForPicking(pWAREHOUSE_SOURCE, pLINE_ID, pMaterialCode, pResult, pTrans)
            Dim xrow As DataRow
            If pResult = "OK" Then

                If pIsDescretional Then
                    pAssignedUser = pDiscretionalUser
                Else
                    xdata1 = xserv1.GetUserForTask(pWAREHOUSE_SOURCE, pLINE_ID, pMaterialCode, pResult, pTrans) 'Obtiene el usuario que debe ser asignado segun el producto.
                    If pResult = "OK" Then
                        pAssignedUser = xdata1.Tables(0).Rows(0)("LOGIN_ID").ToString
                    Else
                        'pTrans.Rollback()
                        Return False
                    End If
                End If

                pPendienteAsignar = pTaskQty
                For Each xrow In xdata.Tables(0).Rows
                    pSourceLocation = xrow("SPOT_ID").ToString


                    pBin = IIf(IsDBNull(xrow("BIN_ID").ToString), "0", xrow("BIN_ID").ToString)
                    pBin = IIf(pBin <> "", xrow("BIN_ID").ToString, "0")

                    pInvDisponible = xrow("SALABLE_INVENTORY")
                    'BUSCA el inventario total de la ubicacion/bin

                    If pPendienteAsignar > 0 Then
                        If pPendienteAsignar >= pInvDisponible Then
                            ptmpQty = pInvDisponible
                        Else
                            ptmpQty = pPendienteAsignar
                        End If
                        If xserv1.HoldInventory(pWAREHOUSE_SOURCE, pSourceLocation, pBin, pMaterialCode, ptmpQty, pResult, pTrans) Then
                            If Not xserv1.CreateTask(pWAREHOUSE_SOURCE, pWAREHOUSE_SOURCE, "TAREA_PICKING", "PICKING_MANUAL", pTaskOwner, pAssignedUser, pIsDescretional, pMaterialCode, pMaterialCode, pSourceLocation, pTargetLocation, pERPDoc, pERPDate, ptmpQty, ptmpQty, pClientID, pComments, 0, 0, pBin, pTargetBin, pNEEDS_TO_AUDIT, pResult, pTrans) Then
                                'pTrans.Rollback()
                                Return False
                            Else

                                Try
                                    pPendienteAsignar = pPendienteAsignar - ptmpQty
                                Catch ex As Exception
                                    pResult = ex.Message
                                    'pTrans.Rollback()
                                    Return False
                                End Try

                            End If
                        Else
                            'pTrans.Rollback()
                            Return False
                        End If
                    End If
                Next

                pResult = "OK"

                'If pShouldCommit Then
                '    pTrans.Commit()
                'End If

                Return True

            Else
                'pResult = "ERROR, No hay ubicaciones/bins con suficiente inventario Producto : " + pMaterialCode
                'pTrans.Rollback()
                Return False
            End If


        Catch ex As Exception
            'pTrans.Rollback()
            pResult = ex.Message
            Return False
        End Try

    End Function


    '15-Jul-10 J.R. para crear tareas Reabastecimiento
    Public Function CreateReplenishmentTask(ByVal pWAREHOUSE_SOURCE As String, ByVal pWAREHOUSE_TARGET As String, ByVal pTASK_OWNER As String, ByVal pTASK_ASSIGNEDTO As String, ByVal pIS_DISCRETIONAL As Integer, ByVal pMATERIAL_CODE As String, ByVal pMATERIAL_BARCODE As String, ByVal pLOCATION_SPOT_SOURCE As String, ByVal pLOCATION_SPOT_TARGET As String, ByVal pERP_DATE As Date, ByVal pERP_QTY As Double, ByVal pQUANTITY_ASSIGNED As Double, ByVal pCLIENT_OWNER As String, ByVal pLastTransNumber As Double, ByRef pLastTaskNumber As Double, ByVal pBIN_SOURCE As String, ByRef pResult As String, ByRef pTrans As SqlTransaction) As Boolean
        'If Not xserv1.CreateReplenishmentTask(pWAREHOUSE_SOURCE, pWAREHOUSE_TARGET, "TAREA_REABASTECIMIENTO", "REABASTECIMIENTO_MANUAL", pTaskOwner, pTASK_ASSIGNEDTO, 0, pMATERIAL_CODE, pMATERIAL_BARCODE, pLOCATION_SPOT_SOURCE, pLOCATION_SPOT_TARGET, "", Today.Date, p_QTY, pQUANTITY_ASSIGNED, "", pComments, 0, 0, 0, pResult, pTrans) Then

        Dim pAssignedUser As String = ""
        Dim pSourceLocation As String = ""

        Dim xserv1 As New WMS_Tasks
        Dim pPendienteAsignar As Double = 0
        Dim pInvDisponible As Double
        Dim ptmpQty As Double
        Dim pBin As String

        Dim xdata As DataSet
        Dim XSQL As String = ""
        Try

            xdata = xserv1.GetLocationsForReplenishment(pWAREHOUSE_SOURCE, pMATERIAL_CODE, pResult, pTrans)
            Dim xrow As DataRow
            If pResult = "OK" Then

                '15-Jul-10 J.R. Aun no esta lo del discretional user
                'If pIsDescretional Then
                '    pAssignedUser = pDiscretionalUser
                'Else
                'xdata1 = xserv1.GetUserForTask(pWAREHOUSE_SOURCE, pLINE_ID, pMaterialCode, pResult, pTrans) 'Obtiene el usuario que debe ser asignado segun el producto.
                'If pResult = "OK" Then
                '    pAssignedUser = xdata1.Tables(0).Rows(0)("LOGIN_ID").ToString
                'Else
                '    'pTrans.Rollback()
                '    Return False
                'End If
                'End If

                pPendienteAsignar = pQUANTITY_ASSIGNED
                For Each xrow In xdata.Tables(0).Rows
                    pSourceLocation = xrow("SPOT_ID").ToString

                    '26-Jul-10 J.R. no se le dice que BIN debe traer porque el elije cual quiere
                    'pBin = IIf(IsDBNull(xrow("BIN_ID").ToString), "0", xrow("BIN_ID").ToString)
                    'pBin = IIf(pBin <> "", xrow("BIN_ID").ToString, "0")
                    pBin = "0"

                    pInvDisponible = xrow("SALABLE_INVENTORY")
                    'BUSCA el inventario total de la ubicacion/bin

                    If pPendienteAsignar > 0 Then
                        If pPendienteAsignar >= pInvDisponible Then
                            ptmpQty = pInvDisponible
                        Else
                            ptmpQty = pPendienteAsignar
                        End If
                        If xserv1.HoldInventory(pWAREHOUSE_SOURCE, pSourceLocation, pBin, pMATERIAL_CODE, ptmpQty, pResult, pTrans) Then
                            'If Not xserv1.CreateTask(pWAREHOUSE_SOURCE, pWAREHOUSE_SOURCE, "TAREA_PICKING", "PICKING_MANUAL", pTaskOwner, pAssignedUser, pIsDescretional, pMaterialCode, pMaterialCode, pSourceLocation, pTargetLocation, pERPDoc, pERPDate, ptmpQty, ptmpQty, pClientID, pComments, 0, 0, CDbl(pBin), pResult, pTrans) Then
                            If Not xserv1.CreateTask(pWAREHOUSE_SOURCE, pWAREHOUSE_TARGET, "TAREA_REABASTECIMIENTO", "REABASTECIMIENTO_MANUAL", pTASK_OWNER, pTASK_ASSIGNEDTO, pIS_DISCRETIONAL, pMATERIAL_CODE, pMATERIAL_BARCODE, pSourceLocation, pLOCATION_SPOT_TARGET, "", pERP_DATE, ptmpQty, ptmpQty, pCLIENT_OWNER, "TAREA CREADA DESDE HANDHELD", pLastTransNumber, pLastTaskNumber, CDbl(pBin), "0", 0, pResult, pTrans) Then
                                'pTrans.Rollback()
                                Return False
                            Else
                                Try
                                    pPendienteAsignar = pPendienteAsignar - ptmpQty
                                Catch ex As Exception
                                    pResult = ex.Message
                                    'pTrans.Rollback()
                                    Return False
                                End Try

                            End If
                        Else
                            'pTrans.Rollback()
                            Return False
                        End If
                    End If
                Next

                pResult = "OK"

                'If pShouldCommit Then
                '    pTrans.Commit()
                'End If

                Return True

            Else
                'pResult = "ERROR, No hay ubicaciones/bins con suficiente inventario Producto : " + pMaterialCode
                'pTrans.Rollback()
                Return False
            End If


        Catch ex As Exception
            'pTrans.Rollback()
            pResult = ex.Message
            Return False
        End Try

    End Function

    '25-Jul-10 J.R. para crear tareas Reubicacion
    Public Function CreateRelocationTask(ByVal pWAREHOUSE_SOURCE As String, ByVal pWAREHOUSE_TARGET As String, ByVal pTASK_OWNER As String, ByVal pTASK_ASSIGNEDTO As String, ByVal pIS_DISCRETIONAL As Integer, ByVal pMATERIAL_CODE As String, ByVal pMATERIAL_BARCODE As String, ByVal pLOCATION_SPOT_SOURCE As String, ByVal pLOCATION_SPOT_TARGET As String, ByVal pERP_DATE As Date, ByVal pERP_QTY As Double, ByVal pQUANTITY_ASSIGNED As Double, ByVal pCLIENT_OWNER As String, ByVal pLastTransNumber As Double, ByRef pLastTaskNumber As Double, ByVal pBIN_SOURCE As String, ByRef pResult As String, ByRef pTrans As SqlTransaction) As Boolean

        Dim pAssignedUser As String = ""
        Dim pSourceLocation As String = ""

        Dim xserv1 As New WMS_Tasks

        Try

            If xserv1.CreateTask(pWAREHOUSE_SOURCE, pWAREHOUSE_TARGET, "TAREA_REUBICACION", "REUBICACION_MANUAL", pTASK_OWNER, pTASK_ASSIGNEDTO, pIS_DISCRETIONAL, pMATERIAL_CODE, pMATERIAL_BARCODE, pLOCATION_SPOT_SOURCE, pLOCATION_SPOT_TARGET, "", pERP_DATE, pERP_QTY, pQUANTITY_ASSIGNED, pCLIENT_OWNER, "TAREA CREADA DESDE HANDHELD", pLastTransNumber, pLastTaskNumber, pBIN_SOURCE, "0", 0, pResult, pTrans) Then
                pResult = "OK"
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            'pTrans.Rollback()
            pResult = ex.Message
            Return False
        End Try

    End Function

    Public Function GetLocationsForPicking(ByVal pWarehouse As String, ByVal pLineID As String, ByVal pMaterial As String, ByRef pResult As String, ByRef pTrans As SqlTransaction) As DataSet

        Dim XSQL As String = ""
        XSQL = "SELECT * FROM OP_WMS_FUNC_GET_BEST_LOCATION_TO_PICK('" + pWarehouse.Trim + "','" + pLineID + "','" + pMaterial.Trim + "')"

        Dim miscDA As New SqlCommand
        Dim miscADP As New SqlDataAdapter
        Dim miscDS As New DataSet

        miscDA.Transaction = pTrans
        miscDA.Connection = pTrans.Connection
        miscDA.CommandText = XSQL
        miscDA.CommandType = CommandType.Text

        Try
            miscADP.SelectCommand = miscDA
            miscADP.Fill(miscDS)
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR, Producto " + pMaterial + " No tiene inventario disponible. bodega " + pWarehouse
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If
    End Function

    '15-Jul-10 J.R. para crear tareas Reabastecimiento
    Public Function GetLocationsForReplenishment(ByVal pWarehouse As String, ByVal pMaterial As String, ByRef pResult As String, ByRef pTrans As SqlTransaction) As DataSet

        Dim XSQL As String = ""
        XSQL = "SELECT * FROM OP_WMS_FUNC_GET_BEST_LOCATION_TO_REPLENISH('" + pWarehouse.Trim + "','" + pMaterial.Trim + "') ORDER BY SALABLE_INVENTORY "

        Dim miscDA As New SqlCommand
        Dim miscADP As New SqlDataAdapter
        Dim miscDS As New DataSet

        miscDA.Transaction = pTrans
        miscDA.Connection = pTrans.Connection
        miscDA.CommandText = XSQL
        miscDA.CommandType = CommandType.Text

        Try
            miscADP.SelectCommand = miscDA
            miscADP.Fill(miscDS)
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR, Producto " + pMaterial + " No tiene inventario disponible. bodega " + pWarehouse
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If
    End Function

    '01-Ago-10 J.R. selecciona las ubicaciones de storagepicking para mover de Standby hacia alli
    Public Function GetLocationsForStoragePicking(ByVal pWarehouse As String, ByVal pMaterial As String, ByVal pStandByLocation As String, ByRef pResult As String, ByRef pTrans As SqlTransaction) As DataSet

        Dim XSQL As String = ""
        XSQL = "SELECT * FROM OP_WMS_FUNC_GET_BEST_LOCATION_TO_REPLENISH('" + pWarehouse.Trim + "','" + pMaterial.Trim + "') WHERE SPOT_ID <> '" + pStandByLocation.Trim + "' ORDER BY SALABLE_INVENTORY "

        Dim miscDA As New SqlCommand
        Dim miscADP As New SqlDataAdapter
        Dim miscDS As New DataSet

        miscDA.Transaction = pTrans
        miscDA.Connection = pTrans.Connection
        miscDA.CommandText = XSQL
        miscDA.CommandType = CommandType.Text

        Try
            miscADP.SelectCommand = miscDA
            miscADP.Fill(miscDS)
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR, Producto " + pMaterial + " No tiene inventario disponible. bodega " + pWarehouse
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If
    End Function

    Public Function HoldInventory(ByVal pWAREHOUSE As String, ByVal pLOCATION_SPOT_TARGET As String, ByVal pBIN As String, ByVal pMATERIAL_CODE As String, ByVal pQTY As Double, ByRef pResult As String, ByRef pTrans As SqlTransaction) As Boolean
        Dim XSQL As String = ""
        Dim pSalableItem As Double = 0
        Try

            Dim xdata As DataSet
            xdata = GetItemSalable(pWAREHOUSE, pLOCATION_SPOT_TARGET, pBIN, pMATERIAL_CODE, pResult, pTrans)
            If pResult = "OK" Then
                pSalableItem = xdata.Tables(0).Rows(0)("SALABLE_QTY")
                If pSalableItem <= 0 Then
                    pResult = "ERROR,Cantidad disponible agotada"
                    Return False
                Else
                    If pSalableItem < pQTY Then
                        pResult = "ERROR,No se puede reservar la cantidad " & pQTY & " debido a que excede la cantidad disponible registrada  " & pSalableItem
                        Return False
                    End If
                End If
            End If

            XSQL = "UPDATE OP_WMS_INVENTORY "
            XSQL = XSQL + " SET "
            XSQL = XSQL + " QUANTITY_ON_HOLD = QUANTITY_ON_HOLD + " & pQTY
            XSQL = XSQL + " WHERE WAREHOUSE_ID = '" + pWAREHOUSE + "' AND "
            XSQL = XSQL + " SPOT_ID = '" + pLOCATION_SPOT_TARGET + "' AND "
            XSQL = XSQL + IIf(pBIN = "0", " BIN_ID IS NULL AND ", " BIN_ID = " + pBIN + " AND ")

            XSQL = XSQL + " MATERIAL_ID = '" + pMATERIAL_CODE + "' "

            If ExecuteSqlTransaction(pTrans, XSQL, pResult) Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            pResult = ex.Message
            Return False
        End Try

    End Function

    'TRANSACTION
    Public Function CreateTask(ByVal pWAREHOUSE_SOURCE As String, ByVal pWAREHOUSE_TARGET As String, ByVal pTASK_TYPE As String, ByVal pTASK_SUBTYPE As String, ByVal pTASK_OWNER As String, ByVal pTASK_ASSIGNEDTO As String, ByVal pIS_DISCRETIONAL As Integer, ByVal pMATERIAL_CODE As String, ByVal pMATERIAL_BARCODE As String, ByVal pLOCATION_SPOT_SOURCE As String, ByVal pLOCATION_SPOT_TARGET As String, ByVal pERP_LEGACY_ID As String, ByVal pERP_DATE As Date, ByVal pERP_QTY As Double, ByVal pQUANTITY_ASSIGNED As Double, ByVal pCLIENT_OWNER As String, ByVal pTASK_COMMENTS As String, ByVal pLastTransNumber As Double, ByRef pLastTaskNumber As Double, ByVal pBIN_SOURCE As String, ByVal pBIN_TARGET As String, ByVal pNEEDS_TO_AUDIT As String, ByRef pResult As String, ByRef pTrans As SqlTransaction) As Boolean

        Dim XSQL As String = ""
        Try
            XSQL = "INSERT INTO OP_WMS_TASK_LIST("
            XSQL = XSQL + ""
            XSQL = XSQL + "ASSIGNED_DATE,"
            XSQL = XSQL + "TASK_TYPE,"
            XSQL = XSQL + "TASK_SUBTYPE,"
            XSQL = XSQL + "TASK_OWNER,"
            XSQL = XSQL + "TASK_ASSIGNEDTO,"
            XSQL = XSQL + "IS_COMPLETED,"
            XSQL = XSQL + "IS_DISCRETIONAL,"
            XSQL = XSQL + "MATERIAL_CODE,"
            XSQL = XSQL + "MATERIAL_BARCODE,"
            XSQL = XSQL + "MATERIAL_DESCRIPTION,"
            XSQL = XSQL + "WAREHOUSE_SOURCE,"
            XSQL = XSQL + "WAREHOUSE_TARGET,"
            XSQL = XSQL + "LOCATION_SPOT_SOURCE,"
            XSQL = XSQL + "LOCATION_SPOT_TARGET,"
            XSQL = XSQL + "ERP_LEGACY_ID,"
            XSQL = XSQL + "ERP_DATE,"
            XSQL = XSQL + "ERP_QTY,"
            XSQL = XSQL + "QUANTITY_PENDING,"
            XSQL = XSQL + "QUANTITY_ASSIGNED,"
            XSQL = XSQL + "CLIENT_OWNER,"
            XSQL = XSQL + "CLIENT_NAME,"
            XSQL = XSQL + "PICKING_STARTED_DATE,"
            XSQL = XSQL + "PICKING_FINISHED_DATE,"
            XSQL = XSQL + "TASK_COMMENTS, TRANS_OWNER, BIN_SOURCE, BIN_TARGET, NEEDS_TO_AUDIT, CLIENT_ROUTE)"
            XSQL = XSQL + "VALUES ("
            XSQL = XSQL + "CURRENT_TIMESTAMP,"
            XSQL = XSQL + "'" + pTASK_TYPE + "',"
            XSQL = XSQL + "'" + pTASK_SUBTYPE + "',"
            XSQL = XSQL + "'" + pTASK_OWNER + "',"
            XSQL = XSQL + "'" + pTASK_ASSIGNEDTO + "',"
            XSQL = XSQL + "0,"
            XSQL = XSQL + pIS_DISCRETIONAL.ToString + ","
            XSQL = XSQL + "'" + pMATERIAL_CODE + "',"
            XSQL = XSQL + "'" + pMATERIAL_BARCODE + "',"
            XSQL = XSQL + "'" + GetProdInfo("DESC", pMATERIAL_BARCODE, pTrans) + "',"
            XSQL = XSQL + "'" + pWAREHOUSE_SOURCE + "',"
            XSQL = XSQL + "'" + pWAREHOUSE_TARGET + "',"
            XSQL = XSQL + "'" + pLOCATION_SPOT_SOURCE + "',"
            XSQL = XSQL + "'" + pLOCATION_SPOT_TARGET + "',"
            XSQL = XSQL + "'" + pERP_LEGACY_ID + "',"
            XSQL = XSQL + IIf(IsValidDate(pERP_DATE), "'" + pERP_DATE.ToString("yyyy/MM/dd") + "',", "NULL")
            XSQL = XSQL + "" + pERP_QTY.ToString + ","
            XSQL = XSQL + pQUANTITY_ASSIGNED.ToString + "," ' PENDING = ASSIGNED WHEN CREATED.
            XSQL = XSQL + pQUANTITY_ASSIGNED.ToString + ","
            XSQL = XSQL + "'" + pCLIENT_OWNER + "',"
            XSQL = XSQL + "'" + GetClientName(pCLIENT_OWNER, pTrans) + "',"
            XSQL = XSQL + "CURRENT_TIMESTAMP,"
            XSQL = XSQL + "NULL,"
            XSQL = XSQL + "'" + pTASK_COMMENTS + "',"
            XSQL = XSQL + "" + pLastTransNumber.ToString + ","
            XSQL = XSQL & pBIN_SOURCE & ","
            XSQL = XSQL & pBIN_TARGET & ","
            XSQL = XSQL & pNEEDS_TO_AUDIT & ",'" + GetRouteByERP(pERP_LEGACY_ID, pTrans, pResult) + "')"

            If ExecuteSqlTransaction(pTrans, XSQL, pResult) Then
                Dim xset As DataSet = GetLastTask(pResult, pTrans)
                pLastTaskNumber = xset.Tables(0).Rows(0)("LAST_TASK_ID")
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            pResult = ex.Message
            Return False
        End Try

    End Function
    Public Function GetRouteByERP(ByVal pERP_LEGACY_ID As String, ByRef pTrans As SqlTransaction, ByRef pResult As String) As String
        Try

            Dim XSQL As String = ""
            XSQL = "SELECT CLIENT_ROUTE FROM OP_WMS_DEMAND_TO_PICK WHERE ERP_DOCUMENT = '" + pERP_LEGACY_ID + "'"

            Dim miscDA As New SqlCommand
            Dim miscADP As New SqlDataAdapter
            Dim miscDS As New DataSet

            miscDA.Transaction = pTrans
            miscDA.Connection = pTrans.Connection
            miscDA.CommandText = XSQL
            miscDA.CommandType = CommandType.Text

            Try
                miscADP.SelectCommand = miscDA
                miscADP.Fill(miscDS)
            Catch ex As Exception
                pResult = "ERROR," + ex.Message
                Return Nothing
            End Try
            If miscDS.Tables(0).Rows.Count <= 0 Then
                pResult = "ERROR, No se encontro ruta para el pedido " & pERP_LEGACY_ID
                Return Nothing
            Else
                pResult = "OK"
                Return miscDS.Tables(0).Rows(0)("CLIENT_ROUTE")
            End If
        Catch ex As Exception
            Return "N/A"
        End Try
    End Function
    'TRANSACTION
    Public Function GetLastTask(ByRef pResult As String, ByRef pTrans As SqlTransaction) As DataSet

        Dim XSQL As String = ""
        XSQL = "SELECT IDENT_CURRENT('OP_WMS_TASK_LIST') AS LAST_TASK_ID"

        Dim miscDA As New SqlCommand
        Dim miscADP As New SqlDataAdapter
        Dim miscDS As New DataSet

        miscDA.Transaction = pTrans
        miscDA.Connection = pTrans.Connection
        miscDA.CommandText = XSQL
        miscDA.CommandType = CommandType.Text

        Try
            miscADP.SelectCommand = miscDA
            miscADP.Fill(miscDS)
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR, No se encontro la ultima tarea creada"
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If
    End Function

    '28-Jul-10 J.R. se agrego paramentro pValidateIfIsPending para buscar solo tareas vivas (no completadas o canceladas).  
    'TRANSACTION
    Public Function GetTaskInfo(ByVal pTaskID As Double, ByRef pResult As String, ByRef pTrans As SqlTransaction, Optional ByVal pValidateIfIsPending As Boolean = False) As DataSet

        Dim XSQL As String = ""
        XSQL = "SELECT * FROM OP_WMS_TASK_LIST WHERE SERIAL_NUMBER = " & pTaskID

        '28-Jul-10 J.R. Este parametro viene en True solo para metodos ProcesarPicking, Reabastecimiento y Reubicacion. para no procesar tareas canceladas
        If pValidateIfIsPending Then
            XSQL = XSQL + " AND IS_CANCELED = 0 AND IS_COMPLETED = 0 AND IS_PAUSED = 0 "
        End If

        'FileOpen(1, "c:\OnePlanWMS\OP_WMS_LOG_TEST.txt", OpenMode.Append, OpenAccess.ReadWrite, OpenShare.Default)
        'WriteLine(1, "GetTaskInfo - " + XSQL)
        'FileClose(1)

        Dim miscDA As New SqlCommand
        Dim miscADP As New SqlDataAdapter
        Dim miscDS As New DataSet

        miscDA.Transaction = pTrans
        miscDA.Connection = pTrans.Connection
        miscDA.CommandText = XSQL
        miscDA.CommandType = CommandType.Text

        Try
            miscADP.SelectCommand = miscDA
            miscADP.Fill(miscDS)
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR, No se encontro tarea o fue anulada, pausada o reasignada " & pTaskID
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If
    End Function

    'TRANSACTION
    Public Function GetAvailableTasks(ByVal pERPDocument As String, ByRef pResult As String, ByRef pTrans As SqlTransaction) As DataSet

        Dim XSQL As String = ""
        XSQL = "SELECT * FROM OP_WMS_TASKLIST WHERE ERP_LEGACY_ID = '" + pERPDocument + "' AND IS_CANCELED = 0"

        Dim miscDA As New SqlCommand
        Dim miscADP As New SqlDataAdapter
        Dim miscDS As New DataSet

        miscDA.Transaction = pTrans
        miscDA.Connection = pTrans.Connection
        miscDA.CommandText = XSQL
        miscDA.CommandType = CommandType.Text

        Try
            miscADP.SelectCommand = miscDA
            miscADP.Fill(miscDS)
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR, No hay tareas disponibles para el documento: " + pERPDocument
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If
    End Function


    'TRANSACTION
    Public Function GetItemSalable(ByVal pWarehouse As String, ByVal pLocation As String, ByVal pBin As String, ByVal pMaterial As String, ByRef pResult As String, ByRef pTrans As SqlTransaction) As DataSet

        Dim XSQL As String = ""

        If pBin = "0" Then
            XSQL = "SELECT (QUANTITY_UNITS-QUANTITY_ON_HOLD) AS SALABLE_QTY FROM OP_WMS_INVENTORY WHERE WAREHOUSE_ID = '" + pWarehouse + "' AND SPOT_ID = '" + pLocation + "' AND MATERIAL_ID = '" + pMaterial + "'"
        Else
            XSQL = "SELECT (QUANTITY_UNITS-QUANTITY_ON_HOLD) AS SALABLE_QTY FROM OP_WMS_INVENTORY WHERE WAREHOUSE_ID = '" + pWarehouse + "' AND SPOT_ID = '" + pLocation + "' AND BIN_ID = '" + pBin + "' AND MATERIAL_ID = '" + pMaterial + "'"
        End If

        Dim miscDA As New SqlCommand
        Dim miscADP As New SqlDataAdapter
        Dim miscDS As New DataSet

        miscDA.Transaction = pTrans
        miscDA.Connection = pTrans.Connection
        miscDA.CommandText = XSQL
        miscDA.CommandType = CommandType.Text

        Try
            miscADP.SelectCommand = miscDA
            miscADP.Fill(miscDS)
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR, No se encontro inventario para esa bodega/ubicacion/producto"
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If
    End Function

    '27-Jul-10 J.R. parametro optional pCheckERPDoc para verificar ERP_DOC o no, si viene de picking lo hace, si viene de reabast o reubicacion NO
    'Public Function AdjustBinInventory(ByVal pTaskNumber As Double, ByVal pERP_DOC As String, ByVal pBIN_TARGET As String, ByVal pMATERIAL As String, ByVal pQTY As Double, ByVal pLOGIN As String, ByRef pResult As String, ByRef pTrans As SqlTransaction, Optional ByVal pCheckERPDoc As Boolean = True) As Boolean
    Public Function AdjustBinInventory(ByVal pTaskNumber As Double, ByVal pERP_DOC As String, ByVal pBIN_TARGET As String, ByVal pMATERIAL As String, ByVal pQTY As Double, ByVal pLOGIN As String, ByRef pResult As String, ByRef pTrans As SqlTransaction, Optional ByVal pCheckERPDoc As Boolean = True, Optional ByVal pRemoveRecord As Boolean = False) As Boolean
        Try
            Dim pSQL As String = ""

            Try
                'verify that the bin it's not relatead to any previous erp document, otherwise mark error.

                '27-Jul-10 J.R. parametro optional para verificar ERP_DOC o no, si viene de picking lo hace, si viene de reabast o reubicacion NO
                If pCheckERPDoc Then

                    pSQL = "SELECT * FROM OP_WMS_INV_X_BIN WHERE BIN_ID='" + pBIN_TARGET + "'"

                    Dim miscDA1 As New SqlCommand
                    Dim miscADP1 As New SqlDataAdapter
                    Dim miscDS1 As New DataSet

                    miscDA1.Transaction = pTrans
                    miscDA1.Connection = pTrans.Connection
                    miscDA1.CommandText = pSQL
                    miscDA1.CommandType = CommandType.Text

                    Try
                        miscADP1.SelectCommand = miscDA1
                        miscADP1.Fill(miscDS1)
                    Catch ex As Exception
                        pResult = "ERROR (@AdjInv): " + ex.Message
                        Return False
                    End Try

                    If miscDS1.Tables(0).Rows.Count >= 1 Then
                        If miscDS1.Tables(0).Rows(0)("LAST_ERP_DOC") <> pERP_DOC Then
                            pResult = "BIN ya tiene el pedido : " + miscDS1.Tables(0).Rows(0)("LAST_ERP_DOC") + " relacionado (" & pERP_DOC & ")"
                            Return False
                        End If
                    End If

                End If  '27-Jul-10 J.R. parametro optional para verificar ERP_DOC o no, si viene de picking lo hace, si viene de reabast o reubicacion NO

                'IF INVENTORY EXISTS THEN UPDATE IT.
                pSQL = "SELECT * FROM OP_WMS_INV_X_BIN WHERE BIN_ID='" + pBIN_TARGET + "' AND MATERIAL_ID = '" + pMATERIAL + "' "

                Dim miscDA As New SqlCommand
                Dim miscADP As New SqlDataAdapter
                Dim miscDS As New DataSet

                miscDA.Transaction = pTrans
                miscDA.Connection = pTrans.Connection
                miscDA.CommandText = pSQL
                miscDA.CommandType = CommandType.Text

                Try
                    miscADP.SelectCommand = miscDA
                    miscADP.Fill(miscDS)

                Catch ex As Exception
                    pResult = "ERROR (@AdjInv): " + ex.Message
                    Return False
                End Try

                If miscDS.Tables(0).Rows.Count >= 1 Then


                    '27-Jul-10 J.R. borra el registro cuando llega a 0, esto sirve cuando se llama desde ProcesarTareaReubicacion por si se hacen reubicaciones parciales para que cuando llegue a 0 borre la linea
                    'aqui deberia entrar solo cuando es ProcesaReubicacion
                    If pRemoveRecord Then

                        If miscDS.Tables(0).Rows(0)("QTY") - pQTY <= 0 Then 'Si reubico lo ultimo que tenia el bin, entonces quedo vacio y hay que borrarlo de la tabla

                            pSQL = "DELETE FROM OP_WMS_INV_X_BIN WHERE BIN_ID = " + pBIN_TARGET

                        Else  'sino, solo le resta lo que reubico

                            pSQL = "UPDATE OP_WMS_INV_X_BIN SET QTY = QTY - " & pQTY & " , LAST_TASK_ID = " & pTaskNumber & ", LAST_LOGIN = '" + pLOGIN + "'"
                            pSQL = pSQL + "   WHERE BIN_ID = " & pBIN_TARGET & " AND MATERIAL_ID = '" + pMATERIAL + "' "

                        End If

                    Else  '27-Jul-10 J.R. Si viene de picking siempre entra aqui

                        'then update inventory
                        pSQL = "UPDATE OP_WMS_INV_X_BIN SET QTY = QTY + " & pQTY & " , LAST_TASK_ID = " & pTaskNumber & ", LAST_LOGIN = '" + pLOGIN + "'"
                        pSQL = pSQL + "   WHERE BIN_ID = " & pBIN_TARGET & " AND MATERIAL_ID = '" + pMATERIAL + "' "

                    End If

                Else

                    'then create inventory
                    pSQL = "INSERT INTO OP_WMS_INV_X_BIN"
                    pSQL = pSQL + " (BIN_ID"
                    pSQL = pSQL + ",MATERIAL_ID"
                    pSQL = pSQL + ",MATERIAL_NAME"
                    pSQL = pSQL + ",QTY"
                    pSQL = pSQL + ",LAST_LOGIN"
                    pSQL = pSQL + ",LAST_DATETIME"
                    pSQL = pSQL + ",LAST_TASK_ID"
                    pSQL = pSQL + ",LAST_ERP_DOC)"
                    pSQL = pSQL + " VALUES"
                    pSQL = pSQL + "(" + pBIN_TARGET
                    pSQL = pSQL + ",'" + pMATERIAL + "'"
                    pSQL = pSQL + ",'" + GetProdInfo("DESC", pMATERIAL, pTrans) + "'"
                    pSQL = pSQL + "," & pQTY
                    pSQL = pSQL + ",'" + pLOGIN + "'"
                    pSQL = pSQL + ",CURRENT_TIMESTAMP"
                    pSQL = pSQL + "," & pTaskNumber
                    pSQL = pSQL + ",'" + pERP_DOC + "')"
                End If
                If Not ExecuteSqlTransaction(pTrans, pSQL, pResult) Then
                    Return False
                Else
                    Return True
                End If

            Catch ex As Exception
                pResult = ex.Message
                Return False
            End Try

        Catch ex As Exception
            pResult = "ERROR (@AdjInv.StartTrans):" + ex.Message
            Return False
        End Try

    End Function


    '21-Ene-11 J.R Se agrego un While para hacer 10 intentos cuando no puede completar el update (por deadlock) y si no se sale
    Public Function UpdatePickingTask(ByVal pTaskNumber As Double, ByVal pLastTrans As Integer, ByVal pBIN_TARGET As String, ByVal pMATERIAL_CODE As String, ByVal pQTY As Double, ByRef pResult As String, ByRef pTrans As SqlTransaction) As Boolean
        Dim XSQL As String = ""
        Dim pQuantityPending As Double = 0

        Dim xcmd As New SqlCommand
        Dim xParm As New SqlParameter


        Try

            Dim iAttempts As Integer = 0
            Do While iAttempts <= 9

                xcmd.Connection = pTrans.Connection
                xcmd.Transaction = pTrans
                xcmd.CommandText = "OP_WMS_SP_UPDATE_PICKING_TASK"
                xcmd.CommandType = CommandType.StoredProcedure

                xcmd.Parameters.AddWithValue("@pQTY", pQTY)
                xcmd.Parameters.AddWithValue("@pLAST_TRANS", pLastTrans)
                xcmd.Parameters.AddWithValue("@pBIN_TARGET", CInt(pBIN_TARGET))
                xcmd.Parameters.AddWithValue("@pTASK_NUMBER", pTaskNumber)
                xcmd.Parameters.AddWithValue("@pOUTPUT", 0)
                xcmd.Parameters("@pOUTPUT").Direction = ParameterDirection.Output

                Try

                    xcmd.ExecuteNonQuery()
                    pResult = "OK"
                    Return True

                Catch ex As Exception

                    pResult = "OP_WMS_SP_UPDATE_PICKING_TASK failed!"
                    iAttempts += 1

                End Try
                Return True
                Exit Function

            Loop

            If pResult <> "OK" Then
                Return False
            End If

            '21-Ene-11 J.R. Se quito porque se maneja arriba, se hacen 10 intentos y si no puede entonces da el error
            'If xcmd.Parameters("@pOUTPUT").Value = 1 Then
            '    Return True
            'Else
            '    pResult = "OP_WMS_SP_UPDATE_PICKING_TASK failed!"
            '    Return False
            'End If

            ''27-Oct-10 J.R. tampoco funciono, sigue dando deadlocks, se dejo ahora en un SP (arriba)
            'Dim xserv1 As New WMS_Tasks
            'Dim xdata2 As New DataSet
            'xdata2 = xserv1.GetTaskInfo(pTaskNumber, pResult, pTrans)
            'If pResult = "OK" Then

            '    pQuantityPending = xdata2.Tables(0).Rows(0)("QUANTITY_PENDING")
            '    pQuantityPending = pQuantityPending - pQTY

            '    XSQL = "UPDATE OP_WMS_TASK_LIST SET "
            '    XSQL = XSQL + " QUANTITY_PENDING = QUANTITY_PENDING - " & pQTY
            '    XSQL = XSQL + ", TRANS_OWNER = " & pLastTrans
            '    XSQL = XSQL + ", BIN_TARGET = " & pBIN_TARGET

            '    If pQuantityPending = 0 Then

            '        XSQL = XSQL + ", IS_COMPLETED = 1 "
            '        XSQL = XSQL + ", PICKING_FINISHED_DATE = CURRENT_TIMESTAMP "

            '    End If

            '    XSQL = XSQL + " WHERE SERIAL_NUMBER  = " & pTaskNumber
            '    'XSQL = XSQL + " AND  MATERIAL_CODE = '" + pMATERIAL_CODE + "' "

            '    If Not ExecuteSqlTransaction(pTrans, XSQL, pResult) Then
            '        'FileOpen(1, "c:\OnePlanWMS\OP_WMS_LOG_TEST.txt", OpenMode.Append, OpenAccess.ReadWrite, OpenShare.Default)
            '        'WriteLine(1, "UpdatePickingTask - " + pResult)
            '        'FileClose(1)
            '        Return False
            '    Else
            '        Return True
            '    End If

            'Else
            '    Return False
            'End If

            '26-Oct-10 J.R. se mejoro la forma de hacer este update ya que da error por deadlock
            'XSQL = "UPDATE OP_WMS_TASK_LIST "
            'XSQL = XSQL + " SET "
            'XSQL = XSQL + " QUANTITY_PENDING = QUANTITY_PENDING - " & pQTY
            'XSQL = XSQL + " ,TRANS_OWNER = " & pLastTrans
            'XSQL = XSQL + " ,BIN_TARGET = " & pBIN_TARGET
            'XSQL = XSQL + " WHERE SERIAL_NUMBER  = " & pTaskNumber
            'XSQL = XSQL + " AND  MATERIAL_CODE = '" + pMATERIAL_CODE + "' "

            'If ExecuteSqlTransaction(pTrans, XSQL, pResult) Then

            '    Dim xserv1 As New WMS_Tasks
            '    Dim xdata2 As New DataSet
            '    xdata2 = xserv1.GetTaskInfo(pTaskNumber, pResult, pTrans)
            '    If pResult = "OK" Then
            '        If xdata2.Tables(0).Rows(0)("QUANTITY_PENDING") = 0 Then
            '            XSQL = "UPDATE OP_WMS_TASK_LIST "
            '            XSQL = XSQL + " SET "
            '            '11-Ago-10 J.R. esta tabla no tiene campo Allowed_to_pick
            '            'XSQL = XSQL + " IS_COMPLETED = 1, ALLOWED_TO_PICK = NULL "
            '            XSQL = XSQL + " IS_COMPLETED = 1, "
            '            XSQL = XSQL + " PICKING_FINISHED_DATE = CURRENT_TIMESTAMP "
            '            XSQL = XSQL + " WHERE SERIAL_NUMBER  = " & pTaskNumber
            '            XSQL = XSQL + " AND  MATERIAL_CODE = '" + pMATERIAL_CODE + "' "
            '            If Not ExecuteSqlTransaction(pTrans, XSQL, pResult) Then
            '                'FileOpen(1, "c:\OnePlanWMS\OP_WMS_LOG_TEST.txt", OpenMode.Append, OpenAccess.ReadWrite, OpenShare.Default)
            '                'WriteLine(1, "UpdatePickingTask - " + pResult)
            '                'FileClose(1)
            '                Return False
            '            Else

            '            End If
            '        End If
            '    End If
            '    Return True
            'Else
            '    Return False
            'End If
        Catch ex As Exception
            pResult = ex.Message
            'FileOpen(1, "c:\OnePlanWMS\OP_WMS_LOG_TEST.txt", OpenMode.Append, OpenAccess.ReadWrite, OpenShare.Default)
            'WriteLine(1, "UpdatePickingTask - " + pResult)
            'WriteLine(1, "UpdatePickingTask XSQL - " + XSQL)
            'FileClose(1)
            Return False
        End Try
        Return True
    End Function

    '23-Jul-10 J.R. actualiza tarea de reabastecimiento luego de procesarla
    Public Function UpdateReplenishmentTask(ByVal pTaskNumber As Double, ByVal pLastTrans As Integer, ByVal pBIN_TARGET As String, ByVal pMATERIAL_CODE As String, ByVal pQTY As Double, ByRef pResult As String, ByRef pTrans As SqlTransaction) As Boolean
        Dim XSQL As String = ""
        Dim pSalableItem As Double = 0
        Try

            XSQL = "UPDATE OP_WMS_TASK_LIST "
            XSQL = XSQL + " SET "
            XSQL = XSQL + " QUANTITY_PENDING = QUANTITY_PENDING - " & pQTY
            XSQL = XSQL + " ,TRANS_OWNER = " & pLastTrans
            XSQL = XSQL + " ,BIN_TARGET = " & pBIN_TARGET
            XSQL = XSQL + " WHERE SERIAL_NUMBER  = " & pTaskNumber
            XSQL = XSQL + " AND  MATERIAL_CODE = '" + pMATERIAL_CODE + "' "

            If ExecuteSqlTransaction(pTrans, XSQL, pResult) Then

                Dim xserv1 As New WMS_Tasks
                Dim xdata2 As New DataSet
                xdata2 = xserv1.GetTaskInfo(pTaskNumber, pResult, pTrans)
                If pResult = "OK" Then
                    If xdata2.Tables(0).Rows(0)("QUANTITY_PENDING") = 0 Then
                        XSQL = "UPDATE OP_WMS_TASK_LIST "
                        XSQL = XSQL + " SET "
                        XSQL = XSQL + " IS_COMPLETED = 1 "
                        XSQL = XSQL + " WHERE SERIAL_NUMBER  = " & pTaskNumber
                        XSQL = XSQL + " AND  MATERIAL_CODE = '" + pMATERIAL_CODE + "' "
                        If Not ExecuteSqlTransaction(pTrans, XSQL, pResult) Then
                            Return False
                        End If
                    End If
                End If
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            pResult = ex.Message
            Return False
        End Try

    End Function

    '26-Jul-10 J.R. actualiza tarea de reubicacion luego de procesarla
    Public Function UpdateRelocationTask(ByVal pTaskNumber As Double, ByVal pLastTrans As Integer, ByVal pBIN_TARGET As String, ByVal pMATERIAL_CODE As String, ByVal pQTY As Double, ByRef pResult As String, ByRef pTrans As SqlTransaction) As Boolean
        Dim XSQL As String = ""
        Dim pSalableItem As Double = 0
        Try

            XSQL = "UPDATE OP_WMS_TASK_LIST "
            XSQL = XSQL + " SET "
            XSQL = XSQL + " QUANTITY_PENDING = QUANTITY_PENDING - " & pQTY
            XSQL = XSQL + " ,TRANS_OWNER = " & pLastTrans
            XSQL = XSQL + " ,BIN_TARGET = " & pBIN_TARGET
            XSQL = XSQL + " WHERE SERIAL_NUMBER  = " & pTaskNumber
            XSQL = XSQL + " AND  MATERIAL_CODE = '" + pMATERIAL_CODE + "' "

            If ExecuteSqlTransaction(pTrans, XSQL, pResult) Then

                Dim xserv1 As New WMS_Tasks
                Dim xdata2 As New DataSet
                xdata2 = xserv1.GetTaskInfo(pTaskNumber, pResult, pTrans)
                If pResult = "OK" Then
                    If xdata2.Tables(0).Rows(0)("QUANTITY_PENDING") = 0 Then
                        XSQL = "UPDATE OP_WMS_TASK_LIST "
                        XSQL = XSQL + " SET "
                        XSQL = XSQL + " IS_COMPLETED = 1 "
                        XSQL = XSQL + " WHERE SERIAL_NUMBER  = " & pTaskNumber
                        XSQL = XSQL + " AND  MATERIAL_CODE = '" + pMATERIAL_CODE + "' "
                        If Not ExecuteSqlTransaction(pTrans, XSQL, pResult) Then
                            Return False
                        End If
                    End If
                End If
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            pResult = ex.Message
            Return False
        End Try

    End Function

    '07-Abr-11 J.R. llena una tabla de control de bines escaneados para que los pida en ese orden en las Touchscreen  
    Public Function AddBINtoControlTable(ByVal pERPDoc As String, ByVal pTargetBin As Integer, ByVal pLineID As String, ByRef pResult As String, ByRef pTrans As SqlTransaction) As Boolean
        Dim XSQL As String
        Try

            XSQL = "INSERT INTO OP_WMS_CTRL_BIN_PASSING (ERP_LEGACY_ID, BIN_TARGET, TASK_ASSIGNEDTO, DATETIME_PASSED, BIN_RELEASED) "
            XSQL = XSQL + "SELECT '" & pERPDoc & "', " & pTargetBin & ", LOGIN_ID, GETDATE(), 'N' FROM OP_WMS_LOGIN_JOIN_LOCATIONS WHERE LINE_ID = '" & pLineID & "'"

            If ExecuteSqlTransaction(pTrans, XSQL, pResult) Then
                Return True
            Else
                pResult = "OK"
                Return True
            End If
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return False
        End Try

    End Function

    '07-Abr-11 J.R. borra los bines de la tabla de control para que ya no se los pida a los pickers  
    Public Function RemoveBINfromControlTable(ByVal pTargetBin As Integer, ByVal pAssignedUser As String, ByVal pLinea As String, ByRef pResult As String, ByRef pTrans As SqlTransaction) As Boolean
        Dim XSQL As String
        'Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)


        Try
            XSQL = "DELETE FROM OP_WMS_CTRL_BIN_PASSING WHERE BIN_TARGET = " & pTargetBin & " AND TASK_ASSIGNEDTO = '" & pAssignedUser & "'"

            If ExecuteSqlTransaction(pTrans, XSQL, pResult) Then

                XSQL = "SELECT TOP 1 LOGIN_ID FROM OP_WMS_LOGIN_JOIN_LOCATIONS WHERE LINE_ID = '" + pLinea + "' AND LOCATION_SPOT > (SELECT LOCATION_SPOT FROM OP_WMS_LOGIN_JOIN_LOCATIONS WHERE LOGIN_ID = '" + pAssignedUser + "') ORDER BY LOCATION_SPOT"

                Dim miscDA As New SqlCommand
                Dim miscADP As New SqlDataAdapter
                Dim miscDS As New DataSet
                Dim pNextUser As String = ""

                miscDA.Transaction = pTrans
                miscDA.Connection = pTrans.Connection
                miscDA.CommandText = XSQL
                miscDA.CommandType = CommandType.Text

                miscADP.SelectCommand = miscDA
                miscADP.Fill(miscDS)

                If miscDS.Tables(0).Rows.Count <= 0 Then

                    pNextUser = "N/A"
                Else



                    pNextUser = miscDS.Tables(0).Rows(0)("LOGIN_ID").ToString

                End If

                XSQL = "UPDATE OP_WMS_CTRL_BIN_PASSING SET BIN_RELEASED = 'S' WHERE BIN_TARGET = " & pTargetBin & " AND TASK_ASSIGNEDTO = '" & pNextUser.ToUpper.Trim & "'"

                Try
                    If pLinea = "LINEA_1" Then

                        'FileOpen(1, "c:\logs\CTRL_BIN_PASSING.txt", OpenMode.Append, OpenAccess.ReadWrite, OpenShare.Default)
                        'WriteLine(1, Now.ToString + " - " + XSQL)
                        'FileClose(1)
                    End If
                    'FileOpen(1, "c:\logs\OP_WMS_LOG_TEST.txt", OpenMode.Append, OpenAccess.ReadWrite, OpenShare.Default)
                    'WriteLine(1, Now.ToString + " - " + XSQL)
                    'FileClose(1)

                Catch ex As Exception

                End Try



                If ExecuteSqlTransaction(pTrans, XSQL, pResult) Then
                    pResult = "OK"
                    Return True
                Else
                    Return False
                End If

            Else
                Return False
            End If

        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return False
        End Try

    End Function

    '07-Abr-11 J.R. llena una tabla de control de bines escaneados para que los pida en ese orden en las Touchscreen  
    Public Function AddClosedBINtoControlTable(ByVal pERPDoc As String, ByVal pClosedBin As Integer, ByVal pTargetBin As Integer, ByVal pAssignedUser As String, ByRef pResult As String, ByRef pTrans As SqlTransaction) As Boolean
        Dim XSQL As New StringBuilder
        Try
            XSQL.Append("INSERT INTO OP_WMS_CTRL_BIN_PASSING (ERP_LEGACY_ID, BIN_TARGET, TASK_ASSIGNEDTO, DATETIME_PASSED, BIN_RELEASED) ")
            XSQL.Append("SELECT '" & pERPDoc & "'," & pTargetBin & ", B.LOGIN_ID, DATEADD(MILLISECOND,100,DATETIME_PASSED), (CASE WHEN B.LOGIN_ID = '" & pAssignedUser & "' THEN 'S' ELSE 'N' END) BIN_RELEASED ")
            XSQL.Append("FROM OP_WMS_CTRL_BIN_PASSING A inner join (select * from OP_WMS_LOGIN_JOIN_LOCATIONS where LINE_ID in (select LINE_ID from OP_WMS_LOGIN_JOIN_LOCATIONS where LOGIN_ID = '" & pAssignedUser & "') and LOCATION_SPOT >= (select LOCATION_SPOT from OP_WMS_LOGIN_JOIN_LOCATIONS where LOGIN_ID = '" & pAssignedUser & "')) B ON 1=1")
            XSQL.Append("WHERE A.ERP_LEGACY_ID = '" & pERPDoc & "' AND A.BIN_TARGET = " & pClosedBin & " AND A.TASK_ASSIGNEDTO = '" & pAssignedUser & "'")

            If ExecuteSqlTransaction(pTrans, XSQL.ToString, pResult) Then
                Return True
            Else
                pResult = "OK"
                Return True
            End If
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return False
        End Try

    End Function

    '27-Jun-11 J.R. cuando se reasigna un bin tambien debe ingresarse a la tabla de control, si el usuario lo define
    Public Function AddReassignedBINtoControlTable(ByVal pERPDoc As String, ByVal pTargetBin As Integer, ByVal pColumna As String, ByRef pResult As String, ByRef pTrans As SqlTransaction) As Boolean
        'Dim XSQL As New StringBuilder
        'Try

        '    Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        '    Dim XSQL As String = ""

        '    XSQL = "SELECT LOCATION_SPOT, LINE_ID FROM OP_WMS_LOGIN_JOIN_LOCATIONS "
        '    XSQL = XSQL + "WHERE LINE_ID = (SELECT MAX(ASSIGNED_TO_LINE) FROM OP_WMS_DEMAND_TO_PICK WHERE ERP_DOCUMENT = '" + pDoc + "') "
        '    XSQL = XSQL + "ORDER BY LOCATION_SPOT"

        '    Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        '    Dim miscDS As DataSet = New DataSet()
        '    Try
        '        miscDA.Fill(miscDS, "GetLocationsByDocument")
        '    Catch ex As Exception
        '        pResult = "ERROR," + ex.Message
        '        Return Nothing
        '    End Try
        '    If miscDS.Tables(0).Rows.Count <= 0 Then
        '        pResult = "NO_INFO"
        '        Return Nothing
        '    Else
        '        pResult = "OK"
        '        Return miscDS
        '    End If

        '    Dim dsDatos As DataSet = New DataSet

        '    XSQL.Append("SELECT '" & pERPDoc & "'," & pTargetBin & ", LOGIN_ID, (SELECT DATEADD(MILLISECOND,100,MAX(DATETIME_PASSED)) FROM OP_WMS_CTRL_BIN_PASSING WHERE ERP_LEGACY_ID = '" & pERPDoc & "') FROM OP_WMS_LOGIN_JOIN_LOCATIONS ")
        '    XSQL.Append("WHERE LINE_ID = (SELECT MAX(ASSIGNED_TO_LINE) FROM OP_WMS_DEMAND_TO_PICK WHERE ERP_DOCUMENT = '" & pERPDoc & "') ")
        '    XSQL.Append("AND LOCATION_SPOT >= '" & pColumna & "' ")
        '    XSQL.Append("ORDER BY LOCATION_SPOT ")


        '    XSQL.Append("INSERT INTO OP_WMS_CTRL_BIN_PASSING (ERP_LEGACY_ID, BIN_TARGET, TASK_ASSIGNEDTO, DATETIME_PASSED, BIN_RELEASED) ")


        '    If ExecuteSqlTransaction(pTrans, XSQL.ToString, pResult) Then
        '        Return True
        '    Else
        '        Return False
        '    End If
        'Catch ex As Exception
        '    pResult = "ERROR," + ex.Message
        '    Return False
        'End Try
        Return True

    End Function
    'TRANSACTION
    Public Function CreatePackagesCountTask(ByVal pWAREHOUSE_SOURCE As String, ByVal pLINE_ID As String, ByVal pERPDoc As String, ByVal pIsDescretional As Boolean, ByVal pDiscretionalUser As String, ByRef pResult As String, ByRef pTrans As SqlTransaction) As Boolean

        Dim pAssignedUser As String = ""
        Dim pSourceLocation As String = ""

        Dim xserv1 As New WMS_Tasks
        Dim pPendienteAsignar As Double = 0
        Dim XSQL As String = ""
        Try

            If pIsDescretional Then
                pAssignedUser = pDiscretionalUser
            Else

                'obtener el usuario a asignar
                XSQL = "SELECT LOGIN_ID FROM OP_WMS_LOGINS WHERE LINE_ID='" + pLINE_ID + "' ORDER BY CARGA_TRABAJO, LOGIN_ID ASC"

                Dim miscDA1 As New SqlCommand
                Dim miscADP1 As New SqlDataAdapter
                Dim miscDS1 As New DataSet

                miscDA1.Transaction = pTrans
                miscDA1.Connection = pTrans.Connection
                miscDA1.CommandText = XSQL
                miscDA1.CommandType = CommandType.Text

                Try
                    miscADP1.SelectCommand = miscDA1
                    miscADP1.Fill(miscDS1)
                Catch ex As Exception
                    pResult = "ERROR (@CreatePackagesCountTask): " + ex.Message
                    Return False
                End Try

                If miscDS1.Tables(0).Rows.Count >= 1 Then
                    pAssignedUser = miscDS1.Tables(0).Rows(0)("LOGIN_ID").ToString
                Else
                    pResult = "ERROR, No Encontro Operador disponible para linea"
                    Return False
                End If

            End If

            If pResult = "OK" Then
                'ACTUALIZAR REGISTROS EN PACK_X_DISP
                XSQL = "UPDATE OP_WMS_PACKAGES_X_DISPATCH SET ASSIGNED_TO = '" + pAssignedUser + "' WHERE ERP_DOC = '" + pERPDoc + "'"
                If ExecuteSqlTransaction(pTrans, XSQL, pResult) Then
                    Return True
                Else
                    Return False
                End If

            Else
                pResult = "OK"
                Return True

            End If

        Catch ex As Exception
            pResult = ex.Message
            Return False
        End Try

    End Function
End Class