using System;
using MobilityScm.Modelo.Interfaces.Controladores;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Modelo.Vistas;
using MobilityScm.Vertical.Servicios;

namespace MobilityScm.Modelo.Controladores
{
    public class ConsultaDeLineaDePickingControlador : IConsultaDeLineaDePickingControlador
    {
        private readonly IConsultaDeLineaDePickingVista _vista;

        public IInteraccionConUsuarioServicio InteraccionConUsuarioServicio { get; set; }

        public ILineaDePickingServicio LineaDePickingServicio { get; set; }

        public ConsultaDeLineaDePickingControlador(IConsultaDeLineaDePickingVista vista)
        {
            _vista = vista;
            SuscribirEventos();
        }

        private void SuscribirEventos()
        {
            _vista.VistaCargandosePorPrimeraVez += _vista_VistaCargandosePorPrimeraVez;
            _vista.VistaTerminoDeCargar += _vista_VistaTerminoDeCargar;
            _vista.UsuarioDeseaObtenerCajas += _vista_UsuarioDeseaObtenerCajas;
        }

        private void _vista_UsuarioDeseaObtenerCajas(object sender, Argumentos.ConsultaArgumento e)
        {
            try
            {
                _vista.Cajas = LineaDePickingServicio.ObtenerCajasPorFecha(e);
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(ex.Message);
            }
        }

        private void _vista_VistaTerminoDeCargar(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void _vista_VistaCargandosePorPrimeraVez(object sender, System.EventArgs e)
        {
            
        }
    }
}