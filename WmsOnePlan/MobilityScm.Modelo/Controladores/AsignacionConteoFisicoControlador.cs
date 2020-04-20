using System;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Modelo.Servicios;
using MobilityScm.Modelo.Tipos;
using MobilityScm.Modelo.Vistas;
using MobilityScm.Vertical.Servicios;

namespace MobilityScm.Modelo.Controladores
{
    public class AsignacionConteoFisicoControlador : IAsignacionConteoFisicoControlador
    {
        private readonly IAsignacionConteosFisicosVista _vista;

        public IConteoFisicoServicio ConteoFisicoServicio { get; set; }

        public IMaterialServicio MaterialServicio { get; set; }

        public IUbicacionServicio UbicacionServicio { get; set; }
        public IBodegaServicio BodegaServicio { get; set; }
        public IClienteServicio ClienteServicio { get; set; }
        public IInteraccionConUsuarioServicio InteraccionConUsuarioServicio { get; set; }
        public IUsuarioServicio UsuarioServicio { get; set; }
        public IConfiguracionServicio ConfiguracionServicio { get; set; }

        public AsignacionConteoFisicoControlador(IAsignacionConteosFisicosVista vista)
        {
            _vista = vista;
            SuscribirEventos();
        }

        private void SuscribirEventos()
        {
            _vista.UsuarioDeseaGrabarConteoFisico += _vista_UsuarioDeseaGrabarConteoFisico;
            _vista.UsuarioDeseaObtenerBodegas += _vista_UsuarioDeseaObtenerBodegas;
            _vista.UsuarioDeseaObtenerClientes += _vista_UsuarioDeseaObtenerClientes;
            _vista.UsuarioDeseaObtenerMaterial += _vista_UsuarioDeseaObtenerMaterial;
            _vista.UsuarioDeseaObtenerUbicaciones += _vista_UsuarioDeseaObtenerUbicaciones;
            _vista.UsuarioDeseaObtenerUsuarios += _vista_UsuarioDeseaObtenerUsuarios;
            _vista.UsuarioDeseaObtenerZonas += _vista_UsuarioDeseaObtenerZonas;
            _vista.UsuarioDeseaObtenerUbicacionesPorFiltro += _vista_UsuarioDeseaObtenerUbicacionesPorFiltro;
            _vista.UsuarioDeseaObtenerPrioridades += _vista_UsuarioDeseaObtenerPrioridades;
            _vista.VistaCargandosePorPrimeraVez += _vista_VistaCargandosePorPrimeraVez;
        }

        private void _vista_VistaCargandosePorPrimeraVez(object sender, EventArgs e)
        {
            _vista_UsuarioDeseaObtenerPrioridades(sender, e);            
            _vista_UsuarioDeseaObtenerUsuarios(sender, e);
            _vista.Regimen = ConfiguracionServicio.ObtenerConfiguracionesGrupoYTipo(new MobilityScm.Modelo.Entidades.Configuracion { PARAM_TYPE = "WMS3PL", PARAM_GROUP = "WAREHOUSE_REGIMEN" });
        }

        private void _vista_UsuarioDeseaObtenerPrioridades(object sender, EventArgs e)
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

        private void _vista_UsuarioDeseaObtenerUbicacionesPorFiltro(object sender, Argumentos.ConteoFisicoArgumento e)
        {
            try
            {
                _vista.ConteoDetalles = UbicacionServicio.ObtenerUbicacionesPorFiltros(e);
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaObtenerZonas(object sender, Argumentos.ConteoFisicoArgumento e)
        {
            try
            {
                _vista.Zonas = BodegaServicio.ObtenerZonasDeUnaBodega(new Bodega { WAREHOUSE_ID =  e.Bodegas});
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaObtenerUsuarios(object sender, EventArgs e)
        {
            try
            {
                _vista.Usuarios = UsuarioServicio.ObtenerUsuariosTipoBodegaAsignadosCD(InteraccionConUsuarioServicio.ObtenerCentroDistribucion());
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaObtenerUbicaciones(object sender, Argumentos.ConteoFisicoArgumento e)
        {
            try
            {
                _vista.Ubicaciones = UbicacionServicio.ObtenerUbicacionesPorZonaOBodega(e);
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaObtenerMaterial(object sender, Argumentos.ConteoFisicoArgumento e)
        {
            try
            {
                _vista.Materiales = MaterialServicio.ObtenerMaterialesPorBodegaClienteUbicacionOZona(e);
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaObtenerClientes(object sender, Argumentos.ConteoFisicoArgumento e)
        {
            try
            {
                _vista.Clientes = ClienteServicio.ObtenerClientesPorRegimen(e);
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaObtenerBodegas(object sender, Argumentos.ConteoFisicoArgumento e)
        {
            try
            {
                _vista.Bodegas = BodegaServicio.ObtenerBodegasPorUsuariosRelacionados(e);
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaGrabarConteoFisico(object sender, Argumentos.ConteoFisicoArgumento e)
        {
            try
            {
                var op = ConteoFisicoServicio.GenerarTareaConteoFisico(e);
                if (op.Resultado == ResultadoOperacionTipo.Error)
                {
                    throw new Exception("Ocurrió un error al crear conteo: " + op.Mensaje);
                }

            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }
    }
}
