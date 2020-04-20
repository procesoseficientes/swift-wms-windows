using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobilityScm.Modelo.Entidades
{
    [Serializable]
    public class OrdenDeCompraDetalle
    {
        public int ERP_RECEPTION_DOCUMENT_DETAIL_ID { get; set; }
		public int ERP_RECEPTION_DOCUMENT_HEADER_ID { get; set; }
        public string DOC_NUM { get; set; }
        public string MATERIAL_ID { get; set; }
        public string MATERIAL_NAME { get; set; }
        public decimal QTY { get; set; }
		public int LINE_NUM { get; set; }
		public int ERP_OBJECT_TYPE { get; set; }
		public int ATTEMPTED_WITH_ERROR { get; set; }
		public int IS_POSTED_ERP { get; set; }
		public DateTime POSTED_ERP { get; set; }
		public string POSTED_RESPONSE { get; set; }
		public string ERP_REFERENCE { get; set; }
		public string ERP_REFERENCE_DOC_NUM { get; set; }
		public string WAREHOUSE_CODE { get; set; }
		public string CURRENCY { get; set; }
		public decimal RATE { get; set; }
		public string TAX_CODE { get; set; }
		public decimal VAT_PERCENT { get; set; }
		public decimal PRICE { get; set; }
		public decimal DISCOUNT { get; set; }
		public string COST_CENTER { get; set; }
		public int QTY_ASSIGNED { get; set; }
		public string UNIT { get; set; }
		public string UNIT_DESCRIPTION { get; set; }

        public int QTY_FACTOR { get; set; }

        public decimal PENDING { get; set; }
        public decimal QTY_CONFIRMED { get; set; }
        public decimal QTY_CONFIRMED_READ_ONLY { get; set; }
        public string ERP_WAREHOUSE { get; set; }
        public bool ESTA_EN_MODO_EDICION { get; set; }

    }
}
