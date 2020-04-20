using System;
using System.Collections.Generic;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;

namespace MobilityScm.Modelo.Vistas
{
    public interface IConsultaDeLineaDePickingVista: IVistaBase
    {
        event EventHandler<ConsultaArgumento> UsuarioDeseaObtenerCajas;

        IList<Caja> Cajas { get; set; }
    }
}