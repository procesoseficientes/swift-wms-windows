using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Modelo.Servicios;
using MobilityScm.Utilerias;

namespace MobilityScm.Modelo.PruebaUnitaria.Servicios
{
    [TestClass]
    public class LineaDePickingPrueba
    {
        #region Configuracion

        public LineaDePickingPrueba()
        {
            var conexion = new ConfiguracionConexion();
            Mvx.Ioc.RegisterType<IBaseDeDatosServicio, BaseDeDatosServicio>();
            Mvx.Ioc.RegisterSingleton<IConfiguracionDeConexion, ConfiguracionConexion>(conexion);
            Mvx.Ioc.Resolve<IConfiguracionDeConexion>();
            Mvx.Ioc.RegisterType<ILineaDePickingServicio, LineaDePickingServicio>();
            LineaDePickingServicio = Mvx.Ioc.Resolve<ILineaDePickingServicio>();
        }

        public ILineaDePickingServicio LineaDePickingServicio { get; set; }

        #endregion
        [TestMethod]
        public void ObtenerCajasPorCliente()
        {
            var resultado = LineaDePickingServicio.ObtenerCajasPorCliente(new ManifiestoArgumento()
            {
                IdManifiestoDeCarga = "5"
            });
            Assert.IsTrue(resultado.Count > 0);
        }
    }
}
