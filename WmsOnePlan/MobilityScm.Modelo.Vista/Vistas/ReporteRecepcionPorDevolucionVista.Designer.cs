namespace MobilityScm.Modelo.Vistas
{
    partial class ReporteRecepcionPorDevolucionVista
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReporteRecepcionPorDevolucionVista));
            this.UiBarManager = new DevExpress.XtraBars.BarManager(this.components);
            this.UiBarraPrincipal = new DevExpress.XtraBars.Bar();
            this.UiFechaInicial = new DevExpress.XtraBars.BarEditItem();
            this.UiRepositoryItemFechaInicial = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.UiFechaFinal = new DevExpress.XtraBars.BarEditItem();
            this.UiRepositoryItemFechaFinal = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.UiBarBodegas = new DevExpress.XtraBars.BarEditItem();
            this.UiRepositorySearchLookBodegas = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.UiVistaBodegas = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colWAREHOUSE_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UiBarButtonRefrescar = new DevExpress.XtraBars.BarButtonItem();
            this.UiBarButtonExcel = new DevExpress.XtraBars.BarButtonItem();
            this.UiBarButtonContraer = new DevExpress.XtraBars.BarButtonItem();
            this.UiBarButtonExpandir = new DevExpress.XtraBars.BarButtonItem();
            this.UiBarButtonConsolidado = new DevExpress.XtraBars.BarButtonItem();
            this.UiBarButtonDetallado = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.UiGridControlDevoluciones = new DevExpress.XtraGrid.GridControl();
            this.UiVistaDevoluciones = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colINVOICE_DOC_NUM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCLIENT_CODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCLIENT_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPLATE_NUMBER = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTASK_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colENVIADO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colERP_REFERENCE_DOC_NUM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMATERIAL_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMATERIAL_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQTY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRECEPTION_QTY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UiDialogoGuardar = new System.Windows.Forms.SaveFileDialog();
            this.btnSaveLayout = new DevExpress.XtraBars.BarButtonItem();
            this.SaveLayout = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.UiBarManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiRepositoryItemFechaInicial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiRepositoryItemFechaInicial.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiRepositoryItemFechaFinal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiRepositoryItemFechaFinal.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiRepositorySearchLookBodegas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiVistaBodegas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiGridControlDevoluciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiVistaDevoluciones)).BeginInit();
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
            this.UiFechaInicial,
            this.UiFechaFinal,
            this.UiBarButtonRefrescar,
            this.UiBarButtonExcel,
            this.UiBarButtonContraer,
            this.UiBarButtonExpandir,
            this.UiBarButtonConsolidado,
            this.UiBarButtonDetallado,
            this.UiBarBodegas,
            this.btnSaveLayout});
            this.UiBarManager.MaxItemId = 13;
            this.UiBarManager.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.UiRepositoryItemFechaInicial,
            this.UiRepositoryItemFechaFinal,
            this.UiRepositorySearchLookBodegas});
            // 
            // UiBarraPrincipal
            // 
            this.UiBarraPrincipal.BarName = "Tools";
            this.UiBarraPrincipal.DockCol = 0;
            this.UiBarraPrincipal.DockRow = 0;
            this.UiBarraPrincipal.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.UiBarraPrincipal.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Width, this.UiFechaInicial, "", false, true, true, 115),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Width, this.UiFechaFinal, "", false, true, true, 124),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Width, this.UiBarBodegas, "", false, true, true, 144),
            new DevExpress.XtraBars.LinkPersistInfo(this.UiBarButtonRefrescar),
            new DevExpress.XtraBars.LinkPersistInfo(this.UiBarButtonExcel),
            new DevExpress.XtraBars.LinkPersistInfo(this.UiBarButtonContraer),
            new DevExpress.XtraBars.LinkPersistInfo(this.UiBarButtonExpandir),
            new DevExpress.XtraBars.LinkPersistInfo(this.UiBarButtonConsolidado),
            new DevExpress.XtraBars.LinkPersistInfo(this.UiBarButtonDetallado),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnSaveLayout)});
            this.UiBarraPrincipal.OptionsBar.AllowQuickCustomization = false;
            this.UiBarraPrincipal.OptionsBar.DisableCustomization = true;
            this.UiBarraPrincipal.OptionsBar.DrawDragBorder = false;
            this.UiBarraPrincipal.OptionsBar.MultiLine = true;
            this.UiBarraPrincipal.OptionsBar.UseWholeRow = true;
            this.UiBarraPrincipal.Text = "Tools";
            // 
            // UiFechaInicial
            // 
            this.UiFechaInicial.Caption = "Fecha Inicial";
            this.UiFechaInicial.Edit = this.UiRepositoryItemFechaInicial;
            this.UiFechaInicial.Id = 3;
            this.UiFechaInicial.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("UiFechaInicial.ImageOptions.Image")));
            this.UiFechaInicial.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("UiFechaInicial.ImageOptions.LargeImage")));
            this.UiFechaInicial.Name = "UiFechaInicial";
            this.UiFechaInicial.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // UiRepositoryItemFechaInicial
            // 
            this.UiRepositoryItemFechaInicial.AutoHeight = false;
            this.UiRepositoryItemFechaInicial.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.UiRepositoryItemFechaInicial.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.UiRepositoryItemFechaInicial.Name = "UiRepositoryItemFechaInicial";
            // 
            // UiFechaFinal
            // 
            this.UiFechaFinal.Caption = "Fecha Final";
            this.UiFechaFinal.Edit = this.UiRepositoryItemFechaFinal;
            this.UiFechaFinal.Id = 4;
            this.UiFechaFinal.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("UiFechaFinal.ImageOptions.Image")));
            this.UiFechaFinal.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("UiFechaFinal.ImageOptions.LargeImage")));
            this.UiFechaFinal.Name = "UiFechaFinal";
            this.UiFechaFinal.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // UiRepositoryItemFechaFinal
            // 
            this.UiRepositoryItemFechaFinal.AutoHeight = false;
            this.UiRepositoryItemFechaFinal.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.UiRepositoryItemFechaFinal.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.UiRepositoryItemFechaFinal.Name = "UiRepositoryItemFechaFinal";
            // 
            // UiBarBodegas
            // 
            this.UiBarBodegas.Caption = "Bodegas";
            this.UiBarBodegas.Edit = this.UiRepositorySearchLookBodegas;
            this.UiBarBodegas.Id = 11;
            this.UiBarBodegas.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("UiBarBodegas.ImageOptions.Image")));
            this.UiBarBodegas.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("UiBarBodegas.ImageOptions.LargeImage")));
            this.UiBarBodegas.Name = "UiBarBodegas";
            this.UiBarBodegas.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // UiRepositorySearchLookBodegas
            // 
            this.UiRepositorySearchLookBodegas.AutoHeight = false;
            this.UiRepositorySearchLookBodegas.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.UiRepositorySearchLookBodegas.Name = "UiRepositorySearchLookBodegas";
            this.UiRepositorySearchLookBodegas.PopupView = this.UiVistaBodegas;
            this.UiRepositorySearchLookBodegas.CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(this.UiRepositorySearchLookBodegas_CustomDisplayText);
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
            this.colWAREHOUSE_ID.Caption = "Código";
            this.colWAREHOUSE_ID.FieldName = "WAREHOUSE_ID";
            this.colWAREHOUSE_ID.Name = "colWAREHOUSE_ID";
            this.colWAREHOUSE_ID.OptionsColumn.AllowEdit = false;
            this.colWAREHOUSE_ID.Visible = true;
            this.colWAREHOUSE_ID.VisibleIndex = 1;
            // 
            // colNAME
            // 
            this.colNAME.Caption = "Nombre";
            this.colNAME.FieldName = "NAME";
            this.colNAME.Name = "colNAME";
            this.colNAME.OptionsColumn.AllowEdit = false;
            this.colNAME.Visible = true;
            this.colNAME.VisibleIndex = 2;
            // 
            // UiBarButtonRefrescar
            // 
            this.UiBarButtonRefrescar.Caption = "Refrescar";
            this.UiBarButtonRefrescar.Id = 5;
            this.UiBarButtonRefrescar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("UiBarButtonRefrescar.ImageOptions.Image")));
            this.UiBarButtonRefrescar.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("UiBarButtonRefrescar.ImageOptions.LargeImage")));
            this.UiBarButtonRefrescar.Name = "UiBarButtonRefrescar";
            this.UiBarButtonRefrescar.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.UiBarButtonRefrescar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.UiBarButtonRefrescar_ItemClick);
            // 
            // UiBarButtonExcel
            // 
            this.UiBarButtonExcel.Caption = "Exportar a Excel";
            this.UiBarButtonExcel.Id = 6;
            this.UiBarButtonExcel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("UiBarButtonExcel.ImageOptions.Image")));
            this.UiBarButtonExcel.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("UiBarButtonExcel.ImageOptions.LargeImage")));
            this.UiBarButtonExcel.Name = "UiBarButtonExcel";
            this.UiBarButtonExcel.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.UiBarButtonExcel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.UiBarButtonExcel_ItemClick);
            // 
            // UiBarButtonContraer
            // 
            this.UiBarButtonContraer.Caption = "Contraer";
            this.UiBarButtonContraer.Id = 7;
            this.UiBarButtonContraer.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("UiBarButtonContraer.ImageOptions.Image")));
            this.UiBarButtonContraer.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("UiBarButtonContraer.ImageOptions.LargeImage")));
            this.UiBarButtonContraer.Name = "UiBarButtonContraer";
            this.UiBarButtonContraer.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.UiBarButtonContraer.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.UiBarButtonContraer_ItemClick);
            // 
            // UiBarButtonExpandir
            // 
            this.UiBarButtonExpandir.Caption = "Expandir";
            this.UiBarButtonExpandir.Id = 8;
            this.UiBarButtonExpandir.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("UiBarButtonExpandir.ImageOptions.Image")));
            this.UiBarButtonExpandir.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("UiBarButtonExpandir.ImageOptions.LargeImage")));
            this.UiBarButtonExpandir.Name = "UiBarButtonExpandir";
            this.UiBarButtonExpandir.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.UiBarButtonExpandir.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.UiBarButtonExpandir_ItemClick);
            // 
            // UiBarButtonConsolidado
            // 
            this.UiBarButtonConsolidado.Caption = "Reporte Consolidado";
            this.UiBarButtonConsolidado.Id = 9;
            this.UiBarButtonConsolidado.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("UiBarButtonConsolidado.ImageOptions.Image")));
            this.UiBarButtonConsolidado.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("UiBarButtonConsolidado.ImageOptions.LargeImage")));
            this.UiBarButtonConsolidado.Name = "UiBarButtonConsolidado";
            this.UiBarButtonConsolidado.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.UiBarButtonConsolidado.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.UiBarButtonConsolidado_ItemClick);
            // 
            // UiBarButtonDetallado
            // 
            this.UiBarButtonDetallado.Caption = "Reporte Detallado";
            this.UiBarButtonDetallado.Id = 10;
            this.UiBarButtonDetallado.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("UiBarButtonDetallado.ImageOptions.Image")));
            this.UiBarButtonDetallado.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("UiBarButtonDetallado.ImageOptions.LargeImage")));
            this.UiBarButtonDetallado.Name = "UiBarButtonDetallado";
            this.UiBarButtonDetallado.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.UiBarButtonDetallado.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.UiBarButtonDetallado_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.UiBarManager;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.barDockControlTop.Size = new System.Drawing.Size(3218, 46);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 1258);
            this.barDockControlBottom.Manager = this.UiBarManager;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.barDockControlBottom.Size = new System.Drawing.Size(3218, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 46);
            this.barDockControlLeft.Manager = this.UiBarManager;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 1212);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(3218, 46);
            this.barDockControlRight.Manager = this.UiBarManager;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 1212);
            // 
            // UiGridControlDevoluciones
            // 
            this.UiGridControlDevoluciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UiGridControlDevoluciones.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.UiGridControlDevoluciones.Location = new System.Drawing.Point(0, 46);
            this.UiGridControlDevoluciones.MainView = this.UiVistaDevoluciones;
            this.UiGridControlDevoluciones.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.UiGridControlDevoluciones.MenuManager = this.UiBarManager;
            this.UiGridControlDevoluciones.Name = "UiGridControlDevoluciones";
            this.UiGridControlDevoluciones.Size = new System.Drawing.Size(3218, 1212);
            this.UiGridControlDevoluciones.TabIndex = 4;
            this.UiGridControlDevoluciones.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.UiVistaDevoluciones});
            // 
            // UiVistaDevoluciones
            // 
            this.UiVistaDevoluciones.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colINVOICE_DOC_NUM,
            this.colCLIENT_CODE,
            this.colCLIENT_NAME,
            this.colPLATE_NUMBER,
            this.colTASK_ID,
            this.colENVIADO,
            this.colERP_REFERENCE_DOC_NUM,
            this.colMATERIAL_ID,
            this.colMATERIAL_NAME,
            this.colQTY,
            this.colRECEPTION_QTY});
            this.UiVistaDevoluciones.DetailHeight = 673;
            this.UiVistaDevoluciones.FixedLineWidth = 4;
            this.UiVistaDevoluciones.GridControl = this.UiGridControlDevoluciones;
            this.UiVistaDevoluciones.GroupCount = 1;
            this.UiVistaDevoluciones.Name = "UiVistaDevoluciones";
            this.UiVistaDevoluciones.OptionsView.ShowAutoFilterRow = true;
            this.UiVistaDevoluciones.OptionsView.ShowFooter = true;
            this.UiVistaDevoluciones.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colINVOICE_DOC_NUM, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colINVOICE_DOC_NUM
            // 
            this.colINVOICE_DOC_NUM.Caption = "Factura";
            this.colINVOICE_DOC_NUM.FieldName = "INVOICE_DOC_NUM";
            this.colINVOICE_DOC_NUM.MinWidth = 40;
            this.colINVOICE_DOC_NUM.Name = "colINVOICE_DOC_NUM";
            this.colINVOICE_DOC_NUM.OptionsColumn.AllowEdit = false;
            this.colINVOICE_DOC_NUM.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "INVOICE_DOC_NUM", "{0}")});
            this.colINVOICE_DOC_NUM.Visible = true;
            this.colINVOICE_DOC_NUM.VisibleIndex = 0;
            this.colINVOICE_DOC_NUM.Width = 150;
            // 
            // colCLIENT_CODE
            // 
            this.colCLIENT_CODE.Caption = "Código del Cliente";
            this.colCLIENT_CODE.FieldName = "CLIENT_CODE";
            this.colCLIENT_CODE.MinWidth = 40;
            this.colCLIENT_CODE.Name = "colCLIENT_CODE";
            this.colCLIENT_CODE.OptionsColumn.AllowEdit = false;
            this.colCLIENT_CODE.Visible = true;
            this.colCLIENT_CODE.VisibleIndex = 0;
            this.colCLIENT_CODE.Width = 150;
            // 
            // colCLIENT_NAME
            // 
            this.colCLIENT_NAME.Caption = "Nombre del Cliente";
            this.colCLIENT_NAME.FieldName = "CLIENT_NAME";
            this.colCLIENT_NAME.MinWidth = 40;
            this.colCLIENT_NAME.Name = "colCLIENT_NAME";
            this.colCLIENT_NAME.OptionsColumn.AllowEdit = false;
            this.colCLIENT_NAME.Visible = true;
            this.colCLIENT_NAME.VisibleIndex = 1;
            this.colCLIENT_NAME.Width = 150;
            // 
            // colPLATE_NUMBER
            // 
            this.colPLATE_NUMBER.Caption = "Vehículo";
            this.colPLATE_NUMBER.FieldName = "PLATE_NUMBER";
            this.colPLATE_NUMBER.MinWidth = 40;
            this.colPLATE_NUMBER.Name = "colPLATE_NUMBER";
            this.colPLATE_NUMBER.OptionsColumn.AllowEdit = false;
            this.colPLATE_NUMBER.Visible = true;
            this.colPLATE_NUMBER.VisibleIndex = 2;
            this.colPLATE_NUMBER.Width = 150;
            // 
            // colTASK_ID
            // 
            this.colTASK_ID.Caption = "Documento de Recepción";
            this.colTASK_ID.FieldName = "TASK_ID";
            this.colTASK_ID.MinWidth = 40;
            this.colTASK_ID.Name = "colTASK_ID";
            this.colTASK_ID.OptionsColumn.AllowEdit = false;
            this.colTASK_ID.Visible = true;
            this.colTASK_ID.VisibleIndex = 3;
            this.colTASK_ID.Width = 150;
            // 
            // colENVIADO
            // 
            this.colENVIADO.Caption = "Estado de Envío";
            this.colENVIADO.FieldName = "ENVIADO";
            this.colENVIADO.MinWidth = 40;
            this.colENVIADO.Name = "colENVIADO";
            this.colENVIADO.OptionsColumn.AllowEdit = false;
            this.colENVIADO.Visible = true;
            this.colENVIADO.VisibleIndex = 4;
            this.colENVIADO.Width = 150;
            // 
            // colERP_REFERENCE_DOC_NUM
            // 
            this.colERP_REFERENCE_DOC_NUM.Caption = "Nota de Crédito";
            this.colERP_REFERENCE_DOC_NUM.FieldName = "ERP_REFERENCE_DOC_NUM";
            this.colERP_REFERENCE_DOC_NUM.MinWidth = 40;
            this.colERP_REFERENCE_DOC_NUM.Name = "colERP_REFERENCE_DOC_NUM";
            this.colERP_REFERENCE_DOC_NUM.OptionsColumn.AllowEdit = false;
            this.colERP_REFERENCE_DOC_NUM.Visible = true;
            this.colERP_REFERENCE_DOC_NUM.VisibleIndex = 5;
            this.colERP_REFERENCE_DOC_NUM.Width = 150;
            // 
            // colMATERIAL_ID
            // 
            this.colMATERIAL_ID.Caption = "Código de Material";
            this.colMATERIAL_ID.FieldName = "MATERIAL_ID";
            this.colMATERIAL_ID.MinWidth = 40;
            this.colMATERIAL_ID.Name = "colMATERIAL_ID";
            this.colMATERIAL_ID.OptionsColumn.AllowEdit = false;
            this.colMATERIAL_ID.Visible = true;
            this.colMATERIAL_ID.VisibleIndex = 6;
            this.colMATERIAL_ID.Width = 150;
            // 
            // colMATERIAL_NAME
            // 
            this.colMATERIAL_NAME.Caption = "Descripción de Material";
            this.colMATERIAL_NAME.FieldName = "MATERIAL_NAME";
            this.colMATERIAL_NAME.MinWidth = 40;
            this.colMATERIAL_NAME.Name = "colMATERIAL_NAME";
            this.colMATERIAL_NAME.OptionsColumn.AllowEdit = false;
            this.colMATERIAL_NAME.Visible = true;
            this.colMATERIAL_NAME.VisibleIndex = 7;
            this.colMATERIAL_NAME.Width = 150;
            // 
            // colQTY
            // 
            this.colQTY.Caption = "Cantidad Recepcionada";
            this.colQTY.DisplayFormat.FormatString = "{0:###,###,##0.00}";
            this.colQTY.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colQTY.FieldName = "QTY";
            this.colQTY.MinWidth = 40;
            this.colQTY.Name = "colQTY";
            this.colQTY.OptionsColumn.AllowEdit = false;
            this.colQTY.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "QTY", "Total={0:#,###,##0.00}")});
            this.colQTY.Visible = true;
            this.colQTY.VisibleIndex = 8;
            this.colQTY.Width = 150;
            // 
            // colRECEPTION_QTY
            // 
            this.colRECEPTION_QTY.Caption = "Cantidad del Documento";
            this.colRECEPTION_QTY.DisplayFormat.FormatString = "{0:###,###,##0.00}";
            this.colRECEPTION_QTY.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colRECEPTION_QTY.FieldName = "RECEPTION_QTY";
            this.colRECEPTION_QTY.MinWidth = 40;
            this.colRECEPTION_QTY.Name = "colRECEPTION_QTY";
            this.colRECEPTION_QTY.OptionsColumn.AllowEdit = false;
            this.colRECEPTION_QTY.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "RECEPTION_QTY", "Total={0:#,###,##0.00}")});
            this.colRECEPTION_QTY.Visible = true;
            this.colRECEPTION_QTY.VisibleIndex = 9;
            this.colRECEPTION_QTY.Width = 150;
            // 
            // btnSaveLayout
            // 
            this.btnSaveLayout.Caption = "Grabar";
            this.btnSaveLayout.Id = 12;
            this.btnSaveLayout.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveLayout.ImageOptions.Image")));
            this.btnSaveLayout.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnSaveLayout.ImageOptions.LargeImage")));
            this.btnSaveLayout.Name = "btnSaveLayout";
            this.btnSaveLayout.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnSaveLayout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSaveLayout_ItemClick);
            // 
            // SaveLayout
            // 
            this.SaveLayout.Interval = 300;
            this.SaveLayout.Tick += new System.EventHandler(this.SaveLayout_Tick);
            // 
            // ReporteRecepcionPorDevolucionVista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(3218, 1258);
            this.Controls.Add(this.UiGridControlDevoluciones);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "ReporteRecepcionPorDevolucionVista";
            this.Text = "Reporte de Devoluciones";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReporteRecepcionPorDevolucionVista_FormClosing);
            this.Load += new System.EventHandler(this.ReporteRecepcionPorDevolucionVista_Load);
            ((System.ComponentModel.ISupportInitialize)(this.UiBarManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiRepositoryItemFechaInicial.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiRepositoryItemFechaInicial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiRepositoryItemFechaFinal.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiRepositoryItemFechaFinal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiRepositorySearchLookBodegas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiVistaBodegas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiGridControlDevoluciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiVistaDevoluciones)).EndInit();
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
        private DevExpress.XtraGrid.GridControl UiGridControlDevoluciones;
        private DevExpress.XtraGrid.Views.Grid.GridView UiVistaDevoluciones;
        private DevExpress.XtraBars.BarEditItem UiFechaInicial;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit UiRepositoryItemFechaInicial;
        private DevExpress.XtraBars.BarEditItem UiFechaFinal;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit UiRepositoryItemFechaFinal;
        private DevExpress.XtraBars.BarButtonItem UiBarButtonRefrescar;
        private DevExpress.XtraBars.BarButtonItem UiBarButtonExcel;
        private DevExpress.XtraBars.BarButtonItem UiBarButtonContraer;
        private DevExpress.XtraBars.BarButtonItem UiBarButtonExpandir;
        private DevExpress.XtraBars.BarButtonItem UiBarButtonConsolidado;
        private DevExpress.XtraBars.BarButtonItem UiBarButtonDetallado;
        private DevExpress.XtraBars.BarEditItem UiBarBodegas;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit UiRepositorySearchLookBodegas;
        private DevExpress.XtraGrid.Views.Grid.GridView UiVistaBodegas;
        private DevExpress.XtraGrid.Columns.GridColumn colWAREHOUSE_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colNAME;
        private DevExpress.XtraGrid.Columns.GridColumn colINVOICE_DOC_NUM;
        private DevExpress.XtraGrid.Columns.GridColumn colCLIENT_CODE;
        private DevExpress.XtraGrid.Columns.GridColumn colCLIENT_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn colPLATE_NUMBER;
        private DevExpress.XtraGrid.Columns.GridColumn colTASK_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colENVIADO;
        private DevExpress.XtraGrid.Columns.GridColumn colERP_REFERENCE_DOC_NUM;
        private DevExpress.XtraGrid.Columns.GridColumn colMATERIAL_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colMATERIAL_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn colQTY;
        private DevExpress.XtraGrid.Columns.GridColumn colRECEPTION_QTY;
        private System.Windows.Forms.SaveFileDialog UiDialogoGuardar;
        private DevExpress.XtraBars.BarButtonItem btnSaveLayout;
        private System.Windows.Forms.Timer SaveLayout;
    }
}