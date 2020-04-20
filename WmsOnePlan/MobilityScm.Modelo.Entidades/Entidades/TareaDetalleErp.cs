using System;

namespace MobilityScm.Modelo.Entidades
{
    public class TareaDetalleErp
    {
        public string NO_DOC { get; set; }
        public int PICKING_DEMAND_HEADER_ID { get; set; }
        public int WMS_DOCUMENT_HEADER_ID { get; set; }
        public string DOC_ID { get; set; }
        public int ATTEMPTED_WITH_ERROR { get; set; }
        public int IS_POSTED_ERP { get; set; }
        public string STATUS_POSTED_ERP { get; set; }
        public DateTime POSTED_ERP { get; set; }
        public string POSTED_RESPONSE { get; set; }
        public string ERP_REFERENCE { get; set; }
        public int IS_AUTHORIZED { get; set; }
        public int MAX_ATTEMPTS { get; set; }
        public string CODE_ROUTE { get; set; }
        public int USE_PICKING_LINE { get; set; }
    }
}
