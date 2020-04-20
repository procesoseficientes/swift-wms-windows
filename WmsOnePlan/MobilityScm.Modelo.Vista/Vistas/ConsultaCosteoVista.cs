using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraReports.UI;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Controladores;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Interfaces.Controladores;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Modelo.Servicios;
using MobilityScm.Utilerias;
using MobilityScm.Vertical.Servicios;

namespace MobilityScm.Modelo.Vistas
{
    public partial class ConsultaCosteoVista : VistaBase, IConsultaCosteoVista
    {

        public IInteraccionConUsuarioServicio InteraccionConUsuarioServicio { get; set; }
        public ConsultaCosteoVista()
        {
            InitializeComponent();
            InteraccionConUsuarioServicio = Mvx.Ioc.Resolve<IInteraccionConUsuarioServicio>();

            Mvx.Ioc.RegisterType<IConsultaCosteoServicio, ConsultaCosteoServicio>();
            Mvx.Ioc.RegisterType<IBodegaServicio, BodegaServicio>();


            Mvx.Ioc.RegisterType<IConsultaCosteoControlador, ConsultaCosteoControlador>();
            Mvx.Ioc.RegisterSingleton<IConsultaCosteoVista, ConsultaCosteoVista>(this);
            Mvx.Ioc.Resolve<IConsultaCosteoControlador>();


        }

        public event EventHandler<CosteoArgumento> UsuarioDeseaObtenerPolizasMaestroDetallePendientesDeAutorizar;
        public event EventHandler<CosteoArgumento> UsuarioDeseaAutorizarCosteoPoliza;
        public event EventHandler VistaCargandosePorPrimeraVez;
        public IList<PolizaMaestroDetalle> PolizasMaestroDetalle
        {
            get { return (IList<PolizaMaestroDetalle>)UiContenedorCosteos.DataSource; }
            set { UiContenedorCosteos.DataSource = value; }
        }
        public IList<Bodega> Bodegas
        {
            get { return (IList<Bodega>)UiListaBodega.Properties.DataSource; }
            set { UiListaBodega.Properties.DataSource = value; }
        }

        public string Usuario { get; set; }
        private bool UsuarioSeleccionoListaBodegaCompleta { get; set; }

        private bool UsuarioSeleccionoVistaCosteosCompleta { get; set; }

        public bool LineasAbiertas => UiSwitchLineasAbiertas.Checked;

        private void ConsultaCosteoVista_Load(object sender, EventArgs e)
        {
            UiFechaInicial.EditValue = DateTime.Today;
            UiFechaFinal.EditValue = DateTime.Today;
            VistaCargandosePorPrimeraVez?.Invoke(null, null);
            UiListaBodega.Properties.PopupFormWidth = UiListaBodega.Width - 10;
            CargarOGuardarDisenios(UiContenedorCosteos, false, Usuario, GetType().Name);
        }

        private void UiListaBodega_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            e.DisplayText = ObtenerTextoAMostrarListaBodega();
        }

        private void UiListaVistaBodega_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            for (var i = 0; i < UiListaVistaBodega.RowCount; i++)
            {
                var registro = (Bodega)UiListaVistaBodega.GetRow(i);
                if (registro == null) continue;
                if (registro.IS_SELECTED)
                {
                    UiListaVistaBodega.SelectRow(i);
                }
            }
        }

        private void UiListaVistaBodega_MouseUp(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null)
                return;
            GridHitInfo hi = view.CalcHitInfo(new System.Drawing.Point(e.X, e.Y));
            if ((hi.HitTest == GridHitTest.Column || hi.HitTest == GridHitTest.GroupPanelColumn) && hi.Column.Name.Equals("DX$CheckboxSelectorColumn"))
            {
                UsuarioSeleccionoListaBodegaCompleta = true;
            }

        }

        private void UiListaVistaBodega_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {

            if (e.ControllerRow >= 0)
            {
                var registro = (Bodega)UiListaVistaBodega.GetRow(e.ControllerRow);
                registro.IS_SELECTED = (e.Action == CollectionChangeAction.Add);
            }
            else
            {
                if (UsuarioSeleccionoListaBodegaCompleta)
                {
                    for (var i = 0; i < UiListaVistaBodega.RowCount; i++)
                    {
                        var registro = (Bodega)UiListaVistaBodega.GetRow(i);
                        if (registro == null) continue;
                        registro.IS_SELECTED = (UiListaVistaBodega.SelectedRowsCount != 0);
                    }
                    UsuarioSeleccionoListaBodegaCompleta = false;
                }
            }

            var edit = ActiveControl as DevExpress.XtraEditors.SearchLookUpEdit;
            if (edit == null) return;
            edit.Text = ObtenerTextoAMostrarListaBodega();
        }

        private string ObtenerTextoAMostrarListaBodega()
        {
            if (Bodegas == null) return "";
            var cadena = new StringBuilder();
            foreach (var documento in Bodegas.Where(doc => doc.IS_SELECTED))
            {
                if (cadena.Length > 0) { cadena.Append(","); }
                cadena.Append(documento.WAREHOUSE_ID + "|" + documento.NAME);
            }

            return cadena.ToString();
        }

        private void UiBotonRefrescar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CargarCosteos(sender);
        }

        private void CargarCosteos(object sender)
        {
            try
            {
                if (PrepararBodegas() != "")
                {
                    UsuarioDeseaObtenerPolizasMaestroDetallePendientesDeAutorizar?.Invoke(sender, new CosteoArgumento
                    {
                        FechaInicial = Convert.ToDateTime(UiFechaInicial.EditValue)
                   ,
                        FechaFinal = Convert.ToDateTime(UiFechaFinal.EditValue)
                   ,
                        Login = InteraccionConUsuarioServicio.ObtenerUsuario()
                   ,
                        Warehouses = PrepararBodegas()
                    });
                }
                else
                {
                 InteraccionConUsuarioServicio.Mensaje("Debe seleccionar al menos una bodega.");   
                }
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private string PrepararBodegas()
        {
            if (Bodegas == null) return null;
            var cadena = new StringBuilder();
            foreach (var objeto in Bodegas.Where(doc => doc.IS_SELECTED))
            {
                if (cadena.Length > 0) { cadena.Append("|"); }
                cadena.Append(objeto.WAREHOUSE_ID);
            }
            return cadena.ToString();
        }

        private void ExportalAExcel()
        {
            if (UiContenedorCosteos.DataSource == null) return;
            if (UiVistaCosteos.RowCount <= 0) return;

            var dialog = new SaveFileDialog
            {
                DefaultExt = "xlsx",
                Filter = @"Archivos de excel (*.xlsx)|*.xlsx"
            };

            if (dialog.ShowDialog() != DialogResult.OK) return;
            UiVistaCosteos.ExportToXlsx(dialog.FileName);
        }

        private void UiBotonExpandir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UiVistaCosteos.ExpandAllGroups();
        }

        private void UiBotonContraer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UiVistaCosteos.CollapseAllGroups();
        }

        private void UiBotonExportarExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ExportalAExcel();
        }

        private void UiBotonReporteConsolidado_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //if (PolizasMaestroDetalle == null || PolizasMaestroDetalle.IsEmpty())
            if (PolizasMaestroDetalle == null)
                return;
            var reporte = new Reportes.ConsultaCosteosConsolidado
            {
                DataSource = ListToDataTableClass.ListToDataTable(PolizasMaestroDetalle.ToList()),
                DataMember = "COSTEOS_CONSOLIDADOS",
                RequestParameters = false
            };
            reporte.Parameters["ImagenLogo"].Value = InteraccionConUsuarioServicio.ObtenerLogo();
            reporte.FillDataSource();

            using (var printTool = new ReportPrintTool(reporte))
            {
                printTool.ShowRibbonPreviewDialog();
            }
        }

        private void UiBotonReportePorDocumento_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //if (PolizasMaestroDetalle == null || PolizasMaestroDetalle.IsEmpty() || PolizasMaestroDetalle.Count(x => x.IS_SELECTED) == 0)
            if (PolizasMaestroDetalle == null || PolizasMaestroDetalle.Count(x => x.IS_SELECTED) == 0)
                return;
            var documentosSeleccionados = PolizasMaestroDetalle.Where(detalle => detalle.IS_SELECTED).Select(x => new { x.DOC_ID }).Distinct().ToList();


            var reporte = new Reportes.ConsultaCosteosPorDocumento
            {
                DataSource = ListToDataTableClass.ListToDataTable(PolizasMaestroDetalle.Where(detalle => documentosSeleccionados.Exists(s => s.DOC_ID == detalle.DOC_ID)).ToList()),
                DataMember = "COSTEOS_POR_DOCUMENTO",
                RequestParameters = false
            };
            reporte.Parameters["ImagenLogo"].Value = InteraccionConUsuarioServicio.ObtenerLogo();
            reporte.FillDataSource();

            using (var printTool = new ReportPrintTool(reporte))
            {
                printTool.ShowRibbonPreviewDialog();
            }
        }

        private void UiBotonAutorizar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                foreach (var documento in PolizasMaestroDetalle.Where(doc => doc.IS_SELECTED))
                {
                    UsuarioDeseaAutorizarCosteoPoliza?.Invoke(sender, new CosteoArgumento
                    {
                        PolizaDetalle = new PolizaDetalle
                        {
                            DOC_ID = documento.DOC_ID,
                            LINE_NUMBER = documento.LINE_NUMBER
                        }
                         ,
                        Login = Usuario
                    });
                }
                CargarCosteos(sender);
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void UiVistaCosteos_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            RecargarSeleccionCosteos();
        }

        private void UiVistaCosteos_ColumnFilterChanged(object sender, EventArgs e)
        {
            RecargarSeleccionCosteos();
        }

        private void RecargarSeleccionCosteos()
        {
            for (var i = 0; i < UiVistaCosteos.RowCount; i++)
            {
                var documento = (PolizaMaestroDetalle)UiVistaCosteos.GetRow(i);
                if (documento == null) continue;
                if (documento.IS_SELECTED)
                {
                    UiVistaCosteos.SelectRow(i);
                }
            }
        }

        private void UiVistaCosteos_MouseUp(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null)
                return;
            GridHitInfo hi = view.CalcHitInfo(new System.Drawing.Point(e.X, e.Y));
            if ((hi.HitTest == GridHitTest.Column || hi.HitTest == GridHitTest.GroupPanelColumn) && hi.Column.Name.Equals("DX$CheckboxSelectorColumn"))
            {
                UsuarioSeleccionoVistaCosteosCompleta = true;
            }
        }

        private void UiVistaCosteos_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if (e.ControllerRow >= 0)
            {
                var documento = (PolizaMaestroDetalle)UiVistaCosteos.GetRow(e.ControllerRow);
                documento.IS_SELECTED = (e.Action == CollectionChangeAction.Add);
            }
            else
            {
                if (UsuarioSeleccionoVistaCosteosCompleta)
                {
                    for (var i = 0; i < UiVistaCosteos.RowCount; i++)
                    {
                        var documento = (PolizaMaestroDetalle)UiVistaCosteos.GetRow(i);
                        if (documento == null) continue;
                        documento.IS_SELECTED = (UiVistaCosteos.SelectedRowsCount != 0);
                    }
                    UsuarioSeleccionoVistaCosteosCompleta = false;
                }
            }
        }

        private void UiListaBodega_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Tag == null) return;
            switch (e.Button.Tag.ToString())
            {
                case "UiBotonRefrescarBodega":
                    VistaCargandosePorPrimeraVez?.Invoke(sender, new ConteoFisicoArgumento());
                    break;
            }
        }

        private void ConsultaCosteoVista_FormClosing(object sender, FormClosingEventArgs e)
        {
            CargarOGuardarDisenios(UiContenedorCosteos, true, Usuario, GetType().Name);
        }

        private void UiSwitchLineasAbiertas_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CargarCosteos(sender);
        }
    }
}
