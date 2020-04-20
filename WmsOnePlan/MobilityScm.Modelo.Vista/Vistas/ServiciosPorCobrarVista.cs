using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPivotGrid;
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
    public partial class ServiciosPorCobrarVista : VistaBase, IServicioPorCobrarVista
    {
        #region Eventos
        public event EventHandler<ServicioPorCobrarArgumento> UsuarioDeseaGuardarCambioDePrecio;
        public event EventHandler<ServicioPorCobrarArgumento> UsuarioDeseaCargarServiciosPorCobrarPorFecha;
        public event EventHandler<ServicioPorCobrarArgumento> UsuarioDeseaEjecutarProcesoAlMomento;
        public event EventHandler<ServicioPorCobrarArgumento> UsuarioDeseaMarcarComoCobrado;
        public event EventHandler VistaTerminoDeCargarPorPrimeraVez;
        #endregion

        #region Propiedades


        public IList<ServicioPorCobrar> ListaDeServiciosPorCobrar
        {
            get
            {
                return (IList<ServicioPorCobrar>)UiContenedorVistasEdicion.DataSource;
            }
            set
            {
                UiPivotGridVistaGeneral.DataSource = value;
                UiContenedorVistasEdicion.DataSource = value;
            }
        }

        public IList<Cliente> Clientes
        {
            get { return (IList<Cliente>)UiListaDeCliente.Properties.DataSource; }

            set
            {
                UiListaDeCliente.Properties.DataSource = value;

            }
        }

        public string Usuario { get; set; }

        #endregion

        #region Constructor y Carga

        public ServiciosPorCobrarVista()
        {
            InitializeComponent();
            Mvx.Ioc.RegisterType<IBaseDeDatosServicio, BaseDeDatosServicio>();
            Mvx.Ioc.Resolve<IConfiguracionDeConexion>();
            Mvx.Ioc.Resolve<IInteraccionConUsuarioServicio>();
            Mvx.Ioc.RegisterType<IServiciosPorCobrarServicio, ServiciosPorCobrarServicio>();
            Mvx.Ioc.RegisterType<IClienteServicio, ClienteServicio>();
            Mvx.Ioc.RegisterSingleton<IServicioPorCobrarVista, ServiciosPorCobrarVista>(this);
            Mvx.Ioc.RegisterType<IServicioPorCobrarControlador, ServicioPorCobrarControlador>();
            Mvx.Ioc.Resolve<IServicioPorCobrarControlador>();
        }

        private void ServiciosPorCobrar_Load(object sender, EventArgs e)
        {
            UiFechaInicio.EditValue = DateTime.Today;
            UiFechaFinal.EditValue = DateTime.Today;
            VistaTerminoDeCargarPorPrimeraVez?.Invoke(sender, e);
            UiListaDeCliente.Properties.PopupFormWidth = UiListaDeCliente.Width;
            CargarOGuardarDisenios(UiPivotGridVistaGeneral, false, Usuario, GetType().Name);
            CargarOGuardarDisenios(UiContenedorVistasEdicion, false, Usuario, GetType().Name);
        }

        private void UiListaDeCliente_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            StringBuilder cadena = new StringBuilder();
            foreach (var cliente in UiListaDeCliente.Properties.View.GetSelectedRows().Select(indice => (Cliente)UiListaDeCliente.Properties.View.GetRow(indice)))
            {
                if (cadena.Length > 0) { cadena.Append(","); }
                cadena.Append(cliente.CLIENT_CODE);
            }
            e.DisplayText = cadena.ToString();
        }

        private void UiListaDeCliente_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            var edit = ActiveControl as GridLookUpEdit;
            if (edit == null) return;
            StringBuilder cadena = new StringBuilder();
            foreach (var cliente in UiListaDeCliente.Properties.View.GetSelectedRows().Select(indice => (Cliente)UiListaDeCliente.Properties.View.GetRow(indice)))
            {
                if (cadena.Length > 0) { cadena.Append(","); }
                cadena.Append(cliente.CLIENT_CODE);
            }
            edit.Text = cadena.ToString();
        }

        #endregion

        #region Eventos de Controles
        private void UiBotonRefrescar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            var servicioPorCobrar = new ServicioPorCobrar { CLIENT_CODE = ObtenerClientesSeleccionados() };
            if (!UiSwiftIncluirServiciosCobrados.Checked)
            {
                servicioPorCobrar.IS_CHARGED = 0;
            }

            UsuarioDeseaCargarServiciosPorCobrarPorFecha?.Invoke(sender, new ServicioPorCobrarArgumento { FechaInicio = DateTime.Parse(UiFechaInicio.EditValue.ToString()), FechaFinal = DateTime.Parse(UiFechaFinal.EditValue.ToString()), ServicioPorCobrar = servicioPorCobrar });
        }

        private void UiVistaEdicion_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            var servicio = (ServicioPorCobrar)e.Row;
            foreach (var servicioPorCobrar in ListaDeServiciosPorCobrar.Where(servicioPorCobrar => servicio.SERVICES_TO_BILL_ID == servicioPorCobrar.SERVICES_TO_BILL_ID))
            {
                servicioPorCobrar.TOTAL_AMOUNT = (servicio.PRICE_TO_CHANGE * servicio.QTY);
                break;
            }
            UiPivotGridVistaGeneral.DataSource = ListaDeServiciosPorCobrar.ToList();
            UiPivotGridVistaGeneral.Refresh();
        }

        private void UiBotonRestablecerPrecio_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RestablecerPrecios();
        }

        private void UiBotonGuardarEdicion_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UsuarioDeseaGuardarCambiosDePrecio();
        }

        private void UiBotonMarcarCobrados_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UsuarioDeseaMarcarComoCobrados();
        }

        private void UiBotonEjecutarPrecesoDeServicio_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UsuarioDeseaEjecutarProcesoAlMomento?.Invoke(sender, new ServicioPorCobrarArgumento());
        }

        private void UiBotonExpandirConsulta_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UiPivotGridVistaGeneral.ExpandAll();
        }

        private void UiBotonContraerConsulta_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UiPivotGridVistaGeneral.CollapseAll();
        }

        private void UiBotonExpandirEdicion_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UiVistaEdicion.ExpandAllGroups();
        }

        private void UiBotonContraerEdicion_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UiVistaEdicion.CollapseAllGroups();
        }
        private void ServiciosPorCobrarVista_FormClosing(object sender, FormClosingEventArgs e)
        {
            CargarOGuardarDisenios(UiPivotGridVistaGeneral, true, Usuario, GetType().Name);
            CargarOGuardarDisenios(UiContenedorVistasEdicion, true, Usuario, GetType().Name);
        }

        #endregion

        #region Metodos

        private void RestablecerPrecios()
        {
            foreach (var servicio in ListaDeServiciosPorCobrar)
            {
                servicio.PRICE_TO_CHANGE = servicio.PRICE;
            }

            UiPivotGridVistaGeneral.DataSource = ListaDeServiciosPorCobrar.ToList();
            UiPivotGridVistaGeneral.Refresh();

            UiContenedorVistasEdicion.DataSource = ListaDeServiciosPorCobrar.ToList();
            UiContenedorVistasEdicion.Refresh();
            UiVistaEdicion.ExpandAllGroups();
        }

        private void UsuarioDeseaGuardarCambiosDePrecio()
        {
            UsuarioDeseaGuardarCambioDePrecio?.Invoke(null, new ServicioPorCobrarArgumento { ListaDeServiciosPorCobrar = ListaDeServiciosPorCobrar.ToList() });
            var servicioPorCobrar = new ServicioPorCobrar { CLIENT_CODE = ObtenerClientesSeleccionados() };
            if (!UiSwiftIncluirServiciosCobrados.Checked)
            {
                servicioPorCobrar.IS_CHARGED = 0;
            }

            UsuarioDeseaCargarServiciosPorCobrarPorFecha?.Invoke(null, new ServicioPorCobrarArgumento { FechaInicio = DateTime.Parse(UiFechaInicio.EditValue.ToString()), FechaFinal = DateTime.Parse(UiFechaFinal.EditValue.ToString()), ServicioPorCobrar = servicioPorCobrar });
            UiVistaEdicion.ExpandAllGroups();
        }

        private void UsuarioDeseaMarcarComoCobrados()
        {
            var lista = new List<ServicioPorCobrar>();
            foreach (var servicio in UiVistaEdicion.GetSelectedRows().Select(indice => (ServicioPorCobrar)UiVistaEdicion.GetRow(indice)).Where(servicio => servicio.IS_CHARGED == 0))
            {
                servicio.IS_CHARGED = 1;
                servicio.CHARGED_DATE = DateTime.Today;
                lista.Add(servicio);
            }
            UsuarioDeseaMarcarComoCobrado?.Invoke(null, new ServicioPorCobrarArgumento { ListaDeServiciosPorCobrar = lista });
            var servicioPorCobrar = new ServicioPorCobrar { CLIENT_CODE = ObtenerClientesSeleccionados() };
            if (!UiSwiftIncluirServiciosCobrados.Checked)
            {
                servicioPorCobrar.IS_CHARGED = 0;
            }

            UsuarioDeseaCargarServiciosPorCobrarPorFecha?.Invoke(null, new ServicioPorCobrarArgumento { FechaInicio = DateTime.Parse(UiFechaInicio.EditValue.ToString()), FechaFinal = DateTime.Parse(UiFechaFinal.EditValue.ToString()), ServicioPorCobrar = servicioPorCobrar });
            UiVistaEdicion.ExpandAllGroups();
        }

        private void UiVistaEdicion_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            var servicio = (ServicioPorCobrar)UiVistaEdicion.GetRow(e.ControllerRow);
            if (servicio?.IS_CHARGED == 1)
            {
                UiVistaEdicion.UnselectRow(e.ControllerRow);
            }
        }

        private void UiVistaEdicion_ShowingEditor(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var vista = (GridView)sender;
            var servicio = (ServicioPorCobrar)vista.GetRow(vista.FocusedRowHandle);

            e.Cancel = servicio.IS_CHARGED == 1;
        }

        private string ObtenerClientesSeleccionados()
        {
            var cadenaCliente = new StringBuilder();
            foreach (var cliente in UiListaDeCliente.Properties.View.GetSelectedRows().Select(indice => (Cliente)UiListaDeCliente.Properties.View.GetRow(indice)))
            {
                if (cadenaCliente.Length > 0) { cadenaCliente.Append("|"); }
                cadenaCliente.Append(cliente.CLIENT_CODE);
            }
            return cadenaCliente.ToString();
        }


        #endregion

        private void UiVistaEdicion_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            ColumnView view = sender as ColumnView;
            if ((e.Column.FieldName == "TOTAL_AMOUNT" || e.Column.FieldName == "PRICE_TO_CHANGE") &&
                e.ListSourceRowIndex != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
            {
                decimal price = Convert.ToDecimal(e.Value);
                string currencyType = (string)view.GetListSourceRowCellValue(e.ListSourceRowIndex, "CURRENCY");
                e.DisplayText = currencyType + " " + price;

            }
        }

        private void UiPivotGridVistaGeneral_CustomCellDisplayText(object sender, DevExpress.XtraPivotGrid.PivotCellDisplayTextEventArgs e)
        {

            //if (e.Value != null && (e.DataField.Name == "UiPivotPRICE" || e.DataField.Name == "UiPivotTOTAL_AMOUNT"))
            //{
            //    e.DisplayText = (e.GetFieldValue(UiPivotCurrency) == null ? "" : e.GetFieldValue(UiPivotCurrency).ToString()) + e.Value;
            //}
        }
    }

}

