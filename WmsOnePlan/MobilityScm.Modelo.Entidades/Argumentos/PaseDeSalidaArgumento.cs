using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MobilityScm.Modelo.Entidades;

namespace MobilityScm.Modelo.Argumentos
{
    public class PaseDeSalidaArgumento : EventArgs
    {
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Login { get; set; }

        public string CODE_WAREHOUSE { get; set; }

        public string DEMAND_TYPE { get; set; }

        public string PICKING_DEMAND_HEADER_ID { get; set; }

        public string Xml { get; set; }
        public string DISTRIBUTION_CENTER_ID { get; set; }

        public PaseDeSalidaEncabezado PaseDeSalidaEncabezado { get; set; }

        public List<PaseDeSalidaDetalle> PaseDeSalidaDetalles { get; set; }
        public Vehiculo Vehiculo { get; set; }
        public Piloto Piloto { get; set; }

        public IList<MobilityScm.Modelo.Entidades.Configuracion> TipoSalida { get; set; }
    }
}
