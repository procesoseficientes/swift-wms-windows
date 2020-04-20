using System;
using System.Collections.Generic;
using MobilityScm.Modelo.Entidades;

namespace MobilityScm.Modelo.Argumentos
{
    public class InventarioComprometidoArgumento : EventArgs
    {
        public IList<InventarioComprometidoEncabezado> InventarioComprometidoEncabezados { get; set; }

        public IList<InventarioComprometidoDetalle> InventarioComprometidoDetalles { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFinal { get; set; }

        public int PickingDemandHeaderId { get; set; }

        public string Usuario { get; set; }

    }
}
