using System;
using System.Collections.Generic;
using FizzWare.NBuilder;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Modelo.Servicios;
using MobilityScm.Modelo.Tipos;
using MobilityScm.Utilerias;
using System.IO;
using System.Linq;

namespace MobilityScm.Modelo.PruebaUnitaria.Servicios
{
    [TestClass]
    public class DemandaDeDespachoPrueba
    {
        #region Configuracion

        public DemandaDeDespachoPrueba()
        {
            ConfiguracionConexion conexion = new ConfiguracionConexion();
            Mvx.Ioc.RegisterType<IBaseDeDatosServicio, BaseDeDatosServicio>();
            Mvx.Ioc.RegisterSingleton<IConfiguracionDeConexion, ConfiguracionConexion>(conexion);
            Mvx.Ioc.Resolve<IConfiguracionDeConexion>();
            Mvx.Ioc.RegisterType<IDemandaDeDespachoServicio, DemandaDeDespachoServicio>();
            DemandaDeDespachoServicio = Mvx.Ioc.Resolve<IDemandaDeDespachoServicio>();
        }

        public IDemandaDeDespachoServicio DemandaDeDespachoServicio { get; set; }

        #endregion

        #region Propiedades 
        private IList<VehiculoManifiesto> Vehiculos { get; set; }
        public IList<OrdenDeVentaEncabezado> Ordenes { get; set; }
        #endregion

        #region DataHelpers
        private void BuildData()
        {
            var generator = new Random();


            Vehiculos = new List<VehiculoManifiesto>();
            Ordenes = new List<OrdenDeVentaEncabezado>();

            Ordenes = Builder<OrdenDeVentaEncabezado>.CreateListOfSize(150).All().Build();

            foreach (var orden in Ordenes)
            {
                orden.ORDER_VOLUME = (decimal)generator.NextDouble() * 500;
                orden.ORDER_WEIGHT = (decimal)generator.NextDouble() * 100;
            }

            Vehiculos = Builder<VehiculoManifiesto>.CreateListOfSize(25).All().With(v => v.FILL_RATE > 90 && v.FILL_RATE < 101).Build();

            foreach (var vehiculo in Vehiculos)
            {
                vehiculo.AVAILABLE_VOLUME = (decimal)generator.NextDouble() * 25000;
                vehiculo.AVAILABLE_WEIGHT = (decimal)generator.NextDouble() * 1500;
            }

            using (var sw = File.CreateText("D:\\CSV\\vehiculos.csv"))
            {
                foreach (var v in Vehiculos) {
                    sw.WriteLine(v.VEHICLE_CODE + "," + v.AVAILABLE_WEIGHT + "," + v.AVAILABLE_VOLUME);
                }
            }

            using (var sw = File.CreateText("D:\\CSV\\ordenes.csv"))
            {
                foreach (var o in Ordenes)
                {
                    sw.WriteLine(o.SALES_ORDER_ID + "," + o.ORDER_WEIGHT + "," + o.ORDER_VOLUME);
                }
            }
        }
        #endregion
        

        [TestMethod]
        public void ProcesarDemandaParaVehiculos()
        {
            BuildData();
            Vehiculos.ToList().ForEach(x =>
            {
                
            });
            var argumento = new PickingArgumento
            {
                Encabezados = Ordenes,
                Vehiculos = Vehiculos,
                PrioridadOrden = PrioridadVehiculos.Peso
            };

            var resultado = DemandaDeDespachoServicio.ProcesarDemandaParaVehiculos(ref argumento);

            using (var sw = File.CreateText("D:\\CSV\\resultado.csv"))
            {
                foreach (var res in resultado)
                {
                    sw.WriteLine(res.VEHICLE + "," + res.MAX_WEIGHT + "," + res.MAX_VOLUME + "," + res.AVAILABLE_WEIGHT + "," + res.AVAILABLE_VOLUME );
                    foreach (var orden in res.Ordenes)
                    {
                        sw.WriteLine(",,,,," + orden.SALES_ORDER_ID + "," + orden.ORDER_WEIGHT + "," + orden.ORDER_VOLUME);
                    }
                    decimal totalVolumen = 0;
                    decimal totalPeso = 0;

                    res.Ordenes.ToList().ForEach(r => { totalVolumen += r.ORDER_VOLUME; totalPeso += r.ORDER_WEIGHT; });

                    sw.WriteLine(",,,,,,,," + totalPeso + "," + totalVolumen);
                }
            }

            using (var sw = File.CreateText("D:\\CSV\\ordenesSinVehiculo.csv"))
            {
                foreach (var o in argumento.Encabezados)
                {
                    sw.WriteLine(o.SALES_ORDER_ID + "," + o.ORDER_WEIGHT + "," + o.ORDER_VOLUME);
                }
            }

            Assert.IsTrue(resultado != null);
        }

        [TestMethod]
        public void AjustarPrioridadVehiculos()
        {
            BuildData();
            var argumento = new PickingArgumento()
            {
                Vehiculos = Vehiculos,
                PrioridadNueva = 22,
                Vehiculo = Vehiculos[7]
            };

            using (var sw = File.CreateText("D:\\CSV\\vehiculosSinOrdenar.csv"))
            {
                foreach (var r in Vehiculos)
                {
                    sw.WriteLine(r.VEHICLE_CODE + "," + r.VEHICLE + "," + r.PRIORITY);
                }
            }

            var resultado = DemandaDeDespachoServicio.AjustarPrioridadVehiculos(argumento);

            using (var sw = File.CreateText("D:\\CSV\\vehiculosOrdenados.csv"))
            {
                foreach (var r in resultado)
                {
                    sw.WriteLine(r.VEHICLE_CODE + "," + r.VEHICLE + "," + r.PRIORITY);
                }
            }

            Assert.IsTrue(resultado.Count > 0);
        }

        [TestMethod]
        public void GenerarReportePedidosPorVendedor()
        {
            var resultado = DemandaDeDespachoServicio.GenerarReportePedidosPorVendedor(new ConsultaArgumento()
            {
                FechaInicial = new DateTime(2017,8,1)
                ,FechaFinal = new DateTime(2017, 11, 17, 23, 59, 59)
                ,CodigoBodega = "BODEGA_01"
                ,Login = "ADMIN"
            });

            using (var sw = File.CreateText("D:\\CSV\\ReportePedidosPorVendedor.csv"))
            {
                foreach (var r in resultado)
                {
                    sw.WriteLine(r.SELLER_CODE + "," + r.SELLER_NAME + "," + r.QTY_SALES_ORDERS + "," + r.QTY_CUSTOMERS
                                 + "," + r.TOTAL_SALES_ORDERS + "," + r.QTY_PENDING_TO_ASSIGN + "," + r.QTY_PICKED + ","
                                 + r.QTY_PENDING_TO_DISPATCH + "," + r.QTY_DISPATCHED + "," + r.TOTAL_TIME_SPENT);
                }
            }

            Assert.IsTrue(resultado != null);
        }
    }
}
