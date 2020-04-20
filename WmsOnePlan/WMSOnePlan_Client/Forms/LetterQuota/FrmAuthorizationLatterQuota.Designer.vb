<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAuthorizationLatterQuota
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
        Dim StyleFormatCondition3 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Me.colSTATUS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryIsLogged = New DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup()
        Me.colMERCHANDISE_DESCRIPTION = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colDOC_ID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPOLIZAS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCLAVE_ADUANA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNOMBRE_ADUANA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNO_FACTURA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMERCHANDISE_QTY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMERCHANDISE_VALUE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBL_NUMBER = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCONTAINER_NUMBER = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCLAVE_AGENTE_ADUANERO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNOMBRE_AGENTE_ADUANERO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNOMBRE_CONSIGNATARIO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNIT_CONSIGNATARIO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDOMICILIO_FISCAL_CONSIGNATARIO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRELATED_CLIENT_CODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCLIENT_NAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colLAST_UPDATED = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colEMAIL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRegimen = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMedida = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFirma = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.coladuana = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UiColPuesto = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar1 = New DevExpress.XtraBars.Bar()
        Me.btnAutorizar = New DevExpress.XtraBars.BarButtonItem()
        Me.btnEnSitio = New DevExpress.XtraBars.BarButtonItem()
        Me.BarBtnParam = New DevExpress.XtraBars.BarButtonItem()
        Me.btnPrint = New DevExpress.XtraBars.BarButtonItem()
        Me.chkIncluirAutorizados = New DevExpress.XtraBars.BarToggleSwitchItem()
        Me.chkIncluirEnsSitio = New DevExpress.XtraBars.BarToggleSwitchItem()
        Me.dtFechaInicio = New DevExpress.XtraBars.BarEditItem()
        Me.RepositoryItemDateEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.dtFechaFinal = New DevExpress.XtraBars.BarEditItem()
        Me.RepositoryItemDateEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.btnRefresh1 = New DevExpress.XtraBars.BarButtonItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.BarCheckItem1 = New DevExpress.XtraBars.BarCheckItem()
        Me.BarEditItem1 = New DevExpress.XtraBars.BarEditItem()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.btnRefresh = New DevExpress.XtraBars.BarButtonItem()
        Me.BarBtnParametros = New DevExpress.XtraBars.BarButtonItem()
        Me.DataWindow = New System.Windows.Forms.GroupBox()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.BtnReset = New System.Windows.Forms.Button()
        Me.TxtCarta = New System.Windows.Forms.TextBox()
        Me.LblCarta = New System.Windows.Forms.Label()
        Me.BtnPrintCupo = New System.Windows.Forms.Button()
        Me.TxtFirma = New System.Windows.Forms.TextBox()
        Me.TxtMedida = New System.Windows.Forms.TextBox()
        Me.TxtPoliza = New System.Windows.Forms.TextBox()
        Me.LblFirma = New System.Windows.Forms.Label()
        Me.LblMedida = New System.Windows.Forms.Label()
        Me.LblPoliza = New System.Windows.Forms.Label()
        Me.dxerror = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.UiTextoPuesto = New System.Windows.Forms.TextBox()
        Me.UiEtiquetaPuesto = New System.Windows.Forms.Label()
        CType(Me.RepositoryIsLogged,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.GridControl1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.GridView1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.BarManager1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.RepositoryItemDateEdit1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.RepositoryItemDateEdit1.CalendarTimeProperties,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.RepositoryItemDateEdit2,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.RepositoryItemDateEdit2.CalendarTimeProperties,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.RepositoryItemTextEdit1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.DataWindow.SuspendLayout
        CType(Me.dxerror,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'colSTATUS
        '
        Me.colSTATUS.Caption = "Estado"
        Me.colSTATUS.FieldName = "STATUS"
        Me.colSTATUS.Name = "colSTATUS"
        Me.colSTATUS.OptionsColumn.AllowEdit = false
        Me.colSTATUS.OptionsColumn.AllowFocus = false
        Me.colSTATUS.Visible = true
        Me.colSTATUS.VisibleIndex = 15
        '
        'RepositoryIsLogged
        '
        Me.RepositoryIsLogged.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.RepositoryIsLogged.ExportMode = DevExpress.XtraEditors.Repository.ExportMode.Value
        Me.RepositoryIsLogged.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem(1, "LogIn"), New DevExpress.XtraEditors.Controls.RadioGroupItem(0, "LogOut")})
        Me.RepositoryIsLogged.Name = "RepositoryIsLogged"
        Me.RepositoryIsLogged.NullText = "1"
        '
        'colMERCHANDISE_DESCRIPTION
        '
        Me.colMERCHANDISE_DESCRIPTION.Caption = "Descripcion Mercaderia"
        Me.colMERCHANDISE_DESCRIPTION.FieldName = "MERCHANDISE_DESCRIPTION"
        Me.colMERCHANDISE_DESCRIPTION.Name = "colMERCHANDISE_DESCRIPTION"
        Me.colMERCHANDISE_DESCRIPTION.OptionsColumn.AllowEdit = false
        Me.colMERCHANDISE_DESCRIPTION.OptionsColumn.AllowFocus = false
        Me.colMERCHANDISE_DESCRIPTION.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.List
        Me.colMERCHANDISE_DESCRIPTION.Visible = true
        Me.colMERCHANDISE_DESCRIPTION.VisibleIndex = 6
        Me.colMERCHANDISE_DESCRIPTION.Width = 67
        '
        'GridControl1
        '
        Me.GridControl1.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.Location = New System.Drawing.Point(0, 33)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryIsLogged})
        Me.GridControl1.Size = New System.Drawing.Size(1139, 582)
        Me.GridControl1.TabIndex = 17
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colDOC_ID, Me.colPOLIZAS, Me.colCLAVE_ADUANA, Me.colNOMBRE_ADUANA, Me.colNO_FACTURA, Me.colMERCHANDISE_DESCRIPTION, Me.colMERCHANDISE_QTY, Me.colMERCHANDISE_VALUE, Me.colBL_NUMBER, Me.colCONTAINER_NUMBER, Me.colCLAVE_AGENTE_ADUANERO, Me.colNOMBRE_AGENTE_ADUANERO, Me.colNOMBRE_CONSIGNATARIO, Me.colNIT_CONSIGNATARIO, Me.colDOMICILIO_FISCAL_CONSIGNATARIO, Me.colRELATED_CLIENT_CODE, Me.colCLIENT_NAME, Me.colSTATUS, Me.colLAST_UPDATED, Me.colEMAIL, Me.colRegimen, Me.colMedida, Me.colFirma, Me.coladuana, Me.UiColPuesto})
        Me.GridView1.CustomizationFormBounds = New System.Drawing.Rectangle(984, 556, 210, 172)
        StyleFormatCondition1.Appearance.BackColor = System.Drawing.Color.Yellow
        StyleFormatCondition1.Appearance.Options.UseBackColor = true
        StyleFormatCondition1.Column = Me.colSTATUS
        StyleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression
        StyleFormatCondition1.Expression = "[STATUS] = 'SOLICITADA'"
        StyleFormatCondition2.Appearance.BackColor = System.Drawing.Color.Lime
        StyleFormatCondition2.Appearance.Options.UseBackColor = true
        StyleFormatCondition2.Column = Me.colSTATUS
        StyleFormatCondition2.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression
        StyleFormatCondition2.Expression = "[STATUS] = 'AUTORIZADA'"
        StyleFormatCondition3.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(128,Byte),Integer), CType(CType(128,Byte),Integer), CType(CType(255,Byte),Integer))
        StyleFormatCondition3.Appearance.Options.UseBackColor = true
        StyleFormatCondition3.Column = Me.colSTATUS
        StyleFormatCondition3.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression
        StyleFormatCondition3.Expression = "[STATUS] = 'EN_SITIO'"
        Me.GridView1.FormatConditions.AddRange(New DevExpress.XtraGrid.StyleFormatCondition() {StyleFormatCondition1, StyleFormatCondition2, StyleFormatCondition3})
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.GroupCount = 1
        Me.GridView1.GroupPanelText = "Organizar por columna"
        Me.GridView1.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "LOGIN_ID", Nothing, "")})
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.MultiSelect = true
        Me.GridView1.OptionsView.AnimationType = DevExpress.XtraGrid.Views.Base.GridAnimationType.AnimateFocusedItem
        Me.GridView1.OptionsView.ShowAutoFilterRow = true
        Me.GridView1.OptionsView.ShowFooter = true
        Me.GridView1.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.colCLIENT_NAME, DevExpress.Data.ColumnSortOrder.Ascending)})
        Me.GridView1.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never
        Me.GridView1.ViewCaption = "Clientes"
        '
        'colDOC_ID
        '
        Me.colDOC_ID.Caption = "No. Carta Cupo"
        Me.colDOC_ID.FieldName = "DOC_ID"
        Me.colDOC_ID.Name = "colDOC_ID"
        Me.colDOC_ID.OptionsColumn.AllowEdit = false
        Me.colDOC_ID.OptionsColumn.AllowFocus = false
        Me.colDOC_ID.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList
        Me.colDOC_ID.Visible = true
        Me.colDOC_ID.VisibleIndex = 0
        Me.colDOC_ID.Width = 50
        '
        'colPOLIZAS
        '
        Me.colPOLIZAS.Caption = "Poliza"
        Me.colPOLIZAS.FieldName = "POLIZAS"
        Me.colPOLIZAS.Name = "colPOLIZAS"
        Me.colPOLIZAS.OptionsColumn.AllowEdit = false
        Me.colPOLIZAS.OptionsColumn.AllowFocus = false
        Me.colPOLIZAS.OptionsColumn.FixedWidth = true
        Me.colPOLIZAS.OptionsColumn.ReadOnly = true
        Me.colPOLIZAS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)})
        Me.colPOLIZAS.Visible = true
        Me.colPOLIZAS.VisibleIndex = 2
        '
        'colCLAVE_ADUANA
        '
        Me.colCLAVE_ADUANA.Caption = "Clave Aduana"
        Me.colCLAVE_ADUANA.FieldName = "CLAVE_ADUANA"
        Me.colCLAVE_ADUANA.Name = "colCLAVE_ADUANA"
        Me.colCLAVE_ADUANA.OptionsColumn.AllowEdit = false
        Me.colCLAVE_ADUANA.OptionsColumn.AllowFocus = false
        Me.colCLAVE_ADUANA.OptionsColumn.ReadOnly = true
        Me.colCLAVE_ADUANA.Visible = true
        Me.colCLAVE_ADUANA.VisibleIndex = 3
        Me.colCLAVE_ADUANA.Width = 67
        '
        'colNOMBRE_ADUANA
        '
        Me.colNOMBRE_ADUANA.Caption = "Nombre Aduana"
        Me.colNOMBRE_ADUANA.FieldName = "NOMBRE_ADUANA"
        Me.colNOMBRE_ADUANA.Name = "colNOMBRE_ADUANA"
        Me.colNOMBRE_ADUANA.OptionsColumn.AllowEdit = false
        Me.colNOMBRE_ADUANA.OptionsColumn.AllowFocus = false
        Me.colNOMBRE_ADUANA.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[True]
        Me.colNOMBRE_ADUANA.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.colNOMBRE_ADUANA.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.List
        Me.colNOMBRE_ADUANA.Visible = true
        Me.colNOMBRE_ADUANA.VisibleIndex = 4
        Me.colNOMBRE_ADUANA.Width = 67
        '
        'colNO_FACTURA
        '
        Me.colNO_FACTURA.Caption = "No. Factura"
        Me.colNO_FACTURA.FieldName = "NO_FACTURA"
        Me.colNO_FACTURA.Name = "colNO_FACTURA"
        Me.colNO_FACTURA.OptionsColumn.AllowEdit = false
        Me.colNO_FACTURA.OptionsColumn.AllowFocus = false
        Me.colNO_FACTURA.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.List
        Me.colNO_FACTURA.Visible = true
        Me.colNO_FACTURA.VisibleIndex = 5
        Me.colNO_FACTURA.Width = 67
        '
        'colMERCHANDISE_QTY
        '
        Me.colMERCHANDISE_QTY.Caption = "Cantidad"
        Me.colMERCHANDISE_QTY.FieldName = "MERCHANDISE_QTY"
        Me.colMERCHANDISE_QTY.Name = "colMERCHANDISE_QTY"
        Me.colMERCHANDISE_QTY.OptionsColumn.AllowEdit = false
        Me.colMERCHANDISE_QTY.OptionsColumn.AllowFocus = false
        Me.colMERCHANDISE_QTY.OptionsColumn.ReadOnly = true
        Me.colMERCHANDISE_QTY.Visible = true
        Me.colMERCHANDISE_QTY.VisibleIndex = 1
        Me.colMERCHANDISE_QTY.Width = 69
        '
        'colMERCHANDISE_VALUE
        '
        Me.colMERCHANDISE_VALUE.Caption = "Valor"
        Me.colMERCHANDISE_VALUE.FieldName = "MERCHANDISE_VALUE"
        Me.colMERCHANDISE_VALUE.Name = "colMERCHANDISE_VALUE"
        Me.colMERCHANDISE_VALUE.OptionsColumn.AllowEdit = false
        Me.colMERCHANDISE_VALUE.OptionsColumn.AllowFocus = false
        Me.colMERCHANDISE_VALUE.Visible = true
        Me.colMERCHANDISE_VALUE.VisibleIndex = 7
        Me.colMERCHANDISE_VALUE.Width = 69
        '
        'colBL_NUMBER
        '
        Me.colBL_NUMBER.Caption = "BL"
        Me.colBL_NUMBER.FieldName = "BL_NUMBER"
        Me.colBL_NUMBER.Name = "colBL_NUMBER"
        Me.colBL_NUMBER.OptionsColumn.AllowEdit = false
        Me.colBL_NUMBER.OptionsColumn.AllowFocus = false
        Me.colBL_NUMBER.Visible = true
        Me.colBL_NUMBER.VisibleIndex = 8
        Me.colBL_NUMBER.Width = 69
        '
        'colCONTAINER_NUMBER
        '
        Me.colCONTAINER_NUMBER.Caption = "Contenedor"
        Me.colCONTAINER_NUMBER.FieldName = "CONTAINER_NUMBER"
        Me.colCONTAINER_NUMBER.Name = "colCONTAINER_NUMBER"
        Me.colCONTAINER_NUMBER.OptionsColumn.AllowEdit = false
        Me.colCONTAINER_NUMBER.OptionsColumn.AllowFocus = false
        Me.colCONTAINER_NUMBER.Visible = true
        Me.colCONTAINER_NUMBER.VisibleIndex = 9
        Me.colCONTAINER_NUMBER.Width = 69
        '
        'colCLAVE_AGENTE_ADUANERO
        '
        Me.colCLAVE_AGENTE_ADUANERO.Caption = "Clave Agente Aduanero"
        Me.colCLAVE_AGENTE_ADUANERO.FieldName = "CLAVE_AGENTE_ADUANERO"
        Me.colCLAVE_AGENTE_ADUANERO.Name = "colCLAVE_AGENTE_ADUANERO"
        Me.colCLAVE_AGENTE_ADUANERO.OptionsColumn.AllowEdit = false
        Me.colCLAVE_AGENTE_ADUANERO.OptionsColumn.AllowFocus = false
        Me.colCLAVE_AGENTE_ADUANERO.Visible = true
        Me.colCLAVE_AGENTE_ADUANERO.VisibleIndex = 10
        Me.colCLAVE_AGENTE_ADUANERO.Width = 69
        '
        'colNOMBRE_AGENTE_ADUANERO
        '
        Me.colNOMBRE_AGENTE_ADUANERO.Caption = "Nombre Agente Aduanero"
        Me.colNOMBRE_AGENTE_ADUANERO.FieldName = "NOMBRE_AGENTE_ADUANERO"
        Me.colNOMBRE_AGENTE_ADUANERO.Name = "colNOMBRE_AGENTE_ADUANERO"
        Me.colNOMBRE_AGENTE_ADUANERO.OptionsColumn.AllowEdit = false
        Me.colNOMBRE_AGENTE_ADUANERO.OptionsColumn.AllowFocus = false
        Me.colNOMBRE_AGENTE_ADUANERO.Visible = true
        Me.colNOMBRE_AGENTE_ADUANERO.VisibleIndex = 11
        Me.colNOMBRE_AGENTE_ADUANERO.Width = 69
        '
        'colNOMBRE_CONSIGNATARIO
        '
        Me.colNOMBRE_CONSIGNATARIO.Caption = "Nombre Consignatario"
        Me.colNOMBRE_CONSIGNATARIO.FieldName = "NOMBRE_CONSIGNATARIO"
        Me.colNOMBRE_CONSIGNATARIO.Name = "colNOMBRE_CONSIGNATARIO"
        Me.colNOMBRE_CONSIGNATARIO.OptionsColumn.AllowEdit = false
        Me.colNOMBRE_CONSIGNATARIO.OptionsColumn.AllowFocus = false
        Me.colNOMBRE_CONSIGNATARIO.Visible = true
        Me.colNOMBRE_CONSIGNATARIO.VisibleIndex = 12
        Me.colNOMBRE_CONSIGNATARIO.Width = 69
        '
        'colNIT_CONSIGNATARIO
        '
        Me.colNIT_CONSIGNATARIO.Caption = "Nit Consignatario"
        Me.colNIT_CONSIGNATARIO.FieldName = "NIT_CONSIGNATARIO"
        Me.colNIT_CONSIGNATARIO.Name = "colNIT_CONSIGNATARIO"
        Me.colNIT_CONSIGNATARIO.OptionsColumn.AllowEdit = false
        Me.colNIT_CONSIGNATARIO.OptionsColumn.AllowFocus = false
        Me.colNIT_CONSIGNATARIO.Visible = true
        Me.colNIT_CONSIGNATARIO.VisibleIndex = 13
        Me.colNIT_CONSIGNATARIO.Width = 69
        '
        'colDOMICILIO_FISCAL_CONSIGNATARIO
        '
        Me.colDOMICILIO_FISCAL_CONSIGNATARIO.Caption = "Dominio Fiscal del Consignatario"
        Me.colDOMICILIO_FISCAL_CONSIGNATARIO.FieldName = "DOMICILIO_FISCAL_CONSIGNATARIO"
        Me.colDOMICILIO_FISCAL_CONSIGNATARIO.Name = "colDOMICILIO_FISCAL_CONSIGNATARIO"
        Me.colDOMICILIO_FISCAL_CONSIGNATARIO.OptionsColumn.AllowEdit = false
        Me.colDOMICILIO_FISCAL_CONSIGNATARIO.OptionsColumn.AllowFocus = false
        Me.colDOMICILIO_FISCAL_CONSIGNATARIO.Visible = true
        Me.colDOMICILIO_FISCAL_CONSIGNATARIO.VisibleIndex = 14
        Me.colDOMICILIO_FISCAL_CONSIGNATARIO.Width = 101
        '
        'colRELATED_CLIENT_CODE
        '
        Me.colRELATED_CLIENT_CODE.Caption = "Codigo Cliente"
        Me.colRELATED_CLIENT_CODE.FieldName = "RELATED_CLIENT_CODE"
        Me.colRELATED_CLIENT_CODE.Name = "colRELATED_CLIENT_CODE"
        Me.colRELATED_CLIENT_CODE.OptionsColumn.AllowEdit = false
        Me.colRELATED_CLIENT_CODE.OptionsColumn.AllowFocus = false
        '
        'colCLIENT_NAME
        '
        Me.colCLIENT_NAME.Caption = "Nombre Cliente"
        Me.colCLIENT_NAME.FieldName = "CLIENT_NAME"
        Me.colCLIENT_NAME.Name = "colCLIENT_NAME"
        Me.colCLIENT_NAME.OptionsColumn.AllowEdit = false
        Me.colCLIENT_NAME.OptionsColumn.AllowFocus = false
        Me.colCLIENT_NAME.Visible = true
        Me.colCLIENT_NAME.VisibleIndex = 15
        '
        'colLAST_UPDATED
        '
        Me.colLAST_UPDATED.Caption = "Fecha Ultima Actualizacion"
        Me.colLAST_UPDATED.FieldName = "LAST_UPDATED"
        Me.colLAST_UPDATED.Name = "colLAST_UPDATED"
        Me.colLAST_UPDATED.OptionsColumn.AllowEdit = false
        Me.colLAST_UPDATED.OptionsColumn.AllowFocus = false
        Me.colLAST_UPDATED.Visible = true
        Me.colLAST_UPDATED.VisibleIndex = 16
        '
        'colEMAIL
        '
        Me.colEMAIL.Caption = "Correo Electronico"
        Me.colEMAIL.FieldName = "EMAIL"
        Me.colEMAIL.Name = "colEMAIL"
        Me.colEMAIL.OptionsColumn.AllowEdit = false
        Me.colEMAIL.OptionsColumn.AllowFocus = false
        '
        'colRegimen
        '
        Me.colRegimen.Caption = "Regimen"
        Me.colRegimen.FieldName = "Regimen"
        Me.colRegimen.Name = "colRegimen"
        Me.colRegimen.OptionsColumn.AllowEdit = false
        Me.colRegimen.OptionsColumn.AllowFocus = false
        Me.colRegimen.Visible = true
        Me.colRegimen.VisibleIndex = 17
        '
        'colMedida
        '
        Me.colMedida.Caption = "Medida"
        Me.colMedida.FieldName = "Unidad_Medida"
        Me.colMedida.Name = "colMedida"
        Me.colMedida.OptionsColumn.AllowEdit = false
        Me.colMedida.OptionsColumn.AllowFocus = false
        Me.colMedida.Visible = true
        Me.colMedida.VisibleIndex = 18
        '
        'colFirma
        '
        Me.colFirma.Caption = "Firma"
        Me.colFirma.FieldName = "Firma"
        Me.colFirma.Name = "colFirma"
        Me.colFirma.OptionsColumn.AllowEdit = false
        Me.colFirma.OptionsColumn.AllowFocus = false
        Me.colFirma.Visible = true
        Me.colFirma.VisibleIndex = 19
        '
        'coladuana
        '
        Me.coladuana.Caption = "Aduana"
        Me.coladuana.FieldName = "clave_aduana_alsersa"
        Me.coladuana.Name = "coladuana"
        Me.coladuana.OptionsColumn.AllowEdit = false
        Me.coladuana.OptionsColumn.AllowFocus = false
        Me.coladuana.Visible = true
        Me.coladuana.VisibleIndex = 20
        '
        'UiColPuesto
        '
        Me.UiColPuesto.Caption = "Puesto"
        Me.UiColPuesto.FieldName = "POSITION_PERSON"
        Me.UiColPuesto.Name = "UiColPuesto"
        Me.UiColPuesto.Visible = true
        Me.UiColPuesto.VisibleIndex = 21
        '
        'BarManager1
        '
        Me.BarManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Bar1})
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.btnAutorizar, Me.btnEnSitio, Me.btnPrint, Me.BarCheckItem1, Me.chkIncluirAutorizados, Me.chkIncluirEnsSitio, Me.BarEditItem1, Me.dtFechaInicio, Me.dtFechaFinal, Me.btnRefresh, Me.BarBtnParametros, Me.btnRefresh1, Me.BarBtnParam})
        Me.BarManager1.MaxItemId = 14
        Me.BarManager1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTextEdit1, Me.RepositoryItemDateEdit1, Me.RepositoryItemDateEdit2})
        '
        'Bar1
        '
        Me.Bar1.BarName = "Herramientas"
        Me.Bar1.DockCol = 0
        Me.Bar1.DockRow = 0
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.btnAutorizar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.btnEnSitio, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.BarBtnParam, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.btnPrint, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.chkIncluirAutorizados, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.chkIncluirEnsSitio, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.dtFechaInicio, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.dtFechaFinal, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.btnRefresh1, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)})
        Me.Bar1.OptionsBar.AllowQuickCustomization = false
        Me.Bar1.OptionsBar.DrawDragBorder = false
        Me.Bar1.OptionsBar.UseWholeRow = true
        Me.Bar1.Text = "Herramientas"
        '
        'btnAutorizar
        '
        Me.btnAutorizar.Caption = "Autorizar"
        Me.btnAutorizar.Glyph = Global.WMSOnePlan_Client.My.Resources.Resources.edittask_16x16
        Me.btnAutorizar.Id = 0
        Me.btnAutorizar.LargeGlyph = Global.WMSOnePlan_Client.My.Resources.Resources.edittask_32x32
        Me.btnAutorizar.Name = "btnAutorizar"
        '
        'btnEnSitio
        '
        Me.btnEnSitio.Caption = "En Sitio"
        Me.btnEnSitio.Glyph = Global.WMSOnePlan_Client.My.Resources.Resources.status_16x16
        Me.btnEnSitio.Id = 1
        Me.btnEnSitio.LargeGlyph = Global.WMSOnePlan_Client.My.Resources.Resources.status_32x32
        Me.btnEnSitio.Name = "btnEnSitio"
        '
        'BarBtnParam
        '
        Me.BarBtnParam.Caption = "Parametros"
        Me.BarBtnParam.Glyph = Global.WMSOnePlan_Client.My.Resources.Resources.edittask_16x16
        Me.BarBtnParam.Id = 13
        Me.BarBtnParam.Name = "BarBtnParam"
        '
        'btnPrint
        '
        Me.btnPrint.Caption = "Print"
        Me.btnPrint.Glyph = Global.WMSOnePlan_Client.My.Resources.Resources.print_16x16
        Me.btnPrint.Id = 2
        Me.btnPrint.LargeGlyph = Global.WMSOnePlan_Client.My.Resources.Resources.print_32x32
        Me.btnPrint.Name = "btnPrint"
        '
        'chkIncluirAutorizados
        '
        Me.chkIncluirAutorizados.Caption = "Incluir Autorizados"
        Me.chkIncluirAutorizados.Glyph = Global.WMSOnePlan_Client.My.Resources.Resources.usergroup_16x16
        Me.chkIncluirAutorizados.Id = 4
        Me.chkIncluirAutorizados.LargeGlyph = Global.WMSOnePlan_Client.My.Resources.Resources.usergroup_32x32
        Me.chkIncluirAutorizados.Name = "chkIncluirAutorizados"
        '
        'chkIncluirEnsSitio
        '
        Me.chkIncluirEnsSitio.Caption = "Incluir En Sitio"
        Me.chkIncluirEnsSitio.Glyph = Global.WMSOnePlan_Client.My.Resources.Resources.team_16x16
        Me.chkIncluirEnsSitio.Id = 5
        Me.chkIncluirEnsSitio.LargeGlyph = Global.WMSOnePlan_Client.My.Resources.Resources.team_32x32
        Me.chkIncluirEnsSitio.Name = "chkIncluirEnsSitio"
        '
        'dtFechaInicio
        '
        Me.dtFechaInicio.Caption = "Fecha Inicio"
        Me.dtFechaInicio.Edit = Me.RepositoryItemDateEdit1
        Me.dtFechaInicio.EditWidth = 100
        Me.dtFechaInicio.Glyph = Global.WMSOnePlan_Client.My.Resources.Resources.dayview_16x16
        Me.dtFechaInicio.Id = 7
        Me.dtFechaInicio.LargeGlyph = Global.WMSOnePlan_Client.My.Resources.Resources.dayview_32x32
        Me.dtFechaInicio.Name = "dtFechaInicio"
        '
        'RepositoryItemDateEdit1
        '
        Me.RepositoryItemDateEdit1.AutoHeight = false
        Me.RepositoryItemDateEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemDateEdit1.Name = "RepositoryItemDateEdit1"
        '
        'dtFechaFinal
        '
        Me.dtFechaFinal.Caption = "Fecha Final"
        Me.dtFechaFinal.Edit = Me.RepositoryItemDateEdit2
        Me.dtFechaFinal.EditWidth = 100
        Me.dtFechaFinal.Glyph = Global.WMSOnePlan_Client.My.Resources.Resources.monthview_16x16
        Me.dtFechaFinal.Id = 8
        Me.dtFechaFinal.LargeGlyph = Global.WMSOnePlan_Client.My.Resources.Resources.monthview_32x32
        Me.dtFechaFinal.Name = "dtFechaFinal"
        '
        'RepositoryItemDateEdit2
        '
        Me.RepositoryItemDateEdit2.AutoHeight = false
        Me.RepositoryItemDateEdit2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemDateEdit2.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemDateEdit2.Name = "RepositoryItemDateEdit2"
        '
        'btnRefresh1
        '
        Me.btnRefresh1.Caption = "Refresh"
        Me.btnRefresh1.Glyph = Global.WMSOnePlan_Client.My.Resources.Resources.convert_16x16
        Me.btnRefresh1.Id = 12
        Me.btnRefresh1.Name = "btnRefresh1"
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = false
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(1139, 33)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = false
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 615)
        Me.barDockControlBottom.Size = New System.Drawing.Size(1139, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = false
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 33)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 582)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = false
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(1139, 33)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 582)
        '
        'BarCheckItem1
        '
        Me.BarCheckItem1.Caption = "BarCheckItem1"
        Me.BarCheckItem1.Id = 3
        Me.BarCheckItem1.Name = "BarCheckItem1"
        '
        'BarEditItem1
        '
        Me.BarEditItem1.Caption = "BarEditItem1"
        Me.BarEditItem1.Edit = Me.RepositoryItemTextEdit1
        Me.BarEditItem1.Id = 6
        Me.BarEditItem1.Name = "BarEditItem1"
        '
        'RepositoryItemTextEdit1
        '
        Me.RepositoryItemTextEdit1.AutoHeight = false
        Me.RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
        '
        'btnRefresh
        '
        Me.btnRefresh.Caption = "Refresh"
        Me.btnRefresh.Glyph = Global.WMSOnePlan_Client.My.Resources.Resources.convert_16x16
        Me.btnRefresh.Id = 9
        Me.btnRefresh.LargeGlyph = Global.WMSOnePlan_Client.My.Resources.Resources.convert_32x32
        Me.btnRefresh.Name = "btnRefresh"
        '
        'BarBtnParametros
        '
        Me.BarBtnParametros.Caption = "Parametro"
        Me.BarBtnParametros.Glyph = Global.WMSOnePlan_Client.My.Resources.Resources.table_row_delete1
        Me.BarBtnParametros.Id = 11
        Me.BarBtnParametros.Name = "BarBtnParametros"
        '
        'DataWindow
        '
        Me.DataWindow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.DataWindow.Controls.Add(Me.UiTextoPuesto)
        Me.DataWindow.Controls.Add(Me.UiEtiquetaPuesto)
        Me.DataWindow.Controls.Add(Me.BtnSalir)
        Me.DataWindow.Controls.Add(Me.BtnReset)
        Me.DataWindow.Controls.Add(Me.TxtCarta)
        Me.DataWindow.Controls.Add(Me.LblCarta)
        Me.DataWindow.Controls.Add(Me.BtnPrintCupo)
        Me.DataWindow.Controls.Add(Me.TxtFirma)
        Me.DataWindow.Controls.Add(Me.TxtMedida)
        Me.DataWindow.Controls.Add(Me.TxtPoliza)
        Me.DataWindow.Controls.Add(Me.LblFirma)
        Me.DataWindow.Controls.Add(Me.LblMedida)
        Me.DataWindow.Controls.Add(Me.LblPoliza)
        Me.DataWindow.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.DataWindow.Location = New System.Drawing.Point(402, 197)
        Me.DataWindow.Name = "DataWindow"
        Me.DataWindow.Size = New System.Drawing.Size(294, 188)
        Me.DataWindow.TabIndex = 0
        Me.DataWindow.TabStop = false
        Me.DataWindow.Text = "Carta Cupo"
        Me.DataWindow.Visible = false
        '
        'BtnSalir
        '
        Me.BtnSalir.Location = New System.Drawing.Point(219, 143)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(56, 33)
        Me.BtnSalir.TabIndex = 6
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        Me.BtnSalir.UseVisualStyleBackColor = true
        '
        'BtnReset
        '
        Me.BtnReset.Location = New System.Drawing.Point(157, 143)
        Me.BtnReset.Name = "BtnReset"
        Me.BtnReset.Size = New System.Drawing.Size(56, 33)
        Me.BtnReset.TabIndex = 5
        Me.BtnReset.Text = "Limpiar"
        Me.BtnReset.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        Me.BtnReset.UseVisualStyleBackColor = true
        '
        'TxtCarta
        '
        Me.TxtCarta.Location = New System.Drawing.Point(123, 13)
        Me.TxtCarta.Name = "TxtCarta"
        Me.TxtCarta.Size = New System.Drawing.Size(150, 20)
        Me.TxtCarta.TabIndex = 0
        '
        'LblCarta
        '
        Me.LblCarta.AutoSize = true
        Me.LblCarta.Location = New System.Drawing.Point(6, 16)
        Me.LblCarta.Name = "LblCarta"
        Me.LblCarta.Size = New System.Drawing.Size(80, 13)
        Me.LblCarta.TabIndex = 7
        Me.LblCarta.Text = "No. Carta Cupo"
        '
        'BtnPrintCupo
        '
        Me.BtnPrintCupo.Location = New System.Drawing.Point(94, 143)
        Me.BtnPrintCupo.Name = "BtnPrintCupo"
        Me.BtnPrintCupo.Size = New System.Drawing.Size(56, 33)
        Me.BtnPrintCupo.TabIndex = 4
        Me.BtnPrintCupo.Text = "Guardar"
        Me.BtnPrintCupo.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        Me.BtnPrintCupo.UseVisualStyleBackColor = true
        '
        'TxtFirma
        '
        Me.TxtFirma.Location = New System.Drawing.Point(124, 91)
        Me.TxtFirma.Name = "TxtFirma"
        Me.TxtFirma.Size = New System.Drawing.Size(150, 20)
        Me.TxtFirma.TabIndex = 2
        '
        'TxtMedida
        '
        Me.TxtMedida.Location = New System.Drawing.Point(123, 65)
        Me.TxtMedida.Name = "TxtMedida"
        Me.TxtMedida.Size = New System.Drawing.Size(150, 20)
        Me.TxtMedida.TabIndex = 1
        '
        'TxtPoliza
        '
        Me.TxtPoliza.Location = New System.Drawing.Point(123, 39)
        Me.TxtPoliza.Name = "TxtPoliza"
        Me.TxtPoliza.Size = New System.Drawing.Size(150, 20)
        Me.TxtPoliza.TabIndex = 0
        '
        'LblFirma
        '
        Me.LblFirma.AutoSize = true
        Me.LblFirma.Location = New System.Drawing.Point(6, 94)
        Me.LblFirma.Name = "LblFirma"
        Me.LblFirma.Size = New System.Drawing.Size(72, 13)
        Me.LblFirma.TabIndex = 9
        Me.LblFirma.Text = "Nombre Firma"
        '
        'LblMedida
        '
        Me.LblMedida.AutoSize = true
        Me.LblMedida.Location = New System.Drawing.Point(6, 68)
        Me.LblMedida.Name = "LblMedida"
        Me.LblMedida.Size = New System.Drawing.Size(97, 13)
        Me.LblMedida.TabIndex = 9
        Me.LblMedida.Text = "Unidad de Medida:"
        '
        'LblPoliza
        '
        Me.LblPoliza.AutoSize = true
        Me.LblPoliza.Location = New System.Drawing.Point(6, 42)
        Me.LblPoliza.Name = "LblPoliza"
        Me.LblPoliza.Size = New System.Drawing.Size(52, 13)
        Me.LblPoliza.TabIndex = 8
        Me.LblPoliza.Text = "Regimen "
        '
        'dxerror
        '
        Me.dxerror.ContainerControl = Me
        '
        'UiTextoPuesto
        '
        Me.UiTextoPuesto.Location = New System.Drawing.Point(123, 117)
        Me.UiTextoPuesto.Name = "UiTextoPuesto"
        Me.UiTextoPuesto.Size = New System.Drawing.Size(150, 20)
        Me.UiTextoPuesto.TabIndex = 3
        '
        'UiEtiquetaPuesto
        '
        Me.UiEtiquetaPuesto.AutoSize = true
        Me.UiEtiquetaPuesto.Location = New System.Drawing.Point(6, 120)
        Me.UiEtiquetaPuesto.Name = "UiEtiquetaPuesto"
        Me.UiEtiquetaPuesto.Size = New System.Drawing.Size(111, 13)
        Me.UiEtiquetaPuesto.TabIndex = 11
        Me.UiEtiquetaPuesto.Text = "Puesto de la Persona:"
        '
        'FrmAuthorizationLatterQuota
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1139, 615)
        Me.Controls.Add(Me.DataWindow)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "FrmAuthorizationLatterQuota"
        Me.Text = "Cartas de Cupo"
        CType(Me.RepositoryIsLogged,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.GridControl1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.GridView1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.BarManager1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.RepositoryItemDateEdit1.CalendarTimeProperties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.RepositoryItemDateEdit1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.RepositoryItemDateEdit2.CalendarTimeProperties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.RepositoryItemDateEdit2,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.RepositoryItemTextEdit1,System.ComponentModel.ISupportInitialize).EndInit
        Me.DataWindow.ResumeLayout(false)
        Me.DataWindow.PerformLayout
        CType(Me.dxerror,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colDOC_ID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPOLIZAS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCLAVE_ADUANA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNOMBRE_ADUANA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNO_FACTURA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMERCHANDISE_DESCRIPTION As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMERCHANDISE_QTY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryIsLogged As DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup
    Friend WithEvents colMERCHANDISE_VALUE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBL_NUMBER As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCONTAINER_NUMBER As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCLAVE_AGENTE_ADUANERO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNOMBRE_AGENTE_ADUANERO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNOMBRE_CONSIGNATARIO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNIT_CONSIGNATARIO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDOMICILIO_FISCAL_CONSIGNATARIO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRELATED_CLIENT_CODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCLIENT_NAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSTATUS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colLAST_UPDATED As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents Bar1 As DevExpress.XtraBars.Bar
    Friend WithEvents btnAutorizar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents btnEnSitio As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnPrint As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents chkIncluirAutorizados As DevExpress.XtraBars.BarToggleSwitchItem
    Friend WithEvents BarCheckItem1 As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents chkIncluirEnsSitio As DevExpress.XtraBars.BarToggleSwitchItem
    Friend WithEvents dtFechaInicio As DevExpress.XtraBars.BarEditItem
    Friend WithEvents RepositoryItemDateEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents BarEditItem1 As DevExpress.XtraBars.BarEditItem
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents dtFechaFinal As DevExpress.XtraBars.BarEditItem
    Friend WithEvents RepositoryItemDateEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents btnRefresh As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents colEMAIL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DataWindow As System.Windows.Forms.GroupBox
    Friend WithEvents BtnPrintCupo As System.Windows.Forms.Button
    Friend WithEvents TxtFirma As System.Windows.Forms.TextBox
    Friend WithEvents TxtMedida As System.Windows.Forms.TextBox
    Friend WithEvents TxtPoliza As System.Windows.Forms.TextBox
    Friend WithEvents LblFirma As System.Windows.Forms.Label
    Friend WithEvents LblMedida As System.Windows.Forms.Label
    Friend WithEvents LblPoliza As System.Windows.Forms.Label
    Friend WithEvents BarBtnParametros As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnRefresh1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents TxtCarta As System.Windows.Forms.TextBox
    Friend WithEvents LblCarta As System.Windows.Forms.Label
    Friend WithEvents dxerror As System.Windows.Forms.ErrorProvider
    Friend WithEvents BtnSalir As System.Windows.Forms.Button
    Friend WithEvents BtnReset As System.Windows.Forms.Button
    Friend WithEvents BarBtnParam As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents colRegimen As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMedida As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFirma As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents coladuana As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UiColPuesto As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UiTextoPuesto As TextBox
    Friend WithEvents UiEtiquetaPuesto As Label
End Class
