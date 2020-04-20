using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Utils.Extensions;
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
    public partial class ConsultaDeInventarioDiarioVista : VistaBase, IConsultaDeInventarioDiarioVista
    {
        #region Eventos
        public event EventHandler<ConsultaArgumento> UsuarioDeseaConsultarInventarioDiario;
        public event EventHandler VistaCargandosePorPrimeraVez;
        public event EventHandler VistaTerminoDeCargar;
        #endregion

        #region Propiedades
        public IList<Bodega> Bodegas
        {
            get { return (IList<Bodega>)UiSearchLookUpBodegas.DataSource; }
            set
            {
                UiSearchLookUpBodegas.DataSource = value;
            }
        }

        public IList<ReporteDeInventarioDiario> Inventario
        {
            get { return (IList<ReporteDeInventarioDiario>)UiGridControlReporteDeInventario.DataSource; }
            set { UiGridControlReporteDeInventario.DataSource = value; }
        }

        public DateTime FechaReporte => (DateTime)UiFecha.EditValue;

        public IInteraccionConUsuarioServicio InteraccionConUsuarioServicio { get; set; }

        private bool _todasLasBodegasSeleccionadas;
        #endregion

        #region Contructor y Eventos de Carga
        public ConsultaDeInventarioDiarioVista()
        {
            InitializeComponent();

            Mvx.Ioc.RegisterType<IBaseDeDatosServicio, BaseDeDatosServicio>();
            Mvx.Ioc.Resolve<IConfiguracionDeConexion>();
            InteraccionConUsuarioServicio = Mvx.Ioc.Resolve<IInteraccionConUsuarioServicio>();

            Mvx.Ioc.RegisterType<IInventarioServicio, InventarioServicio>();
            Mvx.Ioc.RegisterType<IBodegaServicio, BodegaServicio>();

            Mvx.Ioc.RegisterSingleton<IConsultaDeInventarioDiarioVista, ConsultaDeInventarioDiarioVista>(this);
            Mvx.Ioc.RegisterType<IConsultaDeInventarioDiarioControlador, ConsultaDeInventarioDiarioControlador>();
            Mvx.Ioc.Resolve<IConsultaDeInventarioDiarioControlador>();
        }

        private void ConsultaDeInventarioDiarioVista_Load(object sender, EventArgs e)
        {
            VistaCargandosePorPrimeraVez?.Invoke(sender, e);
            UiFecha.EditValue = DateTime.Now.Date;
            CargarOGuardarDisenios(UiGridControlReporteDeInventario, false, InteraccionConUsuarioServicio.ObtenerUsuario(), GetType().Name);
        }

        private void ConsultaDeInventarioDiarioVista_FormClosing(object sender, FormClosingEventArgs e)
        {
            CargarOGuardarDisenios(UiGridControlReporteDeInventario, true, InteraccionConUsuarioServicio.ObtenerUsuario(), GetType().Name);
        }
        #endregion

        #region Métodos
        public void TerminoProceso(object mensaje, dynamic sender)
        {
            throw new NotImplementedException();
        }

        private string ObtenerBodegasSeleccionadas()
        {
            return Bodegas == null ? string.Empty : string.Join("|", Bodegas.Where(b => b.IS_SELECTED).Select(b => b.WAREHOUSE_ID));
        }
        #endregion

        #region Eventos Controles
        private void UiBarButtonRefrescar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                UsuarioDeseaConsultarInventarioDiario?.Invoke(sender, new ConsultaArgumento()
                {
                    CodigoBodega = ObtenerBodegasSeleccionadas(),
                    FechaInicial = FechaReporte,
                    Login = InteraccionConUsuarioServicio.ObtenerUsuario()
                });
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
        private void UiBarButtonExportarAExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                UiDialogoGuardar.DefaultExt = "xlsx";
                UiDialogoGuardar.Filter = @"Archivos de excel (*.xlsx)|*.xlsx";
                UiDialogoGuardar.FilterIndex = 2;
                UiDialogoGuardar.RestoreDirectory = true;
                UiDialogoGuardar.Title = @"Guardar Consulta de Inventario de Diario";
                if (UiDialogoGuardar.ShowDialog() == DialogResult.OK)
                {
                    UiVistaReporteDeInventario.ExportToXlsx(UiDialogoGuardar.FileName);
                }
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(ex.Message);
            }
            Cursor.Current = Cursors.Default;
        }

        private void UiBarButtonExpandir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UiVistaReporteDeInventario.ExpandAllGroups();
        }

        private void UiBarButtonColapsar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UiVistaReporteDeInventario.CollapseAllGroups();
        }

        private void UiBarButtonReporte_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var reporte = new Reportes.ConsultaDeInventarioDiario()
                {
                    DataSource = ListToDataTableClass.ListToDataTable(Inventario.ToList()),
                    RequestParameters = false
                };

                reporte.Parameters["Usuario"].Value = InteraccionConUsuarioServicio.ObtenerNombreUsuario();
                reporte.Parameters["ImagenLogo"].Value = InteraccionConUsuarioServicio.ObtenerLogo();
                reporte.FillDataSource();

                using (var printTool = new ReportPrintTool(reporte))
                {
                    printTool.ShowRibbonPreviewDialog();
                }
                Cursor.Current = Cursors.Default;

            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(ex.Message);
            }
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

        private void UiSearchLookUpBodegas_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            e.DisplayText = Bodegas == null ? string.Empty : string.Join(",", Bodegas.Where(b => b.IS_SELECTED).Select(b => b.NAME));
        }
        #endregion
    }
}
