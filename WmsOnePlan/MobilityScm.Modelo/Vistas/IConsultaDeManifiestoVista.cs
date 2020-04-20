using System;
using System.Collections.Generic;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;

namespace MobilityScm.Modelo.Vistas
{
    public interface IConsultaDeManifiestoVista : IVistaBase
    {

        event EventHandler<ManifiestoArgumento> UsuarioDeseaObtenerEncabezadosDeManifiesto;
        event EventHandler<ManifiestoArgumento> UsuarioDeseaObtenerDetallesDeManifiestos;
        event EventHandler<ManifiestoArgumento> UsuarioDeseaCancelarManifiesto;
        event EventHandler<ManifiestoArgumento> UsuarioDeseaActualizarVehiculoAManifiesto;
        event EventHandler<ManifiestoArgumento> UsuarioDeseaQuitarDetallesDeManifiesto;
        event EventHandler<ManifiestoArgumento> UsuarioDeseaObtenerVehiculosConPilotoAsociado;
        IList<ManifiestoEncabezado> EncabezadosDeManifiesto { get; set; }
        IList<ManifiestoDetalle> DetallesDeManifiestos { get; set; }
        IList<Vehiculo> Vehiculos { get; set; }
        IList<Vehiculo> TodosVehiculos { get; set; }
        string Usuario { get; set; }

       IList<Parametro> Parametros { get; set; }
    }
}
