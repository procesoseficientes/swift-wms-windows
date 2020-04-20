using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MobilityScm.Modelo.Interfaces.Controladores;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Modelo.Tipos;
using MobilityScm.Modelo.Vistas;
using MobilityScm.Vertical.Entidades;
using MobilityScm.Vertical.Servicios;

namespace MobilityScm.Modelo.Controladores
{
    public class ServicioPorCobrarControlador : IServicioPorCobrarControlador
    {
        private IServicioPorCobrarVista _vista;

        public IServiciosPorCobrarServicio ServicioPorCobrarServicio { get; set; }

        public IClienteServicio ClienteServicio { get; set; }

        public IInteraccionConUsuarioServicio InteraccionConUsuarioServicio { get; set; }

        public ServicioPorCobrarControlador(IServicioPorCobrarVista vista)
        {
            _vista = vista;
            SuscribirEventos();
        }

        private void SuscribirEventos()
        {
            _vista.UsuarioDeseaCargarServiciosPorCobrarPorFecha += _vista_UsuarioDeseaCargarServiciosPorCobrarPorFecha;
            _vista.UsuarioDeseaGuardarCambioDePrecio += _vista_UsuarioDeseaGuardarCambioDePrecio;
            _vista.UsuarioDeseaEjecutarProcesoAlMomento += _vista_UsuarioDeseaEjecutarProcesoAlMomento;
            _vista.VistaTerminoDeCargarPorPrimeraVez += _vista_VistaTerminoDeCargarPorPrimeraVez;
            _vista.UsuarioDeseaMarcarComoCobrado += _vista_UsuarioDeseaMarcarComoCobrado;
        }

        private void _vista_UsuarioDeseaMarcarComoCobrado(object sender, Argumentos.ServicioPorCobrarArgumento e)
        {
            try
            {
                InteraccionConUsuarioServicio.Confirmar("Confirma marcar como cobrados los registos?",
                    () =>
                    {
                        foreach (var servicio in e.ListaDeServiciosPorCobrar)
                        {
                            servicio.LAST_UPDATED_BY = InteraccionConUsuarioServicio.ObtenerUsuario();
                            var resultado = ServicioPorCobrarServicio.ModificarServicioPorCobrar(servicio);
                            if (resultado.Resultado == ResultadoOperacionTipo.Error)
                            {
                                InteraccionConUsuarioServicio.Mensaje("No se pudo ejecutar el proceso debido a: " + resultado.Mensaje);
                            }
                        }


                    }, "Servicios Por Cobrar", "Aceptar", "Cancelar");
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje("No se pudo actualizar el registro debido a: " + ex.Message);
            }
        }

        private void _vista_VistaTerminoDeCargarPorPrimeraVez(object sender, EventArgs e)
        {
            try
            {
                _vista.Clientes = ClienteServicio.ObtenerClientes();
                _vista.Usuario = InteraccionConUsuarioServicio.ObtenerUsuario();
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje("No se pudo ejecutar el proceso debido a: " + ex.Message);
            }
        }

        private void _vista_UsuarioDeseaEjecutarProcesoAlMomento(object sender, Argumentos.ServicioPorCobrarArgumento e)
        {
            try
            {
                InteraccionConUsuarioServicio.Confirmar("Este proceso puede tardar y puede afectar el rendimiento de la aplicacion",
                    () =>
                    {
                        e.Login = InteraccionConUsuarioServicio.ObtenerUsuario();
                        var resultado = ServicioPorCobrarServicio.EjecutarProcesoServiciosPorCobrar(e.Login);
                        if (resultado.Resultado == ResultadoOperacionTipo.Error)
                        {
                            InteraccionConUsuarioServicio.Mensaje("No se pudo ejecutar el proceso debido a: " + resultado.Mensaje);
                        }
                    }, "Servicios Por Cobrar", "Aceptar", "Cancelar");


            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje("No se pudo ejecutar el proceso debido a: " + ex.Message);
            }

        }

        private void _vista_UsuarioDeseaGuardarCambioDePrecio(object sender, Argumentos.ServicioPorCobrarArgumento e)
        {
            try
            {
                InteraccionConUsuarioServicio.Confirmar("Confirma guardar cambios de la tarifa?",
                    () =>
                    {
                        foreach (var servicio in e.ListaDeServiciosPorCobrar.Where(servicio => servicio.PRICE_TO_CHANGE != servicio.PRICE))
                        {
                            servicio.LAST_UPDATED_BY = InteraccionConUsuarioServicio.ObtenerUsuario();
                            var resultado = ServicioPorCobrarServicio.ModificarServicioPorCobrar(servicio);
                            if (resultado.Resultado == ResultadoOperacionTipo.Error)
                            {
                                InteraccionConUsuarioServicio.Mensaje("No se pudo ejecutar el proceso debido a: " + resultado.Mensaje);
                            }
                        }
                        
                        
                    }, "Servicios Por Cobrar", "Aceptar", "Cancelar");
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje("No se pudo actualizar el registro debido a: " + ex.Message);
            }
        }

        private void _vista_UsuarioDeseaCargarServiciosPorCobrarPorFecha(object sender, Argumentos.ServicioPorCobrarArgumento e)
        {
            try
            {
                if (!string.IsNullOrEmpty(e.ServicioPorCobrar.CLIENT_CODE))
                {
                    _vista.ListaDeServiciosPorCobrar =
                    ServicioPorCobrarServicio.ConsultarServiciosPorCobrarPorFecha(e.FechaInicio, e.FechaFinal, e.ServicioPorCobrar);
                }
                else
                {
                    InteraccionConUsuarioServicio.Mensaje("Seleccione un cliente.");
                }

            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje("Error al intentar cargar los Servicios Por Cobrar debido a: " + ex.Message);
            }
        }


    }
}
