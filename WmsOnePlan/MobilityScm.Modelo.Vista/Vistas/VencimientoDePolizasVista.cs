using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Controladores;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Interfaces.Controladores;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Modelo.Servicios;
using MobilityScm.Utilerias;
using MobilityScm.Vertical.Servicios;
using System.Xml.Linq;
using DevExpress.XtraBars;
using DevExpress.XtraReports.UI;
using MobilityScm.Modelo.Estados;
using MobilityScm.Modelo.Popups;
using MobilityScm.Modelo.Tipos;

namespace MobilityScm.Modelo.Vistas
{
    public partial class VencimientoDePolizasVista :  VistaBase, IVencimientoDePolizasVista
    {

        #region Eventos 
        public event EventHandler VistaCargandosePorPrimeraVez;
        public event EventHandler UsuarioDeseaObtenerClientes;
        public event EventHandler<PolizaArgumento> UsuarioDeseaObtenerPolizas;
        #endregion  

        #region Propiedades
        public IList<Poliza> Polizas
        {
            get
            {
                return (IList<Poliza>)UiContenedorVistaPoliza.DataSource;
            }
            set
            {
                UiContenedorVistaPoliza.DataSource = value;
            }
        }

        public IList<Cliente> Clientes
        {
            get
            {
                return (IList<Cliente>)UIListaClientes.Properties.DataSource;
            }

            set
            {
                UIListaClientes.Properties.DataSource = value;
            }
        }

        public IList<Seguridad> Permisos { get; set; }

        public IInteraccionConUsuarioServicio InteraccionConUsuarioServicio { get; set; }
        
        public bool UsuarioSeleccionoListaClientes { get; set; }
        #endregion

        #region Contructor y Eventos de Carga

        public VencimientoDePolizasVista()
        {
            InitializeComponent();

            Mvx.Ioc.RegisterType<IBaseDeDatosServicio, BaseDeDatosServicio>();
            Mvx.Ioc.Resolve<IConfiguracionDeConexion>();
            InteraccionConUsuarioServicio = Mvx.Ioc.Resolve<IInteraccionConUsuarioServicio>();
            Mvx.Ioc.RegisterType<IVencimientoDePolizasServicio, VencimientoDePolizasServicio>();
            Mvx.Ioc.RegisterType<IClienteServicio, ClienteServicio>();
            Mvx.Ioc.RegisterType<ISeguridadServicio, SeguridadServicio>();

            Mvx.Ioc.RegisterSingleton<IVencimientoDePolizasVista, VencimientoDePolizasVista>(this);
            Mvx.Ioc.RegisterType<IVencimientoDePolizasControlador, VencimientoDePolizasControlador>();
            Mvx.Ioc.Resolve<IVencimientoDePolizasControlador>();
        }


        private void VencimientoDePolizasVista_Load(object sender, EventArgs e)
        {
            VistaCargandosePorPrimeraVez?.Invoke(sender, e);
            LimpiarControlesFiltro();
            RevisarPermisosBotonLiberar();
            CargarOGuardarDisenios(UiContenedorVistaPoliza, false, InteraccionConUsuarioServicio.ObtenerUsuario(), GetType().Name);
        }

        #endregion

        #region Eventos de Controles
        private void UIListaClientes_CustomDisplayText(object sender, CustomDisplayTextEventArgs e)
        {
            e.DisplayText = ObtenerTextoAMostrarListaClientes();
        }

        private void UIListaClientes_Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            UsuarioDeseaObtenerClientes?.Invoke(sender, new TareaArgumento());
        }

        private void UiVistaPoliza_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if (e.ControllerRow >= 0)
            {
                SeleccionarFilaPolizas(e.ControllerRow, (e.Action == CollectionChangeAction.Add));
            }
            else
            {
                for (var i = 0; i < UiVistaPoliza.RowCount; i++)
                {
                    SeleccionarFilaPolizas(e.ControllerRow, (UiVistaPoliza.SelectedRowsCount != 0));
                }
            }
        }

        private void UiListaVistaClientes_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if (e.ControllerRow >= 0)
            {
                var cliente = (Cliente)UiListaVistaClientes.GetRow(e.ControllerRow);
                cliente.IS_SELECTED = (e.Action == CollectionChangeAction.Add);
            }
            else
            {
                if (UsuarioSeleccionoListaClientes)
                {
                    for (var i = 0; i < UiListaVistaClientes.RowCount; i++)
                    {
                        var documento = (Cliente)UiListaVistaClientes.GetRow(i);
                        if (documento == null) continue;
                        documento.IS_SELECTED = (UiListaVistaClientes.SelectedRowsCount != 0);
                    }
                    UsuarioSeleccionoListaClientes = false;
                }
            }

            var edit = ActiveControl as SearchLookUpEdit;
            if (edit == null) return;
            edit.Text = ObtenerTextoAMostrarListaClientes();
        }

        private void UiListaVistaClientes_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            for (var i = 0; i < UiListaVistaClientes.RowCount; i++)
            {
                var cliente = (Cliente)UiListaVistaClientes.GetRow(i);
                if (cliente == null) continue;
                if (cliente.IS_SELECTED)
                {
                    UiListaVistaClientes.SelectRow(i);
                }
            }
        }

        private void UiListaVistaClientes_MouseUp(object sender, MouseEventArgs e)
        {
            var view = sender as GridView;
            if (view == null)
                return;
            var hi = view.CalcHitInfo(new Point(e.X, e.Y));
            if ((hi.HitTest == GridHitTest.Column || hi.HitTest == GridHitTest.GroupPanelColumn) && hi.Column.Name.Equals("DX$CheckboxSelectorColumn"))
            {
                UsuarioSeleccionoListaClientes = true;
            }
        }

        private void UiBotonAceptarFiltro_Click(object sender, EventArgs e)
        {
            RealizarBusqueda();
        }

        private void UiSwitchVencidas_Toggled(object sender, EventArgs e)
        {
            BloquearControlesFiltro(UiSwitchVencidas.IsOn);
            LimpiarControlesFiltro();
        }

        private void UiBarButtonExpandir_ItemClick(object sender, ItemClickEventArgs e)
        {
            UiVistaPoliza.ExpandAllGroups();
        }

        private void UiBarButtonColapsar_ItemClick(object sender, ItemClickEventArgs e)
        {
            UiVistaPoliza.CollapseAllGroups();
        }

        private void UiBarButtonExportarExcel_ItemClick(object sender, ItemClickEventArgs e)
        {
            UiVistaPoliza.ShowPrintPreview();
        }

        private void UiBarButtonImprimir_ItemClick(object sender, ItemClickEventArgs e)
        {
            GenerarReporte();
        }

        private void UiBarButtonLiberar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Polizas != null && Polizas.Count(p => p.IS_SELECTED) > 0)
            {
                var popup = new LiberarPolizaPopup(Polizas);
                popup.FormClosing += Popup_FormClosing;
                popup.Show();
            }
            else
            {
                InteraccionConUsuarioServicio.Mensaje("Debe de seleccionar al menos una póliza para liberar.");
            }
        }
        
        #endregion

        #region Metodos

        private void SeleccionarFilaPolizas(int fila, bool seleccionar)
        {
            var poliza = (Poliza)UiVistaPoliza.GetRow(fila);
            if (poliza == null) return;
            if (poliza.BLOCKED_STATUS != EstadoPolizaFiscal.FREE.ToString())
            {
                poliza.IS_SELECTED = seleccionar;
            }
            else
            {
                UiVistaPoliza.UnselectRow(fila);
            }
        }

        private void RealizarBusqueda()
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                var clientesSeleccionados = Clientes.Where(cliente => cliente.IS_SELECTED).Select(cliente => cliente.CLIENT_CODE);
                var clientes = new XDocument();
                clientes.Add(new XElement("Data", clientesSeleccionados.Select(cl => new XElement("CLIENT_CODE", cl))));

                var polizaArgumento = new PolizaArgumento
                {
                    START_DATE = UiFechaInicial.DateTime
                    ,
                    END_DATE = UiFechaFinal.DateTime
                    ,
                    DAYS = (int)UiGrupoRadioFechas.EditValue
                    ,
                    CUSTOMER = clientes.ToString()
                    ,
                    BLOCKED_ONLY = UiSwitchVencidas.IsOn ? (int)SiNo.Si : (int)SiNo.No
                };

                UsuarioDeseaObtenerPolizas?.Invoke(null, polizaArgumento);
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.Mensaje(exception.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private string ObtenerTextoAMostrarListaClientes()
        {
            return Clientes == null ? string.Empty : string.Join(",", Clientes.Where(cl => cl.IS_SELECTED).Select(cl => cl.CLIENT_NAME));
        }

        private void BloquearControlesFiltro(bool bloquear)
        {
            UiGrupoRadioFechas.ReadOnly = bloquear;
            UiFechaInicial.ReadOnly = bloquear;
            UiFechaFinal.ReadOnly = bloquear;
        }

        private void LimpiarControlesFiltro()
        {
            UiGrupoRadioFechas.SelectedIndex = 0;
            UiFechaInicial.EditValue = DateTime.Now.Date;
            UiFechaFinal.EditValue = DateTime.Now;
        }


        private void RevisarPermisosBotonLiberar()
        {
            var permiso = Permisos.FirstOrDefault(p => p.CHECK_ID == OpcionPermisos.UNBLOCK_POLIZAS_EXPIRADAS.ToString());
            UiBarButtonLiberar.Visibility = permiso != null ? BarItemVisibility.Always : BarItemVisibility.Never;
        }

        private void GenerarReporte()
        {
            try
            {
                var listaPolizas = new List<Poliza>();
                for (var i = 0; i < UiVistaPoliza.RowCount; i++)
                {
                    if (!UiVistaPoliza.IsGroupRow(i))
                        listaPolizas.Add((Poliza)UiVistaPoliza.GetRow(i));
                }
                var listaPolizasParaReporte =
                    listaPolizas.GroupBy(
                        b =>
                            new
                            {
                                b.CLIENT_CODE,
                                b.CLIENT_NAME,
                                b.REGIMEN,
                                b.REGIMEN_GROUP,
                                b.FECHA_LLEGADA,
                                b.EXPIRATION_DATE,
                                b.DAYS_FOR_LOCKING,
                                b.TIME_BLOCKED,
                                b.QTY,
                                b.TOTAL_VALUE,
                                b.DESCRIPTION_STATUS,
                                b.UNLOCK_DATE,
                                b.UNLOCK_DOCUMENT,
                                b.UNLOCK_USER,
                                b.DOC_ID
                            }).Select(b => new Poliza
                            {
                                CLIENT_CODE = b.Key.CLIENT_CODE,
                                CLIENT_NAME = b.Key.CLIENT_NAME,
                                REGIMEN = b.Key.REGIMEN,
                                REGIMEN_GROUP = b.Key.REGIMEN_GROUP,
                                FECHA_LLEGADA = b.Key.FECHA_LLEGADA,
                                EXPIRATION_DATE = b.Key.EXPIRATION_DATE,
                                DAYS_FOR_LOCKING = b.Key.DAYS_FOR_LOCKING,
                                TIME_BLOCKED = b.Key.TIME_BLOCKED,
                                QTY = b.Key.QTY,
                                TOTAL_VALUE = b.Key.TOTAL_VALUE,
                                DESCRIPTION_STATUS = b.Key.DESCRIPTION_STATUS,
                                UNLOCK_DATE = b.Key.UNLOCK_DATE,
                                UNLOCK_DOCUMENT = b.Key.UNLOCK_DOCUMENT,
                                UNLOCK_USER = b.Key.UNLOCK_USER,
                                DOC_ID = b.Key.DOC_ID
                            }).ToList();

                var reporte = new Reportes.PolizasVencidas
                {
                    DataSource = ListToDataTableClass.ListToDataTable(listaPolizasParaReporte),
                    DataMember = "Polizas",
                    RequestParameters = false
                };
                reporte.Parameters["ImagenLogo"].Value = InteraccionConUsuarioServicio.ObtenerLogo();
                reporte.Parameters["Usuario"].Value = InteraccionConUsuarioServicio.ObtenerNombreUsuario();
                reporte.FillDataSource();

                using (var printTool = new ReportPrintTool(reporte))
                {
                    printTool.ShowRibbonPreviewDialog();
                }

            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void Popup_FormClosing(object sender, FormClosingEventArgs e)
        {
            RealizarBusqueda();
        }
        #endregion


    }
}
