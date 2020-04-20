Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Configuration.ConfigurationManager
Imports System.ComponentModel
Imports System.Data.SqlClient
Imports WMSOnePlan_BusinessServices.ModuleServices

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")>
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)>
<ToolboxItem(False)>
Public Class WMS_Polizas
    Inherits System.Web.Services.WebService

    <WebMethod(Description:="ParsePoliza")>
    Public Function ParsePoliza(ByVal pPOLIZA_BARCODE As String, ByRef pResult As String) As DataSet


        Try
            Dim xrow As DataRow

            Dim xtable As New DataTable
            Dim xds As New DataSet

            xrow = xtable.NewRow

            xtable.Columns.Add("FIELD_1", System.Type.GetType("System.String"))
            xtable.Columns.Add("FIELD_3", System.Type.GetType("System.String"))
            xtable.Columns.Add("FIELD_4", System.Type.GetType("System.String"))
            xtable.Columns.Add("FIELD_5", System.Type.GetType("System.String"))
            xtable.Columns.Add("FIELD_6", System.Type.GetType("System.String"))
            xtable.Columns.Add("FIELD_8_1", System.Type.GetType("System.String"))
            xtable.Columns.Add("FIELD_8_2", System.Type.GetType("System.String"))
            xtable.Columns.Add("FIELD_9", System.Type.GetType("System.String"))
            xtable.Columns.Add("FIELD_12", System.Type.GetType("System.String"))
            xtable.Columns.Add("FIELD_15", System.Type.GetType("System.String"))
            xtable.Columns.Add("FIELD_16", System.Type.GetType("System.String"))
            xtable.Columns.Add("FIELD_20", System.Type.GetType("System.String"))
            xtable.Columns.Add("FIELD_21", System.Type.GetType("System.String"))
            xtable.Columns.Add("FIELD_22", System.Type.GetType("System.String"))
            xtable.Columns.Add("FIELD_23", System.Type.GetType("System.String"))
            xtable.Columns.Add("FIELD_24", System.Type.GetType("System.String"))
            xtable.Columns.Add("FIELD_25_4", System.Type.GetType("System.String"))
            xtable.Columns.Add("FIELD_25_5", System.Type.GetType("System.String"))
            xtable.Columns.Add("FIELD_29", System.Type.GetType("System.String"))

            xrow("FIELD_1") = Mid(pPOLIZA_BARCODE, 1, 10)
            xrow("FIELD_3") = Mid(pPOLIZA_BARCODE, 11, 20)
            xrow("FIELD_4") = Mid(pPOLIZA_BARCODE, 31, 8)
            xrow("FIELD_5") = Mid(pPOLIZA_BARCODE, 39, 7)
            xrow("FIELD_6") = Mid(pPOLIZA_BARCODE, 46, 8)
            'xrow("FIELD_8_1") = Mid(pPOLIZA_BARCODE, 71, 6)
            'xrow("FIELD_8_2") = Mid(pPOLIZA_BARCODE, 77, 2)
            xrow("FIELD_8_1") = Mid(pPOLIZA_BARCODE, 71, 5)
            xrow("FIELD_8_2") = Mid(pPOLIZA_BARCODE, 76, 2)
            xrow("FIELD_9") = Mid(pPOLIZA_BARCODE, 79, 2)
            xrow("FIELD_12") = Mid(pPOLIZA_BARCODE, 81, 1)
            xrow("FIELD_15") = Mid(pPOLIZA_BARCODE, 82, 8)
            xrow("FIELD_16") = Mid(pPOLIZA_BARCODE, 90, 15)
            xrow("FIELD_20") = Mid(pPOLIZA_BARCODE, 105, 15)
            xrow("FIELD_21") = Mid(pPOLIZA_BARCODE, 120, 16)
            xrow("FIELD_22") = Mid(pPOLIZA_BARCODE, 136, 15)
            xrow("FIELD_23") = Mid(pPOLIZA_BARCODE, 151, 15)
            xrow("FIELD_24") = Mid(pPOLIZA_BARCODE, 166, 15)
            xrow("FIELD_25_4") = Mid(pPOLIZA_BARCODE, 181, 15)
            xrow("FIELD_25_5") = Mid(pPOLIZA_BARCODE, 196, 15)
            xrow("FIELD_29") = Mid(pPOLIZA_BARCODE, 211, 9)

            xtable.Rows.Add(xrow)
            xds.Tables.Add(xtable)
            pResult = "OK"
            Return xds

        Catch ex As Exception
            pResult = ex.Message
            Return Nothing
        Finally
        End Try

    End Function


    <WebMethod(Description:="Search Bin by Key")>
    Public Function AgregarImagenAPoliza(ByVal pCODIGO_BARRAS_ID As String, ByVal pIMAGE As Byte(), ByVal pLoginID As String,
                                         ByVal pAuditId As Integer, ByVal pAuditType As String,
                                         ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldb_conexion.Open()

        Try

            Dim cmd As New SqlCommand

            cmd.Parameters.Add("@pCODIGO_BARRAS_ID", SqlDbType.VarChar, 50)
            cmd.Parameters("@pCODIGO_BARRAS_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@pCODIGO_BARRAS_ID").Value = pCODIGO_BARRAS_ID

            cmd.Parameters.Add("@pIMAGE", SqlDbType.Image)
            cmd.Parameters("@pIMAGE").Direction = ParameterDirection.Input
            cmd.Parameters("@pIMAGE").Value = pIMAGE

            cmd.Parameters.Add("@pUPLOADED_BY", SqlDbType.VarChar, 25)
            cmd.Parameters("@pUPLOADED_BY").Direction = ParameterDirection.Input
            cmd.Parameters("@pUPLOADED_BY").Value = pLoginID

            cmd.Parameters.Add("@AUDIT_ID", SqlDbType.Int)
            cmd.Parameters("@AUDIT_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@AUDIT_ID").Value = pAuditId

            cmd.Parameters.Add("@AUDIT_TYPE", SqlDbType.VarChar, 25)
            cmd.Parameters("@AUDIT_TYPE").Direction = ParameterDirection.Input
            cmd.Parameters("@AUDIT_TYPE").Value = pAuditType

            cmd.Parameters.Add("@pRESULT", SqlDbType.VarChar, 250)
            cmd.Parameters("@pRESULT").Direction = ParameterDirection.Output
            cmd.Parameters("@pRESULT").Value = ""

            cmd.CommandText = DefaultSchema & "OP_WMS_SP_AGREGA_IMAGEN_POLIZA"
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


    <WebMethod(Description:="CrearLicencia")>
    Public Function CrearLicencia(ByVal pCODIGO_POLIZA As String, ByVal pLoginID As String, ByRef pLICENCIA_ID As Integer, ByVal pCLIENT_OWNER As String, ByVal pREGIMEN As String, ByVal TaskId As Integer, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldb_conexion.Open()

        Try

            Dim cmd As New SqlCommand

            cmd.Parameters.Add("@pCODIGO_POLIZA", SqlDbType.VarChar, 25)
            cmd.Parameters("@pCODIGO_POLIZA").Direction = ParameterDirection.Input
            cmd.Parameters("@pCODIGO_POLIZA").Value = pCODIGO_POLIZA

            cmd.Parameters.Add("@pLOGIN", SqlDbType.VarChar, 25)
            cmd.Parameters("@pLOGIN").Direction = ParameterDirection.Input
            cmd.Parameters("@pLOGIN").Value = pLoginID

            cmd.Parameters.Add("@pLICENCIA_ID", SqlDbType.Int)
            cmd.Parameters("@pLICENCIA_ID").Direction = ParameterDirection.Output
            cmd.Parameters("@pLICENCIA_ID").Value = 0

            cmd.Parameters.Add("@pCLIENT_OWNER", SqlDbType.VarChar, 25)
            cmd.Parameters("@pCLIENT_OWNER").Direction = ParameterDirection.Input
            cmd.Parameters("@pCLIENT_OWNER").Value = pCLIENT_OWNER

            cmd.Parameters.Add("@pREGIMEN", SqlDbType.VarChar, 25)
            cmd.Parameters("@pREGIMEN").Direction = ParameterDirection.Input
            cmd.Parameters("@pREGIMEN").Value = pREGIMEN

            cmd.Parameters.Add("@pRESULT", SqlDbType.VarChar, 250)
            cmd.Parameters("@pRESULT").Direction = ParameterDirection.Output
            cmd.Parameters("@pRESULT").Value = ""
            If TaskId > 0 Then
                cmd.Parameters.Add("@pTaskId", SqlDbType.Int)
                cmd.Parameters("@pTaskId").Direction = ParameterDirection.Input
                cmd.Parameters("@pTaskId").Value = TaskId
            End If


            cmd.CommandText = DefaultSchema + "OP_WMS_SP_CREA_LICENCIA"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldb_conexion

            cmd.ExecuteNonQuery()

            sqldb_conexion.Close()
            pResult = cmd.Parameters("@pRESULT").Value.ToString

            If pResult = "OK" Then
                pLICENCIA_ID = cmd.Parameters("@pLICENCIA_ID").Value
            End If

            Return IIf(pResult = "OK", True, False)

        Catch ex As Exception
            pResult = "CrearLicencia: " + ex.Message
            Return False
        Finally
            sqldb_conexion.Close()
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try

    End Function
    <WebMethod(Description:="Search Bin by Key")>
    Public Function AgregaSKU_Licencia(ByVal pLICENSE_ID As Integer, ByVal pBARCODE As String, ByVal pQTY As Decimal, ByVal pLAST_LOGIN As String,
                                   ByVal pVOLUME_FACTOR As Double, ByVal pWEIGTH As Double, ByVal pSERIAL As String, ByVal pCOMMENTS As String,
                                   ByVal pACUERDO_COMERCIAL As String, ByRef pSKUS_COUNTED As Integer, ByVal pSTATUS As String, ByRef pResult As String,
                                   ByVal pEnvironmentName As String, ByVal pDateExpiration As Date, ByVal pBatch As String, ByVal pVin As String, statusName As string, action as string, tone as string, caliber As string) As Boolean

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldb_conexion.Open()

        Try

            Dim cmd As New SqlCommand

            cmd.Parameters.Add("@pLICENSE_ID", SqlDbType.Int)
            cmd.Parameters("@pLICENSE_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@pLICENSE_ID").Value = pLICENSE_ID

            cmd.Parameters.Add("@pBARCODE", SqlDbType.VarChar, 25)
            cmd.Parameters("@pBARCODE").Direction = ParameterDirection.Input
            cmd.Parameters("@pBARCODE").Value = pBARCODE

            cmd.Parameters.Add("@pQTY", SqlDbType.Decimal)
            cmd.Parameters("@pQTY").Direction = ParameterDirection.Input
            cmd.Parameters("@pQTY").Value = pQTY

            cmd.Parameters.Add("@pLAST_LOGIN", SqlDbType.VarChar, 25)
            cmd.Parameters("@pLAST_LOGIN").Direction = ParameterDirection.Input
            cmd.Parameters("@pLAST_LOGIN").Value = pLAST_LOGIN

            cmd.Parameters.Add("@pVOLUME_FACTOR", SqlDbType.Float)
            cmd.Parameters("@pVOLUME_FACTOR").Direction = ParameterDirection.Input
            cmd.Parameters("@pVOLUME_FACTOR").Value = pVOLUME_FACTOR

            cmd.Parameters.Add("@pWEIGTH", SqlDbType.Float)
            cmd.Parameters("@pWEIGTH").Direction = ParameterDirection.Input
            cmd.Parameters("@pWEIGTH").Value = pWEIGTH

            cmd.Parameters.Add("@pCOMMENTS", SqlDbType.VarChar, 250)
            cmd.Parameters("@pCOMMENTS").Direction = ParameterDirection.Input
            cmd.Parameters("@pCOMMENTS").Value = IIf(pCOMMENTS = "", "N/A", pCOMMENTS)

            cmd.Parameters.Add("@pSERIAL", SqlDbType.VarChar, 50)
            cmd.Parameters("@pSERIAL").Direction = ParameterDirection.Input
            cmd.Parameters("@pSERIAL").Value = pSERIAL

            cmd.Parameters.Add("@pAcuerdoComercial", SqlDbType.VarChar, 15)
            cmd.Parameters("@pAcuerdoComercial").Direction = ParameterDirection.Input
            cmd.Parameters("@pAcuerdoComercial").Value = pACUERDO_COMERCIAL

            cmd.Parameters.Add("@pTOTAL_SKUs", SqlDbType.Int)
            cmd.Parameters("@pTOTAL_SKUs").Direction = ParameterDirection.Output
            cmd.Parameters("@pTOTAL_SKUs").Value = 0

            cmd.Parameters.Add("@pSTATUS", SqlDbType.VarChar, 15)
            cmd.Parameters("@pSTATUS").Direction = ParameterDirection.Input
            cmd.Parameters("@pSTATUS").Value = pSTATUS

            cmd.Parameters.Add("@pRESULT", SqlDbType.VarChar, 500)
            cmd.Parameters("@pRESULT").Direction = ParameterDirection.Output
            cmd.Parameters("@pRESULT").Value = ""

            cmd.Parameters.Add("@DATE_EXPIRATION", SqlDbType.Date)
            cmd.Parameters("@DATE_EXPIRATION").Direction = ParameterDirection.Input
            cmd.Parameters("@DATE_EXPIRATION").Value = pDateExpiration

            cmd.Parameters.Add("@BATCH", SqlDbType.VarChar, 15)
            cmd.Parameters("@BATCH").Direction = ParameterDirection.Input
            cmd.Parameters("@BATCH").Value = pBatch

            cmd.Parameters.Add("@VIN", SqlDbType.VarChar, 40)
            cmd.Parameters("@VIN").Direction = ParameterDirection.Input
            cmd.Parameters("@VIN").Value = pVin

            cmd.Parameters.Add("@PARAM_NAME", SqlDbType.VarChar, 50)
            cmd.Parameters("@PARAM_NAME").Direction = ParameterDirection.Input
            cmd.Parameters("@PARAM_NAME").Value = statusName

            cmd.Parameters.Add("@ACTION", SqlDbType.VarChar, 20)
            cmd.Parameters("@ACTION").Direction = ParameterDirection.Input
            cmd.Parameters("@ACTION").Value = action

            cmd.Parameters.Add( "@TONE", SqlDbType.VarChar)
            cmd.Parameters("@TONE").Direction = ParameterDirection.Input
            cmd.Parameters("@TONE").Value = tone

             cmd.Parameters.Add( "@CALIBER", SqlDbType.VarChar)
            cmd.Parameters("@CALIBER").Direction = ParameterDirection.Input
            cmd.Parameters("@CALIBER").Value = caliber

            cmd.CommandText = DefaultSchema & "OP_WMS_SP_AGREGA_SKU_LICENCIA"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldb_conexion



            cmd.ExecuteNonQuery()

            sqldb_conexion.Close()
            pResult = cmd.Parameters("@pRESULT").Value.ToString
            pSKUS_COUNTED = IIf(IsDBNull(cmd.Parameters("@pTOTAL_SKUs").Value), 0, cmd.Parameters("@pTOTAL_SKUs").Value)

            Return pResult = "OK"

        Catch ex As SqlException
            pResult = ex.Message + " " + ex.Source
            Return False
        Finally
            sqldb_conexion.Close()
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try

    End Function


    <WebMethod(Description:="Update Clients")>
    Public Function UpdatePolizaImg(ByVal pPhotoId As Integer, ByVal pComment As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String = ""
        Try
            XSQL = "UPDATE " & DefaultSchema & "OP_WMS_IMAGENES_POLIZA SET "
            XSQL = XSQL + " COMMENTS = '" + pComment + "'"

            XSQL = XSQL + " WHERE "
            XSQL = XSQL + " PHOTO_ID = " + pPhotoId.ToString()
            If ExecuteSqlTransaction(sqldbConexion.ConnectionString, XSQL, pResult) Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            pResult = ex.Message
            Return False
        End Try

    End Function

    <WebMethod(Description:="Agrega serie por material")>
    Public Function AgregarSeriePorMaterial(ByVal licenciaId As Integer, ByVal materialId As String, ByVal serie As String,
                                         ByVal batch As String, ByVal fechaDeExpiracion As Date, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldb_conexion.Open()

        Try

            Dim cmd As New SqlCommand

            cmd.Parameters.Add("@LICENSE_ID", SqlDbType.Int)
            cmd.Parameters("@LICENSE_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@LICENSE_ID").Value = licenciaId

            cmd.Parameters.Add("@MATERIAL_ID", SqlDbType.VarChar)
            cmd.Parameters("@MATERIAL_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@MATERIAL_ID").Value = materialId

            cmd.Parameters.Add("@SERIAL", SqlDbType.VarChar)
            cmd.Parameters("@SERIAL").Direction = ParameterDirection.Input
            cmd.Parameters("@SERIAL").Value = serie

            cmd.Parameters.Add("@BATCH", SqlDbType.VarChar)
            cmd.Parameters("@BATCH").Direction = ParameterDirection.Input
            cmd.Parameters("@BATCH").Value = batch

            If Not String.IsNullOrEmpty(batch) Then
                cmd.Parameters.Add("@DATE_EXPIRATION", SqlDbType.Date)
                cmd.Parameters("@DATE_EXPIRATION").Direction = ParameterDirection.Input
                cmd.Parameters("@DATE_EXPIRATION").Value = fechaDeExpiracion
            End If

            cmd.CommandText = DefaultSchema & "OP_WMS_SP_INSERT_MATERIAL_X_SERIAL_NUMBER"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldb_conexion

            cmd.ExecuteNonQuery()

            sqldb_conexion.Close()
            Return True

        Catch ex As Exception
            pResult = ex.Message
            Return False
        Finally
            sqldb_conexion.Close()
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try

    End Function

    <WebMethod(Description:="Actualiza el lote y fecha de vencimiento de la serie")>
    Public Function ActulizarLoteYFechaDeVencimientoPorSerie(ByVal correlativo As Integer, ByVal batch As Integer, ByVal fechaDeExpiracion As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldb_conexion.Open()

        Try

            Dim cmd As New SqlCommand

            cmd.Parameters.Add("@CORRELATIVE", SqlDbType.Int, 50)
            cmd.Parameters("@CORRELATIVE").Direction = ParameterDirection.Input
            cmd.Parameters("@CORRELATIVE").Value = correlativo

            cmd.Parameters.Add("@BATCH", SqlDbType.VarChar)
            cmd.Parameters("@BATCH").Direction = ParameterDirection.Input
            cmd.Parameters("@BATCH").Value = batch

            cmd.Parameters.Add("@DATE_EXPIRATION", SqlDbType.VarChar, 25)
            cmd.Parameters("@DATE_EXPIRATION").Direction = ParameterDirection.Input
            cmd.Parameters("@DATE_EXPIRATION").Value = fechaDeExpiracion

            cmd.CommandText = DefaultSchema & "OP_WMS_SP_UPDATE_MATERIAL_X_SERIAL_NUMBER"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldb_conexion

            cmd.ExecuteNonQuery()

            sqldb_conexion.Close()
            Return True

        Catch ex As Exception
            pResult = ex.Message
            Return False
        Finally
            sqldb_conexion.Close()
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try

    End Function

    <WebMethod(Description:="Elimina la serie")>
    Public Function EliminarSerie(ByVal correlativo As Integer, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldb_conexion.Open()

        Try

            Dim cmd As New SqlCommand

            cmd.Parameters.Add("@CORRELATIVE", SqlDbType.Int)
            cmd.Parameters("@CORRELATIVE").Direction = ParameterDirection.Input
            cmd.Parameters("@CORRELATIVE").Value = correlativo

            cmd.CommandText = DefaultSchema & "OP_WMS_SP_DELETE_MATERIAL_X_SERIAL_NUMBER"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldb_conexion

            cmd.ExecuteNonQuery()

            sqldb_conexion.Close()
            Return True

        Catch ex As Exception
            pResult = ex.Message
            Return False
        Finally
            sqldb_conexion.Close()
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try

    End Function

    <WebMethod(Description:="Agrega serie por material")>
    Public Function ObtienerInformacionPorMaterialSerie(ByVal materialId As String, ByVal serie As String, licenseId As Integer, ByRef pResult As String, ByVal pEnvironmentName As String) As DataTable

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldb_conexion.Open()

        Try

            Dim cmd As New SqlCommand

            cmd.Parameters.Add("@MATERIAL_ID", SqlDbType.VarChar)
            cmd.Parameters("@MATERIAL_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@MATERIAL_ID").Value = materialId
            
            If Not String.IsNullOrEmpty(serie) Then
                cmd.Parameters.Add("@SERIAL", SqlDbType.VarChar)
                cmd.Parameters("@SERIAL").Direction = ParameterDirection.Input
                cmd.Parameters("@SERIAL").Value = serie
            End If

            cmd.Parameters.Add("@LICENSE_ID", SqlDbType.Int).Value = licenseId
            
            cmd.CommandText = DefaultSchema & "OP_WMS_SP_GET_MATERIAL_X_SERIAL_NUMBER"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldb_conexion

            Dim miscDa As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim miscDt As DataTable = New DataTable("ObtienerInformacionPorMaterialSerie")

            Try
                miscDa.Fill(miscDt)
                sqldb_conexion.Close()
                Return miscDt
            Catch ex As Exception
                pResult = "ERROR," + ex.Message
                Return Nothing
            End Try
        Catch ex As Exception
            pResult = ex.Message
            Return Nothing
        Finally
            sqldb_conexion.Close()
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try

    End Function
End Class