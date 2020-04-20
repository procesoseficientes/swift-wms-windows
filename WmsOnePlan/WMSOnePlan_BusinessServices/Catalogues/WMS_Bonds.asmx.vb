Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Configuration.ConfigurationManager
Imports System.ComponentModel
Imports System.Data.SqlClient
Imports WMSOnePlan_BusinessServices.ModuleServices
Imports System.Web.Script.Services

' Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class WMS_Bonds
    Inherits System.Web.Services.WebService

    <WebMethod(Description:="Create a bond")> _
    Public Function CreateBond(ByRef pCertificateId As Integer, ByVal pBondId As String, ByVal pAmount As Decimal,
                               ByVal pInsurenceCompanyId As String, ByVal pCurrency As String,
                               ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        Dim strSql As New StringBuilder
        Try

            strSql.Append(String.Format(" INSERT INTO {0}OP_WMS_BONDS(", DefaultSchema))
            strSql.Append(" CERTIFICATE_ID")
            strSql.Append(" , BOND_ID")
            strSql.Append(" , AMOUNT")
            strSql.Append(" , INSURANCES_COMPANY_ID")
            strSql.Append(" , CURRENCY")
            strSql.Append(" ) VALUES(")
            strSql.Append(String.Format(" {0}", pCertificateId))
            strSql.Append(String.Format(" , '{0}'", pBondId))
            strSql.Append(String.Format(" , '{0}'", pAmount))
            strSql.Append(String.Format(" , '{0}'", pInsurenceCompanyId))
            strSql.Append(String.Format(" , '{0}'", pCurrency))
            strSql.Append(" )")

            If ExecuteSqlTransaction(sqldb_conexion.ConnectionString, strSql.ToString, pResult) Then
                Return True
            End If
        Catch ex As Exception
            pResult = ex.Message
            Return False
        End Try
    End Function

    <WebMethod(Description:="Update a bond")> _
    Public Function UpdateBond(ByRef pCertificateId As Integer, ByVal pBondId As String, ByVal pAmount As Decimal,
                               ByVal pInsurenceCompanyId As String, ByVal pCurrency As String,
                               ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        Dim strSql As New StringBuilder
        Try

            strSql.Append(String.Format(" UPDATE {0}OP_WMS_BONDS SET", DefaultSchema))
            strSql.Append(String.Format(" AMOUNT = '{0}'", pAmount))
            strSql.Append(String.Format(" , INSURANCES_COMPANY_ID = '{0}'", pInsurenceCompanyId))
            strSql.Append(String.Format(" , BOND_ID = '{0}'", pBondId))
            strSql.Append(String.Format(" , CURRENCY = '{0}'", pCurrency))
            strSql.Append(String.Format(" WHERE CERTIFICATE_ID = {0}", pCertificateId))

            If ExecuteSqlTransaction(sqldb_conexion.ConnectionString, strSql.ToString, pResult) Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            pResult = ex.Message
            Return False
        End Try
    End Function

    <WebMethod(Description:="Delete a bond")> _
    Public Function DeleteBond(ByVal pCertificateId As Integer, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        Dim strSql As New StringBuilder
        Try

            strSql.Append(String.Format(" DELETE {0}OP_WMS_BONDS", DefaultSchema))
            strSql.Append(String.Format(" WHERE CERTIFICATE_ID = {0}", pCertificateId))

            If ExecuteSqlTransaction(sqldb_conexion.ConnectionString, strSql.ToString, pResult) Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            pResult = ex.Message
            Return False
        End Try
    End Function

    <WebMethod(Description:="Fill a bond")> _
    Public Function FillBond(ByVal pCertificateId As Integer, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        Dim strSql As New StringBuilder
        strSql.Append(" SELECT BOND_ID, AMOUNT, INSURANCES_COMPANY_ID, CURRENCY")
        strSql.Append(String.Format(" FROM {0}OP_WMS_BONDS ", DefaultSchema))
        strSql.Append(String.Format(" where CERTIFICATE_ID = {0}", pCertificateId))

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "FillBond")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR, No encontro el registro."
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function

End Class