using System;

namespace MobilityScm.Modelo.Entidades
{
    [Serializable]
    public class Ruta
    {
        public int ROUTE { get; set; }

        public string CODE_ROUTE { get; set; }

        public string NAME_ROUTE { get; set; }

        public string GEOREFERENCE_ROUTE { get; set; }

        public string COMMENT_ROUTE { get; set; }

        public string LOGIN { get; set; }

        public string SELLER_CODE { get; set; }

        public string SELLER_NAME { get; set; }

        public string CODE_VEHICLE { get; set; }

        public string NAME_USER { get; set; }

        public DateTime STAR_DATE { get; set; }

        public DateTime END_DATE { get; set; }
 
        public int EXTERNAL_SOURCE_ID { get; set; }

        public string SOURCE_NAME { get; set; }

        public bool IS_SELECTED { get; set; }
    }
}
