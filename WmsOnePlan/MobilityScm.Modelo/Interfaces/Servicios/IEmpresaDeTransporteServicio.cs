using System.Collections.Generic;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Vertical.Entidades;

namespace MobilityScm.Modelo.Interfaces.Servicios
{
    public interface IEmpresaDeTransporteServicio
    {
        Operacion CrearEmpresaDeTransporte(EmpresaDeTransporteArgumento empresaDeTransporteArgumento);

        Operacion ActualizarEmpresaDeTransporte(EmpresaDeTransporteArgumento empresaDeTransporteArgumento);

        Operacion EliminarEmpresaDeTransporte(EmpresaDeTransporteArgumento empresaDeTransporteArgumento);

        IList<EmpresaDeTransporte> ObtenerEmpresasDeTransporte(EmpresaDeTransporteArgumento empresaDeTransporteArgumento);

    }
}