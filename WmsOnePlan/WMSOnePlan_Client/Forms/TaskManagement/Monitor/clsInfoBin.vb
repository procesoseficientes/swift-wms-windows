Imports System.ComponentModel
Public Class InfoBinClassEnum
    Inherits StringConverter

    Public Sub New()
        MyBase.New()
    End Sub
    
    Public Function GetMaterialClassEnum()
        Dim XStr(0) As String
        Dim I As Integer = 0
        Dim xserv As New OnePlanServices_Settings.WMS_SettingsSoapClient("WMS_SettingsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_settings.asmx")
        Dim xdataset As New DataSet
        Dim pResult As String = ""
        Dim xdr As DataRow
        Try
            xdataset = xserv.GetParam_ByParamKey("PRODUCTOS", "CLASES", "", pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then
                For Each xdr In xdataset.Tables(0).Rows
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
        Return New StandardValuesCollection(GetMaterialClassEnum())
    End Function
    Public Overloads Overrides Function GetStandardValuesExclusive(ByVal context As ITypeDescriptorContext) As Boolean
        'True = el combo no admite más items que los de la lista
        'False = el combo admite un item que no esté en la lista
        Return True
    End Function

End Class

Public Class clsInfoBin
    Public _CURRENT_DOC As String
    Public _STATUS As String
    Public _LAST_ASSIGNED_DOC As String
    Public _LAST_PICKING_USER As String
    Public _LAST_PICKING_DATE As Date
    Public _LAST_PICKING_LOCATION As String
    Public _LAST_PICKING_DOC As String
    Public _LAST_PICKING_MATERIAL As String
    Public _LAST_CLOSING_USER As String
    Public _LAST_CLOSING_DATE As Date
    Public _LAST_RELEASING_USER As String
    Public _LAST_RELEASING_DATE As Date

    <Category("1 Datos Generales"), [ReadOnly](True), Description("Pedido Asignado Actualmente al BIN")> _
       Public Property PedidoActual() As String
        Get
            Return _CURRENT_DOC
        End Get
        Set(ByVal Value As String)
            _CURRENT_DOC = Value
        End Set
    End Property
    <Category("1 Datos Generales"), [ReadOnly](True), Description("Estado Actual")> _
       Public Property EstadoActual() As String
        Get
            Return _STATUS
        End Get
        Set(ByVal Value As String)
            _STATUS = Value
        End Set
    End Property
    <Category("1 Datos Generales"), [ReadOnly](True), Description("Ultimo Pedido Asignado al BIN")> _
       Public Property UltimoPedidoAsignado() As String
        Get
            Return _LAST_ASSIGNED_DOC
        End Get
        Set(ByVal Value As String)
            _LAST_ASSIGNED_DOC = Value
        End Set
    End Property

    <Category("2 Información de Picking"), [ReadOnly](True), Description("Ultimo usuario que hizo Picking")> _
       Public Property UsuarioUltimoPicking() As String
        Get
            Return _LAST_PICKING_USER
        End Get
        Set(ByVal Value As String)
            _LAST_PICKING_USER = Value
        End Set
    End Property
    <Category("2 Información de Picking"), [ReadOnly](True), Description("Hora y Fecha de último Picking")> _
       Public Property FechaUltimoPicking() As Date
        Get
            Return _LAST_PICKING_DATE
        End Get
        Set(ByVal Value As Date)
            _LAST_PICKING_DATE = Value
        End Set
    End Property

    <Category("2 Información de Picking"), [ReadOnly](True), Description("Ultima Ubicacion que fue Pickeado")> _
       Public Property UltimaUbicacionPicking() As String
        Get
            Return _LAST_PICKING_LOCATION
        End Get
        Set(ByVal Value As String)
            _LAST_PICKING_LOCATION = Value
        End Set
    End Property
    <Category("2 Información de Picking"), [ReadOnly](True), Description("Ultimo documento que fue Pickeado")> _
       Public Property UltimoDocumentoPicking() As String
        Get
            Return _LAST_PICKING_DOC
        End Get
        Set(ByVal Value As String)
            _LAST_PICKING_DOC = Value
        End Set
    End Property
    <Category("2 Información de Picking"), [ReadOnly](True), Description("Ultimo producto que fue Pickeado")> _
       Public Property UltimoProductoPicking() As String
        Get
            Return _LAST_PICKING_MATERIAL
        End Get
        Set(ByVal Value As String)
            _LAST_PICKING_MATERIAL = Value
        End Set
    End Property

    <Category("3 Información Adicional"), [ReadOnly](True), Description("Ultimo usuario que cerró el BIN")> _
       Public Property UsuarioUltimoCierre() As String
        Get
            Return _LAST_CLOSING_USER
        End Get
        Set(ByVal Value As String)
            _LAST_CLOSING_USER = Value
        End Set
    End Property
    <Category("3 Información Adicional"), [ReadOnly](True), Description("Hora y Fecha de último cierre del BIN")> _
       Public Property FechaUltimoCierre() As Date
        Get
            Return _LAST_CLOSING_DATE
        End Get
        Set(ByVal Value As Date)
            _LAST_CLOSING_DATE = Value
        End Set
    End Property
    <Category("3 Información Adicional"), [ReadOnly](True), Description("Ultimo usuario que liberó manualmente el BIN")> _
       Public Property UsuarioUltimaLiberacionManual() As String
        Get
            Return _LAST_RELEASING_USER
        End Get
        Set(ByVal Value As String)
            _LAST_RELEASING_USER = Value
        End Set
    End Property
    <Category("3 Información Adicional"), [ReadOnly](True), Description("Hora y Fecha de última liberación manual del BIN")> _
       Public Property FechaUltimaLiberacionManual() As Date
        Get
            Return _LAST_RELEASING_DATE
        End Get
        Set(ByVal Value As Date)
            _LAST_RELEASING_DATE = Value
        End Set
    End Property


    Public Function Grabar(ByRef pResult As String) As Boolean
        Dim pLocalResult As String = ""
        'Try
        '    Dim xserv As New OnePlanServices_Materials.WMS_MaterialsSoapClient("WMS_MaterialsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_materials.asmx")

        '    xserv.SearchByKeyMaterials(CodigoBarras, pLocalResult, PublicLoginInfo.Environment)
        '    If pLocalResult = "OK" Then 'Update the record
        '        If xserv.UpdateMaterials(CodigoBarras, CodigoBarrasAlterno, Descripcion.Replace("'", "''"), DescripcionCorta.Replace("'", "''"), FactorVolumen, UltimoCosto, Clase, CantidadMaxPorBin, pLocalResult, PublicLoginInfo.Environment) Then
        '            Return True
        '        Else
        '            pResult = pLocalResult
        '            Return False
        '        End If
        '    Else 'Add new record
        '        If xserv.CreateMaterials(CodigoBarras, CodigoBarrasAlterno, Descripcion.Replace("'", "''"), DescripcionCorta.Replace("'", "''"), FactorVolumen, UltimoCosto, Clase, CantidadMaxPorBin, pLocalResult, PublicLoginInfo.Environment) Then
        '            Return True
        '        Else
        '            pResult = pLocalResult
        '            Return False
        '        End If
        '    End If
        'Catch ex As Exception
        '    pResult = ex.Message
        '    Return False
        'End Try
    End Function

    Public Function Delete(ByRef pResult As String) As Boolean
        Dim pLocalResult As String = ""
        'Try
        '    Dim xserv As New OnePlanServices_Materials.WMS_MaterialsSoapClient("WMS_MaterialsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_materials.asmx")

        '    If xserv.DeleteMaterials(CodigoBarras, pLocalResult, PublicLoginInfo.Environment) Then
        '        Return True
        '    Else
        '        pResult = pLocalResult
        '        Return False
        '    End If
        'Catch ex As Exception
        '    pResult = ex.Message
        '    Return False
        'End Try
    End Function

End Class
