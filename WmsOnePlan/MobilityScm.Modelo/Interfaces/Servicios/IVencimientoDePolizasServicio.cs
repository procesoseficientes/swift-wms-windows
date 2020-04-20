using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Vertical.Entidades;

namespace MobilityScm.Modelo.Interfaces.Servicios
{
    public interface IVencimientoDePolizasServicio
    {
        IList<Poliza> ObtenerPolizasListasAExpirar(PolizaArgumento polizaArgumento);
        Operacion DesbloquearPoliza(PolizaArgumento polizaArgumento);
    }
}
