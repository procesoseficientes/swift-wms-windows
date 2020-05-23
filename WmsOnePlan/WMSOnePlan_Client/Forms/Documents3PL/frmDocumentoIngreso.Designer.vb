<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDocumentoIngreso
    Inherits DevExpress.XtraEditors.XtraForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDocumentoIngreso))
        Dim EditorButtonImageOptions1 As DevExpress.XtraEditors.Controls.EditorButtonImageOptions = New DevExpress.XtraEditors.Controls.EditorButtonImageOptions()
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject3 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject4 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.XtraTabHead = New DevExpress.XtraTab.XtraTabPage()
        Me.LayoutEncabezado = New DevExpress.XtraLayout.LayoutControl()
        Me.GridLookUpEdit3 = New DevExpress.XtraEditors.GridLookUpEdit()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar2 = New DevExpress.XtraBars.Bar()
        Me.txtScanPoliza = New DevExpress.XtraBars.BarEditItem()
        Me.txtScanEdit = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.btnScan = New DevExpress.XtraBars.BarLargeButtonItem()
        Me.btnSave = New DevExpress.XtraBars.BarLargeButtonItem()
        Me.btnAddLine = New DevExpress.XtraBars.BarLargeButtonItem()
        Me.btnPrint = New DevExpress.XtraBars.BarLargeButtonItem()
        Me.btnRestore = New DevExpress.XtraBars.BarLargeButtonItem()
        Me.btnClean = New DevExpress.XtraBars.BarLargeButtonItem()
        Me.UIBotonRectificar = New DevExpress.XtraBars.BarLargeButtonItem()
        Me.UIBotonRectificacion = New DevExpress.XtraBars.BarLargeButtonItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.btnRectify = New DevExpress.XtraBars.BarLargeButtonItem()
        Me.btnEnviar = New DevExpress.XtraBars.BarLargeButtonItem()
        Me.GridView10 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridLookUpEdit2 = New DevExpress.XtraEditors.GridLookUpEdit()
        Me.GridView9 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridLookUpEdit1 = New DevExpress.XtraEditors.GridLookUpEdit()
        Me.GridView7 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.cmbBodegueros = New DevExpress.XtraEditors.GridLookUpEdit()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.cmbPolizaAsegurada = New DevExpress.XtraEditors.GridLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.cmbAcuerdoHead = New DevExpress.XtraEditors.GridLookUpEdit()
        Me.GridLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.txtCodigoPoliza = New DevExpress.XtraEditors.TextEdit()
        Me.txtMarchamo = New DevExpress.XtraEditors.TextEdit()
        Me.dtFechaLlegada = New DevExpress.XtraEditors.DateEdit()
        Me.GridDocRefencia = New DevExpress.XtraGrid.GridControl()
        Me.GridViewDocReferencia = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colDOCUMENTO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTIPODOCUMENTO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cmbTipoDocRef = New DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit()
        Me.RepositoryItemGridLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colFECHADOCUMENTO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.dtFechaDocumentoRef = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.colDOC_ID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNUMERO_DUA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOBSERVACIONES = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colLAST_UPDATED_BY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colLAST_UPDATED = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.txtStatus = New DevExpress.XtraEditors.TextEdit()
        Me.txtNumeroSat = New DevExpress.XtraEditors.TextEdit()
        Me.txtDomicilioRepresentante = New DevExpress.XtraEditors.TextEdit()
        Me.txtTipoDeclaranteRepresentante = New DevExpress.XtraEditors.TextEdit()
        Me.txtPaisImportador = New DevExpress.XtraEditors.TextEdit()
        Me.txtPaisRepresentante = New DevExpress.XtraEditors.TextEdit()
        Me.txtRazonSocialRepresentante = New DevExpress.XtraEditors.TextEdit()
        Me.txtIdTributariaRepresentante = New DevExpress.XtraEditors.TextEdit()
        Me.txtTipoRepresentante = New DevExpress.XtraEditors.TextEdit()
        Me.txtModo = New DevExpress.XtraEditors.TextEdit()
        Me.txtTipoImportador = New DevExpress.XtraEditors.TextEdit()
        Me.txtNaturalezaTrans = New DevExpress.XtraEditors.TextEdit()
        Me.txtDepositoFiscalZf = New DevExpress.XtraEditors.TextEdit()
        Me.txtRazonSocialImportador = New DevExpress.XtraEditors.TextEdit()
        Me.txtDomicilioImportador = New DevExpress.XtraEditors.TextEdit()
        Me.txtIdTributariaImportador = New DevExpress.XtraEditors.TextEdit()
        Me.txtAduanaEntradaSalida = New DevExpress.XtraEditors.TextEdit()
        Me.txtClase = New DevExpress.XtraEditors.TextEdit()
        Me.txtNumeroContenedor = New DevExpress.XtraEditors.TextEdit()
        Me.txtEntidadContenedor = New DevExpress.XtraEditors.TextEdit()
        Me.txtTipoContenedor = New DevExpress.XtraEditors.TextEdit()
        Me.txtAduanaDespachoDestino = New DevExpress.XtraEditors.TextEdit()
        Me.txtPaisProcedencia = New DevExpress.XtraEditors.TextEdit()
        Me.txtTotalPesoBrutoKg = New DevExpress.XtraEditors.TextEdit()
        Me.txtTotalBultos = New DevExpress.XtraEditors.TextEdit()
        Me.txtTotalLineas = New DevExpress.XtraEditors.TextEdit()
        Me.txtNumeroOrden = New DevExpress.XtraEditors.TextEdit()
        Me.txtDocumentoPadre = New DevExpress.XtraEditors.TextEdit()
        Me.txtTotalOtrosUsd = New DevExpress.XtraEditors.TextEdit()
        Me.txtTotalSeguroUsd = New DevExpress.XtraEditors.TextEdit()
        Me.txtTotalFleteUsd = New DevExpress.XtraEditors.TextEdit()
        Me.dtFechaAceptacion = New DevExpress.XtraEditors.DateEdit()
        Me.txtNumeroDua = New DevExpress.XtraEditors.TextEdit()
        Me.txtTotalGeneral = New DevExpress.XtraEditors.TextEdit()
        Me.txtTotalOtros = New DevExpress.XtraEditors.TextEdit()
        Me.txtTotalLiquidar = New DevExpress.XtraEditors.TextEdit()
        Me.dtFechaDocumento = New DevExpress.XtraEditors.DateEdit()
        Me.txtDocId = New DevExpress.XtraEditors.ButtonEdit()
        Me.txtTotalFobUsd = New DevExpress.XtraEditors.TextEdit()
        Me.txtTotalValorAduana = New DevExpress.XtraEditors.TextEdit()
        Me.txtTipoCambio = New DevExpress.XtraEditors.TextEdit()
        Me.cmbRegimenPoliza = New DevExpress.XtraEditors.GridLookUpEdit()
        Me.GridViewCmbRegimen = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.cmbRegimen = New DevExpress.XtraEditors.GridLookUpEdit()
        Me.GridViewCmbRegimenAlmacen = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.cmbCliente = New DevExpress.XtraEditors.GridLookUpEdit()
        Me.GridViewCliente = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.txtTicketNumber = New DevExpress.XtraEditors.TextEdit()
        Me.lookUpPrioridad = New DevExpress.XtraEditors.GridLookUpEdit()
        Me.GridLookUpEdit4View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem18 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem22 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem23 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem24 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem11 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem12 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem27 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem25 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem28 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem50 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem14 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem15 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem34 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem13 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem10 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem20 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem19 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem21 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem26 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem43 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem16 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem44 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem31 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem39 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem36 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem38 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem32 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem30 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem35 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem40 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SplitterItem2 = New DevExpress.XtraLayout.SplitterItem()
        Me.SplitterItem3 = New DevExpress.XtraLayout.SplitterItem()
        Me.SplitterItem4 = New DevExpress.XtraLayout.SplitterItem()
        Me.SplitterItem6 = New DevExpress.XtraLayout.SplitterItem()
        Me.LayoutControlItem46 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem45 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SplitterItem1 = New DevExpress.XtraLayout.SplitterItem()
        Me.SplitterItem7 = New DevExpress.XtraLayout.SplitterItem()
        Me.LayoutControlItem29 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem41 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem33 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SplitterItem5 = New DevExpress.XtraLayout.SplitterItem()
        Me.LayoutControlItem80 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem42 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lblPolizaAsegurada = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem82 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem79 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem17 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem37 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.layoutTicketFiscal = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem83 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem77 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem84 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem85 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.XtraTabDetail = New DevExpress.XtraTab.XtraTabPage()
        Me.LayoutDetalle = New DevExpress.XtraLayout.LayoutControl()
        Me.UiListaImpuesto = New DevExpress.XtraEditors.GridLookUpEdit()
        Me.UiListaVistaImpuesto = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.UiColDescripcionImpuesto = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.txtPolizaOrigen = New DevExpress.XtraEditors.TextEdit()
        Me.txtDocumentoOrigen = New DevExpress.XtraEditors.TextEdit()
        Me.txtActualizadaEl = New DevExpress.XtraEditors.TextEdit()
        Me.txtActualizadaPor = New DevExpress.XtraEditors.TextEdit()
        Me.txtPolizaRelacionada = New DevExpress.XtraEditors.TextEdit()
        Me.txtAcuerdo2 = New DevExpress.XtraEditors.TextEdit()
        Me.txtAcuerdo1 = New DevExpress.XtraEditors.TextEdit()
        Me.txtRegionCp = New DevExpress.XtraEditors.TextEdit()
        Me.txtSeguroUsd = New DevExpress.XtraEditors.TextEdit()
        Me.txtFleteUsd = New DevExpress.XtraEditors.TextEdit()
        Me.txtFobUsd = New DevExpress.XtraEditors.TextEdit()
        Me.txtPaisOrigen = New DevExpress.XtraEditors.TextEdit()
        Me.txtGastosVarios = New DevExpress.XtraEditors.TextEdit()
        Me.txtImpuestosVarios = New DevExpress.XtraEditors.TextEdit()
        Me.GridDetalle = New DevExpress.XtraGrid.GridControl()
        Me.GridViewDetalle = New DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView()
        Me.GridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.colNUMEROLINEA = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colDESCRIPCIONPRODUCTO = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colBULTOS = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colVALORADUANA = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colVALORIVA = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colVALORDAI = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colCANTIDAD = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colUNIDADCANTIDAD = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colCLASE = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colPESONETO = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colUNIDADPESO = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colVOLUMEN = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colUNIDADVOLUMEN = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colCODIGOSAC = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colIMPUESTOSVARIOS = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colGASTOSVARIOS = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colPAISORIGEN = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colFOBUSD = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colFLETEUSD = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colSEGUROUSD = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colREGIONCP = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colACUERDO1 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colACUERDO2 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colPOLIZARELACIONADA = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colACTUALIZADAPOR = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colACTUALIZADAEL = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colDOCUMENTOORIGEN = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colPOLIZAORIGEN = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colACUERDOCOMERCIAL = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colCONSIGNATARIO = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colPCTDAI = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colMaterialId = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.txtValorIva = New DevExpress.XtraEditors.TextEdit()
        Me.txtDai = New DevExpress.XtraEditors.TextEdit()
        Me.txtVolumen = New DevExpress.XtraEditors.TextEdit()
        Me.txtValorAduana = New DevExpress.XtraEditors.TextEdit()
        Me.txtCantidad = New DevExpress.XtraEditors.TextEdit()
        Me.cmbUnidadPeso = New DevExpress.XtraEditors.GridLookUpEdit()
        Me.GridView4 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.txtPesoNeto = New DevExpress.XtraEditors.TextEdit()
        Me.txtClaseLinea = New DevExpress.XtraEditors.TextEdit()
        Me.txtBultos = New DevExpress.XtraEditors.TextEdit()
        Me.cmbSacCode = New DevExpress.XtraEditors.GridLookUpEdit()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.txtNumeroLinea = New DevExpress.XtraEditors.TextEdit()
        Me.cmbUnidadCantidad = New DevExpress.XtraEditors.GridLookUpEdit()
        Me.GridView5 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.cmbUnidadVolumen = New DevExpress.XtraEditors.GridLookUpEdit()
        Me.GridView6 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.cmbConsignatario = New DevExpress.XtraEditors.GridLookUpEdit()
        Me.GridView8 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.pctDAI = New DevExpress.XtraEditors.SpinEdit()
        Me.txtDescripcionSku = New DevExpress.XtraEditors.LookUpEdit()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem47 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem52 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem58 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem48 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem51 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem56 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem60 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem55 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem61 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem53 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem54 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem59 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem49 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SplitterItem8 = New DevExpress.XtraLayout.SplitterItem()
        Me.LayoutControlItem62 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem63 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem64 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem65 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem66 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem67 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem68 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem69 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem78 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem74 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem72 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem76 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem73 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SplitterItem9 = New DevExpress.XtraLayout.SplitterItem()
        Me.LayoutControlItem70 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem71 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem81 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem75 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.UiLayoutControlImpuesto = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem57 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.XtraTabServicios = New DevExpress.XtraTab.XtraTabPage()
        Me.LayoutServicios = New DevExpress.XtraLayout.LayoutControl()
        Me.LayoutControlGroup3 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.Bar1 = New DevExpress.XtraBars.Bar()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.XtraTabHead.SuspendLayout()
        CType(Me.LayoutEncabezado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutEncabezado.SuspendLayout()
        CType(Me.GridLookUpEdit3.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtScanEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridLookUpEdit2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridLookUpEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbBodegueros.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbPolizaAsegurada.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbAcuerdoHead.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCodigoPoliza.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMarchamo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtFechaLlegada.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtFechaLlegada.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridDocRefencia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewDocReferencia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbTipoDocRef, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemGridLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtFechaDocumentoRef, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtFechaDocumentoRef.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtStatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNumeroSat.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDomicilioRepresentante.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTipoDeclaranteRepresentante.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPaisImportador.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPaisRepresentante.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRazonSocialRepresentante.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtIdTributariaRepresentante.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTipoRepresentante.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtModo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTipoImportador.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNaturalezaTrans.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDepositoFiscalZf.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRazonSocialImportador.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDomicilioImportador.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtIdTributariaImportador.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAduanaEntradaSalida.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtClase.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNumeroContenedor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEntidadContenedor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTipoContenedor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAduanaDespachoDestino.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPaisProcedencia.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalPesoBrutoKg.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalBultos.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalLineas.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNumeroOrden.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDocumentoPadre.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalOtrosUsd.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalSeguroUsd.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalFleteUsd.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtFechaAceptacion.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtFechaAceptacion.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNumeroDua.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalGeneral.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalOtros.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalLiquidar.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtFechaDocumento.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtFechaDocumento.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDocId.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalFobUsd.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalValorAduana.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTipoCambio.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbRegimenPoliza.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewCmbRegimen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbRegimen.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewCmbRegimenAlmacen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbCliente.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTicketNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lookUpPrioridad.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridLookUpEdit4View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem24, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem27, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem25, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem28, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem50, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem34, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem26, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem43, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem44, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem31, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem39, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem36, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem38, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem32, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem30, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem35, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem40, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitterItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitterItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitterItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitterItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem46, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem45, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitterItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitterItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem29, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem41, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem33, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitterItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem80, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem42, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPolizaAsegurada, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem82, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem79, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem37, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutTicketFiscal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem83, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem77, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem84, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem85, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabDetail.SuspendLayout()
        CType(Me.LayoutDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutDetalle.SuspendLayout()
        CType(Me.UiListaImpuesto.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiListaVistaImpuesto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPolizaOrigen.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDocumentoOrigen.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtActualizadaEl.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtActualizadaPor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPolizaRelacionada.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAcuerdo2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAcuerdo1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRegionCp.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSeguroUsd.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFleteUsd.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFobUsd.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPaisOrigen.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtGastosVarios.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtImpuestosVarios.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtValorIva.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDai.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtVolumen.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtValorAduana.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCantidad.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbUnidadPeso.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPesoNeto.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtClaseLinea.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBultos.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbSacCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNumeroLinea.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbUnidadCantidad.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbUnidadVolumen.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbConsignatario.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctDAI.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDescripcionSku.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem47, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem52, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem58, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem48, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem51, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem56, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem60, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem55, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem61, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem53, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem54, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem59, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem49, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitterItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem62, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem63, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem64, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem65, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem66, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem67, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem68, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem69, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem78, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem74, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem72, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem76, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem73, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitterItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem70, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem71, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem81, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem75, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiLayoutControlImpuesto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem57, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabServicios.SuspendLayout()
        CType(Me.LayoutServicios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XtraTabControl1.Location = New System.Drawing.Point(0, 106)
        Me.XtraTabControl1.Margin = New System.Windows.Forms.Padding(6)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.XtraTabHead
        Me.XtraTabControl1.Size = New System.Drawing.Size(2418, 1325)
        Me.XtraTabControl1.TabIndex = 0
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XtraTabHead, Me.XtraTabDetail, Me.XtraTabServicios})
        '
        'XtraTabHead
        '
        Me.XtraTabHead.Controls.Add(Me.LayoutEncabezado)
        Me.XtraTabHead.Margin = New System.Windows.Forms.Padding(6)
        Me.XtraTabHead.Name = "XtraTabHead"
        Me.XtraTabHead.Size = New System.Drawing.Size(2414, 1276)
        Me.XtraTabHead.Text = "Encabezado Ingreso"
        '
        'LayoutEncabezado
        '
        Me.LayoutEncabezado.Controls.Add(Me.GridLookUpEdit3)
        Me.LayoutEncabezado.Controls.Add(Me.GridLookUpEdit2)
        Me.LayoutEncabezado.Controls.Add(Me.GridLookUpEdit1)
        Me.LayoutEncabezado.Controls.Add(Me.cmbBodegueros)
        Me.LayoutEncabezado.Controls.Add(Me.cmbPolizaAsegurada)
        Me.LayoutEncabezado.Controls.Add(Me.cmbAcuerdoHead)
        Me.LayoutEncabezado.Controls.Add(Me.txtCodigoPoliza)
        Me.LayoutEncabezado.Controls.Add(Me.txtMarchamo)
        Me.LayoutEncabezado.Controls.Add(Me.dtFechaLlegada)
        Me.LayoutEncabezado.Controls.Add(Me.GridDocRefencia)
        Me.LayoutEncabezado.Controls.Add(Me.txtStatus)
        Me.LayoutEncabezado.Controls.Add(Me.txtNumeroSat)
        Me.LayoutEncabezado.Controls.Add(Me.txtDomicilioRepresentante)
        Me.LayoutEncabezado.Controls.Add(Me.txtTipoDeclaranteRepresentante)
        Me.LayoutEncabezado.Controls.Add(Me.txtPaisImportador)
        Me.LayoutEncabezado.Controls.Add(Me.txtPaisRepresentante)
        Me.LayoutEncabezado.Controls.Add(Me.txtRazonSocialRepresentante)
        Me.LayoutEncabezado.Controls.Add(Me.txtIdTributariaRepresentante)
        Me.LayoutEncabezado.Controls.Add(Me.txtTipoRepresentante)
        Me.LayoutEncabezado.Controls.Add(Me.txtModo)
        Me.LayoutEncabezado.Controls.Add(Me.txtTipoImportador)
        Me.LayoutEncabezado.Controls.Add(Me.txtNaturalezaTrans)
        Me.LayoutEncabezado.Controls.Add(Me.txtDepositoFiscalZf)
        Me.LayoutEncabezado.Controls.Add(Me.txtRazonSocialImportador)
        Me.LayoutEncabezado.Controls.Add(Me.txtDomicilioImportador)
        Me.LayoutEncabezado.Controls.Add(Me.txtIdTributariaImportador)
        Me.LayoutEncabezado.Controls.Add(Me.txtAduanaEntradaSalida)
        Me.LayoutEncabezado.Controls.Add(Me.txtClase)
        Me.LayoutEncabezado.Controls.Add(Me.txtNumeroContenedor)
        Me.LayoutEncabezado.Controls.Add(Me.txtEntidadContenedor)
        Me.LayoutEncabezado.Controls.Add(Me.txtTipoContenedor)
        Me.LayoutEncabezado.Controls.Add(Me.txtAduanaDespachoDestino)
        Me.LayoutEncabezado.Controls.Add(Me.txtPaisProcedencia)
        Me.LayoutEncabezado.Controls.Add(Me.txtTotalPesoBrutoKg)
        Me.LayoutEncabezado.Controls.Add(Me.txtTotalBultos)
        Me.LayoutEncabezado.Controls.Add(Me.txtTotalLineas)
        Me.LayoutEncabezado.Controls.Add(Me.txtNumeroOrden)
        Me.LayoutEncabezado.Controls.Add(Me.txtDocumentoPadre)
        Me.LayoutEncabezado.Controls.Add(Me.txtTotalOtrosUsd)
        Me.LayoutEncabezado.Controls.Add(Me.txtTotalSeguroUsd)
        Me.LayoutEncabezado.Controls.Add(Me.txtTotalFleteUsd)
        Me.LayoutEncabezado.Controls.Add(Me.dtFechaAceptacion)
        Me.LayoutEncabezado.Controls.Add(Me.txtNumeroDua)
        Me.LayoutEncabezado.Controls.Add(Me.txtTotalGeneral)
        Me.LayoutEncabezado.Controls.Add(Me.txtTotalOtros)
        Me.LayoutEncabezado.Controls.Add(Me.txtTotalLiquidar)
        Me.LayoutEncabezado.Controls.Add(Me.dtFechaDocumento)
        Me.LayoutEncabezado.Controls.Add(Me.txtDocId)
        Me.LayoutEncabezado.Controls.Add(Me.txtTotalFobUsd)
        Me.LayoutEncabezado.Controls.Add(Me.txtTotalValorAduana)
        Me.LayoutEncabezado.Controls.Add(Me.txtTipoCambio)
        Me.LayoutEncabezado.Controls.Add(Me.cmbRegimenPoliza)
        Me.LayoutEncabezado.Controls.Add(Me.cmbRegimen)
        Me.LayoutEncabezado.Controls.Add(Me.cmbCliente)
        Me.LayoutEncabezado.Controls.Add(Me.txtTicketNumber)
        Me.LayoutEncabezado.Controls.Add(Me.lookUpPrioridad)
        Me.LayoutEncabezado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.LayoutEncabezado.Margin = New System.Windows.Forms.Padding(6)
        Me.LayoutEncabezado.Name = "LayoutEncabezado"
        Me.LayoutEncabezado.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(-1039, 248, 250, 350)
        Me.LayoutEncabezado.Root = Me.LayoutControlGroup1
        Me.LayoutEncabezado.Size = New System.Drawing.Size(2414, 1276)
        Me.LayoutEncabezado.TabIndex = 0
        Me.LayoutEncabezado.Text = "Encabezado Ingreso"
        '
        'GridLookUpEdit3
        '
        Me.GridLookUpEdit3.Location = New System.Drawing.Point(304, 1224)
        Me.GridLookUpEdit3.Margin = New System.Windows.Forms.Padding(6)
        Me.GridLookUpEdit3.MenuManager = Me.BarManager1
        Me.GridLookUpEdit3.Name = "GridLookUpEdit3"
        Me.GridLookUpEdit3.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridLookUpEdit3.Properties.Appearance.Options.UseBackColor = True
        Me.GridLookUpEdit3.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        Me.GridLookUpEdit3.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.GridLookUpEdit3.Properties.NullText = "[Seleccione Regimen...]"
        Me.GridLookUpEdit3.Properties.PopupView = Me.GridView10
        Me.GridLookUpEdit3.Size = New System.Drawing.Size(2098, 40)
        Me.GridLookUpEdit3.StyleController = Me.LayoutEncabezado
        Me.GridLookUpEdit3.TabIndex = 60
        '
        'BarManager1
        '
        Me.BarManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Bar2})
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.btnSave, Me.btnScan, Me.btnRectify, Me.btnPrint, Me.btnRestore, Me.btnAddLine, Me.btnEnviar, Me.txtScanPoliza, Me.btnClean, Me.UIBotonRectificar, Me.UIBotonRectificacion})
        Me.BarManager1.MainMenu = Me.Bar2
        Me.BarManager1.MaxItemId = 14
        Me.BarManager1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.txtScanEdit})
        '
        'Bar2
        '
        Me.Bar2.BarName = "Main menu"
        Me.Bar2.DockCol = 0
        Me.Bar2.DockRow = 0
        Me.Bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar2.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.txtScanPoliza, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(Me.btnScan), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.btnSave, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(CType((DevExpress.XtraBars.BarLinkUserDefines.PaintStyle Or DevExpress.XtraBars.BarLinkUserDefines.KeyTip), DevExpress.XtraBars.BarLinkUserDefines), Me.btnAddLine, "", False, True, True, 0, Nothing, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph, "", ""), New DevExpress.XtraBars.LinkPersistInfo(CType((DevExpress.XtraBars.BarLinkUserDefines.PaintStyle Or DevExpress.XtraBars.BarLinkUserDefines.KeyTip), DevExpress.XtraBars.BarLinkUserDefines), Me.btnPrint, "", False, True, True, 0, Nothing, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph, "P", ""), New DevExpress.XtraBars.LinkPersistInfo(CType((DevExpress.XtraBars.BarLinkUserDefines.PaintStyle Or DevExpress.XtraBars.BarLinkUserDefines.KeyTip), DevExpress.XtraBars.BarLinkUserDefines), Me.btnRestore, "", False, True, True, 0, Nothing, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph, "T", ""), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.btnClean, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(Me.UIBotonRectificar), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.UIBotonRectificacion, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)})
        Me.Bar2.OptionsBar.MultiLine = True
        Me.Bar2.OptionsBar.UseWholeRow = True
        Me.Bar2.Text = "Main menu"
        '
        'txtScanPoliza
        '
        Me.txtScanPoliza.Edit = Me.txtScanEdit
        Me.txtScanPoliza.EditWidth = 141
        Me.txtScanPoliza.Id = 8
        Me.txtScanPoliza.Name = "txtScanPoliza"
        '
        'txtScanEdit
        '
        Me.txtScanEdit.AutoHeight = False
        Me.txtScanEdit.Name = "txtScanEdit"
        '
        'btnScan
        '
        Me.btnScan.Caption = "&Escanear"
        Me.btnScan.CaptionAlignment = DevExpress.XtraBars.BarItemCaptionAlignment.Right
        Me.btnScan.Id = 2
        Me.btnScan.ImageOptions.LargeImage = Global.WMSOnePlan_Client.My.Resources.Resources.shapes080
        Me.btnScan.ItemShortcut = New DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.E))
        Me.btnScan.Name = "btnScan"
        Me.btnScan.ShortcutKeyDisplayString = "Ctrl+E"
        '
        'btnSave
        '
        Me.btnSave.Caption = "&Grabar"
        Me.btnSave.Id = 1
        Me.btnSave.ImageOptions.LargeImage = Global.WMSOnePlan_Client.My.Resources.Resources.save_large
        Me.btnSave.ItemShortcut = New DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.G))
        Me.btnSave.Name = "btnSave"
        Me.btnSave.ShortcutKeyDisplayString = "Ctrl+G"
        '
        'btnAddLine
        '
        Me.btnAddLine.Caption = "&Agregar Linea"
        Me.btnAddLine.Id = 6
        Me.btnAddLine.ImageOptions.Image = Global.WMSOnePlan_Client.My.Resources.Resources.size_vertical
        Me.btnAddLine.ItemShortcut = New DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A))
        Me.btnAddLine.Name = "btnAddLine"
        Me.btnAddLine.ShortcutKeyDisplayString = "Ctrl+A"
        '
        'btnPrint
        '
        Me.btnPrint.Caption = "Im&primir"
        Me.btnPrint.Id = 4
        Me.btnPrint.ImageOptions.LargeImage = Global.WMSOnePlan_Client.My.Resources.Resources.print_large
        Me.btnPrint.ItemShortcut = New DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P))
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.ShortcutKeyDisplayString = "Ctrl+P"
        '
        'btnRestore
        '
        Me.btnRestore.Caption = "Res&tablecer"
        Me.btnRestore.Id = 5
        Me.btnRestore.ImageOptions.LargeImage = Global.WMSOnePlan_Client.My.Resources.Resources.MarkAsFinal_Large
        Me.btnRestore.ItemShortcut = New DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.T))
        Me.btnRestore.Name = "btnRestore"
        Me.btnRestore.ShortcutKeyDisplayString = "Ctrl+T"
        '
        'btnClean
        '
        Me.btnClean.Caption = "Limpiar Campos"
        Me.btnClean.Id = 9
        Me.btnClean.ImageOptions.Image = Global.WMSOnePlan_Client.My.Resources.Resources.application_side_list
        Me.btnClean.Name = "btnClean"
        '
        'UIBotonRectificar
        '
        Me.UIBotonRectificar.Caption = "Rectificar"
        Me.UIBotonRectificar.Id = 11
        Me.UIBotonRectificar.ImageOptions.LargeImage = CType(resources.GetObject("UIBotonRectificar.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.UIBotonRectificar.Name = "UIBotonRectificar"
        '
        'UIBotonRectificacion
        '
        Me.UIBotonRectificacion.Caption = "Rectificación"
        Me.UIBotonRectificacion.Id = 13
        Me.UIBotonRectificacion.ImageOptions.Image = CType(resources.GetObject("UIBotonRectificacion.ImageOptions.Image"), System.Drawing.Image)
        Me.UIBotonRectificacion.ImageOptions.LargeImage = CType(resources.GetObject("UIBotonRectificacion.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.UIBotonRectificacion.Name = "UIBotonRectificacion"
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Manager = Me.BarManager1
        Me.barDockControlTop.Margin = New System.Windows.Forms.Padding(6)
        Me.barDockControlTop.Size = New System.Drawing.Size(2418, 106)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 1431)
        Me.barDockControlBottom.Manager = Me.BarManager1
        Me.barDockControlBottom.Margin = New System.Windows.Forms.Padding(6)
        Me.barDockControlBottom.Size = New System.Drawing.Size(2418, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 106)
        Me.barDockControlLeft.Manager = Me.BarManager1
        Me.barDockControlLeft.Margin = New System.Windows.Forms.Padding(6)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 1325)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(2418, 106)
        Me.barDockControlRight.Manager = Me.BarManager1
        Me.barDockControlRight.Margin = New System.Windows.Forms.Padding(6)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 1325)
        '
        'btnRectify
        '
        Me.btnRectify.Caption = "&Rectificacion"
        Me.btnRectify.Id = 3
        Me.btnRectify.ImageOptions.LargeImage = Global.WMSOnePlan_Client.My.Resources.Resources.Prepare_Large
        Me.btnRectify.ItemShortcut = New DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.R))
        Me.btnRectify.Name = "btnRectify"
        Me.btnRectify.ShortcutKeyDisplayString = "Ctrl+R"
        '
        'btnEnviar
        '
        Me.btnEnviar.Caption = "&Enviar SAT"
        Me.btnEnviar.Id = 7
        Me.btnEnviar.ImageOptions.Image = Global.WMSOnePlan_Client.My.Resources.Resources.transmit_go
        Me.btnEnviar.ItemShortcut = New DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.E))
        Me.btnEnviar.Name = "btnEnviar"
        '
        'GridView10
        '
        Me.GridView10.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView10.Name = "GridView10"
        Me.GridView10.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView10.OptionsView.ShowAutoFilterRow = True
        Me.GridView10.OptionsView.ShowGroupPanel = False
        '
        'GridLookUpEdit2
        '
        Me.GridLookUpEdit2.Location = New System.Drawing.Point(304, 1180)
        Me.GridLookUpEdit2.Margin = New System.Windows.Forms.Padding(6)
        Me.GridLookUpEdit2.MenuManager = Me.BarManager1
        Me.GridLookUpEdit2.Name = "GridLookUpEdit2"
        Me.GridLookUpEdit2.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridLookUpEdit2.Properties.Appearance.Options.UseBackColor = True
        Me.GridLookUpEdit2.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        Me.GridLookUpEdit2.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.GridLookUpEdit2.Properties.NullText = "[Seleccione Regimen...]"
        Me.GridLookUpEdit2.Properties.PopupView = Me.GridView9
        Me.GridLookUpEdit2.Size = New System.Drawing.Size(2098, 40)
        Me.GridLookUpEdit2.StyleController = Me.LayoutEncabezado
        Me.GridLookUpEdit2.TabIndex = 59
        '
        'GridView9
        '
        Me.GridView9.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView9.Name = "GridView9"
        Me.GridView9.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView9.OptionsView.ShowAutoFilterRow = True
        Me.GridView9.OptionsView.ShowGroupPanel = False
        '
        'GridLookUpEdit1
        '
        Me.GridLookUpEdit1.Location = New System.Drawing.Point(304, 1136)
        Me.GridLookUpEdit1.Margin = New System.Windows.Forms.Padding(6)
        Me.GridLookUpEdit1.MenuManager = Me.BarManager1
        Me.GridLookUpEdit1.Name = "GridLookUpEdit1"
        Me.GridLookUpEdit1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridLookUpEdit1.Properties.Appearance.Options.UseBackColor = True
        Me.GridLookUpEdit1.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        Me.GridLookUpEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.GridLookUpEdit1.Properties.NullText = "[Seleccione Regimen...]"
        Me.GridLookUpEdit1.Properties.PopupView = Me.GridView7
        Me.GridLookUpEdit1.Size = New System.Drawing.Size(2098, 40)
        Me.GridLookUpEdit1.StyleController = Me.LayoutEncabezado
        Me.GridLookUpEdit1.TabIndex = 58
        '
        'GridView7
        '
        Me.GridView7.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView7.Name = "GridView7"
        Me.GridView7.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView7.OptionsView.ShowAutoFilterRow = True
        Me.GridView7.OptionsView.ShowGroupPanel = False
        '
        'cmbBodegueros
        '
        Me.cmbBodegueros.Location = New System.Drawing.Point(1161, 710)
        Me.cmbBodegueros.Margin = New System.Windows.Forms.Padding(6)
        Me.cmbBodegueros.MenuManager = Me.BarManager1
        Me.cmbBodegueros.Name = "cmbBodegueros"
        Me.cmbBodegueros.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmbBodegueros.Properties.Appearance.Options.UseBackColor = True
        Me.cmbBodegueros.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbBodegueros.Properties.PopupView = Me.GridView2
        Me.cmbBodegueros.Size = New System.Drawing.Size(1241, 40)
        Me.cmbBodegueros.StyleController = Me.LayoutEncabezado
        Me.cmbBodegueros.TabIndex = 12
        '
        'GridView2
        '
        Me.GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'cmbPolizaAsegurada
        '
        Me.cmbPolizaAsegurada.Location = New System.Drawing.Point(304, 646)
        Me.cmbPolizaAsegurada.Margin = New System.Windows.Forms.Padding(6)
        Me.cmbPolizaAsegurada.MenuManager = Me.BarManager1
        Me.cmbPolizaAsegurada.Name = "cmbPolizaAsegurada"
        Me.cmbPolizaAsegurada.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmbPolizaAsegurada.Properties.Appearance.Options.UseBackColor = True
        Me.cmbPolizaAsegurada.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        Me.cmbPolizaAsegurada.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbPolizaAsegurada.Properties.NullText = ""
        Me.cmbPolizaAsegurada.Properties.PopupFormMinSize = New System.Drawing.Size(600, 0)
        Me.cmbPolizaAsegurada.Properties.PopupView = Me.GridView1
        Me.cmbPolizaAsegurada.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.cmbPolizaAsegurada.Size = New System.Drawing.Size(541, 40)
        Me.cmbPolizaAsegurada.StyleController = Me.LayoutEncabezado
        Me.cmbPolizaAsegurada.TabIndex = 50
        '
        'GridView1
        '
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'cmbAcuerdoHead
        '
        Me.cmbAcuerdoHead.Location = New System.Drawing.Point(1161, 666)
        Me.cmbAcuerdoHead.Margin = New System.Windows.Forms.Padding(6)
        Me.cmbAcuerdoHead.MenuManager = Me.BarManager1
        Me.cmbAcuerdoHead.Name = "cmbAcuerdoHead"
        Me.cmbAcuerdoHead.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmbAcuerdoHead.Properties.Appearance.Options.UseBackColor = True
        Me.cmbAcuerdoHead.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbAcuerdoHead.Properties.NullText = "[Seleccione Acuerdo...]"
        Me.cmbAcuerdoHead.Properties.PopupView = Me.GridLookUpEdit1View
        Me.cmbAcuerdoHead.Size = New System.Drawing.Size(1241, 40)
        Me.cmbAcuerdoHead.StyleController = Me.LayoutEncabezado
        Me.cmbAcuerdoHead.TabIndex = 55
        '
        'GridLookUpEdit1View
        '
        Me.GridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridLookUpEdit1View.Name = "GridLookUpEdit1View"
        Me.GridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'txtCodigoPoliza
        '
        Me.txtCodigoPoliza.Location = New System.Drawing.Point(304, 100)
        Me.txtCodigoPoliza.Margin = New System.Windows.Forms.Padding(6)
        Me.txtCodigoPoliza.MenuManager = Me.BarManager1
        Me.txtCodigoPoliza.Name = "txtCodigoPoliza"
        Me.txtCodigoPoliza.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtCodigoPoliza.Properties.Appearance.Options.UseBackColor = True
        Me.txtCodigoPoliza.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.txtCodigoPoliza.Properties.MaxLength = 15
        Me.txtCodigoPoliza.Size = New System.Drawing.Size(312, 38)
        Me.txtCodigoPoliza.StyleController = Me.LayoutEncabezado
        Me.txtCodigoPoliza.TabIndex = 54
        '
        'txtMarchamo
        '
        Me.txtMarchamo.Location = New System.Drawing.Point(304, 690)
        Me.txtMarchamo.Margin = New System.Windows.Forms.Padding(6)
        Me.txtMarchamo.MenuManager = Me.BarManager1
        Me.txtMarchamo.Name = "txtMarchamo"
        Me.txtMarchamo.Size = New System.Drawing.Size(541, 40)
        Me.txtMarchamo.StyleController = Me.LayoutEncabezado
        Me.txtMarchamo.TabIndex = 48
        '
        'dtFechaLlegada
        '
        Me.dtFechaLlegada.EditValue = Nothing
        Me.dtFechaLlegada.Location = New System.Drawing.Point(2182, 56)
        Me.dtFechaLlegada.Margin = New System.Windows.Forms.Padding(6)
        Me.dtFechaLlegada.MenuManager = Me.BarManager1
        Me.dtFechaLlegada.Name = "dtFechaLlegada"
        Me.dtFechaLlegada.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.dtFechaLlegada.Properties.Appearance.Options.UseBackColor = True
        Me.dtFechaLlegada.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtFechaLlegada.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.dtFechaLlegada.Size = New System.Drawing.Size(220, 40)
        Me.dtFechaLlegada.StyleController = Me.LayoutEncabezado
        Me.dtFechaLlegada.TabIndex = 47
        '
        'GridDocRefencia
        '
        Me.GridDocRefencia.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(6)
        Me.GridDocRefencia.Location = New System.Drawing.Point(304, 774)
        Me.GridDocRefencia.MainView = Me.GridViewDocReferencia
        Me.GridDocRefencia.Margin = New System.Windows.Forms.Padding(6)
        Me.GridDocRefencia.MenuManager = Me.BarManager1
        Me.GridDocRefencia.Name = "GridDocRefencia"
        Me.GridDocRefencia.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.dtFechaDocumentoRef, Me.cmbTipoDocRef})
        Me.GridDocRefencia.Size = New System.Drawing.Size(2098, 358)
        Me.GridDocRefencia.TabIndex = 53
        Me.GridDocRefencia.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewDocReferencia})
        '
        'GridViewDocReferencia
        '
        Me.GridViewDocReferencia.Appearance.TopNewRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridViewDocReferencia.Appearance.TopNewRow.Options.UseBackColor = True
        Me.GridViewDocReferencia.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colDOCUMENTO, Me.colTIPODOCUMENTO, Me.colFECHADOCUMENTO, Me.colDOC_ID, Me.colNUMERO_DUA, Me.colOBSERVACIONES, Me.colLAST_UPDATED_BY, Me.colLAST_UPDATED})
        Me.GridViewDocReferencia.DetailHeight = 673
        Me.GridViewDocReferencia.FixedLineWidth = 4
        Me.GridViewDocReferencia.GridControl = Me.GridDocRefencia
        Me.GridViewDocReferencia.Name = "GridViewDocReferencia"
        Me.GridViewDocReferencia.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
        Me.GridViewDocReferencia.OptionsView.ShowGroupPanel = False
        '
        'colDOCUMENTO
        '
        Me.colDOCUMENTO.Caption = "NUMERO DOCUMENTO"
        Me.colDOCUMENTO.FieldName = "NUMERO_DOCUMENTO"
        Me.colDOCUMENTO.MinWidth = 40
        Me.colDOCUMENTO.Name = "colDOCUMENTO"
        Me.colDOCUMENTO.Visible = True
        Me.colDOCUMENTO.VisibleIndex = 0
        Me.colDOCUMENTO.Width = 150
        '
        'colTIPODOCUMENTO
        '
        Me.colTIPODOCUMENTO.Caption = "TIPO DOCUMENTO"
        Me.colTIPODOCUMENTO.ColumnEdit = Me.cmbTipoDocRef
        Me.colTIPODOCUMENTO.FieldName = "TIPO_DOCUMENTO"
        Me.colTIPODOCUMENTO.MinWidth = 40
        Me.colTIPODOCUMENTO.Name = "colTIPODOCUMENTO"
        Me.colTIPODOCUMENTO.Visible = True
        Me.colTIPODOCUMENTO.VisibleIndex = 1
        Me.colTIPODOCUMENTO.Width = 150
        '
        'cmbTipoDocRef
        '
        Me.cmbTipoDocRef.AutoHeight = False
        Me.cmbTipoDocRef.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbTipoDocRef.Name = "cmbTipoDocRef"
        Me.cmbTipoDocRef.NullText = "[Seleccione tipo documento...]"
        Me.cmbTipoDocRef.PopupView = Me.RepositoryItemGridLookUpEdit1View
        '
        'RepositoryItemGridLookUpEdit1View
        '
        Me.RepositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.RepositoryItemGridLookUpEdit1View.Name = "RepositoryItemGridLookUpEdit1View"
        Me.RepositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.RepositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'colFECHADOCUMENTO
        '
        Me.colFECHADOCUMENTO.Caption = "FECHA DOCUMENTO"
        Me.colFECHADOCUMENTO.ColumnEdit = Me.dtFechaDocumentoRef
        Me.colFECHADOCUMENTO.FieldName = "FECHA_DOCUMENTO"
        Me.colFECHADOCUMENTO.MinWidth = 40
        Me.colFECHADOCUMENTO.Name = "colFECHADOCUMENTO"
        Me.colFECHADOCUMENTO.Visible = True
        Me.colFECHADOCUMENTO.VisibleIndex = 2
        Me.colFECHADOCUMENTO.Width = 150
        '
        'dtFechaDocumentoRef
        '
        Me.dtFechaDocumentoRef.AutoHeight = False
        Me.dtFechaDocumentoRef.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtFechaDocumentoRef.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.dtFechaDocumentoRef.Name = "dtFechaDocumentoRef"
        '
        'colDOC_ID
        '
        Me.colDOC_ID.Caption = "DOCUMENTO"
        Me.colDOC_ID.FieldName = "DOC_ID"
        Me.colDOC_ID.MinWidth = 40
        Me.colDOC_ID.Name = "colDOC_ID"
        Me.colDOC_ID.Width = 150
        '
        'colNUMERO_DUA
        '
        Me.colNUMERO_DUA.Caption = "NUMERO DUA"
        Me.colNUMERO_DUA.FieldName = "NUMERO_DUA"
        Me.colNUMERO_DUA.MinWidth = 40
        Me.colNUMERO_DUA.Name = "colNUMERO_DUA"
        Me.colNUMERO_DUA.Width = 150
        '
        'colOBSERVACIONES
        '
        Me.colOBSERVACIONES.Caption = "OBSERVACIONES"
        Me.colOBSERVACIONES.FieldName = "OBSERVACIONES"
        Me.colOBSERVACIONES.MinWidth = 40
        Me.colOBSERVACIONES.Name = "colOBSERVACIONES"
        Me.colOBSERVACIONES.Visible = True
        Me.colOBSERVACIONES.VisibleIndex = 3
        Me.colOBSERVACIONES.Width = 150
        '
        'colLAST_UPDATED_BY
        '
        Me.colLAST_UPDATED_BY.Caption = "USUARIO ACTUALIZO"
        Me.colLAST_UPDATED_BY.FieldName = "LAST_UPDATED_BY"
        Me.colLAST_UPDATED_BY.MinWidth = 40
        Me.colLAST_UPDATED_BY.Name = "colLAST_UPDATED_BY"
        Me.colLAST_UPDATED_BY.Width = 150
        '
        'colLAST_UPDATED
        '
        Me.colLAST_UPDATED.Caption = "ACTUALIZADO EL"
        Me.colLAST_UPDATED.FieldName = "LAST_UPDATED"
        Me.colLAST_UPDATED.MinWidth = 40
        Me.colLAST_UPDATED.Name = "colLAST_UPDATED"
        Me.colLAST_UPDATED.Width = 150
        '
        'txtStatus
        '
        Me.txtStatus.Location = New System.Drawing.Point(932, 276)
        Me.txtStatus.Margin = New System.Windows.Forms.Padding(6)
        Me.txtStatus.MenuManager = Me.BarManager1
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.Size = New System.Drawing.Size(310, 40)
        Me.txtStatus.StyleController = Me.LayoutEncabezado
        Me.txtStatus.TabIndex = 46
        '
        'txtNumeroSat
        '
        Me.txtNumeroSat.Location = New System.Drawing.Point(1558, 408)
        Me.txtNumeroSat.Margin = New System.Windows.Forms.Padding(6)
        Me.txtNumeroSat.MenuManager = Me.BarManager1
        Me.txtNumeroSat.Name = "txtNumeroSat"
        Me.txtNumeroSat.Size = New System.Drawing.Size(308, 40)
        Me.txtNumeroSat.StyleController = Me.LayoutEncabezado
        Me.txtNumeroSat.TabIndex = 45
        '
        'txtDomicilioRepresentante
        '
        Me.txtDomicilioRepresentante.Location = New System.Drawing.Point(1161, 602)
        Me.txtDomicilioRepresentante.Margin = New System.Windows.Forms.Padding(6)
        Me.txtDomicilioRepresentante.MenuManager = Me.BarManager1
        Me.txtDomicilioRepresentante.Name = "txtDomicilioRepresentante"
        Me.txtDomicilioRepresentante.Size = New System.Drawing.Size(1241, 40)
        Me.txtDomicilioRepresentante.StyleController = Me.LayoutEncabezado
        Me.txtDomicilioRepresentante.TabIndex = 44
        '
        'txtTipoDeclaranteRepresentante
        '
        Me.txtTipoDeclaranteRepresentante.Location = New System.Drawing.Point(2182, 364)
        Me.txtTipoDeclaranteRepresentante.Margin = New System.Windows.Forms.Padding(6)
        Me.txtTipoDeclaranteRepresentante.MenuManager = Me.BarManager1
        Me.txtTipoDeclaranteRepresentante.Name = "txtTipoDeclaranteRepresentante"
        Me.txtTipoDeclaranteRepresentante.Size = New System.Drawing.Size(220, 40)
        Me.txtTipoDeclaranteRepresentante.StyleController = Me.LayoutEncabezado
        Me.txtTipoDeclaranteRepresentante.TabIndex = 43
        '
        'txtPaisImportador
        '
        Me.txtPaisImportador.Location = New System.Drawing.Point(932, 408)
        Me.txtPaisImportador.Margin = New System.Windows.Forms.Padding(6)
        Me.txtPaisImportador.MenuManager = Me.BarManager1
        Me.txtPaisImportador.Name = "txtPaisImportador"
        Me.txtPaisImportador.Size = New System.Drawing.Size(310, 40)
        Me.txtPaisImportador.StyleController = Me.LayoutEncabezado
        Me.txtPaisImportador.TabIndex = 42
        '
        'txtPaisRepresentante
        '
        Me.txtPaisRepresentante.Location = New System.Drawing.Point(2182, 408)
        Me.txtPaisRepresentante.Margin = New System.Windows.Forms.Padding(6)
        Me.txtPaisRepresentante.MenuManager = Me.BarManager1
        Me.txtPaisRepresentante.Name = "txtPaisRepresentante"
        Me.txtPaisRepresentante.Size = New System.Drawing.Size(220, 40)
        Me.txtPaisRepresentante.StyleController = Me.LayoutEncabezado
        Me.txtPaisRepresentante.TabIndex = 41
        '
        'txtRazonSocialRepresentante
        '
        Me.txtRazonSocialRepresentante.Location = New System.Drawing.Point(932, 496)
        Me.txtRazonSocialRepresentante.Margin = New System.Windows.Forms.Padding(6)
        Me.txtRazonSocialRepresentante.MenuManager = Me.BarManager1
        Me.txtRazonSocialRepresentante.Name = "txtRazonSocialRepresentante"
        Me.txtRazonSocialRepresentante.Size = New System.Drawing.Size(310, 40)
        Me.txtRazonSocialRepresentante.StyleController = Me.LayoutEncabezado
        Me.txtRazonSocialRepresentante.TabIndex = 40
        '
        'txtIdTributariaRepresentante
        '
        Me.txtIdTributariaRepresentante.Location = New System.Drawing.Point(1558, 364)
        Me.txtIdTributariaRepresentante.Margin = New System.Windows.Forms.Padding(6)
        Me.txtIdTributariaRepresentante.MenuManager = Me.BarManager1
        Me.txtIdTributariaRepresentante.Name = "txtIdTributariaRepresentante"
        Me.txtIdTributariaRepresentante.Size = New System.Drawing.Size(308, 40)
        Me.txtIdTributariaRepresentante.StyleController = Me.LayoutEncabezado
        Me.txtIdTributariaRepresentante.TabIndex = 39
        '
        'txtTipoRepresentante
        '
        Me.txtTipoRepresentante.Location = New System.Drawing.Point(1558, 320)
        Me.txtTipoRepresentante.Margin = New System.Windows.Forms.Padding(6)
        Me.txtTipoRepresentante.MenuManager = Me.BarManager1
        Me.txtTipoRepresentante.Name = "txtTipoRepresentante"
        Me.txtTipoRepresentante.Size = New System.Drawing.Size(308, 40)
        Me.txtTipoRepresentante.StyleController = Me.LayoutEncabezado
        Me.txtTipoRepresentante.TabIndex = 38
        '
        'txtModo
        '
        Me.txtModo.Location = New System.Drawing.Point(1558, 56)
        Me.txtModo.Margin = New System.Windows.Forms.Padding(6)
        Me.txtModo.MenuManager = Me.BarManager1
        Me.txtModo.Name = "txtModo"
        Me.txtModo.Properties.Mask.EditMask = "n"
        Me.txtModo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtModo.Size = New System.Drawing.Size(308, 40)
        Me.txtModo.StyleController = Me.LayoutEncabezado
        Me.txtModo.TabIndex = 37
        '
        'txtTipoImportador
        '
        Me.txtTipoImportador.Location = New System.Drawing.Point(304, 494)
        Me.txtTipoImportador.Margin = New System.Windows.Forms.Padding(6)
        Me.txtTipoImportador.MenuManager = Me.BarManager1
        Me.txtTipoImportador.Name = "txtTipoImportador"
        Me.txtTipoImportador.Size = New System.Drawing.Size(312, 40)
        Me.txtTipoImportador.StyleController = Me.LayoutEncabezado
        Me.txtTipoImportador.TabIndex = 35
        '
        'txtNaturalezaTrans
        '
        Me.txtNaturalezaTrans.Location = New System.Drawing.Point(2182, 276)
        Me.txtNaturalezaTrans.Margin = New System.Windows.Forms.Padding(6)
        Me.txtNaturalezaTrans.MenuManager = Me.BarManager1
        Me.txtNaturalezaTrans.Name = "txtNaturalezaTrans"
        Me.txtNaturalezaTrans.Size = New System.Drawing.Size(220, 40)
        Me.txtNaturalezaTrans.StyleController = Me.LayoutEncabezado
        Me.txtNaturalezaTrans.TabIndex = 34
        '
        'txtDepositoFiscalZf
        '
        Me.txtDepositoFiscalZf.Location = New System.Drawing.Point(932, 364)
        Me.txtDepositoFiscalZf.Margin = New System.Windows.Forms.Padding(6)
        Me.txtDepositoFiscalZf.MenuManager = Me.BarManager1
        Me.txtDepositoFiscalZf.Name = "txtDepositoFiscalZf"
        Me.txtDepositoFiscalZf.Size = New System.Drawing.Size(310, 40)
        Me.txtDepositoFiscalZf.StyleController = Me.LayoutEncabezado
        Me.txtDepositoFiscalZf.TabIndex = 33
        '
        'txtRazonSocialImportador
        '
        Me.txtRazonSocialImportador.Location = New System.Drawing.Point(932, 452)
        Me.txtRazonSocialImportador.Margin = New System.Windows.Forms.Padding(6)
        Me.txtRazonSocialImportador.MenuManager = Me.BarManager1
        Me.txtRazonSocialImportador.Name = "txtRazonSocialImportador"
        Me.txtRazonSocialImportador.Size = New System.Drawing.Size(310, 40)
        Me.txtRazonSocialImportador.StyleController = Me.LayoutEncabezado
        Me.txtRazonSocialImportador.TabIndex = 32
        '
        'txtDomicilioImportador
        '
        Me.txtDomicilioImportador.Location = New System.Drawing.Point(1558, 452)
        Me.txtDomicilioImportador.Margin = New System.Windows.Forms.Padding(6)
        Me.txtDomicilioImportador.MenuManager = Me.BarManager1
        Me.txtDomicilioImportador.Name = "txtDomicilioImportador"
        Me.txtDomicilioImportador.Size = New System.Drawing.Size(844, 40)
        Me.txtDomicilioImportador.StyleController = Me.LayoutEncabezado
        Me.txtDomicilioImportador.TabIndex = 36
        '
        'txtIdTributariaImportador
        '
        Me.txtIdTributariaImportador.Location = New System.Drawing.Point(304, 538)
        Me.txtIdTributariaImportador.Margin = New System.Windows.Forms.Padding(6)
        Me.txtIdTributariaImportador.MenuManager = Me.BarManager1
        Me.txtIdTributariaImportador.Name = "txtIdTributariaImportador"
        Me.txtIdTributariaImportador.Size = New System.Drawing.Size(312, 40)
        Me.txtIdTributariaImportador.StyleController = Me.LayoutEncabezado
        Me.txtIdTributariaImportador.TabIndex = 31
        '
        'txtAduanaEntradaSalida
        '
        Me.txtAduanaEntradaSalida.Location = New System.Drawing.Point(1558, 232)
        Me.txtAduanaEntradaSalida.Margin = New System.Windows.Forms.Padding(6)
        Me.txtAduanaEntradaSalida.MenuManager = Me.BarManager1
        Me.txtAduanaEntradaSalida.Name = "txtAduanaEntradaSalida"
        Me.txtAduanaEntradaSalida.Size = New System.Drawing.Size(308, 40)
        Me.txtAduanaEntradaSalida.StyleController = Me.LayoutEncabezado
        Me.txtAduanaEntradaSalida.TabIndex = 30
        '
        'txtClase
        '
        Me.txtClase.Location = New System.Drawing.Point(304, 406)
        Me.txtClase.Margin = New System.Windows.Forms.Padding(6)
        Me.txtClase.MenuManager = Me.BarManager1
        Me.txtClase.Name = "txtClase"
        Me.txtClase.Size = New System.Drawing.Size(312, 40)
        Me.txtClase.StyleController = Me.LayoutEncabezado
        Me.txtClase.TabIndex = 29
        '
        'txtNumeroContenedor
        '
        Me.txtNumeroContenedor.Location = New System.Drawing.Point(1558, 276)
        Me.txtNumeroContenedor.Margin = New System.Windows.Forms.Padding(6)
        Me.txtNumeroContenedor.MenuManager = Me.BarManager1
        Me.txtNumeroContenedor.Name = "txtNumeroContenedor"
        Me.txtNumeroContenedor.Size = New System.Drawing.Size(308, 40)
        Me.txtNumeroContenedor.StyleController = Me.LayoutEncabezado
        Me.txtNumeroContenedor.TabIndex = 28
        '
        'txtEntidadContenedor
        '
        Me.txtEntidadContenedor.Location = New System.Drawing.Point(2182, 320)
        Me.txtEntidadContenedor.Margin = New System.Windows.Forms.Padding(6)
        Me.txtEntidadContenedor.MenuManager = Me.BarManager1
        Me.txtEntidadContenedor.Name = "txtEntidadContenedor"
        Me.txtEntidadContenedor.Size = New System.Drawing.Size(220, 40)
        Me.txtEntidadContenedor.StyleController = Me.LayoutEncabezado
        Me.txtEntidadContenedor.TabIndex = 27
        '
        'txtTipoContenedor
        '
        Me.txtTipoContenedor.Location = New System.Drawing.Point(932, 320)
        Me.txtTipoContenedor.Margin = New System.Windows.Forms.Padding(6)
        Me.txtTipoContenedor.MenuManager = Me.BarManager1
        Me.txtTipoContenedor.Name = "txtTipoContenedor"
        Me.txtTipoContenedor.Size = New System.Drawing.Size(310, 40)
        Me.txtTipoContenedor.StyleController = Me.LayoutEncabezado
        Me.txtTipoContenedor.TabIndex = 26
        '
        'txtAduanaDespachoDestino
        '
        Me.txtAduanaDespachoDestino.Location = New System.Drawing.Point(2182, 232)
        Me.txtAduanaDespachoDestino.Margin = New System.Windows.Forms.Padding(6)
        Me.txtAduanaDespachoDestino.MenuManager = Me.BarManager1
        Me.txtAduanaDespachoDestino.Name = "txtAduanaDespachoDestino"
        Me.txtAduanaDespachoDestino.Size = New System.Drawing.Size(220, 40)
        Me.txtAduanaDespachoDestino.StyleController = Me.LayoutEncabezado
        Me.txtAduanaDespachoDestino.TabIndex = 25
        '
        'txtPaisProcedencia
        '
        Me.txtPaisProcedencia.Location = New System.Drawing.Point(304, 450)
        Me.txtPaisProcedencia.Margin = New System.Windows.Forms.Padding(6)
        Me.txtPaisProcedencia.MenuManager = Me.BarManager1
        Me.txtPaisProcedencia.Name = "txtPaisProcedencia"
        Me.txtPaisProcedencia.Size = New System.Drawing.Size(312, 40)
        Me.txtPaisProcedencia.StyleController = Me.LayoutEncabezado
        Me.txtPaisProcedencia.TabIndex = 24
        '
        'txtTotalPesoBrutoKg
        '
        Me.txtTotalPesoBrutoKg.Location = New System.Drawing.Point(2182, 188)
        Me.txtTotalPesoBrutoKg.Margin = New System.Windows.Forms.Padding(6)
        Me.txtTotalPesoBrutoKg.MenuManager = Me.BarManager1
        Me.txtTotalPesoBrutoKg.Name = "txtTotalPesoBrutoKg"
        Me.txtTotalPesoBrutoKg.Properties.Mask.EditMask = "n2"
        Me.txtTotalPesoBrutoKg.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtTotalPesoBrutoKg.Size = New System.Drawing.Size(220, 40)
        Me.txtTotalPesoBrutoKg.StyleController = Me.LayoutEncabezado
        Me.txtTotalPesoBrutoKg.TabIndex = 23
        '
        'txtTotalBultos
        '
        Me.txtTotalBultos.Location = New System.Drawing.Point(1558, 188)
        Me.txtTotalBultos.Margin = New System.Windows.Forms.Padding(6)
        Me.txtTotalBultos.MenuManager = Me.BarManager1
        Me.txtTotalBultos.Name = "txtTotalBultos"
        Me.txtTotalBultos.Properties.Mask.EditMask = "n0"
        Me.txtTotalBultos.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtTotalBultos.Size = New System.Drawing.Size(308, 40)
        Me.txtTotalBultos.StyleController = Me.LayoutEncabezado
        Me.txtTotalBultos.TabIndex = 22
        '
        'txtTotalLineas
        '
        Me.txtTotalLineas.Location = New System.Drawing.Point(304, 362)
        Me.txtTotalLineas.Margin = New System.Windows.Forms.Padding(6)
        Me.txtTotalLineas.MenuManager = Me.BarManager1
        Me.txtTotalLineas.Name = "txtTotalLineas"
        Me.txtTotalLineas.Properties.Mask.EditMask = "n0"
        Me.txtTotalLineas.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtTotalLineas.Size = New System.Drawing.Size(312, 40)
        Me.txtTotalLineas.StyleController = Me.LayoutEncabezado
        Me.txtTotalLineas.TabIndex = 21
        '
        'txtNumeroOrden
        '
        Me.txtNumeroOrden.Location = New System.Drawing.Point(304, 230)
        Me.txtNumeroOrden.Margin = New System.Windows.Forms.Padding(6)
        Me.txtNumeroOrden.MenuManager = Me.BarManager1
        Me.txtNumeroOrden.Name = "txtNumeroOrden"
        Me.txtNumeroOrden.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtNumeroOrden.Properties.Appearance.Options.UseBackColor = True
        Me.txtNumeroOrden.Size = New System.Drawing.Size(312, 40)
        Me.txtNumeroOrden.StyleController = Me.LayoutEncabezado
        Me.txtNumeroOrden.TabIndex = 20
        '
        'txtDocumentoPadre
        '
        Me.txtDocumentoPadre.Location = New System.Drawing.Point(2182, 12)
        Me.txtDocumentoPadre.Margin = New System.Windows.Forms.Padding(6)
        Me.txtDocumentoPadre.MenuManager = Me.BarManager1
        Me.txtDocumentoPadre.Name = "txtDocumentoPadre"
        Me.txtDocumentoPadre.Properties.Mask.EditMask = "n"
        Me.txtDocumentoPadre.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtDocumentoPadre.Properties.ReadOnly = True
        Me.txtDocumentoPadre.Size = New System.Drawing.Size(220, 40)
        Me.txtDocumentoPadre.StyleController = Me.LayoutEncabezado
        Me.txtDocumentoPadre.TabIndex = 19
        '
        'txtTotalOtrosUsd
        '
        Me.txtTotalOtrosUsd.Location = New System.Drawing.Point(304, 318)
        Me.txtTotalOtrosUsd.Margin = New System.Windows.Forms.Padding(6)
        Me.txtTotalOtrosUsd.MenuManager = Me.BarManager1
        Me.txtTotalOtrosUsd.Name = "txtTotalOtrosUsd"
        Me.txtTotalOtrosUsd.Properties.Mask.EditMask = "n2"
        Me.txtTotalOtrosUsd.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtTotalOtrosUsd.Size = New System.Drawing.Size(312, 40)
        Me.txtTotalOtrosUsd.StyleController = Me.LayoutEncabezado
        Me.txtTotalOtrosUsd.TabIndex = 18
        '
        'txtTotalSeguroUsd
        '
        Me.txtTotalSeguroUsd.Location = New System.Drawing.Point(932, 100)
        Me.txtTotalSeguroUsd.Margin = New System.Windows.Forms.Padding(6)
        Me.txtTotalSeguroUsd.MenuManager = Me.BarManager1
        Me.txtTotalSeguroUsd.Name = "txtTotalSeguroUsd"
        Me.txtTotalSeguroUsd.Properties.Mask.EditMask = "n2"
        Me.txtTotalSeguroUsd.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtTotalSeguroUsd.Size = New System.Drawing.Size(310, 40)
        Me.txtTotalSeguroUsd.StyleController = Me.LayoutEncabezado
        Me.txtTotalSeguroUsd.TabIndex = 17
        '
        'txtTotalFleteUsd
        '
        Me.txtTotalFleteUsd.Location = New System.Drawing.Point(1558, 100)
        Me.txtTotalFleteUsd.Margin = New System.Windows.Forms.Padding(6)
        Me.txtTotalFleteUsd.MenuManager = Me.BarManager1
        Me.txtTotalFleteUsd.Name = "txtTotalFleteUsd"
        Me.txtTotalFleteUsd.Properties.Mask.EditMask = "n2"
        Me.txtTotalFleteUsd.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtTotalFleteUsd.Size = New System.Drawing.Size(308, 40)
        Me.txtTotalFleteUsd.StyleController = Me.LayoutEncabezado
        Me.txtTotalFleteUsd.TabIndex = 16
        '
        'dtFechaAceptacion
        '
        Me.dtFechaAceptacion.EditValue = Nothing
        Me.dtFechaAceptacion.Location = New System.Drawing.Point(932, 232)
        Me.dtFechaAceptacion.Margin = New System.Windows.Forms.Padding(6)
        Me.dtFechaAceptacion.MenuManager = Me.BarManager1
        Me.dtFechaAceptacion.Name = "dtFechaAceptacion"
        Me.dtFechaAceptacion.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtFechaAceptacion.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.dtFechaAceptacion.Size = New System.Drawing.Size(310, 40)
        Me.dtFechaAceptacion.StyleController = Me.LayoutEncabezado
        Me.dtFechaAceptacion.TabIndex = 15
        '
        'txtNumeroDua
        '
        Me.txtNumeroDua.Location = New System.Drawing.Point(932, 12)
        Me.txtNumeroDua.Margin = New System.Windows.Forms.Padding(6)
        Me.txtNumeroDua.MenuManager = Me.BarManager1
        Me.txtNumeroDua.Name = "txtNumeroDua"
        Me.txtNumeroDua.Size = New System.Drawing.Size(310, 40)
        Me.txtNumeroDua.StyleController = Me.LayoutEncabezado
        Me.txtNumeroDua.TabIndex = 14
        '
        'txtTotalGeneral
        '
        Me.txtTotalGeneral.Location = New System.Drawing.Point(1558, 144)
        Me.txtTotalGeneral.Margin = New System.Windows.Forms.Padding(6)
        Me.txtTotalGeneral.MenuManager = Me.BarManager1
        Me.txtTotalGeneral.Name = "txtTotalGeneral"
        Me.txtTotalGeneral.Properties.Mask.EditMask = "n2"
        Me.txtTotalGeneral.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtTotalGeneral.Size = New System.Drawing.Size(308, 40)
        Me.txtTotalGeneral.StyleController = Me.LayoutEncabezado
        Me.txtTotalGeneral.TabIndex = 13
        '
        'txtTotalOtros
        '
        Me.txtTotalOtros.Location = New System.Drawing.Point(932, 188)
        Me.txtTotalOtros.Margin = New System.Windows.Forms.Padding(6)
        Me.txtTotalOtros.MenuManager = Me.BarManager1
        Me.txtTotalOtros.Name = "txtTotalOtros"
        Me.txtTotalOtros.Properties.Mask.EditMask = "n2"
        Me.txtTotalOtros.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtTotalOtros.Size = New System.Drawing.Size(310, 40)
        Me.txtTotalOtros.StyleController = Me.LayoutEncabezado
        Me.txtTotalOtros.TabIndex = 12
        '
        'txtTotalLiquidar
        '
        Me.txtTotalLiquidar.Location = New System.Drawing.Point(932, 144)
        Me.txtTotalLiquidar.Margin = New System.Windows.Forms.Padding(6)
        Me.txtTotalLiquidar.MenuManager = Me.BarManager1
        Me.txtTotalLiquidar.Name = "txtTotalLiquidar"
        Me.txtTotalLiquidar.Properties.Mask.EditMask = "n2"
        Me.txtTotalLiquidar.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtTotalLiquidar.Size = New System.Drawing.Size(310, 40)
        Me.txtTotalLiquidar.StyleController = Me.LayoutEncabezado
        Me.txtTotalLiquidar.TabIndex = 11
        '
        'dtFechaDocumento
        '
        Me.dtFechaDocumento.EditValue = Nothing
        Me.dtFechaDocumento.Location = New System.Drawing.Point(932, 56)
        Me.dtFechaDocumento.Margin = New System.Windows.Forms.Padding(6)
        Me.dtFechaDocumento.MenuManager = Me.BarManager1
        Me.dtFechaDocumento.Name = "dtFechaDocumento"
        Me.dtFechaDocumento.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtFechaDocumento.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.dtFechaDocumento.Properties.Mask.EditMask = "g"
        Me.dtFechaDocumento.Size = New System.Drawing.Size(310, 40)
        Me.dtFechaDocumento.StyleController = Me.LayoutEncabezado
        Me.dtFechaDocumento.TabIndex = 10
        '
        'txtDocId
        '
        Me.txtDocId.Location = New System.Drawing.Point(304, 56)
        Me.txtDocId.Margin = New System.Windows.Forms.Padding(6)
        Me.txtDocId.MenuManager = Me.BarManager1
        Me.txtDocId.Name = "txtDocId"
        Me.txtDocId.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Redo, "", -1, True, False, False, EditorButtonImageOptions1, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, SerializableAppearanceObject2, SerializableAppearanceObject3, SerializableAppearanceObject4, "", Nothing, Nothing, DevExpress.Utils.ToolTipAnchor.[Default])})
        Me.txtDocId.Properties.Mask.EditMask = "n0"
        Me.txtDocId.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtDocId.Properties.ReadOnly = True
        Me.txtDocId.Size = New System.Drawing.Size(312, 40)
        Me.txtDocId.StyleController = Me.LayoutEncabezado
        Me.txtDocId.TabIndex = 9
        '
        'txtTotalFobUsd
        '
        Me.txtTotalFobUsd.Location = New System.Drawing.Point(304, 274)
        Me.txtTotalFobUsd.Margin = New System.Windows.Forms.Padding(6)
        Me.txtTotalFobUsd.MenuManager = Me.BarManager1
        Me.txtTotalFobUsd.Name = "txtTotalFobUsd"
        Me.txtTotalFobUsd.Properties.Mask.EditMask = "n2"
        Me.txtTotalFobUsd.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtTotalFobUsd.Size = New System.Drawing.Size(312, 40)
        Me.txtTotalFobUsd.StyleController = Me.LayoutEncabezado
        Me.txtTotalFobUsd.TabIndex = 8
        '
        'txtTotalValorAduana
        '
        Me.txtTotalValorAduana.Location = New System.Drawing.Point(2182, 144)
        Me.txtTotalValorAduana.Margin = New System.Windows.Forms.Padding(6)
        Me.txtTotalValorAduana.MenuManager = Me.BarManager1
        Me.txtTotalValorAduana.Name = "txtTotalValorAduana"
        Me.txtTotalValorAduana.Properties.Mask.EditMask = "n2"
        Me.txtTotalValorAduana.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtTotalValorAduana.Size = New System.Drawing.Size(220, 40)
        Me.txtTotalValorAduana.StyleController = Me.LayoutEncabezado
        Me.txtTotalValorAduana.TabIndex = 7
        '
        'txtTipoCambio
        '
        Me.txtTipoCambio.Location = New System.Drawing.Point(2182, 100)
        Me.txtTipoCambio.Margin = New System.Windows.Forms.Padding(6)
        Me.txtTipoCambio.MenuManager = Me.BarManager1
        Me.txtTipoCambio.Name = "txtTipoCambio"
        Me.txtTipoCambio.Properties.Mask.EditMask = "n4"
        Me.txtTipoCambio.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtTipoCambio.Size = New System.Drawing.Size(220, 40)
        Me.txtTipoCambio.StyleController = Me.LayoutEncabezado
        Me.txtTipoCambio.TabIndex = 6
        '
        'cmbRegimenPoliza
        '
        Me.cmbRegimenPoliza.Location = New System.Drawing.Point(1558, 12)
        Me.cmbRegimenPoliza.Margin = New System.Windows.Forms.Padding(6)
        Me.cmbRegimenPoliza.MenuManager = Me.BarManager1
        Me.cmbRegimenPoliza.Name = "cmbRegimenPoliza"
        Me.cmbRegimenPoliza.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmbRegimenPoliza.Properties.Appearance.Options.UseBackColor = True
        Me.cmbRegimenPoliza.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        Me.cmbRegimenPoliza.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbRegimenPoliza.Properties.NullText = "[Seleccione Regimen...]"
        Me.cmbRegimenPoliza.Properties.PopupView = Me.GridViewCmbRegimen
        Me.cmbRegimenPoliza.Size = New System.Drawing.Size(308, 40)
        Me.cmbRegimenPoliza.StyleController = Me.LayoutEncabezado
        Me.cmbRegimenPoliza.TabIndex = 5
        '
        'GridViewCmbRegimen
        '
        Me.GridViewCmbRegimen.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridViewCmbRegimen.Name = "GridViewCmbRegimen"
        Me.GridViewCmbRegimen.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridViewCmbRegimen.OptionsView.ShowAutoFilterRow = True
        Me.GridViewCmbRegimen.OptionsView.ShowGroupPanel = False
        '
        'cmbRegimen
        '
        Me.cmbRegimen.EditValue = "[Seleccione Regimen...]"
        Me.cmbRegimen.Location = New System.Drawing.Point(304, 12)
        Me.cmbRegimen.Margin = New System.Windows.Forms.Padding(6)
        Me.cmbRegimen.MenuManager = Me.BarManager1
        Me.cmbRegimen.Name = "cmbRegimen"
        Me.cmbRegimen.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmbRegimen.Properties.Appearance.Options.UseBackColor = True
        Me.cmbRegimen.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbRegimen.Properties.NullText = "[Seleccione Regimen...]"
        Me.cmbRegimen.Properties.PopupView = Me.GridViewCmbRegimenAlmacen
        Me.cmbRegimen.Size = New System.Drawing.Size(312, 40)
        Me.cmbRegimen.StyleController = Me.LayoutEncabezado
        Me.cmbRegimen.TabIndex = 4
        '
        'GridViewCmbRegimenAlmacen
        '
        Me.GridViewCmbRegimenAlmacen.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridViewCmbRegimenAlmacen.Name = "GridViewCmbRegimenAlmacen"
        Me.GridViewCmbRegimenAlmacen.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridViewCmbRegimenAlmacen.OptionsView.ShowGroupPanel = False
        '
        'cmbCliente
        '
        Me.cmbCliente.Location = New System.Drawing.Point(304, 602)
        Me.cmbCliente.Margin = New System.Windows.Forms.Padding(6)
        Me.cmbCliente.MenuManager = Me.BarManager1
        Me.cmbCliente.Name = "cmbCliente"
        Me.cmbCliente.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmbCliente.Properties.Appearance.Options.UseBackColor = True
        Me.cmbCliente.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        Me.cmbCliente.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbCliente.Properties.NullText = ""
        Me.cmbCliente.Properties.PopupView = Me.GridViewCliente
        Me.cmbCliente.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.cmbCliente.Size = New System.Drawing.Size(541, 40)
        Me.cmbCliente.StyleController = Me.LayoutEncabezado
        Me.cmbCliente.TabIndex = 49
        '
        'GridViewCliente
        '
        Me.GridViewCliente.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridViewCliente.Name = "GridViewCliente"
        Me.GridViewCliente.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridViewCliente.OptionsView.ShowAutoFilterRow = True
        Me.GridViewCliente.OptionsView.ShowGroupPanel = False
        '
        'txtTicketNumber
        '
        Me.txtTicketNumber.Location = New System.Drawing.Point(304, 142)
        Me.txtTicketNumber.Margin = New System.Windows.Forms.Padding(6)
        Me.txtTicketNumber.MenuManager = Me.BarManager1
        Me.txtTicketNumber.Name = "txtTicketNumber"
        Me.txtTicketNumber.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtTicketNumber.Properties.Appearance.Options.UseBackColor = True
        Me.txtTicketNumber.Size = New System.Drawing.Size(312, 40)
        Me.txtTicketNumber.StyleController = Me.LayoutEncabezado
        Me.txtTicketNumber.TabIndex = 56
        '
        'lookUpPrioridad
        '
        Me.lookUpPrioridad.Location = New System.Drawing.Point(304, 186)
        Me.lookUpPrioridad.Margin = New System.Windows.Forms.Padding(6)
        Me.lookUpPrioridad.MenuManager = Me.BarManager1
        Me.lookUpPrioridad.Name = "lookUpPrioridad"
        Me.lookUpPrioridad.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.lookUpPrioridad.Properties.ImmediatePopup = True
        Me.lookUpPrioridad.Properties.NullText = ""
        Me.lookUpPrioridad.Properties.PopupView = Me.GridLookUpEdit4View
        Me.lookUpPrioridad.Size = New System.Drawing.Size(312, 40)
        Me.lookUpPrioridad.StyleController = Me.LayoutEncabezado
        Me.lookUpPrioridad.TabIndex = 57
        '
        'GridLookUpEdit4View
        '
        Me.GridLookUpEdit4View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridLookUpEdit4View.Name = "GridLookUpEdit4View"
        Me.GridLookUpEdit4View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridLookUpEdit4View.OptionsView.ShowGroupPanel = False
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.CustomizationFormText = "Root"
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2, Me.LayoutControlItem3, Me.LayoutControlItem4, Me.LayoutControlItem9, Me.LayoutControlItem1, Me.LayoutControlItem5, Me.LayoutControlItem18, Me.LayoutControlItem22, Me.LayoutControlItem23, Me.LayoutControlItem24, Me.LayoutControlItem11, Me.LayoutControlItem8, Me.LayoutControlItem12, Me.LayoutControlItem27, Me.LayoutControlItem25, Me.LayoutControlItem28, Me.LayoutControlItem50, Me.LayoutControlItem14, Me.LayoutControlItem15, Me.LayoutControlItem7, Me.LayoutControlItem34, Me.LayoutControlItem13, Me.LayoutControlItem10, Me.LayoutControlItem20, Me.LayoutControlItem19, Me.LayoutControlItem21, Me.LayoutControlItem26, Me.LayoutControlItem43, Me.LayoutControlItem16, Me.LayoutControlItem44, Me.LayoutControlItem31, Me.LayoutControlItem39, Me.LayoutControlItem36, Me.LayoutControlItem38, Me.LayoutControlItem32, Me.LayoutControlItem30, Me.LayoutControlItem35, Me.LayoutControlItem40, Me.SplitterItem2, Me.SplitterItem3, Me.SplitterItem4, Me.SplitterItem6, Me.LayoutControlItem46, Me.LayoutControlItem45, Me.SplitterItem1, Me.SplitterItem7, Me.LayoutControlItem29, Me.LayoutControlItem41, Me.LayoutControlItem33, Me.SplitterItem5, Me.LayoutControlItem80, Me.LayoutControlItem42, Me.lblPolizaAsegurada, Me.LayoutControlItem82, Me.LayoutControlItem79, Me.LayoutControlItem17, Me.LayoutControlItem37, Me.LayoutControlItem6, Me.layoutTicketFiscal, Me.LayoutControlItem83, Me.LayoutControlItem77, Me.LayoutControlItem84, Me.LayoutControlItem85})
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(2414, 1276)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.cmbRegimenPoliza
        Me.LayoutControlItem2.CustomizationFormText = "Regimen"
        Me.LayoutControlItem2.Location = New System.Drawing.Point(1254, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(604, 44)
        Me.LayoutControlItem2.Text = "Regimen"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(289, 25)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.txtTipoCambio
        Me.LayoutControlItem3.CustomizationFormText = "Tipo Cambio"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(1878, 88)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(516, 44)
        Me.LayoutControlItem3.Text = "Tipo Cambio"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(289, 25)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.txtTotalValorAduana
        Me.LayoutControlItem4.CustomizationFormText = "Total Valor Aduana"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(1878, 132)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(516, 44)
        Me.LayoutControlItem4.Text = "Total Valor Aduana"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(289, 25)
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.txtTotalOtros
        Me.LayoutControlItem9.CustomizationFormText = "Total Otros"
        Me.LayoutControlItem9.Location = New System.Drawing.Point(628, 176)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(606, 44)
        Me.LayoutControlItem9.Text = "Total Otros"
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(289, 25)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.cmbRegimen
        Me.LayoutControlItem1.CustomizationFormText = "Regimen Almacen"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(608, 44)
        Me.LayoutControlItem1.Text = "Regimen Almacen"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(289, 25)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.txtTotalFobUsd
        Me.LayoutControlItem5.CustomizationFormText = "Total FOB USD"
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 262)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(608, 44)
        Me.LayoutControlItem5.Text = "Total FOB USD"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(289, 25)
        '
        'LayoutControlItem18
        '
        Me.LayoutControlItem18.Control = Me.txtTotalLineas
        Me.LayoutControlItem18.CustomizationFormText = "Total Lineas"
        Me.LayoutControlItem18.Location = New System.Drawing.Point(0, 350)
        Me.LayoutControlItem18.Name = "LayoutControlItem18"
        Me.LayoutControlItem18.Size = New System.Drawing.Size(608, 44)
        Me.LayoutControlItem18.Text = "Total Lineas"
        Me.LayoutControlItem18.TextSize = New System.Drawing.Size(289, 25)
        '
        'LayoutControlItem22
        '
        Me.LayoutControlItem22.Control = Me.txtAduanaDespachoDestino
        Me.LayoutControlItem22.CustomizationFormText = "Aduana Despacho o Destino"
        Me.LayoutControlItem22.Location = New System.Drawing.Point(1878, 220)
        Me.LayoutControlItem22.Name = "LayoutControlItem22"
        Me.LayoutControlItem22.Size = New System.Drawing.Size(516, 44)
        Me.LayoutControlItem22.Text = "Aduana Despacho o Destino"
        Me.LayoutControlItem22.TextSize = New System.Drawing.Size(289, 25)
        '
        'LayoutControlItem23
        '
        Me.LayoutControlItem23.Control = Me.txtTipoContenedor
        Me.LayoutControlItem23.CustomizationFormText = "Tipo Contenedor"
        Me.LayoutControlItem23.Location = New System.Drawing.Point(628, 308)
        Me.LayoutControlItem23.Name = "LayoutControlItem23"
        Me.LayoutControlItem23.Size = New System.Drawing.Size(606, 44)
        Me.LayoutControlItem23.Text = "Tipo Contenedor"
        Me.LayoutControlItem23.TextSize = New System.Drawing.Size(289, 25)
        '
        'LayoutControlItem24
        '
        Me.LayoutControlItem24.Control = Me.txtEntidadContenedor
        Me.LayoutControlItem24.CustomizationFormText = "Entidad Contenedor"
        Me.LayoutControlItem24.Location = New System.Drawing.Point(1878, 308)
        Me.LayoutControlItem24.Name = "LayoutControlItem24"
        Me.LayoutControlItem24.Size = New System.Drawing.Size(516, 44)
        Me.LayoutControlItem24.Text = "Entidad Contenedor"
        Me.LayoutControlItem24.TextSize = New System.Drawing.Size(289, 25)
        '
        'LayoutControlItem11
        '
        Me.LayoutControlItem11.Control = Me.txtNumeroDua
        Me.LayoutControlItem11.CustomizationFormText = "Numero DUA"
        Me.LayoutControlItem11.Location = New System.Drawing.Point(628, 0)
        Me.LayoutControlItem11.Name = "LayoutControlItem11"
        Me.LayoutControlItem11.Size = New System.Drawing.Size(606, 44)
        Me.LayoutControlItem11.Text = "Numero DUA"
        Me.LayoutControlItem11.TextSize = New System.Drawing.Size(289, 25)
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.txtTotalLiquidar
        Me.LayoutControlItem8.CustomizationFormText = "Total Liquidar"
        Me.LayoutControlItem8.Location = New System.Drawing.Point(628, 132)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(606, 44)
        Me.LayoutControlItem8.Text = "Total Liquidar"
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(289, 25)
        '
        'LayoutControlItem12
        '
        Me.LayoutControlItem12.Control = Me.dtFechaAceptacion
        Me.LayoutControlItem12.CustomizationFormText = "Fecha Aceptacion"
        Me.LayoutControlItem12.Location = New System.Drawing.Point(628, 220)
        Me.LayoutControlItem12.Name = "LayoutControlItem12"
        Me.LayoutControlItem12.Size = New System.Drawing.Size(606, 44)
        Me.LayoutControlItem12.Text = "Fecha Aceptacion"
        Me.LayoutControlItem12.TextSize = New System.Drawing.Size(289, 25)
        '
        'LayoutControlItem27
        '
        Me.LayoutControlItem27.Control = Me.txtAduanaEntradaSalida
        Me.LayoutControlItem27.CustomizationFormText = "Aduana Entrada o Salida"
        Me.LayoutControlItem27.Location = New System.Drawing.Point(1254, 220)
        Me.LayoutControlItem27.Name = "LayoutControlItem27"
        Me.LayoutControlItem27.Size = New System.Drawing.Size(604, 44)
        Me.LayoutControlItem27.Text = "Aduana Entrada o Salida"
        Me.LayoutControlItem27.TextSize = New System.Drawing.Size(289, 25)
        '
        'LayoutControlItem25
        '
        Me.LayoutControlItem25.Control = Me.txtNumeroContenedor
        Me.LayoutControlItem25.CustomizationFormText = "Numero Contenedor"
        Me.LayoutControlItem25.Location = New System.Drawing.Point(1254, 264)
        Me.LayoutControlItem25.Name = "LayoutControlItem25"
        Me.LayoutControlItem25.Size = New System.Drawing.Size(604, 44)
        Me.LayoutControlItem25.Text = "Numero Contenedor"
        Me.LayoutControlItem25.TextSize = New System.Drawing.Size(289, 25)
        '
        'LayoutControlItem28
        '
        Me.LayoutControlItem28.Control = Me.txtIdTributariaImportador
        Me.LayoutControlItem28.CustomizationFormText = "Id Tributaria Importador"
        Me.LayoutControlItem28.Location = New System.Drawing.Point(0, 526)
        Me.LayoutControlItem28.Name = "LayoutControlItem28"
        Me.LayoutControlItem28.Size = New System.Drawing.Size(608, 44)
        Me.LayoutControlItem28.Text = "Id Tributaria Importador"
        Me.LayoutControlItem28.TextSize = New System.Drawing.Size(289, 25)
        '
        'LayoutControlItem50
        '
        Me.LayoutControlItem50.ContentVisible = False
        Me.LayoutControlItem50.Control = Me.GridDocRefencia
        Me.LayoutControlItem50.CustomizationFormText = "Documentos de Referencia"
        Me.LayoutControlItem50.Location = New System.Drawing.Point(0, 762)
        Me.LayoutControlItem50.Name = "LayoutControlItem50"
        Me.LayoutControlItem50.Size = New System.Drawing.Size(2394, 362)
        Me.LayoutControlItem50.Text = "Documentos de Referencia"
        Me.LayoutControlItem50.TextSize = New System.Drawing.Size(289, 25)
        '
        'LayoutControlItem14
        '
        Me.LayoutControlItem14.Control = Me.txtTotalSeguroUsd
        Me.LayoutControlItem14.CustomizationFormText = "Total Seguro USD"
        Me.LayoutControlItem14.Location = New System.Drawing.Point(628, 88)
        Me.LayoutControlItem14.Name = "LayoutControlItem14"
        Me.LayoutControlItem14.Size = New System.Drawing.Size(606, 44)
        Me.LayoutControlItem14.Text = "Total Seguro USD"
        Me.LayoutControlItem14.TextSize = New System.Drawing.Size(289, 25)
        '
        'LayoutControlItem15
        '
        Me.LayoutControlItem15.Control = Me.txtTotalOtrosUsd
        Me.LayoutControlItem15.CustomizationFormText = "Total Otros USD"
        Me.LayoutControlItem15.Location = New System.Drawing.Point(0, 306)
        Me.LayoutControlItem15.Name = "LayoutControlItem15"
        Me.LayoutControlItem15.Size = New System.Drawing.Size(608, 44)
        Me.LayoutControlItem15.Text = "Total Otros USD"
        Me.LayoutControlItem15.TextSize = New System.Drawing.Size(289, 25)
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.dtFechaDocumento
        Me.LayoutControlItem7.CustomizationFormText = "Fecha Documento"
        Me.LayoutControlItem7.Location = New System.Drawing.Point(628, 44)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(606, 44)
        Me.LayoutControlItem7.Text = "Fecha Documento"
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(289, 25)
        '
        'LayoutControlItem34
        '
        Me.LayoutControlItem34.Control = Me.txtModo
        Me.LayoutControlItem34.CustomizationFormText = "Modo"
        Me.LayoutControlItem34.Location = New System.Drawing.Point(1254, 44)
        Me.LayoutControlItem34.Name = "LayoutControlItem34"
        Me.LayoutControlItem34.Size = New System.Drawing.Size(604, 44)
        Me.LayoutControlItem34.Text = "Modo"
        Me.LayoutControlItem34.TextSize = New System.Drawing.Size(289, 25)
        '
        'LayoutControlItem13
        '
        Me.LayoutControlItem13.Control = Me.txtTotalFleteUsd
        Me.LayoutControlItem13.CustomizationFormText = "Total Flete USD"
        Me.LayoutControlItem13.Location = New System.Drawing.Point(1254, 88)
        Me.LayoutControlItem13.Name = "LayoutControlItem13"
        Me.LayoutControlItem13.Size = New System.Drawing.Size(604, 44)
        Me.LayoutControlItem13.Text = "Total Flete USD"
        Me.LayoutControlItem13.TextSize = New System.Drawing.Size(289, 25)
        '
        'LayoutControlItem10
        '
        Me.LayoutControlItem10.Control = Me.txtTotalGeneral
        Me.LayoutControlItem10.CustomizationFormText = "Total General"
        Me.LayoutControlItem10.Location = New System.Drawing.Point(1254, 132)
        Me.LayoutControlItem10.Name = "LayoutControlItem10"
        Me.LayoutControlItem10.Size = New System.Drawing.Size(604, 44)
        Me.LayoutControlItem10.Text = "Total General"
        Me.LayoutControlItem10.TextSize = New System.Drawing.Size(289, 25)
        '
        'LayoutControlItem20
        '
        Me.LayoutControlItem20.Control = Me.txtTotalPesoBrutoKg
        Me.LayoutControlItem20.CustomizationFormText = "Total Peso Bruto KG"
        Me.LayoutControlItem20.Location = New System.Drawing.Point(1878, 176)
        Me.LayoutControlItem20.Name = "LayoutControlItem20"
        Me.LayoutControlItem20.Size = New System.Drawing.Size(516, 44)
        Me.LayoutControlItem20.Text = "Total Peso Bruto KG"
        Me.LayoutControlItem20.TextSize = New System.Drawing.Size(289, 25)
        '
        'LayoutControlItem19
        '
        Me.LayoutControlItem19.Control = Me.txtTotalBultos
        Me.LayoutControlItem19.CustomizationFormText = "Total Bultos"
        Me.LayoutControlItem19.Location = New System.Drawing.Point(1254, 176)
        Me.LayoutControlItem19.Name = "LayoutControlItem19"
        Me.LayoutControlItem19.Size = New System.Drawing.Size(604, 44)
        Me.LayoutControlItem19.Text = "Total Bultos"
        Me.LayoutControlItem19.TextSize = New System.Drawing.Size(289, 25)
        '
        'LayoutControlItem21
        '
        Me.LayoutControlItem21.Control = Me.txtPaisProcedencia
        Me.LayoutControlItem21.CustomizationFormText = "Pais Procedencia"
        Me.LayoutControlItem21.Location = New System.Drawing.Point(0, 438)
        Me.LayoutControlItem21.Name = "LayoutControlItem21"
        Me.LayoutControlItem21.Size = New System.Drawing.Size(608, 44)
        Me.LayoutControlItem21.Text = "Pais Procedencia"
        Me.LayoutControlItem21.TextSize = New System.Drawing.Size(289, 25)
        '
        'LayoutControlItem26
        '
        Me.LayoutControlItem26.Control = Me.txtClase
        Me.LayoutControlItem26.CustomizationFormText = "Clase"
        Me.LayoutControlItem26.Location = New System.Drawing.Point(0, 394)
        Me.LayoutControlItem26.Name = "LayoutControlItem26"
        Me.LayoutControlItem26.Size = New System.Drawing.Size(608, 44)
        Me.LayoutControlItem26.Text = "Clase"
        Me.LayoutControlItem26.TextSize = New System.Drawing.Size(289, 25)
        '
        'LayoutControlItem43
        '
        Me.LayoutControlItem43.Control = Me.txtStatus
        Me.LayoutControlItem43.CustomizationFormText = "Status"
        Me.LayoutControlItem43.Location = New System.Drawing.Point(628, 264)
        Me.LayoutControlItem43.Name = "LayoutControlItem43"
        Me.LayoutControlItem43.Size = New System.Drawing.Size(606, 44)
        Me.LayoutControlItem43.Text = "Status"
        Me.LayoutControlItem43.TextSize = New System.Drawing.Size(289, 25)
        '
        'LayoutControlItem16
        '
        Me.LayoutControlItem16.Control = Me.txtDocumentoPadre
        Me.LayoutControlItem16.CustomizationFormText = "Documento Padre"
        Me.LayoutControlItem16.Location = New System.Drawing.Point(1878, 0)
        Me.LayoutControlItem16.Name = "LayoutControlItem16"
        Me.LayoutControlItem16.Size = New System.Drawing.Size(516, 44)
        Me.LayoutControlItem16.Text = "Documento Padre"
        Me.LayoutControlItem16.TextSize = New System.Drawing.Size(289, 25)
        '
        'LayoutControlItem44
        '
        Me.LayoutControlItem44.Control = Me.dtFechaLlegada
        Me.LayoutControlItem44.CustomizationFormText = "Fecha Llegada"
        Me.LayoutControlItem44.Location = New System.Drawing.Point(1878, 44)
        Me.LayoutControlItem44.Name = "LayoutControlItem44"
        Me.LayoutControlItem44.Size = New System.Drawing.Size(516, 44)
        Me.LayoutControlItem44.Text = "Fecha Llegada"
        Me.LayoutControlItem44.TextSize = New System.Drawing.Size(289, 25)
        '
        'LayoutControlItem31
        '
        Me.LayoutControlItem31.Control = Me.txtNaturalezaTrans
        Me.LayoutControlItem31.CustomizationFormText = "Naturaleza Transaccion"
        Me.LayoutControlItem31.Location = New System.Drawing.Point(1878, 264)
        Me.LayoutControlItem31.Name = "LayoutControlItem31"
        Me.LayoutControlItem31.Size = New System.Drawing.Size(516, 44)
        Me.LayoutControlItem31.Text = "Naturaleza Transaccion"
        Me.LayoutControlItem31.TextSize = New System.Drawing.Size(289, 25)
        '
        'LayoutControlItem39
        '
        Me.LayoutControlItem39.Control = Me.txtPaisImportador
        Me.LayoutControlItem39.CustomizationFormText = "Pais Importador"
        Me.LayoutControlItem39.Location = New System.Drawing.Point(628, 396)
        Me.LayoutControlItem39.Name = "LayoutControlItem39"
        Me.LayoutControlItem39.Size = New System.Drawing.Size(606, 44)
        Me.LayoutControlItem39.Text = "Pais Importador"
        Me.LayoutControlItem39.TextSize = New System.Drawing.Size(289, 25)
        '
        'LayoutControlItem36
        '
        Me.LayoutControlItem36.Control = Me.txtIdTributariaRepresentante
        Me.LayoutControlItem36.CustomizationFormText = "Id Tributaria Representante"
        Me.LayoutControlItem36.Location = New System.Drawing.Point(1254, 352)
        Me.LayoutControlItem36.Name = "LayoutControlItem36"
        Me.LayoutControlItem36.Size = New System.Drawing.Size(604, 44)
        Me.LayoutControlItem36.Text = "Id Tributaria Representante"
        Me.LayoutControlItem36.TextSize = New System.Drawing.Size(289, 25)
        '
        'LayoutControlItem38
        '
        Me.LayoutControlItem38.Control = Me.txtPaisRepresentante
        Me.LayoutControlItem38.CustomizationFormText = "Pais Representante"
        Me.LayoutControlItem38.Location = New System.Drawing.Point(1878, 396)
        Me.LayoutControlItem38.Name = "LayoutControlItem38"
        Me.LayoutControlItem38.Size = New System.Drawing.Size(516, 44)
        Me.LayoutControlItem38.Text = "Pais Representante"
        Me.LayoutControlItem38.TextSize = New System.Drawing.Size(289, 25)
        '
        'LayoutControlItem32
        '
        Me.LayoutControlItem32.Control = Me.txtTipoImportador
        Me.LayoutControlItem32.CustomizationFormText = "Tipo Importador"
        Me.LayoutControlItem32.Location = New System.Drawing.Point(0, 482)
        Me.LayoutControlItem32.Name = "LayoutControlItem32"
        Me.LayoutControlItem32.Size = New System.Drawing.Size(608, 44)
        Me.LayoutControlItem32.Text = "Tipo Importador"
        Me.LayoutControlItem32.TextSize = New System.Drawing.Size(289, 25)
        '
        'LayoutControlItem30
        '
        Me.LayoutControlItem30.Control = Me.txtDepositoFiscalZf
        Me.LayoutControlItem30.CustomizationFormText = "Deposito Fiscal ZF"
        Me.LayoutControlItem30.Location = New System.Drawing.Point(628, 352)
        Me.LayoutControlItem30.Name = "LayoutControlItem30"
        Me.LayoutControlItem30.Size = New System.Drawing.Size(606, 44)
        Me.LayoutControlItem30.Text = "Deposito Fiscal ZF"
        Me.LayoutControlItem30.TextSize = New System.Drawing.Size(289, 25)
        '
        'LayoutControlItem35
        '
        Me.LayoutControlItem35.Control = Me.txtTipoRepresentante
        Me.LayoutControlItem35.CustomizationFormText = "Tipo Representante"
        Me.LayoutControlItem35.Location = New System.Drawing.Point(1254, 308)
        Me.LayoutControlItem35.Name = "LayoutControlItem35"
        Me.LayoutControlItem35.Size = New System.Drawing.Size(604, 44)
        Me.LayoutControlItem35.Text = "Tipo Representante"
        Me.LayoutControlItem35.TextSize = New System.Drawing.Size(289, 25)
        '
        'LayoutControlItem40
        '
        Me.LayoutControlItem40.Control = Me.txtTipoDeclaranteRepresentante
        Me.LayoutControlItem40.CustomizationFormText = "Tipo Declarante Representante"
        Me.LayoutControlItem40.Location = New System.Drawing.Point(1878, 352)
        Me.LayoutControlItem40.Name = "LayoutControlItem40"
        Me.LayoutControlItem40.Size = New System.Drawing.Size(516, 44)
        Me.LayoutControlItem40.Text = "Tipo Declarante Representante"
        Me.LayoutControlItem40.TextSize = New System.Drawing.Size(289, 25)
        '
        'SplitterItem2
        '
        Me.SplitterItem2.AllowHotTrack = True
        Me.SplitterItem2.CustomizationFormText = "SplitterItem2"
        Me.SplitterItem2.Location = New System.Drawing.Point(0, 570)
        Me.SplitterItem2.Name = "SplitterItem2"
        Me.SplitterItem2.Size = New System.Drawing.Size(2394, 20)
        '
        'SplitterItem3
        '
        Me.SplitterItem3.AllowHotTrack = True
        Me.SplitterItem3.CustomizationFormText = "SplitterItem3"
        Me.SplitterItem3.Location = New System.Drawing.Point(0, 742)
        Me.SplitterItem3.Name = "SplitterItem3"
        Me.SplitterItem3.Size = New System.Drawing.Size(2394, 20)
        '
        'SplitterItem4
        '
        Me.SplitterItem4.AllowHotTrack = True
        Me.SplitterItem4.CustomizationFormText = "SplitterItem4"
        Me.SplitterItem4.Location = New System.Drawing.Point(608, 0)
        Me.SplitterItem4.Name = "SplitterItem4"
        Me.SplitterItem4.Size = New System.Drawing.Size(20, 570)
        '
        'SplitterItem6
        '
        Me.SplitterItem6.AllowHotTrack = True
        Me.SplitterItem6.CustomizationFormText = "SplitterItem6"
        Me.SplitterItem6.Location = New System.Drawing.Point(1858, 0)
        Me.SplitterItem6.Name = "SplitterItem6"
        Me.SplitterItem6.Size = New System.Drawing.Size(20, 440)
        '
        'LayoutControlItem46
        '
        Me.LayoutControlItem46.Control = Me.cmbCliente
        Me.LayoutControlItem46.CustomizationFormText = "Cliente"
        Me.LayoutControlItem46.Location = New System.Drawing.Point(0, 590)
        Me.LayoutControlItem46.Name = "LayoutControlItem46"
        Me.LayoutControlItem46.Size = New System.Drawing.Size(837, 44)
        Me.LayoutControlItem46.Text = "Cliente"
        Me.LayoutControlItem46.TextSize = New System.Drawing.Size(289, 25)
        '
        'LayoutControlItem45
        '
        Me.LayoutControlItem45.Control = Me.txtMarchamo
        Me.LayoutControlItem45.CustomizationFormText = "Numero Marchamo"
        Me.LayoutControlItem45.Location = New System.Drawing.Point(0, 678)
        Me.LayoutControlItem45.Name = "LayoutControlItem45"
        Me.LayoutControlItem45.Size = New System.Drawing.Size(837, 64)
        Me.LayoutControlItem45.Text = "Numero Marchamo"
        Me.LayoutControlItem45.TextSize = New System.Drawing.Size(289, 25)
        '
        'SplitterItem1
        '
        Me.SplitterItem1.AllowHotTrack = True
        Me.SplitterItem1.CustomizationFormText = "SplitterItem1"
        Me.SplitterItem1.Location = New System.Drawing.Point(837, 590)
        Me.SplitterItem1.Name = "SplitterItem1"
        Me.SplitterItem1.Size = New System.Drawing.Size(20, 152)
        '
        'SplitterItem7
        '
        Me.SplitterItem7.AllowHotTrack = True
        Me.SplitterItem7.CustomizationFormText = "SplitterItem7"
        Me.SplitterItem7.Location = New System.Drawing.Point(857, 634)
        Me.SplitterItem7.Name = "SplitterItem7"
        Me.SplitterItem7.Size = New System.Drawing.Size(1537, 20)
        '
        'LayoutControlItem29
        '
        Me.LayoutControlItem29.Control = Me.txtRazonSocialImportador
        Me.LayoutControlItem29.CustomizationFormText = "Razon Social Importador"
        Me.LayoutControlItem29.Location = New System.Drawing.Point(628, 440)
        Me.LayoutControlItem29.Name = "LayoutControlItem29"
        Me.LayoutControlItem29.Size = New System.Drawing.Size(606, 44)
        Me.LayoutControlItem29.Text = "Razon Social Importador"
        Me.LayoutControlItem29.TextSize = New System.Drawing.Size(289, 25)
        '
        'LayoutControlItem41
        '
        Me.LayoutControlItem41.Control = Me.txtDomicilioRepresentante
        Me.LayoutControlItem41.CustomizationFormText = "Domicilio Representante"
        Me.LayoutControlItem41.Location = New System.Drawing.Point(857, 590)
        Me.LayoutControlItem41.Name = "LayoutControlItem41"
        Me.LayoutControlItem41.Size = New System.Drawing.Size(1537, 44)
        Me.LayoutControlItem41.Text = "Domicilio Representante"
        Me.LayoutControlItem41.TextSize = New System.Drawing.Size(289, 25)
        '
        'LayoutControlItem33
        '
        Me.LayoutControlItem33.Control = Me.txtDomicilioImportador
        Me.LayoutControlItem33.CustomizationFormText = "Domicilio Importador"
        Me.LayoutControlItem33.Location = New System.Drawing.Point(1254, 440)
        Me.LayoutControlItem33.Name = "LayoutControlItem33"
        Me.LayoutControlItem33.Size = New System.Drawing.Size(1140, 130)
        Me.LayoutControlItem33.Text = "Domicilio Importador"
        Me.LayoutControlItem33.TextSize = New System.Drawing.Size(289, 25)
        '
        'SplitterItem5
        '
        Me.SplitterItem5.AllowHotTrack = True
        Me.SplitterItem5.CustomizationFormText = "SplitterItem5"
        Me.SplitterItem5.Location = New System.Drawing.Point(1234, 0)
        Me.SplitterItem5.Name = "SplitterItem5"
        Me.SplitterItem5.Size = New System.Drawing.Size(20, 570)
        '
        'LayoutControlItem80
        '
        Me.LayoutControlItem80.Control = Me.cmbAcuerdoHead
        Me.LayoutControlItem80.CustomizationFormText = "Acuerdo Comercial"
        Me.LayoutControlItem80.Location = New System.Drawing.Point(857, 654)
        Me.LayoutControlItem80.Name = "LayoutControlItem80"
        Me.LayoutControlItem80.Size = New System.Drawing.Size(1537, 44)
        Me.LayoutControlItem80.Text = "Acuerdo Comercial"
        Me.LayoutControlItem80.TextSize = New System.Drawing.Size(289, 25)
        '
        'LayoutControlItem42
        '
        Me.LayoutControlItem42.Control = Me.txtNumeroSat
        Me.LayoutControlItem42.CustomizationFormText = "Numero SAT"
        Me.LayoutControlItem42.Location = New System.Drawing.Point(1254, 396)
        Me.LayoutControlItem42.Name = "LayoutControlItem42"
        Me.LayoutControlItem42.Size = New System.Drawing.Size(604, 44)
        Me.LayoutControlItem42.Text = "Numero SAT"
        Me.LayoutControlItem42.TextSize = New System.Drawing.Size(289, 25)
        '
        'lblPolizaAsegurada
        '
        Me.lblPolizaAsegurada.Control = Me.cmbPolizaAsegurada
        Me.lblPolizaAsegurada.CustomizationFormText = "Poliza Asegurada"
        Me.lblPolizaAsegurada.Location = New System.Drawing.Point(0, 634)
        Me.lblPolizaAsegurada.Name = "lblPolizaAsegurada"
        Me.lblPolizaAsegurada.Size = New System.Drawing.Size(837, 44)
        Me.lblPolizaAsegurada.Text = "Poliza Asegurada"
        Me.lblPolizaAsegurada.TextSize = New System.Drawing.Size(289, 25)
        '
        'LayoutControlItem82
        '
        Me.LayoutControlItem82.Control = Me.cmbBodegueros
        Me.LayoutControlItem82.CustomizationFormText = "Operador"
        Me.LayoutControlItem82.Location = New System.Drawing.Point(857, 698)
        Me.LayoutControlItem82.Name = "LayoutControlItem82"
        Me.LayoutControlItem82.Size = New System.Drawing.Size(1537, 44)
        Me.LayoutControlItem82.Text = "Operador"
        Me.LayoutControlItem82.TextSize = New System.Drawing.Size(289, 25)
        '
        'LayoutControlItem79
        '
        Me.LayoutControlItem79.Control = Me.txtCodigoPoliza
        Me.LayoutControlItem79.CustomizationFormText = "Codigo Poliza"
        Me.LayoutControlItem79.Location = New System.Drawing.Point(0, 88)
        Me.LayoutControlItem79.Name = "LayoutControlItem79"
        Me.LayoutControlItem79.Size = New System.Drawing.Size(608, 42)
        Me.LayoutControlItem79.Text = "Codigo Poliza"
        Me.LayoutControlItem79.TextSize = New System.Drawing.Size(289, 25)
        '
        'LayoutControlItem17
        '
        Me.LayoutControlItem17.Control = Me.txtNumeroOrden
        Me.LayoutControlItem17.CustomizationFormText = "Numero Orden"
        Me.LayoutControlItem17.Location = New System.Drawing.Point(0, 218)
        Me.LayoutControlItem17.Name = "LayoutControlItem17"
        Me.LayoutControlItem17.Size = New System.Drawing.Size(608, 44)
        Me.LayoutControlItem17.Text = "Numero Orden"
        Me.LayoutControlItem17.TextSize = New System.Drawing.Size(289, 25)
        '
        'LayoutControlItem37
        '
        Me.LayoutControlItem37.Control = Me.txtRazonSocialRepresentante
        Me.LayoutControlItem37.CustomizationFormText = "Razon Social Representante"
        Me.LayoutControlItem37.Location = New System.Drawing.Point(628, 484)
        Me.LayoutControlItem37.Name = "LayoutControlItem37"
        Me.LayoutControlItem37.Size = New System.Drawing.Size(606, 86)
        Me.LayoutControlItem37.Text = "Razon Social Representante"
        Me.LayoutControlItem37.TextSize = New System.Drawing.Size(289, 25)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.txtDocId
        Me.LayoutControlItem6.CustomizationFormText = "Numero Documento"
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 44)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(608, 44)
        Me.LayoutControlItem6.Text = "Numero Documento"
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(289, 25)
        '
        'layoutTicketFiscal
        '
        Me.layoutTicketFiscal.Control = Me.txtTicketNumber
        Me.layoutTicketFiscal.Location = New System.Drawing.Point(0, 130)
        Me.layoutTicketFiscal.Name = "layoutTicketFiscal"
        Me.layoutTicketFiscal.Size = New System.Drawing.Size(608, 44)
        Me.layoutTicketFiscal.Text = "Ticket"
        Me.layoutTicketFiscal.TextSize = New System.Drawing.Size(289, 25)
        '
        'LayoutControlItem83
        '
        Me.LayoutControlItem83.Control = Me.lookUpPrioridad
        Me.LayoutControlItem83.Location = New System.Drawing.Point(0, 174)
        Me.LayoutControlItem83.Name = "LayoutControlItem83"
        Me.LayoutControlItem83.Size = New System.Drawing.Size(608, 44)
        Me.LayoutControlItem83.Text = "Prioridad"
        Me.LayoutControlItem83.TextSize = New System.Drawing.Size(289, 25)
        '
        'LayoutControlItem77
        '
        Me.LayoutControlItem77.ContentVisible = False
        Me.LayoutControlItem77.Control = Me.GridLookUpEdit1
        Me.LayoutControlItem77.Location = New System.Drawing.Point(0, 1124)
        Me.LayoutControlItem77.Name = "LayoutControlItem77"
        Me.LayoutControlItem77.Size = New System.Drawing.Size(2394, 44)
        Me.LayoutControlItem77.TextSize = New System.Drawing.Size(289, 25)
        '
        'LayoutControlItem84
        '
        Me.LayoutControlItem84.ContentVisible = False
        Me.LayoutControlItem84.Control = Me.GridLookUpEdit2
        Me.LayoutControlItem84.Location = New System.Drawing.Point(0, 1168)
        Me.LayoutControlItem84.Name = "LayoutControlItem84"
        Me.LayoutControlItem84.Size = New System.Drawing.Size(2394, 44)
        Me.LayoutControlItem84.TextSize = New System.Drawing.Size(289, 25)
        '
        'LayoutControlItem85
        '
        Me.LayoutControlItem85.ContentVisible = False
        Me.LayoutControlItem85.Control = Me.GridLookUpEdit3
        Me.LayoutControlItem85.Location = New System.Drawing.Point(0, 1212)
        Me.LayoutControlItem85.Name = "LayoutControlItem85"
        Me.LayoutControlItem85.Size = New System.Drawing.Size(2394, 44)
        Me.LayoutControlItem85.TextSize = New System.Drawing.Size(289, 25)
        '
        'XtraTabDetail
        '
        Me.XtraTabDetail.Controls.Add(Me.LayoutDetalle)
        Me.XtraTabDetail.Margin = New System.Windows.Forms.Padding(6)
        Me.XtraTabDetail.Name = "XtraTabDetail"
        Me.XtraTabDetail.Size = New System.Drawing.Size(2414, 880)
        Me.XtraTabDetail.Text = "Detalle Ingreso"
        '
        'LayoutDetalle
        '
        Me.LayoutDetalle.Controls.Add(Me.UiListaImpuesto)
        Me.LayoutDetalle.Controls.Add(Me.txtPolizaOrigen)
        Me.LayoutDetalle.Controls.Add(Me.txtDocumentoOrigen)
        Me.LayoutDetalle.Controls.Add(Me.txtActualizadaEl)
        Me.LayoutDetalle.Controls.Add(Me.txtActualizadaPor)
        Me.LayoutDetalle.Controls.Add(Me.txtPolizaRelacionada)
        Me.LayoutDetalle.Controls.Add(Me.txtAcuerdo2)
        Me.LayoutDetalle.Controls.Add(Me.txtAcuerdo1)
        Me.LayoutDetalle.Controls.Add(Me.txtRegionCp)
        Me.LayoutDetalle.Controls.Add(Me.txtSeguroUsd)
        Me.LayoutDetalle.Controls.Add(Me.txtFleteUsd)
        Me.LayoutDetalle.Controls.Add(Me.txtFobUsd)
        Me.LayoutDetalle.Controls.Add(Me.txtPaisOrigen)
        Me.LayoutDetalle.Controls.Add(Me.txtGastosVarios)
        Me.LayoutDetalle.Controls.Add(Me.txtImpuestosVarios)
        Me.LayoutDetalle.Controls.Add(Me.GridDetalle)
        Me.LayoutDetalle.Controls.Add(Me.txtValorIva)
        Me.LayoutDetalle.Controls.Add(Me.txtDai)
        Me.LayoutDetalle.Controls.Add(Me.txtVolumen)
        Me.LayoutDetalle.Controls.Add(Me.txtValorAduana)
        Me.LayoutDetalle.Controls.Add(Me.txtCantidad)
        Me.LayoutDetalle.Controls.Add(Me.cmbUnidadPeso)
        Me.LayoutDetalle.Controls.Add(Me.txtPesoNeto)
        Me.LayoutDetalle.Controls.Add(Me.txtClaseLinea)
        Me.LayoutDetalle.Controls.Add(Me.txtBultos)
        Me.LayoutDetalle.Controls.Add(Me.cmbSacCode)
        Me.LayoutDetalle.Controls.Add(Me.txtNumeroLinea)
        Me.LayoutDetalle.Controls.Add(Me.cmbUnidadCantidad)
        Me.LayoutDetalle.Controls.Add(Me.cmbUnidadVolumen)
        Me.LayoutDetalle.Controls.Add(Me.cmbConsignatario)
        Me.LayoutDetalle.Controls.Add(Me.pctDAI)
        Me.LayoutDetalle.Controls.Add(Me.txtDescripcionSku)
        Me.LayoutDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutDetalle.Location = New System.Drawing.Point(0, 0)
        Me.LayoutDetalle.Margin = New System.Windows.Forms.Padding(6)
        Me.LayoutDetalle.Name = "LayoutDetalle"
        Me.LayoutDetalle.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(163, 352, 250, 350)
        Me.LayoutDetalle.Root = Me.LayoutControlGroup2
        Me.LayoutDetalle.Size = New System.Drawing.Size(2414, 880)
        Me.LayoutDetalle.TabIndex = 0
        Me.LayoutDetalle.Text = "Detalle"
        '
        'UiListaImpuesto
        '
        Me.UiListaImpuesto.Location = New System.Drawing.Point(1494, 56)
        Me.UiListaImpuesto.Margin = New System.Windows.Forms.Padding(6)
        Me.UiListaImpuesto.MenuManager = Me.BarManager1
        Me.UiListaImpuesto.Name = "UiListaImpuesto"
        Me.UiListaImpuesto.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.UiListaImpuesto.Properties.DisplayMember = "PARAM_CAPTION"
        Me.UiListaImpuesto.Properties.PopupView = Me.UiListaVistaImpuesto
        Me.UiListaImpuesto.Properties.ValueMember = "MONEY_VALUE"
        Me.UiListaImpuesto.Size = New System.Drawing.Size(908, 40)
        Me.UiListaImpuesto.StyleController = Me.LayoutDetalle
        Me.UiListaImpuesto.TabIndex = 36
        '
        'UiListaVistaImpuesto
        '
        Me.UiListaVistaImpuesto.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.UiColDescripcionImpuesto})
        Me.UiListaVistaImpuesto.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.UiListaVistaImpuesto.Name = "UiListaVistaImpuesto"
        Me.UiListaVistaImpuesto.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.UiListaVistaImpuesto.OptionsView.ShowGroupPanel = False
        '
        'UiColDescripcionImpuesto
        '
        Me.UiColDescripcionImpuesto.Caption = "Descripcion"
        Me.UiColDescripcionImpuesto.FieldName = "PARAM_CAPTION"
        Me.UiColDescripcionImpuesto.Name = "UiColDescripcionImpuesto"
        Me.UiColDescripcionImpuesto.Visible = True
        Me.UiColDescripcionImpuesto.VisibleIndex = 0
        '
        'txtPolizaOrigen
        '
        Me.txtPolizaOrigen.Location = New System.Drawing.Point(2007, 452)
        Me.txtPolizaOrigen.Margin = New System.Windows.Forms.Padding(6)
        Me.txtPolizaOrigen.MenuManager = Me.BarManager1
        Me.txtPolizaOrigen.Name = "txtPolizaOrigen"
        Me.txtPolizaOrigen.Size = New System.Drawing.Size(395, 40)
        Me.txtPolizaOrigen.StyleController = Me.LayoutDetalle
        Me.txtPolizaOrigen.TabIndex = 32
        '
        'txtDocumentoOrigen
        '
        Me.txtDocumentoOrigen.Location = New System.Drawing.Point(831, 408)
        Me.txtDocumentoOrigen.Margin = New System.Windows.Forms.Padding(6)
        Me.txtDocumentoOrigen.MenuManager = Me.BarManager1
        Me.txtDocumentoOrigen.Name = "txtDocumentoOrigen"
        Me.txtDocumentoOrigen.Size = New System.Drawing.Size(439, 40)
        Me.txtDocumentoOrigen.StyleController = Me.LayoutDetalle
        Me.txtDocumentoOrigen.TabIndex = 31
        '
        'txtActualizadaEl
        '
        Me.txtActualizadaEl.Location = New System.Drawing.Point(831, 320)
        Me.txtActualizadaEl.Margin = New System.Windows.Forms.Padding(6)
        Me.txtActualizadaEl.MenuManager = Me.BarManager1
        Me.txtActualizadaEl.Name = "txtActualizadaEl"
        Me.txtActualizadaEl.Size = New System.Drawing.Size(439, 40)
        Me.txtActualizadaEl.StyleController = Me.LayoutDetalle
        Me.txtActualizadaEl.TabIndex = 30
        '
        'txtActualizadaPor
        '
        Me.txtActualizadaPor.Location = New System.Drawing.Point(1494, 364)
        Me.txtActualizadaPor.Margin = New System.Windows.Forms.Padding(6)
        Me.txtActualizadaPor.MenuManager = Me.BarManager1
        Me.txtActualizadaPor.Name = "txtActualizadaPor"
        Me.txtActualizadaPor.Size = New System.Drawing.Size(908, 40)
        Me.txtActualizadaPor.StyleController = Me.LayoutDetalle
        Me.txtActualizadaPor.TabIndex = 29
        '
        'txtPolizaRelacionada
        '
        Me.txtPolizaRelacionada.Location = New System.Drawing.Point(1408, 452)
        Me.txtPolizaRelacionada.Margin = New System.Windows.Forms.Padding(6)
        Me.txtPolizaRelacionada.MenuManager = Me.BarManager1
        Me.txtPolizaRelacionada.Name = "txtPolizaRelacionada"
        Me.txtPolizaRelacionada.Size = New System.Drawing.Size(395, 40)
        Me.txtPolizaRelacionada.StyleController = Me.LayoutDetalle
        Me.txtPolizaRelacionada.TabIndex = 28
        '
        'txtAcuerdo2
        '
        Me.txtAcuerdo2.Location = New System.Drawing.Point(831, 364)
        Me.txtAcuerdo2.Margin = New System.Windows.Forms.Padding(6)
        Me.txtAcuerdo2.MenuManager = Me.BarManager1
        Me.txtAcuerdo2.Name = "txtAcuerdo2"
        Me.txtAcuerdo2.Size = New System.Drawing.Size(439, 40)
        Me.txtAcuerdo2.StyleController = Me.LayoutDetalle
        Me.txtAcuerdo2.TabIndex = 27
        '
        'txtAcuerdo1
        '
        Me.txtAcuerdo1.Location = New System.Drawing.Point(212, 408)
        Me.txtAcuerdo1.Margin = New System.Windows.Forms.Padding(6)
        Me.txtAcuerdo1.MenuManager = Me.BarManager1
        Me.txtAcuerdo1.Name = "txtAcuerdo1"
        Me.txtAcuerdo1.Size = New System.Drawing.Size(395, 40)
        Me.txtAcuerdo1.StyleController = Me.LayoutDetalle
        Me.txtAcuerdo1.TabIndex = 26
        '
        'txtRegionCp
        '
        Me.txtRegionCp.Location = New System.Drawing.Point(212, 364)
        Me.txtRegionCp.Margin = New System.Windows.Forms.Padding(6)
        Me.txtRegionCp.MenuManager = Me.BarManager1
        Me.txtRegionCp.Name = "txtRegionCp"
        Me.txtRegionCp.Size = New System.Drawing.Size(395, 40)
        Me.txtRegionCp.StyleController = Me.LayoutDetalle
        Me.txtRegionCp.TabIndex = 25
        '
        'txtSeguroUsd
        '
        Me.txtSeguroUsd.Location = New System.Drawing.Point(1494, 320)
        Me.txtSeguroUsd.Margin = New System.Windows.Forms.Padding(6)
        Me.txtSeguroUsd.MenuManager = Me.BarManager1
        Me.txtSeguroUsd.Name = "txtSeguroUsd"
        Me.txtSeguroUsd.Size = New System.Drawing.Size(908, 40)
        Me.txtSeguroUsd.StyleController = Me.LayoutDetalle
        Me.txtSeguroUsd.TabIndex = 24
        '
        'txtFleteUsd
        '
        Me.txtFleteUsd.Location = New System.Drawing.Point(831, 276)
        Me.txtFleteUsd.Margin = New System.Windows.Forms.Padding(6)
        Me.txtFleteUsd.MenuManager = Me.BarManager1
        Me.txtFleteUsd.Name = "txtFleteUsd"
        Me.txtFleteUsd.Size = New System.Drawing.Size(439, 40)
        Me.txtFleteUsd.StyleController = Me.LayoutDetalle
        Me.txtFleteUsd.TabIndex = 23
        '
        'txtFobUsd
        '
        Me.txtFobUsd.Location = New System.Drawing.Point(212, 320)
        Me.txtFobUsd.Margin = New System.Windows.Forms.Padding(6)
        Me.txtFobUsd.MenuManager = Me.BarManager1
        Me.txtFobUsd.Name = "txtFobUsd"
        Me.txtFobUsd.Properties.Mask.EditMask = "n2"
        Me.txtFobUsd.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtFobUsd.Size = New System.Drawing.Size(395, 40)
        Me.txtFobUsd.StyleController = Me.LayoutDetalle
        Me.txtFobUsd.TabIndex = 22
        '
        'txtPaisOrigen
        '
        Me.txtPaisOrigen.Location = New System.Drawing.Point(1494, 276)
        Me.txtPaisOrigen.Margin = New System.Windows.Forms.Padding(6)
        Me.txtPaisOrigen.MenuManager = Me.BarManager1
        Me.txtPaisOrigen.Name = "txtPaisOrigen"
        Me.txtPaisOrigen.Size = New System.Drawing.Size(908, 40)
        Me.txtPaisOrigen.StyleController = Me.LayoutDetalle
        Me.txtPaisOrigen.TabIndex = 21
        '
        'txtGastosVarios
        '
        Me.txtGastosVarios.Location = New System.Drawing.Point(831, 232)
        Me.txtGastosVarios.Margin = New System.Windows.Forms.Padding(6)
        Me.txtGastosVarios.MenuManager = Me.BarManager1
        Me.txtGastosVarios.Name = "txtGastosVarios"
        Me.txtGastosVarios.Properties.Mask.EditMask = "n2"
        Me.txtGastosVarios.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtGastosVarios.Size = New System.Drawing.Size(439, 40)
        Me.txtGastosVarios.StyleController = Me.LayoutDetalle
        Me.txtGastosVarios.TabIndex = 20
        '
        'txtImpuestosVarios
        '
        Me.txtImpuestosVarios.Location = New System.Drawing.Point(212, 276)
        Me.txtImpuestosVarios.Margin = New System.Windows.Forms.Padding(6)
        Me.txtImpuestosVarios.MenuManager = Me.BarManager1
        Me.txtImpuestosVarios.Name = "txtImpuestosVarios"
        Me.txtImpuestosVarios.Properties.Mask.EditMask = "n2"
        Me.txtImpuestosVarios.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtImpuestosVarios.Size = New System.Drawing.Size(395, 40)
        Me.txtImpuestosVarios.StyleController = Me.LayoutDetalle
        Me.txtImpuestosVarios.TabIndex = 19
        '
        'GridDetalle
        '
        Me.GridDetalle.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(6)
        Me.GridDetalle.Location = New System.Drawing.Point(212, 496)
        Me.GridDetalle.MainView = Me.GridViewDetalle
        Me.GridDetalle.Margin = New System.Windows.Forms.Padding(6)
        Me.GridDetalle.MenuManager = Me.BarManager1
        Me.GridDetalle.Name = "GridDetalle"
        Me.GridDetalle.Size = New System.Drawing.Size(2190, 372)
        Me.GridDetalle.TabIndex = 18
        Me.GridDetalle.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewDetalle})
        '
        'GridViewDetalle
        '
        Me.GridViewDetalle.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridViewDetalle.Appearance.FooterPanel.Options.UseBackColor = True
        Me.GridViewDetalle.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand1})
        Me.GridViewDetalle.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.colNUMEROLINEA, Me.colDESCRIPCIONPRODUCTO, Me.colBULTOS, Me.colCANTIDAD, Me.colUNIDADCANTIDAD, Me.colVALORADUANA, Me.colVALORDAI, Me.colVALORIVA, Me.colCLASE, Me.colPESONETO, Me.colUNIDADPESO, Me.colVOLUMEN, Me.colUNIDADVOLUMEN, Me.colCODIGOSAC, Me.colIMPUESTOSVARIOS, Me.colGASTOSVARIOS, Me.colPAISORIGEN, Me.colFOBUSD, Me.colFLETEUSD, Me.colSEGUROUSD, Me.colREGIONCP, Me.colACUERDO1, Me.colACUERDO2, Me.colPOLIZARELACIONADA, Me.colACTUALIZADAPOR, Me.colACTUALIZADAEL, Me.colDOCUMENTOORIGEN, Me.colPOLIZAORIGEN, Me.colACUERDOCOMERCIAL, Me.colCONSIGNATARIO, Me.colPCTDAI, Me.colMaterialId})
        Me.GridViewDetalle.DetailHeight = 673
        Me.GridViewDetalle.FixedLineWidth = 4
        Me.GridViewDetalle.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridViewDetalle.GridControl = Me.GridDetalle
        Me.GridViewDetalle.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CUSTOMS_AMOUNT", Me.colVALORADUANA, "(Total Aduana = {0:c2})"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "DAI", Me.colVALORDAI, "(Total DAI = {0:c2})"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "IVA", Me.colVALORIVA, "(Total IVA = {0:c2})")})
        Me.GridViewDetalle.Name = "GridViewDetalle"
        Me.GridViewDetalle.OptionsBehavior.Editable = False
        Me.GridViewDetalle.OptionsSelection.MultiSelect = True
        Me.GridViewDetalle.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GridViewDetalle.OptionsView.ShowAutoFilterRow = True
        Me.GridViewDetalle.OptionsView.ShowFooter = True
        Me.GridViewDetalle.OptionsView.ShowGroupPanel = False
        '
        'GridBand1
        '
        Me.GridBand1.Caption = "Productos contenidos en el documento"
        Me.GridBand1.Columns.Add(Me.colNUMEROLINEA)
        Me.GridBand1.Columns.Add(Me.colDESCRIPCIONPRODUCTO)
        Me.GridBand1.Columns.Add(Me.colBULTOS)
        Me.GridBand1.Columns.Add(Me.colVALORADUANA)
        Me.GridBand1.Columns.Add(Me.colVALORIVA)
        Me.GridBand1.Columns.Add(Me.colVALORDAI)
        Me.GridBand1.MinWidth = 40
        Me.GridBand1.Name = "GridBand1"
        Me.GridBand1.VisibleIndex = 0
        Me.GridBand1.Width = 1846
        '
        'colNUMEROLINEA
        '
        Me.colNUMEROLINEA.Caption = "NUMERO LINEA"
        Me.colNUMEROLINEA.FieldName = "LINE_NUMBER"
        Me.colNUMEROLINEA.MinWidth = 40
        Me.colNUMEROLINEA.Name = "colNUMEROLINEA"
        Me.colNUMEROLINEA.Visible = True
        Me.colNUMEROLINEA.Width = 188
        '
        'colDESCRIPCIONPRODUCTO
        '
        Me.colDESCRIPCIONPRODUCTO.Caption = "DESCRIPCION PRODUCTO"
        Me.colDESCRIPCIONPRODUCTO.FieldName = "SKU_DESCRIPTION"
        Me.colDESCRIPCIONPRODUCTO.MinWidth = 40
        Me.colDESCRIPCIONPRODUCTO.Name = "colDESCRIPCIONPRODUCTO"
        Me.colDESCRIPCIONPRODUCTO.Visible = True
        Me.colDESCRIPCIONPRODUCTO.Width = 294
        '
        'colBULTOS
        '
        Me.colBULTOS.Caption = "BULTOS"
        Me.colBULTOS.FieldName = "BULTOS"
        Me.colBULTOS.MinWidth = 40
        Me.colBULTOS.Name = "colBULTOS"
        Me.colBULTOS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "BULTOS", "(Total Bultos = {0:n2})")})
        Me.colBULTOS.Visible = True
        Me.colBULTOS.Width = 242
        '
        'colVALORADUANA
        '
        Me.colVALORADUANA.Caption = "VALOR ADUANA"
        Me.colVALORADUANA.FieldName = "CUSTOMS_AMOUNT"
        Me.colVALORADUANA.MinWidth = 40
        Me.colVALORADUANA.Name = "colVALORADUANA"
        Me.colVALORADUANA.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CUSTOMS_AMOUNT", "(Total Aduana = {0:c2})")})
        Me.colVALORADUANA.Visible = True
        Me.colVALORADUANA.Width = 258
        '
        'colVALORIVA
        '
        Me.colVALORIVA.Caption = "VALOR IVA"
        Me.colVALORIVA.FieldName = "IVA"
        Me.colVALORIVA.MinWidth = 40
        Me.colVALORIVA.Name = "colVALORIVA"
        Me.colVALORIVA.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "IVA", "(Total IVA = {0:c2})")})
        Me.colVALORIVA.Visible = True
        Me.colVALORIVA.Width = 218
        '
        'colVALORDAI
        '
        Me.colVALORDAI.Caption = "VALOR DAI"
        Me.colVALORDAI.FieldName = "DAI"
        Me.colVALORDAI.MinWidth = 40
        Me.colVALORDAI.Name = "colVALORDAI"
        Me.colVALORDAI.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "DAI", "(Total DAI = {0:c2})")})
        Me.colVALORDAI.Visible = True
        Me.colVALORDAI.Width = 646
        '
        'colCANTIDAD
        '
        Me.colCANTIDAD.Caption = "CANTIDAD"
        Me.colCANTIDAD.FieldName = "QTY"
        Me.colCANTIDAD.MinWidth = 40
        Me.colCANTIDAD.Name = "colCANTIDAD"
        Me.colCANTIDAD.Visible = True
        Me.colCANTIDAD.Width = 122
        '
        'colUNIDADCANTIDAD
        '
        Me.colUNIDADCANTIDAD.Caption = "UNIDAD CANTIDAD"
        Me.colUNIDADCANTIDAD.FieldName = "QTY_UNIT"
        Me.colUNIDADCANTIDAD.MinWidth = 40
        Me.colUNIDADCANTIDAD.Name = "colUNIDADCANTIDAD"
        Me.colUNIDADCANTIDAD.Visible = True
        Me.colUNIDADCANTIDAD.Width = 206
        '
        'colCLASE
        '
        Me.colCLASE.Caption = "CLASE"
        Me.colCLASE.FieldName = "CLASE"
        Me.colCLASE.MinWidth = 40
        Me.colCLASE.Name = "colCLASE"
        Me.colCLASE.Visible = True
        Me.colCLASE.Width = 80
        '
        'colPESONETO
        '
        Me.colPESONETO.Caption = "PESO NETO"
        Me.colPESONETO.FieldName = "NET_WEIGTH"
        Me.colPESONETO.MinWidth = 40
        Me.colPESONETO.Name = "colPESONETO"
        Me.colPESONETO.Visible = True
        Me.colPESONETO.Width = 130
        '
        'colUNIDADPESO
        '
        Me.colUNIDADPESO.Caption = "UNIDAD PESO"
        Me.colUNIDADPESO.FieldName = "WEIGTH_UNIT"
        Me.colUNIDADPESO.MinWidth = 40
        Me.colUNIDADPESO.Name = "colUNIDADPESO"
        Me.colUNIDADPESO.Visible = True
        Me.colUNIDADPESO.Width = 154
        '
        'colVOLUMEN
        '
        Me.colVOLUMEN.Caption = "VOLUMEN"
        Me.colVOLUMEN.FieldName = "VOLUME"
        Me.colVOLUMEN.MinWidth = 40
        Me.colVOLUMEN.Name = "colVOLUMEN"
        Me.colVOLUMEN.Visible = True
        Me.colVOLUMEN.Width = 112
        '
        'colUNIDADVOLUMEN
        '
        Me.colUNIDADVOLUMEN.Caption = "UNIDAD VOLUMEN"
        Me.colUNIDADVOLUMEN.FieldName = "VOLUME_UNIT"
        Me.colUNIDADVOLUMEN.MinWidth = 40
        Me.colUNIDADVOLUMEN.Name = "colUNIDADVOLUMEN"
        Me.colUNIDADVOLUMEN.Visible = True
        Me.colUNIDADVOLUMEN.Width = 196
        '
        'colCODIGOSAC
        '
        Me.colCODIGOSAC.Caption = "CODIGO SAC"
        Me.colCODIGOSAC.FieldName = "SAC_CODE"
        Me.colCODIGOSAC.MinWidth = 40
        Me.colCODIGOSAC.Name = "colCODIGOSAC"
        Me.colCODIGOSAC.Visible = True
        Me.colCODIGOSAC.Width = 146
        '
        'colIMPUESTOSVARIOS
        '
        Me.colIMPUESTOSVARIOS.Caption = "IMPUESTOS VARIOS"
        Me.colIMPUESTOSVARIOS.FieldName = "MISC_TAXES"
        Me.colIMPUESTOSVARIOS.MinWidth = 40
        Me.colIMPUESTOSVARIOS.Name = "colIMPUESTOSVARIOS"
        Me.colIMPUESTOSVARIOS.Visible = True
        Me.colIMPUESTOSVARIOS.Width = 214
        '
        'colGASTOSVARIOS
        '
        Me.colGASTOSVARIOS.Caption = "GASTOS VARIOS"
        Me.colGASTOSVARIOS.FieldName = "MISC_EXPENSES"
        Me.colGASTOSVARIOS.MinWidth = 40
        Me.colGASTOSVARIOS.Name = "colGASTOSVARIOS"
        Me.colGASTOSVARIOS.Visible = True
        Me.colGASTOSVARIOS.Width = 180
        '
        'colPAISORIGEN
        '
        Me.colPAISORIGEN.Caption = "PAIS ORIGEN"
        Me.colPAISORIGEN.FieldName = "ORIGIN_COUNTRY"
        Me.colPAISORIGEN.MinWidth = 40
        Me.colPAISORIGEN.Name = "colPAISORIGEN"
        Me.colPAISORIGEN.Visible = True
        Me.colPAISORIGEN.Width = 148
        '
        'colFOBUSD
        '
        Me.colFOBUSD.Caption = "FOB USD"
        Me.colFOBUSD.FieldName = "FOB_USD"
        Me.colFOBUSD.MinWidth = 40
        Me.colFOBUSD.Name = "colFOBUSD"
        Me.colFOBUSD.Visible = True
        Me.colFOBUSD.Width = 104
        '
        'colFLETEUSD
        '
        Me.colFLETEUSD.Caption = "FLETE USD"
        Me.colFLETEUSD.FieldName = "FREIGTH_USD"
        Me.colFLETEUSD.MinWidth = 40
        Me.colFLETEUSD.Name = "colFLETEUSD"
        Me.colFLETEUSD.Visible = True
        Me.colFLETEUSD.Width = 122
        '
        'colSEGUROUSD
        '
        Me.colSEGUROUSD.Caption = "SEGURO USD"
        Me.colSEGUROUSD.FieldName = "INSURANCE_USD"
        Me.colSEGUROUSD.MinWidth = 40
        Me.colSEGUROUSD.Name = "colSEGUROUSD"
        Me.colSEGUROUSD.Visible = True
        Me.colSEGUROUSD.Width = 146
        '
        'colREGIONCP
        '
        Me.colREGIONCP.Caption = "REGION CP"
        Me.colREGIONCP.FieldName = "REGION_CP"
        Me.colREGIONCP.MinWidth = 40
        Me.colREGIONCP.Name = "colREGIONCP"
        Me.colREGIONCP.Visible = True
        Me.colREGIONCP.Width = 128
        '
        'colACUERDO1
        '
        Me.colACUERDO1.Caption = "ACUERDO1"
        Me.colACUERDO1.FieldName = "AGREEMENT_1"
        Me.colACUERDO1.MinWidth = 40
        Me.colACUERDO1.Name = "colACUERDO1"
        Me.colACUERDO1.Visible = True
        Me.colACUERDO1.Width = 128
        '
        'colACUERDO2
        '
        Me.colACUERDO2.Caption = "ACUERDO2"
        Me.colACUERDO2.FieldName = "AGREEMENT_2"
        Me.colACUERDO2.MinWidth = 40
        Me.colACUERDO2.Name = "colACUERDO2"
        Me.colACUERDO2.Visible = True
        Me.colACUERDO2.Width = 128
        '
        'colPOLIZARELACIONADA
        '
        Me.colPOLIZARELACIONADA.Caption = "POLIZA RELACIONADA"
        Me.colPOLIZARELACIONADA.FieldName = "RELATED_POLIZA"
        Me.colPOLIZARELACIONADA.MinWidth = 40
        Me.colPOLIZARELACIONADA.Name = "colPOLIZARELACIONADA"
        Me.colPOLIZARELACIONADA.Visible = True
        Me.colPOLIZARELACIONADA.Width = 240
        '
        'colACTUALIZADAPOR
        '
        Me.colACTUALIZADAPOR.Caption = "ACTUALIZADA POR"
        Me.colACTUALIZADAPOR.FieldName = "LAST_UPDATED_BY"
        Me.colACTUALIZADAPOR.MinWidth = 40
        Me.colACTUALIZADAPOR.Name = "colACTUALIZADAPOR"
        Me.colACTUALIZADAPOR.Visible = True
        Me.colACTUALIZADAPOR.Width = 206
        '
        'colACTUALIZADAEL
        '
        Me.colACTUALIZADAEL.Caption = "ACTUALIZADA EL"
        Me.colACTUALIZADAEL.FieldName = "LAST_UPDATED"
        Me.colACTUALIZADAEL.MinWidth = 40
        Me.colACTUALIZADAEL.Name = "colACTUALIZADAEL"
        Me.colACTUALIZADAEL.Visible = True
        Me.colACTUALIZADAEL.Width = 186
        '
        'colDOCUMENTOORIGEN
        '
        Me.colDOCUMENTOORIGEN.Caption = "DOCUMENTO ORIGEN"
        Me.colDOCUMENTOORIGEN.FieldName = "ORIGIN_DOC_ID"
        Me.colDOCUMENTOORIGEN.MinWidth = 40
        Me.colDOCUMENTOORIGEN.Name = "colDOCUMENTOORIGEN"
        Me.colDOCUMENTOORIGEN.Visible = True
        Me.colDOCUMENTOORIGEN.Width = 230
        '
        'colPOLIZAORIGEN
        '
        Me.colPOLIZAORIGEN.Caption = "POLIZA ORIGEN"
        Me.colPOLIZAORIGEN.FieldName = "CODIGO_POLIZA_ORIGEN"
        Me.colPOLIZAORIGEN.MinWidth = 40
        Me.colPOLIZAORIGEN.Name = "colPOLIZAORIGEN"
        Me.colPOLIZAORIGEN.Visible = True
        Me.colPOLIZAORIGEN.Width = 174
        '
        'colACUERDOCOMERCIAL
        '
        Me.colACUERDOCOMERCIAL.Caption = "ACUERDO COMERCIAL"
        Me.colACUERDOCOMERCIAL.MinWidth = 40
        Me.colACUERDOCOMERCIAL.Name = "colACUERDOCOMERCIAL"
        Me.colACUERDOCOMERCIAL.Visible = True
        Me.colACUERDOCOMERCIAL.Width = 240
        '
        'colCONSIGNATARIO
        '
        Me.colCONSIGNATARIO.Caption = "CONSIGNATARIO"
        Me.colCONSIGNATARIO.FieldName = "CLIENT_CODE"
        Me.colCONSIGNATARIO.MinWidth = 40
        Me.colCONSIGNATARIO.Name = "colCONSIGNATARIO"
        Me.colCONSIGNATARIO.Visible = True
        Me.colCONSIGNATARIO.Width = 188
        '
        'colPCTDAI
        '
        Me.colPCTDAI.Caption = "PCT DAI"
        Me.colPCTDAI.FieldName = "PCTDAI"
        Me.colPCTDAI.MinWidth = 40
        Me.colPCTDAI.Name = "colPCTDAI"
        Me.colPCTDAI.Visible = True
        Me.colPCTDAI.Width = 150
        '
        'colMaterialId
        '
        Me.colMaterialId.Caption = "BandedGridColumn1"
        Me.colMaterialId.FieldName = "MATERIAL_ID"
        Me.colMaterialId.MinWidth = 40
        Me.colMaterialId.Name = "colMaterialId"
        Me.colMaterialId.Visible = True
        Me.colMaterialId.Width = 150
        '
        'txtValorIva
        '
        Me.txtValorIva.Location = New System.Drawing.Point(1494, 144)
        Me.txtValorIva.Margin = New System.Windows.Forms.Padding(6)
        Me.txtValorIva.MenuManager = Me.BarManager1
        Me.txtValorIva.Name = "txtValorIva"
        Me.txtValorIva.Properties.DisplayFormat.FormatString = "G7"
        Me.txtValorIva.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.txtValorIva.Properties.Mask.EditMask = "n6"
        Me.txtValorIva.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtValorIva.Size = New System.Drawing.Size(908, 40)
        Me.txtValorIva.StyleController = Me.LayoutDetalle
        Me.txtValorIva.TabIndex = 17
        '
        'txtDai
        '
        Me.txtDai.Location = New System.Drawing.Point(831, 100)
        Me.txtDai.Margin = New System.Windows.Forms.Padding(6)
        Me.txtDai.MenuManager = Me.BarManager1
        Me.txtDai.Name = "txtDai"
        Me.txtDai.Properties.Mask.EditMask = "n6"
        Me.txtDai.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtDai.Size = New System.Drawing.Size(439, 40)
        Me.txtDai.StyleController = Me.LayoutDetalle
        Me.txtDai.TabIndex = 16
        '
        'txtVolumen
        '
        Me.txtVolumen.Location = New System.Drawing.Point(212, 232)
        Me.txtVolumen.Margin = New System.Windows.Forms.Padding(6)
        Me.txtVolumen.MenuManager = Me.BarManager1
        Me.txtVolumen.Name = "txtVolumen"
        Me.txtVolumen.Properties.Mask.EditMask = "n6"
        Me.txtVolumen.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtVolumen.Size = New System.Drawing.Size(395, 40)
        Me.txtVolumen.StyleController = Me.LayoutDetalle
        Me.txtVolumen.TabIndex = 14
        '
        'txtValorAduana
        '
        Me.txtValorAduana.EditValue = "0"
        Me.txtValorAduana.Location = New System.Drawing.Point(212, 100)
        Me.txtValorAduana.Margin = New System.Windows.Forms.Padding(6)
        Me.txtValorAduana.MenuManager = Me.BarManager1
        Me.txtValorAduana.Name = "txtValorAduana"
        Me.txtValorAduana.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtValorAduana.Properties.Appearance.Options.UseBackColor = True
        Me.txtValorAduana.Properties.Mask.EditMask = "n2"
        Me.txtValorAduana.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtValorAduana.Size = New System.Drawing.Size(395, 40)
        Me.txtValorAduana.StyleController = Me.LayoutDetalle
        Me.txtValorAduana.TabIndex = 12
        '
        'txtCantidad
        '
        Me.txtCantidad.Location = New System.Drawing.Point(831, 56)
        Me.txtCantidad.Margin = New System.Windows.Forms.Padding(6)
        Me.txtCantidad.MenuManager = Me.BarManager1
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Properties.Mask.EditMask = "n4"
        Me.txtCantidad.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtCantidad.Size = New System.Drawing.Size(439, 40)
        Me.txtCantidad.StyleController = Me.LayoutDetalle
        Me.txtCantidad.TabIndex = 11
        '
        'cmbUnidadPeso
        '
        Me.cmbUnidadPeso.Location = New System.Drawing.Point(1494, 188)
        Me.cmbUnidadPeso.Margin = New System.Windows.Forms.Padding(6)
        Me.cmbUnidadPeso.MenuManager = Me.BarManager1
        Me.cmbUnidadPeso.Name = "cmbUnidadPeso"
        Me.cmbUnidadPeso.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbUnidadPeso.Properties.NullText = "[Seleccione Unidad...]"
        Me.cmbUnidadPeso.Properties.PopupView = Me.GridView4
        Me.cmbUnidadPeso.Size = New System.Drawing.Size(908, 40)
        Me.cmbUnidadPeso.StyleController = Me.LayoutDetalle
        Me.cmbUnidadPeso.TabIndex = 10
        '
        'GridView4
        '
        Me.GridView4.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView4.Name = "GridView4"
        Me.GridView4.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView4.OptionsView.ShowGroupPanel = False
        '
        'txtPesoNeto
        '
        Me.txtPesoNeto.Location = New System.Drawing.Point(831, 144)
        Me.txtPesoNeto.Margin = New System.Windows.Forms.Padding(6)
        Me.txtPesoNeto.MenuManager = Me.BarManager1
        Me.txtPesoNeto.Name = "txtPesoNeto"
        Me.txtPesoNeto.Properties.Mask.EditMask = "n6"
        Me.txtPesoNeto.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtPesoNeto.Size = New System.Drawing.Size(439, 40)
        Me.txtPesoNeto.StyleController = Me.LayoutDetalle
        Me.txtPesoNeto.TabIndex = 9
        '
        'txtClaseLinea
        '
        Me.txtClaseLinea.Location = New System.Drawing.Point(212, 188)
        Me.txtClaseLinea.Margin = New System.Windows.Forms.Padding(6)
        Me.txtClaseLinea.MenuManager = Me.BarManager1
        Me.txtClaseLinea.Name = "txtClaseLinea"
        Me.txtClaseLinea.Size = New System.Drawing.Size(395, 40)
        Me.txtClaseLinea.StyleController = Me.LayoutDetalle
        Me.txtClaseLinea.TabIndex = 8
        '
        'txtBultos
        '
        Me.txtBultos.Location = New System.Drawing.Point(212, 56)
        Me.txtBultos.Margin = New System.Windows.Forms.Padding(6)
        Me.txtBultos.MenuManager = Me.BarManager1
        Me.txtBultos.Name = "txtBultos"
        Me.txtBultos.Properties.Mask.EditMask = "n4"
        Me.txtBultos.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtBultos.Size = New System.Drawing.Size(395, 40)
        Me.txtBultos.StyleController = Me.LayoutDetalle
        Me.txtBultos.TabIndex = 7
        '
        'cmbSacCode
        '
        Me.cmbSacCode.Location = New System.Drawing.Point(1494, 232)
        Me.cmbSacCode.Margin = New System.Windows.Forms.Padding(6)
        Me.cmbSacCode.MenuManager = Me.BarManager1
        Me.cmbSacCode.Name = "cmbSacCode"
        Me.cmbSacCode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbSacCode.Properties.NullText = "[Seleccione SAC...]"
        Me.cmbSacCode.Properties.PopupView = Me.GridView3
        Me.cmbSacCode.Size = New System.Drawing.Size(908, 40)
        Me.cmbSacCode.StyleController = Me.LayoutDetalle
        Me.cmbSacCode.TabIndex = 6
        '
        'GridView3
        '
        Me.GridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView3.Name = "GridView3"
        Me.GridView3.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView3.OptionsView.ShowGroupPanel = False
        '
        'txtNumeroLinea
        '
        Me.txtNumeroLinea.Location = New System.Drawing.Point(212, 12)
        Me.txtNumeroLinea.Margin = New System.Windows.Forms.Padding(6)
        Me.txtNumeroLinea.MenuManager = Me.BarManager1
        Me.txtNumeroLinea.Name = "txtNumeroLinea"
        Me.txtNumeroLinea.Properties.Mask.EditMask = "n0"
        Me.txtNumeroLinea.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtNumeroLinea.Properties.ReadOnly = True
        Me.txtNumeroLinea.Size = New System.Drawing.Size(395, 40)
        Me.txtNumeroLinea.StyleController = Me.LayoutDetalle
        Me.txtNumeroLinea.TabIndex = 4
        '
        'cmbUnidadCantidad
        '
        Me.cmbUnidadCantidad.Location = New System.Drawing.Point(1494, 100)
        Me.cmbUnidadCantidad.Margin = New System.Windows.Forms.Padding(6)
        Me.cmbUnidadCantidad.MenuManager = Me.BarManager1
        Me.cmbUnidadCantidad.Name = "cmbUnidadCantidad"
        Me.cmbUnidadCantidad.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbUnidadCantidad.Properties.NullText = "[Seleccione Unidad...]"
        Me.cmbUnidadCantidad.Properties.PopupView = Me.GridView5
        Me.cmbUnidadCantidad.Size = New System.Drawing.Size(908, 40)
        Me.cmbUnidadCantidad.StyleController = Me.LayoutDetalle
        Me.cmbUnidadCantidad.TabIndex = 13
        '
        'GridView5
        '
        Me.GridView5.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView5.Name = "GridView5"
        Me.GridView5.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView5.OptionsView.ShowGroupPanel = False
        '
        'cmbUnidadVolumen
        '
        Me.cmbUnidadVolumen.Location = New System.Drawing.Point(831, 188)
        Me.cmbUnidadVolumen.Margin = New System.Windows.Forms.Padding(6)
        Me.cmbUnidadVolumen.MenuManager = Me.BarManager1
        Me.cmbUnidadVolumen.Name = "cmbUnidadVolumen"
        Me.cmbUnidadVolumen.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbUnidadVolumen.Properties.NullText = ""
        Me.cmbUnidadVolumen.Properties.PopupView = Me.GridView6
        Me.cmbUnidadVolumen.Size = New System.Drawing.Size(439, 40)
        Me.cmbUnidadVolumen.StyleController = Me.LayoutDetalle
        Me.cmbUnidadVolumen.TabIndex = 15
        '
        'GridView6
        '
        Me.GridView6.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView6.Name = "GridView6"
        Me.GridView6.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView6.OptionsView.ShowGroupPanel = False
        '
        'cmbConsignatario
        '
        Me.cmbConsignatario.Location = New System.Drawing.Point(212, 452)
        Me.cmbConsignatario.Margin = New System.Windows.Forms.Padding(6)
        Me.cmbConsignatario.MenuManager = Me.BarManager1
        Me.cmbConsignatario.Name = "cmbConsignatario"
        Me.cmbConsignatario.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        Me.cmbConsignatario.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbConsignatario.Properties.NullText = "[Seleccione Consignatario...]"
        Me.cmbConsignatario.Properties.PopupView = Me.GridView8
        Me.cmbConsignatario.Size = New System.Drawing.Size(992, 40)
        Me.cmbConsignatario.StyleController = Me.LayoutDetalle
        Me.cmbConsignatario.TabIndex = 34
        '
        'GridView8
        '
        Me.GridView8.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView8.Name = "GridView8"
        Me.GridView8.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView8.OptionsView.ShowAutoFilterRow = True
        Me.GridView8.OptionsView.ShowGroupPanel = False
        '
        'pctDAI
        '
        Me.pctDAI.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.pctDAI.Location = New System.Drawing.Point(212, 144)
        Me.pctDAI.Margin = New System.Windows.Forms.Padding(6)
        Me.pctDAI.MenuManager = Me.BarManager1
        Me.pctDAI.Name = "pctDAI"
        Me.pctDAI.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.pctDAI.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.[Default]
        Me.pctDAI.Properties.Mask.EditMask = "f3"
        Me.pctDAI.Size = New System.Drawing.Size(395, 40)
        Me.pctDAI.StyleController = Me.LayoutDetalle
        Me.pctDAI.TabIndex = 35
        '
        'txtDescripcionSku
        '
        Me.txtDescripcionSku.Location = New System.Drawing.Point(831, 12)
        Me.txtDescripcionSku.Margin = New System.Windows.Forms.Padding(6)
        Me.txtDescripcionSku.MenuManager = Me.BarManager1
        Me.txtDescripcionSku.Name = "txtDescripcionSku"
        Me.txtDescripcionSku.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtDescripcionSku.Properties.Appearance.Options.UseBackColor = True
        Me.txtDescripcionSku.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtDescripcionSku.Properties.NullText = ""
        Me.txtDescripcionSku.Properties.PopupSizeable = False
        Me.txtDescripcionSku.Size = New System.Drawing.Size(1571, 40)
        Me.txtDescripcionSku.StyleController = Me.LayoutDetalle
        Me.txtDescripcionSku.TabIndex = 5
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.CustomizationFormText = "Root"
        Me.LayoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup2.GroupBordersVisible = False
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem47, Me.LayoutControlItem52, Me.LayoutControlItem58, Me.LayoutControlItem48, Me.LayoutControlItem51, Me.LayoutControlItem56, Me.LayoutControlItem60, Me.LayoutControlItem55, Me.LayoutControlItem61, Me.LayoutControlItem53, Me.LayoutControlItem54, Me.LayoutControlItem59, Me.LayoutControlItem49, Me.SplitterItem8, Me.LayoutControlItem62, Me.LayoutControlItem63, Me.LayoutControlItem64, Me.LayoutControlItem65, Me.LayoutControlItem66, Me.LayoutControlItem67, Me.LayoutControlItem68, Me.LayoutControlItem69, Me.LayoutControlItem78, Me.LayoutControlItem74, Me.LayoutControlItem72, Me.LayoutControlItem76, Me.LayoutControlItem73, Me.SplitterItem9, Me.LayoutControlItem70, Me.LayoutControlItem71, Me.LayoutControlItem81, Me.LayoutControlItem75, Me.UiLayoutControlImpuesto, Me.LayoutControlItem57})
        Me.LayoutControlGroup2.Name = "Root"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(2414, 880)
        Me.LayoutControlGroup2.TextVisible = False
        '
        'LayoutControlItem47
        '
        Me.LayoutControlItem47.Control = Me.txtNumeroLinea
        Me.LayoutControlItem47.CustomizationFormText = "Numero Linea"
        Me.LayoutControlItem47.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem47.Name = "LayoutControlItem47"
        Me.LayoutControlItem47.Size = New System.Drawing.Size(599, 44)
        Me.LayoutControlItem47.Text = "Numero Linea"
        Me.LayoutControlItem47.TextSize = New System.Drawing.Size(197, 25)
        '
        'LayoutControlItem52
        '
        Me.LayoutControlItem52.Control = Me.txtClaseLinea
        Me.LayoutControlItem52.CustomizationFormText = "Clase"
        Me.LayoutControlItem52.Location = New System.Drawing.Point(0, 176)
        Me.LayoutControlItem52.Name = "LayoutControlItem52"
        Me.LayoutControlItem52.Size = New System.Drawing.Size(599, 44)
        Me.LayoutControlItem52.Text = "Clase"
        Me.LayoutControlItem52.TextSize = New System.Drawing.Size(197, 25)
        '
        'LayoutControlItem58
        '
        Me.LayoutControlItem58.Control = Me.txtVolumen
        Me.LayoutControlItem58.CustomizationFormText = "Volumen"
        Me.LayoutControlItem58.Location = New System.Drawing.Point(0, 220)
        Me.LayoutControlItem58.Name = "LayoutControlItem58"
        Me.LayoutControlItem58.Size = New System.Drawing.Size(599, 44)
        Me.LayoutControlItem58.Text = "Volumen"
        Me.LayoutControlItem58.TextSize = New System.Drawing.Size(197, 25)
        '
        'LayoutControlItem48
        '
        Me.LayoutControlItem48.Control = Me.txtDescripcionSku
        Me.LayoutControlItem48.CustomizationFormText = "Descripcion Producto"
        Me.LayoutControlItem48.Location = New System.Drawing.Point(619, 0)
        Me.LayoutControlItem48.Name = "LayoutControlItem48"
        Me.LayoutControlItem48.Size = New System.Drawing.Size(1775, 44)
        Me.LayoutControlItem48.Text = "Descripcion Producto"
        Me.LayoutControlItem48.TextSize = New System.Drawing.Size(197, 25)
        '
        'LayoutControlItem51
        '
        Me.LayoutControlItem51.Control = Me.txtBultos
        Me.LayoutControlItem51.CustomizationFormText = "Bultos"
        Me.LayoutControlItem51.Location = New System.Drawing.Point(0, 44)
        Me.LayoutControlItem51.Name = "LayoutControlItem51"
        Me.LayoutControlItem51.Size = New System.Drawing.Size(599, 44)
        Me.LayoutControlItem51.Text = "Bultos"
        Me.LayoutControlItem51.TextSize = New System.Drawing.Size(197, 25)
        '
        'LayoutControlItem56
        '
        Me.LayoutControlItem56.Control = Me.txtValorAduana
        Me.LayoutControlItem56.CustomizationFormText = "Valor Aduana"
        Me.LayoutControlItem56.Location = New System.Drawing.Point(0, 88)
        Me.LayoutControlItem56.Name = "LayoutControlItem56"
        Me.LayoutControlItem56.Size = New System.Drawing.Size(599, 44)
        Me.LayoutControlItem56.Text = "Valor Aduana"
        Me.LayoutControlItem56.TextSize = New System.Drawing.Size(197, 25)
        '
        'LayoutControlItem60
        '
        Me.LayoutControlItem60.Control = Me.txtDai
        Me.LayoutControlItem60.CustomizationFormText = "Valor DAI"
        Me.LayoutControlItem60.Location = New System.Drawing.Point(619, 88)
        Me.LayoutControlItem60.Name = "LayoutControlItem60"
        Me.LayoutControlItem60.Size = New System.Drawing.Size(643, 44)
        Me.LayoutControlItem60.Text = "Valor DAI"
        Me.LayoutControlItem60.TextSize = New System.Drawing.Size(197, 25)
        '
        'LayoutControlItem55
        '
        Me.LayoutControlItem55.Control = Me.txtCantidad
        Me.LayoutControlItem55.CustomizationFormText = "Cantidad"
        Me.LayoutControlItem55.Location = New System.Drawing.Point(619, 44)
        Me.LayoutControlItem55.Name = "LayoutControlItem55"
        Me.LayoutControlItem55.Size = New System.Drawing.Size(643, 44)
        Me.LayoutControlItem55.Text = "Cantidad"
        Me.LayoutControlItem55.TextSize = New System.Drawing.Size(197, 25)
        '
        'LayoutControlItem61
        '
        Me.LayoutControlItem61.Control = Me.txtValorIva
        Me.LayoutControlItem61.CustomizationFormText = "Valor IVA"
        Me.LayoutControlItem61.Location = New System.Drawing.Point(1282, 132)
        Me.LayoutControlItem61.Name = "LayoutControlItem61"
        Me.LayoutControlItem61.Size = New System.Drawing.Size(1112, 44)
        Me.LayoutControlItem61.Text = "Valor IVA"
        Me.LayoutControlItem61.TextSize = New System.Drawing.Size(197, 25)
        '
        'LayoutControlItem53
        '
        Me.LayoutControlItem53.Control = Me.txtPesoNeto
        Me.LayoutControlItem53.CustomizationFormText = "Peso Neto"
        Me.LayoutControlItem53.Location = New System.Drawing.Point(619, 132)
        Me.LayoutControlItem53.Name = "LayoutControlItem53"
        Me.LayoutControlItem53.Size = New System.Drawing.Size(643, 44)
        Me.LayoutControlItem53.Text = "Peso Neto"
        Me.LayoutControlItem53.TextSize = New System.Drawing.Size(197, 25)
        '
        'LayoutControlItem54
        '
        Me.LayoutControlItem54.Control = Me.cmbUnidadPeso
        Me.LayoutControlItem54.CustomizationFormText = "Unidad Peso"
        Me.LayoutControlItem54.Location = New System.Drawing.Point(1282, 176)
        Me.LayoutControlItem54.Name = "LayoutControlItem54"
        Me.LayoutControlItem54.Size = New System.Drawing.Size(1112, 44)
        Me.LayoutControlItem54.Text = "Unidad Peso"
        Me.LayoutControlItem54.TextSize = New System.Drawing.Size(197, 25)
        '
        'LayoutControlItem59
        '
        Me.LayoutControlItem59.Control = Me.cmbUnidadVolumen
        Me.LayoutControlItem59.CustomizationFormText = "Unidad Volumen"
        Me.LayoutControlItem59.Location = New System.Drawing.Point(619, 176)
        Me.LayoutControlItem59.Name = "LayoutControlItem59"
        Me.LayoutControlItem59.Size = New System.Drawing.Size(643, 44)
        Me.LayoutControlItem59.Text = "Unidad Volumen"
        Me.LayoutControlItem59.TextSize = New System.Drawing.Size(197, 25)
        '
        'LayoutControlItem49
        '
        Me.LayoutControlItem49.Control = Me.cmbSacCode
        Me.LayoutControlItem49.CustomizationFormText = "Codigo SAC"
        Me.LayoutControlItem49.Location = New System.Drawing.Point(1282, 220)
        Me.LayoutControlItem49.Name = "LayoutControlItem49"
        Me.LayoutControlItem49.Size = New System.Drawing.Size(1112, 44)
        Me.LayoutControlItem49.Text = "Codigo SAC"
        Me.LayoutControlItem49.TextSize = New System.Drawing.Size(197, 25)
        '
        'SplitterItem8
        '
        Me.SplitterItem8.AllowHotTrack = True
        Me.SplitterItem8.CustomizationFormText = "SplitterItem8"
        Me.SplitterItem8.Location = New System.Drawing.Point(599, 0)
        Me.SplitterItem8.Name = "SplitterItem8"
        Me.SplitterItem8.Size = New System.Drawing.Size(20, 440)
        '
        'LayoutControlItem62
        '
        Me.LayoutControlItem62.Control = Me.GridDetalle
        Me.LayoutControlItem62.CustomizationFormText = "Detalle Documento"
        Me.LayoutControlItem62.Location = New System.Drawing.Point(0, 484)
        Me.LayoutControlItem62.Name = "LayoutControlItem62"
        Me.LayoutControlItem62.Size = New System.Drawing.Size(2394, 376)
        Me.LayoutControlItem62.Text = "Detalle Documento"
        Me.LayoutControlItem62.TextSize = New System.Drawing.Size(197, 25)
        '
        'LayoutControlItem63
        '
        Me.LayoutControlItem63.Control = Me.txtImpuestosVarios
        Me.LayoutControlItem63.CustomizationFormText = "Impuestos Varios"
        Me.LayoutControlItem63.Location = New System.Drawing.Point(0, 264)
        Me.LayoutControlItem63.Name = "LayoutControlItem63"
        Me.LayoutControlItem63.Size = New System.Drawing.Size(599, 44)
        Me.LayoutControlItem63.Text = "Impuestos Varios"
        Me.LayoutControlItem63.TextSize = New System.Drawing.Size(197, 25)
        '
        'LayoutControlItem64
        '
        Me.LayoutControlItem64.Control = Me.txtGastosVarios
        Me.LayoutControlItem64.CustomizationFormText = "Gastos Varios"
        Me.LayoutControlItem64.Location = New System.Drawing.Point(619, 220)
        Me.LayoutControlItem64.Name = "LayoutControlItem64"
        Me.LayoutControlItem64.Size = New System.Drawing.Size(643, 44)
        Me.LayoutControlItem64.Text = "Gastos Varios"
        Me.LayoutControlItem64.TextSize = New System.Drawing.Size(197, 25)
        '
        'LayoutControlItem65
        '
        Me.LayoutControlItem65.Control = Me.txtPaisOrigen
        Me.LayoutControlItem65.CustomizationFormText = "Pais Origen"
        Me.LayoutControlItem65.Location = New System.Drawing.Point(1282, 264)
        Me.LayoutControlItem65.Name = "LayoutControlItem65"
        Me.LayoutControlItem65.Size = New System.Drawing.Size(1112, 44)
        Me.LayoutControlItem65.Text = "Pais Origen"
        Me.LayoutControlItem65.TextSize = New System.Drawing.Size(197, 25)
        '
        'LayoutControlItem66
        '
        Me.LayoutControlItem66.Control = Me.txtFobUsd
        Me.LayoutControlItem66.CustomizationFormText = "FOB USD"
        Me.LayoutControlItem66.Location = New System.Drawing.Point(0, 308)
        Me.LayoutControlItem66.Name = "LayoutControlItem66"
        Me.LayoutControlItem66.Size = New System.Drawing.Size(599, 44)
        Me.LayoutControlItem66.Text = "FOB USD"
        Me.LayoutControlItem66.TextSize = New System.Drawing.Size(197, 25)
        '
        'LayoutControlItem67
        '
        Me.LayoutControlItem67.Control = Me.txtFleteUsd
        Me.LayoutControlItem67.CustomizationFormText = "Flete USD"
        Me.LayoutControlItem67.Location = New System.Drawing.Point(619, 264)
        Me.LayoutControlItem67.Name = "LayoutControlItem67"
        Me.LayoutControlItem67.Size = New System.Drawing.Size(643, 44)
        Me.LayoutControlItem67.Text = "Flete USD"
        Me.LayoutControlItem67.TextSize = New System.Drawing.Size(197, 25)
        '
        'LayoutControlItem68
        '
        Me.LayoutControlItem68.Control = Me.txtSeguroUsd
        Me.LayoutControlItem68.CustomizationFormText = "Seguro USD"
        Me.LayoutControlItem68.Location = New System.Drawing.Point(1282, 308)
        Me.LayoutControlItem68.Name = "LayoutControlItem68"
        Me.LayoutControlItem68.Size = New System.Drawing.Size(1112, 44)
        Me.LayoutControlItem68.Text = "Seguro USD"
        Me.LayoutControlItem68.TextSize = New System.Drawing.Size(197, 25)
        '
        'LayoutControlItem69
        '
        Me.LayoutControlItem69.Control = Me.txtRegionCp
        Me.LayoutControlItem69.CustomizationFormText = "Region CP"
        Me.LayoutControlItem69.Location = New System.Drawing.Point(0, 352)
        Me.LayoutControlItem69.Name = "LayoutControlItem69"
        Me.LayoutControlItem69.Size = New System.Drawing.Size(599, 44)
        Me.LayoutControlItem69.Text = "Region CP"
        Me.LayoutControlItem69.TextSize = New System.Drawing.Size(197, 25)
        '
        'LayoutControlItem78
        '
        Me.LayoutControlItem78.Control = Me.cmbConsignatario
        Me.LayoutControlItem78.CustomizationFormText = "Consignatario"
        Me.LayoutControlItem78.Location = New System.Drawing.Point(0, 440)
        Me.LayoutControlItem78.Name = "LayoutControlItem78"
        Me.LayoutControlItem78.Size = New System.Drawing.Size(1196, 44)
        Me.LayoutControlItem78.Text = "Consignatario"
        Me.LayoutControlItem78.TextSize = New System.Drawing.Size(197, 25)
        '
        'LayoutControlItem74
        '
        Me.LayoutControlItem74.Control = Me.txtActualizadaEl
        Me.LayoutControlItem74.CustomizationFormText = "Actualizada El"
        Me.LayoutControlItem74.Location = New System.Drawing.Point(619, 308)
        Me.LayoutControlItem74.Name = "LayoutControlItem74"
        Me.LayoutControlItem74.Size = New System.Drawing.Size(643, 44)
        Me.LayoutControlItem74.Text = "Actualizada El"
        Me.LayoutControlItem74.TextSize = New System.Drawing.Size(197, 25)
        '
        'LayoutControlItem72
        '
        Me.LayoutControlItem72.Control = Me.txtPolizaRelacionada
        Me.LayoutControlItem72.CustomizationFormText = "Poliza Relacionada"
        Me.LayoutControlItem72.Location = New System.Drawing.Point(1196, 440)
        Me.LayoutControlItem72.Name = "LayoutControlItem72"
        Me.LayoutControlItem72.Size = New System.Drawing.Size(599, 44)
        Me.LayoutControlItem72.Text = "Poliza Relacionada"
        Me.LayoutControlItem72.TextSize = New System.Drawing.Size(197, 25)
        '
        'LayoutControlItem76
        '
        Me.LayoutControlItem76.Control = Me.txtPolizaOrigen
        Me.LayoutControlItem76.CustomizationFormText = "Poliza Origen"
        Me.LayoutControlItem76.Location = New System.Drawing.Point(1795, 440)
        Me.LayoutControlItem76.Name = "LayoutControlItem76"
        Me.LayoutControlItem76.Size = New System.Drawing.Size(599, 44)
        Me.LayoutControlItem76.Text = "Poliza Origen"
        Me.LayoutControlItem76.TextSize = New System.Drawing.Size(197, 25)
        '
        'LayoutControlItem73
        '
        Me.LayoutControlItem73.Control = Me.txtActualizadaPor
        Me.LayoutControlItem73.CustomizationFormText = "Actualizada Por"
        Me.LayoutControlItem73.Location = New System.Drawing.Point(1282, 352)
        Me.LayoutControlItem73.Name = "LayoutControlItem73"
        Me.LayoutControlItem73.Size = New System.Drawing.Size(1112, 88)
        Me.LayoutControlItem73.Text = "Actualizada Por"
        Me.LayoutControlItem73.TextSize = New System.Drawing.Size(197, 25)
        '
        'SplitterItem9
        '
        Me.SplitterItem9.AllowHotTrack = True
        Me.SplitterItem9.CustomizationFormText = "SplitterItem9"
        Me.SplitterItem9.Location = New System.Drawing.Point(1262, 44)
        Me.SplitterItem9.Name = "SplitterItem9"
        Me.SplitterItem9.Size = New System.Drawing.Size(20, 396)
        '
        'LayoutControlItem70
        '
        Me.LayoutControlItem70.Control = Me.txtAcuerdo1
        Me.LayoutControlItem70.CustomizationFormText = "Acuerdo1"
        Me.LayoutControlItem70.Location = New System.Drawing.Point(0, 396)
        Me.LayoutControlItem70.Name = "LayoutControlItem70"
        Me.LayoutControlItem70.Size = New System.Drawing.Size(599, 44)
        Me.LayoutControlItem70.Text = "Acuerdo1"
        Me.LayoutControlItem70.TextSize = New System.Drawing.Size(197, 25)
        '
        'LayoutControlItem71
        '
        Me.LayoutControlItem71.Control = Me.txtAcuerdo2
        Me.LayoutControlItem71.CustomizationFormText = "Acuerdo2"
        Me.LayoutControlItem71.Location = New System.Drawing.Point(619, 352)
        Me.LayoutControlItem71.Name = "LayoutControlItem71"
        Me.LayoutControlItem71.Size = New System.Drawing.Size(643, 44)
        Me.LayoutControlItem71.Text = "Acuerdo2"
        Me.LayoutControlItem71.TextSize = New System.Drawing.Size(197, 25)
        '
        'LayoutControlItem81
        '
        Me.LayoutControlItem81.Control = Me.pctDAI
        Me.LayoutControlItem81.CustomizationFormText = "pct DAI"
        Me.LayoutControlItem81.Location = New System.Drawing.Point(0, 132)
        Me.LayoutControlItem81.Name = "LayoutControlItem81"
        Me.LayoutControlItem81.Size = New System.Drawing.Size(599, 44)
        Me.LayoutControlItem81.Text = "pct DAI"
        Me.LayoutControlItem81.TextSize = New System.Drawing.Size(197, 25)
        '
        'LayoutControlItem75
        '
        Me.LayoutControlItem75.Control = Me.txtDocumentoOrigen
        Me.LayoutControlItem75.CustomizationFormText = "Documento Origen"
        Me.LayoutControlItem75.Location = New System.Drawing.Point(619, 396)
        Me.LayoutControlItem75.Name = "LayoutControlItem75"
        Me.LayoutControlItem75.Size = New System.Drawing.Size(643, 44)
        Me.LayoutControlItem75.Text = "Documento Origen"
        Me.LayoutControlItem75.TextSize = New System.Drawing.Size(197, 25)
        '
        'UiLayoutControlImpuesto
        '
        Me.UiLayoutControlImpuesto.Control = Me.UiListaImpuesto
        Me.UiLayoutControlImpuesto.Location = New System.Drawing.Point(1282, 44)
        Me.UiLayoutControlImpuesto.Name = "UiLayoutControlImpuesto"
        Me.UiLayoutControlImpuesto.Size = New System.Drawing.Size(1112, 44)
        Me.UiLayoutControlImpuesto.Text = "Impuesto"
        Me.UiLayoutControlImpuesto.TextSize = New System.Drawing.Size(197, 25)
        '
        'LayoutControlItem57
        '
        Me.LayoutControlItem57.Control = Me.cmbUnidadCantidad
        Me.LayoutControlItem57.CustomizationFormText = "Unidad de Cantidad"
        Me.LayoutControlItem57.Location = New System.Drawing.Point(1282, 88)
        Me.LayoutControlItem57.Name = "LayoutControlItem57"
        Me.LayoutControlItem57.Size = New System.Drawing.Size(1112, 44)
        Me.LayoutControlItem57.Text = "Unidad de Cantidad"
        Me.LayoutControlItem57.TextSize = New System.Drawing.Size(197, 25)
        '
        'XtraTabServicios
        '
        Me.XtraTabServicios.Controls.Add(Me.LayoutServicios)
        Me.XtraTabServicios.Margin = New System.Windows.Forms.Padding(6)
        Me.XtraTabServicios.Name = "XtraTabServicios"
        Me.XtraTabServicios.PageVisible = False
        Me.XtraTabServicios.Size = New System.Drawing.Size(2414, 880)
        Me.XtraTabServicios.Text = "Servicios"
        '
        'LayoutServicios
        '
        Me.LayoutServicios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutServicios.Location = New System.Drawing.Point(0, 0)
        Me.LayoutServicios.Margin = New System.Windows.Forms.Padding(6)
        Me.LayoutServicios.Name = "LayoutServicios"
        Me.LayoutServicios.Root = Me.LayoutControlGroup3
        Me.LayoutServicios.Size = New System.Drawing.Size(2414, 880)
        Me.LayoutServicios.TabIndex = 0
        Me.LayoutServicios.Text = "Servicios"
        '
        'LayoutControlGroup3
        '
        Me.LayoutControlGroup3.CustomizationFormText = "LayoutControlGroup3"
        Me.LayoutControlGroup3.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup3.GroupBordersVisible = False
        Me.LayoutControlGroup3.Name = "LayoutControlGroup3"
        Me.LayoutControlGroup3.Size = New System.Drawing.Size(2414, 880)
        Me.LayoutControlGroup3.TextVisible = False
        '
        'Bar1
        '
        Me.Bar1.BarName = "Tools"
        Me.Bar1.DockCol = 0
        Me.Bar1.DockRow = 1
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar1.Text = "Tools"
        Me.Bar1.Visible = False
        '
        'frmDocumentoIngreso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(2418, 1431)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Margin = New System.Windows.Forms.Padding(6)
        Me.Name = "frmDocumentoIngreso"
        Me.Text = "Documento Ingreso"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.XtraTabHead.ResumeLayout(False)
        CType(Me.LayoutEncabezado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutEncabezado.ResumeLayout(False)
        CType(Me.GridLookUpEdit3.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtScanEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridLookUpEdit2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridLookUpEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbBodegueros.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbPolizaAsegurada.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbAcuerdoHead.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCodigoPoliza.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMarchamo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtFechaLlegada.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtFechaLlegada.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridDocRefencia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewDocReferencia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbTipoDocRef, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemGridLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtFechaDocumentoRef.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtFechaDocumentoRef, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtStatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNumeroSat.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDomicilioRepresentante.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTipoDeclaranteRepresentante.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPaisImportador.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPaisRepresentante.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRazonSocialRepresentante.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtIdTributariaRepresentante.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTipoRepresentante.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtModo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTipoImportador.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNaturalezaTrans.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDepositoFiscalZf.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRazonSocialImportador.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDomicilioImportador.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtIdTributariaImportador.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAduanaEntradaSalida.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtClase.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNumeroContenedor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEntidadContenedor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTipoContenedor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAduanaDespachoDestino.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPaisProcedencia.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalPesoBrutoKg.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalBultos.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalLineas.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNumeroOrden.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDocumentoPadre.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalOtrosUsd.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalSeguroUsd.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalFleteUsd.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtFechaAceptacion.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtFechaAceptacion.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNumeroDua.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalGeneral.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalOtros.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalLiquidar.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtFechaDocumento.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtFechaDocumento.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDocId.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalFobUsd.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalValorAduana.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTipoCambio.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbRegimenPoliza.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewCmbRegimen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbRegimen.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewCmbRegimenAlmacen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbCliente.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTicketNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lookUpPrioridad.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridLookUpEdit4View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem24, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem27, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem25, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem28, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem50, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem34, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem26, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem43, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem44, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem31, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem39, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem36, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem38, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem32, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem30, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem35, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem40, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitterItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitterItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitterItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitterItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem46, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem45, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitterItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitterItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem29, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem41, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem33, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitterItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem80, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem42, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPolizaAsegurada, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem82, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem79, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem37, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutTicketFiscal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem83, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem77, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem84, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem85, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabDetail.ResumeLayout(False)
        CType(Me.LayoutDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutDetalle.ResumeLayout(False)
        CType(Me.UiListaImpuesto.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiListaVistaImpuesto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPolizaOrigen.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDocumentoOrigen.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtActualizadaEl.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtActualizadaPor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPolizaRelacionada.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAcuerdo2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAcuerdo1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRegionCp.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSeguroUsd.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFleteUsd.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFobUsd.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPaisOrigen.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtGastosVarios.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtImpuestosVarios.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtValorIva.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDai.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtVolumen.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtValorAduana.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCantidad.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbUnidadPeso.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPesoNeto.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtClaseLinea.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBultos.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbSacCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNumeroLinea.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbUnidadCantidad.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbUnidadVolumen.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbConsignatario.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctDAI.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDescripcionSku.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem47, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem52, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem58, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem48, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem51, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem56, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem60, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem55, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem61, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem53, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem54, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem59, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem49, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitterItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem62, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem63, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem64, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem65, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem66, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem67, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem68, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem69, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem78, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem74, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem72, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem76, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem73, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitterItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem70, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem71, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem81, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem75, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiLayoutControlImpuesto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem57, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabServicios.ResumeLayout(False)
        CType(Me.LayoutServicios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout

End Sub
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XtraTabHead As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XtraTabDetail As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XtraTabServicios As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents LayoutEncabezado As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutDetalle As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutServicios As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup3 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents Bar2 As DevExpress.XtraBars.Bar
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents Bar1 As DevExpress.XtraBars.Bar
    Friend WithEvents cmbRegimen As DevExpress.XtraEditors.GridLookUpEdit
    Friend WithEvents GridViewCmbRegimenAlmacen As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents cmbRegimenPoliza As DevExpress.XtraEditors.GridLookUpEdit
    Friend WithEvents GridViewCmbRegimen As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtTipoCambio As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtTotalValorAduana As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtTotalFobUsd As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtDocId As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents dtFechaDocumento As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtTotalLiquidar As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtTotalGeneral As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtTotalOtros As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem10 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtNumeroDua As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem11 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents dtFechaAceptacion As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LayoutControlItem12 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtTotalSeguroUsd As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtTotalFleteUsd As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem13 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem14 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtTotalOtrosUsd As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem15 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtDocumentoPadre As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem16 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtNumeroOrden As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem17 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtTotalBultos As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtTotalLineas As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem18 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem19 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtTotalPesoBrutoKg As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem20 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtPaisProcedencia As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem21 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtAduanaDespachoDestino As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem22 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtTipoContenedor As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem23 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtEntidadContenedor As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem24 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtNumeroContenedor As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem25 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtClase As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem26 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtAduanaEntradaSalida As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem27 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtRazonSocialImportador As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtIdTributariaImportador As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem28 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem29 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtNaturalezaTrans As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtDepositoFiscalZf As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem30 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem31 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtDomicilioImportador As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtTipoImportador As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem32 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem33 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtModo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem34 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtTipoRepresentante As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem35 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtIdTributariaRepresentante As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem36 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtRazonSocialRepresentante As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem37 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtPaisRepresentante As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem38 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtPaisImportador As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem39 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtTipoDeclaranteRepresentante As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem40 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtDomicilioRepresentante As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem41 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtStatus As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtNumeroSat As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem42 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem43 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents dtFechaLlegada As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LayoutControlItem44 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtMarchamo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem45 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents cmbCliente As DevExpress.XtraEditors.GridLookUpEdit
    Friend WithEvents GridViewCliente As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlItem46 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SplitterItem1 As DevExpress.XtraLayout.SplitterItem
    Friend WithEvents GridDocRefencia As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewDocReferencia As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlItem50 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents colDOCUMENTO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTIPODOCUMENTO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFECHADOCUMENTO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents btnSave As DevExpress.XtraBars.BarLargeButtonItem
    Friend WithEvents btnScan As DevExpress.XtraBars.BarLargeButtonItem
    Friend WithEvents btnRectify As DevExpress.XtraBars.BarLargeButtonItem
    Friend WithEvents btnPrint As DevExpress.XtraBars.BarLargeButtonItem
    Friend WithEvents btnRestore As DevExpress.XtraBars.BarLargeButtonItem
    Friend WithEvents txtNumeroLinea As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem47 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem48 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents cmbSacCode As DevExpress.XtraEditors.GridLookUpEdit
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlItem49 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtBultos As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem51 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtClaseLinea As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem52 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents cmbUnidadPeso As DevExpress.XtraEditors.GridLookUpEdit
    Friend WithEvents GridView4 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents txtPesoNeto As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem53 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem54 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtValorAduana As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtCantidad As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem55 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem56 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents cmbUnidadCantidad As DevExpress.XtraEditors.GridLookUpEdit
    Friend WithEvents GridView5 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlItem57 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtVolumen As DevExpress.XtraEditors.TextEdit
    Friend WithEvents cmbUnidadVolumen As DevExpress.XtraEditors.GridLookUpEdit
    Friend WithEvents GridView6 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlItem58 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem59 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtDai As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem60 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtValorIva As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem61 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SplitterItem2 As DevExpress.XtraLayout.SplitterItem
    Friend WithEvents SplitterItem3 As DevExpress.XtraLayout.SplitterItem
    Friend WithEvents SplitterItem4 As DevExpress.XtraLayout.SplitterItem
    Friend WithEvents SplitterItem5 As DevExpress.XtraLayout.SplitterItem
    Friend WithEvents SplitterItem6 As DevExpress.XtraLayout.SplitterItem
    Friend WithEvents SplitterItem7 As DevExpress.XtraLayout.SplitterItem
    Friend WithEvents GridDetalle As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewDetalle As DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView
    Friend WithEvents SplitterItem8 As DevExpress.XtraLayout.SplitterItem
    Friend WithEvents SplitterItem9 As DevExpress.XtraLayout.SplitterItem
    Friend WithEvents LayoutControlItem62 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtSeguroUsd As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtFleteUsd As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtFobUsd As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtPaisOrigen As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtGastosVarios As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtImpuestosVarios As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem63 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem64 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem65 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem66 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem67 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem68 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtAcuerdo2 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtAcuerdo1 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtRegionCp As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem69 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem70 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem71 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtActualizadaEl As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtActualizadaPor As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtPolizaRelacionada As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem72 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem73 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem74 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtPolizaOrigen As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtDocumentoOrigen As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem75 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem76 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents cmbConsignatario As DevExpress.XtraEditors.GridLookUpEdit
    Friend WithEvents GridView8 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlItem78 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents btnAddLine As DevExpress.XtraBars.BarLargeButtonItem
    Friend WithEvents colNUMEROLINEA As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colDESCRIPCIONPRODUCTO As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colBULTOS As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colCANTIDAD As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colUNIDADCANTIDAD As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colVALORADUANA As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colVALORDAI As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colVALORIVA As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colCLASE As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colPESONETO As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colUNIDADPESO As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colVOLUMEN As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colUNIDADVOLUMEN As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colCODIGOSAC As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colIMPUESTOSVARIOS As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colGASTOSVARIOS As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colPAISORIGEN As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colFOBUSD As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colFLETEUSD As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colSEGUROUSD As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colREGIONCP As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colACUERDO1 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colACUERDO2 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colPOLIZARELACIONADA As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colACTUALIZADAPOR As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colACTUALIZADAEL As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colDOCUMENTOORIGEN As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colPOLIZAORIGEN As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colACUERDOCOMERCIAL As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colCONSIGNATARIO As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents btnEnviar As DevExpress.XtraBars.BarLargeButtonItem
    Friend WithEvents cmbTipoDocRef As DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit
    Friend WithEvents RepositoryItemGridLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents dtFechaDocumentoRef As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents colDOC_ID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNUMERO_DUA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOBSERVACIONES As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colLAST_UPDATED_BY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colLAST_UPDATED As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents txtScanPoliza As DevExpress.XtraBars.BarEditItem
    Friend WithEvents txtScanEdit As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents txtCodigoPoliza As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem79 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents btnClean As DevExpress.XtraBars.BarLargeButtonItem
    Friend WithEvents cmbAcuerdoHead As DevExpress.XtraEditors.GridLookUpEdit
    Friend WithEvents GridLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlItem80 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem81 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents colPCTDAI As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents pctDAI As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents cmbPolizaAsegurada As DevExpress.XtraEditors.GridLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents lblPolizaAsegurada As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents cmbBodegueros As DevExpress.XtraEditors.GridLookUpEdit
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlItem82 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents UIBotonRectificar As DevExpress.XtraBars.BarLargeButtonItem
    Friend WithEvents UIBotonRectificacion As DevExpress.XtraBars.BarLargeButtonItem
    Friend WithEvents UiListaImpuesto As DevExpress.XtraEditors.GridLookUpEdit
    Friend WithEvents UiListaVistaImpuesto As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents UiColDescripcionImpuesto As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UiLayoutControlImpuesto As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtDescripcionSku As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents colMaterialId As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents txtTicketNumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents layoutTicketFiscal As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem83 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents GridLookUpEdit3 As DevExpress.XtraEditors.GridLookUpEdit
    Friend WithEvents GridView10 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridLookUpEdit2 As DevExpress.XtraEditors.GridLookUpEdit
    Friend WithEvents GridView9 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridLookUpEdit1 As DevExpress.XtraEditors.GridLookUpEdit
    Friend WithEvents GridView7 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlItem77 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem84 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem85 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lookUpPrioridad As DevExpress.XtraEditors.GridLookUpEdit
    Friend WithEvents GridLookUpEdit4View As DevExpress.XtraGrid.Views.Grid.GridView
End Class
