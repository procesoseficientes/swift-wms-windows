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
    public partial class OrdenesDeVentaPendientesVista : Form, IOrdenesDeVentaPendientesVista
    {
        public IInteraccionConUsuarioServicio InteraccionConUsuarioServicio { get; set; }
        public OrdenesDeVentaPendientesVista()
        {
            InitializeComponent();
            InteraccionConUsuarioServicio = Mvx.Ioc.Resolve<IInteraccionConUsuarioServicio>();
            Mvx.Ioc.RegisterType<IOrdenDeVentaSwiftExpressServicio, OrdenDeVentaSwiftExpressServicio>();
            Mvx.Ioc.RegisterType<IRutasSwiftExpressServicio, RutasSwiftExpressServicio>();
            Mvx.Ioc.RegisterType<IOrdenesDeVentaPendienteControlador, OrdenesDeVentaPendienteControlador>();
            Mvx.Ioc.RegisterType<IOrdenDeVentaERPServicio, OrdenDeVentaERPServicio>();
            Mvx.Ioc.RegisterSingleton<IOrdenesDeVentaPendientesVista, OrdenesDeVentaPendientesVista>(this);
            Mvx.Ioc.Resolve<IOrdenesDeVentaPendienteControlador>();
            VistaCargandosePorPrimeraVez?.Invoke(null, null);
            UiFechaInicio.EditValue = DateTime.Now.Date;
            UiFechaFinal.EditValue = DateTime.Now.Date;
        }
        public bool OrdenesDeErp => UiSwitchErp.Checked;
        public bool OrdenesDeSonda => UISwitchSonda.Checked;

        public IList<OrdenDeVentaPendiente> OrdenesDeVentaPendiente
        {
            get
            {
                return (IList<OrdenDeVentaPendiente>)UiPivotGridOrdenesPendiente.DataSource;
            }

            set
            {
                UiPivotGridOrdenesPendiente.DataSource = null;
                UiPivotGridOrdenesPendiente.DataSource = value;
            }
        }

        private bool UsuarioSeleccionoListaRutaVendedorCompleta { get; set; }

        public IList<Ruta> Rutas
        {
            get
            {
                return (IList<Ruta>)UiListaRutaVendedor.Properties.DataSource;
            }

            set
            {
                UiListaRutaVendedor.Properties.DataSource = value;
            }
        }

        public event EventHandler<OrdenDeVentaArgumento> UsuarioDeseaObtenerOrdenesDeVentaPendiente;
        public event EventHandler UsuarioDeseaObtenerRutas;
        public event EventHandler UsuarioDeseaQuitarLineasCompletas;
        public event EventHandler VistaCargandosePorPrimeraVez;

        private void UiBotonRefrescar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CargarOrdenesDeVenta(sender);
        }

        private void UISwitchSonda_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CargarOrdenesDeVenta(sender);
        }

        private void UiSwitchErp_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CargarOrdenesDeVenta(sender);
        }

        private void CargarOrdenesDeVenta(object sender)
        {
            try
            {
                var codigosFuesteRutas = new StringBuilder();
                var codigosRutas = new StringBuilder();
                UiPivotGridOrdenesPendiente.DataSource = new List<OrdenDeVentaPendiente>();

                if (UISwitchSonda.Checked)
                {
                    foreach (var ruta in Rutas.Where(r => r.IS_SELECTED))
                    {
                        if (codigosFuesteRutas.Length > 0) { codigosFuesteRutas.Append("|"); }
                        codigosFuesteRutas.Append(ruta.EXTERNAL_SOURCE_ID);

                        if (codigosRutas.Length > 0) { codigosRutas.Append("|"); }
                        codigosRutas.Append(ruta.CODE_ROUTE);
                    }
                }
                UsuarioDeseaObtenerOrdenesDeVentaPendiente?.Invoke(sender, new OrdenDeVentaArgumento
                {
                    FechaInicio = Convert.ToDateTime(UiFechaInicio.EditValue),
                    FechaFin = Convert.ToDateTime(UiFechaFinal.EditValue).AddHours(23),
                    CodigosFuenteRuta = codigosFuesteRutas.ToString(),
                    CodigosRuta = codigosRutas.ToString()
                });

                UiPivotGridOrdenesPendiente.Refresh();

            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void UiBotonQuitarLineasCompletadas_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                UsuarioDeseaQuitarLineasCompletas?.Invoke(sender, e);
                UiPivotGridOrdenesPendiente.Refresh();
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void UiListaRutaVendedor_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            UsuarioDeseaObtenerRutas?.Invoke(sender, e);
        }

        private void OrdenesDeVentaPendientesVista_Load(object sender, EventArgs e)
        {

        }

        private void UiBotonImpDetallado_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            try
            {
                var dialog = new SaveFileDialog
                {
                    DefaultExt = "xlsx",
                    Filter = @"Archivos de excel (*.xlsx)|*.xlsx"
                };

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    UiPivotGridOrdenesPendiente.ExportToXlsx(dialog.FileName);
                }
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void UiBotonImpConsolidado_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var reporte = new Reportes.OrdenesDeVentaPendientes
            {
                DataSource = this.OrdenesDeVentaPendiente.ToList(),
                //  DataMember = "OrdenesDeVentaPendiente",
                RequestParameters = false
            };
            reporte.Parameters["ImagenLogo"].Value = InteraccionConUsuarioServicio.ObtenerLogo();
            reporte.FillDataSource();

            using (var printTool = new ReportPrintTool(reporte))
            {
                printTool.ShowRibbonPreviewDialog();
            }
        }

        private void UiFechaFinal_EditValueChanged(object sender, EventArgs e)
        {
            CargarOrdenesDeVenta(sender);
        }

        private void UiFechaInicio_EditValueChanged(object sender, EventArgs e)
        {
            CargarOrdenesDeVenta(sender);
        }

        private void UiListaVistaRuntaVendedor_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            for (var i = 0; i < UiListaVistaRuntaVendedor.RowCount; i++)
            {
                var registro = (Ruta)UiListaVistaRuntaVendedor.GetRow(i);
                if (registro == null) continue;
                if (registro.IS_SELECTED)
                {
                    UiListaVistaRuntaVendedor.SelectRow(i);
                }
            }
        }

        private void UiListaVistaRuntaVendedor_MouseUp(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null)
                return;
            GridHitInfo hi = view.CalcHitInfo(new System.Drawing.Point(e.X, e.Y));
            if ((hi.HitTest == GridHitTest.Column || hi.HitTest == GridHitTest.GroupPanelColumn) && hi.Column.Name.Equals("DX$CheckboxSelectorColumn"))
            {
                UsuarioSeleccionoListaRutaVendedorCompleta = true;
            }
        }

        private void UiListaVistaRuntaVendedor_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if (e.ControllerRow >= 0)
            {
                var registro = (Ruta)UiListaVistaRuntaVendedor.GetRow(e.ControllerRow);
                registro.IS_SELECTED = (e.Action == CollectionChangeAction.Add);
            }
            else
            {
                if (UsuarioSeleccionoListaRutaVendedorCompleta)
                {
                    for (var i = 0; i < UiListaVistaRuntaVendedor.RowCount; i++)
                    {
                        var registro = (Ruta)UiListaVistaRuntaVendedor.GetRow(i);
                        if (registro == null) continue;
                        registro.IS_SELECTED = (UiListaVistaRuntaVendedor.SelectedRowsCount != 0);
                    }
                    UsuarioSeleccionoListaRutaVendedorCompleta = false;
                }
            }

            var edit = ActiveControl as DevExpress.XtraEditors.SearchLookUpEdit;
            if (edit == null) return;
            edit.Text = ObtenerTextoAMostrarListaRutas();
        }

        private void UiListaRutaVendedor_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            e.DisplayText = ObtenerTextoAMostrarListaRutas();
        }

        private string ObtenerTextoAMostrarListaRutas()
        {
            if (Rutas == null) return "";
            var cadena = new StringBuilder();
            foreach (var documento in Rutas.Where(doc => doc.IS_SELECTED))
            {
                if (cadena.Length > 0) { cadena.Append(","); }
                cadena.Append(documento.CODE_ROUTE + "|" + documento.SELLER_CODE);
            }

            return cadena.ToString();
        }

        private void UiListaRutaVendedor_EditValueChanged(object sender, EventArgs e)
        {
            CargarOrdenesDeVenta(sender);
        }
    }
}
