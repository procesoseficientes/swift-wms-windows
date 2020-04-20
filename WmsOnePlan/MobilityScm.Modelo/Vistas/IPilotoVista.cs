using System;
using System.Collections.Generic;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;

namespace MobilityScm.Modelo.Vistas
{
    public interface IPilotoVista
    {
        event EventHandler<PilotoArgumento> UsuarioDeseaCrearPiloto;

        event EventHandler<PilotoArgumento> UsuarioDeseaActualizarPiloto;

        event EventHandler<PilotoArgumento> UsuarioDeseaEliminarPiloto;

        event EventHandler<PilotoArgumento> UsuarioDeseaObtenerPilotos;

        event EventHandler<PilotoArgumento> UsuarioDeseaAsociarPilotoAUsuarioDelSistema;

        event EventHandler<PilotoArgumento> UsuarioDeseaDesasociarPilotoDeUsuarioDelSistema;  

        event EventHandler UsuarioDeseaObtenerRoles;

        event EventHandler<PilotoArgumento> UsuarioDeseaObtenerUsuariosPorRol;

        event EventHandler VistaCargandosePorPrimeraVez;

        Piloto Piloto { get; set; }

        IList<Piloto> Pilotos { get; set; }

        IList<RolDeUsuario> RolesDeUsuario { get; set; }

        //IList<Usuario> UsuariosPorRol { get; set; }

        IList<UsuarioPorPiloto> UsuariosPorPilotos { get; set; }

        IList<Usuario> UsuariosExternos { get; set; }
        IList<Parametro> Parametros { get; set; }
    }
}