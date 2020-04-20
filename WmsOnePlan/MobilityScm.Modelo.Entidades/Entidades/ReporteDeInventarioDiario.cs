using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobilityScm.Modelo.Entidades
{
    public class ReporteDeInventarioDiario
    {
        public string MATERIAL_ID { get; set; }
        public string MATERIAL_NAME { get; set; }
        public int IS_MASTER_PACK { get; set; }
        public string WAREHOUSE { get; set; }
        public decimal QTY_INCOME_TRANSACTION { get; set; }
        public decimal QTY_OUTPUT_TRANSACTION { get; set; }
        public decimal INITIAL_INVENTORY { get; set; }
        public decimal FINAL_INVENTORY { get; set; }
    }
}
