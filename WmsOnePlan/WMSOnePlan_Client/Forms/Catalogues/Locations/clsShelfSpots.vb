Imports System.ComponentModel
Public Class LocationTypeEnum
    Inherits StringConverter
    Public Sub New()
        MyBase.New()
    End Sub
    Private LocationTypeEnum() As String = GetLocationTypes()

    Public Function GetLocationTypes()
        Dim XStr(0) As String
        Dim I As Integer = 0
        Dim xserv As New OnePlanServices_Settings.WMS_SettingsSoapClient("WMS_SettingsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_settings.asmx")
        Dim xds As New DataSet
        Dim xdr As DataRow
        Dim pResult As String = ""
        Try
            xds = xserv.GetParam_ByParamKey("SISTEMA", "TIPO_UBICACIONES", "", pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then
                For Each xdr In xds.Tables(0).Rows
                    XStr(I) = xdr("PARAM_NAME").ToString
                    ReDim Preserve XStr(I + 1)
                    I = I + 1
                Next
            End If
        Catch ex As Exception
            XStr(0) = "NONE"
        End Try
        Return XStr

    End Function
    Public Overloads Overrides Function GetStandardValuesSupported(ByVal context As ITypeDescriptorContext) As Boolean
        'True = Se despliega la lista
        'False = No se despliega la lista y el ususario debe escribir un valor
        Return True
    End Function
    Public Overloads Overrides Function GetStandardValues(ByVal context As ITypeDescriptorContext) As StandardValuesCollection
        Return New StandardValuesCollection(LocationTypeEnum)
    End Function
    Public Overloads Overrides Function GetStandardValuesExclusive(ByVal context As ITypeDescriptorContext) As Boolean
        'True = el combo no admite más items que los de la lista
        'False = el combo admite un item que no esté en la lista
        Return False
    End Function
End Class


Public Class LinesEnumClass
    Inherits StringConverter

    Public Sub New()
        MyBase.New()
    End Sub
    Private LinesEnum() As String = GetLines()

    Public Function GetLines()
        Dim XStr(0) As String
        Dim I As Integer = 0
        Dim xserv As New OnePlanServices_Settings.WMS_SettingsSoapClient("WMS_SettingsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_settings.asmx")
        Dim xds As New DataSet
        Dim xdr As DataRow
        Dim pResult As String = ""
        Try
            xds = xserv.GetParam_ByParamKey("SISTEMA", "LINEAS_PICKING", "", pResult, PublicLoginInfo.Environment)
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
        Return New StandardValuesCollection(GetLines())
    End Function
    Public Overloads Overrides Function GetStandardValuesExclusive(ByVal context As ITypeDescriptorContext) As Boolean
        'True = el combo no admite más items que los de la lista
        'False = el combo admite un item que no esté en la lista
        Return True
    End Function

End Class

Public Class ZonesEnumClass
    Inherits StringConverter

    Public Sub New()
        MyBase.New()
    End Sub
    Private ZonesEnum() As String = GetZones()

    Public Function GetZones(Optional warehouse As String = "")
        Dim XStr(0) As String
        Dim I As Integer = 0
        Dim xserv As New OnePlanServices_Locations.WMS_LocationsSoapClient("WMS_LocationsSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Locations.asmx")
        Dim xds As New DataSet
        Dim xdr As DataRow
        Dim pResult As String = ""
        Try
            xds = xserv.GetWmsZones(pResult, PublicLoginInfo.Environment,warehouse)
            If pResult = "OK" Then
                For Each xdr In xds.Tables(0).Rows
                    XStr(I) = xdr("ZONE").ToString
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
        Dim bodega As clsShelfSpots = context.Instance
        Return New StandardValuesCollection(GetZones(bodega.Bodega))
    End Function
    Public Overloads Overrides Function GetStandardValuesExclusive(ByVal context As ITypeDescriptorContext) As Boolean
        'True = el combo no admite más items que los de la lista
        'False = el combo admite un item que no esté en la lista
        Return True
    End Function

End Class

Public Class SectionEnumClass
    Inherits StringConverter

    Public Sub New()
        MyBase.New()
    End Sub
    Private SectionEnum() As String = GetSections()

    Public Function GetSections()
        Dim xStr(0) As String
        Dim I As Integer = 0
        Dim xserv As New OnePlanServices_Settings.WMS_SettingsSoapClient("WMS_SettingsSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Settings.asmx")
        Dim xds As New DataSet
        Dim xdr As DataRow
        Dim pResult As String = ""
        Try
            xds = xserv.GetParam_ByParamKey("SISTEMA","TRAMOS_LINEA",Nothing,pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then
                For Each xdr In xds.Tables(0).Rows
                    xStr(I) = xdr("PARAM_CAPTION").ToString
                    I = I + 1
                    ReDim Preserve xStr(I)

                Next
            End If
        Catch ex As Exception
            xStr(0) = ex.Message
        End Try
        Return xStr
    End Function

    Public Overloads Overrides Function GetStandardValuesSupported(ByVal context As ITypeDescriptorContext) As Boolean
        'True = Se despliega la lista
        'False = No se despliega la lista y el ususario debe escribir un valor
        Return True
    End Function
    Public Overloads Overrides Function GetStandardValues(ByVal context As ITypeDescriptorContext) As StandardValuesCollection
        Return New StandardValuesCollection(GetSections())
    End Function
    Public Overloads Overrides Function GetStandardValuesExclusive(ByVal context As ITypeDescriptorContext) As Boolean
        'True = el combo no admite más items que los de la lista
        'False = el combo admite un item que no esté en la lista
        Return True
    End Function

End Class


Public Class WarehousesEnumClass
    Inherits StringConverter

    Public Sub New()
        MyBase.New()
    End Sub
    Public WarehousesEnumClass() As String = GetWarehouses()

    Public Function GetWarehouses()
        Dim XStr(0) As String
        Dim I As Integer = 0
        Dim xserv As New OnePlanServices_Locations.WMS_LocationsSoapClient("WMS_LocationsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_locations.asmx")
        Dim xds As New DataSet
        Dim xdr As DataRow
        Dim pResult As String = ""
        Try
            'xds = xserv.SelectWarehousesGroup(pResult, PublicLoginInfo.Environment)
            xds = xserv.GetAssociatedWarehouseWithUser(PublicLoginInfo.LoginID, PublicLoginInfo.Environment, pResult)
            If pResult = "OK" Then
                For Each xdr In xds.Tables(0).Rows
                    XStr(I) = xdr("WAREHOUSE_ID").ToString
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
        WarehousesEnumClass = GetWarehouses()
        Return New StandardValuesCollection(WarehousesEnumClass)
    End Function
    Public Overloads Overrides Function GetStandardValuesExclusive(ByVal context As ITypeDescriptorContext) As Boolean
        'True = el combo no admite más items que los de la lista
        'False = el combo admite un item que no esté en la lista
        Return True
    End Function

End Class

Public Class SioNo
    Inherits StringConverter
    Public Sub New()
        MyBase.New()
    End Sub
    Private SioNo() As String = {"SI", "NO"}
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
        Return True
    End Function
End Class

Public Class clsShelfSpots
    Public _WAREHOUSE_PARENT As String
    Public _ZONE As String
    Public _LOCATION_SPOT As String
    Public _SPOT_TYPE As String
    Public _SPOT_ORDERBY As Integer
    Public _SPOT_AISLE As String
    Public _SPOT_COLUMN As String
    Public _SPOT_LEVEL As String
    Public _SPOT_PARTITION As String
    Public _SPOT_LABEL As String
    Public _ALLOW_PICKING As String
    Public _ALLOW_STORAGE As String
    Public _ALLOW_REALLOC As String
    Public _ALLOW_FAST_PICKING As String
    Public _IS_WASTE As String
    Public _AVAILABLE As String
    Public _LINE_ID As String
    Public _MAX_MT2 As Double
    Public _MAX_WEIGHT As Double
    Public _VOLUME As Double
    Public _SECTION As String



    <Category("Datos Generales"), TypeConverter(GetType(WarehousesEnumClass)), Description("Bodega Padre de la ubicacion")>
    Public Property Bodega() As String
        Get
            Return _WAREHOUSE_PARENT
        End Get
        Set(ByVal Value As String)
            _WAREHOUSE_PARENT = Value
        End Set
    End Property
    <Category("Datos Generales"), TypeConverter(GetType(LinesEnumClass)), Description("Linea asociada a la ubicacion (aplica para picking, usar default para ubicaciones fuera de la bodega de picking)")>
    Public Property Linea() As String
        Get
            Return _LINE_ID
        End Get
        Set(ByVal Value As String)
            _LINE_ID = Value
        End Set
    End Property

    <Category("Datos Generales"), Description("Codigo identificador de la ubicacion -maximo 25 caracteres-")>
    Public Property Codigo() As String
        Get
            Return _LOCATION_SPOT
        End Get
        Set(ByVal Value As String)
            _LOCATION_SPOT = Value
        End Set
    End Property
    <Category("Datos Generales"), TypeConverter(GetType(LocationTypeEnum)), Description("Tipo de Ubicacion (Rack/Piso/Movil...etc)")>
    Public Property Tipo() As String
        Get
            Return _SPOT_TYPE
        End Get
        Set(ByVal Value As String)
            _SPOT_TYPE = Value
        End Set
    End Property
    <Category("Datos Generales"), TypeConverter(GetType(SectionEnumClass)),Description("Sección de la Ubicacion")>
    Public Property Seccion() As String
        Get
            Return _SECTION
        End Get
        Set(ByVal Value As String)
            _SECTION = Value
        End Set
    End Property
    <Category("Datos Generales"), TypeConverter(GetType(ZonesEnumClass)), Description("Zona de la Ubicacion")>
    Public Property Zona() As String
        Get
            Return _ZONE
        End Get
        Set(ByVal Value As String)
            _ZONE = Value
        End Set
    End Property
    <Category("Direccion y Orden"), Description("Secuencia de ordenamiento para picking de la ubicacion")>
    Public Property SecuenciaDeOrden() As String
        Get
            Return _SPOT_ORDERBY
        End Get
        Set(ByVal Value As String)
            _SPOT_ORDERBY = Value
        End Set
    End Property
    <Category("Direccion y Orden"), Description("Numero o Literal que corresponde al Rack ")>
    Public Property Rack() As String
        Get
            Return _SPOT_AISLE
        End Get
        Set(ByVal Value As String)
            _SPOT_AISLE = Value
        End Set
    End Property
    <Category("Direccion y Orden"), Description("Columna dentro del Rack de la ubicacion")>
    Public Property Columna() As String
        Get
            Return _SPOT_COLUMN
        End Get
        Set(ByVal Value As String)
            _SPOT_COLUMN = Value
        End Set
    End Property
    <Category("Direccion y Orden"), Description("Nivel de la ubicacion dentro de la ubicacion")>
    Public Property Nivel() As String
        Get
            Return _SPOT_LEVEL
        End Get
        Set(ByVal Value As String)
            _SPOT_LEVEL = Value
        End Set
    End Property
    <Category("Direccion y Orden"), Description("Numero de particion de la ubicacion. (ejemplo: bin plastico dentro de la ubicacion)")>
    Public Property Particion() As String
        Get
            Return _SPOT_PARTITION
        End Get
        Set(ByVal Value As String)
            _SPOT_PARTITION = Value
        End Set
    End Property

    <Category("Datos Generales"), Description("Titulo de la ubicacion (etiqueta impresa)")>
    Public Property Etiqueta() As String
        Get
            Return _SPOT_LABEL
        End Get
        Set(ByVal Value As String)
            _SPOT_LABEL = Value
        End Set
    End Property

    <Category("Caracteristicas"), TypeConverter(GetType(SioNo)), Description("Permite la ubicacion realizar picking? (1=SI / 0=NO)")>
    Public Property PermitePicking() As String
        Get
            Select Case _ALLOW_PICKING
                Case "0"
                    Return "NO"
                Case "1"
                    Return "SI"
                Case "NO"
                    Return "NO"
                Case Else
                    Return "SI"
            End Select
        End Get
        Set(ByVal Value As String)
            Select Case Value
                Case "0"
                    _ALLOW_PICKING = "NO"
                Case "1"
                    _ALLOW_PICKING = "SI"
                Case "NO"
                    _ALLOW_PICKING = "NO"
                Case Else
                    _ALLOW_PICKING = "SI"
            End Select
        End Set
    End Property

    <Category("Caracteristicas"), TypeConverter(GetType(SioNo)), Description("Permite la ubicación realizar picking rápido? (1=SI / 0=NO)")>
    Public Property PermitePickingRapido() As String
        Get
            Select Case _ALLOW_FAST_PICKING
                Case "0"
                    Return "NO"
                Case "1"
                    Return "SI"
                Case "NO"
                    Return "NO"
                Case "SI"
                    Return "SI"
                Case Else
                    Return "NO"
            End Select
        End Get
        Set(ByVal Value As String)
            Select Case Value
                Case "0"
                    _ALLOW_FAST_PICKING = "NO"
                Case "1"
                    _ALLOW_FAST_PICKING = "SI"
                Case "NO"
                    _ALLOW_FAST_PICKING = "NO"
                Case "SI"
                    _ALLOW_FAST_PICKING = "SI"
                Case Else
                    _ALLOW_FAST_PICKING = "NO"
            End Select
        End Set
    End Property

    <Category("Caracteristicas"), TypeConverter(GetType(SioNo)), Description("La ubicación es de Desperdicio? (1=SI / 0=NO)")>
    Public Property EsDesperdicio() As String
        Get
            Select Case _IS_WASTE
                Case "0"
                    Return "NO"
                Case "1"
                    Return "SI"
                Case "NO"
                    Return "NO"
                Case "SI"
                    Return "SI"
                Case Else
                    Return "NO"
            End Select
        End Get
        Set(ByVal Value As String)
            Select Case Value
                Case "0"
                    _IS_WASTE = "NO"
                Case "1"
                    _IS_WASTE = "SI"
                Case "NO"
                    _IS_WASTE = "NO"
                Case "SI"
                    _IS_WASTE = "SI"
                Case Else
                    _IS_WASTE = "NO"
            End Select
        End Set
    End Property

    <Category("Caracteristicas"), TypeConverter(GetType(SioNo)), Description("Permite la ubicacion recibir directo desde recepción? (1=SI / 0=NO)")>
    Public Property PermiteAlmacenaje() As String
        Get
            Select Case _ALLOW_STORAGE
                Case "0"
                    Return "NO"
                Case "1"
                    Return "SI"
                Case "NO"
                    Return "NO"
                Case Else
                    Return "SI"
            End Select
        End Get
        Set(ByVal Value As String)
            Select Case Value
                Case "0"
                    _ALLOW_STORAGE = "NO"
                Case "1"
                    _ALLOW_STORAGE = "SI"
                Case "NO"
                    _ALLOW_STORAGE = "NO"
                Case Else
                    _ALLOW_STORAGE = "SI"
            End Select
        End Set
    End Property
    <Category("Caracteristicas"), TypeConverter(GetType(SioNo)), Description("Permite la ubicacion realizar reubicacion hacia dentro o hacia fuera? (0=SI / 1=NO)")>
    Public Property PermiteReubicar() As String
        Get
            Select Case _ALLOW_REALLOC
                Case "0"
                    Return "NO"
                Case "1"
                    Return "SI"
                Case "NO"
                    Return "NO"
                Case Else
                    Return "SI"
            End Select
        End Get
        Set(ByVal Value As String)
            Select Case Value
                Case "0"
                    _ALLOW_REALLOC = "NO"
                Case "1"
                    _ALLOW_REALLOC = "SI"
                Case "NO"
                    _ALLOW_REALLOC = "NO"
                Case Else
                    _ALLOW_REALLOC = "SI"
            End Select
        End Set
    End Property
    <Category("Caracteristicas"), TypeConverter(GetType(SioNo)), Description("Ubicacion habilitada(0=SI / 1=NO)")>
    Public Property Disponible() As String
        Get
            Select Case _AVAILABLE
                Case "0"
                    Return "NO"
                Case "1"
                    Return "SI"
                Case "NO"
                    Return "NO"
                Case Else
                    Return "SI"
            End Select
        End Get
        Set(ByVal Value As String)
            Select Case Value
                Case "0"
                    _AVAILABLE = "NO"
                Case "1"
                    _AVAILABLE = "SI"
                Case "NO"
                    _AVAILABLE = "NO"
                Case Else
                    _AVAILABLE = "SI"
            End Select
        End Set
    End Property
    <Category("Caracteristicas"), Description("Máximo almacenaje de ubicacion en MT2")>
    Public Property Metros2() As Double
        Get
            Return _MAX_MT2
        End Get
        Set(ByVal Value As Double)
            _MAX_MT2 = Value
        End Set
    End Property

    <Category("Caracteristicas"), Description("Peso máximo de ubicacion en Toneladas"), [Browsable](False)>
    Public Property PesoMaximo() As Double
        Get
            Return _MAX_WEIGHT
        End Get
        Set(ByVal Value As Double)
            _MAX_WEIGHT = Value
        End Set
    End Property


    <Category("Caracteristicas"), Description("Volumen de la ubicación"), [Browsable](False)>
    Public Property Volumen() As Double
        Get
            Return _VOLUME
        End Get
        Set(ByVal Value As Double)
            _VOLUME = Value
        End Set
    End Property

    Public Sub SetReadOnlyProperty(ByVal propertyName As String, ByVal [readOnly] As Boolean)
        Dim descriptor As PropertyDescriptor = TypeDescriptor.GetProperties([GetType]())(propertyName)
        Dim attribute As ReadOnlyAttribute = DirectCast(descriptor.Attributes(GetType(ReadOnlyAttribute)), ReadOnlyAttribute)
        Dim fieldToChange As Reflection.FieldInfo = attribute.[GetType]().GetField("isReadOnly", System.Reflection.BindingFlags.NonPublic Or System.Reflection.BindingFlags.Instance)
        fieldToChange.SetValue(attribute, [readOnly])
    End Sub

    Public Sub SetBrowsableProperty(ByVal propertyName As String, ByVal [browsable] As Boolean)
        Dim descriptor As PropertyDescriptor = TypeDescriptor.GetProperties([GetType]())(propertyName)
        Dim attribute As BrowsableAttribute = DirectCast(descriptor.Attributes(GetType(BrowsableAttribute)), BrowsableAttribute)
        Dim fieldToChange As Reflection.FieldInfo = attribute.[GetType]().GetField("browsable", System.Reflection.BindingFlags.NonPublic Or System.Reflection.BindingFlags.Instance)
        fieldToChange.SetValue(attribute, [browsable])
    End Sub

    Public Function Grabar(ByRef pResult As String) As Boolean
        Dim pLocalResult As String = ""
        Try
            If PesoMaximo = 0 AndAlso Tipo = "RACK" Then
                Throw New Exception("El peso maximo es obligatorio")
            End If
            Dim xserv As New OnePlanServices_Locations.WMS_LocationsSoapClient("WMS_LocationsSoap", PublicLoginInfo.WSHost & "/Catalogues/wms_locations.asmx")
            xserv.SearchByKeyShelfSpots(Bodega, Codigo, pLocalResult, PublicLoginInfo.Environment)
            If pLocalResult = "OK" Then 'Update the record
                If xserv.UpdateShelfSpots(Bodega, Codigo, Tipo, SecuenciaDeOrden, Rack, Columna, Nivel, IIf(PermitePicking = "NO", 0, 1), IIf(PermiteAlmacenaje = "NO", 0, 1), IIf(PermiteReubicar = "NO", 0, 1), IIf(Disponible = "NO", 0, 1), Zona, Particion, Etiqueta, Linea, Metros2, PesoMaximo, pLocalResult, PublicLoginInfo.Environment, Seccion, Volumen, IIf(PermitePickingRapido = "NO", 0, 1), IIf(EsDesperdicio = "NO", 0, 1)) Then
                    Return True
                Else
                    pResult = pLocalResult
                    Return False
                End If
            Else 'Add new record
                If xserv.CreateShelfSpots(Bodega, Codigo, Tipo, SecuenciaDeOrden, Rack, Columna, Nivel, IIf(PermitePicking = "NO", 0, 1), IIf(PermiteAlmacenaje = "NO", 0, 1), IIf(PermiteReubicar = "NO", 0, 1), IIf(Disponible = "NO", 0, 1), Zona, Particion, Etiqueta, Linea, Metros2, PesoMaximo, pLocalResult, PublicLoginInfo.Environment, Seccion, Volumen, IIf(PermitePickingRapido = "NO", 0, 1), IIf(EsDesperdicio = "NO", 0, 1)) Then
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
            Dim xserv As New OnePlanServices_Locations.WMS_LocationsSoapClient("WMS_LocationsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_locations.asmx")
            If xserv.DeleteShelfSpots(Bodega, Codigo, Linea, pLocalResult, PublicLoginInfo.Environment) Then
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
