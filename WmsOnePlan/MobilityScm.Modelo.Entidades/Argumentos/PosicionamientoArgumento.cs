using System;
using MobilityScm.Modelo.Entidades;

namespace MobilityScm.Modelo.Argumentos
{
    public class PosicionamientoArgumento : EventArgs
    {
        public string XmlBodegas { get; set; }

        public string XmlClases { get; set; }

        public ZonaDePosicionamiento ZonaDePosicionamiento { get; set; }

        public string Login { get; set; }

        public string XmlZonaPosicionamiento { get; set; }
    }
}
