Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Configuration.ConfigurationManager
Imports System.ComponentModel
Imports System.Data.SqlClient
Imports WMSOnePlan_BusinessServices.ModuleServices

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class SONDA_Transport
    Inherits System.Web.Services.WebService

#Region "SONDA: Company services"
    <WebMethod(Description:="Get GetCompany Info based on the ID")> _
    Public Function GetCompany_by_ID(ByRef pCompanyID As Integer, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim XSQL As String = ""
        Dim sqldb_conexion As SqlConnection = Nothing
        Dim pDebugInfo As String = ""

        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
            sqldb_conexion.Open()

            XSQL = "SELECT * FROM " + AppSettings("SONDA_DB_OWNER").ToString + ".SONDA_TRANSPORT_COMPANIES "
            If pCompanyID <> -99 Then
                XSQL = XSQL + " WHERE COMPANY_ID = " & pCompanyID
            End If

            pDebugInfo = "0"

            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()
            pDebugInfo = "1"
            miscDA.Fill(miscDS, "GetCompany_by_ID")

            pDebugInfo = "2"
            If miscDS.Tables(0).Rows.Count <= 0 Then
                pResult = "ERROR, No hay empresas de transporte disponibles"
                pResult = XSQL
                Return Nothing
            Else

                pResult = "OK"
                Return miscDS
            End If

        Catch ex As Exception
            pResult = "ERROR, " + ex.Message + " pDebugInfo: "
            Return Nothing
        Finally
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try
    End Function
    <WebMethod(Description:="Get GetCompany Vehicules Tree")> _
 Public Function GetCompanyVehicules_Tree(ByRef pLoginID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String = ""

        Dim pDebugInfo As String = ""
        sqldb_conexion.Open()

        Try

            XSQL = "SELECT 	COMPANY_ID, COMPANY_NAME, VEHICULE_PLATES, VEHICULE_TYPE, "
            XSQL = XSQL + "VEHICULE_LOAD_CAPACITY, VEHICULE_MAX_PACKAGES, VEHICULE_MAX_PACKAGES AS VEHICULE_MAX_PACKAGES_AVAILABLE "
            XSQL = XSQL + "FROM " + AppSettings("SONDA_DB_OWNER").ToString + ".SONDA_VIEW_TRANSPORT_VEHICULES WHERE "
            XSQL = XSQL + "VEHICULE_PLATES NOT IN "
            XSQL = XSQL + "(SELECT VEHICULE_PLATES FROM " + AppSettings("SONDA_DB_OWNER").ToString + ".SONDA_ROUTE_IN_DESIGN "
            XSQL = XSQL + "WHERE LOGIN_ID = '" + pLoginID + "') AND VEHICULE_MAX_PACKAGES >=1"

            pDebugInfo = "0"

            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()
            pDebugInfo = "1"
            miscDA.Fill(miscDS, "COMPANY")

            pDebugInfo = "2"
            If miscDS.Tables(0).Rows.Count <= 0 Then
                pResult = "ERROR, No hay vehiculos disponibles para empresas de transporte"
                pResult = XSQL
                Return Nothing
            Else

                pResult = "OK"
                Return miscDS
            End If



        Catch ex As Exception
            pResult = "ERROR, " + ex.Message + " pDebugInfo: "
            Return Nothing
        Finally
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try
    End Function
    <WebMethod(Description:="Update Company")> _
    Public Function UpdateCompany(ByVal pCOMPANY_ID As Integer, ByVal pCOMPANY_NAME As String, ByVal pSTATUS As String, ByVal pLoginID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldb_conexion.Open()

        Try

            Dim cmd As New SqlCommand

            cmd.Parameters.Add("@COMPANY_ID", SqlDbType.Int)
            cmd.Parameters("@COMPANY_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@COMPANY_ID").Value = pCOMPANY_ID

            cmd.Parameters.Add("@COMPANY_NAME", SqlDbType.VarChar, 50)
            cmd.Parameters("@COMPANY_NAME").Direction = ParameterDirection.Input
            cmd.Parameters("@COMPANY_NAME").Value = pCOMPANY_NAME

            cmd.Parameters.Add("@STATUS", SqlDbType.VarChar, 25)
            cmd.Parameters("@STATUS").Direction = ParameterDirection.Input
            cmd.Parameters("@STATUS").Value = pSTATUS

            cmd.Parameters.Add("@pLOGIN", SqlDbType.VarChar, 25)
            cmd.Parameters("@pLOGIN").Direction = ParameterDirection.Input
            cmd.Parameters("@pLOGIN").Value = pLoginID

            cmd.Parameters.Add("@pRESULT", SqlDbType.VarChar, 500)
            cmd.Parameters("@pRESULT").Direction = ParameterDirection.Output
            cmd.Parameters("@pRESULT").Value = ""

            cmd.CommandText = "" + AppSettings("SONDA_DB_OWNER").ToString + ".SONDA_SP_UPDATE_TRANSPORT_COMPANY"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldb_conexion

            cmd.ExecuteNonQuery()

            sqldb_conexion.Close()
            pResult = cmd.Parameters("@pRESULT").Value.ToString
            Return IIf(pResult = "OK", True, False)

        Catch ex As SqlException
            pResult = ex.Message + " " + ex.Server.ToString
            Return False
        Finally
            sqldb_conexion.Close()
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try


    End Function
    <WebMethod(Description:="Update Company")> _
Public Function CreateCompany(ByVal pCOMPANY_ID As Integer, ByVal pCOMPANY_NAME As String, ByVal pSTATUS As String, ByVal pLoginID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldb_conexion.Open()

        Try

            Dim cmd As New SqlCommand

            cmd.Parameters.Add("@COMPANY_ID", SqlDbType.Int)
            cmd.Parameters("@COMPANY_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@COMPANY_ID").Value = pCOMPANY_ID

            cmd.Parameters.Add("@COMPANY_NAME", SqlDbType.VarChar, 50)
            cmd.Parameters("@COMPANY_NAME").Direction = ParameterDirection.Input
            cmd.Parameters("@COMPANY_NAME").Value = pCOMPANY_NAME

            cmd.Parameters.Add("@STATUS", SqlDbType.VarChar, 25)
            cmd.Parameters("@STATUS").Direction = ParameterDirection.Input
            cmd.Parameters("@STATUS").Value = pSTATUS

            cmd.Parameters.Add("@pLOGIN", SqlDbType.VarChar, 25)
            cmd.Parameters("@pLOGIN").Direction = ParameterDirection.Input
            cmd.Parameters("@pLOGIN").Value = pLoginID

            cmd.Parameters.Add("@pRESULT", SqlDbType.VarChar, 500)
            cmd.Parameters("@pRESULT").Direction = ParameterDirection.Output
            cmd.Parameters("@pRESULT").Value = ""

            cmd.CommandText = "" + AppSettings("SONDA_DB_OWNER").ToString + ".SONDA_SP_CREATE_TRANSPORT_COMPANY"
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
    <WebMethod(Description:="Create Transport Document")> _
Public Function DeleteCompany(ByVal pCOMPANY_ID As Integer, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim XSQL As String = ""

        Dim pTrans As SqlTransaction = Nothing
        Try
            XSQL = "DELETE " + AppSettings("SONDA_DB_OWNER").ToString + ".SONDA_TRANSPORT_COMPANIES WHERE COMPANY_ID = " & pCOMPANY_ID

            Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

            Try
                sqldb_conexion.Open()
            Catch ex As Exception
                pResult = ex.Message
                Return False
            End Try
            pTrans = sqldb_conexion.BeginTransaction(IsolationLevel.Serializable)

            If ExecuteSqlTransaction(pTrans, XSQL, pResult) Then
                pTrans.Commit()
                Return True
            Else
                pTrans.Rollback()
                Return False
            End If
        Catch ex As Exception
            pTrans.Rollback()
            pResult = ex.Message
            Return -1
        End Try

    End Function
#End Region

#Region "SONDA: Driver services"
    <WebMethod(Description:="Get Driver Info based on the ID")> _
    Public Function GetDriver_by_ID(ByRef pDriverID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim XSQL As String = ""
        Dim sqldb_conexion As SqlConnection = Nothing
        Dim pDebugInfo As String = ""

        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
            sqldb_conexion.Open()

            XSQL = "SELECT B.COMPANY_NAME, A.DRIVER_LICENSE, A.DRIVER_NAME, A.COMPANY_ID "
            XSQL = XSQL + " FROM  SONDA.dbo.SONDA_TRANSPORT_DRIVERS A, SONDA.dbo.SONDA_TRANSPORT_COMPANIES B "
            XSQL = XSQL + " WHERE A.COMPANY_ID = B.COMPANY_ID "

            If pDriverID <> -99 Then
                XSQL = XSQL + " AND DRIVER_LICENSE = '" + pDriverID + "'"
            End If

            pDebugInfo = "0"

            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()
            pDebugInfo = "1"
            miscDA.Fill(miscDS, "GetDriver_by_ID")

            pDebugInfo = "2"
            If miscDS.Tables(0).Rows.Count <= 0 Then
                pResult = "ERROR, No hay ningun piloto con ese codigo"
                pResult = XSQL
                Return Nothing
            Else
                pResult = "OK"
                Return miscDS
            End If

        Catch ex As Exception
            pResult = "ERROR, " + ex.Message + " pDebugInfo: "
            Return Nothing
        Finally
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try
    End Function
    <WebMethod(Description:="Get Driver Info based on the ID")> _
   Public Function GetCompanies(ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim XSQL As String = ""
        Dim sqldb_conexion As SqlConnection = Nothing
        Dim pDebugInfo As String = ""

        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
            sqldb_conexion.Open()

            XSQL = "SELECT (convert(varchar(10),COMPANY_ID) + '-' + COMPANY_NAME) AS COMPANY_NAME from SONDA.dbo.SONDA_TRANSPORT_COMPANIES"
            XSQL = XSQL + " GROUP BY COMPANY_ID, COMPANY_NAME ORDER BY COMPANY_ID "

            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()
            pDebugInfo = "1"
            miscDA.Fill(miscDS, "GetCompanies")

            pDebugInfo = "2"
            If miscDS.Tables(0).Rows.Count <= 0 Then
                pResult = "ERROR, No hay ninguna empresa de transporte definidas"
                pResult = XSQL
                Return Nothing
            Else
                pResult = "OK"
                Return miscDS
            End If

        Catch ex As Exception
            pResult = "ERROR, " + ex.Message + " pDebugInfo: "
            Return Nothing
        Finally
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try
    End Function
    <WebMethod(Description:="Update Driver")> _
    Public Function UpdateDriver(ByVal pCOMPANY_ID As Integer, ByVal pDRIVER_ID As String, ByVal pDRIVER_NAME As String, ByVal pLoginID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldb_conexion.Open()

        Try

            Dim cmd As New SqlCommand

            cmd.Parameters.Add("@COMPANY_ID", SqlDbType.Int)
            cmd.Parameters("@COMPANY_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@COMPANY_ID").Value = pCOMPANY_ID

            cmd.Parameters.Add("@DRIVER_ID", SqlDbType.VarChar, 50)
            cmd.Parameters("@DRIVER_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@DRIVER_ID").Value = pDRIVER_ID

            cmd.Parameters.Add("@DRIVER_NAME", SqlDbType.VarChar, 150)
            cmd.Parameters("@DRIVER_NAME").Direction = ParameterDirection.Input
            cmd.Parameters("@DRIVER_NAME").Value = pDRIVER_NAME

            cmd.Parameters.Add("@pLOGIN", SqlDbType.VarChar, 25)
            cmd.Parameters("@pLOGIN").Direction = ParameterDirection.Input
            cmd.Parameters("@pLOGIN").Value = pLoginID

            cmd.Parameters.Add("@pRESULT", SqlDbType.VarChar, 500)
            cmd.Parameters("@pRESULT").Direction = ParameterDirection.Output
            cmd.Parameters("@pRESULT").Value = ""

            cmd.CommandText = "SONDA.DBO.SONDA_SP_UPDATE_TRANSPORT_DRIVER"
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
    <WebMethod(Description:="Create Driver")> _
Public Function CreateDriver(ByVal pCOMPANY_ID As Integer, ByVal pDRIVER_ID As String, ByVal pDRIVER_NAME As String, ByVal pLoginID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldb_conexion.Open()

        Try

            Dim cmd As New SqlCommand

            cmd.Parameters.Add("@COMPANY_ID", SqlDbType.Int)
            cmd.Parameters("@COMPANY_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@COMPANY_ID").Value = pCOMPANY_ID

            cmd.Parameters.Add("@DRIVER_ID", SqlDbType.VarChar, 50)
            cmd.Parameters("@DRIVER_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@DRIVER_ID").Value = pDRIVER_ID

            cmd.Parameters.Add("@DRIVER_NAME", SqlDbType.VarChar, 150)
            cmd.Parameters("@DRIVER_NAME").Direction = ParameterDirection.Input
            cmd.Parameters("@DRIVER_NAME").Value = pDRIVER_NAME

            cmd.Parameters.Add("@pLOGIN", SqlDbType.VarChar, 25)
            cmd.Parameters("@pLOGIN").Direction = ParameterDirection.Input
            cmd.Parameters("@pLOGIN").Value = pLoginID

            cmd.Parameters.Add("@pRESULT", SqlDbType.VarChar, 500)
            cmd.Parameters("@pRESULT").Direction = ParameterDirection.Output
            cmd.Parameters("@pRESULT").Value = ""

            cmd.CommandText = "SONDA.DBO.SONDA_SP_CREATE_TRANSPORT_DRIVER"
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
    <WebMethod(Description:="Delete a driver")> _
Public Function DeleteDriver(ByVal pDRIVER_ID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim XSQL As String = ""

        Dim pTrans As SqlTransaction = Nothing
        Try
            XSQL = "DELETE SONDA.DBO.SONDA_TRANSPORT_DRIVERS WHERE DRIVER_LICENSE = '" + pDRIVER_ID + "'"

            Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

            Try
                sqldb_conexion.Open()
            Catch ex As Exception
                pResult = ex.Message
                Return False
            End Try
            pTrans = sqldb_conexion.BeginTransaction(IsolationLevel.Serializable)

            If ExecuteSqlTransaction(pTrans, XSQL, pResult) Then
                pTrans.Commit()
                Return True
            Else
                pTrans.Rollback()
                Return False
            End If
        Catch ex As Exception
            pTrans.Rollback()
            pResult = ex.Message
            Return -1
        End Try

    End Function
#End Region

#Region "SONDA: Vehicule services"
    <WebMethod(Description:="Get Vehicule Info based on the ID")> _
        Public Function GetVehicule_by_ID(ByRef pVehiculeID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim Sql As String = ""
        Dim sqldb_conexion As SqlConnection = Nothing
        Dim pDebugInfo As String = ""

        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
            sqldb_conexion.Open()

            Sql = Sql & " SELECT * FROM SONDA.DBO.SONDA_FUNCT_GET_VEHICULES() "


            If pVehiculeID <> "-99" Then
                Sql = Sql + " WHERE VEHICULE_PLATES = '" + pVehiculeID + "'"
            End If

            pDebugInfo = "0"

            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(Sql, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()
            pDebugInfo = "1"
            miscDA.Fill(miscDS, "GetDriver_by_ID")

            pDebugInfo = "2"
            If miscDS.Tables(0).Rows.Count <= 0 Then
                pResult = "ERROR, No hay ningun piloto con ese codigo"
                pResult = Sql
                Return Nothing
            Else
                pResult = "OK"
                Return miscDS
            End If

        Catch ex As Exception
            pResult = "ERROR, " + ex.Message + " pDebugInfo: "
            Return Nothing
        Finally
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try
    End Function
    <WebMethod(Description:="Update Driver")> _
    Public Function UpdateVehicule(ByVal pCOMPANY_ID As Integer, ByVal pVEHICULE_TYPE As String, _
                                   ByVal pVEHICULE_PLATES As String, ByVal pVEHICULE_LOAD_CAPACITY As Double, _
                                   ByVal pVEHICULE_MAX_PACKAGES As Double, ByVal pSTATUS As String, _
                                   ByVal pLoginID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldb_conexion.Open()

        Try

            Dim cmd As New SqlCommand

            cmd.Parameters.Add("@COMPANY_ID", SqlDbType.Int)
            cmd.Parameters("@COMPANY_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@COMPANY_ID").Value = pCOMPANY_ID

            cmd.Parameters.Add("@VEHICULE_TYPE", SqlDbType.VarChar, 50)
            cmd.Parameters("@VEHICULE_TYPE").Direction = ParameterDirection.Input
            cmd.Parameters("@VEHICULE_TYPE").Value = pVEHICULE_TYPE

            cmd.Parameters.Add("@VEHICULE_PLATES", SqlDbType.VarChar, 150)
            cmd.Parameters("@VEHICULE_PLATES").Direction = ParameterDirection.Input
            cmd.Parameters("@VEHICULE_PLATES").Value = pVEHICULE_PLATES

            cmd.Parameters.Add("@VEHICULE_LOAD_CAPACITY", SqlDbType.Decimal)
            cmd.Parameters("@VEHICULE_LOAD_CAPACITY").Direction = ParameterDirection.Input
            cmd.Parameters("@VEHICULE_LOAD_CAPACITY").Value = pVEHICULE_LOAD_CAPACITY

            cmd.Parameters.Add("@VEHICULE_MAX_PACKAGES", SqlDbType.Decimal)
            cmd.Parameters("@VEHICULE_MAX_PACKAGES").Direction = ParameterDirection.Input
            cmd.Parameters("@VEHICULE_MAX_PACKAGES").Value = pVEHICULE_MAX_PACKAGES

            cmd.Parameters.Add("@STATUS", SqlDbType.VarChar, 150)
            cmd.Parameters("@STATUS").Direction = ParameterDirection.Input
            cmd.Parameters("@STATUS").Value = pSTATUS

            cmd.Parameters.Add("@pLOGIN", SqlDbType.VarChar, 25)
            cmd.Parameters("@pLOGIN").Direction = ParameterDirection.Input
            cmd.Parameters("@pLOGIN").Value = pLoginID

            cmd.Parameters.Add("@pRESULT", SqlDbType.VarChar, 500)
            cmd.Parameters("@pRESULT").Direction = ParameterDirection.Output
            cmd.Parameters("@pRESULT").Value = ""

            cmd.CommandText = "SONDA.DBO.SONDA_SP_UPDATE_TRANSPORT_VEHICULE"
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
    <WebMethod(Description:="Create Driver")> _
Public Function CreateVehicule(ByVal pCOMPANY_ID As Integer, ByVal pVEHICULE_TYPE As String, _
                                   ByVal pVEHICULE_PLATES As String, ByVal pVEHICULE_LOAD_CAPACITY As Double, _
                                   ByVal pVEHICULE_MAX_PACKAGES As Double, ByVal pSTATUS As String, _
                                   ByVal pLoginID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldb_conexion.Open()

        Try

            Dim cmd As New SqlCommand

            cmd.Parameters.Add("@COMPANY_ID", SqlDbType.Int)
            cmd.Parameters("@COMPANY_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@COMPANY_ID").Value = pCOMPANY_ID

            cmd.Parameters.Add("@VEHICULE_TYPE", SqlDbType.VarChar, 50)
            cmd.Parameters("@VEHICULE_TYPE").Direction = ParameterDirection.Input
            cmd.Parameters("@VEHICULE_TYPE").Value = pVEHICULE_TYPE

            cmd.Parameters.Add("@VEHICULE_PLATES", SqlDbType.VarChar, 150)
            cmd.Parameters("@VEHICULE_PLATES").Direction = ParameterDirection.Input
            cmd.Parameters("@VEHICULE_PLATES").Value = pVEHICULE_PLATES

            cmd.Parameters.Add("@VEHICULE_LOAD_CAPACITY", SqlDbType.Decimal)
            cmd.Parameters("@VEHICULE_LOAD_CAPACITY").Direction = ParameterDirection.Input
            cmd.Parameters("@VEHICULE_LOAD_CAPACITY").Value = pVEHICULE_LOAD_CAPACITY

            cmd.Parameters.Add("@VEHICULE_MAX_PACKAGES", SqlDbType.Decimal)
            cmd.Parameters("@VEHICULE_MAX_PACKAGES").Direction = ParameterDirection.Input
            cmd.Parameters("@VEHICULE_MAX_PACKAGES").Value = pVEHICULE_MAX_PACKAGES

            cmd.Parameters.Add("@STATUS", SqlDbType.VarChar, 150)
            cmd.Parameters("@STATUS").Direction = ParameterDirection.Input
            cmd.Parameters("@STATUS").Value = pSTATUS

            cmd.Parameters.Add("@pLOGIN", SqlDbType.VarChar, 25)
            cmd.Parameters("@pLOGIN").Direction = ParameterDirection.Input
            cmd.Parameters("@pLOGIN").Value = pLoginID

            cmd.Parameters.Add("@pRESULT", SqlDbType.VarChar, 500)
            cmd.Parameters("@pRESULT").Direction = ParameterDirection.Output
            cmd.Parameters("@pRESULT").Value = ""

            cmd.CommandText = "SONDA.DBO.SONDA_SP_CREATE_TRANSPORT_VEHICULE"
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
    <WebMethod(Description:="Delete a driver")> _
    Public Function DeleteVehicule(ByVal pVEHICULE_PLATES As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim XSQL As String = ""

        Dim pTrans As SqlTransaction = Nothing
        Try
            XSQL = "DELETE SONDA.DBO.SONDA_TRANSPORT_VEHICULES WHERE VEHICULE_PLATES = '" + pVEHICULE_PLATES + "'"

            Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

            Try
                sqldb_conexion.Open()
            Catch ex As Exception
                pResult = ex.Message
                Return False
            End Try
            pTrans = sqldb_conexion.BeginTransaction(IsolationLevel.Serializable)

            If ExecuteSqlTransaction(pTrans, XSQL, pResult) Then
                pTrans.Commit()
                Return True
            Else
                pTrans.Rollback()
                Return False
            End If
        Catch ex As Exception
            pTrans.Rollback()
            pResult = ex.Message
            Return -1
        End Try

    End Function
#End Region



    <WebMethod(Description:="Get GetCompany Vehicules Tree")> _
    Public Function GetRoutePlans(ByVal pDateStart As Date, ByVal pDateEnd As Date, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim SQL As String = ""
        Dim pDebugInfo As String = ""
        sqldb_conexion.Open()

        Try
            Dim pTmpIni As String = Format(pDateStart, "yyyy-MM-dd")
            Dim pTmpEnd As String = Format(pDateEnd, "yyyy-MM-dd")

            SQL = " SELECT   A.ROUTE_ID AS RUTA, A.STATUS, A.COUNTED_ASSIGNED_TO AS LOADER, A.DELIVERY_VEHICULE_TYPE as Empresa, A.DELIVERY_DRIVER_NAME as Piloto "
            SQL = SQL & "FROM "
            SQL = SQL & "    " + AppSettings("SONDA_DB_OWNER").ToString + ".SONDA_DOCS A "
            SQL = SQL & "WHERE CONVERT(CHAR(10),CREATED,120) BETWEEN "
            SQL = SQL & "      CONVERT(CHAR(10),'" + pTmpIni + "',120) AND CONVERT(CHAR(10),'" + pTmpEnd + "',120) AND "
            SQL = SQL & " A.STATUS IN ('LOADED','TO_VERIFY') "
            SQL = SQL & " GROUP BY A.ROUTE_ID, A.STATUS, A.COUNTED_ASSIGNED_TO, A.DELIVERY_VEHICULE_TYPE, A.DELIVERY_DRIVER_NAME"


            pDebugInfo = "0"

            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(SQL, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()
            pDebugInfo = "1"
            miscDA.Fill(miscDS, "DOCS")
            pDebugInfo = "2"
            If miscDS.Tables(0).Rows.Count <= 0 Then
                pResult = "ERROR, No hay tareas de carga de ruta "
                Return Nothing
            Else
                pDebugInfo = "2.1"
                Dim xsql As String = ""
                'xsql = "SELECT BOX_ID + '  [' + CAST(VERIFIED_DATETIME AS nvarchar(25))+']' AS BOX_ID_CAPTION, "
                xsql = "SELECT A.ERP_DOC, A.STATUS, VERIFIED_DATETIME AS FECHA, "
                xsql = xsql + " ISNULL((SELECT TOP 1 Z.ROUTE_ID FROM " + AppSettings("SONDA_DB_OWNER").ToString + ".SONDA_DOCS Z WHERE Z.DOC_ID = A.DOC_ID),'N/A') AS RUTA"
                xsql = xsql + " FROM " + AppSettings("SONDA_DB_OWNER").ToString + ".SONDA_ORDERS_BY_DOC A "
                xsql = xsql & "WHERE CONVERT(CHAR(10),A.CREATED,120) BETWEEN "
                xsql = xsql & "      CONVERT(CHAR(10),'" + pTmpIni + "',120) AND CONVERT(CHAR(10),'" + pTmpEnd + "',120) "
                xsql = xsql & "      GROUP BY A.ERP_DOC, A.STATUS, A.VERIFIED_DATETIME,A.DOC_ID"
                'xsql = xsql & "      AND A.STATUS IN ('TO_VERIFY','VERIFIED')"

                pDebugInfo = "2.2"

                miscDA.SelectCommand = New SqlCommand(xsql, sqldb_conexion)
                miscDA.Fill(miscDS, "DETAIL")

                If miscDS.Tables(0).Rows.Count <= 0 Then
                    pResult = "ERROR, No hay tareas (DET) para : " + pTmpIni + "   " + pTmpEnd
                    Return Nothing
                Else
                    Try
                        Dim keyColumn As DataColumn = miscDS.Tables("DOCS").Columns("RUTA")
                        Dim foreignKeyColumn As DataColumn = miscDS.Tables("DETAIL").Columns("RUTA")

                        miscDS.Relations.Add("DOCS_DETAIL", keyColumn, foreignKeyColumn)

                        If miscDS.Tables(2) Is Nothing Then
                            pResult = "ERROR, No se genero la jerarquia de doc-detalle."
                            Return Nothing
                        Else
                            miscDS.Tables(2).Columns(0).ReadOnly = True
                        End If
                    Catch ex As Exception
                        ' pResult = "ERROR, " + ex.Message
                        ' Return Nothing

                    End Try

                    pResult = "OK"
                    Return miscDS
                End If

            End If

        Catch ex As Exception
            pResult = "ERROR, " + ex.Message + " pDebugInfo: "
            Return Nothing
        Finally
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try



    End Function
    <WebMethod(Description:="Search Bin by Key")> _
    Public Function SendToDesign(ByVal pLoginID As String, ByVal pRouteID As String, ByVal pERP_DOC As String, ByVal pVehiculePlates As String, ByVal pCompanyName As String, ByVal pTotalPackages As Integer, ByVal pClientName As String, ByVal pCompanyID As Integer, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldb_conexion.Open()

        Try

            Dim cmd As New SqlCommand


            cmd.Parameters.Add("@pLOGIN", SqlDbType.VarChar, 25)
            cmd.Parameters("@pLOGIN").Direction = ParameterDirection.Input
            cmd.Parameters("@pLOGIN").Value = pLoginID

            cmd.Parameters.Add("@pROUTE_ID", SqlDbType.VarChar, 50)
            cmd.Parameters("@pROUTE_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@pROUTE_ID").Value = pRouteID

            cmd.Parameters.Add("@pERP_DOC", SqlDbType.VarChar, 25)
            cmd.Parameters("@pERP_DOC").Direction = ParameterDirection.Input
            cmd.Parameters("@pERP_DOC").Value = pERP_DOC

            cmd.Parameters.Add("@pTRANSPORT_UNIT", SqlDbType.VarChar, 25)
            cmd.Parameters("@pTRANSPORT_UNIT").Direction = ParameterDirection.Input
            cmd.Parameters("@pTRANSPORT_UNIT").Value = pVehiculePlates

            cmd.Parameters.Add("@pCOMPANY_NAME", SqlDbType.VarChar, 150)
            cmd.Parameters("@pCOMPANY_NAME").Direction = ParameterDirection.Input
            cmd.Parameters("@pCOMPANY_NAME").Value = pCompanyName

            cmd.Parameters.Add("@pTOTAL_PACKAGES", SqlDbType.Int)
            cmd.Parameters("@pTOTAL_PACKAGES").Direction = ParameterDirection.Input
            cmd.Parameters("@pTOTAL_PACKAGES").Value = pTotalPackages

            cmd.Parameters.Add("@pCLIENT_NAME", SqlDbType.VarChar, 150)
            cmd.Parameters("@pCLIENT_NAME").Direction = ParameterDirection.Input
            cmd.Parameters("@pCLIENT_NAME").Value = pClientName

            cmd.Parameters.Add("@pCOMPANY_ID", SqlDbType.Int)
            cmd.Parameters("@pCOMPANY_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@pCOMPANY_ID").Value = pCompanyID

            cmd.Parameters.Add("@pRESULT", SqlDbType.VarChar, 250)
            cmd.Parameters("@pRESULT").Direction = ParameterDirection.Output
            cmd.Parameters("@pRESULT").Value = ""

            cmd.CommandText = "SONDA.[dbo].[SONDA_SP_SET_ROUTE_DESIGN]"
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
    <WebMethod(Description:="Get GetCompany Vehicules Tree")> _
   Public Function GetRouteDesign(ByVal pLoginID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String = ""

        Dim pDebugInfo As String = ""
        sqldb_conexion.Open()

        Try

            XSQL = "SELECT * FROM " + AppSettings("SONDA_DB_OWNER").ToString + ".SONDA_ROUTE_IN_DESIGN WHERE LOGIN_ID = '" + pLoginID + "'"

            pDebugInfo = "0"

            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()
            pDebugInfo = "1"
            miscDA.Fill(miscDS, "GetRouteDesign")

            pDebugInfo = "2"
            If miscDS.Tables(0).Rows.Count <= 0 Then
                pResult = "ERROR, No hay datos en disenio."
                Return Nothing
            Else

                pResult = "OK"
                Return miscDS
            End If



        Catch ex As Exception
            pResult = "ERROR, " + ex.Message + " pDebugInfo: "
            Return Nothing
        Finally
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try
    End Function
    <WebMethod(Description:="Get my counting tasks")> _
    Public Function GetAllRoutesCompletedNotInDesignMode(ByRef pLoginID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String = ""

        Dim pDebugInfo As String = ""
        sqldb_conexion.Open()

        Try

            XSQL = "        SELECT * "
            XSQL = XSQL + " FROM "
            XSQL = XSQL + "     " + AppSettings("SONDA_DB_OWNER").ToString + ".SONDA_VIEW_COMPLETED_ROUTES"
            XSQL = XSQL + "     WHERE ROUTE NOT IN (SELECT ROUTE_ID FROM " + AppSettings("SONDA_DB_OWNER").ToString + ".SONDA_ROUTE_IN_DESIGN WHERE LOGIN_ID = '" + pLoginID + "')"
            XSQL = XSQL + " ORDER BY"
            XSQL = XSQL + "     ROUTE "

            pDebugInfo = "0"

            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()
            pDebugInfo = "1"
            miscDA.Fill(miscDS, "GetAllRoutesCompleted")
            pDebugInfo = "2"
            If miscDS.Tables(0).Rows.Count <= 0 Then
                pResult = "ERROR, No hay rutas completadas "
                Return Nothing
            Else
                pResult = "OK"
                Return miscDS
            End If

        Catch ex As Exception
            pResult = "ERROR, " + ex.Message
            Return Nothing
        Finally
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try



    End Function
    <WebMethod(Description:="Get my counting tasks")> _
    Public Function GetWorkload_By_TransCompany(ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String = ""

        Dim pDebugInfo As String = ""
        sqldb_conexion.Open()

        Try

            XSQL = "        SELECT * "
            XSQL = XSQL + " FROM "
            XSQL = XSQL + " " + AppSettings("SONDA_DB_OWNER").ToString + ".SONDA_VIEW_WORKLOAD_BY_TRANS_COMPANY"

            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()
            pDebugInfo = "1"
            miscDA.Fill(miscDS, "GetWorkload_By_TransCompany")
            pDebugInfo = "2"
            If miscDS.Tables(0).Rows.Count <= 0 Then
                pResult = "ERROR, No hay ninguna carga de trabajo "
                Return Nothing
            Else
                pResult = "OK"
                Return miscDS
            End If

        Catch ex As Exception
            pResult = "ERROR, " + ex.Message
            Return Nothing
        Finally
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try
    End Function
    <WebMethod(Description:="Get my counting tasks")> _
   Public Function GetDriversNotInDesign(ByVal pLoginID As String, ByVal pCompanyID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String = ""

        Dim pDebugInfo As String = ""
        sqldb_conexion.Open()

        Try

            XSQL = "        SELECT * "
            XSQL = XSQL + " FROM "
            XSQL = XSQL + " " + AppSettings("SONDA_DB_OWNER").ToString + ".SONDA_TRANSPORT_DRIVERS WHERE COMPANY_ID = " + pCompanyID + " AND DRIVER_LICENSE NOT IN (SELECT ISNULL(DRIVER_LICENSE,'') FROM " + AppSettings("SONDA_DB_OWNER").ToString + ".SONDA_ROUTE_IN_DESIGN WHERE LOGIN_ID = '" + pLoginID + "')"

            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()
            pDebugInfo = "1"
            miscDA.Fill(miscDS, "GetDriversNotInDesign")
            pDebugInfo = "2"
            If miscDS.Tables(0).Rows.Count <= 0 Then
                pResult = "ERROR, No hay pilotos disponibles "
                Return Nothing
            Else
                pResult = "OK"
                Return miscDS
            End If

        Catch ex As Exception
            pResult = "ERROR, " + ex.Message
            Return Nothing
        Finally
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try

    End Function
    <WebMethod(Description:="Get my counting tasks")> _
   Public Function GetLoadingGatesNotInDesign(ByVal pLoginID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String = ""

        Dim pDebugInfo As String = ""
        sqldb_conexion.Open()

        Try

            XSQL = "        SELECT * "
            XSQL = XSQL + " FROM "
            XSQL = XSQL + " [SONDA].[dbo].[SONDA_LOADING_GATES] WHERE STATUS='AVAILABLE'" ' AND GATE_ID NOT IN (SELECT ISNULL(LOADING_GATE,0) FROM "+AppSettings("SONDA_DB_OWNER").ToString+".SONDA_ROUTE_IN_DESIGN WHERE  LOGIN_ID = '" + pLoginID + "')"

            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()
            pDebugInfo = "1"
            miscDA.Fill(miscDS, "GetDriversNotInDesign")
            pDebugInfo = "2"
            If miscDS.Tables(0).Rows.Count <= 0 Then
                pResult = "ERROR, No hay puertas disponibles "
                Return Nothing
            Else
                pResult = "OK"
                Return miscDS
            End If

        Catch ex As Exception
            pResult = "ERROR, " + ex.Message
            Return Nothing
        Finally
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try

    End Function
    <WebMethod(Description:="Get my counting tasks")> _
   Public Function GetLoadingGates(ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String = ""

        Dim pDebugInfo As String = ""
        sqldb_conexion.Open()

        Try

            XSQL = "        SELECT * "
            XSQL = XSQL + " FROM "
            XSQL = XSQL + " [SONDA].[dbo].[SONDA_LOADING_GATES]" ' WHERE GATE_ID " 'NOT IN (SELECT LOADING_GATE FROM OP_WMS_LOGINS WHERE ASSIGNED_OPERATOR IS NOT NULL)"

            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()
            pDebugInfo = "1"
            miscDA.Fill(miscDS, "GetLoadingGates")
            pDebugInfo = "2"
            If miscDS.Tables(0).Rows.Count <= 0 Then
                pResult = "ERROR, No hay puertas "
                Return Nothing
            Else
                pResult = "OK"
                Return miscDS
            End If

        Catch ex As Exception
            pResult = "ERROR, " + ex.Message
            Return Nothing
        Finally
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try

    End Function
    <WebMethod(Description:="Search Bin by Key")> _
    Public Function UpdateDriverDesign(ByVal pService As String, ByVal pRouteID As String, ByVal pVehiculePlates As String, ByVal pDriverLicense As String, ByVal pDriverName As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldb_conexion.Open()

        Try

            Dim cmd As New SqlCommand

            cmd.Parameters.Add("@pROUTE_ID", SqlDbType.VarChar, 50)
            cmd.Parameters("@pROUTE_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@pROUTE_ID").Value = pRouteID

            cmd.Parameters.Add("@pTRANSPORT_UNIT", SqlDbType.VarChar, 25)
            cmd.Parameters("@pTRANSPORT_UNIT").Direction = ParameterDirection.Input
            cmd.Parameters("@pTRANSPORT_UNIT").Value = pVehiculePlates

            cmd.Parameters.Add("@pDRIVER_LICENSE", SqlDbType.VarChar, 50)
            cmd.Parameters("@pDRIVER_LICENSE").Direction = ParameterDirection.Input
            cmd.Parameters("@pDRIVER_LICENSE").Value = pDriverLicense

            cmd.Parameters.Add("@pDRIVER_NAME", SqlDbType.VarChar, 150)
            cmd.Parameters("@pDRIVER_NAME").Direction = ParameterDirection.Input
            cmd.Parameters("@pDRIVER_NAME").Value = pDriverName

            cmd.Parameters.Add("@pSERVICE", SqlDbType.VarChar, 15)
            cmd.Parameters("@pSERVICE").Direction = ParameterDirection.Input
            cmd.Parameters("@pSERVICE").Value = pService

            cmd.Parameters.Add("@pRESULT", SqlDbType.VarChar, 250)
            cmd.Parameters("@pRESULT").Direction = ParameterDirection.Output
            cmd.Parameters("@pRESULT").Value = ""

            cmd.CommandText = "SONDA.[dbo].[SONDA_SP_UPDATE_ROUTE_DRIVER]"
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
    <WebMethod(Description:="Search Bin by Key")> _
   Public Function UpdateLoadingGateDesign(ByVal pRouteID As String, ByVal pERP_DOC As String, ByVal pLoadingGate As Integer, ByVal pLoadingGateOperator As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldb_conexion.Open()

        Try

            Dim cmd As New SqlCommand

            cmd.Parameters.Add("@pROUTE_ID", SqlDbType.VarChar, 50)
            cmd.Parameters("@pROUTE_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@pROUTE_ID").Value = pRouteID

            cmd.Parameters.Add("@pERP_DOC", SqlDbType.VarChar, 25)
            cmd.Parameters("@pERP_DOC").Direction = ParameterDirection.Input
            cmd.Parameters("@pERP_DOC").Value = pERP_DOC

            cmd.Parameters.Add("@pLOADING_GATE", SqlDbType.Int)
            cmd.Parameters("@pLOADING_GATE").Direction = ParameterDirection.Input
            cmd.Parameters("@pLOADING_GATE").Value = pLoadingGate

            cmd.Parameters.Add("@pLOADING_GATE_OPERATOR", SqlDbType.VarChar, 25)
            cmd.Parameters("@pLOADING_GATE_OPERATOR").Direction = ParameterDirection.Input
            cmd.Parameters("@pLOADING_GATE_OPERATOR").Value = pLoadingGateOperator

            cmd.Parameters.Add("@pRESULT", SqlDbType.VarChar, 250)
            cmd.Parameters("@pRESULT").Direction = ParameterDirection.Output
            cmd.Parameters("@pRESULT").Value = ""

            cmd.CommandText = "SONDA.[dbo].[SONDA_SP_UPDATE_ROUTE_LOADING_GATE]"
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
    <WebMethod(Description:="Create Transport Document")> _
Public Function CreateTransportDocument(ByVal pROUTE_ID As String, ByVal pERP_DOC As String, ByVal pCREATED_BY As String, ByVal pSTATUS As String, ByVal pLAST_UPDATE_BY As String, ByVal pCOUNTED_ASSIGNED_TO As String, ByVal pLOADING_GATE As Integer, ByVal pDELIVERY_ASSIGNED_TO As String, ByVal pDELIVERY_DRIVER_NAME As String, ByVal pDELIVERY_VEHICULE_PLATES As String, ByVal pDELIVERY_VEHICULE_TYPE As String, ByVal pIS_ADDENDUM As Integer, ByVal pDOC_PARENT As Integer, ByVal pTOTAL_PACKAGES As Integer, ByVal pDELIVERY_CLIENT_NAME As String, ByVal pDELIVERY_CLIENT_PHONE As String, ByVal pDELIVERY_CLIENT_ADDRESS As String, ByVal pIS_INTERMEDIATE As Boolean, ByVal pDELIVERY_COMPANY_ID As Integer, ByVal pDELIVERY_COMPANY_NAME As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Integer

        Dim XSQL As String = ""
        Dim pDebug = "0"
        Dim pINTERMEDIATE_PARENT As String = ""

        Dim pLastDoc As Integer = 0


        If pIS_INTERMEDIATE Then
            pINTERMEDIATE_PARENT = pROUTE_ID + "-1"
        End If

        Try
            Dim pTrans As SqlTransaction = Nothing


            XSQL = "DELETE " + AppSettings("SONDA_DB_OWNER").ToString + ".SONDA_ORDERS_BY_DOC WHERE DOC_ID IN (SELECT DOC_ID FROM " + AppSettings("SONDA_DB_OWNER").ToString + ".SONDA_DOCS WHERE ERP_DOC = '" + pERP_DOC + "')"
            If ExecuteSqlTransaction(AppSettings(pEnvironmentName).ToString, XSQL, pResult) Then
                XSQL = "DELETE " + AppSettings("SONDA_DB_OWNER").ToString + ".SONDA_DOCS WHERE ERP_DOC = '" + pERP_DOC + "'"
                If Not ExecuteSqlTransaction(AppSettings(pEnvironmentName).ToString, XSQL, pResult) Then
                    pLastDoc = -1
                    Return -1
                End If
            Else
                pLastDoc = -1
                Return -1
            End If
            

            XSQL = "INSERT INTO " + AppSettings("SONDA_DB_OWNER").ToString + ".SONDA_DOCS("
            XSQL = XSQL + "ROUTE_ID," '1
            XSQL = XSQL + "CREATED," '1
            XSQL = XSQL + "CREATED_BY," '2
            XSQL = XSQL + "STATUS," '2
            XSQL = XSQL + "LAST_UPDATE," '2
            XSQL = XSQL + "LAST_UPDATE_BY," '2
            XSQL = XSQL + "COUNTED_ASSIGNED_TO," '2
            XSQL = XSQL + "COUNTED_STARTED_DATE," '2
            XSQL = XSQL + "COUNTED_FINISHED_DATE," '2
            XSQL = XSQL + "LOADING_GATE," '2
            XSQL = XSQL + "DELIVERY_ASSIGNED_TO," '2
            XSQL = XSQL + "DELIVERY_DRIVER_NAME," '2
            XSQL = XSQL + "DELIVERY_VEHICULE_PLATES," '2
            XSQL = XSQL + "DELIVERY_VEHICULE_TYPE," '2
            XSQL = XSQL + "DELIVERY_DATE," '2
            XSQL = XSQL + "IS_ADDENDUM," '2
            XSQL = XSQL + "DOC_PARENT," '2
            XSQL = XSQL + "TOTAL_PACKAGES, " '2
            XSQL = XSQL + "ERP_DOC, "
            XSQL = XSQL + "DELIVERY_CLIENT_NAME, "
            XSQL = XSQL + "DELIVERY_CLIENT_PHONE, "
            XSQL = XSQL + "DELIVERY_CLIENT_ADDRESS, "
            XSQL = XSQL + "INTERMEDIATE_PARENT, "
            XSQL = XSQL + "DELIVERY_COMPANY_ID, "
            XSQL = XSQL + "DELIVERY_COMPANY_NAME) "
            XSQL = XSQL + "VALUES ("
            XSQL = XSQL + "'" + pROUTE_ID + "'," '2
            XSQL = XSQL + "CURRENT_TIMESTAMP," '2
            XSQL = XSQL + "'" + pCREATED_BY + "'," '2
            XSQL = XSQL + "'LOADED'," '2
            XSQL = XSQL + "CURRENT_TIMESTAMP," '2
            XSQL = XSQL + "'" + pLAST_UPDATE_BY + "'," '2
            XSQL = XSQL + "'" + pCOUNTED_ASSIGNED_TO + "'," '2
            XSQL = XSQL + "NULL," '2
            XSQL = XSQL + "NULL," '2
            XSQL = XSQL + pLOADING_GATE.ToString + "," '2
            XSQL = XSQL + "'" + pDELIVERY_ASSIGNED_TO + "'," '2
            XSQL = XSQL + "'" + pDELIVERY_DRIVER_NAME + "'," '2
            XSQL = XSQL + "'" + pDELIVERY_VEHICULE_PLATES + "'," '2
            XSQL = XSQL + "'" + pDELIVERY_VEHICULE_TYPE + "'," '2
            XSQL = XSQL + "NULL," '2
            XSQL = XSQL + pIS_ADDENDUM.ToString + "," '2
            XSQL = XSQL + "'" + pDOC_PARENT.ToString + "'," '2
            XSQL = XSQL + pTOTAL_PACKAGES.ToString + ",'" + pERP_DOC + "',"
            XSQL = XSQL + "'" + pDELIVERY_CLIENT_NAME + "'," '2
            XSQL = XSQL + "'" + pDELIVERY_CLIENT_PHONE + "'," '2
            XSQL = XSQL + "'" + pDELIVERY_CLIENT_ADDRESS + "'," '2

            If pINTERMEDIATE_PARENT = "" Then
                XSQL = XSQL + "NULL," '2
            Else
                XSQL = XSQL + "'" + pINTERMEDIATE_PARENT + "'," '2
            End If

            XSQL = XSQL + pDELIVERY_COMPANY_ID.ToString + "," '2
            XSQL = XSQL + "'" + pDELIVERY_COMPANY_NAME + "')" '2

            pDebug = "1 " + pEnvironmentName
            'Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
            pDebug = "2"
            Try
                pDebug = "3"
                'sqldb_conexion.Open()
                pDebug = "4"
            Catch ex As Exception
                pResult = ex.Message + " debug: " + pDebug
                Return -1
            End Try
            'pTrans = sqldb_conexion.BeginTransaction(IsolationLevel.Serializable)

            If ExecuteSqlTransaction(AppSettings(pEnvironmentName).ToString, XSQL, pResult) Then

                pLastDoc = GetLastDoc(pEnvironmentName)

                If CreateDocDetail(pLastDoc, pERP_DOC, pLAST_UPDATE_BY, pResult, pEnvironmentName) Then

                    XSQL = "DELETE " + AppSettings("SONDA_DB_OWNER").ToString + ".SONDA_ROUTE_IN_DESIGN WHERE ERP_DOC = '" + pERP_DOC + "'"
                    If Not ExecuteSqlTransaction(AppSettings(pEnvironmentName).ToString, XSQL, pResult) Then
                        Return -1

                    Else

                        XSQL = "UPDATE " + AppSettings("DB_LINK").ToString + "OP_WMS_PACKAGES_X_DISPATCH SET STATUS = 'DELIVERED_TO_SONDA' WHERE ROUTE = '" + pROUTE_ID + "'"

                        If Not ExecuteSqlTransaction(AppSettings(pEnvironmentName).ToString, XSQL, pResult) Then
                            Return -1
                        End If

                        pResult = "OK"
                        Return pLastDoc
                    End If

                Else
                    pLastDoc = -1
                    Return -1
                End If

            Else
                pResult = pResult + " debug: " + pDebug
                'pTrans.Rollback()
                Return -1
            End If
        Catch ex As Exception

            'pTrans.Rollback()
            pResult = ex.Message + " debug: " + pDebug
            Return -1
        End Try

    End Function
    <WebMethod(Description:="Create Transport Document Detail")> _
    Public Function CreateDocDetail(ByVal pLastDoc As Integer, ByVal pERP_DOC As String, ByVal pLAST_UPDATE_BY As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean
        Dim pDebugInfo As String = "0"
        Try
            'Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

            If AppSettings("DB_LINK") Is Nothing Then
                pResult = "ERROR, variable DB_LINK no existe, en archivo de configuracion."
                Return Nothing
            End If

            Dim XSQL As String = "SELECT BOX_ID FROM " + AppSettings("DB_LINK").ToString + "OP_WMS_PACKAGES_X_DISPATCH WHERE ERP_DOC = '" + pERP_DOC + "'"
            Dim xrow As DataRow


            'sqldb_conexion.Open()

            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, AppSettings(pEnvironmentName).ToString)
            Dim miscDS As DataSet = New DataSet()
            pDebugInfo = "1"
            miscDA.Fill(miscDS, "CreateDocDetail")
            pDebugInfo = "2"
            If miscDS.Tables(0).Rows.Count <= 0 Then
                pResult = "ERROR, No hay bultos para ese pedido"
                Return False
            Else
                For Each xrow In miscDS.Tables(0).Rows
                    XSQL = "INSERT INTO "
                    XSQL = XSQL + "[SONDA].[dbo].[SONDA_ORDERS_BY_DOC]"
                    XSQL = XSQL + "([DOC_ID]"
                    XSQL = XSQL + "           ,[ERP_DOC]"
                    XSQL = XSQL + "           ,[BOX_ID]"
                    XSQL = XSQL + "           ,[CREATED]"
                    XSQL = XSQL + "           ,[STATUS]"
                    XSQL = XSQL + "           ,[VERIFIED_DATETIME]"
                    XSQL = XSQL + "           ,[DELIVERIED_DATETIME]"
                    XSQL = XSQL + "           ,[LAST_UPDATE_BY])"
                    XSQL = XSQL + "     VALUES"
                    XSQL = XSQL + "           (" + pLastDoc.ToString
                    XSQL = XSQL + "           ,'" + pERP_DOC + "'"
                    XSQL = XSQL + "           ,'" + xrow("BOX_ID").ToString + "'"
                    XSQL = XSQL + "           ,CURRENT_TIMESTAMP"
                    XSQL = XSQL + "           ,'LOADED'"
                    XSQL = XSQL + "           ,NULL"
                    XSQL = XSQL + "           ,NULL"
                    XSQL = XSQL + "           ,'" + pLAST_UPDATE_BY + "')"
                    pDebugInfo = "3"
                    If Not ExecuteSqlTransaction(AppSettings(pEnvironmentName).ToString, XSQL, pResult) Then
                        Return False
                    End If
                Next
            End If

            'sqldb_conexion.Close()
            Return True

        Catch ex As Exception
            'sqldb_conexion.close()
            pResult = pDebugInfo + " " + ex.Message
            Return False
        End Try



    End Function
    <WebMethod(Description:="CleanDesign")> _
    Public Function CleanDesign(ByVal pLoginID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldb_conexion.Open()

        Try

            Dim cmd As New SqlCommand

            cmd.Parameters.Add("@pLOGIN", SqlDbType.VarChar, 25)
            cmd.Parameters("@pLOGIN").Direction = ParameterDirection.Input
            cmd.Parameters("@pLOGIN").Value = pLoginID

            cmd.Parameters.Add("@pRESULT", SqlDbType.VarChar, 250)
            cmd.Parameters("@pRESULT").Direction = ParameterDirection.Output
            cmd.Parameters("@pRESULT").Value = ""

            cmd.CommandText = "SONDA.[dbo].[SONDA_SP_CLEAN_DESIGN]"
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
    'TRANSACTION
    Public Function GetLastDoc(ByVal pEnvironmentName As String) As Integer
        Dim XSQL As String = ""
        XSQL = "SELECT IDENT_CURRENT('" + AppSettings("SONDA_DB_OWNER").ToString + ".SONDA_DOCS') AS LAST_CREATED_DOC"

        Dim miscDA As New SqlCommand
        Dim miscADP As New SqlDataAdapter
        Dim miscDS As New DataSet

        miscDA.Connection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        miscDA.CommandText = XSQL
        miscDA.CommandType = CommandType.Text

        Try
            miscADP.SelectCommand = miscDA
            miscADP.Fill(miscDS)
        Catch ex As Exception
            Return 0
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            Return 0
        Else
            Return miscDS.Tables(0).Rows(0)("LAST_CREATED_DOC")
        End If
    End Function
#Region "SONDA_OUTDOOR"
    <WebMethod(Description:="Search Bin by Key")> _
    Public Function LogRouteGPS(ByVal pRouteID As String, ByVal pGPS_URL As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldb_conexion.Open()

        Try

            Dim cmd As New SqlCommand

            cmd.Parameters.Add("@pROUTE_ID", SqlDbType.VarChar, 50)
            cmd.Parameters("@pROUTE_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@pROUTE_ID").Value = pRouteID

            cmd.Parameters.Add("@pGPS_URL", SqlDbType.VarChar, 250)
            cmd.Parameters("@pGPS_URL").Direction = ParameterDirection.Input
            cmd.Parameters("@pGPS_URL").Value = pGPS_URL

            cmd.Parameters.Add("@pRESULT", SqlDbType.VarChar, 250)
            cmd.Parameters("@pRESULT").Direction = ParameterDirection.Output
            cmd.Parameters("@pRESULT").Value = ""

            cmd.CommandText = "SONDA.[dbo].[SONDA_SP_LOG_ROUTE_GPS]"
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
    <WebMethod(Description:="Get my route plan")> _
    Public Function GetMyRoutePlan(ByVal pLoginID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String = ""

        Dim pDebugInfo As String = ""
        sqldb_conexion.Open()

        Try

            XSQL = " SELECT * "
            XSQL = XSQL + " FROM "
            XSQL = XSQL + " [SONDA].[dbo].[SONDA_FUNC_GET_MY_ROUTE_PLAN]('" + pLoginID + "')"

            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)

            If miscDA Is Nothing Then
                pResult = "ERROR, No hay pedidos a entregar "
                Return Nothing
            End If

            Dim miscDS As DataSet = New DataSet()
            pDebugInfo = "1"
            miscDA.Fill(miscDS, "GetMyRoutePlan")
            pDebugInfo = "2"
            If miscDS.Tables(0).Rows.Count <= 0 Then
                pResult = "ERROR, No hay pedidos a entregar "
                Return Nothing
            Else
                pResult = "OK"
                Return miscDS
            End If

        Catch ex As Exception
            pResult = "ERROR, " + ex.Message
            Return Nothing
        Finally
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try

    End Function
    <WebMethod(Description:="Get my delivery tasks")> _
    Public Function GetMyDocDetail(ByVal pLOGIN_ID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String = ""

        Dim pDebugInfo As String = ""
        sqldb_conexion.Open()

        Try

            XSQL = " SELECT * "
            XSQL = XSQL + " FROM "
            XSQL = XSQL + " [SONDA].[dbo].[SONDA_FUNC_GET_MY_DOC_DETAIL]('" + pLOGIN_ID + "')"

            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()
            pDebugInfo = "1"
            miscDA.Fill(miscDS, "GetMyDocDetail")
            pDebugInfo = "2"
            If miscDS.Tables(0).Rows.Count <= 0 Then
                pResult = "ERROR, No hay cajas a entregar para este pedido"
                Return Nothing
            Else
                pResult = "OK"
                Return miscDS
            End If

        Catch ex As Exception
            pResult = "ERROR, " + ex.Message
            Return Nothing
        Finally
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try

    End Function
    <WebMethod(Description:="Get my delivery tasks")> _
Public Function GetDriverInfo(ByVal pDriverLicense As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection = Nothing
        Dim XSQL As String = ""

        Dim pDebugInfo As String = ""


        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
            sqldb_conexion.Open()
        Catch ex As Exception
            pResult = "ERROR, " + ex.Message
            Return Nothing
        End Try

        Try

            XSQL = " SELECT "
            XSQL = XSQL & "    A.DRIVER_LICENSE, "
            XSQL = XSQL & "    A.DRIVER_NAME, "
            XSQL = XSQL & "    B.COMPANY_ID, "
            XSQL = XSQL & "    B.COMPANY_NAME "
            XSQL = XSQL & "FROM "
            XSQL = XSQL & "    SONDA.dbo.SONDA_TRANSPORT_DRIVERS A, "
            XSQL = XSQL & "    SONDA.dbo.SONDA_TRANSPORT_COMPANIES B "
            XSQL = XSQL & "WHERE "
            XSQL = XSQL & "    A.DRIVER_LICENSE = '" + pDriverLicense.Trim + "' AND "
            XSQL = XSQL & "    A.COMPANY_ID = B.COMPANY_ID "

            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()
            pDebugInfo = "1"
            miscDA.Fill(miscDS, "GetDriverInfo")
            pDebugInfo = "2"
            If miscDS.Tables(0).Rows.Count <= 0 Then
                pResult = "ERROR, Piloto no registrado "
                Return Nothing
            Else
                pResult = "OK"
                Return miscDS
            End If

        Catch ex As Exception
            pResult = "ERROR, " + ex.Message
            Return Nothing
        Finally
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try

    End Function
    <WebMethod(Description:="Get my delivery tasks")> _
   Public Function GetMyRoutePlan_ByStatus(ByVal pLoginID As String, ByVal pStatus As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String = ""

        Dim pDebugInfo As String = ""
        sqldb_conexion.Open()

        Try

            XSQL = " SELECT * "
            XSQL = XSQL + " FROM "
            XSQL = XSQL + " [SONDA].[dbo].[SONDA_FUNC_GET_MY_ROUTE_PLAN_BY_STATUS]('" + pLoginID + "', '" + pStatus + "')"

            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()
            pDebugInfo = "1"
            miscDA.Fill(miscDS, "GetMyRoutePlan_Delivered")
            pDebugInfo = "2"
            If miscDS.Tables(0).Rows.Count <= 0 Then
                pResult = "ERROR, No hay pedidos entregados "
                Return Nothing
            Else
                pResult = "OK"
                Return miscDS
            End If

        Catch ex As Exception
            pResult = "ERROR, " + ex.Message
            Return Nothing
        Finally
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try

    End Function
    <WebMethod(Description:="Process Delivery Order")> _
 Public Function ProcessDeliveryOrder(ByVal pIS_DELIVERY As Boolean, ByVal pERP_DOC As String, ByVal pGPS_URL As String, ByVal pIMAGE As Byte(), ByVal pLoginID As String, ByVal pNoDeliveryReason As String, ByVal pIS_ADDENDUM As Integer, ByVal pDOC_OWNER As Integer, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldb_conexion.Open()

        Try

            Dim cmd As New SqlCommand

            cmd.Parameters.Add("@pERP_DOC", SqlDbType.VarChar, 50)
            cmd.Parameters("@pERP_DOC").Direction = ParameterDirection.Input
            cmd.Parameters("@pERP_DOC").Value = pERP_DOC

            cmd.Parameters.Add("@pIS_DELIVERY", SqlDbType.Int)
            cmd.Parameters("@pIS_DELIVERY").Direction = ParameterDirection.Input
            cmd.Parameters("@pIS_DELIVERY").Value = IIf(pIS_DELIVERY, 0, 1) '0=DELIVERED / 1=NOT TO DELIVER

            cmd.Parameters.Add("@pGPS_URL", SqlDbType.VarChar, 250)
            cmd.Parameters("@pGPS_URL").Direction = ParameterDirection.Input
            cmd.Parameters("@pGPS_URL").Value = pGPS_URL

            cmd.Parameters.Add("@pIMAGE", SqlDbType.Image)
            cmd.Parameters("@pIMAGE").Direction = ParameterDirection.Input
            cmd.Parameters("@pIMAGE").Value = pIMAGE

            cmd.Parameters.Add("@pLOGIN_ID", SqlDbType.VarChar, 25)
            cmd.Parameters("@pLOGIN_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@pLOGIN_ID").Value = pLoginID

            cmd.Parameters.Add("@pNO_DELIVERY_REASON", SqlDbType.VarChar, 250)
            cmd.Parameters("@pNO_DELIVERY_REASON").Direction = ParameterDirection.Input
            cmd.Parameters("@pNO_DELIVERY_REASON").Value = pNoDeliveryReason

            cmd.Parameters.Add("@pDELIVERY_DATE", SqlDbType.DateTime)
            cmd.Parameters("@pDELIVERY_DATE").Direction = ParameterDirection.Input
            cmd.Parameters("@pDELIVERY_DATE").Value = Now.ToString

            cmd.Parameters.Add("@pIS_ADDENDUM", SqlDbType.Int)
            cmd.Parameters("@pIS_ADDENDUM").Direction = ParameterDirection.Input
            cmd.Parameters("@pIS_ADDENDUM").Value = CInt(pIS_ADDENDUM)

            cmd.Parameters.Add("@pDOC_OWNER", SqlDbType.Int)
            cmd.Parameters("@pDOC_OWNER").Direction = ParameterDirection.Input
            cmd.Parameters("@pDOC_OWNER").Value = CInt(pDOC_OWNER)

            cmd.Parameters.Add("@pRESULT", SqlDbType.VarChar, 250)
            cmd.Parameters("@pRESULT").Direction = ParameterDirection.Output
            cmd.Parameters("@pRESULT").Value = ""

            cmd.CommandText = "SONDA.[dbo].[SONDA_SP_PROCESS_DELIVERY_ORDER]"
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

    <WebMethod(Description:="Process Delivery Order")> _
    Public Function MarkRouteAsCompleted(ByVal pROUTE_ID As String, ByVal pLoginID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldb_conexion.Open()

        Try

            Dim cmd As New SqlCommand

            cmd.Parameters.Add("@pROUTE_ID", SqlDbType.VarChar, 25)
            cmd.Parameters("@pROUTE_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@pROUTE_ID").Value = pROUTE_ID

            cmd.Parameters.Add("@pLOGIN_ID", SqlDbType.VarChar, 25)
            cmd.Parameters("@pLOGIN_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@pLOGIN_ID").Value = pLoginID

            cmd.Parameters.Add("@pRESULT", SqlDbType.VarChar, 250)
            cmd.Parameters("@pRESULT").Direction = ParameterDirection.Output
            cmd.Parameters("@pRESULT").Value = ""

            cmd.CommandText = "SONDA.[dbo].[SONDA_SP_MARK_ROUTE_AS_COMPLETED]"
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


    <WebMethod(Description:="Search Bin by Key")> _
 Public Function UpdatePictureAndGPS(ByVal pERP_DOC As String, ByVal pGPS_URL As String, ByVal pIMAGE As Byte(), ByVal pLoginID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldb_conexion.Open()

        Try

            Dim cmd As New SqlCommand

            cmd.Parameters.Add("@pERP_DOC", SqlDbType.VarChar, 50)
            cmd.Parameters("@pERP_DOC").Direction = ParameterDirection.Input
            cmd.Parameters("@pERP_DOC").Value = pERP_DOC

            cmd.Parameters.Add("@pGPS_URL", SqlDbType.VarChar, 250)
            cmd.Parameters("@pGPS_URL").Direction = ParameterDirection.Input
            cmd.Parameters("@pGPS_URL").Value = pGPS_URL

            cmd.Parameters.Add("@pIMAGE", SqlDbType.Image)
            cmd.Parameters("@pIMAGE").Direction = ParameterDirection.Input
            cmd.Parameters("@pIMAGE").Value = pIMAGE

            cmd.Parameters.Add("@pLOGIN_ID", SqlDbType.VarChar, 25)
            cmd.Parameters("@pLOGIN_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@pLOGIN_ID").Value = pLoginID

            cmd.Parameters.Add("@pRESULT", SqlDbType.VarChar, 250)
            cmd.Parameters("@pRESULT").Direction = ParameterDirection.Output
            cmd.Parameters("@pRESULT").Value = ""

            cmd.CommandText = "SONDA.[dbo].[SONDA_SP_UPDATE_PICTURE_AND_GPS]"
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


#End Region

#Region "SONDA WEB PORTAL"
    <WebMethod(Description:="Get GetActiveRouteInfo_ByDate")> _
    Public Function GetActiveRouteInfo_ByDate(ByVal pSinceDate As String, ByVal pToDate As String, ByVal pLOGIN_ID As String, ByVal pROLE_ID As String, ByVal pStatus As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection = Nothing
        Dim XconnStr As String = AppSettings(pEnvironmentName).ToString

        Try
            sqldb_conexion = New SqlConnection(XconnStr)
            sqldb_conexion.Open()
        Catch ex As SqlException
            pResult = "ERROR," + ex.Message + " " & ex.ErrorCode & " Server: " & ex.Server & " Misc: " & ex.StackTrace.ToString
            Return Nothing
        End Try

        Dim XSQL As String = ""

        Dim pDebugInfo As String = ""


        Try


            'format date: yyyyMMdd
            XSQL = " SELECT * "
            XSQL = XSQL + " FROM "

            If pROLE_ID = "TRACKING_SONDA" Then
                If pStatus <> "*" Then
                    XSQL = XSQL + " [SONDA].[dbo].[SONDA_FUNC_GET_ACTIVE_ROUTES_INFO]('" + pSinceDate + "','" + pToDate + "') WHERE STATUS = '" + pStatus + "' AND CLIENT_ROUTE  IN (SELECT Z.ROUTE_ID FROM " + AppSettings("SONDA_DB_OWNER").ToString + ".SONDA_VIEW_ROUTES_BY_TRACKING_OPERATORS Z WHERE Z.ACTIVE_TRACKING_OPERATOR_ID = '" + pLOGIN_ID + "') ORDER BY DELIVERY_DATE DESC"
                Else
                    XSQL = XSQL + " [SONDA].[dbo].[SONDA_FUNC_GET_ACTIVE_ROUTES_INFO]('" + pSinceDate + "','" + pToDate + "') WHERE CLIENT_ROUTE  IN (SELECT Z.ROUTE_ID FROM " + AppSettings("SONDA_DB_OWNER").ToString + ".SONDA_VIEW_ROUTES_BY_TRACKING_OPERATORS Z WHERE Z.ACTIVE_TRACKING_OPERATOR_ID = '" + pLOGIN_ID + "') ORDER BY DELIVERY_DATE DESC"
                End If
            Else
                If pStatus <> "*" Then
                    XSQL = XSQL + " [SONDA].[dbo].[SONDA_FUNC_GET_ACTIVE_ROUTES_INFO]('" + pSinceDate + "','" + pToDate + "') WHERE STATUS = '" + pStatus + "' ORDER BY DELIVERY_DATE DESC"
                Else
                    XSQL = XSQL + " [SONDA].[dbo].[SONDA_FUNC_GET_ACTIVE_ROUTES_INFO]('" + pSinceDate + "','" + pToDate + "') ORDER BY DELIVERY_DATE DESC"
                End If
            End If



            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()
            pDebugInfo = "1"
            miscDA.Fill(miscDS, "GetActiveRouteInfo_ByDate")
            pDebugInfo = "2"
            If miscDS.Tables(0).Rows.Count <= 0 Then
                pResult = "ERROR, No hay pedidos en ruta para estas fechas: " + XSQL
                Return Nothing
            Else
                pResult = "OK"
                Return miscDS
            End If

        Catch ex As Exception
            pResult = "ERROR, " + ex.Message
            Return Nothing
        Finally
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try

    End Function
    <WebMethod(Description:="Get GetActiveRouteInfo_ByDoc")> _
    Public Function GetActiveRouteInfo_ByDoc(ByVal pERP_DOC As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection = Nothing

        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
        End Try

        Dim XSQL As String = ""

        Dim pDebugInfo As String = ""
        sqldb_conexion.Open()

        Try
            XSQL = " SELECT * "
            XSQL = XSQL + " FROM "
            XSQL = XSQL + " [SONDA].[dbo].[SONDA_FUNC_GET_ROUTE_INFO]('" + pERP_DOC + "') ORDER BY CLIENT_NAME"

            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()
            pDebugInfo = "1"
            miscDA.Fill(miscDS, "GetActiveRouteInfo_ByDoc")
            pDebugInfo = "2"
            If miscDS.Tables(0).Rows.Count <= 0 Then
                pResult = "ERROR, No hay informacion de este documento"
                Return Nothing
            Else
                pResult = "OK"
                Return miscDS
            End If

        Catch ex As Exception
            pResult = "ERROR, " + ex.Message
            Return Nothing
        Finally
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try

    End Function
    <WebMethod(Description:="Get GetRouteImage")> _
    Public Function GetRouteImage(ByVal pERP_DOC As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection = Nothing

        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
        End Try

        Dim XSQL As String = ""

        Dim pDebugInfo As String = ""
        sqldb_conexion.Open()

        Try
            XSQL = " SELECT * "
            XSQL = XSQL + " FROM "
            XSQL = XSQL + " [SONDA].[dbo].[SONDA_FUNC_GET_ROUTE_IMAGE]('" + pERP_DOC + "')"

            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()
            pDebugInfo = "1"
            miscDA.Fill(miscDS, "GetRouteImage")
            pDebugInfo = "2"
            If miscDS.Tables(0).Rows.Count <= 0 Then
                pResult = "ERROR, No hay IMAGEN de este documento"
                Return Nothing
            Else
                pResult = "OK"
                Return miscDS
            End If

        Catch ex As Exception
            pResult = "ERROR, " + ex.Message
            Return Nothing
        Finally
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try

    End Function
    <WebMethod(Description:="Get GetRouteOverview_003")> _
    Public Function GetRouteOverview_003(ByVal pLOGIN_ID As String, ByVal pROLE_ID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection = Nothing

        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
        End Try

        Dim XSQL As String = ""

        Dim pDebugInfo As String = ""
        sqldb_conexion.Open()

        Try
            XSQL = " SELECT ROUTE_ID, PERC_FINISHED, DELIVERY_COMPANY_NAME, DELIVERY_DRIVER_NAME "
            XSQL = XSQL + " FROM " + AppSettings("SONDA_DB_OWNER").ToString + ".SONDA_VIEW_ROUTE_OVERVIEW_002 "

            If pROLE_ID = "TRACKING_SONDA" Then
                XSQL = XSQL + "WHERE ROUTE_ID IN (SELECT Z.ROUTE_ID FROM " + AppSettings("SONDA_DB_OWNER").ToString + ".SONDA_VIEW_ROUTES_BY_TRACKING_OPERATORS Z WHERE Z.ACTIVE_TRACKING_OPERATOR_ID = '" + pLOGIN_ID + "') "
            End If
            XSQL = XSQL + "ORDER BY ROUTE_ID "

            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()
            pDebugInfo = "1"
            miscDA.Fill(miscDS, "GetRouteOverview_003")
            pDebugInfo = "2"
            If miscDS.Tables(0).Rows.Count <= 0 Then
                pResult = "ERROR, No hay informacion de planes de ruta"
                Return Nothing
            Else
                pResult = "OK"
                Return miscDS
            End If

        Catch ex As Exception
            pResult = "ERROR, " + ex.Message
            Return Nothing
        Finally
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try

    End Function


    <WebMethod(Description:="Get GetRouteOverview_Avg")> _
Public Function GetRouteOverview_Avg(ByVal pLOGIN_ID As String, ByVal pROLE_ID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Double
        Dim sqldb_conexion As SqlConnection = Nothing

        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return False
            Exit Function
        End Try

        Dim XSQL As String = ""

        Dim pDebugInfo As String = ""
        sqldb_conexion.Open()

        Try
            XSQL = " SELECT AVG(PERC_FINISHED) AS AVG_FINISHED "
            XSQL = XSQL + " FROM " + AppSettings("SONDA_DB_OWNER").ToString + ".SONDA_VIEW_ROUTE_OVERVIEW_002 "
            If pROLE_ID = "TRACKING_SONDA" Then
                XSQL = XSQL + " WHERE ROUTE_ID  IN (SELECT Z.ROUTE_ID FROM " + AppSettings("SONDA_DB_OWNER").ToString + ".SONDA_VIEW_ROUTES_BY_TRACKING_OPERATORS Z WHERE Z.ACTIVE_TRACKING_OPERATOR_ID = '" + pLOGIN_ID + "')"
            End If

            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()
            pDebugInfo = "1"
            miscDA.Fill(miscDS, "GetRouteOverview_Avg")
            pDebugInfo = "2"
            If miscDS.Tables(0).Rows.Count <= 0 Then
                pResult = "ERROR, No hay informacion de planes de ruta"
                Return -1
            Else
                pResult = "OK"
                Return miscDS.Tables(0).Rows(0)("AVG_FINISHED")
            End If

        Catch ex As Exception
            pResult = "ERROR, " + ex.Message
            Return -1
        Finally
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try

    End Function

    <WebMethod(Description:="Get GetActiveRouteStats")> _
    Public Function GetActiveRouteStats(ByVal pROUTE_ID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection = Nothing

        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
        End Try

        Dim XSQL As String = ""

        Dim pDebugInfo As String = ""
        sqldb_conexion.Open()

        Try
            XSQL = " SELECT * "
            XSQL = XSQL + " FROM "
            XSQL = XSQL + " [SONDA].[dbo].[SONDA_FUNC_GET_ROUTE_DELIVERY_STATS]('" + pROUTE_ID + "') order by primer_pedido desc"

            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()
            pDebugInfo = "1"
            miscDA.Fill(miscDS, "GetActiveRouteStats")
            pDebugInfo = "2"
            If miscDS.Tables(0).Rows.Count <= 0 Then
                pResult = "ERROR, No hay informacion para esta ruta " + pROUTE_ID
                Return Nothing
            Else
                pResult = "OK"
                Return miscDS
            End If

        Catch ex As Exception
            pResult = "ERROR, " + ex.Message
            Return Nothing
        Finally
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try

    End Function

    <WebMethod(Description:="Get GetRoutesByOperators")> _
    Public Function GetRoutesByOperators(ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection = Nothing

        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
        End Try

        Dim XSQL As String = ""

        Dim pDebugInfo As String = ""
        sqldb_conexion.Open()

        Try
            XSQL = " SELECT * "
            XSQL = XSQL + " FROM "
            XSQL = XSQL + " " + AppSettings("SONDA_DB_OWNER").ToString + ".SONDA_VIEW_ROUTES_BY_TRACKING_OPERATORS ORDER BY LOGIN_NAME"

            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()
            pDebugInfo = "1"
            miscDA.Fill(miscDS, "GetRoutesByOperators")
            pDebugInfo = "2"
            If miscDS.Tables(0).Rows.Count <= 0 Then
                pResult = "ERROR, No hay informacion para operadores de seguimiento de rutas"
                Return Nothing
            Else
                pResult = "OK"
                Return miscDS
            End If

        Catch ex As Exception
            pResult = "ERROR, " + ex.Message
            Return Nothing
        Finally
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try

    End Function

    <WebMethod(Description:="Get GetTrackingOperators")> _
    Public Function GetTrackingOperators(ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection = Nothing

        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
        End Try

        Dim XSQL As String = ""

        Dim pDebugInfo As String = ""
        sqldb_conexion.Open()

        Try
            XSQL = " SELECT * "
            XSQL = XSQL + " FROM "
            XSQL = XSQL + " " + AppSettings("SONDA_DB_OWNER").ToString + ".SONDA_VIEW_TRACKING_OPERATORS ORDER BY LOGIN_NAME"

            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()
            pDebugInfo = "1"
            miscDA.Fill(miscDS, "GetTrackingOperators")
            pDebugInfo = "2"
            If miscDS.Tables(0).Rows.Count <= 0 Then
                pResult = "ERROR, No hay información para operadores de seguimiento de rutas"
                Return Nothing
            Else
                pResult = "OK"
                Return miscDS
            End If

        Catch ex As Exception
            pResult = "ERROR, " + ex.Message
            Return Nothing
        Finally
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try

    End Function

    <WebMethod(Description:="Get RelateOperatorWithRoute")> _
        Public Function RelateOperatorWithRoute(ByVal pLOGIN_ID As String, ByVal pROUTE_ID As String, ByVal pLAST_UPDATE_BY As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean
        
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldb_conexion.Open()

        Try

            Dim cmd As New SqlCommand

            cmd.Parameters.Add("@pLOGIN", SqlDbType.VarChar, 25)
            cmd.Parameters("@pLOGIN").Direction = ParameterDirection.Input
            cmd.Parameters("@pLOGIN").Value = pLOGIN_ID

            cmd.Parameters.Add("@pROUTE_ID", SqlDbType.VarChar, 25)
            cmd.Parameters("@pROUTE_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@pROUTE_ID").Value = pROUTE_ID

            cmd.Parameters.Add("@pRESULT", SqlDbType.VarChar, 250)
            cmd.Parameters("@pRESULT").Direction = ParameterDirection.Output
            cmd.Parameters("@pRESULT").Value = ""

            cmd.CommandText = "SONDA.[dbo].[SONDA_SP_RELATE_TRACKING_OPERATOR_TO_ROUTE]"
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

    <WebMethod(Description:="Get SwitchOperatorRoutes")> _
        Public Function SwitchOperatorRoutes(ByVal pSource_LoginID As String, ByVal pTarget_LoginID As String, ByVal pLAST_UPDATE_BY As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldb_conexion.Open()

        Try

            Dim cmd As New SqlCommand

            cmd.Parameters.Add("@pSOURCE_LOGIN", SqlDbType.VarChar, 25)
            cmd.Parameters("@pSOURCE_LOGIN").Direction = ParameterDirection.Input
            cmd.Parameters("@pSOURCE_LOGIN").Value = pSource_LoginID

            cmd.Parameters.Add("@pTARGET_LOGIN", SqlDbType.VarChar, 25)
            cmd.Parameters("@pTARGET_LOGIN").Direction = ParameterDirection.Input
            cmd.Parameters("@pTARGET_LOGIN").Value = pTarget_LoginID

            cmd.Parameters.Add("@pRESULT", SqlDbType.VarChar, 250)
            cmd.Parameters("@pRESULT").Direction = ParameterDirection.Output
            cmd.Parameters("@pRESULT").Value = ""

            cmd.CommandText = "SONDA.[dbo].[SONDA_SP_SWITCH_TRACKING_OPERATOR]"
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

    <WebMethod(Description:="Create Transport Document")> _
    Public Function CreateRouteGuide(ByVal pROUTE_ID As String, ByVal pGATE_ID As Integer, ByVal pDELIVERY_ASSIGNED_TO As String, ByVal pLAST_UPDATE_BY As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim XSQL As String = ""
        Dim pDebug = "0"


        Try
            Dim pTrans As SqlTransaction = Nothing

            XSQL = "DELETE FROM " + AppSettings("SONDA_DB_OWNER").ToString + ".SONDA_LOADING_GUIDE"
            XSQL = XSQL + " WHERE ROUTE_ID = '" + pROUTE_ID + "'"

            If ExecuteSqlTransaction(AppSettings(pEnvironmentName).ToString, XSQL, pResult) Then
                XSQL = "INSERT INTO " + AppSettings("SONDA_DB_OWNER").ToString + ".SONDA_LOADING_GUIDE("
                XSQL = XSQL + "ROUTE_ID," '1
                XSQL = XSQL + "GATE_ID," '1
                XSQL = XSQL + "LOADING_STATUS," '2
                XSQL = XSQL + "DELIVERY_ASSIGNED_TO," '2
                XSQL = XSQL + "DELIVERY_DRIVER_NAME," '2
                XSQL = XSQL + "DELIVERY_COMPANY_ID," '2
                XSQL = XSQL + "DELIVERY_COMPANY_NAME," '2
                XSQL = XSQL + "LAST_UPDATE_BY," '2
                XSQL = XSQL + "LAST_UPDATE)" '2
                XSQL = XSQL + "VALUES ("
                XSQL = XSQL + "'" + pROUTE_ID + "'," '2
                XSQL = XSQL + pGATE_ID.ToString + "," '2
                XSQL = XSQL + "'CREATED'," '2
                XSQL = XSQL + "'" + pDELIVERY_ASSIGNED_TO + "'," '2
                XSQL = XSQL + "(SELECT A.DRIVER_NAME FROM " + AppSettings("SONDA_DB_OWNER").ToString + ".SONDA_TRANSPORT_DRIVERS A WHERE A.DRIVER_LICENSE = '" + pDELIVERY_ASSIGNED_TO + "'),"
                XSQL = XSQL + "(SELECT A.COMPANY_ID FROM " + AppSettings("SONDA_DB_OWNER").ToString + ".SONDA_TRANSPORT_DRIVERS A WHERE A.DRIVER_LICENSE = '" + pDELIVERY_ASSIGNED_TO + "')," '2
                XSQL = XSQL + "(SELECT B.COMPANY_NAME FROM " + AppSettings("SONDA_DB_OWNER").ToString + ".SONDA_TRANSPORT_COMPANIES B WHERE B.COMPANY_ID  =  (SELECT A.COMPANY_ID FROM " + AppSettings("SONDA_DB_OWNER").ToString + ".SONDA_TRANSPORT_DRIVERS A WHERE A.DRIVER_LICENSE = '" + pDELIVERY_ASSIGNED_TO + "'))," '2
                XSQL = XSQL + "'" + pLAST_UPDATE_BY + "'," '2
                XSQL = XSQL + "CURRENT_TIMESTAMP)" '2

                pDebug = "1 " + pEnvironmentName

                If ExecuteSqlTransaction(AppSettings(pEnvironmentName).ToString, XSQL, pResult) Then
                    pResult = "OK"
                End If


            Else
                Return False
            End If

        Catch ex As Exception
            pResult = ex.Message + " debug: " + pDebug
            Return -1
        End Try
        Return True
    End Function

    <WebMethod(Description:="Get GetLoadingGuide")> _
    Public Function GetLoadingGuide(ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection = Nothing
        Dim EmptyDS As New DataSet

        Dim EmptyTB As New DataTable
        Dim xCol0 As New DataColumn("GATE_ID", System.Type.GetType("System.String"))
        Dim xCol1 As New DataColumn("ROUTE_ID", System.Type.GetType("System.String"))
        Dim xCol2 As New DataColumn("LOADING_STATUS", System.Type.GetType("System.String"))
        Dim xCol3 As New DataColumn("DELIVERY_ASSIGNED_TO", System.Type.GetType("System.String"))
        Dim xCol4 As New DataColumn("DELIVERY_DRIVER_NAME", System.Type.GetType("System.String"))
        Dim xCol5 As New DataColumn("DELIVERY_COMPANY_ID", System.Type.GetType("System.String"))
        Dim xCol6 As New DataColumn("DELIVERY_COMPANY_NAME", System.Type.GetType("System.String"))
        Dim xCol7 As New DataColumn("LAST_UPDATE_BY", System.Type.GetType("System.String"))
        Dim xCol8 As New DataColumn("LAST_UPDATE", System.Type.GetType("System.String"))

        EmptyTB.Columns.Add(xCol0)
        EmptyTB.Columns.Add(xCol1)
        EmptyTB.Columns.Add(xCol2)
        EmptyTB.Columns.Add(xCol3)
        EmptyTB.Columns.Add(xCol4)
        EmptyTB.Columns.Add(xCol5)
        EmptyTB.Columns.Add(xCol6)
        EmptyTB.Columns.Add(xCol7)
        EmptyTB.Columns.Add(xCol8)

        EmptyDS.Tables.Add(EmptyTB)

        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
        End Try

        Dim XSQL As String = ""

        Dim pDebugInfo As String = ""
        sqldb_conexion.Open()

        Try
            XSQL = " SELECT * "
            XSQL = XSQL + " FROM "
            XSQL = XSQL + " " + AppSettings("SONDA_DB_OWNER").ToString + ".SONDA_LOADING_GUIDE ORDER BY ROUTE_ID"

            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()
            pDebugInfo = "1"
            miscDA.Fill(miscDS, "GetLoadingGuide")
            pDebugInfo = "2"
            If miscDS.Tables(0).Rows.Count <= 0 Then
                pResult = "ERROR, No hay información para distribución de rutas en puertas de despacho"
                Return EmptyDS
            Else
                pResult = "OK"
                Return miscDS
            End If

        Catch ex As Exception
            pResult = "ERROR, " + ex.Message
            Return EmptyDS
        Finally
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try

    End Function

    <WebMethod(Description:="Get my counting tasks")> _
    Public Function GetDrivers(ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String = ""

        Dim pDebugInfo As String = ""
        sqldb_conexion.Open()

        Try

            XSQL = "        SELECT COMPANY_ID as Empresa, DRIVER_LICENSE as Codigo, DRIVER_NAME as Piloto"
            XSQL = XSQL + " FROM "
            XSQL = XSQL + " " + AppSettings("SONDA_DB_OWNER").ToString + ".SONDA_TRANSPORT_DRIVERS ORDER BY COMPANY_ID, DRIVER_NAME "

            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()
            pDebugInfo = "1"
            miscDA.Fill(miscDS, "GetDrivers")
            pDebugInfo = "2"
            If miscDS.Tables(0).Rows.Count <= 0 Then
                pResult = "ERROR, No hay pilotos disponibles "
                Return Nothing
            Else
                pResult = "OK"
                Return miscDS
            End If

        Catch ex As Exception
            pResult = "ERROR, " + ex.Message
            Return Nothing
        Finally
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try

    End Function


    <WebMethod(Description:="Create Transport Document")> _
    Public Function DeleteRouteGuide(ByVal pROUTE_ID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim XSQL As String = ""
        Dim pDebug = "0"

        Try
            Dim pTrans As SqlTransaction = Nothing

            XSQL = "DELETE FROM " + AppSettings("SONDA_DB_OWNER").ToString + ".SONDA_LOADING_GUIDE"
            XSQL = XSQL + " WHERE ROUTE_ID = '" + pROUTE_ID + "'"

            If ExecuteSqlTransaction(AppSettings(pEnvironmentName).ToString, XSQL, pResult) Then

            Else
                Return False
            End If

        Catch ex As Exception
            pResult = ex.Message + " debug: " + pDebug
            Return -1
        End Try
        Return True
    End Function

    <WebMethod(Description:="Create Transport Document")> _
    Public Function ClearUpRouteGuide(ByVal pROUTE_ID As String, ByVal pLAST_UPDATE_BY As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim XSQL As String = ""
        Dim pDebug = "0"

        Try
            Dim pTrans As SqlTransaction = Nothing

            XSQL = "UPDATE " + AppSettings("SONDA_DB_OWNER").ToString + ".SONDA_LOADING_GUIDE "
            XSQL = XSQL + " SET GATE_ID = NULL, DELIVERY_ASSIGNED_TO=NULL, DELIVERY_DRIVER_NAME=NULL, DELIVERY_COMPANY_ID=NULL, DELIVERY_COMPANY_NAME=NULL, LAST_UPDATE_BY='" + pLAST_UPDATE_BY + "', LAST_UPDATE = CURRENT_TIMESTAMP"
            XSQL = XSQL + " WHERE ROUTE_ID = '" + pROUTE_ID + "'"

            If ExecuteSqlTransaction(AppSettings(pEnvironmentName).ToString, XSQL, pResult) Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            pResult = ex.Message + " debug: " + pDebug
            Return -1
        End Try

    End Function


    <WebMethod(Description:="Get GetLoadingGuide")> _
   Public Function GetLoadingGuideByRoute(byval pROUTE_ID as string, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection = Nothing

        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
        End Try

        Dim XSQL As String = ""

        Dim pDebugInfo As String = ""
        sqldb_conexion.Open()

        Try
            XSQL = " SELECT * "
            XSQL = XSQL + " FROM "
            XSQL = XSQL + AppSettings("SONDA_DB_OWNER").ToString + ".SONDA_LOADING_GUIDE WHERE ROUTE_ID = '" + pROUTE_ID + "'"

            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()
            pDebugInfo = "1"
            miscDA.Fill(miscDS, "GetLoadingGuideByRoute")
            pDebugInfo = "2"
            If miscDS.Tables(0).Rows.Count <= 0 Then
                pResult = "ERROR, No hay información para distribución para la ruta " + pROUTE_ID
                Return Nothing
            Else
                pResult = "OK"
                Return miscDS
            End If

        Catch ex As Exception
            
            pResult = "ERROR, " + ex.Message
            LogSQLErrors("GetLoadingGuideByRoute: " + pResult, XSQL, "")

            Return Nothing
        Finally
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try

    End Function

    <WebMethod(Description:="Get counting overview by operator")> _
    Public Function GetMyRouteManifest(ByVal pRouteID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings("SONDA").ToString)
        Dim XSQL As String = ""

        Dim pDebugInfo As String = ""
        sqldb_conexion.Open()

        Try

            XSQL = "SELECT 	A.ROUTE_ID, DELIVERY_ASSIGNED_TO, DELIVERY_DRIVER_NAME, DELIVERY_COMPANY_NAME,"
            XSQL = XSQL + " (CAJAS-PREMIOS)AS CAJAS, (CAJAS+PREMIOS) AS BULTOS,  "
            XSQL = XSQL + " ERP_DOC, DELIVERY_CLIENT_NAME FROM SONDA_VIEW_ROUTE_MANIFEST A"
            XSQL = XSQL + " WHERE "
            XSQL = XSQL + " ROUTE_ID = '" + Trim(UCase(pRouteID)) + "'"
            XSQL = XSQL + " ORDER BY delivery_assigned_to, delivery_client_name"

            pDebugInfo = "0"

            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()
            pDebugInfo = "1"
            miscDA.Fill(miscDS, "GetMyRouteManifest")


            pDebugInfo = "2"
            If miscDS.Tables(0).Rows.Count <= 0 Then
                pResult = "ERROR, No hay informacion para la ruta [" + pRouteID + "] "
                Return Nothing
            Else
                pResult = "OK"
                Return miscDS
            End If

        Catch ex As Exception
            pResult = "ERROR, " + ex.Message + " pDebugInfo: "
            Return Nothing
        Finally
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try

    End Function
    <WebMethod(Description:="Search Bin by Key")> _
    Public Function TestConnection(ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldb_conexion As SqlConnection = Nothing

        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
            sqldb_conexion.Open()

            sqldb_conexion.Close()
            pResult = "OK"
            Return True

        Catch ex As Exception
            pResult = ex.Message
            Return False
        Finally
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try


    End Function
#End Region

End Class