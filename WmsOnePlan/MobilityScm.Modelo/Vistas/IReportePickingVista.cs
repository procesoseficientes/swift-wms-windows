using MobilityScm.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobilityScm.Modelo.Vistas
{
    public interface IReportePickingVista
    {

        event EventHandler VistaCargandosePorPrimeraVez;
        event EventHandler UsuarioDeseaRefrescarReporte;

        IList<ReportePicking> DetalleReportePicking { get; set; }
        DateTime FechaInicial { get; set; }
        DateTime FechaFinal { get; set; }
    }
}
