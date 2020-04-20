Imports System.ComponentModel

Public Class clsCheckPoint
    Public _PRIV_ID As String
    Public _PRIV_NAME As String
    Public _PRIV_GROUP As String
    <Category("Datos Generales"), Description("Codigo del punto de control maximo 25 caracteres")> _
       Public Property Codigo() As String
        Get
            Return _PRIV_ID
        End Get
        Set(ByVal Value As String)
            _PRIV_ID = Value
        End Set
    End Property
    <Category("Datos Generales"), Description("Nombre del punto de control maximo 50 caracteres")> _
       Public Property Nombre() As String
        Get
            Return _PRIV_NAME
        End Get
        Set(ByVal Value As String)
            _PRIV_NAME = Value
        End Set
    End Property
    <Category("Datos Generales"), Description("Grupo del punto de control maximo 25 caracteres")> _
       Public Property Grupo() As String
        Get
            Return _PRIV_GROUP
        End Get
        Set(ByVal Value As String)
            _PRIV_GROUP = Value
        End Set
    End Property

    Public Function Grabar(ByRef pResult As String) As Boolean
        Dim pLocalResult As String = ""
        Try
            Dim xserv As New OnePlanServices_Security.WMS_SecuritySoapClient("WMS_SecuritySoap", PublicLoginInfo.WSHost + "/Catalogues/wms_security.asmx")
            xserv.SearchByKeyCheckPoint(Codigo, pLocalResult, PublicLoginInfo.Environment)
            If pLocalResult = "OK" Then 'Update the record
                If xserv.UpdateCheckPoint(Codigo, Nombre, Grupo, pLocalResult, PublicLoginInfo.Environment) Then
                    Return True
                Else
                    pResult = pLocalResult
                    Return False
                End If
            Else 'Add new record
                If xserv.CreateCheckPoint(Codigo, Nombre, Grupo, pLocalResult, PublicLoginInfo.Environment) Then
                    Return True
                Else
                    pResult = pLocalResult
                    Return False
                End If
            End If
        Catch ex As Exception
            pResult = ex.Message
            Return False
        End Try
    End Function

    Public Function Delete(ByRef pResult As String) As Boolean
        Dim pLocalResult As String = ""
        Try
            Dim xserv As New OnePlanServices_Security.WMS_SecuritySoapClient("WMS_SecuritySoap", PublicLoginInfo.WSHost + "/Catalogues/wms_security.asmx")
            If xserv.DeleteCheckPoint(Codigo, pLocalResult, PublicLoginInfo.Environment) Then
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


