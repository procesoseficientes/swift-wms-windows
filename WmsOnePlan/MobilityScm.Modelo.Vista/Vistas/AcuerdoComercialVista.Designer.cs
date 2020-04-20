namespace MobilityScm.Modelo.Vistas
{
    partial class AcuerdoComercialVista
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AcuerdoComercialVista));
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression1 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.STATUS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.UiMenuAcuerdoComercialVista = new DevExpress.XtraBars.Bar();
            this.UiBtnGenerarReporteExcel = new DevExpress.XtraBars.BarButtonItem();
            this.UiBtnImprimirReporte = new DevExpress.XtraBars.BarButtonItem();
            this.UiBtnRefrescarVistaPrincipal = new DevExpress.XtraBars.BarButtonItem();
            this.UiFechaInicio = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.UiFechaFinal = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemDateEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.UiVistaInventarioPorAcuerdoComercial = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.CLIENT_CODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CLIENT_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ACUERDO_COMERCIAL_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ACUERDO_COMERCIAL_NOMBRE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.REGIMEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.VALID_FROM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.VALID_TO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.INVENTORY_QTY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.VALOR_TOTAL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UiEtiquetaListaCliente = new DevExpress.XtraEditors.LabelControl();
            this.UiListaDeCliente = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiVistaInventarioPorAcuerdoComercial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiListaDeCliente.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            this.SuspendLayout();
            // 
            // STATUS
            // 
            this.STATUS.Caption = "Estado";
            this.STATUS.FieldName = "STATUS";
            this.STATUS.Name = "STATUS";
            this.STATUS.OptionsColumn.AllowEdit = false;
            this.STATUS.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals;
            this.STATUS.Visible = true;
            this.STATUS.VisibleIndex = 7;
            this.STATUS.Width = 41;
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.UiMenuAcuerdoComercialVista});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.UiBtnGenerarReporteExcel,
            this.UiBtnImprimirReporte,
            this.UiBtnRefrescarVistaPrincipal,
            this.UiFechaInicio,
            this.UiFechaFinal});
            this.barManager1.MaxItemId = 9;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemDateEdit1,
            this.repositoryItemTextEdit1,
            this.repositoryItemDateEdit2});
            // 
            // UiMenuAcuerdoComercialVista
            // 
            this.UiMenuAcuerdoComercialVista.BarName = "Tools";
            this.UiMenuAcuerdoComercialVista.DockCol = 0;
            this.UiMenuAcuerdoComercialVista.DockRow = 0;
            this.UiMenuAcuerdoComercialVista.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.UiMenuAcuerdoComercialVista.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.UiBtnGenerarReporteExcel, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.UiBtnImprimirReporte, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.UiBtnRefrescarVistaPrincipal, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.UiFechaInicio, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.UiFechaFinal, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.UiMenuAcuerdoComercialVista.OptionsBar.AllowQuickCustomization = false;
            this.UiMenuAcuerdoComercialVista.OptionsBar.DrawDragBorder = false;
            this.UiMenuAcuerdoComercialVista.OptionsBar.UseWholeRow = true;
            this.UiMenuAcuerdoComercialVista.Text = "Tools";
            // 
            // UiBtnGenerarReporteExcel
            // 
            this.UiBtnGenerarReporteExcel.Caption = "Excel";
            this.UiBtnGenerarReporteExcel.Glyph = ((System.Drawing.Image)(resources.GetObject("UiBtnGenerarReporteExcel.Glyph")));
            this.UiBtnGenerarReporteExcel.Id = 0;
            this.UiBtnGenerarReporteExcel.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("UiBtnGenerarReporteExcel.LargeGlyph")));
            this.UiBtnGenerarReporteExcel.Name = "UiBtnGenerarReporteExcel";
            this.UiBtnGenerarReporteExcel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.UiBtnGenerarReporteExcel_ItemClick);
            // 
            // UiBtnImprimirReporte
            // 
            this.UiBtnImprimirReporte.Caption = "Imprimir";
            this.UiBtnImprimirReporte.Glyph = ((System.Drawing.Image)(resources.GetObject("UiBtnImprimirReporte.Glyph")));
            this.UiBtnImprimirReporte.Id = 1;
            this.UiBtnImprimirReporte.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("UiBtnImprimirReporte.LargeGlyph")));
            this.UiBtnImprimirReporte.Name = "UiBtnImprimirReporte";
            this.UiBtnImprimirReporte.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.UiBtnImprimirReporte_ItemClick);
            // 
            // UiBtnRefrescarVistaPrincipal
            // 
            this.UiBtnRefrescarVistaPrincipal.Caption = "Refrescar";
            this.UiBtnRefrescarVistaPrincipal.Glyph = ((System.Drawing.Image)(resources.GetObject("UiBtnRefrescarVistaPrincipal.Glyph")));
            this.UiBtnRefrescarVistaPrincipal.Id = 5;
            this.UiBtnRefrescarVistaPrincipal.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("UiBtnRefrescarVistaPrincipal.LargeGlyph")));
            this.UiBtnRefrescarVistaPrincipal.Name = "UiBtnRefrescarVistaPrincipal";
            this.UiBtnRefrescarVistaPrincipal.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.UiBtnRefrescarVistaPrincipal_ItemClick);
            // 
            // UiFechaInicio
            // 
            this.UiFechaInicio.Caption = "Fecha Inicio";
            this.UiFechaInicio.Edit = this.repositoryItemDateEdit1;
            this.UiFechaInicio.Glyph = ((System.Drawing.Image)(resources.GetObject("UiFechaInicio.Glyph")));
            this.UiFechaInicio.Id = 6;
            this.UiFechaInicio.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("UiFechaInicio.LargeGlyph")));
            this.UiFechaInicio.Name = "UiFechaInicio";
            this.UiFechaInicio.Size = new System.Drawing.Size(200, 0);
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
            this.UiFechaFinal.Id = 8;
            this.UiFechaFinal.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("UiFechaFinal.LargeGlyph")));
            this.UiFechaFinal.Name = "UiFechaFinal";
            this.UiFechaFinal.Size = new System.Drawing.Size(200, 0);
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
            this.barDockControlTop.Size = new System.Drawing.Size(1083, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 510);
            this.barDockControlBottom.Size = new System.Drawing.Size(1083, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 479);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1083, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 479);
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // UiVistaInventarioPorAcuerdoComercial
            // 
            this.UiVistaInventarioPorAcuerdoComercial.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UiVistaInventarioPorAcuerdoComercial.Location = new System.Drawing.Point(0, 53);
            this.UiVistaInventarioPorAcuerdoComercial.MainView = this.gridView1;
            this.UiVistaInventarioPorAcuerdoComercial.MenuManager = this.barManager1;
            this.UiVistaInventarioPorAcuerdoComercial.Name = "UiVistaInventarioPorAcuerdoComercial";
            this.UiVistaInventarioPorAcuerdoComercial.Size = new System.Drawing.Size(1083, 457);
            this.UiVistaInventarioPorAcuerdoComercial.TabIndex = 9;
            this.UiVistaInventarioPorAcuerdoComercial.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.CLIENT_CODE,
            this.CLIENT_NAME,
            this.ACUERDO_COMERCIAL_ID,
            this.ACUERDO_COMERCIAL_NOMBRE,
            this.REGIMEN,
            this.VALID_FROM,
            this.VALID_TO,
            this.STATUS,
            this.INVENTORY_QTY,
            this.VALOR_TOTAL});
            gridFormatRule1.ApplyToRow = true;
            gridFormatRule1.Column = this.STATUS;
            gridFormatRule1.Name = "EstadoDeAcuerdoComercial";
            formatConditionRuleExpression1.Expression = "[STATUS] = \'INACTIVO\'";
            formatConditionRuleExpression1.PredefinedName = "Red Fill";
            gridFormatRule1.Rule = formatConditionRuleExpression1;
            gridFormatRule1.Tag = "\"INACTIVO\"";
            this.gridView1.FormatRules.Add(gridFormatRule1);
            this.gridView1.GridControl = this.UiVistaInventarioPorAcuerdoComercial;
            this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "CLIENT_CODE", null, "(Registros: Count={0})"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "VALOR_TOTAL", null, "(Valor Total: SUM={0:0.##})")});
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowFooter = true;
            // 
            // CLIENT_CODE
            // 
            this.CLIENT_CODE.Caption = "Código Cliente";
            this.CLIENT_CODE.FieldName = "CLIENT_CODE";
            this.CLIENT_CODE.Name = "CLIENT_CODE";
            this.CLIENT_CODE.OptionsColumn.AllowEdit = false;
            this.CLIENT_CODE.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "CLIENT_CODE", "Registros: {0}")});
            this.CLIENT_CODE.Visible = true;
            this.CLIENT_CODE.VisibleIndex = 0;
            this.CLIENT_CODE.Width = 49;
            // 
            // CLIENT_NAME
            // 
            this.CLIENT_NAME.Caption = "Nombre Cliente";
            this.CLIENT_NAME.FieldName = "CLIENT_NAME";
            this.CLIENT_NAME.Name = "CLIENT_NAME";
            this.CLIENT_NAME.OptionsColumn.AllowEdit = false;
            this.CLIENT_NAME.Visible = true;
            this.CLIENT_NAME.VisibleIndex = 1;
            this.CLIENT_NAME.Width = 49;
            // 
            // ACUERDO_COMERCIAL_ID
            // 
            this.ACUERDO_COMERCIAL_ID.Caption = "No. Acuerdo Comercial";
            this.ACUERDO_COMERCIAL_ID.FieldName = "ACUERDO_COMERCIAL_ID";
            this.ACUERDO_COMERCIAL_ID.Name = "ACUERDO_COMERCIAL_ID";
            this.ACUERDO_COMERCIAL_ID.OptionsColumn.AllowEdit = false;
            this.ACUERDO_COMERCIAL_ID.Visible = true;
            this.ACUERDO_COMERCIAL_ID.VisibleIndex = 2;
            this.ACUERDO_COMERCIAL_ID.Width = 49;
            // 
            // ACUERDO_COMERCIAL_NOMBRE
            // 
            this.ACUERDO_COMERCIAL_NOMBRE.Caption = "Nombre Acuerdo Comercial";
            this.ACUERDO_COMERCIAL_NOMBRE.FieldName = "ACUERDO_COMERCIAL_NOMBRE";
            this.ACUERDO_COMERCIAL_NOMBRE.Name = "ACUERDO_COMERCIAL_NOMBRE";
            this.ACUERDO_COMERCIAL_NOMBRE.OptionsColumn.AllowEdit = false;
            this.ACUERDO_COMERCIAL_NOMBRE.Visible = true;
            this.ACUERDO_COMERCIAL_NOMBRE.VisibleIndex = 3;
            this.ACUERDO_COMERCIAL_NOMBRE.Width = 49;
            // 
            // REGIMEN
            // 
            this.REGIMEN.Caption = "Regimen";
            this.REGIMEN.FieldName = "REGIMEN";
            this.REGIMEN.Name = "REGIMEN";
            this.REGIMEN.OptionsColumn.AllowEdit = false;
            this.REGIMEN.Visible = true;
            this.REGIMEN.VisibleIndex = 4;
            this.REGIMEN.Width = 49;
            // 
            // VALID_FROM
            // 
            this.VALID_FROM.Caption = "Válido De";
            this.VALID_FROM.FieldName = "VALID_FROM";
            this.VALID_FROM.Name = "VALID_FROM";
            this.VALID_FROM.OptionsColumn.AllowEdit = false;
            this.VALID_FROM.Visible = true;
            this.VALID_FROM.VisibleIndex = 5;
            this.VALID_FROM.Width = 49;
            // 
            // VALID_TO
            // 
            this.VALID_TO.Caption = "Válido A";
            this.VALID_TO.FieldName = "VALID_TO";
            this.VALID_TO.Name = "VALID_TO";
            this.VALID_TO.OptionsColumn.AllowEdit = false;
            this.VALID_TO.Visible = true;
            this.VALID_TO.VisibleIndex = 6;
            this.VALID_TO.Width = 49;
            // 
            // INVENTORY_QTY
            // 
            this.INVENTORY_QTY.Caption = "Cantidad Inventario";
            this.INVENTORY_QTY.FieldName = "INVENTORY_QTY";
            this.INVENTORY_QTY.Name = "INVENTORY_QTY";
            this.INVENTORY_QTY.OptionsColumn.AllowEdit = false;
            this.INVENTORY_QTY.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "INVENTORY_QTY", "Inventario Total: {0}")});
            this.INVENTORY_QTY.Visible = true;
            this.INVENTORY_QTY.VisibleIndex = 8;
            this.INVENTORY_QTY.Width = 52;
            // 
            // VALOR_TOTAL
            // 
            this.VALOR_TOTAL.Caption = "Valor Total";
            this.VALOR_TOTAL.FieldName = "VALOR_TOTAL";
            this.VALOR_TOTAL.Name = "VALOR_TOTAL";
            this.VALOR_TOTAL.OptionsColumn.AllowEdit = false;
            this.VALOR_TOTAL.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "VALOR_TOTAL", "Valor Total Inventario: {0}")});
            this.VALOR_TOTAL.Visible = true;
            this.VALOR_TOTAL.VisibleIndex = 9;
            this.VALOR_TOTAL.Width = 59;
            // 
            // UiEtiquetaListaCliente
            // 
            this.UiEtiquetaListaCliente.Location = new System.Drawing.Point(3, 34);
            this.UiEtiquetaListaCliente.Name = "UiEtiquetaListaCliente";
            this.UiEtiquetaListaCliente.Size = new System.Drawing.Size(37, 13);
            this.UiEtiquetaListaCliente.TabIndex = 17;
            this.UiEtiquetaListaCliente.Text = "Cliente:";
            // 
            // UiListaDeCliente
            // 
            this.UiListaDeCliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UiListaDeCliente.EditValue = "";
            this.UiListaDeCliente.Location = new System.Drawing.Point(46, 31);
            this.UiListaDeCliente.Name = "UiListaDeCliente";
            serializableAppearanceObject1.Image = ((System.Drawing.Image)(resources.GetObject("serializableAppearanceObject1.Image")));
            serializableAppearanceObject1.Options.UseImage = true;
            this.UiListaDeCliente.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.OK, "", -1, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleLeft, ((System.Drawing.Image)(resources.GetObject("UiListaDeCliente.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", "REFRESH", null, true)});
            this.UiListaDeCliente.Properties.NullText = "...";
            this.UiListaDeCliente.Properties.ValueMember = "CLIENT_CODE";
            this.UiListaDeCliente.Properties.View = this.gridLookUpEdit1View;
            this.UiListaDeCliente.Properties.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(this.UiListaDeCliente_Properties_CloseUp);
            this.UiListaDeCliente.Properties.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.UiListaDeCliente_Properties_ButtonClick);
            this.UiListaDeCliente.Properties.CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(this.UiListaDeCliente_Properties_CustomDisplayText);
            this.UiListaDeCliente.Size = new System.Drawing.Size(1037, 20);
            this.UiListaDeCliente.TabIndex = 16;
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsSelection.MultiSelect = true;
            this.gridLookUpEdit1View.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridLookUpEdit1View.OptionsView.ShowAutoFilterRow = true;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Código";
            this.gridColumn1.FieldName = "CLIENT_CODE";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 100;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Nombre";
            this.gridColumn2.FieldName = "CLIENT_NAME";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 300;
            // 
            // AcuerdoComercialVista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1083, 510);
            this.Controls.Add(this.UiEtiquetaListaCliente);
            this.Controls.Add(this.UiListaDeCliente);
            this.Controls.Add(this.UiVistaInventarioPorAcuerdoComercial);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "AcuerdoComercialVista";
            this.Text = "AcuerdoComercialVista";
            this.Load += new System.EventHandler(this.AcuerdoComercialVista_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiVistaInventarioPorAcuerdoComercial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiListaDeCliente.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar UiMenuAcuerdoComercialVista;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem UiBtnGenerarReporteExcel;
        private DevExpress.XtraBars.BarButtonItem UiBtnImprimirReporte;
        private DevExpress.XtraBars.BarButtonItem UiBtnRefrescarVistaPrincipal;
        private DevExpress.XtraBars.BarEditItem UiFechaInicio;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraBars.BarEditItem UiFechaFinal;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraGrid.GridControl UiVistaInventarioPorAcuerdoComercial;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn CLIENT_CODE;
        private DevExpress.XtraGrid.Columns.GridColumn CLIENT_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn ACUERDO_COMERCIAL_ID;
        private DevExpress.XtraGrid.Columns.GridColumn ACUERDO_COMERCIAL_NOMBRE;
        private DevExpress.XtraGrid.Columns.GridColumn REGIMEN;
        private DevExpress.XtraGrid.Columns.GridColumn VALID_FROM;
        private DevExpress.XtraGrid.Columns.GridColumn VALID_TO;
        private DevExpress.XtraGrid.Columns.GridColumn STATUS;
        private DevExpress.XtraGrid.Columns.GridColumn INVENTORY_QTY;
        private DevExpress.XtraGrid.Columns.GridColumn VALOR_TOTAL;
        private DevExpress.XtraEditors.LabelControl UiEtiquetaListaCliente;
        private DevExpress.XtraEditors.GridLookUpEdit UiListaDeCliente;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
    }
}