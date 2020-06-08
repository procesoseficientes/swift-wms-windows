Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration.ConfigurationManager
Imports System.Data.Common
Imports System.Linq.Expressions

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")>
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)>
<ToolboxItem(False)>
Public Class _3PL_Polizas
    Inherits System.Web.Services.WebService

    <WebMethod(Description:="Devuelve encabezado de documento")>
    Public Function get_Poliza_Header(ByVal pWhere As String, ByVal pEnvironmentName As String, ByRef pResult As String) As DataSet
        Dim XSQL As String = "SELECT TOP(1) [PH].DOC_ID, [PH].NUMERO_ORDEN, [PH].ADUANA_ENTRADA_SALIDA, [PH].NUMERO_DUA, [PH].FECHA_ACEPTACION_DMY, [PH].ADUANA_DESPACHO_DESTINO, [PH].REGIMEN, [PH].CLASE, [PH].PAIS_PROCEDENCIA"
        XSQL = XSQL & " , [PH].NATURALEZA_TRANS, [PH].DEPOSITO_FISCAL_ZF, [PH].MODO, [PH].FECHA_LLEGADA, [PH].TIPO_CAMBIO, [PH].TOTAL_VALOR_ADUANA, [PH].TOTAL_NUMERO_LINEAS, [PH].TOTAL_BULTOS, [PH].TOTAL_PESO_BRUTO_KG"
        XSQL = XSQL & " , [PH].TOTAL_FOB_USD, [PH].TOTAL_FLETE_USD, [PH].TOTAL_SEGURO_USD, [PH].TOTAL_OTROS_USD, [PH].NUMERO_SAT, [PH].TIPO_IMPORTADOR, [PH].ID_TRIB_IMPORTADOR, [PH].PAIS_IMPORTADOR, [PH].RAZON_SOCIAL_IMPORTADOR"
        XSQL = XSQL & " , [PH].DOMICILIO_IMPORTADOR, [PH].TIPO_REPRESENTANTE, [PH].ID_TRIB_REPRESENTANTE, [PH].PAIS_REPRESENTANTE, [PH].TIPO_DECLARANTE_REPRESENTANTE, [PH].RAZON_SOCIAL_REPRESENTANTE"
        XSQL = XSQL & " , [PH].DOMICILIO_REPRESENTANTE, [PH].TIPO_CONTENEDOR, [PH].NUMERO_CONTENEDOR, [PH].ENTIDAD_CONTENEDOR, [PH].NUMERO_MARCHAMO_CONTENEDOR, [PH].TOTAL_LIQUIDAR, [PH].TOTAL_OTROS"
        XSQL = XSQL & " , [PH].TOTAL_GENERAL, [PH].CODIGO_POLIZA, [PH].LAST_UPDATED_BY, [PH].LAST_UPDATED, [PH].STATUS, [PH].CLIENT_CODE, [PH].TIPO, [PH].PENDIENTE_RECTIFICACION, [PH].CODIGO_POLIZA_RECTIFICACION, [PH].COMENTARIO_RECTIFICACION"
        XSQL = XSQL & " , [PH].WAREHOUSE_REGIMEN, [PH].FECHA_DOCUMENTO, [PH].ACUERDO_COMERCIAL, [PH].POLIZA_ASEGURADA, [PH].POLIZA_ASSIGNEDTO, [PH].PENDIENTE_RECTIFICACION, [PH].CODIGO_POLIZA_RECTIFICACION, [PH].COMENTARIO_RECTIFICACION, [PH].CLASE_POLIZA_RECTIFICACION, [PH].DOC_ID_RECTIFICACION , [PH].COMENTARIO_RECTIFICADO, [T].TICKET_NUMBER"
        XSQL = XSQL & " FROM " & DefaultSchema & "OP_WMS_POLIZA_HEADER [PH]"
        XSQL = XSQL & " LEFT JOIN " & DefaultSchema & "OP_WMS_TICKETS [T] ON ([PH].[DOC_ID] = [T].[POLIZA_DOC_ID])" & pWhere
        Dim sqldb_conexion As SqlConnection

        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()
            miscDA.Fill(miscDS, "OP_WMS_POLIZA_HEAD")
            pResult = "OK"
            Return miscDS
        Catch ex As Exception
            pResult = ex.Message
            pResult = "ERROR," + ex.Message
            Return Nothing

        End Try

    End Function

    <WebMethod(Description:="Devuelve detalle de documento con cualquier where")>
    Public Function get_Poliza_Detail(ByVal pWhere As String, ByVal codigoPoliza As String, ByVal pEnvironmentName As String, ByRef pResult As String) As DataSet
        Dim XSQL As String = "SELECT DOC_ID,LINE_NUMBER,SKU_DESCRIPTION,SAC_CODE,BULTOS,CLASE,NET_WEIGTH"
        XSQL = XSQL & " ,WEIGTH_UNIT,QTY,CUSTOMS_AMOUNT,QTY_UNIT,VOLUME,VOLUME_UNIT,DAI,IVA"
        XSQL = XSQL & " ,MISC_TAXES,FOB_USD,FREIGTH_USD,INSURANCE_USD,MISC_EXPENSES,ORIGIN_COUNTRY"
        XSQL = XSQL & " ,REGION_CP,AGREEMENT_1,AGREEMENT_2,RELATED_POLIZA,LAST_UPDATED_BY,LAST_UPDATED"
        XSQL = XSQL & " ,ORIGIN_DOC_ID,CODIGO_POLIZA_ORIGEN,PD.CLIENT_CODE, ACUERDO_COMERCIAL,PCTDAI, ORIGIN_LINE_NUMBER, VC.CLIENT_NAME AS CONSIGNATARIO_NAME"
        XSQL = XSQL & " , (SELECT TOP 1 NUMERO_ORDEN FROM  " + DefaultSchema + "OP_WMS_POLIZA_HEADER PH WHERE PH.DOC_ID = PD.DOC_ID) AS NUMEROODERORIGEN, PD.TAX, MATERIAL_ID"
        XSQL = XSQL & "  FROM " & DefaultSchema & "OP_WMS_POLIZA_DETAIL PD "
        XSQL = XSQL & "  LEFT JOIN " & DefaultSchema & "OP_WMS_VIEW_CLIENTS AS VC ON (VC.CLIENT_CODE = PD.CLIENT_CODE)"
        If (String.IsNullOrEmpty(pWhere)) Then
            XSQL = XSQL & " WHERE DOC_ID IN (SELECT TOP 1 DOC_ID FROM " + DefaultSchema + "OP_WMS_POLIZA_HEADER WHERE CODIGO_POLIZA = '" & codigoPoliza & "') "
        Else
            XSQL = XSQL & pWhere
        End If


        Dim sqldb_conexion As SqlConnection

        Try
            LogSQLErrors("get_Poliza_Detail", XSQL, "")
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()
            miscDA.Fill(miscDS, "OP_WMS_POLIZA_DETAIL")
            pResult = "OK"
            Return miscDS
        Catch ex As Exception
            pResult = ex.Message
            pResult = "ERROR," + ex.Message
            Return Nothing

        End Try

    End Function

    <WebMethod(Description:="Devuelve documento en sincronizacion con cualquier where")>
    Public Function get_Sync_Poliza(ByVal pPolizaWhere As String, ByVal pEnvironmentName As String, ByRef pResult As String) As DataSet
        Dim XSQL As String = "SELECT POLIZA,DOC_ID,ass.CLIENT_CODE,vc.CLIENT_NAME, STATUS,SENT,RECEIVED,SAT_RESULT, CREATED from " & DefaultSchema & "OP_WMS_AUTORIZATION_SYNC_SAT ass INNER JOIN  " + DefaultSchema + "OP_WMS_VIEW_CLIENTS vc ON ass.CLIENT_CODE = vc.CLIENT_CODE COLLATE DATABASE_DEFAULT"
        XSQL = XSQL & pPolizaWhere
        Dim sqldb_conexion As SqlConnection

        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()
            miscDA.Fill(miscDS, "OP_WMS_AUTORIZATION_SYNC_SAT")
            pResult = "OK"
            Return miscDS
        Catch ex As Exception
            pResult = ex.Message
            pResult = "ERROR," + ex.Message
            Return Nothing

        End Try

    End Function

    <WebMethod(Description:="Graba poliza en sincronizacion con sat")>
    Public Function set_Sync_Poliza(ByVal pPOLIZA As String, ByVal pDOC_ID As Int32, ByVal pCLIENT_CODE As String, ByVal pCLIENT_NAME As String, ByVal pSTATUS As Int16, ByVal pSENT As Date, ByVal pRECEIVED As Date, ByVal pSAT_RESULT As String, ByVal pLAST_UPDATED_BY As String, ByVal pEnvironmentName As String, ByRef pResult As String) As Boolean
        Dim sqldb_conexion As SqlConnection
        Dim sqlCmd As SqlCommand
        Dim strReturn As String
        Dim dtPivot As Date
        sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Try
            sqlCmd = New SqlCommand(DefaultSchema & "sp_OP_WMS_AUTORIZACION_SYNC_SAT", sqldb_conexion)
            sqlCmd.CommandType = CommandType.StoredProcedure

            'creamos todos los parametros del sp
            sqlCmd.Parameters.Add(New SqlParameter("@POLIZA", SqlDbType.VarChar, 50)).Direction = ParameterDirection.Input
            sqlCmd.Parameters.Add(New SqlParameter("@DOC_ID", SqlDbType.Int, 18))
            sqlCmd.Parameters.Add(New SqlParameter("@CLIENT_CODE", SqlDbType.VarChar, 25))
            sqlCmd.Parameters.Add(New SqlParameter("@CLIENT_NAME", SqlDbType.VarChar, 200))
            sqlCmd.Parameters.Add(New SqlParameter("@STATUS", SqlDbType.SmallInt, 2))
            sqlCmd.Parameters.Add(New SqlParameter("@SENT", SqlDbType.DateTime))
            sqlCmd.Parameters.Add(New SqlParameter("@RECEIVED", SqlDbType.DateTime))
            sqlCmd.Parameters.Add(New SqlParameter("@SAT_RESULT", SqlDbType.VarChar, 200))
            sqlCmd.Parameters.Add(New SqlParameter("@LAST_UPDATED_BY", SqlDbType.VarChar, 25))
            sqlCmd.Parameters.Add(New SqlParameter("@retCode", 1)).Direction = ParameterDirection.ReturnValue

            'asignamos valores
            sqlCmd.Parameters("@POLIZA").Value = pPOLIZA
            sqlCmd.Parameters("@DOC_ID").Value = pDOC_ID
            sqlCmd.Parameters("@CLIENT_CODE").Value = pCLIENT_CODE
            sqlCmd.Parameters("@CLIENT_NAME").Value = pCLIENT_NAME
            sqlCmd.Parameters("@STATUS").Value = pSTATUS
            sqlCmd.Parameters("@LAST_UPDATED_BY").Value = pLAST_UPDATED_BY
            If DateTime.TryParse(pSENT.ToString, dtPivot) Then
                sqlCmd.Parameters("@SENT").Value = dtPivot
            Else
                sqlCmd.Parameters("@SENT").Value = Nothing
            End If
            If DateTime.TryParse(pRECEIVED.ToString, dtPivot) Then
                sqlCmd.Parameters("@RECEIVED").Value = dtPivot
            Else
                sqlCmd.Parameters("@RECEIVED").Value = Nothing
            End If

            sqlCmd.Parameters("@SAT_RESULT").Value = pSAT_RESULT

            'ejecutamos el procedure y validamos la respuesta
            If sqldb_conexion.State = ConnectionState.Closed Then sqldb_conexion.Open()
            sqlCmd.ExecuteNonQuery()

            strReturn = sqlCmd.Parameters("@retCode").Value

            If strReturn = "0" Then
                pResult = "ERROR," + strReturn
                Return False
            Else
                If strReturn = "1" Then
                    pResult = "inserted"
                End If
                If strReturn = "2" Then
                    pResult = "updated"
                End If
                Return True
            End If

        Catch ex As Exception
            pResult = ex.Message
            pResult = "ERROR," + ex.Message
            Return False

        Finally
            If sqldb_conexion.State = ConnectionState.Open Then sqldb_conexion.Close()

        End Try

    End Function

    <WebMethod(Description:="Graba registro de garita")>
    Public Function set_Shelter(ByVal pDOC_ID As Double, ByVal pISPASS As Integer, ByVal pUPDATED_BY As String, ByVal pEnvironmentName As String, ByRef pResult As String, ByRef pCHECKPOINT_ID As Integer) As Boolean
        Dim sqldb_conexion As SqlConnection
        Dim sqlCmd As SqlCommand
        Dim strReturn As String
        sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Try
            sqlCmd = New SqlCommand(DefaultSchema & "sp_OP_WMS3PL_SECURITY_CHECKPOINT", sqldb_conexion)
            sqlCmd.CommandType = CommandType.StoredProcedure

            'creamos todos los parametros del sp
            sqlCmd.Parameters.Add(New SqlParameter("@CHECKPOINT_ID", SqlDbType.Int)).Direction = ParameterDirection.InputOutput
            sqlCmd.Parameters.Add(New SqlParameter("@DOC_ID", SqlDbType.Int))
            sqlCmd.Parameters.Add(New SqlParameter("@ISPASS", SqlDbType.Int))
            sqlCmd.Parameters.Add(New SqlParameter("@UPDATED_BY", SqlDbType.VarChar, 25))
            sqlCmd.Parameters.Add(New SqlParameter("@retCode", 1)).Direction = ParameterDirection.ReturnValue

            'asignamos valores
            sqlCmd.Parameters("@UPDATED_BY").Value = pUPDATED_BY
            sqlCmd.Parameters("@DOC_ID").Value = pDOC_ID
            sqlCmd.Parameters("@ISPASS").Value = pISPASS
            If pCHECKPOINT_ID > 0 Then
                sqlCmd.Parameters("@CHECKPOINT_ID").Value = pCHECKPOINT_ID
            End If

            'ejecutamos el procedure y validamos la respuesta
            If sqldb_conexion.State = ConnectionState.Closed Then sqldb_conexion.Open()
            sqlCmd.ExecuteNonQuery()

            strReturn = sqlCmd.Parameters("@retCode").Value

            If strReturn = "0" Then
                pResult = "ERROR," + strReturn
                Return False
            Else
                If strReturn = "1" Then
                    pResult = "inserted"
                    pCHECKPOINT_ID = sqlCmd.Parameters("@CHECKPOINT_ID").Value
                End If
                If strReturn = "2" Then
                    pResult = "updated"
                End If
                Return True
            End If

        Catch ex As Exception
            pResult = ex.Message
            pResult = "ERROR," + ex.Message
            Return False

        Finally
            If sqldb_conexion.State = ConnectionState.Open Then sqldb_conexion.Close()

        End Try

    End Function

    <WebMethod(Description:="Graba Encabezado de Poliza")>
    Public Function set_Poliza_Header(ByVal pNUMERO_ORDEN As String, ByVal pADUANA_ENTRADA_SALIDA As String, ByVal pNUMERO_DUA As String, ByVal pFECHA_ACEPTACION_DMY As String, ByVal pADUANA_DESPACHO_DESTINO As String,
    ByVal pREGIMEN As String, ByVal pCLASE As String, ByVal pPAIS_PROCEDENCIA As String, ByVal pNATURALEZA_TRANS As String, ByVal pDEPOSITO_FISCAL_ZF As String,
    ByVal pMODO As Integer, ByVal pFECHA_LLEGADA As Date, ByVal pTIPO_CAMBIO As Double, ByVal pTOTAL_VALOR_ADUANA As Double, ByVal pTOTAL_NUMERO_LINEAS As Double,
    ByVal pTOTAL_BULTOS As Integer, ByVal pTOTAL_PESO_BRUTO_KG As Double, ByVal pTOTAL_FOB_USD As Double, ByVal pTOTAL_FLETE_USD As Double, ByVal pTOTAL_SEGURO_USD As Double,
    ByVal pTOTAL_OTROS_USD As Double, ByVal pNUMERO_SAT As String, ByVal pTIPO_IMPORTADOR As String, ByVal pID_TRIB_IMPORTADOR As String, ByVal pPAIS_IMPORTADOR As String,
    ByVal pRAZON_SOCIAL_IMPORTADOR As String, ByVal pDOMICILIO_IMPORTADOR As String, ByVal pTIPO_REPRESENTANTE As String, ByVal pID_TRIB_REPRESENTANTE As String,
    ByVal pPAIS_REPRESENTANTE As String, ByVal pTIPO_DECLARANTE_REPRESENTANTE As String, ByVal pRAZON_SOCIAL_REPRESENTANTE As String,
    ByVal pDOMICILIO_REPRESENTANTE As String, ByVal pTIPO_CONTENEDOR As Integer, ByVal pNUMERO_CONTENEDOR As String, ByVal pENTIDAD_CONTENEDOR As String,
    ByVal pNUMERO_MARCHAMO_CONTENEDOR As String, ByVal pTOTAL_LIQUIDAR As Double, ByVal pTOTAL_OTROS As Double, ByVal pTOTAL_GENERAL As Double,
    ByVal pCODIGO_POLIZA As String, ByVal pLAST_UPDATED_BY As String, ByVal pLAST_UPDATED As Date, ByVal pSTATUS As String, ByVal pCLIENT_CODE As String,
    ByVal pWAREHOUSE_REGIMEN As String, ByVal pFECHA_DOCUMENTO As Date, ByVal pACUERDO_COMERCIAL As String, ByVal pTIPO As String, ByVal pEnvironmentName As String, ByRef pResult As String, ByRef pDOC_ID As Integer,
    ByVal pPolizaAsegurada As String, ByVal pPolizaAssognedto As String, ByVal pTranslation As String, ByVal pTicketNumber As Int64) As Boolean

        Dim sqlCmd As SqlCommand
        Dim strReturn As String
        Dim sqldbConexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Try
            sqlCmd = New SqlCommand(DefaultSchema & "sp_OP_WMS_POLIZA_HEADER", sqldbConexion)
            sqlCmd.CommandType = CommandType.StoredProcedure

            'creamos todos los parametros del sp
            sqlCmd.Parameters.Add(New SqlParameter("@DOC_ID", SqlDbType.Int, 18)).Direction = ParameterDirection.InputOutput
            sqlCmd.Parameters.Add(New SqlParameter("@NUMERO_ORDEN", SqlDbType.VarChar, 25))
            sqlCmd.Parameters.Add(New SqlParameter("@ADUANA_ENTRADA_SALIDA", SqlDbType.VarChar, 25))
            sqlCmd.Parameters.Add(New SqlParameter("@NUMERO_DUA", SqlDbType.VarChar, 50))
            sqlCmd.Parameters.Add(New SqlParameter("@FECHA_ACEPTACION_DMY", SqlDbType.VarChar, 25))
            sqlCmd.Parameters.Add(New SqlParameter("@ADUANA_DESPACHO_DESTINO", SqlDbType.VarChar, 25))
            sqlCmd.Parameters.Add(New SqlParameter("@REGIMEN", SqlDbType.VarChar, 15))
            sqlCmd.Parameters.Add(New SqlParameter("@CLASE", SqlDbType.VarChar, 5))
            sqlCmd.Parameters.Add(New SqlParameter("@PAIS_PROCEDENCIA", SqlDbType.VarChar, 6))
            sqlCmd.Parameters.Add(New SqlParameter("@NATURALEZA_TRANS", SqlDbType.VarChar, 5))
            sqlCmd.Parameters.Add(New SqlParameter("@DEPOSITO_FISCAL_ZF", SqlDbType.VarChar, 15))
            sqlCmd.Parameters.Add(New SqlParameter("@MODO", SqlDbType.Int, 18))
            sqlCmd.Parameters.Add(New SqlParameter("@FECHA_LLEGADA", SqlDbType.DateTime))
            sqlCmd.Parameters.Add(New SqlParameter("@TIPO_CAMBIO", SqlDbType.Decimal))
            sqlCmd.Parameters.Add(New SqlParameter("@TOTAL_VALOR_ADUANA", SqlDbType.Decimal))
            sqlCmd.Parameters.Add(New SqlParameter("@TOTAL_NUMERO_LINEAS", SqlDbType.Int))
            sqlCmd.Parameters.Add(New SqlParameter("@TOTAL_BULTOS", SqlDbType.Int))
            sqlCmd.Parameters.Add(New SqlParameter("@TOTAL_PESO_BRUTO_KG", SqlDbType.Decimal))
            sqlCmd.Parameters.Add(New SqlParameter("@TOTAL_FOB_USD", SqlDbType.Decimal))
            sqlCmd.Parameters.Add(New SqlParameter("@TOTAL_FLETE_USD", SqlDbType.Decimal))
            sqlCmd.Parameters.Add(New SqlParameter("@TOTAL_SEGURO_USD", SqlDbType.Decimal))
            sqlCmd.Parameters.Add(New SqlParameter("@TOTAL_OTROS_USD", SqlDbType.Decimal))
            sqlCmd.Parameters.Add(New SqlParameter("@NUMERO_SAT", SqlDbType.VarChar, 25))
            sqlCmd.Parameters.Add(New SqlParameter("@TIPO_IMPORTADOR", SqlDbType.VarChar, 5))
            sqlCmd.Parameters.Add(New SqlParameter("@ID_TRIB_IMPORTADOR", SqlDbType.VarChar, 25))
            sqlCmd.Parameters.Add(New SqlParameter("@PAIS_IMPORTADOR", SqlDbType.VarChar, 5))
            sqlCmd.Parameters.Add(New SqlParameter("@RAZON_SOCIAL_IMPORTADOR", SqlDbType.VarChar, 250))
            sqlCmd.Parameters.Add(New SqlParameter("@DOMICILIO_IMPORTADOR", SqlDbType.VarChar, 250))
            sqlCmd.Parameters.Add(New SqlParameter("@TIPO_REPRESENTANTE", SqlDbType.VarChar, 5))
            sqlCmd.Parameters.Add(New SqlParameter("@ID_TRIB_REPRESENTANTE", SqlDbType.VarChar, 5))
            sqlCmd.Parameters.Add(New SqlParameter("@PAIS_REPRESENTANTE", SqlDbType.VarChar, 5))
            sqlCmd.Parameters.Add(New SqlParameter("@TIPO_DECLARANTE_REPRESENTANTE", SqlDbType.VarChar, 5))
            sqlCmd.Parameters.Add(New SqlParameter("@RAZON_SOCIAL_REPRESENTANTE", SqlDbType.VarChar, 250))
            sqlCmd.Parameters.Add(New SqlParameter("@DOMICILIO_REPRESENTANTE", SqlDbType.VarChar, 250))
            sqlCmd.Parameters.Add(New SqlParameter("@TIPO_CONTENEDOR", SqlDbType.Int))
            sqlCmd.Parameters.Add(New SqlParameter("@NUMERO_CONTENEDOR", SqlDbType.VarChar, 50))
            sqlCmd.Parameters.Add(New SqlParameter("@ENTIDAD_CONTENEDOR", SqlDbType.VarChar, 5))
            sqlCmd.Parameters.Add(New SqlParameter("@NUMERO_MARCHAMO_CONTENEDOR", SqlDbType.VarChar, 50))
            sqlCmd.Parameters.Add(New SqlParameter("@TOTAL_LIQUIDAR", SqlDbType.Decimal))
            sqlCmd.Parameters.Add(New SqlParameter("@TOTAL_OTROS", SqlDbType.Decimal))
            sqlCmd.Parameters.Add(New SqlParameter("@TOTAL_GENERAL", SqlDbType.Decimal))
            sqlCmd.Parameters.Add(New SqlParameter("@CODIGO_POLIZA", SqlDbType.VarChar, 15))
            sqlCmd.Parameters.Add(New SqlParameter("@LAST_UPDATED_BY", SqlDbType.VarChar, 25))
            sqlCmd.Parameters.Add(New SqlParameter("@LAST_UPDATED", SqlDbType.DateTime))
            sqlCmd.Parameters.Add(New SqlParameter("@STATUS", SqlDbType.VarChar, 15))
            sqlCmd.Parameters.Add(New SqlParameter("@CLIENT_CODE", SqlDbType.VarChar, 25))
            sqlCmd.Parameters.Add(New SqlParameter("@WAREHOUSE_REGIMEN", SqlDbType.VarChar, 15))
            sqlCmd.Parameters.Add(New SqlParameter("@FECHA_DOCUMENTO", SqlDbType.DateTime))
            sqlCmd.Parameters.Add(New SqlParameter("@ACUERDO_COMERCIAL", SqlDbType.VarChar, 25))
            sqlCmd.Parameters.Add(New SqlParameter("@TIPO", SqlDbType.VarChar, 25))
            sqlCmd.Parameters.Add(New SqlParameter("@retCode", 1)).Direction = ParameterDirection.ReturnValue
            sqlCmd.Parameters.Add(New SqlParameter("@POLIZAASEGURADA", SqlDbType.VarChar, 50))
            sqlCmd.Parameters.Add(New SqlParameter("@POLIZAASSIGNEDTO", SqlDbType.VarChar, 25))
            sqlCmd.Parameters.Add(New SqlParameter("@TRANSLATION", SqlDbType.VarChar, 10))
            sqlCmd.Parameters.Add(New SqlParameter("@TICKET_NUMBER", SqlDbType.BigInt))

            'asignamos valores
            sqlCmd.Parameters("@NUMERO_ORDEN").Value = pNUMERO_ORDEN.ToUpper
            sqlCmd.Parameters("@ADUANA_ENTRADA_SALIDA").Value = pADUANA_ENTRADA_SALIDA.ToUpper
            sqlCmd.Parameters("@NUMERO_DUA").Value = pNUMERO_DUA.ToUpper
            sqlCmd.Parameters("@FECHA_ACEPTACION_DMY").Value = pFECHA_ACEPTACION_DMY
            sqlCmd.Parameters("@ADUANA_DESPACHO_DESTINO").Value = pADUANA_DESPACHO_DESTINO.ToUpper
            sqlCmd.Parameters("@REGIMEN").Value = pREGIMEN.ToUpper
            sqlCmd.Parameters("@CLASE").Value = pCLASE
            sqlCmd.Parameters("@PAIS_PROCEDENCIA").Value = pPAIS_PROCEDENCIA.ToUpper
            sqlCmd.Parameters("@NATURALEZA_TRANS").Value = pNATURALEZA_TRANS.ToUpper
            sqlCmd.Parameters("@DEPOSITO_FISCAL_ZF").Value = pDEPOSITO_FISCAL_ZF.ToUpper
            sqlCmd.Parameters("@MODO").Value = pMODO
            sqlCmd.Parameters("@FECHA_LLEGADA").Value = DateTime.Parse(pFECHA_LLEGADA.ToString)
            sqlCmd.Parameters("@TIPO_CAMBIO").Value = pTIPO_CAMBIO
            sqlCmd.Parameters("@TOTAL_VALOR_ADUANA").Value = pTOTAL_VALOR_ADUANA
            sqlCmd.Parameters("@TOTAL_NUMERO_LINEAS").Value = pTOTAL_NUMERO_LINEAS
            sqlCmd.Parameters("@TOTAL_BULTOS").Value = pTOTAL_BULTOS
            sqlCmd.Parameters("@TOTAL_PESO_BRUTO_KG").Value = pTOTAL_PESO_BRUTO_KG
            sqlCmd.Parameters("@TOTAL_FOB_USD").Value = pTOTAL_FOB_USD
            sqlCmd.Parameters("@TOTAL_FLETE_USD").Value = pTOTAL_FLETE_USD
            sqlCmd.Parameters("@TOTAL_SEGURO_USD").Value = pTOTAL_SEGURO_USD
            sqlCmd.Parameters("@TOTAL_OTROS_USD").Value = pTOTAL_OTROS_USD
            sqlCmd.Parameters("@NUMERO_SAT").Value = pNUMERO_SAT
            sqlCmd.Parameters("@TIPO_IMPORTADOR").Value = pTIPO_IMPORTADOR
            sqlCmd.Parameters("@ID_TRIB_IMPORTADOR").Value = pID_TRIB_IMPORTADOR
            sqlCmd.Parameters("@PAIS_IMPORTADOR").Value = pPAIS_IMPORTADOR.ToUpper
            sqlCmd.Parameters("@RAZON_SOCIAL_IMPORTADOR").Value = pRAZON_SOCIAL_IMPORTADOR
            sqlCmd.Parameters("@DOMICILIO_IMPORTADOR").Value = pDOMICILIO_IMPORTADOR
            sqlCmd.Parameters("@TIPO_REPRESENTANTE").Value = pTIPO_REPRESENTANTE
            sqlCmd.Parameters("@ID_TRIB_REPRESENTANTE").Value = pID_TRIB_REPRESENTANTE
            sqlCmd.Parameters("@PAIS_REPRESENTANTE").Value = pPAIS_REPRESENTANTE
            sqlCmd.Parameters("@TIPO_DECLARANTE_REPRESENTANTE").Value = pTIPO_DECLARANTE_REPRESENTANTE
            sqlCmd.Parameters("@RAZON_SOCIAL_REPRESENTANTE").Value = pRAZON_SOCIAL_REPRESENTANTE
            sqlCmd.Parameters("@DOMICILIO_REPRESENTANTE").Value = pDOMICILIO_REPRESENTANTE
            sqlCmd.Parameters("@TIPO_CONTENEDOR").Value = pTIPO_CONTENEDOR
            sqlCmd.Parameters("@NUMERO_CONTENEDOR").Value = pNUMERO_CONTENEDOR.ToUpper
            sqlCmd.Parameters("@ENTIDAD_CONTENEDOR").Value = pENTIDAD_CONTENEDOR
            sqlCmd.Parameters("@NUMERO_MARCHAMO_CONTENEDOR").Value = pNUMERO_MARCHAMO_CONTENEDOR
            sqlCmd.Parameters("@TOTAL_LIQUIDAR").Value = pTOTAL_LIQUIDAR
            sqlCmd.Parameters("@TOTAL_OTROS").Value = pTOTAL_OTROS
            sqlCmd.Parameters("@TOTAL_GENERAL").Value = pTOTAL_GENERAL
            sqlCmd.Parameters("@CODIGO_POLIZA").Value = pCODIGO_POLIZA.ToUpper
            sqlCmd.Parameters("@LAST_UPDATED_BY").Value = pLAST_UPDATED_BY
            sqlCmd.Parameters("@LAST_UPDATED").Value = DateTime.Parse(pLAST_UPDATED.ToString)
            sqlCmd.Parameters("@STATUS").Value = pSTATUS.ToUpper
            sqlCmd.Parameters("@CLIENT_CODE").Value = pCLIENT_CODE
            sqlCmd.Parameters("@WAREHOUSE_REGIMEN").Value = pWAREHOUSE_REGIMEN
            sqlCmd.Parameters("@FECHA_DOCUMENTO").Value = DateTime.Parse(pFECHA_DOCUMENTO.ToString)
            sqlCmd.Parameters("@ACUERDO_COMERCIAL").Value = pACUERDO_COMERCIAL
            sqlCmd.Parameters("@TIPO").Value = pTIPO
            If pDOC_ID > 0 Then
                sqlCmd.Parameters("@DOC_ID").Value = pDOC_ID
            End If
            sqlCmd.Parameters("@POLIZAASEGURADA").Value = pPolizaAsegurada
            sqlCmd.Parameters("@POLIZAASSIGNEDTO").Value = pPolizaAssognedto
            sqlCmd.Parameters("@TRANSLATION").Value = pTranslation
            sqlCmd.Parameters("@TICKET_NUMBER").Value = pTicketNumber

            'ejecutamos el procedure y validamos la respuesta
            sqldbConexion.Open()
            sqlCmd.ExecuteNonQuery()

            strReturn = sqlCmd.Parameters("@retCode").Value

            Select Case strReturn
                Case "0"
                    pResult = "ERROR:" + strReturn
                    Return False
                Case "1"
                    pResult = "inserted"
                    pDOC_ID = sqlCmd.Parameters("@DOC_ID").Value
                    Return True
                Case "2"
                    pResult = "updated"
                    Return True
                Case "4"
                    pResult = "ERROR: Ya existe el código de poliza proporcionado, por favor verifique y vuelva a intentar"
                    Return False
                Case "5"
                    pResult = "ERROR: El código de poliza proporcionado no coincide con el almacenado en la base de datos, por favor verifique y vuelva a intentar"
                Case Else
                    pResult = "ERROR:" + strReturn
                    Return False
            End Select

        Catch ex As Exception
            pResult = ex.Message
            pResult = "ERROR:" + ex.Message
            Return False

        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try
    End Function

    <WebMethod(Description:="Graba Detalle de documento")>
    Public Function set_Poliza_Detail(ByVal pDOC_ID As Integer, ByVal pSKU_DESCRIPTION As String, ByVal pSAC_CODE As String, ByVal pBULTOS As Double, ByVal pCLASE As String _
    , ByVal pNET_WEIGTH As Double, ByVal pWEIGTH_UNIT As String, ByVal pQTY As Double, ByVal pCUSTOMS_AMOUNT As Double, ByVal pQTY_UNIT As String, ByVal pVOLUME As Double _
    , ByVal pVOLUME_UNIT As String, ByVal pDAI As Double, ByVal pIVA As Double, ByVal pMISC_TAXES As Double, ByVal pFOB_USD As Double, ByVal pFREIGTH_USD As Double _
    , ByVal pINSURANCE_USD As Double, ByVal pMISC_EXPENSES As Double, ByVal pORIGIN_COUNTRY As String, ByVal pREGION_CP As String, ByVal pAGREEMENT_1 As String _
    , ByVal pAGREEMENT_2 As String, ByVal pRELATED_POLIZA As String, ByVal pLAST_UPDATED_BY As String, ByVal pLAST_UPDATED As Date, ByVal pORIGIN_DOC_ID As Integer _
    , ByVal pCODIGO_POLIZA_ORIGEN As String, ByVal pCLIENT_CODE As String, ByVal pPCTDAI As Double, ByVal pORIGIN_LINE_NUMBER As Double, ByVal pEnvironmentName As String, ByRef pResult As String, ByRef pLINE_NUMBER As Integer, impuesto As Decimal, materialId As String) As Boolean

        Dim sqldb_conexion As SqlConnection
        Dim sqlCmd As SqlCommand
        Dim strReturn As String
        sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Try
            'validamos que el numero de la poliza no venga null
            If pDOC_ID <= 0 Then
                pResult = "ERROR, LA POLIZA A MODIFICAR NO EXISTE. (DocID:" & pDOC_ID & ")"
                Return False
            Else

                sqlCmd = New SqlCommand(DefaultSchema & "sp_OP_WMS_POLIZA_DETAIL", sqldb_conexion)
                sqlCmd.CommandType = CommandType.StoredProcedure

                'creamos todos los parametros del sp
                sqlCmd.Parameters.Add(New SqlParameter("@LINE_NUMBER", SqlDbType.Int, 18)).Direction = ParameterDirection.InputOutput
                sqlCmd.Parameters.Add(New SqlParameter("@DOC_ID", SqlDbType.Int, 18))
                sqlCmd.Parameters.Add(New SqlParameter("@SKU_DESCRIPTION", SqlDbType.VarChar, 250))
                sqlCmd.Parameters.Add(New SqlParameter("@SAC_CODE", SqlDbType.VarChar, 50))
                sqlCmd.Parameters.Add(New SqlParameter("@BULTOS", SqlDbType.Decimal))
                sqlCmd.Parameters.Add(New SqlParameter("@CLASE", SqlDbType.VarChar, 25))
                sqlCmd.Parameters.Add(New SqlParameter("@NET_WEIGTH", SqlDbType.Decimal))
                sqlCmd.Parameters.Add(New SqlParameter("@WEIGTH_UNIT", SqlDbType.VarChar, 25))
                sqlCmd.Parameters.Add(New SqlParameter("@QTY", SqlDbType.Decimal))
                sqlCmd.Parameters.Add(New SqlParameter("@CUSTOMS_AMOUNT", SqlDbType.Decimal))
                sqlCmd.Parameters.Add(New SqlParameter("@QTY_UNIT", SqlDbType.VarChar, 25))
                sqlCmd.Parameters.Add(New SqlParameter("@VOLUME", SqlDbType.Decimal))
                sqlCmd.Parameters.Add(New SqlParameter("@VOLUME_UNIT", SqlDbType.VarChar, 25))
                sqlCmd.Parameters.Add(New SqlParameter("@DAI", SqlDbType.Decimal))
                sqlCmd.Parameters.Add(New SqlParameter("@IVA", SqlDbType.Decimal))
                sqlCmd.Parameters.Add(New SqlParameter("@MISC_TAXES", SqlDbType.Decimal))
                sqlCmd.Parameters.Add(New SqlParameter("@FOB_USD", SqlDbType.Decimal))
                sqlCmd.Parameters.Add(New SqlParameter("@FREIGTH_USD", SqlDbType.Decimal))
                sqlCmd.Parameters.Add(New SqlParameter("@INSURANCE_USD", SqlDbType.Decimal))
                sqlCmd.Parameters.Add(New SqlParameter("@MISC_EXPENSES", SqlDbType.Decimal))
                sqlCmd.Parameters.Add(New SqlParameter("@ORIGIN_COUNTRY", SqlDbType.VarChar, 50))
                sqlCmd.Parameters.Add(New SqlParameter("@REGION_CP", SqlDbType.VarChar, 50))
                sqlCmd.Parameters.Add(New SqlParameter("@AGREEMENT_1", SqlDbType.VarChar, 50))
                sqlCmd.Parameters.Add(New SqlParameter("@AGREEMENT_2", SqlDbType.VarChar, 50))
                sqlCmd.Parameters.Add(New SqlParameter("@RELATED_POLIZA", SqlDbType.VarChar, 15))
                sqlCmd.Parameters.Add(New SqlParameter("@LAST_UPDATED_BY", SqlDbType.VarChar, 25))
                sqlCmd.Parameters.Add(New SqlParameter("@LAST_UPDATED", SqlDbType.DateTime))
                sqlCmd.Parameters.Add(New SqlParameter("@ORIGIN_DOC_ID", SqlDbType.Int, 18))
                sqlCmd.Parameters.Add(New SqlParameter("@CODIGO_POLIZA_ORIGEN", SqlDbType.VarChar, 15))
                sqlCmd.Parameters.Add(New SqlParameter("@CLIENT_CODE", SqlDbType.VarChar, 25))
                sqlCmd.Parameters.Add(New SqlParameter("@PCTDAI", SqlDbType.Decimal))
                sqlCmd.Parameters.Add(New SqlParameter("@ORIGIN_LINE_NUMBER", SqlDbType.Int, 18))
                sqlCmd.Parameters.Add(New SqlParameter("@retCode", 1)).Direction = ParameterDirection.ReturnValue
                sqlCmd.Parameters.Add(New SqlParameter("@TAX", SqlDbType.Decimal))
                sqlCmd.Parameters.Add(New SqlParameter("@MATERIAL_ID", SqlDbType.VarChar, 50))
                'If pLINE_NUMBER > 0 Then
                '    sqlCmd.Parameters("@LINE_NUMBER").Value = pLINE_NUMBER
                'End If

                'asignamos valores
                sqlCmd.Parameters("@LINE_NUMBER").Value = pLINE_NUMBER
                sqlCmd.Parameters("@DOC_ID").Value = pDOC_ID
                sqlCmd.Parameters("@SKU_DESCRIPTION").Value = pSKU_DESCRIPTION
                sqlCmd.Parameters("@SAC_CODE").Value = pSAC_CODE
                sqlCmd.Parameters("@BULTOS").Value = pBULTOS
                sqlCmd.Parameters("@CLASE").Value = pCLASE
                sqlCmd.Parameters("@NET_WEIGTH").Value = pNET_WEIGTH
                sqlCmd.Parameters("@WEIGTH_UNIT").Value = pWEIGTH_UNIT
                sqlCmd.Parameters("@QTY").Value = pQTY
                sqlCmd.Parameters("@CUSTOMS_AMOUNT").Value = pCUSTOMS_AMOUNT
                sqlCmd.Parameters("@QTY_UNIT").Value = pQTY_UNIT
                sqlCmd.Parameters("@VOLUME").Value = pVOLUME
                sqlCmd.Parameters("@VOLUME_UNIT").Value = pVOLUME_UNIT
                sqlCmd.Parameters("@DAI").Value = pDAI
                sqlCmd.Parameters("@IVA").Value = pIVA
                sqlCmd.Parameters("@MISC_TAXES").Value = pMISC_TAXES
                sqlCmd.Parameters("@FOB_USD").Value = pFOB_USD
                sqlCmd.Parameters("@FREIGTH_USD").Value = pFREIGTH_USD
                sqlCmd.Parameters("@INSURANCE_USD").Value = pINSURANCE_USD
                sqlCmd.Parameters("@MISC_EXPENSES").Value = pMISC_EXPENSES
                sqlCmd.Parameters("@ORIGIN_COUNTRY").Value = pORIGIN_COUNTRY
                sqlCmd.Parameters("@REGION_CP").Value = pREGION_CP
                sqlCmd.Parameters("@AGREEMENT_1").Value = pAGREEMENT_1
                sqlCmd.Parameters("@AGREEMENT_2").Value = pAGREEMENT_2
                sqlCmd.Parameters("@RELATED_POLIZA").Value = pRELATED_POLIZA
                sqlCmd.Parameters("@LAST_UPDATED_BY").Value = pLAST_UPDATED_BY
                sqlCmd.Parameters("@LAST_UPDATED").Value = DateTime.Parse(pLAST_UPDATED.ToString())
                sqlCmd.Parameters("@ORIGIN_DOC_ID").Value = pORIGIN_DOC_ID
                sqlCmd.Parameters("@CODIGO_POLIZA_ORIGEN").Value = pCODIGO_POLIZA_ORIGEN
                sqlCmd.Parameters("@CLIENT_CODE").Value = pCLIENT_CODE
                sqlCmd.Parameters("@PCTDAI").Value = pPCTDAI
                sqlCmd.Parameters("@ORIGIN_LINE_NUMBER").Value = pORIGIN_LINE_NUMBER
                sqlCmd.Parameters("@TAX").Value = impuesto
                sqlCmd.Parameters("@MATERIAL_ID").Value = materialId

                'ejecutamos el procedure y validamos la respuesta
                If sqldb_conexion.State = ConnectionState.Closed Then sqldb_conexion.Open()
                sqlCmd.ExecuteNonQuery()

                strReturn = sqlCmd.Parameters("@retCode").Value

                If strReturn = "0" Then
                    pResult = "ERROR:" + strReturn
                    Return False
                Else
                    If strReturn = "1" Then
                        pResult = "inserted"
                        pLINE_NUMBER = sqlCmd.Parameters("@LINE_NUMBER").Value
                    End If
                    If strReturn = "2" Then
                        pResult = "updated"
                    End If
                    Return True
                End If
            End If
        Catch ex As Exception
            pResult = ex.Message
            pResult = "ERROR:" + ex.Message
            Return False

        Finally
            If sqldb_conexion.State = ConnectionState.Open Then sqldb_conexion.Close()

        End Try


    End Function

    <WebMethod(Description:="Devuelve documentos asociados a documento con cualquier where")>
    Public Function get_Docs_Ref_Poliza(ByVal pWhere As String, ByVal pEnvironmentName As String, ByRef pResult As String) As DataSet
        Dim XSQL As String = "SELECT DOC_ID,NUMERO_DUA,NUMERO_DOCUMENTO,TIPO_DOCUMENTO,FECHA_DOCUMENTO,OBSERVACIONES FROM " & DefaultSchema & "OP_WMS3PL_DOCS_REFERENCIA "
        XSQL = XSQL & pWhere
        Dim sqldb_conexion As SqlConnection

        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()
            miscDA.Fill(miscDS, "OP_WMS3PL_DOCS_REFERENCIA")
            pResult = "OK"
            Return miscDS
        Catch ex As Exception
            pResult = ex.Message
            pResult = "ERROR," + ex.Message
            Return Nothing

        End Try

    End Function

    <WebMethod(Description:="Graba Documentos de referencia de documento de ingreso")>
    Public Function set_Docs_Ref_Poliza(ByVal pDOC_ID As Integer, ByVal pNUMERO_DUA As String, ByVal pNUMERO_DOCUMENTO As String, ByVal pTIPO_DOCUMENTO As String, ByVal pFECHA_DOCUMENTO As Date, ByVal pOBSERVACIONES As String, ByVal pLAST_UPDATED_BY As String, ByVal pLAST_UPDATED As Date, ByVal pEnvironmentName As String, ByRef pResult As String) As Boolean
        Dim sqldb_conexion As SqlConnection
        Dim sqlCmd As SqlCommand
        Dim strReturn As String
        sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Try
            sqlCmd = New SqlCommand(DefaultSchema & "sp_OP_WMS3PL_DOCS_REFERENCIA", sqldb_conexion)
            sqlCmd.CommandType = CommandType.StoredProcedure

            'creamos todos los parametros del sp
            sqlCmd.Parameters.Add(New SqlParameter("@DOC_ID", SqlDbType.Int, 18)).Direction = ParameterDirection.Input
            sqlCmd.Parameters.Add(New SqlParameter("@NUMERO_DUA", SqlDbType.VarChar, 15))
            sqlCmd.Parameters.Add(New SqlParameter("@NUMERO_DOCUMENTO", SqlDbType.VarChar, 50))
            sqlCmd.Parameters.Add(New SqlParameter("@TIPO_DOCUMENTO", SqlDbType.VarChar, 15))
            sqlCmd.Parameters.Add(New SqlParameter("@FECHA_DOCUMENTO", SqlDbType.Date))
            sqlCmd.Parameters.Add(New SqlParameter("@OBSERVACIONES", SqlDbType.VarChar, 250))
            sqlCmd.Parameters.Add(New SqlParameter("@LAST_UPDATED_BY", SqlDbType.VarChar, 25))
            sqlCmd.Parameters.Add(New SqlParameter("@LAST_UPDATED", SqlDbType.Date))
            sqlCmd.Parameters.Add(New SqlParameter("@retCode", 1)).Direction = ParameterDirection.ReturnValue

            'asignamos valores
            sqlCmd.Parameters("@DOC_ID").Value = pDOC_ID
            sqlCmd.Parameters("@NUMERO_DUA").Value = pNUMERO_DUA
            sqlCmd.Parameters("@NUMERO_DOCUMENTO").Value = pNUMERO_DOCUMENTO
            sqlCmd.Parameters("@TIPO_DOCUMENTO").Value = pTIPO_DOCUMENTO
            sqlCmd.Parameters("@FECHA_DOCUMENTO").Value = pFECHA_DOCUMENTO
            sqlCmd.Parameters("@OBSERVACIONES").Value = pOBSERVACIONES
            sqlCmd.Parameters("@LAST_UPDATED_BY").Value = pLAST_UPDATED_BY
            sqlCmd.Parameters("@LAST_UPDATED").Value = pLAST_UPDATED

            If sqldb_conexion.State = ConnectionState.Closed Then sqldb_conexion.Open()
            sqlCmd.ExecuteNonQuery()

            strReturn = sqlCmd.Parameters("@retCode").Value

            If strReturn = "0" Then
                pResult = "ERROR:" + strReturn
                Return False
            Else
                If strReturn = "1" Then
                    pResult = "inserted"
                    pDOC_ID = sqlCmd.Parameters("@DOC_ID").Value
                End If
                If strReturn = "2" Then
                    pResult = "updated"
                End If
                Return True
            End If

        Catch ex As Exception
            pResult = ex.Message
            pResult = "ERROR:" + ex.Message
            Return False

        Finally
            If sqldb_conexion.State = ConnectionState.Open Then sqldb_conexion.Close()

        End Try
    End Function

    <WebMethod(Description:="borra documentos de referencia de documento de ingreso")>
    Public Function del_Docs_Ref_Poliza(ByVal pDOC_ID As Integer, ByVal pNUMERO_DOCUMENTO As String, ByVal pTIPO_DOCUMENTO As String, ByVal pEnvironmentName As String, ByRef pResult As String) As Boolean
        Dim XSQL As String

        Try
            XSQL = "DELETE FROM " & DefaultSchema & "OP_WMS3PL_DOCS_REFERENCIA WHERE DOC_ID = " & pDOC_ID.ToString() & " AND NUMERO_DOCUMENTO = '" & pNUMERO_DOCUMENTO & "' AND TIPO_DOCUMENTO = '" & pTIPO_DOCUMENTO & "'"
            ExecuteSqlTransaction(AppSettings(pEnvironmentName).ToString, XSQL, pResult)

            If pResult = "OK" Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            pResult = ex.Message

            Return False
        End Try
    End Function

    <WebMethod(Description:="Devuelve las transacciones de una poliza")>
    Public Function get_tran_byPoliza(ByVal pPOLIZA As String, ByVal pEnvironmentName As String, ByRef pResult As String) As DataSet
        Dim XSQL As String = "SELECT * FROM " & DefaultSchema & "OP_WMS_TRANS WHERE CODIGO_POLIZA = '" & pPOLIZA & "'"

        Dim sqldb_conexion As SqlConnection

        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()
            miscDA.Fill(miscDS, "OP_WMS_TRANS")
            pResult = "OK"
            Return miscDS
        Catch ex As Exception
            pResult = ex.Message
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
    End Function


    <WebMethod(Description:="Devuelve las transacciones de una poliza")>
    Public Function get_tran_byID(ByVal pTRAN As Double, ByVal pEnvironmentName As String, ByRef pResult As String) As DataSet
        Dim XSQL As String = "SELECT * FROM " & DefaultSchema & "OP_WMS_TRANS WHERE SERIAL_NUMBER = '" & pTRAN & "'"

        Dim sqldb_conexion As SqlConnection

        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()
            miscDA.Fill(miscDS, "OP_WMS_TRANS")
            pResult = "OK"
            Return miscDS
        Catch ex As Exception
            pResult = ex.Message
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
    End Function

    <WebMethod(Description:="Devuelve las transacciones pendientes de cuadrar")>
    Public Function get_recepcions_pending_auto(ByVal pEnvironmentName As String, ByRef pResult As String) As DataSet
        Dim XSQL As String = "SELECT * FROM " & DefaultSchema & "OP_WMS3PL_VIEW_AUTORIZATIONS_PENDING_AUTO "

        Dim sqldb_conexion As SqlConnection

        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()
            miscDA.Fill(miscDS, "OP_WMS_TRANS")
            pResult = "OK"
            Return miscDS
        Catch ex As Exception
            pResult = ex.Message
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
    End Function

    <WebMethod(Description:="Graba poliza recepcion match")>
    Public Function set_POLIZA_TRANS_MATCH(ByVal pCODIGO_POLIZA As String, ByVal pTRANS_ID As Integer, ByVal pLINENO_POLIZA As Integer, ByVal pDOC_ID As Integer,
                                           ByVal pSKU_DESCRIPTION As String, ByVal pMATERIAL_CODE As String, ByVal pMATERIAL_DESCRIPTION As String,
                                           ByVal pQTY_TRANS As Double, ByVal pQTY_POLIZA As Double, ByVal pBULTOS_POLIZA As Double,
                                           ByVal pLAST_UPDATED_BY As String, ByVal pQty As Double, ByVal pComments As String,
                                           ByVal pEnvironmentName As String, ByRef pResult As String) As Boolean
        Dim sqldb_conexion As SqlConnection
        Dim sqlCmd As SqlCommand
        Dim strReturn As String
        sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Try
            sqlCmd = New SqlCommand(DefaultSchema & "sp_OP_WMS3PL_POLIZA_TRANS_MATCH", sqldb_conexion)
            sqlCmd.CommandType = CommandType.StoredProcedure

            'creamos todos los parametros del sp
            sqlCmd.Parameters.Add(New SqlParameter("@CODIGO_POLIZA", SqlDbType.VarChar, 25)).Direction = ParameterDirection.Input
            sqlCmd.Parameters.Add(New SqlParameter("@TRANS_ID", SqlDbType.Int, 18))
            sqlCmd.Parameters.Add(New SqlParameter("@LINENO_POLIZA", SqlDbType.Int, 18))
            sqlCmd.Parameters.Add(New SqlParameter("@DOC_ID", SqlDbType.Int, 18))
            sqlCmd.Parameters.Add(New SqlParameter("@SKU_DESCRIPTION", SqlDbType.VarChar, 250))
            sqlCmd.Parameters.Add(New SqlParameter("@MATERIAL_CODE", SqlDbType.VarChar, 25))
            sqlCmd.Parameters.Add(New SqlParameter("@MATERIAL_DESCRIPTION", SqlDbType.VarChar, 200))
            sqlCmd.Parameters.Add(New SqlParameter("@QTY_TRANS", SqlDbType.Decimal))
            sqlCmd.Parameters.Add(New SqlParameter("@QTY_POLIZA", SqlDbType.Decimal))
            sqlCmd.Parameters.Add(New SqlParameter("@BULTOS_POLIZA", SqlDbType.Decimal))
            sqlCmd.Parameters.Add(New SqlParameter("@LAST_UPDATED_BY", SqlDbType.VarChar, 25))
            sqlCmd.Parameters.Add(New SqlParameter("@retCode", 1)).Direction = ParameterDirection.ReturnValue
            sqlCmd.Parameters.Add(New SqlParameter("@QTY", SqlDbType.Decimal))
            sqlCmd.Parameters.Add(New SqlParameter("@COMMENTS", SqlDbType.VarChar))

            sqlCmd.Parameters("@CODIGO_POLIZA").Value = pCODIGO_POLIZA
            sqlCmd.Parameters("@TRANS_ID").Value = pTRANS_ID
            sqlCmd.Parameters("@LINENO_POLIZA").Value = pLINENO_POLIZA
            sqlCmd.Parameters("@DOC_ID").Value = pDOC_ID
            sqlCmd.Parameters("@SKU_DESCRIPTION").Value = pSKU_DESCRIPTION
            sqlCmd.Parameters("@MATERIAL_CODE").Value = pMATERIAL_CODE
            sqlCmd.Parameters("@MATERIAL_DESCRIPTION").Value = pMATERIAL_DESCRIPTION
            sqlCmd.Parameters("@QTY_TRANS").Value = pQTY_TRANS
            sqlCmd.Parameters("@QTY_POLIZA").Value = pQTY_POLIZA
            sqlCmd.Parameters("@BULTOS_POLIZA").Value = pBULTOS_POLIZA
            sqlCmd.Parameters("@LAST_UPDATED_BY").Value = pLAST_UPDATED_BY
            sqlCmd.Parameters("@QTY").Value = pQty
            sqlCmd.Parameters("@COMMENTS").Value = pComments

            'ejecutamos el procedure y validamos la respuesta
            If sqldb_conexion.State = ConnectionState.Closed Then sqldb_conexion.Open()
            sqlCmd.ExecuteNonQuery()

            strReturn = sqlCmd.Parameters("@retCode").Value

            If strReturn = "0" Then
                pResult = "ERROR:" + strReturn
                Return False
            Else
                If strReturn = "1" Then
                    pResult = "inserted"

                End If
                If strReturn = "2" Then
                    pResult = "updated"
                End If
                Return True
            End If

        Catch ex As Exception
            pResult = ex.Message
            pResult = "ERROR:" + ex.Message
            Return False

        Finally
            If sqldb_conexion.State = ConnectionState.Open Then sqldb_conexion.Close()

        End Try

    End Function

    <WebMethod(Description:="Devuelve detalle de asociacion entre las recepciones y las polizas de ingreso")>
    Public Function get_trans_match(ByVal pWhere As String, ByVal pEnvironmentName As String, ByRef pResult As String) As DataSet
        Dim XSQL As String = " SELECT TM.*, T.LICENSE_ID FROM " & DefaultSchema & "OP_WMS3PL_POLIZA_TRANS_MATCH TM"
        XSQL = XSQL & " INNER JOIN " & DefaultSchema & "OP_WMS_TRANS T ON (TM.TRANS_ID = T.SERIAL_NUMBER) "
        XSQL = XSQL & pWhere
        Dim sqldb_conexion As SqlConnection

        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()
            miscDA.Fill(miscDS, "OP_WMS3PL_POLIZA_TRANS_MATCH")
            pResult = "OK"
            Return miscDS
        Catch ex As Exception
            pResult = ex.Message
            pResult = "ERROR," + ex.Message
            Return Nothing

        End Try

    End Function

    <WebMethod(Description:="borra asociacion entre transacciones y polizas")>
    Public Function del_POLIZA_TRANS_MATCH(ByVal pCODIGO_POLIZA As String, ByVal pMATERIAL_CODE As String, ByVal pLINENO_POLIZA As Integer, ByVal pTRANS_ID As Integer, ByVal pEnvironmentName As String, ByRef pResult As String) As Boolean
        Dim XSQL As String

        Try
            XSQL = "DELETE FROM " & DefaultSchema & "OP_WMS3PL_POLIZA_TRANS_MATCH WHERE CODIGO_POLIZA = '" & pCODIGO_POLIZA & "' AND MATERIAL_CODE = '" & pMATERIAL_CODE & "' AND LINENO_POLIZA = " & pLINENO_POLIZA.ToString & " AND TRANS_ID = " & pTRANS_ID.ToString
            ExecuteSqlTransaction(AppSettings(pEnvironmentName).ToString, XSQL, pResult)

            If pResult = "OK" Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            pResult = ex.Message

            Return False
        End Try
    End Function


    <WebMethod(Description:="Devuelve inventario actual por documento")>
    Public Function GetInventoryByDosc(pEnvironmentName As String, ByRef pResult As String) As DataTable
        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()
        Try
            Dim cmd As New SqlCommand
            Dim reader As SqlDataReader
            Dim dt As DataTable = New DataTable("GetInventoryByDosc")
            cmd.CommandText = String.Format("{0}OP_WMS_SP_GET_INVENTORY_BY_DOCS", DefaultSchema)
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

    <WebMethod(Description:="Devuelve inventario actual por documento")>
    Public Function get_inventory_bydocs(ByVal pWhere As String, ByVal pEnvironmentName As String, ByRef pResult As String) As DataSet
        Dim XSQL As String = " SELECT DISTINCT VID.* FROM " & DefaultSchema & "OP_WMS_VIEW_INVENTORY_X_DOCS VID"
        XSQL = XSQL & " INNER JOIN " & DefaultSchema & "OP_WMS3PL_POLIZA_TRANS_MATCH PTM ON( "
        XSQL = XSQL & " VID.DOC_ID = PTM.DOC_ID"
        XSQL = XSQL & " ) "

        XSQL = XSQL & pWhere
        Dim sqldb_conexion As SqlConnection

        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()
            miscDA.Fill(miscDS, "INVENTORY_X_DOCS")
            pResult = "OK"
            Return miscDS
        Catch ex As Exception
            pResult = ex.Message
            pResult = "ERROR," + ex.Message
            Return Nothing

        End Try
    End Function

    <WebMethod(Description:="Devuelve acuerdo comercial del cliente")>
    Public Function get_cust_term_of_trade(ByVal pCLIENT_CODE As String, ByVal pEnvironmentName As String, ByRef pResult As String) As DataSet
        Dim XSQL As String = "select CLIENT_CA FROM " & DefaultSchema & "OP_WMS_VIEW_CLIENTS where CLIENT_CODE = '" & pCLIENT_CODE & "' COLLATE DATABASE_DEFAULT"
        Dim sqldb_conexion As SqlConnection

        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()
            miscDA.Fill(miscDS, "OP_WMS_CLIENTS")
            pResult = "OK"
            Return miscDS
        Catch ex As Exception
            pResult = ex.Message
            pResult = "ERROR," + ex.Message
            Return Nothing

        End Try

    End Function

    <WebMethod(Description:="borra una linea del detalle de la poliza")>
    Public Function del_POLIZA_LINE(ByVal pDOC_ID As Integer, ByVal pLINENO_POLIZA As Integer, ByVal pEnvironmentName As String, ByRef pResult As String) As Boolean
        Dim XSQL As String

        Try
            XSQL = "DELETE FROM " & DefaultSchema & "OP_WMS_POLIZA_DETAIL WHERE DOC_ID = " & pDOC_ID.ToString & " AND LINE_NUMBER = " & pLINENO_POLIZA.ToString
            ExecuteSqlTransaction(AppSettings(pEnvironmentName).ToString, XSQL, pResult)

            If pResult = "OK" Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            pResult = ex.Message

            Return False
        End Try
    End Function

    <WebMethod(Description:="Devuelve los productos del cliente")>
    Public Function get_cust_skus(ByVal pCLIENT_CODE As String, ByVal pEnvironmentName As String, ByRef pResult As String) As DataSet
        Dim XSQL As String = "select BARCODE_ID, MATERIAL_NAME,MATERIAL_ID FROM " & DefaultSchema & "OP_WMS_MATERIALS where CLIENT_OWNER = '" & pCLIENT_CODE.ToString + "' COLLATE DATABASE_DEFAULT"
        Dim sqldb_conexion As SqlConnection

        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()
            miscDA.Fill(miscDS, "OP_WMS_MATERIALS")
            pResult = "OK"
            Return miscDS
        Catch ex As Exception
            pResult = ex.Message
            pResult = "ERROR," + ex.Message
            Return Nothing

        End Try

    End Function

    <WebMethod(Description:="Devuelve documentos de egreso pendientes de picking")>
    Public Function get_pending_picking(ByVal pWHERE As String, ByVal pEnvironmentName As String, ByRef pResult As String) As DataSet
        Dim XSQL As String = "SELECT *  FROM " & DefaultSchema & "OP_WMS3PL_VIEW_PENDING "
        If pWHERE.Length > 0 Then
            XSQL = XSQL & pWHERE
        End If

        Dim sqldb_conexion As SqlConnection

        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()
            miscDA.Fill(miscDS, "OP_WMS3PL_PENDING")
            pResult = "OK"
            Return miscDS
        Catch ex As Exception            
            pResult = "ERROR," + ex.Message
            Return Nothing

        End Try
    End Function

    <WebMethod(Description:=" actualiza picking en proceso")>
    Public Function set_picking_status(ByVal pDOC_ID As Integer, ByVal pLINE_NUMBER As Integer, ByVal pSTATUS As String, ByVal pEnvironmentName As String, ByRef pResult As String) As DataSet
        Dim XSQL As String

        Try
            XSQL = "UPDATE " & DefaultSchema & "OP_WMS_POLIZA_DETAIL SET PICKING_STATUS = '" & pSTATUS & "' WHERE DOC_ID = " & pDOC_ID.ToString() & " AND LINE_NUMBER = " & pLINE_NUMBER.ToString()
            ExecuteSqlTransaction(AppSettings(pEnvironmentName).ToString, XSQL, pResult)

            If pResult = "OK" Then
                XSQL = "SELECT TOP 1 WAVE_PICKING_ID FROM " + DefaultSchema + "OP_WMS_TASK_LIST ORDER BY ASSIGNED_DATE DESC;"
                Dim sqldb_conexion As SqlConnection
                Try
                    sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
                    Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
                    Dim miscDS As DataSet = New DataSet()
                    miscDA.Fill(miscDS, "OP_WMS_TASK_LIST")
                    pResult = "OK"
                    Return miscDS
                Catch ex As Exception
                    pResult = "ERROR," + ex.Message + ex.StackTrace
                    Return Nothing
                End Try
            Else
                pResult = "ERROR"
                Return Nothing
            End If

        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
    End Function

    <WebMethod(Description:="Devuelve detalle de asociacion entre las productos y las polizas de ingreso")>
    Public Function get_skus_match(ByVal pWhere As String, ByVal pEnvironmentName As String, ByRef pResult As String) As DataSet
        Dim XSQL As String = " SELECT *  FROM " & DefaultSchema & "OP_WMS3PL_VIEW_POLIZA_MATERIAL_MATCH "
        If pWhere.Length > 0 Then
            XSQL = XSQL & pWhere
        End If
        'XSQL = XSQL + " GROUP BY pm.CODIGO_POLIZA, pm.LINENO_POLIZA, pm.DOC_ID, pm.MATERIAL_CODE, mt.BARCODE_ID, mt.ALTERNATE_BARCODE, mt.MATERIAL_NAME"
        Dim sqldb_conexion As SqlConnection
        LogSQLErrors("get_skus_match", XSQL, "")
        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()
            miscDA.Fill(miscDS, "OP_WMS3PL_POLIZA_TRANS_MATCH")
            If miscDS.Tables(0).Rows.Count >= 1 Then
                pResult = "OK"
                Return miscDS
            Else
                pResult = "ERROR, No hay datos para: " + pWhere + ". No hay inventario disponible"
                Return Nothing
            End If

            Return Nothing
        Catch ex As Exception
            pResult = ex.Message
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
    End Function

    <WebMethod(Description:="Crea tareas de picking")>
    Public Function set_tasks_list(ByVal pTASK_TYPE As String, ByVal pTASK_SUBTYPE As String, ByVal pTASK_OWNER As String, ByVal pTASK_ASSIGNEDTO As String, ByVal pQUATITY_ASSIGNED As Double, ByVal pQUATITY_PENDING As Double,
                                   ByVal pCODIGO_POLIZA_SOURCE As String, ByVal pCODIGO_POLIZA_TARGET As String, ByVal pREGIMEN As String, ByVal pMATERIAL_ID As String, ByVal pBARCODE_ID As String, ByVal pALTERNATE_BARCODE As String,
                                   ByVal pMATERIAL_NAME As String, ByVal pCLIENT_OWNER As String, ByVal pCLIENT_NAME As String, ByVal numeroDeLineaPolizaOrigen As Integer, ByVal numeroDeLineaPolizaDestino As Integer, ByVal pEnvironmentName As String, ByRef pResult As String, ByRef pWAVE_PICKING_ID As Integer, ByVal pTranslation As String) As Boolean
        Dim sqldb_conexion As SqlConnection
        Dim sqlCmd As SqlCommand

        sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Try
            sqlCmd = New SqlCommand(DefaultSchema & "sp_INSERT_TASKS", sqldb_conexion)
            sqlCmd.CommandType = CommandType.StoredProcedure
            sqlCmd.CommandTimeout = 100

            'creamos todos los parametros del sp
            sqlCmd.Parameters.Add(New SqlParameter("@TASK_TYPE", SqlDbType.VarChar, 25)).Direction = ParameterDirection.Input
            sqlCmd.Parameters.Add(New SqlParameter("@TASK_SUBTYPE", SqlDbType.VarChar, 25))
            sqlCmd.Parameters.Add(New SqlParameter("@TASK_OWNER", SqlDbType.VarChar, 25))
            sqlCmd.Parameters.Add(New SqlParameter("@TASK_ASSIGNEDTO", SqlDbType.VarChar, 25))
            sqlCmd.Parameters.Add(New SqlParameter("@QUANTITY_ASSIGNED", SqlDbType.Float))
            sqlCmd.Parameters.Add(New SqlParameter("@QUANTITY_PENDING", SqlDbType.Float))
            sqlCmd.Parameters.Add(New SqlParameter("@CODIGO_POLIZA_SOURCE", SqlDbType.VarChar, 25))
            sqlCmd.Parameters.Add(New SqlParameter("@CODIGO_POLIZA_TARGET", SqlDbType.VarChar, 25))
            sqlCmd.Parameters.Add(New SqlParameter("@REGIMEN", SqlDbType.VarChar, 50))
            sqlCmd.Parameters.Add(New SqlParameter("@MATERIAL_ID", SqlDbType.VarChar, 25))
            sqlCmd.Parameters.Add(New SqlParameter("@BARCODE_ID", SqlDbType.VarChar, 50))
            sqlCmd.Parameters.Add(New SqlParameter("@ALTERNATE_BARCODE", SqlDbType.VarChar, 50))
            sqlCmd.Parameters.Add(New SqlParameter("@MATERIAL_NAME", SqlDbType.VarChar, 200))
            sqlCmd.Parameters.Add(New SqlParameter("@CLIENT_OWNER", SqlDbType.VarChar, 25))
            sqlCmd.Parameters.Add(New SqlParameter("@CLIENT_NAME", SqlDbType.VarChar, 150))
            sqlCmd.Parameters.Add(New SqlParameter("@PRESULT", SqlDbType.VarChar, 4000)).Direction = ParameterDirection.Output
            sqlCmd.Parameters.Add(New SqlParameter("@WAVE_PICKING_ID", SqlDbType.Int)).Direction = ParameterDirection.InputOutput
            sqlCmd.Parameters.Add(New SqlParameter("@TRAMSLATION", SqlDbType.VarChar, 10))

            sqlCmd.Parameters("@TASK_TYPE").Value = pTASK_TYPE
            sqlCmd.Parameters("@TASK_SUBTYPE").Value = pTASK_SUBTYPE
            sqlCmd.Parameters("@TASK_OWNER").Value = pTASK_OWNER
            sqlCmd.Parameters("@TASK_ASSIGNEDTO").Value = pTASK_ASSIGNEDTO
            sqlCmd.Parameters("@QUANTITY_ASSIGNED").Value = pQUATITY_ASSIGNED
            sqlCmd.Parameters("@QUANTITY_PENDING").Value = pQUATITY_PENDING
            sqlCmd.Parameters("@CODIGO_POLIZA_SOURCE").Value = pCODIGO_POLIZA_SOURCE
            sqlCmd.Parameters("@CODIGO_POLIZA_TARGET").Value = pCODIGO_POLIZA_TARGET
            sqlCmd.Parameters("@REGIMEN").Value = pREGIMEN
            sqlCmd.Parameters("@MATERIAL_ID").Value = pMATERIAL_ID
            sqlCmd.Parameters("@BARCODE_ID").Value = pBARCODE_ID
            sqlCmd.Parameters("@ALTERNATE_BARCODE").Value = pALTERNATE_BARCODE
            sqlCmd.Parameters("@MATERIAL_NAME").Value = pMATERIAL_NAME
            sqlCmd.Parameters("@CLIENT_OWNER").Value = pCLIENT_OWNER
            sqlCmd.Parameters("@CLIENT_NAME").Value = pCLIENT_NAME
            sqlCmd.Parameters("@WAVE_PICKING_ID").Value = pWAVE_PICKING_ID
            sqlCmd.Parameters("@TRAMSLATION").Value = pTranslation

            sqlCmd.Parameters.Add(New SqlParameter("@LINE_NUMBER_POLIZA_SOURCE", SqlDbType.Int)).Value = numeroDeLineaPolizaOrigen
            sqlCmd.Parameters.Add(New SqlParameter("@LINE_NUMBER_POLIZA_TARGET", SqlDbType.Int)).Value = numeroDeLineaPolizaDestino

            'ejecutamos el procedure y validamos la respuesta
            If sqldb_conexion.State = ConnectionState.Closed Then sqldb_conexion.Open()
            sqlCmd.ExecuteNonQuery()

            pResult = sqlCmd.Parameters("@PRESULT").Value


            If pResult = "OK" Then
                pWAVE_PICKING_ID = sqlCmd.Parameters("@WAVE_PICKING_ID").Value
                Return True
            Else

                pWAVE_PICKING_ID = 0
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

    <WebMethod(Description:="Devuelve todos los encabezados de documento")>
    Public Function get_all_Poliza_Headers(ByVal pWhere As String, ByVal pEnvironmentName As String, ByRef pResult As String) As DataSet
        Dim XSQL As String = "SELECT * FROM " & DefaultSchema & "OP_WMS_POLIZA_HEADER " & pWhere
        Dim sqldb_conexion As SqlConnection

        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()
            miscDA.Fill(miscDS, "OP_WMS_POLIZA_HEAD")
            pResult = "OK"
            Return miscDS
        Catch ex As Exception
            pResult = ex.Message
            pResult = "ERROR," + ex.Message
            Return Nothing

        End Try

    End Function

    <WebMethod(Description:="Devuelve todos las imagenes del documento")>
    Public Function get_all_Poliza_Images(ByVal pWhere As String, ByVal pEnvironmentName As String, ByRef pResult As String) As DataSet
        Dim XSQL As String = "SELECT * FROM " & DefaultSchema & "OP_WMS_IMAGENES_POLIZA " & pWhere & " ORDER BY UPLOADED_DATE DESC"
        Dim sqldb_conexion As SqlConnection

        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()
            miscDA.Fill(miscDS, "OP_WMS_IMAGENES_POLIZA")
            pResult = "OK"
            Return miscDS
        Catch ex As Exception
            pResult = ex.Message
            pResult = "ERROR," + ex.Message
            Return Nothing

        End Try

    End Function

    <WebMethod(Description:="Crea pase de salida")>
    Public Function set_pass(ByVal pCLIENT_CODE As String, ByVal pCLIENT_NAME As String, ByVal pLAST_UPDATED_BY As String, ByVal pISEMPTY As String, ByVal pVEHICLE_PLATE As String,
                                   ByVal pVEHICLE_DRIVER As String, ByVal pVEHICLE_ID As String, ByVal pDRIVER_ID As String, ByVal pAUTORIZED_BY As String,
                                   ByVal pHANDLER As String, ByVal pCARRIER As String, ByVal pTXT As String, ByVal pLOADUNLOAD As String, ByVal pLOADWITH As String,
                                   ByVal pAUDIT_ID As Integer, ByVal pEnvironmentName As String, ByRef pResult As String, ByRef pPASSID As Integer) As Boolean
        Dim sqldb_conexion As SqlConnection
        Dim sqlCmd As SqlCommand

        sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Try
            sqlCmd = New SqlCommand(DefaultSchema & "sp_OP_WMS3PL_PASSES", sqldb_conexion)
            sqlCmd.CommandType = CommandType.StoredProcedure

            'creamos todos los parametros del sp
            sqlCmd.Parameters.Add(New SqlParameter("@CLIENT_CODE", SqlDbType.VarChar, 25)).Direction = ParameterDirection.Input
            sqlCmd.Parameters.Add(New SqlParameter("@CLIENT_NAME", SqlDbType.VarChar, 200))
            sqlCmd.Parameters.Add(New SqlParameter("@LAST_UPDATED_BY", SqlDbType.VarChar, 25))
            sqlCmd.Parameters.Add(New SqlParameter("@ISEMPTY", SqlDbType.VarChar, 1))
            sqlCmd.Parameters.Add(New SqlParameter("@VEHICLE_PLATE", SqlDbType.VarChar, 25))
            sqlCmd.Parameters.Add(New SqlParameter("@VEHICLE_DRIVER", SqlDbType.VarChar, 200))
            sqlCmd.Parameters.Add(New SqlParameter("@VEHICLE_ID", SqlDbType.VarChar, 25))
            sqlCmd.Parameters.Add(New SqlParameter("@DRIVER_ID", SqlDbType.VarChar, 50))
            sqlCmd.Parameters.Add(New SqlParameter("@AUTORIZED_BY", SqlDbType.VarChar, 250))
            sqlCmd.Parameters.Add(New SqlParameter("@HANDLER", SqlDbType.VarChar, 250))
            sqlCmd.Parameters.Add(New SqlParameter("@CARRIER", SqlDbType.VarChar, 250))
            sqlCmd.Parameters.Add(New SqlParameter("@TXT", SqlDbType.VarChar, 4000))
            sqlCmd.Parameters.Add(New SqlParameter("@LOADUNLOAD", SqlDbType.VarChar, 1))
            sqlCmd.Parameters.Add(New SqlParameter("@LOADWITH", SqlDbType.VarChar, 4000))
            sqlCmd.Parameters.Add(New SqlParameter("@AUDIT_ID", SqlDbType.Int))
            sqlCmd.Parameters.Add(New SqlParameter("@PRESULT", SqlDbType.VarChar, 4000)).Direction = ParameterDirection.Output
            sqlCmd.Parameters.Add(New SqlParameter("@PASS_ID", SqlDbType.Int)).Direction = ParameterDirection.InputOutput

            sqlCmd.Parameters("@CLIENT_CODE").Value = pCLIENT_CODE
            sqlCmd.Parameters("@CLIENT_NAME").Value = pCLIENT_NAME
            sqlCmd.Parameters("@LAST_UPDATED_BY").Value = pLAST_UPDATED_BY
            sqlCmd.Parameters("@ISEMPTY").Value = pISEMPTY
            sqlCmd.Parameters("@VEHICLE_PLATE").Value = pVEHICLE_PLATE
            sqlCmd.Parameters("@VEHICLE_DRIVER").Value = pVEHICLE_DRIVER
            sqlCmd.Parameters("@VEHICLE_ID").Value = pVEHICLE_ID
            sqlCmd.Parameters("@DRIVER_ID").Value = pDRIVER_ID
            sqlCmd.Parameters("@AUTORIZED_BY").Value = pAUTORIZED_BY
            sqlCmd.Parameters("@HANDLER").Value = pHANDLER
            sqlCmd.Parameters("@CARRIER").Value = pCARRIER
            sqlCmd.Parameters("@TXT").Value = pTXT
            sqlCmd.Parameters("@LOADUNLOAD").Value = pLOADUNLOAD
            sqlCmd.Parameters("@LOADWITH").Value = pLOADWITH
            sqlCmd.Parameters("@AUDIT_ID").Value = 0
            If pPASSID > 0 Then
                sqlCmd.Parameters("@PASS_ID").Value = pPASSID
            End If

            'ejecutamos el procedure y validamos la respuesta
            If sqldb_conexion.State = ConnectionState.Closed Then sqldb_conexion.Open()
            sqlCmd.ExecuteNonQuery()

            pResult = sqlCmd.Parameters("@PRESULT").Value


            If pResult = "OK" Then
                pPASSID = sqlCmd.Parameters("@PASS_ID").Value
                Return True
            Else

                pPASSID = 0
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

    <WebMethod(Description:="Crea pase de salida")>
    Public Function set_pass_detail(ByVal pPASSID As Integer, ByVal pAUDIT_ID As Integer, ByVal pLAST_UPDATED_BY As String,
                                   ByVal pEnvironmentName As String, ByRef pResult As String) As Boolean
        Dim sqldb_conexion As SqlConnection = Nothing
        Dim sqlCmd As SqlCommand

        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)

            sqlCmd = New SqlCommand("" + DefaultSchema + "[OP_WMS_SP_PASS_SET_DETAIL]", sqldb_conexion)
            sqlCmd.CommandType = CommandType.StoredProcedure

            'creamos todos los parametros del sp
            sqlCmd.Parameters.Add(New SqlParameter("@PASS_ID", SqlDbType.Int, 25)).Direction = ParameterDirection.Input
            sqlCmd.Parameters.Add(New SqlParameter("@AUDIT_ID", SqlDbType.Int))
            sqlCmd.Parameters.Add(New SqlParameter("@LAST_UPDATED_BY", SqlDbType.VarChar, 25)).Direction = ParameterDirection.Input
            sqlCmd.Parameters.Add(New SqlParameter("@PRESULT", SqlDbType.VarChar, 4000)).Direction = ParameterDirection.Output

            sqlCmd.Parameters("@PASS_ID").Value = pPASSID
            sqlCmd.Parameters("@AUDIT_ID").Value = pAUDIT_ID
            sqlCmd.Parameters("@LAST_UPDATED_BY").Value = pLAST_UPDATED_BY

            'ejecutamos el procedure y validamos la respuesta
            If sqldb_conexion.State = ConnectionState.Closed Then sqldb_conexion.Open()
            sqlCmd.ExecuteNonQuery()

            pResult = sqlCmd.Parameters("@PRESULT").Value

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

    <WebMethod(Description:="Crea pase de salida por poliza")>
    Public Function set_pass_detail_by_poliza(ByVal pPASSID As Integer, ByVal pCodePoliza As String, ByVal pLAST_UPDATED_BY As String,
                                   ByVal pEnvironmentName As String, ByRef pResult As String) As Boolean
        Dim sqldb_conexion As SqlConnection = Nothing
        Dim sqlCmd As SqlCommand

        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)

            sqlCmd = New SqlCommand("" + DefaultSchema + "[OP_WMS_SP_PASS_SET_DETAIL_BY_POLIZA]", sqldb_conexion)
            sqlCmd.CommandType = CommandType.StoredProcedure

            'creamos todos los parametros del sp
            sqlCmd.Parameters.Add(New SqlParameter("@PASS_ID", SqlDbType.Int, 25)).Direction = ParameterDirection.Input
            sqlCmd.Parameters.Add(New SqlParameter("@CODE_POLIZA", SqlDbType.VarChar, 15))
            sqlCmd.Parameters.Add(New SqlParameter("@LAST_UPDATED_BY", SqlDbType.VarChar, 25)).Direction = ParameterDirection.Input
            sqlCmd.Parameters.Add(New SqlParameter("@PRESULT", SqlDbType.VarChar, 4000)).Direction = ParameterDirection.Output

            sqlCmd.Parameters("@PASS_ID").Value = pPASSID
            sqlCmd.Parameters("@CODE_POLIZA").Value = pCodePoliza
            sqlCmd.Parameters("@LAST_UPDATED_BY").Value = pLAST_UPDATED_BY

            'ejecutamos el procedure y validamos la respuesta
            If sqldb_conexion.State = ConnectionState.Closed Then sqldb_conexion.Open()
            sqlCmd.ExecuteNonQuery()

            pResult = sqlCmd.Parameters("@PRESULT").Value

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

    <WebMethod(Description:="Elimina detalle de auditorias por pase de salida")>
    Public Function delete_pass_detail(ByVal pPASSID As Integer, ByVal pEnvironmentName As String, ByRef pResult As String) As Boolean
        Dim sqldb_conexion As SqlConnection = Nothing
        Dim sqlCmd As SqlCommand

        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)

            Dim strSql As New StringBuilder
            strSql.Append(String.Format(" DELETE FROM  " + DefaultSchema + "OP_WMS3PL_AUDITS_X_PASS WHERE PASS_ID = {0};", pPASSID))
            strSql.Append(String.Format(" DELETE FROM  " + DefaultSchema + "OP_WMS3PL_PASSES WHERE PASS_ID = {0};", pPASSID))
            strSql.Append(" ")

            sqlCmd = New SqlCommand(strSql.ToString(), sqldb_conexion)
            sqlCmd.CommandType = CommandType.Text

            If sqldb_conexion.State = ConnectionState.Closed Then sqldb_conexion.Open()
            sqlCmd.ExecuteNonQuery()

            pResult = "OK"
            Return True
        Catch ex As Exception
            pResult = ex.Message
            pResult = "ERROR:" + ex.Message
            Return False

        Finally
            If sqldb_conexion.State = ConnectionState.Open Then sqldb_conexion.Close()

        End Try

    End Function


    <WebMethod(Description:="asocia poliza a pase de salida")>
    Public Function set_poliza_pass(ByVal pCLIENT_CODE As String, ByVal pCLIENT_NAME As String, ByVal pLAST_UPDATED_BY As String, ByVal pCODIGO_POLIZA As String, ByVal pNUMERO_ORDEN As String,
                                   ByVal pNUMERO_DUA As String, ByVal pDOC_ID As Integer, ByVal pPASSID As Integer,
                                   ByVal pEnvironmentName As String, ByRef pResult As String) As Boolean
        Dim sqldb_conexion As SqlConnection
        Dim sqlCmd As SqlCommand

        sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Try
            sqlCmd = New SqlCommand(DefaultSchema & "sp_OP_WMS3PL_POLIZAS_X_PASSES", sqldb_conexion)
            sqlCmd.CommandType = CommandType.StoredProcedure

            'creamos todos los parametros del sp
            sqlCmd.Parameters.Add(New SqlParameter("@CLIENT_CODE", SqlDbType.VarChar, 25)).Direction = ParameterDirection.Input
            sqlCmd.Parameters.Add(New SqlParameter("@CLIENT_NAME", SqlDbType.VarChar, 250))
            sqlCmd.Parameters.Add(New SqlParameter("@LAST_UPDATED_BY", SqlDbType.VarChar, 25))
            sqlCmd.Parameters.Add(New SqlParameter("@CODIGO_POLIZA", SqlDbType.VarChar, 15))
            sqlCmd.Parameters.Add(New SqlParameter("@NUMERO_ORDEN", SqlDbType.VarChar, 50))
            sqlCmd.Parameters.Add(New SqlParameter("@NUMERO_DUA", SqlDbType.VarChar, 50))
            sqlCmd.Parameters.Add(New SqlParameter("@DOC_ID", SqlDbType.Int))
            sqlCmd.Parameters.Add(New SqlParameter("@PASS_ID", SqlDbType.Int))
            sqlCmd.Parameters.Add(New SqlParameter("@PRESULT", SqlDbType.VarChar, 4000)).Direction = ParameterDirection.Output

            sqlCmd.Parameters("@CLIENT_CODE").Value = pCLIENT_CODE
            sqlCmd.Parameters("@CLIENT_NAME").Value = pCLIENT_NAME
            sqlCmd.Parameters("@LAST_UPDATED_BY").Value = pLAST_UPDATED_BY
            sqlCmd.Parameters("@CODIGO_POLIZA").Value = pCODIGO_POLIZA
            sqlCmd.Parameters("@NUMERO_ORDEN").Value = pNUMERO_ORDEN
            sqlCmd.Parameters("@NUMERO_DUA").Value = pNUMERO_DUA
            sqlCmd.Parameters("@DOC_ID").Value = pDOC_ID
            sqlCmd.Parameters("@PASS_ID").Value = pPASSID

            'ejecutamos el procedure y validamos la respuesta
            If sqldb_conexion.State = ConnectionState.Closed Then sqldb_conexion.Open()
            sqlCmd.ExecuteNonQuery()

            pResult = sqlCmd.Parameters("@PRESULT").Value


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

    <WebMethod(Description:="Devuelve pases de salida")>
    Public Function get_all_passes(ByVal pWhere As String, ByVal pEnvironmentName As String, ByRef pResult As String) As DataSet
        Dim XSQL As String = "SELECT * FROM " & DefaultSchema & "OP_WMS3PL_PASSES " & pWhere
        Dim sqldb_conexion As SqlConnection

        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()
            miscDA.Fill(miscDS, "OP_WMS3PL_PASSES")
            pResult = "OK"
            Return miscDS
        Catch ex As Exception
            pResult = ex.Message
            pResult = "ERROR," + ex.Message
            Return Nothing

        End Try

    End Function

    <WebMethod(Description:="Devuelve polizas de passes de salida")>
    Public Function get_all_poliza_passes(ByVal pWhere As String, ByVal pEnvironmentName As String, ByRef pResult As String) As DataSet
        Dim XSQL As String = "SELECT * FROM " & DefaultSchema & "OP_WMS3PL_POLIZAS_X_PASSES " & pWhere
        Dim sqldb_conexion As SqlConnection

        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()
            miscDA.Fill(miscDS, "OP_WMS3PL_POLIZAS_X_PASSES")
            pResult = "OK"
            Return miscDS
        Catch ex As Exception
            pResult = ex.Message
            pResult = "ERROR," + ex.Message
            Return Nothing

        End Try

    End Function

    <WebMethod(Description:="Devuelve parametros de passes de salida")>
    Public Function get_passes_params(ByVal pFIELD As String, ByVal pEnvironmentName As String, ByRef pResult As String) As DataSet
        Dim XSQL As String = "SELECT DISTINCT " & pFIELD & " FROM " & DefaultSchema & "OP_WMS3PL_PASSES "
        Dim sqldb_conexion As SqlConnection

        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()
            miscDA.Fill(miscDS, "OP_WMS3PL_PASSES")
            pResult = "OK"
            Return miscDS
        Catch ex As Exception
            pResult = ex.Message
            pResult = "ERROR," + ex.Message
            Return Nothing

        End Try

    End Function

    <WebMethod(Description:="Devuelve logins activos")>
    Public Function get_all_active_logins(ByVal pEnvironmentName As String, ByRef pResult As String) As DataSet
        Dim XSQL As String = "SELECT * FROM " & DefaultSchema & "OP_WMS_LOGINS WHERE LOGIN_STATUS = 'ACTIVO' "
        Dim sqldb_conexion As SqlConnection

        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()
            miscDA.Fill(miscDS, "OP_WMS_LOGINS")
            pResult = "OK"
            Return miscDS
        Catch ex As Exception
            pResult = ex.Message
            pResult = "ERROR," + ex.Message
            Return Nothing

        End Try

    End Function

    <WebMethod(Description:="rectifica poliza")>
    Public Function set_rectify(ByVal pCODIGO_POLIZA As String, ByVal pDOC_ID As Integer, ByVal pCODIGO_POLIZA_RECTIFICADA As String, ByVal pDOC_ID_RECTIFICADA As Integer,
                                ByVal pLAST_UPDATED_BY As String, ByVal pEnvironmentName As String, ByRef pResult As String) As Boolean
        Dim sqldb_conexion As SqlConnection
        Dim sqlCmd As SqlCommand

        sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Try
            sqlCmd = New SqlCommand(DefaultSchema & "sp_RECTIFY", sqldb_conexion)
            sqlCmd.CommandType = CommandType.StoredProcedure

            'creamos todos los parametros del sp
            sqlCmd.Parameters.Add(New SqlParameter("@CODIGO_POLIZA", SqlDbType.VarChar, 15)).Direction = ParameterDirection.Input
            sqlCmd.Parameters.Add(New SqlParameter("@DOC_ID", SqlDbType.Int))
            sqlCmd.Parameters.Add(New SqlParameter("@RELATED_POLIZA", SqlDbType.VarChar, 15))
            sqlCmd.Parameters.Add(New SqlParameter("@RELATED_DOC_ID", SqlDbType.Int))
            sqlCmd.Parameters.Add(New SqlParameter("@LAST_UPDATED_BY", SqlDbType.VarChar, 50))
            sqlCmd.Parameters.Add(New SqlParameter("@PRESULT", SqlDbType.VarChar, 4000)).Direction = ParameterDirection.Output

            sqlCmd.Parameters("@CODIGO_POLIZA").Value = pCODIGO_POLIZA
            sqlCmd.Parameters("@DOC_ID").Value = pDOC_ID
            sqlCmd.Parameters("@RELATED_POLIZA").Value = pCODIGO_POLIZA_RECTIFICADA
            sqlCmd.Parameters("@RELATED_DOC_ID").Value = pDOC_ID_RECTIFICADA
            sqlCmd.Parameters("@LAST_UPDATED_BY").Value = pLAST_UPDATED_BY

            'ejecutamos el procedure y validamos la respuesta
            If sqldb_conexion.State = ConnectionState.Closed Then sqldb_conexion.Open()
            sqlCmd.ExecuteNonQuery()

            pResult = sqlCmd.Parameters("@PRESULT").Value

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

    <WebMethod(Description:="Devuelve inventario general por bodega")>
    Public Function GetInventoryGeneralByWarehouse(codeClient As String, codeWarehouse As String, isDiscretional As Boolean, pEnvironmentName As String, ByRef pResult As String) As DataTable
        Dim sqldbConexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()
        Try
            pResult = "OK"
            Dim cmd As New SqlCommand
            Dim reader As SqlDataReader
            Dim dt = New DataTable("GetInventoryGeneralByWarehouse")
            cmd.CommandText = String.Format("{0}OP_WMS_SP_GET_INVENTORY_BY_WAREHOUSE", DefaultSchema)

            cmd.Parameters.Add("@CODE_CLIENT", SqlDbType.VarChar).Value = codeClient
            cmd.Parameters.Add("@CODE_WAREHOUSE", SqlDbType.VarChar).Value = codeWarehouse
            cmd.Parameters.Add("@IS_DISCRETIONAL", SqlDbType.Int).Value = isDiscretional


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

    <WebMethod(Description:="Devuelve las bodegas relacionadas con los operadores")>
    Public Function GetWarehouseByRelatedUsers(login As String, operators As String, pEnvironmentName As String, ByRef pResult As String) As DataTable
        Dim sqldbConexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()
        Try
            Dim cmd As New SqlCommand
            Dim reader As SqlDataReader
            Dim dt = New DataTable("GetWarehouseByRelatedUsers")
            cmd.CommandText = String.Format("{0}OP_WMS_SP_GET_WAREHOUSE_BY_RELATED_USERS", DefaultSchema)

            cmd.Parameters.Add("@LOGIN", SqlDbType.VarChar).Value = login
            cmd.Parameters.Add("@OPERATORS", SqlDbType.VarChar).Value = operators


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

    <WebMethod(Description:="Devuelve inventario general")>
    Public Function get_general_inventory_by_sku(ByVal materialId As String, ByVal currentWarehouse As String, ByVal pEnvironmentName As String, ByRef pResult As String) As DataTable
        Dim cmd As New SqlCommand

        Dim sqldb_conexion As SqlConnection
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable("GetInventoryFiscalByLicence")
        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)

            cmd.CommandText = String.Format("{0}OP_WMS_SP_GET_INVENTORY_BY_SKU", DefaultSchema)
            cmd.Parameters.Add("@MATERIAL_ID", SqlDbType.VarChar).Value = materialId
            cmd.Parameters.Add("@CURRENT_WAREHOUSE", SqlDbType.VarChar).Value = currentWarehouse

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldb_conexion
            If sqldb_conexion.State = ConnectionState.Closed Then sqldb_conexion.Open()
            reader = cmd.ExecuteReader()
            dt.Load(reader)
            sqldb_conexion.Close()

            pResult = "OK"
            If sqldb_conexion.State = ConnectionState.Open Then sqldb_conexion.Close()
            Return dt
        Catch ex As Exception

            pResult = "ERROR," + ex.Message
            Return Nothing

        End Try

    End Function

    <WebMethod(Description:="Devuelve inventario para picking general")>
    Public Function get_general_picking_available(ByVal pWhere As String, ByVal pEnvironmentName As String, ByRef pResult As String) As DataSet
        Dim XSQL As String = "SELECT * FROM " & DefaultSchema & "OP_WMS_VIEW_PICKING_AVAILABLE_GENERAL " & pWhere
        Dim sqldb_conexion As SqlConnection

        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()
            miscDA.Fill(miscDS, "OP_WMS_VIEW_PICKING_AVAILABLE_GENERAL")
            pResult = "OK"
            Return miscDS
        Catch ex As Exception

            pResult = "ERROR," + ex.Message
            Return Nothing

        End Try

    End Function

    <WebMethod(Description:="Egreso general")>
    Public Function set_General_Egreso(ByVal pTASK_OWNER As String, ByVal pTASK_ASSIGNEDTO As String, ByVal pQUANTITY_ASSIGNED As Double, ByVal pCODIGO_POLIZA_TARGET As String,
                                ByVal pMATERIAL_ID As String, ByVal pBARCODE_ID As String, ByVal pALTERNATE_BARCODE As String, ByVal pMATERIAL_NAME As String, ByVal pCLIENT_OWNER As String,
                                ByVal pCLIENT_NAME As String, ByVal pEnvironmentName As String, ByRef pResult As String, ByRef pWPI As Integer,
                                       ByVal Warehouse As String, ByVal EnviarErp As Integer, ByVal ProjectId As String, ByVal Status As String,byval pLocationSpotTarget As string) As Boolean
        Dim sqldb_conexion As SqlConnection
        Dim sqlCmd As SqlCommand

        sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Try
            sqlCmd = New SqlCommand(DefaultSchema & "OP_WMS_SP_INSERT_TASKS_GENERAL", sqldb_conexion)
            sqlCmd.CommandType = CommandType.StoredProcedure

            'creamos todos los parametros del sp
            sqlCmd.Parameters.Add(New SqlParameter("@TASK_OWNER", SqlDbType.VarChar, 25)).Direction = ParameterDirection.Input
            sqlCmd.Parameters.Add(New SqlParameter("@TASK_ASSIGNEDTO", SqlDbType.VarChar, 25))
            sqlCmd.Parameters.Add(New SqlParameter("@QUANTITY_ASSIGNED", SqlDbType.Decimal))
            sqlCmd.Parameters.Add(New SqlParameter("@CODIGO_POLIZA_TARGET", SqlDbType.VarChar, 25))
            sqlCmd.Parameters.Add(New SqlParameter("@MATERIAL_ID", SqlDbType.VarChar, 25))
            sqlCmd.Parameters.Add(New SqlParameter("@BARCODE_ID", SqlDbType.VarChar, 50))
            sqlCmd.Parameters.Add(New SqlParameter("@ALTERNATE_BARCODE", SqlDbType.VarChar, 50))
            sqlCmd.Parameters.Add(New SqlParameter("@MATERIAL_NAME", SqlDbType.VarChar, 200))
            sqlCmd.Parameters.Add(New SqlParameter("@CLIENT_OWNER", SqlDbType.VarChar, 25))
            sqlCmd.Parameters.Add(New SqlParameter("@CLIENT_NAME", SqlDbType.VarChar, 150))
            sqlCmd.Parameters.Add(New SqlParameter("@PRESULT", SqlDbType.VarChar, 4000)).Direction = ParameterDirection.Output
            sqlCmd.Parameters.Add(New SqlParameter("@WAVE_PICKING_ID", SqlDbType.Int)).Direction = ParameterDirection.InputOutput
            sqlCmd.Parameters.Add(New SqlParameter("@WAREHOUSE", SqlDbType.VarChar, 50))
            sqlCmd.Parameters.Add(New SqlParameter("@SEND_ERP", SqlDbType.Int))
            sqlCmd.Parameters.Add(New SqlParameter("@PROJECT_ID", SqlDbType.VarChar, 36))
            sqlCmd.Parameters.Add(New SqlParameter("@STATUS_CODE", SqlDbType.VarChar, 100))
            sqlCmd.Parameters.Add(New SqlParameter("@LOCATION_SPOT_TARGET", SqlDbType.VarChar, 50))

            sqlCmd.Parameters("@TASK_OWNER").Value = pTASK_OWNER
            sqlCmd.Parameters("@TASK_ASSIGNEDTO").Value = pTASK_ASSIGNEDTO
            sqlCmd.Parameters("@QUANTITY_ASSIGNED").Value = pQUANTITY_ASSIGNED
            sqlCmd.Parameters("@CODIGO_POLIZA_TARGET").Value = pCODIGO_POLIZA_TARGET
            sqlCmd.Parameters("@MATERIAL_ID").Value = pMATERIAL_ID
            sqlCmd.Parameters("@BARCODE_ID").Value = pBARCODE_ID
            sqlCmd.Parameters("@ALTERNATE_BARCODE").Value = pALTERNATE_BARCODE
            sqlCmd.Parameters("@MATERIAL_NAME").Value = pMATERIAL_NAME
            sqlCmd.Parameters("@CLIENT_OWNER").Value = pCLIENT_OWNER
            sqlCmd.Parameters("@CLIENT_NAME").Value = pCLIENT_NAME
            sqlCmd.Parameters("@WAVE_PICKING_ID").Value = pWPI
            sqlCmd.Parameters("@WAREHOUSE").Value = Warehouse
            sqlCmd.Parameters("@SEND_ERP").Value = EnviarErp
            sqlCmd.Parameters("@PROJECT_ID").Value = ProjectId
            sqlCmd.Parameters("@STATUS_CODE").Value = Status
            sqlCmd.Parameters("@LOCATION_SPOT_TARGET").Value = pLocationSpotTarget

            'ejecutamos el procedure y validamos la respuesta
            If sqldb_conexion.State = ConnectionState.Closed Then sqldb_conexion.Open()
            sqlCmd.ExecuteNonQuery()

            pResult = sqlCmd.Parameters("@PRESULT").Value

            If pResult = "OK" Then
                pWPI = sqlCmd.Parameters("@WAVE_PICKING_ID").Value
                Return True
            Else
                LogSQLErrors("GENERA_TAREA_GENERAL", pMATERIAL_ID + " " + pMATERIAL_NAME + " " + pCLIENT_NAME, " ")
                Return False
            End If

        Catch ex As Exception

            pResult = "ERROR:" + ex.Message
            Return False

        Finally
            If sqldb_conexion.State = ConnectionState.Open Then sqldb_conexion.Close()

        End Try

    End Function


    <WebMethod(Description:="Egreso general discrecional")>
    Public Function set_General_Egreso_DISCRETIONARY(ByVal pTASK_OWNER As String, ByVal pTASK_ASSIGNEDTO As String, ByVal pQUANTITY_ASSIGNED As Double, ByVal pCODIGO_POLIZA_TARGET As String,
                                ByVal pMATERIAL_ID As String, ByVal pBARCODE_ID As String, ByVal pALTERNATE_BARCODE As String, ByVal pMATERIAL_NAME As String, ByVal pCLIENT_OWNER As String,
                                ByVal pCLIENT_NAME As String, ByVal pEnvironmentName As String, ByRef pResult As String, ByRef pWPI As Integer,
                                ByVal pLicence As Integer, ByVal pTypeDiscretionary As String, ByVal pSerialNumber As String, tone As String, caliber As String, ByVal pProject As String, ByVal pLocationSpotTarget As String) As Boolean
        Dim sqldb_conexion As SqlConnection
        Dim sqlCmd As SqlCommand

        sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Try
            sqlCmd = New SqlCommand(DefaultSchema & "OP_WMS_SP_INSERT_TASKS_GENERAL_DISCRETIONARY", sqldb_conexion)
            sqlCmd.CommandType = CommandType.StoredProcedure

            'creamos todos los parametros del sp
            sqlCmd.Parameters.Add(New SqlParameter("@TASK_OWNER", SqlDbType.VarChar, 25)).Direction = ParameterDirection.Input
            sqlCmd.Parameters.Add(New SqlParameter("@TASK_ASSIGNEDTO", SqlDbType.VarChar, 25))
            sqlCmd.Parameters.Add(New SqlParameter("@QUANTITY_ASSIGNED", SqlDbType.Decimal))
            sqlCmd.Parameters.Add(New SqlParameter("@CODIGO_POLIZA_TARGET", SqlDbType.VarChar, 25))
            sqlCmd.Parameters.Add(New SqlParameter("@MATERIAL_ID", SqlDbType.VarChar, 25))
            sqlCmd.Parameters.Add(New SqlParameter("@BARCODE_ID", SqlDbType.VarChar, 50))
            sqlCmd.Parameters.Add(New SqlParameter("@ALTERNATE_BARCODE", SqlDbType.VarChar, 50))
            sqlCmd.Parameters.Add(New SqlParameter("@MATERIAL_NAME", SqlDbType.VarChar, 200))
            sqlCmd.Parameters.Add(New SqlParameter("@CLIENT_OWNER", SqlDbType.VarChar, 25))
            sqlCmd.Parameters.Add(New SqlParameter("@CLIENT_NAME", SqlDbType.VarChar, 150))
            sqlCmd.Parameters.Add(New SqlParameter("@PRESULT", SqlDbType.VarChar, 4000)).Direction = ParameterDirection.Output
            sqlCmd.Parameters.Add(New SqlParameter("@WAVE_PICKING_ID", SqlDbType.Int)).Direction = ParameterDirection.InputOutput

            sqlCmd.Parameters.Add(New SqlParameter("@LICENSE_ID", SqlDbType.Int))
            sqlCmd.Parameters.Add(New SqlParameter("@TypeDiscretionary", SqlDbType.VarChar, 100))
            sqlCmd.Parameters.Add(New SqlParameter("@PROJECT_ID", SqlDbType.VarChar, 36))
            sqlCmd.Parameters.Add(New SqlParameter("@LOCATION_SPOT_TARGET", SqlDbType.VarChar, 50))


            sqlCmd.Parameters("@TASK_OWNER").Value = pTASK_OWNER
            sqlCmd.Parameters("@TASK_ASSIGNEDTO").Value = pTASK_ASSIGNEDTO
            sqlCmd.Parameters("@QUANTITY_ASSIGNED").Value = pQUANTITY_ASSIGNED
            sqlCmd.Parameters("@CODIGO_POLIZA_TARGET").Value = pCODIGO_POLIZA_TARGET
            sqlCmd.Parameters("@MATERIAL_ID").Value = pMATERIAL_ID
            sqlCmd.Parameters("@BARCODE_ID").Value = pBARCODE_ID
            sqlCmd.Parameters("@ALTERNATE_BARCODE").Value = pALTERNATE_BARCODE
            sqlCmd.Parameters("@MATERIAL_NAME").Value = pMATERIAL_NAME
            sqlCmd.Parameters("@CLIENT_OWNER").Value = pCLIENT_OWNER
            sqlCmd.Parameters("@CLIENT_NAME").Value = pCLIENT_NAME
            sqlCmd.Parameters("@WAVE_PICKING_ID").Value = pWPI
            sqlCmd.Parameters("@LICENSE_ID").Value = pLicence
            sqlCmd.Parameters("@TypeDiscretionary").Value = pTypeDiscretionary
            sqlCmd.Parameters("@PROJECT_ID").Value = pProject
            sqlCmd.Parameters("@LOCATION_SPOT_TARGET").Value= pLocationSpotTarget

            sqlCmd.Parameters.Add(New SqlParameter("@SERIAL_NUMBER", SqlDbType.VarChar, 50)).Value = pSerialNumber

            If Not String.IsNullOrEmpty(tone) Then
                sqlCmd.Parameters.Add(New SqlParameter("@TONE", SqlDbType.VarChar)).Value = tone
            End If

            If Not String.IsNullOrEmpty(caliber) Then
                sqlCmd.Parameters.Add(New SqlParameter("@CALIBER", SqlDbType.VarChar)).Value = caliber
            End If

            'ejecutamos el procedure y validamos la respuesta
            If sqldb_conexion.State = ConnectionState.Closed Then sqldb_conexion.Open()
            sqlCmd.ExecuteNonQuery()

            pResult = sqlCmd.Parameters("@PRESULT").Value

            If pResult = "OK" Then
                pWPI = sqlCmd.Parameters("@WAVE_PICKING_ID").Value
                Return True
            Else
                LogSQLErrors("GENERA_TAREA_GENERAL", pMATERIAL_ID + " " + pMATERIAL_NAME + " " + pCLIENT_NAME, " ")
                Return False
            End If

        Catch ex As Exception

            pResult = "ERROR:" + ex.Message
            Return False

        Finally
            If sqldb_conexion.State = ConnectionState.Open Then sqldb_conexion.Close()

        End Try

    End Function

    <WebMethod(Description:="Devuelve el detalle de lineas de poliza")>
    Public Function get_all_poliza_kardex(ByVal pTABLA As String, ByVal pEnvironmentName As String, ByRef pResult As String) As DataTable
        Dim connection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim command As SqlCommand
        connection.Open()
        Try

            command = New SqlCommand(DefaultSchema & "OP_WMS_GET_POLIZA_FISCAL_ENTRY", connection)
            command.CommandType = CommandType.StoredProcedure

            'creamos todos los parametros del sp
            command.Parameters.Add(New SqlParameter("@TYPE", SqlDbType.VarChar, 25))
            command.Parameters("@TYPE").Value = pTABLA

            Dim dataAdapter As SqlDataAdapter = New SqlDataAdapter(command)
            Dim dataSet As DataSet = New DataSet()

            'ejecutamos el procedure y validamos la respuesta
            dataAdapter.Fill(dataSet, "POLIZA_ENTRY")

            If dataSet Is Nothing Or dataSet.Tables.Count <= 0 Then
                pResult = "No se encontró información"
                Return Nothing
            End If

            pResult = "OK"
            Return dataSet.Tables(0)
        Catch ex As Exception
            pResult = "ERROR:" + ex.Message
            Return Nothing
        Finally
            connection.Close()
            connection.Dispose()
            connection = Nothing
        End Try
    End Function

    <WebMethod(Description:="Devuelve los productos en transacciones de una poliza")>
    Public Function get_skus_tran_byPoliza(ByVal pPOLIZA As String, ByVal pEnvironmentName As String, ByRef pResult As String) As DataSet
        'Dim XSQL As String = "SELECT DISTINCT MATERIAL_BARCODE, MATERIAL_CODE, MATERIAL_DESCRIPTION, MATERIAL_COST, QUANTITY_UNITS, CLIENT_NAME "
        'XSQL = XSQL & " FROM " & DefaultSchema & "OP_WMS_TRANS WHERE CODIGO_POLIZA = '" & pPOLIZA & "' AND TRANS_TYPE IN ('INICIALIZACION_GENERAL','INGRESO_GENERAL') "

        Dim XSQL As String = "SELECT MATERIAL_BARCODE, MATERIAL_CODE, MATERIAL_DESCRIPTION, MATERIAL_COST, SUM(QUANTITY_UNITS) AS QUANTITY_UNITS, CLIENT_NAME "
        XSQL = XSQL & " FROM " & DefaultSchema & "OP_WMS_TRANS WHERE CODIGO_POLIZA = '" & pPOLIZA & "' AND TRANS_TYPE IN ('INICIALIZACION_GENERAL','INGRESO_GENERAL') AND [STATUS] = 'PROCESSED' "
        XSQL = XSQL & " GROUP BY MATERIAL_BARCODE, MATERIAL_CODE, MATERIAL_DESCRIPTION, MATERIAL_COST, CLIENT_NAME "

        Dim sqldb_conexion As SqlConnection

        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()
            miscDA.Fill(miscDS, "OP_WMS_TRANS")
            pResult = "OK"
            Return miscDS
        Catch ex As Exception

            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
    End Function

    <WebMethod(Description:="borra todo el detalle de la poliza")>
    Public Function del_ALL_POLIZA_LINES(ByVal pDOC_ID As Integer, ByVal pEnvironmentName As String, ByRef pResult As String) As Boolean
        Dim XSQL As String

        Try
            XSQL = "DELETE FROM " & DefaultSchema & "OP_WMS_POLIZA_DETAIL WHERE DOC_ID = " & pDOC_ID.ToString
            ExecuteSqlTransaction(AppSettings(pEnvironmentName).ToString, XSQL, pResult)

            If pResult = "OK" Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            pResult = ex.Message

            Return False
        End Try
    End Function

    <WebMethod(Description:="Devuelve las bodegas")>
    Public Function get_all_warehouses(ByVal pEnvironmentName As String, ByRef pResult As String) As DataSet
        Dim XSQL As String = "select DISTINCT CURRENT_WAREHOUSE WAREHOUSE_ID   "
        XSQL = XSQL & "  from " & DefaultSchema & "OP_WMS_LICENSES"
        XSQL = XSQL & " WHERE CURRENT_WAREHOUSE IS NOT NULL"

        Dim sqldb_conexion As SqlConnection

        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()
            miscDA.Fill(miscDS, "OP_WMS_WAREHOUSES")

            pResult = "OK"
            Return miscDS
        Catch ex As Exception

            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
    End Function

    <WebMethod(Description:="Devuelve el pase de salida para imprimir")>
    Public Function print_pass(ByVal pPASS As Integer, ByVal pAUDIT As Integer, ByVal pEnvironmentName As String, ByRef pResult As String) As DataSet

        Dim XSQL = "SELECT * FROM " & DefaultSchema & "[OP_WMS_FUNC_GET_PASS_DATA]('" & pPASS & "')"

        Dim sqldb_conexion As SqlConnection

        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)

            Dim miscDS As DataSet = New DataSet()
            Dim dtSalida As New DataTable
            Dim dtRet As New DataTable

            miscDA.Fill(miscDS, "SALIDA_VEHICULO")

            Dim XSQL1 As String = "SELECT * FROM  " + DefaultSchema + "OP_WMS_FUNC_GET_PASS_DETAIL(" & pPASS & ")"

            Dim miscDA2 As SqlDataAdapter = New SqlDataAdapter(XSQL1, sqldb_conexion)
            miscDA2.Fill(miscDS, "RETIRO")

            pResult = "OK"

            Return miscDS
        Catch ex As Exception

            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
    End Function

    <WebMethod(Description:="Devuelve el pase de salida para imprimir")>
    Public Function print_pass_by_poliza(ByVal pPASS As Integer, ByVal pAUDIT As Integer, ByVal pEnvironmentName As String, ByRef pResult As String) As DataSet

        Dim XSQL = "SELECT * FROM " & DefaultSchema & "[OP_WMS_FUNC_GET_PASS_DATA_BY_POLIZA]('" & pPASS & "')"

        Dim sqldb_conexion As SqlConnection

        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)

            Dim miscDS As DataSet = New DataSet()
            Dim dtSalida As New DataTable
            Dim dtRet As New DataTable

            miscDA.Fill(miscDS, "SALIDA_VEHICULO")

            Dim XSQL1 As String = "SELECT * FROM  " + DefaultSchema + "OP_WMS_FUNC_GET_PASS_DETAIL_BY_POLIZA(" & pPASS & ")"

            Dim miscDA2 As SqlDataAdapter = New SqlDataAdapter(XSQL1, sqldb_conexion)
            miscDA2.Fill(miscDS, "RETIRO")

            pResult = "OK"

            Return miscDS
        Catch ex As Exception

            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
    End Function

    <WebMethod(Description:="delete pase de salida")>
    Public Function delete_pass_audits_detail(ByVal pPASSID As Integer, ByVal pAUDIT_ID As Integer,
                                        ByVal pEnvironmentName As String, ByRef pResult As String) As Boolean
        Dim sqldb_conexion As SqlConnection = Nothing
        Dim sqlCmd As SqlCommand

        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)

            sqlCmd = New SqlCommand("" + DefaultSchema + "[OP_WMS_SP_DELETE_PASS_DETAIL]", sqldb_conexion)
            sqlCmd.CommandType = CommandType.StoredProcedure

            'creamos todos los parametros del sp
            sqlCmd.Parameters.Add(New SqlParameter("@PASS_ID", SqlDbType.Int, 25)).Direction = ParameterDirection.Input
            sqlCmd.Parameters.Add(New SqlParameter("@AUDIT_ID", SqlDbType.Int))
            sqlCmd.Parameters.Add(New SqlParameter("@PRESULT", SqlDbType.VarChar, 4000)).Direction = ParameterDirection.Output

            sqlCmd.Parameters("@PASS_ID").Value = pPASSID
            sqlCmd.Parameters("@AUDIT_ID").Value = pAUDIT_ID

            'ejecutamos el procedure y validamos la respuesta
            If sqldb_conexion.State = ConnectionState.Closed Then sqldb_conexion.Open()
            sqlCmd.ExecuteNonQuery()

            pResult = sqlCmd.Parameters("@PRESULT").Value

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

    <WebMethod(Description:="delete pase de salida por poliza")>
    Public Function delete_pass_detail_by_poliza(ByVal pPASSID As Integer, ByVal pCodigoPoliza As String,
                                        ByVal pEnvironmentName As String, ByRef pResult As String) As Boolean
        Dim sqldb_conexion As SqlConnection = Nothing
        Dim sqlCmd As SqlCommand

        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)

            sqlCmd = New SqlCommand("" + DefaultSchema + "[OP_WMS_SP_DELETE_PASS_DETAIL_BY_POLIZA]", sqldb_conexion)
            sqlCmd.CommandType = CommandType.StoredProcedure

            'creamos todos los parametros del sp
            sqlCmd.Parameters.Add(New SqlParameter("@PASS_ID", SqlDbType.Int, 25)).Direction = ParameterDirection.Input
            sqlCmd.Parameters.Add(New SqlParameter("@CODE_POLIZA", SqlDbType.VarChar, 15))
            sqlCmd.Parameters.Add(New SqlParameter("@PRESULT", SqlDbType.VarChar, 4000)).Direction = ParameterDirection.Output

            sqlCmd.Parameters("@PASS_ID").Value = pPASSID
            sqlCmd.Parameters("@CODE_POLIZA").Value = pCodigoPoliza

            'ejecutamos el procedure y validamos la respuesta
            If sqldb_conexion.State = ConnectionState.Closed Then sqldb_conexion.Open()
            sqlCmd.ExecuteNonQuery()

            pResult = sqlCmd.Parameters("@PRESULT").Value

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

    <WebMethod(Description:="Devuelve las polizas fiscal que se ingresaron ")>
    Public Function GetPolizasIngresoFiscal(ByVal pTipo As String, ByVal pRegimen As String, ByVal pValFechas As Boolean, ByVal pFechaInicio As Date, ByVal pFechaFinal As Date, ByVal pEnvironmentName As String, ByRef pResult As String) As DataTable
        Dim strSql As New StringBuilder(" SELECT *")
        strSql.Append(String.Format(" , CASE (SELECT COUNT(*) FROM {0}OP_WMS3PL_POLIZA_TRANS_MATCH PTM WHERE PTM.CODIGO_POLIZA = VP.CODIGO_POLIZA)", DefaultSchema))
        strSql.Append(" WHEN 0 THEN 'PENDIENTE'")
        strSql.Append(" ELSE 'ASOCIADO' END AS [STATUS]")
        strSql.Append(String.Format(", ISNULL((SELECT TOP 1 COMMENTS FROM {0}OP_WMS3PL_POLIZA_TRANS_MATCH TXN WHERE VP.CODIGO_POLIZA = TXN.CODIGO_POLIZA),'') AS COMMENTS", DefaultSchema))
        strSql.Append(String.Format(" FROM {0}OP_WMS_VIEW_POLIZAS VP", DefaultSchema))
        strSql.Append(String.Format(" WHERE TIPO IN('{0}')", pTipo))
        strSql.Append(String.Format(" AND WAREHOUSE_REGIMEN IN('{0}')", pRegimen))
        If pValFechas Then
            strSql.Append(String.Format(" AND CONVERT(DATE, LAST_UPDATED) BETWEEN CONVERT(DATE, '{0}') AND CONVERT(DATE, '{1}')", pFechaInicio.Date.ToString("yyyy-MM-dd"), pFechaFinal.Date.ToString("yyyy-MM-dd")))
        End If
        strSql.Append(" ORDER BY LAST_UPDATED")

        Dim sqldbConexion As SqlConnection

        Try
            sqldbConexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
            Dim miscDa As SqlDataAdapter = New SqlDataAdapter(strSql.ToString(), sqldbConexion)
            Dim miscDt As DataTable = New DataTable("GetPolizasIngresoFiscal")
            miscDa.Fill(miscDt)
            pResult = "OK"
            Return miscDt
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
    End Function

    <WebMethod(Description:="Devuelve las transacciones pendientes de cuadrar")>
    Public Function GetRecepcionPendingAuto(ByVal pCodigoPoliza As String, ByVal pEnvironmentName As String, ByRef pResult As String) As DataTable

        Dim strSql As New StringBuilder(" SELECT *")
        strSql.Append(String.Format(" FROM {0}OP_WMS3PL_VIEW_AUTORIZATIONS_PENDING_AUTO AP", DefaultSchema))
        strSql.Append(String.Format(" INNER JOIN {0}OP_WMS_TRANS T ON (AP.SERIAL_NUMBER = T.SERIAL_NUMBER) ", DefaultSchema))
        strSql.Append(String.Format(" WHERE AP.CODIGO_POLIZA = '{0}' ", pCodigoPoliza))
        strSql.Append(String.Format(" AND AP.LICENSE_ID IS NOT NULL"))
        strSql.Append(String.Format(" AND AP.QUANTITY_UNITS > 0"))
        strSql.Append(String.Format(" AND [T].[STATUS] = 'PROCESSED'"))
        strSql.Append(" ORDER BY AP.LICENSE_ID")

        Dim sqldbConexion As SqlConnection

        Try
            sqldbConexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
            Dim miscDa As SqlDataAdapter = New SqlDataAdapter(strSql.ToString(), sqldbConexion)
            Dim miscDs As DataTable = New DataTable("GetRecepcionPendingAuto")
            miscDa.Fill(miscDs)
            pResult = "OK"
            Return miscDs
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
    End Function


    <WebMethod(Description:="Devuelve las las tareas de picking")>
    Public Function GetTaskPicking(ByVal pOlaPicking As String, ByVal pMaterialId As String, ByVal pQtyAssigned As Integer, ByVal pEnvironmentName As String, ByRef pResult As String) As DataTable

        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()
        Try
            Dim cmd As New SqlCommand
            Dim reader As SqlDataReader
            Dim dt As DataTable = New DataTable("GetTaskPicking")
            cmd.CommandText = String.Format("{0}OP_WMS_SP_GET_TASK_PICKING", DefaultSchema)
            cmd.Parameters.Add("@OlaPicking", SqlDbType.Int)
            cmd.Parameters("@OlaPicking").Value = pOlaPicking

            cmd.Parameters.Add("@MaterialId", SqlDbType.VarChar, 25)
            cmd.Parameters("@MaterialId").Value = pMaterialId

            cmd.Parameters.Add("@QTY", SqlDbType.Int)
            cmd.Parameters("@QTY").Value = pQtyAssigned

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


    <WebMethod(Description:="Consulta reporte egreso")>
    Public Function ObtnerConsultaDeEgresos(ByVal Login As String, ByVal pFechaInicio As DateTime, ByVal pFechaFin As DateTime, ByVal pClientCode As String, ByVal pRegimen As String, ByVal pEnvironmentName As String, ByRef pResult As String) As DataTable
        Dim sqldbConexion As SqlConnection
        Dim miscDs As DataTable = New DataTable("ReporteEgreso")
        Dim cmd As New SqlCommand
        Try
            sqldbConexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)

            cmd.Parameters.Add("@FECHA_INICIO", SqlDbType.DateTime)
            cmd.Parameters("@FECHA_INICIO").Direction = ParameterDirection.Input
            cmd.Parameters("@FECHA_INICIO").Value = pFechaInicio

            cmd.Parameters.Add("@FECHA_FINAL", SqlDbType.DateTime)
            cmd.Parameters("@FECHA_FINAL").Direction = ParameterDirection.Input
            cmd.Parameters("@FECHA_FINAL").Value = pFechaFin

            If Not pClientCode Is Nothing Then
                cmd.Parameters.Add("@CLIENT_CODE", SqlDbType.VarChar)
                cmd.Parameters("@CLIENT_CODE").Direction = ParameterDirection.Input
                cmd.Parameters("@CLIENT_CODE").Value = pClientCode
            End If

            If Not pRegimen Is Nothing Then
                cmd.Parameters.Add("@REGIMEN", SqlDbType.VarChar)
                cmd.Parameters("@REGIMEN").Direction = ParameterDirection.Input
                cmd.Parameters("@REGIMEN").Value = pRegimen
            End If

            cmd.Parameters.Add(New SqlParameter("@LOGIN", SqlDbType.VarChar, 25)).Value = Login
            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_GET_REPORT_EGRESS]"
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

    <WebMethod(Description:="Consulta reporte Ingreso")>
    Public Function ObtnerConsultaDeIngreso(ByVal Login As String, ByVal pFechaInicio As DateTime, ByVal pFechaFin As DateTime, ByVal pClientCode As String, ByVal pEnvironmentName As String, ByRef pResult As String) As DataTable
        Dim sqldbConexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim miscDs = New DataTable("ReporteIngreso")
        Dim cmd As New SqlCommand

        Try
            cmd.Parameters.Add("@FECHA_INICIO", SqlDbType.DateTime)
            cmd.Parameters("@FECHA_INICIO").Direction = ParameterDirection.Input
            cmd.Parameters("@FECHA_INICIO").Value = pFechaInicio

            cmd.Parameters.Add("@FECHA_FINAL", SqlDbType.DateTime)
            cmd.Parameters("@FECHA_FINAL").Direction = ParameterDirection.Input
            cmd.Parameters("@FECHA_FINAL").Value = pFechaFin

            If Not pClientCode Is Nothing Then
                cmd.Parameters.Add("@CLIENT_CODE", SqlDbType.VarChar)
                cmd.Parameters("@CLIENT_CODE").Direction = ParameterDirection.Input
                cmd.Parameters("@CLIENT_CODE").Value = pClientCode
            End If

            cmd.Parameters.Add("@LOGIN", SqlDbType.VarChar, 25).Value = Login
            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_REPORT_FISCAL_INCOME]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion

            Dim miscDa = New SqlDataAdapter(cmd)
            miscDa.Fill(miscDs)
            Return miscDs
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try

    End Function

    <WebMethod(Description:="Consulta reporte Ingreso General")>
    Public Function ObtnerConsultaDeIngresoGeneral(ByVal Login As String, ByVal pFechaInicio As DateTime, ByVal pFechaFin As DateTime, ByVal pClientCode As String, ByVal pEnvironmentName As String, ByRef pResult As String) As DataTable
        Dim sqldbConexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim miscDs = New DataTable("ReporteIngreso")
        Dim cmd As New SqlCommand
        Try
            cmd.Parameters.Add("@FECHA_INICIO", SqlDbType.DateTime)
            cmd.Parameters("@FECHA_INICIO").Direction = ParameterDirection.Input
            cmd.Parameters("@FECHA_INICIO").Value = pFechaInicio

            cmd.Parameters.Add("@FECHA_FINAL", SqlDbType.DateTime)
            cmd.Parameters("@FECHA_FINAL").Direction = ParameterDirection.Input
            cmd.Parameters("@FECHA_FINAL").Value = pFechaFin

            If Not pClientCode Is Nothing Then
                cmd.Parameters.Add("@CLIENT_CODE", SqlDbType.VarChar)
                cmd.Parameters("@CLIENT_CODE").Direction = ParameterDirection.Input
                cmd.Parameters("@CLIENT_CODE").Value = pClientCode
            End If

            cmd.Parameters.Add("@LOGIN", SqlDbType.VarChar, 25).Value = Login

            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_REPORT_GENERAL_INCOME]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion

            Dim miscDa = New SqlDataAdapter(cmd)
            miscDa.Fill(miscDs)
            Return miscDs
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try



    End Function

#Region "AutorizationSyncSat"

    <WebMethod(Description:="Verifica si la poliza existe ")>
    Public Function Verify_Poliza(ByVal pPoliza As String, ByVal pEnvironmentName As String, ByRef pResult As String) As DataSet

        Dim strSql As New StringBuilder
        strSql.Append(" SELECT vc.CLIENT_CODE")
        strSql.Append(" , vc.CLIENT_NAME")
        strSql.Append(String.Format(" FROM {0}OP_WMS_POLIZA_HEADER AS ph INNER JOIN {0}OP_WMS_VIEW_CLIENTS AS vc", DefaultSchema))
        strSql.Append(" ON ph.CLIENT_CODE = vc.CLIENT_CODE COLLATE DATABASE_DEFAULT")
        strSql.Append(String.Format(" WHERE NUMERO_ORDEN = '{0}'", pPoliza))

        Dim sqldb_conexion As SqlConnection
        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()
            miscDA.Fill(miscDS, "VerifyPoliza")
            pResult = "OK"
            Return miscDS
        Catch ex As Exception
            pResult = ex.Message
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
    End Function

    <WebMethod(Description:="Mira si ya fue grabada la poliza")>
    Public Function Exist_Autorization_Sat(ByVal pPoliza As String, ByVal pEnvironmentName As String, ByRef pResult As String) As DataSet

        Dim strSql As New StringBuilder
        strSql.Append(" SELECT")
        strSql.Append(" STATUS")
        strSql.Append(String.Format(" FROM {0}OP_WMS_AUTORIZATION_SYNC_SAT", DefaultSchema))
        strSql.Append(String.Format(" where POLIZA = '{0}'", pPoliza))

        Dim sqldb_conexion As SqlConnection
        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()
            miscDA.Fill(miscDS, "ExistPoliza")
            pResult = "OK"
            Return miscDS
        Catch ex As Exception
            pResult = ex.Message
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
    End Function

    <WebMethod(Description:="Graba la autorizacion sat")>
    Public Function Create_Autorization_Sat(ByVal pPoliza As String, ByVal pClientCode As Integer, ByVal pEnvironmentName As String, ByRef pResult As String) As Boolean

        Dim sqldb_conexion As SqlConnection
        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)

            Dim strSql As New StringBuilder
            strSql.Append(" INSERT INTO")
            strSql.Append(String.Format(" {0}OP_WMS_AUTORIZATION_SYNC_SAT(", DefaultSchema))
            strSql.Append(" DOC_ID")
            strSql.Append(" , POLIZA")
            strSql.Append(" , CLIENT_CODE")
            strSql.Append(" , STATUS")
            strSql.Append(" , CREATED")
            strSql.Append(" ) VALUES(")
            strSql.Append(String.Format(" (select (isnull(max(DOC_ID),0) +1) from {0}OP_WMS_AUTORIZATION_SYNC_SAT)", DefaultSchema))
            strSql.Append(String.Format(" , '{0}'", pPoliza))
            strSql.Append(String.Format(" , {0}", pClientCode))
            strSql.Append(" , 1")
            strSql.Append(" , GetDate())")

            If ExecuteSqlTransaction(sqldb_conexion.ConnectionString, strSql.ToString, pResult) Then
                Return True
            End If
            Return True
        Catch ex As Exception
            pResult = pResult + "ERROR," + ex.Message
            Return False
        End Try
    End Function

    <WebMethod(Description:="Actualiza la autorizacion sat")>
    Public Function Update_Autorization_Sat(ByVal pDocId As Integer, ByVal pSatResult As String, ByVal pSent As DateTime, ByVal pReceived As DateTime, ByVal pEnvironmentName As String, ByRef pResult As String) As Boolean

        Dim sqldb_conexion As SqlConnection

        Try
            Dim sqlCmd As SqlCommand
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
            Dim strSql As New StringBuilder
            strSql.Append(String.Format(" UPDATE {0}OP_WMS_AUTORIZATION_SYNC_SAT", DefaultSchema))
            strSql.Append(String.Format(" SET SENT = @Sent"))
            strSql.Append(String.Format(" , SAT_RESULT = @SatResult"))
            strSql.Append(String.Format(" , RECEIVED = @Recived"))
            strSql.Append(String.Format(" WHERE DOC_ID = @DocId"))
            sqlCmd.CommandText = strSql.ToString
            sqlCmd.CommandType = CommandType.Text
            sqlCmd.Parameters.Add("@Sent", SqlDbType.DateTime)
            sqlCmd.Parameters.Add("@SatResult", SqlDbType.VarChar, 250)
            sqlCmd.Parameters.Add("@Recived", SqlDbType.DateTime)
            sqlCmd.Parameters.Add("@DocId", SqlDbType.Int, 18)
            sqlCmd.Parameters("@Sent").Value = pSent
            sqlCmd.Parameters("@SatResult").Value = pSatResult
            sqlCmd.Parameters("@Recived").Value = pReceived
            sqlCmd.Parameters("@DocId").Value = pDocId
            sqlCmd.Connection = sqldb_conexion
            sqlCmd.Connection.Open()
            sqlCmd.ExecuteNonQuery()
            sqlCmd.Connection.Close()


            'If ExecuteSqlTransaction(sqldb_conexion.ConnectionString, strSql.ToString, pResult) Then
            'Return True
            'End If
            Return True
        Catch ex As Exception
            pResult = pResult + "ERROR," + ex.Message
            Return False
        End Try
    End Function

    <WebMethod(Description:="Obtener numero de stado por tipo")>
    Public Function Get_Num_Status(ByVal pEnvironmentName As String, ByRef pResult As String) As DataSet
        Dim strSql As New StringBuilder
        strSql.Append(" SELECT")
        strSql.Append(" (SELECT COUNT(*) FROM  " + DefaultSchema + "OP_WMS_AUTORIZATION_SYNC_SAT WHERE STATUS = 1) AS rowPending")
        strSql.Append(" , (SELECT COUNT(*) FROM  " + DefaultSchema + "OP_WMS_AUTORIZATION_SYNC_SAT WHERE STATUS = 2) AS rowReyected")
        strSql.Append(" , (SELECT COUNT(*) FROM  " + DefaultSchema + "OP_WMS_AUTORIZATION_SYNC_SAT WHERE STATUS = 3) AS rowAproved ")

        Dim sqldb_conexion As SqlConnection
        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()
            miscDA.Fill(miscDS, "Get_Num_Status")
            pResult = "OK"
            Return miscDS
        Catch ex As Exception
            pResult = ex.Message
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
    End Function

#End Region

#Region "ComprobanteDeEntrada"

    <WebMethod(Description:="Get Doc Income by client")>
    Public Function GetDocIncomeByClient(ByVal nameTable As String, ByVal codeClient As String, ByVal startDate As Date,
                                             ByVal endDate As Date, ByRef pResult As String, ByVal pEnvironmentName As String) As DataTable

        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()
        Try
            Dim cmd As New SqlCommand
            Dim reader As SqlDataReader
            Dim dt As DataTable = New DataTable(nameTable)
            cmd.CommandText = String.Format("{0}OP_WMS_SP_GET_DOC_INCOME_BY_CLIENT", DefaultSchema)

            cmd.Parameters.Add("@CODE_CLIENT", SqlDbType.VarChar).Value = codeClient
            cmd.Parameters.Add("@START_DATE", SqlDbType.Date).Value = startDate
            cmd.Parameters.Add("@END_DATE", SqlDbType.Date).Value = endDate

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

    <WebMethod(Description:="Get Details Doc Income by client")>
    Public Function GetDetailsDocIncomeByClient(ByVal nameTable As String, ByVal codeClient As String, ByVal codePoliza As String,
                                                ByRef pResult As String, ByVal pEnvironmentName As String) As DataTable

        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()
        Try
            Dim cmd As New SqlCommand
            Dim reader As SqlDataReader
            Dim dt As DataTable = New DataTable(nameTable)
            cmd.CommandText = String.Format("{0}OP_WMS_SP_GET_DETAILS_DOC_INCOME_BY_CLIENT", DefaultSchema)

            cmd.Parameters.Add("@CODE_CLIENT", SqlDbType.VarChar).Value = codeClient
            cmd.Parameters.Add("@CODE_POLIZA", SqlDbType.VarChar).Value = codePoliza

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

#End Region

#Region "Rectificacion"

    <WebMethod(Description:="Establece la poliza como rectificada")>
    Public Function EstablecerPolizaPendienteRetificacion(ByVal docId As Integer, ByVal poliza As String, ByVal comentario As String, ByVal clase As String,
                                                 ByVal usuario As String, ByVal pEnvironmentName As String) As String

        Dim sqldbConexion As SqlConnection
        Try
            sqldbConexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
            sqldbConexion.Open()

            Dim cmd As New SqlCommand
            cmd.CommandText = String.Format("{0}OP_WMS_SP_SET_POLIZA_PENDING_RECTIFICATION", DefaultSchema)
            cmd.Parameters.Add("@DOC_ID", SqlDbType.Int).Value = docId
            cmd.Parameters.Add("@CODIGO_POLIZA_RECTIFADA", SqlDbType.VarChar, 18).Value = poliza
            cmd.Parameters.Add("@COMENTARIO_RECTIFICACION", SqlDbType.VarChar, 25).Value = comentario
            cmd.Parameters.Add("@CLASE_POLIZA_RECTIFICACION", SqlDbType.VarChar, 200).Value = clase
            cmd.Parameters.Add("@LAST_UPDATED_BY", SqlDbType.VarChar, 25).Value = usuario
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            cmd.ExecuteNonQuery()
            sqldbConexion.Close()

            Return "OK"
        Catch exDb As SqlException
            Return "ERROR," + exDb.Message
        Catch ex As Exception
            Return "ERROR," + ex.Message
        End Try
    End Function

    <WebMethod(Description:="ObtenerPolizasPendientesDeRectificacion")>
    Public Function ObtenerPolizasPendientesDeRectificacion(ByRef pResult As String, ByVal pEnvironmentName As String) As DataTable

        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()
        Try
            Dim cmd As New SqlCommand
            Dim reader As SqlDataReader
            Dim dt As DataTable = New DataTable("OP_WMS_GET_POLIZA_RECTIFICATION")
            cmd.CommandText = String.Format("{0}OP_WMS_GET_POLIZA_RECTIFICATION", DefaultSchema)

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

    <WebMethod(Description:="Establece la poliza como rectificada")>
    Public Function EstablecerPolizaRetificacion(ByVal docIdRectificada As Integer, ByVal docIdRectificacion As Integer, ByVal comentario As String, ByVal clase As String,
                                                 ByVal usuario As String, ByVal pEnvironmentName As String) As String

        Dim sqldbConexion As SqlConnection
        Try
            sqldbConexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
            sqldbConexion.Open()

            Dim cmd As New SqlCommand
            cmd.CommandText = String.Format("{0}OP_WMS_SP_SET_POLIZA_RECTIFICATION", DefaultSchema)
            cmd.Parameters.Add("@DOC_ID_RECTIFADA", SqlDbType.Int).Value = docIdRectificada
            cmd.Parameters.Add("@DOC_ID_RECTIFICACION", SqlDbType.Int).Value = docIdRectificacion
            cmd.Parameters.Add("@CLASE_POLIZA_RECTIFICACION", SqlDbType.VarChar, 25).Value = clase
            cmd.Parameters.Add("@COMENTARIO_RECTIFICACION", SqlDbType.VarChar, 200).Value = comentario
            cmd.Parameters.Add("@LAST_UPDATED_BY", SqlDbType.VarChar, 25).Value = usuario
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            cmd.ExecuteNonQuery()
            sqldbConexion.Close()
        Catch exDb As SqlException
            Return "ERROR," + exDb.Message
        Catch ex As Exception
            Return "ERROR," + ex.Message
        End Try
        Return "OK"
    End Function

    <WebMethod(Description:="ObtenerRectificaciones")>
    Public Function ObtenerRectificaciones(ByVal startDate As Date, ByVal endDate As Date, ByRef pResult As String, ByVal pEnvironmentName As String) As DataTable

        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()
        Try
            Dim cmd As New SqlCommand
            Dim reader As SqlDataReader
            Dim dt As DataTable = New DataTable("OP_WMS_GET_RECTIFICATIONS")
            cmd.CommandText = String.Format("{0}OP_WMS_GET_RECTIFICATIONS", DefaultSchema)
            cmd.Parameters.Add("@START_DATE", SqlDbType.DateTime).Value = startDate
            cmd.Parameters.Add("@END_DATE", SqlDbType.DateTime).Value = endDate
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

#End Region



    <WebMethod(Description:="Inserta Tarea De Recepcion")>
    Public Function InsertarTareaDeRecepcion(ByVal taskSubType As String, ByVal taskOwner As String, ByVal taskAssignedTo As String,
                                ByVal taskComments As String, ByVal regimen As String, ByVal clientOwner As String, ByVal clientName As String,
                                ByVal docIdSource As Integer, ByVal pEnvironmentName As String, ByRef pResult As String,
                                             ByVal codigoPolizaSource As String, ByVal EnviaErp As Integer, ByVal priority As Integer, ByVal receptionType As String) As DataTable
        Dim sqldb_conexion As SqlConnection
        Dim command As SqlCommand

        sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Try
            command = New SqlCommand(DefaultSchema & "OP_WMS_SP_INSERT_TASK_RECEPTION", sqldb_conexion)
            command.CommandType = CommandType.StoredProcedure

            'creamos todos los parametros del sp            
            command.Parameters.Add(New SqlParameter("@TASK_SUBTYPE", SqlDbType.VarChar, 25))
            command.Parameters.Add(New SqlParameter("@TASK_OWNER", SqlDbType.VarChar, 25))
            command.Parameters.Add(New SqlParameter("@TASK_ASSIGNEDTO", SqlDbType.VarChar, 25))
            command.Parameters.Add(New SqlParameter("@TASK_COMMENTS", SqlDbType.VarChar, 150))
            command.Parameters.Add(New SqlParameter("@REGIMEN", SqlDbType.VarChar, 50))
            command.Parameters.Add(New SqlParameter("@CLIENT_OWNER", SqlDbType.VarChar, 25))
            command.Parameters.Add(New SqlParameter("@CLIENT_NAME", SqlDbType.VarChar, 150))
            command.Parameters.Add(New SqlParameter("@DOC_ID_SOURCE", SqlDbType.Int))
            command.Parameters.Add(New SqlParameter("@PRIORITY", SqlDbType.Int))
            command.Parameters.Add(New SqlParameter("@CODIGO_POLIZA_SOURCE", SqlDbType.VarChar, 25))
            command.Parameters.Add(New SqlParameter("@SEND_TO_ERP", SqlDbType.Int))
            command.Parameters.Add(New SqlParameter("@RECEPTION_TYPE_ERP", SqlDbType.VarChar, 50))


            command.Parameters("@TASK_SUBTYPE").Value = taskSubType
            command.Parameters("@TASK_OWNER").Value = taskOwner
            command.Parameters("@TASK_ASSIGNEDTO").Value = taskAssignedTo
            command.Parameters("@TASK_COMMENTS").Value = taskComments
            command.Parameters("@REGIMEN").Value = regimen
            command.Parameters("@CLIENT_OWNER").Value = clientOwner
            command.Parameters("@CLIENT_NAME").Value = clientName
            command.Parameters("@DOC_ID_SOURCE").Value = docIdSource
            command.Parameters("@PRIORITY").Value = priority
            command.Parameters("@CODIGO_POLIZA_SOURCE").Value = codigoPolizaSource
            command.Parameters("@SEND_TO_ERP").Value = EnviaErp
            command.Parameters("@RECEPTION_TYPE_ERP").Value = receptionType
            Dim adapter = New SqlDataAdapter(command)
            Dim table = New DataTable("InsertarTareaDeRecepcion")

            'ejecutamos el procedure 
            sqldb_conexion.Open()
            adapter.Fill(table)

            Return table
        Catch ex As Exception
            pResult = "ERROR," & ex.Message
            Return Nothing
        Finally
            sqldb_conexion.Close()
            sqldb_conexion.Dispose()
        End Try

    End Function

    <WebMethod(Description:="obtiene las polizas por cliente y regimen de bodega")>
    Public Function GetPolizaByClientAndWarehouseRegimen(ByVal Login As String, ByVal WarehouseRegimen As String, ByVal ClientCode As String, ByVal pEnvironmentName As String, ByRef pResult As String) As DataSet
        Dim sqldb_conexion As SqlConnection
        Dim sqlCmd As SqlCommand

        sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Try

            sqlCmd = New SqlCommand(DefaultSchema & "OP_WMS_SP_GET_POLIZA_BY_CLIENT_AND_WAREHOUSE_REGIMEN", sqldb_conexion)
            sqlCmd.CommandType = CommandType.StoredProcedure

            'creamos todos los parametros del sp            
            sqlCmd.Parameters.Add(New SqlParameter("@CLIENT_CODE", SqlDbType.VarChar, 25)).Value = ClientCode
            sqlCmd.Parameters.Add(New SqlParameter("@WHAREHOUSE_REGIMEN", SqlDbType.VarChar, 25)).Value = WarehouseRegimen
            sqlCmd.Parameters.Add(New SqlParameter("@LOGIN", SqlDbType.VarChar, 25)).Value = Login

            'ejecutamos el procedure 
            If sqldb_conexion.State = ConnectionState.Closed Then sqldb_conexion.Open()
            Dim miscDA = New SqlDataAdapter(sqlCmd)
            Dim miscDS = New DataSet()

            miscDA.Fill(miscDS, "OP_WMS_POLIZA_HEAD")
            pResult = "OK"
            Return miscDS

        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing

        Finally
            If sqldb_conexion.State = ConnectionState.Open Then sqldb_conexion.Close()
        End Try

    End Function

    <WebMethod(Description:="Obtiene el inventario fiscal por licencia")>
    Public Function GetInventoryFiscalByLicence(ByVal docId As Integer, ByVal line As Integer, ByRef pResult As String, ByVal pEnvironmentName As String) As DataTable

        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()
        Try
            Dim cmd As New SqlCommand
            Dim reader As SqlDataReader
            Dim dt As DataTable = New DataTable("GetInventoryFiscalByLicence")
            cmd.CommandText = String.Format("{0}OP_WMS_SP_GET_INVENTORY_FISCAL_BY_LICENCE", DefaultSchema)
            cmd.Parameters.Add("@DOC_ID", SqlDbType.Int).Value = docId
            cmd.Parameters.Add("@LINENO_POLIZA", SqlDbType.Int).Value = line
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


    <WebMethod(Description:="Crea tareas de picking")>
    Public Function InsertTaskFical(ByVal pTASK_TYPE As String, ByVal pTASK_SUBTYPE As String, ByVal pTASK_OWNER As String, ByVal pTASK_ASSIGNEDTO As String, ByVal pQUATITY_ASSIGNED As Double, ByVal pQUATITY_PENDING As Double,
                                   ByVal pCODIGO_POLIZA_SOURCE As String, ByVal pCODIGO_POLIZA_TARGET As String, ByVal pREGIMEN As String, ByVal pMATERIAL_ID As String, ByVal pBARCODE_ID As String, ByVal pALTERNATE_BARCODE As String,
                                   ByVal pMATERIAL_NAME As String, ByVal pCLIENT_OWNER As String, ByVal pCLIENT_NAME As String, ByVal numeroDeLineaPolizaOrigen As Integer, ByVal numeroDeLineaPolizaDestino As Integer, ByVal licenciaId As Integer, ByVal pEnvironmentName As String, ByRef pResult As String, ByRef pWAVE_PICKING_ID As Integer, ByVal pTranslation As String) As Boolean
        Dim sqldb_conexion As SqlConnection
        Dim sqlCmd As SqlCommand

        sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Try
            sqlCmd = New SqlCommand(DefaultSchema & "OP_WMS_SP_INSERT_TASKS_FISCAL", sqldb_conexion)
            sqlCmd.CommandType = CommandType.StoredProcedure
            sqlCmd.CommandTimeout = 100

            'creamos todos los parametros del sp
            sqlCmd.Parameters.Add(New SqlParameter("@TASK_TYPE", SqlDbType.VarChar, 25)).Direction = ParameterDirection.Input
            sqlCmd.Parameters.Add(New SqlParameter("@TASK_SUBTYPE", SqlDbType.VarChar, 25))
            sqlCmd.Parameters.Add(New SqlParameter("@TASK_OWNER", SqlDbType.VarChar, 25))
            sqlCmd.Parameters.Add(New SqlParameter("@TASK_ASSIGNEDTO", SqlDbType.VarChar, 25))
            sqlCmd.Parameters.Add(New SqlParameter("@QUANTITY_ASSIGNED", SqlDbType.Float))
            sqlCmd.Parameters.Add(New SqlParameter("@QUANTITY_PENDING", SqlDbType.Float))
            sqlCmd.Parameters.Add(New SqlParameter("@CODIGO_POLIZA_SOURCE", SqlDbType.VarChar, 25))
            sqlCmd.Parameters.Add(New SqlParameter("@CODIGO_POLIZA_TARGET", SqlDbType.VarChar, 25))
            sqlCmd.Parameters.Add(New SqlParameter("@REGIMEN", SqlDbType.VarChar, 50))
            sqlCmd.Parameters.Add(New SqlParameter("@MATERIAL_ID", SqlDbType.VarChar, 25))
            sqlCmd.Parameters.Add(New SqlParameter("@BARCODE_ID", SqlDbType.VarChar, 50))
            sqlCmd.Parameters.Add(New SqlParameter("@ALTERNATE_BARCODE", SqlDbType.VarChar, 50))
            sqlCmd.Parameters.Add(New SqlParameter("@MATERIAL_NAME", SqlDbType.VarChar, 200))
            sqlCmd.Parameters.Add(New SqlParameter("@CLIENT_OWNER", SqlDbType.VarChar, 25))
            sqlCmd.Parameters.Add(New SqlParameter("@CLIENT_NAME", SqlDbType.VarChar, 150))
            sqlCmd.Parameters.Add(New SqlParameter("@PRESULT", SqlDbType.VarChar, 4000)).Direction = ParameterDirection.Output
            sqlCmd.Parameters.Add(New SqlParameter("@WAVE_PICKING_ID", SqlDbType.Int)).Direction = ParameterDirection.InputOutput
            sqlCmd.Parameters.Add(New SqlParameter("@TRAMSLATION", SqlDbType.VarChar, 10))

            sqlCmd.Parameters("@TASK_TYPE").Value = pTASK_TYPE
            sqlCmd.Parameters("@TASK_SUBTYPE").Value = pTASK_SUBTYPE
            sqlCmd.Parameters("@TASK_OWNER").Value = pTASK_OWNER
            sqlCmd.Parameters("@TASK_ASSIGNEDTO").Value = pTASK_ASSIGNEDTO
            sqlCmd.Parameters("@QUANTITY_ASSIGNED").Value = pQUATITY_ASSIGNED
            sqlCmd.Parameters("@QUANTITY_PENDING").Value = pQUATITY_PENDING
            sqlCmd.Parameters("@CODIGO_POLIZA_SOURCE").Value = pCODIGO_POLIZA_SOURCE
            sqlCmd.Parameters("@CODIGO_POLIZA_TARGET").Value = pCODIGO_POLIZA_TARGET
            sqlCmd.Parameters("@REGIMEN").Value = pREGIMEN
            sqlCmd.Parameters("@MATERIAL_ID").Value = pMATERIAL_ID
            sqlCmd.Parameters("@BARCODE_ID").Value = pBARCODE_ID
            sqlCmd.Parameters("@ALTERNATE_BARCODE").Value = pALTERNATE_BARCODE
            sqlCmd.Parameters("@MATERIAL_NAME").Value = pMATERIAL_NAME
            sqlCmd.Parameters("@CLIENT_OWNER").Value = pCLIENT_OWNER
            sqlCmd.Parameters("@CLIENT_NAME").Value = pCLIENT_NAME
            sqlCmd.Parameters("@WAVE_PICKING_ID").Value = pWAVE_PICKING_ID
            sqlCmd.Parameters("@TRAMSLATION").Value = pTranslation

            sqlCmd.Parameters.Add(New SqlParameter("@LINE_NUMBER_POLIZA_SOURCE", SqlDbType.Int)).Value = numeroDeLineaPolizaOrigen
            sqlCmd.Parameters.Add(New SqlParameter("@LINE_NUMBER_POLIZA_TARGET", SqlDbType.Int)).Value = numeroDeLineaPolizaDestino
            sqlCmd.Parameters.Add(New SqlParameter("@LICENCE_ID", SqlDbType.Int)).Value = licenciaId

            'ejecutamos el procedure y validamos la respuesta
            If sqldb_conexion.State = ConnectionState.Closed Then sqldb_conexion.Open()
            sqlCmd.ExecuteNonQuery()

            pResult = sqlCmd.Parameters("@PRESULT").Value


            If pResult = "OK" Then
                pWAVE_PICKING_ID = sqlCmd.Parameters("@WAVE_PICKING_ID").Value
                Return True
            Else
                pWAVE_PICKING_ID = 0
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

    <WebMethod(Description:="Obtiene el inventario necesitado para los masterpacks")>
    Public Function GetInventoryNeededForMasterPack(ByVal masterPackCode As String, ByVal warehouseId As String, ByVal qty As Integer, ByRef pResult As String, ByVal pEnvironmentName As String) As DataTable
        Dim sqldbConexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()
        Try
            Dim cmd As New SqlCommand
            Dim reader As SqlDataReader
            Dim dt = New DataTable("InventoryNeededByMasterPack")
            cmd.CommandText = String.Format("{0}OP_WMS_SP_GET_INVENTORY_NEEDED_FOR_MASTERPACK", DefaultSchema)
            cmd.Parameters.Add("@MASTER_PACK_CODE", SqlDbType.VarChar).Value = masterPackCode
            cmd.Parameters.Add("@WAREHOUSE_ID", SqlDbType.VarChar).Value = warehouseId
            cmd.Parameters.Add("@QTY", SqlDbType.Int).Value = qty
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            reader = cmd.ExecuteReader()
            dt.Load(reader)
            Return dt
        Catch ex As Exception
            pResult = ex.Message
            Return Nothing
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try
    End Function

    <WebMethod(Description:="Obtiene el inventario actual del masterpack incluyendo lo que se puede armar a un nivel")>
    Public Function CheckMasterPackInventory(ByVal masterPackCode As String, ByVal warehouseId As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Integer
        Dim sqldbConexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()
        Try
            Dim cmd As New SqlCommand

            cmd.CommandText = String.Format("{0}[OP_WMS_SP_GET_AVAILABLE_INVENTORY_FOR_MASTERPACK]", DefaultSchema)
            cmd.Parameters.Add("@MASTER_PACK_CODE", SqlDbType.VarChar).Value = masterPackCode
            cmd.Parameters.Add("@WAREHOUSE_ID", SqlDbType.VarChar).Value = warehouseId
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion

            Dim ret = cmd.ExecuteScalar()


            Return Convert.ToInt32(ret)
        Catch ex As Exception
            pResult = ex.Message
            Return Nothing
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try
    End Function

    <WebMethod(Description:="Valida todo el inventario del egreso general por xml y retorna el inventario necesario/no disponible")>
    Public Function CheckGeneralExitInventory(ByVal xmlDetalle As String, ByVal warehouseId As String, ByVal olaPicking As Integer, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldbConexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()
        Try
            Dim sqlCmd = New SqlCommand(DefaultSchema & "OP_WMS_SP_CHECK_INVENTORY_GENERAL_EXIT", sqldbConexion)
            sqlCmd.CommandType = CommandType.StoredProcedure

            'creamos todos los parametros del sp            
            sqlCmd.Parameters.Add(New SqlParameter("@XML", SqlDbType.Xml)).Value = xmlDetalle
            sqlCmd.Parameters.Add(New SqlParameter("@WAREHOUSE_ID", SqlDbType.VarChar)).Value = warehouseId

            Dim miscDa = New SqlDataAdapter(sqlCmd)
            Dim miscDs = New DataSet()

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

    <WebMethod(Description:="Obtiene el detalle de la tarea por numero de serie o por ola de picking")>
    Public Function GetTaskFromReceptionOrDispatch(serialNumber As Integer, wavePickingId As Integer, ByRef pResult As String, ByVal pEnvironmentName As String) As DataTable
        Dim sqldbConexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()
        Try
            Dim cmd As New SqlCommand
            Dim reader As SqlDataReader
            Dim dt = New DataTable("GetTaskFromReceptionOrDispatch")
            cmd.CommandText = String.Format("{0}[OP_WMS_SP_GET_TASKS_FROM_RECEPTION_OR_DISPATCH]", DefaultSchema)
            cmd.Parameters.Add("@SERIAL_NUMBER", SqlDbType.VarChar).Value = serialNumber
            cmd.Parameters.Add("@WAVE_PICKING_ID", SqlDbType.VarChar).Value = wavePickingId
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            reader = cmd.ExecuteReader()
            dt.Load(reader)
            Return dt
        Catch ex As Exception
            pResult = ex.Message
            Return Nothing
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try
    End Function

    <WebMethod(Description:="Obtiene las polizas con inventario disponible")>
    Public Function GetPolicyWithAvailableInventory(warehouse As String, clientOwer As String, regimen As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataTable
        Dim sqldbConexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()
        Try
            Dim cmd As New SqlCommand
            Dim reader As SqlDataReader
            Dim dt = New DataTable("GetPolicyWithAvailableInventori")
            cmd.CommandText = String.Format("{0}[OP_WMS_SP_GET_ACTIVE_INCOME_POLICY]", DefaultSchema)
            cmd.Parameters.Add("@WAREHOUSE", SqlDbType.VarChar).Value = warehouse
            cmd.Parameters.Add("@CLIENT_OWNER", SqlDbType.VarChar).Value = clientOwer
            cmd.Parameters.Add("@REGIMEN", SqlDbType.VarChar).Value = regimen
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            reader = cmd.ExecuteReader()
            dt.Load(reader)
            Return dt
        Catch ex As Exception
            pResult = ex.Message
            Return Nothing
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try
    End Function

    <WebMethod(Description:="Obtiene el inventario de la poliza")>
    Public Function GetInventoryByPolicy(codigoPoliza As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataTable
        Dim sqldbConexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()
        Try
            Dim cmd As New SqlCommand
            Dim reader As SqlDataReader
            Dim dt = New DataTable("GetInventoryByPolicy")
            cmd.CommandText = String.Format("{0}[OP_WMS_SP_GET_INVENTORY_POLICY]", DefaultSchema)
            cmd.Parameters.Add("@CODIGO_POLIZA", SqlDbType.VarChar).Value = codigoPoliza
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            reader = cmd.ExecuteReader()
            dt.Load(reader)
            Return dt
        Catch ex As Exception
            pResult = ex.Message
            Return Nothing
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try
    End Function

    <WebMethod(Description:="Obtiene los datos del ticket")>
    Public Function GetTicketById(idTicket As Long, ByRef pResult As String, ByVal pEnvironmentName As String) As DataTable
        Dim sqldbConexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()
        Try
            Dim cmd As New SqlCommand
            Dim reader As SqlDataReader
            Dim dt = New DataTable("GetTicketById")
            cmd.CommandText = String.Format("{0}[OP_WMS_SP_GET_TICKET]", DefaultSchema)
            cmd.Parameters.Add("@TICKET_NUMBER", SqlDbType.BigInt).Value = idTicket
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            reader = cmd.ExecuteReader()
            dt.Load(reader)
            Return dt
        Catch ex As Exception
            pResult = ex.Message
            Return Nothing
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try
    End Function

End Class