using System;

namespace MobilityScm.Modelo.Entidades
{
    public class PedidosPorVendedor
    {
        public int? SALES_ORDER_ID { get; set; }

        public string CLIENT_CODE { get; set; }

        public DateTime? POSTED_DATETIME { get; set; }

        public DateTime? DELIVERY_DATETIME { get; set; }

        public string SOURCE { get; set; }

        public string SELLER_CODE { get; set; }

        public string SELLER_NAME { get; set; }

        public decimal? DOC_TOTAL { get; set; }

        public string OWNER { get; set; }

        public int? EXTERNAL_SOURCE_ID { get; set; }

        public int WAVE_PICKING_ID { get; set; }

        public string SOURCE_NAME { get; set; }

        public int IN_PICKING_DEMAND { get; set; }

        public int TASK_IS_COMPLETED { get; set; }

        public DateTime TASK_ACCEPTED_DATE { get; set; }

        public DateTime TASK_COMPLETED_DATE { get; set; }
    }
    
}