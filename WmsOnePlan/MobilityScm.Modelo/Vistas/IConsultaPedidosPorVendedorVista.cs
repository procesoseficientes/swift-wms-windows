using System;
using System.Collections.Generic;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;

namespace MobilityScm.Modelo.Vistas
{
    public interface IConsultaPedidosPorVendedorVista: IVistaBase
    {
        event EventHandler<ConsultaArgumento> UsuarioDeseaObtenerReporte;

        IList<ReportePedidosPorVendedor> PedidosPorVendedor { get; set; }

        IList<Bodega> Bodegas { get; set; }
    }
}