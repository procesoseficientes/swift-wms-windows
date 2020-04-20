using System;

namespace MobilityScm.Modelo.Entidades
{
    [Serializable]
    public class DemandaDespachoDetalle
    {
        public int PICKING_DEMAND_DETAIL_ID { get; set; }

        public int PICKING_DEMAND_HEADER_ID { get; set; }

        public string MATERIAL_ID { get; set; }

        public int QTY { get; set; }

        public int LINE_NUM { get; set; }

        public int? ERP_OBJECT_TYPE { get; set; }

        public decimal PRICE { get; set; }

        public string MASTER_ID_MATERIAL { get; set; }
        public string MATERIAL_OWNER { get; set; }
        public string SOURCE_TYPE { get; set; }

        public string TONE { get; set; }

        public string CALIBER { get; set; }

        public decimal DISCOUNT { get; set; }
        public int IS_BONUS { get; set; }
        public string DISCOUNT_TYPE { get; set; }

        public string CLIENT_CODE { get; set; }
        public string CLIENT_NAME { get; set; }
        public DateTime CREATED_DATE { get; set; }
        public int WAVE_PICKING_ID { get; set; }
        public string DOC_NUM { get; set; }

        public int TYPE_DEMAND_CODE { get; set; }
        public string TYPE_DEMAND_NAME { get; set; }
        public string ERP_REFERENCE { get; set; }
        public bool IS_SELECTED { get; set; }
        public string MATERIAL_NAME { get; set; }

        public int QTY_AVAILABLE { get; set; }
        public int DOC_NUM_POLIZA { get; set; }
        public string CODIGO_POLIZA { get; set; }
        public string NUMERO_ORDEN_POLIZA { get; set; }
        public DateTime COMPLETED_DATE { get; set; }
        public string CODE_WAREHOUSE { get; set; }
    }

}
