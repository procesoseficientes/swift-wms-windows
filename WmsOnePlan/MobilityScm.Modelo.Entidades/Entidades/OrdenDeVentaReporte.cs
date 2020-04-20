using System;

namespace MobilityScm.Modelo.Entidades
{
    [Serializable]
    public class OrdenDeVentaReporte
    {
        public string SOURCE { get; set; }
        public string SALES_ORDER_ID { get; set; }
        public DateTime POSTED_DATETIME { get; set; }
        public DateTime DELIVERY_DATE { get; set; }
        public int QTY_WAVE_PICKING { get; set; }
        public string CLIENT_CODE { get; set; }
        public string CLIENT_NAME { get; set; }
        public string CODE_SELLER { get; set; }
        public string SELLER_NAME { get; set; }
        public string STATE_CODE { get; set; }
        public string SKU { get; set; }
        public string DESCRIPTION_SKU { get; set; }
        public int LINE_SEQ { get; set; }
        public int IS_MASTER_PACK { get; set; }
        public string IS_MASTER_PACK_DESCRIPTION { get; set; }
        public int? WAVE_PICKING_ID { get; set; }
        public decimal QTY { get; set; }
        public decimal QTY_PENDING { get; set; }
        public decimal QTY_SWIFT { get; set; }
        public decimal OPEN_QTY { get; set; }
        public string DOC_STATUS { get; set; }
        public string DOC_STATUS_DESCRIPTION { get; set; }
        public int? IS_POSTED_ERP { get; set; }
        public string IS_POSTED_ERP_DESCRIPTION { get; set; }
        public string ERP_REFERENCE { get; set; }
        public string CANCELED { get; set; }
        public decimal WEIGHT { get; set; }
        public decimal WEIGHT_SALE_ORDER { get; set; }
        public decimal WEIGHT_SWIFT { get; set; }
        public int? MANIFEST_HEADER_ID { get; set; }
        public int DRIVER { get; set; }
        public int VEHICLE { get; set; }
        public string POSTED_RESPONSE { get; set; }

        public int MATERIAL_IN_SWIFT { get; set; }

        public int USE_PICKING_LINE { get; set; }

        public int IS_BONUS { get; set; }

        public string TYPE_DEMAND_NAME { get; set; }

        public string ADRESS_CUSTOMER { get; set; }

    }
}
