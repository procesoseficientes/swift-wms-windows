using System;
using System.Collections.Generic;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Vertical.Entidades;

namespace MobilityScm.Modelo.Argumentos
{
    public class DocumentoRecepcionERPArgumento: EventArgs
    {
        public DocumentoRecepcionErpEncabezado DocumentoRecepcionERP { get; set; }

        public DocumentoRecepcionErpDetalle DocumentoRecepcionErpDetalle { get; set; }

        public IList<DocumentoRecepcion> DocumentosDeRecepcion{ get; set; }

        public PolizaAsegurada PolizaAsegurada { get; set; }

        public FuenteExterna FuenteExterna { get; set; }

        public Operacion Operacion { get; set; }

        public IList<string> Operadores { get; set; }

        public Boolean Consolidado { get; set; }
    }
}
