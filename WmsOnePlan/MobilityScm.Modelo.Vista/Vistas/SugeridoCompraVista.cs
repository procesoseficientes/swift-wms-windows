using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Controladores;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Interfaces.Controladores;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Modelo.Servicios;
using MobilityScm.Modelo.Tipos;
using MobilityScm.Utilerias;
using MobilityScm.Vertical.Servicios;

namespace MobilityScm.Modelo.Vistas
{
    public partial class SugeridoCompraVista : VistaBaseDeveExpress, ISugeridoCompraVista
    {
        #region Eventos

        public event EventHandler<SugeridoCompraArgumento> UsuarioDeseaObtenerBodegas;
        public event EventHandler<SugeridoCompraArgumento> UsuarioDeseaObtenerMateriales;
        public event EventHandler<SugeridoCompraArgumento> UsuarioDeseaObtenerSugeridoCompra;
        public event EventHandler VistaCargandosePorPrimeraVez;

        #endregion

        #region Propiedades

        public IList<Bodega> Bodegas
        {
            get { return (IList<Bodega>)UiListaBodega.Properties.DataSource; }
            set { UiListaBodega.Properties.DataSource = value; }
        }
        public IList<Material> Materiales
        {
            get { return (IList<Material>)UiListaProducto.Properties.DataSource; }
            set { UiListaProducto.Properties.DataSource = value; }
        }
        public IList<SugeridoCompra> SugeridoCompra
        {
            get { return (IList<SugeridoCompra>)UiVistaConsulta.DataSource; }
            set { UiVistaConsulta.DataSource = value; }
        }
        public IInteraccionConUsuarioServicio InteraccionConUsuarioServicio { get; set; }

        public IList<Entidades.Configuracion> Configuraciones { get; set; }
        #endregion

        #region Contructor y eventos de inicio de pagina

        public SugeridoCompraVista()
        {
            InitializeComponent();
            Mvx.Ioc.RegisterType<IBaseDeDatosServicio, BaseDeDatosServicio>();
            Mvx.Ioc.Resolve<IConfiguracionDeConexion>();
            InteraccionConUsuarioServicio = Mvx.Ioc.Resolve<IInteraccionConUsuarioServicio>();
            Mvx.Ioc.RegisterType<IBodegaServicio, BodegaServicio>();
            Mvx.Ioc.RegisterType<IUbicacionServicio, UbicacionServicio>();
            Mvx.Ioc.RegisterType<IMaterialServicio, MaterialServicio>();
            Mvx.Ioc.RegisterType<IConfiguracionServicio, ConfiguracionServicio>();
            Mvx.Ioc.RegisterType<IInventarioServicio, InventarioServicio>();
            Mvx.Ioc.RegisterSingleton<ISugeridoCompraVista, SugeridoCompraVista>(this);
            Mvx.Ioc.RegisterType<ISugerenciaCompraControlador, SugerenciaCompraControlador>();
            Mvx.Ioc.Resolve<ISugerenciaCompraControlador>();
        }

        private void InventarioInactivoVista_Load(object sender, EventArgs e)
        {
            Configuraciones = new List<Entidades.Configuracion>();
            Bodegas = new List<Bodega>();
            Materiales = new List<Material>();
            SugeridoCompra = new List<SugeridoCompra>();
            VistaCargandosePorPrimeraVez?.Invoke(null, null);
            
            CargarOGuardarDisenios(UiVistaConsulta, false, InteraccionConUsuarioServicio.ObtenerUsuario(), GetType().Name);
            
            ImplementarSeleccionMultipleDeUnaLista(UiListaBodega, new ObjetoParaGuardarEnVista { ListaDeCamposAMostrar = (new[] { "WAREHOUSE_ID" }) });
            ImplementarSeleccionMultipleDeUnaLista(UiListaProducto, new ObjetoParaGuardarEnVista { ListaDeCamposAMostrar = (new[] { "MATERIAL_CODE" }) });

        }

        #endregion

        #region Metodos

        #endregion

        #region Eventos de pagina

        private void UiLista_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (e.Button.Tag == null) return;
            switch (e.Button.Tag.ToString())
            {
                case "UiBtnRefrescarListaBodegas":
                    UsuarioDeseaObtenerBodegas?.Invoke(null, null);
                    break;
                case "UiBtnRefrescarListaMaterial":
                    UsuarioDeseaObtenerMateriales?.Invoke(null, null);
                    break;
            }
            Cursor.Current = Cursors.Default;
        }

        #region ListaDeBodegas

        private void UiListaBodega_Properties_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            try
            {
                if (!Bodegas.ToList().Exists(b => b.IS_SELECTED))
                {
                    Materiales = new List<Material>();
                    return;
                }
                UsuarioDeseaObtenerMateriales?.Invoke(null, null);
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        #endregion

        private void UiBotonExpandir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UiVistaInventarioInactivo.ExpandAllGroups();
        }

        private void UiBotonContraer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UiVistaInventarioInactivo.CollapseAllGroups();
        }

        private void UiBotonExportarExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                ExportarVista(UiVistaInventarioInactivo, true, ExportarA.Excel);
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void UiBotonRefrescar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                UsuarioDeseaObtenerSugeridoCompra?.Invoke(null, null);
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void InventarioInactivoVista_FormClosing(object sender, FormClosingEventArgs e)
        {
            CargarOGuardarDisenios(UiVistaConsulta, true, InteraccionConUsuarioServicio.ObtenerUsuario(), GetType().Name);
        }

        #endregion


    }
}
