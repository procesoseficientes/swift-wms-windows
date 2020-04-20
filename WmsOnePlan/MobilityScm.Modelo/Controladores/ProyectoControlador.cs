using System;
using System.Collections.Generic;
using System.Linq;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Interfaces.Controladores;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Modelo.Tipos;
using MobilityScm.Modelo.Vistas;
using MobilityScm.Utilerias;
using MobilityScm.Vertical.Entidades;

namespace MobilityScm.Modelo.Controladores
{
    public class ProyectoControlador : IProyectoControlador
    {
        private readonly IProyectoVista _vista;

        public IProyectoServicio ProyectoServicio { get; set; }
        public IClienteServicio ClienteServicio { get; set; }

        public ProyectoControlador(IProyectoVista vista)
        {
            _vista = vista;
            SuscribirEventos();
        }

        private void SuscribirEventos()
        {
            _vista.UsuarioDeseaEliminarProyecto += _vista_UsuarioDeseaEliminarProyecto;
            _vista.UsuarioDeseaGrabarProyecto += _vista_UsuarioDeseaGrabarProyecto;
            _vista.UsuarioDeseaObtenerProyectos += _vista_UsuarioDeseaObtenerProyectos;
            _vista.VistaCargandosePorPrimeraVez += _vista_VistaCargandosePorPrimeraVez;
            _vista.UsuarioDeseaObtenerClientesErp += _vista_UsuarioDeseaObtenerClientesErp;
            _vista.UsuarioDeseaObtenerInventarioReservado += _vista_UsuarioDeseaObtenerInventarioReservado;
            _vista.UsuarioDeseaObtenerInventarioDisponible += _vista_UsuarioDeseaObtenerInventarioDisponible;
            _vista.UsuarioDeseaAsignarInventarioAProyecto += _vista_UsuarioDeseaAsignarInventarioAProyecto;
            _vista.UsuarioDeseaEliminarInventarioDeProyecto += _vista_UsuarioDeseaEliminarInventarioDeProyecto;
            _vista.UsuarioDeseaObtenerProductos += _vista_UsuarioDeseaObtenerProductos;
        }

        private void _vista_UsuarioDeseaObtenerProductos(object sender, ProyectoArgumento e)
        {
            _vista.Skus = ProyectoServicio.ObtenerMaterialesParaFiltrarPorOwner(new ProyectoArgumento { });
        }

        private void _vista_UsuarioDeseaEliminarInventarioDeProyecto(object sender, ProyectoArgumento e)
        {
            try
            {
                Operacion op = ProyectoServicio.EliminarInventarioDeProyecto(e);
                if (op.Resultado == ResultadoOperacionTipo.Exito)
                {
                    _vista.InventarioAsignadoAProyecto = ProyectoServicio.ObtenerInventarioAsignadoAProyecto(e);
                    ObtenerResumenDeInventario(_vista.InventarioAsignadoAProyecto.ToList());
                    _vista.InventarioPendienteDeAsignar?.Clear();
                }
                else
                {
                    throw new Exception(op.Mensaje);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void _vista_UsuarioDeseaAsignarInventarioAProyecto(object sender, ProyectoArgumento e)
        {
            try
            {
                Operacion op = ProyectoServicio.AsignarInventarioAProyecto(e);
                if (op.Resultado == ResultadoOperacionTipo.Exito)
                {
                    _vista.InventarioAsignadoAProyecto = ProyectoServicio.ObtenerInventarioAsignadoAProyecto(e);
                    var materials = from m in _vista.Skus.ToList()
                                    select new Material { MATERIAL_ID = m.MATERIAL_ID, IS_SELECTED = m.IS_SELECTED };
                    e.MaterialXml = Xml.ConvertListToXml(materials.Where(m => m.IS_SELECTED).ToList());
                    _vista.InventarioPendienteDeAsignar?.Clear();
                    ObtenerResumenDeInventario(_vista.InventarioAsignadoAProyecto.ToList());
                }
                else
                {
                    throw new Exception(op.Mensaje);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void _vista_UsuarioDeseaObtenerInventarioDisponible(object sender, ProyectoArgumento e)
        {
            try
            {
                var materials = from m in _vista.Skus.ToList()
                                select new Material { MATERIAL_ID = m.MATERIAL_ID, IS_SELECTED = m.IS_SELECTED };
                e.MaterialXml = Xml.ConvertListToXml(materials.Where(m => m.IS_SELECTED).ToList());
                _vista.InventarioPendienteDeAsignar = ProyectoServicio.ObtenerInventarioDisponible(e);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void _vista_UsuarioDeseaObtenerInventarioReservado(object sender, ProyectoArgumento e)
        {
            try
            {
                _vista.InventarioAsignadoAProyecto = ProyectoServicio.ObtenerInventarioAsignadoAProyecto(e);
                ObtenerResumenDeInventario(_vista.InventarioAsignadoAProyecto.ToList());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void _vista_UsuarioDeseaObtenerClientesErp(object sender, ProyectoArgumento e)
        {
            ObtenerClientes();
        }

        private void _vista_VistaCargandosePorPrimeraVez(object sender, EventArgs e)
        {
            try
            {
                ObtenerProyectos(new ProyectoArgumento
                {
                    Proyecto = new Proyecto
                    {
                        STATUS = null
                    }
                });
                ObtenerClientes();
                _vista.ProyectoSeleccionado = new Proyecto();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void _vista_UsuarioDeseaObtenerProyectos(object sender, Argumentos.ProyectoArgumento e)
        {
            try
            {
                ObtenerProyectos(e);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void _vista_UsuarioDeseaGrabarProyecto(object sender, Argumentos.ProyectoArgumento e)
        {
            try
            {
                var op = ProyectoServicio.GrabarProyecto(e);
                if (op.Resultado == ResultadoOperacionTipo.Exito)
                {
                    _vista.ProyectoSeleccionado.ID = Guid.Parse(op.DbData);
                    _vista.VistaTermenioDeGrabar();

                }
                else
                {
                    throw new Exception(op.Mensaje);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void _vista_UsuarioDeseaEliminarProyecto(object sender, Argumentos.ProyectoArgumento e)
        {
            try
            {
                var op = ProyectoServicio.EliminarProyecto(e);
                if (op.Resultado == ResultadoOperacionTipo.Exito)
                {
                    _vista.VistaTerminoDeEliminar();
                }
                else
                {
                    throw new Exception(op.Mensaje);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ObtenerProyectos(ProyectoArgumento e)
        {
            try
            {
                _vista.Proyectos = ProyectoServicio.ObtenerProyectosPorEstado(e);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ObtenerClientes()
        {
            try
            {
                _vista.Clientes = ClienteServicio.ObtenerClientesErp(new OrdenDeVentaArgumento());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ObtenerResumenDeInventario(List<InventarioReservadoProyecto> listaDeInventario)
        {
            var listaDeMateriales = new List<ResumenInventarioProyecto>();

            foreach (var inventario in listaDeInventario)
            {
                if (!listaDeMateriales.Exists(lm => lm.MATERIAL_ID.Equals(inventario.MATERIAL_ID)))
                {
                    listaDeMateriales.Add(new ResumenInventarioProyecto
                    {
                        MATERIAL_ID = inventario.MATERIAL_ID,
                        MATERIAL_NAME = inventario.MATERIAL_NAME,
                        Licencias = new List<InventarioReservadoProyecto>()
                    });
                }
            }

            foreach (var material in listaDeMateriales)
            {
                material.Licencias = listaDeInventario.Where(li => li.MATERIAL_ID.Equals(material.MATERIAL_ID)).ToList();
                material.QTY = material.Licencias.Sum(l => l.QTY_RESERVED);
                material.QTY_DISPACHT = material.Licencias.Sum(l => l.QTY_DISPATCHED);
                material.QTY_PENDING = material.QTY - material.QTY_DISPACHT;
                material.QTY_RESERVED_PICKING = material.Licencias.Sum(l => l.RESERVED_PICKING);
            }

            _vista.ResumenProyecto = listaDeMateriales;
        }
    }
}
