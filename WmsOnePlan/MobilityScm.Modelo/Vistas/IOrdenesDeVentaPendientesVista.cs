using System;
using System.Collections.Generic;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;

namespace MobilityScm.Modelo.Vistas
{
    public interface IOrdenesDeVentaPendientesVista
    {
        event EventHandler<OrdenDeVentaArgumento> UsuarioDeseaObtenerOrdenesDeVentaPendiente;
        event EventHandler UsuarioDeseaObtenerRutas;
        event EventHandler VistaCargandosePorPrimeraVez;
        event EventHandler UsuarioDeseaQuitarLineasCompletas;
        IList<OrdenDeVentaPendiente> OrdenesDeVentaPendiente { get; set; }
        IList<Ruta> Rutas { get; set; }
        bool OrdenesDeErp { get;  }
        bool OrdenesDeSonda { get; }
    }
}
