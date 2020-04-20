using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Utilerias;
using MobilityScm.Vertical.Entidades;
using Telerik.OpenAccess.Data.Common;

namespace MobilityScm.Modelo.Servicios
{
    public class InventarioComprometidoServicio : IInventarioComprometidoServicio
    {
        #region Propiedades

        public IBaseDeDatosServicio BaseDeDatosServicio { get; set; }

        #endregion

        #region Constructor

        public InventarioComprometidoServicio(IBaseDeDatosServicio baseDeDatosServicio)
        {
            BaseDeDatosServicio = baseDeDatosServicio;
        }

        #endregion

        #region Metodos


        public IList<InventarioComprometidoEncabezado> ObtenerEncabezadosParaReporteDeInventarioComprometido(
            InventarioComprometidoArgumento inventarioComprometidoArgumento)
        {
            DbParameter[] parameters =
           {
                new OAParameter
               {
                   ParameterName = "@INIT_DATE",
                   Value = inventarioComprometidoArgumento.FechaInicio
               },
                new OAParameter
               {
                   ParameterName = "@END_DATE",
                   Value = inventarioComprometidoArgumento.FechaFinal
               },
               new OAParameter
               {
                   ParameterName = "@LOGIN_ID",
                   Value = inventarioComprometidoArgumento.Usuario
               }
           };
            return
                BaseDeDatosServicio.ExecuteQuery<InventarioComprometidoEncabezado>(
                    $"{BaseDeDatosServicio.Esquema}.OP_WMS_SP_GET_COMMITTED_INVENTORY_REPORT",
                    CommandType.StoredProcedure, parameters).ToList();
        }

        public IList<InventarioComprometidoDetalle> ObtenerDetallesParaReporteDeInventarioComprometido(InventarioComprometidoArgumento inventarioComprometidoArgumento)
        {
            var serializer = new XmlSerializer(typeof(List<InventarioComprometidoEncabezado>));
            var xmlDocumentos = new StringWriter();
            var xmlWriter = new XmlTextWriter(xmlDocumentos) { Formatting = Formatting.Indented };
            serializer.Serialize(xmlWriter, inventarioComprometidoArgumento.InventarioComprometidoEncabezados.ToList());
            var documentos = xmlDocumentos.ToString();

            DbParameter[] parameters =
            {
                new OAParameter
                {
                    ParameterName = "@DEMAND_HEADER_XML", Value = documentos
                }
            };
            return
                BaseDeDatosServicio.ExecuteQuery<InventarioComprometidoDetalle>(
                    $"{BaseDeDatosServicio.Esquema}.OP_WMS_SP_GET_DETAIL_OF_COMMITTED_INVENTORY_REPORT",
                    CommandType.StoredProcedure, parameters).ToList();
        }

        public Operacion CancelarOrdenPreparada(InventarioComprometidoArgumento inventarioComprometidoArgumento)
        {
            DbParameter[] parameters =
            {
                new OAParameter
                {
                    ParameterName = "@PICKING_DEMAND_HEADER_ID",
                    Value = inventarioComprometidoArgumento.PickingDemandHeaderId
                }
            };

            return
                BaseDeDatosServicio.ExecuteQuery<Operacion>(
                    $"{BaseDeDatosServicio.Esquema}.OP_WMS_CANCEL_PREPARED_DISPATCH",
                    CommandType.StoredProcedure, parameters).FirstOrDefault();
        }

        #endregion

    }
}