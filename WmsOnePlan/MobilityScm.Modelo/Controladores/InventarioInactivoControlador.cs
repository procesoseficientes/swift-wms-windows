using System;
using System.Linq;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Utilerias;
using MobilityScm.Modelo.Interfaces.Controladores;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Modelo.Tipos;
using MobilityScm.Modelo.Vistas;
using MobilityScm.Vertical.Servicios;

namespace MobilityScm.Modelo.Controladores
{
    public class InventarioInactivoControlador : IInventarioInactivoControlador
    {
        private readonly IInventarioInactivoVista _vista;

        public IBodegaServicio BodegaServicio { get; set; }
        public IUbicacionServicio UbicacionServicio { get; set; }
        public IMaterialServicio MaterialServicio { get; set; }
        public IInventarioServicio InventarioServicio { get; set; }

        public IConfiguracionServicio ConfiguracionServicio { get; set; }
        public IInteraccionConUsuarioServicio InteraccionConUsuarioServicio { get; set; }

        public InventarioInactivoControlador(IInventarioInactivoVista vista)
        {
            _vista = vista;
            SuscribirEventos();
        }

        private void SuscribirEventos()
        {
            _vista.UsuarioDeseaObtenerBodegas += _vista_UsuarioDeseaObtenerBodegas;
            _vista.UsuarioDeseaObtenerZonas += _vista_UsuarioDeseaObtenerZonas;
            _vista.UsuarioDeseaObtenerMateriales += _vista_UsuarioDeseaObtenerMateriales;
            _vista.UsuarioDeseaObtenerIdle += _vista_UsuarioDeseaObtenerIdle;
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

        private void _vista_UsuarioDeseaObtenerIdle(object sender, InventarioInactivoArgumento e)
        {
            try
            {
                var arg = new InventarioInactivoArgumento
                {
                    Login = InteraccionConUsuarioServicio.ObtenerUsuario()
                    ,
                    WarehouseXml = Xml.ConvertListToXml(_vista.Bodegas.Where(b => b.IS_SELECTED).ToList())
                    ,
                    ZoneXml = Xml.ConvertListToXml(_vista.Zonas.Where(z => z.IS_SELECTED).ToList())
                    ,
                    MaterialXml = Xml.ConvertListToXml(_vista.Materiales.Where(m => m.IS_SELECTED).ToList())
                };

                _vista.InventarioInactivo = InventarioServicio.ObtenerInventarioInactivo(arg);
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaObtenerMateriales(object sender, InventarioInactivoArgumento e)
        {
            try
            {
                var arg = new InventarioInactivoArgumento
                {
                    Login = InteraccionConUsuarioServicio.ObtenerUsuario()
                    ,
                    WarehouseXml = Xml.ConvertListToXml(_vista.Bodegas.Where(b => b.IS_SELECTED).ToList())
                    ,
                    ZoneXml = Xml.ConvertListToXml(_vista.Zonas.Where(z => z.IS_SELECTED).ToList())
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

        private void _vista_UsuarioDeseaObtenerZonas(object sender, InventarioInactivoArgumento e)
        {
            try
            {
                var arg = new InventarioInactivoArgumento
                {
                    Login = InteraccionConUsuarioServicio.ObtenerUsuario()
                    ,
                    WarehouseXml = Xml.ConvertListToXml(_vista.Bodegas.Where(b => b.IS_SELECTED).ToList())
                };

                var listaZonasTemporal = _vista.Zonas.Where(z => z.IS_SELECTED).ToList();

                var listaZonasResultado = UbicacionServicio.ObtenerZonasPorBodegas(arg);

                if (listaZonasTemporal.Count > 0)
                {
                    foreach (var zona in listaZonasResultado)
                    {
                        zona.IS_SELECTED = listaZonasTemporal.Exists(zt => zt.IS_SELECTED && zt.ZONE == zona.ZONE);
                    }
                }
                _vista.Zonas = listaZonasResultado;
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaObtenerBodegas(object sender, InventarioInactivoArgumento e)
        {
            try
            {
                var listaTemporal = _vista.Bodegas.Where(z => z.IS_SELECTED).ToList();

                var listaResultado = BodegaServicio.ObtenerBodegaAsignadaAUsuario(InteraccionConUsuarioServicio.ObtenerUsuario());

                if (listaTemporal.Count > 0)
                {
                    foreach (var registro in listaResultado)
                    {
                        registro.IS_SELECTED = listaTemporal.Exists(lt => lt.IS_SELECTED && lt.WAREHOUSE_ID == registro.WAREHOUSE_ID);
                    }
                }

                _vista.Bodegas = BodegaServicio.ObtenerBodegaAsignadaAUsuario(InteraccionConUsuarioServicio.ObtenerUsuario());
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }
    }
}
