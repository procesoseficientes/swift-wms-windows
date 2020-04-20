using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Argumentos;

namespace MobilityScm.Modelo.Vistas
{
    public interface IMasterPackVista
    {
        event EventHandler<MasterPackArgumento> UsuarioDeseaObtenerMaestroDetalleDeMasterPack;
        event EventHandler<MasterPackArgumento> UsuarioDeseaObtenerMasterPacksPorFechaDeExplocion;
        event EventHandler<MasterPackArgumento> UsuarioDeseaObtenerDetallesDeMasterPacks;
        event EventHandler<MasterPackArgumento> UsuarioDeseaAutorizarMasterPackERP;
        event EventHandler VistaCargandosePorPrimeraVez;

        IList<MasterPackMaestroDetalle> MaestroDetalles { get; set; }
        IList<MasterPackEncabezado> MasterPackEncabezados { get; set; }
        IList<MasterPackDetalle> MasterPackDetalles { get; set; }

        string Usuario { get; set; }
    }
}
