using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraReports.UI;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Controladores;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Estados;
using MobilityScm.Modelo.Interfaces.Controladores;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Modelo.Servicios;
using MobilityScm.Modelo.Tipos;
using MobilityScm.Utilerias;
using MobilityScm.Vertical.Servicios;

namespace MobilityScm.Modelo.Vistas
{
    public partial class ReporteDeSolicitudDeTrasladoVista : VistaBase, IReporteDeSolicitudDeTrasladoVista
    {
        #region Eventos
        public event EventHandler<ReporteDeSolicitudDeTrasladoArgumento> UsuarioDeseaCerrarSolicitudesDeTraslado;
        public event EventHandler<ReporteDeSolicitudDeTrasladoArgumento> UsuarioDeseaObtenerSolicitudesDeTrasladoPorBodegaEstadoYFecha;
        public event EventHandler<ReporteDeSolicitudDeTrasladoArgumento> UsuarioDeseaSeleccionoSolicitudDeTraslado;
        public event EventHandler<ReporteDeSolicitudDeTrasladoArgumento> UsuarioSeleccionoCentrosDeDistribucion;
        public event EventHandler VistaCargandosePorPrimeraVez;
        public event EventHandler VistaTerminoDeCargar;
        #endregion

        #region Propiedades
        public IList<Bodega> Bodegas
        {
            get { return (IList<Bodega>)UiListaBodega.Properties.DataSource; }
            set { UiListaBodega.Properties.DataSource = value; }
        }

        public IList<Entidades.Configuracion> CentrosDeDistribucion
        {
            get { return (IList<Entidades.Configuracion>)UIListaCentroDeDistribucion.Properties.DataSource; }
            set { UIListaCentroDeDistribucion.Properties.DataSource = value; }
        }

        public IList<SolicitudDeTrasladoEncabezado> SolicitudesDeTraslado
        {
            get { return (IList<SolicitudDeTrasladoEncabezado>)UiContenedorSolicitudes.DataSource; }
            set { UiContenedorSolicitudes.DataSource = value; }
        }

        public IList<TrazabilidadDeSolicitudDeTraslado> TrazabilidadDeSolicitudesDeTraslado
        {
            get { return (IList<TrazabilidadDeSolicitudDeTraslado>)UiContenedorTrazabilidad.DataSource; }
            set { UiContenedorTrazabilidad.DataSource = value; }
        }

        public IInteraccionConUsuarioServicio InteraccionConUsuarioServicio { get; set; }
        private bool UsuarioSeleccionoListaCentrosDeDistribucionCompleta { get; set; }
        private bool UsuarioSeleccionoListaSolicitudesCompleta { get; set; }
        private bool UsuarioSeleccionoListaBodegasCompleta { get; set; }

        public IList<Seguridad> ListaDeSeguridad { get; set; }
        #endregion

        #region Constructor y Eventos de Carga
        public ReporteDeSolicitudDeTrasladoVista()
        {
            InitializeComponent();

            Mvx.Ioc.RegisterType<IBaseDeDatosServicio, BaseDeDatosServicio>();
            Mvx.Ioc.Resolve<IConfiguracionDeConexion>();
            InteraccionConUsuarioServicio = Mvx.Ioc.Resolve<IInteraccionConUsuarioServicio>();
            Mvx.Ioc.RegisterType<ISolicitudDeTrasladoServicio, SolicitudDeTrasladoServicio>();
            Mvx.Ioc.RegisterType<IConfiguracionServicio, ConfiguracionServicio>();
            Mvx.Ioc.RegisterType<ISeguridadServicio, SeguridadServicio>();
            Mvx.Ioc.RegisterType<IBodegaServicio, BodegaServicio>();

            Mvx.Ioc.RegisterSingleton<IReporteDeSolicitudDeTrasladoVista, ReporteDeSolicitudDeTrasladoVista>(this);
            Mvx.Ioc.RegisterType<IReporteDeSolicitudDeTrasladoControlador, ReporteDeSolicitudDeTrasladoControlador>();
            Mvx.Ioc.Resolve<IReporteDeSolicitudDeTrasladoControlador>();
        }
        private void ReporteDeSolicitudDeTrasladoVista_Load(object sender, EventArgs e)
        {
            VistaCargandosePorPrimeraVez?.Invoke(sender, e);
            CargarOGuardarDisenios(UiContenedorSolicitudes, false, InteraccionConUsuarioServicio.ObtenerUsuario(), GetType().Name);
            CargarOGuardarDisenios(UiContenedorTrazabilidad, false, InteraccionConUsuarioServicio.ObtenerUsuario(), GetType().Name);
            UiGrupoRadioFechas.SelectedIndex = 0;
            UiFechaInicial.EditValue = DateTime.Now.Date;
            UiFechaFinal.EditValue = DateTime.Now.Date + new TimeSpan(23, 59, 59);
        }
        #endregion

        #region Metodos
        public void TerminoProceso(object mensaje, dynamic sender)
        {

        }


        private void DoRowDoubleClick(GridView view, Point pt, object sender)
        {
            var info = view.CalcHitInfo(pt);
            if (!info.InRow && !info.InRowCell) return;
            var idSolicitudTraslado = UiVistaSolicitud.GetRowCellValue(info.RowHandle, "TRANSFER_REQUEST_ID");
            if (idSolicitudTraslado == null) return;
            UsuarioDeseaSeleccionoSolicitudDeTraslado?.Invoke(sender, new ReporteDeSolicitudDeTrasladoArgumento
            {
                SolicitudDeTrasladoEncabezado = new SolicitudDeTrasladoEncabezado { TRANSFER_REQUEST_ID = (int)idSolicitudTraslado }
            });

            UiTabControlPrincipal.SelectedTabPage = UiTabTrazabilidad;
        }
        #endregion

        #region Eventos de Controles
        private void UIListaClientes_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Tag == null) return;
            switch (e.Button.Tag.ToString())
            {
                case "UiBotonRefrescar-CentrosDeDistribucion":
                    // UsuarioDeseaObtenerTiposDeTarea?.Invoke(sender, new TareaArgumento());
                    break;
                case "UiBotonRefrescar-Bodega":
                    // UsuarioDeseaObtenerTiposDeTarea?.Invoke(sender, new TareaArgumento());
                    break;
            }
        }

        private void UiGrupoRadioFechas_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (UiGrupoRadioFechas.SelectedIndex)
            {
                case 0:
                    UiFechaInicial.EditValue = DateTime.Now;
                    UiFechaFinal.EditValue = DateTime.Now;
                    break;
                case 1:
                    UiFechaInicial.EditValue = DateTime.Now.Date.AddDays(-1);
                    UiFechaFinal.EditValue = DateTime.Now;
                    break;
                case 2:
                    UiFechaInicial.EditValue = DateTime.Now.Date.AddDays(-7) ;
                    UiFechaFinal.EditValue = DateTime.Now;
                    break;
                case 3:
                    UiFechaInicial.EditValue = DateTime.Now.Date.AddMonths(-1);
                    UiFechaFinal.EditValue = DateTime.Now;
                    break;
                case 4:
                    UiFechaInicial.EditValue = DateTime.Now.Date.AddMonths(-3) ;
                    UiFechaFinal.EditValue = DateTime.Now;
                    break;
                case 5:
                    UiFechaInicial.EditValue = DateTime.Now.Date.AddMonths(-6);
                    UiFechaFinal.EditValue = DateTime.Now;
                    break;
            }
        }

        private void UiVistaCentroDeDistribucion_MouseUp(object sender, MouseEventArgs e)
        {
            var view = sender as GridView;
            if (view == null)
                return;
            var hi = view.CalcHitInfo(new Point(e.X, e.Y));
            if ((hi.HitTest == GridHitTest.Column || hi.HitTest == GridHitTest.GroupPanelColumn) && hi.Column.Name.Equals("DX$CheckboxSelectorColumn"))
            {
                UsuarioSeleccionoListaCentrosDeDistribucionCompleta = true;
            }
        }

        private void UiVistaCentroDeDistribucion_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            for (var i = 0; i < UiVistaCentroDeDistribucion.RowCount; i++)
            {
                var centro = (Entidades.Configuracion)UiVistaCentroDeDistribucion.GetRow(i);
                if (centro == null) continue;
                if (centro.IS_SELECTED)
                {
                    UiVistaCentroDeDistribucion.SelectRow(i);
                }
            }
        }

        private void UIListaCentroDeDistribucion_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            if (CentrosDeDistribucion == null) return;
            e.DisplayText = string.Join(",",
                CentrosDeDistribucion.Where(solicitud => solicitud.IS_SELECTED).Select(solicitud => solicitud.PARAM_CAPTION));
        }

        private void UiVistaCentroDeDistribucion_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            var edit = ActiveControl as DevExpress.XtraEditors.SearchLookUpEdit;
            if (edit == null ) return;

            if (e.ControllerRow >= 0)
            {
                var centro = (Entidades.Configuracion)UiVistaCentroDeDistribucion.GetRow(e.ControllerRow);
                centro.IS_SELECTED = (e.Action == CollectionChangeAction.Add);
            }
            else
            {
                if (UsuarioSeleccionoListaCentrosDeDistribucionCompleta)
                {
                    for (var i = 0; i < UiVistaCentroDeDistribucion.RowCount; i++)
                    {
                        var centro = (Entidades.Configuracion)UiVistaCentroDeDistribucion.GetRow(i);
                        if (centro == null) continue;
                        centro.IS_SELECTED = (UiVistaCentroDeDistribucion.SelectedRowsCount != 0);
                    }
                    UsuarioSeleccionoListaCentrosDeDistribucionCompleta = false;
                }
            }


            edit.Text = string.Join(",", CentrosDeDistribucion.Where(centro => centro.IS_SELECTED).Select(centro => centro.PARAM_CAPTION));
            //
            UsuarioSeleccionoCentrosDeDistribucion?.Invoke(sender, new ReporteDeSolicitudDeTrasladoArgumento
            {
                CentrosDeDistribucion = string.Join("|", CentrosDeDistribucion.Where(centro => centro.IS_SELECTED).Select(centro => centro.PARAM_NAME))
            });
        }

        private void UiVistaBodegas_MouseUp(object sender, MouseEventArgs e)
        {
            var view = sender as GridView;
            if (view == null)
                return;
            var hi = view.CalcHitInfo(new Point(e.X, e.Y));
            if ((hi.HitTest == GridHitTest.Column || hi.HitTest == GridHitTest.GroupPanelColumn) && hi.Column.Name.Equals("DX$CheckboxSelectorColumn"))
            {
                UsuarioSeleccionoListaBodegasCompleta = true;
            }
        }

        private void UiVistaBodegas_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            for (var i = 0; i < UiVistaBodegas.RowCount; i++)
            {
                var bodega = (Bodega)UiVistaBodegas.GetRow(i);
                if (bodega == null) continue;
                if (bodega.IS_SELECTED)
                {
                    UiVistaBodegas.SelectRow(i);
                }
            }
        }

        private void UiListaBodega_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            if (Bodegas == null) return;
            e.DisplayText = string.Join(",",
                Bodegas.Where(bodega => bodega.IS_SELECTED).Select(bodega => bodega.NAME));
        }

        private void UiVistaBodegas_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            var edit = ActiveControl as DevExpress.XtraEditors.SearchLookUpEdit;
            if (edit == null) return;

            if (e.ControllerRow >= 0)
            {
                var bodega = (Bodega)UiVistaBodegas.GetRow(e.ControllerRow);
                bodega.IS_SELECTED = (e.Action == CollectionChangeAction.Add);
            }
            else
            {
                if (UsuarioSeleccionoListaBodegasCompleta)
                {
                    for (var i = 0; i < UiVistaBodegas.RowCount; i++)
                    {
                        var bodega = (Bodega)UiVistaBodegas.GetRow(i);
                        if (bodega == null) continue;
                        bodega.IS_SELECTED = (UiVistaBodegas.SelectedRowsCount != 0);
                    }
                    UsuarioSeleccionoListaBodegasCompleta = false;
                }
            }



            edit.Text = string.Join(",", Bodegas.Where(bodega => bodega.IS_SELECTED).Select(bodega => bodega.NAME));
        }


        private void UiBotonAceptarFiltro_Click(object sender, EventArgs e)
        {
            if (Bodegas == null) return;
            UsuarioDeseaObtenerSolicitudesDeTrasladoPorBodegaEstadoYFecha?.Invoke(sender, new ReporteDeSolicitudDeTrasladoArgumento
            {
                FechaInicial = UiFechaInicial.DateTime
                ,
                FechaFinal = UiFechaFinal.DateTime
                ,
                Estado = UiSwitchAbiertas.IsOn ? Enums.GetStringValue(EstadoSolicitudDeTraslado.OPEN) : Enums.GetStringValue(EstadoSolicitudDeTraslado.CLOSED)
                ,
                Bodegas = string.Join("|", Bodegas.Where(bodega => bodega.IS_SELECTED).Select(bodega => bodega.WAREHOUSE_ID))
            });
        }

        private void UiVistaSolicitud_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if (e.ControllerRow >= 0)
            {
                var solicitud = (SolicitudDeTrasladoEncabezado)UiVistaSolicitud.GetRow(e.ControllerRow);
                solicitud.IS_SELECTED = (e.Action == CollectionChangeAction.Add);
            }
            else
            {
                if (!UsuarioSeleccionoListaSolicitudesCompleta) return;
                for (var i = 0; i < UiVistaSolicitud.RowCount; i++)
                {
                    var solicitud = (SolicitudDeTrasladoEncabezado)UiVistaSolicitud.GetRow(i);
                    if (solicitud == null) continue;
                    solicitud.IS_SELECTED = (UiVistaSolicitud.SelectedRowsCount != 0);
                }
                UsuarioSeleccionoListaSolicitudesCompleta = false;
            }
        }

        private void UiVistaSolicitud_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            for (var i = 0; i < UiVistaSolicitud.RowCount; i++)
            {
                var solicitud = (SolicitudDeTrasladoEncabezado)UiVistaSolicitud.GetRow(i);
                if (solicitud == null) continue;
                if (solicitud.IS_SELECTED)
                {
                    UiVistaSolicitud.SelectRow(i);
                }
            }
        }

        private void UiVistaSolicitud_MouseUp(object sender, MouseEventArgs e)
        {
            var view = sender as GridView;
            if (view == null)
                return;
            var hi = view.CalcHitInfo(new Point(e.X, e.Y));
            if ((hi.HitTest == GridHitTest.Column || hi.HitTest == GridHitTest.GroupPanelColumn) && hi.Column.Name.Equals("DX$CheckboxSelectorColumn"))
            {
                UsuarioSeleccionoListaSolicitudesCompleta = true;
            }
        }

        private void UiBarButtonExpandir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UiVistaSolicitud.ExpandAllGroups();
        }

        private void UiBarButtonColapsar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UiVistaSolicitud.CollapseAllGroups();
        }

        private void UiBarButtonExportar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UiVistaSolicitud.ShowPrintPreview();
        }

        private void UiVistaSolicitud_DoubleClick(object sender, EventArgs e)
        {
            var view = (GridView)sender;
            var pt = view.GridControl.PointToClient(MousePosition);
            DoRowDoubleClick(view, pt, sender);
        }


        private void UiBarButtonCerrarSolicitudes_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (SolicitudesDeTraslado == null) return;
            UsuarioDeseaCerrarSolicitudesDeTraslado?.Invoke(sender, new ReporteDeSolicitudDeTrasladoArgumento
            {
                IdsSolicitudesDeTraslado = string.Join("|", SolicitudesDeTraslado.Where(solicitud => solicitud.IS_SELECTED).Select(solicitud => solicitud.TRANSFER_REQUEST_ID))
                ,
                MaterialesSolicitudDeTraslado = string.Join("|", SolicitudesDeTraslado.Where(solicitud => solicitud.IS_SELECTED).Select(solicitud => solicitud.MATERIAL_ID))
            });

            UsuarioDeseaObtenerSolicitudesDeTrasladoPorBodegaEstadoYFecha?.Invoke(sender, new ReporteDeSolicitudDeTrasladoArgumento
            {
                FechaInicial = UiFechaInicial.DateTime
                ,
                FechaFinal = UiFechaFinal.DateTime
                ,
                Estado = UiSwitchAbiertas.IsOn ? Enums.GetStringValue(EstadoSolicitudDeTraslado.OPEN) : Enums.GetStringValue(EstadoSolicitudDeTraslado.CLOSED)
                ,
                Bodegas = string.Join("|", Bodegas.Where(bodega => bodega.IS_SELECTED).Select(bodega => bodega.WAREHOUSE_ID))
            });
        }

        private void UiBarButtonImprimir_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (SolicitudesDeTraslado == null) return;
            var listaSolicitudes = new List<SolicitudDeTrasladoEncabezado>();
            for (var i = 0; i < UiVistaSolicitud.RowCount; i++)
            {
                listaSolicitudes.Add((SolicitudDeTrasladoEncabezado)UiVistaSolicitud.GetRow(i));
            }
            var reporte = new Reportes.ReporteDeSolicitudDeTraslado
            {
                DataSource = ListToDataTableClass.ListToDataTable(listaSolicitudes)
                ,
                RequestParameters = false
            };
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
