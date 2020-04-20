using System;

namespace MobilityScm.Modelo.Entidades
{
    [Serializable]
    public class ServicioPorCobrar
    {

        public int SERVICES_TO_BILL_ID { get; set; }

        public decimal QTY { get; set; }

        public string TRANSACTION_TYPE { get; set; }

        public decimal PRICE_TO_CHANGE { get; set; }
        public decimal PRICE { get; set; }

        public decimal TOTAL_AMOUNT { get; set; }

        public DateTime PROCESS_DATE { get; set; }

        public DateTime CREATED_DATE { get; set; }

        public DateTime? LAST_UPDATED_DATE { get; set; }

        public string LAST_UPDATED_BY { get; set; }

        public int? TYPE_CHARGE_ID { get; set; }

        public string TYPE_CHARGE_DESCRIPTION { get; set; }

        public string CLIENT_CODE { get; set; }

        public string CLIENT_NAME { get; set; }

        public int? IS_CHARGED { get; set; }

        public string INVOICE_REFERENCE { get; set; }

        public DateTime? CHARGED_DATE { get; set; }

        public decimal? LICENSE_ID { get; set; }

        public string LOCATION { get; set; }

        public int? SERVICE_ID { get; set; }

        public string SERVICE_CODE { get; set; }

        public string SERVICE_DESCRIPTION { get; set; }

        public string REGIMEN { get; set; }

        public int? DOC_NUM { get; set; }

        public int? TRANSACTION_ID { get; set; }

        public string IS_CHARGED_DESCRIPTION { get; set; }

        public string BILLING_FRECUENCY { get; set; }
        public string CURRENCY { get; set; }
        public string ACUERDO_COMERCIAL_NOMBRE { get; set; }
        public string ACUERDO_COMERCIAL_STATUS { get; set; }
    }

}
