using System.Collections.Generic;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Vertical.Entidades;

namespace MobilityScm.Modelo.Interfaces.Servicios
{
    public interface IInventarioServicio
    {
        IList<Inventario> ObtenerInventario(InventarioArgumento inventarioArgumento);

        Operacion ActualizarEstadoDelMaterialPorLicencia(InventarioArgumento inventarioArgumento);

        IList<ReporteDeInventarioDiario> ObtenerReporteDiarioDeInventario(ConsultaArgumento argumento);

        IList<InventarioInactivo> ObtenerInventarioInactivo(InventarioInactivoArgumento arg);

        IList<SugeridoCompra> ObtenerSugeridoCompra(SugeridoCompraArgumento arg);
    }
}
