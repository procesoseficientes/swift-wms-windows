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
    public class PilotoServicio : IPilotoServicio
    {

        public IBaseDeDatosServicio BaseDeDatosServicio { get; set; }

        public PilotoServicio(IBaseDeDatosServicio baseDeDatosServicio)
        {
            BaseDeDatosServicio = baseDeDatosServicio;
        }

        public Operacion CrearPiloto(PilotoArgumento pilotoArgumento)
        {
            try
            {
                DbParameter[] parameters =
                {
                    new OAParameter
                    {
                        ParameterName = "@NAME",
                        Value = pilotoArgumento.Piloto.NAME
                    },
                    new OAParameter
                    {
                        ParameterName = "@LAST_NAME",
                        Value = pilotoArgumento.Piloto.LAST_NAME
                    },
                    new OAParameter
                    {
                        ParameterName = "@IDENTIFICATION_DOCUMENT_NUMBER",
                        Value = pilotoArgumento.Piloto.IDENTIFICATION_DOCUMENT_NUMBER
                    },
                    new OAParameter
                    {
                        ParameterName = "@LICENSE_NUMBER",
                        Value = pilotoArgumento.Piloto.LICENSE_NUMBER
                    },
                    new OAParameter
                    {
                        ParameterName = "@LICESE_TYPE",
                        Value = pilotoArgumento.Piloto.LICESE_TYPE
                    },
                    new OAParameter
                    {
                        ParameterName = "@LICENSE_EXPIRATION_DATE",
                        Value = pilotoArgumento.Piloto.LICENSE_EXPIRATION_DATE
                    },
                    new OAParameter
                    {
                        ParameterName = "@ADDRESS",
                        Value = pilotoArgumento.Piloto.ADDRESS
                    },
                    new OAParameter
                    {
                        ParameterName = "@TELEPHONE",
                        Value = pilotoArgumento.Piloto.TELEPHONE
                    },
                    new OAParameter
                    {
                        ParameterName = "@MAIL",
                        Value = pilotoArgumento.Piloto.MAIL
                    },
                    new OAParameter
                    {
                        ParameterName = "@COMMENT",
                        Value = pilotoArgumento.Piloto.COMMENT
                    },
                    new OAParameter
                    {
                        ParameterName = "@LAST_UPDATE_BY",
                        Value = pilotoArgumento.Piloto.LAST_UPDATE_BY
                    }
                };

                var op =
                    BaseDeDatosServicio.ExecuteQuery<Operacion>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_ADD_PILOT",
                        CommandType.StoredProcedure, false, parameters)[0];

                if (op.Resultado == ResultadoOperacionTipo.Exito)
                {
                    BaseDeDatosServicio.Commit();
                }
                else
                {
                    BaseDeDatosServicio.Rollback();
                }
                return op;
            }
            catch (DbException e)
            {
                BaseDeDatosServicio.Rollback();
                return new Operacion
                {
                    Codigo = e.ErrorCode,
                    Mensaje = e.Message,
                    Resultado = ResultadoOperacionTipo.Error
                };
            }
            catch (Exception ex)
            {
                BaseDeDatosServicio.Rollback();
                return new Operacion
                {
                    Codigo = -1,
                    Mensaje = ex.Message,
                    Resultado = ResultadoOperacionTipo.Error
                };
            }
        }

        public Operacion ActualizarPiloto(PilotoArgumento pilotoArgumento)
        {
            try
            {
                DbParameter[] parameters =
                {
                    new OAParameter
                    {
                        ParameterName = "@PILOT_CODE",
                        Value = pilotoArgumento.Piloto.PILOT_CODE
                    },
                    new OAParameter
                    {
                        ParameterName = "@NAME",
                        Value = pilotoArgumento.Piloto.NAME
                    },
                    new OAParameter
                    {
                        ParameterName = "@LAST_NAME",
                        Value = pilotoArgumento.Piloto.LAST_NAME
                    },
                    new OAParameter
                    {
                        ParameterName = "@IDENTIFICATION_DOCUMENT_NUMBER",
                        Value = pilotoArgumento.Piloto.IDENTIFICATION_DOCUMENT_NUMBER
                    },
                    new OAParameter
                    {
                        ParameterName = "@LICENSE_NUMBER",
                        Value = pilotoArgumento.Piloto.LICENSE_NUMBER
                    },
                    new OAParameter
                    {
                        ParameterName = "@LICESE_TYPE",
                        Value = pilotoArgumento.Piloto.LICESE_TYPE
                    },
                    new OAParameter
                    {
                        ParameterName = "@LICENSE_EXPIRATION_DATE",
                        Value = pilotoArgumento.Piloto.LICENSE_EXPIRATION_DATE
                    },
                    new OAParameter
                    {
                        ParameterName = "@ADDRESS",
                        Value = pilotoArgumento.Piloto.ADDRESS
                    },
                    new OAParameter
                    {
                        ParameterName = "@TELEPHONE",
                        Value = pilotoArgumento.Piloto.TELEPHONE
                    },
                    new OAParameter
                    {
                        ParameterName = "@MAIL",
                        Value = pilotoArgumento.Piloto.MAIL
                    },
                    new OAParameter
                    {
                        ParameterName = "@COMMENT",
                        Value = pilotoArgumento.Piloto.COMMENT
                    },
                    new OAParameter
                    {
                        ParameterName = "@LAST_UPDATE_BY",
                        Value = pilotoArgumento.Piloto.LAST_UPDATE_BY
                    }
                };

                var op =
                    BaseDeDatosServicio.ExecuteQuery<Operacion>(
                        BaseDeDatosServicio.Esquema + ".OP_WMS_SP_UPDATE_PILOT", CommandType.StoredProcedure, false,
                        parameters)[0];

                if (op.Resultado == ResultadoOperacionTipo.Exito)
                {
                    BaseDeDatosServicio.Commit();
                }
                else
                {
                    BaseDeDatosServicio.Rollback();
                }
                return op;
            }
            catch (DbException e)
            {
                BaseDeDatosServicio.Rollback();
                return new Operacion
                {
                    Codigo = e.ErrorCode,
                    Mensaje = e.Message,
                    Resultado = ResultadoOperacionTipo.Error
                };
            }
            catch (Exception ex)
            {
                BaseDeDatosServicio.Rollback();
                return new Operacion
                {
                    Codigo = -1,
                    Mensaje = ex.Message,
                    Resultado = ResultadoOperacionTipo.Error
                };
            }
        }

        public Operacion EliminarPiloto(PilotoArgumento pilotoArgumento)
        {
            try
            {
                DbParameter[] parameters =
                {
                    new OAParameter
                    {
                        ParameterName = "@PILOT_CODE",
                        Value = pilotoArgumento.Piloto.PILOT_CODE
                    }
                };

                var op =
                    BaseDeDatosServicio.ExecuteQuery<Operacion>(
                        BaseDeDatosServicio.Esquema + ".OP_WMS_SP_DELETE_PILOT", CommandType.StoredProcedure, false,
                        parameters)[0];
                if (op.Resultado == ResultadoOperacionTipo.Exito)
                {
                    BaseDeDatosServicio.Commit();
                }
                else
                {
                    BaseDeDatosServicio.Rollback();
                }
                return op;
            }
            catch (DbException e)
            {
                BaseDeDatosServicio.Rollback();
                return new Operacion
                {
                    Codigo = e.ErrorCode,
                    Mensaje = e.Message,
                    Resultado = ResultadoOperacionTipo.Error
                };
            }
            catch (Exception ex)
            {
                BaseDeDatosServicio.Rollback();
                return new Operacion
                {
                    Codigo = -1,
                    Mensaje = ex.Message,
                    Resultado = ResultadoOperacionTipo.Error
                };
            }
        }

        public Operacion AsociarPilotoAUsuarioDelSistema(PilotoArgumento pilotoArgumento)
        {
            try
            {
                DbParameter[] parameters =
                {
                    new OAParameter
                    {
                        ParameterName = "@PILOT_CODE",
                        Value = pilotoArgumento.UsuarioPorPiloto.PILOT_CODE
                    },
                    new OAParameter
                    {
                        ParameterName = "@USER_CODE",
                        Value = pilotoArgumento.UsuarioPorPiloto.USER_CODE
                    },
                    new OAParameter
                    {
                        ParameterName = "@LAST_UPDATE_BY",
                        Value = DateTime.Now
                    }
                };

                var op = BaseDeDatosServicio.ExecuteQuery<Operacion>(
                        BaseDeDatosServicio.Esquema + ".OP_WMS_ASSOCIATE_USER_TO_PILOT", CommandType.StoredProcedure,
                        false, parameters)[0];

                if (op.Resultado == ResultadoOperacionTipo.Exito)
                {
                    BaseDeDatosServicio.Commit();
                }
                else
                {
                    BaseDeDatosServicio.Rollback();
                }
                return op;
            }
            catch (DbException e)
            {
                BaseDeDatosServicio.Rollback();
                return new Operacion
                {
                    Codigo = e.ErrorCode,
                    Mensaje = e.Message,
                    Resultado = ResultadoOperacionTipo.Error
                };
            }
            catch (Exception ex)
            {
                BaseDeDatosServicio.Rollback();
                return new Operacion
                {
                    Codigo = -1,
                    Mensaje = ex.Message,
                    Resultado = ResultadoOperacionTipo.Error
                };
            }
        }

        public Operacion DesasociarPilotoDeUsuarioDelSistema(PilotoArgumento pilotoArgumento)
        {
            try
            {
                DbParameter[] parameters =
                {
                    new OAParameter
                    {
                        ParameterName = "@PILOT_CODE",
                        Value = pilotoArgumento.UsuarioPorPiloto.PILOT_CODE
                    }
                };

                var op =
                    BaseDeDatosServicio.ExecuteQuery<Operacion>(
                        BaseDeDatosServicio.Esquema + ".OP_WMS_DISSASOCIATE_USER_FROM_PILOT",
                        CommandType.StoredProcedure, false, parameters)[0];

                if (op.Resultado == ResultadoOperacionTipo.Exito)
                {
                    BaseDeDatosServicio.Commit();
                }
                else
                {
                    BaseDeDatosServicio.Rollback();
                }
                return op;

            }
            catch (DbException e)
            {
                BaseDeDatosServicio.Rollback();
                return new Operacion
                {
                    Codigo = e.ErrorCode,
                    Mensaje = e.Message,
                    Resultado = ResultadoOperacionTipo.Error
                };
            }
            catch (Exception ex)
            {
                BaseDeDatosServicio.Rollback();
                return new Operacion
                {
                    Codigo = -1,
                    Mensaje = ex.Message,
                    Resultado = ResultadoOperacionTipo.Error
                };
            }
        }

        public IList<Piloto> ObtenerPilotos(PilotoArgumento pilotoArgumento)
        {
            DbParameter[] parameters =
            {
                new OAParameter
                {
                    ParameterName = "@PILOT_CODE",
                    Value = pilotoArgumento.Piloto.PILOT_CODE
                }
            };
            return
                BaseDeDatosServicio.ExecuteQuery<Piloto>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_PILOT",
                    CommandType.StoredProcedure, parameters).ToList();
        }

        public IList<UsuarioPorPiloto> ObteneUsuarioPorPilotos()
        {

            return
                BaseDeDatosServicio.ExecuteQuery<UsuarioPorPiloto>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_USER_ASSOCIATED_TO_PILOT",
                    CommandType.StoredProcedure, null).ToList();
        }

        public IList<Piloto> ObtenerPilotosNoAsociadosAVehiculos(PilotoArgumento pilotoArgumento)
        {
            DbParameter[] parameters =
           {
                new OAParameter
                {
                    ParameterName = "@PILOT_CODE",
                    Value = pilotoArgumento.Piloto.PILOT_CODE
                }
            };
            return
                BaseDeDatosServicio.ExecuteQuery<Piloto>(BaseDeDatosServicio.Esquema + ".OP_WMS_GET_PILOT_UNASSOCIATED_TO_VEHICLE",
                    CommandType.StoredProcedure, parameters).ToList();
        }

        public Piloto ObtenerPilotoPorVehiculo(PilotoArgumento pilotoArgumento)
        {
            DbParameter[] parameters =
           {
                new OAParameter
                {
                    ParameterName = "@VEHICLE_CODE",
                    Value = pilotoArgumento.Piloto.VEHICLE_CODE
                }
            };
            return
                BaseDeDatosServicio.ExecuteQuery<Piloto>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_DRIVER_BY_VEHICLE",
                    CommandType.StoredProcedure, parameters)[0];
        }

    }
}