<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRectifications
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRectifications))
        Dim StyleFormatCondition1 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Dim StyleFormatCondition2 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Me.barHeader = New DevExpress.XtraBars.Bar()
        Me.Bar1 = New DevExpress.XtraBars.Bar()
        Me.barManagerHeader = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar2 = New DevExpress.XtraBars.Bar()
        Me.UiBotonExpandirVista = New DevExpress.XtraBars.BarButtonItem()
        Me.UiBotonContraerVista = New DevExpress.XtraBars.BarButtonItem()
        Me.UiBotonExportarExcelVista = New DevExpress.XtraBars.BarButtonItem()
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
        Me.UiVistasRectificaciones = New DevExpress.XtraGrid.GridControl()
        Me.UIVistaRectificacion = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colDOC_ID_RECTIFADA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCODIGO_POLIZA_RECTIFADA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNUMERO_ORDEN_RECTIFADA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCOMENTARIO_RECTIFADA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCLASE_POLIZA_RECTIFADA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFECHA_RECTIFICADA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOPERADOR_RECTIFICADA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDOC_ID_RECTIFICACION = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCODIGO_POLIZA_RECTIFICACION = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNUMERO_ORDEN_RECTIFICACION = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCOMENTARIO_RECTIFICACION = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFECHA_RECTIFICACION = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOPERADOR_RECTIFICACION = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPENDIENTE_RECTIFICACION = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCLIENT_CODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCLIENT_NAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UiBotonImprimir = New DevExpress.XtraBars.BarButtonItem()
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
        CType(Me.UiVistasRectificaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UIVistaRectificacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.Bar2.OptionsBar.AllowQuickCustomization = False
        Me.Bar2.OptionsBar.DrawDragBorder = False
        Me.Bar2.OptionsBar.UseWholeRow = True
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
        Me.UiBotonExportarExcelVista.Glyph = CType(resources.GetObject("UiBotonExportarExcelVista.Glyph"), System.Drawing.Image)
        Me.UiBotonExportarExcelVista.Id = 12
        Me.UiBotonExportarExcelVista.LargeGlyph = CType(resources.GetObject("UiBotonExportarExcelVista.LargeGlyph"), System.Drawing.Image)
        Me.UiBotonExportarExcelVista.Name = "UiBotonExportarExcelVista"
        '
        'UIFechaInicio
        '
        Me.UIFechaInicio.Caption = "Fecha Inicio"
        Me.UIFechaInicio.Edit = Me.RepositoryItemDateEdit1
        Me.UIFechaInicio.Glyph = CType(resources.GetObject("UIFechaInicio.Glyph"), System.Drawing.Image)
        Me.UIFechaInicio.Id = 0
        Me.UIFechaInicio.LargeGlyph = CType(resources.GetObject("UIFechaInicio.LargeGlyph"), System.Drawing.Image)
        Me.UIFechaInicio.Name = "UIFechaInicio"
        Me.UIFechaInicio.Width = 100
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
        Me.UiFechaFinal.Glyph = CType(resources.GetObject("UiFechaFinal.Glyph"), System.Drawing.Image)
        Me.UiFechaFinal.Id = 1
        Me.UiFechaFinal.LargeGlyph = CType(resources.GetObject("UiFechaFinal.LargeGlyph"), System.Drawing.Image)
        Me.UiFechaFinal.Name = "UiFechaFinal"
        Me.UiFechaFinal.Width = 100
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
        Me.UiBotonRefrescarVista.Glyph = CType(resources.GetObject("UiBotonRefrescarVista.Glyph"), System.Drawing.Image)
        Me.UiBotonRefrescarVista.Id = 2
        Me.UiBotonRefrescarVista.LargeGlyph = CType(resources.GetObject("UiBotonRefrescarVista.LargeGlyph"), System.Drawing.Image)
        Me.UiBotonRefrescarVista.Name = "UiBotonRefrescarVista"
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(1122, 31)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 546)
        Me.barDockControlBottom.Size = New System.Drawing.Size(1122, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 31)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 515)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(1122, 31)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 515)
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
        'UiVistasRectificaciones
        '
        Me.UiVistasRectificaciones.Cursor = System.Windows.Forms.Cursors.Default
        Me.UiVistasRectificaciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UiVistasRectificaciones.Location = New System.Drawing.Point(0, 31)
        Me.UiVistasRectificaciones.MainView = Me.UIVistaRectificacion
        Me.UiVistasRectificaciones.MenuManager = Me.barManagerHeader
        Me.UiVistasRectificaciones.Name = "UiVistasRectificaciones"
        Me.UiVistasRectificaciones.Size = New System.Drawing.Size(1122, 515)
        Me.UiVistasRectificaciones.TabIndex = 6
        Me.UiVistasRectificaciones.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.UIVistaRectificacion})
        '
        'UIVistaRectificacion
        '
        Me.UIVistaRectificacion.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colDOC_ID_RECTIFADA, Me.colCODIGO_POLIZA_RECTIFADA, Me.colNUMERO_ORDEN_RECTIFADA, Me.colCOMENTARIO_RECTIFADA, Me.colCLASE_POLIZA_RECTIFADA, Me.colFECHA_RECTIFICADA, Me.colOPERADOR_RECTIFICADA, Me.colDOC_ID_RECTIFICACION, Me.colCODIGO_POLIZA_RECTIFICACION, Me.colNUMERO_ORDEN_RECTIFICACION, Me.colCOMENTARIO_RECTIFICACION, Me.colFECHA_RECTIFICACION, Me.colOPERADOR_RECTIFICACION, Me.colPENDIENTE_RECTIFICACION, Me.colCLIENT_CODE, Me.colCLIENT_NAME})
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
        Me.UIVistaRectificacion.FormatConditions.AddRange(New DevExpress.XtraGrid.StyleFormatCondition() {StyleFormatCondition1, StyleFormatCondition2})
        Me.UIVistaRectificacion.GridControl = Me.UiVistasRectificaciones
        Me.UIVistaRectificacion.Name = "UIVistaRectificacion"
        '
        'colDOC_ID_RECTIFADA
        '
        Me.colDOC_ID_RECTIFADA.Caption = "Documento Recitificada"
        Me.colDOC_ID_RECTIFADA.FieldName = "DOC_ID_RECTIFADA"
        Me.colDOC_ID_RECTIFADA.Name = "colDOC_ID_RECTIFADA"
        Me.colDOC_ID_RECTIFADA.OptionsColumn.AllowEdit = False
        Me.colDOC_ID_RECTIFADA.OptionsColumn.AllowFocus = False
        Me.colDOC_ID_RECTIFADA.Visible = True
        Me.colDOC_ID_RECTIFADA.VisibleIndex = 0
        '
        'colCODIGO_POLIZA_RECTIFADA
        '
        Me.colCODIGO_POLIZA_RECTIFADA.Caption = "Poliza Rectificada"
        Me.colCODIGO_POLIZA_RECTIFADA.FieldName = "CODIGO_POLIZA_RECTIFADA"
        Me.colCODIGO_POLIZA_RECTIFADA.Name = "colCODIGO_POLIZA_RECTIFADA"
        Me.colCODIGO_POLIZA_RECTIFADA.OptionsColumn.AllowEdit = False
        Me.colCODIGO_POLIZA_RECTIFADA.Visible = True
        Me.colCODIGO_POLIZA_RECTIFADA.VisibleIndex = 1
        '
        'colNUMERO_ORDEN_RECTIFADA
        '
        Me.colNUMERO_ORDEN_RECTIFADA.Caption = "Numero Orden Rectificada"
        Me.colNUMERO_ORDEN_RECTIFADA.FieldName = "NUMERO_ORDEN_RECTIFADA"
        Me.colNUMERO_ORDEN_RECTIFADA.Name = "colNUMERO_ORDEN_RECTIFADA"
        Me.colNUMERO_ORDEN_RECTIFADA.OptionsColumn.AllowEdit = False
        Me.colNUMERO_ORDEN_RECTIFADA.Visible = True
        Me.colNUMERO_ORDEN_RECTIFADA.VisibleIndex = 2
        '
        'colCOMENTARIO_RECTIFADA
        '
        Me.colCOMENTARIO_RECTIFADA.Caption = "Comentario al Rectificar"
        Me.colCOMENTARIO_RECTIFADA.FieldName = "COMENTARIO_RECTIFADA"
        Me.colCOMENTARIO_RECTIFADA.Name = "colCOMENTARIO_RECTIFADA"
        Me.colCOMENTARIO_RECTIFADA.OptionsColumn.AllowEdit = False
        Me.colCOMENTARIO_RECTIFADA.Visible = True
        Me.colCOMENTARIO_RECTIFADA.VisibleIndex = 3
        '
        'colCLASE_POLIZA_RECTIFADA
        '
        Me.colCLASE_POLIZA_RECTIFADA.Caption = "Clase Poliza"
        Me.colCLASE_POLIZA_RECTIFADA.FieldName = "CLASE_POLIZA_RECTIFADA"
        Me.colCLASE_POLIZA_RECTIFADA.Name = "colCLASE_POLIZA_RECTIFADA"
        Me.colCLASE_POLIZA_RECTIFADA.OptionsColumn.AllowEdit = False
        Me.colCLASE_POLIZA_RECTIFADA.Visible = True
        Me.colCLASE_POLIZA_RECTIFADA.VisibleIndex = 4
        '
        'colFECHA_RECTIFICADA
        '
        Me.colFECHA_RECTIFICADA.Caption = "Fecha al Rectificar"
        Me.colFECHA_RECTIFICADA.FieldName = "FECHA_RECTIFICADA"
        Me.colFECHA_RECTIFICADA.Name = "colFECHA_RECTIFICADA"
        Me.colFECHA_RECTIFICADA.OptionsColumn.AllowEdit = False
        Me.colFECHA_RECTIFICADA.Visible = True
        Me.colFECHA_RECTIFICADA.VisibleIndex = 5
        '
        'colOPERADOR_RECTIFICADA
        '
        Me.colOPERADOR_RECTIFICADA.Caption = "Operador que Rectifico"
        Me.colOPERADOR_RECTIFICADA.FieldName = "OPERADOR_RECTIFICADA"
        Me.colOPERADOR_RECTIFICADA.Name = "colOPERADOR_RECTIFICADA"
        Me.colOPERADOR_RECTIFICADA.OptionsColumn.AllowEdit = False
        Me.colOPERADOR_RECTIFICADA.Visible = True
        Me.colOPERADOR_RECTIFICADA.VisibleIndex = 6
        '
        'colDOC_ID_RECTIFICACION
        '
        Me.colDOC_ID_RECTIFICACION.Caption = "Documento de Recitificacion"
        Me.colDOC_ID_RECTIFICACION.FieldName = "DOC_ID_RECTIFICACION"
        Me.colDOC_ID_RECTIFICACION.Name = "colDOC_ID_RECTIFICACION"
        Me.colDOC_ID_RECTIFICACION.OptionsColumn.AllowEdit = False
        Me.colDOC_ID_RECTIFICACION.Visible = True
        Me.colDOC_ID_RECTIFICACION.VisibleIndex = 7
        '
        'colCODIGO_POLIZA_RECTIFICACION
        '
        Me.colCODIGO_POLIZA_RECTIFICACION.Caption = "Poliza de Rectificacion"
        Me.colCODIGO_POLIZA_RECTIFICACION.FieldName = "CODIGO_POLIZA_RECTIFICACION"
        Me.colCODIGO_POLIZA_RECTIFICACION.Name = "colCODIGO_POLIZA_RECTIFICACION"
        Me.colCODIGO_POLIZA_RECTIFICACION.OptionsColumn.AllowEdit = False
        Me.colCODIGO_POLIZA_RECTIFICACION.Visible = True
        Me.colCODIGO_POLIZA_RECTIFICACION.VisibleIndex = 8
        '
        'colNUMERO_ORDEN_RECTIFICACION
        '
        Me.colNUMERO_ORDEN_RECTIFICACION.Caption = "Numero Orden Rectificacion"
        Me.colNUMERO_ORDEN_RECTIFICACION.FieldName = "NUMERO_ORDEN_RECTIFICACION"
        Me.colNUMERO_ORDEN_RECTIFICACION.Name = "colNUMERO_ORDEN_RECTIFICACION"
        Me.colNUMERO_ORDEN_RECTIFICACION.OptionsColumn.AllowEdit = False
        Me.colNUMERO_ORDEN_RECTIFICACION.Visible = True
        Me.colNUMERO_ORDEN_RECTIFICACION.VisibleIndex = 9
        '
        'colCOMENTARIO_RECTIFICACION
        '
        Me.colCOMENTARIO_RECTIFICACION.Caption = "Comentario de Rectificacion"
        Me.colCOMENTARIO_RECTIFICACION.FieldName = "COMENTARIO_RECTIFICACION"
        Me.colCOMENTARIO_RECTIFICACION.Name = "colCOMENTARIO_RECTIFICACION"
        Me.colCOMENTARIO_RECTIFICACION.OptionsColumn.AllowEdit = False
        Me.colCOMENTARIO_RECTIFICACION.Visible = True
        Me.colCOMENTARIO_RECTIFICACION.VisibleIndex = 10
        '
        'colFECHA_RECTIFICACION
        '
        Me.colFECHA_RECTIFICACION.Caption = "Fecha de Rectificacion"
        Me.colFECHA_RECTIFICACION.FieldName = "FECHA_RECTIFICACION"
        Me.colFECHA_RECTIFICACION.Name = "colFECHA_RECTIFICACION"
        Me.colFECHA_RECTIFICACION.OptionsColumn.AllowEdit = False
        Me.colFECHA_RECTIFICACION.Visible = True
        Me.colFECHA_RECTIFICACION.VisibleIndex = 11
        '
        'colOPERADOR_RECTIFICACION
        '
        Me.colOPERADOR_RECTIFICACION.Caption = "Opedor de Rectificacion"
        Me.colOPERADOR_RECTIFICACION.FieldName = "OPERADOR_RECTIFICACION"
        Me.colOPERADOR_RECTIFICACION.Name = "colOPERADOR_RECTIFICACION"
        Me.colOPERADOR_RECTIFICACION.OptionsColumn.AllowEdit = False
        Me.colOPERADOR_RECTIFICACION.Visible = True
        Me.colOPERADOR_RECTIFICACION.VisibleIndex = 12
        '
        'colPENDIENTE_RECTIFICACION
        '
        Me.colPENDIENTE_RECTIFICACION.Caption = "Estado Poliza Rectificacion"
        Me.colPENDIENTE_RECTIFICACION.FieldName = "PENDIENTE_RECTIFICACION_DESCRIPCION"
        Me.colPENDIENTE_RECTIFICACION.Name = "colPENDIENTE_RECTIFICACION"
        Me.colPENDIENTE_RECTIFICACION.OptionsColumn.AllowEdit = False
        Me.colPENDIENTE_RECTIFICACION.Visible = True
        Me.colPENDIENTE_RECTIFICACION.VisibleIndex = 13
        '
        'colCLIENT_CODE
        '
        Me.colCLIENT_CODE.Caption = "Codigo Cliente"
        Me.colCLIENT_CODE.FieldName = "CLIENT_CODE"
        Me.colCLIENT_CODE.Name = "colCLIENT_CODE"
        Me.colCLIENT_CODE.OptionsColumn.AllowEdit = False
        Me.colCLIENT_CODE.Visible = True
        Me.colCLIENT_CODE.VisibleIndex = 14
        '
        'colCLIENT_NAME
        '
        Me.colCLIENT_NAME.Caption = "Nombre Cliente"
        Me.colCLIENT_NAME.FieldName = "CLIENT_NAME"
        Me.colCLIENT_NAME.Name = "colCLIENT_NAME"
        Me.colCLIENT_NAME.OptionsColumn.AllowEdit = False
        Me.colCLIENT_NAME.Visible = True
        Me.colCLIENT_NAME.VisibleIndex = 15
        '
        'UiBotonImprimir
        '
        Me.UiBotonImprimir.Caption = "Imprimir"
        Me.UiBotonImprimir.Glyph = CType(resources.GetObject("UiBotonImprimir.Glyph"), System.Drawing.Image)
        Me.UiBotonImprimir.Id = 13
        Me.UiBotonImprimir.LargeGlyph = CType(resources.GetObject("UiBotonImprimir.LargeGlyph"), System.Drawing.Image)
        Me.UiBotonImprimir.Name = "UiBotonImprimir"
        '
        'FrmRectifications
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1122, 546)
        Me.Controls.Add(Me.UiVistasRectificaciones)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "FrmRectifications"
        Me.Text = "Rectificaciones"
        CType(Me.barManagerHeader, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit2.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit3.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiVistasRectificaciones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UIVistaRectificacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

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
    Friend WithEvents UiVistasRectificaciones As DevExpress.XtraGrid.GridControl
    Friend WithEvents UIVistaRectificacion As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colDOC_ID_RECTIFADA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCODIGO_POLIZA_RECTIFADA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNUMERO_ORDEN_RECTIFADA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCOMENTARIO_RECTIFADA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCLASE_POLIZA_RECTIFADA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFECHA_RECTIFICADA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOPERADOR_RECTIFICADA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDOC_ID_RECTIFICACION As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCODIGO_POLIZA_RECTIFICACION As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNUMERO_ORDEN_RECTIFICACION As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCOMENTARIO_RECTIFICACION As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFECHA_RECTIFICACION As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOPERADOR_RECTIFICACION As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPENDIENTE_RECTIFICACION As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCLIENT_CODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCLIENT_NAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UiBotonExportarExcelVista As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents UiBotonImprimir As DevExpress.XtraBars.BarButtonItem
End Class
