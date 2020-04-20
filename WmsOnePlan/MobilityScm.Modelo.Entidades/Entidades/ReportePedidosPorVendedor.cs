using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobilityScm.Modelo.Entidades
{
    public class ReportePedidosPorVendedor
    {
        public string SELLER_CODE { get; set; }
        public string SELLER_NAME { get; set; }
        public decimal TOTAL_SALES_ORDERS { get; set; }
        public int QTY_SALES_ORDERS { get; set; }
        public int QTY_CUSTOMERS { get; set; }
        public int QTY_PENDING_TO_ASSIGN { get; set; }
        public int QTY_PICKED { get; set; }
        public int QTY_PENDING_TO_DISPATCH { get; set; }
        public int QTY_DISPATCHED { get; set; }
        public TimeSpan TOTAL_TIME_SPENT { get; set; }
    }
}
