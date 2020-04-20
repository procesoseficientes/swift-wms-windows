using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraReports.UI;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Controladores;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Interfaces.Controladores;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Modelo.Reportes;
using MobilityScm.Modelo.Servicios;
using MobilityScm.Utilerias;
using MobilityScm.Vertical.Servicios;

namespace MobilityScm.Modelo.Vistas
{
    public partial class InventarioComprometido : Form, IInventarioComprometidoVista
    {
        #region Eventos

        public event EventHandler<InventarioComprometidoArgumento> UsuarioDeseaObtenerInventarioComprometido;
        public event EventHandler<InventarioComprometidoArgumento> UsuarioDeseaCancelarElInventarioPreparado;

        #endregion

        #region Propiedades
        public IList<InventarioComprometidoEncabezado> InventarioComprometidoEncabezados
        {
            get { return (IList<InventarioComprometidoEncabezado>)UiGridControlInventarioComprometido.DataSource; }
            set { UiGridControlInventarioComprometido.DataSource = value; }
        }

        public IList<InventarioComprometidoDetalle> InventarioComprometidoDetalles
        {
            get { return (IList<InventarioComprometidoDetalle>)UiGridControlInventarioComprometidoDetalle.DataSource; }
            set { UiGridControlInventarioComprometidoDetalle.DataSource = value; }
        }

        public IList<InventarioComprometidoDetalle> InventarioComprometidoTodosDetalles { get; set; }

        private bool UsuarioSeleccionoVistaCompletaInventarioComprometidoEncabezado { get; set; }

        public IInteraccionConUsuarioServicio InteraccionConUsuarioServicio { get; set; }

        #endregion

        #region Constructor e Inicializador
        public InventarioComprometido()
        {
            InitializeComponent();

            Mvx.Ioc.RegisterType<IBaseDeDatosServicio, BaseDeDatosServicio>();
            Mvx.Ioc.Resolve<IConfiguracionDeConexion>();
            InteraccionConUsuarioServicio = Mvx.Ioc.Resolve<IInteraccionConUsuarioServicio>();

            Mvx.Ioc.RegisterType<IInventarioComprometidoServicio, InventarioComprometidoServicio>();
            Mvx.Ioc.RegisterType<IInventarioComprometidoControlador, InventarioComprometidoControlador>();
            Mvx.Ioc.RegisterSingleton<IInventarioComprometidoVista, InventarioComprometido>(this);
            Mvx.Ioc.Resolve<IInventarioComprometidoControlador>();
        }
        #endregion

        #region Metodos
        private void MostrarDetalleDeOlaDePicking(object sender)
        {
            if (UiVistaInventarioComprometido.FocusedRowHandle < 0) return;
            var olaDePicking =
                (InventarioComprometidoEncabezado)
                    UiVistaInventarioComprometido.GetRow(UiVistaInventarioComprometido.FocusedRowHandle);

            InventarioComprometidoDetalles = InventarioComprometidoTodosDetalles.Where(todosDetalles => todosDetalles.PICKING_DEMAND_HEADER_ID == olaDePicking.PICKING_DEMAND_HEADER_ID).ToList();
        }

        private void ExportalAExcel()
        {
            try
            {
                //if (InventarioComprometidoEncabezados == null || InventarioComprometidoTodosDetalles == null || InventarioComprometidoEncabezados.Count(x => x.IS_SELECTED) == 0) return;
                var inventarioComprometidoConsolidado = from detalle in InventarioComprometidoTodosDetalles
                                                        join encabezado in InventarioComprometidoEncabezados on detalle.WAVE_PICKING_ID equals
                                                            encabezado.WAVE_PICKING_ID
                                                        select
                                                            new
                                                            {
                                                                encabezado.DOC_NUM,
                                                                encabezado.DELIVERY_DATE,
                                                                encabezado.CLIENT_CODE,
                                                                encabezado.CLIENT_NAME,
                                                                encabezado.IS_FROM_ERP,
                                                                encabezado.IS_FROM_SONDA,
                                                                encabezado.WAVE_PICKING_ID,
                                                                encabezado.ERP_DOCUMENT,
                                                                encabezado.STATUS,
                                                                detalle.LABEL_ID,
                                                                detalle.LOCATION_SPOT_SOURCE,
                                                                detalle.LICENSE_ID_SOURCE,
                                                                detalle.LOCATION_SPOT_TARGET,
                                                                detalle.LICENSE_ID_TARGET,
                                                                detalle.MATERIAL_ID,
                                                                detalle.MATERIAL_NAME,
                                                                detalle.IS_MASTER_PACK,
                                                                detalle.QTY,
                                                                detalle.DELIVERY_STATUS
                                                            };
                if (inventarioComprometidoConsolidado.Count() > 0)
                {
                    var dialog = new SaveFileDialog
                    {
                        DefaultExt = "xlsx",
                        Filter = @"Archivos de excel (*.xlsx)|*.xlsx"
                    };
                    if (dialog.ShowDialog() != DialogResult.OK) return;
                    UiGridExport.DataSource = inventarioComprometidoConsolidado.ToList();
                    UiGridExport.ExportToXlsx(dialog.FileName);
                }



            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void GenerarReporte()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var listaDeEncabezadosSeleccionados =
                    InventarioComprometidoEncabezados.Where(enc => enc.IS_SELECTED).ToList();

                if (listaDeEncabezadosSeleccionados.Count == 0) return;

                var listaDeReporte = (from encabezado in listaDeEncabezadosSeleccionados
                                      let listaDetalles = InventarioComprometidoTodosDetalles.Where(det => det.WAVE_PICKING_ID == encabezado.WAVE_PICKING_ID).ToList()
                                      from detalle in listaDetalles
                                      select new InventarioComprometidoParaReporte
                                      {
                                          DOC_NUM = encabezado.DOC_NUM,
                                          CLIENT_CODE = encabezado.CLIENT_CODE,
                                          CLIENT_NAME = encabezado.CLIENT_NAME,
                                          WAVE_PICKING_ID = encabezado.WAVE_PICKING_ID,
                                          ERP_DOCUMENT = encabezado.ERP_DOCUMENT,
                                          LABEL_ID = detalle.LABEL_ID,
                                          LOCATION_SPOT = detalle.LOCATION_SPOT,
                                          MATERIAL_ID = detalle.MATERIAL_ID,
                                          MATERIAL_NAME = detalle.MATERIAL_NAME,
                                          QTY = detalle.QTY,
                                          DELIVERY_STATUS = detalle.DELIVERY_STATUS
                                      }).ToList();

                var reporte = new ReporteInventarioComprometido()
                {
                    DataSource = ListToDataTableClass.ListToDataTable(listaDeReporte),
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

        public void RecargarPantalla()
        {
            try
            {
                if (UiFechaInicio.EditValue == null || UiFechaFinal.EditValue == null) return;
                if ((DateTime)UiFechaInicio.EditValue > (DateTime)UiFechaFinal.EditValue)
                {
                    InteraccionConUsuarioServicio.Alerta("La fecha final no puede ser mayor a la fecha inicial");
                }
                InventarioComprometidoDetalles = new List<InventarioComprometidoDetalle>();
                UsuarioDeseaObtenerInventarioComprometido?.Invoke(null, new InventarioComprometidoArgumento
                {
                    FechaInicio = DateTime.Parse(UiFechaInicio.EditValue.ToString())
                    ,
                    FechaFinal = DateTime.Parse(UiFechaFinal.EditValue.ToString())
                });

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

        private void CancelarInventarioPreparado()
        {
            try
            {
                var invetarioPreparado = (InventarioComprometidoEncabezado)UiVistaInventarioComprometido.GetRow(UiVistaInventarioComprometido.FocusedRowHandle);
                if (invetarioPreparado == null) return;
                if (XtraMessageBox.Show("¿Confirma cancelar el inventario preparado?", "Swift 3PL", MessageBoxButtons.YesNo,
                       MessageBoxIcon.Question) != DialogResult.Yes) return;
                UsuarioDeseaCancelarElInventarioPreparado?.Invoke(null, new InventarioComprometidoArgumento { PickingDemandHeaderId = invetarioPreparado.PICKING_DEMAND_HEADER_ID });
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

        #region Metodos de Controles
        private void InventarioComprometido_Load(object sender, EventArgs e)
        {
            UiFechaFinal.EditValue = DateTime.Today;
            UiFechaInicio.EditValue = DateTime.Today;
        }

        private void UiGridControlInventarioComprometido_Click(object sender, EventArgs e)
        {
            MostrarDetalleDeOlaDePicking(sender);
        }

        private void UiBotonRefrescar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RecargarPantalla();
        }

        private void UiVistaInventarioComprometido_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.ControllerRow >= 0)
            {
                var documento = (InventarioComprometidoEncabezado)UiVistaInventarioComprometido.GetRow(e.ControllerRow);
                documento.IS_SELECTED = (e.Action == CollectionChangeAction.Add);
            }
            else
            {
                if (UsuarioSeleccionoVistaCompletaInventarioComprometidoEncabezado)
                {
                    for (var i = 0; i < UiVistaInventarioComprometido.RowCount; i++)
                    {
                        var documento = (InventarioComprometidoEncabezado)UiVistaInventarioComprometido.GetRow(i);
                        if (documento == null) continue;
                        documento.IS_SELECTED = (UiVistaInventarioComprometido.SelectedRowsCount != 0);
                    }
                    UsuarioSeleccionoVistaCompletaInventarioComprometidoEncabezado = false;
                }
            }
        }

        private void UiVistaInventarioComprometido_MouseUp(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null)
                return;

            GridHitInfo hi = view.CalcHitInfo(new System.Drawing.Point(e.X, e.Y));
            if ((hi.HitTest == GridHitTest.Column || hi.HitTest == GridHitTest.GroupPanelColumn) &&
                hi.Column.Name.Equals("DX$CheckboxSelectorColumn"))
            {
                UsuarioSeleccionoVistaCompletaInventarioComprometidoEncabezado = true;
            }
        }

        private void UiVistaInventarioComprometido_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            for (var i = 0; i < UiVistaInventarioComprometido.RowCount; i++)
            {
                var documento = (InventarioComprometidoEncabezado)UiVistaInventarioComprometido.GetRow(i);
                if (documento == null) continue;
                if (documento.IS_SELECTED)
                {
                    UiVistaInventarioComprometido.SelectRow(i);
                }
            }
        }

        private void UiBotonCancelar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CancelarInventarioPreparado();
        }

        private void UiBotonExportarExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ExportalAExcel();
        }

        #endregion


    }
}
