using System;
using System.Collections.Generic;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;

namespace MobilityScm.Modelo.Vistas
{
    public interface IInventarioInactivoVista
    {
        event EventHandler<InventarioInactivoArgumento> UsuarioDeseaObtenerBodegas;

        event EventHandler<InventarioInactivoArgumento> UsuarioDeseaObtenerZonas;

        event EventHandler<InventarioInactivoArgumento> UsuarioDeseaObtenerMateriales;

        event EventHandler<InventarioInactivoArgumento> UsuarioDeseaObtenerIdle;

        event EventHandler VistaCargandosePorPrimeraVez;

        IList<Bodega> Bodegas { get; set; }

        IList<Zona> Zonas { get; set; }

        IList<Material> Materiales { get; set; }

        IList<Entidades.Configuracion> Configuraciones { get; set; }

        IList<InventarioInactivo> InventarioInactivo { get; set; }
    }
}
