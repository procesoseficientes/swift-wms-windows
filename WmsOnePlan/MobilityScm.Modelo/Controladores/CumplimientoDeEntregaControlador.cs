using System;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Interfaces.Controladores;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Modelo.Vistas;
using MobilityScm.Vertical.Servicios;

namespace MobilityScm.Modelo.Controladores
{
    public class CumplimientoDeEntregaControlador: ICumplimientoDeEntregaControlador
    {
        private readonly ICumplimientoDeEntregaVista _vista;

        public IPilotoServicio PilotoServicio { get; set; }

        public IVehiculoServicio VehiculoServicio { get; set; }

        public ICumplimientoDeEntregaServicio CumplimientoDeEntregaServicio{ get; set; }

        public IInteraccionConUsuarioServicio InteraccionConUsuarioServicio { get; set; }

        public CumplimientoDeEntregaControlador(ICumplimientoDeEntregaVista vista)
        {
            _vista = vista;
            SubscribirEventos();
        }

        private void SubscribirEventos()
        {
            try
            {
                _vista.VistaCargandosePorPrimeraVez += _vista_VistaCargandosePorPrimeraVez;
                _vista.UsuarioDeseaObtenerPilotos += _vista_UsuarioDeseaObtenerPilotos;
                _vista.UsuarioDeseaObtenerVehiculos += _vista_UsuarioDeseaObtenerVehiculos;
                _vista.UsuarioDeseaConsultarCumplimientoDeEntrega += _vista_UsuarioDeseaConsultarCumplimientoDeEntrega;
                _vista.UsuarioSeleccionoManifiestoDeCarga += _vista_UsuarioSeleccionoManifiestoDeCarga;
                _vista.UsuarioDeseaObtenerImagenesDeEntrega += _vista_UsuarioDeseaObtenerImagenesDeEntrega;
            }
            catch (Exception e)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(e.Message);
            }
        }

        private void _vista_UsuarioDeseaObtenerImagenesDeEntrega(object sender, CumplimientoDeEntregaArgumento e)
        {
            try
            {
                _vista.ImagenesDeEntrega = CumplimientoDeEntregaServicio.ObtenerImagenesDeLaEntrega(e);
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(exception.Message);
            }
        }

        private void _vista_UsuarioSeleccionoManifiestoDeCarga(object sender, CumplimientoDeEntregaArgumento e)
        {
            try
            {
                _vista.TareasCumplimientodeEntregas = CumplimientoDeEntregaServicio.ObtenerTrackingManifiesto(e);
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(exception.Message);
            }
        }

        private void _vista_UsuarioDeseaConsultarCumplimientoDeEntrega(object sender, CumplimientoDeEntregaArgumento e)
        {
            try
            {
                _vista.CumplimientoDeEntregas = CumplimientoDeEntregaServicio.ObtenerCumplimientoDeEntregas(e);
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(exception.Message);
            }
        }

        private void _vista_UsuarioDeseaObtenerVehiculos(object sender, EventArgs e)
        {
            try
            {
                _vista.Vehiculos = VehiculoServicio.ObtenerVehiculosConPilotosAsociados();
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(exception.Message);
            }
        }

        private void _vista_UsuarioDeseaObtenerPilotos(object sender, EventArgs e)
        {
            try
            {
                _vista.Pilotos = PilotoServicio.ObtenerPilotos(new PilotoArgumento {Piloto = new Piloto()});
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
                _vista_UsuarioDeseaObtenerVehiculos(sender,e);
                _vista_UsuarioDeseaObtenerPilotos(sender,e);
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(exception.Message);
            }
        }

        
    }
}