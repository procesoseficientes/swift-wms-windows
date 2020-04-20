using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;

namespace MobilityScm.Modelo.Vistas
{
    public interface IBalanceDeSaldosFiscalVista
    {
        event EventHandler<BalanceDeSaldosFiscalArgumento> UsuarioDeseaObtenerBalanceDeSaldosFiscal;
        event EventHandler VistaCargandosePorPrimeraVez;
        IList<BalanceDeSaldosFiscal> BalanceDeSaldosFiscal { get; set; }
    }
}
