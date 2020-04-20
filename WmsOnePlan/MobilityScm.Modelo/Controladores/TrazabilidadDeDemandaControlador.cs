using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Modelo.Vistas;
using MobilityScm.Vertical.Servicios;

namespace MobilityScm.Modelo.Controladores
{
    public class TrazabilidadDeDemandaControlador : ITrazabilidadDeDemandaControlador
    {
        private readonly ITrazabilidadDeDemandaVista _vista;

        public IOrdenDeVentaERPServicio OrdenDeVentaErpServicio { get; set; }
        public IOrdenDeVentaSwiftExpressServicio OrdenDeVentaSwiftExpressServicio { get; set; }
        public IBodegaServicio BodegaServicio { get; set; }
        public IInteraccionConUsuarioServicio InteraccionConUsuarioServicio { get; set; }                                    

        public TrazabilidadDeDemandaControlador(ITrazabilidadDeDemandaVista vista)
        {
            _vista = vista;
            SuscribirEventos();
        }

        private void SuscribirEventos()
        {
            _vista.VistaCargandosePorPrimeraVez += _vista_VistaCargandosePorPrimeraVez;
            _vista.UsuarioDeseaObtenerReporte += _vista_UsuarioDeseaObtenerReporte;
        }

        private void _vista_UsuarioDeseaObtenerReporte(object sender, Argumentos.OrdenDeVentaArgumento e)
        {
            try
            {
                _vista.OrdenesDeVenta = e.EsDeErp
                    ? OrdenDeVentaErpServicio.ObtenerOrdenesParaReporteDeTrazabilidad(e)
                    : OrdenDeVentaSwiftExpressServicio.ObtenerOrdenesParaReporteDeTrazabilidad(e);
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
                _vista.Bodegas = BodegaServicio.ObtenerBodegaAsignadaAUsuario(InteraccionConUsuarioServicio.ObtenerUsuario());
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }
    }
}
