using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;

namespace MobilityScm.Modelo.Vistas
{
    public interface IVencimientoDePolizasVista
    {
        event EventHandler VistaCargandosePorPrimeraVez;
        event EventHandler UsuarioDeseaObtenerClientes;
        event EventHandler<PolizaArgumento> UsuarioDeseaObtenerPolizas;

        IList<Poliza> Polizas { get; set; }
        IList<Cliente> Clientes { get; set; }
        IList<Seguridad> Permisos { get; set; }
    }
}
