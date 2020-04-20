using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MobilityScm.Modelo.Entidades;

namespace MobilityScm.Modelo.Argumentos
{
    public class PickingArgumento : ConsultaArgumento
    {
        public IList<OrdenDeVentaDetalle> Detalle { get; set; }
        public IList<OrdenDeVentaEncabezado> Encabezados { get; set; }

        public IList<Picking> Pickings { get; set; }
        public Poliza Poliza { get; set; }

        public Ubicacion Ubicacion { get; set; }
        public bool EsConsolidado { get; set; }
        public bool ManejaLineaDePicking { get; set; }
        public string LineaDePicking { get; set; }
        public Tipos.TipoFuenteDemandaDespacho TipoDespacho { get; set; }
        public Tipos.PrioridadVehiculos PrioridadOrden { get; set; }
        public IList<VehiculoManifiesto> Vehiculos { get; set; }
        public VehiculoManifiesto Vehiculo { get; set; }
        public int PrioridadNueva { get; set; }
        public string Bodega { get; set; }
        public bool EsDemandaParaEntregaInmediata { get; set; }
        public int PrioridadDeTarea { get; set; }
        public string Xml { get; set; }
        public Proyecto Proyecto { get; set; }
        public string NumeroOrden { get; set; }
    }
}
