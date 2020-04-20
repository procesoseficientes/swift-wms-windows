<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCertificateDeposit
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCertificateDeposit))
        Dim StyleFormatCondition1 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Dim StyleFormatCondition2 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Dim StyleFormatCondition3 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Dim StyleFormatCondition4 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim StyleFormatCondition5 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Dim StyleFormatCondition6 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Dim StyleFormatCondition7 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Dim StyleFormatCondition8 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Me.Bar1 = New DevExpress.XtraBars.Bar()
        Me.Bar2 = New DevExpress.XtraBars.Bar()
        Me.UiPanelContenido = New DevExpress.XtraEditors.PanelControl()
        Me.UiEtiquetaCliente = New DevExpress.XtraEditors.LabelControl()
        Me.UiSplitPrincipal = New DevExpress.XtraEditors.SplitContainerControl()
        Me.UiPopupEstado = New DevExpress.XtraBars.PopupControlContainer(Me.components)
        Me.UiEtiquetaComentarioTitulo = New DevExpress.XtraEditors.LabelControl()
        Me.UiMemoComentarioEstado = New DevExpress.XtraEditors.MemoEdit()
        Me.UiBarraPrincipal = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem2 = New DevExpress.XtraBars.BarButtonItem()
        Me.UiVistaCertificadoEncabezado = New DevExpress.XtraGrid.GridControl()
        Me.gridView5 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colCERTIFICATE_DEPOSIT_ID_HEADER = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colVALID_FROM = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colVALID_TO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSTATUS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCLIENT_CODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPICKING = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSERIAL_NUMBER = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTRANS_DATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LOGIN_ID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BarDockControl3 = New DevExpress.XtraBars.BarDockControl()
        Me.BarDockControl4 = New DevExpress.XtraBars.BarDockControl()
        Me.BarDockControl2 = New DevExpress.XtraBars.BarDockControl()
        Me.BarDockControl1 = New DevExpress.XtraBars.BarDockControl()
        Me.UiPopupReporte = New DevExpress.XtraBars.PopupControlContainer(Me.components)
        Me.UiTextoEndoso = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.UiCheckInGenerico = New DevExpress.XtraEditors.CheckEdit()
        Me.LabelControl13 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl12 = New DevExpress.XtraEditors.LabelControl()
        Me.UiListaAlmacenaje = New DevExpress.XtraEditors.GridLookUpEdit()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar9 = New DevExpress.XtraBars.Bar()
        Me.UiBotonImprimir = New DevExpress.XtraBars.BarButtonItem()
        Me.UiBotonAgregarCertificado = New DevExpress.XtraBars.BarButtonItem()
        Me.UiBotonBorrarDetCet = New DevExpress.XtraBars.BarButtonItem()
        Me.UiBotonNuevoCertificado = New DevExpress.XtraBars.BarButtonItem()
        Me.UiBotonGrabarCertificado = New DevExpress.XtraBars.BarButtonItem()
        Me.UiFechaInicioRecepcion = New DevExpress.XtraBars.BarEditItem()
        Me.RepositoryItemDateEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.UiFechaFinalRecepcion = New DevExpress.XtraBars.BarEditItem()
        Me.RepositoryItemDateEdit4 = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.UiBotonRefreshRecepcion = New DevExpress.XtraBars.BarButtonItem()
        Me.BarDockControl5 = New DevExpress.XtraBars.BarDockControl()
        Me.BarDockControl6 = New DevExpress.XtraBars.BarDockControl()
        Me.BarDockControl7 = New DevExpress.XtraBars.BarDockControl()
        Me.BarDockControl8 = New DevExpress.XtraBars.BarDockControl()
        Me.RepositoryItemCalcEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit()
        Me.RepositoryItemCalcEdit4 = New DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit()
        Me.GridView6 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LabelControl11 = New DevExpress.XtraEditors.LabelControl()
        Me.UiCheckSujetoAPagos = New DevExpress.XtraEditors.CheckEdit()
        Me.LabelControl10 = New DevExpress.XtraEditors.LabelControl()
        Me.UiSpinSerie = New DevExpress.XtraEditors.SpinEdit()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.UiEtiquetaFechaVencimiento = New DevExpress.XtraEditors.DateEdit()
        Me.UiEtiquetaEndoso = New System.Windows.Forms.Label()
        Me.UiSpinImpuesto = New DevExpress.XtraEditors.SpinEdit()
        Me.UiTextoNota = New DevExpress.XtraEditors.TextEdit()
        Me.UiFechaEmision = New DevExpress.XtraEditors.DateEdit()
        Me.UiCheckIndividual = New DevExpress.XtraEditors.CheckEdit()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.UiEtiquetaCertificadoId = New System.Windows.Forms.Label()
        Me.UiBotonGenerarReporte = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.UiBotonCancelarReporte = New DevExpress.XtraEditors.SimpleButton()
        Me.UiFechaValidoFinal = New DevExpress.XtraEditors.DateEdit()
        Me.UiFechaValidoInicio = New DevExpress.XtraEditors.DateEdit()
        Me.UiEtiquetaFechaValidoA = New DevExpress.XtraEditors.LabelControl()
        Me.UiEtiquetaFechaValidoDe = New DevExpress.XtraEditors.LabelControl()
        Me.UiVistaCertificadoDetalle = New DevExpress.XtraGrid.GridControl()
        Me.GridView4 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colDOC_ID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMATERIAL_CODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSKU_DESCRIPTION = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colLOCATIONS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBULTOS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colQTY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCUSTOMS_AMOUNT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UIListaRecepcionDetalle = New DevExpress.XtraEditors.GridLookUpEdit()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colListaMATERIAL_CODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colListaSKU_DESCRIPTION = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colListaLOCATIONS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colListaBULTOS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colListaQTY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colListaCUSTOMS_AMOUNT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colListaDOC_ID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colListaSTATUS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UiEtiquetaRecepcion = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.UiListaRecepcion = New DevExpress.XtraEditors.GridLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.UiListaCliente = New DevExpress.XtraEditors.GridLookUpEdit()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.barHeader = New DevExpress.XtraBars.Bar()
        Me.Bar3 = New DevExpress.XtraBars.Bar()
        Me.Bar4 = New DevExpress.XtraBars.Bar()
        Me.Bar5 = New DevExpress.XtraBars.Bar()
        Me.Bar6 = New DevExpress.XtraBars.Bar()
        Me.UiBarraCertificados = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar8 = New DevExpress.XtraBars.Bar()
        Me.UiFechaInicioCertificados1 = New DevExpress.XtraBars.BarEditItem()
        Me.RepositoryItemDateEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.UiFechaFinalCertificados = New DevExpress.XtraBars.BarEditItem()
        Me.RepositoryItemDateEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.UiBotonRefreshCertificado = New DevExpress.XtraBars.BarButtonItem()
        Me.UiListaEstados = New DevExpress.XtraBars.BarEditItem()
        Me.RepositoryItemComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.UiBotonCambiarEstado = New DevExpress.XtraBars.BarButtonItem()
        Me.UiFechaInicioCertificados = New DevExpress.XtraBars.BarEditItem()
        Me.RepositoryItemCalcEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit()
        Me.BarEditItem2 = New DevExpress.XtraBars.BarEditItem()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryItemCalcEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit()
        Me.RepositoryItemLookUpEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        CType(Me.UiPanelContenido, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiPanelContenido.SuspendLayout()
        CType(Me.UiSplitPrincipal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiSplitPrincipal.SuspendLayout()
        CType(Me.UiPopupEstado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiPopupEstado.SuspendLayout()
        CType(Me.UiMemoComentarioEstado.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiBarraPrincipal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiVistaCertificadoEncabezado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridView5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiPopupReporte, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiPopupReporte.SuspendLayout()
        CType(Me.UiTextoEndoso.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCheckInGenerico.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiListaAlmacenaje.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit3.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit4.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCalcEdit3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCalcEdit4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCheckSujetoAPagos.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiSpinSerie.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiEtiquetaFechaVencimiento.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiEtiquetaFechaVencimiento.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiSpinImpuesto.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiTextoNota.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiFechaEmision.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiFechaEmision.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCheckIndividual.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiFechaValidoFinal.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiFechaValidoFinal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiFechaValidoInicio.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiFechaValidoInicio.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiVistaCertificadoDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UIListaRecepcionDetalle.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiListaRecepcion.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiListaCliente.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiBarraCertificados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit2.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCalcEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCalcEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLookUpEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.BarName = "Herramientas"
        Me.Bar1.DockCol = 0
        Me.Bar1.DockRow = 0
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar1.OptionsBar.AllowQuickCustomization = False
        Me.Bar1.OptionsBar.DrawDragBorder = False
        Me.Bar1.OptionsBar.UseWholeRow = True
        Me.Bar1.Text = "Herramientas"
        '
        'Bar2
        '
        Me.Bar2.BarName = "Herramientas"
        Me.Bar2.DockCol = 0
        Me.Bar2.DockRow = 0
        Me.Bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar2.OptionsBar.AllowQuickCustomization = False
        Me.Bar2.OptionsBar.DrawDragBorder = False
        Me.Bar2.OptionsBar.UseWholeRow = True
        Me.Bar2.Text = "Herramientas"
        '
        'UiPanelContenido
        '
        Me.UiPanelContenido.Controls.Add(Me.UiEtiquetaCliente)
        Me.UiPanelContenido.Controls.Add(Me.UiSplitPrincipal)
        Me.UiPanelContenido.Controls.Add(Me.UiListaCliente)
        Me.UiPanelContenido.Controls.Add(Me.barDockControlLeft)
        Me.UiPanelContenido.Controls.Add(Me.barDockControlRight)
        Me.UiPanelContenido.Controls.Add(Me.barDockControlBottom)
        Me.UiPanelContenido.Controls.Add(Me.barDockControlTop)
        Me.UiPanelContenido.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UiPanelContenido.Location = New System.Drawing.Point(0, 0)
        Me.UiPanelContenido.Name = "UiPanelContenido"
        Me.UiPanelContenido.Size = New System.Drawing.Size(1474, 729)
        Me.UiPanelContenido.TabIndex = 10
        '
        'UiEtiquetaCliente
        '
        Me.UiEtiquetaCliente.Location = New System.Drawing.Point(12, 12)
        Me.UiEtiquetaCliente.Name = "UiEtiquetaCliente"
        Me.UiEtiquetaCliente.Size = New System.Drawing.Size(37, 13)
        Me.UiEtiquetaCliente.TabIndex = 15
        Me.UiEtiquetaCliente.Text = "Cliente:"
        '
        'UiSplitPrincipal
        '
        Me.UiSplitPrincipal.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UiSplitPrincipal.Location = New System.Drawing.Point(2, 38)
        Me.UiSplitPrincipal.Name = "UiSplitPrincipal"
        Me.UiSplitPrincipal.Panel1.Controls.Add(Me.UiPopupEstado)
        Me.UiSplitPrincipal.Panel1.Controls.Add(Me.UiVistaCertificadoEncabezado)
        Me.UiSplitPrincipal.Panel1.Controls.Add(Me.BarDockControl3)
        Me.UiSplitPrincipal.Panel1.Controls.Add(Me.BarDockControl4)
        Me.UiSplitPrincipal.Panel1.Controls.Add(Me.BarDockControl2)
        Me.UiSplitPrincipal.Panel1.Controls.Add(Me.BarDockControl1)
        Me.UiSplitPrincipal.Panel1.Text = "Panel1"
        Me.UiSplitPrincipal.Panel2.Controls.Add(Me.UiPopupReporte)
        Me.UiSplitPrincipal.Panel2.Controls.Add(Me.UiFechaValidoFinal)
        Me.UiSplitPrincipal.Panel2.Controls.Add(Me.UiFechaValidoInicio)
        Me.UiSplitPrincipal.Panel2.Controls.Add(Me.UiEtiquetaFechaValidoA)
        Me.UiSplitPrincipal.Panel2.Controls.Add(Me.UiEtiquetaFechaValidoDe)
        Me.UiSplitPrincipal.Panel2.Controls.Add(Me.UiVistaCertificadoDetalle)
        Me.UiSplitPrincipal.Panel2.Controls.Add(Me.UIListaRecepcionDetalle)
        Me.UiSplitPrincipal.Panel2.Controls.Add(Me.UiEtiquetaRecepcion)
        Me.UiSplitPrincipal.Panel2.Controls.Add(Me.LabelControl1)
        Me.UiSplitPrincipal.Panel2.Controls.Add(Me.UiListaRecepcion)
        Me.UiSplitPrincipal.Panel2.Controls.Add(Me.BarDockControl7)
        Me.UiSplitPrincipal.Panel2.Controls.Add(Me.BarDockControl8)
        Me.UiSplitPrincipal.Panel2.Controls.Add(Me.BarDockControl6)
        Me.UiSplitPrincipal.Panel2.Controls.Add(Me.BarDockControl5)
        Me.UiSplitPrincipal.Panel2.Text = "Panel2"
        Me.UiSplitPrincipal.Size = New System.Drawing.Size(1472, 691)
        Me.UiSplitPrincipal.SplitterPosition = 657
        Me.UiSplitPrincipal.TabIndex = 6
        Me.UiSplitPrincipal.Text = "SplitContainerControl1"
        '
        'UiPopupEstado
        '
        Me.UiPopupEstado.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.UiPopupEstado.Controls.Add(Me.UiEtiquetaComentarioTitulo)
        Me.UiPopupEstado.Controls.Add(Me.UiMemoComentarioEstado)
        Me.UiPopupEstado.Location = New System.Drawing.Point(356, 31)
        Me.UiPopupEstado.Manager = Me.UiBarraPrincipal
        Me.UiPopupEstado.Name = "UiPopupEstado"
        Me.UiPopupEstado.Size = New System.Drawing.Size(250, 95)
        Me.UiPopupEstado.TabIndex = 11
        Me.UiPopupEstado.Visible = False
        '
        'UiEtiquetaComentarioTitulo
        '
        Me.UiEtiquetaComentarioTitulo.Location = New System.Drawing.Point(13, 10)
        Me.UiEtiquetaComentarioTitulo.Name = "UiEtiquetaComentarioTitulo"
        Me.UiEtiquetaComentarioTitulo.Size = New System.Drawing.Size(59, 13)
        Me.UiEtiquetaComentarioTitulo.TabIndex = 6
        Me.UiEtiquetaComentarioTitulo.Text = "Comentario:"
        '
        'UiMemoComentarioEstado
        '
        Me.UiMemoComentarioEstado.Location = New System.Drawing.Point(13, 29)
        Me.UiMemoComentarioEstado.MenuManager = Me.UiBarraPrincipal
        Me.UiMemoComentarioEstado.Name = "UiMemoComentarioEstado"
        Me.UiMemoComentarioEstado.Properties.MaxLength = 250
        Me.UiMemoComentarioEstado.Size = New System.Drawing.Size(223, 52)
        Me.UiMemoComentarioEstado.TabIndex = 0
        '
        'UiBarraPrincipal
        '
        Me.UiBarraPrincipal.DockControls.Add(Me.barDockControlTop)
        Me.UiBarraPrincipal.DockControls.Add(Me.barDockControlBottom)
        Me.UiBarraPrincipal.DockControls.Add(Me.barDockControlLeft)
        Me.UiBarraPrincipal.DockControls.Add(Me.barDockControlRight)
        Me.UiBarraPrincipal.Form = Me.UiPanelContenido
        Me.UiBarraPrincipal.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.BarButtonItem1, Me.BarButtonItem2})
        Me.UiBarraPrincipal.MaxItemId = 2
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(2, 2)
        Me.barDockControlTop.Size = New System.Drawing.Size(1470, 0)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(2, 727)
        Me.barDockControlBottom.Size = New System.Drawing.Size(1470, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(2, 2)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 725)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(1472, 2)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 725)
        '
        'BarButtonItem1
        '
        Me.BarButtonItem1.Caption = "Nuevo"
        Me.BarButtonItem1.Glyph = CType(resources.GetObject("BarButtonItem1.Glyph"), System.Drawing.Image)
        Me.BarButtonItem1.Id = 0
        Me.BarButtonItem1.LargeGlyph = CType(resources.GetObject("BarButtonItem1.LargeGlyph"), System.Drawing.Image)
        Me.BarButtonItem1.Name = "BarButtonItem1"
        '
        'BarButtonItem2
        '
        Me.BarButtonItem2.Caption = "Grabar"
        Me.BarButtonItem2.Glyph = CType(resources.GetObject("BarButtonItem2.Glyph"), System.Drawing.Image)
        Me.BarButtonItem2.Id = 1
        Me.BarButtonItem2.LargeGlyph = CType(resources.GetObject("BarButtonItem2.LargeGlyph"), System.Drawing.Image)
        Me.BarButtonItem2.Name = "BarButtonItem2"
        '
        'UiVistaCertificadoEncabezado
        '
        Me.UiVistaCertificadoEncabezado.Cursor = System.Windows.Forms.Cursors.Default
        Me.UiVistaCertificadoEncabezado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UiVistaCertificadoEncabezado.Location = New System.Drawing.Point(0, 31)
        Me.UiVistaCertificadoEncabezado.MainView = Me.gridView5
        Me.UiVistaCertificadoEncabezado.Name = "UiVistaCertificadoEncabezado"
        Me.UiVistaCertificadoEncabezado.Size = New System.Drawing.Size(657, 660)
        Me.UiVistaCertificadoEncabezado.TabIndex = 6
        Me.UiVistaCertificadoEncabezado.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridView5})
        '
        'gridView5
        '
        Me.gridView5.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colCERTIFICATE_DEPOSIT_ID_HEADER, Me.colVALID_FROM, Me.colVALID_TO, Me.colSTATUS, Me.colCLIENT_CODE, Me.colPICKING, Me.colSERIAL_NUMBER, Me.colTRANS_DATE, Me.LOGIN_ID})
        StyleFormatCondition1.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        StyleFormatCondition1.Appearance.Options.UseBackColor = True
        StyleFormatCondition1.ApplyToRow = True
        StyleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression
        StyleFormatCondition1.Expression = "[STATUS] ==  'PENDIENTE'"
        StyleFormatCondition2.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        StyleFormatCondition2.Appearance.Options.UseBackColor = True
        StyleFormatCondition2.ApplyToRow = True
        StyleFormatCondition2.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression
        StyleFormatCondition2.Expression = "[STATUS] == 'ASOCIADO'"
        StyleFormatCondition3.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        StyleFormatCondition3.Appearance.Options.UseBackColor = True
        StyleFormatCondition3.ApplyToRow = True
        StyleFormatCondition3.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression
        StyleFormatCondition3.Expression = "[PICKING]  ==  'NO'"
        StyleFormatCondition4.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        StyleFormatCondition4.Appearance.Options.UseBackColor = True
        StyleFormatCondition4.ApplyToRow = True
        StyleFormatCondition4.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression
        StyleFormatCondition4.Expression = "[PICKING]  ==  'SI'"
        Me.gridView5.FormatConditions.AddRange(New DevExpress.XtraGrid.StyleFormatCondition() {StyleFormatCondition1, StyleFormatCondition2, StyleFormatCondition3, StyleFormatCondition4})
        Me.gridView5.GridControl = Me.UiVistaCertificadoEncabezado
        Me.gridView5.Name = "gridView5"
        Me.gridView5.OptionsView.ShowFooter = True
        '
        'colCERTIFICATE_DEPOSIT_ID_HEADER
        '
        Me.colCERTIFICATE_DEPOSIT_ID_HEADER.Caption = "Numero Documento"
        Me.colCERTIFICATE_DEPOSIT_ID_HEADER.FieldName = "CERTIFICATE_DEPOSIT_ID_HEADER"
        Me.colCERTIFICATE_DEPOSIT_ID_HEADER.Name = "colCERTIFICATE_DEPOSIT_ID_HEADER"
        Me.colCERTIFICATE_DEPOSIT_ID_HEADER.OptionsColumn.AllowEdit = False
        Me.colCERTIFICATE_DEPOSIT_ID_HEADER.OptionsColumn.AllowFocus = False
        Me.colCERTIFICATE_DEPOSIT_ID_HEADER.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "CERTIFICATE_DEPOSIT_ID_HEADER", "Cantidad: {0}")})
        Me.colCERTIFICATE_DEPOSIT_ID_HEADER.Visible = True
        Me.colCERTIFICATE_DEPOSIT_ID_HEADER.VisibleIndex = 0
        '
        'colVALID_FROM
        '
        Me.colVALID_FROM.Caption = "Fecha Inicio"
        Me.colVALID_FROM.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.colVALID_FROM.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.colVALID_FROM.FieldName = "VALID_FROM"
        Me.colVALID_FROM.Name = "colVALID_FROM"
        Me.colVALID_FROM.OptionsColumn.AllowEdit = False
        Me.colVALID_FROM.OptionsColumn.AllowFocus = False
        Me.colVALID_FROM.Visible = True
        Me.colVALID_FROM.VisibleIndex = 1
        '
        'colVALID_TO
        '
        Me.colVALID_TO.Caption = "Fecha Final"
        Me.colVALID_TO.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.colVALID_TO.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.colVALID_TO.FieldName = "VALID_TO"
        Me.colVALID_TO.Name = "colVALID_TO"
        Me.colVALID_TO.OptionsColumn.AllowEdit = False
        Me.colVALID_TO.OptionsColumn.AllowFocus = False
        Me.colVALID_TO.Visible = True
        Me.colVALID_TO.VisibleIndex = 2
        '
        'colSTATUS
        '
        Me.colSTATUS.Caption = "Estado"
        Me.colSTATUS.FieldName = "STATUS"
        Me.colSTATUS.Name = "colSTATUS"
        Me.colSTATUS.OptionsColumn.AllowEdit = False
        Me.colSTATUS.Visible = True
        Me.colSTATUS.VisibleIndex = 4
        '
        'colCLIENT_CODE
        '
        Me.colCLIENT_CODE.Caption = "Codigo Cliente"
        Me.colCLIENT_CODE.FieldName = "CLIENT_CODE"
        Me.colCLIENT_CODE.Name = "colCLIENT_CODE"
        Me.colCLIENT_CODE.OptionsColumn.AllowEdit = False
        Me.colCLIENT_CODE.OptionsColumn.AllowFocus = False
        Me.colCLIENT_CODE.Visible = True
        Me.colCLIENT_CODE.VisibleIndex = 3
        '
        'colPICKING
        '
        Me.colPICKING.Caption = "Tiene Despacho"
        Me.colPICKING.FieldName = "PICKING"
        Me.colPICKING.Name = "colPICKING"
        Me.colPICKING.OptionsColumn.AllowEdit = False
        Me.colPICKING.Visible = True
        Me.colPICKING.VisibleIndex = 5
        '
        'colSERIAL_NUMBER
        '
        Me.colSERIAL_NUMBER.Caption = "Num. Transacción"
        Me.colSERIAL_NUMBER.FieldName = "SERIAL_NUMBER"
        Me.colSERIAL_NUMBER.Name = "colSERIAL_NUMBER"
        Me.colSERIAL_NUMBER.OptionsColumn.AllowEdit = False
        Me.colSERIAL_NUMBER.Visible = True
        Me.colSERIAL_NUMBER.VisibleIndex = 6
        '
        'colTRANS_DATE
        '
        Me.colTRANS_DATE.Caption = "Fecha Transacción"
        Me.colTRANS_DATE.FieldName = "TRANS_DATE"
        Me.colTRANS_DATE.Name = "colTRANS_DATE"
        Me.colTRANS_DATE.OptionsColumn.AllowEdit = False
        Me.colTRANS_DATE.Visible = True
        Me.colTRANS_DATE.VisibleIndex = 7
        '
        'LOGIN_ID
        '
        Me.LOGIN_ID.Caption = "Operador de Transacción"
        Me.LOGIN_ID.FieldName = "LOGIN_ID"
        Me.LOGIN_ID.Name = "LOGIN_ID"
        Me.LOGIN_ID.OptionsColumn.AllowEdit = False
        Me.LOGIN_ID.Visible = True
        Me.LOGIN_ID.VisibleIndex = 8
        '
        'BarDockControl3
        '
        Me.BarDockControl3.CausesValidation = False
        Me.BarDockControl3.Dock = System.Windows.Forms.DockStyle.Left
        Me.BarDockControl3.Location = New System.Drawing.Point(0, 31)
        Me.BarDockControl3.Size = New System.Drawing.Size(0, 660)
        '
        'BarDockControl4
        '
        Me.BarDockControl4.CausesValidation = False
        Me.BarDockControl4.Dock = System.Windows.Forms.DockStyle.Right
        Me.BarDockControl4.Location = New System.Drawing.Point(657, 31)
        Me.BarDockControl4.Size = New System.Drawing.Size(0, 660)
        '
        'BarDockControl2
        '
        Me.BarDockControl2.CausesValidation = False
        Me.BarDockControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarDockControl2.Location = New System.Drawing.Point(0, 691)
        Me.BarDockControl2.Size = New System.Drawing.Size(657, 0)
        '
        'BarDockControl1
        '
        Me.BarDockControl1.CausesValidation = False
        Me.BarDockControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.BarDockControl1.Location = New System.Drawing.Point(0, 0)
        Me.BarDockControl1.Size = New System.Drawing.Size(657, 31)
        '
        'UiPopupReporte
        '
        Me.UiPopupReporte.AutoSize = True
        Me.UiPopupReporte.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.UiPopupReporte.Controls.Add(Me.UiTextoEndoso)
        Me.UiPopupReporte.Controls.Add(Me.LabelControl4)
        Me.UiPopupReporte.Controls.Add(Me.UiCheckInGenerico)
        Me.UiPopupReporte.Controls.Add(Me.LabelControl13)
        Me.UiPopupReporte.Controls.Add(Me.LabelControl12)
        Me.UiPopupReporte.Controls.Add(Me.UiListaAlmacenaje)
        Me.UiPopupReporte.Controls.Add(Me.LabelControl11)
        Me.UiPopupReporte.Controls.Add(Me.UiCheckSujetoAPagos)
        Me.UiPopupReporte.Controls.Add(Me.LabelControl10)
        Me.UiPopupReporte.Controls.Add(Me.UiSpinSerie)
        Me.UiPopupReporte.Controls.Add(Me.LabelControl9)
        Me.UiPopupReporte.Controls.Add(Me.UiEtiquetaFechaVencimiento)
        Me.UiPopupReporte.Controls.Add(Me.UiEtiquetaEndoso)
        Me.UiPopupReporte.Controls.Add(Me.UiSpinImpuesto)
        Me.UiPopupReporte.Controls.Add(Me.UiTextoNota)
        Me.UiPopupReporte.Controls.Add(Me.UiFechaEmision)
        Me.UiPopupReporte.Controls.Add(Me.UiCheckIndividual)
        Me.UiPopupReporte.Controls.Add(Me.LabelControl8)
        Me.UiPopupReporte.Controls.Add(Me.LabelControl7)
        Me.UiPopupReporte.Controls.Add(Me.LabelControl3)
        Me.UiPopupReporte.Controls.Add(Me.LabelControl2)
        Me.UiPopupReporte.Controls.Add(Me.LabelControl6)
        Me.UiPopupReporte.Controls.Add(Me.UiEtiquetaCertificadoId)
        Me.UiPopupReporte.Controls.Add(Me.UiBotonGenerarReporte)
        Me.UiPopupReporte.Controls.Add(Me.LabelControl5)
        Me.UiPopupReporte.Controls.Add(Me.UiBotonCancelarReporte)
        Me.UiPopupReporte.Location = New System.Drawing.Point(1, 31)
        Me.UiPopupReporte.Manager = Me.BarManager1
        Me.UiPopupReporte.Name = "UiPopupReporte"
        Me.UiPopupReporte.ShowCloseButton = True
        Me.UiPopupReporte.ShowSizeGrip = True
        Me.UiPopupReporte.Size = New System.Drawing.Size(309, 267)
        Me.UiPopupReporte.TabIndex = 11
        Me.UiPopupReporte.Visible = False
        '
        'UiTextoEndoso
        '
        Me.UiTextoEndoso.Location = New System.Drawing.Point(131, 209)
        Me.UiTextoEndoso.MenuManager = Me.UiBarraPrincipal
        Me.UiTextoEndoso.Name = "UiTextoEndoso"
        Me.UiTextoEndoso.Size = New System.Drawing.Size(166, 20)
        Me.UiTextoEndoso.TabIndex = 9
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(11, 212)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(39, 13)
        Me.LabelControl4.TabIndex = 29
        Me.LabelControl4.Text = "Endoso:"
        '
        'UiCheckInGenerico
        '
        Me.UiCheckInGenerico.Location = New System.Drawing.Point(259, 30)
        Me.UiCheckInGenerico.MenuManager = Me.UiBarraPrincipal
        Me.UiCheckInGenerico.Name = "UiCheckInGenerico"
        Me.UiCheckInGenerico.Properties.Caption = ""
        Me.UiCheckInGenerico.Size = New System.Drawing.Size(22, 19)
        Me.UiCheckInGenerico.TabIndex = 0
        '
        'LabelControl13
        '
        Me.LabelControl13.Location = New System.Drawing.Point(11, 33)
        Me.LabelControl13.Name = "LabelControl13"
        Me.LabelControl13.Size = New System.Drawing.Size(110, 13)
        Me.LabelControl13.TabIndex = 27
        Me.LabelControl13.Text = "Designación Individual:"
        '
        'LabelControl12
        '
        Me.LabelControl12.Location = New System.Drawing.Point(11, 55)
        Me.LabelControl12.Name = "LabelControl12"
        Me.LabelControl12.Size = New System.Drawing.Size(59, 13)
        Me.LabelControl12.TabIndex = 26
        Me.LabelControl12.Text = "Almacenaje:"
        '
        'UiListaAlmacenaje
        '
        Me.UiListaAlmacenaje.Location = New System.Drawing.Point(131, 51)
        Me.UiListaAlmacenaje.MenuManager = Me.BarManager1
        Me.UiListaAlmacenaje.Name = "UiListaAlmacenaje"
        Me.UiListaAlmacenaje.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Refresh", -1, True, True, True, DevExpress.XtraEditors.ImageLocation.MiddleCenter, CType(resources.GetObject("UiListaAlmacenaje.Properties.Buttons"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, "", "REFRESH", Nothing, True)})
        Me.UiListaAlmacenaje.Properties.NullText = "Seleccione un Registro"
        Me.UiListaAlmacenaje.Properties.PopupFormMinSize = New System.Drawing.Size(700, 0)
        Me.UiListaAlmacenaje.Properties.View = Me.GridView6
        Me.UiListaAlmacenaje.Size = New System.Drawing.Size(166, 22)
        Me.UiListaAlmacenaje.TabIndex = 2
        '
        'BarManager1
        '
        Me.BarManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Bar9})
        Me.BarManager1.DockControls.Add(Me.BarDockControl5)
        Me.BarManager1.DockControls.Add(Me.BarDockControl6)
        Me.BarManager1.DockControls.Add(Me.BarDockControl7)
        Me.BarManager1.DockControls.Add(Me.BarDockControl8)
        Me.BarManager1.Form = Me.UiSplitPrincipal.Panel2
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.UiBotonNuevoCertificado, Me.UiBotonGrabarCertificado, Me.UiBotonRefreshRecepcion, Me.UiFechaInicioRecepcion, Me.UiFechaFinalRecepcion, Me.UiBotonAgregarCertificado, Me.UiBotonBorrarDetCet, Me.UiBotonImprimir})
        Me.BarManager1.MaxItemId = 10
        Me.BarManager1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCalcEdit3, Me.RepositoryItemCalcEdit4, Me.RepositoryItemDateEdit3, Me.RepositoryItemDateEdit4})
        '
        'Bar9
        '
        Me.Bar9.BarName = "Tools"
        Me.Bar9.DockCol = 0
        Me.Bar9.DockRow = 0
        Me.Bar9.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar9.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.UiBotonImprimir, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.UiBotonAgregarCertificado, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.UiBotonBorrarDetCet, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.UiBotonNuevoCertificado, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.UiBotonGrabarCertificado, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.UiFechaInicioRecepcion, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.UiFechaFinalRecepcion, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.UiBotonRefreshRecepcion, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)})
        Me.Bar9.OptionsBar.AllowQuickCustomization = False
        Me.Bar9.OptionsBar.DrawDragBorder = False
        Me.Bar9.OptionsBar.UseWholeRow = True
        Me.Bar9.Text = "Tools"
        '
        'UiBotonImprimir
        '
        Me.UiBotonImprimir.Caption = "Print"
        Me.UiBotonImprimir.Glyph = CType(resources.GetObject("UiBotonImprimir.Glyph"), System.Drawing.Image)
        Me.UiBotonImprimir.Id = 9
        Me.UiBotonImprimir.LargeGlyph = CType(resources.GetObject("UiBotonImprimir.LargeGlyph"), System.Drawing.Image)
        Me.UiBotonImprimir.Name = "UiBotonImprimir"
        '
        'UiBotonAgregarCertificado
        '
        Me.UiBotonAgregarCertificado.Caption = "Agregar"
        Me.UiBotonAgregarCertificado.Glyph = CType(resources.GetObject("UiBotonAgregarCertificado.Glyph"), System.Drawing.Image)
        Me.UiBotonAgregarCertificado.Id = 7
        Me.UiBotonAgregarCertificado.LargeGlyph = CType(resources.GetObject("UiBotonAgregarCertificado.LargeGlyph"), System.Drawing.Image)
        Me.UiBotonAgregarCertificado.Name = "UiBotonAgregarCertificado"
        '
        'UiBotonBorrarDetCet
        '
        Me.UiBotonBorrarDetCet.Caption = "Eliminar"
        Me.UiBotonBorrarDetCet.Glyph = CType(resources.GetObject("UiBotonBorrarDetCet.Glyph"), System.Drawing.Image)
        Me.UiBotonBorrarDetCet.Id = 8
        Me.UiBotonBorrarDetCet.LargeGlyph = CType(resources.GetObject("UiBotonBorrarDetCet.LargeGlyph"), System.Drawing.Image)
        Me.UiBotonBorrarDetCet.Name = "UiBotonBorrarDetCet"
        '
        'UiBotonNuevoCertificado
        '
        Me.UiBotonNuevoCertificado.Caption = "Nuevo"
        Me.UiBotonNuevoCertificado.Glyph = CType(resources.GetObject("UiBotonNuevoCertificado.Glyph"), System.Drawing.Image)
        Me.UiBotonNuevoCertificado.Id = 0
        Me.UiBotonNuevoCertificado.LargeGlyph = CType(resources.GetObject("UiBotonNuevoCertificado.LargeGlyph"), System.Drawing.Image)
        Me.UiBotonNuevoCertificado.Name = "UiBotonNuevoCertificado"
        '
        'UiBotonGrabarCertificado
        '
        Me.UiBotonGrabarCertificado.Caption = "Grabar"
        Me.UiBotonGrabarCertificado.Glyph = CType(resources.GetObject("UiBotonGrabarCertificado.Glyph"), System.Drawing.Image)
        Me.UiBotonGrabarCertificado.Id = 1
        Me.UiBotonGrabarCertificado.LargeGlyph = CType(resources.GetObject("UiBotonGrabarCertificado.LargeGlyph"), System.Drawing.Image)
        Me.UiBotonGrabarCertificado.Name = "UiBotonGrabarCertificado"
        '
        'UiFechaInicioRecepcion
        '
        Me.UiFechaInicioRecepcion.Caption = "Fecha Inicio"
        Me.UiFechaInicioRecepcion.Edit = Me.RepositoryItemDateEdit3
        Me.UiFechaInicioRecepcion.Glyph = CType(resources.GetObject("UiFechaInicioRecepcion.Glyph"), System.Drawing.Image)
        Me.UiFechaInicioRecepcion.Id = 5
        Me.UiFechaInicioRecepcion.LargeGlyph = CType(resources.GetObject("UiFechaInicioRecepcion.LargeGlyph"), System.Drawing.Image)
        Me.UiFechaInicioRecepcion.Name = "UiFechaInicioRecepcion"
        Me.UiFechaInicioRecepcion.Width = 100
        '
        'RepositoryItemDateEdit3
        '
        Me.RepositoryItemDateEdit3.AutoHeight = False
        Me.RepositoryItemDateEdit3.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemDateEdit3.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemDateEdit3.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.RepositoryItemDateEdit3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.RepositoryItemDateEdit3.EditFormat.FormatString = "dd/MM/yyyy"
        Me.RepositoryItemDateEdit3.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.RepositoryItemDateEdit3.Name = "RepositoryItemDateEdit3"
        '
        'UiFechaFinalRecepcion
        '
        Me.UiFechaFinalRecepcion.Caption = "Fecha Final"
        Me.UiFechaFinalRecepcion.Edit = Me.RepositoryItemDateEdit4
        Me.UiFechaFinalRecepcion.Glyph = CType(resources.GetObject("UiFechaFinalRecepcion.Glyph"), System.Drawing.Image)
        Me.UiFechaFinalRecepcion.Id = 6
        Me.UiFechaFinalRecepcion.LargeGlyph = CType(resources.GetObject("UiFechaFinalRecepcion.LargeGlyph"), System.Drawing.Image)
        Me.UiFechaFinalRecepcion.Name = "UiFechaFinalRecepcion"
        Me.UiFechaFinalRecepcion.Width = 100
        '
        'RepositoryItemDateEdit4
        '
        Me.RepositoryItemDateEdit4.AutoHeight = False
        Me.RepositoryItemDateEdit4.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemDateEdit4.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemDateEdit4.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.RepositoryItemDateEdit4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.RepositoryItemDateEdit4.EditFormat.FormatString = "dd/MM/yyyy"
        Me.RepositoryItemDateEdit4.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.RepositoryItemDateEdit4.Name = "RepositoryItemDateEdit4"
        '
        'UiBotonRefreshRecepcion
        '
        Me.UiBotonRefreshRecepcion.Caption = "Refresh"
        Me.UiBotonRefreshRecepcion.Glyph = CType(resources.GetObject("UiBotonRefreshRecepcion.Glyph"), System.Drawing.Image)
        Me.UiBotonRefreshRecepcion.Id = 4
        Me.UiBotonRefreshRecepcion.LargeGlyph = CType(resources.GetObject("UiBotonRefreshRecepcion.LargeGlyph"), System.Drawing.Image)
        Me.UiBotonRefreshRecepcion.Name = "UiBotonRefreshRecepcion"
        '
        'BarDockControl5
        '
        Me.BarDockControl5.CausesValidation = False
        Me.BarDockControl5.Dock = System.Windows.Forms.DockStyle.Top
        Me.BarDockControl5.Location = New System.Drawing.Point(0, 0)
        Me.BarDockControl5.Size = New System.Drawing.Size(810, 31)
        '
        'BarDockControl6
        '
        Me.BarDockControl6.CausesValidation = False
        Me.BarDockControl6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarDockControl6.Location = New System.Drawing.Point(0, 691)
        Me.BarDockControl6.Size = New System.Drawing.Size(810, 0)
        '
        'BarDockControl7
        '
        Me.BarDockControl7.CausesValidation = False
        Me.BarDockControl7.Dock = System.Windows.Forms.DockStyle.Left
        Me.BarDockControl7.Location = New System.Drawing.Point(0, 31)
        Me.BarDockControl7.Size = New System.Drawing.Size(0, 660)
        '
        'BarDockControl8
        '
        Me.BarDockControl8.CausesValidation = False
        Me.BarDockControl8.Dock = System.Windows.Forms.DockStyle.Right
        Me.BarDockControl8.Location = New System.Drawing.Point(810, 31)
        Me.BarDockControl8.Size = New System.Drawing.Size(0, 660)
        '
        'RepositoryItemCalcEdit3
        '
        Me.RepositoryItemCalcEdit3.AutoHeight = False
        Me.RepositoryItemCalcEdit3.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemCalcEdit3.Name = "RepositoryItemCalcEdit3"
        '
        'RepositoryItemCalcEdit4
        '
        Me.RepositoryItemCalcEdit4.AutoHeight = False
        Me.RepositoryItemCalcEdit4.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemCalcEdit4.Name = "RepositoryItemCalcEdit4"
        '
        'GridView6
        '
        Me.GridView6.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView6.Name = "GridView6"
        Me.GridView6.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView6.OptionsView.ShowAutoFilterRow = True
        Me.GridView6.OptionsView.ShowGroupPanel = False
        '
        'LabelControl11
        '
        Me.LabelControl11.Location = New System.Drawing.Point(168, 188)
        Me.LabelControl11.Name = "LabelControl11"
        Me.LabelControl11.Size = New System.Drawing.Size(20, 13)
        Me.LabelControl11.TabIndex = 24
        Me.LabelControl11.Text = "Lps:"
        '
        'UiCheckSujetoAPagos
        '
        Me.UiCheckSujetoAPagos.Location = New System.Drawing.Point(147, 183)
        Me.UiCheckSujetoAPagos.MenuManager = Me.UiBarraPrincipal
        Me.UiCheckSujetoAPagos.Name = "UiCheckSujetoAPagos"
        Me.UiCheckSujetoAPagos.Properties.Caption = ""
        Me.UiCheckSujetoAPagos.Size = New System.Drawing.Size(22, 19)
        Me.UiCheckSujetoAPagos.TabIndex = 7
        '
        'LabelControl10
        '
        Me.LabelControl10.Location = New System.Drawing.Point(11, 186)
        Me.LabelControl10.Name = "LabelControl10"
        Me.LabelControl10.Size = New System.Drawing.Size(131, 13)
        Me.LabelControl10.TabIndex = 22
        Me.LabelControl10.Text = "Mercaderia sujetas a pago:"
        '
        'UiSpinSerie
        '
        Me.UiSpinSerie.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.UiSpinSerie.Location = New System.Drawing.Point(132, 157)
        Me.UiSpinSerie.MenuManager = Me.UiBarraPrincipal
        Me.UiSpinSerie.Name = "UiSpinSerie"
        Me.UiSpinSerie.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.UiSpinSerie.Size = New System.Drawing.Size(165, 20)
        Me.UiSpinSerie.TabIndex = 6
        '
        'LabelControl9
        '
        Me.LabelControl9.Location = New System.Drawing.Point(11, 160)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(62, 13)
        Me.LabelControl9.TabIndex = 20
        Me.LabelControl9.Text = "Numero Hoja"
        '
        'UiEtiquetaFechaVencimiento
        '
        Me.UiEtiquetaFechaVencimiento.EditValue = Nothing
        Me.UiEtiquetaFechaVencimiento.Location = New System.Drawing.Point(131, 105)
        Me.UiEtiquetaFechaVencimiento.MenuManager = Me.UiBarraPrincipal
        Me.UiEtiquetaFechaVencimiento.Name = "UiEtiquetaFechaVencimiento"
        Me.UiEtiquetaFechaVencimiento.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.UiEtiquetaFechaVencimiento.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.UiEtiquetaFechaVencimiento.Size = New System.Drawing.Size(166, 20)
        Me.UiEtiquetaFechaVencimiento.TabIndex = 4
        '
        'UiEtiquetaEndoso
        '
        Me.UiEtiquetaEndoso.AutoSize = True
        Me.UiEtiquetaEndoso.Location = New System.Drawing.Point(23, 247)
        Me.UiEtiquetaEndoso.Name = "UiEtiquetaEndoso"
        Me.UiEtiquetaEndoso.Size = New System.Drawing.Size(39, 13)
        Me.UiEtiquetaEndoso.TabIndex = 16
        Me.UiEtiquetaEndoso.Text = "Label1"
        Me.UiEtiquetaEndoso.Visible = False
        '
        'UiSpinImpuesto
        '
        Me.UiSpinImpuesto.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.UiSpinImpuesto.Location = New System.Drawing.Point(192, 183)
        Me.UiSpinImpuesto.MenuManager = Me.UiBarraPrincipal
        Me.UiSpinImpuesto.Name = "UiSpinImpuesto"
        Me.UiSpinImpuesto.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.UiSpinImpuesto.Size = New System.Drawing.Size(105, 20)
        Me.UiSpinImpuesto.TabIndex = 8
        '
        'UiTextoNota
        '
        Me.UiTextoNota.Location = New System.Drawing.Point(131, 131)
        Me.UiTextoNota.MenuManager = Me.UiBarraPrincipal
        Me.UiTextoNota.Name = "UiTextoNota"
        Me.UiTextoNota.Size = New System.Drawing.Size(166, 20)
        Me.UiTextoNota.TabIndex = 5
        '
        'UiFechaEmision
        '
        Me.UiFechaEmision.EditValue = Nothing
        Me.UiFechaEmision.Location = New System.Drawing.Point(131, 79)
        Me.UiFechaEmision.MenuManager = Me.UiBarraPrincipal
        Me.UiFechaEmision.Name = "UiFechaEmision"
        Me.UiFechaEmision.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.UiFechaEmision.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.UiFechaEmision.Size = New System.Drawing.Size(166, 20)
        Me.UiFechaEmision.TabIndex = 3
        '
        'UiCheckIndividual
        '
        Me.UiCheckIndividual.EditValue = True
        Me.UiCheckIndividual.Location = New System.Drawing.Point(125, 29)
        Me.UiCheckIndividual.MenuManager = Me.UiBarraPrincipal
        Me.UiCheckIndividual.Name = "UiCheckIndividual"
        Me.UiCheckIndividual.Properties.Caption = ""
        Me.UiCheckIndividual.Size = New System.Drawing.Size(22, 19)
        Me.UiCheckIndividual.TabIndex = 1
        '
        'LabelControl8
        '
        Me.LabelControl8.Location = New System.Drawing.Point(11, 108)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(108, 13)
        Me.LabelControl8.TabIndex = 10
        Me.LabelControl8.Text = "Fecha de Vencimiento:"
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(12, 231)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(39, 13)
        Me.LabelControl7.TabIndex = 9
        Me.LabelControl7.Text = "Endoso:"
        Me.LabelControl7.Visible = False
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(11, 134)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(80, 13)
        Me.LabelControl3.TabIndex = 7
        Me.LabelControl3.Text = "Nota del Detalle:"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(11, 82)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(86, 13)
        Me.LabelControl2.TabIndex = 6
        Me.LabelControl2.Text = "Fecha de Emisión:"
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(12, 10)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(111, 13)
        Me.LabelControl6.TabIndex = 5
        Me.LabelControl6.Text = "Numero de Certificado:"
        '
        'UiEtiquetaCertificadoId
        '
        Me.UiEtiquetaCertificadoId.AutoSize = True
        Me.UiEtiquetaCertificadoId.Location = New System.Drawing.Point(129, 10)
        Me.UiEtiquetaCertificadoId.Name = "UiEtiquetaCertificadoId"
        Me.UiEtiquetaCertificadoId.Size = New System.Drawing.Size(39, 13)
        Me.UiEtiquetaCertificadoId.TabIndex = 4
        Me.UiEtiquetaCertificadoId.Text = "Label1"
        '
        'UiBotonGenerarReporte
        '
        Me.UiBotonGenerarReporte.Image = CType(resources.GetObject("UiBotonGenerarReporte.Image"), System.Drawing.Image)
        Me.UiBotonGenerarReporte.Location = New System.Drawing.Point(104, 235)
        Me.UiBotonGenerarReporte.Name = "UiBotonGenerarReporte"
        Me.UiBotonGenerarReporte.Size = New System.Drawing.Size(112, 23)
        Me.UiBotonGenerarReporte.TabIndex = 10
        Me.UiBotonGenerarReporte.Text = "Generar Reporte"
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(147, 32)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(106, 13)
        Me.LabelControl5.TabIndex = 1
        Me.LabelControl5.Text = "Designación Generica:"
        '
        'UiBotonCancelarReporte
        '
        Me.UiBotonCancelarReporte.Image = CType(resources.GetObject("UiBotonCancelarReporte.Image"), System.Drawing.Image)
        Me.UiBotonCancelarReporte.Location = New System.Drawing.Point(222, 235)
        Me.UiBotonCancelarReporte.Name = "UiBotonCancelarReporte"
        Me.UiBotonCancelarReporte.Size = New System.Drawing.Size(75, 23)
        Me.UiBotonCancelarReporte.TabIndex = 11
        Me.UiBotonCancelarReporte.Text = "Cencelar"
        '
        'UiFechaValidoFinal
        '
        Me.UiFechaValidoFinal.EditValue = Nothing
        Me.UiFechaValidoFinal.Location = New System.Drawing.Point(223, 84)
        Me.UiFechaValidoFinal.MenuManager = Me.UiBarraPrincipal
        Me.UiFechaValidoFinal.Name = "UiFechaValidoFinal"
        Me.UiFechaValidoFinal.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.UiFechaValidoFinal.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.UiFechaValidoFinal.Properties.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.UiFechaValidoFinal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.UiFechaValidoFinal.Properties.EditFormat.FormatString = "dd/MM/yyyy"
        Me.UiFechaValidoFinal.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.UiFechaValidoFinal.Size = New System.Drawing.Size(100, 20)
        Me.UiFechaValidoFinal.TabIndex = 34
        '
        'UiFechaValidoInicio
        '
        Me.UiFechaValidoInicio.EditValue = Nothing
        Me.UiFechaValidoInicio.Location = New System.Drawing.Point(105, 84)
        Me.UiFechaValidoInicio.MenuManager = Me.UiBarraPrincipal
        Me.UiFechaValidoInicio.Name = "UiFechaValidoInicio"
        Me.UiFechaValidoInicio.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.UiFechaValidoInicio.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.UiFechaValidoInicio.Properties.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.UiFechaValidoInicio.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.UiFechaValidoInicio.Properties.EditFormat.FormatString = "dd/MM/yyyy"
        Me.UiFechaValidoInicio.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.UiFechaValidoInicio.Size = New System.Drawing.Size(100, 20)
        Me.UiFechaValidoInicio.TabIndex = 33
        '
        'UiEtiquetaFechaValidoA
        '
        Me.UiEtiquetaFechaValidoA.Location = New System.Drawing.Point(211, 87)
        Me.UiEtiquetaFechaValidoA.Name = "UiEtiquetaFechaValidoA"
        Me.UiEtiquetaFechaValidoA.Size = New System.Drawing.Size(6, 13)
        Me.UiEtiquetaFechaValidoA.TabIndex = 28
        Me.UiEtiquetaFechaValidoA.Text = "a"
        '
        'UiEtiquetaFechaValidoDe
        '
        Me.UiEtiquetaFechaValidoDe.Location = New System.Drawing.Point(10, 87)
        Me.UiEtiquetaFechaValidoDe.Name = "UiEtiquetaFechaValidoDe"
        Me.UiEtiquetaFechaValidoDe.Size = New System.Drawing.Size(79, 13)
        Me.UiEtiquetaFechaValidoDe.TabIndex = 25
        Me.UiEtiquetaFechaValidoDe.Text = "Fecha Valido de:"
        '
        'UiVistaCertificadoDetalle
        '
        Me.UiVistaCertificadoDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UiVistaCertificadoDetalle.Cursor = System.Windows.Forms.Cursors.Default
        Me.UiVistaCertificadoDetalle.Location = New System.Drawing.Point(0, 110)
        Me.UiVistaCertificadoDetalle.MainView = Me.GridView4
        Me.UiVistaCertificadoDetalle.Name = "UiVistaCertificadoDetalle"
        Me.UiVistaCertificadoDetalle.Size = New System.Drawing.Size(810, 581)
        Me.UiVistaCertificadoDetalle.TabIndex = 20
        Me.UiVistaCertificadoDetalle.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView4})
        '
        'GridView4
        '
        Me.GridView4.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colDOC_ID, Me.colMATERIAL_CODE, Me.colSKU_DESCRIPTION, Me.colLOCATIONS, Me.colBULTOS, Me.colQTY, Me.colCUSTOMS_AMOUNT})
        StyleFormatCondition5.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        StyleFormatCondition5.Appearance.Options.UseBackColor = True
        StyleFormatCondition5.ApplyToRow = True
        StyleFormatCondition5.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression
        StyleFormatCondition5.Expression = "[STATUS] ==  'DISPONIBLE'"
        StyleFormatCondition6.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        StyleFormatCondition6.Appearance.Options.UseBackColor = True
        StyleFormatCondition6.ApplyToRow = True
        StyleFormatCondition6.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression
        StyleFormatCondition6.Expression = "[STATUS] == 'ASOCIADO'"
        Me.GridView4.FormatConditions.AddRange(New DevExpress.XtraGrid.StyleFormatCondition() {StyleFormatCondition5, StyleFormatCondition6})
        Me.GridView4.GridControl = Me.UiVistaCertificadoDetalle
        Me.GridView4.Name = "GridView4"
        Me.GridView4.OptionsSelection.MultiSelect = True
        Me.GridView4.OptionsView.ShowFooter = True
        '
        'colDOC_ID
        '
        Me.colDOC_ID.Caption = "Numero de Documento"
        Me.colDOC_ID.FieldName = "DOC_ID"
        Me.colDOC_ID.Name = "colDOC_ID"
        Me.colDOC_ID.OptionsColumn.AllowEdit = False
        Me.colDOC_ID.OptionsColumn.AllowFocus = False
        Me.colDOC_ID.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "DOC_ID", "Cantidad: {0}")})
        Me.colDOC_ID.Visible = True
        Me.colDOC_ID.VisibleIndex = 0
        '
        'colMATERIAL_CODE
        '
        Me.colMATERIAL_CODE.Caption = "Código Material"
        Me.colMATERIAL_CODE.FieldName = "MATERIAL_CODE"
        Me.colMATERIAL_CODE.Name = "colMATERIAL_CODE"
        Me.colMATERIAL_CODE.OptionsColumn.AllowEdit = False
        Me.colMATERIAL_CODE.OptionsColumn.AllowFocus = False
        Me.colMATERIAL_CODE.Visible = True
        Me.colMATERIAL_CODE.VisibleIndex = 1
        '
        'colSKU_DESCRIPTION
        '
        Me.colSKU_DESCRIPTION.Caption = "Descripción Material"
        Me.colSKU_DESCRIPTION.FieldName = "SKU_DESCRIPTION"
        Me.colSKU_DESCRIPTION.Name = "colSKU_DESCRIPTION"
        Me.colSKU_DESCRIPTION.OptionsColumn.AllowEdit = False
        Me.colSKU_DESCRIPTION.Visible = True
        Me.colSKU_DESCRIPTION.VisibleIndex = 3
        '
        'colLOCATIONS
        '
        Me.colLOCATIONS.Caption = "Ubicaciones"
        Me.colLOCATIONS.FieldName = "LOCATIONS"
        Me.colLOCATIONS.Name = "colLOCATIONS"
        Me.colLOCATIONS.OptionsColumn.AllowEdit = False
        Me.colLOCATIONS.OptionsColumn.AllowFocus = False
        Me.colLOCATIONS.Visible = True
        Me.colLOCATIONS.VisibleIndex = 2
        '
        'colBULTOS
        '
        Me.colBULTOS.Caption = "Bultos"
        Me.colBULTOS.FieldName = "BULTOS"
        Me.colBULTOS.Name = "colBULTOS"
        Me.colBULTOS.OptionsColumn.AllowEdit = False
        Me.colBULTOS.Visible = True
        Me.colBULTOS.VisibleIndex = 4
        '
        'colQTY
        '
        Me.colQTY.Caption = "Cantidad"
        Me.colQTY.FieldName = "QTY"
        Me.colQTY.Name = "colQTY"
        Me.colQTY.OptionsColumn.AllowEdit = False
        Me.colQTY.Visible = True
        Me.colQTY.VisibleIndex = 5
        '
        'colCUSTOMS_AMOUNT
        '
        Me.colCUSTOMS_AMOUNT.Caption = "Monto"
        Me.colCUSTOMS_AMOUNT.FieldName = "CUSTOMS_AMOUNT"
        Me.colCUSTOMS_AMOUNT.Name = "colCUSTOMS_AMOUNT"
        Me.colCUSTOMS_AMOUNT.OptionsColumn.AllowEdit = False
        Me.colCUSTOMS_AMOUNT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CUSTOMS_AMOUNT", "Total: {0}")})
        Me.colCUSTOMS_AMOUNT.Visible = True
        Me.colCUSTOMS_AMOUNT.VisibleIndex = 6
        '
        'UIListaRecepcionDetalle
        '
        Me.UIListaRecepcionDetalle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UIListaRecepcionDetalle.Location = New System.Drawing.Point(105, 58)
        Me.UIListaRecepcionDetalle.Name = "UIListaRecepcionDetalle"
        Me.UIListaRecepcionDetalle.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.UIListaRecepcionDetalle.Properties.DisplayMember = "SKU_DESCRIPTION"
        Me.UIListaRecepcionDetalle.Properties.NullText = ""
        Me.UIListaRecepcionDetalle.Properties.PopupFormMinSize = New System.Drawing.Size(700, 0)
        Me.UIListaRecepcionDetalle.Properties.ValueMember = "MATERIAL_CODE"
        Me.UIListaRecepcionDetalle.Properties.View = Me.GridView3
        Me.UIListaRecepcionDetalle.Size = New System.Drawing.Size(557, 20)
        Me.UIListaRecepcionDetalle.TabIndex = 19
        '
        'GridView3
        '
        Me.GridView3.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colListaMATERIAL_CODE, Me.colListaSKU_DESCRIPTION, Me.colListaLOCATIONS, Me.colListaBULTOS, Me.colListaQTY, Me.colListaCUSTOMS_AMOUNT, Me.colListaDOC_ID, Me.colListaSTATUS})
        Me.GridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        StyleFormatCondition7.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        StyleFormatCondition7.Appearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        StyleFormatCondition7.Appearance.Options.UseBackColor = True
        StyleFormatCondition7.Appearance.Options.UseBorderColor = True
        StyleFormatCondition7.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression
        StyleFormatCondition7.Expression = "[STATUS] == 'DISPONIBLE'"
        StyleFormatCondition8.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        StyleFormatCondition8.Appearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        StyleFormatCondition8.Appearance.Options.UseBackColor = True
        StyleFormatCondition8.Appearance.Options.UseBorderColor = True
        StyleFormatCondition8.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression
        StyleFormatCondition8.Expression = "[STATUS] == 'ASOCIADO'"
        Me.GridView3.FormatConditions.AddRange(New DevExpress.XtraGrid.StyleFormatCondition() {StyleFormatCondition7, StyleFormatCondition8})
        Me.GridView3.Name = "GridView3"
        Me.GridView3.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView3.OptionsSelection.MultiSelect = True
        Me.GridView3.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
        Me.GridView3.OptionsView.ShowAutoFilterRow = True
        Me.GridView3.OptionsView.ShowGroupPanel = False
        '
        'colListaMATERIAL_CODE
        '
        Me.colListaMATERIAL_CODE.Caption = "Codigó Material"
        Me.colListaMATERIAL_CODE.FieldName = "MATERIAL_CODE"
        Me.colListaMATERIAL_CODE.Name = "colListaMATERIAL_CODE"
        Me.colListaMATERIAL_CODE.Visible = True
        Me.colListaMATERIAL_CODE.VisibleIndex = 1
        '
        'colListaSKU_DESCRIPTION
        '
        Me.colListaSKU_DESCRIPTION.Caption = "Descripción Material"
        Me.colListaSKU_DESCRIPTION.FieldName = "SKU_DESCRIPTION"
        Me.colListaSKU_DESCRIPTION.Name = "colListaSKU_DESCRIPTION"
        Me.colListaSKU_DESCRIPTION.Visible = True
        Me.colListaSKU_DESCRIPTION.VisibleIndex = 2
        '
        'colListaLOCATIONS
        '
        Me.colListaLOCATIONS.Caption = "Ubicaciones"
        Me.colListaLOCATIONS.FieldName = "LOCATIONS"
        Me.colListaLOCATIONS.Name = "colListaLOCATIONS"
        Me.colListaLOCATIONS.Visible = True
        Me.colListaLOCATIONS.VisibleIndex = 3
        '
        'colListaBULTOS
        '
        Me.colListaBULTOS.Caption = "Bultos"
        Me.colListaBULTOS.FieldName = "BULTOS"
        Me.colListaBULTOS.Name = "colListaBULTOS"
        Me.colListaBULTOS.Visible = True
        Me.colListaBULTOS.VisibleIndex = 4
        '
        'colListaQTY
        '
        Me.colListaQTY.Caption = "Cantidad"
        Me.colListaQTY.FieldName = "QTY"
        Me.colListaQTY.Name = "colListaQTY"
        Me.colListaQTY.Visible = True
        Me.colListaQTY.VisibleIndex = 5
        '
        'colListaCUSTOMS_AMOUNT
        '
        Me.colListaCUSTOMS_AMOUNT.Caption = "Monto"
        Me.colListaCUSTOMS_AMOUNT.FieldName = "CUSTOMS_AMOUNT"
        Me.colListaCUSTOMS_AMOUNT.Name = "colListaCUSTOMS_AMOUNT"
        Me.colListaCUSTOMS_AMOUNT.Visible = True
        Me.colListaCUSTOMS_AMOUNT.VisibleIndex = 6
        '
        'colListaDOC_ID
        '
        Me.colListaDOC_ID.Caption = "DOC_ID"
        Me.colListaDOC_ID.FieldName = "DOC_ID"
        Me.colListaDOC_ID.Name = "colListaDOC_ID"
        Me.colListaDOC_ID.OptionsColumn.AllowEdit = False
        '
        'colListaSTATUS
        '
        Me.colListaSTATUS.Caption = "Estado"
        Me.colListaSTATUS.FieldName = "STATUS"
        Me.colListaSTATUS.Name = "colListaSTATUS"
        Me.colListaSTATUS.Visible = True
        Me.colListaSTATUS.VisibleIndex = 7
        '
        'UiEtiquetaRecepcion
        '
        Me.UiEtiquetaRecepcion.Location = New System.Drawing.Point(10, 35)
        Me.UiEtiquetaRecepcion.Name = "UiEtiquetaRecepcion"
        Me.UiEtiquetaRecepcion.Size = New System.Drawing.Size(53, 13)
        Me.UiEtiquetaRecepcion.TabIndex = 16
        Me.UiEtiquetaRecepcion.Text = "Recepción:"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(10, 61)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(89, 13)
        Me.LabelControl1.TabIndex = 18
        Me.LabelControl1.Text = "Recepción Detalle:"
        '
        'UiListaRecepcion
        '
        Me.UiListaRecepcion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UiListaRecepcion.EditValue = ""
        Me.UiListaRecepcion.Location = New System.Drawing.Point(105, 32)
        Me.UiListaRecepcion.Name = "UiListaRecepcion"
        Me.UiListaRecepcion.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.UiListaRecepcion.Properties.NullText = ""
        Me.UiListaRecepcion.Properties.PopupFormMinSize = New System.Drawing.Size(700, 0)
        Me.UiListaRecepcion.Properties.View = Me.GridView1
        Me.UiListaRecepcion.Size = New System.Drawing.Size(557, 20)
        Me.UiListaRecepcion.TabIndex = 17
        '
        'GridView1
        '
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'UiListaCliente
        '
        Me.UiListaCliente.Location = New System.Drawing.Point(55, 9)
        Me.UiListaCliente.Name = "UiListaCliente"
        Me.UiListaCliente.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.UiListaCliente.Properties.NullText = ""
        Me.UiListaCliente.Properties.PopupFormMinSize = New System.Drawing.Size(700, 0)
        Me.UiListaCliente.Properties.View = Me.GridView2
        Me.UiListaCliente.Size = New System.Drawing.Size(489, 20)
        Me.UiListaCliente.TabIndex = 5
        '
        'GridView2
        '
        Me.GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView2.OptionsView.ShowAutoFilterRow = True
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'barHeader
        '
        Me.barHeader.BarName = "Herramientas"
        Me.barHeader.DockCol = 0
        Me.barHeader.DockRow = 0
        Me.barHeader.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.barHeader.OptionsBar.AllowQuickCustomization = False
        Me.barHeader.OptionsBar.DrawDragBorder = False
        Me.barHeader.OptionsBar.UseWholeRow = True
        Me.barHeader.Text = "Herramientas"
        '
        'Bar3
        '
        Me.Bar3.BarName = "Herramientas"
        Me.Bar3.DockCol = 0
        Me.Bar3.DockRow = 0
        Me.Bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar3.OptionsBar.AllowQuickCustomization = False
        Me.Bar3.OptionsBar.DrawDragBorder = False
        Me.Bar3.OptionsBar.UseWholeRow = True
        Me.Bar3.Text = "Herramientas"
        '
        'Bar4
        '
        Me.Bar4.BarName = "Herramientas"
        Me.Bar4.DockCol = 0
        Me.Bar4.DockRow = 0
        Me.Bar4.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar4.OptionsBar.AllowQuickCustomization = False
        Me.Bar4.OptionsBar.DrawDragBorder = False
        Me.Bar4.OptionsBar.UseWholeRow = True
        Me.Bar4.Text = "Herramientas"
        '
        'Bar5
        '
        Me.Bar5.BarName = "Herramientas"
        Me.Bar5.DockCol = 0
        Me.Bar5.DockRow = 0
        Me.Bar5.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar5.OptionsBar.AllowQuickCustomization = False
        Me.Bar5.OptionsBar.DrawDragBorder = False
        Me.Bar5.OptionsBar.UseWholeRow = True
        Me.Bar5.Text = "Herramientas"
        '
        'Bar6
        '
        Me.Bar6.BarName = "Herramientas"
        Me.Bar6.DockCol = 0
        Me.Bar6.DockRow = 0
        Me.Bar6.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar6.OptionsBar.AllowQuickCustomization = False
        Me.Bar6.OptionsBar.DrawDragBorder = False
        Me.Bar6.OptionsBar.UseWholeRow = True
        Me.Bar6.Text = "Herramientas"
        '
        'UiBarraCertificados
        '
        Me.UiBarraCertificados.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Bar8})
        Me.UiBarraCertificados.DockControls.Add(Me.BarDockControl1)
        Me.UiBarraCertificados.DockControls.Add(Me.BarDockControl2)
        Me.UiBarraCertificados.DockControls.Add(Me.BarDockControl3)
        Me.UiBarraCertificados.DockControls.Add(Me.BarDockControl4)
        Me.UiBarraCertificados.Form = Me.UiSplitPrincipal.Panel1
        Me.UiBarraCertificados.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.UiFechaInicioCertificados, Me.BarEditItem2, Me.UiBotonRefreshCertificado, Me.UiFechaInicioCertificados1, Me.UiFechaFinalCertificados, Me.UiListaEstados, Me.UiBotonCambiarEstado})
        Me.UiBarraCertificados.MaxItemId = 10
        Me.UiBarraCertificados.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCalcEdit1, Me.RepositoryItemTextEdit1, Me.RepositoryItemCalcEdit2, Me.RepositoryItemDateEdit1, Me.RepositoryItemDateEdit2, Me.RepositoryItemLookUpEdit1, Me.RepositoryItemComboBox1})
        '
        'Bar8
        '
        Me.Bar8.BarName = "Tools"
        Me.Bar8.DockCol = 0
        Me.Bar8.DockRow = 0
        Me.Bar8.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar8.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.UiFechaInicioCertificados1, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.UiFechaFinalCertificados, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.UiBotonRefreshCertificado, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.UiListaEstados, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(Me.UiBotonCambiarEstado)})
        Me.Bar8.OptionsBar.AllowQuickCustomization = False
        Me.Bar8.OptionsBar.DrawDragBorder = False
        Me.Bar8.OptionsBar.UseWholeRow = True
        Me.Bar8.Text = "Tools"
        '
        'UiFechaInicioCertificados1
        '
        Me.UiFechaInicioCertificados1.Caption = "Fecha Inicio"
        Me.UiFechaInicioCertificados1.Edit = Me.RepositoryItemDateEdit1
        Me.UiFechaInicioCertificados1.Glyph = CType(resources.GetObject("UiFechaInicioCertificados1.Glyph"), System.Drawing.Image)
        Me.UiFechaInicioCertificados1.Id = 4
        Me.UiFechaInicioCertificados1.LargeGlyph = CType(resources.GetObject("UiFechaInicioCertificados1.LargeGlyph"), System.Drawing.Image)
        Me.UiFechaInicioCertificados1.Name = "UiFechaInicioCertificados1"
        Me.UiFechaInicioCertificados1.Width = 100
        '
        'RepositoryItemDateEdit1
        '
        Me.RepositoryItemDateEdit1.AutoHeight = False
        Me.RepositoryItemDateEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemDateEdit1.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.RepositoryItemDateEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.RepositoryItemDateEdit1.EditFormat.FormatString = "dd/MM/yyyy"
        Me.RepositoryItemDateEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.RepositoryItemDateEdit1.Name = "RepositoryItemDateEdit1"
        '
        'UiFechaFinalCertificados
        '
        Me.UiFechaFinalCertificados.Caption = "Fecha Final"
        Me.UiFechaFinalCertificados.Edit = Me.RepositoryItemDateEdit2
        Me.UiFechaFinalCertificados.Glyph = CType(resources.GetObject("UiFechaFinalCertificados.Glyph"), System.Drawing.Image)
        Me.UiFechaFinalCertificados.Id = 6
        Me.UiFechaFinalCertificados.LargeGlyph = CType(resources.GetObject("UiFechaFinalCertificados.LargeGlyph"), System.Drawing.Image)
        Me.UiFechaFinalCertificados.Name = "UiFechaFinalCertificados"
        Me.UiFechaFinalCertificados.Width = 100
        '
        'RepositoryItemDateEdit2
        '
        Me.RepositoryItemDateEdit2.AutoHeight = False
        Me.RepositoryItemDateEdit2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemDateEdit2.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemDateEdit2.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.RepositoryItemDateEdit2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.RepositoryItemDateEdit2.EditFormat.FormatString = "dd/MM/yyyy"
        Me.RepositoryItemDateEdit2.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.RepositoryItemDateEdit2.Name = "RepositoryItemDateEdit2"
        '
        'UiBotonRefreshCertificado
        '
        Me.UiBotonRefreshCertificado.Caption = "Refresh"
        Me.UiBotonRefreshCertificado.Glyph = CType(resources.GetObject("UiBotonRefreshCertificado.Glyph"), System.Drawing.Image)
        Me.UiBotonRefreshCertificado.Id = 3
        Me.UiBotonRefreshCertificado.LargeGlyph = CType(resources.GetObject("UiBotonRefreshCertificado.LargeGlyph"), System.Drawing.Image)
        Me.UiBotonRefreshCertificado.Name = "UiBotonRefreshCertificado"
        '
        'UiListaEstados
        '
        Me.UiListaEstados.Caption = "Estado"
        Me.UiListaEstados.Edit = Me.RepositoryItemComboBox1
        Me.UiListaEstados.Glyph = CType(resources.GetObject("UiListaEstados.Glyph"), System.Drawing.Image)
        Me.UiListaEstados.Id = 8
        Me.UiListaEstados.LargeGlyph = CType(resources.GetObject("UiListaEstados.LargeGlyph"), System.Drawing.Image)
        Me.UiListaEstados.Name = "UiListaEstados"
        Me.UiListaEstados.Width = 75
        '
        'RepositoryItemComboBox1
        '
        Me.RepositoryItemComboBox1.AutoHeight = False
        Me.RepositoryItemComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemComboBox1.Items.AddRange(New Object() {"ACTIVO", "INACTIVO", "ANULAR"})
        Me.RepositoryItemComboBox1.Name = "RepositoryItemComboBox1"
        Me.RepositoryItemComboBox1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'UiBotonCambiarEstado
        '
        Me.UiBotonCambiarEstado.Caption = "Grabar Estado"
        Me.UiBotonCambiarEstado.Glyph = CType(resources.GetObject("UiBotonCambiarEstado.Glyph"), System.Drawing.Image)
        Me.UiBotonCambiarEstado.Id = 9
        Me.UiBotonCambiarEstado.LargeGlyph = CType(resources.GetObject("UiBotonCambiarEstado.LargeGlyph"), System.Drawing.Image)
        Me.UiBotonCambiarEstado.Name = "UiBotonCambiarEstado"
        '
        'UiFechaInicioCertificados
        '
        Me.UiFechaInicioCertificados.Caption = "Fecha Inicio"
        Me.UiFechaInicioCertificados.Edit = Me.RepositoryItemCalcEdit1
        Me.UiFechaInicioCertificados.Glyph = CType(resources.GetObject("UiFechaInicioCertificados.Glyph"), System.Drawing.Image)
        Me.UiFechaInicioCertificados.Id = 0
        Me.UiFechaInicioCertificados.LargeGlyph = CType(resources.GetObject("UiFechaInicioCertificados.LargeGlyph"), System.Drawing.Image)
        Me.UiFechaInicioCertificados.Name = "UiFechaInicioCertificados"
        Me.UiFechaInicioCertificados.Width = 95
        '
        'RepositoryItemCalcEdit1
        '
        Me.RepositoryItemCalcEdit1.AutoHeight = False
        Me.RepositoryItemCalcEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemCalcEdit1.Name = "RepositoryItemCalcEdit1"
        '
        'BarEditItem2
        '
        Me.BarEditItem2.Caption = "BarEditItem2"
        Me.BarEditItem2.Edit = Me.RepositoryItemTextEdit1
        Me.BarEditItem2.Id = 1
        Me.BarEditItem2.Name = "BarEditItem2"
        '
        'RepositoryItemTextEdit1
        '
        Me.RepositoryItemTextEdit1.AutoHeight = False
        Me.RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
        '
        'RepositoryItemCalcEdit2
        '
        Me.RepositoryItemCalcEdit2.AutoHeight = False
        Me.RepositoryItemCalcEdit2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemCalcEdit2.Name = "RepositoryItemCalcEdit2"
        '
        'RepositoryItemLookUpEdit1
        '
        Me.RepositoryItemLookUpEdit1.AutoHeight = False
        Me.RepositoryItemLookUpEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemLookUpEdit1.Name = "RepositoryItemLookUpEdit1"
        '
        'FrmCertificateDeposit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1474, 729)
        Me.Controls.Add(Me.UiPanelContenido)
        Me.Name = "FrmCertificateDeposit"
        Me.Text = "Certificado de Deposito"
        CType(Me.UiPanelContenido, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiPanelContenido.ResumeLayout(False)
        Me.UiPanelContenido.PerformLayout()
        CType(Me.UiSplitPrincipal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiSplitPrincipal.ResumeLayout(False)
        CType(Me.UiPopupEstado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiPopupEstado.ResumeLayout(False)
        Me.UiPopupEstado.PerformLayout()
        CType(Me.UiMemoComentarioEstado.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiBarraPrincipal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiVistaCertificadoEncabezado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridView5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiPopupReporte, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiPopupReporte.ResumeLayout(False)
        Me.UiPopupReporte.PerformLayout()
        CType(Me.UiTextoEndoso.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiCheckInGenerico.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiListaAlmacenaje.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit3.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit4.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCalcEdit3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCalcEdit4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiCheckSujetoAPagos.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiSpinSerie.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiEtiquetaFechaVencimiento.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiEtiquetaFechaVencimiento.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiSpinImpuesto.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiTextoNota.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiFechaEmision.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiFechaEmision.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiCheckIndividual.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiFechaValidoFinal.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiFechaValidoFinal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiFechaValidoInicio.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiFechaValidoInicio.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiVistaCertificadoDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UIListaRecepcionDetalle.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiListaRecepcion.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiListaCliente.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiBarraCertificados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit2.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCalcEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCalcEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLookUpEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar1 As DevExpress.XtraBars.Bar
    Friend WithEvents Bar2 As DevExpress.XtraBars.Bar
    Friend WithEvents UiPanelContenido As DevExpress.XtraEditors.PanelControl
    Friend WithEvents UiSplitPrincipal As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents UiListaCliente As DevExpress.XtraEditors.GridLookUpEdit
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents UiVistaCertificadoEncabezado As DevExpress.XtraGrid.GridControl
    Friend WithEvents gridView5 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colCERTIFICATE_DEPOSIT_ID_HEADER As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colVALID_FROM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colVALID_TO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSTATUS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCLIENT_CODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UiListaRecepcion As DevExpress.XtraEditors.GridLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents UiEtiquetaRecepcion As DevExpress.XtraEditors.LabelControl
    Friend WithEvents UiEtiquetaCliente As DevExpress.XtraEditors.LabelControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barHeader As DevExpress.XtraBars.Bar
    Friend WithEvents Bar3 As DevExpress.XtraBars.Bar
    Friend WithEvents Bar4 As DevExpress.XtraBars.Bar
    Friend WithEvents Bar5 As DevExpress.XtraBars.Bar
    Friend WithEvents Bar6 As DevExpress.XtraBars.Bar
    Friend WithEvents UiBarraPrincipal As DevExpress.XtraBars.BarManager
    Friend WithEvents UIListaRecepcionDetalle As DevExpress.XtraEditors.GridLookUpEdit
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem2 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents UiBarraCertificados As DevExpress.XtraBars.BarManager
    Friend WithEvents Bar8 As DevExpress.XtraBars.Bar
    Friend WithEvents BarDockControl1 As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarDockControl2 As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarDockControl3 As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarDockControl4 As DevExpress.XtraBars.BarDockControl
    Friend WithEvents UiFechaInicioCertificados As DevExpress.XtraBars.BarEditItem
    Friend WithEvents RepositoryItemCalcEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit
    Friend WithEvents RepositoryItemCalcEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit
    Friend WithEvents UiBotonRefreshCertificado As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarEditItem2 As DevExpress.XtraBars.BarEditItem
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents UiVistaCertificadoDetalle As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView4 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colDOC_ID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMATERIAL_CODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSKU_DESCRIPTION As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colLOCATIONS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BarDockControl7 As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarDockControl8 As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarDockControl6 As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarDockControl5 As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents Bar9 As DevExpress.XtraBars.Bar
    Friend WithEvents UiBotonNuevoCertificado As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents UiBotonGrabarCertificado As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RepositoryItemCalcEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit
    Friend WithEvents RepositoryItemCalcEdit4 As DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit
    Friend WithEvents UiBotonRefreshRecepcion As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents UiEtiquetaFechaValidoA As DevExpress.XtraEditors.LabelControl
    Friend WithEvents UiEtiquetaFechaValidoDe As DevExpress.XtraEditors.LabelControl
    Friend WithEvents UiFechaInicioCertificados1 As DevExpress.XtraBars.BarEditItem
    Friend WithEvents RepositoryItemDateEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents UiFechaFinalCertificados As DevExpress.XtraBars.BarEditItem
    Friend WithEvents RepositoryItemDateEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents UiFechaInicioRecepcion As DevExpress.XtraBars.BarEditItem
    Friend WithEvents RepositoryItemDateEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents UiFechaFinalRecepcion As DevExpress.XtraBars.BarEditItem
    Friend WithEvents RepositoryItemDateEdit4 As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents colListaMATERIAL_CODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colListaSKU_DESCRIPTION As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colListaLOCATIONS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colListaBULTOS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colListaQTY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colListaCUSTOMS_AMOUNT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UiFechaValidoFinal As DevExpress.XtraEditors.DateEdit
    Friend WithEvents UiFechaValidoInicio As DevExpress.XtraEditors.DateEdit
    Friend WithEvents UiBotonAgregarCertificado As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents colBULTOS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colQTY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCUSTOMS_AMOUNT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colListaDOC_ID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UiBotonBorrarDetCet As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents colListaSTATUS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UiListaEstados As DevExpress.XtraBars.BarEditItem
    Friend WithEvents RepositoryItemComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents RepositoryItemLookUpEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents UiBotonCambiarEstado As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents UiPopupReporte As DevExpress.XtraBars.PopupControlContainer
    Friend WithEvents UiEtiquetaFechaVencimiento As DevExpress.XtraEditors.DateEdit
    Friend WithEvents UiEtiquetaEndoso As System.Windows.Forms.Label
    Friend WithEvents UiSpinImpuesto As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents UiTextoNota As DevExpress.XtraEditors.TextEdit
    Friend WithEvents UiFechaEmision As DevExpress.XtraEditors.DateEdit
    Friend WithEvents UiCheckIndividual As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents UiEtiquetaCertificadoId As System.Windows.Forms.Label
    Friend WithEvents UiBotonGenerarReporte As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents UiBotonCancelarReporte As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents UiBotonImprimir As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents UiSpinSerie As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl11 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents UiCheckSujetoAPagos As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LabelControl10 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl12 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents UiListaAlmacenaje As DevExpress.XtraEditors.GridLookUpEdit
    Friend WithEvents GridView6 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents UiCheckInGenerico As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LabelControl13 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents UiTextoEndoso As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents UiPopupEstado As DevExpress.XtraBars.PopupControlContainer
    Friend WithEvents UiEtiquetaComentarioTitulo As DevExpress.XtraEditors.LabelControl
    Friend WithEvents UiMemoComentarioEstado As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents colPICKING As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSERIAL_NUMBER As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTRANS_DATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LOGIN_ID As DevExpress.XtraGrid.Columns.GridColumn
End Class
