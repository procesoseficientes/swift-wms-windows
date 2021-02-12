using System;
using System.Collections.Generic;

namespace MobilityScm.Modelo.Entidades
{
    [Serializable]
    public class ManifiestoEncabezado
    {
        public int DRIVER { get; set; }
        public int VEHICLE { get; set; }
        public string DISTRIBUTION_CENTER { get; set; }
        public string LAST_UPDATE_BY { get; set; }
        public int MANIFEST_HEADER_ID { get; set; }
        public string STATUS { get; set; }
        public string DOCUMENT_PREFIX { get; set; }
        public IList<ManifiestoDetalle> Detalle { get; set; }

        //public string CAI { get; set; }
        //public string CAI_NUMERO { get; set; }
        //public int CAI_RANGO_INICIAL { get; set; }
        //public int CAI_RANGO_FINAL { get; set; }
        //public DateTime CAI_FECHA_VENCIMIENTO { get; set; }

        public string MANIFEST_TYPE { get; set; }

        public int? TRANSFER_REQUEST_ID { get; set; }

        public IList<ManifiestoDetalle> ListaDeDetalles { get; set; }

        public decimal WEIGHT { get; set; }
        public DateTime CREATED_DATE { get; set; }
        public DateTime LAST_UPDATE { get; set; }
        public string PLATE_NUMBER { get; set; }
        public string PILOT_NAME { get; set; }
        public string WAREHOUSE_FROM { get; set; }
        public string WAREHOUSE_TO { get; set; }
    }
}
