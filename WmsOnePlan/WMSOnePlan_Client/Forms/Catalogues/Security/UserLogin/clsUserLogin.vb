Imports System.ComponentModel
Imports DevExpress.UserSkins
Imports DevExpress.Skins
Imports DevExpress.Skins.Info

Public Class clsUserLogin
    Public _LOGIN_ID As String
    Public _ROLE_ID As String
    Public _LOGIN_NAME As String
    Public _LOGIN_TYPE As String
    Public _LOGIN_STATUS As String = "ACTIVO"
    Public _LOGIN_PWD As String
    Public _LICENSE_SERIAL As String
    Public _ENVIRONMENT As String
    Public _USERGUI As String
    Public _CONSOLIDATION_TERMINAL As Integer
    Public _GENERATE_TASKS As Integer '07-Oct-10
    Public _LINE_ID As String
    Public _DOMAIN As String
    Public _LOADING_GATE As String
    Public _WAREHOUSE_ID As String
    Public _EMAIL As String
    Public _AUTHORIZER As String
    Public _NotifyLetterQuota As String
    Public _CAN_RELOCATE As String
    Public _LINE_POSITION As String
    Public _SPOT_COLUMN As String
    Public _TERMINAL_IP As String
    public  shared _DEFAULT_DOMAIN AS String  = string.Empty
    Public Class UserLine
        Inherits StringConverter
        Public Sub New()
            MyBase.New()
        End Sub
        Private UserLineEnum() As String = GetLines()
        
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
            Return New StandardValuesCollection(UserLineEnum)
        End Function
        Public Overloads Overrides Function GetStandardValuesExclusive(ByVal context As ITypeDescriptorContext) As Boolean
            'True = el combo no admite más items que los de la lista
            'False = el combo admite un item que no esté en la lista
            Return True
        End Function
    End Class

     Public Class UserDomains
        Inherits StringConverter
        Public Sub New()
            MyBase.New()
        End Sub
        Private DomainsEnum() As String = GetDomains()
        
        Public Function GetDomains()
            Dim XStr(0) As String
            Dim I As Integer = 0
            Dim securityProvider As New OnePlanServices_Security.WMS_SecuritySoapClient("WMS_SecuritySoap", PublicLoginInfo.WSHost + "/Catalogues/wms_security.asmx")
            Dim domainsTable As New DataTable
            Dim xdr As DataRow
            Dim result As String = ""
            Try
                domainsTable = securityProvider.GetDomains(result,  PublicLoginInfo.Environment)
                If result = "OK" Then
                    For Each xdr In domainsTable.Rows
                        If I = 0 Then
                            _DEFAULT_DOMAIN =  xdr("ID").ToString +" - " + xdr("DOMAIN").ToString
                        End If
                        XStr(I) =  xdr("ID").ToString +" - " + xdr("DOMAIN").ToString
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
            Return New StandardValuesCollection(DomainsEnum)
        End Function
        Public Overloads Overrides Function GetStandardValuesExclusive(ByVal context As ITypeDescriptorContext) As Boolean
            'True = el combo no admite más items que los de la lista
            'False = el combo admite un item que no esté en la lista
            Return True
        End Function
    End Class

    Public Class UserLinePosition
        Inherits StringConverter
        Public Sub New()
            MyBase.New()
        End Sub
        Private UserLinePositionEnum() As String = GetLinesPosition()
        Public Function GetLinesPosition()
            Dim combo(0) As String
            Try 
                Dim tabla As DataTable = New DataTable("PosisionDeLinea")
                tabla.Columns.Add("Valor", Type.GetType("System.String"))
                tabla.Rows.Add("Principio")
                tabla.Rows.Add("Final")
                tabla.Rows.Add("Intermedio")
            
                For j As Integer = 0 To tabla.Rows.Count - 1
                    combo(j) = tabla.Rows(j)("Valor").ToString
                    ReDim Preserve combo(j+1)
                Next
            Catch ex As Exception
                combo(0) = "Ninguno"
            End Try
            Return combo
        End Function
        Public Overloads Overrides Function GetStandardValuesSupported(ByVal context As ITypeDescriptorContext) As Boolean
            'True = Se despliega la lista
            'False = No se despliega la lista y el ususario debe escribir un valor
            Return True
        End Function
        Public Overloads Overrides Function GetStandardValues(ByVal context As ITypeDescriptorContext) As StandardValuesCollection
            Return New StandardValuesCollection(UserLinePositionEnum)
        End Function
        Public Overloads Overrides Function GetStandardValuesExclusive(ByVal context As ITypeDescriptorContext) As Boolean
            'True = el combo no admite más items que los de la lista
            'False = el combo admite un item que no esté en la lista
            Return True
        End Function
    End Class

    Public Class UserEnvironment
        Inherits StringConverter
        Public Sub New()
            MyBase.New()
        End Sub
        Private UserEnvironmentEnum() As String = GetUserEnvironment()
        Public Function GetUserEnvironment()
            Dim XStr(0) As String
            Dim I As Integer = 0
            Dim xserv As New OnePlanServices_Security.WMS_SecuritySoapClient("WMS_SecuritySoap", PublicLoginInfo.WSHost + "/Catalogues/wms_security.asmx")
            Dim xds As New DataSet
            Dim xdr As DataRow
            Dim pResult As String = ""
            Try
                xds = xserv.GetEnvironments("OP_WMS", pResult, PublicLoginInfo.Environment)
                If pResult = "OK" Then
                    For Each xdr In xds.Tables(0).Rows
                        XStr(I) = xdr("ENVIRONMENT_NAME").ToString
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
            Return New StandardValuesCollection(UserEnvironmentEnum)
        End Function
        Public Overloads Overrides Function GetStandardValuesExclusive(ByVal context As ITypeDescriptorContext) As Boolean
            'True = el combo no admite más items que los de la lista
            'False = el combo admite un item que no esté en la lista
            Return True
        End Function
    End Class
    Public Class UserGui
        Inherits StringConverter
        Public Sub New()
            MyBase.New()
        End Sub
        Private UserGuiEnum() As String = GetUserGui()
        Public Function GetUserGui()
            Dim XStr(0) As String
            Dim I As Integer = 0
            'Dim xserv As New OnePlanServices_Settings.WMS_SettingsSoapClient("WMS_SettingsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_settings.asmx")
            'Dim xds As New DataSet
            'Dim xdr As DataRow
            'Dim pResult As String = ""
            Try

                For j = 0 To SkinManager.Default.Skins.Count - 1
                    Try
                        XStr(I) = SkinManager.Default.Skins(j).SkinName.ToString
                        ReDim Preserve XStr(I + 1)
                        I = I + 1
                    Catch ex As Exception
                        MessageBox.Show(ex.Message)
                    End Try

                Next

                'xds = xserv.GetParam_ByParamKey("SISTEMA", "GUI_LAYOUT", "", pResult, PublicLoginInfo.Environment)
                'If pResult = "OK" Then
                '    For Each xdr In xds.Tables(0).Rows
                '        XStr(I) = xdr("PARAM_NAME").ToString
                '        ReDim Preserve XStr(I + 1)
                '        I = I + 1
                '    Next
                'End If

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
            Return New StandardValuesCollection(UserGuiEnum)
        End Function
        Public Overloads Overrides Function GetStandardValuesExclusive(ByVal context As ITypeDescriptorContext) As Boolean
            'True = el combo no admite más items que los de la lista
            'False = el combo admite un item que no esté en la lista
            Return True
        End Function
    End Class
    Public Class UserTypeEnum
        Inherits StringConverter
        Public Sub New()
            MyBase.New()
        End Sub
        Private UserTypeEnum() As String = {"PC", "MOVIL", "PC_Y_MOVIL"}
        Public Overloads Overrides Function GetStandardValuesSupported(ByVal context As ITypeDescriptorContext) As Boolean
            'True = Se despliega la lista
            'False = No se despliega la lista y el ususario debe escribir un valor
            Return True
        End Function
        Public Overloads Overrides Function GetStandardValues(ByVal context As ITypeDescriptorContext) As StandardValuesCollection
            Return New StandardValuesCollection(UserTypeEnum)
        End Function
        Public Overloads Overrides Function GetStandardValuesExclusive(ByVal context As ITypeDescriptorContext) As Boolean
            'True = el combo no admite más items que los de la lista
            'False = el combo admite un item que no esté en la lista
            Return True
        End Function
    End Class
    Public Class UserStatusEnum
        Inherits StringConverter
        Public Sub New()
            MyBase.New()
        End Sub
        Private UserStatusEnum() As String = {"ACTIVO", "BLOQUEADO"}
        Public Overloads Overrides Function GetStandardValuesSupported(ByVal context As ITypeDescriptorContext) As Boolean
            'True = Se despliega la lista
            'False = No se despliega la lista y el ususario debe escribir un valor
            Return True
        End Function
        Public Overloads Overrides Function GetStandardValues(ByVal context As ITypeDescriptorContext) As StandardValuesCollection
            Return New StandardValuesCollection(UserStatusEnum)
        End Function
        Public Overloads Overrides Function GetStandardValuesExclusive(ByVal context As ITypeDescriptorContext) As Boolean
            'True = el combo no admite más items que los de la lista
            'False = el combo admite un item que no esté en la lista
            Return True
        End Function
    End Class
    Public Class LevelAccessEnum
        Inherits StringConverter
        Public Sub New()
            MyBase.New()
        End Sub
        Private LevelAccessEnum() As String = GetLevelAccess()
        Public Function GetLevelAccess()
            Dim XStr(0) As String
            Dim I As Integer = 0
            Dim xserv As New OnePlanServices_Security.WMS_SecuritySoapClient("WMS_SecuritySoap", PublicLoginInfo.WSHost + "/Catalogues/wms_security.asmx")
            Dim xds As New DataSet
            Dim xdr As DataRow
            Dim pResult As String = ""
            Try
                xds = xserv.AccessLevelGroups(pResult, PublicLoginInfo.Environment)
                If pResult = "OK" Then
                    For Each xdr In xds.Tables(0).Rows
                        XStr(I) = xdr("ROLE_ID").ToString
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
            Return New StandardValuesCollection(LevelAccessEnum)
        End Function
        Public Overloads Overrides Function GetStandardValuesExclusive(ByVal context As ITypeDescriptorContext) As Boolean
            'True = el combo no admite más items que los de la lista
            'False = el combo admite un item que no esté en la lista
            Return True
        End Function
    End Class

    Public Class WhereHouseEndabled
        Inherits StringConverter
        Public Sub New()
            MyBase.New()
        End Sub
        Private WhereHouseEndabled() As String = GetWhereHouseEndabled()
        Public Function GetWhereHouseEndabled()
            Dim XStr(0) As String
            Dim I As Integer = 0
            Dim xserv As New OnePlanServices_Locations.WMS_LocationsSoapClient("WMS_LocationsSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Locations.asmx")
            Dim xds As New DataSet
            Dim xdr As DataRow
            Dim pResult As String = ""
            Try
                xds = xserv.GetWareHouseEnabled(pResult, PublicLoginInfo.Environment)
                If pResult = "OK" Then
                    For Each xdr In xds.Tables(0).Rows
                        XStr(I) = xdr("WAREHOUSE_ID").ToString
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
            Return New StandardValuesCollection(WhereHouseEndabled)
        End Function
        Public Overloads Overrides Function GetStandardValuesExclusive(ByVal context As ITypeDescriptorContext) As Boolean
            'True = el combo no admite más items que los de la lista
            'False = el combo admite un item que no esté en la lista
            Return True
        End Function
    End Class

    <Category("Datos Generales"), Description("Codigo de usuario maximo 25 caracteres")> _
       Public Property CodigoUsuario() As String
        Get
            Return _LOGIN_ID
        End Get
        Set(ByVal Value As String)
            _LOGIN_ID = Value
        End Set
    End Property
    <Category("Grado de Acceso"), TypeConverter(GetType(LevelAccessEnum)), Description("El grado de acceso y privilegios del usuario")> _
       Public Property NivelAcceso() As String
        Get
            Return _ROLE_ID
        End Get
        Set(ByVal Value As String)
            _ROLE_ID = Value
        End Set
    End Property
    <Category("Datos Generales"), Description("Nombre completo del usuario")> _
       Public Property NombreUsuario() As String
        Get
            Return _LOGIN_NAME
        End Get
        Set(ByVal Value As String)
            _LOGIN_NAME = Value
        End Set
    End Property
    <Category("Datos Generales"), TypeConverter(GetType(UserTypeEnum)), Description("Tipo de usuario")> _
       Public Property TipoUsuario() As String
        Get
            Return _LOGIN_TYPE
        End Get
        Set(ByVal Value As String)
            _LOGIN_TYPE = Value
        End Set
    End Property
    <Category("Datos Generales"), TypeConverter(GetType(UserStatusEnum)), Description("Estatus del usuario")> _
       Public Property Estatus() As String
        Get
            Return _LOGIN_STATUS
        End Get
        Set(ByVal Value As String)
            _LOGIN_STATUS = Value
        End Set
    End Property
    <Category("Datos Generales"), Description("Clave personal del usuario no mayor a 25 caracteres"), PasswordPropertyText(True)> _
       Public Property Password() As String
        Get
            Return _LOGIN_PWD
        End Get
        Set(ByVal Value As String)
            _LOGIN_PWD = Value
        End Set
    End Property
    <Category("Autenticacion"), Description("No. serial de la licencia otorgada por Mobility SCM Inc.")> _
       Public Property SerieDeLicencia() As String
        Get
            Return _LICENSE_SERIAL
        End Get
        Set(ByVal Value As String)
            _LICENSE_SERIAL = Value
        End Set
    End Property
    <Category("Datos Generales"), TypeConverter(GetType(UserEnvironment)), Description("Ambiente de trabajo definido para el usuario.")> _
       Public Property AmbienteTrabajo() As String
        Get
            Return _ENVIRONMENT
        End Get
        Set(ByVal Value As String)
            _ENVIRONMENT = Value
        End Set
    End Property
    <Category("Datos Generales"), TypeConverter(GetType(UserGui)), Description("Intefase grafica del sistema.")> _
    Public Property InterfaseGrafica() As String
        Get
            Return _USERGUI
        End Get
        Set(ByVal Value As String)
            _USERGUI = Value
        End Set
    End Property
    
    <Category("Datos Generales"), Description("Numero de Terminal de Consolidacion asignada.")> _
   Public Property TerminalConsolidacion() As Integer
        Get
            Return _CONSOLIDATION_TERMINAL
        End Get
        Set(ByVal Value As Integer)
            _CONSOLIDATION_TERMINAL = Value
        End Set
    End Property

    <Category("Datos Generales"), Description("Define si el usuario genera tareas de Picking o no.")> _
   Public Property GeneraTareas() As Integer
        Get
            Return _GENERATE_TASKS
        End Get
        Set(ByVal Value As Integer)
            _GENERATE_TASKS = Value
        End Set
    End Property
    <Category("Datos Generales"), TypeConverter(GetType(UserLine)), Description("Linea asignada al operador")> _
    Public Property Linea() As String
        Get
            Return _LINE_ID
        End Get
        Set(ByVal Value As String)
            _LINE_ID = Value
        End Set
    End Property


        <Category("Datos Generales"), TypeConverter(GetType(UserDomains)), Description("Dominio de aplicación")> _
    Public Property Dominio() As String
        Get
            Return _DOMAIN
        End Get
        Set(ByVal Value As String)
            _DOMAIN = Value
        End Set
    End Property

    <Category("Datos Generales"), TypeConverter(GetType(UserLinePosition)), Description("Posicion en la linea")> _
    Public Property PosicionEnLaLinea() As String
        Get
            Select Case _LINE_POSITION
                Case "FIRST"
                    Return "Principio"
                Case "LAST"
                    Return "Final"
                Case Else
                    Return "Intermedio"
            End Select
        End Get
        Set(ByVal Value As String)
            Select Case Value
                Case "Principio"
                    _LINE_POSITION = "FIRST"
                Case "Final"
                    _LINE_POSITION = "LAST"
                Case "FIRST"
                    _LINE_POSITION = "FIRST"
                Case "LAST"
                    _LINE_POSITION = "LAST"
                Case Else
                    _LINE_POSITION = ""
            End Select
        End Set
    End Property

    <Category("Datos Generales"), Description("Columna en la linea")> _
    Public Property Columna() As String
        Get
            Return _SPOT_COLUMN
        End Get
        Set(ByVal Value As String)
            _SPOT_COLUMN = Value
        End Set
    End Property

    <Category("Datos Generales"), Description("IP de la terminal en la linea a utilizar")> _
    Public Property Terminal() As String
        Get
            Return _TERMINAL_IP
        End Get
        Set(ByVal Value As String)
            _TERMINAL_IP = Value
        End Set
    End Property

    <Category("Grado de Acceso"), TypeConverter(GetType(WhereHouseEndabled)), Description("Bodegas habilitadas para el usuario")> _
    Public Property BodegasHabilitadas() As String
        Get
            Return _WAREHOUSE_ID
        End Get
        Set(ByVal Value As String)
            _WAREHOUSE_ID = Value
        End Set
    End Property

    <Category("Datos Generales"), Description("Correo electronico del usuario")> _
    Public Property EMAIL() As String
        Get
            Return _EMAIL
        End Get
        Set(ByVal Value As String)
            _EMAIL = Value
        End Set
    End Property

    <Category("Grado de Acceso"), TypeConverter(GetType(SioNo)), Description("Permite autorizar (1=SI / 0=NO)")> _
    Public Property Autorizador() As String
        Get
            Select Case _AUTHORIZER
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
                    _AUTHORIZER = "NO"
                Case "1"
                    _AUTHORIZER = "SI"
                Case "NO"
                    _AUTHORIZER = "NO"
                Case Else
                    _AUTHORIZER = "SI"
            End Select
        End Set
    End Property

    <Category("Grado de Acceso"), TypeConverter(GetType(SioNo)), Description("Se enviaran correos electrónicos sobre el procedimiento de las cartas de cupo.")> _
    Public Property NotificarCartaCupo() As String
        Get
            Select Case _NotifyLetterQuota
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
                    _NotifyLetterQuota = "NO"
                Case "1"
                    _NotifyLetterQuota = "SI"
                Case "NO"
                    _NotifyLetterQuota = "NO"
                Case Else
                    _NotifyLetterQuota = "SI"
            End Select
        End Set
    End Property

    <Category("Grado de Acceso"), TypeConverter(GetType(SioNo)), Description("Tiene permisos para realizar tareas de reubicación.")> _
    Public Property TareasReubicacion() As String
        Get
            Select Case _CAN_RELOCATE
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
                    _CAN_RELOCATE = "NO"
                Case "1"
                    _CAN_RELOCATE = "SI"
                Case "NO"
                    _CAN_RELOCATE = "NO"
                Case Else
                    _CAN_RELOCATE = "SI"
            End Select
        End Set
    End Property

    Public Function Grabar(ByRef pResult As String) As Boolean
        Dim pLocalResult As String = ""
        Try
            Dim xserv As New OnePlanServices_Security.WMS_SecuritySoapClient("WMS_SecuritySoap", PublicLoginInfo.WSHost + "/Catalogues/wms_security.asmx")
            xserv.SearchByKeyUserLogin(CodigoUsuario, pLocalResult, PublicLoginInfo.Environment)
            If pLocalResult = "OK" Then 'Update the record
                If xserv.UpdateUserLogin(CodigoUsuario, NivelAcceso, NombreUsuario, TipoUsuario, Estatus, Password,
                                        SerieDeLicencia, AmbienteTrabajo, InterfaseGrafica, TerminalConsolidacion,
                                        GeneraTareas, Linea, 0, BodegasHabilitadas, EMAIL,
                                        IIf(Autorizador.Equals("NO"), 0, 1), IIf(NotificarCartaCupo.Equals("NO"), 0, 1), IIf(TareasReubicacion.Equals("NO"), 0, 1),
                                        _LINE_POSITION,Columna,Terminal, Dominio.Split("-")(0) ,
                                        pLocalResult, PublicLoginInfo.Environment) Then
                    Return True
                Else
                    pResult = pLocalResult
                    Return False
                End If
            Else 'Add new record
                If xserv.CreateUserLogin(CodigoUsuario, NivelAcceso, NombreUsuario, TipoUsuario, Estatus, Password,
                                         SerieDeLicencia, AmbienteTrabajo, InterfaseGrafica, TerminalConsolidacion,
                                         Linea, GeneraTareas, 0, BodegasHabilitadas, EMAIL,
                                         IIf(Autorizador.Equals("NO"), 0, 1), IIf(NotificarCartaCupo.Equals("NO"), 0, 1), IIf(TareasReubicacion.Equals("NO"), 0, 1),
                                         _LINE_POSITION,Columna,Terminal,Dominio.Split("-")(0),
                                         pLocalResult, PublicLoginInfo.Environment) Then
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
            If xserv.DeleteUserLogin(CodigoUsuario, pLocalResult, PublicLoginInfo.Environment) Then
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
