using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobilityScm.Modelo.Entidades
{
    [Serializable]
    public class PaseDeSalidaEncabezado
    {
        public string CLIENT_CODE { get; set; }

        public string CLIENT_NAME { get; set; }

        public decimal PASS_ID { get; set; }

        public string LAST_UPDATED_BY { get; set; }

        public DateTime? LAST_UPDATED { get; set; }

        public string ISEMPTY { get; set; }

        public string VEHICLE_PLATE { get; set; }

        public string VEHICLE_DRIVER { get; set; }

        public int? VEHICLE_ID { get; set; }

        public int? DRIVER_ID { get; set; }

        public string AUTORIZED_BY { get; set; }

        public string HANDLER { get; set; }

        public string CARRIER { get; set; }

        public string TXT { get; set; }

        public string LOADUNLOAD { get; set; }

        public string LOADWITH { get; set; }

        public decimal? AUDIT_ID { get; set; }

        public DateTime? CREATED_DATE { get; set; }

        public string CREATED_BY { get; set; }

        public string STATUS { get; set; }

        public string TYPE { get; set; }

        public string LICENSE_NUMBER { get; set; }
    }
}
