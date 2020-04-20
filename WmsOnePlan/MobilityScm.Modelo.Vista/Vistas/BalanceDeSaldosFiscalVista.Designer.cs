namespace MobilityScm.Modelo.Vistas
{
    partial class BalanceDeSaldosFiscalVista
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BalanceDeSaldosFiscalVista));
            this.UiBarraManager = new DevExpress.XtraBars.BarManager();
            this.UiBarraPrincipal = new DevExpress.XtraBars.Bar();
            this.UiBotonExpadir = new DevExpress.XtraBars.BarButtonItem();
            this.UiBotonContraer = new DevExpress.XtraBars.BarButtonItem();
            this.UiBotonExportarExcel = new DevExpress.XtraBars.BarButtonItem();
            this.UiBotonImprimir = new DevExpress.XtraBars.BarButtonItem();
            this.UiBotonRefrescar = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.UiVistasBalance = new DevExpress.XtraGrid.GridControl();
            this.UiVistaBalanceDeSaldos = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.UiColNombreCliente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UiColNumeroDocumento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UiColCodigoPoliza = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UiColNumeroOrden = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UiColFechaDocumento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UiColDescripcionMaterial = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UiColLicencia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UiColCantidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UiColValorCif = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UiColImpuesto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UiCokRegimenDocumento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UiColGrupoRegimen = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.UiBarraManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiVistasBalance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiVistaBalanceDeSaldos)).BeginInit();
            this.SuspendLayout();
            // 
            // UiBarraManager
            // 
            this.UiBarraManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.UiBarraPrincipal});
            this.UiBarraManager.DockControls.Add(this.barDockControlTop);
            this.UiBarraManager.DockControls.Add(this.barDockControlBottom);
            this.UiBarraManager.DockControls.Add(this.barDockControlLeft);
            this.UiBarraManager.DockControls.Add(this.barDockControlRight);
            this.UiBarraManager.Form = this;
            this.UiBarraManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.UiBotonRefrescar,
            this.UiBotonExportarExcel,
            this.UiBotonImprimir,
            this.UiBotonExpadir,
            this.UiBotonContraer});
            this.UiBarraManager.MaxItemId = 5;
            // 
            // UiBarraPrincipal
            // 
            this.UiBarraPrincipal.BarName = "Tools";
            this.UiBarraPrincipal.DockCol = 0;
            this.UiBarraPrincipal.DockRow = 0;
            this.UiBarraPrincipal.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.UiBarraPrincipal.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.UiBotonExpadir, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.UiBotonContraer, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.UiBotonExportarExcel, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.UiBotonImprimir, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.UiBotonRefrescar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.UiBarraPrincipal.OptionsBar.AllowQuickCustomization = false;
            this.UiBarraPrincipal.OptionsBar.DrawDragBorder = false;
            this.UiBarraPrincipal.OptionsBar.UseWholeRow = true;
            this.UiBarraPrincipal.Text = "Tools";
            // 
            // UiBotonExpadir
            // 
            this.UiBotonExpadir.Caption = "Expandir";
            this.UiBotonExpadir.Glyph = ((System.Drawing.Image)(resources.GetObject("UiBotonExpadir.Glyph")));
            this.UiBotonExpadir.Id = 3;
            this.UiBotonExpadir.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("UiBotonExpadir.LargeGlyph")));
            this.UiBotonExpadir.Name = "UiBotonExpadir";
            this.UiBotonExpadir.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.UiBotonExpadir_ItemClick);
            // 
            // UiBotonContraer
            // 
            this.UiBotonContraer.Caption = "Contraer";
            this.UiBotonContraer.Glyph = ((System.Drawing.Image)(resources.GetObject("UiBotonContraer.Glyph")));
            this.UiBotonContraer.Id = 4;
            this.UiBotonContraer.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("UiBotonContraer.LargeGlyph")));
            this.UiBotonContraer.Name = "UiBotonContraer";
            this.UiBotonContraer.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.UiBotonContraer_ItemClick);
            // 
            // UiBotonExportarExcel
            // 
            this.UiBotonExportarExcel.Caption = "Exportar Excel";
            this.UiBotonExportarExcel.Glyph = ((System.Drawing.Image)(resources.GetObject("UiBotonExportarExcel.Glyph")));
            this.UiBotonExportarExcel.Id = 1;
            this.UiBotonExportarExcel.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("UiBotonExportarExcel.LargeGlyph")));
            this.UiBotonExportarExcel.Name = "UiBotonExportarExcel";
            this.UiBotonExportarExcel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.UiBotonExportarExcel_ItemClick);
            // 
            // UiBotonImprimir
            // 
            this.UiBotonImprimir.Caption = "Imprimir";
            this.UiBotonImprimir.Glyph = ((System.Drawing.Image)(resources.GetObject("UiBotonImprimir.Glyph")));
            this.UiBotonImprimir.Id = 2;
            this.UiBotonImprimir.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("UiBotonImprimir.LargeGlyph")));
            this.UiBotonImprimir.Name = "UiBotonImprimir";
            this.UiBotonImprimir.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.UiBotonImprimir_ItemClick);
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
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1028, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 588);
            this.barDockControlBottom.Size = new System.Drawing.Size(1028, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 557);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1028, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 557);
            // 
            // UiVistasBalance
            // 
            this.UiVistasBalance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UiVistasBalance.Location = new System.Drawing.Point(0, 31);
            this.UiVistasBalance.MainView = this.UiVistaBalanceDeSaldos;
            this.UiVistasBalance.MenuManager = this.UiBarraManager;
            this.UiVistasBalance.Name = "UiVistasBalance";
            this.UiVistasBalance.Size = new System.Drawing.Size(1028, 557);
            this.UiVistasBalance.TabIndex = 4;
            this.UiVistasBalance.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.UiVistaBalanceDeSaldos});
            // 
            // UiVistaBalanceDeSaldos
            // 
            this.UiVistaBalanceDeSaldos.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.UiColNombreCliente,
            this.UiColNumeroDocumento,
            this.UiColCodigoPoliza,
            this.UiColNumeroOrden,
            this.UiColFechaDocumento,
            this.UiColDescripcionMaterial,
            this.UiColLicencia,
            this.UiColCantidad,
            this.UiColValorCif,
            this.UiColImpuesto,
            this.UiCokRegimenDocumento,
            this.UiColGrupoRegimen});
            this.UiVistaBalanceDeSaldos.GridControl = this.UiVistasBalance;
            this.UiVistaBalanceDeSaldos.Name = "UiVistaBalanceDeSaldos";
            this.UiVistaBalanceDeSaldos.OptionsView.ShowAutoFilterRow = true;
            this.UiVistaBalanceDeSaldos.OptionsView.ShowFooter = true;
            // 
            // UiColNombreCliente
            // 
            this.UiColNombreCliente.Caption = "Nombre Cliente";
            this.UiColNombreCliente.FieldName = "CLIENT_NAME";
            this.UiColNombreCliente.Name = "UiColNombreCliente";
            this.UiColNombreCliente.OptionsColumn.AllowEdit = false;
            this.UiColNombreCliente.Visible = true;
            this.UiColNombreCliente.VisibleIndex = 0;
            // 
            // UiColNumeroDocumento
            // 
            this.UiColNumeroDocumento.Caption = "Numero Documento";
            this.UiColNumeroDocumento.FieldName = "DOC_ID";
            this.UiColNumeroDocumento.Name = "UiColNumeroDocumento";
            this.UiColNumeroDocumento.OptionsColumn.AllowEdit = false;
            this.UiColNumeroDocumento.Visible = true;
            this.UiColNumeroDocumento.VisibleIndex = 1;
            // 
            // UiColCodigoPoliza
            // 
            this.UiColCodigoPoliza.Caption = "Codigo Poliza";
            this.UiColCodigoPoliza.FieldName = "CODIGO_POLIZA";
            this.UiColCodigoPoliza.Name = "UiColCodigoPoliza";
            this.UiColCodigoPoliza.OptionsColumn.AllowEdit = false;
            this.UiColCodigoPoliza.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "CODIGO_POLIZA", "{0}")});
            this.UiColCodigoPoliza.Visible = true;
            this.UiColCodigoPoliza.VisibleIndex = 2;
            // 
            // UiColNumeroOrden
            // 
            this.UiColNumeroOrden.Caption = "Numero Orden";
            this.UiColNumeroOrden.FieldName = "NUMERO_ORDEN";
            this.UiColNumeroOrden.Name = "UiColNumeroOrden";
            this.UiColNumeroOrden.OptionsColumn.AllowEdit = false;
            this.UiColNumeroOrden.Visible = true;
            this.UiColNumeroOrden.VisibleIndex = 3;
            // 
            // UiColFechaDocumento
            // 
            this.UiColFechaDocumento.Caption = "Fecha";
            this.UiColFechaDocumento.FieldName = "FECHA_DOCUMENTO";
            this.UiColFechaDocumento.Name = "UiColFechaDocumento";
            this.UiColFechaDocumento.OptionsColumn.AllowEdit = false;
            this.UiColFechaDocumento.Visible = true;
            this.UiColFechaDocumento.VisibleIndex = 4;
            // 
            // UiColDescripcionMaterial
            // 
            this.UiColDescripcionMaterial.Caption = "Descripción Material";
            this.UiColDescripcionMaterial.FieldName = "MATERIAL_NAME";
            this.UiColDescripcionMaterial.Name = "UiColDescripcionMaterial";
            this.UiColDescripcionMaterial.OptionsColumn.AllowEdit = false;
            this.UiColDescripcionMaterial.Visible = true;
            this.UiColDescripcionMaterial.VisibleIndex = 5;
            // 
            // UiColLicencia
            // 
            this.UiColLicencia.Caption = "Licencia";
            this.UiColLicencia.FieldName = "LICENSE_ID";
            this.UiColLicencia.Name = "UiColLicencia";
            this.UiColLicencia.OptionsColumn.AllowEdit = false;
            this.UiColLicencia.Visible = true;
            this.UiColLicencia.VisibleIndex = 6;
            // 
            // UiColCantidad
            // 
            this.UiColCantidad.Caption = "Cantidad";
            this.UiColCantidad.FieldName = "BULTOS";
            this.UiColCantidad.Name = "UiColCantidad";
            this.UiColCantidad.OptionsColumn.AllowEdit = false;
            this.UiColCantidad.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "QTY", "{0:0.##}")});
            this.UiColCantidad.Visible = true;
            this.UiColCantidad.VisibleIndex = 7;
            // 
            // UiColValorCif
            // 
            this.UiColValorCif.Caption = "Valor Cif";
            this.UiColValorCif.FieldName = "VALOR_CIF";
            this.UiColValorCif.Name = "UiColValorCif";
            this.UiColValorCif.OptionsColumn.AllowEdit = false;
            this.UiColValorCif.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "VALOR_CIF", "{0:0.##}")});
            this.UiColValorCif.Visible = true;
            this.UiColValorCif.VisibleIndex = 8;
            // 
            // UiColImpuesto
            // 
            this.UiColImpuesto.Caption = "Impuesto";
            this.UiColImpuesto.FieldName = "IMPUESTO";
            this.UiColImpuesto.Name = "UiColImpuesto";
            this.UiColImpuesto.OptionsColumn.AllowEdit = false;
            this.UiColImpuesto.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "IMPUESTO", "{0:0.##}")});
            this.UiColImpuesto.Visible = true;
            this.UiColImpuesto.VisibleIndex = 9;
            // 
            // UiCokRegimenDocumento
            // 
            this.UiCokRegimenDocumento.Caption = "Regimen Documento";
            this.UiCokRegimenDocumento.FieldName = "REGIMEN_DOCUMENTO";
            this.UiCokRegimenDocumento.Name = "UiCokRegimenDocumento";
            this.UiCokRegimenDocumento.OptionsColumn.AllowEdit = false;
            this.UiCokRegimenDocumento.Visible = true;
            this.UiCokRegimenDocumento.VisibleIndex = 10;
            // 
            // UiColGrupoRegimen
            // 
            this.UiColGrupoRegimen.Caption = "Grupo Regimen";
            this.UiColGrupoRegimen.FieldName = "GRUPO_REGIMEN";
            this.UiColGrupoRegimen.Name = "UiColGrupoRegimen";
            this.UiColGrupoRegimen.OptionsColumn.AllowEdit = false;
            this.UiColGrupoRegimen.Visible = true;
            this.UiColGrupoRegimen.VisibleIndex = 11;
            // 
            // BalanceDeSaldosFiscalVista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 588);
            this.Controls.Add(this.UiVistasBalance);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "BalanceDeSaldosFiscalVista";
            this.Text = "Balance De Saldos Fiscal";
            this.Load += new System.EventHandler(this.BalanceDeSaldosFiscalVista_Load);
            ((System.ComponentModel.ISupportInitialize)(this.UiBarraManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiVistasBalance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UiVistaBalanceDeSaldos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager UiBarraManager;
        private DevExpress.XtraBars.Bar UiBarraPrincipal;
        private DevExpress.XtraBars.BarButtonItem UiBotonRefrescar;
        private DevExpress.XtraBars.BarButtonItem UiBotonExportarExcel;
        private DevExpress.XtraBars.BarButtonItem UiBotonImprimir;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraGrid.GridControl UiVistasBalance;
        private DevExpress.XtraGrid.Views.Grid.GridView UiVistaBalanceDeSaldos;
        private DevExpress.XtraGrid.Columns.GridColumn UiColNombreCliente;
        private DevExpress.XtraGrid.Columns.GridColumn UiColNumeroDocumento;
        private DevExpress.XtraGrid.Columns.GridColumn UiColCodigoPoliza;
        private DevExpress.XtraGrid.Columns.GridColumn UiColNumeroOrden;
        private DevExpress.XtraGrid.Columns.GridColumn UiColFechaDocumento;
        private DevExpress.XtraGrid.Columns.GridColumn UiColDescripcionMaterial;
        private DevExpress.XtraGrid.Columns.GridColumn UiColLicencia;
        private DevExpress.XtraGrid.Columns.GridColumn UiColCantidad;
        private DevExpress.XtraGrid.Columns.GridColumn UiColValorCif;
        private DevExpress.XtraGrid.Columns.GridColumn UiColImpuesto;
        private DevExpress.XtraGrid.Columns.GridColumn UiCokRegimenDocumento;
        private DevExpress.XtraGrid.Columns.GridColumn UiColGrupoRegimen;
        private DevExpress.XtraBars.BarButtonItem UiBotonExpadir;
        private DevExpress.XtraBars.BarButtonItem UiBotonContraer;
    }
}