using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MobilityScm.Modelo.Entidades;

namespace MobilityScm.Modelo.Argumentos
{
    public class ZonaArgumento: EventArgs
    {
        public Zona Zona { get; set; }

        public int ZonaAsociadaId { get; set; }
    }
}
