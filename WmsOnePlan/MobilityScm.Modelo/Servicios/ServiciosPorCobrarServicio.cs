using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Utilerias;
using Telerik.OpenAccess.Data.Common;
using MobilityScm.Modelo.Tipos;
using Operacion = MobilityScm.Vertical.Entidades.Operacion;

namespace MobilityScm.Modelo.Servicios
{
    public class ServiciosPorCobrarServicio : IServiciosPorCobrarServicio
    {
        public IBaseDeDatosServicio BaseDeDatosServicio { get; set; }

        public ServiciosPorCobrarServicio(IBaseDeDatosServicio baseDeDatosServicio)
        {
            BaseDeDatosServicio = baseDeDatosServicio;
        }

        public IList<ServicioPorCobrar> ConsultarServiciosPorCobrarPorFecha(DateTime fechaInicio, DateTime fechaFin, ServicioPorCobrar servicioPorCobrar)
        {
            DbParameter[] parameters = {
                                           new OAParameter
                                           {
                                               ParameterName = "@INICIAL_DATE",
                                               Value = fechaInicio
                                           },
                                           new OAParameter
                                           {
                                               ParameterName = "@FINAL_DATE"
                                               ,Value = fechaFin
                                           },
                                           new OAParameter
                                           {
                                               ParameterName = "@CLIENT_CODE"
                                               ,Value = servicioPorCobrar.CLIENT_CODE
                                           },
                                           new OAParameter
                                           {
                                               ParameterName = "@IS_CHARGED"
                                               ,
                                               Value = servicioPorCobrar.IS_CHARGED
                                           }

                };
            return BaseDeDatosServicio.ExecuteQuery<ServicioPorCobrar>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_SERVICE_TO_BILL_BY_DATES", CommandType.StoredProcedure, parameters);
        }

        public Operacion EjecutarProcesoServiciosPorCobrar(string login)
        {
            DbParameter[] parameters = {
                                           new OAParameter
                                           {
                                               ParameterName = "@TYPE",
                                               Value = "ON_DEMAND"
                                           },
                                           new OAParameter
                                           {
                                               ParameterName = "@LAST_UPDATED_BY"
                                               ,Value = login
                                           },

                };
            var op = BaseDeDatosServicio.ExecuteQuery<Operacion>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_PROCESS_CHARGE_SERVICES", CommandType.StoredProcedure, parameters)[0];
            return op;
        }

        public Operacion ModificarServicioPorCobrar(ServicioPorCobrar servicioPorCobrar)
        {
            BaseDeDatosServicio.BeginTransaction();
            try
            {
                DbParameter[] parameters ={
                    new OAParameter
                    {
                        ParameterName = "@SERVICES_TO_BILL_ID",
                        Value = servicioPorCobrar.SERVICES_TO_BILL_ID
                    }
                   ,
                    new OAParameter
                    {
                        ParameterName = "@QTY",
                        Value = servicioPorCobrar.QTY == new decimal()? (decimal?)null: servicioPorCobrar.QTY
                    }
                    ,
                    new OAParameter
                    {
                        ParameterName = "@TRANSACTION_TYPE",
                        Value = servicioPorCobrar.TRANSACTION_TYPE
                    }
                    ,
                    new OAParameter
                    {
                        ParameterName = "@PRICE",
                        Value = (servicioPorCobrar.IS_CHARGED == 0)?( servicioPorCobrar.PRICE_TO_CHANGE): (servicioPorCobrar.PRICE)
                    }
                    ,
                    new OAParameter
                    {
                        ParameterName = "@TOTAL_AMOUNT",
                        Value = servicioPorCobrar.TOTAL_AMOUNT
                    }
                    ,
                    new OAParameter
                    {
                        ParameterName = "@PROCESS_DATE",
                        Value = servicioPorCobrar.PROCESS_DATE  == new DateTime()? (DateTime?)null: servicioPorCobrar.PROCESS_DATE
                    }
                    ,
                    new OAParameter
                    {
                        ParameterName = "@LAST_UPDATED_BY",
                        Value = servicioPorCobrar.LAST_UPDATED_BY
                    }
                    ,
                    new OAParameter
                    {
                        ParameterName = "@TYPE_CHARGE_ID",
                        Value = servicioPorCobrar.TYPE_CHARGE_ID
                    }
                    ,
                    new OAParameter
                    {
                        ParameterName = "@TYPE_CHARGE_DESCRIPTION",
                        Value = servicioPorCobrar.TYPE_CHARGE_DESCRIPTION
                    }
                    ,
                    new OAParameter
                    {
                        ParameterName = "@CLIENT_CODE",
                        Value = servicioPorCobrar.CLIENT_CODE
                    }
                    ,
                    new OAParameter
                    {
                        ParameterName = "@CLIENT_NAME",
                        Value = servicioPorCobrar.CLIENT_NAME
                    }
                    ,
                    new OAParameter
                    {
                        ParameterName = "@IS_CHARGED",
                        Value = servicioPorCobrar.IS_CHARGED
                    }
                    ,
                    new OAParameter
                    {
                        ParameterName = "@INVOICE_REFERENCE",
                        Value = servicioPorCobrar.INVOICE_REFERENCE
                    }
                    ,
                    new OAParameter
                    {
                        ParameterName = "@CHARGED_DATE",
                        Value = servicioPorCobrar.CHARGED_DATE
                    }

                    ,
                    new OAParameter
                    {
                        ParameterName = "@LICENSE_ID",
                        Value = servicioPorCobrar.LICENSE_ID
                    }
                    ,
                    new OAParameter
                    {
                        ParameterName = "@LOCATION",
                        Value = servicioPorCobrar.LOCATION
                    }
                    ,
                    new OAParameter
                    {
                        ParameterName = "@SERVICE_ID",
                        Value = servicioPorCobrar.SERVICE_ID
                    }
                    ,
                    new OAParameter
                    {
                        ParameterName = "@SERVICE_CODE",
                        Value = servicioPorCobrar.SERVICE_CODE
                    }
                    ,
                    new OAParameter
                    {
                        ParameterName = "@SERVICE_DESCRIPTION",
                        Value = servicioPorCobrar.SERVICE_DESCRIPTION
                    }
                    ,
                    new OAParameter
                    {
                        ParameterName = "@REGIMEN",
                        Value = servicioPorCobrar.REGIMEN
                    }
                    ,
                    new OAParameter
                    {
                        ParameterName = "@DOC_NUM",
                        Value = servicioPorCobrar.DOC_NUM
                    }
                    ,
                    new OAParameter
                    {
                        ParameterName = "@TRANSACTION_ID",
                        Value = servicioPorCobrar.TRANSACTION_ID
                    }
                };

                var op = BaseDeDatosServicio.ExecuteQuery<Operacion>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_UPDATE_SERVICE_TO_BILL", CommandType.StoredProcedure, parameters)[0];
                BaseDeDatosServicio.Commit();
                return op;
            }
            catch (DbException e)
            {
                BaseDeDatosServicio.Rollback();
                return new Operacion
                {
                    Codigo = e.ErrorCode,
                    Mensaje = e.Message,
                    Resultado = ResultadoOperacionTipo.Error
                };
            }
            catch (Exception ex)
            {
                BaseDeDatosServicio.Rollback();
                return new Operacion
                {
                    Codigo = -1,
                    Mensaje = ex.Message,
                    Resultado = ResultadoOperacionTipo.Error
                };
            }
        }
    }
}
