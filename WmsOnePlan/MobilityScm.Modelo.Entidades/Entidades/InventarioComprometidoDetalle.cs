using System;
using System.Collections.Generic;

namespace MobilityScm.Modelo.Entidades
{
    [Serializable]
    public class InventarioComprometidoDetalle
    {
        public int? LABEL_ID { get; set; }
        public string LOCATION_SPOT { get; set; }
        public string MATERIAL_ID { get; set; }
        public string MATERIAL_NAME { get; set; }
        public string IS_MASTER_PACK { get; set; }
        public decimal QTY { get; set; }
        public string DELIVERY_STATUS { get; set; }
        public int WAVE_PICKING_ID { get; set; }
        public int LICENSE_ID_SOURCE { get; set; }
        public string LOCATION_SPOT_SOURCE { get; set; }
        public int LICENSE_ID_TARGET { get; set; }
        public string LOCATION_SPOT_TARGET { get; set; }
        public int PICKING_DEMAND_HEADER_ID { get; set; }
    }
}
