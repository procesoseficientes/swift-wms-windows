using System;
using System.Collections.Generic;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Interfaces.Controladores;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Modelo.Tipos;
using MobilityScm.Modelo.Vistas;
using MobilityScm.Vertical.Servicios;

namespace MobilityScm.Modelo.Controladores
{
    public class ConsultaDeManifiestoControlador : IConsultaDeManifiestoControlador
    {
        private readonly IConsultaDeManifiestoVista _vista;

        public IConsultaDeManifiestoServicio ConsultaDeManifiestoServicio { get; set; }
        public IManifiestoCargaServicio ManifiestoCargaServicio { get; set; }
        public IInteraccionConUsuarioServicio InteraccionConUsuarioServicio { get; set; }
        public IVehiculoServicio VehiculoServicio { get; set; }

        public IParametroServicio ParametroServicio { get; set; }

        public ConsultaDeManifiestoControlador(IConsultaDeManifiestoVista vista)
        {
            _vista = vista;
            SubscribirEventos();
        }

        private void SubscribirEventos()
        {
            _vista.VistaCargandosePorPrimeraVez += _vista_VistaCargandosePorPrimeraVez;
            _vista.UsuarioDeseaCancelarManifiesto += _vista_UsuarioDeseaCancelarManifiesto;
            _vista.UsuarioDeseaActualizarVehiculoAManifiesto += _vista_UsuarioDeseaActualizarVehiculoAManifiesto;
            _vista.UsuarioDeseaObtenerDetallesDeManifiestos += _vista_UsuarioDeseaObtenerDetallesDeManifiestos;
            _vista.UsuarioDeseaObtenerEncabezadosDeManifiesto += _vista_UsuarioDeseaObtenerEncabezadosDeManifiesto;
            _vista.UsuarioDeseaQuitarDetallesDeManifiesto += _vista_UsuarioDeseaQuitarDetallesDeManifiesto;
            _vista.UsuarioDeseaObtenerVehiculosConPilotoAsociado += _vista_UsuarioDeseaObtenerVehiculosConPilotoAsociado;
        }

        private void _vista_UsuarioDeseaObtenerVehiculosConPilotoAsociado(object sender, ManifiestoArgumento e)
        {
            try
            {
                _vista.TodosVehiculos = VehiculoServicio.ObtenerVehiculosConPilotosAsociados();
                _vista.Vehiculos = _vista.TodosVehiculos;
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
                _vista.TodosVehiculos = VehiculoServicio.ObtenerVehiculosConPilotosAsociados();
                _vista.Vehiculos = _vista.TodosVehiculos;
                _vista.Usuario = InteraccionConUsuarioServicio.ObtenerUsuario();
                _vista.Parametros = ParametroServicio.ObtenerParametro(new ConsultaArgumento
                {
                    GrupoParametro = Enums.GetStringValue(GrupoParametro.DemandaDePicking),
                    IdParametro = Enums.GetStringValue(IdParametro.ObtieneTipoDeDemanda)
                });
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(exception.Message);
            }
        }

        private void _vista_UsuarioDeseaQuitarDetallesDeManifiesto(object sender, ManifiestoArgumento e)
        {
            try
            {
                var op = ConsultaDeManifiestoServicio.DesasociarDemandasDespachoDeManifiesto(e);
                if (op.Resultado == ResultadoOperacionTipo.Error)
                {
                    throw new Exception(op.Mensaje);
                }
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(exception.Message);
            }
        }

        private void _vista_UsuarioDeseaObtenerDetallesDeManifiestos(object sender, ManifiestoArgumento e)
        {
            try
            {
                _vista.DetallesDeManifiestos = ManifiestoCargaServicio.ObtenerManifiestoDetalle(e);
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(exception.Message);
            }
        }

        private void _vista_UsuarioDeseaObtenerEncabezadosDeManifiesto(object sender, ManifiestoArgumento e)
        {
            try
            {
                _vista.EncabezadosDeManifiesto = ConsultaDeManifiestoServicio.ObtenerEncabezadosDeManifiesto(e);
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(exception.Message);
            }
        }

        private void _vista_UsuarioDeseaActualizarVehiculoAManifiesto(object sender, ManifiestoArgumento e)
        {
            try
            {
                var op = ConsultaDeManifiestoServicio.ActualizarVehiculoAManifiesto(e);
                if (op.Resultado == ResultadoOperacionTipo.Error)
                {
                    throw new Exception(op.Mensaje);
                }
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(exception.Message);
            }
        }

        private void _vista_UsuarioDeseaCancelarManifiesto(object sender, ManifiestoArgumento e)
        {
            try
            {
                var op = ConsultaDeManifiestoServicio.CancelarManifiesto(e);
                if (op.Resultado == ResultadoOperacionTipo.Error)
                {
                    throw new Exception(op.Mensaje);
                }
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(exception.Message);
            }
        }
    }
}
