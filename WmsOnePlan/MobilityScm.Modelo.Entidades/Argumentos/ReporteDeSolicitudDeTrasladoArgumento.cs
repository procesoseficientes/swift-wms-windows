using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MobilityScm.Modelo.Entidades;

namespace MobilityScm.Modelo.Argumentos
{
    public class ReporteDeSolicitudDeTrasladoArgumento : ConsultaArgumento
    {
        public SolicitudDeTrasladoEncabezado SolicitudDeTrasladoEncabezado { get; set; }
        public string Estado { get; set; }
        public string IdsSolicitudesDeTraslado { get; set; }
        public string MaterialesSolicitudDeTraslado { get; set; }
        public int VieneDeErp { get; set; }
        public string ReferenciaErp { get; set; }
        public string Bodegas { get; set; }

        public string CentrosDeDistribucion { get; set; }
    }
}
