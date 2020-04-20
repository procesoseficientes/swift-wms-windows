using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MobilityScm.Modelo.Interfaces.Controladores;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Modelo.Vistas;
using MobilityScm.Vertical.Servicios;

namespace MobilityScm.Modelo.Controladores
{
    public class ConsultaPedidosPorVendedorControlador: IConsultaPedidosPorVendedorControlador
    {
        private readonly IConsultaPedidosPorVendedorVista _vista;

        public IInteraccionConUsuarioServicio InteraccionConUsuarioServicio { get; set; }

        public IDemandaDeDespachoServicio DemandaDeDespachoServicio { get; set; }

        public IBodegaServicio BodegaServicio { get; set; }

        public ConsultaPedidosPorVendedorControlador(IConsultaPedidosPorVendedorVista vista)
        {
            _vista = vista;
            SuscribirEventos();
        }

        private void SuscribirEventos()
        {
            _vista.VistaCargandosePorPrimeraVez += _vista_VistaCargandosePorPrimeraVez;
            _vista.VistaTerminoDeCargar += _vista_VistaTerminoDeCargar;
            _vista.UsuarioDeseaObtenerReporte += _vista_UsuarioDeseaObtenerReporte;
        }

        private void _vista_UsuarioDeseaObtenerReporte(object sender, Argumentos.ConsultaArgumento e)
        {
            try
            {
                _vista.PedidosPorVendedor = DemandaDeDespachoServicio.GenerarReportePedidosPorVendedor(e);
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

        private void _vista_VistaCargandosePorPrimeraVez(object sender, EventArgs e)
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
