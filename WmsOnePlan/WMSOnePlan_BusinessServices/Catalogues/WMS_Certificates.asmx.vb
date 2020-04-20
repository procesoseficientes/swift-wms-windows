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
Public Class WMS_Certificates
    Inherits System.Web.Services.WebService

    <WebMethod(Description:="Create a certificate")> _
    Public Function CreateCertificate(ByVal pAddBond As Boolean, ByRef pCertificateId As Integer, ByVal pCreationBy As String, ByVal pSupervisionId As Integer,
                                      ByVal p3plWarenHouse As String, ByVal pValidFrom As Date, ByVal pValidTo As Date, ByVal pClientCode As String,
                                      ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        Dim strSql As New StringBuilder
        Try

            strSql.Append(String.Format(" INSERT INTO {0}OP_WMS_CERTIFICATES(", DefaultSchema))
            strSql.Append(" CREATION_DATE")
            strSql.Append(" , CREATION_BY")
            strSql.Append(" , SUPERVISION_ID")
            strSql.Append(" , [3PL_WAREHOUSE]")
            strSql.Append(" , CERTIFICATE_STATUS")
            strSql.Append(" , VALID_FROM")
            strSql.Append(" , VALID_TO")
            strSql.Append(" , CLIENT_CODE")
            strSql.Append(" , HAS_BOND")
            strSql.Append(" ) VALUES(")
            strSql.Append(String.Format(" GetDate()"))
            strSql.Append(String.Format(" , '{0}'", pCreationBy))
            strSql.Append(String.Format(" , {0}", pSupervisionId))
            strSql.Append(String.Format(" , '{0}'", p3plWarenHouse))
            strSql.Append(String.Format(" , 'Activo'"))
            strSql.Append(String.Format(" , convert(date,'{0}')", pValidFrom.ToString("MM/dd/yyyy")))
            strSql.Append(String.Format(" , convert(date,'{0}')", pValidTo.ToString("MM/dd/yyyy")))
            strSql.Append(String.Format(" , '{0}'", pClientCode))
            strSql.Append(String.Format(" , {0}", IIf(pAddBond, 1, 0)))
            strSql.Append(")")

            If ExecuteSqlTransaction(sqldb_conexion.ConnectionString, strSql.ToString, pResult) Then
                If pAddBond Then
                    strSql = New StringBuilder
                    strSql.Append(String.Format(" SELECT isnull(MAX(CERTIFICATE_ID),0) FROM {0}OP_WMS_CERTIFICATES", DefaultSchema))

                    Dim miscDA As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqldb_conexion)
                    Dim miscDS As DataSet = New DataSet()
                    Try
                        miscDA.Fill(miscDS, "GetMaxCertificateId")
                    Catch ex As Exception
                        pResult = "ERROR," + ex.Message
                        Return False
                    End Try
                    If miscDS.Tables(0).Rows(0)(0) = 0 Then
                        pResult = "ERROR, No se pudo obtener el id"
                        Return False
                    Else
                        pCertificateId = Integer.Parse(miscDS.Tables(0).Rows(0)(0).ToString)
                        pResult = "OK"
                        Return True
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

    <WebMethod(Description:="UPDATE a certificate")> _
    Public Function UpdateCertificate(ByRef pCertificateId As Integer, ByVal pLastUpdateBy As String, ByVal pSupervisionId As Integer,
                                      ByVal p3plWarenHouse As String, ByVal pCertificateStatus As String, ByVal pValidFrom As Date,
                                      ByVal pValidTo As Date, ByVal pClientCode As String, ByVal pHasBond As Integer,
                                      ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        Dim strSql As New StringBuilder
        Try

            strSql.Append(String.Format(" UPDATE {0}OP_WMS_CERTIFICATES SET", DefaultSchema))
            strSql.Append(" LAST_UPDATED = GetDate()")
            strSql.Append(String.Format(" , LAST_UPDATED_BY = '{0}'", pLastUpdateBy))
            strSql.Append(String.Format(" , SUPERVISION_ID =  {0}", pSupervisionId))
            strSql.Append(String.Format(" , [3PL_WAREHOUSE] = '{0}'", p3plWarenHouse))
            strSql.Append(String.Format(" , CERTIFICATE_STATUS = '{0}'", pCertificateStatus))
            strSql.Append(String.Format(" , VALID_FROM = convert(date,'{0}')", pValidFrom.ToString("MM/dd/yyyy")))
            strSql.Append(String.Format(" , VALID_TO = convert(date,'{0}')", pValidTo.ToString("MM/dd/yyyy")))
            strSql.Append(String.Format(" , CLIENT_CODE = '{0}'", pClientCode))
            strSql.Append(String.Format(" , HAS_BOND = {0}", pHasBond))
            strSql.Append(String.Format(" WHERE CERTIFICATE_ID = {0}", pCertificateId))

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

    <WebMethod(Description:="DELETE a certificate")> _
    Public Function DeleteCertificate(ByVal pCertificateId As Integer, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        Dim strSql As New StringBuilder
        Try

            strSql.Append(String.Format(" DELETE {0}OP_WMS_CERTIFICATES", DefaultSchema))
            strSql.Append(String.Format(" WHERE CERTIFICATE_ID = {0}", pCertificateId))

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

    <WebMethod(Description:="UPDATE a certificate Valid")> _
    Public Function UpdateCertificateValid(ByRef pCertificateId As Integer, ByVal pValidFrom As Date, ByVal pValidTo As Date,
                                           ByVal pLastUpdateBy As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        Dim strSql As New StringBuilder
        Try

            strSql.Append(String.Format(" UPDATE {0}OP_WMS_CERTIFICATES SET", DefaultSchema))
            strSql.Append(" LAST_UPDATED = GetDate()")
            strSql.Append(String.Format(" , LAST_UPDATED_BY = '{0}'", pLastUpdateBy))
            strSql.Append(String.Format(" , VALID_FROM = convert(date,'{0}')", pValidFrom.ToString("MM/dd/yyyy")))
            strSql.Append(String.Format(" , VALID_TO = convert(date,'{0}')", pValidTo.ToString("MM/dd/yyyy")))
            strSql.Append(String.Format(" WHERE CERTIFICATE_ID = {0}", pCertificateId))

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

    <WebMethod(Description:="Get a certificate")> _
    Public Function GetCertificate(ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        Dim strSql As New StringBuilder
        strSql.Append(" SELECT ce.CERTIFICATE_ID")
        strSql.Append(" , SUPERVISION_ID")
        strSql.Append(" , CLIENT_OWHEN")
        strSql.Append(" , [3PL_WAREHOUSE]")
        strSql.Append(" , NAME")
        strSql.Append(" , CERTIFICATE_STATUS")
        strSql.Append(" , VALID_TO")
        strSql.Append(" , vc.CLIENT_CODE")
        strSql.Append(" , vc.CLIENT_NAME")
        strSql.Append(" , case HAS_BOND when 0 then 'NO' else 'SI' END AS HAS_BOND	")
        strSql.Append(" , BOND_ID")
        strSql.Append(" , INSURANCES_COMPANY_ID")
        strSql.Append(" , COMPANY_NAME")
        strSql.Append(" , AMOUNT")
        strSql.Append(" , ce.CREATION_DATE")
        strSql.Append(" , CURRENCY")
        strSql.Append(String.Format(" FROM {0}OP_WMS_CERTIFICATES ce", DefaultSchema))
        strSql.Append(String.Format(" INNER JOIN {0}OP_WMS_SUPERVISIONS ON SUPERVISION_ID = SUPER_ID", DefaultSchema))
        strSql.Append(String.Format(" INNER JOIN {0}OP_WMS_WAREHOUSES ON [3PL_WAREHOUSE] = WAREHOUSE_ID", DefaultSchema))
        strSql.Append(String.Format(" INNER JOIN {0}OP_WMS_VIEW_CLIENTS vc ON ce.CLIENT_CODE = vc.CLIENT_CODE COLLATE DATABASE_DEFAULT", DefaultSchema))
        strSql.Append(String.Format(" LEFT JOIN {0}OP_WMS_BONDS b ON ce.CERTIFICATE_ID = b.CERTIFICATE_ID", DefaultSchema))
        strSql.Append(String.Format(" LEFT JOIN {0}OP_WMS_INSURANCE_COMPANIES ON INSURANCES_COMPANY_ID = COMPANY_ID", DefaultSchema))

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "GetCertificate")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR, No existen encontraron registros."
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If
    End Function

    <WebMethod(Description:="Fill a Certificate")> _
    Public Function FillCertificate(ByVal pCertificateId As Integer, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        Dim strSql As New StringBuilder
        strSql.Append(" SELECT CERTIFICATE_ID")
        strSql.Append(" , SUPERVISION_ID")
        strSql.Append(" , [3PL_WAREHOUSE]")
        strSql.Append(" , CERTIFICATE_STATUS")
        strSql.Append(" , VALID_FROM")
        strSql.Append(" , VALID_TO")
        strSql.Append(" , CLIENT_CODE")
        strSql.Append(" , HAS_BOND")
        strSql.Append(String.Format(" FROM {0}OP_WMS_CERTIFICATES", DefaultSchema))
        strSql.Append(String.Format(" WHERE CERTIFICATE_ID = {0}", pCertificateId))

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "FillCertificate")
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

    <WebMethod(Description:="Get Report certificate")> _
    Public Function GetRepCertificateBond(ByVal pNameTable As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        Dim strSql As New StringBuilder
        strSql.Append(" SELECT ct.CERTIFICATE_ID AS NumCertificado")
        strSql.Append(" , cl.CLIENT_CODE AS CodigoCliente")
        strSql.Append(" , cl.CLIENT_NAME AS NombreCliente")
        strSql.Append(" , AMOUNT AS MontoBono")
        strSql.Append(" , VALID_TO AS FechaVencimiento")
        strSql.Append(" , BOND_ID AS NumBono")
        strSql.Append(" , COMPANY_NAME AS Aseguradora")
        strSql.Append(String.Format(" FROM {0}OP_WMS_CERTIFICATES ct ", DefaultSchema))
        strSql.Append(String.Format(" INNER JOIN {0}OP_WMS_BONDS bd ON bd.CERTIFICATE_ID = ct.CERTIFICATE_ID", DefaultSchema))
        strSql.Append(String.Format(" INNER JOIN {0}OP_WMS_VIEW_CLIENTS cl ON ct.CLIENT_CODE = cl.CLIENT_CODE COLLATE DATABASE_DEFAULT", DefaultSchema))
        strSql.Append(String.Format(" INNER JOIN {0}OP_WMS_INSURANCE_COMPANIES ON COMPANY_ID = INSURANCES_COMPANY_ID", DefaultSchema))
        strSql.Append(String.Format(" WHERE HAS_BOND = 1"))
        strSql.Append(" ORDER BY VALID_TO")

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, pNameTable)
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR, No existen encontraron registros."
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If
    End Function

    <WebMethod(Description:="Create a certificate log")> _
    Public Function CreateCertificateLog(ByRef pCertificateId As Integer, ByVal pUpdateBy As String, ByVal pOldValidFrom As Date,
                                      ByVal pOldValidTo As Date, ByVal pNewdValidFrom As Date, ByVal pNewValidTo As Date,
                                      ByVal pAuthorizedBy As String, ByVal pComment As String,
                                      ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        Dim strSql As New StringBuilder
        Try

            strSql.Append(String.Format(" INSERT {0}OP_WMS_CERTIFICATE_LOG (", DefaultSchema))
            strSql.Append(" CERTIFICATE_ID")
            strSql.Append(" , UPDATED")
            strSql.Append(" , UPDATED_BY")
            strSql.Append(" , OLD_VALIN_FROM")
            strSql.Append(" , OLD_VALIN_TO")
            strSql.Append(" , NEW_VALID_FROM")
            strSql.Append(" , NEW_VALID_TO")
            strSql.Append(" , AUTHORIZED_BY")
            strSql.Append(" , COMMENT")
            strSql.Append(" )VALUES(")
            strSql.Append(String.Format(" {0}", pCertificateId))
            strSql.Append(" , GetDate()")
            strSql.Append(String.Format(" , '{0}'", pUpdateBy))
            strSql.Append(String.Format(" , convert(date,'{0}')", pOldValidFrom.ToString("MM/dd/yyyy")))
            strSql.Append(String.Format(" , convert(date,'{0}')", pOldValidTo.ToString("MM/dd/yyyy")))
            strSql.Append(String.Format(" , convert(date,'{0}')", pNewdValidFrom.ToString("MM/dd/yyyy")))
            strSql.Append(String.Format(" , convert(date,'{0}')", pNewValidTo.ToString("MM/dd/yyyy")))
            strSql.Append(String.Format(" , '{0}'", pAuthorizedBy))
            strSql.Append(String.Format(" , '{0}'", pComment))
            strSql.Append(" )")

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

    <WebMethod(Description:="Get Certificate Log")> _
    Public Function GetCertificateLOG(ByRef pCertificateId As Integer, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        Dim strSql As New StringBuilder
        strSql.Append(" SELECT *")
        strSql.Append(String.Format(" FROM {0}OP_WMS_CERTIFICATE_LOG ", DefaultSchema))
        strSql.Append(String.Format(" WHERE CERTIFICATE_ID = {0}", pCertificateId))

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "GetCertificateLOG")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR, No existen encontraron registros."
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If
    End Function

    <WebMethod(Description:="Search specific Clima location")> _
    Public Function SelectCurrency(ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String = ""
        XSQL = "SELECT * FROM " & DefaultSchema & "OP_WMS_FUNC_GET_CURRENCY() "
        XSQL = XSQL + " ORDER BY NUMERIC_VALUE "


        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "SelectCurrency")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR,No existen tipos de moneda "
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function

#Region "Kardex"

    <WebMethod(Description:="Get Kardex Certificate")> _
    Public Function GetKardexCertificate(ByVal pUsers As String, ByVal pNameTable As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataTable

        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()
        Try
            Dim cmd As New SqlCommand
            Dim reader As SqlDataReader
            Dim dt As DataTable = New DataTable(pNameTable)
            cmd.CommandText = String.Format("{0}OP_WMS_SP_KARDEX_CERTIFICATE_GET", DefaultSchema)
            cmd.Parameters.Add("@USERS", SqlDbType.VarChar, 50)
            cmd.Parameters("@USERS").Value = pUsers

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            reader = cmd.ExecuteReader()

            dt.Load(reader)
            sqldbConexion.Close()
            pResult = "OK"
            Return dt
        Catch ex As Exception
            pResult = ex.Message
            Return Nothing
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try
    End Function


    <WebMethod(Description:="Get Kardex Certificate")> _
    Public Function GetKardexConsultation(ByVal pCertificateId As Integer, ByVal pNameTable As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataTable

        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()
        Try
            Dim cmd As New SqlCommand
            Dim reader As SqlDataReader
            Dim dt As DataTable = New DataTable(pNameTable)
            cmd.CommandText = String.Format("{0}OP_WMS_SP_KARDEX_GET", DefaultSchema)
            cmd.Parameters.Add("@CERTIFICADO_ID", SqlDbType.Int)
            cmd.Parameters("@CERTIFICADO_ID").Value = pCertificateId

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            reader = cmd.ExecuteReader()

            dt.Load(reader)
            sqldbConexion.Close()
            pResult = "OK"
            Return dt
        Catch ex As Exception
            pResult = ex.Message
            Return Nothing
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try
    End Function

    <WebMethod(Description:="Inserta un Kardex ")> _
    Public Function InsertKardex(ByVal pCertificateId As Integer, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()
        Try
            Dim cmd As New SqlCommand

            cmd.CommandText = String.Format("{0}OP_WMS_SP_KARDEX_INSERT", DefaultSchema)
            cmd.Parameters.Add("@CERTIFICADO_ID", SqlDbType.Int)
            cmd.Parameters("@CERTIFICADO_ID").Value = pCertificateId

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            cmd.ExecuteNonQuery()
            sqldbConexion.Close()
            pResult = "OK"
        Catch ex As Exception
            pResult = ex.Message
            Return False
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try
        Return True
    End Function

    <WebMethod(Description:="Actualiza un Kardex")> _
    Public Function UpdatedKardex(ByVal pKardexId As Integer, ByVal pCurrentBalace As Decimal, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = String.Format("{0}OP_WMS_SP_KARDEX_UPDATED", DefaultSchema)
            cmd.Parameters.Add("@KARDEX_ID", SqlDbType.Int)
            cmd.Parameters("@KARDEX_ID").Value = pKardexId
            cmd.Parameters.Add("@CURRENT_BALACE", SqlDbType.Decimal)
            cmd.Parameters("@CURRENT_BALACE").Value = pCurrentBalace

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            cmd.ExecuteNonQuery()
            sqldbConexion.Close()
            pResult = "OK"
        Catch ex As Exception
            pResult = ex.Message
            Return False
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try
        Return True
    End Function

    <WebMethod(Description:="Get Kardex TXNS")> _
    Public Function GetKardexTxns(ByVal pCertificateId As Integer, ByVal pFechaInicio As Date, ByVal pFechaFinal As Date, ByVal pNameTable As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataTable

        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()
        Try
            Dim cmd As New SqlCommand
            Dim reader As SqlDataReader
            Dim dt As DataTable = New DataTable(pNameTable)
            cmd.CommandText = String.Format("{0}OP_WMS_SP_KARDEX_TXNS_GET", DefaultSchema)
            cmd.Parameters.Add("@CERTIFICADO_ID", SqlDbType.Int)
            cmd.Parameters("@CERTIFICADO_ID").Value = pCertificateId
            cmd.Parameters.Add("@FechaInicio", SqlDbType.Date)
            cmd.Parameters("@FechaInicio").Value = pFechaInicio
            cmd.Parameters.Add("@FechaFinal", SqlDbType.Date)
            cmd.Parameters("@FechaFinal").Value = pFechaFinal

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            reader = cmd.ExecuteReader()

            dt.Load(reader)
            sqldbConexion.Close()
            pResult = "OK"
            Return dt
        Catch ex As Exception
            pResult = ex.Message
            Return Nothing
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try
    End Function

    <WebMethod(Description:="Inserta un Kardex TXNS")> _
    Public Function InsertKardexTxns(ByVal pCertificateId As Integer, pTxDate As Date, ByVal pTxReceipts As Decimal,
                                     ByVal pTxDispactil As Decimal, ByVal pTxLastBalace As Decimal, ByVal pTxCurrentBalance As Decimal,
                                     ByVal pSku As String, ByVal pSkuDescription As String, ByVal pCost As Decimal, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()
        Try
            Dim cmd As New SqlCommand

            cmd.CommandText = String.Format("{0}OP_WMS_SP_KARDEX_TXNS_INSERT", DefaultSchema)
            cmd.Parameters.Add("@CERTIFICADO_ID", SqlDbType.Int)
            cmd.Parameters("@CERTIFICADO_ID").Value = pCertificateId

            cmd.Parameters.Add("@TX_DATE", SqlDbType.Date)
            cmd.Parameters("@TX_DATE").Value = pTxDate

            cmd.Parameters.Add("@TX_RECEIPTS", SqlDbType.Decimal)
            cmd.Parameters("@TX_RECEIPTS").Value = pTxReceipts

            cmd.Parameters.Add("@TX_DISPACTIL", SqlDbType.Decimal)
            cmd.Parameters("@TX_DISPACTIL").Value = pTxDispactil

            cmd.Parameters.Add("@TX_LAST_BALACE", SqlDbType.Decimal)
            cmd.Parameters("@TX_LAST_BALACE").Value = pTxLastBalace

            cmd.Parameters.Add("@TX_CURRENT_BALANCE", SqlDbType.Decimal)
            cmd.Parameters("@TX_CURRENT_BALANCE").Value = pTxCurrentBalance

            cmd.Parameters.Add("@SKU", SqlDbType.VarChar, 50)
            cmd.Parameters("@SKU").Value = pSku

            cmd.Parameters.Add("@SKU_DESCRIPTION", SqlDbType.VarChar, 200)
            cmd.Parameters("@SKU_DESCRIPTION").Value = pSkuDescription

            cmd.Parameters.Add("@COST", SqlDbType.Money)
            cmd.Parameters("@COST").Value = pCost

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            cmd.ExecuteNonQuery()
            sqldbConexion.Close()
            pResult = "OK"
        Catch ex As Exception
            pResult = ex.Message
            Return False
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try
        Return True
    End Function

#End Region

#Region "Certificado Deposito"

    <WebMethod(Description:="GetDocByCliente")> _
    Public Function GetDocByCliente(ByVal pNameTable As String, ByVal pClienteId As String, ByVal pFechaInicio As Date, ByVal pFechaFinal As Date, ByRef pResult As String, ByVal pEnvironmentName As String) As DataTable

        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()
        Try
            Dim cmd As New SqlCommand
            Dim reader As SqlDataReader
            Dim dt As DataTable = New DataTable(pNameTable)
            cmd.CommandText = String.Format("{0}OP_WMS_SP_GET_DOC_BY_CLIENT", DefaultSchema)
            cmd.Parameters.Add("@CLIENT_CODE", SqlDbType.VarChar, 50).Value = pClienteId

            cmd.Parameters.Add("@DATE_START", SqlDbType.Date).Value = pFechaInicio
            cmd.Parameters.Add("@DATE_END", SqlDbType.Date).Value = pFechaFinal

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            reader = cmd.ExecuteReader()

            dt.Load(reader)
            sqldbConexion.Close()
            Return dt
        Catch ex As Exception
            pResult = ex.Message
            Return Nothing
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try
    End Function

    <WebMethod(Description:="GetDetailByDocForCertificate")> _
    Public Function GetDetailByDocForCertificateAlmge(ByVal pNameTable As String, ByVal pDocId As Integer, ByRef pResult As String, ByVal pEnvironmentName As String) As DataTable

        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()
        Try
            Dim cmd As New SqlCommand
            Dim reader As SqlDataReader
            Dim dt As DataTable = New DataTable(pNameTable)
            cmd.CommandText = String.Format("{0}OP_WMS_SP_GET_DETAIL_BY_DOC_FOR_CERTIFICATE_ALMGEN", DefaultSchema)
            cmd.Parameters.Add("@DOC_ID", SqlDbType.Int).Value = pDocId

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            reader = cmd.ExecuteReader()

            dt.Load(reader)
            sqldbConexion.Close()
            Return dt
        Catch ex As Exception
            pResult = ex.Message
            Return Nothing
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try
    End Function

    <WebMethod(Description:="GetDetailByDocForCertificate")> _
    Public Function GetDetailByDocForCertificate(ByVal pNameTable As String, ByVal pDocId As Integer, ByRef pResult As String, ByVal pEnvironmentName As String) As DataTable

        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()
        Try
            Dim cmd As New SqlCommand
            Dim reader As SqlDataReader
            Dim dt As DataTable = New DataTable(pNameTable)
            cmd.CommandText = String.Format("{0}OP_WMS_SP_GET_DETAIL_BY_DOC_FOR_CERTIFICATE", DefaultSchema)
            cmd.Parameters.Add("@DOC_ID", SqlDbType.Int).Value = pDocId

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            reader = cmd.ExecuteReader()

            dt.Load(reader)
            sqldbConexion.Close()
            Return dt
        Catch ex As Exception
            pResult = ex.Message
            Return Nothing
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try
    End Function

    <WebMethod(Description:="GetCertificateDepositByClient")> _
    Public Function GetCertificateDepositByClient(ByVal pNameTable As String, ByVal pClienteId As String, ByVal pFechaInicio As Date, ByVal pFechaFinal As Date, ByRef pResult As String, ByVal pEnvironmentName As String) As DataTable

        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()
        Try
            Dim cmd As New SqlCommand
            Dim reader As SqlDataReader
            Dim dt As DataTable = New DataTable(pNameTable)
            cmd.CommandText = String.Format("{0}OP_WMS_SP_GET_ALL_CERTIFICATE_DEPOSIT_HEADER_BY_CLIENT_CODE", DefaultSchema)
            cmd.Parameters.Add("@CLIENT_CODE", SqlDbType.VarChar, 50).Value = pClienteId

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            reader = cmd.ExecuteReader()

            dt.Load(reader)
            sqldbConexion.Close()
            Return dt
        Catch ex As Exception
            pResult = ex.Message
            Return Nothing
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try

    End Function

    <WebMethod(Description:="InsertCertificateDepositHeader")> _
    Public Function InsertCertificateDepositHeader(ByVal pNameTable As String, ByVal pValidoInicio As Date, ByVal pValidoFinal As Date,
                                                   ByVal login As String, ByVal status As String, ByVal pClienteId As String,
                                                   ByRef pResult As String, ByVal pEnvironmentName As String) As DataTable

        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()
        Try
            Dim cmd As New SqlCommand
            Dim reader As SqlDataReader
            Dim dt As DataTable = New DataTable(pNameTable)
            cmd.CommandText = String.Format("{0}OP_WMS_SP_INSERT_CERTIFICATE_DEPOSIT_HEADER", DefaultSchema)
            cmd.Parameters.Add("@VALID_FROM", SqlDbType.Date).Value = pValidoInicio
            cmd.Parameters.Add("@VALID_TO", SqlDbType.Date).Value = pValidoFinal
            cmd.Parameters.Add("@NAME_USER", SqlDbType.VarChar, 50).Value = login
            cmd.Parameters.Add("@STATUS", SqlDbType.VarChar, 25).Value = status
            cmd.Parameters.Add("@CLIENT_NODE", SqlDbType.VarChar, 25).Value = pClienteId

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            reader = cmd.ExecuteReader()

            dt.Load(reader)
            sqldbConexion.Close()
            Return dt
        Catch ex As Exception
            pResult = ex.Message
            Return Nothing
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try

    End Function

    <WebMethod(Description:="InsertCertificateDepositDetail")> _
    Public Function InsertCertificateDepositDetail(ByVal pNameTable As String, ByVal certificateIdHedaer As Integer, ByVal docId As Integer, ByVal materialCode As String,
                                                   ByVal skuDescripcion As String, ByVal locations As String, ByVal bultos As Integer, ByVal qty As Decimal, ByVal monto As Decimal,
                                                   ByRef pResult As String, ByVal pEnvironmentName As String) As DataTable

        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()
        Try
            Dim cmd As New SqlCommand
            Dim reader As SqlDataReader
            Dim dt As DataTable = New DataTable(pNameTable)
            cmd.CommandText = String.Format("{0}OP_WMS_SP_INSERT_CERTIFICATE_DEPOSIT_DETAIL", DefaultSchema)
            cmd.Parameters.Add("@ID_DEPOSIT_HEADER", SqlDbType.Int).Value = certificateIdHedaer
            cmd.Parameters.Add("@DOC_ID", SqlDbType.Int).Value = docId
            cmd.Parameters.Add("@MATERIAL_CODE", SqlDbType.VarChar, 50).Value = materialCode
            cmd.Parameters.Add("@SKU_DESCRIPTION", SqlDbType.VarChar, 200).Value = skuDescripcion
            cmd.Parameters.Add("@LOCATIONS", SqlDbType.VarChar, 200).Value = locations
            cmd.Parameters.Add("@BULTOS", SqlDbType.Int).Value = bultos
            cmd.Parameters.Add("@QTY", SqlDbType.Decimal).Value = qty
            cmd.Parameters.Add("@CUSTOM_AMOUNT", SqlDbType.Decimal).Value = monto


            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            reader = cmd.ExecuteReader()

            dt.Load(reader)
            sqldbConexion.Close()
            Return dt
        Catch ex As Exception
            pResult = ex.Message
            Return Nothing
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try

    End Function

    <WebMethod(Description:="GetCertificateDepositDetail")> _
    Public Function GetCertificateDepositDetail(ByVal pNameTable As String, ByVal certificateIdHedaer As Integer,
                                                   ByRef pResult As String, ByVal pEnvironmentName As String) As DataTable

        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()
        Try
            Dim cmd As New SqlCommand
            Dim reader As SqlDataReader
            Dim dt As DataTable = New DataTable(pNameTable)
            cmd.CommandText = String.Format("{0}OP_WMS_SP_GET_CERTIFICATE_DEPOSIT_DETAIL_BY_HEADER", DefaultSchema)

            cmd.Parameters.Add("@ID_DEPOSIT_HEADER", SqlDbType.Int).Value = certificateIdHedaer

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            reader = cmd.ExecuteReader()

            dt.Load(reader)
            sqldbConexion.Close()
            Return dt
        Catch ex As Exception
            pResult = ex.Message
            Return Nothing
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try

    End Function

    <WebMethod(Description:="GetCertificateDepositDetail")> _
    Public Function SetStatusCertificateDeposit(ByVal certificateDeposit As Integer, ByVal status As String, ByVal login As String, ByVal comentario As String,
                                                   ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()
        Try
            Dim cmd As New SqlCommand

            cmd.CommandText = String.Format("{0}OP_WMS_SP_SET_STATUS_CERTIFICATE_DEPOSIT_HEADER", DefaultSchema)

            cmd.Parameters.Add("@ID_DEPOSIT_HEADER", SqlDbType.Int).Value = certificateDeposit
            cmd.Parameters.Add("@STATUS", SqlDbType.VarChar, 25).Value = status
            cmd.Parameters.Add("@LOGIN", SqlDbType.VarChar, 25).Value = login
            cmd.Parameters.Add("@COMMET", SqlDbType.VarChar, 250).Value = comentario

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            cmd.ExecuteNonQuery()
            sqldbConexion.Close()

            Return True
        Catch ex As Exception
            pResult = ex.Message
            Return False
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try

    End Function


    <WebMethod(Description:="GetCertificateDepositDetail")> _
    Public Function DeleteDetailCertificate(ByVal certificateDeposit As Integer,
                                                   ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()
        Try
            Dim cmd As New SqlCommand
            Dim reader As SqlDataReader

            cmd.CommandText = String.Format("{0}OP_WMS_SP_DELETE_CERTIFICATE_DEPOSIT_DETAIL_FOR_CERTIFICATE_DEPOSIT_HEADER", DefaultSchema)

            cmd.Parameters.Add("@ID_DEPOSIT_HEADER", SqlDbType.Int).Value = certificateDeposit

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            cmd.ExecuteNonQuery()
            sqldbConexion.Close()

            Return True
        Catch ex As Exception
            pResult = ex.Message
            Return False
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try

    End Function

    <WebMethod(Description:="GetCertificateDepositDetail")> _
    Public Function UpdateCertificateDepositHeder(ByVal certificateDeposit As Integer, ByVal pValidoInicio As Date, ByVal pValidoFinal As Date,
                                                   ByVal login As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()
        Try
            Dim cmd As New SqlCommand
            Dim reader As SqlDataReader

            cmd.CommandText = String.Format("{0}OP_WMS_SP_UPDATE_CERTIFICATE_DEPOSIT_HEADER", DefaultSchema)

            cmd.Parameters.Add("@ID_DEPOSIT_HEADER", SqlDbType.Int).Value = certificateDeposit
            cmd.Parameters.Add("@VALID_FROM", SqlDbType.Date).Value = pValidoInicio
            cmd.Parameters.Add("@VALID_TO", SqlDbType.Date).Value = pValidoFinal
            cmd.Parameters.Add("@LAST_UPDATED_BY", SqlDbType.VarChar, 25).Value = login

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            cmd.ExecuteNonQuery()
            sqldbConexion.Close()

            Return True
        Catch ex As Exception
            pResult = ex.Message
            Return False
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try

    End Function

    <WebMethod(Description:="GetCertificateDepositDetail")> _
    Public Function InsertarLogCertificado(ByVal certificadoDepositoId As Integer, ByVal login As String,
                                            ByVal comentario As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()
        Try
            Dim cmd As New SqlCommand

            cmd.CommandText = String.Format("{0}OP_WMS_INSERT_CERTIFICATE_DEPOSIT_LOG", DefaultSchema)

            cmd.Parameters.Add("@CERTIFICATE_DEPOSIT_ID_HEADER", SqlDbType.Int).Value = certificadoDepositoId
            cmd.Parameters.Add("@LOIGN", SqlDbType.VarChar).Value = login
            cmd.Parameters.Add("@COMMET", SqlDbType.VarChar).Value = comentario

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            cmd.ExecuteNonQuery()
            sqldbConexion.Close()

            Return True
        Catch ex As Exception
            pResult = ex.Message
            Return False
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try

    End Function


#End Region

End Class