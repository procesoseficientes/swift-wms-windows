namespace MobilityScm.Modelo.Vistas
{
    partial class ConsultaCosteoVista
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConsultaCosteoVista));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.barManager1 = new DevExpress.XtraBars.BarManager();
            this.UiBarraPrincipalOpciones = new DevExpress.XtraBars.Bar();
            this.UiBotonAutorizar = new DevExpress.XtraBars.BarButtonItem();
            this.UiBotonRefrescar = new DevExpress.XtraBars.BarButtonItem();
            this.UiBotonExpandir = new DevExpress.XtraBars.BarButtonItem();
            this.UiBotonContraer = new DevExpress.XtraBars.BarButtonItem();
            this.UiBotonExportarExcel = new DevExpress.XtraBars.BarButtonItem();
            this.UiBotonReporteConsolidado = new DevExpress.XtraBars.BarButtonItem();
            this.UiBotonReportePorDocumento = new DevExpress.XtraBars.BarButtonItem();
            this.UiFechaInicial = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.UiFechaFinal = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemDateEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.UiSwitchLineasAbiertas = new DevExpress.XtraBars.BarToggleSwitchItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.UiContenedorCosteos = new DevExpress.XtraGrid.GridControl();
            this.UiVistaCosteos = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDOC_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCODIGO_POLIZA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNUMERO_ORDER = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCLIENT_CODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFECHA_DOCUMENTO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFECHA_LLEGADA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPOLIZA_ASEGURADA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colACUERDO_COMERCIAL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTRANS_TYPE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLINE_NUMBER = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSKU_DESCRIPTION = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQTY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCUSTOMS_AMOUNT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLAST_UPDATE_BY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLAST_UPDATED = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMATEDIAL_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSTATUS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUNITARY_PRICE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UiListaBodega = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.UiListaVistaBodega = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colWAREHOUSE_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UiLabelBodega = new DevExpress.XtraEditors.LabelControl();
            this.colCLIENT_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiContenedorCosteos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiVistaCosteos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiListaBodega.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiListaVistaBodega)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.UiBarraPrincipalOpciones});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.UiBotonRefrescar,
            this.UiBotonExpandir,
            this.UiBotonContraer,
            this.UiBotonExportarExcel,
            this.UiBotonReporteConsolidado,
            this.UiBotonReportePorDocumento,
            this.UiBotonAutorizar,
            this.UiFechaInicial,
            this.UiFechaFinal,
            this.UiSwitchLineasAbiertas});
            this.barManager1.MaxItemId = 12;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemDateEdit1,
            this.repositoryItemDateEdit2});
            // 
            // UiBarraPrincipalOpciones
            // 
            this.UiBarraPrincipalOpciones.BarName = "Tools";
            this.UiBarraPrincipalOpciones.DockCol = 0;
            this.UiBarraPrincipalOpciones.DockRow = 0;
            this.UiBarraPrincipalOpciones.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.UiBarraPrincipalOpciones.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.UiBotonAutorizar, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.UiBotonRefrescar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.UiBotonExpandir, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.UiBotonContraer, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.UiBotonExportarExcel, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.UiBotonReporteConsolidado, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.UiBotonReportePorDocumento, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.UiFechaInicial, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.UiFechaFinal, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.UiSwitchLineasAbiertas, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.UiBarraPrincipalOpciones.Offset = 4;
            this.UiBarraPrincipalOpciones.Text = "Tools";
            // 
            // UiBotonAutorizar
            // 
            this.UiBotonAutorizar.Caption = "Autorizar";
            this.UiBotonAutorizar.Glyph = ((System.Drawing.Image)(resources.GetObject("UiBotonAutorizar.Glyph")));
            this.UiBotonAutorizar.Id = 6;
            this.UiBotonAutorizar.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("UiBotonAutorizar.LargeGlyph")));
            this.UiBotonAutorizar.Name = "UiBotonAutorizar";
            this.UiBotonAutorizar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.UiBotonAutorizar_ItemClick);
            // 
            // UiBotonRefrescar
            // 
            this.UiBotonRefrescar.Caption = "Refrescar";
            this.UiBotonRefrescar.Glyph = ((System.Drawing.Image)(resources.GetObject("UiBotonRefrescar.Glyph")));
            this.UiBotonRefrescar.Id = 0;
            this.UiBotonRefrescar.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("UiBotonRefrescar.LargeGlyph")));
            this.UiBotonRefrescar.Name = "UiBotonRefrescar";
            this.UiBotonRefrescar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.UiBotonRefrescar_ItemClick);
            // 
            // UiBotonExpandir
            // 
            this.UiBotonExpandir.Caption = "Expandir";
            this.UiBotonExpandir.Glyph = ((System.Drawing.Image)(resources.GetObject("UiBotonExpandir.Glyph")));
            this.UiBotonExpandir.Id = 1;
            this.UiBotonExpandir.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("UiBotonExpandir.LargeGlyph")));
            this.UiBotonExpandir.Name = "UiBotonExpandir";
            this.UiBotonExpandir.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.UiBotonExpandir_ItemClick);
            // 
            // UiBotonContraer
            // 
            this.UiBotonContraer.Caption = "Contraer";
            this.UiBotonContraer.Glyph = ((System.Drawing.Image)(resources.GetObject("UiBotonContraer.Glyph")));
            this.UiBotonContraer.Id = 2;
            this.UiBotonContraer.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("UiBotonContraer.LargeGlyph")));
            this.UiBotonContraer.Name = "UiBotonContraer";
            this.UiBotonContraer.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.UiBotonContraer_ItemClick);
            // 
            // UiBotonExportarExcel
            // 
            this.UiBotonExportarExcel.Caption = "Exportar Excel";
            this.UiBotonExportarExcel.Glyph = ((System.Drawing.Image)(resources.GetObject("UiBotonExportarExcel.Glyph")));
            this.UiBotonExportarExcel.Id = 3;
            this.UiBotonExportarExcel.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("UiBotonExportarExcel.LargeGlyph")));
            this.UiBotonExportarExcel.Name = "UiBotonExportarExcel";
            this.UiBotonExportarExcel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.UiBotonExportarExcel_ItemClick);
            // 
            // UiBotonReporteConsolidado
            // 
            this.UiBotonReporteConsolidado.Caption = "Reporte Consolidado";
            this.UiBotonReporteConsolidado.Glyph = ((System.Drawing.Image)(resources.GetObject("UiBotonReporteConsolidado.Glyph")));
            this.UiBotonReporteConsolidado.Id = 4;
            this.UiBotonReporteConsolidado.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("UiBotonReporteConsolidado.LargeGlyph")));
            this.UiBotonReporteConsolidado.Name = "UiBotonReporteConsolidado";
            this.UiBotonReporteConsolidado.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.UiBotonReporteConsolidado_ItemClick);
            // 
            // UiBotonReportePorDocumento
            // 
            this.UiBotonReportePorDocumento.Caption = "Reporte Por Documento";
            this.UiBotonReportePorDocumento.Glyph = ((System.Drawing.Image)(resources.GetObject("UiBotonReportePorDocumento.Glyph")));
            this.UiBotonReportePorDocumento.Id = 5;
            this.UiBotonReportePorDocumento.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("UiBotonReportePorDocumento.LargeGlyph")));
            this.UiBotonReportePorDocumento.Name = "UiBotonReportePorDocumento";
            this.UiBotonReportePorDocumento.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.UiBotonReportePorDocumento_ItemClick);
            // 
            // UiFechaInicial
            // 
            this.UiFechaInicial.Caption = "Fecha Inicial";
            this.UiFechaInicial.Edit = this.repositoryItemDateEdit1;
            this.UiFechaInicial.Glyph = ((System.Drawing.Image)(resources.GetObject("UiFechaInicial.Glyph")));
            this.UiFechaInicial.Id = 7;
            this.UiFechaInicial.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("UiFechaInicial.LargeGlyph")));
            this.UiFechaInicial.Name = "UiFechaInicial";
            this.UiFechaInicial.Size = new System.Drawing.Size(180, 0);
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
            this.UiFechaFinal.Id = 9;
            this.UiFechaFinal.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("UiFechaFinal.LargeGlyph")));
            this.UiFechaFinal.Name = "UiFechaFinal";
            this.UiFechaFinal.Size = new System.Drawing.Size(180, 0);
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
            // UiSwitchLineasAbiertas
            // 
            this.UiSwitchLineasAbiertas.Caption = "Lineas Abiertas";
            this.UiSwitchLineasAbiertas.Glyph = ((System.Drawing.Image)(resources.GetObject("UiSwitchLineasAbiertas.Glyph")));
            this.UiSwitchLineasAbiertas.Id = 11;
            this.UiSwitchLineasAbiertas.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("UiSwitchLineasAbiertas.LargeGlyph")));
            this.UiSwitchLineasAbiertas.Name = "UiSwitchLineasAbiertas";
            this.UiSwitchLineasAbiertas.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.UiSwitchLineasAbiertas_CheckedChanged);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1424, 33);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 690);
            this.barDockControlBottom.Size = new System.Drawing.Size(1424, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 33);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 657);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1424, 33);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 657);
            // 
            // UiContenedorCosteos
            // 
            this.UiContenedorCosteos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UiContenedorCosteos.Location = new System.Drawing.Point(13, 65);
            this.UiContenedorCosteos.MainView = this.UiVistaCosteos;
            this.UiContenedorCosteos.MenuManager = this.barManager1;
            this.UiContenedorCosteos.Name = "UiContenedorCosteos";
            this.UiContenedorCosteos.Size = new System.Drawing.Size(1399, 613);
            this.UiContenedorCosteos.TabIndex = 4;
            this.UiContenedorCosteos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.UiVistaCosteos});
            // 
            // UiVistaCosteos
            // 
            this.UiVistaCosteos.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDOC_ID,
            this.colCODIGO_POLIZA,
            this.colNUMERO_ORDER,
            this.colCLIENT_CODE,
            this.colFECHA_DOCUMENTO,
            this.colFECHA_LLEGADA,
            this.colPOLIZA_ASEGURADA,
            this.colACUERDO_COMERCIAL,
            this.colTRANS_TYPE,
            this.colLINE_NUMBER,
            this.colSKU_DESCRIPTION,
            this.colQTY,
            this.colCUSTOMS_AMOUNT,
            this.colLAST_UPDATE_BY,
            this.colLAST_UPDATED,
            this.colMATEDIAL_ID,
            this.colSTATUS,
            this.colUNITARY_PRICE,
            this.colCLIENT_NAME});
            this.UiVistaCosteos.GridControl = this.UiContenedorCosteos;
            this.UiVistaCosteos.Name = "UiVistaCosteos";
            this.UiVistaCosteos.OptionsSelection.MultiSelect = true;
            this.UiVistaCosteos.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.UiVistaCosteos.OptionsView.ShowAutoFilterRow = true;
            this.UiVistaCosteos.OptionsView.ShowFooter = true;
            this.UiVistaCosteos.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.UiVistaCosteos_SelectionChanged);
            this.UiVistaCosteos.BeforeLeaveRow += new DevExpress.XtraGrid.Views.Base.RowAllowEventHandler(this.UiVistaCosteos_BeforeLeaveRow);
            this.UiVistaCosteos.ColumnFilterChanged += new System.EventHandler(this.UiVistaCosteos_ColumnFilterChanged);
            this.UiVistaCosteos.MouseUp += new System.Windows.Forms.MouseEventHandler(this.UiVistaCosteos_MouseUp);
            // 
            // colDOC_ID
            // 
            this.colDOC_ID.Caption = "# Doc.";
            this.colDOC_ID.FieldName = "DOC_ID";
            this.colDOC_ID.Name = "colDOC_ID";
            this.colDOC_ID.OptionsColumn.AllowEdit = false;
            this.colDOC_ID.Visible = true;
            this.colDOC_ID.VisibleIndex = 1;
            // 
            // colCODIGO_POLIZA
            // 
            this.colCODIGO_POLIZA.Caption = "Cod. Poliza";
            this.colCODIGO_POLIZA.FieldName = "CODIGO_POLIZA";
            this.colCODIGO_POLIZA.Name = "colCODIGO_POLIZA";
            this.colCODIGO_POLIZA.OptionsColumn.AllowEdit = false;
            this.colCODIGO_POLIZA.Visible = true;
            this.colCODIGO_POLIZA.VisibleIndex = 2;
            // 
            // colNUMERO_ORDER
            // 
            this.colNUMERO_ORDER.Caption = "Num. Orden";
            this.colNUMERO_ORDER.FieldName = "NUMERO_ORDEN";
            this.colNUMERO_ORDER.Name = "colNUMERO_ORDER";
            this.colNUMERO_ORDER.OptionsColumn.AllowEdit = false;
            this.colNUMERO_ORDER.Visible = true;
            this.colNUMERO_ORDER.VisibleIndex = 3;
            // 
            // colCLIENT_CODE
            // 
            this.colCLIENT_CODE.Caption = "Cod. Cliente";
            this.colCLIENT_CODE.FieldName = "CLIENT_CODE";
            this.colCLIENT_CODE.Name = "colCLIENT_CODE";
            this.colCLIENT_CODE.OptionsColumn.AllowEdit = false;
            this.colCLIENT_CODE.Visible = true;
            this.colCLIENT_CODE.VisibleIndex = 4;
            // 
            // colFECHA_DOCUMENTO
            // 
            this.colFECHA_DOCUMENTO.Caption = "Fecha Doc.";
            this.colFECHA_DOCUMENTO.FieldName = "FECHA_DOCUMENTO";
            this.colFECHA_DOCUMENTO.Name = "colFECHA_DOCUMENTO";
            this.colFECHA_DOCUMENTO.OptionsColumn.AllowEdit = false;
            this.colFECHA_DOCUMENTO.Visible = true;
            this.colFECHA_DOCUMENTO.VisibleIndex = 5;
            // 
            // colFECHA_LLEGADA
            // 
            this.colFECHA_LLEGADA.Caption = "Fecha Llegada";
            this.colFECHA_LLEGADA.FieldName = "FECHA_LLEGADA";
            this.colFECHA_LLEGADA.Name = "colFECHA_LLEGADA";
            this.colFECHA_LLEGADA.OptionsColumn.AllowEdit = false;
            this.colFECHA_LLEGADA.Visible = true;
            this.colFECHA_LLEGADA.VisibleIndex = 6;
            // 
            // colPOLIZA_ASEGURADA
            // 
            this.colPOLIZA_ASEGURADA.Caption = "Poliza Asegurada";
            this.colPOLIZA_ASEGURADA.FieldName = "POLIZA_ASEGURADA";
            this.colPOLIZA_ASEGURADA.Name = "colPOLIZA_ASEGURADA";
            this.colPOLIZA_ASEGURADA.OptionsColumn.AllowEdit = false;
            this.colPOLIZA_ASEGURADA.Visible = true;
            this.colPOLIZA_ASEGURADA.VisibleIndex = 7;
            // 
            // colACUERDO_COMERCIAL
            // 
            this.colACUERDO_COMERCIAL.Caption = "Acuerdo Comercial";
            this.colACUERDO_COMERCIAL.FieldName = "ACUERDO_COMERCIAL";
            this.colACUERDO_COMERCIAL.Name = "colACUERDO_COMERCIAL";
            this.colACUERDO_COMERCIAL.OptionsColumn.AllowEdit = false;
            this.colACUERDO_COMERCIAL.Visible = true;
            this.colACUERDO_COMERCIAL.VisibleIndex = 8;
            // 
            // colTRANS_TYPE
            // 
            this.colTRANS_TYPE.Caption = "Tipo Transaccion";
            this.colTRANS_TYPE.FieldName = "TRANS_TYPE";
            this.colTRANS_TYPE.Name = "colTRANS_TYPE";
            this.colTRANS_TYPE.OptionsColumn.AllowEdit = false;
            this.colTRANS_TYPE.Visible = true;
            this.colTRANS_TYPE.VisibleIndex = 9;
            // 
            // colLINE_NUMBER
            // 
            this.colLINE_NUMBER.Caption = "Linea no.";
            this.colLINE_NUMBER.FieldName = "LINE_NUMBER";
            this.colLINE_NUMBER.Name = "colLINE_NUMBER";
            this.colLINE_NUMBER.OptionsColumn.AllowEdit = false;
            // 
            // colSKU_DESCRIPTION
            // 
            this.colSKU_DESCRIPTION.Caption = "SKU";
            this.colSKU_DESCRIPTION.FieldName = "SKU_DESCRIPTION";
            this.colSKU_DESCRIPTION.Name = "colSKU_DESCRIPTION";
            this.colSKU_DESCRIPTION.OptionsColumn.AllowEdit = false;
            this.colSKU_DESCRIPTION.Visible = true;
            this.colSKU_DESCRIPTION.VisibleIndex = 10;
            // 
            // colQTY
            // 
            this.colQTY.Caption = "Cantidad";
            this.colQTY.FieldName = "QTY";
            this.colQTY.Name = "colQTY";
            this.colQTY.OptionsColumn.AllowEdit = false;
            this.colQTY.Visible = true;
            this.colQTY.VisibleIndex = 11;
            // 
            // colCUSTOMS_AMOUNT
            // 
            this.colCUSTOMS_AMOUNT.Caption = "Total";
            this.colCUSTOMS_AMOUNT.FieldName = "CUSTOMS_AMOUNT";
            this.colCUSTOMS_AMOUNT.Name = "colCUSTOMS_AMOUNT";
            this.colCUSTOMS_AMOUNT.OptionsColumn.AllowEdit = false;
            this.colCUSTOMS_AMOUNT.Visible = true;
            this.colCUSTOMS_AMOUNT.VisibleIndex = 12;
            // 
            // colLAST_UPDATE_BY
            // 
            this.colLAST_UPDATE_BY.Caption = "Ult. Actualizar";
            this.colLAST_UPDATE_BY.FieldName = "LAST_UPDATED_BY";
            this.colLAST_UPDATE_BY.Name = "colLAST_UPDATE_BY";
            this.colLAST_UPDATE_BY.OptionsColumn.AllowEdit = false;
            this.colLAST_UPDATE_BY.Visible = true;
            this.colLAST_UPDATE_BY.VisibleIndex = 13;
            // 
            // colLAST_UPDATED
            // 
            this.colLAST_UPDATED.Caption = "Ult. Actualizacion";
            this.colLAST_UPDATED.FieldName = "LAST_UPDATED";
            this.colLAST_UPDATED.Name = "colLAST_UPDATED";
            this.colLAST_UPDATED.OptionsColumn.AllowEdit = false;
            this.colLAST_UPDATED.Visible = true;
            this.colLAST_UPDATED.VisibleIndex = 14;
            // 
            // colMATEDIAL_ID
            // 
            this.colMATEDIAL_ID.Caption = "Cod. SKU";
            this.colMATEDIAL_ID.FieldName = "MATERIAL_ID";
            this.colMATEDIAL_ID.Name = "colMATEDIAL_ID";
            this.colMATEDIAL_ID.OptionsColumn.AllowEdit = false;
            this.colMATEDIAL_ID.Visible = true;
            this.colMATEDIAL_ID.VisibleIndex = 15;
            // 
            // colSTATUS
            // 
            this.colSTATUS.Caption = "Estado";
            this.colSTATUS.FieldName = "STATUS";
            this.colSTATUS.Name = "colSTATUS";
            this.colSTATUS.OptionsColumn.AllowEdit = false;
            this.colSTATUS.Visible = true;
            this.colSTATUS.VisibleIndex = 16;
            // 
            // colUNITARY_PRICE
            // 
            this.colUNITARY_PRICE.Caption = "Precio Unitario";
            this.colUNITARY_PRICE.FieldName = "UNITARY_PRICE";
            this.colUNITARY_PRICE.Name = "colUNITARY_PRICE";
            this.colUNITARY_PRICE.OptionsColumn.AllowEdit = false;
            this.colUNITARY_PRICE.Visible = true;
            this.colUNITARY_PRICE.VisibleIndex = 17;
            // 
            // UiListaBodega
            // 
            this.UiListaBodega.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UiListaBodega.Location = new System.Drawing.Point(74, 37);
            this.UiListaBodega.MenuManager = this.barManager1;
            this.UiListaBodega.Name = "UiListaBodega";
            this.UiListaBodega.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("UiListaBodega.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", "UiBotonRefrescarBodega", null, true)});
            this.UiListaBodega.Properties.View = this.UiListaVistaBodega;
            this.UiListaBodega.Properties.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.UiListaBodega_Properties_ButtonClick);
            this.UiListaBodega.Size = new System.Drawing.Size(1338, 22);
            this.UiListaBodega.TabIndex = 5;
            this.UiListaBodega.CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(this.UiListaBodega_CustomDisplayText);
            // 
            // UiListaVistaBodega
            // 
            this.UiListaVistaBodega.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colWAREHOUSE_ID,
            this.colNAME});
            this.UiListaVistaBodega.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.UiListaVistaBodega.Name = "UiListaVistaBodega";
            this.UiListaVistaBodega.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.UiListaVistaBodega.OptionsSelection.MultiSelect = true;
            this.UiListaVistaBodega.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.UiListaVistaBodega.OptionsView.ShowGroupPanel = false;
            this.UiListaVistaBodega.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.UiListaVistaBodega_SelectionChanged);
            this.UiListaVistaBodega.BeforeLeaveRow += new DevExpress.XtraGrid.Views.Base.RowAllowEventHandler(this.UiListaVistaBodega_BeforeLeaveRow);
            this.UiListaVistaBodega.MouseUp += new System.Windows.Forms.MouseEventHandler(this.UiListaVistaBodega_MouseUp);
            // 
            // colWAREHOUSE_ID
            // 
            this.colWAREHOUSE_ID.Caption = "Codigo Bodega";
            this.colWAREHOUSE_ID.FieldName = "WAREHOUSE_ID";
            this.colWAREHOUSE_ID.Name = "colWAREHOUSE_ID";
            this.colWAREHOUSE_ID.OptionsColumn.AllowEdit = false;
            this.colWAREHOUSE_ID.Visible = true;
            this.colWAREHOUSE_ID.VisibleIndex = 2;
            // 
            // colNAME
            // 
            this.colNAME.Caption = "Nombre";
            this.colNAME.FieldName = "NAME";
            this.colNAME.Name = "colNAME";
            this.colNAME.OptionsColumn.AllowEdit = false;
            this.colNAME.Visible = true;
            this.colNAME.VisibleIndex = 1;
            // 
            // UiLabelBodega
            // 
            this.UiLabelBodega.Location = new System.Drawing.Point(13, 38);
            this.UiLabelBodega.Name = "UiLabelBodega";
            this.UiLabelBodega.Size = new System.Drawing.Size(40, 13);
            this.UiLabelBodega.TabIndex = 6;
            this.UiLabelBodega.Text = "Bodega:";
            // 
            // colCLIENT_NAME
            // 
            this.colCLIENT_NAME.Caption = "Nombre Cliente";
            this.colCLIENT_NAME.FieldName = "CLIENT_NAME";
            this.colCLIENT_NAME.Name = "colCLIENT_NAME";
            this.colCLIENT_NAME.OptionsColumn.AllowEdit = false;
            this.colCLIENT_NAME.Visible = true;
            this.colCLIENT_NAME.VisibleIndex = 18;
            // 
            // ConsultaCosteoVista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1424, 690);
            this.Controls.Add(this.UiLabelBodega);
            this.Controls.Add(this.UiListaBodega);
            this.Controls.Add(this.UiContenedorCosteos);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ConsultaCosteoVista";
            this.Text = "Consulta de Costeos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConsultaCosteoVista_FormClosing);
            this.Load += new System.EventHandler(this.ConsultaCosteoVista_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiContenedorCosteos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiVistaCosteos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiListaBodega.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiListaVistaBodega)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar UiBarraPrincipalOpciones;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem UiBotonRefrescar;
        private DevExpress.XtraBars.BarButtonItem UiBotonExpandir;
        private DevExpress.XtraBars.BarButtonItem UiBotonContraer;
        private DevExpress.XtraBars.BarButtonItem UiBotonExportarExcel;
        private DevExpress.XtraBars.BarButtonItem UiBotonReporteConsolidado;
        private DevExpress.XtraBars.BarButtonItem UiBotonReportePorDocumento;
        private DevExpress.XtraGrid.GridControl UiContenedorCosteos;
        private DevExpress.XtraGrid.Views.Grid.GridView UiVistaCosteos;
        private DevExpress.XtraEditors.SearchLookUpEdit UiListaBodega;
        private DevExpress.XtraGrid.Views.Grid.GridView UiListaVistaBodega;
        private DevExpress.XtraEditors.LabelControl UiLabelBodega;
        private DevExpress.XtraBars.BarButtonItem UiBotonAutorizar;
        private DevExpress.XtraGrid.Columns.GridColumn colDOC_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colCODIGO_POLIZA;
        private DevExpress.XtraGrid.Columns.GridColumn colNUMERO_ORDER;
        private DevExpress.XtraGrid.Columns.GridColumn colCLIENT_CODE;
        private DevExpress.XtraGrid.Columns.GridColumn colFECHA_DOCUMENTO;
        private DevExpress.XtraGrid.Columns.GridColumn colFECHA_LLEGADA;
        private DevExpress.XtraGrid.Columns.GridColumn colPOLIZA_ASEGURADA;
        private DevExpress.XtraGrid.Columns.GridColumn colACUERDO_COMERCIAL;
        private DevExpress.XtraGrid.Columns.GridColumn colTRANS_TYPE;
        private DevExpress.XtraGrid.Columns.GridColumn colLINE_NUMBER;
        private DevExpress.XtraGrid.Columns.GridColumn colSKU_DESCRIPTION;
        private DevExpress.XtraGrid.Columns.GridColumn colQTY;
        private DevExpress.XtraGrid.Columns.GridColumn colCUSTOMS_AMOUNT;
        private DevExpress.XtraGrid.Columns.GridColumn colLAST_UPDATE_BY;
        private DevExpress.XtraGrid.Columns.GridColumn colLAST_UPDATED;
        private DevExpress.XtraGrid.Columns.GridColumn colMATEDIAL_ID;
        private DevExpress.XtraBars.BarEditItem UiFechaInicial;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraBars.BarEditItem UiFechaFinal;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn colWAREHOUSE_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colNAME;
        private DevExpress.XtraGrid.Columns.GridColumn colSTATUS;
        private DevExpress.XtraBars.BarToggleSwitchItem UiSwitchLineasAbiertas;
        private DevExpress.XtraGrid.Columns.GridColumn colUNITARY_PRICE;
        private DevExpress.XtraGrid.Columns.GridColumn colCLIENT_NAME;
    }
}