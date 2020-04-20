using System;

namespace MobilityScm.Modelo.Entidades
{
    public class Proyecto
    {
        public Guid ID { get; set; }

        public string OPPORTUNITY_CODE { get; set; }

        public string OPPORTUNITY_NAME { get; set; }

        public string SHORT_NAME { get; set; }

        public string OBSERVATIONS { get; set; }

        public string CUSTOMER_CODE { get; set; }

        public string STATUS { get; set; }

        public string CREATED_BY { get; set; }

        public DateTime? CREATED_DATE { get; set; }

        public string LAST_UPDATED_BY { get; set; }

        public DateTime? LAST_UPDATED_DATE { get; set; }

        public string CUSTOMER_NAME { get; set; }

        public string CUSTOMER_OWNER { get; set; }

        public string STATUS_DESCRIPTION { get; set; }

        public decimal UNITS { get; set; }

        public decimal PERCENTAGE_DISPATCHED { get; set; }

        public DateTime? LAST_DISPATCHED_DATE { get; set; }

        public decimal COST_UNITS { get; set; }
    }
}
