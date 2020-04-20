using System;
using System.Collections.Generic;
using MobilityScm.Modelo.Entidades;

namespace MobilityScm.Modelo.Argumentos
{
    public class AcuerdoComercialArgumento : EventArgs
    {
        public AcuerdoComercial AcuerdoComercial { get; set; }

        public string IdCliente { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public String Login { get; set; }
    }
}
