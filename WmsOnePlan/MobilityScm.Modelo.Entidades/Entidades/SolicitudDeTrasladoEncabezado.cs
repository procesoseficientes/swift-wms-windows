using System;

namespace MobilityScm.Modelo.Entidades
{
    [Serializable]
    public class SolicitudDeTrasladoEncabezado
    {
        public int TRANSFER_REQUEST_ID { get; set; }

        public string REQUEST_TYPE { get; set; }

        public string REQUEST_TYPE_DESCRIPTION { get; set; }

        public string WAREHOUSE_FROM { get; set; }

        public string WAREHOUSE_TO { get; set; }

        public DateTime REQUEST_DATE { get; set; }

        public DateTime? DELIVERY_DATE { get; set; }

        public string COMMENT { get; set; }

        public string STATUS { get; set; }

        public string STATUS_DESCRIPTION { get; set; }

        public string CREATED_BY { get; set; }

        public DateTime LAST_UPDATE { get; set; }

        public string LAST_UPDATE_BY { get; set; }

        public string DISTRIBUTION_CENTER_FROM { get; set; }

        public string DISTRIBUTION_CENTER_TO { get; set; }

        public string OWNER { get; set; }

        public bool IS_SELECTED { get; set; }
        public string DISTRIBUTION_CENTER_NAME { get; set; }
        public string DISTRIBUTION_CENTER_ID { get; set; }
        public DateTime? RECEPTION_DATE { get; set; }
        public string MATERIAL_ID { get; set; }
        public string MATERIAL_NAME { get; set; }
        public decimal QTY { get; set; }
        public decimal PROCESSED_QTY { get; set; }
        public decimal PENDING_QTY { get; set; }
        public int DOC_NUM { get; set; }
        public int IS_FROM_ERP { get; set; }
        public int DOC_ENTRY { get; set; }
    }
}
