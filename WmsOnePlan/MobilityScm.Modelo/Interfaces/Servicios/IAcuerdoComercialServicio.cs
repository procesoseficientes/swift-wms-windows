using System.Collections.Generic;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Argumentos;

namespace MobilityScm.Modelo.Interfaces.Servicios
{
    public interface IAcuerdoComercialServicio
    {
        IList<AcuerdoComercial> ObtenerAcuerdosComerciales(AcuerdoComercialArgumento acuerdoComercialArgumento);

        IList<AcuerdoComercial> ObtenerAcuerdosComercialesPorCliente(AcuerdoComercial acuerdoComercial);
    }
}
