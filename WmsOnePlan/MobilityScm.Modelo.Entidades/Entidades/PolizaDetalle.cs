using System;

namespace MobilityScm.Modelo.Entidades
{
    [Serializable]
    public class PolizaDetalle
    {
        public decimal DOC_ID { get; set; }

        public decimal LINE_NUMBER { get; set; }

        public string SKU_DESCRIPTION { get; set; }

        public string SAC_CODE { get; set; }

        public decimal BULTOS { get; set; }

        public string CLASE { get; set; }

        public decimal? NET_WEIGTH { get; set; }

        public string WEIGTH_UNIT { get; set; }

        public decimal? QTY { get; set; }

        public decimal? CUSTOMS_AMOUNT { get; set; }

        public string QTY_UNIT { get; set; }

        public decimal? VOLUME { get; set; }

        public string VOLUME_UNIT { get; set; }

        public decimal DAI { get; set; }

        public decimal IVA { get; set; }

        public decimal MISC_TAXES { get; set; }

        public decimal? FOB_USD { get; set; }

        public decimal? FREIGTH_USD { get; set; }

        public decimal? INSURANCE_USD { get; set; }

        public decimal? MISC_EXPENSES { get; set; }

        public string ORIGIN_COUNTRY { get; set; }

        public string REGION_CP { get; set; }

        public string AGREEMENT_1 { get; set; }

        public string AGREEMENT_2 { get; set; }

        public string RELATED_POLIZA { get; set; }

        public string LAST_UPDATED_BY { get; set; }

        public DateTime? LAST_UPDATED { get; set; }

        public decimal? ORIGIN_DOC_ID { get; set; }

        public string CODIGO_POLIZA_ORIGEN { get; set; }

        public string CLIENT_CODE { get; set; }

        public string ACUERDO_COMERCIAL { get; set; }

        public decimal? PCTDAI { get; set; }

        public decimal? ORIGIN_LINE_NUMBER { get; set; }

        public string PICKING_STATUS { get; set; }

        public decimal? TAX { get; set; }

        public string MATERIAL_ID { get; set; }

        public decimal? UNITARY_PRICE { get; set; }

        public int? IS_AUTHORIZED { get; set; }
    }
}
