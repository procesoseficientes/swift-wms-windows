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
    public class ConsultaDeManifiestoServicio : IConsultaDeManifiestoServicio
    {

        #region Base de datos
        public IBaseDeDatosServicio BaseDeDatosServicio { get; set; }

        public ConsultaDeManifiestoServicio(IBaseDeDatosServicio baseDeDatosServicio)
        {
            BaseDeDatosServicio = baseDeDatosServicio;
        }
        #endregion

        public Operacion CancelarManifiesto(ManifiestoArgumento manifiestoArgumento)
        {
            try
            {
                BaseDeDatosServicio.BeginTransaction();
                DbParameter[] parameters = {
                   new OAParameter
                   {
                       ParameterName = "@MANIFEST_HEADER_ID",
                       Value = manifiestoArgumento.ManifiestoEncabezado.MANIFEST_HEADER_ID
                   }
                };
                var op = BaseDeDatosServicio.ExecuteQuery<Operacion>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_CANCEL_MANIFEST", CommandType.StoredProcedure, false, parameters)[0];

                if (op.Resultado != ResultadoOperacionTipo.Exito)
                {
                    BaseDeDatosServicio.Rollback();
                }
                else
                {
                    BaseDeDatosServicio.Commit();
                }
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

        public Operacion ActualizarVehiculoAManifiesto(ManifiestoArgumento manifiestoArgumento)
        {
            DbParameter[] parameters = {
                   new OAParameter
                   {
                       ParameterName = "@MANIFEST_HEADER_ID",
                       Value = manifiestoArgumento.ManifiestoEncabezado.MANIFEST_HEADER_ID
                   }
                   ,
                       new OAParameter
                   {
                       ParameterName = "@VEHICLE_CODE",
                       Value = manifiestoArgumento.ManifiestoEncabezado.VEHICLE
                   }
                    ,
                       new OAParameter
                   {
                       ParameterName = "@LOGIN",
                       Value = manifiestoArgumento.Login
                   }
                };
            var op = BaseDeDatosServicio.ExecuteQuery<Operacion>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_CHANGE_MANIFEST_VEHICLE", CommandType.StoredProcedure, false, parameters)[0];

            if (op.Resultado == ResultadoOperacionTipo.Error)
            {
                throw new Exception(op.Mensaje);
            }
            return op;
        }

        public IList<ManifiestoEncabezado> ObtenerEncabezadosDeManifiesto(ManifiestoArgumento manifiestoArgumento)
        {
            DbParameter[] parameters =
          {
                new OAParameter
                {
                    ParameterName = "@START_DATE",
                    Value = manifiestoArgumento.FechaInicial
                },
                new OAParameter
                {
                    ParameterName = "@END_DATE",
                    Value = manifiestoArgumento.FechaFinal
                },
                new OAParameter
                {
                    ParameterName = "@STATUS_MANIFEST",
                    Value = manifiestoArgumento.ManifiestoEncabezado.STATUS
                },
                new OAParameter
                {
                    ParameterName = "@LOGIN",
                    Value = manifiestoArgumento.Login
                }
            };
            return BaseDeDatosServicio.ExecuteQuery<ManifiestoEncabezado>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_MANIFEST_BY_STATUS", CommandType.StoredProcedure, parameters);
        }

        public Operacion DesasociarDemandasDespachoDeManifiesto(ManifiestoArgumento manifiestoArgumento)
        {
            try
            {
                BaseDeDatosServicio.BeginTransaction();
                DbParameter[] parameters = {
                   new OAParameter
                   {
                       ParameterName = "@PICKING_DEMAND_HEADER_IDS",
                       Value = manifiestoArgumento.DemandasDespacho
                   }
                   ,
                       new OAParameter
                   {
                       ParameterName = "@MANIFEST_HEADER_ID",
                       Value = manifiestoArgumento.ManifiestoEncabezado.MANIFEST_HEADER_ID
                   }
                };
                var op = BaseDeDatosServicio.ExecuteQuery<Operacion>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_DISASSOCIATE_PICKING_DEMAND_OF_MANIFEST", CommandType.StoredProcedure, false, parameters)[0];

                if (op.Resultado != ResultadoOperacionTipo.Exito)
                {
                    BaseDeDatosServicio.Rollback();
                }
                else
                {
                    BaseDeDatosServicio.Commit();
                }
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
