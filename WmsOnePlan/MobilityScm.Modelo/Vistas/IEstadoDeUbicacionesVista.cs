

using System;
using System.Collections.Generic;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;

namespace MobilityScm.Modelo.Vistas
{
    public interface IEstadoDeUbicacionesVista
    {
        event EventHandler<EstadoDeUbicacionArgumento> UsuarioDeseaObtenerBodegasAsignadasAUsuario;
        event EventHandler<EstadoDeUbicacionArgumento> UsuarioDeseaObtenerZonasPorWarehouse;
        event EventHandler<EstadoDeUbicacionArgumento> UsuarioDeseaObtenerEstadoDeUbicaciones;
        event EventHandler VistaCargandosePorPrimeraVez;

        IList<Ubicacion> Ubicaciones { get; set; }
        IList<Bodega> Bodegas { get; set; }
        IList<Zona> Zonas { get; set; }
        IList<MobilityScm.Modelo.Entidades.Configuracion> TiposUbicacion { get; set; }

    }
}
