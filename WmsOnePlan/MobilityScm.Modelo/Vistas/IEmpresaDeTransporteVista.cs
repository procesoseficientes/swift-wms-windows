using System;
using System.Collections.Generic;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;

namespace MobilityScm.Modelo.Vistas
{
    public interface IEmpresaDeTransporteVista
    {
        event EventHandler<EmpresaDeTransporteArgumento> UsuarioDeseaCrearEmpresaDeTransporte;
        event EventHandler<EmpresaDeTransporteArgumento> UsuarioDeseaActualizarEmpresaDeTransporte;
        event EventHandler<EmpresaDeTransporteArgumento> UsuarioDeseaEliminarEmpresaDeTransporte;
        event EventHandler<EmpresaDeTransporteArgumento> UsuarioDeseaObtenerEmpresasDeTransporte;
        event EventHandler VistaCargandosePorPrimeraVez;

        EmpresaDeTransporte EmpresaDeTransporte { get; set; }
        IList<EmpresaDeTransporte> EmpresasDeTransporte { get; set; }
    }
}