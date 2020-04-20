using System;
using System.Collections.Generic;
using MobilityScm.Modelo.Entidades;

namespace MobilityScm.Modelo.Argumentos
{
    public class ManifiestoArgumento : ConsultaArgumento
    {
        public ManifiestoEncabezado ManifiestoEncabezado { get; set; }
        public IList<ManifiestoDetalle> ManifiestoDetalle { get; set; }
        public string Bodegas { get; set; }
        public string Rutas { get; set; }
        public string EncabezadosSeleccionados { get; set; }

        public string Tipo { get; set; }

        public string IdManifiestoDeCarga { get; set; }

        public Vehiculo Vehiculo { get; set; }
        public string DemandasDespacho { get; set; }

        public bool EstaModificando { get; set; }
    }
}
