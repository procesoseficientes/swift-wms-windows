namespace MobilityScm.Modelo.Vistas
{
    partial class AdministradorDeLineaDePickingVista
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdministradorDeLineaDePickingVista));
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            this.UiBarManager = new DevExpress.XtraBars.BarManager(this.components);
            this.UiBarraPrincipal = new DevExpress.XtraBars.Bar();
            this.UiTextoNumeroDeCaja = new DevExpress.XtraBars.BarEditItem();
            this.UiControlTextoNumeroDeCaja = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.UiBotonGuardar = new DevExpress.XtraBars.BarButtonItem();
            this.UiBotonExportarExcel = new DevExpress.XtraBars.BarButtonItem();
            this.UiBotonContraer = new DevExpress.XtraBars.BarButtonItem();
            this.UiBotonExpandir = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.UiContenedorPrincipal = new DevExpress.XtraGrid.GridControl();
            this.UiVistaPrincipal = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colBOX_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMATERIAL_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMATERIAL_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLOGIN_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLOCATION_SPOT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGATE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWAVE_PICKING_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colERP_DOC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCLIENT_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCLIENT_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCLIENT_ROUTE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSTATUS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSTATUS_DESCRIPTION = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQUANTITY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSALE_ORDER = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBOX_NUMBER = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTOTAL_BOXES = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSOURCE_TYPE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWAS_IMPLODED = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UiCheckBoxImplosion = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colQUANTITY_ORIGINAL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColModified = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPICKING_LINE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UiDialogoParaGuardar = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.UiBarManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiControlTextoNumeroDeCaja)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiContenedorPrincipal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiVistaPrincipal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiCheckBoxImplosion)).BeginInit();
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
            this.UiTextoNumeroDeCaja,
            this.UiBotonGuardar,
            this.UiBotonExportarExcel,
            this.UiBotonContraer,
            this.UiBotonExpandir});
            this.UiBarManager.MainMenu = this.UiBarraPrincipal;
            this.UiBarManager.MaxItemId = 6;
            this.UiBarManager.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.UiControlTextoNumeroDeCaja});
            // 
            // UiBarraPrincipal
            // 
            this.UiBarraPrincipal.BarName = "Main menu";
            this.UiBarraPrincipal.DockCol = 0;
            this.UiBarraPrincipal.DockRow = 0;
            this.UiBarraPrincipal.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.UiBarraPrincipal.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Width, this.UiTextoNumeroDeCaja, "", false, true, true, 119),
            new DevExpress.XtraBars.LinkPersistInfo(this.UiBotonGuardar),
            new DevExpress.XtraBars.LinkPersistInfo(this.UiBotonExportarExcel),
            new DevExpress.XtraBars.LinkPersistInfo(this.UiBotonContraer),
            new DevExpress.XtraBars.LinkPersistInfo(this.UiBotonExpandir)});
            this.UiBarraPrincipal.OptionsBar.AllowQuickCustomization = false;
            this.UiBarraPrincipal.OptionsBar.DrawDragBorder = false;
            this.UiBarraPrincipal.OptionsBar.UseWholeRow = true;
            this.UiBarraPrincipal.Text = "Main menu";
            // 
            // UiTextoNumeroDeCaja
            // 
            this.UiTextoNumeroDeCaja.Caption = "Número de Caja";
            this.UiTextoNumeroDeCaja.Edit = this.UiControlTextoNumeroDeCaja;
            this.UiTextoNumeroDeCaja.Id = 1;
            this.UiTextoNumeroDeCaja.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("UiTextoNumeroDeCaja.ImageOptions.Image")));
            this.UiTextoNumeroDeCaja.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("UiTextoNumeroDeCaja.ImageOptions.LargeImage")));
            this.UiTextoNumeroDeCaja.Name = "UiTextoNumeroDeCaja";
            this.UiTextoNumeroDeCaja.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // UiControlTextoNumeroDeCaja
            // 
            this.UiControlTextoNumeroDeCaja.AutoHeight = false;
            this.UiControlTextoNumeroDeCaja.Name = "UiControlTextoNumeroDeCaja";
            this.UiControlTextoNumeroDeCaja.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UiControlTextoNumeroDeCaja_KeyDown);
            // 
            // UiBotonGuardar
            // 
            this.UiBotonGuardar.Caption = "Guardar";
            this.UiBotonGuardar.Id = 2;
            this.UiBotonGuardar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("UiBotonGuardar.ImageOptions.Image")));
            this.UiBotonGuardar.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("UiBotonGuardar.ImageOptions.LargeImage")));
            this.UiBotonGuardar.Name = "UiBotonGuardar";
            this.UiBotonGuardar.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.UiBotonGuardar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.UiBotonGuardar_ItemClick);
            // 
            // UiBotonExportarExcel
            // 
            this.UiBotonExportarExcel.Caption = "Exportar a Excel";
            this.UiBotonExportarExcel.Id = 3;
            this.UiBotonExportarExcel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("UiBotonExportarExcel.ImageOptions.Image")));
            this.UiBotonExportarExcel.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("UiBotonExportarExcel.ImageOptions.LargeImage")));
            this.UiBotonExportarExcel.Name = "UiBotonExportarExcel";
            this.UiBotonExportarExcel.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.UiBotonExportarExcel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.UiBotonExportarExcel_ItemClick);
            // 
            // UiBotonContraer
            // 
            this.UiBotonContraer.Caption = "Contraer";
            this.UiBotonContraer.Id = 4;
            this.UiBotonContraer.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("UiBotonContraer.ImageOptions.Image")));
            this.UiBotonContraer.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("UiBotonContraer.ImageOptions.LargeImage")));
            this.UiBotonContraer.Name = "UiBotonContraer";
            this.UiBotonContraer.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.UiBotonContraer.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.UiBotonContraer_ItemClick);
            // 
            // UiBotonExpandir
            // 
            this.UiBotonExpandir.Caption = "Expandir";
            this.UiBotonExpandir.Id = 5;
            this.UiBotonExpandir.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("UiBotonExpandir.ImageOptions.Image")));
            this.UiBotonExpandir.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("UiBotonExpandir.ImageOptions.LargeImage")));
            this.UiBotonExpandir.Name = "UiBotonExpandir";
            this.UiBotonExpandir.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.UiBotonExpandir.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.UiBotonExpandir_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.UiBarManager;
            this.barDockControlTop.Size = new System.Drawing.Size(1370, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 661);
            this.barDockControlBottom.Manager = this.UiBarManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(1370, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.UiBarManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 637);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1370, 24);
            this.barDockControlRight.Manager = this.UiBarManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 637);
            // 
            // UiContenedorPrincipal
            // 
            this.UiContenedorPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UiContenedorPrincipal.Location = new System.Drawing.Point(0, 24);
            this.UiContenedorPrincipal.MainView = this.UiVistaPrincipal;
            this.UiContenedorPrincipal.MenuManager = this.UiBarManager;
            this.UiContenedorPrincipal.Name = "UiContenedorPrincipal";
            this.UiContenedorPrincipal.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.UiCheckBoxImplosion});
            this.UiContenedorPrincipal.Size = new System.Drawing.Size(1370, 637);
            this.UiContenedorPrincipal.TabIndex = 4;
            this.UiContenedorPrincipal.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.UiVistaPrincipal});
            // 
            // UiVistaPrincipal
            // 
            this.UiVistaPrincipal.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colBOX_ID,
            this.colMATERIAL_ID,
            this.colMATERIAL_NAME,
            this.colLOGIN_ID,
            this.colLOCATION_SPOT,
            this.colGATE,
            this.colWAVE_PICKING_ID,
            this.colERP_DOC,
            this.colCLIENT_ID,
            this.colCLIENT_NAME,
            this.colCLIENT_ROUTE,
            this.colSTATUS,
            this.colSTATUS_DESCRIPTION,
            this.colQUANTITY,
            this.colSALE_ORDER,
            this.colBOX_NUMBER,
            this.colTOTAL_BOXES,
            this.colSOURCE_TYPE,
            this.colWAS_IMPLODED,
            this.colQUANTITY_ORIGINAL,
            this.ColModified,
            this.colPICKING_LINE});
            gridFormatRule1.Name = "Format0";
            gridFormatRule1.Rule = null;
            this.UiVistaPrincipal.FormatRules.Add(gridFormatRule1);
            this.UiVistaPrincipal.GridControl = this.UiContenedorPrincipal;
            this.UiVistaPrincipal.Name = "UiVistaPrincipal";
            this.UiVistaPrincipal.OptionsView.ShowAutoFilterRow = true;
            this.UiVistaPrincipal.OptionsView.ShowFooter = true;
            this.UiVistaPrincipal.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.UiVistaPrincipal_ShowingEditor);
            this.UiVistaPrincipal.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.UiVistaPrincipal_ValidatingEditor);
            // 
            // colBOX_ID
            // 
            this.colBOX_ID.Caption = "Número de Caja";
            this.colBOX_ID.FieldName = "BOX_ID";
            this.colBOX_ID.Name = "colBOX_ID";
            this.colBOX_ID.OptionsColumn.AllowEdit = false;
            this.colBOX_ID.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colMATERIAL_ID
            // 
            this.colMATERIAL_ID.Caption = "Código de Material";
            this.colMATERIAL_ID.FieldName = "MATERIAL_ID";
            this.colMATERIAL_ID.Name = "colMATERIAL_ID";
            this.colMATERIAL_ID.OptionsColumn.AllowEdit = false;
            this.colMATERIAL_ID.Visible = true;
            this.colMATERIAL_ID.VisibleIndex = 0;
            // 
            // colMATERIAL_NAME
            // 
            this.colMATERIAL_NAME.Caption = "Descripción de Material";
            this.colMATERIAL_NAME.FieldName = "MATERIAL_NAME";
            this.colMATERIAL_NAME.Name = "colMATERIAL_NAME";
            this.colMATERIAL_NAME.OptionsColumn.AllowEdit = false;
            this.colMATERIAL_NAME.Visible = true;
            this.colMATERIAL_NAME.VisibleIndex = 1;
            // 
            // colLOGIN_ID
            // 
            this.colLOGIN_ID.Caption = "Operador";
            this.colLOGIN_ID.FieldName = "LOGIN_ID";
            this.colLOGIN_ID.Name = "colLOGIN_ID";
            this.colLOGIN_ID.OptionsColumn.AllowEdit = false;
            this.colLOGIN_ID.Visible = true;
            this.colLOGIN_ID.VisibleIndex = 2;
            // 
            // colLOCATION_SPOT
            // 
            this.colLOCATION_SPOT.Caption = "Ubicación Picking";
            this.colLOCATION_SPOT.FieldName = "LOCATION_SPOT";
            this.colLOCATION_SPOT.Name = "colLOCATION_SPOT";
            this.colLOCATION_SPOT.OptionsColumn.AllowEdit = false;
            this.colLOCATION_SPOT.Visible = true;
            this.colLOCATION_SPOT.VisibleIndex = 3;
            // 
            // colGATE
            // 
            this.colGATE.Caption = "Ubicación Destino";
            this.colGATE.FieldName = "GATE";
            this.colGATE.Name = "colGATE";
            this.colGATE.OptionsColumn.AllowEdit = false;
            this.colGATE.Visible = true;
            this.colGATE.VisibleIndex = 4;
            // 
            // colWAVE_PICKING_ID
            // 
            this.colWAVE_PICKING_ID.Caption = "Ola de Picking";
            this.colWAVE_PICKING_ID.FieldName = "WAVE_PICKING_ID";
            this.colWAVE_PICKING_ID.Name = "colWAVE_PICKING_ID";
            this.colWAVE_PICKING_ID.OptionsColumn.AllowEdit = false;
            this.colWAVE_PICKING_ID.Visible = true;
            this.colWAVE_PICKING_ID.VisibleIndex = 5;
            // 
            // colERP_DOC
            // 
            this.colERP_DOC.Caption = "Documento de la Línea de Picking";
            this.colERP_DOC.FieldName = "ERP_DOC";
            this.colERP_DOC.Name = "colERP_DOC";
            this.colERP_DOC.OptionsColumn.AllowEdit = false;
            this.colERP_DOC.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colCLIENT_ID
            // 
            this.colCLIENT_ID.Caption = "Código de Cliente";
            this.colCLIENT_ID.FieldName = "CLIENT_ID";
            this.colCLIENT_ID.Name = "colCLIENT_ID";
            this.colCLIENT_ID.OptionsColumn.AllowEdit = false;
            // 
            // colCLIENT_NAME
            // 
            this.colCLIENT_NAME.Caption = "Cliente del Pedido";
            this.colCLIENT_NAME.FieldName = "CLIENT_NAME";
            this.colCLIENT_NAME.Name = "colCLIENT_NAME";
            this.colCLIENT_NAME.OptionsColumn.AllowEdit = false;
            this.colCLIENT_NAME.Visible = true;
            this.colCLIENT_NAME.VisibleIndex = 6;
            // 
            // colCLIENT_ROUTE
            // 
            this.colCLIENT_ROUTE.Caption = "Ruta";
            this.colCLIENT_ROUTE.FieldName = "CLIENT_ROUTE";
            this.colCLIENT_ROUTE.Name = "colCLIENT_ROUTE";
            this.colCLIENT_ROUTE.OptionsColumn.AllowEdit = false;
            this.colCLIENT_ROUTE.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            // 
            // colSTATUS
            // 
            this.colSTATUS.Caption = "Estado";
            this.colSTATUS.FieldName = "STATUS";
            this.colSTATUS.Name = "colSTATUS";
            this.colSTATUS.OptionsColumn.AllowEdit = false;
            this.colSTATUS.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colSTATUS_DESCRIPTION
            // 
            this.colSTATUS_DESCRIPTION.Caption = "Estado";
            this.colSTATUS_DESCRIPTION.FieldName = "STATUS_DESCRIPTION";
            this.colSTATUS_DESCRIPTION.Name = "colSTATUS_DESCRIPTION";
            this.colSTATUS_DESCRIPTION.OptionsColumn.AllowEdit = false;
            this.colSTATUS_DESCRIPTION.Visible = true;
            this.colSTATUS_DESCRIPTION.VisibleIndex = 8;
            // 
            // colQUANTITY
            // 
            this.colQUANTITY.Caption = "Cantidad";
            this.colQUANTITY.FieldName = "QUANTITY";
            this.colQUANTITY.Name = "colQUANTITY";
            this.colQUANTITY.Visible = true;
            this.colQUANTITY.VisibleIndex = 7;
            // 
            // colSALE_ORDER
            // 
            this.colSALE_ORDER.Caption = "Número de Pedido";
            this.colSALE_ORDER.FieldName = "SALE_ORDER";
            this.colSALE_ORDER.Name = "colSALE_ORDER";
            this.colSALE_ORDER.OptionsColumn.AllowEdit = false;
            // 
            // colBOX_NUMBER
            // 
            this.colBOX_NUMBER.Caption = "Número de Caja";
            this.colBOX_NUMBER.FieldName = "BOX_NUMBER";
            this.colBOX_NUMBER.Name = "colBOX_NUMBER";
            this.colBOX_NUMBER.OptionsColumn.AllowEdit = false;
            // 
            // colTOTAL_BOXES
            // 
            this.colTOTAL_BOXES.Caption = "Total de Cajas";
            this.colTOTAL_BOXES.FieldName = "TOTAL_BOXES";
            this.colTOTAL_BOXES.Name = "colTOTAL_BOXES";
            this.colTOTAL_BOXES.OptionsColumn.AllowEdit = false;
            // 
            // colSOURCE_TYPE
            // 
            this.colSOURCE_TYPE.Caption = "Fuente";
            this.colSOURCE_TYPE.FieldName = "SOURCE_TYPE";
            this.colSOURCE_TYPE.Name = "colSOURCE_TYPE";
            this.colSOURCE_TYPE.OptionsColumn.AllowEdit = false;
            // 
            // colWAS_IMPLODED
            // 
            this.colWAS_IMPLODED.Caption = "Implosión";
            this.colWAS_IMPLODED.ColumnEdit = this.UiCheckBoxImplosion;
            this.colWAS_IMPLODED.FieldName = "WAS_IMPLODED";
            this.colWAS_IMPLODED.Name = "colWAS_IMPLODED";
            this.colWAS_IMPLODED.OptionsColumn.AllowEdit = false;
            // 
            // UiCheckBoxImplosion
            // 
            this.UiCheckBoxImplosion.AutoHeight = false;
            this.UiCheckBoxImplosion.Name = "UiCheckBoxImplosion";
            this.UiCheckBoxImplosion.ValueChecked = 1;
            this.UiCheckBoxImplosion.ValueUnchecked = 0;
            // 
            // colQUANTITY_ORIGINAL
            // 
            this.colQUANTITY_ORIGINAL.Caption = "Cantidad Original";
            this.colQUANTITY_ORIGINAL.FieldName = "QUANTITY_ORIGINAL";
            this.colQUANTITY_ORIGINAL.Name = "colQUANTITY_ORIGINAL";
            this.colQUANTITY_ORIGINAL.OptionsColumn.AllowEdit = false;
            this.colQUANTITY_ORIGINAL.Visible = true;
            this.colQUANTITY_ORIGINAL.VisibleIndex = 9;
            // 
            // ColModified
            // 
            this.ColModified.Caption = "Modificado";
            this.ColModified.FieldName = "MODIFIED";
            this.ColModified.Name = "ColModified";
            this.ColModified.OptionsColumn.AllowEdit = false;
            this.ColModified.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colPICKING_LINE
            // 
            this.colPICKING_LINE.Caption = "Línea de Picking";
            this.colPICKING_LINE.FieldName = "PICKING_LINE";
            this.colPICKING_LINE.Name = "colPICKING_LINE";
            this.colPICKING_LINE.OptionsColumn.AllowEdit = false;
            // 
            // AdministradorDeLineaDePickingVista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 661);
            this.Controls.Add(this.UiContenedorPrincipal);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "AdministradorDeLineaDePickingVista";
            this.Text = "Administrador de Linea de Picking";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AdministradorDeLineaDePickingVista_FormClosing);
            this.Load += new System.EventHandler(this.AdministradorDeLineaDePickingVista_Load);
            ((System.ComponentModel.ISupportInitialize)(this.UiBarManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiControlTextoNumeroDeCaja)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiContenedorPrincipal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiVistaPrincipal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiCheckBoxImplosion)).EndInit();
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
        private DevExpress.XtraBars.BarEditItem UiTextoNumeroDeCaja;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit UiControlTextoNumeroDeCaja;
        private DevExpress.XtraBars.BarButtonItem UiBotonGuardar;
        private DevExpress.XtraBars.BarButtonItem UiBotonExportarExcel;
        private DevExpress.XtraBars.BarButtonItem UiBotonContraer;
        private DevExpress.XtraBars.BarButtonItem UiBotonExpandir;
        private DevExpress.XtraGrid.GridControl UiContenedorPrincipal;
        private DevExpress.XtraGrid.Views.Grid.GridView UiVistaPrincipal;
        private System.Windows.Forms.SaveFileDialog UiDialogoParaGuardar;
        private DevExpress.XtraGrid.Columns.GridColumn colBOX_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colMATERIAL_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colMATERIAL_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn colLOGIN_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colLOCATION_SPOT;
        private DevExpress.XtraGrid.Columns.GridColumn colGATE;
        private DevExpress.XtraGrid.Columns.GridColumn colWAVE_PICKING_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colERP_DOC;
        private DevExpress.XtraGrid.Columns.GridColumn colCLIENT_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colCLIENT_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn colCLIENT_ROUTE;
        private DevExpress.XtraGrid.Columns.GridColumn colSTATUS;
        private DevExpress.XtraGrid.Columns.GridColumn colSTATUS_DESCRIPTION;
        private DevExpress.XtraGrid.Columns.GridColumn colQUANTITY;
        private DevExpress.XtraGrid.Columns.GridColumn colSALE_ORDER;
        private DevExpress.XtraGrid.Columns.GridColumn colBOX_NUMBER;
        private DevExpress.XtraGrid.Columns.GridColumn colTOTAL_BOXES;
        private DevExpress.XtraGrid.Columns.GridColumn colSOURCE_TYPE;
        private DevExpress.XtraGrid.Columns.GridColumn colWAS_IMPLODED;
        private DevExpress.XtraGrid.Columns.GridColumn colQUANTITY_ORIGINAL;
        private DevExpress.XtraGrid.Columns.GridColumn ColModified;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit UiCheckBoxImplosion;
        private DevExpress.XtraGrid.Columns.GridColumn colPICKING_LINE;
    }
}