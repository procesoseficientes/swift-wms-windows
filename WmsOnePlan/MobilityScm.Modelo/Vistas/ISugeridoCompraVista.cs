using System;
using System.Collections.Generic;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;

namespace MobilityScm.Modelo.Vistas
{
    public interface ISugeridoCompraVista
    {
        event EventHandler<SugeridoCompraArgumento> UsuarioDeseaObtenerBodegas;

        event EventHandler<SugeridoCompraArgumento> UsuarioDeseaObtenerMateriales;
                           
        event EventHandler<SugeridoCompraArgumento> UsuarioDeseaObtenerSugeridoCompra;

        event EventHandler VistaCargandosePorPrimeraVez;

        IList<Bodega> Bodegas { get; set; }

        IList<Material> Materiales { get; set; }

        IList<Entidades.Configuracion> Configuraciones { get; set; }

        IList<SugeridoCompra> SugeridoCompra { get; set; }
    }
}
