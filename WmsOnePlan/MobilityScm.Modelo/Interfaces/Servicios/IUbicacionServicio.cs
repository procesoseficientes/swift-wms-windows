using MobilityScm.Modelo.Entidades;
using System.Collections.Generic;
using MobilityScm.Modelo.Argumentos;

namespace MobilityScm.Modelo.Interfaces.Servicios
{
    /// <summary>
    /// Interfaz servicio de ubicaciones
    /// </summary>
    public interface IUbicacionServicio
    {
        /// <summary>
        /// obtener ubicaciones y tipo rampa y puerta
        /// </summary>
        /// <returns></returns>
        IList<Ubicacion> ObtenerUbicacionesTipoRampaYPuertaParaRecepcion(string distributionCenterId);
        IList<Ubicacion> ObtenerUbicacionesTipoRampaYPuertaParaDespacho(string distribuitionCenterId);

        IList<Ubicacion> ObtenerUbicacionesPorZonaOBodega(ConteoFisicoArgumento arg);

        IList<ConteoFisicoDetalle> ObtenerUbicacionesPorFiltros(ConteoFisicoArgumento arg);

        /// <summary>
        /// Obtiene todoas las zonas por bodega
        /// </summary>
        /// <param name="arg"></param>
        /// <returns>Listado de Zonas</returns>
        IList<Zona> ObtenerZonasPorBodegas(InventarioInactivoArgumento arg);
    }
}
