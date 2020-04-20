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

namespace MobilityScm.Modelo.Servicios
{
    public class CatalogoZonaServicio : ICatalogoZonaServicio
    {
        public IBaseDeDatosServicio BaseDeDatosServicio { get; set; }

        public CatalogoZonaServicio(IBaseDeDatosServicio baseDeDatosServicio)
        {
            BaseDeDatosServicio = baseDeDatosServicio;
        }

        public IList<Zona> ConsultarZonas()
        {
            return BaseDeDatosServicio.ExecuteQuery<Zona>(
                BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_ALL_ZONES",
                CommandType.StoredProcedure).ToList();
        }

        public Operacion AgregarZona(ZonaArgumento arg)
        {
            DbParameter[] parameters =
            {
                new OAParameter
                {
                    ParameterName = "@ZONE",
                    Value = arg.Zona.ZONE
                },
                new OAParameter
                {
                    ParameterName = "@DESCRIPTION",
                    Value = arg.Zona.DESCRIPTION
                },
                new OAParameter
                {
                    ParameterName = "@WAREHOUSE_CODE",
                    Value = arg.Zona.WAREHOUSE_CODE
                },
                new OAParameter
                {
                    ParameterName = "@EXPLODE_MATERIALS_IN_REALLOC",
                    Value = arg.Zona.RECEIVE_EXPLODED_MATERIALS
                },
                new OAParameter
                {
                    ParameterName = "@LINE_ID",
                    Value = arg.Zona.LINE_ID
                }
            };

            return BaseDeDatosServicio.ExecuteQuery<Operacion>(
                BaseDeDatosServicio.Esquema + ".OP_WMS_SP_INSERT_ZONE",
                CommandType.StoredProcedure, parameters).FirstOrDefault();
        }

        public Operacion EliminarZona(ZonaArgumento arg)
        {
            DbParameter[] parameters =
            {
                new OAParameter
                {
                    ParameterName = "@ZONE_ID",
                    Value = arg.Zona.ZONE_ID
                }
            };

            return BaseDeDatosServicio.ExecuteQuery<Operacion>(
                BaseDeDatosServicio.Esquema + ".OP_WMS_SP_DELETE_ZONE",
                CommandType.StoredProcedure, parameters).FirstOrDefault();
        }

        public Operacion ActualizarZona(ZonaArgumento arg)
        {
            DbParameter[] parameters =
            {
                new OAParameter
                {
                    ParameterName = "@ZONE_ID",
                    Value = arg.Zona.ZONE_ID
                },
                new OAParameter
                {
                    ParameterName = "@ZONE",
                    Value = arg.Zona.ZONE
                },
                new OAParameter
                {
                    ParameterName = "@DESCRIPTION",
                    Value = arg.Zona.DESCRIPTION
                },
                new OAParameter
                {
                    ParameterName = "@WAREHOUSE_CODE",
                    Value = arg.Zona.WAREHOUSE_CODE
                },
                new OAParameter
                {
                    ParameterName = "@EXPLODE_MATERIALS_IN_REALLOC",
                    Value = arg.Zona.RECEIVE_EXPLODED_MATERIALS
                },
                new OAParameter
                {
                    ParameterName = "@LINE_ID",
                    Value = arg.Zona.LINE_ID
                }
            };

            return BaseDeDatosServicio.ExecuteQuery<Operacion>(
                BaseDeDatosServicio.Esquema + ".OP_WMS_SP_UPDATE_ZONE",
                CommandType.StoredProcedure, parameters).FirstOrDefault();
        }

        public IList<Zona> ConsultarZonasParaAsociar(ZonaArgumento arg)
        {
            DbParameter[] parameters =
            {
                new OAParameter
                {
                    ParameterName = "@ZONE_ID",
                    Value = arg.Zona.ZONE_ID
                }
            };

            return BaseDeDatosServicio.ExecuteQuery<Zona>(
                BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_ZONES_TO_REPLENISH",
                CommandType.StoredProcedure, parameters).ToList();
        }

        public IList<Zona> ConsultarZonasAsociadas(ZonaArgumento arg)
        {
            DbParameter[] parameters =
            {
                new OAParameter
                {
                    ParameterName = "@ZONE_ID",
                    Value = arg.Zona.ZONE_ID
                }
            };

            return BaseDeDatosServicio.ExecuteQuery<Zona>(
                BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_ZONES_ASOCCIATE_TO_ZONE_FOR_REPLENISH",
                CommandType.StoredProcedure, parameters).ToList();
        }

        public Operacion AsociarZonaDeReabastecimiento(ZonaArgumento arg)
        {
            DbParameter[] parameters =
            {
                new OAParameter
                {
                    ParameterName = "@ZONE_ID",
                    Value = arg.Zona.ZONE_ID
                },
                new OAParameter
                {
                    ParameterName = "@REPLENISH_ZONE_ID",
                    Value = arg.ZonaAsociadaId
                }
            };

            return BaseDeDatosServicio.ExecuteQuery<Operacion>(
                BaseDeDatosServicio.Esquema + ".OP_WMS_SP_ADD_ZONE_TO_REPLENISH_ZONE",
                CommandType.StoredProcedure, parameters).FirstOrDefault();
        }

        public Operacion DesAsociarZonaDeReabastecimiento(ZonaArgumento arg)
        {
            DbParameter[] parameters =
            {
                new OAParameter
                {
                    ParameterName = "@ZONE_ID",
                    Value = arg.Zona.ZONE_ID
                },
                new OAParameter
                {
                    ParameterName = "@REPLENISH_ZONE_ID",
                    Value = arg.ZonaAsociadaId
                }
            };

            return BaseDeDatosServicio.ExecuteQuery<Operacion>(
                BaseDeDatosServicio.Esquema + ".OP_WMS_SP_DELETE_ZONE_RELATION_TO_REPLENISH_ZONE",
                CommandType.StoredProcedure, parameters).FirstOrDefault();
        }
    }
}
