using System.Collections.Generic;
using MobilityScm.Modelo.Entidades;
using System;
using Operacion = MobilityScm.Vertical.Entidades.Operacion;

namespace MobilityScm.Modelo.Interfaces.Servicios
{
    public interface IServiciosPorCobrarServicio
    {
        IList<ServicioPorCobrar> ConsultarServiciosPorCobrarPorFecha(DateTime fechaInicio , DateTime fechaFin, ServicioPorCobrar servicioPorCobrar);
        Operacion ModificarServicioPorCobrar(ServicioPorCobrar e);
        Operacion EjecutarProcesoServiciosPorCobrar(string login);
    }
}
