using MobilityScm.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobilityScm.Modelo.Interfaces.Servicios
{
    /// <summary>
    /// Interfaz servicio de fuente externa
    /// </summary>
   public  interface IFuenteExternaServicio
    {
        /// <summary>
        /// Obtener fuentes
        /// </summary>
        /// <returns></returns>
        IList<FuenteExterna> ObtenerFuentesExternas();
    }
}
