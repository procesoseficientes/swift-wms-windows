Imports System.ComponentModel
Imports System.Text.RegularExpressions

Public Class MaterialClassEnum
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
                    ReDim Preserve XStr(I)
                    XStr(I) = xdr("PARAM_NAME").ToString
                    I = I + 1
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

Public Class MaterialSubClassEnum
    Inherits StringConverter

    Public Sub New()
        MyBase.New()
    End Sub

    Public Function GetMaterialSubClassEnum()
        Dim XStr(0) As String
        Dim I As Integer = 0
        Dim xserv As New OnePlanServices_Materials.WMS_MaterialsSoapClient("WMS_MaterialsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_materials.asmx")
        Dim xtable As DataTable
        Dim pResult As String = ""
        Dim xdr As DataRow
        Try
            xtable = xserv.ObtenerSubClasesParaMaterial(pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then
                For Each xdr In xtable.Rows
                    ReDim Preserve XStr(I)
                    XStr(I) = xdr("SUB_CLASS_NAME").ToString
                    I = I + 1
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
        Return New StandardValuesCollection(GetMaterialSubClassEnum())
    End Function
    Public Overloads Overrides Function GetStandardValuesExclusive(ByVal context As ITypeDescriptorContext) As Boolean
        'True = el combo no admite más items que los de la lista
        'False = el combo admite un item que no esté en la lista
        Return True
    End Function
End Class

Public Class MaterialUnitWeightEnum
    Inherits StringConverter

    Public Sub New()
        MyBase.New()
    End Sub

    Public Function GetMaterialUnitWeightEnum()
        Dim XStr(0) As String
        Dim I As Integer = 0
        Dim xserv As New OnePlanServices_Settings.WMS_SettingsSoapClient("WMS_SettingsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_settings.asmx")
        Dim xdataset As New DataSet
        Dim pResult As String = ""
        Dim xdr As DataRow
        Try
            xdataset = xserv.GetParam_ByParamKey("SISTEMA", "UNIDAD_PESO", "", pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then
                For Each xdr In xdataset.Tables(0).Rows
                    ReDim Preserve XStr(I)
                    XStr(I) = xdr("PARAM_NAME").ToString
                    I = I + 1
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
        Return New StandardValuesCollection(GetMaterialUnitWeightEnum())
    End Function
    Public Overloads Overrides Function GetStandardValuesExclusive(ByVal context As ITypeDescriptorContext) As Boolean
        'True = el combo no admite más items que los de la lista
        'False = el combo admite un item que no esté en la lista
        Return True
    End Function

End Class

Public Class clsMaterials
    Public _MATERIAL_ID As String
    Public _ALTERNATE_BARCODE As String
    Public _MATERIAL_NAME As String
    Public _SHORT_NAME As String
    Public _VOLUME_FACTOR As Double
    Public _MATERIAL_CLASS As String
    Public _MATERIAL_SUB_CLASS As String
    Public _MAX_X_BIN As Double

    Public _CLIENT_OWNER As String
    Public _BARCODE_ID As String
    Public _HIGH As Double
    Public _LENGTH As Double
    Public _WIDTH As Double
    Public _SCAN_BY_ONE As Integer
    Public _REQUIRES_LOGISTICS_INFO As Integer
    Public _WEIGTH As Double
    Public _IS_CAR As String
    Public _BATCH_REQUESTED As String
    Public _SERIAL_NUMBER_REQUESTS As String
    Public _HANDLE_MASTER_PACK As String
    Public _EXPLODE_IN_RECEPTION As String
    Public _WEIGHT_MEASUREMENT As String

    'PUBLIC _IMAGE1
    'PUBLIC _IMAGE2
    'PUBLIC _IMAGE3
    Public _LAST_UPDATED As String
    Public _LAST_UPDATED_BY As String
    Public _HANDLE_TONE As String
    Public _HANDLE_CALIBER As String
    Public _USE_PICKING_LINE As String
    Public _QUALITY_CONTROL As String
    Public _HANDLE_CORRELATIVE_SERIALS As String
    Public _PREFIX_CORRELATIVE_SERIALS As String
    Public _LEAD_TIME As Integer
    Public _SUPPLIER As String
    Public _NAME_SUPPLIER As String

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
    <Category("Datos Generales"), TypeConverter(GetType(SioNo)), Description("El producto es carro? (1=SI / 0=NO)")>
    Public Property EsCarro() As String
        Get
            Select Case _IS_CAR
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
                    _IS_CAR = "NO"
                Case "1"
                    _IS_CAR = "SI"
                Case "NO"
                    _IS_CAR = "NO"
                Case Else
                    _IS_CAR = "SI"
            End Select

        End Set
    End Property

    <Category("Datos Generales"), TypeConverter(GetType(SioNo)), Description("El numero de lote es requerido ? (1=SI / 0=NO)")>
    Public Property ManejaLote() As String
        Get
            Select Case _BATCH_REQUESTED
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
                    _BATCH_REQUESTED = "NO"
                Case "1"
                    _BATCH_REQUESTED = "SI"
                Case "NO"
                    _BATCH_REQUESTED = "NO"
                Case Else
                    _BATCH_REQUESTED = "SI"
            End Select
        End Set
    End Property
       <Category("Datos Generales"), TypeConverter(GetType(SioNo)), Description("El producto maneja CALIBRE? (1=SI / 0=NO)")>
    Public Property ManejaCalibre() As String
        Get
            Select Case _HANDLE_CALIBER
               Case "NO"
                    Return "NO"
                Case "SI"
                    Return "SI"
                Case "0"
                    Return "NO"
                Case "1"
                    Return "SI"
                Case Else
                    Return "NO"
            End Select
        End Get
        Set(ByVal Value As String)
            Select Case Value
                Case "0"
                    _HANDLE_CALIBER = "NO"
                Case "1"
                    _HANDLE_CALIBER = "SI"
                Case "NO"
                    _HANDLE_CALIBER = "NO"
                Case "SI"
                    _HANDLE_CALIBER = "SI"
                Case Else
                    _HANDLE_CALIBER = "NO"
            End Select
        End Set
    End Property
    <Category("Datos Generales"), TypeConverter(GetType(SioNo)), Description("El producto maneja TONO? (1=SI / 0=NO)")>
    Public Property ManejaTono() As String
        Get
            Select Case _HANDLE_TONE
                Case "NO"
                    Return "NO"
                Case "SI"
                    Return "SI"
                Case "0"
                    Return "NO"
                Case "1"
                    Return "SI"
                Case Else
                    Return "NO"
            End Select
        End Get
        Set(ByVal Value As String)
            Select Case Value
                Case "0"
                    _HANDLE_TONE = "NO"
                Case "1"
                    _HANDLE_TONE = "SI"
                Case "NO"
                    _HANDLE_TONE = "NO"
                Case "SI"
                    _HANDLE_TONE = "SI"
                Case Else
                    _HANDLE_TONE = "NO"
            End Select
        End Set
    End Property

    <Category("Datos Generales"), TypeConverter(GetType(SioNo)), Description("El numero de Serie es requerido ? (1=SI / 0=NO)")>
    Public Property ManejaSerie() As String
        Get
            Select Case _SERIAL_NUMBER_REQUESTS
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
        Set(value As String)
            Select Case value
                Case "0"
                    _SERIAL_NUMBER_REQUESTS = "NO"
                Case "1"
                    _SERIAL_NUMBER_REQUESTS = "SI"
                Case "NO"
                    _SERIAL_NUMBER_REQUESTS = "NO"
                Case Else
                    _SERIAL_NUMBER_REQUESTS = "SI"
            End Select
        End Set
    End Property


    <Category("Datos Generales"), TypeConverter(GetType(SioNo)), Description("Maneja Master Pack ? (1=SI / 0=NO)"), [Browsable](True)>
    Public Property ManejaMasterPack() As String
        Get
            Select Case _HANDLE_MASTER_PACK
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
        Set(value As String)
            Select Case value
                Case "0"
                    _HANDLE_MASTER_PACK = "NO"
                Case "1"
                    _HANDLE_MASTER_PACK = "SI"
                Case "NO"
                    _HANDLE_MASTER_PACK = "NO"
                Case Else
                    _HANDLE_MASTER_PACK = "SI"
            End Select

        End Set
    End Property


    <Category("Datos Generales"), TypeConverter(GetType(SioNo)), Description("Explota en recepción? (SI / NO)"), [Browsable](True)>
    Public Property ManejaExplosionEnRecepcion() As String
        Get
            Select Case _EXPLODE_IN_RECEPTION
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
        Set(value As String)
            Select Case value
                Case "0"
                    _EXPLODE_IN_RECEPTION = "NO"
                Case "1"
                    _EXPLODE_IN_RECEPTION = "SI"
                Case "NO"
                    _EXPLODE_IN_RECEPTION = "NO"
                Case Else
                    _EXPLODE_IN_RECEPTION = "SI"
            End Select

        End Set
    End Property

    <Category("Datos Generales"), TypeConverter(GetType(SioNo)), Description("Usa linea de picking? (SI / NO)"), [Browsable](True)>
    Public Property UsaLineaDePicking() As String
        Get
            Select Case _USE_PICKING_LINE
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
        Set(value As String)
            Select Case value
                Case "0"
                    _USE_PICKING_LINE = "NO"
                Case "1"
                    _USE_PICKING_LINE = "SI"
                Case "NO"
                    _USE_PICKING_LINE = "NO"
                Case Else
                    _USE_PICKING_LINE = "SI"
            End Select

        End Set
    End Property

    <Category("Datos Generales"), TypeConverter(GetType(SioNo)), Description("Necesita de control de calidad? (SI / NO)"), [Browsable](True)>
    Public Property UsaControlDeCalidad() As String
        Get
            Select Case _QUALITY_CONTROL
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
        Set(value As String)
            Select Case value
                Case "0"
                    _QUALITY_CONTROL = "NO"
                Case "1"
                    _QUALITY_CONTROL = "SI"
                Case "NO"
                    _QUALITY_CONTROL = "NO"
                Case Else
                    _QUALITY_CONTROL = "SI"
            End Select

        End Set
    End Property

    <Category("Datos Generales"), TypeConverter(GetType(SioNo)), Description("Maneja Serie Correlativa? (SI / NO)"), [Browsable](True)>
    Public Property ManejaSerieCorrelativa() As String
        Get
            Select Case _HANDLE_CORRELATIVE_SERIALS
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
        Set(value As String)
            Select Case value
                Case "0"
                    _HANDLE_CORRELATIVE_SERIALS = "NO"
                Case "1"
                    _HANDLE_CORRELATIVE_SERIALS = "SI"
                Case "NO"
                    _HANDLE_CORRELATIVE_SERIALS = "NO"
                Case Else
                    _HANDLE_CORRELATIVE_SERIALS = "SI"
            End Select

        End Set
    End Property

    <Category("Datos Generales"), Description("Proveedor")>
    Public Property Proveedor() As String
        Get
            Return _SUPPLIER
        End Get
        Set(ByVal value As String)
            _SUPPLIER = value
        End Set
    End Property

    <Category("Datos Generales"), Description("NombreProveedor")>
    Public Property NombreProveedor() As String
        Get
            Return _NAME_SUPPLIER
        End Get
        Set(ByVal value As String)
            _NAME_SUPPLIER = value
        End Set
    End Property

    <Category("Datos Generales"), Description("Tiempo de espera")>
    Public Property TiempoDeEspera() As Integer
        Get
            Return _LEAD_TIME
        End Get
        Set(ByVal value As Integer)
            _LEAD_TIME = value
        End Set
    End Property

    <Category("Datos Generales"), Description("Prefijo Series Correlativas")>
    Public Property PrefijoSerieCorrelativa() As String
        Get
            Return _PREFIX_CORRELATIVE_SERIALS
        End Get
        Set(ByVal Value As String)
            _PREFIX_CORRELATIVE_SERIALS = Value
        End Set
    End Property

    <Category("Datos Generales"), Description("Codigo de barras para el producto")>
    Public Property CodigoBarras() As String
        Get
            Return _BARCODE_ID
        End Get
        Set(ByVal Value As String)
            _BARCODE_ID = Value
        End Set
    End Property
    <Category("Datos Generales"), Description("cliente al que pertenece el producto")>
    Public Property Cliente() As String
        Get
            Return _CLIENT_OWNER
        End Get
        Set(ByVal Value As String)
            _CLIENT_OWNER = Value
        End Set
    End Property
    <Category("Datos Generales"), Description("codigo de producto")>
    Public Property Codigo() As String
        Get
            Return _MATERIAL_ID
        End Get
        Set(ByVal Value As String)
            _MATERIAL_ID = Value
        End Set
    End Property
    <Category("Datos Generales"), Description("Codigo de barras alterno para el producto")>
    Public Property CodigoBarrasAlterno() As String
        Get
            Return _ALTERNATE_BARCODE
        End Get
        Set(ByVal Value As String)
            _ALTERNATE_BARCODE = Value
        End Set
    End Property
    <Category("Datos Generales"), Description("Descripcion del producto (Max. 200 caracteres)")>
    Public Property Descripcion() As String
        Get
            Return _MATERIAL_NAME
        End Get
        Set(ByVal Value As String)
            _MATERIAL_NAME = Value
        End Set
    End Property
    <Category("Datos Generales"), Description("Descripcion corta del producto (Max. 25 caracteres)")>
    Public Property DescripcionCorta() As String
        Get
            Return _SHORT_NAME
        End Get
        Set(ByVal Value As String)
            _SHORT_NAME = Value
        End Set
    End Property
    <Category("Dimensiones"), Description("Factor del volumen")>
    Public Property FactorVolumen() As Double
        Get
            Return _VOLUME_FACTOR
        End Get
        Set(ByVal Value As Double)
            _VOLUME_FACTOR = Value
        End Set
    End Property
    <Category("Dimensiones"), Description("Alto")>
    Public Property Alto() As Double
        Get
            Return _HIGH
        End Get
        Set(ByVal Value As Double)
            _HIGH = Value
        End Set
    End Property
    <Category("Dimensiones"), Description("Largo")>
    Public Property Largo() As Double
        Get
            Return _LENGTH
        End Get
        Set(ByVal Value As Double)
            _LENGTH = Value
        End Set
    End Property
    <Category("Dimensiones"), Description("Ancho")>
    Public Property Ancho() As Double
        Get
            Return _WIDTH
        End Get
        Set(ByVal Value As Double)
            _WIDTH = Value
        End Set
    End Property
    <Category("Dimensiones"), Description("Peso"), [ReadOnly](True)>
    Public Property Peso() As Double
        Get
            Return _WEIGTH
        End Get
        Set(ByVal Value As Double)
            _WEIGTH = Value  'Regex.Replace(value.ToString(), "\d+,{1}\d{0,6}", String.Empty)
        End Set
    End Property
    <Category("Datos Generales"), TypeConverter(GetType(MaterialClassEnum)), Description("Clasificacion del producto")>
    Public Property Clase() As String
        Get
            Return _MATERIAL_CLASS
        End Get
        Set(ByVal Value As String)
            _MATERIAL_CLASS = Value
        End Set
    End Property
    <Category("Datos Generales"), TypeConverter(GetType(MaterialSubClassEnum)), Description("Sub-Clasificacion del producto")>
    Public Property SubClase() As String
        Get
            Return _MATERIAL_SUB_CLASS
        End Get
        Set(ByVal Value As String)
            _MATERIAL_SUB_CLASS = Value
        End Set
    End Property
    <Category("Datos Generales"), TypeConverter(GetType(MaterialUnitWeightEnum)), Description("Unidad de peso")>
    Public Property UnidadPeso() As String
        Get
            Return _WEIGHT_MEASUREMENT
        End Get
        Set(ByVal Value As String)
            _WEIGHT_MEASUREMENT = Value
        End Set
    End Property
    <Category("Datos Generales"), Description("Cantidad Maxima por BIN")>
    Public Property CantidadMaxPorBin() As String
        Get
            Return _MAX_X_BIN
        End Get
        Set(ByVal Value As String)
            _MAX_X_BIN = Value
        End Set
    End Property
    <Category("Datos de Auditoria"), Description("Ultima Actualizacion")>
    Public Property Actualizado_el() As String
        Get
            Return _LAST_UPDATED
        End Get
        Set(ByVal Value As String)
            _LAST_UPDATED = Value
        End Set
    End Property
    <Category("Datos de Auditoria"), Description("Ultimo usuario que actualizo")>
    Public Property Actualizado_por() As String
        Get
            Return _LAST_UPDATED_BY
        End Get
        Set(ByVal Value As String)
            _LAST_UPDATED_BY = Value
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
            Dim xserv As New OnePlanServices_Materials.WMS_MaterialsSoapClient("WMS_MaterialsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_materials.asmx")
            If ManejaSerie = "NO" And ManejaSerieCorrelativa = "SI" Then
                pResult = "No se puede configurar Series correlativas al material porque el material no maneja series."
                Return False
            End If
            xserv.SearchByKeyMaterials(Codigo, pLocalResult, PublicLoginInfo.Environment)
            If pLocalResult = "OK" Then 'Update the record

                If xserv.UpdateMaterials(Cliente,
                                         Codigo,
                                         CodigoBarras,
                                         CodigoBarrasAlterno,
                                         Descripcion.Replace("'", "''"),
                                         DescripcionCorta.Replace("'", "''"),
                                         FactorVolumen,
                                         Clase,
                                         SubClase,
                                         Alto,
                                         Largo,
                                         Ancho,
                                         CantidadMaxPorBin,
                                         _SCAN_BY_ONE,
                                         _REQUIRES_LOGISTICS_INFO,
                                         Peso,
                                         Actualizado_por,
                                         IIf(EsCarro = "SI", 1, 0),
                                         IIf(ManejaLote = "SI", 1, 0),
                                         pLocalResult,
                                         PublicLoginInfo.Environment,
                                         IIf(ManejaSerie = "SI", 1, 0),
                                         IIf(ManejaMasterPack = "SI", 1, 0),
                                         UnidadPeso,
                                         IIf(ManejaExplosionEnRecepcion = "SI", 1, 0),
                                         IIf(ManejaTono = "SI", 1, 0),
                                         IIf(ManejaCalibre = "SI", 1, 0),
                                         IIf(UsaLineaDePicking = "SI", 1, 0),
                                         IIf(UsaControlDeCalidad = "SI", 1, 0),
                                         PrefijoSerieCorrelativa,
                                         IIf(ManejaSerieCorrelativa = "SI", 1, 0),
                                         TiempoDeEspera,
                                         Proveedor,
                                         NombreProveedor) Then
                    Return True
                Else
                    pResult = pLocalResult
                    Return False
                End If
            Else 'Add new record
                If xserv.CreateMaterials(Cliente,
                                         Codigo,
                                         CodigoBarras,
                                         CodigoBarrasAlterno,
                                         Descripcion.Replace("'", "''"),
                                         DescripcionCorta.Replace("'", "''"),
                                         Format(FactorVolumen, "#0.0000"),
                                         Clase,
                                         SubClase,
                                         Alto,
                                         Largo,
                                         Ancho,
                                         CantidadMaxPorBin,
                                         _SCAN_BY_ONE,
                                         _REQUIRES_LOGISTICS_INFO,
                                         Peso,
                                         Actualizado_por,
                                         IIf(EsCarro = "SI", 1, 0),
                                         IIf(ManejaLote = "SI", 1, 0),
                                         pLocalResult,
                                         PublicLoginInfo.Environment,
                                         IIf(ManejaSerie = "SI", 1, 0),
                                         IIf(ManejaMasterPack = "SI", 1, 0),
                                         UnidadPeso,
                                         IIf(ManejaExplosionEnRecepcion = "SI", 1, 0),
                                         IIf(ManejaTono = "SI", 1, 0),
                                         IIf(ManejaCalibre = "SI", 1, 0),
                                         IIf(UsaLineaDePicking = "SI", 1, 0),
                                         IIf(UsaControlDeCalidad = "SI", 1, 0),
                                         PrefijoSerieCorrelativa,
                                         IIf(ManejaSerieCorrelativa = "SI", 1, 0),
                                         TiempoDeEspera,
                                         Proveedor,
                                         NombreProveedor) Then
                    Codigo = Cliente + "/" + Codigo
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
            Dim xserv As New OnePlanServices_Materials.WMS_MaterialsSoapClient("WMS_MaterialsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_materials.asmx")

            If xserv.DeleteMaterials(Codigo, Cliente, pLocalResult, PublicLoginInfo.Environment) Then
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

    public Function ObtenerUnidadPeso() As String()
        Dim XStr(0) As String
        Dim I As Integer = 0
        Dim xserv As New OnePlanServices_Settings.WMS_SettingsSoapClient("WMS_SettingsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_settings.asmx")
        Dim xdataset As New DataSet
        Dim pResult As String = ""
        Dim xdr As DataRow
        Try
            xdataset = xserv.GetParam_ByParamKey("SISTEMA", "UNIDAD_PESO", "", pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then
                For Each xdr In xdataset.Tables(0).Rows
                    ReDim Preserve XStr(I)
                    XStr(I) = xdr("PARAM_NAME").ToString
                    I = I + 1
                Next
            End If
        Catch ex As Exception
            XStr(0) = ex.Message
        End Try
        Return XStr
    End Function

    Public Function ObtenerClaseDeMaterial() As String()

        Dim XStr(0) As String
        Dim I As Integer = 0
        Dim xserv As New OnePlanServices_Materials.WMS_MaterialsSoapClient("WMS_MaterialsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_materials.asmx")
        Dim xtable As DataTable
        Dim pResult As String = ""

        Try
            xtable = xserv.ObtenerClasesParaMaterial(pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then

                For Each xdr In xtable.Rows
                    ReDim Preserve XStr(I)
                    XStr(I) = xdr("CLASS_NAME").ToString()
                    I = I + 1
                Next

            End If
        Catch ex As Exception
            XStr(0) = ex.Message
        End Try

        Return XStr
    End Function

    Public Function ObtenerSubClaseDeMaterial() As String()

        Dim XStr(0) As String
        Dim I As Integer = 0
        Dim xserv As New OnePlanServices_Materials.WMS_MaterialsSoapClient("WMS_MaterialsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_materials.asmx")
        Dim xtable As DataTable
        Dim pResult As String = ""

        Try
            xtable = xserv.ObtenerSubClasesParaMaterial(pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then

                For Each xdr In xtable.Rows
                    ReDim Preserve XStr(I)
                    XStr(I) = xdr("SUB_CLASS_NAME").ToString()
                    I = I + 1
                Next

            End If
        Catch ex As Exception
            XStr(0) = ex.Message
        End Try

        Return XStr
    End Function

End Class
