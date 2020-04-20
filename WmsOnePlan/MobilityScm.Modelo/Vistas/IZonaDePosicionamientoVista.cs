using System;
using System.Collections.Generic;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;

namespace MobilityScm.Modelo.Vistas
{
    public interface IZonaDePosicionamientoVista
    {
        event EventHandler<PosicionamientoArgumento> UsuarioDeseaObtenerBodegas;

        event EventHandler<PosicionamientoArgumento> UsuarioDeseaObtenerZonasDePosicionamiento;

        event EventHandler<PosicionamientoArgumento> UsuarioDeseaGrabarZonasDePosicionamiento;

        event EventHandler<PosicionamientoArgumento> UsuarioDeseaObtenerClasesDisponibles;

        event EventHandler<PosicionamientoArgumento> UsuarioDeseaObtenerClasesAsociadas;

        event EventHandler<PosicionamientoArgumento> UsuarioDeseaQuitarClases;

        event EventHandler<PosicionamientoArgumento> UsuarioDeseaAgregarClases;

        event EventHandler<PosicionamientoArgumento> UsuarioDeseaCargarPlantilla;

        event EventHandler VistaCargandosePorPrimeraVez;

        IList<Bodega> Bodegas { get; set; }

        IList<ZonaDePosicionamiento> ZonasDePosicionamientos { get; set; }

        IList<Parametro> Parametros { get; set; }

        IList<Clase> ClasesDisponibles { get; set; }

        IList<Clase> ClasesAsociadas { get; set; }

        ZonaDePosicionamiento ZonasDePosicionamientoSeleccionado { get; set; }
    }
}
