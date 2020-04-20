using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
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
    public partial class ProyectoVista : VistaBaseDeveExpress, IProyectoVista
    {
        #region Eventos

        public event EventHandler<ProyectoArgumento> UsuarioDeseaObtenerProyectos;
        public event EventHandler<ProyectoArgumento> UsuarioDeseaGrabarProyecto;
        public event EventHandler<ProyectoArgumento> UsuarioDeseaEliminarProyecto;
        public event EventHandler<ProyectoArgumento> UsuarioDeseaObtenerClientesErp;
        public event EventHandler VistaCargandosePorPrimeraVez;


        public event EventHandler<ProyectoArgumento> UsuarioDeseaObtenerInventarioDisponible;
        public event EventHandler<ProyectoArgumento> UsuarioDeseaObtenerInventarioReservado;
        public event EventHandler<ProyectoArgumento> UsuarioDeseaAsignarInventarioAProyecto;
        public event EventHandler<ProyectoArgumento> UsuarioDeseaEliminarInventarioDeProyecto;
        public event EventHandler<ProyectoArgumento> UsuarioDeseaObtenerProductos;

        #endregion

        #region Propiedades

        public IList<Proyecto> Proyectos
        {
            get { return (IList<Proyecto>)UIControlDeVistas.DataSource; }
            set { UIControlDeVistas.DataSource = value; }
        }

        public Proyecto ProyectoSeleccionado { get; set; }


        public IInteraccionConUsuarioServicio InteraccionConUsuarioServicio { get; set; }
        public IList<Cliente> Clientes
        {
            get { return (IList<Cliente>)UiListaClienteProyecto.Properties.DataSource; }
            set { UiListaClienteProyecto.Properties.DataSource = value; }
        }

        public IList<Material> Skus
        {
            get { return (IList<Material>)UiVistaMateriales.Properties.DataSource; }
            set { UiVistaMateriales.Properties.DataSource = value; }
        }

        public IList<InventarioReservadoProyecto> InventarioAsignadoAProyecto
        {
            get { return (IList<InventarioReservadoProyecto>)UiInventarioProyecto.DataSource; }
            set { UiInventarioProyecto.DataSource = value; }
        }

        public IList<InventarioReservadoProyecto> InventarioPendienteDeAsignar
        {
            get { return (IList<InventarioReservadoProyecto>)UiVistaInventarioDisponible.Properties.DataSource; }
            set { UiVistaInventarioDisponible.Properties.DataSource = value; }
        }

        public IList<ResumenInventarioProyecto> ResumenProyecto
        {
            get { return (IList<ResumenInventarioProyecto>)UiResumenProyecto.DataSource; }
            set { UiResumenProyecto.DataSource = value; }
        }
        #endregion

        public ProyectoVista()
        {
            InitializeComponent();
            Mvx.Ioc.RegisterType<IBaseDeDatosServicio, BaseDeDatosServicio>();
            Mvx.Ioc.Resolve<IConfiguracionDeConexion>();
            InteraccionConUsuarioServicio = Mvx.Ioc.Resolve<IInteraccionConUsuarioServicio>();
            Mvx.Ioc.RegisterType<IProyectoServicio, ProyectoServicio>();
            Mvx.Ioc.RegisterType<IClienteServicio, ClienteServicio>();
            Mvx.Ioc.RegisterSingleton<IProyectoVista, ProyectoVista>(this);
            Mvx.Ioc.RegisterType<IProyectoControlador, ProyectoControlador>();
            Mvx.Ioc.Resolve<IProyectoControlador>();
        }

        private void ProyectoVista_Load(object sender, EventArgs e)
        {
            try
            {
                UiListaEstado.EditValue = "Todos";
                CrearValidaciones();
                VistaCargandosePorPrimeraVez?.Invoke(null, null);
                GuardarOCargarDiseniosDeControles(this, InteraccionConUsuarioServicio.ObtenerUsuario(), false, GetType().Name);

                ImplementarSeleccionMultipleDeUnaLista(UiVistaMateriales, new ObjetoParaGuardarEnVista { ListaDeCamposAMostrar = (new[] { "MATERIAL_ID" }) });
                ImplementarSeleccionMultipleDeUnaLista(UiVistaInventarioDisponible, new ObjetoParaGuardarEnVista { ListaDeCamposAMostrar = (new[] { "LICENSE_ID", "MATERIAL_ID" }) });
                ImplementarSeleccionMultipleDeUnaVista(UiVistaInventarioProyecto);
                UiListaEstado.EditValue = "Todos";
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(ex.Message);
            }
        }

        private void ProyectoVista_FormClosing(object sender, FormClosingEventArgs e)
        {
            InteraccionConUsuarioServicio.MostrarDialogoDeCargando();
            try
            {
                GuardarOCargarDiseniosDeControles(this, InteraccionConUsuarioServicio.ObtenerUsuario(), true, GetType().Name);
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(ex.Message);
            }
            InteraccionConUsuarioServicio.CerrarDialogoDeCargando();
        }

        private void UiBotonExpandir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UiVistaProyecto.ExpandAllGroups();
        }

        private void UiBotonContraer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UiVistaProyecto.CollapseAllGroups();
        }

        private void UiBotonExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            InteraccionConUsuarioServicio.MostrarDialogoDeCargando();
            try
            {
                ExportarVista(UiVistaProyecto, true, ExportarA.Excel);
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(ex.Message);
            }
            InteraccionConUsuarioServicio.CerrarDialogoDeCargando();
        }

        private void UiBotonRefrescar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            InteraccionConUsuarioServicio.MostrarDialogoDeCargando();
            try
            {
                RefrescarVista();
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(ex.Message);
            }
            InteraccionConUsuarioServicio.CerrarDialogoDeCargando();
        }

        private void UiBotonNuevoProyecto_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            InteraccionConUsuarioServicio.MostrarDialogoDeCargando();
            try
            {
                LimpiarControles();
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(ex.Message);
            }
            InteraccionConUsuarioServicio.CerrarDialogoDeCargando();
        }

        private void UiBotonGrabarProyecto_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            InteraccionConUsuarioServicio.MostrarDialogoDeCargando();
            try
            {
                if (!UiDxValidaciones.Validate()) return;
                ProyectoSeleccionado.CUSTOMER_NAME = null;

                ProyectoSeleccionado.OPPORTUNITY_CODE = UiTextoCodigoProyecto.Text;
                ProyectoSeleccionado.OPPORTUNITY_NAME = UiTextoNombreProyecto.Text;
                ProyectoSeleccionado.SHORT_NAME = UiTextoNombreCortoProyecto.Text;
                ProyectoSeleccionado.OBSERVATIONS = UIMemoObservacionesProyecto.Text;
                ProyectoSeleccionado.STATUS = Enums.GetStringValue(EstadoDeProyecto.Creado);
                ProyectoSeleccionado.CUSTOMER_CODE = UiListaClienteProyecto.EditValue?.ToString();
                if (string.IsNullOrEmpty(ProyectoSeleccionado.CUSTOMER_CODE))
                {
                    InteraccionConUsuarioServicio.MensajeErrorDialogo("Debe seleccionar cliente");
                    return;
                }
                if (!string.IsNullOrEmpty(ProyectoSeleccionado.CUSTOMER_CODE))
                {
                    var clientes = Clientes.FirstOrDefault(c => c.CUSTOMER_CODE == ProyectoSeleccionado.CUSTOMER_CODE);
                    ProyectoSeleccionado.CUSTOMER_NAME = clientes?.CUSTOMER_NAME;
                    ProyectoSeleccionado.CUSTOMER_OWNER = clientes?.OWNER;
                }
                UsuarioDeseaGrabarProyecto?.Invoke(null, new ProyectoArgumento
                {
                    Login = InteraccionConUsuarioServicio.ObtenerUsuario(),
                    Proyecto = ProyectoSeleccionado
                });

            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(ex.Message);
            }
            InteraccionConUsuarioServicio.CerrarDialogoDeCargando();
        }

        private void UiVistaProyecto_Click(object sender, EventArgs e)
        {
            InteraccionConUsuarioServicio.MostrarDialogoDeCargando();
            try
            {
                var indice = UiVistaProyecto.FocusedRowHandle;
                if (indice < 0) return;
                var registro = (Proyecto)UiVistaProyecto.GetRow(indice);
                ProyectoSeleccionado = registro;
                EditarTextoCodigo(UiTextoCodigoProyecto, ProyectoSeleccionado.OPPORTUNITY_CODE, false);
                UiTextoNombreProyecto.Text = ProyectoSeleccionado.OPPORTUNITY_NAME;
                UiTextoNombreCortoProyecto.Text = ProyectoSeleccionado.SHORT_NAME;
                UIMemoObservacionesProyecto.Text = ProyectoSeleccionado.OBSERVATIONS;
                UiListaClienteProyecto.EditValue = ProyectoSeleccionado.CUSTOMER_CODE;
                UsuarioDeseaObtenerProductos?.Invoke(null, null);
                UsuarioDeseaObtenerInventarioReservado?.Invoke(sender, new ProyectoArgumento { Proyecto = ProyectoSeleccionado });
                UiTabInventarioProyecto.PageVisible = true;
                UiTabResumenProyecto.PageVisible = true;
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
            InteraccionConUsuarioServicio.CerrarDialogoDeCargando();
        }

        private void UiBotonEliminarProyecto_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            InteraccionConUsuarioServicio.MostrarDialogoDeCargando();
            try
            {
                if (ProyectoSeleccionado.ID == Guid.Empty) return;
                UsuarioDeseaEliminarProyecto?.Invoke(null, new ProyectoArgumento
                {
                    Login = InteraccionConUsuarioServicio.ObtenerUsuario(),
                    Proyecto = ProyectoSeleccionado
                });
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(ex.Message);
            }
            InteraccionConUsuarioServicio.CerrarDialogoDeCargando();
        }

        private void UiLista_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            InteraccionConUsuarioServicio.MostrarDialogoDeCargando();
            try
            {
                if (e.Button.Tag == null) return;
                switch (e.Button.Tag.ToString())
                {
                    case "UiBtnRefrescarClientesProyecto":
                        UsuarioDeseaObtenerClientesErp?.Invoke(null, null);
                        break;
                    case "UiBtnRefrescarMateriales":
                        if (ProyectoSeleccionado.ID == Guid.Empty) return;
                        UsuarioDeseaObtenerProductos?.Invoke(null, null);
                        break;
                    case "UiBtnRefrescarInventarioDisponible":
                        if (ProyectoSeleccionado.ID == Guid.Empty) return;
                        UsuarioDeseaObtenerInventarioDisponible?.Invoke(sender, new ProyectoArgumento { Proyecto = ProyectoSeleccionado, Login = InteraccionConUsuarioServicio.ObtenerUsuario() });
                        break;
                }
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(ex.Message);
            }
            InteraccionConUsuarioServicio.CerrarDialogoDeCargando();
        }

        private void RefrescarVista()
        {
            try
            {
                var indice = UiVistaProyecto.FocusedRowHandle;
                string estado = null;
                switch (UiListaEstado.EditValue.ToString())
                {
                    case "Creado":
                        estado = Enums.GetStringValue(EstadoDeProyecto.Creado);
                        break;
                    case "En proceso":
                        estado = Enums.GetStringValue(EstadoDeProyecto.EnProceso);
                        break;
                    case "Completado":
                        estado = Enums.GetStringValue(EstadoDeProyecto.Completado);
                        break;
                    case "Finalizado":
                        estado = Enums.GetStringValue(EstadoDeProyecto.Finalizado);
                        break;
                    case "Cancelado":
                        estado = Enums.GetStringValue(EstadoDeProyecto.Cancelado);
                        break;
                }
                UsuarioDeseaObtenerProyectos?.Invoke(null, new ProyectoArgumento { Proyecto = new Proyecto { STATUS = estado } });
                UiVistaProyecto.FocusedRowHandle = indice;
                UiTabInventarioProyecto.PageVisible = false;
                UiTabResumenProyecto.PageVisible = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CrearValidaciones()
        {
            try
            {
                UiDxValidaciones.ValidationMode = ValidationMode.Manual;

                ConditionValidationRule validacionTextoCodigo = new ConditionValidationRule();
                validacionTextoCodigo.ConditionOperator = ConditionOperator.Contains;
                validacionTextoCodigo.ErrorText = "Ingrese el código";
                validacionTextoCodigo.ErrorType = ErrorType.Critical;

                UiDxValidaciones.SetValidationRule(UiTextoCodigoProyecto, validacionTextoCodigo);

                ConditionValidationRule validacionTextoNombre = new ConditionValidationRule();
                validacionTextoNombre.ConditionOperator = ConditionOperator.Contains;
                validacionTextoNombre.ErrorText = "Ingrese el nombre";
                validacionTextoNombre.ErrorType = ErrorType.Critical;

                UiDxValidaciones.SetValidationRule(UiTextoNombreProyecto, validacionTextoNombre);


                ConditionValidationRule validacionTextoNombreCorto = new ConditionValidationRule();
                validacionTextoNombreCorto.ConditionOperator = ConditionOperator.Contains;
                validacionTextoNombreCorto.ErrorText = "Ingrese el nombre corto(este es el que aparecerá en el móvil)";
                validacionTextoNombreCorto.ErrorType = ErrorType.Critical;

                UiDxValidaciones.SetValidationRule(UiTextoNombreCortoProyecto, validacionTextoNombreCorto);
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(ex.Message);
            }
        }

        public void VistaTermenioDeGrabar()
        {
            try
            {
                RefrescarVista();
                EditarTextoCodigo(UiTextoCodigoProyecto, ProyectoSeleccionado.OPPORTUNITY_CODE, false);

            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(ex.Message);
            }
        }

        public void VistaTerminoDeEliminar()
        {
            try
            {
                RefrescarVista();
                LimpiarControles();
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(ex.Message);
            }
        }

        private void LimpiarControles()
        {
            InteraccionConUsuarioServicio.MostrarDialogoDeCargando();
            try
            {
                ProyectoSeleccionado = new Proyecto();
                EditarTextoCodigo(UiTextoCodigoProyecto, string.Empty, true);
                UiTextoNombreProyecto.Text = string.Empty;
                UiTextoNombreCortoProyecto.Text = string.Empty;
                UIMemoObservacionesProyecto.Text = string.Empty;
                UiListaClienteProyecto.EditValue = null;
                Skus = new List<Material>();
                UiTabInventarioProyecto.PageVisible = false;
                UiTabResumenProyecto.PageVisible = false;
                InventarioPendienteDeAsignar = new List<InventarioReservadoProyecto>();
                InventarioAsignadoAProyecto = new List<InventarioReservadoProyecto>();
                ResumenProyecto = new List<ResumenInventarioProyecto>();
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(ex.Message);
            }
            InteraccionConUsuarioServicio.CerrarDialogoDeCargando();
        }

        private void UiListaEstado_EditValueChanged(object sender, EventArgs e)
        {
            RefrescarVista();
        }

        private void UiBotonAgregarDetalleInventario_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            InteraccionConUsuarioServicio.MostrarDialogoDeCargando();
            try
            {
                if (!UiDxValidaciones.Validate()) return;
                if (InventarioPendienteDeAsignar == null || InventarioPendienteDeAsignar.Count == 0)
                {
                    InteraccionConUsuarioServicio.MensajeErrorDialogo("Debe seleccionar inventario para asignar al proyecto");
                };

                UsuarioDeseaAsignarInventarioAProyecto?.Invoke(null, new ProyectoArgumento
                {
                    Login = InteraccionConUsuarioServicio.ObtenerUsuario(),
                    Proyecto = ProyectoSeleccionado,
                    LicenciasXml = Xml.ConvertListToXml(InventarioPendienteDeAsignar.Where(m => m.IS_SELECTED).ToList())
                });
                VistaTerminoDeEliminar();
                UiVistaProyecto_Click(sender, e);
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(ex.Message);
            }
            InteraccionConUsuarioServicio.CerrarDialogoDeCargando();
        }

        private void UiBotonEliminarInventario_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            InteraccionConUsuarioServicio.MostrarDialogoDeCargando();
            try
            {
                if (InventarioAsignadoAProyecto == null || InventarioAsignadoAProyecto.Where(m => m.IS_SELECTED).ToList().Count == 0)
                {
                    InteraccionConUsuarioServicio.MensajeErrorDialogo("Debe seleccionar el inventario a eliminar");
                    return;
                }

                foreach(var inventory in InventarioAsignadoAProyecto.Where(m => m.IS_SELECTED).ToList())
                {
                    if (inventory.RESERVED_PICKING > 0 || inventory.QTY_DISPATCHED > 0)
                    {
                        InteraccionConUsuarioServicio.MensajeErrorDialogo("No se puede realizar la acción, inventario despachado o reservado para picking.");
                        return;
                    }
                }
                
                if (ProyectoSeleccionado == null || ProyectoSeleccionado.ID == Guid.Empty) return;
                UsuarioDeseaEliminarInventarioDeProyecto?.Invoke(null, new ProyectoArgumento
                {
                    Login = InteraccionConUsuarioServicio.ObtenerUsuario(),
                    Proyecto = ProyectoSeleccionado,
                    LicenciasXml = Xml.ConvertListToXml(InventarioAsignadoAProyecto.Where(m => m.IS_SELECTED).ToList())
                });
                UsuarioDeseaObtenerInventarioReservado?.Invoke(sender, new ProyectoArgumento { Proyecto = ProyectoSeleccionado });
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(ex.Message);
            }
            InteraccionConUsuarioServicio.CerrarDialogoDeCargando();
        }

        private void UiBotonExpandirInventario_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UiVistaInventarioProyecto.ExpandAllGroups();
        }

        private void UiBotonContraerInventario_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UiVistaInventarioProyecto.CollapseAllGroups();
        }

        private void UiBotonExportarAExcelInventarioReservado_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            InteraccionConUsuarioServicio.MostrarDialogoDeCargando();
            try
            {
                ExportarVista(UiVistaInventarioProyecto, true, ExportarA.Excel);
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(ex.Message);
            }
            InteraccionConUsuarioServicio.CerrarDialogoDeCargando();
        }
    }
}