using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Utilerias;
using Telerik.OpenAccess.Data.Common;

namespace MobilityScm.Modelo.Servicios
{
    public class ParametroServicio : IParametroServicio
    {
        public IBaseDeDatosServicio BaseDeDatosServicio { get; set; }

        public ParametroServicio(IBaseDeDatosServicio baseDeDatosServicio)
        {
            BaseDeDatosServicio = baseDeDatosServicio;
        }

        public IList<Parametro> ObtenerParametro(ConsultaArgumento argumento)
        {
            DbParameter[] parameters =
               {
                   new OAParameter
                   {
                       ParameterName = "@GROUP_ID",
                       Value = argumento.GrupoParametro
                   }
                   ,
                   new OAParameter
                   {
                       ParameterName = "@PARAMETER_ID",
                       Value = argumento.IdParametro
                   }
               };
            return BaseDeDatosServicio.ExecuteQuery<Parametro>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_PARAMETER", CommandType.StoredProcedure, parameters).ToList();
        }
    }
}
