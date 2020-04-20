using System;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Interfaces.Controladores;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Modelo.Tipos;
using MobilityScm.Modelo.Vistas;
using MobilityScm.Vertical.Servicios;

namespace MobilityScm.Modelo.Controladores
{
    public class InventarioComprometidoControlador : IInventarioComprometidoControlador
    {
        private readonly IInventarioComprometidoVista _vista;

        public IInventarioComprometidoServicio InventarioComprometidoServicio { get; set; }

        public IInteraccionConUsuarioServicio InteraccionConUsuarioServicio { get; set; }

        public InventarioComprometidoControlador(IInventarioComprometidoVista vista)
        {
            _vista = vista;
            SubscribirEventos();
        }
        private void SubscribirEventos()
        {
            try
            {
                _vista.UsuarioDeseaObtenerInventarioComprometido += _vista_UsuarioDeseaObtenerInventarioComprometidoEncabezado;
                _vista.UsuarioDeseaCancelarElInventarioPreparado += _vista_UsuarioDeseaCancelarElInventarioPreparado;
            }
            catch (Exception e)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(e.Message);
            }
        }

        private void _vista_UsuarioDeseaCancelarElInventarioPreparado(object sender, InventarioComprometidoArgumento e)
        {
            var op = InventarioComprometidoServicio.CancelarOrdenPreparada(e);
            if (op.Resultado == ResultadoOperacionTipo.Exito)
            {
                _vista.RecargarPantalla();
            }
            else
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(op.Mensaje);
            }
        }

        private void _vista_UsuarioDeseaObtenerInventarioComprometidoEncabezado(object sender, InventarioComprometidoArgumento e)
        {
            e.Usuario = InteraccionConUsuarioServicio.ObtenerUsuario();

            _vista.InventarioComprometidoEncabezados =
                InventarioComprometidoServicio.ObtenerEncabezadosParaReporteDeInventarioComprometido(e);

            e.InventarioComprometidoEncabezados = _vista.InventarioComprometidoEncabezados;

            _vista.InventarioComprometidoTodosDetalles =
                InventarioComprometidoServicio.ObtenerDetallesParaReporteDeInventarioComprometido(e);
        }

    }
}
