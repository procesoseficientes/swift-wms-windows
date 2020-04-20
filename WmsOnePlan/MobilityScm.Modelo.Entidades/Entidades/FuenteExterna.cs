using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobilityScm.Modelo.Entidades
{
    public class FuenteExterna
    {
        public int EXTERNAL_SOURCE_ID { get; set; }
        public string SOURCE_NAME { get; set; }
        public DateTime INITIAL_DATE { get; set; }
        public DateTime END_DATE { get; set; }
        public int HAS_MISSING { get; set; }
        public string DATA_BASE_NAME { get; set; }
        public string SCHEMA_NAME { get; set; }
        public string COMMENT { get; set; }
        public string INTERFACE_DATA_BASE_NAME { get; set; }
        public int COMPANY_ID { get; set; }
        public string COMPANY_NAME { get; set; }
        public string CLIENT_CODE { get; set; }
    }
}
