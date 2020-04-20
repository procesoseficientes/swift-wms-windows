Imports System.Web.Services
Imports System.Configuration.ConfigurationManager
Imports System.ComponentModel
Imports System.Data.SqlClient

' Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente.
' <System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class WMS_Insurance_Docs
    Inherits WebService

    <WebMethod(Description:="Create a Insurance Docs")> _
    Public Function CreateInsuranceDocs(ByVal pCompanyId As String, ByVal pCLientCode As String, ByVal pPoliza As String,
                                        ByRef pFechaVenInicio As Date, ByRef pFechaVenFihnal As Date, ByRef pMonto As Decimal,
                                        ByRef pCobertura As String, ByRef pCreateBy As String, ByVal pInsuranceOwhen As String,
                                        ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean
        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        Dim strSql As New StringBuilder
        Try

            strSql.Append(String.Format(" INSERT INTO {0}OP_WMS_INSURANCE_DOCS(", DefaultSchema))
            strSql.Append(" COMPANY_ID")
            strSql.Append(" , CLIENT_CODE")
            strSql.Append(" , POLIZA_INSURANCE")
            strSql.Append(" , VALIN_FROM")
            strSql.Append(" , VALIN_TO")
            strSql.Append(" , AMOUNT")
            strSql.Append(" , COVERAGE")
            strSql.Append(" , CREATED_BY")
            strSql.Append(" , CREATED_DATE")
            strSql.Append(" , INSURANCE_OWHEN")
            strSql.Append(" ) VALUES(")
            strSql.Append(String.Format(" '{0}'", pCompanyId))
            strSql.Append(String.Format(" , '{0}'", pCLientCode))
            strSql.Append(String.Format(" , '{0}'", pPoliza))
            strSql.Append(String.Format(" , convert(date,'{0}')", pFechaVenInicio.ToString("MM/dd/yyyy")))
            strSql.Append(String.Format(" , convert(date,'{0}')", pFechaVenFihnal.ToString("MM/dd/yyyy")))
            strSql.Append(String.Format(" , '{0}'", pMonto))
            strSql.Append(String.Format(" , '{0}'", pCobertura))
            strSql.Append(String.Format(" , '{0}'", pCreateBy))
            strSql.Append(String.Format(" , GetDate()"))
            strSql.Append(String.Format(" , '{0}'", pInsuranceOwhen))
            strSql.Append(")")

            If ExecuteSqlTransaction(sqldbConexion.ConnectionString, strSql.ToString, pResult) Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            pResult = ex.Message
            Return False
        End Try
    End Function

    <WebMethod(Description:="UPDATE a Insurance Docs")> _
    Public Function UpdateInsuranceDocs(ByVal pCompanyId As Integer, ByRef pMonto As Decimal, ByRef pCobertura As String, ByRef pLastUpdateBy As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean
        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        Dim strSql As New StringBuilder
        Try

            strSql.Append(String.Format(" UPDATE {0}OP_WMS_INSURANCE_DOCS SET", DefaultSchema))
            strSql.Append(String.Format(" AMOUNT = '{0}'", pMonto))
            strSql.Append(String.Format(" , COVERAGE =  '{0}'", pCobertura))
            strSql.Append(String.Format(" , LAST_UPDATED_BY = '{0}'", pLastUpdateBy))
            strSql.Append(" , LAST_UPDATED = GetDate()")
            strSql.Append(String.Format(" WHERE DOC_ID = {0}", pCompanyId))

            If ExecuteSqlTransaction(sqldbConexion.ConnectionString, strSql.ToString, pResult) Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            pResult = ex.Message
            Return False
        End Try
    End Function

    <WebMethod(Description:="DELETE a Insurance Docs")> _
    Public Function DeleteInsuranceDocs(ByVal pCompanyId As Integer, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean
        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        Dim strSql As New StringBuilder
        Try

            strSql.Append(String.Format(" DELETE {0}OP_WMS_INSURANCE_DOCS", DefaultSchema))
            strSql.Append(String.Format(" WHERE DOC_ID = {0}", pCompanyId))

            If ExecuteSqlTransaction(sqldbConexion.ConnectionString, strSql.ToString, pResult) Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            pResult = ex.Message
            Return False
        End Try
    End Function


    <WebMethod(Description:="Get a Insurance Docs")> _
    Public Function GetInsuranceDocs(ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet

        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        Dim strSql As New StringBuilder
        strSql.Append(String.Format(" SELECT * FROM {0}OP_WMS_VIEW_INSURANCE_DOC", DefaultSchema))
        'strSql.Append(" SELECT DOC_ID, POLIZA_INSURANCE, COMPANY_NAME, AMOUNT, VALIN_TO, CLIENT_NAME, COVERAGE , INSURANCE_OWHEN")

        'strSql.Append(String.Format(" ,( SELECT ISNULL(SUM(TOTAL_VALOR),0) FROM {0}OP_WMS_VIEW_VALORIZACION V  JOIN {0}OP_WMS_POLIZA_HEADER P ON V.CODIGO_POLIZA = P.CODIGO_POLIZA", DefaultSchema))
        'strSql.Append(" where POLIZA_ASEGURADA  = isd.DOC_ID ) AS AMOUNTINV ")
        'strSql.Append(String.Format(" , AMOUNT - ( SELECT ISNULL(SUM(TOTAL_VALOR),0) FROM {0}OP_WMS_VIEW_VALORIZACION V  JOIN {0}OP_WMS_POLIZA_HEADER P ON V.CODIGO_POLIZA = P.CODIGO_POLIZA", DefaultSchema))
        'strSql.Append(" where POLIZA_ASEGURADA  = isd.DOC_ID ) AS AMOUNTDIF ")

        'strSql.Append(String.Format(" FROM {0}OP_WMS_INSURANCE_DOCS isd", DefaultSchema))
        'strSql.Append(String.Format(" INNER JOIN {0}OP_WMS_INSURANCE_COMPANIES isc ON isd.COMPANY_ID = isc.COMPANY_ID", DefaultSchema))
        'strSql.Append(String.Format(" INNER JOIN {0}OP_WMS_VIEW_CLIENTS vc ON  isd.CLIENT_CODE = vc.CLIENT_CODE COLLATE DATABASE_DEFAULT", DefaultSchema))
        'strSql.Append(" UNION")
        'strSql.Append(" SELECT 0 AS DOC_ID , C.TEXT_VALUE AS POLIZA_INSURANCE, SPARE1 AS COMPANY_NAME, CONVERT(MONEY,MONEY_VALUE) AS AMOUNT, CONVERT(DATE,RANGE_DATE_END) AS VALIN_TO")
        'strSql.Append(" , C.PARAM_CAPTION AS CLIENT_NAME, SPARE2 AS COVERAGE, 'PROPIA' AS INSURANCE_OWHEN")
        'strSql.Append(String.Format(" ,( SELECT ISNULL(SUM(TOTAL_VALOR),0) FROM {0}OP_WMS_VIEW_VALORIZACION V  JOIN {0}OP_WMS_POLIZA_HEADER P ON V.CODIGO_POLIZA = P.CODIGO_POLIZA", DefaultSchema))
        'strSql.Append(" where POLIZA_ASEGURADA  =  C.TEXT_VALUE ) AS AMOUNTINV ")

        'strSql.Append(String.Format(" , CONVERT(MONEY,MONEY_VALUE) - ( SELECT ISNULL(SUM(TOTAL_VALOR),0) FROM {0}OP_WMS_VIEW_VALORIZACION V  JOIN {0}OP_WMS_POLIZA_HEADER P ON V.CODIGO_POLIZA = P.CODIGO_POLIZA", DefaultSchema))
        'strSql.Append(" where POLIZA_ASEGURADA  =  C.TEXT_VALUE ) AS AMOUNTDIF ")
        'strSql.Append(String.Format(" FROM {0}OP_WMS_CONFIGURATIONS C", DefaultSchema))
        'strSql.Append(" WHERE PARAM_TYPE = 'POLIZAS' ")
        'strSql.Append(" AND PARAM_GROUP = 'POLIZAS_SEGUROS' ")

        Dim miscDa As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqldbConexion)
        Dim miscDs As DataSet = New DataSet()
        Try
            miscDa.Fill(miscDs, "GetInsuranceDocs")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDs.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR, No existen encontraron registros."
            Return Nothing
        Else
            pResult = "OK"
            Return miscDs
        End If

    End Function

    <WebMethod(Description:="Get a Insurance Docs")> _
    Public Function FillInsuranceDocs(ByVal pDocId As Integer, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet

        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        Dim strSql As New StringBuilder
        strSql.Append(" SELECT DOC_ID, COMPANY_ID, AMOUNT, CLIENT_CODE, COVERAGE, POLIZA_INSURANCE, VALIN_FROM, VALIN_TO, INSURANCE_OWHEN ")
        strSql.Append(String.Format(" FROM {0}OP_WMS_INSURANCE_DOCS", DefaultSchema))
        strSql.Append(String.Format(" WHERE DOC_ID = {0}", pDocId))

        Dim miscDa As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqldbConexion)
        Dim miscDs As DataSet = New DataSet()
        Try
            miscDa.Fill(miscDs, "GetInsuranceDocs")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDs.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR, No se encontraron registros."
            Return Nothing
        Else
            pResult = "OK"
            Return miscDs
        End If

    End Function

    <WebMethod(Description:="Get Report Insurance Docs")> _
    Public Function GetRepInsuranceDoscs(ByVal pNameTable As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataTable

        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()


        Try
            Dim cmd As New SqlCommand
            Dim reader As SqlDataReader
            Dim dt As DataTable = New DataTable(pNameTable)
            cmd.CommandText = String.Format("{0}OP_WMS_SP_REPORTE_POLIZAS_SEGURO", DefaultSchema)
            cmd.Parameters.Add("@pResult", SqlDbType.VarChar, 25)
            cmd.Parameters("@pResult").Direction = ParameterDirection.Output
            cmd.Parameters("@pResult").Value = ""

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            reader = cmd.ExecuteReader()

            dt.Load(reader)
            sqldbConexion.Close()
            pResult = cmd.Parameters("@pRESULT").Value.ToString
            Return dt
        Catch ex As Exception
            pResult = ex.Message
            Return Nothing
        Finally
            '09-Mar-11 J.R. cerrar conexiones para mejorar performance
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try
    End Function

    <WebMethod(Description:="Get a Insurance Docs Client")> _
    Public Function GetInsuranceDocsCliente(ByVal pClientCode As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet

        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        Dim strSql As New StringBuilder
        strSql.Append(" SELECT * ") 'DOC_ID, POLIZA_INSURANCE")
        strSql.Append(String.Format(" FROM {0}OP_WMS_INSURANCE_DOCS", DefaultSchema))
        strSql.Append(String.Format(" WHERE CLIENT_CODE = '{0}' COLLATE DATABASE_DEFAULT", pClientCode))
        strSql.Append(String.Format(" AND VALIN_TO >= CONVERT(DATE, GETDATE())"))
        strSql.Append(String.Format(" AND AMOUNT > 0"))

        Dim miscDa As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqldbConexion)
        Dim miscDs As DataSet = New DataSet()
        Try
            miscDa.Fill(miscDs, "GetInsuranceDocsCliente")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDs.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR, No se encontraron registros."
            Return Nothing
        Else
            pResult = "OK"
            Return miscDs
        End If

    End Function


    <WebMethod(Description:="Create Insurance Docs Log")> _
    Public Function CreateInsuranceDocsLog(ByVal pDocId As Integer, ByVal pUserId As String, ByVal pFechaInicio As Date,
                                           ByVal pFechaFinal As Date, ByVal pComentario As String, ByVal pAutorizado As String,
                                           ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()

        Try
            Dim cmd As New SqlCommand

            cmd.CommandText = String.Format("{0}OP_WMS_SP_CREATE_INSURANCE_DOCS_LOG", DefaultSchema)

            cmd.Parameters.Add("@INSURANCE_DOCS_ID", SqlDbType.Int)
            cmd.Parameters("@INSURANCE_DOCS_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@INSURANCE_DOCS_ID").Value = pDocId

            cmd.Parameters.Add("@UPDATE_BY", SqlDbType.VarChar)
            cmd.Parameters("@UPDATE_BY").Direction = ParameterDirection.Input
            cmd.Parameters("@UPDATE_BY").Value = pUserId

            cmd.Parameters.Add("@NEW_VALID_FROM", SqlDbType.Date)
            cmd.Parameters("@NEW_VALID_FROM").Direction = ParameterDirection.Input
            cmd.Parameters("@NEW_VALID_FROM").Value = pFechaInicio.Date

            cmd.Parameters.Add("@NEW_VALID_TO", SqlDbType.Date)
            cmd.Parameters("@NEW_VALID_TO").Direction = ParameterDirection.Input
            cmd.Parameters("@NEW_VALID_TO").Value = pFechaFinal.Date

            cmd.Parameters.Add("@COMMENT", SqlDbType.VarChar)
            cmd.Parameters("@COMMENT").Direction = ParameterDirection.Input
            cmd.Parameters("@COMMENT").Value = pComentario

            cmd.Parameters.Add("@AUTHORIZED_BY", SqlDbType.VarChar)
            cmd.Parameters("@AUTHORIZED_BY").Direction = ParameterDirection.Input
            cmd.Parameters("@AUTHORIZED_BY").Value = pAutorizado

            cmd.Parameters.Add("@pResult", SqlDbType.VarChar, 200)
            cmd.Parameters("@pResult").Direction = ParameterDirection.Output
            cmd.Parameters("@pResult").Value = ""

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            cmd.ExecuteReader()


            sqldbConexion.Close()
            pResult = cmd.Parameters("@pRESULT").Value.ToString
            Return pResult = "OK"
        Catch ex As Exception
            pResult = ex.Message
            Return Nothing
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try
    End Function

    <WebMethod(Description:="Get a Insurance Docs Log")> _
    Public Function GetInsuranceDocsLog(ByVal pInsuranceDocId As Integer, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet

        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        Dim strSql As New StringBuilder
        strSql.Append(" SELECT * ")
        strSql.Append(String.Format(" FROM {0}OP_WMS_INSURANCE_DOCS_LOG", DefaultSchema))
        strSql.Append(String.Format(" WHERE INSURANCE_DOCS_ID = {0} ", pInsuranceDocId))


        Dim miscDa As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqldbConexion)
        Dim miscDs As DataSet = New DataSet()
        Try
            miscDa.Fill(miscDs, "GetInsuranceDocsLog")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDs.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR, No se encontraron registros."
            Return Nothing
        Else
            pResult = "OK"
            Return miscDs
        End If

    End Function

    <WebMethod(Description:="Get Expiration Poliza Docs")> _
    Public Function GetExpirationPolizaDoc(ByVal pFechaInicio As Date, ByVal pFechaFinal As Date, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet

        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        Dim strSql As New StringBuilder
        strSql.Append(" SELECT * ")
        strSql.Append(String.Format(" FROM {0}OP_WMS_VIEW_VENCIMIENTO_POR_TIPO_POLIZA", DefaultSchema))
        strSql.Append(String.Format(" WHERE CONVERT(DATE, VALIN_TO) BETWEEN CONVERT(DATE, '{0}') AND CONVERT(DATE, '{1}') ", pFechaInicio.ToString("yyyy-MM-dd"), pFechaFinal.ToString("yyyy-MM-dd")))


        Dim miscDa As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqldbConexion)
        Dim miscDs As DataSet = New DataSet()
        Try
            miscDa.Fill(miscDs, "GetInsuranceDocsLog")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDs.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR, No se encontraron registros."
            Return Nothing
        Else
            pResult = "OK"
            Return miscDs
        End If

    End Function

    <WebMethod(Description:="Get Expiration Insurance Docs")> _
    Public Function GetExpirationInsuranceDoc(ByVal pFechaInicio As Date, ByVal pFechaFinal As Date, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet

        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        Dim strSql As New StringBuilder
        strSql.Append(" SELECT * ")
        strSql.Append(String.Format(" FROM {0}OP_WMS_VIEW_VENCIMIENTO_POR_POLIZA_SEGURO", DefaultSchema))
        strSql.Append(String.Format(" WHERE CONVERT(DATE, VALIN_TO) BETWEEN CONVERT(DATE, '{0}') AND CONVERT(DATE, '{1}') ", pFechaInicio.ToString("yyyy-MM-dd"), pFechaFinal.ToString("yyyy-MM-dd")))


        Dim miscDa As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqldbConexion)
        Dim miscDs As DataSet = New DataSet()
        Try
            miscDa.Fill(miscDs, "GetInsuranceDocsLog")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDs.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR, No se encontraron registros."
            Return Nothing
        Else
            pResult = "OK"
            Return miscDs
        End If

    End Function

End Class