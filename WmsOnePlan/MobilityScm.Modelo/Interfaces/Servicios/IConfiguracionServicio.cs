using System.Collections.Generic;
using MobilityScm.Modelo.Entidades;

namespace MobilityScm.Modelo.Interfaces.Servicios
{
    public interface IConfiguracionServicio
    {
        IList<Entidades.Configuracion> ObtenerConfiguracionesGrupoYTipo(Entidades.Configuracion configuracion);
        IList<Entidades.Configuracion> ObtenerCentrosDeDistribucion(Entidades.Configuracion configuracion);
        IList<Entidades.Configuracion> ObtenerCentrosDeDistribucionPorLogin(Entidades.Configuracion configuracion);
        IList<Entidades.Configuracion> ObtenerTiposSolicitudDeTraslado(Entidades.Configuracion configuracion);

    }
}
