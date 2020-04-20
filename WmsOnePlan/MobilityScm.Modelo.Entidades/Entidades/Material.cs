using System;

namespace MobilityScm.Modelo.Entidades
{
    public class Material
    {
        public string CLIENT_OWNER { get; set; }

        public string MATERIAL_ID { get; set; }

        public string BARCODE_ID { get; set; }

        public string ALTERNATE_BARCODE { get; set; }

        public string MATERIAL_NAME { get; set; }

        public string SHORT_NAME { get; set; }

        public decimal? VOLUME_FACTOR { get; set; }

        public string MATERIAL_CLASS { get; set; }

        public decimal? HIGH { get; set; }

        public decimal? LENGTH { get; set; }

        public decimal? WIDTH { get; set; }

        public decimal? MAX_X_BIN { get; set; }

        public decimal? SCAN_BY_ONE { get; set; }

        public decimal? REQUIRES_LOGISTICS_INFO { get; set; }

        public decimal? WEIGTH { get; set; }

        public byte[] IMAGE_1 { get; set; }

        public byte[] IMAGE_2 { get; set; }

        public byte[] IMAGE_3 { get; set; }

        public DateTime? LAST_UPDATED { get; set; }

        public string LAST_UPDATED_BY { get; set; }

        public decimal? IS_CAR { get; set; }

        public decimal? MT3 { get; set; }

        public decimal? BATCH_REQUESTED { get; set; }

        public decimal? SERIAL_NUMBER_REQUESTS { get; set; }

        public int IS_MASTER_PACK { get; set; }

        public decimal ERP_AVERAGE_PRICE { get; set; }

        public string WEIGHT_MEASUREMENT { get; set; }

        public int EXPLODE_IN_RECEPTION { get; set; }

        public int HANDLE_TONE { get; set; }

        public int HANDLE_CALIBER { get; set; }

        public int USE_PICKING_LINE { get; set; }

        public int QUALITY_CONTROL { get; set; }

        public string ITEM_CODE_ERP { get; set; }

        public int NON_STORAGE { get; set; }

        public int ALLOW_DECIMAL_VALUE { get; set; }

        public string PREFIX_CORRELATIVE_SERIALS { get; set; }

        public int HANDLE_CORRELATIVE_SERIALS { get; set; }

        public string BASE_MEASUREMENT_UNIT { get; set; }
        public bool IS_SELECTED { get; set; }

        public string MATERIAL_CODE { get; set; }
    }
}
