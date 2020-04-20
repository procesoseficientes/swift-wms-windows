namespace MobilityScm.Modelo.Vistas
{
    partial class ConsultaPedidosPorVendedorVista
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConsultaPedidosPorVendedorVista));
            this.UiBarManager = new DevExpress.XtraBars.BarManager(this.components);
            this.UiBarraPrincipal = new DevExpress.XtraBars.Bar();
            this.UiFechaIncial = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.UiFechaFinal = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemDateEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.UiBarItemBodega = new DevExpress.XtraBars.BarEditItem();
            this.UiLookUpEditBodega = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.UiBotonRefrescar = new DevExpress.XtraBars.BarButtonItem();
            this.UiBotonExportarExcel = new DevExpress.XtraBars.BarButtonItem();
            this.UiBotonImprimir = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemGridLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.repositoryItemGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.UiSearchLookUpBodega = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.repositoryItemSearchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colWarehouseId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.UiContenedorPrincipal = new DevExpress.XtraGrid.GridControl();
            this.UiVistaPrincipal = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSellerCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSellerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQtySalesOrders = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQtyCustomers = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalSalesOrders = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQtyPendingToAssign = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQtyPicked = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQtyPendingToDispatch = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQtyDispatched = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalTimeSpent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UiDialogoParaGuardar = new System.Windows.Forms.SaveFileDialog();
            this.UiError = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.UiBarManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiLookUpEditBodega)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiSearchLookUpBodega)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiContenedorPrincipal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiVistaPrincipal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiError)).BeginInit();
            this.SuspendLayout();
            // 
            // UiBarManager
            // 
            this.UiBarManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.UiBarraPrincipal});
            this.UiBarManager.DockControls.Add(this.barDockControlTop);
            this.UiBarManager.DockControls.Add(this.barDockControlBottom);
            this.UiBarManager.DockControls.Add(this.barDockControlLeft);
            this.UiBarManager.DockControls.Add(this.barDockControlRight);
            this.UiBarManager.Form = this;
            this.UiBarManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.UiFechaIncial,
            this.UiFechaFinal,
            this.UiBotonRefrescar,
            this.UiBotonExportarExcel,
            this.UiBotonImprimir,
            this.UiBarItemBodega});
            this.UiBarManager.MainMenu = this.UiBarraPrincipal;
            this.UiBarManager.MaxItemId = 10;
            this.UiBarManager.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemDateEdit1,
            this.repositoryItemTextEdit1,
            this.repositoryItemDateEdit2,
            this.repositoryItemGridLookUpEdit1,
            this.UiSearchLookUpBodega,
            this.repositoryItemTextEdit2,
            this.UiLookUpEditBodega});
            // 
            // UiBarraPrincipal
            // 
            this.UiBarraPrincipal.BarName = "Main menu";
            this.UiBarraPrincipal.DockCol = 0;
            this.UiBarraPrincipal.DockRow = 0;
            this.UiBarraPrincipal.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.UiBarraPrincipal.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Width, this.UiFechaIncial, "", false, true, true, 153),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Width, this.UiFechaFinal, "", false, true, true, 130),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Width, this.UiBarItemBodega, "", false, true, true, 213),
            new DevExpress.XtraBars.LinkPersistInfo(this.UiBotonRefrescar),
            new DevExpress.XtraBars.LinkPersistInfo(this.UiBotonExportarExcel),
            new DevExpress.XtraBars.LinkPersistInfo(this.UiBotonImprimir)});
            this.UiBarraPrincipal.OptionsBar.AllowQuickCustomization = false;
            this.UiBarraPrincipal.OptionsBar.DrawDragBorder = false;
            this.UiBarraPrincipal.OptionsBar.UseWholeRow = true;
            this.UiBarraPrincipal.Text = "Main menu";
            // 
            // UiFechaIncial
            // 
            this.UiFechaIncial.Caption = "Fecha Inicial";
            this.UiFechaIncial.Edit = this.repositoryItemDateEdit1;
            this.UiFechaIncial.Glyph = ((System.Drawing.Image)(resources.GetObject("UiFechaIncial.Glyph")));
            this.UiFechaIncial.Id = 0;
            this.UiFechaIncial.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("UiFechaIncial.LargeGlyph")));
            this.UiFechaIncial.Name = "UiFechaIncial";
            this.UiFechaIncial.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
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
            // UiFechaFinal
            // 
            this.UiFechaFinal.Caption = "Fecha Final";
            this.UiFechaFinal.Edit = this.repositoryItemDateEdit2;
            this.UiFechaFinal.Glyph = ((System.Drawing.Image)(resources.GetObject("UiFechaFinal.Glyph")));
            this.UiFechaFinal.Id = 2;
            this.UiFechaFinal.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("UiFechaFinal.LargeGlyph")));
            this.UiFechaFinal.Name = "UiFechaFinal";
            this.UiFechaFinal.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // repositoryItemDateEdit2
            // 
            this.repositoryItemDateEdit2.AutoHeight = false;
            this.repositoryItemDateEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit2.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit2.Name = "repositoryItemDateEdit2";
            // 
            // UiBarItemBodega
            // 
            this.UiBarItemBodega.Caption = "Bodega";
            this.UiBarItemBodega.Edit = this.UiLookUpEditBodega;
            this.UiBarItemBodega.Id = 9;
            this.UiBarItemBodega.Name = "UiBarItemBodega";
            this.UiBarItemBodega.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // UiLookUpEditBodega
            // 
            this.UiLookUpEditBodega.AutoHeight = false;
            this.UiLookUpEditBodega.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.UiLookUpEditBodega.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("WAREHOUSE_ID", "Código de Bodega"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NAME", "Bodega")});
            this.UiLookUpEditBodega.DisplayMember = "NAME";
            this.UiLookUpEditBodega.Name = "UiLookUpEditBodega";
            this.UiLookUpEditBodega.NullText = "Seleccione Bodega";
            this.UiLookUpEditBodega.ValueMember = "WAREHOUSE_ID";
            // 
            // UiBotonRefrescar
            // 
            this.UiBotonRefrescar.Caption = "Refrescar";
            this.UiBotonRefrescar.Glyph = ((System.Drawing.Image)(resources.GetObject("UiBotonRefrescar.Glyph")));
            this.UiBotonRefrescar.Id = 4;
            this.UiBotonRefrescar.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("UiBotonRefrescar.LargeGlyph")));
            this.UiBotonRefrescar.Name = "UiBotonRefrescar";
            this.UiBotonRefrescar.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.UiBotonRefrescar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.UiBotonRefrescar_ItemClick);
            // 
            // UiBotonExportarExcel
            // 
            this.UiBotonExportarExcel.Caption = "Exportar a Excel";
            this.UiBotonExportarExcel.Glyph = ((System.Drawing.Image)(resources.GetObject("UiBotonExportarExcel.Glyph")));
            this.UiBotonExportarExcel.Id = 5;
            this.UiBotonExportarExcel.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("UiBotonExportarExcel.LargeGlyph")));
            this.UiBotonExportarExcel.Name = "UiBotonExportarExcel";
            this.UiBotonExportarExcel.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.UiBotonExportarExcel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.UiBotonExportarExcel_ItemClick);
            // 
            // UiBotonImprimir
            // 
            this.UiBotonImprimir.Caption = "Imprimir";
            this.UiBotonImprimir.Glyph = ((System.Drawing.Image)(resources.GetObject("UiBotonImprimir.Glyph")));
            this.UiBotonImprimir.Id = 6;
            this.UiBotonImprimir.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("UiBotonImprimir.LargeGlyph")));
            this.UiBotonImprimir.Name = "UiBotonImprimir";
            this.UiBotonImprimir.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.UiBotonImprimir.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.UiBotonImprimir_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1415, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 665);
            this.barDockControlBottom.Size = new System.Drawing.Size(1415, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 641);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1415, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 641);
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // repositoryItemGridLookUpEdit1
            // 
            this.repositoryItemGridLookUpEdit1.AutoHeight = false;
            this.repositoryItemGridLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemGridLookUpEdit1.Name = "repositoryItemGridLookUpEdit1";
            this.repositoryItemGridLookUpEdit1.View = this.repositoryItemGridLookUpEdit1View;
            // 
            // repositoryItemGridLookUpEdit1View
            // 
            this.repositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit1View.Name = "repositoryItemGridLookUpEdit1View";
            this.repositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // UiSearchLookUpBodega
            // 
            this.UiSearchLookUpBodega.AutoHeight = false;
            this.UiSearchLookUpBodega.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.UiSearchLookUpBodega.DisplayMember = "NAME";
            this.UiSearchLookUpBodega.Name = "UiSearchLookUpBodega";
            this.UiSearchLookUpBodega.NullText = "Seleccione Bodega";
            this.UiSearchLookUpBodega.ValueMember = "WAREHOUSE_ID";
            this.UiSearchLookUpBodega.View = this.repositoryItemSearchLookUpEdit1View;
            // 
            // repositoryItemSearchLookUpEdit1View
            // 
            this.repositoryItemSearchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colWarehouseId,
            this.colName});
            this.repositoryItemSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemSearchLookUpEdit1View.Name = "repositoryItemSearchLookUpEdit1View";
            this.repositoryItemSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemSearchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // colWarehouseId
            // 
            this.colWarehouseId.Caption = "Código de Bodega";
            this.colWarehouseId.FieldName = "WAREHOUSE_ID";
            this.colWarehouseId.Name = "colWarehouseId";
            this.colWarehouseId.OptionsColumn.AllowEdit = false;
            this.colWarehouseId.Visible = true;
            this.colWarehouseId.VisibleIndex = 0;
            // 
            // colName
            // 
            this.colName.Caption = "Bodega";
            this.colName.FieldName = "NAME";
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowEdit = false;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            // 
            // repositoryItemTextEdit2
            // 
            this.repositoryItemTextEdit2.AutoHeight = false;
            this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
            // 
            // UiContenedorPrincipal
            // 
            this.UiContenedorPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UiContenedorPrincipal.Location = new System.Drawing.Point(0, 24);
            this.UiContenedorPrincipal.MainView = this.UiVistaPrincipal;
            this.UiContenedorPrincipal.MenuManager = this.UiBarManager;
            this.UiContenedorPrincipal.Name = "UiContenedorPrincipal";
            this.UiContenedorPrincipal.Size = new System.Drawing.Size(1415, 641);
            this.UiContenedorPrincipal.TabIndex = 4;
            this.UiContenedorPrincipal.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.UiVistaPrincipal});
            // 
            // UiVistaPrincipal
            // 
            this.UiVistaPrincipal.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSellerCode,
            this.colSellerName,
            this.colQtySalesOrders,
            this.colQtyCustomers,
            this.colTotalSalesOrders,
            this.colQtyPendingToAssign,
            this.colQtyPicked,
            this.colQtyPendingToDispatch,
            this.colQtyDispatched,
            this.colTotalTimeSpent});
            this.UiVistaPrincipal.GridControl = this.UiContenedorPrincipal;
            this.UiVistaPrincipal.Name = "UiVistaPrincipal";
            this.UiVistaPrincipal.OptionsView.ShowAutoFilterRow = true;
            this.UiVistaPrincipal.OptionsView.ShowFooter = true;
            // 
            // colSellerCode
            // 
            this.colSellerCode.Caption = "Código de Vendedor";
            this.colSellerCode.FieldName = "SELLER_CODE";
            this.colSellerCode.Name = "colSellerCode";
            this.colSellerCode.OptionsColumn.AllowEdit = false;
            this.colSellerCode.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colSellerCode.Visible = true;
            this.colSellerCode.VisibleIndex = 0;
            // 
            // colSellerName
            // 
            this.colSellerName.Caption = "Vendedor";
            this.colSellerName.FieldName = "SELLER_NAME";
            this.colSellerName.Name = "colSellerName";
            this.colSellerName.OptionsColumn.AllowEdit = false;
            this.colSellerName.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colSellerName.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "SELLER_NAME", "Total:  {0:#,###,##0.##}")});
            this.colSellerName.Visible = true;
            this.colSellerName.VisibleIndex = 1;
            // 
            // colQtySalesOrders
            // 
            this.colQtySalesOrders.Caption = "Cantidad de Órdenes de Venta";
            this.colQtySalesOrders.DisplayFormat.FormatString = "{0:#,###,##0.##}";
            this.colQtySalesOrders.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colQtySalesOrders.FieldName = "QTY_SALES_ORDERS";
            this.colQtySalesOrders.Name = "colQtySalesOrders";
            this.colQtySalesOrders.OptionsColumn.AllowEdit = false;
            this.colQtySalesOrders.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "QTY_SALES_ORDERS", "Total:  {0:#,###,##0.##}")});
            this.colQtySalesOrders.Visible = true;
            this.colQtySalesOrders.VisibleIndex = 2;
            // 
            // colQtyCustomers
            // 
            this.colQtyCustomers.Caption = "Cantidad de Clientes";
            this.colQtyCustomers.DisplayFormat.FormatString = "{0:#,###,##0.##}";
            this.colQtyCustomers.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colQtyCustomers.FieldName = "QTY_CUSTOMERS";
            this.colQtyCustomers.Name = "colQtyCustomers";
            this.colQtyCustomers.OptionsColumn.AllowEdit = false;
            this.colQtyCustomers.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "QTY_CUSTOMERS", "Total:  {0:#,###,##0.##}")});
            this.colQtyCustomers.Visible = true;
            this.colQtyCustomers.VisibleIndex = 3;
            // 
            // colTotalSalesOrders
            // 
            this.colTotalSalesOrders.Caption = "Monto de Órdenes de Venta";
            this.colTotalSalesOrders.DisplayFormat.FormatString = "{0:#,###,##0.00}";
            this.colTotalSalesOrders.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalSalesOrders.FieldName = "TOTAL_SALES_ORDERS";
            this.colTotalSalesOrders.Name = "colTotalSalesOrders";
            this.colTotalSalesOrders.OptionsColumn.AllowEdit = false;
            this.colTotalSalesOrders.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TOTAL_SALES_ORDERS", "Total:  {0:#,###,##0.00}")});
            this.colTotalSalesOrders.Visible = true;
            this.colTotalSalesOrders.VisibleIndex = 4;
            // 
            // colQtyPendingToAssign
            // 
            this.colQtyPendingToAssign.Caption = "Pendientes de Asignar";
            this.colQtyPendingToAssign.DisplayFormat.FormatString = "{0:#,###,##0.##}";
            this.colQtyPendingToAssign.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colQtyPendingToAssign.FieldName = "QTY_PENDING_TO_ASSIGN";
            this.colQtyPendingToAssign.Name = "colQtyPendingToAssign";
            this.colQtyPendingToAssign.OptionsColumn.AllowEdit = false;
            this.colQtyPendingToAssign.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "QTY_PENDING_TO_ASSIGN", "Total:  {0:#,###,##0.##}")});
            this.colQtyPendingToAssign.Visible = true;
            this.colQtyPendingToAssign.VisibleIndex = 5;
            // 
            // colQtyPicked
            // 
            this.colQtyPicked.Caption = "Asignados";
            this.colQtyPicked.DisplayFormat.FormatString = "{0:#,###,##0.##}";
            this.colQtyPicked.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colQtyPicked.FieldName = "QTY_PICKED";
            this.colQtyPicked.Name = "colQtyPicked";
            this.colQtyPicked.OptionsColumn.AllowEdit = false;
            this.colQtyPicked.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "QTY_PICKED", "Total:  {0:#,###,##0.##}")});
            this.colQtyPicked.Visible = true;
            this.colQtyPicked.VisibleIndex = 6;
            // 
            // colQtyPendingToDispatch
            // 
            this.colQtyPendingToDispatch.Caption = "Sin Asignar";
            this.colQtyPendingToDispatch.DisplayFormat.FormatString = "{0:#,###,##0.##}";
            this.colQtyPendingToDispatch.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colQtyPendingToDispatch.FieldName = "QTY_PENDING_TO_DISPATCH";
            this.colQtyPendingToDispatch.Name = "colQtyPendingToDispatch";
            this.colQtyPendingToDispatch.OptionsColumn.AllowEdit = false;
            this.colQtyPendingToDispatch.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "QTY_PENDING_TO_DISPATCH", "Total:  {0:#,###,##0.##}")});
            this.colQtyPendingToDispatch.Visible = true;
            this.colQtyPendingToDispatch.VisibleIndex = 7;
            // 
            // colQtyDispatched
            // 
            this.colQtyDispatched.Caption = "Despachados";
            this.colQtyDispatched.DisplayFormat.FormatString = "{0:#,###,##0.##}";
            this.colQtyDispatched.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colQtyDispatched.FieldName = "QTY_DISPATCHED";
            this.colQtyDispatched.Name = "colQtyDispatched";
            this.colQtyDispatched.OptionsColumn.AllowEdit = false;
            this.colQtyDispatched.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "QTY_DISPATCHED", "Total:  {0:#,###,##0.##}")});
            this.colQtyDispatched.Visible = true;
            this.colQtyDispatched.VisibleIndex = 8;
            // 
            // colTotalTimeSpent
            // 
            this.colTotalTimeSpent.Caption = "Tiempo Total";
            this.colTotalTimeSpent.DisplayFormat.FormatString = "{0:%d} {0:hh}:{0:mm}:{0:ss}";
            this.colTotalTimeSpent.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colTotalTimeSpent.FieldName = "TOTAL_TIME_SPENT";
            this.colTotalTimeSpent.Name = "colTotalTimeSpent";
            this.colTotalTimeSpent.OptionsColumn.AllowEdit = false;
            this.colTotalTimeSpent.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TOTAL_TIME_SPENT", "Total: {0:%d} {0:hh}:{0:mm}:{0:ss}")});
            this.colTotalTimeSpent.Visible = true;
            this.colTotalTimeSpent.VisibleIndex = 9;
            // 
            // UiError
            // 
            this.UiError.ContainerControl = this;
            // 
            // ConsultaPedidosPorVendedorVista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1415, 665);
            this.Controls.Add(this.UiContenedorPrincipal);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ConsultaPedidosPorVendedorVista";
            this.Text = "Pedidos por Vendedor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConsultaPedidosPorVendedorVista_FormClosing);
            this.Load += new System.EventHandler(this.ConsultaPedidosPorVendedorVista_Load);
            ((System.ComponentModel.ISupportInitialize)(this.UiBarManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiLookUpEditBodega)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiSearchLookUpBodega)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiContenedorPrincipal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiVistaPrincipal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiError)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager UiBarManager;
        private DevExpress.XtraBars.Bar UiBarraPrincipal;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarEditItem UiFechaIncial;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraBars.BarEditItem UiFechaFinal;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit1;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit1View;
        private DevExpress.XtraBars.BarButtonItem UiBotonRefrescar;
        private DevExpress.XtraBars.BarButtonItem UiBotonExportarExcel;
        private DevExpress.XtraBars.BarButtonItem UiBotonImprimir;
        private DevExpress.XtraGrid.GridControl UiContenedorPrincipal;
        private DevExpress.XtraGrid.Views.Grid.GridView UiVistaPrincipal;
        private DevExpress.XtraGrid.Columns.GridColumn colSellerCode;
        private DevExpress.XtraGrid.Columns.GridColumn colSellerName;
        private DevExpress.XtraGrid.Columns.GridColumn colQtySalesOrders;
        private DevExpress.XtraGrid.Columns.GridColumn colQtyCustomers;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalSalesOrders;
        private DevExpress.XtraGrid.Columns.GridColumn colQtyPendingToAssign;
        private DevExpress.XtraGrid.Columns.GridColumn colQtyPicked;
        private DevExpress.XtraGrid.Columns.GridColumn colQtyPendingToDispatch;
        private DevExpress.XtraGrid.Columns.GridColumn colQtyDispatched;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalTimeSpent;
        private System.Windows.Forms.SaveFileDialog UiDialogoParaGuardar;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit UiSearchLookUpBodega;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemSearchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn colWarehouseId;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraBars.BarEditItem UiBarItemBodega;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit UiLookUpEditBodega;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider UiError;
    }
}