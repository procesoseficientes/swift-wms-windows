using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;

namespace MobilityScm.Modelo.Vistas
{
    public interface IReporteRecepcionPorDevolucionVista : IVistaBase
    {
        event EventHandler<ConsultaArgumento> UsuarioDeseaObtenerRecepcionesPorDevolucion;

        IList<ReporteRecepcionPorDevolucion> RecepcionesPorDevoluciones { get; set; }
        IList<Bodega> Bodegas { get; set; }
    }
}
