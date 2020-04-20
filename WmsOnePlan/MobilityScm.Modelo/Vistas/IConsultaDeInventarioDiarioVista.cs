using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;

namespace MobilityScm.Modelo.Vistas
{
    public interface IConsultaDeInventarioDiarioVista : IVistaBase
    {
        event EventHandler<ConsultaArgumento> UsuarioDeseaConsultarInventarioDiario;
        IList<ReporteDeInventarioDiario> Inventario { get; set; }
        IList<Bodega> Bodegas { get; set; }
        DateTime FechaReporte { get; }
    }
}
