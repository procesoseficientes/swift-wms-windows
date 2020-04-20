using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
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
using Enums = MobilityScm.Modelo.Tipos.Enums;

namespace MobilityScm.Modelo.Vistas
{
    public partial class VehiculoVista : VistaBase, IVehiculoVista
    {
        #region Eventos
        public event EventHandler<VehiculoArgumento> UsuarioDeseaCrearVehiculo;
        public event EventHandler<VehiculoArgumento> UsuarioDeseaActualizarVehiculo;
        public event EventHandler<VehiculoArgumento> UsuarioDeseaEliminarVehiculo;
        public event EventHandler<VehiculoArgumento> UsuarioDeseaObtenerVehiculos;
        public event EventHandler<VehiculoArgumento> UsuarioDeseaObtenerVehiculo;
        public event EventHandler<VehiculoArgumento> UsuarioDeseaAsociarPiloto;
        public event EventHandler<VehiculoArgumento> UsuarioDeseaDesasociarPiloto;
        public event EventHandler<PilotoArgumento> UsuarioDeseaObtenerPilotosNoAsociadosAVehiculos;
        public event EventHandler<EmpresaDeTransporteArgumento> UsuarioDeseaObtenerEmpresasDeTransporte;
        public event EventHandler<VehiculoArgumento> UsuarioDeseaObtenerPolizas;
        public event EventHandler VistaCargandosePorPrimeraVez;
        #endregion

        #region Propiedades
        public IList<Piloto> Pilotos
        {
            get { return (IList<Piloto>)UiListaPiloto.DataSource; }
            set
            {
                UiListaPiloto.DataSource = value;
                if (!ExisteRegistro(Vehiculo.PILOT_CODE))
                {
                    if (value.Count <= 0) return;
                    Vehiculo.PILOT_CODE = value[0].PILOT_CODE;
                    UiPropiedadesDeVehiculo.Refresh();
                }
            }
        }

        public IList<Vehiculo> Vehiculos
        {
            get { return (IList<Vehiculo>)UiVistaVehiculos.DataSource; }
            set
            {
                UiVistaVehiculos.DataSource = value;
                UiGridVistaVehiculos.ExpandAllGroups();
            }
        }

        public Vehiculo Vehiculo
        {
            get { return (Vehiculo)UiPropiedadesDeVehiculo.SelectedObject; }
            set
            {
                UiPropiedadesDeVehiculo.SelectedObject = value;
                UiPropiedadesDeVehiculo.Refresh();
            }
        }

        public IList<EmpresaDeTransporte> EmpresasDeTransporte
        {
            get { return (IList<EmpresaDeTransporte>)UiListaEmpresa.DataSource; }
            set
            {
                UiListaEmpresa.DataSource = value;
                if (value.Count <= 0) return;
                Vehiculo.TRANSPORT_COMPANY_CODE = value[0].TRANSPORT_COMPANY_CODE;
                UiPropiedadesDeVehiculo.Refresh();
            }
        }

        public IList<PolizaAsegurada> PolizasDeSeguro
        {
            get { return (IList<PolizaAsegurada>) UiListaPolizas.DataSource; }
            set
            {
                UiListaPolizas.DataSource = value;
                UiVistaListaPolizas.Columns.Clear();
                UiVistaListaPolizas.Columns.AddVisible("DOC_ID", "Id Póliza");
                UiVistaListaPolizas.Columns.AddVisible("POLIZA_INSURANCE", "Número de Póliza");
            }
        }
        public IList<Parametro> Parametros { get; set; }
        public IInteraccionConUsuarioServicio InteraccionConUsuarioServicio { get; private set; }
        #endregion

        #region Constructor E Inicializacion

        public VehiculoVista()
        {
            InitializeComponent();

            InteraccionConUsuarioServicio = Mvx.Ioc.Resolve<IInteraccionConUsuarioServicio>();
            Mvx.Ioc.RegisterType<IBaseDeDatosServicio, BaseDeDatosServicio>();
            Mvx.Ioc.Resolve<IConfiguracionDeConexion>();
            Mvx.Ioc.RegisterType<IEmpresaDeTransporteServicio, EmpresaDeTransporteServicio>();
            Mvx.Ioc.RegisterType<IPilotoServicio, PilotoServicio>();
            Mvx.Ioc.RegisterType<IVehiculoServicio, VehiculoServicio>();
            Mvx.Ioc.RegisterType<IPolizaServicio, PolizaServicio>();
            Mvx.Ioc.RegisterType<IVehiculoControlador, VehiculoControlador>();
            Mvx.Ioc.RegisterSingleton<IVehiculoVista, VehiculoVista>(this);
            Mvx.Ioc.RegisterType<IParametroServicio, ParametroServicio>();
            Mvx.Ioc.Resolve<IVehiculoControlador>();
        }

        private void VehiculoVista_Load(object sender, EventArgs e)
        {
            VistaCargandosePorPrimeraVez?.Invoke(sender, e);
            CargarOGuardarDisenios(UiVistaVehiculos, false, InteraccionConUsuarioServicio.ObtenerUsuario(), GetType().Name);
  
            var parametroIntegracion = Parametros.FirstOrDefault(p => p.PARAMETER_ID == Enums.GetStringValue(IdParametro.IntegracionNEXT) && p.GROUP_ID == Enums.GetStringValue(GrupoParametro.Next));
            var mostrarBarraOpciones = (parametroIntegracion != null && int.Parse(parametroIntegracion.VALUE) == (int)SiNo.Si);

            if (mostrarBarraOpciones)
            {
                UIBarraEditor.Visible = false;
            }
        }

        #endregion

        #region Eventos De Controles

        private void UiBotonRefrescar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {

                UsuarioDeseaObtenerVehiculos?.Invoke(sender,
                    new VehiculoArgumento { Vehiculo = new Vehiculo() });

             }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Alerta(ex.Message);
            }
        }

        private void UiBotonExportarExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (UiVistaVehiculos.DataSource == null || UiGridVistaVehiculos.RowCount <= 0) return;

                var dialog = new SaveFileDialog
                {
                    DefaultExt = "xlsx",
                    Filter = @"Archivos de excel (*.xlsx)|*.xlsx"
                };

                if (dialog.ShowDialog() != DialogResult.OK) return;
                UiVistaVehiculos.ExportToXlsx(dialog.FileName);
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Alerta(ex.Message);
            }
        }

        private void UiBotonContraerGrupos_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                UiGridVistaVehiculos.CollapseAllGroups();
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Alerta(ex.Message);
            }
        }

        private void UiBotonExpandirGrupos_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                UiGridVistaVehiculos.ExpandAllGroups();
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Alerta(ex.Message);
            }
        }

        private void UiBotonNuevoVehiculo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                VistaCargandosePorPrimeraVez?.Invoke(sender, e);
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Alerta(ex.Message);
            }
        }

        private void UiBotonGrabarVehiculo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                Grabar();
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Alerta(ex.Message);
            }
        }

        private void UiBotonBorrarVehiculo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (ExisteRegistro(Vehiculo.VEHICLE_CODE))
                {
                    UsuarioDeseaEliminarVehiculo?.Invoke(null, new VehiculoArgumento { Vehiculo = Vehiculo });
                }
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Alerta(ex.Message);
            }
        }

        private void UiBotonAsociarPilotoAVehiculo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                AsociarODesasociarPiloto(true);
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Alerta(ex.Message);
            }
        }

        private void UiBotonDesasociarPilotoDeVehiculo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                AsociarODesasociarPiloto(false);
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Alerta(ex.Message);
            }
        }

        private void UiGridVistaVehiculos_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (!TieneSeleccionadoUnaFilaEnLaVista(UiGridVistaVehiculos)) return;

                Vehiculo = ((Vehiculo)ObtenerFilaSelecciondaDeLaVista(UiGridVistaVehiculos)).ShallowCopy();
                var piloto = new Piloto { PILOT_CODE = Vehiculo.PILOT_CODE };
                UsuarioDeseaObtenerPilotosNoAsociadosAVehiculos?.Invoke(null, new PilotoArgumento { Piloto = piloto });
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Alerta(ex.Message);
            }
        }

        private void UiListaPiloto_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                UiVistaVehiculos.Focus();
                if (BotonSeleccionadoNoTieneEtiqueta(e)) return;
                switch (e.Button.Tag.ToString())
                {
                    case "UiBotonRefrescarListaEmpresas":
                        UsuarioDeseaObtenerEmpresasDeTransporte?.Invoke(null, new EmpresaDeTransporteArgumento {EmpresaDeTransporte = new EmpresaDeTransporte()});
                        break;
                    case "UiBotonRefrescarListaPilotos":
                        var piloto = new Piloto();

                        if (ExisteRegistro(Vehiculo.VEHICLE_CODE))
                        {
                            var firstOrDefault = Vehiculos.ToList().FirstOrDefault(v => v.VEHICLE_CODE == Vehiculo.VEHICLE_CODE);
                            if (firstOrDefault != null)
                            {
                                piloto.PILOT_CODE = firstOrDefault.PILOT_CODE;
                            }
                        }

                        UsuarioDeseaObtenerPilotosNoAsociadosAVehiculos?.Invoke(null, new PilotoArgumento { Piloto = piloto });
                        break;
                    case "UiBotonRefrescarPolizas":
                        UsuarioDeseaObtenerPolizas?.Invoke(null, new VehiculoArgumento());
                        break;
                }
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Alerta(ex.Message);
            }
        }
        
        #endregion


        #region Metodos
        
        private static bool BotonSeleccionadoNoTieneEtiqueta(DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            return e.Button.Tag == null;
        }


        private bool ExisteRegistro(int? valor)
        {
            return valor != null && valor != 0;
        }



        private void Grabar()
        {
            try
            {
                UiVistaVehiculos.Focus();
                if (!ValidarCampos()) return;
                Vehiculo.LAST_UPDATE_BY = InteraccionConUsuarioServicio.ObtenerUsuario();
                if (!ExisteRegistro(Vehiculo.VEHICLE_CODE))
                {
                    UsuarioDeseaCrearVehiculo?.Invoke(null, new VehiculoArgumento { Vehiculo = Vehiculo });
                }
                else
                {
                    UsuarioDeseaActualizarVehiculo?.Invoke(null, new VehiculoArgumento { Vehiculo = Vehiculo });
                }
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Alerta(ex.Message);
            }
        }

        private bool ValidarCampos()
        {
            try
            {
                if (string.IsNullOrEmpty(Vehiculo.BRAND))
                {
                    InteraccionConUsuarioServicio.MensajeErrorDialogo("Ingrese la marca");
                    return false;
                }
                if (string.IsNullOrEmpty(Vehiculo.LINE))
                {
                    InteraccionConUsuarioServicio.MensajeErrorDialogo("Ingrese la línea");
                    return false;
                }
                if (string.IsNullOrEmpty(Vehiculo.MODEL))
                {
                    InteraccionConUsuarioServicio.MensajeErrorDialogo("Ingrese el modelo");
                    return false;
                }
                if (string.IsNullOrEmpty(Vehiculo.COLOR))
                {
                    InteraccionConUsuarioServicio.MensajeErrorDialogo("Ingrese el color");
                    return false;
                }
                if (string.IsNullOrEmpty(Vehiculo.CHASSIS_NUMBER))
                {
                    InteraccionConUsuarioServicio.MensajeErrorDialogo("Ingrese el número de chasis.");
                    return false;
                }
                if (string.IsNullOrEmpty(Vehiculo.ENGINE_NUMBER))
                {
                    InteraccionConUsuarioServicio.MensajeErrorDialogo("Ingrese el número de motor.");
                    return false;
                }
                if (string.IsNullOrEmpty(Vehiculo.PLATE_NUMBER))
                {
                    InteraccionConUsuarioServicio.MensajeErrorDialogo("Ingrese la placa.");
                    return false;
                }

                if (Vehiculo.TRANSPORT_COMPANY_CODE == null)
                {
                    InteraccionConUsuarioServicio.MensajeErrorDialogo("Seleccione la empresa de transporte.");
                    return false;
                }
                if (Vehiculo.WEIGHT == null || Vehiculo.WEIGHT <= 0)
                {
                    InteraccionConUsuarioServicio.MensajeErrorDialogo("Ingrese el peso.");
                    return false;
                }
                if (Vehiculo.HIGH == null || Vehiculo.HIGH <= 0)
                {
                    InteraccionConUsuarioServicio.MensajeErrorDialogo("Ingrese la altura.");
                    return false;
                }
                if (Vehiculo.WIDTH == null || Vehiculo.WIDTH <= 0)
                {
                    InteraccionConUsuarioServicio.MensajeErrorDialogo("Ingrese el ancho.");
                    return false;
                }
                if (Vehiculo.DEPTH == null || Vehiculo.DEPTH <= 0)
                {
                    InteraccionConUsuarioServicio.MensajeErrorDialogo("Ingrese la profundidad.");
                    return false;
                }
                if (Vehiculo.VOLUME_FACTOR == null || Vehiculo.VOLUME_FACTOR <= 0)
                {
                    InteraccionConUsuarioServicio.MensajeErrorDialogo("Ingrese el factor volumen.");
                    return false;
                }
                if (Vehiculo.VEHICLE_AXLES == null || Vehiculo.VEHICLE_AXLES <= 0)
                {
                    InteraccionConUsuarioServicio.MensajeErrorDialogo("Ingrese la cantidad de ejes del vehículo.");
                    return false;
                }
                if (string.IsNullOrEmpty(Vehiculo.STATUS))
                {
                    InteraccionConUsuarioServicio.MensajeErrorDialogo("Ingrese el estado del vehículo.");
                    return false;
                }
                if (Vehiculo.AVERAGE_COST_PER_KILOMETER < 0)
                {
                    InteraccionConUsuarioServicio.MensajeErrorDialogo("Ingrese el costo promedio por kilómetro no puede ir negativo.");
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Alerta(ex.Message);
                return false;
            }
        }

        private void AsociarODesasociarPiloto(bool asociar)
        {
            try
            {
                UiVistaVehiculos.Focus();
                if (ExisteRegistro(Vehiculo.VEHICLE_CODE) && ExisteRegistro(Vehiculo.PILOT_CODE))
                {
                    if (asociar)
                    {
                        UsuarioDeseaAsociarPiloto?.Invoke(null, new VehiculoArgumento { Vehiculo = Vehiculo });
                    }
                    else
                    {
                        UsuarioDeseaDesasociarPiloto?.Invoke(null, new VehiculoArgumento { Vehiculo = Vehiculo });
                    }

                }
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Alerta(ex.Message);
            }
        }

        private void CalcularVolumenDelVehiculo(decimal? alto, decimal? ancho, decimal? profundidad)
        {
            if (alto == null || ancho == null || profundidad == null) return;
            Vehiculo.VOLUME_FACTOR = alto * ancho * profundidad;
        }

        private void ObtenerParametros()
        {

        }
        #endregion

        private void UiSpinAlto_EditValueChanged(object sender, EventArgs e)
        {
            var spin = (SpinEdit) sender;
            UiPropiedadesDeVehiculo.Refresh();
            CalcularVolumenDelVehiculo((decimal?)spin.EditValue, Vehiculo.WIDTH, Vehiculo.DEPTH);
        }

        private void UiSpinAcho_EditValueChanged(object sender, EventArgs e)
        {
            var spin = (SpinEdit)sender;
            UiPropiedadesDeVehiculo.Refresh();
            CalcularVolumenDelVehiculo(Vehiculo.HIGH, (decimal?)spin.EditValue, Vehiculo.DEPTH);
        }

        private void UiSpinProfundidad_EditValueChanged(object sender, EventArgs e)
        {
            var spin = (SpinEdit)sender;
            UiPropiedadesDeVehiculo.Refresh();
            CalcularVolumenDelVehiculo(Vehiculo.HIGH, Vehiculo.WIDTH, (decimal?)spin.EditValue);
        }
    }
}
