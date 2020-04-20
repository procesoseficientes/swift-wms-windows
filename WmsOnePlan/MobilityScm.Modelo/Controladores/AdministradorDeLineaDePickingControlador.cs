using System;
using System.Collections.Generic;
using System.Linq;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Interfaces.Controladores;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Modelo.Tipos;
using MobilityScm.Modelo.Vistas;
using MobilityScm.Vertical.Servicios;

namespace MobilityScm.Modelo.Controladores
{
    public class AdministradorDeLineaDePickingControlador : IAdministradorDeLineaDePickingControlador
    {
        private readonly IAdministradorDeLineaDePickingVista _vista;

        public IInteraccionConUsuarioServicio InteraccionConUsuarioServicio { get; set; }

        public ILineaDePickingServicio LineaDePickingServicio { get; set; }

        public AdministradorDeLineaDePickingControlador(IAdministradorDeLineaDePickingVista vista)
        {
            _vista = vista;
            SuscribirEventos();
        }

        private void SuscribirEventos()
        {
            _vista.VistaCargandosePorPrimeraVez += _vista_VistaCargandosePorPrimeraVez;
            _vista.VistaTerminoDeCargar += _vista_VistaTerminoDeCargar;
            _vista.UsuarioDeseaConsultarCaja += _vista_UsuarioDeseaConsultarCaja;
            _vista.UsuarioDeseaActualizarCaja += _vista_UsuarioDeseaActualizarCaja;
        }

        private void _vista_UsuarioDeseaActualizarCaja(object sender, Argumentos.CajaArgumento e)
        {
            try
            {
                var operacion = LineaDePickingServicio.ModificarCaja(e);
                if (operacion.Resultado == ResultadoOperacionTipo.Exito)
                {
                    _vista.Cajas = new List<Caja>();
                    _vista.Cajas = LineaDePickingServicio.ObtenerCajaPorId(new ConsultaArgumento {IdParametro = e.Cajas.FirstOrDefault().BOX_ID });
                }
                else
                {
                    InteraccionConUsuarioServicio.MensajeErrorDialogo(operacion.Mensaje);
                }
                
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaConsultarCaja(object sender, Argumentos.ConsultaArgumento e)
        {
            try
            {
                _vista.Cajas = LineaDePickingServicio.ObtenerCajaPorId(e);
            }
            catch (Exception ex)
            {
                _vista.Cajas = new List<Caja>();
                InteraccionConUsuarioServicio.MensajeErrorDialogo(ex.Message);
            }
        }

        private void _vista_VistaTerminoDeCargar(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void _vista_VistaCargandosePorPrimeraVez(object sender, System.EventArgs e)
        {
            
        }
    }
}