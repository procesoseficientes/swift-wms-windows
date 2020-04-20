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
Public Class WMS_InitInventory
    Inherits System.Web.Services.WebService
    <WebMethod()> _
    Public Function InitBasicInventory_Location(ByVal pWAREHOUSE As String, ByVal pLOCATION As String, ByVal pBIN As String, ByVal pMATERIAL As String, ByVal pDESC As String, ByVal pQTY As Double, ByVal pLOGIN As String, ByVal pLINE_ID As String, ByVal pEnvironmentName As String, ByRef pResult As String) As Boolean
        Dim pNum As Integer = 0
        Dim pLastTrans As Double = 0
        Dim pSQL As String = ""

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldb_conexion.Open()
        Try

            'Dim pTrans As SqlTransaction
            'pTrans = sqldb_conexion.BeginTransaction(IsolationLevel.Serializable)

            Try
                'IF INVENTORY EXISTS THEN UPDATE IT.
                pSQL = "SELECT * FROM OP_WMS_INVENTORY WHERE WAREHOUSE_ID='" + pWAREHOUSE + "' AND SPOT_ID = '" + pLOCATION + "' "
                pSQL = pSQL + " AND BIN_ID IS NULL"
                pSQL = pSQL + "  AND MATERIAL_ID = '" + pMATERIAL + "'"

                Dim miscDA As New SqlCommand
                Dim miscADP As New SqlDataAdapter
                Dim miscDS As New DataSet

                'miscDA.Transaction = pTrans
                miscDA.Connection = sqldb_conexion
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
                    'then update inventory
                    pSQL = "UPDATE OP_WMS_INVENTORY SET QUANTITY_UNITS = QUANTITY_UNITS + " & pQTY & " , LAST_TRANS_ID = " & IIf(pLastTrans = 0, "NULL", pLastTrans) & ", LAST_LOGIN_ID = " + IIf(pLOGIN <> "", "'" + pLOGIN.ToUpper + "'", "NULL") + "  WHERE WAREHOUSE_ID='" + pWAREHOUSE + "' AND SPOT_ID = '" + pLOCATION + "' "
                    pSQL = pSQL + " AND BIN_ID IS NULL"
                    pSQL = pSQL + " AND MATERIAL_ID='" + pMATERIAL + "'"
                Else
                    'then create inventory

                    pSQL = pSQL + " INSERT INTO OP_WMS_INVENTORY"
                    pSQL = pSQL + " (WAREHOUSE_ID"
                    pSQL = pSQL + ",SPOT_ID"
                    pSQL = pSQL + ",BIN_ID"
                    pSQL = pSQL + ",BATCH_NUMBER"
                    pSQL = pSQL + ",MATERIAL_ID"
                    pSQL = pSQL + ",MATERIAL_DESCRIPTION"
                    pSQL = pSQL + ",MATERIAL_COST"
                    pSQL = pSQL + ",VOLUME_FACTOR"
                    pSQL = pSQL + ",CHECK_IN_DATE"
                    pSQL = pSQL + ",DAYS_ON_IDLE"
                    pSQL = pSQL + ",LAST_TRANS_ID"
                    pSQL = pSQL + ",LAST_LOGIN_ID"
                    pSQL = pSQL + ",QUANTITY_UNITS"
                    pSQL = pSQL + ",QUANTITY_ON_HOLD, LINE_ID)"
                    pSQL = pSQL + "VALUES"
                    pSQL = pSQL + "('" + pWAREHOUSE + "'"
                    pSQL = pSQL + ",'" + pLOCATION + "'"
                    pSQL = pSQL + ",NULL"
                    pSQL = pSQL + ",NULL"
                    pSQL = pSQL + ",'" + pMATERIAL + "'"
                    pSQL = pSQL + ",'" + pDESC + "'"
                    pSQL = pSQL + ",0"
                    '14-Sep-10 la BD devuelve 0,00 en lugar de 0.00 y por eso la sentencia aparece con mas campos en VALUE de lo que hay en INSERT
                    'pSQL = pSQL + "," + GetProdInfo("COST", pMaterial, pTrans)
                    pSQL = pSQL + ",0"
                    pSQL = pSQL + ",CURRENT_TIMESTAMP"
                    pSQL = pSQL + ",0"
                    pSQL = pSQL + "," & IIf(pLastTrans = 0, "NULL", pLastTrans)
                    pSQL = pSQL + "," + IIf(pLOGIN <> "", "'" + pLOGIN.ToUpper + "'", "NULL")
                    pSQL = pSQL + "," & pQTY
                    pSQL = pSQL + ",0,'" + pLINE_ID.ToUpper + "')"

                End If

                Dim command As SqlCommand = sqldb_conexion.CreateCommand()

                command.Connection = sqldb_conexion
                Try
                    command.CommandText = pSQL
                    command.ExecuteNonQuery()
                    pResult = "OK"
                    Return True
                Catch ex As Exception
                    pResult = ex.Message
                    Return False
                End Try


            Catch ex As Exception
                pResult = ex.Message
                Return False
            End Try


        Catch ex As Exception
            sqldb_conexion.Close()
            sqldb_conexion.Dispose()
            pResult = "ERROR," & pNum & ":" + ex.Message
            Return False
        End Try

    End Function

    
    <WebMethod()> _
    Public Function CleanUp_Location(ByVal pWAREHOUSE As String, ByVal pLOCATION As String, ByVal pEnvironmentName As String, ByRef pResult As String) As Boolean
        Dim pNum As Integer = 0
        Dim pLastTrans As Double = 0
        Dim xSql As String
        Dim pTrans As SqlTransaction = Nothing
        Try
            Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
            sqldb_conexion.Open()

            pTrans = sqldb_conexion.BeginTransaction(IsolationLevel.Serializable)
            xSql = "DELETE FROM OP_WMS_INVENTORY WHERE WAREHOUSE_ID = '" + pWAREHOUSE + "' AND SPOT_ID = '" + pLOCATION + "'"

            If ExecuteSqlTransaction(pTrans, xSql, pResult) Then

                xSql = "DELETE FROM OP_WMS_MATERIALS_JOIN_SPOTS WHERE WAREHOUSE_PARENT = '" + pWAREHOUSE + "' AND LOCATION_SPOT = '" + pLOCATION + "'"
                If ExecuteSqlTransaction(pTrans, xSql, pResult) Then
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
            pTrans.Rollback()
            pResult = "ERROR," + ex.Message
            Return False
        End Try

    End Function

End Class