using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Utilerias;
using MobilityScm.Vertical.Entidades;
using Telerik.OpenAccess.Data.Common;

namespace MobilityScm.Modelo.Servicios
{
    public class PosicionamientoServicio : IPosicionamientoServicio
    {
        #region Base de datos
        public IBaseDeDatosServicio BaseDeDatosServicio { get; set; }

        public PosicionamientoServicio(IBaseDeDatosServicio baseDeDatosServicio)
        {
            BaseDeDatosServicio = baseDeDatosServicio;
        }

        public IList<ZonaDePosicionamiento> ObtenerZonaDePosicionamientos(PosicionamientoArgumento arg)
        {
            DbParameter[] parametros =
            {
                new OAParameter
                {
                    ParameterName = "@LOGIN",
                    Value = arg.Login
                },
                new OAParameter
                {
                    ParameterName = "@WAREHOUSE_XML",
                    Value = arg.XmlBodegas
                }
            };
            return BaseDeDatosServicio.ExecuteQuery<ZonaDePosicionamiento>($"{BaseDeDatosServicio.Esquema}.[OP_WMS_GET_SLOTTING]", CommandType.StoredProcedure, parametros).ToList();
        }

        public IList<ZonaDePosicionamiento> ObtenerZonaDePosicionamientosSubClase(PosicionamientoArgumento arg)
        {
            DbParameter[] parametros =
            {
                new OAParameter
                {
                    ParameterName = "@LOGIN",
                    Value = arg.Login
                },
                new OAParameter
                {
                    ParameterName = "@WAREHOUSE_XML",
                    Value = arg.XmlBodegas
                }
            };
            return BaseDeDatosServicio.ExecuteQuery<ZonaDePosicionamiento>($"{BaseDeDatosServicio.Esquema}.[OP_WMS_GET_SLOTTING_SUB_CLASS]", CommandType.StoredProcedure, parametros).ToList();
        }


        public Operacion GrabarZonaDePosicionamiento(PosicionamientoArgumento arg)
        {
            return arg.ZonaDePosicionamiento.ID == Guid.Empty
                ? InsertarZonaDePosicionamiento(arg)
                : ActualizarZonaDePosicionamiento(arg);
        }

        private Operacion InsertarZonaDePosicionamiento(PosicionamientoArgumento arg)
        {
            DbParameter[] parameters =
            {
                new OAParameter
                {
                    ParameterName = "@WAREHOUSE_CODE",
                    Value = arg.ZonaDePosicionamiento.WAREHOUSE_CODE
                },
                new OAParameter
                {
                    ParameterName = "@ZONE_ID",
                    Value = arg.ZonaDePosicionamiento.ZONE_ID
                },
                new OAParameter
                {
                    ParameterName = "@ZONE ",
                    Value = arg.ZonaDePosicionamiento.ZONE
                },
                new OAParameter
                {
                    ParameterName = "@MANDATORY",
                    Value = arg.ZonaDePosicionamiento.MANDATORY
                }

            };
            return BaseDeDatosServicio.ExecuteQuery<Operacion>($"{BaseDeDatosServicio.Esquema}.[OP_WMS_SP_INSERT_SLOTTING_ZONE]", CommandType.StoredProcedure, parameters)[0];
        }

        private Operacion ActualizarZonaDePosicionamiento(PosicionamientoArgumento arg)
        {
            DbParameter[] parameters =
            {
                new OAParameter
                {
                    ParameterName = "@ID_SLOTTING_ZONE",
                    Value = arg.ZonaDePosicionamiento.ID
                },
                new OAParameter
                {
                    ParameterName = "@MANDATORY",
                    Value = arg.ZonaDePosicionamiento.MANDATORY
                }
            };
            return BaseDeDatosServicio.ExecuteQuery<Operacion>($"{BaseDeDatosServicio.Esquema}.[OP_WMS_SP_UPDATE_SLOTTING_ZONE]", CommandType.StoredProcedure, parameters)[0];
        }

        public Operacion AgregarClasesParaZonaDePosicionamiento(PosicionamientoArgumento arg)
        {
            DbParameter[] parameters =
            {
                new OAParameter
                {
                    ParameterName = "@WAREHOUSE_CODE",
                    Value = arg.ZonaDePosicionamiento.WAREHOUSE_CODE
                },
                new OAParameter
                {
                    ParameterName = "@ZONE_ID",
                    Value = arg.ZonaDePosicionamiento.ZONE_ID
                },
                new OAParameter
                {
                    ParameterName = "@ZONE",
                    Value = arg.ZonaDePosicionamiento.ZONE
                },
                new OAParameter
                {
                    ParameterName = "@MANDATORY",
                    Value = arg.ZonaDePosicionamiento.MANDATORY
                },
                new OAParameter
                {
                    ParameterName = "@XML",
                    Value = arg.XmlClases
                }
            };
            return BaseDeDatosServicio.ExecuteQuery<Operacion>($"{BaseDeDatosServicio.Esquema}.[OP_WMS_SP_INSERT_SLOTTING_ZONE_BY_CLASS]", CommandType.StoredProcedure, parameters)[0];
        }

        public Operacion AgregarSubClasesParaZonaDePosicionamiento(PosicionamientoArgumento arg)
        {
            DbParameter[] parameters =
            {
                new OAParameter
                {
                    ParameterName = "@WAREHOUSE_CODE",
                    Value = arg.ZonaDePosicionamiento.WAREHOUSE_CODE
                },
                new OAParameter
                {
                    ParameterName = "@ZONE_ID",
                    Value = arg.ZonaDePosicionamiento.ZONE_ID
                },
                new OAParameter
                {
                    ParameterName = "@ZONE",
                    Value = arg.ZonaDePosicionamiento.ZONE
                },
                new OAParameter
                {
                    ParameterName = "@MANDATORY",
                    Value = arg.ZonaDePosicionamiento.MANDATORY
                },
                new OAParameter
                {
                    ParameterName = "@XML",
                    Value = arg.XmlClases
                }
            };
            return BaseDeDatosServicio.ExecuteQuery<Operacion>($"{BaseDeDatosServicio.Esquema}.[OP_WMS_SP_INSERT_SLOTTING_ZONE_BY_SUB_CLASS]", CommandType.StoredProcedure, parameters)[0];
        }

        public Operacion QuitarClasesParaZonaDePosicionamiento(PosicionamientoArgumento arg)
        {
            DbParameter[] parameters =
            {
                new OAParameter
                {
                    ParameterName = "@ID_SLOTTING_ZONE",
                    Value = arg.ZonaDePosicionamiento.ID
                },
                new OAParameter
                {
                    ParameterName = "@XML",
                    Value = arg.XmlClases
                }
            };
            return BaseDeDatosServicio.ExecuteQuery<Operacion>($"{BaseDeDatosServicio.Esquema}.[OP_WMS_SP_DELETE_SLOTTING_ZONE_BY_CLASS]", CommandType.StoredProcedure, parameters)[0];
        }

        public Operacion QuitarSubClasesParaZonaDePosicionamiento(PosicionamientoArgumento arg)
        {
            DbParameter[] parameters =
            {
                new OAParameter
                {
                    ParameterName = "@ID_SLOTTING_ZONE",
                    Value = arg.ZonaDePosicionamiento.ID
                },
                new OAParameter
                {
                    ParameterName = "@XML",
                    Value = arg.XmlClases
                }
            };
            return BaseDeDatosServicio.ExecuteQuery<Operacion>($"{BaseDeDatosServicio.Esquema}.[OP_WMS_SP_DELETE_SLOTTING_ZONE_BY_SUB_CLASS]", CommandType.StoredProcedure, parameters)[0];
        }

        public IList<Operacion> ProcessarXmlObtenidoExcel(PosicionamientoArgumento arg)
        {
            DbParameter[] parameters =
            {
                new OAParameter
                {
                    ParameterName = "@XML",
                    Value = arg.XmlZonaPosicionamiento
                }
            };
            return BaseDeDatosServicio.ExecuteQuery<Operacion>($"{BaseDeDatosServicio.Esquema}.[OP_WMS_SP_INSERT_SLOTTING_ZONE_BY_XML]", CommandType.StoredProcedure, parameters);
        }
        #endregion
    }
}
