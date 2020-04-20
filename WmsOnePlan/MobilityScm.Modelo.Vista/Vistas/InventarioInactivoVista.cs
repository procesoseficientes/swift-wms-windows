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
    public partial class InventarioInactivoVista : VistaBaseDeveExpress, IInventarioInactivoVista
    {
        #region Eventos

        public event EventHandler<InventarioInactivoArgumento> UsuarioDeseaObtenerBodegas;
        public event EventHandler<InventarioInactivoArgumento> UsuarioDeseaObtenerZonas;
        public event EventHandler<InventarioInactivoArgumento> UsuarioDeseaObtenerMateriales;
        public event EventHandler<InventarioInactivoArgumento> UsuarioDeseaObtenerIdle;
        public event EventHandler VistaCargandosePorPrimeraVez;

        #endregion

        #region Propiedades

        public IList<Bodega> Bodegas
        {
            get { return (IList<Bodega>)UiListaBodega.Properties.DataSource; }
            set { UiListaBodega.Properties.DataSource = value; }
        }
        public IList<Zona> Zonas
        {
            get { return (IList<Zona>)UiListaZona.Properties.DataSource; }
            set { UiListaZona.Properties.DataSource = value; }
        }
        public IList<Material> Materiales
        {
            get { return (IList<Material>)UiListaProducto.Properties.DataSource; }
            set { UiListaProducto.Properties.DataSource = value; }
        }
        public IList<InventarioInactivo> InventarioInactivo
        {
            get { return (IList<InventarioInactivo>)UiVistaConsulta.DataSource; }
            set { UiVistaConsulta.DataSource = value; }
        }
        public IInteraccionConUsuarioServicio InteraccionConUsuarioServicio { get; set; }

        public IList<Entidades.Configuracion> Configuraciones { get; set; }
        #endregion

        #region Contructor y eventos de inicio de pagina

        public InventarioInactivoVista()
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
            Mvx.Ioc.RegisterSingleton<IInventarioInactivoVista, InventarioInactivoVista>(this);
            Mvx.Ioc.RegisterType<IInventarioInactivoControlador, InventarioInactivoControlador>();
            Mvx.Ioc.Resolve<IInventarioInactivoControlador>();
        }

        private void InventarioInactivoVista_Load(object sender, EventArgs e)
        {
            Configuraciones = new List<Entidades.Configuracion>();
            Bodegas = new List<Bodega>();
            Zonas = new List<Zona>();
            Materiales = new List<Material>();
            InventarioInactivo = new List<InventarioInactivo>();
            VistaCargandosePorPrimeraVez?.Invoke(null, null);
            EstablecerReglasDeColorParaLaConsulta();
            CargarOGuardarDisenios(UiVistaConsulta, false, InteraccionConUsuarioServicio.ObtenerUsuario(), GetType().Name);
            
            ImplementarSeleccionMultipleDeUnaLista(UiListaBodega, new ObjetoParaGuardarEnVista { ListaDeCamposAMostrar = (new[] { "WAREHOUSE_ID" }) });
            ImplementarSeleccionMultipleDeUnaLista(UiListaZona, new ObjetoParaGuardarEnVista { ListaDeCamposAMostrar = (new[] { "ZONE" }) });
            ImplementarSeleccionMultipleDeUnaLista(UiListaProducto, new ObjetoParaGuardarEnVista { ListaDeCamposAMostrar = (new[] { "MATERIAL_CODE" }) });

        }

        #endregion

        #region Metodos

        private void EstablecerReglasDeColorParaLaConsulta()
        {
            try
            {
                if (Configuraciones.Count < 0) return;
                foreach (var configuracion in Configuraciones)
                {
                    DevExpress.XtraGrid.GridFormatRule regla = new DevExpress.XtraGrid.GridFormatRule();
                    regla.ApplyToRow = true;
                    regla.Name = configuracion.PARAM_NAME;
                    DevExpress.XtraEditors.FormatConditionRuleExpression expressionRegla = new DevExpress.XtraEditors.FormatConditionRuleExpression();
                    expressionRegla.Appearance.BackColor = Color.FromArgb(int.Parse(configuracion.COLOR));
                    expressionRegla.Appearance.BackColor2 = Color.FromArgb(int.Parse(configuracion.COLOR));
                    expressionRegla.Appearance.Options.UseBackColor = true;
                    expressionRegla.Expression = $"[IDLE] >= {configuracion.RANGE_NUM_START} And [IDLE] <={configuracion.RANGE_NUM_END}";
                    regla.Rule = expressionRegla;
                    UiVistaInventarioInactivo.FormatRules.Add(regla);
                }

            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

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
                case "UiBtnRefrescarListaZonas":
                    UsuarioDeseaObtenerZonas?.Invoke(null, null);
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
                    Zonas = new List<Zona>();
                    Materiales = new List<Material>();
                    return;
                }
                UsuarioDeseaObtenerZonas?.Invoke(null, null);
                UsuarioDeseaObtenerMateriales?.Invoke(null, null);
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        #endregion

        #region ListaDeZona

        private void UiListaZona_Properties_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            try
            {
                if (!Bodegas.ToList().Exists(b => b.IS_SELECTED) && !Zonas.ToList().Exists(b => b.IS_SELECTED))
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
                UsuarioDeseaObtenerIdle?.Invoke(null, null);
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
