using System;
using System.Collections.Generic;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Estados;
using MobilityScm.Modelo.Tipos;

namespace MobilityScm.Modelo.Vistas
{
    public interface IDemandaDeDespachoVista
    {
        event EventHandler<OrdenDeVentaArgumento> UsuarioDeseaObtenerOrdenesDeVentaPorFecha;
        event EventHandler<SkuArgumento> UsuarioDeseaValidarInventarioParaOrdenDeVenta;
        event EventHandler<OrdenDeVentaArgumento> UsuarioDeseaMarcarOrdenDeVentaConPicking;
        event EventHandler UsuarioDeseaObtenerRutas;
        event EventHandler<PickingArgumento> UsuarioDeseaCrearPickingDeOrdenDeVenta;
        event EventHandler VistaCargandosePorPrimeraVez;
        event EventHandler<OrdenDeVentaArgumento> UsuarioDeseaDescartarEncabezado;
        event EventHandler<OrdenDeVentaArgumento> UsuarioDeseaDescartarTodosEncabezadosConAdvertencia;
        event EventHandler<OrdenDeVentaArgumento> UsuarioDeseaObtenerBodegasAsignadas;
        event EventHandler UsuarioDeseaObtenerUbicacionesDeSalida;
        event EventHandler<OrdenDeVentaArgumento> UsuarioDeseaObtenerClientesErpCanalModerno;
        event EventHandler<OrdenDeVentaArgumento> UsuarioDeseaObtenerDetallesConsolidados;
        event EventHandler<OrdenDeVentaArgumento> usuarioDeseaEliminarRegistros;
        event EventHandler<OrdenDeVentaArgumento> UsuarioDeseaObtenerSolicitudesDeTransferencia;
        event EventHandler<OrdenDeVentaArgumento> UsuarioDeseaObtenerDemandasPreparadasPorFecha;
        event EventHandler UsuarioSeleccionoFuente;
        event EventHandler<OrdenDeVentaArgumento> UsuarioDeseaObtenerLineasDePickingAsociadasABodega;

        event EventHandler<OrdenDeVentaArgumento> UsuarioSeleccionoBodega;
        event EventHandler<OrdenDeVentaArgumento> UsuarioSeleccionoPoligonos;

        event EventHandler<PickingArgumento> UsuarioDeseaCambiarElOrdenDeVehiculos;

        event EventHandler<ConsultaArgumento> UsuarioCambioValorDeSwitchDeConsolidado;
        event EventHandler<ConsultaArgumento> UsuarioDeseaObtenerPrioridad;

        event EventHandler<OlaDePickingDeDemandaDespachoArgumento> UsuarioDeseaObtenerOlasDePickigGeneradas;

        event EventHandler<ConsultaArgumento> UsuarioDeseaObtenerProyectos;

        IList<OrdenDeVentaEncabezado> OrdenesDeVenta { get; set; }

        IList<Sku> Skus { get; set; }
        IList<OrdenDeVentaDetalle> DetallesOrdenDeVenta { get; set; }
        IList<OrdenDeVentaDetalle> DetallesOrdenDeVentaConsolidado { get; set; }
        IList<Ruta> Rutas { get; set; }
        string Usuario { get; set; }
        IList<Bodega> Bodegas { get; set; }

        string BodegaSeleccionda { get; }
        string UbicacionSeleccionda { get; }

        void RefrescarVistaOrdenes();

        TipoFuenteDemandaDespacho TipoFuente { get; set; }
        bool EsConsolidado { get; }
        IList<Ubicacion> Ubicaciones { get; set; }
        IList<Cliente> ClientesErpCanalModerno { get; set; }

        IList<MaterialConTonoYCalibre> MaterialesConTonoYCalibres { get; set; }

        bool EsPorTonoOCalibre { get; }

        bool ManejaLineaDePicking { get; }

        IList<Entidades.Configuracion> Permisos { get; set; }

        IList<Entidades.Configuracion> LineasDePicking { get; set; }

        IList<Poligono> Poligonos { get; set; }
        IList<Parametro> Parametros { get; set; }

        IList<VehiculoManifiesto> Vehiculos { get; set; }

        int FiltroDeUsaLineaDePicking { get; set; }

        bool EsDemandaParaEntregaInmediata { get; set; }

        bool MuestraSwitchDeEntregaInmediata { set; }

        IList<Entidades.Configuracion> PrioridadDeTarea { get; set; }

        TipoDeInventario TipoInventario { get; set; }

        IList<InventarioParaPickingPorEstado> InvnetarioDisponiblePorEstado { get; set; }
        IList<InventarioParaPickingPorEstado> EstadosDeMaterial { get; set; }

        Entidades.Configuracion EstadoPredeterminadoDeMaterial { get; set; }

        IList<OlaDePickingDeDemandaDespacho> OlasDePikingCreadas { get; set; }

        IList<Proyecto> Proyectos { get; set; }
        Proyecto ProyectoSeleccionado { get; set; }

        string NumeroOrden { get; set; }
    }
}
