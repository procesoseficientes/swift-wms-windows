using System.Collections.Generic;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;

namespace MobilityScm.Modelo.Interfaces.Servicios
{
    public interface IRutasSwiftExpressServicio
    {
        IList<Ruta> ObtenerRutas();
        IList<Ruta> ObtenerTodasRutas();
        IList<Ruta> ObtenerTodasRutasAsociadasABodega(string bodegas);
        IList<Ruta> ObtenerRutasPorPoligonosPorFecha(OrdenDeVentaArgumento argumento);
    }
}
