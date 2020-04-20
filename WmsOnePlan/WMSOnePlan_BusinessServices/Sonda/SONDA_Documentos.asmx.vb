Imports System.Web.Services
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Web.Services.Protocols
Imports System.Configuration.ConfigurationManager

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class SONDA_Documentos
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Function CrearHeader(ByVal HeaderDataSet As DataSet, ByVal pEnvironmentName As String, ByRef pResult As String) As Boolean
        pResult = "OK"
        Try

            Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
            Dim cmd As SqlCommand = Nothing

            Dim pDocumento As SqlParameter = Nothing
            Dim pGPS_Lat As SqlParameter = Nothing
            Dim pGPS_Lon As SqlParameter = Nothing
            Dim pFotografia As SqlParameter = Nothing

            cmd = New SqlCommand("SONDA_SP_CREATE_HEADER", sqldb_conexion)
            cmd.CommandType = System.Data.CommandType.StoredProcedure

            pDocumento = New SqlParameter("@Documento", SqlDbType.VarChar, 50)
            pDocumento.Value = HeaderDataSet.Tables(0).Rows(0)("Documento").ToString

            pGPS_Lat = New SqlParameter("@GPS_Lat", SqlDbType.VarChar, 15)
            pGPS_Lat.Value = HeaderDataSet.Tables(0).Rows(0)("GPS_Lat").ToString

            pGPS_Lon = New SqlParameter("@GPS_Lon", SqlDbType.VarChar, 15)
            pGPS_Lon.Value = HeaderDataSet.Tables(0).Rows(0)("GPS_Lon").ToString

            pFotografia = New SqlParameter("@Picture", SqlDbType.Image)
            pFotografia.Value = HeaderDataSet.Tables(0).Rows(0)("fotografia")

            cmd.Parameters.Add(pDocumento)
            cmd.Parameters.Add(pGPS_Lat)
            cmd.Parameters.Add(pGPS_Lon)
            cmd.Parameters.Add(pFotografia)

            sqldb_conexion.Open()
            cmd.ExecuteNonQuery()
            sqldb_conexion.Close()

            pResult = "OK"
            Return True
        Catch ex As Exception
            pResult = ex.Message
            Return False
        End Try
        Return True
    End Function

End Class