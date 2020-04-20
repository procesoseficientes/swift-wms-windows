Imports System.ComponentModel

Public Class clsInfoDoc
    Public _DOC_DATE As Date
    Public _TRANSFERED_WMS_DATE As Date
    Public _CLIENT As String
    Public _SECTOR As String
    Public _ROUTE As String
    Public _STATUS As String
    Public _ASSIGNED_DATE As String
    Public _ASSIGNED_TO_LINE As String
    Public _ASSIGNED_BINS As String
    Public _CURRENT_PICKING_LOCATION As String
    Public _LAST_PICKING_DATE As Date
    Public _LAST_PICKING_LOCATION As String
    Public _LAST_PICKING_MATERIAL As String
    Public _CONSOLIDATION_TERMINAL As String
    Public _LAST_CONSOLIDATION_DATE As Date
    Public _TOTAL_BOXES As Integer


    <Category("1 Datos Generales"), [ReadOnly](True), Description("Fecha de Facturacion")> _
       Public Property FechaPedido() As Date
        Get
            Return _DOC_DATE
        End Get
        Set(ByVal Value As Date)
            _DOC_DATE = Value
        End Set
    End Property
    <Category("1 Datos Generales"), [ReadOnly](True), Description("Fecha de Traslado a WMS")> _
       Public Property TrasladadoHaciaWMS() As Date
        Get
            Return _TRANSFERED_WMS_DATE
        End Get
        Set(ByVal Value As Date)
            _TRANSFERED_WMS_DATE = Value
        End Set
    End Property
    <Category("1 Datos Generales"), [ReadOnly](True), Description("Cliente")> _
       Public Property Cliente() As String
        Get
            Return _CLIENT
        End Get
        Set(ByVal Value As String)
            _CLIENT = Value
        End Set
    End Property
    <Category("1 Datos Generales"), [ReadOnly](True), Description("Sector")> _
       Public Property Sector() As String
        Get
            Return _SECTOR
        End Get
        Set(ByVal Value As String)
            _SECTOR = Value
        End Set
    End Property
    <Category("1 Datos Generales"), [ReadOnly](True), Description("Ruta")> _
       Public Property Ruta() As String
        Get
            Return _ROUTE
        End Get
        Set(ByVal Value As String)
            _ROUTE = Value
        End Set
    End Property
    <Category("1 Datos Generales"), [ReadOnly](True), Description("Estado del Pedido")> _
       Public Property EstadoPedido() As String
        Get
            Return _STATUS
        End Get
        Set(ByVal Value As String)
            _STATUS = Value
        End Set
    End Property

    <Category("2 Información de Picking"), [ReadOnly](True), Description("Fecha de Asignación a Picking")> _
       Public Property FechaAsigacion() As Date
        Get
            Return _ASSIGNED_DATE
        End Get
        Set(ByVal Value As Date)
            _ASSIGNED_DATE = Value
        End Set
    End Property
    <Category("2 Información de Picking"), [ReadOnly](True), Description("Linea al que fue asignado el pedido")> _
       Public Property AsignadoALinea() As String
        Get
            Return _ASSIGNED_TO_LINE
        End Get
        Set(ByVal Value As String)
            _ASSIGNED_TO_LINE = Value
        End Set
    End Property
    <Category("2 Información de Picking"), [ReadOnly](True), Description("Bins asignados al pedido")> _
       Public Property BinsAsignados() As String
        Get
            Return _ASSIGNED_BINS
        End Get
        Set(ByVal Value As String)
            _ASSIGNED_BINS = Value
        End Set
    End Property
    <Category("2 Información de Picking"), [ReadOnly](True), Description("Ubicacion actual en Picking")> _
       Public Property UbicacionActualPicking() As String
        Get
            Return _CURRENT_PICKING_LOCATION
        End Get
        Set(ByVal Value As String)
            _CURRENT_PICKING_LOCATION = Value
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
    <Category("2 Información de Picking"), [ReadOnly](True), Description("Ultimo producto que fue Pickeado")> _
       Public Property UltimoProductoPicking() As String
        Get
            Return _LAST_PICKING_MATERIAL
        End Get
        Set(ByVal Value As String)
            _LAST_PICKING_MATERIAL = Value
        End Set
    End Property

    <Category("3 Información de Consolidación"), [ReadOnly](True), Description("Mesa en que fue (es) consolidado el pedido")> _
       Public Property ConsolidandoEnMesa() As String
        Get
            Return _CONSOLIDATION_TERMINAL
        End Get
        Set(ByVal Value As String)
            _CONSOLIDATION_TERMINAL = Value
        End Set
    End Property
    <Category("3 Información de Consolidación"), [ReadOnly](True), Description("Hora y Fecha de última consolidación")> _
       Public Property FechaUltimaConsolidacion() As Date
        Get
            Return _LAST_CONSOLIDATION_DATE
        End Get
        Set(ByVal Value As Date)
            _LAST_CONSOLIDATION_DATE = Value
        End Set
    End Property
    <Category("3 Información de Consolidación"), [ReadOnly](True), Description("Total de cajas consolidadas para el pedido")> _
       Public Property TotalCajas() As Integer
        Get
            Return _TOTAL_BOXES
        End Get
        Set(ByVal Value As Integer)
            _TOTAL_BOXES = Value
        End Set
    End Property

End Class
