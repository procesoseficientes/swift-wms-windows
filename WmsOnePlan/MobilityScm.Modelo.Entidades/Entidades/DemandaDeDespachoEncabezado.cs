using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobilityScm.Modelo.Entidades
{
    [Serializable]
    public class DemandaDeDespachoEncabezado
    {
        public string DOC_NUM { get; set; }
        public string STATUS_POSTED_ERP { get; set; }
        public DateTime? POSTED_ERP { get; set; }
        public string POSTED_RESPONSE { get; set; }
        public string ERP_REFERENCE { get; set; }
        public string IS_FROM_ERP { get; set; }
    }
}
