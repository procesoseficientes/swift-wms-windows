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
Public Class WMS_DeliveredLabels
    Inherits System.Web.Services.WebService

    <WebMethod(Description:="Obtiene las etiquetas de una ola de picking")>
    Public Function GetLabelsByWavePicking(wavePickingId As Integer, ByRef result As String, pEnvironmentName As String) As DataTable

        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()

        Try

            Dim cmd As New SqlCommand

            cmd.Parameters.Add("@WAVE_PICKING_ID", SqlDbType.Int).Value = wavePickingId

            cmd.CommandText = $"{DefaultSchema}OP_WMS_SP_GET_LABELS_BY_WAVE_PICKING"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            Dim miscDa As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim miscDt As DataTable = New DataTable("LabelsByWavePicking")

            Try
                miscDa.Fill(miscDt)
                Return miscDt
            Catch ex As Exception
                result = $"ERROR, {ex.Message}"
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

    <WebMethod(Description:="Inserta una nueva entrega de espacho")>
    Public Function InsertDeliveredDispatchHeader(wavePickingId As Integer, status As String, loginId As String, ByRef result As String, pEnvironmentName As String) As DataTable

        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()

        Try

            Dim cmd As New SqlCommand

            cmd.Parameters.Add("@WAVE_PICKING_ID", SqlDbType.Int).Value = wavePickingId
            cmd.Parameters.Add("@STATUS", SqlDbType.VarChar, 25).Value = status
            cmd.Parameters.Add("@CREATE_BY", SqlDbType.VarChar, 50).Value = loginId

            cmd.CommandText = $"{DefaultSchema}OP_WMS_SP_INSERT_DELIVERED_DISPATCH_HEADER"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            Dim miscDa As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim miscDt As DataTable = New DataTable("InsertDeliveredDispatchHeader")

            Try
                miscDa.Fill(miscDt)
                Return miscDt
            Catch ex As Exception
                result = $"ERROR, {ex.Message}"
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

    <WebMethod(Description:="Cambia el estado de la entrega de espacho")>
    Public Function ChangeStatusDEliveredDispatchHeader(deliveredDispatchHeaderId As Integer, status As String, loginId As String, ByRef result As String, pEnvironmentName As String) As DataTable

        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()

        Try

            Dim cmd As New SqlCommand

            cmd.Parameters.Add("@DELIVERED_DISPATCH_HEADER_ID", SqlDbType.Int).Value = deliveredDispatchHeaderId
            cmd.Parameters.Add("@STATUS", SqlDbType.VarChar, 25).Value = status
            cmd.Parameters.Add("@LAST_UPDATE_BY", SqlDbType.VarChar, 50).Value = loginId

            cmd.CommandText = $"{DefaultSchema}OP_WMS_SP_CHANGE_STATUS_DELIVERED_DISPATCH_HEADER"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            Dim miscDa As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim miscDt As DataTable = New DataTable("ChangeStatusDEliveredDispatchHeader")

            Try
                miscDa.Fill(miscDt)
                Return miscDt
            Catch ex As Exception
                result = $"ERROR, {ex.Message}"
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

    <WebMethod(Description:="Devuelve el porcentaje de avace de la entrega de la ola de picking")>
    Public Function ValidateIfDeliveryPickingIsComplete(wavePickingId As Integer, ByRef result As String, pEnvironmentName As String) As DataTable

        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()

        Try

            Dim cmd As New SqlCommand

            cmd.Parameters.Add("@WAVE_PICKING_ID", SqlDbType.Int).Value = wavePickingId

            cmd.CommandText = $"{DefaultSchema}OP_WMS_SP_VALIDATE_IF_DELIVERY_PICKING_IS_COMPLETE"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            Dim miscDa As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim miscDt As DataTable = New DataTable("ValidateIfDeliveryPickingIsComplete")

            Try
                miscDa.Fill(miscDt)
                Return miscDt
            Catch ex As Exception
                result = $"ERROR, {ex.Message}"
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
    Public Function InsertDeliveredLabel(deliveredDispatchHeaderId As Integer, wavePickingId As Integer, labelId As Integer, status As String, loginId As String, ByRef result As String, pEnvironmentName As String) As DataTable

        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()

        Try

            Dim cmd As New SqlCommand

            cmd.Parameters.Add("@DELIVERED_DISPATCH_HEADER_ID", SqlDbType.Int).Value = deliveredDispatchHeaderId
            cmd.Parameters.Add("@WAVE_PICKING_ID", SqlDbType.Int).Value = wavePickingId
            cmd.Parameters.Add("@STATUS", SqlDbType.VarChar, 50).Value = status
            cmd.Parameters.Add("@LABEL_ID", SqlDbType.Int).Value = labelId
            cmd.Parameters.Add("@LOGIN_ID", SqlDbType.VarChar, 50).Value = loginId


            cmd.CommandText = $"{DefaultSchema}OP_WMS_SP_INSERT_DELIVERED_DETAIL"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            Dim miscDa As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim miscDt As DataTable = New DataTable("InsertDeliveredLabel")

            Try
                miscDa.Fill(miscDt)
                Return miscDt
            Catch ex As Exception
                result = $"ERROR, {ex.Message}"
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

    <WebMethod(Description:="Cambia el estado de una etiqueta ")>
    Public Function ChangeLabelStatus(labelId As Integer, status As String, ByRef result As String, pEnvironmentName As String) As DataTable

        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()

        Try

            Dim cmd As New SqlCommand

            cmd.Parameters.Add("@LABEL_ID", SqlDbType.Int).Value = labelId
            cmd.Parameters.Add("@STATUS", SqlDbType.VarChar, 50).Value = status

            cmd.CommandText = $"{DefaultSchema}OP_WMS_SP_CHANGE_LABEL_STATUS"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            Dim miscDa As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim miscDt As DataTable = New DataTable("ChangeLabelStatus")

            Try
                miscDa.Fill(miscDt)
                Return miscDt
            Catch ex As Exception
                result = $"ERROR, {ex.Message}"
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

    <WebMethod(Description:="Elimina una etiqueta entregada")>
    Public Function DeleteDeliveredLabel(labelId As Integer, status As String, ByRef result As String, pEnvironmentName As String) As DataTable

        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()

        Try

            Dim cmd As New SqlCommand

            cmd.Parameters.Add("@LABEL_ID", SqlDbType.Int).Value = labelId
            cmd.Parameters.Add("@STATUS", SqlDbType.VarChar, 50).Value = status

            cmd.CommandText = $"{DefaultSchema}[OP_WMS_SP_DELETE_DELIVERED_DISPATCH_DETAIL]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            Dim miscDa As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim miscDt As DataTable = New DataTable("DeleteDeliveredLabel ")

            Try
                miscDa.Fill(miscDt)
                Return miscDt
            Catch ex As Exception
                result = $"ERROR, {ex.Message}"
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

    <WebMethod(Description:="Obtiene el detalle de la entrega de despacho")>
    Public Function GetDeliveredDispatchDetail(deliveredDispatchHeaderId As Integer, ByRef result As String, pEnvironmentName As String) As DataSet

        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()

        Try

            Dim cmd As New SqlCommand

            cmd.Parameters.Add("@DELIVERED_DISPATCH_HEADER_ID", SqlDbType.Int).Value = deliveredDispatchHeaderId

            cmd.CommandText = $"{DefaultSchema}[OP_WMS_SP_GET_DELIVERED_DISPATCH_DETAIL]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            Dim miscDa As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim miscDs As DataSet = New DataSet()


            Try
                miscDa.Fill(miscDs, "GetDeliveredDispatchDetail")

                cmd = New SqlCommand
                cmd.Parameters.Add("@DELIVERED_DISPATCH_HEADER_ID", SqlDbType.Int).Value = deliveredDispatchHeaderId
                cmd.CommandText = DefaultSchema & "[OP_WMS_SP_GET_DELIVERED_DISPATCH_DETAIL_OF_SERIAL_NUMBER]"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Connection = sqldbConexion
                miscDa = New SqlDataAdapter(cmd)

                miscDa.Fill(miscDs, "GetDeliveredDispatchDetailOfSerialNumber")


                Dim parentColumns = New DataColumn() {miscDs.Tables("GetDeliveredDispatchDetail").Columns("LABEL_ID")}
                Dim childColumns = New DataColumn() {miscDs.Tables("GetDeliveredDispatchDetailOfSerialNumber").Columns("LABEL_ID")}
                miscDs.Relations.Add("Series_Number_By_Material", parentColumns, childColumns, False)

                Return miscDs
            Catch ex As Exception
                result = $"ERROR, {ex.Message}"
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