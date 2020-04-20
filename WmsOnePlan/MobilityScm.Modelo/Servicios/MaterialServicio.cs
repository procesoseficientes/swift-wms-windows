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
    public class MaterialServicio : IMaterialServicio
    {
        public IBaseDeDatosServicio BaseDeDatosServicio { get; set; }

        public MaterialServicio(IBaseDeDatosServicio baseDeDatosServicio)
        {
            BaseDeDatosServicio = baseDeDatosServicio;
        }

        public IList<Sku> ObtenerMaterialesPorBodegaClienteUbicacionOZona(ConteoFisicoArgumento arg)
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
                       ParameterName = "@LOGIN_ID",
                       Value =  (arg.Login == string.Empty ?  null : arg.Login)
                   }
                };

            return BaseDeDatosServicio.ExecuteQuery<Sku>
                (BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_MATERIALS_BY_WAREHOUSE_CLIENT_LOCATION_OR_ZONE", CommandType.StoredProcedure, true, parameters).ToList();
        }

        public IList<Material> ObtenerMaterialesPorBodegaYZona(InventarioInactivoArgumento arg)
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
                },
                new OAParameter
                {
                    ParameterName = "@ZONE_XML",
                    Value =  arg.ZoneXml
                }
            };

            return BaseDeDatosServicio.ExecuteQuery<Material>
                (BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_MATERIALS_BY_WAREHOUSE_AND_ZONE", CommandType.StoredProcedure, true, parameters).ToList();
        }
    }
}
