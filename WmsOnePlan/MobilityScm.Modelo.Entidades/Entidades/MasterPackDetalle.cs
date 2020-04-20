using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobilityScm.Modelo.Entidades
{
    public class MasterPackDetalle
    {
        public int MASTER_PACK_DETAIL_ID { get; set; }
        public int MASTER_PACK_HEADER_ID { get; set; }
        public string MATERIAL_ID { get; set; }
        public string MATERIAL_NAME { get; set; }
        public string CLIENT_CODE { get; set; }
        public string CLIENT_NAME { get; set; }
        public string BARCODE_ID { get; set; }
        public int QTY { get; set; }
        public string BATCH { get; set; }
        public DateTime DATE_EXPIRATION { get; set; }
    }
}
