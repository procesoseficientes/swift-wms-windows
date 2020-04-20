using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Utilerias;
using System.Linq;
using Telerik.OpenAccess.Data.Common;
using MobilityScm.Modelo.Argumentos;
using System;

namespace MobilityScm.Modelo.Servicios
{
    public class RutasSwiftExpressServicio : IRutasSwiftExpressServicio
    {
        public IBaseDeDatosServicio BaseDeDatosServicio { get; set; }


        public RutasSwiftExpressServicio(IBaseDeDatosServicio baseDeDatosServicio)
        {
            BaseDeDatosServicio = baseDeDatosServicio;

        }

        public IList<Ruta> ObtenerRutas()
        {
            var ls = BaseDeDatosServicio.ExecuteQuery<Ruta>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_ROUTES_FROM_EXTERNAL_SOURCE", CommandType.StoredProcedure, null).ToList();
            return ls;
        }
        public IList<Ruta> ObtenerTodasRutas()
        {
            var ls = BaseDeDatosServicio.ExecuteQuery<Ruta>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_ALL_ROUTES_FROM_EXTERNAL_SOURCE", CommandType.StoredProcedure, true, null).ToList();
            return ls;
        }

        public IList<Ruta> ObtenerTodasRutasAsociadasABodega(string bodegas)
        {
            DbParameter[] parameters =
           {
                new OAParameter
                {
                    ParameterName = "@WAREHOUSE",
                    Value = bodegas
                }
            };
            var ls = BaseDeDatosServicio.ExecuteQuery<Ruta>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_ALL_ROUTES_FROM_EXTERNAL_SOURCE_BY_WAREHOUSE"
                , CommandType.StoredProcedure, true, parameters).ToList();
            return ls;
        }

        public IList<Ruta> ObtenerRutasPorPoligonosPorFecha(OrdenDeVentaArgumento argumento)
        {
            DbParameter[] parameters =
            {
                new OAParameter
                {
                    ParameterName = "@POLYGON",
                    Value = argumento.CodigosPoligonos
                },new OAParameter
                {
                    ParameterName = "@EXTERNAL_SOURCE_POLYGON",
                    Value = argumento.FuenteExternaPoligonos
                },new OAParameter
                {
                    ParameterName = "@START_DATE",
                    Value = argumento.FechaInicio
                },new OAParameter
                {
                    ParameterName = "@END_DATE",
                    Value = argumento.FechaFin
                }
            };
            return BaseDeDatosServicio.ExecuteQuery<Ruta>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_ROUTES_BY_POLYGON_AND_DATES"
                , CommandType.StoredProcedure, true, parameters).ToList();
        }
    }
}
