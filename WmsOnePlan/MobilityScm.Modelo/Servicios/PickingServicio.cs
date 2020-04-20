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
using MobilityScm.Modelo.Estados;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Modelo.Tipos;
using MobilityScm.Utilerias;
using MobilityScm.Vertical.Entidades;
using Telerik.OpenAccess.Data.Common;

namespace MobilityScm.Modelo.Servicios
{
    public class PickingServicio : IPickingServicio
    {

        #region Base de datos
        public IBaseDeDatosServicio BaseDeDatosServicio { get; set; }

        public PickingServicio(IBaseDeDatosServicio baseDeDatosServicio)
        {
            BaseDeDatosServicio = baseDeDatosServicio;
        }
        #endregion

        public Operacion CrearPickingDeOrdenDeVenta(ref PickingArgumento argumento)
        {
            var wavePickingId = 0;
            try
            {
                var tipoDespacho = Enums.GetStringValue(TipoDemandaDespacho.OrdenVenta);
                if (argumento.TipoDespacho == TipoFuenteDemandaDespacho.SolicitudTrasladoErp ||
                    argumento.TipoDespacho == TipoFuenteDemandaDespacho.SolicitudTrasladoWms)
                {
                    tipoDespacho = Enums.GetStringValue(TipoDemandaDespacho.SolicitudTraslado);
                }

                var serializer = new XmlSerializer(typeof(List<OrdenDeVentaEncabezado>));
                var xmlDocumentos = new StringWriter();
                var xmlWriter = new XmlTextWriter(xmlDocumentos) { Formatting = Formatting.Indented };
                serializer.Serialize(xmlWriter, argumento.Encabezados.ToList());
                var documentos = xmlDocumentos.ToString();

                DbParameter[] parameters =
          {
                new OAParameter
                {
                    ParameterName = "@LOGIN",
                    Value = argumento.Login
                },
                new OAParameter
                {
                    ParameterName = "@LOCATION_TARGET",
                    Value = argumento.Ubicacion.LOCATION_SPOT
                },
                new OAParameter
                {
                    ParameterName = "@IS_CONSOLIDATED",
                    Value = argumento.EsConsolidado ? 1 : 0
                },
                new OAParameter
                {
                    ParameterName = "@SOURCE",
                    Value = Enums.GetStringValue(argumento.TipoDespacho),
                }
                ,
                new OAParameter
                {
                    ParameterName = "@CODE_WAREHOUSE",
                    Value = argumento.Bodega,
                }

                ,
                new OAParameter
                {
                    ParameterName = "@DEMAND_TYPE",
                    Value = tipoDespacho,
                }
                ,
                new OAParameter
                {
                    ParameterName = "@IN_PICKING_LINE",
                    Value =  argumento.ManejaLineaDePicking ? (int)SiNo.Si : (int)SiNo.No,
                }
                ,
                new OAParameter
                {
                    ParameterName = "@LINE_ID",
                    Value = argumento.LineaDePicking,
                }
                ,
                new OAParameter
                {
                    ParameterName = "@DEMAND",
                    Value = documentos,
                }
                ,
                new OAParameter
                {
                    ParameterName = "@IS_FOR_DELIVERY_IMMEDIATE",
                    Value = argumento.EsDemandaParaEntregaInmediata,
                }
                ,
                new OAParameter
                {
                    ParameterName = "@PRIORITY",
                    Value = argumento.PrioridadDeTarea,
                }
                ,
                new OAParameter
                {
                    ParameterName = "@PROJECT_ID",
                    Value = argumento.Proyecto.ID == Guid.Empty ? (Guid?)null :  argumento.Proyecto.ID,
                }
                ,
                new OAParameter
                {
                    ParameterName = "@ORDER_NUMBER",
                    Value = argumento.NumeroOrden,
                }
            };
                var resultado = BaseDeDatosServicio.ExecuteQuery<OrdenDeVentaEncabezado>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_CREATE_DEMAND"
                    , CommandType.StoredProcedure, false, parameters);
                if (resultado.Count <= 0)
                {
                    throw new Exception("Error inesperado, no se generó el picking.");
                }

                foreach (var encabezado in argumento.Encabezados)
                {
                    var encabezadoResultado = resultado.FirstOrDefault(x => x.ID == encabezado.ID);
                    if (encabezadoResultado == null)
                    {
                        throw new Exception("No se encontró pedido en resultado.");
                    }
                    encabezado.WAVE_PICKING_ID = encabezadoResultado.WAVE_PICKING_ID;
                    encabezado.PICKING_DEMAND_HEADER_ID = encabezadoResultado.PICKING_DEMAND_HEADER_ID;
                    encabezado.LINE_DOC = encabezadoResultado.LINE_DOC;
                    encabezado.BOX_QTY = encabezadoResultado.BOX_QTY;
                    wavePickingId = encabezadoResultado.WAVE_PICKING_ID;
                }
#if !DEBUG
                EnviarABandaTransportadora(argumento);
#endif

            }
            catch (Exception ex)
            {
                return new Operacion
                {
                    Codigo = -1,
                    Mensaje = ex.Message,
                    Resultado = Tipos.ResultadoOperacionTipo.Error
                };
            }
            return new Operacion
            {
                Codigo = 0,
                Mensaje = "Proceso Exitoso",
                Resultado = ResultadoOperacionTipo.Exito,
                DbData = wavePickingId.ToString()
            };
        }

        private void EnviarABandaTransportadora(PickingArgumento argumento)
        {

            if (argumento.ManejaLineaDePicking)
            {
                var servicio = new BandaAtoxAriumWS.BandaAtoxAriumSoapClient();

                foreach (var encabezado in argumento.Encabezados)
                {
                    var resultado = "";
                    if (encabezado.BOX_QTY > 0)
                    {
                        int idDeInduccion = servicio.RegistroEncabezado(encabezado.LINE_DOC, encabezado.BOX_QTY, ref resultado);
                        if (resultado == "OK")
                        {
                            var operacionDeInduccion = ColocaIdDeIndcuccionATareaDeLineaDePicking(encabezado.LINE_DOC, idDeInduccion);
                            if (operacionDeInduccion.Resultado == ResultadoOperacionTipo.Error)
                            {
                                throw new Exception(operacionDeInduccion.Mensaje);
                            }
                            if (argumento.EsConsolidado)
                            {
                                return;
                            }
                        }
                    }

                }
            }


        }


        private Operacion CrearPolizaDeDespachoDeUnaOrdenDeVenta(OrdenDeVentaEncabezado encabezado, string login, TipoFuenteDemandaDespacho tipoFuente)
        {
            var poliza = new Poliza
            {
                FECHA_LLEGADA = DateTime.Now,
                LAST_UPDATED_BY = login,
                LAST_UPDATED = DateTime.Now,
                CLIENT_CODE = encabezado.SOURCE_NAME,
                FECHA_DOCUMENTO = DateTime.Now,
                EXTERNAL_SOURCE_ID = encabezado.EXTERNAL_SOURCE_ID,
                SALES_ORDER_ID = encabezado.SALES_ORDER_ID
            };
            var op = new Operacion();
            DbParameter[] parameters =
            {
                new OAParameter
                {
                    ParameterName = "@DOC_ID",
                    Value = 0
                },
                 new OAParameter
                {
                    ParameterName = "@FECHA_LLEGADA",
                    Value = poliza.FECHA_LLEGADA
                }, new OAParameter
                {
                    ParameterName = "@LAST_UPDATED_BY",
                    Value = poliza.LAST_UPDATED_BY
                }, new OAParameter
                {
                    ParameterName = "@LAST_UPDATED",
                    Value = poliza.LAST_UPDATED
                }, new OAParameter
                {
                    ParameterName = "@CLIENT_CODE",
                    Value = poliza.CLIENT_CODE
                }, new OAParameter
                {
                    ParameterName = "@FECHA_DOCUMENTO",
                    Value = poliza.FECHA_DOCUMENTO
                }, new OAParameter
                {
                    ParameterName = "@TIPO",
                    Value = poliza.TIPO
                }, new OAParameter
                {
                    ParameterName = "@CODIGO_POLIZA",
                    Value = poliza.SALES_ORDER_ID + "-" + Enums.GetStringValue(tipoFuente).Replace(" ","") + '-' + poliza.CLIENT_CODE
                }
            };
            op = BaseDeDatosServicio.ExecuteQuery<Operacion>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_INSERT_POLIZA_HEADER", CommandType.StoredProcedure, false, parameters)[0];
            return op;
        }
        private Operacion CrearPickingDeOrdenDeVenta(OrdenDeVentaEncabezado encabezadoOrden, Poliza poliza
             , int wavePickingId, out IList<Picking> pickings, PickingArgumento argumento)
        {
            try
            {
                string transferRequestId = string.Empty;
                if (argumento.TipoDespacho == TipoFuenteDemandaDespacho.SolicitudTrasladoErp || argumento.TipoDespacho == TipoFuenteDemandaDespacho.SolicitudTrasladoWms)
                    transferRequestId = encabezadoOrden.SALES_ORDER_ID.ToString();

                pickings = (from detalle in encabezadoOrden.Detalles
                            group detalle by detalle.SKU
                                           into g
                            select new Picking
                            {
                                TASK_OWNER = argumento.Login,
                                TASK_ASSIGNEDTO = argumento.ManejaLineaDePicking ? argumento.LineaDePicking : "",//Si es de linea se lo asigna si no se queda vacio para la asignación posterior
                                QUANTITY_ASSIGNED = g.Sum(x => x.QTY),
                                CODIGO_POLIZA_TARGET = poliza.CODIGO_POLIZA,
                                MATERIAL_ID = g.Key,
                                BARCODE_ID = g.Max(x => x.BARCODE_ID),
                                ALTERNATE_BARCODE = g.Max(x => x.ALTERNATE_BARCODE),
                                MATERIAL_NAME = g.Max(x => x.DESCRIPTION_SKU),
                                CLIENT_OWNER = g.Max(x => x.MATERIAL_OWNER),
                                CLIENT_NAME = g.Max(x => x.MATERIAL_OWNER),
                                CODE_WAREHOUSE_SOURCE = argumento.Bodega,
                                TONE = g.Max(x => x.TONE),
                                CALIBER = g.Max(x => x.CALIBER),
                                IN_PICKING_LINE = argumento.ManejaLineaDePicking ? (int)SiNo.Si : (int)SiNo.No
                            }).ToList();

                Operacion op = new Operacion();
                if (!argumento.EsConsolidado)
                {
                    wavePickingId = 0;
                }

                foreach (var picking in pickings)
                {
                    DbParameter[] parameters =
                    {
                        new OAParameter
                        {
                            ParameterName = "@TASK_OWNER",
                            Value = picking.TASK_OWNER
                        },
                        new OAParameter
                        {
                            ParameterName = "@TASK_ASSIGNEDTO",
                            Value = picking.TASK_ASSIGNEDTO
                        },
                        new OAParameter
                        {
                            ParameterName = "@QUANTITY_ASSIGNED",
                            Value = picking.QUANTITY_ASSIGNED
                        },
                        new OAParameter
                        {
                            ParameterName = "@CODIGO_POLIZA_TARGET",
                            Value = encabezadoOrden.SALES_ORDER_ID + "-" + Enums.GetStringValue(argumento.TipoDespacho).Replace(" ","")  + '-' + encabezadoOrden.SOURCE_NAME
                        },
                        new OAParameter
                        {
                            ParameterName = "@MATERIAL_ID",
                            Value = picking.MATERIAL_ID
                        },
                        new OAParameter
                        {
                            ParameterName = "@BARCODE_ID",
                            Value = picking.BARCODE_ID
                        },
                        new OAParameter
                        {
                            ParameterName = "@ALTERNATE_BARCODE",
                            Value = picking.ALTERNATE_BARCODE
                        },
                        new OAParameter
                        {
                            ParameterName = "@MATERIAL_NAME",
                            Value = picking.MATERIAL_NAME
                        },
                        new OAParameter
                        {
                            ParameterName = "@CLIENT_OWNER",
                            Value = picking.CLIENT_OWNER
                        },
                        new OAParameter
                        {
                            ParameterName = "@CLIENT_NAME",
                            Value = picking.CLIENT_NAME
                        },
                        new OAParameter
                        {
                            ParameterName = "@IS_FROM_SONDA",
                            Value = encabezadoOrden.IS_FROM_SONDA
                        } ,
                        new OAParameter
                        {
                            ParameterName = "@CODE_WAREHOUSE",
                            Value = picking.CODE_WAREHOUSE_SOURCE
                        },
                        new OAParameter
                        {
                            ParameterName = "@IS_FROM_ERP",
                            Value = encabezadoOrden.IS_FROM_ERP
                        }
                        ,
                        new OAParameter
                        {
                            ParameterName = "@WAVE_PICKING_ID",
                            Value = wavePickingId
                        },
                        new OAParameter
                        {
                            ParameterName = "@DOC_ID_TARGET",
                            Value = picking.CODIGO_POLIZA_TARGET
                        },
                        new OAParameter
                        {
                            ParameterName = "@LOCATION_SPOT_TARGET",
                            Value = argumento.Ubicacion.LOCATION_SPOT
                        }
                        ,
                        new OAParameter
                        {
                            ParameterName = "@IS_CONSOLIDATED",
                            Value = argumento.EsConsolidado
                        },
                        new OAParameter
                        {
                            ParameterName = "@SOURCE_TYPE",
                            Value = Enums.GetStringValue(argumento.TipoDespacho)
                        }
                        ,
                        new OAParameter
                        {
                            ParameterName = "@TRANSFER_REQUEST_ID",
                            Value = transferRequestId == string.Empty ? null : transferRequestId
                        }
                        ,
                        new OAParameter
                        {
                            ParameterName = "@TONE",
                            Value = picking.TONE == string.Empty ? null : picking.TONE
                        }
                        ,
                        new OAParameter
                        {
                            ParameterName = "@CALIBER",
                            Value = picking.CALIBER == string.Empty ? null : picking.CALIBER
                        },
                        new OAParameter
                        {
                            ParameterName = "@IN_PICKING_LINE",
                            Value = picking.IN_PICKING_LINE
                        }
                    };

                    op = BaseDeDatosServicio.ExecuteQuery<Operacion>
                       (BaseDeDatosServicio.Esquema + ".OP_WMS_SP_INSERT_TASKS_GENERAL_PICKING_DEMAND", CommandType.StoredProcedure, false, parameters)[0];

                    if (op.Resultado == ResultadoOperacionTipo.Error)
                    {
                        throw new Exception(op.Mensaje);
                    }
                    else
                    {
                        wavePickingId = Convert.ToInt32(op.DbData.Split('|')[0]);
                        int QTY_MP = Convert.ToInt32(op.DbData.Split('|')?[1]);
                        picking.WAS_IMPLODED = QTY_MP > 0 ? 1 : 0;
                        picking.QTY_IMPLODED = QTY_MP;
                        picking.WAVE_PICKING_ID = wavePickingId;
                    }
                }
                return op;
            }
            catch (Exception ex)
            {
                pickings = null;
                throw new Exception("Error. No se pudo Insertar Picking de la orden de venta " +
                                    encabezadoOrden.SALES_ORDER_ID + ": " + ex.Message);
            }
        }

        private Poliza CrearPoliza(PickingArgumento argumento, OrdenDeVentaEncabezado encabezado)
        {
            var operacionPoliza = CrearPolizaDeDespachoDeUnaOrdenDeVenta(encabezado, argumento.Login, argumento.TipoDespacho);
            if (operacionPoliza.Resultado == ResultadoOperacionTipo.Error)
            {
                throw new Exception("Error. No se pudo crear la poliza de despacho " + encabezado.SALES_ORDER_ID + ": " + operacionPoliza.Mensaje);
            }

            var poliza = new Poliza { CODIGO_POLIZA = operacionPoliza.DbData };
            return poliza;
        }

        private int CrearDocumentoDemandaDespacho(PickingArgumento argumento, OrdenDeVentaEncabezado encabezado, int wavePickingId, IList<Picking> pickings)
        {
            var tipoDespacho = Enums.GetStringValue(TipoDemandaDespacho.OrdenVenta);
            if (argumento.TipoDespacho == TipoFuenteDemandaDespacho.SolicitudTrasladoErp ||
                argumento.TipoDespacho == TipoFuenteDemandaDespacho.SolicitudTrasladoWms)
            {
                tipoDespacho = Enums.GetStringValue(TipoDemandaDespacho.SolicitudTraslado);
            }

            var demandaHeader = new DemandaDespachoHeader
            {
                IS_FROM_SONDA = encabezado.IS_FROM_SONDA,
                IS_FROM_ERP = encabezado.IS_FROM_ERP,
                LAST_UPDATE_BY = argumento.Login,
                CLIENT_CODE = encabezado.CLIENT_ID,
                CUSTOMER_NAME = encabezado.CUSTOMER_NAME,
                CODE_SELLER = encabezado.CODE_SELLER,
                CODE_ROUTE = encabezado.CODE_ROUTE,
                CODE_WAREHOUSE = argumento.Bodega,
                DOC_NUM = encabezado.SALES_ORDER_ID,
                DOC_NUM_SEQUENCE = encabezado.DOC_NUM,
                LAST_UPDATE = DateTime.Now,
                SERIAL_NUMBER = encabezado.DOC_SERIE,
                TOTAL_AMOUNT = encabezado.TOTAL_AMOUNT,
                WAVE_PICKING_ID = wavePickingId,
                IS_COMPLETED = encabezado.IS_COMPLETED,
                EXTERNAL_SOURCE_ID = encabezado.EXTERNAL_SOURCE_ID,
                DOC_ENTRY = encabezado.DOC_ENTRY,
                IS_CONSOLIDATED = argumento.EsConsolidado ? 1 : 0,
                PRIORITY = encabezado.Prioridad,
                CLIENT_OWNER = encabezado.CLIENT_OWNER,
                MASTER_ID_SELLER = encabezado.MASTER_ID_SELLER,
                SELLER_OWNER = encabezado.SELLER_OWNER,
                OWNER = encabezado.OWNER,
                SOURCE_TYPE = Enums.GetStringValue(argumento.TipoDespacho),
                DEMAND_TYPE = tipoDespacho,
                WAREHOUSE_FROM = encabezado.WAREHOUSE_FROM,
                WAREHOUSE_TO = encabezado.WAREHOUSE_TO,
                DELIVERY_DATE = encabezado.DELIVERY_DATE.GetValueOrDefault().Date,
                ADDRESS_CUSTOMER = encabezado.ADDRESS_CUSTOMER,
                STATE_CODE = encabezado.STATE_CODE,
                DISCOUNT = encabezado.DISCOUNT,
                TYPE_DEMAND_CODE = encabezado.TYPE_DEMAND_CODE,
                TYPE_DEMAND_NAME = encabezado.TYPE_DEMAND_NAME

            };

            var op = CrearDemandaDespachoEncabezado(demandaHeader);
            if (op.Resultado == ResultadoOperacionTipo.Error)
            {

                throw new Exception("Error. No se pudo guardar la demanda de despacho de la orden de venta " +
                                    encabezado.SALES_ORDER_ID + ": " + op.Mensaje);
            }
            var pickingDocumentHeader = Convert.ToInt32(op.DbData);
            var demandaDetalle = encabezado.Detalles.Select(x => new DemandaDespachoDetalle
            {
                ERP_OBJECT_TYPE = x.ERP_OBJECT_TYPE,
                LINE_NUM = x.LINE_SEQ,
                MATERIAL_ID = x.SKU,
                PRICE = x.PRICE,
                PICKING_DEMAND_HEADER_ID = Convert.ToInt32(op.DbData),
                QTY = Convert.ToInt32(x.QTY),
                MASTER_ID_MATERIAL = x.MASTER_ID_MATERIAL,
                MATERIAL_OWNER = x.MATERIAL_OWNER,
                SOURCE_TYPE = Enums.GetStringValue(argumento.TipoDespacho),
                TONE = x.TONE,
                CALIBER = x.CALIBER,
                DISCOUNT = x.DISCOUNT,
                DISCOUNT_TYPE = x.DISCOUNT_TYPE,
                IS_BONUS = x.IS_BONUS
            }).ToList();

            op = CrearDemandaDespachoDetalle(demandaDetalle, pickings);
            if (op.Resultado == ResultadoOperacionTipo.Error)
            {
                throw new Exception(
                    "Error. No se pudo guardar el detalle de la demanda de despacho de la orden de venta " +
                    encabezado.SALES_ORDER_ID + ": " + op.Mensaje);

            }
            return pickingDocumentHeader;
        }

        public Operacion CrearDemandaDespachoDetalle(IList<DemandaDespachoDetalle> detalles, IList<Picking> pickings)
        {
            var op = new Operacion();
            foreach (var detalle in detalles)
            {

                var actualPicking = pickings.FirstOrDefault(x => (string)x.MATERIAL_ID == detalle.MATERIAL_ID);

                DbParameter[] parameters ={
                   new OAParameter
                   {
                       ParameterName = "@PICKING_DEMAND_HEADER_ID",
                       Value = detalle.PICKING_DEMAND_HEADER_ID
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
                       ParameterName = "@PRICE",
                       Value = detalle.PRICE
                   }
                     ,
                    new OAParameter
                   {
                       ParameterName = "@WAS_IMPLODED",
                       Value = actualPicking?.WAS_IMPLODED ??0
                   }
                     ,
                    new OAParameter
                   {
                       ParameterName = "@QTY_IMPLODED",
                       Value = actualPicking?.QTY_IMPLODED ??0
                   }
                    ,
                    new OAParameter
                   {
                       ParameterName = "@MASTER_ID_MATERIAL",
                       Value = detalle.MASTER_ID_MATERIAL
                   }
                    ,
                    new OAParameter
                   {
                       ParameterName = "@MATERIAL_OWNER",
                       Value = detalle.MATERIAL_OWNER
                   }
                      ,
                    new OAParameter
                   {
                       ParameterName = "@SOURCE_TYPE",
                       Value = detalle.SOURCE_TYPE
                   }
                    ,
                    new OAParameter
                   {
                       ParameterName = "@TONE",
                       Value = detalle.TONE
                   }
                    ,
                    new OAParameter
                   {
                       ParameterName = "@CALIBER",
                       Value = detalle.CALIBER
                   }
                   , new OAParameter
                   {
                       ParameterName = "@DISCOUNT",
                       Value = detalle.DISCOUNT
                   }, new OAParameter
                   {
                       ParameterName = "@DISCOUNT_TYPE",
                       Value = detalle.DISCOUNT_TYPE
                   }, new OAParameter
                   {
                       ParameterName = "@IS_BONUS",
                       Value = detalle.IS_BONUS
                   }

                };
                op = BaseDeDatosServicio.ExecuteQuery<Operacion>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_INSERT_NEXT_DEMAND_PICKING_DETAIL", CommandType.StoredProcedure, false, parameters)[0];
                if (op.Resultado == ResultadoOperacionTipo.Error)
                {
                    op.Mensaje = "Error. No se pudo insertar detalle de demanda " + detalle.PICKING_DEMAND_HEADER_ID + ": " + op.Mensaje;
                    return op;
                }
            }
            return op;
        }
        public Operacion CrearDemandaDespachoEncabezado(DemandaDespachoHeader encabezado)
        {
            DbParameter[] parameters ={
            new OAParameter
            {
                ParameterName = "@DOC_NUM",
                Value = encabezado.DOC_NUM
            }
            ,
                new OAParameter
            {
                ParameterName = "@CLIENT_CODE",
                Value = encabezado.CLIENT_CODE
            }
            ,
            new OAParameter
            {
                ParameterName = "@CODE_ROUTE",
                Value = encabezado.CODE_ROUTE
            }
            ,
            new OAParameter
            {
                ParameterName = "@CODE_SELLER",
                Value = encabezado.CODE_SELLER
            }
            ,
            new OAParameter
            {
                ParameterName = "@TOTAL_AMOUNT",
                Value = encabezado.TOTAL_AMOUNT
            }
            ,
            new OAParameter
            {
                ParameterName = "@SERIAL_NUMBER",
                Value = encabezado.SERIAL_NUMBER
            }
            ,new OAParameter
            {
                ParameterName = "@DOC_NUM_SEQUENCE",
                Value = encabezado.DOC_NUM_SEQUENCE
            }
            ,new OAParameter
            {
                ParameterName = "@EXTERNAL_SOURCE_ID",
                Value = encabezado.EXTERNAL_SOURCE_ID
            }
            ,new OAParameter
            {
                ParameterName = "@IS_FROM_ERP",
                Value = encabezado.IS_FROM_ERP
            }
            ,new OAParameter
            {
                ParameterName = "@IS_FROM_SONDA",
                Value = encabezado.IS_FROM_SONDA
            }
            ,new OAParameter
            {
                ParameterName = "@LAST_UPDATE_BY",
                Value = encabezado.LAST_UPDATE_BY
            }
            ,new OAParameter
            {
                ParameterName = "@WAVE_PICKING_ID",
                Value = encabezado.WAVE_PICKING_ID
            }
            ,new OAParameter
            {
                ParameterName = "@CODE_WAREHOUSE",
                Value = encabezado.CODE_WAREHOUSE
            }
            ,new OAParameter
            {
                ParameterName = "@IS_COMPLETED",
                Value = encabezado.IS_COMPLETED
            }
            ,new OAParameter
            {
                ParameterName = "@CUSTOMER_NAME",
                Value = encabezado.CUSTOMER_NAME
            }
            ,new OAParameter
            {
                ParameterName = "@DOC_ENTRY",
                Value = encabezado.DOC_ENTRY
            }
            ,new OAParameter
            {
                ParameterName = "@IS_CONSOLIDATED",
                Value = encabezado.IS_CONSOLIDATED
            }
            ,new OAParameter
            {
                ParameterName = "@PRIORITY",
                Value = encabezado.PRIORITY
            }
            ,new OAParameter
            {
                ParameterName = "@OWNER",
                Value = encabezado.OWNER
            }
            ,new OAParameter
            {
                ParameterName = "@CLIENT_OWNER",
                Value = encabezado.CLIENT_OWNER
            }
            ,new OAParameter
            {
                ParameterName = "@SELLER_OWNER",
                Value = encabezado.SELLER_OWNER
            }
            ,new OAParameter
            {
                ParameterName = "@MASTER_ID_SELLER",
                Value = encabezado.MASTER_ID_SELLER
            }
            ,new OAParameter
            {
                ParameterName = "@SOURCE_TYPE",
                Value = encabezado.SOURCE_TYPE
            }
            ,new OAParameter
            {
                ParameterName = "@DEMAND_TYPE",
                Value = encabezado.DEMAND_TYPE
            }
            ,new OAParameter
            {
                ParameterName = "@WAREHOUSE_FROM",
                Value = encabezado.WAREHOUSE_FROM
            }
            ,new OAParameter
            {
                ParameterName = "@WAREHOUSE_TO",
                Value = encabezado.WAREHOUSE_TO
            }
            ,new OAParameter
            {
                ParameterName = "@DELIVERY_DATE",
                Value = encabezado.DELIVERY_DATE
            },new OAParameter
            {
                ParameterName = "@ADDRESS_CUSTOMER",
                Value = encabezado.ADDRESS_CUSTOMER
            }
            ,new OAParameter
            {
                ParameterName = "@STATE_CODE",
                Value = encabezado.STATE_CODE
            }
            ,new OAParameter
            {
                ParameterName = "@DISCOUNT",
                Value = encabezado.DISCOUNT
            }
            ,new OAParameter
            {
                ParameterName = "@TYPE_DEMAND_CODE",
                Value = encabezado.TYPE_DEMAND_CODE
            }
            ,new OAParameter
            {
                ParameterName = "@TYPE_DEMAND_NAME",
                Value = encabezado.TYPE_DEMAND_NAME
            }
            };
            var op = BaseDeDatosServicio.ExecuteQuery<Operacion>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_INSERT_NEXT_DEMAND_PICKING_HEADER", CommandType.StoredProcedure, false, parameters)[0];
            return op;
        }

        public IList<Picking> ConsultarPickingEncabezadosFinalizados(ManifiestoArgumento consulta)
        {
            DbParameter[] parameters =
           {
                new OAParameter
                {
                    ParameterName = "@INITIAL_DATE",
                    Value = consulta.FechaInicial
                },
                 new OAParameter
                {
                    ParameterName = "@END_DATE",
                    Value = consulta.FechaFinal
                }
                 , new OAParameter
                {
                    ParameterName = "@WAREHOUSE",
                    Value = consulta.Bodegas
                }
                 , new OAParameter
                {
                    ParameterName = "@CODE_ROUTE",
                    Value = consulta.Rutas
                }
                 , new OAParameter
                {
                    ParameterName = "@MANIFEST_TYPE",
                    Value = consulta.Tipo
                }
            };
            return BaseDeDatosServicio.ExecuteQuery<Picking>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_COMPLETED_PICKING_HEADER", CommandType.StoredProcedure, parameters);
        }

        public IList<PickingDetalle> ObtenerPickingDetalle(string encabezados)
        {
            DbParameter[] parameters =
            {
                new OAParameter
                {
                    ParameterName = "@PICKING_HEADER_ID",
                    Value = encabezados
                }
            };
            return BaseDeDatosServicio.ExecuteQuery<PickingDetalle>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_PICKING_DETAIL", CommandType.StoredProcedure, parameters);
        }

        public Operacion InsertarTareaLineaPicking(int olaDePicking, bool esConsolidado, string usuario, string lineaDePicking)
        {
            DbParameter[] parameters =
            {
                new OAParameter
                {
                    ParameterName = "@WAVE_PICKING_ID",
                    Value = olaDePicking
                },
                new OAParameter
                {
                    ParameterName = "@IS_CONSOLIDATED",
                    Value = esConsolidado ? 1: 0
                },
                new OAParameter
                {
                    ParameterName = "@LOGIN",
                    Value = usuario
                },
                new OAParameter
                {
                    ParameterName = "@PICKING_LINE_ID",
                    Value = lineaDePicking
                }
            };
            return BaseDeDatosServicio.ExecuteQuery<Operacion>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_INSERT_PICKING_LINE_TASK"
                , CommandType.StoredProcedure, false, parameters)?.FirstOrDefault();
        }

        public Operacion ColocaIdDeIndcuccionATareaDeLineaDePicking(string documento, int idDeInduccion)
        {
            DbParameter[] parameters =
            {
                new OAParameter
                {
                    ParameterName = "@ERP_DOC",
                    Value = documento
                },
                new OAParameter
                {
                    ParameterName = "@INDUCTION_ID",
                    Value = idDeInduccion
                }
            };
            return BaseDeDatosServicio.ExecuteQuery<Operacion>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_SET_INDUCTION_ID_TO_DISTRIBUTED_TASK", CommandType.StoredProcedure, false, parameters).FirstOrDefault();
        }


        public IList<ReportePicking> ObtenerReportePicking(PickingArgumento argumento)
        {
            DbParameter[] parameters =
                               {
                    new OAParameter
                    {
                        ParameterName = "@START_DATE",
                        Value = argumento.FechaInicial
                    },
                    new OAParameter
                    {
                        ParameterName = "@END_DATE",
                        Value = argumento.FechaFinal
                    }
                };
            return BaseDeDatosServicio.ExecuteQuery<ReportePicking>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_PICKING_REPORT", CommandType.StoredProcedure, true, parameters).ToList();
        }

        public IList<InventarioParaPickingPorEstado> ObtenerInvnentarioPraPickingPorEstado(PickingArgumento argumento)
        {
            DbParameter[] parameters =
                               {
                    new OAParameter
                    {
                        ParameterName = "@XML",
                        Value = argumento.Xml
                    },
                    new OAParameter
                    {
                        ParameterName = "@CODE_WAREHOUSE",
                        Value = argumento.CodigoBodega
                    },
                    new OAParameter
                    {
                        ParameterName = "@PROJECT_ID",
                        Value =argumento.Proyecto.ID
                    }
                };
            
            return BaseDeDatosServicio.ExecuteQuery<InventarioParaPickingPorEstado>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_INVENTORY_FOR_PICKING_BY_STATUS_MATERIAL", CommandType.StoredProcedure, parameters).ToList();
        }
    }
}
