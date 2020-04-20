using System;

namespace MobilityScm.Modelo.Entidades
{
    [Serializable]
    public class CajaPorCliente
    {
        public string DISTRIBUTION_CENTER { get; set; }

        public string PLATE_NUMBER { get; set; }

        public string PILOT_FULL_NAME { get; set; }

        public int MANIFEST_HEADER_ID { get; set; }

        public string CLIENT_CODE { get; set; }

        public string CLIENT_NAME { get; set; }

        public int BOX_AMOUNT { get; set; }

        public string BOXES { get; set; }

        public string DOCUMENTS { get; set; }
    }
}