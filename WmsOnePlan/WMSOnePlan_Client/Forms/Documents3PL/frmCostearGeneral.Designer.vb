<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCostearGeneral
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
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar2 = New DevExpress.XtraBars.Bar()
        Me.btnGrabar = New DevExpress.XtraBars.BarLargeButtonItem()
        Me.btnCosteo = New DevExpress.XtraBars.BarLargeButtonItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.GridIngresos = New DevExpress.XtraGrid.GridControl()
        Me.GridViewIngresos = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colCLIENTE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cmbClientes = New DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit()
        Me.RepositoryItemGridLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colNUMERO_ORDEN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDOC_ID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFECHA_DOCUMENTO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCODIGO_POLIZA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colACUERDO_COMERCIAL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPOLIZA_ASEGURADA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPOLIZA_ASSIGNEDTO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridCostos = New DevExpress.XtraGrid.GridControl()
        Me.GridViewCostos = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colMATERIAL_BARCODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMATERIAL_CODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMATERIAL_DESCRIPTION = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMATERIAL_COST = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCalcEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit()
        Me.colQUANTITY_UNITS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SplitterItem1 = New DevExpress.XtraLayout.SplitterItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridIngresos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewIngresos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemGridLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridCostos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewCostos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCalcEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitterItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BarManager1
        '
        Me.BarManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Bar2})
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.btnGrabar, Me.btnCosteo})
        Me.BarManager1.MainMenu = Me.Bar2
        Me.BarManager1.MaxItemId = 2
        '
        'Bar2
        '
        Me.Bar2.BarName = "Main menu"
        Me.Bar2.DockCol = 0
        Me.Bar2.DockRow = 0
        Me.Bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar2.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.btnGrabar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.btnCosteo, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)})
        Me.Bar2.OptionsBar.MultiLine = True
        Me.Bar2.OptionsBar.UseWholeRow = True
        Me.Bar2.Text = "Main menu"
        '
        'btnGrabar
        '
        Me.btnGrabar.Caption = "&Grabar"
        Me.btnGrabar.Id = 0
        Me.btnGrabar.LargeGlyph = Global.WMSOnePlan_Client.My.Resources.Resources.save_large
        Me.btnGrabar.Name = "btnGrabar"
        '
        'btnCosteo
        '
        Me.btnCosteo.Caption = "&Cerrar Costeo"
        Me.btnCosteo.Glyph = Global.WMSOnePlan_Client.My.Resources.Resources.MarkAsFinal_Large
        Me.btnCosteo.Id = 1
        Me.btnCosteo.Name = "btnCosteo"
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(1116, 58)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 503)
        Me.barDockControlBottom.Size = New System.Drawing.Size(1116, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 58)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 445)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(1116, 58)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 445)
        '
        'GridIngresos
        '
        Me.GridIngresos.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridIngresos.Location = New System.Drawing.Point(12, 29)
        Me.GridIngresos.MainView = Me.GridViewIngresos
        Me.GridIngresos.MenuManager = Me.BarManager1
        Me.GridIngresos.Name = "GridIngresos"
        Me.GridIngresos.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.cmbClientes})
        Me.GridIngresos.Size = New System.Drawing.Size(595, 404)
        Me.GridIngresos.TabIndex = 0
        Me.GridIngresos.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewIngresos})
        '
        'GridViewIngresos
        '
        Me.GridViewIngresos.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colCLIENTE, Me.colNUMERO_ORDEN, Me.colDOC_ID, Me.colFECHA_DOCUMENTO, Me.colCODIGO_POLIZA, Me.colACUERDO_COMERCIAL, Me.colPOLIZA_ASEGURADA, Me.colPOLIZA_ASSIGNEDTO})
        Me.GridViewIngresos.GridControl = Me.GridIngresos
        Me.GridViewIngresos.Name = "GridViewIngresos"
        Me.GridViewIngresos.OptionsView.ShowAutoFilterRow = True
        '
        'colCLIENTE
        '
        Me.colCLIENTE.Caption = "CLIENTE"
        Me.colCLIENTE.ColumnEdit = Me.cmbClientes
        Me.colCLIENTE.FieldName = "CLIENT_CODE"
        Me.colCLIENTE.Name = "colCLIENTE"
        Me.colCLIENTE.OptionsColumn.AllowEdit = False
        Me.colCLIENTE.Visible = True
        Me.colCLIENTE.VisibleIndex = 0
        '
        'cmbClientes
        '
        Me.cmbClientes.AutoHeight = False
        Me.cmbClientes.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbClientes.Name = "cmbClientes"
        Me.cmbClientes.View = Me.RepositoryItemGridLookUpEdit1View
        '
        'RepositoryItemGridLookUpEdit1View
        '
        Me.RepositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.RepositoryItemGridLookUpEdit1View.Name = "RepositoryItemGridLookUpEdit1View"
        Me.RepositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.RepositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'colNUMERO_ORDEN
        '
        Me.colNUMERO_ORDEN.Caption = "REFERENCIA"
        Me.colNUMERO_ORDEN.FieldName = "NUMERO_ORDEN"
        Me.colNUMERO_ORDEN.Name = "colNUMERO_ORDEN"
        Me.colNUMERO_ORDEN.OptionsColumn.AllowEdit = False
        Me.colNUMERO_ORDEN.Visible = True
        Me.colNUMERO_ORDEN.VisibleIndex = 1
        '
        'colDOC_ID
        '
        Me.colDOC_ID.Caption = "DOCUMENTO"
        Me.colDOC_ID.FieldName = "DOC_ID"
        Me.colDOC_ID.Name = "colDOC_ID"
        Me.colDOC_ID.OptionsColumn.AllowEdit = False
        Me.colDOC_ID.Visible = True
        Me.colDOC_ID.VisibleIndex = 2
        '
        'colFECHA_DOCUMENTO
        '
        Me.colFECHA_DOCUMENTO.Caption = "FECHA DOCUMENTO"
        Me.colFECHA_DOCUMENTO.FieldName = "FECHA_DOCUMENTO"
        Me.colFECHA_DOCUMENTO.Name = "colFECHA_DOCUMENTO"
        Me.colFECHA_DOCUMENTO.OptionsColumn.AllowEdit = False
        Me.colFECHA_DOCUMENTO.Visible = True
        Me.colFECHA_DOCUMENTO.VisibleIndex = 3
        '
        'colCODIGO_POLIZA
        '
        Me.colCODIGO_POLIZA.Caption = "POLIZA"
        Me.colCODIGO_POLIZA.FieldName = "CODIGO_POLIZA"
        Me.colCODIGO_POLIZA.Name = "colCODIGO_POLIZA"
        Me.colCODIGO_POLIZA.OptionsColumn.AllowEdit = False
        Me.colCODIGO_POLIZA.Visible = True
        Me.colCODIGO_POLIZA.VisibleIndex = 4
        '
        'colACUERDO_COMERCIAL
        '
        Me.colACUERDO_COMERCIAL.Caption = "ACUERDO COMERCIAL"
        Me.colACUERDO_COMERCIAL.FieldName = "ACUERDO_COMERCIAL"
        Me.colACUERDO_COMERCIAL.Name = "colACUERDO_COMERCIAL"
        Me.colACUERDO_COMERCIAL.OptionsColumn.AllowEdit = False
        '
        'colPOLIZA_ASEGURADA
        '
        Me.colPOLIZA_ASEGURADA.Caption = "Codigo Poliza Asegurada"
        Me.colPOLIZA_ASEGURADA.FieldName = "POLIZA_ASEGURADA"
        Me.colPOLIZA_ASEGURADA.Name = "colPOLIZA_ASEGURADA"
        Me.colPOLIZA_ASEGURADA.OptionsColumn.AllowEdit = False
        '
        'colPOLIZA_ASSIGNEDTO
        '
        Me.colPOLIZA_ASSIGNEDTO.Caption = "Operador Asignado"
        Me.colPOLIZA_ASSIGNEDTO.FieldName = "POLIZA_ASSIGNEDTO"
        Me.colPOLIZA_ASSIGNEDTO.Name = "colPOLIZA_ASSIGNEDTO"
        Me.colPOLIZA_ASSIGNEDTO.OptionsColumn.AllowEdit = False
        '
        'GridCostos
        '
        Me.GridCostos.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridCostos.Location = New System.Drawing.Point(616, 29)
        Me.GridCostos.MainView = Me.GridViewCostos
        Me.GridCostos.MenuManager = Me.BarManager1
        Me.GridCostos.Name = "GridCostos"
        Me.GridCostos.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCalcEdit1})
        Me.GridCostos.Size = New System.Drawing.Size(488, 404)
        Me.GridCostos.TabIndex = 0
        Me.GridCostos.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewCostos})
        '
        'GridViewCostos
        '
        Me.GridViewCostos.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colMATERIAL_BARCODE, Me.colMATERIAL_CODE, Me.colMATERIAL_DESCRIPTION, Me.colMATERIAL_COST, Me.colQUANTITY_UNITS})
        Me.GridViewCostos.GridControl = Me.GridCostos
        Me.GridViewCostos.Name = "GridViewCostos"
        Me.GridViewCostos.OptionsView.ShowAutoFilterRow = True
        '
        'colMATERIAL_BARCODE
        '
        Me.colMATERIAL_BARCODE.Caption = "CODIGO BARRAS"
        Me.colMATERIAL_BARCODE.FieldName = "MATERIAL_BARCODE"
        Me.colMATERIAL_BARCODE.Name = "colMATERIAL_BARCODE"
        Me.colMATERIAL_BARCODE.OptionsColumn.AllowEdit = False
        Me.colMATERIAL_BARCODE.Visible = True
        Me.colMATERIAL_BARCODE.VisibleIndex = 0
        '
        'colMATERIAL_CODE
        '
        Me.colMATERIAL_CODE.Caption = "CODIGO"
        Me.colMATERIAL_CODE.FieldName = "MATERIAL_CODE"
        Me.colMATERIAL_CODE.Name = "colMATERIAL_CODE"
        Me.colMATERIAL_CODE.OptionsColumn.AllowEdit = False
        Me.colMATERIAL_CODE.Visible = True
        Me.colMATERIAL_CODE.VisibleIndex = 1
        '
        'colMATERIAL_DESCRIPTION
        '
        Me.colMATERIAL_DESCRIPTION.Caption = "PRODUCTO"
        Me.colMATERIAL_DESCRIPTION.FieldName = "MATERIAL_DESCRIPTION"
        Me.colMATERIAL_DESCRIPTION.Name = "colMATERIAL_DESCRIPTION"
        Me.colMATERIAL_DESCRIPTION.OptionsColumn.AllowEdit = False
        Me.colMATERIAL_DESCRIPTION.Visible = True
        Me.colMATERIAL_DESCRIPTION.VisibleIndex = 2
        '
        'colMATERIAL_COST
        '
        Me.colMATERIAL_COST.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.colMATERIAL_COST.AppearanceCell.Options.UseBackColor = True
        Me.colMATERIAL_COST.Caption = "COSTO"
        Me.colMATERIAL_COST.ColumnEdit = Me.RepositoryItemCalcEdit1
        Me.colMATERIAL_COST.FieldName = "MATERIAL_COST"
        Me.colMATERIAL_COST.Name = "colMATERIAL_COST"
        Me.colMATERIAL_COST.Visible = True
        Me.colMATERIAL_COST.VisibleIndex = 3
        '
        'RepositoryItemCalcEdit1
        '
        Me.RepositoryItemCalcEdit1.AutoHeight = False
        Me.RepositoryItemCalcEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemCalcEdit1.Name = "RepositoryItemCalcEdit1"
        '
        'colQUANTITY_UNITS
        '
        Me.colQUANTITY_UNITS.Caption = "UNIDADES"
        Me.colQUANTITY_UNITS.FieldName = "QUANTITY_UNITS"
        Me.colQUANTITY_UNITS.Name = "colQUANTITY_UNITS"
        Me.colQUANTITY_UNITS.OptionsColumn.AllowEdit = False
        Me.colQUANTITY_UNITS.Visible = True
        Me.colQUANTITY_UNITS.VisibleIndex = 4
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.LabelControl2)
        Me.LayoutControl1.Controls.Add(Me.LabelControl1)
        Me.LayoutControl1.Controls.Add(Me.GridIngresos)
        Me.LayoutControl1.Controls.Add(Me.GridCostos)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 58)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(519, 309, 250, 350)
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(1116, 445)
        Me.LayoutControl1.TabIndex = 9
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(611, 12)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(493, 13)
        Me.LabelControl2.StyleController = Me.LayoutControl1
        Me.LabelControl2.TabIndex = 5
        Me.LabelControl2.Text = "  Costos"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 12)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(595, 13)
        Me.LabelControl1.StyleController = Me.LayoutControl1
        Me.LabelControl1.TabIndex = 4
        Me.LabelControl1.Text = "Ingresos"
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.CustomizationFormText = "Root"
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.SplitterItem1, Me.LayoutControlItem3, Me.LayoutControlItem4})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1116, 445)
        Me.LayoutControlGroup1.Text = "Root"
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.GridIngresos
        Me.LayoutControlItem1.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 17)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(599, 408)
        Me.LayoutControlItem1.Text = "LayoutControlItem1"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextToControlDistance = 0
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.GridCostos
        Me.LayoutControlItem2.CustomizationFormText = "LayoutControlItem2"
        Me.LayoutControlItem2.Location = New System.Drawing.Point(604, 17)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(492, 408)
        Me.LayoutControlItem2.Text = "LayoutControlItem2"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextToControlDistance = 0
        Me.LayoutControlItem2.TextVisible = False
        '
        'SplitterItem1
        '
        Me.SplitterItem1.AllowHotTrack = True
        Me.SplitterItem1.CustomizationFormText = "SplitterItem1"
        Me.SplitterItem1.Location = New System.Drawing.Point(599, 17)
        Me.SplitterItem1.Name = "SplitterItem1"
        Me.SplitterItem1.Size = New System.Drawing.Size(5, 408)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.LabelControl1
        Me.LayoutControlItem3.CustomizationFormText = "LayoutControlItem3"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem3.MinSize = New System.Drawing.Size(41, 17)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(599, 17)
        Me.LayoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem3.Text = "LayoutControlItem3"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextToControlDistance = 0
        Me.LayoutControlItem3.TextVisible = False
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.LabelControl2
        Me.LayoutControlItem4.CustomizationFormText = "Costos"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(599, 0)
        Me.LayoutControlItem4.MinSize = New System.Drawing.Size(70, 17)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(497, 17)
        Me.LayoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem4.Text = "Costos"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextToControlDistance = 0
        Me.LayoutControlItem4.TextVisible = False
        '
        'frmCostearGeneral
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1116, 503)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "frmCostearGeneral"
        Me.Text = "Costear Ingreso de General"
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridIngresos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewIngresos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbClientes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemGridLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridCostos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewCostos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCalcEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitterItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents Bar2 As DevExpress.XtraBars.Bar
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents GridIngresos As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewIngresos As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridCostos As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewCostos As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SplitterItem1 As DevExpress.XtraLayout.SplitterItem
    Friend WithEvents btnGrabar As DevExpress.XtraBars.BarLargeButtonItem
    Friend WithEvents colCLIENTE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cmbClientes As DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit
    Friend WithEvents RepositoryItemGridLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colNUMERO_ORDEN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDOC_ID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFECHA_DOCUMENTO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCODIGO_POLIZA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMATERIAL_BARCODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMATERIAL_CODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMATERIAL_DESCRIPTION As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMATERIAL_COST As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCalcEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit
    Friend WithEvents colQUANTITY_UNITS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colACUERDO_COMERCIAL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents btnCosteo As DevExpress.XtraBars.BarLargeButtonItem
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents colPOLIZA_ASEGURADA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPOLIZA_ASSIGNEDTO As DevExpress.XtraGrid.Columns.GridColumn
End Class
