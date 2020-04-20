using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Utilerias;
using MobilityScm.Vertical.Entidades;
using Telerik.OpenAccess.Data.Common;

namespace MobilityScm.Modelo.Servicios
{
    public class ProyectoServicio : IProyectoServicio
    {
        public IBaseDeDatosServicio BaseDeDatosServicio { get; set; }

        public ProyectoServicio(IBaseDeDatosServicio baseDeDatosServicio)
        {
            BaseDeDatosServicio = baseDeDatosServicio;
        }

        public Operacion GrabarProyecto(ProyectoArgumento arg)
        {
            return (arg.Proyecto.ID == Guid.Empty) ? InsertarProyecto(arg) : ActualizarProyecto(arg);
        }

        public Operacion InsertarProyecto(ProyectoArgumento arg)
        {
            DbParameter[] parameters =
            {
                new OAParameter
                {
                    ParameterName = "@OPPORTUNITY_CODE",
                    Value = arg.Proyecto.OPPORTUNITY_CODE
                }, new OAParameter
                {
                    ParameterName = "@OPPORTUNITY_NAME",
                    Value = arg.Proyecto.OPPORTUNITY_NAME
                }, new OAParameter
                {
                    ParameterName = "@SHORT_NAME",
                    Value = arg.Proyecto.SHORT_NAME
                }, new OAParameter
                {
                    ParameterName = "@OBSERVATIONS",
                    Value = arg.Proyecto.OBSERVATIONS
                }, new OAParameter
                {
                    ParameterName = "@CUSTOMER_CODE",
                    Value = arg.Proyecto.CUSTOMER_CODE
                }, new OAParameter
                {
                    ParameterName = "@CUSTOMER_NAME",
                    Value = arg.Proyecto.CUSTOMER_NAME
                }, new OAParameter
                {
                    ParameterName = "@CUSTOMER_OWNER",
                    Value = arg.Proyecto.CUSTOMER_OWNER
                },new OAParameter
                {
                    ParameterName = "@STATUS",
                    Value = arg.Proyecto.STATUS
                },new OAParameter
                {
                    ParameterName = "@LOGIN_ID",
                    Value = arg.Login
                }
            };

            return BaseDeDatosServicio.ExecuteQuery<Operacion>($"{BaseDeDatosServicio.Esquema}.OP_WMS_SP_INSERT_PROJECT", CommandType.StoredProcedure, parameters)[0];
        }

        public Operacion ActualizarProyecto(ProyectoArgumento arg)
        {
            DbParameter[] parameters =
            {
                new OAParameter
                {
                    ParameterName = "@ID",
                    Value = arg.Proyecto.ID
                },new OAParameter
                {
                    ParameterName = "@OPPORTUNITY_CODE",
                    Value = arg.Proyecto.OPPORTUNITY_CODE
                }, new OAParameter
                {
                    ParameterName = "@OPPORTUNITY_NAME",
                    Value = arg.Proyecto.OPPORTUNITY_NAME
                }, new OAParameter
                {
                    ParameterName = "@SHORT_NAME",
                    Value = arg.Proyecto.SHORT_NAME
                }, new OAParameter
                {
                    ParameterName = "@OBSERVATIONS",
                    Value = arg.Proyecto.OBSERVATIONS
                }, new OAParameter
                {
                    ParameterName = "@CUSTOMER_CODE",
                    Value = arg.Proyecto.CUSTOMER_CODE
                }, new OAParameter
                {
                    ParameterName = "@CUSTOMER_NAME",
                    Value = arg.Proyecto.CUSTOMER_NAME
                }, new OAParameter
                {
                    ParameterName = "@CUSTOMER_OWNER",
                    Value = arg.Proyecto.CUSTOMER_OWNER
                },new OAParameter
                {
                    ParameterName = "@STATUS",
                    Value = arg.Proyecto.STATUS
                },new OAParameter
                {
                    ParameterName = "@LOGIN_ID",
                    Value = arg.Login
                }
            };

            return BaseDeDatosServicio.ExecuteQuery<Operacion>($"{BaseDeDatosServicio.Esquema}.OP_WMS_SP_UPDATE_PROJECT", CommandType.StoredProcedure, parameters)[0];
        }

        public Operacion EliminarProyecto(ProyectoArgumento arg)
        {
            DbParameter[] parameters =
            {
                new OAParameter
                {
                    ParameterName = "@ID",
                    Value = arg.Proyecto.ID
                },new OAParameter
                {
                    ParameterName = "@LOGIN",
                    Value = arg.Login
                }
            };
            return BaseDeDatosServicio.ExecuteQuery<Operacion>($"{BaseDeDatosServicio.Esquema}.OP_WMS_SP_DELETE_PROJECT", CommandType.StoredProcedure, parameters)[0];
        }

        public IList<Proyecto> ObtenerProyectosPorEstado(ProyectoArgumento arg)
        {
            DbParameter[] parameters =
            {
                new OAParameter
                {
                    ParameterName = "@STATUS",
                    Value = arg.Proyecto.STATUS
                }
            };
            return BaseDeDatosServicio.ExecuteQuery<Proyecto>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_PROJECT_BY_STATUS", CommandType.StoredProcedure, parameters).ToList();
        }

        public Operacion AsignarInventarioAProyecto(ProyectoArgumento arg)
        {
            DbParameter[] parameters =
            {
                new OAParameter
                {
                    ParameterName = "@XML",
                    Value = arg.LicenciasXml
                },
                new OAParameter
                {
                    ParameterName = "@LOGIN",
                    Value = arg.Login
                }
            };
            return BaseDeDatosServicio.ExecuteQuery<Operacion>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_INSERT_INVENTORY_RESERVED_BY_XML", CommandType.StoredProcedure, false, parameters)[0];
        }

        public Operacion EliminarInventarioDeProyecto(ProyectoArgumento arg)
        {
            DbParameter[] parameters =
            {
                new OAParameter
                {
                    ParameterName = "@XML",
                    Value = arg.LicenciasXml
                },
                new OAParameter
                {
                    ParameterName = "@LOGIN",
                    Value = arg.Login
                },
                new OAParameter
                {
                    ParameterName = "@PROJECT_ID",
                    Value = arg.Proyecto.ID
                }
            };
            return BaseDeDatosServicio.ExecuteQuery<Operacion>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_DELETE_INVENTORY_RESERVED_BY_XML", CommandType.StoredProcedure, false, parameters)[0];
        }

        public IList<Material> ObtenerMaterialesParaFiltrarPorOwner(ProyectoArgumento arg)
        {
            return BaseDeDatosServicio.ExecuteQuery<Material>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_MATERIALS", CommandType.StoredProcedure).ToList();
        }

        public IList<InventarioReservadoProyecto> ObtenerInventarioDisponible(ProyectoArgumento arg)
        {
            DbParameter[] parameters =
            {
                new OAParameter
                {
                    ParameterName = "@MATERIAL_XML",
                    Value = arg.MaterialXml
                },
                new OAParameter
                {
                    ParameterName = "@LOGIN_ID",
                    Value = arg.Login
                },
                new OAParameter
                {
                    ParameterName = "@PROJECT_ID",
                    Value = arg.Proyecto.ID
                }
            };
            return BaseDeDatosServicio.ExecuteQuery<InventarioReservadoProyecto>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_INVENTORY_AVAILABLE_TO_ASSIGN_PROJECT", CommandType.StoredProcedure, parameters).ToList();
        }

        public IList<InventarioReservadoProyecto> ObtenerInventarioAsignadoAProyecto(ProyectoArgumento arg)
        {
            DbParameter[] parameters =
            {
                new OAParameter
                {
                    ParameterName = "@PROJECT_ID",
                    Value = arg.Proyecto.ID
                }
            };
            return BaseDeDatosServicio.ExecuteQuery<InventarioReservadoProyecto>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_INVENTORY_ASSIGNED_TO_PROJECT", CommandType.StoredProcedure, parameters).ToList();
        }
    }
}
