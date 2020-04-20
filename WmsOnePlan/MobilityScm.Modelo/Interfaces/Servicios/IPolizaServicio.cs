using System.Collections.Generic;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Vertical.Entidades;

namespace MobilityScm.Modelo.Interfaces.Servicios
{
    public interface IPolizaServicio
    {
        Operacion GuardarPolizaHeader(Poliza poliza);
        IList<PolizaAsegurada> ObtenerTodasLasPolizasDeSeguro();
    }
}
