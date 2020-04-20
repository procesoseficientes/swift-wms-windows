using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;

namespace MobilityScm.Modelo.Vistas
{
    public interface IConsultaCosteoVista
    {
        event EventHandler<CosteoArgumento> UsuarioDeseaObtenerPolizasMaestroDetallePendientesDeAutorizar;
        event EventHandler<CosteoArgumento> UsuarioDeseaAutorizarCosteoPoliza;

        event EventHandler VistaCargandosePorPrimeraVez;
        IList<PolizaMaestroDetalle> PolizasMaestroDetalle { get; set; }
        IList<Bodega> Bodegas { get; set; }
        bool LineasAbiertas { get; }
        string Usuario { get; set; }
    }
}
