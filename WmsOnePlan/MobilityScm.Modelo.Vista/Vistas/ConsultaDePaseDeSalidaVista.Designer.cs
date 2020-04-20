namespace MobilityScm.Modelo.Vistas
{
    partial class ConsultaDePaseDeSalidaVista
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConsultaDePaseDeSalidaVista));
            this.UiBarraDeMenuPrincipal = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.UiBtnExportarVistaPasesDeSalidaAExcel = new DevExpress.XtraBars.BarButtonItem();
            this.UiBtnExpandirGruposVistaPasesDeSalida = new DevExpress.XtraBars.BarButtonItem();
            this.UiBtnContraerGruposVistaPasesDeSalida = new DevExpress.XtraBars.BarButtonItem();
            this.UiBtnRefrescarVistaPasesDeSalida = new DevExpress.XtraBars.BarButtonItem();
            this.UiFechaInicialConsultaPasesDeSalida = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.UiFechaFinalConsultaPasesDeSalida = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemDateEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.UiContenedorVistaPaseDeSalida = new DevExpress.XtraGrid.GridControl();
            this.UiVistaPaseDeSalida = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.UiColPaseDeSalidaId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UiColPlacaVehiculo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UiColCodigoVehiculo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UiColCodigoPiloto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UiColNombrePiloto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UiColBodega = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UiColFechaCreacionPaseDeSalida = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UiColEstadoPaseDeSalida = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UiColTipoPaseDeSalida = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UiColCodigoCliente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UiColNombreCliente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UiColCodigoDeOlaDePicking = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UiColNumeroDocumento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UiColCodigoMaterial = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UiColDescripcionMaterial = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UiColCantidadMaterial = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UiColDocumentoErp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UiDialogoExportarVistaAExcel = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.UiBarraDeMenuPrincipal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiContenedorVistaPaseDeSalida)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiVistaPaseDeSalida)).BeginInit();
            this.SuspendLayout();
            // 
            // UiBarraDeMenuPrincipal
            // 
            this.UiBarraDeMenuPrincipal.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.UiBarraDeMenuPrincipal.DockControls.Add(this.barDockControlTop);
            this.UiBarraDeMenuPrincipal.DockControls.Add(this.barDockControlBottom);
            this.UiBarraDeMenuPrincipal.DockControls.Add(this.barDockControlLeft);
            this.UiBarraDeMenuPrincipal.DockControls.Add(this.barDockControlRight);
            this.UiBarraDeMenuPrincipal.Form = this;
            this.UiBarraDeMenuPrincipal.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.UiBtnExportarVistaPasesDeSalidaAExcel,
            this.UiBtnExpandirGruposVistaPasesDeSalida,
            this.UiBtnContraerGruposVistaPasesDeSalida,
            this.UiBtnRefrescarVistaPasesDeSalida,
            this.UiFechaInicialConsultaPasesDeSalida,
            this.UiFechaFinalConsultaPasesDeSalida});
            this.UiBarraDeMenuPrincipal.MaxItemId = 6;
            this.UiBarraDeMenuPrincipal.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemDateEdit1,
            this.repositoryItemDateEdit2});
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.UiBtnExportarVistaPasesDeSalidaAExcel, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.UiBtnExpandirGruposVistaPasesDeSalida, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.UiBtnContraerGruposVistaPasesDeSalida, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.UiBtnRefrescarVistaPasesDeSalida, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.UiFechaInicialConsultaPasesDeSalida, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.UiFechaFinalConsultaPasesDeSalida, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Tools";
            // 
            // UiBtnExportarVistaPasesDeSalidaAExcel
            // 
            this.UiBtnExportarVistaPasesDeSalidaAExcel.Caption = "Exportar A Excel";
            this.UiBtnExportarVistaPasesDeSalidaAExcel.Glyph = ((System.Drawing.Image)(resources.GetObject("UiBtnExportarVistaPasesDeSalidaAExcel.Glyph")));
            this.UiBtnExportarVistaPasesDeSalidaAExcel.Id = 0;
            this.UiBtnExportarVistaPasesDeSalidaAExcel.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("UiBtnExportarVistaPasesDeSalidaAExcel.LargeGlyph")));
            this.UiBtnExportarVistaPasesDeSalidaAExcel.Name = "UiBtnExportarVistaPasesDeSalidaAExcel";
            this.UiBtnExportarVistaPasesDeSalidaAExcel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.UiBtnExportarVistaPasesDeSalidaAExcel_ItemClick);
            // 
            // UiBtnExpandirGruposVistaPasesDeSalida
            // 
            this.UiBtnExpandirGruposVistaPasesDeSalida.Caption = "Expandir Grupos";
            this.UiBtnExpandirGruposVistaPasesDeSalida.Glyph = ((System.Drawing.Image)(resources.GetObject("UiBtnExpandirGruposVistaPasesDeSalida.Glyph")));
            this.UiBtnExpandirGruposVistaPasesDeSalida.Id = 1;
            this.UiBtnExpandirGruposVistaPasesDeSalida.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("UiBtnExpandirGruposVistaPasesDeSalida.LargeGlyph")));
            this.UiBtnExpandirGruposVistaPasesDeSalida.Name = "UiBtnExpandirGruposVistaPasesDeSalida";
            this.UiBtnExpandirGruposVistaPasesDeSalida.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.UiBtnExpandirGruposVistaPasesDeSalida_ItemClick);
            // 
            // UiBtnContraerGruposVistaPasesDeSalida
            // 
            this.UiBtnContraerGruposVistaPasesDeSalida.Caption = "Contraer Grupos";
            this.UiBtnContraerGruposVistaPasesDeSalida.Glyph = ((System.Drawing.Image)(resources.GetObject("UiBtnContraerGruposVistaPasesDeSalida.Glyph")));
            this.UiBtnContraerGruposVistaPasesDeSalida.Id = 2;
            this.UiBtnContraerGruposVistaPasesDeSalida.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("UiBtnContraerGruposVistaPasesDeSalida.LargeGlyph")));
            this.UiBtnContraerGruposVistaPasesDeSalida.Name = "UiBtnContraerGruposVistaPasesDeSalida";
            this.UiBtnContraerGruposVistaPasesDeSalida.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.UiBtnContraerGruposVistaPasesDeSalida_ItemClick);
            // 
            // UiBtnRefrescarVistaPasesDeSalida
            // 
            this.UiBtnRefrescarVistaPasesDeSalida.Caption = "Refrescar";
            this.UiBtnRefrescarVistaPasesDeSalida.Glyph = ((System.Drawing.Image)(resources.GetObject("UiBtnRefrescarVistaPasesDeSalida.Glyph")));
            this.UiBtnRefrescarVistaPasesDeSalida.Id = 3;
            this.UiBtnRefrescarVistaPasesDeSalida.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("UiBtnRefrescarVistaPasesDeSalida.LargeGlyph")));
            this.UiBtnRefrescarVistaPasesDeSalida.Name = "UiBtnRefrescarVistaPasesDeSalida";
            this.UiBtnRefrescarVistaPasesDeSalida.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.UiBtnRefrescarVistaPasesDeSalida_ItemClick);
            // 
            // UiFechaInicialConsultaPasesDeSalida
            // 
            this.UiFechaInicialConsultaPasesDeSalida.Caption = "Fecha Inicial";
            this.UiFechaInicialConsultaPasesDeSalida.Edit = this.repositoryItemDateEdit1;
            this.UiFechaInicialConsultaPasesDeSalida.Glyph = ((System.Drawing.Image)(resources.GetObject("UiFechaInicialConsultaPasesDeSalida.Glyph")));
            this.UiFechaInicialConsultaPasesDeSalida.Id = 4;
            this.UiFechaInicialConsultaPasesDeSalida.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("UiFechaInicialConsultaPasesDeSalida.LargeGlyph")));
            this.UiFechaInicialConsultaPasesDeSalida.Name = "UiFechaInicialConsultaPasesDeSalida";
            this.UiFechaInicialConsultaPasesDeSalida.Size = new System.Drawing.Size(250, 0);
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
            // UiFechaFinalConsultaPasesDeSalida
            // 
            this.UiFechaFinalConsultaPasesDeSalida.Caption = "Fecha Final";
            this.UiFechaFinalConsultaPasesDeSalida.Edit = this.repositoryItemDateEdit2;
            this.UiFechaFinalConsultaPasesDeSalida.Glyph = ((System.Drawing.Image)(resources.GetObject("UiFechaFinalConsultaPasesDeSalida.Glyph")));
            this.UiFechaFinalConsultaPasesDeSalida.Id = 5;
            this.UiFechaFinalConsultaPasesDeSalida.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("UiFechaFinalConsultaPasesDeSalida.LargeGlyph")));
            this.UiFechaFinalConsultaPasesDeSalida.Name = "UiFechaFinalConsultaPasesDeSalida";
            this.UiFechaFinalConsultaPasesDeSalida.Size = new System.Drawing.Size(250, 0);
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
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1234, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 560);
            this.barDockControlBottom.Size = new System.Drawing.Size(1234, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 529);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1234, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 529);
            // 
            // UiContenedorVistaPaseDeSalida
            // 
            this.UiContenedorVistaPaseDeSalida.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UiContenedorVistaPaseDeSalida.Location = new System.Drawing.Point(0, 31);
            this.UiContenedorVistaPaseDeSalida.MainView = this.UiVistaPaseDeSalida;
            this.UiContenedorVistaPaseDeSalida.MenuManager = this.UiBarraDeMenuPrincipal;
            this.UiContenedorVistaPaseDeSalida.Name = "UiContenedorVistaPaseDeSalida";
            this.UiContenedorVistaPaseDeSalida.Size = new System.Drawing.Size(1234, 529);
            this.UiContenedorVistaPaseDeSalida.TabIndex = 4;
            this.UiContenedorVistaPaseDeSalida.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.UiVistaPaseDeSalida});
            this.UiContenedorVistaPaseDeSalida.DoubleClick += new System.EventHandler(this.UiContenedorVistaPaseDeSalida_DoubleClick);
            // 
            // UiVistaPaseDeSalida
            // 
            this.UiVistaPaseDeSalida.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.UiColPaseDeSalidaId,
            this.UiColPlacaVehiculo,
            this.UiColCodigoVehiculo,
            this.UiColCodigoPiloto,
            this.UiColNombrePiloto,
            this.UiColBodega,
            this.UiColFechaCreacionPaseDeSalida,
            this.UiColEstadoPaseDeSalida,
            this.UiColTipoPaseDeSalida,
            this.UiColCodigoCliente,
            this.UiColNombreCliente,
            this.UiColCodigoDeOlaDePicking,
            this.UiColNumeroDocumento,
            this.UiColCodigoMaterial,
            this.UiColDescripcionMaterial,
            this.UiColCantidadMaterial,
            this.UiColDocumentoErp});
            this.UiVistaPaseDeSalida.GridControl = this.UiContenedorVistaPaseDeSalida;
            this.UiVistaPaseDeSalida.GroupCount = 2;
            this.UiVistaPaseDeSalida.Name = "UiVistaPaseDeSalida";
            this.UiVistaPaseDeSalida.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.UiColPaseDeSalidaId, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.UiColCodigoCliente, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // UiColPaseDeSalidaId
            // 
            this.UiColPaseDeSalidaId.Caption = "Código";
            this.UiColPaseDeSalidaId.FieldName = "PASS_ID";
            this.UiColPaseDeSalidaId.Name = "UiColPaseDeSalidaId";
            this.UiColPaseDeSalidaId.OptionsColumn.AllowEdit = false;
            this.UiColPaseDeSalidaId.Visible = true;
            this.UiColPaseDeSalidaId.VisibleIndex = 0;
            // 
            // UiColPlacaVehiculo
            // 
            this.UiColPlacaVehiculo.Caption = "Placa Vehículo";
            this.UiColPlacaVehiculo.FieldName = "VEHICLE_PLATE";
            this.UiColPlacaVehiculo.Name = "UiColPlacaVehiculo";
            this.UiColPlacaVehiculo.OptionsColumn.AllowEdit = false;
            this.UiColPlacaVehiculo.Visible = true;
            this.UiColPlacaVehiculo.VisibleIndex = 0;
            // 
            // UiColCodigoVehiculo
            // 
            this.UiColCodigoVehiculo.Caption = "Código Vehículo";
            this.UiColCodigoVehiculo.FieldName = "VEHICLE_ID";
            this.UiColCodigoVehiculo.Name = "UiColCodigoVehiculo";
            this.UiColCodigoVehiculo.OptionsColumn.AllowEdit = false;
            // 
            // UiColCodigoPiloto
            // 
            this.UiColCodigoPiloto.Caption = "Código Piloto";
            this.UiColCodigoPiloto.FieldName = "DRIVER_ID";
            this.UiColCodigoPiloto.Name = "UiColCodigoPiloto";
            this.UiColCodigoPiloto.OptionsColumn.AllowEdit = false;
            // 
            // UiColNombrePiloto
            // 
            this.UiColNombrePiloto.Caption = "Nombre Piloto";
            this.UiColNombrePiloto.FieldName = "NAME_PILOT";
            this.UiColNombrePiloto.Name = "UiColNombrePiloto";
            this.UiColNombrePiloto.OptionsColumn.AllowEdit = false;
            this.UiColNombrePiloto.Visible = true;
            this.UiColNombrePiloto.VisibleIndex = 1;
            // 
            // UiColBodega
            // 
            this.UiColBodega.Caption = "Centro De Distribución";
            this.UiColBodega.FieldName = "CODE_WAREHOUSE";
            this.UiColBodega.Name = "UiColBodega";
            this.UiColBodega.OptionsColumn.AllowEdit = false;
            this.UiColBodega.Visible = true;
            this.UiColBodega.VisibleIndex = 3;
            // 
            // UiColFechaCreacionPaseDeSalida
            // 
            this.UiColFechaCreacionPaseDeSalida.Caption = "Fecha Creación";
            this.UiColFechaCreacionPaseDeSalida.FieldName = "CREATED_DATE";
            this.UiColFechaCreacionPaseDeSalida.Name = "UiColFechaCreacionPaseDeSalida";
            this.UiColFechaCreacionPaseDeSalida.OptionsColumn.AllowEdit = false;
            this.UiColFechaCreacionPaseDeSalida.Visible = true;
            this.UiColFechaCreacionPaseDeSalida.VisibleIndex = 2;
            // 
            // UiColEstadoPaseDeSalida
            // 
            this.UiColEstadoPaseDeSalida.Caption = "Estado";
            this.UiColEstadoPaseDeSalida.FieldName = "STATUS";
            this.UiColEstadoPaseDeSalida.Name = "UiColEstadoPaseDeSalida";
            this.UiColEstadoPaseDeSalida.OptionsColumn.AllowEdit = false;
            this.UiColEstadoPaseDeSalida.Visible = true;
            this.UiColEstadoPaseDeSalida.VisibleIndex = 4;
            // 
            // UiColTipoPaseDeSalida
            // 
            this.UiColTipoPaseDeSalida.Caption = "Tipo";
            this.UiColTipoPaseDeSalida.FieldName = "TYPE";
            this.UiColTipoPaseDeSalida.Name = "UiColTipoPaseDeSalida";
            this.UiColTipoPaseDeSalida.OptionsColumn.AllowEdit = false;
            this.UiColTipoPaseDeSalida.Visible = true;
            this.UiColTipoPaseDeSalida.VisibleIndex = 5;
            // 
            // UiColCodigoCliente
            // 
            this.UiColCodigoCliente.Caption = "Código Cliente";
            this.UiColCodigoCliente.FieldName = "CLIENT_CODE";
            this.UiColCodigoCliente.Name = "UiColCodigoCliente";
            this.UiColCodigoCliente.OptionsColumn.AllowEdit = false;
            this.UiColCodigoCliente.Visible = true;
            this.UiColCodigoCliente.VisibleIndex = 6;
            // 
            // UiColNombreCliente
            // 
            this.UiColNombreCliente.Caption = "Nombre Cliente";
            this.UiColNombreCliente.FieldName = "CLIENT_NAME";
            this.UiColNombreCliente.Name = "UiColNombreCliente";
            this.UiColNombreCliente.OptionsColumn.AllowEdit = false;
            this.UiColNombreCliente.Visible = true;
            this.UiColNombreCliente.VisibleIndex = 6;
            // 
            // UiColCodigoDeOlaDePicking
            // 
            this.UiColCodigoDeOlaDePicking.Caption = "Ola De Picking";
            this.UiColCodigoDeOlaDePicking.FieldName = "WAVE_PICKING_ID";
            this.UiColCodigoDeOlaDePicking.Name = "UiColCodigoDeOlaDePicking";
            this.UiColCodigoDeOlaDePicking.OptionsColumn.AllowEdit = false;
            this.UiColCodigoDeOlaDePicking.Visible = true;
            this.UiColCodigoDeOlaDePicking.VisibleIndex = 7;
            // 
            // UiColNumeroDocumento
            // 
            this.UiColNumeroDocumento.Caption = "Número Documento";
            this.UiColNumeroDocumento.FieldName = "DOC_NUM";
            this.UiColNumeroDocumento.Name = "UiColNumeroDocumento";
            this.UiColNumeroDocumento.OptionsColumn.AllowEdit = false;
            this.UiColNumeroDocumento.Visible = true;
            this.UiColNumeroDocumento.VisibleIndex = 8;
            // 
            // UiColCodigoMaterial
            // 
            this.UiColCodigoMaterial.Caption = "Material";
            this.UiColCodigoMaterial.FieldName = "MATERIAL_ID";
            this.UiColCodigoMaterial.Name = "UiColCodigoMaterial";
            this.UiColCodigoMaterial.OptionsColumn.AllowEdit = false;
            this.UiColCodigoMaterial.Visible = true;
            this.UiColCodigoMaterial.VisibleIndex = 9;
            // 
            // UiColDescripcionMaterial
            // 
            this.UiColDescripcionMaterial.Caption = "Descripción";
            this.UiColDescripcionMaterial.FieldName = "MATERIAL_NAME";
            this.UiColDescripcionMaterial.Name = "UiColDescripcionMaterial";
            this.UiColDescripcionMaterial.OptionsColumn.AllowEdit = false;
            this.UiColDescripcionMaterial.Visible = true;
            this.UiColDescripcionMaterial.VisibleIndex = 10;
            // 
            // UiColCantidadMaterial
            // 
            this.UiColCantidadMaterial.Caption = "Cantidad";
            this.UiColCantidadMaterial.FieldName = "QTY";
            this.UiColCantidadMaterial.Name = "UiColCantidadMaterial";
            this.UiColCantidadMaterial.OptionsColumn.AllowEdit = false;
            this.UiColCantidadMaterial.Visible = true;
            this.UiColCantidadMaterial.VisibleIndex = 11;
            // 
            // UiColDocumentoErp
            // 
            this.UiColDocumentoErp.Caption = "Documento ERP";
            this.UiColDocumentoErp.FieldName = "ERP_REFERENCE";
            this.UiColDocumentoErp.Name = "UiColDocumentoErp";
            this.UiColDocumentoErp.OptionsColumn.AllowEdit = false;
            this.UiColDocumentoErp.Visible = true;
            this.UiColDocumentoErp.VisibleIndex = 12;
            // 
            // ConsultaDePaseDeSalidaVista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 560);
            this.Controls.Add(this.UiContenedorVistaPaseDeSalida);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ConsultaDePaseDeSalidaVista";
            this.Text = "Consulta De Pase De Salida";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConsultaDePaseDeSalidaVista_FormClosing);
            this.Load += new System.EventHandler(this.ConsultaDePaseDeSalidaVista_Load);
            ((System.ComponentModel.ISupportInitialize)(this.UiBarraDeMenuPrincipal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiContenedorVistaPaseDeSalida)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiVistaPaseDeSalida)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager UiBarraDeMenuPrincipal;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem UiBtnExportarVistaPasesDeSalidaAExcel;
        private DevExpress.XtraBars.BarButtonItem UiBtnExpandirGruposVistaPasesDeSalida;
        private DevExpress.XtraBars.BarButtonItem UiBtnContraerGruposVistaPasesDeSalida;
        private DevExpress.XtraBars.BarButtonItem UiBtnRefrescarVistaPasesDeSalida;
        private DevExpress.XtraBars.BarEditItem UiFechaInicialConsultaPasesDeSalida;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraBars.BarEditItem UiFechaFinalConsultaPasesDeSalida;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit2;
        private DevExpress.XtraGrid.GridControl UiContenedorVistaPaseDeSalida;
        private DevExpress.XtraGrid.Views.Grid.GridView UiVistaPaseDeSalida;
        private DevExpress.XtraGrid.Columns.GridColumn UiColPaseDeSalidaId;
        private DevExpress.XtraGrid.Columns.GridColumn UiColPlacaVehiculo;
        private DevExpress.XtraGrid.Columns.GridColumn UiColCodigoVehiculo;
        private DevExpress.XtraGrid.Columns.GridColumn UiColCodigoPiloto;
        private DevExpress.XtraGrid.Columns.GridColumn UiColNombrePiloto;
        private DevExpress.XtraGrid.Columns.GridColumn UiColBodega;
        private DevExpress.XtraGrid.Columns.GridColumn UiColFechaCreacionPaseDeSalida;
        private DevExpress.XtraGrid.Columns.GridColumn UiColEstadoPaseDeSalida;
        private DevExpress.XtraGrid.Columns.GridColumn UiColTipoPaseDeSalida;
        private DevExpress.XtraGrid.Columns.GridColumn UiColCodigoCliente;
        private DevExpress.XtraGrid.Columns.GridColumn UiColNombreCliente;
        private DevExpress.XtraGrid.Columns.GridColumn UiColCodigoDeOlaDePicking;
        private DevExpress.XtraGrid.Columns.GridColumn UiColNumeroDocumento;
        private DevExpress.XtraGrid.Columns.GridColumn UiColCodigoMaterial;
        private DevExpress.XtraGrid.Columns.GridColumn UiColDescripcionMaterial;
        private DevExpress.XtraGrid.Columns.GridColumn UiColCantidadMaterial;
        private System.Windows.Forms.SaveFileDialog UiDialogoExportarVistaAExcel;
        private DevExpress.XtraGrid.Columns.GridColumn UiColDocumentoErp;
    }
}