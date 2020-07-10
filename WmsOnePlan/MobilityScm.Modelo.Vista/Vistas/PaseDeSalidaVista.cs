using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraReports.UI;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Controladores;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Estados;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Modelo.Servicios;
using MobilityScm.Modelo.Tipos;
using MobilityScm.Utilerias;
using MobilityScm.Vertical.Servicios;

namespace MobilityScm.Modelo.Vistas
{
    public partial class PaseDeSalidaVista : VistaBase, IPaseDeSalidaVista
    {

        #region Eventos

        public event EventHandler<PaseDeSalidaArgumento> UsuarioDeseaAnularPaseDeSalida;
        public event EventHandler<PaseDeSalidaArgumento> UsuarioDeseaGrabar;
        public event EventHandler<PaseDeSalidaArgumento> UsuarioDeseaObtenerDespachos;
        public event EventHandler<PaseDeSalidaArgumento> UsuarioDeseaObtenerEntregas;
        public event EventHandler<PaseDeSalidaArgumento> UsuarioDeseaObtnerAutorizados;
        public event EventHandler VistaCargandosePorPrimeraVez;
        public event EventHandler<PaseDeSalidaArgumento> UsuarioDeseaObtenerClientes;
        public event EventHandler<PaseDeSalidaArgumento> UsuarioDeseaObtenerTipos;
        public event EventHandler<PaseDeSalidaArgumento> UsuarioDeseaObtenerVehiculos;
        public event EventHandler<PaseDeSalidaArgumento> UsuarioDeseaObtenerBodegas;
        public event EventHandler<PaseDeSalidaArgumento> UsuarioDeseaObtnerPaseDeSalida;
        public event EventHandler<PaseDeSalidaArgumento> UsuarioDeseaObtenerDetalleDeDespachos;
        public event EventHandler<PaseDeSalidaArgumento> UsuarioDeseaObtenerPaseDeSalida;
        public event EventHandler<PaseDeSalidaArgumento> UsuarioDeseaCambiarEstadoAlPase;
        public event EventHandler<PaseDeSalidaArgumento> UsuarioDeseaObtenerPaseParaReporte;
        public event EventHandler<PaseDeSalidaArgumento> UsuarioDeseaObtenerSoloVehiculos;
        public event EventHandler<PaseDeSalidaArgumento> UsuarioDeseaGrabarVehiculo;
        public event EventHandler<PaseDeSalidaArgumento> UsuarioDeseaObtenerPilotos;
        public event EventHandler<PaseDeSalidaArgumento> UsuarioDeseaGrabarPiloto;
        public event EventHandler<PaseDeSalidaArgumento> UsuarioDeseaObtenerTipoSalida;
        #endregion

        #region Propieades

        public IList<Cliente> Clientes
        {
            get { return (IList<Cliente>)UiListaCliente.Properties.DataSource; }

            set { UiListaCliente.Properties.DataSource = value; }
        }

        public IList<Vehiculo> Vehiculos
        {
            get { return (IList<Vehiculo>)UiListaVehiculo.Properties.DataSource; }

            set { UiListaVehiculo.Properties.DataSource = value; }
        }


        public IList<Bodega> Bodegas
        {
            get { return (IList<Bodega>)UiListaBodega.Properties.DataSource; }

            set { UiListaBodega.Properties.DataSource = value; }
        }

        public IList<Usuario> UsuariosParaAutorizar
        {
            get { return (IList<Usuario>)UiListaAutorizadoPor.Properties.DataSource; }

            set { UiListaAutorizadoPor.Properties.DataSource = value; }
        }

        public IList<Usuario> UsuariosParaEntrega
        {
            get { return (IList<Usuario>)UiListaEntregadoPor.Properties.DataSource; }

            set { UiListaEntregadoPor.Properties.DataSource = value; }
        }

        public IList<DemandaDespachoHeader> DespachoEncabezados
        {
            get { return (IList<DemandaDespachoHeader>)UiListaDespachos.Properties.DataSource; }

            set { UiListaDespachos.Properties.DataSource = value; }
        }

        public IList<DemandaDespachoDetalle> DespachosDetalles
        {
            get { return (IList<DemandaDespachoDetalle>)UiVistasDeDetalle.DataSource; }

            set { UiVistasDeDetalle.DataSource = value; UiVistasDeDetalle.Refresh(); }
        }

        public IList<PaseDeSalida> PaseDeSalidas { get; set; }

        public IList<Parametro> Parametros { get; set; }
        public IList<Entidades.Configuracion> TipoSalida { get; set; }
        private bool UsuarioSeleccionoListaDeDespachosEncabezadosCompleta { get; set; }

        private bool UsuarioSeleccionoListaDeDespachosDetallesCompleta { get; set; }

        public IInteraccionConUsuarioServicio InteraccionConUsuarioServicio { get; private set; }

        public IList<Vehiculo> SoloVehiculos
        {
            get { return (IList<Vehiculo>)UiListaSoloVehiculo.Properties.DataSource; }

            set { UiListaSoloVehiculo.Properties.DataSource = value; }
        }

        public IList<Piloto> Pilotos
        {
            get { return (IList<Piloto>)UiListaPilotos.Properties.DataSource; }

            set { UiListaPilotos.Properties.DataSource = value; }
        }     

        #endregion

        #region Inicializacion
        public PaseDeSalidaVista()
        {
            InitializeComponent();
            InteraccionConUsuarioServicio = Mvx.Ioc.Resolve<IInteraccionConUsuarioServicio>();
            Mvx.Ioc.RegisterType<IBaseDeDatosServicio, BaseDeDatosServicio>();
            Mvx.Ioc.Resolve<IConfiguracionDeConexion>();
            Mvx.Ioc.RegisterType<IClienteServicio, ClienteServicio>();
            Mvx.Ioc.RegisterType<IVehiculoServicio, VehiculoServicio>();
            Mvx.Ioc.RegisterType<IUsuarioServicio, UsuarioServicio>();
            Mvx.Ioc.RegisterType<IBodegaServicio, BodegaServicio>();
            Mvx.Ioc.RegisterType<IParametroServicio, ParametroServicio>();
            Mvx.Ioc.RegisterType<IDemandaDeDespachoServicio, DemandaDeDespachoServicio>();
            Mvx.Ioc.RegisterType<IPaseDeSalidaServicio, PaseDeSalidaServicio>();
            Mvx.Ioc.RegisterType<IPilotoServicio, PilotoServicio>();
            Mvx.Ioc.RegisterType<IPaseDeSalidaControlador, PaseDeSalidaControlador>();
            Mvx.Ioc.RegisterSingleton<IPaseDeSalidaVista, PaseDeSalidaVista>(this);
            Mvx.Ioc.RegisterType<IConfiguracionServicio, ConfiguracionServicio>();
            Mvx.Ioc.Resolve<IPaseDeSalidaControlador>();
        }

        private void PaseDeSalidaVista_Load(object sender, EventArgs e)
        {
            try
            {
                VistaCargandosePorPrimeraVez?.Invoke(sender, e);

                UiListaTipo.Properties.DataSource = TipoSalida;
                UiListaTipo.Properties.ValueMember = "PARAM_NAME";
                UiListaTipo.Properties.DisplayMember = "PARAM_CAPTION";


                //CargarOGuardarDisenios(UiVistasDeDetalle, false, InteraccionConUsuarioServicio.ObtenerUsuario(), GetType().Name);
                var parametroTipoDespacho = Parametros.FirstOrDefault(p => p.PARAMETER_ID == Enums.GetStringValue(IdParametro.ObtieneTipoDeDemanda) && p.GROUP_ID == Enums.GetStringValue(GrupoParametro.DemandaDePicking));
                var mostrarTipoDespacho = (parametroTipoDespacho != null && int.Parse(parametroTipoDespacho.VALUE) == (int)SiNo.Si);                

                UiColListaCodigoTipoDespacho.Visible = mostrarTipoDespacho;
                UiColListaCodigoTipoDespacho.OptionsColumn.ShowInCustomizationForm = mostrarTipoDespacho;
                UiColListaNombreTipoDespacho.Visible = mostrarTipoDespacho;
                UiColListaNombreTipoDespacho.OptionsColumn.ShowInCustomizationForm = mostrarTipoDespacho;
                UiColVistaCodigoTipoDespacho.Visible = mostrarTipoDespacho;
                UiColVistaCodigoTipoDespacho.OptionsColumn.ShowInCustomizationForm = mostrarTipoDespacho;
                UiColVistaNombreTipoDespacho.Visible = mostrarTipoDespacho;
                UiColVistaNombreTipoDespacho.OptionsColumn.ShowInCustomizationForm = mostrarTipoDespacho;

                UiFechaInicial.EditValue = DateTime.Now.Date.AddMonths(-1) + (new TimeSpan(0, 0, 0));
                UiFechaFinal.EditValue = DateTime.Now.Date.AddMonths(1) + (new TimeSpan(23, 59, 59));

                var parametroPaseDeSalida = Parametros.FirstOrDefault(p => p.PARAMETER_ID == Enums.GetStringValue(IdParametro.InsertarOActualizarVehiculoYPiloto) && p.GROUP_ID == Enums.GetStringValue(GrupoParametro.Pase));
                var mostrarListaDePilotos = (parametroPaseDeSalida != null && int.Parse(parametroPaseDeSalida.VALUE) == (int)SiNo.Si);
                UiLayoutObjetoListaDeVehiculos.Visibility = (!mostrarListaDePilotos)
                    ? LayoutVisibility.Always
                    : LayoutVisibility.Never; ;
                UiLayoutObjetoListaDeSoloVehiculos.Visibility = (mostrarListaDePilotos)
                    ? LayoutVisibility.Always
                    : LayoutVisibility.Never;
                UiLayoutObjetoListaDePilotos.Visibility = (mostrarListaDePilotos)
                    ? LayoutVisibility.Always
                    : LayoutVisibility.Never;
                SeleccionarPrimerRegistroDeLasListas();
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo($"Error al cargar la pantalla: {ex.Message}");
            }
        }
        private void SeleccionarPrimerRegistroDeLasListas()
        {
            try
            {
                var cliente = Clientes.FirstOrDefault();
                if (cliente != null) UiListaCliente.EditValue = cliente.CLIENT_CODE;

                var vehiculo = Vehiculos.FirstOrDefault();
                if (vehiculo != null) UiListaVehiculo.EditValue = vehiculo.VEHICLE_CODE;

                var soloVehiculo = SoloVehiculos.FirstOrDefault();
                if (soloVehiculo != null) UiListaSoloVehiculo.EditValue = soloVehiculo.VEHICLE_CODE;

                var pilotos = SoloVehiculos.FirstOrDefault();
                if (pilotos != null) UiListaPilotos.EditValue = pilotos.PILOT_CODE;

                var bodega = Bodegas.FirstOrDefault();
                if (bodega != null) UiListaBodega.EditValue = bodega.WAREHOUSE_ID;

                var usuariosParaEntrega = UsuariosParaEntrega.FirstOrDefault();
                if (usuariosParaEntrega != null) UiListaEntregadoPor.EditValue = usuariosParaEntrega.LOGIN_ID;

                UiListaAutorizadoPor.EditValue = InteraccionConUsuarioServicio.ObtenerUsuario();
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo($"Error al seleccionar el primero en las listas: {ex.Message}");
            }
        }

        private void UiListaDespachos_QueryPopUp(object sender, CancelEventArgs e)
        {
            var lista = (SearchLookUpEdit)sender;
            if (lista == null) return;
            lista.Properties.PopupFormWidth = UiListaDespachos.Width - 15;
        }

        #endregion

        #region Eventos

        private void UiListaDespachos_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if (e.Button.Tag == null) return;
                switch (e.Button.Tag.ToString())
                {
                    case "UiBotonRefrescarClientes":
                        UsuarioDeseaObtenerClientes?.Invoke(null, new PaseDeSalidaArgumento());
                        break;
                    case "UiBotonRefrescarVehiculos":
                        UsuarioDeseaObtenerVehiculos?.Invoke(null, new PaseDeSalidaArgumento());
                        break;
                    case "UiBotonRefrescarBodega":
                        UsuarioDeseaObtenerBodegas?.Invoke(null, new PaseDeSalidaArgumento());
                        break;
                    case "UiBotonRefrescarAutorizado":
                        UsuarioDeseaObtnerAutorizados?.Invoke(null, new PaseDeSalidaArgumento());
                        break;
                    case "UiBotonRefrescarEntregado":
                        UsuarioDeseaObtenerEntregas?.Invoke(null, new PaseDeSalidaArgumento());
                        break;
                    case "UiBotonRefrescarDespachos":
                        ObtenerDemandasDeDespacho();
                        break;
                    case "UiBotonAgregarDetalle":
                        UsuarioDeseaObtenerLosDetallesDeDespacho();
                        break;
                    case "UiBotonBuscarPase":
                        var spinEdit = sender as SpinEdit;
                        if (spinEdit != null)
                        {
                            int paseDeSalida = int.Parse(spinEdit.Value.ToString(CultureInfo.InvariantCulture));
                            ObtenerPaseDeSalida(paseDeSalida);
                        }
                        break;
                    case "UiBotonSoloVehiculoRefrescar":
                        UsuarioDeseaObtenerSoloVehiculos?.Invoke(null, new PaseDeSalidaArgumento());
                        break;
                    case "UiBotonIngresarOEditarVehiculo":
                        UiPopupVehiculo.Visible = !UiPopupVehiculo.Visible;
                        UiPopupPiloto.Visible = false;
                        EstablecerVehiculoSeleccionado();
                        break;
                    case "UiBotonPilotoRefrescar":
                        UsuarioDeseaObtenerPilotos?.Invoke(null, new PaseDeSalidaArgumento());
                        break;
                    case "UiBotonInsetarOEditarPiloto":
                        UiPopupPiloto.Visible = !UiPopupPiloto.Visible;
                        UiPopupVehiculo.Visible = false;
                        EstablecerPilotoSeleccionado();
                        break;
                }

            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo($"Error al refrescar o agregar: {ex.Message}");
            }
        }

        private void UiVistaListaDespachos_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null)
                return;


            GridHitInfo hi = view.CalcHitInfo(new System.Drawing.Point(e.X, e.Y));
            if ((hi.HitTest == GridHitTest.Column || hi.HitTest == GridHitTest.GroupPanelColumn) &&
                hi.Column.Name.Equals("DX$CheckboxSelectorColumn"))
            {
                UsuarioSeleccionoListaDeDespachosEncabezadosCompleta = true;
            }
        }

        private void UiVistaListaDespachos_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if (e.ControllerRow >= 0)
            {
                var registro = (DemandaDespachoHeader)UiVistaListaDespachos.GetRow(e.ControllerRow);
                registro.IS_SELECTED = (e.Action == CollectionChangeAction.Add);
            }
            else
            {
                if (UsuarioSeleccionoListaDeDespachosEncabezadosCompleta)
                {
                    for (var i = 0; i < UiVistaListaDespachos.RowCount; i++)
                    {
                        var registro = (DemandaDespachoHeader)UiVistaListaDespachos.GetRow(i);
                        if (registro == null) continue;
                        registro.IS_SELECTED = (UiVistaListaDespachos.SelectedRowsCount != 0);
                    }
                    UsuarioSeleccionoListaDeDespachosEncabezadosCompleta = false;
                }
            }

            var edit = UiListaDespachos;
            if (edit == null) return;
            edit.Text = ObtenerTextoAMostrarListaDeDespachosEncabezados();
        }

        private void UiVistaListaDespachos_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            for (var i = 0; i < UiVistaListaDespachos.RowCount; i++)
            {
                var registro = (DemandaDespachoHeader)UiVistaListaDespachos.GetRow(i);
                if (registro == null) continue;
                if (registro.IS_SELECTED)
                {
                    UiVistaListaDespachos.SelectRow(i);
                }
            }
        }

        private void UiListaDespachos_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            e.DisplayText = ObtenerTextoAMostrarListaDeDespachosEncabezados();
        }

        private void UiVistaDespacho_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null)
                return;


            GridHitInfo hi = view.CalcHitInfo(new System.Drawing.Point(e.X, e.Y));
            if ((hi.HitTest == GridHitTest.Column || hi.HitTest == GridHitTest.GroupPanelColumn) &&
                hi.Column.Name.Equals("DX$CheckboxSelectorColumn"))
            {
                UsuarioSeleccionoListaDeDespachosDetallesCompleta = true;
            }
        }

        private void UiVistaDespacho_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if (e.ControllerRow >= 0)
            {
                var documento = (DemandaDespachoDetalle)UiVistaDespacho.GetRow(e.ControllerRow);
                documento.IS_SELECTED = (e.Action == CollectionChangeAction.Add);
            }
            else
            {
                if (!UsuarioSeleccionoListaDeDespachosDetallesCompleta) return;
                for (var i = 0; i < UiVistaDespacho.RowCount; i++)
                {
                    var documento = (DemandaDespachoDetalle)UiVistaDespacho.GetRow(i);
                    if (documento == null) continue;
                    documento.IS_SELECTED = (UiVistaDespacho.SelectedRowsCount != 0);
                }
                UsuarioSeleccionoListaDeDespachosDetallesCompleta = false;
            }
        }

        private void UiVistaDespacho_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            MarcarDetallesDeDespachosSeleccionado();
        }

        private void UiVistaDespacho_ColumnFilterChanged(object sender, EventArgs e)
        {
            MarcarDetallesDeDespachosSeleccionado();
        }


        private void UiBotonExpandir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UiVistaDespacho.ExpandAllGroups();
        }

        private void UiBotonContraer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UiVistaDespacho.CollapseAllGroups();
        }

        private void UiBotonGrabar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Grabar();
        }

        private void UiBotonEliminarDetalle_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            EliminarDetalle();
        }


        private void UiVistaDespacho_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            var view = sender as GridView;
            if (view == null || view.FocusedColumn.FieldName != "QTY") return;

            var registro = (DemandaDespachoDetalle)UiVistaDespacho.GetRow(view.FocusedRowHandle);

            try
            {
                var qty = decimal.Parse(e.Value.ToString());
                if (qty > registro.QTY_AVAILABLE || qty < 0)
                {

                    e.Valid = false;
                    e.ErrorText = "La cantidad sobrepasa la cantidad disponible o tiene que ser mayor a cero.";
                    return;
                }
            }
            catch (Exception)
            {
                e.Valid = false;
                e.ErrorText = "Cantidad inválida.";
            }
        }

        private void UiSpinBuscarPaseDeSalida_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var spinEdit = sender as SpinEdit;
                if (spinEdit != null)
                {
                    int paseDeSalida = int.Parse(spinEdit.Value.ToString(CultureInfo.InvariantCulture));
                    ObtenerPaseDeSalida(paseDeSalida);
                }
            }
        }

        private void UiBotonLimpiarDatos_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LimpiarControles();
        }

        private void PaseDeSalidaVista_FormClosing(object sender, FormClosingEventArgs e)
        {
            CargarOGuardarDisenios(UiVistasDeDetalle, true, InteraccionConUsuarioServicio.ObtenerUsuario(), GetType().Name);
        }

        private void UiListaTipo_EditValueChanged(object sender, EventArgs e)
        {
            DespachoEncabezados = new List<DemandaDespachoHeader>();
        }

        private void UiBotonAnularPaseDeSalida_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UsuarioDeseaAnularElPase();
        }

        private void UiBotonImprimir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UsuarioDeseaImprimirReporte();
        }

        private void UiBotonCerrarPopupVehiculo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UiPopupVehiculo.Visible = false;
        }

        private void UiBotonNuevoVehiculo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LimpiarControlesDeVehiculo();
        }

        private void UiBotonCerrarPopupPiloto_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UiPopupPiloto.Visible = false;
        }

        private void UiBotonNuevoPiloto_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LimpiarControlesDePiloto();
        }

        private void UiBotonGrabarVehiculo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GrabarVehiculo();
        }

        private void UiBotonGrabarPiloto_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GrabarPiloto();
        }

        #endregion

        #region Metodos

        private void MarcarDetallesDeDespachosSeleccionado()
        {
            try
            {
                for (var i = 0; i < UiVistaDespacho.RowCount; i++)
                {
                    var documento = (DemandaDespachoDetalle)UiVistaDespacho.GetRow(i);
                    if (documento == null) continue;
                    if (documento.IS_SELECTED)
                    {
                        UiVistaDespacho.SelectRow(i);
                    }
                }
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo($"Error al marcar detalle selecionado: {ex.Message}");
            }
        }


        private string ObtenerTextoAMostrarListaDeDespachosEncabezados()
        {
            if (DespachoEncabezados == null) return "";
            var cadena = new StringBuilder();
            foreach (var documento in DespachoEncabezados.Where(doc => doc.IS_SELECTED))
            {
                if (cadena.Length > 0)
                {
                    cadena.Append(",");
                }

                cadena.Append(UiListaTipo.EditValue.ToString()
                            .Equals(
                                Enums.GetStringValue(TipoDeDespachoParaPaseDeSalida.DespachoGeneral))
                            ? documento.WAVE_PICKING_ID.ToString()
                            : (documento.PICKING_DEMAND_HEADER_ID + "|" + documento.DOC_NUM + "|" + documento.ERP_REFERENCE));
            }

            return cadena.ToString();
        }

        private bool Validar()
        {
            var validacion = true;
            try
            {
                UiListaDespachos.Focus();
                UiError.SetError(UiListaCliente, "", ErrorType.None);
                UiError.SetError(UiListaTipo, "", ErrorType.None);
                UiError.SetError(UiListaVehiculo, "", ErrorType.None);
                UiError.SetError(UiGroupRadioEstadoVehiculo, "", ErrorType.None);
                UiError.SetError(UiListaAutorizadoPor, "", ErrorType.None);
                UiError.SetError(UiListaEntregadoPor, "", ErrorType.None);
                UiError.SetError(UiVistasDeDetalle, "", ErrorType.None);

                UiError.SetError(UiListaSoloVehiculo, "", ErrorType.None);
                UiError.SetError(UiListaPilotos, "", ErrorType.None);

                if (UiListaCliente.EditValue == null)
                {
                    UiError.SetError(UiListaCliente, "Dato Obligatorio", ErrorType.Critical);
                    validacion = false;
                }
                if (UiListaTipo.EditValue == null)
                {
                    UiError.SetError(UiListaTipo, "Dato Obligatorio", ErrorType.Critical);
                    validacion = false;
                }

                var parametroPaseDeSalida = Parametros.FirstOrDefault(p => p.PARAMETER_ID == Enums.GetStringValue(IdParametro.InsertarOActualizarVehiculoYPiloto) && p.GROUP_ID == Enums.GetStringValue(GrupoParametro.Pase));
                var mostrarListaDePilotos = (parametroPaseDeSalida != null && int.Parse(parametroPaseDeSalida.VALUE) == (int)SiNo.Si);

                if (mostrarListaDePilotos)
                {

                    if (UiListaSoloVehiculo.EditValue == null)
                    {
                        UiError.SetError(UiListaVehiculo, "Dato Obligatorio", ErrorType.Critical);
                        validacion = false;
                    }

                    if (UiListaPilotos.EditValue == null)
                    {
                        UiError.SetError(UiListaVehiculo, "Dato Obligatorio", ErrorType.Critical);
                        validacion = false;
                    }
                }
                else
                {
                    if (UiListaVehiculo.EditValue == null)
                    {
                        UiError.SetError(UiListaVehiculo, "Dato Obligatorio", ErrorType.Critical);
                        validacion = false;
                    }
                }


                if (UiGroupRadioEstadoVehiculo.EditValue == null)
                {
                    UiError.SetError(UiGroupRadioEstadoVehiculo, "Dato Obligatorio", ErrorType.Critical);
                    validacion = false;
                }
                if (UiListaAutorizadoPor.EditValue == null)
                {
                    UiError.SetError(UiListaAutorizadoPor, "Dato Obligatorio", ErrorType.Critical);
                    validacion = false;
                }
                if (UiListaEntregadoPor.EditValue == null)
                {
                    UiError.SetError(UiListaEntregadoPor, "Dato Obligatorio", ErrorType.Critical);
                    validacion = false;
                }

                if (!UiVistasDeDetalle.MainView.ValidateEditor())
                {
                    UiError.SetError(UiVistasDeDetalle, "Dato Obligatorio", ErrorType.Critical);
                    validacion = false;
                }


            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(ex.Message);
                validacion = false;
            }

            return validacion;
        }


        private bool ExisteRegistro(int valor)
        {
            return valor != 0;
        }

        private bool ValidarRangoDeFechas()
        {
            var validacion = true;
            try
            {
                UiError.SetError(UiFechaInicial, "", ErrorType.None);
                UiError.SetError(UiFechaFinal, "", ErrorType.None);
                UiError.SetError(UiListaBodega, "", ErrorType.None);

                if (UiFechaInicial.EditValue == null)
                {
                    UiError.SetError(UiFechaInicial, "Dato Obligatorio", ErrorType.Critical);
                    validacion = false;
                }
                if (UiFechaFinal.EditValue == null)
                {
                    UiError.SetError(UiFechaFinal, "Dato Obligatorio", ErrorType.Critical);
                    validacion = false;
                }

                if (UiListaBodega.EditValue == null)
                {
                    UiError.SetError(UiListaBodega, "Dato Obligatorio", ErrorType.Critical);
                    validacion = false;
                }

                if (UiFechaInicial.EditValue != null && UiFechaFinal.EditValue != null)
                {
                    if (UiFechaInicial.DateTime > UiFechaFinal.DateTime)
                    {
                        UiError.SetError(UiFechaFinal, "Fecha inicial es mayor a la fecha final.", ErrorType.Critical);
                        validacion = false;
                    }
                }
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo($"Error al validar la bodega y el rango de fechas : {ex.Message}");
                validacion = false;
            }
            return validacion;
        }

        private void ObtenerDemandasDeDespacho()
        {
            try
            {
                if (!ValidarRangoDeFechas()) return;

                var paseDeSalidaArgumento = new PaseDeSalidaArgumento
                {
                    FechaInicio = (UiFechaInicial.DateTime) + (new TimeSpan(00, 00, 00))
                    ,
                    FechaFin = (UiFechaFinal.DateTime) + (new TimeSpan(23, 59, 59))
                    ,
                    CODE_WAREHOUSE = UiListaBodega.EditValue.ToString()
                    ,
                    DEMAND_TYPE = UiListaTipo.EditValue.ToString()

                };

                UsuarioDeseaObtenerDespachos?.Invoke(null, paseDeSalidaArgumento);

            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo($"Error al obtener las demandas de despacho: {ex.Message}");
            }
        }

        private void UsuarioDeseaObtenerLosDetallesDeDespacho()
        {
            try
            {
                if (DespachoEncabezados.ToList().Exists(doc => doc.IS_SELECTED))
                {
                    var listaDeDespachosEncabezados = DespachoEncabezados.Where(doc => doc.IS_SELECTED).ToList();
                    var cadena = new StringBuilder();
                    foreach (var registro in listaDeDespachosEncabezados)
                    {
                        if (cadena.Length > 0)
                        {
                            cadena.Append("|");
                        }
                        cadena.Append(UiListaTipo.EditValue.ToString()
                            .Equals(
                                Enums.GetStringValue(TipoDeDespachoParaPaseDeSalida.DespachoGeneral))
                            ? registro.WAVE_PICKING_ID
                            : registro.PICKING_DEMAND_HEADER_ID);
                    }

                    UsuarioDeseaObtenerDetalleDeDespachos?.Invoke(null, new PaseDeSalidaArgumento
                    {
                        PICKING_DEMAND_HEADER_ID = cadena.ToString(),
                        PaseDeSalidaEncabezado = new PaseDeSalidaEncabezado
                        {
                            PASS_ID = Convert.ToInt32(UiEtiquetaNumeroPase.Text)
                        },
                        DEMAND_TYPE = UiListaTipo.EditValue.ToString()
                    });
                    BloquearTipo();
                }
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo($"Error al obtener el detalle de los despachos: {ex.Message}");
            }
        }

        private void Grabar()
        {
            try
            {
                if (!Validar()) return;
                var argumento = new PaseDeSalidaArgumento();
                var parametroPaseDeSalida = Parametros.FirstOrDefault(p => p.PARAMETER_ID == Enums.GetStringValue(IdParametro.InsertarOActualizarVehiculoYPiloto) && p.GROUP_ID == Enums.GetStringValue(GrupoParametro.Pase));
                var mostrarListaDePilotos = (parametroPaseDeSalida != null && int.Parse(parametroPaseDeSalida.VALUE) == (int)SiNo.Si);
                var vehiculo = new Vehiculo();

                if (mostrarListaDePilotos)
                {
                    var soloVehiculo = SoloVehiculos.FirstOrDefault(v => v.VEHICLE_CODE == Convert.ToInt32(UiListaSoloVehiculo.EditValue.ToString()));
                    var piloto = Pilotos.FirstOrDefault(v => v.PILOT_CODE == Convert.ToInt32(UiListaPilotos.EditValue.ToString()));

                    if (soloVehiculo != null && piloto != null)
                    {
                        vehiculo.VEHICLE_CODE = soloVehiculo.VEHICLE_CODE;
                        vehiculo.PLATE_NUMBER = soloVehiculo.PLATE_NUMBER;

                        vehiculo.PILOT_CODE = piloto.PILOT_CODE;
                        vehiculo.PILOT_NAME = piloto.NAME;
                        vehiculo.LICENSE_NUMBER = piloto.LICENSE_NUMBER;
                    }
                    else
                    {
                        vehiculo = null;
                    }
                }
                else
                {
                    vehiculo = Vehiculos.FirstOrDefault(v => v.VEHICLE_CODE == Convert.ToInt32(UiListaVehiculo.EditValue.ToString()));
                }
                if (vehiculo != null)
                    argumento.PaseDeSalidaEncabezado = new PaseDeSalidaEncabezado
                    {
                        PASS_ID = Convert.ToInt32(UiEtiquetaNumeroPase.Text)
                        ,
                        CLIENT_CODE = UiListaCliente.EditValue.ToString()
                        ,
                        CLIENT_NAME = UiListaCliente.Text
                        ,
                        ISEMPTY = UiCheckTransporteVacio.Checked ? "N" : "Y"
                        ,
                        VEHICLE_ID = vehiculo.VEHICLE_CODE
                        ,
                        VEHICLE_PLATE = vehiculo.PLATE_NUMBER
                        ,
                        VEHICLE_DRIVER = vehiculo.PILOT_NAME
                        ,
                        DRIVER_ID = vehiculo.PILOT_CODE
                        ,
                        AUTORIZED_BY = UiListaAutorizadoPor.EditValue.ToString()
                        ,
                        LICENSE_NUMBER = vehiculo.LICENSE_NUMBER
                        ,
                        HANDLER = UiListaEntregadoPor.EditValue.ToString()
                        ,
                        TXT = UiMemoObservaciones.Text
                        ,
                        LOADUNLOAD = UiGroupRadioEstadoVehiculo.EditValue.ToString()
                        ,
                        TYPE = UiListaTipo.EditValue.ToString()
                        ,
                        STATUS = UiEtiquetaEstado.Tag.ToString()
                    };
                UsuarioDeseaGrabar?.Invoke(null, argumento);
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo($"Error al validar el pase de salida: {ex.Message}");
            }
        }

        public void TerminoDeGrabar(int paseDeSalida)
        {
            try
            {

                InteraccionConUsuarioServicio.MensajeExito("Se grabó exitosamente.");
                UiEtiquetaNumeroPase.Text = paseDeSalida.ToString();
                if (UiEtiquetaEstado.Tag.ToString().Equals(Enums.GetStringValue(EstadoPaseDeSalida.Finalizado)))
                {
                    BloquearControles(Enums.GetStringValue(EstadoPaseDeSalida.Finalizado));
                    EstablecerEstado(Enums.GetStringValue(EstadoPaseDeSalida.Finalizado));
                }
                else
                {
                    BloquearControles(Enums.GetStringValue(EstadoPaseDeSalida.Creado));
                    EstablecerEstado(Enums.GetStringValue(EstadoPaseDeSalida.Creado));
                    ObtenerDemandasDeDespacho();
                }
                DespachoEncabezados = new List<DemandaDespachoHeader>();
                DespachosDetalles = new List<DemandaDespachoDetalle>();


            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo($"Error al terminar de grabar: {ex.Message}");
            }
        }

        public void EliminarDetalle()
        {
            try
            {
                DespachosDetalles = DespachosDetalles.Where(d => !d.IS_SELECTED).ToList();
                BloquearTipo();
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo($"Error al eliminar el detalle: {ex.Message}");
            }
        }

        public void CargarControlesEncabezado(PaseDeSalidaEncabezado paseDeSalidaEncabezado)
        {
            try
            {
                BloquearControles(string.Empty);
                UiEtiquetaNumeroPase.Text = paseDeSalidaEncabezado.PASS_ID.ToString();
                UiListaCliente.EditValue = paseDeSalidaEncabezado.CLIENT_CODE;
                UiCheckTransporteVacio.Checked = paseDeSalidaEncabezado.ISEMPTY.Equals("Y");
                UiListaTipo.EditValue = paseDeSalidaEncabezado.TYPE;
                UiListaVehiculo.EditValue = paseDeSalidaEncabezado.VEHICLE_ID;
                UiListaSoloVehiculo.EditValue = paseDeSalidaEncabezado.VEHICLE_ID;
                UiListaPilotos.EditValue = paseDeSalidaEncabezado.DRIVER_ID;
                UiGroupRadioEstadoVehiculo.EditValue = paseDeSalidaEncabezado.LOADUNLOAD;
                UiListaAutorizadoPor.EditValue = paseDeSalidaEncabezado.AUTORIZED_BY;
                UiListaEntregadoPor.EditValue = paseDeSalidaEncabezado.HANDLER;
                UiMemoObservaciones.Text = paseDeSalidaEncabezado.TXT;
                BloquearControles(paseDeSalidaEncabezado.STATUS);
                EstablecerEstado(paseDeSalidaEncabezado.STATUS);
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo($"Error al cargar los datos generales: {ex.Message}");
            }
        }

        private void BloquearControles(string estado)
        {
            try
            {
                UiListaCliente.Enabled = true;
                UiCheckTransporteVacio.Enabled = true;
                UiListaTipo.Enabled = true;
                UiListaVehiculo.Enabled = true;
                UiListaSoloVehiculo.Enabled = true;
                UiListaPilotos.Enabled = true;
                UiGroupRadioEstadoVehiculo.Enabled = true;
                UiListaBodega.Enabled = true;
                UiListaAutorizadoPor.Enabled = true;
                UiListaEntregadoPor.Enabled = true;
                UiMemoObservaciones.Enabled = true;
                UiListaDespachos.Enabled = true;
                UiBotonEliminarDetalle.Enabled = true;
                UiBotonGrabar.Enabled = true;
                UiBotonImprimir.Enabled = true;
                UiBotonAnularPaseDeSalida.Enabled = true;
                UiColVistaCantidad.OptionsColumn.AllowEdit = true;

                if (estado.Equals(Enums.GetStringValue(EstadoPaseDeSalida.Creado)))
                {
                    UiListaCliente.Enabled = false;
                    UiListaTipo.Enabled = false;
                }
                else if (estado.Equals(Enums.GetStringValue(EstadoPaseDeSalida.Finalizado)) || estado.Equals(Enums.GetStringValue(EstadoPaseDeSalida.Cancelado)))
                {
                    UiListaCliente.Enabled = false;
                    UiCheckTransporteVacio.Enabled = false;
                    UiListaTipo.Enabled = false;
                    UiListaVehiculo.Enabled = estado.Equals(Enums.GetStringValue(EstadoPaseDeSalida.Finalizado));
                    UiListaSoloVehiculo.Enabled = estado.Equals(Enums.GetStringValue(EstadoPaseDeSalida.Finalizado));
                    UiListaPilotos.Enabled = estado.Equals(Enums.GetStringValue(EstadoPaseDeSalida.Finalizado));
                    UiGroupRadioEstadoVehiculo.Enabled = false;
                    UiListaBodega.Enabled = false;
                    UiListaAutorizadoPor.Enabled = false;
                    UiListaEntregadoPor.Enabled = false;
                    UiMemoObservaciones.Enabled = false;
                    UiListaDespachos.Enabled = false;
                    UiBotonEliminarDetalle.Enabled = false;
                    UiColVistaCantidad.OptionsColumn.AllowEdit = false;
                    UiBotonImprimir.Enabled = estado.Equals(Enums.GetStringValue(EstadoPaseDeSalida.Finalizado));
                    UiBotonGrabar.Enabled = estado.Equals(Enums.GetStringValue(EstadoPaseDeSalida.Finalizado));
                    UiBotonAnularPaseDeSalida.Enabled = estado.Equals(Enums.GetStringValue(EstadoPaseDeSalida.Finalizado));
                }
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo($"Error al bloquear los controles: {ex.Message}");
            }
        }

        public void ObtenerPaseDeSalida(int paseDeSalida)
        {
            try
            {
                var argumento = new PaseDeSalidaArgumento
                {
                    PaseDeSalidaEncabezado = new PaseDeSalidaEncabezado
                    {
                        PASS_ID = paseDeSalida
                    }
                    ,
                    Login = InteraccionConUsuarioServicio.ObtenerUsuario()
                    ,
                    DISTRIBUTION_CENTER_ID = InteraccionConUsuarioServicio.ObtenerCentroDistribucion()
                };
                UsuarioDeseaObtenerPaseDeSalida?.Invoke(null, argumento);
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo($"Error al bloquear los controles: {ex.Message}");
            }
        }

        private void LimpiarControles()
        {
            try
            {
                BloquearControles(string.Empty);
                UiEtiquetaEstado.Tag = "...";
                UiEtiquetaEstado.Text = @"...";
                UiEtiquetaNumeroPase.Text = "0";
                UiListaCliente.EditValue = null;
                UiCheckTransporteVacio.Checked = false;
                UiListaTipo.EditValue = TipoDeDespachoParaPaseDeSalida.Venta;
                UiListaVehiculo.EditValue = null;
                UiGroupRadioEstadoVehiculo.EditValue = null;
                UiListaBodega.EditValue = null;
                UiListaAutorizadoPor.EditValue = null;
                UiListaEntregadoPor.EditValue = null;
                UiMemoObservaciones.Text = "";
                DespachoEncabezados = new List<DemandaDespachoHeader>();
                DespachosDetalles = new List<DemandaDespachoDetalle>();
                BloquearTipo();
                SeleccionarPrimerRegistroDeLasListas();
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo($"Error al limpiar los controles: {ex.Message}");
            }
        }

        private void BloquearTipo()
        {
            UiListaTipo.Enabled = DespachosDetalles.ToList().Count == 0;

        }

        public void TerminoDeActualizarEstado(int paseDeSalida, string estado)
        {
            try
            {
                BloquearControles(estado);
                EstablecerEstado(estado);
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo($"Error al terminar de actualizar el estado: {ex.Message}");
            }
        }

        private void EstablecerEstado(string estado)
        {
            try
            {
                if (estado.Equals(Enums.GetStringValue(EstadoPaseDeSalida.Creado)))
                {
                    UiEtiquetaEstado.Text = "Creado";
                    UiEtiquetaEstado.Tag = Enums.GetStringValue(EstadoPaseDeSalida.Creado);
                }
                else if (estado.Equals(Enums.GetStringValue(EstadoPaseDeSalida.Finalizado)))
                {
                    UiEtiquetaEstado.Text = "Finalizado";
                    UiEtiquetaEstado.Tag = Enums.GetStringValue(EstadoPaseDeSalida.Finalizado);
                }
                else if (estado.Equals(Enums.GetStringValue(EstadoPaseDeSalida.Cancelado)))
                {
                    UiEtiquetaEstado.Text = "Anulado";
                    UiEtiquetaEstado.Tag = Enums.GetStringValue(EstadoPaseDeSalida.Cancelado);
                }
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo($"Error al establecer el estado: {ex.Message}");
            }
        }

        private void UsuarioDeseaImprimirReporte()
        {
            try
            {
                if (!ExisteRegistro(Convert.ToInt32(UiEtiquetaNumeroPase.Text))) return;
                if (!UiEtiquetaEstado.Tag.ToString().Equals(Enums.GetStringValue(EstadoPaseDeSalida.Finalizado)))
                {
                    if (ConfirmacionImprimirElReporte())
                    {
                        var argumento = new PaseDeSalidaArgumento
                        {
                            Login = InteraccionConUsuarioServicio.ObtenerUsuario(),
                            PaseDeSalidaEncabezado = new PaseDeSalidaEncabezado
                            {
                                PASS_ID = Convert.ToInt32(UiEtiquetaNumeroPase.Text)
                       ,
                                STATUS = Enums.GetStringValue(EstadoPaseDeSalida.Finalizado)
                            }
                        };
                                                
                        UsuarioDeseaCambiarEstadoAlPase?.Invoke(null, argumento);
                        GenerarReporte(false);
                    }
                }
                else
                {
                    GenerarReporte(true);
                }
                
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo($"Error al imprimir el reporte: {ex.Message}");
            }
        }

        private void GenerarReporte(bool mostrarEtiquetaReimpresion)
        {
            try
            {
                var argumento = new PaseDeSalidaArgumento
                {
                    Login = InteraccionConUsuarioServicio.ObtenerUsuario(),
                    PaseDeSalidaEncabezado = new PaseDeSalidaEncabezado
                    {
                        PASS_ID = Convert.ToInt32(UiEtiquetaNumeroPase.Text)
                        ,
                        STATUS = Enums.GetStringValue(EstadoPaseDeSalida.Finalizado)
                    }
                    ,
                    DISTRIBUTION_CENTER_ID = InteraccionConUsuarioServicio.ObtenerCentroDistribucion()
                };

                UsuarioDeseaObtenerPaseParaReporte?.Invoke(null, argumento);

                var pasesFiltradosAgrupados =
                    PaseDeSalidas.GroupBy(p => p.DOC_NUM)
                        .Select(paseGrupo => paseGrupo.ToList())
                        .ToList();
                

                if (FiltroPasesParaReporte(pasesFiltradosAgrupados))
                {
                    var generoReportePrincipal = false;
                    bool pAlt = bool.Parse(ConfigurationManager.AppSettings["PaseDeSalidaAlt"]);
                    XtraReport reporteDePaseDeSalidaGeneral;
                    if (pAlt == true) reporteDePaseDeSalidaGeneral = new Reportes.PaseDeSalidaAlt();
                    else reporteDePaseDeSalidaGeneral = new Reportes.PaseDeSalida();

                    for (var i = 0; i < pasesFiltradosAgrupados.Count; i++)
                    {
                        var pasefiltrado = pasesFiltradosAgrupados[i];
                        XtraReport reporte;

                        if (pAlt == true) { 
                            reporte = new Reportes.PaseDeSalidaAlt(!string.IsNullOrEmpty(pasefiltrado[0].SELLER), mostrarEtiquetaReimpresion)
                            {
                                DataSource = ListToDataTableClass.ListToDataTable(pasefiltrado),
                                DataMember = "PaseDeSalida",
                                RequestParameters = false
                            };
                        } else
                        {
                            reporte = new Reportes.PaseDeSalida(!string.IsNullOrEmpty(pasefiltrado[0].SELLER), mostrarEtiquetaReimpresion)
                            {
                                DataSource = ListToDataTableClass.ListToDataTable(pasefiltrado),
                                DataMember = "PaseDeSalida",
                                RequestParameters = false
                            };
                        }
                        var parametroFactura = Parametros.FirstOrDefault(p => p.PARAMETER_ID == Enums.GetStringValue(IdParametro.GeneraFactura) && p.GROUP_ID == Enums.GetStringValue(GrupoParametro.Sistema));
                        var parametroEtiquetaGarantia = Parametros.FirstOrDefault(p => p.PARAMETER_ID == Enums.GetStringValue(IdParametro.MostrarEtiquetaDeGarantia) && p.GROUP_ID == Enums.GetStringValue(GrupoParametro.Pase));
                        var parametroPanelCondiciones = Parametros.FirstOrDefault(p => p.PARAMETER_ID == Enums.GetStringValue(IdParametro.MostrarEtiquetaDePanelCondiciones) && p.GROUP_ID == Enums.GetStringValue(GrupoParametro.Pase));

                        reporte.Parameters["ImagenLogo"].Value = InteraccionConUsuarioServicio.ObtenerLogo();
                        reporte.Parameters["GeneraFactura"].Value = (parametroFactura != null && int.Parse(parametroFactura.VALUE) == (int)SiNo.Si);
                        reporte.Parameters["MostrorEtiquetaGarantia"].Value = (parametroEtiquetaGarantia != null && int.Parse(parametroEtiquetaGarantia.VALUE) == (int)SiNo.Si);
                        //Se mostrará la etiqueta PanelCondiciones si no existe el parámetro en la DB o si existe, debe de tener el valor "1".
                        //reporte.Parameters["MostrarEtiquetaPanelCondiciones"].Value = !(parametroPanelCondiciones != null && int.Parse(parametroPanelCondiciones.VALUE) == (int)SiNo.No);
                        reporte.Parameters["LogoDeImagenPredeterminada"].Value = InteraccionConUsuarioServicio.ObtenerLogoDeImagenPredeterminada();
                        
                        reporte.FillDataSource();
                        reporte.CreateDocument();


                        if (EsPrimerReporte(i))
                        {
                            reporteDePaseDeSalidaGeneral = reporte;
                            generoReportePrincipal = true;
                        }
                        else
                        {
                            reporteDePaseDeSalidaGeneral.Pages.AddRange(reporte.Pages);
                        }

                    }

                    if (!generoReportePrincipal) return;

                    reporteDePaseDeSalidaGeneral.PrintingSystem.ContinuousPageNumbering = false;

                    using (var printTool = new ReportPrintTool(reporteDePaseDeSalidaGeneral))
                    {
                        printTool.ShowRibbonPreviewDialog();
                    }

                }
                else
                {
                    InteraccionConUsuarioServicio.MensajeErrorDialogo("No se encontraron datos para generar el reporte");
                }


            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo($"Error al generar el reporte: {ex.Message}");
            }
        }

        private bool FiltroPasesParaReporte(List<List<PaseDeSalida>> pasesDeSalidaFiltrados)
        {
            return pasesDeSalidaFiltrados.Count > 0;
        }

        private bool EsPrimerReporte(int indice)
        {
            return indice == 0;
        }


        private bool ConfirmacionImprimirElReporte()
        {
            return XtraMessageBox.Show("Confirma imprimir el pase de salida(Esto finalizará el documento)?", "Swift 3PL", MessageBoxButtons.YesNo,
                       MessageBoxIcon.Question) == DialogResult.Yes;
        }

        private void UsuarioDeseaAnularElPase()
        {
            try
            {
                if (!ExisteRegistro(Convert.ToInt32(UiEtiquetaNumeroPase.Text))) return;
                if (!ConfirmacionParaAnularPase()) return;
                var argumento = new PaseDeSalidaArgumento
                {
                    Login = InteraccionConUsuarioServicio.ObtenerUsuario(),
                    PaseDeSalidaEncabezado = new PaseDeSalidaEncabezado
                    {
                        PASS_ID = Convert.ToInt32(UiEtiquetaNumeroPase.Text)
                        ,
                        STATUS = Enums.GetStringValue(EstadoPaseDeSalida.Cancelado)
                    }
                };
                UsuarioDeseaCambiarEstadoAlPase?.Invoke(null, argumento);
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo($"Error al anular el pase: {ex.Message}");
            }
        }

        private bool ConfirmacionParaAnularPase()
        {
            return XtraMessageBox.Show("Confirma anular el pase de salida?", "Swift 3PL", MessageBoxButtons.YesNo,
                       MessageBoxIcon.Question) == DialogResult.Yes;
        }

        public void TerminoDeGrabarVehiculo(int? codigoVehiculo)
        {
            try
            {
                UiListaSoloVehiculo.EditValue = codigoVehiculo;
                UiPopupVehiculo.Visible = false;
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo($"Error al establecer el vehículo: {ex.Message}");
            }
        }

        public void TerminoDeGrabarPiloto(int? codigoPiloto)
        {
            try
            {
                UiListaPilotos.EditValue = codigoPiloto;
                UiPopupPiloto.Visible = false;
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo($"Error al establecer el piloto: {ex.Message}");
            }
        }

        private void EstablecerVehiculoSeleccionado()
        {
            try
            {
                if (!UiPopupVehiculo.Visible) return;
                LimpiarControlesDeVehiculo();
                if (UiListaSoloVehiculo.EditValue == null) return;
                var vehiculo = SoloVehiculos.FirstOrDefault(sv => sv.VEHICLE_CODE == int.Parse(UiListaSoloVehiculo.EditValue.ToString()));
                if (vehiculo == null) return;
                UiEtiquetaCodigoVehiculo.Text = vehiculo.VEHICLE_CODE.ToString();
                UiTextoPlaca.Text = vehiculo.PLATE_NUMBER;
                UiTextoMarca.Text = vehiculo.BRAND;
                UiTextoModelo.Text = vehiculo.MODEL;
                UiTextoColor.Text = vehiculo.COLOR;
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo($"Error al establecer el vehículo seleccionado: {ex.Message}");
            }
        }

        private void LimpiarControlesDeVehiculo()
        {
            try
            {
                UiEtiquetaCodigoVehiculo.Text = "0";
                UiTextoPlaca.Text = "";
                UiTextoMarca.Text = "";
                UiTextoModelo.Text = "";
                UiTextoColor.Text = "";
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo($"Error al limpiar los controles para vehículo: {ex.Message}");
            }
        }

        private void EstablecerPilotoSeleccionado()
        {
            try
            {
                if (!UiPopupPiloto.Visible) return;
                LimpiarControlesDePiloto();
                if (UiListaPilotos.EditValue == null) return;
                var piloto = Pilotos.FirstOrDefault(sv => sv.PILOT_CODE == int.Parse(UiListaPilotos.EditValue.ToString()));
                if (piloto == null) return;
                UiEtiquetaCodigoPiloto.Text = piloto.PILOT_CODE.ToString();
                UiTextoNombrePiloto.Text = piloto.NAME;
                UiTextoApellidoPiloto.Text = piloto.LAST_NAME;
                UiTextoLicenciaPiloto.Text = piloto.LICENSE_NUMBER;
                UiTextoTelefonoPiloto.Text = piloto.TELEPHONE;
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo($"Error al establecer el vehículo seleccionado: {ex.Message}");
            }
        }

        private void LimpiarControlesDePiloto()
        {
            try
            {
                UiEtiquetaCodigoPiloto.Text = "0";
                UiTextoNombrePiloto.Text = "";
                UiTextoApellidoPiloto.Text = "";
                UiTextoLicenciaPiloto.Text = "";
                UiTextoTelefonoPiloto.Text = "";
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo($"Error al limpiar los controles para vehículo: {ex.Message}");
            }
        }

        private void GrabarVehiculo()
        {
            try
            {
                if (string.IsNullOrEmpty(UiTextoPlaca.Text))
                {
                    InteraccionConUsuarioServicio.MensajeErrorDialogo($"Ingrese el número de placa");
                    UiTextoPlaca.Focus();
                    return;
                }

                UsuarioDeseaGrabarVehiculo?.Invoke(null, new PaseDeSalidaArgumento
                {
                    Vehiculo = new Vehiculo
                    {
                        VEHICLE_CODE = int.Parse(UiEtiquetaCodigoVehiculo.Text)
                    ,
                        PLATE_NUMBER = UiTextoPlaca.Text
                    ,
                        BRAND = UiTextoMarca.Text
                    ,
                        MODEL = UiTextoModelo.Text
                    ,
                        COLOR = UiTextoColor.Text
                    ,
                        LINE = "N/A"
                    ,
                        CHASSIS_NUMBER = "N/A"
                    ,
                        ENGINE_NUMBER = "N/A"
                    ,
                        WEIGHT = 0
                    ,
                        HIGH = 0
                    ,
                        WIDTH = 0
                    ,
                        DEPTH = 0
                    ,
                        VOLUME_FACTOR = 0
                    ,
                        LAST_UPDATE_BY = InteraccionConUsuarioServicio.ObtenerUsuario()
                    ,
                        VEHICLE_AXLES = 0
                    }
                });
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo($"Error al grabar el vehículo: {ex.Message}");
            }
        }

        private void GrabarPiloto()
        {
            try
            {
                if (string.IsNullOrEmpty(UiTextoNombrePiloto.Text))
                {
                    InteraccionConUsuarioServicio.MensajeErrorDialogo($"Ingrese el nombre del piloto");
                    UiTextoNombrePiloto.Focus();
                    return;
                }

                UsuarioDeseaGrabarPiloto?.Invoke(null, new PaseDeSalidaArgumento
                {
                    Piloto = new Piloto
                    {
                        PILOT_CODE = int.Parse(UiEtiquetaCodigoPiloto.Text)
                   ,
                        NAME = UiTextoNombrePiloto.Text
                   ,
                        LAST_NAME = UiTextoApellidoPiloto.Text
                   ,
                        LICENSE_NUMBER = UiTextoLicenciaPiloto.Text
                   ,
                        TELEPHONE = UiTextoTelefonoPiloto.Text
                   ,
                        IDENTIFICATION_DOCUMENT_NUMBER = "N/A"
                   ,
                        LICESE_TYPE = "N/A"
                   ,
                        LICENSE_EXPIRATION_DATE = DateTime.Today
                   ,
                        ADDRESS = "N/A"
                   ,
                        MAIL = "N/A"
                   ,
                        COMMENT = "N/A"
                   ,
                        LAST_UPDATE_BY = InteraccionConUsuarioServicio.ObtenerUsuario()
                    }
                });
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo($"Error al grabar el piloto: {ex.Message}");
            }
        }


        #endregion
    }
}
