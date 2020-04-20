using System;

namespace MobilityScm.Modelo.Entidades
{
    public class ZonaDePosicionamiento
    {
        public Guid ID { get; set; }

        public string WAREHOUSE_CODE { get; set; }

        public int ZONE_ID { get; set; }

        public string ZONE { get; set; }

        public bool MANDATORY { get; set; }

        public int FAMILY { get; set; }
    }
}
