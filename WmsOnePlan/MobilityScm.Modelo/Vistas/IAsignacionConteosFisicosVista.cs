using System;
using System.Collections.Generic;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Argumentos;

namespace MobilityScm.Modelo.Vistas
{

    public interface IAsignacionConteosFisicosVista
    {

        event EventHandler UsuarioDeseaObtenerUsuarios;
        event EventHandler<ConteoFisicoArgumento> UsuarioDeseaObtenerBodegas;
        event EventHandler<ConteoFisicoArgumento> UsuarioDeseaObtenerZonas;
        event EventHandler<ConteoFisicoArgumento> UsuarioDeseaObtenerClientes;
        event EventHandler<ConteoFisicoArgumento> UsuarioDeseaObtenerUbicaciones;
        event EventHandler<ConteoFisicoArgumento> UsuarioDeseaObtenerMaterial;
        event EventHandler<ConteoFisicoArgumento> UsuarioDeseaGrabarConteoFisico;
        event EventHandler<ConteoFisicoArgumento> UsuarioDeseaObtenerUbicacionesPorFiltro;
        event EventHandler UsuarioDeseaObtenerPrioridades;
        event EventHandler VistaCargandosePorPrimeraVez;

        IList<Usuario> Usuarios { get; set; }
        IList<Bodega> Bodegas { get; set; }
        IList<Zona> Zonas { get; set; }
        IList<Cliente> Clientes { get; set; }
        IList<Ubicacion> Ubicaciones { get; set; }
        IList<Sku> Materiales { get; set; }
        IList<MobilityScm.Modelo.Entidades.Configuracion> Prioridad { get; set; }
        IList<ConteoFisicoDetalle> ConteoDetalles { get; set; }
        IList<MobilityScm.Modelo.Entidades.Configuracion> Regimen { get; set; }


    }
}
