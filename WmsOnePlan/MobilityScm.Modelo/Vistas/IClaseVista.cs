using System;
using System.Collections.Generic;
using MobilityScm.Modelo.Argumentos;

namespace MobilityScm.Modelo.Vistas
{
    public interface IClaseVista : IVistaBase
    {
        event EventHandler<ClaseArgumento> UsuarioDeseaGuardarClase;
        event EventHandler<ClaseArgumento> UsuarioDeseaEliminarClase;
        event EventHandler<ClaseArgumento> UsuarioDeseaAsociarClases;
        event EventHandler<ClaseArgumento> UsuarioDeseaDesasociarClases;
        event EventHandler<ClaseArgumento> UsuarioDeseaObtenerClase;
        event EventHandler<ClaseArgumento> UsuarioDeseaObtenerClases;
        event EventHandler<ClaseArgumento> UsuarioDeseaObtenerClasesDisponiblesAAsociar;
        event EventHandler<ClaseArgumento> UsuarioDeseaObtenerTiposDeClases;
        event EventHandler<ClaseArgumento> UsuarioDeseaCargarClasesPorXml;

        IList<Clase> Clases { get; set; }

        Clase Clase { get; set; }

        IList<Entidades.Configuracion> Tipos { get; set; }

        IList<Clase> ClasesNoAsociadas { get; set; }

        IList<Clase> ClasesAsociadas { get; set; }
    }
}