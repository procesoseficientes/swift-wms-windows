Imports System.ComponentModel
Public Class ParamTypeEnum
    Inherits StringConverter
    Public Sub New()
        MyBase.New()
    End Sub
    'Private ParamTypeEnum() As String = {"INGRESOS", "ALMACENAMIENTO", "EGRESOS", "SISTEMA", "SEGURIDAD", "OTROS"}
    Private ParamTypeEnum() As String = GetParamTypes()
    Public Overloads Overrides Function GetStandardValuesSupported(ByVal context As ITypeDescriptorContext) As Boolean
        'True = Se despliega la lista
        'False = No se despliega la lista y el ususario debe escribir un valor
        Return True
    End Function
    Public Overloads Overrides Function GetStandardValues(ByVal context As ITypeDescriptorContext) As StandardValuesCollection
        Return New StandardValuesCollection(ParamTypeEnum)
    End Function
    Public Overloads Overrides Function GetStandardValuesExclusive(ByVal context As ITypeDescriptorContext) As Boolean
        'True = el combo no admite más items que los de la lista
        'False = el combo admite un item que no esté en la lista
        Return False
    End Function

    Public Function GetParamTypes()
        Dim XStr(0) As String
        Dim I As Integer = 0
        Dim xser As New OnePlanServices_Settings.WMS_SettingsSoapClient("WMS_SettingsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_settings.asmx")
        Dim xds As New DataSet
        Dim xdr As DataRow
        Dim pResult As String = ""
        Try
            xds = xser.GetParam_ByParamKey("SISTEMA", "TIPOS_PARAMETROS", "", pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then
                For Each xdr In xds.Tables(0).Rows
                    XStr(I) = xdr("PARAM_NAME").ToString()
                    I = I + 1
                    ReDim Preserve XStr(I)
                Next
            End If
        Catch ex As Exception
            XStr(0) = ex.Message
        End Try
        Return XStr
    End Function

End Class

Public Class CtrlPanel_Class

    Private _ParamType As String = ""

    Private _PARAM_GROUP As String = ""
    Private _PARAM_GROUP_CAPTION As String = ""

    Private _PARAM_NAME As String = ""
    Private _PARAM_CAPTION As String = ""

    Private _NUMERIC_VALUE As Integer = 0
    Private _MONEY_VALUE As Double = 0
    Private _TEXT_VALUE As String = ""
    Private _DATE_VALUE As Date = Nothing
    Private _DECIMAL_VALUE As Double = Nothing


    Private _RANGE_NUM_START As Integer = 0
    Private _RANGE_NUM_END As Integer = 0
    Private _RANGE_DATE_START As Date = Nothing
    Private _RANGE_DATE_END As Date = Nothing

    Private _SPARE1 As String = ""
    Private _SPARE2 As String = ""
    Private _SPARE3 As String = ""
    Private _SPARE4 As String = ""
    Private _SPARE5 As String = ""

    Private _COLOR As Color = Drawing.Color.Transparent

    Public Function Grabar(ByRef pResult As String) As Boolean
        Dim pLocalResult As String = ""

        Try
            Dim xserv As New OnePlanServices_Settings.WMS_SettingsSoapClient("WMS_SettingsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_settings.asmx")

            xserv.GetParam_ByParamKey(Tipo, Grupo, NombreDelParametro, pLocalResult, PublicLoginInfo.Environment)
            If pLocalResult = "OK" Then 'Update the record
                If xserv.UpdateParams(Tipo, Grupo, TituloDelGrupo, NombreDelParametro, TituloDelParametro, ValorNumerico, ValorMonetario, ValorTexto, ValorFecha, NumeroInicial, NumeroFinal, FechaInicial, FechaFinal, ValorExtra_1, ValorExtra_2, pLocalResult, PublicLoginInfo.Environment, ValorDecimal, ValorExtra_3, ValorExtra_4, ValorExtra_5, Color.ToArgb) Then
                    Return True
                Else
                    pResult = pLocalResult
                    Return False
                End If

            Else 'Add new record
                If xserv.CreateParams(Tipo, Grupo, TituloDelGrupo, NombreDelParametro, TituloDelParametro, ValorNumerico, ValorMonetario, ValorTexto, ValorFecha, NumeroInicial, NumeroFinal, FechaInicial, FechaFinal, ValorExtra_1, ValorExtra_2, pLocalResult, PublicLoginInfo.Environment, ValorDecimal, ValorExtra_3, ValorExtra_4, ValorExtra_5, Color.ToArgb) Then
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
    Function ConvertRGBToHex(ByVal color As Color) As String
        Dim colorValue As Color = color
        Dim RGBValue As Integer = colorValue.ToArgb()
        Dim hexValue As String = RGBValue.ToString("X6")
        Return hexValue
    End Function


    Public Function Delete(ByRef pResult As String) As Boolean
        Dim pLocalResult As String = ""

        Try
            Dim xserv As New OnePlanServices_Settings.WMS_SettingsSoapClient("WMS_SettingsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_settings.asmx")

            'delete a record
            If xserv.DeleteParam(Tipo, Grupo, NombreDelParametro, pLocalResult, PublicLoginInfo.Environment) Then
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

    <Category("Datos del Grupo"), TypeConverter(GetType(ParamTypeEnum)), Description("Tipo de parametro")>
    Public Property Tipo() As String
        Get
            Return _ParamType
        End Get
        Set(ByVal Value As String)
            _ParamType = Value
        End Set
    End Property
    <Category("Datos del Grupo"), Description("Grupo de parametro")>
    Public Property Grupo() As String
        Get
            Return _PARAM_GROUP
        End Get
        Set(ByVal Value As String)
            _PARAM_GROUP = Value
        End Set
    End Property
    <Category("Datos del Grupo"), Description("Titulo del Grupo")>
    Public Property TituloDelGrupo() As String
        Get
            Return _PARAM_GROUP_CAPTION
        End Get
        Set(ByVal Value As String)
            _PARAM_GROUP_CAPTION = Value
        End Set
    End Property

    <Category("Datos del Parametro"), Description("Nombre del parametro")>
    Public Property NombreDelParametro() As String
        Get
            Return _PARAM_NAME
        End Get
        Set(ByVal Value As String)
            _PARAM_NAME = Value
        End Set
    End Property

    <Category("Datos del Parametro"), Description("Nombre del parametro")>
    Public Property TituloDelParametro() As String
        Get
            Return _PARAM_CAPTION
        End Get
        Set(ByVal Value As String)
            _PARAM_CAPTION = Value
        End Set
    End Property
    <Category("Valores del Parametro"), Description("Valor Numerico")>
    Public Property ValorNumerico() As Integer
        Get
            Return _NUMERIC_VALUE
        End Get
        Set(ByVal Value As Integer)
            _NUMERIC_VALUE = Value
        End Set
    End Property

    <Category("Valores del Parametro"), Description("Valor Monetario")>
    Public Property ValorMonetario() As Double
        Get
            Return _MONEY_VALUE
        End Get
        Set(ByVal Value As Double)
            _MONEY_VALUE = Value
        End Set
    End Property

    <Category("Valores del Parametro"), Description("Valor Texto")>
    Public Property ValorTexto() As String
        Get
            Return _TEXT_VALUE
        End Get
        Set(ByVal Value As String)
            _TEXT_VALUE = Value
        End Set
    End Property

    <Category("Valores del Parametro"), Description("Valor en Fecha")>
    Public Property ValorFecha() As Date
        Get
            Return _DATE_VALUE
        End Get
        Set(ByVal Value As Date)
            _DATE_VALUE = Value
        End Set
    End Property

    <Category("Valores del Parametro"), Description("Valor Decimal")>
    Public Property ValorDecimal() As Double
        Get
            Return _DECIMAL_VALUE
        End Get
        Set(ByVal Value As Double)
            _DECIMAL_VALUE = Value
        End Set
    End Property

    <Category("Rangos de valor"), Description("Valor Numerico Inicial")>
    Public Property NumeroInicial() As Integer
        Get
            Return _RANGE_NUM_START
        End Get
        Set(ByVal Value As Integer)
            _RANGE_NUM_START = Value
        End Set
    End Property
    <Category("Rangos de valor"), Description("Valor Numerico Final")>
    Public Property NumeroFinal() As Integer
        Get
            Return _RANGE_NUM_END
        End Get
        Set(ByVal Value As Integer)
            _RANGE_NUM_END = Value
        End Set
    End Property
    <Category("Rangos de valor"), Description("Valor Fecha Inicial")>
    Public Property FechaInicial() As Date
        Get
            Return _RANGE_DATE_START
        End Get
        Set(ByVal Value As Date)
            _RANGE_DATE_START = Value
        End Set
    End Property
    <Category("Rangos de valor"), Description("Valor Fecha Inicial")>
    Public Property FechaFinal() As Date
        Get
            Return _RANGE_DATE_END
        End Get
        Set(ByVal Value As Date)
            _RANGE_DATE_END = Value
        End Set
    End Property
    <Category("Valores extras"), Description("Valor Extra 1")>
    Public Property ValorExtra_1() As String
        Get
            Return _SPARE1
        End Get
        Set(ByVal Value As String)
            _SPARE1 = Value
        End Set
    End Property
    <Category("Valores extras"), Description("Valor Extra 2")>
    Public Property ValorExtra_2() As String
        Get
            Return _SPARE2
        End Get
        Set(ByVal Value As String)
            _SPARE2 = Value
        End Set
    End Property
    <Category("Valores extras"), Description("Valor Extra 3")>
    Public Property ValorExtra_3() As String
        Get
            Return _SPARE3
        End Get
        Set(ByVal Value As String)
            _SPARE3 = Value
        End Set
    End Property
    <Category("Valores extras"), Description("Valor Extra 4")>
    Public Property ValorExtra_4() As String
        Get
            Return _SPARE4
        End Get
        Set(ByVal Value As String)
            _SPARE4 = Value
        End Set
    End Property
    <Category("Valores extras"), Description("Valor Extra 5")>
    Public Property ValorExtra_5() As String
        Get
            Return _SPARE5
        End Get
        Set(ByVal Value As String)
            _SPARE5 = Value
        End Set
    End Property
    <Category("Valores extras"), Description("Color")>
    Public Property Color() As Color
        Get
            Return _COLOR
        End Get
        Set(ByVal Value As Color)
            _COLOR = Value
        End Set
    End Property



End Class

