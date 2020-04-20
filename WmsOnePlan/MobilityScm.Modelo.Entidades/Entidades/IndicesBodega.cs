using System;

namespace MobilityScm.Modelo.Entidades
{
    public class IndicesBodega
    {
        public long ID { get; set; }

        public string CODE_WAREHOUSE { get; set; }

        public string MATERIAL_CODE { get; set; }

        public string BARCODE_ID { get; set; }

        public string MATERIAL_NAME { get; set; }

        public decimal? AVARAGE_SALES { get; set; }

        public decimal? QTY { get; set; }

        public decimal? INVENTORY_COVERAGE { get; set; }

        public decimal? INVENTORY_ROTATION { get; set; }

        public DateTime? DATE_OF_LAST_RECEPTION { get; set; }

        public DateTime? DATE_OF_LAST_PICKING { get; set; }

        public DateTime? DATE_OF_THE_LAST_PHYSICAL_COUNT { get; set; }

        public int? IDLE { get; set; }

        public DateTime? DATE_START { get; set; }

        public DateTime? DATE_END { get; set; }

        public DateTime? DATE_OF_PROCESS { get; set; }
    }
}
