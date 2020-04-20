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
        CType(Me.barManagerHeader,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.RepositoryItemDateEdit1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.RepositoryItemDateEdit1.CalendarTimeProperties,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.RepositoryItemDateEdit2,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.RepositoryItemDateEdit2.CalendarTimeProperties,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.RepositoryItemTextEdit1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.RepositoryItemTextEdit2,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.RepositoryItemDateEdit3,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.RepositoryItemDateEdit3.CalendarTimeProperties,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.RepositoryItemTextEdit3,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.UiVistaGridEgresos,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.UiVistaIngresoGeneral,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.UiGridViewEgresos,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.UiListaRegimen.Properties,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.UiListaVistaRegimen,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.UiListaCliente.Properties,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.UiListaVistaCliente,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.UiError,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'barManagerHeader
        '
        Me.barManagerHeader.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Bar2})
        Me.barManagerHeader.DockControls.Add(Me.barDockControlTop)
        Me.barManagerHeader.DockControls.Add(Me.barDockControlBottom)
        Me.barManagerHeader.DockControls.Add(Me.barDockControlLeft)
        Me.barManagerHeader.DockControls.Add(Me.barDockControlRight)
        Me.barManagerHeader.Form = Me
        Me.barManagerHeader.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.UIFechaInicio, Me.UiFechaFinal, Me.UiBotonRefrescarVista, Me.BarEditItem5, Me.BarEditItem6, Me.BarEditItem1, Me.BarEditItem2, Me.BarEditItem7, Me.UiBotonExpandirVista, Me.UiBotonContraerVista, Me.UiBotonExportarExcelVista, Me.UiBotonImprimir})
        Me.barManagerHeader.MaxItemId = 14
        Me.barManagerHeader.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemDateEdit1, Me.RepositoryItemDateEdit2, Me.RepositoryItemTextEdit1, Me.RepositoryItemTextEdit2, Me.RepositoryItemDateEdit3, Me.RepositoryItemTextEdit3})
        '
        'Bar2
        '
        Me.Bar2.BarName = "Herramientas"
        Me.Bar2.DockCol = 0
        Me.Bar2.DockRow = 0
        Me.Bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar2.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.UiBotonExpandirVista, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.UiBotonContraerVista, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.UiBotonExportarExcelVista, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.UiBotonImprimir, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.UIFechaInicio, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.UiFechaFinal, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.UiBotonRefrescarVista, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)})
        Me.Bar2.OptionsBar.AllowQuickCustomization = false
        Me.Bar2.OptionsBar.DrawDragBorder = false
        Me.Bar2.OptionsBar.UseWholeRow = true
        Me.Bar2.Text = "Herramientas"
        '
        'UiBotonExpandirVista
        '
        Me.UiBotonExpandirVista.Caption = "Expandir"
        Me.UiBotonExpandirVista.Glyph = Global.WMSOnePlan_Client.My.Resources.Resources.linespacing_16x16
        Me.UiBotonExpandirVista.Id = 8
        Me.UiBotonExpandirVista.LargeGlyph = Global.WMSOnePlan_Client.My.Resources.Resources.linespacing_32x32
        Me.UiBotonExpandirVista.Name = "UiBotonExpandirVista"
        '
        'UiBotonContraerVista
        '
        Me.UiBotonContraerVista.Caption = "Contraer"
        Me.UiBotonContraerVista.Glyph = Global.WMSOnePlan_Client.My.Resources.Resources.linespacing2_16x16
        Me.UiBotonContraerVista.Id = 9
        Me.UiBotonContraerVista.LargeGlyph = Global.WMSOnePlan_Client.My.Resources.Resources.linespacing2_32x32
        Me.UiBotonContraerVista.Name = "UiBotonContraerVista"
        '
        'UiBotonExportarExcelVista
        '
        Me.UiBotonExportarExcelVista.Caption = "Excel"
        Me.UiBotonExportarExcelVista.Glyph = CType(resources.GetObject("UiBotonExportarExcelVista.Glyph"),System.Drawing.Image)
        Me.UiBotonExportarExcelVista.Id = 12
        Me.UiBotonExportarExcelVista.LargeGlyph = CType(resources.GetObject("UiBotonExportarExcelVista.LargeGlyph"),System.Drawing.Image)
        Me.UiBotonExportarExcelVista.Name = "UiBotonExportarExcelVista"
        '
        'UiBotonImprimir
        '
        Me.UiBotonImprimir.Caption = "Imprimir"
        Me.UiBotonImprimir.Glyph = CType(resources.GetObject("UiBotonImprimir.Glyph"),System.Drawing.Image)
        Me.UiBotonImprimir.Id = 13
        Me.UiBotonImprimir.LargeGlyph = CType(resources.GetObject("UiBotonImprimir.LargeGlyph"),System.Drawing.Image)
        Me.UiBotonImprimir.Name = "UiBotonImprimir"
        '
        'UIFechaInicio
        '
        Me.UIFechaInicio.Caption = "Fecha Inicio"
        Me.UIFechaInicio.Edit = Me.RepositoryItemDateEdit1
        Me.UIFechaInicio.EditWidth = 100
        Me.UIFechaInicio.Glyph = CType(resources.GetObject("UIFechaInicio.Glyph"),System.Drawing.Image)
        Me.UIFechaInicio.Id = 0
        Me.UIFechaInicio.LargeGlyph = CType(resources.GetObject("UIFechaInicio.LargeGlyph"),System.Drawing.Image)
        Me.UIFechaInicio.Name = "UIFechaInicio"
        '
        'RepositoryItemDateEdit1
        '
        Me.RepositoryItemDateEdit1.AutoHeight = false
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
        Me.UiFechaFinal.Glyph = CType(resources.GetObject("UiFechaFinal.Glyph"),System.Drawing.Image)
        Me.UiFechaFinal.Id = 1
        Me.UiFechaFinal.LargeGlyph = CType(resources.GetObject("UiFechaFinal.LargeGlyph"),System.Drawing.Image)
        Me.UiFechaFinal.Name = "UiFechaFinal"
        '
        'RepositoryItemDateEdit2
        '
        Me.RepositoryItemDateEdit2.AutoHeight = false
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
        Me.UiBotonRefrescarVista.Glyph = CType(resources.GetObject("UiBotonRefrescarVista.Glyph"),System.Drawing.Image)
        Me.UiBotonRefrescarVista.Id = 2
        Me.UiBotonRefrescarVista.LargeGlyph = CType(resources.GetObject("UiBotonRefrescarVista.LargeGlyph"),System.Drawing.Image)
        Me.UiBotonRefrescarVista.Name = "UiBotonRefrescarVista"
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = false
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(1199, 31)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = false
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 557)
        Me.barDockControlBottom.Size = New System.Drawing.Size(1199, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = false
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 31)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 526)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = false
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(1199, 31)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 526)
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
        Me.RepositoryItemTextEdit1.AutoHeight = false
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
        Me.RepositoryItemTextEdit2.AutoHeight = false
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
        Me.RepositoryItemDateEdit3.AutoHeight = false
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
        Me.RepositoryItemTextEdit3.AutoHeight = false
        Me.RepositoryItemTextEdit3.Name = "RepositoryItemTextEdit3"
        '
        'barHeader
        '
        Me.barHeader.BarName = "Herramientas"
        Me.barHeader.DockCol = 0
        Me.barHeader.DockRow = 0
        Me.barHeader.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.barHeader.OptionsBar.AllowQuickCustomization = false
        Me.barHeader.OptionsBar.DrawDragBorder = false
        Me.barHeader.OptionsBar.UseWholeRow = true
        Me.barHeader.Text = "Herramientas"
        '
        'Bar1
        '
        Me.Bar1.BarName = "Herramientas"
        Me.Bar1.DockCol = 0
        Me.Bar1.DockRow = 0
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar1.OptionsBar.AllowQuickCustomization = false
        Me.Bar1.OptionsBar.DrawDragBorder = false
        Me.Bar1.OptionsBar.UseWholeRow = true
        Me.Bar1.Text = "Herramientas"
        '
        'UiLabelCliente
        '
        Me.UiLabelCliente.Location = New System.Drawing.Point(388, 40)
        Me.UiLabelCliente.Name = "UiLabelCliente"
        Me.UiLabelCliente.Size = New System.Drawing.Size(33, 13)
        Me.UiLabelCliente.TabIndex = 20
        Me.UiLabelCliente.Text = "Cliente"
        '
        'UiVistaGridEgresos
        '
        Me.UiVistaGridEgresos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.UiVistaGridEgresos.Cursor = System.Windows.Forms.Cursors.Default
        Me.UiVistaGridEgresos.Location = New System.Drawing.Point(0, 63)
        Me.UiVistaGridEgresos.MainView = Me.UiVistaIngresoGeneral
        Me.UiVistaGridEgresos.MenuManager = Me.barManagerHeader
        Me.UiVistaGridEgresos.Name = "UiVistaGridEgresos"
        Me.UiVistaGridEgresos.Size = New System.Drawing.Size(1199, 482)
        Me.UiVistaGridEgresos.TabIndex = 25
        Me.UiVistaGridEgresos.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.UiVistaIngresoGeneral, Me.UiGridViewEgresos})
        '
        'UiVistaIngresoGeneral
        '
        Me.UiVistaIngresoGeneral.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7, Me.GridColumn8, Me.GridColumn10, Me.GridColumn11, Me.GridColumn12, Me.UiColInventarioExterno, Me.colTRANSFER_REQUEST_ID, Me.colVEHICLE, Me.colDRIVER, Me.colWAREHOUSE_FROM, Me.colEstado, Me.colBloqueaInventario, Me.colColor, Me.colTono, Me.colCalibre, Me.UiColNumeroSerie, Me.UiColLote, Me.UiColFechaExpriracion, Me.UiColVin})
        StyleFormatCondition1.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(255,Byte),Integer), CType(CType(192,Byte),Integer))
        StyleFormatCondition1.Appearance.Options.UseBackColor = true
        StyleFormatCondition1.ApplyToRow = true
        StyleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression
        StyleFormatCondition1.Expression = "[STATUS] ==  'PENDIENTE'"
        StyleFormatCondition2.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(192,Byte),Integer), CType(CType(255,Byte),Integer), CType(CType(192,Byte),Integer))
        StyleFormatCondition2.Appearance.Options.UseBackColor = true
        StyleFormatCondition2.ApplyToRow = true
        StyleFormatCondition2.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression
        StyleFormatCondition2.Expression = "[STATUS] == 'ASOCIADO'"
        Me.UiVistaIngresoGeneral.FormatConditions.AddRange(New DevExpress.XtraGrid.StyleFormatCondition() {StyleFormatCondition1, StyleFormatCondition2})
        Me.UiVistaIngresoGeneral.GridControl = Me.UiVistaGridEgresos
        Me.UiVistaIngresoGeneral.GroupCount = 1
        Me.UiVistaIngresoGeneral.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TOTAL", Me.GridColumn12, "(Total: SUM={0:#,###,###.00})"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "MATERIAL_ID", Me.GridColumn1, "(Cantidad registros={0})")})
        Me.UiVistaIngresoGeneral.Name = "UiVistaIngresoGeneral"
        Me.UiVistaIngresoGeneral.OptionsView.ShowAutoFilterRow = true
        Me.UiVistaIngresoGeneral.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn1, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Número Documento"
        Me.GridColumn1.FieldName = "DOC_ID"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.AllowEdit = false
        Me.GridColumn1.OptionsColumn.AllowFocus = false
        Me.GridColumn1.Visible = true
        Me.GridColumn1.VisibleIndex = 0
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Número Órden"
        Me.GridColumn2.FieldName = "ORDEN"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.OptionsColumn.AllowEdit = false
        Me.GridColumn2.OptionsColumn.AllowFocus = false
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Código Póliza"
        Me.GridColumn3.FieldName = "POLIZA"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.OptionsColumn.AllowEdit = false
        Me.GridColumn3.OptionsColumn.AllowFocus = false
        Me.GridColumn3.Visible = true
        Me.GridColumn3.VisibleIndex = 0
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Código Cliente"
        Me.GridColumn4.FieldName = "CLIENT_CODE"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.OptionsColumn.AllowEdit = false
        Me.GridColumn4.OptionsColumn.AllowFocus = false
        Me.GridColumn4.Visible = true
        Me.GridColumn4.VisibleIndex = 1
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Nombre Cliente"
        Me.GridColumn5.FieldName = "CLIENTE"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.OptionsColumn.AllowEdit = false
        Me.GridColumn5.OptionsColumn.AllowFocus = false
        Me.GridColumn5.Visible = true
        Me.GridColumn5.VisibleIndex = 2
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Fecha Documento"
        Me.GridColumn6.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn6.FieldName = "FECHA"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.OptionsColumn.AllowEdit = false
        Me.GridColumn6.OptionsColumn.AllowFocus = false
        Me.GridColumn6.Visible = true
        Me.GridColumn6.VisibleIndex = 3
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Descripción Material"
        Me.GridColumn7.FieldName = "DESCRIPCION"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.OptionsColumn.AllowEdit = false
        Me.GridColumn7.Visible = true
        Me.GridColumn7.VisibleIndex = 4
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "Código Material"
        Me.GridColumn8.FieldName = "MATERIAL_ID"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.OptionsColumn.AllowEdit = false
        Me.GridColumn8.Visible = true
        Me.GridColumn8.VisibleIndex = 5
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Cantidad"
        Me.GridColumn10.FieldName = "CANTIDAD"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.OptionsColumn.AllowEdit = false
        Me.GridColumn10.Visible = true
        Me.GridColumn10.VisibleIndex = 6
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "Valor unitario"
        Me.GridColumn11.DisplayFormat.FormatString = "#,###,###.00"
        Me.GridColumn11.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn11.FieldName = "VALOR_UNITARIO"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.OptionsColumn.AllowEdit = false
        Me.GridColumn11.Visible = true
        Me.GridColumn11.VisibleIndex = 7
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "Total"
        Me.GridColumn12.DisplayFormat.FormatString = "#,###,###.00"
        Me.GridColumn12.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn12.FieldName = "TOTAL"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.OptionsColumn.AllowEdit = false
        Me.GridColumn12.Visible = true
        Me.GridColumn12.VisibleIndex = 8
        '
        'UiColInventarioExterno
        '
        Me.UiColInventarioExterno.Caption = "Inventario Externo"
        Me.UiColInventarioExterno.FieldName = "IS_EXTERNAL_INVENTORY"
        Me.UiColInventarioExterno.Name = "UiColInventarioExterno"
        Me.UiColInventarioExterno.OptionsColumn.AllowEdit = false
        Me.UiColInventarioExterno.Visible = true
        Me.UiColInventarioExterno.VisibleIndex = 9
        '
        'colTRANSFER_REQUEST_ID
        '
        Me.colTRANSFER_REQUEST_ID.Caption = "Número de Solicitud de Traslado"
        Me.colTRANSFER_REQUEST_ID.FieldName = "TRANSFER_REQUEST_ID"
        Me.colTRANSFER_REQUEST_ID.Name = "colTRANSFER_REQUEST_ID"
        Me.colTRANSFER_REQUEST_ID.OptionsColumn.AllowEdit = false
        Me.colTRANSFER_REQUEST_ID.Visible = true
        Me.colTRANSFER_REQUEST_ID.VisibleIndex = 10
        '
        'colVEHICLE
        '
        Me.colVEHICLE.Caption = "Nombre del Trasporte"
        Me.colVEHICLE.FieldName = "VEHICLE"
        Me.colVEHICLE.Name = "colVEHICLE"
        Me.colVEHICLE.OptionsColumn.AllowEdit = false
        Me.colVEHICLE.Visible = true
        Me.colVEHICLE.VisibleIndex = 11
        '
        'colDRIVER
        '
        Me.colDRIVER.Caption = "Piloto"
        Me.colDRIVER.FieldName = "DRIVER"
        Me.colDRIVER.Name = "colDRIVER"
        Me.colDRIVER.OptionsColumn.AllowEdit = false
        Me.colDRIVER.Visible = true
        Me.colDRIVER.VisibleIndex = 12
        '
        'colWAREHOUSE_FROM
        '
        Me.colWAREHOUSE_FROM.Caption = "Bodega Origen"
        Me.colWAREHOUSE_FROM.FieldName = "WAREHOUSE_FROM"
        Me.colWAREHOUSE_FROM.Name = "colWAREHOUSE_FROM"
        Me.colWAREHOUSE_FROM.OptionsColumn.AllowEdit = false
        Me.colWAREHOUSE_FROM.Visible = true
        Me.colWAREHOUSE_FROM.VisibleIndex = 13
        '
        'colEstado
        '
        Me.colEstado.Caption = "Estado"
        Me.colEstado.FieldName = "STATUS_NAME"
        Me.colEstado.Name = "colEstado"
        Me.colEstado.OptionsColumn.AllowEdit = false
        Me.colEstado.OptionsColumn.AllowFocus = false
        Me.colEstado.Visible = true
        Me.colEstado.VisibleIndex = 14
        '
        'colBloqueaInventario
        '
        Me.colBloqueaInventario.Caption = "Bloqueado"
        Me.colBloqueaInventario.FieldName = "BLOCKS_INVENTORY"
        Me.colBloqueaInventario.Name = "colBloqueaInventario"
        Me.colBloqueaInventario.OptionsColumn.AllowEdit = false
        Me.colBloqueaInventario.OptionsColumn.AllowFocus = false
        Me.colBloqueaInventario.Visible = true
        Me.colBloqueaInventario.VisibleIndex = 15
        '
        'colColor
        '
        Me.colColor.Caption = "Color"
        Me.colColor.FieldName = "COLOR"
        Me.colColor.Name = "colColor"
        Me.colColor.OptionsColumn.AllowEdit = false
        Me.colColor.OptionsColumn.AllowFocus = false
        Me.colColor.Visible = true
        Me.colColor.VisibleIndex = 16
        '
        'colTono
        '
        Me.colTono.Caption = "Tono"
        Me.colTono.FieldName = "TONE"
        Me.colTono.Name = "colTono"
        Me.colTono.OptionsColumn.AllowEdit = false
        Me.colTono.OptionsColumn.ReadOnly = true
        Me.colTono.Visible = true
        Me.colTono.VisibleIndex = 17
        '
        'colCalibre
        '
        Me.colCalibre.Caption = "Calibre"
        Me.colCalibre.FieldName = "CALIBER"
        Me.colCalibre.Name = "colCalibre"
        Me.colCalibre.OptionsColumn.AllowEdit = false
        Me.colCalibre.OptionsColumn.ReadOnly = true
        Me.colCalibre.Visible = true
        Me.colCalibre.VisibleIndex = 18
        '
        'UiColNumeroSerie
        '
        Me.UiColNumeroSerie.Caption = "Número de Serie"
        Me.UiColNumeroSerie.FieldName = "SERIAL"
        Me.UiColNumeroSerie.Name = "UiColNumeroSerie"
        Me.UiColNumeroSerie.OptionsColumn.AllowEdit = false
        Me.UiColNumeroSerie.Visible = true
        Me.UiColNumeroSerie.VisibleIndex = 19
        '
        'UiColLote
        '
        Me.UiColLote.Caption = "Lote"
        Me.UiColLote.FieldName = "BATCH"
        Me.UiColLote.Name = "UiColLote"
        Me.UiColLote.OptionsColumn.AllowEdit = false
        Me.UiColLote.Visible = true
        Me.UiColLote.VisibleIndex = 20
        '
        'UiColFechaExpriracion
        '
        Me.UiColFechaExpriracion.Caption = "Fecha De Expiración"
        Me.UiColFechaExpriracion.FieldName = "DATE_EXPIRATION"
        Me.UiColFechaExpriracion.Name = "UiColFechaExpriracion"
        Me.UiColFechaExpriracion.OptionsColumn.AllowEdit = false
        Me.UiColFechaExpriracion.Visible = true
        Me.UiColFechaExpriracion.VisibleIndex = 21
        '
        'UiColVin
        '
        Me.UiColVin.Caption = "VIN"
        Me.UiColVin.FieldName = "VIN"
        Me.UiColVin.Name = "UiColVin"
        Me.UiColVin.OptionsColumn.AllowEdit = false
        Me.UiColVin.Visible = true
        Me.UiColVin.VisibleIndex = 22
        '
        'UiGridViewEgresos
        '
        Me.UiGridViewEgresos.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colDOC_ID, Me.colNUMERO_ORDEN, Me.colCODIGO_POLIZA, Me.colCLIENT_CODE, Me.colClientName, Me.colFECHA_DOCUMENTO, Me.colMaterialDesc, Me.colMaterial_Code, Me.colBultos, Me.colCantidad, Me.colValorUnitario, Me.colValorTotal, Me.colConsignatario, Me.colRegimen, Me.colGRUPO_REGIMEN, Me.colREGIMEN_DOCUMENTO, Me.UiColDiasRegimen, Me.UiColDiasParaVencer, Me.UiColFechaVencimiento, Me.UiColEstadoRegimen, Me.UiColNombreEstado, Me.UiColInventarioBloqueado, Me.UiColColor, Me.UiColTono, Me.UiColCalibre, Me.UiColNumeroDeSerieFiscal, Me.UiColLoteFiscal, Me.UiColFechaExpiracionFiscal, Me.UiColVinFiscal})
        StyleFormatCondition3.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(255,Byte),Integer), CType(CType(192,Byte),Integer))
        StyleFormatCondition3.Appearance.Options.UseBackColor = true
        StyleFormatCondition3.ApplyToRow = true
        StyleFormatCondition3.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression
        StyleFormatCondition3.Expression = "[STATUS] ==  'PENDIENTE'"
        StyleFormatCondition4.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(192,Byte),Integer), CType(CType(255,Byte),Integer), CType(CType(192,Byte),Integer))
        StyleFormatCondition4.Appearance.Options.UseBackColor = true
        StyleFormatCondition4.ApplyToRow = true
        StyleFormatCondition4.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression
        StyleFormatCondition4.Expression = "[STATUS] == 'ASOCIADO'"
        Me.UiGridViewEgresos.FormatConditions.AddRange(New DevExpress.XtraGrid.StyleFormatCondition() {StyleFormatCondition3, StyleFormatCondition4})
        Me.UiGridViewEgresos.GridControl = Me.UiVistaGridEgresos
        Me.UiGridViewEgresos.GroupCount = 1
        Me.UiGridViewEgresos.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TOTAL", Me.colValorTotal, "(Total: SUM={0:#,###,###.00})"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "MATERIAL_ID", Me.colDOC_ID, "(Cantidad registros={0})")})
        Me.UiGridViewEgresos.Name = "UiGridViewEgresos"
        Me.UiGridViewEgresos.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect
        Me.UiGridViewEgresos.OptionsView.ShowAutoFilterRow = true
        Me.UiGridViewEgresos.OptionsView.ShowFooter = true
        Me.UiGridViewEgresos.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.colDOC_ID, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'colDOC_ID
        '
        Me.colDOC_ID.Caption = "Número Documento"
        Me.colDOC_ID.FieldName = "DOC_ID"
        Me.colDOC_ID.Name = "colDOC_ID"
        Me.colDOC_ID.OptionsColumn.AllowEdit = false
        Me.colDOC_ID.OptionsColumn.AllowFocus = false
        Me.colDOC_ID.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "DOC_ID", "Registros: {0}")})
        Me.colDOC_ID.Visible = true
        Me.colDOC_ID.VisibleIndex = 0
        '
        'colNUMERO_ORDEN
        '
        Me.colNUMERO_ORDEN.Caption = "Número Órden"
        Me.colNUMERO_ORDEN.FieldName = "ORDEN"
        Me.colNUMERO_ORDEN.Name = "colNUMERO_ORDEN"
        Me.colNUMERO_ORDEN.OptionsColumn.AllowEdit = false
        Me.colNUMERO_ORDEN.OptionsColumn.AllowFocus = false
        Me.colNUMERO_ORDEN.Visible = true
        Me.colNUMERO_ORDEN.VisibleIndex = 0
        '
        'colCODIGO_POLIZA
        '
        Me.colCODIGO_POLIZA.Caption = "Código Póliza"
        Me.colCODIGO_POLIZA.FieldName = "POLIZA"
        Me.colCODIGO_POLIZA.Name = "colCODIGO_POLIZA"
        Me.colCODIGO_POLIZA.OptionsColumn.AllowEdit = false
        Me.colCODIGO_POLIZA.OptionsColumn.AllowFocus = false
        Me.colCODIGO_POLIZA.Visible = true
        Me.colCODIGO_POLIZA.VisibleIndex = 1
        '
        'colCLIENT_CODE
        '
        Me.colCLIENT_CODE.Caption = "Código Cliente"
        Me.colCLIENT_CODE.FieldName = "CLIENT_CODE"
        Me.colCLIENT_CODE.Name = "colCLIENT_CODE"
        Me.colCLIENT_CODE.OptionsColumn.AllowEdit = false
        Me.colCLIENT_CODE.OptionsColumn.AllowFocus = false
        Me.colCLIENT_CODE.Visible = true
        Me.colCLIENT_CODE.VisibleIndex = 2
        '
        'colClientName
        '
        Me.colClientName.Caption = "Nombre Cliente"
        Me.colClientName.FieldName = "CLIENTE"
        Me.colClientName.Name = "colClientName"
        Me.colClientName.OptionsColumn.AllowEdit = false
        Me.colClientName.OptionsColumn.AllowFocus = false
        Me.colClientName.Visible = true
        Me.colClientName.VisibleIndex = 3
        '
        'colFECHA_DOCUMENTO
        '
        Me.colFECHA_DOCUMENTO.Caption = "Fecha Documento"
        Me.colFECHA_DOCUMENTO.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.colFECHA_DOCUMENTO.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.colFECHA_DOCUMENTO.FieldName = "FECHA"
        Me.colFECHA_DOCUMENTO.Name = "colFECHA_DOCUMENTO"
        Me.colFECHA_DOCUMENTO.OptionsColumn.AllowEdit = false
        Me.colFECHA_DOCUMENTO.OptionsColumn.AllowFocus = false
        Me.colFECHA_DOCUMENTO.Visible = true
        Me.colFECHA_DOCUMENTO.VisibleIndex = 4
        '
        'colMaterialDesc
        '
        Me.colMaterialDesc.Caption = "Descripción Material"
        Me.colMaterialDesc.FieldName = "DESCRIPCION"
        Me.colMaterialDesc.Name = "colMaterialDesc"
        Me.colMaterialDesc.OptionsColumn.AllowEdit = false
        Me.colMaterialDesc.Visible = true
        Me.colMaterialDesc.VisibleIndex = 6
        '
        'colMaterial_Code
        '
        Me.colMaterial_Code.Caption = "Código Material"
        Me.colMaterial_Code.FieldName = "MATERIAL_ID"
        Me.colMaterial_Code.Name = "colMaterial_Code"
        Me.colMaterial_Code.OptionsColumn.AllowEdit = false
        Me.colMaterial_Code.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "MATERIAL_ID", "{0}")})
        Me.colMaterial_Code.Visible = true
        Me.colMaterial_Code.VisibleIndex = 5
        '
        'colBultos
        '
        Me.colBultos.Caption = "Bultos"
        Me.colBultos.FieldName = "BULTOS"
        Me.colBultos.Name = "colBultos"
        Me.colBultos.OptionsColumn.AllowEdit = false
        Me.colBultos.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "BULTOS", "{0:0.##}")})
        Me.colBultos.Visible = true
        Me.colBultos.VisibleIndex = 7
        '
        'colCantidad
        '
        Me.colCantidad.Caption = "Cantidad"
        Me.colCantidad.FieldName = "CANTIDAD"
        Me.colCantidad.Name = "colCantidad"
        Me.colCantidad.OptionsColumn.AllowEdit = false
        Me.colCantidad.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CANTIDAD", "{0:0.##}")})
        Me.colCantidad.Visible = true
        Me.colCantidad.VisibleIndex = 8
        '
        'colValorUnitario
        '
        Me.colValorUnitario.Caption = "Total Valor"
        Me.colValorUnitario.DisplayFormat.FormatString = "#,###,###.00"
        Me.colValorUnitario.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colValorUnitario.FieldName = "CUSTOMS_AMOUNT"
        Me.colValorUnitario.Name = "colValorUnitario"
        Me.colValorUnitario.OptionsColumn.AllowEdit = false
        Me.colValorUnitario.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CUSTOMS_AMOUNT", "{0:#,###,###.00}")})
        Me.colValorUnitario.Visible = true
        Me.colValorUnitario.VisibleIndex = 9
        '
        'colValorTotal
        '
        Me.colValorTotal.Caption = "Total General"
        Me.colValorTotal.DisplayFormat.FormatString = "#,###,###.00"
        Me.colValorTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colValorTotal.FieldName = "IMPUESTO"
        Me.colValorTotal.Name = "colValorTotal"
        Me.colValorTotal.OptionsColumn.AllowEdit = false
        Me.colValorTotal.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "IMPUESTO", "{0:#,###,###.00}")})
        Me.colValorTotal.Visible = true
        Me.colValorTotal.VisibleIndex = 10
        '
        'colConsignatario
        '
        Me.colConsignatario.Caption = "Consignatario"
        Me.colConsignatario.FieldName = "CONSIGNATARIO"
        Me.colConsignatario.Name = "colConsignatario"
        Me.colConsignatario.OptionsColumn.AllowEdit = false
        Me.colConsignatario.Visible = true
        Me.colConsignatario.VisibleIndex = 11
        '
        'colRegimen
        '
        Me.colRegimen.Caption = "Régimen"
        Me.colRegimen.FieldName = "REGIMEN"
        Me.colRegimen.Name = "colRegimen"
        Me.colRegimen.OptionsColumn.AllowEdit = false
        Me.colRegimen.Visible = true
        Me.colRegimen.VisibleIndex = 12
        '
        'colGRUPO_REGIMEN
        '
        Me.colGRUPO_REGIMEN.Caption = "Grupo Régimen"
        Me.colGRUPO_REGIMEN.FieldName = "GRUPO_REGIMEN"
        Me.colGRUPO_REGIMEN.Name = "colGRUPO_REGIMEN"
        Me.colGRUPO_REGIMEN.OptionsColumn.AllowEdit = false
        Me.colGRUPO_REGIMEN.Visible = true
        Me.colGRUPO_REGIMEN.VisibleIndex = 13
        '
        'colREGIMEN_DOCUMENTO
        '
        Me.colREGIMEN_DOCUMENTO.Caption = "Régimen Doc."
        Me.colREGIMEN_DOCUMENTO.FieldName = "REGIMEN_DOCUMENTO"
        Me.colREGIMEN_DOCUMENTO.Name = "colREGIMEN_DOCUMENTO"
        Me.colREGIMEN_DOCUMENTO.OptionsColumn.AllowEdit = false
        Me.colREGIMEN_DOCUMENTO.Visible = true
        Me.colREGIMEN_DOCUMENTO.VisibleIndex = 14
        '
        'UiColDiasRegimen
        '
        Me.UiColDiasRegimen.Caption = "Días en Régimen"
        Me.UiColDiasRegimen.FieldName = "DIAS_REGIMEN"
        Me.UiColDiasRegimen.Name = "UiColDiasRegimen"
        Me.UiColDiasRegimen.OptionsColumn.AllowEdit = false
        Me.UiColDiasRegimen.Visible = true
        Me.UiColDiasRegimen.VisibleIndex = 15
        '
        'UiColDiasParaVencer
        '
        Me.UiColDiasParaVencer.Caption = "Días para Vencer"
        Me.UiColDiasParaVencer.FieldName = "DIAS_PARA_VENCER"
        Me.UiColDiasParaVencer.Name = "UiColDiasParaVencer"
        Me.UiColDiasParaVencer.OptionsColumn.AllowEdit = false
        Me.UiColDiasParaVencer.Visible = true
        Me.UiColDiasParaVencer.VisibleIndex = 16
        '
        'UiColFechaVencimiento
        '
        Me.UiColFechaVencimiento.Caption = "Fecha Vencimiento"
        Me.UiColFechaVencimiento.FieldName = "FECHA_VENCIMIENTO"
        Me.UiColFechaVencimiento.Name = "UiColFechaVencimiento"
        Me.UiColFechaVencimiento.OptionsColumn.AllowEdit = false
        Me.UiColFechaVencimiento.Visible = true
        Me.UiColFechaVencimiento.VisibleIndex = 17
        '
        'UiColEstadoRegimen
        '
        Me.UiColEstadoRegimen.Caption = "Estado Régimen"
        Me.UiColEstadoRegimen.FieldName = "ESTADO_REGIMEN"
        Me.UiColEstadoRegimen.Name = "UiColEstadoRegimen"
        Me.UiColEstadoRegimen.OptionsColumn.AllowEdit = false
        Me.UiColEstadoRegimen.Visible = true
        Me.UiColEstadoRegimen.VisibleIndex = 18
        '
        'UiColNombreEstado
        '
        Me.UiColNombreEstado.Caption = "Estado"
        Me.UiColNombreEstado.FieldName = "STATUS_NAME"
        Me.UiColNombreEstado.Name = "UiColNombreEstado"
        Me.UiColNombreEstado.OptionsColumn.AllowEdit = false
        Me.UiColNombreEstado.Visible = true
        Me.UiColNombreEstado.VisibleIndex = 19
        '
        'UiColInventarioBloqueado
        '
        Me.UiColInventarioBloqueado.Caption = "Bloqueado"
        Me.UiColInventarioBloqueado.FieldName = "BLOCKS_INVENTORY"
        Me.UiColInventarioBloqueado.Name = "UiColInventarioBloqueado"
        Me.UiColInventarioBloqueado.OptionsColumn.AllowEdit = false
        Me.UiColInventarioBloqueado.Visible = true
        Me.UiColInventarioBloqueado.VisibleIndex = 20
        '
        'UiColColor
        '
        Me.UiColColor.Caption = "Color"
        Me.UiColColor.FieldName = "COLOR"
        Me.UiColColor.Name = "UiColColor"
        Me.UiColColor.OptionsColumn.AllowEdit = false
        Me.UiColColor.Visible = true
        Me.UiColColor.VisibleIndex = 21
        '
        'UiColTono
        '
        Me.UiColTono.Caption = "Tono"
        Me.UiColTono.FieldName = "TONE"
        Me.UiColTono.Name = "UiColTono"
        Me.UiColTono.OptionsColumn.AllowEdit = false
        Me.UiColTono.OptionsColumn.ReadOnly = true
        Me.UiColTono.Visible = true
        Me.UiColTono.VisibleIndex = 22
        '
        'UiColCalibre
        '
        Me.UiColCalibre.Caption = "Calibre"
        Me.UiColCalibre.FieldName = "CALIBER"
        Me.UiColCalibre.Name = "UiColCalibre"
        Me.UiColCalibre.OptionsColumn.AllowEdit = false
        Me.UiColCalibre.OptionsColumn.ReadOnly = true
        Me.UiColCalibre.Visible = true
        Me.UiColCalibre.VisibleIndex = 23
        '
        'UiColNumeroDeSerieFiscal
        '
        Me.UiColNumeroDeSerieFiscal.Caption = "Número de Serie"
        Me.UiColNumeroDeSerieFiscal.FieldName = "SERIAL"
        Me.UiColNumeroDeSerieFiscal.Name = "UiColNumeroDeSerieFiscal"
        Me.UiColNumeroDeSerieFiscal.OptionsColumn.AllowEdit = false
        Me.UiColNumeroDeSerieFiscal.Visible = true
        Me.UiColNumeroDeSerieFiscal.VisibleIndex = 24
        '
        'UiColLoteFiscal
        '
        Me.UiColLoteFiscal.Caption = "Lote"
        Me.UiColLoteFiscal.FieldName = "BATCH"
        Me.UiColLoteFiscal.Name = "UiColLoteFiscal"
        Me.UiColLoteFiscal.Visible = true
        Me.UiColLoteFiscal.VisibleIndex = 25
        '
        'UiColFechaExpiracionFiscal
        '
        Me.UiColFechaExpiracionFiscal.Caption = "Fecha Expiración"
        Me.UiColFechaExpiracionFiscal.FieldName = "DATE_EXPIRATION"
        Me.UiColFechaExpiracionFiscal.Name = "UiColFechaExpiracionFiscal"
        Me.UiColFechaExpiracionFiscal.Visible = true
        Me.UiColFechaExpiracionFiscal.VisibleIndex = 26
        '
        'UiColVinFiscal
        '
        Me.UiColVinFiscal.Caption = "VIN"
        Me.UiColVinFiscal.FieldName = "VIN"
        Me.UiColVinFiscal.Name = "UiColVinFiscal"
        Me.UiColVinFiscal.Visible = true
        Me.UiColVinFiscal.VisibleIndex = 27
        '
        'BarButtonItem1
        '
        Me.BarButtonItem1.Caption = "Refresh"
        Me.BarButtonItem1.Glyph = CType(resources.GetObject("BarButtonItem1.Glyph"),System.Drawing.Image)
        Me.BarButtonItem1.Id = 2
        Me.BarButtonItem1.LargeGlyph = CType(resources.GetObject("BarButtonItem1.LargeGlyph"),System.Drawing.Image)
        Me.BarButtonItem1.Name = "BarButtonItem1"
        '
        'UiEtiquetaRegimen
        '
        Me.UiEtiquetaRegimen.Location = New System.Drawing.Point(12, 40)
        Me.UiEtiquetaRegimen.Name = "UiEtiquetaRegimen"
        Me.UiEtiquetaRegimen.Size = New System.Drawing.Size(45, 13)
        Me.UiEtiquetaRegimen.TabIndex = 35
        Me.UiEtiquetaRegimen.Text = "Régimen:"
        '
        'UiListaRegimen
        '
        Me.UiListaRegimen.Location = New System.Drawing.Point(63, 37)
        Me.UiListaRegimen.MenuManager = Me.barManagerHeader
        Me.UiListaRegimen.Name = "UiListaRegimen"
        Me.UiListaRegimen.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.UiListaRegimen.Properties.DisplayMember = "PARAM_CAPTION"
        Me.UiListaRegimen.Properties.ValueMember = "PARAM_NAME"
        Me.UiListaRegimen.Properties.View = Me.UiListaVistaRegimen
        Me.UiListaRegimen.Size = New System.Drawing.Size(319, 20)
        Me.UiListaRegimen.TabIndex = 36
        '
        'UiListaVistaRegimen
        '
        Me.UiListaVistaRegimen.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.UiColRegimenAlmacen, Me.UiColDescripcionRegimenAlmacen})
        Me.UiListaVistaRegimen.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.UiListaVistaRegimen.Name = "UiListaVistaRegimen"
        Me.UiListaVistaRegimen.OptionsSelection.EnableAppearanceFocusedCell = false
        Me.UiListaVistaRegimen.OptionsView.ShowGroupPanel = false
        '
        'UiColRegimenAlmacen
        '
        Me.UiColRegimenAlmacen.Caption = "Régimen Almacén"
        Me.UiColRegimenAlmacen.FieldName = "PARAM_NAME"
        Me.UiColRegimenAlmacen.Name = "UiColRegimenAlmacen"
        Me.UiColRegimenAlmacen.Visible = true
        Me.UiColRegimenAlmacen.VisibleIndex = 0
        '
        'UiColDescripcionRegimenAlmacen
        '
        Me.UiColDescripcionRegimenAlmacen.Caption = "Descripción Régimen Almacén"
        Me.UiColDescripcionRegimenAlmacen.FieldName = "PARAM_CAPTION"
        Me.UiColDescripcionRegimenAlmacen.Name = "UiColDescripcionRegimenAlmacen"
        Me.UiColDescripcionRegimenAlmacen.Visible = true
        Me.UiColDescripcionRegimenAlmacen.VisibleIndex = 1
        '
        'UiListaCliente
        '
        Me.UiListaCliente.Location = New System.Drawing.Point(427, 37)
        Me.UiListaCliente.MenuManager = Me.barManagerHeader
        Me.UiListaCliente.Name = "UiListaCliente"
        Me.UiListaCliente.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.UiListaCliente.Properties.DisplayMember = "CLIENT_NAME"
        Me.UiListaCliente.Properties.ShowClearButton = false
        Me.UiListaCliente.Properties.ValueMember = "CLIENT_CODE"
        Me.UiListaCliente.Properties.View = Me.UiListaVistaCliente
        Me.UiListaCliente.Size = New System.Drawing.Size(391, 20)
        Me.UiListaCliente.TabIndex = 37
        '
        'UiListaVistaCliente
        '
        Me.UiListaVistaCliente.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.UiColCodigoCliente, Me.UiColNombreCliente})
        Me.UiListaVistaCliente.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.UiListaVistaCliente.Name = "UiListaVistaCliente"
        Me.UiListaVistaCliente.OptionsSelection.EnableAppearanceFocusedCell = false
        Me.UiListaVistaCliente.OptionsSelection.MultiSelect = true
        Me.UiListaVistaCliente.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
        Me.UiListaVistaCliente.OptionsView.ShowGroupPanel = false
        '
        'UiColCodigoCliente
        '
        Me.UiColCodigoCliente.Caption = "Código"
        Me.UiColCodigoCliente.FieldName = "CLIENT_CODE"
        Me.UiColCodigoCliente.Name = "UiColCodigoCliente"
        Me.UiColCodigoCliente.Visible = true
        Me.UiColCodigoCliente.VisibleIndex = 1
        '
        'UiColNombreCliente
        '
        Me.UiColNombreCliente.Caption = "Nombre"
        Me.UiColNombreCliente.FieldName = "CLIENT_NAME"
        Me.UiColNombreCliente.Name = "UiColNombreCliente"
        Me.UiColNombreCliente.Visible = true
        Me.UiColNombreCliente.VisibleIndex = 2
        '
        'UiError
        '
        Me.UiError.ContainerControl = Me
        '
        'frmConsultaDeIngresoFiscal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1199, 557)
        Me.Controls.Add(Me.UiListaCliente)
        Me.Controls.Add(Me.UiListaRegimen)
        Me.Controls.Add(Me.UiEtiquetaRegimen)
        Me.Controls.Add(Me.UiVistaGridEgresos)
        Me.Controls.Add(Me.UiLabelCliente)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
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
End Class
