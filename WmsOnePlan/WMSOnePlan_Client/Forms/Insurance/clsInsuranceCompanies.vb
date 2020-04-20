Imports System.ComponentModel

Public Class clsInsuranceCompanies
    Public _COMPANY_ID As String
    Public _COMPANY_NAME As String
    Public _CREATED_DATE As String
    Public _CREATED_BY As String

    <Category("Datos Generales"), Description("Codigo de la compania")> _
    Public Property Codigo() As String
        Get
            Return _COMPANY_ID
        End Get
        Set(ByVal Value As String)
            _COMPANY_ID = Value
        End Set
    End Property

    <Category("Datos Generales"), Description("Nombre de la compania")> _
    Public Property Nombre() As String
        Get
            Return _COMPANY_NAME
        End Get
        Set(ByVal Value As String)
            _COMPANY_NAME = Value
        End Set
    End Property

    <Category("Datos de Auditoria"), Description("Fecha de creacion")> _
    Public Property FechaCreacion() As String
        Get
            Return _CREATED_DATE
        End Get
        Set(ByVal Value As String)
            _CREATED_DATE = Value
        End Set
    End Property

    <Category("Datos de Auditoria"), Description("Usuario que los Creo")> _
    Public Property UsuarioCreacion() As String
        Get
            Return _CREATED_BY
        End Get
        Set(ByVal Value As String)
            _CREATED_BY = Value
        End Set
    End Property

    Public Function Create(ByRef pResult As String) As Boolean
        Dim pLocalResult As String = ""
        Try
            Dim xserv As New OnePlanServices_Insurance_Companies.WMS_Insurance_CompaniesSoapClient("WMS_Insurance_CompaniesSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Insurance_Companies.asmx")

            Dim dsData As New DataSet

            dsData = xserv.Exist_Insurance_Companie(Codigo, PublicLoginInfo.Environment, pLocalResult)
            If pLocalResult = "OK" Then
                If Integer.Parse(dsData.Tables(0).Rows(0)(0)) = 0 Then
                    pLocalResult = ""
                    Dim grabo As New Boolean
                    grabo = xserv.CreateInsuranceCompany(Codigo, Nombre, PublicLoginInfo.LoginID, pLocalResult, PublicLoginInfo.Environment)
                    If grabo Then
                        If pLocalResult = "OK" Then
                            pResult = "OK"
                            Return True
                        Else
                            pResult = pLocalResult
                            Return False
                        End If
                    Else
                        pResult = pLocalResult
                        Return False
                    End If
                Else
                    pResult = "Error: El codigo ya existe"
                    Return False
                End If
            Else
                pResult = pLocalResult
                Return False
            End If
        Catch ex As Exception
            pResult = ex.Message
            Return False
        End Try
    End Function

    Public Function Update(ByRef pResult As String) As Boolean
        Dim pLocalResult As String = ""
        Try
            Dim xserv As New OnePlanServices_Insurance_Companies.WMS_Insurance_CompaniesSoapClient("WMS_Insurance_CompaniesSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Insurance_Companies.asmx")

            Dim grabo As New Boolean
            grabo = xserv.UpdateInsuranceCompany(Codigo, Nombre, pLocalResult, PublicLoginInfo.Environment)
            If grabo Then
                If pLocalResult = "OK" Then
                    pResult = "OK"
                    Return True
                Else
                    pResult = pLocalResult
                    Return False
                End If
            Else
                pResult = pLocalResult
                Return False
            End If
        Catch ex As Exception
            pResult = ex.Message
            Return False
        End Try
    End Function

    Public Function Delete(ByRef pResult As String) As Boolean
        Dim pLocalResult As String = ""
        Try
            Dim xserv As New OnePlanServices_Insurance_Companies.WMS_Insurance_CompaniesSoapClient("WMS_Insurance_CompaniesSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Insurance_Companies.asmx")

            If xserv.DeleteInsuranceCompany(Codigo, pLocalResult, PublicLoginInfo.Environment) Then
                Return True
            Else
                pResult = pLocalResult
                Return False
            End If
        Catch ex As Exception
            pResult = ex.Message
            Return False
        End Try
    End Function

End Class
