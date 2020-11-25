using MobilityScm.Modelo.Interfaces.Servicios;
using System.Collections.Generic;
using System.Linq;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Utilerias;
using System.Data;
using System.Data.Common;
using MobilityScm.Modelo.Argumentos;
using Telerik.OpenAccess.Data.Common;

namespace MobilityScm.Modelo.Servicios
{
    /// <summary>
    /// Ubicacion servicio
    /// </summary>
    public class UbicacionServicio : IUbicacionServicio
    {

        /// <summary>
        /// IBase de datos servicio
        /// </summary>
        public IBaseDeDatosServicio BaseDeDatosServicio { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="baseDeDatosServicio"></param>
        public UbicacionServicio(IBaseDeDatosServicio baseDeDatosServicio)
        {
            BaseDeDatosServicio = baseDeDatosServicio;
        }

        /// <summary>
        /// Obtener ubicaciones tipo rampa y puerta.
        /// </summary>
        /// <returns></returns>
        public IList<Ubicacion> ObtenerUbicacionesTipoRampaYPuertaParaRecepcion(string distributionCenterId)
        {
            DbParameter[] parameters = {
                new OAParameter
                {
                    ParameterName = "@DISTRIBUTION_CENTER_ID",
                    Value =  distributionCenterId
                }
            };

            return BaseDeDatosServicio.ExecuteQuery<Ubicacion>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_LOCATION_FOR_RECEPTION", CommandType.StoredProcedure, parameters);
        }

        /// <summary>
        /// Obtener ubicaciones tipo rampa y puerta.
        /// </summary>
        /// <returns></returns>
        public IList<Ubicacion> ObtenerUbicacionesTipoRampaYPuertaParaDespacho(string distributionCenterId)
        {
            DbParameter[] parameters = {
                new OAParameter
                {
                    ParameterName = "@WAREHOUSE_ID",
                    Value =  distributionCenterId
                }
            };

            return BaseDeDatosServicio.ExecuteQuery<Ubicacion>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_LOCATION_FOR_DISPATCH", CommandType.StoredProcedure, parameters);
        }

        public IList<Ubicacion> ObtenerUbicacionesPorZonaOBodega(ConteoFisicoArgumento arg)
        {
            DbParameter[] parameters = {
                new OAParameter
                {
                    ParameterName = "@WAREHOUSE",
                    Value =  arg.Bodegas
                },
                new OAParameter
                {
                    ParameterName = "@ZONE",
                    Value =  (arg.Zonas == string.Empty ?  null : arg.Zonas)
                }
            };

            return BaseDeDatosServicio.ExecuteQuery<Ubicacion>
                (BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_LOCATION_BY_ZONE_OR_WAREHOUSE", CommandType.StoredProcedure, true, parameters).ToList();
        }

        public IList<ConteoFisicoDetalle> ObtenerUbicacionesPorFiltros(ConteoFisicoArgumento arg)
        {
            DbParameter[] parameters = {
                   new OAParameter
                   {
                       ParameterName = "@WAREHOUSE",
                       Value =  arg.Bodegas
                   },
                   new OAParameter
                   {
                       ParameterName = "@REGIMEN",
                       Value =  arg.Regimen
                   },
                new OAParameter
                   {
                       ParameterName = "@ZONE",
                       Value =  (arg.Zonas == string.Empty ?  null : arg.Zonas)
                   },
                   new OAParameter
                   {
                       ParameterName = "@CLIENT_CODE",
                       Value =  (arg.Clientes == string.Empty ?  null : arg.Clientes)
                   },
                     new OAParameter
                   {
                       ParameterName = "@LOCATION",
                       Value =  (arg.Ubicaciones == string.Empty ?  null : arg.Ubicaciones)
                   },
                   new OAParameter
                   {
                       ParameterName = "@MATERIAL",
                       Value =  (arg.Materiales == string.Empty ?  null : arg.Materiales)
                   },
                    new OAParameter
                   {
                       ParameterName = "@EMPTY_LOCATIONS",
                       Value =  arg.UbicacionesVacias
                   }
                };

            return BaseDeDatosServicio.ExecuteQuery<ConteoFisicoDetalle>
                (BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_LOCATIONS_FOR_PHISICAL_COUNT_BY_FILTERS", CommandType.StoredProcedure, true, parameters).ToList();
        }

        public IList<Zona> ObtenerZonasPorBodegas(InventarioInactivoArgumento arg)
        {
            DbParameter[] parameters = {
                new OAParameter
                {
                    ParameterName = "@LOGIN",
                    Value =  arg.Login
                },
                new OAParameter
                {
                    ParameterName = "@WAREHOUSE_XML",
                    Value =  arg.WarehouseXml
                }
            };

            return BaseDeDatosServicio.ExecuteQuery<Zona>
                (BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_ZONES_BY_WAREHOUSE_XML", CommandType.StoredProcedure, true, parameters).ToList();
        }
    }
}
