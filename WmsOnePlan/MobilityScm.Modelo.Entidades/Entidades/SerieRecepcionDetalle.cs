using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobilityScm.Modelo.Entidades
{
    [Serializable]
    public class SerieRecepcionDetalle
    {
        public decimal DOC_ID { get; set; }
        public int LICENSE_ID { get; set; }
        public string CURRENT_LOCATION { get; set; }
        public string MATERIAL_ID { get; set; }
        public string SERIAL { get; set; }
        public string CORRELATIVE { get; set; }
        public string SERIAL_PREFIX { get; set; }
        public int SERIAL_CORRELATIVE { get; set; }
        public string SERIAL_CORRELATIVE_ID { get; set; }
        public int ID { get; set; }
        public string MATERIAL_NAME { get; set; }
        public string CODE_SUPPLIER { get; set; }
        public string NAME_SUPPLIER { get; set; }
    }
}
