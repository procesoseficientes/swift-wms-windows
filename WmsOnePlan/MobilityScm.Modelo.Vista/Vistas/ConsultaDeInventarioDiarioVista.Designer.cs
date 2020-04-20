namespace MobilityScm.Modelo.Vistas
{
    partial class ConsultaDeInventarioDiarioVista
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConsultaDeInventarioDiarioVista));
            this.UiControladorBarras = new DevExpress.XtraBars.BarManager(this.components);
            this.UiBarraPrincipal = new DevExpress.XtraBars.Bar();
            this.UiFecha = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.UiBarItemBodega = new DevExpress.XtraBars.BarEditItem();
            this.UiSearchLookUpBodegas = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.UiVistaBodegas = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colWAREHOUSE_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UiBarButtonRefrescar = new DevExpress.XtraBars.BarButtonItem();
            this.UiBarButtonExportarAExcel = new DevExpress.XtraBars.BarButtonItem();
            this.UiBarButtonExpandir = new DevExpress.XtraBars.BarButtonItem();
            this.UiBarButtonColapsar = new DevExpress.XtraBars.BarButtonItem();
            this.UiBarButtonReporte = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.UiGridControlReporteDeInventario = new DevExpress.XtraGrid.GridControl();
            this.UiVistaReporteDeInventario = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colWAREHOUSE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMATERIAL_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMATERIAL_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIS_MASTER_PACK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UiCheckEditMasterPack = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colINITIAL_INVENTORY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQTY_INCOME_TRANSACTION = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQTY_OUTPUT_TRANSACTION = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFINAL_INVENTORY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UiDialogoGuardar = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.UiControladorBarras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiSearchLookUpBodegas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiVistaBodegas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiGridControlReporteDeInventario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiVistaReporteDeInventario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiCheckEditMasterPack)).BeginInit();
            this.SuspendLayout();
            // 
            // UiControladorBarras
            // 
            this.UiControladorBarras.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.UiBarraPrincipal});
            this.UiControladorBarras.DockControls.Add(this.barDockControlTop);
            this.UiControladorBarras.DockControls.Add(this.barDockControlBottom);
            this.UiControladorBarras.DockControls.Add(this.barDockControlLeft);
            this.UiControladorBarras.DockControls.Add(this.barDockControlRight);
            this.UiControladorBarras.Form = this;
            this.UiControladorBarras.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.UiFecha,
            this.UiBarButtonRefrescar,
            this.UiBarButtonExportarAExcel,
            this.UiBarButtonExpandir,
            this.UiBarButtonColapsar,
            this.UiBarButtonReporte,
            this.UiBarItemBodega});
            this.UiControladorBarras.MainMenu = this.UiBarraPrincipal;
            this.UiControladorBarras.MaxItemId = 9;
            this.UiControladorBarras.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemDateEdit1,
            this.UiSearchLookUpBodegas});
            // 
            // UiBarraPrincipal
            // 
            this.UiBarraPrincipal.BarName = "Main menu";
            this.UiBarraPrincipal.DockCol = 0;
            this.UiBarraPrincipal.DockRow = 0;
            this.UiBarraPrincipal.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.UiBarraPrincipal.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Width, this.UiFecha, "", false, true, true, 135),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Width, this.UiBarItemBodega, "", false, true, true, 189),
            new DevExpress.XtraBars.LinkPersistInfo(this.UiBarButtonRefrescar),
            new DevExpress.XtraBars.LinkPersistInfo(this.UiBarButtonExportarAExcel),
            new DevExpress.XtraBars.LinkPersistInfo(this.UiBarButtonExpandir),
            new DevExpress.XtraBars.LinkPersistInfo(this.UiBarButtonColapsar),
            new DevExpress.XtraBars.LinkPersistInfo(this.UiBarButtonReporte)});
            this.UiBarraPrincipal.OptionsBar.AllowQuickCustomization = false;
            this.UiBarraPrincipal.OptionsBar.DrawDragBorder = false;
            this.UiBarraPrincipal.OptionsBar.MultiLine = true;
            this.UiBarraPrincipal.OptionsBar.UseWholeRow = true;
            this.UiBarraPrincipal.Text = "Main menu";
            // 
            // UiFecha
            // 
            this.UiFecha.Caption = "Fecha";
            this.UiFecha.Edit = this.repositoryItemDateEdit1;
            this.UiFecha.Glyph = ((System.Drawing.Image)(resources.GetObject("UiFecha.Glyph")));
            this.UiFecha.Id = 1;
            this.UiFecha.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("UiFecha.LargeGlyph")));
            this.UiFecha.Name = "UiFecha";
            this.UiFecha.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            // 
            // UiBarItemBodega
            // 
            this.UiBarItemBodega.Caption = "Bodega";
            this.UiBarItemBodega.Edit = this.UiSearchLookUpBodegas;
            this.UiBarItemBodega.Glyph = ((System.Drawing.Image)(resources.GetObject("UiBarItemBodega.Glyph")));
            this.UiBarItemBodega.Id = 8;
            this.UiBarItemBodega.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("UiBarItemBodega.LargeGlyph")));
            this.UiBarItemBodega.Name = "UiBarItemBodega";
            this.UiBarItemBodega.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // UiSearchLookUpBodegas
            // 
            this.UiSearchLookUpBodegas.AutoHeight = false;
            this.UiSearchLookUpBodegas.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.UiSearchLookUpBodegas.DisplayMember = "NAME";
            this.UiSearchLookUpBodegas.Name = "UiSearchLookUpBodegas";
            this.UiSearchLookUpBodegas.NullText = "Seleccione Bodega(s)";
            this.UiSearchLookUpBodegas.ValueMember = "WAREHOUSE_ID";
            this.UiSearchLookUpBodegas.View = this.UiVistaBodegas;
            this.UiSearchLookUpBodegas.CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(this.UiSearchLookUpBodegas_CustomDisplayText);
            // 
            // UiVistaBodegas
            // 
            this.UiVistaBodegas.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colWAREHOUSE_ID,
            this.colNAME});
            this.UiVistaBodegas.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.UiVistaBodegas.Name = "UiVistaBodegas";
            this.UiVistaBodegas.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.UiVistaBodegas.OptionsSelection.MultiSelect = true;
            this.UiVistaBodegas.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.UiVistaBodegas.OptionsView.ShowGroupPanel = false;
            this.UiVistaBodegas.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.UiVistaBodegas_SelectionChanged);
            // 
            // colWAREHOUSE_ID
            // 
            this.colWAREHOUSE_ID.Caption = "Código Bodega";
            this.colWAREHOUSE_ID.FieldName = "WAREHOUSE_ID";
            this.colWAREHOUSE_ID.Name = "colWAREHOUSE_ID";
            this.colWAREHOUSE_ID.OptionsColumn.AllowEdit = false;
            this.colWAREHOUSE_ID.Visible = true;
            this.colWAREHOUSE_ID.VisibleIndex = 2;
            // 
            // colNAME
            // 
            this.colNAME.Caption = "Bodega";
            this.colNAME.FieldName = "NAME";
            this.colNAME.Name = "colNAME";
            this.colNAME.OptionsColumn.AllowEdit = false;
            this.colNAME.Visible = true;
            this.colNAME.VisibleIndex = 1;
            // 
            // UiBarButtonRefrescar
            // 
            this.UiBarButtonRefrescar.Caption = "Refrescar";
            this.UiBarButtonRefrescar.Glyph = ((System.Drawing.Image)(resources.GetObject("UiBarButtonRefrescar.Glyph")));
            this.UiBarButtonRefrescar.Id = 2;
            this.UiBarButtonRefrescar.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("UiBarButtonRefrescar.LargeGlyph")));
            this.UiBarButtonRefrescar.Name = "UiBarButtonRefrescar";
            this.UiBarButtonRefrescar.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.UiBarButtonRefrescar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.UiBarButtonRefrescar_ItemClick);
            // 
            // UiBarButtonExportarAExcel
            // 
            this.UiBarButtonExportarAExcel.Caption = "Exportar a Excel";
            this.UiBarButtonExportarAExcel.Glyph = ((System.Drawing.Image)(resources.GetObject("UiBarButtonExportarAExcel.Glyph")));
            this.UiBarButtonExportarAExcel.Id = 3;
            this.UiBarButtonExportarAExcel.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("UiBarButtonExportarAExcel.LargeGlyph")));
            this.UiBarButtonExportarAExcel.Name = "UiBarButtonExportarAExcel";
            this.UiBarButtonExportarAExcel.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.UiBarButtonExportarAExcel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.UiBarButtonExportarAExcel_ItemClick);
            // 
            // UiBarButtonExpandir
            // 
            this.UiBarButtonExpandir.Caption = "Expandir";
            this.UiBarButtonExpandir.Glyph = ((System.Drawing.Image)(resources.GetObject("UiBarButtonExpandir.Glyph")));
            this.UiBarButtonExpandir.Id = 4;
            this.UiBarButtonExpandir.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("UiBarButtonExpandir.LargeGlyph")));
            this.UiBarButtonExpandir.Name = "UiBarButtonExpandir";
            this.UiBarButtonExpandir.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.UiBarButtonExpandir.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.UiBarButtonExpandir_ItemClick);
            // 
            // UiBarButtonColapsar
            // 
            this.UiBarButtonColapsar.Caption = "Colapsar";
            this.UiBarButtonColapsar.Glyph = ((System.Drawing.Image)(resources.GetObject("UiBarButtonColapsar.Glyph")));
            this.UiBarButtonColapsar.Id = 5;
            this.UiBarButtonColapsar.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("UiBarButtonColapsar.LargeGlyph")));
            this.UiBarButtonColapsar.Name = "UiBarButtonColapsar";
            this.UiBarButtonColapsar.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.UiBarButtonColapsar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.UiBarButtonColapsar_ItemClick);
            // 
            // UiBarButtonReporte
            // 
            this.UiBarButtonReporte.Caption = "Imprimir";
            this.UiBarButtonReporte.Glyph = ((System.Drawing.Image)(resources.GetObject("UiBarButtonReporte.Glyph")));
            this.UiBarButtonReporte.Id = 6;
            this.UiBarButtonReporte.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("UiBarButtonReporte.LargeGlyph")));
            this.UiBarButtonReporte.Name = "UiBarButtonReporte";
            this.UiBarButtonReporte.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.UiBarButtonReporte.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.UiBarButtonReporte_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1268, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 718);
            this.barDockControlBottom.Size = new System.Drawing.Size(1268, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 694);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1268, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 694);
            // 
            // UiGridControlReporteDeInventario
            // 
            this.UiGridControlReporteDeInventario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UiGridControlReporteDeInventario.Location = new System.Drawing.Point(0, 24);
            this.UiGridControlReporteDeInventario.MainView = this.UiVistaReporteDeInventario;
            this.UiGridControlReporteDeInventario.MenuManager = this.UiControladorBarras;
            this.UiGridControlReporteDeInventario.Name = "UiGridControlReporteDeInventario";
            this.UiGridControlReporteDeInventario.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.UiCheckEditMasterPack});
            this.UiGridControlReporteDeInventario.Size = new System.Drawing.Size(1268, 694);
            this.UiGridControlReporteDeInventario.TabIndex = 4;
            this.UiGridControlReporteDeInventario.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.UiVistaReporteDeInventario});
            // 
            // UiVistaReporteDeInventario
            // 
            this.UiVistaReporteDeInventario.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colWAREHOUSE,
            this.colMATERIAL_ID,
            this.colMATERIAL_NAME,
            this.colIS_MASTER_PACK,
            this.colINITIAL_INVENTORY,
            this.colQTY_INCOME_TRANSACTION,
            this.colQTY_OUTPUT_TRANSACTION,
            this.colFINAL_INVENTORY});
            this.UiVistaReporteDeInventario.GridControl = this.UiGridControlReporteDeInventario;
            this.UiVistaReporteDeInventario.GroupCount = 1;
            this.UiVistaReporteDeInventario.Name = "UiVistaReporteDeInventario";
            this.UiVistaReporteDeInventario.OptionsView.ShowAutoFilterRow = true;
            this.UiVistaReporteDeInventario.OptionsView.ShowFooter = true;
            this.UiVistaReporteDeInventario.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colWAREHOUSE, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colWAREHOUSE
            // 
            this.colWAREHOUSE.Caption = "Bodega";
            this.colWAREHOUSE.FieldName = "WAREHOUSE";
            this.colWAREHOUSE.Name = "colWAREHOUSE";
            this.colWAREHOUSE.OptionsColumn.AllowEdit = false;
            this.colWAREHOUSE.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "WAREHOUSE", "{0}")});
            this.colWAREHOUSE.Visible = true;
            this.colWAREHOUSE.VisibleIndex = 0;
            // 
            // colMATERIAL_ID
            // 
            this.colMATERIAL_ID.Caption = "Código Material";
            this.colMATERIAL_ID.FieldName = "MATERIAL_ID";
            this.colMATERIAL_ID.Name = "colMATERIAL_ID";
            this.colMATERIAL_ID.OptionsColumn.AllowEdit = false;
            this.colMATERIAL_ID.Visible = true;
            this.colMATERIAL_ID.VisibleIndex = 0;
            // 
            // colMATERIAL_NAME
            // 
            this.colMATERIAL_NAME.Caption = "Material";
            this.colMATERIAL_NAME.FieldName = "MATERIAL_NAME";
            this.colMATERIAL_NAME.Name = "colMATERIAL_NAME";
            this.colMATERIAL_NAME.OptionsColumn.AllowEdit = false;
            this.colMATERIAL_NAME.Visible = true;
            this.colMATERIAL_NAME.VisibleIndex = 1;
            // 
            // colIS_MASTER_PACK
            // 
            this.colIS_MASTER_PACK.Caption = "Es Master Pack";
            this.colIS_MASTER_PACK.ColumnEdit = this.UiCheckEditMasterPack;
            this.colIS_MASTER_PACK.FieldName = "IS_MASTER_PACK";
            this.colIS_MASTER_PACK.Name = "colIS_MASTER_PACK";
            this.colIS_MASTER_PACK.OptionsColumn.AllowEdit = false;
            this.colIS_MASTER_PACK.Visible = true;
            this.colIS_MASTER_PACK.VisibleIndex = 3;
            // 
            // UiCheckEditMasterPack
            // 
            this.UiCheckEditMasterPack.AutoHeight = false;
            this.UiCheckEditMasterPack.Name = "UiCheckEditMasterPack";
            this.UiCheckEditMasterPack.ValueChecked = 1;
            this.UiCheckEditMasterPack.ValueUnchecked = 0;
            // 
            // colINITIAL_INVENTORY
            // 
            this.colINITIAL_INVENTORY.Caption = "Inventario Inicial";
            this.colINITIAL_INVENTORY.DisplayFormat.FormatString = "{0:#,##0.00}";
            this.colINITIAL_INVENTORY.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colINITIAL_INVENTORY.FieldName = "INITIAL_INVENTORY";
            this.colINITIAL_INVENTORY.Name = "colINITIAL_INVENTORY";
            this.colINITIAL_INVENTORY.OptionsColumn.AllowEdit = false;
            this.colINITIAL_INVENTORY.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "INITIAL_INVENTORY", "Total: {0:#,##0.00}")});
            this.colINITIAL_INVENTORY.Visible = true;
            this.colINITIAL_INVENTORY.VisibleIndex = 2;
            // 
            // colQTY_INCOME_TRANSACTION
            // 
            this.colQTY_INCOME_TRANSACTION.Caption = "Ingresos";
            this.colQTY_INCOME_TRANSACTION.DisplayFormat.FormatString = "{0:#,##0.00}";
            this.colQTY_INCOME_TRANSACTION.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colQTY_INCOME_TRANSACTION.FieldName = "QTY_INCOME_TRANSACTION";
            this.colQTY_INCOME_TRANSACTION.Name = "colQTY_INCOME_TRANSACTION";
            this.colQTY_INCOME_TRANSACTION.OptionsColumn.AllowEdit = false;
            this.colQTY_INCOME_TRANSACTION.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "QTY_INCOME_TRANSACTION", "Total: {0:#,##0.00}")});
            this.colQTY_INCOME_TRANSACTION.Visible = true;
            this.colQTY_INCOME_TRANSACTION.VisibleIndex = 4;
            // 
            // colQTY_OUTPUT_TRANSACTION
            // 
            this.colQTY_OUTPUT_TRANSACTION.Caption = "Despachos";
            this.colQTY_OUTPUT_TRANSACTION.DisplayFormat.FormatString = "{0:#,##0.00}";
            this.colQTY_OUTPUT_TRANSACTION.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colQTY_OUTPUT_TRANSACTION.FieldName = "QTY_OUTPUT_TRANSACTION";
            this.colQTY_OUTPUT_TRANSACTION.Name = "colQTY_OUTPUT_TRANSACTION";
            this.colQTY_OUTPUT_TRANSACTION.OptionsColumn.AllowEdit = false;
            this.colQTY_OUTPUT_TRANSACTION.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "QTY_OUTPUT_TRANSACTION", "Total: {0:#,##0.00}")});
            this.colQTY_OUTPUT_TRANSACTION.Visible = true;
            this.colQTY_OUTPUT_TRANSACTION.VisibleIndex = 5;
            // 
            // colFINAL_INVENTORY
            // 
            this.colFINAL_INVENTORY.Caption = "Inventario Final";
            this.colFINAL_INVENTORY.DisplayFormat.FormatString = "{0:#,##0.00}";
            this.colFINAL_INVENTORY.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colFINAL_INVENTORY.FieldName = "FINAL_INVENTORY";
            this.colFINAL_INVENTORY.Name = "colFINAL_INVENTORY";
            this.colFINAL_INVENTORY.OptionsColumn.AllowEdit = false;
            this.colFINAL_INVENTORY.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "FINAL_INVENTORY", "Total: {0:#,##0.00}")});
            this.colFINAL_INVENTORY.Visible = true;
            this.colFINAL_INVENTORY.VisibleIndex = 6;
            // 
            // ConsultaDeInventarioDiarioVista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1268, 718);
            this.Controls.Add(this.UiGridControlReporteDeInventario);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ConsultaDeInventarioDiarioVista";
            this.Text = "Consulta De Inventario Diario";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConsultaDeInventarioDiarioVista_FormClosing);
            this.Load += new System.EventHandler(this.ConsultaDeInventarioDiarioVista_Load);
            ((System.ComponentModel.ISupportInitialize)(this.UiControladorBarras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiSearchLookUpBodegas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiVistaBodegas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiGridControlReporteDeInventario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiVistaReporteDeInventario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiCheckEditMasterPack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager UiControladorBarras;
        private DevExpress.XtraBars.Bar UiBarraPrincipal;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarEditItem UiFecha;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraBars.BarButtonItem UiBarButtonRefrescar;
        private DevExpress.XtraBars.BarButtonItem UiBarButtonExportarAExcel;
        private DevExpress.XtraBars.BarButtonItem UiBarButtonColapsar;
        private DevExpress.XtraBars.BarButtonItem UiBarButtonReporte;
        private DevExpress.XtraBars.BarButtonItem UiBarButtonExpandir;
        private DevExpress.XtraGrid.GridControl UiGridControlReporteDeInventario;
        private DevExpress.XtraGrid.Views.Grid.GridView UiVistaReporteDeInventario;
        private DevExpress.XtraGrid.Columns.GridColumn colWAREHOUSE;
        private DevExpress.XtraGrid.Columns.GridColumn colMATERIAL_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colMATERIAL_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn colINITIAL_INVENTORY;
        private DevExpress.XtraGrid.Columns.GridColumn colQTY_INCOME_TRANSACTION;
        private DevExpress.XtraGrid.Columns.GridColumn colQTY_OUTPUT_TRANSACTION;
        private DevExpress.XtraGrid.Columns.GridColumn colFINAL_INVENTORY;
        private System.Windows.Forms.SaveFileDialog UiDialogoGuardar;
        private DevExpress.XtraBars.BarEditItem UiBarItemBodega;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit UiSearchLookUpBodegas;
        private DevExpress.XtraGrid.Views.Grid.GridView UiVistaBodegas;
        private DevExpress.XtraGrid.Columns.GridColumn colWAREHOUSE_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colNAME;
        private DevExpress.XtraGrid.Columns.GridColumn colIS_MASTER_PACK;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit UiCheckEditMasterPack;
    }
}