using System;
using System.Collections.Generic;

namespace MobilityScm.Modelo.Entidades
{
    [Serializable]
    public class DocumentoRecepcion
    {
        public int ERP_RECEPTION_DOCUMENT_HEADER_ID { get; set; }

        public string DOC_ID { get; set; }

        public string TYPE { get; set; }

        public string CODE_SUPPLIER { get; set; }

        public string CODE_CLIENT { get; set; }

        public DateTime? ERP_DATE { get; set; }

        public DateTime? LAST_UPDATE { get; set; }

        public string LAST_UPDATE_BY { get; set; }

        public int? ATTEMPTED_WITH_ERROR { get; set; }

        public int? IS_POSTED_ERP { get; set; }

        public DateTime? POSTED_ERP { get; set; }

        public string POSTED_RESPONSE { get; set; }

        public string ERP_REFERENCE { get; set; }

        public int? IS_AUTHORIZED { get; set; }

        public int? IS_COMPLETE { get; set; }

        public decimal? TASK_ID { get; set; }

        public int? EXTERNAL_SOURCE_ID { get; set; }

        public IList<DocumentoRecepcionDetalle> DocumentoRecepcionErpDetalles { get; set; }

        public string TRADE_AGREEMENT { get; set; }

        public string INSURANCE_POLICY { get; set; }

        public string TYPE_RECEPTION { get; set; }
        public string TASK_ASSIGNEDTO { get; set; }
        public string REGIMEN { get; set; }

        public string CLIENT_NAME { get; set; }

        public string PRIORITY { get; set; }

        public string LOCATION_SPOT_TARGET { get; set; }

        public string DOC_NUM { get; set; }

        public string NAME_SUPPLIER { get; set; }

        public string OWNER { get; set; }

        public string SOURCE { get; set; }

        public string ERP_WAREHOUSE_CODE { get; set; }

        public int DOC_ID_POLIZA { get; set; }

        public string DOC_ENTRY { get; set; }


        public string ADDRESS { get; set; }
        public string DOC_CURRENCY { get; set; }
        public double? DOC_RATE { get; set; }
        public string SUBSIDIARY { get; set; }

        public string DET_CURRENCY { get; set; }
        public double? DET_RATE { get; set; }
        public string DET_TAX_CODE { get; set; }
        public double? DET_VAT_PERCENT { get; set; }
        public string COST_CENTER { get; set; }
    }
}
