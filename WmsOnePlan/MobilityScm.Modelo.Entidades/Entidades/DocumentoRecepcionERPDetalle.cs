using System;
using System.Reflection.Emit;

namespace MobilityScm.Modelo.Entidades
{
    [Serializable]
    public class DocumentoRecepcionErpDetalle
    {
        public string SAP_RECEPTION_ID { get; set; }
        public string ERP_DOC { get; set; }
        public string PROVIDER_ID { get; set; }
        public string PROVIDER_NAME { get; set; }
        public string SKU { get; set; }
        public string SKU_DESCRIPTION { get; set; }
        public decimal? QTY { get; set; }
        public int LINE_NUM { get; set; }
        public string COMMENTS { get; set; }
        public string BARCODE_ID { get; set; }
        public string ALTERNATE_BARCODE { get; set; }
        public int EXTERNAL_SOURCE_ID { get; set; }
        public string SOURCE_NAME { get; set; }

        public string LOGIN_ID { get; set; }
        public string LOCATION_SPOT { get; set; }
        public string TYPE_RECEPCTION { get; set; }
        public string TYPE_RECEPCTION_DRESCRIPTION { get; set; }
        public int? PRIORITY { get; set; }
        public string PRIORITY_DESCRIPTION { get; set; }
        public int? TRADE_AGREEMENT_ID { get; set; }
        public string TRADE_AGREEMENT_DESCRIPTION { get; set; }
        public string CLIENT_CODE { get; set; }
        public string INSURANCE_DOC_ID { get; set; }
        public string INSURANCE_DOC_DESCRIPTION { get; set; }

        public int? DETAIL_COUNT { get; set; }

        public int? IS_ASSIGNED { get; set; }

        public int? OBJECT_TYPE { get; set; }

        public int? TOTAL_QUANTITY { get; set; }

        public int? OPEN_QUANTITY { get; set; }

        public int? IS_MISSING { get; set; }

        public int? RECEPTION_QUANTITY { get; set; }

        public string MASTER_ID_SKU { get; set; }
        public string OWNER_SKU { get; set; }
        public string OWNER { get; set; }

        public int? IS_VOID { get; set; }

        public string SOURCE { get; set; }

        public string ERP_WAREHOUSE_CODE { get; set; }

        public string DOC_ENTRY { get; set; }

        public string MATERIAL_OWNER { get; set; }

        public string ADDRESS { get; set; }
        public string DOC_CURRENCY { get; set; }
        public double? DOC_RATE { get; set; }
        public string SUBSIDIARY { get; set; }
        
        public string DET_CURRENCY { get; set; }
        public double? DET_RATE { get; set; }
        public string DET_TAX_CODE { get; set; }
        public double? DET_VAT_PERCENT { get; set; }
        public double? PRICE { get; set; }
        public double? DISCOUNT_PERCENT { get; set; }

        public string COST_CENTER { get; set; }

        public string UNIT { get; set; }
        public string UNIT_DESCRIPTION { get; set; }
    }
}
                                                                                