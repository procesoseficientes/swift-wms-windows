using System.Collections.Generic;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;

namespace MobilityScm.Modelo.Interfaces.Servicios
{
    public interface ICumplimientoDeEntregaServicio
    {
        IList<CumplimientoDeEntrega> ObtenerCumplimientoDeEntregas(CumplimientoDeEntregaArgumento cumplimientoDeEntregaArgumento);

        IList<TareaDeCumplimientoDeEntrega> ObtenerTrackingManifiesto(CumplimientoDeEntregaArgumento argumento);

        IList<CumplimientoDeEntrega> ObtenerImagenesDeLaEntrega(CumplimientoDeEntregaArgumento argumento);
    }
}