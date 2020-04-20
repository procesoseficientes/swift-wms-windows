using System;
using System.Collections.Generic;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;

namespace MobilityScm.Modelo.Vistas
{
    public interface IConsultaDePaseDeSalidaVista
    {
        event EventHandler<PaseDeSalidaArgumento> UsuarioDeseaObtenerPasesDeSalida;
        event EventHandler VistaCargandosePorPrimeraVez;
        IList<PaseDeSalida> PasesDeSalida { get; set; }

        void InicializarCampos();
    }
}