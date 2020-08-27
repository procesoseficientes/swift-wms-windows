using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
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
    public partial class TrazabilidadDeDemandaVista : VistaBase, ITrazabilidadDeDemandaVista
    {
        #region Eventos
        public event EventHandler<OrdenDeVentaArgumento> UsuarioDeseaObtenerReporte;
        public event EventHandler VistaCargandosePorPrimeraVez;
        public event EventHandler VistaTerminoDeCargar;
        #endregion

        #region Propiedades
        public IList<OrdenDeVentaReporte> OrdenesDeVenta
        {
            get { return (IList<OrdenDeVentaReporte>)UiContenedorTrazabilidadOrdenes.DataSource; }
            set { UiContenedorTrazabilidadOrdenes.DataSource = value; }
        }

        public IList<Bodega> Bodegas
        {
            get { return (IList<Bodega>) repositoryItemLookUpEdit1.DataSource; }
            set { repositoryItemLookUpEdit1.DataSource = value; }
        }

        public IInteraccionConUsuarioServicio InteraccionConUsuarioServicio { get; set; }
        #endregion

        public TrazabilidadDeDemandaVista()
        {
            InitializeComponent();

            Mvx.Ioc.RegisterType<IBaseDeDatosServicio, BaseDeDatosServicio>();
            Mvx.Ioc.Resolve<IConfiguracionDeConexion>();
            InteraccionConUsuarioServicio = Mvx.Ioc.Resolve<IInteraccionConUsuarioServicio>();
            Mvx.Ioc.RegisterType<IOrdenDeVentaERPServicio, OrdenDeVentaERPServicio>();
            Mvx.Ioc.RegisterType<IOrdenDeVentaSwiftExpressServicio, OrdenDeVentaSwiftExpressServicio>();
            Mvx.Ioc.RegisterType<IBodegaServicio, BodegaServicio>();

            Mvx.Ioc.RegisterSingleton<ITrazabilidadDeDemandaVista, TrazabilidadDeDemandaVista>(this);
            Mvx.Ioc.RegisterType<ITrazabilidadDeDemandaControlador, TrazabilidadDeDemandaControlador>();
            Mvx.Ioc.Resolve<ITrazabilidadDeDemandaControlador>();
        }
        

        public void TerminoProceso(object mensaje, dynamic sender)
        {
            throw new NotImplementedException();
        }
        
        private void TrazabilidadDeDemandaVista_Load(object sender, EventArgs e)
        {
            VistaCargandosePorPrimeraVez?.Invoke(sender, e);
            UiFechaIncial.EditValue = DateTime.Now.Date;
            UiFechaFinal.EditValue = DateTime.Now.Date + (new TimeSpan(23, 59, 59));

            SaveLayout.Start();
        }


        private void UiBotonRefrescar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (UiComboBodega.EditValue == null) return;

                OrdenesDeVenta = null;
                UsuarioDeseaObtenerReporte?.Invoke(sender, new OrdenDeVentaArgumento
                {
                    FechaInicio = (DateTime)UiFechaIncial.EditValue    
                    ,
                    FechaFin = (DateTime)UiFechaFinal.EditValue
                    ,
                    CodigoBodega = UiComboBodega.EditValue.ToString()
                    ,
                    EsDeErp = UiBarSwitchERP.Checked
                    ,
                    Usuario = InteraccionConUsuarioServicio.ObtenerUsuario()
                });
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void UiBotonExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UiDialogoParaGuardar.DefaultExt = "xlsx";
            UiDialogoParaGuardar.Filter = @"Archivos de excel (*.xlsx)|*.xlsx";
            UiDialogoParaGuardar.FilterIndex = 2;
            UiDialogoParaGuardar.RestoreDirectory = true;
            UiDialogoParaGuardar.Title = @"Guardar Reporte Trazabilidad de Demanda";
            if (UiDialogoParaGuardar.ShowDialog() == DialogResult.OK)
            {
                UiVistaTrazabilidadOrdenes.ExportToXlsx(UiDialogoParaGuardar.FileName);
            }
        }

        private void TrazabilidadDeDemandaVista_FormClosing(object sender, FormClosingEventArgs e)
        {
            CargarOGuardarDisenios(UiContenedorTrazabilidadOrdenes, true, InteraccionConUsuarioServicio.ObtenerUsuario(), GetType().Name);
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveLayout.Start();
        }

        int start = 0;
        private void SaveLayout_Tick(object sender, EventArgs e)
        {
            if (start == 0)
            {
                this.CargarOGuardarDisenios(UiContenedorTrazabilidadOrdenes, false, InteraccionConUsuarioServicio.ObtenerUsuario(), "Trazabilidad");
                start = 1;
                SaveLayout.Stop();
            }
        }
    }
}
