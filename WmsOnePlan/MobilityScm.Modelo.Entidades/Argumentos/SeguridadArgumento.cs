using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MobilityScm.Modelo.Entidades;

namespace MobilityScm.Modelo.Argumentos
{
    public class SeguridadArgumento : EventArgs
    {
        public Seguridad Seguridad { get; set; }

        public Seguridad SeguridadVista { get; set; }   // Hijos de la pantalla

        public string Pantalla { get; set; }
    }
}
