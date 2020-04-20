using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Interfaces.Controladores;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Modelo.Servicios;
using MobilityScm.Modelo.Tipos;
using MobilityScm.Utilerias;
using MobilityScm.Vertical.Entidades;
using MobilityScm.Vertical.Servicios;

namespace MobilityScm.Modelo.PruebaUnitaria.Servicios
{
    [TestClass]
    public class ClasePrueba
    {
        #region Configuracion

        public ClasePrueba()
        {
            ConfiguracionConexion conexion = new ConfiguracionConexion();
            Mvx.Ioc.RegisterType<IBaseDeDatosServicio, BaseDeDatosServicio>();
            Mvx.Ioc.RegisterSingleton<IConfiguracionDeConexion, ConfiguracionConexion>(conexion);
            Mvx.Ioc.Resolve<IConfiguracionDeConexion>();
            Mvx.Ioc.RegisterType<IClaseServicio, ClaseServicio>();
            ClaseServicio = Mvx.Ioc.Resolve<IClaseServicio>();
        }

        public IClaseServicio ClaseServicio { get; set; }

        #endregion

        [TestMethod]
        public void ObtenerClases()
        {
            var resultado = ClaseServicio.ObtenerClases();
            Assert.IsTrue(resultado.Count > 0);
        }

        [TestMethod]
        public void ObtenerClase()
        {
            var resultado = ClaseServicio.ObtenerClasePorId(new Clase
            {
                CLASS_ID = 1

            });
            Assert.IsNotNull(resultado);
        }

        [TestMethod]
        public void AbcClase()
        {
            Clase objeto = CrearClase();

            objeto.CLASS_NAME = objeto.CLASS_DESCRIPTION + Utilerias.PruebaUnitaria.ObtenerCadenaAleartoria(5);
            var modificacion = ClaseServicio.ActualizarClase(objeto);
            if (modificacion.Resultado == ResultadoOperacionTipo.Exito)
            {
                var eliminacion = EliminarClase(objeto);
                Assert.IsTrue(eliminacion.Resultado == ResultadoOperacionTipo.Exito);
            }
            else
                throw new Exception(modificacion.Mensaje);
        }

        private Operacion EliminarClase(Clase objeto)
        {
            var eliminacion = ClaseServicio.EliminarClase(objeto);
            if (eliminacion.Resultado == ResultadoOperacionTipo.Exito)
            {
                return eliminacion;
            }
            else
                throw new Exception(eliminacion.Mensaje);
        }

        private Clase CrearClase()
        {
            var objeto = new Clase
            {
                CLASS_ID = 1
                ,
                CLASS_NAME = Utilerias.PruebaUnitaria.ObtenerCadenaAleartoria(25)
                ,
                CLASS_DESCRIPTION = Utilerias.PruebaUnitaria.ObtenerCadenaAleartoria(50)
                ,
                CLASS_TYPE = "Productos"
                ,
                CREATED_BY = "PABS"
                ,
                LAST_UPDATED_BY = "PABS"
                ,
                PRIORITY = 1
            };
            var creacion = ClaseServicio.CrearClase(objeto);

            if (creacion.Resultado == ResultadoOperacionTipo.Exito)
            {
                objeto.CLASS_ID = Convert.ToInt32(creacion.DbData);
            }
            else
            {
                throw new Exception(creacion.Mensaje);
            }
            return objeto;

        }

        [TestMethod]
        public void AsociacionClase()
        {

            var clase = CrearClase();
            var clases = ClaseServicio.ObtenerClasesNoAsociadas(clase);
            var argumento = new ClaseArgumento
            {
                Clase = clase
                ,
                Clases = clases.ToList(),
            };

            var asociar = ClaseServicio.AsociarClases(argumento);
            if (asociar.Resultado != ResultadoOperacionTipo.Exito)
            {
                throw new Exception(asociar.Mensaje);
            }

            var clasesAsociadas = ClaseServicio.ObtenerClasesAsociadas(clase);
            Assert.IsTrue(clasesAsociadas.Count > 0);

            var desasociar = ClaseServicio.DesasociarClases(argumento);
            if (desasociar.Resultado != ResultadoOperacionTipo.Exito)
            {
                throw new Exception(desasociar.Mensaje);
            }
            EliminarClase(clase);
        }

        [TestMethod]
        public void IngresoXML()
        {

            var lista = new List<Clase>
            {
                new Clase
                {
                    CLASS_ID = 1
                    ,
                    CLASS_NAME = Utilerias.PruebaUnitaria.ObtenerCadenaAleartoria(25)
                    ,
                    CLASS_DESCRIPTION = Utilerias.PruebaUnitaria.ObtenerCadenaAleartoria(50)
                    ,
                    CLASS_TYPE = "Productos"
                    ,
                    CREATED_BY = "PABS"
                    ,
                    LAST_UPDATED_BY = "PABS"
                    ,
                    PRIORITY = 1
                },
                new Clase
                {
                    CLASS_ID = 1
                    ,
                    CLASS_NAME = Utilerias.PruebaUnitaria.ObtenerCadenaAleartoria(25)
                    ,
                    CLASS_DESCRIPTION = Utilerias.PruebaUnitaria.ObtenerCadenaAleartoria(50)
                    ,
                    CLASS_TYPE = "Productos"
                    ,
                    CREATED_BY = "PABS"
                    ,
                    LAST_UPDATED_BY = "PABS"
                    ,
                    PRIORITY = 2
                }
            };

            var cargarExcel = ClaseServicio.CargarClasesPorXml(new ClaseArgumento
            {
                Clases = lista,
                Login = "PABS"
            });

            Assert.IsTrue(cargarExcel.Resultado == ResultadoOperacionTipo.Exito);

            var clasesCreadas = ClaseServicio.ObtenerClases().Where(x =>
                lista.Exists(y => y.CLASS_NAME == x.CLASS_NAME)
            ).ToList();
            if (clasesCreadas.Count <= 0)
            {
                throw new Exception("No se crearon las clases.");
            }

            foreach (var claseActual in clasesCreadas)
            {
                EliminarClase(claseActual);
            }

            Assert.IsNotNull(clasesCreadas);
        }
    }
}
