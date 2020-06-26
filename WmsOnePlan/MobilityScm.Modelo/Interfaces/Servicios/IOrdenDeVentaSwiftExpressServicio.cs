using System.Collections.Generic;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Vertical.Entidades;

namespace MobilityScm.Modelo.Interfaces.Servicios
{
    public interface IOrdenDeVentaSwiftExpressServicio
    {
        IList<OrdenDeVentaEncabezado> ObtenerOrdenesDeVentaPorFecha(OrdenDeVentaArgumento ordenDeVentaArgumento);

        IList<OrdenDeVentaEncabezado> ObtenerOrdenesDeEntregaPorFecha(OrdenDeVentaArgumento ordenDeVentaArgumento);

        IList<Sku> ValidarInventarioParaOrdenDeVenta(SkuArgumento skuArgumento);

        IList<OrdenDeVentaDetalle> ObtenerOrdenVentaDetalle(OrdenDeVentaEncabezado encabezado);

        Operacion MarcarOrdenDeVentaConPicking(OrdenDeVentaEncabezado ordenDeVenta);

        IList<OrdenDeVentaPendiente> ObtenerOrdenVentaPendientes(OrdenDeVentaArgumento ordenDeVentaArgumento);

        IList<OrdenDeVentaDetalle> ObtenerOrdenVentaDetalleDeOrdenes(OrdenDeVentaArgumento ordenDeVentaArgumento);

        IList<OrdenDeVentaDetalle> ObtenerOrdenVentaDetalleConsolidadoDeOrdenes(OrdenDeVentaArgumento ordenDeVentaArgumento);
        IList<OrdenDeVentaReporte> ObtenerOrdenesParaReporteDeTrazabilidad(OrdenDeVentaArgumento arg);


    }
}
