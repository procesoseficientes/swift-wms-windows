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
    public class VehiculoServicio : IVehiculoServicio
    {
        public IBaseDeDatosServicio BaseDeDatosServicio { get; set; }

        public VehiculoServicio(IBaseDeDatosServicio baseDeDatosServicio)
        {
            BaseDeDatosServicio = baseDeDatosServicio;
        }

        public Operacion CrearVehiculo(VehiculoArgumento vehiculoArgumento)
        {
            try
            {
                DbParameter[] parameters =
                {
                    new OAParameter
                    {
                        ParameterName = "@BRAND",
                        Value = vehiculoArgumento.Vehiculo.BRAND
                    },
                    new OAParameter
                    {
                        ParameterName = "@LINE",
                        Value = vehiculoArgumento.Vehiculo.LINE
                    },
                    new OAParameter
                    {
                        ParameterName = "@MODEL",
                        Value = vehiculoArgumento.Vehiculo.MODEL
                    },
                    new OAParameter
                    {
                        ParameterName = "@COLOR",
                        Value = vehiculoArgumento.Vehiculo.COLOR
                    },
                    new OAParameter
                    {
                        ParameterName = "@CHASSIS_NUMBER",
                        Value = vehiculoArgumento.Vehiculo.CHASSIS_NUMBER
                    },
                    new OAParameter
                    {
                        ParameterName = "@ENGINE_NUMBER",
                        Value = vehiculoArgumento.Vehiculo.ENGINE_NUMBER
                    },
                    new OAParameter
                    {
                        ParameterName = "@VIN_NUMBER",
                        Value =vehiculoArgumento.Vehiculo.VIN_NUMBER
                    },
                    new OAParameter
                    {
                        ParameterName = "@PLATE_NUMBER",
                        Value = vehiculoArgumento.Vehiculo.PLATE_NUMBER
                    },
                    new OAParameter
                    {
                        ParameterName = "@TRANSPORT_COMPANY_CODE",
                        Value = vehiculoArgumento.Vehiculo.TRANSPORT_COMPANY_CODE
                    },
                    new OAParameter
                    {
                        ParameterName = "@WEIGHT",
                        Value = vehiculoArgumento.Vehiculo.WEIGHT
                    },
                    new OAParameter
                    {
                        ParameterName = "@HIGH",
                        Value =vehiculoArgumento.Vehiculo.HIGH
                    }
                    ,
                    new OAParameter
                    {
                        ParameterName = "@WIDTH",
                        Value =vehiculoArgumento.Vehiculo.WIDTH
                    }
                    ,
                    new OAParameter
                    {
                        ParameterName = "@DEPTH",
                        Value = vehiculoArgumento.Vehiculo.DEPTH
                    }
                    ,
                    new OAParameter
                    {
                        ParameterName = "@VOLUME_FACTOR",
                        Value = vehiculoArgumento.Vehiculo.VOLUME_FACTOR
                    }
                    ,
                    new OAParameter
                    {
                        ParameterName = "@LAST_UPDATE_BY",
                        Value = vehiculoArgumento.Vehiculo.LAST_UPDATE_BY
                    }
                    ,
                    new OAParameter
                    {
                        ParameterName = "@PILOT_CODE",
                        Value = vehiculoArgumento.Vehiculo.PILOT_CODE
                    }
                    ,
                    new OAParameter
                    {
                        ParameterName = "@RATING",
                        Value =vehiculoArgumento.Vehiculo.RATING
                    }
                    ,
                    new OAParameter
                    {
                        ParameterName = "@IS_ACTIVE",
                        Value =vehiculoArgumento.Vehiculo.IS_ACTIVE
                    }
                    ,
                    new OAParameter
                    {
                        ParameterName = "@STATUS",
                        Value = vehiculoArgumento.Vehiculo.STATUS
                    }
                    ,
                    new OAParameter
                    {
                        ParameterName = "@FILL_RATE",
                        Value = vehiculoArgumento.Vehiculo.FILL_RATE
                    }
                    ,
                    new OAParameter
                    {
                        ParameterName = "@VEHICLE_AXLES",
                        Value = vehiculoArgumento.Vehiculo.VEHICLE_AXLES
                    }
                    ,
                    new OAParameter
                    {
                        ParameterName = "@INSURANCE_DOC_ID",
                        Value = vehiculoArgumento.Vehiculo.INSURANCE_DOC_ID
                    }
                    ,new OAParameter
                    {
                        ParameterName = "@AVERAGE_COST_PER_KILOMETER",
                        Value = vehiculoArgumento.Vehiculo.AVERAGE_COST_PER_KILOMETER
                    }
                };

                var op =
                    BaseDeDatosServicio.ExecuteQuery<Operacion>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_ADD_VEHICLE",
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

        public Operacion ActualizarVehiculo(VehiculoArgumento vehiculoArgumento)
        {
            try
            {
                DbParameter[] parameters =
                {
                      new OAParameter
                    {
                        ParameterName = "@VEHICLE_CODE",
                        Value = vehiculoArgumento.Vehiculo.VEHICLE_CODE
                    },
                    new OAParameter
                    {
                        ParameterName = "@BRAND",
                        Value = vehiculoArgumento.Vehiculo.BRAND
                    },
                    new OAParameter
                    {
                        ParameterName = "@LINE",
                        Value = vehiculoArgumento.Vehiculo.LINE
                    },
                    new OAParameter
                    {
                        ParameterName = "@MODEL",
                        Value = vehiculoArgumento.Vehiculo.MODEL
                    },
                    new OAParameter
                    {
                        ParameterName = "@COLOR",
                        Value = vehiculoArgumento.Vehiculo.COLOR
                    },
                    new OAParameter
                    {
                        ParameterName = "@CHASSIS_NUMBER",
                        Value = vehiculoArgumento.Vehiculo.CHASSIS_NUMBER
                    },
                    new OAParameter
                    {
                        ParameterName = "@ENGINE_NUMBER",
                        Value = vehiculoArgumento.Vehiculo.ENGINE_NUMBER
                    },
                    new OAParameter
                    {
                        ParameterName = "@VIN_NUMBER",
                        Value =vehiculoArgumento.Vehiculo.VIN_NUMBER
                    },
                    new OAParameter
                    {
                        ParameterName = "@PLATE_NUMBER",
                        Value = vehiculoArgumento.Vehiculo.PLATE_NUMBER
                    },
                    new OAParameter
                    {
                        ParameterName = "@TRANSPORT_COMPANY_CODE",
                        Value = vehiculoArgumento.Vehiculo.TRANSPORT_COMPANY_CODE
                    },
                    new OAParameter
                    {
                        ParameterName = "@WEIGHT",
                        Value = vehiculoArgumento.Vehiculo.WEIGHT
                    },
                    new OAParameter
                    {
                        ParameterName = "@HIGH",
                        Value =vehiculoArgumento.Vehiculo.HIGH
                    }
                    ,
                    new OAParameter
                    {
                        ParameterName = "@WIDTH",
                        Value =vehiculoArgumento.Vehiculo.WIDTH
                    }
                    ,
                    new OAParameter
                    {
                        ParameterName = "@DEPTH",
                        Value = vehiculoArgumento.Vehiculo.DEPTH
                    }
                    ,
                    new OAParameter
                    {
                        ParameterName = "@VOLUME_FACTOR",
                        Value = vehiculoArgumento.Vehiculo.VOLUME_FACTOR
                    }
                    ,
                    new OAParameter
                    {
                        ParameterName = "@LAST_UPDATE_BY",
                        Value = vehiculoArgumento.Vehiculo.LAST_UPDATE_BY
                    }
                    ,
                    new OAParameter
                    {
                        ParameterName = "@PILOT_CODE",
                        Value = vehiculoArgumento.Vehiculo.PILOT_CODE
                    }
                    ,
                    new OAParameter
                    {
                        ParameterName = "@RATING",
                        Value =vehiculoArgumento.Vehiculo.RATING
                    }
                    ,
                    new OAParameter
                    {
                        ParameterName = "@IS_ACTIVE",
                        Value =vehiculoArgumento.Vehiculo.IS_ACTIVE
                    }
                    ,
                    new OAParameter
                    {
                        ParameterName = "@STATUS",
                        Value = vehiculoArgumento.Vehiculo.STATUS
                    }
                    ,
                    new OAParameter
                    {
                        ParameterName = "@FILL_RATE",
                        Value = vehiculoArgumento.Vehiculo.FILL_RATE
                    }
                    ,
                    new OAParameter
                    {
                        ParameterName = "@VEHICLE_AXLES",
                        Value = vehiculoArgumento.Vehiculo.VEHICLE_AXLES
                    }
                    ,
                    new OAParameter
                    {
                        ParameterName = "@INSURANCE_DOC_ID",
                        Value = vehiculoArgumento.Vehiculo.INSURANCE_DOC_ID
                    }
                    ,new OAParameter
                    {
                        ParameterName = "@AVERAGE_COST_PER_KILOMETER",
                        Value = vehiculoArgumento.Vehiculo.AVERAGE_COST_PER_KILOMETER
                    }
                };

                var op =
                    BaseDeDatosServicio.ExecuteQuery<Operacion>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_UPDATE_VEHICLE",
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

        public Operacion EliminarVehiculo(VehiculoArgumento vehiculoArgumento)
        {
            try
            {
                DbParameter[] parameters =
                {
                      new OAParameter
                    {
                        ParameterName = "@VEHICLE_CODE",
                        Value = vehiculoArgumento.Vehiculo.VEHICLE_CODE
                    }
                };

                var op =
                    BaseDeDatosServicio.ExecuteQuery<Operacion>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_DELETE_VEHICLE",
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

        public Operacion AsociarVehiculoAPiloto(VehiculoArgumento vehiculoArgumento)
        {
            try
            {
                DbParameter[] parameters =
                {
                      new OAParameter
                    {
                        ParameterName = "@VEHICLE_CODE",
                        Value = vehiculoArgumento.Vehiculo.VEHICLE_CODE
                    }
                    ,
                    new OAParameter
                    {
                        ParameterName = "@PILOT_CODE",
                        Value = vehiculoArgumento.Vehiculo.PILOT_CODE
                    }
                    ,
                      new OAParameter
                    {
                        ParameterName = "@LAST_UPDATE_BY",
                        Value = vehiculoArgumento.Vehiculo.LAST_UPDATE_BY
                    }
                };

                var op =
                    BaseDeDatosServicio.ExecuteQuery<Operacion>(BaseDeDatosServicio.Esquema + ".OP_WMS_ASSOCIATE_VEHICLE_TO_PILOT",
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

        public Operacion DesasociarVehiculoDePiloto(VehiculoArgumento vehiculoArgumento)
        {
            try
            {
                DbParameter[] parameters =
                {
                      new OAParameter
                    {
                        ParameterName = "@VEHICLE_CODE",
                        Value = vehiculoArgumento.Vehiculo.VEHICLE_CODE
                    }
                    ,
                      new OAParameter
                    {
                        ParameterName = "@LAST_UPDATE_BY",
                        Value = vehiculoArgumento.Vehiculo.LAST_UPDATE_BY
                    }
                };

                var op =
                    BaseDeDatosServicio.ExecuteQuery<Operacion>(BaseDeDatosServicio.Esquema + ".OP_WMS_DISSASOCIATE_VEHICLE_FROM_PILOT",
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

        public IList<Vehiculo> ObtenerVehiculos(VehiculoArgumento vehiculoArgumento)
        {
            DbParameter[] parameters =
               {
                new OAParameter
                {
                    ParameterName = "@VEHICLE_CODE",
                    Value = vehiculoArgumento.Vehiculo.VEHICLE_CODE
                }
            };
            return
                BaseDeDatosServicio.ExecuteQuery<Vehiculo>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_VEHICLE",
                    CommandType.StoredProcedure, parameters).ToList();
        }

        public Vehiculo ObtenerVehiculo(VehiculoArgumento vehiculoArgumento)
        {
            return
                BaseDeDatosServicio.ExecuteQuery<Vehiculo>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_VEHICLE",
                    CommandType.StoredProcedure, null)[0];
        }

        public IList<Vehiculo> ObtenerVehiculosConPilotosAsociados()
        {
            return
                BaseDeDatosServicio.ExecuteQuery<Vehiculo>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_VEHICLES_WITH_PILOT",
                    CommandType.StoredProcedure, null).ToList();
        }

        public IList<Vehiculo> ObtenerVehiculosPorPeso(VehiculoArgumento vehiculoArgumento)
        {

            DbParameter[] parameters =
             {
                new OAParameter
                {
                    ParameterName = "@WEIGHT",
                    Value = vehiculoArgumento.Vehiculo.WEIGHT
                }
            };
            return
                BaseDeDatosServicio.ExecuteQuery<Vehiculo>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_VEHICLE_BY_WEIGHT",
                    CommandType.StoredProcedure, parameters).ToList();
        }

        public IList<VehiculoManifiesto> ObtenerVehiculosParaDemandaDespacho()
        {
            var result = BaseDeDatosServicio.ExecuteQuery<VehiculoManifiesto>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_VEHICLE_FOR_PICKING_DEMAND_MANIFEST", CommandType.StoredProcedure, true, null).ToList();
            result.Add(new VehiculoManifiesto()
            {
                AVAILABLE_VOLUME = 0,AVAILABLE_WEIGHT = 0,FILL_RATE = 0,IS_OWN = 3,MAX_VOLUME = 0,MAX_WEIGHT = 0,Ordenes = new List<OrdenDeVentaEncabezado>(),ORIGINAL_USED_VOLUME = 0,ORIGINAL_USED_WEIGHT = 0,ORIGINAL_AVAILABLE_VOLUME = 0,
                ORIGINAL_AVAILABLE_WEIGHT = 0,PRIORITY = 9999,VEHICLE_CODE = -1, STATUS = "SIN_VEHICULO",VEHICLE = "SIN VEHICULO",USED_VOLUME = 0,USED_WEIGHT = 0,PLATE_NUMBER = string.Empty,
                RATING = 0,TRANSPORT_COMPANY_CODE = 0,TRANSPORT_COMPANY_NAME = string.Empty
            });
            return result;
        }
    }
}