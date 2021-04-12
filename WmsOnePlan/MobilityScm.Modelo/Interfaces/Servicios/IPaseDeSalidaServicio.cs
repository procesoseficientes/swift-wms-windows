using System.Collections.Generic;
using System.Data;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Vertical.Entidades;

namespace MobilityScm.Modelo.Interfaces.Servicios
{
    public interface IPaseDeSalidaServicio
    {
        Operacion GrabarPaseDeSalida(PaseDeSalidaArgumento paseDeSalidaArgumento);
        IList<PaseDeSalidaEncabezado> ObtenerPase(PaseDeSalidaArgumento argumento);
        IList<PaseDeSalidaDetalle> ObtenerDetalleDePase(PaseDeSalidaArgumento argumento);
        DataTable ActualizarEstadoParaElPaseDeSalidaFerco(PaseDeSalidaArgumento paseDeSalidaArgumento);
        Operacion ActualizarEstadoParaElPaseDeSalida(PaseDeSalidaArgumento paseDeSalidaArgumento);
        IList<PaseDeSalida> ObtenerPasesDeSalidaParaReporte(PaseDeSalidaArgumento paseDeSalidaArgumento);
        IList<PaseDeSalida> ObtnerPasesDeSalidas(PaseDeSalidaArgumento paseDeSalidaArgumento);
    }
}
