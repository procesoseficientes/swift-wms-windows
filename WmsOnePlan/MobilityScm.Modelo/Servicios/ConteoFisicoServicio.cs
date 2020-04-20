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
    public class ConteoFisicoServicio : IConteoFisicoServicio
    {
        public IBaseDeDatosServicio BaseDeDatosServicio { get; set; }

        public ConteoFisicoServicio(IBaseDeDatosServicio baseDeDatosServicio)
        {
            BaseDeDatosServicio = baseDeDatosServicio;
        }

        public Operacion GenerarTareaConteoFisico(ConteoFisicoArgumento conteoFisicoArgumento)
        {
            try
            {
                BaseDeDatosServicio.BeginTransaction();
                var op = InsertarTarea(conteoFisicoArgumento);
                conteoFisicoArgumento.ConteoFisicoEncabezado.TASK_ID = Convert.ToInt32(op.DbData);
                op = InsertarConteoFisicoEncabezado(conteoFisicoArgumento);

                foreach (var conteoFisicoDetalle in conteoFisicoArgumento.ConteoFisicoDetalle)
                    conteoFisicoDetalle.PHYSICAL_COUNT_HEADER_ID = Convert.ToInt32(op.DbData);
                op = InsertarConteoFisicoDetalle(conteoFisicoArgumento);
                BaseDeDatosServicio.Commit();
                return op;
            }
            catch (Exception e)
            {
                BaseDeDatosServicio.Rollback();
                return new Operacion
                {
                    Resultado = ResultadoOperacionTipo.Error,
                    Mensaje = e.Message,
                };
            }
        }

        public Operacion InsertarConteoFisicoDetalle(ConteoFisicoArgumento conteoFisicoArgumento)
        {

            var op = new Operacion();
            foreach (var item in conteoFisicoArgumento.ConteoFisicoDetalle)
            {
                DbParameter[] parameters = {
                   new OAParameter
                   {
                       ParameterName = "@PHYSICAL_COUNT_HEADER_ID",
                       Value = item.PHYSICAL_COUNT_HEADER_ID
                   },
                   new OAParameter
                   {
                       ParameterName = "@WAREHOUSE_ID",
                       Value = item.CODE_WAREHOUSE
                   },
                   new OAParameter
                   {
                       ParameterName = "@ZONE",
                       Value = item.ZONE
                   },
                   new OAParameter
                   {
                       ParameterName = "@LOCATION",
                       Value = item.LOCATION_SPOT
                   },
                   new OAParameter
                   {
                       ParameterName = "@CLIENT_CODE",
                       Value = item.CLIENT_CODE
                   },
                   new OAParameter
                   {
                       ParameterName = "@MATERIAL_ID",
                       Value = item.MATERIAL_ID
                   },
                   new OAParameter
                   {
                       ParameterName = "@ASSIGNED_TO",
                       Value = item.ASSIGNED_TO
                   }
                };
                op = BaseDeDatosServicio.ExecuteQuery<Operacion>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_INSERT_PHYSICAL_COUNTS_DETAIL", CommandType.StoredProcedure, false, parameters)[0];
                if (op.Resultado == ResultadoOperacionTipo.Error)
                {
                    throw new Exception("Ocurrió un error al crear detalle: " + op.Mensaje);
                }
            }
            return op;

        }

        public Operacion InsertarConteoFisicoEncabezado(ConteoFisicoArgumento conteoFisicoArgumento)
        {
            DbParameter[] parameters = {
                   new OAParameter
                   {
                       ParameterName = "@TASK_ID",
                       Value = conteoFisicoArgumento.ConteoFisicoEncabezado.TASK_ID
                   },
                   new OAParameter
                   {
                       ParameterName = "@REGIMEN",
                       Value = conteoFisicoArgumento.ConteoFisicoEncabezado.REGIMEN
                   },
                   new OAParameter
                   {
                       ParameterName = "@DISTRIBUTION_CENTER",
                       Value = conteoFisicoArgumento.ConteoFisicoEncabezado.DISTRIBUTION_CENTER
                   }
                };
            var op = BaseDeDatosServicio.ExecuteQuery<Operacion>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_INSERT_PHYSICAL_COUNTS_HEADER", CommandType.StoredProcedure, false, parameters)[0];
            if (op.Resultado == ResultadoOperacionTipo.Error)
            {
                throw new Exception("Ocurrió un error al crear encabezado: " + op.Mensaje);
            }
            return op;
        }

        public Operacion InsertarTarea(ConteoFisicoArgumento conteoFisicoArgumento)
        {
            DbParameter[] parameters = {
                   new OAParameter
                   {
                       ParameterName = "@CREATE_BY",
                       Value = conteoFisicoArgumento.Tarea.CREATE_BY
                   },
                   new OAParameter
                   {
                       ParameterName = "@TASK_TYPE",
                       Value = conteoFisicoArgumento.Tarea.TASK_TYPE
                   },
                   new OAParameter
                   {
                       ParameterName = "@TASK_ASSIGNED_TO",
                       Value = conteoFisicoArgumento.Tarea.TASK_ASSIGNED_TO
                   },
                   new OAParameter
                   {
                       ParameterName = "@REGIMEN",
                       Value = conteoFisicoArgumento.Tarea.REGIMEN
                   },
                   new OAParameter
                   {
                       ParameterName = "@PRIORITY",
                       Value = conteoFisicoArgumento.Tarea.PRIORITY
                   },
                   new OAParameter
                   {
                       ParameterName = "@COMMENTS",
                       Value = conteoFisicoArgumento.Tarea.COMMENTS
                   }

                };
            var op = BaseDeDatosServicio.ExecuteQuery<Operacion>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_INSERT_TASK", CommandType.StoredProcedure, false, parameters)[0];
            if (op.Resultado == ResultadoOperacionTipo.Error)
            {
                throw new Exception("Ocurrió un error al crear tarea: " + op.Mensaje);
            }
            return op;
        }

        public IList<ConteoFisico> ConsultarConsConteosFisicos(ConteoFisicoArgumento conteoFisicoArgumento)
        {
            DbParameter[] parameters = {
                new OAParameter
                {
                    ParameterName = "@START_DATETIME",
                    Value =  conteoFisicoArgumento.FechaInicial.Date
                },
                new OAParameter
                {
                    ParameterName = "@END_DATETIME",
                    Value =  (conteoFisicoArgumento.FechaFinal.Date).AddDays(1)
                },
                new OAParameter
                {
                    ParameterName = "@USERS_ASSIGNED_TO",
                    Value = string.IsNullOrEmpty(  conteoFisicoArgumento.Operadores) ? null :  conteoFisicoArgumento.Operadores
                },
               new OAParameter
                {
                    ParameterName = "@CODE_WAREHOUSE",
                    Value = string.IsNullOrEmpty(  conteoFisicoArgumento.Bodegas) ? null :  conteoFisicoArgumento.Bodegas
                },
               new OAParameter
                {
                    ParameterName = "@LOGIN_ID",
                    Value = conteoFisicoArgumento.Login
                }
            };
            return BaseDeDatosServicio.ExecuteQuery<ConteoFisico>
                (BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_PHYSICAL_COUNTS", CommandType.StoredProcedure, true, parameters).ToList();
        }
    }
}
