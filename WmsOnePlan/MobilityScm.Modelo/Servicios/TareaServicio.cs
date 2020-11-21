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
    public class TareaServicio : ITareaServicio
    {

        public IBaseDeDatosServicio BaseDeDatosServicio { get; set; }

        public TareaServicio(IBaseDeDatosServicio baseDeDatosServicio)
        {
            BaseDeDatosServicio = baseDeDatosServicio;
        }
        public Operacion AutorizarDocumentoErpPicking(TareaArgumento tareaArgumento)
        {
            try
            {
                DbParameter[] parameters = {
                   new OAParameter
                   {
                       ParameterName = "@WAVE_PICKING_ID",
                       Value = tareaArgumento.Tarea.WAVE_PICKING_ID
                   },
                   new OAParameter
                   {
                       ParameterName = "@LAST_UPDATE_BY",
                       Value = tareaArgumento.Login
                   }
                };
                var op = BaseDeDatosServicio.ExecuteQuery<Operacion>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_AUTHORIZE_ERP_PICKING_DOCUMENT", CommandType.StoredProcedure, true, parameters)[0];
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

        public Operacion AutorizarDocumentoErpConteoFisico(TareaArgumento tareaArgumento)
        {
            try
            {
                DbParameter[] parameters = {
                   new OAParameter
                   {
                       ParameterName = "@PHYSICAL_COUNT_HEADER_ID",
                       Value = tareaArgumento.Tarea.PHYSICAL_COUNT_HEADER_ID

                   }
                   // new OAParameter
                   //{
                   //    ParameterName = "@LAST_UPDATE_BY",
                   //    Value = tareaArgumento.Login
                   //}

                };
                var op = BaseDeDatosServicio.ExecuteQuery<Operacion>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_AUTHORIZE_ERP_COUNT_DOCUMENT", CommandType.StoredProcedure, true, parameters)[0];
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

        public Operacion AutorizarDocumentoErpRecepcion(TareaArgumento tareaArgumento)
        {
            try
            {
                DbParameter[] parameters = {
                   new OAParameter
                   {
                       ParameterName = "@ERP_RECEPTION_DOCUMENT_HEADER_ID",
                       Value = tareaArgumento.Tarea.WMS_DOCUMENT_HEADER_ID
                   },
                   new OAParameter
                   {
                       ParameterName = "@LAST_UPDATE_BY",
                       Value = tareaArgumento.Login
                   }
                };
                var op = BaseDeDatosServicio.ExecuteQuery<Operacion>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_AUTHORIZE_ERP_RECEPTION_DOCUMENT", CommandType.StoredProcedure, true, parameters)[0];
                if (op.Resultado == ResultadoOperacionTipo.Error)
                {
                    throw new Exception("Ocurrió un error al autorizar recepcion ERP: " + op.Mensaje);
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

        public Operacion CambiarEstadoDeTarea(TareaArgumento tareaArgumento)
        {
            try
            {
                DbParameter[] parameters = {
                   new OAParameter
                   {
                       ParameterName = "@NEW_STATUS",
                       Value = tareaArgumento.Tarea.IS_PAUSED
                   },
                   new OAParameter
                   {
                       ParameterName = "@SERIAL_NUMBER",
                       Value = tareaArgumento.Tarea.SERIAL_NUMBER
                   }
                   ,
                   new OAParameter
                   {
                       ParameterName = "@WAVE_PICKING_ID",
                       Value = tareaArgumento.Tarea.WAVE_PICKING_ID
                   }
                };
                var op = BaseDeDatosServicio.ExecuteQuery<Operacion>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_UPDATE_STATUS_TASK", CommandType.StoredProcedure, true, parameters)[0];
                if (op.Resultado == ResultadoOperacionTipo.Error)
                {
                    throw new Exception("Ocurrió un error al cambiar el estado de la tarea: " + op.Mensaje);
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

        public Operacion CambiarOperadorDeTarea(TareaArgumento tareaArgumento)
        {
            try
            {
                DbParameter[] parameters = {
                   new OAParameter
                   {
                       ParameterName = "@TASK_ASSIGNEDTO",
                       Value = tareaArgumento.Tarea.TASK_ASSIGNEDTO
                   },
                   new OAParameter
                   {
                       ParameterName = "@SERIAL_NUMBER",
                       Value = tareaArgumento.Tarea.SERIAL_NUMBER
                   },
                   new OAParameter
                   {
                       ParameterName = "@WAVE_PICKING_ID",
                       Value = tareaArgumento.Tarea.WAVE_PICKING_ID
                   },
                   new OAParameter
                   {
                       ParameterName = "@MATERIAL_ID",
                       Value = tareaArgumento.Tarea.MATERIAL_ID
                   }
                };
                var op = BaseDeDatosServicio.ExecuteQuery<Operacion>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_UPDATE_ASSIGNED_TASK_USER", CommandType.StoredProcedure, true, parameters)[0];
                if (op.Resultado == ResultadoOperacionTipo.Error)
                {
                    throw new Exception("Ocurrió un error al cambiar el estado de la tarea: " + op.Mensaje);
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

        public Operacion CambiarOperadorDeTareaConteo(TareaArgumento tareaArgumento)
        {
            try
            {
                DbParameter[] parameters = {
                   new OAParameter
                   {
                       ParameterName = "@PHYSICAL_COUNT_DETAIL_ID",
                       Value = tareaArgumento.Tarea.TASK_ID
                   },
                   new OAParameter
                   {
                       ParameterName = "@ASSIGNED_TO",
                       Value = tareaArgumento.Tarea.TASK_ASSIGNEDTO
                   }
                };
                var op = BaseDeDatosServicio.ExecuteQuery<Operacion>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_UPDATE_ASSIGNED_OPERATOR_TO_COUNT_DETAIL", CommandType.StoredProcedure, true, parameters)[0];
                if (op.Resultado == ResultadoOperacionTipo.Error)
                {
                    throw new Exception("Ocurrió un error al cambiar el operador de la tarea: " + op.Mensaje);
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

        public Operacion CancelarDetallePicking(TareaArgumento tareaArgumento)
        {
            try
            {
                DbParameter[] parameters = {
                   new OAParameter
                   {
                       ParameterName = "@LOGIN_ID",
                       Value = tareaArgumento.Login
                   },
                   new OAParameter
                   {
                       ParameterName = "@WAVE_PICKING_ID",
                       Value = tareaArgumento.Tarea.WAVE_PICKING_ID
                   },
                   new OAParameter
                   {
                       ParameterName = "@MATERIAL_ID",
                       Value = tareaArgumento.Tarea.MATERIAL_ID
                   }

                };
                var op = BaseDeDatosServicio.ExecuteQuery<Operacion>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_CANCEL_PICKING_DETAIL_LINE_BO", CommandType.StoredProcedure, parameters)[0];
                if (op.Resultado == ResultadoOperacionTipo.Error)
                {
                    throw new Exception("Ocurrió un error al cancelar detalle de picking: " + op.Mensaje);
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

        public IList<TareaDetalle> ObtenerTareaDetalle(TareaArgumento tareaArgumento)
        {
            if (tareaArgumento.Tarea.TASK_TYPE == "TAREA_PICKING")
            {
                DbParameter[] parameters =
                {
                    new OAParameter
                    {
                        ParameterName = "@WAVE_PICKING_ID",
                        Value = tareaArgumento.Tarea.WAVE_PICKING_ID
                    },
                    new OAParameter
                    {
                        ParameterName = "@LOGIN",
                        Value = tareaArgumento.Login
                    },
                    new OAParameter
                    {
                        ParameterName = "@CLASS",
                        Value = tareaArgumento.Clases
                    }
                };
                return BaseDeDatosServicio.ExecuteQuery<TareaDetalle>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_TASK_DETAIL_FOR_PICKING", CommandType.StoredProcedure, true, parameters).ToList();
            }

            if (tareaArgumento.Tarea.TASK_TYPE == "TAREA_REUBICACION")
            {
                DbParameter[] parameters =
                {
                    new OAParameter
                    {
                        ParameterName = "@WAVE_PICKING_ID",
                        Value = tareaArgumento.Tarea.WAVE_PICKING_ID
                    },
                    new OAParameter
                    {
                        ParameterName = "@LOGIN",
                        Value = tareaArgumento.Login
                    },
                    new OAParameter
                    {
                        ParameterName = "@CLASS",
                        Value = tareaArgumento.Clases
                    }
                };
                return BaseDeDatosServicio.ExecuteQuery<TareaDetalle>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_TASK_DETAIL_FOR_REALLOC", CommandType.StoredProcedure, true, parameters).ToList();
            }
            if (tareaArgumento.Tarea.TASK_TYPE == "TAREA_RECEPCION")
            {
                DbParameter[] parameters =
                               {
                    new OAParameter
                    {
                        ParameterName = "@SERIAL_NUMBER",
                        Value = tareaArgumento.Tarea.SERIAL_NUMBER
                    }
                };
                return BaseDeDatosServicio.ExecuteQuery<TareaDetalle>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_TASK_DETAIL_FOR_RECEPTION_CONSOLIDATED", CommandType.StoredProcedure, true, parameters).ToList();
            }
            if (tareaArgumento.Tarea.TASK_TYPE == "TAREA_CONTEO_FISICO")
            {
                DbParameter[] parameters =
               {
                    new OAParameter
                    {
                        ParameterName = "@TASK_ID",
                        Value = tareaArgumento.Tarea.TASK_ID
                    },
                    new OAParameter
                    {
                        ParameterName = "@LOGIN",
                        Value = tareaArgumento.Login
                    }
                };
                return BaseDeDatosServicio.ExecuteQuery<TareaDetalle>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_TASK_DETAIL_FOR_COUNT", CommandType.StoredProcedure, true, parameters).ToList();
            }
            return new List<TareaDetalle>();
        }

        public IList<Tarea> ObtenerTareasConDetalleDeMaterial(TareaArgumento tareaArgumento)
        {
            DbParameter[] parameters = {
                new OAParameter
                {
                    ParameterName = "@START_DATETIME",
                    Value =  tareaArgumento.FechaInicial
                },
                new OAParameter
                {
                    ParameterName = "@END_DATETIME",
                    Value =  tareaArgumento.FechaFinal
                },
                new OAParameter
                {
                    ParameterName = "@LOGIN",
                    Value = tareaArgumento.Login
                },
               new OAParameter
                {
                    ParameterName = "@USERS",
                    Value =  tareaArgumento.Users
                },
               new OAParameter
                {
                    ParameterName = "@TYPES",
                    Value = tareaArgumento.Types
                }
               ,
               new OAParameter
                {
                    ParameterName = "@CLASS",
                    Value = tareaArgumento.Clases
                }
            };
            return BaseDeDatosServicio.ExecuteQuery<Tarea>(BaseDeDatosServicio.Esquema + ".OP_WMS_GET_TASK_BASIC_VIEW_DETAILED", CommandType.StoredProcedure, true, parameters).ToList();
        }

        public IList<Tarea> ObtenerTareas(TareaArgumento tareaArgumento)
        {
            DbParameter[] parameters = {
                new OAParameter
                {
                    ParameterName = "@START_DATETIME",
                    Value =  tareaArgumento.FechaInicial
                },
                new OAParameter
                {
                    ParameterName = "@END_DATETIME",
                    Value =  tareaArgumento.FechaFinal
                },
                new OAParameter
                {
                    ParameterName = "@LOGIN",
                    Value = tareaArgumento.Login
                },
               new OAParameter
                {
                    ParameterName = "@USERS",
                    Value =  tareaArgumento.Users
                },
               new OAParameter
                {
                    ParameterName = "@TYPES",
                    Value = tareaArgumento.Types
                }
               ,
               new OAParameter
                {
                    ParameterName = "@CLASS",
                    Value = tareaArgumento.Clases
                }
            };
            return BaseDeDatosServicio.ExecuteQuery<Tarea>(BaseDeDatosServicio.Esquema + ".OP_WMS_GET_TASK_BASIC_VIEW", CommandType.StoredProcedure, true, parameters).ToList();
        }

        public IList<Tarea> ObtenerTareasParaGraficas(TareaArgumento tareaArgumento)
        {
            DbParameter[] parameters = {
                new OAParameter
                {
                    ParameterName = "@START_DATETIME",
                    Value =  tareaArgumento.FechaInicial
                },
                new OAParameter
                {
                    ParameterName = "@END_DATETIME",
                    Value =  tareaArgumento.FechaFinal
                },
                new OAParameter
                {
                    ParameterName = "@LOGIN",
                    Value = tareaArgumento.Login
                },
               new OAParameter
                {
                    ParameterName = "@USERS",
                    Value =  tareaArgumento.Users
                },
               new OAParameter
                {
                    ParameterName = "@TYPES",
                    Value = tareaArgumento.Types
                }
            };
            return BaseDeDatosServicio.ExecuteQuery<Tarea>(BaseDeDatosServicio.Esquema + ".OP_WMS_GET_GET_OPERATORS_GRAPHICS_TASK", CommandType.StoredProcedure, true, parameters).ToList();
        }

        public Operacion CambiarEstadoTareaConteno(TareaArgumento tareaArgumento)
        {
            try
            {
                DbParameter[] parameters = {
                   new OAParameter
                   {
                       ParameterName = "@NEW_STATUS",
                       Value = tareaArgumento.Tarea.IS_PAUSED
                   },
                   new OAParameter
                   {
                       ParameterName = "@TASK_ID",
                       Value = tareaArgumento.Tarea.TASK_ID
                   }

                };
                var op = BaseDeDatosServicio.ExecuteQuery<Operacion>(BaseDeDatosServicio.Esquema + ".OP_WMS_UPDATE_TASK_BY_TASK_ID", CommandType.StoredProcedure, true, parameters)[0];
                if (op.Resultado == ResultadoOperacionTipo.Error)
                {
                    throw new Exception("Ocurrió un error al cambiar el estado de la tarea: " + op.Mensaje);
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

        public Operacion CancelarTareaPorOla(TareaArgumento tareaArgumento)
        {
            DbParameter[] parameters =
                  {
                    new OAParameter
                    {
                        ParameterName = "@WAVE_PICKING_ID",
                        Value = tareaArgumento.Tarea.WAVE_PICKING_ID
                    },
                    new OAParameter
                    {
                        ParameterName = "@USER_ID",
                        Value = tareaArgumento.Login
                    }
                };
            return BaseDeDatosServicio.ExecuteQuery<Operacion>(BaseDeDatosServicio.Esquema + ".OP_WMS_DELETE_PICKING", CommandType.StoredProcedure, true, parameters).FirstOrDefault();
        }

        public Operacion CancelarTareaRecepcion(TareaArgumento tareaArgumento)
        {
            DbParameter[] parameters =
                 {
                    new OAParameter
                    {
                        ParameterName = "@SERIAL_NUMBER",
                        Value = tareaArgumento.Tarea.SERIAL_NUMBER
                    },
                    new OAParameter
                    {
                        ParameterName = "@USER_ID",
                        Value = tareaArgumento.Login
                    }
                };
            return BaseDeDatosServicio.ExecuteQuery<Operacion>(BaseDeDatosServicio.Esquema + ".OP_WMS_DELETE_PICKING_BY_SERIAL_NUMBER", CommandType.StoredProcedure, true, parameters).FirstOrDefault();
        }

        public Operacion CancelarTareaConteo(TareaArgumento tareaArgumento)
        {
            DbParameter[] parameters =
                  {
                    new OAParameter
                    {
                        ParameterName = "@TASK_ID",
                        Value = tareaArgumento.Tarea.TASK_ID
                    },
                    new OAParameter
                    {
                        ParameterName = "@USER",
                        Value = tareaArgumento.Login
                    }
                };
            return BaseDeDatosServicio.ExecuteQuery<Operacion>(BaseDeDatosServicio.Esquema + ".OP_WMS_DELETE_COUNTING_TASK", CommandType.StoredProcedure, true, parameters).FirstOrDefault();
        }

        public Operacion DistribuirTareaATodosLosOperadores(TareaArgumento tareaArgumento)
        {
            try
            {
                DbParameter[] parameters = {
                   new OAParameter
                   {
                       ParameterName = "@LOGIN",
                       Value = tareaArgumento.Login
                   }
                };
                var op = BaseDeDatosServicio.ExecuteQuery<Operacion>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_RE_ASIGN_TASKS_TO_EVERYONE", CommandType.StoredProcedure, true, parameters)[0];
                if (op.Resultado == ResultadoOperacionTipo.Error)
                {
                    throw new Exception("Ocurrió un error al autorizar recepcion ERP: " + op.Mensaje);
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

        public Operacion DistribuirTareaATodosLosOperadoresSinTarea(TareaArgumento tareaArgumento)
        {
            try
            {
                DbParameter[] parameters = {
                   new OAParameter
                   {
                       ParameterName = "@LOGIN",
                       Value = tareaArgumento.Login
                   }
                };
                var op = BaseDeDatosServicio.ExecuteQuery<Operacion>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_RE_ASIGN_TASKS_TO_EVERYONE_WITHOUT_TASKS", CommandType.StoredProcedure, true, parameters)[0];
                if (op.Resultado == ResultadoOperacionTipo.Error)
                {
                    throw new Exception("Ocurrió un error al autorizar recepcion ERP: " + op.Mensaje);
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

        public Operacion ValidarAutorizacionDeRecepcionPorDevolucion(TareaArgumento argumento)
        {
            try
            {
                DbParameter[] parameters = {
                    new OAParameter
                    {
                        ParameterName = "@TASK_ID",
                        Value = argumento.Tarea.SERIAL_NUMBER
                    }
                };
                var op = BaseDeDatosServicio.ExecuteQuery<Operacion>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_VALIDATE_RECEPTION_FOR_INVOICE_RETURN_TO_SEND_ERP", CommandType.StoredProcedure, true, parameters)[0];
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

        public Operacion CancelarTareaDeRecepcionPorDevolucionDeFactura(TareaArgumento argumento)
        {
            try
            {
                DbParameter[] parameters = {
                    new OAParameter
                    {
                        ParameterName = "@TASK_ID",
                        Value = argumento.Tarea.SERIAL_NUMBER
                    },
                    new OAParameter
                    {
                        ParameterName = "@LOGIN",
                        Value = argumento.Login
                    }
                };
                var op = BaseDeDatosServicio.ExecuteQuery<Operacion>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_CANCEL_RECEPTION_FOR_INVOICE_RETURN", CommandType.StoredProcedure, false, parameters)[0];
                if (op.Resultado == ResultadoOperacionTipo.Exito) BaseDeDatosServicio.Commit();
                else BaseDeDatosServicio.Rollback();
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

        public Operacion ReasignarTareaLineaDePicking(TareaArgumento argumento)
        {
            try
            {
                DbParameter[] parameters = {
                    new OAParameter
                    {
                        ParameterName = "@WAVE_PICKING_ID",
                        Value = argumento.Tarea.WAVE_PICKING_ID
                    },
                    new OAParameter
                    {
                        ParameterName = "@PICKING_LINE_ID",
                        Value = argumento.Linea
                    },
                    new OAParameter
                    {
                        ParameterName = "@LOGIN",
                        Value = argumento.Login
                    }
                };
                var op = BaseDeDatosServicio.ExecuteQuery<Operacion>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_CHANGE_LINE_PICKING_BY_WAVE_PICKING", CommandType.StoredProcedure, false, parameters)[0];
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

        public Operacion CancelarTareaLineaDePicking(TareaArgumento argumento)
        {
            try
            {
                DbParameter[] parameters = {
                    new OAParameter
                    {
                        ParameterName = "@WAVE_PICKING_ID",
                        Value = argumento.Tarea.WAVE_PICKING_ID
                    },
                    new OAParameter
                    {
                        ParameterName = "@LOGIN",
                        Value = argumento.Login
                    }
                };
                var op = BaseDeDatosServicio.ExecuteQuery<Operacion>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_CANCEL_PICKING_LINE_WAVE", CommandType.StoredProcedure, false, parameters)[0];
                if (op.Resultado == ResultadoOperacionTipo.Exito) BaseDeDatosServicio.Commit();
                else BaseDeDatosServicio.Rollback();
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

        public Operacion CambiarPrioridadDeLaTarea(TareaArgumento argumento)
        {
            try
            {
                DbParameter[] parameters = {
                    new OAParameter
                    {
                        ParameterName = "@TASK_ID",
                        Value = argumento.Tarea.SERIAL_NUMBER
                    },
                    new OAParameter
                    {
                        ParameterName = "@TASK_TYPE",
                        Value = argumento.Tarea.TASK_TYPE
                    },
                    new OAParameter
                    {
                        ParameterName = "@PRIORITY",
                        Value = argumento.Priority
                    }
                };
                var op = BaseDeDatosServicio.ExecuteQuery<Operacion>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_UPDATE_TASK_PRIORITY", CommandType.StoredProcedure, false, parameters)[0];
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

        public Operacion CancelarDetalleDeRecepcion(TareaArgumento argumento)
        {
            try
            {
                DbParameter[] parameters = {
                    new OAParameter
                    {
                        ParameterName = "@XML",
                        Value = argumento.Xml
                    },
                    new OAParameter
                    {
                        ParameterName = "@CODIGO_POLIZA",
                        Value = argumento.Tarea.CODIGO_POLIZA_SOURCE2
                    }
                    ,
                    new OAParameter
                    {
                        ParameterName = "@REASON",
                        Value = argumento.Razon
                    }
                    ,
                    new OAParameter
                    {
                        ParameterName = "@TASK_ID",
                        Value = argumento.Tarea.SERIAL_NUMBER
                    }
                };
                var op = BaseDeDatosServicio.ExecuteQuery<Operacion>(BaseDeDatosServicio.Esquema + ".OP_WMS_CANCEL_RECEPTION_DETAIL", CommandType.StoredProcedure, false, parameters)[0];
                if (op.Resultado == ResultadoOperacionTipo.Exito) BaseDeDatosServicio.Commit();
                else BaseDeDatosServicio.Rollback();

                return op;

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

        public IList<TareaDetalleErp> ObtenerDetalleErpTarea(TareaArgumento argumento)
        {
            DbParameter[] parameters = {
                new OAParameter
                {
                    ParameterName = "@WAVE_PICKING_ID",
                    Value = argumento.OlaDePicking
                }
            };
            return BaseDeDatosServicio.ExecuteQuery<TareaDetalleErp>(BaseDeDatosServicio.Esquema + ".OP_WMS_GET_TASK_DEMAND_DETAIL", CommandType.StoredProcedure, true, parameters).ToList();
        }

        public IList<TareaDetalle> ObtenerDetalleTareaRecepcionParaConfirmacion(TareaArgumento argumento)
        {
            DbParameter[] parameters =
               {
                    new OAParameter
                    {
                        ParameterName = "@SERIAL_NUMBER",
                        Value = argumento.Tarea.SERIAL_NUMBER
                    }
                };
            return BaseDeDatosServicio.ExecuteQuery<TareaDetalle>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_TASK_DETAIL_CONFIRMATION_FOR_RECEPTION", CommandType.StoredProcedure, true, parameters).ToList();
        }

        public IList<Tarea> ObtenerDetalleLicenciasOla(TareaArgumento argumento)
        {
            DbParameter[] parameters =
               {
                    new OAParameter
                    {
                        ParameterName = "@WAVE_PICKING_ID",
                        Value = argumento.Tarea.WAVE_PICKING_ID
                    }
                };
            return BaseDeDatosServicio.ExecuteQuery<Tarea>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_TASK_DETAIL_FOR_WAVE_PICKING", CommandType.StoredProcedure, true, parameters).ToList();
        }

        public Operacion CambiarLicenciaEnLineaDeTareaPicking(TareaArgumento argumento)
        {
            try
            {
                DbParameter[] parameters = {
                    new OAParameter
                    {
                        ParameterName = "@SERIAL_NUMBER",
                        Value = argumento.Tarea.SERIAL_NUMBER
                    },new OAParameter
                    {
                        ParameterName = "@LOGIN",
                        Value = argumento.Login                    }
                };
                var op = BaseDeDatosServicio.ExecuteQuery<Operacion>(BaseDeDatosServicio.Esquema + ".OP_WMS_CHANGE_LICENSE_IN_LINE_OF_PICKING_TASK", CommandType.StoredProcedure, false, parameters)[0];
                if (op.Resultado == ResultadoOperacionTipo.Exito) BaseDeDatosServicio.Commit();
                else BaseDeDatosServicio.Rollback();
                return op;
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

        public Operacion ReabrirTareaRecepcion(TareaArgumento argumento)
        {
            try
            {
                DbParameter[] parameters = {
                    new OAParameter
                    {
                        ParameterName = "@SERIAL_NUMBER",
                        Value = argumento.Tarea.SERIAL_NUMBER
                    },new OAParameter
                    {
                        ParameterName = "@LOGIN",
                        Value = argumento.Login                    }
                };
                var op = BaseDeDatosServicio.ExecuteQuery<Operacion>(BaseDeDatosServicio.Esquema + ".OP_WMS_REOPEN_TASK_RECEPTION", CommandType.StoredProcedure, false, parameters)[0];
                if (op.Resultado == ResultadoOperacionTipo.Exito) BaseDeDatosServicio.Commit();
                else BaseDeDatosServicio.Rollback();
                return op;
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
