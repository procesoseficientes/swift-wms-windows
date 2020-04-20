using System;

namespace MobilityScm.Modelo.Entidades
{
    public class OrdenDeVentaPendiente
    {
        public int DOC_NUM { get; set; }
        public DateTime POSTED_DATE { get; set; }
        public string CLIENT_CODE { get; set; }
        public string CLIENT_NAME { get; set; }
        public string MATERIAL_ID { get; set; }
        public string MATERIAL_NAME { get; set; }
        public int TOTAL_QUANTITY { get; set; }
        public int PROCESS_QUANTITY { get; set; }
        public int DIFERENCE { get; set; }
        public decimal PRICE { get; set; }
        public decimal TOTAL_LINE { get; set; }
        public decimal UNSOLD_PRICE { get; set; }
        public string ORIGIN { get; set; }
        public int LINE_SEQ { get; set; }
        public int EXTERNAL_SOURCE_ID { get; set; }
        public string SOURCE_NAME { get; set; }
        public string CODE_ROUTE { get; set; }
        public string SELLER { get; set; }

        public string  MATERIAL_IN_SWIFT { get; set; }
    }
}
