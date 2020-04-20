using System;
using System.Collections.Generic;
using MobilityScm.Modelo.Entidades;

namespace MobilityScm.Modelo.Argumentos
{
    public class CajaArgumento : EventArgs
    {
        public IList<Caja> Cajas { get; set; }

        public string Login { get; set; }
    }
}