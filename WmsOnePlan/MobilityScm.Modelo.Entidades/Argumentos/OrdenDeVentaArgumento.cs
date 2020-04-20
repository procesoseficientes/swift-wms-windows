using System;
using System.Collections.Generic;
using MobilityScm.Modelo.Entidades;

namespace MobilityScm.Modelo.Argumentos
{
    public class OrdenDeVentaArgumento : EventArgs
    {
        public IList<OrdenDeVentaEncabezado> Encabezados { get; set; }

        public IList<OrdenDeVentaDetalle> Detalles { get; set; }

        public OrdenDeVentaEncabezado OrdenDeVentaEncabezado { get; set; }

        public OrdenDeVentaDetalle OrdenDeVentaDetalle { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFin { get; set; }

        public string CodigosFuenteRuta { get; set; }

        public string CodigosRuta { get; set; }

        public int CodigoFuenteExterna { get; set; }

        public string CodigoBodega { get; set; }

        public string CodigosClientesErpCanalModerno { get; set; }

        public string TextoEncabezados { get; set; }

        public string TextoFuentesExternas { get; set; }

        public bool EsConsolidado { get; set; }
        public string XmlDocumentos { get; set; }
        public bool EsPorTonoOCalibre { get; set; }
        public bool EsDeErp { get; set; }
        public string CodigosPoligonos { get; set; }
        public string FuenteExternaPoligonos { get; set; }

        public int? UsaLineaDePicking { get; set; }

        public string Usuario { get; set; }

        public Entidades.Configuracion EstadoPredeterminadoDeMaterial { get; set; }

        public bool BorrarSeleccionados { get; set; }

        public string DocNum { get; set; }
    }
}