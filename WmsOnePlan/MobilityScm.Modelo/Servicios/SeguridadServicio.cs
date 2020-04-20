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
    public class SeguridadServicio : ISeguridadServicio
    {
        public IBaseDeDatosServicio BaseDeDatosServicio { get; set; }

        public SeguridadServicio(IBaseDeDatosServicio baseDeDatosServicio)
        {
            BaseDeDatosServicio = baseDeDatosServicio;
        }

        public IList<Seguridad> ObtenerPermisosDeSeguridad(SeguridadArgumento seguridadArgumento)
        {
            DbParameter[] parameters = {
                new OAParameter
                {
                    ParameterName = "@PARENT",
                    Value =  seguridadArgumento.Seguridad.PARENT
                },
                new OAParameter
                {
                    ParameterName = "@CATEGORY",
                    Value =  seguridadArgumento.Seguridad.CATEGORY
                },
                new OAParameter
                {
                    ParameterName = "@LOGIN",
                    Value =  seguridadArgumento.Seguridad.LOGIN
                }
            };
            return BaseDeDatosServicio.ExecuteQuery<Seguridad>
                (BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_SECURITY_ACCESS", CommandType.StoredProcedure, true, parameters).ToList();
        }
    }
}
