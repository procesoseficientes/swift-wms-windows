using System;
using System.Collections.Generic;
using System.Text;
using Symbol.WPAN.Bluetooth;

namespace MobilityScm.Modelo.Vistas
{
    public static class VariablesDeAmbienteParaConsulta
    {
        public static string UserId { get; set; }
        public static string Enviroment { get; set; }
        public static string WsHost { get; set; }
        public static MobilityScm.BarcodeScann.BarcodeScanner BarcodeScanner { get; set; }
        public static string Printer { get; set; }

    }
}
