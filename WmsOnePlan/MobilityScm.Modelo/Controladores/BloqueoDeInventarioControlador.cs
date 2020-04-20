using System;
using System.Linq;
using System.Xml.Linq;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Interfaces.Controladores;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Modelo.Tipos;
using MobilityScm.Modelo.Vistas;
using MobilityScm.Vertical.Entidades;
using MobilityScm.Vertical.Servicios;

namespace MobilityScm.Modelo.Controladores
{
    public class BloqueoDeInventarioControlador : IBloqueoDeInventarioControlador
    {
        private readonly IBloqueoDeInventarioVista _vista;

        public IInventarioServicio InventarioServicio { get; set; }

        public IConfiguracionServicio ConfiguracionServicio { get; set; }

        public IInteraccionConUsuarioServicio InteraccionConUsuarioServicio { get; set; }

        public BloqueoDeInventarioControlador(IBloqueoDeInventarioVista vista)
        {
            _vista = vista;
            SuscribirEventos();
        }

        private void SuscribirEventos()
        {
            _vista.UsuarioDeseaObtenerInventario += _vista_UsuarioDeseaObtenerInventario;
            _vista.UsuarioDeseaCambiarElEstadoDelInventario += _vista_UsuarioDeseaCambiarElEstadoDelInventario;
            _vista.UsuarioDeseaObtenerEstadosDeMaterial += _vista_UsuairoDeseaObtenerEstadosDeMaterial;
            _vista.VistaCargandosePorPrimeraVez += _vista_VistaCargandosePorPrimeraVez;
        }

        private void _vista_UsuairoDeseaObtenerEstadosDeMaterial(object sender, InventarioArgumento e)
        {
            try
            {
                ObtenerEstadosDeMaterial();
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void _vista_VistaCargandosePorPrimeraVez(object sender, EventArgs e)
        {
            try
            {
                _vista.Usuario = InteraccionConUsuarioServicio.ObtenerUsuario();
                _vista.Inventario = InventarioServicio.ObtenerInventario(new InventarioArgumento { UsuarioId = _vista.Usuario });
                ObtenerEstadosDeMaterial();
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaCambiarElEstadoDelInventario(object sender, InventarioArgumento e)
        {
            try
            {
                var op = InventarioServicio.ActualizarEstadoDelMaterialPorLicencia(new InventarioArgumento
                {
                    UsuarioId = _vista.Usuario
                    ,
                    XmlDeLicencias = ObtenerXmlDeLicencias()
                });
                if (op.Resultado == ResultadoOperacionTipo.Exito)
                {
                    _vista.Inventario = InventarioServicio.ObtenerInventario(new InventarioArgumento { UsuarioId = _vista.Usuario });
                }
                else
                {
                    InteraccionConUsuarioServicio.Mensaje(op.Mensaje);
                }
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }
        private string ObtenerXmlDeLicencias()
        {
            var documentoXml = new XDocument(new XDeclaration("1.0", "iso-8859-1", null));
            var nodoRaiz = new XElement("ArrayOfInventario");
            documentoXml.Add(nodoRaiz);


            _vista.Inventario.Where(i => !string.IsNullOrEmpty(i.STATUS_CODE_NEW)).ToList().ForEach(i =>
            {
                var nodoInventario = new XElement("Inventario");
                nodoInventario.Add(new XElement("LICENSE_ID", i.LICENSE_ID));
                nodoInventario.Add(new XElement("MATERIAL_ID", i.MATERIAL_ID));
                nodoInventario.Add(new XElement("STATUS_CODE", i.STATUS_CODE_NEW));
                nodoRaiz.Add(nodoInventario);
            });
            return documentoXml.ToString();
                
        }
        private void _vista_UsuarioDeseaObtenerInventario(object sender, InventarioArgumento e)
        {
            try
            {
                _vista.Inventario = InventarioServicio.ObtenerInventario(new InventarioArgumento { UsuarioId = _vista.Usuario });
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void ObtenerEstadosDeMaterial()
        {
            var listaDeEstados = ConfiguracionServicio.ObtenerConfiguracionesGrupoYTipo(new Entidades.Configuracion
            {
                PARAM_TYPE = "ESTADO",
                PARAM_GROUP = "ESTADOS"
            });

            listaDeEstados.ToList().ForEach(e =>
            {
                e.SPARE1 = AplicaPropiedadDelEstado(e.SPARE1) ? "SI" : "NO";
                e.SPARE2 = AplicaPropiedadDelEstado(e.SPARE2) ? "SI" : "NO";
            });

            _vista.EstadosDeMaterial = listaDeEstados;
        }

        private static bool AplicaPropiedadDelEstado(string valor)
        {
            return (valor.Equals("1") || valor.ToUpper().Equals("SI"));
        }
    }
}
