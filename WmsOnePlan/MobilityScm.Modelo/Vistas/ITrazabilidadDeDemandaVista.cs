using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;

namespace MobilityScm.Modelo.Vistas
{
    public interface ITrazabilidadDeDemandaVista : IVistaBase
    {
        event EventHandler<OrdenDeVentaArgumento> UsuarioDeseaObtenerReporte;
        IList<OrdenDeVentaReporte> OrdenesDeVenta { get; set; }
        IList<Bodega> Bodegas { get; set; }
    }
}
