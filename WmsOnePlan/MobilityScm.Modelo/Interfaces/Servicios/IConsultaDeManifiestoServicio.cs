using System.Collections.Generic;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Vertical.Entidades;

namespace MobilityScm.Modelo.Interfaces.Servicios
{
    public interface IConsultaDeManifiestoServicio
    {
        IList<ManifiestoEncabezado> ObtenerEncabezadosDeManifiesto(ManifiestoArgumento manifiestoArgumento);     
        Operacion CancelarManifiesto(ManifiestoArgumento manifiestoArgumento);
        Operacion ActualizarVehiculoAManifiesto(ManifiestoArgumento manifiestoArgumento);
        Operacion DesasociarDemandasDespachoDeManifiesto(ManifiestoArgumento manifiestoArgumento);

    }
}
