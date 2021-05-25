using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Modelo.Servicios;
using MobilityScm.Modelo.Tipos;
using MobilityScm.Modelo.Vistas;
using MobilityScm.Vertical.Entidades;
using MobilityScm.Vertical.Servicios;
using Enums = MobilityScm.Modelo.Configuracion.Enums;

namespace MobilityScm.Modelo.Controladores
{
    public class PaseDeSalidaControlador : IPaseDeSalidaControlador
    {
        private readonly IPaseDeSalidaVista _vista;

        public IClienteServicio ClienteServicio { get; set; }

        public IVehiculoServicio VehiculoServicio { get; set; }

        public IUsuarioServicio UsuarioServicio { get; set; }

        public IDemandaDeDespachoServicio DemandaDeDespachoServicio { get; set; }

        public IBodegaServicio BodegaServicio { get; set; }

        public IInteraccionConUsuarioServicio InteraccionConUsuarioServicio { get; set; }

        public IParametroServicio ParametroServicio { get; set; }
        public IPaseDeSalidaServicio PaseDeSalidaServicio { get; set; }

        public IPilotoServicio PilotoServicio { get; set; }
        public IConfiguracionServicio ConfiguracionServicio { get; set; }

        public PaseDeSalidaControlador(IPaseDeSalidaVista vista)
        {
            _vista = vista;
            SuscribirEventos();
        }

        private void SuscribirEventos()
        {
            _vista.VistaCargandosePorPrimeraVez += _vista_VistaCargandosePorPrimeraVez;
            _vista.UsuarioDeseaObtenerClientes += _vista_UsuarioDeseaObtenerClientes;
            _vista.UsuarioDeseaObtenerVehiculos += _vista_UsuarioDeseaObtenerVehiculos;
            _vista.UsuarioDeseaObtenerBodegas += _vista_UsuarioDeseaObtenerBodegas;
            _vista.UsuarioDeseaObtnerAutorizados += _vista_UsuarioDeseaObtnerAutorizados;
            _vista.UsuarioDeseaObtenerEntregas += _vista_UsuarioDeseaObtenerEntregas;
            _vista.UsuarioDeseaObtenerDespachos += _vista_UsuarioDeseaObtenerDespachos;
            _vista.UsuarioDeseaObtenerDetalleDeDespachos += _vista_UsuarioDeseaObtenerDetalleDeDespachos;
            _vista.UsuarioDeseaObtenerPaseDeSalida += _vista_UsuarioDeseaObtenerPaseDeSalida;
            _vista.UsuarioDeseaGrabar += _vista_UsuarioDeseaGrabar;
            _vista.UsuarioDeseaCambiarEstadoAlPase += _vista_UsuarioDeseaCambiarEstadoAlPase;
            _vista.UsuarioDeseaObtenerPaseParaReporte += _vista_UsuarioDeseaObtenerPaseParaReporte;
            _vista.UsuarioDeseaObtenerSoloVehiculos += _vista_UsuarioDeseaObtenerSoloVehiculos;
            _vista.UsuarioDeseaGrabarVehiculo += _vista_UsuarioDeseaGrabarVehiculo;
            _vista.UsuarioDeseaObtenerPilotos += _vista_UsuarioDeseaObtenerPilotos;
            _vista.UsuarioDeseaGrabarPiloto += _vista_UsuarioDeseaGrabarPiloto;

            _vista.UsuarioDeseaObtenerTipoSalida += _vista_UsuarioDeseaObtenerTiposDeSalida;
        }

        private void _vista_UsuarioDeseaGrabarPiloto(object sender, PaseDeSalidaArgumento e)
        {
            try
            {
                var op = InsertarRegistro(e.Piloto.PILOT_CODE) ? PilotoServicio.CrearPiloto(new PilotoArgumento { Piloto = e.Piloto }) : PilotoServicio.ActualizarPiloto(new PilotoArgumento { Piloto = e.Piloto });
                if (op.Resultado == ResultadoOperacionTipo.Exito)
                {
                    _vista.Pilotos = PilotoServicio.ObtenerPilotos(new PilotoArgumento { Piloto = new Piloto() });
                    var codigoPiloto = InsertarRegistro(e.Piloto.PILOT_CODE) ? int.Parse(op.DbData): e.Piloto.PILOT_CODE;
                    _vista.TerminoDeGrabarPiloto(codigoPiloto);
                }
                else
                {
                    InteraccionConUsuarioServicio.MensajeErrorDialogo($"Error al crear o actualizar el vehículo: {op.Resultado}");
                }
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo($"Error al obtener los vehículos: {ex.Message}");
            }
        }

        private void _vista_UsuarioDeseaObtenerPilotos(object sender, PaseDeSalidaArgumento e)
        {
            try
            {
                _vista.Pilotos = PilotoServicio.ObtenerPilotos(new PilotoArgumento { Piloto = new Piloto() });
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo($"Error al obtener los vehículos: {ex.Message}");
            }
        }

        private void _vista_UsuarioDeseaGrabarVehiculo(object sender, PaseDeSalidaArgumento e)
        {
            try
            {
                var op = InsertarRegistro(e.Vehiculo.VEHICLE_CODE) ? VehiculoServicio.CrearVehiculo(new VehiculoArgumento { Vehiculo = e.Vehiculo }) : VehiculoServicio.ActualizarVehiculo(new VehiculoArgumento { Vehiculo = e.Vehiculo });
                if (op.Resultado == ResultadoOperacionTipo.Exito)
                {
                    _vista.SoloVehiculos = VehiculoServicio.ObtenerVehiculos(new VehiculoArgumento { Vehiculo = new Vehiculo() });
                    var codigoVehiculo = InsertarRegistro(e.Vehiculo.VEHICLE_CODE) ? int.Parse(op.DbData) : e.Vehiculo.VEHICLE_CODE;
                    _vista.TerminoDeGrabarVehiculo(codigoVehiculo);
                }
                else
                {
                    InteraccionConUsuarioServicio.MensajeErrorDialogo($"Error al crear o actualizar el vehículo: {op.Resultado}");
                }
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo($"Error al grabar el vehículo: {ex.Message}");
            }
        }

        private void _vista_UsuarioDeseaObtenerSoloVehiculos(object sender, PaseDeSalidaArgumento e)
        {
            try
            {
                _vista.SoloVehiculos = VehiculoServicio.ObtenerVehiculos(new VehiculoArgumento { Vehiculo = new Vehiculo() });
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo($"Error al obtener los vehículos: {ex.Message}");
            }
        }

        private void _vista_UsuarioDeseaObtenerPaseParaReporte(object sender, PaseDeSalidaArgumento e)
        {
            try
            {
                _vista.PaseDeSalidas = PaseDeSalidaServicio.ObtenerPasesDeSalidaParaReporte(e);
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo($"Error al obtener el pase de salida para reporte: {ex.Message}");
            }
        }

        private void _vista_UsuarioDeseaCambiarEstadoAlPase(object sender, PaseDeSalidaArgumento e)
        {
            try
            {
                bool pAlt = bool.Parse(ConfigurationManager.AppSettings["PaseDeSalidaAlt"]);
                // Actualiza el estado del Pase de Salida para Ferco
                if (pAlt)
                {
                    DataTable op = PaseDeSalidaServicio.ActualizarEstadoParaElPaseDeSalidaFerco(e);
                    int result = op.Rows[0].Field<int>(0);
                    if (result == 1)
                    {
                        _vista.TerminoDeActualizarEstado(Convert.ToInt32(e.PaseDeSalidaEncabezado.PASS_ID),
                            e.PaseDeSalidaEncabezado.STATUS);
                    }
                    else
                    {
                        InteraccionConUsuarioServicio.MensajeErrorDialogo(op.Rows[0].Field<string>(1));
                    }
                }
                // Actualiza el estado del Pase de Salida para los demas clientes
                else
                {
                    var op = PaseDeSalidaServicio.ActualizarEstadoParaElPaseDeSalida(e);
                    if (op.Resultado == ResultadoOperacionTipo.Exito)
                    {
                        _vista.TerminoDeActualizarEstado(Convert.ToInt32(e.PaseDeSalidaEncabezado.PASS_ID),
                            e.PaseDeSalidaEncabezado.STATUS);
                    }
                    else
                    {
                        InteraccionConUsuarioServicio.MensajeErrorDialogo(op.Mensaje);
                    }
                }
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo($"Error al cambiar el estado del pase: {ex.Message}");
            }
        }

        private void _vista_UsuarioDeseaObtenerPaseDeSalida(object sender, PaseDeSalidaArgumento e)
        {
            try
            {
                var pase = PaseDeSalidaServicio.ObtenerPase(e).FirstOrDefault();
                if (pase != null)
                {
                    _vista.DespachosDetalles = new List<DemandaDespachoDetalle>();
                    _vista.CargarControlesEncabezado(pase);
                    UnirDetalleDePaseConLasDemandas(e);
                }
                else
                {
                    InteraccionConUsuarioServicio.MensajeErrorDialogo($"No se encontro el pase de salida");
                }

            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo($"Error al obtener el pase: {ex.Message}");
            }
        }

        private void _vista_UsuarioDeseaGrabar(object sender, PaseDeSalidaArgumento e)
        {
            try
            {
                e.Login = InteraccionConUsuarioServicio.ObtenerUsuario();
                e.Xml = ObtenerXmlDeLicencias();
                var op = PaseDeSalidaServicio.GrabarPaseDeSalida(e);
                if (op.Resultado == ResultadoOperacionTipo.Error)
                {
                    InteraccionConUsuarioServicio.MensajeErrorDialogo($"Error al grabar el pase de salida: {op.Mensaje}");
                }
                else
                {
                    _vista.TerminoDeGrabar(Convert.ToInt32(e.PaseDeSalidaEncabezado.PASS_ID));
                    UnirDetalleDePaseConLasDemandas(e);
                }

            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo($"Error al preparar el pase de salida para guardar: {ex.Message}");
            }
        }

        private string ObtenerXmlDeLicencias()
        {
            var documentoXml = new XDocument(new XDeclaration("1.0", "iso-8859-1", null));
            var nodoRaiz = new XElement("ArrayOfPassDetail");
            documentoXml.Add(nodoRaiz);


            _vista.DespachosDetalles.Where(d => d.QTY > 0).ToList().ForEach(d =>
            {
                var nodoInventario = new XElement("Detail");
                nodoInventario.Add(new XElement("CLIENT_CODE", d.CLIENT_CODE));
                nodoInventario.Add(new XElement("CLIENT_NAME", d.CLIENT_NAME));
                nodoInventario.Add(new XElement("PICKING_DEMAND_HEADER_ID", d.PICKING_DEMAND_HEADER_ID));
                nodoInventario.Add(new XElement("DOC_NUM", d.DOC_NUM));
                nodoInventario.Add(new XElement("MATERIAL_ID", d.MATERIAL_ID));
                nodoInventario.Add(new XElement("MATERIAL_NAME", d.MATERIAL_NAME));
                nodoInventario.Add(new XElement("QTY", d.QTY));
                nodoInventario.Add(new XElement("DOC_NUM_POLIZA", d.DOC_NUM_POLIZA));
                nodoInventario.Add(new XElement("CODIGO_POLIZA", d.CODIGO_POLIZA));
                nodoInventario.Add(new XElement("NUMERO_ORDEN_POLIZA", d.NUMERO_ORDEN_POLIZA));
                nodoInventario.Add(new XElement("WAVE_PICKING_ID", d.WAVE_PICKING_ID));
                nodoInventario.Add(new XElement("CREATED_DATE", d.CREATED_DATE));
                nodoInventario.Add(new XElement("CODE_WAREHOUSE", d.CODE_WAREHOUSE));
                nodoInventario.Add(new XElement("TYPE_DEMAND_CODE", d.TYPE_DEMAND_CODE));
                nodoInventario.Add(new XElement("TYPE_DEMAND_NAME", d.TYPE_DEMAND_NAME));
                nodoInventario.Add(new XElement("LINE_NUM", d.LINE_NUM));
                nodoRaiz.Add(nodoInventario);
            });
            return documentoXml.ToString();

        }

        private void _vista_UsuarioDeseaObtenerDetalleDeDespachos(object sender, PaseDeSalidaArgumento e)
        {
            try
            {
                _vista.DespachosDetalles = DemandaDeDespachoServicio.ObtnerDemandasDetallesParaPaseDeSalida(e);
                UnirDetalleDePaseConLasDemandas(e);
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaObtenerDespachos(object sender, PaseDeSalidaArgumento e)
        {
            try
            {
                _vista.DespachoEncabezados = DemandaDeDespachoServicio.ObtnerDemandasEncabezadosParaPaseDeSalida(e);
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaObtenerEntregas(object sender, PaseDeSalidaArgumento e)
        {
            try
            {
                _vista.UsuariosParaEntrega = UsuarioServicio.ObtenerUsuariosActivosPorCentroDeDistribucion(InteraccionConUsuarioServicio.ObtenerCentroDistribucion());
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaObtnerAutorizados(object sender, PaseDeSalidaArgumento e)
        {
            try
            {
                _vista.UsuariosParaAutorizar = UsuarioServicio.ObtenerUsuariosActivosPorCentroDeDistribucion(InteraccionConUsuarioServicio.ObtenerCentroDistribucion());
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaObtenerBodegas(object sender, PaseDeSalidaArgumento e)
        {
            try
            {
                _vista.Bodegas = BodegaServicio.ObtenerBodegaAsignadaAUsuario(InteraccionConUsuarioServicio.ObtenerUsuario());
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaObtenerVehiculos(object sender, PaseDeSalidaArgumento e)
        {
            try
            {
                _vista.Vehiculos = VehiculoServicio.ObtenerVehiculos(new VehiculoArgumento { Vehiculo = new Vehiculo() });

            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaObtenerClientes(object sender, PaseDeSalidaArgumento e)
        {
            try
            {
                _vista.Clientes = ClienteServicio.ObtenerClientes();

            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(ex.Message);
            }
        }

        private void _vista_VistaCargandosePorPrimeraVez(object sender, EventArgs e)
        {
            try
            {
                _vista.Parametros = new List<Parametro>();
                _vista.Clientes = ClienteServicio.ObtenerClientes();
                _vista.Vehiculos = VehiculoServicio.ObtenerVehiculos(new VehiculoArgumento { Vehiculo = new Vehiculo() });
                _vista.Bodegas = BodegaServicio.ObtenerBodegaAsignadaAUsuario(InteraccionConUsuarioServicio.ObtenerUsuario());
                _vista.UsuariosParaAutorizar = UsuarioServicio.ObtenerUsuariosActivosPorCentroDeDistribucion(InteraccionConUsuarioServicio.ObtenerCentroDistribucion());
                _vista.UsuariosParaEntrega = UsuarioServicio.ObtenerUsuariosActivosPorCentroDeDistribucion(InteraccionConUsuarioServicio.ObtenerCentroDistribucion());
                ObtenerParametros();
                _vista.SoloVehiculos = VehiculoServicio.ObtenerVehiculos(new VehiculoArgumento { Vehiculo = new Vehiculo() });
                _vista.Pilotos = PilotoServicio.ObtenerPilotos(new PilotoArgumento {Piloto = new Piloto()});
                _vista.DespachosDetalles = new List<DemandaDespachoDetalle>();
                _vista.PaseDeSalidas = new List<PaseDeSalida>();
                ObtenerTiposDeSalida();
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(ex.Message);
            }
        }

        private void ObtenerParametros()
        {
            _vista.Parametros = ParametroServicio.ObtenerParametro(new ConsultaArgumento
            {
                GrupoParametro = Enums.GetStringValue(GrupoParametro.DemandaDePicking),
                IdParametro = Enums.GetStringValue(IdParametro.ObtieneTipoDeDemanda)
            });
            var parametrosTemporal = ParametroServicio.ObtenerParametro(new ConsultaArgumento
            {
                GrupoParametro = Enums.GetStringValue(GrupoParametro.Sistema),
                IdParametro = Enums.GetStringValue(IdParametro.GeneraFactura)
            });
            foreach (var parametro in parametrosTemporal)
            {
                _vista.Parametros.Add(parametro);
            }

            parametrosTemporal = ParametroServicio.ObtenerParametro(new ConsultaArgumento
            {
                GrupoParametro = Enums.GetStringValue(GrupoParametro.Pase),
                IdParametro = Enums.GetStringValue(IdParametro.MostrarEtiquetaDeGarantia)
            });

            foreach (var parametro in parametrosTemporal)
            {
                _vista.Parametros.Add(parametro);
            }

            parametrosTemporal = ParametroServicio.ObtenerParametro(new ConsultaArgumento
            {
                GrupoParametro = Enums.GetStringValue(GrupoParametro.Pase),
                IdParametro = Enums.GetStringValue(IdParametro.InsertarOActualizarVehiculoYPiloto)
            });

            foreach (var parametro in parametrosTemporal)
            {
                _vista.Parametros.Add(parametro);
            }

            parametrosTemporal = ParametroServicio.ObtenerParametro(new ConsultaArgumento
            {
                GrupoParametro = Enums.GetStringValue(GrupoParametro.Pase),
                IdParametro = Enums.GetStringValue(IdParametro.MostrarEtiquetaDePanelCondiciones)
            });

            foreach (var parametro in parametrosTemporal)
            {
                _vista.Parametros.Add(parametro);
            }
        }

        private void UnirDetalleDePaseConLasDemandas(PaseDeSalidaArgumento e)
        {
            try
            {
                var detallesDePase = PaseDeSalidaServicio.ObtenerDetalleDePase(e).ToList();
                var detallesDeDespachos = _vista.DespachosDetalles.ToList();
                foreach (var detallePase in detallesDePase)
                {

                    var detalleDespacho = detallesDeDespachos.ToList().FirstOrDefault(d =>
                                                                                        ((d.PICKING_DEMAND_HEADER_ID != 0) 
                                                                                        ? d.PICKING_DEMAND_HEADER_ID == detallePase.PICKING_DEMAND_HEADER_ID 
                                                                                        : d.WAVE_PICKING_ID == detallePase.WAVE_PICKING_ID) &&
                                                                                        d.MATERIAL_ID == detallePase.MATERIAL_ID && 
                                                                                        d.LINE_NUM == detallePase.LINE_NUM);
                    if (detalleDespacho != null)
                    {
                        detalleDespacho.QTY_AVAILABLE = detalleDespacho.QTY_AVAILABLE + detallePase.QTY;
                        detalleDespacho.QTY = detallePase.QTY;
                    }
                    else
                    {
                        var demandaDetalle = new DemandaDespachoDetalle
                        {
                            CLIENT_CODE = detallePase.CLIENT_CODE
                            ,
                            CLIENT_NAME = detallePase.CLIENT_NAME
                            ,
                            PICKING_DEMAND_HEADER_ID = detallePase.PICKING_DEMAND_HEADER_ID
                            ,
                            DOC_NUM = detallePase.DOC_NUM
                            ,
                            MATERIAL_ID = detallePase.MATERIAL_ID
                            ,
                            MATERIAL_NAME = detallePase.MATERIAL_NAME
                            ,
                            QTY_AVAILABLE = detallePase.QTY
                            ,
                            QTY = detallePase.QTY
                            ,
                            DOC_NUM_POLIZA = detallePase.DOC_NUM_POLIZA
                            ,
                            CODIGO_POLIZA = detallePase.CODIGO_POLIZA
                            ,
                            NUMERO_ORDEN_POLIZA = detallePase.NUMERO_ORDEN_POLIZA
                            ,
                            WAVE_PICKING_ID = detallePase.WAVE_PICKING_ID
                            ,
                            CREATED_DATE = detallePase.CREATED_DATE
                            ,
                            CODE_WAREHOUSE = detallePase.CODE_WAREHOUSE
                            ,TYPE_DEMAND_CODE = detallePase.TYPE_DEMAND_CODE
                            ,
                            TYPE_DEMAND_NAME = detallePase.TYPE_DEMAND_NAME
                        };
                        detallesDeDespachos.Add(demandaDetalle);
                    }
                }
                _vista.DespachosDetalles = detallesDeDespachos.ToList();

            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(ex.Message);
            }
        }

        private bool InsertarRegistro(int? valor)
        {
            return valor == 0;
        }

        private void _vista_UsuarioDeseaObtenerTiposDeSalida(object sender, Argumentos.PaseDeSalidaArgumento e)
        {
            ObtenerTiposDeSalida();
        }
        private void ObtenerTiposDeSalida()
        {
            try
            {
                var listaTiposDeTarea = ConfiguracionServicio.ObtenerConfiguracionesGrupoYTipo(new Entidades.Configuracion
                {
                    PARAM_GROUP = Enums.GetStringValue(GrupoParametro.TipoSalida)
                    ,
                    PARAM_TYPE = Enums.GetStringValue(TipoDeClasificaciones.Sistema)
                });
                _vista.TipoSalida = listaTiposDeTarea;
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.Mensaje(exception.Message);
            }
        }

    }
}
