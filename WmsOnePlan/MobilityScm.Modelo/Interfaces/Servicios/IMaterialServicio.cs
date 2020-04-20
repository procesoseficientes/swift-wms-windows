using System.Collections.Generic;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;

namespace MobilityScm.Modelo.Interfaces.Servicios
{
    public interface IMaterialServicio
    {        
        IList<Sku> ObtenerMaterialesPorBodegaClienteUbicacionOZona(ConteoFisicoArgumento arg);

        IList<Material> ObtenerMaterialesPorBodegaYZona(InventarioInactivoArgumento arg);
    }
}
