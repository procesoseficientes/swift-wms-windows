using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Estados;
using MobilityScm.Modelo.Interfaces.Controladores;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Modelo.Tipos;
using MobilityScm.Modelo.Vistas;
using MobilityScm.Vertical.Servicios;

namespace MobilityScm.Modelo.Controladores
{
    public class ReporteDeSolicitudDeTrasladoControlador : IReporteDeSolicitudDeTrasladoControlador
    {
        private readonly IReporteDeSolicitudDeTrasladoVista _vista;
        public ISolicitudDeTrasladoServicio SolicitudDeTrasladoServicio { get; set; }
        public IConfiguracionServicio ConfiguracionServicio { get; set; }
        public IBodegaServicio BodegaServicio { get; set; }
        public ISeguridadServicio SeguridadServicio { get; set; }

        public IInteraccionConUsuarioServicio InteraccionConUsuarioServicio { get; set; }
        public ReporteDeSolicitudDeTrasladoControlador(IReporteDeSolicitudDeTrasladoVista vista)
        {
            _vista = vista;
            SuscribirEventos();
        }

        private void SuscribirEventos()
        {
            _vista.UsuarioDeseaObtenerSolicitudesDeTrasladoPorBodegaEstadoYFecha += _vista_UsuarioDeseaObtenerSolicitudesDeTrasladoPorBodegaEstadoYFecha;
            _vista.UsuarioDeseaSeleccionoSolicitudDeTraslado += _vista_UsuarioDeseaSeleccionoSolicitudDeTraslado;
            _vista.UsuarioDeseaCerrarSolicitudesDeTraslado += _vista_UsuarioDeseaCerrarSolicitudesDeTraslado;
            _vista.UsuarioSeleccionoCentrosDeDistribucion += _vista_UsuarioSeleccionoCentrosDeDistribucion;

            _vista.VistaCargandosePorPrimeraVez += _vista_VistaCargandosePorPrimeraVez;
        }

        private void _vista_UsuarioSeleccionoCentrosDeDistribucion(object sender, ReporteDeSolicitudDeTrasladoArgumento e)
        {
            try
            {
                _vista.Bodegas = BodegaServicio.ObtenerBodegaPorCentroDeDistribucionYUsuario(new Bodega
                {
                    DISTRIBUTION_CENTER_ID = e.CentrosDeDistribucion
                    ,LOGIN = InteraccionConUsuarioServicio.ObtenerUsuario()
                    ,IS_WAREHOUSE_FROM = (int)SiNo.Si
                });
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaCerrarSolicitudesDeTraslado(object sender, Argumentos.ReporteDeSolicitudDeTrasladoArgumento e)
        {
            try
            {
                var traslados = string.Join("|", _vista.SolicitudesDeTraslado.Where(wt => wt.IS_SELECTED).Select(wt => wt.TRANSFER_REQUEST_ID));
                e.IdsSolicitudesDeTraslado = traslados;
                var operacion = SolicitudDeTrasladoServicio.CerrarSolicitudesDeTraslado(e);
                if (operacion.Resultado == ResultadoOperacionTipo.Error)
                {
                    InteraccionConUsuarioServicio.Mensaje(operacion.Mensaje);
                }
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaSeleccionoSolicitudDeTraslado(object sender, Argumentos.ReporteDeSolicitudDeTrasladoArgumento e)
        {
            try
            {
                _vista.TrazabilidadDeSolicitudesDeTraslado = SolicitudDeTrasladoServicio.ObtenerTrazabilidadDeSolicitudDeTraslado(e);
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaObtenerSolicitudesDeTrasladoPorBodegaEstadoYFecha(object sender, Argumentos.ReporteDeSolicitudDeTrasladoArgumento e)
        {
            try
            {
                _vista.SolicitudesDeTraslado = SolicitudDeTrasladoServicio.ObtenerSolicitudesDeTrasladoPorBodegaEstadoYFecha(e);
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
                _vista.CentrosDeDistribucion = ConfiguracionServicio.ObtenerCentrosDeDistribucionPorLogin(new Entidades.Configuracion
                {
                    LOGIN = InteraccionConUsuarioServicio.ObtenerUsuario()
                });

                _vista.ListaDeSeguridad =
                    SeguridadServicio.ObtenerPermisosDeSeguridad(new SeguridadArgumento
                    {
                        Seguridad =
                            new Seguridad
                            {
                                PARENT = Enums.GetStringValue(Tipos.PadreDePrivilegio.SolicitudDeTraslado),
                                CATEGORY = Enums.GetStringValue(Tipos.CategorigaDePrivilegio.Seguridad),
                                LOGIN = InteraccionConUsuarioServicio.ObtenerUsuario()
                            }
                    });
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }
    }
}
