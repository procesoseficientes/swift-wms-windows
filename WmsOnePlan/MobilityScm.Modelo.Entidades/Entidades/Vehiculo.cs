using System;

namespace MobilityScm.Modelo.Entidades
{
    [Serializable]
    public class Vehiculo
    {
        public Vehiculo() { STATUS = "DISPONIBLE"; }
        public int? VEHICLE_CODE { get; set; }

        public string BRAND { get; set; }

        public string LINE { get; set; }

        public string MODEL { get; set; }

        public string COLOR { get; set; }

        public string CHASSIS_NUMBER { get; set; }

        public string ENGINE_NUMBER { get; set; }

        public string VIN_NUMBER { get; set; }

        public string PLATE_NUMBER { get; set; }

        public int? TRANSPORT_COMPANY_CODE { get; set; }

        public string TRANSPORT_COMPANY_NAME { get; set; }

        public decimal? WEIGHT { get; set; }

        public decimal? HIGH { get; set; }

        public decimal? WIDTH { get; set; }

        public decimal? DEPTH { get; set; }

        public decimal? VOLUME_FACTOR { get; set; }

        public DateTime? LAST_UPDATE { get; set; }

        public string LAST_UPDATE_BY { get; set; }

        public int? PILOT_CODE { get; set; }

        public string PILOT_NAME { get; set; }

        public decimal RATING { get; set; }
        public int IS_ACTIVE { get; set; }
        public string STATUS { get; set; }
        public decimal FILL_RATE { get; set; }
        public int? VEHICLE_AXLES { get; set; }
        public int? INSURANCE_DOC_ID { get; set; }

        public string POLIZA_INSURANCE { get; set; }
        public string LICENSE_NUMBER { get; set; }

        public bool IS_SELECTED { get; set; }

        public decimal AVERAGE_COST_PER_KILOMETER { get; set; }

        public Vehiculo ShallowCopy()
        {
            return (Vehiculo)this.MemberwiseClone();
        }
    }
}