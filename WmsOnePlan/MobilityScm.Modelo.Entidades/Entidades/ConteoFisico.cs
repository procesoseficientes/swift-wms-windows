using System;
using System.Security;

namespace MobilityScm.Modelo.Entidades
{
    [Serializable]
    public class ConteoFisico
    {
        public int PHYSICAL_COUNT_HEADER_ID { get; set; }
        public int TASK_ID { get; set; }
        public DateTime? ACCEPTED_DATE { get; set; }
        public DateTime? COMPLETED_DATE { get; set; }
        public string TASK_ASSIGNED_TO { get; set; }
        public DateTime? ASSIGNED_DATE { get; set; }
        public string REGIMEN { get; set; }
        public string TASK_STATUS { get; set; }
        public decimal PERCENT_COMPLETED { get; set; }
        public decimal ACCURACY { get; set; }
        public int TOTAL_CONTADOS { get; set; }
        public int TOTAL_COUNT { get; set; }
        public int TOTAL_HITS { get; set; }
        public int TOTAL_MISSES { get; set; }
        public string WAREHOUSE_ID { get; set; }
        public string LOCATION_STATUS { get; set; }
        public string LOCATION { get; set; }
        public string MATERIAL_ID { get; set; }
        public string MATERIAL_NAME { get; set; }
        public string ASSIGNED_TO { get; set; }
        public string COUNT_ASSIGNED_TO { get; set; }
        public decimal QTY_SCANNED { get; set; }
        public int LICENSE_ID { get; set; }
        public decimal QTY_EXPECTED { get; set; }
        public string HIT_OR_MISS { get; set; }
        public DateTime? EXECUTED { get; set; }
        public string EXECUTED_BY { get; set; }
        public DateTime? EXPIRATION_DATE { get; set; }
        public string BATCH { get; set; }
        public string SERIAL { get; set; }
        public decimal DIFFERENCE { get; set; }
        public DateTime? EXPIRATION_DATE_EXPECTED { get; set; }
        public string BATCH_EXPECTED { get; set; }
        public string SERIAL_EXPECTED { get; set; }




    }
}
