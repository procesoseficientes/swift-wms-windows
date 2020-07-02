using System;
using System.Collections.Generic;
using MobilityScm.Modelo.Entidades;

namespace MobilityScm.Modelo.Argumentos
{
    public class BodegaArgumento : EventArgs
    {
        public Bodega Bodega { get; set; }

        public string BodegaId { get; set; }

    }
}
