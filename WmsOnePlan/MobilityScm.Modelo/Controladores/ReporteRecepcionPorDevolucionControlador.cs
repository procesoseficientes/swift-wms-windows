using System;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Interfaces.Controladores;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Modelo.Tipos;
using MobilityScm.Modelo.Vistas;
using MobilityScm.Vertical.Entidades;
using MobilityScm.Vertical.Servicios;
using Enums = MobilityScm.Modelo.Configuracion.Enums;

namespace MobilityScm.Modelo.Controladores
{
    public class ReporteRecepcionPorDevolucionControlador : IReporteRecepcionPorDevolucionControlador
    {
        private readonly IReporteRecepcionPorDevolucionVista _vista;

        public IRecepcionServicio RecepcionServicio { get; set; }

        public IBodegaServicio BodegaServicio { get; set; }

        public IInteraccionConUsuarioServicio InteraccionConUsuarioServicio { get; set; }

        public ReporteRecepcionPorDevolucionControlador(IReporteRecepcionPorDevolucionVista vista)
        {
            _vista = vista;
            SuscribirEventos();
        }

        private void SuscribirEventos()
        {
            _vista.VistaCargandosePorPrimeraVez += _vista_VistaCargandosePorPrimeraVez;
            _vista.VistaTerminoDeCargar += _vista_VistaTerminoDeCargar;

            _vista.UsuarioDeseaObtenerRecepcionesPorDevolucion += _vista_UsuarioDeseaObtenerRecepcionesPorDevolucion;
        }

        private void _vista_UsuarioDeseaObtenerRecepcionesPorDevolucion(object sender, ConsultaArgumento e)
        {
            try
            {
                _vista.RecepcionesPorDevoluciones = RecepcionServicio.ObtenerReporteRecepcionPorDevoulucion(e);
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void _vista_VistaTerminoDeCargar(object sender, EventArgs e)
        {
        }

        private void _vista_VistaCargandosePorPrimeraVez(object sender, EventArgs e)
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
    }
}
