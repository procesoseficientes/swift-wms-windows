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
    public class OrdenDeVentaERPServicio : IOrdenDeVentaERPServicio
    {
        public IBaseDeDatosServicio BaseDeDatosServicio { get; set; }

        public OrdenDeVentaERPServicio(IBaseDeDatosServicio baseDeDatosServicio)
        {
            BaseDeDatosServicio = baseDeDatosServicio;
        }
        public IList<OrdenDeVentaEncabezado> ObtenerOrdenesDeVentaPorFecha(OrdenDeVentaArgumento ordenDeVentaArgumento)
        {
            DbParameter[] parameters =
        {
               new OAParameter
               {
                   ParameterName = "@START_DATE",
                   Value = ordenDeVentaArgumento.FechaInicio
               }
               ,
               new OAParameter
               {
                   ParameterName = "@END_DATE",
                   Value = ordenDeVentaArgumento.FechaFin
               }
               ,
               new OAParameter
               {
                   ParameterName = "@CLIENTS",
                   Value = ordenDeVentaArgumento.CodigosClientesErpCanalModerno
               },
               new OAParameter
               {
                   ParameterName = "@WAREHOUSE_CODE",
                   Value = ordenDeVentaArgumento.CodigoBodega
               },
               new OAParameter
               {
                   ParameterName = "@DOC_NUM",
                   Value = ordenDeVentaArgumento.DocNum
               }
           };
            return BaseDeDatosServicio.ExecuteQuery<OrdenDeVentaEncabezado>(BaseDeDatosServicio.Esquema + ".OP_WMS_GET_ERP_SALES_ORDER_HEADER_CHANNEL_MODERN", CommandType.StoredProcedure, parameters);
        }

        public IList<OrdenDeVentaDetalle> ObtenerOrdenVentaDetalle(OrdenDeVentaArgumento argumento)
        {
            DbParameter[] parameters =
         {
               new OAParameter
               {
                   ParameterName = "@DOC_NUM",
                   Value = argumento.TextoEncabezados
               },
               new OAParameter
               {
                   ParameterName = "@EXTERNAL_SOURCE_ID",
                   Value = argumento.TextoFuentesExternas
               }
           };
            return BaseDeDatosServicio.ExecuteQuery<OrdenDeVentaDetalle>(BaseDeDatosServicio.Esquema + ".OP_WMS_GET_ERP_SALES_ORDER_DETAIL_CHANNEL_MODERN", CommandType.StoredProcedure, false, parameters);
        }

        public IList<OrdenDeVentaPendiente> ObtenerOrdenVentaPendientes(OrdenDeVentaArgumento ordenDeVentaArgumento)
        {
            DbParameter[] parameters =
                {
                new OAParameter
                {
                    ParameterName = "@START_DATE",
                    Value = ordenDeVentaArgumento.FechaInicio
                }
                ,new OAParameter
                {
                    ParameterName = "@END_DATE",
                    Value = ordenDeVentaArgumento.FechaFin
                }
            };
            return BaseDeDatosServicio.ExecuteQuery<OrdenDeVentaPendiente>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_ERP_DETAIL_SALES_ORDER_CHANNEL_MODERN_PENDING", CommandType.StoredProcedure, false, parameters);
        }

        public IList<OrdenDeVentaDetalle> ObtenerOrdenVentaDetalleDeOrdenes(OrdenDeVentaArgumento argumento)
        {
            DbParameter[] parameters =
        {
               new OAParameter
               {
                   ParameterName = "@DOC_NUMS",
                   Value = argumento.TextoEncabezados
               },
               new OAParameter
               {
                   ParameterName = "@EXTERNAL_SOURCE_IDS",
                   Value = argumento.TextoFuentesExternas
               }
               ,
               new OAParameter
               {
                    ParameterName = "@CODE_WAREHOUSE",
                   Value = argumento.CodigoBodega
               }
                ,new OAParameter
                {
                    ParameterName = "@START_DATE",
                    Value = argumento.FechaInicio
                }
                ,new OAParameter
                {
                    ParameterName = "@END_DATE",
                    Value = argumento.FechaFin
                }
           };
            return BaseDeDatosServicio.ExecuteQuery<OrdenDeVentaDetalle>(BaseDeDatosServicio.Esquema + ".OP_WMS_GET_ERP_SALES_ORDER_DETAIL_BY_ORDERS_CHANNEL_MODERN", CommandType.StoredProcedure, false, parameters);
        }


        public IList<MaterialConTonoYCalibre> ObtenerTonosYCalibresDeMateriales(SkuArgumento skuArgumento)
        {
            DbParameter[] parameters =
        {
               new OAParameter
               {
                   ParameterName = "@MATERIAL_ID",
                   Value = skuArgumento.CODE_MATERIALS
               }
               ,
               new OAParameter
               {
                   ParameterName = "@WAREHOUSE_ID",
                   Value = skuArgumento.CODE_WAREHOUSE
               }
           };
            return BaseDeDatosServicio.ExecuteQuery<MaterialConTonoYCalibre>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_MATERIAL_WITH_TONE_AND_CALIBER_BY_MATERIALS", CommandType.StoredProcedure, parameters);
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
            return BaseDeDatosServicio.ExecuteQuery<OrdenDeVentaReporte>(BaseDeDatosServicio.Esquema + ".OP_WMS_GET_ERP_SALES_ORDER_FOR_REPORT", CommandType.StoredProcedure, true, parameters);
        }
    }
}
