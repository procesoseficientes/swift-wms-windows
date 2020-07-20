using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Estados;
using MobilityScm.Modelo.Interfaces.Controladores;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Modelo.Servicios;
using MobilityScm.Modelo.Tipos;
using MobilityScm.Modelo.Vistas;
using MobilityScm.Vertical.Servicios;
using System.Xml.Linq;
using DevExpress.Data.Filtering.Helpers;
using MobilityScm.Utilerias;
using MoreLinq;

namespace MobilityScm.Modelo.Controladores
{
    public class DemandaDeDespachoControlador : IDemandaDeDespachoControlador
    {
        private readonly IDemandaDeDespachoVista _vista;

        public IOrdenDeVentaSwiftExpressServicio OrdenDeVentaSwiftExpressServicio { get; set; }

        public IPickingServicio PickingServicio { get; set; }

        public IRutasSwiftExpressServicio RutasSwiftExpressServicio { get; set; }

        public IInteraccionConUsuarioServicio InteraccionConUsuarioServicio { get; set; }

        public IPolizaServicio PolizaServicio { get; set; }

        public IDemandaDeDespachoServicio DemandaDeDespachoServicio { get; set; }

        public IBodegaServicio BodegaServicio { get; set; }

        public IOrdenDeVentaERPServicio OrdenDeVentaErpServicio { get; set; }
        public IUbicacionServicio UbicacionServicio { get; set; }

        public IClienteServicio ClienteServicio { get; set; }

        public ISolicitudDeTrasladoServicio SolicitudDeTrasladoServicio { get; set; }

        public IConfiguracionServicio ConfiguracionServicio { get; set; }

        public IPoligonoServicio PoligonoServicio { get; set; }

        public IParametroServicio ParametroServicio { get; set; }

        public IVehiculoServicio VehiculoServicio { get; set; }

        public IBaseDeDatosServicio BaseDeDatosServicio { get; set; }
        public IManifiestoCargaServicio ManifiestoCargaServicio { get; set; }
        public IProyectoServicio ProyectoServicio { get; set; }

        public DemandaDeDespachoControlador(IDemandaDeDespachoVista vista)
        {
            _vista = vista;
            SuscribirEventos();
        }

        private void SuscribirEventos()
        {
            _vista.VistaCargandosePorPrimeraVez += _vista_VistaCargandosePorPrimeraVez;
            _vista.UsuarioDeseaObtenerRutas += _vista_UsuarioDeseaObtenerRutas;
            _vista.UsuarioDeseaObtenerOrdenesDeVentaPorFecha += _vista_UsuarioDeseaObtenerOrdenesDeVentaPorFecha;
            _vista.UsuarioDeseaObtenerOrdenesDeEntregaPorFecha += _vista_UsuarioDeseaObtenerOrdenesDeEntregaPorFecha;
            _vista.UsuarioDeseaValidarInventarioParaOrdenDeVenta += _vista_UsuarioDeseaValidarInventarioParaOrdenDeVenta;
            _vista.UsuarioDeseaMarcarOrdenDeVentaConPicking += _vista_UsuarioDeseaMarcarOrdenDeVentaConPicking;
            _vista.UsuarioDeseaDescartarEncabezado += _vista_UsuarioDeseaDescartarEncabezado;
            _vista.UsuarioDeseaDescartarTodosEncabezadosConAdvertencia += _vista_UsuarioDeseaDescartarTodosEncabezadosConAdvertencia;
            _vista.UsuarioDeseaObtenerBodegasAsignadas += _vista_UsuarioDeseaObtenerBodegasAsignadas;
            _vista.UsuarioDeseaCrearPickingDeOrdenDeVenta += _vista_UsuarioDeseaCrearPickingDeOrdenDeVenta;
            _vista.UsuarioDeseaObtenerUbicacionesDeSalida += _vista_UsuarioDeseaObtenerUbicacionesDeSalida;
            _vista.UsuarioDeseaObtenerClientesErpCanalModerno += _vista_UsuarioDeseaObtenerClientesErpCanalModerno;
            _vista.UsuarioDeseaObtenerDetallesConsolidados += _vista_UsuarioDeseaObtenerDetallesConsolidados;
            _vista.usuarioDeseaEliminarRegistros += _vista_usuarioDeseaEliminarRegistros;
            _vista.UsuarioDeseaObtenerLineasDePickingAsociadasABodega += _vista_UsuarioDeseaObtenerLineasDePickingAsociadasABodega;

            _vista.UsuarioDeseaObtenerSolicitudesDeTransferencia += _vista_UsuarioDeseaObtenerSolicitudesDeTransferencia;
            _vista.UsuarioSeleccionoFuente += _vista_UsuarioSeleccionoFuente;

            _vista.UsuarioSeleccionoBodega += _vista_UsuarioSeleccionoBodega;
            _vista.UsuarioSeleccionoPoligonos += _vista_UsuarioSeleccionoPoligonos;

            _vista.UsuarioDeseaCambiarElOrdenDeVehiculos += _vista_UsuarioDeseaCambiarElOrdenDeVehiculos;

            _vista.UsuarioCambioValorDeSwitchDeConsolidado += _vista_UsuarioCambioValorDeSwitchDeConsolidado;
            _vista.UsuarioDeseaObtenerPrioridad += _vista_UsuarioDeseaObtenerPrioridad;

            _vista.UsuarioDeseaObtenerDemandasPreparadasPorFecha += _vista_UsuarioDeseaObtenerDemandasPreparadasPorFecha;
            _vista.UsuarioDeseaObtenerOlasDePickigGeneradas += _vista_UsuarioDeseaObtenerOlasDePickigGeneradas;
            _vista.UsuarioDeseaObtenerProyectos += _vista_UsuarioDeseaObtenerProyectos;
        }

        private void _vista_UsuarioDeseaObtenerProyectos(object sender, ConsultaArgumento e)
        {
            ObtenerProyectosPorCliente();
        }

        private void _vista_UsuarioDeseaObtenerOlasDePickigGeneradas(object sender, OlaDePickingDeDemandaDespachoArgumento e)
        {
            try
            {
                var lista = DemandaDeDespachoServicio.ObtenerOlasDePickingPorDemandaDeDespacho(e);

                var listaEncabezados = new List<OlaDePickingDeDemandaDespacho>();

                foreach (var olaDePiking in lista)
                {
                    if (!listaEncabezados.Exists(o => o.WAVE_PICKING_ID == olaDePiking.WAVE_PICKING_ID))
                    {

                        var olaDePikingAIngresar = olaDePiking;
                        olaDePikingAIngresar.DemandaDeDespachoEncabezado = new List<DemandaDeDespachoEncabezado>();
                        var listaDetalle = lista.Where(o => o.WAVE_PICKING_ID == olaDePikingAIngresar.WAVE_PICKING_ID).ToList();

                        if (listaDetalle.Count() > 1)
                        {
                            foreach (var detalle in listaDetalle)
                            {
                                var detalleAIngresar = new DemandaDeDespachoEncabezado
                                {
                                    DOC_NUM = detalle.DOC_NUM
                                    ,
                                    STATUS_POSTED_ERP = detalle.STATUS_POSTED_ERP
                                    ,
                                    POSTED_ERP = detalle.POSTED_ERP
                                    ,
                                    POSTED_RESPONSE = detalle.POSTED_RESPONSE
                                    ,
                                    ERP_REFERENCE = detalle.ERP_REFERENCE
                                };
                                olaDePikingAIngresar.DemandaDeDespachoEncabezado.Add(detalleAIngresar);
                            }

                            olaDePikingAIngresar.DOC_NUM = null;
                            olaDePikingAIngresar.STATUS_POSTED_ERP = string.Empty;
                            olaDePikingAIngresar.POSTED_ERP = null;
                            olaDePikingAIngresar.POSTED_RESPONSE = string.Empty;
                            olaDePikingAIngresar.ERP_REFERENCE = string.Empty;
                        }

                        listaEncabezados.Add(olaDePikingAIngresar);
                    }
                }
                _vista.OlasDePikingCreadas = listaEncabezados;

            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaObtenerPrioridad(object sender, ConsultaArgumento e)
        {
            _vista.PrioridadDeTarea = ConfiguracionServicio.ObtenerConfiguracionesGrupoYTipo(new Entidades.Configuracion()
            {
                PARAM_GROUP = Enums.GetStringValue(GrupoDeClasificaciones.Prioridad),
                PARAM_TYPE = Enums.GetStringValue(TipoDeClasificaciones.Sistema)
            });
        }

        private void _vista_UsuarioCambioValorDeSwitchDeConsolidado(object sender, ConsultaArgumento e)
        {
            var parametroParaMostarONoSwitchDeEntregaImediata = ParametroServicio.ObtenerParametro(new ConsultaArgumento
            {
                GrupoParametro = "PICKING_DEMAND"
                   ,
                IdParametro = "SHOW_IMMEDIATE_DELIVERY_SWITCH"
            });

            var muestraSwitchDeEntregaInmediata = parametroParaMostarONoSwitchDeEntregaImediata[0].VALUE != null &&
                                                     int.Parse(parametroParaMostarONoSwitchDeEntregaImediata[0].VALUE) ==
                                                     (int)SiNo.Si;

            var switchConsolidadoActivo = e.SiNo;

            _vista.MuestraSwitchDeEntregaInmediata = muestraSwitchDeEntregaInmediata && !switchConsolidadoActivo && _vista.TipoInventario == TipoDeInventario.General;
            _vista.EsDemandaParaEntregaInmediata = true;
        }

        private void _vista_UsuarioDeseaCambiarElOrdenDeVehiculos(object sender, PickingArgumento e)
        {
            try
            {
                e.Vehiculos = DemandaDeDespachoServicio.AjustarPrioridadVehiculos(e);
                e.Encabezados = _vista.OrdenesDeVenta;
                DemandaDeDespachoServicio.ProcesarDemandaParaVehiculos(ref e);

                _vista.Vehiculos = e.Vehiculos;
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void _vista_UsuarioSeleccionoPoligonos(object sender, OrdenDeVentaArgumento e)
        {
            try
            {
                _vista.Rutas = RutasSwiftExpressServicio.ObtenerRutasPorPoligonosPorFecha(e);
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void _vista_UsuarioSeleccionoBodega(object sender, OrdenDeVentaArgumento e)
        {
            try
            {
                _vista.Poligonos = PoligonoServicio.ObtenerPoligonosDeDistribucionPorBodega(e);
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaObtenerLineasDePickingAsociadasABodega(object sender, OrdenDeVentaArgumento e)
        {
            try
            {
                _vista.LineasDePicking = BodegaServicio.ObtenerLineasDePickingAsociadasABodega(new Bodega
                {
                    WAREHOUSE_ID = e.CodigoBodega
                });
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaObtenerSolicitudesDeTransferencia(object sender, OrdenDeVentaArgumento e)
        {
            try
            {
                _vista.OrdenesDeVenta = _vista.TipoFuente == TipoFuenteDemandaDespacho.SolicitudTrasladoErp
                    ? SolicitudDeTrasladoServicio.ObtenerSolicitudesDeTransferenciaDeErpPorFecha(e).OrderBy(en => en.POSTED_DATETIME).ToList()
                    : SolicitudDeTrasladoServicio.ObtenerSolicitudesDeTransferenciaPorFecha(e).OrderBy(en => en.POSTED_DATETIME).ToList();

                var documentos = _vista.OrdenesDeVenta.Select(d => new Documento { DocumentId = d.SALES_ORDER_ID, ExternalSourceId = d.EXTERNAL_SOURCE_ID, Owner = d.OWNER });

                foreach (var traslado in _vista.OrdenesDeVenta) { traslado.ADDRESS_CUSTOMER = traslado.WAREHOUSE_TO; }

                var serializer = new XmlSerializer(typeof(List<Documento>));
                var xmlDocumentos = new StringWriter();
                var xmlWriter = new XmlTextWriter(xmlDocumentos) { Formatting = Formatting.Indented };
                serializer.Serialize(xmlWriter, documentos.ToList());
                e.XmlDocumentos = xmlDocumentos.ToString();

                _vista.DetallesOrdenDeVenta = _vista.TipoFuente == TipoFuenteDemandaDespacho.SolicitudTrasladoErp
                    ? SolicitudDeTrasladoServicio.ObtenerDetalleDeSolicitudesDeTransferenciaErp(e)
                    : SolicitudDeTrasladoServicio.ObtenerDetalleDeSolicitudesDeTransferencia(e);

                _vista.DetallesOrdenDeVenta.ToList().ForEach(ovd => { ovd.fechaModificacion = DateTime.Now; });

                var listaEncabezado = _vista.OrdenesDeVenta.ToList();
                var listaDetalle = _vista.DetallesOrdenDeVenta.ToList();

                _vista.Skus = OrdenDeVentaSwiftExpressServicio.ValidarInventarioParaOrdenDeVenta(ObtenerArgumentoParaValidarSkuInventario());
                ObtenerMaterialesConTonoYCalibre();
                var listaMaterialesConTonoOCalibre = _vista.MaterialesConTonoYCalibres.ToList();

                var despachoConEstado =
                    _vista.Parametros.FirstOrDefault(
                        p =>
                            p.GROUP_ID == Enums.GetStringValue(GrupoParametro.DemandaDePicking) &&
                            p.PARAMETER_ID == Enums.GetStringValue(IdParametro.DespachoPorEstadoDematerial));

                bool despacharConEstadoDeMaterial = false;
                if (despachoConEstado != null && despachoConEstado.VALUE.Equals("1"))
                {
                    _vista.InvnetarioDisponiblePorEstado = PickingServicio.ObtenerInvnentarioPraPickingPorEstado(ObtenerArgumentoDePickingParaInventarioPorestado());
                    _vista.EstadosDeMaterial = ObtenerEstadosDisponibles();
                    despacharConEstadoDeMaterial = true;
                }

                if (_vista.TipoFuente == TipoFuenteDemandaDespacho.SolicitudTrasladoWms) listaDetalle.ToList().ForEach(d => d.EXTERNAL_SOURCE_ID = 0);
                DemandaDeDespachoServicio.AjustarInventarioDeOrdenDeVenta(ref listaEncabezado,
                    ref listaDetalle, _vista.Skus, ref listaMaterialesConTonoOCalibre, _vista.TipoInventario, despacharConEstadoDeMaterial);

                var ordenLlenado =
                    _vista.Permisos.FirstOrDefault(
                        p => p.PARAM_NAME == Enums.GetStringValue(NombreDeClasificaciones.OrdenDeLlenado));

                var argumento = new PickingArgumento
                {
                    Encabezados = listaEncabezado,
                    Vehiculos = _vista.Vehiculos,
                    PrioridadOrden = ordenLlenado.TEXT_VALUE == "PESO" ? PrioridadVehiculos.Peso : PrioridadVehiculos.Volumen
                };
                _vista.Vehiculos = DemandaDeDespachoServicio.ProcesarDemandaParaVehiculos(ref argumento);

                int numeroEncabezado = 1;
                int numeroDetalle = 1;
                foreach (var enc in listaEncabezado)
                {
                    enc.ID = numeroEncabezado;
                    foreach (var d in from det in listaDetalle
                                      where enc.SALES_ORDER_ID == det.SALES_ORDER_ID && enc.EXTERNAL_SOURCE_ID == det.EXTERNAL_SOURCE_ID
                                      select det)
                    {
                        d.fechaModificacion = DateTime.Now;
                        d.ID = numeroDetalle;
                        d.HEADER_ID = numeroEncabezado;
                        enc.Detalles.Add(d);
                        numeroDetalle++;
                    }
                    numeroEncabezado++;
                }
                listaEncabezado.RemoveAll(n => n.Detalles.Count == 0);

                _vista.OrdenesDeVenta = listaEncabezado;
                _vista.DetallesOrdenDeVenta = listaDetalle;
                _vista.MaterialesConTonoYCalibres = listaMaterialesConTonoOCalibre;


                AjustarOrdenarEncabezados();
                LlenarOrdenesDeVentaConsolidado();
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void _vista_UsuarioSeleccionoFuente(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void _vista_usuarioDeseaEliminarRegistros(object sender, OrdenDeVentaArgumento e)
        {
            List<OrdenDeVentaEncabezado> listaEncabezado;
            List<OrdenDeVentaDetalle> listaDetalle;
            if (_vista.EsConsolidado)
            {
                var listaConsolidadoAEliminar = _vista.DetallesOrdenDeVentaConsolidado.Where(con => con.IS_SELECTD == e.BorrarSeleccionados);

                foreach (var detalle in _vista.DetallesOrdenDeVenta.Where(det => listaConsolidadoAEliminar.ToList().Exists(con => con.SKU == det.SKU)))
                {
                    detalle.QTY = 0;
                }

                var lst = (from enc in _vista.OrdenesDeVenta let agregarEncabezado = _vista.DetallesOrdenDeVenta.Where(det => det.SALES_ORDER_ID == enc.SALES_ORDER_ID && det.EXTERNAL_SOURCE_ID == enc.EXTERNAL_SOURCE_ID && det.SOURCE.ToUpper() == enc.OWNER.ToUpper()).Any(detalle => detalle.QTY > 0) where !agregarEncabezado select enc).ToList();
                listaEncabezado = lst;


                listaDetalle = _vista.DetallesOrdenDeVenta.ToList().Where(ord => !listaEncabezado.ToList().Exists(con => con.SALES_ORDER_ID == ord.SALES_ORDER_ID && con.EXTERNAL_SOURCE_ID == ord.EXTERNAL_SOURCE_ID && ord.SOURCE.ToUpper() == con.OWNER.ToUpper())).ToList();
                listaEncabezado = _vista.OrdenesDeVenta.ToList().Where(ord => !listaEncabezado.ToList().Exists(con => con.SALES_ORDER_ID == ord.SALES_ORDER_ID && con.EXTERNAL_SOURCE_ID == ord.EXTERNAL_SOURCE_ID && ord.OWNER.ToUpper() == con.OWNER.ToUpper())).ToList();
            }
            else
            {
                var listaEncabezadoAEliminar = _vista.OrdenesDeVenta.Where(enc => enc.IS_SELECTD == e.BorrarSeleccionados);
                listaDetalle =
                    _vista.DetallesOrdenDeVenta.Where(
                        det =>
                            !listaEncabezadoAEliminar.ToList()
                                .Exists(
                                    enc =>
                                        enc.SALES_ORDER_ID == det.SALES_ORDER_ID &&
                                        enc.EXTERNAL_SOURCE_ID == det.EXTERNAL_SOURCE_ID
                                        && det.SOURCE.ToUpper() == enc.OWNER.ToUpper())).ToList();
                listaEncabezado = _vista.OrdenesDeVenta.Where(enc => enc.IS_SELECTD != e.BorrarSeleccionados).ToList();

            }

            _vista.OrdenesDeVenta = listaEncabezado;
            _vista.DetallesOrdenDeVenta = listaDetalle;

            _vista.Skus = OrdenDeVentaSwiftExpressServicio.ValidarInventarioParaOrdenDeVenta(ObtenerArgumentoParaValidarSkuInventario());
            ObtenerMaterialesConTonoYCalibre();
            var listaMaterialesConTonoOCalibre = _vista.MaterialesConTonoYCalibres.ToList();

            var despachoConEstado =
                    _vista.Parametros.FirstOrDefault(
                        p =>
                            p.GROUP_ID == Enums.GetStringValue(GrupoParametro.DemandaDePicking) &&
                            p.PARAMETER_ID == Enums.GetStringValue(IdParametro.DespachoPorEstadoDematerial));

            bool despacharConEstadoDeMaterial = false;
            if (despachoConEstado != null && despachoConEstado.VALUE.Equals("1"))
            {
                _vista.InvnetarioDisponiblePorEstado = PickingServicio.ObtenerInvnentarioPraPickingPorEstado(ObtenerArgumentoDePickingParaInventarioPorestado());
                _vista.EstadosDeMaterial = ObtenerEstadosDisponibles();
                despacharConEstadoDeMaterial = true;
            }

            DemandaDeDespachoServicio.AjustarInventarioDeOrdenDeVenta(ref listaEncabezado,
                ref listaDetalle, _vista.Skus, ref listaMaterialesConTonoOCalibre, _vista.TipoInventario, despacharConEstadoDeMaterial);

            var ordenLlenado =
                    _vista.Permisos.FirstOrDefault(
                        p => p.PARAM_NAME == Enums.GetStringValue(NombreDeClasificaciones.OrdenDeLlenado));

            var argumento = new PickingArgumento
            {
                Encabezados = listaEncabezado,
                Vehiculos = _vista.Vehiculos,
                PrioridadOrden = ordenLlenado.TEXT_VALUE == "PESO" ? PrioridadVehiculos.Peso : PrioridadVehiculos.Volumen
            };
            _vista.Vehiculos = DemandaDeDespachoServicio.ProcesarDemandaParaVehiculos(ref argumento);

            foreach (var encabezado in listaEncabezado)
            {
                encabezado.IS_SELECTD = false;
            }

            _vista.OrdenesDeVenta = listaEncabezado;
            _vista.DetallesOrdenDeVenta = listaDetalle;

            _vista.MaterialesConTonoYCalibres = listaMaterialesConTonoOCalibre;

            AjustarOrdenarEncabezados();

            LlenarOrdenesDeVentaConsolidado();
        }

        private void _vista_UsuarioDeseaObtenerDetallesConsolidados(object sender, OrdenDeVentaArgumento e)
        {
            LlenarOrdenesDeVentaConsolidado();
        }

        private void _vista_UsuarioDeseaObtenerClientesErpCanalModerno(object sender, OrdenDeVentaArgumento e)
        {
            try
            {
                switch (_vista.TipoFuente)
                {
                    case TipoFuenteDemandaDespacho.OrdenDeEntrega:
                        _vista.ClientesErpCanalModerno = ClienteServicio.ObtenerClientesOrdeDeEntrega(e);
                        break;
                    case TipoFuenteDemandaDespacho.OrdenVentaErp:
                        _vista.ClientesErpCanalModerno = _vista.TipoInventario == TipoDeInventario.General
                        ? ClienteServicio.ObtenerClientesErpPorCanalModerno(e)
                        : ClienteServicio.ObtenerClientesErpCanalModernoParaOrdenesDeVentaPreparadas(e);
                        break;
                    default:
                        return;
                }
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.Mensaje(exception.Message);
            }
        }

        private void _vista_UsuarioDeseaObtenerUbicacionesDeSalida(object sender, BodegaArgumento e)
        {
            _vista.Ubicaciones = UbicacionServicio.ObtenerUbicacionesTipoRampaYPuertaParaDespacho(e.BodegaId);
        }

        private void _vista_UsuarioDeseaCrearPickingDeOrdenDeVenta(object sender, PickingArgumento e)
        {
            try
            {
                e.Login = _vista.Usuario;
                e.Ubicacion = new Ubicacion { LOCATION_SPOT = _vista.EsDemandaParaEntregaInmediata ? _vista.UbicacionSeleccionda : string.Empty };
                e.EsConsolidado = _vista.EsConsolidado;
                e.TipoDespacho = _vista.TipoFuente;
                e.Bodega = _vista.BodegaSeleccionda;
                e.EsDemandaParaEntregaInmediata = _vista.EsDemandaParaEntregaInmediata;
                e.Proyecto = _vista.ProyectoSeleccionado;
                e.NumeroOrden = _vista.NumeroOrden;

                BaseDeDatosServicio.BeginTransaction();
                var mensaje = "El picking se generó exitosamente.";
                var usaNext =
                    _vista.Parametros.FirstOrDefault(x => x.PARAMETER_ID == Enums.GetStringValue(IdParametro.TieneNext))
                    ;

                if (usaNext == null || usaNext.VALUE == ((int)SiNo.No).ToString() || !_vista.EsDemandaParaEntregaInmediata
                    || _vista.TipoFuente == TipoFuenteDemandaDespacho.SolicitudTrasladoErp
                    || _vista.TipoFuente == TipoFuenteDemandaDespacho.SolicitudTrasladoWms)
                {
                    e.Encabezados = ObtenerOrdenesParaPicking();
                    var op = PickingServicio.CrearPickingDeOrdenDeVenta(ref e);
                    if (op.Resultado == ResultadoOperacionTipo.Error)
                    {
                        throw new Exception(op.Mensaje);
                    }
                    if (_vista.EsConsolidado)
                    {
                        mensaje += $" La ola de picking es: {op.DbData}";
                    }
                }
                else
                {
                    foreach (var vehiculo in _vista.Vehiculos)
                    {
                        if (vehiculo.Ordenes.Count > 0)
                        {
                            e.Encabezados = ObtenerOrdenesParaPicking(vehiculo.Ordenes);
                            var op = PickingServicio.CrearPickingDeOrdenDeVenta(ref e);
                            if (op.Resultado == ResultadoOperacionTipo.Error)
                            {
                                throw new Exception(op.Mensaje);
                            }
                            if (vehiculo.IS_OWN <= 1)
                            {
                                op = ManifiestoCargaServicio.CrearManifiestoDeCargaDesdeDemandaDeDespacho(e, vehiculo);
                                if (op.Resultado == ResultadoOperacionTipo.Error)
                                {
                                    throw new Exception(op.Mensaje);
                                }
                            }
                        }
                    }
                }

                BaseDeDatosServicio.Commit();
                InteraccionConUsuarioServicio.MensajeExito(mensaje);
                _vista.Vehiculos = VehiculoServicio.ObtenerVehiculosParaDemandaDespacho();
                _vista.NumeroOrden = string.Empty;
                _vista.RefrescarVistaOrdenes();
            }
            catch (Exception exception)
            {
                BaseDeDatosServicio.Rollback();
                InteraccionConUsuarioServicio.Mensaje(exception.Message);
            }
        }

        private void _vista_UsuarioDeseaObtenerBodegasAsignadas(object sender, OrdenDeVentaArgumento e)
        {
            try
            {
                _vista.Bodegas = BodegaServicio.ObtenerBodegaAsignadaAUsuario(login: _vista.Usuario);
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.Mensaje(exception.Message);
            }
        }

        private void _vista_UsuarioDeseaDescartarTodosEncabezadosConAdvertencia(object sender, OrdenDeVentaArgumento e)
        {
            try
            {
                List<OrdenDeVentaEncabezado> listaEncabezado;
                List<OrdenDeVentaDetalle> listaDetalle;
                if (!_vista.EsConsolidado)
                {
                    _vista.DetallesOrdenDeVenta =
                    _vista.DetallesOrdenDeVenta.Where(
                        det =>
                            _vista.OrdenesDeVenta.ToList()
                                .Exists(
                                    enc =>
                                        det.SALES_ORDER_ID == enc.SALES_ORDER_ID && det.EXTERNAL_SOURCE_ID == enc.EXTERNAL_SOURCE_ID && enc.AdvertenciaFaltaInventario == 0 && det.SOURCE.ToUpper() == enc.OWNER.ToUpper()))
                        .ToList();
                    _vista.OrdenesDeVenta = _vista.OrdenesDeVenta.Where(enc => enc.AdvertenciaFaltaInventario == 0).ToList();

                    listaEncabezado = _vista.OrdenesDeVenta.ToList();
                    listaDetalle = _vista.DetallesOrdenDeVenta.ToList();
                }
                else
                {
                    var listaDetalleConsolidadoConInventario = _vista.DetallesOrdenDeVentaConsolidado.Where(c => !_vista.Skus.ToList().Exists(s => s.MATERIAL_ID == c.SKU)).ToList();
                    var listaDetalleConsolidadoSinInventario = _vista.DetallesOrdenDeVentaConsolidado.Where(c => _vista.Skus.ToList().Exists(s => s.MATERIAL_ID == c.SKU)).ToList();

                    var listaEncabezadoConsolidado =
                        _vista.OrdenesDeVenta.Where(
                            enc =>
                                _vista.DetallesOrdenDeVenta.ToList()
                                    .Exists(
                                        det =>
                                            listaDetalleConsolidadoConInventario.Exists(
                                                con =>
                                                    enc.SALES_ORDER_ID == det.SALES_ORDER_ID &&
                                                    enc.EXTERNAL_SOURCE_ID == det.EXTERNAL_SOURCE_ID &&
                                                    det.SKU == con.SKU &&
                                                    det.SOURCE.ToUpper() == enc.OWNER.ToUpper())));

                    var listaDetalleConsolidado =
                        _vista.DetallesOrdenDeVenta.Where(
                            det =>
                                listaEncabezadoConsolidado.ToList()
                                    .Exists(
                                        enc =>
                                            det.SALES_ORDER_ID == enc.SALES_ORDER_ID &&
                                            det.EXTERNAL_SOURCE_ID == enc.EXTERNAL_SOURCE_ID &&
                                            det.SOURCE.ToUpper() == enc.OWNER.ToUpper())).ToList();

                    foreach (var detalle in listaDetalleConsolidado.Where(det => listaDetalleConsolidadoSinInventario.Exists(con => det.SKU == con.SKU)))
                    {
                        detalle.QTY = 0;
                    }
                    listaEncabezado = listaEncabezadoConsolidado.ToList();
                    listaDetalle = listaDetalleConsolidado;
                    _vista.OrdenesDeVenta = listaEncabezado;
                    _vista.DetallesOrdenDeVenta = listaDetalle;
                }


                _vista.OrdenesDeVenta = listaEncabezado;
                _vista.DetallesOrdenDeVenta = listaDetalle;
                _vista.Skus = OrdenDeVentaSwiftExpressServicio.ValidarInventarioParaOrdenDeVenta(ObtenerArgumentoParaValidarSkuInventario());

                ObtenerMaterialesConTonoYCalibre();
                var listaMaterialesConTonoOCalibre = _vista.MaterialesConTonoYCalibres.ToList();

                var despachoConEstado =
                    _vista.Parametros.FirstOrDefault(
                        p =>
                            p.GROUP_ID == Enums.GetStringValue(GrupoParametro.DemandaDePicking) &&
                            p.PARAMETER_ID == Enums.GetStringValue(IdParametro.DespachoPorEstadoDematerial));

                bool despacharConEstadoDeMaterial = false;
                if (despachoConEstado != null && despachoConEstado.VALUE.Equals("1"))
                {
                    _vista.InvnetarioDisponiblePorEstado = PickingServicio.ObtenerInvnentarioPraPickingPorEstado(ObtenerArgumentoDePickingParaInventarioPorestado());
                    _vista.EstadosDeMaterial = ObtenerEstadosDisponibles();
                    despacharConEstadoDeMaterial = true;
                }

                DemandaDeDespachoServicio.AjustarInventarioDeOrdenDeVenta(ref listaEncabezado,
                    ref listaDetalle, _vista.Skus, ref listaMaterialesConTonoOCalibre, _vista.TipoInventario, despacharConEstadoDeMaterial);

                var ordenLlenado =
                    _vista.Permisos.FirstOrDefault(
                        p => p.PARAM_NAME == Enums.GetStringValue(NombreDeClasificaciones.OrdenDeLlenado));

                var argumento = new PickingArgumento
                {
                    Encabezados = listaEncabezado,
                    Vehiculos = _vista.Vehiculos,
                    PrioridadOrden = ordenLlenado.TEXT_VALUE == "PESO" ? PrioridadVehiculos.Peso : PrioridadVehiculos.Volumen
                };
                _vista.Vehiculos = DemandaDeDespachoServicio.ProcesarDemandaParaVehiculos(ref argumento);

                _vista.OrdenesDeVenta = listaEncabezado;
                _vista.DetallesOrdenDeVenta = listaDetalle;
                _vista.MaterialesConTonoYCalibres = listaMaterialesConTonoOCalibre;
                AjustarOrdenarEncabezados();

                LlenarOrdenesDeVentaConsolidado();

            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaDescartarEncabezado(object sender, OrdenDeVentaArgumento e)
        {
            try
            {
                _vista.DetallesOrdenDeVenta =
                    _vista.DetallesOrdenDeVenta.Where(
                        det => det.SALES_ORDER_ID != e.OrdenDeVentaEncabezado.SALES_ORDER_ID).ToList();

                _vista.OrdenesDeVenta =
                    _vista.OrdenesDeVenta.Where(
                        enc => enc.SALES_ORDER_ID != e.OrdenDeVentaEncabezado.SALES_ORDER_ID).ToList();

                var listaEncabezado = _vista.OrdenesDeVenta.ToList();
                var listaDetalle = _vista.DetallesOrdenDeVenta.ToList();
                _vista.Skus = OrdenDeVentaSwiftExpressServicio.ValidarInventarioParaOrdenDeVenta(ObtenerArgumentoParaValidarSkuInventario());

                ObtenerMaterialesConTonoYCalibre();
                var listaMaterialesConTonoOCalibre = _vista.MaterialesConTonoYCalibres.ToList();

                var despachoConEstado =
                    _vista.Parametros.FirstOrDefault(
                        p =>
                            p.GROUP_ID == Enums.GetStringValue(GrupoParametro.DemandaDePicking) &&
                            p.PARAMETER_ID == Enums.GetStringValue(IdParametro.DespachoPorEstadoDematerial));

                bool despacharConEstadoDeMaterial = false;
                if (despachoConEstado != null && despachoConEstado.VALUE.Equals("1"))
                {
                    _vista.InvnetarioDisponiblePorEstado = PickingServicio.ObtenerInvnentarioPraPickingPorEstado(ObtenerArgumentoDePickingParaInventarioPorestado());
                    _vista.EstadosDeMaterial = ObtenerEstadosDisponibles();
                    despacharConEstadoDeMaterial = true;
                }

                DemandaDeDespachoServicio.AjustarInventarioDeOrdenDeVenta(ref listaEncabezado,
                    ref listaDetalle, _vista.Skus, ref listaMaterialesConTonoOCalibre, _vista.TipoInventario, despacharConEstadoDeMaterial);

                var ordenLlenado =
                    _vista.Permisos.FirstOrDefault(
                        p => p.PARAM_NAME == Enums.GetStringValue(NombreDeClasificaciones.OrdenDeLlenado));

                var argumento = new PickingArgumento
                {
                    Encabezados = listaEncabezado,
                    Vehiculos = _vista.Vehiculos,
                    PrioridadOrden = ordenLlenado.TEXT_VALUE == "PESO" ? PrioridadVehiculos.Peso : PrioridadVehiculos.Volumen
                };
                _vista.Vehiculos = DemandaDeDespachoServicio.ProcesarDemandaParaVehiculos(ref argumento);

                _vista.OrdenesDeVenta = listaEncabezado;
                _vista.DetallesOrdenDeVenta = listaDetalle;
                _vista.MaterialesConTonoYCalibres = listaMaterialesConTonoOCalibre;
                AjustarOrdenarEncabezados();
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaMarcarOrdenDeVentaConPicking(object sender, OrdenDeVentaArgumento e)
        {
            var operacion = OrdenDeVentaSwiftExpressServicio.MarcarOrdenDeVentaConPicking(e.OrdenDeVentaEncabezado);
            if (operacion.Resultado == ResultadoOperacionTipo.Error)
            {
                InteraccionConUsuarioServicio.Mensaje(operacion.Mensaje);
            }
        }

        private void _vista_UsuarioDeseaValidarInventarioParaOrdenDeVenta(object sender, SkuArgumento e)
        {
            try
            {
                if (_vista.OrdenesDeVenta == null || _vista.DetallesOrdenDeVenta == null)
                {
                    return;
                }
                var listaEncabezado = _vista.OrdenesDeVenta.ToList();
                var listaDetalle = _vista.DetallesOrdenDeVenta.ToList();

                if (_vista.TipoInventario == TipoDeInventario.General)
                {
                    _vista.InvnetarioDisponiblePorEstado = PickingServicio.ObtenerInvnentarioPraPickingPorEstado(ObtenerArgumentoDePickingParaInventarioPorestado());
                    _vista.EstadosDeMaterial = ObtenerEstadosDisponibles();

                    _vista.Skus =
                        OrdenDeVentaSwiftExpressServicio.ValidarInventarioParaOrdenDeVenta(
                            ObtenerArgumentoParaValidarSkuInventario());
                }
                else
                {
                    _vista.Skus = new List<Sku>();
                }

                ObtenerMaterialesConTonoYCalibre();
                var listaMaterialesConTonoOCalibre = _vista.MaterialesConTonoYCalibres.ToList();

                var despachoConEstado =
                    _vista.Parametros.FirstOrDefault(
                        p =>
                            p.GROUP_ID == Enums.GetStringValue(GrupoParametro.DemandaDePicking) &&
                            p.PARAMETER_ID == Enums.GetStringValue(IdParametro.DespachoPorEstadoDematerial));

                bool despacharConEstadoDeMaterial = false;
                if (despachoConEstado != null && despachoConEstado.VALUE.Equals("1"))
                {
                    _vista.InvnetarioDisponiblePorEstado = PickingServicio.ObtenerInvnentarioPraPickingPorEstado(ObtenerArgumentoDePickingParaInventarioPorestado());
                    _vista.EstadosDeMaterial = ObtenerEstadosDisponibles();
                    despacharConEstadoDeMaterial = true;
                }

                DemandaDeDespachoServicio.AjustarInventarioDeOrdenDeVenta(ref listaEncabezado,
                    ref listaDetalle, _vista.Skus, ref listaMaterialesConTonoOCalibre, _vista.TipoInventario, despacharConEstadoDeMaterial);

                var ordenLlenado =
                    _vista.Permisos.FirstOrDefault(
                        p => p.PARAM_NAME == Enums.GetStringValue(NombreDeClasificaciones.OrdenDeLlenado));

                var argumento = new PickingArgumento
                {
                    Encabezados = listaEncabezado,
                    Vehiculos = _vista.Vehiculos,
                    PrioridadOrden = ordenLlenado == null || ordenLlenado.TEXT_VALUE == "PESO" ? PrioridadVehiculos.Peso : PrioridadVehiculos.Volumen
                };
                _vista.Vehiculos = DemandaDeDespachoServicio.ProcesarDemandaParaVehiculos(ref argumento);

                _vista.OrdenesDeVenta = listaEncabezado;
                _vista.DetallesOrdenDeVenta = listaDetalle;
                _vista.MaterialesConTonoYCalibres = listaMaterialesConTonoOCalibre;
                AjustarOrdenarEncabezados();
                LlenarOrdenesDeVentaConsolidado();
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaObtenerDemandasPreparadasPorFecha(object sender, OrdenDeVentaArgumento e)
        {
            try
            {
                switch (_vista.TipoFuente)
                {
                    case TipoFuenteDemandaDespacho.OrdenVentaErp:
                        _vista.OrdenesDeVenta = DemandaDeDespachoServicio.ObtenerOrdenesDeVentaPreparadaErp(e);
                        break;
                    case TipoFuenteDemandaDespacho.OrdenVentaSonda:
                        _vista.OrdenesDeVenta = DemandaDeDespachoServicio.ObtenerOrdenesDeVentaPreparadaSonda(e);
                        break;
                    case TipoFuenteDemandaDespacho.SolicitudTrasladoErp:
                        _vista.OrdenesDeVenta = DemandaDeDespachoServicio.ObtenerSolicitudTransferenciaPreparadaErp(e);
                        break;
                    case TipoFuenteDemandaDespacho.SolicitudTrasladoWms:
                        _vista.OrdenesDeVenta = DemandaDeDespachoServicio.ObtenerSolicitudTransferenciaPreparadaSwift(e);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                _vista.OrdenesDeVenta = _vista.OrdenesDeVenta.OrderBy(en => en.POSTED_DATETIME).ToList();
                _vista.Vehiculos = VehiculoServicio.ObtenerVehiculosParaDemandaDespacho();

                e.TextoEncabezados = string.Join("|", _vista.OrdenesDeVenta.Select(wt => wt.PICKING_DEMAND_HEADER_ID));

                _vista.DetallesOrdenDeVenta = DemandaDeDespachoServicio.ObtenerOrdenVentaDetalleDeOrdenesPreparadas(e);

                var encabezadosParaEliminar = _vista.DetallesOrdenDeVenta
                    .GroupBy(x => new { x.SALES_ORDER_ID })
                    .Select(y => new { Id = y.Key.SALES_ORDER_ID, Amount = y.Sum(x => x.QTY) })
                    .Where(x => x.Amount <= 0)
                    .Select(x => x.Id);

                foreach (var en in encabezadosParaEliminar)
                {
                    var enc = _vista.OrdenesDeVenta.FirstOrDefault(x => x.SALES_ORDER_ID == en);
                    _vista.OrdenesDeVenta.Remove(enc);
                }

                var listaEncabezado = _vista.OrdenesDeVenta.ToList();
                var listaDetalle = _vista.DetallesOrdenDeVenta.ToList();

                var numeroEncabezado = 1;
                var numeroDetalle = 1;
                foreach (var enc in listaEncabezado)
                {
                    enc.ID = numeroEncabezado;
                    foreach (var d in from det in listaDetalle
                                      where enc.SALES_ORDER_ID == det.SALES_ORDER_ID && enc.EXTERNAL_SOURCE_ID == det.EXTERNAL_SOURCE_ID
                                      select det)
                    {
                        d.fechaModificacion = DateTime.Now;
                        d.ID = numeroDetalle;
                        d.HEADER_ID = numeroEncabezado;
                        enc.Detalles.Add(d);
                        numeroDetalle++;
                    }
                    numeroEncabezado++;
                }
                listaEncabezado.RemoveAll(n => n.Detalles.Count == 0);
                _vista.Skus = new List<Sku>();

                ObtenerMaterialesConTonoYCalibre();

                var listaMaterialesConTonoOCalibre = _vista.MaterialesConTonoYCalibres.ToList();

                var despachoConEstado =
                    _vista.Parametros.FirstOrDefault(
                        p =>
                            p.GROUP_ID == Enums.GetStringValue(GrupoParametro.DemandaDePicking) &&
                            p.PARAMETER_ID == Enums.GetStringValue(IdParametro.DespachoPorEstadoDematerial));

                bool despacharConEstadoDeMaterial = false;
                if (despachoConEstado != null && despachoConEstado.VALUE.Equals("1"))
                {
                    _vista.InvnetarioDisponiblePorEstado = PickingServicio.ObtenerInvnentarioPraPickingPorEstado(ObtenerArgumentoDePickingParaInventarioPorestado());
                    _vista.EstadosDeMaterial = ObtenerEstadosDisponibles();
                    despacharConEstadoDeMaterial = true;
                }

                DemandaDeDespachoServicio.AjustarInventarioDeOrdenDeVenta(ref listaEncabezado, ref listaDetalle, _vista.Skus, ref listaMaterialesConTonoOCalibre, _vista.TipoInventario, despacharConEstadoDeMaterial);

                var ordenLlenado =
                    _vista.Permisos.FirstOrDefault(
                        p => p.PARAM_NAME == Enums.GetStringValue(NombreDeClasificaciones.OrdenDeLlenado));

                var argumento = new PickingArgumento
                {
                    Encabezados = listaEncabezado,
                    Vehiculos = _vista.Vehiculos,
                    PrioridadOrden = ordenLlenado == null || ordenLlenado.TEXT_VALUE == "PESO" ? PrioridadVehiculos.Peso : PrioridadVehiculos.Volumen
                };
                _vista.Vehiculos = DemandaDeDespachoServicio.ProcesarDemandaParaVehiculos(ref argumento);
                _vista.OrdenesDeVenta = listaEncabezado;
                _vista.DetallesOrdenDeVenta = listaDetalle;
                _vista.MaterialesConTonoYCalibres = listaMaterialesConTonoOCalibre;
                AjustarOrdenarEncabezados();
                LlenarOrdenesDeVentaConsolidado();
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.Mensaje(exception.Message);
            }
        }

        private void _vista_UsuarioDeseaObtenerOrdenesDeEntregaPorFecha(object sender, OrdenDeVentaArgumento e)
        {
            try
            {
                _vista.Vehiculos = VehiculoServicio.ObtenerVehiculosParaDemandaDespacho();
                _vista.OrdenesDeVenta = OrdenDeVentaSwiftExpressServicio.ObtenerOrdenesDeEntregaPorFecha(e);
                _vista.OrdenesDeVenta = _vista.OrdenesDeVenta.OrderBy(en => en.POSTED_DATETIME).ToList();

                e.TextoEncabezados = string.Empty;
                e.TextoFuentesExternas = string.Empty;

                foreach (var ordenDeVentaEncabezado in _vista.OrdenesDeVenta)
                {
                    e.TextoEncabezados += string.IsNullOrEmpty(e.TextoEncabezados) ? ordenDeVentaEncabezado.SALES_ORDER_ID.ToString() : "|" + ordenDeVentaEncabezado.SALES_ORDER_ID;
                    e.TextoFuentesExternas += string.IsNullOrEmpty(e.TextoFuentesExternas) ? ordenDeVentaEncabezado.EXTERNAL_SOURCE_ID.ToString() : "|" + ordenDeVentaEncabezado.EXTERNAL_SOURCE_ID;

                }

                _vista.DetallesOrdenDeVenta = OrdenDeVentaErpServicio.ObtenerOrdenDeEntregaDetalle(e);


                foreach (var ordenDeVentaDetalle in _vista.DetallesOrdenDeVenta.Where(det => _vista.FiltroDeUsaLineaDePicking != (int)Tipos.UsaLineaDePicking.Ambas && det.USE_PICKING_LINE != _vista.FiltroDeUsaLineaDePicking))
                {
                    ordenDeVentaDetalle.QTY = 0;
                }

                var encabezadosParaEliminar = _vista.DetallesOrdenDeVenta
                    .GroupBy(x => new { x.SALES_ORDER_ID })
                    .Select(y => new { Id = y.Key.SALES_ORDER_ID, Amount = y.Sum(x => x.QTY) })
                    .Where(x => x.Amount <= 0)
                    .Select(x => x.Id);

                foreach (var en in encabezadosParaEliminar)
                {
                    var enc = _vista.OrdenesDeVenta.FirstOrDefault(x => x.SALES_ORDER_ID == en);
                    _vista.OrdenesDeVenta.Remove(enc);
                }
                _vista.DetallesOrdenDeVenta = _vista.DetallesOrdenDeVenta.Where(x => _vista.OrdenesDeVenta.ToList().Exists(y => y.SALES_ORDER_ID == x.SALES_ORDER_ID && x.SOURCE == y.OWNER)).ToList();

                var listaEncabezado = _vista.OrdenesDeVenta.ToList();
                var listaDetalle = _vista.DetallesOrdenDeVenta.ToList();

                foreach (var detalle in listaDetalle)
                {
                    detalle.STATUS_CODE_ORIGIN = detalle.STATUS_CODE;
                    if (string.IsNullOrEmpty(detalle.STATUS_CODE))
                    {
                        detalle.STATUS_CODE = _vista.EstadoPredeterminadoDeMaterial.PARAM_NAME;
                    }
                }

                int numeroEncabezado = 1;
                int numeroDetalle = 1;
                foreach (var enc in listaEncabezado)
                {
                    enc.ID = numeroEncabezado;
                    foreach (var d in from det in listaDetalle
                                      where enc.SALES_ORDER_ID == det.SALES_ORDER_ID && enc.EXTERNAL_SOURCE_ID == det.EXTERNAL_SOURCE_ID
                                      && det.SOURCE == enc.OWNER
                                      select det)
                    {
                        d.fechaModificacion = DateTime.Now;
                        d.ID = numeroDetalle;
                        d.HEADER_ID = numeroEncabezado;
                        enc.Detalles.Add(d);
                        numeroDetalle++;
                    }
                    numeroEncabezado++;
                }
                listaEncabezado.RemoveAll(n => n.Detalles.Count == 0);



                var despachoConEstado =
                    _vista.Parametros.FirstOrDefault(
                        p =>
                            p.GROUP_ID == Enums.GetStringValue(GrupoParametro.DemandaDePicking) &&
                            p.PARAMETER_ID == Enums.GetStringValue(IdParametro.DespachoPorEstadoDematerial));

                bool despacharConEstadoDeMaterial = false;
                if (despachoConEstado != null && despachoConEstado.VALUE.Equals("1"))
                {
                    _vista.InvnetarioDisponiblePorEstado = PickingServicio.ObtenerInvnentarioPraPickingPorEstado(ObtenerArgumentoDePickingParaInventarioPorestado());
                    _vista.EstadosDeMaterial = ObtenerEstadosDisponibles();
                    despacharConEstadoDeMaterial = true;
                }

                _vista.Skus = OrdenDeVentaSwiftExpressServicio.ValidarInventarioParaOrdenDeVenta(ObtenerArgumentoParaValidarSkuInventario());

                var listaMaterialesConTonoOCalibre = _vista.MaterialesConTonoYCalibres.ToList();

                DemandaDeDespachoServicio.AjustarInventarioDeOrdenDeVenta(ref listaEncabezado, ref listaDetalle, _vista.Skus, ref listaMaterialesConTonoOCalibre, _vista.TipoInventario, despacharConEstadoDeMaterial);

                var ordenLlenado =
                    _vista.Permisos.FirstOrDefault(
                        p => p.PARAM_NAME == Enums.GetStringValue(NombreDeClasificaciones.OrdenDeLlenado));

                var argumento = new PickingArgumento
                {
                    Encabezados = listaEncabezado,
                    Vehiculos = _vista.Vehiculos,
                    PrioridadOrden = ordenLlenado == null || ordenLlenado.TEXT_VALUE == "PESO" ? PrioridadVehiculos.Peso : PrioridadVehiculos.Volumen
                };
                _vista.Vehiculos = DemandaDeDespachoServicio.ProcesarDemandaParaVehiculos(ref argumento);
                _vista.OrdenesDeVenta = listaEncabezado;
                _vista.DetallesOrdenDeVenta = listaDetalle;
                _vista.MaterialesConTonoYCalibres = listaMaterialesConTonoOCalibre;
                AjustarOrdenarEncabezados();
                LlenarOrdenesDeVentaConsolidado();

            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaObtenerOrdenesDeVentaPorFecha(object sender, OrdenDeVentaArgumento e)
        {
            try
            {
                _vista.Vehiculos = VehiculoServicio.ObtenerVehiculosParaDemandaDespacho();
                _vista.OrdenesDeVenta = 
                    (_vista.TipoFuente == TipoFuenteDemandaDespacho.OrdenVentaErp) ? 
                        OrdenDeVentaErpServicio.ObtenerOrdenesDeVentaPorFecha(e) : 
                        OrdenDeVentaSwiftExpressServicio.ObtenerOrdenesDeVentaPorFecha(e);
                _vista.OrdenesDeVenta = _vista.OrdenesDeVenta.OrderBy(en => en.POSTED_DATETIME).ToList();

                e.TextoEncabezados = string.Empty;
                e.TextoFuentesExternas = string.Empty;

                foreach (var ordenDeVentaEncabezado in _vista.OrdenesDeVenta)
                {
                    e.TextoEncabezados += string.IsNullOrEmpty(e.TextoEncabezados) ? ordenDeVentaEncabezado.SALES_ORDER_ID.ToString() : "|" + ordenDeVentaEncabezado.SALES_ORDER_ID;
                    e.TextoFuentesExternas += string.IsNullOrEmpty(e.TextoFuentesExternas) ? ordenDeVentaEncabezado.EXTERNAL_SOURCE_ID.ToString() : "|" + ordenDeVentaEncabezado.EXTERNAL_SOURCE_ID;

                }

                _vista.DetallesOrdenDeVenta = 
                    (_vista.TipoFuente == TipoFuenteDemandaDespacho.OrdenVentaErp) ? 
                        OrdenDeVentaErpServicio.ObtenerOrdenVentaDetalleDeOrdenes(e) : 
                        OrdenDeVentaSwiftExpressServicio.ObtenerOrdenVentaDetalleDeOrdenes(e);


                foreach (var ordenDeVentaDetalle in _vista.DetallesOrdenDeVenta.Where(det => _vista.FiltroDeUsaLineaDePicking != (int)Tipos.UsaLineaDePicking.Ambas && det.USE_PICKING_LINE != _vista.FiltroDeUsaLineaDePicking))
                {
                    ordenDeVentaDetalle.QTY = 0;
                }

                var encabezadosParaEliminar = _vista.DetallesOrdenDeVenta
                    .GroupBy(x => new { x.SALES_ORDER_ID })
                    .Select(y => new { Id = y.Key.SALES_ORDER_ID, Amount = y.Sum(x => x.QTY) })
                    .Where(x => x.Amount <= 0)
                    .Select(x => x.Id);

                foreach (var en in encabezadosParaEliminar)
                {
                    var enc = _vista.OrdenesDeVenta.FirstOrDefault(x => x.SALES_ORDER_ID == en);
                    _vista.OrdenesDeVenta.Remove(enc);
                }
                //_vista.DetallesOrdenDeVenta = _vista.DetallesOrdenDeVenta
                //    .Where(
                //        x => _vista.OrdenesDeVenta.ToList()
                //        .Exists(
                //            y => y.SALES_ORDER_ID == x.SALES_ORDER_ID && x.SOURCE == y.OWNER
                //        )
                //    ).ToList();

                var listaEncabezado = _vista.OrdenesDeVenta.ToList();
                var listaDetalle = _vista.DetallesOrdenDeVenta.ToList();

                foreach (var detalle in listaDetalle)
                {
                    detalle.STATUS_CODE_ORIGIN = detalle.STATUS_CODE;
                    if (string.IsNullOrEmpty(detalle.STATUS_CODE))
                    {
                        detalle.STATUS_CODE = _vista.EstadoPredeterminadoDeMaterial.PARAM_NAME;
                    }
                }

                int numeroEncabezado = 1;
                int numeroDetalle = 1;
                foreach (var enc in listaEncabezado)
                {
                    enc.ID = numeroEncabezado;
                    foreach (var d in from det in listaDetalle
                                      where enc.SALES_ORDER_ID == det.SALES_ORDER_ID && enc.EXTERNAL_SOURCE_ID == det.EXTERNAL_SOURCE_ID
                                      && det.SOURCE == enc.OWNER
                                      select det)
                    {
                        d.fechaModificacion = DateTime.Now;
                        d.ID = numeroDetalle;
                        d.HEADER_ID = numeroEncabezado;
                        enc.Detalles.Add(d);
                        numeroDetalle++;
                    }
                    numeroEncabezado++;
                }
                listaEncabezado.RemoveAll(n => n.Detalles.Count == 0);



                var despachoConEstado =
                    _vista.Parametros.FirstOrDefault(
                        p =>
                            p.GROUP_ID == Enums.GetStringValue(GrupoParametro.DemandaDePicking) &&
                            p.PARAMETER_ID == Enums.GetStringValue(IdParametro.DespachoPorEstadoDematerial));

                bool despacharConEstadoDeMaterial = false;
                if (despachoConEstado != null && despachoConEstado.VALUE.Equals("1"))
                {
                    _vista.InvnetarioDisponiblePorEstado = PickingServicio.ObtenerInvnentarioPraPickingPorEstado(ObtenerArgumentoDePickingParaInventarioPorestado());
                    _vista.EstadosDeMaterial = ObtenerEstadosDisponibles();
                    despacharConEstadoDeMaterial = true;
                }

                _vista.Skus = OrdenDeVentaSwiftExpressServicio.ValidarInventarioParaOrdenDeVenta(ObtenerArgumentoParaValidarSkuInventario());

                var listaMaterialesConTonoOCalibre = _vista.MaterialesConTonoYCalibres.ToList();

                DemandaDeDespachoServicio.AjustarInventarioDeOrdenDeVenta(ref listaEncabezado, ref listaDetalle, _vista.Skus, ref listaMaterialesConTonoOCalibre, _vista.TipoInventario, despacharConEstadoDeMaterial);

                var ordenLlenado =
                    _vista.Permisos.FirstOrDefault(
                        p => p.PARAM_NAME == Enums.GetStringValue(NombreDeClasificaciones.OrdenDeLlenado));

                var argumento = new PickingArgumento
                {
                    Encabezados = listaEncabezado,
                    Vehiculos = _vista.Vehiculos,
                    PrioridadOrden = ordenLlenado == null || ordenLlenado.TEXT_VALUE == "PESO" ? PrioridadVehiculos.Peso : PrioridadVehiculos.Volumen
                };
                _vista.Vehiculos = DemandaDeDespachoServicio.ProcesarDemandaParaVehiculos(ref argumento);
                _vista.OrdenesDeVenta = listaEncabezado;
                _vista.DetallesOrdenDeVenta = listaDetalle;
                _vista.MaterialesConTonoYCalibres = listaMaterialesConTonoOCalibre;
                AjustarOrdenarEncabezados();
                LlenarOrdenesDeVentaConsolidado();

            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaObtenerRutas(object sender, EventArgs e)
        {
            try
            {
                _vista.Rutas = RutasSwiftExpressServicio.ObtenerRutas();
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void _vista_VistaCargandosePorPrimeraVez(object sender, EventArgs e)
        {
            try
            {
                _vista.ClientesErpCanalModerno = new List<Cliente>();
                _vista.MaterialesConTonoYCalibres = new List<MaterialConTonoYCalibre>();
                _vista.Parametros = new List<Parametro>();
                _vista.DetallesOrdenDeVentaConsolidado = new List<OrdenDeVentaDetalle>();
                _vista.DetallesOrdenDeVenta = new List<OrdenDeVentaDetalle>();
                _vista.Usuario = InteraccionConUsuarioServicio.ObtenerUsuario();
                _vista.Bodegas = BodegaServicio.ObtenerBodegaAsignadaAUsuario(login: _vista.Usuario);
                _vista.Ubicaciones =
                    UbicacionServicio.ObtenerUbicacionesTipoRampaYPuertaParaDespacho(
                        InteraccionConUsuarioServicio.ObtenerCentroDistribucion());
                _vista.Permisos = ConfiguracionServicio.ObtenerConfiguracionesGrupoYTipo(new Entidades.Configuracion()
                {
                    PARAM_GROUP = Enums.GetStringValue(GrupoDeClasificaciones.DemandaDeDespacho),
                    PARAM_TYPE = Enums.GetStringValue(TipoDeClasificaciones.Sistema)
                });
                _vista.Parametros = ParametroServicio.ObtenerParametro(new ConsultaArgumento
                {
                    GrupoParametro = Enums.GetStringValue(GrupoParametro.Next),
                    IdParametro = Enums.GetStringValue(IdParametro.TieneNext)
                });

                var parametrosParaTipoDespacho = ParametroServicio.ObtenerParametro(new ConsultaArgumento
                {
                    GrupoParametro = Enums.GetStringValue(GrupoParametro.DemandaDePicking),
                    IdParametro = Enums.GetStringValue(IdParametro.ObtieneTipoDeDemanda)
                });

                //PARAMETROS FUENTE DESPACHO              
                var parametrosParaFuenteDespacho = ParametroServicio.ObtenerParametro(new ConsultaArgumento
                {
                    GrupoParametro = Enums.GetStringValue(GrupoParametro.FuenteDemandaDespacho),
                    IdParametro = Enums.GetStringValue(TipoFuenteDemandaDespacho.OrdenVentaSonda)
                });
                foreach (var parametro in parametrosParaFuenteDespacho)
                {
                    _vista.Parametros.Add(parametro);
                }

                parametrosParaFuenteDespacho = ParametroServicio.ObtenerParametro(new ConsultaArgumento
                {
                    GrupoParametro = Enums.GetStringValue(GrupoParametro.FuenteDemandaDespacho),
                    IdParametro = Enums.GetStringValue(TipoFuenteDemandaDespacho.OrdenVentaErp)
                });
                foreach (var parametro in parametrosParaFuenteDespacho)
                {
                    _vista.Parametros.Add(parametro);
                }

                parametrosParaFuenteDespacho = ParametroServicio.ObtenerParametro(new ConsultaArgumento
                {
                    GrupoParametro = Enums.GetStringValue(GrupoParametro.FuenteDemandaDespacho),
                    IdParametro = Enums.GetStringValue(TipoFuenteDemandaDespacho.SolicitudTrasladoWms)
                });
                foreach (var parametro in parametrosParaFuenteDespacho)
                {
                    _vista.Parametros.Add(parametro);
                }

                parametrosParaFuenteDespacho = ParametroServicio.ObtenerParametro(new ConsultaArgumento
                {
                    GrupoParametro = Enums.GetStringValue(GrupoParametro.FuenteDemandaDespacho),
                    IdParametro = Enums.GetStringValue(TipoFuenteDemandaDespacho.SolicitudTrasladoErp)
                });
                foreach (var parametro in parametrosParaFuenteDespacho)
                {
                    _vista.Parametros.Add(parametro);
                }
                //

                parametrosParaFuenteDespacho = ParametroServicio.ObtenerParametro(new ConsultaArgumento
                {
                    GrupoParametro = Enums.GetStringValue(GrupoParametro.FuenteDemandaDespacho),
                    IdParametro = "DO - ERP"
                });
                foreach (var parametro in parametrosParaFuenteDespacho)
                {
                    _vista.Parametros.Add(parametro);
                }

                foreach (var parametro in parametrosParaTipoDespacho)
                {
                    _vista.Parametros.Add(parametro);
                }

                parametrosParaTipoDespacho = ParametroServicio.ObtenerParametro(new ConsultaArgumento
                {
                    GrupoParametro = Enums.GetStringValue(GrupoParametro.DemandaDePicking),
                    IdParametro = Enums.GetStringValue(IdParametro.DespachoPorEstadoDematerial)
                });

                foreach (var parametro in parametrosParaTipoDespacho)
                {
                    _vista.Parametros.Add(parametro);
                }

                _vista.Vehiculos = VehiculoServicio.ObtenerVehiculosParaDemandaDespacho();

                var parametroParaMostarONoSwitchDeEntregaImediata = ParametroServicio.ObtenerParametro(new ConsultaArgumento
                {
                    GrupoParametro = Enums.GetStringValue(GrupoParametro.DemandaDePicking)//"PICKING_DEMAND",
                    ,
                    IdParametro = Enums.GetStringValue(IdParametro.MostrarSwitchEntregaInmediata)//"SHOW_IMMEDIATE_DELIVERY_SWITCH"
                });

                _vista.MuestraSwitchDeEntregaInmediata = parametroParaMostarONoSwitchDeEntregaImediata[0].VALUE != null &&
                                                         int.Parse(parametroParaMostarONoSwitchDeEntregaImediata[0].VALUE) ==
                                                         (int)SiNo.Si;
                _vista.PrioridadDeTarea = ConfiguracionServicio.ObtenerConfiguracionesGrupoYTipo(new Entidades.Configuracion()
                {
                    PARAM_GROUP = Enums.GetStringValue(GrupoDeClasificaciones.Prioridad),
                    PARAM_TYPE = Enums.GetStringValue(TipoDeClasificaciones.Sistema)
                });
                _vista.Rutas = RutasSwiftExpressServicio.ObtenerRutas();

                var listaDeEstados = ConfiguracionServicio.ObtenerConfiguracionesGrupoYTipo(new Entidades.Configuracion()
                {
                    PARAM_GROUP = Enums.GetStringValue(GrupoDeClasificaciones.Estados),
                    PARAM_TYPE = Enums.GetStringValue(TipoDeClasificaciones.Estado)
                });

                _vista.EstadoPredeterminadoDeMaterial = listaDeEstados.FirstOrDefault(es => es.NUMERIC_VALUE == 1);
                _vista.ProyectoSeleccionado = new Proyecto();
                _vista.OrdenesDeVenta = new List<OrdenDeVentaEncabezado>();
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private SkuArgumento ObtenerArgumentoParaValidarSkuInventario()
        {
            var documentoXml = new XDocument(new XDeclaration("1.0", "iso-8859-1", null));
            var nodoRaiz = new XElement("ArrayOfOrdenDeVentaDetalle");
            documentoXml.Add(nodoRaiz);

            foreach (var detalle in _vista.DetallesOrdenDeVenta.Where(det => _vista.FiltroDeUsaLineaDePicking == (int)Tipos.UsaLineaDePicking.Ambas || det.USE_PICKING_LINE == _vista.FiltroDeUsaLineaDePicking))
            {
                var nodoFactura = new XElement("OrdenDeVentaDetalle");
                nodoFactura.Add(new XElement("SKU", detalle.SKU));
                nodoFactura.Add(new XElement("DESCRIPTION_SKU", detalle.DESCRIPTION_SKU));
                nodoFactura.Add(new XElement("QTY", detalle.QTY));
                nodoFactura.Add(new XElement("EXTERNAL_SOURCE_ID", detalle.EXTERNAL_SOURCE_ID));
                nodoFactura.Add(new XElement("SOURCE_NAME", detalle.SOURCE_NAME));
                nodoFactura.Add(new XElement("IS_MASTER_PACK", detalle.IS_MASTER_PACK));
                nodoFactura.Add(new XElement("MATERIAL_OWNER", detalle.MATERIAL_OWNER));
                nodoFactura.Add(new XElement("STATUS_CODE", detalle.STATUS_CODE));
                nodoRaiz.Add(nodoFactura);
            }

            var MIN_DAYS_EXPIRATION_DATE = 0;
            if (_vista.EsConsolidado)
            {
                MIN_DAYS_EXPIRATION_DATE = _vista.OrdenesDeVenta.Max(d => d.MIN_DAYS_EXPIRATION_DATE);
            }

            return new SkuArgumento
            {
                SalesOrderDetailXml = documentoXml.ToString()
                ,
                CODE_WAREHOUSE = _vista.BodegaSeleccionda
                ,
                HandleToneOrCaliber = _vista.EsPorTonoOCalibre
                ,
                EnLineaDePicking = _vista.ManejaLineaDePicking
                ,
                Proyecto = _vista.ProyectoSeleccionado
                ,
                MIN_DAYS_EXPIRATION_DATE = MIN_DAYS_EXPIRATION_DATE
            };
        }

        private PickingArgumento ObtenerArgumentoDePickingParaInventarioPorestado()
        {
            var documentoXml = new XDocument(new XDeclaration("1.0", "iso-8859-1", null));
            var nodoRaiz = new XElement("ArrayOfOrdenDeVentaDetalle");
            documentoXml.Add(nodoRaiz);

            var listaDeDetalle = new List<OrdenDeVentaDetalle>();
            foreach (var detalle in _vista.DetallesOrdenDeVenta)
            {
                if (!listaDeDetalle.Exists(d => d.SKU == detalle.SKU))
                {

                    listaDeDetalle.Add(new OrdenDeVentaDetalle { SKU = detalle.SKU });
                }
            }

            foreach (var detalle in listaDeDetalle)
            {
                var nodoFactura = new XElement("OrdenDeVentaDetalle");
                nodoFactura.Add(new XElement("SKU", detalle.SKU));
                nodoRaiz.Add(nodoFactura);
            }

            return new PickingArgumento
            {
                Xml = documentoXml.ToString(),
                CodigoBodega = _vista.BodegaSeleccionda
                ,
                Proyecto = _vista.ProyectoSeleccionado
            };
        }

        private IList<InventarioParaPickingPorEstado> ObtenerEstadosDisponibles()
        {
            var listaNueva = new List<InventarioParaPickingPorEstado>();
            foreach (var inventario in _vista.InvnetarioDisponiblePorEstado)
            {
                if (!listaNueva.Exists(e => e.STATUS_CODE == inventario.STATUS_CODE))
                {
                    listaNueva.Add(new InventarioParaPickingPorEstado { STATUS_CODE = inventario.STATUS_CODE, STATUS_NAME = inventario.STATUS_NAME, COLOR = inventario.COLOR });
                }
            }
            return listaNueva;
        }

        private void AjustarOrdenarEncabezados()
        {
            var listaEncabezado = _vista.OrdenesDeVenta;
            var listaDetalle = _vista.DetallesOrdenDeVenta;

            listaDetalle = listaDetalle.OrderByDescending(d => d.fechaModificacion).ToList();
            string ordenActual = string.Empty;
            var fuenteExterna = 0;
            var prioridad = 1;
            var source = string.Empty;
            foreach (var detalle in listaDetalle)
            {
                if (source == detalle.SOURCE && ordenActual == detalle.SALES_ORDER_ID && fuenteExterna == detalle.EXTERNAL_SOURCE_ID) continue;
                ordenActual = detalle.SALES_ORDER_ID;
                fuenteExterna = detalle.EXTERNAL_SOURCE_ID;
                source = detalle.SOURCE;
                foreach (var encabezado in
                    listaEncabezado.Where(
                        enc => enc.SALES_ORDER_ID == ordenActual && enc.EXTERNAL_SOURCE_ID == fuenteExterna && enc.OWNER.ToUpper() == source.ToUpper()))
                {
                    encabezado.Prioridad = prioridad;
                    prioridad++;
                    break;
                }
            }
            _vista.OrdenesDeVenta = listaEncabezado;
        }

        private List<OrdenDeVentaDetalle> ObtenerOrdenesConDetalleSinDetalle()
        {
            var listaDetalle = _vista.DetallesOrdenDeVenta;
            listaDetalle = listaDetalle.OrderByDescending(d => d.fechaModificacion).ToList();
            return listaDetalle.Where(detalle => detalle.QTY > 0).ToList();
        }

        private List<OrdenDeVentaEncabezado> ObtenerOrdenesParaPicking(IList<OrdenDeVentaEncabezado> listaEncabezado = null)
        {

            var listaDetalle = ObtenerOrdenesConDetalleSinDetalle();
            var codigoBodega = _vista.BodegaSeleccionda;

            var listaEncabezadoResultado = new List<OrdenDeVentaEncabezado>();

            if (listaEncabezado == null)
            {
                listaEncabezado = _vista.OrdenesDeVenta;
            }



            foreach (var detalle in listaDetalle)
            {
                var existeEncabezdo = listaEncabezadoResultado.Any(encabezado => detalle.SALES_ORDER_ID == encabezado.SALES_ORDER_ID && detalle.EXTERNAL_SOURCE_ID == encabezado.EXTERNAL_SOURCE_ID && detalle.SOURCE.ToUpper() == encabezado.OWNER.ToUpper());
                detalle.CODE_WAREHOUSE_SOURCE = codigoBodega;
                if (existeEncabezdo) continue;
                {
                    foreach (var encabezado in listaEncabezado.Where(enc => enc.SALES_ORDER_ID == detalle.SALES_ORDER_ID && enc.EXTERNAL_SOURCE_ID == detalle.EXTERNAL_SOURCE_ID && detalle.SOURCE.ToUpper() == enc.OWNER.ToUpper()))
                    {
                        listaEncabezadoResultado.Add(encabezado);
                        break;
                    }
                }
            }

            foreach (var encabezado in listaEncabezadoResultado)
            {
                encabezado.Detalles =
                    listaDetalle.Where(det => det.SALES_ORDER_ID == encabezado.SALES_ORDER_ID && det.EXTERNAL_SOURCE_ID == encabezado.EXTERNAL_SOURCE_ID && det.SOURCE.ToUpper() == encabezado.OWNER.ToUpper()).ToList();
                encabezado.CODE_WAREHOUSE = codigoBodega;

                var listaCompletaDetalle = _vista.DetallesOrdenDeVenta.Where(det => det.SALES_ORDER_ID == encabezado.SALES_ORDER_ID && det.EXTERNAL_SOURCE_ID == encabezado.EXTERNAL_SOURCE_ID && det.SOURCE.ToUpper() == encabezado.OWNER.ToUpper()).ToList();
                encabezado.IS_COMPLETED = listaCompletaDetalle.Exists(x => x.QTY_PENDING != x.QTY) ? 0 : 1;
            }

            return listaEncabezadoResultado;
        }

        private void LlenarOrdenesDeVentaConsolidado()
        {
            var ordenDeVentaArgumento = new OrdenDeVentaArgumento
            {
                Detalles = _vista.DetallesOrdenDeVenta
                ,
                EsPorTonoOCalibre = _vista.EsPorTonoOCalibre
                ,
                EstadoPredeterminadoDeMaterial = _vista.EstadoPredeterminadoDeMaterial
            };
            _vista.DetallesOrdenDeVentaConsolidado = OrdenDeVentaSwiftExpressServicio.ObtenerOrdenVentaDetalleConsolidadoDeOrdenes(ordenDeVentaArgumento).ToList().Where(con => con.QTY > 0).ToList();
        }

        private void ObtenerMaterialesConTonoYCalibre()
        {
            try
            {
                if (_vista.EsPorTonoOCalibre)
                {
                    var codigosDeMateriales = _vista.DetallesOrdenDeVenta.ToList().Aggregate("", (skuActual, skuDetalle) => skuActual + (skuDetalle.SKU + "|"));
                    _vista.MaterialesConTonoYCalibres =
                    OrdenDeVentaErpServicio.ObtenerTonosYCalibresDeMateriales(new SkuArgumento
                    {
                        CODE_MATERIALS = codigosDeMateriales == string.Empty ? "" : codigosDeMateriales
                        ,
                        CODE_WAREHOUSE = _vista.BodegaSeleccionda
                    });
                }
                else
                {
                    _vista.MaterialesConTonoYCalibres = new List<MaterialConTonoYCalibre>();
                }
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void ObtenerProyectosPorCliente()
        {
            var clientes = _vista.ClientesErpCanalModerno.ToList().Where(ccm => ccm.IS_SELECTED).ToList();
            var ordenes = _vista.OrdenesDeVenta.ToList();
            _vista.Proyectos?.Clear();
            foreach (var ordenDeVentaEncabezado in ordenes)
            {
                if (!clientes.Exists(c => c.CLIENT_ID.Equals(ordenDeVentaEncabezado.CLIENT_ID)))
                {
                    clientes.Add(new Cliente { CLIENT_ID = ordenDeVentaEncabezado.CLIENT_ID });
                }
            }

            var proyectos = ProyectoServicio.ObtenerProyectosPorEstado(new ProyectoArgumento { Proyecto = new Proyecto { STATUS = Enums.GetStringValue(EstadoDeProyecto.EnProceso) } }).ToList();
            var tempProyectos = (from pro in proyectos
                                 join cli in clientes
                                 on pro.CUSTOMER_CODE equals cli.CLIENT_ID
                                 select pro).ToList();
            var proyectosParaAgregar = new List<Proyecto>();
            foreach (var element in tempProyectos)
            {
                if (!proyectosParaAgregar.Exists(c => c.ID.Equals(element.ID)))
                {
                    proyectosParaAgregar.Add(element);
                }
            }
            _vista.Proyectos = proyectosParaAgregar;
        }
    }
}
