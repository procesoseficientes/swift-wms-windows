using System;
using System.Collections.Generic;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Argumentos;

namespace MobilityScm.Modelo.Vistas
{
    public interface IAcuerdoComercialPorInventarioVista
    {
        event EventHandler<AcuerdoComercialArgumento> UsuarioDeseaObtenerAcuerdoComercialPorInventario;
        //event EventHandler UsuarioDeseaObtenerClientes;
        event EventHandler VistaCargandosePorPrimeraVez;
        IList<AcuerdoComercial> AcuerdosComerciales { get; set; }
        IList<Cliente> Clientes { get; set; }
        string Usuario { get; set; }
    }
}
