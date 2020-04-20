using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace MobilityScm.Modelo.Vistas
{
    public static class VariablesDeAmbiente
    {
        public static string UserId { get; set; }
        public static string Enviroment { get; set; }
        public static string WsHost { get; set; }
        public static MobilityScm.BarcodeScann.BarcodeScanner BarcodeScanner { get; set; }
    }
}
