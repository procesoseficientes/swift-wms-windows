using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;

namespace MobilityScm.Modelo.Interfaces.Servicios
{
    public interface IBodegaServicio
    {
        IList<Bodega> ObtenerBodegaAsignadaAUsuario(string login);
        IList<Bodega> ObtenerBodegaAsignadaAUsuarioSugCompra(string login);
        IList<Bodega> ObtenerBodegasPorUsuariosRelacionados(ConteoFisicoArgumento conteoFisicoArgumento);
        IList<Zona> ObtenerZonasDeUnaBodega(Bodega argumento);
        IList<Bodega> ObtenerBodegaPorCentroDeDistribucion(Bodega argumento);
        IList<Bodega> ObtenerBodegaPorCentroDeDistribucionYUsuario(Bodega argumento);
        IList<Entidades.Configuracion> ObtenerLineasDePickingAsociadasABodega(Bodega argumento);
        IList<Entidades.Configuracion> ObtenerLineasDePickingAsociadasABodegaDelUsuario(Bodega argumento);
        IList<BodegaERP> ObtenerBodegasDeERP(string owner);
    }
}
