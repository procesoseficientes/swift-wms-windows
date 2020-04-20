using System;
using MobilityScm.Modelo.Entidades;

namespace MobilityScm.Modelo.Argumentos
{
    public class ProyectoArgumento : EventArgs
    {
        public Proyecto Proyecto { get; set; }
        public string Login { get; set; }
        public string MaterialXml { get; set; }
        public string LicenciasXml { get; set; }
    }
}
