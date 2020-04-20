using System;

namespace MobilityScm.Modelo.Entidades
{
    [Serializable]
    public class InventarioParaPickingPorEstado
    {
        public string MATERIAL_ID { get; set; }
        public string MATERIAL_NAME { get; set; }
        public string CLIENT_CODE { get; set; }
        public string CLIENT_NAME { get; set; }
        public string REGIMEN { get; set; }
        public string CURRENT_WAREHOUSE { get; set; }
        public decimal QTY { get; set; }
        public decimal COMMITED_QTY { get; set; }
        public decimal AVAILABLE_QTY { get; set; }
        public string STATUS_CODE { get; set; }
        public string STATUS_NAME { get; set; }
        public string COLOR { get; set; }
    }
}
