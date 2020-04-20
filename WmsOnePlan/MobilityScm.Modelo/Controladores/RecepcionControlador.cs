using MobilityScm.Modelo.Interfaces.Controladores;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Modelo.Tipos;
using MobilityScm.Modelo.Vistas;
using MobilityScm.Vertical.Servicios;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Utilerias;
using MobilityScm.Vertical.Entidades;

namespace MobilityScm.Modelo.Controladores
{
    public class RecepcionControlador : IRecepcionControlador
    {
        private readonly IRecepcionErpVista _vista;
        public IRecepcionServicio RecepcionServicio { get; set; }
        public IPolizaServicio PolizaServicio { get; set; }
        public IPolizaAseguradaServicio PolizaAseguradaServicio { get; set; }
        public IUsuarioServicio UsuarioServicio { get; set; }
        public IConfiguracionServicio ConfiguracionServicio { get; set; }
        public IUbicacionServicio UbicacionServicio { get; set; }
        public IAcuerdoComercialServicio AcuerdoComercialServicio { get; set; }

        public IFuenteExternaServicio FuenteExternaServicio { get; set; }

        public IInteraccionConUsuarioServicio InteraccionConUsuarioServicio { get; set; }

        public ITareaServicio TareaServicio { get; set; }

        public IParametroServicio ParametroServicio { get; set; }

        public RecepcionControlador(IRecepcionErpVista vista)
        {
            _vista = vista;
            SuscribirEventos();
        }

        private void SuscribirEventos()
        {
            _vista.UsuarioDeseaObtenerAcuerdosComercialesPorCliente += _vista_UsuarioDeseaObtenerAcuerdosComercialesPorCliente;
            _vista.VistaCargandosePorPrimeraVez += _vista_VistaCargandosePorPrimeraVez;
            _vista.UsuarioDeseaObtenerOrdenesDeCompra += _vista_UsuarioDeseaObtenerOrdenesDeCompra;
            _vista.UsuarioDeseaObtenerPolizaAseguradaPorCliente += _vista_UsuarioDeseaObtenerPolizaAseguradaPorCliente;
            _vista.UsuarioDeseaObtenerUsuario += _vista_UsuarioDeseaObtenerUsuario;
            _vista.UsuarioDeseaObtenerUbicaciones += _vista_UsuarioDeseaObtenerUbicaciones;
            _vista.UsuarioDeseaObtenerTipoDeRecepcion += _vista_UsuarioDeseaObtenerTipoDeRecepcion;
            _vista.UsuarioDeseaObtenerPrioridad += _vista_UsuarioDeseaObtenerPrioridad;
            _vista.UsuarioDeseaObtenerClientes += _vista_UsuarioDeseaObtenerClientes;
            _vista.UsuarioDeseaObtenerDetalleOrdenDeCompra += _vista_UsuarioDeseaObtenerDetalleOrdenDeCompra;
            _vista.UsuarioDeseaGrabarDocmentosErp += _vista_UsuarioDeseaGrabarDocmentosErp;
            _vista.UsuarioDeseaObtenerFacturaParaDevolucion += _vista_UsuarioDeseaObtenerFacturaParaDevolucion;

        }

        private void _vista_UsuarioDeseaObtenerFacturaParaDevolucion(object sender, Argumentos.DocumentoRecepcionERPArgumento e)
        {
            try
            {
                var nuevoDetalle = RecepcionServicio.ObtenerFacturaParaDevolucion(e.DocumentoRecepcionERP);
                if (nuevoDetalle != null && nuevoDetalle.Count > 0)
                {
                    var docEntry = nuevoDetalle[0].DOC_ENTRY;
                    _vista.OrdenesDeCompraDetalle = _vista.OrdenesDeCompraDetalle.Where(d => d.DOC_ENTRY != docEntry).ToList();
                    _vista.OrdenesDeCompraDetalle = AgregarDocumentoAlDetalle(_vista.OrdenesDeCompraDetalle.ToList(), nuevoDetalle.ToList(), e); 
                }
                else
                {
                    InteraccionConUsuarioServicio.Mensaje("No se encontro la factura " + e.DocumentoRecepcionERP.DOC_NUM);
                }
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaGrabarDocmentosErp(object sender, DocumentoRecepcionERPArgumento e)
        {
            try
            {
                e.DocumentosDeRecepcion = ObtenerDocumentosErpParaGrabar();

                var proceso = RecepcionServicio.GrabarRecepcionDesdeErp(e);

                if (proceso.Operacion.Resultado == ResultadoOperacionTipo.Error)
                {
                    InteraccionConUsuarioServicio.Mensaje(proceso.Operacion.Mensaje);
                }
                else
                {
                    _vista.LimpiarControles();
                    EnviarTareasAApi(proceso.Operadores);
                }
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private List<DocumentoRecepcionErpDetalle> AgregarDocumentoAlDetalle(List<DocumentoRecepcionErpDetalle> detalleActual, List<DocumentoRecepcionErpDetalle> nuevoDetalle, Argumentos.DocumentoRecepcionERPArgumento documentoRecepcionErpArgumento)
        {
            var listaDelDetalleActual = new List<DocumentoRecepcionErpDetalle>();

            if (detalleActual != null)
            {
                listaDelDetalleActual = detalleActual.ToList();
            }

            foreach (var detalleNuevo in nuevoDetalle)
            {
                var existeDetConTarea = false;
                foreach (var detalle in listaDelDetalleActual.Where(detalle => detalle.ERP_DOC == detalleNuevo.ERP_DOC && detalle.CLIENT_CODE == documentoRecepcionErpArgumento.DocumentoRecepcionErpDetalle.CLIENT_CODE))
                {
                    detalleNuevo.LOGIN_ID = detalle.LOGIN_ID;
                    detalleNuevo.LOCATION_SPOT = detalle.LOCATION_SPOT;
                    detalleNuevo.TYPE_RECEPCTION = detalle.TYPE_RECEPCTION;
                    detalleNuevo.TYPE_RECEPCTION_DRESCRIPTION = detalle.TYPE_RECEPCTION_DRESCRIPTION;
                    detalleNuevo.PRIORITY = detalle.PRIORITY;
                    detalleNuevo.PRIORITY_DESCRIPTION = detalle.PRIORITY_DESCRIPTION;
                    detalleNuevo.TRADE_AGREEMENT_ID = detalle.TRADE_AGREEMENT_ID;
                    detalleNuevo.TRADE_AGREEMENT_DESCRIPTION = detalle.TRADE_AGREEMENT_DESCRIPTION;
                    detalleNuevo.CLIENT_CODE = detalle.CLIENT_CODE;
                    detalleNuevo.INSURANCE_DOC_ID = detalle.INSURANCE_DOC_ID;
                    detalleNuevo.INSURANCE_DOC_DESCRIPTION = detalle.INSURANCE_DOC_DESCRIPTION;
                    detalleNuevo.DETAIL_COUNT = nuevoDetalle.Where(d => d.ERP_DOC == detalleNuevo.ERP_DOC && detalleNuevo.CLIENT_CODE == documentoRecepcionErpArgumento.DocumentoRecepcionErpDetalle.CLIENT_CODE).ToList().Count;
                    detalleNuevo.SOURCE = detalle.SOURCE;
                    existeDetConTarea = true;
                    break;
                }
                if (existeDetConTarea)
                {
                    var exiteDetalle = listaDelDetalleActual.Any(detalle => detalle.ERP_DOC == detalleNuevo.ERP_DOC && detalle.SKU == detalleNuevo.SKU && detalle.CLIENT_CODE == documentoRecepcionErpArgumento.DocumentoRecepcionErpDetalle.CLIENT_CODE && detalle.LINE_NUM == detalleNuevo.LINE_NUM);

                    if (!exiteDetalle)
                    {
                        listaDelDetalleActual.Add(detalleNuevo);
                    }
                }
                else
                {
                    detalleNuevo.LOGIN_ID = documentoRecepcionErpArgumento.DocumentoRecepcionErpDetalle.LOGIN_ID;
                    detalleNuevo.LOCATION_SPOT = documentoRecepcionErpArgumento.DocumentoRecepcionErpDetalle.LOCATION_SPOT;
                    detalleNuevo.TYPE_RECEPCTION = documentoRecepcionErpArgumento.DocumentoRecepcionErpDetalle.TYPE_RECEPCTION;
                    detalleNuevo.TYPE_RECEPCTION_DRESCRIPTION = documentoRecepcionErpArgumento.DocumentoRecepcionErpDetalle.TYPE_RECEPCTION_DRESCRIPTION;
                    detalleNuevo.PRIORITY = documentoRecepcionErpArgumento.DocumentoRecepcionErpDetalle.PRIORITY;
                    detalleNuevo.PRIORITY_DESCRIPTION = documentoRecepcionErpArgumento.DocumentoRecepcionErpDetalle.PRIORITY_DESCRIPTION;
                    detalleNuevo.TRADE_AGREEMENT_ID = documentoRecepcionErpArgumento.DocumentoRecepcionErpDetalle.TRADE_AGREEMENT_ID;
                    detalleNuevo.TRADE_AGREEMENT_DESCRIPTION = documentoRecepcionErpArgumento.DocumentoRecepcionErpDetalle.TRADE_AGREEMENT_DESCRIPTION;
                    detalleNuevo.CLIENT_CODE = documentoRecepcionErpArgumento.DocumentoRecepcionErpDetalle.CLIENT_CODE;
                    detalleNuevo.INSURANCE_DOC_ID = documentoRecepcionErpArgumento.DocumentoRecepcionErpDetalle.INSURANCE_DOC_ID;
                    detalleNuevo.INSURANCE_DOC_DESCRIPTION = documentoRecepcionErpArgumento.DocumentoRecepcionErpDetalle.INSURANCE_DOC_DESCRIPTION;
                    detalleNuevo.DETAIL_COUNT = nuevoDetalle.Where(d => d.ERP_DOC == detalleNuevo.ERP_DOC && detalleNuevo.CLIENT_CODE == documentoRecepcionErpArgumento.DocumentoRecepcionErpDetalle.CLIENT_CODE).ToList().Count;
                    detalleNuevo.SOURCE = documentoRecepcionErpArgumento.DocumentoRecepcionErpDetalle.SOURCE;
                    listaDelDetalleActual.Add(detalleNuevo);
                }
            }

            return listaDelDetalleActual;
        }

        private void _vista_UsuarioDeseaObtenerDetalleOrdenDeCompra(object sender, Argumentos.DocumentoRecepcionERPArgumento e)
        {
            try
            {
                var listaDetalleDoc = RecepcionServicio.DocumentosRecepcionErpDetalles(e.DocumentoRecepcionERP);
                _vista.OrdenesDeCompraDetalle = AgregarDocumentoAlDetalle(_vista.OrdenesDeCompraDetalle.ToList(), listaDetalleDoc.ToList(), e);
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaObtenerClientes(object sender, Argumentos.DocumentoRecepcionERPArgumento e)
        {
            try
            {
                _vista.FuenteExterna = FuenteExternaServicio.ObtenerFuentesExternas();
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaObtenerPrioridad(object sender, Argumentos.DocumentoRecepcionERPArgumento e)
        {
            try
            {
                _vista.Prioridad = ConfiguracionServicio.ObtenerConfiguracionesGrupoYTipo(new Entidades.Configuracion { PARAM_TYPE = "SISTEMA", PARAM_GROUP = "PRIORITY" });
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaObtenerTipoDeRecepcion(object sender, Argumentos.DocumentoRecepcionERPArgumento e)
        {
            try
            {
                _vista.TiposDeRecepcion = ConfiguracionServicio.ObtenerConfiguracionesGrupoYTipo(new Entidades.Configuracion { PARAM_TYPE = "SISTEMA", PARAM_GROUP = "TYPE_RECEPTION" });
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaObtenerUbicaciones(object sender, Argumentos.DocumentoRecepcionERPArgumento e)
        {
            try
            {
                _vista.Ubicaciones = UbicacionServicio.ObtenerUbicacionesTipoRampaYPuertaParaRecepcion(InteraccionConUsuarioServicio.ObtenerCentroDistribucion());
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaObtenerUsuario(object sender, Argumentos.DocumentoRecepcionERPArgumento e)
        {
            try
            {
                _vista.Operadores = UsuarioServicio.ObtenerUsuariosTipoBodegaAsignadosCD(InteraccionConUsuarioServicio.ObtenerCentroDistribucion());
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
                _vista.Operadores = UsuarioServicio.ObtenerUsuariosTipoBodegaAsignadosCD(InteraccionConUsuarioServicio.ObtenerCentroDistribucion());
                _vista.TiposDeRecepcion = ConfiguracionServicio.ObtenerConfiguracionesGrupoYTipo(new Entidades.Configuracion { PARAM_TYPE = "SISTEMA", PARAM_GROUP = "TYPE_RECEPTION" });
                _vista.Prioridad = ConfiguracionServicio.ObtenerConfiguracionesGrupoYTipo(new Entidades.Configuracion { PARAM_TYPE = "SISTEMA", PARAM_GROUP = "PRIORITY" });
                _vista.FuenteExterna = FuenteExternaServicio.ObtenerFuentesExternas();
                _vista.Usuario = InteraccionConUsuarioServicio.ObtenerUsuario();
                _vista.ParametrosDeSistema =
                   ParametroServicio.ObtenerParametro(new ConsultaArgumento
                   {
                       GrupoParametro = Enums.GetStringValue(GrupoParametro.Sistema),
                       IdParametro = Enums.GetStringValue(IdParametro.TipoDeClienteMovilDe3Pl)
                   });
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaObtenerPolizaAseguradaPorCliente(object sender, Argumentos.DocumentoRecepcionERPArgumento e)
        {
            try
            {
                _vista.PolizaAseguradora = new List<PolizaAsegurada>();
                var polizasDeSeguro = PolizaAseguradaServicio.ObtenerPolizaAseguradaPorCliente(e.PolizaAsegurada);

                if (polizasDeSeguro.Count == 0)
                {
                    var configuraciones = ConfiguracionServicio.ObtenerConfiguracionesGrupoYTipo(new Entidades.Configuracion { PARAM_TYPE = "POLIZAS", PARAM_GROUP = "POLIZAS_SEGUROS" });
                    foreach (var configuracion in configuraciones)
                    {
                        polizasDeSeguro.Add(new PolizaAsegurada
                        {
                            DOC_ID_CONFIGURATION = configuracion.TEXT_VALUE
                            ,
                            POLIZA_INSURANCE = configuracion.PARAM_CAPTION
                        });
                    }
                }
                _vista.PolizaAseguradora = polizasDeSeguro;
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaObtenerOrdenesDeCompra(object sender, Argumentos.DocumentoRecepcionERPArgumento e)
        {
            try
            {
                _vista.OrdenesDeCompraEncabezado = RecepcionServicio.DocumentosRecepcionErpEncabezados(e.FuenteExterna);
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaObtenerAcuerdosComercialesPorCliente(object sender, Argumentos.AcuerdoComercialArgumento e)
        {
            try
            {
                _vista.AcuerdosComerciales = AcuerdoComercialServicio.ObtenerAcuerdosComercialesPorCliente(e.AcuerdoComercial);
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private List<DocumentoRecepcion> ObtenerDocumentosErpParaGrabar()
        {
            var listaDetalle = _vista.OrdenesDeCompraDetalle;
            listaDetalle = listaDetalle.OrderBy(d => d.CLIENT_CODE).ToList().OrderBy(d => d.ERP_DOC).ToList();
            var listaDecoumentos = new List<DocumentoRecepcion>();
            string idDocumentoActual = "";
            var idClient = "";
            var catidadDetalles = 0;
            var cantidad = 0;
            var documento = new DocumentoRecepcion
            {
                DocumentoRecepcionErpDetalles = new List<DocumentoRecepcionDetalle>()
            };


            foreach (var detalle in listaDetalle)
            {
                if (idDocumentoActual != detalle.ERP_DOC || idClient != detalle.CLIENT_CODE)
                {
                    if (documento.DocumentoRecepcionErpDetalles.Count != 0)
                    {

                        documento.IS_COMPLETE = Convert.ToInt32(cantidad == catidadDetalles); //Convert.ToInt32(documento.DocumentoRecepcionErpDetalles.Count == catidadDetalles);
                        listaDecoumentos.Add(documento);
                        documento = new DocumentoRecepcion
                        {
                            DocumentoRecepcionErpDetalles = new List<DocumentoRecepcionDetalle>()
                        };
                    }

                    idDocumentoActual = detalle.ERP_DOC;
                    idClient = detalle.CLIENT_CODE;
                    if (detalle.DETAIL_COUNT != null) catidadDetalles = (int)detalle.DETAIL_COUNT;
                    documento.DOC_NUM = detalle.ERP_DOC;
                    documento.DOC_ID = detalle.SAP_RECEPTION_ID;
                    documento.TYPE = detalle.TYPE_RECEPCTION;
                    documento.CODE_SUPPLIER = detalle.PROVIDER_ID;
                    documento.LAST_UPDATE_BY = InteraccionConUsuarioServicio.ObtenerUsuario();
                    documento.TASK_ID = 0;
                    documento.EXTERNAL_SOURCE_ID = Convert.ToInt32(detalle.EXTERNAL_SOURCE_ID);
                    documento.TRADE_AGREEMENT = detalle.TRADE_AGREEMENT_ID.ToString();
                    documento.INSURANCE_POLICY = detalle.INSURANCE_DOC_ID;
                    documento.TYPE_RECEPTION = detalle.TYPE_RECEPCTION;
                    documento.TASK_ASSIGNEDTO = detalle.LOGIN_ID;
                    documento.REGIMEN = "GENERAL";
                    documento.CODE_CLIENT = detalle.CLIENT_CODE;
                    documento.CLIENT_NAME = "";
                    documento.PRIORITY = detalle.PRIORITY.ToString();
                    documento.LOCATION_SPOT_TARGET = detalle.LOCATION_SPOT;
                    documento.NAME_SUPPLIER = detalle.PROVIDER_NAME;
                    documento.OWNER = detalle.OWNER;
                    documento.SOURCE = detalle.SOURCE;
                    documento.ERP_WAREHOUSE_CODE = detalle.ERP_WAREHOUSE_CODE;
                    documento.DOC_ENTRY = detalle.DOC_ENTRY;
                    documento.ADDRESS = detalle.ADDRESS;
                    documento.DOC_CURRENCY = detalle.DOC_CURRENCY;
                    documento.DOC_RATE = detalle.DOC_RATE;
                    documento.SUBSIDIARY = detalle.SUBSIDIARY;
                    documento.COST_CENTER = detalle.COST_CENTER;

                    cantidad = 1;
                    if (detalle.IS_ASSIGNED == 1)
                    {
                        continue;
                    }
                    var detalleAgregar = new DocumentoRecepcionDetalle
                    {
                        MATERIAL_ID = detalle.SKU,
                        QTY = detalle.QTY
                        ,
                        LINE_NUM = detalle.LINE_NUM
                        ,
                        ERP_OBJECT_TYPE = Convert.ToInt32(detalle.OBJECT_TYPE)
                        ,
                        DET_CURRENCY = detalle.DET_CURRENCY
                        ,
                        DET_RATE = detalle.DET_RATE
                        ,
                        DET_TAX_CODE = detalle.DET_TAX_CODE
                        ,
                        DET_VAT_PERCENT = detalle.DET_VAT_PERCENT
                        ,
                        PRICE = detalle.PRICE
                        ,
                        DISCOUNT_PERCENT = detalle.DISCOUNT_PERCENT
                        ,
                        WAREHOUSE_CODE = detalle.ERP_WAREHOUSE_CODE
                        ,
                        COST_CENTER =  detalle.COST_CENTER
                        ,
                        UNIT = detalle.UNIT
                        ,
                        UNIT_DESCRIPTION = detalle.UNIT_DESCRIPTION
                    };

                    documento.DocumentoRecepcionErpDetalles.Add(detalleAgregar);
                }
                else
                {
                    cantidad += 1;
                    if (detalle.IS_ASSIGNED == 1)
                    {
                        continue;
                    }
                    var detalleAgregar = new DocumentoRecepcionDetalle
                    {
                        MATERIAL_ID = detalle.SKU,
                        QTY = detalle.QTY
                        ,
                        LINE_NUM = detalle.LINE_NUM
                        ,
                        ERP_OBJECT_TYPE = Convert.ToInt32(detalle.OBJECT_TYPE)
                         ,
                        DET_CURRENCY = detalle.DET_CURRENCY
                        ,
                        DET_RATE = detalle.DET_RATE
                        ,
                        DET_TAX_CODE = detalle.DET_TAX_CODE
                        ,
                        DET_VAT_PERCENT = detalle.DET_VAT_PERCENT
                        ,
                        PRICE = detalle.PRICE
                        ,
                        DISCOUNT_PERCENT = detalle.DISCOUNT_PERCENT
                        ,
                        WAREHOUSE_CODE = detalle.ERP_WAREHOUSE_CODE
                        ,
                        COST_CENTER = detalle.COST_CENTER
                        ,
                        UNIT = detalle.UNIT
                        ,
                        UNIT_DESCRIPTION = detalle.UNIT_DESCRIPTION
                    };

                    documento.DocumentoRecepcionErpDetalles.Add(detalleAgregar);
                }
            }
            documento.IS_COMPLETE = Convert.ToInt32(cantidad == catidadDetalles);
            listaDecoumentos.Add(documento);

            return listaDecoumentos;
        }

        private void EnviarTareasAApi(IList<string> listaDeOperadores)
        {
            if (!SeEnvianTareasAlApi()) return;
            if (listaDeOperadores.Count <= 0) return;

            var op =
                Rest.ExecutePost<Operacion>(
                    $"{InteraccionConUsuarioServicio.ObtenerDireccionBaseDeApi()}{RutasApi.Tareas.EnviarTareas}",
                    new ListaOperadorParaActualizacionDeTarea
                    {
                        loginId = InteraccionConUsuarioServicio.ObtenerUsuarioYDominio(),
                        password = InteraccionConUsuarioServicio.ObtenerClaveDeUsuario(),
                        dbUser = InteraccionConUsuarioServicio.ObtenerUsuarioDeBaseDeDatos(),
                        dbPassword = InteraccionConUsuarioServicio.ObtenerContraseniaDeBaseDeDatos(),
                        serverIp = InteraccionConUsuarioServicio.ObtenerServerIp(),
                        operators = listaDeOperadores
                    });

            if (op.Resultado == ResultadoOperacionTipo.Error)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo($"Error al enviar las tareas hacia el dispositivo móvil debido a: {op.Mensaje}");
            }
        }

        private bool SeEnvianTareasAlApi()
        {
            var parametro =
                _vista.ParametrosDeSistema.FirstOrDefault(p => p.GROUP_ID == Enums.GetStringValue(GrupoParametro.Sistema) && p.PARAMETER_ID == Enums.GetStringValue(IdParametro.TipoDeClienteMovilDe3Pl));
            return (parametro != null && int.Parse(parametro.VALUE) == 1);
        }

        private static string ObtenerXmlDeListadoDeTareas(List<Tarea> listadoDeTareas)
        {
            var serializador = new XmlSerializer(typeof(List<Tarea>));
            var escritorDeDocumentos = new StringWriter();
            var escritorXml = new XmlTextWriter(escritorDeDocumentos) { Formatting = Formatting.Indented };
            serializador.Serialize(escritorXml, listadoDeTareas);
            return escritorDeDocumentos.ToString();
        }
    }
}
