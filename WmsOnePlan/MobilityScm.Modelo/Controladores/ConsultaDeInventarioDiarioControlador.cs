using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Interfaces.Controladores;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Modelo.Vistas;
using MobilityScm.Vertical.Servicios;

namespace MobilityScm.Modelo.Controladores
{
    public class ConsultaDeInventarioDiarioControlador : IConsultaDeInventarioDiarioControlador
    {
        private readonly IConsultaDeInventarioDiarioVista _vista;

        public IInventarioServicio InventarioServicio { get; set; }

        public IBodegaServicio BodegaServicio { get; set; }

        public IInteraccionConUsuarioServicio InteraccionConUsuarioServicio { get; set; }

        public ConsultaDeInventarioDiarioControlador(IConsultaDeInventarioDiarioVista vista)
        {
            _vista = vista;
            SuscribirEventos();
        }

        private void SuscribirEventos()
        {
            _vista.VistaTerminoDeCargar += _vista_VistaTerminoDeCargar;
            _vista.VistaCargandosePorPrimeraVez += _vista_VistaCargandosePorPrimeraVez;

            _vista.UsuarioDeseaConsultarInventarioDiario += _vista_UsuarioDeseaConsultarInventarioDiario;
        }

        private void _vista_UsuarioDeseaConsultarInventarioDiario(object sender, Argumentos.ConsultaArgumento e)
        {
            try
            {
                _vista.Inventario = InventarioServicio.ObtenerReporteDiarioDeInventario(e);
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
                _vista.Inventario = new List<ReporteDeInventarioDiario>();
                _vista.Bodegas = BodegaServicio.ObtenerBodegaAsignadaAUsuario(InteraccionConUsuarioServicio.ObtenerUsuario());
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(ex.Message);
            }
        }

        private void _vista_VistaTerminoDeCargar(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
