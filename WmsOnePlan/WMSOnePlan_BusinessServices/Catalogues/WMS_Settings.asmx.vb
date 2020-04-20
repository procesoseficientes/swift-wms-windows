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
Public Class WMS_Settings
    Inherits System.Web.Services.WebService


    <WebMethod(Description:="Returns a dataset with the different params type from OP_WMS_CONFIGURATIONS table")>
    Public Function GetParamTypes(ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim miscDA As SqlDataAdapter = New SqlDataAdapter("SELECT DISTINCT(PARAM_TYPE) AS PARAM_TYPE FROM " & DefaultSchema & "OP_WMS_CONFIGURATIONS", sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "ParamTypes")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR,No hay tipos de parametros definidos"
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If
    End Function

    <WebMethod(Description:="Returns a dataset with the different params type from OP_WMS_CONFIGURATIONS table")>
    Public Function GetParamsChilds(ByVal pParamType As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim miscDA As SqlDataAdapter = New SqlDataAdapter("SELECT PARAM_GROUP, PARAM_GROUP_CAPTION AS PARAM_GROUP FROM " & DefaultSchema & "OP_WMS_CONFIGURATIONS WHERE PARAM_TYPE = '" + pParamType.ToUpper.Trim + "' GROUP BY PARAM_GROUP, PARAM_GROUP_CAPTION ", sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "ParamChild")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR,No hay parametros con ese tipo: " + pParamType.ToUpper
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If
    End Function
    <WebMethod(Description:="Returns a dataset with parameters based on a partial search for caption fields")>
    Public Function GetParam_PartialSearch(ByVal pParam_Partial_Caption As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String

        XSQL = "SELECT * FROM " & DefaultSchema & "OP_WMS_CONFIGURATIONS WHERE UPPER(PARAM_CAPTION) LIKE '%" + pParam_Partial_Caption.ToUpper.Trim + "%' OR UPPER(PARAM_GROUP_CAPTION) LIKE '%" + pParam_Partial_Caption.ToUpper.Trim + "%'  OR UPPER(PARAM_TYPE) LIKE '%" + pParam_Partial_Caption.ToUpper.Trim + "%' ORDER BY PARAM_TYPE, PARAM_GROUP_CAPTION, PARAM_CAPTION, NUMERIC_VALUE"
        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "Params")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR,No hay parametros con ese tipo: " + pParam_Partial_Caption.ToUpper + "/ " + XSQL
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If
    End Function
    <WebMethod(Description:="Returns a dataset based on an specific parameter ID")>
    Public Function GetParam_ByParamID(ByVal pParamID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String

        XSQL = "SELECT * FROM " & DefaultSchema & "OP_WMS_CONFIGURATIONS WHERE UPPER(PARAM_NAME) = '" +
        pParamID.ToUpper.Trim + "'"
        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "SingleParam")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR,No existe parametro : " + pParamID.ToUpper + "/ " + XSQL
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If
    End Function
    <WebMethod(Description:="Returns occupancy level pre-defined values")>
    Public Function GetOccupancyLeveles(ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String

        XSQL = "SELECT PARAM_CAPTION, NUMERIC_VALUE FROM  " + DefaultSchema + "OP_WMS_CONFIGURATIONS "
        XSQL = XSQL + " WHERE PARAM_TYPE = 'SISTEMA' AND PARAM_GROUP = 'NIVELES_OCUPACION' ORDER BY NUMERIC_VALUE"

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "SingleParam")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR,No existen niveles pre-definidos de ocupacion"
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If
    End Function

    <WebMethod(Description:="Returns a dataset based on the parameters table key (type, group, id)")>
    Public Function GetParam_ByParamKey(pParamType As String, pParamGroup As String, pParamId As String, ByRef pResult As String, pEnvironmentName As String) As DataSet
        Dim sqldbConexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()
        Try
            Dim sqlCmd = New SqlCommand($"{DefaultSchema}OP_WMS_SP_GET_CONFIGURATIONS", sqldbConexion)
            sqlCmd.CommandType = CommandType.StoredProcedure

            sqlCmd.Parameters.Add(New SqlParameter("@PARAM_TYPE", SqlDbType.VarChar, 25)).Value = pParamType
            sqlCmd.Parameters.Add(New SqlParameter("@PARAM_GROUP", SqlDbType.VarChar, 25)).Value = pParamGroup
            If Not String.IsNullOrEmpty(pParamId) Then
                sqlCmd.Parameters.Add(New SqlParameter("@PARAM_NAME", SqlDbType.VarChar, 50)).Value = pParamId
            End If

            Dim miscDa = New SqlDataAdapter(sqlCmd)
            Dim miscDs = New DataSet()

            miscDa.Fill(miscDs)
            If ThereAreParameter(miscDs) Then
                pResult = "ERROR, No existe parametro : " + pParamType.ToUpper + "/ " + pParamGroup.ToUpper + "/ " + pParamId.ToUpper
                Return miscDs
            Else
                pResult = "OK"
                Return miscDs
            End If
                       
        Catch ex As Exception
            pResult = ex.Message
            Return Nothing
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try
    End Function

    private Shared Function ThereAreParameter(dataset As DataSet) As Boolean
        return dataset.Tables(0).Rows.Count <= 0
    End Function



    <WebMethod(Description:="Create parameters registry")>
    Public Function CreateParams(ByVal pPARAM_TYPE As String, ByVal pPARAM_GROUP As String, ByVal pPARAM_GROUP_CAPTION As String, ByVal pPARAM_NAME As String, ByVal pPARAM_CAPTION As String, ByVal pNUMERIC_VALUE As Integer, ByVal pMONEY_VALUE As Double, ByVal pTEXT_VALUE As String, ByVal pDATE_VALUE As Date, ByVal pRANGE_NUM_START As Integer, ByVal pRANGE_NUM_END As Integer, ByVal pRANGE_DATE_START As Date, ByVal pRANGE_DATE_END As Date, ByVal pSPARE1 As String, ByVal pSPARE2 As String, ByRef pResult As String, ByVal pEnvironmentName As String, ByVal pDECIMAL_VALUE As Double, ByVal pSPARE3 As String, ByVal pSPARE4 As String, ByVal pSPARE5 As String, ByVal pCOLOR As String) As Boolean

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String = ""

        Try
            XSQL = "INSERT INTO " & DefaultSchema & "OP_WMS_CONFIGURATIONS" +
               "(PARAM_TYPE" +
               ",PARAM_GROUP" +
               ",PARAM_GROUP_CAPTION " +
               ",PARAM_NAME " +
               ",PARAM_CAPTION " +
               ",NUMERIC_VALUE " +
               ",MONEY_VALUE " +
               ",TEXT_VALUE " +
               ",DATE_VALUE " +
               ",RANGE_NUM_START " +
               ",RANGE_NUM_END " +
               ",RANGE_DATE_START " +
               ",RANGE_DATE_END " +
               ",SPARE1 " +
               ",SPARE2 " +
               ",DECIMAL_VALUE " +
               ",SPARE3 " +
               ",SPARE4 " +
               ",SPARE5 " +
               ",COLOR)" +
            "VALUES " +
                "('" + pPARAM_TYPE + "'" +
               ",'" + pPARAM_GROUP + "'" +
               ",'" + pPARAM_GROUP_CAPTION + "'" +
               ",'" + pPARAM_NAME + "'" +
               ",'" + pPARAM_CAPTION + "'" +
               "," + pNUMERIC_VALUE.ToString +
               "," + pMONEY_VALUE.ToString +
               ",'" + pTEXT_VALUE + "'" +
               "," + IIf(IsValidDate(pDATE_VALUE), "'" + pDATE_VALUE.Date.ToString("yyyy-MM-dd hh:mm:ss") + "'", "NULL") +
               "," + pRANGE_NUM_START.ToString +
               "," + pRANGE_NUM_END.ToString +
               "," + IIf(IsValidDate(pRANGE_DATE_START), "'" + pRANGE_DATE_START.Date.ToString("yyyy-MM-dd hh:mm:ss") + "'", "NULL") +
               "," + IIf(IsValidDate(pRANGE_DATE_END), "'" + pRANGE_DATE_END.Date.ToString("yyyy-MM-dd hh:mm:ss") + "'", "NULL") +
               ",'" + pSPARE1 + "'" +
               ",'" + pSPARE2 + "'" +
               "," + pDECIMAL_VALUE.ToString +
               ",'" + pSPARE3 + "'" +
               ",'" + pSPARE4 + "'" +
               ",'" + pSPARE5 + "'" +
               ",'" + pCOLOR + "')"

            If ExecuteSqlTransaction(sqldb_conexion.ConnectionString, XSQL, pResult) Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            pResult = ex.Message
            Return False
        End Try

    End Function


    <WebMethod(Description:="Update parameters based on key row")>
    Public Function UpdateParams(ByVal pPARAM_TYPE As String, ByVal pPARAM_GROUP As String, ByVal pPARAM_GROUP_CAPTION As String, ByVal pPARAM_NAME As String, ByVal pPARAM_CAPTION As String, ByVal pNUMERIC_VALUE As Integer, ByVal pMONEY_VALUE As Double, ByVal pTEXT_VALUE As String, ByVal pDATE_VALUE As Date, ByVal pRANGE_NUM_START As Integer, ByVal pRANGE_NUM_END As Integer, ByVal pRANGE_DATE_START As Date, ByVal pRANGE_DATE_END As Date, ByVal pSPARE1 As String, ByVal pSPARE2 As String, ByRef pResult As String, ByVal pEnvironmentName As String, ByVal pDECIMAL_VALUE As Double, ByVal pSPARE3 As String, ByVal pSPARE4 As String, ByVal pSPARE5 As String, ByVal pCOLOR As String) As Boolean


        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String = ""

        Try
            XSQL = " UPDATE " & DefaultSchema & "OP_WMS_CONFIGURATIONS SET " +
               " PARAM_GROUP='" + pPARAM_GROUP + "'" +
               " ,PARAM_GROUP_CAPTION ='" + pPARAM_GROUP_CAPTION + "'" +
               " ,PARAM_NAME = '" + pPARAM_NAME + "'" +
               " ,PARAM_CAPTION = '" + pPARAM_CAPTION + "'" +
               " ,NUMERIC_VALUE = " + pNUMERIC_VALUE.ToString +
               " ,MONEY_VALUE = " + pMONEY_VALUE.ToString +
               " ,TEXT_VALUE ='" + pTEXT_VALUE + "'" +
               " ,DATE_VALUE =" + IIf(IsValidDate(pDATE_VALUE), "'" + pDATE_VALUE.ToString("yyyy-MM-dd hh:mm:ss") + "'", "NULL") +
               " ,RANGE_NUM_START = " + pRANGE_NUM_START.ToString +
               " ,RANGE_NUM_END =" + pRANGE_NUM_END.ToString +
               " ,RANGE_DATE_START = " + IIf(IsValidDate(pRANGE_DATE_START), "'" + pRANGE_DATE_START.ToString("yyyy-MM-dd hh:mm:ss") + "'", "NULL") +
               " ,RANGE_DATE_END = " + IIf(IsValidDate(pRANGE_DATE_END), "'" + pRANGE_DATE_END.ToString("yyyy-MM-dd hh:mm:ss") + "'", "NULL") +
               " ,SPARE1 = '" + pSPARE1 + "'" +
               " ,SPARE2 = '" + pSPARE2 + "'" +
               " ,DECIMAL_VALUE = " + pDECIMAL_VALUE.ToString +
               " ,SPARE3 = '" + pSPARE3 + "'" +
               " ,SPARE4 = '" + pSPARE4 + "'" +
               " ,SPARE5 = '" + pSPARE5 + "'" +
               " ,COLOR = '" + pCOLOR + "'" +
            " WHERE PARAM_TYPE = '" + pPARAM_TYPE + "' AND PARAM_GROUP = '" + pPARAM_GROUP + "' AND PARAM_NAME = '" + pPARAM_NAME + "' "

            If ExecuteSqlTransaction(sqldb_conexion.ConnectionString, XSQL, pResult) Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            pResult = ex.Message
            Return False
        End Try

    End Function


    <WebMethod(Description:="Update parameters based on key row")>
    Public Function DeleteParam(ByVal pPARAM_TYPE As String, ByVal pPARAM_GROUP As String, ByVal pPARAM_NAME As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String = ""

        Try
            XSQL = "DELETE " & DefaultSchema & "OP_WMS_CONFIGURATIONS " +
            "WHERE PARAM_TYPE = '" + pPARAM_TYPE + "' AND PARAM_GROUP = '" + pPARAM_GROUP + "' AND PARAM_NAME = '" + pPARAM_NAME + "' "

            If ExecuteSqlTransaction(sqldb_conexion.ConnectionString, XSQL, pResult) Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            pResult = ex.Message
            Return False
        End Try

    End Function



    <WebMethod(Description:="Create a GridLayout")>
    Public Function CreateGridLayouts(ByVal pGRID_ID As String, ByVal pLOGIN_ID As String, ByVal pLAYOUT_XML As String, ByVal pLAYOUT_XML_APPERANCE As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String = ""
        Try
            XSQL = "INSERT INTO " & DefaultSchema & "OP_SETUP_GRIDS_LAYOUT("
            XSQL = XSQL + "GRID_ID,"
            XSQL = XSQL + "LOGIN_ID,"
            XSQL = XSQL + "LAYOUT_XML, LAYOUT_XML_APPERANCE)"
            XSQL = XSQL + "VALUES ("
            XSQL = XSQL + "'" + pGRID_ID.ToUpper + "',"
            XSQL = XSQL + "'" + pLOGIN_ID.ToUpper + "',"
            XSQL = XSQL + "'" + pLAYOUT_XML + "','" + pLAYOUT_XML_APPERANCE + "')"
            If ExecuteSqlTransaction(sqldb_conexion.ConnectionString, XSQL, pResult) Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            pResult = ex.Message
            Return False
        End Try

    End Function

    <WebMethod(Description:="Update a Grid Layout")>
    Public Function SetGridLayout(ByVal pGRID_ID As String, ByVal pLOGIN_ID As String, ByVal pLAYOUT_XML As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldb_conexion.Open()

        Try

            Dim cmd As New SqlCommand

            cmd.Parameters.Add("@pGRID_ID", SqlDbType.VarChar, 250)
            cmd.Parameters("@pGRID_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@pGRID_ID").Value = pGRID_ID

            cmd.Parameters.Add("@pLOGIN_ID", SqlDbType.VarChar, 25)
            cmd.Parameters("@pLOGIN_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@pLOGIN_ID").Value = pLOGIN_ID

            cmd.Parameters.Add("@pGRID_CRITERIA_FILTER", SqlDbType.VarChar, 500)
            cmd.Parameters("@pGRID_CRITERIA_FILTER").Direction = ParameterDirection.Input
            cmd.Parameters("@pGRID_CRITERIA_FILTER").Value = ""

            cmd.Parameters.Add("@pLAYOUT_XML", SqlDbType.VarChar, 2000)
            cmd.Parameters("@pLAYOUT_XML").Direction = ParameterDirection.Input
            cmd.Parameters("@pLAYOUT_XML").Value = pLAYOUT_XML

            cmd.Parameters.Add("@pRESULT", SqlDbType.VarChar, 250)
            cmd.Parameters("@pRESULT").Direction = ParameterDirection.Output
            cmd.Parameters("@pRESULT").Value = ""
            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_SET_GRID_LAYOUT]"

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

    <WebMethod(Description:="Get a GridLayout")>
    Public Function SearchByKeyGridLayouts(ByVal pGRID_ID As String, ByVal pLOGIN_ID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String = ""
        XSQL = "SELECT * FROM " & DefaultSchema & "OP_SETUP_GRIDS_LAYOUT"
        XSQL = XSQL + " WHERE "
        XSQL = XSQL + "UPPER(GRID_ID) = '" + pGRID_ID.ToUpper + "' AND "
        XSQL = XSQL + "UPPER(LOGIN_ID) = '" + pLOGIN_ID.ToUpper + "'"
        XSQL = XSQL + " ORDER BY "
        XSQL = XSQL + "GRID_ID, "
        XSQL = XSQL + "LOGIN_ID"

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "SearchByKey_GridLayouts")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR,No existe GridLayouts : " + pGRID_ID + " / " + pLOGIN_ID
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function

    '21-Feb-11 J.R. cambios para balanceo de pedidos por linea
    <WebMethod(Description:="Get a Line Balancing Size")>
    Public Function SearchLineBalancingBySize(ByVal pSIZE As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet

        Dim XSQL As String = ""
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        XSQL = "SELECT * FROM " & DefaultSchema & "OP_WMS_LINES_BALANCING"
        XSQL = XSQL + " WHERE "
        XSQL = XSQL + "UPPER(SIZE) = '" + pSIZE.ToUpper + "'"
        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "SearchLineBalancingBySize")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR,No existe Tamaño: " + pSIZE
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function

    '21-Feb-11 J.R. cambios para balanceo de pedidos por linea
    <WebMethod(Description:="Get Line Balancing Sizes by partial search")>
    Public Function SearchPartialBalancingBySize(ByVal pSIZE As String, ByVal pSIZE_DESCRIPTION As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet

        Dim XSQL As String = ""
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        XSQL = "SELECT * FROM " & DefaultSchema & "OP_WMS_LINES_BALANCING"
        XSQL = XSQL + " WHERE "
        XSQL = XSQL + "UPPER(SIZE) LIKE '%" + pSIZE.ToUpper + "%' OR "
        XSQL = XSQL + "UPPER(SIZE_DESCRIPTION) LIKE '%" + pSIZE_DESCRIPTION.ToUpper + "%'"
        XSQL = XSQL + " ORDER BY INITIAL_RANGE"
        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "SearchPartialBalancingBySize")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR,No existe Tamaño : " + pSIZE
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function

    '21-Feb-11 J.R. cambios para balanceo de pedidos por linea
    <WebMethod(Description:="Create a Line Balancing Size")>
    Public Function CreateLineBalancing(ByVal pSIZE As String, ByVal pSIZE_DESCRIPTION As String, ByVal pINITIAL_RANGE As Double, ByVal pFINAL_RANGE As Double, ByVal pLINE_1_PERCENT As Double, ByVal pLINE_2_PERCENT As Double, ByVal pLINE_3_PERCENT As Double, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String = ""
        Try
            XSQL = "INSERT INTO " & DefaultSchema & "OP_WMS_LINES_BALANCING("
            XSQL = XSQL + "SIZE,"
            XSQL = XSQL + "SIZE_DESCRIPTION,"
            XSQL = XSQL + "INITIAL_RANGE,"
            XSQL = XSQL + "FINAL_RANGE,"
            XSQL = XSQL + "LINE_1_PERCENT,"
            XSQL = XSQL + "LINE_2_PERCENT,"
            XSQL = XSQL + "LINE_3_PERCENT)"
            XSQL = XSQL + "VALUES ("
            XSQL = XSQL + "'" + pSIZE + "',"
            XSQL = XSQL + "'" + pSIZE_DESCRIPTION + "',"
            XSQL = XSQL + pINITIAL_RANGE.ToString + ","
            XSQL = XSQL + pFINAL_RANGE.ToString + ","
            XSQL = XSQL + pLINE_1_PERCENT.ToString + ","
            XSQL = XSQL + pLINE_2_PERCENT.ToString + ","
            XSQL = XSQL + pLINE_3_PERCENT.ToString + ")"
            If ExecuteSqlTransaction(sqldb_conexion.ConnectionString, XSQL, pResult) Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            pResult = ex.Message
            Return False
        End Try

    End Function

    '21-Feb-11 J.R. cambios para balanceo de pedidos por linea
    <WebMethod(Description:="Update a Line Balancing Size")>
    Public Function UpdateLineBalancing(ByVal pSIZE As String, ByVal pSIZE_DESCRIPTION As String, ByVal pINITIAL_RANGE As Double, ByVal pFINAL_RANGE As Double, ByVal pLINE_1_PERCENT As Double, ByVal pLINE_2_PERCENT As Double, ByVal pLINE_3_PERCENT As Double, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String = ""
        Try
            XSQL = "UPDATE " & DefaultSchema & "OP_WMS_LINES_BALANCING SET "
            XSQL = XSQL + "SIZE_DESCRIPTION = '" + pSIZE_DESCRIPTION + "',"
            XSQL = XSQL + "INITIAL_RANGE = " + pINITIAL_RANGE.ToString + ","
            XSQL = XSQL + "FINAL_RANGE = " + pFINAL_RANGE.ToString + ","
            XSQL = XSQL + "LINE_1_PERCENT = " + pLINE_1_PERCENT.ToString + ","
            XSQL = XSQL + "LINE_2_PERCENT = " + pLINE_2_PERCENT.ToString + ","
            XSQL = XSQL + "LINE_3_PERCENT = " + pLINE_3_PERCENT.ToString
            XSQL = XSQL + " WHERE "
            XSQL = XSQL + "SIZE = '" + pSIZE + "'"
            If ExecuteSqlTransaction(sqldb_conexion.ConnectionString, XSQL, pResult) Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            pResult = ex.Message
            Return False
        End Try

    End Function

    '21-Feb-11 J.R. cambios para balanceo de pedidos por linea
    <WebMethod(Description:="Delete a Line Balancing Size")>
    Public Function DeleteLineBalancing(ByVal pSIZE As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim XSQL As String = ""
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        XSQL = "DELETE " & DefaultSchema & "OP_WMS_LINES_BALANCING"
        XSQL = XSQL + " WHERE "
        XSQL = XSQL + "SIZE = '" + pSIZE + "'"
        Try
            If ExecuteSqlTransaction(sqldb_conexion.ConnectionString, XSQL, pResult) Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            pResult = ex.Message
            Return False
        End Try

    End Function
    <WebMethod(Description:="")>
    Public Function GetLabelsSetup(ByVal pLabelID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim miscDA As SqlDataAdapter = New SqlDataAdapter("SELECT * FROM " & DefaultSchema & "OP_SETUP_LABELS where LABEL_ID = '" + pLabelID + "'", sqldb_conexion)

        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "GetLabelsSetup")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR,No hay ese tipo de etiqueta solicitado: " + pLabelID
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If
    End Function

    <WebMethod(Description:="")>
    Public Function IsLabelID_In_Line(ByVal pLabelID As String, ByVal pLineID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim miscDA As SqlDataAdapter = New SqlDataAdapter("SELECT 1 FROM " & DefaultSchema & "OP_WMS_LABELS_JOIN_LINES where LABEL_ID = '" + pLabelID + "' AND LINE_ID = '" + pLineID + "'", sqldb_conexion)

        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "IsLabelID_In_Line")
        Catch ex As Exception
            Return False
            pResult = "ERROR," + ex.Message
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR,la etiqueta: " + pLabelID + " no esta relacionada con la linea: " + pLineID
            Return False
        Else
            pResult = "OK"
            Return True
        End If
    End Function

    <WebMethod(Description:="")>
    Public Function RelateLabel_Line(ByVal pLabelID As String, ByVal pLineID As String, ByVal pClearAllRelationship As Boolean, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim XSQL As String = ""
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Try

            If pClearAllRelationship Then
                XSQL = "DELETE " & DefaultSchema & "OP_WMS_LABELS_JOIN_LINES"
                XSQL = XSQL + " WHERE "
                XSQL = XSQL + " LABEL_ID = '" + pLabelID + "'"
                If ExecuteSqlTransaction(sqldb_conexion.ConnectionString, XSQL, pResult) Then
                    Return True
                Else
                    Return False
                End If

            End If

            XSQL = "DELETE " & DefaultSchema & "OP_WMS_LABELS_JOIN_LINES WHERE LINE_ID = '" + pLineID + "'"

            If ExecuteSqlTransaction(sqldb_conexion.ConnectionString, XSQL, pResult) Then

                XSQL = "INSERT INTO " & DefaultSchema & "OP_WMS_LABELS_JOIN_LINES"
                XSQL = XSQL + " (LINE_ID, LABEL_ID) VALUES('" + pLineID + "','" + pLabelID + "')"

                If ExecuteSqlTransaction(sqldb_conexion.ConnectionString, XSQL, pResult) Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If
        Catch ex As Exception
            pResult = ex.Message
            Return False
        End Try

    End Function
    <WebMethod(Description:="")>
    Public Function UpdateLabelSetup(ByVal pLabelID As String, ByVal pZPLCommands As String, ByVal pLoginID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim XSQL As String = ""
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Try
            XSQL = "UPDATE " & DefaultSchema & "OP_SETUP_LABELS SET LAST_ZPL_COMMANDS = ZPL_COMMANDS, ZPL_COMMANDS = '" + pZPLCommands + "', LAST_UPDATED=CURRENT_TIMESTAMP, LAST_LOGIN = '" + pLoginID + "' WHERE LABEL_ID = '" + pLabelID + "'"

            If ExecuteSqlTransaction(sqldb_conexion.ConnectionString, XSQL, pResult) Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            pResult = ex.Message
            Return False
        End Try

    End Function
    <WebMethod(Description:="")>
    Public Function GetLabelID_In_Line(ByVal pLineID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As String

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim miscDA As SqlDataAdapter = New SqlDataAdapter("SELECT LABEL_ID FROM " & DefaultSchema & "OP_WMS_LABELS_JOIN_LINES where LINE_ID = '" + pLineID + "'", sqldb_conexion)

        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "GetLabelID_In_Line")
            Return miscDS.Tables(0).Rows(0)("LABEL_ID").ToStringA

        Catch ex As Exception
            Return False
            pResult = "ERROR," + ex.Message
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR, la linea: " + pLineID + " no esta relacionada con ninguna etiqueta"
            Return False
        Else
            pResult = "OK"
            Return True
        End If
    End Function


    <WebMethod(Description:="Get handheld button configuration.")>
    Public Function GetHHButtonSettings(ByVal pModel As String, ByVal pManufacturer As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataTable

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim miscDA As SqlDataAdapter =
             New SqlDataAdapter(" EXEC " & DefaultSchema & "[OP_WMS_SP_GET_DEVICE_BUTTON_CONFIGURATION] @MANUFACTURER = '" + pManufacturer + "', @MODEL  = '" + pModel + "'", sqldb_conexion)

        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "ButtonConfiguration")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try

        pResult = "OK"
        Return miscDS.Tables(0)
    End Function

    <WebMethod(Description:="Obtiene un paramtro.")>
    Public Function GetParameter(groupId As string, parameterId As String, ByRef result As String, pEnvironmentName As String) As DataTable

        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()

        Try

            Dim cmd As New SqlCommand

            cmd.Parameters.Add("@GROUP_ID", SqlDbType.VarChar).Value = groupId
            cmd.Parameters.Add("@PARAMETER_ID", SqlDbType.VarChar).Value = parameterId

            cmd.CommandText = DefaultSchema & "[OP_WMS_SP_GET_PARAMETER]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            Dim miscDa = New SqlDataAdapter(cmd)
            Dim miscDt = New DataTable("GetParameter")

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