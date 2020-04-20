using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilityScm.Modelo.Entidades
{
    public class ResumenInventarioProyecto
    {
        public string MATERIAL_ID { get; set; }

        public string MATERIAL_NAME { get; set; }

        public decimal QTY { get; set; }

        public decimal QTY_PENDING { get; set; }

        public decimal QTY_DISPACHT { get; set; }

        public decimal QTY_RESERVED_PICKING { get; set; }

        public List<InventarioReservadoProyecto> Licencias { get; set; }
    }
}
