using System.Collections.Generic;
using MobilityScm.Modelo.Entidades;

namespace MobilityScm.Modelo.Interfaces.Servicios
{
    public interface IPolizaAseguradaServicio
    {
        IList<PolizaAsegurada> ObtenerPolizaAseguradaPorCliente(PolizaAsegurada polizaAsegurada);
    }
}
