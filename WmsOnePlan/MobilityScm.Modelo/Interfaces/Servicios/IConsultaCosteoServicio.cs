using System.Collections.Generic;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Vertical.Entidades;

namespace MobilityScm.Modelo.Interfaces.Servicios
{
    public interface IConsultaCosteoServicio
    {
        Operacion AutorizarCosteoPoliza(CosteoArgumento costeoArgumento);

        IList<PolizaMaestroDetalle> ObtenerPolizasMaestroDetallePendientesDeAutorizar(CosteoArgumento costeoArgumento);
    }
}
