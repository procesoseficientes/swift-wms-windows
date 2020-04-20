

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Modelo.Tipos;
using MobilityScm.Utilerias;
using MobilityScm.Vertical.Entidades;
using Telerik.OpenAccess.Data.Common;

namespace MobilityScm.Modelo.Servicios
{
    public class ManifiestoCargaServicio : IManifiestoCargaServicio
    {

        #region Base de datos
        public IBaseDeDatosServicio BaseDeDatosServicio { get; set; }

        public ManifiestoCargaServicio(IBaseDeDatosServicio baseDeDatosServicio)
        {
            BaseDeDatosServicio = baseDeDatosServicio;
        }
        #endregion

        public IList<ManifiestoCarga> ConsultarManifiesto(ManifiestoArgumento arg)
        {
            DbParameter[] parameters =
            {
                new OAParameter
                {
                    ParameterName = "@MANIFEST_HEADER_ID",
                    Value = arg.ManifiestoEncabezado.MANIFEST_HEADER_ID
                }
            };
            return BaseDeDatosServicio.ExecuteQuery<ManifiestoCarga>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_MANIFIEST_REPORT", CommandType.StoredProcedure, parameters);
        }

        public Operacion GrabarManifiestoDetalle(ManifiestoArgumento arg)
        {
            var op = new Operacion();
            foreach (var detalle in arg.ManifiestoDetalle)
            {
                DbParameter[] parameters = {
                   new OAParameter
                   {
                       ParameterName = "@MANIFEST_HEADER_ID",
                       Value = arg.ManifiestoEncabezado.MANIFEST_HEADER_ID
                   },
                   new OAParameter
                   {
                       ParameterName = "@PICKING_DEMAND_HEADER_ID",
                       Value = detalle.PICKING_DEMAND_HEADER_ID
                   },
                   new OAParameter
                   {
                       ParameterName = "@LAST_UPDATE_BY",
                       Value = arg.ManifiestoEncabezado.LAST_UPDATE_BY
                   }
                };
                op = BaseDeDatosServicio.ExecuteQuery<Operacion>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_INSERT_MANIFEST_DETAIL", CommandType.StoredProcedure, false, parameters)[0];
                if (op.Resultado != ResultadoOperacionTipo.Exito)
                {
                    throw new Exception(op.Mensaje);
                }
            }
            return op;
        }

        public Operacion GrabarManifiestoEncabezado(ManifiestoArgumento arg)
        {
            try
            {
                BaseDeDatosServicio.BeginTransaction();
                DbParameter[] parameters = {
                   new OAParameter
                   {
                       ParameterName = "@DRIVER",
                       Value = arg.ManifiestoEncabezado.DRIVER
                   }
                   ,
                       new OAParameter
                   {
                       ParameterName = "@VEHICLE",
                       Value = arg.ManifiestoEncabezado.VEHICLE
                   }
                   ,
                    new OAParameter
                   {
                       ParameterName = "@LAST_UPDATE_BY",
                       Value = arg.ManifiestoEncabezado.LAST_UPDATE_BY
                   }
                    ,
                    new OAParameter
                   {
                       ParameterName = "@MANIFEST_TYPE",
                       Value = arg.ManifiestoEncabezado.MANIFEST_TYPE
                   }
                    ,
                    new OAParameter
                   {
                       ParameterName = "@TRANSFER_REQUEST_ID",
                       Value = arg.ManifiestoEncabezado.TRANSFER_REQUEST_ID
                   }
                };
                var op = BaseDeDatosServicio.ExecuteQuery<Operacion>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_INSERT_MANIFEST_HEADER", CommandType.StoredProcedure, false, parameters)[0];
                if (op.Resultado == ResultadoOperacionTipo.Exito)
                {
                    var manifestHeaderId = op.DbData;
                    arg.ManifiestoEncabezado.MANIFEST_HEADER_ID = Convert.ToInt32(op.DbData);
                    op = GrabarManifiestoDetalle(arg);
                    if (op.Resultado != ResultadoOperacionTipo.Exito)
                    {
                        throw new Exception("Ocurrió un error al guardar el detalle del manifiesto: " + op.Mensaje);
                    }
                    op.DbData = manifestHeaderId;
                }
                else
                {
                    if (op.Resultado != ResultadoOperacionTipo.Exito)
                    {
                        throw new Exception("Ocurrió un error al guardar el encabezado del manifiesto: " + op.Mensaje);
                    }
                }
                return op;
            }
            catch (Exception ex)
            {
                BaseDeDatosServicio.Rollback();
                throw new Exception("Error al agregar manifiesto: " + ex.Message);
            }
        }

        public ManifiestoEncabezado ObtenerManifiestoDeCarga(ManifiestoArgumento arg)
        {
            try
            {
                var manifiesto = ObtenerManifiestoEncabezado(arg);
                if (manifiesto != null)
                    manifiesto.Detalle = ObtenerManifiestoDetalle(arg);
                return manifiesto;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el manifiesto de carga: " + ex.Message);
            }
        }

        private ManifiestoEncabezado ObtenerManifiestoEncabezado(ManifiestoArgumento arg)
        {
            DbParameter[] parameters =
            {
                new OAParameter
                {
                    ParameterName = "@MANIFEST_HEADER_ID",
                    Value = arg.IdManifiestoDeCarga
                }
            };
            var encabezados = BaseDeDatosServicio.ExecuteQuery<ManifiestoEncabezado>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_MANIFEST_HEADER", CommandType.StoredProcedure, parameters);
            return encabezados.Count == 0 ? null : encabezados[0];
        }
        public IList<ManifiestoDetalle> ObtenerManifiestoDetalle(ManifiestoArgumento arg)
        {
            DbParameter[] parameters =
            {
                new OAParameter
                {
                    ParameterName = "@MANIFEST_HEADER_ID",
                    Value = arg.IdManifiestoDeCarga
                }
            };
            return BaseDeDatosServicio.ExecuteQuery<ManifiestoDetalle>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_MANIFEST_DETAIL", CommandType.StoredProcedure, parameters);
        }

        public Operacion CrearManifiestoDeCargaDesdeDemandaDeDespacho(PickingArgumento argumento, VehiculoManifiesto vehiculo)
        {
            try
            {
                var listadoEncabezado = argumento.Encabezados.Select(x =>
                   new ManifiestoDetalle()
                    {
                       PICKING_DEMAND_HEADER_ID = x.PICKING_DEMAND_HEADER_ID,
                       WAVE_PICKING_ID = x.WAVE_PICKING_ID
                   }).ToList()
                ;
                var serializer = new XmlSerializer(typeof(List<ManifiestoDetalle>));
                var xmlDocumentos = new StringWriter();
                var xmlWriter = new XmlTextWriter(xmlDocumentos) { Formatting = Formatting.Indented };
                serializer.Serialize(xmlWriter, listadoEncabezado);
                var xml = xmlDocumentos.ToString();

                DbParameter[] parameters =
                {
                    new OAParameter
                    {
                        ParameterName = "@VEHICLE_CODE",
                        Value = vehiculo.VEHICLE_CODE
                    },
                    new OAParameter
                    {
                        ParameterName = "@LOGIN",
                        Value = argumento.Login
                    }
                    ,
                    new OAParameter
                    {
                        ParameterName = "@XML",
                        Value = xml
                    }
                };
                return BaseDeDatosServicio.ExecuteQuery<Operacion>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_CREATE_MANIFEST_FROM_PICKING_DEMAND", CommandType.StoredProcedure, false, parameters).FirstOrDefault();
            }
            catch (Exception e)
            {
                return new Operacion
                {
                    Resultado = ResultadoOperacionTipo.Error,
                    Mensaje = e.Message,
                    Codigo = -1
                };
            }
        }

        public Operacion EliminarManifiestoDetalle(ManifiestoArgumento argumento)
        {
            DbParameter[] parameters =
                {
                    new OAParameter
                    {
                        ParameterName = "@MANIFEST_HEADER_ID",
                        Value = argumento.ManifiestoEncabezado.MANIFEST_HEADER_ID
                    }
                };
            var operacion = BaseDeDatosServicio.ExecuteQuery<Operacion>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_DELETE_MANIFEST_DETAIL", CommandType.StoredProcedure, false, parameters).FirstOrDefault();
            if (operacion != null && operacion.Resultado == ResultadoOperacionTipo.Error)
            {
                throw new Exception(operacion.Mensaje);
            }
            return operacion;
        }

        public Operacion EliminarManifiestoDetalleCertificado(ManifiestoArgumento argumento)
        {
            DbParameter[] parameters =
                {
                    new OAParameter
                    {
                        ParameterName = "@MANIFEST_HEADER_ID",
                        Value = argumento.ManifiestoEncabezado.MANIFEST_HEADER_ID
                    },
                    new OAParameter
                    {
                        ParameterName = "@DEMAND_HEADER_ID",
                        Value = argumento.DemandasDespacho
                    }
                };
            var operacion = BaseDeDatosServicio.ExecuteQuery<Operacion>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_DELETE_MANIFEST_DETAIL_WHEN_ITS_CERTIFIED", CommandType.StoredProcedure, false, parameters).FirstOrDefault();
            if (operacion != null && operacion.Resultado == ResultadoOperacionTipo.Error)
            {
                throw new Exception(operacion.Mensaje);
            }
            return operacion;
        }
    }
}
