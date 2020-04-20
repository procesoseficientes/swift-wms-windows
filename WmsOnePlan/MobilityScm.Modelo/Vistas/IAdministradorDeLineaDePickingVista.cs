using System;
using System.Collections.Generic;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;

namespace MobilityScm.Modelo.Vistas
{
    public interface IAdministradorDeLineaDePickingVista: IVistaBase
    {
        event EventHandler<ConsultaArgumento> UsuarioDeseaConsultarCaja;

        event EventHandler<CajaArgumento> UsuarioDeseaActualizarCaja;

        IList<Caja> Cajas { get; set; }
    }
}