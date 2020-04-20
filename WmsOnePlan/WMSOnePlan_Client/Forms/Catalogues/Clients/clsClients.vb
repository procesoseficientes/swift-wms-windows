Imports System.ComponentModel
#Region "Enums"
Public Class ClientClassEnum
    Inherits StringConverter
    Public Sub New()
        MyBase.New()
    End Sub
    Public Function GetCustomClasses()
        Dim XStr(0) As String
        Dim I As Integer = 0
        Dim xserv As New OnePlanServices_Settings.WMS_SettingsSoapClient("WMS_SettingsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_settings.asmx")
        Dim xds As New DataSet
        Dim xdr As DataRow
        Dim pResult As String = ""
        Try
            xds = xserv.GetParam_ByParamKey("CLIENTES", "CLASES", "", pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then
                For Each xdr In xds.Tables(0).Rows
                    XStr(I) = xdr("PARAM_NAME").ToString
                    I = I + 1
                    ReDim Preserve XStr(I)

                Next
            End If
        Catch ex As Exception
            XStr(0) = ex.Message
        End Try
        Return XStr
    End Function

    Public Overloads Overrides Function GetStandardValuesSupported(ByVal context As ITypeDescriptorContext) As Boolean
        'True = Se despliega la lista
        'False = No se despliega la lista y el ususario debe escribir un valor
        Return True
    End Function
    Public Overloads Overrides Function GetStandardValues(ByVal context As ITypeDescriptorContext) As StandardValuesCollection
        Return New StandardValuesCollection(GetCustomClasses())
    End Function
    Public Overloads Overrides Function GetStandardValuesExclusive(ByVal context As ITypeDescriptorContext) As Boolean
        'True = el combo no admite más items que los de la lista
        'False = el combo admite un item que no esté en la lista
        Return False
    End Function

End Class

Public Class ClientsERPEnum
    Inherits StringConverter
    Public Sub New()
        MyBase.New()
    End Sub
    Public Function GetERPCustomers()
        Dim XStr(0) As String
        Dim I As Integer = 0
        Dim xserv As New OnePlanServices_Clients.WMS_ClientsSoapClient("WMS_ClientsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_clients.asmx")
        Dim xds As New DataSet
        Dim xdr As DataRow
        Dim pResult As String = ""
        Try
            xds = xserv.GetERPClients(pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then
                For Each xdr In xds.Tables(0).Rows
                    XStr(I) = xdr("CLIENT_NAME").ToString + "/" + xdr("CLIENT_CODE").ToString
                    I = I + 1
                    ReDim Preserve XStr(I)
                Next
            End If
        Catch ex As Exception
            XStr(0) = ex.Message
        End Try
        Return XStr
    End Function

    Public Overloads Overrides Function GetStandardValuesSupported(ByVal context As ITypeDescriptorContext) As Boolean
        'True = Se despliega la lista
        'False = No se despliega la lista y el ususario debe escribir un valor
        Return True
    End Function
    Public Overloads Overrides Function GetStandardValues(ByVal context As ITypeDescriptorContext) As StandardValuesCollection
        Return New StandardValuesCollection(GetERPCustomers())
    End Function
    Public Overloads Overrides Function GetStandardValuesExclusive(ByVal context As ITypeDescriptorContext) As Boolean
        'True = el combo no admite más items que los de la lista
        'False = el combo admite un item que no esté en la lista
        Return False
    End Function

End Class


Public Class ClientRoutesEnum
    Inherits StringConverter
    Public Sub New()
        MyBase.New()
    End Sub
    Public Function GetCustomRoutes()
        Dim XStr(0) As String
        Dim I As Integer = 0
        Dim xserv As New OnePlanServices_Settings.WMS_SettingsSoapClient("WMS_SettingsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_settings.asmx")
        Dim xds As New DataSet
        Dim xdr As DataRow
        Dim pResult As String = ""
        Try
            xds = xserv.GetParam_ByParamKey("CLIENTES", "RUTAS", "", pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then
                For Each xdr In xds.Tables(0).Rows
                    XStr(I) = xdr("PARAM_NAME").ToString
                    I = I + 1
                    ReDim Preserve XStr(I)

                Next
            End If
        Catch ex As Exception
            XStr(0) = ex.Message
        End Try
        Return XStr
    End Function
    Public Overloads Overrides Function GetStandardValuesSupported(ByVal context As ITypeDescriptorContext) As Boolean
        'True = Se despliega la lista
        'False = No se despliega la lista y el ususario debe escribir un valor
        Return True
    End Function
    Public Overloads Overrides Function GetStandardValues(ByVal context As ITypeDescriptorContext) As StandardValuesCollection
        Return New StandardValuesCollection(GetCustomRoutes())
    End Function
    Public Overloads Overrides Function GetStandardValuesExclusive(ByVal context As ITypeDescriptorContext) As Boolean
        'True = el combo no admite más items que los de la lista
        'False = el combo admite un item que no esté en la lista
        Return False
    End Function

End Class

Public Class ClientCAEnum
    Inherits StringConverter
    Public Sub New()
        MyBase.New()
    End Sub
    Public Function GetCA()
        Dim XStr(0) As String
        Dim I As Integer = 0
        Dim xserv As New OnePlanServices_Settings.WMS_SettingsSoapClient("WMS_SettingsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_settings.asmx")
        Dim xds As New DataSet
        Dim xdr As DataRow
        Dim pResult As String = ""
        Try
            xds = xserv.GetParam_ByParamKey("CLIENTES", "ACUERDO COMERCIAL", "", pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then
                For Each xdr In xds.Tables(0).Rows
                    XStr(I) = xdr("PARAM_NAME").ToString
                    I = I + 1
                    ReDim Preserve XStr(I)

                Next
            End If
        Catch ex As Exception
            XStr(0) = ex.Message
        End Try
        Return XStr
    End Function
    Public Overloads Overrides Function GetStandardValuesSupported(ByVal context As ITypeDescriptorContext) As Boolean
        'True = Se despliega la lista
        'False = No se despliega la lista y el ususario debe escribir un valor
        Return True
    End Function
    Public Overloads Overrides Function GetStandardValues(ByVal context As ITypeDescriptorContext) As StandardValuesCollection
        Return New StandardValuesCollection(GetCA())
    End Function
    Public Overloads Overrides Function GetStandardValuesExclusive(ByVal context As ITypeDescriptorContext) As Boolean
        'True = el combo no admite más items que los de la lista
        'False = el combo admite un item que no esté en la lista
        Return True
    End Function

End Class
#End Region
Public Class ActivoInactivo
    Inherits StringConverter
    Public Sub New()
        MyBase.New()
    End Sub
    Private SioNo() As String = {"ACTIVO", "INACTIVO"}
    Public Overloads Overrides Function GetStandardValuesSupported(ByVal context As ITypeDescriptorContext) As Boolean
        'True = Se despliega la lista
        'False = No se despliega la lista y el ususario debe escribir un valor
        Return True
    End Function
    Public Overloads Overrides Function GetStandardValues(ByVal context As ITypeDescriptorContext) As StandardValuesCollection
        Return New StandardValuesCollection(SioNo)
    End Function
    Public Overloads Overrides Function GetStandardValuesExclusive(ByVal context As ITypeDescriptorContext) As Boolean
        'True = el combo no admite más items que los de la lista
        'False = el combo admite un item que no esté en la lista
        Return False
    End Function
End Class
Public Class clsClients
    Public _CLIENT_CODE As String
    Public _CLIENT_NAME As String
    Public _CLIENT_ROUTE As String
    Public _CLIENT_CLASS As String
    Public _CLIENT_STATUS As String
    Public _CLIENT_CA As String
    Public _CLIENT_ERP_CODE As String
    <Category("Interfase"), TypeConverter(GetType(ClientsERPEnum)), Description("Codigo del cliente en ERP")> _
    Public Property CodigoERP() As String
        Get
            Return _CLIENT_ERP_CODE
        End Get
        Set(ByVal Value As String)
            _CLIENT_ERP_CODE = Value
        End Set
    End Property

    <Category("Datos Generales"), Description("Codigo Unico Cliente (Max.25 caracteres)")> _
    Public Property Codigo() As String
        Get
            Return _CLIENT_CODE
        End Get
        Set(ByVal Value As String)
            _CLIENT_CODE = Value
        End Set
    End Property
    <Category("Datos Generales"), Description("Nombre del Cliente (Max.200 caracteres)")> _
    Public Property Nombre() As String
        Get
            Return _CLIENT_NAME
        End Get
        Set(ByVal Value As String)
            _CLIENT_NAME = Value
        End Set
    End Property
    <Category("Datos Generales"), TypeConverter(GetType(ClientRoutesEnum)), Description("Ruta default del Cliente")> _
    Public Property Ruta() As String
        Get
            Return _CLIENT_ROUTE
        End Get
        Set(ByVal Value As String)
            _CLIENT_ROUTE = Value
        End Set
    End Property
    <Category("Datos Generales"), TypeConverter(GetType(ClientClassEnum)), Description("Clasificacion del Cliente")> _
    Public Property Clasificacion() As String
        Get
            Return _CLIENT_CLASS
        End Get
        Set(ByVal Value As String)
            _CLIENT_CLASS = Value
        End Set
    End Property
    <Category("Datos Generales"), TypeConverter(GetType(ClientCAEnum)), Description("Acuerdo Comercial del Cliente")> _
    Public Property Acuerdo() As String
        Get
            Return _CLIENT_CA
        End Get
        Set(ByVal Value As String)
            _CLIENT_CA = Value
        End Set
    End Property
    <Category("Datos Generales"), TypeConverter(GetType(ActivoInactivo)), Description("Estatus del Cliente")> _
    Public Property Estatus() As String
        Get
            Select Case _CLIENT_STATUS
                Case "0"
                    Return "INACTIVO"
                Case "1"
                    Return "ACTIVO"
                Case "INACTIVO"
                    Return "INACTIVO"
                Case Else
                    Return "ACTIVO"
            End Select
        End Get
        Set(ByVal Value As String)
            Select Case Value
                Case "ACTIVO"
                    _CLIENT_STATUS = "1"
                Case "INACTIVO"
                    _CLIENT_STATUS = "0"
                Case "0"
                    _CLIENT_STATUS = "INACTIVO"
                Case Else
                    _CLIENT_STATUS = "ACTIVO"
            End Select
        End Set
    End Property
    Public Function Grabar(ByRef pResult As String) As Boolean
        Dim pLocalResult As String = ""
        Dim pEstatus = "1"
        Try
            Dim xserv As New OnePlanServices_Clients.WMS_ClientsSoapClient("WMS_ClientsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_clients.asmx")

            xserv.SearchByKeyClients(Codigo, pLocalResult, PublicLoginInfo.Environment)
            If pLocalResult = "OK" Then 'Update the record
                If Estatus = "ACTIVO" Then
                    pEstatus = "1"
                Else
                    pEstatus = "0"
                End If
                If xserv.UpdateClients(Codigo, Nombre, Ruta, Clasificacion, pEstatus, CodigoERP, pLocalResult, PublicLoginInfo.Environment) Then
                    Return True
                Else
                    pResult = pLocalResult
                    Return False
                End If
            Else 'Add new record
                If Estatus = "ACTIVO" Then
                    pEstatus = "1"
                Else
                    pEstatus = "0"
                End If

                If xserv.CreateClients(Codigo, Nombre, Ruta, Clasificacion, pEstatus, CodigoERP, pLocalResult, PublicLoginInfo.Environment) Then
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
            Dim xserv As New OnePlanServices_Clients.WMS_ClientsSoapClient("WMS_ClientsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_clients.asmx")

            If xserv.DeleteClients(Codigo, pLocalResult, PublicLoginInfo.Environment) Then
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
