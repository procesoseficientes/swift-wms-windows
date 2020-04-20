using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobilityScm.Modelo.Entidades
{
    [Serializable]
    public class PaseDeSalidaDetalle
    {
        public int PASS_DETAIL_ID { get; set; }

        public decimal PASS_HEADER_ID { get; set; }

        public string CLIENT_CODE { get; set; }

        public string CLIENT_NAME { get; set; }

        public int PICKING_DEMAND_HEADER_ID { get; set; }

        public string DOC_NUM { get; set; }

        public string MATERIAL_ID { get; set; }

        public string MATERIAL_NAME { get; set; }

        public int QTY { get; set; }

        public int DOC_NUM_POLIZA { get; set; }

        public string CODIGO_POLIZA { get; set; }

        public string NUMERO_ORDEN_POLIZA { get; set; }

        public int WAVE_PICKING_ID { get; set; }

        public DateTime CREATED_DATE { get; set; }

        public string CODE_WAREHOUSE { get; set; }
        public int TYPE_DEMAND_CODE { get; set; }
        public string TYPE_DEMAND_NAME { get; set; }

        public int LINE_NUM { get; set; }
    }
}
