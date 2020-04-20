using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Interfaces.Controladores;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Modelo.Tipos;
using MobilityScm.Modelo.Vistas;
using MobilityScm.Utilerias;
using MobilityScm.Vertical.Servicios;

namespace MobilityScm.Modelo.Controladores
{
    public class AcuerdoComercialPorInventarioControlador : IAcuerdoComercialPorInventarioControlador
    {
        private readonly IAcuerdoComercialPorInventarioVista _vista;

        public IAcuerdoComercialServicio AcuerdoComercialServicio { get; set; }

        public IClienteServicio ClienteServicio { get; set; }
        public IInteraccionConUsuarioServicio InteraccionConUsuarioServicio { get; set; }

        public AcuerdoComercialPorInventarioControlador(IAcuerdoComercialPorInventarioVista vista)
        {
            _vista = vista;
            SuscribirEventos();
        }

        private void SuscribirEventos()
        {
            _vista.VistaCargandosePorPrimeraVez += _vista_VistaCargandosePorPrimeraVez;
            //_vista.UsuarioDeseaObtenerClientes += _vista_UsuarioDeseaObtenerClientes;
            _vista.UsuarioDeseaObtenerAcuerdoComercialPorInventario += _vista_UsuarioDeseaObtenerAcuerdoComercialPorInventario;
        }

        private void _vista_UsuarioDeseaObtenerClientes(object sender, EventArgs e)
        {
            try
            {
                _vista.Clientes = ClienteServicio.ObtenerClientes();
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
                _vista.Clientes = ClienteServicio.ObtenerClientes();
                _vista.Usuario = InteraccionConUsuarioServicio.ObtenerUsuario();
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaObtenerAcuerdoComercialPorInventario(object sender, AcuerdoComercialArgumento e)
        {
            try
            {
                _vista.AcuerdosComerciales = AcuerdoComercialServicio.ObtenerAcuerdosComerciales(e);
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }
    }
}
