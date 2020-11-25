using System;

namespace MobilityScm.Modelo.Entidades
{
    [Serializable]
    public class ConteoFisicoDetalle
    {
        public int PHYSICAL_COUNT_DETAIL_ID { get; set; }

        public int? PHYSICAL_COUNT_HEADER_ID { get; set; }
        public string WAREHOUSE_ID { get; set; }

        public string ZONE { get; set; }

        public string LOCATION_SPOT { get; set; }

        public string CLIENT_CODE { get; set; }

        public string MATERIAL_ID { get; set; }
        public int QTY_SCANNED { get; set; }
        public int QTY_EXPECTED { get; set; }
        public int DIFFERENCE { get; set; }

        public string ASSIGNED_TO { get; set; }

        public string STATUS { get; set; }

        public string CLIENT_NAME { get; set; }

        public  string MATERIAL_NAME { get; set; }

        public string CODE_WAREHOUSE { get; set; }
        public string REGIMEN { get; set; }

    }
}
