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
using MobilityScm.Vertical.Entidades;
using Telerik.OpenAccess.Data.Common;
using MobilityScm.Modelo.Tipos;

namespace MobilityScm.Modelo.Servicios
{
    public class InventarioServicio : IInventarioServicio
    {
        public IBaseDeDatosServicio BaseDeDatosServicio { get; set; }

        public InventarioServicio(IBaseDeDatosServicio baseDeDatosServicio)
        {
            BaseDeDatosServicio = baseDeDatosServicio;
        }

        public IList<Inventario> ObtenerInventario(InventarioArgumento inventarioArgumento)
        {
            DbParameter[] parameters =
           {
               new OAParameter
               {
                   ParameterName = "@LOGIN",
                   Value = inventarioArgumento.UsuarioId
               }
           };
            return BaseDeDatosServicio.ExecuteQuery<Inventario>($"{BaseDeDatosServicio.Esquema}.OP_WMS_SP_GET_INVENTORY", CommandType.StoredProcedure, parameters).ToList();
        }

        public Operacion ActualizarEstadoDelMaterialPorLicencia(InventarioArgumento inventarioArgumento)
        {
            try
            {
                DbParameter[] parameters ={
                    new OAParameter
                    {
                        ParameterName = "@XML",
                        Value = inventarioArgumento.XmlDeLicencias
                    }
                };

                var op = BaseDeDatosServicio.ExecuteQuery<Operacion>($"{BaseDeDatosServicio.Esquema}.OP_WMS_SP_UPDATE_STATUS_BY_MATERIAL", CommandType.StoredProcedure, false, parameters)[0];

                if (op.Resultado != ResultadoOperacionTipo.Error)
                    BaseDeDatosServicio.Commit();
                else
                    BaseDeDatosServicio.Rollback();

                return op;
            }
            catch (Exception ex)
            {
                BaseDeDatosServicio.Rollback();
                return new Operacion
                {
                    Codigo = -1,
                    Mensaje = ex.Message,
                    Resultado = Tipos.ResultadoOperacionTipo.Error
                };
            }
        }

        public IList<ReporteDeInventarioDiario> ObtenerReporteDiarioDeInventario(ConsultaArgumento argumento)
        {
            DbParameter[] parameters =
            {
                new OAParameter
                {
                    ParameterName = "@REPORT_DATETIME",
                    Value = argumento.FechaInicial
                },
                new OAParameter
                {
                    ParameterName = "@WAREHOUSE",
                    Value = argumento.CodigoBodega
                }
                ,
                new OAParameter
                {
                    ParameterName = "@LOGIN",
                    Value = argumento.Login
                }
            };
            return BaseDeDatosServicio.ExecuteQuery<ReporteDeInventarioDiario>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_DAILY_INVENTORY_REPORT", CommandType.StoredProcedure, parameters).ToList();
        }

        public IList<InventarioInactivo> ObtenerInventarioInactivo(InventarioInactivoArgumento arg)
        {
            DbParameter[] parameters =
            {
                new OAParameter
                {
                    ParameterName = "@LOGIN",
                    Value =  arg.Login
                },
                new OAParameter
                {
                    ParameterName = "@WAREHOUSE_XML",
                    Value =  arg.WarehouseXml
                },
                new OAParameter
                {
                    ParameterName = "@ZONE_XML",
                    Value =  arg.ZoneXml
                },
                new OAParameter
                {
                    ParameterName = "@MATERIAL_XML",
                    Value =  arg.MaterialXml
                }
            };
            return BaseDeDatosServicio.ExecuteQuery<InventarioInactivo>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_IDLE", CommandType.StoredProcedure, parameters).ToList();
        }

        public IList<SugeridoCompra> ObtenerSugeridoCompra(SugeridoCompraArgumento arg)
        {
            DbParameter[] parameters =
            {
                new OAParameter
                {
                    ParameterName = "@LOGIN",
                    Value =  arg.Login
                },
                new OAParameter
                {
                    ParameterName = "@WAREHOUSE_XML",
                    Value =  arg.WarehouseXml
                },
                new OAParameter
                {
                    ParameterName = "@MATERIAL_XML",
                    Value =  arg.MaterialXml
                }
            };
            return BaseDeDatosServicio.ExecuteQuery<SugeridoCompra>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_SUGGESTED_PURCHASE", CommandType.StoredProcedure, parameters).Where(s => s.STOCK_MIN > 0).ToList();
        }
    }
}
