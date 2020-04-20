using System;

namespace MobilityScm.Modelo.Entidades
{
    [Serializable]
    public class PolizaMaestroDetalle
    {

        public int DOC_ID { get; set; }
        public string CODIGO_POLIZA { get; set; }
        public string CLIENT_CODE { get; set; }
        public string CLIENT_NAME { get; set; }
        public DateTime? FECHA_DOCUMENTO { get; set; }
        public DateTime? FECHA_LLEGADA { get; set; }
        public string POLIZA_ASEGURADA { get; set; }
        public string NUMERO_ORDEN { get; set; }
        public string ACUERDO_COMERCIAL { get; set; }
        public string LAST_UPDATED_BY { get; set; }
        public DateTime? LAST_UPDATED { get; set; }
        public string TRANS_TYPE { get; set; }
        public int LINE_NUMBER { get; set; }
        public string SKU_DESCRIPTION { get; set; }
        public decimal? QTY { get; set; }
        public decimal? CUSTOMS_AMOUNT { get; set; }
        public string MATERIAL_ID { get; set; }
        public decimal? UNITARY_PRICE { get; set; }
        public int? IS_AUTHORIZED { get; set; }

        public string STATUS { get; set; }
        public bool IS_SELECTED { get; set; }

    }
}
