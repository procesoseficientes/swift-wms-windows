using System;
using System.Collections.Generic;
using MobilityScm.Modelo.Entidades;

namespace MobilityScm.Modelo.Argumentos
{
    public class VehiculoArgumento: EventArgs
    {
        public IList<Vehiculo> Vehiculos { get; set; }
        public Vehiculo Vehiculo { get; set; }
        public Piloto Piloto { get; set; }
    }
}