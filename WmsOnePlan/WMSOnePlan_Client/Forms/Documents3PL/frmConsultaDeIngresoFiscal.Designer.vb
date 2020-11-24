<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmConsultaDeIngresoFiscal
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsultaDeIngresoFiscal))
        Dim StyleFormatCondition1 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Dim StyleFormatCondition2 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Dim StyleFormatCondition3 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Dim StyleFormatCondition4 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Me.barManagerHeader = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar2 = New DevExpress.XtraBars.Bar()
        Me.UiBotonExpandirVista = New DevExpress.XtraBars.BarButtonItem()
        Me.UiBotonContraerVista = New DevExpress.XtraBars.BarButtonItem()
        Me.btnSaveLayout = New DevExpress.XtraBars.BarButtonItem()
        Me.UiBotonExportarExcelVista = New DevExpress.XtraBars.BarButtonItem()
        Me.UiBotonImprimir = New DevExpress.XtraBars.BarButtonItem()
        Me.UIFechaInicio = New DevExpress.XtraBars.BarEditItem()
        Me.RepositoryItemDateEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.UiFechaFinal = New DevExpress.XtraBars.BarEditItem()
        Me.RepositoryItemDateEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.UiBotonRefrescarVista = New DevExpress.XtraBars.BarButtonItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.BarEditItem5 = New DevExpress.XtraBars.BarEditItem()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.BarEditItem6 = New DevExpress.XtraBars.BarEditItem()
        Me.RepositoryItemTextEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.BarEditItem1 = New DevExpress.XtraBars.BarEditItem()
        Me.BarEditItem2 = New DevExpress.XtraBars.BarEditItem()
        Me.RepositoryItemDateEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.BarEditItem7 = New DevExpress.XtraBars.BarEditItem()
        Me.RepositoryItemTextEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.barHeader = New DevExpress.XtraBars.Bar()
        Me.Bar1 = New DevExpress.XtraBars.Bar()
        Me.UiLabelCliente = New DevExpress.XtraEditors.LabelControl()
        Me.UiVistaGridEgresos = New DevExpress.XtraGrid.GridControl()
        Me.UiVistaIngresoGeneral = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UiColInventarioExterno = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTRANSFER_REQUEST_ID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colVEHICLE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDRIVER = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colWAREHOUSE_FROM = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colEstado = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBloqueaInventario = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colColor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTono = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCalibre = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UiColNumeroSerie = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UiColLote = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UiColFechaExpriracion = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UiColVin = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UiGridViewEgresos = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colDOC_ID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNUMERO_ORDEN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCODIGO_POLIZA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCLIENT_CODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colClientName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFECHA_DOCUMENTO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMaterialDesc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMaterial_Code = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBultos = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCantidad = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colValorUnitario = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colValorTotal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colConsignatario = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRegimen = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colGRUPO_REGIMEN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colREGIMEN_DOCUMENTO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UiColDiasRegimen = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UiColDiasParaVencer = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UiColFechaVencimiento = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UiColEstadoRegimen = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UiColNombreEstado = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UiColInventarioBloqueado = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UiColColor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UiColTono = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UiColCalibre = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UiColNumeroDeSerieFiscal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UiColLoteFiscal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UiColFechaExpiracionFiscal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UiColVinFiscal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        Me.UiEtiquetaRegimen = New DevExpress.XtraEditors.LabelControl()
        Me.UiListaRegimen = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.UiListaVistaRegimen = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.UiColRegimenAlmacen = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UiColDescripcionRegimenAlmacen = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UiListaCliente = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.UiListaVistaCliente = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.UiColCodigoCliente = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UiColNombreCliente = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UiError = New DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(Me.components)
        Me.loadLayout = New System.Windows.Forms.Timer(Me.components)
        CType(Me.barManagerHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit2.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit3.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiVistaGridEgresos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiVistaIngresoGeneral, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGridViewEgresos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiListaRegimen.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiListaVistaRegimen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiListaCliente.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiListaVistaCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiError, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'barManagerHeader
        '
        Me.barManagerHeader.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Bar2})
        Me.barManagerHeader.DockControls.Add(Me.barDockControlTop)
        Me.barManagerHeader.DockControls.Add(Me.barDockControlBottom)
        Me.barManagerHeader.DockControls.Add(Me.barDockControlLeft)
        Me.barManagerHeader.DockControls.Add(Me.barDockControlRight)
        Me.barManagerHeader.Form = Me
        Me.barManagerHeader.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.UIFechaInicio, Me.UiFechaFinal, Me.UiBotonRefrescarVista, Me.BarEditItem5, Me.BarEditItem6, Me.BarEditItem1, Me.BarEditItem2, Me.BarEditItem7, Me.UiBotonExpandirVista, Me.UiBotonContraerVista, Me.UiBotonExportarExcelVista, Me.UiBotonImprimir, Me.btnSaveLayout})
        Me.barManagerHeader.MaxItemId = 15
        Me.barManagerHeader.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemDateEdit1, Me.RepositoryItemDateEdit2, Me.RepositoryItemTextEdit1, Me.RepositoryItemTextEdit2, Me.RepositoryItemDateEdit3, Me.RepositoryItemTextEdit3})
        '
        'Bar2
        '
        Me.Bar2.BarName = "Herramientas"
        Me.Bar2.DockCol = 0
        Me.Bar2.DockRow = 0
        Me.Bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar2.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.UiBotonExpandirVista, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.UiBotonContraerVista, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(Me.btnSaveLayout), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.UiBotonExportarExcelVista, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.UiBotonImprimir, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.UIFechaInicio, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.UiFechaFinal, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.UiBotonRefrescarVista, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)})
        Me.Bar2.OptionsBar.AllowQuickCustomization = False
        Me.Bar2.OptionsBar.DrawDragBorder = False
        Me.Bar2.OptionsBar.UseWholeRow = True
        Me.Bar2.Text = "Herramientas"
        '
        'UiBotonExpandirVista
        '
        Me.UiBotonExpandirVista.Caption = "Expandir"
        Me.UiBotonExpandirVista.Id = 8
        Me.UiBotonExpandirVista.ImageOptions.Image = Global.WMSOnePlan_Client.My.Resources.Resources.linespacing_16x16
        Me.UiBotonExpandirVista.ImageOptions.LargeImage = Global.WMSOnePlan_Client.My.Resources.Resources.linespacing_32x32
        Me.UiBotonExpandirVista.Name = "UiBotonExpandirVista"
        '
        'UiBotonContraerVista
        '
        Me.UiBotonContraerVista.Caption = "Contraer"
        Me.UiBotonContraerVista.Id = 9
        Me.UiBotonContraerVista.ImageOptions.Image = Global.WMSOnePlan_Client.My.Resources.Resources.linespacing2_16x16
        Me.UiBotonContraerVista.ImageOptions.LargeImage = Global.WMSOnePlan_Client.My.Resources.Resources.linespacing2_32x32
        Me.UiBotonContraerVista.Name = "UiBotonContraerVista"
        '
        'btnSaveLayout
        '
        Me.btnSaveLayout.Caption = "Grabar"
        Me.btnSaveLayout.Id = 14
        Me.btnSaveLayout.ImageOptions.Image = CType(resources.GetObject("btnSaveLayout.ImageOptions.Image"), System.Drawing.Image)
        Me.btnSaveLayout.ImageOptions.LargeImage = CType(resources.GetObject("btnSaveLayout.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.btnSaveLayout.Name = "btnSaveLayout"
        Me.btnSaveLayout.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        '
        'UiBotonExportarExcelVista
        '
        Me.UiBotonExportarExcelVista.Caption = "Excel"
        Me.UiBotonExportarExcelVista.Id = 12
        Me.UiBotonExportarExcelVista.ImageOptions.Image = CType(resources.GetObject("UiBotonExportarExcelVista.ImageOptions.Image"), System.Drawing.Image)
        Me.UiBotonExportarExcelVista.ImageOptions.LargeImage = CType(resources.GetObject("UiBotonExportarExcelVista.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.UiBotonExportarExcelVista.Name = "UiBotonExportarExcelVista"
        '
        'UiBotonImprimir
        '
        Me.UiBotonImprimir.Caption = "Imprimir"
        Me.UiBotonImprimir.Id = 13
        Me.UiBotonImprimir.ImageOptions.Image = CType(resources.GetObject("UiBotonImprimir.ImageOptions.Image"), System.Drawing.Image)
        Me.UiBotonImprimir.ImageOptions.LargeImage = CType(resources.GetObject("UiBotonImprimir.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.UiBotonImprimir.Name = "UiBotonImprimir"
        '
        'UIFechaInicio
        '
        Me.UIFechaInicio.Caption = "Fecha Inicio"
        Me.UIFechaInicio.Edit = Me.RepositoryItemDateEdit1
        Me.UIFechaInicio.EditWidth = 100
        Me.UIFechaInicio.Id = 0
        Me.UIFechaInicio.ImageOptions.Image = CType(resources.GetObject("UIFechaInicio.ImageOptions.Image"), System.Drawing.Image)
        Me.UIFechaInicio.ImageOptions.LargeImage = CType(resources.GetObject("UIFechaInicio.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.UIFechaInicio.Name = "UIFechaInicio"
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
        'UiFechaFinal
        '
        Me.UiFechaFinal.Caption = "Fecha Final"
        Me.UiFechaFinal.Edit = Me.RepositoryItemDateEdit2
        Me.UiFechaFinal.EditWidth = 100
        Me.UiFechaFinal.Id = 1
        Me.UiFechaFinal.ImageOptions.Image = CType(resources.GetObject("UiFechaFinal.ImageOptions.Image"), System.Drawing.Image)
        Me.UiFechaFinal.ImageOptions.LargeImage = CType(resources.GetObject("UiFechaFinal.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.UiFechaFinal.Name = "UiFechaFinal"
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
        'UiBotonRefrescarVista
        '
        Me.UiBotonRefrescarVista.Caption = "Refresh"
        Me.UiBotonRefrescarVista.Id = 2
        Me.UiBotonRefrescarVista.ImageOptions.Image = CType(resources.GetObject("UiBotonRefrescarVista.ImageOptions.Image"), System.Drawing.Image)
        Me.UiBotonRefrescarVista.ImageOptions.LargeImage = CType(resources.GetObject("UiBotonRefrescarVista.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.UiBotonRefrescarVista.Name = "UiBotonRefrescarVista"
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Manager = Me.barManagerHeader
        Me.barDockControlTop.Margin = New System.Windows.Forms.Padding(6)
        Me.barDockControlTop.Size = New System.Drawing.Size(2398, 46)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 1071)
        Me.barDockControlBottom.Manager = Me.barManagerHeader
        Me.barDockControlBottom.Margin = New System.Windows.Forms.Padding(6)
        Me.barDockControlBottom.Size = New System.Drawing.Size(2398, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 46)
        Me.barDockControlLeft.Manager = Me.barManagerHeader
        Me.barDockControlLeft.Margin = New System.Windows.Forms.Padding(6)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 1025)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(2398, 46)
        Me.barDockControlRight.Manager = Me.barManagerHeader
        Me.barDockControlRight.Margin = New System.Windows.Forms.Padding(6)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 1025)
        '
        'BarEditItem5
        '
        Me.BarEditItem5.Caption = "BarEditItem5"
        Me.BarEditItem5.Edit = Me.RepositoryItemTextEdit1
        Me.BarEditItem5.Id = 3
        Me.BarEditItem5.Name = "BarEditItem5"
        '
        'RepositoryItemTextEdit1
        '
        Me.RepositoryItemTextEdit1.AutoHeight = False
        Me.RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
        '
        'BarEditItem6
        '
        Me.BarEditItem6.Caption = "BarEditItem6"
        Me.BarEditItem6.Edit = Me.RepositoryItemTextEdit2
        Me.BarEditItem6.Id = 4
        Me.BarEditItem6.Name = "BarEditItem6"
        '
        'RepositoryItemTextEdit2
        '
        Me.RepositoryItemTextEdit2.AutoHeight = False
        Me.RepositoryItemTextEdit2.Name = "RepositoryItemTextEdit2"
        '
        'BarEditItem1
        '
        Me.BarEditItem1.Caption = "BarEditItem1"
        Me.BarEditItem1.Edit = Nothing
        Me.BarEditItem1.Id = 5
        Me.BarEditItem1.Name = "BarEditItem1"
        '
        'BarEditItem2
        '
        Me.BarEditItem2.Caption = "BarEditItem2"
        Me.BarEditItem2.Edit = Me.RepositoryItemDateEdit3
        Me.BarEditItem2.Id = 6
        Me.BarEditItem2.Name = "BarEditItem2"
        '
        'RepositoryItemDateEdit3
        '
        Me.RepositoryItemDateEdit3.AutoHeight = False
        Me.RepositoryItemDateEdit3.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemDateEdit3.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemDateEdit3.Name = "RepositoryItemDateEdit3"
        '
        'BarEditItem7
        '
        Me.BarEditItem7.Caption = "BarEditItem7"
        Me.BarEditItem7.Edit = Me.RepositoryItemTextEdit3
        Me.BarEditItem7.Id = 7
        Me.BarEditItem7.Name = "BarEditItem7"
        '
        'RepositoryItemTextEdit3
        '
        Me.RepositoryItemTextEdit3.AutoHeight = False
        Me.RepositoryItemTextEdit3.Name = "RepositoryItemTextEdit3"
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
        'UiLabelCliente
        '
        Me.UiLabelCliente.Location = New System.Drawing.Point(776, 77)
        Me.UiLabelCliente.Margin = New System.Windows.Forms.Padding(6)
        Me.UiLabelCliente.Name = "UiLabelCliente"
        Me.UiLabelCliente.Size = New System.Drawing.Size(64, 25)
        Me.UiLabelCliente.TabIndex = 20
        Me.UiLabelCliente.Text = "Cliente"
        '
        'UiVistaGridEgresos
        '
        Me.UiVistaGridEgresos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UiVistaGridEgresos.Cursor = System.Windows.Forms.Cursors.Default
        Me.UiVistaGridEgresos.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(6)
        Me.UiVistaGridEgresos.Location = New System.Drawing.Point(0, 121)
        Me.UiVistaGridEgresos.MainView = Me.UiVistaIngresoGeneral
        Me.UiVistaGridEgresos.Margin = New System.Windows.Forms.Padding(6)
        Me.UiVistaGridEgresos.MenuManager = Me.barManagerHeader
        Me.UiVistaGridEgresos.Name = "UiVistaGridEgresos"
        Me.UiVistaGridEgresos.Size = New System.Drawing.Size(2398, 927)
        Me.UiVistaGridEgresos.TabIndex = 25
        Me.UiVistaGridEgresos.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.UiVistaIngresoGeneral, Me.UiGridViewEgresos})
        '
        'UiVistaIngresoGeneral
        '
        Me.UiVistaIngresoGeneral.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7, Me.GridColumn8, Me.GridColumn10, Me.GridColumn11, Me.GridColumn12, Me.UiColInventarioExterno, Me.colTRANSFER_REQUEST_ID, Me.colVEHICLE, Me.colDRIVER, Me.colWAREHOUSE_FROM, Me.colEstado, Me.colBloqueaInventario, Me.colColor, Me.colTono, Me.colCalibre, Me.UiColNumeroSerie, Me.UiColLote, Me.UiColFechaExpriracion, Me.UiColVin})
        Me.UiVistaIngresoGeneral.DetailHeight = 673
        Me.UiVistaIngresoGeneral.FixedLineWidth = 4
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
        Me.UiVistaIngresoGeneral.FormatConditions.AddRange(New DevExpress.XtraGrid.StyleFormatCondition() {StyleFormatCondition1, StyleFormatCondition2})
        Me.UiVistaIngresoGeneral.GridControl = Me.UiVistaGridEgresos
        Me.UiVistaIngresoGeneral.GroupCount = 1
        Me.UiVistaIngresoGeneral.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TOTAL", Me.GridColumn12, "(Total: SUM={0:#,###,###.00})"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "MATERIAL_ID", Me.GridColumn1, "(Cantidad registros={0})")})
        Me.UiVistaIngresoGeneral.Name = "UiVistaIngresoGeneral"
        Me.UiVistaIngresoGeneral.OptionsView.ShowAutoFilterRow = True
        Me.UiVistaIngresoGeneral.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn1, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Número Documento"
        Me.GridColumn1.FieldName = "DOC_ID"
        Me.GridColumn1.MinWidth = 40
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.AllowEdit = False
        Me.GridColumn1.OptionsColumn.AllowFocus = False
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        Me.GridColumn1.Width = 150
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Número Órden"
        Me.GridColumn2.FieldName = "ORDEN"
        Me.GridColumn2.MinWidth = 40
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.OptionsColumn.AllowEdit = False
        Me.GridColumn2.OptionsColumn.AllowFocus = False
        Me.GridColumn2.Width = 150
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Código Póliza"
        Me.GridColumn3.FieldName = "POLIZA"
        Me.GridColumn3.MinWidth = 40
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.OptionsColumn.AllowEdit = False
        Me.GridColumn3.OptionsColumn.AllowFocus = False
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 0
        Me.GridColumn3.Width = 150
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Código Cliente"
        Me.GridColumn4.FieldName = "CLIENT_CODE"
        Me.GridColumn4.MinWidth = 40
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.OptionsColumn.AllowEdit = False
        Me.GridColumn4.OptionsColumn.AllowFocus = False
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 1
        Me.GridColumn4.Width = 150
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Nombre Cliente"
        Me.GridColumn5.FieldName = "CLIENTE"
        Me.GridColumn5.MinWidth = 40
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.OptionsColumn.AllowEdit = False
        Me.GridColumn5.OptionsColumn.AllowFocus = False
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 2
        Me.GridColumn5.Width = 150
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Fecha Documento"
        Me.GridColumn6.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn6.FieldName = "FECHA"
        Me.GridColumn6.MinWidth = 40
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.OptionsColumn.AllowEdit = False
        Me.GridColumn6.OptionsColumn.AllowFocus = False
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 3
        Me.GridColumn6.Width = 150
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Descripción Material"
        Me.GridColumn7.FieldName = "DESCRIPCION"
        Me.GridColumn7.MinWidth = 40
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.OptionsColumn.AllowEdit = False
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 4
        Me.GridColumn7.Width = 150
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "Código Material"
        Me.GridColumn8.FieldName = "MATERIAL_ID"
        Me.GridColumn8.MinWidth = 40
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.OptionsColumn.AllowEdit = False
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 5
        Me.GridColumn8.Width = 150
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Cantidad"
        Me.GridColumn10.FieldName = "CANTIDAD"
        Me.GridColumn10.MinWidth = 40
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.OptionsColumn.AllowEdit = False
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 6
        Me.GridColumn10.Width = 150
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "Valor unitario"
        Me.GridColumn11.DisplayFormat.FormatString = "#,###,###.00"
        Me.GridColumn11.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn11.FieldName = "VALOR_UNITARIO"
        Me.GridColumn11.MinWidth = 40
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.OptionsColumn.AllowEdit = False
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 7
        Me.GridColumn11.Width = 150
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "Total"
        Me.GridColumn12.DisplayFormat.FormatString = "#,###,###.00"
        Me.GridColumn12.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn12.FieldName = "TOTAL"
        Me.GridColumn12.MinWidth = 40
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.OptionsColumn.AllowEdit = False
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 8
        Me.GridColumn12.Width = 150
        '
        'UiColInventarioExterno
        '
        Me.UiColInventarioExterno.Caption = "Inventario Externo"
        Me.UiColInventarioExterno.FieldName = "IS_EXTERNAL_INVENTORY"
        Me.UiColInventarioExterno.MinWidth = 40
        Me.UiColInventarioExterno.Name = "UiColInventarioExterno"
        Me.UiColInventarioExterno.OptionsColumn.AllowEdit = False
        Me.UiColInventarioExterno.Visible = True
        Me.UiColInventarioExterno.VisibleIndex = 9
        Me.UiColInventarioExterno.Width = 150
        '
        'colTRANSFER_REQUEST_ID
        '
        Me.colTRANSFER_REQUEST_ID.Caption = "Número de Solicitud de Traslado"
        Me.colTRANSFER_REQUEST_ID.FieldName = "TRANSFER_REQUEST_ID"
        Me.colTRANSFER_REQUEST_ID.MinWidth = 40
        Me.colTRANSFER_REQUEST_ID.Name = "colTRANSFER_REQUEST_ID"
        Me.colTRANSFER_REQUEST_ID.OptionsColumn.AllowEdit = False
        Me.colTRANSFER_REQUEST_ID.Visible = True
        Me.colTRANSFER_REQUEST_ID.VisibleIndex = 10
        Me.colTRANSFER_REQUEST_ID.Width = 150
        '
        'colVEHICLE
        '
        Me.colVEHICLE.Caption = "Nombre del Trasporte"
        Me.colVEHICLE.FieldName = "VEHICLE"
        Me.colVEHICLE.MinWidth = 40
        Me.colVEHICLE.Name = "colVEHICLE"
        Me.colVEHICLE.OptionsColumn.AllowEdit = False
        Me.colVEHICLE.Visible = True
        Me.colVEHICLE.VisibleIndex = 11
        Me.colVEHICLE.Width = 150
        '
        'colDRIVER
        '
        Me.colDRIVER.Caption = "Piloto"
        Me.colDRIVER.FieldName = "DRIVER"
        Me.colDRIVER.MinWidth = 40
        Me.colDRIVER.Name = "colDRIVER"
        Me.colDRIVER.OptionsColumn.AllowEdit = False
        Me.colDRIVER.Visible = True
        Me.colDRIVER.VisibleIndex = 12
        Me.colDRIVER.Width = 150
        '
        'colWAREHOUSE_FROM
        '
        Me.colWAREHOUSE_FROM.Caption = "Bodega Origen"
        Me.colWAREHOUSE_FROM.FieldName = "WAREHOUSE_FROM"
        Me.colWAREHOUSE_FROM.MinWidth = 40
        Me.colWAREHOUSE_FROM.Name = "colWAREHOUSE_FROM"
        Me.colWAREHOUSE_FROM.OptionsColumn.AllowEdit = False
        Me.colWAREHOUSE_FROM.Visible = True
        Me.colWAREHOUSE_FROM.VisibleIndex = 13
        Me.colWAREHOUSE_FROM.Width = 150
        '
        'colEstado
        '
        Me.colEstado.Caption = "Estado"
        Me.colEstado.FieldName = "STATUS_NAME"
        Me.colEstado.MinWidth = 40
        Me.colEstado.Name = "colEstado"
        Me.colEstado.OptionsColumn.AllowEdit = False
        Me.colEstado.OptionsColumn.AllowFocus = False
        Me.colEstado.Visible = True
        Me.colEstado.VisibleIndex = 14
        Me.colEstado.Width = 150
        '
        'colBloqueaInventario
        '
        Me.colBloqueaInventario.Caption = "Bloqueado"
        Me.colBloqueaInventario.FieldName = "BLOCKS_INVENTORY"
        Me.colBloqueaInventario.MinWidth = 40
        Me.colBloqueaInventario.Name = "colBloqueaInventario"
        Me.colBloqueaInventario.OptionsColumn.AllowEdit = False
        Me.colBloqueaInventario.OptionsColumn.AllowFocus = False
        Me.colBloqueaInventario.Visible = True
        Me.colBloqueaInventario.VisibleIndex = 15
        Me.colBloqueaInventario.Width = 150
        '
        'colColor
        '
        Me.colColor.Caption = "Color"
        Me.colColor.FieldName = "COLOR"
        Me.colColor.MinWidth = 40
        Me.colColor.Name = "colColor"
        Me.colColor.OptionsColumn.AllowEdit = False
        Me.colColor.OptionsColumn.AllowFocus = False
        Me.colColor.Visible = True
        Me.colColor.VisibleIndex = 16
        Me.colColor.Width = 150
        '
        'colTono
        '
        Me.colTono.Caption = "Tono"
        Me.colTono.FieldName = "TONE"
        Me.colTono.MinWidth = 40
        Me.colTono.Name = "colTono"
        Me.colTono.OptionsColumn.AllowEdit = False
        Me.colTono.OptionsColumn.ReadOnly = True
        Me.colTono.Visible = True
        Me.colTono.VisibleIndex = 17
        Me.colTono.Width = 150
        '
        'colCalibre
        '
        Me.colCalibre.Caption = "Calibre"
        Me.colCalibre.FieldName = "CALIBER"
        Me.colCalibre.MinWidth = 40
        Me.colCalibre.Name = "colCalibre"
        Me.colCalibre.OptionsColumn.AllowEdit = False
        Me.colCalibre.OptionsColumn.ReadOnly = True
        Me.colCalibre.Visible = True
        Me.colCalibre.VisibleIndex = 18
        Me.colCalibre.Width = 150
        '
        'UiColNumeroSerie
        '
        Me.UiColNumeroSerie.Caption = "Número de Serie"
        Me.UiColNumeroSerie.FieldName = "SERIAL"
        Me.UiColNumeroSerie.MinWidth = 40
        Me.UiColNumeroSerie.Name = "UiColNumeroSerie"
        Me.UiColNumeroSerie.OptionsColumn.AllowEdit = False
        Me.UiColNumeroSerie.Visible = True
        Me.UiColNumeroSerie.VisibleIndex = 19
        Me.UiColNumeroSerie.Width = 150
        '
        'UiColLote
        '
        Me.UiColLote.Caption = "Lote"
        Me.UiColLote.FieldName = "BATCH"
        Me.UiColLote.MinWidth = 40
        Me.UiColLote.Name = "UiColLote"
        Me.UiColLote.OptionsColumn.AllowEdit = False
        Me.UiColLote.Visible = True
        Me.UiColLote.VisibleIndex = 20
        Me.UiColLote.Width = 150
        '
        'UiColFechaExpriracion
        '
        Me.UiColFechaExpriracion.Caption = "Fecha De Expiración"
        Me.UiColFechaExpriracion.FieldName = "DATE_EXPIRATION"
        Me.UiColFechaExpriracion.MinWidth = 40
        Me.UiColFechaExpriracion.Name = "UiColFechaExpriracion"
        Me.UiColFechaExpriracion.OptionsColumn.AllowEdit = False
        Me.UiColFechaExpriracion.Visible = True
        Me.UiColFechaExpriracion.VisibleIndex = 21
        Me.UiColFechaExpriracion.Width = 150
        '
        'UiColVin
        '
        Me.UiColVin.Caption = "VIN"
        Me.UiColVin.FieldName = "VIN"
        Me.UiColVin.MinWidth = 40
        Me.UiColVin.Name = "UiColVin"
        Me.UiColVin.OptionsColumn.AllowEdit = False
        Me.UiColVin.Visible = True
        Me.UiColVin.VisibleIndex = 22
        Me.UiColVin.Width = 150
        '
        'UiGridViewEgresos
        '
        Me.UiGridViewEgresos.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colDOC_ID, Me.colNUMERO_ORDEN, Me.colCODIGO_POLIZA, Me.colCLIENT_CODE, Me.colClientName, Me.colFECHA_DOCUMENTO, Me.colMaterialDesc, Me.colMaterial_Code, Me.colBultos, Me.colCantidad, Me.colValorUnitario, Me.colValorTotal, Me.colConsignatario, Me.colRegimen, Me.colGRUPO_REGIMEN, Me.colREGIMEN_DOCUMENTO, Me.UiColDiasRegimen, Me.UiColDiasParaVencer, Me.UiColFechaVencimiento, Me.UiColEstadoRegimen, Me.UiColNombreEstado, Me.UiColInventarioBloqueado, Me.UiColColor, Me.UiColTono, Me.UiColCalibre, Me.UiColNumeroDeSerieFiscal, Me.UiColLoteFiscal, Me.UiColFechaExpiracionFiscal, Me.UiColVinFiscal})
        Me.UiGridViewEgresos.DetailHeight = 673
        Me.UiGridViewEgresos.FixedLineWidth = 4
        StyleFormatCondition3.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        StyleFormatCondition3.Appearance.Options.UseBackColor = True
        StyleFormatCondition3.ApplyToRow = True
        StyleFormatCondition3.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression
        StyleFormatCondition3.Expression = "[STATUS] ==  'PENDIENTE'"
        StyleFormatCondition4.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        StyleFormatCondition4.Appearance.Options.UseBackColor = True
        StyleFormatCondition4.ApplyToRow = True
        StyleFormatCondition4.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression
        StyleFormatCondition4.Expression = "[STATUS] == 'ASOCIADO'"
        Me.UiGridViewEgresos.FormatConditions.AddRange(New DevExpress.XtraGrid.StyleFormatCondition() {StyleFormatCondition3, StyleFormatCondition4})
        Me.UiGridViewEgresos.GridControl = Me.UiVistaGridEgresos
        Me.UiGridViewEgresos.GroupCount = 1
        Me.UiGridViewEgresos.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TOTAL", Me.colValorTotal, "(Total: SUM={0:#,###,###.00})"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "MATERIAL_ID", Me.colDOC_ID, "(Cantidad registros={0})")})
        Me.UiGridViewEgresos.Name = "UiGridViewEgresos"
        Me.UiGridViewEgresos.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect
        Me.UiGridViewEgresos.OptionsView.ShowAutoFilterRow = True
        Me.UiGridViewEgresos.OptionsView.ShowFooter = True
        Me.UiGridViewEgresos.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.colDOC_ID, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'colDOC_ID
        '
        Me.colDOC_ID.Caption = "Número Documento"
        Me.colDOC_ID.FieldName = "DOC_ID"
        Me.colDOC_ID.MinWidth = 40
        Me.colDOC_ID.Name = "colDOC_ID"
        Me.colDOC_ID.OptionsColumn.AllowEdit = False
        Me.colDOC_ID.OptionsColumn.AllowFocus = False
        Me.colDOC_ID.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "DOC_ID", "Registros: {0}")})
        Me.colDOC_ID.Visible = True
        Me.colDOC_ID.VisibleIndex = 0
        Me.colDOC_ID.Width = 150
        '
        'colNUMERO_ORDEN
        '
        Me.colNUMERO_ORDEN.Caption = "Número Órden"
        Me.colNUMERO_ORDEN.FieldName = "ORDEN"
        Me.colNUMERO_ORDEN.MinWidth = 40
        Me.colNUMERO_ORDEN.Name = "colNUMERO_ORDEN"
        Me.colNUMERO_ORDEN.OptionsColumn.AllowEdit = False
        Me.colNUMERO_ORDEN.OptionsColumn.AllowFocus = False
        Me.colNUMERO_ORDEN.Visible = True
        Me.colNUMERO_ORDEN.VisibleIndex = 0
        Me.colNUMERO_ORDEN.Width = 150
        '
        'colCODIGO_POLIZA
        '
        Me.colCODIGO_POLIZA.Caption = "Código Póliza"
        Me.colCODIGO_POLIZA.FieldName = "POLIZA"
        Me.colCODIGO_POLIZA.MinWidth = 40
        Me.colCODIGO_POLIZA.Name = "colCODIGO_POLIZA"
        Me.colCODIGO_POLIZA.OptionsColumn.AllowEdit = False
        Me.colCODIGO_POLIZA.OptionsColumn.AllowFocus = False
        Me.colCODIGO_POLIZA.Visible = True
        Me.colCODIGO_POLIZA.VisibleIndex = 1
        Me.colCODIGO_POLIZA.Width = 150
        '
        'colCLIENT_CODE
        '
        Me.colCLIENT_CODE.Caption = "Código Cliente"
        Me.colCLIENT_CODE.FieldName = "CLIENT_CODE"
        Me.colCLIENT_CODE.MinWidth = 40
        Me.colCLIENT_CODE.Name = "colCLIENT_CODE"
        Me.colCLIENT_CODE.OptionsColumn.AllowEdit = False
        Me.colCLIENT_CODE.OptionsColumn.AllowFocus = False
        Me.colCLIENT_CODE.Visible = True
        Me.colCLIENT_CODE.VisibleIndex = 2
        Me.colCLIENT_CODE.Width = 150
        '
        'colClientName
        '
        Me.colClientName.Caption = "Nombre Cliente"
        Me.colClientName.FieldName = "CLIENTE"
        Me.colClientName.MinWidth = 40
        Me.colClientName.Name = "colClientName"
        Me.colClientName.OptionsColumn.AllowEdit = False
        Me.colClientName.OptionsColumn.AllowFocus = False
        Me.colClientName.Visible = True
        Me.colClientName.VisibleIndex = 3
        Me.colClientName.Width = 150
        '
        'colFECHA_DOCUMENTO
        '
        Me.colFECHA_DOCUMENTO.Caption = "Fecha Documento"
        Me.colFECHA_DOCUMENTO.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.colFECHA_DOCUMENTO.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.colFECHA_DOCUMENTO.FieldName = "FECHA"
        Me.colFECHA_DOCUMENTO.MinWidth = 40
        Me.colFECHA_DOCUMENTO.Name = "colFECHA_DOCUMENTO"
        Me.colFECHA_DOCUMENTO.OptionsColumn.AllowEdit = False
        Me.colFECHA_DOCUMENTO.OptionsColumn.AllowFocus = False
        Me.colFECHA_DOCUMENTO.Visible = True
        Me.colFECHA_DOCUMENTO.VisibleIndex = 4
        Me.colFECHA_DOCUMENTO.Width = 150
        '
        'colMaterialDesc
        '
        Me.colMaterialDesc.Caption = "Descripción Material"
        Me.colMaterialDesc.FieldName = "DESCRIPCION"
        Me.colMaterialDesc.MinWidth = 40
        Me.colMaterialDesc.Name = "colMaterialDesc"
        Me.colMaterialDesc.OptionsColumn.AllowEdit = False
        Me.colMaterialDesc.Visible = True
        Me.colMaterialDesc.VisibleIndex = 6
        Me.colMaterialDesc.Width = 150
        '
        'colMaterial_Code
        '
        Me.colMaterial_Code.Caption = "Código Material"
        Me.colMaterial_Code.FieldName = "MATERIAL_ID"
        Me.colMaterial_Code.MinWidth = 40
        Me.colMaterial_Code.Name = "colMaterial_Code"
        Me.colMaterial_Code.OptionsColumn.AllowEdit = False
        Me.colMaterial_Code.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "MATERIAL_ID", "{0}")})
        Me.colMaterial_Code.Visible = True
        Me.colMaterial_Code.VisibleIndex = 5
        Me.colMaterial_Code.Width = 150
        '
        'colBultos
        '
        Me.colBultos.Caption = "Bultos"
        Me.colBultos.FieldName = "BULTOS"
        Me.colBultos.MinWidth = 40
        Me.colBultos.Name = "colBultos"
        Me.colBultos.OptionsColumn.AllowEdit = False
        Me.colBultos.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "BULTOS", "{0:0.##}")})
        Me.colBultos.Visible = True
        Me.colBultos.VisibleIndex = 7
        Me.colBultos.Width = 150
        '
        'colCantidad
        '
        Me.colCantidad.Caption = "Cantidad"
        Me.colCantidad.FieldName = "CANTIDAD"
        Me.colCantidad.MinWidth = 40
        Me.colCantidad.Name = "colCantidad"
        Me.colCantidad.OptionsColumn.AllowEdit = False
        Me.colCantidad.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CANTIDAD", "{0:0.##}")})
        Me.colCantidad.Visible = True
        Me.colCantidad.VisibleIndex = 8
        Me.colCantidad.Width = 150
        '
        'colValorUnitario
        '
        Me.colValorUnitario.Caption = "Total Valor"
        Me.colValorUnitario.DisplayFormat.FormatString = "#,###,###.00"
        Me.colValorUnitario.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colValorUnitario.FieldName = "CUSTOMS_AMOUNT"
        Me.colValorUnitario.MinWidth = 40
        Me.colValorUnitario.Name = "colValorUnitario"
        Me.colValorUnitario.OptionsColumn.AllowEdit = False
        Me.colValorUnitario.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CUSTOMS_AMOUNT", "{0:#,###,###.00}")})
        Me.colValorUnitario.Visible = True
        Me.colValorUnitario.VisibleIndex = 9
        Me.colValorUnitario.Width = 150
        '
        'colValorTotal
        '
        Me.colValorTotal.Caption = "Total General"
        Me.colValorTotal.DisplayFormat.FormatString = "#,###,###.00"
        Me.colValorTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colValorTotal.FieldName = "IMPUESTO"
        Me.colValorTotal.MinWidth = 40
        Me.colValorTotal.Name = "colValorTotal"
        Me.colValorTotal.OptionsColumn.AllowEdit = False
        Me.colValorTotal.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "IMPUESTO", "{0:#,###,###.00}")})
        Me.colValorTotal.Visible = True
        Me.colValorTotal.VisibleIndex = 10
        Me.colValorTotal.Width = 150
        '
        'colConsignatario
        '
        Me.colConsignatario.Caption = "Consignatario"
        Me.colConsignatario.FieldName = "CONSIGNATARIO"
        Me.colConsignatario.MinWidth = 40
        Me.colConsignatario.Name = "colConsignatario"
        Me.colConsignatario.OptionsColumn.AllowEdit = False
        Me.colConsignatario.Visible = True
        Me.colConsignatario.VisibleIndex = 11
        Me.colConsignatario.Width = 150
        '
        'colRegimen
        '
        Me.colRegimen.Caption = "Régimen"
        Me.colRegimen.FieldName = "REGIMEN"
        Me.colRegimen.MinWidth = 40
        Me.colRegimen.Name = "colRegimen"
        Me.colRegimen.OptionsColumn.AllowEdit = False
        Me.colRegimen.Visible = True
        Me.colRegimen.VisibleIndex = 12
        Me.colRegimen.Width = 150
        '
        'colGRUPO_REGIMEN
        '
        Me.colGRUPO_REGIMEN.Caption = "Grupo Régimen"
        Me.colGRUPO_REGIMEN.FieldName = "GRUPO_REGIMEN"
        Me.colGRUPO_REGIMEN.MinWidth = 40
        Me.colGRUPO_REGIMEN.Name = "colGRUPO_REGIMEN"
        Me.colGRUPO_REGIMEN.OptionsColumn.AllowEdit = False
        Me.colGRUPO_REGIMEN.Visible = True
        Me.colGRUPO_REGIMEN.VisibleIndex = 13
        Me.colGRUPO_REGIMEN.Width = 150
        '
        'colREGIMEN_DOCUMENTO
        '
        Me.colREGIMEN_DOCUMENTO.Caption = "Régimen Doc."
        Me.colREGIMEN_DOCUMENTO.FieldName = "REGIMEN_DOCUMENTO"
        Me.colREGIMEN_DOCUMENTO.MinWidth = 40
        Me.colREGIMEN_DOCUMENTO.Name = "colREGIMEN_DOCUMENTO"
        Me.colREGIMEN_DOCUMENTO.OptionsColumn.AllowEdit = False
        Me.colREGIMEN_DOCUMENTO.Visible = True
        Me.colREGIMEN_DOCUMENTO.VisibleIndex = 14
        Me.colREGIMEN_DOCUMENTO.Width = 150
        '
        'UiColDiasRegimen
        '
        Me.UiColDiasRegimen.Caption = "Días en Régimen"
        Me.UiColDiasRegimen.FieldName = "DIAS_REGIMEN"
        Me.UiColDiasRegimen.MinWidth = 40
        Me.UiColDiasRegimen.Name = "UiColDiasRegimen"
        Me.UiColDiasRegimen.OptionsColumn.AllowEdit = False
        Me.UiColDiasRegimen.Visible = True
        Me.UiColDiasRegimen.VisibleIndex = 15
        Me.UiColDiasRegimen.Width = 150
        '
        'UiColDiasParaVencer
        '
        Me.UiColDiasParaVencer.Caption = "Días para Vencer"
        Me.UiColDiasParaVencer.FieldName = "DIAS_PARA_VENCER"
        Me.UiColDiasParaVencer.MinWidth = 40
        Me.UiColDiasParaVencer.Name = "UiColDiasParaVencer"
        Me.UiColDiasParaVencer.OptionsColumn.AllowEdit = False
        Me.UiColDiasParaVencer.Visible = True
        Me.UiColDiasParaVencer.VisibleIndex = 16
        Me.UiColDiasParaVencer.Width = 150
        '
        'UiColFechaVencimiento
        '
        Me.UiColFechaVencimiento.Caption = "Fecha Vencimiento"
        Me.UiColFechaVencimiento.FieldName = "FECHA_VENCIMIENTO"
        Me.UiColFechaVencimiento.MinWidth = 40
        Me.UiColFechaVencimiento.Name = "UiColFechaVencimiento"
        Me.UiColFechaVencimiento.OptionsColumn.AllowEdit = False
        Me.UiColFechaVencimiento.Visible = True
        Me.UiColFechaVencimiento.VisibleIndex = 17
        Me.UiColFechaVencimiento.Width = 150
        '
        'UiColEstadoRegimen
        '
        Me.UiColEstadoRegimen.Caption = "Estado Régimen"
        Me.UiColEstadoRegimen.FieldName = "ESTADO_REGIMEN"
        Me.UiColEstadoRegimen.MinWidth = 40
        Me.UiColEstadoRegimen.Name = "UiColEstadoRegimen"
        Me.UiColEstadoRegimen.OptionsColumn.AllowEdit = False
        Me.UiColEstadoRegimen.Visible = True
        Me.UiColEstadoRegimen.VisibleIndex = 18
        Me.UiColEstadoRegimen.Width = 150
        '
        'UiColNombreEstado
        '
        Me.UiColNombreEstado.Caption = "Estado"
        Me.UiColNombreEstado.FieldName = "STATUS_NAME"
        Me.UiColNombreEstado.MinWidth = 40
        Me.UiColNombreEstado.Name = "UiColNombreEstado"
        Me.UiColNombreEstado.OptionsColumn.AllowEdit = False
        Me.UiColNombreEstado.Visible = True
        Me.UiColNombreEstado.VisibleIndex = 19
        Me.UiColNombreEstado.Width = 150
        '
        'UiColInventarioBloqueado
        '
        Me.UiColInventarioBloqueado.Caption = "Bloqueado"
        Me.UiColInventarioBloqueado.FieldName = "BLOCKS_INVENTORY"
        Me.UiColInventarioBloqueado.MinWidth = 40
        Me.UiColInventarioBloqueado.Name = "UiColInventarioBloqueado"
        Me.UiColInventarioBloqueado.OptionsColumn.AllowEdit = False
        Me.UiColInventarioBloqueado.Visible = True
        Me.UiColInventarioBloqueado.VisibleIndex = 20
        Me.UiColInventarioBloqueado.Width = 150
        '
        'UiColColor
        '
        Me.UiColColor.Caption = "Color"
        Me.UiColColor.FieldName = "COLOR"
        Me.UiColColor.MinWidth = 40
        Me.UiColColor.Name = "UiColColor"
        Me.UiColColor.OptionsColumn.AllowEdit = False
        Me.UiColColor.Visible = True
        Me.UiColColor.VisibleIndex = 21
        Me.UiColColor.Width = 150
        '
        'UiColTono
        '
        Me.UiColTono.Caption = "Tono"
        Me.UiColTono.FieldName = "TONE"
        Me.UiColTono.MinWidth = 40
        Me.UiColTono.Name = "UiColTono"
        Me.UiColTono.OptionsColumn.AllowEdit = False
        Me.UiColTono.OptionsColumn.ReadOnly = True
        Me.UiColTono.Visible = True
        Me.UiColTono.VisibleIndex = 22
        Me.UiColTono.Width = 150
        '
        'UiColCalibre
        '
        Me.UiColCalibre.Caption = "Calibre"
        Me.UiColCalibre.FieldName = "CALIBER"
        Me.UiColCalibre.MinWidth = 40
        Me.UiColCalibre.Name = "UiColCalibre"
        Me.UiColCalibre.OptionsColumn.AllowEdit = False
        Me.UiColCalibre.OptionsColumn.ReadOnly = True
        Me.UiColCalibre.Visible = True
        Me.UiColCalibre.VisibleIndex = 23
        Me.UiColCalibre.Width = 150
        '
        'UiColNumeroDeSerieFiscal
        '
        Me.UiColNumeroDeSerieFiscal.Caption = "Número de Serie"
        Me.UiColNumeroDeSerieFiscal.FieldName = "SERIAL"
        Me.UiColNumeroDeSerieFiscal.MinWidth = 40
        Me.UiColNumeroDeSerieFiscal.Name = "UiColNumeroDeSerieFiscal"
        Me.UiColNumeroDeSerieFiscal.OptionsColumn.AllowEdit = False
        Me.UiColNumeroDeSerieFiscal.Visible = True
        Me.UiColNumeroDeSerieFiscal.VisibleIndex = 24
        Me.UiColNumeroDeSerieFiscal.Width = 150
        '
        'UiColLoteFiscal
        '
        Me.UiColLoteFiscal.Caption = "Lote"
        Me.UiColLoteFiscal.FieldName = "BATCH"
        Me.UiColLoteFiscal.MinWidth = 40
        Me.UiColLoteFiscal.Name = "UiColLoteFiscal"
        Me.UiColLoteFiscal.Visible = True
        Me.UiColLoteFiscal.VisibleIndex = 25
        Me.UiColLoteFiscal.Width = 150
        '
        'UiColFechaExpiracionFiscal
        '
        Me.UiColFechaExpiracionFiscal.Caption = "Fecha Expiración"
        Me.UiColFechaExpiracionFiscal.FieldName = "DATE_EXPIRATION"
        Me.UiColFechaExpiracionFiscal.MinWidth = 40
        Me.UiColFechaExpiracionFiscal.Name = "UiColFechaExpiracionFiscal"
        Me.UiColFechaExpiracionFiscal.Visible = True
        Me.UiColFechaExpiracionFiscal.VisibleIndex = 26
        Me.UiColFechaExpiracionFiscal.Width = 150
        '
        'UiColVinFiscal
        '
        Me.UiColVinFiscal.Caption = "VIN"
        Me.UiColVinFiscal.FieldName = "VIN"
        Me.UiColVinFiscal.MinWidth = 40
        Me.UiColVinFiscal.Name = "UiColVinFiscal"
        Me.UiColVinFiscal.Visible = True
        Me.UiColVinFiscal.VisibleIndex = 27
        Me.UiColVinFiscal.Width = 150
        '
        'BarButtonItem1
        '
        Me.BarButtonItem1.Caption = "Refresh"
        Me.BarButtonItem1.Id = 2
        Me.BarButtonItem1.ImageOptions.Image = CType(resources.GetObject("BarButtonItem1.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem1.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem1.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarButtonItem1.Name = "BarButtonItem1"
        '
        'UiEtiquetaRegimen
        '
        Me.UiEtiquetaRegimen.Location = New System.Drawing.Point(24, 77)
        Me.UiEtiquetaRegimen.Margin = New System.Windows.Forms.Padding(6)
        Me.UiEtiquetaRegimen.Name = "UiEtiquetaRegimen"
        Me.UiEtiquetaRegimen.Size = New System.Drawing.Size(89, 25)
        Me.UiEtiquetaRegimen.TabIndex = 35
        Me.UiEtiquetaRegimen.Text = "Régimen:"
        '
        'UiListaRegimen
        '
        Me.UiListaRegimen.Location = New System.Drawing.Point(126, 71)
        Me.UiListaRegimen.Margin = New System.Windows.Forms.Padding(6)
        Me.UiListaRegimen.MenuManager = Me.barManagerHeader
        Me.UiListaRegimen.Name = "UiListaRegimen"
        Me.UiListaRegimen.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.UiListaRegimen.Properties.DisplayMember = "PARAM_CAPTION"
        Me.UiListaRegimen.Properties.PopupView = Me.UiListaVistaRegimen
        Me.UiListaRegimen.Properties.ValueMember = "PARAM_NAME"
        Me.UiListaRegimen.Size = New System.Drawing.Size(638, 40)
        Me.UiListaRegimen.TabIndex = 36
        '
        'UiListaVistaRegimen
        '
        Me.UiListaVistaRegimen.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.UiColRegimenAlmacen, Me.UiColDescripcionRegimenAlmacen})
        Me.UiListaVistaRegimen.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.UiListaVistaRegimen.Name = "UiListaVistaRegimen"
        Me.UiListaVistaRegimen.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.UiListaVistaRegimen.OptionsView.ShowGroupPanel = False
        '
        'UiColRegimenAlmacen
        '
        Me.UiColRegimenAlmacen.Caption = "Régimen Almacén"
        Me.UiColRegimenAlmacen.FieldName = "PARAM_NAME"
        Me.UiColRegimenAlmacen.Name = "UiColRegimenAlmacen"
        Me.UiColRegimenAlmacen.Visible = True
        Me.UiColRegimenAlmacen.VisibleIndex = 0
        '
        'UiColDescripcionRegimenAlmacen
        '
        Me.UiColDescripcionRegimenAlmacen.Caption = "Descripción Régimen Almacén"
        Me.UiColDescripcionRegimenAlmacen.FieldName = "PARAM_CAPTION"
        Me.UiColDescripcionRegimenAlmacen.Name = "UiColDescripcionRegimenAlmacen"
        Me.UiColDescripcionRegimenAlmacen.Visible = True
        Me.UiColDescripcionRegimenAlmacen.VisibleIndex = 1
        '
        'UiListaCliente
        '
        Me.UiListaCliente.Location = New System.Drawing.Point(854, 71)
        Me.UiListaCliente.Margin = New System.Windows.Forms.Padding(6)
        Me.UiListaCliente.MenuManager = Me.barManagerHeader
        Me.UiListaCliente.Name = "UiListaCliente"
        Me.UiListaCliente.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.UiListaCliente.Properties.DisplayMember = "CLIENT_NAME"
        Me.UiListaCliente.Properties.PopupView = Me.UiListaVistaCliente
        Me.UiListaCliente.Properties.ShowClearButton = False
        Me.UiListaCliente.Properties.ValueMember = "CLIENT_CODE"
        Me.UiListaCliente.Size = New System.Drawing.Size(782, 40)
        Me.UiListaCliente.TabIndex = 37
        '
        'UiListaVistaCliente
        '
        Me.UiListaVistaCliente.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.UiColCodigoCliente, Me.UiColNombreCliente})
        Me.UiListaVistaCliente.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.UiListaVistaCliente.Name = "UiListaVistaCliente"
        Me.UiListaVistaCliente.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.UiListaVistaCliente.OptionsSelection.MultiSelect = True
        Me.UiListaVistaCliente.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
        Me.UiListaVistaCliente.OptionsView.ShowGroupPanel = False
        '
        'UiColCodigoCliente
        '
        Me.UiColCodigoCliente.Caption = "Código"
        Me.UiColCodigoCliente.FieldName = "CLIENT_CODE"
        Me.UiColCodigoCliente.Name = "UiColCodigoCliente"
        Me.UiColCodigoCliente.Visible = True
        Me.UiColCodigoCliente.VisibleIndex = 1
        '
        'UiColNombreCliente
        '
        Me.UiColNombreCliente.Caption = "Nombre"
        Me.UiColNombreCliente.FieldName = "CLIENT_NAME"
        Me.UiColNombreCliente.Name = "UiColNombreCliente"
        Me.UiColNombreCliente.Visible = True
        Me.UiColNombreCliente.VisibleIndex = 2
        '
        'UiError
        '
        Me.UiError.ContainerControl = Me
        '
        'loadLayout
        '
        Me.loadLayout.Interval = 300
        '
        'frmConsultaDeIngresoFiscal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(2398, 1071)
        Me.Controls.Add(Me.UiListaCliente)
        Me.Controls.Add(Me.UiListaRegimen)
        Me.Controls.Add(Me.UiEtiquetaRegimen)
        Me.Controls.Add(Me.UiVistaGridEgresos)
        Me.Controls.Add(Me.UiLabelCliente)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Margin = New System.Windows.Forms.Padding(6)
        Me.Name = "frmConsultaDeIngresoFiscal"
        Me.Text = "Reporte Ingreso"
        CType(Me.barManagerHeader,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.RepositoryItemDateEdit1.CalendarTimeProperties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.RepositoryItemDateEdit1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.RepositoryItemDateEdit2.CalendarTimeProperties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.RepositoryItemDateEdit2,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.RepositoryItemTextEdit1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.RepositoryItemTextEdit2,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.RepositoryItemDateEdit3.CalendarTimeProperties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.RepositoryItemDateEdit3,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.RepositoryItemTextEdit3,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.UiVistaGridEgresos,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.UiVistaIngresoGeneral,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.UiGridViewEgresos,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.UiListaRegimen.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.UiListaVistaRegimen,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.UiListaCliente.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.UiListaVistaCliente,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.UiError,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents barHeader As DevExpress.XtraBars.Bar
    Friend WithEvents Bar1 As DevExpress.XtraBars.Bar
    Friend WithEvents barManagerHeader As DevExpress.XtraBars.BarManager
    Friend WithEvents Bar2 As DevExpress.XtraBars.Bar
    Friend WithEvents UiBotonExpandirVista As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents UiBotonContraerVista As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents UIFechaInicio As DevExpress.XtraBars.BarEditItem
    Friend WithEvents RepositoryItemDateEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents UiFechaFinal As DevExpress.XtraBars.BarEditItem
    Friend WithEvents RepositoryItemDateEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents UiBotonRefrescarVista As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarEditItem5 As DevExpress.XtraBars.BarEditItem
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents BarEditItem6 As DevExpress.XtraBars.BarEditItem
    Friend WithEvents RepositoryItemTextEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents BarEditItem1 As DevExpress.XtraBars.BarEditItem
    Friend WithEvents BarEditItem2 As DevExpress.XtraBars.BarEditItem
    Friend WithEvents RepositoryItemDateEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents BarEditItem7 As DevExpress.XtraBars.BarEditItem
    Friend WithEvents RepositoryItemTextEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents UiBotonExportarExcelVista As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents UiBotonImprimir As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents UiLabelCliente As DevExpress.XtraEditors.LabelControl
    Friend WithEvents UiVistaGridEgresos As DevExpress.XtraGrid.GridControl
    Friend WithEvents UiGridViewEgresos As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colDOC_ID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNUMERO_ORDEN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCODIGO_POLIZA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCLIENT_CODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colClientName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFECHA_DOCUMENTO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMaterial_Code As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMaterialDesc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCantidad As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colValorUnitario As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colValorTotal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colConsignatario As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRegimen As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBultos As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents colGRUPO_REGIMEN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colREGIMEN_DOCUMENTO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UiListaRegimen As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents UiListaVistaRegimen As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents UiEtiquetaRegimen As DevExpress.XtraEditors.LabelControl
    Friend WithEvents UiColRegimenAlmacen As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UiColDescripcionRegimenAlmacen As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UiListaCliente As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents UiListaVistaCliente As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents UiColCodigoCliente As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UiColNombreCliente As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UiError As DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider
    Friend WithEvents UiVistaIngresoGeneral As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UiColInventarioExterno As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UiColDiasRegimen As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UiColDiasParaVencer As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UiColFechaVencimiento As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UiColEstadoRegimen As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTRANSFER_REQUEST_ID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colVEHICLE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDRIVER As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colWAREHOUSE_FROM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UiColNombreEstado As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UiColInventarioBloqueado As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UiColColor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colEstado As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBloqueaInventario As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colColor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTono As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCalibre As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UiColTono As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UiColCalibre As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UiColNumeroSerie As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UiColNumeroDeSerieFiscal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UiColLote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UiColFechaExpriracion As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UiColVin As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UiColLoteFiscal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UiColFechaExpiracionFiscal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UiColVinFiscal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents btnSaveLayout As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents loadLayout As Timer
End Class
