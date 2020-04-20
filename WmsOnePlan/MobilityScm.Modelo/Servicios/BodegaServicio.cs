using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Utilerias;
using Telerik.OpenAccess.Data.Common;

namespace MobilityScm.Modelo.Servicios
{
    public class BodegaServicio : IBodegaServicio
    {
        public IBaseDeDatosServicio BaseDeDatosServicio { get; set; }

        public BodegaServicio(IBaseDeDatosServicio baseDeDatosServicio)
        {
            BaseDeDatosServicio = baseDeDatosServicio;
        }

        public IList<Bodega> ObtenerBodegaAsignadaAUsuario(string login)
        {
            DbParameter[] parameters =
           {
               new OAParameter
               {
                   ParameterName = "@LOGIN",
                   Value =login
               },
           };
            return BaseDeDatosServicio.ExecuteQuery<Bodega>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_WAREHOUSE_BY_USER_CD", CommandType.StoredProcedure, parameters).ToList();
        }

        public IList<Bodega> ObtenerBodegaAsignadaAUsuarioSugCompra(string login)
        {
            DbParameter[] parameters =
           {
               new OAParameter
               {
                   ParameterName = "@LOGIN",
                   Value =login
               },
           };
            return BaseDeDatosServicio.ExecuteQuery<Bodega>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_WH_BY_USER_CD_SUGG_PURCH", CommandType.StoredProcedure, parameters).ToList();
        }
        
        public IList<Bodega> ObtenerBodegasPorUsuariosRelacionados(ConteoFisicoArgumento conteoFisicoArgumento)
        {
            DbParameter[] parameters =
           {
               new OAParameter
               {
                   ParameterName = "@LOGIN",
                   Value = conteoFisicoArgumento.Login
               },
               new OAParameter
               {
                   ParameterName = "@OPERATORS",
                   Value = conteoFisicoArgumento.Operadores
               },
           };
            return BaseDeDatosServicio.ExecuteQuery<Bodega>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_WAREHOUSE_BY_RELATED_USERS", CommandType.StoredProcedure, parameters).ToList();
        }

        public IList<Zona> ObtenerZonasDeUnaBodega(Bodega argumento)
        {
            DbParameter[] parameters =
            {
               new OAParameter
               {
                   ParameterName = "@WAREHOUSE",
                   Value = argumento.WAREHOUSE_ID
               },
           };
            return BaseDeDatosServicio.ExecuteQuery<Zona>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_ZONES_BY_WAREHOUSE", CommandType.StoredProcedure, parameters).ToList();
        }

        public IList<Bodega> ObtenerBodegaPorCentroDeDistribucion(Bodega argumento)
        {
            DbParameter[] parameters =
            {
               new OAParameter
               {
                   ParameterName = "@DISTRIBUTION_CENTER",
                   Value = argumento.DISTRIBUTION_CENTER_ID
               },new OAParameter
               {
                   ParameterName = "@LOGIN_ID",
                   Value = argumento.LOGIN
               },
           };
            return BaseDeDatosServicio.ExecuteQuery<Bodega>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_WAREHOUSE_BY_DISTRIBUTION_CENTER", CommandType.StoredProcedure, parameters).ToList();
        }

        public IList<Bodega> ObtenerBodegaPorCentroDeDistribucionYUsuario(Bodega argumento)
        {
            DbParameter[] parameters =
            {
               new OAParameter
               {
                   ParameterName = "@DISTRIBUTION_CENTER",
                   Value = argumento.DISTRIBUTION_CENTER_ID
               },new OAParameter
               {
                   ParameterName = "@LOGIN_ID",
                   Value = argumento.LOGIN
               },new OAParameter
               {
                   ParameterName = "@IS_WAREHOUSE_FROM",
                   Value = argumento.IS_WAREHOUSE_FROM
               },
           };
            return BaseDeDatosServicio.ExecuteQuery<Bodega>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_WAREHOUSE_BY_DISTRIBUTION_CENTER_AND_USER", CommandType.StoredProcedure, parameters).ToList();
        }

        public IList<Entidades.Configuracion> ObtenerLineasDePickingAsociadasABodega(Bodega argumento)
        {
            DbParameter[] parameters =
            {
                new OAParameter
                {
                    ParameterName = "@WAREHOUSE_ID",
                    Value = argumento.WAREHOUSE_ID
                },
            };
            return BaseDeDatosServicio.ExecuteQuery<Entidades.Configuracion>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_PICKING_LINE_BY_WAREHOUSE_ID", CommandType.StoredProcedure, parameters).ToList();
        }

        public IList<Entidades.Configuracion> ObtenerLineasDePickingAsociadasABodegaDelUsuario(Bodega argumento)
        {
            DbParameter[] parameters =
            {
                new OAParameter
                {
                    ParameterName = "@LOGIN",
                    Value = argumento.LOGIN
                },
            };
            return BaseDeDatosServicio.ExecuteQuery<Entidades.Configuracion>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_PICKING_LINE_BY_LOGIN", CommandType.StoredProcedure, parameters).ToList();
        }

      public  IList<BodegaERP> ObtenerBodegasDeERP(string owner)
        {
            DbParameter[] parameters =
            {
                new OAParameter
                {
                    ParameterName = "@OWNER",
                    Value = owner
                },
            };
            return BaseDeDatosServicio.ExecuteQuery<Entidades.BodegaERP>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_ERP_MAPPED_WAREHOUSE_BY_OWNER", CommandType.StoredProcedure, parameters).ToList();
        }
    }
}
