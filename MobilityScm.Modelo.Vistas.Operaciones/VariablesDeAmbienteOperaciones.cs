using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Symbol.WPAN.Bluetooth;

namespace MobilityScm.Modelo.Vistas
{
    public static class VariablesDeAmbienteOperaciones
    {
        public static string Usuario { get; set; }
        public static string Ambiente { get; set; }
        public static string DireccionDeServicio { get; set; }
        public static string DireccionDeImpresora { get; set; }
        public static string Empresa { get; set; }
        public static MobilityScm.BarcodeScann.BarcodeScanner EscanerDeCodigoDeBarras { get; set; }
    }
}
