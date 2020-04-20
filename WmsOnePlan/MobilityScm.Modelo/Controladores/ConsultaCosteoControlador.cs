using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Interfaces.Controladores;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Modelo.Servicios;
using MobilityScm.Modelo.Tipos;
using MobilityScm.Modelo.Vistas;
using MobilityScm.Vertical.Servicios;

namespace MobilityScm.Modelo.Controladores
{
    public class ConsultaCosteoControlador : IConsultaCosteoControlador
    {
        private readonly IConsultaCosteoVista _vista;

        public IInteraccionConUsuarioServicio InteraccionConUsuarioServicio { get; set; }
        public IConsultaCosteoServicio ConsultaCosteoServicio { get; set; }

        public IBodegaServicio BodegaServicio { get; set; }

        public ConsultaCosteoControlador(IConsultaCosteoVista vista)
        {
            _vista = vista;
            SuscribirEventos();
        }

        private void SuscribirEventos()
        {
            _vista.UsuarioDeseaObtenerPolizasMaestroDetallePendientesDeAutorizar += _vista_UsuarioDeseaObtenerPolizasMaestroDetallePendientesDeAutorizar;
            _vista.UsuarioDeseaAutorizarCosteoPoliza += _vista_UsuarioDeseaAutorizarCosteoPoliza;
            _vista.VistaCargandosePorPrimeraVez += _vista_VistaCargandosePorPrimeraVez;
        }

        private void _vista_VistaCargandosePorPrimeraVez(object sender, EventArgs e)
        {
            try
            {
                _vista.Usuario = InteraccionConUsuarioServicio.ObtenerUsuario();
                _vista.Bodegas = BodegaServicio.ObtenerBodegaAsignadaAUsuario(InteraccionConUsuarioServicio.ObtenerUsuario());

            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(exception.Message);
            }
        }

        private void _vista_UsuarioDeseaAutorizarCosteoPoliza(object sender, CosteoArgumento e)
        {
            try
            {
                var op = ConsultaCosteoServicio.AutorizarCosteoPoliza(e);
                if (op.Resultado == ResultadoOperacionTipo.Error)
                {
                    InteraccionConUsuarioServicio.MensajeErrorDialogo(op.Mensaje);
                }
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(exception.Message);
            }
        }

        private void _vista_UsuarioDeseaObtenerPolizasMaestroDetallePendientesDeAutorizar(object sender, CosteoArgumento e)
        {
            try
            {
                if (_vista.LineasAbiertas)
                {
                    _vista.PolizasMaestroDetalle = ConsultaCosteoServicio.ObtenerPolizasMaestroDetallePendientesDeAutorizar(e).Where(x => x.STATUS == "Abierto").ToList();
                }
                else
                {
                    _vista.PolizasMaestroDetalle = ConsultaCosteoServicio.ObtenerPolizasMaestroDetallePendientesDeAutorizar(e);
                }

            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(exception.Message);
            }
        }


    }
}
