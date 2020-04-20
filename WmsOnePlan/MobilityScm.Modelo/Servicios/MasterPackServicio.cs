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
using MobilityScm.Vertical.Entidades;
using MobilityScm.Modelo.Tipos;

namespace MobilityScm.Modelo.Servicios
{
    public class MasterPackServicio : IMasterPackServicio
    {
        public IBaseDeDatosServicio BaseDeDatosServicio { get; set; }

        public MasterPackServicio(IBaseDeDatosServicio baseDeDatosServicio)
        {
            BaseDeDatosServicio = baseDeDatosServicio;
        }
        public Operacion AutorizarMasterPackERP(MasterPackArgumento masterPackArgumento)
        {

            try
            {
                DbParameter[] parameters ={
                   new OAParameter
                   {
                       ParameterName = "@MASTER_PACK_HEADER_ID",
                       Value = masterPackArgumento.MasterPackEncabezado.MASTER_PACK_HEADER_ID
                   }
                   ,
                       new OAParameter
                   {
                       ParameterName = "@LAST_UPDATE_BY",
                       Value = masterPackArgumento.MasterPackEncabezado.LAST_UPDATE_BY
                   }

                };
                var op = BaseDeDatosServicio.ExecuteQuery<Operacion>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_AUTHORIZE_ERP_MASTER_PACK", CommandType.StoredProcedure, false, parameters)[0];

                return op;
            }
            catch (DbException ex)
            {
                return new Operacion
                {
                    Codigo = ex.ErrorCode,
                    Mensaje = ex.Message,
                    Resultado = ResultadoOperacionTipo.Error
                };
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

        public IList<MasterPackDetalle> ObtenerDetallesDeMasterPacks(MasterPackArgumento masterPackArgumento)
        {

            DbParameter[] parameters =
          {
               new OAParameter
               {
                   ParameterName = "@MASTER_PACK_HEADER_ID",
                   Value = masterPackArgumento.MasterPackEncabezado.MASTER_PACK_HEADER_ID
               }
           };
            return BaseDeDatosServicio.ExecuteQuery<MasterPackDetalle>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_MASTER_PACK_DETAIL", CommandType.StoredProcedure, parameters);
        }

        public IList<MasterPackMaestroDetalle> ObtenerMaestroDetalleDeMasterPack(MasterPackArgumento masterPackArgumento)
        {
            DbParameter[] parameters =
          {
               new OAParameter
               {
                   ParameterName = "@LOGIN",
                   Value = masterPackArgumento.Login
               }
           };
            return BaseDeDatosServicio.ExecuteQuery<MasterPackMaestroDetalle>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_INVENTORY_ONLINE_BY_MASTER_PACK", CommandType.StoredProcedure, parameters);
        }

        public IList<MasterPackEncabezado> ObtenerMasterPacksPorFechaDeExplocion(MasterPackArgumento masterPackArgumento)
        {
            DbParameter[] parameters =
         {
               new OAParameter
               {
                   ParameterName = "@START_DATE",
                   Value = masterPackArgumento.FechaInicial
               }
               ,
                new OAParameter
                   {
                       ParameterName = "@END_DATE",
                       Value = masterPackArgumento.FechaFinal
                   }
                ,
                new OAParameter
                {
                       ParameterName = "@LOGIN",
                       Value = masterPackArgumento.Login
                   }
           };
            return BaseDeDatosServicio.ExecuteQuery<MasterPackEncabezado>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_MASTER_PACK_HEADER_BY_EXPLODED_DATE", CommandType.StoredProcedure, parameters);
        }
    }
}
