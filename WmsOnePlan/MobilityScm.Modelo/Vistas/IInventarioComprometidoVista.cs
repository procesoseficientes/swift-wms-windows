using System;
using System.Collections.Generic;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;

namespace MobilityScm.Modelo.Vistas
{
    public interface IInventarioComprometidoVista
    {
        event EventHandler<InventarioComprometidoArgumento> UsuarioDeseaObtenerInventarioComprometido;

        event EventHandler<InventarioComprometidoArgumento> UsuarioDeseaCancelarElInventarioPreparado;

        IList<InventarioComprometidoEncabezado> InventarioComprometidoEncabezados { get; set; }

        IList<InventarioComprometidoDetalle> InventarioComprometidoDetalles { get; set; }

        IList<InventarioComprometidoDetalle> InventarioComprometidoTodosDetalles { get; set; }

        void RecargarPantalla();
    }
}
