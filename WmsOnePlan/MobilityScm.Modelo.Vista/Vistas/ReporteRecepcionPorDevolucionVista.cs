using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.DataProcessing;
using DevExpress.XtraPrinting.Native;
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
    public partial class ReporteRecepcionPorDevolucionVista : VistaBase, IReporteRecepcionPorDevolucionVista
    {
        #region Eventos
        public event EventHandler<ConsultaArgumento> UsuarioDeseaObtenerRecepcionesPorDevolucion;
        public event EventHandler VistaCargandosePorPrimeraVez;
        public event EventHandler VistaTerminoDeCargar;
        #endregion

        #region Propiedades
        public IList<Bodega> Bodegas
        {
            get { return (IList<Bodega>)UiRepositorySearchLookBodegas.DataSource; }
            set { UiRepositorySearchLookBodegas.DataSource = value; }
        }

        public IList<ReporteRecepcionPorDevolucion> RecepcionesPorDevoluciones
        {
            get { return (IList<ReporteRecepcionPorDevolucion>)UiGridControlDevoluciones.DataSource; }
            set { UiGridControlDevoluciones.DataSource = value; }
        }
        
        public IInteraccionConUsuarioServicio InteraccionConUsuarioServicio { get; set; }

        private bool _todasLasBodegasSeleccionadas;
        
        public DateTime FechaInicial => (DateTime)UiFechaInicial.EditValue;

        public DateTime FechaFinal => (DateTime)UiFechaFinal.EditValue;
        #endregion

        #region Contructor y Eventos de Carga
        public ReporteRecepcionPorDevolucionVista()
        {
            InitializeComponent();

            Mvx.Ioc.RegisterType<IBaseDeDatosServicio, BaseDeDatosServicio>();
            Mvx.Ioc.Resolve<IConfiguracionDeConexion>();
            InteraccionConUsuarioServicio = Mvx.Ioc.Resolve<IInteraccionConUsuarioServicio>();

            Mvx.Ioc.RegisterType<IRecepcionServicio, RecepcionServicio>();
            Mvx.Ioc.RegisterType<IBodegaServicio, BodegaServicio>();

            Mvx.Ioc.RegisterSingleton<IReporteRecepcionPorDevolucionVista, ReporteRecepcionPorDevolucionVista>(this);
            Mvx.Ioc.RegisterType<IReporteRecepcionPorDevolucionControlador, ReporteRecepcionPorDevolucionControlador>();
            Mvx.Ioc.Resolve<IReporteRecepcionPorDevolucionControlador>();
        }

        private void ReporteRecepcionPorDevolucionVista_Load(object sender, EventArgs e)
        {
            VistaCargandosePorPrimeraVez?.Invoke(sender, e);
            UiFechaInicial.EditValue = DateTime.Now.Date;
            UiFechaFinal.EditValue = DateTime.Now.Date + new TimeSpan(0, 23, 59, 59);
            CargarOGuardarDisenios(UiGridControlDevoluciones, false, InteraccionConUsuarioServicio.ObtenerUsuario(), GetType().Name);
        }

        private void ReporteRecepcionPorDevolucionVista_FormClosing(object sender, FormClosingEventArgs e)
        {
            CargarOGuardarDisenios(UiGridControlDevoluciones, true, InteraccionConUsuarioServicio.ObtenerUsuario(), GetType().Name);
        }
        #endregion



        #region Metodos
        public void TerminoProceso(object mensaje, dynamic sender)
        {
            throw new NotImplementedException();
        }

        private string ObtenerBodegasSeleccionadas()
        {
            return Bodegas == null ? string.Empty : string.Join("|", Bodegas.Where(b => b.IS_SELECTED).Select(b => b.WAREHOUSE_ID));
        }
        #endregion

        #region Eventos de Controles
        private void UiBarButtonRefrescar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                UsuarioDeseaObtenerRecepcionesPorDevolucion?.Invoke(sender, new ConsultaArgumento()
                {
                    CodigoBodega = ObtenerBodegasSeleccionadas(),
                    FechaInicial = FechaInicial,
                    FechaFinal = FechaFinal,
                    Login = InteraccionConUsuarioServicio.ObtenerUsuario()
                });

                UiVistaDevoluciones.ExpandAllGroups();
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(ex.Message);
                throw;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void UiBarButtonExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                UiDialogoGuardar.DefaultExt = "xlsx";
                UiDialogoGuardar.Filter = @"Archivos de excel (*.xlsx)|*.xlsx";
                UiDialogoGuardar.FilterIndex = 2;
                UiDialogoGuardar.RestoreDirectory = true;
                UiDialogoGuardar.Title = @"Guardar Consulta de Inventario de Diario";
                if (UiDialogoGuardar.ShowDialog() == DialogResult.OK) {
                    UiVistaDevoluciones.ExportToXlsx(UiDialogoGuardar.FileName);
                }
            }
            catch (Exception ex) {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void UiBarButtonContraer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UiVistaDevoluciones.CollapseAllGroups();
        }

        private void UiBarButtonExpandir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UiVistaDevoluciones.ExpandAllGroups();
        }
        
        private void UiRepositorySearchLookBodegas_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            e.DisplayText = Bodegas == null ? string.Empty : string.Join(",", Bodegas.Where(b => b.IS_SELECTED).Select(b => b.NAME));
        }

        private void UiVistaBodegas_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            try
            {
                if (Bodegas == null) return;
                if (e.ControllerRow < 0)
                {
                    Bodegas.ForEach(b => b.IS_SELECTED = !_todasLasBodegasSeleccionadas);
                    _todasLasBodegasSeleccionadas = !_todasLasBodegasSeleccionadas;
                }
                else
                {
                    Bodegas[e.ControllerRow].IS_SELECTED = !Bodegas[e.ControllerRow].IS_SELECTED;
                }
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(ex.Message);
            }
        }

        private void UiBarButtonConsolidado_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var devolucionesConsolidadas = RecepcionesPorDevoluciones
                .Where(d => d.QTY > 0)
                .GroupBy(d => new { d.INVOICE_DOC_NUM})
                .Select(dc => new ReporteRecepcionPorDevolucion
                {
                    INVOICE_DOC_NUM = dc.Key.INVOICE_DOC_NUM
                    ,ERP_REFERENCE_DOC_NUM = dc.First().ERP_REFERENCE_DOC_NUM
                    ,CLIENT_CODE = dc.First().CLIENT_CODE
                    ,CLIENT_NAME = dc.First().CLIENT_NAME
                    ,QTY = dc.Sum(d => d.QTY)
                });

            var cantidadNotasDeCredito =
                devolucionesConsolidadas.Where(d => d.ERP_REFERENCE_DOC_NUM != null).ToList().Count;

            var reporte = new Reportes.ReporteDevolucionesConsolidado()
            {
                DataSource = devolucionesConsolidadas,
                RequestParameters = false
            };

            reporte.Parameters["ParametroUsuario"].Value = InteraccionConUsuarioServicio.ObtenerUsuario();
            reporte.Parameters["ImagenLogo"].Value = InteraccionConUsuarioServicio.ObtenerLogo();
            reporte.Parameters["CantidadNotasDeCredito"].Value = cantidadNotasDeCredito;
            reporte.FillDataSource();

            using (var printTool = new ReportPrintTool(reporte))
            {
                printTool.ShowRibbonPreviewDialog();
            }
        }

        private void UiBarButtonDetallado_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var devolucionesDetalladas = RecepcionesPorDevoluciones
                .Where(d => d.QTY > 0)
                .ToList();

            var reporte = new Reportes.ReporteDevolucionesDetallado()
            {
                DataSource = devolucionesDetalladas,
                RequestParameters = false
            };

            reporte.Parameters["ParametroUsuario"].Value = InteraccionConUsuarioServicio.ObtenerUsuario();
            reporte.Parameters["ImagenLogo"].Value = InteraccionConUsuarioServicio.ObtenerLogo();
            reporte.FillDataSource();

            using (var printTool = new ReportPrintTool(reporte))
            {
                printTool.ShowRibbonPreviewDialog();
            }
        }
        #endregion


    }
}
