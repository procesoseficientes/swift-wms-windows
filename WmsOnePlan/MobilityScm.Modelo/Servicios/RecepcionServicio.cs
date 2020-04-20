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
    public class RecepcionServicio : IRecepcionServicio
    {
        public IBaseDeDatosServicio BaseDeDatosServicio { get; set; }

        public RecepcionServicio(IBaseDeDatosServicio baseDeDatosServicio)
        {
            BaseDeDatosServicio = baseDeDatosServicio;
        }

        public DocumentoRecepcionERPArgumento GrabarRecepcionDesdeErp(DocumentoRecepcionERPArgumento documentoRecepcionErpArgumento)
        {
            try
            {
                BaseDeDatosServicio.BeginTransaction();

                var op = new Operacion
                {
                    Codigo = 0,
                    Mensaje = "Proceso Exitoso",
                    Resultado = ResultadoOperacionTipo.Exito
                };
                var listaOperadores = new List<string>();
                int taskIdConsolidado = -1;
                int polizaIdConsolidado = -1;

                foreach (var documentoErp in documentoRecepcionErpArgumento.DocumentosDeRecepcion)
                {

                    //Grabar la poliza
                    var poliza = new Poliza
                    {
                        NUMERO_ORDEN = documentoErp.DOC_NUM.ToString(),
                        FECHA_DOCUMENTO = DateTime.Now,
                        LAST_UPDATED_BY = documentoErp.LAST_UPDATE_BY,
                        CLIENT_CODE = documentoErp.CODE_CLIENT,
                        ACUERDO_COMERCIAL = documentoErp.TRADE_AGREEMENT,
                        POLIZA_ASEGURADA = documentoErp.INSURANCE_POLICY
                        ,
                        PolizaAssognedto = documentoErp.TASK_ASSIGNEDTO
                    };

                    if (polizaIdConsolidado == -1) { 
                        op = GrabarPolizaDeRecepcion(poliza);
                        if (op.Resultado == ResultadoOperacionTipo.Error)
                        {
                            BaseDeDatosServicio.Rollback();
                            return new DocumentoRecepcionERPArgumento { Operacion = op };
                        }
                        polizaIdConsolidado = int.Parse(op.DbData);
                    }

                    poliza.DOC_ID = polizaIdConsolidado;

                    //Genera una tarea de recepcion
                    var tarea = new Tarea
                    {
                        TASK_SUBTYPE = documentoErp.TYPE_RECEPTION
                        ,
                        TASK_OWNER = documentoErp.LAST_UPDATE_BY
                        ,
                        TASK_ASSIGNEDTO = documentoErp.TASK_ASSIGNEDTO
                        ,
                        TASK_COMMENTS = string.Empty
                        ,
                        REGIMEN = documentoErp.REGIMEN
                        ,
                        CLIENT_OWNER = documentoErp.CODE_CLIENT
                        ,
                        CLIENT_NAME = documentoErp.CLIENT_NAME
                        ,
                        CODIGO_POLIZA_SOURCE2 = polizaIdConsolidado.ToString()
                        ,
                        DOC_ID_SOURCE = polizaIdConsolidado
                        ,
                        PRIORITY = int.Parse(documentoErp.PRIORITY)
                        ,
                        IS_FROM_ERP = "1"
                        ,
                        LOCATION_SPOT_TARGET = documentoErp.LOCATION_SPOT_TARGET
                        ,
                        OWNER = documentoErp.OWNER
                    };
                    if (!documentoRecepcionErpArgumento.Consolidado)
                    {
                        op = GrabarTareaDeRecepcionGeneral(tarea);
                        if (op.Resultado == ResultadoOperacionTipo.Error)
                        {
                            BaseDeDatosServicio.Rollback();
                            return new DocumentoRecepcionERPArgumento { Operacion = op };
                        }
                        else
                        {
                            documentoErp.TASK_ID = int.Parse(op.DbData);
                        }
                        polizaIdConsolidado = -1;
                    }
                    else
                    {
                        if (taskIdConsolidado == -1)
                        {
                            op = GrabarTareaDeRecepcionGeneral(tarea);
                            if (op.Resultado == ResultadoOperacionTipo.Error)
                            {
                                BaseDeDatosServicio.Rollback();
                                return new DocumentoRecepcionERPArgumento { Operacion = op };
                            }
                            taskIdConsolidado = int.Parse(op.DbData);
                        }
                        documentoErp.TASK_ID = taskIdConsolidado;
                    }

                    listaOperadores.Add(documentoErp.TASK_ASSIGNEDTO);

                    //Grabar el documento de erp
                    
                    documentoErp.DOC_ID_POLIZA = poliza.DOC_ID;
                    op = GrabarDocumentoRecepcionErp(documentoErp);
                    if (op.Resultado == ResultadoOperacionTipo.Error)
                    {
                        BaseDeDatosServicio.Rollback();
                        return new DocumentoRecepcionERPArgumento { Operacion = op };
                    }
                }
                BaseDeDatosServicio.Commit();

                return new DocumentoRecepcionERPArgumento { Operacion = op, Operadores = listaOperadores };

            }
            catch (DbException ex)
            {
                BaseDeDatosServicio.Rollback();
                return new DocumentoRecepcionERPArgumento
                {
                    Operacion = new Operacion
                    {
                        Codigo = ex.ErrorCode,
                        Mensaje = ex.Message,
                        Resultado = ResultadoOperacionTipo.Error
                    }
                };
            }
            catch (Exception ex)
            {
                BaseDeDatosServicio.Rollback();
                return new DocumentoRecepcionERPArgumento
                {
                    Operacion = new Operacion
                    {
                        Codigo = -1,
                        Mensaje = ex.Message,
                        Resultado = ResultadoOperacionTipo.Error
                    }
                };
            }
        }

        public Operacion GrabarDocumentoRecepcionErp(DocumentoRecepcion documentoRecepcionErpEncabezado)
        {
            try
            {
                DbParameter[] parameters =
                {
                    new OAParameter
                    {
                        ParameterName = "@DOC_ID",
                        Value = documentoRecepcionErpEncabezado.DOC_ID
                    }
                    ,
                    new OAParameter
                    {
                        ParameterName = "@TYPE",
                        Value = documentoRecepcionErpEncabezado.TYPE
                    }
                    ,
                    new OAParameter
                    {
                        ParameterName = "@CODE_SUPPLIER",
                        Value = documentoRecepcionErpEncabezado.CODE_SUPPLIER
                    }
                    ,
                    new OAParameter
                    {
                        ParameterName = "@LAST_UPDATE_BY",
                        Value = documentoRecepcionErpEncabezado.LAST_UPDATE_BY
                    }
                    ,
                    new OAParameter
                    {
                        ParameterName = "@TASK_ID",
                        Value = documentoRecepcionErpEncabezado.TASK_ID
                    }
                    ,
                    new OAParameter
                    {
                        ParameterName = "@EXTERNAL_SOURCE_ID",
                        Value = documentoRecepcionErpEncabezado.EXTERNAL_SOURCE_ID
                    }
                    , new OAParameter
                    {
                        ParameterName = "@IS_COMPLETE",
                        Value = documentoRecepcionErpEncabezado.IS_COMPLETE
                    }
                    , new OAParameter
                    {
                        ParameterName = "@DOC_NUM",
                        Value = documentoRecepcionErpEncabezado.DOC_NUM
                    }
                    , new OAParameter
                    {
                        ParameterName = "@NAME_SUPPLIER",
                        Value = documentoRecepcionErpEncabezado.NAME_SUPPLIER
                    }
                    , new OAParameter
                    {
                        ParameterName = "@OWNER",
                        Value = documentoRecepcionErpEncabezado.OWNER
                    }
                    , new OAParameter
                    {
                        ParameterName = "@SOURCE",
                        Value = documentoRecepcionErpEncabezado.SOURCE
                    }
                    , new OAParameter
                    {
                        ParameterName = "@ERP_WAREHOUSE_CODE",
                        Value = documentoRecepcionErpEncabezado.ERP_WAREHOUSE_CODE
                    }
                    , new OAParameter
                    {
                        ParameterName = "@DOC_ID_POLIZA",
                        Value = documentoRecepcionErpEncabezado.DOC_ID_POLIZA
                    }
                    , new OAParameter
                    {
                        ParameterName = "@DOC_ENTRY",
                        Value = documentoRecepcionErpEncabezado.DOC_ENTRY
                    }
                    , new OAParameter
                    {
                        ParameterName = "@ADDRESS",
                        Value = documentoRecepcionErpEncabezado.ADDRESS
                    }
                    , new OAParameter
                    {
                        ParameterName = "@DOC_CURRENCY",
                        Value = documentoRecepcionErpEncabezado.DOC_CURRENCY
                    }
                    , new OAParameter
                    {
                        ParameterName = "@DOC_RATE",
                        Value = documentoRecepcionErpEncabezado.DOC_RATE
                    }
                    , new OAParameter
                    {
                        ParameterName = "@SUBSIDIARY",
                        Value = documentoRecepcionErpEncabezado.SUBSIDIARY
                    }

                };
                var op = BaseDeDatosServicio.ExecuteQuery<Operacion>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_INSERT_ERP_RECEPTION_DOCUMENT_HEADER", CommandType.StoredProcedure, false, parameters)[0];

                if (op.Resultado != ResultadoOperacionTipo.Exito) return op;

                var id = op.DbData;
                foreach (var detalle in documentoRecepcionErpEncabezado.DocumentoRecepcionErpDetalles)
                {

                    DbParameter[] parametersDetalle ={
                        new OAParameter
                        {
                            ParameterName = "@ERP_RECEPTION_DOCUMENT_HEADER_ID",
                            Value = id
                        }
                        ,
                        new OAParameter
                        {
                            ParameterName = "@MATERIAL_ID",
                            Value = detalle.MATERIAL_ID
                        }
                        ,
                        new OAParameter
                        {
                            ParameterName = "@QTY",
                            Value = detalle.QTY
                        }
                        ,
                        new OAParameter
                        {
                            ParameterName = "@LINE_NUM",
                            Value = detalle.LINE_NUM
                        }
                        ,
                        new OAParameter
                        {
                            ParameterName = "@ERP_OBJECT_TYPE",
                            Value = detalle.ERP_OBJECT_TYPE
                        }
                        ,
                        new OAParameter
                        {
                            ParameterName = "@CURRENCY",
                            Value = detalle.DET_CURRENCY
                        }
                        ,
                        new OAParameter
                        {
                            ParameterName = "@RATE",
                            Value = detalle.DET_RATE
                        }
                        ,
                        new OAParameter
                        {
                            ParameterName = "@TAX_CODE",
                            Value = detalle.DET_TAX_CODE
                        }
                        ,
                        new OAParameter
                        {
                            ParameterName = "@VAT_PERCENT",
                            Value = detalle.DET_VAT_PERCENT
                        }
                        ,
                        new OAParameter
                        {
                            ParameterName = "@PRICE",
                            Value = detalle.PRICE
                        }
                        ,
                        new OAParameter
                        {
                            ParameterName = "@DISCOUNT",
                            Value = detalle.DISCOUNT_PERCENT
                        }
                        ,
                        new OAParameter
                        {
                            ParameterName = "@WAREHOUSE_CODE",
                            Value = detalle.WAREHOUSE_CODE
                        }   
                        , new OAParameter
                        {
                            ParameterName = "@COST_CENTER",
                            Value = detalle.COST_CENTER
                        }, new OAParameter
                        {
                            ParameterName = "@UNIT",
                            Value = detalle.UNIT
                        }, new OAParameter
                        {
                            ParameterName = "@UNIT_DESCRIPTION",
                            Value = detalle.UNIT_DESCRIPTION
                        }
                    };
                    op = BaseDeDatosServicio.ExecuteQuery<Operacion>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_INSERT_ERP_RECEPTION_DOCUMENT_DETAIL", CommandType.StoredProcedure, false, parametersDetalle)[0];

                    if (op.Resultado == ResultadoOperacionTipo.Error)
                    {
                        return op;
                    }
                }

                return op;
            }
            catch (DbException ex)
            {
                return new Operacion
                {
                    Codigo = ex.ErrorCode,
                    Mensaje = ex.Message,
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

        public Operacion GrabarPolizaDeRecepcion(Poliza poliza)
        {
            try
            {
                DbParameter[] parameters ={
                   new OAParameter
                   {
                       ParameterName = "@ORDER_NUM",
                       Value = poliza.NUMERO_ORDEN
                   }
                   ,
                       new OAParameter
                   {
                       ParameterName = "@DOC_DATE",
                       Value = poliza.FECHA_DOCUMENTO
                   }
                   ,
                   new OAParameter
                   {
                       ParameterName = "@LAST_UPDATED_BY",
                       Value = poliza.LAST_UPDATED_BY
                   }
                   ,
                    new OAParameter
                   {
                       ParameterName = "@CLIENT_CODE",
                       Value = poliza.CLIENT_CODE
                   }
                   ,
                    new OAParameter
                   {
                       ParameterName = "@TRADE_AGREEMENT",
                       Value = poliza.ACUERDO_COMERCIAL
                   }
                   ,
                    new OAParameter
                   {
                       ParameterName = "@INSURANCE_POLICY",
                       Value = poliza.POLIZA_ASEGURADA
                   }
                    ,
                    new OAParameter
                   {
                       ParameterName = "@ASSIGNED_TO",
                       Value = poliza.PolizaAssognedto
                   }
                };
                var op = BaseDeDatosServicio.ExecuteQuery<Operacion>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_INSERT_RECEPTION_GENERAL_POLICY", CommandType.StoredProcedure, false, parameters)[0];

                return op;
            }
            catch (DbException ex)
            {
                return new Operacion
                {
                    Codigo = ex.ErrorCode,
                    Mensaje = ex.Message,
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

        public Operacion GrabarTareaDeRecepcionGeneral(Tarea tarea)
        {
            try
            {
                DbParameter[] parameters ={
                   new OAParameter
                   {
                       ParameterName = "@TASK_SUBTYPE",
                       Value = tarea.TASK_SUBTYPE
                   }
                   ,
                       new OAParameter
                   {
                       ParameterName = "@TASK_OWNER",
                       Value = tarea.TASK_OWNER
                   }
                   ,
                   new OAParameter
                   {
                       ParameterName = "@TASK_ASSIGNEDTO",
                       Value = tarea.TASK_ASSIGNEDTO
                   }
                   ,
                    new OAParameter
                   {
                       ParameterName = "@TASK_COMMENTS",
                       Value = tarea.TASK_COMMENTS
                   }
                   ,
                    new OAParameter
                   {
                       ParameterName = "@REGIMEN",
                       Value = tarea.REGIMEN
                   }
                   ,
                    new OAParameter
                   {
                       ParameterName = "@CLIENT_OWNER",
                       Value = tarea.CLIENT_OWNER
                   }
                   ,
                    new OAParameter
                   {
                       ParameterName = "@CLIENT_NAME",
                       Value = tarea.CLIENT_NAME
                   }
                    ,new OAParameter
                   {
                       ParameterName = "@CODIGO_POLIZA_SOURCE",
                       Value = tarea.CODIGO_POLIZA_SOURCE2
                   }
                   , new OAParameter
                   {
                       ParameterName = "@DOC_ID_SOURCE",
                       Value = tarea.DOC_ID_SOURCE
                   }
                   , new OAParameter
                   {
                       ParameterName = "@PRIORITY",
                       Value = tarea.PRIORITY
                   }
                   , new OAParameter
                   {
                       ParameterName = "@IS_FROM_ERP",
                       Value = tarea.IS_FROM_ERP
                   }
                   , new OAParameter
                   {
                       ParameterName = "@LOCATION_SPOT_TARGET",
                       Value = tarea.LOCATION_SPOT_TARGET
                   }
                   , new OAParameter
                    {
                        ParameterName = "@OWNER",
                        Value = tarea.OWNER
                    },
                };
                var op = BaseDeDatosServicio.ExecuteQuery<Operacion>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_INSERT_TASK_RECEPTION_ERP", CommandType.StoredProcedure, false, parameters)[0];

                return op;
            }
            catch (DbException ex)
            {
                return new Operacion
                {
                    Codigo = ex.ErrorCode,
                    Mensaje = ex.Message,
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

        public IList<DocumentoRecepcionErpEncabezado> DocumentosRecepcionErpEncabezados(FuenteExterna fuenteExterna)
        {
            DbParameter[] parameters =
          {
               new OAParameter
               {
                   ParameterName = "@INITIAL_DATE",
                   Value = fuenteExterna.INITIAL_DATE
               }
               , new OAParameter
               {
                   ParameterName = "@END_DATE",
                   Value = fuenteExterna.END_DATE
               },
                new OAParameter
               {
                   ParameterName = "@EXTERNAL_SOURCE_ID",
                   Value = fuenteExterna.EXTERNAL_SOURCE_ID
               },
                new OAParameter
               {
                   ParameterName = "@HAS_MISSING",
                   Value = fuenteExterna.HAS_MISSING
               },
                new OAParameter
               {
                   ParameterName = "@CLIENT_CODE",
                   Value = fuenteExterna.CLIENT_CODE
               }
           };
            return BaseDeDatosServicio.ExecuteQuery<DocumentoRecepcionErpEncabezado>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_ERP_RECEPTION_DOCUMENT_HEADER", CommandType.StoredProcedure, parameters);
        }

        public IList<DocumentoRecepcionErpDetalle> DocumentosRecepcionErpDetalles(DocumentoRecepcionErpEncabezado documentoRecepcionErpEnabezado)
        {
            DbParameter[] parameters =
          {
               new OAParameter
               {
                   ParameterName = "@DOC_ID",
                   Value = documentoRecepcionErpEnabezado.DOC_IDS
               }
               , new OAParameter
               {
                   ParameterName = "@EXTERNAL_SOURCE_ID",
                   Value = documentoRecepcionErpEnabezado.EXTERNAL_SOURCE_ID
               }
               , new OAParameter
               {
                   ParameterName = "@CLIENT_CODE",
                   Value = documentoRecepcionErpEnabezado.OWNER
               }
           };
            return BaseDeDatosServicio.ExecuteQuery<DocumentoRecepcionErpDetalle>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_ERP_RECEPTION_DOCUMENT_DETAIL", CommandType.StoredProcedure, parameters);
        }

        public IList<DocumentoRecepcionErpDetalle> ObtenerFacturaParaDevolucion(DocumentoRecepcionErpEncabezado documentoRecepcionErpEnabezado)
        {
            DbParameter[] parameters =
            {
                new OAParameter
                {
                    ParameterName = "@DOC_NUM",
                    Value = documentoRecepcionErpEnabezado.DOC_NUM
                }
                ,new OAParameter
                {
                    ParameterName = "@OWNER",
                    Value = documentoRecepcionErpEnabezado.OWNER
                }
                ,new OAParameter
                {
                    ParameterName = "@EXTERNAL_SOURCE_ID",
                    Value = documentoRecepcionErpEnabezado.EXTERNAL_SOURCE_ID
                }
            };
            return BaseDeDatosServicio.ExecuteQuery<DocumentoRecepcionErpDetalle>(BaseDeDatosServicio.Esquema + ".OP_WMS_GET_INVOICE_FOR_RETURN ", CommandType.StoredProcedure, parameters);
        }

        public IList<ReporteRecepcionPorDevolucion> ObtenerReporteRecepcionPorDevoulucion(ConsultaArgumento argumento)
        {
            DbParameter[] parameters =
            {
                new OAParameter
                {
                    ParameterName = "@START_DATE",
                    Value = argumento.FechaInicial
                }
                ,new OAParameter
                {
                    ParameterName = "@END_DATE",
                    Value = argumento.FechaFinal
                }
                ,new OAParameter
                {
                    ParameterName = "@LOGIN",
                    Value = argumento.Login
                }
                ,new OAParameter
                {
                    ParameterName = "@WAREHOUSE",
                    Value = argumento.CodigoBodega
                }
            };
            return BaseDeDatosServicio.ExecuteQuery<ReporteRecepcionPorDevolucion>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_RECEPTION_RETURN_REPORT ", CommandType.StoredProcedure, parameters);
        }
    }
}
