using System;
using System.Collections.Generic;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;

namespace MobilityScm.Modelo.Vistas
{
    public interface IIndicesDeBodegaVista
    {
        event EventHandler<InventarioInactivoArgumento> UsuarioDeseaObtenerBodegas;

        event EventHandler<InventarioInactivoArgumento> UsuarioDeseaObtenerMateriales;

        event EventHandler<InventarioInactivoArgumento> UsuarioDeseaObtenerIndicesDeBodega;

        event EventHandler VistaCargandosePorPrimeraVez;

        IList<Bodega> Bodegas { get; set; }

        IList<Material> Materiales { get; set; }

        IList<IndicesBodega> IndicesDeBodegas { get; set; }
    }
}
