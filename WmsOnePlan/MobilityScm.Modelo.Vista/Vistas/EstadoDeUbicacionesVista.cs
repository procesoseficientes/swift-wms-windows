using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGauges.Core.Model;
using DevExpress.XtraGauges.Core.Printing;
using DevExpress.XtraPrinting;
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
    public partial class EstadoDeUbicacionesVista : VistaBase, IEstadoDeUbicacionesVista
    {
        public EstadoDeUbicacionesVista()
        {
            InitializeComponent();

            Mvx.Ioc.RegisterType<IBaseDeDatosServicio, BaseDeDatosServicio>();
            Mvx.Ioc.Resolve<IConfiguracionDeConexion>();
            InteraccionConUsuarioServicio = Mvx.Ioc.Resolve<IInteraccionConUsuarioServicio>();
            Mvx.Ioc.RegisterType<IConfiguracionServicio, ConfiguracionServicio>();
            Mvx.Ioc.RegisterType<IBodegaServicio, BodegaServicio>();
            Mvx.Ioc.RegisterType<IEstadoDeUbicacionesServicio, EstadoDeUbicacionesServicio>();
            Mvx.Ioc.RegisterSingleton<IEstadoDeUbicacionesVista, EstadoDeUbicacionesVista>(this);
            Mvx.Ioc.RegisterType<IEstadoDeUbicacionesControlador, EstadoDeUbicacionesControlador>();
            Mvx.Ioc.Resolve<IEstadoDeUbicacionesControlador>();

            arcScaleComponent2.EnableAnimation = true;
            arcScaleComponent2.EasingMode = EasingMode.EaseIn;
            arcScaleComponent2.EasingFunction = new BounceEase();
        }

        public IList<Bodega> Bodegas
        {
            get { return (IList<Bodega>)UiListaBodegas.Properties.DataSource; }
            set { UiListaBodegas.Properties.DataSource = value; }
        }

        public IList<Entidades.Configuracion> TiposUbicacion

        {
            get { return (IList<Entidades.Configuracion>)UIListaTiposDeTarea.Properties.DataSource; }
            set { UIListaTiposDeTarea.Properties.DataSource = value; }
        }

        public IInteraccionConUsuarioServicio InteraccionConUsuarioServicio { get; set; }

        public IList<Ubicacion> Ubicaciones
        {
            get { return (IList<Ubicacion>)UiGridControlEstadoUbicacion.DataSource; }
            set { UiGridControlEstadoUbicacion.DataSource = value; }
        }
        public IList<Zona> Zonas
        {
            get { return (IList<Zona>)UiListaZonas.Properties.DataSource; }
            set { UiListaZonas.Properties.DataSource = value; }
        }

        public event EventHandler<EstadoDeUbicacionArgumento> UsuarioDeseaObtenerBodegasAsignadasAUsuario;
        public event EventHandler<EstadoDeUbicacionArgumento> UsuarioDeseaObtenerEstadoDeUbicaciones;
        public event EventHandler<EstadoDeUbicacionArgumento> UsuarioDeseaObtenerZonasPorWarehouse;
        public event EventHandler VistaCargandosePorPrimeraVez;

        private void UILista_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

        }

        private void EstadoDeUbicacionesVista_Load(object sender, EventArgs e)
        {
            CargarOGuardarDisenios(UiGridControlEstadoUbicacion, false, InteraccionConUsuarioServicio.ObtenerUsuario(), GetType().Name);
            VistaCargandosePorPrimeraVez?.Invoke(sender, e);
            CargarGrafica();
        }

        private void CargarGrafica()
        {
            try
            {
                var list = (from u in Ubicaciones
                            group u by u.IS_OVERWEIGHT
                       into g
                            select new
                            {
                                SobrePeso = g.Key
                                ,
                                Cantidad = g.Count()
                            }
                   ).ToList();
                var sobrePeso = list.FirstOrDefault(x => x.SobrePeso == "Si");
                int cantidadSobrePeso = 0, cantidadSinSobrePeso = 0;
                if (sobrePeso != null)
                    cantidadSobrePeso = sobrePeso.Cantidad;

                var sinSobrePeso = list.FirstOrDefault(x => x.SobrePeso == "No");
                if (sinSobrePeso != null)
                    cantidadSinSobrePeso = sinSobrePeso.Cantidad;
                arcScaleComponent2.Value = cantidadSobrePeso + cantidadSinSobrePeso == 0 ? 0 : Convert.ToInt32(Convert.ToDecimal(cantidadSobrePeso) / Convert.ToDecimal(cantidadSobrePeso + cantidadSinSobrePeso) * 100);

                labelComponent2.Text = string.IsNullOrEmpty((string)UiListaBodegas.EditValue) ? "Bodega: Todas" : "Bodega: " + UiListaBodegas.Text;
                labelComponent3.Text = string.IsNullOrEmpty((string)UiListaZonas.EditValue) ? "Zona: Todas" : "Zona: " + UiListaZonas.Text;

            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }


        }

        private void UiListaBodegas_EditValueChanged(object sender, EventArgs e)
        {
            CargarZonas(sender);
            CargarUbicaciones(sender);


        }

        private void CargarZonas(object sender)
        {
            if (!string.IsNullOrEmpty((string)UiListaBodegas.EditValue))
            {
                UsuarioDeseaObtenerZonasPorWarehouse?.Invoke(sender, new EstadoDeUbicacionArgumento
                {
                    Bodega = UiListaBodegas.EditValue?.ToString(),
                });
                UiListaZonas.EditValue = "";
            }
        }


        private void CargarUbicaciones(object sender)
        {
            try
            {
                UsuarioDeseaObtenerEstadoDeUbicaciones?.Invoke(sender, new EstadoDeUbicacionArgumento
                {
                    Bodega = UiListaBodegas.EditValue?.ToString(),
                    Zona = UiListaZonas.EditValue?.ToString(),
                    TipoUbicacion = UIListaTiposDeTarea.EditValue?.ToString()
                });
                CargarGrafica();
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void UiListaZonas_EditValueChanged(object sender, EventArgs e)
        {
            CargarUbicaciones(sender);
        }

        private void UIListaTiposDeTarea_EditValueChanged(object sender, EventArgs e)
        {
            CargarUbicaciones(sender);
        }

        private void UiBotonRefrescar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CargarUbicaciones(sender);
        }

        private void UiBotonExportarGrafica_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            try
            {
                gaugeControl1.ShowPrintPreview(PrintSizeMode.Zoom);
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void UiBotonExportarGrid_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                UiGridVistaEstadoUbicaciones.ShowPrintPreview();
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void UiBotonExpandir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                UiGridVistaEstadoUbicaciones.ExpandAllGroups();
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void UiBotonContraer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                UiGridVistaEstadoUbicaciones.CollapseAllGroups();
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void EstadoDeUbicacionesVista_FormClosing(object sender, FormClosingEventArgs e)
        {
            CargarOGuardarDisenios(UiGridControlEstadoUbicacion, true, InteraccionConUsuarioServicio.ObtenerUsuario(), GetType().Name);
        }
    }
}
