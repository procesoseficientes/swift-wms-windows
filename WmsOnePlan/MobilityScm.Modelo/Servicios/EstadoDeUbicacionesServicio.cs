
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Utilerias;
using Telerik.OpenAccess.Data.Common;

namespace MobilityScm.Modelo.Servicios
{
    public class EstadoDeUbicacionesServicio : IEstadoDeUbicacionesServicio
    {
        public IBaseDeDatosServicio BaseDeDatosServicio { get; set; }

        public EstadoDeUbicacionesServicio(IBaseDeDatosServicio baseDeDatosServicio)
        {
            BaseDeDatosServicio = baseDeDatosServicio;
        }
        public IList<Ubicacion> ObtenerEstadoDeUbicaciones(EstadoDeUbicacionArgumento arg)
        {
            DbParameter[] parameters =
        {
               new OAParameter
               {
                   ParameterName = "@WAREHOUSE",
                   Value = string.IsNullOrEmpty( arg.Bodega)? null : arg.Bodega
               },
               new OAParameter
               {
                   ParameterName = "@ZONE",
                   Value =  string.IsNullOrEmpty( arg.Zona )? null : arg.Zona
               },
                new OAParameter
               {
                   ParameterName = "@SPOT_TYPE",
                   Value = string.IsNullOrEmpty( arg.TipoUbicacion)? null : arg.TipoUbicacion
               }
           };
            return BaseDeDatosServicio.ExecuteQuery<Ubicacion>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_LOCATION_STATUS", CommandType.StoredProcedure, parameters);
        }
    }
}
