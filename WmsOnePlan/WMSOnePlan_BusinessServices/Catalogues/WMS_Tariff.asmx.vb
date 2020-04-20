Imports System.Web.Services
Imports System.ComponentModel
Imports System.Configuration.ConfigurationManager

' Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente.
' <System.Web.Script.Services.ScriptService()> _
Imports System.Data.SqlClient

<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class WMS_Tariff
    Inherits WebService


#Region "TypeChange"

    <WebMethod(Description:="Create un Type Change")> _
    Public Function CreateTypeChange(ByVal pChange As String, ByVal pDescription As String, ByVal pWareHouseWeather As String,
                                     ByVal pRegimen As String, ByVal pComent As String, ByVal pDayTrip As String,
                                     ByVal pTypeService As String, ByVal pToMovi As Integer,
                                     ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()
        Try
            Dim cmd As New SqlCommand

            cmd.CommandText = String.Format("{0}OP_WMS_SP_CREATE_TYPE_CHANGE", DefaultSchema)
            cmd.Parameters.Add("@CHARGE", SqlDbType.VarChar)
            cmd.Parameters("@CHARGE").Value = pChange

            cmd.Parameters.Add("@DESCRIPTION", SqlDbType.VarChar)
            cmd.Parameters("@DESCRIPTION").Value = pDescription

            cmd.Parameters.Add("@WAREHOUSE_WEATHER", SqlDbType.VarChar)
            cmd.Parameters("@WAREHOUSE_WEATHER").Value = pWareHouseWeather

            cmd.Parameters.Add("@REGIMEN", SqlDbType.VarChar)
            cmd.Parameters("@REGIMEN").Value = pRegimen

            cmd.Parameters.Add("@COMMENT", SqlDbType.VarChar)
            cmd.Parameters("@COMMENT").Value = pComent
            cmd.Parameters.Add("@DAY_TRIP", SqlDbType.VarChar)
            cmd.Parameters("@DAY_TRIP").Value = pDayTrip

            cmd.Parameters.Add("@SERVICE_CODE", SqlDbType.VarChar)
            cmd.Parameters("@SERVICE_CODE").Value = pTypeService

            cmd.Parameters.Add("@TO_MOVIL", SqlDbType.Int)
            cmd.Parameters("@TO_MOVIL").Value = pToMovi

            cmd.Parameters.Add("@pResult", SqlDbType.VarChar, 250)
            cmd.Parameters("@pResult").Direction = ParameterDirection.Output
            cmd.Parameters("@pResult").Value = ""


            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            cmd.ExecuteNonQuery()
            sqldbConexion.Close()
            pResult = cmd.Parameters("@pRESULT").Value
        Catch ex As Exception
            pResult = ex.Message
            Return False
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try
        Return True
    End Function

    <WebMethod(Description:="Update un Type Change")> _
    Public Function UpdateTypeChange(ByVal pTypeChangeId As Integer, ByVal pChange As String, ByVal pDescription As String, ByVal pWareHouseWeather As String,
                                     ByVal pRegimen As String, ByVal pComent As String, ByVal pDayTrip As String,
                                     ByVal pTypeService As String, ByVal pToMovi As Integer,
                                     ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()
        Try
            Dim cmd As New SqlCommand

            cmd.CommandText = String.Format("{0}OP_WMS_SP_UPDATE_TYPE_CHANGE", DefaultSchema)

            cmd.Parameters.Add("@TYPE_CHARGE_ID", SqlDbType.Int)
            cmd.Parameters("@TYPE_CHARGE_ID").Value = pTypeChangeId

            cmd.Parameters.Add("@CHARGE", SqlDbType.VarChar)
            cmd.Parameters("@CHARGE").Value = pChange

            cmd.Parameters.Add("@DESCRIPTION", SqlDbType.VarChar)
            cmd.Parameters("@DESCRIPTION").Value = pDescription

            cmd.Parameters.Add("@WAREHOUSE_WEATHER", SqlDbType.VarChar)
            cmd.Parameters("@WAREHOUSE_WEATHER").Value = pWareHouseWeather

            cmd.Parameters.Add("@REGIMEN", SqlDbType.VarChar)
            cmd.Parameters("@REGIMEN").Value = pRegimen

            cmd.Parameters.Add("@COMMENT", SqlDbType.VarChar)
            cmd.Parameters("@COMMENT").Value = pComent
            cmd.Parameters.Add("@DAY_TRIP", SqlDbType.VarChar)
            cmd.Parameters("@DAY_TRIP").Value = pDayTrip

            cmd.Parameters.Add("@SERVICE_CODE", SqlDbType.VarChar)
            cmd.Parameters("@SERVICE_CODE").Value = pTypeService

            cmd.Parameters.Add("@TO_MOVIL", SqlDbType.Int)
            cmd.Parameters("@TO_MOVIL").Value = pToMovi

            cmd.Parameters.Add("@pResult", SqlDbType.VarChar, 250)
            cmd.Parameters("@pResult").Direction = ParameterDirection.Output
            cmd.Parameters("@pResult").Value = ""


            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            cmd.ExecuteNonQuery()
            sqldbConexion.Close()
            pResult = cmd.Parameters("@pRESULT").Value.ToString
        Catch ex As Exception
            pResult = ex.Message
            Return False
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try
        Return True
    End Function

    <WebMethod(Description:="Delete un Type Change")> _
    Public Function DeleteTypeChange(ByVal pTypeChangeId As Integer, 
                                     ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()
        Try
            Dim cmd As New SqlCommand

            cmd.CommandText = String.Format("{0}OP_WMS_SP_DELETE_TYPE_CHANGE", DefaultSchema)

            cmd.Parameters.Add("@TYPE_CHARGE_ID", SqlDbType.Int)
            cmd.Parameters("@TYPE_CHARGE_ID").Value = pTypeChangeId
            

            cmd.Parameters.Add("@pResult", SqlDbType.VarChar, 250)
            cmd.Parameters("@pResult").Direction = ParameterDirection.Output
            cmd.Parameters("@pResult").Value = ""


            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            cmd.ExecuteNonQuery()
            sqldbConexion.Close()
            pResult = cmd.Parameters("@pRESULT").Value.ToString
        Catch ex As Exception
            pResult = ex.Message
            Return False
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try
        Return True
    End Function

    <WebMethod(Description:="Get Type Change")> _
    Public Function GetTypeChange(ByRef pResult As String, ByVal pEnvironmentName As String) As DataTable

        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        Dim strSql As New StringBuilder
        strSql.Append(" SELECT * ")
        strSql.Append(" , CASE t.TO_MOVIL WHEN 1 THEN 'SI' ELSE 'NO' END AS MOVIL ")
        strSql.Append(String.Format(" FROM {0}OP_WMS_TYPE_CHARGE t", DefaultSchema))
        strSql.Append(String.Format(" INNER JOIN {0}OP_WMS_VIEW_SERVICES s ON t.SERVICE_CODE = s.SERVICE_CODE", DefaultSchema))

        Dim miscDa As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqldbConexion)
        Dim miscDt As DataTable = New DataTable("GetTypeChange")
        Try
            miscDa.Fill(miscDt)
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDt.Rows.Count <= 0 Then
            pResult = "ERROR, No se econtraron registro."
            Return Nothing
        Else
            pResult = "OK"
            Return miscDt
        End If

    End Function

    <WebMethod(Description:="Get Type Change")> _
    Public Function GetTypeChangeXRegimenClima(ByVal pRegimen As String, ByVal pClima As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataTable

        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        Dim strSql As New StringBuilder
        strSql.Append(" SELECT *")
        strSql.Append(String.Format(" FROM {0}OP_WMS_TYPE_CHARGE", DefaultSchema))
        strSql.Append(String.Format(" WHERE REGIMEN LIKE '%{0}%'", pRegimen))
        strSql.Append(String.Format(" AND WAREHOUSE_WEATHER LIKE '%{0}%' OR WAREHOUSE_WEATHER = 'N/A'", pClima))

        Dim miscDa As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqldbConexion)
        Dim miscDt As DataTable = New DataTable("GetTypeChange")
        Try
            miscDa.Fill(miscDt)
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDt.Rows.Count <= 0 Then
            pResult = "ERROR, No se econtraron registro."
            Return Nothing
        Else
            pResult = "OK"
            Return miscDt
        End If

    End Function

    <WebMethod(Description:="Fill Type Change")> _
    Public Function FillTypeChange(ByVal pTypeChangeId As Integer, ByRef pResult As String, ByVal pEnvironmentName As String) As DataTable

        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        Dim strSql As New StringBuilder
        strSql.Append(" SELECT *")
        strSql.Append(String.Format(" FROM {0}OP_WMS_TYPE_CHARGE", DefaultSchema))
        strSql.Append(String.Format(" WHERE TYPE_CHARGE_ID = {0}", pTypeChangeId))

        Dim miscDa As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqldbConexion)
        Dim miscDt As DataTable = New DataTable("FillTypeChange")
        Try
            miscDa.Fill(miscDt)
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDt.Rows.Count <= 0 Then
            pResult = "ERROR, No se econtraron registro."
            Return Nothing
        Else
            pResult = "OK"
            Return miscDt
        End If

    End Function

    <WebMethod(Description:="Get Services")> _
    Public Function GetServices(ByRef pResult As String, ByVal pEnvironmentName As String) As DataTable

        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        Dim strSql As New StringBuilder
        strSql.Append(" SELECT *")
        strSql.Append(String.Format(" FROM {0}OP_WMS_VIEW_SERVICES", DefaultSchema))

        Dim miscDa As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqldbConexion)
        Dim miscDt As DataTable = New DataTable("GetServices")
        Try
            miscDa.Fill(miscDt)
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDt.Rows.Count <= 0 Then
            pResult = "ERROR, No se econtraron registro."
            Return Nothing
        Else
            pResult = "OK"
            Return miscDt
        End If

    End Function

#End Region

#Region "TarificadorHeader"

    <WebMethod(Description:="Create un Tarificador Header")> _
    Public Function CreateTarificadorHeader(ByRef pAcuerdoComercialId As Integer, ByVal pAcuerdoComercialNombre As String, ByVal pValidFrom As Date, ByVal pValidTo As Date,
                                     ByVal pExpires As Integer, ByVal pCurrency As String, ByVal pStatus As String,
                                     ByVal pWarehouseWeather As String, ByVal pComments As String, ByVal pRegimen As String, ByVal pAuthorizer As String,
                                     ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()
        Try
            Dim cmd As New SqlCommand

            cmd.CommandText = String.Format("{0}OP_WMS_SP_CREATE_TARIFICADOR_HEADER", DefaultSchema)

            cmd.Parameters.Add("@ACUERDO_COMERCIAL_NOMBRE", SqlDbType.VarChar)
            cmd.Parameters("@ACUERDO_COMERCIAL_NOMBRE").Value = pAcuerdoComercialNombre

            cmd.Parameters.Add("@VALID_FROM", SqlDbType.Date)
            cmd.Parameters("@VALID_FROM").Value = pValidFrom

            cmd.Parameters.Add("@VALID_TO", SqlDbType.Date)
            cmd.Parameters("@VALID_TO").Value = pValidTo

            cmd.Parameters.Add("@EXPIRES", SqlDbType.Int)
            cmd.Parameters("@EXPIRES").Value = pExpires

            cmd.Parameters.Add("@CURRENCY", SqlDbType.VarChar)
            cmd.Parameters("@CURRENCY").Value = pCurrency

            cmd.Parameters.Add("@STATUS", SqlDbType.VarChar)
            cmd.Parameters("@STATUS").Value = pStatus

            cmd.Parameters.Add("@WAREHOUSE_WEATHER", SqlDbType.VarChar)
            cmd.Parameters("@WAREHOUSE_WEATHER").Value = pWarehouseWeather

            cmd.Parameters.Add("@COMMENTS", SqlDbType.VarChar)
            cmd.Parameters("@COMMENTS").Value = pComments

            cmd.Parameters.Add("@REGIMEN", SqlDbType.VarChar)
            cmd.Parameters("@REGIMEN").Value = pRegimen

            cmd.Parameters.Add("@AUTHORIZER", SqlDbType.VarChar)
            cmd.Parameters("@AUTHORIZER").Value = pAuthorizer

            cmd.Parameters.Add("@AcuerdoComercialId", SqlDbType.Int)
            cmd.Parameters("@AcuerdoComercialId").Direction = ParameterDirection.Output
            cmd.Parameters("@AcuerdoComercialId").Value = 0

            cmd.Parameters.Add("@pResult", SqlDbType.VarChar, 250)
            cmd.Parameters("@pResult").Direction = ParameterDirection.Output
            cmd.Parameters("@pResult").Value = ""


            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            cmd.ExecuteNonQuery()
            sqldbConexion.Close()
            pResult = cmd.Parameters("@pRESULT").Value.ToString
            pAcuerdoComercialId = Integer.Parse(cmd.Parameters("@AcuerdoComercialId").Value.ToString())
        Catch ex As Exception
            pResult = ex.Message
            Return False
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try
        Return True
    End Function

    <WebMethod(Description:="Update un Tarificador Header")> _
    Public Function UpdateTarificadorHeader(ByVal pAcuerdoComercialId As Integer, ByVal pAcuerdoComercialNombre As String, ByVal pValidFrom As Date, ByVal pValidTo As Date,
                                     ByVal pExpires As Integer, ByVal pCurrency As String, ByVal pStatus As String, ByVal pLastUpdatedBy As String,
                                     ByVal pWarehouseWeather As String, ByVal pComments As String, ByVal pRegimen As String, ByVal pAuthorizer As String,
                                     ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()
        Try
            Dim cmd As New SqlCommand

            cmd.CommandText = String.Format("{0}OP_WMS_SP_UPDATE_TARIFICADOR_HEADER", DefaultSchema)

            cmd.Parameters.Add("@ACUERDO_COMERCIAL_ID", SqlDbType.VarChar)
            cmd.Parameters("@ACUERDO_COMERCIAL_ID").Value = pAcuerdoComercialId

            cmd.Parameters.Add("@ACUERDO_COMERCIAL_NOMBRE", SqlDbType.VarChar)
            cmd.Parameters("@ACUERDO_COMERCIAL_NOMBRE").Value = pAcuerdoComercialNombre

            cmd.Parameters.Add("@VALID_FROM", SqlDbType.Date)
            cmd.Parameters("@VALID_FROM").Value = pValidFrom

            cmd.Parameters.Add("@VALID_TO", SqlDbType.Date)
            cmd.Parameters("@VALID_TO").Value = pValidTo

            cmd.Parameters.Add("@EXPIRES", SqlDbType.Int)
            cmd.Parameters("@EXPIRES").Value = pExpires

            cmd.Parameters.Add("@CURRENCY", SqlDbType.VarChar)
            cmd.Parameters("@CURRENCY").Value = pCurrency

            cmd.Parameters.Add("@STATUS", SqlDbType.VarChar)
            cmd.Parameters("@STATUS").Value = pStatus

            cmd.Parameters.Add("@WAREHOUSE_WEATHER", SqlDbType.VarChar)
            cmd.Parameters("@WAREHOUSE_WEATHER").Value = pWarehouseWeather

            cmd.Parameters.Add("@LAST_UPDATED_BY", SqlDbType.VarChar)
            cmd.Parameters("@LAST_UPDATED_BY").Value = pLastUpdatedBy

            cmd.Parameters.Add("@COMMENTS", SqlDbType.VarChar)
            cmd.Parameters("@COMMENTS").Value = pComments

            cmd.Parameters.Add("@REGIMEN", SqlDbType.VarChar)
            cmd.Parameters("@REGIMEN").Value = pRegimen

            cmd.Parameters.Add("@AUTHORIZER", SqlDbType.VarChar)
            cmd.Parameters("@AUTHORIZER").Value = pAuthorizer

            cmd.Parameters.Add("@pResult", SqlDbType.VarChar, 250)
            cmd.Parameters("@pResult").Direction = ParameterDirection.Output
            cmd.Parameters("@pResult").Value = ""

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            cmd.ExecuteNonQuery()
            sqldbConexion.Close()
            pResult = cmd.Parameters("@pRESULT").Value.ToString
        Catch ex As Exception
            pResult = ex.Message
            Return False
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try
        Return True
    End Function

    <WebMethod(Description:="Delete un Tarificador Header")> _
    Public Function DeleteTarificadorHeader(ByVal pAcuerdoComercialId As Integer,
                                     ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()
        Try
            Dim cmd As New SqlCommand

            cmd.CommandText = String.Format("{0}OP_WMS_SP_DELETE_TARIFICADOR_HEADER", DefaultSchema)

            cmd.Parameters.Add("@ACUERDO_COMERCIAL_ID", SqlDbType.VarChar)
            cmd.Parameters("@ACUERDO_COMERCIAL_ID").Value = pAcuerdoComercialId

            cmd.Parameters.Add("@pResult", SqlDbType.VarChar, 250)
            cmd.Parameters("@pResult").Direction = ParameterDirection.Output
            cmd.Parameters("@pResult").Value = ""

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            cmd.ExecuteNonQuery()
            sqldbConexion.Close()
            pResult = cmd.Parameters("@pRESULT").Value.ToString
        Catch ex As Exception
            pResult = ex.Message
            Return False
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try
        Return True
    End Function

    <WebMethod(Description:="Get Tarifario Header")> _
    Public Function GetTarifarioHeaer(ByRef pResult As String, ByVal pEnvironmentName As String) As DataTable

        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        Dim strSql As New StringBuilder
        strSql.Append(" SELECT *")
        strSql.Append(String.Format(" FROM {0}OP_WMS_TARIFICADOR_HEADER", DefaultSchema))

        Dim miscDa As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqldbConexion)
        Dim miscDt As DataTable = New DataTable("GetTarifarioHeaer")
        Try
            miscDa.Fill(miscDt)
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDt.Rows.Count <= 0 Then
            pResult = "ERROR, No se econtraron registro."
            Return Nothing
        Else
            pResult = "OK"
            Return miscDt
        End If

    End Function

    <WebMethod(Description:="Fill Tarificador Header")> _
    Public Function FillTarificadoHeader(ByVal pAcuerdoComercialId As Integer, ByRef pResult As String, ByVal pEnvironmentName As String) As DataTable

        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        Dim strSql As New StringBuilder
        strSql.Append(" SELECT *")
        strSql.Append(String.Format(" FROM {0}OP_WMS_TARIFICADOR_HEADER", DefaultSchema))
        strSql.Append(String.Format(" WHERE ACUERDO_COMERCIAL_ID = {0}", pAcuerdoComercialId))

        Dim miscDa As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqldbConexion)
        Dim miscDt As DataTable = New DataTable("FillTarificadoHeader")
        Try
            miscDa.Fill(miscDt)
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDt.Rows.Count <= 0 Then
            pResult = "ERROR, No se econtraron registro."
            Return Nothing
        Else
            pResult = "OK"
            Return miscDt
        End If
    End Function

#End Region

#Region "TarificadorDetail"

    <WebMethod(Description:="Create un Tarificador Detail")> _
    Public Function CreateTarificadorDetail(ByVal pAcuerdoComercial As Integer, ByVal pClientId As String,
                                     ByVal pTransName As Integer, ByVal pUnitPrice As Integer, ByVal pCurrency As String,
                                     ByVal pComments As String, ByVal pBillingFrecuency As Integer, ByVal pLimitTo As Integer,
                                     ByVal pUMeasure As String, ByVal pTxSource As String, ByVal pTypeMeause As String,
                                     ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()
        Try
            Dim cmd As New SqlCommand

            cmd.CommandText = String.Format("{0}OP_WMS_SP_CREATE_TARIFICADOR_DETAIL", DefaultSchema)

            cmd.Parameters.Add("@ACUERDO_COMERCIAL", SqlDbType.Int)
            cmd.Parameters("@ACUERDO_COMERCIAL").Value = pAcuerdoComercial

            cmd.Parameters.Add("@TYPE_CHARGE_ID", SqlDbType.Int)
            cmd.Parameters("@TYPE_CHARGE_ID").Value = pTransName

            cmd.Parameters.Add("@UNIT_PRICE", SqlDbType.Int)
            cmd.Parameters("@UNIT_PRICE").Value = pUnitPrice

            cmd.Parameters.Add("@CURRENCY", SqlDbType.VarChar)
            cmd.Parameters("@CURRENCY").Value = pCurrency

            cmd.Parameters.Add("@COMMENTS", SqlDbType.VarChar)
            cmd.Parameters("@COMMENTS").Value = pComments

            cmd.Parameters.Add("@BILLING_FRECUENCY", SqlDbType.Int)
            cmd.Parameters("@BILLING_FRECUENCY").Value = pBillingFrecuency

            cmd.Parameters.Add("@LIMIT_TO", SqlDbType.Int)
            cmd.Parameters("@LIMIT_TO").Value = pLimitTo

            cmd.Parameters.Add("@U_MEASURE", SqlDbType.VarChar)
            cmd.Parameters("@U_MEASURE").Value = pUMeasure

            cmd.Parameters.Add("@TX_SOURCE", SqlDbType.VarChar)
            cmd.Parameters("@TX_SOURCE").Value = pTxSource

            cmd.Parameters.Add("@TYPE_MEASURE", SqlDbType.VarChar)
            cmd.Parameters("@TYPE_MEASURE").Value = pTypeMeause

            cmd.Parameters.Add("@pResult", SqlDbType.VarChar, 250)
            cmd.Parameters("@pResult").Direction = ParameterDirection.Output
            cmd.Parameters("@pResult").Value = ""


            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            cmd.ExecuteNonQuery()
            sqldbConexion.Close()
            pResult = cmd.Parameters("@pRESULT").Value.ToString
        Catch ex As Exception
            pResult = ex.Message
            Return False
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try
        Return True
    End Function

    <WebMethod(Description:="Update un Tarificador Detail")> _
    Public Function UpdateTarificadorDetail(ByVal pAcuerdoComercial As Integer, ByVal pClientId As String, ByVal pSerialId As Integer,
                                     ByVal pTransName As Integer, ByVal pUnitPrice As Integer, ByVal pCurrency As String, ByVal pLastUpdatedBy As String,
                                     ByVal pComments As String, ByVal pBillingFrecuency As Integer, ByVal pLimitTo As Integer,
                                     ByVal pUMeasure As String, ByVal pTxSource As String, ByVal pTypeMeause As String,
                                     ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()
        Try
            Dim cmd As New SqlCommand

            cmd.CommandText = String.Format("{0}OP_WMS_SP_UPDATE_TARIFICADOR_DETAIL", DefaultSchema)

            cmd.Parameters.Add("@ACUERDO_COMERCIAL", SqlDbType.Int)
            cmd.Parameters("@ACUERDO_COMERCIAL").Value = pAcuerdoComercial

            cmd.Parameters.Add("@SERIAL_ID", SqlDbType.Int)
            cmd.Parameters("@SERIAL_ID").Value = pSerialId

            cmd.Parameters.Add("@TYPE_CHARGE_ID", SqlDbType.Int)
            cmd.Parameters("@TYPE_CHARGE_ID").Value = pTransName

            cmd.Parameters.Add("@UNIT_PRICE", SqlDbType.Int)
            cmd.Parameters("@UNIT_PRICE").Value = pUnitPrice

            cmd.Parameters.Add("@CURRENCY", SqlDbType.VarChar)
            cmd.Parameters("@CURRENCY").Value = pCurrency

            cmd.Parameters.Add("@LAST_UPDATED_BY", SqlDbType.VarChar)
            cmd.Parameters("@LAST_UPDATED_BY").Value = pLastUpdatedBy

            cmd.Parameters.Add("@COMMENTS", SqlDbType.VarChar)
            cmd.Parameters("@COMMENTS").Value = pComments

            cmd.Parameters.Add("@BILLING_FRECUENCY", SqlDbType.Int)
            cmd.Parameters("@BILLING_FRECUENCY").Value = pBillingFrecuency

            cmd.Parameters.Add("@LIMIT_TO", SqlDbType.Int)
            cmd.Parameters("@LIMIT_TO").Value = pLimitTo

            cmd.Parameters.Add("@U_MEASURE", SqlDbType.VarChar)
            cmd.Parameters("@U_MEASURE").Value = pUMeasure

            cmd.Parameters.Add("@TX_SOURCE", SqlDbType.VarChar)
            cmd.Parameters("@TX_SOURCE").Value = pTxSource

            cmd.Parameters.Add("@TYPE_MEASURE", SqlDbType.VarChar)
            cmd.Parameters("@TYPE_MEASURE").Value = pTypeMeause

            cmd.Parameters.Add("@pResult", SqlDbType.VarChar, 250)
            cmd.Parameters("@pResult").Direction = ParameterDirection.Output
            cmd.Parameters("@pResult").Value = ""


            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            cmd.ExecuteNonQuery()
            sqldbConexion.Close()
            pResult = cmd.Parameters("@pRESULT").Value.ToString
        Catch ex As Exception
            pResult = ex.Message
            Return False
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try
        Return True
    End Function

    <WebMethod(Description:="U un Tarificador Detail")> _
    Public Function TarificadorDetail(ByVal pAcuerdoComercial As Integer, ByVal pClientId As String, ByVal pSerialId As Integer,
                                      ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()
        Try
            Dim cmd As New SqlCommand

            cmd.CommandText = String.Format("{0}OP_WMS_SP_DELETE_TARIFICADOR_DETAIL", DefaultSchema)

            cmd.Parameters.Add("@ACUERDO_COMERCIAL", SqlDbType.Int)
            cmd.Parameters("@ACUERDO_COMERCIAL").Value = pAcuerdoComercial

            cmd.Parameters.Add("@CLIENT_ID", SqlDbType.VarChar)
            cmd.Parameters("@CLIENT_ID").Value = pClientId

            cmd.Parameters.Add("@SERIAL_ID", SqlDbType.Int)
            cmd.Parameters("@SERIAL_ID").Value = pSerialId

            cmd.Parameters.Add("@pResult", SqlDbType.VarChar, 250)
            cmd.Parameters("@pResult").Direction = ParameterDirection.Output
            cmd.Parameters("@pResult").Value = ""


            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            cmd.ExecuteNonQuery()
            sqldbConexion.Close()
            pResult = cmd.Parameters("@pRESULT").Value.ToString
        Catch ex As Exception
            pResult = ex.Message
            Return False
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try
        Return True
    End Function

    <WebMethod(Description:="Delete un Tarificador Detail")> _
    Public Function DeleteTarificadorDetail(ByVal pAcuerdoComercialId As Integer, ByVal pSerialId As Integer,
                                     ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()
        Try
            Dim cmd As New SqlCommand

            cmd.CommandText = String.Format("{0}OP_WMS_SP_DELETE_TARIFICADOR_DETAIL", DefaultSchema)

            cmd.Parameters.Add("@ACUERDO_COMERCIAL", SqlDbType.Int)
            cmd.Parameters("@ACUERDO_COMERCIAL").Value = pAcuerdoComercialId

            cmd.Parameters.Add("@SERIAL_ID", SqlDbType.Int)
            cmd.Parameters("@SERIAL_ID").Value = pSerialId

            cmd.Parameters.Add("@pResult", SqlDbType.VarChar, 250)
            cmd.Parameters("@pResult").Direction = ParameterDirection.Output
            cmd.Parameters("@pResult").Value = ""

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            cmd.ExecuteNonQuery()
            sqldbConexion.Close()
            pResult = cmd.Parameters("@pRESULT").Value.ToString
        Catch ex As Exception
            pResult = ex.Message
            Return False
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try
        Return True
    End Function

    <WebMethod(Description:="Get Tarifario Detail")> _
    Public Function GetTarifarioDetail(ByVal pAcuerdoComercial As Integer, ByRef pResult As String, ByVal pEnvironmentName As String) As DataTable

        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        Dim strSql As New StringBuilder
        strSql.Append(" SELECT *, DESCRIPTION, PARAM_CAPTION")
        strSql.Append(String.Format(" FROM {0}OP_WMS_TARIFICADOR_DETAIL TD", DefaultSchema))
        strSql.Append(String.Format(" INNER JOIN {0}OP_WMS_TYPE_CHARGE TC ON TD.TYPE_CHARGE_ID = TC.TYPE_CHARGE_ID", DefaultSchema))
        strSql.Append(String.Format(" LEFT JOIN {0}OP_WMS_CONFIGURATIONS C ON C.PARAM_NAME = TD.U_MEASURE ", DefaultSchema))
        strSql.Append(String.Format(" WHERE TD.ACUERDO_COMERCIAL = {0}", pAcuerdoComercial))

        Dim miscDa As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqldbConexion)
        Dim miscDt As DataTable = New DataTable("GetTarifarioDetail")
        Try
            miscDa.Fill(miscDt)
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDt.Rows.Count <= 0 Then
            pResult = "ERROR, No se econtraron registro."
            Return Nothing
        Else
            pResult = "OK"
            Return miscDt
        End If

    End Function

    <WebMethod(Description:="Fill Tarificador Detail")> _
    Public Function FillTarificadoDetail(ByVal pAcuerdoComercialId As Integer, ByVal pClienteId As String, ByVal pSerialId As Integer,
                                         ByRef pResult As String, ByVal pEnvironmentName As String) As DataTable

        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        Dim strSql As New StringBuilder
        strSql.Append(" SELECT *")
        strSql.Append(String.Format(" FROM {0}OP_WMS_TARIFICADOR_DETAIL", DefaultSchema))
        strSql.Append(String.Format(" WHERE ACUERDO_COMERCIAL = {0}", pAcuerdoComercialId))
        strSql.Append(String.Format(" AND CLIENT_ID = '{0}'", pClienteId))
        strSql.Append(String.Format(" AND SERIAL_ID = {0}", pSerialId))

        Dim miscDa As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqldbConexion)
        Dim miscDt As DataTable = New DataTable("FillTarificadoDetail")
        Try
            miscDa.Fill(miscDt)
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDt.Rows.Count <= 0 Then
            pResult = "ERROR, No se econtraron registro."
            Return Nothing
        Else
            pResult = "OK"
            Return miscDt
        End If
    End Function
    
    <WebMethod(Description:="Search specific Clima location")> _
    Public Function SelectMedidas(ByVal pType As String, ByVal pGroup As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataTable

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        Dim strSql As New StringBuilder()
        strSql.Append(String.Format(" SELECT * FROM {0}OP_WMS_FUNC_GET_PARAMETROS_GENERALES('{1}','{2}')", DefaultSchema, pType, pGroup))
        strSql.Append(" ORDER BY NUMERIC_VALUE")

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(strSql.ToString(), sqldb_conexion)
        Dim miscDS As DataTable = New DataTable("SelectMedidas")
        Try
            miscDA.Fill(miscDS)
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Rows.Count <= 0 Then
            pResult = "ERROR,No se econtraron registros. "
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function

#End Region

#Region "AcuerdoXCliente"

    <WebMethod(Description:="Create un Acuerdo por Cliente")> _
    Public Function CreateAcuerdoXCliente(ByVal pAcuerdoComercial As Integer, ByVal pClientId As String,
                                     ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()
        Try
            Dim cmd As New SqlCommand

            cmd.CommandText = String.Format("{0}OP_WMS_SP_CREATE_ACUERDOS_X_CLIENTE", DefaultSchema)

            cmd.Parameters.Add("@ACUERDO_COMERCIAL", SqlDbType.Int)
            cmd.Parameters("@ACUERDO_COMERCIAL").Value = pAcuerdoComercial

            cmd.Parameters.Add("@CLIENT_ID", SqlDbType.VarChar)
            cmd.Parameters("@CLIENT_ID").Value = pClientId

            cmd.Parameters.Add("@pResult", SqlDbType.VarChar, 250)
            cmd.Parameters("@pResult").Direction = ParameterDirection.Output
            cmd.Parameters("@pResult").Value = ""


            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            cmd.ExecuteNonQuery()
            sqldbConexion.Close()
            pResult = cmd.Parameters("@pRESULT").Value.ToString
        Catch ex As Exception
            pResult = ex.Message
            Return False
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try
        Return True
    End Function

    <WebMethod(Description:="Create all Acuerdo por Cliente")> _
    Public Function CreateAllAcuerdoXCliente(ByVal pClientId As String,
                                     ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()
        Try
            Dim cmd As New SqlCommand

            cmd.CommandText = String.Format("{0}OP_WMS_SP_CREATE_ALL_ACUERDOS_X_CLIENTE", DefaultSchema)

            cmd.Parameters.Add("@CLIENT_ID", SqlDbType.VarChar)
            cmd.Parameters("@CLIENT_ID").Value = pClientId

            cmd.Parameters.Add("@pResult", SqlDbType.VarChar, 250)
            cmd.Parameters("@pResult").Direction = ParameterDirection.Output
            cmd.Parameters("@pResult").Value = ""


            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            cmd.ExecuteNonQuery()
            sqldbConexion.Close()
            pResult = cmd.Parameters("@pRESULT").Value.ToString
        Catch ex As Exception
            pResult = ex.Message
            Return False
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try
        Return True
    End Function

    <WebMethod(Description:="Delete un Acuerdo por Cliente")> _
    Public Function DeleteAcuerdoXCliente(ByVal pAcuerdoComercial As Integer, ByVal pClientId As String,
                                     ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()
        Try
            Dim cmd As New SqlCommand

            cmd.CommandText = String.Format("{0}OP_WMS_SP_DELETE_ACUERDOS_X_CLIENTE", DefaultSchema)

            cmd.Parameters.Add("@ACUERDO_COMERCIAL", SqlDbType.Int)
            cmd.Parameters("@ACUERDO_COMERCIAL").Value = pAcuerdoComercial

            cmd.Parameters.Add("@CLIENT_ID", SqlDbType.VarChar)
            cmd.Parameters("@CLIENT_ID").Value = pClientId

            cmd.Parameters.Add("@pResult", SqlDbType.VarChar, 250)
            cmd.Parameters("@pResult").Direction = ParameterDirection.Output
            cmd.Parameters("@pResult").Value = ""


            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            cmd.ExecuteNonQuery()
            sqldbConexion.Close()
            pResult = cmd.Parameters("@pRESULT").Value.ToString
        Catch ex As Exception
            pResult = ex.Message
            Return False
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try
        Return True
    End Function

    <WebMethod(Description:="Delete ALL Acuerdo por Cliente")> _
    Public Function DeleteAllAcuerdoXCliente(ByVal pClientId As String,
                                     ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()
        Try
            Dim cmd As New SqlCommand

            cmd.CommandText = String.Format("{0}OP_WMS_SP_DELETE_ALL_ACUERDOS_X_CLIENTE", DefaultSchema)

            cmd.Parameters.Add("@CLIENT_ID", SqlDbType.VarChar)
            cmd.Parameters("@CLIENT_ID").Value = pClientId

            cmd.Parameters.Add("@pResult", SqlDbType.VarChar, 250)
            cmd.Parameters("@pResult").Direction = ParameterDirection.Output
            cmd.Parameters("@pResult").Value = ""


            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            cmd.ExecuteNonQuery()
            sqldbConexion.Close()
            pResult = cmd.Parameters("@pRESULT").Value.ToString
        Catch ex As Exception
            pResult = ex.Message
            Return False
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try
        Return True
    End Function

    <WebMethod(Description:="Get AssignedAcuerdo")> _
    Public Function GetAssignedAcuerdo(ByVal pClienteId As String, ByVal pNameTable As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataTable

        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()
        Try
            Dim cmd As New SqlCommand
            Dim reader As SqlDataReader
            Dim dt As DataTable = New DataTable(pNameTable)
            cmd.CommandText = String.Format("{0}OP_WMS_SP_GET_ASSIGNED_ACUERDOS_X_CLIENTE", DefaultSchema)
            cmd.Parameters.Add("@CLIENT_ID", SqlDbType.VarChar, 50)
            cmd.Parameters("@CLIENT_ID").Value = pClienteId

            cmd.Parameters.Add("@pResult", SqlDbType.VarChar, 250)
            cmd.Parameters("@pResult").Direction = ParameterDirection.Output
            cmd.Parameters("@pResult").Value = ""

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            reader = cmd.ExecuteReader()

            dt.Load(reader)
            sqldbConexion.Close()
            pResult = cmd.Parameters("@pResult").Value
            Return dt
        Catch ex As Exception
            pResult = ex.Message
            Return Nothing
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try
    End Function

    <WebMethod(Description:="Get AssignedAcuerdo")> _
    Public Function GetAviaableAcuerdo(ByVal pClienteId As String, ByVal pNameTable As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataTable

        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()
        Try
            Dim cmd As New SqlCommand
            Dim reader As SqlDataReader
            Dim dt As DataTable = New DataTable(pNameTable)
            cmd.CommandText = String.Format("{0}OP_WMS_SP_GET_AVAILABLE_ACUERDOS_X_CLIENTE", DefaultSchema)
            cmd.Parameters.Add("@CLIENT_ID", SqlDbType.VarChar, 50)
            cmd.Parameters("@CLIENT_ID").Value = pClienteId

            cmd.Parameters.Add("@pResult", SqlDbType.VarChar, 250)
            cmd.Parameters("@pResult").Direction = ParameterDirection.Output
            cmd.Parameters("@pResult").Value = ""

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            reader = cmd.ExecuteReader()

            dt.Load(reader)
            sqldbConexion.Close()
            pResult = cmd.Parameters("@pResult").Value
            Return dt
        Catch ex As Exception
            pResult = ex.Message
            Return Nothing
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try
    End Function

    <WebMethod(Description:="Get Acuerdo por Cliente")> _
    Public Function GetAcuerdoCliente(ByVal pNameTable As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataTable

        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()
        Try
            Dim cmd As New SqlCommand
            Dim reader As SqlDataReader
            Dim dt As DataTable = New DataTable(pNameTable)
            cmd.CommandText = String.Format("{0}OP_WMS_SP_GET_ACUERDOS_X_CLIENTE", DefaultSchema)
            cmd.Parameters.Add("@pResult", SqlDbType.VarChar, 250)
            cmd.Parameters("@pResult").Direction = ParameterDirection.Output
            cmd.Parameters("@pResult").Value = ""

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            reader = cmd.ExecuteReader()

            dt.Load(reader)
            sqldbConexion.Close()
            pResult = cmd.Parameters("@pResult").Value
            Return dt
        Catch ex As Exception
            pResult = ex.Message
            Return Nothing
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try
    End Function

    <WebMethod(Description:="Get Report Acuerdo por Cliente")> _
    Public Function GetReporteAcuerdoCliente(ByVal pClienteId As String, ByVal pAcuerdoComercialId As Integer,
                                             ByVal pNameTable As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataTable

        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()
        Try
            Dim cmd As New SqlCommand
            Dim reader As SqlDataReader
            Dim dt As DataTable = New DataTable(pNameTable)
            cmd.CommandText = String.Format("{0}OP_WMS_SP_GET_ACUERDO_COMERCIAL", DefaultSchema)

            cmd.Parameters.Add("@pClientId", SqlDbType.VarChar)
            cmd.Parameters("@pClientId").Value = pClienteId

            cmd.Parameters.Add("@AcuerdoComercialId", SqlDbType.VarChar)
            cmd.Parameters("@AcuerdoComercialId").Value = pAcuerdoComercialId


            cmd.Parameters.Add("@pResult", SqlDbType.VarChar, 250)
            cmd.Parameters("@pResult").Direction = ParameterDirection.Output
            cmd.Parameters("@pResult").Value = ""

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            reader = cmd.ExecuteReader()

            dt.Load(reader)
            sqldbConexion.Close()
            pResult = cmd.Parameters("@pResult").Value
            Return dt
        Catch ex As Exception
            pResult = ex.Message
            Return Nothing
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try
    End Function

    <WebMethod(Description:="Get Clienst Sap")> _
    Public Function GetClientSap(ByRef pResult As String, ByVal pEnvironmentName As String) As DataTable

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        Dim strSql As New StringBuilder()
        strSql.Append(String.Format(" SELECT * FROM {0}OP_WMS_VIEW_CLIENTS", DefaultSchema))

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(strSql.ToString(), sqldb_conexion)
        Dim miscDS As DataTable = New DataTable("GetClientSap")
        Try
            miscDA.Fill(miscDS)
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Rows.Count <= 0 Then
            pResult = "ERROR,No se econtraron registros. "
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function

#End Region

End Class