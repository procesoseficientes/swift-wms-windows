<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEgresoFiscalAddLine
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
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.GridEnvio = New DevExpress.XtraGrid.GridControl()
        Me.GridViewEnvio = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colDOC_ID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colLINE_NUMBER = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMATERIAL_ID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSKU_DESCRIPTION1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSAC_CODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBULTOS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCLASE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNET_WEIGTH = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colWEIGTH_UNIT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colQTY1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCUSTOMS_AMOUNT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colQTY_UNIT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colVOLUME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colVOLUME_UNIT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDAI = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colIVA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMISC_TAXES = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFOB_USD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFREIGTH_USD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colINSURANCE_USD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMISC_EXPENSES = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colORIGIN_COUNTRY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colREGION_CP = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAGREEMENT_1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAGREEMENT_2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRELATED_POLIZA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colORIGIN_DOC_ID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCODIGO_POLIZA_ORIGEN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colACUERDO_COMERCIAL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPCTDAI = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colORIGIN_LINE_NUMBER = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCLIENT_CODE1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCONSIGNATARIO_NAME1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridPolizas = New DevExpress.XtraGrid.GridControl()
        Me.GridViewPolizas = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colPOLIZA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNUMERO_ORDEN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNUMERO_DUA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSKU_DESCRIPTION = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colQTY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colLINE_NUMBER1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDOC_ID1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBULTOS1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCONSIGNATARIO_CODIGO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCONSIGNATARIO_NAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cmbCLIENT = New DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit()
        Me.cmbCLIENTView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar2 = New DevExpress.XtraBars.Bar()
        Me.BarLargeButtonItem1 = New DevExpress.XtraBars.BarLargeButtonItem()
        Me.btnAdd = New DevExpress.XtraBars.BarLargeButtonItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.btnDelete = New DevExpress.XtraBars.BarLargeButtonItem()
        Me.colVIN = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.LayoutControl1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.LayoutControl1.SuspendLayout
        CType(Me.GridEnvio,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.GridViewEnvio,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.GridPolizas,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.GridViewPolizas,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.cmbCLIENT,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.cmbCLIENTView,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.LayoutControlGroup1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.LayoutControlItem2,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.LayoutControlItem3,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.BarManager1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.GridEnvio)
        Me.LayoutControl1.Controls.Add(Me.GridPolizas)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 66)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(1181, 524)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'GridEnvio
        '
        Me.GridEnvio.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridEnvio.Location = New System.Drawing.Point(63, 282)
        Me.GridEnvio.MainView = Me.GridViewEnvio
        Me.GridEnvio.Name = "GridEnvio"
        Me.GridEnvio.Size = New System.Drawing.Size(1106, 230)
        Me.GridEnvio.TabIndex = 6
        Me.GridEnvio.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewEnvio})
        '
        'GridViewEnvio
        '
        Me.GridViewEnvio.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colDOC_ID, Me.colLINE_NUMBER, Me.colMATERIAL_ID, Me.colSKU_DESCRIPTION1, Me.colSAC_CODE, Me.colBULTOS, Me.colCLASE, Me.colNET_WEIGTH, Me.colWEIGTH_UNIT, Me.colQTY1, Me.colCUSTOMS_AMOUNT, Me.colQTY_UNIT, Me.colVOLUME, Me.colVOLUME_UNIT, Me.colDAI, Me.colIVA, Me.colMISC_TAXES, Me.colFOB_USD, Me.colFREIGTH_USD, Me.colINSURANCE_USD, Me.colMISC_EXPENSES, Me.colORIGIN_COUNTRY, Me.colREGION_CP, Me.colAGREEMENT_1, Me.colAGREEMENT_2, Me.colRELATED_POLIZA, Me.colORIGIN_DOC_ID, Me.colCODIGO_POLIZA_ORIGEN, Me.colACUERDO_COMERCIAL, Me.colPCTDAI, Me.colORIGIN_LINE_NUMBER, Me.colCLIENT_CODE1, Me.colCONSIGNATARIO_NAME1})
        Me.GridViewEnvio.GridControl = Me.GridEnvio
        Me.GridViewEnvio.Name = "GridViewEnvio"
        Me.GridViewEnvio.OptionsBehavior.Editable = false
        '
        'colDOC_ID
        '
        Me.colDOC_ID.Caption = "DOCUMENTO"
        Me.colDOC_ID.FieldName = "DOC_ID"
        Me.colDOC_ID.Name = "colDOC_ID"
        Me.colDOC_ID.OptionsColumn.ShowInCustomizationForm = false
        '
        'colLINE_NUMBER
        '
        Me.colLINE_NUMBER.Caption = "LINEA"
        Me.colLINE_NUMBER.FieldName = "LINE_NUMBER"
        Me.colLINE_NUMBER.Name = "colLINE_NUMBER"
        Me.colLINE_NUMBER.Visible = true
        Me.colLINE_NUMBER.VisibleIndex = 0
        '
        'colMATERIAL_ID
        '
        Me.colMATERIAL_ID.Caption = "MATERIAL_ID"
        Me.colMATERIAL_ID.FieldName = "MATERIAL_ID"
        Me.colMATERIAL_ID.Name = "colMATERIAL_ID"
        Me.colMATERIAL_ID.Visible = True
        Me.colMATERIAL_ID.VisibleIndex = 1
        '
        'colSKU_DESCRIPTION1
        '
        Me.colSKU_DESCRIPTION1.Caption = "DESCRIPCION"
        Me.colSKU_DESCRIPTION1.FieldName = "SKU_DESCRIPTION"
        Me.colSKU_DESCRIPTION1.Name = "colSKU_DESCRIPTION1"
        Me.colSKU_DESCRIPTION1.Visible = true
        Me.colSKU_DESCRIPTION1.VisibleIndex = 1
        '
        'colSAC_CODE
        '
        Me.colSAC_CODE.Caption = "CODIGO ARANCELARIO"
        Me.colSAC_CODE.FieldName = "SAC_CODE"
        Me.colSAC_CODE.Name = "colSAC_CODE"
        Me.colSAC_CODE.OptionsColumn.ShowInCustomizationForm = false
        '
        'colBULTOS
        '
        Me.colBULTOS.Caption = "BULTOS"
        Me.colBULTOS.FieldName = "BULTOS"
        Me.colBULTOS.Name = "colBULTOS"
        Me.colBULTOS.Visible = true
        Me.colBULTOS.VisibleIndex = 2
        '
        'colCLASE
        '
        Me.colCLASE.Caption = "CLASE"
        Me.colCLASE.FieldName = "CLASE"
        Me.colCLASE.Name = "colCLASE"
        Me.colCLASE.OptionsColumn.ShowInCustomizationForm = false
        '
        'colNET_WEIGTH
        '
        Me.colNET_WEIGTH.Caption = "PESO NETO"
        Me.colNET_WEIGTH.FieldName = "NET_WEIGTH"
        Me.colNET_WEIGTH.Name = "colNET_WEIGTH"
        Me.colNET_WEIGTH.OptionsColumn.ShowInCustomizationForm = false
        '
        'colWEIGTH_UNIT
        '
        Me.colWEIGTH_UNIT.Caption = "UNIDAD DE PESO"
        Me.colWEIGTH_UNIT.FieldName = "WEIGTH_UNIT"
        Me.colWEIGTH_UNIT.Name = "colWEIGTH_UNIT"
        Me.colWEIGTH_UNIT.OptionsColumn.ShowInCustomizationForm = false
        '
        'colQTY1
        '
        Me.colQTY1.Caption = "CANTIDAD"
        Me.colQTY1.FieldName = "QTY"
        Me.colQTY1.Name = "colQTY1"
        Me.colQTY1.OptionsColumn.ShowInCustomizationForm = false
        '
        'colCUSTOMS_AMOUNT
        '
        Me.colCUSTOMS_AMOUNT.Caption = "VALOR ADUANA"
        Me.colCUSTOMS_AMOUNT.FieldName = "CUSTOMS_AMOUNT"
        Me.colCUSTOMS_AMOUNT.Name = "colCUSTOMS_AMOUNT"
        Me.colCUSTOMS_AMOUNT.OptionsColumn.ShowInCustomizationForm = false
        '
        'colQTY_UNIT
        '
        Me.colQTY_UNIT.Caption = "UNIDAD"
        Me.colQTY_UNIT.FieldName = "QTY_UNIT"
        Me.colQTY_UNIT.Name = "colQTY_UNIT"
        Me.colQTY_UNIT.OptionsColumn.ShowInCustomizationForm = false
        '
        'colVOLUME
        '
        Me.colVOLUME.Caption = "VOLUMEN"
        Me.colVOLUME.FieldName = "VOLUME"
        Me.colVOLUME.Name = "colVOLUME"
        Me.colVOLUME.OptionsColumn.ShowInCustomizationForm = false
        '
        'colVOLUME_UNIT
        '
        Me.colVOLUME_UNIT.Caption = "UNIDAD VOLUMEN"
        Me.colVOLUME_UNIT.FieldName = "VOLUME_UNIT"
        Me.colVOLUME_UNIT.Name = "colVOLUME_UNIT"
        Me.colVOLUME_UNIT.OptionsColumn.ShowInCustomizationForm = false
        '
        'colDAI
        '
        Me.colDAI.Caption = "DAI"
        Me.colDAI.FieldName = "DAI"
        Me.colDAI.Name = "colDAI"
        Me.colDAI.OptionsColumn.ShowInCustomizationForm = false
        '
        'colIVA
        '
        Me.colIVA.Caption = "IVA"
        Me.colIVA.FieldName = "IVA"
        Me.colIVA.Name = "colIVA"
        Me.colIVA.OptionsColumn.ShowInCustomizationForm = false
        '
        'colMISC_TAXES
        '
        Me.colMISC_TAXES.Caption = "IMPTOS MISC"
        Me.colMISC_TAXES.FieldName = "MISC_TAXES"
        Me.colMISC_TAXES.Name = "colMISC_TAXES"
        Me.colMISC_TAXES.OptionsColumn.ShowInCustomizationForm = false
        '
        'colFOB_USD
        '
        Me.colFOB_USD.Caption = "FOB USD"
        Me.colFOB_USD.FieldName = "FOB_USD"
        Me.colFOB_USD.Name = "colFOB_USD"
        Me.colFOB_USD.OptionsColumn.ShowInCustomizationForm = false
        '
        'colFREIGTH_USD
        '
        Me.colFREIGTH_USD.Caption = "FLETE USD"
        Me.colFREIGTH_USD.FieldName = "FREIGTH_USD"
        Me.colFREIGTH_USD.Name = "colFREIGTH_USD"
        Me.colFREIGTH_USD.OptionsColumn.ShowInCustomizationForm = false
        '
        'colINSURANCE_USD
        '
        Me.colINSURANCE_USD.Caption = "SEGURO USD"
        Me.colINSURANCE_USD.FieldName = "INSURANCE_USD"
        Me.colINSURANCE_USD.Name = "colINSURANCE_USD"
        Me.colINSURANCE_USD.OptionsColumn.ShowInCustomizationForm = false
        '
        'colMISC_EXPENSES
        '
        Me.colMISC_EXPENSES.Caption = "GASTOS MISC"
        Me.colMISC_EXPENSES.FieldName = "MISC_EXPENSES"
        Me.colMISC_EXPENSES.Name = "colMISC_EXPENSES"
        Me.colMISC_EXPENSES.OptionsColumn.ShowInCustomizationForm = false
        '
        'colORIGIN_COUNTRY
        '
        Me.colORIGIN_COUNTRY.Caption = "ORIGEN"
        Me.colORIGIN_COUNTRY.FieldName = "ORIGIN_COUNTRY"
        Me.colORIGIN_COUNTRY.Name = "colORIGIN_COUNTRY"
        Me.colORIGIN_COUNTRY.OptionsColumn.ShowInCustomizationForm = false
        '
        'colREGION_CP
        '
        Me.colREGION_CP.Caption = "REGION CP"
        Me.colREGION_CP.FieldName = "REGION_CP"
        Me.colREGION_CP.Name = "colREGION_CP"
        Me.colREGION_CP.OptionsColumn.ShowInCustomizationForm = false
        '
        'colAGREEMENT_1
        '
        Me.colAGREEMENT_1.Caption = "ACUERDO1"
        Me.colAGREEMENT_1.FieldName = "AGREEMENT_1"
        Me.colAGREEMENT_1.Name = "colAGREEMENT_1"
        Me.colAGREEMENT_1.OptionsColumn.ShowInCustomizationForm = false
        '
        'colAGREEMENT_2
        '
        Me.colAGREEMENT_2.Caption = "ACUERDO2"
        Me.colAGREEMENT_2.FieldName = "AGREEMENT_2"
        Me.colAGREEMENT_2.Name = "colAGREEMENT_2"
        Me.colAGREEMENT_2.OptionsColumn.ShowInCustomizationForm = false
        '
        'colRELATED_POLIZA
        '
        Me.colRELATED_POLIZA.Caption = "POLIZA RELACIONADA"
        Me.colRELATED_POLIZA.FieldName = "RELATED_POLIZA"
        Me.colRELATED_POLIZA.Name = "colRELATED_POLIZA"
        Me.colRELATED_POLIZA.OptionsColumn.ShowInCustomizationForm = false
        '
        'colORIGIN_DOC_ID
        '
        Me.colORIGIN_DOC_ID.Caption = "DOCUMENTO ORIGEN"
        Me.colORIGIN_DOC_ID.FieldName = "ORIGIN_DOC_ID"
        Me.colORIGIN_DOC_ID.Name = "colORIGIN_DOC_ID"
        Me.colORIGIN_DOC_ID.Visible = true
        Me.colORIGIN_DOC_ID.VisibleIndex = 5
        '
        'colCODIGO_POLIZA_ORIGEN
        '
        Me.colCODIGO_POLIZA_ORIGEN.Caption = "POLIZA ORIGEN"
        Me.colCODIGO_POLIZA_ORIGEN.FieldName = "CODIGO_POLIZA_ORIGEN"
        Me.colCODIGO_POLIZA_ORIGEN.Name = "colCODIGO_POLIZA_ORIGEN"
        Me.colCODIGO_POLIZA_ORIGEN.Visible = true
        Me.colCODIGO_POLIZA_ORIGEN.VisibleIndex = 4
        '
        'colACUERDO_COMERCIAL
        '
        Me.colACUERDO_COMERCIAL.Caption = "ACUERDO COMERCIAL"
        Me.colACUERDO_COMERCIAL.FieldName = "ACUERDO_COMERCIAL"
        Me.colACUERDO_COMERCIAL.Name = "colACUERDO_COMERCIAL"
        Me.colACUERDO_COMERCIAL.OptionsColumn.ShowInCustomizationForm = false
        '
        'colPCTDAI
        '
        Me.colPCTDAI.Caption = "PCTDAI"
        Me.colPCTDAI.FieldName = "PCTDAI"
        Me.colPCTDAI.Name = "colPCTDAI"
        Me.colPCTDAI.OptionsColumn.ShowInCustomizationForm = false
        '
        'colORIGIN_LINE_NUMBER
        '
        Me.colORIGIN_LINE_NUMBER.Caption = "LINEA ORIGEN"
        Me.colORIGIN_LINE_NUMBER.FieldName = "ORIGIN_LINE_NUMBER"
        Me.colORIGIN_LINE_NUMBER.Name = "colORIGIN_LINE_NUMBER"
        Me.colORIGIN_LINE_NUMBER.Visible = true
        Me.colORIGIN_LINE_NUMBER.VisibleIndex = 3
        '
        'colCLIENT_CODE1
        '
        Me.colCLIENT_CODE1.Caption = "Código Consignatario"
        Me.colCLIENT_CODE1.FieldName = "CLIENT_CODE"
        Me.colCLIENT_CODE1.Name = "colCLIENT_CODE1"
        Me.colCLIENT_CODE1.OptionsColumn.ShowInCustomizationForm = false
        Me.colCLIENT_CODE1.Visible = true
        Me.colCLIENT_CODE1.VisibleIndex = 6
        '
        'colCONSIGNATARIO_NAME1
        '
        Me.colCONSIGNATARIO_NAME1.Caption = "Nombre Consignatario"
        Me.colCONSIGNATARIO_NAME1.FieldName = "CONSIGNATARIO_NAME"
        Me.colCONSIGNATARIO_NAME1.Name = "colCONSIGNATARIO_NAME1"
        Me.colCONSIGNATARIO_NAME1.Visible = true
        Me.colCONSIGNATARIO_NAME1.VisibleIndex = 7
        '
        'GridPolizas
        '
        Me.GridPolizas.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridPolizas.Location = New System.Drawing.Point(63, 12)
        Me.GridPolizas.MainView = Me.GridViewPolizas
        Me.GridPolizas.Name = "GridPolizas"
        Me.GridPolizas.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.cmbCLIENT})
        Me.GridPolizas.Size = New System.Drawing.Size(1106, 266)
        Me.GridPolizas.TabIndex = 5
        Me.GridPolizas.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewPolizas})
        '
        'GridViewPolizas
        '
        Me.GridViewPolizas.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colPOLIZA, Me.colNUMERO_ORDEN, Me.colNUMERO_DUA, Me.colSKU_DESCRIPTION, Me.colQTY, Me.colLINE_NUMBER1, Me.colDOC_ID1, Me.colBULTOS1, Me.colCONSIGNATARIO_CODIGO, Me.colCONSIGNATARIO_NAME, Me.colVIN})
        Me.GridViewPolizas.GridControl = Me.GridPolizas
        Me.GridViewPolizas.Name = "GridViewPolizas"
        Me.GridViewPolizas.OptionsView.ShowAutoFilterRow = true
        '
        'colPOLIZA
        '
        Me.colPOLIZA.Caption = "POLIZA"
        Me.colPOLIZA.FieldName = "CODIGO_POLIZA"
        Me.colPOLIZA.Name = "colPOLIZA"
        Me.colPOLIZA.OptionsColumn.AllowEdit = false
        Me.colPOLIZA.Visible = true
        Me.colPOLIZA.VisibleIndex = 0
        '
        'colNUMERO_ORDEN
        '
        Me.colNUMERO_ORDEN.Caption = "NUMERO ORDEN"
        Me.colNUMERO_ORDEN.FieldName = "NUMERO_ORDEN"
        Me.colNUMERO_ORDEN.Name = "colNUMERO_ORDEN"
        Me.colNUMERO_ORDEN.OptionsColumn.AllowEdit = false
        Me.colNUMERO_ORDEN.Visible = true
        Me.colNUMERO_ORDEN.VisibleIndex = 1
        '
        'colNUMERO_DUA
        '
        Me.colNUMERO_DUA.Caption = "NUMERO DUA"
        Me.colNUMERO_DUA.FieldName = "NUMERO_DUA"
        Me.colNUMERO_DUA.Name = "colNUMERO_DUA"
        Me.colNUMERO_DUA.OptionsColumn.AllowEdit = false
        Me.colNUMERO_DUA.Visible = true
        Me.colNUMERO_DUA.VisibleIndex = 2
        '
        'colSKU_DESCRIPTION
        '
        Me.colSKU_DESCRIPTION.Caption = "DESCRIPCION PRODUCTO"
        Me.colSKU_DESCRIPTION.FieldName = "SKU_DESCRIPTION"
        Me.colSKU_DESCRIPTION.Name = "colSKU_DESCRIPTION"
        Me.colSKU_DESCRIPTION.OptionsColumn.AllowEdit = false
        Me.colSKU_DESCRIPTION.Visible = true
        Me.colSKU_DESCRIPTION.VisibleIndex = 3
        '
        'colQTY
        '
        Me.colQTY.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(255,Byte),Integer), CType(CType(192,Byte),Integer))
        Me.colQTY.AppearanceCell.Options.UseBackColor = true
        Me.colQTY.Caption = "CANTIDAD DISPONIBLE"
        Me.colQTY.FieldName = "QTY"
        Me.colQTY.Name = "colQTY"
        Me.colQTY.Visible = true
        Me.colQTY.VisibleIndex = 4
        '
        'colLINE_NUMBER1
        '
        Me.colLINE_NUMBER1.Caption = "LINEA"
        Me.colLINE_NUMBER1.FieldName = "LINE_NUMBER"
        Me.colLINE_NUMBER1.Name = "colLINE_NUMBER1"
        '
        'colDOC_ID1
        '
        Me.colDOC_ID1.Caption = "DOCUMENTO"
        Me.colDOC_ID1.FieldName = "DOC_ID"
        Me.colDOC_ID1.Name = "colDOC_ID1"
        '
        'colBULTOS1
        '
        Me.colBULTOS1.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(255,Byte),Integer), CType(CType(192,Byte),Integer))
        Me.colBULTOS1.AppearanceCell.Options.UseBackColor = true
        Me.colBULTOS1.Caption = "BULTOS DISPONIBLE"
        Me.colBULTOS1.FieldName = "BULTOS"
        Me.colBULTOS1.Name = "colBULTOS1"
        Me.colBULTOS1.Visible = true
        Me.colBULTOS1.VisibleIndex = 5
        '
        'colCONSIGNATARIO_CODIGO
        '
        Me.colCONSIGNATARIO_CODIGO.Caption = "Código Consignatario"
        Me.colCONSIGNATARIO_CODIGO.FieldName = "CONSIGNATARIO_CODIGO"
        Me.colCONSIGNATARIO_CODIGO.Name = "colCONSIGNATARIO_CODIGO"
        Me.colCONSIGNATARIO_CODIGO.OptionsColumn.AllowEdit = false
        Me.colCONSIGNATARIO_CODIGO.Visible = true
        Me.colCONSIGNATARIO_CODIGO.VisibleIndex = 6
        '
        'colCONSIGNATARIO_NAME
        '
        Me.colCONSIGNATARIO_NAME.Caption = "Nombre Consignatario"
        Me.colCONSIGNATARIO_NAME.FieldName = "CONSIGNATARIO_NAME"
        Me.colCONSIGNATARIO_NAME.Name = "colCONSIGNATARIO_NAME"
        Me.colCONSIGNATARIO_NAME.OptionsColumn.AllowEdit = false
        Me.colCONSIGNATARIO_NAME.Visible = true
        Me.colCONSIGNATARIO_NAME.VisibleIndex = 7
        '
        'cmbCLIENT
        '
        Me.cmbCLIENT.AutoHeight = false
        Me.cmbCLIENT.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbCLIENT.Name = "cmbCLIENT"
        Me.cmbCLIENT.View = Me.cmbCLIENTView
        '
        'cmbCLIENTView
        '
        Me.cmbCLIENTView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.cmbCLIENTView.Name = "cmbCLIENTView"
        Me.cmbCLIENTView.OptionsSelection.EnableAppearanceFocusedCell = false
        Me.cmbCLIENTView.OptionsView.ShowGroupPanel = false
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.CustomizationFormText = "LayoutControlGroup1"
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = false
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2, Me.LayoutControlItem3})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1181, 524)
        Me.LayoutControlGroup1.TextVisible = false
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.GridPolizas
        Me.LayoutControlItem2.CustomizationFormText = "Disponible"
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(1161, 270)
        Me.LayoutControlItem2.Text = "Disponible"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(48, 13)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.GridEnvio
        Me.LayoutControlItem3.CustomizationFormText = "Egreso"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 270)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(1161, 234)
        Me.LayoutControlItem3.Text = "Egreso"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(48, 13)
        '
        'BarManager1
        '
        Me.BarManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Bar2})
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.BarLargeButtonItem1, Me.btnAdd, Me.btnDelete})
        Me.BarManager1.MainMenu = Me.Bar2
        Me.BarManager1.MaxItemId = 3
        '
        'Bar2
        '
        Me.Bar2.BarName = "Main menu"
        Me.Bar2.DockCol = 0
        Me.Bar2.DockRow = 0
        Me.Bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar2.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.BarLargeButtonItem1, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.btnAdd, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)})
        Me.Bar2.OptionsBar.MultiLine = true
        Me.Bar2.OptionsBar.UseWholeRow = true
        Me.Bar2.Text = "Main menu"
        '
        'BarLargeButtonItem1
        '
        Me.BarLargeButtonItem1.Caption = "Enviar a Egreso"
        Me.BarLargeButtonItem1.Id = 0
        Me.BarLargeButtonItem1.LargeGlyph = Global.WMSOnePlan_Client.My.Resources.Resources.basket_add
        Me.BarLargeButtonItem1.Name = "BarLargeButtonItem1"
        '
        'btnAdd
        '
        Me.btnAdd.Caption = "Agregar"
        Me.btnAdd.Id = 1
        Me.btnAdd.LargeGlyph = Global.WMSOnePlan_Client.My.Resources.Resources._next
        Me.btnAdd.Name = "btnAdd"
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = false
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(1181, 66)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = false
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 590)
        Me.barDockControlBottom.Size = New System.Drawing.Size(1181, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = false
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 66)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 524)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = false
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(1181, 66)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 524)
        '
        'btnDelete
        '
        Me.btnDelete.Caption = "Eliminar"
        Me.btnDelete.Id = 2
        Me.btnDelete.LargeGlyph = Global.WMSOnePlan_Client.My.Resources.Resources.ni0072_32
        Me.btnDelete.Name = "btnDelete"
        '
        'colVIN
        '
        Me.colVIN.Caption = "VIN"
        Me.colVIN.FieldName = "VIN"
        Me.colVIN.Name = "colVIN"
        Me.colVIN.Visible = true
        Me.colVIN.VisibleIndex = 8
        '
        'frmEgresoFiscalAddLine
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1181, 590)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "frmEgresoFiscalAddLine"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Agregar linea Egreso Fiscal"
        CType(Me.LayoutControl1,System.ComponentModel.ISupportInitialize).EndInit
        Me.LayoutControl1.ResumeLayout(false)
        CType(Me.GridEnvio,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.GridViewEnvio,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.GridPolizas,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.GridViewPolizas,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.cmbCLIENT,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.cmbCLIENTView,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.LayoutControlGroup1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.LayoutControlItem2,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.LayoutControlItem3,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.BarManager1,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents GridEnvio As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewEnvio As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridPolizas As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewPolizas As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents Bar2 As DevExpress.XtraBars.Bar
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarLargeButtonItem1 As DevExpress.XtraBars.BarLargeButtonItem
    Friend WithEvents btnAdd As DevExpress.XtraBars.BarLargeButtonItem
    Friend WithEvents colPOLIZA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNUMERO_ORDEN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNUMERO_DUA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cmbCLIENT As DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit
    Friend WithEvents cmbCLIENTView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colSKU_DESCRIPTION As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colQTY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDOC_ID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colLINE_NUMBER As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMATERIAL_ID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSKU_DESCRIPTION1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSAC_CODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBULTOS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCLASE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNET_WEIGTH As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colWEIGTH_UNIT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colQTY1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCUSTOMS_AMOUNT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colQTY_UNIT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colVOLUME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colVOLUME_UNIT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDAI As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colIVA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMISC_TAXES As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFOB_USD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFREIGTH_USD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colINSURANCE_USD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMISC_EXPENSES As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colORIGIN_COUNTRY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colREGION_CP As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAGREEMENT_1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAGREEMENT_2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRELATED_POLIZA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colORIGIN_DOC_ID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCODIGO_POLIZA_ORIGEN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCLIENT_CODE1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colACUERDO_COMERCIAL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPCTDAI As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colORIGIN_LINE_NUMBER As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents btnDelete As DevExpress.XtraBars.BarLargeButtonItem
    Friend WithEvents colLINE_NUMBER1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDOC_ID1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBULTOS1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCONSIGNATARIO_CODIGO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCONSIGNATARIO_NAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCONSIGNATARIO_NAME1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colVIN As DevExpress.XtraGrid.Columns.GridColumn
End Class
