using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Utilerias;
using Telerik.OpenAccess.Data.Common;
using DevExpress.XtraMap;

namespace MobilityScm.Modelo.Servicios
{
    public class PoligonoServicio : IPoligonoServicio  
    {
        public IBaseDeDatosServicio BaseDeDatosServicio { get; set; }

        public PoligonoServicio(IBaseDeDatosServicio baseDeDatosServicio)
        {
            BaseDeDatosServicio = baseDeDatosServicio;
        }

        public IList<Poligono> ObtenerPoligonosDeDistribucionPorBodega(OrdenDeVentaArgumento argumento)
        {
            DbParameter[] parameters =
               {
                   new OAParameter
                   {
                       ParameterName = "@WAREHOUSE_ID",
                       Value = argumento.CodigoBodega
                   }
               };
            var poligonos = BaseDeDatosServicio.ExecuteQuery<Poligono>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_DISTRIBUTION_POLYGON_BY_WAREHOUSE", CommandType.StoredProcedure, false, parameters).ToList();
            var rnd = new Random();
            foreach (var poligono in poligonos)
            {
                poligono.Fill = Color.FromArgb(90, rnd.Next(1, 150), rnd.Next(1, 250), rnd.Next(1, 250));
                poligono.PuntosDePoligono = ObtenerPuntosDePoligono(poligono);
                foreach (var punto in from p in poligono.PuntosDePoligono
                                      orderby p.POSITION ascending
                                      select p)
                {
                    poligono.Points.Add(punto.GeoPunto);
                }

                poligono.Attributes.Add(new MapItemAttribute()
                {
                    Name = "Nombre",
                    Type = typeof(string),
                    Value = poligono.POLYGON_NAME
                });

                poligono.Attributes.Add(new MapItemAttribute()
                {
                    Name = "Id",
                    Type = typeof(int),
                    Value = poligono.POLYGON_ID
                });
                poligono.ToolTipPattern = "Id: {Id}\nNombre: {Nombre}";
            }
            return poligonos;
        }

        private IList<PuntoDePoligono> ObtenerPuntosDePoligono(Poligono poligono)
        {
            DbParameter[] parameters =
               {
                   new OAParameter
                   {
                       ParameterName = "@POLYGON_ID",
                       Value = poligono.POLYGON_ID
                   },
                   new OAParameter
                   {
                       ParameterName = "@EXTERNAL_SOURCE_ID",
                       Value = poligono.EXTERNAL_SOURCE_ID
                   }
               };
            return BaseDeDatosServicio.ExecuteQuery<PuntoDePoligono>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_POINTS_BY_POLYGON", CommandType.StoredProcedure, false, parameters).ToList();
        }
    }
}
