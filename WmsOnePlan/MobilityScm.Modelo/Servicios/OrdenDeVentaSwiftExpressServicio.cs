using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Utilerias;
using System.Linq;
using System.Net.Sockets;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Estados;
using MobilityScm.Modelo.Tipos;
using Telerik.OpenAccess.Data.Common;
using MobilityScm.Vertical.Entidades;

namespace MobilityScm.Modelo.Servicios
{
    public class OrdenDeVentaSwiftExpressServicio : IOrdenDeVentaSwiftExpressServicio
    {
        public IBaseDeDatosServicio BaseDeDatosServicio { get; set; }

        public OrdenDeVentaSwiftExpressServicio(IBaseDeDatosServicio baseDeDatosServicio)
        {
            BaseDeDatosServicio = baseDeDatosServicio;
        }
        public Operacion MarcarOrdenDeVentaConPicking(OrdenDeVentaEncabezado ordenDeVenta)
        {
            BaseDeDatosServicio.BeginTransaction();
            try
            {
                DbParameter[] parameters =
                {
                    new OAParameter
                    {
                        ParameterName = "@SALES_ORDER_ID",
                        Value = ordenDeVenta.SALES_ORDER_ID
                    },
                    new OAParameter
                    {
                        ParameterName = "@EXTERNAL_SOURCE_ID",
                        Value = ordenDeVenta.EXTERNAL_SOURCE_ID
                    }
                };

                var op = BaseDeDatosServicio.ExecuteQuery<Operacion>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_SET_SALE_ORDER_MAKE_PICKING_FROM_EXTERNAL_SOURCE", CommandType.StoredProcedure, parameters)[0];
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

        public IList<OrdenDeVentaEncabezado> ObtenerOrdenesDeVentaPorFecha(OrdenDeVentaArgumento ordenDeVentaArgumento)
        {
            DbParameter[] parameters =
           {
               new OAParameter
               {
                   ParameterName = "@START_DATETIME",
                   Value = ordenDeVentaArgumento.FechaInicio
               },
               new OAParameter
               {
                   ParameterName = "@END_DATETIME",
                   Value = ordenDeVentaArgumento.FechaFin
               },
               new OAParameter
               {
                   ParameterName = "@SOURCE_CODE_ROUTE",
                   Value = ordenDeVentaArgumento.CodigosFuenteRuta
               },
               new OAParameter
               {
                   ParameterName = "@CODE_ROUTE",
                   Value = ordenDeVentaArgumento.CodigosRuta
               },
               new OAParameter
               {
                   ParameterName = "@CODE_WAREHOUSE",
                   Value = ordenDeVentaArgumento.CodigoBodega
               },
               new OAParameter
               {
                   ParameterName = "@POLYGON",
                   Value = ordenDeVentaArgumento.CodigosPoligonos
               },
               new OAParameter
               {
                   ParameterName = "@EXTERNAL_SOURCE_POLYGON",
                   Value = ordenDeVentaArgumento.FuenteExternaPoligonos
               }
           };
            return BaseDeDatosServicio.ExecuteQuery<OrdenDeVentaEncabezado>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_SALES_ORDER_BY_DATE_FROM_EXTERNAL_SOURCE", CommandType.StoredProcedure, parameters).ToList();
        }

        public IList<OrdenDeVentaEncabezado> ObtenerOrdenesDeEntregaPorFecha(OrdenDeVentaArgumento ordenDeVentaArgumento)
        {
            DbParameter[] parameters =
           {
               new OAParameter
               {
                   ParameterName = "@START_DATE",
                   Value = ordenDeVentaArgumento.FechaInicio
               },
               new OAParameter
               {
                   ParameterName = "@END_DATE",
                   Value = ordenDeVentaArgumento.FechaFin
               },
               new OAParameter
               {
                   ParameterName = "@WAREHOUSE_CODE",
                   Value = ordenDeVentaArgumento.CodigoBodega
               },
               new OAParameter
               {
                   ParameterName = "@CLIENTS",
                   Value = ordenDeVentaArgumento.CodigosClientesErpCanalModerno
               },
               new OAParameter
               {
                   ParameterName = "@DOC_NUM",
                   Value = ordenDeVentaArgumento.DocNum
               }
           };
            return BaseDeDatosServicio.ExecuteQuery<OrdenDeVentaEncabezado>(BaseDeDatosServicio.Esquema + ".OP_WMS_GET_ERP_DELIVERY_ORDER_HEADER", CommandType.StoredProcedure, parameters).ToList();
        }

        public IList<OrdenDeVentaDetalle> ObtenerOrdenVentaDetalle(OrdenDeVentaEncabezado encabezado)
        {
            DbParameter[] parameters =
              {
               new OAParameter
               {
                   ParameterName = "@SALES_ORDER_ID",
                   Value = encabezado.SALES_ORDER_ID
               },
               new OAParameter
               {
                   ParameterName = "@EXTERNAL_SOURCE_ID",
                   Value = encabezado.EXTERNAL_SOURCE_ID
               }
           };
            return BaseDeDatosServicio.ExecuteQuery<OrdenDeVentaDetalle>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_SALE_ORDER_DETAIL_FROM_EXTERNAL", CommandType.StoredProcedure, parameters).ToList();
        }
        
        public IList<Sku> ValidarInventarioParaOrdenDeVenta(SkuArgumento skuArgumento)
        {
            DbParameter[] parameters =
           {
               new OAParameter
               {
                   ParameterName = "@XML",
                   Value = skuArgumento.SalesOrderDetailXml
               },
               new OAParameter
               {
                   ParameterName = "@CODE_WAREHOUSE",
                   Value = skuArgumento.CODE_WAREHOUSE
               },
               new OAParameter
               {
                   ParameterName = "@HANDLE_TONE_OR_CALIBER",
                   Value = skuArgumento.HandleToneOrCaliber
               },
               new OAParameter
               {
                   ParameterName = "@IN_PICKING_LINE",
                   Value = skuArgumento.EnLineaDePicking ? (int)SiNo.Si : (int)SiNo.No
               },
               new OAParameter
               {
                    ParameterName = "@PROJECT_ID",
                    Value = skuArgumento.Proyecto.ID
               },
               new OAParameter
               {
                    ParameterName = "@MIN_DAYS_EXPIRATION_DATE",
                    Value = skuArgumento.MIN_DAYS_EXPIRATION_DATE
               }
           };
            var result =
                BaseDeDatosServicio.ExecuteQuery<Sku>(
                    BaseDeDatosServicio.Esquema + ".OP_WMS_SP_VALIDATE_STOCK_INVENTORY_BY_MATERIAL_FOR_DISPATCH",
                    CommandType.StoredProcedure, parameters).ToList();

            if (result.Count > 0)
            {
                var componentes = result.Where(x => !string.IsNullOrEmpty(x.MASTER_PACK_ID)).ToList();
                result = result.Where(x => string.IsNullOrEmpty(x.MASTER_PACK_ID)).ToList();
                result.ForEach(y =>
                        {
                            y.ComponentesMasterPack = componentes.Where(x => x.MASTER_PACK_ID == y.MATERIAL_ID).ToList();
                        }
                );
            }

            return result;
        }

        public IList<OrdenDeVentaPendiente> ObtenerOrdenVentaPendientes(OrdenDeVentaArgumento ordenDeVentaArgumento)
        {
            DbParameter[] parameters =
          {
               new OAParameter
               {
                   ParameterName = "@START_DATETIME",
                   Value = ordenDeVentaArgumento.FechaInicio
               },
               new OAParameter
               {
                   ParameterName = "@END_DATETIME",
                   Value = ordenDeVentaArgumento.FechaFin
               },
               new OAParameter
               {
                   ParameterName = "@SOURCE_CODE_ROUTE",
                   Value = ordenDeVentaArgumento.CodigosFuenteRuta
               },
               new OAParameter
               {
                   ParameterName = "@CODE_ROUTE",
                   Value = ordenDeVentaArgumento.CodigosRuta
               }
           };
            return BaseDeDatosServicio.ExecuteQuery<OrdenDeVentaPendiente>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_DETAIL_SALES_ORDER_PENDING", CommandType.StoredProcedure, parameters).ToList();
        }

        public IList<OrdenDeVentaDetalle> ObtenerOrdenVentaDetalleDeOrdenes(OrdenDeVentaArgumento ordenDeVentaArgumento)
        {
            DbParameter[] parameters =
             {

               new OAParameter
               {
                   ParameterName = "@EXTERNAL_SOURCES_ID",
                   Value = ordenDeVentaArgumento.TextoFuentesExternas
               },
               new OAParameter
               {
                    ParameterName = "@SALES_ORDER_IDS",
                   Value = ordenDeVentaArgumento.TextoEncabezados
               }
               ,
               new OAParameter
               {
                    ParameterName = "@CODE_WAREHOUSE",
                   Value = ordenDeVentaArgumento.CodigoBodega
               }
           };
            return BaseDeDatosServicio.ExecuteQuery<OrdenDeVentaDetalle>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_SALE_ORDER_DETAIL_BY_ORDERS_FROM_EXTERNAL", CommandType.StoredProcedure, parameters).ToList();
        }

        public IList<OrdenDeVentaDetalle> ObtenerOrdenVentaDetalleConsolidadoDeOrdenes(OrdenDeVentaArgumento ordenDeVentaArgumento)
        {

            return (from detalles in ordenDeVentaArgumento.Detalles
                    group detalles by detalles.SKU
                into consolidado
                    select new OrdenDeVentaDetalle
                    {
                        SKU = consolidado.Key,
                        DESCRIPTION_SKU = consolidado.Max(x => x.DESCRIPTION_SKU),
                        BARCODE_ID = consolidado.Max(x => x.BARCODE_ID),
                        ALTERNATE_BARCODE = consolidado.Max(x => x.ALTERNATE_BARCODE),
                        EXTERNAL_SOURCE_ID = consolidado.Max(x => x.EXTERNAL_SOURCE_ID),
                        QTY = consolidado.Sum(x => x.QTY),
                        QTY_ORIGINAL = consolidado.Sum(x => x.QTY_ORIGINAL),
                        QTY_PENDING = consolidado.Sum(x => x.QTY_PENDING),
                        AVAILABLE_QTY = (ordenDeVentaArgumento.EsPorTonoOCalibre) || consolidado.Sum(x => x.QTY) < consolidado.Max(x => x.AVAILABLE_QTY) ? consolidado.Sum(x => x.QTY) : consolidado.Max(x => x.AVAILABLE_QTY),
                        AdvertenciaFaltaInventario = consolidado.Max(x => x.AdvertenciaFaltaInventario),
                        MASTER_ID_MATERIAL = consolidado.Max(x => x.MASTER_ID_MATERIAL),
                        MATERIAL_OWNER = consolidado.Max(x => x.MATERIAL_OWNER),
                        TONE = consolidado.Max(x => x.TONE),
                        CALIBER = consolidado.Max(x => x.CALIBER),
                        USE_PICKING_LINE = consolidado.Max(x => x.USE_PICKING_LINE),
                        MEASUREMENT_UNIT = "Unidad Base 1x1",
                        STATUS_CODE = ordenDeVentaArgumento.EstadoPredeterminadoDeMaterial.PARAM_NAME,
                        MATERIAL_WEIGHT = consolidado.Max(x => x.MATERIAL_WEIGHT),
                        TOTAL_WEIGHT = consolidado.Max(x => x.TOTAL_WEIGHT)
                    }
            ).ToList();
        }

        public IList<OrdenDeVentaReporte> ObtenerOrdenesParaReporteDeTrazabilidad(OrdenDeVentaArgumento arg)
        {
            DbParameter[] parameters =
            {
                new OAParameter
                {
                    ParameterName = "@WAREHOUSE",
                    Value = arg.CodigoBodega
                }
                ,new OAParameter
                {
                    ParameterName = "@START_DATE",
                    Value = arg.FechaInicio
                }
                ,new OAParameter
                {
                    ParameterName = "@END_DATE",
                    Value = arg.FechaFin
                }
                ,new OAParameter
                {
                    ParameterName = "@LOGIN",
                    Value = arg.Usuario
                }
            };
            return BaseDeDatosServicio.ExecuteQuery<OrdenDeVentaReporte>(BaseDeDatosServicio.Esquema + ".OP_WMS_GET_SONDA_SALES_ORDER_FOR_REPORT", CommandType.StoredProcedure, true, parameters);
        }
    }
}

