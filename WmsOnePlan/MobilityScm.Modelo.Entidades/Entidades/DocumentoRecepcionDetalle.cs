using System;

namespace MobilityScm.Modelo.Entidades
{
    [Serializable]
    public class DocumentoRecepcionDetalle
    {
        public int ERP_RECEPTION_DOCUMENT_DETAIL_ID { get; set; }

        public int? ERP_RECEPTION_DOCUMENT_HEADER_ID { get; set; }

        public string MATERIAL_ID { get; set; }

        public decimal? QTY { get; set; }

        public int LINE_NUM { get; set; }

        public int ERP_OBJECT_TYPE { get; set; }

        public string DET_CURRENCY { get; set; }
        public double? DET_RATE { get; set; }
        public string DET_TAX_CODE { get; set; }
        public double? DET_VAT_PERCENT { get; set; }
        public double? PRICE { get; set; }
        public double? DISCOUNT_PERCENT { get; set; }
        public string WAREHOUSE_CODE { get; set; }
        public string COST_CENTER { get; set; }
        public string UNIT { get; set; }
        public string UNIT_DESCRIPTION { get; set; }
    }
}
