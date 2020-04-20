using MobilityScm.Modelo.Entidades;
using System.Collections.Generic;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Tipos;
using MobilityScm.Vertical.Entidades;

namespace MobilityScm.Modelo.Interfaces.Servicios
{
    public interface IDemandaDeDespachoServicio
    {
        Operacion AjustarInventarioDeOrdenDeVenta(ref List<OrdenDeVentaEncabezado> ordenDeVentaEncabezados,
            ref List<OrdenDeVentaDetalle> ordenDeVentaDetalles, IList<Sku> skus, ref List<MaterialConTonoYCalibre> listaDeMaterialesConTonoOCalibre, TipoDeInventario tipoInventario, bool despachoConEstadoDeMaterial);

        IList<VehiculoManifiesto> ProcesarDemandaParaVehiculos(ref PickingArgumento argumento);
        IList<VehiculoManifiesto> AjustarPrioridadVehiculos(PickingArgumento argumento);

        IList<PedidosPorVendedor> ConsultaReportePedidoPorVendedor(ConsultaArgumento argumento);

        IList<ReportePedidosPorVendedor> GenerarReportePedidosPorVendedor(ConsultaArgumento argumento);

        IList<DemandaDespachoHeader> ObtnerDemandasEncabezadosParaPaseDeSalida(PaseDeSalidaArgumento argumento);

        IList<DemandaDespachoDetalle> ObtnerDemandasDetallesParaPaseDeSalida(PaseDeSalidaArgumento argumento);

        IList<OrdenDeVentaEncabezado> ObtenerOrdenesDeVentaPreparadaSonda(OrdenDeVentaArgumento ordenDeVentaArgumento);

        IList<OrdenDeVentaEncabezado> ObtenerOrdenesDeVentaPreparadaErp(OrdenDeVentaArgumento ordenDeVentaArgumento);

        IList<OrdenDeVentaEncabezado> ObtenerSolicitudTransferenciaPreparadaErp(OrdenDeVentaArgumento ordenDeVentaArgumento);

        IList<OrdenDeVentaEncabezado> ObtenerSolicitudTransferenciaPreparadaSwift(OrdenDeVentaArgumento ordenDeVentaArgumento);

        IList<OrdenDeVentaDetalle> ObtenerOrdenVentaDetalleDeOrdenesPreparadas(OrdenDeVentaArgumento argumento);

        IList<OlaDePickingDeDemandaDespacho> ObtenerOlasDePickingPorDemandaDeDespacho(OlaDePickingDeDemandaDespachoArgumento argumento);

    }
}
