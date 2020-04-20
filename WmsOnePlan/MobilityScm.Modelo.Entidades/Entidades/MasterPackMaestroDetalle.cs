
using System;

namespace MobilityScm.Modelo.Entidades
{
    /// <summary>
    /// Entidad de maestro detalle junto de master pack
    /// </summary>
    public class MasterPackMaestroDetalle
    {
        /// <summary>
        /// Bodega
        /// </summary>
        public string CURRENT_WAREHOUSE { get; set; }
        /// <summary>
        /// licencia
        /// </summary>
        public int LICENSE_ID { get; set; }

        /// <summary>
        /// ubicación
        /// </summary>
        public string CURRENT_LOCATION { get; set; }

        /// <summary>
        /// Masterpack codigo
        /// </summary>
        public string MASTER_PACK_MATERIAL_ID { get; set; }

        /// <summary>
        /// Masterpack description
        /// </summary>
        public string MASTER_PACK_DESCRIPTION { get; set; }
        /// <summary>
        /// Componente codigo
        /// </summary>
        public string MATERIAL_ID { get; set; }

        /// <summary>
        /// Componente nombre
        /// </summary>
        public string MATERIAL_NAME { get; set; }
        /// <summary>
        /// cantiudad
        /// </summary>
        public int QTY { get; set; }

        /// <summary>
        /// ultima actualizacion
        /// </summary>
        public DateTime LAST_UPDATED { get; set; }

        /// <summary>
        /// fecha de expiración
        /// </summary>
        public DateTime DATE_EXPIRATION { get; set; }
        /// <summary>
        /// Lote  
        /// </summary>
        public string BATCH { get; set; }
        /// <summary>
        /// cantiudad componentes
        /// </summary>
        public int QTY_COMPONENT { get; set; }

        public string STATUS_NAME { get; set; }

        public string BLOCKS_INVENTORY { get; set; }

        public string COLOR { get; set; }

    }
}
