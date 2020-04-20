using System;
using System.Collections.Generic;
using MobilityScm.Modelo.Entidades;

namespace MobilityScm.Modelo.Vistas
{
    public interface IDemoVista
    {
        event EventHandler VistaTerminoDeCargar;
        event EventHandler VistaCargandosePorPrimeraVez;

        IList<Entidad> Listado { get; set; }
    }
}