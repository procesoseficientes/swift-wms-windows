using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using DocumentFormat.OpenXml.Spreadsheet;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Modelo.Tipos;
using MobilityScm.Utilerias;
using MobilityScm.Vertical.Entidades;
using Telerik.OpenAccess.Data.Common;

namespace MobilityScm.Modelo.Servicios
{
    public class PaseDeSalidaServicio : IPaseDeSalidaServicio
    {
        public IBaseDeDatosServicio BaseDeDatosServicio { get; set; }

        public PaseDeSalidaServicio(IBaseDeDatosServicio baseDeDatosServicio)
        {
            BaseDeDatosServicio = baseDeDatosServicio;
        }

        private bool SeInsertaElDocumento(decimal valor)
        {
            return valor == 0;
        }

        public Operacion GrabarPaseDeSalida(PaseDeSalidaArgumento paseDeSalidaArgumento)
        {
            BaseDeDatosServicio.BeginTransaction();
            Operacion op = null;

            op = (SeInsertaElDocumento(paseDeSalidaArgumento.PaseDeSalidaEncabezado.PASS_ID))
                ? InsertarPaseDeSalidaEncabezado(paseDeSalidaArgumento)
                : ActualizarPaseDeSalidaEncabezado(paseDeSalidaArgumento);
            if (op.Resultado == ResultadoOperacionTipo.Exito)
            {
                op = InsertarDetalleDePaseDeSalidaEncabezado(paseDeSalidaArgumento);
                if (op.Resultado == ResultadoOperacionTipo.Exito)
                {
                    BaseDeDatosServicio.Commit();
                }
                else
                {
                    BaseDeDatosServicio.Rollback();
                }
            }
            else
            {
                BaseDeDatosServicio.Rollback();
            }

            return op;
        }

        public Operacion InsertarPaseDeSalidaEncabezado(PaseDeSalidaArgumento paseDeSalidaArgumento)
        {
            try
            {


                DbParameter[] parameters ={
                   new OAParameter
                   {
                       ParameterName = "@CLIENT_CODE",
                       Value = paseDeSalidaArgumento.PaseDeSalidaEncabezado.CLIENT_CODE
                   }
                   ,
                       new OAParameter
                   {
                       ParameterName = "@CLIENT_NAME",
                       Value = paseDeSalidaArgumento.PaseDeSalidaEncabezado.CLIENT_NAME
                   }
                   ,
                   new OAParameter
                   {
                       ParameterName = "@ISEMPTY",
                       Value = paseDeSalidaArgumento.PaseDeSalidaEncabezado.ISEMPTY
                   }
                   ,
                    new OAParameter
                   {
                       ParameterName = "@VEHICLE_PLATE",
                       Value = paseDeSalidaArgumento.PaseDeSalidaEncabezado.VEHICLE_PLATE
                   }
                   ,
                     new OAParameter
                   {
                       ParameterName = "@VEHICLE_ID",
                       Value = paseDeSalidaArgumento.PaseDeSalidaEncabezado.VEHICLE_ID
                   }
                   ,
                    new OAParameter
                   {
                       ParameterName = "@DRIVER_ID",
                       Value = paseDeSalidaArgumento.PaseDeSalidaEncabezado.DRIVER_ID
                   }
                    ,
                    new OAParameter
                   {
                       ParameterName = "@VEHICLE_DRIVER",
                       Value = paseDeSalidaArgumento.PaseDeSalidaEncabezado.VEHICLE_DRIVER
                   }
                   ,
                    new OAParameter
                   {
                       ParameterName = "@AUTORIZED_BY",
                       Value = paseDeSalidaArgumento.PaseDeSalidaEncabezado.AUTORIZED_BY
                   }
                    ,
                    new OAParameter
                   {
                       ParameterName = "@HANDLER",
                       Value = paseDeSalidaArgumento.PaseDeSalidaEncabezado.HANDLER
                   }
                    ,new OAParameter
                   {
                       ParameterName = "@TXT",
                       Value = paseDeSalidaArgumento.PaseDeSalidaEncabezado.TXT
                   }
                   , new OAParameter
                   {
                       ParameterName = "@LOADUNLOAD",
                       Value = paseDeSalidaArgumento.PaseDeSalidaEncabezado.LOADUNLOAD
                   }
                   , new OAParameter
                   {
                       ParameterName = "@CREATED_BY",
                       Value = paseDeSalidaArgumento.Login
                   }
                   , new OAParameter
                   {
                       ParameterName = "@LICENSE_NUMBER",
                       Value = paseDeSalidaArgumento.PaseDeSalidaEncabezado.LICENSE_NUMBER
                   }
                    , new OAParameter
                   {
                       ParameterName = "@TYPE",
                       Value = paseDeSalidaArgumento.PaseDeSalidaEncabezado.TYPE
                   }
                };
                var op = BaseDeDatosServicio.ExecuteQuery<Operacion>(BaseDeDatosServicio.Esquema + ".[OP_WMS_SP_INSERT_EXIT_PASS]", CommandType.StoredProcedure, false, parameters)[0];
                if (op.Resultado == ResultadoOperacionTipo.Exito)
                {
                    paseDeSalidaArgumento.PaseDeSalidaEncabezado.PASS_ID = Convert.ToInt32(op.DbData);
                }
                return op;

            }
            catch (DbException ex)
            {
                BaseDeDatosServicio.Rollback();
                return new Operacion
                {
                    Codigo = ex.ErrorCode,
                    Mensaje = ex.Message,
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

        public Operacion ActualizarPaseDeSalidaEncabezado(PaseDeSalidaArgumento paseDeSalidaArgumento)
        {
            try
            {


                DbParameter[] parameters ={
                    new OAParameter
                   {
                       ParameterName = "@PASS_ID",
                       Value = paseDeSalidaArgumento.PaseDeSalidaEncabezado.PASS_ID
                   }
                   ,
                    new OAParameter
                   {
                       ParameterName = "@CLIENT_CODE",
                       Value = paseDeSalidaArgumento.PaseDeSalidaEncabezado.CLIENT_CODE
                   }
                   ,
                       new OAParameter
                   {
                       ParameterName = "@CLIENT_NAME",
                       Value = paseDeSalidaArgumento.PaseDeSalidaEncabezado.CLIENT_NAME
                   }
                   ,
                   new OAParameter
                   {
                       ParameterName = "@ISEMPTY",
                       Value = paseDeSalidaArgumento.PaseDeSalidaEncabezado.ISEMPTY
                   }
                   ,
                    new OAParameter
                   {
                       ParameterName = "@VEHICLE_PLATE",
                       Value = paseDeSalidaArgumento.PaseDeSalidaEncabezado.VEHICLE_PLATE
                   }
                    ,
                     new OAParameter
                   {
                       ParameterName = "@VEHICLE_ID",
                       Value = paseDeSalidaArgumento.PaseDeSalidaEncabezado.VEHICLE_ID
                   }
                   ,
                    new OAParameter
                   {
                       ParameterName = "@DRIVER_ID",
                       Value = paseDeSalidaArgumento.PaseDeSalidaEncabezado.DRIVER_ID
                   }
                   ,
                    new OAParameter
                   {
                       ParameterName = "@AUTORIZED_BY",
                       Value = paseDeSalidaArgumento.PaseDeSalidaEncabezado.AUTORIZED_BY
                   }
                    ,
                    new OAParameter
                   {
                       ParameterName = "@VEHICLE_DRIVER",
                       Value = paseDeSalidaArgumento.PaseDeSalidaEncabezado.VEHICLE_DRIVER
                   }
                   ,
                    new OAParameter
                   {
                       ParameterName = "@HANDLER",
                       Value = paseDeSalidaArgumento.PaseDeSalidaEncabezado.HANDLER
                   }
                    ,new OAParameter
                   {
                       ParameterName = "@TXT",
                       Value = paseDeSalidaArgumento.PaseDeSalidaEncabezado.TXT
                   }
                   , new OAParameter
                   {
                       ParameterName = "@LOADUNLOAD",
                       Value = paseDeSalidaArgumento.PaseDeSalidaEncabezado.LOADUNLOAD
                   }
                   , new OAParameter
                   {
                       ParameterName = "@LAST_UPDATED_BY",
                       Value = paseDeSalidaArgumento.Login
                   }
                   , new OAParameter
                   {
                       ParameterName = "@LICENSE_NUMBER",
                       Value = paseDeSalidaArgumento.PaseDeSalidaEncabezado.LICENSE_NUMBER
                   }
                };
                return BaseDeDatosServicio.ExecuteQuery<Operacion>(BaseDeDatosServicio.Esquema + ".[OP_WMS_SP_UPDATE_EXIT_PASS]", CommandType.StoredProcedure, false, parameters)[0];

            }
            catch (DbException ex)
            {
                BaseDeDatosServicio.Rollback();
                return new Operacion
                {
                    Codigo = ex.ErrorCode,
                    Mensaje = ex.Message,
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

        public Operacion InsertarDetalleDePaseDeSalidaEncabezado(PaseDeSalidaArgumento paseDeSalidaArgumento)
        {
            try
            {
                DbParameter[] parameters ={
                   new OAParameter
                   {
                       ParameterName = "@PASS_HEADER_ID",
                       Value = paseDeSalidaArgumento.PaseDeSalidaEncabezado.PASS_ID
                   }
                   ,
                       new OAParameter
                   {
                       ParameterName = "@XML",
                       Value = paseDeSalidaArgumento.Xml
                   }
                };
                return BaseDeDatosServicio.ExecuteQuery<Operacion>(BaseDeDatosServicio.Esquema + ".[OP_WMS_SP_INSERT_EXIT_PASS_DETAIL]", CommandType.StoredProcedure, false, parameters)[0];
            }
            catch (DbException ex)
            {
                BaseDeDatosServicio.Rollback();
                return new Operacion
                {
                    Codigo = ex.ErrorCode,
                    Mensaje = ex.Message,
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

        public IList<PaseDeSalidaEncabezado> ObtenerPase(PaseDeSalidaArgumento argumento)
        {
            DbParameter[] parameters =
          {
               new OAParameter
               {
                   ParameterName = "@PASS_HEADER_ID",
                   Value = argumento.PaseDeSalidaEncabezado.PASS_ID
               }
               ,new OAParameter
               {
                   ParameterName = "@LOGIN_ID",
                   Value = argumento.Login
               },
               new OAParameter
               {
                   ParameterName = "@DISTRIBUTION_CENTER_ID",
                   Value = argumento.DISTRIBUTION_CENTER_ID
               }
           };
            return BaseDeDatosServicio.ExecuteQuery<PaseDeSalidaEncabezado>(BaseDeDatosServicio.Esquema + ".[OP_WMS_SP_GET_PASS]", CommandType.StoredProcedure, parameters);
        }

        public IList<PaseDeSalidaDetalle> ObtenerDetalleDePase(PaseDeSalidaArgumento argumento)
        {
            DbParameter[] parameters =
          {
               new OAParameter
               {
                   ParameterName = "@PASS_HEADER_ID",
                   Value = argumento.PaseDeSalidaEncabezado.PASS_ID
               }
           };
            return BaseDeDatosServicio.ExecuteQuery<PaseDeSalidaDetalle>(BaseDeDatosServicio.Esquema + ".[OP_WMS_SP_GET_DETAIL_PASS]", CommandType.StoredProcedure, parameters);
        }

        public DataTable ActualizarEstadoParaElPaseDeSalida(PaseDeSalidaArgumento paseDeSalidaArgumento)
        {
            string wshost = ConfigurationManager.AppSettings["WSHOST"].ToString();
            var xserv = new OnePlanServices_Trans.WMS_TransSoapClient("WMS_TransSoap", wshost + "/Trans/WMS_Trans.asmx");
            string result = "";
            DataTable transReturn = xserv.UpdateDeliveryNoteERP(
                Decimal.ToInt32(paseDeSalidaArgumento.PaseDeSalidaEncabezado.PASS_ID),
                paseDeSalidaArgumento.PaseDeSalidaEncabezado.STATUS,
                paseDeSalidaArgumento.Login,
                ConfigurationManager.AppSettings["DEFAULT_ENVIRONMENT"].ToString(),
                ref result);

            return transReturn;

            /*try
            {
                DbParameter[] parameters ={
                   new OAParameter
                   {
                       ParameterName = "@PASS_ID",
                       Value = paseDeSalidaArgumento.PaseDeSalidaEncabezado.PASS_ID
                   }
                   ,
                       new OAParameter
                   {
                       ParameterName = "@STATUS",
                       Value = paseDeSalidaArgumento.PaseDeSalidaEncabezado.STATUS
                   }
                       ,
                       new OAParameter
                   {
                       ParameterName = "@LOGIN",
                       Value = paseDeSalidaArgumento.Login
                   }
                };
                return BaseDeDatosServicio.ExecuteQuery<Operacion>(BaseDeDatosServicio.Esquema + ".[OP_WMS_SP_UPDATE_STATUS_BY_EXIT_PASS]", CommandType.StoredProcedure, parameters)[0];
            }
            catch (DbException ex)
            {
                BaseDeDatosServicio.Rollback();
                return new Operacion
                {
                    Codigo = ex.ErrorCode,
                    Mensaje = ex.Message,
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
            }*/

        }

        public IList<PaseDeSalida> ObtenerPasesDeSalidaParaReporte(PaseDeSalidaArgumento paseDeSalidaArgumento)
        {

            DbParameter[] parameters =
          {
               new OAParameter
               {
                   ParameterName = "@PASS_ID",
                   Value = paseDeSalidaArgumento.PaseDeSalidaEncabezado.PASS_ID
               }
               ,
               new OAParameter
               {
                   ParameterName = "@DISTRIBUTION_CENTER_ID",
                   Value = paseDeSalidaArgumento.DISTRIBUTION_CENTER_ID
               }
           };
            return BaseDeDatosServicio.ExecuteQuery<PaseDeSalida>(BaseDeDatosServicio.Esquema + ".[OP_WMS_SP_GET_PASS_FOR_REPORT]", CommandType.StoredProcedure, parameters);
        }

        public IList<PaseDeSalida> ObtnerPasesDeSalidas(PaseDeSalidaArgumento paseDeSalidaArgumento)
        {

            DbParameter[] parameters =
          {
               new OAParameter
               {
                   ParameterName = "@START_DATE",
                   Value = paseDeSalidaArgumento.FechaInicio
               }
               ,
               new OAParameter
               {
                   ParameterName = "@END_DATE",
                   Value = paseDeSalidaArgumento.FechaFin
               }
               ,
               new OAParameter
               {
                   ParameterName = "@DISTRIBUTION_CENTER_ID",
                   Value = paseDeSalidaArgumento.DISTRIBUTION_CENTER_ID
               }
           };
            return BaseDeDatosServicio.ExecuteQuery<PaseDeSalida>(BaseDeDatosServicio.Esquema + ".[OP_WMS_SP_GET_PASS_REPORT]", CommandType.StoredProcedure, parameters);
        }


    }
}
