using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Modelo.Tipos;
using MobilityScm.Utilerias;
using MobilityScm.Vertical.Entidades;
using Telerik.OpenAccess.Data.Common;

namespace MobilityScm.Modelo.Servicios
{
    public class ConsultaCosteoServicio : IConsultaCosteoServicio
    {
        public IBaseDeDatosServicio BaseDeDatosServicio { get; set; }

        public ConsultaCosteoServicio(IBaseDeDatosServicio baseDeDatosServicio)
        {
            BaseDeDatosServicio = baseDeDatosServicio;
        }
        public Operacion AutorizarCosteoPoliza(CosteoArgumento costeoArgumento)
        {
            try
            {
                DbParameter[] parameters =
                {
                    new OAParameter
                    {
                        ParameterName = "@DOC_ID",
                        Value = costeoArgumento.PolizaDetalle.DOC_ID
                    },
                    new OAParameter
                    {
                        ParameterName = "@LINE_NUMBER",
                        Value = costeoArgumento.PolizaDetalle.LINE_NUMBER
                    },
                    new OAParameter
                    {
                        ParameterName = "@LOGIN",
                        Value = costeoArgumento.Login
                    }
                };
                var op = BaseDeDatosServicio.ExecuteQuery<Operacion>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_AUTHORIZE_COST", CommandType.StoredProcedure, false, parameters)[0];
                if (op.Resultado == ResultadoOperacionTipo.Error)
                {
                    throw new Exception("Ocurrió un error al autorizar costeo de poliza: " + op.Mensaje);
                }
                return op;
            }
            catch (Exception ex)
            {
                return new Operacion
                {
                    Codigo = -1,
                    Mensaje = ex.Message,
                    Resultado = ResultadoOperacionTipo.Error
                };
            }
        }

        public IList<PolizaMaestroDetalle> ObtenerPolizasMaestroDetallePendientesDeAutorizar(CosteoArgumento costeoArgumento)
        {
            DbParameter[] parameters = {
                new OAParameter
                {
                    ParameterName = "@START_DATE",
                    Value =  costeoArgumento.FechaInicial
                }
                ,new OAParameter
                {
                    ParameterName = "@END_DATE",
                    Value =  costeoArgumento.FechaFinal
                }
                ,new OAParameter
                {
                    ParameterName = "@LOGIN",
                    Value =  costeoArgumento.Login
                }
                ,new OAParameter
                {
                    ParameterName = "@WAREHOUSES_ID",
                    Value =  costeoArgumento.Warehouses
                }

            };
            return BaseDeDatosServicio.ExecuteQuery<PolizaMaestroDetalle>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_POLIZA_TO_AUTHORIZE", CommandType.StoredProcedure, true, parameters).ToList();
        }

    }
}
