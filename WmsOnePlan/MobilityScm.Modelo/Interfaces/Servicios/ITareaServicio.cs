using System.Collections.Generic;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Vertical.Entidades;

namespace MobilityScm.Modelo.Interfaces.Servicios
{
    public interface ITareaServicio
    {
        IList<Tarea> ObtenerTareas(TareaArgumento tareaArgumento);
        IList<Tarea> ObtenerTareasConDetalleDeMaterial(TareaArgumento tareaArgumento);
        IList<Tarea> ObtenerTareasParaGraficas(TareaArgumento tareaArgumento);

        IList<TareaDetalle> ObtenerTareaDetalle(TareaArgumento tareaArgumento);

        Operacion CancelarDetallePicking(TareaArgumento tareaArgumento);

        Operacion CambiarEstadoDeTarea(TareaArgumento tareaArgumento);

        Operacion CambiarOperadorDeTareaConteo(TareaArgumento tareaArgumento);

        Operacion CambiarOperadorDeTarea(TareaArgumento tareaArgumento);

        Operacion AutorizarDocumentoErpPicking(TareaArgumento tareaArgumento);

        Operacion AutorizarDocumentoErpRecepcion(TareaArgumento tareaArgumento);

        Operacion AutorizarDocumentoErpConteoFisico(TareaArgumento tareaArgumento);

        Operacion CambiarEstadoTareaConteno(TareaArgumento tareaArgumento);

        Operacion CancelarTareaPorOla(TareaArgumento tareaArgumento);

        Operacion CancelarTareaRecepcion(TareaArgumento tareaArgumento);

        Operacion CancelarTareaConteo(TareaArgumento tareaArgumento);

        Operacion DistribuirTareaATodosLosOperadores(TareaArgumento tareaArgumento);

        Operacion DistribuirTareaATodosLosOperadoresSinTarea(TareaArgumento tareaArgumento);

        Operacion ValidarAutorizacionDeRecepcionPorDevolucion(TareaArgumento argumento);
        Operacion CancelarTareaDeRecepcionPorDevolucionDeFactura(TareaArgumento argumento);


        Operacion ReasignarTareaLineaDePicking(TareaArgumento argumento);
        Operacion CancelarTareaLineaDePicking(TareaArgumento argumento);
        Operacion CambiarPrioridadDeLaTarea(TareaArgumento argumento);
        Operacion CancelarDetalleDeRecepcion(TareaArgumento argumento);
        Operacion CambiarLicenciaEnLineaDeTareaPicking(TareaArgumento argumento);
        Operacion ReabrirTareaRecepcion(TareaArgumento argumento);
        IList<TareaDetalleErp> ObtenerDetalleErpTarea(TareaArgumento argumento);
        IList<TareaDetalle> ObtenerDetalleTareaRecepcionParaConfirmacion(TareaArgumento argumento);
        IList<Tarea> ObtenerDetalleLicenciasOla(TareaArgumento argumento);
    }
}
