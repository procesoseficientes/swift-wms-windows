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
    public class CosteoServicio : ICosteoServicio
    {
        public IBaseDeDatosServicio BaseDeDatosServicio { get; set; }

        public CosteoServicio(IBaseDeDatosServicio baseDeDatosServicio)
        {
            BaseDeDatosServicio = baseDeDatosServicio;
        }

        public Operacion GrabarPolizaDetalle(CosteoArgumento costeoArgumento)
        {
            return (costeoArgumento.PolizaDetalle.LINE_NUMBER == 0)
                ? InsertarPolizaDetalle(costeoArgumento)
                : ActualizarPolizaDetalle(costeoArgumento);
        }

        public Operacion InsertarPolizaDetalle(CosteoArgumento costeoArgumento)
        {
            try
            {
                DbParameter[] parameters = {
                   new OAParameter
                   {
                       ParameterName = "@DOC_ID",
                       Value = costeoArgumento.PolizaDetalle.DOC_ID
                   },
                   new OAParameter
                   {
                       ParameterName = "@SKU_DESCRIPTION",
                       Value = costeoArgumento.PolizaDetalle.SKU_DESCRIPTION
                   }
                   ,
                   new OAParameter
                   {
                       ParameterName = "@QTY",
                       Value = costeoArgumento.PolizaDetalle.QTY
                   }
                   ,
                   new OAParameter
                   {
                       ParameterName = "@CUSTOMS_AMOUNT",
                       Value = costeoArgumento.PolizaDetalle.CUSTOMS_AMOUNT
                   }
                   ,
                   new OAParameter
                   {
                       ParameterName = "@CLIENT_CODE",
                       Value = costeoArgumento.PolizaDetalle.CLIENT_CODE
                   }
                   ,
                   new OAParameter
                   {
                       ParameterName = "@MATERIAL_ID",
                       Value = costeoArgumento.PolizaDetalle.MATERIAL_ID
                   }
                   ,
                   new OAParameter
                   {
                       ParameterName = "@UNITARY_PRICE",
                       Value = costeoArgumento.PolizaDetalle.UNITARY_PRICE
                   }
                   ,
                   new OAParameter
                   {
                       ParameterName = "@LOGIN",
                       Value = costeoArgumento.Login
                   }
                };
                var op = BaseDeDatosServicio.ExecuteQuery<Operacion>(BaseDeDatosServicio.Esquema + ".OP_WMS_INSERT_POLIZA_DETAIL_GENERAL", CommandType.StoredProcedure, parameters)[0];
                if (op.Resultado == ResultadoOperacionTipo.Error)
                {
                    throw new Exception("Ocurrió un error al autorizar picking ERP: " + op.Mensaje);
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

        public Operacion ActualizarPolizaDetalle(CosteoArgumento costeoArgumento)
        {
            try
            {
                DbParameter[] parameters = {
                   new OAParameter
                   {
                       ParameterName = "@DOC_ID",
                       Value = costeoArgumento.PolizaDetalle.DOC_ID
                   },
                   new OAParameter
                   {
                       ParameterName = "@SKU_DESCRIPTION",
                       Value = costeoArgumento.PolizaDetalle.SKU_DESCRIPTION
                   }
                   ,
                   new OAParameter
                   {
                       ParameterName = "@QTY",
                       Value = costeoArgumento.PolizaDetalle.QTY
                   }
                   ,
                   new OAParameter
                   {
                       ParameterName = "@CUSTOMS_AMOUNT",
                       Value = costeoArgumento.PolizaDetalle.CUSTOMS_AMOUNT
                   }
                   ,
                   new OAParameter
                   {
                       ParameterName = "@CLIENT_CODE",
                       Value = costeoArgumento.PolizaDetalle.CLIENT_CODE
                   }
                   ,
                   new OAParameter
                   {
                       ParameterName = "@LINE_NUMBER",
                       Value = costeoArgumento.PolizaDetalle.LINE_NUMBER
                   }
                    ,
                   new OAParameter
                   {
                       ParameterName = "@UNITARY_PRICE",
                       Value = costeoArgumento.PolizaDetalle.UNITARY_PRICE
                   }
                   ,
                   new OAParameter
                   {
                       ParameterName = "@LOGIN",
                       Value = costeoArgumento.Login
                   }
                };
                var op = BaseDeDatosServicio.ExecuteQuery<Operacion>(BaseDeDatosServicio.Esquema + ".OP_WMS_UPDATE_POLIZA_DETAIL_GENERAL", CommandType.StoredProcedure, parameters)[0];
                if (op.Resultado == ResultadoOperacionTipo.Error)
                {
                    throw new Exception("Ocurrió un error al autorizar picking ERP: " + op.Mensaje);
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

        public Operacion ActualizarPolizaEncabezado(CosteoArgumento costeoArgumento)
        {
            try
            {
                DbParameter[] parameters = {
                   new OAParameter
                   {
                       ParameterName = "@DOC_ID",
                       Value = costeoArgumento.Poliza.DOC_ID
                   },
                   new OAParameter
                   {
                       ParameterName = "@POLIZA_ASEGURADA",
                       Value = costeoArgumento.Poliza.POLIZA_ASEGURADA
                   }
                   ,
                   new OAParameter
                   {
                       ParameterName = "@ACUERDO_COMERCIAL",
                       Value = costeoArgumento.Poliza.ACUERDO_COMERCIAL_ID.ToString()
                   }
                   ,
                   new OAParameter
                   {
                       ParameterName = "@LOGIN",
                       Value = costeoArgumento.Login
                   }
                };
                var op = BaseDeDatosServicio.ExecuteQuery<Operacion>(BaseDeDatosServicio.Esquema + ".OP_WMS_UPDATE_POLIZA_HEADER_GENERAL", CommandType.StoredProcedure, parameters)[0];
                if (op.Resultado == ResultadoOperacionTipo.Error)
                {
                    throw new Exception("Ocurrió un error al autorizar picking ERP: " + op.Mensaje);
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

        public IList<PolizaDetalle> ObtenerPolizasDetallePendientesDeAutorizar(CosteoArgumento costeoArgumento)
        {
            DbParameter[] parameters = {
                new OAParameter
                {
                    ParameterName = "@CODE_POLIZA",
                    Value =  costeoArgumento.Poliza.CODIGO_POLIZA
                }
            };
            return BaseDeDatosServicio.ExecuteQuery<PolizaDetalle>(BaseDeDatosServicio.Esquema + ".OP_WMS_GET_POLIZA_DETAIL_HISTORIAL_SUGGESTED_COST", CommandType.StoredProcedure, true, parameters).ToList();
        }

        public IList<Poliza> ObtenerPolizasEncabezadosPendientesDeAutorizar(CosteoArgumento costeoArgumento)
        {
            DbParameter[] parameters = {
                new OAParameter
                {
                    ParameterName = "@START_DATE",
                    Value =  costeoArgumento.FechaInicial
                },new OAParameter
                {
                    ParameterName = "@END_DATE",
                    Value =  costeoArgumento.FechaFinal
                },new OAParameter
                {
                    ParameterName = "@LOGIN",
                    Value =  costeoArgumento.Login
                }
            };
            return BaseDeDatosServicio.ExecuteQuery<Poliza>(BaseDeDatosServicio.Esquema + ".OP_WMS_GET_POLIZA_HEADER_PENDING_AUTHORIZED", CommandType.StoredProcedure, true, parameters).ToList();
        }
    }
}
