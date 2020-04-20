using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Controladores;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Interfaces.Controladores;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Modelo.Servicios;
using MobilityScm.Modelo.Tipos;
using MobilityScm.Utilerias;
using MobilityScm.Vertical.Servicios;

namespace MobilityScm.Modelo.Vistas
{
    public partial class RecepcionErpVista : VistaBaseDeveExpress, IRecepcionErpVista
    {
        #region Eventos


        public event EventHandler<DocumentoRecepcionERPArgumento> UsuarioDeseaObtenerUsuario;
        public event EventHandler<DocumentoRecepcionERPArgumento> UsuarioDeseaObtenerUbicaciones;
        public event EventHandler<DocumentoRecepcionERPArgumento> UsuarioDeseaObtenerTipoDeRecepcion;
        public event EventHandler<DocumentoRecepcionERPArgumento> UsuarioDeseaObtenerPrioridad;
        public event EventHandler<DocumentoRecepcionERPArgumento> UsuarioDeseaObtenerPolizaAseguradaPorCliente;
        public event EventHandler VistaCargandosePorPrimeraVez;
        public event EventHandler<DocumentoRecepcionERPArgumento> UsuarioDeseaObtenerClientes;
        public event EventHandler<DocumentoRecepcionERPArgumento> UsuarioDeseaObtenerDetalleOrdenDeCompra;
        public event EventHandler<AcuerdoComercialArgumento> UsuarioDeseaObtenerAcuerdosComercialesPorCliente;
        public event EventHandler<DocumentoRecepcionERPArgumento> UsuarioDeseaObtenerOrdenesDeCompra;
        public event EventHandler<DocumentoRecepcionERPArgumento> UsuarioDeseaGrabarDocmentosErp;
        public event EventHandler<DocumentoRecepcionERPArgumento> UsuarioDeseaObtenerFacturaParaDevolucion;

        #endregion

        #region Propiedades
        public IInteraccionConUsuarioServicio InteraccionConUsuarioServicio { get; set; }
        public IList<AcuerdoComercial> AcuerdosComerciales
        {
            get
            {
                return (IList<AcuerdoComercial>)UiListaAcuerdoComercial.Properties.DataSource;
            }

            set
            {
                UiListaAcuerdoComercial.Properties.DataSource = value;
            }
        }

        public IList<Cliente> Clientes
        {
            get
            {
                return (IList<Cliente>)UiListaCliente.Properties.DataSource;

            }

            set
            {
                UiListaCliente.Properties.DataSource = value;
            }
        }

        public IList<MobilityScm.Modelo.Entidades.Configuracion> Prioridad
        {
            get
            {
                return (IList<MobilityScm.Modelo.Entidades.Configuracion>)UiListaPrioridad.Properties.DataSource;
            }

            set
            {
                UiListaPrioridad.Properties.DataSource = value;
            }
        }

        public IList<FuenteExterna> FuenteExterna
        {
            get
            {
                return (IList<FuenteExterna>)UiListaCliente.Properties.DataSource;
            }

            set
            {
                UiListaCliente.Properties.DataSource = value;
            }
        }

        public IList<Usuario> Operadores
        {
            get
            {
                return (IList<Usuario>)UiListaOperador.Properties.DataSource;
            }

            set
            {
                UiListaOperador.Properties.DataSource = value;
            }
        }

        public IList<DocumentoRecepcionErpDetalle> OrdenesDeCompraDetalle
        {
            get
            {
                return (IList<DocumentoRecepcionErpDetalle>)UiContenedorVistaErp.DataSource;
            }

            set
            {
                UiContenedorVistaErp.DataSource = value;
                UiVistaErp.ExpandAllGroups();
            }
        }

        public IList<DocumentoRecepcionErpEncabezado> OrdenesDeCompraEncabezado
        {
            get
            {
                return (IList<DocumentoRecepcionErpEncabezado>)UiListaErp.Properties.DataSource;
            }

            set
            {
                UiListaErp.Properties.DataSource = value;
            }
        }

        public IList<PolizaAsegurada> PolizaAseguradora
        {
            get
            {
                return (IList<PolizaAsegurada>)UiListaPolizasDeSeguro.Properties.DataSource;
            }

            set
            {
                if (value.Count > 0)
                {
                    UiListaPolizasDeSeguro.Properties.ValueMember = string.IsNullOrEmpty(value[0].DOC_ID_CONFIGURATION) ? "DOC_ID" : "DOC_ID_CONFIGURATION";
                    if (UiListaPolizasDeSeguro.Properties.ValueMember.Equals("DOC_ID"))
                    {
                        colDOC_ID_CONFIGURATION.Visible = false;
                        colDOC_ID_CONFIGURATION.OptionsColumn.ShowInCustomizationForm = false;
                        colDOC_ID.Visible = true;
                        colDOC_ID.OptionsColumn.ShowInCustomizationForm = true;
                    }
                    else
                    {
                        colDOC_ID_CONFIGURATION.Visible = true;
                        colDOC_ID_CONFIGURATION.OptionsColumn.ShowInCustomizationForm = true;
                        colDOC_ID.Visible = false;
                        colDOC_ID.OptionsColumn.ShowInCustomizationForm = false;
                    }
                }

                UiListaPolizasDeSeguro.Properties.DataSource = value;
            }
        }

        public IList<MobilityScm.Modelo.Entidades.Configuracion> TiposDeRecepcion
        {
            get
            {
                return (IList<MobilityScm.Modelo.Entidades.Configuracion>)UiListaTipoRecepcion.Properties.DataSource;
            }
            set
            {
                UiListaTipoRecepcion.Properties.DataSource = value;
            }
        }

        public IList<Ubicacion> Ubicaciones
        {
            get
            {
                return (IList<Ubicacion>)UiListaUbicacion.Properties.DataSource;
            }
            set
            {
                UiListaUbicacion.Properties.DataSource = value;

            }
        }

        private bool UsuarioSeleccionoListaOrdenEncabezadoCompleta { get; set; }

        public string Usuario { get; set; }

        public IList<Parametro> ParametrosDeSistema { get; set; }

        #endregion

        #region Contructor y Eventos de Carga

        public RecepcionErpVista()
        {
            InitializeComponent();

            Mvx.Ioc.RegisterType<IBaseDeDatosServicio, BaseDeDatosServicio>();
            Mvx.Ioc.Resolve<IConfiguracionDeConexion>();
            InteraccionConUsuarioServicio = Mvx.Ioc.Resolve<IInteraccionConUsuarioServicio>();
            Mvx.Ioc.RegisterType<IRecepcionServicio, RecepcionServicio>();
            Mvx.Ioc.RegisterType<IPolizaServicio, PolizaServicio>();
            Mvx.Ioc.RegisterType<IPolizaAseguradaServicio, PolizaAseguradaServicio>();
            Mvx.Ioc.RegisterType<IUsuarioServicio, UsuarioServicio>();
            Mvx.Ioc.RegisterType<IConfiguracionServicio, ConfiguracionServicio>();
            Mvx.Ioc.RegisterType<IUbicacionServicio, UbicacionServicio>();
            Mvx.Ioc.RegisterType<IAcuerdoComercialServicio, AcuerdoComercialServicio>();
            Mvx.Ioc.RegisterType<IFuenteExternaServicio, FuenteExternaServicio>();
            Mvx.Ioc.RegisterType<ITareaServicio, TareaServicio>();
            Mvx.Ioc.RegisterType<IParametroServicio, ParametroServicio>();
            Mvx.Ioc.RegisterSingleton<IRecepcionErpVista, RecepcionErpVista>(this);
            Mvx.Ioc.RegisterType<IRecepcionControlador, RecepcionControlador>();
            Mvx.Ioc.Resolve<IRecepcionControlador>();

        }

        private void RecepcionErpVista_Load(object sender, EventArgs e)
        {
            VistaCargandosePorPrimeraVez?.Invoke(sender, e);
            UiFechaInicio.EditValue = DateTime.Now.AddDays(-7);
            UiFechaFinal.EditValue = DateTime.Now.AddDays(7);
            UsuarioSeleccionoListaOrdenEncabezadoCompleta = false;
            CargarOGuardarDisenios(UiContenedorVistaErp, false, Usuario, GetType().Name);
            UiListaCliente.Properties.PopupFormWidth = UiListaCliente.Width;
            UiListaErp.Properties.PopupFormWidth = UiListaErp.Width;
            UiListaAcuerdoComercial.Properties.PopupFormWidth = UiListaAcuerdoComercial.Width;
            UiListaPolizasDeSeguro.Properties.PopupFormWidth = UiListaPolizasDeSeguro.Width;
            UiListaOperador.Properties.PopupFormWidth = UiListaOperador.Width;
            UiListaUbicacion.Properties.PopupFormWidth = UiListaUbicacion.Width;
            UiListaTipoRecepcion.Properties.PopupFormWidth = UiListaTipoRecepcion.Width;
            UiListaPrioridad.Properties.PopupFormWidth = UiListaPrioridad.Width;

            UiBarFuente.EditValue = FuenteDeRecepcionDeErp.OrdenDeCompra;
            UiGridLookUpFuente.DataSource = Enum.GetValues(typeof(FuenteDeRecepcionDeErp));
            UiBarFuente.EditValue = FuenteDeRecepcionDeErp.OrdenDeCompra;

            //
            seleccionarPrimerRegistroDeLaLista();
        }
        #endregion

        private void seleccionarPrimerRegistroDeLaLista()
        {
            try
            {
                var primerCliente = FuenteExterna.FirstOrDefault();
                if (primerCliente != null) UiListaCliente.EditValue = primerCliente.CLIENT_CODE;

                var primerAcuerdoComercial = AcuerdosComerciales.FirstOrDefault();
                if (primerAcuerdoComercial != null) UiListaAcuerdoComercial.EditValue = primerAcuerdoComercial.ACUERDO_COMERCIAL;

                var primerPolizaSeguro = PolizaAseguradora.FirstOrDefault();
                if (primerPolizaSeguro != null) UiListaPolizasDeSeguro.EditValue = primerPolizaSeguro.DOC_ID; 
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(ex.Message);
            }
        }

        private void seleccionarPrimerRegistroPorCliente()
        {
            try
            {
                var primerAcuerdoComercial = AcuerdosComerciales.FirstOrDefault();
                if (primerAcuerdoComercial != null) UiListaAcuerdoComercial.EditValue = primerAcuerdoComercial.ACUERDO_COMERCIAL;

                var primerPolizaSeguro = PolizaAseguradora.FirstOrDefault();
                if (primerPolizaSeguro != null) UiListaPolizasDeSeguro.EditValue = primerPolizaSeguro.DOC_ID;
            }
            catch(Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(ex.Message);
            }
        }

        private void UiLista_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if (e.Button.Tag == null) return;
                switch (e.Button.Tag.ToString())
                {
                    case "REFRESCAR-USUARIO":
                        UsuarioDeseaObtenerUsuario?.Invoke(sender, new DocumentoRecepcionERPArgumento());
                        break;
                    case "REFRESCAR-UBICACION":
                        UsuarioDeseaObtenerUbicaciones?.Invoke(sender, new DocumentoRecepcionERPArgumento());
                        break;
                    case "REFRESCAR-TIPORECEPCION":
                        UsuarioDeseaObtenerTipoDeRecepcion?.Invoke(sender, new DocumentoRecepcionERPArgumento());
                        break;
                    case "REFRESCAR-PRIORIDAD":
                        UsuarioDeseaObtenerPrioridad?.Invoke(sender, new DocumentoRecepcionERPArgumento());
                        break;
                    case "REFRESCAR-CLIENTE":
                        UsuarioDeseaObtenerClientes?.Invoke(sender, new DocumentoRecepcionERPArgumento());
                        break;
                    case "REFRESCAR-ERP":
                        LlenarListaEncabezadoErp();
                        break;
                    case "REFRESCAR-ACUERDOCOMERCIAL":
                        LLenarAcuerdoComercial();
                        break;
                    case "REFRESCAR-POLIZASEGURO":
                        LlenarPolizasSeguro();
                        break;
                    case "AGREGAR-ERP":
                        if (!ValidarAlAgregarDocDet(true))
                            LlenarDetalleErp();
                        break;
                }
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void UiVistaErpEncabezado_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            try
            {
                if (e.ControllerRow >= 0)
                {
                    var documento = (DocumentoRecepcionErpEncabezado)UiVistaErpEncabezado.GetRow(e.ControllerRow);
                    documento.IS_SELECTD = (e.Action == CollectionChangeAction.Add);
                }
                else
                {
                    if (UsuarioSeleccionoListaOrdenEncabezadoCompleta)
                    {
                        for (var i = 0; i < UiVistaErpEncabezado.RowCount; i++)
                        {
                            var documento = (DocumentoRecepcionErpEncabezado)UiVistaErpEncabezado.GetRow(i);
                            if (documento == null) continue;
                            documento.IS_SELECTD = (UiVistaErpEncabezado.SelectedRowsCount != 0);
                        }
                        UsuarioSeleccionoListaOrdenEncabezadoCompleta = false;
                    }
                }

                var edit = ActiveControl as DevExpress.XtraEditors.SearchLookUpEdit;
                if (edit == null) return;
                edit.Text = ObtenerTextoAMostrarListaDocErp();
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void UiListaErp_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            e.DisplayText = ObtenerTextoAMostrarListaDocErp();
        }

        private void UiVistaErpEncabezado_MouseUp(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null)
                return;
            GridHitInfo hi = view.CalcHitInfo(new System.Drawing.Point(e.X, e.Y));
            if ((hi.HitTest == GridHitTest.Column || hi.HitTest == GridHitTest.GroupPanelColumn) && hi.Column.Name.Equals("DX$CheckboxSelectorColumn"))
            {
                UsuarioSeleccionoListaOrdenEncabezadoCompleta = true;
            }

        }

        private void UiVistaErpEncabezado_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            for (var i = 0; i < UiVistaErpEncabezado.RowCount; i++)
            {
                var documento = (DocumentoRecepcionErpEncabezado)UiVistaErpEncabezado.GetRow(i);
                if (documento == null) continue;
                if (documento.IS_SELECTD)
                {
                    UiVistaErpEncabezado.SelectRow(i);
                }
            }
        }

        private void UiBotonEliminarEncabezado_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if (UiVistaErp.FocusedRowHandle < 0) return;
                var detalle = (DocumentoRecepcionErpDetalle)UiVistaErp.GetRow(UiVistaErp.FocusedRowHandle);
                if (detalle == null) return;
                if (detalle.IS_ASSIGNED == 1) return;
                var listaDet = OrdenesDeCompraDetalle;
                OrdenesDeCompraDetalle = listaDet.Where(det => det.ERP_DOC != detalle.ERP_DOC || !det.SKU.Equals(detalle.SKU) || det.LINE_NUM != detalle.LINE_NUM).ToList();
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void UiBotonNuevo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LimpiarControles();
        }

        private void LlenarPolizasSeguro()
        {
            if (!ValidarCliente()) return;
            UsuarioDeseaObtenerPolizaAseguradaPorCliente?.Invoke(null, new DocumentoRecepcionERPArgumento
            {
                PolizaAsegurada = new PolizaAsegurada
                {
                    CLIENT_CODE = UiListaCliente.EditValue.ToString()
                }
            });
        }

        private void LLenarAcuerdoComercial()
        {
            if (!ValidarCliente()) return;
            UsuarioDeseaObtenerAcuerdosComercialesPorCliente?.Invoke(null, new AcuerdoComercialArgumento
            {
                AcuerdoComercial = new AcuerdoComercial
                {
                    CLIENT_CODE = UiListaCliente.EditValue.ToString()
                }
            });
        }

        private void LlenarListaEncabezadoErp()
        {
            try
            {
                if (!ValidarFechasYCliente())
                {
                    var fechaInicio = Convert.ToDateTime(UiFechaInicio.EditValue);
                    var fechaFinal = Convert.ToDateTime(UiFechaFinal.EditValue);

                    UsuarioDeseaObtenerOrdenesDeCompra?.Invoke(null, new DocumentoRecepcionERPArgumento
                    {
                        FuenteExterna = new FuenteExterna
                        {
                            EXTERNAL_SOURCE_ID = FuenteExterna.First(fe => fe.CLIENT_CODE == UiListaCliente.EditValue.ToString()).EXTERNAL_SOURCE_ID
                         ,
                            INITIAL_DATE = fechaInicio.Date
                         ,
                            END_DATE = fechaFinal.Date + (new TimeSpan(23, 59, 59))
                         ,
                            HAS_MISSING = UiToogleOrdenesIncompletas.Checked ? 1 : 0
                         ,
                            CLIENT_CODE = UiListaCliente.EditValue.ToString()
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void LlenarDetalleErp()
        {
            try
            {
                var cadena = new StringBuilder();
                foreach (var documento in OrdenesDeCompraEncabezado.Where(doc => doc.IS_SELECTD))
                {
                    if (cadena.Length > 0) { cadena.Append("|"); }
                    cadena.Append(documento.SAP_REFERENCE);
                }

                if (string.IsNullOrEmpty(cadena.ToString())) return;

                UsuarioDeseaObtenerDetalleOrdenDeCompra?.Invoke(null, new DocumentoRecepcionERPArgumento
                {
                    DocumentoRecepcionERP = new DocumentoRecepcionErpEncabezado
                    {
                        DOC_IDS = cadena.ToString()
                        ,
                        EXTERNAL_SOURCE_ID = FuenteExterna.First(fe => fe.CLIENT_CODE == UiListaCliente.EditValue.ToString()).EXTERNAL_SOURCE_ID
                        ,
                        OWNER = UiListaCliente.EditValue.ToString()
                    }
                    ,
                    DocumentoRecepcionErpDetalle = new DocumentoRecepcionErpDetalle
                    {
                        LOGIN_ID = UiListaOperador.EditValue?.ToString() ?? ""
                        ,
                        LOCATION_SPOT = UiListaUbicacion.EditValue?.ToString() ?? ""
                        ,
                        TYPE_RECEPCTION = (Enums.GetStringValue((FuenteDeRecepcionDeErp)UiBarFuente.EditValue) == Enums.GetStringValue(FuenteDeRecepcionDeErp.OrdenDeCompra) ? UiListaTipoRecepcion.EditValue.ToString() : "DEVOLUCION_FACTURA")
                        ,
                        TYPE_RECEPCTION_DRESCRIPTION = (Enums.GetStringValue((FuenteDeRecepcionDeErp)UiBarFuente.EditValue) == Enums.GetStringValue(FuenteDeRecepcionDeErp.OrdenDeCompra) ? UiListaTipoRecepcion.Text : "DEVOLUCION_FACTURA")
                        ,
                        PRIORITY = Convert.ToInt32(UiListaPrioridad.EditValue)
                        ,
                        PRIORITY_DESCRIPTION = UiListaPrioridad.Text
                        ,
                        TRADE_AGREEMENT_ID = Convert.ToInt32(UiListaAcuerdoComercial.EditValue)
                        ,
                        TRADE_AGREEMENT_DESCRIPTION = UiListaAcuerdoComercial.Text
                        ,
                        CLIENT_CODE = UiListaCliente.EditValue.ToString()
                        ,
                        INSURANCE_DOC_ID = UiListaPolizasDeSeguro.EditValue.ToString()
                        ,
                        INSURANCE_DOC_DESCRIPTION = UiListaPolizasDeSeguro.Text
                        ,
                        SOURCE = Enums.GetStringValue((FuenteDeRecepcionDeErp)UiBarFuente.EditValue)
                    }

                });
            }
            catch (Exception ex )
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }

        }

        private string ObtenerTextoAMostrarListaDocErp()
        {
            if (OrdenesDeCompraEncabezado == null) return "";
            var cadena = new StringBuilder();
            foreach (var documento in OrdenesDeCompraEncabezado.Where(doc => doc.IS_SELECTD))
            {
                if (cadena.Length > 0) { cadena.Append(","); }
                cadena.Append(documento.DOC_NUM);
            }

            return cadena.ToString();
        }

        private bool ValidarCliente()
        {
            UiError.SetError(UiListaCliente, "", ErrorType.None);

            if (UiListaCliente.EditValue != null) return true;
            UiError.SetError(UiListaCliente, "Seleccione un cliente");
            return false;
        }

        private bool ValidarFechasYCliente()
        {
            var resultado = false;
            UiError.SetError(UiListaCliente, "", ErrorType.None);

            if (UiListaCliente.EditValue == null)
            {
                UiError.SetError(UiListaCliente, "Seleccione un cliente");
                resultado = true;
            }


            if (UiFechaInicio.EditValue == null || UiFechaFinal.EditValue == null)
            {
                InteraccionConUsuarioServicio.Mensaje("Las fechas no pueden ir vacías.");
                return true;
            }

            if (Convert.ToDateTime(UiFechaInicio.EditValue.ToString()) > Convert.ToDateTime(UiFechaFinal.EditValue))
            {

                InteraccionConUsuarioServicio.Mensaje("La fecha de inicio debe ser menor a la fecha final.");
                return true;
            }

            return resultado;
        }

        private bool ValidarAlAgregarDocDet(bool validarTipoDeRecepcion)
        {
            var resultado = false;
            try
            {
                UiError.SetError(UiListaCliente, "", ErrorType.None);
                UiError.SetError(UiListaAcuerdoComercial, "", ErrorType.None);
                UiError.SetError(UiListaPolizasDeSeguro, "", ErrorType.None);
                UiError.SetError(UiListaOperador, "", ErrorType.None);
                //UiError.SetError(UiListaUbicacion, "", ErrorType.None);
                UiError.SetError(UiListaTipoRecepcion, "", ErrorType.None);
                UiError.SetError(UiListaPrioridad, "", ErrorType.None);


                if (UiListaCliente.EditValue == null)
                {
                    UiError.SetError(UiListaCliente, "Campo Obligatorio");
                    resultado = true;
                }

                if (UiListaAcuerdoComercial.EditValue == null)
                {
                    UiError.SetError(UiListaAcuerdoComercial, "Campo Obligatorio");
                    resultado = true;
                }

                if (UiListaPolizasDeSeguro.EditValue == null)
                {
                    UiError.SetError(UiListaPolizasDeSeguro, "Campo Obligatorio");
                    resultado = true;
                }

                if (UiListaOperador.EditValue == null)
                {
                    UiError.SetError(UiListaOperador, "Campo Obligatorio");
                    resultado = true;
                }

                if (validarTipoDeRecepcion && UiListaTipoRecepcion.EditValue == null)
                {
                    UiError.SetError(UiListaTipoRecepcion, "Campo Obligatorio");
                    resultado = true;
                }

                if (UiListaPrioridad.EditValue == null)
                {
                    UiError.SetError(UiListaPrioridad, "Campo Obligatorio");
                    resultado = true;
                }
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
            return resultado;
        }

        private void UiBotonExpandir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UiVistaErp.ExpandAllGroups();
        }

        private void UiBotonContraer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UiVistaErp.CollapseAllGroups();
        }

        private void UiListaCliente_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                LlenarListaEncabezadoErp();
                LLenarAcuerdoComercial();
                LlenarPolizasSeguro();

                seleccionarPrimerRegistroPorCliente();
            }
            catch(Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }            
        }

        private void UiBotonGrabar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (OrdenesDeCompraDetalle == null) return;
                var existeDocAAgregar = OrdenesDeCompraDetalle.Any(detalle => detalle.IS_ASSIGNED == 0);

                if (existeDocAAgregar)
                {
                    UsuarioDeseaGrabarDocmentosErp?.Invoke(null, new DocumentoRecepcionERPArgumento { Consolidado = UIToogleConsolidado.Checked });
                }
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }

        }

        public void LimpiarControles()
        {
            UiListaErp.Properties.DataSource = new List<DocumentoRecepcionErpEncabezado>();
            UiListaAcuerdoComercial.Properties.DataSource = new List<AcuerdoComercial>();
            UiListaPolizasDeSeguro.Properties.DataSource = new List<PolizaAsegurada>();
            UiContenedorVistaErp.DataSource = new List<DocumentoRecepcionErpDetalle>();

            UiListaCliente.EditValue = null;
            UiListaOperador.EditValue = null;
            UiListaUbicacion.EditValue = null;
            UiListaTipoRecepcion.EditValue = null;
            UiListaPrioridad.EditValue = null;
            UiTextoNumeroDeFactura.Text = "";

        }

        private void RecepcionErpVista_FormClosing(object sender, FormClosingEventArgs e)
        {
            CargarOGuardarDisenios(UiContenedorVistaErp, true, Usuario, GetType().Name);
        }

        private void UiBotonExportarExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ExportalAExcel();
        }

        private void ExportalAExcel()
        {
            try
            {
                if (UiContenedorVistaErp.DataSource == null) return;
                if (UiVistaErp.RowCount <= 0) return;

                var dialog = new SaveFileDialog
                {
                    DefaultExt = "xlsx",
                    Filter = @"Archivos de excel (*.xlsx)|*.xlsx"
                };

                if (dialog.ShowDialog() != DialogResult.OK) return;
                UiVistaCliente.ExportToXlsx(dialog.FileName);
                UiVistaErp.ExportToXlsx(dialog.FileName);
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void UiToogleOrdenesIncompletas_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                LlenarListaEncabezadoErp();
                LLenarAcuerdoComercial();
                LlenarPolizasSeguro();
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void UiBarFuente_EditValueChanged_1(object sender, EventArgs e)
        {
            if (Enums.GetStringValue((FuenteDeRecepcionDeErp)UiBarFuente.EditValue) == Enums.GetStringValue(FuenteDeRecepcionDeErp.OrdenDeCompra))
            {
                UiEtiquetaERP.Text = "ERP:";
                UiFechaInicio.Visibility = BarItemVisibility.Always;
                UiFechaFinal.Visibility = BarItemVisibility.Always;
                UiToogleOrdenesIncompletas.Visibility = BarItemVisibility.Always;
                UiListaErp.Visible = true;
                UiTextoNumeroDeFactura.Visible = false;
                colDetPROVIDER_ID.Caption = "Código Proveedor";
                colDetPROVIDER_NAME.Caption = "Nombre Proveedor";
                UiEtiqeutaTipoRecepcion.Visible = true;
                UiListaTipoRecepcion.Visible = true;
                LimpiarControles();
            }
            else
            {
                UiEtiquetaERP.Text = "Número de Factura:";
                UiFechaInicio.Visibility = BarItemVisibility.Never;
                UiFechaFinal.Visibility = BarItemVisibility.Never;
                UiToogleOrdenesIncompletas.Visibility = BarItemVisibility.Never;
                UiListaErp.Visible = false;
                UiTextoNumeroDeFactura.Visible = true;
                colDetPROVIDER_ID.Caption = "Código Cliente";
                colDetPROVIDER_NAME.Caption = "Nombre Cliente";
                UiEtiqeutaTipoRecepcion.Visible = false;
                UiListaTipoRecepcion.Visible = false;
                LimpiarControles();
            }
        }

        private void UiTextoNumeroDeFactura_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    UiError.SetError(UiListaCliente, "", ErrorType.None);

                    if (!ValidarAlAgregarDocDet(false))
                    {
                        UsuarioDeseaObtenerFacturaParaDevolucion?.Invoke(sender,
                            new DocumentoRecepcionERPArgumento
                            {
                                DocumentoRecepcionERP =
                                    new DocumentoRecepcionErpEncabezado
                                    {
                                        DOC_NUM = UiTextoNumeroDeFactura.Text,
                                        EXTERNAL_SOURCE_ID =
                                            FuenteExterna.First(fe => fe.CLIENT_CODE == UiListaCliente.EditValue.ToString())
                                                .EXTERNAL_SOURCE_ID,
                                        OWNER = UiListaCliente.EditValue.ToString()
                                    }
                                ,
                                DocumentoRecepcionErpDetalle = new DocumentoRecepcionErpDetalle
                                {
                                    LOGIN_ID = UiListaOperador.EditValue?.ToString() ?? ""
                                    ,
                                    LOCATION_SPOT = UiListaUbicacion.EditValue?.ToString() ?? ""
                                    ,
                                    TYPE_RECEPCTION = (Enums.GetStringValue((FuenteDeRecepcionDeErp)UiBarFuente.EditValue) == Enums.GetStringValue(FuenteDeRecepcionDeErp.OrdenDeCompra) ? UiListaTipoRecepcion.EditValue.ToString() : "DEVOLUCION_FACTURA")
                                    ,
                                    TYPE_RECEPCTION_DRESCRIPTION = (Enums.GetStringValue((FuenteDeRecepcionDeErp)UiBarFuente.EditValue) == Enums.GetStringValue(FuenteDeRecepcionDeErp.OrdenDeCompra) ? UiListaTipoRecepcion.Text : "DEVOLUCION_FACTURA")
                                    ,
                                    PRIORITY = Convert.ToInt32(UiListaPrioridad.EditValue)
                                    ,
                                    PRIORITY_DESCRIPTION = UiListaPrioridad.Text
                                    ,
                                    TRADE_AGREEMENT_ID = Convert.ToInt32(UiListaAcuerdoComercial.EditValue)
                                    ,
                                    TRADE_AGREEMENT_DESCRIPTION = UiListaAcuerdoComercial.Text
                                    ,
                                    CLIENT_CODE = UiListaCliente.EditValue.ToString()
                                    ,
                                    INSURANCE_DOC_ID = UiListaPolizasDeSeguro.EditValue.ToString()
                                    ,
                                    INSURANCE_DOC_DESCRIPTION = UiListaPolizasDeSeguro.Text
                                    ,
                                    SOURCE = Enums.GetStringValue((FuenteDeRecepcionDeErp)UiBarFuente.EditValue)
                                }
                            });
                        UiTextoNumeroDeFactura.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        
    }
}