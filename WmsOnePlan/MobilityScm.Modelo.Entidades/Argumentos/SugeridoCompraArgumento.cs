using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilityScm.Modelo.Argumentos
{
    public class SugeridoCompraArgumento : EventArgs
    {
        public string Login { get; set; }
        public string WarehouseXml { get; set; }
        public string ZoneXml { get; set; }
        public string MaterialXml { get; set; }
        public DateTime DateWarehouseIndices { get; set; }
    }
}
