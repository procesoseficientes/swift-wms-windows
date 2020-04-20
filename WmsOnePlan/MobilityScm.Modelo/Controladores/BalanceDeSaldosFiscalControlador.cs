using System;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Interfaces.Controladores;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Modelo.Vistas;
using MobilityScm.Vertical.Servicios;

namespace MobilityScm.Modelo.Controladores
{
    public class BalanceDeSaldosFiscalControlador: IBalanceDeSaldosFiscalControlador
    {
        private readonly IBalanceDeSaldosFiscalVista _vista;

        public IBalanceDeSaldosFiscalServicio BalanceDeSaldosFiscalServicio { get; set; }

        public IInteraccionConUsuarioServicio InteraccionConUsuarioServicio { get; set; }

        public BalanceDeSaldosFiscalControlador(IBalanceDeSaldosFiscalVista vista)
        {
            _vista = vista;
            SuscribirEventos();
        }

        private void SuscribirEventos()
        {
            _vista.VistaCargandosePorPrimeraVez += _vista_VistaCargandosePorPrimeraVez;
            _vista.UsuarioDeseaObtenerBalanceDeSaldosFiscal += _vista_UsuarioDeseaObtenerBalanceDeSaldosFiscal;
        }

        private void _vista_UsuarioDeseaObtenerBalanceDeSaldosFiscal(object sender, BalanceDeSaldosFiscalArgumento e)
        {
            try
            {
                _vista.BalanceDeSaldosFiscal = BalanceDeSaldosFiscalServicio.ObtenerAcuerdosComerciales(new BalanceDeSaldosFiscalArgumento {Usuario = InteraccionConUsuarioServicio.ObtenerUsuario()});
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
                _vista.BalanceDeSaldosFiscal = BalanceDeSaldosFiscalServicio.ObtenerAcuerdosComerciales(new BalanceDeSaldosFiscalArgumento { Usuario = InteraccionConUsuarioServicio.ObtenerUsuario() });
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }
    }
}
