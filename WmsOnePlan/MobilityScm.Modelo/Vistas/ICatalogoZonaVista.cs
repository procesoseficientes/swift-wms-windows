using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;

namespace MobilityScm.Modelo.Vistas
{
    public interface ICatalogoZonaVista
    {
        event EventHandler UsuarioDeseaConsultarZonas;
        event EventHandler<ZonaArgumento> UsuarioDeseaAgregarZona;
        event EventHandler<ZonaArgumento> UsuarioDeseaActualizarZona;
        event EventHandler<ZonaArgumento> UsuarioDeseaEliminarZona;
        event EventHandler<ZonaArgumento> UsuarioDeseaConsultarZonasAsociadas;
        event EventHandler<ZonaArgumento> UsuarioDeseaConsultarZonasParaAsociar;
        event EventHandler<ZonaArgumento> UsuarioDeseaAsociarZonaDeReabastecimiento;
        event EventHandler<ZonaArgumento> UsuarioDeseaDesasociarZonaDeReabastecimiento;
        event EventHandler<ConsultaArgumento> UsuarioDeseaCargarBodegas;
        event EventHandler UsuarioDeseaCargarLineasDePicking;

        IList<Zona> Zonas { get; set; }

        IList<Zona> ZonaAsociadas { get; set; }

        IList<Zona> ZonaAAsociar { get; set; }

        IList<Entidades.Configuracion> LineasDePicking { get; set; }

        IList<Bodega> Bodegas { get; set; }
    }
}
