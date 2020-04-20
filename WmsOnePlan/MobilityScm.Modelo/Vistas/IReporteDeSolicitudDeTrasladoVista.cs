using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;

namespace MobilityScm.Modelo.Vistas
{
    public interface IReporteDeSolicitudDeTrasladoVista : IVistaBase
    {
        event EventHandler<ReporteDeSolicitudDeTrasladoArgumento> UsuarioDeseaObtenerSolicitudesDeTrasladoPorBodegaEstadoYFecha;
        event EventHandler<ReporteDeSolicitudDeTrasladoArgumento> UsuarioDeseaSeleccionoSolicitudDeTraslado;
        event EventHandler<ReporteDeSolicitudDeTrasladoArgumento> UsuarioDeseaCerrarSolicitudesDeTraslado;
        event EventHandler<ReporteDeSolicitudDeTrasladoArgumento> UsuarioSeleccionoCentrosDeDistribucion;

        IList<Entidades.Configuracion> CentrosDeDistribucion { get; set; }
        IList<Bodega> Bodegas { get; set; }
        IList<SolicitudDeTrasladoEncabezado> SolicitudesDeTraslado { get; set; }
        IList<TrazabilidadDeSolicitudDeTraslado> TrazabilidadDeSolicitudesDeTraslado { get; set; }
        IList<Seguridad> ListaDeSeguridad { get; set; }
    }
}
