using System;

namespace MobilityScm.Modelo.Entidades
{
    [Serializable]
    public class DocumentoRecepcionErpEncabezado
    {
        public string SAP_REFERENCE { get; set; }
        public string DOC_NUM { get; set; }
        public string DOC_TYPE { get; set; }
        public string DESCRIPTION_TYPE { get; set; }
        public string SUPPLIER_ID { get; set; }
        public string SUPPLIER_NAME { get; set; }
        public DateTime DOC_DATE { get; set; }
        public int EXTERNAL_SOURCE_ID { get; set; }
        public string DOC_IDS { get; set; }

        public bool IS_SELECTD { get; set; }
        public int HAS_MISSING { get; set; }
        public string MASTER_ID_PROVIDER { get; set; }
        public string OWNER_PROVIDER { get; set; }
        public string OWNER { get; set; }

        public string ADDRESS { get; set; }
		public string DOC_CURRENCY { get; set; }
        public double DOC_RATE { get; set; }
        public string SUBSIDIARY { get; set; }

    }
}
