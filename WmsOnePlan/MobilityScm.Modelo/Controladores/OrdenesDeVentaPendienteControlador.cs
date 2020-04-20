using System;
using System.Collections.Generic;
using System.Linq;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Interfaces.Controladores;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Modelo.Vistas;
using MobilityScm.Vertical.Servicios;

namespace MobilityScm.Modelo.Controladores
{
    public class OrdenesDeVentaPendienteControlador : IOrdenesDeVentaPendienteControlador
    {
        private readonly IOrdenesDeVentaPendientesVista _vista;

        public IOrdenDeVentaSwiftExpressServicio OrdenDeVentaSwiftExpressServicio { get; set; }

        public IRutasSwiftExpressServicio RutasSwiftExpressServicio { get; set; }

        public IInteraccionConUsuarioServicio InteraccionConUsuarioServicio { get; set; }
        public IOrdenDeVentaERPServicio OrdenDeVentaErpServicio { get; set; }

        public OrdenesDeVentaPendienteControlador(IOrdenesDeVentaPendientesVista vista)
        {
            _vista = vista;
            SuscribirEventos();
        }

        private void SuscribirEventos()
        {
            _vista.UsuarioDeseaObtenerOrdenesDeVentaPendiente += _vista_UsuarioDeseaObtenerOrdenesDeVentaPendiente;
            _vista.UsuarioDeseaObtenerRutas += _vista_UsuarioDeseaObtenerRutas;
            _vista.UsuarioDeseaQuitarLineasCompletas += _vista_UsuarioDeseaQuitarLineasCompletas;
            _vista.VistaCargandosePorPrimeraVez += _vista_VistaCargandosePorPrimeraVez;
        }

        private void _vista_VistaCargandosePorPrimeraVez(object sender, EventArgs e)
        {
            _vista_UsuarioDeseaObtenerRutas(sender, e);
        }

        private void _vista_UsuarioDeseaQuitarLineasCompletas(object sender, EventArgs e)
        {
            try
            {
                _vista.OrdenesDeVentaPendiente = _vista.OrdenesDeVentaPendiente.Where(x => x.DIFERENCE != 0).ToList();

            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.Mensaje(exception.Message);
            }
        }

        private void _vista_UsuarioDeseaObtenerRutas(object sender, EventArgs e)
        {
            try
            {
                _vista.Rutas = RutasSwiftExpressServicio.ObtenerRutas();
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.Mensaje(exception.Message);
            }
        }

        private void _vista_UsuarioDeseaObtenerOrdenesDeVentaPendiente(object sender, Argumentos.OrdenDeVentaArgumento e)
        {
            try
            {
               var list = new List<OrdenDeVentaPendiente>();
                if (_vista.OrdenesDeErp) list.AddRange(OrdenDeVentaErpServicio.ObtenerOrdenVentaPendientes(e));
                if (_vista.OrdenesDeSonda) list.AddRange(OrdenDeVentaSwiftExpressServicio.ObtenerOrdenVentaPendientes(e));
                _vista.OrdenesDeVentaPendiente = list;
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.Mensaje(exception.Message);
            }
        }
    }
}
