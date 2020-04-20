using System;
using System.Collections.Generic;
using MobilityScm.Modelo.Entidades;

namespace MobilityScm.Modelo.Argumentos
{
    public class CumplimientoDeEntregaArgumento: EventArgs
    {
        public CumplimientoDeEntrega CumplimientoDeEntrega { get; set; }

        public IList<CumplimientoDeEntrega> CumplimientosDeEntregas { get; set; }

        public Vehiculo Vehiculo { get; set; }

        public Piloto Piloto { get; set; }

        public DateTime FechaInicial { get; set; }

        public DateTime FechaFinal { get; set; }

        public string CodigosDePilotos { get; set; }

        public string CodigosDeVehiculos { get; set; }

        public int IdManifiestoCarga { get; set; }

        public int DeliveryNoteId { get; set; }

    }
}