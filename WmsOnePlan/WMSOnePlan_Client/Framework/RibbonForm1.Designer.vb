<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RibbonForm1
    Inherits DevExpress.XtraBars.Ribbon.RibbonForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RibbonForm1))
        Dim SuperToolTip1 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipItem1 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip2 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipItem2 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip3 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipItem3 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Me.UISplashScreenManager = New DevExpress.XtraSplashScreen.SplashScreenManager(Me, GetType(Global.WMSOnePlan_Client.WaitForm1), true, true)
        Me.RibbonPage_ALMACENAJE = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup_Recepcion = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.btnReciboDoc = New DevExpress.XtraBars.BarButtonItem()
        Me.btnIngresoGeneral = New DevExpress.XtraBars.BarButtonItem()
        Me.UiBotonIngresoERP = New DevExpress.XtraBars.BarButtonItem()
        Me.btnGarita = New DevExpress.XtraBars.BarButtonItem()
        Me.btnAprobacion = New DevExpress.XtraBars.BarButtonItem()
        Me.btnCostearGeneral = New DevExpress.XtraBars.BarButtonItem()
        Me.btnAutoQuotaLetter = New DevExpress.XtraBars.BarButtonItem()
        Me.btnAcuseRecibo = New DevExpress.XtraBars.BarButtonItem()
        Me.UiBotonCertificadoDeposito = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnIngresoExterno = New DevExpress.XtraBars.BarButtonItem()
        Me.UiBotonReporteIngresoF = New DevExpress.XtraBars.BarButtonItem()
        Me.UiBarButtonReporteDevoluciones = New DevExpress.XtraBars.BarButtonItem()
        Me.UiBotonSugeridoCompra = New DevExpress.XtraBars.BarButtonItem()
        Me.RibbonPageGroup_Despacho = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.btnPolizaEgreso = New DevExpress.XtraBars.BarButtonItem()
        Me.btnEgresoGeneral = New DevExpress.XtraBars.BarButtonItem()
        Me.btnGenerateWave = New DevExpress.XtraBars.BarButtonItem()
        Me.btnPase = New DevExpress.XtraBars.BarButtonItem()
        Me.BarBntOutInventory = New DevExpress.XtraBars.BarButtonItem()
        Me.UiBotonPaseSalidaCertificado = New DevExpress.XtraBars.BarButtonItem()
        Me.UiBotonReporteEgreso = New DevExpress.XtraBars.BarButtonItem()
        Me.UiBotonConsultaPaseDeSalida = New DevExpress.XtraBars.BarButtonItem()
        Me.RibbonPageGroup_inventario = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.btnInventarioDocumentos = New DevExpress.XtraBars.BarButtonItem()
        Me.btnReceptions = New DevExpress.XtraBars.BarButtonItem()
        Me.btnKardexFiscal = New DevExpress.XtraBars.BarButtonItem()
        Me.UiBotonRectificaciones = New DevExpress.XtraBars.BarButtonItem()
        Me.btnVencimientoDePolizas = New DevExpress.XtraBars.BarButtonItem()
        Me.RibbonPageGroupAudit = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.btnConsultaAuditsRec = New DevExpress.XtraBars.BarButtonItem()
        Me.btnServiciosAsociados = New DevExpress.XtraBars.BarButtonItem()
        Me.RibbonPage_Tarifario = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.btnTypeChange = New DevExpress.XtraBars.BarButtonItem()
        Me.btnAcuerdoComercial = New DevExpress.XtraBars.BarButtonItem()
        Me.btnAcuerdoCliente = New DevExpress.XtraBars.BarButtonItem()
        Me.UiBotonServiciosPorCobrar = New DevExpress.XtraBars.BarButtonItem()
        Me.UiBtnInventarioPorAcuerdoComercial = New DevExpress.XtraBars.BarButtonItem()
        Me.RibbonPage_BackOrder = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.UiBotonConsultaBackOrder = New DevExpress.XtraBars.BarButtonItem()
        Me.RibbonPage_Conteos = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.UiBotonAsignacionConteoFisico = New DevExpress.XtraBars.BarButtonItem()
        Me.UiBotonConsultaConteoFisico = New DevExpress.XtraBars.BarButtonItem()
        Me.RibbonPage_SolicitudTraslado = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.UiBotonSolicitudDeTraslado = New DevExpress.XtraBars.BarButtonItem()
        Me.UiBarButtonConsultaSolicitudDeTraslado = New DevExpress.XtraBars.BarButtonItem()
        Me.RibbonPage_BloqueoInventario = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.UiBotonBloqueoDeInventario = New DevExpress.XtraBars.BarButtonItem()
        Me.RibbonPage_InventarioComprometido = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.UiBotonInventarioComprometido = New DevExpress.XtraBars.BarButtonItem()
        Me.btnAutoSat = New DevExpress.XtraBars.BarButtonItem()
        Me.btnIngresoActurizacionSat = New DevExpress.XtraBars.BarButtonItem()
        Me.RibbonControl = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.ApplicationMenu1 = New DevExpress.XtraBars.Ribbon.ApplicationMenu(Me.components)
        Me.uiCerrarSesion = New DevExpress.XtraBars.BarButtonItem()
        Me.PanelCtrl_BarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem3 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem4 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem5 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem7 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem8 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem9 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarSubItem2 = New DevExpress.XtraBars.BarSubItem()
        Me.BarButtonItem10 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem12 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarStaticItem1 = New DevExpress.XtraBars.BarStaticItem()
        Me.BarButtonItem13 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem15 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem22 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem24 = New DevExpress.XtraBars.BarButtonItem()
        Me.Static_CustomerName = New DevExpress.XtraBars.BarStaticItem()
        Me.Static_Version = New DevExpress.XtraBars.BarStaticItem()
        Me.Static_Environment = New DevExpress.XtraBars.BarStaticItem()
        Me.BarStaticItem5 = New DevExpress.XtraBars.BarStaticItem()
        Me.BarButtonItem11 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarStaticItem6 = New DevExpress.XtraBars.BarStaticItem()
        Me.BarButtonLocations = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem29 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem30 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem26 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem27 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem32 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarLinkContainerItem1 = New DevExpress.XtraBars.BarLinkContainerItem()
        Me.BarButtonItem34 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem14 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem35 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem37 = New DevExpress.XtraBars.BarButtonItem()
        Me.btnMonitor_ConteoBultos = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem42 = New DevExpress.XtraBars.BarButtonItem()
        Me.Static_UserID = New DevExpress.XtraBars.BarStaticItem()
        Me.btnAparienciaCoffee = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem6 = New DevExpress.XtraBars.BarButtonItem()
        Me.btnCrearTareaCargaRuta = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        Me.Static_Message = New DevExpress.XtraBars.BarStaticItem()
        Me.BarStaticItem4 = New DevExpress.XtraBars.BarStaticItem()
        Me.btn_Transportistas = New DevExpress.XtraBars.BarButtonItem()
        Me.btnCrear_PlanRuta = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem16 = New DevExpress.XtraBars.BarButtonItem()
        Me.btnConsulta_Rutas = New DevExpress.XtraBars.BarButtonItem()
        Me.BarEditItem_Pedido = New DevExpress.XtraBars.BarEditItem()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.BarEditItem1 = New DevExpress.XtraBars.BarEditItem()
        Me.RepositoryItemTextEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.btnBinInfo = New DevExpress.XtraBars.BarButtonItem()
        Me.btnUpLoad_InitFile = New DevExpress.XtraBars.BarButtonItem()
        Me.BarSubItem3 = New DevExpress.XtraBars.BarSubItem()
        Me.BarButtonItem17 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem18 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem19 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem20 = New DevExpress.XtraBars.BarButtonItem()
        Me.btnSetupLabels = New DevExpress.XtraBars.BarButtonItem()
        Me.BarEditItem_GUI = New DevExpress.XtraBars.BarSubItem()
        Me.BarCheckItem1 = New DevExpress.XtraBars.BarCheckItem()
        Me.BarCheckItem2 = New DevExpress.XtraBars.BarCheckItem()
        Me.BarButtonItem21 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem23 = New DevExpress.XtraBars.BarButtonItem()
        Me.btnVehiculos = New DevExpress.XtraBars.BarButtonItem()
        Me.btnPilotos = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem_TrackingOperatorsByRoute = New DevExpress.XtraBars.BarButtonItem()
        Me.btnRouteGuide = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem_InvViews = New DevExpress.XtraBars.BarButtonItem()
        Me.btnConteos = New DevExpress.XtraBars.BarButtonItem()
        Me.btnOccupancy = New DevExpress.XtraBars.BarButtonItem()
        Me.btnInsuranceCompany = New DevExpress.XtraBars.BarButtonItem()
        Me.btnInsuranceDocs = New DevExpress.XtraBars.BarButtonItem()
        Me.btnCertificadoDeposito = New DevExpress.XtraBars.BarButtonItem()
        Me.btnSupervisions = New DevExpress.XtraBars.BarButtonItem()
        Me.btnRepCertificadoBono = New DevExpress.XtraBars.BarButtonItem()
        Me.btnRepPolizaSeguros = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem38 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem39 = New DevExpress.XtraBars.BarButtonItem()
        Me.btnVencimientoPolizas = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonGroup1 = New DevExpress.XtraBars.BarButtonGroup()
        Me.UiBotonDemandaDespacho = New DevExpress.XtraBars.BarButtonItem()
        Me.UiBotonMasterPack = New DevExpress.XtraBars.BarButtonItem()
        Me.UiBotonManifiestoDeCarga = New DevExpress.XtraBars.BarButtonItem()
        Me.UiBarButtonZonas = New DevExpress.XtraBars.BarButtonItem()
        Me.UiBotonConsultaCosteos = New DevExpress.XtraBars.BarButtonItem()
        Me.UiBotonBalanceDeSaldosFiscal = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem25 = New DevExpress.XtraBars.BarButtonItem()
        Me.UiBotonCatalogoClases = New DevExpress.XtraBars.BarButtonItem()
        Me.UiButtonTrazabilidadDeDemanda = New DevExpress.XtraBars.BarButtonItem()
        Me.UiBotonCatalogoEmpresasDeTransporte = New DevExpress.XtraBars.BarButtonItem()
        Me.UiBotonCatalogoDePiloto = New DevExpress.XtraBars.BarButtonItem()
        Me.UiBotonCatalogoVehiculo = New DevExpress.XtraBars.BarButtonItem()
        Me.UiBotonConsultaDeManifiesto = New DevExpress.XtraBars.BarButtonItem()
        Me.UiBotonConsultaDeLineaDePicking = New DevExpress.XtraBars.BarButtonItem()
        Me.UiBarButtonConsultaInventarioDiario = New DevExpress.XtraBars.BarButtonItem()
        Me.UiBotonPedidosPorRuta = New DevExpress.XtraBars.BarButtonItem()
        Me.UiBotonConsultaCumplimientoEntrega = New DevExpress.XtraBars.BarButtonItem()
        Me.UiBotonAdminitradorDeLineaDePicking = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonGroup2 = New DevExpress.XtraBars.BarButtonGroup()
        Me.botonConsultasPersonalizadas = New DevExpress.XtraBars.BarButtonItem()
        Me.UiBotonReportePicking = New DevExpress.XtraBars.BarButtonItem()
        Me.UiBontonInvnetarioInactivo = New DevExpress.XtraBars.BarButtonItem()
        Me.UiBotonIndicesDeBodega = New DevExpress.XtraBars.BarButtonItem()
        Me.UiBotonZonaPosicionamiento = New DevExpress.XtraBars.BarButtonItem()
        Me.RibbonMiniToolbar1 = New DevExpress.XtraBars.Ribbon.RibbonMiniToolbar(Me.components)
        Me.RibbonPageCategory1 = New DevExpress.XtraBars.Ribbon.RibbonPageCategory()
        Me.RibbonPageCategory2 = New DevExpress.XtraBars.Ribbon.RibbonPageCategory()
        Me.RibbonPage_BACKOFFICE = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup_TASKS = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup_CATALOGOS = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.grpInventarios = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.grpCertificadosBonos = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup3 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.UiGrupoPaginaNextTransporte = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.UiGrupoPaginaNextConsultasYTransacciones = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPage_CONFIG = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup_CONFIG = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup_SEGURIDAD = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup4 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.cmbSkinItems = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.RepositoryItemComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.RibbonStatusBar = New DevExpress.XtraBars.Ribbon.RibbonStatusBar()
        Me.BarButtonItem2 = New DevExpress.XtraBars.BarButtonItem()
        Me.XtraTabbedMdiManager1 = New DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(Me.components)
        Me.DefaultLookAndFeel1 = New DevExpress.LookAndFeel.DefaultLookAndFeel(Me.components)
        Me.BarButtonItem28 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarSubItem5 = New DevExpress.XtraBars.BarSubItem()
        Me.BarSubItem6 = New DevExpress.XtraBars.BarSubItem()
        Me.RibbonPageGroup6 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.BarStaticItem2 = New DevExpress.XtraBars.BarStaticItem()
        Me.RibbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup2 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.BarButtonItem36 = New DevExpress.XtraBars.BarButtonItem()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.btnMonitor_Consolidacion = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem31 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem41 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem43 = New DevExpress.XtraBars.BarButtonItem()
        Me.UiTimerVerifyLicense = New System.Windows.Forms.Timer(Me.components)
        CType(Me.RibbonControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ApplicationMenu1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbSkinItems, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabbedMdiManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UISplashScreenManager
        '
        Me.UISplashScreenManager.ClosingDelay = 1000
        '
        'RibbonPage_ALMACENAJE
        '
        Me.RibbonPage_ALMACENAJE.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup_Recepcion, Me.RibbonPageGroup_Despacho, Me.RibbonPageGroup_inventario, Me.RibbonPageGroupAudit, Me.RibbonPage_Tarifario, Me.RibbonPage_BackOrder, Me.RibbonPage_Conteos, Me.RibbonPage_SolicitudTraslado, Me.RibbonPage_BloqueoInventario, Me.RibbonPage_InventarioComprometido})
        Me.RibbonPage_ALMACENAJE.Name = "RibbonPage_ALMACENAJE"
        Me.RibbonPage_ALMACENAJE.Text = "Almacenadora"
        Me.RibbonPage_ALMACENAJE.Visible = False
        '
        'RibbonPageGroup_Recepcion
        '
        Me.RibbonPageGroup_Recepcion.ItemLinks.Add(Me.btnReciboDoc)
        Me.RibbonPageGroup_Recepcion.ItemLinks.Add(Me.btnIngresoGeneral)
        Me.RibbonPageGroup_Recepcion.ItemLinks.Add(Me.UiBotonIngresoERP)
        Me.RibbonPageGroup_Recepcion.ItemLinks.Add(Me.btnGarita)
        Me.RibbonPageGroup_Recepcion.ItemLinks.Add(Me.btnAprobacion)
        Me.RibbonPageGroup_Recepcion.ItemLinks.Add(Me.btnCostearGeneral)
        Me.RibbonPageGroup_Recepcion.ItemLinks.Add(Me.btnAutoQuotaLetter)
        Me.RibbonPageGroup_Recepcion.ItemLinks.Add(Me.btnAcuseRecibo)
        Me.RibbonPageGroup_Recepcion.ItemLinks.Add(Me.UiBotonCertificadoDeposito)
        Me.RibbonPageGroup_Recepcion.ItemLinks.Add(Me.BtnIngresoExterno)
        Me.RibbonPageGroup_Recepcion.ItemLinks.Add(Me.UiBotonReporteIngresoF)
        Me.RibbonPageGroup_Recepcion.ItemLinks.Add(Me.UiBarButtonReporteDevoluciones)
        Me.RibbonPageGroup_Recepcion.ItemLinks.Add(Me.UiBotonSugeridoCompra)
        Me.RibbonPageGroup_Recepcion.Name = "RibbonPageGroup_Recepcion"
        Me.RibbonPageGroup_Recepcion.Text = "Recepción"
        Me.RibbonPageGroup_Recepcion.Visible = False
        '
        'btnReciboDoc
        '
        Me.btnReciboDoc.Caption = "Ingreso Fiscal"
        Me.btnReciboDoc.Id = 140
        Me.btnReciboDoc.ImageOptions.Image = Global.WMSOnePlan_Client.My.Resources.Resources.MarkAsFinal_Large
        Me.btnReciboDoc.Name = "btnReciboDoc"
        Me.btnReciboDoc.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        Me.btnReciboDoc.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'btnIngresoGeneral
        '
        Me.btnIngresoGeneral.Caption = "Ingreso General"
        Me.btnIngresoGeneral.Id = 150
        Me.btnIngresoGeneral.ImageOptions.Image = Global.WMSOnePlan_Client.My.Resources.Resources.application_from_storage
        Me.btnIngresoGeneral.ImageOptions.LargeImage = Global.WMSOnePlan_Client.My.Resources.Resources.comp_bebox93
        Me.btnIngresoGeneral.Name = "btnIngresoGeneral"
        Me.btnIngresoGeneral.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'UiBotonIngresoERP
        '
        Me.UiBotonIngresoERP.Caption = "Ingreso ERP"
        Me.UiBotonIngresoERP.Id = 200
        Me.UiBotonIngresoERP.ImageOptions.Image = CType(resources.GetObject("UiBotonIngresoERP.ImageOptions.Image"), System.Drawing.Image)
        Me.UiBotonIngresoERP.ImageOptions.LargeImage = CType(resources.GetObject("UiBotonIngresoERP.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.UiBotonIngresoERP.Name = "UiBotonIngresoERP"
        Me.UiBotonIngresoERP.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'btnGarita
        '
        Me.btnGarita.Caption = "Garita"
        Me.btnGarita.Id = 142
        Me.btnGarita.ImageOptions.LargeImage = Global.WMSOnePlan_Client.My.Resources.Resources.transport139
        Me.btnGarita.Name = "btnGarita"
        Me.btnGarita.RibbonStyle = CType(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) _
            Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        Me.btnGarita.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'btnAprobacion
        '
        Me.btnAprobacion.Caption = "Aprobacion Fiscal"
        Me.btnAprobacion.Id = 143
        Me.btnAprobacion.ImageOptions.Image = Global.WMSOnePlan_Client.My.Resources.Resources.Prepare_Large
        Me.btnAprobacion.Name = "btnAprobacion"
        Me.btnAprobacion.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        Me.btnAprobacion.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'btnCostearGeneral
        '
        Me.btnCostearGeneral.Caption = "Costeo General"
        Me.btnCostearGeneral.Id = 154
        Me.btnCostearGeneral.ImageOptions.LargeImage = Global.WMSOnePlan_Client.My.Resources.Resources.calculator_edit
        Me.btnCostearGeneral.Name = "btnCostearGeneral"
        Me.btnCostearGeneral.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'btnAutoQuotaLetter
        '
        Me.btnAutoQuotaLetter.Caption = "Autorización Carta Cupo"
        Me.btnAutoQuotaLetter.Id = 184
        Me.btnAutoQuotaLetter.ImageOptions.LargeImage = Global.WMSOnePlan_Client.My.Resources.Resources.AddADigitalSignature_Large
        Me.btnAutoQuotaLetter.Name = "btnAutoQuotaLetter"
        Me.btnAutoQuotaLetter.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'btnAcuseRecibo
        '
        Me.btnAcuseRecibo.Caption = "Acuse Recibo"
        Me.btnAcuseRecibo.Id = 185
        Me.btnAcuseRecibo.ImageOptions.LargeImage = Global.WMSOnePlan_Client.My.Resources.Resources.comp_filetype105
        Me.btnAcuseRecibo.Name = "btnAcuseRecibo"
        Me.btnAcuseRecibo.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'UiBotonCertificadoDeposito
        '
        Me.UiBotonCertificadoDeposito.Caption = "Certificado De Deposito"
        Me.UiBotonCertificadoDeposito.Id = 187
        Me.UiBotonCertificadoDeposito.ImageOptions.Image = CType(resources.GetObject("UiBotonCertificadoDeposito.ImageOptions.Image"), System.Drawing.Image)
        Me.UiBotonCertificadoDeposito.ImageOptions.LargeImage = CType(resources.GetObject("UiBotonCertificadoDeposito.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.UiBotonCertificadoDeposito.Name = "UiBotonCertificadoDeposito"
        Me.UiBotonCertificadoDeposito.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'BtnIngresoExterno
        '
        Me.BtnIngresoExterno.Caption = "Ingreso Externo"
        Me.BtnIngresoExterno.Id = 194
        Me.BtnIngresoExterno.ImageOptions.Image = Global.WMSOnePlan_Client.My.Resources.Resources.balance_unbalance
        Me.BtnIngresoExterno.ImageOptions.LargeImage = Global.WMSOnePlan_Client.My.Resources.Resources.comp_bebox93
        Me.BtnIngresoExterno.Name = "BtnIngresoExterno"
        Me.BtnIngresoExterno.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'UiBotonReporteIngresoF
        '
        Me.UiBotonReporteIngresoF.Caption = "Reporte Ingreso"
        Me.UiBotonReporteIngresoF.Id = 192
        Me.UiBotonReporteIngresoF.ImageOptions.LargeImage = Global.WMSOnePlan_Client.My.Resources.Resources.edittask_32x32
        Me.UiBotonReporteIngresoF.Name = "UiBotonReporteIngresoF"
        Me.UiBotonReporteIngresoF.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        Me.UiBotonReporteIngresoF.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'UiBarButtonReporteDevoluciones
        '
        Me.UiBarButtonReporteDevoluciones.Caption = "Reporte de Devoluciones"
        Me.UiBarButtonReporteDevoluciones.Id = 341
        Me.UiBarButtonReporteDevoluciones.ImageOptions.Image = Global.WMSOnePlan_Client.My.Resources.Resources.return_report_32x32
        Me.UiBarButtonReporteDevoluciones.Name = "UiBarButtonReporteDevoluciones"
        Me.UiBarButtonReporteDevoluciones.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        Me.UiBarButtonReporteDevoluciones.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'UiBotonSugeridoCompra
        '
        Me.UiBotonSugeridoCompra.Id = 376
        Me.UiBotonSugeridoCompra.Name = "UiBotonSugeridoCompra"
        '
        'RibbonPageGroup_Despacho
        '
        Me.RibbonPageGroup_Despacho.ItemLinks.Add(Me.btnPolizaEgreso)
        Me.RibbonPageGroup_Despacho.ItemLinks.Add(Me.btnEgresoGeneral)
        Me.RibbonPageGroup_Despacho.ItemLinks.Add(Me.btnGenerateWave)
        Me.RibbonPageGroup_Despacho.ItemLinks.Add(Me.btnPase)
        Me.RibbonPageGroup_Despacho.ItemLinks.Add(Me.BarBntOutInventory)
        Me.RibbonPageGroup_Despacho.ItemLinks.Add(Me.UiBotonPaseSalidaCertificado)
        Me.RibbonPageGroup_Despacho.ItemLinks.Add(Me.UiBotonReporteEgreso)
        Me.RibbonPageGroup_Despacho.ItemLinks.Add(Me.UiBotonConsultaPaseDeSalida)
        Me.RibbonPageGroup_Despacho.Name = "RibbonPageGroup_Despacho"
        Me.RibbonPageGroup_Despacho.Text = "Despacho"
        Me.RibbonPageGroup_Despacho.Visible = False
        '
        'btnPolizaEgreso
        '
        Me.btnPolizaEgreso.Caption = "Poliza Egreso"
        Me.btnPolizaEgreso.Id = 145
        Me.btnPolizaEgreso.ImageOptions.LargeImage = Global.WMSOnePlan_Client.My.Resources.Resources.imageres_dll_187_18
        Me.btnPolizaEgreso.Name = "btnPolizaEgreso"
        Me.btnPolizaEgreso.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'btnEgresoGeneral
        '
        Me.btnEgresoGeneral.Caption = "Egreso General"
        Me.btnEgresoGeneral.Id = 152
        Me.btnEgresoGeneral.ImageOptions.LargeImage = Global.WMSOnePlan_Client.My.Resources.Resources.basket_go
        Me.btnEgresoGeneral.Name = "btnEgresoGeneral"
        Me.btnEgresoGeneral.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'btnGenerateWave
        '
        Me.btnGenerateWave.Caption = "Orden de Preparado"
        Me.btnGenerateWave.Id = 146
        Me.btnGenerateWave.ImageOptions.LargeImage = Global.WMSOnePlan_Client.My.Resources.Resources.about
        Me.btnGenerateWave.Name = "btnGenerateWave"
        Me.btnGenerateWave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'btnPase
        '
        Me.btnPase.Caption = "Pase de Sálida"
        Me.btnPase.Id = 149
        Me.btnPase.ImageOptions.LargeImage = Global.WMSOnePlan_Client.My.Resources.Resources.comp_beos012
        Me.btnPase.Name = "btnPase"
        Me.btnPase.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'BarBntOutInventory
        '
        Me.BarBntOutInventory.Caption = "Egreso Externo"
        Me.BarBntOutInventory.Id = 188
        Me.BarBntOutInventory.ImageOptions.Image = Global.WMSOnePlan_Client.My.Resources.Resources.basket_add
        Me.BarBntOutInventory.ImageOptions.LargeImage = Global.WMSOnePlan_Client.My.Resources.Resources.basket_go
        Me.BarBntOutInventory.Name = "BarBntOutInventory"
        Me.BarBntOutInventory.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'UiBotonPaseSalidaCertificado
        '
        Me.UiBotonPaseSalidaCertificado.Caption = "Pase de Salida"
        Me.UiBotonPaseSalidaCertificado.Id = 188
        Me.UiBotonPaseSalidaCertificado.ImageOptions.LargeImage = Global.WMSOnePlan_Client.My.Resources.Resources.comp_beos012
        Me.UiBotonPaseSalidaCertificado.Name = "UiBotonPaseSalidaCertificado"
        Me.UiBotonPaseSalidaCertificado.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'UiBotonReporteEgreso
        '
        Me.UiBotonReporteEgreso.Caption = "Reporte Egreso"
        Me.UiBotonReporteEgreso.Id = 191
        Me.UiBotonReporteEgreso.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.[False]
        Me.UiBotonReporteEgreso.ImageOptions.LargeImage = Global.WMSOnePlan_Client.My.Resources.Resources.edittask_32x32
        Me.UiBotonReporteEgreso.Name = "UiBotonReporteEgreso"
        Me.UiBotonReporteEgreso.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'UiBotonConsultaPaseDeSalida
        '
        Me.UiBotonConsultaPaseDeSalida.Caption = "Consulta Pase De Salida"
        Me.UiBotonConsultaPaseDeSalida.Id = 343
        Me.UiBotonConsultaPaseDeSalida.ImageOptions.Image = CType(resources.GetObject("UiBotonConsultaPaseDeSalida.ImageOptions.Image"), System.Drawing.Image)
        Me.UiBotonConsultaPaseDeSalida.ImageOptions.LargeImage = CType(resources.GetObject("UiBotonConsultaPaseDeSalida.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.UiBotonConsultaPaseDeSalida.Name = "UiBotonConsultaPaseDeSalida"
        '
        'RibbonPageGroup_inventario
        '
        Me.RibbonPageGroup_inventario.ItemLinks.Add(Me.btnInventarioDocumentos)
        Me.RibbonPageGroup_inventario.ItemLinks.Add(Me.btnReceptions)
        Me.RibbonPageGroup_inventario.ItemLinks.Add(Me.btnKardexFiscal)
        Me.RibbonPageGroup_inventario.ItemLinks.Add(Me.UiBotonRectificaciones)
        Me.RibbonPageGroup_inventario.ItemLinks.Add(Me.btnVencimientoDePolizas)
        Me.RibbonPageGroup_inventario.Name = "RibbonPageGroup_inventario"
        Me.RibbonPageGroup_inventario.Text = "Consulta de documentos"
        Me.RibbonPageGroup_inventario.Visible = False
        '
        'btnInventarioDocumentos
        '
        Me.btnInventarioDocumentos.Caption = "Inventario Por Documento"
        Me.btnInventarioDocumentos.Id = 144
        Me.btnInventarioDocumentos.ImageOptions.LargeImage = Global.WMSOnePlan_Client.My.Resources.Resources.nd0004_32
        Me.btnInventarioDocumentos.Name = "btnInventarioDocumentos"
        Me.btnInventarioDocumentos.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'btnReceptions
        '
        Me.btnReceptions.Caption = "Transacciones Por Documento"
        Me.btnReceptions.Id = 147
        Me.btnReceptions.ImageOptions.LargeImage = Global.WMSOnePlan_Client.My.Resources.Resources.application_side_list
        Me.btnReceptions.Name = "btnReceptions"
        Me.btnReceptions.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'btnKardexFiscal
        '
        Me.btnKardexFiscal.Caption = "Movimientos Fiscales"
        Me.btnKardexFiscal.Id = 153
        Me.btnKardexFiscal.ImageOptions.LargeImage = Global.WMSOnePlan_Client.My.Resources.Resources.Compare__Large
        Me.btnKardexFiscal.Name = "btnKardexFiscal"
        Me.btnKardexFiscal.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'UiBotonRectificaciones
        '
        Me.UiBotonRectificaciones.Caption = "Rectificaciones"
        Me.UiBotonRectificaciones.Id = 189
        Me.UiBotonRectificaciones.ImageOptions.Image = CType(resources.GetObject("UiBotonRectificaciones.ImageOptions.Image"), System.Drawing.Image)
        Me.UiBotonRectificaciones.ImageOptions.LargeImage = CType(resources.GetObject("UiBotonRectificaciones.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.UiBotonRectificaciones.Name = "UiBotonRectificaciones"
        Me.UiBotonRectificaciones.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'btnVencimientoDePolizas
        '
        Me.btnVencimientoDePolizas.Caption = "Vencimiento de Pólizas"
        Me.btnVencimientoDePolizas.Id = 297
        Me.btnVencimientoDePolizas.ImageOptions.Image = CType(resources.GetObject("btnVencimientoDePolizas.ImageOptions.Image"), System.Drawing.Image)
        Me.btnVencimientoDePolizas.ImageOptions.LargeImage = CType(resources.GetObject("btnVencimientoDePolizas.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.btnVencimientoDePolizas.Name = "btnVencimientoDePolizas"
        Me.btnVencimientoDePolizas.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'RibbonPageGroupAudit
        '
        Me.RibbonPageGroupAudit.ItemLinks.Add(Me.btnConsultaAuditsRec)
        Me.RibbonPageGroupAudit.ItemLinks.Add(Me.btnServiciosAsociados)
        Me.RibbonPageGroupAudit.Name = "RibbonPageGroupAudit"
        Me.RibbonPageGroupAudit.Text = "Auditorias"
        Me.RibbonPageGroupAudit.Visible = False
        '
        'btnConsultaAuditsRec
        '
        Me.btnConsultaAuditsRec.Caption = "Auditorias"
        Me.btnConsultaAuditsRec.Id = 148
        Me.btnConsultaAuditsRec.ImageOptions.Image = Global.WMSOnePlan_Client.My.Resources.Resources.Clipboard
        Me.btnConsultaAuditsRec.Name = "btnConsultaAuditsRec"
        Me.btnConsultaAuditsRec.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        Me.btnConsultaAuditsRec.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'btnServiciosAsociados
        '
        Me.btnServiciosAsociados.Caption = "Servicios Agregados"
        Me.btnServiciosAsociados.Id = 158
        Me.btnServiciosAsociados.ImageOptions.Image = Global.WMSOnePlan_Client.My.Resources.Resources.human127
        Me.btnServiciosAsociados.Name = "btnServiciosAsociados"
        Me.btnServiciosAsociados.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        Me.btnServiciosAsociados.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'RibbonPage_Tarifario
        '
        Me.RibbonPage_Tarifario.ItemLinks.Add(Me.btnTypeChange)
        Me.RibbonPage_Tarifario.ItemLinks.Add(Me.btnAcuerdoComercial)
        Me.RibbonPage_Tarifario.ItemLinks.Add(Me.btnAcuerdoCliente)
        Me.RibbonPage_Tarifario.ItemLinks.Add(Me.UiBotonServiciosPorCobrar)
        Me.RibbonPage_Tarifario.ItemLinks.Add(Me.UiBtnInventarioPorAcuerdoComercial)
        Me.RibbonPage_Tarifario.Name = "RibbonPage_Tarifario"
        Me.RibbonPage_Tarifario.Text = "Tarifario"
        Me.RibbonPage_Tarifario.Visible = False
        '
        'btnTypeChange
        '
        Me.btnTypeChange.Caption = "Tipos de Cobro"
        Me.btnTypeChange.Id = 181
        Me.btnTypeChange.ImageOptions.Image = Global.WMSOnePlan_Client.My.Resources.Resources.application_from_storage
        Me.btnTypeChange.Name = "btnTypeChange"
        Me.btnTypeChange.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        Me.btnTypeChange.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'btnAcuerdoComercial
        '
        Me.btnAcuerdoComercial.Caption = "Acuerdos Comerciales"
        Me.btnAcuerdoComercial.Id = 182
        Me.btnAcuerdoComercial.ImageOptions.Image = Global.WMSOnePlan_Client.My.Resources.Resources.Closed
        Me.btnAcuerdoComercial.Name = "btnAcuerdoComercial"
        Me.btnAcuerdoComercial.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        Me.btnAcuerdoComercial.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'btnAcuerdoCliente
        '
        Me.btnAcuerdoCliente.Caption = "Consulta Acuerdo Comercial por cliente"
        Me.btnAcuerdoCliente.Id = 183
        Me.btnAcuerdoCliente.ImageOptions.Image = Global.WMSOnePlan_Client.My.Resources.Resources.CascadeWindows
        Me.btnAcuerdoCliente.Name = "btnAcuerdoCliente"
        Me.btnAcuerdoCliente.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        Me.btnAcuerdoCliente.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'UiBotonServiciosPorCobrar
        '
        Me.UiBotonServiciosPorCobrar.Caption = "Servicios Por Cobrar"
        Me.UiBotonServiciosPorCobrar.Id = 196
        Me.UiBotonServiciosPorCobrar.ImageOptions.Image = CType(resources.GetObject("UiBotonServiciosPorCobrar.ImageOptions.Image"), System.Drawing.Image)
        Me.UiBotonServiciosPorCobrar.ImageOptions.LargeImage = CType(resources.GetObject("UiBotonServiciosPorCobrar.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.UiBotonServiciosPorCobrar.Name = "UiBotonServiciosPorCobrar"
        Me.UiBotonServiciosPorCobrar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'UiBtnInventarioPorAcuerdoComercial
        '
        Me.UiBtnInventarioPorAcuerdoComercial.Caption = "Inventario por Acuerdo Comercial"
        Me.UiBtnInventarioPorAcuerdoComercial.Id = 197
        Me.UiBtnInventarioPorAcuerdoComercial.ImageOptions.Image = CType(resources.GetObject("UiBtnInventarioPorAcuerdoComercial.ImageOptions.Image"), System.Drawing.Image)
        Me.UiBtnInventarioPorAcuerdoComercial.ImageOptions.LargeImage = CType(resources.GetObject("UiBtnInventarioPorAcuerdoComercial.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.UiBtnInventarioPorAcuerdoComercial.Name = "UiBtnInventarioPorAcuerdoComercial"
        Me.UiBtnInventarioPorAcuerdoComercial.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'RibbonPage_BackOrder
        '
        Me.RibbonPage_BackOrder.ItemLinks.Add(Me.UiBotonConsultaBackOrder)
        Me.RibbonPage_BackOrder.Name = "RibbonPage_BackOrder"
        Me.RibbonPage_BackOrder.Text = "Demanda Insatisfecha"
        Me.RibbonPage_BackOrder.Visible = False
        '
        'UiBotonConsultaBackOrder
        '
        Me.UiBotonConsultaBackOrder.Caption = "Consulta Demanda Insatisfecha"
        Me.UiBotonConsultaBackOrder.Id = 202
        Me.UiBotonConsultaBackOrder.ImageOptions.Image = CType(resources.GetObject("UiBotonConsultaBackOrder.ImageOptions.Image"), System.Drawing.Image)
        Me.UiBotonConsultaBackOrder.ImageOptions.LargeImage = CType(resources.GetObject("UiBotonConsultaBackOrder.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.UiBotonConsultaBackOrder.Name = "UiBotonConsultaBackOrder"
        Me.UiBotonConsultaBackOrder.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        Me.UiBotonConsultaBackOrder.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'RibbonPage_Conteos
        '
        Me.RibbonPage_Conteos.ItemLinks.Add(Me.UiBotonAsignacionConteoFisico)
        Me.RibbonPage_Conteos.ItemLinks.Add(Me.UiBotonConsultaConteoFisico)
        Me.RibbonPage_Conteos.Name = "RibbonPage_Conteos"
        Me.RibbonPage_Conteos.Text = "Conteos Fisicos"
        Me.RibbonPage_Conteos.Visible = False
        '
        'UiBotonAsignacionConteoFisico
        '
        Me.UiBotonAsignacionConteoFisico.Caption = "Asignación Tarea Conteo"
        Me.UiBotonAsignacionConteoFisico.Id = 232
        Me.UiBotonAsignacionConteoFisico.ImageOptions.Image = CType(resources.GetObject("UiBotonAsignacionConteoFisico.ImageOptions.Image"), System.Drawing.Image)
        Me.UiBotonAsignacionConteoFisico.ImageOptions.LargeImage = CType(resources.GetObject("UiBotonAsignacionConteoFisico.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.UiBotonAsignacionConteoFisico.Name = "UiBotonAsignacionConteoFisico"
        Me.UiBotonAsignacionConteoFisico.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'UiBotonConsultaConteoFisico
        '
        Me.UiBotonConsultaConteoFisico.Caption = "Consulta Conteo Fisico"
        Me.UiBotonConsultaConteoFisico.Id = 251
        Me.UiBotonConsultaConteoFisico.ImageOptions.Image = CType(resources.GetObject("UiBotonConsultaConteoFisico.ImageOptions.Image"), System.Drawing.Image)
        Me.UiBotonConsultaConteoFisico.ImageOptions.LargeImage = CType(resources.GetObject("UiBotonConsultaConteoFisico.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.UiBotonConsultaConteoFisico.Name = "UiBotonConsultaConteoFisico"
        Me.UiBotonConsultaConteoFisico.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        Me.UiBotonConsultaConteoFisico.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'RibbonPage_SolicitudTraslado
        '
        Me.RibbonPage_SolicitudTraslado.ItemLinks.Add(Me.UiBotonSolicitudDeTraslado)
        Me.RibbonPage_SolicitudTraslado.ItemLinks.Add(Me.UiBarButtonConsultaSolicitudDeTraslado)
        Me.RibbonPage_SolicitudTraslado.Name = "RibbonPage_SolicitudTraslado"
        Me.RibbonPage_SolicitudTraslado.Text = "Solicitud de Traslado"
        Me.RibbonPage_SolicitudTraslado.Visible = False
        '
        'UiBotonSolicitudDeTraslado
        '
        Me.UiBotonSolicitudDeTraslado.Caption = "Solicitud de Traslado"
        Me.UiBotonSolicitudDeTraslado.Id = 303
        Me.UiBotonSolicitudDeTraslado.ImageOptions.Image = CType(resources.GetObject("UiBotonSolicitudDeTraslado.ImageOptions.Image"), System.Drawing.Image)
        Me.UiBotonSolicitudDeTraslado.ImageOptions.LargeImage = CType(resources.GetObject("UiBotonSolicitudDeTraslado.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.UiBotonSolicitudDeTraslado.Name = "UiBotonSolicitudDeTraslado"
        Me.UiBotonSolicitudDeTraslado.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'UiBarButtonConsultaSolicitudDeTraslado
        '
        Me.UiBarButtonConsultaSolicitudDeTraslado.Caption = "Consulta de Solicitud de Traslado"
        Me.UiBarButtonConsultaSolicitudDeTraslado.Id = 315
        Me.UiBarButtonConsultaSolicitudDeTraslado.ImageOptions.Image = CType(resources.GetObject("UiBarButtonConsultaSolicitudDeTraslado.ImageOptions.Image"), System.Drawing.Image)
        Me.UiBarButtonConsultaSolicitudDeTraslado.ImageOptions.LargeImage = CType(resources.GetObject("UiBarButtonConsultaSolicitudDeTraslado.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.UiBarButtonConsultaSolicitudDeTraslado.Name = "UiBarButtonConsultaSolicitudDeTraslado"
        Me.UiBarButtonConsultaSolicitudDeTraslado.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        Me.UiBarButtonConsultaSolicitudDeTraslado.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'RibbonPage_BloqueoInventario
        '
        Me.RibbonPage_BloqueoInventario.ItemLinks.Add(Me.UiBotonBloqueoDeInventario)
        Me.RibbonPage_BloqueoInventario.Name = "RibbonPage_BloqueoInventario"
        Me.RibbonPage_BloqueoInventario.Text = "Bloqueo De Inventario"
        Me.RibbonPage_BloqueoInventario.Visible = False
        '
        'UiBotonBloqueoDeInventario
        '
        Me.UiBotonBloqueoDeInventario.Caption = "Bloqueo de Inventario"
        Me.UiBotonBloqueoDeInventario.Id = 324
        Me.UiBotonBloqueoDeInventario.ImageOptions.Image = CType(resources.GetObject("UiBotonBloqueoDeInventario.ImageOptions.Image"), System.Drawing.Image)
        Me.UiBotonBloqueoDeInventario.ImageOptions.LargeImage = CType(resources.GetObject("UiBotonBloqueoDeInventario.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.UiBotonBloqueoDeInventario.Name = "UiBotonBloqueoDeInventario"
        Me.UiBotonBloqueoDeInventario.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'RibbonPage_InventarioComprometido
        '
        Me.RibbonPage_InventarioComprometido.ItemLinks.Add(Me.UiBotonInventarioComprometido)
        Me.RibbonPage_InventarioComprometido.Name = "RibbonPage_InventarioComprometido"
        Me.RibbonPage_InventarioComprometido.Text = "Consulta de Inventario Preparado"
        Me.RibbonPage_InventarioComprometido.Visible = False
        '
        'UiBotonInventarioComprometido
        '
        Me.UiBotonInventarioComprometido.Caption = "Consulta Inventario Preparado"
        Me.UiBotonInventarioComprometido.Id = 346
        Me.UiBotonInventarioComprometido.ImageOptions.Image = CType(resources.GetObject("UiBotonInventarioComprometido.ImageOptions.Image"), System.Drawing.Image)
        Me.UiBotonInventarioComprometido.ImageOptions.LargeImage = CType(resources.GetObject("UiBotonInventarioComprometido.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.UiBotonInventarioComprometido.Name = "UiBotonInventarioComprometido"
        '
        'btnAutoSat
        '
        Me.btnAutoSat.Caption = "Autorizacion Sat"
        Me.btnAutoSat.Id = 141
        Me.btnAutoSat.ImageOptions.Image = Global.WMSOnePlan_Client.My.Resources.Resources.LogoSat
        Me.btnAutoSat.Name = "btnAutoSat"
        Me.btnAutoSat.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'btnIngresoActurizacionSat
        '
        Me.btnIngresoActurizacionSat.Caption = "Ingreso Autización Sat"
        Me.btnIngresoActurizacionSat.Id = 160
        Me.btnIngresoActurizacionSat.Name = "btnIngresoActurizacionSat"
        '
        'RibbonControl
        '
        Me.RibbonControl.ApplicationButtonDropDownControl = Me.ApplicationMenu1
        Me.RibbonControl.ApplicationButtonImageOptions.Image = Global.WMSOnePlan_Client.My.Resources.Resources.transmit_blue
        Me.RibbonControl.ApplicationButtonText = Nothing
        Me.RibbonControl.ExpandCollapseItem.Id = 0
        Me.RibbonControl.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl.ExpandCollapseItem, Me.RibbonControl.SearchEditItem, Me.PanelCtrl_BarButtonItem, Me.BarButtonItem3, Me.BarButtonItem4, Me.BarButtonItem5, Me.BarButtonItem7, Me.BarButtonItem8, Me.BarButtonItem9, Me.BarSubItem2, Me.BarButtonItem10, Me.BarButtonItem12, Me.BarStaticItem1, Me.BarButtonItem13, Me.BarButtonItem15, Me.BarButtonItem22, Me.BarButtonItem24, Me.Static_CustomerName, Me.Static_Version, Me.Static_Environment, Me.uiCerrarSesion, Me.BarStaticItem5, Me.BarButtonItem11, Me.BarStaticItem6, Me.BarButtonLocations, Me.BarButtonItem29, Me.BarButtonItem30, Me.BarButtonItem26, Me.BarButtonItem27, Me.BarButtonItem32, Me.BarLinkContainerItem1, Me.BarButtonItem34, Me.BarButtonItem14, Me.BarButtonItem35, Me.BarButtonItem37, Me.btnMonitor_ConteoBultos, Me.BarButtonItem42, Me.Static_UserID, Me.btnAparienciaCoffee, Me.BarButtonItem6, Me.btnCrearTareaCargaRuta, Me.BarButtonItem1, Me.Static_Message, Me.BarStaticItem4, Me.btn_Transportistas, Me.btnCrear_PlanRuta, Me.BarButtonItem16, Me.btnConsulta_Rutas, Me.BarEditItem_Pedido, Me.BarEditItem1, Me.btnBinInfo, Me.btnUpLoad_InitFile, Me.BarSubItem3, Me.BarButtonItem17, Me.BarButtonItem18, Me.BarButtonItem19, Me.BarButtonItem20, Me.btnSetupLabels, Me.BarEditItem_GUI, Me.BarCheckItem1, Me.BarCheckItem2, Me.BarButtonItem21, Me.BarButtonItem23, Me.btnVehiculos, Me.btnPilotos, Me.BarButtonItem_TrackingOperatorsByRoute, Me.btnRouteGuide, Me.btnReciboDoc, Me.btnAutoSat, Me.btnGarita, Me.btnAprobacion, Me.btnInventarioDocumentos, Me.btnPolizaEgreso, Me.btnGenerateWave, Me.btnReceptions, Me.btnConsultaAuditsRec, Me.btnPase, Me.btnIngresoGeneral, Me.btnEgresoGeneral, Me.btnKardexFiscal, Me.btnCostearGeneral, Me.BarButtonItem_InvViews, Me.btnConteos, Me.btnServiciosAsociados, Me.btnOccupancy, Me.btnIngresoActurizacionSat, Me.btnInsuranceCompany, Me.btnInsuranceDocs, Me.btnCertificadoDeposito, Me.btnSupervisions, Me.btnRepCertificadoBono, Me.btnRepPolizaSeguros, Me.BarButtonItem38, Me.BarButtonItem39, Me.btnTypeChange, Me.btnAcuerdoComercial, Me.btnAcuerdoCliente, Me.btnAutoQuotaLetter, Me.btnAcuseRecibo, Me.btnVencimientoPolizas, Me.UiBotonCertificadoDeposito, Me.UiBotonPaseSalidaCertificado, Me.UiBotonRectificaciones, Me.BarBntOutInventory, Me.BarButtonGroup1, Me.BtnIngresoExterno, Me.UiBotonReporteEgreso, Me.UiBotonReporteIngresoF, Me.UiBotonDemandaDespacho, Me.UiBotonServiciosPorCobrar, Me.UiBtnInventarioPorAcuerdoComercial, Me.UiBotonIngresoERP, Me.UiBotonMasterPack, Me.UiBotonConsultaBackOrder, Me.UiBotonManifiestoDeCarga, Me.UiBotonAsignacionConteoFisico, Me.UiBotonConsultaConteoFisico, Me.UiBarButtonZonas, Me.UiBotonConsultaCosteos, Me.UiBotonBalanceDeSaldosFiscal, Me.BarButtonItem25, Me.btnVencimientoDePolizas, Me.UiBotonSolicitudDeTraslado, Me.UiBarButtonConsultaSolicitudDeTraslado, Me.UiBotonCatalogoClases, Me.UiBotonBloqueoDeInventario, Me.UiButtonTrazabilidadDeDemanda, Me.UiBotonCatalogoEmpresasDeTransporte, Me.UiBotonCatalogoDePiloto, Me.UiBotonCatalogoVehiculo, Me.UiBotonConsultaDeManifiesto, Me.UiBotonConsultaDeLineaDePicking, Me.UiBarButtonConsultaInventarioDiario, Me.UiBotonPedidosPorRuta, Me.UiBotonConsultaCumplimientoEntrega, Me.UiBotonAdminitradorDeLineaDePicking, Me.UiBotonConsultaPaseDeSalida, Me.UiBarButtonReporteDevoluciones, Me.BarButtonGroup2, Me.UiBotonInventarioComprometido, Me.botonConsultasPersonalizadas, Me.UiBotonReportePicking, Me.UiBontonInvnetarioInactivo, Me.UiBotonIndicesDeBodega, Me.UiBotonZonaPosicionamiento, Me.UiBotonSugeridoCompra})
        Me.RibbonControl.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl.Margin = New System.Windows.Forms.Padding(10, 9, 10, 9)
        Me.RibbonControl.MaxItemId = 377
        Me.RibbonControl.MiniToolbars.Add(Me.RibbonMiniToolbar1)
        Me.RibbonControl.Name = "RibbonControl"
        Me.RibbonControl.PageCategories.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageCategory() {Me.RibbonPageCategory1, Me.RibbonPageCategory2})
        Me.RibbonControl.PageHeaderItemLinks.Add(Me.BarButtonItem37)
        Me.RibbonControl.PageHeaderItemLinks.Add(Me.BarButtonItem15)
        Me.RibbonControl.PageHeaderItemLinks.Add(Me.BarButtonItem14)
        Me.RibbonControl.PageHeaderItemLinks.Add(Me.btnMonitor_ConteoBultos)
        Me.RibbonControl.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.RibbonPage_BACKOFFICE, Me.RibbonPage_ALMACENAJE, Me.RibbonPage1, Me.RibbonPage_CONFIG})
        Me.RibbonControl.QuickToolbarItemLinks.Add(Me.BarButtonItem15)
        Me.RibbonControl.QuickToolbarItemLinks.Add(Me.BarButtonItem14)
        Me.RibbonControl.QuickToolbarItemLinks.Add(Me.uiCerrarSesion)
        Me.RibbonControl.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTextEdit1, Me.RepositoryItemTextEdit2, Me.cmbSkinItems, Me.RepositoryItemComboBox1})
        Me.RibbonControl.Size = New System.Drawing.Size(3861, 308)
        Me.RibbonControl.StatusBar = Me.RibbonStatusBar
        '
        'ApplicationMenu1
        '
        Me.ApplicationMenu1.ItemLinks.Add(Me.uiCerrarSesion)
        Me.ApplicationMenu1.Name = "ApplicationMenu1"
        Me.ApplicationMenu1.Ribbon = Me.RibbonControl
        '
        'uiCerrarSesion
        '
        Me.uiCerrarSesion.Caption = "Cerrar Sesion"
        Me.uiCerrarSesion.Id = 48
        Me.uiCerrarSesion.ImageOptions.Image = Global.WMSOnePlan_Client.My.Resources.Resources.door_out
        Me.uiCerrarSesion.Name = "uiCerrarSesion"
        Me.uiCerrarSesion.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'PanelCtrl_BarButtonItem
        '
        Me.PanelCtrl_BarButtonItem.Caption = "Parametros Generales"
        Me.PanelCtrl_BarButtonItem.Id = 11
        Me.PanelCtrl_BarButtonItem.ImageOptions.Image = Global.WMSOnePlan_Client.My.Resources.Resources.setting_tools
        Me.PanelCtrl_BarButtonItem.Name = "PanelCtrl_BarButtonItem"
        Me.PanelCtrl_BarButtonItem.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        Me.PanelCtrl_BarButtonItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'BarButtonItem3
        '
        Me.BarButtonItem3.Caption = "Operadores por Ubicacion"
        Me.BarButtonItem3.Id = 12
        Me.BarButtonItem3.ImageOptions.Image = Global.WMSOnePlan_Client.My.Resources.Resources.DisplayForReview_Small
        Me.BarButtonItem3.Name = "BarButtonItem3"
        '
        'BarButtonItem4
        '
        Me.BarButtonItem4.Caption = "Usuarios"
        Me.BarButtonItem4.Id = 15
        Me.BarButtonItem4.ImageOptions.Image = Global.WMSOnePlan_Client.My.Resources.Resources.group
        Me.BarButtonItem4.Name = "BarButtonItem4"
        Me.BarButtonItem4.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        Me.BarButtonItem4.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'BarButtonItem5
        '
        Me.BarButtonItem5.Caption = "Niveles de Acceso"
        Me.BarButtonItem5.Id = 16
        Me.BarButtonItem5.ImageOptions.Image = Global.WMSOnePlan_Client.My.Resources.Resources.group_key
        Me.BarButtonItem5.Name = "BarButtonItem5"
        Me.BarButtonItem5.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        Me.BarButtonItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'BarButtonItem7
        '
        Me.BarButtonItem7.Caption = "Ubicaciones fisicas"
        Me.BarButtonItem7.Id = 19
        Me.BarButtonItem7.Name = "BarButtonItem7"
        '
        'BarButtonItem8
        '
        Me.BarButtonItem8.Caption = "Productos"
        Me.BarButtonItem8.Id = 20
        Me.BarButtonItem8.Name = "BarButtonItem8"
        '
        'BarButtonItem9
        '
        Me.BarButtonItem9.Caption = "Rutas"
        Me.BarButtonItem9.Id = 21
        Me.BarButtonItem9.Name = "BarButtonItem9"
        '
        'BarSubItem2
        '
        Me.BarSubItem2.Caption = "Espacios fisicos"
        Me.BarSubItem2.Id = 22
        Me.BarSubItem2.ImageOptions.Image = Global.WMSOnePlan_Client.My.Resources.Resources.OpenSmall
        Me.BarSubItem2.Name = "BarSubItem2"
        '
        'BarButtonItem10
        '
        Me.BarButtonItem10.Caption = "Bodegas"
        Me.BarButtonItem10.Id = 23
        Me.BarButtonItem10.ImageOptions.Image = Global.WMSOnePlan_Client.My.Resources.Resources.TableSmall
        Me.BarButtonItem10.Name = "BarButtonItem10"
        '
        'BarButtonItem12
        '
        Me.BarButtonItem12.Caption = "Productos"
        Me.BarButtonItem12.Id = 25
        Me.BarButtonItem12.ImageOptions.Image = Global.WMSOnePlan_Client.My.Resources.Resources.Next_Small
        Me.BarButtonItem12.Name = "BarButtonItem12"
        '
        'BarStaticItem1
        '
        Me.BarStaticItem1.Caption = "Test"
        Me.BarStaticItem1.Id = 26
        Me.BarStaticItem1.Name = "BarStaticItem1"
        '
        'BarButtonItem13
        '
        Me.BarButtonItem13.Caption = "Rutas"
        Me.BarButtonItem13.Id = 27
        Me.BarButtonItem13.ImageOptions.Image = Global.WMSOnePlan_Client.My.Resources.Resources.ChangeListLevel_Small
        Me.BarButtonItem13.Name = "BarButtonItem13"
        '
        'BarButtonItem15
        '
        Me.BarButtonItem15.Caption = "Administrar Tareas"
        Me.BarButtonItem15.Id = 32
        Me.BarButtonItem15.ImageOptions.Image = Global.WMSOnePlan_Client.My.Resources.Resources.group_go
        Me.BarButtonItem15.ItemShortcut = New DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F9)
        Me.BarButtonItem15.Name = "BarButtonItem15"
        Me.BarButtonItem15.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        Me.BarButtonItem15.ShortcutKeyDisplayString = "(F9)"
        Me.BarButtonItem15.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'BarButtonItem22
        '
        Me.BarButtonItem22.Caption = "Etiquetas para Ubicaciones"
        Me.BarButtonItem22.Id = 41
        Me.BarButtonItem22.ImageOptions.Image = Global.WMSOnePlan_Client.My.Resources.Resources.PrintSmall
        Me.BarButtonItem22.Name = "BarButtonItem22"
        '
        'BarButtonItem24
        '
        Me.BarButtonItem24.Caption = "Etiquetas para Canastas"
        Me.BarButtonItem24.Id = 43
        Me.BarButtonItem24.ImageOptions.Image = Global.WMSOnePlan_Client.My.Resources.Resources.PrintSmall
        Me.BarButtonItem24.Name = "BarButtonItem24"
        '
        'Static_CustomerName
        '
        Me.Static_CustomerName.Caption = "Cosmetica Global"
        Me.Static_CustomerName.Id = 44
        Me.Static_CustomerName.ImageOptions.Image = Global.WMSOnePlan_Client.My.Resources.Resources.AddADigitalSignature_Large
        Me.Static_CustomerName.Name = "Static_CustomerName"
        Me.Static_CustomerName.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        Me.Static_CustomerName.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'Static_Version
        '
        Me.Static_Version.Caption = "Version: 2012-Q4-025"
        Me.Static_Version.Id = 45
        Me.Static_Version.ImageOptions.Image = Global.WMSOnePlan_Client.My.Resources.Resources.WordCount_Small
        Me.Static_Version.Name = "Static_Version"
        Me.Static_Version.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        '
        'Static_Environment
        '
        Me.Static_Environment.Caption = "Ambiente: PRODUCCION"
        Me.Static_Environment.Id = 46
        Me.Static_Environment.ImageOptions.Image = Global.WMSOnePlan_Client.My.Resources.Resources.database_go
        Me.Static_Environment.Name = "Static_Environment"
        Me.Static_Environment.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        '
        'BarStaticItem5
        '
        Me.BarStaticItem5.Caption = "Espacios fisicos"
        Me.BarStaticItem5.Id = 50
        Me.BarStaticItem5.Name = "BarStaticItem5"
        '
        'BarButtonItem11
        '
        Me.BarButtonItem11.Id = 52
        Me.BarButtonItem11.Name = "BarButtonItem11"
        '
        'BarStaticItem6
        '
        Me.BarStaticItem6.Caption = "-"
        Me.BarStaticItem6.Id = 53
        Me.BarStaticItem6.Name = "BarStaticItem6"
        '
        'BarButtonLocations
        '
        Me.BarButtonLocations.Caption = "Ubicaciones WMS"
        Me.BarButtonLocations.Id = 55
        Me.BarButtonLocations.ImageOptions.Image = Global.WMSOnePlan_Client.My.Resources.Resources.size_vertical
        Me.BarButtonLocations.Name = "BarButtonLocations"
        Me.BarButtonLocations.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        Me.BarButtonLocations.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'BarButtonItem29
        '
        Me.BarButtonItem29.Caption = "Catalogo Clientes"
        Me.BarButtonItem29.Id = 56
        Me.BarButtonItem29.ImageOptions.Image = Global.WMSOnePlan_Client.My.Resources.Resources.user_female
        Me.BarButtonItem29.Name = "BarButtonItem29"
        Me.BarButtonItem29.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        Me.BarButtonItem29.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'BarButtonItem30
        '
        Me.BarButtonItem30.Caption = "Catalogo Productos"
        Me.BarButtonItem30.Description = "Catalogo Productos"
        Me.BarButtonItem30.Id = 57
        Me.BarButtonItem30.ImageOptions.Image = Global.WMSOnePlan_Client.My.Resources.Resources.application_from_storage
        Me.BarButtonItem30.Name = "BarButtonItem30"
        Me.BarButtonItem30.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        Me.BarButtonItem30.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'BarButtonItem26
        '
        Me.BarButtonItem26.Caption = "Office 2007 - Negro"
        Me.BarButtonItem26.Id = 60
        Me.BarButtonItem26.ImageOptions.Image = Global.WMSOnePlan_Client.My.Resources.Resources.Cross_reference_Small
        Me.BarButtonItem26.Name = "BarButtonItem26"
        '
        'BarButtonItem27
        '
        Me.BarButtonItem27.Caption = "Office 2007 - Azul"
        Me.BarButtonItem27.Id = 61
        Me.BarButtonItem27.ImageOptions.Image = Global.WMSOnePlan_Client.My.Resources.Resources.Cross_reference_Small
        Me.BarButtonItem27.Name = "BarButtonItem27"
        '
        'BarButtonItem32
        '
        Me.BarButtonItem32.Caption = "OnePlan Default"
        Me.BarButtonItem32.Id = 63
        Me.BarButtonItem32.ImageOptions.Image = Global.WMSOnePlan_Client.My.Resources.Resources.Cross_reference_Small
        Me.BarButtonItem32.Name = "BarButtonItem32"
        '
        'BarLinkContainerItem1
        '
        Me.BarLinkContainerItem1.Caption = "Otros"
        Me.BarLinkContainerItem1.Id = 70
        Me.BarLinkContainerItem1.Name = "BarLinkContainerItem1"
        '
        'BarButtonItem34
        '
        Me.BarButtonItem34.Caption = "BarButtonItem34"
        Me.BarButtonItem34.Id = 71
        Me.BarButtonItem34.Name = "BarButtonItem34"
        '
        'BarButtonItem14
        '
        Me.BarButtonItem14.Caption = "Inventario en Linea"
        Me.BarButtonItem14.Description = "Inventario en Linea"
        Me.BarButtonItem14.Id = 72
        Me.BarButtonItem14.ImageOptions.Image = Global.WMSOnePlan_Client.My.Resources.Resources.table_tab_search
        Me.BarButtonItem14.Name = "BarButtonItem14"
        Me.BarButtonItem14.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        Me.BarButtonItem14.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'BarButtonItem35
        '
        Me.BarButtonItem35.Caption = "Inventario Consolidado"
        Me.BarButtonItem35.Id = 73
        Me.BarButtonItem35.ImageOptions.Image = Global.WMSOnePlan_Client.My.Resources.Resources.search_plus
        Me.BarButtonItem35.Name = "BarButtonItem35"
        Me.BarButtonItem35.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        Me.BarButtonItem35.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'BarButtonItem37
        '
        Me.BarButtonItem37.Caption = "Transacciones en Linea"
        Me.BarButtonItem37.Id = 75
        Me.BarButtonItem37.ImageOptions.Image = Global.WMSOnePlan_Client.My.Resources.Resources.transmit_go
        Me.BarButtonItem37.Name = "BarButtonItem37"
        Me.BarButtonItem37.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        Me.BarButtonItem37.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'btnMonitor_ConteoBultos
        '
        Me.btnMonitor_ConteoBultos.Caption = "Monitor de Picking"
        Me.btnMonitor_ConteoBultos.Id = 80
        Me.btnMonitor_ConteoBultos.ImageOptions.Image = Global.WMSOnePlan_Client.My.Resources.Resources.monitor_edit
        Me.btnMonitor_ConteoBultos.Name = "btnMonitor_ConteoBultos"
        Me.btnMonitor_ConteoBultos.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'BarButtonItem42
        '
        Me.BarButtonItem42.Caption = "Informacion Gerencial"
        Me.BarButtonItem42.Enabled = False
        Me.BarButtonItem42.Id = 81
        Me.BarButtonItem42.ImageOptions.Image = Global.WMSOnePlan_Client.My.Resources.Resources.charts66
        Me.BarButtonItem42.Name = "BarButtonItem42"
        Me.BarButtonItem42.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'Static_UserID
        '
        Me.Static_UserID.Caption = "..."
        Me.Static_UserID.Id = 84
        Me.Static_UserID.ImageOptions.Image = Global.WMSOnePlan_Client.My.Resources.Resources.user_green
        Me.Static_UserID.Name = "Static_UserID"
        Me.Static_UserID.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        '
        'btnAparienciaCoffee
        '
        Me.btnAparienciaCoffee.Caption = "OnePlan Coffee"
        Me.btnAparienciaCoffee.Id = 85
        Me.btnAparienciaCoffee.ImageOptions.Image = Global.WMSOnePlan_Client.My.Resources.Resources.Cross_reference_Small
        Me.btnAparienciaCoffee.Name = "btnAparienciaCoffee"
        '
        'BarButtonItem6
        '
        Me.BarButtonItem6.Caption = "Cambiar Mi Password"
        Me.BarButtonItem6.Id = 86
        Me.BarButtonItem6.ImageOptions.Image = Global.WMSOnePlan_Client.My.Resources.Resources.change_password
        Me.BarButtonItem6.Name = "BarButtonItem6"
        Me.BarButtonItem6.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'btnCrearTareaCargaRuta
        '
        Me.btnCrearTareaCargaRuta.Caption = "Tareas Carga A Ruta"
        Me.btnCrearTareaCargaRuta.Id = 91
        Me.btnCrearTareaCargaRuta.ImageOptions.Image = Global.WMSOnePlan_Client.My.Resources.Resources.transport107
        Me.btnCrearTareaCargaRuta.Name = "btnCrearTareaCargaRuta"
        Me.btnCrearTareaCargaRuta.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'BarButtonItem1
        '
        Me.BarButtonItem1.Caption = "BarButtonItem1"
        Me.BarButtonItem1.Id = 95
        Me.BarButtonItem1.Name = "BarButtonItem1"
        '
        'Static_Message
        '
        Me.Static_Message.AutoSize = DevExpress.XtraBars.BarStaticItemSize.Spring
        Me.Static_Message.Caption = "..."
        Me.Static_Message.Id = 96
        Me.Static_Message.ItemAppearance.Disabled.BackColor = System.Drawing.Color.DimGray
        Me.Static_Message.ItemAppearance.Disabled.Options.UseBackColor = True
        Me.Static_Message.ItemAppearance.Normal.BackColor = System.Drawing.Color.Transparent
        Me.Static_Message.ItemAppearance.Normal.ForeColor = System.Drawing.Color.Black
        Me.Static_Message.ItemAppearance.Normal.Options.UseBackColor = True
        Me.Static_Message.ItemAppearance.Normal.Options.UseBorderColor = True
        Me.Static_Message.ItemAppearance.Normal.Options.UseFont = True
        Me.Static_Message.ItemAppearance.Normal.Options.UseForeColor = True
        Me.Static_Message.Name = "Static_Message"
        Me.Static_Message.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'BarStaticItem4
        '
        Me.BarStaticItem4.Caption = "BarStaticItem4"
        Me.BarStaticItem4.Id = 97
        Me.BarStaticItem4.Name = "BarStaticItem4"
        '
        'btn_Transportistas
        '
        Me.btn_Transportistas.Caption = "Transportistas"
        Me.btn_Transportistas.Id = 108
        Me.btn_Transportistas.ImageOptions.Image = Global.WMSOnePlan_Client.My.Resources.Resources.road_sign
        Me.btn_Transportistas.Name = "btn_Transportistas"
        Me.btn_Transportistas.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'btnCrear_PlanRuta
        '
        Me.btnCrear_PlanRuta.Caption = "Crear Plan de Ruta"
        Me.btnCrear_PlanRuta.Id = 109
        Me.btnCrear_PlanRuta.ImageOptions.Image = Global.WMSOnePlan_Client.My.Resources.Resources.google_map
        Me.btnCrear_PlanRuta.Name = "btnCrear_PlanRuta"
        Me.btnCrear_PlanRuta.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'BarButtonItem16
        '
        Me.BarButtonItem16.Caption = "Trazabilidad Pedido"
        Me.BarButtonItem16.Id = 110
        Me.BarButtonItem16.ImageOptions.Image = Global.WMSOnePlan_Client.My.Resources.Resources.table_link
        Me.BarButtonItem16.Name = "BarButtonItem16"
        Me.BarButtonItem16.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu
        Me.BarButtonItem16.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'btnConsulta_Rutas
        '
        Me.btnConsulta_Rutas.Caption = "Transporte En Ruta"
        Me.btnConsulta_Rutas.Id = 111
        Me.btnConsulta_Rutas.ImageOptions.Image = Global.WMSOnePlan_Client.My.Resources.Resources.map_magnify
        Me.btnConsulta_Rutas.Name = "btnConsulta_Rutas"
        Me.btnConsulta_Rutas.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'BarEditItem_Pedido
        '
        Me.BarEditItem_Pedido.Caption = "Pedido:"
        Me.BarEditItem_Pedido.Edit = Me.RepositoryItemTextEdit1
        Me.BarEditItem_Pedido.EditValue = "0001"
        Me.BarEditItem_Pedido.EditWidth = 100
        Me.BarEditItem_Pedido.Id = 114
        Me.BarEditItem_Pedido.ImageOptions.Image = Global.WMSOnePlan_Client.My.Resources.Resources.ID_WINDOW_RESET_POSITION_SMALL
        Me.BarEditItem_Pedido.Name = "BarEditItem_Pedido"
        '
        'RepositoryItemTextEdit1
        '
        Me.RepositoryItemTextEdit1.AutoHeight = False
        Me.RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
        '
        'BarEditItem1
        '
        Me.BarEditItem1.Caption = "Docu#:"
        Me.BarEditItem1.Edit = Me.RepositoryItemTextEdit2
        Me.BarEditItem1.EditValue = "14000085"
        Me.BarEditItem1.EditWidth = 100
        Me.BarEditItem1.Id = 115
        Me.BarEditItem1.ImageOptions.Image = Global.WMSOnePlan_Client.My.Resources.Resources.Compare_Small
        Me.BarEditItem1.Name = "BarEditItem1"
        '
        'RepositoryItemTextEdit2
        '
        Me.RepositoryItemTextEdit2.AutoHeight = False
        Me.RepositoryItemTextEdit2.Name = "RepositoryItemTextEdit2"
        '
        'btnBinInfo
        '
        Me.btnBinInfo.Caption = "Informacion del BIN"
        Me.btnBinInfo.Id = 117
        Me.btnBinInfo.ImageOptions.Image = Global.WMSOnePlan_Client.My.Resources.Resources.basket_add
        Me.btnBinInfo.Name = "btnBinInfo"
        Me.btnBinInfo.RibbonStyle = CType(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) _
            Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'btnUpLoad_InitFile
        '
        Me.btnUpLoad_InitFile.Caption = "Cargar Excel de Inicializacion"
        Me.btnUpLoad_InitFile.Id = 118
        Me.btnUpLoad_InitFile.ImageOptions.Image = Global.WMSOnePlan_Client.My.Resources.Resources.ProcessExcelFile
        Me.btnUpLoad_InitFile.Name = "btnUpLoad_InitFile"
        Me.btnUpLoad_InitFile.RibbonStyle = CType(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) _
            Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'BarSubItem3
        '
        Me.BarSubItem3.Caption = "Extras"
        Me.BarSubItem3.Id = 119
        Me.BarSubItem3.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItem17), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItem18), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItem19), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItem20)})
        Me.BarSubItem3.Name = "BarSubItem3"
        '
        'BarButtonItem17
        '
        Me.BarButtonItem17.Caption = "1"
        Me.BarButtonItem17.Id = 120
        Me.BarButtonItem17.Name = "BarButtonItem17"
        '
        'BarButtonItem18
        '
        Me.BarButtonItem18.Caption = "2"
        Me.BarButtonItem18.Id = 121
        Me.BarButtonItem18.Name = "BarButtonItem18"
        '
        'BarButtonItem19
        '
        Me.BarButtonItem19.Caption = "3"
        Me.BarButtonItem19.Id = 122
        Me.BarButtonItem19.Name = "BarButtonItem19"
        '
        'BarButtonItem20
        '
        Me.BarButtonItem20.Caption = "4"
        Me.BarButtonItem20.Id = 123
        Me.BarButtonItem20.Name = "BarButtonItem20"
        '
        'btnSetupLabels
        '
        Me.btnSetupLabels.Caption = "Configurar Etiquetas"
        Me.btnSetupLabels.Id = 127
        Me.btnSetupLabels.ImageOptions.Image = Global.WMSOnePlan_Client.My.Resources.Resources.comp_printing103
        Me.btnSetupLabels.Name = "btnSetupLabels"
        Me.btnSetupLabels.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        ToolTipItem1.Text = "Configurar etiquetas y asignarles línea de consolidación"
        SuperToolTip1.Items.Add(ToolTipItem1)
        Me.btnSetupLabels.SuperTip = SuperToolTip1
        Me.btnSetupLabels.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'BarEditItem_GUI
        '
        Me.BarEditItem_GUI.Caption = "Cambiar apariencia del sistema"
        Me.BarEditItem_GUI.Id = 130
        Me.BarEditItem_GUI.ImageOptions.Image = Global.WMSOnePlan_Client.My.Resources.Resources.paintbrush
        Me.BarEditItem_GUI.Name = "BarEditItem_GUI"
        '
        'BarCheckItem1
        '
        Me.BarCheckItem1.BindableChecked = True
        Me.BarCheckItem1.Caption = "Blackroom"
        Me.BarCheckItem1.Checked = True
        Me.BarCheckItem1.Id = 131
        Me.BarCheckItem1.Name = "BarCheckItem1"
        '
        'BarCheckItem2
        '
        Me.BarCheckItem2.Caption = "Office 2007: Blue"
        Me.BarCheckItem2.Id = 132
        Me.BarCheckItem2.Name = "BarCheckItem2"
        '
        'BarButtonItem21
        '
        Me.BarButtonItem21.Caption = "test"
        Me.BarButtonItem21.Id = 133
        Me.BarButtonItem21.Name = "BarButtonItem21"
        '
        'BarButtonItem23
        '
        Me.BarButtonItem23.Caption = "test_btn"
        Me.BarButtonItem23.Id = 134
        Me.BarButtonItem23.Name = "BarButtonItem23"
        '
        'btnVehiculos
        '
        Me.btnVehiculos.Caption = "Vehiculos"
        Me.btnVehiculos.Id = 135
        Me.btnVehiculos.ImageOptions.Image = Global.WMSOnePlan_Client.My.Resources.Resources.travel_and_transportation
        Me.btnVehiculos.Name = "btnVehiculos"
        Me.btnVehiculos.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        ToolTipItem2.Text = "Mantenimiento a parque vehicular"
        SuperToolTip2.Items.Add(ToolTipItem2)
        Me.btnVehiculos.SuperTip = SuperToolTip2
        '
        'btnPilotos
        '
        Me.btnPilotos.Caption = "Pilotos"
        Me.btnPilotos.Id = 136
        Me.btnPilotos.ImageOptions.Image = Global.WMSOnePlan_Client.My.Resources.Resources.folder_user
        Me.btnPilotos.Name = "btnPilotos"
        Me.btnPilotos.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        ToolTipItem3.Text = "Mantenimiento de pilotos"
        SuperToolTip3.Items.Add(ToolTipItem3)
        Me.btnPilotos.SuperTip = SuperToolTip3
        '
        'BarButtonItem_TrackingOperatorsByRoute
        '
        Me.BarButtonItem_TrackingOperatorsByRoute.Caption = "Asignar seguimiento"
        Me.BarButtonItem_TrackingOperatorsByRoute.Id = 137
        Me.BarButtonItem_TrackingOperatorsByRoute.ImageOptions.Image = Global.WMSOnePlan_Client.My.Resources.Resources.group_go
        Me.BarButtonItem_TrackingOperatorsByRoute.Name = "BarButtonItem_TrackingOperatorsByRoute"
        Me.BarButtonItem_TrackingOperatorsByRoute.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'btnRouteGuide
        '
        Me.btnRouteGuide.Caption = "Distribución de Rutas / Puertas"
        Me.btnRouteGuide.Id = 139
        Me.btnRouteGuide.ImageOptions.Image = Global.WMSOnePlan_Client.My.Resources.Resources.arrow_divide
        Me.btnRouteGuide.Name = "btnRouteGuide"
        Me.btnRouteGuide.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'BarButtonItem_InvViews
        '
        Me.BarButtonItem_InvViews.Caption = "Vistas del Inventario"
        Me.BarButtonItem_InvViews.Description = "Vistas del Inventario"
        Me.BarButtonItem_InvViews.Id = 156
        Me.BarButtonItem_InvViews.ImageOptions.Image = Global.WMSOnePlan_Client.My.Resources.Resources.arrow_in
        Me.BarButtonItem_InvViews.Name = "BarButtonItem_InvViews"
        Me.BarButtonItem_InvViews.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        Me.BarButtonItem_InvViews.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'btnConteos
        '
        Me.btnConteos.Caption = "Conteos"
        Me.btnConteos.Id = 157
        Me.btnConteos.Name = "btnConteos"
        '
        'btnOccupancy
        '
        Me.btnOccupancy.Caption = "Niveles de ocupación"
        Me.btnOccupancy.Description = "Niveles de ocupación"
        Me.btnOccupancy.Id = 159
        Me.btnOccupancy.ImageOptions.Image = Global.WMSOnePlan_Client.My.Resources.Resources.estanteria_metalica
        Me.btnOccupancy.Name = "btnOccupancy"
        Me.btnOccupancy.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        Me.btnOccupancy.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'btnInsuranceCompany
        '
        Me.btnInsuranceCompany.Caption = "Aseguradoras"
        Me.btnInsuranceCompany.Id = 161
        Me.btnInsuranceCompany.ImageOptions.Image = CType(resources.GetObject("btnInsuranceCompany.ImageOptions.Image"), System.Drawing.Image)
        Me.btnInsuranceCompany.Name = "btnInsuranceCompany"
        Me.btnInsuranceCompany.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        Me.btnInsuranceCompany.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'btnInsuranceDocs
        '
        Me.btnInsuranceDocs.Caption = "Polizas de Seguro"
        Me.btnInsuranceDocs.Id = 162
        Me.btnInsuranceDocs.ImageOptions.Image = CType(resources.GetObject("btnInsuranceDocs.ImageOptions.Image"), System.Drawing.Image)
        Me.btnInsuranceDocs.Name = "btnInsuranceDocs"
        Me.btnInsuranceDocs.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        Me.btnInsuranceDocs.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'btnCertificadoDeposito
        '
        Me.btnCertificadoDeposito.Caption = "Certificado"
        Me.btnCertificadoDeposito.Id = 163
        Me.btnCertificadoDeposito.ImageOptions.LargeImage = CType(resources.GetObject("btnCertificadoDeposito.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.btnCertificadoDeposito.Name = "btnCertificadoDeposito"
        Me.btnCertificadoDeposito.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'btnSupervisions
        '
        Me.btnSupervisions.Caption = "Inspecciones"
        Me.btnSupervisions.Id = 164
        Me.btnSupervisions.ImageOptions.LargeImage = CType(resources.GetObject("btnSupervisions.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.btnSupervisions.Name = "btnSupervisions"
        Me.btnSupervisions.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'btnRepCertificadoBono
        '
        Me.btnRepCertificadoBono.Caption = "Reporte de Certificado con Bono"
        Me.btnRepCertificadoBono.Id = 169
        Me.btnRepCertificadoBono.ImageOptions.LargeImage = CType(resources.GetObject("btnRepCertificadoBono.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.btnRepCertificadoBono.Name = "btnRepCertificadoBono"
        Me.btnRepCertificadoBono.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'btnRepPolizaSeguros
        '
        Me.btnRepPolizaSeguros.Caption = "Reporte de Seguro"
        Me.btnRepPolizaSeguros.Id = 170
        Me.btnRepPolizaSeguros.ImageOptions.LargeImage = CType(resources.GetObject("btnRepPolizaSeguros.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.btnRepPolizaSeguros.Name = "btnRepPolizaSeguros"
        Me.btnRepPolizaSeguros.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'BarButtonItem38
        '
        Me.BarButtonItem38.Caption = "BarButtonItem38"
        Me.BarButtonItem38.Id = 171
        Me.BarButtonItem38.Name = "BarButtonItem38"
        '
        'BarButtonItem39
        '
        Me.BarButtonItem39.Caption = "BarButtonItem39"
        Me.BarButtonItem39.Id = 178
        Me.BarButtonItem39.Name = "BarButtonItem39"
        '
        'btnVencimientoPolizas
        '
        Me.btnVencimientoPolizas.Caption = "Vencimiento de Polizas Fiscal"
        Me.btnVencimientoPolizas.Id = 186
        Me.btnVencimientoPolizas.ImageOptions.Image = CType(resources.GetObject("btnVencimientoPolizas.ImageOptions.Image"), System.Drawing.Image)
        Me.btnVencimientoPolizas.ImageOptions.LargeImage = CType(resources.GetObject("btnVencimientoPolizas.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.btnVencimientoPolizas.Name = "btnVencimientoPolizas"
        Me.btnVencimientoPolizas.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'BarButtonGroup1
        '
        Me.BarButtonGroup1.Id = 190
        Me.BarButtonGroup1.Name = "BarButtonGroup1"
        '
        'UiBotonDemandaDespacho
        '
        Me.UiBotonDemandaDespacho.Caption = "Demanda de Despacho"
        Me.UiBotonDemandaDespacho.Id = 195
        Me.UiBotonDemandaDespacho.ImageOptions.Image = Global.WMSOnePlan_Client.My.Resources.Resources.comp_beos012
        Me.UiBotonDemandaDespacho.Name = "UiBotonDemandaDespacho"
        Me.UiBotonDemandaDespacho.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        Me.UiBotonDemandaDespacho.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'UiBotonMasterPack
        '
        Me.UiBotonMasterPack.Caption = "Master Pack"
        Me.UiBotonMasterPack.Id = 201
        Me.UiBotonMasterPack.ImageOptions.Image = CType(resources.GetObject("UiBotonMasterPack.ImageOptions.Image"), System.Drawing.Image)
        Me.UiBotonMasterPack.ImageOptions.LargeImage = CType(resources.GetObject("UiBotonMasterPack.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.UiBotonMasterPack.Name = "UiBotonMasterPack"
        Me.UiBotonMasterPack.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'UiBotonManifiestoDeCarga
        '
        Me.UiBotonManifiestoDeCarga.Caption = "Manifiesto de Carga"
        Me.UiBotonManifiestoDeCarga.Id = 202
        Me.UiBotonManifiestoDeCarga.ImageOptions.Image = Global.WMSOnePlan_Client.My.Resources.Resources.comp_recycle020
        Me.UiBotonManifiestoDeCarga.ImageOptions.LargeImage = Global.WMSOnePlan_Client.My.Resources.Resources.comp_recycle020
        Me.UiBotonManifiestoDeCarga.Name = "UiBotonManifiestoDeCarga"
        Me.UiBotonManifiestoDeCarga.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'UiBarButtonZonas
        '
        Me.UiBarButtonZonas.Caption = "Zonas WMS"
        Me.UiBarButtonZonas.Id = 286
        Me.UiBarButtonZonas.ImageOptions.Image = CType(resources.GetObject("UiBarButtonZonas.ImageOptions.Image"), System.Drawing.Image)
        Me.UiBarButtonZonas.Name = "UiBarButtonZonas"
        Me.UiBarButtonZonas.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        Me.UiBarButtonZonas.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'UiBotonConsultaCosteos
        '
        Me.UiBotonConsultaCosteos.Caption = "Consulta De Costeos"
        Me.UiBotonConsultaCosteos.Id = 294
        Me.UiBotonConsultaCosteos.ImageOptions.Image = CType(resources.GetObject("UiBotonConsultaCosteos.ImageOptions.Image"), System.Drawing.Image)
        Me.UiBotonConsultaCosteos.ImageOptions.LargeImage = CType(resources.GetObject("UiBotonConsultaCosteos.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.UiBotonConsultaCosteos.Name = "UiBotonConsultaCosteos"
        Me.UiBotonConsultaCosteos.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'UiBotonBalanceDeSaldosFiscal
        '
        Me.UiBotonBalanceDeSaldosFiscal.Caption = "Balance De Saldos Fiscal"
        Me.UiBotonBalanceDeSaldosFiscal.Id = 287
        Me.UiBotonBalanceDeSaldosFiscal.ImageOptions.Image = CType(resources.GetObject("UiBotonBalanceDeSaldosFiscal.ImageOptions.Image"), System.Drawing.Image)
        Me.UiBotonBalanceDeSaldosFiscal.ImageOptions.LargeImage = CType(resources.GetObject("UiBotonBalanceDeSaldosFiscal.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.UiBotonBalanceDeSaldosFiscal.Name = "UiBotonBalanceDeSaldosFiscal"
        Me.UiBotonBalanceDeSaldosFiscal.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'BarButtonItem25
        '
        Me.BarButtonItem25.Caption = "BarButtonItem25"
        Me.BarButtonItem25.Id = 296
        Me.BarButtonItem25.Name = "BarButtonItem25"
        '
        'UiBotonCatalogoClases
        '
        Me.UiBotonCatalogoClases.Caption = "Clases"
        Me.UiBotonCatalogoClases.Id = 317
        Me.UiBotonCatalogoClases.ImageOptions.Image = CType(resources.GetObject("UiBotonCatalogoClases.ImageOptions.Image"), System.Drawing.Image)
        Me.UiBotonCatalogoClases.ImageOptions.LargeImage = CType(resources.GetObject("UiBotonCatalogoClases.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.UiBotonCatalogoClases.Name = "UiBotonCatalogoClases"
        '
        'UiButtonTrazabilidadDeDemanda
        '
        Me.UiButtonTrazabilidadDeDemanda.Caption = "Cumplimiento de Demanda"
        Me.UiButtonTrazabilidadDeDemanda.Id = 325
        Me.UiButtonTrazabilidadDeDemanda.ImageOptions.Image = CType(resources.GetObject("UiButtonTrazabilidadDeDemanda.ImageOptions.Image"), System.Drawing.Image)
        Me.UiButtonTrazabilidadDeDemanda.ImageOptions.LargeImage = CType(resources.GetObject("UiButtonTrazabilidadDeDemanda.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.UiButtonTrazabilidadDeDemanda.Name = "UiButtonTrazabilidadDeDemanda"
        Me.UiButtonTrazabilidadDeDemanda.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'UiBotonCatalogoEmpresasDeTransporte
        '
        Me.UiBotonCatalogoEmpresasDeTransporte.Caption = "Empresas"
        Me.UiBotonCatalogoEmpresasDeTransporte.Id = 326
        Me.UiBotonCatalogoEmpresasDeTransporte.ImageOptions.Image = CType(resources.GetObject("UiBotonCatalogoEmpresasDeTransporte.ImageOptions.Image"), System.Drawing.Image)
        Me.UiBotonCatalogoEmpresasDeTransporte.ImageOptions.LargeImage = CType(resources.GetObject("UiBotonCatalogoEmpresasDeTransporte.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.UiBotonCatalogoEmpresasDeTransporte.Name = "UiBotonCatalogoEmpresasDeTransporte"
        Me.UiBotonCatalogoEmpresasDeTransporte.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'UiBotonCatalogoDePiloto
        '
        Me.UiBotonCatalogoDePiloto.Caption = "Pilotos"
        Me.UiBotonCatalogoDePiloto.Id = 327
        Me.UiBotonCatalogoDePiloto.ImageOptions.Image = CType(resources.GetObject("UiBotonCatalogoDePiloto.ImageOptions.Image"), System.Drawing.Image)
        Me.UiBotonCatalogoDePiloto.ImageOptions.LargeImage = CType(resources.GetObject("UiBotonCatalogoDePiloto.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.UiBotonCatalogoDePiloto.Name = "UiBotonCatalogoDePiloto"
        Me.UiBotonCatalogoDePiloto.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'UiBotonCatalogoVehiculo
        '
        Me.UiBotonCatalogoVehiculo.Caption = "Vehiculos"
        Me.UiBotonCatalogoVehiculo.Id = 328
        Me.UiBotonCatalogoVehiculo.ImageOptions.Image = CType(resources.GetObject("UiBotonCatalogoVehiculo.ImageOptions.Image"), System.Drawing.Image)
        Me.UiBotonCatalogoVehiculo.ImageOptions.LargeImage = CType(resources.GetObject("UiBotonCatalogoVehiculo.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.UiBotonCatalogoVehiculo.Name = "UiBotonCatalogoVehiculo"
        Me.UiBotonCatalogoVehiculo.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'UiBotonConsultaDeManifiesto
        '
        Me.UiBotonConsultaDeManifiesto.Caption = "Consulta Manifiestos"
        Me.UiBotonConsultaDeManifiesto.Id = 329
        Me.UiBotonConsultaDeManifiesto.ImageOptions.Image = CType(resources.GetObject("UiBotonConsultaDeManifiesto.ImageOptions.Image"), System.Drawing.Image)
        Me.UiBotonConsultaDeManifiesto.ImageOptions.LargeImage = CType(resources.GetObject("UiBotonConsultaDeManifiesto.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.UiBotonConsultaDeManifiesto.Name = "UiBotonConsultaDeManifiesto"
        Me.UiBotonConsultaDeManifiesto.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'UiBotonConsultaDeLineaDePicking
        '
        Me.UiBotonConsultaDeLineaDePicking.Caption = "Consulta de Línea de Picking"
        Me.UiBotonConsultaDeLineaDePicking.Id = 326
        Me.UiBotonConsultaDeLineaDePicking.ImageOptions.LargeImage = CType(resources.GetObject("UiBotonConsultaDeLineaDePicking.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.UiBotonConsultaDeLineaDePicking.Name = "UiBotonConsultaDeLineaDePicking"
        Me.UiBotonConsultaDeLineaDePicking.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'UiBarButtonConsultaInventarioDiario
        '
        Me.UiBarButtonConsultaInventarioDiario.Caption = "Consulta de Inventario Diario"
        Me.UiBarButtonConsultaInventarioDiario.Id = 331
        Me.UiBarButtonConsultaInventarioDiario.ImageOptions.Image = CType(resources.GetObject("UiBarButtonConsultaInventarioDiario.ImageOptions.Image"), System.Drawing.Image)
        Me.UiBarButtonConsultaInventarioDiario.ImageOptions.LargeImage = CType(resources.GetObject("UiBarButtonConsultaInventarioDiario.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.UiBarButtonConsultaInventarioDiario.Name = "UiBarButtonConsultaInventarioDiario"
        Me.UiBarButtonConsultaInventarioDiario.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        Me.UiBarButtonConsultaInventarioDiario.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'UiBotonPedidosPorRuta
        '
        Me.UiBotonPedidosPorRuta.Caption = "Pedidos por Vendedor"
        Me.UiBotonPedidosPorRuta.Id = 335
        Me.UiBotonPedidosPorRuta.ImageOptions.Image = CType(resources.GetObject("UiBotonPedidosPorRuta.ImageOptions.Image"), System.Drawing.Image)
        Me.UiBotonPedidosPorRuta.ImageOptions.LargeImage = CType(resources.GetObject("UiBotonPedidosPorRuta.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.UiBotonPedidosPorRuta.Name = "UiBotonPedidosPorRuta"
        Me.UiBotonPedidosPorRuta.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        Me.UiBotonPedidosPorRuta.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'UiBotonConsultaCumplimientoEntrega
        '
        Me.UiBotonConsultaCumplimientoEntrega.Caption = "Cumplimiento Entrega"
        Me.UiBotonConsultaCumplimientoEntrega.Id = 339
        Me.UiBotonConsultaCumplimientoEntrega.ImageOptions.Image = CType(resources.GetObject("UiBotonConsultaCumplimientoEntrega.ImageOptions.Image"), System.Drawing.Image)
        Me.UiBotonConsultaCumplimientoEntrega.ImageOptions.LargeImage = CType(resources.GetObject("UiBotonConsultaCumplimientoEntrega.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.UiBotonConsultaCumplimientoEntrega.Name = "UiBotonConsultaCumplimientoEntrega"
        '
        'UiBotonAdminitradorDeLineaDePicking
        '
        Me.UiBotonAdminitradorDeLineaDePicking.Caption = "Administrador de Línea de Picking"
        Me.UiBotonAdminitradorDeLineaDePicking.Id = 340
        Me.UiBotonAdminitradorDeLineaDePicking.ImageOptions.Image = CType(resources.GetObject("UiBotonAdminitradorDeLineaDePicking.ImageOptions.Image"), System.Drawing.Image)
        Me.UiBotonAdminitradorDeLineaDePicking.ImageOptions.LargeImage = CType(resources.GetObject("UiBotonAdminitradorDeLineaDePicking.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.UiBotonAdminitradorDeLineaDePicking.Name = "UiBotonAdminitradorDeLineaDePicking"
        Me.UiBotonAdminitradorDeLineaDePicking.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        Me.UiBotonAdminitradorDeLineaDePicking.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'BarButtonGroup2
        '
        Me.BarButtonGroup2.Caption = "BarButtonGroup2"
        Me.BarButtonGroup2.Id = 344
        Me.BarButtonGroup2.Name = "BarButtonGroup2"
        '
        'botonConsultasPersonalizadas
        '
        Me.botonConsultasPersonalizadas.Caption = "Consultas Personalizadas"
        Me.botonConsultasPersonalizadas.Id = 348
        Me.botonConsultasPersonalizadas.ImageOptions.Image = CType(resources.GetObject("botonConsultasPersonalizadas.ImageOptions.Image"), System.Drawing.Image)
        Me.botonConsultasPersonalizadas.Name = "botonConsultasPersonalizadas"
        Me.botonConsultasPersonalizadas.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'UiBotonReportePicking
        '
        Me.UiBotonReportePicking.Caption = "Reporte de Picking"
        Me.UiBotonReportePicking.Id = 349
        Me.UiBotonReportePicking.ImageOptions.Image = CType(resources.GetObject("UiBotonReportePicking.ImageOptions.Image"), System.Drawing.Image)
        Me.UiBotonReportePicking.Name = "UiBotonReportePicking"
        Me.UiBotonReportePicking.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        Me.UiBotonReportePicking.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'UiBontonInvnetarioInactivo
        '
        Me.UiBontonInvnetarioInactivo.Caption = "Inventario Inactivo"
        Me.UiBontonInvnetarioInactivo.Id = 372
        Me.UiBontonInvnetarioInactivo.ImageOptions.Image = CType(resources.GetObject("UiBontonInvnetarioInactivo.ImageOptions.Image"), System.Drawing.Image)
        Me.UiBontonInvnetarioInactivo.ImageOptions.LargeImage = CType(resources.GetObject("UiBontonInvnetarioInactivo.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.UiBontonInvnetarioInactivo.Name = "UiBontonInvnetarioInactivo"
        Me.UiBontonInvnetarioInactivo.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'UiBotonIndicesDeBodega
        '
        Me.UiBotonIndicesDeBodega.Caption = "Índices de Bodega"
        Me.UiBotonIndicesDeBodega.Id = 373
        Me.UiBotonIndicesDeBodega.ImageOptions.Image = CType(resources.GetObject("UiBotonIndicesDeBodega.ImageOptions.Image"), System.Drawing.Image)
        Me.UiBotonIndicesDeBodega.ImageOptions.LargeImage = CType(resources.GetObject("UiBotonIndicesDeBodega.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.UiBotonIndicesDeBodega.Name = "UiBotonIndicesDeBodega"
        Me.UiBotonIndicesDeBodega.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'UiBotonZonaPosicionamiento
        '
        Me.UiBotonZonaPosicionamiento.Caption = "Slotting"
        Me.UiBotonZonaPosicionamiento.Id = 374
        Me.UiBotonZonaPosicionamiento.ImageOptions.Image = CType(resources.GetObject("UiBotonZonaPosicionamiento.ImageOptions.Image"), System.Drawing.Image)
        Me.UiBotonZonaPosicionamiento.ImageOptions.LargeImage = CType(resources.GetObject("UiBotonZonaPosicionamiento.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.UiBotonZonaPosicionamiento.Name = "UiBotonZonaPosicionamiento"
        '
        'RibbonPageCategory1
        '
        Me.RibbonPageCategory1.Name = "RibbonPageCategory1"
        Me.RibbonPageCategory1.Text = "RibbonPageCategory1"
        '
        'RibbonPageCategory2
        '
        Me.RibbonPageCategory2.Name = "RibbonPageCategory2"
        Me.RibbonPageCategory2.Text = "RibbonPageCategory2"
        '
        'RibbonPage_BACKOFFICE
        '
        Me.RibbonPage_BACKOFFICE.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup_TASKS, Me.RibbonPageGroup_CATALOGOS, Me.grpInventarios, Me.grpCertificadosBonos})
        Me.RibbonPage_BACKOFFICE.Name = "RibbonPage_BACKOFFICE"
        Me.RibbonPage_BACKOFFICE.Text = "WMS"
        Me.RibbonPage_BACKOFFICE.Visible = False
        '
        'RibbonPageGroup_TASKS
        '
        Me.RibbonPageGroup_TASKS.ItemLinks.Add(Me.BarButtonItem15)
        Me.RibbonPageGroup_TASKS.ItemLinks.Add(Me.UiBotonAdminitradorDeLineaDePicking)
        Me.RibbonPageGroup_TASKS.ItemLinks.Add(Me.UiBotonReportePicking)
        Me.RibbonPageGroup_TASKS.Name = "RibbonPageGroup_TASKS"
        Me.RibbonPageGroup_TASKS.Text = "Manejo de Tareas"
        Me.RibbonPageGroup_TASKS.Visible = False
        '
        'RibbonPageGroup_CATALOGOS
        '
        Me.RibbonPageGroup_CATALOGOS.ItemLinks.Add(Me.BarButtonItem30, "CATALOGO PRODUCTOS")
        Me.RibbonPageGroup_CATALOGOS.ItemLinks.Add(Me.BarButtonItem29)
        Me.RibbonPageGroup_CATALOGOS.ItemLinks.Add(Me.BarButtonLocations)
        Me.RibbonPageGroup_CATALOGOS.ItemLinks.Add(Me.btnSetupLabels)
        Me.RibbonPageGroup_CATALOGOS.ItemLinks.Add(Me.UiBarButtonZonas)
        Me.RibbonPageGroup_CATALOGOS.ItemLinks.Add(Me.UiBotonCatalogoClases)
        Me.RibbonPageGroup_CATALOGOS.ItemLinks.Add(Me.UiBotonZonaPosicionamiento)
        Me.RibbonPageGroup_CATALOGOS.Name = "RibbonPageGroup_CATALOGOS"
        Me.RibbonPageGroup_CATALOGOS.Text = "Catalogos WMS"
        Me.RibbonPageGroup_CATALOGOS.Visible = False
        '
        'grpInventarios
        '
        Me.grpInventarios.ItemLinks.Add(Me.BarButtonItem14, "INVENTARIO EN LINEA")
        Me.grpInventarios.ItemLinks.Add(Me.BarButtonItem35)
        Me.grpInventarios.ItemLinks.Add(Me.BarButtonItem37)
        Me.grpInventarios.ItemLinks.Add(Me.BarButtonItem_InvViews)
        Me.grpInventarios.ItemLinks.Add(Me.btnOccupancy)
        Me.grpInventarios.ItemLinks.Add(Me.UiBotonMasterPack)
        Me.grpInventarios.ItemLinks.Add(Me.UiBotonBalanceDeSaldosFiscal)
        Me.grpInventarios.ItemLinks.Add(Me.UiBotonConsultaCosteos)
        Me.grpInventarios.ItemLinks.Add(Me.UiBarButtonConsultaInventarioDiario)
        Me.grpInventarios.ItemLinks.Add(Me.botonConsultasPersonalizadas)
        Me.grpInventarios.ItemLinks.Add(Me.UiBontonInvnetarioInactivo)
        Me.grpInventarios.ItemLinks.Add(Me.UiBotonIndicesDeBodega)
        Me.grpInventarios.Name = "grpInventarios"
        Me.grpInventarios.Text = "Inventarios y Transacciones"
        Me.grpInventarios.Visible = False
        '
        'grpCertificadosBonos
        '
        Me.grpCertificadosBonos.ItemLinks.Add(Me.btnInsuranceCompany)
        Me.grpCertificadosBonos.ItemLinks.Add(Me.btnInsuranceDocs)
        Me.grpCertificadosBonos.ItemLinks.Add(Me.btnSupervisions)
        Me.grpCertificadosBonos.ItemLinks.Add(Me.btnCertificadoDeposito)
        Me.grpCertificadosBonos.ItemLinks.Add(Me.btnRepCertificadoBono)
        Me.grpCertificadosBonos.ItemLinks.Add(Me.btnRepPolizaSeguros)
        Me.grpCertificadosBonos.ItemLinks.Add(Me.btnVencimientoPolizas)
        Me.grpCertificadosBonos.Name = "grpCertificadosBonos"
        Me.grpCertificadosBonos.Text = "Certificados y Bonos"
        Me.grpCertificadosBonos.Visible = False
        '
        'RibbonPage1
        '
        Me.RibbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup3, Me.UiGrupoPaginaNextTransporte, Me.UiGrupoPaginaNextConsultasYTransacciones})
        Me.RibbonPage1.Name = "RibbonPage1"
        Me.RibbonPage1.Text = "NEXT"
        Me.RibbonPage1.Visible = False
        '
        'RibbonPageGroup3
        '
        Me.RibbonPageGroup3.ItemLinks.Add(Me.UiBotonDemandaDespacho)
        Me.RibbonPageGroup3.ItemLinks.Add(Me.UiBotonManifiestoDeCarga)
        Me.RibbonPageGroup3.ItemLinks.Add(Me.UiButtonTrazabilidadDeDemanda)
        Me.RibbonPageGroup3.ItemLinks.Add(Me.UiBotonConsultaDeLineaDePicking)
        Me.RibbonPageGroup3.ItemLinks.Add(Me.UiBotonConsultaDeManifiesto)
        Me.RibbonPageGroup3.Name = "RibbonPageGroup3"
        Me.RibbonPageGroup3.Text = "Movimientos"
        Me.RibbonPageGroup3.Visible = False
        '
        'UiGrupoPaginaNextTransporte
        '
        Me.UiGrupoPaginaNextTransporte.ItemLinks.Add(Me.UiBotonCatalogoEmpresasDeTransporte)
        Me.UiGrupoPaginaNextTransporte.ItemLinks.Add(Me.UiBotonCatalogoDePiloto)
        Me.UiGrupoPaginaNextTransporte.ItemLinks.Add(Me.UiBotonCatalogoVehiculo)
        Me.UiGrupoPaginaNextTransporte.Name = "UiGrupoPaginaNextTransporte"
        Me.UiGrupoPaginaNextTransporte.Text = "Transporte"
        Me.UiGrupoPaginaNextTransporte.Visible = False
        '
        'UiGrupoPaginaNextConsultasYTransacciones
        '
        Me.UiGrupoPaginaNextConsultasYTransacciones.AllowTextClipping = False
        Me.UiGrupoPaginaNextConsultasYTransacciones.ItemLinks.Add(Me.UiBotonPedidosPorRuta)
        Me.UiGrupoPaginaNextConsultasYTransacciones.ItemLinks.Add(Me.UiBotonConsultaCumplimientoEntrega)
        Me.UiGrupoPaginaNextConsultasYTransacciones.Name = "UiGrupoPaginaNextConsultasYTransacciones"
        Me.UiGrupoPaginaNextConsultasYTransacciones.Text = "Consultas y Transacciones"
        Me.UiGrupoPaginaNextConsultasYTransacciones.Visible = False
        '
        'RibbonPage_CONFIG
        '
        Me.RibbonPage_CONFIG.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup_CONFIG, Me.RibbonPageGroup_SEGURIDAD, Me.RibbonPageGroup4})
        Me.RibbonPage_CONFIG.Name = "RibbonPage_CONFIG"
        Me.RibbonPage_CONFIG.Text = "CONFIG"
        '
        'RibbonPageGroup_CONFIG
        '
        Me.RibbonPageGroup_CONFIG.ItemLinks.Add(Me.PanelCtrl_BarButtonItem)
        Me.RibbonPageGroup_CONFIG.ItemLinks.Add(Me.BarEditItem_GUI)
        Me.RibbonPageGroup_CONFIG.Name = "RibbonPageGroup_CONFIG"
        Me.RibbonPageGroup_CONFIG.Text = "Configuraciones"
        Me.RibbonPageGroup_CONFIG.Visible = False
        '
        'RibbonPageGroup_SEGURIDAD
        '
        Me.RibbonPageGroup_SEGURIDAD.ItemLinks.Add(Me.BarButtonItem4)
        Me.RibbonPageGroup_SEGURIDAD.ItemLinks.Add(Me.BarButtonItem5)
        Me.RibbonPageGroup_SEGURIDAD.Name = "RibbonPageGroup_SEGURIDAD"
        Me.RibbonPageGroup_SEGURIDAD.Text = "Seguridad"
        Me.RibbonPageGroup_SEGURIDAD.Visible = False
        '
        'RibbonPageGroup4
        '
        Me.RibbonPageGroup4.ItemLinks.Add(Me.Static_CustomerName)
        Me.RibbonPageGroup4.ItemLinks.Add(Me.Static_Version)
        Me.RibbonPageGroup4.ItemLinks.Add(Me.Static_Environment)
        Me.RibbonPageGroup4.ItemLinks.Add(Me.Static_UserID)
        Me.RibbonPageGroup4.ItemLinks.Add(Me.uiCerrarSesion)
        Me.RibbonPageGroup4.ItemLinks.Add(Me.BarButtonItem6)
        Me.RibbonPageGroup4.Name = "RibbonPageGroup4"
        Me.RibbonPageGroup4.Text = "Acerca de..."
        '
        'cmbSkinItems
        '
        Me.cmbSkinItems.AutoHeight = False
        Me.cmbSkinItems.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.DropDown)})
        Me.cmbSkinItems.HideSelection = False
        Me.cmbSkinItems.Name = "cmbSkinItems"
        '
        'RepositoryItemComboBox1
        '
        Me.RepositoryItemComboBox1.AutoHeight = False
        Me.RepositoryItemComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemComboBox1.Name = "RepositoryItemComboBox1"
        '
        'RibbonStatusBar
        '
        Me.RibbonStatusBar.ItemLinks.Add(Me.Static_Version)
        Me.RibbonStatusBar.ItemLinks.Add(Me.Static_Environment)
        Me.RibbonStatusBar.ItemLinks.Add(Me.Static_Message)
        Me.RibbonStatusBar.Location = New System.Drawing.Point(0, 1288)
        Me.RibbonStatusBar.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.RibbonStatusBar.Name = "RibbonStatusBar"
        Me.RibbonStatusBar.Ribbon = Me.RibbonControl
        Me.RibbonStatusBar.Size = New System.Drawing.Size(3861, 48)
        '
        'BarButtonItem2
        '
        Me.BarButtonItem2.Caption = "Crear Ola de Picking"
        Me.BarButtonItem2.Id = 0
        Me.BarButtonItem2.ImageOptions.Image = Global.WMSOnePlan_Client.My.Resources.Resources.comp_beos012
        Me.BarButtonItem2.Name = "BarButtonItem2"
        Me.BarButtonItem2.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'XtraTabbedMdiManager1
        '
        Me.XtraTabbedMdiManager1.MdiParent = Me
        '
        'BarButtonItem28
        '
        Me.BarButtonItem28.Caption = "Consolidar Picking"
        Me.BarButtonItem28.Id = 8
        Me.BarButtonItem28.ImageOptions.Image = Global.WMSOnePlan_Client.My.Resources.Resources.comp_recycle020
        Me.BarButtonItem28.Name = "BarButtonItem28"
        Me.BarButtonItem28.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'BarSubItem5
        '
        Me.BarSubItem5.Caption = "Consulta Inventario"
        Me.BarSubItem5.Id = 30
        Me.BarSubItem5.ImageOptions.Image = Global.WMSOnePlan_Client.My.Resources.Resources.CascadeWindows
        Me.BarSubItem5.Name = "BarSubItem5"
        Me.BarSubItem5.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'BarSubItem6
        '
        Me.BarSubItem6.Caption = "Consulta Inventario"
        Me.BarSubItem6.Id = 30
        Me.BarSubItem6.ImageOptions.Image = Global.WMSOnePlan_Client.My.Resources.Resources.CascadeWindows
        Me.BarSubItem6.Name = "BarSubItem6"
        Me.BarSubItem6.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'RibbonPageGroup6
        '
        Me.RibbonPageGroup6.Name = "RibbonPageGroup6"
        Me.RibbonPageGroup6.Text = "Settings"
        '
        'BarStaticItem2
        '
        Me.BarStaticItem2.Caption = "..."
        Me.BarStaticItem2.Id = 84
        Me.BarStaticItem2.ImageOptions.Image = Global.WMSOnePlan_Client.My.Resources.Resources.small_user
        Me.BarStaticItem2.Name = "BarStaticItem2"
        Me.BarStaticItem2.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        '
        'RibbonPageGroup1
        '
        Me.RibbonPageGroup1.ItemLinks.Add(Me.btnMonitor_ConteoBultos)
        Me.RibbonPageGroup1.Name = "RibbonPageGroup1"
        Me.RibbonPageGroup1.Text = "Monitores en Linea"
        '
        'RibbonPageGroup2
        '
        Me.RibbonPageGroup2.ItemLinks.Add(Me.BarButtonItem42)
        Me.RibbonPageGroup2.Name = "RibbonPageGroup2"
        Me.RibbonPageGroup2.Text = "Informacion Gerencial"
        '
        'BarButtonItem36
        '
        Me.BarButtonItem36.Caption = "WMS Vrs. SAP B1"
        Me.BarButtonItem36.Enabled = False
        Me.BarButtonItem36.Id = 74
        Me.BarButtonItem36.ImageOptions.Image = Global.WMSOnePlan_Client.My.Resources.Resources.sap_Logo
        Me.BarButtonItem36.Name = "BarButtonItem36"
        Me.BarButtonItem36.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 60000
        '
        'btnMonitor_Consolidacion
        '
        Me.btnMonitor_Consolidacion.Caption = "Monitor Consolidacion"
        Me.btnMonitor_Consolidacion.Id = 103
        Me.btnMonitor_Consolidacion.ImageOptions.Image = Global.WMSOnePlan_Client.My.Resources.Resources.monitor_window_3d
        Me.btnMonitor_Consolidacion.Name = "btnMonitor_Consolidacion"
        Me.btnMonitor_Consolidacion.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'BarButtonItem31
        '
        Me.BarButtonItem31.Caption = "Auditoria Recepción"
        Me.BarButtonItem31.Id = 148
        Me.BarButtonItem31.ImageOptions.Image = Global.WMSOnePlan_Client.My.Resources.Resources.AddADigitalSignature_Large
        Me.BarButtonItem31.Name = "BarButtonItem31"
        Me.BarButtonItem31.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'BarButtonItem41
        '
        Me.BarButtonItem41.Name = "BarButtonItem41"
        '
        'BarButtonItem43
        '
        Me.BarButtonItem43.Caption = "Reporte Egreso"
        Me.BarButtonItem43.Id = 191
        Me.BarButtonItem43.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.[False]
        Me.BarButtonItem43.ImageOptions.LargeImage = Global.WMSOnePlan_Client.My.Resources.Resources.edittask_32x32
        Me.BarButtonItem43.Name = "BarButtonItem43"
        '
        'UiTimerVerifyLicense
        '
        Me.UiTimerVerifyLicense.Enabled = True
        Me.UiTimerVerifyLicense.Interval = 3600000
        '
        'RibbonForm1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(3861, 1336)
        Me.Controls.Add(Me.RibbonStatusBar)
        Me.Controls.Add(Me.RibbonControl)
        Me.IconOptions.Icon = CType(resources.GetObject("RibbonForm1.IconOptions.Icon"), System.Drawing.Icon)
        Me.IconOptions.Image = Global.WMSOnePlan_Client.My.Resources.Resources.drawable_xhdpi_icon
        Me.IsMdiContainer = True
        Me.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.Name = "RibbonForm1"
        Me.Ribbon = Me.RibbonControl
        Me.StatusBar = Me.RibbonStatusBar
        Me.Text = "WMS (Procesos Eficientes)"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.RibbonControl,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.ApplicationMenu1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.RepositoryItemTextEdit1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.RepositoryItemTextEdit2,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.cmbSkinItems,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.RepositoryItemComboBox1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.XtraTabbedMdiManager1,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents RibbonControl As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents RibbonPage_BACKOFFICE As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonStatusBar As DevExpress.XtraBars.Ribbon.RibbonStatusBar
    Friend WithEvents BarButtonItem2 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents XtraTabbedMdiManager1 As DevExpress.XtraTabbedMdi.XtraTabbedMdiManager
    Friend WithEvents DefaultLookAndFeel1 As DevExpress.LookAndFeel.DefaultLookAndFeel
    Friend WithEvents PanelCtrl_BarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem3 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem4 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem5 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem7 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem8 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem9 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarSubItem2 As DevExpress.XtraBars.BarSubItem
    Friend WithEvents BarButtonItem10 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem12 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem13 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarStaticItem1 As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents RibbonPageGroup_TASKS As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents BarButtonItem15 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem22 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem24 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Static_CustomerName As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents Static_Version As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents Static_Environment As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents uiCerrarSesion As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPageGroup4 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents BarStaticItem5 As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents BarStaticItem6 As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents BarButtonItem11 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPageGroup_CATALOGOS As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents BarButtonLocations As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem28 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem29 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem30 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem26 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem27 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem32 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents grpInventarios As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents ApplicationMenu1 As DevExpress.XtraBars.Ribbon.ApplicationMenu
    Friend WithEvents BarLinkContainerItem1 As DevExpress.XtraBars.BarLinkContainerItem
    Friend WithEvents BarButtonItem34 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem14 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarSubItem5 As DevExpress.XtraBars.BarSubItem
    Friend WithEvents BarSubItem6 As DevExpress.XtraBars.BarSubItem
    Friend WithEvents BarButtonItem35 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem37 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnMonitor_ConteoBultos As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem42 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPage_CONFIG As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageGroup_CONFIG As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RibbonPageGroup6 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents Static_UserID As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents btnAparienciaCoffee As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPageGroup_SEGURIDAD As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents BarButtonItem6 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarStaticItem2 As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents btnCrearTareaCargaRuta As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Static_Message As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents BarStaticItem4 As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents RibbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RibbonPageGroup2 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents btn_Transportistas As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem36 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnCrear_PlanRuta As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem16 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnConsulta_Rutas As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarEditItem_Pedido As DevExpress.XtraBars.BarEditItem
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents BarEditItem1 As DevExpress.XtraBars.BarEditItem
    Friend WithEvents RepositoryItemTextEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents btnBinInfo As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnUpLoad_InitFile As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarSubItem3 As DevExpress.XtraBars.BarSubItem
    Friend WithEvents BarButtonItem17 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem18 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem19 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem20 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents cmbSkinItems As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents btnSetupLabels As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RepositoryItemComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents BarEditItem_GUI As DevExpress.XtraBars.BarSubItem
    Friend WithEvents BarCheckItem1 As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents BarCheckItem2 As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents BarButtonItem21 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem23 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents btnMonitor_Consolidacion As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnVehiculos As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnPilotos As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem_TrackingOperatorsByRoute As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnRouteGuide As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnReciboDoc As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPageGroup_Recepcion As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RibbonPageGroup_Despacho As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents btnAutoSat As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnGarita As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnAprobacion As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnInventarioDocumentos As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPageGroup_inventario As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents btnPolizaEgreso As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnGenerateWave As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnReceptions As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnConsultaAuditsRec As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnPase As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnIngresoGeneral As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPageGroupAudit As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents BarButtonItem31 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnEgresoGeneral As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnKardexFiscal As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnCostearGeneral As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem_InvViews As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnConteos As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnServiciosAsociados As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnOccupancy As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnIngresoActurizacionSat As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnInsuranceCompany As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnInsuranceDocs As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnCertificadoDeposito As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnSupervisions As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents grpCertificadosBonos As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents btnRepCertificadoBono As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnRepPolizaSeguros As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPage_Tarifario As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents btnTypeChange As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem38 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem39 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnAcuerdoComercial As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnAcuerdoCliente As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnAutoQuotaLetter As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnAcuseRecibo As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPage_ALMACENAJE As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents btnVencimientoPolizas As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents UiBotonCertificadoDeposito As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarBntOutInventory As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonGroup1 As DevExpress.XtraBars.BarButtonGroup
    Friend WithEvents BtnIngresoExterno As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem41 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents UiBotonPaseSalidaCertificado As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents UiBotonRectificaciones As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents UiBotonReporteEgreso As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents UiBotonReporteIngresoF As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem43 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents UiBotonDemandaDespacho As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPageGroup3 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents UiBotonServiciosPorCobrar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents UiBtnInventarioPorAcuerdoComercial As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents UiBotonIngresoERP As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents UiBotonMasterPack As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPage_BackOrder As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents UiBotonConsultaBackOrder As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonMiniToolbar1 As DevExpress.XtraBars.Ribbon.RibbonMiniToolbar
    Friend WithEvents UiBotonManifiestoDeCarga As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPage_Conteos As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents UiBotonAsignacionConteoFisico As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents UiBotonConsultaConteoFisico As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents UiBotonBalanceDeSaldosFiscal As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents UiBarButtonZonas As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents UiBotonConsultaCosteos As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnVencimientoDePolizas As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem25 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPage_SolicitudTraslado As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents UiBotonSolicitudDeTraslado As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents UiBarButtonConsultaSolicitudDeTraslado As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents UiBotonCatalogoClases As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPage_BloqueoInventario As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents UiBotonBloqueoDeInventario As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents UiButtonTrazabilidadDeDemanda As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents UiBotonConsultaDeLineaDePicking As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents UiGrupoPaginaNextTransporte As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents UiBotonCatalogoEmpresasDeTransporte As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents UiBotonCatalogoDePiloto As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents UiBotonCatalogoVehiculo As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents UiBotonConsultaDeManifiesto As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents UiTimerVerifyLicense As Timer
    Friend WithEvents UiBarButtonConsultaInventarioDiario As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents UiBotonPedidosPorRuta As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents UiGrupoPaginaNextConsultasYTransacciones As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents UiBotonConsultaPaseDeSalida As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents UiBotonConsultaCumplimientoEntrega As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents UiBotonAdminitradorDeLineaDePicking As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents UiBarButtonReporteDevoluciones As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPage_InventarioComprometido As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents UiBotonInventarioComprometido As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonGroup2 As DevExpress.XtraBars.BarButtonGroup
    Friend WithEvents botonConsultasPersonalizadas As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents UiBotonReportePicking As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents UiBontonInvnetarioInactivo As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents UiBotonIndicesDeBodega As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents UiBotonZonaPosicionamiento As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPageCategory1 As DevExpress.XtraBars.Ribbon.RibbonPageCategory
    Friend WithEvents RibbonPageCategory2 As DevExpress.XtraBars.Ribbon.RibbonPageCategory
    Friend WithEvents UISplashScreenManager As DevExpress.XtraSplashScreen.SplashScreenManager
    Friend WithEvents UiBotonSugeridoCompra As DevExpress.XtraBars.BarButtonItem
End Class
