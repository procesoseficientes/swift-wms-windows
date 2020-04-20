using System.Collections.Generic;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Vertical.Entidades;

namespace MobilityScm.Modelo.Interfaces.Servicios
{
    public interface IInventarioComprometidoServicio
    {

        IList<InventarioComprometidoEncabezado> ObtenerEncabezadosParaReporteDeInventarioComprometido(
            InventarioComprometidoArgumento inventarioComprometidoArgumento);

        IList<InventarioComprometidoDetalle> ObtenerDetallesParaReporteDeInventarioComprometido(
            InventarioComprometidoArgumento inventarioComprometidoArgumento);

        Operacion CancelarOrdenPreparada(InventarioComprometidoArgumento inventarioComprometidoArgumento);
    }
}