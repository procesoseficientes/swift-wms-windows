Imports System.ComponentModel
Public Class LineBalancingClassEnum
    Inherits StringConverter

    Public Sub New()
        MyBase.New()
    End Sub
    
    Public Function GetLineBalancingClassEnum()
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
        Return New StandardValuesCollection(GetLineBalancingClassEnum())
    End Function
    Public Overloads Overrides Function GetStandardValuesExclusive(ByVal context As ITypeDescriptorContext) As Boolean
        'True = el combo no admite más items que los de la lista
        'False = el combo admite un item que no esté en la lista
        Return True
    End Function

End Class

Public Class clsLineBalancing
    Public _SIZE As String
    Public _SIZE_DESCRIPTION As String
    Public _INITIAL_RANGE As Double
    Public _FINAL_RANGE As Double
    Public _LINE_1_PERCENT As Double
    Public _LINE_2_PERCENT As Double
    Public _LINE_3_PERCENT As Double
    <Category("Datos Generales"), Description("Tamaño")> _
       Public Property Tamano() As String
        Get
            Return _SIZE
        End Get
        Set(ByVal Value As String)
            _SIZE = Value
        End Set
    End Property
    <Category("Datos Generales"), Description("Descripcion del Tamaño")> _
       Public Property Descripcion() As String
        Get
            Return _SIZE_DESCRIPTION
        End Get
        Set(ByVal Value As String)
            _SIZE_DESCRIPTION = Value
        End Set
    End Property
    <Category("Datos Generales"), Description("Rango Inicial")> _
       Public Property RangoInicial() As Double
        Get
            Return _INITIAL_RANGE
        End Get
        Set(ByVal Value As Double)
            _INITIAL_RANGE = Value
        End Set
    End Property
    <Category("Datos Generales"), Description("Rango Final")> _
       Public Property RangoFinal() As Double
        Get
            Return _FINAL_RANGE
        End Get
        Set(ByVal Value As Double)
            _FINAL_RANGE = Value
        End Set
    End Property
    <Category("Datos Generales"), Description("Porcentaje Linea 1")> _
       Public Property PorcentajeLinea1() As Double
        Get
            Return _LINE_1_PERCENT
        End Get
        Set(ByVal Value As Double)
            _LINE_1_PERCENT = Value
        End Set
    End Property
    <Category("Datos Generales"), Description("Porcentaje Linea 2")> _
       Public Property PorcentajeLinea2() As Double
        Get
            Return _LINE_2_PERCENT
        End Get
        Set(ByVal Value As Double)
            _LINE_2_PERCENT = Value
        End Set
    End Property
    <Category("Datos Generales"), Description("Porcentaje Linea 3")> _
       Public Property PorcentajeLinea3() As Double
        Get
            Return _LINE_3_PERCENT
        End Get
        Set(ByVal Value As Double)
            _LINE_3_PERCENT = Value
        End Set
    End Property

    Public Function Grabar(ByRef pResult As String) As Boolean
        Dim pLocalResult As String = ""
        Try

            'Solo se puede grabar si el balance por linea (todas las lineas) da 100% ó 0
            If (PorcentajeLinea1 + PorcentajeLinea2 + PorcentajeLinea3 <> 100) And (PorcentajeLinea1 + PorcentajeLinea2 + PorcentajeLinea3 <> 0) Then

                pResult = "El porcentaje asignado a cada linea debe sumar 100% o bien Cero"

            Else

                Dim xserv As New OnePlanServices_Settings.WMS_SettingsSoapClient("WMS_SettingsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_settings.asmx")

                xserv.SearchLineBalancingBySize(Tamano, pLocalResult, PublicLoginInfo.Environment)

                If pLocalResult = "OK" Then 'Update the record
                    If xserv.UpdateLineBalancing(Tamano, Descripcion.Replace("'", "''"), RangoInicial, RangoFinal, PorcentajeLinea1, PorcentajeLinea2, PorcentajeLinea3, pLocalResult, PublicLoginInfo.Environment) Then
                        Return True
                    Else
                        pResult = pLocalResult
                        Return False
                    End If
                Else 'Add new record
                    If xserv.CreateLineBalancing(Tamano, Descripcion.Replace("'", "''"), RangoInicial, RangoFinal, PorcentajeLinea1, PorcentajeLinea2, PorcentajeLinea3, pLocalResult, PublicLoginInfo.Environment) Then
                        Return True
                    Else
                        pResult = pLocalResult
                        Return False
                    End If
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
            Dim xserv As New OnePlanServices_Settings.WMS_SettingsSoapClient("WMS_SettingsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_settings.asmx")

            If xserv.DeleteLineBalancing(Tamano, pLocalResult, PublicLoginInfo.Environment) Then
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
