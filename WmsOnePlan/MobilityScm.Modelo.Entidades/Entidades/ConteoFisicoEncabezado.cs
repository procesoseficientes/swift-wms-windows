using System;

namespace MobilityScm.Modelo.Entidades
{
    [Serializable]
    public class ConteoFisicoEncabezado
    {
        public int PHYSICAL_COUNT_HEADER_ID { get; set; }

        public int? TASK_ID { get; set; }

        public string REGIMEN { get; set; }

        public string DISTRIBUTION_CENTER { get; set; }

        public string STATUS { get; set; }
    }
}
