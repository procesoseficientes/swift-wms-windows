using DevExpress.XtraMap;
using System;
using System.Drawing;
using DevExpress.Map;
using MobilityScm.Modelo.Configuracion;
using MobilityScm.Modelo.Estados;

namespace MobilityScm.Modelo.Entidades
{
    /// <summary>
    /// Clase para mostrar tareas del cumplimiento de entrega
    /// </summary>
    [Serializable]
    public class TareaDeCumplimientoDeEntrega : MapPushpin
    {
        public TareaDeCumplimientoDeEntrega()
        {
            Text = SEQUENCE.ToString();
        }

        public int MANIFEST_HEADER_ID { get; set; }
        public string STATUS { get; set; }
        public int VEHICLE_CODE { get; set; }
        public string VEHICLE_PLATE_NUMBER { get; set; }
        public int PILOT_CODE { get; set; }
        public string PILOT_NAME { get; set; }
        public double PERCENTAGE { get; set; }
        public string CLIENT_CODE { get; set; }
        public string CLIENT_NAME { get; set; }
        public string TASK_STATUS { get; set; }
        public string REASON { get; set; }
        public int SEQUENCE { get; set; }
        public string GPS { get; set; }
        public DateTime? ASSIGNED_STAMP { get; set; }
        public int? DELAY { get; set; }
        public int TASK_ID { get; set; }
        public DateTime ACCEPTED_STAMP { get; set; }
        public DateTime COMPLETED_STAMP { get; set; }
        public EstadoTareaDeEntrega PICKING_DEMAND_STATUS { get; set; }
        public int DOCUMENT_QTY { get; set; }

        public int EstadoTarea { get; set; }

        public TimeSpan Demora
        {
            get
            {
                if(ACCEPTED_STAMP == DateTime.MinValue || COMPLETED_STAMP == DateTime.MinValue) return new TimeSpan(0);
                return COMPLETED_STAMP - ACCEPTED_STAMP;
            }
        }
        public double Latitude => Location.GetY();
        public double Longitude => Location.GetX();

        public CoordPoint Location => GeoPoint;

        public GeoPoint GeoPoint
        {
            get
            {

                var lat = GPS.Split(',')[0];
                var longitude = GPS.Split(',')[1];
                return new GeoPoint(double.Parse(lat), double.Parse(longitude));
            }
        }

        public Color Color
        {
            get
            {
                switch (EstadoTarea)
                {
                    case (int)Estados.EstadoTareaDeEntrega.Siguiente:
                        return Color.Yellow;
                    case (int)Estados.EstadoTareaDeEntrega.Cancelada:
                        return Color.Red;
                    case (int)Estados.EstadoTareaDeEntrega.Completa:
                        return Color.Green;
                    case (int)Estados.EstadoTareaDeEntrega.Parcial:
                        return Color.DarkOrange;
                    case (int)Estados.EstadoTareaDeEntrega.Pendiente:
                        return Color.Gray;
                    default:
                        return Color.DarkOrange;
                }
            }
        }
        public int DELIVERY_NOTE_ID { get; set; }
    }
}
