using System.Collections.Generic;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Vertical.Entidades;

namespace MobilityScm.Modelo.Interfaces.Servicios
{
    public interface IRecepcionServicio
    {
        DocumentoRecepcionERPArgumento GrabarRecepcionDesdeErp(DocumentoRecepcionERPArgumento documentoRecepcionErpArgumento);
        Operacion GrabarDocumentoRecepcionErp (DocumentoRecepcion documentoRecepcionErpEncabezado);
        
        Operacion GrabarPolizaDeRecepcion(Poliza poliza);
        Operacion GrabarTareaDeRecepcionGeneral(Tarea tarea);

        IList<DocumentoRecepcionErpEncabezado> DocumentosRecepcionErpEncabezados(FuenteExterna fuente);

        IList<DocumentoRecepcionErpDetalle> DocumentosRecepcionErpDetalles(DocumentoRecepcionErpEncabezado documentoRecepcionErpEnabezado);

        IList<DocumentoRecepcionErpDetalle> ObtenerFacturaParaDevolucion(DocumentoRecepcionErpEncabezado documentoRecepcionErpEnabezado);

        IList<ReporteRecepcionPorDevolucion> ObtenerReporteRecepcionPorDevoulucion(ConsultaArgumento argumento);
    }
}
