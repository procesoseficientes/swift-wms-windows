using System.Collections.Generic;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Vertical.Entidades;

namespace MobilityScm.Modelo.Interfaces.Servicios
{
    public interface ICosteoServicio
    {
        Operacion InsertarPolizaDetalle(CosteoArgumento costeoArgumento);

        Operacion ActualizarPolizaDetalle(CosteoArgumento costeoArgumento);

        Operacion GrabarPolizaDetalle(CosteoArgumento costeoArgumento);

        IList<Poliza> ObtenerPolizasEncabezadosPendientesDeAutorizar(CosteoArgumento costeoArgumento);

        IList<PolizaDetalle> ObtenerPolizasDetallePendientesDeAutorizar(CosteoArgumento costeoArgumento);
        Operacion ActualizarPolizaEncabezado(CosteoArgumento costeoArgumento);
    }
}
