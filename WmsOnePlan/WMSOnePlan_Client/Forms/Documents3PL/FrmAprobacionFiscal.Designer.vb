<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAprobacionFiscal
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim StyleFormatCondition1 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Dim StyleFormatCondition2 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAprobacionFiscal))
        Me.RepositoryItemTextEdit5 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.tabPolizas = New DevExpress.XtraTab.XtraTabControl()
        Me.tabHeader = New DevExpress.XtraTab.XtraTabPage()
        Me.gridPolizas = New DevExpress.XtraGrid.GridControl()
        Me.gridViewPolizas = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colDOC_ID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNUMERO_ORDEN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCODIGO_POLIZA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCLIENT_CODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCardName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colACUERDO_COMERCIAL_NOMBRE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPOLIZA_INSURANCE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFECHA_DOCUMENTO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LAST_UPDATED = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColHSTATUS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCOMMENTS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPENDIENTE_RECTIFICACION_DESCRIPCION = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCOMENTARIO_RECTIFICACION = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCLASE_POLIZA_RECTIFICACION = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCODIGO_POLIZA_RECTIFICACION = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPENDIENTE_RECTIFICACION = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.barManagerHeader = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barHeader = New DevExpress.XtraBars.Bar()
        Me.btnExpandirHeader = New DevExpress.XtraBars.BarButtonItem()
        Me.barContraerHeader = New DevExpress.XtraBars.BarButtonItem()
        Me.btnPrintHeader = New DevExpress.XtraBars.BarButtonItem()
        Me.dtFechaInicio = New DevExpress.XtraBars.BarEditItem()
        Me.RepositoryItemDateEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.dtFechaFinal = New DevExpress.XtraBars.BarEditItem()
        Me.RepositoryItemDateEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.barBtnRefreshHeader = New DevExpress.XtraBars.BarButtonItem()
        Me.UiBotonRectificar = New DevExpress.XtraBars.BarButtonItem()
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
        Me.tabDet = New DevExpress.XtraTab.XtraTabPage()
        Me.SplitContainerControl2 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.gridLicencias = New DevExpress.XtraGrid.GridControl()
        Me.gridViewLicencias = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colESERIAL_NUMBER = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.collICENSE_iD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMATERIAL_CODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMATERIAL_DESCRIPTION = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.coLQUANTITY_UNITS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colLINEAS_ASOCIADOS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colVIN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.gridLienas = New DevExpress.XtraGrid.GridControl()
        Me.gridViewLineas = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colLINE_NUMBER = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMATERIAL_ID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSKU_DESCRIPTION = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colQTY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBULTOS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTRANS_ASOCIADOS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colnDOC_ID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.gridEnlazados = New DevExpress.XtraGrid.GridControl()
        Me.gridViewEnlazados = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colTRANS_ID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colLICENSE_IDAso = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colEMATERIAL_CODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colEMATERIAL_DESCRIPTION = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colEQTY_TRANS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colLINENO_POLIZA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colESKU_DESCRIPTION = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colEQTY_POLIZA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colEBULTOS_POLIZA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colQtyAso = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAsoDOC_ID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BarDockControl7 = New DevExpress.XtraBars.BarDockControl()
        Me.barManagerDetEnlazados = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar2 = New DevExpress.XtraBars.Bar()
        Me.btnBorrorAso = New DevExpress.XtraBars.BarButtonItem()
        Me.btnExpandirAsociados = New DevExpress.XtraBars.BarButtonItem()
        Me.btnContraerAsociados = New DevExpress.XtraBars.BarButtonItem()
        Me.barConfirAsociacion = New DevExpress.XtraBars.BarButtonItem()
        Me.btnCancelarAso = New DevExpress.XtraBars.BarButtonItem()
        Me.BarDockControl5 = New DevExpress.XtraBars.BarDockControl()
        Me.BarDockControl6 = New DevExpress.XtraBars.BarDockControl()
        Me.BarDockControl8 = New DevExpress.XtraBars.BarDockControl()
        Me.BarEditItem3 = New DevExpress.XtraBars.BarEditItem()
        Me.RepositoryItemFontEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemFontEdit()
        Me.BarEditItem4 = New DevExpress.XtraBars.BarEditItem()
        Me.RepositoryItemImageEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemImageEdit()
        Me.txtComentario2 = New DevExpress.XtraBars.BarEditItem()
        Me.RepositoryItemMemoEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.BarDockControl3 = New DevExpress.XtraBars.BarDockControl()
        Me.barManagerDet = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar1 = New DevExpress.XtraBars.Bar()
        Me.btnEnlazar = New DevExpress.XtraBars.BarButtonItem()
        Me.txtComentario3 = New DevExpress.XtraBars.BarEditItem()
        Me.RepositoryItemMemoEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.BarDockControl1 = New DevExpress.XtraBars.BarDockControl()
        Me.BarDockControl2 = New DevExpress.XtraBars.BarDockControl()
        Me.BarDockControl4 = New DevExpress.XtraBars.BarDockControl()
        Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarEditItem8 = New DevExpress.XtraBars.BarEditItem()
        Me.RepositoryItemMemoExEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit()
        Me.txtComentario = New DevExpress.XtraBars.BarEditItem()
        Me.RepositoryItemMemoEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        CType(Me.RepositoryItemTextEdit5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tabPolizas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPolizas.SuspendLayout()
        Me.tabHeader.SuspendLayout()
        CType(Me.gridPolizas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridViewPolizas, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.tabDet.SuspendLayout()
        CType(Me.SplitContainerControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl2.SuspendLayout()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.gridLicencias, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridViewLicencias, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridLienas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridViewLineas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridEnlazados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridViewEnlazados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.barManagerDetEnlazados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemFontEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemImageEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.barManagerDet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoEdit3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoExEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RepositoryItemTextEdit5
        '
        Me.RepositoryItemTextEdit5.AutoHeight = False
        Me.RepositoryItemTextEdit5.Name = "RepositoryItemTextEdit5"
        '
        'tabPolizas
        '
        Me.tabPolizas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabPolizas.Location = New System.Drawing.Point(0, 0)
        Me.tabPolizas.Margin = New System.Windows.Forms.Padding(6)
        Me.tabPolizas.Name = "tabPolizas"
        Me.tabPolizas.SelectedTabPage = Me.tabHeader
        Me.tabPolizas.Size = New System.Drawing.Size(2428, 1135)
        Me.tabPolizas.TabIndex = 0
        Me.tabPolizas.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.tabHeader, Me.tabDet})
        '
        'tabHeader
        '
        Me.tabHeader.Controls.Add(Me.gridPolizas)
        Me.tabHeader.Controls.Add(Me.barDockControlLeft)
        Me.tabHeader.Controls.Add(Me.barDockControlRight)
        Me.tabHeader.Controls.Add(Me.barDockControlBottom)
        Me.tabHeader.Controls.Add(Me.barDockControlTop)
        Me.tabHeader.Margin = New System.Windows.Forms.Padding(6)
        Me.tabHeader.Name = "tabHeader"
        Me.tabHeader.Size = New System.Drawing.Size(2424, 1086)
        Me.tabHeader.Text = "Polizas"
        '
        'gridPolizas
        '
        Me.gridPolizas.Cursor = System.Windows.Forms.Cursors.Default
        Me.gridPolizas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridPolizas.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(6)
        Me.gridPolizas.Location = New System.Drawing.Point(0, 46)
        Me.gridPolizas.MainView = Me.gridViewPolizas
        Me.gridPolizas.Margin = New System.Windows.Forms.Padding(6)
        Me.gridPolizas.MenuManager = Me.barManagerHeader
        Me.gridPolizas.Name = "gridPolizas"
        Me.gridPolizas.Size = New System.Drawing.Size(2424, 1040)
        Me.gridPolizas.TabIndex = 5
        Me.gridPolizas.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridViewPolizas})
        '
        'gridViewPolizas
        '
        Me.gridViewPolizas.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colDOC_ID, Me.colNUMERO_ORDEN, Me.colCODIGO_POLIZA, Me.colCLIENT_CODE, Me.colCardName, Me.colACUERDO_COMERCIAL_NOMBRE, Me.colPOLIZA_INSURANCE, Me.colFECHA_DOCUMENTO, Me.LAST_UPDATED, Me.ColHSTATUS, Me.colCOMMENTS, Me.colPENDIENTE_RECTIFICACION_DESCRIPCION, Me.colCOMENTARIO_RECTIFICACION, Me.colCLASE_POLIZA_RECTIFICACION, Me.colCODIGO_POLIZA_RECTIFICACION, Me.colPENDIENTE_RECTIFICACION})
        Me.gridViewPolizas.DetailHeight = 673
        Me.gridViewPolizas.FixedLineWidth = 4
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
        Me.gridViewPolizas.FormatConditions.AddRange(New DevExpress.XtraGrid.StyleFormatCondition() {StyleFormatCondition1, StyleFormatCondition2})
        Me.gridViewPolizas.GridControl = Me.gridPolizas
        Me.gridViewPolizas.Name = "gridViewPolizas"
        Me.gridViewPolizas.OptionsView.ShowAutoFilterRow = True
        '
        'colDOC_ID
        '
        Me.colDOC_ID.Caption = "Numero Documento"
        Me.colDOC_ID.FieldName = "DOC_ID"
        Me.colDOC_ID.MinWidth = 40
        Me.colDOC_ID.Name = "colDOC_ID"
        Me.colDOC_ID.OptionsColumn.AllowEdit = False
        Me.colDOC_ID.OptionsColumn.AllowFocus = False
        Me.colDOC_ID.Visible = True
        Me.colDOC_ID.VisibleIndex = 0
        Me.colDOC_ID.Width = 150
        '
        'colNUMERO_ORDEN
        '
        Me.colNUMERO_ORDEN.Caption = "Numero Orden"
        Me.colNUMERO_ORDEN.FieldName = "NUMERO_ORDEN"
        Me.colNUMERO_ORDEN.MinWidth = 40
        Me.colNUMERO_ORDEN.Name = "colNUMERO_ORDEN"
        Me.colNUMERO_ORDEN.OptionsColumn.AllowEdit = False
        Me.colNUMERO_ORDEN.OptionsColumn.AllowFocus = False
        Me.colNUMERO_ORDEN.Visible = True
        Me.colNUMERO_ORDEN.VisibleIndex = 1
        Me.colNUMERO_ORDEN.Width = 150
        '
        'colCODIGO_POLIZA
        '
        Me.colCODIGO_POLIZA.Caption = "Codigo Poliza"
        Me.colCODIGO_POLIZA.FieldName = "CODIGO_POLIZA"
        Me.colCODIGO_POLIZA.MinWidth = 40
        Me.colCODIGO_POLIZA.Name = "colCODIGO_POLIZA"
        Me.colCODIGO_POLIZA.OptionsColumn.AllowEdit = False
        Me.colCODIGO_POLIZA.OptionsColumn.AllowFocus = False
        Me.colCODIGO_POLIZA.Visible = True
        Me.colCODIGO_POLIZA.VisibleIndex = 2
        Me.colCODIGO_POLIZA.Width = 150
        '
        'colCLIENT_CODE
        '
        Me.colCLIENT_CODE.Caption = "Codigo Cliente"
        Me.colCLIENT_CODE.FieldName = "CLIENT_CODE"
        Me.colCLIENT_CODE.MinWidth = 40
        Me.colCLIENT_CODE.Name = "colCLIENT_CODE"
        Me.colCLIENT_CODE.OptionsColumn.AllowEdit = False
        Me.colCLIENT_CODE.OptionsColumn.AllowFocus = False
        Me.colCLIENT_CODE.Visible = True
        Me.colCLIENT_CODE.VisibleIndex = 3
        Me.colCLIENT_CODE.Width = 150
        '
        'colCardName
        '
        Me.colCardName.Caption = "Nombre Cliente"
        Me.colCardName.FieldName = "CardName"
        Me.colCardName.MinWidth = 40
        Me.colCardName.Name = "colCardName"
        Me.colCardName.OptionsColumn.AllowEdit = False
        Me.colCardName.OptionsColumn.AllowFocus = False
        Me.colCardName.Visible = True
        Me.colCardName.VisibleIndex = 4
        Me.colCardName.Width = 150
        '
        'colACUERDO_COMERCIAL_NOMBRE
        '
        Me.colACUERDO_COMERCIAL_NOMBRE.Caption = "Acuerdo Comercial"
        Me.colACUERDO_COMERCIAL_NOMBRE.FieldName = "ACUERDO_COMERCIAL_NOMBRE"
        Me.colACUERDO_COMERCIAL_NOMBRE.MinWidth = 40
        Me.colACUERDO_COMERCIAL_NOMBRE.Name = "colACUERDO_COMERCIAL_NOMBRE"
        Me.colACUERDO_COMERCIAL_NOMBRE.OptionsColumn.AllowEdit = False
        Me.colACUERDO_COMERCIAL_NOMBRE.OptionsColumn.AllowFocus = False
        Me.colACUERDO_COMERCIAL_NOMBRE.Visible = True
        Me.colACUERDO_COMERCIAL_NOMBRE.VisibleIndex = 5
        Me.colACUERDO_COMERCIAL_NOMBRE.Width = 150
        '
        'colPOLIZA_INSURANCE
        '
        Me.colPOLIZA_INSURANCE.Caption = "Poliza Seguro"
        Me.colPOLIZA_INSURANCE.FieldName = "POLIZA_INSURANCE"
        Me.colPOLIZA_INSURANCE.MinWidth = 40
        Me.colPOLIZA_INSURANCE.Name = "colPOLIZA_INSURANCE"
        Me.colPOLIZA_INSURANCE.OptionsColumn.AllowEdit = False
        Me.colPOLIZA_INSURANCE.OptionsColumn.AllowFocus = False
        Me.colPOLIZA_INSURANCE.Visible = True
        Me.colPOLIZA_INSURANCE.VisibleIndex = 6
        Me.colPOLIZA_INSURANCE.Width = 150
        '
        'colFECHA_DOCUMENTO
        '
        Me.colFECHA_DOCUMENTO.Caption = "Fecha Documento"
        Me.colFECHA_DOCUMENTO.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.colFECHA_DOCUMENTO.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.colFECHA_DOCUMENTO.FieldName = "FECHA_DOCUMENTO"
        Me.colFECHA_DOCUMENTO.MinWidth = 40
        Me.colFECHA_DOCUMENTO.Name = "colFECHA_DOCUMENTO"
        Me.colFECHA_DOCUMENTO.OptionsColumn.AllowEdit = False
        Me.colFECHA_DOCUMENTO.OptionsColumn.AllowFocus = False
        Me.colFECHA_DOCUMENTO.Visible = True
        Me.colFECHA_DOCUMENTO.VisibleIndex = 7
        Me.colFECHA_DOCUMENTO.Width = 150
        '
        'LAST_UPDATED
        '
        Me.LAST_UPDATED.Caption = "Fecha Creacion"
        Me.LAST_UPDATED.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.LAST_UPDATED.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.LAST_UPDATED.FieldName = "LAST_UPDATED"
        Me.LAST_UPDATED.MinWidth = 40
        Me.LAST_UPDATED.Name = "LAST_UPDATED"
        Me.LAST_UPDATED.OptionsColumn.AllowEdit = False
        Me.LAST_UPDATED.OptionsColumn.AllowFocus = False
        Me.LAST_UPDATED.Visible = True
        Me.LAST_UPDATED.VisibleIndex = 8
        Me.LAST_UPDATED.Width = 150
        '
        'ColHSTATUS
        '
        Me.ColHSTATUS.Caption = "Estado"
        Me.ColHSTATUS.FieldName = "STATUS"
        Me.ColHSTATUS.MinWidth = 40
        Me.ColHSTATUS.Name = "ColHSTATUS"
        Me.ColHSTATUS.OptionsColumn.AllowEdit = False
        Me.ColHSTATUS.OptionsColumn.AllowFocus = False
        Me.ColHSTATUS.Visible = True
        Me.ColHSTATUS.VisibleIndex = 9
        Me.ColHSTATUS.Width = 150
        '
        'colCOMMENTS
        '
        Me.colCOMMENTS.Caption = "Comentarios"
        Me.colCOMMENTS.FieldName = "COMMENTS"
        Me.colCOMMENTS.MinWidth = 40
        Me.colCOMMENTS.Name = "colCOMMENTS"
        Me.colCOMMENTS.OptionsColumn.AllowEdit = False
        Me.colCOMMENTS.Visible = True
        Me.colCOMMENTS.VisibleIndex = 10
        Me.colCOMMENTS.Width = 150
        '
        'colPENDIENTE_RECTIFICACION_DESCRIPCION
        '
        Me.colPENDIENTE_RECTIFICACION_DESCRIPCION.Caption = "Pendiente de Rectificacion"
        Me.colPENDIENTE_RECTIFICACION_DESCRIPCION.FieldName = "PENDIENTE_RECTIFICACION_DESCRIPCION"
        Me.colPENDIENTE_RECTIFICACION_DESCRIPCION.MinWidth = 40
        Me.colPENDIENTE_RECTIFICACION_DESCRIPCION.Name = "colPENDIENTE_RECTIFICACION_DESCRIPCION"
        Me.colPENDIENTE_RECTIFICACION_DESCRIPCION.OptionsColumn.AllowEdit = False
        Me.colPENDIENTE_RECTIFICACION_DESCRIPCION.Visible = True
        Me.colPENDIENTE_RECTIFICACION_DESCRIPCION.VisibleIndex = 11
        Me.colPENDIENTE_RECTIFICACION_DESCRIPCION.Width = 150
        '
        'colCOMENTARIO_RECTIFICACION
        '
        Me.colCOMENTARIO_RECTIFICACION.Caption = "Comentario Pendiente de Rectificar"
        Me.colCOMENTARIO_RECTIFICACION.FieldName = "COMENTARIO_RECTIFICADO"
        Me.colCOMENTARIO_RECTIFICACION.MinWidth = 40
        Me.colCOMENTARIO_RECTIFICACION.Name = "colCOMENTARIO_RECTIFICACION"
        Me.colCOMENTARIO_RECTIFICACION.OptionsColumn.AllowEdit = False
        Me.colCOMENTARIO_RECTIFICACION.Visible = True
        Me.colCOMENTARIO_RECTIFICACION.VisibleIndex = 12
        Me.colCOMENTARIO_RECTIFICACION.Width = 150
        '
        'colCLASE_POLIZA_RECTIFICACION
        '
        Me.colCLASE_POLIZA_RECTIFICACION.Caption = "Clase de Poliza"
        Me.colCLASE_POLIZA_RECTIFICACION.FieldName = "CLASE_POLIZA_RECTIFICACION"
        Me.colCLASE_POLIZA_RECTIFICACION.MinWidth = 40
        Me.colCLASE_POLIZA_RECTIFICACION.Name = "colCLASE_POLIZA_RECTIFICACION"
        Me.colCLASE_POLIZA_RECTIFICACION.OptionsColumn.AllowEdit = False
        Me.colCLASE_POLIZA_RECTIFICACION.Visible = True
        Me.colCLASE_POLIZA_RECTIFICACION.VisibleIndex = 13
        Me.colCLASE_POLIZA_RECTIFICACION.Width = 150
        '
        'colCODIGO_POLIZA_RECTIFICACION
        '
        Me.colCODIGO_POLIZA_RECTIFICACION.Caption = "Poliza de Rectificacion"
        Me.colCODIGO_POLIZA_RECTIFICACION.FieldName = "CODIGO_POLIZA_RECTIFICACION"
        Me.colCODIGO_POLIZA_RECTIFICACION.MinWidth = 40
        Me.colCODIGO_POLIZA_RECTIFICACION.Name = "colCODIGO_POLIZA_RECTIFICACION"
        Me.colCODIGO_POLIZA_RECTIFICACION.OptionsColumn.AllowEdit = False
        Me.colCODIGO_POLIZA_RECTIFICACION.Visible = True
        Me.colCODIGO_POLIZA_RECTIFICACION.VisibleIndex = 14
        Me.colCODIGO_POLIZA_RECTIFICACION.Width = 150
        '
        'colPENDIENTE_RECTIFICACION
        '
        Me.colPENDIENTE_RECTIFICACION.Caption = "PENDIENTE_RECTIFICACION"
        Me.colPENDIENTE_RECTIFICACION.FieldName = "PENDIENTE_RECTIFICACION"
        Me.colPENDIENTE_RECTIFICACION.MinWidth = 40
        Me.colPENDIENTE_RECTIFICACION.Name = "colPENDIENTE_RECTIFICACION"
        Me.colPENDIENTE_RECTIFICACION.OptionsColumn.AllowEdit = False
        Me.colPENDIENTE_RECTIFICACION.OptionsColumn.ShowInCustomizationForm = False
        Me.colPENDIENTE_RECTIFICACION.Width = 150
        '
        'barManagerHeader
        '
        Me.barManagerHeader.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.barHeader})
        Me.barManagerHeader.DockControls.Add(Me.barDockControlTop)
        Me.barManagerHeader.DockControls.Add(Me.barDockControlBottom)
        Me.barManagerHeader.DockControls.Add(Me.barDockControlLeft)
        Me.barManagerHeader.DockControls.Add(Me.barDockControlRight)
        Me.barManagerHeader.Form = Me.tabHeader
        Me.barManagerHeader.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.dtFechaInicio, Me.dtFechaFinal, Me.barBtnRefreshHeader, Me.BarEditItem5, Me.BarEditItem6, Me.BarEditItem1, Me.BarEditItem2, Me.BarEditItem7, Me.btnExpandirHeader, Me.barContraerHeader, Me.btnPrintHeader, Me.UiBotonRectificar})
        Me.barManagerHeader.MaxItemId = 12
        Me.barManagerHeader.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemDateEdit1, Me.RepositoryItemDateEdit2, Me.RepositoryItemTextEdit1, Me.RepositoryItemTextEdit2, Me.RepositoryItemDateEdit3, Me.RepositoryItemTextEdit3})
        '
        'barHeader
        '
        Me.barHeader.BarName = "Herramientas"
        Me.barHeader.DockCol = 0
        Me.barHeader.DockRow = 0
        Me.barHeader.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.barHeader.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.btnExpandirHeader, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.barContraerHeader, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.btnPrintHeader, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.dtFechaInicio, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.dtFechaFinal, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.barBtnRefreshHeader, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.UiBotonRectificar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)})
        Me.barHeader.OptionsBar.AllowQuickCustomization = False
        Me.barHeader.OptionsBar.DrawDragBorder = False
        Me.barHeader.OptionsBar.UseWholeRow = True
        Me.barHeader.Text = "Herramientas"
        '
        'btnExpandirHeader
        '
        Me.btnExpandirHeader.Caption = "Expandir"
        Me.btnExpandirHeader.Id = 8
        Me.btnExpandirHeader.ImageOptions.Image = Global.WMSOnePlan_Client.My.Resources.Resources.linespacing_16x16
        Me.btnExpandirHeader.ImageOptions.LargeImage = Global.WMSOnePlan_Client.My.Resources.Resources.linespacing_32x32
        Me.btnExpandirHeader.Name = "btnExpandirHeader"
        '
        'barContraerHeader
        '
        Me.barContraerHeader.Caption = "Contraer"
        Me.barContraerHeader.Id = 9
        Me.barContraerHeader.ImageOptions.Image = Global.WMSOnePlan_Client.My.Resources.Resources.linespacing2_16x16
        Me.barContraerHeader.ImageOptions.LargeImage = Global.WMSOnePlan_Client.My.Resources.Resources.linespacing2_32x32
        Me.barContraerHeader.Name = "barContraerHeader"
        '
        'btnPrintHeader
        '
        Me.btnPrintHeader.Caption = "Print"
        Me.btnPrintHeader.Id = 10
        Me.btnPrintHeader.ImageOptions.Image = Global.WMSOnePlan_Client.My.Resources.Resources.print_16x16
        Me.btnPrintHeader.ImageOptions.LargeImage = Global.WMSOnePlan_Client.My.Resources.Resources.print_32x32
        Me.btnPrintHeader.Name = "btnPrintHeader"
        '
        'dtFechaInicio
        '
        Me.dtFechaInicio.Caption = "Fecha Inicio"
        Me.dtFechaInicio.Edit = Me.RepositoryItemDateEdit1
        Me.dtFechaInicio.EditWidth = 100
        Me.dtFechaInicio.Id = 0
        Me.dtFechaInicio.ImageOptions.Image = CType(resources.GetObject("dtFechaInicio.ImageOptions.Image"), System.Drawing.Image)
        Me.dtFechaInicio.ImageOptions.LargeImage = CType(resources.GetObject("dtFechaInicio.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.dtFechaInicio.Name = "dtFechaInicio"
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
        'dtFechaFinal
        '
        Me.dtFechaFinal.Caption = "Fecha Final"
        Me.dtFechaFinal.Edit = Me.RepositoryItemDateEdit2
        Me.dtFechaFinal.EditWidth = 100
        Me.dtFechaFinal.Id = 1
        Me.dtFechaFinal.ImageOptions.Image = CType(resources.GetObject("dtFechaFinal.ImageOptions.Image"), System.Drawing.Image)
        Me.dtFechaFinal.ImageOptions.LargeImage = CType(resources.GetObject("dtFechaFinal.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.dtFechaFinal.Name = "dtFechaFinal"
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
        'barBtnRefreshHeader
        '
        Me.barBtnRefreshHeader.Caption = "Refresh"
        Me.barBtnRefreshHeader.Id = 2
        Me.barBtnRefreshHeader.ImageOptions.Image = CType(resources.GetObject("barBtnRefreshHeader.ImageOptions.Image"), System.Drawing.Image)
        Me.barBtnRefreshHeader.ImageOptions.LargeImage = CType(resources.GetObject("barBtnRefreshHeader.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.barBtnRefreshHeader.Name = "barBtnRefreshHeader"
        '
        'UiBotonRectificar
        '
        Me.UiBotonRectificar.Caption = "Rectificar"
        Me.UiBotonRectificar.Id = 11
        Me.UiBotonRectificar.ImageOptions.Image = CType(resources.GetObject("UiBotonRectificar.ImageOptions.Image"), System.Drawing.Image)
        Me.UiBotonRectificar.ImageOptions.LargeImage = CType(resources.GetObject("UiBotonRectificar.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.UiBotonRectificar.Name = "UiBotonRectificar"
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Manager = Me.barManagerHeader
        Me.barDockControlTop.Margin = New System.Windows.Forms.Padding(6)
        Me.barDockControlTop.Size = New System.Drawing.Size(2424, 46)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 1086)
        Me.barDockControlBottom.Manager = Me.barManagerHeader
        Me.barDockControlBottom.Margin = New System.Windows.Forms.Padding(6)
        Me.barDockControlBottom.Size = New System.Drawing.Size(2424, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 46)
        Me.barDockControlLeft.Manager = Me.barManagerHeader
        Me.barDockControlLeft.Margin = New System.Windows.Forms.Padding(6)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 1040)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(2424, 46)
        Me.barDockControlRight.Manager = Me.barManagerHeader
        Me.barDockControlRight.Margin = New System.Windows.Forms.Padding(6)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 1040)
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
        Me.BarEditItem1.Edit = Me.RepositoryItemTextEdit5
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
        'tabDet
        '
        Me.tabDet.Controls.Add(Me.SplitContainerControl2)
        Me.tabDet.Controls.Add(Me.BarDockControl3)
        Me.tabDet.Controls.Add(Me.BarDockControl4)
        Me.tabDet.Controls.Add(Me.BarDockControl2)
        Me.tabDet.Controls.Add(Me.BarDockControl1)
        Me.tabDet.Margin = New System.Windows.Forms.Padding(6)
        Me.tabDet.Name = "tabDet"
        Me.tabDet.Size = New System.Drawing.Size(2424, 1086)
        Me.tabDet.Text = "Cuadre"
        '
        'SplitContainerControl2
        '
        Me.SplitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl2.Horizontal = False
        Me.SplitContainerControl2.Location = New System.Drawing.Point(0, 46)
        Me.SplitContainerControl2.Margin = New System.Windows.Forms.Padding(6)
        Me.SplitContainerControl2.Name = "SplitContainerControl2"
        Me.SplitContainerControl2.Panel1.Controls.Add(Me.SplitContainerControl1)
        Me.SplitContainerControl2.Panel1.Text = "Panel1"
        Me.SplitContainerControl2.Panel2.Controls.Add(Me.LabelControl3)
        Me.SplitContainerControl2.Panel2.Controls.Add(Me.gridEnlazados)
        Me.SplitContainerControl2.Panel2.Controls.Add(Me.BarDockControl7)
        Me.SplitContainerControl2.Panel2.Controls.Add(Me.BarDockControl8)
        Me.SplitContainerControl2.Panel2.Controls.Add(Me.BarDockControl6)
        Me.SplitContainerControl2.Panel2.Controls.Add(Me.BarDockControl5)
        Me.SplitContainerControl2.Panel2.Text = "Panel2"
        Me.SplitContainerControl2.Size = New System.Drawing.Size(2424, 1040)
        Me.SplitContainerControl2.SplitterPosition = 538
        Me.SplitContainerControl2.TabIndex = 6
        Me.SplitContainerControl2.Text = "SplitContainerControl2"
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl1.Margin = New System.Windows.Forms.Padding(6)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.LabelControl1)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.gridLicencias)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.LabelControl2)
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.gridLienas)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(2424, 538)
        Me.SplitContainerControl1.SplitterPosition = 1414
        Me.SplitContainerControl1.TabIndex = 0
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(6, 12)
        Me.LabelControl1.Margin = New System.Windows.Forms.Padding(6)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(131, 25)
        Me.LabelControl1.TabIndex = 1
        Me.LabelControl1.Text = "Transacciones"
        '
        'gridLicencias
        '
        Me.gridLicencias.AllowDrop = True
        Me.gridLicencias.Cursor = System.Windows.Forms.Cursors.Default
        Me.gridLicencias.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridLicencias.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(6)
        Me.gridLicencias.Location = New System.Drawing.Point(0, 0)
        Me.gridLicencias.MainView = Me.gridViewLicencias
        Me.gridLicencias.Margin = New System.Windows.Forms.Padding(6)
        Me.gridLicencias.MenuManager = Me.barManagerHeader
        Me.gridLicencias.Name = "gridLicencias"
        Me.gridLicencias.Size = New System.Drawing.Size(1414, 538)
        Me.gridLicencias.TabIndex = 0
        Me.gridLicencias.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridViewLicencias})
        '
        'gridViewLicencias
        '
        Me.gridViewLicencias.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colESERIAL_NUMBER, Me.collICENSE_iD, Me.colMATERIAL_CODE, Me.colMATERIAL_DESCRIPTION, Me.coLQUANTITY_UNITS, Me.colLINEAS_ASOCIADOS, Me.colVIN})
        Me.gridViewLicencias.DetailHeight = 673
        Me.gridViewLicencias.FixedLineWidth = 4
        Me.gridViewLicencias.GridControl = Me.gridLicencias
        Me.gridViewLicencias.Name = "gridViewLicencias"
        Me.gridViewLicencias.OptionsBehavior.Editable = False
        Me.gridViewLicencias.OptionsSelection.MultiSelect = True
        '
        'colESERIAL_NUMBER
        '
        Me.colESERIAL_NUMBER.Caption = "Transaccion"
        Me.colESERIAL_NUMBER.FieldName = "SERIAL_NUMBER"
        Me.colESERIAL_NUMBER.MinWidth = 40
        Me.colESERIAL_NUMBER.Name = "colESERIAL_NUMBER"
        Me.colESERIAL_NUMBER.OptionsColumn.AllowEdit = False
        Me.colESERIAL_NUMBER.OptionsColumn.AllowFocus = False
        Me.colESERIAL_NUMBER.Visible = True
        Me.colESERIAL_NUMBER.VisibleIndex = 0
        Me.colESERIAL_NUMBER.Width = 150
        '
        'collICENSE_iD
        '
        Me.collICENSE_iD.Caption = "Licencia"
        Me.collICENSE_iD.FieldName = "LICENSE_ID"
        Me.collICENSE_iD.MinWidth = 40
        Me.collICENSE_iD.Name = "collICENSE_iD"
        Me.collICENSE_iD.OptionsColumn.AllowEdit = False
        Me.collICENSE_iD.OptionsColumn.AllowFocus = False
        Me.collICENSE_iD.Visible = True
        Me.collICENSE_iD.VisibleIndex = 1
        Me.collICENSE_iD.Width = 150
        '
        'colMATERIAL_CODE
        '
        Me.colMATERIAL_CODE.Caption = "Codigo Material"
        Me.colMATERIAL_CODE.FieldName = "MATERIAL_CODE"
        Me.colMATERIAL_CODE.MinWidth = 40
        Me.colMATERIAL_CODE.Name = "colMATERIAL_CODE"
        Me.colMATERIAL_CODE.OptionsColumn.AllowEdit = False
        Me.colMATERIAL_CODE.OptionsColumn.AllowFocus = False
        Me.colMATERIAL_CODE.Visible = True
        Me.colMATERIAL_CODE.VisibleIndex = 2
        Me.colMATERIAL_CODE.Width = 150
        '
        'colMATERIAL_DESCRIPTION
        '
        Me.colMATERIAL_DESCRIPTION.Caption = "Nombre Material"
        Me.colMATERIAL_DESCRIPTION.FieldName = "MATERIAL_DESCRIPTION"
        Me.colMATERIAL_DESCRIPTION.MinWidth = 40
        Me.colMATERIAL_DESCRIPTION.Name = "colMATERIAL_DESCRIPTION"
        Me.colMATERIAL_DESCRIPTION.OptionsColumn.AllowEdit = False
        Me.colMATERIAL_DESCRIPTION.OptionsColumn.AllowFocus = False
        Me.colMATERIAL_DESCRIPTION.Visible = True
        Me.colMATERIAL_DESCRIPTION.VisibleIndex = 3
        Me.colMATERIAL_DESCRIPTION.Width = 150
        '
        'coLQUANTITY_UNITS
        '
        Me.coLQUANTITY_UNITS.Caption = "Cantidad"
        Me.coLQUANTITY_UNITS.DisplayFormat.FormatString = "#,##0.0000"
        Me.coLQUANTITY_UNITS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.coLQUANTITY_UNITS.FieldName = "QUANTITY_UNITS"
        Me.coLQUANTITY_UNITS.MinWidth = 40
        Me.coLQUANTITY_UNITS.Name = "coLQUANTITY_UNITS"
        Me.coLQUANTITY_UNITS.OptionsColumn.AllowEdit = False
        Me.coLQUANTITY_UNITS.OptionsColumn.AllowFocus = False
        Me.coLQUANTITY_UNITS.Visible = True
        Me.coLQUANTITY_UNITS.VisibleIndex = 4
        Me.coLQUANTITY_UNITS.Width = 150
        '
        'colLINEAS_ASOCIADOS
        '
        Me.colLINEAS_ASOCIADOS.Caption = "Lineas Asociados"
        Me.colLINEAS_ASOCIADOS.FieldName = "LINEAS_ASOCIADOS"
        Me.colLINEAS_ASOCIADOS.MinWidth = 40
        Me.colLINEAS_ASOCIADOS.Name = "colLINEAS_ASOCIADOS"
        Me.colLINEAS_ASOCIADOS.OptionsColumn.AllowEdit = False
        Me.colLINEAS_ASOCIADOS.OptionsColumn.AllowFocus = False
        Me.colLINEAS_ASOCIADOS.Visible = True
        Me.colLINEAS_ASOCIADOS.VisibleIndex = 5
        Me.colLINEAS_ASOCIADOS.Width = 150
        '
        'colVIN
        '
        Me.colVIN.Caption = "VIN"
        Me.colVIN.FieldName = "VIN"
        Me.colVIN.MinWidth = 40
        Me.colVIN.Name = "colVIN"
        Me.colVIN.OptionsColumn.AllowEdit = False
        Me.colVIN.Visible = True
        Me.colVIN.VisibleIndex = 6
        Me.colVIN.Width = 150
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(0, 12)
        Me.LabelControl2.Margin = New System.Windows.Forms.Padding(6)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(58, 25)
        Me.LabelControl2.TabIndex = 2
        Me.LabelControl2.Text = "Lineas"
        '
        'gridLienas
        '
        Me.gridLienas.AllowDrop = True
        Me.gridLienas.Cursor = System.Windows.Forms.Cursors.Default
        Me.gridLienas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridLienas.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(6)
        Me.gridLienas.Location = New System.Drawing.Point(0, 0)
        Me.gridLienas.MainView = Me.gridViewLineas
        Me.gridLienas.Margin = New System.Windows.Forms.Padding(6)
        Me.gridLienas.MenuManager = Me.barManagerHeader
        Me.gridLienas.Name = "gridLienas"
        Me.gridLienas.Size = New System.Drawing.Size(990, 538)
        Me.gridLienas.TabIndex = 0
        Me.gridLienas.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridViewLineas})
        '
        'gridViewLineas
        '
        Me.gridViewLineas.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colLINE_NUMBER, Me.colMATERIAL_ID, Me.colSKU_DESCRIPTION, Me.colQTY, Me.colBULTOS, Me.colTRANS_ASOCIADOS, Me.colnDOC_ID})
        Me.gridViewLineas.DetailHeight = 673
        Me.gridViewLineas.FixedLineWidth = 4
        Me.gridViewLineas.GridControl = Me.gridLienas
        Me.gridViewLineas.Name = "gridViewLineas"
        Me.gridViewLineas.OptionsSelection.MultiSelect = True
        '
        'colLINE_NUMBER
        '
        Me.colLINE_NUMBER.Caption = "Linea"
        Me.colLINE_NUMBER.FieldName = "LINE_NUMBER"
        Me.colLINE_NUMBER.MinWidth = 40
        Me.colLINE_NUMBER.Name = "colLINE_NUMBER"
        Me.colLINE_NUMBER.OptionsColumn.AllowEdit = False
        Me.colLINE_NUMBER.OptionsColumn.AllowFocus = False
        Me.colLINE_NUMBER.Visible = True
        Me.colLINE_NUMBER.VisibleIndex = 0
        Me.colLINE_NUMBER.Width = 150
        '
        'colMATERIAL_ID
        '
        Me.colMATERIAL_ID.Caption = "Código Material"
        Me.colMATERIAL_ID.FieldName = "MATERIAL_ID"
        Me.colMATERIAL_ID.MinWidth = 40
        Me.colMATERIAL_ID.Name = "colMATERIAL_ID"
        Me.colMATERIAL_ID.Visible = True
        Me.colMATERIAL_ID.VisibleIndex = 1
        Me.colMATERIAL_ID.Width = 300
        '
        'colSKU_DESCRIPTION
        '
        Me.colSKU_DESCRIPTION.Caption = "Descripcion Material"
        Me.colSKU_DESCRIPTION.FieldName = "SKU_DESCRIPTION"
        Me.colSKU_DESCRIPTION.MinWidth = 40
        Me.colSKU_DESCRIPTION.Name = "colSKU_DESCRIPTION"
        Me.colSKU_DESCRIPTION.OptionsColumn.AllowEdit = False
        Me.colSKU_DESCRIPTION.OptionsColumn.AllowFocus = False
        Me.colSKU_DESCRIPTION.Visible = True
        Me.colSKU_DESCRIPTION.VisibleIndex = 2
        Me.colSKU_DESCRIPTION.Width = 150
        '
        'colQTY
        '
        Me.colQTY.Caption = "Cantidad"
        Me.colQTY.DisplayFormat.FormatString = "#,##0.0000"
        Me.colQTY.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colQTY.FieldName = "QTY"
        Me.colQTY.MinWidth = 40
        Me.colQTY.Name = "colQTY"
        Me.colQTY.OptionsColumn.AllowEdit = False
        Me.colQTY.OptionsColumn.AllowFocus = False
        Me.colQTY.Visible = True
        Me.colQTY.VisibleIndex = 3
        Me.colQTY.Width = 150
        '
        'colBULTOS
        '
        Me.colBULTOS.Caption = "Bultos"
        Me.colBULTOS.DisplayFormat.FormatString = "#,##0.0000"
        Me.colBULTOS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colBULTOS.FieldName = "BULTOS"
        Me.colBULTOS.MinWidth = 40
        Me.colBULTOS.Name = "colBULTOS"
        Me.colBULTOS.OptionsColumn.AllowEdit = False
        Me.colBULTOS.OptionsColumn.AllowFocus = False
        Me.colBULTOS.Visible = True
        Me.colBULTOS.VisibleIndex = 4
        Me.colBULTOS.Width = 150
        '
        'colTRANS_ASOCIADOS
        '
        Me.colTRANS_ASOCIADOS.Caption = "Transacciones Asociadas"
        Me.colTRANS_ASOCIADOS.FieldName = "TRANS_ASOCIADOS"
        Me.colTRANS_ASOCIADOS.MinWidth = 40
        Me.colTRANS_ASOCIADOS.Name = "colTRANS_ASOCIADOS"
        Me.colTRANS_ASOCIADOS.OptionsColumn.AllowEdit = False
        Me.colTRANS_ASOCIADOS.OptionsColumn.AllowFocus = False
        Me.colTRANS_ASOCIADOS.Visible = True
        Me.colTRANS_ASOCIADOS.VisibleIndex = 5
        Me.colTRANS_ASOCIADOS.Width = 150
        '
        'colnDOC_ID
        '
        Me.colnDOC_ID.Caption = "DOC_ID"
        Me.colnDOC_ID.FieldName = "DOC_ID"
        Me.colnDOC_ID.MinWidth = 40
        Me.colnDOC_ID.Name = "colnDOC_ID"
        Me.colnDOC_ID.Width = 150
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(6, 67)
        Me.LabelControl3.Margin = New System.Windows.Forms.Padding(6)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(92, 25)
        Me.LabelControl3.TabIndex = 5
        Me.LabelControl3.Text = "Enlazadas"
        '
        'gridEnlazados
        '
        Me.gridEnlazados.Cursor = System.Windows.Forms.Cursors.Default
        Me.gridEnlazados.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridEnlazados.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(6)
        Me.gridEnlazados.Location = New System.Drawing.Point(0, 46)
        Me.gridEnlazados.MainView = Me.gridViewEnlazados
        Me.gridEnlazados.Margin = New System.Windows.Forms.Padding(6)
        Me.gridEnlazados.MenuManager = Me.barManagerHeader
        Me.gridEnlazados.Name = "gridEnlazados"
        Me.gridEnlazados.Size = New System.Drawing.Size(2424, 436)
        Me.gridEnlazados.TabIndex = 0
        Me.gridEnlazados.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridViewEnlazados})
        '
        'gridViewEnlazados
        '
        Me.gridViewEnlazados.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colTRANS_ID, Me.colLICENSE_IDAso, Me.colEMATERIAL_CODE, Me.colEMATERIAL_DESCRIPTION, Me.colEQTY_TRANS, Me.colLINENO_POLIZA, Me.colESKU_DESCRIPTION, Me.colEQTY_POLIZA, Me.colEBULTOS_POLIZA, Me.colQtyAso, Me.colAsoDOC_ID})
        Me.gridViewEnlazados.DetailHeight = 673
        Me.gridViewEnlazados.FixedLineWidth = 4
        Me.gridViewEnlazados.GridControl = Me.gridEnlazados
        Me.gridViewEnlazados.Name = "gridViewEnlazados"
        Me.gridViewEnlazados.OptionsSelection.MultiSelect = True
        '
        'colTRANS_ID
        '
        Me.colTRANS_ID.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.colTRANS_ID.AppearanceCell.Options.UseBackColor = True
        Me.colTRANS_ID.Caption = "Trasaccion"
        Me.colTRANS_ID.FieldName = "TRANS_ID"
        Me.colTRANS_ID.MinWidth = 40
        Me.colTRANS_ID.Name = "colTRANS_ID"
        Me.colTRANS_ID.OptionsColumn.AllowEdit = False
        Me.colTRANS_ID.OptionsColumn.AllowFocus = False
        Me.colTRANS_ID.Visible = True
        Me.colTRANS_ID.VisibleIndex = 0
        Me.colTRANS_ID.Width = 150
        '
        'colLICENSE_IDAso
        '
        Me.colLICENSE_IDAso.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.colLICENSE_IDAso.AppearanceCell.Options.UseBackColor = True
        Me.colLICENSE_IDAso.Caption = "Licencia"
        Me.colLICENSE_IDAso.FieldName = "LICENSE_ID"
        Me.colLICENSE_IDAso.MinWidth = 40
        Me.colLICENSE_IDAso.Name = "colLICENSE_IDAso"
        Me.colLICENSE_IDAso.OptionsColumn.AllowEdit = False
        Me.colLICENSE_IDAso.OptionsColumn.AllowFocus = False
        Me.colLICENSE_IDAso.Visible = True
        Me.colLICENSE_IDAso.VisibleIndex = 1
        Me.colLICENSE_IDAso.Width = 150
        '
        'colEMATERIAL_CODE
        '
        Me.colEMATERIAL_CODE.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.colEMATERIAL_CODE.AppearanceCell.Options.UseBackColor = True
        Me.colEMATERIAL_CODE.Caption = "Codigo Material"
        Me.colEMATERIAL_CODE.FieldName = "MATERIAL_CODE"
        Me.colEMATERIAL_CODE.MinWidth = 40
        Me.colEMATERIAL_CODE.Name = "colEMATERIAL_CODE"
        Me.colEMATERIAL_CODE.OptionsColumn.AllowEdit = False
        Me.colEMATERIAL_CODE.OptionsColumn.AllowFocus = False
        Me.colEMATERIAL_CODE.Visible = True
        Me.colEMATERIAL_CODE.VisibleIndex = 2
        Me.colEMATERIAL_CODE.Width = 150
        '
        'colEMATERIAL_DESCRIPTION
        '
        Me.colEMATERIAL_DESCRIPTION.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.colEMATERIAL_DESCRIPTION.AppearanceCell.Options.UseBackColor = True
        Me.colEMATERIAL_DESCRIPTION.Caption = "Nombre Material"
        Me.colEMATERIAL_DESCRIPTION.FieldName = "MATERIAL_DESCRIPTION"
        Me.colEMATERIAL_DESCRIPTION.MinWidth = 40
        Me.colEMATERIAL_DESCRIPTION.Name = "colEMATERIAL_DESCRIPTION"
        Me.colEMATERIAL_DESCRIPTION.OptionsColumn.AllowEdit = False
        Me.colEMATERIAL_DESCRIPTION.OptionsColumn.AllowFocus = False
        Me.colEMATERIAL_DESCRIPTION.Visible = True
        Me.colEMATERIAL_DESCRIPTION.VisibleIndex = 3
        Me.colEMATERIAL_DESCRIPTION.Width = 150
        '
        'colEQTY_TRANS
        '
        Me.colEQTY_TRANS.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.colEQTY_TRANS.AppearanceCell.Options.UseBackColor = True
        Me.colEQTY_TRANS.Caption = "Cantidad Transaccion"
        Me.colEQTY_TRANS.DisplayFormat.FormatString = "#,##0.0000"
        Me.colEQTY_TRANS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colEQTY_TRANS.FieldName = "QTY_TRANS"
        Me.colEQTY_TRANS.MinWidth = 40
        Me.colEQTY_TRANS.Name = "colEQTY_TRANS"
        Me.colEQTY_TRANS.OptionsColumn.AllowEdit = False
        Me.colEQTY_TRANS.OptionsColumn.AllowFocus = False
        Me.colEQTY_TRANS.Visible = True
        Me.colEQTY_TRANS.VisibleIndex = 4
        Me.colEQTY_TRANS.Width = 150
        '
        'colLINENO_POLIZA
        '
        Me.colLINENO_POLIZA.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.colLINENO_POLIZA.AppearanceCell.Options.UseBackColor = True
        Me.colLINENO_POLIZA.Caption = "Linea"
        Me.colLINENO_POLIZA.FieldName = "LINENO_POLIZA"
        Me.colLINENO_POLIZA.MinWidth = 40
        Me.colLINENO_POLIZA.Name = "colLINENO_POLIZA"
        Me.colLINENO_POLIZA.OptionsColumn.AllowEdit = False
        Me.colLINENO_POLIZA.OptionsColumn.AllowFocus = False
        Me.colLINENO_POLIZA.Visible = True
        Me.colLINENO_POLIZA.VisibleIndex = 5
        Me.colLINENO_POLIZA.Width = 150
        '
        'colESKU_DESCRIPTION
        '
        Me.colESKU_DESCRIPTION.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.colESKU_DESCRIPTION.AppearanceCell.Options.UseBackColor = True
        Me.colESKU_DESCRIPTION.Caption = "Descripcion Material"
        Me.colESKU_DESCRIPTION.FieldName = "SKU_DESCRIPTION"
        Me.colESKU_DESCRIPTION.MinWidth = 40
        Me.colESKU_DESCRIPTION.Name = "colESKU_DESCRIPTION"
        Me.colESKU_DESCRIPTION.OptionsColumn.AllowEdit = False
        Me.colESKU_DESCRIPTION.OptionsColumn.AllowFocus = False
        Me.colESKU_DESCRIPTION.Visible = True
        Me.colESKU_DESCRIPTION.VisibleIndex = 6
        Me.colESKU_DESCRIPTION.Width = 150
        '
        'colEQTY_POLIZA
        '
        Me.colEQTY_POLIZA.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.colEQTY_POLIZA.AppearanceCell.Options.UseBackColor = True
        Me.colEQTY_POLIZA.Caption = "Cantidad Poliza"
        Me.colEQTY_POLIZA.DisplayFormat.FormatString = "#,##0.0000"
        Me.colEQTY_POLIZA.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colEQTY_POLIZA.FieldName = "QTY_POLIZA"
        Me.colEQTY_POLIZA.MinWidth = 40
        Me.colEQTY_POLIZA.Name = "colEQTY_POLIZA"
        Me.colEQTY_POLIZA.OptionsColumn.AllowEdit = False
        Me.colEQTY_POLIZA.OptionsColumn.AllowFocus = False
        Me.colEQTY_POLIZA.Visible = True
        Me.colEQTY_POLIZA.VisibleIndex = 7
        Me.colEQTY_POLIZA.Width = 150
        '
        'colEBULTOS_POLIZA
        '
        Me.colEBULTOS_POLIZA.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.colEBULTOS_POLIZA.AppearanceCell.Options.UseBackColor = True
        Me.colEBULTOS_POLIZA.Caption = "Bultos"
        Me.colEBULTOS_POLIZA.DisplayFormat.FormatString = "#,##0.0000"
        Me.colEBULTOS_POLIZA.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colEBULTOS_POLIZA.FieldName = "BULTOS_POLIZA"
        Me.colEBULTOS_POLIZA.MinWidth = 40
        Me.colEBULTOS_POLIZA.Name = "colEBULTOS_POLIZA"
        Me.colEBULTOS_POLIZA.OptionsColumn.AllowEdit = False
        Me.colEBULTOS_POLIZA.OptionsColumn.AllowFocus = False
        Me.colEBULTOS_POLIZA.Visible = True
        Me.colEBULTOS_POLIZA.VisibleIndex = 8
        Me.colEBULTOS_POLIZA.Width = 150
        '
        'colQtyAso
        '
        Me.colQtyAso.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.colQtyAso.AppearanceCell.Options.UseBackColor = True
        Me.colQtyAso.Caption = "Cantidad"
        Me.colQtyAso.DisplayFormat.FormatString = "#,##0.0000"
        Me.colQtyAso.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colQtyAso.FieldName = "QTY"
        Me.colQtyAso.MinWidth = 40
        Me.colQtyAso.Name = "colQtyAso"
        Me.colQtyAso.Visible = True
        Me.colQtyAso.VisibleIndex = 9
        Me.colQtyAso.Width = 150
        '
        'colAsoDOC_ID
        '
        Me.colAsoDOC_ID.Caption = "DOC_ID"
        Me.colAsoDOC_ID.FieldName = "DOC_ID"
        Me.colAsoDOC_ID.MinWidth = 40
        Me.colAsoDOC_ID.Name = "colAsoDOC_ID"
        Me.colAsoDOC_ID.Width = 150
        '
        'BarDockControl7
        '
        Me.BarDockControl7.CausesValidation = False
        Me.BarDockControl7.Dock = System.Windows.Forms.DockStyle.Left
        Me.BarDockControl7.Location = New System.Drawing.Point(0, 46)
        Me.BarDockControl7.Manager = Me.barManagerDetEnlazados
        Me.BarDockControl7.Margin = New System.Windows.Forms.Padding(6)
        Me.BarDockControl7.Size = New System.Drawing.Size(0, 436)
        '
        'barManagerDetEnlazados
        '
        Me.barManagerDetEnlazados.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Bar2})
        Me.barManagerDetEnlazados.DockControls.Add(Me.BarDockControl5)
        Me.barManagerDetEnlazados.DockControls.Add(Me.BarDockControl6)
        Me.barManagerDetEnlazados.DockControls.Add(Me.BarDockControl7)
        Me.barManagerDetEnlazados.DockControls.Add(Me.BarDockControl8)
        Me.barManagerDetEnlazados.Form = Me.SplitContainerControl2.Panel2
        Me.barManagerDetEnlazados.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.BarEditItem3, Me.BarEditItem4, Me.btnBorrorAso, Me.btnExpandirAsociados, Me.btnContraerAsociados, Me.barConfirAsociacion, Me.btnCancelarAso, Me.txtComentario2})
        Me.barManagerDetEnlazados.MaxItemId = 9
        Me.barManagerDetEnlazados.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemFontEdit1, Me.RepositoryItemImageEdit1, Me.RepositoryItemMemoEdit2})
        '
        'Bar2
        '
        Me.Bar2.BarName = "Herramientas"
        Me.Bar2.DockCol = 0
        Me.Bar2.DockRow = 0
        Me.Bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar2.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.btnBorrorAso, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.btnExpandirAsociados, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.btnContraerAsociados, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.barConfirAsociacion, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.btnCancelarAso, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)})
        Me.Bar2.OptionsBar.AllowQuickCustomization = False
        Me.Bar2.OptionsBar.DrawDragBorder = False
        Me.Bar2.OptionsBar.UseWholeRow = True
        Me.Bar2.Text = "Herramientas"
        '
        'btnBorrorAso
        '
        Me.btnBorrorAso.Caption = "Eliminar"
        Me.btnBorrorAso.Id = 2
        Me.btnBorrorAso.ImageOptions.Image = CType(resources.GetObject("btnBorrorAso.ImageOptions.Image"), System.Drawing.Image)
        Me.btnBorrorAso.ImageOptions.LargeImage = CType(resources.GetObject("btnBorrorAso.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.btnBorrorAso.Name = "btnBorrorAso"
        '
        'btnExpandirAsociados
        '
        Me.btnExpandirAsociados.Caption = "Expadir"
        Me.btnExpandirAsociados.Id = 3
        Me.btnExpandirAsociados.ImageOptions.Image = CType(resources.GetObject("btnExpandirAsociados.ImageOptions.Image"), System.Drawing.Image)
        Me.btnExpandirAsociados.ImageOptions.LargeImage = CType(resources.GetObject("btnExpandirAsociados.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.btnExpandirAsociados.Name = "btnExpandirAsociados"
        '
        'btnContraerAsociados
        '
        Me.btnContraerAsociados.Caption = "Contraer"
        Me.btnContraerAsociados.Id = 4
        Me.btnContraerAsociados.ImageOptions.Image = CType(resources.GetObject("btnContraerAsociados.ImageOptions.Image"), System.Drawing.Image)
        Me.btnContraerAsociados.ImageOptions.LargeImage = CType(resources.GetObject("btnContraerAsociados.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.btnContraerAsociados.Name = "btnContraerAsociados"
        '
        'barConfirAsociacion
        '
        Me.barConfirAsociacion.Caption = "Confirma Asociación"
        Me.barConfirAsociacion.Id = 5
        Me.barConfirAsociacion.ImageOptions.Image = CType(resources.GetObject("barConfirAsociacion.ImageOptions.Image"), System.Drawing.Image)
        Me.barConfirAsociacion.ImageOptions.LargeImage = CType(resources.GetObject("barConfirAsociacion.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.barConfirAsociacion.Name = "barConfirAsociacion"
        Me.barConfirAsociacion.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'btnCancelarAso
        '
        Me.btnCancelarAso.Caption = "Cancelar Asociación"
        Me.btnCancelarAso.Id = 7
        Me.btnCancelarAso.ImageOptions.Image = CType(resources.GetObject("btnCancelarAso.ImageOptions.Image"), System.Drawing.Image)
        Me.btnCancelarAso.ImageOptions.LargeImage = CType(resources.GetObject("btnCancelarAso.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.btnCancelarAso.Name = "btnCancelarAso"
        Me.btnCancelarAso.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'BarDockControl5
        '
        Me.BarDockControl5.CausesValidation = False
        Me.BarDockControl5.Dock = System.Windows.Forms.DockStyle.Top
        Me.BarDockControl5.Location = New System.Drawing.Point(0, 0)
        Me.BarDockControl5.Manager = Me.barManagerDetEnlazados
        Me.BarDockControl5.Margin = New System.Windows.Forms.Padding(6)
        Me.BarDockControl5.Size = New System.Drawing.Size(2424, 46)
        '
        'BarDockControl6
        '
        Me.BarDockControl6.CausesValidation = False
        Me.BarDockControl6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarDockControl6.Location = New System.Drawing.Point(0, 482)
        Me.BarDockControl6.Manager = Me.barManagerDetEnlazados
        Me.BarDockControl6.Margin = New System.Windows.Forms.Padding(6)
        Me.BarDockControl6.Size = New System.Drawing.Size(2424, 0)
        '
        'BarDockControl8
        '
        Me.BarDockControl8.CausesValidation = False
        Me.BarDockControl8.Dock = System.Windows.Forms.DockStyle.Right
        Me.BarDockControl8.Location = New System.Drawing.Point(2424, 46)
        Me.BarDockControl8.Manager = Me.barManagerDetEnlazados
        Me.BarDockControl8.Margin = New System.Windows.Forms.Padding(6)
        Me.BarDockControl8.Size = New System.Drawing.Size(0, 436)
        '
        'BarEditItem3
        '
        Me.BarEditItem3.Caption = "BarEditItem3"
        Me.BarEditItem3.Edit = Me.RepositoryItemFontEdit1
        Me.BarEditItem3.Id = 0
        Me.BarEditItem3.Name = "BarEditItem3"
        '
        'RepositoryItemFontEdit1
        '
        Me.RepositoryItemFontEdit1.AutoHeight = False
        Me.RepositoryItemFontEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemFontEdit1.Name = "RepositoryItemFontEdit1"
        '
        'BarEditItem4
        '
        Me.BarEditItem4.Caption = "BarEditItem4"
        Me.BarEditItem4.Edit = Me.RepositoryItemImageEdit1
        Me.BarEditItem4.Id = 1
        Me.BarEditItem4.Name = "BarEditItem4"
        '
        'RepositoryItemImageEdit1
        '
        Me.RepositoryItemImageEdit1.AutoHeight = False
        Me.RepositoryItemImageEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemImageEdit1.Name = "RepositoryItemImageEdit1"
        '
        'txtComentario2
        '
        Me.txtComentario2.Caption = "Comentario"
        Me.txtComentario2.Edit = Me.RepositoryItemMemoEdit2
        Me.txtComentario2.EditWidth = 300
        Me.txtComentario2.Id = 8
        Me.txtComentario2.ImageOptions.Image = CType(resources.GetObject("txtComentario2.ImageOptions.Image"), System.Drawing.Image)
        Me.txtComentario2.ImageOptions.LargeImage = CType(resources.GetObject("txtComentario2.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.txtComentario2.Name = "txtComentario2"
        '
        'RepositoryItemMemoEdit2
        '
        Me.RepositoryItemMemoEdit2.Name = "RepositoryItemMemoEdit2"
        '
        'BarDockControl3
        '
        Me.BarDockControl3.CausesValidation = False
        Me.BarDockControl3.Dock = System.Windows.Forms.DockStyle.Left
        Me.BarDockControl3.Location = New System.Drawing.Point(0, 46)
        Me.BarDockControl3.Manager = Me.barManagerDet
        Me.BarDockControl3.Margin = New System.Windows.Forms.Padding(6)
        Me.BarDockControl3.Size = New System.Drawing.Size(0, 1040)
        '
        'barManagerDet
        '
        Me.barManagerDet.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Bar1})
        Me.barManagerDet.DockControls.Add(Me.BarDockControl1)
        Me.barManagerDet.DockControls.Add(Me.BarDockControl2)
        Me.barManagerDet.DockControls.Add(Me.BarDockControl3)
        Me.barManagerDet.DockControls.Add(Me.BarDockControl4)
        Me.barManagerDet.Form = Me.tabDet
        Me.barManagerDet.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.btnEnlazar, Me.BarButtonItem1, Me.BarEditItem8, Me.txtComentario, Me.txtComentario3})
        Me.barManagerDet.MaxItemId = 5
        Me.barManagerDet.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemMemoExEdit1, Me.RepositoryItemMemoEdit1, Me.RepositoryItemMemoEdit3})
        '
        'Bar1
        '
        Me.Bar1.BarName = "Herramientas"
        Me.Bar1.DockCol = 0
        Me.Bar1.DockRow = 0
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.btnEnlazar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.txtComentario3, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)})
        Me.Bar1.OptionsBar.AllowQuickCustomization = False
        Me.Bar1.OptionsBar.DrawDragBorder = False
        Me.Bar1.OptionsBar.UseWholeRow = True
        Me.Bar1.Text = "Herramientas"
        '
        'btnEnlazar
        '
        Me.btnEnlazar.Caption = "Enlazar"
        Me.btnEnlazar.Id = 0
        Me.btnEnlazar.ImageOptions.Image = CType(resources.GetObject("btnEnlazar.ImageOptions.Image"), System.Drawing.Image)
        Me.btnEnlazar.ImageOptions.LargeImage = CType(resources.GetObject("btnEnlazar.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.btnEnlazar.Name = "btnEnlazar"
        '
        'txtComentario3
        '
        Me.txtComentario3.Caption = "Comentario"
        Me.txtComentario3.Edit = Me.RepositoryItemMemoEdit3
        Me.txtComentario3.EditWidth = 800
        Me.txtComentario3.Id = 4
        Me.txtComentario3.ImageOptions.Image = CType(resources.GetObject("txtComentario3.ImageOptions.Image"), System.Drawing.Image)
        Me.txtComentario3.ImageOptions.LargeImage = CType(resources.GetObject("txtComentario3.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.txtComentario3.Name = "txtComentario3"
        '
        'RepositoryItemMemoEdit3
        '
        Me.RepositoryItemMemoEdit3.Name = "RepositoryItemMemoEdit3"
        '
        'BarDockControl1
        '
        Me.BarDockControl1.CausesValidation = False
        Me.BarDockControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.BarDockControl1.Location = New System.Drawing.Point(0, 0)
        Me.BarDockControl1.Manager = Me.barManagerDet
        Me.BarDockControl1.Margin = New System.Windows.Forms.Padding(6)
        Me.BarDockControl1.Size = New System.Drawing.Size(2424, 46)
        '
        'BarDockControl2
        '
        Me.BarDockControl2.CausesValidation = False
        Me.BarDockControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarDockControl2.Location = New System.Drawing.Point(0, 1086)
        Me.BarDockControl2.Manager = Me.barManagerDet
        Me.BarDockControl2.Margin = New System.Windows.Forms.Padding(6)
        Me.BarDockControl2.Size = New System.Drawing.Size(2424, 0)
        '
        'BarDockControl4
        '
        Me.BarDockControl4.CausesValidation = False
        Me.BarDockControl4.Dock = System.Windows.Forms.DockStyle.Right
        Me.BarDockControl4.Location = New System.Drawing.Point(2424, 46)
        Me.BarDockControl4.Manager = Me.barManagerDet
        Me.BarDockControl4.Margin = New System.Windows.Forms.Padding(6)
        Me.BarDockControl4.Size = New System.Drawing.Size(0, 1040)
        '
        'BarButtonItem1
        '
        Me.BarButtonItem1.Id = 1
        Me.BarButtonItem1.Name = "BarButtonItem1"
        '
        'BarEditItem8
        '
        Me.BarEditItem8.Caption = "BarEditItem8"
        Me.BarEditItem8.Edit = Me.RepositoryItemMemoExEdit1
        Me.BarEditItem8.Id = 2
        Me.BarEditItem8.Name = "BarEditItem8"
        '
        'RepositoryItemMemoExEdit1
        '
        Me.RepositoryItemMemoExEdit1.AutoHeight = False
        Me.RepositoryItemMemoExEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemMemoExEdit1.Name = "RepositoryItemMemoExEdit1"
        '
        'txtComentario
        '
        Me.txtComentario.Caption = "Comentario"
        Me.txtComentario.Edit = Me.RepositoryItemMemoEdit1
        Me.txtComentario.EditWidth = 500
        Me.txtComentario.Id = 3
        Me.txtComentario.ImageOptions.Image = CType(resources.GetObject("txtComentario.ImageOptions.Image"), System.Drawing.Image)
        Me.txtComentario.ImageOptions.LargeImage = CType(resources.GetObject("txtComentario.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.txtComentario.Name = "txtComentario"
        '
        'RepositoryItemMemoEdit1
        '
        Me.RepositoryItemMemoEdit1.Name = "RepositoryItemMemoEdit1"
        '
        'FrmAprobacionFiscal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(2428, 1135)
        Me.Controls.Add(Me.tabPolizas)
        Me.Margin = New System.Windows.Forms.Padding(6)
        Me.Name = "FrmAprobacionFiscal"
        Me.Text = "Aprobacion Fiscal"
        CType(Me.RepositoryItemTextEdit5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tabPolizas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPolizas.ResumeLayout(False)
        Me.tabHeader.ResumeLayout(False)
        Me.tabHeader.PerformLayout()
        CType(Me.gridPolizas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridViewPolizas, System.ComponentModel.ISupportInitialize).EndInit()
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
        Me.tabDet.ResumeLayout(False)
        Me.tabDet.PerformLayout()
        CType(Me.SplitContainerControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl2.ResumeLayout(False)
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.gridLicencias, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridViewLicencias, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridLienas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridViewLineas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridEnlazados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridViewEnlazados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.barManagerDetEnlazados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemFontEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemImageEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.barManagerDet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoEdit3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoExEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tabPolizas As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents tabHeader As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents tabDet As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents barManagerHeader As DevExpress.XtraBars.BarManager
    Friend WithEvents barHeader As DevExpress.XtraBars.Bar
    Friend WithEvents dtFechaInicio As DevExpress.XtraBars.BarEditItem
    Friend WithEvents RepositoryItemDateEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents gridPolizas As DevExpress.XtraGrid.GridControl
    Friend WithEvents gridViewPolizas As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents dtFechaFinal As DevExpress.XtraBars.BarEditItem
    Friend WithEvents RepositoryItemDateEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents barBtnRefreshHeader As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents SplitContainerControl2 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents BarDockControl3 As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarDockControl4 As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarDockControl2 As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarDockControl1 As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barManagerDet As DevExpress.XtraBars.BarManager
    Friend WithEvents Bar1 As DevExpress.XtraBars.Bar
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents gridLicencias As DevExpress.XtraGrid.GridControl
    Friend WithEvents gridViewLicencias As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents gridLienas As DevExpress.XtraGrid.GridControl
    Friend WithEvents gridViewLineas As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents gridEnlazados As DevExpress.XtraGrid.GridControl
    Friend WithEvents gridViewEnlazados As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents barManagerDetEnlazados As DevExpress.XtraBars.BarManager
    Friend WithEvents Bar2 As DevExpress.XtraBars.Bar
    Friend WithEvents BarDockControl5 As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarDockControl6 As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarDockControl7 As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarDockControl8 As DevExpress.XtraBars.BarDockControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BarEditItem3 As DevExpress.XtraBars.BarEditItem
    Friend WithEvents RepositoryItemFontEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemFontEdit
    Friend WithEvents BarEditItem4 As DevExpress.XtraBars.BarEditItem
    Friend WithEvents RepositoryItemImageEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemImageEdit
    Friend WithEvents btnEnlazar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnBorrorAso As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarEditItem5 As DevExpress.XtraBars.BarEditItem
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents BarEditItem6 As DevExpress.XtraBars.BarEditItem
    Friend WithEvents RepositoryItemTextEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents BarEditItem1 As DevExpress.XtraBars.BarEditItem
    Friend WithEvents BarEditItem2 As DevExpress.XtraBars.BarEditItem
    Friend WithEvents RepositoryItemDateEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents BarEditItem7 As DevExpress.XtraBars.BarEditItem
    Friend WithEvents RepositoryItemTextEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemTextEdit5 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents colDOC_ID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNUMERO_ORDEN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCODIGO_POLIZA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCLIENT_CODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCardName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colACUERDO_COMERCIAL_NOMBRE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPOLIZA_INSURANCE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFECHA_DOCUMENTO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LAST_UPDATED As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents collICENSE_iD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMATERIAL_CODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMATERIAL_DESCRIPTION As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents coLQUANTITY_UNITS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colLINE_NUMBER As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSKU_DESCRIPTION As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBULTOS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colQTY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTRANS_ID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colLINENO_POLIZA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colEMATERIAL_CODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colEMATERIAL_DESCRIPTION As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colESKU_DESCRIPTION As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colEQTY_TRANS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colEQTY_POLIZA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colEBULTOS_POLIZA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colESERIAL_NUMBER As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colLINEAS_ASOCIADOS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTRANS_ASOCIADOS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnExpandirAsociados As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnContraerAsociados As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents colQtyAso As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colLICENSE_IDAso As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents txtComentario As DevExpress.XtraBars.BarEditItem
    Friend WithEvents RepositoryItemMemoEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents BarEditItem8 As DevExpress.XtraBars.BarEditItem
    Friend WithEvents RepositoryItemMemoExEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit
    Friend WithEvents colnDOC_ID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAsoDOC_ID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents barConfirAsociacion As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents txtComentario2 As DevExpress.XtraBars.BarEditItem
    Friend WithEvents RepositoryItemMemoEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents btnCancelarAso As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents txtComentario3 As DevExpress.XtraBars.BarEditItem
    Friend WithEvents RepositoryItemMemoEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents ColHSTATUS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents btnExpandirHeader As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents barContraerHeader As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnPrintHeader As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents colCOMMENTS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPENDIENTE_RECTIFICACION_DESCRIPCION As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCOMENTARIO_RECTIFICACION As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCLASE_POLIZA_RECTIFICACION As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCODIGO_POLIZA_RECTIFICACION As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPENDIENTE_RECTIFICACION As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UiBotonRectificar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents colVIN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMATERIAL_ID As DevExpress.XtraGrid.Columns.GridColumn
End Class
