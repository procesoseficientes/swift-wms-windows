using System;

namespace MobilityScm.Modelo.Entidades
{
    [Serializable]
    public class CumplimientoDeEntrega
    {

        public int MANIFEST_HEADER_ID { get; set; }
        public string STATUS { get; set; }
        public DateTime CREATED_DATE { get; set; }
        public int VEHICLE_CODE { get; set; }
        public string VEHICLE_PLATE_NUMBER { get; set; }
        public int PILOT_CODE { get; set; }
        public string PILOT_NAME { get; set; }
        public double PERCENTAGE { get; set; }
        public string CLIENT_CODE { get; set; }
        public string CLIENT_NAME { get; set; }
        public string TASK_STATUS { get; set; }
        public string PICKING_DEMAND_STATUS { get; set; }
        public string REASON { get; set; }
        public int SEQUENCE { get; set; }
        public string EXPECTED_GPS { get; set; }
        public string POSTED_GPS { get; set; }
        public double? DISTANCE { get; set; }
        public DateTime? ACCEPTED_STAMP { get; set; }
        public DateTime? COMPLETED_STAMP { get; set; }
        public int? DELAY { get; set; }
        public int DOC_NUM { get; set; }
        public string MATERIAL_ID { get; set; }
        public string MATERIAL_NAME { get; set; }
        public int QTY_REQUESTED { get; set; }
        public int QTY_DELIVERED { get; set; }
        public int DIFFERENCE { get; set; }
        public bool IS_SELECTED { get; set; }
        public DateTime ASSIGNED_STAMP { get; set; }
        public int TASK_ID { get; set; }
        public int DELIVERY_NOTE_ID { get; set; }
        public string DELIVERY_IMAGE { get; set; }
        public string DELIVERY_IMAGE_2 { get; set; }
        public string DELIVERY_IMAGE_3 { get; set; }
        public string DELIVERY_IMAGE_4 { get; set; }
        public string DELIVERY_SIGNATURE { get; set; }
        
    }
}