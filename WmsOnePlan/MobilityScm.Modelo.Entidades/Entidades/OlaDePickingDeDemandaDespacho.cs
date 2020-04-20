using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobilityScm.Modelo.Entidades
{
    [Serializable]
    public class OlaDePickingDeDemandaDespacho
    {
        public int WAVE_PICKING_ID { get; set; }
        public DateTime ASSIGNED_DATE { get; set; }
        public string STATUS_TASK { get; set; }
        public DateTime? COMPLETED_DATE { get; set; }
        public string TASK_OWNER { get; set; }
        public string DOC_NUM { get; set; }
        public string STATUS_POSTED_ERP { get; set; }
        public DateTime? POSTED_ERP { get; set; }
        public string POSTED_RESPONSE { get; set; }
        public string ERP_REFERENCE { get; set; }
        public string ORDER_NUMBER { get; set; }
        public List<DemandaDeDespachoEncabezado> DemandaDeDespachoEncabezado { get; set; }
    }
}
