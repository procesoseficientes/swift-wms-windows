<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConsultaDeEgreso
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmConsultaDeEgreso))
        Dim StyleFormatCondition1 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Dim StyleFormatCondition2 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
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
        Me.cmbClientes = New DevExpress.XtraEditors.GridLookUpEdit()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.cmbRegimen = New DevExpress.XtraEditors.GridLookUpEdit()
        Me.GridLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.UiLabelRegimen = New DevExpress.XtraEditors.LabelControl()
        Me.UiLabelCliente = New DevExpress.XtraEditors.LabelControl()
        Me.UiVistaGridEgresos = New DevExpress.XtraGrid.GridControl()
        Me.UiGridViewEgresos = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colDOC_ID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNUMERO_ORDEN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCODIGO_POLIZA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCLIENT_CODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colClientName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFECHA_DOCUMENTO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMaterialDesc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMaterial_Code = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCantidad = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colValorUnitario = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colValorTotal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colConsignatario = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRegimen = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colGRUPO_REGIMEN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colREGIMEN_DOCUMENTO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colIS_EXTERNAL_INVENTORY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTRANSFER_REQUEST_ID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colWAREHOUSE_TO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UiColNumeroDeSerie = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UiColLote = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UiColFechaExpiracion = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UiColVin = New DevExpress.XtraGrid.Columns.GridColumn()
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
        CType(Me.cmbClientes.Properties,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.GridView3,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.cmbRegimen.Properties,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.GridLookUpEdit1View,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.UiVistaGridEgresos,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.UiGridViewEgresos,System.ComponentModel.ISupportInitialize).BeginInit
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
        Me.barDockControlTop.Size = New System.Drawing.Size(1190, 31)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = false
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 489)
        Me.barDockControlBottom.Size = New System.Drawing.Size(1190, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = false
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 31)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 458)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = false
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(1190, 31)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 458)
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
        'cmbClientes
        '
        Me.cmbClientes.Location = New System.Drawing.Point(461, 37)
        Me.cmbClientes.Name = "cmbClientes"
        Me.cmbClientes.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbClientes.Properties.View = Me.GridView3
        Me.cmbClientes.Size = New System.Drawing.Size(344, 20)
        Me.cmbClientes.TabIndex = 18
        '
        'GridView3
        '
        Me.GridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView3.Name = "GridView3"
        Me.GridView3.OptionsSelection.EnableAppearanceFocusedCell = false
        Me.GridView3.OptionsSelection.MultiSelect = true
        Me.GridView3.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
        Me.GridView3.OptionsView.ShowAutoFilterRow = true
        Me.GridView3.OptionsView.ShowGroupPanel = false
        '
        'cmbRegimen
        '
        Me.cmbRegimen.Location = New System.Drawing.Point(68, 37)
        Me.cmbRegimen.Name = "cmbRegimen"
        Me.cmbRegimen.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbRegimen.Properties.View = Me.GridLookUpEdit1View
        Me.cmbRegimen.Size = New System.Drawing.Size(344, 20)
        Me.cmbRegimen.TabIndex = 17
        '
        'GridLookUpEdit1View
        '
        Me.GridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridLookUpEdit1View.Name = "GridLookUpEdit1View"
        Me.GridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false
        Me.GridLookUpEdit1View.OptionsView.ShowGroupPanel = false
        '
        'UiLabelRegimen
        '
        Me.UiLabelRegimen.Location = New System.Drawing.Point(21, 40)
        Me.UiLabelRegimen.Name = "UiLabelRegimen"
        Me.UiLabelRegimen.Size = New System.Drawing.Size(41, 13)
        Me.UiLabelRegimen.TabIndex = 19
        Me.UiLabelRegimen.Text = "Régimen"
        '
        'UiLabelCliente
        '
        Me.UiLabelCliente.Location = New System.Drawing.Point(426, 38)
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
        Me.UiVistaGridEgresos.Location = New System.Drawing.Point(0, 65)
        Me.UiVistaGridEgresos.MainView = Me.UiGridViewEgresos
        Me.UiVistaGridEgresos.MenuManager = Me.barManagerHeader
        Me.UiVistaGridEgresos.Name = "UiVistaGridEgresos"
        Me.UiVistaGridEgresos.Size = New System.Drawing.Size(1190, 424)
        Me.UiVistaGridEgresos.TabIndex = 25
        Me.UiVistaGridEgresos.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.UiGridViewEgresos})
        '
        'UiGridViewEgresos
        '
        Me.UiGridViewEgresos.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colDOC_ID, Me.colNUMERO_ORDEN, Me.colCODIGO_POLIZA, Me.colCLIENT_CODE, Me.colClientName, Me.colFECHA_DOCUMENTO, Me.colMaterialDesc, Me.colMaterial_Code, Me.colCantidad, Me.colValorUnitario, Me.colValorTotal, Me.colConsignatario, Me.colRegimen, Me.colGRUPO_REGIMEN, Me.colREGIMEN_DOCUMENTO, Me.colIS_EXTERNAL_INVENTORY, Me.colTRANSFER_REQUEST_ID, Me.colWAREHOUSE_TO, Me.UiColNumeroDeSerie, Me.UiColLote, Me.UiColFechaExpiracion, Me.UiColVin})
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
        Me.UiGridViewEgresos.FormatConditions.AddRange(New DevExpress.XtraGrid.StyleFormatCondition() {StyleFormatCondition1, StyleFormatCondition2})
        Me.UiGridViewEgresos.GridControl = Me.UiVistaGridEgresos
        Me.UiGridViewEgresos.GroupCount = 1
        Me.UiGridViewEgresos.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TOTAL", Me.colValorTotal, "(Total: SUM={0:#,###,###.00})"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "MATERIAL_ID", Me.colDOC_ID, "(Cantidad registros={0})")})
        Me.UiGridViewEgresos.Name = "UiGridViewEgresos"
        Me.UiGridViewEgresos.OptionsView.ShowAutoFilterRow = true
        Me.UiGridViewEgresos.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.colDOC_ID, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'colDOC_ID
        '
        Me.colDOC_ID.Caption = "Numero Documento"
        Me.colDOC_ID.FieldName = "DOC_ID"
        Me.colDOC_ID.Name = "colDOC_ID"
        Me.colDOC_ID.OptionsColumn.AllowEdit = false
        Me.colDOC_ID.OptionsColumn.AllowFocus = false
        Me.colDOC_ID.Visible = true
        Me.colDOC_ID.VisibleIndex = 0
        '
        'colNUMERO_ORDEN
        '
        Me.colNUMERO_ORDEN.Caption = "Numero Orden"
        Me.colNUMERO_ORDEN.FieldName = "ORDEN"
        Me.colNUMERO_ORDEN.Name = "colNUMERO_ORDEN"
        Me.colNUMERO_ORDEN.OptionsColumn.AllowEdit = false
        Me.colNUMERO_ORDEN.OptionsColumn.AllowFocus = false
        Me.colNUMERO_ORDEN.Visible = true
        Me.colNUMERO_ORDEN.VisibleIndex = 0
        '
        'colCODIGO_POLIZA
        '
        Me.colCODIGO_POLIZA.Caption = "Codigo Poliza"
        Me.colCODIGO_POLIZA.FieldName = "POLIZA"
        Me.colCODIGO_POLIZA.Name = "colCODIGO_POLIZA"
        Me.colCODIGO_POLIZA.OptionsColumn.AllowEdit = false
        Me.colCODIGO_POLIZA.OptionsColumn.AllowFocus = false
        Me.colCODIGO_POLIZA.Visible = true
        Me.colCODIGO_POLIZA.VisibleIndex = 1
        '
        'colCLIENT_CODE
        '
        Me.colCLIENT_CODE.Caption = "Codigo Cliente"
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
        Me.colClientName.FieldName = "CLIENT_NAME"
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
        Me.colMaterial_Code.Visible = true
        Me.colMaterial_Code.VisibleIndex = 5
        '
        'colCantidad
        '
        Me.colCantidad.Caption = "Cantidad"
        Me.colCantidad.FieldName = "CANTIDAD"
        Me.colCantidad.Name = "colCantidad"
        Me.colCantidad.OptionsColumn.AllowEdit = false
        Me.colCantidad.Visible = true
        Me.colCantidad.VisibleIndex = 7
        '
        'colValorUnitario
        '
        Me.colValorUnitario.Caption = "Total Valor"
        Me.colValorUnitario.DisplayFormat.FormatString = "#,###,##0.00"
        Me.colValorUnitario.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colValorUnitario.FieldName = "CUSTOMS_AMOUNT"
        Me.colValorUnitario.Name = "colValorUnitario"
        Me.colValorUnitario.OptionsColumn.AllowEdit = false
        Me.colValorUnitario.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CUSTOMS_AMOUNT", "{0:#,###,###.00}")})
        Me.colValorUnitario.Visible = true
        Me.colValorUnitario.VisibleIndex = 8
        '
        'colValorTotal
        '
        Me.colValorTotal.Caption = "Total General"
        Me.colValorTotal.DisplayFormat.FormatString = "#,###,##0.00"
        Me.colValorTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colValorTotal.FieldName = "IMPUESTO"
        Me.colValorTotal.Name = "colValorTotal"
        Me.colValorTotal.OptionsColumn.AllowEdit = false
        Me.colValorTotal.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "IMPUESTO", "{0:#,###,###.00}")})
        Me.colValorTotal.Visible = true
        Me.colValorTotal.VisibleIndex = 9
        '
        'colConsignatario
        '
        Me.colConsignatario.Caption = "Consignatario"
        Me.colConsignatario.FieldName = "CONSIGNATARIO"
        Me.colConsignatario.Name = "colConsignatario"
        Me.colConsignatario.OptionsColumn.AllowEdit = false
        Me.colConsignatario.Visible = true
        Me.colConsignatario.VisibleIndex = 10
        '
        'colRegimen
        '
        Me.colRegimen.Caption = "Régimen"
        Me.colRegimen.FieldName = "REGIMEN"
        Me.colRegimen.Name = "colRegimen"
        Me.colRegimen.OptionsColumn.AllowEdit = false
        Me.colRegimen.Visible = true
        Me.colRegimen.VisibleIndex = 11
        '
        'colGRUPO_REGIMEN
        '
        Me.colGRUPO_REGIMEN.Caption = "Grupo Régimen"
        Me.colGRUPO_REGIMEN.FieldName = "GRUPO_REGIMEN"
        Me.colGRUPO_REGIMEN.Name = "colGRUPO_REGIMEN"
        Me.colGRUPO_REGIMEN.OptionsColumn.AllowEdit = false
        Me.colGRUPO_REGIMEN.Visible = true
        Me.colGRUPO_REGIMEN.VisibleIndex = 12
        '
        'colREGIMEN_DOCUMENTO
        '
        Me.colREGIMEN_DOCUMENTO.Caption = "Régimen Documento"
        Me.colREGIMEN_DOCUMENTO.FieldName = "REGIMEN_DOCUMENTO"
        Me.colREGIMEN_DOCUMENTO.Name = "colREGIMEN_DOCUMENTO"
        Me.colREGIMEN_DOCUMENTO.OptionsColumn.AllowEdit = false
        Me.colREGIMEN_DOCUMENTO.Visible = true
        Me.colREGIMEN_DOCUMENTO.VisibleIndex = 13
        '
        'colIS_EXTERNAL_INVENTORY
        '
        Me.colIS_EXTERNAL_INVENTORY.Caption = "Inventario Externo"
        Me.colIS_EXTERNAL_INVENTORY.FieldName = "IS_EXTERNAL_INVENTORY"
        Me.colIS_EXTERNAL_INVENTORY.Name = "colIS_EXTERNAL_INVENTORY"
        Me.colIS_EXTERNAL_INVENTORY.OptionsColumn.AllowEdit = false
        Me.colIS_EXTERNAL_INVENTORY.Visible = true
        Me.colIS_EXTERNAL_INVENTORY.VisibleIndex = 14
        '
        'colTRANSFER_REQUEST_ID
        '
        Me.colTRANSFER_REQUEST_ID.Caption = "Número de Solicitud de Traslado"
        Me.colTRANSFER_REQUEST_ID.FieldName = "TRANSFER_REQUEST_ID"
        Me.colTRANSFER_REQUEST_ID.Name = "colTRANSFER_REQUEST_ID"
        Me.colTRANSFER_REQUEST_ID.OptionsColumn.AllowEdit = false
        Me.colTRANSFER_REQUEST_ID.Visible = true
        Me.colTRANSFER_REQUEST_ID.VisibleIndex = 15
        '
        'colWAREHOUSE_TO
        '
        Me.colWAREHOUSE_TO.Caption = "Destino de Traslado"
        Me.colWAREHOUSE_TO.FieldName = "WAREHOUSE_TO"
        Me.colWAREHOUSE_TO.Name = "colWAREHOUSE_TO"
        Me.colWAREHOUSE_TO.OptionsColumn.AllowEdit = false
        Me.colWAREHOUSE_TO.Visible = true
        Me.colWAREHOUSE_TO.VisibleIndex = 16
        '
        'UiColNumeroDeSerie
        '
        Me.UiColNumeroDeSerie.Caption = "Número de Serie"
        Me.UiColNumeroDeSerie.FieldName = "SERIAL"
        Me.UiColNumeroDeSerie.Name = "UiColNumeroDeSerie"
        Me.UiColNumeroDeSerie.OptionsColumn.AllowEdit = false
        Me.UiColNumeroDeSerie.Visible = true
        Me.UiColNumeroDeSerie.VisibleIndex = 17
        '
        'UiColLote
        '
        Me.UiColLote.Caption = "Lote"
        Me.UiColLote.FieldName = "BATCH"
        Me.UiColLote.Name = "UiColLote"
        Me.UiColLote.OptionsColumn.AllowEdit = false
        Me.UiColLote.Visible = true
        Me.UiColLote.VisibleIndex = 18
        '
        'UiColFechaExpiracion
        '
        Me.UiColFechaExpiracion.Caption = "Fecha de Expiración"
        Me.UiColFechaExpiracion.FieldName = "DATE_EXPIRATION"
        Me.UiColFechaExpiracion.Name = "UiColFechaExpiracion"
        Me.UiColFechaExpiracion.OptionsColumn.AllowEdit = false
        Me.UiColFechaExpiracion.Visible = true
        Me.UiColFechaExpiracion.VisibleIndex = 19
        '
        'UiColVin
        '
        Me.UiColVin.Caption = "VIN"
        Me.UiColVin.FieldName = "VIN"
        Me.UiColVin.Name = "UiColVin"
        Me.UiColVin.OptionsColumn.AllowEdit = false
        Me.UiColVin.Visible = true
        Me.UiColVin.VisibleIndex = 20
        '
        'FrmConsultaDeEgreso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1190, 489)
        Me.Controls.Add(Me.UiVistaGridEgresos)
        Me.Controls.Add(Me.UiLabelCliente)
        Me.Controls.Add(Me.UiLabelRegimen)
        Me.Controls.Add(Me.cmbClientes)
        Me.Controls.Add(Me.cmbRegimen)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "FrmConsultaDeEgreso"
        Me.Text = "Reporte Egreso"
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
        CType(Me.cmbClientes.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.GridView3,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.cmbRegimen.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.GridLookUpEdit1View,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.UiVistaGridEgresos,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.UiGridViewEgresos,System.ComponentModel.ISupportInitialize).EndInit
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
    Friend WithEvents UiLabelRegimen As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbClientes As DevExpress.XtraEditors.GridLookUpEdit
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents cmbRegimen As DevExpress.XtraEditors.GridLookUpEdit
    Friend WithEvents GridLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
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
    Friend WithEvents colGRUPO_REGIMEN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colREGIMEN_DOCUMENTO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colIS_EXTERNAL_INVENTORY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTRANSFER_REQUEST_ID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colWAREHOUSE_TO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UiColNumeroDeSerie As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UiColLote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UiColFechaExpiracion As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UiColVin As DevExpress.XtraGrid.Columns.GridColumn
End Class
