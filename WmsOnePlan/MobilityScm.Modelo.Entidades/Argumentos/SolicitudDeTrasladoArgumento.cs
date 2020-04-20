using System;
using System.Collections.Generic;
using MobilityScm.Modelo.Entidades;

namespace MobilityScm.Modelo.Argumentos
{
    public class SolicitudDeTrasladoArgumento : EventArgs
    {
        public SolicitudDeTrasladoEncabezado SolicitudDeTrasladoEncabezado { get; set; }

        public IList<SolicitudDeTrasladoDetalle> SolicitudDeTrasladoDetalles { get; set; }

        public SolicitudDeTrasladoDetalle SolicitudDeTrasladoDetalle { get; set; }

        public IList<Sku> ListadoMateriales { get; set; }

        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        public string CentroDeDistribucion { get; set; }
    }
}
