using System.Collections.Generic;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Vertical.Entidades;

namespace MobilityScm.Modelo.Interfaces.Servicios
{
    public interface IMasterPackServicio
    {
        IList<MasterPackMaestroDetalle> ObtenerMaestroDetalleDeMasterPack(MasterPackArgumento masterPackArgumento);
        IList<MasterPackEncabezado> ObtenerMasterPacksPorFechaDeExplocion(MasterPackArgumento masterPackArgumento);
        IList<MasterPackDetalle> ObtenerDetallesDeMasterPacks(MasterPackArgumento masterPackArgumento);
        Operacion AutorizarMasterPackERP(MasterPackArgumento masterPackArgumento);
    }
}
