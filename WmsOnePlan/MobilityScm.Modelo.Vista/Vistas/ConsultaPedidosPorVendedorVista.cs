using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraGrid.Views.Grid;
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
    public partial class ConsultaPedidosPorVendedorVista : VistaBase, IConsultaPedidosPorVendedorVista
    {
        #region Eventos
        public event EventHandler VistaTerminoDeCargar;
        public event EventHandler VistaCargandosePorPrimeraVez;
        public event EventHandler<ConsultaArgumento> UsuarioDeseaObtenerReporte;
        #endregion

        #region Propiedades
        public IList<ReportePedidosPorVendedor> PedidosPorVendedor
        {
            get { return (IList<ReportePedidosPorVendedor>)UiContenedorPrincipal.DataSource; }
            set { UiContenedorPrincipal.DataSource = value; }
        }

        public IList<Bodega> Bodegas
        {
            get { return (IList<Bodega>)UiLookUpEditBodega.DataSource; }
            set { UiLookUpEditBodega.DataSource = value; }
        }

        public IInteraccionConUsuarioServicio InteraccionConUsuarioServicio { get; set; }
        #endregion

        #region Contructor y Eventos de Carga
        public ConsultaPedidosPorVendedorVista()
        {
            InitializeComponent();

            Mvx.Ioc.RegisterType<IBaseDeDatosServicio, BaseDeDatosServicio>();
            Mvx.Ioc.Resolve<IConfiguracionDeConexion>();
            InteraccionConUsuarioServicio = Mvx.Ioc.Resolve<IInteraccionConUsuarioServicio>();

            Mvx.Ioc.RegisterType<IBodegaServicio, BodegaServicio>();
            Mvx.Ioc.RegisterType<IDemandaDeDespachoServicio, DemandaDeDespachoServicio>();

            Mvx.Ioc.RegisterSingleton<IConsultaPedidosPorVendedorVista, ConsultaPedidosPorVendedorVista>(this);
            Mvx.Ioc.RegisterType<IConsultaPedidosPorVendedorControlador, ConsultaPedidosPorVendedorControlador>();
            Mvx.Ioc.Resolve<IConsultaPedidosPorVendedorControlador>();
        }

        private void ConsultaPedidosPorVendedorVista_Load(object sender, EventArgs e)
        {
            VistaCargandosePorPrimeraVez?.Invoke(sender, e);
            UiFechaIncial.EditValue = DateTime.Now.Date;
            UiFechaFinal.EditValue = DateTime.Now.Date + (new TimeSpan(23, 59, 59));
            CargarOGuardarDisenios(UiContenedorPrincipal, false, InteraccionConUsuarioServicio.ObtenerUsuario(), GetType().Name);
        }

        private void ConsultaPedidosPorVendedorVista_FormClosing(object sender, FormClosingEventArgs e)
        {
            CargarOGuardarDisenios(UiContenedorPrincipal, true, InteraccionConUsuarioServicio.ObtenerUsuario(), GetType().Name);
        }
        #endregion

        #region Metodos
        public void TerminoProceso(object mensaje, dynamic sender)
        {
            throw new NotImplementedException();
        }

        private bool ValidarBodega()
        {
            if (UiBarItemBodega.EditValue != null) return true;

            InteraccionConUsuarioServicio.Mensaje("Debe seleccionar una bodega");
            return false;
        }
        #endregion

        #region Eventos de controles
        private void UiBotonRefrescar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (ValidarBodega())
                {
                    UsuarioDeseaObtenerReporte?.Invoke(e,
                                new ConsultaArgumento
                                {
                                    FechaInicial = (DateTime)UiFechaIncial.EditValue,
                                    FechaFinal = (DateTime)UiFechaFinal.EditValue,
                                    Login = InteraccionConUsuarioServicio.ObtenerUsuario(),
                                    CodigoBodega = UiBarItemBodega.EditValue.ToString()
                                }); 
                }
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void UiBotonExportarExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                UiDialogoParaGuardar.DefaultExt = "xlsx";
                UiDialogoParaGuardar.Filter = @"Archivos de excel (*.xlsx)|*.xlsx";
                UiDialogoParaGuardar.FilterIndex = 2;
                UiDialogoParaGuardar.RestoreDirectory = true;
                UiDialogoParaGuardar.Title = @"Guardar Pedidos por Vendedor";
                if (UiDialogoParaGuardar.ShowDialog() == DialogResult.OK)
                {
                    UiVistaPrincipal.ExportToXlsx(UiDialogoParaGuardar.FileName);
                }
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(ex.Message);
            }
        }

        private void UiBotonImprimir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {   
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (PedidosPorVendedor == null) return;

                UiVistaPrincipal.ExpandAllGroups();
                var pedidosPorVendedor = GetFilteredData<ReportePedidosPorVendedor>(UiVistaPrincipal);

                var reporte = new Reportes.ConsultaPedidosPorVendedor()
                {
                    DataSource = ListToDataTableClass.ListToDataTable(pedidosPorVendedor),
                    RequestParameters = false
                };
                reporte.Parameters["ImagenLogo"].Value = InteraccionConUsuarioServicio.ObtenerLogo();
                reporte.Parameters["Usuario"].Value = InteraccionConUsuarioServicio.ObtenerUsuario();
                reporte.FillDataSource();

                using (var printTool = new ReportPrintTool(reporte))
                {
                    printTool.ShowRibbonPreviewDialog();
                }

            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
            
        }

        #endregion

        private void UiVistaPrincipal_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Start)
                e.TotalValue = TimeSpan.Zero;
            if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Calculate)
            {
                var ts = TimeSpan.Parse(e.FieldValue.ToString());
                e.TotalValue = ts + (TimeSpan)e.TotalValue;
            }
        }
    }
}
