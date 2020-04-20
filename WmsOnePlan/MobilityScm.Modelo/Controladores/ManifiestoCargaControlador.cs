

using System;
using System.Collections.Generic;
using System.Linq;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Interfaces.Controladores;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Modelo.Servicios;
using MobilityScm.Modelo.Tipos;
using MobilityScm.Modelo.Vistas;
using MobilityScm.Utilerias;
using MobilityScm.Vertical.Servicios;

namespace MobilityScm.Modelo.Controladores
{
    public class ManifiestoCargaControlador : IManifiestoCargaControlador
    {
        private readonly IManifiestoCargaVista _vista;

        public IConfiguracionServicio ConfiguracionServicio { get; set; }
        public IBodegaServicio BodegaServicio { get; set; }
        public IManifiestoCargaServicio ManifiestoCargaServicio { get; set; }
        public IPickingServicio PickingServicio { get; set; }
        public IInteraccionConUsuarioServicio InteraccionConUsuarioServicio { get; set; }
        public IRutasSwiftExpressServicio RutasSwiftExpressServicio { get; set; }
        public ILineaDePickingServicio LineaDePickingServicio { get; set; }
        public IVehiculoServicio VehiculoServicio { get; set; }
        public IPilotoServicio PilotoServicio { get; set; }
        public IBaseDeDatosServicio BaseDeDatosServicio { get; set; }
        public IConsultaDeManifiestoServicio ConsultaDeManifiestoServicio { get; set; }
        public IParametroServicio ParametroServicio { get; set; }

        public ManifiestoCargaControlador(IManifiestoCargaVista vista)
        {
            _vista = vista;
            SuscribirEventos();
        }

        private void SuscribirEventos()
        {
            _vista.UsuarioDeseaConsultarBodegas += _vista_UsuarioDeseaConsultarBodegas; ; ;
            _vista.UsuarioDeseaConsultarPickingDetalle += _vista_UsuarioDeseaConsultarPickingDetalle;
            _vista.UsuarioDeseaConsultarPickingEncabezado += _vista_UsuarioDeseaConsultarPickingEncabezado;
            _vista.UsuarioDeseaConsultarVehiculos += _vista_UsuarioDeseaConsultarVehiculos;
            _vista.UsuarioDeseaGrabarManifiesto += _vista_UsuarioDeseaGrabarManifiesto;
            _vista.VistaCargandosePorPrimeraVez += _vista_VistaCargandosePorPrimeraVez;
            _vista.UsuarioDeseaConsultarRutas += _vista_UsuarioDeseaConsultarRutas;
            _vista.UsuarioDeseaConsultarManifiesto += _vista_UsuarioDeseaConsultarManifiesto;
            _vista.UsuarioDeseaObtenerManifiestoDeCarga += _vista_UsuarioDeseaObtenerManifiestoDeCarga;
            _vista.UsuarioDeseaObtenerCajasEnManifiestoDeCarga += _vista_UsuarioDeseaObtenerCajasEnManifiestoDeCarga;
            _vista.UsuarioDeseaObtenerVehiculosPorPeso += _vista_UsuarioDeseaObtenerVehiculosPorPeso;
            _vista.UsuarioDeseaObtenerPilotoPorVehiculo += _vista_UsuarioDeseaObtenerPilotoPorVehiculo;
            _vista.UsuarioDeseaObtenerReporteDeCajasPorCliente += _vista_UsuarioDeseaObtenerReporteDeCajasPorCliente;

        }

        private void _vista_UsuarioDeseaObtenerReporteDeCajasPorCliente(object sender, ManifiestoArgumento e)
        {
            try
            {
                _vista.CajasPorClientes = LineaDePickingServicio.ObtenerCajasPorCliente(e);
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaObtenerCajasEnManifiestoDeCarga(object sender, ManifiestoArgumento e)
        {
            try
            {
                _vista.Cajas = LineaDePickingServicio.ObtenerCajasPorManifiestoDeCarga(e);
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaObtenerPilotoPorVehiculo(object sender, PilotoArgumento e)
        {
            try
            {
                _vista.Piloto = PilotoServicio.ObtenerPilotoPorVehiculo(e);
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaObtenerVehiculosPorPeso(object sender, VehiculoArgumento e)
        {
            try
            {
                _vista.Vehiculos = VehiculoServicio.ObtenerVehiculosPorPeso(e);
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaObtenerManifiestoDeCarga(object sender, ManifiestoArgumento e)
        {
            try
            {
                _vista.ManifiestoDeCargaEncabezado = ManifiestoCargaServicio.ObtenerManifiestoDeCarga(e);
                _vista.DetallesEliminados = new List<int?>();
                _vista.EstaModificando = _vista.ManifiestoDeCargaEncabezado.STATUS != Enums.GetStringValue(Estados.EstadosManifiesto.Cancelado)
                                         && _vista.ManifiestoDeCargaEncabezado.STATUS != Enums.GetStringValue(Estados.EstadosManifiesto.EnPicking);
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaConsultarRutas(object sender, ManifiestoArgumento e)
        {
            try
            {
                _vista.Rutas = RutasSwiftExpressServicio.ObtenerTodasRutasAsociadasABodega(e.Bodegas);
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaConsultarManifiesto(object sender, ManifiestoArgumento e)
        {
            try
            {
                _vista.ManifiestoCarga = ManifiestoCargaServicio.ConsultarManifiesto(e);
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }

        }

        private void _vista_UsuarioDeseaConsultarBodegas(object sender, EventArgs e)
        {
            try
            {
                _vista.Bodegas = BodegaServicio.ObtenerBodegaAsignadaAUsuario(InteraccionConUsuarioServicio.ObtenerUsuario());
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void _vista_VistaCargandosePorPrimeraVez(object sender, System.EventArgs e)
        {
            try
            {
                _vista.Vehiculos = VehiculoServicio.ObtenerVehiculosPorPeso(new VehiculoArgumento { Vehiculo = new Vehiculo() });
                _vista.EstablecerVehiculosEnBaseAPesoDePickings(0);
                _vista.Configuracion = ConfiguracionServicio.ObtenerConfiguracionesGrupoYTipo(new Entidades.Configuracion() { PARAM_TYPE = "SISTEMA", PARAM_GROUP = "MANIFIESTO_DE_CARGA" });
                
                _vista.Bodegas = BodegaServicio.ObtenerBodegaAsignadaAUsuario(InteraccionConUsuarioServicio.ObtenerUsuario());
                _vista.Rutas = RutasSwiftExpressServicio.ObtenerTodasRutas();
                _vista.Usuario = InteraccionConUsuarioServicio.ObtenerUsuario();
                _vista.Parametros = ParametroServicio.ObtenerParametro(new ConsultaArgumento
                {
                    GrupoParametro = Enums.GetStringValue(GrupoParametro.DemandaDePicking),
                    IdParametro = Enums.GetStringValue(IdParametro.ObtieneTipoDeDemanda)
                });
                _vista.ObtenerPuntosDeControles();
                _vista.DetallesEliminados = new List<int?>();
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }

        }

        private void _vista_UsuarioDeseaGrabarManifiesto(object sender, Argumentos.ManifiestoArgumento e)
        {
            try
            {
                e.ManifiestoEncabezado.LAST_UPDATE_BY = InteraccionConUsuarioServicio.ObtenerUsuario();
                if (_vista.EstaModificando)
                {
                    try
                    {
                        BaseDeDatosServicio.BeginTransaction();

                        if (_vista.ManifiestoDeCargaEncabezado.STATUS == Enums.GetStringValue(Estados.EstadosManifiesto.Creado))
                        {
                            ConsultaDeManifiestoServicio.ActualizarVehiculoAManifiesto(e);
                            ManifiestoCargaServicio.EliminarManifiestoDetalle(e);
                        }
                        else if (_vista.ManifiestoDeCargaEncabezado.STATUS == Enums.GetStringValue(Estados.EstadosManifiesto.Certificado)) {
                            ManifiestoCargaServicio.EliminarManifiestoDetalleCertificado(e);
                            BaseDeDatosServicio.Commit();
                            return;
                        }

                        ManifiestoCargaServicio.GrabarManifiestoDetalle(e);
                        BaseDeDatosServicio.Commit();
                    }
                    catch (Exception)
                    {
                        BaseDeDatosServicio.Rollback();
                        throw;
                    }
                }
                else
                {
                    _vista.LastManifestHeaderId = ManifiestoCargaServicio.GrabarManifiestoEncabezado(e).DbData;
                }
                _vista.TerminarProceso(sender);
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaConsultarVehiculos(object sender, System.EventArgs e)
        {
            try
            {
                _vista.Vehiculos = VehiculoServicio.ObtenerVehiculos(new VehiculoArgumento { Vehiculo = new Vehiculo() });
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaConsultarPickingEncabezado(object sender, Argumentos.ManifiestoArgumento e)
        {
            try
            {
                _vista.PickingEncabezado = PickingServicio.ConsultarPickingEncabezadosFinalizados(e);
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaConsultarPickingDetalle(object sender, Argumentos.ManifiestoArgumento e)
        {
            try
            {
                if (_vista.PickingDetalle == null)
                {
                    _vista.PickingDetalle = new List<PickingDetalle>();
                }

                _vista.PickingDetalle = _vista.PickingDetalle.Where(x => !x.EsNuevo).ToList();
                var lista = _vista.PickingDetalle.ToList();
                lista.AddRange(PickingServicio.ObtenerPickingDetalle(e.EncabezadosSeleccionados));
                _vista.PickingDetalle = lista;

                _vista.EstablecerVehiculosEnBaseAPesoDePickings(_vista.ObtenerPesoTotalDelDetalleDePicking());
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }
    }
}
