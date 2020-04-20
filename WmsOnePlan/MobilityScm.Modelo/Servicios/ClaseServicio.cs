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
    public class ClaseServicio : IClaseServicio
    {
        #region Base de datos
        public IBaseDeDatosServicio BaseDeDatosServicio { get; set; }

        public ClaseServicio(IBaseDeDatosServicio baseDeDatosServicio)
        {
            BaseDeDatosServicio = baseDeDatosServicio;
        }
        #endregion

        public Clase ObtenerClasePorId(Clase clase)
        {
            DbParameter[] parameters =
           {
                new OAParameter
                {
                    ParameterName = "@CLASS_ID",
                    Value = clase.CLASS_ID
                }
            };
            return BaseDeDatosServicio.ExecuteQuery<Clase>($"{BaseDeDatosServicio.Esquema}.OP_WMS_SP_GET_CLASS", CommandType.StoredProcedure, false, parameters).First();
        }

        public IList<Clase> ObtenerClases()
        {
            return BaseDeDatosServicio.ExecuteQuery<Clase>($"{BaseDeDatosServicio.Esquema}.OP_WMS_SP_GET_CLASSES", CommandType.StoredProcedure, false, null).ToList();
        }

        public IList<Clase> ObtenerClasesAsociadas(Clase clase)
        {
            DbParameter[] parameters =
           {
                new OAParameter
                {
                    ParameterName = "@CLASS_ID",
                    Value = clase.CLASS_ID
                }
            };
            return BaseDeDatosServicio.ExecuteQuery<Clase>($"{BaseDeDatosServicio.Esquema}.OP_WMS_GET_ASSOCIATED_CLASSES", CommandType.StoredProcedure, false, parameters).ToList();
        }

        public IList<Clase> ObtenerClasesNoAsociadas(Clase clase)
        {
            DbParameter[] parameters =
           {
                new OAParameter
                {
                    ParameterName = "@CLASS_ID",
                    Value = clase.CLASS_ID
                }
            };
            return BaseDeDatosServicio.ExecuteQuery<Clase>($"{BaseDeDatosServicio.Esquema}.OP_WMS_GET_NOT_ASSOCIATED_CLASSES", CommandType.StoredProcedure, false, parameters).ToList();
        }

        public Operacion CrearClase(Clase clase)
        {
            DbParameter[] parameters =
            {
                new OAParameter
                {
                    ParameterName = "@CLASS_NAME",
                    Value = clase.CLASS_NAME
                }, new OAParameter
                {
                    ParameterName = "@CLASS_DESCRIPTION",
                    Value = clase.CLASS_DESCRIPTION
                }, new OAParameter
                {
                    ParameterName = "@CLASS_TYPE",
                    Value = clase.CLASS_TYPE
                }, new OAParameter
                {
                    ParameterName = "@CREATED_BY",
                    Value = clase.CREATED_BY
                }, new OAParameter
                {
                    ParameterName = "@PRIORITY",
                    Value = clase.PRIORITY
                }
            };
            var operacion = BaseDeDatosServicio.ExecuteQuery<Operacion>($"{BaseDeDatosServicio.Esquema}.OP_WMS_SP_CREATE_CLASS", CommandType.StoredProcedure, false, parameters)[0];
            if (operacion.Resultado != ResultadoOperacionTipo.Error) BaseDeDatosServicio.Commit();
            else BaseDeDatosServicio.Rollback();
            return operacion;
        }

        public Operacion ActualizarClase(Clase clase)
        {
            DbParameter[] parameters =
            {
                new OAParameter
                {
                    ParameterName = "@CLASS_ID",
                    Value = clase.CLASS_ID
                },new OAParameter
                {
                    ParameterName = "@CLASS_NAME",
                    Value = clase.CLASS_NAME
                }, new OAParameter
                {
                    ParameterName = "@CLASS_DESCRIPTION",
                    Value = clase.CLASS_DESCRIPTION
                }, new OAParameter
                {
                    ParameterName = "@CLASS_TYPE",
                    Value = clase.CLASS_TYPE
                }, new OAParameter
                {
                    ParameterName = "@LOGIN",
                    Value = clase.LAST_UPDATED_BY
                }, new OAParameter
                {
                    ParameterName = "@PRIORITY",
                    Value = clase.PRIORITY
                }
            };
            var operacion = BaseDeDatosServicio.ExecuteQuery<Operacion>($"{BaseDeDatosServicio.Esquema}.OP_WMS_SP_UPDATE_CLASS", CommandType.StoredProcedure, false, parameters)[0];
            if (operacion.Resultado != ResultadoOperacionTipo.Error) BaseDeDatosServicio.Commit();
            else BaseDeDatosServicio.Rollback();
            return operacion;
        }

        public Operacion EliminarClase(Clase clase)
        {
            DbParameter[] parameters =
            {
                new OAParameter
                {
                    ParameterName = "@CLASS_ID",
                    Value = clase.CLASS_ID
                }
            };
            var operacion = BaseDeDatosServicio.ExecuteQuery<Operacion>($"{BaseDeDatosServicio.Esquema}.OP_WMS_SP_DELETE_CLASS", CommandType.StoredProcedure, false, parameters)[0];
            if (operacion.Resultado != ResultadoOperacionTipo.Error) BaseDeDatosServicio.Commit();
            else BaseDeDatosServicio.Rollback();
            return operacion;
        }

        public Operacion AsociarClases(ClaseArgumento claseArgumento)
        {
            var operacion = new Operacion();
            foreach (var clase in claseArgumento.Clases)
            {
                DbParameter[] parameters =
                {
                    new OAParameter
                    {
                        ParameterName = "@CLASS_ID",
                        Value = claseArgumento.Clase.CLASS_ID
                    },new OAParameter
                    {
                        ParameterName = "@CLASS_ASSOCIATED_ID",
                        Value = clase.CLASS_ID
                    }
                };
                operacion = BaseDeDatosServicio.ExecuteQuery<Operacion>($"{BaseDeDatosServicio.Esquema}.OP_WMS_SP_ASSOCIATE_CLASS", CommandType.StoredProcedure, false, parameters)[0];
                if (operacion.Resultado == ResultadoOperacionTipo.Error)
                {
                    BaseDeDatosServicio.Rollback();
                    return operacion;
                }
            }
            BaseDeDatosServicio.Commit();
            return operacion;
        }

        public Operacion DesasociarClases(ClaseArgumento claseArgumento)
        {
            var operacion = new Operacion();
            foreach (var clase in claseArgumento.Clases)
            {
                DbParameter[] parameters =
                {
                    new OAParameter
                    {
                        ParameterName = "@CLASS_ID",
                        Value = claseArgumento.Clase.CLASS_ID
                    },new OAParameter
                    {
                        ParameterName = "@CLASS_ASSOCIATED_ID",
                        Value = clase.CLASS_ID
                    }
                };
                operacion = BaseDeDatosServicio.ExecuteQuery<Operacion>($"{BaseDeDatosServicio.Esquema}.OP_WMS_SP_DEASSOCIATE_CLASS", CommandType.StoredProcedure, false, parameters)[0];
                if (operacion.Resultado == ResultadoOperacionTipo.Error)
                {
                    BaseDeDatosServicio.Rollback();
                    return operacion;
                }
            }
            BaseDeDatosServicio.Commit();
            return operacion;
        }

        public Operacion CargarClasesPorXml(ClaseArgumento claseArgumento)
        {

            var serializer = new XmlSerializer(typeof(List<Clase>));
            var stringWriter = new StringWriter();
            var xmlWriter = new XmlTextWriter(stringWriter) { Formatting = Formatting.Indented };
            serializer.Serialize(xmlWriter, claseArgumento.Clases);

            DbParameter[] parameters =
            {
                new OAParameter
                {
                    ParameterName = "@XML",
                    Value =  stringWriter.ToString()
                },new OAParameter
                {
                    ParameterName = "@LOGIN",
                    Value = claseArgumento.Login
                }
            };
            var operacion = BaseDeDatosServicio.ExecuteQuery<Operacion>($"{BaseDeDatosServicio.Esquema}.OP_WMS_SP_LOAD_CLASSES_BY_XML", CommandType.StoredProcedure, false, parameters)[0];
            if (operacion.Resultado != ResultadoOperacionTipo.Error) BaseDeDatosServicio.Commit();
            else BaseDeDatosServicio.Rollback();
            return operacion;
        }

        public IList<Clase> ObtenerClasesAsignadasParaZonasDePosicionamiento(PosicionamientoArgumento arg)
        {
            DbParameter[] parametros =
            {
                new OAParameter
                {
                    ParameterName = "@ID_SLOTTING",
                    Value = arg.ZonaDePosicionamiento.ID
                }
            };
            return BaseDeDatosServicio.ExecuteQuery<Clase>($"{BaseDeDatosServicio.Esquema}.[OP_WMS_SP_GET_CLASS_BY_SLOTTING_ZONE]", CommandType.StoredProcedure, parametros).ToList();
        }

        public IList<Clase> ObtenerSubClasesAsignadasParaZonasDePosicionamiento(PosicionamientoArgumento arg)
        {
            DbParameter[] parametros =
            {
                new OAParameter
                {
                    ParameterName = "@ID_SLOTTING",
                    Value = arg.ZonaDePosicionamiento.ID
                }
            };
            return BaseDeDatosServicio.ExecuteQuery<Clase>($"{BaseDeDatosServicio.Esquema}.[OP_WMS_SP_GET_SUB_CLASS_BY_SLOTTING_ZONE]", CommandType.StoredProcedure, parametros).ToList();
        }

        public IList<Clase> ObtenerClasesDisponbilesParaZonasDePosicionamiento(PosicionamientoArgumento arg)
        {
            DbParameter[] parametros =
            {
                new OAParameter
                {
                    ParameterName = "@ID_SLOTTING",
                    Value = arg.ZonaDePosicionamiento.ID
                }
            };
            return BaseDeDatosServicio.ExecuteQuery<Clase>($"{BaseDeDatosServicio.Esquema}.[OP_WMS_SP_GET_CLASS_NOT_ASSOCIATED_SLOTTING_ZONE]", CommandType.StoredProcedure, parametros).ToList();
        }

        public IList<Clase> ObtenerSubClasesDisponbilesParaZonasDePosicionamiento(PosicionamientoArgumento arg)
        {
            DbParameter[] parametros =
            {
                new OAParameter
                {
                    ParameterName = "@ID_SLOTTING",
                    Value = arg.ZonaDePosicionamiento.ID
                }
            };
            return BaseDeDatosServicio.ExecuteQuery<Clase>($"{BaseDeDatosServicio.Esquema}.[OP_WMS_SP_GET_SUB_CLASS_NOT_ASSOCIATED_SLOTTING_ZONE]", CommandType.StoredProcedure, parametros).ToList();
        }
    }
}