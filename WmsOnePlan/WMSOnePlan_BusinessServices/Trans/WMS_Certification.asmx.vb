Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Configuration.ConfigurationManager

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")>
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)>
<ToolboxItem(False)>
Public Class WMS_Certification
    Inherits System.Web.Services.WebService

    <WebMethod(Description:="Obtiene el encabezado del manifiesto")>
    Public Function GetManifiestHeader(manifestHeader As Integer, ByRef result As String, pEnvironmentName As String) As DataTable

        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()

        Try

            Dim cmd As New SqlCommand

            cmd.Parameters.Add("@MANIFEST_HEADER_ID", SqlDbType.Int).Value = manifestHeader

            cmd.CommandText = DefaultSchema & "OP_WMS_SP_GET_MANIFEST_HEADER_FOR_CERTIFICATION"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            Dim miscDa As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim miscDt As DataTable = New DataTable("GetManifiestHeader")

            Try
                miscDa.Fill(miscDt)
                Return miscDt
            Catch ex As Exception
                result = "ERROR," + ex.Message
                Return Nothing
            End Try
        Catch ex As Exception
            result = ex.Message
            Return Nothing
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
            sqldbConexion = Nothing
        End Try

    End Function

    <WebMethod(Description:="Obtiene la data de la etiqueta para manifiesto")>
    Public Function GetLabelDataForManifest(manifestHeaderId As Integer, labelId As Integer, ByRef result As String, pEnvironmentName As String) As DataTable

        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()

        Try

            Dim cmd As New SqlCommand

            cmd.Parameters.Add("@MANIFEST_HEADER_ID", SqlDbType.Int).Value = manifestHeaderId
            cmd.Parameters.Add("@LABEL_ID", SqlDbType.Int).Value = labelId

            cmd.CommandText = DefaultSchema & "OP_WMS_SP_GET_LABEL_DATA_FOR_MANIFEST"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            Dim miscDa As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim miscDt As DataTable = New DataTable("GetLabelDataForManifest")

            Try
                miscDa.Fill(miscDt)
                Return miscDt
            Catch ex As Exception
                result = "ERROR," + ex.Message
                Return Nothing
            End Try
        Catch ex As Exception
            result = ex.Message
            Return Nothing
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
            sqldbConexion = Nothing
        End Try
    End Function

    <WebMethod(Description:="Marca el manifiesto como certificado")>
    Public Function MarkManifestAsCertified(manifestHeaderId As Integer, certificationHeaderId As Integer, lastUpdateBy As String, ByRef result As String, pEnvironmentName As String) As DataTable

        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()

        Try

            Dim cmd As New SqlCommand

            cmd.Parameters.Add("@MANIFEST_HEADER_ID", SqlDbType.Int).Value = manifestHeaderId
            cmd.Parameters.Add("@CERTIFICATION_HEADER_ID", SqlDbType.Int).Value = certificationHeaderId
            cmd.Parameters.Add("@LAST_UPDATE_BY", SqlDbType.VarChar).Value = lastUpdateBy

            cmd.CommandText = DefaultSchema & "OP_WMS_SP_MARK_MANIFEST_AS_CERTIFIED"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            Dim miscDa As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim miscDt As DataTable = New DataTable("MarkManifestAsCertified")

            Try
                miscDa.Fill(miscDt)
                Return miscDt
            Catch ex As Exception
                result = "ERROR," + ex.Message
                Return Nothing
            End Try
        Catch ex As Exception
            result = ex.Message
            Return Nothing
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
            sqldbConexion = Nothing
        End Try
    End Function

    <WebMethod(Description:="Insertar el encabezado del certificado")>
    Public Function InsertCertificationHeader(certificationHeaderId As Integer, createBy As String, ByRef result As String, pEnvironmentName As String) As DataTable

        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()

        Try

            Dim cmd As New SqlCommand

            cmd.Parameters.Add("@MANIFEST_HEADER_ID", SqlDbType.Int).Value = certificationHeaderId
            cmd.Parameters.Add("@CREATE_BY", SqlDbType.VarChar).Value = createBy

            cmd.CommandText = DefaultSchema & "OP_WMS_SP_INSERT_CERTIFICATION_HEADER"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            Dim miscDa As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim miscDt As DataTable = New DataTable("InsertCertificationHeader")

            Try
                miscDa.Fill(miscDt)
                Return miscDt
            Catch ex As Exception
                result = "ERROR," + ex.Message
                Return Nothing
            End Try
        Catch ex As Exception
            result = ex.Message
            Return Nothing
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
            sqldbConexion = Nothing
        End Try
    End Function


    <WebMethod(Description:="Inserta un detalle para el certificado ")>
    Public Function InsertCertificationDetail(certificationHeaderId As Integer, labelId As Integer, qty As Decimal, certificationType As String, lastUpdate As String, materialId As String, boxBarCode As string, ByRef result As String, pEnvironmentName As String) As DataTable

        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()

        Try

            Dim cmd As New SqlCommand

            cmd.Parameters.Add("@CERTIFICATION_HEADER_ID", SqlDbType.Int).Value = certificationHeaderId
            If labelId > 0 Then
                cmd.Parameters.Add("@LABEL_ID", SqlDbType.Int).Value = labelId
            End If

            cmd.Parameters.Add("@QTY", SqlDbType.Decimal).Value = qty
            cmd.Parameters.Add("@CERTIFICATION_TYPE", SqlDbType.VarChar).Value = certificationType
            cmd.Parameters.Add("@LAST_UPDATE", SqlDbType.VarChar).Value = lastUpdate
            cmd.Parameters.Add("@MATERIAL_ID", SqlDbType.VarChar).Value = materialId

            If Not String.IsNullOrEmpty(boxBarCode) then
                cmd.Parameters.Add("@BOX_BARCODE", SqlDbType.VarChar).Value = boxBarCode
            End If

            cmd.CommandText = DefaultSchema & "OP_WMS_SP_INSERT_CERTIFICATION_DETAIL"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            Dim miscDa As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim miscDt As DataTable = New DataTable("InsertCertificationDetail")

            Try
                miscDa.Fill(miscDt)
                Return miscDt
            Catch ex As Exception
                result = "ERROR," + ex.Message
                Return Nothing
            End Try
        Catch ex As Exception
            result = ex.Message
            Return Nothing
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
            sqldbConexion = Nothing
        End Try
    End Function

    <WebMethod(Description:="Elimina un detalle del certificado")>
    Public Function DeleteCertificationDetail(certificationDetailrId As Integer, boxBarCode As String,ByRef result As String, pEnvironmentName As String) As DataTable

        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()

        Try

            Dim cmd As New SqlCommand

            cmd.Parameters.Add("@CERTIFICATION_DETAIL_ID", SqlDbType.Int).Value = certificationDetailrId
            if(not String.IsNullOrEmpty(boxBarCode))then
                cmd.Parameters.Add("@BOX_BARCODE", SqlDbType.VarChar,50).Value = boxBarCode
            End If

            cmd.CommandText = DefaultSchema & "OP_WMS_SP_DELETE_CERTIFICATION_DETAIL"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            Dim miscDa As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim miscDt As DataTable = New DataTable("DeleteCertificationDetail")

            Try
                miscDa.Fill(miscDt)
                Return miscDt
            Catch ex As Exception
                result = "ERROR," + ex.Message
                Return Nothing
            End Try
        Catch ex As Exception
            result = ex.Message
            Return Nothing
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
            sqldbConexion = Nothing
        End Try
    End Function

    <WebMethod(Description:="Elimina un detalle del certificado")>
    Public Function GetMaterialForManifest(manifestHeaderId As Integer, barcodeId As String, ByRef result As String, pEnvironmentName As String) As DataTable

        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()

        Try

            Dim cmd As New SqlCommand

            cmd.Parameters.Add("@MANIFEST_HEADER_ID", SqlDbType.Int).Value = manifestHeaderId
            cmd.Parameters.Add("@BARCODE_ID", SqlDbType.VarChar).Value = barcodeId

            cmd.CommandText = DefaultSchema & "OP_WMS_SP_GET_MATERIAL_FOR_MANIFEST"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            Dim miscDa As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim miscDt As DataTable = New DataTable("GetMaterialForManifest")

            Try
                miscDa.Fill(miscDt)
                Return miscDt
            Catch ex As Exception
                result = "ERROR," + ex.Message
                Return Nothing
            End Try
        Catch ex As Exception
            result = ex.Message
            Return Nothing
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
            sqldbConexion = Nothing
        End Try
    End Function

    <WebMethod(Description:="Valida si la certificacion esta completa.")>
    Public Function ValidateIfCertificationIsComplete(certificationHeaderId As Integer, ByRef result As String, pEnvironmentName As String) As DataTable

        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()

        Try

            Dim cmd As New SqlCommand

            cmd.Parameters.Add("@CERTIFICATION_HEADER_ID", SqlDbType.Int).Value = certificationHeaderId

            cmd.CommandText = DefaultSchema & "OP_WMS_SP_VALIDATE_IF_CERTIFICATION_IS_COMPLETE"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            Dim miscDa As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim miscDt As DataTable = New DataTable("ValidateIfCertificationIsComplete")

            Try
                miscDa.Fill(miscDt)
                Return miscDt
            Catch ex As Exception
                result = "ERROR," + ex.Message
                Return Nothing
            End Try
        Catch ex As Exception
            result = ex.Message
            Return Nothing
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
            sqldbConexion = Nothing
        End Try
    End Function

    <WebMethod(Description:="Obtiene el detalle consolidado de la certificacion.")>
    Public Function GetCertificationDetailConsolidated(certificationHeaderId As Integer, ByRef result As String, pEnvironmentName As String) As DataSet

        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()

        Try

            Dim cmd As New SqlCommand

            cmd.Parameters.Add("@CERTIFICATION_HEADER_ID", SqlDbType.Int).Value = certificationHeaderId

            cmd.CommandText = DefaultSchema & "OP_WMS_SP_GET_CERTIFICATION_DETAIL_CONSOLIDATED"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            Dim miscDa As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim miscDs As DataSet = New DataSet() 'DataTable("GetCertificationDetailConsolidated")


            Try
                miscDa.Fill(miscDs, "GetCertificationDetailConsolidated")

                cmd = New SqlCommand
                cmd.Parameters.Add("@CERTIFICATION_HEADER_ID", SqlDbType.Int).Value = certificationHeaderId
                cmd.CommandText = DefaultSchema & "OP_WMS_GET_CERTIFICATION_DETAIL_OF_SERIAL_NUMBER"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Connection = sqldbConexion
                miscDa = New SqlDataAdapter(cmd)

                miscDa.Fill(miscDs, "GetCertificationDetailOfSerialNumber")


                Dim parentColumns = New DataColumn() {miscDS.Tables("GetCertificationDetailConsolidated").Columns("CERTIFICATION_TYPE"), miscDS.Tables("GetCertificationDetailConsolidated").Columns("MATERIAL_ID") }
                Dim childColumns = New DataColumn() {miscDS.Tables("GetCertificationDetailOfSerialNumber").Columns("CERTIFICATION_TYPE"), miscDS.Tables("GetCertificationDetailOfSerialNumber").Columns("MATERIAL_ID")}
                miscDS.Relations.Add("Series_Number_By_Material", parentColumns, childColumns, False)

                Return miscDs
            Catch ex As Exception
                result = "ERROR," + ex.Message
                Return Nothing
            End Try
        Catch ex As Exception
            result = ex.Message
            Return Nothing
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
            sqldbConexion = Nothing
        End Try
    End Function


    <WebMethod(Description:="Inserta el numero de serie para la certificacion")>
    Public Function InsertCertificationBySerialNumber(certificationHeaderId As Integer, manifestHeaderId As Integer, materialId As String, serialNumber As String, ByRef result As String, pEnvironmentName As String) As DataTable

        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()

        Try

            Dim cmd As New SqlCommand

            cmd.Parameters.Add("@CERTIFICATION_HEADER_ID", SqlDbType.Int).Value = certificationHeaderId
            cmd.Parameters.Add("@MANIFEST_HEDAER_ID", SqlDbType.Int).Value = manifestHeaderId
            cmd.Parameters.Add("@MATERIAL_ID", SqlDbType.VarChar).Value = materialId
            cmd.Parameters.Add("@SERIAL_NUMBER", SqlDbType.VarChar).Value = serialNumber

            cmd.CommandText = DefaultSchema & "OP_WMS_INSERT_CERTIFICATION_BY_SERIAL_NUMBER"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            Dim miscDa As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim miscDt As DataTable = New DataTable("InsertCertificationBySerialNumber")

            Try
                miscDa.Fill(miscDt)
                Return miscDt
            Catch ex As Exception
                result = "ERROR," + ex.Message
                Return Nothing
            End Try
        Catch ex As Exception
            result = ex.Message
            Return Nothing
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
            sqldbConexion = Nothing
        End Try
    End Function

    <WebMethod(Description:="Elimina el numero de serie.")>
    Public Function DeleteCertificationBySerialNumber(certificationHeaderId As Integer, materialId As String, serialNumber As String, ByRef result As String, pEnvironmentName As String) As DataTable

        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()

        Try

            Dim cmd As New SqlCommand

            cmd.Parameters.Add("@CERTIFICATION_HEADER_ID", SqlDbType.Int).Value = certificationHeaderId
            cmd.Parameters.Add("@MATERIAL_ID", SqlDbType.VarChar).Value = materialId
            cmd.Parameters.Add("@SERIAL_NUMBER", SqlDbType.VarChar).Value = serialNumber

            cmd.CommandText = DefaultSchema & "[OP_WMS_SP_DELETE_CERTIFICATION_BY_SERIAL_NUMBER]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            Dim miscDa As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim miscDt As DataTable = New DataTable("DeleteCertificationBySerialNumber")

            Try
                miscDa.Fill(miscDt)
                Return miscDt
            Catch ex As Exception
                result = "ERROR," + ex.Message
                Return Nothing
            End Try
        Catch ex As Exception
            result = ex.Message
            Return Nothing
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
            sqldbConexion = Nothing
        End Try
    End Function

End Class