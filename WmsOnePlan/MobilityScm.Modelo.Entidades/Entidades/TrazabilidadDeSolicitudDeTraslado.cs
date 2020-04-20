using System;

namespace MobilityScm.Modelo.Entidades
{
    [Serializable]
    public class TrazabilidadDeSolicitudDeTraslado
    {
        public int TRANSFER_REQUEST_ID { get; set; }
        public string TRANS_TYPE { get; set; }
        public int TASK_ID { get; set; }
        public DateTime CREATED_DATE { get; set; }
        public decimal QTY { get; set; }
        public decimal PROCESSED_QUANTITY { get; set; }
        public string TASK_ASSIGNED_TO { get; set; }
        public string DRIVER { get; set; }
        public string VEHICLE { get; set; }
    }
}
