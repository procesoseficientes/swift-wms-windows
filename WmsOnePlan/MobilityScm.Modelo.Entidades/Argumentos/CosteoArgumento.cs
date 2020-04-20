using System;
using MobilityScm.Modelo.Entidades;

namespace MobilityScm.Modelo.Argumentos
{
    public class CosteoArgumento: EventArgs
    {
        public Poliza Poliza { get; set; }
        public PolizaDetalle PolizaDetalle { get; set; }
        public PolizaAsegurada PolizaAsegurada { get; set; }
        public AcuerdoComercial AcuerdoComercial { get; set; }
        public DateTime FechaInicial { get; set; }
        public DateTime FechaFinal { get; set; }
        public string Login { get; set; }
        public string Warehouses { get; set; }
    }
}
