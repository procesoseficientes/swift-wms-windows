namespace MobilityScm.Modelo.Vistas
{
    partial class ConsultaDeLineaDePickingVista
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConsultaDeLineaDePickingVista));
            this.UiBarManager = new DevExpress.XtraBars.BarManager(this.components);
            this.UiBarraPrincipal = new DevExpress.XtraBars.Bar();
            this.UiFechaIncial = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.UiFechaFinal = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemDateEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.UiBotonRefrescar = new DevExpress.XtraBars.BarButtonItem();
            this.UiBotonExportarExcel = new DevExpress.XtraBars.BarButtonItem();
            this.UiBotonExpandir = new DevExpress.XtraBars.BarButtonItem();
            this.UiBotonContraer = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.repositoryItemTimeEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.repositoryItemTimeSpanEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTimeSpanEdit();
            this.UiContenedorPrincipal = new DevExpress.XtraGrid.GridControl();
            this.UiVistaPrincipal = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colWavePickingId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBoxId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaterialId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaterialName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPickedDatetime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatusDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLogin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLocationSpot = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBoxAssigned = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBoxAssignedDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBoxNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalBoxes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colClientId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colClientName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colClientRoute = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UiDialogoParaGuardar = new System.Windows.Forms.SaveFileDialog();
            this.UiBotonReporte = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.UiBarManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTimeEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTimeSpanEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiContenedorPrincipal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiVistaPrincipal)).BeginInit();
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
            this.UiBotonExpandir,
            this.UiBotonContraer,
            this.UiBotonReporte});
            this.UiBarManager.MainMenu = this.UiBarraPrincipal;
            this.UiBarManager.MaxItemId = 9;
            this.UiBarManager.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTimeEdit1,
            this.repositoryItemTimeSpanEdit1,
            this.repositoryItemDateEdit1,
            this.repositoryItemDateEdit2});
            // 
            // UiBarraPrincipal
            // 
            this.UiBarraPrincipal.BarName = "Main menu";
            this.UiBarraPrincipal.DockCol = 0;
            this.UiBarraPrincipal.DockRow = 0;
            this.UiBarraPrincipal.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.UiBarraPrincipal.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Width, this.UiFechaIncial, "", false, true, true, 168),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Width, this.UiFechaFinal, "", false, true, true, 183),
            new DevExpress.XtraBars.LinkPersistInfo(this.UiBotonRefrescar),
            new DevExpress.XtraBars.LinkPersistInfo(this.UiBotonExportarExcel),
            new DevExpress.XtraBars.LinkPersistInfo(this.UiBotonExpandir),
            new DevExpress.XtraBars.LinkPersistInfo(this.UiBotonContraer),
            new DevExpress.XtraBars.LinkPersistInfo(this.UiBotonReporte)});
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
            this.UiFechaIncial.Id = 2;
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
            this.UiFechaFinal.Id = 3;
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
            // UiBotonExpandir
            // 
            this.UiBotonExpandir.Caption = "Expandir";
            this.UiBotonExpandir.Glyph = ((System.Drawing.Image)(resources.GetObject("UiBotonExpandir.Glyph")));
            this.UiBotonExpandir.Id = 6;
            this.UiBotonExpandir.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("UiBotonExpandir.LargeGlyph")));
            this.UiBotonExpandir.Name = "UiBotonExpandir";
            this.UiBotonExpandir.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.UiBotonExpandir.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.UiBotonExpandir_ItemClick);
            // 
            // UiBotonContraer
            // 
            this.UiBotonContraer.Caption = "Contraer";
            this.UiBotonContraer.Glyph = ((System.Drawing.Image)(resources.GetObject("UiBotonContraer.Glyph")));
            this.UiBotonContraer.Id = 7;
            this.UiBotonContraer.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("UiBotonContraer.LargeGlyph")));
            this.UiBotonContraer.Name = "UiBotonContraer";
            this.UiBotonContraer.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.UiBotonContraer.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.UiBotonContraer_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1106, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 650);
            this.barDockControlBottom.Size = new System.Drawing.Size(1106, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 626);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1106, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 626);
            // 
            // repositoryItemTimeEdit1
            // 
            this.repositoryItemTimeEdit1.AutoHeight = false;
            this.repositoryItemTimeEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemTimeEdit1.Name = "repositoryItemTimeEdit1";
            // 
            // repositoryItemTimeSpanEdit1
            // 
            this.repositoryItemTimeSpanEdit1.AutoHeight = false;
            this.repositoryItemTimeSpanEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemTimeSpanEdit1.Mask.EditMask = "dd.HH:mm:ss";
            this.repositoryItemTimeSpanEdit1.Name = "repositoryItemTimeSpanEdit1";
            // 
            // UiContenedorPrincipal
            // 
            this.UiContenedorPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UiContenedorPrincipal.Location = new System.Drawing.Point(0, 24);
            this.UiContenedorPrincipal.MainView = this.UiVistaPrincipal;
            this.UiContenedorPrincipal.MenuManager = this.UiBarManager;
            this.UiContenedorPrincipal.Name = "UiContenedorPrincipal";
            this.UiContenedorPrincipal.Size = new System.Drawing.Size(1106, 626);
            this.UiContenedorPrincipal.TabIndex = 4;
            this.UiContenedorPrincipal.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.UiVistaPrincipal});
            // 
            // UiVistaPrincipal
            // 
            this.UiVistaPrincipal.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colWavePickingId,
            this.colBoxId,
            this.colMaterialId,
            this.colMaterialName,
            this.colQuantity,
            this.colPickedDatetime,
            this.colStatus,
            this.colStatusDescription,
            this.colLogin,
            this.colLocationSpot,
            this.colBoxAssigned,
            this.colBoxAssignedDescription,
            this.colBoxNumber,
            this.colTotalBoxes,
            this.colGate,
            this.colClientId,
            this.colClientName,
            this.colClientRoute});
            this.UiVistaPrincipal.GridControl = this.UiContenedorPrincipal;
            this.UiVistaPrincipal.GroupCount = 3;
            this.UiVistaPrincipal.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "GATE", null, "(Total: {0:#,###,##0.00})")});
            this.UiVistaPrincipal.Name = "UiVistaPrincipal";
            this.UiVistaPrincipal.OptionsView.ShowAutoFilterRow = true;
            this.UiVistaPrincipal.OptionsView.ShowFooter = true;
            this.UiVistaPrincipal.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colGate, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colWavePickingId, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colBoxNumber, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colWavePickingId
            // 
            this.colWavePickingId.Caption = "Ola de Picking";
            this.colWavePickingId.FieldName = "WAVE_PICKING_ID";
            this.colWavePickingId.Name = "colWavePickingId";
            this.colWavePickingId.OptionsColumn.AllowEdit = false;
            this.colWavePickingId.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "WAVE_PICKING_ID", "{0}")});
            this.colWavePickingId.Visible = true;
            this.colWavePickingId.VisibleIndex = 0;
            // 
            // colBoxId
            // 
            this.colBoxId.Caption = "Caja";
            this.colBoxId.FieldName = "BOX_ID";
            this.colBoxId.Name = "colBoxId";
            this.colBoxId.OptionsColumn.AllowEdit = false;
            this.colBoxId.Visible = true;
            this.colBoxId.VisibleIndex = 0;
            this.colBoxId.Width = 83;
            // 
            // colMaterialId
            // 
            this.colMaterialId.Caption = "Código de Material";
            this.colMaterialId.FieldName = "MATERIAL_ID";
            this.colMaterialId.Name = "colMaterialId";
            this.colMaterialId.OptionsColumn.AllowEdit = false;
            this.colMaterialId.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colMaterialId.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "MATERIAL_ID", "{0:#,###,##0.00}")});
            this.colMaterialId.Visible = true;
            this.colMaterialId.VisibleIndex = 1;
            // 
            // colMaterialName
            // 
            this.colMaterialName.Caption = "Material";
            this.colMaterialName.FieldName = "MATERIAL_NAME";
            this.colMaterialName.Name = "colMaterialName";
            this.colMaterialName.OptionsColumn.AllowEdit = false;
            this.colMaterialName.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colMaterialName.Visible = true;
            this.colMaterialName.VisibleIndex = 2;
            // 
            // colQuantity
            // 
            this.colQuantity.Caption = "Cantidad";
            this.colQuantity.DisplayFormat.FormatString = "{0:#,###,##0.00}";
            this.colQuantity.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colQuantity.FieldName = "QUANTITY";
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.OptionsColumn.AllowEdit = false;
            this.colQuantity.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "QUANTITY", "{0:#,###,##0.00}")});
            this.colQuantity.Visible = true;
            this.colQuantity.VisibleIndex = 3;
            // 
            // colPickedDatetime
            // 
            this.colPickedDatetime.Caption = "Fecha";
            this.colPickedDatetime.FieldName = "PICKED_DATETIME";
            this.colPickedDatetime.Name = "colPickedDatetime";
            this.colPickedDatetime.OptionsColumn.AllowEdit = false;
            this.colPickedDatetime.Visible = true;
            this.colPickedDatetime.VisibleIndex = 4;
            // 
            // colStatus
            // 
            this.colStatus.Caption = "Estado";
            this.colStatus.FieldName = "STATUS";
            this.colStatus.Name = "colStatus";
            this.colStatus.OptionsColumn.AllowEdit = false;
            this.colStatus.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colStatusDescription
            // 
            this.colStatusDescription.Caption = "Estado";
            this.colStatusDescription.FieldName = "STATUS_DESCRIPTION";
            this.colStatusDescription.Name = "colStatusDescription";
            this.colStatusDescription.OptionsColumn.AllowEdit = false;
            this.colStatusDescription.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colStatusDescription.Visible = true;
            this.colStatusDescription.VisibleIndex = 5;
            // 
            // colLogin
            // 
            this.colLogin.Caption = "Usuario";
            this.colLogin.FieldName = "LOGIN_ID";
            this.colLogin.Name = "colLogin";
            this.colLogin.OptionsColumn.AllowEdit = false;
            this.colLogin.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colLogin.Visible = true;
            this.colLogin.VisibleIndex = 6;
            // 
            // colLocationSpot
            // 
            this.colLocationSpot.Caption = "Ubicación";
            this.colLocationSpot.FieldName = "LOCATION_SPOT";
            this.colLocationSpot.Name = "colLocationSpot";
            this.colLocationSpot.OptionsColumn.AllowEdit = false;
            this.colLocationSpot.Visible = true;
            this.colLocationSpot.VisibleIndex = 7;
            // 
            // colBoxAssigned
            // 
            this.colBoxAssigned.Caption = "Asignada";
            this.colBoxAssigned.FieldName = "BOX_ASSIGNED";
            this.colBoxAssigned.Name = "colBoxAssigned";
            this.colBoxAssigned.OptionsColumn.AllowEdit = false;
            this.colBoxAssigned.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colBoxAssignedDescription
            // 
            this.colBoxAssignedDescription.Caption = "Asignada";
            this.colBoxAssignedDescription.FieldName = "BOX_ASSIGNED_DESCRIPTION";
            this.colBoxAssignedDescription.Name = "colBoxAssignedDescription";
            this.colBoxAssignedDescription.OptionsColumn.AllowEdit = false;
            this.colBoxAssignedDescription.Visible = true;
            this.colBoxAssignedDescription.VisibleIndex = 8;
            // 
            // colBoxNumber
            // 
            this.colBoxNumber.Caption = "No. de Caja";
            this.colBoxNumber.FieldName = "BOX_NUMBER";
            this.colBoxNumber.Name = "colBoxNumber";
            this.colBoxNumber.OptionsColumn.AllowEdit = false;
            this.colBoxNumber.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "MATERIAL_ID", "{0}")});
            this.colBoxNumber.Visible = true;
            this.colBoxNumber.VisibleIndex = 9;
            // 
            // colTotalBoxes
            // 
            this.colTotalBoxes.Caption = "Total De Cajas";
            this.colTotalBoxes.FieldName = "TOTAL_BOXES";
            this.colTotalBoxes.Name = "colTotalBoxes";
            this.colTotalBoxes.OptionsColumn.AllowEdit = false;
            this.colTotalBoxes.Visible = true;
            this.colTotalBoxes.VisibleIndex = 9;
            // 
            // colGate
            // 
            this.colGate.Caption = "Rampa";
            this.colGate.FieldName = "GATE";
            this.colGate.Name = "colGate";
            this.colGate.OptionsColumn.AllowEdit = false;
            this.colGate.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "WAVE_PICKING_ID", "{0}")});
            this.colGate.Visible = true;
            this.colGate.VisibleIndex = 11;
            // 
            // colClientId
            // 
            this.colClientId.Caption = "Código de Cliente";
            this.colClientId.FieldName = "CLIENT_ID";
            this.colClientId.Name = "colClientId";
            this.colClientId.OptionsColumn.AllowEdit = false;
            this.colClientId.Visible = true;
            this.colClientId.VisibleIndex = 10;
            // 
            // colClientName
            // 
            this.colClientName.Caption = "Cliente";
            this.colClientName.FieldName = "CLIENT_NAME";
            this.colClientName.Name = "colClientName";
            this.colClientName.OptionsColumn.AllowEdit = false;
            this.colClientName.Visible = true;
            this.colClientName.VisibleIndex = 11;
            // 
            // colClientRoute
            // 
            this.colClientRoute.Caption = "Ruta";
            this.colClientRoute.FieldName = "CLIENT_ROUTE";
            this.colClientRoute.Name = "colClientRoute";
            this.colClientRoute.OptionsColumn.AllowEdit = false;
            this.colClientRoute.Visible = true;
            this.colClientRoute.VisibleIndex = 12;
            // 
            // UiBotonReporte
            // 
            this.UiBotonReporte.Caption = "Imprimir";
            this.UiBotonReporte.Glyph = ((System.Drawing.Image)(resources.GetObject("UiBotonReporte.Glyph")));
            this.UiBotonReporte.Id = 8;
            this.UiBotonReporte.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("UiBotonReporte.LargeGlyph")));
            this.UiBotonReporte.Name = "UiBotonReporte";
            this.UiBotonReporte.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.UiBotonReporte.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.UiBotonReporte_ItemClick);
            // 
            // ConsultaDeLineaDePickingVista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1106, 650);
            this.Controls.Add(this.UiContenedorPrincipal);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ConsultaDeLineaDePickingVista";
            this.Text = "Consulta de Linea de Picking";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConsultaDeLineaDePickingVista_FormClosing);
            this.Load += new System.EventHandler(this.ConsultaDeLineaDePickingVista_Load);
            ((System.ComponentModel.ISupportInitialize)(this.UiBarManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTimeEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTimeSpanEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiContenedorPrincipal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiVistaPrincipal)).EndInit();
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
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit repositoryItemTimeEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeSpanEdit repositoryItemTimeSpanEdit1;
        private DevExpress.XtraBars.BarEditItem UiFechaIncial;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraBars.BarEditItem UiFechaFinal;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit2;
        private DevExpress.XtraBars.BarButtonItem UiBotonRefrescar;
        private DevExpress.XtraBars.BarButtonItem UiBotonExportarExcel;
        private DevExpress.XtraGrid.GridControl UiContenedorPrincipal;
        private DevExpress.XtraGrid.Views.Grid.GridView UiVistaPrincipal;
        private DevExpress.XtraGrid.Columns.GridColumn colWavePickingId;
        private DevExpress.XtraGrid.Columns.GridColumn colBoxId;
        private DevExpress.XtraGrid.Columns.GridColumn colMaterialId;
        private DevExpress.XtraGrid.Columns.GridColumn colMaterialName;
        private DevExpress.XtraGrid.Columns.GridColumn colQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn colPickedDatetime;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colStatusDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colLogin;
        private DevExpress.XtraGrid.Columns.GridColumn colLocationSpot;
        private DevExpress.XtraGrid.Columns.GridColumn colBoxAssigned;
        private DevExpress.XtraGrid.Columns.GridColumn colBoxAssignedDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colBoxNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalBoxes;
        private DevExpress.XtraGrid.Columns.GridColumn colGate;
        private System.Windows.Forms.SaveFileDialog UiDialogoParaGuardar;
        private DevExpress.XtraBars.BarButtonItem UiBotonExpandir;
        private DevExpress.XtraBars.BarButtonItem UiBotonContraer;
        private DevExpress.XtraGrid.Columns.GridColumn colClientId;
        private DevExpress.XtraGrid.Columns.GridColumn colClientName;
        private DevExpress.XtraGrid.Columns.GridColumn colClientRoute;
        private DevExpress.XtraBars.BarButtonItem UiBotonReporte;
    }
}