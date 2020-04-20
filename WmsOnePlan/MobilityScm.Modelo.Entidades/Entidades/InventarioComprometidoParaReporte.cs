using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobilityScm.Modelo.Entidades
{
    [Serializable]
    public class InventarioComprometidoParaReporte
    {
        public string DOC_NUM { get; set; }
        public string CLIENT_CODE { get; set; }
        public string CLIENT_NAME { get; set; }
        public int WAVE_PICKING_ID { get; set; }
        public string ERP_DOCUMENT { get; set; }
        public int? LABEL_ID { get; set; }
        public string LOCATION_SPOT { get; set; }
        public string MATERIAL_ID { get; set; }
        public string MATERIAL_NAME { get; set; }
        public decimal QTY { get; set; }
        public string DELIVERY_STATUS { get; set; }
        
    }
}
