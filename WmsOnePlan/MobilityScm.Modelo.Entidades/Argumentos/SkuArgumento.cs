using System;
using MobilityScm.Modelo.Entidades;

namespace MobilityScm.Modelo.Argumentos
{
    public class SkuArgumento : EventArgs
    {
        public string CODE_WAREHOUSE { get; set; }
        public string SalesOrderDetailXml { get; set; }

        // ReSharper disable once InconsistentNaming
        public string CODE_MATERIALS { get; set; }

        public bool HandleToneOrCaliber { get; set; }
        public int MIN_DAYS_EXPIRATION_DATE { get; set; }

        public bool EnLineaDePicking { get; set; }
        public Proyecto Proyecto { get; set; }
    }
}
