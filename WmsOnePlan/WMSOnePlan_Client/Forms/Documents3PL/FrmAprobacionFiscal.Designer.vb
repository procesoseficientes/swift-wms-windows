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
        Me.BarDockControl8 = New DevExpress.XtraBars.BarDockControl()
        Me.BarDockControl6 = New DevExpress.XtraBars.BarDockControl()
        Me.BarDockControl5 = New DevExpress.XtraBars.BarDockControl()
        Me.BarDockControl3 = New DevExpress.XtraBars.BarDockControl()
        Me.BarDockControl4 = New DevExpress.XtraBars.BarDockControl()
        Me.BarDockControl2 = New DevExpress.XtraBars.BarDockControl()
        Me.BarDockControl1 = New DevExpress.XtraBars.BarDockControl()
        Me.barManagerDet = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar1 = New DevExpress.XtraBars.Bar()
        Me.btnEnlazar = New DevExpress.XtraBars.BarButtonItem()
        Me.txtComentario3 = New DevExpress.XtraBars.BarEditItem()
        Me.RepositoryItemMemoEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarEditItem8 = New DevExpress.XtraBars.BarEditItem()
        Me.RepositoryItemMemoExEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit()
        Me.txtComentario = New DevExpress.XtraBars.BarEditItem()
        Me.RepositoryItemMemoEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.barManagerDetEnlazados = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar2 = New DevExpress.XtraBars.Bar()
        Me.btnBorrorAso = New DevExpress.XtraBars.BarButtonItem()
        Me.btnExpandirAsociados = New DevExpress.XtraBars.BarButtonItem()
        Me.btnContraerAsociados = New DevExpress.XtraBars.BarButtonItem()
        Me.barConfirAsociacion = New DevExpress.XtraBars.BarButtonItem()
        Me.btnCancelarAso = New DevExpress.XtraBars.BarButtonItem()
        Me.BarEditItem3 = New DevExpress.XtraBars.BarEditItem()
        Me.RepositoryItemFontEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemFontEdit()
        Me.BarEditItem4 = New DevExpress.XtraBars.BarEditItem()
        Me.RepositoryItemImageEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemImageEdit()
        Me.txtComentario2 = New DevExpress.XtraBars.BarEditItem()
        Me.RepositoryItemMemoEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        CType(Me.RepositoryItemTextEdit5,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.tabPolizas,System.ComponentModel.ISupportInitialize).BeginInit
        Me.tabPolizas.SuspendLayout
        Me.tabHeader.SuspendLayout
        CType(Me.gridPolizas,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.gridViewPolizas,System.ComponentModel.ISupportInitialize).BeginInit
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
        Me.tabDet.SuspendLayout
        CType(Me.SplitContainerControl2,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SplitContainerControl2.SuspendLayout
        CType(Me.SplitContainerControl1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SplitContainerControl1.SuspendLayout
        CType(Me.gridLicencias,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.gridViewLicencias,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.gridLienas,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.gridViewLineas,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.gridEnlazados,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.gridViewEnlazados,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.barManagerDet,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.RepositoryItemMemoEdit3,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.RepositoryItemMemoExEdit1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.RepositoryItemMemoEdit1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.barManagerDetEnlazados,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.RepositoryItemFontEdit1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.RepositoryItemImageEdit1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.RepositoryItemMemoEdit2,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'RepositoryItemTextEdit5
        '
        Me.RepositoryItemTextEdit5.AutoHeight = false
        Me.RepositoryItemTextEdit5.Name = "RepositoryItemTextEdit5"
        '
        'tabPolizas
        '
        Me.tabPolizas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabPolizas.Location = New System.Drawing.Point(0, 0)
        Me.tabPolizas.Name = "tabPolizas"
        Me.tabPolizas.SelectedTabPage = Me.tabHeader
        Me.tabPolizas.Size = New System.Drawing.Size(1214, 590)
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
        Me.tabHeader.Name = "tabHeader"
        Me.tabHeader.Size = New System.Drawing.Size(1208, 562)
        Me.tabHeader.Text = "Polizas"
        '
        'gridPolizas
        '
        Me.gridPolizas.Cursor = System.Windows.Forms.Cursors.Default
        Me.gridPolizas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridPolizas.Location = New System.Drawing.Point(0, 31)
        Me.gridPolizas.MainView = Me.gridViewPolizas
        Me.gridPolizas.MenuManager = Me.barManagerHeader
        Me.gridPolizas.Name = "gridPolizas"
        Me.gridPolizas.Size = New System.Drawing.Size(1208, 531)
        Me.gridPolizas.TabIndex = 5
        Me.gridPolizas.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridViewPolizas})
        '
        'gridViewPolizas
        '
        Me.gridViewPolizas.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colDOC_ID, Me.colNUMERO_ORDEN, Me.colCODIGO_POLIZA, Me.colCLIENT_CODE, Me.colCardName, Me.colACUERDO_COMERCIAL_NOMBRE, Me.colPOLIZA_INSURANCE, Me.colFECHA_DOCUMENTO, Me.LAST_UPDATED, Me.ColHSTATUS, Me.colCOMMENTS, Me.colPENDIENTE_RECTIFICACION_DESCRIPCION, Me.colCOMENTARIO_RECTIFICACION, Me.colCLASE_POLIZA_RECTIFICACION, Me.colCODIGO_POLIZA_RECTIFICACION, Me.colPENDIENTE_RECTIFICACION})
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
        Me.gridViewPolizas.FormatConditions.AddRange(New DevExpress.XtraGrid.StyleFormatCondition() {StyleFormatCondition1, StyleFormatCondition2})
        Me.gridViewPolizas.GridControl = Me.gridPolizas
        Me.gridViewPolizas.Name = "gridViewPolizas"
        Me.gridViewPolizas.OptionsView.ShowAutoFilterRow = true
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
        Me.colNUMERO_ORDEN.FieldName = "NUMERO_ORDEN"
        Me.colNUMERO_ORDEN.Name = "colNUMERO_ORDEN"
        Me.colNUMERO_ORDEN.OptionsColumn.AllowEdit = false
        Me.colNUMERO_ORDEN.OptionsColumn.AllowFocus = false
        Me.colNUMERO_ORDEN.Visible = true
        Me.colNUMERO_ORDEN.VisibleIndex = 1
        '
        'colCODIGO_POLIZA
        '
        Me.colCODIGO_POLIZA.Caption = "Codigo Poliza"
        Me.colCODIGO_POLIZA.FieldName = "CODIGO_POLIZA"
        Me.colCODIGO_POLIZA.Name = "colCODIGO_POLIZA"
        Me.colCODIGO_POLIZA.OptionsColumn.AllowEdit = false
        Me.colCODIGO_POLIZA.OptionsColumn.AllowFocus = false
        Me.colCODIGO_POLIZA.Visible = true
        Me.colCODIGO_POLIZA.VisibleIndex = 2
        '
        'colCLIENT_CODE
        '
        Me.colCLIENT_CODE.Caption = "Codigo Cliente"
        Me.colCLIENT_CODE.FieldName = "CLIENT_CODE"
        Me.colCLIENT_CODE.Name = "colCLIENT_CODE"
        Me.colCLIENT_CODE.OptionsColumn.AllowEdit = false
        Me.colCLIENT_CODE.OptionsColumn.AllowFocus = false
        Me.colCLIENT_CODE.Visible = true
        Me.colCLIENT_CODE.VisibleIndex = 3
        '
        'colCardName
        '
        Me.colCardName.Caption = "Nombre Cliente"
        Me.colCardName.FieldName = "CardName"
        Me.colCardName.Name = "colCardName"
        Me.colCardName.OptionsColumn.AllowEdit = false
        Me.colCardName.OptionsColumn.AllowFocus = false
        Me.colCardName.Visible = true
        Me.colCardName.VisibleIndex = 4
        '
        'colACUERDO_COMERCIAL_NOMBRE
        '
        Me.colACUERDO_COMERCIAL_NOMBRE.Caption = "Acuerdo Comercial"
        Me.colACUERDO_COMERCIAL_NOMBRE.FieldName = "ACUERDO_COMERCIAL_NOMBRE"
        Me.colACUERDO_COMERCIAL_NOMBRE.Name = "colACUERDO_COMERCIAL_NOMBRE"
        Me.colACUERDO_COMERCIAL_NOMBRE.OptionsColumn.AllowEdit = false
        Me.colACUERDO_COMERCIAL_NOMBRE.OptionsColumn.AllowFocus = false
        Me.colACUERDO_COMERCIAL_NOMBRE.Visible = true
        Me.colACUERDO_COMERCIAL_NOMBRE.VisibleIndex = 5
        '
        'colPOLIZA_INSURANCE
        '
        Me.colPOLIZA_INSURANCE.Caption = "Poliza Seguro"
        Me.colPOLIZA_INSURANCE.FieldName = "POLIZA_INSURANCE"
        Me.colPOLIZA_INSURANCE.Name = "colPOLIZA_INSURANCE"
        Me.colPOLIZA_INSURANCE.OptionsColumn.AllowEdit = false
        Me.colPOLIZA_INSURANCE.OptionsColumn.AllowFocus = false
        Me.colPOLIZA_INSURANCE.Visible = true
        Me.colPOLIZA_INSURANCE.VisibleIndex = 6
        '
        'colFECHA_DOCUMENTO
        '
        Me.colFECHA_DOCUMENTO.Caption = "Fecha Documento"
        Me.colFECHA_DOCUMENTO.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.colFECHA_DOCUMENTO.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.colFECHA_DOCUMENTO.FieldName = "FECHA_DOCUMENTO"
        Me.colFECHA_DOCUMENTO.Name = "colFECHA_DOCUMENTO"
        Me.colFECHA_DOCUMENTO.OptionsColumn.AllowEdit = false
        Me.colFECHA_DOCUMENTO.OptionsColumn.AllowFocus = false
        Me.colFECHA_DOCUMENTO.Visible = true
        Me.colFECHA_DOCUMENTO.VisibleIndex = 7
        '
        'LAST_UPDATED
        '
        Me.LAST_UPDATED.Caption = "Fecha Creacion"
        Me.LAST_UPDATED.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.LAST_UPDATED.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.LAST_UPDATED.FieldName = "LAST_UPDATED"
        Me.LAST_UPDATED.Name = "LAST_UPDATED"
        Me.LAST_UPDATED.OptionsColumn.AllowEdit = false
        Me.LAST_UPDATED.OptionsColumn.AllowFocus = false
        Me.LAST_UPDATED.Visible = true
        Me.LAST_UPDATED.VisibleIndex = 8
        '
        'ColHSTATUS
        '
        Me.ColHSTATUS.Caption = "Estado"
        Me.ColHSTATUS.FieldName = "STATUS"
        Me.ColHSTATUS.Name = "ColHSTATUS"
        Me.ColHSTATUS.OptionsColumn.AllowEdit = false
        Me.ColHSTATUS.OptionsColumn.AllowFocus = false
        Me.ColHSTATUS.Visible = true
        Me.ColHSTATUS.VisibleIndex = 9
        '
        'colCOMMENTS
        '
        Me.colCOMMENTS.Caption = "Comentarios"
        Me.colCOMMENTS.FieldName = "COMMENTS"
        Me.colCOMMENTS.Name = "colCOMMENTS"
        Me.colCOMMENTS.OptionsColumn.AllowEdit = false
        Me.colCOMMENTS.Visible = true
        Me.colCOMMENTS.VisibleIndex = 10
        '
        'colPENDIENTE_RECTIFICACION_DESCRIPCION
        '
        Me.colPENDIENTE_RECTIFICACION_DESCRIPCION.Caption = "Pendiente de Rectificacion"
        Me.colPENDIENTE_RECTIFICACION_DESCRIPCION.FieldName = "PENDIENTE_RECTIFICACION_DESCRIPCION"
        Me.colPENDIENTE_RECTIFICACION_DESCRIPCION.Name = "colPENDIENTE_RECTIFICACION_DESCRIPCION"
        Me.colPENDIENTE_RECTIFICACION_DESCRIPCION.OptionsColumn.AllowEdit = false
        Me.colPENDIENTE_RECTIFICACION_DESCRIPCION.Visible = true
        Me.colPENDIENTE_RECTIFICACION_DESCRIPCION.VisibleIndex = 11
        '
        'colCOMENTARIO_RECTIFICACION
        '
        Me.colCOMENTARIO_RECTIFICACION.Caption = "Comentario Pendiente de Rectificar"
        Me.colCOMENTARIO_RECTIFICACION.FieldName = "COMENTARIO_RECTIFICADO"
        Me.colCOMENTARIO_RECTIFICACION.Name = "colCOMENTARIO_RECTIFICACION"
        Me.colCOMENTARIO_RECTIFICACION.OptionsColumn.AllowEdit = false
        Me.colCOMENTARIO_RECTIFICACION.Visible = true
        Me.colCOMENTARIO_RECTIFICACION.VisibleIndex = 12
        '
        'colCLASE_POLIZA_RECTIFICACION
        '
        Me.colCLASE_POLIZA_RECTIFICACION.Caption = "Clase de Poliza"
        Me.colCLASE_POLIZA_RECTIFICACION.FieldName = "CLASE_POLIZA_RECTIFICACION"
        Me.colCLASE_POLIZA_RECTIFICACION.Name = "colCLASE_POLIZA_RECTIFICACION"
        Me.colCLASE_POLIZA_RECTIFICACION.OptionsColumn.AllowEdit = false
        Me.colCLASE_POLIZA_RECTIFICACION.Visible = true
        Me.colCLASE_POLIZA_RECTIFICACION.VisibleIndex = 13
        '
        'colCODIGO_POLIZA_RECTIFICACION
        '
        Me.colCODIGO_POLIZA_RECTIFICACION.Caption = "Poliza de Rectificacion"
        Me.colCODIGO_POLIZA_RECTIFICACION.FieldName = "CODIGO_POLIZA_RECTIFICACION"
        Me.colCODIGO_POLIZA_RECTIFICACION.Name = "colCODIGO_POLIZA_RECTIFICACION"
        Me.colCODIGO_POLIZA_RECTIFICACION.OptionsColumn.AllowEdit = false
        Me.colCODIGO_POLIZA_RECTIFICACION.Visible = true
        Me.colCODIGO_POLIZA_RECTIFICACION.VisibleIndex = 14
        '
        'colPENDIENTE_RECTIFICACION
        '
        Me.colPENDIENTE_RECTIFICACION.Caption = "PENDIENTE_RECTIFICACION"
        Me.colPENDIENTE_RECTIFICACION.FieldName = "PENDIENTE_RECTIFICACION"
        Me.colPENDIENTE_RECTIFICACION.Name = "colPENDIENTE_RECTIFICACION"
        Me.colPENDIENTE_RECTIFICACION.OptionsColumn.AllowEdit = false
        Me.colPENDIENTE_RECTIFICACION.OptionsColumn.ShowInCustomizationForm = false
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
        Me.barHeader.OptionsBar.AllowQuickCustomization = false
        Me.barHeader.OptionsBar.DrawDragBorder = false
        Me.barHeader.OptionsBar.UseWholeRow = true
        Me.barHeader.Text = "Herramientas"
        '
        'btnExpandirHeader
        '
        Me.btnExpandirHeader.Caption = "Expandir"
        Me.btnExpandirHeader.Glyph = Global.WMSOnePlan_Client.My.Resources.Resources.linespacing_16x16
        Me.btnExpandirHeader.Id = 8
        Me.btnExpandirHeader.LargeGlyph = Global.WMSOnePlan_Client.My.Resources.Resources.linespacing_32x32
        Me.btnExpandirHeader.Name = "btnExpandirHeader"
        '
        'barContraerHeader
        '
        Me.barContraerHeader.Caption = "Contraer"
        Me.barContraerHeader.Glyph = Global.WMSOnePlan_Client.My.Resources.Resources.linespacing2_16x16
        Me.barContraerHeader.Id = 9
        Me.barContraerHeader.LargeGlyph = Global.WMSOnePlan_Client.My.Resources.Resources.linespacing2_32x32
        Me.barContraerHeader.Name = "barContraerHeader"
        '
        'btnPrintHeader
        '
        Me.btnPrintHeader.Caption = "Print"
        Me.btnPrintHeader.Glyph = Global.WMSOnePlan_Client.My.Resources.Resources.print_16x16
        Me.btnPrintHeader.Id = 10
        Me.btnPrintHeader.LargeGlyph = Global.WMSOnePlan_Client.My.Resources.Resources.print_32x32
        Me.btnPrintHeader.Name = "btnPrintHeader"
        '
        'dtFechaInicio
        '
        Me.dtFechaInicio.Caption = "Fecha Inicio"
        Me.dtFechaInicio.Edit = Me.RepositoryItemDateEdit1
        Me.dtFechaInicio.EditWidth = 100
        Me.dtFechaInicio.Glyph = CType(resources.GetObject("dtFechaInicio.Glyph"),System.Drawing.Image)
        Me.dtFechaInicio.Id = 0
        Me.dtFechaInicio.LargeGlyph = CType(resources.GetObject("dtFechaInicio.LargeGlyph"),System.Drawing.Image)
        Me.dtFechaInicio.Name = "dtFechaInicio"
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
        'dtFechaFinal
        '
        Me.dtFechaFinal.Caption = "Fecha Final"
        Me.dtFechaFinal.Edit = Me.RepositoryItemDateEdit2
        Me.dtFechaFinal.EditWidth = 100
        Me.dtFechaFinal.Glyph = CType(resources.GetObject("dtFechaFinal.Glyph"),System.Drawing.Image)
        Me.dtFechaFinal.Id = 1
        Me.dtFechaFinal.LargeGlyph = CType(resources.GetObject("dtFechaFinal.LargeGlyph"),System.Drawing.Image)
        Me.dtFechaFinal.Name = "dtFechaFinal"
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
        'barBtnRefreshHeader
        '
        Me.barBtnRefreshHeader.Caption = "Refresh"
        Me.barBtnRefreshHeader.Glyph = CType(resources.GetObject("barBtnRefreshHeader.Glyph"),System.Drawing.Image)
        Me.barBtnRefreshHeader.Id = 2
        Me.barBtnRefreshHeader.LargeGlyph = CType(resources.GetObject("barBtnRefreshHeader.LargeGlyph"),System.Drawing.Image)
        Me.barBtnRefreshHeader.Name = "barBtnRefreshHeader"
        '
        'UiBotonRectificar
        '
        Me.UiBotonRectificar.Caption = "Rectificar"
        Me.UiBotonRectificar.Glyph = CType(resources.GetObject("UiBotonRectificar.Glyph"),System.Drawing.Image)
        Me.UiBotonRectificar.Id = 11
        Me.UiBotonRectificar.LargeGlyph = CType(resources.GetObject("UiBotonRectificar.LargeGlyph"),System.Drawing.Image)
        Me.UiBotonRectificar.Name = "UiBotonRectificar"
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = false
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(1208, 31)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = false
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 562)
        Me.barDockControlBottom.Size = New System.Drawing.Size(1208, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = false
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 31)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 531)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = false
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(1208, 31)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 531)
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
        'tabDet
        '
        Me.tabDet.Controls.Add(Me.SplitContainerControl2)
        Me.tabDet.Controls.Add(Me.BarDockControl3)
        Me.tabDet.Controls.Add(Me.BarDockControl4)
        Me.tabDet.Controls.Add(Me.BarDockControl2)
        Me.tabDet.Controls.Add(Me.BarDockControl1)
        Me.tabDet.Name = "tabDet"
        Me.tabDet.Size = New System.Drawing.Size(1208, 562)
        Me.tabDet.Text = "Cuadre"
        '
        'SplitContainerControl2
        '
        Me.SplitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl2.Horizontal = false
        Me.SplitContainerControl2.Location = New System.Drawing.Point(0, 31)
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
        Me.SplitContainerControl2.Size = New System.Drawing.Size(1208, 531)
        Me.SplitContainerControl2.SplitterPosition = 280
        Me.SplitContainerControl2.TabIndex = 6
        Me.SplitContainerControl2.Text = "SplitContainerControl2"
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.LabelControl1)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.gridLicencias)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.LabelControl2)
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.gridLienas)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(1208, 280)
        Me.SplitContainerControl1.SplitterPosition = 707
        Me.SplitContainerControl1.TabIndex = 0
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(3, 6)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(68, 13)
        Me.LabelControl1.TabIndex = 1
        Me.LabelControl1.Text = "Transacciones"
        '
        'gridLicencias
        '
        Me.gridLicencias.AllowDrop = true
        Me.gridLicencias.Cursor = System.Windows.Forms.Cursors.Default
        Me.gridLicencias.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridLicencias.Location = New System.Drawing.Point(0, 0)
        Me.gridLicencias.MainView = Me.gridViewLicencias
        Me.gridLicencias.MenuManager = Me.barManagerHeader
        Me.gridLicencias.Name = "gridLicencias"
        Me.gridLicencias.Size = New System.Drawing.Size(707, 280)
        Me.gridLicencias.TabIndex = 0
        Me.gridLicencias.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridViewLicencias})
        '
        'gridViewLicencias
        '
        Me.gridViewLicencias.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colESERIAL_NUMBER, Me.collICENSE_iD, Me.colMATERIAL_CODE, Me.colMATERIAL_DESCRIPTION, Me.coLQUANTITY_UNITS, Me.colLINEAS_ASOCIADOS, Me.colVIN})
        Me.gridViewLicencias.GridControl = Me.gridLicencias
        Me.gridViewLicencias.Name = "gridViewLicencias"
        Me.gridViewLicencias.OptionsBehavior.Editable = false
        Me.gridViewLicencias.OptionsSelection.MultiSelect = true
        '
        'colESERIAL_NUMBER
        '
        Me.colESERIAL_NUMBER.Caption = "Transaccion"
        Me.colESERIAL_NUMBER.FieldName = "SERIAL_NUMBER"
        Me.colESERIAL_NUMBER.Name = "colESERIAL_NUMBER"
        Me.colESERIAL_NUMBER.OptionsColumn.AllowEdit = false
        Me.colESERIAL_NUMBER.OptionsColumn.AllowFocus = false
        Me.colESERIAL_NUMBER.Visible = true
        Me.colESERIAL_NUMBER.VisibleIndex = 0
        '
        'collICENSE_iD
        '
        Me.collICENSE_iD.Caption = "Licencia"
        Me.collICENSE_iD.FieldName = "LICENSE_ID"
        Me.collICENSE_iD.Name = "collICENSE_iD"
        Me.collICENSE_iD.OptionsColumn.AllowEdit = false
        Me.collICENSE_iD.OptionsColumn.AllowFocus = false
        Me.collICENSE_iD.Visible = true
        Me.collICENSE_iD.VisibleIndex = 1
        '
        'colMATERIAL_CODE
        '
        Me.colMATERIAL_CODE.Caption = "Codigo Material"
        Me.colMATERIAL_CODE.FieldName = "MATERIAL_CODE"
        Me.colMATERIAL_CODE.Name = "colMATERIAL_CODE"
        Me.colMATERIAL_CODE.OptionsColumn.AllowEdit = false
        Me.colMATERIAL_CODE.OptionsColumn.AllowFocus = false
        Me.colMATERIAL_CODE.Visible = true
        Me.colMATERIAL_CODE.VisibleIndex = 2
        '
        'colMATERIAL_DESCRIPTION
        '
        Me.colMATERIAL_DESCRIPTION.Caption = "Nombre Material"
        Me.colMATERIAL_DESCRIPTION.FieldName = "MATERIAL_DESCRIPTION"
        Me.colMATERIAL_DESCRIPTION.Name = "colMATERIAL_DESCRIPTION"
        Me.colMATERIAL_DESCRIPTION.OptionsColumn.AllowEdit = false
        Me.colMATERIAL_DESCRIPTION.OptionsColumn.AllowFocus = false
        Me.colMATERIAL_DESCRIPTION.Visible = true
        Me.colMATERIAL_DESCRIPTION.VisibleIndex = 3
        '
        'coLQUANTITY_UNITS
        '
        Me.coLQUANTITY_UNITS.Caption = "Cantidad"
        Me.coLQUANTITY_UNITS.DisplayFormat.FormatString = "#,##0.0000"
        Me.coLQUANTITY_UNITS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.coLQUANTITY_UNITS.FieldName = "QUANTITY_UNITS"
        Me.coLQUANTITY_UNITS.Name = "coLQUANTITY_UNITS"
        Me.coLQUANTITY_UNITS.OptionsColumn.AllowEdit = false
        Me.coLQUANTITY_UNITS.OptionsColumn.AllowFocus = false
        Me.coLQUANTITY_UNITS.Visible = true
        Me.coLQUANTITY_UNITS.VisibleIndex = 4
        '
        'colLINEAS_ASOCIADOS
        '
        Me.colLINEAS_ASOCIADOS.Caption = "Lineas Asociados"
        Me.colLINEAS_ASOCIADOS.FieldName = "LINEAS_ASOCIADOS"
        Me.colLINEAS_ASOCIADOS.Name = "colLINEAS_ASOCIADOS"
        Me.colLINEAS_ASOCIADOS.OptionsColumn.AllowEdit = false
        Me.colLINEAS_ASOCIADOS.OptionsColumn.AllowFocus = false
        Me.colLINEAS_ASOCIADOS.Visible = true
        Me.colLINEAS_ASOCIADOS.VisibleIndex = 5
        '
        'colVIN
        '
        Me.colVIN.Caption = "VIN"
        Me.colVIN.FieldName = "VIN"
        Me.colVIN.Name = "colVIN"
        Me.colVIN.OptionsColumn.AllowEdit = false
        Me.colVIN.Visible = true
        Me.colVIN.VisibleIndex = 6
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(0, 6)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(30, 13)
        Me.LabelControl2.TabIndex = 2
        Me.LabelControl2.Text = "Lineas"
        '
        'gridLienas
        '
        Me.gridLienas.AllowDrop = true
        Me.gridLienas.Cursor = System.Windows.Forms.Cursors.Default
        Me.gridLienas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridLienas.Location = New System.Drawing.Point(0, 0)
        Me.gridLienas.MainView = Me.gridViewLineas
        Me.gridLienas.MenuManager = Me.barManagerHeader
        Me.gridLienas.Name = "gridLienas"
        Me.gridLienas.Size = New System.Drawing.Size(496, 280)
        Me.gridLienas.TabIndex = 0
        Me.gridLienas.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridViewLineas})
        '
        'gridViewLineas
        '
        Me.gridViewLineas.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colLINE_NUMBER, Me.colSKU_DESCRIPTION, Me.colQTY, Me.colBULTOS, Me.colTRANS_ASOCIADOS, Me.colnDOC_ID})
        Me.gridViewLineas.GridControl = Me.gridLienas
        Me.gridViewLineas.Name = "gridViewLineas"
        Me.gridViewLineas.OptionsSelection.MultiSelect = true
        '
        'colLINE_NUMBER
        '
        Me.colLINE_NUMBER.Caption = "Linea"
        Me.colLINE_NUMBER.FieldName = "LINE_NUMBER"
        Me.colLINE_NUMBER.Name = "colLINE_NUMBER"
        Me.colLINE_NUMBER.OptionsColumn.AllowEdit = false
        Me.colLINE_NUMBER.OptionsColumn.AllowFocus = false
        Me.colLINE_NUMBER.Visible = true
        Me.colLINE_NUMBER.VisibleIndex = 0
        '
        'colSKU_DESCRIPTION
        '
        Me.colSKU_DESCRIPTION.Caption = "Descripcion Material"
        Me.colSKU_DESCRIPTION.FieldName = "SKU_DESCRIPTION"
        Me.colSKU_DESCRIPTION.Name = "colSKU_DESCRIPTION"
        Me.colSKU_DESCRIPTION.OptionsColumn.AllowEdit = false
        Me.colSKU_DESCRIPTION.OptionsColumn.AllowFocus = false
        Me.colSKU_DESCRIPTION.Visible = true
        Me.colSKU_DESCRIPTION.VisibleIndex = 1
        '
        'colQTY
        '
        Me.colQTY.Caption = "Cantidad"
        Me.colQTY.DisplayFormat.FormatString = "#,##0.0000"
        Me.colQTY.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colQTY.FieldName = "QTY"
        Me.colQTY.Name = "colQTY"
        Me.colQTY.OptionsColumn.AllowEdit = false
        Me.colQTY.OptionsColumn.AllowFocus = false
        Me.colQTY.Visible = true
        Me.colQTY.VisibleIndex = 2
        '
        'colBULTOS
        '
        Me.colBULTOS.Caption = "Bultos"
        Me.colBULTOS.DisplayFormat.FormatString = "#,##0.0000"
        Me.colBULTOS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colBULTOS.FieldName = "BULTOS"
        Me.colBULTOS.Name = "colBULTOS"
        Me.colBULTOS.OptionsColumn.AllowEdit = false
        Me.colBULTOS.OptionsColumn.AllowFocus = false
        Me.colBULTOS.Visible = true
        Me.colBULTOS.VisibleIndex = 3
        '
        'colTRANS_ASOCIADOS
        '
        Me.colTRANS_ASOCIADOS.Caption = "Transacciones Asociadas"
        Me.colTRANS_ASOCIADOS.FieldName = "TRANS_ASOCIADOS"
        Me.colTRANS_ASOCIADOS.Name = "colTRANS_ASOCIADOS"
        Me.colTRANS_ASOCIADOS.OptionsColumn.AllowEdit = false
        Me.colTRANS_ASOCIADOS.OptionsColumn.AllowFocus = false
        Me.colTRANS_ASOCIADOS.Visible = true
        Me.colTRANS_ASOCIADOS.VisibleIndex = 4
        '
        'colnDOC_ID
        '
        Me.colnDOC_ID.Caption = "DOC_ID"
        Me.colnDOC_ID.FieldName = "DOC_ID"
        Me.colnDOC_ID.Name = "colnDOC_ID"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(3, 35)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(48, 13)
        Me.LabelControl3.TabIndex = 5
        Me.LabelControl3.Text = "Enlazadas"
        '
        'gridEnlazados
        '
        Me.gridEnlazados.Cursor = System.Windows.Forms.Cursors.Default
        Me.gridEnlazados.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridEnlazados.Location = New System.Drawing.Point(0, 31)
        Me.gridEnlazados.MainView = Me.gridViewEnlazados
        Me.gridEnlazados.MenuManager = Me.barManagerHeader
        Me.gridEnlazados.Name = "gridEnlazados"
        Me.gridEnlazados.Size = New System.Drawing.Size(1208, 215)
        Me.gridEnlazados.TabIndex = 0
        Me.gridEnlazados.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridViewEnlazados})
        '
        'gridViewEnlazados
        '
        Me.gridViewEnlazados.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colTRANS_ID, Me.colLICENSE_IDAso, Me.colEMATERIAL_CODE, Me.colEMATERIAL_DESCRIPTION, Me.colEQTY_TRANS, Me.colLINENO_POLIZA, Me.colESKU_DESCRIPTION, Me.colEQTY_POLIZA, Me.colEBULTOS_POLIZA, Me.colQtyAso, Me.colAsoDOC_ID})
        Me.gridViewEnlazados.GridControl = Me.gridEnlazados
        Me.gridViewEnlazados.Name = "gridViewEnlazados"
        Me.gridViewEnlazados.OptionsSelection.MultiSelect = true
        '
        'colTRANS_ID
        '
        Me.colTRANS_ID.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(CType(CType(192,Byte),Integer), CType(CType(255,Byte),Integer), CType(CType(192,Byte),Integer))
        Me.colTRANS_ID.AppearanceCell.Options.UseBackColor = true
        Me.colTRANS_ID.Caption = "Trasaccion"
        Me.colTRANS_ID.FieldName = "TRANS_ID"
        Me.colTRANS_ID.Name = "colTRANS_ID"
        Me.colTRANS_ID.OptionsColumn.AllowEdit = false
        Me.colTRANS_ID.OptionsColumn.AllowFocus = false
        Me.colTRANS_ID.Visible = true
        Me.colTRANS_ID.VisibleIndex = 0
        '
        'colLICENSE_IDAso
        '
        Me.colLICENSE_IDAso.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(CType(CType(192,Byte),Integer), CType(CType(255,Byte),Integer), CType(CType(192,Byte),Integer))
        Me.colLICENSE_IDAso.AppearanceCell.Options.UseBackColor = true
        Me.colLICENSE_IDAso.Caption = "Licencia"
        Me.colLICENSE_IDAso.FieldName = "LICENSE_ID"
        Me.colLICENSE_IDAso.Name = "colLICENSE_IDAso"
        Me.colLICENSE_IDAso.OptionsColumn.AllowEdit = false
        Me.colLICENSE_IDAso.OptionsColumn.AllowFocus = false
        Me.colLICENSE_IDAso.Visible = true
        Me.colLICENSE_IDAso.VisibleIndex = 1
        '
        'colEMATERIAL_CODE
        '
        Me.colEMATERIAL_CODE.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(CType(CType(192,Byte),Integer), CType(CType(255,Byte),Integer), CType(CType(192,Byte),Integer))
        Me.colEMATERIAL_CODE.AppearanceCell.Options.UseBackColor = true
        Me.colEMATERIAL_CODE.Caption = "Codigo Material"
        Me.colEMATERIAL_CODE.FieldName = "MATERIAL_CODE"
        Me.colEMATERIAL_CODE.Name = "colEMATERIAL_CODE"
        Me.colEMATERIAL_CODE.OptionsColumn.AllowEdit = false
        Me.colEMATERIAL_CODE.OptionsColumn.AllowFocus = false
        Me.colEMATERIAL_CODE.Visible = true
        Me.colEMATERIAL_CODE.VisibleIndex = 2
        '
        'colEMATERIAL_DESCRIPTION
        '
        Me.colEMATERIAL_DESCRIPTION.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(CType(CType(192,Byte),Integer), CType(CType(255,Byte),Integer), CType(CType(192,Byte),Integer))
        Me.colEMATERIAL_DESCRIPTION.AppearanceCell.Options.UseBackColor = true
        Me.colEMATERIAL_DESCRIPTION.Caption = "Nombre Material"
        Me.colEMATERIAL_DESCRIPTION.FieldName = "MATERIAL_DESCRIPTION"
        Me.colEMATERIAL_DESCRIPTION.Name = "colEMATERIAL_DESCRIPTION"
        Me.colEMATERIAL_DESCRIPTION.OptionsColumn.AllowEdit = false
        Me.colEMATERIAL_DESCRIPTION.OptionsColumn.AllowFocus = false
        Me.colEMATERIAL_DESCRIPTION.Visible = true
        Me.colEMATERIAL_DESCRIPTION.VisibleIndex = 3
        '
        'colEQTY_TRANS
        '
        Me.colEQTY_TRANS.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(CType(CType(192,Byte),Integer), CType(CType(255,Byte),Integer), CType(CType(192,Byte),Integer))
        Me.colEQTY_TRANS.AppearanceCell.Options.UseBackColor = true
        Me.colEQTY_TRANS.Caption = "Cantidad Transaccion"
        Me.colEQTY_TRANS.DisplayFormat.FormatString = "#,##0.0000"
        Me.colEQTY_TRANS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colEQTY_TRANS.FieldName = "QTY_TRANS"
        Me.colEQTY_TRANS.Name = "colEQTY_TRANS"
        Me.colEQTY_TRANS.OptionsColumn.AllowEdit = false
        Me.colEQTY_TRANS.OptionsColumn.AllowFocus = false
        Me.colEQTY_TRANS.Visible = true
        Me.colEQTY_TRANS.VisibleIndex = 4
        '
        'colLINENO_POLIZA
        '
        Me.colLINENO_POLIZA.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(CType(CType(192,Byte),Integer), CType(CType(255,Byte),Integer), CType(CType(255,Byte),Integer))
        Me.colLINENO_POLIZA.AppearanceCell.Options.UseBackColor = true
        Me.colLINENO_POLIZA.Caption = "Linea"
        Me.colLINENO_POLIZA.FieldName = "LINENO_POLIZA"
        Me.colLINENO_POLIZA.Name = "colLINENO_POLIZA"
        Me.colLINENO_POLIZA.OptionsColumn.AllowEdit = false
        Me.colLINENO_POLIZA.OptionsColumn.AllowFocus = false
        Me.colLINENO_POLIZA.Visible = true
        Me.colLINENO_POLIZA.VisibleIndex = 5
        '
        'colESKU_DESCRIPTION
        '
        Me.colESKU_DESCRIPTION.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(CType(CType(192,Byte),Integer), CType(CType(255,Byte),Integer), CType(CType(255,Byte),Integer))
        Me.colESKU_DESCRIPTION.AppearanceCell.Options.UseBackColor = true
        Me.colESKU_DESCRIPTION.Caption = "Descripcion Material"
        Me.colESKU_DESCRIPTION.FieldName = "SKU_DESCRIPTION"
        Me.colESKU_DESCRIPTION.Name = "colESKU_DESCRIPTION"
        Me.colESKU_DESCRIPTION.OptionsColumn.AllowEdit = false
        Me.colESKU_DESCRIPTION.OptionsColumn.AllowFocus = false
        Me.colESKU_DESCRIPTION.Visible = true
        Me.colESKU_DESCRIPTION.VisibleIndex = 6
        '
        'colEQTY_POLIZA
        '
        Me.colEQTY_POLIZA.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(CType(CType(192,Byte),Integer), CType(CType(255,Byte),Integer), CType(CType(255,Byte),Integer))
        Me.colEQTY_POLIZA.AppearanceCell.Options.UseBackColor = true
        Me.colEQTY_POLIZA.Caption = "Cantidad Poliza"
        Me.colEQTY_POLIZA.DisplayFormat.FormatString = "#,##0.0000"
        Me.colEQTY_POLIZA.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colEQTY_POLIZA.FieldName = "QTY_POLIZA"
        Me.colEQTY_POLIZA.Name = "colEQTY_POLIZA"
        Me.colEQTY_POLIZA.OptionsColumn.AllowEdit = false
        Me.colEQTY_POLIZA.OptionsColumn.AllowFocus = false
        Me.colEQTY_POLIZA.Visible = true
        Me.colEQTY_POLIZA.VisibleIndex = 7
        '
        'colEBULTOS_POLIZA
        '
        Me.colEBULTOS_POLIZA.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(CType(CType(192,Byte),Integer), CType(CType(255,Byte),Integer), CType(CType(255,Byte),Integer))
        Me.colEBULTOS_POLIZA.AppearanceCell.Options.UseBackColor = true
        Me.colEBULTOS_POLIZA.Caption = "Bultos"
        Me.colEBULTOS_POLIZA.DisplayFormat.FormatString = "#,##0.0000"
        Me.colEBULTOS_POLIZA.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colEBULTOS_POLIZA.FieldName = "BULTOS_POLIZA"
        Me.colEBULTOS_POLIZA.Name = "colEBULTOS_POLIZA"
        Me.colEBULTOS_POLIZA.OptionsColumn.AllowEdit = false
        Me.colEBULTOS_POLIZA.OptionsColumn.AllowFocus = false
        Me.colEBULTOS_POLIZA.Visible = true
        Me.colEBULTOS_POLIZA.VisibleIndex = 8
        '
        'colQtyAso
        '
        Me.colQtyAso.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(255,Byte),Integer), CType(CType(192,Byte),Integer))
        Me.colQtyAso.AppearanceCell.Options.UseBackColor = true
        Me.colQtyAso.Caption = "Cantidad"
        Me.colQtyAso.DisplayFormat.FormatString = "#,##0.0000"
        Me.colQtyAso.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colQtyAso.FieldName = "QTY"
        Me.colQtyAso.Name = "colQtyAso"
        Me.colQtyAso.Visible = true
        Me.colQtyAso.VisibleIndex = 9
        '
        'colAsoDOC_ID
        '
        Me.colAsoDOC_ID.Caption = "DOC_ID"
        Me.colAsoDOC_ID.FieldName = "DOC_ID"
        Me.colAsoDOC_ID.Name = "colAsoDOC_ID"
        '
        'BarDockControl7
        '
        Me.BarDockControl7.CausesValidation = false
        Me.BarDockControl7.Dock = System.Windows.Forms.DockStyle.Left
        Me.BarDockControl7.Location = New System.Drawing.Point(0, 31)
        Me.BarDockControl7.Size = New System.Drawing.Size(0, 215)
        '
        'BarDockControl8
        '
        Me.BarDockControl8.CausesValidation = false
        Me.BarDockControl8.Dock = System.Windows.Forms.DockStyle.Right
        Me.BarDockControl8.Location = New System.Drawing.Point(1208, 31)
        Me.BarDockControl8.Size = New System.Drawing.Size(0, 215)
        '
        'BarDockControl6
        '
        Me.BarDockControl6.CausesValidation = false
        Me.BarDockControl6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarDockControl6.Location = New System.Drawing.Point(0, 246)
        Me.BarDockControl6.Size = New System.Drawing.Size(1208, 0)
        '
        'BarDockControl5
        '
        Me.BarDockControl5.CausesValidation = false
        Me.BarDockControl5.Dock = System.Windows.Forms.DockStyle.Top
        Me.BarDockControl5.Location = New System.Drawing.Point(0, 0)
        Me.BarDockControl5.Size = New System.Drawing.Size(1208, 31)
        '
        'BarDockControl3
        '
        Me.BarDockControl3.CausesValidation = false
        Me.BarDockControl3.Dock = System.Windows.Forms.DockStyle.Left
        Me.BarDockControl3.Location = New System.Drawing.Point(0, 31)
        Me.BarDockControl3.Size = New System.Drawing.Size(0, 531)
        '
        'BarDockControl4
        '
        Me.BarDockControl4.CausesValidation = false
        Me.BarDockControl4.Dock = System.Windows.Forms.DockStyle.Right
        Me.BarDockControl4.Location = New System.Drawing.Point(1208, 31)
        Me.BarDockControl4.Size = New System.Drawing.Size(0, 531)
        '
        'BarDockControl2
        '
        Me.BarDockControl2.CausesValidation = false
        Me.BarDockControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarDockControl2.Location = New System.Drawing.Point(0, 562)
        Me.BarDockControl2.Size = New System.Drawing.Size(1208, 0)
        '
        'BarDockControl1
        '
        Me.BarDockControl1.CausesValidation = false
        Me.BarDockControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.BarDockControl1.Location = New System.Drawing.Point(0, 0)
        Me.BarDockControl1.Size = New System.Drawing.Size(1208, 31)
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
        Me.Bar1.OptionsBar.AllowQuickCustomization = false
        Me.Bar1.OptionsBar.DrawDragBorder = false
        Me.Bar1.OptionsBar.UseWholeRow = true
        Me.Bar1.Text = "Herramientas"
        '
        'btnEnlazar
        '
        Me.btnEnlazar.Caption = "Enlazar"
        Me.btnEnlazar.Glyph = CType(resources.GetObject("btnEnlazar.Glyph"),System.Drawing.Image)
        Me.btnEnlazar.Id = 0
        Me.btnEnlazar.LargeGlyph = CType(resources.GetObject("btnEnlazar.LargeGlyph"),System.Drawing.Image)
        Me.btnEnlazar.Name = "btnEnlazar"
        '
        'txtComentario3
        '
        Me.txtComentario3.Caption = "Comentario"
        Me.txtComentario3.Edit = Me.RepositoryItemMemoEdit3
        Me.txtComentario3.EditWidth = 800
        Me.txtComentario3.Glyph = CType(resources.GetObject("txtComentario3.Glyph"),System.Drawing.Image)
        Me.txtComentario3.Id = 4
        Me.txtComentario3.LargeGlyph = CType(resources.GetObject("txtComentario3.LargeGlyph"),System.Drawing.Image)
        Me.txtComentario3.Name = "txtComentario3"
        '
        'RepositoryItemMemoEdit3
        '
        Me.RepositoryItemMemoEdit3.Name = "RepositoryItemMemoEdit3"
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
        Me.RepositoryItemMemoExEdit1.AutoHeight = false
        Me.RepositoryItemMemoExEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemMemoExEdit1.Name = "RepositoryItemMemoExEdit1"
        '
        'txtComentario
        '
        Me.txtComentario.Caption = "Comentario"
        Me.txtComentario.Edit = Me.RepositoryItemMemoEdit1
        Me.txtComentario.EditWidth = 500
        Me.txtComentario.Glyph = CType(resources.GetObject("txtComentario.Glyph"),System.Drawing.Image)
        Me.txtComentario.Id = 3
        Me.txtComentario.LargeGlyph = CType(resources.GetObject("txtComentario.LargeGlyph"),System.Drawing.Image)
        Me.txtComentario.Name = "txtComentario"
        '
        'RepositoryItemMemoEdit1
        '
        Me.RepositoryItemMemoEdit1.Name = "RepositoryItemMemoEdit1"
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
        Me.Bar2.OptionsBar.AllowQuickCustomization = false
        Me.Bar2.OptionsBar.DrawDragBorder = false
        Me.Bar2.OptionsBar.UseWholeRow = true
        Me.Bar2.Text = "Herramientas"
        '
        'btnBorrorAso
        '
        Me.btnBorrorAso.Caption = "Eliminar"
        Me.btnBorrorAso.Glyph = CType(resources.GetObject("btnBorrorAso.Glyph"),System.Drawing.Image)
        Me.btnBorrorAso.Id = 2
        Me.btnBorrorAso.LargeGlyph = CType(resources.GetObject("btnBorrorAso.LargeGlyph"),System.Drawing.Image)
        Me.btnBorrorAso.Name = "btnBorrorAso"
        '
        'btnExpandirAsociados
        '
        Me.btnExpandirAsociados.Caption = "Expadir"
        Me.btnExpandirAsociados.Glyph = CType(resources.GetObject("btnExpandirAsociados.Glyph"),System.Drawing.Image)
        Me.btnExpandirAsociados.Id = 3
        Me.btnExpandirAsociados.LargeGlyph = CType(resources.GetObject("btnExpandirAsociados.LargeGlyph"),System.Drawing.Image)
        Me.btnExpandirAsociados.Name = "btnExpandirAsociados"
        '
        'btnContraerAsociados
        '
        Me.btnContraerAsociados.Caption = "Contraer"
        Me.btnContraerAsociados.Glyph = CType(resources.GetObject("btnContraerAsociados.Glyph"),System.Drawing.Image)
        Me.btnContraerAsociados.Id = 4
        Me.btnContraerAsociados.LargeGlyph = CType(resources.GetObject("btnContraerAsociados.LargeGlyph"),System.Drawing.Image)
        Me.btnContraerAsociados.Name = "btnContraerAsociados"
        '
        'barConfirAsociacion
        '
        Me.barConfirAsociacion.Caption = "Confirma Asociación"
        Me.barConfirAsociacion.Glyph = CType(resources.GetObject("barConfirAsociacion.Glyph"),System.Drawing.Image)
        Me.barConfirAsociacion.Id = 5
        Me.barConfirAsociacion.LargeGlyph = CType(resources.GetObject("barConfirAsociacion.LargeGlyph"),System.Drawing.Image)
        Me.barConfirAsociacion.Name = "barConfirAsociacion"
        Me.barConfirAsociacion.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'btnCancelarAso
        '
        Me.btnCancelarAso.Caption = "Cancelar Asociación"
        Me.btnCancelarAso.Glyph = CType(resources.GetObject("btnCancelarAso.Glyph"),System.Drawing.Image)
        Me.btnCancelarAso.Id = 7
        Me.btnCancelarAso.LargeGlyph = CType(resources.GetObject("btnCancelarAso.LargeGlyph"),System.Drawing.Image)
        Me.btnCancelarAso.Name = "btnCancelarAso"
        Me.btnCancelarAso.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
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
        Me.RepositoryItemFontEdit1.AutoHeight = false
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
        Me.RepositoryItemImageEdit1.AutoHeight = false
        Me.RepositoryItemImageEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemImageEdit1.Name = "RepositoryItemImageEdit1"
        '
        'txtComentario2
        '
        Me.txtComentario2.Caption = "Comentario"
        Me.txtComentario2.Edit = Me.RepositoryItemMemoEdit2
        Me.txtComentario2.EditWidth = 300
        Me.txtComentario2.Glyph = CType(resources.GetObject("txtComentario2.Glyph"),System.Drawing.Image)
        Me.txtComentario2.Id = 8
        Me.txtComentario2.LargeGlyph = CType(resources.GetObject("txtComentario2.LargeGlyph"),System.Drawing.Image)
        Me.txtComentario2.Name = "txtComentario2"
        '
        'RepositoryItemMemoEdit2
        '
        Me.RepositoryItemMemoEdit2.Name = "RepositoryItemMemoEdit2"
        '
        'FrmAprobacionFiscal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1214, 590)
        Me.Controls.Add(Me.tabPolizas)
        Me.Name = "FrmAprobacionFiscal"
        Me.Text = "Aprobacion Fiscal"
        CType(Me.RepositoryItemTextEdit5,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.tabPolizas,System.ComponentModel.ISupportInitialize).EndInit
        Me.tabPolizas.ResumeLayout(false)
        Me.tabHeader.ResumeLayout(false)
        Me.tabHeader.PerformLayout
        CType(Me.gridPolizas,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.gridViewPolizas,System.ComponentModel.ISupportInitialize).EndInit
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
        Me.tabDet.ResumeLayout(false)
        Me.tabDet.PerformLayout
        CType(Me.SplitContainerControl2,System.ComponentModel.ISupportInitialize).EndInit
        Me.SplitContainerControl2.ResumeLayout(false)
        CType(Me.SplitContainerControl1,System.ComponentModel.ISupportInitialize).EndInit
        Me.SplitContainerControl1.ResumeLayout(false)
        CType(Me.gridLicencias,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.gridViewLicencias,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.gridLienas,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.gridViewLineas,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.gridEnlazados,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.gridViewEnlazados,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.barManagerDet,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.RepositoryItemMemoEdit3,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.RepositoryItemMemoExEdit1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.RepositoryItemMemoEdit1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.barManagerDetEnlazados,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.RepositoryItemFontEdit1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.RepositoryItemImageEdit1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.RepositoryItemMemoEdit2,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

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
End Class
