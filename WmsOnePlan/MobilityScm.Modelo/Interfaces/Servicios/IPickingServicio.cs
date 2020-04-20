using System.Collections.Generic;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Vertical.Entidades;

namespace MobilityScm.Modelo.Interfaces.Servicios
{
    public interface IPickingServicio
    {
        Operacion CrearPickingDeOrdenDeVenta(ref PickingArgumento argumento);

        Operacion CrearDemandaDespachoEncabezado(DemandaDespachoHeader encabezado);
        Operacion CrearDemandaDespachoDetalle(IList<DemandaDespachoDetalle> detalle, IList<Picking> pickings);

        IList<Picking> ConsultarPickingEncabezadosFinalizados(ManifiestoArgumento consulta);
        IList<PickingDetalle> ObtenerPickingDetalle(string encabezados);
        IList<ReportePicking> ObtenerReportePicking(PickingArgumento argumento);
        IList<InventarioParaPickingPorEstado> ObtenerInvnentarioPraPickingPorEstado(PickingArgumento argumento);
    }
}
