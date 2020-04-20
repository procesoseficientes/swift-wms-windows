using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Modelo.Servicios;
using MobilityScm.Utilerias;

namespace MobilityScm.Modelo.PruebaUnitaria.Servicios
{
    [TestClass]
    public class PoligonoPrueba
    {
        #region Configuracion

        public PoligonoPrueba()
        {
            ConfiguracionConexion conexion = new ConfiguracionConexion();
            Mvx.Ioc.RegisterType<IBaseDeDatosServicio, BaseDeDatosServicio>();
            Mvx.Ioc.RegisterSingleton<IConfiguracionDeConexion, ConfiguracionConexion>(conexion);
            Mvx.Ioc.Resolve<IConfiguracionDeConexion>();
            Mvx.Ioc.RegisterType<IPoligonoServicio, PoligonoServicio>();
            PoligonoServicio = Mvx.Ioc.Resolve<IPoligonoServicio>();
        }

        public IPoligonoServicio PoligonoServicio { get; set; }

        #endregion


        [TestMethod]
        public void ObtenerPoligonosDeDistribucionPorBodega()
        {
            var resultado = PoligonoServicio.ObtenerPoligonosDeDistribucionPorBodega(new OrdenDeVentaArgumento()
            {
                CodigoBodega = "BODEGA_01"
            });
            Assert.IsTrue(resultado.Count > 0);
        }
    }
}
