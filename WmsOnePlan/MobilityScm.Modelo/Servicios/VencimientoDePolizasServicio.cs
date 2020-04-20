using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Modelo.Tipos;
using MobilityScm.Utilerias;
using MobilityScm.Vertical.Entidades;
using Telerik.OpenAccess.Data.Common;

namespace MobilityScm.Modelo.Servicios
{
    public class VencimientoDePolizasServicio : IVencimientoDePolizasServicio
    {
        public IBaseDeDatosServicio BaseDeDatosServicio { get; set; }

        public VencimientoDePolizasServicio(IBaseDeDatosServicio baseDeDatosServicio)
        {
            BaseDeDatosServicio = baseDeDatosServicio;
        }

        public Operacion DesbloquearPoliza(PolizaArgumento polizaArgumento)
        {
            DbParameter[] parameters = {
                   new OAParameter
                   {
                       ParameterName = "@POLIZA_HEADER_ID",
                       Value = polizaArgumento.Poliza.DOC_ID
                   },
                   new OAParameter
                   {
                       ParameterName = "@UNBLOCK_DOCUMENT",
                       Value = polizaArgumento.Poliza.UNLOCK_DOCUMENT
                   },
                   new OAParameter
                   {
                       ParameterName = "@UNBLOCK_COMMENT",
                       Value = polizaArgumento.Poliza.UNLOCK_COMMENT
                   },
                   new OAParameter
                   {
                       ParameterName = "@LOGIN",
                       Value = polizaArgumento.Poliza.UNLOCK_USER
                   }
                };
            var op = BaseDeDatosServicio.ExecuteQuery<Operacion>(BaseDeDatosServicio.Esquema + ".OP_WMS_UNBLOCK_POLIZA", CommandType.StoredProcedure,parameters)[0];
            if (op.Resultado == ResultadoOperacionTipo.Error)
            {
                throw new Exception("Ocurrió un error al desbloquear la póliza: " + op.Mensaje);
            }
            return op;
        }

        public IList<Poliza> ObtenerPolizasListasAExpirar(PolizaArgumento polizaArgumento)
        {
            DbParameter[] parameters = {
                new OAParameter
                {
                    ParameterName = "@DAYS",
                    Value =  polizaArgumento.DAYS
                },
                new OAParameter
                {
                    ParameterName = "@START_DATETIME",
                    Value =  polizaArgumento.START_DATE
                },
                new OAParameter
                {
                    ParameterName = "@END_DATETIME",
                    Value = polizaArgumento.END_DATE
                },
               new OAParameter
                {
                    ParameterName = "@CUSTOMER",
                    Value = polizaArgumento.CUSTOMER
                },
               new OAParameter
               {
                   ParameterName = "@BLOCKED_ONLY",
                   Value = polizaArgumento.BLOCKED_ONLY
               },
            };
            return BaseDeDatosServicio.ExecuteQuery<Poliza>
                (BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_POLIZAS_FOR_EXPIRATION", CommandType.StoredProcedure, true, parameters).ToList();
        }
    }
}
