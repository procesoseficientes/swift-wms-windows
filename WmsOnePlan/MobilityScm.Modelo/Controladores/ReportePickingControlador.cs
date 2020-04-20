using MobilityScm.Modelo.Interfaces.Controladores;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Modelo.Vistas;
using MobilityScm.Vertical.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobilityScm.Modelo.Controladores
{
    public class ReportePickingControlador : IReportePickingControlador
    {
        private readonly IReportePickingVista _vista;
        public IInteraccionConUsuarioServicio InteraccionConUsuarioServicio { get; set; }

        public IPickingServicio PickingServicio { get; set; }

        public ReportePickingControlador(IReportePickingVista vista)
        {
            _vista = vista;
            SuscribirEventos();
        }
        private void SuscribirEventos()
        {
            _vista.VistaCargandosePorPrimeraVez += _vista_VistaCargandosePorPrimeraVez;
            _vista.UsuarioDeseaRefrescarReporte += _vista_UsuarioDeseaRefrescarReporte;
    }

        private void _vista_UsuarioDeseaRefrescarReporte(object sender, EventArgs e)
        {
            try
            {
                ObtenerReportePicking();
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
                ObtenerReportePicking();   
            }catch(Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        void ObtenerReportePicking()
        {
            _vista.DetalleReportePicking = PickingServicio.ObtenerReportePicking(new Argumentos.PickingArgumento { FechaInicial = _vista.FechaInicial, FechaFinal = _vista.FechaFinal });
        }
    }
}
