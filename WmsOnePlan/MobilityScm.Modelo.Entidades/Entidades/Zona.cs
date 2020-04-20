using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobilityScm.Modelo.Entidades
{
    public class Zona
    {
        public int ZONE_ID { get; set; }

        public string ZONE { get; set; }

        public string DESCRIPTION { get; set; }

        public string WAREHOUSE_CODE { get; set; }

        public int RECEIVE_EXPLODED_MATERIALS { get; set; }

        public string LINE_ID { get; set; }

        public bool IS_SELECTED { get; set; }
    }
}

