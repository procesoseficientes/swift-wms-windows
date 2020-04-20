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
using MoreLinq;
using Telerik.OpenAccess.Data.Common;

namespace MobilityScm.Modelo.Servicios
{
    public class LineaDePickingServicio : ILineaDePickingServicio
    {
        public IBaseDeDatosServicio BaseDeDatosServicio { get; set; }

        public LineaDePickingServicio(IBaseDeDatosServicio baseDeDatosServicio)
        {
            BaseDeDatosServicio = baseDeDatosServicio;
        }

        public IList<Caja> ObtenerCajasPorFecha(ConsultaArgumento consultaArgumento)
        {
            DbParameter[] parameters =
          {
               new OAParameter
               {
                   ParameterName = "@START_DATETIME",
                   Value = consultaArgumento.FechaInicial
               }
               , new OAParameter
               {
                   ParameterName = "@END_DATETIME",
                   Value = consultaArgumento.FechaFinal
               }
           };
            return BaseDeDatosServicio.ExecuteQuery<Caja>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_BOX_REPORT_BY_DATETIME", CommandType.StoredProcedure, parameters);
        }

        public IList<Caja> ObtenerCajasPorManifiestoDeCarga(ManifiestoArgumento manifiestoArgumento)
        {
            DbParameter[] parameters =
          {
               new OAParameter
               {
                   ParameterName = "@MANIFEST_HEADER_ID",
                   Value = manifiestoArgumento.IdManifiestoDeCarga
               }
           };
            return BaseDeDatosServicio.ExecuteQuery<Caja>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_BOX_REPORT_BY_MANIFEST", CommandType.StoredProcedure, parameters);
        }

        public IList<CajaPorCliente> ObtenerCajasPorCliente(ManifiestoArgumento argumento)
        {
            var cajas = ObtenerCajasPorManifiestoDeCarga(argumento);

            var cajasPorCliente = cajas
                .GroupBy(c => new { c.CLIENT_ID, c.CLIENT_NAME })
                .Select(cc => new CajaPorCliente()
                {
                    PLATE_NUMBER = cc.First().PLATE_NUMBER,
                    BOX_AMOUNT = cc.Select(c => c.BOX_ID).ToList().Distinct().Count(),
                    BOXES = string.Join(", ", cc.Select(c => c.BOX_ID).ToList().Distinct()),
                    CLIENT_NAME = cc.First().CLIENT_NAME,
                    CLIENT_CODE = cc.First().CLIENT_ID,
                    DISTRIBUTION_CENTER = cc.First().DISTRIBUTION_CENTER,
                    MANIFEST_HEADER_ID = cc.First().MANIFEST_HEADER_ID,
                    PILOT_FULL_NAME = cc.First().PILOT_FULL_NAME,
                    DOCUMENTS = string.Join(", ", cc.Select(c => c.ERP_REFERENCE).ToList().Distinct())
                });

            return cajasPorCliente.ToList();
        }

        public IList<Caja> ObtenerCajaPorId(ConsultaArgumento consultaArgumento)
        {
            DbParameter[] parameters =
            {
                new OAParameter
                {
                    ParameterName = "@BOX_ID",
                    Value = consultaArgumento.IdParametro
                }
            };
            return BaseDeDatosServicio.ExecuteQuery<Caja>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_BOX_BY_ID", CommandType.StoredProcedure, parameters);
        }

        public Operacion ModificarCaja(CajaArgumento cajaArgumento)
        {
            try
            {
                var operacion = new Operacion();
                BaseDeDatosServicio.BeginTransaction();

                foreach (var caja in cajaArgumento.Cajas)
                {
                    DbParameter[] parameters =
                    {
                        new OAParameter
                        {
                            ParameterName = "@LOGIN",
                            Value = cajaArgumento.Login
                        }
                        , new OAParameter
                        {
                            ParameterName = "@ERP_DOC",
                            Value = caja.ERP_DOC
                        }
                        , new OAParameter
                        {
                            ParameterName = "@BOX_ID",
                            Value = caja.BOX_ID
                        }
                        , new OAParameter
                        {
                            ParameterName = "@MATERIAL_ID",
                            Value = caja.MATERIAL_ID
                        }
                        , new OAParameter
                        {
                            ParameterName = "@QTY",
                            Value = caja.QUANTITY
                        }
                         , new OAParameter
                        {
                            ParameterName = "@PICKING_LINE",
                            Value =caja.PICKING_LINE
                        }
                    };

                    operacion = BaseDeDatosServicio.ExecuteQuery<Operacion>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_UPDATE_BOX_QTY", CommandType.StoredProcedure, false, parameters)[0];
                    if (operacion.Resultado == ResultadoOperacionTipo.Error) break;
                }

                if (operacion.Resultado != ResultadoOperacionTipo.Error) BaseDeDatosServicio.Commit();
                else BaseDeDatosServicio.Rollback();

                return operacion;
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
    }
}