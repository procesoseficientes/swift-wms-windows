using System;
using System.Collections.Generic;

namespace MobilityScm.Modelo.Entidades
{
    [Serializable]
    public class Sku
    {
        public string SKU { get; set; }

        public string CODE_SKU { get; set; }

        public string DESCRIPTION_SKU { get; set; }

        public string CLASSIFICATION_SKU { get; set; }

        public string BARCODE_SKU { get; set; }

        public string BARCODE_ID { get; set; }

        public string CODE_PROVIDER { get; set; }

        public float? COST { get; set; }

        public string MEASURE { get; set; }

        public DateTime? LAST_UPDATE { get; set; }

        public string LAST_UPDATE_BY { get; set; }

        public string HANDLE_SERIAL_NUMBER { get; set; }

        public string HANDLE_BATCH { get; set; }

        public int? UNIT_MEASURE_SKU { get; set; }

        public decimal? WEIGHT_SKU { get; set; }

        public decimal? VOLUME_SKU { get; set; }

        public decimal? LONG_SKU { get; set; }

        public decimal? WIDTH_SKU { get; set; }

        public decimal? HIGH_SKU { get; set; }

        public string CODE_FAMILY_SKU { get; set; }

        public string DESCRIPTION_FAMILY_SKU { get; set; }

        public int PACK_UNIT { get; set; }

        public string CODE_PACK_UNIT { get; set; }

        public string DESCRIPTION_PACK_UNIT { get; set; }

        public double QTY { get; set; }

        public int EXTERNAL_SOURCE_ID { get; set; }

        public string SOURCE_NAME { get; set; }

        public string CLIENT_OWNER { get; set; }

        public string MATERIAL_ID { get; set; }

        public string MATERIAL_NAME { get; set; }

        public int REQUEST_QTY { get; set; }

        public int QTY_NEEDED { get; set; }

        public bool IS_SELECTED { get; set; }

        public int IS_MASTER_PACK { get; set; }

        public string MASTER_PACK_ID { get; set; }
        public List<Sku> ComponentesMasterPack { get; set; }
        public int QTY_MP { get; set; }

        public double CURRENTLY_AVAILABLE { get; set; }

        public string STATUS_CODE { get; set; }
    }

}