using System.Collections.Generic;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Vertical.Entidades;

namespace MobilityScm.Modelo.Interfaces.Servicios
{
    public interface IManifiestoCargaServicio
    {
        Operacion GrabarManifiestoEncabezado(ManifiestoArgumento arg);
        Operacion GrabarManifiestoDetalle(ManifiestoArgumento arg);
        IList<ManifiestoCarga> ConsultarManifiesto(ManifiestoArgumento arg);
        ManifiestoEncabezado ObtenerManifiestoDeCarga(ManifiestoArgumento arg);
        IList<ManifiestoDetalle> ObtenerManifiestoDetalle(ManifiestoArgumento arg);
        Operacion CrearManifiestoDeCargaDesdeDemandaDeDespacho(PickingArgumento argumento, VehiculoManifiesto vehiculo);

        Operacion EliminarManifiestoDetalle(ManifiestoArgumento argumento);

        Operacion EliminarManifiestoDetalleCertificado(ManifiestoArgumento argumento);
    }
}
