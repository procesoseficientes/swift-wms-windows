using System;
using System.Linq;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Utilerias;
using MobilityScm.Modelo.Interfaces.Controladores;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Modelo.Tipos;
using MobilityScm.Modelo.Vistas;
using MobilityScm.Vertical.Servicios;
using MobilityScm.Modelo.Entidades;
using System.Collections.Generic;

namespace MobilityScm.Modelo.Controladores
{
    public class SugerenciaCompraControlador : ISugerenciaCompraControlador
    {
        private readonly ISugeridoCompraVista _vista;

        public IBodegaServicio BodegaServicio { get; set; }
        public IUbicacionServicio UbicacionServicio { get; set; }
        public IMaterialServicio MaterialServicio { get; set; }
        public IInventarioServicio InventarioServicio { get; set; }

        public IConfiguracionServicio ConfiguracionServicio { get; set; }
        public IInteraccionConUsuarioServicio InteraccionConUsuarioServicio { get; set; }

        public SugerenciaCompraControlador(ISugeridoCompraVista vista)
        {
            _vista = vista;
            SuscribirEventos();
        }

        private void SuscribirEventos()
        {
            _vista.UsuarioDeseaObtenerBodegas += _vista_UsuarioDeseaObtenerBodegas;
            _vista.UsuarioDeseaObtenerMateriales += _vista_UsuarioDeseaObtenerMateriales;
            _vista.UsuarioDeseaObtenerSugeridoCompra += _vista_UsuarioDeseaObtenerSugeridoCompra;
            _vista.VistaCargandosePorPrimeraVez += _vista_VistaCargandosePorPrimeraVez;
        }

        private void _vista_VistaCargandosePorPrimeraVez(object sender, EventArgs e)
        {
            try
            {
                _vista.Configuraciones = ConfiguracionServicio.ObtenerConfiguracionesGrupoYTipo(new Entidades.Configuracion
                {
                    PARAM_GROUP = Enums.GetStringValue(ParametrosGeneralesGrupo.InventarioInactivo)
                        ,
                    PARAM_TYPE = Enums.GetStringValue(ParametrosGeneralesTipo.Almacenamiento)
                });
                _vista_UsuarioDeseaObtenerBodegas(null, null);
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaObtenerSugeridoCompra(object sender, SugeridoCompraArgumento e)
        {
            try
            {
                var arg = new SugeridoCompraArgumento
                {
                    Login = InteraccionConUsuarioServicio.ObtenerUsuario()
                    ,
                    WarehouseXml = Xml.ConvertListToXml(_vista.Bodegas.Where(b => b.IS_SELECTED).ToList())
                    ,
                    MaterialXml = Xml.ConvertListToXml(_vista.Materiales.Where(m => m.IS_SELECTED).ToList())
                };

                _vista.SugeridoCompra = InventarioServicio.ObtenerSugeridoCompra(arg);
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaObtenerMateriales(object sender, SugeridoCompraArgumento e)
        {
            try
            {
                var arg = new InventarioInactivoArgumento
                {
                    Login = InteraccionConUsuarioServicio.ObtenerUsuario()
                    ,
                    WarehouseXml = Xml.ConvertListToXml(_vista.Bodegas.Where(b => b.IS_SELECTED).ToList())
                    ,
                    ZoneXml = Xml.ConvertListToXml(new List<Zona>())
                };

                var listaTemporal = _vista.Materiales.Where(z => z.IS_SELECTED).ToList();

                var listaResultado = MaterialServicio.ObtenerMaterialesPorBodegaYZona(arg);

                if (listaTemporal.Count > 0)
                {
                    foreach (var registro in listaResultado)
                    {
                        registro.IS_SELECTED = listaTemporal.Exists(lt => lt.IS_SELECTED && lt.MATERIAL_CODE == registro.MATERIAL_CODE);
                    }
                }

                _vista.Materiales = listaResultado;
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaObtenerBodegas(object sender, SugeridoCompraArgumento e)
        {
            try
            {
                var listaTemporal = _vista.Bodegas.Where(z => z.IS_SELECTED).ToList();

                var listaResultado = BodegaServicio.ObtenerBodegaAsignadaAUsuarioSugCompra(InteraccionConUsuarioServicio.ObtenerUsuario());

                if (listaTemporal.Count > 0)
                {
                    foreach (var registro in listaResultado)
                    {
                        registro.IS_SELECTED = listaTemporal.Exists(lt => lt.IS_SELECTED && lt.WAREHOUSE_ID == registro.WAREHOUSE_ID);
                    }
                }

                _vista.Bodegas = BodegaServicio.ObtenerBodegaAsignadaAUsuarioSugCompra(InteraccionConUsuarioServicio.ObtenerUsuario());
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }
    }
}
