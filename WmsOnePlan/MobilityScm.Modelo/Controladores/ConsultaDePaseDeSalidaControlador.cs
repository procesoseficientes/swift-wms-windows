using System;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Interfaces.Controladores;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Modelo.Vistas;
using MobilityScm.Vertical.Servicios;

namespace MobilityScm.Modelo.Controladores
{
    public class ConsultaDePaseDeSalidaControlador: IConsulaDePaseDeSalidaControlador
    {

        private readonly IConsultaDePaseDeSalidaVista _vista;

        public IPaseDeSalidaServicio PaseDeSalidaServicio { get; set; }

        public IInteraccionConUsuarioServicio InteraccionConUsuarioServicio { get; set; }

        public ConsultaDePaseDeSalidaControlador(IConsultaDePaseDeSalidaVista vista)
        {
            _vista = vista;
            SubscribirEventos();
        }

        private void SubscribirEventos()
        {
            _vista.VistaCargandosePorPrimeraVez += _vista_VistaCargandosePorPrimeraVez;
            _vista.UsuarioDeseaObtenerPasesDeSalida += _vista_UsuarioDeseaObtenerPasesDeSalida;
        }

        private void _vista_UsuarioDeseaObtenerPasesDeSalida(object sender, PaseDeSalidaArgumento e)
        {
            try
            {
                _vista.PasesDeSalida = PaseDeSalidaServicio.ObtnerPasesDeSalidas(e);
            }
            catch (Exception exception)
            {
               InteraccionConUsuarioServicio.MensajeErrorDialogo(exception.Message);
            }
        }

        private void _vista_VistaCargandosePorPrimeraVez(object sender, System.EventArgs e)
        {
            try
            {
                _vista.InicializarCampos();
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(exception.Message);
            }
        }
    }
}