using MobilityScm.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobilityScm.Modelo.Entidades
{
    public class VehiculoManifiesto
    {
        public VehiculoManifiesto()
        {
            Ordenes = new List<OrdenDeVentaEncabezado>();
        }

        public int VEHICLE_CODE { get; set; }
        public string VEHICLE { get; set; }
        public int TRANSPORT_COMPANY_CODE { get; set; }
        public string TRANSPORT_COMPANY_NAME { get; set; }
        public string PLATE_NUMBER { get; set; }
        public decimal RATING { get; set; }
        public decimal MAX_VOLUME { get; set; }
        public decimal USED_VOLUME { get; set; }
        public decimal ORIGINAL_USED_VOLUME { get; set; }
        public decimal AVAILABLE_VOLUME { get; set; }
        public decimal ORIGINAL_AVAILABLE_VOLUME { get; set; }
        public decimal MAX_WEIGHT { get; set; }
        public decimal USED_WEIGHT { get; set; }
        public decimal ORIGINAL_USED_WEIGHT { get; set; }
        public decimal AVAILABLE_WEIGHT { get; set; }
        public decimal ORIGINAL_AVAILABLE_WEIGHT { get; set; }
        public string STATUS { get; set; }
        public int PRIORITY { get; set; }
        public decimal FILL_RATE { get; set; }
        public int IS_OWN { get; set; }


        public int RowCount => Ordenes.Count;

        public List<OrdenDeVentaEncabezado> Ordenes { get; set; }
        public int PILOT_CODE { get; set; }
    }
}
