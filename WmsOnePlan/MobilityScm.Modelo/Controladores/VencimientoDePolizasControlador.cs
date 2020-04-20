using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Interfaces.Controladores;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Modelo.Tipos;
using MobilityScm.Modelo.Vistas;
using MobilityScm.Vertical.Entidades;
using MobilityScm.Vertical.Servicios;


namespace MobilityScm.Modelo.Controladores
{
    public class VencimientoDePolizasControlador : IVencimientoDePolizasControlador
    {
        private readonly IVencimientoDePolizasVista _vista;

        public IVencimientoDePolizasServicio VencimientoDePolizasServicio { get; set; }
        public IClienteServicio ClienteServicio { get; set; }
        public ISeguridadServicio SeguridadServicio { get; set; }
        public IInteraccionConUsuarioServicio InteraccionConUsuarioServicio { get; set; }

        public VencimientoDePolizasControlador(IVencimientoDePolizasVista vista)
        {
            _vista = vista;
            SuscribirEventos();
        }

        private void SuscribirEventos()
        {
            _vista.VistaCargandosePorPrimeraVez += _vista_VistaCargandosePorPrimeraVez;

            _vista.UsuarioDeseaObtenerPolizas += _vista_UsuarioDeseaObtenerPolizas;
            _vista.UsuarioDeseaObtenerClientes += _vista_UsuarioDeseaObtenerClientes;
        }

        private void _vista_UsuarioDeseaObtenerClientes(object sender, EventArgs e)
        {
            try
            {
                _vista.Clientes = ClienteServicio.ObtenerClientes();

                foreach (var cliente in _vista.Clientes)
                {
                    cliente.IS_SELECTED = true;
                }

            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(ex.Message);
            }
        }
        
        private void _vista_UsuarioDeseaObtenerPolizas(object sender, PolizaArgumento e)
        {
            try
            {
                _vista.Polizas = VencimientoDePolizasServicio.ObtenerPolizasListasAExpirar(e);
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(exception.Message);
            }
        }

        private void _vista_VistaCargandosePorPrimeraVez(object sender, EventArgs e)
        {
            try
            {
                _vista.Clientes = ClienteServicio.ObtenerClientes();
                _vista.Permisos =
                    SeguridadServicio.ObtenerPermisosDeSeguridad(new SeguridadArgumento
                    {
                        Seguridad = new Seguridad {PARENT = "POLIZAS_EXPIRADAS", CATEGORY = "SCREEN_SECURITY", LOGIN = InteraccionConUsuarioServicio.ObtenerUsuario()}
                    });

                foreach (var cliente in _vista.Clientes)
                {
                    cliente.IS_SELECTED = true;
                }
                
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(ex.Message);
            }
        }
        
    }
}
