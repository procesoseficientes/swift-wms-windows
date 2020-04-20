using System.Collections.Generic;
using MobilityScm.Modelo.Entidades;

namespace MobilityScm.Modelo.Interfaces.Servicios
{
    public interface IUsuarioServicio
    {
        IList<Usuario> ObtenerUsuariosTipoBodega();

        IList<Usuario> ObtenerUsuariosTipoBodegaAsignadosCD(string centroDistribucion);
        IList<Usuario> ObtenerUsuariosTipoBodegaAsignadosAlUsuario(string login);

        IList<RolDeUsuario> ObtenerRolesDeUsuario();
        IList<Usuario> ObtenerUsuariosPorRol(RolDeUsuario rolDeUsuario);
        IList<Usuario> ObtenerUsuariosActivosPorCentroDeDistribucion(string centroDistribucion);
        IList<Usuario> ObtenerUsuariosSonda();
    }
}
