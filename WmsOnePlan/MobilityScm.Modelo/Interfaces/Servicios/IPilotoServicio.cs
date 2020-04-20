using System.Collections.Generic;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Vertical.Entidades;

namespace MobilityScm.Modelo.Interfaces.Servicios
{
    public interface IPilotoServicio
    {
        Operacion CrearPiloto(PilotoArgumento pilotoArgumento);
        Operacion ActualizarPiloto(PilotoArgumento pilotoArgumento);
        Operacion EliminarPiloto(PilotoArgumento pilotoArgumento);
        Operacion AsociarPilotoAUsuarioDelSistema(PilotoArgumento pilotoArgumento);
        Operacion DesasociarPilotoDeUsuarioDelSistema(PilotoArgumento pilotoArgumento);
        IList<Piloto> ObtenerPilotosNoAsociadosAVehiculos(PilotoArgumento pilotoArgumento);
        IList<Piloto> ObtenerPilotos(PilotoArgumento pilotoArgumento);
        IList<UsuarioPorPiloto> ObteneUsuarioPorPilotos();
        Piloto ObtenerPilotoPorVehiculo(PilotoArgumento pilotoArgumento);

    }
}