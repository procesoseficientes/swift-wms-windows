using System.Collections.Generic;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Vertical.Entidades;

namespace MobilityScm.Modelo.Interfaces.Servicios
{
    public interface ISolicitudDeTrasladoServicio
    {
        Operacion AgregarSolicitudDeTrasladoEncabezado(SolicitudDeTrasladoArgumento solicitudDeTrasladoArgumento);
        Operacion ActualizarSolicitudDeTrasladoEncabezado(SolicitudDeTrasladoArgumento solicitudDeTrasladoArgumento);
        Operacion EliminarSolicitudDeTrasladoEncabezado(SolicitudDeTrasladoArgumento solicitudDeTrasladoArgumento);
        SolicitudDeTrasladoEncabezado ObtenerSolicitudDeTrasladoEncabezado(SolicitudDeTrasladoArgumento solicitudDeTrasladoArgumento);
        Operacion AgregarSolicitudDeTrasladoDetalle(SolicitudDeTrasladoArgumento solicitudDeTrasladoArgumento);
        Operacion ActualizarSolicitudDeTrasladoDetalle(SolicitudDeTrasladoArgumento solicitudDeTrasladoArgumento);
        Operacion EliminarSolicitudDeTrasladoDetalle(SolicitudDeTrasladoArgumento solicitudDeTrasladoArgumento);
        IList<SolicitudDeTrasladoDetalle> ObtenerSolicitudDeTrasladoDetalle(SolicitudDeTrasladoArgumento solicitudDeTrasladoArgumento);
        IList<OrdenDeVentaEncabezado> ObtenerSolicitudesDeTransferenciaPorFecha(OrdenDeVentaArgumento ordenDeVentaArgumento);
        IList<OrdenDeVentaDetalle> ObtenerDetalleDeSolicitudesDeTransferencia(OrdenDeVentaArgumento ordenDeVentaArgumento);
        IList<OrdenDeVentaEncabezado> ObtenerSolicitudesDeTransferenciaDeErpPorFecha(OrdenDeVentaArgumento ordenDeVentaArgumento);
        IList<OrdenDeVentaDetalle> ObtenerDetalleDeSolicitudesDeTransferenciaErp(OrdenDeVentaArgumento ordenDeVentaArgumento);


        IList<SolicitudDeTrasladoEncabezado> ObtenerSolicitudesDeTrasladoPorBodegaEstadoYFecha(ReporteDeSolicitudDeTrasladoArgumento reporteDeSolicitudDeTrasladoArgumento);
        IList<TrazabilidadDeSolicitudDeTraslado> ObtenerTrazabilidadDeSolicitudDeTraslado(ReporteDeSolicitudDeTrasladoArgumento reporteDeSolicitudDeTrasladoArgumento);
        Operacion CerrarSolicitudesDeTraslado(ReporteDeSolicitudDeTrasladoArgumento reporteDeSolicitudDeTrasladoArgumento);
    }
}
