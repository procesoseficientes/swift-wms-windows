using System.Collections.Generic;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Vertical.Entidades;

namespace MobilityScm.Modelo.Interfaces.Servicios
{
    public interface IProyectoServicio
    {
        Operacion GrabarProyecto(ProyectoArgumento arg);
        Operacion EliminarProyecto(ProyectoArgumento arg);
        IList<Proyecto> ObtenerProyectosPorEstado(ProyectoArgumento arg);
        Operacion AsignarInventarioAProyecto(ProyectoArgumento arg);
        Operacion EliminarInventarioDeProyecto(ProyectoArgumento arg);
        IList<Material> ObtenerMaterialesParaFiltrarPorOwner(ProyectoArgumento arg);
        IList<InventarioReservadoProyecto> ObtenerInventarioDisponible(ProyectoArgumento arg);
        IList<InventarioReservadoProyecto> ObtenerInventarioAsignadoAProyecto(ProyectoArgumento arg);
    }
}
