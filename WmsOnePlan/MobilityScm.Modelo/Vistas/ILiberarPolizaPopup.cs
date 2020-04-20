using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;

namespace MobilityScm.Modelo.Vistas
{
    public interface ILiberarPolizaPopup
    {
        event EventHandler<PolizaArgumento> UsuarioDeseaDesbloquearPolizas;

        IList<Poliza> Polizas { get; set; }
    }
}
