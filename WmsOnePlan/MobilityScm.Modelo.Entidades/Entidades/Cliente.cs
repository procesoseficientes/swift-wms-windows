using System;

namespace MobilityScm.Modelo
{
    [Serializable]
    public class Cliente
    {
        public string CLIENT_CODE { get; set; }

        public string CLIENT_NAME { get; set; }

        public string CLIENT_ROUTE { get; set; }

        public string CLIENT_CLASS { get; set; }

        public int CLIENT_STATUS { get; set; }

        public string CLIENT_REGION { get; set; }

        public string CLIENT_ADDRESS { get; set; }

        public string CLIENT_CA { get; set; }

        public string CLIENT_ERP_CODE { get; set; }

        public bool IS_SELECTED { get; set; }

        public string CLIENT_ID { get; set; }

        public string OWNER { get; set; }
        public string MASTER_ID { get; set; }

        public string ADDRESS_CUSTOMER { get; set; }

        public int STATE_CODE { get; set; }

        public string CUSTOMER_CODE { get; set; }
        public string CUSTOMER_NAME { get; set; }
        public int MIN_DAYS_EXPIRATION_DATE { get; set; }
    }
}
