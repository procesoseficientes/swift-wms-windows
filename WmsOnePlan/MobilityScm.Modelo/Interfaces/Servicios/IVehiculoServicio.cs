using System.Collections.Generic;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Vertical.Entidades;

namespace MobilityScm.Modelo.Interfaces.Servicios
{
    public interface IVehiculoServicio
    {
        Operacion CrearVehiculo(VehiculoArgumento vehiculoArgumento);
        Operacion ActualizarVehiculo(VehiculoArgumento vehiculoArgumento);
        Operacion EliminarVehiculo(VehiculoArgumento vehiculoArgumento);
        Operacion AsociarVehiculoAPiloto(VehiculoArgumento vehiculoArgumento);
        Operacion DesasociarVehiculoDePiloto(VehiculoArgumento vehiculoArgumento);
        IList<Vehiculo> ObtenerVehiculos(VehiculoArgumento vehiculoArgumento);
        Vehiculo ObtenerVehiculo(VehiculoArgumento vehiculoArgumento);
        IList<Vehiculo> ObtenerVehiculosConPilotosAsociados();
        IList<Vehiculo> ObtenerVehiculosPorPeso(VehiculoArgumento vehiculoArgumento);

        IList<VehiculoManifiesto> ObtenerVehiculosParaDemandaDespacho();
    }
}