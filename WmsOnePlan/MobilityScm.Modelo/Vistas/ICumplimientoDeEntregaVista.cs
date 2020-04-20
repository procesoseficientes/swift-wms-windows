using System;
using System.Collections.Generic;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;

namespace MobilityScm.Modelo.Vistas
{
    public interface ICumplimientoDeEntregaVista
    {
        event EventHandler VistaCargandosePorPrimeraVez;

        event EventHandler UsuarioDeseaObtenerPilotos;

        event EventHandler UsuarioDeseaObtenerVehiculos;

        event EventHandler<CumplimientoDeEntregaArgumento> UsuarioDeseaConsultarCumplimientoDeEntrega;

        event EventHandler<CumplimientoDeEntregaArgumento> UsuarioSeleccionoManifiestoDeCarga;

        event EventHandler<CumplimientoDeEntregaArgumento> UsuarioDeseaObtenerImagenesDeEntrega;

        IList<Piloto> Pilotos { get; set; }

        IList<Vehiculo> Vehiculos { get; set; }

        Vehiculo Vehiculo { get; set; }

        IList<CumplimientoDeEntrega> CumplimientoDeEntregas { get; set; }
        IList<TareaDeCumplimientoDeEntrega> TareasCumplimientodeEntregas { get; set; }

        IList<CumplimientoDeEntrega> ImagenesDeEntrega { get; set; }
    }
}