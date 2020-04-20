using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Modelo.Tipos;
using MobilityScm.Vertical.Entidades;
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;
using MobilityScm.Utilerias;
using Telerik.OpenAccess.Data.Common;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Controladores;
using MobilityScm.Modelo.Estados;

namespace MobilityScm.Modelo.Servicios
{
    public class DemandaDeDespachoServicio : IDemandaDeDespachoServicio
    {
        public IBaseDeDatosServicio BaseDeDatosServicio { get; set; }

        public DemandaDeDespachoServicio(IBaseDeDatosServicio baseDeDatosServicio)
        {
            BaseDeDatosServicio = baseDeDatosServicio;
        }


        public Operacion AjustarInventarioDeOrdenDeVenta(ref List<OrdenDeVentaEncabezado> ordenDeVentaEncabezados, ref List<OrdenDeVentaDetalle> ordenDeVentaDetalles, IList<Sku> skus, ref List<MaterialConTonoYCalibre> listaDeMaterialesConTonoOCalibre, TipoDeInventario tipoInventario, bool despachoConEstadoDeMaterial)
        {
            try
            {
                var listaEncabezados = ordenDeVentaEncabezados;
                var listaDetalles = ordenDeVentaDetalles;
                listaDetalles = listaDetalles.OrderByDescending(d => d.fechaModificacion).ToList();
                foreach (var det in listaDetalles)
                {
                    det.AdvertenciaFaltaInventario = 0;
                    det.TONE = (string.IsNullOrEmpty(det.TONE)) ? string.Empty : det.TONE;
                    det.CALIBER = (string.IsNullOrEmpty(det.CALIBER)) ? string.Empty : det.CALIBER;
                }

                if (tipoInventario == TipoDeInventario.General)
                {
                    foreach (var sku in skus)
                    {
                        var disponible = (decimal)sku.QTY;
                        listaDetalles.Where(d => d.SKU == sku.MATERIAL_ID && (!despachoConEstadoDeMaterial || d.STATUS_CODE == sku.STATUS_CODE)).ToList().ForEach(det =>
                        {
                            det.AdvertenciaFaltaInventario = det.QTY <= disponible ? 0 : 1;
                            disponible = disponible - Convert.ToInt32(det.QTY);
                        });
                    }
                }

                //------Ajustar Inventario para material con tono o calibre----

                var listaMaterialesConTonoOCalibre = listaDeMaterialesConTonoOCalibre;
                listaMaterialesConTonoOCalibre = listaMaterialesConTonoOCalibre.OrderBy(m => m.MATERIAL_ID).ThenByDescending(m => m.QTY_AVAILABLE).ToList();



                listaMaterialesConTonoOCalibre.ForEach(materialConTonoYCalibre =>
                {
                    listaDetalles.Where(d => d.SKU == materialConTonoYCalibre.MATERIAL_ID).ToList().ForEach(det =>
                   {
                       materialConTonoYCalibre.QTY_ORDER += det.QTY;
                       materialConTonoYCalibre.TONE = string.IsNullOrEmpty(materialConTonoYCalibre.TONE) ? "" : materialConTonoYCalibre.TONE;
                       materialConTonoYCalibre.CALIBER = string.IsNullOrEmpty(materialConTonoYCalibre.CALIBER) ? "" : materialConTonoYCalibre.CALIBER;

                       if (det.TONE.Equals(materialConTonoYCalibre.TONE) && det.CALIBER.Equals(materialConTonoYCalibre.CALIBER))
                       {
                           det.AdvertenciaFaltaInventario = det.QTY <= materialConTonoYCalibre.QTY ? 0 : 1;
                           materialConTonoYCalibre.QTY = materialConTonoYCalibre.QTY - det.QTY;
                           det.AVAILABLE_QTY = materialConTonoYCalibre.QTY > 0 ? materialConTonoYCalibre.QTY : 0;
                       }
                       else if (DetalleNoTieneTonoYCalibre(det))
                       {
                           det.AdvertenciaFaltaInventario = det.QTY == 0 ? 0 : 1;
                       }
                   });

                });


                //------Fin Ajustar Inventario para material con tono o calibre----

                foreach (var encabezado in listaEncabezados)
                {
                    encabezado.AdvertenciaFaltaInventario = 0;
                }

                listaEncabezados.Where(e =>
                        listaDetalles.ToList().Exists(d =>
                                    d.SALES_ORDER_ID == e.SALES_ORDER_ID &&
                                    d.EXTERNAL_SOURCE_ID == e.EXTERNAL_SOURCE_ID &&
                                    d.AdvertenciaFaltaInventario == 1 &&
                                    d.SOURCE.ToUpper() == e.OWNER.ToUpper())).ToList().ForEach(
                    en =>
                    {
                        en.AdvertenciaFaltaInventario = 1;
                    });



                ordenDeVentaDetalles = listaDetalles;
                ordenDeVentaEncabezados = listaEncabezados;

                return new Operacion
                {
                    Codigo = 0,
                    Resultado = ResultadoOperacionTipo.Exito
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
        private bool DetalleNoTieneTonoYCalibre(OrdenDeVentaDetalle detetalle)
        {
            return string.IsNullOrEmpty(detetalle.TONE) && string.IsNullOrEmpty(detetalle.CALIBER);
        }

        public IList<VehiculoManifiesto> ProcesarDemandaParaVehiculos(ref PickingArgumento argumento)
        {
            if (argumento.Encabezados == null || argumento.Vehiculos == null) return argumento.Vehiculos;
            var pedidosOrdenados = argumento.PrioridadOrden == PrioridadVehiculos.Volumen
                ? argumento.Encabezados.OrderByDescending(e => e.ORDER_VOLUME).ThenByDescending(e => e.ORDER_WEIGHT).ToList()
                : argumento.Encabezados.OrderByDescending(e => e.ORDER_WEIGHT).ThenByDescending(e => e.ORDER_VOLUME).ToList();

            foreach (var vehiculo in from v in argumento.Vehiculos
                                     orderby v.PRIORITY ascending
                                     select v)
            {
                vehiculo.Ordenes.Clear();
                if (pedidosOrdenados.Count <= 0) continue;
                var pesoDisponible = vehiculo.ORIGINAL_AVAILABLE_WEIGHT;
                var volumenDisponible = vehiculo.ORIGINAL_AVAILABLE_VOLUME;

                vehiculo.USED_WEIGHT = vehiculo.ORIGINAL_USED_WEIGHT;
                vehiculo.USED_VOLUME = vehiculo.ORIGINAL_USED_VOLUME;

                foreach (var pedido in pedidosOrdenados)
                {
                    if (pesoDisponible < pedido.ORDER_WEIGHT || volumenDisponible < pedido.ORDER_VOLUME) continue;
                    pesoDisponible -= pedido.ORDER_WEIGHT;
                    volumenDisponible -= pedido.ORDER_VOLUME;

                    vehiculo.USED_WEIGHT += pedido.ORDER_WEIGHT;
                    vehiculo.USED_VOLUME += pedido.ORDER_VOLUME;

                    vehiculo.Ordenes.Add(pedido);
                }

                vehiculo.AVAILABLE_WEIGHT = pesoDisponible;
                vehiculo.AVAILABLE_VOLUME = volumenDisponible;

                pedidosOrdenados.RemoveAll(p => vehiculo.Ordenes.Contains(p));
            }

            foreach (var v in from veh in argumento.Vehiculos
                              where veh.IS_OWN == (int)Tipos.TipoDeVehiculo.SinVehiculo
                              select veh)
                v.Ordenes = pedidosOrdenados;

            argumento.Encabezados = pedidosOrdenados;
            return argumento.Vehiculos;
        }

        public IList<VehiculoManifiesto> AjustarPrioridadVehiculos(PickingArgumento argumento)
        {
            var vehiculos = argumento.Vehiculos;
            var vehiculo = argumento.Vehiculo;
            var prioridadNueva = argumento.PrioridadNueva;

            if (prioridadNueva == vehiculo.PRIORITY) return vehiculos.OrderBy(v => v.PRIORITY).ToList();
            if (prioridadNueva < vehiculo.PRIORITY) // PRIORIDAD NUEVA ES MENOR A LA ACTUAL
            {
                foreach (var v in from veh in vehiculos
                                  where veh.PRIORITY >= argumento.PrioridadNueva && veh.PRIORITY < vehiculo.PRIORITY // ACTUALIZA LOS QUE TIENEN LA PRIORIDAD MENOR A LA PRIORIDAD ACTUAL
                                  select veh)
                {
                    v.PRIORITY++;
                }

                foreach (var v in from veh in vehiculos
                                  where veh.VEHICLE_CODE == vehiculo.VEHICLE_CODE // ACTUALIZA EL REGISTRO MODIFICANDOSE
                                  select veh)
                    v.PRIORITY = prioridadNueva;
            }
            else // PRIORIDAD NUEVA ES MAYOR A LA ACTUAL
            {
                foreach (var v in from veh in vehiculos
                                  where veh.PRIORITY > vehiculo.PRIORITY && veh.PRIORITY <= argumento.PrioridadNueva // ACTUALIZA AQUELLOS CUYA PRIORIDAD SEA MENOR A LA NUEVA Y MAYOR A LA VIEJA
                                  select veh)
                {
                    v.PRIORITY--;
                }

                foreach (var v in from veh in vehiculos
                                  where veh.VEHICLE_CODE == vehiculo.VEHICLE_CODE // ACTUALIZA EL REGISTRO MODIFICANDOSE
                                  select veh)
                    v.PRIORITY = prioridadNueva;
            }

            return vehiculos.OrderBy(v => v.PRIORITY).ToList();
        }

        private VehiculoManifiesto ObtenerVehiculoSinVehiculo()
        {
            return new VehiculoManifiesto()
            {
                AVAILABLE_VOLUME = 0,
                AVAILABLE_WEIGHT = 0,
                FILL_RATE = 0,
                IS_OWN = 3,
                MAX_VOLUME = 0,
                MAX_WEIGHT = 0,
                Ordenes = new List<OrdenDeVentaEncabezado>(),
                ORIGINAL_USED_VOLUME = 0,
                ORIGINAL_USED_WEIGHT = 0,
                ORIGINAL_AVAILABLE_VOLUME = 0,
                ORIGINAL_AVAILABLE_WEIGHT = 0,
                PRIORITY = 9999,
                VEHICLE_CODE = -1,
                STATUS = "SIN_VEHICULO",
                VEHICLE = "SIN VEHICULO",
                USED_VOLUME = 0,
                USED_WEIGHT = 0,
                PLATE_NUMBER = string.Empty,
                RATING = 0,
                TRANSPORT_COMPANY_CODE = 0,
                TRANSPORT_COMPANY_NAME = string.Empty
            };
        }

        public IList<PedidosPorVendedor> ConsultaReportePedidoPorVendedor(ConsultaArgumento argumento)
        {
            DbParameter[] parameters =
          {
               new OAParameter
               {
                   ParameterName = "@START_DATETIME",
                   Value = argumento.FechaInicial
               }
               , new OAParameter
               {
                   ParameterName = "@END_DATETIME",
                   Value = argumento.FechaFinal
               }
               , new OAParameter
               {
                   ParameterName = "@CODE_WAREHOUSE",
                   Value = argumento.CodigoBodega
               }
               , new OAParameter
               {
                   ParameterName = "@LOGIN",
                   Value = argumento.Login
               }
           };
            return BaseDeDatosServicio.ExecuteQuery<PedidosPorVendedor>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_SALES_ORDER_BY_SELLER_REPORT", CommandType.StoredProcedure, parameters);
        }

        [SuppressMessage("ReSharper", "PossibleInvalidOperationException")]
        public IList<ReportePedidosPorVendedor> GenerarReportePedidosPorVendedor(ConsultaArgumento argumento)
        {
            var pedidos = ConsultaReportePedidoPorVendedor(argumento);
            var olasDePedidos = ObtenerPedidosPorOla(pedidos);

            var reportePedidosPorVendedor = new List<ReportePedidosPorVendedor>();
            var vendedores =
                pedidos.GroupBy(p => new { p.SELLER_CODE, p.SELLER_NAME }).Select(p => new PedidosPorVendedor()
                {
                    SELLER_CODE = p.Key.SELLER_CODE,
                    SELLER_NAME = p.Key.SELLER_NAME
                });

            foreach (var v in vendedores)
            {
                var pedidosDeVendedor = pedidos.Where(p => p.SELLER_CODE == v.SELLER_CODE && p.SELLER_NAME == v.SELLER_NAME).ToList();
                var sum = pedidosDeVendedor.Select(p => p.DOC_TOTAL).Sum() == null ? 0 : (decimal)pedidosDeVendedor.Select(p => p.DOC_TOTAL).Sum();

                var olasDeVendedor = ObtenerPedidosPorOla(pedidosDeVendedor);



                var vendedor = new ReportePedidosPorVendedor()
                {
                    SELLER_NAME = v.SELLER_NAME,
                    SELLER_CODE = v.SELLER_CODE,
                    QTY_CUSTOMERS = pedidosDeVendedor.Select(p => p.CLIENT_CODE).Distinct().Count(),
                    QTY_SALES_ORDERS = pedidosDeVendedor.Count(),
                    TOTAL_SALES_ORDERS = sum,
                    QTY_PENDING_TO_ASSIGN = pedidosDeVendedor.Count(p => p.IN_PICKING_DEMAND == 0),
                    QTY_PICKED = pedidosDeVendedor.Count(p => p.IN_PICKING_DEMAND == 1),
                    QTY_PENDING_TO_DISPATCH = pedidosDeVendedor.Count(p => p.IN_PICKING_DEMAND == 1 && p.TASK_IS_COMPLETED == 0),
                    QTY_DISPATCHED = pedidosDeVendedor.Count(p => p.IN_PICKING_DEMAND == 1 && p.TASK_IS_COMPLETED == 1),
                    TOTAL_TIME_SPENT = CalcularTiempoDePorVendedor(olasDePedidos, olasDeVendedor)
                };

                reportePedidosPorVendedor.Add(vendedor);
            }


            return reportePedidosPorVendedor;
        }

        [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
        private IList<PedidosPorOla> ObtenerPedidosPorOla(IList<PedidosPorVendedor> pedidos)
        {
            var pedidosPorOla = new List<PedidosPorOla>();
            var porOla = pedidos.Where(p => p.WAVE_PICKING_ID > 0).GroupBy(p => new { p.WAVE_PICKING_ID }).Select(p => p.Key.WAVE_PICKING_ID);

            foreach (var ola in porOla)
            {
                var pedido = pedidos.Where(p => p.WAVE_PICKING_ID == ola).ToList();
                var isCompleted = pedido.OrderBy(p => p.TASK_IS_COMPLETED).FirstOrDefault().TASK_IS_COMPLETED;

                var fechaAceptada = pedido.OrderBy(p => p.TASK_ACCEPTED_DATE).FirstOrDefault().TASK_ACCEPTED_DATE;

                var fechaCompletada = isCompleted == (int)SiNo.Si
                    ? pedido.OrderByDescending(p => p.TASK_ACCEPTED_DATE).FirstOrDefault().TASK_COMPLETED_DATE
                    : DateTime.MaxValue;

                var tiempoTomado = isCompleted == (int)SiNo.Si
                    ? fechaCompletada.Subtract(fechaAceptada)
                    : new TimeSpan(0);

                var ppo = new PedidosPorOla()
                {
                    OlaDePicking = ola
                    ,
                    Aceptada = fechaAceptada
                    ,
                    Terminada = fechaCompletada
                    ,
                    CantidadPedidos = pedido.Count
                    ,
                    TiempoTomado = tiempoTomado
                };

                pedidosPorOla.Add(ppo);
            }
            return pedidosPorOla;
        }

        [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
        private TimeSpan CalcularTiempoDePorVendedor(IList<PedidosPorOla> olaCompleta, IList<PedidosPorOla> olaPorVendedor)
        {
            if (olaCompleta.Count <= 0 || olaPorVendedor.Count <= 0) return new TimeSpan(0);
            var timeSpan = new TimeSpan();

            var olasDeVendedor = olaPorVendedor.Select(o => o.OlaDePicking).Distinct();

            foreach (var ola in olasDeVendedor)
            {
                var oCompleta = olaCompleta.FirstOrDefault(o => o.OlaDePicking == ola);
                var oVendedor = olaPorVendedor.FirstOrDefault(o => o.OlaDePicking == ola);

                var ticksTiempoCompleta = oCompleta.TiempoTomado.Ticks;
                var pesoVendedor = (decimal)oVendedor.CantidadPedidos / oCompleta.CantidadPedidos;

                var ticksVendedor = ticksTiempoCompleta * pesoVendedor;

                timeSpan += new TimeSpan((long)ticksVendedor);
            }

            return timeSpan;
        }

        public IList<DemandaDespachoHeader> ObtnerDemandasEncabezadosParaPaseDeSalida(PaseDeSalidaArgumento argumento)
        {
            DbParameter[] parameters =
          {
               new OAParameter
               {
                   ParameterName = "@INITIAL_DATE",
                   Value = argumento.FechaInicio
               }
               , new OAParameter
               {
                   ParameterName = "@END_DATE",
                   Value = argumento.FechaFin
               }
               , new OAParameter
               {
                   ParameterName = "@CODE_WAREHOUSE",
                   Value = argumento.CODE_WAREHOUSE
               }
               , new OAParameter
               {
                   ParameterName = "@DEMAND_TYPE",
                   Value = argumento.DEMAND_TYPE
               }
           };
            return BaseDeDatosServicio.ExecuteQuery<DemandaDespachoHeader>(BaseDeDatosServicio.Esquema + ".[OP_WMS_SP_GET_DEMAND_HEADER_FOR_PASS]", CommandType.StoredProcedure, parameters);
        }

        public IList<DemandaDespachoDetalle> ObtnerDemandasDetallesParaPaseDeSalida(PaseDeSalidaArgumento argumento)
        {
            DbParameter[] parameters =
          {
               new OAParameter
               {
                   ParameterName = "@PICKING_DEMAND_HEADER_ID",
                   Value = argumento.PICKING_DEMAND_HEADER_ID
               }
               ,new OAParameter
               {
                   ParameterName = "@DEMAND_TYPE",
                   Value = argumento.DEMAND_TYPE
               }
           };
            return BaseDeDatosServicio.ExecuteQuery<DemandaDespachoDetalle>(BaseDeDatosServicio.Esquema + ".[OP_WMS_SP_GET_DEMAND_DETAIL_FOR_PASS]", CommandType.StoredProcedure, parameters);
        }

        public IList<OrdenDeVentaEncabezado> ObtenerOrdenesDeVentaPreparadaSonda(OrdenDeVentaArgumento ordenDeVentaArgumento)
        {
            DbParameter[] parameters =
            {
               new OAParameter
               {
                   ParameterName = "@START_DATETIME",
                   Value = ordenDeVentaArgumento.FechaInicio
               },
               new OAParameter
               {
                   ParameterName = "@END_DATETIME",
                   Value = ordenDeVentaArgumento.FechaFin
               },
               new OAParameter
               {
                   ParameterName = "@SOURCE_CODE_ROUTE",
                   Value = ordenDeVentaArgumento.CodigosFuenteRuta
               },
               new OAParameter
               {
                   ParameterName = "@CODE_ROUTE",
                   Value = ordenDeVentaArgumento.CodigosRuta
               },
               new OAParameter
               {
                   ParameterName = "@CODE_WAREHOUSE",
                   Value = ordenDeVentaArgumento.CodigoBodega
               }
           };
            return BaseDeDatosServicio.ExecuteQuery<OrdenDeVentaEncabezado>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_PREPARED_SALES_ORDER_TO_DISPATCH_SONDA", CommandType.StoredProcedure, parameters);
        }

        public IList<OrdenDeVentaEncabezado> ObtenerOrdenesDeVentaPreparadaErp(OrdenDeVentaArgumento ordenDeVentaArgumento)
        {
            DbParameter[] parameters =
            {
               new OAParameter
               {
                   ParameterName = "@START_DATETIME",
                   Value = ordenDeVentaArgumento.FechaInicio
               },
               new OAParameter
               {
                   ParameterName = "@END_DATETIME",
                   Value = ordenDeVentaArgumento.FechaFin
               },
               new OAParameter
               {
                   ParameterName = "@CLIENTS",
                   Value = ordenDeVentaArgumento.CodigosClientesErpCanalModerno
               },
               new OAParameter
               {
                   ParameterName = "@CODE_WAREHOUSE",
                   Value = ordenDeVentaArgumento.CodigoBodega
               }
           };
            return BaseDeDatosServicio.ExecuteQuery<OrdenDeVentaEncabezado>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_PREPARED_SALES_ORDER_TO_DISPATCH_ERP", CommandType.StoredProcedure, parameters);
        }

        public IList<OrdenDeVentaEncabezado> ObtenerSolicitudTransferenciaPreparadaErp(OrdenDeVentaArgumento ordenDeVentaArgumento)
        {
            DbParameter[] parameters =
            {
                new OAParameter
                {
                    ParameterName = "@CODE_WAREHOUSE",
                    Value = ordenDeVentaArgumento.CodigoBodega
                },
                new OAParameter
                {
                    ParameterName = "@START_DATETIME",
                    Value = ordenDeVentaArgumento.FechaInicio
                },
                new OAParameter
                {
                    ParameterName = "@END_DATETIME",
                    Value = ordenDeVentaArgumento.FechaFin
                }
            };
            return BaseDeDatosServicio.ExecuteQuery<OrdenDeVentaEncabezado>(
                BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_PREPARED_TRANSFER_REQUEST_TO_DISPATCH_ERP", CommandType.StoredProcedure,
                false, parameters).ToList();
        }

        public IList<OrdenDeVentaEncabezado> ObtenerSolicitudTransferenciaPreparadaSwift(OrdenDeVentaArgumento ordenDeVentaArgumento)
        {
            DbParameter[] parameters =
            {
                new OAParameter
                {
                    ParameterName = "@CODE_WAREHOUSE",
                    Value = ordenDeVentaArgumento.CodigoBodega
                },
                new OAParameter
                {
                    ParameterName = "@START_DATETIME",
                    Value = ordenDeVentaArgumento.FechaInicio
                },
                new OAParameter
                {
                    ParameterName = "@END_DATETIME",
                    Value = ordenDeVentaArgumento.FechaFin
                }
            };
            return BaseDeDatosServicio.ExecuteQuery<OrdenDeVentaEncabezado>(
                BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_PREPARED_TRANSFER_REQUEST_TO_DISPATCH_SWIFT", CommandType.StoredProcedure,
                false, parameters).ToList();
        }

        public IList<OrdenDeVentaDetalle> ObtenerOrdenVentaDetalleDeOrdenesPreparadas(OrdenDeVentaArgumento argumento)
        {
            DbParameter[] parameters =
            {
                new OAParameter
                {
                    ParameterName = "@PICKING_DEMAND_HEADERS",
                    Value = argumento.TextoEncabezados
                }
            };
            return BaseDeDatosServicio.ExecuteQuery<OrdenDeVentaDetalle>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_PREPARED_SALES_ORDER_TO_DISPATCH_DETAIL", CommandType.StoredProcedure, parameters);
        }

        public IList<Cliente> ObtenerClientesErpCanalModernoParaOrdenesDeVentaPreparadas(OrdenDeVentaArgumento argumento)
        {
            DbParameter[] parameters =
            {
                new OAParameter
                {
                    ParameterName = "@PICKING_DEMAND_HEADERS",
                    Value = argumento.TextoEncabezados
                }
            };
            return BaseDeDatosServicio.ExecuteQuery<Cliente>(BaseDeDatosServicio.Esquema + ".OP_WMS_GET_ERP_CLIENTS_FOR_PREPARED_SALES_ORDERS", CommandType.StoredProcedure, parameters);
        }

        public IList<OlaDePickingDeDemandaDespacho> ObtenerOlasDePickingPorDemandaDeDespacho(OlaDePickingDeDemandaDespachoArgumento argumento)
        {
            DbParameter[] parameters =
            {
                new OAParameter
                {
                    ParameterName = "@DATE",
                    Value = argumento.Fecha
                }
            };
            return BaseDeDatosServicio.ExecuteQuery<OlaDePickingDeDemandaDespacho>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_WAVE_PIKING_GENERATED_BY_DEMAND_DISPACHT", CommandType.StoredProcedure, parameters);
        }
    }

}
