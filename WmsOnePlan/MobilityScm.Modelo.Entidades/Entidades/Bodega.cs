using System;
using MobilityScm.Modelo.Estados;

namespace MobilityScm.Modelo.Entidades
{
    public class Bodega
    {
        public string WAREHOUSE_ID { get; set; }

        public string NAME { get; set; }

        public string COMMENTS { get; set; }

        public string ERP_WAREHOUSE { get; set; }

        public decimal? ALLOW_PICKING { get; set; }

        public string DEFAULT_RECEPTION_LOCATION { get; set; }

        public string SHUNT_NAME { get; set; }

        public string WAREHOUSE_WEATHER { get; set; }

        public int? WAREHOUSE_STATUS { get; set; }

        public int? IS_3PL_WAREHUESE { get; set; }

        public string WAHREHOUSE_ADDRESS { get; set; }

        public string GPS_URL { get; set; }

        public string DISTRIBUTION_CENTER_ID { get; set; }

        public string ASSIGNED_TO { get; set; }

        public bool IS_SELECTED { get; set; }

        public string LOGIN { get; set; }

        public int IS_WAREHOUSE_FROM { get; set; }

        public int USE_PICKING_LINE { get; set; }
    }
}
