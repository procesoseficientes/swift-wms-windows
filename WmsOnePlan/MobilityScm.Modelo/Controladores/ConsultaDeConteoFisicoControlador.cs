using System;
using MobilityScm.Modelo.Interfaces.Controladores;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Modelo.Vistas;
using MobilityScm.Vertical.Servicios;

namespace MobilityScm.Modelo.Controladores
{
    public class ConsultaDeConteoFisicoControlador : IConsultaDeConteoFisicoControlador
    {
        private readonly IConsultaDeConteoFisicoVista _vista;

        public IConteoFisicoServicio ConteoFisicoServicio { get; set; }
        public IBodegaServicio BodegaServicio { get; set; }
        public IInteraccionConUsuarioServicio InteraccionConUsuarioServicio { get; set; }
        public IUsuarioServicio UsuarioServicio { get; set; }
        public IConfiguracionServicio ConfiguracionServicio { get; set; }

        public ConsultaDeConteoFisicoControlador(IConsultaDeConteoFisicoVista vista)
        {
            _vista = vista;
            SuscribirEventos();
        }

        private void SuscribirEventos()
        {
            _vista.UsuarioDeseaObtenerBodegas += _vista_UsuarioDeseaObtenerBodegas;
            _vista.UsuarioDeseaObtenerConteosFisicos += _vista_UsuarioDeseaObtenerConteosFisicos;
            _vista.UsuarioDeseaObtenerUsuarios += _vista_UsuarioDeseaObtenerUsuarios;
            _vista.VistaCargandosePorPrimeraVez += _vista_VistaCargandosePorPrimeraVez;

        }

        private void _vista_VistaCargandosePorPrimeraVez(object sender, EventArgs e)
        {
            try
            {
                this._vista_UsuarioDeseaObtenerBodegas(sender, e);
                this._vista_UsuarioDeseaObtenerUsuarios(sender, e);
                _vista.Usuario = InteraccionConUsuarioServicio.ObtenerUsuario();
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaObtenerUsuarios(object sender, EventArgs e)
        {
            try
            {
                _vista.Usuarios = UsuarioServicio.ObtenerUsuariosTipoBodegaAsignadosCD(InteraccionConUsuarioServicio.ObtenerCentroDistribucion());
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaObtenerConteosFisicos(object sender, Argumentos.ConteoFisicoArgumento e)
        {
            try
            {
                _vista.ConteosFisicos = ConteoFisicoServicio.ConsultarConsConteosFisicos(e);
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaObtenerBodegas(object sender, EventArgs e)
        {
            try
            {
                _vista.Bodegas = BodegaServicio.ObtenerBodegaAsignadaAUsuario(InteraccionConUsuarioServicio.ObtenerUsuario());
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }
    }
}
