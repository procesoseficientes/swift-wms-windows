using System;

namespace MobilityScm.Modelo.Entidades
{
    [Serializable]
    public class Ubicacion
    {
        public string WAREHOUSE_PARENT { get; set; }

        public string ZONE { get; set; }

        public string LOCATION_SPOT { get; set; }

        public string SPOT_TYPE { get; set; }

        public decimal SPOT_ORDERBY { get; set; }

        public decimal SPOT_AISLE { get; set; }

        public string SPOT_COLUMN { get; set; }

        public string SPOT_LEVEL { get; set; }

        public string SPOT_PARTITION { get; set; }

        public string SPOT_LABEL { get; set; }

        public int? ALLOW_PICKING { get; set; }

        public int ALLOW_STORAGE { get; set; }

        public int? ALLOW_REALLOC { get; set; }

        public string AVAILABLE { get; set; }

        public string LINE_ID { get; set; }

        public string SPOT_LINE { get; set; }

        public int? LOCATION_OVERLOADED { get; set; }

        public int? MAX_MT2_OCCUPANCY { get; set; }

        public bool IS_SELECTED { get; set; }

        public string DISTRIBUTION_CENTER_ID { get; set; }
        public decimal MAX_WEIGHT { get; set; }
        public decimal REAL_WEIGHT { get; set; }
        public decimal WEIGHT_PERCENT { get; set; }
        public string IS_OVERWEIGHT { get; set; }
        public decimal MT2_OCCUPANCY { get; set; }
    }
}
