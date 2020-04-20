using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Controladores;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Interfaces.Controladores;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Modelo.Servicios;
using MobilityScm.Modelo.Tipos;
using MobilityScm.Utilerias;
using MobilityScm.Vertical.Servicios;
using DevExpress.XtraEditors.Controls;


namespace MobilityScm.Modelo.Vistas
{
    public partial class IndicesDeBodegaVista : VistaBaseDeveExpress, IIndicesDeBodegaVista
    {

        #region Funciones

        public event EventHandler<InventarioInactivoArgumento> UsuarioDeseaObtenerBodegas;
        public event EventHandler<InventarioInactivoArgumento> UsuarioDeseaObtenerMateriales;
        public event EventHandler<InventarioInactivoArgumento> UsuarioDeseaObtenerIndicesDeBodega;
        public event EventHandler VistaCargandosePorPrimeraVez;

        #endregion

        #region Propieddes

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

        public IList<IndicesBodega> IndicesDeBodegas
        {
            get { return (IList<IndicesBodega>)UiVistaConsulta.DataSource; }
            set { UiVistaConsulta.DataSource = value; }
        }

        public IInteraccionConUsuarioServicio InteraccionConUsuarioServicio { get; set; }

        #endregion

        #region Contructor y eventos de inicio de pagina

        public IndicesDeBodegaVista()
        {
            InitializeComponent();

            Mvx.Ioc.RegisterType<IBaseDeDatosServicio, BaseDeDatosServicio>();
            Mvx.Ioc.Resolve<IConfiguracionDeConexion>();
            InteraccionConUsuarioServicio = Mvx.Ioc.Resolve<IInteraccionConUsuarioServicio>();
            Mvx.Ioc.RegisterType<IBodegaServicio, BodegaServicio>();
            Mvx.Ioc.RegisterType<IMaterialServicio, MaterialServicio>();
            Mvx.Ioc.RegisterType<IIndiceBodegaServicio, IndiceBodegaServicio>();
            Mvx.Ioc.RegisterSingleton<IIndicesDeBodegaVista, IndicesDeBodegaVista>(this);
            Mvx.Ioc.RegisterType<IIndicesDeBodegaControlador, IndicesDeBodegaControlador>();
            Mvx.Ioc.Resolve<IIndicesDeBodegaControlador>();
        }

        private void IndicesDeBodegaVista_Load(object sender, EventArgs e)
        {
            Bodegas = new List<Bodega>();
            Materiales = new List<Material>();
            IndicesDeBodegas = new List<IndicesBodega>();
            VistaCargandosePorPrimeraVez?.Invoke(null, null);
            CargarOGuardarDisenios(UiVistaConsulta, false, InteraccionConUsuarioServicio.ObtenerUsuario(), GetType().Name);
            ImplementarSeleccionMultipleDeUnaLista(UiListaBodega, new ObjetoParaGuardarEnVista { ListaDeCamposAMostrar = (new[] { "WAREHOUSE_ID" }) });
            ImplementarSeleccionMultipleDeUnaLista(UiListaProducto, new ObjetoParaGuardarEnVista { ListaDeCamposAMostrar = (new[] { "MATERIAL_CODE" }) });
        }

        #endregion

        #region Eventos de pagina

        private void UiLista_Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
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
            UiVistaIndicesDeBodega.ExpandAllGroups();
        }

        private void UiBotonContraer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UiVistaIndicesDeBodega.CollapseAllGroups();
        }

        private void UiBotonExportarExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                ExportarVista(UiVistaIndicesDeBodega, true, ExportarA.Excel);
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
                if (UiControlFecha.EditValue == null)
                {
                    InteraccionConUsuarioServicio.MensajeErrorDialogo("Debe seleccionar una fecha.");
                    return;
                }

                UsuarioDeseaObtenerIndicesDeBodega?.Invoke(null, new InventarioInactivoArgumento
                {
                    DateWarehouseIndices = (DateTime)UiControlFecha.EditValue
                });
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }
        private void IndicesDeBodegaVista_FormClosing(object sender, FormClosingEventArgs e)
        {
            CargarOGuardarDisenios(UiVistaConsulta, true, InteraccionConUsuarioServicio.ObtenerUsuario(), GetType().Name);
        }

        #endregion
    }
}
