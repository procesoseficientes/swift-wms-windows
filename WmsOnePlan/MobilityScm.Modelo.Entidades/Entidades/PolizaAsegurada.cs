using System;

namespace MobilityScm.Modelo.Entidades
{
    [Serializable]
    public class PolizaAsegurada
    {
        public string DOC_ID { get; set; }

        public string COMPANY_ID { get; set; }

        public decimal? AMOUNT { get; set; }

        public decimal? AVAILABLE { get; set; }

        public DateTime? LAST_TXN_DATE { get; set; }

        public DateTime? CREATED_DATE { get; set; }

        public string CREATED_BY { get; set; }

        public DateTime? LAST_UPDATED { get; set; }

        public string LAST_UPDATED_BY { get; set; }

        public string CLIENT_CODE { get; set; }

        public string COVERAGE { get; set; }

        public DateTime? VALIN_FROM { get; set; }

        public DateTime? VALIN_TO { get; set; }

        public string POLIZA_INSURANCE { get; set; }

        public string INSURANCE_OWHEN { get; set; }

        public string DOC_ID_CONFIGURATION { get; set; }
    }
}
