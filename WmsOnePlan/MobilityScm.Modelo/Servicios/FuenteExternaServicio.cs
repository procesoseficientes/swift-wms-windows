using MobilityScm.Modelo.Interfaces.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Utilerias;
using System.Data;

namespace MobilityScm.Modelo.Servicios
{
    /// <summary>
    /// Servicio de fuente externa 
    /// </summary>
    public class FuenteExternaServicio : IFuenteExternaServicio
    {

        /// <summary>
        /// IBase de datos servicio
        /// </summary>
        public IBaseDeDatosServicio BaseDeDatosServicio { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="baseDeDatosServicio"></param>
        public FuenteExternaServicio(IBaseDeDatosServicio baseDeDatosServicio)
        {
            BaseDeDatosServicio = baseDeDatosServicio;
        }

        public IList<FuenteExterna> ObtenerFuentesExternas()
        {
            return BaseDeDatosServicio.ExecuteQuery<FuenteExterna>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_CLIENTS_FROM_EXTERNAL_SOURCE", CommandType.StoredProcedure, null);
        }
    }
}
