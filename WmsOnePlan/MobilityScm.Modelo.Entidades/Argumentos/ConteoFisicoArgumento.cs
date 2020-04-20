using System;
using System.Collections.Generic;
using MobilityScm.Modelo.Entidades;

namespace MobilityScm.Modelo.Argumentos
{
    public class ConteoFisicoArgumento : ConsultaArgumento
    {
        public Tarea Tarea { get; set; }

        public ConteoFisicoEncabezado ConteoFisicoEncabezado { get; set; }

        public IList<ConteoFisicoDetalle> ConteoFisicoDetalle { get; set; }

        public string Bodegas { get; set; }
        public string Usuarios { get; set; }
        public string Zonas { get; set; }
        public string Clientes { get; set; }
        public string Ubicaciones { get; set; }
        public string Regimen { get; set; }
        public string Materiales { get; set; }
        public string Operadores { get; set; }
        public int UbicacionesVacias { get; set; }
    }
}
