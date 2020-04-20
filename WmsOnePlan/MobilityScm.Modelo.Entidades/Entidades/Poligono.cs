using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraMap;

namespace MobilityScm.Modelo.Entidades
{
    public class Poligono : MapPolygon
    {
        public int POLYGON_ID { get; set; }
        public string POLYGON_NAME { get; set; }
        public string POLYGON_DESCRIPTION { get; set; }
        public string COMMENT { get; set; }
        public bool IS_SELECTED { get; set; }
        public int EXTERNAL_SOURCE_ID { get; set; }
        public string SOURCE_NAME { get; set; }
        public IList<PuntoDePoligono> PuntosDePoligono { get; set; }
    }
}
