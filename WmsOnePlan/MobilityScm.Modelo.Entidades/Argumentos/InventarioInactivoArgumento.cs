using System;

namespace MobilityScm.Modelo.Argumentos
{
    public class InventarioInactivoArgumento : EventArgs
    {
        public string Login { get; set; }
        public string WarehouseXml { get; set; }
        public string ZoneXml { get; set; }
        public string MaterialXml { get; set; }
        public DateTime DateWarehouseIndices { get; set; }
    }
}
