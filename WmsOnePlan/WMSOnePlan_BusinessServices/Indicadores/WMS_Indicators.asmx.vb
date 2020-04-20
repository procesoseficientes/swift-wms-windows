Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports System.Configuration.ConfigurationManager
Imports System.Data.SqlClient

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class WMS_Indicators
    Inherits System.Web.Services.WebService

#Region "Reports"
    <WebMethod()> _
    Public Function getRejects(ByVal pDateFrom As Date, ByVal pDateTo As Date, ByRef pResult As String, ByVal pEnvironment As String) As DataSet

        'Dim sql_conexion As SqlConnection = New SqlConnection(AppSettings("DESARROLLO").ToString)
        'Dim sql_conexion As SqlConnection = New SqlConnection(AppSettings("DESARROLLO").ToString)
        Dim sql_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironment).ToString)
        Dim sbQuery As New StringBuilder
        Try

            sbQuery.Append("SELECT * FROM " & DefaultSchema & "VW_MB_REJECTS WHERE 1=1 ")

            'sbQuery.Append("SELECT * FROM test WHERE 1=1 ")

            If pDateFrom.Year > 1900 And pDateTo.Year > 1900 Then
                sbQuery.Append(" AND SHIFT_DATE_START BETWEEN TO_DATE('" & Format(pDateFrom, "yyyy/MM/dd") & "','yyyy/mm/dd') AND TO_DATE('" & Format(pDateTo, "yyyy/MM/dd") & "','yyyy/mm/dd')")
            ElseIf pDateFrom.Year > 1900 And Not pDateTo.Year > 1900 Then
                'sbQuery.Append(" AND SHIFT_DATE_START >= '" & pDateFrom & "'")
                sbQuery.Append(" AND SHIFT_DATE_START >= TO_DATE('" & Format(pDateFrom, "yyyy/MM/dd") & "','yyyy/mm/dd')")
            ElseIf Not pDateFrom.Year > 1900 And pDateTo.Year > 1900 Then
                'sbQuery.Append(" AND SHIFT_DATE_START <= '" & pDateTo & "'")
                sbQuery.Append(" AND SHIFT_DATE_START <= TO_DATE('" & Format(pDateTo, "yyyy/MM/dd") & "','yyyy/mm/dd')")
            End If


            'Dim miscDA As SqlDataAdapter = New SqlDataAdapter(sbQuery.ToString, sql_conexion)
            'Dim miscDA As SqlDataAdapter = New SqlDataAdapter(sbQuery.ToString, sql_conexion)
            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(sbQuery.ToString, sql_conexion)
            'miscDA.ReturnProviderSpecificTypes = True  'J.R. no funciona con OracleClient solo con OleDb
            Dim miscDS As DataSet = New DataSet()

            miscDA.Fill(miscDS, "getRejects")

            If miscDS.Tables(0).Rows.Count = 0 Then
                pResult = "No data available"
                Return Nothing
            Else
                pResult = "OK"
                Return miscDS
            End If

        Catch ex As Exception
            pResult = "getRejects: " + ex.Message
            Return Nothing
        End Try

    End Function

    <WebMethod()> _
    Public Function getModulesSummary(ByVal pDateFrom As Date, ByVal pDateTo As Date, ByRef pResult As String, ByVal pEnvironment As String) As DataSet

        Dim sql_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironment).ToString)
        Dim sbQuery As New StringBuilder
        Try

            sbQuery.Append("SELECT * FROM " & DefaultSchema & "VW_MB_MODULES_SUMMARY WHERE 1=1 ")

            If pDateFrom.Year > 1900 And pDateTo.Year > 1900 Then
                sbQuery.Append(" AND SHIFT_DATE_START BETWEEN TO_DATE('" & Format(pDateFrom, "yyyy/MM/dd") & "','yyyy/mm/dd') AND TO_DATE('" & Format(pDateTo, "yyyy/MM/dd") & "','yyyy/mm/dd')")
            ElseIf pDateFrom.Year > 1900 And Not pDateTo.Year > 1900 Then
                'sbQuery.Append(" AND SHIFT_DATE_START >= '" & pDateFrom & "'")
                sbQuery.Append(" AND SHIFT_DATE_START >= TO_DATE('" & Format(pDateFrom, "yyyy/MM/dd") & "','yyyy/mm/dd')")
            ElseIf Not pDateFrom.Year > 1900 And pDateTo.Year > 1900 Then
                'sbQuery.Append(" AND SHIFT_DATE_START <= '" & pDateTo & "'")
                sbQuery.Append(" AND SHIFT_DATE_START <= TO_DATE('" & Format(pDateTo, "yyyy/MM/dd") & "','yyyy/mm/dd')")
            End If


            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(sbQuery.ToString, sql_conexion)
            'miscDA.ReturnProviderSpecificTypes = True  'J.R. no funciona con OracleClient solo con OleDb
            Dim miscDS As DataSet = New DataSet()

            miscDA.Fill(miscDS, "getModulesSummary")

            If miscDS.Tables(0).Rows.Count = 0 Then
                pResult = "No data available"
                Return Nothing
            Else
                pResult = "OK"
                Return miscDS
            End If

        Catch ex As Exception
            pResult = "getModulesSummary: " + ex.Message
            Return Nothing
        End Try

    End Function

    <WebMethod()> _
    Public Function getRejectIDs(ByRef pResult As String, ByVal pEnvironment As String) As DataSet

        Dim sql_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironment).ToString)
        Dim sbQuery As New StringBuilder
        Try

            sbQuery.Append("SELECT MAX(COUNTER_ID) COUNTER_ID, MAX(COUNTER_NAME) COUNTER_NAME, LABEL FROM " & DefaultSchema & "MAIN_COUNTERS GROUP BY LABEL ORDER BY LABEL")

            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(sbQuery.ToString, sql_conexion)
            'miscDA.ReturnProviderSpecificTypes = True  'J.R. no funciona con OracleClient solo con OleDb
            Dim miscDS As DataSet = New DataSet()

            miscDA.Fill(miscDS, "getRejectIDs")

            If miscDS.Tables(0).Rows.Count = 0 Then
                pResult = "No data available"
                Return Nothing
            Else
                pResult = "OK"
                Return miscDS
            End If

        Catch ex As Exception
            pResult = "getRejectIDs: " + ex.Message
            Return Nothing
        End Try

    End Function

    <WebMethod()> _
    Public Function getStopIDs(ByRef pResult As String, ByVal pEnvironment As String) As DataSet

        Dim sql_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironment).ToString)
        Dim sbQuery As New StringBuilder
        Try

            sbQuery.Append("SELECT MAX(STOP_ID) COUNTER_ID, MAX(STOP_NAME) COUNTER_NAME, LABEL FROM " & DefaultSchema & "MAIN_STOPS GROUP BY LABEL ORDER BY LABEL")

            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(sbQuery.ToString, sql_conexion)
            'miscDA.ReturnProviderSpecificTypes = True  'J.R. no funciona con OracleClient solo con OleDb
            Dim miscDS As DataSet = New DataSet()

            miscDA.Fill(miscDS, "getStopIDs")

            If miscDS.Tables(0).Rows.Count = 0 Then
                pResult = "No data available"
                Return Nothing
            Else
                pResult = "OK"
                Return miscDS
            End If

        Catch ex As Exception
            pResult = "getStopIDs: " + ex.Message
            Return Nothing
        End Try

    End Function

#End Region


#Region "Profiles"

    <WebMethod()> _
    Public Function saveNewProfile(ByVal pProfileModuleID As String, ByVal pProfileName As String, ByVal pLayoutID As String, ByVal pUser As String, ByRef pResult As String, ByVal pEnvironment As String) As Boolean


        Dim sql_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironment).ToString)
        Dim pTrans As SqlTransaction = Nothing ''''
        Dim sbQuery As New StringBuilder
        Try


            ''sbQuery.Append("INSERT INTO OP_WMS_MAIN_PROFILES (PROFILE_MODULE_ID, PROFILE_NAME, PROFILE_USER) ")
            ''sbQuery.Append("VALUES ('" + pProfileModuleID + "','" + pProfileName + "','" + pUser + "')")

            ''FileOpen(1, "c:\" + pProfileModuleID + "~" + pProfileName + "~" + pUser + ".txt", OpenMode.Output, OpenAccess.Write, OpenShare.Default)
            ''WriteLine(1, pLayoutID)
            ''FileClose(1)

            ''sbQuery.Append("INSERT INTO OP_WMS_MAIN_PROFILES (PROFILE_MODULE_ID, PROFILE_NAME, PROFILE_USER, PROFILE_LAYOUT_ID) ")
            ''sbQuery.Append("VALUES ('" + pProfileModuleID + "','" + pProfileName + "','" + pUser + "','" + pLayoutID + "')")

            'sql_conexion.Open()
            'pTrans = sql_conexion.BeginTransaction(IsolationLevel.Serializable)
            'If ExecuteSqlTransaction(pTrans, sbQuery.ToString, pResult) Then
            '    pTrans.Commit()
            '    sql_conexion.Close()
            '    pResult = "OK"
            '    Return True
            'Else
            '    pTrans.Rollback()
            '    sql_conexion.Close()
            '    Return False
            'End If

            Dim xcmd As New SqlCommand
            Dim xParm As New SqlParameter

            sql_conexion.Open()

            xcmd.Connection = sql_conexion
            xcmd.CommandText = DefaultSchema & "OP_WMS_SP_SAVE_PROFILE"
            xcmd.CommandType = CommandType.StoredProcedure
            xcmd.Parameters.AddWithValue("pProfileModuleID", pProfileModuleID)
            xcmd.Parameters.AddWithValue("pProfileName", pProfileName)
            xcmd.Parameters.AddWithValue("pUser", pUser)
            xcmd.Parameters.AddWithValue("pLayoutID", pLayoutID)

            xcmd.ExecuteNonQuery()
            sql_conexion.Close()

            pResult = "OK"
            Return True

        Catch ex As Exception
            pResult = "saveNewProfile: " + ex.Message
            Return False
        End Try

    End Function

    <WebMethod()> _
    Public Function updateProfile(ByVal pProfileModuleID As String, ByVal pProfileName As String, ByVal pLayoutID As Object, ByVal pUser As String, ByRef pResult As String, ByVal pEnvironment As String) As Boolean

        Dim sql_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironment).ToString)
        Dim sbQuery As New StringBuilder
        Try

            Dim xcmd As New SqlCommand
            Dim xParm As New SqlParameter

            sql_conexion.Open()

            xcmd.Connection = sql_conexion
            xcmd.CommandText = DefaultSchema & "OP_WMS_SP_UPDATE_PROFILE"
            xcmd.CommandType = CommandType.StoredProcedure
            xcmd.Parameters.AddWithValue("pProfileModuleID", pProfileModuleID)
            xcmd.Parameters.AddWithValue("pProfileName", pProfileName)
            xcmd.Parameters.AddWithValue("pUser", pUser)
            xcmd.Parameters.AddWithValue("pLayoutID", pLayoutID)

            xcmd.ExecuteNonQuery()
            sql_conexion.Close()

            pResult = "OK"
            Return True

        Catch ex As Exception
            pResult = "updateProfile: " + ex.Message
            Return False
        End Try

    End Function

    <WebMethod()> _
    Public Function getProfilesByUser(ByVal pProfileModuleID As String, ByVal pUser As String, ByRef pResult As String, ByVal pEnvironment As String) As DataSet

        Dim sql_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironment).ToString)
        Dim sbQuery As New StringBuilder
        Try

            sbQuery.Append("SELECT PROFILE_NAME FROM " & DefaultSchema & "OP_WMS_MAIN_PROFILES WHERE PROFILE_MODULE_ID = '" + pProfileModuleID + "' AND PROFILE_USER = '" + pUser + "' ")

            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(sbQuery.ToString, sql_conexion)
            'miscDA.ReturnProviderSpecificTypes = True  'J.R. no funciona con OracleClient solo con OleDb
            Dim miscDS As DataSet = New DataSet()

            miscDA.Fill(miscDS, "getProfilesByUser")

            If miscDS.Tables(0).Rows.Count = 0 Then
                pResult = "NO DATA FOUND"
                Return Nothing
            Else
                pResult = "OK"
                Return miscDS
            End If

        Catch ex As Exception
            pResult = "getProfilesByUser: " + ex.Message
            Return Nothing
        End Try

    End Function

    <WebMethod()> _
    Public Function getUserProfileByID(ByVal pProfileModuleID As String, ByVal pProfileName As String, ByVal pUser As String, ByRef pResult As String, ByVal pEnvironment As String) As String

        'Dim sql_conexion As OleDbConnection = New OleDbConnection(AppSettings(pEnvironment).ToString)
        Dim sql_conexion As SqlConnection = New SqlConnection(AppSettings("DESARROLLO").ToString)
        Dim sbQuery As New StringBuilder
        Try


            Dim xcmd As New SqlCommand
            Dim xParm As New SqlParameter

            sql_conexion.Open()

            xcmd.Connection = sql_conexion
            xcmd.CommandText = DefaultSchema & "OP_WMS_FUNC_READ_PROFILE"
            xcmd.CommandType = CommandType.StoredProcedure

            xcmd.Parameters.Add("pProfileModuleID", SqlDbType.VarChar).Value = pProfileModuleID
            xcmd.Parameters.Add("pProfileName", SqlDbType.VarChar).Value = pProfileName
            xcmd.Parameters.Add("pUser", SqlDbType.VarChar).Value = pUser
            xcmd.Parameters.Add("pLayoutID", SqlDbType.VarChar, 5000).Direction = ParameterDirection.ReturnValue

            xcmd.ExecuteNonQuery()
            sql_conexion.Close()

            pResult = "OK"
            Return xcmd.Parameters(3).Value

        Catch ex As Exception
            pResult = "getUserProfileByID: " + ex.Message
            Return ""
        End Try

    End Function

    <WebMethod()> _
    Public Function deleteProfile(ByVal pProfileModuleID As String, ByVal pProfileName As String, ByVal pUser As String, ByRef pResult As String, ByVal pEnvironment As String) As Boolean

        'Dim sql_conexion As OleDbConnection = New OleDbConnection(AppSettings(pEnvironment).ToString)
        Dim sql_conexion As SqlConnection = New SqlConnection(AppSettings("DESARROLLO").ToString)
        Dim pTrans As SqlTransaction = Nothing
        Dim sbQuery As New StringBuilder
        Try

            sbQuery.Append("DELETE FROM " & DefaultSchema & "OP_WMS_MAIN_PROFILES WHERE PROFILE_MODULE_ID = '" + pProfileModuleID + "' AND PROFILE_NAME = '" + pProfileName + "' AND PROFILE_USER = '" + pUser + "' ")

            sql_conexion.Open()
            pTrans = sql_conexion.BeginTransaction(IsolationLevel.Serializable)
            If ExecuteSqlTransaction(pTrans, sbQuery.ToString, pResult) Then
                pTrans.Commit()
                Return True
            Else
                pTrans.Rollback()
                Return False
            End If

        Catch ex As Exception
            pResult = "getProfilesByUser: " + ex.Message
            Return Nothing
        End Try

    End Function

#End Region


#Region "Miscelaneous"

    <WebMethod()> _
    Public Function getReportSpecifications(ByVal pReportID As String, ByRef pResult As String, ByVal pEnvironment As String) As DataSet

        Dim sql_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironment).ToString)
        Dim sbQuery As New StringBuilder
        Try

            sbQuery.Append("SELECT * FROM " & DefaultSchema & "OP_WMS_MAIN_REPORTS_FIELDS WHERE REPORT_ID = '" + pReportID + "' ")

            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(sbQuery.ToString, sql_conexion)
            'miscDA.ReturnProviderSpecificTypes = True  'J.R. no funciona con OracleClient solo con OleDb
            Dim miscDS As DataSet = New DataSet()

            miscDA.Fill(miscDS, "getReportSpecifications")

            If miscDS.Tables(0).Rows.Count = 0 Then
                pResult = "NO DATA FOUND"
                Return Nothing
            Else
                pResult = "OK"
                Return miscDS
            End If

        Catch ex As Exception
            pResult = "getReportSpecifications: " + ex.Message
            Return Nothing
        End Try

    End Function

    <WebMethod()> _
    Public Function getDataByReportID(ByVal pReportID As String, ByVal pDateFrom As Date, ByVal pDateTo As Date, ByVal pParam3 As String, ByVal pParam4 As String, ByRef pResult As String, ByVal pEnvironment As String) As DataSet

        Dim sql_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironment).ToString)
        Dim sbQuery As New StringBuilder
        Try

            sbQuery.Append("SELECT * FROM " & DefaultSchema & "OP_WMS_MAIN_REPORTS WHERE REPORT_ID = '" + pReportID + "' ")

            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(sbQuery.ToString, sql_conexion)
            'miscDA.ReturnProviderSpecificTypes = True  'J.R. no funciona con OracleClient solo con OleDb
            Dim miscDS As DataSet = New DataSet()

            miscDA.Fill(miscDS, "getReportQuery")

            If miscDS.Tables(0).Rows.Count = 0 Then
                pResult = "NO DATA FOUND"
                Return Nothing
            Else

                Dim strQuery As String = "" & miscDS.Tables(0).Rows(0)("REPORT_QUERY").ToString

                'usar Format en lugar de Replace para parsear Query

                strQuery = String.Format(strQuery, Format(pDateFrom, "yyyy/MM/dd"), Format(pDateTo, "yyyy/MM/dd"), pParam3, pParam4)

                'strQuery = strQuery.Replace("mb_pDateFrom", Format(pDateFrom, "yyyy/MM/dd"))
                'strQuery = strQuery.Replace("mb_pDateTo", Format(pDateTo, "yyyy/MM/dd"))

                sbQuery.Remove(0, sbQuery.Length - 1)
                sbQuery.Append(strQuery)
                Dim miscDA_Report As SqlDataAdapter = New SqlDataAdapter(sbQuery.ToString, sql_conexion)
                Dim miscDS_Report As DataSet = New DataSet()

                miscDA_Report.Fill(miscDS_Report, "getDataByReportID")

                If miscDS_Report.Tables(0).Rows.Count = 0 Then
                    pResult = "NO DATA FOUND"
                    Return Nothing
                Else

                    pResult = "OK"
                    Return miscDS_Report

                End If

            End If

        Catch ex As Exception
            pResult = "getDataByReportID: " + ex.Message
            Return Nothing
        End Try

    End Function

    <WebMethod()> _
    Public Function getTrendDataByReportID(ByVal pReportID As String, ByVal pDateFrom As Date, ByVal pDateTo As Date, ByVal pFiltro As String, ByRef pResult As String, ByVal pEnvironment As String) As DataSet

        Dim sql_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironment).ToString)
        Dim sbQuery As New StringBuilder
        Try

            sbQuery.Append("SELECT * FROM " & DefaultSchema & "OP_WMS_MAIN_REPORTS WHERE REPORT_ID = '" + pReportID + "' ")

            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(sbQuery.ToString, sql_conexion)
            'miscDA.ReturnProviderSpecificTypes = True  'J.R. no funciona con OracleClient solo con OleDb
            Dim miscDS As DataSet = New DataSet()

            miscDA.Fill(miscDS, "getReportQuery")

            If miscDS.Tables(0).Rows.Count = 0 Then
                pResult = "NO DATA FOUND"
                Return Nothing
            Else

                Dim strQuery As String = "" & miscDS.Tables(0).Rows(0)("REPORT_QUERY").ToString

                'usar Format en lugar de Replace para parsear Query

                strQuery = String.Format(strQuery, Format(pDateFrom, "yyyy/MM/dd"), Format(pDateTo, "yyyy/MM/dd"), pFiltro)

                'strQuery = strQuery.Replace("mb_pDateFrom", Format(pDateFrom, "yyyy/MM/dd"))
                'strQuery = strQuery.Replace("mb_pDateTo", Format(pDateTo, "yyyy/MM/dd"))

                sbQuery.Remove(0, sbQuery.Length - 1)
                sbQuery.Append(strQuery)
                Dim miscDA_Report As SqlDataAdapter = New SqlDataAdapter(sbQuery.ToString, sql_conexion)
                Dim miscDS_Report As DataSet = New DataSet()

                miscDA_Report.Fill(miscDS_Report, "getTrendDataByReportID")

                If miscDS_Report.Tables(0).Rows.Count = 0 Then
                    pResult = "NO DATA FOUND"
                    Return Nothing
                Else

                    pResult = "OK"
                    Return miscDS_Report

                End If

            End If

        Catch ex As Exception
            pResult = "getDataByReportID: " + ex.Message
            Return Nothing
        End Try

    End Function

    <WebMethod()> _
    Public Function getHoursByWorkedDays(ByRef pResult As String, ByVal pEnvironment As String) As DataSet

        Dim sql_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironment).ToString)
        Dim sbQuery As New StringBuilder
        Try

            sbQuery.Append("SELECT * FROM " & DefaultSchema & "OP_WMS_WORKED_HOURS_BY_DAY ORDER BY WORKED_DAY DESC")

            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(sbQuery.ToString, sql_conexion)
            Dim miscDS As DataSet = New DataSet()

            miscDA.Fill(miscDS, "getHoursByWorkedDays")

            If miscDS.Tables(0).Rows.Count = 0 Then
                pResult = "NO DATA FOUND"
                Return Nothing
            Else

                pResult = "OK"
                Return miscDS

            End If

        Catch ex As Exception
            pResult = "getHoursByWorkedDays: " + ex.Message
            Return Nothing
        End Try

    End Function

    <WebMethod()> _
    Public Function saveHoursByDate(ByVal pDate As Date, ByVal pHours As Integer, ByRef pResult As String, ByVal pEnvironment As String) As Boolean

        'Dim sql_conexion As OleDbConnection = New OleDbConnection(AppSettings(pEnvironment).ToString)
        Dim sql_conexion As SqlConnection = New SqlConnection(AppSettings("DESARROLLO").ToString)
        Dim pTrans As SqlTransaction = Nothing
        Dim sbQuery As New StringBuilder
        Try

            sbQuery.Append("INSERT INTO " & DefaultSchema & "OP_WMS_WORKED_HOURS_BY_DAY (WORKED_DAY, WORKED_HOURS) VALUES ('" + Format(pDate, "yyyy/MM/dd").ToString + "', " + pHours.ToString + ")")

            sql_conexion.Open()
            pTrans = sql_conexion.BeginTransaction(IsolationLevel.Serializable)
            If ExecuteSqlTransaction(pTrans, sbQuery.ToString, pResult) Then
                pTrans.Commit()
                Return True
            Else
                pTrans.Rollback()
                If InStr(pResult, "Primary Key Constraint", CompareMethod.Text) Then
                    pResult = "Fecha ya tiene definicion de Horas Trabajadas, imposible duplicar!"
                End If
                Return False
            End If

        Catch ex As Exception
            pResult = "saveHoursByDate: " + ex.Message
            Return False
        End Try

    End Function

    <WebMethod()> _
    Public Function deleteHoursByDate(ByVal pDate As Date, ByRef pResult As String, ByVal pEnvironment As String) As Boolean

        'Dim sql_conexion As OleDbConnection = New OleDbConnection(AppSettings(pEnvironment).ToString)
        Dim sql_conexion As SqlConnection = New SqlConnection(AppSettings("DESARROLLO").ToString)
        Dim pTrans As SqlTransaction = Nothing
        Dim sbQuery As New StringBuilder
        Try

            sbQuery.Append("DELETE FROM " & DefaultSchema & "OP_WMS_WORKED_HOURS_BY_DAY WHERE WORKED_DAY = '" + Format(pDate, "yyyy/MM/dd").ToString + "'")

            sql_conexion.Open()
            pTrans = sql_conexion.BeginTransaction(IsolationLevel.Serializable)
            If ExecuteSqlTransaction(pTrans, sbQuery.ToString, pResult) Then
                pTrans.Commit()
                Return True
            Else
                pTrans.Rollback()
                Return False
            End If

        Catch ex As Exception
            pResult = "deleteHoursByDate: " + ex.Message
            Return False
        End Try

    End Function

#End Region

End Class