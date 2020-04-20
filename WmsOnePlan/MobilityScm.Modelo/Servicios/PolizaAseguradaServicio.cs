using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Utilerias;
using MobilityScm.Vertical.Entidades;
using Telerik.OpenAccess.Data.Common;

namespace MobilityScm.Modelo.Servicios
{
    public class PolizaAseguradaServicio : IPolizaAseguradaServicio
    {
        public IBaseDeDatosServicio BaseDeDatosServicio { get; set; }

        public PolizaAseguradaServicio(IBaseDeDatosServicio baseDeDatosServicio)
        {
            BaseDeDatosServicio = baseDeDatosServicio;
        }

        public IList<PolizaAsegurada> ObtenerPolizaAseguradaPorCliente(PolizaAsegurada polizaAsegurada)
        {
            DbParameter[] parameters =
          {
               new OAParameter
               {
                   ParameterName = "@CODE_CLIENT",
                   Value = polizaAsegurada.CLIENT_CODE
               }

           };
            return BaseDeDatosServicio.ExecuteQuery<PolizaAsegurada>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_INSURANCE_DOC_BY_CLIENT", CommandType.StoredProcedure, parameters).ToList();
        }
    }
}
