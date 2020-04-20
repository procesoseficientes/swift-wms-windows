using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MobilityScm.Modelo.Entidades;

namespace MobilityScm.Modelo.Argumentos
{
    public class PolizaArgumento : EventArgs
    {
        public Poliza Poliza { get; set; }

        public IList<Poliza> Polizas { get; set; }

        public int BLOCKED_ONLY { get; set; }
        public int DAYS { get; set; }
        public DateTime START_DATE { get; set; }
        public DateTime END_DATE { get; set; }
        public string CUSTOMER { get; set; }

        public string UNLOCK_DOCUMENT { get; set; }
        public string UNLOCK_COMMENT { get; set; }
        public string UNLOCK_USER { get; set; }
    }
}
