using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraMap;

namespace MobilityScm.Modelo.Entidades
{
    public class PuntoDePoligono
    {
        public int POLYGON_ID { get; set; }
        public int POSITION { get; set; }
        public string LATITUDE { get; set; }
        public string LONGITUDE { get; set; }
        public GeoPoint GeoPunto => new GeoPoint(double.Parse(LATITUDE), double.Parse(LONGITUDE));
    }
}
