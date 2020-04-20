using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Modelo.Servicios;
using MobilityScm.Utilerias;

namespace MobilityScm.Modelo.PruebaUnitaria.Servicios
{
    [TestClass]
    public class CumplimientoDeEntregaPrueba
    {
        #region Configuración

        public ICumplimientoDeEntregaServicio CumplimientoDeEntregaServicio { get; set; }

        public CumplimientoDeEntregaPrueba()
        {
            ConfiguracionConexion conexion = new ConfiguracionConexion();
            Mvx.Ioc.RegisterType<IBaseDeDatosServicio, BaseDeDatosServicio>();
            Mvx.Ioc.RegisterSingleton<IConfiguracionDeConexion, ConfiguracionConexion>(conexion);
            Mvx.Ioc.Resolve<IConfiguracionDeConexion>();
            Mvx.Ioc.RegisterType<ICumplimientoDeEntregaServicio, CumplimientoDeEntregaServicio>();
            CumplimientoDeEntregaServicio = Mvx.Ioc.Resolve<ICumplimientoDeEntregaServicio>();
        }

        #endregion

        [TestMethod]
        public void ObtenerManifiestoSeleccionado()
        {
            var argumentoCumplimiento = new CumplimientoDeEntregaArgumento
            {
                CodigosDeVehiculos = "17|19|21|25",
                CodigosDePilotos = "20",
                FechaInicial =  new DateTime(2017, 10 ,19),
                FechaFinal= new DateTime(2017, 11, 19),
            };
            var resultadoManifiestos = CumplimientoDeEntregaServicio.ObtenerCumplimientoDeEntregas(argumentoCumplimiento);

            argumentoCumplimiento.CumplimientosDeEntregas = resultadoManifiestos;
            argumentoCumplimiento.IdManifiestoCarga = 2152;

            var resultadoManifiestoTareas =
                CumplimientoDeEntregaServicio.ObtenerTrackingManifiesto(argumentoCumplimiento);

            Assert.IsNotNull(resultadoManifiestoTareas);

        }
    }
}
