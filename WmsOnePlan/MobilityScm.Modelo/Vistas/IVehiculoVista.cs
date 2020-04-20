using System;
using System.Collections.Generic;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;

namespace MobilityScm.Modelo.Vistas
{
    public interface IVehiculoVista
    {
        event EventHandler<VehiculoArgumento> UsuarioDeseaCrearVehiculo;
        event EventHandler<VehiculoArgumento> UsuarioDeseaActualizarVehiculo;
        event EventHandler<VehiculoArgumento> UsuarioDeseaEliminarVehiculo;
        event EventHandler<VehiculoArgumento> UsuarioDeseaObtenerVehiculos;
        event EventHandler<VehiculoArgumento> UsuarioDeseaObtenerVehiculo;
        event EventHandler<VehiculoArgumento> UsuarioDeseaAsociarPiloto;
        event EventHandler<VehiculoArgumento> UsuarioDeseaDesasociarPiloto;
        event EventHandler<PilotoArgumento> UsuarioDeseaObtenerPilotosNoAsociadosAVehiculos;
        event EventHandler<EmpresaDeTransporteArgumento> UsuarioDeseaObtenerEmpresasDeTransporte;
        event EventHandler<VehiculoArgumento> UsuarioDeseaObtenerPolizas;
        event EventHandler VistaCargandosePorPrimeraVez;
        IList<Piloto> Pilotos { get; set; }
        IList<Vehiculo> Vehiculos { get; set; }
        Vehiculo Vehiculo { get; set; }
        IList<EmpresaDeTransporte> EmpresasDeTransporte { get; set; }
        IList<PolizaAsegurada> PolizasDeSeguro { get; set; }
        IList<Parametro> Parametros { get; set; }
    }
}