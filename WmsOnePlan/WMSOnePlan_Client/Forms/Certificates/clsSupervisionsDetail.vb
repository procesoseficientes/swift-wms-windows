Imports System.ComponentModel

Public Class clsSupervisionsDetail
    Public _CODE As String
    Public _DESCRIPTION As String
    Public _QTY As String
    Public _COST As String

    <Category("Datos Generales"), Description("Codigo de la del detalle")> _
    Public Property Codigo() As String
        Get
            Return _CODE
        End Get
        Set(ByVal Value As String)
            _CODE = Value
        End Set
    End Property

    <Category("Datos Generales"), Description("Descripcion del detalle")> _
    Public Property Descripcion() As String
        Get
            Return _DESCRIPTION
        End Get
        Set(ByVal Value As String)
            _DESCRIPTION = Value
        End Set
    End Property

    <Category("Datos Generales"), Description("Cantidad del detalle")> _
    Public Property Cantidad() As String
        Get
            Return _QTY
        End Get
        Set(ByVal Value As String)
            _QTY = Value
        End Set
    End Property

    <Category("Datos Generales"), Description("Costo del detalle")> _
    Public Property Costo() As String
        Get
            Return _COST
        End Get
        Set(ByVal Value As String)
            _COST = Value
        End Set
    End Property

    Public Function Create(ByVal pSuperId As Integer, ByRef pResult As String) As Boolean
        Dim pLocalResult As String = ""
        Try
            Dim xserv As New OnePlanServices_SupervisionsDetail.WMS_SupervisionsDetailSoapClient("WMS_SupervisionsDetailSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_SupervisionsDetail.asmx")

            Dim dsData As New DataSet

            dsData = xserv.ExistSupervisionsDetail(pSuperId, Codigo, pLocalResult, PublicLoginInfo.Environment)
            If pLocalResult = "OK" Then
                If Integer.Parse(dsData.Tables(0).Rows(0)(0)) = 0 Then
                    pLocalResult = ""
                    If xserv.CreateSupervisionsDetail(pSuperId, Codigo, Descripcion, Decimal.Parse(Cantidad), Decimal.Parse(Costo), pLocalResult, PublicLoginInfo.Environment) Then
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

    Public Function Update(ByVal pSuperId As Integer, ByRef pResult As String) As Boolean
        Dim pLocalResult As String = ""
        Try
            Dim xserv As New OnePlanServices_SupervisionsDetail.WMS_SupervisionsDetailSoapClient("WMS_SupervisionsDetailSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_SupervisionsDetail.asmx")

            If xserv.UpdateSupervisionDetail(pSuperId, Codigo, Descripcion, Decimal.Parse(Cantidad), Decimal.Parse(Costo), pLocalResult, PublicLoginInfo.Environment) Then
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

    Public Function Delete(ByVal pSuperId As Integer, ByRef pResult As String) As Boolean
        Dim pLocalResult As String = ""
        Try
            Dim xserv As New OnePlanServices_SupervisionsDetail.WMS_SupervisionsDetailSoapClient("WMS_SupervisionsDetailSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_SupervisionsDetail.asmx")

            If xserv.DeleteSupervisionsDetails(pSuperId, Codigo, pLocalResult, PublicLoginInfo.Environment) Then
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
