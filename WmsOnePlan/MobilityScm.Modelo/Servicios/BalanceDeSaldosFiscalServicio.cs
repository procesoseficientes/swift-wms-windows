using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Utilerias;
using Telerik.OpenAccess.Data.Common;

namespace MobilityScm.Modelo.Servicios
{
    public class BalanceDeSaldosFiscalServicio : IBalanceDeSaldosFiscalServicio
    {
        public IBaseDeDatosServicio BaseDeDatosServicio { get; set; }

        public BalanceDeSaldosFiscalServicio(IBaseDeDatosServicio baseDeDatosServicio)
        {
            BaseDeDatosServicio = baseDeDatosServicio;
        }
        public IList<BalanceDeSaldosFiscal> ObtenerAcuerdosComerciales(BalanceDeSaldosFiscalArgumento acuerdoComercialArgumento)
        {
            DbParameter[] parameters =
          {
               new OAParameter
               {
                   ParameterName = "@LOGIN",
                   Value = acuerdoComercialArgumento.Usuario
               }

           };
            return BaseDeDatosServicio.ExecuteQuery<BalanceDeSaldosFiscal>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_BALANCE_OF_PAYMENTS_BY_FISCAL", CommandType.StoredProcedure, parameters).ToList();
        }
    }
}
