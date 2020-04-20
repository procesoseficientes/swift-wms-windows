using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Modelo.Servicios;
using MobilityScm.Utilerias;

namespace MobilityScm.Modelo.PruebaUnitaria.Servicios
{
    [TestClass]
    public class ParametroPrueba
    {
        #region Configuracion

        public ParametroPrueba()
        {
            ConfiguracionConexion conexion = new ConfiguracionConexion();
            Mvx.Ioc.RegisterType<IBaseDeDatosServicio, BaseDeDatosServicio>();
            Mvx.Ioc.RegisterSingleton<IConfiguracionDeConexion, ConfiguracionConexion>(conexion);
            Mvx.Ioc.Resolve<IConfiguracionDeConexion>();
            Mvx.Ioc.RegisterType<IParametroServicio, ParametroServicio>();
            ParametroServicio = Mvx.Ioc.Resolve<IParametroServicio>();
        }

        public IParametroServicio ParametroServicio { get; set; }

        #endregion

        [TestMethod]
        public void ObtenerParametro()
        {
            var resultado = ParametroServicio.ObtenerParametro(new ConsultaArgumento()
            {
                GrupoParametro = "NEXT"
                ,IdParametro = "HAS_NEXT"
            });
            Assert.IsTrue(resultado.Count > 0);
        }
    }
}
