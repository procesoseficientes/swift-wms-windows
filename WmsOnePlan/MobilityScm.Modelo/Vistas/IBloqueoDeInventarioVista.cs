using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;

namespace MobilityScm.Modelo.Vistas
{
    public interface IBloqueoDeInventarioVista
    {
        event EventHandler<InventarioArgumento> UsuarioDeseaObtenerInventario;

        event EventHandler<InventarioArgumento> UsuarioDeseaObtenerEstadosDeMaterial;

        event EventHandler<InventarioArgumento> UsuarioDeseaCambiarElEstadoDelInventario;

        event EventHandler VistaCargandosePorPrimeraVez;

        IList<Inventario> Inventario { get; set; }

        IList<Entidades.Configuracion> EstadosDeMaterial { get; set; }

        string Usuario { get; set; }

    }
}
