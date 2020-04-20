using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;

namespace MobilityScm.Modelo.Interfaces.Servicios
{
    public interface IPoligonoServicio
    {
        IList<Poligono> ObtenerPoligonosDeDistribucionPorBodega(OrdenDeVentaArgumento argumento);
    }
}
