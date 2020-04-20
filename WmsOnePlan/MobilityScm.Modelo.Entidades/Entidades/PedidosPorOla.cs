using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobilityScm.Modelo.Entidades
{
    public class PedidosPorOla
    {
        public int CantidadPedidos { get; set; }
        public int OlaDePicking { get; set; }
        public DateTime Aceptada { get; set; }
        public DateTime Terminada { get; set; }
        public TimeSpan TiempoTomado { get; set; }
    }
}
