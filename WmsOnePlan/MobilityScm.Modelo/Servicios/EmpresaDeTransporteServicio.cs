using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Modelo.Tipos;
using MobilityScm.Utilerias;
using MobilityScm.Vertical.Entidades;
using Telerik.OpenAccess.Data.Common;

namespace MobilityScm.Modelo.Servicios
{
    public class EmpresaDeTransporteServicio: IEmpresaDeTransporteServicio
    {

        public IBaseDeDatosServicio BaseDeDatosServicio { get; set; }

        public EmpresaDeTransporteServicio(IBaseDeDatosServicio baseDeDatosServicio)
        {
            BaseDeDatosServicio = baseDeDatosServicio;
        }

        public Operacion CrearEmpresaDeTransporte(EmpresaDeTransporteArgumento empresaDeTransporteArgumento)
        {
            try
            {
                DbParameter[] parameters =
                {
                    new OAParameter
                    {
                        ParameterName = "@NAME",
                        Value = empresaDeTransporteArgumento.EmpresaDeTransporte.NAME
                    },
                    new OAParameter
                    {
                        ParameterName = "@ADDRESS",
                        Value = empresaDeTransporteArgumento.EmpresaDeTransporte.ADDRESS
                    },
                    new OAParameter
                    {
                        ParameterName = "@TELEPHONE",
                        Value = empresaDeTransporteArgumento.EmpresaDeTransporte.TELEPHONE
                    },
                    new OAParameter
                    {
                        ParameterName = "@CONTACT",
                        Value = empresaDeTransporteArgumento.EmpresaDeTransporte.CONTACT
                    },
                    new OAParameter
                    {
                        ParameterName = "@MAIL",
                        Value = empresaDeTransporteArgumento.EmpresaDeTransporte.MAIL
                    }
                    ,
                    new OAParameter
                    {
                        ParameterName = "@LAST_UPDATE_BY",
                        Value = empresaDeTransporteArgumento.EmpresaDeTransporte.LAST_UPDATE_BY
                    }
                    ,
                    new OAParameter
                    {
                        ParameterName = "@IS_OWN",
                        Value = empresaDeTransporteArgumento.EmpresaDeTransporte.IS_OWN
                    }
                };

                return BaseDeDatosServicio.ExecuteQuery<Operacion>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_ADD_TRANSPORT_COMPANY", CommandType.StoredProcedure,false, parameters)[0];
            }
            catch (DbException e)
            {
                return new Operacion
                {
                    Codigo = e.ErrorCode,
                    Mensaje = e.Message,
                    Resultado = ResultadoOperacionTipo.Error
                };
            }
            catch (Exception ex)
            {
                return new Operacion
                {
                    Codigo = -1,
                    Mensaje = ex.Message,
                    Resultado = ResultadoOperacionTipo.Error
                };
            }
        }

        public Operacion ActualizarEmpresaDeTransporte(EmpresaDeTransporteArgumento empresaDeTransporteArgumento)
        {
            try
            {
                DbParameter[] parameters =
                {
                    new OAParameter
                    {
                        ParameterName = "@TRANSPORT_COMPANY_CODE",
                        Value = empresaDeTransporteArgumento.EmpresaDeTransporte.TRANSPORT_COMPANY_CODE
                    }, new OAParameter
                    {
                        ParameterName = "@NAME",
                        Value = empresaDeTransporteArgumento.EmpresaDeTransporte.NAME
                    },
                    new OAParameter
                    {
                        ParameterName = "@ADDRESS",
                        Value = empresaDeTransporteArgumento.EmpresaDeTransporte.ADDRESS
                    },
                    new OAParameter
                    {
                        ParameterName = "@TELEPHONE",
                        Value = empresaDeTransporteArgumento.EmpresaDeTransporte.TELEPHONE
                    },
                    new OAParameter
                    {
                        ParameterName = "@CONTACT",
                        Value = empresaDeTransporteArgumento.EmpresaDeTransporte.CONTACT
                    },
                    new OAParameter
                    {
                        ParameterName = "@MAIL",
                        Value = empresaDeTransporteArgumento.EmpresaDeTransporte.MAIL
                    }
                    ,
                    new OAParameter
                    {
                        ParameterName = "@LAST_UPDATE_BY",
                        Value = empresaDeTransporteArgumento.EmpresaDeTransporte.LAST_UPDATE_BY
                    }
                    ,
                    new OAParameter
                    {
                        ParameterName = "@IS_OWN",
                        Value = empresaDeTransporteArgumento.EmpresaDeTransporte.IS_OWN
                    }
                };

                return BaseDeDatosServicio.ExecuteQuery<Operacion>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_UPDATE_TRANSPORT_COMPANY", CommandType.StoredProcedure, false, parameters)[0];
            }
            catch (DbException e)
            {
                return new Operacion
                {
                    Codigo = e.ErrorCode,
                    Mensaje = e.Message,
                    Resultado = ResultadoOperacionTipo.Error
                };
            }
            catch (Exception ex)
            {
                return new Operacion
                {
                    Codigo = -1,
                    Mensaje = ex.Message,
                    Resultado = ResultadoOperacionTipo.Error
                };
            }
        }

        public Operacion EliminarEmpresaDeTransporte(EmpresaDeTransporteArgumento empresaDeTransporteArgumento)
        {
            try
            {
                DbParameter[] parameters =
                {
                    new OAParameter
                    {
                        ParameterName = "@TRANSPORT_COMPANY_CODE",
                        Value = empresaDeTransporteArgumento.EmpresaDeTransporte.TRANSPORT_COMPANY_CODE
                    }
                };

                return BaseDeDatosServicio.ExecuteQuery<Operacion>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_DELETE_TRANSPORT_COMPANY", CommandType.StoredProcedure, false, parameters)[0];
            }
            catch (DbException e)
            {
                return new Operacion
                {
                    Codigo = e.ErrorCode,
                    Mensaje = e.Message,
                    Resultado = ResultadoOperacionTipo.Error
                };
            }
            catch (Exception ex)
            {
                return new Operacion
                {
                    Codigo = -1,
                    Mensaje = ex.Message,
                    Resultado = ResultadoOperacionTipo.Error
                };
            }
        }

        public IList<EmpresaDeTransporte> ObtenerEmpresasDeTransporte(EmpresaDeTransporteArgumento empresaDeTransporteArgumento)
        {
            DbParameter[] parameters =
             {
               new OAParameter
               {
                   ParameterName = "@TRANSPORT_COMPANY_CODE",
                   Value =  empresaDeTransporteArgumento.EmpresaDeTransporte.TRANSPORT_COMPANY_CODE
               }
           };
            return BaseDeDatosServicio.ExecuteQuery<EmpresaDeTransporte>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_TRANSPORT_COMPANY", CommandType.StoredProcedure, parameters).ToList();
        }
    }
}