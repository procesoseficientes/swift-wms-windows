using System;

namespace MobilityScm.Modelo.Entidades
{
    [Serializable]
    public class PaseDeSalida
    {
        public string CLIENT_CODE { get; set; }

        public string CLIENT_NAME { get; set; }

        public decimal PASS_ID { get; set; }

        public string LAST_UPDATED_BY { get; set; }

        public DateTime? LAST_UPDATED { get; set; }

        public string ISEMPTY { get; set; }

        public string VEHICLE_PLATE { get; set; }

        public string VEHICLE_DRIVER { get; set; }

        public int? VEHICLE_ID { get; set; }

        public int? DRIVER_ID { get; set; }

        public string AUTORIZED_BY { get; set; }

        public string HANDLER { get; set; }

        public string CARRIER { get; set; }

        public string TXT { get; set; }

        public string LOADUNLOAD { get; set; }

        public string LOADWITH { get; set; }

        public decimal? AUDIT_ID { get; set; }

        public DateTime? CREATED_DATE { get; set; }

        public string CREATED_BY { get; set; }

        public string NAME_PILOT { get; set; }

        public string CODE_WAREHOUSE { get; set; }

        public string STATUS { get; set; }

        public string TYPE { get; set; }

        public int? WAVE_PICKING_ID { get; set; }

        public int? DOC_NUM { get; set; }

        public string MATERIAL_ID { get; set; }

        public string MATERIAL_NAME { get; set; }

        public double? QTY { get; set; }

        public string COMPANY_NAME { get; set; }
        public string DISTRIBUTION_CENTER_ID { get; set; }
        public string ERP_REFERENCE { get; set; }
        public string ADDRESS_CUSTOMER { get; set; }

        public string SELLER { get; set; }

        public string TRNSP_NAME { get; set; }

        public string COMMENTS { get; set; }

        public string PYMNT_GROUP { get; set; }

        public string BRANCH_NAME { get; set; }

        public DateTime DEMAND_DELIVERY_DATE { get; set; }

        public string COMPANY_CONDITIONS { get; set; }
    }
}
