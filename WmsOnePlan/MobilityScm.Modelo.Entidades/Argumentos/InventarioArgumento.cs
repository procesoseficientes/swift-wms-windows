using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MobilityScm.Modelo.Entidades;

namespace MobilityScm.Modelo.Argumentos
{
    public class InventarioArgumento: EventArgs
    {
        public string UsuarioId { get; set; }
        public string XmlDeLicencias { get; set; }
    }
}
