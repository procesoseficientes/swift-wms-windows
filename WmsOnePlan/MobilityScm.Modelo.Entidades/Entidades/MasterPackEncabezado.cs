using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobilityScm.Modelo.Entidades
{
    public class MasterPackEncabezado
    {
        public int MASTER_PACK_HEADER_ID { get; set; }
        public int LICENSE_ID { get; set; }
        public string MATERIAL_ID { get; set; }
        public string MATERIAL_NAME { get; set; }
        public int POLICY_HEADER_ID { get; set; }
        public string CODE_POLICY_HEADER { get; set; }
        public DateTime LAST_UPDATED { get; set; }
        public string LAST_UPDATE_BY { get; set; }
        public int EXPLODED { get; set; }
        public string EXPLODED_DESCRIPTION { get; set; }
        public DateTime? EXPLODED_DATE { get; set; }
        public DateTime RECEPTION_DATE { get; set; }
        public int IS_AUTHORIZED { get; set; }
        public string IS_AUTHORIZED_DESCRIPTION { get; set; }
        public int ATTEMPTED_WITH_ERROR { get; set; }
        public int IS_POSTED_ERP { get; set; }
        public DateTime? POSTED_ERP { get; set; }
        public string POSTED_RESPONSE { get; set; }
        public string ERP_REFERENCE { get; set; }
        public string STATUS_POSTED_ERP { get; set; }

        public string CLIENT_CODE { get; set; }
        public string CLIENT_NAME { get; set; }
        public bool IS_SELECTD { get; set; }

        public int MAX_ATTEMPTS { get; set; }
        public int QTY { get; set; }
    }
}
