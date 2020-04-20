using System;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Interfaces.Controladores;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Modelo.Vistas;
using MobilityScm.Vertical.Servicios;

namespace MobilityScm.Modelo.Controladores
{
    public class EstadoDeUbicacionesControlador : IEstadoDeUbicacionesControlador
    {
        private readonly IEstadoDeUbicacionesVista _vista;

        public IInteraccionConUsuarioServicio InteraccionConUsuarioServicio { get; set; }

        public IBodegaServicio BodegaServicio { get; set; }
        public IConfiguracionServicio ConfiguracionServicio { get; set; }
        public IEstadoDeUbicacionesServicio EstadoDeUbicacionesServicio { get; set; }

        public EstadoDeUbicacionesControlador(IEstadoDeUbicacionesVista vista)
        {
            _vista = vista;
            SuscribirEventos();
        }

        private void SuscribirEventos()
        {
            _vista.UsuarioDeseaObtenerBodegasAsignadasAUsuario += _vista_UsuarioDeseaObtenerBodegasAsignadasAUsuario;
            _vista.UsuarioDeseaObtenerEstadoDeUbicaciones += _vista_UsuarioDeseaObtenerEstadoDeUbicaciones;
            _vista.UsuarioDeseaObtenerZonasPorWarehouse += _vista_UsuarioDeseaObtenerZonasPorWarehouse;
            _vista.VistaCargandosePorPrimeraVez += _vista_VistaCargandosePorPrimeraVez;
        }

        private void _vista_VistaCargandosePorPrimeraVez(object sender, System.EventArgs e)
        {
            try
            {
                _vista.TiposUbicacion = ConfiguracionServicio.ObtenerConfiguracionesGrupoYTipo(new Entidades.Configuracion
                {
                    PARAM_TYPE = "SISTEMA",
                    PARAM_GROUP = "TIPO_UBICACIONES"
                });
                _vista.Bodegas = BodegaServicio.ObtenerBodegaAsignadaAUsuario(InteraccionConUsuarioServicio.ObtenerUsuario());
                _vista.Ubicaciones =
                    EstadoDeUbicacionesServicio.ObtenerEstadoDeUbicaciones(new EstadoDeUbicacionArgumento());

            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaObtenerZonasPorWarehouse(object sender, Argumentos.EstadoDeUbicacionArgumento e)
        {
            try
            {
                _vista.Zonas = BodegaServicio.ObtenerZonasDeUnaBodega(new Bodega { WAREHOUSE_ID = e.Bodega });
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaObtenerEstadoDeUbicaciones(object sender, Argumentos.EstadoDeUbicacionArgumento e)
        {
            try
            {
                _vista.Ubicaciones = EstadoDeUbicacionesServicio.ObtenerEstadoDeUbicaciones(e);
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaObtenerBodegasAsignadasAUsuario(object sender, Argumentos.EstadoDeUbicacionArgumento e)
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
    }
}
