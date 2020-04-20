using System;
using System.Collections.Generic;
using System.Drawing;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;

namespace MobilityScm.Modelo.Vistas
{
    public interface IManifiestoCargaVista
    {
        event EventHandler<ManifiestoArgumento> UsuarioDeseaConsultarPickingEncabezado;
        event EventHandler<ManifiestoArgumento> UsuarioDeseaConsultarPickingDetalle;
        event EventHandler UsuarioDeseaConsultarBodegas;
        event EventHandler<ManifiestoArgumento> UsuarioDeseaConsultarRutas;
        event EventHandler UsuarioDeseaConsultarVehiculos;
        event EventHandler<ManifiestoArgumento> UsuarioDeseaGrabarManifiesto;
        event EventHandler<ManifiestoArgumento> UsuarioDeseaConsultarManifiesto;
        event EventHandler VistaCargandosePorPrimeraVez;
        event EventHandler<ManifiestoArgumento> UsuarioDeseaObtenerManifiestoDeCarga;
        event EventHandler<ManifiestoArgumento> UsuarioDeseaObtenerCajasEnManifiestoDeCarga;
        event EventHandler<VehiculoArgumento> UsuarioDeseaObtenerVehiculosPorPeso;
        event EventHandler<PilotoArgumento> UsuarioDeseaObtenerPilotoPorVehiculo;
        event EventHandler<ManifiestoArgumento> UsuarioDeseaObtenerReporteDeCajasPorCliente;

        IList<Bodega> Bodegas { get; set; }
        IList<Vehiculo> Vehiculos { get; set; }
        Vehiculo Vehiculo { get; set; }
        Piloto Piloto { get; set; }
        IList<PickingDetalle> PickingDetalle { get; set; }
        IList<Picking> PickingEncabezado { get; set; }
        IList<Ruta> Rutas { get; set; }
        string Usuario { get; set; }
        IList<ManifiestoCarga> ManifiestoCarga { get; set; }
        ManifiestoEncabezado ManifiestoDeCargaEncabezado { get; set; }
        string LastManifestHeaderId { get; set; }

        Point PuntoDeEtiquetaDeRuta { get; set; }

        Point PuntoDeEtiquetaDePicking { get; set; }

        Point PuntoDeListaDeRutas { get; set; }

        Point PuntoDeListaDePickings { get; set; }

        void ObtenerPuntosDeControles();

        void TerminarProceso(object sender);

        IList<Entidades.Configuracion> Configuracion { get; set; }
        IList<Caja> Cajas { get; set; }
        bool EstaBuscando { get; set; }

        void EstablecerVehiculosEnBaseAPesoDePickings(decimal peso);

        decimal ObtenerPesoTotalDelDetalleDePicking();

        bool EstaModificando { get; set; }

        IList<Parametro> Parametros { get; set; }

        IList<CajaPorCliente> CajasPorClientes { get; set; }

        IEnumerable<int?> DetallesEliminados { get; set; }
    }
}
