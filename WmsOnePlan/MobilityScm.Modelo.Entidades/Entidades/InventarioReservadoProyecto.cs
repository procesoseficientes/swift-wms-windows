using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilityScm.Modelo.Entidades
{
    public class InventarioReservadoProyecto
    {
        public int ID { get; set; }

        public Guid PROJECT_ID { get; set; }

        public decimal PK_LINE { get; set; }

        public decimal LICENSE_ID { get; set; }

        public string MATERIAL_ID { get; set; }

        public string MATERIAL_NAME { get; set; }

        public decimal QTY { get; set; }

        public decimal QTY_AVAILABLE { get; set; }

        public string STATUS_CODE { get; set; }

        public decimal QTY_LICENSE { get; set; }

        public decimal QTY_RESERVED { get; set; }

        public decimal QTY_DISPATCHED { get; set; }

        public decimal QTY_PENDING { get; set; }

        public decimal RESERVED_PICKING { get; set; }

        public string TONE { get; set; }

        public string CALIBER { get; set; }

        public string BATCH { get; set; }

        public DateTime? DATE_EXPIRATION { get; set; }

        public bool IS_SELECTED { get; set; }
    }
}
