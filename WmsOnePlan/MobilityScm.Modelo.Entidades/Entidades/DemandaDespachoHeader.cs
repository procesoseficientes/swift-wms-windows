using System;
using System.Collections.Generic;

namespace MobilityScm.Modelo.Entidades
{
    /// <summary>
    /// Demanda de despacho
    /// </summary>
    [Serializable]
    public class DemandaDespachoHeader
    {
        public int PICKING_DEMAND_HEADER_ID { get; set; }

        public string DOC_NUM { get; set; }

        public string CLIENT_CODE { get; set; }
        public string CUSTOMER_NAME { get; set; }

        public string CODE_ROUTE { get; set; }

        public string CODE_SELLER { get; set; }

        public decimal? TOTAL_AMOUNT { get; set; }

        public string SERIAL_NUMBER { get; set; }

        public string DOC_NUM_SEQUENCE { get; set; }

        public int EXTERNAL_SOURCE_ID { get; set; }

        public int IS_FROM_ERP { get; set; }

        public int IS_FROM_SONDA { get; set; }

        public DateTime LAST_UPDATE { get; set; }

        public string LAST_UPDATE_BY { get; set; }

        public int IS_COMPLETED { get; set; }

        public int WAVE_PICKING_ID { get; set; }

        public string CODE_WAREHOUSE { get; set; }

        public string DOC_ENTRY { get; set; }

        public int IS_CONSOLIDATED { get; set; }
        public int PRIORITY { get; set; }

        public string CLIENT_OWNER { get; set; }
        public string MASTER_ID_SELLER { get; set; }
        public string SELLER_OWNER { get; set; }
        public string OWNER { get; set; }
        public string SOURCE_TYPE { get; set; }
        public string DEMAND_TYPE { get; set; }
        public string WAREHOUSE_FROM { get; set; }
        public string WAREHOUSE_TO { get; set; }
        public DateTime DELIVERY_DATE { get;set;}
        public string ADDRESS_CUSTOMER { get; set; }
        public int STATE_CODE { get; set; }
        public decimal DISCOUNT { get; set; }
        public string CLIENT_NAME { get; set; }
        public int TYPE_DEMAND_CODE { get; set; }
        public string TYPE_DEMAND_NAME { get; set; }
        public DateTime CREATED_DATE { get; set; }
        public string ERP_REFERENCE { get; set; }
        public bool IS_SELECTED { get; set; }
    }
}
