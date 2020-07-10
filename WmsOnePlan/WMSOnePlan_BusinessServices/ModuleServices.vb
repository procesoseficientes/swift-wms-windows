Imports System.Configuration.ConfigurationManager
Imports System.Diagnostics
Imports System.Data.SqlClient
Imports System.Threading
Module ModuleServices
    Public DefaultSchema As String = AppSettings("CLIENT_SCHEMA")
#Region "Database"
    Public Function GetJson(ByVal dt As DataTable) As String

        Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
        Dim rows As New List(Of Dictionary(Of String, Object))
        Dim row As Dictionary(Of String, Object)

        For Each dr As DataRow In dt.Rows
            row = New Dictionary(Of String, Object)
            For Each col As DataColumn In dt.Columns
                row.Add(col.ColumnName, dr(col))
            Next
            rows.Add(row)
        Next

        Return serializer.Serialize(rows)
    End Function
    Public Function ExecuteSqlTransaction(ByVal connectionString As String, ByVal SQLStatment As String, ByRef pResult As String) As Boolean
        Using connection As New SqlConnection(connectionString)
            Try
                connection.Open()
            Catch ex As SqlException
                pResult = ex.Message + " " + connectionString
                Return False
            End Try


            Dim command As SqlCommand = connection.CreateCommand()

            command.Connection = connection
            Try
                command.CommandText = SQLStatment
                command.ExecuteNonQuery()
                pResult = "OK"
                Return True
            Catch ex As SqlException
                pResult = "ExecuteSqlTransaction:" + ex.Message + " " + SQLStatment
                Return False
            End Try
        End Using

        Return True
    End Function
    Public Function LogSQLErrors(ByVal pMessage As String, ByVal pSQL As String, ByRef pResult As String) As Boolean

        Dim pSqlLocal As String = ""
        Try
            pSqlLocal = "INSERT INTO " & DefaultSchema & "OP_LOG (ERR_DATETIME, ERR_TEXT, ERR_SQL) VALUES (CURRENT_TIMESTAMP, '" + pMessage.Replace("'", "|") + "', '" + pSQL.Replace("'", "|") + "')"

            'ExecuteSqlTransaction(AppSettings("WSHOST").ToString, pSqlLocal, pResult)
            Return True

        Catch ex As Exception
            pResult = "LogSQLErrors: " + ex.Message + " " + pSqlLocal

            Return False
        End Try

    End Function
    Public Function ExecuteSqlTransaction(ByRef pTransaction As SqlTransaction, ByVal SQLStatment As String, ByRef pResult As String) As Boolean

        Dim command As SqlCommand = pTransaction.Connection.CreateCommand
        command.Transaction = pTransaction
        Try

            command.CommandText = SQLStatment
            command.ExecuteNonQuery()
            pResult = "OK"

        Catch ex As Exception
            pResult = ex.Message

            Return False
        End Try

        Return True
    End Function
    Public Function ExecuteSqlTransaction(ByRef pTransaction As SqlTransaction, ByVal SQLStatment As String, ByRef pResult As String, ByRef pAffectedRows As Integer) As Boolean

        Dim command As SqlCommand = pTransaction.Connection.CreateCommand
        command.Transaction = pTransaction
        Try
            command.CommandText = SQLStatment
            pAffectedRows = command.ExecuteNonQuery()
            pResult = "OK"

        Catch ex As Exception
            'FileOpen(1, "c:\OnePlanWMS\OP_WMS_LOG.txt", OpenMode.Append, OpenAccess.ReadWrite, OpenShare.Default)
            'WriteLine(1, Now.ToString + " - " + ex.Message + " - " + SQLStatment)
            'FileClose(1)
            pResult = ex.Message
            Return False
        End Try

        Return True
    End Function
    Public Function GetLastTrans(ByRef pResult As String, ByRef pTrans As SqlTransaction) As DataSet

        Dim XSQL As String = ""
        XSQL = "SELECT IDENT_CURRENT('OP_WMS_TRANS') AS LAST_TRANS_ID"

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
            pResult = "ERROR, No se encontro la ultima transaccion creada"
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function
    Public Function GetSQLTrans(ByVal pSQL As String, ByRef pTrans As SqlTransaction, ByRef pResult As String) As DataSet

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
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR, No hay registros"
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If
    End Function

#End Region
#Region "Misc"

    Public Function IsValidDate(ByVal pDate As Date) As Boolean
        If Year(pDate) >= 2000 Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function AdjustInventory(ByVal pSourceWarehouse As String, ByVal pSourceLocationSpot As String, ByVal pBinID As String, ByVal pMaterial As String, ByVal pQty As Double, ByVal pTransInited As Boolean, ByVal pShouldInitTrans As Boolean, ByVal pShouldEndTrans As Boolean, ByRef pTrans As SqlTransaction, ByVal pLastTrans As Integer, ByVal pLastLogin As String, ByVal pLineID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean
        Try
            Dim pSQL As String = ""

            If pSourceLocationSpot = "" Then
                pResult = "ERROR,Ubicacion vacia"
                Return False
            Else
                Try
                    If Not ValidateExists("LOCATION", pSourceLocationSpot, pSourceWarehouse, pEnvironmentName) Then
                        pResult = "ERROR,Ubicacion no existe"
                        Return False
                    End If
                Catch ex As Exception
                    pResult = ex.Message
                    Return False
                End Try
            End If

            If IsNumeric(pBinID) Then
                If pBinID < 0 Then
                    pResult = "ERROR,BIN con numero Invalido"
                    Return False
                Else
                    Try
                        If pBinID <> 0 Then
                            If Not ValidateExists("BIN", pBinID.ToString, "", pEnvironmentName) Then
                                pResult = "ERROR,BIN no existe"
                                Return False
                            End If
                        End If
                    Catch ex As Exception
                        pResult = ex.Message
                        Return False
                    End Try
                End If
            End If

            If pMaterial = "" Then
                pResult = "ERROR,Material vacio"
                Return False
            Else
                Try
                    If Not ValidateExists("MATERIAL", pMaterial, "", pEnvironmentName) Then
                        pResult = "ERROR,Material no existe"
                        WriteLine(1, pResult)
                        FileClose(1)
                        Return False
                    End If
                Catch ex As Exception
                    pResult = ex.Message
                    Return False
                End Try
            End If

            Try
                'IF INVENTORY EXISTS THEN UPDATE IT.
                pSQL = "SELECT * FROM OP_WMS_INVENTORY WHERE WAREHOUSE_ID='" + pSourceWarehouse + "' AND SPOT_ID = '" + pSourceLocationSpot + "' "
                If IsNumeric(pBinID) Then
                    If pBinID >= 1 Then
                        pSQL = pSQL + " AND BIN_ID=" + pBinID + ""
                    Else
                        pSQL = pSQL + " AND BIN_ID IS NULL "
                    End If

                Else
                    pSQL = pSQL + " AND BIN_ID IS NULL"
                End If
                pSQL = pSQL + "  AND MATERIAL_ID = '" + pMaterial + "'"

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
                    'then update inventory
                    pSQL = "UPDATE OP_WMS_INVENTORY SET QUANTITY_UNITS = QUANTITY_UNITS + " & pQty & " , LAST_TRANS_ID = " & IIf(pLastTrans = 0, "NULL", pLastTrans) & ", LAST_LOGIN_ID = " + IIf(pLastLogin <> "", "'" + pLastLogin.ToUpper + "'", "NULL") + "  WHERE WAREHOUSE_ID='" + pSourceWarehouse + "' AND SPOT_ID = '" + pSourceLocationSpot + "' "
                    If IsNumeric(pBinID) Then
                        If pBinID >= 1 Then
                            pSQL = pSQL + " AND BIN_ID=" + pBinID + ""
                        Else
                            pSQL = pSQL + " AND BIN_ID IS NULL"
                        End If
                    Else
                        pSQL = pSQL + " AND BIN_ID IS NULL"
                    End If
                    pSQL = pSQL + " AND MATERIAL_ID='" + pMaterial + "'"
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
                    pSQL = pSQL + "('" + pSourceWarehouse + "'"
                    pSQL = pSQL + ",'" + pSourceLocationSpot + "'"
                    If IsNumeric(pBinID) Then
                        If pBinID >= 1 Then
                            pSQL = pSQL + "," + pBinID
                        Else
                            pSQL = pSQL + ",NULL"
                        End If

                    Else
                        pSQL = pSQL + ",NULL"
                    End If
                    pSQL = pSQL + ",NULL"
                    pSQL = pSQL + ",'" + pMaterial + "'"
                    pSQL = pSQL + ",'" + GetProdInfo("DESC", pMaterial, pTrans) + "'"
                    pSQL = pSQL + "," + Replace(GetProdInfo("COST", pMaterial, pTrans), ",", ".")
                    '14-Sep-10 la BD devuelve 0,00 en lugar de 0.00 y por eso la sentencia aparece con mas campos en VALUE de lo que hay en INSERT
                    'pSQL = pSQL + "," + GetProdInfo("COST", pMaterial, pTrans)
                    pSQL = pSQL + ",0"
                    pSQL = pSQL + ",CURRENT_TIMESTAMP"
                    pSQL = pSQL + ",0"
                    pSQL = pSQL + "," & IIf(pLastTrans = 0, "NULL", pLastTrans)
                    pSQL = pSQL + "," + IIf(pLastLogin <> "", "'" + pLastLogin.ToUpper + "'", "NULL")
                    pSQL = pSQL + "," & pQty
                    pSQL = pSQL + ",0,'" + pLineID.ToUpper + "')"

                End If
                If Not ExecuteSqlTransaction(pTrans, pSQL, pResult) Then
                    Return False
                Else
                    pResult = "AdjustInv: " + pResult
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
    Public Function AdjustInventory(ByVal pSourceWarehouse As String, ByVal pSourceLocationSpot As String, ByVal pBinID As String, ByVal pMaterial As String, ByVal pQty As Double, ByVal pTransInited As Boolean, ByVal pShouldInitTrans As Boolean, ByVal pShouldEndTrans As Boolean, ByRef pConnection As SqlConnection, ByVal pLastTrans As Integer, ByVal pLastLogin As String, ByVal pLineID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean
        Try
            Dim pSQL As String = ""

            If pSourceLocationSpot = "" Then
                pResult = "ERROR,Ubicacion vacia"
                Return False
            Else
                Try
                    If Not ValidateExists("LOCATION", pSourceLocationSpot, pSourceWarehouse, pEnvironmentName) Then
                        pResult = "ERROR,Ubicacion no existe"
                        Return False
                    End If
                Catch ex As Exception
                    pResult = ex.Message
                    Return False
                End Try
            End If

            If IsNumeric(pBinID) Then
                If pBinID < 0 Then
                    pResult = "ERROR,BIN con numero Invalido"
                    Return False
                Else
                    Try
                        If pBinID <> 0 Then
                            If Not ValidateExists("BIN", pBinID.ToString, "", pEnvironmentName) Then
                                pResult = "ERROR,BIN no existe"
                                Return False
                            End If
                        End If
                    Catch ex As Exception
                        pResult = ex.Message
                        Return False
                    End Try
                End If
            End If

            If pMaterial = "" Then
                pResult = "ERROR,Material vacio"
                Return False
            Else
                Try
                    If Not ValidateExists("MATERIAL", pMaterial, "", pEnvironmentName) Then
                        pResult = "ERROR,Material no existe"
                        WriteLine(1, pResult)
                        FileClose(1)
                        Return False
                    End If
                Catch ex As Exception
                    pResult = ex.Message
                    Return False
                End Try
            End If

            Try
                'IF INVENTORY EXISTS THEN UPDATE IT.
                pSQL = "SELECT * FROM OP_WMS_INVENTORY WHERE WAREHOUSE_ID='" + pSourceWarehouse + "' AND SPOT_ID = '" + pSourceLocationSpot + "' "
                If IsNumeric(pBinID) Then
                    If pBinID >= 1 Then
                        pSQL = pSQL + " AND BIN_ID=" + pBinID + ""
                    Else
                        pSQL = pSQL + " AND BIN_ID IS NULL "
                    End If

                Else
                    pSQL = pSQL + " AND BIN_ID IS NULL"
                End If
                pSQL = pSQL + "  AND MATERIAL_ID = '" + pMaterial + "'"

                Dim miscDA As New SqlCommand
                Dim miscADP As New SqlDataAdapter
                Dim miscDS As New DataSet

                'miscDA.Transaction = pTrans
                miscDA.Connection = pConnection
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
                    pSQL = "UPDATE OP_WMS_INVENTORY SET QUANTITY_UNITS = QUANTITY_UNITS + " & pQty & " , LAST_TRANS_ID = " & IIf(pLastTrans = 0, "NULL", pLastTrans) & ", LAST_LOGIN_ID = " + IIf(pLastLogin <> "", "'" + pLastLogin.ToUpper + "'", "NULL") + "  WHERE WAREHOUSE_ID='" + pSourceWarehouse + "' AND SPOT_ID = '" + pSourceLocationSpot + "' "
                    If IsNumeric(pBinID) Then
                        If pBinID >= 1 Then
                            pSQL = pSQL + " AND BIN_ID=" + pBinID + ""
                        Else
                            pSQL = pSQL + " AND BIN_ID IS NULL"
                        End If
                    Else
                        pSQL = pSQL + " AND BIN_ID IS NULL"
                    End If
                    pSQL = pSQL + " AND MATERIAL_ID='" + pMaterial + "'"
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
                    pSQL = pSQL + "('" + pSourceWarehouse + "'"
                    pSQL = pSQL + ",'" + pSourceLocationSpot + "'"
                    If IsNumeric(pBinID) Then
                        If pBinID >= 1 Then
                            pSQL = pSQL + "," + pBinID
                        Else
                            pSQL = pSQL + ",NULL"
                        End If

                    Else
                        pSQL = pSQL + ",NULL"
                    End If
                    pSQL = pSQL + ",NULL"
                    pSQL = pSQL + ",'" + pMaterial + "'"
                    pSQL = pSQL + ",'" + GetProdInfo("DESC", pMaterial) + "'"
                    pSQL = pSQL + "," + Replace(GetProdInfo("COST", pMaterial), ",", ".")
                    '14-Sep-10 la BD devuelve 0,00 en lugar de 0.00 y por eso la sentencia aparece con mas campos en VALUE de lo que hay en INSERT
                    'pSQL = pSQL + "," + GetProdInfo("COST", pMaterial, pTrans)
                    pSQL = pSQL + ",0"
                    pSQL = pSQL + ",CURRENT_TIMESTAMP"
                    pSQL = pSQL + ",0"
                    pSQL = pSQL + "," & IIf(pLastTrans = 0, "NULL", pLastTrans)
                    pSQL = pSQL + "," + IIf(pLastLogin <> "", "'" + pLastLogin.ToUpper + "'", "NULL")
                    pSQL = pSQL + "," & pQty
                    pSQL = pSQL + ",0,'" + pLineID.ToUpper + "')"

                End If
                If Not ExecuteSqlTransaction(pConnection.ConnectionString, pSQL, pResult) Then
                    Return False
                Else
                    pResult = "AdjustInv: " + pResult
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
    Public Function ValidateExists(ByVal pModule As String, ByVal pParamValue As String, ByVal pSpareParam As String, ByVal pEnvironmentName As String) As Boolean
        Dim pResult As String = ""
        Select Case UCase(pModule)
            Case "MATERIAL"
                Dim xserv As New WMS_Materials
                Call xserv.SearchByKeyMaterials(pParamValue, pResult, pEnvironmentName)
                xserv = Nothing
                Return IIf(pResult = "OK", True, False)
            Case "LOCATION"
                Dim xserv As New WMS_Locations
                Call xserv.SearchByKeyShelfSpots(pSpareParam, pParamValue, pResult, pEnvironmentName)
                xserv = Nothing
                Return IIf(pResult = "OK", True, False)
        End Select
        Return True
    End Function
   Public Function GetUserName(ByVal pLOGIN_ID As String, ByVal pTrans As SqlTransaction, ByVal pEnvironment As String) As String

        Try
            Dim pResult As String = ""
            Dim xserv As New WMS_Security
            Dim xdata As DataSet
            xdata = xserv.SearchByKeyUserLogin(pLOGIN_ID, pResult, pEnvironment)
            If pResult = "OK" Then
                Return xdata.Tables(0).Rows(0)("LOGIN_NAME")
            Else
                Return "N/A"
            End If
            xserv = Nothing
        Catch ex As Exception
            Return "N/A"
        End Try
        Return ""
    End Function
    Public Function GetTransDesc(ByVal pTransType As String, ByVal pTrans As SqlTransaction) As String
        Try
            Dim pResult As String = ""
            Dim xserv As New WMS_Settings
            Dim xdata As DataSet
            xdata = xserv.GetParam_ByParamKey("SISTEMA", "TRANS_TYPES", pTransType, pResult, "DESARROLLO")
            If pResult = "OK" Then
                Return xdata.Tables(0).Rows(0)("PARAM_CAPTION")
            Else
                Return "N/A"
            End If
            xserv = Nothing
        Catch ex As Exception
            Return "N/A"
        End Try
        Return ""
    End Function
    Public Function GetProdInfo(ByVal pType As String, ByVal pProd As String, ByVal pTrans As SqlTransaction) As String
        Try
            Dim pResult As String = ""
            Dim xserv As New WMS_Materials
            Dim xdata As DataSet
            xdata = xserv.SearchByKeyMaterials(pProd, pResult, "DESARROLLO")
            If pResult = "OK" Then
                If pType = "DESC" Then
                    Return xdata.Tables(0).Rows(0)("MATERIAL_NAME").Replace("'", "''")
                Else
                    Return IIf(IsDBNull(xdata.Tables(0).Rows(0)("ERP_COST")), "0", xdata.Tables(0).Rows(0)("ERP_COST").ToString)
                End If
            Else
                If pType = "DESC" Then
                    Return "N/A"
                Else
                    Return "0"
                End If
            End If
            xserv = Nothing
        Catch ex As Exception
            Return "N/A"
        End Try
        Return ""
    End Function
    Public Function GetProdInfo(ByVal pType As String, ByVal pProd As String) As String
        Try
            Dim pResult As String = ""
            Dim xserv As New WMS_Materials
            Dim xdata As DataSet
            xdata = xserv.SearchByKeyMaterials(pProd, pResult, "DESARROLLO")
            If pResult = "OK" Then
                If pType = "DESC" Then
                    Return xdata.Tables(0).Rows(0)("MATERIAL_NAME").Replace("'", "''")
                Else
                    Return IIf(IsDBNull(xdata.Tables(0).Rows(0)("ERP_COST")), "0", xdata.Tables(0).Rows(0)("ERP_COST").ToString)
                End If
            Else
                If pType = "DESC" Then
                    Return "N/A"
                Else
                    Return "0"
                End If
            End If
            xserv = Nothing
        Catch ex As Exception
            Return "N/A"
        End Try
        Return ""
    End Function
    Public Function GetClientName(ByVal pClientID As String, ByVal pTrans As SqlTransaction) As String

        Try
            Dim pResult As String = ""
            Dim xserv As New WMS_Clients
            Dim xdata As DataSet
            xdata = xserv.SearchByKeyClients(pClientID, pResult, "DESARROLLO")
            If pResult = "OK" Then
                Return xdata.Tables(0).Rows(0)("CLIENT_NAME")
            Else
                Return "N/A"
            End If
            xserv = Nothing
        Catch ex As Exception
            Return "N/A"
        End Try
        Return ""
    End Function

    Public Function convertDataReaderToDataSet(ByVal reader As SqlDataReader) As DataSet
        Dim dataSet As DataSet = New DataSet
        Dim dataRow As DataRow
        Dim columnName As String
        Dim column As DataColumn
        Dim schemaTable As DataTable
        Dim dataTable As DataTable

        Do
            ' Create new data table
            schemaTable = reader.GetSchemaTable
            dataTable = New DataTable
            If Not IsDBNull(schemaTable) Then
                ' A query returning records was executed
                Dim i As Integer
                For i = 0 To schemaTable.Rows.Count - 1
                    dataRow = schemaTable.Rows(i)
                    ' Create a column name that is unique in the data table
                    columnName = dataRow("ColumnName")
                    'Add the column definition to the data table
                    column = New DataColumn(columnName, CType(dataRow("DataType"), Type))
                    dataTable.Columns.Add(column)
                Next
                dataSet.Tables.Add(dataTable)

                'Fill the data table we just created
                While reader.Read()
                    dataRow = dataTable.NewRow()
                    For i = 0 To reader.FieldCount - 1
                        dataRow(i) = reader(i)
                    Next
                    dataTable.Rows.Add(dataRow)
                End While
            Else
                'No records were returned
                column = New DataColumn("RowsAffected")
                dataTable.Columns.Add(column)
                dataSet.Tables.Add(dataTable)
                dataRow = dataTable.NewRow()
                dataRow(0) = reader.RecordsAffected
                dataTable.Rows.Add(dataRow)
            End If
        Loop While reader.NextResult()
        Return dataSet
    End Function



#End Region

End Module
