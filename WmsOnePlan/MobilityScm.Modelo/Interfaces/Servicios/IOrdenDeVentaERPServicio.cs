using System.Collections.Generic;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Vertical.Entidades;

namespace MobilityScm.Modelo.Interfaces.Servicios
{
    public interface IOrdenDeVentaERPServicio
    {
        IList<OrdenDeVentaEncabezado> ObtenerOrdenesDeVentaPorFecha(OrdenDeVentaArgumento ordenDeVentaArgumento);
        IList<OrdenDeVentaDetalle> ObtenerOrdenVentaDetalle(OrdenDeVentaArgumento argumento);
        IList<OrdenDeVentaPendiente> ObtenerOrdenVentaPendientes(OrdenDeVentaArgumento ordenDeVentaArgumento);
        IList<OrdenDeVentaDetalle> ObtenerOrdenVentaDetalleDeOrdenes(OrdenDeVentaArgumento argumento);
        IList<OrdenDeVentaDetalle> ObtenerOrdenDeEntregaDetalle(OrdenDeVentaArgumento argumento);
        IList<MaterialConTonoYCalibre> ObtenerTonosYCalibresDeMateriales(SkuArgumento skuArgumento);
        IList<OrdenDeVentaReporte> ObtenerOrdenesParaReporteDeTrazabilidad(OrdenDeVentaArgumento arg);
    }
}
