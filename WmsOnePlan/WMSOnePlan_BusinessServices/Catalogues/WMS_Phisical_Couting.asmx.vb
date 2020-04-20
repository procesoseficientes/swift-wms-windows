Imports System.Web.Services
Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Configuration.ConfigurationManager

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")>
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)>
<ToolboxItem(False)>
Public Class WMS_Phisical_Couting
    Inherits System.Web.Services.WebService


    <WebMethod()>
    Public Function GetMyCountingTask(login As String, ByRef result As String, pEnvironmentName As String) As DataTable
        Dim sqldbConexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()
        Try
            Dim cmd As New SqlCommand
            Dim reader As SqlDataReader
            Dim dt = New DataTable("GetMyCountingTask")
            cmd.CommandText = String.Format("{0}OP_WMS_SP_GET_MY_COUTING_TASK", DefaultSchema)
            cmd.Parameters.Add("@LOGIN", SqlDbType.VarChar)
            cmd.Parameters("@LOGIN").Value = login


            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            reader = cmd.ExecuteReader()

            dt.Load(reader)
            sqldbConexion.Close()
            Return dt
        Catch ex As Exception
            result = ex.Message
            Return Nothing
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try
    End Function

    <WebMethod()>
    Public Function GetLocationsForCount(login As String, taskId As Integer, ByRef result As String, pEnvironmentName As String) As DataTable
        Dim sqldbConexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()
        Try
            Dim cmd As New SqlCommand
            Dim reader As SqlDataReader
            Dim dt = New DataTable("GetLocationsForCount")
            cmd.CommandText = String.Format("{0}OP_WMS_SP_GET_LOCATIONS_FOR_COUNT", DefaultSchema)
            cmd.Parameters.Add("@LOGIN", SqlDbType.VarChar)
            cmd.Parameters("@LOGIN").Value = login

            cmd.Parameters.Add("@TASK_ID", SqlDbType.Int)
            cmd.Parameters("@TASK_ID").Value = taskId

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            reader = cmd.ExecuteReader()

            dt.Load(reader)
            sqldbConexion.Close()
            Return dt
        Catch ex As Exception
            result = ex.Message
            Return Nothing
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try
    End Function

    <WebMethod()>
    Public Function GetNextMaterialForCount(login As String, taskId As Integer, location As String, ByRef result As String, pEnvironmentName As String) As DataTable
        Dim sqldbConexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()
        Try
            Dim cmd As New SqlCommand
            Dim reader As SqlDataReader
            Dim dt = New DataTable("GetNextMaterialForCount")
            cmd.CommandText = String.Format("{0}OP_WMS_SP_GET_NEXT_MATERIAL_FOR_COUNT", DefaultSchema)
            cmd.Parameters.Add("@LOGIN", SqlDbType.VarChar)
            cmd.Parameters("@LOGIN").Value = login

            cmd.Parameters.Add("@TASK_ID", SqlDbType.Int)
            cmd.Parameters("@TASK_ID").Value = taskId

            cmd.Parameters.Add("@LOCATION", SqlDbType.VarChar)
            cmd.Parameters("@LOCATION").Value = location

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            reader = cmd.ExecuteReader()

            dt.Load(reader)
            sqldbConexion.Close()
            Return dt
        Catch ex As Exception
            result = ex.Message
            Return Nothing
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try
    End Function

    <WebMethod()>
    Public Function InsertCountExecution(login As String, taskId As Integer, location As String, licenseId As Integer, materialId As String, qtyScanned As Decimal, expirationDet As Nullable(Of DateTime), batch As String, serial As String, ByRef result As String, pEnvironmentName As String) As Boolean
        Dim sqldbConexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = String.Format("{0}OP_WMS_SP_INSERT_COUNT_EXECUTION", DefaultSchema)
            cmd.Parameters.Add("@LOGIN", SqlDbType.VarChar)
            cmd.Parameters("@LOGIN").Value = login

            cmd.Parameters.Add("@TASK_ID", SqlDbType.Int)
            cmd.Parameters("@TASK_ID").Value = taskId

            cmd.Parameters.Add("@LOCATION", SqlDbType.VarChar)
            cmd.Parameters("@LOCATION").Value = location

            cmd.Parameters.Add("@LICENSE_ID", SqlDbType.Int)
            cmd.Parameters("@LICENSE_ID").Value = licenseId

            cmd.Parameters.Add("@MATERIAL_ID", SqlDbType.VarChar)
            cmd.Parameters("@MATERIAL_ID").Value = materialId

            cmd.Parameters.Add("@QTY_SCANNED", SqlDbType.Decimal)
            cmd.Parameters("@QTY_SCANNED").Value = qtyScanned

            cmd.Parameters.Add("@EXPIRATION_DATE", SqlDbType.DateTime)
            cmd.Parameters("@EXPIRATION_DATE").Value = expirationDet

            cmd.Parameters.Add("@BATCH", SqlDbType.VarChar)
            cmd.Parameters("@BATCH").Value = IIf(String.IsNullOrEmpty(batch), Nothing, batch)
            cmd.Parameters.Add("@SERIAL", SqlDbType.VarChar)
            cmd.Parameters("@SERIAL").Value = IIf(String.IsNullOrEmpty(serial), Nothing, serial)

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            cmd.ExecuteNonQuery()
            sqldbConexion.Close()
            Return True
        Catch ex As Exception
            result = ex.Message
            Return Nothing
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try
    End Function

    <WebMethod()>
    Public Function RecountLocation(login As String, taskId As Integer, location As String, ByRef result As String, pEnvironmentName As String) As DataTable
        Dim sqldbConexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()
        Try
            Dim cmd As New SqlCommand
            Dim reader As SqlDataReader
            Dim dt = New DataTable("RecountLocation")
            cmd.CommandText = String.Format("{0}OP_WMS_SP_RECOUNT_LOCATION", DefaultSchema)
            cmd.Parameters.Add("@LOGIN", SqlDbType.VarChar)
            cmd.Parameters("@LOGIN").Value = login

            cmd.Parameters.Add("@TASK_ID", SqlDbType.Int)
            cmd.Parameters("@TASK_ID").Value = taskId

            cmd.Parameters.Add("@LOCATION", SqlDbType.VarChar)
            cmd.Parameters("@LOCATION").Value = location

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            reader = cmd.ExecuteReader()

            dt.Load(reader)
            sqldbConexion.Close()
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                result = dt.Rows(0)(0)
            Else
                result = "Ocurrió un error inesperado al preparar el reconteo."
            End If


            Return dt
        Catch ex As Exception
            result = ex.Message
            Return Nothing
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try
    End Function

    <WebMethod()>
    Public Function FinishLocation(login As String, taskId As Integer, location As String, ByRef result As String, pEnvironmentName As String) As DataTable
        Dim sqldbConexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()
        Try
            Dim cmd As New SqlCommand
            Dim reader As SqlDataReader
            Dim dt = New DataTable("FinishLocation")
            cmd.CommandText = String.Format("{0}OP_WMS_SP_FINISH_LOCATION", DefaultSchema)
            cmd.Parameters.Add("@LOGIN", SqlDbType.VarChar)
            cmd.Parameters("@LOGIN").Value = login

            cmd.Parameters.Add("@TASK_ID", SqlDbType.Int)
            cmd.Parameters("@TASK_ID").Value = taskId

            cmd.Parameters.Add("@LOCATION", SqlDbType.VarChar)
            cmd.Parameters("@LOCATION").Value = location

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            reader = cmd.ExecuteReader()

            dt.Load(reader)
            sqldbConexion.Close()
            Return dt
        Catch ex As Exception
            result = ex.Message
            Return Nothing
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try
    End Function

    <WebMethod()>
    Public Function ValidateScannedLocationForCountingTask(login As String, taskId As Integer, location As String, ByRef result As String, pEnvironmentName As String) As DataTable
        Dim sqldbConexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()
        Try
            Dim cmd As New SqlCommand
            Dim reader As SqlDataReader
            Dim dt = New DataTable("ValidateScannedLocationForCountingTask")
            cmd.CommandText = String.Format("{0}OP_WMS_SP_VALIDATE_SCANNED_LOCATION_FOR_COUNT", DefaultSchema)
            cmd.Parameters.Add("@LOGIN", SqlDbType.VarChar)
            cmd.Parameters("@LOGIN").Value = login

            cmd.Parameters.Add("@TASK_ID", SqlDbType.Int)
            cmd.Parameters("@TASK_ID").Value = taskId

            cmd.Parameters.Add("@LOCATION", SqlDbType.VarChar)
            cmd.Parameters("@LOCATION").Value = location

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            reader = cmd.ExecuteReader()

            dt.Load(reader)
            sqldbConexion.Close()
            Return dt
        Catch ex As Exception
            result = ex.Message
            Return Nothing
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try


    End Function

    <WebMethod()>
    Public Function ValidateScannedMaterialForCountingTask(login As String, taskId As Integer,
                        location As String, licence As Integer, materialId As String, batch As String,
                        serial As String, ByRef result As String, pEnvironmentName As String) As DataTable
        Dim sqldbConexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()
        Try
            Dim cmd As New SqlCommand
            Dim reader As SqlDataReader
            Dim dt = New DataTable("ValidateScannedMaterialForCountingTask")
            cmd.CommandText = String.Format("{0}OP_WMS_SP_VALIDATE_RECOUNTED_MATERIAL_FOR_TASK", DefaultSchema)
            cmd.Parameters.Add("@LOGIN", SqlDbType.VarChar)
            cmd.Parameters("@LOGIN").Value = login

            cmd.Parameters.Add("@TASK_ID", SqlDbType.Int)
            cmd.Parameters("@TASK_ID").Value = taskId

            cmd.Parameters.Add("@LOCATION", SqlDbType.VarChar)
            cmd.Parameters("@LOCATION").Value = location

            cmd.Parameters.Add("@LICENCE_ID", SqlDbType.VarChar)
            cmd.Parameters("@LICENCE_ID").Value = licence

            cmd.Parameters.Add("@MATERIAL_ID", SqlDbType.VarChar)
            cmd.Parameters("@MATERIAL_ID").Value = materialId

            cmd.Parameters.Add("@BATCH", SqlDbType.VarChar)
            cmd.Parameters("@BATCH").Value = IIf(String.IsNullOrEmpty(batch), Nothing, batch)

            cmd.Parameters.Add("@SERIAL", SqlDbType.VarChar)
            cmd.Parameters("@SERIAL").Value = IIf(String.IsNullOrEmpty(serial), Nothing, serial)

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            reader = cmd.ExecuteReader()

            dt.Load(reader)
            sqldbConexion.Close()
            Return dt
        Catch ex As Exception
            result = ex.Message
            Return Nothing
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try


    End Function


    <WebMethod()>
    Public Function GetScannedMaterial(licence As Integer, barcodeId As String, ByRef result As String, pEnvironmentName As String) As DataTable
        Dim sqldbConexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()
        Try
            Dim cmd As New SqlCommand
            Dim reader As SqlDataReader
            Dim dt = New DataTable("GetScannedMaterial")
            cmd.CommandText = String.Format("{0}OP_WMS_SP_GET_MATERIAL_BY_BARCODE", DefaultSchema)

            cmd.Parameters.Add("@LICENCE_ID", SqlDbType.VarChar)
            cmd.Parameters("@LICENCE_ID").Value = licence

            cmd.Parameters.Add("@BARCODE_ID", SqlDbType.VarChar)
            cmd.Parameters("@BARCODE_ID").Value = barcodeId

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            reader = cmd.ExecuteReader()

            dt.Load(reader)

            sqldbConexion.Close()
            result = "OK"
            If dt Is Nothing Or dt.Rows.Count = 0 Then
                result = "No se encontró información del material."
            End If

            Return dt
        Catch ex As Exception
            result = ex.Message
            Return Nothing
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try


    End Function

    <WebMethod()>
    Public Function ValidateScannedLicence(licence As Integer, ByRef result As String, pEnvironmentName As String) As Boolean
        Dim sqldbConexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()
        result = "OK"
        Try
            Dim cmd As New SqlCommand
            Dim dt = New DataTable("ValidateScannedLicence")

            cmd.CommandText = String.Format("{0}OP_WMS_SP_GET_IS_VALID_LICENCE", DefaultSchema)

            cmd.Parameters.Add("@LICENCE_ID", SqlDbType.VarChar)
            cmd.Parameters("@LICENCE_ID").Value = licence

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            cmd.ExecuteNonQuery()
            sqldbConexion.Close()

            Return True
        Catch ex As Exception
            result = ex.Message
            Return False
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try


    End Function
End Class