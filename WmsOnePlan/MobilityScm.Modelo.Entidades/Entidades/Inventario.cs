using System;

namespace MobilityScm.Modelo.Entidades
{
    [Serializable]
    public class Inventario
    {
        public string MATERIAL_ID { get; set; }
        public string MATERIAL_NAME { get; set; }
        public string CURRENT_WAREHOUSE { get; set; }
        public string CURRENT_LOCATION { get; set; }
        public string BATCH { get; set; }
        public DateTime? DATE_EXPIRATION { get; set; }
        public int LICENSE_ID { get; set; }
        public string CODE_SUPPLIER { get; set; }
        public string NAME_SUPPLIER { get; set; }
        public decimal QTY { get; set; }
        public decimal TOTAL_VALOR { get; set; }
        public string STATUS_NAME { get; set; }
        public string COLOR { get; set; }
        public string VIN { get; set; }
        public string TONE { get; set; }
        public string CALIBER { get; set; }
        public string STATUS_CODE { get; set; }

        public string STATUS_CODE_NEW { get; set; }

        public string STATUS_NAME_NEW { get; set; }

        public bool IS_SELECTD { get; set; }

        public string SERIAL { get; set; }
    }
}
