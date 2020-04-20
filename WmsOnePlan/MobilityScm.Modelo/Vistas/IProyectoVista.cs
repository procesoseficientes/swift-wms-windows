using System;
using System.Collections.Generic;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;

namespace MobilityScm.Modelo.Vistas
{
    public interface IProyectoVista
    {
        event EventHandler<ProyectoArgumento> UsuarioDeseaObtenerProyectos;
        event EventHandler<ProyectoArgumento> UsuarioDeseaGrabarProyecto;
        event EventHandler<ProyectoArgumento> UsuarioDeseaEliminarProyecto;
        event EventHandler<ProyectoArgumento> UsuarioDeseaObtenerClientesErp;
        event EventHandler VistaCargandosePorPrimeraVez;

        
        event EventHandler<ProyectoArgumento> UsuarioDeseaObtenerInventarioDisponible;
        event EventHandler<ProyectoArgumento> UsuarioDeseaObtenerInventarioReservado;
        event EventHandler<ProyectoArgumento> UsuarioDeseaAsignarInventarioAProyecto;
        event EventHandler<ProyectoArgumento> UsuarioDeseaEliminarInventarioDeProyecto;
        event EventHandler<ProyectoArgumento> UsuarioDeseaObtenerProductos;

        IList<Proyecto> Proyectos { get; set; }

        IList<Cliente> Clientes { get; set; }

        Proyecto ProyectoSeleccionado { get; set; }

        void VistaTermenioDeGrabar();
        void VistaTerminoDeEliminar();

        IList<Material> Skus { get; set; }
        IList<InventarioReservadoProyecto> InventarioAsignadoAProyecto { get; set; }
        IList<InventarioReservadoProyecto> InventarioPendienteDeAsignar { get; set; }

        IList<ResumenInventarioProyecto> ResumenProyecto { get; set; }
    }
}
