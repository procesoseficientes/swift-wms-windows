Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Configuration.ConfigurationManager
Imports System.ComponentModel
Imports System.Data.SqlClient
Imports WMSOnePlan_BusinessServices.ModuleServices


' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
<System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class WMS_ServicesToBill
    Inherits System.Web.Services.WebService
    <WebMethod()> _
    Public Function GetAllServicesNotRelated(ByVal pCLIENT_ERP_CODE As Integer, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Try
            Dim sqldb_conexion As SqlConnection
            Dim XSQL As String = ""
            Try
                sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
            Catch ex As Exception
                pResult = ex.Message
                Return Nothing
            End Try
            XSQL = "SELECT * FROM  " + DefaultSchema + "[OP_WMS_FUNC_GET_SERVICES_AVAILABLE_TO_BILL]('" & pCLIENT_ERP_CODE & "')"

            sqldb_conexion.Open()
            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()
            Try
                miscDA.Fill(miscDS, "GetAllServicesNotRelated")
                If miscDS.Tables(0).Rows.Count <= 0 Then
                    pResult = "ERROR,No hay servicios disponibles para el cliente: " & pCLIENT_ERP_CODE
                    sqldb_conexion.Close()
                    Return Nothing
                Else
                    pResult = "OK"
                    sqldb_conexion.Close()
                    Return miscDS
                End If
            Catch ex As Exception
                sqldb_conexion.Close()
                pResult = "ERROR," + ex.Message
                Return Nothing
            End Try
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
    End Function
    <WebMethod()> _
    Public Function GetAllServicesRelatedTo(ByVal pCLIENT_ERP_CODE As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Try
            Dim sqldb_conexion As SqlConnection
            Dim XSQL As String = ""
            Try
                sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
            Catch ex As Exception
                pResult = ex.Message
                Return Nothing
            End Try
            XSQL = "SELECT * FROM  " + DefaultSchema + "[OP_WMS_FUNC_GET_SERVICES_RELATED]('" + pCLIENT_ERP_CODE + "')"

            sqldb_conexion.Open()
            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()
            Try
                miscDA.Fill(miscDS, "GetAllServicesRelatedTo")
                If miscDS.Tables(0).Rows.Count <= 0 Then
                    pResult = "ERROR,No hay servicios relacionados para el cliente: " + pCLIENT_ERP_CODE
                    sqldb_conexion.Close()
                    Return Nothing
                Else
                    pResult = "OK"
                    sqldb_conexion.Close()
                    Return miscDS
                End If
            Catch ex As Exception
                sqldb_conexion.Close()
                pResult = "ERROR," + ex.Message
                Return Nothing
            End Try
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
    End Function

    <WebMethod()> _
    Public Function RelateServiceTo(ByVal pCLIENT_ERP_CODE As String, ByVal pSERVICE_ID As String, ByVal pLOGIN_ID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean
        Dim sqldb_conexion As SqlConnection = Nothing

        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
            sqldb_conexion.Open()

            Dim cmd As New SqlCommand

            cmd.Parameters.Add("@pCLIENT_ERP_CODE", SqlDbType.VarChar, 50)
            cmd.Parameters("@pCLIENT_ERP_CODE").Direction = ParameterDirection.Input
            cmd.Parameters("@pCLIENT_ERP_CODE").Value = pCLIENT_ERP_CODE

            cmd.Parameters.Add("@pSERVICE_ID", SqlDbType.VarChar, 50)
            cmd.Parameters("@pSERVICE_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@pSERVICE_ID").Value = pSERVICE_ID

            cmd.Parameters.Add("@pLOGIN_ID", SqlDbType.VarChar, 25)
            cmd.Parameters("@pLOGIN_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@pLOGIN_ID").Value = pLOGIN_ID

            cmd.Parameters.Add("@pRESULT", SqlDbType.VarChar, 250)
            cmd.Parameters("@pRESULT").Direction = ParameterDirection.Output
            cmd.Parameters("@pRESULT").Value = ""
            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_RELATE_SERVICE_TO]"

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
    <WebMethod()> _
    Public Function UnRelateServiceTo(ByVal pCLIENT_ERP_CODE As String, ByVal pSERVICE_SEQUENCE As Integer, ByVal pLOGIN_ID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean
        Dim sqldb_conexion As SqlConnection = Nothing

        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
            sqldb_conexion.Open()

            Dim cmd As New SqlCommand

            cmd.Parameters.Add("@pCLIENT_ERP_CODE", SqlDbType.VarChar, 50)
            cmd.Parameters("@pCLIENT_ERP_CODE").Direction = ParameterDirection.Input
            cmd.Parameters("@pCLIENT_ERP_CODE").Value = pCLIENT_ERP_CODE

            cmd.Parameters.Add("@pSERVICE_ID", SqlDbType.VarChar, 15)
            cmd.Parameters("@pSERVICE_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@pSERVICE_ID").Value = pSERVICE_SEQUENCE

            cmd.Parameters.Add("@pLOGIN_ID", SqlDbType.VarChar, 25)
            cmd.Parameters("@pLOGIN_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@pLOGIN_ID").Value = pLOGIN_ID

            cmd.Parameters.Add("@pRESULT", SqlDbType.VarChar, 250)
            cmd.Parameters("@pRESULT").Direction = ParameterDirection.Output
            cmd.Parameters("@pRESULT").Value = ""
            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_UNRELATE_SERVICE_TO]"

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
    <WebMethod()> _
    Public Function UpdateServiceComments(ByVal pCLIENT_ERP_CODE As String, ByVal pSERVICE_ID As String, _
                                          ByVal pCOMMENTS As String, pREFERENCES As String, ByVal pLOGIN_ID As String, _
                                          ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean
        Dim sqldb_conexion As SqlConnection = Nothing

        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
            sqldb_conexion.Open()

            Dim cmd As New SqlCommand

            cmd.Parameters.Add("@pCLIENT_ERP_CODE", SqlDbType.Int)
            cmd.Parameters("@pCLIENT_ERP_CODE").Direction = ParameterDirection.Input
            cmd.Parameters("@pCLIENT_ERP_CODE").Value = pCLIENT_ERP_CODE

            cmd.Parameters.Add("@pSERVICE_ID", SqlDbType.VarChar, 15)
            cmd.Parameters("@pSERVICE_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@pSERVICE_ID").Value = pSERVICE_ID

            cmd.Parameters.Add("@pCOMMENTS", SqlDbType.VarChar)
            cmd.Parameters("@pCOMMENTS").Direction = ParameterDirection.Input
            cmd.Parameters("@pCOMMENTS").Value = pCOMMENTS

            cmd.Parameters.Add("@pREFERENCES", SqlDbType.VarChar)
            cmd.Parameters("@pREFERENCES").Direction = ParameterDirection.Input
            cmd.Parameters("@pREFERENCES").Value = pREFERENCES

            cmd.Parameters.Add("@pLOGIN_ID", SqlDbType.VarChar, 25)
            cmd.Parameters("@pLOGIN_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@pLOGIN_ID").Value = pLOGIN_ID

            cmd.Parameters.Add("@pRESULT", SqlDbType.VarChar, 250)
            cmd.Parameters("@pRESULT").Direction = ParameterDirection.Output
            cmd.Parameters("@pRESULT").Value = ""
            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_UPDATE_SERVICE_COMMENTS]"

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
    <WebMethod()> _
    Public Function UpdateService(ByVal pCLIENT_ERP_CODE As String, ByVal pSERVICE_ID As String, ByVal pLOGIN_ID As String, ByVal pQTY As Double, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean
        Dim sqldb_conexion As SqlConnection = Nothing

        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
            sqldb_conexion.Open()

            Dim cmd As New SqlCommand

            cmd.Parameters.Add("@pCLIENT_ERP_CODE", SqlDbType.VarChar, 50)
            cmd.Parameters("@pCLIENT_ERP_CODE").Direction = ParameterDirection.Input
            cmd.Parameters("@pCLIENT_ERP_CODE").Value = pCLIENT_ERP_CODE

            cmd.Parameters.Add("@pSERVICE_ID", SqlDbType.VarChar, 15)
            cmd.Parameters("@pSERVICE_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@pSERVICE_ID").Value = pSERVICE_ID

            cmd.Parameters.Add("@pQTY", SqlDbType.Float)
            cmd.Parameters("@pQTY").Direction = ParameterDirection.Input
            cmd.Parameters("@pQTY").Value = pQTY

            cmd.Parameters.Add("@pLOGIN_ID", SqlDbType.VarChar, 25)
            cmd.Parameters("@pLOGIN_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@pLOGIN_ID").Value = pLOGIN_ID

            cmd.Parameters.Add("@pRESULT", SqlDbType.VarChar, 250)
            cmd.Parameters("@pRESULT").Direction = ParameterDirection.Output
            cmd.Parameters("@pRESULT").Value = ""
            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_UPDATE_SERVICE_TO]"

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
    <WebMethod()> _
    Public Function GetAllClientsWithServices(ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Try
            Dim sqldb_conexion As SqlConnection
            Dim XSQL As String = ""
            Try
                sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
            Catch ex As Exception
                pResult = ex.Message
                Return Nothing
            End Try
            XSQL = "SELECT * FROM  " + DefaultSchema + "[OP_WMS_VIEW_SERVICES_X_CLIENT] ORDER BY QTY_SERVICES_TO_BILL DESC"

            sqldb_conexion.Open()
            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()
            Try
                miscDA.Fill(miscDS, "GetAllClientsWithServices")
                If miscDS.Tables(0).Rows.Count <= 0 Then
                    sqldb_conexion.Close()
                    pResult = "ERROR,No hay clientes"
                    Return Nothing
                Else
                    pResult = "OK"
                    sqldb_conexion.Close()
                    Return miscDS
                End If
            Catch ex As Exception
                sqldb_conexion.Close()
                pResult = "ERROR," + ex.Message
                Return Nothing
            End Try
        Catch ex As Exception

            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
    End Function
End Class