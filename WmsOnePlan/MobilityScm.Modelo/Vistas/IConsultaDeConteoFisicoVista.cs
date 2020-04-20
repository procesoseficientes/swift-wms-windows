using System;
using System.Collections.Generic;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;

namespace MobilityScm.Modelo.Vistas
{
    public interface IConsultaDeConteoFisicoVista
    {
        event EventHandler<ConteoFisicoArgumento> UsuarioDeseaObtenerConteosFisicos;
        event EventHandler UsuarioDeseaObtenerUsuarios;
        event EventHandler UsuarioDeseaObtenerBodegas;
        event EventHandler VistaCargandosePorPrimeraVez;

        IList<ConteoFisico> ConteosFisicos { get; set; }
        IList<Usuario> Usuarios { get; set; }
        IList<Bodega> Bodegas { get; set; }
        string Usuario { get; set; }

    }
}