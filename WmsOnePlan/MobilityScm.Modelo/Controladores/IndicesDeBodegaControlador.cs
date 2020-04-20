using System;
using System.Collections.Generic;
using System.Linq;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Interfaces.Controladores;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Modelo.Vistas;
using MobilityScm.Vertical.Servicios;
using MobilityScm.Utilerias;

namespace MobilityScm.Modelo.Controladores
{
    public class IndicesDeBodegaControlador : IIndicesDeBodegaControlador
    {
        private readonly IIndicesDeBodegaVista _vista;
        public IBodegaServicio BodegaServicio { get; set; }
        public IMaterialServicio MaterialServicio { get; set; }
        public IIndiceBodegaServicio IndiceBodegaServicio { get; set; }
        public IInteraccionConUsuarioServicio InteraccionConUsuarioServicio { get; set; }

        public IndicesDeBodegaControlador(IIndicesDeBodegaVista vista)
        {
            _vista = vista;
            SuscribirEventos();
        }

        private void SuscribirEventos()
        {
            _vista.UsuarioDeseaObtenerBodegas += _vista_UsuarioDeseaObtenerBodegas;
            _vista.UsuarioDeseaObtenerMateriales += _vista_UsuarioDeseaObtenerMateriales;
            _vista.UsuarioDeseaObtenerIndicesDeBodega += _vista_UsuarioDeseaObtenerIndicesDeBodega;
            _vista.VistaCargandosePorPrimeraVez += _vista_VistaCargandosePorPrimeraVez;
        }

        private void _vista_VistaCargandosePorPrimeraVez(object sender, EventArgs e)
        {
            try
            {
                _vista_UsuarioDeseaObtenerBodegas(null, null);
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaObtenerIndicesDeBodega(object sender, Argumentos.InventarioInactivoArgumento e)
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
                    ,
                    MaterialXml = Xml.ConvertListToXml(_vista.Materiales.Where(m => m.IS_SELECTED).ToList())
                    ,
                    DateWarehouseIndices = e.DateWarehouseIndices
                };

                _vista.IndicesDeBodegas = IndiceBodegaServicio.ObtenerIndicesBodegas(arg);
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaObtenerMateriales(object sender, Argumentos.InventarioInactivoArgumento e)
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

        private void _vista_UsuarioDeseaObtenerBodegas(object sender, Argumentos.InventarioInactivoArgumento e)
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

                _vista.Bodegas = listaResultado;
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }
    }
}
