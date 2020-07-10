using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using DevExpress.Xpo.DB.Helpers;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Utilerias;
using Telerik.OpenAccess.Data.Common;

namespace MobilityScm.Modelo.Servicios
{
    public class ClienteServicio : IClienteServicio
    {
        public IBaseDeDatosServicio BaseDeDatosServicio { get; set; }

        public ClienteServicio(IBaseDeDatosServicio baseDeDatosServicio)
        {
            BaseDeDatosServicio = baseDeDatosServicio;
        }
        public IList<Cliente> ObtenerClientes()
        {

            return BaseDeDatosServicio.ExecuteQuery<Cliente>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_CLIENTS", CommandType.StoredProcedure, null);
        }

        public IList<Cliente> ObtenerClientesPorRegimen(ConteoFisicoArgumento conteoFisicoArgumento)
        {
            DbParameter[] parameters = {
                   new OAParameter
                   {
                       ParameterName = "@WAREHOUSE",
                       Value =  conteoFisicoArgumento.Bodegas
                   },
                   new OAParameter
                   {
                       ParameterName = "@REGIMEN",
                       Value =  conteoFisicoArgumento.Regimen
                   },
                new OAParameter
                   {
                       ParameterName = "@ZONE",
                       Value =  (conteoFisicoArgumento.Zonas == string.Empty ?  null : conteoFisicoArgumento.Zonas)
                   },

                   new OAParameter
                   {
                       ParameterName = "@LOCATION",
                       Value =  (conteoFisicoArgumento.Ubicaciones == string.Empty ?  null : conteoFisicoArgumento.Ubicaciones)
                   }
                };

            return BaseDeDatosServicio.ExecuteQuery<Cliente>
                (BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_CLIENTS_BY_WAREHOUSE_CLIENT_LOCATION_OR_ZONE", CommandType.StoredProcedure, true, parameters).ToList();
        }

        public IList<Cliente> ObtenerClientesErpPorCanalModerno(OrdenDeVentaArgumento argumento)
        {
            DbParameter[] parameters =
            {
                new OAParameter
                {
                    ParameterName = "@START_DATE",
                    Value = argumento.FechaInicio
                },new OAParameter
                {
                    ParameterName = "@END_DATE",
                    Value = argumento.FechaFin
                },new OAParameter
                {
                    ParameterName = "@WAREHOUSE_CODE",
                    Value = argumento.CodigoBodega
                }
            };
            return BaseDeDatosServicio.ExecuteQuery<Cliente>
                (BaseDeDatosServicio.Esquema + ".OP_WMS_GET_ERP_CLIENTS_FOR_CHANNEL_MODERN", CommandType.StoredProcedure, true, parameters).ToList();
        }

        public IList<Cliente> ObtenerClientesOrdeDeEntrega(OrdenDeVentaArgumento argumento)
        {
            DbParameter[] parameters =
            {
                new OAParameter
                {
                    ParameterName = "@START_DATE",
                    Value = argumento.FechaInicio
                },new OAParameter
                {
                    ParameterName = "@END_DATE",
                    Value = argumento.FechaFin
                },new OAParameter
                {
                    ParameterName = "@WAREHOUSE_CODE",
                    Value = argumento.CodigoBodega
                }
            };
            return BaseDeDatosServicio.ExecuteQuery<Cliente>
                (BaseDeDatosServicio.Esquema + ".OP_WMS_GET_ERP_CLIENTS_FOR_DELIVERY_ORDER", CommandType.StoredProcedure, true, parameters).ToList();
        }

        public IList<Cliente> ObtenerClientesErpCanalModernoParaOrdenesDeVentaPreparadas(OrdenDeVentaArgumento argumento)
        {
            DbParameter[] parameters =
            {
                new OAParameter
                {
                    ParameterName = "@START_DATE",
                    Value = argumento.FechaInicio
                },new OAParameter
                {
                    ParameterName = "@END_DATE",
                    Value = argumento.FechaFin
                },new OAParameter
                {
                    ParameterName = "@WAREHOUSE_CODE",
                    Value = argumento.CodigoBodega
                }
            };
            return BaseDeDatosServicio.ExecuteQuery<Cliente>
                (BaseDeDatosServicio.Esquema + ".OP_WMS_GET_ERP_CLIENTS_FOR_PREPARED_SALES_ORDERS", CommandType.StoredProcedure, true, parameters).ToList();
        }

        public IList<Cliente> ObtenerClientesErp(OrdenDeVentaArgumento argumento)
        {
            try
            {
                return BaseDeDatosServicio.ExecuteQuery<Cliente>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_CUSTOMER_BY_ERP", CommandType.StoredProcedure).ToList();
            }
            catch (DbException ex)
            {
                BaseDeDatosServicio.Rollback();
                throw ex;
            }
            catch (Exception ex)
            {
                BaseDeDatosServicio.Rollback();
                throw ex;
            }
        }
    }
}
