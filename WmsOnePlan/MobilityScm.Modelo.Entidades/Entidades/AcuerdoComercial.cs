using System;

namespace MobilityScm.Modelo.Entidades
{
    [Serializable]
    public class AcuerdoComercial
    {
        public string CLIENT_CODE { get; set; }
        public string CLIENT_NAME { get; set; }
        public int ACUERDO_COMERCIAL_ID { get; set; }
        public string ACUERDO_COMERCIAL_NOMBRE { get; set; }
        public string REGIMEN { get; set; }
        public DateTime VALID_FROM { get; set; }
        public DateTime VALID_TO { get; set; }
        public string STATUS { get; set; }
        public int INVENTORY_QTY { get; set; }
        public double VALOR_TOTAL { get; set; }

        public int ACUERDO_COMERCIAL{ get; set; }

        public string DESCRIPCION { get; set; }
    }
}
