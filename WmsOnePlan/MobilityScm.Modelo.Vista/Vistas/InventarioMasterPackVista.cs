using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Controladores;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Interfaces.Controladores;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Modelo.Servicios;
using MobilityScm.Utilerias;
using MobilityScm.Vertical.Servicios;
using System.ComponentModel;
using System.Linq;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraReports.UI;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace MobilityScm.Modelo.Vistas
{
    public partial class InventarioMasterPackVista : VistaBase, IMasterPackVista
    {
        #region Eventos

        public event EventHandler<MasterPackArgumento> UsuarioDeseaAutorizarMasterPackERP;
        public event EventHandler<MasterPackArgumento> UsuarioDeseaObtenerDetallesDeMasterPacks;
        public event EventHandler<MasterPackArgumento> UsuarioDeseaObtenerMaestroDetalleDeMasterPack;
        public event EventHandler<MasterPackArgumento> UsuarioDeseaObtenerMasterPacksPorFechaDeExplocion;
        public event EventHandler VistaCargandosePorPrimeraVez;
        #endregion

        #region Propiedades

        public IList<MasterPackMaestroDetalle> MaestroDetalles
        {
            get { return (IList<MasterPackMaestroDetalle>)UiContendorDeVistaInventario.DataSource; }

            set
            {
                UiContendorDeVistaInventario.DataSource = value;
                UiVistaInventario.ExpandAllGroups();
            }
        }

        public IList<MasterPackDetalle> MasterPackDetalles
        {
            get { return (IList<MasterPackDetalle>)UiContenedorVistaMasterPackDetalle.DataSource; }

            set
            {
                UiContenedorVistaMasterPackDetalle.DataSource = value;
                UiVistaMasterPackDetalle.ExpandAllGroups();
            }
        }

        public IList<MasterPackEncabezado> MasterPackEncabezados
        {
            get { return (IList<MasterPackEncabezado>)UiContenedorVistaMasterPackEncabezado.DataSource; }

            set
            {
                UiContenedorVistaMasterPackEncabezado.DataSource = value;
                UiVistaMasterPackEncabezado.ExpandAllGroups();
            }
        }

        public string Usuario { get; set; }

        private bool UsuarioSeleccionoListaMasterPackCompleta { get; set; }

        public IInteraccionConUsuarioServicio InteraccionConUsuarioServicio { get; private set; }
        #endregion

        #region Contructor y Eventos De carga

        public InventarioMasterPackVista()
        {
            InitializeComponent();
            InteraccionConUsuarioServicio = Mvx.Ioc.Resolve<IInteraccionConUsuarioServicio>();
            Mvx.Ioc.RegisterType<IBaseDeDatosServicio, BaseDeDatosServicio>();
            Mvx.Ioc.Resolve<IConfiguracionDeConexion>();
            Mvx.Ioc.Resolve<IInteraccionConUsuarioServicio>();
            Mvx.Ioc.RegisterType<IMasterPackServicio, MasterPackServicio>();
            Mvx.Ioc.RegisterType<IMasterPackControlador, MasterPackControlador>();
            Mvx.Ioc.RegisterSingleton<IMasterPackVista, InventarioMasterPackVista>(this);
            Mvx.Ioc.Resolve<IMasterPackControlador>();
        }

        private void InventarioMasterPackVista_Load(object sender, EventArgs e)
        {
            VistaCargandosePorPrimeraVez?.Invoke(sender, e);
            CargarOGuardarDisenios(UiContendorDeVistaInventario, false, Usuario, GetType().Name);
            UiFechaInicioEnvio.EditValue = DateTime.Today;
            UiFechaFinalEnvio.EditValue = DateTime.Today;
        }

        private void InventarioMasterPackVista_FormClosing(object sender, FormClosingEventArgs e)
        {
            CargarOGuardarDisenios(UiContendorDeVistaInventario, true, Usuario, GetType().Name);
        }

        #endregion

        #region Inventario En Linea

        #region Eventos

        private void UiBotonExportarAExcelInventario_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MaestroDetalles == null) return;
            if (MaestroDetalles.Count == 0) return;

            var dialog = new SaveFileDialog
            {
                DefaultExt = "xlsx",
                Filter = @"Archivos de excel (*.xlsx)|*.xlsx"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                UiContendorDeVistaInventario.ExportToXlsx(dialog.FileName);
            }
        }

        private void UiBotonRefrescarInventario_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UsuarioDeseaObtenerMaestroDetalleDeMasterPack?.Invoke(sender, new MasterPackArgumento { Login = InteraccionConUsuarioServicio.ObtenerUsuario() });
        }

        private void UiTimerInventario_Tick(object sender, EventArgs e)
        {
            UsuarioDeseaObtenerMaestroDetalleDeMasterPack?.Invoke(sender, new MasterPackArgumento { Login = InteraccionConUsuarioServicio.ObtenerUsuario() });
        }

        private void UiSwiftchRefrescarAutomaticamenteInventario_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UiTimerInventario.Enabled = UiSwiftchRefrescarAutomaticamenteInventario.Checked;
        }

        private void UiBotonExpadirInventario_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UiVistaInventario.ExpandAllGroups();
        }

        private void UiBotonContraerInventario_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UiVistaInventario.CollapseAllGroups();
        }

        #endregion

        #endregion

        #region Envio

        #region Eventos

        private void UiBotonRefrescarEnvio_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LlenarVistaEncabezadoEnvio();
        }

        private void UiContenedorVistaMasterPackEncabezado_Click(object sender, EventArgs e)
        {
            LlenarDetalleMasterPack();
        }

        private void UiVistaMasterPackEncabezado_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if (e.ControllerRow >= 0)
            {
                var masterPack = (MasterPackEncabezado)UiVistaMasterPackEncabezado.GetRow(e.ControllerRow);
                if (masterPack.IS_AUTHORIZED == 0 && masterPack.EXPLODED == 1)
                {
                    masterPack.IS_SELECTD = (e.Action == CollectionChangeAction.Add);
                }
                else
                {
                    masterPack.IS_SELECTD = false;
                    UiVistaMasterPackEncabezado.UnselectRow(e.ControllerRow);
                }

            }
            else
            {
                if (!UsuarioSeleccionoListaMasterPackCompleta) return;
                for (var i = 0; i < UiVistaMasterPackEncabezado.RowCount; i++)
                {
                    var masterPack = (MasterPackEncabezado)UiVistaMasterPackEncabezado.GetRow(i);
                    if (masterPack == null) continue;
                    if (masterPack.IS_AUTHORIZED == 0 && masterPack.EXPLODED == 1)
                    {
                        masterPack.IS_SELECTD = (UiVistaMasterPackEncabezado.SelectedRowsCount != 0);
                    }
                    else
                    {
                        masterPack.IS_SELECTD = false;
                        UiVistaMasterPackEncabezado.UnselectRow(i);
                    }
                }
                UsuarioSeleccionoListaMasterPackCompleta = false;
            }
        }

        private void UiVistaMasterPackEncabezado_MouseUp(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null)
                return;
            GridHitInfo hi = view.CalcHitInfo(new System.Drawing.Point(e.X, e.Y));
            if ((hi.HitTest == GridHitTest.Column || hi.HitTest == GridHitTest.GroupPanelColumn) && hi.Column.Name.Equals("DX$CheckboxSelectorColumn"))
            {
                UsuarioSeleccionoListaMasterPackCompleta = true;
            }
        }

        private void UiVistaMasterPackEncabezado_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            try
            {
                MarcarMasterPackEncabezado();
            }
            catch (Exception)
            {
            }

        }

        private void UiVistaMasterPackEncabezado_ColumnFilterChanged(object sender, EventArgs e)
        {
            try
            {
                MarcarMasterPackEncabezado();
            }
            catch (Exception)
            {
            }

        }

        private void UiBotonEnviarAErp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AutorizarMasterPack();
        }

        private void UiBotonExportarAExcelEnvio_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MasterPackEncabezados == null) return;
            if (MasterPackEncabezados.Count == 0) return;

            var dialog = new SaveFileDialog
            {
                DefaultExt = "xlsx",
                Filter = @"Archivos de excel (*.xlsx)|*.xlsx"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                UiVistaMasterPackEncabezado.ExportToXlsx(dialog.FileName);
            }
        }

        private void InventarioMasterPackVista_Resize(object sender, EventArgs e)
        {
            UiSplitEnvio.SplitterPosition = (Height - 50) / 2;
        }

        #endregion

        #region Consultas 

        private void MarcarMasterPackEncabezado()
        {
            for (var i = 0; i < UiVistaMasterPackEncabezado.RowCount; i++)
            {
                var masterPack = (MasterPackEncabezado)UiVistaMasterPackEncabezado.GetRow(i);
                if (masterPack.IS_SELECTD)
                {
                    UiVistaMasterPackEncabezado.SelectRow(i);
                }
                else if (masterPack.IS_AUTHORIZED == 1 && masterPack.EXPLODED == 1)
                {
                    UiVistaMasterPackEncabezado.UnselectRow(i);
                }
            }
        }

        private void LlenarVistaEncabezadoEnvio()
        {
            if (UiFechaInicioEnvio.EditValue == null || UiFechaFinalEnvio.EditValue == null) return;

            UsuarioDeseaObtenerMasterPacksPorFechaDeExplocion?.Invoke(null, new MasterPackArgumento
            {
                FechaInicial = ((DateTime)UiFechaInicioEnvio.EditValue)
                ,
                FechaFinal = ((DateTime)UiFechaFinalEnvio.EditValue)
                ,
                Login = InteraccionConUsuarioServicio.ObtenerUsuario()
            });
            MasterPackDetalles = new List<MasterPackDetalle>();
        }

        private void LlenarDetalleMasterPack()
        {
            if (UiVistaMasterPackEncabezado.FocusedRowHandle < 0) return;

            MasterPackDetalles = new List<MasterPackDetalle>();

            var masterPackEncabezado = (MasterPackEncabezado)UiVistaMasterPackEncabezado.GetRow(UiVistaMasterPackEncabezado.FocusedRowHandle);

            UsuarioDeseaObtenerDetallesDeMasterPacks?.Invoke(null, new MasterPackArgumento
            {
                MasterPackEncabezado = masterPackEncabezado

            });
        }

        private void AutorizarMasterPack()
        {
            var lista = MasterPackEncabezados.Where(m => m.IS_SELECTD && m.IS_AUTHORIZED == 0 && m.EXPLODED == 1);
            foreach (var masterPack in lista)
            {
                UsuarioDeseaAutorizarMasterPackERP?.Invoke(null, new MasterPackArgumento
                {
                    MasterPackEncabezado = masterPack

                });
            }
            LlenarVistaEncabezadoEnvio();
        }





        #endregion

        #endregion

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (UiVistaInventario.DataSource == null)
            {
                InteraccionConUsuarioServicio.Mensaje(
                    "No se encontraron datos para generar el reporte, por favor, verifique y vuelva a intentar.");
            }
            else
            {
                var listaDeInventario = new List<MasterPackMaestroDetalle>();
                for (var i = 0; i < UiVistaInventario.RowCount; i++)
                {
                    listaDeInventario.Add((MasterPackMaestroDetalle)UiVistaInventario.GetRow(i));
                }
                var reporte = new Reportes.MasterPackInventario
                {
                    DataSource = ListToDataTableClass.ListToDataTable(listaDeInventario),
                    DataMember = "AcuerdoComercial",
                    RequestParameters = false
                };
                reporte.Parameters["ImagenLogo"].Value = InteraccionConUsuarioServicio.ObtenerLogo();
                reporte.FillDataSource();

                using (var printTool = new ReportPrintTool(reporte))
                {
                    printTool.ShowRibbonPreviewDialog();
                }
            }
        }

        private void UiVistaInventario_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (EsColumnaDeColorYElValorEsNumerico(e))
            {
                Color color = Color.FromArgb(Convert.ToInt32(e.CellValue));
                LinearGradientBrush brush = new LinearGradientBrush(e.Bounds, color, color, LinearGradientMode.ForwardDiagonal);

                e.Graphics.FillRectangle(brush, e.Bounds);
                brush.Dispose();
                e.Graphics.DrawString("", e.Appearance.Font, Brushes.Black, new RectangleF(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));
                e.Handled = true;
            }
        }

        private bool EsColumnaDeColorYElValorEsNumerico(DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            int output;
            return e.CellValue != null && e.Column.FieldName == "COLOR" && int.TryParse(e.CellValue.ToString(), out output);
        }
    }
}
