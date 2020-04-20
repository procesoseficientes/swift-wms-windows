using System.Collections.Generic;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Vertical.Entidades;

namespace MobilityScm.Modelo.Interfaces.Servicios
{
    public interface ILineaDePickingServicio
    {
        IList<Caja> ObtenerCajasPorFecha(ConsultaArgumento consultaArgumento);
        IList<Caja> ObtenerCajasPorManifiestoDeCarga(ManifiestoArgumento consultaArgumento);

        IList<CajaPorCliente> ObtenerCajasPorCliente(ManifiestoArgumento argumento);

        IList<Caja> ObtenerCajaPorId(ConsultaArgumento consultaArgumento);

        Operacion ModificarCaja(CajaArgumento cajaArgumento);
    }
}