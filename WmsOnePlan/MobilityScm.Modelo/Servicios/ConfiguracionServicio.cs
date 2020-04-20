using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Utilerias;
using Telerik.OpenAccess.Data.Common;

namespace MobilityScm.Modelo.Servicios
{
    public class ConfiguracionServicio : IConfiguracionServicio
    {
        public IBaseDeDatosServicio BaseDeDatosServicio { get; set; }

        public ConfiguracionServicio(IBaseDeDatosServicio baseDeDatosServicio)
        {
            BaseDeDatosServicio = baseDeDatosServicio;
        }
        public IList<Entidades.Configuracion> ObtenerConfiguracionesGrupoYTipo(MobilityScm.Modelo.Entidades.Configuracion configuracion)
        {
            DbParameter[] parameters =
          {
               new OAParameter
               {
                   ParameterName = "@PARAM_TYPE",
                   Value = configuracion.PARAM_TYPE
               }
               ,new OAParameter
               {
                   ParameterName = "@PARAM_GROUP",
                   Value = configuracion.PARAM_GROUP
               }

           };
            return BaseDeDatosServicio.ExecuteQuery<Entidades.Configuracion>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_CONFIGURATIONS", CommandType.StoredProcedure, parameters).ToList();
        }

        public IList<Entidades.Configuracion> ObtenerCentrosDeDistribucion(Entidades.Configuracion configuracion)
        {
            return BaseDeDatosServicio.ExecuteQuery<Entidades.Configuracion>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_DISTRIBUTION_CENTER", CommandType.StoredProcedure, false, null).ToList();
        }

        public IList<Entidades.Configuracion> ObtenerCentrosDeDistribucionPorLogin(Entidades.Configuracion configuracion)
        {
            DbParameter[] parameters =
            {
                new OAParameter
                {
                    ParameterName = "@LOGIN",
                    Value = configuracion.LOGIN
                }
            };
            return BaseDeDatosServicio.ExecuteQuery<Entidades.Configuracion>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_DISTRIBUTION_CENTER_ASSOCIATED_TO_USER", CommandType.StoredProcedure, false, parameters).ToList();

        }

        public IList<Entidades.Configuracion> ObtenerTiposSolicitudDeTraslado(Entidades.Configuracion configuracion)
        {
            return BaseDeDatosServicio.ExecuteQuery<Entidades.Configuracion>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_TRANSFER_TYPES", CommandType.StoredProcedure, false, null).ToList();
        }
    }
}
