using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Utilerias;
using Telerik.OpenAccess.Data.Common;

namespace MobilityScm.Modelo.Servicios
{
    public class UsuarioServicio : IUsuarioServicio
    {
        public IBaseDeDatosServicio BaseDeDatosServicio { get; set; }

        public UsuarioServicio(IBaseDeDatosServicio baseDeDatosServicio)
        {
            BaseDeDatosServicio = baseDeDatosServicio;
        }

        public IList<Usuario> ObtenerUsuariosTipoBodega()
        {
            return BaseDeDatosServicio.ExecuteQuery<Usuario>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_OPERATORS", CommandType.StoredProcedure, null);
        }

        public IList<Usuario> ObtenerUsuariosTipoBodegaAsignadosCD(string centroDistribucion)
        {
            DbParameter[] parameters = {
                new OAParameter
                {
                    ParameterName = "@DISTRIBUTION_CENTER",
                    Value = centroDistribucion
                }
            };
            return BaseDeDatosServicio.ExecuteQuery<Usuario>
                (BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_OPERATORS_ASSIGNED_TO_DISTRIBUTION_CENTER", CommandType.StoredProcedure, true, parameters).ToList();
        }

        public IList<Usuario> ObtenerUsuariosTipoBodegaAsignadosAlUsuario(string login)
        {
            DbParameter[] parameters = {
                new OAParameter
                {
                    ParameterName = "@LOGIN",
                    Value = login
                }
            };
            return BaseDeDatosServicio.ExecuteQuery<Usuario>
                (BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_OPERATORS_ASSIGNED_TO_DISTRIBUTION_CENTER_BY_USER", CommandType.StoredProcedure, true, parameters).ToList();
        }

        public IList<RolDeUsuario> ObtenerRolesDeUsuario()
        {
            return BaseDeDatosServicio.ExecuteQuery<RolDeUsuario>
                (BaseDeDatosServicio.Esquema + ".OP_WMS_GET_USER_ROLE", CommandType.StoredProcedure, null).ToList();
        }

        public IList<Usuario> ObtenerUsuariosPorRol(RolDeUsuario rolDeUsuario)
        {
            DbParameter[] parameters = {
                new OAParameter
                {
                    ParameterName = "@USER_ROLE",
                    Value = rolDeUsuario.ROLE_ID
                }
                ,
                new OAParameter
                {
                    ParameterName = "@USER_CODE",
                    Value = string.IsNullOrEmpty(rolDeUsuario.USER_CODE) ? null: rolDeUsuario.USER_CODE
                }
            };
            return BaseDeDatosServicio.ExecuteQuery<Usuario>
                (BaseDeDatosServicio.Esquema + ".OP_WMS_GET_USER_BY_ROLE", CommandType.StoredProcedure, parameters)
                .ToList();
        }

        public IList<Usuario> ObtenerUsuariosActivosPorCentroDeDistribucion(string centroDistribucion)
        {
            DbParameter[] parameters = {
                new OAParameter
                {
                    ParameterName = "@DISTRIBUTION_CENTER",
                    Value = centroDistribucion
                }
            };
            return BaseDeDatosServicio.ExecuteQuery<Usuario>(BaseDeDatosServicio.Esquema + ".[OP_WMS_GET_ACTIVE_USER_BY_DISTRIBUTION_CENTER]", CommandType.StoredProcedure, parameters).ToList();
        }

        public IList<Usuario> ObtenerUsuariosSonda()
        {
            return BaseDeDatosServicio.ExecuteQuery<Usuario>
                (BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_USERS_SONDA_SD", CommandType.StoredProcedure, null).ToList();
        }

    }
}
