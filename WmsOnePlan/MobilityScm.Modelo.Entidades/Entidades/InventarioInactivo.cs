using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobilityScm.Modelo.Entidades
{
    public class InventarioInactivo
    {
        public string CURRENT_WAREHOUSE { get; set; }
        public string ZONE { get; set; }
        public string CURRENT_LOCATION { get; set; }
        public int LICENSE_ID { get; set; }
        public string MATERIAL_ID { get; set; }
        public string BARCODE_ID { get; set; }
        public string MATERIAL_NAME { get; set; }
        public decimal QTY { get; set; }
        public int IDLE { get; set; }
        public int NUMBER_OF_COMPLETE_RELOCATIONS { get; set; }
        public int NUMBER_OF_PARTIAL_RELOCATIONS { get; set; }
        public int NUMBER_OF_PHYSICAL_COUNTS { get; set; }
    }
}
