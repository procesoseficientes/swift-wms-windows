using System;
using System.Collections.Generic;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Argumentos;

namespace MobilityScm.Modelo.Vistas
{
    public interface IServicioPorCobrarVista
    {
        event EventHandler<ServicioPorCobrarArgumento> UsuarioDeseaCargarServiciosPorCobrarPorFecha;
        event EventHandler<ServicioPorCobrarArgumento> UsuarioDeseaGuardarCambioDePrecio;
        event EventHandler<ServicioPorCobrarArgumento> UsuarioDeseaEjecutarProcesoAlMomento;
        event EventHandler<ServicioPorCobrarArgumento> UsuarioDeseaMarcarComoCobrado;
        event EventHandler VistaTerminoDeCargarPorPrimeraVez;

        IList<ServicioPorCobrar> ListaDeServiciosPorCobrar { get; set; }
        IList<Cliente> Clientes { get; set; }

        string Usuario { get; set; }

    }
}
