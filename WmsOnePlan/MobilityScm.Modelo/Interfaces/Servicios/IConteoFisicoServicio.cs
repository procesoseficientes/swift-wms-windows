using System.Collections.Generic;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Vertical.Entidades;

namespace MobilityScm.Modelo.Interfaces.Servicios
{
    public interface IConteoFisicoServicio
    {    
        Operacion GenerarTareaConteoFisico(ConteoFisicoArgumento conteoFisicoArgumento);
        Operacion InsertarTarea(ConteoFisicoArgumento conteoFisicoArgumento);
        Operacion InsertarConteoFisicoEncabezado(ConteoFisicoArgumento conteoFisicoArgumento);
        Operacion InsertarConteoFisicoDetalle(ConteoFisicoArgumento conteoFisicoArgumento);

        IList<ConteoFisico> ConsultarConsConteosFisicos(ConteoFisicoArgumento conteoFisicoArgumento);
    }
}
