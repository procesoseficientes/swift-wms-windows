<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInfo_InvConsolidate
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
        Dim GridFormatRule1 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleExpression1 As DevExpress.XtraEditors.FormatConditionRuleExpression = New DevExpress.XtraEditors.FormatConditionRuleExpression()
        Dim GridFormatRule2 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleExpression2 As DevExpress.XtraEditors.FormatConditionRuleExpression = New DevExpress.XtraEditors.FormatConditionRuleExpression()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInfo_InvConsolidate))
        Me.Timer_Inventory = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn_ClientOwner = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn_Prod = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn_Descripcion = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn_Disp = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn_Reservado = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn_Unidades = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn_Maneja_Serie = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridControl2 = New DevExpress.XtraGrid.GridControl()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn_Class = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn_Ubicacion = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn_Bin = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn_Detail_Disp = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn_Detail_Hold = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UiColPorcentajePeso = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UiColSobrepeso = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colStatusName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colInventarioBloqueado = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colColor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UiColTono = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UiColCalibre = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colProjectCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNombreProyecto = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.barOpciones = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar1 = New DevExpress.XtraBars.Bar()
        Me.barBtnAcualizacion = New DevExpress.XtraBars.BarButtonItem()
        Me.barBtnSave = New DevExpress.XtraBars.BarButtonItem()
        Me.barBtnPrint = New DevExpress.XtraBars.BarButtonItem()
        Me.UiBtnExportarConsolidado = New DevExpress.XtraBars.BarButtonItem()
        Me.UiBtnExportarDetalle = New DevExpress.XtraBars.BarButtonItem()
        Me.Bar3 = New DevExpress.XtraBars.Bar()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.BarButtonItem2 = New DevExpress.XtraBars.BarButtonItem()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.Panel1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.barOpciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Timer_Inventory
        '
        Me.Timer_Inventory.Interval = 10000
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(838, 23)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Info: Inventario Consolidado"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.SplitContainer1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 47)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(838, 328)
        Me.Panel1.TabIndex = 20
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.GridControl1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.GridControl2)
        Me.SplitContainer1.Size = New System.Drawing.Size(838, 328)
        Me.SplitContainer1.SplitterDistance = 500
        Me.SplitContainer1.TabIndex = 0
        '
        'GridControl1
        '
        Me.GridControl1.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.Location = New System.Drawing.Point(0, 0)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(496, 324)
        Me.GridControl1.TabIndex = 21
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn_ClientOwner, Me.GridColumn_Prod, Me.GridColumn_Descripcion, Me.GridColumn_Disp, Me.GridColumn_Reservado, Me.GridColumn_Unidades, Me.GridColumn_Maneja_Serie})
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.GroupPanelText = "Organizar por columna"
        Me.GridView1.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "QTY", Nothing, ""), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "MATERIAL_ID", Nothing, "")})
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.AnimationType = DevExpress.XtraGrid.Views.Base.GridAnimationType.AnimateFocusedItem
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        Me.GridView1.OptionsView.ShowFooter = True
        Me.GridView1.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never
        Me.GridView1.ViewCaption = "InventarioOnLine"
        '
        'GridColumn_ClientOwner
        '
        Me.GridColumn_ClientOwner.Caption = "Dueño"
        Me.GridColumn_ClientOwner.FieldName = "CLIENT_OWNER"
        Me.GridColumn_ClientOwner.Name = "GridColumn_ClientOwner"
        Me.GridColumn_ClientOwner.OptionsColumn.AllowEdit = False
        Me.GridColumn_ClientOwner.OptionsColumn.ReadOnly = True
        Me.GridColumn_ClientOwner.Visible = True
        Me.GridColumn_ClientOwner.VisibleIndex = 6
        '
        'GridColumn_Prod
        '
        Me.GridColumn_Prod.Caption = "Producto"
        Me.GridColumn_Prod.FieldName = "MATERIAL_ID"
        Me.GridColumn_Prod.Name = "GridColumn_Prod"
        Me.GridColumn_Prod.OptionsColumn.AllowEdit = False
        Me.GridColumn_Prod.OptionsColumn.ReadOnly = True
        Me.GridColumn_Prod.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)})
        Me.GridColumn_Prod.Visible = True
        Me.GridColumn_Prod.VisibleIndex = 0
        Me.GridColumn_Prod.Width = 65
        '
        'GridColumn_Descripcion
        '
        Me.GridColumn_Descripcion.Caption = "Descripcion"
        Me.GridColumn_Descripcion.FieldName = "MATERIAL_NAME"
        Me.GridColumn_Descripcion.Name = "GridColumn_Descripcion"
        Me.GridColumn_Descripcion.OptionsColumn.AllowEdit = False
        Me.GridColumn_Descripcion.Visible = True
        Me.GridColumn_Descripcion.VisibleIndex = 1
        Me.GridColumn_Descripcion.Width = 265
        '
        'GridColumn_Disp
        '
        Me.GridColumn_Disp.Caption = "Inv.Disp."
        Me.GridColumn_Disp.FieldName = "AVAILABLE"
        Me.GridColumn_Disp.Name = "GridColumn_Disp"
        Me.GridColumn_Disp.OptionsColumn.AllowEdit = False
        Me.GridColumn_Disp.OptionsColumn.AllowFocus = False
        Me.GridColumn_Disp.OptionsColumn.ReadOnly = True
        Me.GridColumn_Disp.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GridColumn_Disp.Visible = True
        Me.GridColumn_Disp.VisibleIndex = 2
        '
        'GridColumn_Reservado
        '
        Me.GridColumn_Reservado.Caption = "Inv.Reservado"
        Me.GridColumn_Reservado.FieldName = "RESERVED"
        Me.GridColumn_Reservado.Name = "GridColumn_Reservado"
        Me.GridColumn_Reservado.OptionsColumn.AllowEdit = False
        Me.GridColumn_Reservado.OptionsColumn.AllowFocus = False
        Me.GridColumn_Reservado.OptionsColumn.ReadOnly = True
        Me.GridColumn_Reservado.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GridColumn_Reservado.Visible = True
        Me.GridColumn_Reservado.VisibleIndex = 3
        '
        'GridColumn_Unidades
        '
        Me.GridColumn_Unidades.Caption = "Inv.Fisico"
        Me.GridColumn_Unidades.FieldName = "QTY"
        Me.GridColumn_Unidades.Name = "GridColumn_Unidades"
        Me.GridColumn_Unidades.OptionsColumn.AllowEdit = False
        Me.GridColumn_Unidades.OptionsColumn.AllowFocus = False
        Me.GridColumn_Unidades.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridColumn_Unidades.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn_Unidades.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GridColumn_Unidades.Visible = True
        Me.GridColumn_Unidades.VisibleIndex = 4
        Me.GridColumn_Unidades.Width = 93
        '
        'GridColumn_Maneja_Serie
        '
        Me.GridColumn_Maneja_Serie.Caption = "Maneja Serie"
        Me.GridColumn_Maneja_Serie.FieldName = "HANDLE_SERIAL"
        Me.GridColumn_Maneja_Serie.Name = "GridColumn_Maneja_Serie"
        Me.GridColumn_Maneja_Serie.OptionsColumn.AllowEdit = False
        Me.GridColumn_Maneja_Serie.OptionsColumn.ReadOnly = True
        Me.GridColumn_Maneja_Serie.Visible = True
        Me.GridColumn_Maneja_Serie.VisibleIndex = 5
        '
        'GridControl2
        '
        Me.GridControl2.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl2.Location = New System.Drawing.Point(0, 0)
        Me.GridControl2.MainView = Me.GridView2
        Me.GridControl2.Name = "GridControl2"
        Me.GridControl2.Size = New System.Drawing.Size(330, 324)
        Me.GridControl2.TabIndex = 18
        Me.GridControl2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView2})
        '
        'GridView2
        '
        Me.GridView2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.GridView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn_Class, Me.GridColumn_Ubicacion, Me.GridColumn_Bin, Me.GridColumn_Detail_Disp, Me.GridColumn_Detail_Hold, Me.GridColumn3, Me.UiColPorcentajePeso, Me.UiColSobrepeso, Me.colStatusName, Me.colInventarioBloqueado, Me.colColor, Me.UiColTono, Me.UiColCalibre, Me.colProjectCode, Me.colNombreProyecto})
        GridFormatRule1.ApplyToRow = True
        GridFormatRule1.Name = "UiReglaPesoUbicacionAl50"
        FormatConditionRuleExpression1.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        FormatConditionRuleExpression1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        FormatConditionRuleExpression1.Appearance.Options.UseBackColor = True
        FormatConditionRuleExpression1.Expression = "[WEIGHT_PERCENT] > 50 And [WEIGHT_PERCENT] < 90"
        GridFormatRule1.Rule = FormatConditionRuleExpression1
        GridFormatRule2.ApplyToRow = True
        GridFormatRule2.Name = "UiReglaPesoUbicacionAl90"
        FormatConditionRuleExpression2.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        FormatConditionRuleExpression2.Appearance.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        FormatConditionRuleExpression2.Appearance.BorderColor = System.Drawing.Color.Red
        FormatConditionRuleExpression2.Appearance.Options.UseBackColor = True
        FormatConditionRuleExpression2.Appearance.Options.UseBorderColor = True
        FormatConditionRuleExpression2.Expression = "[WEIGHT_PERCENT] >= 90"
        GridFormatRule2.Rule = FormatConditionRuleExpression2
        Me.GridView2.FormatRules.Add(GridFormatRule1)
        Me.GridView2.FormatRules.Add(GridFormatRule2)
        Me.GridView2.GridControl = Me.GridControl2
        Me.GridView2.GroupCount = 1
        Me.GridView2.GroupPanelText = "Organizar por columna"
        Me.GridView2.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "QTY", Nothing, ""), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "MATERIAL_ID", Nothing, "")})
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsView.AnimationType = DevExpress.XtraGrid.Views.Base.GridAnimationType.AnimateFocusedItem
        Me.GridView2.OptionsView.ShowAutoFilterRow = True
        Me.GridView2.OptionsView.ShowFooter = True
        Me.GridView2.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn_Class, DevExpress.Data.ColumnSortOrder.Ascending)})
        Me.GridView2.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never
        Me.GridView2.ViewCaption = "InventarioOnLine"
        '
        'GridColumn_Class
        '
        Me.GridColumn_Class.Caption = "Bodega"
        Me.GridColumn_Class.FieldName = "CURRENT_WAREHOUSE"
        Me.GridColumn_Class.Name = "GridColumn_Class"
        Me.GridColumn_Class.OptionsColumn.AllowEdit = False
        Me.GridColumn_Class.Width = 67
        '
        'GridColumn_Ubicacion
        '
        Me.GridColumn_Ubicacion.Caption = "Ubicacion"
        Me.GridColumn_Ubicacion.FieldName = "CURRENT_LOCATION"
        Me.GridColumn_Ubicacion.Name = "GridColumn_Ubicacion"
        Me.GridColumn_Ubicacion.OptionsColumn.AllowEdit = False
        Me.GridColumn_Ubicacion.OptionsColumn.FixedWidth = True
        Me.GridColumn_Ubicacion.OptionsColumn.ReadOnly = True
        Me.GridColumn_Ubicacion.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GridColumn_Ubicacion.Visible = True
        Me.GridColumn_Ubicacion.VisibleIndex = 0
        Me.GridColumn_Ubicacion.Width = 112
        '
        'GridColumn_Bin
        '
        Me.GridColumn_Bin.Caption = "Licencia"
        Me.GridColumn_Bin.FieldName = "LICENSE_ID"
        Me.GridColumn_Bin.Name = "GridColumn_Bin"
        Me.GridColumn_Bin.OptionsColumn.AllowEdit = False
        Me.GridColumn_Bin.Visible = True
        Me.GridColumn_Bin.VisibleIndex = 1
        '
        'GridColumn_Detail_Disp
        '
        Me.GridColumn_Detail_Disp.Caption = "Cantidad"
        Me.GridColumn_Detail_Disp.FieldName = "QTY"
        Me.GridColumn_Detail_Disp.Name = "GridColumn_Detail_Disp"
        Me.GridColumn_Detail_Disp.OptionsColumn.AllowEdit = False
        Me.GridColumn_Detail_Disp.OptionsColumn.AllowFocus = False
        Me.GridColumn_Detail_Disp.OptionsColumn.ReadOnly = True
        Me.GridColumn_Detail_Disp.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GridColumn_Detail_Disp.Visible = True
        Me.GridColumn_Detail_Disp.VisibleIndex = 4
        '
        'GridColumn_Detail_Hold
        '
        Me.GridColumn_Detail_Hold.Caption = "Código Poliza"
        Me.GridColumn_Detail_Hold.FieldName = "CODIGO_POLIZA"
        Me.GridColumn_Detail_Hold.Name = "GridColumn_Detail_Hold"
        Me.GridColumn_Detail_Hold.OptionsColumn.AllowEdit = False
        Me.GridColumn_Detail_Hold.OptionsColumn.AllowFocus = False
        Me.GridColumn_Detail_Hold.OptionsColumn.ReadOnly = True
        Me.GridColumn_Detail_Hold.Visible = True
        Me.GridColumn_Detail_Hold.VisibleIndex = 3
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Regimen"
        Me.GridColumn3.FieldName = "REGIMEN"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.OptionsColumn.AllowEdit = False
        Me.GridColumn3.OptionsColumn.AllowFocus = False
        Me.GridColumn3.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridColumn3.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 2
        Me.GridColumn3.Width = 93
        '
        'UiColPorcentajePeso
        '
        Me.UiColPorcentajePeso.Caption = "% Peso"
        Me.UiColPorcentajePeso.FieldName = "WEIGHT_PERCENT"
        Me.UiColPorcentajePeso.Name = "UiColPorcentajePeso"
        Me.UiColPorcentajePeso.OptionsColumn.AllowEdit = False
        Me.UiColPorcentajePeso.OptionsColumn.ReadOnly = True
        Me.UiColPorcentajePeso.Visible = True
        Me.UiColPorcentajePeso.VisibleIndex = 5
        '
        'UiColSobrepeso
        '
        Me.UiColSobrepeso.Caption = "Sobrepeso"
        Me.UiColSobrepeso.FieldName = "IS_OVERWEIGHT"
        Me.UiColSobrepeso.Name = "UiColSobrepeso"
        Me.UiColSobrepeso.OptionsColumn.AllowEdit = False
        Me.UiColSobrepeso.OptionsColumn.ReadOnly = True
        Me.UiColSobrepeso.Visible = True
        Me.UiColSobrepeso.VisibleIndex = 6
        '
        'colStatusName
        '
        Me.colStatusName.Caption = "Estado"
        Me.colStatusName.FieldName = "STATUS_NAME"
        Me.colStatusName.Name = "colStatusName"
        Me.colStatusName.OptionsColumn.AllowEdit = False
        Me.colStatusName.OptionsColumn.ReadOnly = True
        Me.colStatusName.Visible = True
        Me.colStatusName.VisibleIndex = 7
        '
        'colInventarioBloqueado
        '
        Me.colInventarioBloqueado.Caption = "Bloqueado"
        Me.colInventarioBloqueado.FieldName = "BLOCKS_INVENTORY"
        Me.colInventarioBloqueado.Name = "colInventarioBloqueado"
        Me.colInventarioBloqueado.OptionsColumn.AllowEdit = False
        Me.colInventarioBloqueado.OptionsColumn.ReadOnly = True
        Me.colInventarioBloqueado.Visible = True
        Me.colInventarioBloqueado.VisibleIndex = 8
        '
        'colColor
        '
        Me.colColor.Caption = "Color"
        Me.colColor.FieldName = "COLOR"
        Me.colColor.Name = "colColor"
        Me.colColor.OptionsColumn.AllowEdit = False
        Me.colColor.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.[False]
        Me.colColor.OptionsColumn.ReadOnly = True
        Me.colColor.Visible = True
        Me.colColor.VisibleIndex = 9
        '
        'UiColTono
        '
        Me.UiColTono.Caption = "Tono"
        Me.UiColTono.FieldName = "TONE"
        Me.UiColTono.Name = "UiColTono"
        Me.UiColTono.OptionsColumn.AllowEdit = False
        Me.UiColTono.OptionsColumn.ReadOnly = True
        Me.UiColTono.Visible = True
        Me.UiColTono.VisibleIndex = 10
        '
        'UiColCalibre
        '
        Me.UiColCalibre.Caption = "Calibre"
        Me.UiColCalibre.FieldName = "CALIBER"
        Me.UiColCalibre.Name = "UiColCalibre"
        Me.UiColCalibre.OptionsColumn.AllowEdit = False
        Me.UiColCalibre.OptionsColumn.ReadOnly = True
        Me.UiColCalibre.Visible = True
        Me.UiColCalibre.VisibleIndex = 11
        '
        'colProjectCode
        '
        Me.colProjectCode.Caption = "Código Proyecto"
        Me.colProjectCode.FieldName = "PROJECT_CODE"
        Me.colProjectCode.Name = "colProjectCode"
        Me.colProjectCode.OptionsColumn.AllowEdit = False
        Me.colProjectCode.Visible = True
        Me.colProjectCode.VisibleIndex = 12
        '
        'colNombreProyecto
        '
        Me.colNombreProyecto.Caption = "Nombre Proyecto"
        Me.colNombreProyecto.FieldName = "PROJECT_SHORT_NAME"
        Me.colNombreProyecto.Name = "colNombreProyecto"
        Me.colNombreProyecto.OptionsColumn.AllowEdit = False
        Me.colNombreProyecto.Visible = True
        Me.colNombreProyecto.VisibleIndex = 13
        '
        'barOpciones
        '
        Me.barOpciones.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Bar1, Me.Bar3})
        Me.barOpciones.DockControls.Add(Me.barDockControlTop)
        Me.barOpciones.DockControls.Add(Me.barDockControlBottom)
        Me.barOpciones.DockControls.Add(Me.barDockControlLeft)
        Me.barOpciones.DockControls.Add(Me.barDockControlRight)
        Me.barOpciones.Form = Me
        Me.barOpciones.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.barBtnAcualizacion, Me.barBtnSave, Me.BarButtonItem2, Me.barBtnPrint, Me.UiBtnExportarConsolidado, Me.UiBtnExportarDetalle})
        Me.barOpciones.MaxItemId = 6
        Me.barOpciones.StatusBar = Me.Bar3
        '
        'Bar1
        '
        Me.Bar1.BarName = "Herramientas"
        Me.Bar1.DockCol = 0
        Me.Bar1.DockRow = 0
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.barBtnAcualizacion, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.barBtnSave, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.barBtnPrint, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(Me.UiBtnExportarConsolidado), New DevExpress.XtraBars.LinkPersistInfo(Me.UiBtnExportarDetalle)})
        Me.Bar1.OptionsBar.AllowQuickCustomization = False
        Me.Bar1.OptionsBar.DrawDragBorder = False
        Me.Bar1.OptionsBar.UseWholeRow = True
        Me.Bar1.Text = "Herramientas"
        '
        'barBtnAcualizacion
        '
        Me.barBtnAcualizacion.Caption = "Actualizacion Manual"
        Me.barBtnAcualizacion.Id = 0
        Me.barBtnAcualizacion.ImageOptions.Image = CType(resources.GetObject("barBtnAcualizacion.ImageOptions.Image"), System.Drawing.Image)
        Me.barBtnAcualizacion.ImageOptions.LargeImage = CType(resources.GetObject("barBtnAcualizacion.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.barBtnAcualizacion.Name = "barBtnAcualizacion"
        '
        'barBtnSave
        '
        Me.barBtnSave.Caption = "Grabar"
        Me.barBtnSave.Id = 1
        Me.barBtnSave.ImageOptions.Image = CType(resources.GetObject("barBtnSave.ImageOptions.Image"), System.Drawing.Image)
        Me.barBtnSave.ImageOptions.LargeImage = CType(resources.GetObject("barBtnSave.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.barBtnSave.Name = "barBtnSave"
        '
        'barBtnPrint
        '
        Me.barBtnPrint.Caption = "Imprimir"
        Me.barBtnPrint.Id = 3
        Me.barBtnPrint.ImageOptions.Image = CType(resources.GetObject("barBtnPrint.ImageOptions.Image"), System.Drawing.Image)
        Me.barBtnPrint.ImageOptions.LargeImage = CType(resources.GetObject("barBtnPrint.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.barBtnPrint.Name = "barBtnPrint"
        '
        'UiBtnExportarConsolidado
        '
        Me.UiBtnExportarConsolidado.Caption = "Exportar Consolidado"
        Me.UiBtnExportarConsolidado.Id = 4
        Me.UiBtnExportarConsolidado.ImageOptions.Image = CType(resources.GetObject("UiBtnExportarConsolidado.ImageOptions.Image"), System.Drawing.Image)
        Me.UiBtnExportarConsolidado.ImageOptions.LargeImage = CType(resources.GetObject("UiBtnExportarConsolidado.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.UiBtnExportarConsolidado.Name = "UiBtnExportarConsolidado"
        Me.UiBtnExportarConsolidado.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        '
        'UiBtnExportarDetalle
        '
        Me.UiBtnExportarDetalle.Caption = "Exportar Detalle"
        Me.UiBtnExportarDetalle.Id = 5
        Me.UiBtnExportarDetalle.ImageOptions.Image = CType(resources.GetObject("UiBtnExportarDetalle.ImageOptions.Image"), System.Drawing.Image)
        Me.UiBtnExportarDetalle.ImageOptions.LargeImage = CType(resources.GetObject("UiBtnExportarDetalle.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.UiBtnExportarDetalle.Name = "UiBtnExportarDetalle"
        Me.UiBtnExportarDetalle.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        '
        'Bar3
        '
        Me.Bar3.BarName = "Barra de estado"
        Me.Bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom
        Me.Bar3.DockCol = 0
        Me.Bar3.DockRow = 0
        Me.Bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom
        Me.Bar3.OptionsBar.AllowQuickCustomization = False
        Me.Bar3.OptionsBar.DrawDragBorder = False
        Me.Bar3.OptionsBar.UseWholeRow = True
        Me.Bar3.Text = "Barra de estado"
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Manager = Me.barOpciones
        Me.barDockControlTop.Size = New System.Drawing.Size(838, 24)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 375)
        Me.barDockControlBottom.Manager = Me.barOpciones
        Me.barDockControlBottom.Size = New System.Drawing.Size(838, 20)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 24)
        Me.barDockControlLeft.Manager = Me.barOpciones
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 351)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(838, 24)
        Me.barDockControlRight.Manager = Me.barOpciones
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 351)
        '
        'BarButtonItem2
        '
        Me.BarButtonItem2.Caption = "BarButtonItem2"
        Me.BarButtonItem2.Id = 2
        Me.BarButtonItem2.Name = "BarButtonItem2"
        '
        'frmInfo_InvConsolidate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(838, 395)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.Name = "frmInfo_InvConsolidate"
        Me.Text = "Inventario Consolidado"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(false)
        Me.SplitContainer1.Panel1.ResumeLayout(false)
        Me.SplitContainer1.Panel2.ResumeLayout(false)
        CType(Me.SplitContainer1,System.ComponentModel.ISupportInitialize).EndInit
        Me.SplitContainer1.ResumeLayout(false)
        CType(Me.GridControl1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.GridView1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.GridControl2,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.GridView2,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.barOpciones,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents Timer_Inventory As System.Windows.Forms.Timer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn_Prod As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn_Descripcion As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn_Unidades As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridControl2 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn_Class As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn_Ubicacion As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn_Bin As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn_Disp As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn_Reservado As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn_Detail_Disp As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn_Detail_Hold As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents barOpciones As DevExpress.XtraBars.BarManager
    Friend WithEvents Bar1 As DevExpress.XtraBars.Bar
    Friend WithEvents barBtnAcualizacion As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents barBtnSave As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Bar3 As DevExpress.XtraBars.Bar
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarButtonItem2 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents barBtnPrint As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents GridColumn_Maneja_Serie As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UiColPorcentajePeso As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UiColSobrepeso As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colStatusName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colInventarioBloqueado As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colColor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UiColTono As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UiColCalibre As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colProjectCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNombreProyecto As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UiBtnExportarConsolidado As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents UiBtnExportarDetalle As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents GridColumn_ClientOwner As DevExpress.XtraGrid.Columns.GridColumn
End Class
