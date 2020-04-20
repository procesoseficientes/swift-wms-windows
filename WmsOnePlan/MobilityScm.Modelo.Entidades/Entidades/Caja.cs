using System;

namespace MobilityScm.Modelo.Entidades
{
    [Serializable]
    public class Caja
    {
        public string WAVE_PICKING_ID { get; set; }

        public string BOX_ID { get; set; }

        public string MATERIAL_ID { get; set; }

        public string MATERIAL_NAME { get; set; }

        public decimal QUANTITY { get; set; }

        public DateTime PICKED_DATETIME { get; set; }

        public string STATUS { get; set; }

        public string STATUS_DESCRIPTION { get; set; }

        public string LOGIN_ID { get; set; }

        public string LOCATION_SPOT { get; set; }

        public int BOX_ASSIGNED { get; set; }

        public string BOX_ASSIGNED_DESCRIPTION { get; set; }

        public int BOX_NUMBER { get; set; }

        public int TOTAL_BOXES { get; set; }

        public string GATE { get; set; }

        public string CLIENT_ID { get; set; }

        public string CLIENT_NAME { get; set; }

        public string CLIENT_ROUTE { get; set; }

        public string ERP_REFERENCE { get; set; }

        public string DISTRIBUTION_CENTER { get; set; }

        public string PLATE_NUMBER { get; set; }

        public string PILOT_FULL_NAME { get; set; }

        public int MANIFEST_HEADER_ID { get; set; }

        public string SOURCE_TYPE { get; set; }

        public string SALE_ORDER { get; set; }

        public string ERP_DOC { get; set; }

        public int WAS_IMPLODED { get; set; }
        public decimal QUANTITY_ORIGINAL { get; set; }
        public bool MODIFIED { get; set; }
        public string PICKING_LINE { get; set; }
    }
}