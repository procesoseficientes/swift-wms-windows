using System;
using System.Collections.Generic;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;

namespace MobilityScm.Modelo.Vistas
{
    public interface ICosteoVista
    {
        event EventHandler<CosteoArgumento> UsuarioDeseaObtenerPolizasEncabezadoPendientes;
        event EventHandler<CosteoArgumento> UsuarioDeseaObtenerPolizaDetallePendiente;
        event EventHandler<CosteoArgumento> UsuarioDeseaGrabarCosto;
        event EventHandler<CosteoArgumento> UsuarioDeseaCargarExcel;
        event EventHandler<CosteoArgumento> UsuarioDeseaCambiarPrecioUnitario;
        event EventHandler<CosteoArgumento> UsuarioDeseaObtenerPolizaSeguro;
        event EventHandler<CosteoArgumento> UsuarioDeseaObtenerAcuerdosComerciales;
        event EventHandler VistaCargandosePorPrimeraVez;

        IList<Poliza> Polizas { get; set; }
        IList<PolizaDetalle> PolizaDetalles { get; set; }
        IList<PolizaDetalle> PolizaDetallesParaConsolidado { get; set; }

        IList<PolizaAsegurada> PolizaAseguradas { get; set; }
        IList<AcuerdoComercial> AcuerdoComerciales { get; set; }
        bool EsConsolidado { get; }

        string Usuario { get; set; }
    }
}
