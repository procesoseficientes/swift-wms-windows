using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilityScm.Modelo.Entidades
{
    public class SugeridoCompra
    {
        public string MATERIAL_ID { get; set; }
        public string MATERIAL_NAME { get; set; }
        public decimal STOCK_MIN { get; set; }
        public decimal STOCK_MAX { get; set; }
        public decimal TRANSIT { get; set; }
        public decimal SUGGESTED_PURCHASE { get; set; }
        public decimal COVERAGE_MONTHS { get; set; }
        public DateTime? LAST_DATE_PURCHASE { get; set; }
        public string SUPPLIER { get; set; }
        public decimal AVERAGE_CONSUMPTION { get; set; }
        public decimal QTY { get; set; }
        public DateTime SUGGESTED_PURCHASE_DATE { get; set; }
        public DateTime RECEPTION_DATE { get; set; }
        public decimal QTY_INVENTORY { get; set; }
    }
}
