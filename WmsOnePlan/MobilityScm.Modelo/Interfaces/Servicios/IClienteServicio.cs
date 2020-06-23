using System.Collections.Generic;
using MobilityScm.Modelo.Argumentos;

namespace MobilityScm.Modelo.Interfaces.Servicios
{
    public interface IClienteServicio
    {
        IList<Cliente> ObtenerClientes();

        IList<Cliente> ObtenerClientesPorRegimen(ConteoFisicoArgumento conteoFisicoArgumento );

        IList<Cliente> ObtenerClientesErpPorCanalModerno(OrdenDeVentaArgumento argumento);

        IList<Cliente> ObtenerClientesErpCanalModernoParaOrdenesDeVentaPreparadas(OrdenDeVentaArgumento argumento);
        IList<Cliente> ObtenerClientesOrdeDeEntrega(OrdenDeVentaArgumento argumento);

        IList<Cliente> ObtenerClientesErp(OrdenDeVentaArgumento argumento);
    }
}
