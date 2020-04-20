namespace MobilityScm.Modelo.Vistas
{
    partial class ReportePickingVista
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportePickingVista));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.UiFechaInicial = new DevExpress.XtraBars.BarEditItem();
            this.UiStartDate = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.barStaticItem2 = new DevExpress.XtraBars.BarStaticItem();
            this.UiFechaFinal = new DevExpress.XtraBars.BarEditItem();
            this.UiEndDate = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.UiBotonRefrescar = new DevExpress.XtraBars.BarButtonItem();
            this.UiEditComboGuardados = new DevExpress.XtraBars.BarEditItem();
            this.comboPivotGuardados = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.UiBotonExportarPivotTable = new DevExpress.XtraBars.BarButtonItem();
            this.UiBotonExportarData = new DevExpress.XtraBars.BarButtonItem();
            this.UiBotonGuardarConfiguracionPivot = new DevExpress.XtraBars.BarButtonItem();
            this.UiBotonGuardarComoNuevo = new DevExpress.XtraBars.BarButtonItem();
            this.UiEditNombreArchivo = new DevExpress.XtraBars.BarEditItem();
            this.txtNombreReportePivot = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.UiBotonEliminarXmlPivot = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.UiPivotReportePicking = new DevExpress.XtraPivotGrid.PivotGridControl();
            this.UICol_WAVE_PICKING_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            this.UiCol_DOC_NUM = new DevExpress.XtraPivotGrid.PivotGridField();
            this.UiCol_CREATED_BY = new DevExpress.XtraPivotGrid.PivotGridField();
            this.UiCol_CREATED_BY_NAME = new DevExpress.XtraPivotGrid.PivotGridField();
            this.UiCol_MATERIAL_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            this.UiCol_MATERIAL_NAME = new DevExpress.XtraPivotGrid.PivotGridField();
            this.UiCol_MATERIAL_COST = new DevExpress.XtraPivotGrid.PivotGridField();
            this.UiCol_WAREHOUSE_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            this.UiCol_QUANTITY_ASSIGNED = new DevExpress.XtraPivotGrid.PivotGridField();
            this.UiCol_ASSIGNED_TO = new DevExpress.XtraPivotGrid.PivotGridField();
            this.UiCol_ASSIGNED_TO_NAME = new DevExpress.XtraPivotGrid.PivotGridField();
            this.UiCol_ASSIGNED_DATE = new DevExpress.XtraPivotGrid.PivotGridField();
            this.UiCol_ACCEPTED_DATE = new DevExpress.XtraPivotGrid.PivotGridField();
            this.UiCol_COMPLETED_DATE = new DevExpress.XtraPivotGrid.PivotGridField();
            this.UiCol_ACCEPTED_CREATED_INTERVAL = new DevExpress.XtraPivotGrid.PivotGridField();
            this.UiCol_ACCEPTED_CREATED_INTERVAL_MINUTES = new DevExpress.XtraPivotGrid.PivotGridField();
            this.UiCol_PICKING_TIME = new DevExpress.XtraPivotGrid.PivotGridField();
            this.UiCol_PICKING_TIME_MINUTES = new DevExpress.XtraPivotGrid.PivotGridField();
            this.UiCol_TOTAL_TIME_PICKING = new DevExpress.XtraPivotGrid.PivotGridField();
            this.UiCol_TOTAL_TIME_PICKING_MINUTES = new DevExpress.XtraPivotGrid.PivotGridField();
            this.UiCol_TOTAL_TIME_FROM_TASK_ASSIGNED = new DevExpress.XtraPivotGrid.PivotGridField();
            this.UiCol_TOTAL_TIME_FROM_TASK_ASSIGNED_MINUTES = new DevExpress.XtraPivotGrid.PivotGridField();
            this.UiCol_TASK_ORDER = new DevExpress.XtraPivotGrid.PivotGridField();
            this.UiDialogoParaGuardar = new System.Windows.Forms.SaveFileDialog();
            this.UiDetallePicking = new DevExpress.XtraGrid.GridControl();
            this.UiViewDetallePicking = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.UiColView_WAVE_PICKING_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UiColView_DOC_NUM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UiColView_CREATED_BY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UiColView_CREATED_BY_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UiColView_MATERIAL_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UiColView_MATERIAL_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UiColView_MATERIAL_COST = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UiColView_WAREHOUSE_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UiColView_QUANTITY_ASSIGNED = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UiColView_ASSIGNED_TO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UiColView_ASSIGNED_TO_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UiColView_ASSIGNED_DATE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UiColView_ACCEPTED_DATE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UiColView_COMPLETED_DATE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UiColView_ACCEPTED_CREATED_INTERVAL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UiColView_ACCEPTED_CREATED_INTERVAL_MINUTES = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UiColView_PICKING_TIME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UiColView_PICKING_TIME_MINUTES = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UiColView_TOTAL_TIME_PICKING = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UiColView_TOTAL_TIME_PICKING_MINUTES = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UiColView_TOTAL_TIME_FROM_TASK_ASSIGNED = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UiColView_TOTAL_TIME_FROM_TASK_ASSIGNED_MINUTES = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UiColView_TASK_ORDER = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiStartDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiStartDate.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiEndDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiEndDate.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboPivotGuardados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombreReportePivot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiPivotReportePicking)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiDetallePicking)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiViewDetallePicking)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.UiBotonRefrescar,
            this.UiBotonExportarPivotTable,
            this.UiBotonExportarData,
            this.UiBotonGuardarConfiguracionPivot,
            this.UiBotonGuardarComoNuevo,
            this.UiEditNombreArchivo,
            this.UiEditComboGuardados,
            this.UiFechaInicial,
            this.UiFechaFinal,
            this.UiBotonEliminarXmlPivot,
            this.barStaticItem1,
            this.barStaticItem2});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 15;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox1,
            this.txtNombreReportePivot,
            this.comboPivotGuardados,
            this.UiStartDate,
            this.UiEndDate});
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.UiFechaInicial),
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem2),
            new DevExpress.XtraBars.LinkPersistInfo(this.UiFechaFinal),
            new DevExpress.XtraBars.LinkPersistInfo(this.UiBotonRefrescar),
            new DevExpress.XtraBars.LinkPersistInfo(this.UiEditComboGuardados),
            new DevExpress.XtraBars.LinkPersistInfo(this.UiBotonExportarPivotTable),
            new DevExpress.XtraBars.LinkPersistInfo(this.UiBotonExportarData),
            new DevExpress.XtraBars.LinkPersistInfo(this.UiBotonGuardarConfiguracionPivot),
            new DevExpress.XtraBars.LinkPersistInfo(this.UiBotonGuardarComoNuevo),
            new DevExpress.XtraBars.LinkPersistInfo(this.UiEditNombreArchivo),
            new DevExpress.XtraBars.LinkPersistInfo(this.UiBotonEliminarXmlPivot)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Caption = "Fecha Inicial:";
            this.barStaticItem1.Id = 13;
            this.barStaticItem1.Name = "barStaticItem1";
            // 
            // UiFechaInicial
            // 
            this.UiFechaInicial.Edit = this.UiStartDate;
            this.UiFechaInicial.EditWidth = 100;
            this.UiFechaInicial.Id = 10;
            this.UiFechaInicial.Name = "UiFechaInicial";
            // 
            // UiStartDate
            // 
            this.UiStartDate.AutoHeight = false;
            this.UiStartDate.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.UiStartDate.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.UiStartDate.Name = "UiStartDate";
            this.UiStartDate.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // barStaticItem2
            // 
            this.barStaticItem2.Caption = "Fecha Final:";
            this.barStaticItem2.Id = 14;
            this.barStaticItem2.Name = "barStaticItem2";
            // 
            // UiFechaFinal
            // 
            this.UiFechaFinal.Edit = this.UiEndDate;
            this.UiFechaFinal.EditWidth = 100;
            this.UiFechaFinal.Id = 11;
            this.UiFechaFinal.Name = "UiFechaFinal";
            // 
            // UiEndDate
            // 
            this.UiEndDate.AutoHeight = false;
            this.UiEndDate.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.UiEndDate.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.UiEndDate.Name = "UiEndDate";
            this.UiEndDate.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // UiBotonRefrescar
            // 
            this.UiBotonRefrescar.Caption = "Refrescar";
            this.UiBotonRefrescar.Id = 0;
            this.UiBotonRefrescar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("UiBotonRefrescar.ImageOptions.Image")));
            this.UiBotonRefrescar.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("UiBotonRefrescar.ImageOptions.LargeImage")));
            this.UiBotonRefrescar.Name = "UiBotonRefrescar";
            this.UiBotonRefrescar.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.UiBotonRefrescar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.UiBotonRefrescar_ItemClick);
            // 
            // UiEditComboGuardados
            // 
            this.UiEditComboGuardados.Caption = "barEditItem2";
            this.UiEditComboGuardados.Edit = this.comboPivotGuardados;
            this.UiEditComboGuardados.EditWidth = 250;
            this.UiEditComboGuardados.Id = 9;
            this.UiEditComboGuardados.Name = "UiEditComboGuardados";
            this.UiEditComboGuardados.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // comboPivotGuardados
            // 
            this.comboPivotGuardados.AutoHeight = false;
            this.comboPivotGuardados.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboPivotGuardados.Name = "comboPivotGuardados";
            this.comboPivotGuardados.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // UiBotonExportarPivotTable
            // 
            this.UiBotonExportarPivotTable.Caption = "Exportar Pivot";
            this.UiBotonExportarPivotTable.Id = 2;
            this.UiBotonExportarPivotTable.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("UiBotonExportarPivotTable.ImageOptions.Image")));
            this.UiBotonExportarPivotTable.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("UiBotonExportarPivotTable.ImageOptions.LargeImage")));
            this.UiBotonExportarPivotTable.Name = "UiBotonExportarPivotTable";
            this.UiBotonExportarPivotTable.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.UiBotonExportarPivotTable.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.UiBotonExportarPivotTable.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.UiBotonExportarPivotTable_ItemClick);
            // 
            // UiBotonExportarData
            // 
            this.UiBotonExportarData.Caption = "Exportar Data";
            this.UiBotonExportarData.Id = 3;
            this.UiBotonExportarData.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("UiBotonExportarData.ImageOptions.Image")));
            this.UiBotonExportarData.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("UiBotonExportarData.ImageOptions.LargeImage")));
            this.UiBotonExportarData.Name = "UiBotonExportarData";
            this.UiBotonExportarData.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.UiBotonExportarData.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.UiBotonExportarData_ItemClick);
            // 
            // UiBotonGuardarConfiguracionPivot
            // 
            this.UiBotonGuardarConfiguracionPivot.Caption = "Guardar";
            this.UiBotonGuardarConfiguracionPivot.Id = 4;
            this.UiBotonGuardarConfiguracionPivot.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("UiBotonGuardarConfiguracionPivot.ImageOptions.Image")));
            this.UiBotonGuardarConfiguracionPivot.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("UiBotonGuardarConfiguracionPivot.ImageOptions.LargeImage")));
            this.UiBotonGuardarConfiguracionPivot.Name = "UiBotonGuardarConfiguracionPivot";
            this.UiBotonGuardarConfiguracionPivot.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.UiBotonGuardarConfiguracionPivot.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.UiBotonGuardarConfiguracionPivot.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.UiBotonGuardarConfiguracionPivot_ItemClick);
            // 
            // UiBotonGuardarComoNuevo
            // 
            this.UiBotonGuardarComoNuevo.Caption = "Guardar Como Nuevo";
            this.UiBotonGuardarComoNuevo.Id = 5;
            this.UiBotonGuardarComoNuevo.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("UiBotonGuardarComoNuevo.ImageOptions.Image")));
            this.UiBotonGuardarComoNuevo.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("UiBotonGuardarComoNuevo.ImageOptions.LargeImage")));
            this.UiBotonGuardarComoNuevo.Name = "UiBotonGuardarComoNuevo";
            this.UiBotonGuardarComoNuevo.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.UiBotonGuardarComoNuevo.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.UiBotonGuardarComoNuevo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.UiBotonGuardarComoNuevo_ItemClick);
            // 
            // UiEditNombreArchivo
            // 
            this.UiEditNombreArchivo.Edit = this.txtNombreReportePivot;
            this.UiEditNombreArchivo.EditWidth = 150;
            this.UiEditNombreArchivo.Id = 8;
            this.UiEditNombreArchivo.Name = "UiEditNombreArchivo";
            this.UiEditNombreArchivo.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // txtNombreReportePivot
            // 
            this.txtNombreReportePivot.AutoHeight = false;
            this.txtNombreReportePivot.Name = "txtNombreReportePivot";
            // 
            // UiBotonEliminarXmlPivot
            // 
            this.UiBotonEliminarXmlPivot.Caption = "Eliminar";
            this.UiBotonEliminarXmlPivot.Id = 12;
            this.UiBotonEliminarXmlPivot.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("UiBotonEliminarXmlPivot.ImageOptions.Image")));
            this.UiBotonEliminarXmlPivot.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("UiBotonEliminarXmlPivot.ImageOptions.LargeImage")));
            this.UiBotonEliminarXmlPivot.Name = "UiBotonEliminarXmlPivot";
            this.UiBotonEliminarXmlPivot.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.UiBotonEliminarXmlPivot.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.UiBotonEliminarXmlPivot.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.UiBotonEliminarXmlPivot_Click);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1626, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 639);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1626, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 615);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1626, 24);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 615);
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoComplete = false;
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            this.repositoryItemComboBox1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // UiPivotReportePicking
            // 
            this.UiPivotReportePicking.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
            this.UICol_WAVE_PICKING_ID,
            this.UiCol_DOC_NUM,
            this.UiCol_CREATED_BY,
            this.UiCol_CREATED_BY_NAME,
            this.UiCol_MATERIAL_ID,
            this.UiCol_MATERIAL_NAME,
            this.UiCol_MATERIAL_COST,
            this.UiCol_WAREHOUSE_ID,
            this.UiCol_QUANTITY_ASSIGNED,
            this.UiCol_ASSIGNED_TO,
            this.UiCol_ASSIGNED_TO_NAME,
            this.UiCol_ASSIGNED_DATE,
            this.UiCol_ACCEPTED_DATE,
            this.UiCol_COMPLETED_DATE,
            this.UiCol_ACCEPTED_CREATED_INTERVAL,
            this.UiCol_ACCEPTED_CREATED_INTERVAL_MINUTES,
            this.UiCol_PICKING_TIME,
            this.UiCol_PICKING_TIME_MINUTES,
            this.UiCol_TOTAL_TIME_PICKING,
            this.UiCol_TOTAL_TIME_PICKING_MINUTES,
            this.UiCol_TOTAL_TIME_FROM_TASK_ASSIGNED,
            this.UiCol_TOTAL_TIME_FROM_TASK_ASSIGNED_MINUTES,
            this.UiCol_TASK_ORDER});
            this.UiPivotReportePicking.Location = new System.Drawing.Point(1161, 372);
            this.UiPivotReportePicking.Name = "UiPivotReportePicking";
            this.UiPivotReportePicking.Size = new System.Drawing.Size(331, 222);
            this.UiPivotReportePicking.TabIndex = 4;
            this.UiPivotReportePicking.Visible = false;
            // 
            // UICol_WAVE_PICKING_ID
            // 
            this.UICol_WAVE_PICKING_ID.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.UICol_WAVE_PICKING_ID.AreaIndex = 0;
            this.UICol_WAVE_PICKING_ID.Caption = "Ola de Picking";
            this.UICol_WAVE_PICKING_ID.FieldName = "WAVE_PICKING_ID";
            this.UICol_WAVE_PICKING_ID.Name = "UICol_WAVE_PICKING_ID";
            // 
            // UiCol_DOC_NUM
            // 
            this.UiCol_DOC_NUM.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.UiCol_DOC_NUM.AreaIndex = 1;
            this.UiCol_DOC_NUM.Caption = "Pedido";
            this.UiCol_DOC_NUM.FieldName = "DOC_NUM";
            this.UiCol_DOC_NUM.Name = "UiCol_DOC_NUM";
            // 
            // UiCol_CREATED_BY
            // 
            this.UiCol_CREATED_BY.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.UiCol_CREATED_BY.AreaIndex = 2;
            this.UiCol_CREATED_BY.Caption = "Creado Por";
            this.UiCol_CREATED_BY.FieldName = "CREATED_BY";
            this.UiCol_CREATED_BY.Name = "UiCol_CREATED_BY";
            // 
            // UiCol_CREATED_BY_NAME
            // 
            this.UiCol_CREATED_BY_NAME.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.UiCol_CREATED_BY_NAME.AreaIndex = 3;
            this.UiCol_CREATED_BY_NAME.Caption = "Nombre Creado Por";
            this.UiCol_CREATED_BY_NAME.FieldName = "CREATED_BY_NAME";
            this.UiCol_CREATED_BY_NAME.Name = "UiCol_CREATED_BY_NAME";
            // 
            // UiCol_MATERIAL_ID
            // 
            this.UiCol_MATERIAL_ID.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.UiCol_MATERIAL_ID.AreaIndex = 4;
            this.UiCol_MATERIAL_ID.Caption = "Código Material";
            this.UiCol_MATERIAL_ID.FieldName = "MATERIAL_ID";
            this.UiCol_MATERIAL_ID.Name = "UiCol_MATERIAL_ID";
            // 
            // UiCol_MATERIAL_NAME
            // 
            this.UiCol_MATERIAL_NAME.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.UiCol_MATERIAL_NAME.AreaIndex = 5;
            this.UiCol_MATERIAL_NAME.Caption = "Nombre Material";
            this.UiCol_MATERIAL_NAME.FieldName = "MATERIAL_NAME";
            this.UiCol_MATERIAL_NAME.Name = "UiCol_MATERIAL_NAME";
            // 
            // UiCol_MATERIAL_COST
            // 
            this.UiCol_MATERIAL_COST.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.UiCol_MATERIAL_COST.AreaIndex = 6;
            this.UiCol_MATERIAL_COST.Caption = "Costo Material";
            this.UiCol_MATERIAL_COST.FieldName = "MATERIAL_COST";
            this.UiCol_MATERIAL_COST.Name = "UiCol_MATERIAL_COST";
            // 
            // UiCol_WAREHOUSE_ID
            // 
            this.UiCol_WAREHOUSE_ID.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.UiCol_WAREHOUSE_ID.AreaIndex = 7;
            this.UiCol_WAREHOUSE_ID.Caption = "Bodega";
            this.UiCol_WAREHOUSE_ID.FieldName = "WAREHOUSE_ID";
            this.UiCol_WAREHOUSE_ID.Name = "UiCol_WAREHOUSE_ID";
            // 
            // UiCol_QUANTITY_ASSIGNED
            // 
            this.UiCol_QUANTITY_ASSIGNED.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.UiCol_QUANTITY_ASSIGNED.AreaIndex = 8;
            this.UiCol_QUANTITY_ASSIGNED.Caption = "Cantidad Asignada";
            this.UiCol_QUANTITY_ASSIGNED.FieldName = "QUANTITY_ASSIGNED";
            this.UiCol_QUANTITY_ASSIGNED.Name = "UiCol_QUANTITY_ASSIGNED";
            // 
            // UiCol_ASSIGNED_TO
            // 
            this.UiCol_ASSIGNED_TO.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.UiCol_ASSIGNED_TO.AreaIndex = 9;
            this.UiCol_ASSIGNED_TO.Caption = "Asignado A";
            this.UiCol_ASSIGNED_TO.FieldName = "ASSIGNED_TO";
            this.UiCol_ASSIGNED_TO.Name = "UiCol_ASSIGNED_TO";
            // 
            // UiCol_ASSIGNED_TO_NAME
            // 
            this.UiCol_ASSIGNED_TO_NAME.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.UiCol_ASSIGNED_TO_NAME.AreaIndex = 10;
            this.UiCol_ASSIGNED_TO_NAME.Caption = "Nombre Asignado A";
            this.UiCol_ASSIGNED_TO_NAME.FieldName = "ASSIGNED_TO_NAME";
            this.UiCol_ASSIGNED_TO_NAME.Name = "UiCol_ASSIGNED_TO_NAME";
            // 
            // UiCol_ASSIGNED_DATE
            // 
            this.UiCol_ASSIGNED_DATE.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.UiCol_ASSIGNED_DATE.AreaIndex = 11;
            this.UiCol_ASSIGNED_DATE.Caption = "Fecha de Asignación";
            this.UiCol_ASSIGNED_DATE.FieldName = "ASSIGNED_DATE";
            this.UiCol_ASSIGNED_DATE.Name = "UiCol_ASSIGNED_DATE";
            // 
            // UiCol_ACCEPTED_DATE
            // 
            this.UiCol_ACCEPTED_DATE.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.UiCol_ACCEPTED_DATE.AreaIndex = 12;
            this.UiCol_ACCEPTED_DATE.Caption = "Fecha de Aceptación";
            this.UiCol_ACCEPTED_DATE.FieldName = "ACCEPTED_DATE";
            this.UiCol_ACCEPTED_DATE.Name = "UiCol_ACCEPTED_DATE";
            // 
            // UiCol_COMPLETED_DATE
            // 
            this.UiCol_COMPLETED_DATE.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.UiCol_COMPLETED_DATE.AreaIndex = 13;
            this.UiCol_COMPLETED_DATE.Caption = "Fecha de completación Picking";
            this.UiCol_COMPLETED_DATE.FieldName = "COMPLETED_DATE";
            this.UiCol_COMPLETED_DATE.Name = "UiCol_COMPLETED_DATE";
            // 
            // UiCol_ACCEPTED_CREATED_INTERVAL
            // 
            this.UiCol_ACCEPTED_CREATED_INTERVAL.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.UiCol_ACCEPTED_CREATED_INTERVAL.AreaIndex = 14;
            this.UiCol_ACCEPTED_CREATED_INTERVAL.Caption = "Intervalo Creación Aceptación";
            this.UiCol_ACCEPTED_CREATED_INTERVAL.FieldName = "ACCEPTED_CREATED_INTERVAL";
            this.UiCol_ACCEPTED_CREATED_INTERVAL.Name = "UiCol_ACCEPTED_CREATED_INTERVAL";
            // 
            // UiCol_ACCEPTED_CREATED_INTERVAL_MINUTES
            // 
            this.UiCol_ACCEPTED_CREATED_INTERVAL_MINUTES.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.UiCol_ACCEPTED_CREATED_INTERVAL_MINUTES.AreaIndex = 15;
            this.UiCol_ACCEPTED_CREATED_INTERVAL_MINUTES.Caption = "Intervalo Creación Aceptación(Minutos)";
            this.UiCol_ACCEPTED_CREATED_INTERVAL_MINUTES.FieldName = "ACCEPTED_CREATED_INTERVAL_MINUTES";
            this.UiCol_ACCEPTED_CREATED_INTERVAL_MINUTES.Name = "UiCol_ACCEPTED_CREATED_INTERVAL_MINUTES";
            // 
            // UiCol_PICKING_TIME
            // 
            this.UiCol_PICKING_TIME.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.UiCol_PICKING_TIME.AreaIndex = 16;
            this.UiCol_PICKING_TIME.Caption = "Tiempo Picking";
            this.UiCol_PICKING_TIME.FieldName = "PICKING_TIME";
            this.UiCol_PICKING_TIME.Name = "UiCol_PICKING_TIME";
            // 
            // UiCol_PICKING_TIME_MINUTES
            // 
            this.UiCol_PICKING_TIME_MINUTES.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.UiCol_PICKING_TIME_MINUTES.AreaIndex = 17;
            this.UiCol_PICKING_TIME_MINUTES.Caption = "Tiempo Picking(Minutos)";
            this.UiCol_PICKING_TIME_MINUTES.FieldName = "PICKING_TIME_MINUTES";
            this.UiCol_PICKING_TIME_MINUTES.Name = "UiCol_PICKING_TIME_MINUTES";
            // 
            // UiCol_TOTAL_TIME_PICKING
            // 
            this.UiCol_TOTAL_TIME_PICKING.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.UiCol_TOTAL_TIME_PICKING.AreaIndex = 18;
            this.UiCol_TOTAL_TIME_PICKING.Caption = "Tiempo Total Picking";
            this.UiCol_TOTAL_TIME_PICKING.FieldName = "TOTAL_TIME_PICKING";
            this.UiCol_TOTAL_TIME_PICKING.Name = "UiCol_TOTAL_TIME_PICKING";
            // 
            // UiCol_TOTAL_TIME_PICKING_MINUTES
            // 
            this.UiCol_TOTAL_TIME_PICKING_MINUTES.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.UiCol_TOTAL_TIME_PICKING_MINUTES.AreaIndex = 19;
            this.UiCol_TOTAL_TIME_PICKING_MINUTES.Caption = "Tiempo Total Picking(Minutos)";
            this.UiCol_TOTAL_TIME_PICKING_MINUTES.FieldName = "TOTAL_TIME_PICKING_MINUTES";
            this.UiCol_TOTAL_TIME_PICKING_MINUTES.Name = "UiCol_TOTAL_TIME_PICKING_MINUTES";
            // 
            // UiCol_TOTAL_TIME_FROM_TASK_ASSIGNED
            // 
            this.UiCol_TOTAL_TIME_FROM_TASK_ASSIGNED.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.UiCol_TOTAL_TIME_FROM_TASK_ASSIGNED.AreaIndex = 20;
            this.UiCol_TOTAL_TIME_FROM_TASK_ASSIGNED.Caption = "Tiempo Total desde asignación";
            this.UiCol_TOTAL_TIME_FROM_TASK_ASSIGNED.FieldName = "TOTAL_TIME_FROM_TASK_ASSIGNED";
            this.UiCol_TOTAL_TIME_FROM_TASK_ASSIGNED.Name = "UiCol_TOTAL_TIME_FROM_TASK_ASSIGNED";
            // 
            // UiCol_TOTAL_TIME_FROM_TASK_ASSIGNED_MINUTES
            // 
            this.UiCol_TOTAL_TIME_FROM_TASK_ASSIGNED_MINUTES.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.UiCol_TOTAL_TIME_FROM_TASK_ASSIGNED_MINUTES.AreaIndex = 21;
            this.UiCol_TOTAL_TIME_FROM_TASK_ASSIGNED_MINUTES.Caption = "Tiempo Total desde asignación(Minutos)";
            this.UiCol_TOTAL_TIME_FROM_TASK_ASSIGNED_MINUTES.FieldName = "TOTAL_TIME_FROM_TASK_ASSIGNED_MINUTES";
            this.UiCol_TOTAL_TIME_FROM_TASK_ASSIGNED_MINUTES.Name = "UiCol_TOTAL_TIME_FROM_TASK_ASSIGNED_MINUTES";
            // 
            // UiCol_TASK_ORDER
            // 
            this.UiCol_TASK_ORDER.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.UiCol_TASK_ORDER.AreaIndex = 22;
            this.UiCol_TASK_ORDER.Caption = "Orden Tarea";
            this.UiCol_TASK_ORDER.FieldName = "TASK_ORDER";
            this.UiCol_TASK_ORDER.Name = "UiCol_TASK_ORDER";
            // 
            // UiDetallePicking
            // 
            this.UiDetallePicking.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UiDetallePicking.Location = new System.Drawing.Point(0, 24);
            this.UiDetallePicking.MainView = this.UiViewDetallePicking;
            this.UiDetallePicking.MenuManager = this.barManager1;
            this.UiDetallePicking.Name = "UiDetallePicking";
            this.UiDetallePicking.Size = new System.Drawing.Size(1626, 615);
            this.UiDetallePicking.TabIndex = 9;
            this.UiDetallePicking.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.UiViewDetallePicking});
            // 
            // UiViewDetallePicking
            // 
            this.UiViewDetallePicking.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.UiColView_WAVE_PICKING_ID,
            this.UiColView_DOC_NUM,
            this.UiColView_CREATED_BY,
            this.UiColView_CREATED_BY_NAME,
            this.UiColView_MATERIAL_ID,
            this.UiColView_MATERIAL_NAME,
            this.UiColView_MATERIAL_COST,
            this.UiColView_WAREHOUSE_NAME,
            this.UiColView_QUANTITY_ASSIGNED,
            this.UiColView_ASSIGNED_TO,
            this.UiColView_ASSIGNED_TO_NAME,
            this.UiColView_ASSIGNED_DATE,
            this.UiColView_ACCEPTED_DATE,
            this.UiColView_COMPLETED_DATE,
            this.UiColView_ACCEPTED_CREATED_INTERVAL,
            this.UiColView_ACCEPTED_CREATED_INTERVAL_MINUTES,
            this.UiColView_PICKING_TIME,
            this.UiColView_PICKING_TIME_MINUTES,
            this.UiColView_TOTAL_TIME_PICKING,
            this.UiColView_TOTAL_TIME_PICKING_MINUTES,
            this.UiColView_TOTAL_TIME_FROM_TASK_ASSIGNED,
            this.UiColView_TOTAL_TIME_FROM_TASK_ASSIGNED_MINUTES,
            this.UiColView_TASK_ORDER});
            this.UiViewDetallePicking.GridControl = this.UiDetallePicking;
            this.UiViewDetallePicking.Name = "UiViewDetallePicking";
            this.UiViewDetallePicking.OptionsView.ShowAutoFilterRow = true;
            this.UiViewDetallePicking.OptionsView.ShowChildrenInGroupPanel = true;
            // 
            // UiColView_WAVE_PICKING_ID
            // 
            this.UiColView_WAVE_PICKING_ID.Caption = "Ola de Picking";
            this.UiColView_WAVE_PICKING_ID.FieldName = "WAVE_PICKING_ID";
            this.UiColView_WAVE_PICKING_ID.Name = "UiColView_WAVE_PICKING_ID";
            this.UiColView_WAVE_PICKING_ID.OptionsColumn.AllowEdit = false;
            this.UiColView_WAVE_PICKING_ID.Visible = true;
            this.UiColView_WAVE_PICKING_ID.VisibleIndex = 0;
            // 
            // UiColView_DOC_NUM
            // 
            this.UiColView_DOC_NUM.Caption = "Pedido";
            this.UiColView_DOC_NUM.FieldName = "DOC_NUM";
            this.UiColView_DOC_NUM.Name = "UiColView_DOC_NUM";
            this.UiColView_DOC_NUM.OptionsColumn.AllowEdit = false;
            this.UiColView_DOC_NUM.Visible = true;
            this.UiColView_DOC_NUM.VisibleIndex = 1;
            // 
            // UiColView_CREATED_BY
            // 
            this.UiColView_CREATED_BY.Caption = "Creado por";
            this.UiColView_CREATED_BY.FieldName = "CREATED_BY";
            this.UiColView_CREATED_BY.Name = "UiColView_CREATED_BY";
            this.UiColView_CREATED_BY.OptionsColumn.AllowEdit = false;
            this.UiColView_CREATED_BY.Visible = true;
            this.UiColView_CREATED_BY.VisibleIndex = 2;
            // 
            // UiColView_CREATED_BY_NAME
            // 
            this.UiColView_CREATED_BY_NAME.Caption = "Nombre Creado por";
            this.UiColView_CREATED_BY_NAME.FieldName = "CREATED_BY_NAME";
            this.UiColView_CREATED_BY_NAME.Name = "UiColView_CREATED_BY_NAME";
            this.UiColView_CREATED_BY_NAME.OptionsColumn.AllowEdit = false;
            this.UiColView_CREATED_BY_NAME.Visible = true;
            this.UiColView_CREATED_BY_NAME.VisibleIndex = 3;
            // 
            // UiColView_MATERIAL_ID
            // 
            this.UiColView_MATERIAL_ID.Caption = "Código Material";
            this.UiColView_MATERIAL_ID.FieldName = "MATERIAL_ID";
            this.UiColView_MATERIAL_ID.Name = "UiColView_MATERIAL_ID";
            this.UiColView_MATERIAL_ID.OptionsColumn.AllowEdit = false;
            this.UiColView_MATERIAL_ID.Visible = true;
            this.UiColView_MATERIAL_ID.VisibleIndex = 4;
            // 
            // UiColView_MATERIAL_NAME
            // 
            this.UiColView_MATERIAL_NAME.Caption = "Nombre Material";
            this.UiColView_MATERIAL_NAME.FieldName = "MATERIAL_NAME";
            this.UiColView_MATERIAL_NAME.Name = "UiColView_MATERIAL_NAME";
            this.UiColView_MATERIAL_NAME.OptionsColumn.AllowEdit = false;
            this.UiColView_MATERIAL_NAME.Visible = true;
            this.UiColView_MATERIAL_NAME.VisibleIndex = 5;
            // 
            // UiColView_MATERIAL_COST
            // 
            this.UiColView_MATERIAL_COST.Caption = "Costo Material";
            this.UiColView_MATERIAL_COST.FieldName = "MATERIAL_COST";
            this.UiColView_MATERIAL_COST.Name = "UiColView_MATERIAL_COST";
            this.UiColView_MATERIAL_COST.OptionsColumn.AllowEdit = false;
            this.UiColView_MATERIAL_COST.Visible = true;
            this.UiColView_MATERIAL_COST.VisibleIndex = 6;
            // 
            // UiColView_WAREHOUSE_NAME
            // 
            this.UiColView_WAREHOUSE_NAME.Caption = "Bodega";
            this.UiColView_WAREHOUSE_NAME.FieldName = "WAREHOUSE_NAME";
            this.UiColView_WAREHOUSE_NAME.Name = "UiColView_WAREHOUSE_NAME";
            this.UiColView_WAREHOUSE_NAME.OptionsColumn.AllowEdit = false;
            this.UiColView_WAREHOUSE_NAME.Visible = true;
            this.UiColView_WAREHOUSE_NAME.VisibleIndex = 8;
            // 
            // UiColView_QUANTITY_ASSIGNED
            // 
            this.UiColView_QUANTITY_ASSIGNED.Caption = "Cantidad Asignada";
            this.UiColView_QUANTITY_ASSIGNED.FieldName = "QUANTITY_ASSIGNED";
            this.UiColView_QUANTITY_ASSIGNED.Name = "UiColView_QUANTITY_ASSIGNED";
            this.UiColView_QUANTITY_ASSIGNED.OptionsColumn.AllowEdit = false;
            this.UiColView_QUANTITY_ASSIGNED.Visible = true;
            this.UiColView_QUANTITY_ASSIGNED.VisibleIndex = 7;
            // 
            // UiColView_ASSIGNED_TO
            // 
            this.UiColView_ASSIGNED_TO.Caption = "Asignado A";
            this.UiColView_ASSIGNED_TO.FieldName = "ASSIGNED_TO";
            this.UiColView_ASSIGNED_TO.Name = "UiColView_ASSIGNED_TO";
            this.UiColView_ASSIGNED_TO.OptionsColumn.AllowEdit = false;
            this.UiColView_ASSIGNED_TO.Visible = true;
            this.UiColView_ASSIGNED_TO.VisibleIndex = 9;
            // 
            // UiColView_ASSIGNED_TO_NAME
            // 
            this.UiColView_ASSIGNED_TO_NAME.Caption = "Nombre Asignado A";
            this.UiColView_ASSIGNED_TO_NAME.FieldName = "ASSIGNED_TO_NAME";
            this.UiColView_ASSIGNED_TO_NAME.Name = "UiColView_ASSIGNED_TO_NAME";
            this.UiColView_ASSIGNED_TO_NAME.OptionsColumn.AllowEdit = false;
            this.UiColView_ASSIGNED_TO_NAME.Visible = true;
            this.UiColView_ASSIGNED_TO_NAME.VisibleIndex = 10;
            // 
            // UiColView_ASSIGNED_DATE
            // 
            this.UiColView_ASSIGNED_DATE.Caption = "Fecha de asignación";
            this.UiColView_ASSIGNED_DATE.FieldName = "ASSIGNED_DATE";
            this.UiColView_ASSIGNED_DATE.Name = "UiColView_ASSIGNED_DATE";
            this.UiColView_ASSIGNED_DATE.OptionsColumn.AllowEdit = false;
            this.UiColView_ASSIGNED_DATE.Visible = true;
            this.UiColView_ASSIGNED_DATE.VisibleIndex = 11;
            // 
            // UiColView_ACCEPTED_DATE
            // 
            this.UiColView_ACCEPTED_DATE.Caption = "Fecha de Aceptación";
            this.UiColView_ACCEPTED_DATE.FieldName = "ACCEPTED_DATE";
            this.UiColView_ACCEPTED_DATE.Name = "UiColView_ACCEPTED_DATE";
            this.UiColView_ACCEPTED_DATE.OptionsColumn.AllowEdit = false;
            this.UiColView_ACCEPTED_DATE.Visible = true;
            this.UiColView_ACCEPTED_DATE.VisibleIndex = 12;
            // 
            // UiColView_COMPLETED_DATE
            // 
            this.UiColView_COMPLETED_DATE.Caption = "Fecha de completación Picking";
            this.UiColView_COMPLETED_DATE.FieldName = "COMPLETED_DATE";
            this.UiColView_COMPLETED_DATE.Name = "UiColView_COMPLETED_DATE";
            this.UiColView_COMPLETED_DATE.OptionsColumn.AllowEdit = false;
            this.UiColView_COMPLETED_DATE.Visible = true;
            this.UiColView_COMPLETED_DATE.VisibleIndex = 13;
            // 
            // UiColView_ACCEPTED_CREATED_INTERVAL
            // 
            this.UiColView_ACCEPTED_CREATED_INTERVAL.Caption = "Intervalo Creación Aceptación";
            this.UiColView_ACCEPTED_CREATED_INTERVAL.FieldName = "ACCEPTED_CREATED_INTERVAL";
            this.UiColView_ACCEPTED_CREATED_INTERVAL.Name = "UiColView_ACCEPTED_CREATED_INTERVAL";
            this.UiColView_ACCEPTED_CREATED_INTERVAL.OptionsColumn.AllowEdit = false;
            this.UiColView_ACCEPTED_CREATED_INTERVAL.Visible = true;
            this.UiColView_ACCEPTED_CREATED_INTERVAL.VisibleIndex = 14;
            // 
            // UiColView_ACCEPTED_CREATED_INTERVAL_MINUTES
            // 
            this.UiColView_ACCEPTED_CREATED_INTERVAL_MINUTES.Caption = "Intervalo Creación Aceptación(Minutos)";
            this.UiColView_ACCEPTED_CREATED_INTERVAL_MINUTES.FieldName = "ACCEPTED_CREATED_INTERVAL_MINUTES";
            this.UiColView_ACCEPTED_CREATED_INTERVAL_MINUTES.Name = "UiColView_ACCEPTED_CREATED_INTERVAL_MINUTES";
            this.UiColView_ACCEPTED_CREATED_INTERVAL_MINUTES.OptionsColumn.AllowEdit = false;
            this.UiColView_ACCEPTED_CREATED_INTERVAL_MINUTES.Visible = true;
            this.UiColView_ACCEPTED_CREATED_INTERVAL_MINUTES.VisibleIndex = 15;
            // 
            // UiColView_PICKING_TIME
            // 
            this.UiColView_PICKING_TIME.Caption = "Tiempo Picking";
            this.UiColView_PICKING_TIME.FieldName = "PICKING_TIME";
            this.UiColView_PICKING_TIME.Name = "UiColView_PICKING_TIME";
            this.UiColView_PICKING_TIME.OptionsColumn.AllowEdit = false;
            this.UiColView_PICKING_TIME.Visible = true;
            this.UiColView_PICKING_TIME.VisibleIndex = 16;
            // 
            // UiColView_PICKING_TIME_MINUTES
            // 
            this.UiColView_PICKING_TIME_MINUTES.Caption = "Tiempo Picking(Minutos)";
            this.UiColView_PICKING_TIME_MINUTES.FieldName = "PICKING_TIME_MINUTES";
            this.UiColView_PICKING_TIME_MINUTES.Name = "UiColView_PICKING_TIME_MINUTES";
            this.UiColView_PICKING_TIME_MINUTES.OptionsColumn.AllowEdit = false;
            this.UiColView_PICKING_TIME_MINUTES.Visible = true;
            this.UiColView_PICKING_TIME_MINUTES.VisibleIndex = 17;
            // 
            // UiColView_TOTAL_TIME_PICKING
            // 
            this.UiColView_TOTAL_TIME_PICKING.Caption = "Tiempo Total Picking";
            this.UiColView_TOTAL_TIME_PICKING.FieldName = "TOTAL_TIME_PICKING";
            this.UiColView_TOTAL_TIME_PICKING.Name = "UiColView_TOTAL_TIME_PICKING";
            this.UiColView_TOTAL_TIME_PICKING.OptionsColumn.AllowEdit = false;
            this.UiColView_TOTAL_TIME_PICKING.Visible = true;
            this.UiColView_TOTAL_TIME_PICKING.VisibleIndex = 18;
            // 
            // UiColView_TOTAL_TIME_PICKING_MINUTES
            // 
            this.UiColView_TOTAL_TIME_PICKING_MINUTES.Caption = "Tiempo Total Picking(Minutos)";
            this.UiColView_TOTAL_TIME_PICKING_MINUTES.FieldName = "TOTAL_TIME_PICKING_MINUTES";
            this.UiColView_TOTAL_TIME_PICKING_MINUTES.Name = "UiColView_TOTAL_TIME_PICKING_MINUTES";
            this.UiColView_TOTAL_TIME_PICKING_MINUTES.OptionsColumn.AllowEdit = false;
            this.UiColView_TOTAL_TIME_PICKING_MINUTES.Visible = true;
            this.UiColView_TOTAL_TIME_PICKING_MINUTES.VisibleIndex = 19;
            // 
            // UiColView_TOTAL_TIME_FROM_TASK_ASSIGNED
            // 
            this.UiColView_TOTAL_TIME_FROM_TASK_ASSIGNED.Caption = "Tiempo Total desde asignación";
            this.UiColView_TOTAL_TIME_FROM_TASK_ASSIGNED.FieldName = "TOTAL_TIME_FROM_TASK_ASSIGNED";
            this.UiColView_TOTAL_TIME_FROM_TASK_ASSIGNED.Name = "UiColView_TOTAL_TIME_FROM_TASK_ASSIGNED";
            this.UiColView_TOTAL_TIME_FROM_TASK_ASSIGNED.OptionsColumn.AllowEdit = false;
            this.UiColView_TOTAL_TIME_FROM_TASK_ASSIGNED.Visible = true;
            this.UiColView_TOTAL_TIME_FROM_TASK_ASSIGNED.VisibleIndex = 20;
            // 
            // UiColView_TOTAL_TIME_FROM_TASK_ASSIGNED_MINUTES
            // 
            this.UiColView_TOTAL_TIME_FROM_TASK_ASSIGNED_MINUTES.Caption = "Tiempo Total desde asignación(Minutos)";
            this.UiColView_TOTAL_TIME_FROM_TASK_ASSIGNED_MINUTES.FieldName = "TOTAL_TIME_FROM_TASK_ASSIGNED_MINUTES";
            this.UiColView_TOTAL_TIME_FROM_TASK_ASSIGNED_MINUTES.Name = "UiColView_TOTAL_TIME_FROM_TASK_ASSIGNED_MINUTES";
            this.UiColView_TOTAL_TIME_FROM_TASK_ASSIGNED_MINUTES.OptionsColumn.AllowEdit = false;
            this.UiColView_TOTAL_TIME_FROM_TASK_ASSIGNED_MINUTES.Visible = true;
            this.UiColView_TOTAL_TIME_FROM_TASK_ASSIGNED_MINUTES.VisibleIndex = 21;
            // 
            // UiColView_TASK_ORDER
            // 
            this.UiColView_TASK_ORDER.Caption = "Orden Tarea";
            this.UiColView_TASK_ORDER.FieldName = "TASK_ORDER";
            this.UiColView_TASK_ORDER.Name = "UiColView_TASK_ORDER";
            this.UiColView_TASK_ORDER.OptionsColumn.AllowEdit = false;
            this.UiColView_TASK_ORDER.Visible = true;
            this.UiColView_TASK_ORDER.VisibleIndex = 22;
            // 
            // ReportePickingVista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1626, 639);
            this.Controls.Add(this.UiDetallePicking);
            this.Controls.Add(this.UiPivotReportePicking);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ReportePickingVista";
            this.Text = "Reporte Picking";
            this.Load += new System.EventHandler(this.ReportePickingVista_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiStartDate.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiStartDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiEndDate.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiEndDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboPivotGuardados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombreReportePivot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiPivotReportePicking)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiDetallePicking)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiViewDetallePicking)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem UiBotonRefrescar;
        private DevExpress.XtraPivotGrid.PivotGridControl UiPivotReportePicking;
        private DevExpress.XtraBars.BarButtonItem UiBotonExportarPivotTable;
        private DevExpress.XtraBars.BarButtonItem UiBotonExportarData;
        private DevExpress.XtraBars.BarButtonItem UiBotonGuardarConfiguracionPivot;
        private DevExpress.XtraBars.BarButtonItem UiBotonGuardarComoNuevo;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraBars.BarEditItem UiEditComboGuardados;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox comboPivotGuardados;
        private DevExpress.XtraBars.BarEditItem UiEditNombreArchivo;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit txtNombreReportePivot;
        private DevExpress.XtraBars.BarEditItem UiFechaInicial;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit UiStartDate;
        private DevExpress.XtraBars.BarEditItem UiFechaFinal;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit UiEndDate;
        private DevExpress.XtraPivotGrid.PivotGridField UICol_WAVE_PICKING_ID;
        private DevExpress.XtraPivotGrid.PivotGridField UiCol_DOC_NUM;
        private DevExpress.XtraPivotGrid.PivotGridField UiCol_CREATED_BY;
        private DevExpress.XtraPivotGrid.PivotGridField UiCol_CREATED_BY_NAME;
        private DevExpress.XtraPivotGrid.PivotGridField UiCol_MATERIAL_ID;
        private DevExpress.XtraPivotGrid.PivotGridField UiCol_MATERIAL_NAME;
        private DevExpress.XtraPivotGrid.PivotGridField UiCol_MATERIAL_COST;
        private DevExpress.XtraPivotGrid.PivotGridField UiCol_WAREHOUSE_ID;
        private DevExpress.XtraPivotGrid.PivotGridField UiCol_QUANTITY_ASSIGNED;
        private DevExpress.XtraPivotGrid.PivotGridField UiCol_ASSIGNED_TO;
        private DevExpress.XtraPivotGrid.PivotGridField UiCol_ASSIGNED_TO_NAME;
        private DevExpress.XtraPivotGrid.PivotGridField UiCol_ASSIGNED_DATE;
        private DevExpress.XtraPivotGrid.PivotGridField UiCol_ACCEPTED_DATE;
        private DevExpress.XtraPivotGrid.PivotGridField UiCol_COMPLETED_DATE;
        private DevExpress.XtraPivotGrid.PivotGridField UiCol_ACCEPTED_CREATED_INTERVAL;
        private DevExpress.XtraPivotGrid.PivotGridField UiCol_ACCEPTED_CREATED_INTERVAL_MINUTES;
        private DevExpress.XtraPivotGrid.PivotGridField UiCol_PICKING_TIME;
        private DevExpress.XtraPivotGrid.PivotGridField UiCol_PICKING_TIME_MINUTES;
        private DevExpress.XtraPivotGrid.PivotGridField UiCol_TOTAL_TIME_PICKING;
        private DevExpress.XtraPivotGrid.PivotGridField UiCol_TOTAL_TIME_PICKING_MINUTES;
        private DevExpress.XtraPivotGrid.PivotGridField UiCol_TOTAL_TIME_FROM_TASK_ASSIGNED;
        private DevExpress.XtraPivotGrid.PivotGridField UiCol_TOTAL_TIME_FROM_TASK_ASSIGNED_MINUTES;
        private DevExpress.XtraPivotGrid.PivotGridField UiCol_TASK_ORDER;
        private System.Windows.Forms.SaveFileDialog UiDialogoParaGuardar;
        private DevExpress.XtraGrid.GridControl UiDetallePicking;
        private DevExpress.XtraGrid.Views.Grid.GridView UiViewDetallePicking;
        private DevExpress.XtraGrid.Columns.GridColumn UiColView_WAVE_PICKING_ID;
        private DevExpress.XtraGrid.Columns.GridColumn UiColView_DOC_NUM;
        private DevExpress.XtraGrid.Columns.GridColumn UiColView_CREATED_BY;
        private DevExpress.XtraGrid.Columns.GridColumn UiColView_CREATED_BY_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn UiColView_MATERIAL_ID;
        private DevExpress.XtraGrid.Columns.GridColumn UiColView_MATERIAL_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn UiColView_MATERIAL_COST;
        private DevExpress.XtraGrid.Columns.GridColumn UiColView_WAREHOUSE_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn UiColView_QUANTITY_ASSIGNED;
        private DevExpress.XtraGrid.Columns.GridColumn UiColView_ASSIGNED_TO;
        private DevExpress.XtraGrid.Columns.GridColumn UiColView_ASSIGNED_TO_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn UiColView_ASSIGNED_DATE;
        private DevExpress.XtraGrid.Columns.GridColumn UiColView_ACCEPTED_DATE;
        private DevExpress.XtraGrid.Columns.GridColumn UiColView_COMPLETED_DATE;
        private DevExpress.XtraGrid.Columns.GridColumn UiColView_ACCEPTED_CREATED_INTERVAL;
        private DevExpress.XtraGrid.Columns.GridColumn UiColView_ACCEPTED_CREATED_INTERVAL_MINUTES;
        private DevExpress.XtraGrid.Columns.GridColumn UiColView_PICKING_TIME;
        private DevExpress.XtraGrid.Columns.GridColumn UiColView_PICKING_TIME_MINUTES;
        private DevExpress.XtraGrid.Columns.GridColumn UiColView_TOTAL_TIME_PICKING;
        private DevExpress.XtraGrid.Columns.GridColumn UiColView_TOTAL_TIME_PICKING_MINUTES;
        private DevExpress.XtraGrid.Columns.GridColumn UiColView_TOTAL_TIME_FROM_TASK_ASSIGNED;
        private DevExpress.XtraGrid.Columns.GridColumn UiColView_TOTAL_TIME_FROM_TASK_ASSIGNED_MINUTES;
        private DevExpress.XtraGrid.Columns.GridColumn UiColView_TASK_ORDER;
        private DevExpress.XtraBars.BarButtonItem UiBotonEliminarXmlPivot;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarStaticItem barStaticItem2;
    }
}