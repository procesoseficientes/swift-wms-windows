using System;
using System.Collections.Generic;

namespace MobilityScm.Modelo.Entidades
{
    [Serializable]
    public class InventarioComprometidoEncabezado
    {
        public string DOC_NUM { get; set; }
        public DateTime DELIVERY_DATE { get; set; }
        public string CLIENT_CODE { get; set; }
        public string CLIENT_NAME { get; set; }
        public string IS_FROM_SONDA { get; set; }
        public string IS_FROM_ERP { get; set; }
        public int WAVE_PICKING_ID { get; set; }
        public string ERP_DOCUMENT { get; set; }
        public string STATUS { get; set; }
        public bool IS_SELECTED { get; set; }

        public string DEMAND_TYPE { get; set; }

        public string PROJECT { get; set; }

        public int PICKING_DEMAND_HEADER_ID { get; set; }
    }
}
